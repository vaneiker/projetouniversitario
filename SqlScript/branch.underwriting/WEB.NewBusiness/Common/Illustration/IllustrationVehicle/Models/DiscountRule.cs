
using System;
namespace WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models
{
    [Serializable]
    public class DiscountRule
    {
        public int DiscountRuleId { get; set; }
        public int DiscountRuleDetailId { get; set; }
        public string DiscountRuleNameKey { get; set; }
        public string DiscountRuleDetailNameKey { get; set; }
        public string DiscountRuleValue { get; set; }
        public decimal DetailRuleValue { get; set; }
    }
}