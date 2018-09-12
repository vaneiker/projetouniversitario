using System;
using DevExpress.Data.Linq;
using Web.SubmittedPolicies.Common.Interfaces;

namespace Web.SubmittedPolicies.Life.UserControls.Issue
{
    public partial class Confirmation : System.Web.UI.UserControl, IUc
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Translator(Common.Classes.Enums.Languages lang)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            gvConfirmationPolicies.DataBind();
        }


        protected void dsConfirmationPolicies_OnSelecting(object sender, LinqServerModeDataSourceSelectEventArgs e)
        {
            e.KeyExpression = "Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Policy_No";
            e.QueryableSource = Common.Classes.Common.DataService.GetConfirmationPolicies();
            gvConfirmationPolicies.FocusedRowIndex = -1;
        }
    }
}