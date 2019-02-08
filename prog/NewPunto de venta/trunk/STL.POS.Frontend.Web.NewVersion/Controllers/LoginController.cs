using Statetrust.Framework.Security.Bll;
using Statetrust.Framework.Security.Bll.Item;
using STL.POS.Frontend.Web.NewVersion.CustomCode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.NewVersion.Controllers
{
    public class LoginController : BaseController
    {
        private CustomCode.Utility.ActionModel ActionModel
        {
            set
            {
                Session["ActionModel"] = value.ToJson();
            }
        }

        public ActionResult RedirectToOtherApp(string path, string appname, string tab)
        {
            var onlyLoggedUsers = allowOnlyLoggedUsers();
            if (onlyLoggedUsers)
            {
                var addInfo = new AdditionalInfo
                {
                    CompanyId = Usuario != null ? Usuario.CurrentCompanyId : 1, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                    Language = Usuario != null ? Usuario.CurrentLanguageKey : "es", //Idioma en el que quiere que se vea la aplicación a acceder.
                    AppName = appname,
                    RedirectUrl = path,
                    RedirectTab = tab
                };

                var data = GenerateToken(Usuario.UserID, addInfo); //Genera un nuevo Token y se le pasa el ID del Usuario, el WebControl que lo llamo para leer los parámetros de aplicación y el Additional info para saber la compañía y el idioma.

                string msjerrr = "";

                if (data.Status)
                {
                }
                else
                {
                    msjerrr = data.errormessage.Trim();
                    if (msjerrr == "This user does not have access to this page or App")
                    {
                        msjerrr = "This user does not have access to this page or App";//Globalization.Home.HomeIndex.userNotAllowed;
                    }
                }
                return Json(new { Status = data.Status, UrlPath = data.UrlPath, errormessage = msjerrr }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = false, UrlPath = "", errormessage = "" }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult RedirectToVo(string path, string appname, string tab)
        {
            var addInfo = new AdditionalInfo
            {
                CompanyId = Usuario != null ? Usuario.CurrentCompanyId : 1, //Nombre de la compañía de la cual se quiere ver la data (Life o Atlantica)
                Language = Usuario != null ? Usuario.CurrentLanguageKey : "es", //Idioma en el que quiere que se vea la aplicación a acceder.
                AppName = appname,
                RedirectUrl = path,
                RedirectTab = tab
            };

            var data = GenerateToken(Usuario.UserID, addInfo); //Genera un nuevo Token y se le pasa el ID del Usuario, el WebControl que lo llamo para leer los parámetros de aplicación y el Additional info para saber la compañía y el idioma.

            string msjerrr = "";

            if (data.Status)
            {
            }
            else
            {
                msjerrr = data.errormessage.Trim();
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = "This user does not have access to this page or App";//Globalization.Home.HomeIndex.userNotAllowed;
                }
            }

            return Json(new { Status = data.Status, UrlPath = data.UrlPath, errormessage = msjerrr }, JsonRequestBehavior.AllowGet);
        }

        private void setRolesByUser(List<Usuarios.RolesByUser> dataRoles)
        {
            base.CanDoInclusion = dataRoles.Any(o => o.Rol_Name.Contains("CanDoInclusionCot"));
            base.CanDoExclusion = dataRoles.Any(o => o.Rol_Name.Contains("CanDoExclusionCot"));
            base.IsShowPolicy = dataRoles.Any(o => o.Rol_Name.Contains("IsShowPolicy"));
            base.CanSeeListUsers = dataRoles.Any(o => o.Rol_Name.Contains("CanSeeListUsersPVAUTO"));
            base.CanDoCambios = dataRoles.Any(o => o.Rol_Name.Contains("CanDoCambiosCot"));

            base.CanDoNuevaPropuesta = dataRoles.Any(o => o.Rol_Name.Contains("NuevaPropuestaCot"));

            var _listUsers = oDropDownManager.GetDropDown(CustomCode.CommonEnums.DropDownType.GETALLUSERSACCESSPV.ToString()).ToList();
            var realList = new SelectList(_listUsers.Select(i => new SelectListItem { Text = i.name, Value = i.Value }), "Value", "Text");

            base.ListUsers = realList;

        }

        // GET: Login
        public ActionResult STFLogin()
        {
            var controller = "Home";
            var action = "Index";

            var newController = "Home";
            var newAction = "Index";

            /*
              1 = Solo usuarios Logueados
              0 =  Todo el mundo
            */

            var onlyLoggedUsers = allowOnlyLoggedUsers();

            if (onlyLoggedUsers)
            {
                if (WebConfigurationManager.AppSettings["ApplySecurity"].ToString() == "false")
                {
                    var userId = 0;
                    string userLogin = "ptecnologia";//mamercedes --> outiiz/77lQ= || defaultuser || PTECNOLOGIA --> UjAsEkU/BxXlACKm4mdWkg== || 
                    if (!Login(userLogin, "UjAsEkU/BxXlACKm4mdWkg==", ref userId))
                    {
                        return RedirectToAction(action, controller);
                    }

                    SetLoginInformation();

                    //CheckDbUser(Usuario.UserLogin, Usuario.Email);

                    var UsuarioRoles = Usuario.rolesByUser;
                    setRolesByUser(UsuarioRoles);
                    var usuario = GetCurrentUsuario();
                    ViewBag.UserOrigin = STL.POS.Frontend.Web.NewVersion.CustomCode.CommonEnums.UserOrigins.VO;
                    ViewBag.UserType = usuario == null ? "" : Usuario.UserType.ToString();

                    setOthersValues(ref newController, ref newAction);

                    if (!string.IsNullOrEmpty(newAction) && !string.IsNullOrEmpty(newController))
                    {
                        return RedirectToAction(newAction, new { Controller = newController/*, Area = "Auto"*/ });
                    }

                }
                else
                {
                    if (Request.QueryString.Count > 0)
                    {
                        var secToken = Request.QueryString[0];
                        var userId = 0;
                        var applicationId = 0;
                        var username = string.Empty;
                        var loginName = string.Empty;
                        var email = string.Empty;

                        if (!Login(secToken, ref userId, ref applicationId))
                            return RedirectToAction(action, controller);

                        SetLoginInformation();

                        //CheckDbUser(Usuario.UserLogin, email);

                        var UsuarioRoles = Usuario.rolesByUser;
                        setRolesByUser(UsuarioRoles);
                        setOthersValues(ref newController, ref newAction);

                        if (!string.IsNullOrEmpty(newAction) && !string.IsNullOrEmpty(newController))
                        {
                            return RedirectToAction(newAction, new { Controller = newController/*, Area = "Auto"*/ });
                        }
                    }
                    else
                    {
                        return Redirect(WebConfigurationManager.AppSettings["SecurityLogin"].ToString());
                    }
                }
            }
            else
            {
                setOthersValues(ref newController, ref newAction);

                if (!string.IsNullOrEmpty(newAction) && !string.IsNullOrEmpty(newController))
                {
                    return RedirectToAction(newAction, new { Controller = newController/*, Area = "Auto"*/ });
                }

                return RedirectToAction(action, new { Controller = controller });
            }

            return RedirectToAction(action, new { Controller = controller });

        }

        [ValidateInput(false)]
        public ActionResult ReloginUser(string userdata = "")
        {
            var spUser = userdata.Split('|');

            if (spUser.Count() > 2)
            {
                var userId = 0;
                string userLogin = spUser[0].ToString();
                string userPass = spUser[1].ToString();
                if (Login(userLogin, userPass, ref userId))
                {
                    SetLoginInformation();

                    var UsuarioRoles = Usuario.rolesByUser;
                    setRolesByUser(UsuarioRoles);

                    //esto lo hago para que si se cambia de usuario con ptecnologia siempre aparezca la lista de usuarios
                    base.CanSeeListUsers = true;

                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogoutPOS()
        {
            //Session.Abandon();
            //ViewBag.UnauthorizedAccess = false;
            return RedirectToAction("Index", "Home");
        }

        private void setOthersValues(ref string redirectedController, ref string redirectedAction)
        {
            var jsonAdditionalInfo = Request.QueryString["additionalinfo"];
            redirectedController = "";
            redirectedAction = "";
            bool modeley = SetModeLey();
            bool modefull = SetModeFull();

            if (!String.IsNullOrEmpty(jsonAdditionalInfo))
            {
                var usuario = GetCurrentUsuario();
                if (usuario != null)
                {
                    var additionalInfo = GetAdditionalInfo(jsonAdditionalInfo);
                    var urlMVC = additionalInfo.RedirectRoute;

                    foreach (var url in urlMVC)
                    {
                        if (url.Key.ToString() == "Controller")
                        {
                            redirectedController = url.Value;
                        }

                        if (url.Key.ToString() == "Action")
                        {
                            redirectedAction = url.Value;
                        }
                    }

                    if (modeley)
                    {
                        ActionModel = new CustomCode.Utility.ActionModel
                        {
                            ActionJson = "LEYMODE"
                        };
                    }
                    else if (modefull)
                    {
                        ActionModel = new CustomCode.Utility.ActionModel
                        {
                            ActionJson = "FULLMODE"
                        };
                    }
                    else
                    {
                        ActionModel = new CustomCode.Utility.ActionModel
                        {
                            ActionJson = additionalInfo.Action
                        };
                    }
                }
                else
                {
                    var decrypt = Utility.Decrypt_Query_New(jsonAdditionalInfo);

                    var newJosn = Utility.deserializeJSON<Utility.jsonAdditionalInfo_Security>(decrypt);
                    if (newJosn != null)
                    {
                        if (modeley)
                        {
                            ActionModel = new CustomCode.Utility.ActionModel
                            {
                                ActionJson = "LEYMODE"
                            };
                        }
                        else if (modefull)
                        {
                            ActionModel = new CustomCode.Utility.ActionModel
                            {
                                ActionJson = "FULLMODE"
                            };
                        }
                        else
                        {
                            ActionModel = new CustomCode.Utility.ActionModel
                            {
                                ActionJson = newJosn.Action//additionalInfo.Action
                            };
                        }
                    }
                    else
                    {
                        ActionModel = new CustomCode.Utility.ActionModel
                        {
                            ActionJson = ""
                        };
                    }
                }

                _actionData = "";

                var val = Session["ActionModel"];
                if (val == null)
                {
                    Session.Remove("ActionModel");
                    base.PolicySendByVO = "";
                }
                var actionModel = val.ToString().ToObject<Utility.ActionModel>();
                Session.Remove("ActionModel");
                if (actionModel != null)
                {
                    _actionData = actionModel.ActionJson;
                }
                else
                {
                    base.PolicySendByVO = "";
                }
            }
            else
            {
                if (modeley)
                {
                    ActionModel = new CustomCode.Utility.ActionModel
                    {
                        ActionJson = "LEYMODE"
                    };

                    _actionData = "";

                    var val = Session["ActionModel"];
                    if (val == null)
                    {
                        Session.Remove("ActionModel");
                        base.PolicySendByVO = "";
                    }
                    var actionModel = val.ToString().ToObject<Utility.ActionModel>();
                    Session.Remove("ActionModel");
                    if (actionModel != null)
                    {
                        _actionData = actionModel.ActionJson;
                    }
                    else
                    {
                        base.PolicySendByVO = "";
                    }
                }
                else if (modefull)
                {
                    ActionModel = new CustomCode.Utility.ActionModel
                    {
                        ActionJson = "FULLMODE"
                    };

                    _actionData = "";

                    var val = Session["ActionModel"];
                    if (val == null)
                    {
                        Session.Remove("ActionModel");
                        base.PolicySendByVO = "";
                    }
                    var actionModel = val.ToString().ToObject<Utility.ActionModel>();
                    Session.Remove("ActionModel");
                    if (actionModel != null)
                    {
                        _actionData = actionModel.ActionJson;
                    }
                    else
                    {
                        base.PolicySendByVO = "";
                    }
                }

            }
        }

        public ActionResult simulateRequestFranklin(string changeUrl = "")
        {
            var path = ConfigurationManager.AppSettings["PvAutoPath"];
            var appname = ConfigurationManager.AppSettings["PvAutoApp_Name"];
            var appid = ConfigurationManager.AppSettings["PuntodeVentaAppId"];
            System.Web.UI.WebControls.LinkButton bntDrop = new System.Web.UI.WebControls.LinkButton();
            bntDrop.Attributes["path"] = path;
            bntDrop.Attributes["appname"] = appname;
            //bntDrop.Attributes["appid"] = appid;
            /*Enviar Poliza Como parametro*/
            //bntDrop.Attributes.Add("Action", "EXCLUSION" + '&' + "16-05-520028");
            bntDrop.Attributes.Add("Action", "LEYMODE");
            var addInfo = new Statetrust.Framework.Security.Bll.Item.AdditionalInfo
            {
                //AppName = appname,
                CompanyId = 2,
                Language = "es"
            };

            var currentuserid = 17966;
            if (GetCurrentUserID() != null)
            {
                currentuserid = GetCurrentUserID().Value;
            }
            var data = Statetrust.Framework.Security.Core.SecurityPage.GenerateToken(currentuserid, bntDrop, addInfo);
            string Url = "";
            if (data.Status)
            {
                if (changeUrl == "S")
                {
                    Url = data.UrlPath.Replace("http://PuntoDeVentaNew.dev.atlantica.local", "http://localhost:65492");
                }
                else
                {
                    Url = data.UrlPath;
                }

            }
            else
            {
                Url = data.errormessage;
            }

            return Json(new { Status = data.Status, UrlPath = Url, errormessage = "" }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SetLeyMode(string changeUrl = "")
        {
            var path = ConfigurationManager.AppSettings["PvAutoPath"];
            var appname = ConfigurationManager.AppSettings["PvAutoApp_Name"];
            var appid = ConfigurationManager.AppSettings["PuntodeVentaAppId"];
            System.Web.UI.WebControls.LinkButton bntDrop = new System.Web.UI.WebControls.LinkButton();
            bntDrop.Attributes["path"] = path;
            bntDrop.Attributes["appname"] = appname;
            //bntDrop.Attributes["appid"] = appid;
            /*Enviar Poliza Como parametro*/
            //bntDrop.Attributes.Add("Action", "EXCLUSION" + '&' + "16-05-520028");
            bntDrop.Attributes.Add("Action", "LEYMODE");
            var addInfo = new Statetrust.Framework.Security.Bll.Item.AdditionalInfo
            {
                //AppName = appname,
                CompanyId = 2,
                Language = "es"
            };

            var currentuserid = 17966;
            if (GetCurrentUserID() != null)
            {
                currentuserid = GetCurrentUserID().Value;
            }
            var data = Statetrust.Framework.Security.Core.SecurityPage.GenerateToken(currentuserid, bntDrop, addInfo);
            string Url = "";
            if (data.Status)
            {
                if (changeUrl == "S")
                {
                    Url = data.UrlPath.Replace("http://PuntoDeVentaNew.dev.atlantica.local", "http://localhost:65492");
                }
                else
                {
                    Url = data.UrlPath;
                }

            }
            else
            {
                Url = data.errormessage;
            }

            return Json(new { Status = data.Status, UrlPath = Url, errormessage = "" }, JsonRequestBehavior.AllowGet);
        }

    }
}