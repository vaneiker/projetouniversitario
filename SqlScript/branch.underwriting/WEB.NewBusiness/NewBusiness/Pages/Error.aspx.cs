using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var QueryString = Request.QueryString["msg"];
            if (!string.IsNullOrEmpty(QueryString))
                ltMsg.Text = QueryString;
        }

        protected void btnGoToLoby_Click(object sender, EventArgs e)
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["SecurityLogin"];
            Response.Redirect(url);
        }

        protected void btnGoToLoby_PreRender(object sender, EventArgs e)
        {
            (sender as Button).Text = RESOURCE.UnderWriting.NewBussiness.Resources.gotothelobby;
        }
    }
}