using DevExpress.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SubmittedPolicies.Life.UserControls.Processing
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public delegate void SelectGridRows(Common.Classes.Common.PolicyKeyItem keyItem = null);
        public event SelectGridRows SelectGridRowProcesing;

        private const string GridKeyExpression = "Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Step_Type_Id;Step_Id;Step_Case_No;Policy_No";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dsProcessingPolicies_OnSelecting(object sender, LinqServerModeDataSourceSelectEventArgs e)
        {
            e.KeyExpression = GridKeyExpression;
            e.QueryableSource = Common.Classes.Common.DataService.GetProcessingPolicies();
            gvProcessingPolicies.FocusedRowIndex = -1;
        }

        public void FillData()
        {
            gvProcessingPolicies.DataBind();
        }

        protected void gvProcessingPolicies_OnFocusedRowChanged(object sender, EventArgs e)
        {
            //if (gvProcessingPolicies.FocusedRowIndex < 0)
            //    SelectGridRowProcesing();
            //else
            //{
            //    var values = gvProcessingPolicies.GetRowValues(gvProcessingPolicies.FocusedRowIndex, gvProcessingPolicies.KeyFieldName).ToString().Split('|');

            //    //Get Key Info from Grid
            //    var keyItem = new Common.Classes.Common.PolicyKeyItem()
            //    {
            //        CorpId = Convert.ToInt32(values[0]),
            //        RegionId = Convert.ToInt32(values[1]),
            //        CountryId = Convert.ToInt32(values[2]),
            //        DomesticregId = Convert.ToInt32(values[3]),
            //        StateProvId = Convert.ToInt32(values[4]),
            //        CityId = Convert.ToInt32(values[5]),
            //        OfficeId = Convert.ToInt32(values[6]),
            //        CaseSeqNo = Convert.ToInt32(values[7]),
            //        HistSeqNo = Convert.ToInt32(values[8])
            //    };

            //    SelectGridRowProcesing(keyItem);
            //}
        }
    }
}