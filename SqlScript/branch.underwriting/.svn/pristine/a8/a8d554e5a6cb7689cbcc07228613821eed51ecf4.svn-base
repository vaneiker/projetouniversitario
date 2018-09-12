using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Statetrust.Framework.Web;
using Statetrust.Framework.Web.WebParts.Masters;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.DReview
{
    public partial class DReviewMaster : STFMainMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            STFCUserProfile1.ChangeCompany += ChangeCompany;
            hdnURLLogin.Value = ConfigurationManager.AppSettings["SecurityLogin"].ToString();

            if (!IsPostBack)
            {
                hdnhighlightedFieldRequired.Value = ConfigurationManager.AppSettings["highlightedFieldRequired"].ToString();
                TimeRefresh.Value = ConfigurationManager.AppSettings["timeToRefresh"];
            }  

            RequiredFileSize.Value = ConfigurationManager.AppSettings["RequiredFileSize"];
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            var hdnLang = this.FindControl("STFCUserProfile1").FindControl("hdnLang") as System.Web.UI.WebControls.HiddenField;
            var idioma = hdnLang.Value;
            btnProfile.Attributes["class"] = idioma == "en" ? "show_profileEN" : "show_profileES";
            hdnGetDate.Value = DateTime.Now.ToString("MM/dd/yyyy");
        }

        protected void ChangeTabs(object sender, EventArgs e)
        {
            var oDataReviewPage = (DReview.Pages.DReview)(bodyContent.Page);
            hdnCurrentTabSup.Value = ((LinkButton)sender).ID;
            oDataReviewPage.ManageTabs(sender, e);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect(ConfigurationManager.AppSettings["SecurityLogin"]);
        }

        public void ChangeCompany(int companyId)
        {
            ((Common.BasePage)(bodyContent.Page)).SetCompany(companyId);
            changeLogo(companyId);
        }

        public void changeLogo(int company)
        {
            lnkLogo.CssClass = company == 1 ? "logo_stl" : "logo_atl";
        }
    }
}