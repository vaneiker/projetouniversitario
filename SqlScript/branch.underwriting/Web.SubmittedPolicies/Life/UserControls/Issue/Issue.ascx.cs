using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Data.Linq;
using DevExpress.Web;
using Statetrust.Framework.Web.JSTools;
using Web.SubmittedPolicies.Common.Interfaces;
using Web.SubmittedPolicies.Bll;
using Web.SubmittedPolicies.Common.Classes;
using Web.SubmittedPolicies.PolicyService;

namespace Web.SubmittedPolicies.Life.UserControls.Issue
{
    public partial class Issue : Uc, IUc
    {
        public delegate void SelectGridRows(Common.Classes.Common.PolicyKeyItem keyItem = null);
        public event SelectGridRows SelectGridRow;

        private const string GridKeyExpression = "Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Step_Type_Id;Step_Id;Step_Case_No;Policy_No";

        protected void Page_Load(object sender, EventArgs e)
        {
            UCReject1.FillIssuePoliciesGrid += CloseRejectPop;
        }

        public void Translator(Enums.Languages lang)
        {
        }

        public void Save()
        {
        }

        public void ClearData()
        {
        }

        public void FillData()
        {
            gvIssuePolicies.DataBind();
        }

        protected void dsIssuePolicies_OnSelecting(object sender, LinqServerModeDataSourceSelectEventArgs e)
        {
            e.KeyExpression = GridKeyExpression;
            e.QueryableSource = Common.Classes.Common.DataService.GetIssuePolicies();
            gvIssuePolicies.FocusedRowIndex = -1;
        }

        protected void gvIssuePolicies_OnFocusedRowChanged(object sender, EventArgs e)
        {
            if (gvIssuePolicies.FocusedRowIndex < 0)
                SelectGridRow();
            else
            {
                var values = gvIssuePolicies.GetRowValues(gvIssuePolicies.FocusedRowIndex, gvIssuePolicies.KeyFieldName).ToString().Split('|');

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
                    HistSeqNo = Convert.ToInt32(values[8])
                };

                SelectGridRow(keyItem);
            }

        }

        protected void gvIssuePolicies_OnRowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.VisibleIndex < 0) return;

            var keyPolicy = gvIssuePolicies.GetRowValues(e.VisibleIndex, GridKeyExpression).ToString().Split('|');
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
                HistSeqNo = int.Parse(keyPolicy[8])
            };

            switch (e.CommandArgs.CommandName)
            {
                case "Reject":
                    keyItem.StepTypeId = int.Parse(keyPolicy[9]);
                    keyItem.StepId = int.Parse(keyPolicy[10]);
                    keyItem.StepCaseNo = int.Parse(keyPolicy[11]);

                    //Fill Popup Data
                    UCReject1.PolicyKey = keyItem;
                    UCReject1.FillData();

                    //Show Popup
                    mpReject.Show();
                    hdnShowReject.Value = "true";
                    break;
                case "Ammendment":
                    //Fill Popup Data
                    UCAmmendments1.PolicyKey = keyItem;
                    UCAmmendments1.FillData(true);

                    //Show Popup
                    mpAmmendments.Show();
                    hdnShowAmmendments.Value = "true";
                    break;
                case "Document":
                    //Fill Popup Data
                    UCDocuments1.PolicyKey = keyItem;
                    UCDocuments1.FillData(true);

                    //Show Popup
                    mpDocuments.Show();
                    hdnShowDocuments.Value = "true";
                    break;
            }
        }

        private void CloseRejectPop()
        {
            mpReject.Hide();
            hdnShowReject.Value = "false";
            FillData();
            SelectGridRow(null);
        }

        protected void lnkEmitir_OnClick(object sender, EventArgs e)
        {

            try
            {
                var policyService = new PolicyServiceClient();
                var policyListString = new List<String>();
                var policiesList = new List<Common.Classes.Common.PolicyKeyItem>();
                const string json = @"
                    {
                        ""TestPropertyA"" : ""TestPropertyValue"",
                        ""TestPropertyB"" : 1,
                        ""TestPropertyC"" : false
                    }";

                for (var i = 0; i < gvIssuePolicies.VisibleRowCount; i++)
                {
                    var dataColumn = gvIssuePolicies.DataColumns[15];
                    var chkSelect = gvIssuePolicies.FindRowCellTemplateControl(i, dataColumn, "chkIssueSelecst");
                    if (chkSelect == null) continue;
                    if (!((ASPxCheckBox)chkSelect).Checked) continue;

                    var values = gvIssuePolicies.GetRowValues(i, gvIssuePolicies.KeyFieldName).ToString().Split('|');
                    var policyNo = gvIssuePolicies.GetRowValues(i, "Policy_No").ToString();
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
                        StepCaseNo = Convert.ToInt32(values[11]),
                        PolicyNo = policyNo
                    };

                    policyListString.Add(policyNo);
                    policiesList.Add(keyItem);
                }

                if (!policyListString.Any()) return;
                /*
                //Send Policies to Advisor
                SubmitAsync(policyService, policyListString.ToArray(), json);

                //Change Policy Status
                Common.Classes.Common.DataService.ChangePolicyStatus(policiesList, Common.Classes.Common.CurrentUserId);
                */
                //Send Policies to Advisor
                var policyResult = Submit(policyService, policyListString.ToArray(), json);
                var successEmit = policiesList.Where(p => policyResult._PolicyResult.Where(r=>r.Result && r.PolicyNumber == p.PolicyNo).Any()).ToList();

                //Bmarroquin 14-02-2017 el cambio de estado ya se hace desde SubmitPoliciesServices...
                /*
                //Change Policy Status
                Common.Classes.Common.DataService.ChangePolicyStatus(successEmit, Common.Classes.Common.CurrentUserId);
                */

                //Bmarroquin 28-01-2017 Se agrega como mejora parte de la tropicalizacion de ESA, mandar un mensaje para que no de la impresion al usuario que no se ha procesado Nada
                var lStrExito = "-Se Procesaron Correctamente " + policyResult.SuccessFulPolicies.ToString() + " Polizas <br>";
                var lStrFail = "-Se Procesaron Con Error " + policyResult.FailedPolicies.ToString() + " Polizas";

                var msjTest = " CustomDialogMessageEx(' " + lStrExito + " " + lStrFail + " ', 500, 150, true,'Resultado');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msjTest, true);
                //Fin cambios Bmarroquin 28-01-2017


                //Refresh Grid
                FillData();
            }
            catch (Exception ex)
            {
                //Bmarroquin 28-01-2017
                var msjTest = " CustomDialogMessageEx(' Ocurrio un Error:  " + ex.Message + " ', 500, 150, true,'Error');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msjTest, true);
            }
        }

        static Web.SubmittedPolicies.PolicyService.SubmitPolicyResult Submit(IPolicyService proxy, string[] policyArray, string json)
        {
            var result = proxy.Submit(policyArray, null);
            return result;
        }
    }
}