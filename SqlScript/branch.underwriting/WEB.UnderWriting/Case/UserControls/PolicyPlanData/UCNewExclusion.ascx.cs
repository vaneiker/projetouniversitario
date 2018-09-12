using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
    public partial class UCNewExclusion : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {

        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        DropDownManager DropDowns = new DropDownManager();

        //IPolicy PolicyManager
        //{
        //    get { return diManager.PolicyManager; }
        //}
        bool IsAditionalInsured
        {
            get { return !string.IsNullOrWhiteSpace(hdnNEIsAditional.Value) && bool.Parse(hdnNEIsAditional.Value); }
            set { hdnNEIsAditional.Value = value.ToString(); }
        }
        int contactId
        {
            get { return string.IsNullOrWhiteSpace(hdnNEContactId.Value) ? 0 : int.Parse(hdnNEContactId.Value); }
            set { hdnNEContactId.Value = value.ToString(); }
        }
        int contactRoleTypeId
        {
            get { return string.IsNullOrWhiteSpace(hdnNEContactRoleTypeId.Value) ? 0 : int.Parse(hdnNEContactRoleTypeId.Value); }
            set { hdnNEContactRoleTypeId.Value = value.ToString(); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void FillDrops()
        {
            //Exclusion Type
            DropDowns.GetDropDown(ref ddlNEExclusionType, Language.English, DropDownType.ExclusionType, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);

            //Requested By
            DropDowns.GetDropDown(ref ddlNERequestedBy, Language.English, DropDownType.RiskRequestedBy, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
        }


        public void FillExclusionData(Boolean IsAditional, int ContactId, int ContactRoleTypeId)
        {
            IsAditionalInsured = IsAditional;
            contactId = ContactId;
            contactRoleTypeId = ContactRoleTypeId;

            FillDrops();
        }


        public void save()
        {
            DateTime date = DateTime.Now;

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
                OperationId = (int)Tools.RisksOperations.Exclusion,
                ClassificationId = 1, //Standard
                ExclusionTypeId = int.Parse(ddlNEExclusionType.SelectedValue),
                RiskRateStatusId = 1, //Active
                ExclusionId = int.Parse(ddlNEExclusion.SelectedValue),
                Comment = txtNEExclusionComment.Text,

                //Contact
                ContactId = contactId,
                ContactRoleTypeId = contactRoleTypeId,
                RequestedBy = int.Parse(ddlNERequestedBy.SelectedValue),
                YearToReconsider = 0,
                Duration = 0,
                EndDate = null,
                StartDate = date,
                ReconsiderDate = date,
                //Underwriter
                UserId = Service.Underwriter_Id
            };

            riskList.Add(riskItem);

            //Insert Credit
            Services.PolicyManager.InsertRiskRating(riskList);

            ((HiddenField)this.Parent.Parent.Parent.FindControl("hfAddNewExclusion")).Value = "false";
            ((UCPolicyPlanDataContainer)this.Parent.Parent.Parent).FillExclusionData(IsAditionalInsured);
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            save();
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void clearData()
        {
            throw new NotImplementedException();
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

        protected void ddlExclusionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Exclusion
            DropDowns.GetDropDown(ref ddlNEExclusion, Language.English, DropDownType.Exclusion, corpId: Service.Corp_Id, exclusionTypeId: int.Parse(ddlNEExclusionType.SelectedValue), projectId: Service.ProjectId, companyId: Service.CompanyId);
        }
    }
}