using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class IllustrationsLife : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var selectedTab = ObjServices.TabRedirect;
                var hdnCurrentMenuSelectedMenuLeft = this.Master.FindControl("hdnCurrentMenuSelectedMenuLeft");

                if (selectedTab == "MenulnkIllustrationsLife")
                {

                    if (hdnCurrentMenuSelectedMenuLeft != null)
                        ((HiddenField)hdnCurrentMenuSelectedMenuLeft).Value = "MenulnkIllustrationsLife";
                    ObjServices.IsSuscripcionQuotRole = true;

                    UCIllustrationsLifeList.Initialize();
                }
            }
        }
    }
}