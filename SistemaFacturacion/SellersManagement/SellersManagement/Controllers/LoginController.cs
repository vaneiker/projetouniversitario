using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using SellersManagement.CustomCode;

namespace SellersManagement.Controllers
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

        // GET: Login
        public ActionResult Login()
        {
            var controller = "Home";
            var action = "Index";

            var newController = "Home";
            var newAction = "Index";

            if (WebConfigurationManager.AppSettings["ApplySecurity"].ToString() == "false")
            {
                var userId = 0;
                string userLogin = "PTECNOLOGIA";//mamercedes --> outiiz/77lQ= || defaultuser || PTECNOLOGIA --> UjAsEkU/BxXlACKm4mdWkg== || 
                if (!Login(userLogin, "outiiz/77lQ=", ref userId))
                {
                    return RedirectToAction(action, controller);
                }

                SetLoginInformation();
                
                setOthersValues(ref newController, ref newAction);

                deleteCookie();

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


                    setOthersValues(ref newController, ref newAction);

                    deleteCookie();

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


            //return RedirectToAction(action, new { currentUserName = Usuario.UserLogin, Controller = controller });
            return RedirectToAction(action, new { Controller = controller });
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


                ActionModel = new CustomCode.Utility.ActionModel
                {
                    ActionJson = additionalInfo.Action
                };
            }
        }


        private void deleteCookie()
        {

            if (Request.Cookies["WasloadData"] != null)
            {
                var c = new HttpCookie("WasloadData");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

        }

    }
}