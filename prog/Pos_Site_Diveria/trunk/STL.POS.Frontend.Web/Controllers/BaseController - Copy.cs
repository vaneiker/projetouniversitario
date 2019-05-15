using Statetrust.Framework.Web.Mvc.WebParts.Controllers;
using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace STL.POS.Frontend.Web.Controllers
{
#if DEBUG
     public class BaseController:  Controller
#else
    public class BaseController:  STFMainController
#endif
    {
        public const string SESSION_LANGUAGE_ID = "CURRENT_LANGUAGE_ID";

        private const string SESSION_CURRENTCULTURE = "CURRENTCULTURE";

        protected PosModel dataAccess;

        public object FormLogin { get; private set; }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            var languageId = "es-DO";
            if (Request.RequestContext.HttpContext.Session != null && Request.RequestContext.HttpContext.Session[SESSION_LANGUAGE_ID] != null)
            {
                languageId = Request.RequestContext.HttpContext.Session[SESSION_LANGUAGE_ID].ToString();
            }

            var currentCulture = CultureInfo.CreateSpecificCulture(languageId);
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;

            ViewBag.LanguageList = GetLanguageList();
            ViewBag.CurrentLanguage = languageId;

            ViewBag.User = null;

            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                var user = dataAccess.Users.FirstOrDefault(u => u.Username == User.Identity.Name && u.UserOrigin == UserOrigins.VO);
                if (user != null)
                    ViewBag.User = user;
            }

            return base.BeginExecuteCore(callback, state);
        }

        public BaseController(PosModel model) : base()
        {
            dataAccess = model;

        }

        public ActionResult ChangeLanguage(string languageId, string returnUrl)
        {
            Session[SESSION_LANGUAGE_ID] = languageId;
            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            else
                return new EmptyResult();
        }

        private Dictionary<string, string> GetLanguageList()
        {

            var current = Thread.CurrentThread.CurrentCulture.Name;

            var list = new Dictionary<string, string>();
            if (current.ToLower().StartsWith("en"))
            {
                list.Add(Helpers.Constants.ID_LANGUAGE_SPANISH, "Spanish");
                list.Add(Helpers.Constants.ID_LANGUAGE_ENGLISH, "English");
            }
            else
            {
                list.Add(Helpers.Constants.ID_LANGUAGE_SPANISH, "Español");
                list.Add(Helpers.Constants.ID_LANGUAGE_ENGLISH, "Inglés");
            }

            return list;

        }

        protected CultureInfo GetCurrentCulture()
        {
            if (Session[SESSION_CURRENTCULTURE] == null)
            {
                return CultureInfo.CreateSpecificCulture(Helpers.Constants.ID_LANGUAGE_SPANISH);
            }
            else
                return CultureInfo.CreateSpecificCulture(Session[SESSION_CURRENTCULTURE].ToString());
        }

        protected User CheckUser(string userId, string name, string surname, string email)
        {
            if (string.IsNullOrEmpty(User.Identity.Name)) //POS User
            {
                var user = dataAccess.Users.FirstOrDefault(f => f.Username == userId);

                if (user == null) //Create user
                {
                    user = new User();
                    user.DateCreated = DateTime.Now;
                    user.Email = user.Email;
                    user.LastLogin = DateTime.Now;
                    user.Name = name;
                    user.Surname = surname;
                    user.Username = userId;
                    user.UserOrigin = UserOrigins.POS;
                    dataAccess.Users.Add(user);
                }
                return user;
            }
            else // Agent or suscriptor (in a future)
            {
                var user = dataAccess.Users.FirstOrDefault(f => f.Username == User.Identity.Name);
                return user;
            }

        }

    }
}