using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products
{
    public partial class UCAxy : UC
    {
        public DropDownList _ddlProductName { get { return ddlProductName; } } 
        public DropDownList _ddlFamilyProduct { get { return ddlFamilyProduct; } }
        public DropDownList _ddlInitialContribution { get { return ddlInitialContribution; } }
        public DropDownList _ddlCurrency { get { return ddlCurrency; } }                      
        public Button _btnPprofile { get { return btnPprofile; } }                            
        public DropDownList _ddlInvestmentProfile { get { return ddlInvestmentProfile; } }    
        public RadioButton _si1 { get { return si1; } set { si1.Checked = value.Checked; } }  
        public RadioButton _no1 { get { return no1; } set { no1.Checked = value.Checked; } }  

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void readOnly(bool x)
        {
            Utility.EnableControls(frmPlan.Controls, x);
        }

        protected void ddlInitialContribution_PreRender(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);
            drop.Items[0].Text = Resources.NoLabel.ToUpper();
            drop.Items[1].Text = Resources.YesLabel.ToUpper();
        }        
    }
}