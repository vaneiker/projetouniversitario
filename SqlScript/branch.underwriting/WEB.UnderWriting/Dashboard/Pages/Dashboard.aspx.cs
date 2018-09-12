using System;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Dashboard.Pages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var hfTabSelected = this.Page.Master.FindControl("WUCMainMenu").FindControl("hfCurrentTabSelected");

            if (hfTabSelected != null)
            {
                ((HiddenField)hfTabSelected).Value = "lnkDashboard";

            }
        }
    }
}