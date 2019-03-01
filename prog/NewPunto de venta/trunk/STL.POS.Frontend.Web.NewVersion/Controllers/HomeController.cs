﻿using STL.POS.AgentWSProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STL.POS.Frontend.Web.NewVersion.CustomCode;
using Entity.Entities;
using Newtonsoft.Json;
using System.Globalization;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Xml;


namespace STL.POS.Frontend.Web.NewVersion.Controllers
{
    public partial class HomeController : BaseController
    {
        #region Combo's Fill Calls

        public JsonResult GetMonths()
        {
            var months = new Dictionary<int, string>();

            for (int i = 1; i < 13; i++)
            {
                months.Add(i, new DateTime(1, i, 1).ToString("MMM"));
            }

            return Json(months.Select(d => new { Id = d.Key, Name = d.Value }).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgents()
        {
            var usuario = GetCurrentUsuario();
            List<Entity.Entities.WSEntities.AgentTreeInfoNewWS> agentList = new List<Entity.Entities.WSEntities.AgentTreeInfoNewWS>();
            if (usuario != null)
            {
                int bl = 2;

                if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                {
                    var a = oAgentWSProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl);
                    foreach (var r in a)
                    {
                        string json = JsonConvert.SerializeObject(r);
                        agentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS()
                        {
                            AgentCode = r.AgentCode,
                            CorpId = r.CorpId,
                            FullName = r.FullName,
                            FullNameAll = r.FullNameAll,
                            NameId = r.NameId,
                            jsonAgentTree = json
                        });
                    }
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent)
                {
                    var a = oAgentWSProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl);
                    foreach (var r in a)
                    {
                        string json = JsonConvert.SerializeObject(r);

                        agentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS()
                        {
                            AgentCode = r.AgentCode,
                            CorpId = r.CorpId,
                            FullName = r.FullName,
                            FullNameAll = r.FullNameAll,
                            NameId = r.NameId,
                            jsonAgentTree = json
                        });
                    }

                    if (agentList.Count() == 0)
                    {
                        agentList = new List<Entity.Entities.WSEntities.AgentTreeInfoNewWS>();
                        string userNameID = !string.IsNullOrEmpty(usuario.AgentNameId) ? usuario.AgentNameId : usuario.UserLogin;

                        agentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS()
                        {
                            AgentCode = usuario.AgentCode,
                            CorpId = usuario.CorpId,
                            FullName = usuario.FirstName + " " + usuario.LastName,
                            FullNameAll = usuario.FirstName + " " + usuario.LastName + (!string.IsNullOrEmpty(usuario.AgentCode) ? "(" + usuario.AgentCode + ")" : ""),
                            NameId = userNameID,
                            jsonAgentTree = ""
                        });

                        var newagentList = new List<Entity.Entities.WSEntities.AgentTreeInfoNewWS>();

                        foreach (var r in agentList)
                        {
                            string json = JsonConvert.SerializeObject(r);

                            newagentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS()
                            {
                                AgentCode = usuario.AgentCode,
                                CorpId = usuario.CorpId,
                                FullName = usuario.FirstName + " " + usuario.LastName,
                                FullNameAll = usuario.FirstName + " " + usuario.LastName + (!string.IsNullOrEmpty(usuario.AgentCode) ? "(" + usuario.AgentCode + ")" : ""),
                                NameId = userNameID,
                                jsonAgentTree = json
                            });
                        }
                        agentList = newagentList;
                    }
                    else if (agentList.Count() == 1)
                    {
                        agentList = new List<Entity.Entities.WSEntities.AgentTreeInfoNewWS>();
                        string userNameID = !string.IsNullOrEmpty(usuario.AgentNameId) ? usuario.AgentNameId : usuario.UserLogin;

                        //agentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS() { FullNameAll = usuario.FirstName + " " + usuario.LastName + "(" + usuario.AgentCode + ")", NameId = userNameID, AgentId = usuario.AgentId });

                        foreach (var r in a)
                        {
                            string json = JsonConvert.SerializeObject(r);

                            agentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS()
                            {
                                AgentCode = usuario.AgentCode,
                                CorpId = usuario.CorpId,
                                FullName = usuario.FirstName + " " + usuario.LastName,
                                FullNameAll = usuario.FirstName + " " + usuario.LastName + (!string.IsNullOrEmpty(usuario.AgentCode) ? "(" + usuario.AgentCode + ")" : ""),
                                NameId = userNameID,
                                jsonAgentTree = json
                            });
                        }
                    }
                }
            }

            agentList = agentList.OrderBy(o => o.FullNameAll).ToList();

            //var WEWE = oAgentWSProxy.TEST().Select(x=>new AgentWSProxy.AgentService.Agent.AssignedOffice()
            //{
            //    AgentId = x.AgentId,
            //    AgentCode = x.AgentCode,
            //    AgentNameID=x.AgentNameID,
            //    OfficeId=x.OfficeId,
            //    OfficeDesc = x.OfficeDesc,
            //    OfficeCode = x.OfficeCode,
            //});

            return Json(new { agents = agentList }, JsonRequestBehavior.AllowGet);
        }

        private SelectList GetVehicleAvailableYearsList(int selectedValue = 0)
        {
            //1960 to now
            string minYear = oDropDownManager.GetParameter("PARAMETER_KEY_MIN_YEAR_VEHICLE").Value;
            var year = !string.IsNullOrEmpty(minYear) ? minYear.ToInt() : 1960;

            var list = new List<int>();
            for (int i = DateTime.Now.Year + 1; i >= year; i--)
            {
                list.Add(i);
            }

            return new SelectList(list.Select(i => new SelectListItem { Text = i.ToString(), Value = i.ToString() }), "Value", "Text", selectedValue);
        }

        private bool ExisteMarcaSysflex(List<STL.POS.WsProxy.SysflexService.PolicySysflexMarcaVehiculo> ListaSysflex, string descripcion)
        {
            var existe = false;

            foreach (var m in ListaSysflex)
            {
                if (m.Descripcion.ToUpper() == descripcion.ToUpper())
                {
                    existe = true;
                    break;
                }
            }

            return existe;
        }

        private SelectList getVehiclesBrands(int selectedValue = 0)
        {
            /*List<STL.POS.WsProxy.SysflexService.PolicySysflexMarcaVehiculo> ListaMarcasSysflex = new List<STL.POS.WsProxy.SysflexService.PolicySysflexMarcaVehiculo>();

            ListaMarcasSysflex = oCoreProxy.GetVehicleMakes();*/

            List<MakePos> ListaMarcasPost = new List<MakePos>();

            var Brands = oDropDownManager.GetDropDown(CommonEnums.DropDownType.BRANDS.ToString());

            foreach (var m in Brands)
            {
                ListaMarcasPost.Add(new MakePos() { id = m.Value.ToInt(), name = m.name });

                /*
                if (!string.IsNullOrEmpty(m.name) && !string.IsNullOrWhiteSpace(m.name))
                {
                    string newName = m.name.Trim();
                    if (ExisteMarcaSysflex(ListaMarcasSysflex, newName) == true)
                    {
                        ListaMarcasPost.Add(new MakePos() { id = m.Value.ToInt(), name = newName });
                    }
                }
                */
            }

            return new SelectList(ListaMarcasPost.OrderBy(x => x.name).Select(i => new SelectListItem { Text = i.name, Value = i.id.ToString() }), "Value", "Text", selectedValue);
        }

        public JsonResult getVehiclesModelsByBrands(int BrandID)
        {
            var Models = oDropDownManager.GetVehicleModels(BrandID);

            return Json(Models.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsageStates()
        {
            var output = oDropDownManager.GetUsageStates().Select(u => new
            {
                id = u.Id,
                name = u.Name,
                allowed = u.Allowed,
                message = u.UsageMessage
            });

            return Json(output.OrderBy(x => x.allowed).ThenBy(n => n.name), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQtyYearsBack0KmVip()
        {
            var Param = oDropDownManager.GetParameter("PARAMETER_KEY_QTY_YEARS_BACK_OKM_VIP").Value;
            return Json(Param, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStoreStates()
        {
            var param = oDropDownManager.GetParameter("PARAMETER_KEY_STORED_VALUES").Value;

            Dictionary<int, string> values = JsonConvert.DeserializeObject<Dictionary<int, string>>(param);

            var output = from pair in values
                         select new { id = pair.Key, name = pair.Value };

            return Json(output, JsonRequestBehavior.AllowGet);
        }

        private int GetModelCoreId(int makeId, int modelId)
        {
            int coreId = -1;

            var models = oDropDownManager.GetVehicleModels(makeId);
            if (models != null)
            {
                var realmodel = models.FirstOrDefault(x => x.Id == modelId);
                if (realmodel != null)
                {
                    coreId = realmodel.CoreId.ToInt();
                }
            }

            return
                coreId;
        }

        public JsonResult GetSurchargePercentage()
        {
            var u = GetCurrentUsuario();
            if (u != null)
            {
                if (u.CanApplySurcharge)
                {
                    var sur = oDropDownManager.GetDropDown(CommonEnums.DropDownType.SURCHARGEPERCENTAGE.ToString());

                    var output = from v in sur
                                 select new { id = v.Value, name = v.name };

                    return Json(output.ToArray(), JsonRequestBehavior.AllowGet);
                }
            }
            List<string> lempty = new List<string>();
            return Json(lempty.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrentIsc()
        {
            var param = oDropDownManager.GetParameter("PARAMETER_KEY_PERCENTAGE_ISC").Value;
            return Json(new { isc = param }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPercentByQtyVehicle(int qtyVehicles)
        {
            if (qtyVehicles > 0)
            {
                var jsonParam = oDropDownManager.GetParameter("PARAMETER_KEY_PERCENT_FLOTILLA_DISCOUNT").Value;
                decimal percentParam = 0;

                var json = JsonConvert.DeserializeObject<List<Utility.Percent_Flotilla_Discount>>(jsonParam);

                foreach (var qty in json)
                {
                    if (qtyVehicles >= qty.From && qtyVehicles <= qty.To)
                    {
                        percentParam = (qty.Porc * 100);

                        return Json(percentParam, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        private void sendEmailErrorInvoice(string message)
        {
            /*Enviando Eamil a Francisco*/
            var emailError = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_ERROR_GENERATE_INVOICE_SYSFLEX").Value;
            var senderError = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_SENDER").Value;

            var subject = "Error Generando la Factura en Sysflex";
            var body = message;

            List<string> destinatariosListError = new List<string>();

            foreach (var e in emailError.Split(','))
            {
                destinatariosListError.Add(e);
            }

            SendEmailHelper.SendMail(senderError, destinatariosListError, subject, body, null);
            /**/
        }

        private SelectList getCountries(int countryID)
        {
            var c = oDropDownManager.GetDropDown(STL.POS.Frontend.Web.NewVersion.CustomCode.CommonEnums.DropDownType.COUNTRY.ToString());  //getCountyBL(countryID);
            return new SelectList(c.Select(i => new SelectListItem { Text = i.name, Value = i.Value.ToString() }), "Value", "Text", countryID);
        }

        public JsonResult getCountyBL(int countryID)
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

            var countries = oDropDownManager.GetDropDown(STL.POS.Frontend.Web.NewVersion.CustomCode.CommonEnums.DropDownType.COUNTRY.ToString());

            IEnumerable<Generic> allCountrys = null;

            if (countryID > 0)
            {
                string cid = countryID.ToString();

                currentCountry = countryID;

                allCountrys = countries.Where(x => x.Value == cid).ToList();
            }
            else
            {
                currentCountry = 129; //Por default RD
                allCountrys = countries.ToList();
            }
            List<Utility.blByCountry> blBycountry = new List<Utility.blByCountry>();

            foreach (var c in allCountrys)
            {
                var blByCountry = oDropDownManager.GetCountryBusinessLines(c.Value.ToInt());
                var bls = new List<Utility.BussinesLines>();
                List<int> countrySaveds = new List<int>();

                foreach (var bl in blByCountry)
                {
                    if (IsPVLifeRole && bl.bl_name.Contains("Vida"))
                    {
                        bls.Add(new Utility.BussinesLines()
                        {
                            blID = bl.Id,
                            blName = bl.bl_name
                        });
                    }

                    if (IsPVAutoRole && bl.bl_name.Contains("Auto"))
                    {
                        bls.Add(new Utility.BussinesLines()
                        {
                            blID = bl.Id,
                            blName = bl.bl_name
                        });
                    }

                    if (IsPVGeneralesRole && bl.bl_name.Contains("Lineas Comerciales"))
                    {
                        bls.Add(new Utility.BussinesLines()
                        {
                            blID = bl.Id,
                            blName = bl.bl_name
                        });
                    }

                    if (IsPVGeneralesRole && bl.bl_name.Contains("Vivienda"))
                    {
                        bls.Add(new Utility.BussinesLines()
                        {
                            blID = bl.Id,
                            blName = bl.bl_name
                        });
                    }

                    if (IsPVSaludRole && bl.bl_name.Contains("Salud"))
                    {
                        bls.Add(new Utility.BussinesLines()
                        {
                            blID = bl.Id,
                            blName = bl.bl_name
                        });
                    }

                    if (!countrySaveds.Contains(c.Value.ToInt()))
                    {
                        blBycountry.Add(new Utility.blByCountry()
                        {
                            countryID = c.Value.ToInt(),
                            countryName = c.name,
                            _BussinesLines = bls
                        });

                        countrySaveds.Add(c.Value.ToInt());
                    }
                }
            }

            return Json(blBycountry, JsonRequestBehavior.AllowGet);
        }

        public JsonResult redirectToApp(string blName)
        {
            var onlyLoggedUsers = allowOnlyLoggedUsers();
            if (onlyLoggedUsers)
            {
                var user = GetCurrentUsuario();

                /*Conectandome al Site de Salud*/
                if (blName.Contains("Salud") && user != null)
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
                        return Json(new { sucess = true, pathredirect = data.UrlPath, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string msjerrr = data.errormessage;
                        if (msjerrr == "This user does not have access to this page or App")
                        {
                            msjerrr = "Este usuario no tiene acceso a esta pagina o aplicacion";
                        }
                        return Json(new { sucess = false, pathredirect = "", message = msjerrr }, JsonRequestBehavior.AllowGet);
                    }
                }
                /**/

                /*Conectandome al Site de Propiedad - Lineas Comerciales*/
                else if (blName.Contains("Lineas Comerciales") && user != null)
                {
                    string PVLineasAliadasPath = oDropDownManager.GetParameter("PARAMETER_KEY_LINEAS_COMERCIALES_PATH").Value;
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

                        return Json(new { sucess = true, pathredirect = data.UrlPath, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string msjerrr = data.errormessage;
                        if (msjerrr == "This user does not have access to this page or App")
                        {
                            msjerrr = "Este usuario no tiene acceso a esta pagina o aplicacion";
                        }
                        return Json(new { sucess = false, pathredirect = "", message = msjerrr }, JsonRequestBehavior.AllowGet);
                    }
                }
                /**/
                /*Conectandome al Site de Propiedad - Lineas Comerciales*/
                else if (blName.Contains("Vivienda") && user != null)
                {
                    string PVLineasAliadasPath = oDropDownManager.GetParameter("PARAMETER_KEY_VIVIENDA_PATH").Value;
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
                        return Json(new { sucess = true, pathredirect = data.UrlPath, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string msjerrr = data.errormessage;
                        if (msjerrr == "This user does not have access to this page or App")
                        {
                            msjerrr = "Este usuario no tiene acceso a esta pagina o aplicacion";
                        }
                        return Json(new { sucess = false, pathredirect = "", message = msjerrr }, JsonRequestBehavior.AllowGet);
                    }
                }
                /**/

                /*Conectandome al Site de Propiedad - Vida*/
                else if (blName.Contains("Vida") && user != null)
                {
                    string PvVidaPath = oDropDownManager.GetParameter("PARAMETER_KEY_VIDA_PATH").Value;
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

                        return Json(new { sucess = true, pathredirect = data.UrlPath, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string msjerrr = data.errormessage;
                        if (msjerrr == "This user does not have access to this page or App")
                        {
                            msjerrr = "Este usuario no tiene acceso a esta pagina o aplicacion";
                        }
                        return Json(new { sucess = false, pathredirect = "", message = msjerrr }, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            return Json(new { sucess = true, pathredirect = "", message = "" }, JsonRequestBehavior.AllowGet);
        }

        public Entity.Entities.WSEntities.AgentTreeInfoNewWS GetAgentInfo(string NameId, Statetrust.Framework.Security.Bll.Usuarios usuario)
        {
            var result = oAgentWSProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, 2)
                .Select(r => new Entity.Entities.WSEntities.AgentTreeInfoNewWS
                {
                    AgentCode = r.AgentCode,
                    CorpId = r.CorpId,
                    FullName = r.FullName,
                    FullNameAll = r.FullNameAll,
                    NameId = r.NameId
                }).FirstOrDefault(x => x.NameId == NameId);

            return
                result;
        }

        public void setAgentToQuotationOnRequoting(int QuotationID, Driver driver, string agentChangeSelected)
        {
            var usuario = GetCurrentUsuario();
            Entity.Entities.WSEntities.AgentTreeInfoNewWS agent = null;

            if (usuario != null)
            {
                agent = GetAgentInfo(agentChangeSelected, usuario);
            }

            if (agent != null)
            {
                Quotation.parameter param = new Quotation.parameter();
                param.id = QuotationID;

                if (usuario == null)
                {
                    var us = CheckQuotationHasUser(QuotationID);
                    if (us > 0)
                    {
                        param.user_Id = us;
                    }
                    else
                    {
                        var agentNameId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_NAME").Value;
                        param.user_Id = CheckUser(agentNameId, null, null, null);
                    }
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                {
                    if (agent != null)
                    {
                        param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                    }
                    else
                    {
                        var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                        param.user_Id = (us > 0) ? us : CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                    }
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User)
                {
                    param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                }
                else //Agent
                {
                    if (agent != null)
                        param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                    else
                    {
                        var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                        param.user_Id = (us > 0) ? us : CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email, usuario.AgentId);
                    }
                }

                var getquo2 = oQuotationManager.GetQuotation(QuotationID);
                if (getquo2 != null)
                {
                    param.monthlyPayment = getquo2.MonthlyPayment;
                    param.financed = getquo2.Financed;
                    param.period = getquo2.Period;

                    if (!string.IsNullOrEmpty(base.RiskLevel))
                        param.RiskLevel = base.RiskLevel;
                }
                param.modi_UserId = (GetCurrentUserID() != null ? GetCurrentUserID() : getquo2.Modi_UserId);
                var quotSaved = oQuotationManager.SetQuotation(param);
            }
        }

        public JsonResult GetFuelType(int? FuelTypeId, int? MakeId, int? ModelId)
        {
            if (FuelTypeId.HasValue && MakeId.HasValue && ModelId.HasValue)
            {
                var data = oDropDownManager.GetVehicleFuelTypeByModel(new VehicleFuelTypeByModel.Parameter()
                {
                    vehicleFuelTypeIdSysflex = FuelTypeId,
                    makeId = MakeId,
                    modelId = ModelId
                });

                if (data.Count() > 0)
                {
                    var qdata = from d in data
                                select new
                                {
                                    Value = d.VehicleFuelTypeIdSysflex,
                                    Name = d.VehicleFuelTypeDesc
                                };

                    return Json(qdata.ToArray(), JsonRequestBehavior.AllowGet);
                }
            }
            else if (MakeId.HasValue && ModelId.HasValue)
            {
                var data = oDropDownManager.GetVehicleFuelTypeByModel(new VehicleFuelTypeByModel.Parameter()
                {
                    makeId = MakeId,
                    modelId = ModelId
                });

                if (data.Count() > 0)
                {
                    var qdata = from d in data
                                select new
                                {
                                    Value = d.VehicleFuelTypeIdSysflex,
                                    Name = d.VehicleFuelTypeDesc
                                };

                    return Json(qdata.ToArray(), JsonRequestBehavior.AllowGet);
                }
            }

            var fuelData = oDropDownManager.GetVehicleFuelType(FuelTypeId);

            var qfuelData = from fd in fuelData
                            select new
                            {
                                Value = fd.VehicleFuelTypeIdSysflex,
                                Name = fd.VehicleFuelTypeDesc
                            };

            return Json(qfuelData.ToArray(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Quotation

        private Tuple<IEnumerable<Entity.Entities.VehicleProduct>, List<Entity.Entities.Coverage>> getVehiclesAndCoverages(int QuotationID)
        {
            Tuple<IEnumerable<Entity.Entities.VehicleProduct>, List<Entity.Entities.Coverage>> result;

            var VehicleData = getVehicleData(QuotationID).Select(v => new Entity.Entities.VehicleProduct
            {
                Id = v.Id,
                VehicleDescription = v.VehicleDescription,
                Year = v.Year,
                Cylinders = v.Cylinders,
                Passengers = v.Passengers,
                Weight = v.Weight,
                Chassis = v.Chassis,
                Plate = v.Plate,
                Color = v.Color,
                VehiclePrice = v.VehiclePrice,
                InsuredAmount = v.InsuredAmount,
                PercentageToInsure = v.PercentageToInsure,
                TotalPrime = v.TotalPrime,
                TotalIsc = v.TotalIsc,
                TotalDiscount = v.TotalDiscount,
                SelectedProductCoreId = v.SelectedProductCoreId,
                VehicleTypeCoreId = v.VehicleTypeCoreId,
                SelectedProductName = v.SelectedProductName,
                VehicleTypeName = v.VehicleTypeName,
                VehicleMakeName = v.VehicleMakeName,
                UsageId = v.UsageId,
                UsageName = v.UsageName,
                StoreId = v.StoreId,
                StoreName = v.StoreName,
                Driver_Id = v.Driver_Id,
                VehicleModel_Make_Id = v.VehicleModel_Make_Id,
                VehicleModel_Model_Id = v.VehicleModel_Model_Id,
                Quotation_Id = v.Quotation_Id,
                SelectedVehicleTypeId = (oDropDownManager.GetVehicleTypes((int?)v.VehicleModel_Make_Id, (int?)v.VehicleModel_Model_Id).FirstOrDefault() != null ? oDropDownManager.GetVehicleTypes((int?)v.VehicleModel_Make_Id, (int?)v.VehicleModel_Model_Id).FirstOrDefault().VehicleTypeId : v.SelectedVehicleTypeId),
                SelectedVehicleTypeName = v.SelectedVehicleTypeName,
                SelectedCoverageCoreId = v.SelectedCoverageCoreId,
                SelectedCoverageName = v.SelectedCoverageName,
                VehicleYearOld = v.VehicleYearOld,
                SurChargePercentage = v.SurChargePercentage,
                NumeroFormulario = v.NumeroFormulario,
                RateJson = v.RateJson,
                UserId = v.UserId,
                Modi_Date = v.Modi_Date,
                SecuenciaVehicleSysflex = v.SecuenciaVehicleSysflex,
                IsFacultative = v.IsFacultative,
                AmountFacultative = v.AmountFacultative,
                VehicleQuantity = v.VehicleQuantity,
                ModelDesc = v.ModelDesc,
                VehicleNumber = v.VehicleNumber,
                ProratedPremium = v.ProratedPremium,
                SelectedVehicleFuelTypeId = v.SelectedVehicleFuelTypeId,
                SelectedVehicleFuelTypeDesc = v.SelectedVehicleFuelTypeDesc,
                minimumdepreciation = v.minimumdepreciation,
                IsOverPreMium = v.IsOverPreMium,
                minimumdepreciationId = v.minimumdepreciationId,
                TotalDeppreciation = v.TotalDeppreciation,
                TotalDepreciationId = v.TotalDepreciationId
            });

            List<Entity.Entities.Coverage> CoverageData = new List<Coverage>();

            foreach (var v in VehicleData)
            {
                var coverageByVehicle = oQuotationManager.GetQuotationCoverage(v.Id.GetValueOrDefault(), CommonEnums.CoverageFilterType.Todo.ToInt()).Select(a => new Entity.Entities.Coverage
                {
                    Id = a.Id,
                    IsSelected = a.IsSelected,
                    CoverageDetailCoreId = a.CoverageDetailCoreId,
                    Name = a.Name,
                    Amount = a.Amount,
                    MinDeductible = a.MinDeductible,
                    SelfDamagesToProductLimits = a.SelfDamagesToProductLimits,
                    ThirdPartyToProductLimits = a.ThirdPartyToProductLimits,
                    ServiceType_Id = a.ServiceType_Id,
                    Limit = a.Limit,
                    UserId = a.UserId,
                    Deductible = a.Deductible,
                    CoverageType = a.CoverageType,
                    vehilceID = v.Id.GetValueOrDefault(),
                    baseDeductible = a.baseDeductible,
                    coveragePercentage = a.coveragePercentage,
                    AllowsToSummarize = a.AllowsToSummarize
                }).ToList();

                foreach (var c in coverageByVehicle)
                {
                    CoverageData.Add(c);
                }
            }

            result = new Tuple<IEnumerable<Entity.Entities.VehicleProduct>, List<Entity.Entities.Coverage>>(VehicleData, CoverageData);

            return
                result;
        }

        private QuotationViewModel GetDataQuotation(int QuotationID = 0)
        {
            var data = new QuotationViewModel();

            if (QuotationID > 0)
            {
                var defaultFuelType = oDropDownManager.GetParameter("PARAMETER_KEY_FUEL_TYPE_DEFAULT_VALUE").Value.ToInt();
                var defaultFuelTypeText = oDropDownManager.GetParameter("PARAMETER_KEY_FUEL_TYPE_DEFAULT_VALUE_TEXT").Value;

                var quotData = oQuotationManager.GetQuotation(QuotationID);
                data.StartDate = quotData.StartDate;
                data.EndDate = quotData.EndDate;
                data.PaymentFreqIdSelected = quotData.PaymentFreqIdSelected != null ? quotData.PaymentFreqIdSelected.Replace("\"", "'") : "";
                data.LastStepVisited = quotData.LastStepVisited;
                data.Id = quotData.Id;
                data.QuotationCoreNumber = quotData.QuotationCoreNumber;
                data.QuotationNumber = quotData.QuotationNumber;
                data.TotalPrime = quotData.TotalPrime;
                data.TotalISC = quotData.TotalISC;
                data.TotalDiscount = quotData.TotalDiscount;
                data.PaymentFrequency = quotData.PaymentFrequency;
                data.SendInspectionOnly = quotData.SendInspectionOnly;
                data.User_Id = quotData.User_Id;
                data.policyNoMain = quotData.policyNoMain;
                data.couponCode = quotData.couponCode;
                data.couponPercentageDiscount = quotData.couponPercentageDiscount;
                data.CouponProspectId = quotData.CouponProspectId;
                data.contactFormId = quotData.contactFormId;


                #region Driver's
                var quotDriver = oQuotationManager.GetQuotationDrivers(QuotationID);
                if (quotDriver.Count() > 0)
                {
                    data._drivers = quotDriver.Where(a => a.IsPrincipal).Select(x => new QuotationViewModel.drivers
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        SecondName = x.SecondName,
                        FirstSurname = x.FirstSurname,
                        SecondSurname = x.SecondSurname,
                        DateOfBirth = x.DateOfBirth,
                        IsPrincipal = x.IsPrincipal,
                        Address = x.Address,
                        PhoneNumber = x.PhoneNumber,
                        Mobile = x.Mobile,
                        WorkPhone = x.WorkPhone,
                        MaritalStatus = x.MaritalStatus,
                        Job = x.Job,
                        Company = x.Company,
                        YearsInCompany = x.YearsInCompany,
                        Sex = x.Sex,
                        City_Country_Id = x.City_Country_Id,
                        City_Domesticreg_Id = x.City_Domesticreg_Id,
                        City_State_Prov_Id = x.City_State_Prov_Id,
                        City_City_Id = x.City_City_Id,
                        Nationality_Global_Country_Id = x.Nationality_Global_Country_Id,
                        Email = x.Email,
                        IdentificationType = x.IdentificationType,
                        IdentificationNumber = x.IdentificationNumber,
                        ForeignLicense = x.ForeignLicense,
                        IdentificationNumberValidDate = x.IdentificationNumberValidDate,
                        InvoiceTypeId = x.InvoiceTypeId,
                        UserId = x.UserId,
                        Modi_Date = x.Modi_Date,
                        PostalCode = x.PostalCode,
                        AnnualIncome = x.AnnualIncome,
                        SocialReasonId = x.SocialReasonId,
                        OwnershipStructureId = x.OwnershipStructureId,
                        IdentificationFinalBeneficiaryOptionsId = x.IdentificationFinalBeneficiaryOptionsId,
                        PepFormularyOptionsId = x.PepFormularyOptionsId,
                        Home_Owner = x.Home_Owner,
                        QtyPersonsDepend = x.QtyPersonsDepend,
                        QtyEmployees = x.QtyEmployees,
                        Linked = x.Linked,
                        Segment = x.Segment,
                        Fax = x.Fax,
                        URL = x.URL,
                        CityDesc = x.CityDesc,
                        MunicipioDesc = x.MunicipioDesc,
                        GlobalCountryDesc = x.GlobalCountryDesc,
                        GlobalCountryDescEN = x.GlobalCountryDescEN,
                        StateProvDesc = x.StateProvDesc,
                        SocialReasonDesc = x.SocialReasonDesc,
                        PepFormularyOptionsDesc = x.PepFormularyOptionsDesc,
                        OwnershipStructureDesc = x.OwnershipStructureDesc,
                        IdentificationFinalBeneficiaryOptionsDesc = x.IdentificationFinalBeneficiaryOptionsDesc,
                        TypeOfPerson = x.TypeOfPerson

                    })
                    .ToList();
                }
                #endregion

                #region Vehicle's
                var quotVehicle = oQuotationManager.GetQuotationVehicles(QuotationID);
                if (quotVehicle.Count() > 0)
                {
                    data._vehicles = quotVehicle.Select(x => new QuotationViewModel.Vehicles
                    {
                        VehicleNumber = x.VehicleNumber,
                        Id = x.Id,
                        VehicleDescription = x.VehicleDescription,
                        Year = x.Year,
                        Cylinders = x.Cylinders,
                        Passengers = x.Passengers,
                        Weight = x.Weight,
                        Chassis = x.Chassis,
                        Plate = x.Plate,
                        Color = x.Color,
                        VehiclePrice = x.VehiclePrice,
                        InsuredAmount = x.InsuredAmount,
                        PercentageToInsure = x.PercentageToInsure,
                        TotalPrime = x.TotalPrime,
                        TotalIsc = x.TotalIsc,
                        TotalDiscount = x.TotalDiscount,
                        SelectedProductCoreId = x.SelectedProductCoreId,
                        VehicleTypeCoreId = x.VehicleTypeCoreId,
                        SelectedProductName = x.SelectedProductName,
                        VehicleTypeName = x.VehicleTypeName,
                        VehicleMakeName = x.VehicleMakeName,
                        ModelDesc = x.ModelDesc,
                        UsageId = x.UsageId,
                        UsageName = x.UsageName,
                        StoreId = x.StoreId,
                        StoreName = x.StoreName,
                        Driver_Id = x.Driver_Id,
                        VehicleModel_Make_Id = x.VehicleModel_Make_Id,
                        VehicleModel_Model_Id = x.VehicleModel_Model_Id,
                        Quotation_Id = x.Quotation_Id,
                        SelectedVehicleTypeId = x.SelectedVehicleTypeId,
                        SelectedVehicleTypeName = x.SelectedVehicleTypeName,
                        SelectedCoverageCoreId = x.SelectedCoverageCoreId,
                        SelectedCoverageName = x.SelectedCoverageName,
                        VehicleYearOld = x.VehicleYearOld,
                        SurChargePercentage = x.SurChargePercentage,
                        NumeroFormulario = x.NumeroFormulario,
                        RateJson = x.RateJson,
                        UserId = x.UserId,
                        Modi_Date = x.Modi_Date,
                        SecuenciaVehicleSysflex = x.SecuenciaVehicleSysflex,
                        IsFacultative = x.IsFacultative,
                        AmountFacultative = x.AmountFacultative,
                        VehicleQuantity = x.VehicleQuantity,
                        TotalPrimeVehicle = x.TotalPrime.GetValueOrDefault() + x.TotalIsc.GetValueOrDefault(),
                        SelectedVehicleFuelTypeId = x.SelectedVehicleFuelTypeId.HasValue ? x.SelectedVehicleFuelTypeId.Value : defaultFuelType,
                        SelectedVehicleFuelTypeDesc = x.SelectedVehicleFuelTypeId.HasValue ? x.SelectedVehicleFuelTypeDesc : defaultFuelTypeText,

                        vehicleProductLimits = oQuotationManager.GetQuotationProductLimits(x.Id.GetValueOrDefault()).Select(a => new QuotationViewModel.VehicleProductLimits
                        {
                            Id = a.Id,
                            IsSelected = a.IsSelected,
                            SdPrime = a.SdPrime,
                            TpPrime = a.TpPrime,
                            ServicesPrime = a.ServicesPrime,
                            ISC = a.ISC,
                            ISCPercentage = a.ISCPercentage,
                            TotalPrime = a.TotalPrime,
                            TotalIsc = a.TotalIsc,
                            TotalDiscount = a.TotalDiscount,
                            SelectedDeductibleCoreId = a.SelectedDeductibleCoreId,
                            SelectedDeductibleName = a.SelectedDeductibleName,
                            VehicleProduct_Id = a.VehicleProduct_Id,
                            UserId = a.UserId
                        })
                        .FirstOrDefault(),

                        coverages = oQuotationManager.GetQuotationCoverage(x.Id.GetValueOrDefault(), CommonEnums.CoverageFilterType.Todo.ToInt()).Select(a => new QuotationViewModel.coverages
                        {
                            Id = a.Id,
                            IsSelected = a.IsSelected,
                            CoverageDetailCoreId = a.CoverageDetailCoreId,
                            Name = a.Name,
                            Amount = a.Amount,
                            MinDeductible = a.MinDeductible,
                            SelfDamagesToProductLimits = a.SelfDamagesToProductLimits,
                            ThirdPartyToProductLimits = a.ThirdPartyToProductLimits,
                            ServiceType_Id = a.ServiceType_Id,
                            Limit = a.Limit,
                            UserId = a.UserId,
                            Deductible = a.Deductible,
                            CoverageType = a.CoverageType
                        })
                        .ToList(),

                        _services = oQuotationManager.GetQuotationCoverage(x.Id.GetValueOrDefault(), CommonEnums.CoverageFilterType.ServiciosSeleccionados.ToInt()).Select(a => new QuotationViewModel.coverages
                        {
                            Id = a.Id,
                            IsSelected = a.IsSelected,
                            CoverageDetailCoreId = a.CoverageDetailCoreId,
                            Name = a.Name,
                            Amount = a.Amount,
                            MinDeductible = a.MinDeductible,
                            SelfDamagesToProductLimits = a.SelfDamagesToProductLimits,
                            ThirdPartyToProductLimits = a.ThirdPartyToProductLimits,
                            ServiceType_Id = a.ServiceType_Id,
                            Limit = a.Limit,
                            UserId = a.UserId,
                            Deductible = a.Deductible,
                            CoverageType = a.CoverageType
                        })
                        .ToList(),
                    })
                    .ToList();
                }
                #endregion

                #region Agent Quotation
                data._agentQuotation = oUserManager.GetUser(quotData.User_Id, null, null, null);
                #endregion
            }

            return data;
        }

        private int GetNewDailyQuotationNumber()
        {
            var nextQ = oDropDownManager.GetDropDown(CommonEnums.DropDownType.NEXTQUOTATION.ToString());

            if (nextQ.Count() > 0)
                return nextQ.FirstOrDefault().Value.ToInt() + 1;
            else
                return 0;
        }

        public string GetQuotationCoreNumber(int quotationPossitenumber)
        {
            var quotation = oQuotationManager.GetQuotation(quotationPossitenumber);

            if (quotation != null && quotation.QuotationCoreNumber != null)
            {
                return quotation.QuotationCoreNumber;
            }
            else { return "0"; }
        }

        public JsonResult loadQuotatoin(string QuotationID)
        {
            QuotationViewModel data = new QuotationViewModel();
            bool _allowRequoting = true;
            int qtyMaxVehicles = 0;

            try
            {
                string decriptedId = Utility.Decode(QuotationID.Replace("%3d", "="));
                int realQuotationID = decriptedId.ToInt();

                data = GetDataQuotation(realQuotationID);

                QuotationId = realQuotationID;
                QuotationNumber = data != null ? data.QuotationNumber : "";

                if (data != null)
                {
                    isNotLawProduct = data.SendInspectionOnly.GetValueOrDefault();

                    DateTime actualDate = DateTime.Now;

                    if (data.StartDate.GetValueOrDefault().Date < actualDate.Date)
                    {
                        data.StartDate = actualDate.Date;
                        data.EndDate = actualDate.AddYears(1).Date;
                    }


                    var quantityToNoRequoting = oDropDownManager.GetParameter("PARAMETER_KEY_QUANTITY_TO_NO_REQUOTING").Value.ToInt();

                    int qtyVehicles = data._vehicles != null ? data._vehicles.Count() : 0;


                    if (qtyVehicles > quantityToNoRequoting)
                    {
                        _allowRequoting = false;

                        qtyMaxVehicles = data._vehicles.Sum(x => x.VehicleQuantity.GetValueOrDefault());
                    }

                }
            }
            catch (Exception ex)
            {
                return Json(new { error = "La cotización solicitada no existe." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { quotData = data, AllowRequoting = _allowRequoting, qtyMaxVehicles = qtyMaxVehicles }, JsonRequestBehavior.AllowGet);
        }

        public string GetQuotationProduct(int quotationID)
        {
            var data = GetDataQuotation(quotationID);

            if (data._vehicles != null && data._vehicles.Count > 0)
            {
                var prods = data._vehicles.Select(c => c.SelectedProductName).Distinct();

                if (prods.Count() > 1)
                    return "Flotilla";
                else
                    return prods.First();
            }
            else
                return string.Empty;
        }

        #endregion

        #region Methods of CoreProxy

        public Entity.Entities.WSEntities.OfficeMatchWS GetOfficeMatch(int globalOfficeId)
        {
            Entity.Entities.WSEntities.OfficeMatchWS result = null;

            var dataResult = oCoreProxy.GetofficeMatch_NewPV(globalOfficeId).FirstOrDefault();
            if (dataResult != null)
            {
                result = new Entity.Entities.WSEntities.OfficeMatchWS
                {
                    OfficeDesc = dataResult.OfficeDesc,
                    OfficeIdGlobal = dataResult.OfficeIdGlobal,
                    OfficeIdSysFlex = dataResult.OfficeIdSysFlex
                };
            }

            return result;
        }

        public JsonResult GetVehicleTypes_New(int brandId, int modelId, int vehicleYear, string AgentCode)
        {
            var model = oDropDownManager.GetVehicleTypes(brandId, modelId).FirstOrDefault();

            if (model != null)
            {
                var paramDeLey = oDropDownManager.GetParameter("PARAMETER_KEY_DELEY_DISCRIMINATOR").Value;
                int codRamo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();

                try
                {
                    var usersysflexornotProducts = oDropDownManager.GetParameter("PARAMETER_KEY_USE_OR_NOT_SYSFLEX_PRODUCTS").Value;

                    if (usersysflexornotProducts == "S")
                    {
                        var prods = oCoreProxy.GetVehicleTypes_NewPV(model.CoreVehicleTypeId, vehicleYear, paramDeLey, codRamo);

                        var realProds = ProductsFromSysflex.GetVehicleTypes_NewPV(prods);

                        return Json(realProds.ToArray(), JsonRequestBehavior.AllowGet);
                    }
                    else if (usersysflexornotProducts == "N")
                    {
                        var prods = ProductsFromSysflex.GetProductsSysflex(model.CoreVehicleTypeId, vehicleYear, null, codRamo, AgentCode);
                        return Json(prods.ToArray(), JsonRequestBehavior.AllowGet);
                    }

                    return Json(new System.Collections.ArrayList(), JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    var msg = string.Format("BrandId: {0} - ModelId: {1} - VehicleYear: {2}\nMensaje: {3}\nDetalle: {4}"
                                 , brandId.ToString()
                                 , modelId.ToString()
                                 , vehicleYear.ToString()
                                 , ex.Message
                                 , ex.StackTrace);
                    LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error al obtener datos de productos desde Sysflex", msg, ex);
                    return Json(new System.Collections.ArrayList(), JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json(new System.Collections.ArrayList(), JsonRequestBehavior.AllowGet);
        }

        public Entity.Entities.WSEntities.ProductLimitWS GetCoverageDetails(int coverageCoreId, decimal vehiclePrice, int codRamo)
        {
            Entity.Entities.WSEntities.ProductLimitWS pLimit = new Entity.Entities.WSEntities.ProductLimitWS();
            decimal temp;

            var selfAndOthers = oCoreProxy.GetCoverageNewDetail(coverageCoreId, (int)WsProxy.SysFlexCoverageDetailsIndicators.SelfAndThirdParty, vehiclePrice, codRamo);

            pLimit.ThirdPartyCoverages = (from s in selfAndOthers
                                          where s.CoverageDetailType.ToLower() == Entity.Entities.WSEntities.CoverageDetailWS.CoverageDetailTypeThirdParty.ToLower()
                                          orderby s.CoverageDetailName
                                          select new Entity.Entities.WSEntities.CoverageDetailWS()
                                          {
                                              CoverageDetailCoreId = s.CoverageDetailID.GetValueOrDefault(),
                                              Amount = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                              Limit = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                              MinDeductible = s.MinimumDeductible.GetValueOrDefault(),
                                              Name = s.CoverageDetailName
                                          }).ToList();

            pLimit.SelfDamagesCoverages = (from s in selfAndOthers
                                           where s.CoverageDetailType.ToLower() == Entity.Entities.WSEntities.CoverageDetailWS.CoverageDetailTypeSelfDamages.ToLower()
                                           orderby s.CoverageDetailName
                                           select new Entity.Entities.WSEntities.CoverageDetailWS()
                                           {
                                               CoverageDetailCoreId = s.CoverageDetailID.GetValueOrDefault(),
                                               Amount = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                               Limit = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                               MinDeductible = s.MinimumDeductible.GetValueOrDefault(),
                                               Name = s.CoverageDetailName
                                           }).ToList();

            //Additionals
            var services = oCoreProxy.GetCoverageNewDetail(coverageCoreId, (int)WsProxy.SysFlexCoverageDetailsIndicators.AdditionalServices, vehiclePrice, codRamo);

            pLimit.ServicesCoverages = (from s in services
                                        orderby s.CoverageDetailType
                                        select s.CoverageDetailType).Distinct().Select(s =>
                                            new Entity.Entities.WSEntities.ServiceTypeWS
                                            {
                                                Name = s,
                                                Coverages = new List<Entity.Entities.WSEntities.CoverageDetailWS>()
                                            }).Distinct().ToList();

            var rand = new Random(DateTime.Now.Millisecond);

            pLimit.ServicesCoverages.ToList().ForEach(sc =>
                    {
                        var coverages = (from s in services
                                         where s.CoverageDetailType == sc.Name
                                         orderby s.CoverageDetailName
                                         select new Entity.Entities.WSEntities.CoverageDetailWS()
                                         {
                                             Id = rand.Next(10000) * -1,
                                             CoverageDetailCoreId = s.CoverageDetailID.GetValueOrDefault(),
                                             IsSelected = s.mandatory,
                                             Amount = s.Premium.GetValueOrDefault(0m),
                                             Limit = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                             MinDeductible = s.MinimumDeductible.GetValueOrDefault(),
                                             Name = s.CoverageDetailName
                                         }).ToList();

                        sc.Coverages = coverages;
                    });

            return pLimit;
        }

        public JsonResult GetCoverageDetailsOfVehicle(int coverageCoreId, int makeId, int modelId, decimal vehiclePrice)
        {
            int coreId;
            int codRamo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();
            int DEDUCIBLE_SURCHARGE = oDropDownManager.GetParameter("PARAMETER_KEY_ID_DEDUCIBLE_SURCHARGE").Value.ToInt();

            try
            {
                coreId = GetModelCoreId(makeId, modelId);

                var coverageLimits = GetCoverageDetails(coverageCoreId, vehiclePrice, codRamo);

                var surcharges = oCoreProxy.GetDeductibles_NewPV(coverageCoreId, DEDUCIBLE_SURCHARGE, coreId, codRamo); ;

                var deductibles = from s in surcharges
                                  orderby s.Descripcion
                                  select new Entity.Entities.WSEntities.DeductibleValuesWS() { CoreId = s.Secuencia, Name = s.Descripcion };

                return Json(new { deductibles = deductibles.ToArray(), coverageLimits = coverageLimits }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var msg = string.Format("CoverageId: {0} - MakeId: {1} - ModelId: {2} - vehiclePrice: {3}\nMensaje: {4}\nDetalle: {5}", coverageCoreId.ToString()
                    , makeId.ToString()
                    , modelId.ToString()
                    , vehiclePrice.ToString()
                    , ex.Message
                    , ex.StackTrace);
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error al obtener datos de coberturas y deducibles desde Sysflex", msg, ex);
                throw ex;
            }
        }

        public JsonResult GetRates(
         int coverageCoreId, //Subramo
         int brandId,
         int modelId,
         int vehicleYear,
         int coveragePercent,
         string startDate,
         string endDate,
         decimal insuredAmount,
         string productId,
         int storageId,
         string servicesIdList,
         string deductibleId,
         string gender,
         string principalDateOfBirth,
         decimal? percentSurCharge,
         string QuotationNumberForRates,
         string LicenciaExtranjera,
         int qtyVehicles,
         int usage,
         int secuencia = 1,
         string agentChangeSelected = "",
         string quotationCore = "0",
         bool Esdeley = false,
         int idCapacidad = 0,
         string descCapacidad = "",
         string coverages = "",
         string limitself = "",
         string usagename = "",
         string isSemifull = "",
         string QuotationNumber = "",
         bool wasChangeDateBirth = false,
         bool wasChangeClientSex = false,
         string actualAgentSelected = "",
         int fuelTypeId = 0,
         string fuelTypeDesc = "")
        {
            List<string> statusMessages = new List<string>();
            var success = false;

            try
            {
                int cod_company = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();
                int ramo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();

                #region Actualizando Agente Cotizacion si Cambian el que seleccionaron al principio
                /*Si el id del agente cambia entonces actualizar la tabla de cotizacion con el id del agente nuevo
                 esto permitira que la prima cambie*/

                int intermediario = 0;
                var currentDriverSaved = oQuotationManager.GetQuotationDrivers(QuotationNumberForRates.ToInt());
                Driver PrincipalDriver = new Driver();
                if (currentDriverSaved != null)
                {
                    PrincipalDriver = currentDriverSaved.FirstOrDefault(x => x.IsPrincipal);
                }

                if (!string.IsNullOrEmpty(agentChangeSelected) && !string.IsNullOrEmpty(QuotationNumberForRates))
                {
                    OthersFields otf = GetOthersFields(QuotationNumberForRates, agentChangeSelected);

                    if (otf.AgentIDOnSysflex > 0)
                    {
                        intermediario = otf.AgentIDOnSysflex;

                        oCoreProxy.SetAgentInQuotationHeader_NewPV(otf.objQuotation, PrincipalDriver, intermediario, "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), cod_company, otf.codMoneda, otf.codramo, otf.tasaMoneda, otf.idOficina, null, out statusMessages);

                        if (statusMessages.Count() > 0)
                        {
                            string realMessage = "";

                            foreach (var stmsg in statusMessages)
                            {
                                realMessage += "\n" + stmsg;
                            }
                            LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error al modificar el intermediario de la cotizacion", "Mensaje: " + realMessage, null);
                            throw new Exception("Error al modificar el intermediario de la cotizacion.");
                        }
                    }

                    setAgentToQuotationOnRequoting(QuotationNumberForRates.ToInt(), PrincipalDriver, agentChangeSelected);
                }

                if (wasChangeDateBirth)
                {
                    OthersFields otf = GetOthersFields(QuotationNumberForRates, actualAgentSelected);

                    if (otf.AgentIDOnSysflex > 0)
                    {
                        var newDatebirth = DateTime.Parse(principalDateOfBirth, CultureInfo.InvariantCulture);

                        intermediario = otf.AgentIDOnSysflex;

                        oCoreProxy.SetAgentInQuotationHeader_NewPV(otf.objQuotation, PrincipalDriver, intermediario, "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), cod_company, otf.codMoneda, otf.codramo, otf.tasaMoneda, otf.idOficina, newDatebirth, out statusMessages);

                        if (statusMessages.Count() > 0)
                        {
                            string realMessage = "";

                            foreach (var stmsg in statusMessages)
                            {
                                realMessage += "\n" + stmsg;
                            }
                            LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error al modificar el intermediario de la cotizacion", "Mensaje: " + realMessage, null);
                            throw new Exception("Error al modificar el intermediario de la cotizacion.");
                        }
                    }
                }

                if (wasChangeClientSex)
                {
                    OthersFields otf = GetOthersFields(QuotationNumberForRates, actualAgentSelected);

                    if (otf.AgentIDOnSysflex > 0)
                    {
                        var newSex = gender;

                        intermediario = otf.AgentIDOnSysflex;

                        oCoreProxy.SetAgentInQuotationHeader_NewPV(otf.objQuotation, PrincipalDriver, intermediario, "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), cod_company, otf.codMoneda, otf.codramo, otf.tasaMoneda, otf.idOficina, null, out statusMessages, newSex);

                        if (statusMessages.Count() > 0)
                        {
                            string realMessage = "";

                            foreach (var stmsg in statusMessages)
                            {
                                realMessage += "\n" + stmsg;
                            }
                            LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error al modificar el intermediario de la cotizacion", "Mensaje: " + realMessage, null);
                            throw new Exception("Error al modificar el intermediario de la cotizacion.");
                        }
                    }
                }
                /**/
                #endregion

                #region Insertando Detalle/Obteniendo prima de la cotizacion


                var model = oDropDownManager.GetVehicleModels(brandId).FirstOrDefault(x => x.Id == modelId);

                var Marca = oDropDownManager.GetDropDown(STL.POS.Frontend.Web.NewVersion.CustomCode.CommonEnums.DropDownType.BRANDS.ToString()).FirstOrDefault(x => x.Value == brandId.ToString());

                var Type = oDropDownManager.GetVehicleTypes(brandId, modelId).FirstOrDefault();

                var Type1 = oDropDownManager.GetVehicleTypes(brandId, modelId).FirstOrDefault();

                /*Storage from POS_SITE*/
                var param = oDropDownManager.GetParameter("PARAMETER_KEY_STORED_VALUES").Value;
                Dictionary<int, string> values = JsonConvert.DeserializeObject<Dictionary<int, string>>(param);
                var StorageOutput = from pair in values
                                    select new { id = pair.Key, name = pair.Value };

                var storageName = "";
                if (StorageOutput.Count() > 0)
                {
                    var storage = StorageOutput.FirstOrDefault(x => x.id == storageId);
                    if (storage != null)
                    {
                        storageName = storage.name;
                    }
                }

                if (deductibleId == "") { deductibleId = "0"; }

                var tipoveh = new List<Entity.Entities.WSEntities.ComboCondicion>();
                var Marcavehiculo = new List<Entity.Entities.WSEntities.ComboCondicion>();
                var Usovehiculo = new List<Entity.Entities.WSEntities.ComboCondicion>();
                var Aniovehiculo = new List<Entity.Entities.WSEntities.ComboCondicion>();
                var Deductible = new List<Entity.Entities.WSEntities.ComboCondicion>();
                var Storage = new List<Entity.Entities.WSEntities.ComboCondicion>();
                //var VersionVehiculo = new SysflexComboCondicion();

                /*type MakesVEH*/
                Marcavehiculo = ComboConditionsMethods.GetComboCondicion_New("MakesVEH", ramo, coverageCoreId, "MARCA VEHÍCULO", Marca.name, null, null);

                /*type YearVEH*/
                Aniovehiculo = ComboConditionsMethods.GetAnioVehiculo_New("YearVEH", ramo, coverageCoreId, "AÑOS VEHICULOS", null, vehicleYear, null);

                /*type DeducibleVEH*/
                Deductible = ComboConditionsMethods.GetDeductible_New("DeducibleVEH", ramo, coverageCoreId, "DEDUCIBLE", null, vehicleYear, Convert.ToInt32(deductibleId));

                /*type StorageVEH*/
                Storage = ComboConditionsMethods.GetDeductible_New("StorageVEH", ramo, coverageCoreId, "Estacionamiento", storageName, null, null);

                var cDetail = new STL.POS.WsProxy.SysflexService.PolicyQuotationSysFlexCotDetKey();

                var startDatetime = DateTime.Parse(startDate, CultureInfo.InvariantCulture);
                var endDatetime = DateTime.Parse(endDate, CultureInfo.InvariantCulture);

                cDetail.cotizacion = Convert.ToDecimal(quotationCore);

                cDetail.ramo = ramo;
                cDetail.subRamo = coverageCoreId;
                cDetail.secuencia = secuencia;
                cDetail.montoAsegurado = insuredAmount;
                cDetail.tasa = 0;
                cDetail.formadePago = "";

                cDetail.idTipoVehiculo = Type.CoreVehicleTypeId.ToString();

                if (Marcavehiculo.Count() > 0)
                {
                    cDetail.idMarcaVehiculo = Marcavehiculo.FirstOrDefault().Codigo.ToString();
                }

                cDetail.idModeloVehiculo = model.CoreId.ToString();
                cDetail.idVersion = "";
                cDetail.version = "";

                if (Aniovehiculo.Count() > 0)
                {
                    cDetail.idAnoVehiculo = Aniovehiculo.FirstOrDefault().Codigo.ToString();
                }
                cDetail.anoVehiculo = vehicleYear.ToString();

                cDetail.idUso = usage.ToString();

                if (Storage.Count() > 0)
                {
                    cDetail.idEstacionaEn = Storage.FirstOrDefault().Codigo.ToString();
                }

                cDetail.idColor = "";
                cDetail.color = "";
                cDetail.idCapacidad = idCapacidad.ToString();
                cDetail.capacidad = descCapacidad;

                cDetail.fechaInicio = startDatetime.Date;
                cDetail.fechaFin = endDatetime.Date;

                /*Actualziacion de fecha de vencimiento en base a 6 meses*/
                if (isSemifull.Contains("(6 Meses)")
                    || isSemifull.Contains("( 6 Meses )")
                    || isSemifull.Contains("( 6 Meses)")
                    || isSemifull.Contains("(6 Meses )")
                    )
                {
                    var dateStart = startDatetime;
                    DateTime newEndDate = dateStart.AddMonths(6);

                    cDetail.fechaFin = newEndDate.Date;
                    cDetail.fechaInicio = startDatetime.Date;
                }


                //si es de ley no lleva deducible
                if (!Esdeley)
                {
                    if (Deductible.Count() > 0 && Deductible.FirstOrDefault().Codigo != null & Deductible.FirstOrDefault().Descripcion != null)
                    {
                        cDetail.iddeducible = Deductible.FirstOrDefault().Codigo.ToString();
                        cDetail.deducible = Deductible.FirstOrDefault().Descripcion.ToString();
                    }
                    else
                    {
                        cDetail.iddeducible = "0";
                        cDetail.deducible = "";
                    }
                }

                cDetail.compania = cod_company;

                var quantityOfMonth = Utility.QuantityOfMonth(cDetail.fechaInicio.Value, cDetail.fechaFin.Value);
                cDetail.cantidadMeses = quantityOfMonth == 0 ? 1 : quantityOfMonth;// 12;

                cDetail.codigoTarifa = 1;
                cDetail.categoria = "";
                cDetail.tipoVehiculo = Type.VehicleTypeDesc;
                cDetail.marcaVehiculo = Marca.name;
                cDetail.modeloVehiculo = model.Name;
                cDetail.uso = usagename;
                cDetail.estacionaEn = Storage.Count() > 0 ? Storage.FirstOrDefault().Descripcion : storageName;
                cDetail.renovacionAutomatica = "S";
                cDetail.usuario = "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "Venta Directa");
                cDetail.estatus = "ACTIVO";
                cDetail.porciendoCobertura = coveragePercent.ToString();

                cDetail.PorcientoRecargoVentas = percentSurCharge.GetValueOrDefault();

                bool foreingLicence = false;
                if ((LicenciaExtranjera == "1" || LicenciaExtranjera == "Si" || LicenciaExtranjera == "true" || LicenciaExtranjera == "True" || LicenciaExtranjera == "TRUE") && gender != "Empresa" && isSemifull.ToLower().IndexOf("semi") <= -1)
                {
                    foreingLicence = true;
                }
                else if (gender == "Empresa")
                {
                    var foreingLicenceParam = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_DEFAULT_FOREIGNLICENSE").Value;
                    bool.TryParse(foreingLicenceParam, out foreingLicence);
                }
                cDetail.licenciaExtranjera = foreingLicence;


                var genderId = 1;

                if (gender == "Femenino")
                {
                    genderId = 2;
                }

                DateTime birthday = DateTime.Now;
                int age = 0;

                if (gender == "Empresa")
                {
                    var genderParam = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_DEFAULT_SEX").Value;
                    int genderCompany = 0;
                    int.TryParse(genderParam, out genderCompany);

                    if (genderCompany > 0)
                    {
                        genderId = genderCompany;

                        gender = "N/A";
                    }

                    var ageParam = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_DEFAULT_AGE").Value;
                    int ageCompany = 0;
                    int.TryParse(ageParam, out ageCompany);

                    if (ageCompany > 0)
                    {
                        age = 0;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(principalDateOfBirth))
                    {
                        birthday = DateTime.Parse(principalDateOfBirth, CultureInfo.InvariantCulture);
                        age = Utility.GetAge(birthday);
                    }
                }

                STL.POS.WsProxy.SysflexService.PolicySexoEdadKeyParameter paramSex = new WsProxy.SysflexService.PolicySexoEdadKeyParameter();
                paramSex.Sexo = gender;
                paramSex.Edad = age.ToString();
                paramSex.RamoID = ramo;
                paramSex.subramo = coverageCoreId;

                var resultSexoEdad = oCoreProxy.GetSexoEdad(paramSex);
                var sexage = !string.IsNullOrEmpty(resultSexoEdad) ? resultSexoEdad : null;
                cDetail.sexoEdad = sexage;

                cDetail.idTipoCombustible = fuelTypeId.ToString();
                cDetail.tipoCombustible = fuelTypeDesc;

                success = false;

                //Inserto el detalle de la cotizacion
                var output = oCoreProxy.GetRates_New(cDetail, out statusMessages);
                /**/


                /*inserto las cobeturas del vehiculo actual*/

                if (!string.IsNullOrEmpty(limitself))
                {
                    List<Entity.Entities.WSEntities.CoverageJsonClass> selfAndThirdCoverage = new List<Entity.Entities.WSEntities.CoverageJsonClass>();

                    var self = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.CoverageJsonClass>>(limitself);

                    if (self != null)
                    {
                        foreach (var st in self.ToList())
                        {
                            selfAndThirdCoverage.Add(st);
                        }
                    }

                    List<Entity.Entities.WSEntities.CoverageJsonClass> ServiceCoverage = new List<Entity.Entities.WSEntities.CoverageJsonClass>();

                    if (!string.IsNullOrEmpty(coverages) && coverages != "[]")
                    {
                        var serviceCov = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.CoverageJsonClass>>(coverages);

                        if (serviceCov != null)
                        {
                            foreach (var ser in serviceCov.ToList())
                            {
                                Entity.Entities.WSEntities.CoverageJsonClass servicesActual = new Entity.Entities.WSEntities.CoverageJsonClass();
                                servicesActual.CoverageDetailCoreId = ser.CoverageDetailCoreId;
                                servicesActual.Name = ser.Name;
                                servicesActual.Limit = ser.Limit;
                                servicesActual.isSelected = ser.isSelected;
                                //servicesActual.delete = (ser.isSelected == false);

                                ServiceCoverage.Add(servicesActual);
                            }
                        }
                    }

                    oCoreProxy.SetCoverageVehicle_GetRate_NewPV(selfAndThirdCoverage, ServiceCoverage, Convert.ToDecimal(quotationCore), secuencia, cod_company, out statusMessages);
                    //Inserto otra vez el detalle de manera que se actualize con los cambios de las coberturas
                    output = oCoreProxy.GetRates_New(cDetail, out statusMessages);
                }

                if (statusMessages.Count() > 0)
                {
                    string realMessage = "";

                    foreach (var stmsg in statusMessages)
                        realMessage += "\n" + stmsg;

                    LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), Convert.ToInt32(QuotationNumberForRates), "Error al obtener la prima", "Mensaje: " + " QuotationID: " + QuotationNumber + " " + realMessage, null);
                    return Json(new { messageError = "Error al obtener la Prima." }, JsonRequestBehavior.AllowGet);
                }
                success = true;
                return Json(output, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (statusMessages.Count() > 0)
                {
                    string realMessage = "";

                    foreach (var stmsg in statusMessages)
                    {
                        realMessage += "\n" + stmsg;
                    }

                    LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), Convert.ToInt32(QuotationNumberForRates), "Error al obtener la prima", "Mensaje: " + " QuotationID: " + QuotationNumber + " " + realMessage, null);
                }
                success = false;

                return Json(new { messageError = "Error al obtener la Prima." }, JsonRequestBehavior.AllowGet);
            }
            #endregion
        }

        private OthersFields GetOthersFields(string QuotationNumberForRates, string agentChangeSelected = "")
        {
            OthersFields otf = new OthersFields();
            int intermediario = 0;
            int QuotationIDForRates = 0;

            if (!string.IsNullOrEmpty(QuotationNumberForRates))
            {
                var idOficina = oDropDownManager.GetParameter("PARAMETER_KEY_COD_OFICINA").Value.ToInt();
                var idOficinaVO = oDropDownManager.GetParameter("PARAMETER_KEY_COD_OFICINA_VO").Value.ToInt();

                int.TryParse(QuotationNumberForRates, out QuotationIDForRates);
                var quotation = GetDataQuotation(QuotationIDForRates); //GetQuotationForReport(QuotationIDForRates);
                var quotationUser = quotation != null ? getQuotationUserById(quotation.User_Id.GetValueOrDefault()) : null;

                if (quotation != null)
                {
                    if (quotation.SendInspectionOnly.HasValue && !quotation.SendInspectionOnly.Value)
                    {
                        ViewBag.userCanApplySurCharge = "N";
                    }
                }

                var userAgenCode = new Statetrust.Framework.Security.Bll.Usuarios();

                if (!string.IsNullOrEmpty(agentChangeSelected))
                {
                    userAgenCode = getAgenteUserInfo(agentChangeSelected);
                }
                else
                {
                    userAgenCode = getAgenteUserInfo((quotationUser.AgentId.HasValue ? quotationUser.AgentId.Value : 0));
                }

                if (userAgenCode != null)
                {
                    var OfficeId = 13;
                    idOficinaVO = userAgenCode.AgentOffices != null ? userAgenCode.AgentOffices.FirstOrDefault().OfficeId : idOficinaVO;

                    var dataMatch = GetOfficeMatch(idOficinaVO);

                    if (dataMatch != null && dataMatch.OfficeIdSysFlex.GetValueOrDefault() > 0)
                    {
                        OfficeId = dataMatch.OfficeIdSysFlex.GetValueOrDefault();
                    }
                    else
                    {
                        idOficina = idOficinaVO = userAgenCode.AgentOffices.First().OfficeId;
                    }

                    idOficina = OfficeId;

                    int.TryParse(userAgenCode.AgentCode, out intermediario);
                }

                otf.idOficina = idOficina;
                otf.AgentIDOnSysflex = intermediario;
                otf.codMoneda = oDropDownManager.GetParameter("PARAMETER_KEY_COD_MONEDA_SYSFLEX").Value.ToInt();
                otf.tasaMoneda = oDropDownManager.GetParameter("PARAMETER_KEY_TASA_MONEDA").Value.ToInt();
                otf.codramo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();
                otf.objQuotation = quotation;
            }

            return otf;
        }

        public JsonResult getMaximoReaseguroSubRamo_New(int SecuenciaVehicleSysflex, decimal quotationCoreNumber, string make, string model, string year)
        {
            int cod_company = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();

            string message = "";
            bool IsFacultative = false;
            decimal AmountFacultative = 0;

            var result = oCoreProxy.GetReinsuranceByItemVehicle(cod_company, quotationCoreNumber, SecuenciaVehicleSysflex);

            if (result.Count() > 0 && result.FirstOrDefault() != null)
            {
                if (result.FirstOrDefault().ValorFacultativo > 0)
                {
                    IsFacultative = true;
                    AmountFacultative = result.FirstOrDefault().ValorFacultativo.GetValueOrDefault();

                    var messageParam = oDropDownManager.GetParameter("PARAMETER_KEY_MESSAGE_REINSURANCE").Value;
                    message = string.Format(messageParam, make, model, year);
                }
            }

            return Json(new { IsFacultative = IsFacultative, message = message, AmountFacultative = AmountFacultative }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteVehicleOnSysflex(int SecuenciaVehicleSysflex, decimal quotationCoreNumber, int vehicleID = 0)
        {
            try
            {
                int cod_company = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();

                //borrando en sysflex
                oCoreProxy.DeleteVehicleOnSysflex(cod_company, SecuenciaVehicleSysflex, quotationCoreNumber);

                //borrando en possite
                oVehicleProductManager.DeleteVehicleProductCoveragesServices(vehicleID, true);

                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error al BORRAR el vehiculo en sysflex/Punto de venta.", "Detalle: Cotizacion id Sysflex: " + quotationCoreNumber + " MENSAJE: " + ex.Message + " StackTrace: " + ex.StackTrace, ex);
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        // GET: Home

        private void getDataIndex()
        {
            string textMode = "";

            if (ConfigurationManager.AppSettings["PARAMETER_KEY_SET_MODE_LEY"] == "1")
            {
                textMode = "COTIZADOR VEHÍCULO LEY";
            }
            else if (ConfigurationManager.AppSettings["PARAMETER_KEY_SET_MODE_FULL"] == "1")
            {
                textMode = "COTIZADOR VEHÍCULO FULL";
            }
            else
            {
                textMode = "COTIZADOR";
            }

            ViewBag.TitlePage = textMode;
            ViewBag.VehicleAvailableYearsList = GetVehicleAvailableYearsList();
            ViewBag.VehiclebrandsList = getVehiclesBrands();
            ViewBag.Sexes = getSexes("");
            ViewBag.ForeingLicence = getForeingLicence("");
        }

        public ActionResult Index(string id = "", string m = "")
        {
            var z = DateTime.Now.Ticks.ToString();

            base.RequestType = CommonEnums.RequestType.Emision;

            IsAQuotation = true;

            string decripted = "";
            try
            {
                decripted = Utility.Decode(id.Replace("%3d", "="));
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { msg = "nf", id = "" });
            }

            QuotationId = decripted.ToInt();

            //QuotationId = Request.QueryString["id"].ToInt();

            var usuario = GetCurrentUsuario();

            var onlyLoggedUsers = allowOnlyLoggedUsers();
            if (onlyLoggedUsers == false)
            {
                ViewBag.IsCustomer = "true";
            }
            else
                ViewBag.IsCustomer = "false";

            if (usuario == null && onlyLoggedUsers)
            {
                var urlLogin = System.Web.Configuration.WebConfigurationManager.AppSettings["SecurityLogin"].ToString();

                Session.RemoveAll();

                return Redirect(urlLogin);
            }

            ViewBag.userCanApplySurCharge = usuario != null ? usuario.CanApplySurcharge ? "S" : "N" : "N";

            isNotLawProduct = false;

            getDataIndex();

            ViewBag.ListCountries = getCountries(129);

            ViewBag.onlyLoggedUsers = onlyLoggedUsers;

            return View(new QuotationViewModel());
        }

        public ActionResult MainForm(int Id)
        {
            this.QuotationId = Id;
            getDataIndex();
            return PartialView(new QuotationViewModel());
        }

        [HttpPost]
        public JsonResult SaveClientInfoBasic(string jsondata)
        {
            int quotationID = 0;
            var agentNameId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_NAME").Value;
            try
            {
                var form = JsonConvert.DeserializeObject<dynamic>(jsondata);

                quotationID = form.quotationID;

                var usuario = GetCurrentUsuario();
                Entity.Entities.WSEntities.AgentTreeInfoNewWS agent = null;

                if (form.agentSelected != null)
                {
                    agent = JsonConvert.DeserializeObject<Entity.Entities.WSEntities.AgentTreeInfoNewWS>(form.agentSelected.ToString());
                }

                bool isNewQuotation = quotationID == 0;
                var currDate = DateTime.Now;

                string Mask = oDropDownManager.GetParameter("PARAMETER_KEY_CREDIT_CARD_MASK").Value;
                string strCreditCardNumber = string.Empty;
                string msgValidationCreditCard = string.Empty;
                bool IsFinanced = false;

                #region Insertando Cotizacion en Pos_site
                Quotation.parameter param = new Quotation.parameter();
                param.id = quotationID;

                if (isNewQuotation)
                {
                    param.productNumber = "01";
                    param.businessLine_Id = 1;
                    param.cardnetPaymentStatus = CommonEnums.QuotationCardnetStatus.NotSent.ToInt();
                    isNewQuotation = true;

                    param.quotationDailyNumber = GetNewDailyQuotationNumber();
                    param.quotationNumber = param.productNumber + DateTime.Now.ToString("yyyyMMdd") + param.quotationDailyNumber.ToString().PadLeft(4, '0');

                    param.startDate = DateTime.Now.Date;
                    param.endDate = DateTime.Now.AddYears(1).Date;
                }
                else
                {
                    string startDate = form.StartDate;
                    string endDate = form.EndDate;
                    DateTime newDate = DateTime.Parse(startDate, CultureInfo.InvariantCulture);
                    if (newDate.TimeOfDay.TotalHours > 0)
                    {
                        param.startDate = newDate.Date;
                    }
                    else
                    {
                        param.startDate = newDate.Date;
                    }

                    DateTime newDateEnd = DateTime.Parse(endDate, CultureInfo.InvariantCulture);
                    if (newDateEnd.TimeOfDay.TotalHours <= 0)
                    {
                        param.endDate = newDateEnd.Date;
                    }
                    else
                    {
                        param.endDate = newDateEnd.Date;
                    }

                    if (param.startDate.Value.Date < DateTime.Now.Date)
                    {
                        throw new Exception("La Fecha Inicio de Vigencia no puede ser menor a la Fecha Actual.");
                    }

                    if (param.endDate.Value.Date < DateTime.Now.Date)
                    {
                        throw new Exception("La Fecha Fin de Vigencia no puede ser menor a la Fecha Actual.");
                    }
                }

                param.lastStepVisited = 1;

                if (isNewQuotation)
                {
                    param.paymentFrequencyId = null;
                    param.paymentFrequency = "N/A";
                    param.paymentWay = null;

                    param.currency_Id = 1;
                    param.currencySymbol = "RD$";

                    param.achAccountHolderGovId = null;
                    param.achBankRoutingNumber = null;
                    param.achName = string.Empty;
                    param.achNumber = null;
                    param.achType = 0;

                    param.iSCPercentage = 0;
                    param.discountPercentage = 0;
                    param.amountToPayEnteredByUser = 0;
                    param.sendInspectionOnly = false;
                    param.declined = false;
                    param.messaging = false;

                    param.financed = IsFinanced;
                    param.monthlyPayment = null;
                    param.period = null;
                    param.credit_Card_Type_Id = 0;
                    param.credit_Card_Number_Key = null;
                    param.credit_Card_Number = null;

                    param.expiration_Date_Year = 0;
                    param.expiration_Date_Month = 0;
                    param.card_Holder = null;
                    param.domiciliation = false;

                    param.quotationProduct = "";
                    param.discountPercentage = 0;
                    param.totalISC = 0;
                    param.totalPrime = 0;
                    param.totalDiscount = 0;

                    param.flotillaDiscountPercent = 0;
                    param.totalFlotillaDiscount = 0;
                }

                #region Usuarios Datos
                if (usuario == null)
                {
                    if (isNewQuotation)
                    {
                        param.user_Id = CheckUser(agentNameId, null, null, null);
                    }
                    else
                    {
                        var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                        if (us > 0)
                        {
                            param.user_Id = us;
                        }
                        else
                        {
                            param.user_Id = CheckUser(agentNameId, null, null, null);
                        }
                    }
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                {
                    if (agent != null)
                        param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                    else
                    {
                        var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                        if (us > 0)
                        {
                            param.user_Id = us;
                        }
                        else
                        {
                            param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                        }
                    }
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User)
                {
                    param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                }
                else //Agent
                {
                    if (agent != null)
                    {
                        param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                    }
                    else
                    {
                        var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                        if (us > 0)
                        {
                            param.user_Id = us;
                        }
                        else
                        {
                            param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email, usuario.AgentId);
                        }
                    }
                }
                #endregion

                int qtyDayOfVigency = Utility.QuantityOfDays(param.startDate.Value, param.endDate.Value);
                param.qtyDayOfVigency = qtyDayOfVigency == 0 ? 365 : qtyDayOfVigency;// 365;

                param.status = 0;
                param.lastStepVisited = 1;
                param.modi_UserId = GetCurrentUserID();
                param.RequestTypeId = CommonEnums.RequestType.Emision.ToInt();
                param.isExternal = false;

                param.couponCode = !string.IsNullOrEmpty(form.couponCode.ToString()) ? form.couponCode : "";
                param.couponPercentageDiscount = !string.IsNullOrEmpty(form.couponPercentageDiscount.ToString()) ? form.couponPercentageDiscount : 0;
                param.CouponProspectId = !string.IsNullOrEmpty(form.couponProspectId.ToString()) ? form.couponProspectId : null;

                if (!string.IsNullOrEmpty(form.contactFormId.ToString()))
                {
                    param.contactFormId = form.contactFormId;
                }
                else
                {
                    param.contactFormId = 0;
                }

                if (!string.IsNullOrEmpty(base.RiskLevel))
                    param.RiskLevel = base.RiskLevel;

                var quotSaved = oQuotationManager.SetQuotation(param);
                quotationID = quotSaved.EntityId;
                var currentQuotationSaved = oQuotationManager.GetQuotation(quotationID);

                #endregion

                #region Person/Driver

                Person.PersonParameters pers = new Person.PersonParameters();
                pers.id = form.driver > 0 ? form.driver : (int?)null;
                pers.isPrincipal = true;

                pers.firstName = form.FirstName;
                pers.firstSurname = form.FirstSurname;
                pers.sex = form.Sex;
                pers.foreignLicense = form.ForeignLicense == "Si" ? true : false;

                string identf = !string.IsNullOrEmpty(form.IdentificationType.ToString()) ? form.IdentificationType : "";

                if (!string.IsNullOrEmpty(form.DateOfBirth.ToString()) && identf != "RNC")
                {
                    pers.dateOfBirth = Convert.ToDateTime(form.DateOfBirth.ToString(), CultureInfo.InvariantCulture);
                }
                else
                {
                    pers.dateOfBirth = new DateTime(1753, 01, 01);//FEcha por default cuando sea rnc que podria venir vacio
                }
                pers.identificationType = identf;

                string[] ident = new string[] { "Cédula", "Licencia", "RNC" };

                if (!string.IsNullOrEmpty(form.IdentificationNumber.ToString()) && ident.Contains(identf))
                {
                    pers.identificationNumber = form.IdentificationNumber.ToString().Replace("-", "");
                }
                else
                {
                    pers.identificationNumber = form.IdentificationNumber;
                }

                pers.mobile = form.PhoneNumber;
                pers.email = form.Email;

                /*Poner la ciudad por default*/
                var city = oDropDownManager.GetDropDown(CommonEnums.DropDownType.DEFAULTCITY.ToString()).FirstOrDefault(); //oDropDownManager.GetCities(129, 817, null).FirstOrDefault();
                var keyCity = city.Value.Split('-');
                if (keyCity.Count() > 2)
                {
                    pers.country_Id = 129;
                    pers.domesticreg_Id = keyCity[0].ToInt();
                    pers.state_Prov_Id = keyCity[1].ToInt();
                    pers.city_Id = keyCity[3].ToInt();
                }

                pers.userId = GetCurrentUserID();
                var personSaved = oPersonManagerManager.SetPerson(pers);

                Driver.parameters dri = new Driver.parameters();
                dri.accidentsLast3Years = null;
                dri.yearsDriving = null;
                dri.userId = GetCurrentUserID();
                dri.quotationId = quotSaved.EntityId;
                dri.id = personSaved.EntityId;
                var driverSaved = oDriverManager.SetDriver(dri);

                var currentDriverSaved = oQuotationManager.GetQuotationDrivers(currentQuotationSaved.Id.GetValueOrDefault());
                Driver PrincipalDriver = new Driver();
                if (currentDriverSaved != null)
                {
                    PrincipalDriver = currentDriverSaved.FirstOrDefault(x => x.IsPrincipal);
                }

                #endregion

                #region Insertando Cotizacion en Sysflex

                var codMonedaVO = oDropDownManager.GetParameter("PARAMETER_KEY_COD_MONEDA").Value.ToInt();
                var codMoneda = oDropDownManager.GetParameter("PARAMETER_KEY_COD_MONEDA_SYSFLEX").Value.ToInt();
                var tasaMoneda = oDropDownManager.GetParameter("PARAMETER_KEY_TASA_MONEDA").Value.ToInt();
                var idOficina = oDropDownManager.GetParameter("PARAMETER_KEY_COD_OFICINA").Value.ToInt();
                var idOficinaVO = oDropDownManager.GetParameter("PARAMETER_KEY_COD_OFICINA_VO").Value.ToInt();
                var agentId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_ID").Value.ToInt();
                var servicesRetryAmount = oDropDownManager.GetParameter("PARAMETER_KEY_SERVICES_RETRY_AMOUNT").Value.ToInt();
                string messageError;
                var codramo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();

                var quotationUser = agent != null ? getQuotationUser(agent.NameId) : null;

                int agentCode = -1;
                if (quotationID > 0 && quotationUser != null && quotationUser.AgentId > 0)
                {
                    var userAgenCode = getAgenteUserInfo((quotationUser.AgentId.HasValue ? quotationUser.AgentId.Value : 0));
                    if (userAgenCode != null)
                    {
                        if (userAgenCode.AgentId <= 0)
                        {
                            userAgenCode = getAgenteUserInfo(quotationUser.Username);//que es el nameid
                        }

                        int.TryParse(userAgenCode.AgentCode, out agentCode);
                    }
                }

                if (agentCode <= 0)
                {
                    agentCode = oDropDownManager.GetParameter("PARAMETER_KEY_COD_INTERMEDIARIO").Value.ToInt();
                }

                if (usuario != null && usuario.UserType != Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User) //Agent or Suscriptor
                {
                    if (quotationID > 0 && quotationUser != null && quotationUser.AgentId > 0)
                    {
                        var userAgentOffice = getAgenteUserInfo((quotationUser.AgentId.HasValue ? quotationUser.AgentId.Value : 0));
                        if (userAgentOffice != null)
                        {
                            if (userAgentOffice.AgentId <= 0)
                            {
                                userAgentOffice = getAgenteUserInfo(quotationUser.Username);//que es el nameid
                            }

                            var OfficeId = 13;
                            //idOficinaVO = userAgentOffice.AgentOffices != null ? userAgentOffice.AgentOffices.FirstOrDefault().OfficeId : idOficinaVO;
                            foreach (var item in userAgentOffice.AgentOffices)
                            {
                                idOficinaVO = item.OfficeId;
                                continue;
                            }

                            var dataMatch = GetOfficeMatch(idOficinaVO);

                            if (dataMatch != null && dataMatch.OfficeIdSysFlex.GetValueOrDefault() > 0)
                                OfficeId = dataMatch.OfficeIdSysFlex.GetValueOrDefault();

                            idOficina = OfficeId;
                        }
                    }
                    else
                        idOficina = idOficinaVO = usuario.AgentOffices.First().OfficeId;
                }
                else if (usuario == null)
                {
                    if (quotationID > 0 && quotationUser != null && quotationUser.AgentId > 0)
                    {
                        var userAgentOffice = getAgenteUserInfo((quotationUser.AgentId.HasValue ? quotationUser.AgentId.Value : 0));
                        if (userAgentOffice != null)
                        {
                            if (userAgentOffice.AgentId <= 0)
                            {
                                userAgentOffice = getAgenteUserInfo(quotationUser.Username);//que es el nameid
                            }
                            var OfficeId = 13;
                            //idOficinaVO = userAgentOffice.AgentOffices != null ? userAgentOffice.AgentOffices.FirstOrDefault().OfficeId : idOficinaVO;                            
                            foreach (var item in userAgentOffice.AgentOffices)
                            {
                                idOficinaVO = item.OfficeId;
                                continue;
                            }

                            var dataMatch = GetOfficeMatch(idOficinaVO);
                            if (dataMatch != null && dataMatch.OfficeIdSysFlex.GetValueOrDefault() > 0)
                                OfficeId = dataMatch.OfficeIdSysFlex.GetValueOrDefault();

                            idOficina = OfficeId;
                        }
                    }
                }


                decimal flotillaPercent = param.flotillaDiscountPercent.GetValueOrDefault();
                int DESCUENTO_FLOTILLA_ID = oDropDownManager.GetParameter("PARAMETER_KEY_DESCUENTO_FLOTILLA_ID_SYSFLEX").Value.ToInt();

                decimal prontoPagoPercent = param.discountPercentage.GetValueOrDefault();
                int PRONTO_PAGO_ID = oDropDownManager.GetParameter("PARAMETER_KEY_PRONTO_PAGO_ID_SYSFLEX").Value.ToInt();

                int cod_COMPANY = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();
                string Sistema = oDropDownManager.GetParameter("PARAMETER_KEY_SYSTEMA").Value;

                string NoCotizacionCore = "0";


                if (string.IsNullOrEmpty(currentQuotationSaved.QuotationCoreNumber))
                {
                    NoCotizacionCore = GetQuotationCoreNumber(quotationID);
                }
                else
                {
                    NoCotizacionCore = currentQuotationSaved.QuotationCoreNumber;
                }


                if (string.IsNullOrEmpty(NoCotizacionCore) || NoCotizacionCore == "0")
                {
                    NoCotizacionCore = oCoreProxy.SetAutoQuotationHeaderForGetCoreQuotationNumber_NewPV(currentQuotationSaved, PrincipalDriver, codMoneda, tasaMoneda, agentCode, idOficina, codramo,
                        servicesRetryAmount, "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : ""), cod_COMPANY, flotillaPercent, DESCUENTO_FLOTILLA_ID, prontoPagoPercent, PRONTO_PAGO_ID, null, Sistema, out messageError);

                    if (!string.IsNullOrEmpty(messageError))
                    {
                        System.ArgumentException argEx = new System.ArgumentException("Error al crear la Cotizacion", messageError);
                        LoggerHelper.Log(CommonEnums.Categories.Error, "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "VentaDirecta"), -1, "Error al guardar nueva cotización", "Mensaje: " + messageError, argEx);
                        throw argEx;
                    }
                }
                #endregion

                #region Actualizando Cotizacion con los datos de sysflex

                Quotation.parameter UpdParam = new Quotation.parameter();
                UpdParam.id = currentQuotationSaved.Id;

                UpdParam.principalFullName = PrincipalDriver.FirstName.Trim() + (!string.IsNullOrEmpty(PrincipalDriver.FirstSurname) ? " " + PrincipalDriver.FirstSurname.Trim() : "");
                UpdParam.principalIdentificationNumber = PrincipalDriver.IdentificationNumber;

                UpdParam.quotationCoreNumber = NoCotizacionCore;

                UpdParam.modi_UserId = GetCurrentUserID();

                //set risklevel
                if (!string.IsNullOrEmpty(base.RiskLevel))
                    UpdParam.RiskLevel = base.RiskLevel;

                oQuotationManager.SetQuotation(UpdParam);

                #endregion


                #region Datos de los referidos

                Quotation.QuotationReferred quotationReferred = new Quotation.QuotationReferred();
                int? ReferredId = form.ReferredId.ToString() == "0" ? null : Convert.ToInt32(form.ReferredId.ToString());
                bool validToSave = false;

                //Revisando si existe un referido para entonces actualizarlo.

                var referred = oQuotationManager.GetQuotationReferred(quotationID, ReferredId);
                if (referred != null)
                {
                    ReferredId = referred.ReferredId;
                }

                //

                if (form.contactFormId.ToString() == "5")//Recomendacion de alguien
                {
                    quotationReferred.ReferredId = ReferredId;
                    quotationReferred.QuotationId = quotationID;
                    quotationReferred.ReferredName = form.ReferredName.ToString();
                    quotationReferred.ReferredIdentificationNumber = form.ReferredIdentificationNumber.ToString();
                    quotationReferred.ReferredPhone = form.ReferredPhone.ToString();
                    quotationReferred.ReferredEmail = form.ReferredEmail.ToString();
                    quotationReferred.ReferredPolicy = form.ReferredPolicy.ToString();

                    if (!string.IsNullOrEmpty(quotationReferred.ReferredName) ||
                       !string.IsNullOrEmpty(quotationReferred.ReferredPolicy) ||
                       !string.IsNullOrEmpty(quotationReferred.ReferredIdentificationNumber) ||
                       !string.IsNullOrEmpty(quotationReferred.ReferredPhone) ||
                       !string.IsNullOrEmpty(quotationReferred.ReferredEmail))
                    {
                        validToSave = true;
                    }

                    if (validToSave)
                    {
                        oQuotationManager.SetQuotationReferred(quotationReferred);
                    }
                }
                else if (form.contactFormId.ToString() != "5" && ReferredId.HasValue)
                {
                    //Si cambian de via de promocion a cualquiera que sea diferente a Recomendacion de alguien (5) eliminiar ese referido

                    oQuotationManager.DeleteQuotationReferred(quotationID);

                    //
                }
                #endregion



                ViewBag.QuotationID = currentQuotationSaved.Id;
                ViewBag.QuotationNumber = currentQuotationSaved.QuotationNumber;
                ViewBag.QuotationCoreNumber = currentQuotationSaved.QuotationCoreNumber;

                QuotationNumber = currentQuotationSaved.QuotationNumber;
                QuotationId = currentQuotationSaved.Id.Value;
            }
            catch (Exception ex)
            {
                var user = GetCurrentUsuario();

                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, "POS-" + (user != null ? user.UserLogin : "VentaDirecta"), quotationID, "Error al guardar nueva cotización", "Mensaje: " + ex.Message, ex);

                //devolmeos un mensaje de error
                return Json(new { messageError = "Error al guardar nueva cotización" }, JsonRequestBehavior.AllowGet);
            }

            string quotationIdEncript = Utility.Encode(QuotationId.ToString());

            return Json(new { MessageSucess = "", QuotationId = ViewBag.QuotationID, QuotationNumber = ViewBag.QuotationNumber, showNextSection = true, quotationIdEncript = quotationIdEncript }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveDataVehicle(string jsondata, bool requoting = false, string saveOnlyVh = "N")
        {
            int quotationID = 0;
            string appMode = "";
            int? contactFormId = null;
            List<object> matchDinamicVehicleWithCreated = new List<object>();
            string dic = "";
            try
            {
                var updatedVehicles = JsonConvert.DeserializeObject<List<dynamic>>(jsondata);
                var newVehicles = updatedVehicles.Where(u => u.randomId <= 0);
                bool first = true;
                decimal percentISC = 16;
                string principalIdentificationNumber = "";
                string principalFullName = "";

                decimal PercentByQtyVehicle = 0;
                decimal TotalByQtyVehicle = 0;

                var realVehicleQty = newVehicles.Select(x => (int)x.VehicleQuantity).Cast<int>().ToList();
                var realVehicleQty_Sum = realVehicleQty.Sum();

                var tp = newVehicles.Select(x => (decimal)x.TotalPrime * (decimal)x.VehicleQuantity).Cast<decimal>().ToList();
                decimal totalVehiclesPrime = tp.Sum();

                List<bool> allLawProdcts = new List<bool>();

                appMode = newVehicles.Select(x => (string)x.appMode).Cast<string>().FirstOrDefault();

                if (!string.IsNullOrEmpty(newVehicles.FirstOrDefault().contactFormId.ToString()))
                {
                    contactFormId = newVehicles.Select(x => (int?)x.contactFormId).Cast<int?>().FirstOrDefault();
                }

                foreach (var vehicle in newVehicles)
                {
                    quotationID = vehicle.Quotation_Id;
                    var usuario = GetCurrentUsuario();
                    Entity.Entities.WSEntities.AgentTreeInfoNewWS agent = null;

                    if (vehicle.agentSelected != null)
                    {
                        agent = JsonConvert.DeserializeObject<Entity.Entities.WSEntities.AgentTreeInfoNewWS>(vehicle.agentSelected.ToString());
                    }

                    Quotation.parameter param = new Quotation.parameter();

                    if (first)
                    {
                        #region Insertando Cotizacion en Pos_site
                        param.id = quotationID;

                        string startDate = vehicle.startDate;
                        string endDate = vehicle.endDate;
                        DateTime newDate = DateTime.Parse(startDate, CultureInfo.InvariantCulture);
                        if (newDate.TimeOfDay.TotalHours > 0)
                        {
                            param.startDate = newDate.Date;
                        }
                        else
                        {
                            param.startDate = newDate.Date;
                        }

                        DateTime newDateEnd = DateTime.Parse(endDate, CultureInfo.InvariantCulture);
                        if (newDateEnd.TimeOfDay.TotalHours <= 0)
                        {
                            param.endDate = newDateEnd.Date;
                        }
                        else
                        {
                            param.endDate = newDateEnd.Date;
                        }

                        if (param.startDate.Value.Date < DateTime.Now.Date)
                        {
                            throw new Exception("La Fecha Inicio de Vigencia no puede ser menor a la Fecha Actual.");
                        }

                        if (param.endDate.Value.Date < DateTime.Now.Date)
                        {
                            throw new Exception("La Fecha Fin de Vigencia no puede ser menor a la Fecha Actual.");
                        }

                        param.iSCPercentage = vehicle.porcImpuesto;
                        percentISC = vehicle.porcImpuesto;

                        #region asignando usuario a la cotizacion
                        if (usuario == null)
                        {
                            var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                            if (us > 0)
                            {
                                param.user_Id = us;
                            }
                            else
                            {
                                var agentNameId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_NAME").Value;
                                param.user_Id = CheckUser(agentNameId, null, null, null);
                            }
                        }
                        else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                        {
                            if (agent != null)
                                param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                            else
                            {
                                var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                                if (us > 0)
                                {
                                    param.user_Id = us;
                                }
                                else
                                {
                                    param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                                }
                            }
                        }
                        else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User)
                        {
                            param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                        }
                        else //Agent
                        {
                            if (agent != null)
                            {
                                param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                            }
                            else
                            {
                                var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                                if (us > 0)
                                {
                                    param.user_Id = us;
                                }
                                else
                                {
                                    param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email, usuario.AgentId);
                                }
                            }
                        }
                        #endregion

                        int qtyDayOfVigency = Utility.QuantityOfDays(param.startDate.Value, param.endDate.Value);
                        param.qtyDayOfVigency = qtyDayOfVigency == 0 ? 365 : qtyDayOfVigency;// 365;

                        var getquo2 = oQuotationManager.GetQuotation(quotationID);
                        if (getquo2 != null)
                        {
                            param.monthlyPayment = getquo2.MonthlyPayment;
                            param.financed = getquo2.Financed;
                            param.period = getquo2.Period;

                            if (!string.IsNullOrEmpty(base.RiskLevel))
                                param.RiskLevel = base.RiskLevel;
                        }

                        param.status = 0;
                        param.lastStepVisited = 1;
                        param.modi_UserId = GetCurrentUserID();

                        param.couponCode = !string.IsNullOrEmpty(vehicle.couponCode.ToString()) ? vehicle.couponCode : "";
                        param.couponPercentageDiscount = !string.IsNullOrEmpty(vehicle.couponPercentageDiscount.ToString()) ? vehicle.couponPercentageDiscount : 0;
                        param.CouponProspectId = !string.IsNullOrEmpty(vehicle.couponProspectId.ToString()) ? vehicle.couponProspectId : null;

                        var quotSaved = oQuotationManager.SetQuotation(param);

                        #endregion

                        if (requoting == false && appMode != "LEYMODE")
                        {
                            #region Person/Driver

                            Person.PersonParameters pers = new Person.PersonParameters();
                            pers.id = vehicle.Driver_Id;

                            pers.firstName = vehicle.drivername;
                            pers.firstSurname = vehicle.driversurname;
                            pers.sex = vehicle.driversex;
                            pers.foreignLicense = vehicle.driverforeignlicense == "Si" ? true : false;

                            string identf = vehicle.driveridentificationtype != null ? vehicle.driveridentificationtype : "";

                            if (!string.IsNullOrEmpty(vehicle.driverdob.ToString()) && identf != "RNC")
                            {
                                pers.dateOfBirth = Convert.ToDateTime(vehicle.driverdob.ToString(), CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                pers.dateOfBirth = new DateTime(1753, 01, 01);//FEcha por default cuando sea rnc que podria venir vacio
                            }
                            pers.identificationType = identf;

                            string[] ident = new string[] { "Cédula", "Licencia", "RNC" };

                            if (vehicle.driveridentificationtype != null && ident.Contains(identf))
                            {
                                pers.identificationNumber = vehicle.driveridentificationNumber.ToString().Replace("-", "");
                            }
                            else
                            {
                                pers.identificationNumber = vehicle.driveridentificationNumber;
                            }
                            principalFullName = pers.firstName + " " + pers.firstSurname;
                            principalIdentificationNumber = pers.identificationNumber;

                            pers.phoneNumber = vehicle.driverphonenumber;
                            pers.email = vehicle.driveremail;
                            pers.userId = GetCurrentUserID();

                            var personSaved = oPersonManagerManager.SetPerson(pers);

                            #endregion
                        }
                        first = false;
                    }

                    #region Vehicle

                    VehicleProduct.Parameter vparam = new VehicleProduct.Parameter();
                    vparam.id = vehicle.Id != null ? vehicle.Id : null;
                    vparam.vehicleDescription = vehicle.VehicleDescription;
                    vparam.year = vehicle.Year;
                    vparam.vehiclePrice = vehicle.VehiclePrice;
                    vparam.insuredAmount = vehicle.InsuredAmount;
                    vparam.percentageToInsure = vehicle.PercentageToInsure;
                    vparam.totalPrime = vehicle.TotalPrime;
                    vparam.totalIsc = vehicle.TotalIsc;
                    vparam.totalDiscount = 0;
                    vparam.selectedProductCoreId = vehicle.SelectedProductCoreId;
                    var vtCore = oDropDownManager.GetVehicleTypes((int?)vehicle.VehicleModel_Make_Id, (int?)vehicle.VehicleModel_Model_Id).FirstOrDefault();
                    if (vtCore != null)
                    {
                        vparam.vehicleTypeCoreId = vtCore.CoreVehicleTypeId;
                        vparam.vehicleTypeName = vtCore.VehicleTypeDesc;
                    }
                    vparam.selectedProductName = vehicle.SelectedProductName;
                    vparam.vehicleMakeName = vehicle.VehicleMakeName;
                    vparam.usageId = vehicle.UsageId;
                    vparam.usageName = vehicle.UsageName;
                    vparam.storeId = vehicle.StoreId;
                    vparam.storeName = vehicle.StoreName;
                    vparam.driver_Id = vehicle.Driver_Id;
                    vparam.vehicleModel_Make_Id = vehicle.VehicleModel_Make_Id;
                    vparam.vehicleModel_Model_Id = vehicle.VehicleModel_Model_Id;
                    vparam.quotation_Id = quotationID;
                    vparam.selectedVehicleTypeId = vehicle.SelectedVehicleTypeId;
                    vparam.selectedVehicleTypeName = vehicle.SelectedVehicleTypeName;
                    vparam.selectedCoverageCoreId = vehicle.SelectedCoverageCoreId;
                    vparam.selectedCoverageName = vehicle.SelectedCoverageName;
                    vparam.vehicleYearOld = vehicle.VehicleYearOld;
                    vparam.surChargePercentage = (vehicle.SurChargePercentage == 0) ? 0 : vehicle.SurChargePercentage;
                    vparam.numeroFormulario = null;
                    vparam.rateJson = vehicle.RateJson;
                    vparam.userId = GetCurrentUserID();
                    vparam.secuenciaVehicleSysflex = vehicle.SecuenciaVehicleSysflex;
                    vparam.isFacultative = vehicle.IsFacultative;
                    vparam.amountFacultative = vehicle.AmountFacultative;
                    vparam.vehicleQuantity = vehicle.VehicleQuantity;
                    vparam.ProratedPremium = 0;
                    vparam.SelectedVehicleFuelTypeId = vehicle.SelectedVehicleFuelTypeId;
                    vparam.SelectedVehicleFuelTypeDesc = vehicle.SelectedVehicleFuelTypeDesc;
                    //Llamar el metodo que guarda o modifica los datos del vehiculo          
                    var vehicleSaved = oVehicleProductManager.SetVehicleProduct(vparam);

                    var currentVehicleID = vehicleSaved.EntityId;

                    var isLawProduct = vehicle.isLawProduct == false ? true : false;

                    allLawProdcts.Add(isLawProduct);

                    #region ProductsLimits
                    var json = JsonConvert.SerializeObject(vehicle.GlobalDataProductLimits);
                    if (json != "null")
                    {
                        ProductLimits productLimitSet = JsonConvert.DeserializeObject<ProductLimits>(json);
                        productLimitSet.TotalIsc = vehicle.TotalIsc;
                        productLimitSet.TotalDiscount = vehicle.TotalDiscount;
                        productLimitSet.TotalPrime = vehicle.TotalPrime;

                        //Mark this productlimitset as the one selected by the user
                        productLimitSet.IsSelected = true;
                        if (vehicle.selectedDeductible.ToString() != "")
                        {
                            productLimitSet.SelectedDeductibleCoreId = vehicle.selectedDeductible;
                            json = JsonConvert.SerializeObject(vehicle.GlobalDataDeductibleList);
                            List<Entity.Entities.WSEntities.DeductibleValues> deductibleList = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.DeductibleValues>>(json);

                            Entity.Entities.WSEntities.DeductibleValues deductible = deductibleList.FirstOrDefault(d => d.CoreId == productLimitSet.SelectedDeductibleCoreId);
                            productLimitSet.SelectedDeductibleName = deductible != null ? deductible.Name : null;
                        }

                        //Borrado masivo de coverturas y productlimits
                        oVehicleProductManager.DeleteVehicleProductCoveragesServices(currentVehicleID, false);
                        //

                        ProductLimits.Parameter prodParam = new ProductLimits.Parameter();
                        prodParam.id = null;
                        prodParam.vehicleProduct_Id = currentVehicleID;
                        prodParam.isSelected = productLimitSet.IsSelected;
                        prodParam.totalIsc = productLimitSet.TotalIsc;
                        prodParam.totalDiscount = productLimitSet.TotalDiscount;
                        prodParam.totalPrime = productLimitSet.TotalPrime;
                        prodParam.servicesPrime = productLimitSet.ServicesPrime;
                        prodParam.tpPrime = productLimitSet.TpPrime;
                        prodParam.sdPrime = productLimitSet.SdPrime;
                        prodParam.selectedDeductibleCoreId = productLimitSet.SelectedDeductibleCoreId;
                        prodParam.selectedDeductibleName = productLimitSet.SelectedDeductibleName;
                        prodParam.userId = GetCurrentUserID();
                        var productLimitSaved = oProductLimitsManager.SetProudctLimits(prodParam);
                        var currentProductLimit = productLimitSaved.EntityId;

                        STL.POS.WsProxy.SysflexService.PolicySysFlexGetPrimaCoberturaKey parm = new STL.POS.WsProxy.SysflexService.PolicySysFlexGetPrimaCoberturaKey();
                        parm.Cotizacion = vehicle.quotationCoreNumber;//.ToString().ToDecimal();
                        parm.Secuencia = vehicle.SecuenciaVehicleSysflex;
                        var primacobertura = oCoreProxy.GetPrimaCobertura(parm);

                        #region Services

                        List<string> headers = new List<string>();
                        BaseEntity serviceTypeSaved = new BaseEntity();


                        var jsonST = JsonConvert.SerializeObject(vehicle.GlobalDataProductLimits.ServicesCoverages);
                        List<Entity.Entities.WSEntities.ServiceTypeWS> st = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.ServiceTypeWS>>(jsonST);
                        foreach (var stList in st)
                        {
                            foreach (var sc in stList.Coverages)
                            {
                                if (!headers.Contains(stList.Name))
                                {
                                    ServicesTypes.Parameter stParam = new ServicesTypes.Parameter();
                                    stParam.id = null;
                                    stParam.servicesTypesToProductLimits = currentProductLimit;
                                    stParam.name = stList.Name;
                                    stParam.userId = GetCurrentUserID();
                                    serviceTypeSaved = oServicesTypesRepositoryManager.SetServiceType(stParam);

                                    headers.Add(stList.Name);
                                }

                                var currentServiceType = serviceTypeSaved.EntityId;

                                #region SE Coverages

                                if (sc.IsSelected)
                                {
                                    Coverage.Parameter scParam = new Coverage.Parameter();

                                    if (primacobertura.Count() > 0)
                                    {
                                        var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == sc.CoverageDetailCoreId);
                                        if (realCObert != null)
                                        {
                                            decimal realLimitSer = 0;
                                            string MontoInformativo = realCObert.MontoInformativo.Replace(",", "");
                                            decimal.TryParse(MontoInformativo, out realLimitSer);

                                            scParam.id = null;
                                            scParam.isSelected = sc.IsSelected;
                                            scParam.coverageDetailCoreId = sc.CoverageDetailCoreId;
                                            scParam.name = sc.Name;
                                            //scParam.amount = realCObert.Prima;
                                            //scParam.limit = realCObert.Prima;

                                            scParam.amount = realCObert.Prima;
                                            scParam.limit = realLimitSer;

                                            scParam.minDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                            scParam.deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;
                                            scParam.selfDamagesToProductLimits = null;
                                            scParam.thirdPartyToProductLimits = null;
                                            scParam.serviceType_Id = currentServiceType;
                                            scParam.userId = GetCurrentUserID();

                                            scParam.coveragePercentage = realCObert.PorcientoCobertura;
                                            scParam.baseDeductible = realCObert.BaseDeducible;
                                            scParam.allowsToSummarize = realCObert.PermiteSumarizar;
                                            oCoverageManager.SetCoverageDetail(scParam);
                                        }
                                    }
                                }
                            }
                            #endregion
                        }

                        #endregion

                        #region Self Damage Coverages

                        var jsonSelfDamages = JsonConvert.SerializeObject(vehicle.GlobalDataProductLimits.SelfDamagesCoverages);
                        List<Entity.Entities.WSEntities.CoverageDetailWS> sfd = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.CoverageDetailWS>>(jsonSelfDamages);

                        Coverage.Parameter sdParam = new Coverage.Parameter();

                        if (sfd != null && sfd.Count() > 0)
                        {
                            foreach (var sdc in sfd)
                            {
                                sdParam = new Coverage.Parameter();

                                if (primacobertura.Count() > 0)
                                {
                                    var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == sdc.CoverageDetailCoreId);
                                    if (realCObert != null)
                                    {
                                        decimal realLimit = 0;
                                        string MontoInformativo = realCObert.MontoInformativo.Replace(",", "");
                                        decimal.TryParse(MontoInformativo, out realLimit);
                                        /*sdc.Amount = realLimit;
                                        sdc.Limit = realLimit;
                                        sdc.MinDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                        sdc.Deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;*/

                                        sdParam.id = null;
                                        sdParam.isSelected = false;
                                        sdParam.coverageDetailCoreId = sdc.CoverageDetailCoreId;
                                        sdParam.name = sdc.Name;
                                        sdParam.amount = realLimit;
                                        sdParam.limit = realLimit;
                                        sdParam.minDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                        sdParam.deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;
                                        sdParam.selfDamagesToProductLimits = currentProductLimit;
                                        sdParam.thirdPartyToProductLimits = null;
                                        sdParam.serviceType_Id = null;
                                        sdParam.userId = GetCurrentUserID();

                                        sdParam.coveragePercentage = realCObert.PorcientoCobertura;
                                        sdParam.baseDeductible = realCObert.BaseDeducible;
                                        sdParam.allowsToSummarize = realCObert.PermiteSumarizar;
                                        oCoverageManager.SetCoverageDetail(sdParam);
                                    }
                                }


                            }
                        }

                        #endregion

                        #region Third Party Coverages
                        var jsonThirdParty = JsonConvert.SerializeObject(vehicle.GlobalDataProductLimits.ThirdPartyCoverages);
                        List<Entity.Entities.WSEntities.CoverageDetailWS> tps = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.CoverageDetailWS>>(jsonThirdParty);

                        Coverage.Parameter tpParam = new Coverage.Parameter();

                        if (tps != null && tps.Count() > 0)
                        {
                            foreach (var tpc in tps)
                            {
                                tpParam = new Coverage.Parameter();

                                if (primacobertura.Count() > 0)
                                {
                                    var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == tpc.CoverageDetailCoreId);
                                    if (realCObert != null)
                                    {
                                        decimal realLimit = 0;
                                        string MontoInformativo = realCObert.MontoInformativo.Replace(",", "");
                                        decimal.TryParse(MontoInformativo, out realLimit);
                                        tpc.Amount = realLimit;
                                        tpc.Limit = realLimit;
                                        tpc.MinDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                        tpc.Deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;

                                        tpParam.id = null;
                                        tpParam.isSelected = false;
                                        tpParam.coverageDetailCoreId = tpc.CoverageDetailCoreId;
                                        tpParam.name = tpc.Name;
                                        tpParam.amount = realLimit;
                                        tpParam.limit = realLimit;
                                        tpParam.minDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                        tpParam.deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;
                                        tpParam.selfDamagesToProductLimits = null;
                                        tpParam.thirdPartyToProductLimits = currentProductLimit;
                                        tpParam.serviceType_Id = null;
                                        tpParam.userId = GetCurrentUserID();

                                        tpParam.coveragePercentage = realCObert.PorcientoCobertura;
                                        tpParam.baseDeductible = realCObert.BaseDeducible;
                                        tpParam.allowsToSummarize = realCObert.PermiteSumarizar;
                                        oCoverageManager.SetCoverageDetail(tpParam);
                                    }
                                }
                            }
                        }
                        #endregion

                    }
                    #endregion

                    #endregion
                }

                bool calc = (saveOnlyVh == "S");

                if (calc)
                {
                    var vdata = getVehicleData(quotationID);

                    if (vdata.Count() > 0)
                    {
                        var sumVh = vdata.Select(x => x.TotalPrime * x.VehicleQuantity).ToList();
                        totalVehiclesPrime = sumVh.Sum().GetValueOrDefault();

                        var sumVhQ = vdata.Select(x => x.VehicleQuantity).ToList();
                        realVehicleQty_Sum = sumVhQ.Sum().GetValueOrDefault();

                        PercentByQtyVehicle = getFlotillaPercentByQty(realVehicleQty_Sum);
                    }
                }
                else
                {
                    PercentByQtyVehicle = getFlotillaPercentByQty(realVehicleQty_Sum);
                }

                //Actualizando la cotizacion con los totales de prima
                Quotation.parameter qparam = new Quotation.parameter();
                qparam.id = quotationID;

                qparam.totalISC = (totalVehiclesPrime * (percentISC / 100));
                qparam.totalPrime = totalVehiclesPrime;

                var prod = GetQuotationProduct(quotationID);
                qparam.quotationProduct = prod == "Flotilla" ? "Varios" : prod;

                if (appMode != "LEYMODE")
                {
                    var driverPrin = getDriverData(quotationID).FirstOrDefault(x => x.IsPrincipal);

                    if (driverPrin != null)
                    {
                        qparam.principalFullName = driverPrin.GetFullName();
                        qparam.principalIdentificationNumber = !string.IsNullOrEmpty(driverPrin.IdentificationNumber) ? driverPrin.IdentificationNumber : "";
                    }
                }

                qparam.flotillaDiscountPercent = PercentByQtyVehicle;
                qparam.totalFlotillaDiscount = totalVehiclesPrime * (PercentByQtyVehicle / 100);

                var getquo = oQuotationManager.GetQuotation(quotationID);
                if (getquo != null)
                {
                    qparam.monthlyPayment = getquo.MonthlyPayment;
                    qparam.financed = getquo.Financed;
                    qparam.period = getquo.Period;
                }

                //Si al menos hay un true, entonces no es de ley, porque para ser de ley todo debe ser false
                if (allLawProdcts.Contains(true))
                    qparam.sendInspectionOnly = true;
                else
                    qparam.sendInspectionOnly = false;

                isNotLawProduct = qparam.sendInspectionOnly.GetValueOrDefault();
                qparam.contactFormId = contactFormId;
                qparam.modi_UserId = GetCurrentUserID();

                if (!string.IsNullOrEmpty(base.RiskLevel))
                    qparam.RiskLevel = base.RiskLevel;

                oQuotationManager.SetQuotation(qparam);

                QuotationId = qparam.id.Value;
                QuotationNumber = qparam.quotationNumber;

                var allVehicles = oQuotationManager.GetQuotationVehicles(QuotationId);

                if (calc)
                {
                    var currentSavedVH = newVehicles.FirstOrDefault();
                    string VehicleDescription = currentSavedVH.VehicleDescription.ToString();
                    string SecuenciaVehicleSysflex = currentSavedVH.SecuenciaVehicleSysflex.ToString();

                    int realSecuenciaVehicleSysflex = SecuenciaVehicleSysflex.ToInt();

                    var exist = allVehicles.FirstOrDefault(a => a.VehicleDescription == VehicleDescription && a.SecuenciaVehicleSysflex == realSecuenciaVehicleSysflex);

                    if (exist != null)
                    {
                        dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                        MyDynamic.randomId = Convert.ToInt32(currentSavedVH.randomId);
                        MyDynamic.vehicleID = exist.Id.Value;
                        matchDinamicVehicleWithCreated.Add(MyDynamic);
                    }
                }
                else
                {
                    foreach (var v in allVehicles)
                    {
                        var exist = newVehicles.FirstOrDefault(a => a.VehicleDescription == v.VehicleDescription && a.SecuenciaVehicleSysflex == v.SecuenciaVehicleSysflex);

                        if (exist != null)
                        {
                            dynamic MyDynamic = new System.Dynamic.ExpandoObject(); // note, the type MUST be dynamic to use dynamic invoking.
                            MyDynamic.randomId = Convert.ToInt32(exist.randomId);
                            MyDynamic.vehicleID = v.Id.Value;
                            matchDinamicVehicleWithCreated.Add(MyDynamic);
                        }
                    }
                }

                dic = JsonConvert.SerializeObject(matchDinamicVehicleWithCreated);
                //
            }
            catch (Exception ex)
            {
                var userLogged = GetCurrentUsuario();

                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, (userLogged != null ? userLogged.UserLogin : ""), quotationID, "Error al guardar el/los Vehiculos(s)", "Mensaje: " + ex.Message, ex);

                //devolmeos un mensaje de error
                return Json(new { messageError = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { MessageSucess = "", QuotationId = QuotationId, QuotationNumber = QuotationNumber, showNextSection = true, VehicleDataMatch = dic }, JsonRequestBehavior.AllowGet);
        }

        public Entity.Entities.WSEntities.SendQuotationResultWS SendQuotationToCore(int quotationID, decimal? MinimumAmountToPay = 0)
        {
            //Lo pongo en false para que use la url del servicio que apunta al sysflex donde van las emisiones
            IsAQuotation = false;

            Entity.Entities.WSEntities.SendQuotationResultWS result = new Entity.Entities.WSEntities.SendQuotationResultWS();
            result.CantMovement = true;

            result.resultQuotation = new Quotation();

            Quotation quotation = oQuotationManager.GetQuotation(quotationID);
            string EndorsementBeneficiary = "";

            //Validar que si es una inclusion ver si se puede crear un movimiento
            if (base.RequestType == CommonEnums.RequestType.Inclusion && !base.isNotLawProduct)
            {
                var resultChkMov = oCoreProxy.GetPolicyMov(quotation.policyNoMain);
                if (!resultChkMov.GetValueOrDefault())
                {
                    return new Entity.Entities.WSEntities.SendQuotationResultWS
                    {
                        CantMovement = resultChkMov.GetValueOrDefault(),
                        resultQuotation = null,
                        SentToCore = false,
                        SentToCoreWithErrorGP = false,
                        SentToVO = false
                    };
                }
            }
            else if (base.RequestType == CommonEnums.RequestType.Exclusion)
            {
                var resultChkMov = oCoreProxy.GetPolicyMov(quotation.policyNoMain);
                if (!resultChkMov.GetValueOrDefault())
                {
                    return new Entity.Entities.WSEntities.SendQuotationResultWS
                    {
                        CantMovement = resultChkMov.GetValueOrDefault(),
                        resultQuotation = null,
                        SentToCore = false,
                        SentToCoreWithErrorGP = false,
                        SentToVO = false
                    };
                }
            }


            if (MinimumAmountToPay > 0)
                quotation.AmountToPayEnteredByUser = MinimumAmountToPay;

            //Conductor Principal
            var quoPrincipalDr = oQuotationManager.GetQuotationDrivers(quotation.Id.GetValueOrDefault()).FirstOrDefault(x => x.IsPrincipal);
            //

            //datos vehiculos
            var vehicleCoverages = getVehiclesAndCoverages(quotation.Id.GetValueOrDefault());
            //

            if (base.RequestType == CommonEnums.RequestType.Exclusion)
            {
                var DataCoreVehicle = oCoreProxy.GetVehiculosFromPoliza(quotation.policyNoMain);

                if (DataCoreVehicle.Any())
                {
                    foreach (var v in DataCoreVehicle)
                    {
                        if (v.TieneEndoso.GetValueOrDefault() && vehicleCoverages.Item1.FirstOrDefault(x => x.Chassis == v.chasis) != null)
                        {
                            EndorsementBeneficiary = "Endosatario Exclusion";
                        }
                    }
                }
            }


            var quotationUser = quotation != null ? getQuotationUserById(quotation.User_Id.GetValueOrDefault()) : null;
            var currentUser = GetCurrentUsuario();

            var codMonedaVO = oDropDownManager.GetParameter("PARAMETER_KEY_COD_MONEDA").Value.ToInt();
            var codMoneda = oDropDownManager.GetParameter("PARAMETER_KEY_COD_MONEDA_SYSFLEX").Value.ToInt();
            var tasaMoneda = oDropDownManager.GetParameter("PARAMETER_KEY_TASA_MONEDA").Value.ToInt();
            var codIntermediario = oDropDownManager.GetParameter("PARAMETER_KEY_COD_INTERMEDIARIO").Value.ToInt();
            var idOficina = oDropDownManager.GetParameter("PARAMETER_KEY_COD_OFICINA").Value.ToInt();
            var idOficinaVO = oDropDownManager.GetParameter("PARAMETER_KEY_COD_OFICINA_VO").Value.ToInt();
            var agentNameId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_NAME").Value;
            var agentId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_ID").Value.ToInt();
            var TasaCalc = oDropDownManager.GetParameter("PARAMETER_KEY_PERCENTAGE_ISC").Value.ToInt();
            var servicesRetryAmount = oDropDownManager.GetParameter("PARAMETER_KEY_SERVICES_RETRY_AMOUNT").Value.ToInt();
            string policyId = string.Empty;
            List<string> statusMessages = null;
            string SourceID = "";
            List<ListVehicleSourceID> listVehicleSourceID = new List<ListVehicleSourceID>();
            bool errorGP = false;
            bool errorChasis = false;
            var codramo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();

            int agentCode = -1;
            if (quotation != null && quotationUser != null && quotationUser.AgentId.HasValue)
            {
                var userAgenCode = getAgenteUserInfo(quotationUser.AgentId.Value);
                if (userAgenCode != null)
                {
                    if (userAgenCode.AgentId <= 0)
                    {
                        userAgenCode = getAgenteUserInfo(quotationUser.Username);//que es el nameid
                    }
                    int.TryParse(userAgenCode.AgentCode, out agentCode);
                }
            }

            if (agentCode <= 0)
            {
                agentCode = oDropDownManager.GetParameter("PARAMETER_KEY_COD_INTERMEDIARIO").Value.ToInt();
            }

            var usuario = GetCurrentUsuario();

            if (usuario != null && usuario.UserType != Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User) //Agent or Suscriptor
            {
                if (quotation != null && quotationUser != null && quotationUser.AgentId.HasValue)
                {
                    var userAgentOffice = getAgenteUserInfo(quotationUser.AgentId.Value);
                    if (userAgentOffice != null)
                    {
                        if (userAgentOffice.AgentId <= 0)
                        {
                            userAgentOffice = getAgenteUserInfo(quotationUser.Username);//que es el nameid
                        }

                        var OfficeId = 13;
                        idOficinaVO = userAgentOffice.AgentOffices != null ? userAgentOffice.AgentOffices.FirstOrDefault().OfficeId : idOficinaVO;

                        var dataMatch = GetOfficeMatch(idOficinaVO);

                        if (dataMatch != null && dataMatch.OfficeIdSysFlex.GetValueOrDefault() > 0)
                            OfficeId = dataMatch.OfficeIdSysFlex.GetValueOrDefault();

                        idOficina = OfficeId;
                    }
                }
                else
                    idOficina = idOficinaVO = usuario.AgentOffices.First().OfficeId;
            }
            else if (usuario == null)
            {
                if (quotation != null && quotationUser != null && quotationUser.AgentId.HasValue)
                {
                    var userAgentOffice = getAgenteUserInfo(quotationUser.AgentId.Value);
                    if (userAgentOffice != null)
                    {
                        if (userAgentOffice.AgentId <= 0)
                        {
                            userAgentOffice = getAgenteUserInfo(quotationUser.Username);//que es el nameid
                        }

                        var OfficeId = 13;
                        idOficinaVO = userAgentOffice.AgentOffices != null ? userAgentOffice.AgentOffices.FirstOrDefault().OfficeId : idOficinaVO;

                        var dataMatch = GetOfficeMatch(idOficinaVO);

                        if (dataMatch != null && dataMatch.OfficeIdSysFlex.GetValueOrDefault() > 0)
                            OfficeId = dataMatch.OfficeIdSysFlex.GetValueOrDefault();

                        idOficina = OfficeId;
                    }
                }
            }

            #region Envio a Sysflex

            var genderParam = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_DEFAULT_SEX").Value;
            var ageParam = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_DEFAULT_AGE").Value;
            var useNCFNew = oDropDownManager.GetParameter("PARAMETER_KEY_USE_OR_NOT_NEW_NCF_SYSFLEX").Value;


            if (quotation.SendInspectionOnly.HasValue && !quotation.SendInspectionOnly.Value) //Send quotation to Sysflex, it's a Ley quotation
            {
                string policyNumber = string.Empty;
                decimal quotationCoreId = 0m;
                decimal clientCoreId = 0m;

                decimal flotillaPercent = quotation.FlotillaDiscountPercent.GetValueOrDefault();
                int DESCUENTO_FLOTILLA_ID = oDropDownManager.GetParameter("PARAMETER_KEY_DESCUENTO_FLOTILLA_ID_SYSFLEX").Value.ToInt();

                decimal prontoPagoPercent = quotation.DiscountPercentage.GetValueOrDefault();
                int PRONTO_PAGO_ID = oDropDownManager.GetParameter("PARAMETER_KEY_PRONTO_PAGO_ID_SYSFLEX").Value.ToInt();

                int cod_COMPANY = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();
                string Sistema = oDropDownManager.GetParameter("PARAMETER_KEY_SYSTEMA").Value;
                string errorPrimaZero = oDropDownManager.GetParameter("PARAMETER_KEY_ERROR_PRIMA_ZERO").Value;

                int ubicationID = 0;
                if (quoPrincipalDr != null && quoPrincipalDr.City_City_Id > 0)
                    ubicationID = oPersonManagerManager.GetPersonCountryUbicationOnSysflex(quoPrincipalDr.City_Country_Id, quoPrincipalDr.City_State_Prov_Id, quoPrincipalDr.City_City_Id);

                var AllowDescuentoProntoPago = oDropDownManager.GetParameter("PARAMETER_KEY_ALLOW_DISCOUNT_PRONTO_PAGO").Value;
                var AllowDescuentoFlotilla = oDropDownManager.GetParameter("PARAMETER_KEY_ALLOW_DISCOUNT_FLOTILLA").Value;

                var AllowDescuentoCoupon = oDropDownManager.GetParameter("PARAMETER_KEY_ALLOW_DISCOUNT_COUPON").Value;
                int DESCUENTO_COUPON_ID = oDropDownManager.GetParameter("PARAMETER_KEY_DESCUENTO_COUPON_ID_SYSFLEX").Value.ToInt();
                decimal CouponDiscountPercent = quotation.couponPercentageDiscount.GetValueOrDefault();

                if (base.RequestType == CommonEnums.RequestType.Emision)
                {
                    result.SentToCore = oCoreProxy.SetAutoQuotation_NewPV
                        (
                        quotation,
                        quoPrincipalDr,
                        vehicleCoverages,
                        getVehicleProductLimitVehicle,
                        quotationUser,
                        codMoneda,
                        tasaMoneda,
                        agentCode,
                        idOficina,
                        codramo,
                        servicesRetryAmount,
                        "POS-" + (currentUser != null ? currentUser.UserLogin : ""),
                        cod_COMPANY,
                        flotillaPercent,
                        DESCUENTO_FLOTILLA_ID,
                        prontoPagoPercent,
                        PRONTO_PAGO_ID,
                        Sistema,
                        errorPrimaZero,
                        ubicationID,
                        genderParam,
                        ageParam,
                        useNCFNew,
                        IsShowPolicy,
                        AllowDescuentoProntoPago,
                        AllowDescuentoFlotilla,
                        AllowDescuentoCoupon,
                        DESCUENTO_COUPON_ID,
                        CouponDiscountPercent,
                        out policyNumber,
                        out quotationCoreId,
                        out clientCoreId,
                        out statusMessages,
                        out SourceID,
                        out listVehicleSourceID,
                        out errorGP,
                        out errorChasis);
                }
                else if (RequestType == CommonEnums.RequestType.Inclusion)
                {
                    result.SentToCore = oCoreProxy.SetAutoQuotationInlclusionSysFlex
                                                                  (quotation,
                                                                   quoPrincipalDr,
                                                                   vehicleCoverages,
                                                                   getVehicleProductLimitVehicle,
                                                                   "POS-" + (currentUser != null ? currentUser.UserLogin : ""),
                                                                   useNCFNew,
                                                                   Sistema,
                                                                   TasaCalc,
                                                                   out policyNumber,
                                                                   out quotationCoreId,
                                                                   out clientCoreId,
                                                                   out statusMessages,
                                                                   out errorGP
                                                                   );
                }

                if (!result.SentToCore)
                {
                    var msg = "Se produjeron los siguientes errores al enviar la cotización al sistema core:";
                    foreach (var stmsg in statusMessages)
                    {
                        msg += "\n" + stmsg;
                    }
                    var quotationNumerError = quotation != null ? " No Cotizacion: " + quotation.QuotationNumber + " " : "N/A ";
                    LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.GetValueOrDefault(), "Error envío de cotización a Sysflex", quotationNumerError + msg);

                    result.resultQuotation = null;

                    if (errorChasis)
                    {
                        result.SentToCoreErrorChasis = msg;
                    }

                    SendErrorQuotation((quotation != null ? quotation.QuotationNumber : "N/A"), msg);

                    return result;
                }
                else
                {
                    result.resultQuotation.PolicyNumber = policyNumber; // Poliza generado por sysflex
                    result.resultQuotation.QuotationCoreIdNumber = quotationCoreId; // Cotizacion de sysflex
                    result.resultQuotation.ClientCoreIdNumber = clientCoreId; // Id del cliente en Sysflex
                    result.resultQuotation.Id = quotation.Id; //

                    policyId = policyNumber;

                    if (errorGP)
                    {
                        result.SentToCoreWithErrorGP = true;

                        string msg = "";
                        foreach (var stmsg in statusMessages)
                        {
                            msg += "\n" + stmsg;
                        }

                        var quotationNumerError = quotation != null ? " No Cotizacion: " + quotation.QuotationNumber + " " : "N/A ";
                        LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.Value, "Error al generar la factura en Sysflex", quotationNumerError + msg);

                        SendErrorQuotation((quotation != null ? quotation.QuotationNumber : "N/A"), msg);
                    }

                    //valido si es domiciliada para enviar la domiciliacion a GP
                    if (quotation.Domiciliation.GetValueOrDefault())
                    {
                        var msg = string.Empty;
                        try
                        {
                            var Result = oVirtualOfficeProxy.SetDomiciliationNewPosSite(quotation, quotation.PaymentFrequencyId.GetValueOrDefault(), cod_COMPANY, Convert.ToDecimal(quotation.QuotationCoreNumber), quotation.StartDate.GetValueOrDefault(), policyNumber, (usuario != null ? "POS-" + usuario.UserLogin : "POS-Venta Directa"));
                            msg = Result.oReturn.Message;

                            if (msg != "Exito")
                            {
                                var quotationNumerError = quotation != null ? " No Poliza: " + quotation.PolicyNumber + " " : "N/A ";
                                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.Value, "Error al domiciliar el pago", quotationNumerError + msg);
                            }
                        }
                        catch (Exception ex)
                        {
                            var quotationNumerError = quotation != null ? " No Poliza: " + quotation.PolicyNumber + " " : "N/A ";
                            LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.Value, "Error al domiciliar el pago", quotationNumerError + msg);
                        }

                    }
                }
            }
            else
                policyId = quotation.QuotationNumber;

            #endregion

            if (quotationUser != null && quotationUser.AgentId.HasValue && quotationUser.AgentId.Value > 0)
            {
                agentNameId = quotationUser.Username;
                agentId = quotationUser.AgentId.Value;
            }

            #region Enviando a la Bandeja
            //Now send quotation to VO
            int userID = oDropDownManager.GetParameter("PARAMETER_KEY_USERID_DEFAULT_VO").Value.ToInt();

            if (currentUser != null)
            {
                userID = currentUser.UserID;
            }

            var personforJobGlobal = oQuotationManager.getJobsByDesc(quoPrincipalDr.Job);

            ///Peps
            var oPeps = oDriverManager.GetPepsFormularyByDriver(quoPrincipalDr.Id, "CalidadPep");
            //
            //Benefiarios
            var oBenefiary = oDriverManager.GetDriverBeneficiaries(quoPrincipalDr.Id);
            //

            decimal MinAllowedAmountToPay = oDropDownManager.GetParameter("PARAMETER_KEY_MINIMUN_ALLOWED_AMOUNT_TO_PAY").Value.ToDecimal();

            string newEndpointCotizacion = "";

            //cuando sea full usar el webservices de cotizar para la parte de llamar el getprimacobertura
            if (quotation.SendInspectionOnly.HasValue && quotation.SendInspectionOnly.Value)
            {
                newEndpointCotizacion = System.Web.Configuration.WebConfigurationManager.AppSettings["SysFlexServiceQuoteUrl"].ToString(CultureInfo.InvariantCulture);
            }

            if (RequestType == CommonEnums.RequestType.Inclusion || RequestType == CommonEnums.RequestType.Exclusion || RequestType == CommonEnums.RequestType.Cambios)
            {
                newEndpointCotizacion = "";
            }

            result.SentToVO =
                oVirtualOfficeProxy.SetAutoQuotationAutoNew(agentNameId,
                                                            agentId,
                                                            idOficinaVO,
                                                            codMonedaVO,
                                                            servicesRetryAmount,
                                                            policyId,
                                                            SourceID,
                                                            codramo,
                                                            quotation,
                                                            quoPrincipalDr,
                                                            vehicleCoverages,
                                                            oPeps,
                                                            oBenefiary,
                                                            oQuotationManager.GetMappingInfo,
                                                            personforJobGlobal,
                                                            userID,
                                                            listVehicleSourceID,
                                                            getVehicleProductLimitVehicle,
                                                            MinAllowedAmountToPay,
                                                            EndorsementBeneficiary,
                                                            newEndpointCotizacion,
                                                            out statusMessages
                                                            );
            #endregion

            if (!result.SentToVO)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.GetValueOrDefault(), "Error envío de cotización a Virtual Office", string.Join("\n", statusMessages));

                SendErrorQuotation((quotation != null ? quotation.QuotationNumber : "N/A"), string.Join("\n", statusMessages));

                return result;
            }
            else
            {
                if (statusMessages.Count() > 0)
                {
                    LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.GetValueOrDefault(), "Error envío de cotización a Virtual Office", string.Join("\n", statusMessages));

                    SendErrorQuotation((quotation != null ? quotation.QuotationNumber : "N/A"), string.Join("\n", statusMessages));
                }

                if (quotation.SendInspectionOnly.HasValue && !quotation.SendInspectionOnly.Value)
                {
                    //Enviando requeridos la bandeja
                    try
                    {
                        oDocumentRequiredManager.SendDocumentRequiredToGlobal(new Requeriments.SetRequerimentsParameters()
                        {
                            quotationId = base.QuotationId,
                            userId = userID
                        });

                        oVirtualOfficeProxy.UpdateOneQuotationInfoTempNewPV(quotation, userID);
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.GetValueOrDefault(), "Error envío de documentos requeridos a la bandeja", ex.Message, ex);
                    }
                }

                return result;
            }
        }

        [HttpPost]
        public JsonResult DismissPayment(int quotationID, decimal? MinimumAmountToPay = 0)
        {
            var quotation = oQuotationManager.GetQuotation(quotationID);

            if (quotation == null)
                throw new Exception("Cotización no encontrada");

            bool response = false;
            string message = "";

            var s = oVirtualOfficeProxy.GetPolicy(quotation.QuotationNumber);
            if (s == true)
            {
                var usuario = GetCurrentUsuario();

                //Aqui llamar sp que Eliminara la cotizacion duplicada
                bool wasDeleted = oVirtualOfficeProxy.DeleteDuplicatePolicy(quotation.QuotationNumber, usuario.UserID);

                if (!wasDeleted)
                {
                    //Existe en vo
                    message = "Esta cotización ya ha sido enviada a nuestros sistemas.";
                    return Json(new { success = response, quotationId = quotation.Id, message = message }, JsonRequestBehavior.AllowGet);
                }
            }

            try
            {
                var sqr = SendQuotationToCore(quotation.Id.GetValueOrDefault(), MinimumAmountToPay);

                if (!sqr.CantMovement)
                {
                    response = false;
                    message = string.Format("A la Poliza \"{0}\" no se le pueden hacer movimientos ya que la misma esta en Transito", quotation.policyNoMain);
                    return Json(new { success = response, quotationId = quotation.Id, message = message }, JsonRequestBehavior.AllowGet);
                }

                var PolicyNumber = sqr.resultQuotation == null ? string.Empty : sqr.resultQuotation.PolicyNumber;

                var currentUser = GetCurrentUsuario();

                if (base.RequestType == CommonEnums.RequestType.Inclusion)
                    PolicyNumber = quotation.policyNoMain;

                if (sqr.SentToCore && sqr.SentToVO && sqr.SentToCoreWithErrorGP)
                {
                    response = true;

                    message = "No ha sido posible generar la factura en SysFlex. Espere de 3 a 5 minutos y consulte la póliza en Sysflex para verificar la factura, si la póliza aparece en tránsito favor comunicarse a la ext: 5280 o 5256 para asistencia de como proceder. El número de póliza se generó correctamente en SysFlex....... No. Póliza: " + quotation.PolicyNumber;
                    message = string.Format(oDropDownManager.GetParameter("PARAMETER_KEY_MESSAGE_GP_PASS_TO_SYSFLEX").Value, PolicyNumber);
                    message += ". Hora del Mensaje: " + DateTime.Now.ToString("hh:mm:ss tt");

                    if (sqr.resultQuotation != null)
                    {
                        Quotation.parameter qparam = new Quotation.parameter();
                        qparam.id = quotation.Id;
                        qparam.policyNumber = sqr.resultQuotation.PolicyNumber;
                        qparam.quotationCoreIdNumber = sqr.resultQuotation.QuotationCoreIdNumber;
                        qparam.quotationCoreNumber = sqr.resultQuotation.QuotationCoreIdNumber.ToString();
                        qparam.clientCoreIdNumber = sqr.resultQuotation.ClientCoreIdNumber;
                        qparam.paymentWay = null;
                        qparam.paymentFrequency = null;
                        qparam.status = 1;//Completada
                        qparam.modi_UserId = (GetCurrentUserID() != null ? GetCurrentUserID() : quotation.Modi_UserId);
                        qparam.monthlyPayment = quotation != null ? quotation.MonthlyPayment : null;
                        qparam.financed = quotation != null ? quotation.Financed.GetValueOrDefault() : false;
                        qparam.period = quotation != null ? quotation.Period : null;

                        if (!string.IsNullOrEmpty(base.RiskLevel))
                            qparam.RiskLevel = base.RiskLevel;

                        oQuotationManager.SetQuotation(qparam);
                    }

                    sendEmailErrorInvoice(message);
                }
                else if (sqr.SentToCore && !sqr.SentToVO && sqr.SentToCoreWithErrorGP)
                {
                    response = true;

                    message = "Ha ocurrido un error al tratar envíar la cotización a la Bandeja y no ha sido posible generar la factura en SysFlex. Espere de 3 a 5 minutos y consulte la póliza en Sysflex para verificar la factura, si la póliza aparece en tránsito favor comunicarse a la ext: 5280 o 5256 para asistencia de como proceder. El número de póliza se generó correctamente en SysFlex....... No. Póliza: " + quotation.PolicyNumber;

                    message = string.Format(oDropDownManager.GetParameter("PARAMETER_KEY_MESSAGE_GP_PASS_TO_SYSFLEX2").Value, PolicyNumber);
                    message += ". Hora del Mensaje: " + DateTime.Now.ToString("hh:mm:ss tt");

                    if (sqr.resultQuotation != null)
                    {
                        Quotation.parameter qparam = new Quotation.parameter();
                        qparam.id = quotation.Id;
                        qparam.policyNumber = sqr.resultQuotation.PolicyNumber;
                        qparam.quotationCoreIdNumber = sqr.resultQuotation.QuotationCoreIdNumber;
                        qparam.quotationCoreNumber = sqr.resultQuotation.QuotationCoreIdNumber.ToString();
                        qparam.clientCoreIdNumber = sqr.resultQuotation.ClientCoreIdNumber;
                        qparam.paymentWay = null;
                        qparam.paymentFrequency = null;
                        qparam.status = 1;//Completada
                        qparam.modi_UserId = (GetCurrentUserID() != null ? GetCurrentUserID() : quotation.Modi_UserId);
                        qparam.monthlyPayment = quotation != null ? quotation.MonthlyPayment : null;
                        qparam.financed = quotation != null ? quotation.Financed.GetValueOrDefault() : false;
                        qparam.period = quotation != null ? quotation.Period : null;

                        if (!string.IsNullOrEmpty(base.RiskLevel))
                            qparam.RiskLevel = base.RiskLevel;

                        oQuotationManager.SetQuotation(qparam);
                    }

                    sendEmailErrorInvoice(message);
                }
                else if (sqr.SentToCore && sqr.SentToVO && !sqr.SentToCoreWithErrorGP)//CUANDO TODO SALE BIEN
                {
                    response = true;

                    message = "La cotización se ha cargado en nuestros sistemas satisfactoriamente....... No. Póliza: " + PolicyNumber;

                    if (RequestType == CommonEnums.RequestType.Inclusion)
                        message = string.Format("El movimiento fue completado satisfactoriamente....... No. Póliza: {0}", PolicyNumber);

                    if (sqr.resultQuotation != null)
                    {
                        Quotation.parameter qparam = new Quotation.parameter();
                        qparam.id = quotation.Id;
                        qparam.policyNumber = sqr.resultQuotation.PolicyNumber;
                        qparam.quotationCoreIdNumber = sqr.resultQuotation.QuotationCoreIdNumber;
                        qparam.quotationCoreNumber = sqr.resultQuotation.QuotationCoreIdNumber.ToString();
                        qparam.clientCoreIdNumber = sqr.resultQuotation.ClientCoreIdNumber;
                        qparam.paymentWay = null;
                        qparam.paymentFrequency = null;
                        qparam.status = 1;//Completada
                        qparam.modi_UserId = (GetCurrentUserID() != null ? GetCurrentUserID() : quotation.Modi_UserId);
                        qparam.monthlyPayment = quotation != null ? quotation.MonthlyPayment : null;
                        qparam.financed = quotation != null ? quotation.Financed.GetValueOrDefault() : false;
                        qparam.period = quotation != null ? quotation.Period : null;

                        if (!string.IsNullOrEmpty(base.RiskLevel))
                            qparam.RiskLevel = base.RiskLevel;

                        oQuotationManager.SetQuotation(qparam);
                    }
                }
                else if (sqr.SentToCore && !sqr.SentToVO && !sqr.SentToCoreWithErrorGP)//CUANDO TODO SALE BIEN MENOS EN VO
                {
                    response = true;
                    message = "Ha ocurrido un error al tratar envíar la cotización a la bandeja, pero, se genero correctamente el número de póliza en SysFlex....... No. Póliza: " + PolicyNumber;

                    if (sqr.resultQuotation != null)
                    {
                        Quotation.parameter qparam = new Quotation.parameter();
                        qparam.id = quotation.Id;

                        qparam.policyNumber = sqr.resultQuotation.PolicyNumber;
                        qparam.quotationCoreIdNumber = sqr.resultQuotation.QuotationCoreIdNumber;
                        qparam.quotationCoreNumber = sqr.resultQuotation.QuotationCoreIdNumber.ToString();
                        qparam.clientCoreIdNumber = sqr.resultQuotation.ClientCoreIdNumber;
                        qparam.paymentWay = null;
                        qparam.paymentFrequency = null;
                        qparam.status = 1;//Completada
                        qparam.modi_UserId = (GetCurrentUserID() != null ? GetCurrentUserID() : quotation.Modi_UserId);
                        qparam.RequestTypeId = 1;
                        qparam.monthlyPayment = quotation != null ? quotation.MonthlyPayment : null;
                        qparam.financed = quotation != null ? quotation.Financed.GetValueOrDefault() : false;
                        qparam.period = quotation != null ? quotation.Period : null;
                        oQuotationManager.SetQuotation(qparam);
                    }

                }
                else if (!sqr.SentToCore && !sqr.SentToVO)
                {
                    response = false;
                    message = "Ha ocurrido un error al tratar envíar la cotización a Sysflex y a la Bandeja.";

                    if (!string.IsNullOrEmpty(sqr.SentToCoreErrorChasis))
                    {
                        message = sqr.SentToCoreErrorChasis;
                    }
                }

                if (response)
                {
                    if (base.RequestType == CommonEnums.RequestType.Emision && !string.IsNullOrEmpty(quotation.couponCode))
                    {
                        var quoPrincipalDr = oQuotationManager.GetQuotationDrivers(quotation.Id.GetValueOrDefault()).FirstOrDefault(x => x.IsPrincipal);
                        SetCouponProspect(quoPrincipalDr.FirstName, quoPrincipalDr.FirstSurname, quoPrincipalDr.Email, quoPrincipalDr.PhoneNumber, sqr.resultQuotation.PolicyNumber, quotation.CouponProspectId.GetValueOrDefault());
                    }

                    GenerateOnbaseFile(quotation.Id.GetValueOrDefault());

                    //Enviando nota a global siempre que haya
                    var allNotes = oQuotationManager.GetQuotationNotes(quotation.Id.GetValueOrDefault()).ToList();

                    if (allNotes.Count() > 0)
                    {
                        foreach (var n in allNotes)
                        {
                            oQuotationManager.SendQuotationNotesToGlobal(quotation.Id.GetValueOrDefault(), n.Id);
                        }
                    }
                    //Enviando nota a global siempre que haya
                }


            }
            catch (Exception ex)
            {
                var quotationNumerError = quotation != null ? " No Cotizacion: " + quotation.QuotationNumber + " " : "N/A ";
                var titulo = "Error al cargar la cotización";
                var mensaje = "Se produjo un error al omitir el pago.\nMensaje: " + quotationNumerError + ex.Message + "\nDetalle: " + ex.StackTrace;

                if (string.IsNullOrEmpty(message))
                    message = ex.Message;

                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.GetValueOrDefault(), titulo, mensaje, ex);

                SendErrorQuotation((quotation != null ? quotation.QuotationNumber : "N/A"), mensaje, ex);
            }

            return Json(new { success = response, quotationId = quotation.Id, message = message }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Check if product of law chassis and plate exist
        /// </summary>
        /// <param name="quotationId"></param>
        /// <returns></returns>
        public JsonResult CheckChassisPlateLawProducts(int quotationID)
        {
            /*Validando que no existan la placa y el chasis introducido*/
            var quotation = oQuotationManager.GetQuotation(quotationID);

            List<string> statusMessages = new List<string>();
            bool success = true;
            string realMessage = "";

            var vhData = getVehicleData(quotation.Id.GetValueOrDefault()).ToList().FirstOrDefault(x =>
                            (string.IsNullOrEmpty(x.Chassis) || string.IsNullOrWhiteSpace(x.Chassis)) ||
                            (string.IsNullOrEmpty(x.Plate) || string.IsNullOrWhiteSpace(x.Plate)) ||
                            (string.IsNullOrEmpty(x.Color) || string.IsNullOrWhiteSpace(x.Color))
                            );
            if (vhData != null)
            {
                realMessage = string.Format("El vehículo {0} falta completarle la información del chasis, placa o color. Si el error persiste refresque la página e intente otra vez.", vhData.VehicleDescription);
                return Json(new { success = false, message = realMessage }, JsonRequestBehavior.AllowGet);
            }


            try
            {
                var vehicle = getVehicleData(quotation.Id.GetValueOrDefault()).ToList();

                foreach (var item in vehicle)
                {
                    //if (!quotation.SendInspectionOnly.GetValueOrDefault()){}//Se solicito que se valide el chasis con todos los productos jdotel 04-04-2018

                    IsAQuotation = false;

                    var ccp = this.CheckChassisPlate(item.Chassis, item.Plate);

                    if (ccp.Count() > 0)
                    {
                        string policyOfDuplicate = string.Join(", ", ccp.Select(i => i.Policy));
                        string policyOfDuplicateEncriptep = Utility.Encrypt_Query(policyOfDuplicate);
                        string mid = "Mensaje ID:";
                        if (base.IsShowPolicy)
                        {
                            policyOfDuplicateEncriptep = policyOfDuplicate;
                            mid = "Poliza(s):";
                        }

                        statusMessages.Add(string.Format("El chasis \"{0}\" o placa \"{1}\" ya estan registrados en nuestros sistemas.<br/> {3} {2}",
                            item.Chassis, item.Plate, policyOfDuplicateEncriptep, mid));

                        success = false;
                    }
                    //}
                }

                if (statusMessages.Count() == 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                statusMessages.Add("Falla en el método CheckChassisPlate. Detalle: " + ex.Message);
                success = false;
            }
            if (!success)
            {
                foreach (var stmsg in statusMessages)
                {
                    realMessage += "\n" + stmsg;
                }

                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotation.Id.GetValueOrDefault(), "Error en envío de cotización a Sysflex/VirtualOffice", "Detalle: Nro de Cotización fallida: " + quotation.Id.GetValueOrDefault().ToString() + " MENSAJE " + realMessage);
                return Json(new { success = false, message = realMessage }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                IsAQuotation = true;
                return Json(new { success = true, message = "" }, JsonRequestBehavior.AllowGet);
            }
            /**/
        }

        [HttpPost]
        public JsonResult GetProductExcludeByAgent(string AgentCode)
        {
            var result = oQuotationManager.GetProductExcludeByAgent(AgentCode);
            return
                Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getMainOptions()
        {
            //Filtro Historico se refiere al menu de opciones
            var data = oDropDownManager.GetDropDown(CommonEnums.DropDownType.FILTROHISTORICO.ToString());
            var _params = "";

            if (base._actionData == null)
            {
                if (SetModeLey())
                {
                    _params = "LEYMODE";
                }
                else if (SetModeFull())
                {
                    _params = "FULLMODE";
                }

                base._actionData = _params;
            }
            else
            {
                _params = base._actionData;
            }


            var sp = _params.Split('&');
            string process = "";
            string couponDefault = "";
            string appMode = _params;
            string defaultClientJson = "";

            if (appMode.Trim() == CommonEnums.AppModes.LEYMODE.ToString() || appMode.Trim() == CommonEnums.AppModes.FULLMODE.ToString())
            {
                defaultClientJson = oDropDownManager.GetParameter("PARAMETER_KEY_DEFAULT_CLIENT").Value;
            }

            if (sp.Count() > 1)
            {
                process = sp[0];
                PolicySendByVO = sp[1];
                _actionData = "";
            }


            if (!base.CanDoInclusion)
            {
                data = data.Where(i => i.name.MyRemoveInvalidCharacters().ToLower() != CommonEnums.RequestType.Inclusion.ToString().ToLower()).ToList();

                if (process.MyRemoveInvalidCharacters().ToLower() == CommonEnums.RequestType.Inclusion.ToString().ToLower())
                {
                    process = "";
                }
            }

            if (!base.CanDoExclusion)
            {
                data = data.Where(i => i.name.MyRemoveInvalidCharacters().ToLower() != CommonEnums.RequestType.Exclusion.ToString().ToLower()).ToList();

                if (process.MyRemoveInvalidCharacters().ToLower() == CommonEnums.RequestType.Exclusion.ToString().ToLower())
                {
                    process = "";
                }
            }

            if (!base.CanDoCambios)
            {
                data = data.Where(i => i.name.MyRemoveInvalidCharacters().ToLower() != CommonEnums.RequestType.Cambios.ToString().ToLower()).ToList();

                if (process.MyRemoveInvalidCharacters().ToLower() == CommonEnums.RequestType.Cambios.ToString().ToLower())
                {
                    process = "";
                }
            }

            if (!base.CanDoNuevaPropuesta)
            {
                data = data.Where(i => i.name.MyRemoveInvalidCharacters().ToLower().Replace(" ", "") != CommonEnums.RequestType.PropuestaRecuperacion.ToString().ToLower()).ToList();

                if (process.MyRemoveInvalidCharacters().ToLower().Replace(" ", "") == CommonEnums.RequestType.PropuestaRecuperacion.ToString().ToLower())
                {
                    process = "";
                }
            }

            return Json(new { data = data.ToList(), optionSelected = process, PolicySendByVO = PolicySendByVO, AppMode = appMode, couponDefault = couponDefault, defaultClient = defaultClientJson }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool SendCallback(Redirect redirect)
        {
            string stcUrl = "";
            string numToCall = "";
            var ThisUser = GetCurrentUsuario();
            try
            {
                #region Generando llamada automatica
                //notificando llamada a la cuenta de servicio configurada
                SendNotificationCallBack(redirect); //esto esta comentado hasta que la url de la llamada esté funcionando
                numToCall = redirect.CntCode != null ? redirect.CntCode + redirect.CityCode + redirect.NumToCall : redirect.CityCode + redirect.NumToCall;

                //string queryString =
                //             "CntCode=" + redirect.CntCode +
                //             "&CityCode=" + redirect.CityCode +
                //             "&NumToCall=" + numToCall +
                //             "&Lang=" + redirect.Lang +
                //             "&FirstNames=" + redirect.FirstNames +
                //             "&LastNames=" + redirect.LastNames +
                //             "&City=" + redirect.City +
                //             "&Country=" + redirect.Country +
                //             "&Client=" + redirect.Client +
                //             "&eMail=" + redirect.Email != null ? redirect.Email : "" +
                //             "&PolicyNum=" + redirect.PolicyNum +
                //             "&Products=" + redirect.Products +
                //             "&Reason=" + redirect.Reason + 
                //             "&Company=" + redirect.Company +
                //             "&Message=" + redirect.Message +
                //             "&DateTime=" + redirect.Date_Time +
                //             "&NextURL=https://www.atlantica.do/sucursales/" +
                //             "&Svc=" + redirect.Svc;

                var UrlBase = oDropDownManager.GetParameter("PARAMETER_KEY_NEX_URL_CALBACK_SERVICES").Value;

                string queryString =
                             "NextURL=" + UrlBase +
                             "&NumToCall=" + numToCall;

                stcUrl = string.Format(oDropDownManager.GetParameter("PARAMETER_KEY_URL_CALBACK_SERVICES").Value, numToCall);


                var webRequest = WebRequest.Create(stcUrl);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                var byteArray = Encoding.UTF8.GetBytes(queryString);
                webRequest.ContentLength = byteArray.Length;
                var dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                #endregion
                return true;
            }

            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (ThisUser != null ? ThisUser.UserLogin : "POS-VentaDirecta"), 0, "Error posteando la llamada a los agentes de servicios en PVV", ex.Message, ex);
                return false;
            }
        }

        public ActionResult SetNewQueue()
        {
            var result = new Entity.Entities.QueueResult();
            var responseIncidence = "";
            var JsonChat = "";
            var ThisUser = GetCurrentUsuario();
            var msg = "";
            string incidencyId = "";
            try
            {
                #region Generando el nuevo codigo de incidencia en la base de datos de GrupoGD
                responseIncidence = SetNewIncidence();
                //incidencyId = SetNewIncidence();
                if (responseIncidence.Contains("|"))
                {
                    var param = responseIncidence.Split('|');
                    incidencyId = param[0].ToString();
                    JsonChat = param[1].ToString();
                }
                else
                {
                    throw new Exception("El Identificador del chat no fue encontrado");
                }

                if (string.IsNullOrEmpty(incidencyId))
                {
                    throw new Exception("El Identificador del chat no fue encontrado");
                }
                #endregion

                #region Enviando notificacion a los agentes de servicio para que sean que un usuario ha solicitado un chat
                var anonimusParam = oQueuesProxy.FilterQueuesAnomimus();

                var AnonimusName = string.Concat("PV_Vehiculos_", Guid.NewGuid()).ToUpper().Replace("-", "");
                anonimusParam.Anonimous_Name = AnonimusName;
                anonimusParam.Phone_Number = "999";
                anonimusParam.Policy_No = "00-000000-0000";
                anonimusParam.Queue_Source_Id = 6; // esto indica a los agentes, desde qué sistema se envió el chat
                anonimusParam.Driver_GPS_Location = oDropDownManager.GetParameter("PARAMETER_KEY_URL_CONNECT_CHAT_VIRTUAL_OFFICE").Value;

                anonimusParam.flag = 1; // esto indicador se refiere a que es un chat
                anonimusParam.pkIncidentChat = incidencyId;
                anonimusParam.Call_Meeting_Type_Desc = oDropDownManager.GetParameter("PARAMETER_KEY_CALL_MEETING_TYPE_DESC").Value;//"Services";
                anonimusParam.Call_Meeting_SubType_Desc = oDropDownManager.GetParameter("PARAMETER_KEY_CALL_MEETING_SUBTYPE_DESC").Value;//"Consultas";

                var ExecutionResult = oQueuesProxy.SetQueueAnomimusWithSourceId(anonimusParam).ToList();
                if (ExecutionResult != null)
                {
                    result = ExecutionResult.Select(o => new Entity.Entities.QueueResult()
                    {
                        Queue_Id = o.Queue_Anonimous_Id,
                        Case_Number = o.Case_Number,
                        Call_Meeting_Id = o.Call_Meeting_Id,
                        Contact_Id = o.Contact_Id,
                        IncidenceId = incidencyId
                        //Driver_GPS_Location  = o.Driver_GPS_Location,
                    }).FirstOrDefault();
                }
                #endregion
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (ThisUser != null ? ThisUser.UserLogin : "POS-VentaDirecta"), 0, "Error generando el chat desde PVV en VirtualOffice", ex.Message, ex);
                result.Case_Number = "Error";
                result.IncidenceId = ex.Message;
            }

            return Json(new { result = result, JsonChat = JsonChat }, JsonRequestBehavior.AllowGet);
        }

        public void SendNotificationCallBack(Redirect redirect)
        {
            var AccountTo = "";
            var AccountFrom = "";
            var ThisUser = GetCurrentUsuario();
            try
            {
                AccountTo = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_TO_CALLBACK").Value; //"jamador@statetrustlife.com, csoriano@statetrustlife.com,robispo@statetrustlife.com";
                AccountFrom = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_SENDER_CALLBACK").Value;

                var subject = string.Concat("Llamada generada desde el Punto de Venta de Auto para el cliente ", redirect.FirstNames, " ", redirect.LastNames);
                var body = string.Concat("Por este medio le informamos que el cliente ", redirect.FirstNames, " ", redirect.LastNames, " ha solicitado desde el Punto de Venta de Auto una llamada automática al teléfono ", redirect.CntCode != null ? " Móvil " + redirect.CntCode + redirect.CityCode + redirect.NumToCall : "Fijo " + redirect.CityCode + redirect.NumToCall, !string.IsNullOrEmpty(redirect.PolicyNum) ? " con relación a su póliza No. " + redirect.PolicyNum : "");

                List<string> destinatariosListError = new List<string>();

                foreach (var e in AccountTo.Split(','))
                {
                    destinatariosListError.Add(e);
                }

                SendEmailHelper.SendMail(AccountFrom, destinatariosListError, subject, body, null);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (ThisUser != null ? ThisUser.UserLogin : "POS-VentaDirecta"), 0, "Error enviando correo a los angentes de servicio sobre llamada telefonica en PVV", ex.Message, ex);
            }
        }

        public ActionResult GetPhoneTypes()
        {
            IEnumerable<Entity.Entities.Generic> result = null;
            var ThisUser = GetCurrentUsuario();
            try
            {
                result = oDropDownManager.GetDropDown(CommonEnums.DropDownType.PHONETYPES.ToString()).ToList();
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (ThisUser != null ? ThisUser.UserLogin : "POS-VentaDirecta"), 0, "Error buscando los tipos de teléfonos", ex.Message, ex);
            }
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetChatConnections()
        {
            var ThisUser = GetCurrentUsuario();
            var ConnectionChat = "";
            var ConnectionVirtualOffice = "";
            var ConnectionChatService = "";
            var OpenFireHostName = "";
            var DefaultUserChat = "";
            var MobileAgents = "";
            try
            {
                ConnectionChat = oDropDownManager.GetParameter("PARAMETER_KEY_URL_CONNECT_CHAT").Value;
                ConnectionVirtualOffice = oDropDownManager.GetParameter("PARAMETER_KEY_URL_CONNECT_CHAT_VIRTUAL_OFFICE").Value;
                ConnectionChatService = oDropDownManager.GetParameter("PARAMETER_KEY_URL_CHAT_CONNECTION_SERVICES").Value;
                OpenFireHostName = oDropDownManager.GetParameter("PARAMETER_KEY_OPENFIRE_HOSTNAME").Value;
                DefaultUserChat = oDropDownManager.GetParameter("PARAMETER_KEY_DEFAULT_CHAT_USER").Value;
                MobileAgents = oDropDownManager.GetParameter("PARAMETER_KEY_CLIENT_USERNAME").Value;
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (ThisUser != null ? ThisUser.UserLogin : "POS-VentaDirecta"), 0, "Error buscando los parametros de conexion del chat", ex.Message, ex);
            }
            return Json(new { ConnectionChat = ConnectionChat, ConnectionVirtualOffice = ConnectionVirtualOffice, ConnectionChatService = ConnectionChatService, OpenFireHostName = OpenFireHostName, DefaultUserChat = DefaultUserChat, MobileAgents = MobileAgents }, JsonRequestBehavior.AllowGet);
        }

        public string SetNewIncidence()
        {
            string stcUrl = "";
            var result = "";
            var ResponseResult = new Entity.Entities.IncidenceResponse();
            var port = 0;
            var ThisUser = GetCurrentUsuario();
            string StatusServices = "";
            string StatusServicesClosed = ""; //H
            try
            {
                #region Generando llamada automatica
                var UrlIncidenceService = oDropDownManager.GetParameter("PARAMETER_KEY_CHAT_URL_GENERATE_CHAT_ID").Value.Split('|');
                port = UrlIncidenceService[1].ToInt();
                StatusServices = UrlIncidenceService[2];
                StatusServicesClosed = UrlIncidenceService[3].ToString();

                var parameter = new
                {
                    chatDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    chatStatus = StatusServices,
                    fkStClient = port
                };

                var queryString = JsonConvert.SerializeObject(parameter);

                stcUrl = UrlIncidenceService[0];

                var webRequest = WebRequest.Create(stcUrl);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                var byteArray = Encoding.UTF8.GetBytes(queryString);
                webRequest.ContentLength = byteArray.Length;
                var dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = null;
                response = webRequest.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var str = reader.ReadToEnd();
                ResponseResult = JsonConvert.DeserializeObject<IncidenceResponse>(str);
                var JsonParameter = new
                {
                    pkStChat = ResponseResult.pkStChat.ToString(),
                    strChatDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    chatStatus = StatusServicesClosed,
                    StClient = port
                };
                #endregion

                result = string.Concat(ResponseResult.pkStChat.ToString(), "|", JsonConvert.SerializeObject(JsonParameter));
                ResponseResult = null;
                return result;
            }

            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (ThisUser != null ? ThisUser.UserLogin : "POS-VentaDirecta"), 0, "Error generando el identificador unico del chat en la db de grupo gd", ex.Message, ex);
                return "";
            }
        }

        public ActionResult CloseChat(string pJsonChat)
        {
            string stcUrl = "";
            Entity.Entities.Generic result = new Entity.Entities.Generic();
            var ThisUser = GetCurrentUsuario();
            try
            {
                #region Generando llamada automatica
                if (!string.IsNullOrEmpty(pJsonChat))
                {
                    var parameterJson = JsonConvert.DeserializeObject<IncidenceResponse>(pJsonChat);
                    var parameter = new
                    {
                        pkStChat = parameterJson.pkStChat,
                        chatDate = parameterJson.strChatDate,
                        chatStatus = parameterJson.chatStatus,
                        fkStClient = parameterJson.StClient
                    };

                    var UrlIncidenceService = oDropDownManager.GetParameter("PARAMETER_KEY_CHAT_URL_GENERATE_CHAT_ID").Value.Split('|');

                    var queryString = JsonConvert.SerializeObject(parameter);

                    stcUrl = UrlIncidenceService[0];

                    var webRequest = WebRequest.Create(stcUrl);
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/json";
                    var byteArray = Encoding.UTF8.GetBytes(queryString);
                    webRequest.ContentLength = byteArray.Length;
                    var dataStream = webRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();

                    WebResponse response = null;
                    response = webRequest.GetResponse();
                    var reader = new StreamReader(response.GetResponseStream());
                    var str = reader.ReadToEnd();
                    #endregion
                    result.name = "success";
                }
            }

            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (ThisUser != null ? ThisUser.UserLogin : "POS-VentaDirecta"), 0, "Error cerrando el chat en la db de grupo gd", ex.Message, ex);
                result.name = "error";
                result.Value = "Ha ocurrido un error cerrando el chat, intente nuevamente por favor";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private void GenerateOnbaseFile(int quotationID)
        {
            StringBuilder textFile = Utility.getIndexFileText();
            var StringResultFinal = new StringBuilder();
            string StringResult = "";
            string PathFiletxt = "";
            var FileList = new List<Tuple<byte[], string>>(0);
            string OnBasePath = System.Configuration.ConfigurationManager.AppSettings["OnBasePathPOS"];
            var RequestType = (CustomCode.CommonEnums.RequestType)Enum.Parse(typeof(CustomCode.CommonEnums.RequestType), base.RequestType.ToString());
            string policyNo = "";

            var quotData = oQuotationManager.GetQuotation(quotationID);

            //if (RequestType == CommonEnums.RequestType.Emision)
            //{
            policyNo = (string.IsNullOrEmpty(quotData.PolicyNumber) ? quotData.QuotationNumber : quotData.PolicyNumber);

            string vFileName = policyNo + ".txt";
            PathFiletxt = string.Concat(OnBasePath, @"\", vFileName);
            string RutaRequireDoc = "";
            List<string> docNames = new List<string>();

            var docRequiredData = oDocumentRequiredManager.GeQuotationRequeriments(new Requeriments.GetRequerimentsParameters()
            {
                quotationId = quotData.Id,
                RiskLevel = base.RiskLevel
            }).Where(x => x.DocumentId.HasValue && x.QuotationId.HasValue).ToList();

            byte[] docRequiredBinary = new byte[] { };

            foreach (var d in docRequiredData)
            {
                string chassis = "";

                var docbinary = oDocumentRequiredManager.GeQuotationRequerimentsByDocument(new Requeriments.GetRequerimentsParameters()
                {
                    quotationId = d.QuotationId,
                    documentId = d.DocumentId
                }).FirstOrDefault();

                if (docbinary != null)
                {
                    docRequiredBinary = docbinary.DocumentBinary;
                }

                RutaRequireDoc = string.Concat(OnBasePath, policyNo, "-", d.DocumentName);
                string current = DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                string clientName = quotData.PrincipalFullName;
                string clientDocID = quotData.PrincipalIdentificationNumber;

                if (d.PersonId.HasValue)
                {
                    var driver = oDriverManager.GetDriver(d.PersonId.Value);

                    if (driver != null)
                    {
                        clientName = string.Concat(driver.FirstName, " ", driver.FirstSurname);
                        clientDocID = driver.IdentificationNumber;
                    }
                }

                if (d.VehicleId.HasValue)
                {
                    var vh = oQuotationManager.GetQuotationVehicles(d.QuotationId.Value).ToList();
                    if (vh.Any())
                    {
                        var vhe = vh.FirstOrDefault(x => x.Id == d.VehicleId.Value);
                        if (vhe != null)
                        {
                            chassis = vhe.Chassis;
                        }
                    }
                }

                string realOnBaseNameKey = d.OnBaseNameKey;
                if (d.OnBaseNameKey == "SUS-Cedula Funcionario")
                {
                    realOnBaseNameKey = "SUS-Cedula";
                }

                StringResult = string.Format(textFile.ToString()
                    , realOnBaseNameKey //{0}
                    , current //{1}
                    , policyNo //{2}
                    , clientName //{3}
                    , current //{4}
                    , quotData.EndDate.GetValueOrDefault().ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) //{5}
                    , quotData.StartDate.GetValueOrDefault().ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) //{6}
                    , (GetCurrentUsuario() != null ? "POS-" + GetCurrentUsuario().UserLogin : "POS-VentaDirecta") //{7}
                    , quotData.QuotationNumber //{8}
                    , clientDocID //{9}
                    , chassis //{10}
                    , RequestType //{11}
                    , RutaRequireDoc //{12}
                    );

                StringResultFinal.AppendLine(StringResult);

                FileList.Add(new Tuple<byte[], string>(docRequiredBinary, RutaRequireDoc));

                docNames.Add(d.DocumentName);
            }

            try
            {
                //Guardar todos los archivos en la carpeta de onbase
                foreach (var item in FileList)
                {
                    //Proceso para atlantica
                    System.IO.File.WriteAllBytes(item.Item2, item.Item1);
                }
                //Guardar el txt que necesita Onbase para importar los archivos
                System.IO.File.WriteAllText(PathFiletxt, StringResultFinal.ToString(), Encoding.Default);

                //borrando los archivos de mi ruta local
                foreach (var dname in docNames)
                {
                    var completePath = Path.Combine(Server.MapPath("~/Tmp/"), dname);
                    deleteFileFromPath(completePath);
                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), quotData.Id.GetValueOrDefault(), "Error al guardar los documentos requeridos en la ruta", ex.Message, ex);
            }
            //}
        }

        public ActionResult ValidateOpenFireUserSession(string pUser)
        {
            string stcUrl = "";
            string str = "";
            var ThisUser = GetCurrentUsuario();
            var result = new Generic();
            var KeyAutorization = "";
            try
            {
                var ParameterServices = oDropDownManager.GetParameter("PARAMETER_KEY_URL_SERVICES_VALIDATE_USER_SESSION").Value.Split('|');
                stcUrl = ParameterServices[0] + pUser;
                KeyAutorization = ParameterServices[1].ToString();

                var parameter = new
                {
                    nombre = pUser
                };

                var webRequest = WebRequest.Create(stcUrl);
                webRequest.Headers.Add("Authorization", KeyAutorization);

                webRequest.Method = "GET";
                webRequest.ContentType = "application/json";

                using (WebResponse response = webRequest.GetResponse())
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    str = reader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(str);
                    XmlNode elem = doc.DocumentElement.LastChild;
                    if (elem != null)
                        result.name = elem.Name;
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (ThisUser != null ? ThisUser.UserLogin : "POS-VentaDirecta"), 0, "Error intentando validar la session del chat a travez del servicio " + stcUrl, ex.Message, ex);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #region Coupon

        public ActionResult GetCoupon(string CouponCode, string name, string lastName, string email, string phonenumber, string agentNameCode, int quotID, string couponDefault = "")
        {
            string messageError = "";
            bool success = true;
            string couponCode = "";
            decimal couponDiscount = 0;
            int prospectoID = 0;

            try
            {
                var usuario = GetCurrentUsuario();
                if (usuario == null || !string.IsNullOrEmpty(couponDefault))
                {
                    var codIntermediario = oDropDownManager.GetParameter("PARAMETER_KEY_COD_INTERMEDIARIO").Value.ToInt();
                    var agentNameId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_NAME").Value;

                    agentNameCode = agentNameId;

                    if (string.IsNullOrEmpty(name))
                    {
                        name = "Prospecto";
                    }

                    //if (!string.IsNullOrEmpty(couponDefault) && string.IsNullOrEmpty(name))
                    //{
                    //    name = "Prospecto";
                    //}
                }


                if (string.IsNullOrEmpty(agentNameCode))
                {
                    success = false;
                    messageError = string.Format("Debe seleccionar un Representante para poder optar por el Código Promocional.", CouponCode);

                    return Json(new { success = success, CouponCode = couponCode, CouponDiscount = couponDiscount, ProspectoID = prospectoID, message = messageError }, JsonRequestBehavior.AllowGet);
                }

                if (quotID > 0 && string.IsNullOrEmpty(name))
                {
                    var getquoD = oQuotationManager.GetQuotationDrivers(quotID);
                    if (getquoD != null)
                    {
                        var principalDri = getquoD.FirstOrDefault(x => x.IsPrincipal);
                        if (principalDri != null)
                        {
                            name = principalDri.FirstName;
                            lastName = principalDri.FirstSurname;
                            email = principalDri.Email;
                            phonenumber = string.IsNullOrEmpty(principalDri.PhoneNumber) ? principalDri.Mobile : principalDri.PhoneNumber;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(name))
                {
                    var parameter = new VirtualOfficeProxy.VOProxy.CouponsGetCoupons();
                    parameter.CouponCode = CouponCode;

                    var couponGenerated = oVirtualOfficeProxy.GetCoupon(parameter);

                    if (couponGenerated.Code != "000")
                    {
                        messageError += "Response Code: " + couponGenerated.Code + "\nMensaje: " + couponGenerated.Message;
                        messageError += "\nParámetros: " + JsonConvert.SerializeObject(couponGenerated, Newtonsoft.Json.Formatting.Indented) + "\n--\n";
                        success = false;
                    }

                    if (success && couponGenerated.JSONResult != "[]")
                    {
                        dynamic couponGeneratedResult = JsonConvert.DeserializeObject<List<dynamic>>(couponGenerated.JSONResult).FirstOrDefault();

                        //Creo el Prospecto
                        prospectoID = SetCouponProspect(name, lastName, email, phonenumber);
                        //

                        //Obteniendo el canal del intermediario seleccionado
                        string AgentChannel = "";

                        var objUser = getAgenteUserInfo(agentNameCode);
                        if (objUser != null)
                        {
                            AgentChannel = objUser.AgentsChannel.Channel_Desc.Trim();
                        }
                        //
                        bool validCo = ValidateCoupon(couponGeneratedResult.Codigo.ToString(), prospectoID, AgentChannel, out messageError);
                        if (validCo)
                        {
                            //Luego que veo que el cupon es valido, reviso si esta vigente todavia
                            DateTime startDate = couponGeneratedResult.FechaInicio;
                            DateTime endDate = couponGeneratedResult.FechaFin;
                            //

                            couponCode = couponGeneratedResult.Codigo.ToString();

                            DateTime currentDate = DateTime.Now;
                            if (currentDate.Date > endDate.Date)
                            {
                                messageError = string.Format("El Código Promocional <strong>{0}</strong> ha vencido.", couponCode);
                                success = false;
                            }
                            else
                            {
                                couponDiscount = couponGeneratedResult.Descuento;
                                messageError = string.Format("Felicidades el Código Promocional <strong>{0}</strong> es valido y aplica por un descuento de un {1}%.", couponCode, couponDiscount.ToString().Replace(".00", ""));
                            }
                        }
                        else
                        {
                            success = false;
                            //messageError = string.Format("El Código Promocional <strong>{0}</strong> es inválido.", couponCode);
                            if (string.IsNullOrEmpty(messageError))
                            {
                                messageError = string.Format("El Código Promocional <strong>{0}</strong> es inválido.", CouponCode);
                            }
                            else
                            {
                                messageError = string.Format("El Código Promocional <strong>{0}</strong> ha dado el siguiente mensaje: <strong>{1}</strong>", CouponCode, messageError);
                            }


                            if (quotID > 0)
                            {
                                Quotation.parameter qparam = new Quotation.parameter();
                                qparam.id = quotID;

                                var getquo = oQuotationManager.GetQuotation(quotID);
                                if (getquo != null)
                                {
                                    qparam.monthlyPayment = getquo.MonthlyPayment;
                                    qparam.financed = getquo.Financed;
                                    qparam.period = getquo.Period;

                                }
                                qparam.couponCode = "";
                                qparam.couponPercentageDiscount = 0;
                                qparam.CouponProspectId = 0;
                                qparam.modi_UserId = GetCurrentUserID();

                                if (!string.IsNullOrEmpty(base.RiskLevel))
                                    qparam.RiskLevel = base.RiskLevel;

                                oQuotationManager.SetQuotation(qparam);
                            }
                        }
                    }
                    else
                    {
                        success = false;
                        messageError = string.Format("El Código Promocional <strong>{0}</strong> es inválido.", CouponCode);
                    }
                }
                else
                {
                    success = false;
                    messageError = string.Format("Debe escribir un nombre para poder optar por el Código Promocional.", CouponCode);
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error Obteniendo Informacion Código Promocional", messageError, ex);
                success = false;
                messageError = "Error Obteniendo Información del Código Promocional";
            }

            return Json(new { success = success, CouponCode = couponCode, CouponDiscount = couponDiscount, ProspectoID = prospectoID, message = messageError }, JsonRequestBehavior.AllowGet);
        }

        private bool ValidateCoupon(string couponCode, int prospectID, string AgentChannel, out string messageError)
        {
            messageError = "";
            bool success = true;
            try
            {
                var parameter = new VirtualOfficeProxy.VOProxy.CouponsValidateCoupon();
                parameter.CouponCode = couponCode;
                parameter.ProspectId = prospectID;
                parameter.TransactionDate = DateTime.Now;
                parameter.ChannelName = AgentChannel;

                var validCoupon = oVirtualOfficeProxy.ValidateCouponByChannel(parameter);

                if (validCoupon.Code != "000")
                {
                    messageError += "Response Code: " + validCoupon.Code + "\nMensaje: " + validCoupon.Message;
                    messageError += "\nParámetros: " + JsonConvert.SerializeObject(validCoupon, Newtonsoft.Json.Formatting.Indented) + "\n--\n";
                    success = false;
                }

                if (success)
                {
                    dynamic validCouponResult = JsonConvert.DeserializeObject<dynamic>(validCoupon.JSONResult);

                    string code = validCouponResult.code;
                    if (code == "0")
                    {
                        return true;
                    }
                    else
                    {
                        messageError = validCouponResult.codeDescription.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error Validando Código Promocional " + couponCode, messageError, ex);
            }

            return false;
        }

        private int SetCouponProspect(string name, string lastName, string email, string phonenumber, string policy = "", int prospectId = 0)
        {
            string messageError = "";
            bool success = true;
            int prospectID = 0;
            try
            {
                var parameter = new VirtualOfficeProxy.VOProxy.CouponsCouponProspect();

                parameter.ProspectId = prospectId;
                parameter.Name = name;
                parameter.LastName = lastName;
                parameter.Email = email;
                parameter.PhoneNumber = phonenumber;
                parameter.Policy = policy;

                var CouponProspect = oVirtualOfficeProxy.SetCouponProspect(parameter);

                if (CouponProspect.Code != "000")
                {
                    messageError += "Response Code: " + CouponProspect.Code + "\nMensaje: " + CouponProspect.Message;
                    messageError += "\nParámetros: " + JsonConvert.SerializeObject(CouponProspect, Newtonsoft.Json.Formatting.Indented) + "\n--\n";
                    success = false;
                }

                if (success)
                {
                    dynamic CouponProspectResult = JsonConvert.DeserializeObject<dynamic>(CouponProspect.JSONResult);

                    string code = CouponProspectResult.code;
                    if (code == "0" && CouponProspectResult.prospecto != null)
                    {
                        prospectID = CouponProspectResult.prospecto.Id;
                        return prospectID;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error Creando Propescto Código Promocional " + name, messageError, ex);
            }

            return prospectID;
        }

        #endregion

        public ActionResult getContactForm()
        {
            //Filtro Historico se refiere al menu de opciones
            var data = oDropDownManager.GetDropDown(CommonEnums.DropDownType.CONTACTFORM.ToString());

            return Json(new { data = data.ToList() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoverageExplication(int coverageID = 0)
        {
            //Filtro Historico se refiere al menu de opciones
            var data = oCoverageManager.GetCoverageExplication(new CoverageExplication.Parameter()
            {
                coverageID = coverageID
            });

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAgentChannel(string agentNameCode)
        {
            //Obteniendo el canal del intermediario seleccionado
            string AgentChannel = "";

            var objUser = getAgenteUserInfo(agentNameCode);
            if (objUser != null)
            {
                AgentChannel = objUser.AgentsChannel.Channel_Desc.Trim();
            }
            //

            return Json(new { AgentChannel = AgentChannel }, JsonRequestBehavior.AllowGet);

        }

        #region Send Verification Code

        public JsonResult SendVerificationCode(string PhoneNumber)
        {
            string message = "";
            bool success = false;

            try
            {
                string noMaskedPhoneNumber = PhoneNumber.Replace("-", "").Replace("(", "").Replace(")", "");

                var generatedCode = Utility.getVerificationCode();

                var oPosAuto = new CustomCode.TH.POS_AUTO();
                var oTransaction = new CustomCode.TH.Transaction();
                var oRecipients = new CustomCode.TH.Recipients();

                oTransaction.DocumentId = oDropDownManager.GetParameter("PARAMETER_KEY_DOCUMENT_ID_SMS").Value;

                oRecipients.PhoneNumber = noMaskedPhoneNumber;
                oRecipients.Message = generatedCode;

                oPosAuto.Transaction = oTransaction;
                oPosAuto.Recipients = oRecipients;

                var DocXML = Utility.SerializeToXMLString(oPosAuto);

                byte[] Xml = Encoding.UTF8.GetBytes(DocXML);

                int THProjectID = oDropDownManager.GetParameter("PARAMETER_KEY_TH_PROJECT_ID").Value.ToInt();
                int THBatchConfigResID = oDropDownManager.GetParameter("PARAMETER_KEY_TH_BATCH_CONFIG_RES_ID").Value.ToInt();

                //oThunderheadProxy.SendToTHExecutePreview_SMS(null, Xml, THProjectID, THBatchConfigResID);
                oThunderheadProxy.NewSendToTHExecutePreview_SMS(Xml, THProjectID, THBatchConfigResID);

                oQuotationManager.SetVerificationCode(PhoneNumber, generatedCode);

                message = string.Format("Se ha enviado un código de verificación al número de celular: <strong>{0}</strong>. " +
                                        "<br/> Favor introducir el código de verificación recibido para continuar.",
                                        PhoneNumber);
                success = true;

            }
            catch (Exception ex)
            {
                string ms = string.Format("Error enviando codigo de verificacion al numero: {0} Mensaje error: {1}", PhoneNumber, ex.Message);
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error enviando codigo de verificacion", ms, ex);
            }
            return Json(new { success = success, message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateCode(string PhoneNumber, string VerificationCode)
        {
            string message = "";
            bool success = false;

            var code = oQuotationManager.GetVerificationCode(PhoneNumber, VerificationCode);

            if (code == null)
            {
                message = "El código introducido es invalido, favor verificar.";
            }
            else
            {
                success = true;
                message = "El código introducido es válido, puede continuar.";
            }

            return Json(new { success = success, message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCode(string PhoneNumber)
        {
            bool success = false;
            string strCode = "";

            var code = oQuotationManager.GetVerificationCode(PhoneNumber, null);

            if (code != null)
            {
                success = true;
                strCode = code.verification_Code;
            }

            return Json(new { success = success, code = strCode }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        public JsonResult AllowSaveOnlyVehicle()
        {
            var al = oDropDownManager.GetParameter("PARAMETER_KEY_ALLOW_SAVE_ONLY_VEHICLE").Value;

            return Json(new { allow = (al == "S") }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getClientIpInfo(string ip = "", string m = "")
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            bool success = true;
            string message = "";
            int id = 0;
            string description = null;
            bool processAll = false;

            if (!string.IsNullOrEmpty(m))
            {
                processAll = true;
            }

            try
            {
                WebClient client = new WebClient();

                // Make an api call and get response.
                string url = string.Format("https://tools.keycdn.com/geo.json?host={0}", ip);
                string response = client.DownloadString(url);
                //Deserialize response JSON
                Utility.GeoRootObject ipdata = Utility.deserializeJSON<Utility.GeoRootObject>(response);
                if (ipdata.status == "error")
                {
                    success = false;
                    message = ipdata.description;
                    //throw new Exception(ipdata.description);
                }
                else
                {
                    //aqui guardar el json generado
                    LogVisits param = new LogVisits();

                    if (processAll)
                    {
                        var decode = Utility.Decode(m);
                        var spl = decode.Split('|');

                        id = Convert.ToInt32(spl[0]);
                        description = spl[1];
                    }

                    param.contactFormId = id;
                    param.iP = ip;
                    param.iPInfo = response;
                    param.system = "Punto de Venta Auto";

                    oQuotationManager.SetLogVisits(param);
                }

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.ToString();
            }

            return Json(new { success = success, message = message, medio = id }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetQuotationReferredInfo(int quotationId)
        {
            var data = oQuotationManager.GetQuotationReferred(quotationId, null);

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetReferredInfoByPolicy(string policy)
        {
            var DataCoreCustomer = oCoreProxy.GetClienteFromPoliza(policy);
            Person pp = null;

            if (DataCoreCustomer != null)
            {
                pp = new Person();

                pp.IdentificationNumber = DataCoreCustomer.RNC;
                pp.FirstName = DataCoreCustomer.NombreCliente;
                pp.Email = DataCoreCustomer.Email;
                pp.PhoneNumber = !string.IsNullOrEmpty(DataCoreCustomer.Celular) ? DataCoreCustomer.Celular : DataCoreCustomer.TelefonoResidencia;
            }

            return Json(new { data = pp }, JsonRequestBehavior.AllowGet);
        }

    }
}


