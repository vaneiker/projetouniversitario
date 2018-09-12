using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class HealthRepository : GlobalRepository
    {
        public HealthRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual Health.Policy.Premium SetPolicyPremium(Health.Policy.Premium parameter)
        {
            Health.Policy.Premium result;
            IEnumerable<SP_SET_HH_POLICY_PREMIUM_Result> temp;

            temp = globalModel.SP_SET_HH_POLICY_PREMIUM(
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticRegId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.BenefitPlanId,
                    parameter.PaymentFreqTypeId,
                    parameter.PremiumAmount,
                    parameter.UserId
                    );

            result = temp
                .Select(h => new Health.Policy.Premium
                {
                    CorpId = h.Corp_Id.ConvertToNoNullable(),
                    RegionId = h.Region_Id.ConvertToNoNullable(),
                    CountryId = h.Country_Id.ConvertToNoNullable(),
                    DomesticRegId = h.Domesticreg_Id.ConvertToNoNullable(),
                    StateProvId = h.State_Prov_Id.ConvertToNoNullable(),
                    CityId = h.City_Id.ConvertToNoNullable(),
                    OfficeId = h.Office_Id.ConvertToNoNullable(),
                    CaseSeqNo = h.Case_Seq_No.ConvertToNoNullable(),
                    HistSeqNo = h.Hist_Seq_No.ConvertToNoNullable(),
                    BenefitPlanId = h.Benefit_Plan_Id.ConvertToNoNullable(),
                    PaymentFreqTypeId = h.Payment_Freq_Type_Id.ConvertToNoNullable()
                })
                .FirstOrDefault();

            return
                result;
        }
        public virtual Health.Policy.Member.CoveragePremium SetPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter)
        {
            Health.Policy.Member.CoveragePremium result;
            IEnumerable<SP_SET_HH_POLICY_MEMBER_COVERAGE_PREMIUM_Result> temp;

            temp = globalModel.SP_SET_HH_POLICY_MEMBER_COVERAGE_PREMIUM(
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticRegId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.ContactId,
                    parameter.ContactRoleTypeId,
                    parameter.BenefitPlanId,
                    parameter.CoverageTypeId,
                    parameter.CoverageId,
                    parameter.PremiumAmount,
                    parameter.UserId
                    );

            result = temp
                .Select(hcp => new Health.Policy.Member.CoveragePremium
                {
                    CorpId = hcp.Corp_Id.ConvertToNoNullable(),
                    RegionId = hcp.Region_Id.ConvertToNoNullable(),
                    CountryId = hcp.Country_Id.ConvertToNoNullable(),
                    DomesticRegId = hcp.Domesticreg_Id.ConvertToNoNullable(),
                    StateProvId = hcp.State_Prov_Id.ConvertToNoNullable(),
                    CityId = hcp.City_Id.ConvertToNoNullable(),
                    OfficeId = hcp.Office_Id.ConvertToNoNullable(),
                    CaseSeqNo = hcp.Case_Seq_No.ConvertToNoNullable(),
                    HistSeqNo = hcp.Hist_Seq_No.ConvertToNoNullable(),
                    ContactId = hcp.Contact_Id.ConvertToNoNullable(),
                    ContactRoleTypeId = hcp.Contact_Role_Type_Id.ConvertToNoNullable(),
                    BenefitPlanId = hcp.Benefit_Plan_Id.ConvertToNoNullable(),
                    CoverageTypeId = hcp.Coverage_Type_Id.ConvertToNoNullable(),
                    CoverageId = hcp.Coverage_Id.ConvertToNoNullable()
                })
                .FirstOrDefault();

            return
                result;
        }
        public virtual IEnumerable<Health.Policy.Member.CoveragePremium> GetPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter)
        {
            IEnumerable<Health.Policy.Member.CoveragePremium> result;
            IEnumerable<SP_GET_MEMBER_COVERAGE_PREMIUM_Result> temp;

            temp = globalModel.SP_GET_MEMBER_COVERAGE_PREMIUM(
                    parameter.CorpId,
                    parameter.RegionId,                    
                    parameter.CountryId,
                    parameter.DomesticRegId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.ContactId,
                    parameter.ContactRoleTypeId
                    );

            result = temp
                .Select(hcp => new Health.Policy.Member.CoveragePremium
                {
                    CoverageTypeId = hcp.Coverage_Type_Id,
                    CoverageId = hcp.Coverage_Id,
                    CoverageDesc = hcp.Coverage_Desc,
                    ContactId = hcp.Contact_Id,
                    ContactRoleTypeId = hcp.Contact_Role_Type_Id,
                    ContactFirstName = hcp.Contact_First_Name,
                    ContactLastName = hcp.Contact_Last_Name,
                    ProductId = hcp.Product_id,
                    ProductDesc = hcp.Product_Desc,
                    BenefitPlanId = hcp.Benefit_Plan_Id,
                    BenefitPlanDesc = hcp.Benefit_Plan_Desc,
                    Deductible = hcp.Deductible,
                    InsuredAmount = hcp.Insured_Amount,
                    PremiumAmount = hcp.Premium_Amount
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<Health.BenefitPlan> GetBenefitPlan(Health.BenefitPlan.Key parameter)
        {
            IEnumerable<Health.BenefitPlan> result;
            IEnumerable<SP_GET_BENEFIT_PLAN_Result> temp;

            temp = globalModel.SP_GET_BENEFIT_PLAN(
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticRegId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo
                    );

            result = temp
                .Select(bp => new Health.BenefitPlan
                {
                    ProductId = bp.Product_Id,
                    DeductibleCategoryId = bp.Deductible_Category_Id,
                    DeductibleCategoryValue = bp.Deductible_Category_Value,
                    DeductibleTypeId = bp.Deductible_Type_Id,
                    DeductibleTypeDesc = bp.Deductible_Type_Desc,
                    BenefitPlanId = bp.Benefit_Plan_Id,
                    BenefitPlanDesc = bp.Benefit_Plan_Desc,
                    ProductDesc = bp.Product_Desc
                })
                .ToArray();

            return
                result;
        }
    }
}
