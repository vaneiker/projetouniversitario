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
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness
{
    public partial class Business : STFMainMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            STFCUserProfile1.ChangeCompany += ChangeCompany;
            hdnhighlightedFieldRequired.Value = ConfigurationManager.AppSettings["highlightedFieldRequired"].ToString();
            hdnURLLogin.Value = ConfigurationManager.AppSettings["SecurityLogin"].ToString();

            RequiredFileSize.Value = ConfigurationManager.AppSettings["RequiredFileSize"];
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            var hdnLang = this.FindControl("STFCUserProfile1").FindControl("hdnLang") as System.Web.UI.WebControls.HiddenField;
            var idioma = hdnLang.Value;
            btnProfile.Attributes["class"] = idioma == "en" ? "show_profileEN" : "show_profileES";
            btnTools.Attributes["class"] = idioma == "en" ? "toolbar_btnEN" : "toolbar_btnES";
            hdnGetDate.Value = DateTime.Now.ToString("MM/dd/yyyy");
        }

        public void ChangeCompany(int companyId)
        {
            WUCTopMenu.changeLogo(companyId);
            ((Common.BasePage)(bodyContent.Page)).SetCompany(companyId);
        }

        protected void btnDummy_Click(object sender, EventArgs e)
        {
            var x = string.Empty;
        }
    }
}