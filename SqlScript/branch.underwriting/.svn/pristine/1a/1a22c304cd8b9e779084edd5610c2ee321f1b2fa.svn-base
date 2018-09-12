using Statetrust.Framework.Web.WebParts.Pages;
using System;

namespace WEB.UnderWriting.Common
{
    public class BasePage : STFMainPage//System.Web.UI.Page 
    {
        public Services Service
        {
            get { return Session["ID"] != null ? new Services(Session["ID"].ToString()) : new Services(); }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            DevExpress.Data.Helpers.ServerModeCore.DefaultForceCaseInsensitiveForAnySource = true;
        }

        public void SetUWCompany(int companyId)
        {
            Service.CompanyId = companyId;
        }
    }
}