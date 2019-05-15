using Statetrust.Framework.Security.Bll;
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
using System.Data.Entity;

namespace STL.POS.Frontend.Web.Controllers
{

    public class BaseController : STFMainController
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


            ViewBag.UserOrigin = UserOrigins.POS;

            var usuario = GetCurrentUsuario();

            if (usuario != null)//!string.IsNullOrEmpty(User.Identity.Name))
            {
                var user = dataAccess.Users.FirstOrDefault(u => u.Username == usuario.UserLogin && u.UserOrigin == UserOrigins.VO);
                if (user != null)
                {
                    ViewBag.UserOrigin = UserOrigins.VO;
                    ViewBag.CurrentUserFullName = user.GetFullName();
                    ViewBag.UserType = user.UserType;
                }
            }

            return base.BeginExecuteCore(callback, state);
        }

        public BaseController(PosModel model)
            : base()
        {
            dataAccess = model;

        }

        public ActionResult Change_Language(string languageId, string returnUrl)
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

        protected Usuarios GetCurrentUsuario()
        {
            var sessionManager = Statetrust.Framework.Security.Core.Util.SessionManager.Get(Session);

            if (sessionManager == null)
                return null;
            else
                return Usuario;
        }

        protected User CheckUser(string userId, string name, string surname, string email, int? agentId = null)
        {
            var usuario = GetCurrentUsuario();
            if (usuario == null) //POS User
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
            else // User, Agent or suscriptor
            {
                User user = null;
                User suscriptorUser = null;

                if (usuario.UserType == Usuarios.UserTypeEnum.User)
                {
                    user = dataAccess.Users.FirstOrDefault(f => f.Username == userId && f.UserType == UserType.WebUser);
                }
                else //Agent or suscriptor
                {
                    user = dataAccess.Users.FirstOrDefault(f => f.Username == userId && f.UserType == UserType.Agent);
                    suscriptorUser = dataAccess.Users.FirstOrDefault(f => f.Username == usuario.UserLogin && f.UserType == UserType.Subscriptor);
                }

                if (user == null) //Create user
                {
                    var realAgent = getAgenteUserInfo(userId);

                    user = new User();
                    user.DateCreated = DateTime.Now;
                    user.Email = email;
                    user.LastLogin = DateTime.Now;
                    user.Name = name;
                    user.Surname = surname;
                    user.Username = userId;
                    user.UserOrigin = UserOrigins.VO;
                    user.UserType = usuario.UserType == Usuarios.UserTypeEnum.User ? UserType.WebUser : UserType.Agent;
                    user.Suscriptor = suscriptorUser;
                    user.AgentId = realAgent != null ? realAgent.AgentId : agentId;
                    dataAccess.Users.Add(user);
                }
                else
                {
                    if (user.Suscriptor == null)
                    {
                        user.Suscriptor = suscriptorUser;
                    }
                    if (user.AgentId == null || user.AgentId == 0)
                    {
                        var realAgent = getAgenteUserInfo(userId);

                        user.AgentId = realAgent != null ? realAgent.AgentId : agentId;
                    }
                }

                return user;
            }
        }

        protected User CheckQuotationHasUser(int quotationID)
        {
            User user = null;

            var quotation = (from q in dataAccess.Quotations.OfType<QuotationAuto>().Include("User")
                             where q.Id == quotationID
                             select q).FirstOrDefault() as QuotationAuto;

            if (quotation != null)
            {
                //var USERDEFAULT= Convert.ToInt32(dataAccess.GetParameter(Parameter.PARAMETER_KEY_COD_INTERMEDIARIO, "10562").Value);

                if (quotation.User != null && quotation.User.AgentId.HasValue)
                {
                    //usuario que tiene la cotizacion agregada
                    string nameidAgentQuo = quotation.User.Username;
                    var agentIDAgentQuo = quotation.User.AgentId;

                    user = dataAccess.Users.FirstOrDefault(f => f.Username == nameidAgentQuo && f.UserType == UserType.Agent);
                    if (user == null)
                    {
                        user = dataAccess.Users.FirstOrDefault(f => f.AgentId == agentIDAgentQuo && f.UserType == UserType.Agent);
                    }
                }
                /*else
                {
                    user = dataAccess.Users.FirstOrDefault(f => f.Username == actualAgentNameID && f.UserType == UserType.Agent);
                }*/

            }
            return user;
        }


        public int? GetCurrentUserID()
        {
            var usuario = GetCurrentUsuario();
            if (usuario != null)
            {
                return usuario.UserID;
            }

            return null;
        }


        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }


        public string TranslateStepBuy1(string value)
        {
            var newValue = "";
            newValue = Globalization.PosAuto.StepBuy1.ResourceManager.GetString(value.Replace("-", "").Replace("-", "").Trim());

            if (!string.IsNullOrEmpty(newValue))
            {
                return newValue;
            }

            return value;
        }

        /// <summary>
        /// 1 (true) = Solo usuarios Logueados, 0(false) =  Todo el mundo
        /// </summary>
        /// <returns></returns>
        public bool allowOnlyLoggedUsers()
        {
            /*
           1 = Solo usuarios Logueados
           0 =  Todo el mundo
           */
            var onlyLoggedUsers = System.Web.Configuration.WebConfigurationManager.AppSettings["PARAMETER_KEY_ONLY_LOGGED_USER"].ToString(CultureInfo.InvariantCulture);

            return onlyLoggedUsers == "1";
        }
    }
}