using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.SubmittedPolicies.Common.Classes;
using Web.SubmittedPolicies.Common.Interfaces;

namespace Web.SubmittedPolicies.Life.UserControls.NeverIssued.Popups
{
    public partial class UCEditNeverIssued : Uc, IUc
    {
        public delegate void EditNeverIssued();
        public event EditNeverIssued LoadNeverIssued;

        protected void Page_Load(object sender, EventArgs e)
        {
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
            //FillDrops
            FillDrops();

            //Get Policy Info from DB
            var data = Common.Classes.Common.DataService.GetNeverIssuedPolicyInfo(PolicyKey).ToList();

            if (!data.Any()) return;
            var dataItem = data.First();

            //ReadOnly Fields
            txtENIAgentName.Text = dataItem.AgentFullName;
            txtENIApplicationDate.Text = dataItem.ApplicationDate_F;
            txtENIInitialPremium.Text = dataItem.Initial_Premium_F;
            txtENIOffice.Text = dataItem.Office_Desc;
            txtENIOwnerName.Text = dataItem.OwnerFullName;
            txtENIPolicy.Text = dataItem.Policy_No;
            txtENIProductType.Text = dataItem.Product_Desc;

            //Editable Fields
            txtENIComment.Text = dataItem.Note_Desc;
            chkENIPenalty.Checked = dataItem.Penalty ?? false;
            ddlENINeverIssued.SelectedValue = dataItem.Step_Reason_Id.HasValue ? dataItem.Step_Reason_Id.ToString() : "-1";
        }

        protected void btnENISend_OnClick(object sender, EventArgs e)
        {
            var reasonId = int.Parse(ddlENINeverIssued.SelectedValue);

            if (ddlENINeverIssued.SelectedIndex < 1 || String.IsNullOrWhiteSpace(txtENIComment.Text)) return;
            Common.Classes.Common.DataService.SendNeverIssuedPolicy(PolicyKey, reasonId, chkENIPenalty.Checked, txtENIComment.Text, Common.Classes.Common.CurrentUserId);
            LoadNeverIssued();
        }

        private void FillDrops()
        {
            ddlENINeverIssued.FillDrops(Common.Classes.Common.DataService.GetDropDowns(Enums.DropDowns.StepsReason, PolicyKey.CorpId).OrderBy(r => r.Text).ToList(), true);
        }
    }
}