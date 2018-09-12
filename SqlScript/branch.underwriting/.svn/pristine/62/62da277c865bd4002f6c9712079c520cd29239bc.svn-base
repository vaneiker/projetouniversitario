using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Administrator.UserControls
{
    public partial class UCAgent : System.Web.UI.UserControl
    {
        public class Item
        {
            string Agent_Desc { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Item> item = new List<Item>();
                gvAgent.DataSource = item;
                gvAgent.DataBind();
            }
        }

        protected void gvAgent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}