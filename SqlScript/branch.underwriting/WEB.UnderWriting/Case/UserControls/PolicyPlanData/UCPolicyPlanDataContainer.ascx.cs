using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
    public partial class UCPolicyPlanDataContainer : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            UCPocicyPlanInformation.save();
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
            UCPocicyPlanInformation.FillData();
            UCAmendments.FillData();
            UCRiskClass.FillData(false);


            //Additional Risk
            var hasAdditional = Service.AddInsuredContactId.HasValue;

            UCRiskClassAditional.Visible = hasAdditional;
            if (hasAdditional)
                UCRiskClassAditional.FillData(true);
        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        public void LoadNewRisk(Boolean IsAditional, int ContactId, int ContactRoleTypeId, IEnumerable<Policy.RiskRating> riskRatingList = null,
            Decimal? duration = null, Decimal? yearsToReconsider = null, Decimal? tableRating = null, Decimal? perThousand = null)
        {
            hfAddNewRisk.Value = "true";
            if (riskRatingList == null)
                UCNewRisk.FillRiskData(IsAditional, ContactId, ContactRoleTypeId);
            else
                UCNewRisk.FillEditData(IsAditional, ContactId, ContactRoleTypeId, riskRatingList, duration.Value, yearsToReconsider.Value, tableRating, perThousand);
        }

        public void LoadNewCredit(Boolean IsAditional, int ContactId, int ContactRoleTypeId, decimal TotalTRRating, decimal TotalPThousand)
        {
            hfAddNewCredit.Value = "true";
            UCNewCredit.clearData();
            UCNewCredit.FillCreditData(IsAditional, ContactId, ContactRoleTypeId, TotalTRRating, TotalPThousand);
        }

        public void LoadNewExclusion(Boolean IsAditional, int ContactId, int ContactRoleTypeId)
        {
            hfAddNewExclusion.Value = "true";
            UCNewExclusion.FillExclusionData(IsAditional, ContactId, ContactRoleTypeId);
        }

        public void LoadExclusionComment(String Comment, String Underwriter, String CommentDate)
        {
            hfExclusionComment.Value = "true";
            UCPopExclusionComment.FillCommentData(Comment, Underwriter, CommentDate);
        }

        public void LoadTerminateExclusion(String RiskId, String SequenceReference, String UnderWriterName, String Comment, Boolean IsAditional)
        {

            ModalPopupTerminateExclusion.Show();
            UCTerminateExclusion.FillTerminanteExclusionData(RiskId, SequenceReference, UnderWriterName, Comment, IsAditional);
        }

        public void FillExclusionData(Boolean IsAditional)
        {
            if (IsAditional)
                UCRiskClassAditional.FillExclusionData();
            else
                UCRiskClass.FillExclusionData();
        }

        public void FillRiskData(Boolean IsAditional)
        {
            if (IsAditional)
                UCRiskClassAditional.FillRiskData();
            else
                UCRiskClass.FillRiskData();
        }

        public void FillCreditData(Boolean IsAditional)
        {
            if (IsAditional)
                UCRiskClassAditional.FillCreditData();
            else
                UCRiskClass.FillCreditData();
        }
    }
}