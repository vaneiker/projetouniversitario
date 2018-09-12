using System;
using System.Collections.Generic;

namespace WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models
{
    [Serializable]
    public class VehicleSurcharge
    {
        public int CorpId { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public int Year { get; set; }
        public int InsuredVehicleId { get; set; }
        public decimal InsuredAmount { get; set; }
        public decimal PremiumAmount { get; set; }
        public decimal BasePremiumAmount { get; set; }
        public decimal PremiumAmountWithSurcharge { get; set; }
        public decimal OwnDamages { get; set; }
        public decimal OwnDamagesWithSurcharge { get; set; }
        public int RowIndex { get; set; }
        public List<DiscountRule> ListDiscountRule { get; set; }
        public List<VehicleCoverage> ListOwnDamagesCoverage { get; set; }
        public string VehicleDesc { get; set; }
        public string SurchargeSelectedValue { get; set; }
        public bool MarkError { get; set; }

        public long VehicleUniqueId { get; set; }
        public int BlTypeId { get; set; }
        public int BlId { get; set; }
        public int ProductId { get; set; }
        public int VehicleTypeId { get; set; }
        public int GroupId { get; set; }
        public int CoverageTypeId { get; set; }
        public int CoverageId { get; set; }
        public decimal OldUnitaryPrice { get; set; }
        public decimal OldCoverageAmount { get; set; }
        public decimal UnitaryPrice { get; set; }

        public string DiscountRuleValue { get; set; }

        [Serializable]
        public class VehicleCoverage
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public long VehicleUniqueId { get; set; }
            public int BlTypeId { get; set; }
            public int BlId { get; set; }
            public int ProductId { get; set; }
            public int VehicleTypeId { get; set; }
            public int GroupId { get; set; }
            public int CoverageTypeId { get; set; }
            public int CoverageId { get; set; }
            public decimal OldUnitaryPrice { get; set; }
            public decimal UnitaryPrice { get; set; }
        }
    }
}