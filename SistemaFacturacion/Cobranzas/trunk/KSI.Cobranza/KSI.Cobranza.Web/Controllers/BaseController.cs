using KSI.Cobranza.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Statetrust.Framework.Security.Bll;
using Statetrust.Framework.Web.Mvc.WebParts.Controllers;
using System.Web.Security;
using System.Data.Entity;
using KSI.Cobranza.Web.Util;
using KSI.Cobranza.Web.Seguridad;
using System.Web.Configuration;
using System.Globalization;
using KSI.Cobranza.Web.Models.ViewModels;
using System.Web.Helpers;

namespace KSI.Cobranza.Web.Controllers
{
    public class BaseController : STFMainController
    {
        protected string FileFolderDocs { get { return System.Configuration.ConfigurationManager.AppSettings["FileFolderDocs"]; } }
        protected string QuantityUploadDocs { get { return System.Configuration.ConfigurationManager.AppSettings["QuantityUploadDocs"]; } }
        protected string LimitUploadDocsInMb { get { return System.Configuration.ConfigurationManager.AppSettings["LimitUploadDocsInMb"]; } }
        protected string PathAttachmentTHKSI { get { return System.Configuration.ConfigurationManager.AppSettings["PathAttachmentTHKSI"]; } }
        protected string CallRexPath { get { return System.Configuration.ConfigurationManager.AppSettings["CallRexPath"]; } }
        protected bool isDebug { get { return bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsDebug"]); } }

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

        public void PrintExcel<T>(IEnumerable<T> Model) where T : class
        {
            //create object to webgrid   
            WebGrid grid = new WebGrid(source: Model, canPage: false, canSort: false);

            WebGridColumn[] Columns = {
                                       grid.Column("UserID", "UserID"),
                                       grid.Column("Name", "Name"),
                                       grid.Column("Email", "Email"),
                                       grid.Column("PhoneNumber", "PhoneNumber"),
                                       grid.Column("Status", "Status")
                                      };

            string gridData = grid.GetHtml(
            columns: grid.Columns(Columns)).ToString();
            Response.ClearContent();
            //give name to excel sheet.  
            Response.AddHeader("content-disposition", "attachment; filename=UserData.xls");
            //specify content type  
            Response.ContentType = "application/excel";
            //write excel data using this method   
            Response.Write(gridData);
            Response.End();
        }

    }
}