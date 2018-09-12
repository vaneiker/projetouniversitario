using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
    public partial class UCNewCredit : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {

        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        DropDownManager DropDowns = new DropDownManager();
        //IPolicy PolicyManager
        //{
        //    get { return diManager.PolicyManager; }
        //}
        bool IsAditionalInsured
        {
            get { return string.IsNullOrWhiteSpace(hdnNCIsAditional.Value) ? false : bool.Parse(hdnNCIsAditional.Value); }
            set { hdnNCIsAditional.Value = value.ToString(); }
        }
        int contactId
        {
            get { return string.IsNullOrWhiteSpace(hdnNCContactId.Value) ? 0 : int.Parse(hdnNCContactId.Value); }
            set { hdnNCContactId.Value = value.ToString(); }
        }
        int contactRoleTypeId
        {
            get { return string.IsNullOrWhiteSpace(hdnNCContactRoleTypeId.Value) ? 0 : int.Parse(hdnNCContactRoleTypeId.Value); }
            set { hdnNCContactRoleTypeId.Value = value.ToString(); }
        }

        Decimal PTotalPThousand
        {
            get { return string.IsNullOrWhiteSpace(hdnTotalPThousand.Value) ? 0 : Decimal.Parse(hdnTotalPThousand.Value); }
            set { hdnTotalPThousand.Value = value.ToString(); }
        }

        Decimal PTotalTRating
        {
            get { return string.IsNullOrWhiteSpace(hdnTotalTRating.Value) ? 0 : Decimal.Parse(hdnTotalTRating.Value); }
            set { hdnTotalTRating.Value = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        public void FillCreditData(Boolean IsAditional, int ContactId, int ContactRoleTypeId, decimal TotalTRating, decimal TotalPThousand)
        {

            IsAditionalInsured = IsAditional;
            contactId = ContactId;
            contactRoleTypeId = ContactRoleTypeId;

            PTotalTRating = TotalTRating;
            PTotalPThousand = TotalPThousand;

            FillDrops();
        }

        private void FillDrops()
        {
            //Credit Type DropDown
            DropDowns.GetDropDown(ref ddlCreditType, Language.English, DropDownType.RatingType, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);

            //Credit DropDown
            DropDowns.GetDropDown(ref ddlCredit, Language.English, DropDownType.Credit, Service.Corp_Id, creditTypeId: -1, projectId: Service.ProjectId, companyId: Service.CompanyId);

            //Credit Reason DropDown
            DropDowns.GetDropDown(ref ddlReason, Language.English, DropDownType.CreditReason, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            DateTime date = DateTime.Now;

            var creditValue = decimal.Parse(ddlCredit.SelectedItem.Text.Replace("%", ""));

            if (int.Parse(ddlCreditType.SelectedValue) == (int)Tools.RisksRatingTypes.TableRating)
            {
                if (creditValue > PTotalTRating)
                {
                    this.MessageBox("You cannot add a Table Rating Credit greater than Table Rating Total.", 500, 150, true, "Warning");
                    return;
                }
            }
            else
            {
                if (creditValue > PTotalPThousand)
                {
                    this.MessageBox("You cannot add a Per Thousand Credit greater than Per Thousand Total.", 500, 150, true, "Warning");
                    return;
                }
            }


            var riskList = new List<Entity.UnderWriting.Entities.Policy.RiskRating>();

            var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
            {
                //Key
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticRegId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,

                //Rating Info
                OperationId = (int)Tools.RisksOperations.Credit,
                ClassificationId = 1, //Standard
                TableRating = decimal.Parse(ddlCredit.SelectedItem.Text.Replace("%", "")),
                RiskRateStatusId = 1, //Active
                CreditId = int.Parse(ddlCredit.SelectedValue),
                Comment = txtCreditComment.Text,
                CreditTypeId = int.Parse(ddlCreditType.SelectedValue),

                //Contact
                ContactId = contactId,
                ContactRoleTypeId = contactRoleTypeId,
                CreditReasonId = int.Parse(ddlReason.SelectedValue),
                YearToReconsider = 0,
                Duration = 0,
                EndDate = date,
                StartDate = date,
                ReconsiderDate = date,

                //Underwriter
                UserId = Service.Underwriter_Id,
                RequestedBy = Service.Underwriter_Id
            };

            riskList.Add(riskItem);

            //Insert Credit
            Services.PolicyManager.InsertRiskRating(riskList);

            ((HiddenField)this.Parent.Parent.Parent.FindControl("hfAddNewCredit")).Value = "false";
            ((UCPolicyPlanDataContainer)this.Parent.Parent.Parent).FillCreditData(IsAditionalInsured);
        }

        public void clearData()
        {
            txtCreditComment.Text = "";
        }

        public void readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            throw new NotImplementedException();
        }

        protected void ddlCreditType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var creditTypeId = ddlCreditType.SelectedIndex < 1 ? -1 : int.Parse(ddlCreditType.SelectedValue.ToString());

            //Credit DropDown
            DropDowns.GetDropDown(ref ddlCredit, Language.English, DropDownType.Credit, Service.Corp_Id, creditTypeId: creditTypeId, projectId: Service.ProjectId, companyId: Service.CompanyId);
        }

    }
}