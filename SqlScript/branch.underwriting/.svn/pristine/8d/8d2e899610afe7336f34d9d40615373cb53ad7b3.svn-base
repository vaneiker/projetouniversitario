using System;
using Statetrust.Framework.Web.WebParts.Pages;

namespace Web.SubmittedPolicies.Life.Pages
{
    public partial class Life : STFMainPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkIssue_OnClick(object sender, EventArgs e)
        {
            mvLife.SetActiveView(vIssue);
            liIssue.Attributes.Add("class", "activo");
            liNeverIssued.Attributes.Add("class", "");
            UCIssueContainer.FillData();
        }

        protected void lnkNeverIssued_OnClick(object sender, EventArgs e)
        {
            mvLife.SetActiveView(vNeverIssued);
            liIssue.Attributes.Add("class", "");
            liNeverIssued.Attributes.Add("class", "activo");
            UCNeverIssued.FillData();
        }

      
    }
}