using System;

namespace WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models
{
    [Serializable]
    public class VehicleDiscount
    {
        private decimal _sumDiscount = 0;
        public int CorpId { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public int DomesticRegId { get; set; }
        public int StateProvId { get; set; }
        public int CityId { get; set; }
        public int OfficeId { get; set; }
        public int CaseSeqNo { get; set; }
        public int HistSeqNo { get; set; }
        public int InsuredvehicleId { get; set; }
        public int Year { get; set; }
        public decimal InsuredAmount { get; set; }
        public decimal PremiumAmount { get; set; }
        public decimal OriginalPremiumAmount { get; set; }
        public decimal MinimumDiscountIndex { get; set; }
        public decimal PremiumAmountWithDiscount { get; set; }
        public int RowIndex { get; set; }
        public DiscountRule DiscountRule { get; set; }
        public decimal SumDiscount
        {
            get
            {
                return _sumDiscount + (DiscountRule == null ? 0 : DiscountRule.DiscountRuleValue.ToDecimal());
            }
            set
            {
                _sumDiscount = value;
            }
        }
        public string VehicleDesc { get; set; }
        public decimal CurrentDiscountIndex { get; set; }
        public bool MarkError { get; set; }
    }
}