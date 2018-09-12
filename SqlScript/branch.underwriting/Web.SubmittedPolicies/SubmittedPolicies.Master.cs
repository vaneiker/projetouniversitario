using System;
using Statetrust.Framework.Web.WebParts.Masters;
using Web.SubmittedPolicies.Bll;

namespace Web.SubmittedPolicies
{
    public partial class SubmittedPolicies : STFMainMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            STFCUserProfile1.ChangeCompany += ChangeCompany;
        }

        public void ChangeCompany(int companyId)
        {
            Common.Classes.Common.CurrentCompanyId = companyId;
            Common.Classes.Common.DataService = new SubmittedPoliciesService(companyId);
            lnkCompanyLogo.CssClass = Common.Classes.Common.CurrentCompanyId == 2 ? "logo" : "logoSTL";
        }
    }
}