using Statetrust.Framework.Security.Bll;
using Statetrust.Framework.Security.Bll.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Declarative.Invoicing.Controllers
{
    public class LoginController : BaseController
    {

        public ActionResult RedirectToOtherApp(string path, string appname, string tab)
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
                return Json(new { Status = false, UrlPath = "", errormessage = "" }, JsonRequestBehavior.AllowGet);
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
            //base.CanDoInclusion = dataRoles.Any(o => o.Rol_Name.Contains("CanDoInclusionCot"));          
            // base.ListUsers = realList;
        }

        // GET: Login
        public ActionResult STFLogin()
        {
            var controller = "Queue";
            var action = "Index";

            var newController = "Queue";
            var newAction = "Index";

            if (WebConfigurationManager.AppSettings["ApplySecurity"].ToString() == "false")
            {
                var userId = 0;
                string userLogin = "jdotel";//mamercedes --> outiiz/77lQ= || defaultuser || PTECNOLOGIA --> UjAsEkU/BxXlACKm4mdWkg== || 
                if (!Login(userLogin, "outiiz/77lQ=", ref userId))
                {
                    return RedirectToAction(action, controller);
                }

                SetLoginInformation();

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

            return RedirectToAction(action, new { Controller = controller });
        }

        private void setOthersValues(ref string redirectedController, ref string redirectedAction)
        {
            var jsonAdditionalInfo = Request.QueryString["additionalinfo"];
            redirectedController = "";
            redirectedAction = "";

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
                }
            }

        }
    }
}