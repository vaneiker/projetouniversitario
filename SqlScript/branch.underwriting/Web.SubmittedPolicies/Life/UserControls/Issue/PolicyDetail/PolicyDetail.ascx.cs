using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.SubmittedPolicies.Bll.Poco;

namespace Web.SubmittedPolicies.Life.UserControls.Issue.PolicyDetail
{
    public partial class PolicyDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FillData(PolicyData policyDetail = null)
        {
            if (policyDetail == null)
            {
                //OwnerInfo
                txtOName.Text = "-";
                txtOCountryResidence.Text = "-";
                txtOCountryBirh.Text = "-";
                txtOAnnualIncome.Text = "-";

                //InsuredInfo
                txtIName.Text = "-";
                txtICountryResidence.Text = "-";
                txtIBgck.Text = "-";
                txtISmoker.Text = "-";

                //PolicyInfo
                txtPAnnualPremium.Text = "-";
                txtPApplicationDate.Text = "-";
                txtPInitialPremium.Text = "-";
                txtPInsuredAmount.Text = "-";
                txtPPeriodicPremium.Text = "-";
                txtPProductType.Text = "-";
                txtPUnderwriter.Text = "-";
                txtPYearsConstribution.Text = "-";
            }
            else
            {
                //OwnerInfo
                txtOName.Text = policyDetail.OwnerFullName;
                txtOCountryResidence.Text = policyDetail.Country_Of_Residence_Desc_Owner;
                txtOCountryBirh.Text = policyDetail.Country_Of_Birth_Desc_Owner;
                txtOAnnualIncome.Text = policyDetail.Annual_Personal_Income_F;

                //InsuredInfo
                txtIName.Text = policyDetail.InsuredFullName;
                txtICountryResidence.Text = policyDetail.Country_Of_Residence_Desc_Insured;
                txtIBgck.Text = policyDetail.BackgroundCheckResult_Desc;
                txtISmoker.Text = policyDetail.Smoker_Insured_Desc;

                //PolicyInfo
                txtPAnnualPremium.Text = policyDetail.Annual_premiun_F;
                txtPApplicationDate.Text = policyDetail.ApplicationDate_F;
                txtPInitialPremium.Text = policyDetail.Initial_Premium_F;
                txtPInsuredAmount.Text = policyDetail.Insured_Amount_F;
                txtPPeriodicPremium.Text = policyDetail.Periodic_Premium_F;
                txtPProductType.Text = policyDetail.Product_Desc;
                txtPUnderwriter.Text = policyDetail.Underwriter_Name;
                txtPYearsConstribution.Text = policyDetail.Contribution_Years_F;
            }
        }
    }
}