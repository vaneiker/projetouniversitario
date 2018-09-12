using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DI.UnderWriting.IllusData.Interfaces;

namespace WEB.NewBusiness.Common.Illustration
{
    public class RulesService
    {
        public enum Rules{ 
        MAXIMUM_INSURED_AMT = 1,
        MINIMUM_INSURED_AMT = 2,
        MINIMUM_YEARLY_PREMIUM = 3,
        MINIMUM_CONTRIBUTION_PERIOD = 4,
        LOAD_CHARGE = 5,
        MONTHLY_FEE = 6,
        PREMIUM_RESERVE = 7,
        FUND_COST = 8,
        GROWTH_EXPECTED_RETURN = 9,
        BALANCED_EXPECTED_RETURN = 10,
        MODERATE_EXPECTED_RETURN = 11,
        GUARANTEED_EXPECTED_RETURN = 12,
        RATE = 13,
        PREMIUM_SMOKING = 14,
        PREMIUM_INSURED = 15,
        EXCESS_AGE = 16,
        MAX_AGE = 17,
        COUNTRY_RISK_TARGET_MORT_PER = 18,
        TARGET_FACTOR = 19,
        ADB_FACTOR = 20,
        ADB_MAX_AGE = 21,
        TARGET_CONTRIBUTION_PERIOD = 22,
        TARGET_DISCOUNT_FACTOR = 23,
        INVESTMENT_DISCOUNT_FACTOR = 24,
        MINIMUM_PREMIUM_TO_TARGET_FACTOR = 25,
        GS_MINIMUM_CONTRIBUTION_PERIOD = 26,
        INSURANCE_EXCESS_FACTOR = 27,
        INSURANCE_MAX_AGE = 28,
        INSURANCE_MIN_AGE = 29,
        INSURANCE_UNDERAGE = 30,
        MAXIMUM_INSURED_AMT_UNDERAGE = 31,
        TARGET_OVERAGE = 33,
        TARGET_PERIOD = 34,
        MINIMUM_PREMIUM_PERIOD = 35,

        GS_MINIMUM_PREMIUM_AMOUNT = 36,
        GS_MAXIMUM_PREMIUM_AMOUNT = 37,
        GS_MINIMUM_INSURED_AMOUNT = 38,
        GS_MAXIMUM_INSURED_AMOUNT = 39,
        GS_MINIMUM_TARGET_AMOUNT = 40,
        GS_MAXIMUM_TARGET_AMOUNT = 41,

        MAX_AGE_FOR_NINGUNA = 42,

        SURRENDER_CHARGE = 43,
        PARTIAL_SURRENDER_CHARGE = 44,
        SURRENDER_EXCESS_PERCENT = 45,

        TARGET_NINGUNA_PERCENT = 46,
        LOAN_INTEREST_RATE = 47,
        LOAN_PRINCIPAL_GROWTH_RATE = 48,
        LOAN_PRINCIPAL_GROW_INVEST_RATE = 49,
        INTEREST_LOAN_RATE = 50,
        LOAN_ASSET_RATE = 51,
        IS_LOAN_RATE = 52,

        SMOKER_OVERAGE = 53,
        INSURANCE_OVERAGE = 54,
        MAX_AGE_OFFSET_FOR_DEFAULT_MORTALITY = 55,
        MAX_AGE_FOR_DEFAULT_MORTALITY = 56,
        MAX_MORTALITY_VALUE = 57,
        MALE_MORTALITY_OFFSET = 58,

        GS_MINIMUM_ANNUITY_AMOUNT = 59,
        GS_MAXIMUM_ANNUITY_AMOUNT = 60,

        MINIMUM_PREMIUM_DISCOUNT_FACTOR = 61,
        RETIREMENT_PARTIAL_MINIMUM_PREMIUM_MULTIPLE = 62,

        COMMISSION_COST = 63,
        ADMIN_FIXED = 64,
        BASE_INTEREST = 65,

        RESCATE_STARTYEAR = 66,
        RESCATE_PERCENTAGE = 67,

        ADB_MAX_INSURED_AMOUNT = 68,

        // rules related to term product
        TARGET_RATE = 69,
        REGULAR_MARGIN = 70,
        SAVINGS_MARGIN = 71,
        RIDERS_MARGIN = 72,
        MINIMUM_FIRST_AGE_TARGET = 73,
        MINIMUM_FIRST_BASE_PRICE = 74,
        MINIMUM_SECOND_BASE_PRICE = 75,

        MINIMUM_RIDER_COST = 76,

        ADB_MIN_INSURED_AMOUNT = 77,

        ADDL_MIN_INSURED_AMOUNT = 78,
        ADDL_MAX_INSURED_AMOUNT = 79,

        OIR_MIN_INSURED_AMOUNT = 80,
        OIR_MAX_INSURED_AMOUNT = 81,

        MAXIMUM_ANNUITY_AMT = 82,
        MINIMUM_ANNUITY_AMT = 83,
        MAXIMUM_ANNUITY_AMT_YEAR = 84,
        MINIMUM_ANNUITY_AMT_YEAR = 85,

        MAXIMUM_CONTRIBUTION_PERIOD = 86,
        MINIMUM_ANNUITY_PERIOD = 87,
        MAXIMUM_ANNUITY_PERIOD = 88,
        MAXIMUM_AGE_END_ANNUITY = 89,
        MINIMUM_PERIOD_PRIOR_ANNUITY = 90,
        MAX_AGE_INSURANCE_TERM = 91,
        MINIMUM_INSURANCE_PERIOD = 92,
        MAXIMUM_INSURANCE_PERIOD = 93,
        MINIMUM_TOTAL_PREMIUM = 94,
        GS_MAXIMUM_ADB_COST = 95,
        GS_MAXIMUM_TERM_COST = 96,
        GS_MAXIMUM_OIR_COST = 97,
        TARGET_ADDL_DISCOUNT = 98,
        MAXIMUM_AGE_PRIOR_ANNUITY = 99,
        EXTRA_TERM_PENALTY = 100,
        ADB_ADD_TO_INSURED = 101,
        USE_PRIMARY_FOR_OTHER = 102
        }

        private List<Entity.UnderWriting.IllusData.Illustrator.RuleParameter> _lstRules;

        public RulesService(IIllusData oIllusDataManager, string productCode)
        {
            _lstRules = oIllusDataManager.GetAllRuleParameter(null, productCode).ToList();
        }

        public double GetValue(Rules ruleNo)
        {
            try
            {
                return Convert.ToDouble(_lstRules.Single(o => o.RuleParameterNo == ruleNo.ToInt()).RuleParameterValue.Value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}