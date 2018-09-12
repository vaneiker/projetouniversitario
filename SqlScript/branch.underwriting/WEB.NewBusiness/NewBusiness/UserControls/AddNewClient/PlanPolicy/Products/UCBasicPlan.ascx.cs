using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products
{
    public partial class UCBasicPlan : System.Web.UI.UserControl
    {
        public DropDownList _ddlProductName { get { return ddlProductName; } }
        public DropDownList _ddlFamilyProduct { get { return ddlFamilyProduct; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void readOnly(bool x)
        {
            Utility.EnableControls(frmPlan.Controls, x);
        }

        protected void ddlFamilyProduct_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}