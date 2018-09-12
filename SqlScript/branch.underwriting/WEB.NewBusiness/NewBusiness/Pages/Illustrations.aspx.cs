using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class Illustrations : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAgentId.Value = ObjServices.Agent_LoginId.ToString();

            if (!IsPostBack)
            {
                var selectedTab = ObjServices.TabRedirect;
                var hdnCurrentMenuSelectedMenuLeft = this.Master.FindControl("hdnCurrentMenuSelectedMenuLeft");

                if (hdnCurrentMenuSelectedMenuLeft != null)
                    ((HiddenField)hdnCurrentMenuSelectedMenuLeft).Value = "MenulnkIllustrations";

                WUCIllustrationsList.Initialize();
            }
        }        
    }
}
