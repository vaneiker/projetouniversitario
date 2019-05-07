using Declarative.Invoicing.CustomCode.TH;
using Declarative.Invoicing.Logic;
using Declarative.Invoicing.SysflexServices;
using Statetrust.Framework.Security.Bll;
using Statetrust.Framework.Web.Mvc.WebParts.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Declarative.Invoicing.Controllers
{
    public class BaseController : STFMainController
    {
        //public BaseController()
        //{
        //    if (System.Web.HttpContext.Current.Session == null)
        //    {
        //        System.Web.HttpContext.Current.Session.Add(key, new SessionList(key));
        //        (System.Web.HttpContext.Current.Session[key] as SessionList).sessionObject = new SessionObject();
        //    }
        //    else
        //        if (System.Web.HttpContext.Current.Session[key] == null)
        //    {
        //        System.Web.HttpContext.Current.Session.Add(key, new SessionList(key));
        //        (System.Web.HttpContext.Current.Session[key] as SessionList).sessionObject = new SessionObject();
        //    }

        //    datos = (System.Web.HttpContext.Current.Session[key] as SessionList);
        //}


        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            var languageId = "es-DO";

            var currentCulture = CultureInfo.CreateSpecificCulture(languageId);
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;

            ViewBag.CurrentLanguage = languageId;

            //var usuario = GetCurrentUsuario();

            return base.BeginExecuteCore(callback, state);
        }

        protected Usuarios GetCurrentUsuario()
        {
            var sessionManager = Statetrust.Framework.Security.Core.Util.SessionManager.Get(Session);

            if (sessionManager == null)
                return null;
            else
                return Usuario;
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

        public string GetCurrentUserName()
        {
            var usuario = GetCurrentUsuario();
            if (usuario != null)
            {
                return usuario.AgentNameId;
            }

            return null;
        }

        public string GetCurrentUserLogin()
        {
            var usuario = GetCurrentUsuario();
            if (usuario != null)
            {
                return usuario.UserLogin;
            }

            return "";
        }

        public string numberFormat = "#,0.00";

        #region Managers

        protected PolicyManager oPolicyManager
        {
            get
            {
                return new PolicyManager();
            }
        }

        protected QueueManager oQueueManager
        {
            get
            {
                return new QueueManager();
            }
        }

        protected InvoiceManager oInvoiceManager
        {
            get
            {
                return new InvoiceManager();
            }
        }

        

        #endregion

        #region Services

        protected SysFlexServiceClient oSysFlexService
        {
            get
            {
                return
                    new SysFlexServiceClient();
            }
        }

        protected THSettings oTHSettings
        {
            get
            {
                return
                    new THSettings();
            }
        }


        #endregion

    }
}