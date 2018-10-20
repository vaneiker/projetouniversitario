using STL.POS.AgentWSProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STL.POS.Frontend.Web.NewVersion.CustomCode;
using Entity.Entities;
using Newtonsoft.Json;
using System.Globalization;

namespace STL.POS.Frontend.Web.NewVersion.Controllers
{

    public class QuotationSearchController : BaseController
    {
        private int bl = Helperes.BUSINESSLINE_ID_AUTO == 1 ? 2 : Helperes.BUSINESSLINE_ID_AUTO;

        #region QuotationSearch
        public ActionResult QuotationSearch(string pQuotationNumber = "", string pIdentification = "", DateTime? pDateOfBirth = null)
        {
            pIdentification = pIdentification.Replace("-", string.Empty);
            ViewBag.TitlePage = "HISTORICO DE COTIZACIONES";

            IEnumerable<Entity.Entities.Quotation> result = null;
            List<string> agentes = new List<string>();
            List<string> strList = new List<string>();
            var user = GetCurrentUsuario();
            try
            {

                var onlyLoggedUsers = allowOnlyLoggedUsers();

                if (user == null && onlyLoggedUsers)
                {
                    var urlLogin = System.Web.Configuration.WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture);

                    Session.RemoveAll();

                    return Redirect(urlLogin);
                }


                if (!onlyLoggedUsers) //valido si la persona logueada es un cliente y no un usuario
                {
                    Session["ShowOrNotMenu"] = false;
                    if (!string.IsNullOrEmpty(pQuotationNumber))
                        result = oQuotationManager.GetQuotations(null, string.Empty, pQuotationNumber, string.Empty, string.Empty, string.Empty, false);
                    else
                    {
                        result = oQuotationManager.GetQuotations(null, string.Empty, string.Empty, string.Empty, pIdentification, string.Empty, false);
                        result = result.Where(x => x.DateOfBirth == pDateOfBirth.GetValueOrDefault()).ToList();
                    }
                }
                else
                {
                    Session["ShowOrNotMenu"] = true;
                    if (user != null)
                    {
                        ViewBag.CurrentUserName = user.UserLogin;
                        #region filtros por usuaro


                        if (user.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                        {
                            agentes = new List<string>();
                            var agentList = oAgentWSProxy.GetAgentTreeNewInfoCallNew(user.AgentOffices.FirstOrDefault().CorpId, user.AgentId, user.AgentNameId, bl);
                            agentes = agentList.Select(a => a.NameId).ToList();

                            result = oQuotationManager.GetQuotations(Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent.ToInt(), string.Empty).ToList();
                            result = result.Where(x => agentes.Contains(x.UserName)).ToList();
                        }
                        else if (user.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent)
                        {
                            agentes = new List<string>();
                            var agentList = oAgentWSProxy.GetAgentTreeNewInfoCallNew(user.AgentOffices.FirstOrDefault().CorpId, user.AgentId, user.AgentNameId, bl);

                            if (agentList.Count() == 1)
                            {
                                /*tengo las cotizaciones que yo tenga ya sea con mi username o nameid, esto es para que independientemente este registrado en pos
                                  siempre traiga mis cotizaciones*/

                                List<string> myquots = new List<string>();
                                var currentNameid = agentList.FirstOrDefault().NameId;



                                myquots.Add(currentNameid);
                                myquots.Add(user.UserLogin);
                                result = oQuotationManager.GetQuotations(Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent.ToInt(), string.Empty).ToList();
                                result = result.Where(x => myquots.Contains(x.UserName)).ToList();
                            }
                            else
                            {
                                agentes = agentList.Select(a => a.NameId).ToList();

                                result = oQuotationManager.GetQuotations(Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent.ToInt(), string.Empty).ToList();
                                result = result.Where(x => agentes.Contains(x.UserName)).ToList();
                            }
                        }
                        else
                        {
                            result = oQuotationManager.GetQuotations(Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent.ToInt(), user.UserLogin).ToList();
                        }

                        #endregion
                    }
                    else
                    {
                        result = oQuotationManager.GetQuotations(0, string.Empty).ToList();
                        result = result.Where(x => pIdentification.StartsWith(x.PrincipalIdentificationNumber)).ToList();
                    }
                }


                var products = result.Select(x => new
                {
                    name = x.QuotationProduct.Trim()
                }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

                var quotations = result.Select(x => new
                {
                    name = x.QuotationNumber.Trim()
                }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

                var principals = result.Where(u => !string.IsNullOrEmpty(u.PrincipalFullName)).Select(x => new
                {
                    name = x.PrincipalFullName.Trim()
                }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

                var identifications = result.Where(u => !string.IsNullOrEmpty(u.PrincipalIdentificationNumber)).Select(x => new
                {
                    name = string.IsNullOrEmpty(x.PrincipalIdentificationNumber.Trim()) ? "" : x.PrincipalIdentificationNumber.Trim()
                }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

                var businesLines = result.Select(x => new
                {
                    name = x.BusinessLineDesc.Trim()
                }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();
                var currencies = result.Select(x => new
                {
                    name = x.CurrencySymbol.Trim()
                }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

                ViewBag.QuotationListID = new SelectList(quotations.ToList().Select(i => new SelectListItem { Text = i.name.ToString(), Value = i.name.ToString() }), "Value", "Text");
                ViewBag.principalNameList = new SelectList(principals.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");
                ViewBag.identificationList = new SelectList(identifications.ToList().Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");
                ViewBag.businessLineList = new SelectList(businesLines.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");
                ViewBag.planList = new SelectList(products.Select(i => new SelectListItem { Text = i.name, Value = i.name }).Distinct(), "Value", "Text");
                ViewBag.currencyList = new SelectList(currencies.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");

                var param = oDropDownManager.GetDropDown(CommonEnums.DropDownType.OPERATORS.ToString()).ToList();
                ViewBag.operatorList = new SelectList(param.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");

                var totalprimes = result.Select(x => new
                {
                    name = x.TotalPrime
                }).Where(q => q.name > 0).Distinct();

                ViewBag.annualPrimeList = new SelectList(totalprimes.Select(i => new SelectListItem { Text = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture), Value = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture) }), "Value", "Text");

                var impuestos = result.Select(x => new
                {
                    name = x.TotalISC
                }).Where(q => q.name > 0).Distinct();

                ViewBag.taxesList = new SelectList(impuestos.Select(i => new SelectListItem { Text = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture), Value = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture) }), "Value", "Text");

                //sumo el campo prima total y el impuesto para llenar el dropdownlist de filtrar por total de prima
                var TotalPrimeList = result.Select(x => new
                {
                    name = x.Total
                }).Where(q => q.name > 0).Distinct();

                ViewBag.totalList = new SelectList(TotalPrimeList.Select(i => new SelectListItem { Text = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture), Value = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture) }), "Value", "Text");

                var dates = result.Select(x => new
                {
                    name = x.Created.ToString("dd-MMM-yyyy").ToLower()
                }).Distinct();

                ViewBag.quotationDateList = new SelectList(dates.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");

                var requestTypes = result.Select(x => new
                {
                    name = x.RequestTypeDesc
                }).Distinct();

                ViewBag.requestTypeList = new SelectList(requestTypes.ToList().Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, "POS-" + (user != null ? user.UserLogin : ""), QuotationId, "Error al cargar el historico de cotizaciones", "Mensaje: " + ex.Message, ex);
            }
            return PartialView(result);
            //return View(result);
        }

        public ActionResult DeclineQuotation(string quotations)
        {
            bool result = false;
            int Errors = 0;
            try
            {

                if (string.IsNullOrEmpty(quotations))
                {
                    return Json(new { result }, JsonRequestBehavior.AllowGet);
                };

                var parameters = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Entity.Entities.Quotation>>(quotations);
                foreach (var item in parameters)
                {
                    var parameter = new Quotation.parameter
                    {
                        id = item.Id,
                        declined = item.Declined,
                        modi_UserId = GetCurrentUserID(),
                        RiskLevel = !string.IsNullOrEmpty(base.RiskLevel)? base.RiskLevel: null
                    };
                    try
                    {
                        var OperationResult = oQuotationManager.SetQuotation(parameter);
                    }
                    catch (Exception)
                    {
                        Errors += 1;
                    }

                }
                result = (Errors > 0);


            }
            catch (Exception ex)
            {
                var user = GetCurrentUsuario();
                LoggerHelper.Log(CommonEnums.Categories.Error, "POS-" + (user != null ? user.UserLogin : ""), QuotationId, "Error declinando la cotización", "Mensaje: " + ex.Message, ex);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("QuotationSearch", "Home");
        }

        public ActionResult QuotationSearch2(
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
            IEnumerable<Entity.Entities.Quotation> result = null;
            List<string> agentes = new List<string>();
            var user = GetCurrentUsuario();

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

            if (user != null)
            {
                #region filtros por usuaro


                if (user.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                {
                    agentes = new List<string>();
                    if (string.IsNullOrWhiteSpace(agentNameId))
                    {
                        var agentList = oAgentWSProxy.GetAgentTreeNewInfoCallNew(user.AgentOffices.FirstOrDefault().CorpId, user.AgentId, user.AgentNameId, bl);
                        agentes = agentList.Select(a => a.NameId).ToList();
                    }
                    else
                    {
                        agentes.Add(agentNameId);
                    }

                    result = oQuotationManager.GetQuotations(Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent.ToInt(), string.Empty).ToList();
                    result = result.Where(x => agentes.Contains(x.UserName)).ToList();
                }
                else if (user.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent)
                {
                    agentes = new List<string>();
                    var agentList = oAgentWSProxy.GetAgentTreeNewInfoCallNew(user.AgentOffices.FirstOrDefault().CorpId, user.AgentId, user.AgentNameId, bl);

                    if (agentList.Count() == 1)
                    {
                        /*tengo las cotizaciones que yo tenga ya sea con mi username o nameid, esto es para que independientemente este registrado en pos
                          siempre traiga mis cotizaciones*/

                        List<string> myquots = new List<string>();
                        var currentNameid = agentList.FirstOrDefault().NameId;



                        myquots.Add(currentNameid);
                        myquots.Add(user.UserLogin);
                        result = oQuotationManager.GetQuotations(Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent.ToInt(), string.Empty).ToList();
                        result = result.Where(x => myquots.Contains(x.UserName)).ToList();
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(agentNameId))
                        {
                            agentes = agentList.Select(a => a.NameId).ToList();
                        }
                        else
                            agentes.Add(agentNameId);
                        result = oQuotationManager.GetQuotations(Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent.ToInt(), string.Empty).ToList();
                        result = result.Where(x => agentes.Contains(x.UserName)).ToList();
                    }
                }
                else
                {
                    result = oQuotationManager.GetQuotations(Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent.ToInt(), user.UserLogin).ToList();
                }

                #endregion
            }
            else
            {
                result = oQuotationManager.GetQuotations(0, string.Empty).ToList();
                result = result.Where(x => identification.StartsWith(x.PrincipalIdentificationNumber)).ToList();
            }

            #region aplicando filtros adicionales

            if (!string.IsNullOrEmpty(primeOperatorSelected) && annualPrime.HasValue)
            {
                if (primeOperatorSelected == "=")
                    result = result.Where(q => q.TotalPrime == annualPrime);
                else if (primeOperatorSelected == "<")
                    result = result.Where(q => q.TotalPrime < annualPrime);
                else if (primeOperatorSelected == ">")
                    result = result.Where(q => q.TotalPrime > annualPrime);
            }

            if (!string.IsNullOrEmpty(taxesOperatorSelected) && taxes.HasValue)
            {
                if (taxesOperatorSelected == "=")
                    result = result.Where(q => q.TotalISC == taxes);
                else if (taxesOperatorSelected == "<")
                    result = result.Where(q => q.TotalISC < taxes);
                else if (taxesOperatorSelected == ">")
                    result = result.Where(q => q.TotalISC > taxes);
            }

            if (!string.IsNullOrEmpty(totalOperatorSelected) && total.HasValue)
            {
                if (totalOperatorSelected == "=")
                    result = result.Where(q => (q.Total - q.TotalDiscount) == total);
                else if (totalOperatorSelected == "<")
                    result = result.Where(q => (q.Total - q.TotalDiscount) < total);
                else if (totalOperatorSelected == ">")
                    result = result.Where(q => (q.Total - q.TotalDiscount) > total);
            }

            #endregion

            var products = result.Select(x => new
            {
                name = x.QuotationProduct.Trim()
            }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

            var quotations = result.Select(x => new
            {
                name = x.QuotationNumber.Trim()
            }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

            var principals = result.Where(u => !string.IsNullOrEmpty(u.PrincipalFullName)).Select(x => new
            {
                name = x.PrincipalFullName.Trim()
            }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

            var identifications = result.Where(u => !string.IsNullOrEmpty(u.PrincipalIdentificationNumber)).Select(x => new
            {
                name = string.IsNullOrEmpty(x.PrincipalIdentificationNumber.Trim()) ? "" : x.PrincipalIdentificationNumber.Trim()
            }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

            var businesLines = result.Select(x => new
            {
                name = x.BusinessLineDesc.Trim()
            }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();
            var currencies = result.Select(x => new
            {
                name = x.CurrencySymbol.Trim()
            }).Where(q => !string.IsNullOrEmpty(q.name.Trim())).Distinct();

            ViewBag.QuotationListID = new SelectList(quotations.ToList().Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text"); ;
            ViewBag.principalNameList = new SelectList(principals.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");
            ViewBag.identificationList = new SelectList(identifications.ToList().Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");
            ViewBag.businessLineList = new SelectList(businesLines.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");
            ViewBag.planList = new SelectList(products.Select(i => new SelectListItem { Text = i.name, Value = i.name }).Distinct(), "Value", "Text");
            ViewBag.currencyList = new SelectList(currencies.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");

            var param = oDropDownManager.GetDropDown(CommonEnums.DropDownType.OPERATORS.ToString()).ToList();
            ViewBag.operatorList = new SelectList(param.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");

            var totalprimes = result.Select(x => new
            {
                name = x.TotalPrime
            }).Where(q => q.name > 0).Distinct();

            ViewBag.annualPrimeList = new SelectList(totalprimes.Select(i => new SelectListItem { Text = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture), Value = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture) }), "Value", "Text");

            var impuestos = result.Select(x => new
            {
                name = x.TotalISC
            }).Where(q => q.name > 0).Distinct();

            ViewBag.taxesList = new SelectList(impuestos.Select(i => new SelectListItem { Text = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture), Value = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture) }), "Value", "Text");

            //sumo el campo prima total y el impuesto para llenar el dropdownlist de filtrar por total de prima
            var TotalPrimeList = result.Select(x => new
            {
                name = x.Total
            }).Where(q => q.name > 0).Distinct();

            ViewBag.totalList = new SelectList(TotalPrimeList.Select(i => new SelectListItem { Text = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture), Value = i.name.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture) }), "Value", "Text");

            var dates = result.Select(x => new
            {
                name = x.Created.ToString("dd-MMM-yyyy").ToLower()
            }).Distinct();

            ViewBag.quotationDateList = new SelectList(dates.Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");

            var requestTypes = result.Select(x => new
            {
                name = x.RequestTypeDesc
            }).Distinct();

            ViewBag.requestTypeList = new SelectList(requestTypes.ToList().Select(i => new SelectListItem { Text = i.name, Value = i.name }), "Value", "Text");
            //ViewBag.CurrentUserName = currentUserName;
            ViewBag.CurrentUserName = user.UserLogin;
            return PartialView("QuotationSearch", result);
        }

        public ActionResult SetVariable(string value)
        {
            base.QuotationId = value.ToInt();
            base.CoreQuotationNumber = getQuotationData(QuotationId).QuotationCoreNumber;
            return this.Json(new { success = true, quotationEncripted = Utility.Encode(value.ToString()) });
        }

        public ActionResult RedirectQuotation(string quotationNumber)
        {
            Entity.Entities.Generic result = new Entity.Entities.Generic();

            try
            {
                var quotation = oQuotationManager.GetQuotation(null, quotationNumber);
                if (quotation != null)
                {
                    QuotationId = quotation.Id.GetValueOrDefault();
                    result.name = "success";
                    result.Value = Utility.Encode(QuotationId.ToString());
                }
                else
                {
                    result.name = "Error";
                    result.Value = "El número de cotización digitado es incorrecto o ya fue fue completado previamente";
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                result.name = "Error";
                result.Value = ex.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}