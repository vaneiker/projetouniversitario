using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products
{
    public partial class UCFunerarios : System.Web.UI.UserControl
    {
        public DropDownList _ddlProductName { get { return ddlProductName; } }
        public DropDownList _ddlFamilyProduct { get { return ddlFamilyProduct; } }
        public DropDownList _ddlCurrency { get { return ddlCurrency; } }                      
        public DropDownList _ddlInitialContribution { get { return ddlInitialContribution; } }
        public DropDownList _ddlLoteType { get { return ddlLoteType; } }
        public DropDownList _ddlLote { get { return ddlLote; } }
        public DropDownList _ddlContributionType { get { return ddlContributionType; } }                
        public DropDownList _ddlOtherInsured { get { return ddlOtherInsured; } }              
        public DropDownList _ddlRepatriation { get { return ddlRepatriation; } }              

        protected void Page_Load(object sender, EventArgs e){}

        protected void TranslateDrop_PreRender(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);
            drop.Items[0].Text = Resources.NoLabel.ToUpper();
            drop.Items[1].Text = Resources.YesLabel.ToUpper();
        }
    }
}