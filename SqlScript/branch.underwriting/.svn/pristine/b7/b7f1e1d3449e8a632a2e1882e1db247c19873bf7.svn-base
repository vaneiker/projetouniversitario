using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class SubmittedPolicies : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            if (!IsPostBack)
            {                   
                var hdnCurrentMenuSelectedMenuLeft = this.Master.FindControl("hdnCurrentMenuSelectedMenuLeft");
                if (hdnCurrentMenuSelectedMenuLeft != null)
                    ((HiddenField)hdnCurrentMenuSelectedMenuLeft).Value = "MenulnkSubmitted";
                WUCSubmittedPolicies.Initialize();
            }
        }
      

        protected void ManageTabs(object sender, EventArgs e)
        {
            //Change Tab
            var Tab = ((LinkButton)sender).ClientID;
            var ltTitle = (WUCSearch.FindControl("ltTitle") as Literal);
            WUCSearch.FillDrop();
            WUCSearch.CleanControl();

            switch (Tab)
            {
                case "lnkSubmittedPolicies":
                    WUCSubmittedPolicies.Initialize();
                    mtvViews.SetActiveView(vSubmittedPolicies);
                   // ltTitle.Text = "SUBMITTED POLICES ON DATA REVIEW";
                    break;
                case "lnkEffectivePendingReceipt":
                    WUCEffectivePendingReceipt.Initialize();
                    mtvViews.SetActiveView(vEffectivePendingReceipt);
                   // ltTitle.Text = "EFFECTIVE PENDING RECEIPT";
                    break;
            }

            hdnCurrentTabSubmittedPolicies.Value = Tab;
        }
    }
}