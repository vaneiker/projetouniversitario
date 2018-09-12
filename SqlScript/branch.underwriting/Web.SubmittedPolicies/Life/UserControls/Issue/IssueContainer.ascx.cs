using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.SubmittedPolicies.Common.Interfaces;

namespace Web.SubmittedPolicies.Life.UserControls.Issue
{
    public partial class IssueContainer : UserControl, IUc
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCIssue.SelectGridRow += FillDetailData;
            //UCProcessing.SelectGridRowProcesing += FillDetailData;
        }

        protected void lnkIssue_OnClick(object sender, EventArgs e)
        {
            mvIssueContainer.SetActiveView(vIssue);
            lnkPolicyDetail_OnClick(null, null);
            pnlIssuePlyDetail.Visible = true;
            lnkIssue.CssClass = "box_btn activo";
            lnkProcessing.CssClass = "box_btn";
            UCIssue.FillData();
        }

        protected void lnkPolicyDetail_OnClick(object sender, EventArgs e)
        {
            mvPolicyDetail.SetActiveView(vPolicyDetail);
            liPolicyDetail.Attributes.Add("class", "tab-item open");
            liPolicyRiders.Attributes.Add("class", "tab-item");
        }

        protected void lnkPolicyRiders_OnClick(object sender, EventArgs e)
        {
            mvPolicyDetail.SetActiveView(vPolicyRiders);
            liPolicyDetail.Attributes.Add("class", "tab-item");
            liPolicyRiders.Attributes.Add("class", "tab-item open");
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
            lnkIssue_OnClick(null, null);
        }

        public void FillDetailData(Common.Classes.Common.PolicyKeyItem keyItem = null)
        {
            if (keyItem == null)
            {
                UCPolicyDetail.FillData();
                UCRiders.FillData();
                lnkPolicyDetail.Text = "Datos de la Póliza - 0000000" ;
            }
            else
            {
                //Get Policy Info from DB
                var data = Common.Classes.Common.DataService.GetPolicyInfo(Common.Classes.Common.ProjectId, keyItem).ToList();

                if (!data.Any()) return;
                var dataItem = data.First();

                //Get Riders Info
                var pRiders = Common.Classes.Common.DataService.GetPolicyRiders(keyItem).ToList();

                //Fill UserControls
                lnkPolicyDetail.Text = "Datos de la Póliza - " + dataItem.Policy_No;
                UCPolicyDetail.FillData(dataItem);
                UCRiders.FillData(pRiders);
            }
        }

        protected void lnkProcessing_Click(object sender, EventArgs e)
        {
            mvIssueContainer.SetActiveView(vProcessing);
            //lnkPolicyDetail_OnClick(null, null);
            pnlIssuePlyDetail.Visible = false;
            lnkIssue.CssClass = "box_btn activo_ck";
            lnkProcessing.CssClass = "box_btn activo";
            UCProcessing.FillData();
        }
    }
}