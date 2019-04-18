using SellersManagement.Logic;
using Statetrust.Framework.Security.Bll;
using Statetrust.Framework.Web.Mvc.WebParts.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SellersManagement.Controllers
{
    public class BaseController : STFMainController
    {
        //public CultureInfo culturelanguaje = CultureInfo.CreateSpecificCulture("es-DO");
        //public SessionList datos;
        //private string key = "SessionData";

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            var languageId = "es-DO";

            /*if (Request.RequestContext.HttpContext.Session != null && Request.RequestContext.HttpContext.Session[SESSION_LANGUAGE_ID] != null)
            {
                languageId = Request.RequestContext.HttpContext.Session[SESSION_LANGUAGE_ID].ToString();
            }*/

            var currentCulture = CultureInfo.CreateSpecificCulture(languageId);
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;

            //ViewBag.CurrentLanguage = languageId;

            //var usuario = GetCurrentUsuario();

            //ViewBag.UserOrigin = CommonEnums.UserOrigins.VO;
            //ViewBag.UserType = "";
            //ViewBag.isAgentUser = false;

            //ViewBag.userCanApplySurCharge = "N";

            //ViewBag.CanSeeListUsers = CanSeeListUsers;
            //if (usuario != null)
            //{
            //    ViewBag.UserType = Usuario.UserType.ToString();
            //    ViewBag.isAgentUser = (Usuario.UserType == Usuarios.UserTypeEnum.Agent || Usuario.UserType == Usuarios.UserTypeEnum.Assistant) ? true : false;
            //    ViewBag.userCanApplySurCharge = usuario.CanApplySurcharge ? "S" : "N";

            //    ViewBag.CanSeeListUsers = CanSeeListUsers;
            //    ViewBag.ListUsers = ListUsers;
            //}
            return base.BeginExecuteCore(callback, state);
        }

        public BaseController()
        {
            //if (System.Web.HttpContext.Current.Session == null)
            //{
            //    System.Web.HttpContext.Current.Session.Add(key, new SessionList(key));
            //    (System.Web.HttpContext.Current.Session[key] as SessionList).sessionObject = new SessionObject();
            //}
            //else
            //    if (System.Web.HttpContext.Current.Session[key] == null)
            //{
            //    System.Web.HttpContext.Current.Session.Add(key, new SessionList(key));
            //    (System.Web.HttpContext.Current.Session[key] as SessionList).sessionObject = new SessionObject();
            //}

            //datos = (System.Web.HttpContext.Current.Session[key] as SessionList);
        }

        protected Usuarios GetCurrentUsuario()
        {
            var sessionManager = Statetrust.Framework.Security.Core.Util.SessionManager.Get(Session);

            if (sessionManager == null)
                return null;
            else
                return Usuario;
        }

        protected bool isExecutivesATLRol()
        {
            var Usuario = GetCurrentUsuario();
            var UsuarioRoles = Usuario.rolesByUser;
            return UsuarioRoles.Any(o => o.Rol_Name.Contains("ExecutivesATL"));
        }

        protected AgentServiceReference.AgentServiceClient oAgentServices
        {
            get
            {
                return
                    new AgentServiceReference.AgentServiceClient();
            }
        }

        protected SysflexAgentServiceReference.AgentServiceClient oSysflexAgentServices
        {
            get
            {
                return
                    new SysflexAgentServiceReference.AgentServiceClient();
            }
        }

        protected DropDownManager oDropDownManager
        {
            get
            {
                return new DropDownManager();
            }
        }

        protected ManagementManager oManagementManager
        {
            get
            {
                return new ManagementManager();
            }
        }


        protected void createCookie() {

            if (Request.Cookies["WasloadData"] == null)
            {
                var c = new HttpCookie("WasloadData");
                c.Expires = DateTime.Now.AddDays(1);
                c.Path = "/";
                Response.Cookies.Add(c);
            }
        }

        public int GetLastPage(int totalRow, int rowPerPage)
        {
            int LastPage = 0;
            try
            {
                string dataCalculated = (totalRow / (decimal)rowPerPage).ToString(); // rowPerPage = Cantidad de registros por pagina;
                var pageCalculated = (totalRow / rowPerPage);


                //si tiene un punto es que la operacion tiene una pagina que se perderia y le sumo 1+ para que contemple el ult. registro
                if (dataCalculated.Contains("."))
                    LastPage = Convert.ToInt32(pageCalculated) + 1;
                else
                    LastPage = Convert.ToInt32(pageCalculated);
            }
            catch (Exception)
            {
                LastPage = 0;
            }

            return LastPage;
        }
    }
}