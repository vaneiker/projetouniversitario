using Statetrust.Framework.Core.Base;
using Statetrust.Framework.Security.Bll.Item;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MantModelosyMarcas.Controllers
{
    public class LoginController : BaseController
    {
         
        public ActionResult Login()
        {
            //redirecionar a la pantalla de bienvenida
            var controller = "MarcasModelos";
            var action = "Index";

            var newController = "MarcasModelos";
            var newAction = "Index";
            if (WebConfigurationManager.AppSettings["ApplySecurity"].ToString(CultureInfo.InvariantCulture) == "false")
            {
                var userId = 0;

                //if (!Login("jdotel", "BZZL/bg9Bmfs/ie82nYPlQ==", ref userId))
                if (!Login("PTECNOLOGIA", "outiiz/77lQ=", ref userId))
                    return RedirectToAction(action, controller);
                SetLoginInformation();

                setOthersValues(ref  newController, ref newAction);

                if (!string.IsNullOrEmpty(newAction) && !string.IsNullOrEmpty(newController))
                {
                    return RedirectToAction(newAction, new { Controller = newController, Area = "Auto" });
                }

                if (string.IsNullOrEmpty(newAction) && string.IsNullOrEmpty(newController))
                {
                    Statetrust.Framework.Security.Core.Mvc.SecurityController a = new Statetrust.Framework.Security.Core.Mvc.SecurityController();

                    var routeDefaulta = a.GetDefaultPageByUserID(userId, 2040);
                    if (routeDefaulta == null) return Redirect(WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture));
                    controller = routeDefaulta[CommonEnums.RouteValues.Controller];
                    action = routeDefaulta[CommonEnums.RouteValues.Action];
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
                    {
                        return RedirectToAction(action, controller);
                    }

                    var route = SetLoginInformation();

                    action = "Index";

                    setOthersValues(ref  newController, ref newAction);

                    if (string.IsNullOrEmpty(newAction) && string.IsNullOrEmpty(newController))
                    {
                        var routeDefault = GetDefaultPageByUserID(userId, applicationId);
                        if (routeDefault == null) return Redirect(WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture));
                        controller = routeDefault[CommonEnums.RouteValues.Controller];
                        action = routeDefault[CommonEnums.RouteValues.Action];
                    }
                }
                else
                    return Redirect(WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture));
            }

            return RedirectToAction(action, controller);
        }

        [AllowAnonymous]
        public ActionResult RedirectToOtherApp(string path, string appname, string tab)
        {
            string msjerrr = "";
            try
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
                               
                string realPath = "";
                if (data.Status)
                {
                    realPath = path;
                }
                else
                {
                    msjerrr = data.errormessage.Trim();
                    if (msjerrr == "This user does not have access to this page or App")
                    {
                        msjerrr = "Este usuario no tiene acceso a esta página o aplicación.";
                    }
                }

                return Json(new { Status = data.Status, UrlPath = realPath, errormessage = msjerrr }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Threading.ThreadAbortException)
            {
                // To Handle HTTP Exception "Cannot redirect after HTTP headers have been sent".
            }
            catch (Exception)
            {

                throw;
            }

            return Json(new { Status =false, UrlPath = "", errormessage = msjerrr }, JsonRequestBehavior.AllowGet);
        }

        private void setOthersValues(ref string redirectedController, ref string redirectedAction)
        {
            var jsonAdditionalInfo = Request.QueryString["additionalinfo"];
            redirectedController = "";
            redirectedAction = "";

            if (!String.IsNullOrEmpty(jsonAdditionalInfo))
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