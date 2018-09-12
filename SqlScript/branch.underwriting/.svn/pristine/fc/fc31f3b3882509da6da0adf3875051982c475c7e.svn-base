using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.SubmittedPolicies.Bll.Poco;

namespace Web.SubmittedPolicies.Life.UserControls.Issue.PolicyDetail
{
    public partial class Riders : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FillData(List<PolicyRider> policyRiders = null)
        {
            gvRiders.DataSource = policyRiders ?? new List<PolicyRider>() ;
            gvRiders.DataBind();
        }

    }
}