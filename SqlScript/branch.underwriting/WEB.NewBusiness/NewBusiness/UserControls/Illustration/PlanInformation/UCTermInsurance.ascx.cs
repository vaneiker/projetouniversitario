using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation
{
    public partial class UCTermInsurance : System.Web.UI.UserControl
    {

        public DropDownList _ddlSpecialPayment { get { return this.ddlSpecialPayment; } }
        public DropDownList _ddlFrequencyPayment { get { return this.ddlFrequencyPayment; } }
        public DropDownList _ddlContributionType { get { return this.ddlContributionType; } }
        public DropDownList _ddlFinancialInstitution { get { return this.ddlFinancialInstitution; } }
        public TextBox _txtSpecialPayment { get { return  txtSpecialPayment; } }
        public TextBox _txtContributionPeriodMonth { get { return this.txtContributionPeriodMonth; } }
        public TextBox _txtContributionPeriod { get { return txtContributionPeriod; } }
        public TextBox _txtFinancingRate { get { return txtFinancingRate; } }
        #region Div Properties
        public HtmlGenericControl _divSpecialPayment { get { return divSpecialPayment; } }
        public HtmlGenericControl _divPaymentSpecial { get { return divPaymentSpecial; } }
        public HtmlGenericControl _divFinancialInstitution { get { return divFinancialInstitution; } }
        public HtmlGenericControl _divFinancigRateAndDestiny { get { return divFinancigRateAndDestiny; } }
        public DropDownList _ddlDestinyFund { get { return this.ddlDestinyFund; } }
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlSpecialPayment_PreRender(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);
            drop.Items[0].Text = Resources.NoLabel.ToUpper();
            drop.Items[1].Text = Resources.YesLabel.ToUpper();
        }

        protected void ddlFinancialInstitution_PreRender(object sender, EventArgs e)
        {

        }
    }
}