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
    public partial class UCLightHouse : System.Web.UI.UserControl
    {
        public DropDownList _ddlProductName { get { return ddlProductName; } }
        public DropDownList _ddlFamilyProduct { get { return ddlFamilyProduct; } }
        public DropDownList _ddlSpouseOtherInsured { get { return ddlSpouseOtherInsured; } }
        public DropDownList _ddlAccidentalDeathBenefits { get { return ddlAccidentalDeathBenefits; } }
        public DropDownList _ddlAdditionalTermInsurance { get { return ddlAdditionalTermInsurance; } }
        public DropDownList _ddlCritialIllness { get { return ddlCritialIllness; } }
        public DropDownList _ddlContributionType { get { return ddlContributionType; } }
        public DropDownList _ddlInitialContribution { get { return ddlInitialContribution; } }
        public DropDownList _ddlCurrency { get { return ddlCurrency; } }
        public System.Web.UI.HtmlControls.HtmlGenericControl _divDllFinancialInstitucionGroup { get { return divDllFinancialInstitucionGroup; } }
        
        public System.Web.UI.HtmlControls.HtmlGenericControl _divSpecialPayment { get { return divSpecialPayment; } }

        public System.Web.UI.HtmlControls.HtmlGenericControl _divDestinyFund { get { return divDestinyFund; } }

        #region Component Data
        public DropDownList _ddlSpecialPayment { get { return ddlSpecialPayment; } }

        
        public System.Web.UI.WebControls.DropDownList _ddlFinancialInstitution { get { return ddlFinancialInstitution; } }

        public System.Web.UI.WebControls.TextBox _txtSpecialPayment { get { return txtSpecialPayment; } }

        public System.Web.UI.WebControls.TextBox _txtFinancingRate { get { return txtFinancingRate; } }

        public System.Web.UI.WebControls.DropDownList _ddlDestinyFund { get { return ddlDestinyFund; } }
        #endregion        
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

        protected void ddlFinancialInstitutionTranslateDrop_PreRender(object sender, EventArgs e)
        {
            
        }

        protected void ddlCurrencySpecialPayment_PreRender(object sender, EventArgs e)
        {

        }

        protected void ddlDestinyFund_PreRender(object sender, EventArgs e)
        {

        }

        protected void ddlSpecialPayment_PreRender(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);
            drop.Items[0].Text = Resources.NoLabel.ToUpper();
            drop.Items[1].Text = Resources.YesLabel.ToUpper();
        }




    }
}