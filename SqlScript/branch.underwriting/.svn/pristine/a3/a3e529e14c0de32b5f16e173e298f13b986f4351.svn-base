using Statetrust.Framework.Web.WebParts.Masters;
using System;

namespace WEB.UnderWriting.Case
{
    public partial class Case : STFMainMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            STFCUserProfile1.ChangeCompany += ChangeCompany;

            STFCUserProfile1.NewAnchorAttr("lnk", "lnk");
            STFCUserProfile1.NewAnchorAttr("onClick", "setCurrentAccordeon(this,'#hfPolicyPlanDataAccordeon');");
            STFCUserProfile1.NewAnchorAttr("class", "trigger");
        }

        public void ChangeCompany(int companyId)
        {
            ((Common.BasePage)(ContentGridAllCases.Page)).SetUWCompany(companyId);
            WUCMainMenu.ChangeLogo();
        }
    }
}