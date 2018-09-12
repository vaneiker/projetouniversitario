using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.UnderWriting.IllusData
{
    public class DropDown
    {
        public string Product { get; set; }
        public string PlanGroupCode { get; set; }
        public string ProductCode { get; set; }
        public string PFixed { get; set; }
        public string IsRefund { get; set; }
        public string PlanGroup { get; set; }
        public int? Period { get; set; }
        public string ContributionType { get; set; }
        public string CalculateType { get; set; }
        public string PlanType { get; set; }
        public string PlanTypeCode { get; set; }
        public string Life { get; set; }
        public string Education { get; set; }
        public string Retirement { get; set; }
        public string TermInsurance { get; set; }
        public string ActivityRiskType { get; set; }
        public int? ActivityRiskTypeNo { get; set; }
        public decimal? ActivityRiskValue { get; set; }
        public string HealthRiskType { get; set; }
        public int? HealthRiskTypeNo { get; set; }
        public decimal? HealthRiskValue { get; set; }
        public string FrequencyType { get; set; }
        public string FrequencyTypeCode { get; set; }
        public int? FrequencyValue { get; set; }
        public decimal? FrequencyCost { get; set; }
        public string InvestmentProfile { get; set; }
        public string InvestmentProfileCode { get; set; }
        public string IllustrationType { get; set; }
        public string IllustrationTypeCode { get; set; }
        public string IllustrationStatusCode { get; set; }
        public string IllustrationStatus { get; set; }
        public string PhoneType { get; set; }
        public string PhoneTypeCode { get; set; }
        public string EmailType { get; set; }
        public string EmailTypeCode { get; set; }
        public string ReferralType { get; set; }
        public string ReferralTypeCode { get; set; }
        public string RelationshipType { get; set; }
        public string RelationshipTypeCode { get; set; }
        public string CountryName { get; set; }
        public int? CountryNo { get; set; }
        public string CountryCode { get; set; }
        public string PrimaryLanguageCode { get; set; }
        public string LanguageCodes { get; set; }
        public decimal? RiskValue { get; set; }
        public string Adb { get; set; }
        public string MaritalStatus { get; set; }
        public string MaritalStatusCode { get; set; }
        public string GenderName { get; set; }
        public string GenderCode { get; set; }
        public string ProfessionType { get; set; }
        public string ProfessionTypeCode { get; set; }
        public string OccupationType { get; set; }
        public string OccupationTypeCode { get; set; }
        public string AdvisorCode { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationTypeCode { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string PClass { get; set; }
        public string Symbol { get; set; }
        public string CalculateTypeCode { get; set; }
        public string ContributionTypeCode { get; set; }
        public decimal? InvestmentProfileRate { get; set; }
        public string InsuredTypeCode { get; set; }
        public string InsuredType { get; set; }
        public string BeneficiaryTypeCode { get; set; }
        public string BeneficiaryType { get; set; }
        public int? MortalityNo { get; set; }
        public int? Age { get; set; }
        public decimal? MaleNonSmoker { get; set; }
        public decimal? FemaleNonSmoker { get; set; }
        public decimal? MaleSmoker { get; set; }
        public decimal? FemaleSmoker { get; set; }
        public string RiderTypeCode { get; set; }
        public int? YearNo { get; set; }
        public decimal? Vr { get; set; }
        public decimal? AdditionalPenalty { get; set; }
        public decimal? RegularComm { get; set; }
        public decimal? ExcessComm { get; set; }
        public int? CommissionNo { get; set; }
        public decimal? PenalTyperCent { get; set; }
        public int? SurrenderPenaltyNo { get; set; }
        public string ContributionPeriod { get; set; }
        public int? ProviderId { get; set; }
        public int? ProviderTypeId { get; set; }
        public string ProviderName { get; set; }
        public string ValueFieldSource { get; set; }   
                           

        public class Parameter
        {
            public string DropDownType { get; set; }
            public string ProductCode { get; set; }
            public string Life { get; set; }
            public string PlanGroupCode { get; set; }
            public string Education { get; set; }
            public string Retirement { get; set; }
            public string TermInsurance { get; set; }
            public string PClass { get; set; }
            public string RiderTypeCode { get; set; }
            public int? Age { get; set; }
            public string CompanyId { get; set; }
            public int? CorpId { get; set; }
            public int? RegionId { get; set; }
            public int? StateProvId { get; set; }
            public int? CountryId { get; set; }
            public int? DomesticregId { get; set; }
            public int? ProviderTypeId { get; set; }           
        }
    }
}
