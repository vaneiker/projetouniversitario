using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class CardNetScreenTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form.AllKeys.Count() > 0)
                {
                    hdnReturnUrl.Value = Request.Form["ReturnUrl"];
                }
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            Response.Redirect(hdnReturnUrl.Value);
        }
    }
}