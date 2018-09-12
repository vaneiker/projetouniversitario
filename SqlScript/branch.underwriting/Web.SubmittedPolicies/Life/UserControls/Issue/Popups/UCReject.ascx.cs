using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.SubmittedPolicies.Common.Classes;
using Web.SubmittedPolicies.Common.Interfaces;

namespace Web.SubmittedPolicies.Life.UserControls.Issue.Popups
{
    public partial class UCReject : Uc, IUc
    {
        public delegate void FillIssueGrid();
        public event FillIssueGrid FillIssuePoliciesGrid;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Translator(Common.Classes.Enums.Languages lang)
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
            //Get Policy Info from DB
            var data = Common.Classes.Common.DataService.GetRejectPolicyInfo(PolicyKey).ToList();

            if (!data.Any()) return;
            var dataItem = data.First();

            txtRPPolicy.Text = dataItem.Policy_No;
            txtRPOwnerName.Text = dataItem.OwnerFullName;
            txtRPProductType.Text = dataItem.Product_Desc;
            txtRPAgentName.Text = dataItem.AgentFullName;
            txtRPInitialPremium.Text = dataItem.Initial_Premium_F;
            txtRPOffice.Text = dataItem.Office_Desc;
        }

        protected void btnPRRechazar_OnClick(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtRPComment.Text)) return;
            Common.Classes.Common.DataService.RejectPolicies(PolicyKey, txtRPComment.Text, Common.Classes.Common.CurrentUserId);
            FillIssuePoliciesGrid();
        }
    }
}