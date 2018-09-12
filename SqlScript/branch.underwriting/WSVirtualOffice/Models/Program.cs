using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using WSVirtualOffice.Models.businesslogic;
using WSVirtualOffice.Models.blinsurance;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using WSVirtualOffice.Models.codes;
//using WSVirtualOffice.Models.querydata;

//using System.Windows.Forms;

namespace WSVirtualOffice.Models
{
    static class Program
    {
        public static List<WSActivityrisktype> wsactivityrisktypelist { get; set; }
        public static List<WSDefermentPeriod> wsdefermentperiodlist { get; set; }
        public static List<WSAnnuityPeriod> wsAnnuityperiodlist { get; set; }
        public static List<WSClasscodeData> wsclasscodelist { get; set; }
        public static List<WSCompany> wscompanylist { get; set; }
        public static List<WSPlanGroup> wsplangrouplist { get; set; }
        public static List<WSCountry> wscountrylist { get; set; }
        public static List<WSFrequencytype> wsfrequncytypelist { get; set; }
        public static List<WSGender> wsgenderlist { get; set; }
        public static List<WSHealthrisktype> wshealthrisktypelist { get; set; }        
        public static List<WSMaritalStatus> wsmaritalstatuslist { get; set; }
        public static List<WSInvestmentprofile> wsinvestmentprofilelist { get; set; }
        public static List<WSProduct> wsproductlist { get; set; }
        public static List<WSCalculatetype> wscalculatetypelist { get; set; }
        public static List<WSContributionType> wscontributiontypelist { get; set; }
        public static List<WSPlantype> wsplantypelist { get; set; }
        
        
        
        public static Int32 systemno;

        public static String[] weeknames = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };        
        public static List<userdet> userlist;
        public static List<businesslogic.Userdata> userdetailslist;
        public static List<usertypedet> usertypelist = new List<usertypedet>();
        public static List<roledet> rolelist = new List<roledet>();

        public static  DataVOUniversalDataContext db;
        public static mortalityvaluesdet[] mortalitydata;
        public static List<activityrisktypedet> actrisklist = new List<activityrisktypedet>();
        public static List<emailtypedet> emailtypelist = new List<emailtypedet>();
        public static List<genderdet> genderlist = new List<genderdet>();
        public static List<phonetypedet> phonetypelist = new List<phonetypedet>();
        public static List<maritalstatusdet> maritalstatuslist = new List<maritalstatusdet>();
        public static List<referraltypedet> referraltypeslist = new List<referraltypedet>();
        public static List<healthrisktypedet> healthrisklist = new List<healthrisktypedet>();
        public static List<investmentprofiledet> investprofilelist = new List<investmentprofiledet>();
        public static List<frequencytypedet> frequencylist = new List<frequencytypedet>();
        public static List<commissiondet> commissionlist = new List<commissiondet>();
        public static List<vwinvestmentprofilevalue> investprofilevalueslist = new List<vwinvestmentprofilevalue>();
        public static List<ruleparametervaluesdet> rulevalueslist = new List<ruleparametervaluesdet>();
        public static List<contributiontypedet> contrtypeslist = new List<contributiontypedet>();
        public static List<calculatetypedet> calctypeslist = new List<calculatetypedet>();
        public static List<calculatetypeobdet> calcobtypeslist = new List<calculatetypeobdet>();
        public static List<productdet> productslist = new List<productdet>();
        public static List<relationshiptypedet> relationslist = new List<relationshiptypedet>();
        public static List<plangroupdet> plangroupslist = new List<plangroupdet>();
        public static List<plantypedet> plantypeslist = new List<plantypedet>();
        public static List<identificationtypedet> idtypeslist = new List<identificationtypedet>();
        public static List<occupationtypedet> occtypeslist = new List<occupationtypedet>();
        public static List<professiontypedet> professiontypeslist = new List<professiontypedet>();
        public static List<countrydet> countrieslist = new List<countrydet>();
        public static List<entitytypedet> entitylist = new List<entitytypedet>();

        public static List<invprofilecompareratesdet> invcomparelist = new List<invprofilecompareratesdet>();
        public static List<positiontypedet> positiontypeslist = new List<positiontypedet>();
        public static List<logintypedet> logintypelist = new List<logintypedet>();
        public static List<languagedet> languageslist = new List<languagedet>();
        public static List<insuranceleveldet> insurancelevelslist = new List<insuranceleveldet>();
        public static List<identificationtypedet> identificationtypeslist = new List<identificationtypedet>();
        public static List<examdet> examslist = new List<examdet>();
        public static List<examconditionsdet> examconditionslist = new List<examconditionsdet>();
        public static List<currencydet> currencylist = new List<currencydet>();
        public static List<calculatetypedet> calculatetypeslist = new List<calculatetypedet>();
        public static List<beneficiarytypedet> beneficiarytypeslist = new List<beneficiarytypedet>();
        //public static List<positiontypedet> positiontypeslist = new List<positiontypedet>();

        public static List<surrenderpenaltydet> surrenderpenaltylist = new List<surrenderpenaltydet>();

        // new additions
        public static List<String> actrisksddl = new List<String>();
        public static List<String> healthrisksddl = new List<String>();
        public static List<String> calculatetypeslife = new List<String>();
        public static List<String> contributiontypeslife = new List<String>();

        public static List<String> calculatetypesred = new List<String>();
        public static List<String> contributiontypesred = new List<String>();

        public static List<String> calculatetypesterm = new List<String>();
        public static List<String> contributiontypesterm = new List<String>();

        public static List<String> plantypesred = new List<String>();
        public static List<String> plantypeslife = new List<String>();
        public static List<String> plantypesterm = new List<String>();

        public static List<companydet> companieslist = new List<companydet>();
        public static List<logitemdet> Logitemcall = new List<logitemdet>();

        public static List<frequencycostdet> freqcostlist = new List<frequencycostdet>();
        public static List<productcanceldet> cancelist = new List<productcanceldet>();
        public static List<productcanceldetailsdet> canceldetailslist = new List<productcanceldetailsdet>();
        public static List<productcurrencydet> prodcurlist = new List<productcurrencydet>();

        public static List<hierarchydet> hierarchylist = new List<hierarchydet>();

        public static List<agentstatusdet> registertypeslist = new List<agentstatusdet>();
        public static List<approvaltypedet> approvallist = new List<approvaltypedet>();
        public static List<annuityperioddet> annuityperiodlist = new List<annuityperioddet>();
        public static List<defermentperioddet> defermentperiodlist = new List<defermentperioddet>();

        public static List<premiumreturnbyyear> premiumreturnbyyear = new List<premiumreturnbyyear>();

        public static int callorvisit = 0;


        //public static Insurancerules[] 



        public static String agentcode = null;
        //public static long customerno = 0;
        //public static long customerplanno = 0;


        public static List<Propdata> spanishLangData = null;
        public static List<Propdata> frenchLangData = null;
        public static List<Propdata> portugueseLangData = null;
        public static List<Propdata> chineseLangData = null;

        //public static List<string> masters = new List<string>();
        
        public static List<lookupdatadet> lookupdatalist = null;

        public static String currentlanguage = "English";

        public static Boolean isdecimal(String t1)
        {
            try
            {
                Decimal d1 = Decimal.Parse(t1);
            }
            catch (FormatException ex)
            {
                return false;

            }
            return true;
        }


        public static Boolean isPositiveDecimal(String t1)
        {
            try
            {
                Decimal d1 = Decimal.Parse(t1);

                if (d1 < 0)
                {
                    return false;
                }
            }
            catch (FormatException ex)
            {
                return false;

            }
            return true;
        }


        public static Boolean isinteger(String t1)
        {
            try
            {
                Int32 d1 = Int32.Parse(t1);
            }
            catch (FormatException ex)
            {
                return false;

            }
            return true;
        }

        public static Boolean isLong(String t1)
        {
            try
            {
                Int64 d1 = Int64.Parse(t1);
            }
            catch (FormatException ex)
            {
                return false;

            }
            return true;
        }


        public static Boolean isPositiveInteger(String t1)
        {
            try
            {
                Int32 d1 = Int32.Parse(t1);
                if (d1 < 0)
                {
                    return false;
                }
            }
            catch (FormatException ex)
            {
                return false;

            }
            return true;
        }

        public static Boolean isdate(String t1)
        {
            //try
            //{
            //    DateTime d1 = DateTime.Parse(t1);
            //}
            //catch (FormatException ex)
            //{
            //    return false;

            //}
            //return true;
            try
            {
                DateTime d1;
                return DateTime.TryParse(t1, out d1);
            }
            catch (FormatException ex)
            {
                return false;
            }
        }

        public static int CalculateAge(String birthdate)
        {
            DateTime dob = DateTime.Parse(birthdate);
            // get the difference in years
            int years = DateTime.Now.Year - dob.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (DateTime.Now.Month < dob.Month || (DateTime.Now.Month == dob.Month && DateTime.Now.Day < dob.Day))
                years--;

            return years;
        }

        public static Boolean isTime(String time)
        {
            Regex r1 = new Regex("^([0-1][0-9]|[2][0-3])(:([0-5][0-9])){1,2}$");
            return r1.Match(time).Success;

        }

        /*
        public static String getNumberstring(long num)
        {
            
        }*/

        public static long getNewillustrationno()
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                return (from item in newdb.customerPlandets
                        select item.illustrationno).Max().Value + 1;


            }

            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return 0;

        }

        public static Boolean isOnlyChar(string temp)
        {
            if (temp.Trim().Equals(""))
            {
                return true;
            }
            string pattern = @"^[a-zA-Z\s]+$";


            System.Text.RegularExpressions.Match match = Regex.Match(temp.Trim(), pattern, RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;
        
        }

        public static Boolean isOnlyCharDot(string temp)
        {
            if (temp.Trim().Equals(""))
            {
                return true;
            }
            string pattern = @"^[a-zA-Z\s.]+$";


            System.Text.RegularExpressions.Match match = Regex.Match(temp.Trim(), pattern, RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;

        }

        public static Boolean isOnlyCharSpl(string temp)
        {
            if (temp.Trim().Equals(""))
            {
                return true;
            }
            string pattern = @"[a-zA-Z\s!@~#$%^&*()|\/?<>':;]$";


            System.Text.RegularExpressions.Match match = Regex.Match(temp.Trim(), pattern, RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static Boolean isAlphaNumeric(string temp)
        {
            if (temp.Trim().Equals(""))
            {
                return true;
            }
            string pattern = @"^[a-zA-Z\s0-9]+$";


            System.Text.RegularExpressions.Match match = Regex.Match(temp.Trim(), pattern, RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else
                return false;

        }

        private static  double calculatepv(double growthrate, int frequency, double amount)
        {
            double netamount = amount;
            for (int i = 1; i < frequency; i++)
            {
                netamount = netamount + amount * (1.0 / Math.Pow((1 + growthrate), i));

            }
            return netamount;

        }


        public static double calculateannualizedpremium(int frequency, double periodicpayment, double penaltypercent, double annualgrowthtrate)
        {
            double netperiodicpayment = periodicpayment / (1 + penaltypercent);
            //MessageBox.Show(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,netperiodicpayment.ToString());
            double periodicgrowthrate = Math.Pow((1 + annualgrowthtrate), 1.0 / frequency * 1.0) - 1;
            //MessageBox.Show(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,periodicgrowthrate.ToString());
            return calculatepv(periodicgrowthrate, frequency, netperiodicpayment);

        }


        public static String getDispllustrationno(String productcode, Int32 systemno, Int32 illustrationno)
        {
            return productcode + "-" + systemno.ToString("000") + "-" + illustrationno.ToString("00000");
        }



        public static decimal getDecimalvaluefromcurrency(char classcode, String valuestring)
        {
            if (classcode != ' ')
            {
                valuestring = valuestring.Trim();
                String curstring = Currencytypes.Currencycode(classcode);
                valuestring = valuestring.Replace(curstring, "");
                if (!valuestring.Equals(""))
                {
                    return decimal.Parse(valuestring);
                }
                else
                {
                    return 0;
                }
            }
            return 0;
            
        }


        public static String getCurrencyString(char classcode, double value)
        {
            String curstring = Currencytypes.Currencycode(classcode);
            return curstring + " " + getThousandseperatedString(value);
        }

        //public String convertedCurrency(string valuestring)
        //{
        //    char classcode;
        //    if (valuestring.Contains("$"))
        //    {
        //        classcode = 'A';
        //    }
        //    else
        //    {
        //        classcode = 'E';
        //    }
           

            
            
        //    String curstring = Currencytypes.Currencycode(classcode);
        //    return curstring + " " + getThousandseperatedString(double.Parse(getDecimalvaluefromcurrency(classcode,valuestring).ToString()));
        //}

        public static String getThousandseperatedString(double value)
        {
            return String.Format("{0:#,0}", value);
        }

        public static String getThousandseperateddecimalString(double value)
        {
            return String.Format("{0:#,0.00}", value);
        }

        public static String getTwodecimalString(double value)
        {
            return String.Format("{0:0.00}", value);
        }

        public static DataVOUniversalDataContext getDbConnection()
        {
            try
            {
                DataVOUniversalDataContext newdb = new DataVOUniversalDataContext();
                return newdb;
            }
            catch (Exception ex)
            {
                throw new Exception("db connection has issues");
                //return null;
            }
        }

    }
}


