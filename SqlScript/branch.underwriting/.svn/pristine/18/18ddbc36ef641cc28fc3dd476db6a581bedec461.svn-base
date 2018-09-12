using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WSVirtualOffice.Models.businesslogic
{
    public class IllustrationRecord
    {
        public String productcode;
        public char plantypecode;
        public char classcode;
        public char contributiontypecode;
        public String investmentprofilecode;
        public char initialcontributioncode;
        public double initialcontributionamount;
        public char financialgoalcode;
        public int financialgoaluntilage;
        public double financialgoalamount;
        public int activityrisktypeno;
        public int healthrisktypeno;
        public char otherplancode;
        public int contributionperiod;
        public char calculatecode;
        public double insuredamount;
        public double periodicpremiumamount;
        public char frequencycode;
        public int defermentperiod;
        public int annuityperiod;
        public char maritalstatuscode;
        public int age;
        public char gendercode;
        public char smokercode;
        public double annuityamount;
        public int contributionuntilage;

        public OtherInsuranceRecord oirdata;
        public AddlInsuranceRecord termdata;
        public CriticalIllnessRecord cidata;
        public ADBRecord adbdata;

        public Boolean isvalid = false;


        public enum Fields
        {
            PRODUCTCODE,
            PLANTYPECODE,
            CLASSCODE,
            CONTRIBUTIONTYPECODE,
            INVESTMENTPROFILECODE,
            INITIALCONTRIBUTIONCODE,
            INITIALCONTRIBUTIONAMOUNT,
            FINANCIALGOALCODE,
            FINANCIALGOALUNTILAGE,
            FINANCIALGOALAMOUNT,
            ACTIVITYRISKTYPENO,
            HEALTHRISKTYPENO,
            OTHERPLANCODE,
            CONTRIBUTIONPERIOD,
            CALCULATECODE,
            INSUREDAMOUNT,
            PERIODICPREMIUMAMOUNT,
            FREQUENCYCODE,
            DEFERMENTPERIOD,
            ANNUITYPERIOD,
            MARITALSTATUSCODE,
            AGE,
            GENDERCODE,
            SMOKERCODE,
            ANNUITYAMOUNT,
            CONTRIBUTIONUNTILAGE
        }

        public static bool Compare(HttpSessionState session, Fields field, object compareField)
        {
            if (!GetCurrentRecord(session).isvalid)
                return false;

            switch (field)
            {
                case Fields.PRODUCTCODE: { return CompareString(session, compareField, GetCurrentRecord(session).productcode); }
                case Fields.PLANTYPECODE: { return CompareString(session, compareField, GetCurrentRecord(session).plantypecode); }
                case Fields.CLASSCODE: { return CompareString(session, compareField, GetCurrentRecord(session).classcode); }
                case Fields.CONTRIBUTIONTYPECODE: { return CompareString(session, compareField, GetCurrentRecord(session).contributiontypecode); }
                case Fields.INVESTMENTPROFILECODE: { return CompareString(session, compareField, GetCurrentRecord(session).investmentprofilecode); }
                case Fields.INITIALCONTRIBUTIONCODE: { return CompareString(session, compareField, GetCurrentRecord(session).initialcontributioncode); }
                case Fields.INITIALCONTRIBUTIONAMOUNT: { return CompareDouble(session, compareField, GetCurrentRecord(session).initialcontributionamount); }
                case Fields.FINANCIALGOALCODE: { return CompareString(session, compareField, GetCurrentRecord(session).financialgoalcode); }
                case Fields.FINANCIALGOALUNTILAGE: { return CompareInt(session, compareField, GetCurrentRecord(session).financialgoaluntilage); }
                case Fields.FINANCIALGOALAMOUNT: { return CompareDouble(session, compareField, GetCurrentRecord(session).financialgoalamount); }
                case Fields.ACTIVITYRISKTYPENO: { return CompareInt(session, compareField, GetCurrentRecord(session).activityrisktypeno); }
                case Fields.HEALTHRISKTYPENO: { return CompareInt(session, compareField, GetCurrentRecord(session).healthrisktypeno); }
                case Fields.OTHERPLANCODE: { return CompareString(session, compareField, GetCurrentRecord(session).otherplancode); }
                case Fields.CONTRIBUTIONPERIOD: { return CompareInt(session, compareField, GetCurrentRecord(session).contributionperiod); }
                case Fields.CALCULATECODE: { return CompareString(session, compareField, GetCurrentRecord(session).calculatecode); }
                case Fields.INSUREDAMOUNT: { return CompareDouble(session, compareField, GetCurrentRecord(session).insuredamount); }
                case Fields.PERIODICPREMIUMAMOUNT: { return CompareDouble(session, compareField, GetCurrentRecord(session).periodicpremiumamount); }
                case Fields.FREQUENCYCODE: { return CompareString(session, compareField, GetCurrentRecord(session).frequencycode); }
                case Fields.DEFERMENTPERIOD: { return CompareInt(session, compareField, GetCurrentRecord(session).defermentperiod); }
                case Fields.ANNUITYPERIOD: { return CompareInt(session, compareField, GetCurrentRecord(session).annuityperiod); }
                case Fields.MARITALSTATUSCODE: { return CompareString(session, compareField, GetCurrentRecord(session).maritalstatuscode); }
                case Fields.AGE: { return CompareInt(session, compareField, GetCurrentRecord(session).age); }
                case Fields.GENDERCODE: { return CompareString(session, compareField, GetCurrentRecord(session).maritalstatuscode); }
                case Fields.SMOKERCODE: { return CompareString(session, compareField, GetCurrentRecord(session).smokercode); }
                case Fields.ANNUITYAMOUNT: { return CompareDouble(session, compareField, GetCurrentRecord(session).annuityamount); }
                case Fields.CONTRIBUTIONUNTILAGE: { return CompareInt(session, compareField, GetCurrentRecord(session).contributionuntilage); }
            }
            return false;
        }

        private static IllustrationRecord GetCurrentRecord(HttpSessionState session)
        {
            IllustrationRecord currentRecord = Sessionclass.getSessiondata(session).currentillustrationrecord;
            if (currentRecord != null)
                return currentRecord;
            else
            {
                currentRecord = new IllustrationRecord();
                Sessionclass.setCurrentIllustrationRecord(session, currentRecord);
                return currentRecord;
            }
        }

        private static bool CompareString(HttpSessionState session, object str1, object str2)
        {
            if (!CheckNull(session, str1, str2))
                return false;

            if (str1.ToString().ToUpper().Equals(str2.ToString().ToUpper()))
            {
                return true;
            }
            else
            {
                SetCurrentRecordInvalid(session);
                return false;
            }
        }

        private static bool CompareInt(HttpSessionState session, object value1, object value2)
        {
            if (!CheckNull(session, value1, value2))
                return false;

            int temp1 = 0, temp2 = 0;

            if (int.TryParse(value1.ToString(), out temp1) == false || int.TryParse(value2.ToString(), out temp2) == false)
            {
                SetCurrentRecordInvalid(session);
                return false;
            }

            if (Convert.ToInt32(value1) == Convert.ToInt32(value2))
            {
                return true;
            }
            else
            {
                SetCurrentRecordInvalid(session);
                return false;
            }
        }

        private static bool CompareDouble(HttpSessionState session, object value1, object value2)
        {
            if (!CheckNull(session, value1, value2))
                return false;

            double temp1 = 0, temp2 = 0;

            if (double.TryParse(value1.ToString(), out temp1) == false || double.TryParse(value2.ToString(), out temp2) == false)
            {
                SetCurrentRecordInvalid(session);
                return false;
            }

            if (Convert.ToDouble(value1) == Convert.ToDouble(value2))
            {
                return true;
            }
            else
            {
                SetCurrentRecordInvalid(session);
                return false;
            }
        }

        private static bool CheckNull(HttpSessionState session, object field1, object field2)
        {
            if (field1 == null && field2 == null)
                return true;

            if (field1 == null || field2 == null)
            {
                SetCurrentRecordInvalid(session);
                return false;
            }
            return true;
        }

        private static void SetCurrentRecordInvalid(HttpSessionState session)
        {
            IllustrationRecord currentRecord = GetCurrentRecord(session);
            currentRecord.isvalid = false;
            Sessionclass.setCurrentIllustrationRecord(session, currentRecord);
        }

        //private void SaveIllustrationRecord(String productcode, char plantypecode, char classcode, char contributiontypecode, String investmentprofilecode, char initialcontributioncode, double initialcontributionamount, char financialgoalcode, int financialgoaluntilage, double financialgoalamount, int activityrisktypeno, int healthrisktypeno, char otherplancode, int contributionperiod, char calculatecode, double insuredamount, double periodicpremiumamount, char frequencycode, int defermentperiod, int annuityperiod, char maritalstatuscode, int age, char gendercode, char smokercode, OtherInsuranceRecord oirdata, AddlInsuranceRecord termdata, CriticalIllnessRecord cidata, ADBRecord adbdata, Boolean isvalid)
        //public static void SaveIllustrationRecord(HttpSessionState session, String productcode, char plantypecode, char classcode, char contributiontypecode, String investmentprofilecode, char initialcontributioncode, double initialcontributionamount, char financialgoalcode, int financialgoaluntilage, double financialgoalamount, int activityrisktypeno, int healthrisktypeno, char otherplancode, int contributionperiod, char calculatecode, double insuredamount, double periodicpremiumamount, char frequencycode, int defermentperiod, int annuityperiod, Boolean isvalid)
        public static void SavePlanInfoRecord(HttpSessionState session, customerPlandet custPlan, string initialContributionCode, char isValid)
        {
            IllustrationRecord currentRecord = GetCurrentRecord(session);

            if (currentRecord == null)
            {
                currentRecord = new IllustrationRecord();
            }

            currentRecord.activityrisktypeno = custPlan.activityrisktypeno;
            //currentRecord.adbdata = custPlan.adbdata;
            //currentRecord.age = custPlan.age;
            currentRecord.annuityperiod = Convert.ToInt32(custPlan.retirementperiod);
            currentRecord.calculatecode = custPlan.calculatetypecode;
            //currentRecord.cidata = custPlan.cidata;
            currentRecord.classcode = custPlan.@class;
            currentRecord.contributionperiod = custPlan.contributionperiod;
            currentRecord.contributiontypecode = custPlan.contributiontypecode;
            currentRecord.defermentperiod = Convert.ToInt32(custPlan.defermentperiod);
            currentRecord.financialgoalamount = Convert.ToDouble(custPlan.financialgoalamount);
            currentRecord.financialgoalcode = custPlan.financialgoal;
            currentRecord.financialgoaluntilage = custPlan.financialgoalage;
            currentRecord.frequencycode = custPlan.frequencytypecode;
            //currentRecord.gendercode = custPlan.gendercode;
            currentRecord.healthrisktypeno = custPlan.healthrisktypeno;
            currentRecord.initialcontributionamount = Convert.ToDouble(custPlan.initialcontribution);
            currentRecord.initialcontributioncode = Convert.ToChar(initialContributionCode);
            currentRecord.insuredamount = Convert.ToDouble(custPlan.insuredamount);
            currentRecord.investmentprofilecode = custPlan.investmentprofilecode.ToString();
            currentRecord.isvalid = (custPlan.illustrationverified == 'Y' ? true : false);
            //currentRecord.maritalstatuscode = custPlan.maritalstatuscode;
            //currentRecord.oirdata = custPlan.oirdata;
            currentRecord.otherplancode = Convert.ToChar(custPlan.otherplans);
            currentRecord.periodicpremiumamount = Convert.ToDouble(custPlan.premiumamount);
            currentRecord.plantypecode = custPlan.plantypecode;
            currentRecord.productcode = custPlan.productcode;
            //currentRecord.smokercode = custPlan.smokercode;
            //currentRecord.termdata = custPlan.termdata;
            currentRecord.annuityamount = Convert.ToDouble(custPlan.annuityamount);

            Sessionclass.setCurrentIllustrationRecord(session, currentRecord);
        }

        public static void SaveClientInfoRecord(HttpSessionState session, customerdet cust, char isValid)
        {
            IllustrationRecord currentRecord = GetCurrentRecord(session);

            if (currentRecord == null)
            {
                currentRecord = new IllustrationRecord();
            }

            currentRecord.age = Convert.ToInt32(cust.Age);
            currentRecord.gendercode = cust.gendercode;
            currentRecord.isvalid = (isValid == 'Y' ? true : false);
            currentRecord.maritalstatuscode = Convert.ToChar(cust.MaritalStatuscode);
            currentRecord.smokercode = cust.Smoker;
            
            Sessionclass.setCurrentIllustrationRecord(session, currentRecord);
        }
    }
}
