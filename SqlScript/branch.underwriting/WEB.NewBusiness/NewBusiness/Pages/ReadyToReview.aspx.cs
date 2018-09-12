using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class ReadyToReview : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                ObjServices.IsDataReviewMode = false;
                var hdnCurrentMenuSelectedMenuLeft = this.Master.FindControl("hdnCurrentMenuSelectedMenuLeft");
                if (hdnCurrentMenuSelectedMenuLeft != null)
                    ((HiddenField)hdnCurrentMenuSelectedMenuLeft).Value = "MenulnkReadyToReview";
            }
        }
    }
}