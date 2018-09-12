using System;
using System.Web.UI;

namespace WEB.UnderWriting.Dashboard.UserControls.Common
{
    public partial class Left : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                //mvContentener.SetActiveView(vGroupedView);
                //WUCGroupedView.FillData();
            }
            
        }

        private void DisableViewState()
        {
              //WUCGraph.ViewStateModeControl(false);
              //WUCDetailedView.ViewStateModeControl(false);
              //WUCGroupedView.ViewStateModeControl(false);
        }

        private void UnselectedAll()
        {
            //btnDetailedView.CssClass = string.Empty;
            //btnGroupedView.CssClass = string.Empty;
            //btnGraph.CssClass = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //mvContentener.SetActiveView(vGroupedView);
            
            //DisableViewState();
            //WUCGroupedView.ViewStateModeControl(true);
            //WUCGroupedView.FillData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //mvContentener.SetActiveView(vDetailedView);
            
            //DisableViewState();
            //WUCDetailedView.ViewStateModeControl(true);
            //WUCDetailedView.FillData();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //mvContentener.SetActiveView(vGraph);
            //DisableViewState();
            //WUCGraph.ViewStateModeControl(true);
        }
    }
}