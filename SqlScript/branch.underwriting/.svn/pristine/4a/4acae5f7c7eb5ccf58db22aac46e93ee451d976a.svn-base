using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.DReview.Pages
{
    public partial class DReview : BasePage
    {  
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = ObjServices.Language == Utility.Language.en ? "Data Review" : "Revisión de datos";
            CasesNotSubmittedContainer.setViewPrincipal += setViewPrincipal;
            HistoricalCasesContainer.setViewPrincipal += setViewPrincipal;            

        }

        public void updateView()
        {
            udpViews.Update();
        }

        public void setViewPrincipal(int index = 0, string TitleView = "")
        {
            if (index == 1)
            {
                hdnIsView.Value = "true";
                WUCView.Initialize(TitleView);
            }
            else if(index == -1){
                hdnIsView.Value = "false";
                index = 0;
                CasesNotSubmittedContainer.Initialize();
            }
            else
                hdnIsView.Value = "false";

            mtvPrincipal.ActiveViewIndex = index;
            udpViews.Update();
            udpAddNewClient.Update();
        }

        public void setView(int index = 0)
        {
            mtvMenuSup.ActiveViewIndex = index;

            if (index == 0)
            {
                var bodyContent = this.Page.Master.FindControl("bodyContent");
                var udpAddNewClient = (UpdatePanel)bodyContent.FindControl("udpAddNewClient");
                (bodyContent.FindControl("containerMessage") as HiddenField).Value = "body";
                udpAddNewClient.Update();
                DReviewContainer.setActiveView(0);
                DReviewContainer.FillData();
            }
        }      

        public void ManageTabs(object sender, EventArgs e)
        {
            var Tab = ((LinkButton)sender).ClientID;
            switch (Tab)
            {
                case "lnkDataReview":
                    DReviewContainer.setActiveView(0);
                    DReviewContainer.Initialize();
                    (this.Master.FindControl("bodyContent").FindControl("containerMessage") as HiddenField).Value = "body";
                    mtvMenuSup.SetActiveView(vDataReview);
                    break;
                case "lnkHistoricalCases":
                    HistoricalCasesContainer.Initialize();
                    mtvMenuSup.SetActiveView(vHistoricalCases);
                    break;
                case "lnkCasesNotSubmitted":
                    CasesNotSubmittedContainer.Initialize();
                    mtvMenuSup.SetActiveView(vCasesNotSubmitted);
                    break;
                case "lnkAdministrator":
                    mtvMenuSup.SetActiveView(vAdministrator);
                    break;
            }

            setViewPrincipal();
        }
    }
}