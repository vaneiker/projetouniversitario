using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.DReview.UserControl.CasesNotSubmitted
{
    public partial class CasesNotSubmittedContainer : UC
    {
        public delegate void setViewPrincipalHandler(int index, string TitleView);
        public event setViewPrincipalHandler setViewPrincipal;

        public void setView(int index, string TitleView)
        {
            setViewPrincipal(index, TitleView);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WUCCasesInProcess.setViewPrincipal += setView;
            WUCReadyToReview.setViewPrincipal += setView;
        }       

        public void Initialize()
        {
            WUCCasesInProcess.FillData();
            hdnCurrentTabCasesNoSubmitted.Value = "lnkCasesInProcess";
            mtvCasesNotSubmitted.SetActiveView(vCasesInProcess);
        }

        public void ManageTab(object sender, EventArgs e)
        {
            var ButtonSender = (LinkButton)sender;
            var Tab = ButtonSender.ID;
            switch (Tab)
            {
                case "lnkCasesInProcess":
                    WUCCasesInProcess.Initialize();
                    mtvCasesNotSubmitted.SetActiveView(vCasesInProcess);
                    break;
                case "lnkReadyToReview":
                    WUCReadyToReview.Initialize();
                    mtvCasesNotSubmitted.SetActiveView(vReadyToReview);
                    break;
            }

            hdnCurrentTabCasesNoSubmitted.Value = Tab;

        }
    }
}