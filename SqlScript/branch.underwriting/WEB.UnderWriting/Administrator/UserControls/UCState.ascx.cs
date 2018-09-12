using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Administrator.UserControls
{
    public partial class UCState : System.Web.UI.UserControl
    {

                public class Item
        {
                    string State_Desc { get; set; }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Item> item = new List<Item>();
                gvState.DataSource = item;
                gvState.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }


        protected void gvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}