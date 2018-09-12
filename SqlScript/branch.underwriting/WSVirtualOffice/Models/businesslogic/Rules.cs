using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Rules
    {
        public static int MAXIMUM_INSURED_AMT = 1;
        public static int MINIMUM_INSURED_AMT = 2;
        public static int MINIMUM_YEARLY_PREMIUM = 3;
        public static int MINIMUM_CONTRIBUTION_PERIOD = 4;
        public static int LOAD_CHARGE = 5;
        public static int MONTHLY_FEE = 6;
        public static int PREMIUM_RESERVE = 7;
        public static int FUND_COST = 8;
        public static int GROWTH_EXPECTED_RETURN = 9;
        public static int BALANCED_EXPECTED_RETURN = 10;
        public static int MODERATE_EXPECTED_RETURN = 11;
        public static int GUARANTEED_EXPECTED_RETURN = 12;
        public static int RATE = 13;
        public static int PREMIUM_SMOKING = 14;
        public static int PREMIUM_INSURED = 15;
        public static int EXCESS_AGE = 16;
        public static int MAX_AGE = 17;
        public static int COUNTRY_RISK_TARGET_MORT_PER = 18;
        public static int TARGET_FACTOR = 19;
        public static int ADB_FACTOR = 20;
        public static int ADB_MAX_AGE = 21;
        public static int TARGET_CONTRIBUTION_PERIOD = 22;
        public static int TARGET_DISCOUNT_FACTOR = 23;
        public static int INVESTMENT_DISCOUNT_FACTOR = 24;
        public static int MINIMUM_PREMIUM_TO_TARGET_FACTOR = 25;
        public static int GS_MINIMUM_CONTRIBUTION_PERIOD = 26;
        public static int INSURANCE_EXCESS_FACTOR = 27;
        public static int INSURANCE_MAX_AGE = 28;
        public static int INSURANCE_MIN_AGE = 29;
        public static int INSURANCE_UNDERAGE = 30;
        public static int MAXIMUM_INSURED_AMT_UNDERAGE = 31;
        //public static int MINIMUM_CONTRIBUTION_PERIOD = 32;
        public static int TARGET_OVERAGE = 33;
        public static int TARGET_PERIOD = 34;
        public static int MINIMUM_PREMIUM_PERIOD = 35;
        


        public static int GS_MINIMUM_PREMIUM_AMOUNT = 36;
        public static int GS_MAXIMUM_PREMIUM_AMOUNT = 37;
        public static int GS_MINIMUM_INSURED_AMOUNT = 38;
        public static int GS_MAXIMUM_INSURED_AMOUNT = 39;
        public static int GS_MINIMUM_TARGET_AMOUNT = 40;
        public static int GS_MAXIMUM_TARGET_AMOUNT = 41;


        public static int MAX_AGE_FOR_NINGUNA = 42;

        public static int SURRENDER_CHARGE = 43;
        public static int PARTIAL_SURRENDER_CHARGE = 44;
        public static int SURRENDER_EXCESS_PERCENT = 45;

        public static int TARGET_NINGUNA_PERCENT = 46;
        public static int LOAN_INTEREST_RATE = 47;
        public static int LOAN_PRINCIPAL_GROWTH_RATE = 48;
        public static int LOAN_PRINCIPAL_GROW_INVEST_RATE = 49;
        public static int INTEREST_LOAN_RATE = 50;
        public static int LOAN_ASSET_RATE = 51;
        public static int IS_LOAN_RATE = 52;

        public static int SMOKER_OVERAGE = 53;
        public static int INSURANCE_OVERAGE = 54;
        public static int MAX_AGE_OFFSET_FOR_DEFAULT_MORTALITY = 55;
        public static int MAX_AGE_FOR_DEFAULT_MORTALITY = 56;
        public static int MAX_MORTALITY_VALUE = 57;
        public static int MALE_MORTALITY_OFFSET = 58;

        


        public static int GS_MINIMUM_ANNUITY_AMOUNT = 59;
        public static int GS_MAXIMUM_ANNUITY_AMOUNT = 60;

        public static int MINIMUM_PREMIUM_DISCOUNT_FACTOR = 61;
        public static int RETIREMENT_PARTIAL_MINIMUM_PREMIUM_MULTIPLE = 62;

        public static int COMMISSION_COST = 63;
        public static int ADMIN_FIXED = 64;
        public static int BASE_INTEREST = 65;

        public static int RESCATE_STARTYEAR = 66;
        public static int RESCATE_PERCENTAGE = 67;

        public static int ADB_MAX_INSURED_AMOUNT = 68;
                        

        // rules related to term product
        public static int TARGET_RATE = 69;
        public static int REGULAR_MARGIN = 70;
        public static int SAVINGS_MARGIN = 71;
        public static int RIDERS_MARGIN = 72;
        public static int MINIMUM_FIRST_AGE_TARGET = 73;
        public static int MINIMUM_FIRST_BASE_PRICE = 74;
        public static int MINIMUM_SECOND_BASE_PRICE = 75;

        public static int MINIMUM_RIDER_COST = 76;

        public static int ADB_MIN_INSURED_AMOUNT = 77;

        public static int ADDL_MIN_INSURED_AMOUNT = 78;
        public static int ADDL_MAX_INSURED_AMOUNT = 79;

        public static int OIR_MIN_INSURED_AMOUNT = 80;
        public static int OIR_MAX_INSURED_AMOUNT = 81;


        public static int MAXIMUM_ANNUITY_AMT = 82;
        public static int MINIMUM_ANNUITY_AMT = 83;
        public static int MAXIMUM_ANNUITY_AMT_YEAR = 84;
        public static int MINIMUM_ANNUITY_AMT_YEAR = 85;

        public static int MAXIMUM_CONTRIBUTION_PERIOD= 86;
        public static int MINIMUM_ANNUITY_PERIOD = 87;
        public static int MAXIMUM_ANNUITY_PERIOD = 88;
        public static int MAXIMUM_AGE_END_ANNUITY = 89;
        public static int MINIMUM_PERIOD_PRIOR_ANNUITY = 90;
        public static int MAX_AGE_INSURANCE_TERM = 91;
        public static int MINIMUM_INSURANCE_PERIOD = 92;
        public static int MAXIMUM_INSURANCE_PERIOD = 93;
        public static int MINIMUM_TOTAL_PREMIUM = 94;
        public static int GS_MAXIMUM_ADB_COST = 95;
        public static int GS_MAXIMUM_TERM_COST = 96;
        public static int GS_MAXIMUM_OIR_COST = 97;
        public static int TARGET_ADDL_DISCOUNT = 98;
        public static int MAXIMUM_AGE_PRIOR_ANNUITY = 99;
        public static int EXTRA_TERM_PENALTY = 100;
	    public static int ADB_ADD_TO_INSURED = 101;
        public static int USE_PRIMARY_FOR_OTHER = 102;
        public static int MINIMUM_ANYTIME_PREMIUM = 103;

        public static int FUNERAL_INSURED_AMOUNT = 104;
        public static int PUBLICO = 105;
        public static int PRIVADO = 106;
        public static int REPATRIATION = 107;
        public static int FAMILIARNO = 108;
        public static int FAMILIARYES = 109;
        public static int MONTHLYFACTOR = 104;
        public static int QUARTERLYFACTOR = 105;
        public static int SEMIANNUALFACTOR = 106;

        public static int FEMALE_MORTALITY_OFFSET = 110;
        public static int RIDER_TERM_FACTOR = 111;
        public static int RIDER_CI_FACTOR = 112;

        // Lgonzalez 03-03-2017
        public static int MAX_AGE_RIDER_CI = 113;
        public static int MAX_AGE_RIDER_ADB = 114;
        // Lgonzalez 03-03-2017
        //Lgonzalez 08-03-2017
        public static int MAX_AGE_RIDER_TERM = 115;

        public static int MAX_AGE_EXIT_INSURANCE = 116;
        public static int MAX_AGE_EXIT_RIDER_CI = 117;
        public static int MAX_AGE_EXIT_RIDER_ADB = 118;
        public static int MAX_AGE_EXIT_RIDER_TERM = 119;
        //Lgonzalez 08-03-2017
        //Bmarroquin 15-03-2017 agrego new static variables
        public static int MAX_AMOUNT_INSURED_FE = 120;
        public static int MIM_AMOUNT_INSURED_FE = 121;
        //Bmarroquin 15-03-2017

        //Lgonzalez 30-03-2017
        public static int MIN_PERCENTAGE_INSURED_FE = 122;

        //Extra_Term_Penalty
        //86	Maximum_contribution_period
//87	Minimum_annuity_period
//88	Maximum_annuity_Period
//89	Maximum_age_end_annuity
//90	Minimum_Period_Prior_Annuity
//91	Max_Age_insurance_term
//92	Minimum_Insurance_Period
//93	Maximum_Insurance_Period
        
        public static int getRulevalueint(int ruleno, String productcode,char classcode)
        {
            try
            {
                var rule = (from ruledata in Program.rulevalueslist
                            where (ruledata.productcode.Equals(productcode)) && (ruledata.ruleparameterno == ruleno)
                            where (((classcode=='A' || classcode=='R') && ruledata.classcode==classcode)||!(classcode=='A' || classcode=='R'))
                            select ruledata).FirstOrDefault();
                return (int)(rule.ruleparametervalue);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static double getRulevaluedouble(int ruleno, String productcode,char classcode)
        {
            try
            {
                var rule = (from ruledata in Program.rulevalueslist
                            where (ruledata.productcode.Equals(productcode)) && (ruledata.ruleparameterno == ruleno)
                            where (((classcode == 'A' || classcode == 'R') && ruledata.classcode == classcode) || !(classcode == 'A' || classcode == 'R'))
                            select ruledata).FirstOrDefault();
                return (double)(rule.ruleparametervalue);
            }
            catch (Exception ex)
            {
                return 0.0 ;
            }

        }

        public static Boolean getRulevalueboolean(int ruleno, String productcode,char classcode)
        {
            try
            {
                var rule = (from ruledata in Program.rulevalueslist
                            where (ruledata.productcode.Equals(productcode)) && (ruledata.ruleparameterno == ruleno)
                            where (((classcode == 'A' || classcode == 'R') && ruledata.classcode == classcode) || !(classcode == 'A' || classcode == 'R'))
                            select ruledata).FirstOrDefault();
                if (rule.ruleparametervalue.Equals(decimal.Parse("0.0")))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static double getPremiumReturnFactor(int customerage, int retirementyears, char is_smoker)
        {
            try
            {
                DataVOUniversalDataContext db = new DataVOUniversalDataContext();
                var rule = (from premiumreturn in db.premiumreturnbyyears
                            where premiumreturn.customerage.Equals(customerage) && (premiumreturn.retirementyears.Equals(retirementyears)) && premiumreturn.is_smoker.Equals((is_smoker == 'Y'? true:false))
                            select premiumreturn).FirstOrDefault();

                /*var rule = (from premiumreturn in Program.premiumreturnbyyear
                            where ((premiumreturn.customerage.Equals(customerage)) && (premiumreturn.retirementyears.Equals(retirementyears)))
                            select premiumreturn).FirstOrDefault();*/

                return (double)(rule.returnfactorvalue);
                            
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        

    }


 

}
