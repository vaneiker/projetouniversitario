using System;
using System.Collections.Generic;
using System.Linq;
using Entity.UnderWriting.Entities;
using WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models;

namespace WEB.NewBusiness.Common.Illustration.IllustrationVehicle
{
    public static class IllustrationVehicleService
    {
        public static void CalculateDiscount(List<VehicleDiscount> lstVehicles, List<DiscountRule> lstDiscountRule)
        {
            var currentDiscountRule = lstDiscountRule.First();
            foreach (var vehicle in lstVehicles)
            {
                var percentDiscount = currentDiscountRule.DiscountRuleValue.ToDecimal();
                var premiumAmountWithDiscount = vehicle.PremiumAmount * (1 - percentDiscount);
                var index = premiumAmountWithDiscount / vehicle.InsuredAmount;
                if (vehicle.MinimumDiscountIndex > 0 && index < vehicle.MinimumDiscountIndex)
                {
                    vehicle.MarkError = true;
                    if (lstDiscountRule.Count > 1)
                    {
                        var lstJustCurrentVehicle = lstVehicles.Where(o => o.InsuredvehicleId == vehicle.InsuredvehicleId).ToList();
                        var lstOtherDiscountRule = lstDiscountRule.Where(o => o.DiscountRuleDetailId < currentDiscountRule.DiscountRuleDetailId).ToList();
                        CalculateDiscount(lstJustCurrentVehicle, lstOtherDiscountRule);
                    }
                    else
                    {
                        vehicle.CurrentDiscountIndex = index;
                        vehicle.PremiumAmountWithDiscount = vehicle.PremiumAmount;
                        vehicle.DiscountRule = null;
                    }
                    continue;
                }
                vehicle.CurrentDiscountIndex = index;
                vehicle.PremiumAmountWithDiscount = premiumAmountWithDiscount;
                vehicle.DiscountRule = currentDiscountRule;
            }
        }

        public static decimal GenerateMinimumDiscountIndex(Policy.VehiclesCoverage vehicle, List<DiscountRule> lstDiscountRules)
        {
            var productTypeDiscount = lstDiscountRules
            .FirstOrDefault(o => o.DiscountRuleNameKey.Contains(Utility.DiscountRules.DiscountRulesIndexByProductType.ToString() + "_" + vehicle.ProductTypeNameKey));

            if (productTypeDiscount != null)
                return productTypeDiscount.DiscountRuleValue.ToDecimal();
            else
            {
                var lstYearDiscountRuleId = lstDiscountRules
                    .Where(o => o.DiscountRuleNameKey.Contains(Utility.DiscountRules.ByYearDiscountRules.ToString()))
                    .Select(o => o.DiscountRuleId).Distinct();
                var difYearVehicleToday = DateTime.Now.Year - vehicle.YearVehicle.GetValueOrDefault();

                if (difYearVehicleToday < 0)
                    difYearVehicleToday = 0;

                foreach (var discountRuleId in lstYearDiscountRuleId)
                {
                    var minYear = lstDiscountRules
                        .FirstOrDefault(o =>
                            o.DiscountRuleId == discountRuleId &&
                            o.DiscountRuleDetailNameKey == Utility.DiscountRulesDetail.MinYear.ToString());

                    var maxYear = lstDiscountRules
                        .FirstOrDefault(o =>
                            o.DiscountRuleId == discountRuleId &&
                            o.DiscountRuleDetailNameKey == Utility.DiscountRulesDetail.MaxYear.ToString());

                    var currentIndex = lstDiscountRules
                        .FirstOrDefault(o =>
                            o.DiscountRuleId == discountRuleId &&
                            o.DiscountRuleDetailNameKey == Utility.DiscountRulesDetail.Index.ToString());

                    if (minYear == null ||
                        maxYear == null ||
                        currentIndex == null ||
                        !difYearVehicleToday.IsInRange(minYear.DiscountRuleValue.ToInt(), maxYear.DiscountRuleValue.ToInt())) continue;

                    return currentIndex.DiscountRuleValue.ToDecimal();
                }
            }

            return 0m;
        }

        public static List<DiscountRule> GetListDiscountRuleSurchargeToApply(int? insuredAge, List<DiscountRule> lstDiscountRules, Policy.VehiclesCoverage vehicle)
        {
            var lstDiscountRuleSurchargeToApply = new List<DiscountRule>();

            if (insuredAge.HasValue)
            {
                var ageRule = lstDiscountRules.FirstOrDefault(o => o.DiscountRuleNameKey == Utility.DiscountRules.SurchargeByDriverAge.ToString());
                if (ageRule != null && insuredAge.GetValueOrDefault() <= ageRule.DiscountRuleValue.ToInt())
                    lstDiscountRuleSurchargeToApply.Add(ageRule);
            }

            var vehicleTypeRule = lstDiscountRules
                .FirstOrDefault(o =>
                    o.DiscountRuleNameKey == Utility.DiscountRules.SurchargeByVehicleType.ToString() &&
                    o.DiscountRuleDetailNameKey == Utility.DiscountRulesDetail.VehicleType.ToString() &&
                    o.DiscountRuleValue.ToInt() == vehicle.VehicleTypeId.GetValueOrDefault()
                );

            if (vehicleTypeRule != null)
                lstDiscountRuleSurchargeToApply.Add(vehicleTypeRule);

            return lstDiscountRuleSurchargeToApply;
        }

        public static void CalculateSurcharge(VehicleSurcharge vehicle, DiscountRule discountRule)
        {
            vehicle.ListDiscountRule.Add(discountRule);
            var percentSurcharge = vehicle.ListDiscountRule.Sum(o => o.DiscountRuleValue.ToDecimal());
            var surchargeValue = vehicle.OwnDamages * percentSurcharge;
            vehicle.PremiumAmountWithSurcharge = vehicle.PremiumAmount + surchargeValue;
            vehicle.OwnDamagesWithSurcharge = vehicle.OwnDamages + surchargeValue;
        }

        public static void CalculateSurchargeToCoverageDetail(VehicleSurcharge vehicle)
        {
            var percentSurcharge = vehicle.ListDiscountRule.Sum(o => o.DiscountRuleValue.ToDecimal());
            foreach (var coverage in vehicle.ListOwnDamagesCoverage)
            {
                coverage.OldUnitaryPrice = coverage.UnitaryPrice;
                coverage.UnitaryPrice = coverage.UnitaryPrice * (1 + percentSurcharge);
            }
        }
    }
}