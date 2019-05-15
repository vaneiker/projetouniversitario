using Microsoft.Practices.EnterpriseLibrary.Logging;
using Newtonsoft.Json;
using STL.POS.AgentWSProxy;
using STL.POS.AgentWSProxy.AgentService;
using STL.POS.Data;
using STL.POS.Frontend.Web.Helpers;
using STL.POS.Frontend.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace STL.POS.Frontend.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IAgentProxy agentProxy;
        private int bl = Constants.BUSINESSLINE_ID_AUTO == 1 ? 2 : Constants.BUSINESSLINE_ID_AUTO;
        public HomeController(PosModel da, IAgentProxy aProxy)
            : base(da)
        {
            agentProxy = aProxy;
        }

        // GET: Home
        //[Authorize]
        public ActionResult Index()
        {
            var user = GetCurrentUsuario();

            /*
             true = Solo usuarios Logueados
             false =  Todo el mundo
             */
            var onlyLoggedUsers = allowOnlyLoggedUsers();

            if (user == null && onlyLoggedUsers)
            {
                var urlLogin = System.Web.Configuration.WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture);

                Session.RemoveAll();

                return Redirect(urlLogin);
            }

            if (user != null)
            {
                ViewBag.isDefaultUser = (user.UserLogin == "mamercedes");
            }
            else
            {
                ViewBag.isDefaultUser = false;
            }

            Session["ShowOrNotMenu"] = false;

            return View();
        }

        public ActionResult GetCountriesBl()
        {
            var onlyLoggedUsers = allowOnlyLoggedUsers();

            bool IsPVLifeRole = false;
            bool IsPVAutoRole = false;
            bool IsPVGeneralesRole = false;
            bool IsPVSaludRole = false;

            if (onlyLoggedUsers == false)
            {
                IsPVAutoRole = true;
            }
            else
            {
                var UsuarioRoles = Usuario.rolesByUser;

                IsPVLifeRole = UsuarioRoles.Any(o => o.Rol_Name.Contains("LIFE-NewBusiness"));
                IsPVAutoRole = UsuarioRoles.Any(o => o.Rol_Name.Contains("Auto-PuntoDeVenta"));
                IsPVGeneralesRole = UsuarioRoles.Any(o => o.Rol_Name.Contains("Generales-PuntoDeVenta"));
                IsPVSaludRole = UsuarioRoles.Any(o => o.Rol_Name.Contains("Salud-PuntoDeVenta"));
            }

            var countries = from c in dataAccess.ST_GLOBAL_COUNTRY.Include("BusinessLines")
                            where c.BusinessLines.Count > 0
                            && c.Global_Country_Status
                            orderby c.Global_Country_Desc
                            select c;


            List<ST_GLOBAL_COUNTRY> Lcountries = new List<ST_GLOBAL_COUNTRY>();
            var allCountrys = countries.ToList();

            foreach (var c in allCountrys)
            {
                var blByCountry = c.BusinessLines.ToList();
                List<BusinessLine> realBussinesLine = new List<BusinessLine>();

                foreach (var bl in blByCountry)
                {
                    if (IsPVLifeRole && bl.Name.Contains("Vida"))
                    {
                        realBussinesLine.Add(bl);
                    }

                    if (IsPVAutoRole && bl.Name.Contains("Auto"))
                    {
                        realBussinesLine.Add(bl);
                    }

                    if (IsPVGeneralesRole && bl.Name.Contains("Lineas Comerciales"))
                    {
                        realBussinesLine.Add(bl);
                    }

                    if (IsPVGeneralesRole && bl.Name.Contains("Vivienda"))
                    {
                        realBussinesLine.Add(bl);
                    }

                    if (IsPVSaludRole && bl.Name.Contains("Salud"))
                    {
                        realBussinesLine.Add(bl);
                    }
                }

                if (realBussinesLine.Count() > 0)
                {
                    c.BusinessLines = realBussinesLine;
                    Lcountries.Add(c);
                }
            }

            Lcountries.ToList().ForEach(f =>
            {
                f.BusinessLines = f.BusinessLines.OrderBy(c => c.Name).ToList();
            });

            return Json(Lcountries.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SelectAction(int? countryId, int businessLineId)
        {
            var onlyLoggedUsers = allowOnlyLoggedUsers();
            var businessLine = dataAccess.BusinessLines.First(b => b.Id == businessLineId);
            if (onlyLoggedUsers)
            {
                var user = GetCurrentUsuario();

                /*Conectandome al Site de Salud*/
                if (businessLine != null && businessLine.Name.Contains("Salud") && user != null)
                {
                    string PvSaludPath = System.Configuration.ConfigurationManager.AppSettings["PvSaludPath"].ToString();
                    string PvSaludApp_Name = System.Configuration.ConfigurationManager.AppSettings["PvSaludApp_Name"].ToString();

                    var addInfo = new Statetrust.Framework.Security.Bll.Item.AdditionalInfo
                    {
                        CompanyId = Usuario.CurrentCompanyId, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                        Language = Usuario.CurrentLanguageKey, //Idioma en el que quiere que se vea la aplicación a acceder.
                        AppName = PvSaludApp_Name,
                        RedirectUrl = PvSaludPath
                    };

                    var data = GenerateToken(Usuario.UserID, addInfo); //Genera un nuevo Token y se le pasa el ID del Usuario, el WebControl que lo llamo para leer los parámetros de aplicación y el Additional info para saber la compañía y el idioma.

                    if (data.Status) //Devuelve True en caso de que el logueo haya sido exitoso.
                    {
                        FormsAuthentication.SignOut();
                        return Json(new { sucess = true, pathredirect = data.UrlPath, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string msjerrr = data.errormessage;
                        if (msjerrr == "This user does not have access to this page or App")
                        {
                            msjerrr = Globalization.Home.HomeIndex.userNotAllowed;
                        }
                        return Json(new { sucess = false, pathredirect = "", message = msjerrr }, JsonRequestBehavior.AllowGet);
                    }
                }
                /**/

                /*Conectandome al Site de Propiedad - Lineas Comerciales*/
                else if (businessLine != null && businessLine.Name.Contains("Lineas Comerciales") && user != null)
                {
                    string PVLineasAliadasPath = dataAccess.GetParameter(Parameter.PARAMETER_KEY_LINEAS_COMERCIALES_PATH, "PropiedaCotizacion.aspx?IDQuotationBusiness=0&GlobalRamo=3&Pais=129").Value;
                    string PVLineasAliadasApp_Name = System.Configuration.ConfigurationManager.AppSettings["PVLineasAliadasApp_Name"].ToString();

                    var addInfo = new Statetrust.Framework.Security.Bll.Item.AdditionalInfo
                    {
                        CompanyId = Usuario != null ? Usuario.CurrentCompanyId : 1, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                        Language = Usuario != null ? Usuario.CurrentLanguageKey : "es", //Idioma en el que quiere que se vea la aplicación a acceder.
                        AppName = PVLineasAliadasApp_Name,
                        RedirectUrl = PVLineasAliadasPath
                    };

                    var data = GenerateToken(Usuario.UserID, addInfo);

                    if (data.Status)
                    {
                        FormsAuthentication.SignOut();
                        return Json(new { sucess = true, pathredirect = data.UrlPath, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string msjerrr = data.errormessage;
                        if (msjerrr == "This user does not have access to this page or App")
                        {
                            msjerrr = Globalization.Home.HomeIndex.userNotAllowed;
                        }
                        return Json(new { sucess = false, pathredirect = "", message = msjerrr }, JsonRequestBehavior.AllowGet);
                    }
                }
                /**/
                /*Conectandome al Site de Propiedad - Lineas Comerciales*/
                else if (businessLine != null && businessLine.Name.Contains("Vivienda") && user != null)
                {
                    string PVLineasAliadasPath = dataAccess.GetParameter(Parameter.PARAMETER_KEY_VIVIENDA_PATH, "PropiedaCotizacion.aspx?IDQuotationBusiness=0&GlobalRamo=2&Pais=129").Value;
                    string PVLineasAliadasApp_Name = System.Configuration.ConfigurationManager.AppSettings["PVLineasAliadasApp_Name"].ToString();

                    var addInfo = new Statetrust.Framework.Security.Bll.Item.AdditionalInfo
                    {
                        CompanyId = Usuario != null ? Usuario.CurrentCompanyId : 1, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                        Language = Usuario != null ? Usuario.CurrentLanguageKey : "es", //Idioma en el que quiere que se vea la aplicación a acceder.
                        AppName = PVLineasAliadasApp_Name,
                        RedirectUrl = PVLineasAliadasPath
                    };

                    var data = GenerateToken(Usuario.UserID, addInfo);

                    if (data.Status)
                    {
                        FormsAuthentication.SignOut();
                        return Json(new { sucess = true, pathredirect = data.UrlPath, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string msjerrr = data.errormessage;
                        if (msjerrr == "This user does not have access to this page or App")
                        {
                            msjerrr = Globalization.Home.HomeIndex.userNotAllowed;
                        }
                        return Json(new { sucess = false, pathredirect = "", message = msjerrr }, JsonRequestBehavior.AllowGet);
                    }
                }
                /**/

                /*Conectandome al Site de Propiedad - Vida*/
                else if (businessLine != null && businessLine.Name.Contains("Vida") && user != null)
                {
                    string PvVidaPath = dataAccess.GetParameter(Parameter.PARAMETER_KEY_VIDA_PATH, "AddNewClient.aspx").Value;
                    string PVVidaApp_Name = System.Configuration.ConfigurationManager.AppSettings["PVVidaApp_Name"].ToString();

                    var addInfo = new Statetrust.Framework.Security.Bll.Item.AdditionalInfo
                    {
                        CompanyId = Usuario != null ? Usuario.CurrentCompanyId : 1, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                        Language = Usuario != null ? Usuario.CurrentLanguageKey : "es", //Idioma en el que quiere que se vea la aplicación a acceder.
                        AppName = PVVidaApp_Name,
                        RedirectUrl = PvVidaPath
                    };

                    var data = GenerateToken(Usuario.UserID, addInfo);

                    if (data.Status)
                    {
                        FormsAuthentication.SignOut();
                        return Json(new { sucess = true, pathredirect = data.UrlPath, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string msjerrr = data.errormessage;
                        if (msjerrr == "This user does not have access to this page or App")
                        {
                            msjerrr = Globalization.Home.HomeIndex.userNotAllowed;
                        }
                        return Json(new { sucess = false, pathredirect = "", message = msjerrr }, JsonRequestBehavior.AllowGet);
                    }
                }
                /**/

                else
                {
                    return Json(new { sucess = true, pathredirect = businessLine.Path, message = "" }, JsonRequestBehavior.AllowGet);
                }
                /**/
            }

            return Json(new { sucess = true, pathredirect = businessLine.Path, message = "" }, JsonRequestBehavior.AllowGet);
        }
        
        private string GetUrlByQuotationType(Quotation quotation)
        {
            if (quotation.GetType() == typeof(QuotationAuto))
            {
                string encodeEncriptation = STL.POS.Data.CSEntities.Helperes.Encode(quotation.Id.ToString());
                return Url.Action("Index", "PosAuto", new { Area = "Auto", id = encodeEncriptation });
            }
            else
            {
                return Url.Action("Index", "Home", new { Area = string.Empty });
            }
        }

        public ActionResult SelectQuotationByFilter(SelectQuotationFilterModel model)
        {
            //if (model.QuotationId.HasValue)
            if (!string.IsNullOrEmpty(model.QuotationId))
            {
                var decriptedID = STL.POS.Data.CSEntities.Helperes.Decode(model.QuotationId);
                int realID = Convert.ToInt32(decriptedID);

                var quot = dataAccess.Quotations.FirstOrDefault(f => f.Id == realID);

                if (quot.Status == QuotationStatus.Finalized)
                {
                    model.Error = "No puede mostrarse la cotización dado que ya fue finalizada e informada a nuestras oficinas comerciales.";
                    return View("SelectQuotation", model);
                }
                else
                    return Redirect(GetUrlByQuotationType(quot));
            }
            else if (!string.IsNullOrEmpty(model.QuotationNumber))
            {
                var quot = dataAccess.Quotations.FirstOrDefault(f => f.QuotationNumber == model.QuotationNumber);
                if (quot != null)
                {
                    if (quot.Status == QuotationStatus.Finalized)
                    {
                        model.Error = "No puede mostrarse la cotización dado que ya fue finalizada e informada a nuestras oficinas comerciales.";
                        return View("SelectQuotation", model);
                    }
                    else
                        return Redirect(GetUrlByQuotationType(quot));
                }
                else
                {
                    model.Error = "No se ha encontrado la cotización solicitada";
                    return View("SelectQuotation", model);
                }
            }
            else if (!string.IsNullOrEmpty(model.PrincipalId) && model.Day.HasValue && model.Month.HasValue && model.Year.HasValue)
            {
                var id = model.PrincipalId + model.Day.Value.ToString("00") + model.Month.Value.ToString("00") + model.Year.Value.ToString("0000");

                //var user = dataAccess.Users.FirstOrDefault(u => u.Username == id && u.UserOrigin == UserOrigins.POS);

                //if (user == null)
                //{
                //    model.Error = "No se han encontrado cotizaciones pertenecientes a la persona indicada.";
                //    return View("SelectQuotation", model);
                //}
                //else
                //{
                //FormsAuthentication.SetAuthCookie(id, false);
                return Redirect(Url.Action("QuotationSearch", "Home", new { Area = string.Empty, currentUserName = id }));
                //}
            }
            else
            {
                model.Error = "No hay suficientes datos para buscar una cotización.";
                return View("SelectQuotation", model);
            }
        }

        public ActionResult SelectQuotation()
        {
            return View(new SelectQuotationFilterModel());
        }

        public ActionResult QuotationSearch(string currentUserName)
        {
            var user = GetCurrentUsuario();
            /*
            1 = Si, Solo usuarios Logueados
            2 = No, Todo el mundo
            */
            var onlyLoggedUsers = allowOnlyLoggedUsers();

            if (user == null && onlyLoggedUsers)
            {
                var urlLogin = System.Web.Configuration.WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture);

                Session.RemoveAll();

                return Redirect(urlLogin);
            }


            if (!onlyLoggedUsers)
            {
                Session["ShowOrNotMenu"] = false;
            }
            else
            {
                Session["ShowOrNotMenu"] = true;
            }

            ViewBag.CurrentUserName = currentUserName;
            return View();
        }

        public ActionResult GetQuotations(int currentPage,
            int pageSize,
            string agentNameId,
            int? quotationId,
            string principalName,
            string identification,
            string quotationDate,
            int? businessLine,
            string plan,
            int? currency,
            decimal? annualPrime,
            decimal? taxes,
            decimal? total,
            string primeOperatorSelected,
            string taxesOperatorSelected,
            string totalOperatorSelected,
            string currentUserName,
            string AgentQuotationNameID)
        {
            IQueryable<Quotation> quotations;
            var usuario = GetCurrentUsuario();
            List<string> agentes = new List<string>();

            if (usuario != null)
            {
                if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                {
                    agentes = new List<string>();
                    if (string.IsNullOrWhiteSpace(agentNameId))
                    {
                        var agentList = agentProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl);
                        agentes = agentList.Select(a => a.NameId).ToList();
                    }
                    else
                    {
                        agentes.Add(agentNameId);
                    }

                    quotations = from q in dataAccess.Quotations.Include("User")
                                 where agentes.Contains(q.User.Username)
                                 && q.User.UserType == UserType.Agent
                                 && q.Status == QuotationStatus.InProgress
                                 && q.Declined == false
                                 select q;
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent)
                {
                    agentes = new List<string>();
                    var agentList = agentProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl);

                    if (agentList.Count() == 1)
                    {
                        /*tengo las cotizaciones que yo tenga ya sea con mi username o nameid, esto es para que independientemente este registrado en pos
                          siempre traiga mis cotizaciones*/

                        List<string> myquots = new List<string>();
                        var currentNameid = agentList.FirstOrDefault().NameId;

                        myquots.Add(currentNameid);
                        myquots.Add(currentUserName);

                        quotations = from q in dataAccess.Quotations.Include("User")
                                     where myquots.Contains(q.User.Username)
                                     && q.Status == QuotationStatus.InProgress
                                     && q.Declined == false
                                     select q;

                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(agentNameId))
                        {
                            agentes = agentList.Select(a => a.NameId).ToList();
                        }
                        else
                            agentes.Add(agentNameId);
                        quotations = from q in dataAccess.Quotations.Include("User")
                                     //where (agentNameId == null ? q.User.Suscriptor.Username == currentUserName : q.User.Username == agentNameId)
                                     where agentes.Contains(q.User.Username)
                                     && q.User.UserType == UserType.Agent
                                     && q.Status == QuotationStatus.InProgress
                                     && q.Declined == false
                                     select q;
                    }
                }
                else
                {
                    quotations = from q in dataAccess.Quotations.Include("User")
                                 where q.User.Username == currentUserName
                                 && q.Status == QuotationStatus.InProgress
                                 && q.Declined == false
                                 select q;
                }
            }
            else
            {
                quotations = from q in dataAccess.Quotations.Include("User")
                             where currentUserName.StartsWith(q.PrincipalIdentificationNumber)
                             && q.Status == QuotationStatus.InProgress
                             && q.Declined == false
                             select q;
            }



            if (businessLine.HasValue)
            {
                quotations = from q in quotations
                             where q.BusinessLine.Id == businessLine.Value
                             select q;
            }

            if (quotationId.HasValue)
                quotations = quotations.Where(q => q.Id == quotationId);

            if (!string.IsNullOrEmpty(principalName))
                quotations = quotations.Where(q => q.PrincipalFullName.Contains(principalName));

            if (!string.IsNullOrEmpty(identification))
                quotations = quotations.Where(q => q.PrincipalIdentificationNumber.Contains(identification));

            if (!string.IsNullOrEmpty(quotationDate))
            {
                var date = DateTime.Parse(quotationDate);
                quotations = quotations.Where(q => DbFunctions.TruncateTime(q.Created) == date);
            }

            if (!string.IsNullOrEmpty(plan))
                quotations = quotations.Where(q => q.QuotationProduct == plan);

            if (currency.HasValue)
                quotations = quotations.Where(q => q.Currency.Id == currency.Value);

            if (!string.IsNullOrEmpty(primeOperatorSelected) && annualPrime.HasValue)
            {
                if (primeOperatorSelected == "=")
                    quotations = quotations.Where(q => q.TotalPrime == annualPrime);
                else if (primeOperatorSelected == "<")
                    quotations = quotations.Where(q => q.TotalPrime < annualPrime);
                else if (primeOperatorSelected == ">")
                    quotations = quotations.Where(q => q.TotalPrime > annualPrime);
            }

            if (!string.IsNullOrEmpty(taxesOperatorSelected) && taxes.HasValue)
            {
                if (taxesOperatorSelected == "=")
                    quotations = quotations.Where(q => q.TotalISC == taxes);
                else if (taxesOperatorSelected == "<")
                    quotations = quotations.Where(q => q.TotalISC < taxes);
                else if (taxesOperatorSelected == ">")
                    quotations = quotations.Where(q => q.TotalISC > taxes);
            }

            if (!string.IsNullOrEmpty(totalOperatorSelected) && total.HasValue)
            {
                if (totalOperatorSelected == "=")
                    quotations = quotations.Where(q => (q.TotalPrime + q.TotalISC - q.TotalDiscount) == total);
                else if (totalOperatorSelected == "<")
                    quotations = quotations.Where(q => (q.TotalPrime + q.TotalISC - q.TotalDiscount) < total);
                else if (totalOperatorSelected == ">")
                    quotations = quotations.Where(q => (q.TotalPrime + q.TotalISC - q.TotalDiscount) > total);
            }

            if (!string.IsNullOrEmpty(AgentQuotationNameID))
            {
                List<string> agList = new List<string>();
                agList.Add(AgentQuotationNameID);

                quotations = quotations.Where(q => agList.Contains(q.User.Username)
                                     && q.User.UserType == UserType.Agent
                                     && q.Status == QuotationStatus.InProgress && q.Declined == false);
            }

            var totalRegisters = quotations.Count();

            var totalPages = 0;

            if (totalRegisters > 0)
            {
                totalPages = Convert.ToInt32(Math.Ceiling((double)(totalRegisters / pageSize)));

                if (totalPages < currentPage)
                    currentPage = totalPages - 1;
            }

            var quotationCount = quotations.OrderByDescending(q => q.Id).Skip(currentPage * pageSize).Take(pageSize).ToList();

            var registers = quotationCount.Select(q => new QuotationSearchRegisterModel()
            {
                AnnualPrime = q.TotalPrime.GetValueOrDefault().ToString("n2"),
                BusinessLine = q.GetType() == typeof(QuotationAuto) ? "Auto" : "Salud",
                Currency = q.CurrencySymbol,
                PrincipalIdentificationNumber = q.PrincipalIdentificationNumber,
                //Id = q.Id,//Original 181082017
                Id = STL.POS.Data.CSEntities.Helperes.Encode(q.Id.ToString()),
                Plan = q.QuotationProduct,
                PrincipalName = q.PrincipalFullName,
                QuotationDate = q.Created.ToString("dd MMM yyyy"),
                QuotationNumber = q.QuotationNumber,
                Taxes = q.TotalISC.GetValueOrDefault().ToString("n2"),
                Total = (q.TotalISC + q.TotalPrime - q.TotalDiscount).GetValueOrDefault().ToString("n2"),
                FullName = getAgentNameByNameID(q.User != null ? q.User.Username : "")
            });

            return Json(new { totalRegisters = totalRegisters, currentPage = currentPage, registers = registers }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetFilterLists(string currentUserName)
        {
            List<AgentTreeInfoNew> agentList = new List<AgentTreeInfoNew>();

            var usuario = GetCurrentUsuario();

            if (usuario != null && usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
            {
                agentList = agentProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl);
            }
            else if (usuario != null && usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent)
            {
                agentList = agentProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl);

                /*Como el objeto se llena con el que viene si tenga o no cadena, no hay que hacer esta codicion*/
                if (agentList.Count() == 1)
                {
                    agentList = new List<AgentTreeInfoNew>();
                    //agentList.Add(new Agent.AgentTreeInfo() { FullNameAll = usuario.FirstName + " " + usuario.LastName + " (" + usuario.AgentCode + " )", NameId = usuario.UserLogin, AgentId = usuario.AgentId });
                    agentList.Add(new AgentTreeInfoNew() { FullNameAll = usuario.FirstName + " " + usuario.LastName + " (" + usuario.AgentCode + " )", NameId = usuario.AgentNameId, AgentId = usuario.AgentId });
                }
            }

            var agents = agentList.OrderBy(o => o.FullNameAll).ToList();

            var currencyList = (from c in dataAccess.Currencies
                                orderby c.Symbol
                                select new { id = c.Id, symbol = c.Symbol }).ToArray();

            //ORIGINAL 18-10-2016 JHEIRON DOTEL
            //var quotations = (from q in dataAccess.Quotations
            //                  where q.User.Username == currentUserName
            //                  && q.Status == QuotationStatus.InProgress
            //                  select q);

            var quotations = (from q in dataAccess.Quotations
                              where q.Status == QuotationStatus.InProgress
                              && q.Declined == false
                              select q).Take(1);


            if (agentList.Count() == 1)
            {
                /*tengo las cotizaciones que yo tenga ya sea con mi username o nameid, esto es para que independientemente este registrado en pos
                 siempre traiga mis cotizaciones*/

                List<string> myquots = new List<string>();
                var currentNameid = agentList.FirstOrDefault().NameId;

                myquots.Add(currentNameid);
                myquots.Add(currentUserName);

                quotations = (from q in dataAccess.Quotations
                              where myquots.Contains(q.User.Username)
                                && q.Status == QuotationStatus.InProgress
                                && q.Declined == false
                              select q);
            }
            else if (agentList.Count() > 1)
            {
                var agentes = agentList.Select(a => a.NameId).ToList();

                quotations = (from q in dataAccess.Quotations
                              where agentes.Contains(q.User.Username)
                                && q.Status == QuotationStatus.InProgress
                                && q.Declined == false
                              select q);
            }


            var qNumbers = (from q in quotations
                            orderby q.Id descending
                            select new { id = q.Id, quotationNumber = q.QuotationNumber }).ToArray();

            var ids = (from q in quotations
                       orderby q.PrincipalIdentificationNumber
                       select q.PrincipalIdentificationNumber).Distinct().ToList();

            var principals = (from q in quotations
                              orderby q.PrincipalFullName
                              select q.PrincipalFullName).Distinct().ToArray();

            var dates = (from q in quotations
                         orderby q.Created
                         select DbFunctions.TruncateTime(q.Created)).Distinct().ToList().Select(q => q.Value.ToString("dd MMM yyyy")).ToArray();

            var businessLines = (from b in dataAccess.BusinessLines
                                 orderby b.Name
                                 select new { id = b.Id, name = b.Name }).ToArray();

            var plans = (from q in quotations
                         where q.QuotationProduct != string.Empty
                         orderby q.QuotationProduct
                         select q.QuotationProduct
                         ).Distinct().ToArray();

            List<QuotationListAgent> AgentQuotationList = new List<QuotationListAgent>();

            var LAgentQuotationList = (from q in quotations
                                       orderby q.Created
                                       select q.User.Username).Distinct().ToArray();

            foreach (var a in LAgentQuotationList)
            {
                var r = agentList.FirstOrDefault(x => x.NameId.Contains(a));
                if (r != null)
                {
                    AgentQuotationList.Add(new QuotationListAgent() { NameID = r.NameId, FullName = r.FullNameAll });
                }
            }
            var realAgentQuotationList = AgentQuotationList.ToArray();


            return Json(new
            {
                agentList = agents,
                quotationList = qNumbers,
                principalNameList = principals,
                quotationDateList = dates,
                currencyList = currencyList,
                businessLineList = businessLines,
                planList = plans,
                identificationList = ids,
                AgentQuotationList = realAgentQuotationList
            }, JsonRequestBehavior.AllowGet);


        }

        private string getAgentNameByNameID(string nameID)
        {
            var agentinfo = getAgenteUserInfo(nameID);
            if (agentinfo != null)
            {
                return agentinfo.FullName + " (" + agentinfo.AgentCode + ")";
            }
            return "";
        }

        public ActionResult GetServerDate()
        {
            var date = DateTime.Now;
            var dateUtc = DateTime.UtcNow;
            return Json(new { currentDate = date, currentDateUTC = dateUtc }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMonths()
        {
            var months = new Dictionary<int, string>();

            for (int i = 1; i < 13; i++)
            {
                months.Add(i, new DateTime(1, i, 1).ToString("MMM"));
            }

            return Json(months.Select(d => new { Id = d.Key, Name = d.Value }).ToArray(), JsonRequestBehavior.AllowGet);

        }

        [AjaxHandleError]
        public ActionResult SetDeclinedQuotations(string quotationID)
        {
            bool sucess = false;
            try
            {
                if (!string.IsNullOrEmpty(quotationID))
                {
                    var sp = quotationID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var q in sp)
                    {
                        int qq = 0;

                        int.TryParse(q, out qq);
                        var quot = dataAccess.Quotations.FirstOrDefault(x => x.Id == qq);
                        if (quot != null)
                        {
                            quot.Declined = true;
                            dataAccess.SaveChanges();

                            sucess = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sucess = false;
            }
            return Json(new { message = "Proceso Completado", sucess = sucess }, JsonRequestBehavior.AllowGet);
        }


        private void DeclinedQuotationsByTime()
        {
            DateTime startDate = DateTime.Now;
            List<int> idToDelete = new List<int>();

            var quot = dataAccess.Quotations.Where(x => x.Status == QuotationStatus.InProgress
                && x.Declined == false
                && DbFunctions.DiffDays(x.Created, startDate).Value > 30
                );//.ToList();
            if (quot.Any())
            {
                foreach (var q in quot)
                {
                    DateTime Created = q.Created;
                    TimeSpan substract = startDate - Created;

                    double days = substract.TotalDays;

                    //if (expiryDate.Date >= startDate.Date)
                    if (days > 30)
                    {
                        idToDelete.Add(q.Id);
                    }
                    else
                    {


                    }
                }

                foreach (var item in idToDelete)
                {
                    var a = dataAccess.Quotations.FirstOrDefault(x => x.Id == item);
                    if (a != null)
                    {
                        a.Declined = true;
                        //dataAccess.SaveChanges();
                    }
                }

            }
        }


        public ActionResult ReviseQuotation()
        {
            List<STL.POS.Data.CSEntities.GetErrorQuotationResult> l = new List<Data.CSEntities.GetErrorQuotationResult>();
            return View(l);
        }

        [HttpPostAttribute]
        public ActionResult ReviseQuotation(FormCollection form)
        {
            if (!string.IsNullOrEmpty(form["quotNumber"]))
            {
                List<Data.CSEntities.GetErrorQuotationResult> l = dataAccess.GetErrorQuotation(form["quotNumber"].ToString());
                return View(l);
            }

            return View(new List<Data.CSEntities.GetErrorQuotationResult>());
        }




        class QuotationListAgent
        {
            public string NameID { get; set; }
            public string FullName { get; set; }
        }

    }
}