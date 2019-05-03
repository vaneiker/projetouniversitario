using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ShipLogs.Frontend.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/
        public ActionResult Login()
        {
            //redirecionar a la pantalla de bienvenida
            var controller = "Home";//esto es a modo de ejemplo hasta que se termine de desarrollar
            var action = "Index";   //esto es a modo de ejemplo hasta que se termine de desarrollar

            if (WebConfigurationManager.AppSettings["ApplySecurity"].ToString(CultureInfo.InvariantCulture) == "false")
            {
                var userId = 0;

                if (!Login("pveneiker", "outiiz/77lQ=", ref userId))
                    return RedirectToAction(action, controller);
                SetLoginInformation();
                //CheckDbUser(Usuario.UserLogin, Usuario.Email);
                // action = "QuotationSearch";
                //FormsAuthentication.SetAuthCookie(Usuario.UserLogin, true);
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


                    var route = SetLoginInformation();
                    //CheckDbUser(loginName, email);

                    action = "Index";
                    //FormsAuthentication.SetAuthCookie(loginName, true);
                }
                else
                    return Redirect(WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture));
            }


            return RedirectToAction(action, controller);
        }

    }
}