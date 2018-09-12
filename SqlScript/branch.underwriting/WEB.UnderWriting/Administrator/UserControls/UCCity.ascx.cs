using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Administrator.UserControls
{
    public partial class UCCity : System.Web.UI.UserControl
    {
        public class Item
        {
            string City_Desc { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Item> item = new List<Item>();
                gvCity.DataSource = item;
                gvCity.DataBind();
            }

        }


        protected void gvCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}