using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Linq;
using DevExpress.Web;
using Web.SubmittedPolicies.Common.Classes;
using Web.SubmittedPolicies.Common.Interfaces;
using System.Web.UI;
using Statetrust.Framework.Web.JSTools;
using Web.SubmittedPolicies.PolicyService;

namespace Web.SubmittedPolicies.Life.UserControls.NeverIssued
{
    public partial class NeverIssued : Uc, IUc
    {
        private const string GridKeyExpression = "Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Step_Type_Id;Step_Id;Step_Case_No";
        protected void Page_Load(object sender, EventArgs e)
        {
            UCEditNeverIssued1.LoadNeverIssued += CloseEditPop;
        }

        protected void dsNeverIssued_OnSelecting(object sender, LinqServerModeDataSourceSelectEventArgs e)
        {
            e.KeyExpression = GridKeyExpression;
            e.QueryableSource = Common.Classes.Common.DataService.GetNeverIssuedPolicies();
            gvNeverIssued.FocusedRowIndex = -1;
        }

        protected void gvNeverIssued_OnRowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.VisibleIndex < 0) return;

            var keyPolicy = gvNeverIssued.GetRowValues(e.VisibleIndex, GridKeyExpression).ToString().Split('|');
            if (!keyPolicy.Any()) return;
            var keyItem = new Common.Classes.Common.PolicyKeyItem
            {
                CorpId = int.Parse(keyPolicy[0]),
                RegionId = int.Parse(keyPolicy[1]),
                CountryId = int.Parse(keyPolicy[2]),
                DomesticregId = int.Parse(keyPolicy[3]),
                StateProvId = int.Parse(keyPolicy[4]),
                CityId = int.Parse(keyPolicy[5]),
                OfficeId = int.Parse(keyPolicy[6]),
                CaseSeqNo = int.Parse(keyPolicy[7]),
                HistSeqNo = int.Parse(keyPolicy[8]),
                StepTypeId = int.Parse(keyPolicy[9]),
                StepId = int.Parse(keyPolicy[10]),
                StepCaseNo = int.Parse(keyPolicy[11])
            };

            switch (e.CommandArgs.CommandName)
            {
                case "Edit":
                    //Fill Popup Data
                    UCEditNeverIssued1.PolicyKey = keyItem;
                    UCEditNeverIssued1.FillData();

                    //Show Popup
                    mpEditNeverIssued.Show();
                    hdnShowEditNeverIssued.Value = "true";
                    break;
            }
        }

        protected void gvNeverIssued_OnFocusedRowChanged(object sender, EventArgs e)
        {
        }

        public void Translator(Enums.Languages lang)
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
            gvNeverIssued.DataBind();
        }

        protected void btnNIREnviar_OnClick(object sender, EventArgs e)
        {
            try
            {
                var policyService = new PolicyServiceClient();
                var policyListString = new List<String>();
                const string json = @"
                    {
                        ""TestPropertyA"" : ""TestPropertyValue"",
                        ""TestPropertyB"" : 1,
                        ""TestPropertyC"" : false
                    }";

                var policiesList = new List<Common.Classes.Common.PolicyKeyItem>();

                for (var i = 0; i < gvNeverIssued.VisibleRowCount; i++)
                {
                    var dataColumn = gvNeverIssued.DataColumns[10];
                    var chkSelect = gvNeverIssued.FindRowCellTemplateControl(i, dataColumn, "chkIssueSelecst");
                    if (chkSelect == null) continue;
                    if (!((ASPxCheckBox)chkSelect).Checked) continue;

                    var values = gvNeverIssued.GetRowValues(i, gvNeverIssued.KeyFieldName).ToString().Split('|');

                    //Get Key Info from Grid
                    var keyItem = new Common.Classes.Common.PolicyKeyItem()
                    {
                        CorpId = Convert.ToInt32(values[0]),
                        RegionId = Convert.ToInt32(values[1]),
                        CountryId = Convert.ToInt32(values[2]),
                        DomesticregId = Convert.ToInt32(values[3]),
                        StateProvId = Convert.ToInt32(values[4]),
                        CityId = Convert.ToInt32(values[5]),
                        OfficeId = Convert.ToInt32(values[6]),
                        CaseSeqNo = Convert.ToInt32(values[7]),
                        HistSeqNo = Convert.ToInt32(values[8]),
                        StepTypeId = Convert.ToInt32(values[9]),
                        StepId = Convert.ToInt32(values[10]),
                        StepCaseNo = Convert.ToInt32(values[11])
                    };

                    policyListString.Add(values[12]);
                    policiesList.Add(keyItem);
                }

                if (!policiesList.Any()) return;
                //Send Policies to Advisor
                SubmitAsync(policyService, policyListString.ToArray(), json);

                //Change Policy Status
                Common.Classes.Common.DataService.ChangePolicyStatus(policiesList, Common.Classes.Common.CurrentUserId);

                //Refresh Grid
                FillData();
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        private void CloseEditPop()
        {
            mpEditNeverIssued.Hide();
            hdnShowEditNeverIssued.Value = "false";
            gvNeverIssued.DataBind();
        }

        static async void SubmitAsync(IPolicyService proxy, string[] policyArray, string json)
        {
            var task1 = proxy.SubmitNeverIssuedAsync(policyArray, json);
        }
    }
}