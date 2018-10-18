﻿using KSI.Cobranza.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Statetrust.Framework.Security.Bll;
using Statetrust.Framework.Web.Mvc.WebParts.Controllers;
using System.Web.Security;
using System.Data.Entity;
using KSI.Recaudo.Web.Util;
using KSI.Recaudo.Web.Seguridad;
using System.Web.Configuration;
using System.Globalization;
using KSI.Cobranza.Web.Models.ViewModels;

namespace KSI.Cobranza.Web.Controllers
{
    public class BaseController : STFMainController
    {
        protected Usuarios vUsr
        {
            get { return GetCurrentUsuario(); }
        }

        public bool HideVaribleURL;

        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Alert.TempDataKey] = alerts;
        }

        protected Usuarios GetCurrentUsuario()
        {
            var sessionManager = Statetrust.Framework.Security.Core.Util.SessionManager.Get(Session);

            if (sessionManager == null)
                return null;
            else
                return Usuario;
        }

        protected IEnumerable<string> GetErrorsFromModel()
        {
            var ModelErrorList = new List<string>(0);

            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    ModelErrorList.Add(error.ErrorMessage);
                }
            }

            return
                ModelErrorList
                .ToArray();
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

        public void ValidateUserAccess()
        {
            var usuario = GetCurrentUsuario();
            if (usuario == null)
            {
                Response.Redirect(WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture));
            }
        }

        public PartialViewResult _ModelErrorList(string errorList)
        {
            var model = Utility.deserializeJSON<List<string>>(errorList);
            return
                    PartialView(model);
        }
    }
}