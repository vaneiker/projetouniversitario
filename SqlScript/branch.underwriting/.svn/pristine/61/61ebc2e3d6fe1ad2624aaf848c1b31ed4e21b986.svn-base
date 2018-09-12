using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData.ProductControls
{
    public partial class VIDA : System.Web.UI.UserControl
    {
        public delegate void FillProfileData(int val);
        public event FillProfileData FillProfileDataP;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPersonalizedProfile_Click(object sender, EventArgs e)
        {
            FillProfileDataP(int.Parse(ddlInvestmentProfile.SelectedValue.Split('|')[0]));
        }
    }
}