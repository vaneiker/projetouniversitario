using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products
{
    public partial class UCLegacy : System.Web.UI.UserControl
    {

        public DropDownList _ddlProductName { get { return ddlProductName; } }
        public DropDownList _ddlFamilyProduct { get { return ddlFamilyProduct; } }
        public DropDownList _ddlSpouseOtherInsured { get { return ddlSpouseOtherInsured; } }
        public DropDownList _ddlAccidentalDeathBenefits { get { return ddlAccidentalDeathBenefits; } }
        public DropDownList _ddlAdditionalTermInsurance { get { return ddlAdditionalTermInsurance; } }
        public Button _btnPprofile { get { return btnPprofile; } }
        public DropDownList _ddlContributionType { get { return ddlContributionType; } }
        //public DropDownList _ddlFinancialGlobal { get { return ddlFinancialGlobal; } }
        public DropDownList _ddlInitialContribution { get { return ddlInitialContribution; } }
        public DropDownList _ddlCurrency { get { return ddlCurrency; } }
        public DropDownList _ddlInvestmentProfile { get { return ddlInvestmentProfile; } }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void readOnly(bool x)
        {
            Utility.EnableControls(frmPlan.Controls, x);
        }

        protected void TranslateDrop_PreRender(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);
            drop.Items[0].Text = Resources.NoLabel.ToUpper();
            drop.Items[1].Text = Resources.YesLabel.ToUpper();
        }
    }
}