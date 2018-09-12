using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    class IinsuranceMain
    {

        public String product;
        public String plantype;
        public String contributiontype;


        private String contributionuntilagestr;
        private String contributionperiodstr;


        public int untilage;
        public int numberofyears;

        public String calculatetype;

        private String insuredamountstr;
        public double insuredamount;

        private String periodicpremimamountstr;

        public double premiumcost;

        public double periodicpremiumamount;

        public String frequencytype;
        public String investmentprofile;
        public int age;
        public String gender;
        public String smoker;
        public String country;
        public String activityrisktype;
        public String healthrisktype;

        private String financialgoal;
        public int financialgoalage;
        private double financialgoalamount;

        private String initialcontribution;
        public double initialcontributionamount;


        // start rider definition

        public String rideradb;
        public double rideradbamount;

        public String riderterm;
        public int ridertermuntilage;
        public double ridertermamount;

        public String rideracdb;


        public String riderci;
        public double riderciamount;

        //public String rideroir;
        public double rideroiramount;
        public int oirage;
        public String oirgender;
        public String oirsmoker;
        public int oiruntilage;
        public String oiractivityrisk;
        public String oirhealthrisk;

        public char rideradbcode = 'N';
        public char ridertermcode = 'N';
        public char rideracdbcode = 'N';
        public char ridercicode = 'N';
        public char rideroircode = 'N';

        public double rideradbcost;
        public double ridertermcost;
        public double rideracdbcost;
        public double ridercicost;
        public double rideroircost;


        private double calctargetamount;
        private double calcinsuredamount;
        private double calcminimumpremium;
        private double calcyearlypremium;
        private double calcriderpremium;

        // end rider definition        

        public String productcode;
        public char plantypecode;
        public char contributiontypecode;
        public char calculatetypecode;
        public char frequencytypecode;

        public int frequencytypevalue;
        public double frequencytypepenalty;

        public char investmentprofilecode;
        public char gendercode;
        public char smokercode;
        public int countryno;

        public double activityrisktypevalue;
        public double healthrisktypevalue;

        public char oirgendercode;
        public char oirsmokercode;

        public double oiractivityrisktypevalue;
        public double oirhealthrisktypevalue;

        //public char healthrisktypecode_1;

        public char financialgoalcode;
        public char initialcontributioncode;

        public double annualizedpremiumamount;

        public double growthrate;
        public double costoffunds;
        public double netgrowthrate;


        public double countryrisk;
        private ICommissiondata[] commissiondata = null;

        private ISurrenderpenaltydata[] surrenderpenaltydata = null;

        public double[] varpremiumamount = null;
        public double[] varinsuredamount = null;
        public double[] varinvestprofile = null;
        public double[] varsurrenderamount = null;
        public double[] varloanamount = null;
        public double[] varloanrepayamount = null;

        public char varpremiumcode = 'N';
        public char varinsuredcode = 'N';
        public char varinvestprofilecode = 'N';
        public char varsurrendercode = 'N';
        public char varloancode = 'N';
        public char varloanrepaycode = 'N';




        private double targetaccountvalue = 0.0;
        private double precision = 100.0;

        private IMortalitydata[] mortalitydata = null;
        private IMortalitydata[] oirmortalitydata = null;

        // rule values
        public int insurancemaxage;
        public double GSMaximumtargetamount;
        public double GSMinimumtargetamount;
        public double GSMaximuminsuredamount;
        public double GSMinimuminsuredamount;
        public double GSMaximumpremiumamount;
        public double GSMinimumpremiumamount;
        public double Minimumpremiumamount;
        public double Minimuminsuredamount;
        public double Maximuminsuredamount;
        public double Targetoverage;
        public double Premiumreserve;
        public int Targetcontributionperiod;
        public double Monthlyfeevalue;
        public double Monthlyfeevalueyear;
        public double Loadchargepercent;
        public int GSMinimumcontributionperiod;
        public int Maxage;
        public int Maxageforninguna;
        public double Minimumpremiumtotargetfactor;
        public double Targetdiscountfactor;
        public int Rideradbmaxage;
        public double Rideradbfactor;
        public double surrendercharge;
        public double partialsurrendercharge;
        public double surrenderexcesspenalty;

        public double TargetNingunaPercent;
        public double LoanInterestRate;
        public double LoanPrincipalGrowthRate;
        public Boolean LoanPrincipalGrowInvestRate;

        public double InterestLoanRate;
        public double LoanAssetRate;
        public Boolean IsLoanRate;



        public Boolean isOpeningbalance = false;
        public int planyearstart;
        public double openingbalanceamount = 0.0;


        /*
        private static double calculateAccountvalue(IMainInsuranceData insdata,double targetamount,double[] varinsuredamount,double[] varpremiumamount)
        {
            double accountvalue = 0.0;
            return 0.0;
            


        }*/

        private static Mainvaluedata calculateaccountvalue(double insuredamount, Accountvaluedata[] acvaluedata, Productinvprofile prodprofile)
        {
            Mainvaluedata maindata = new Mainvaluedata();
            double accountvalue = 0.0;
            


            Targetamountdata[] targetvaluedata = new Targetamountdata[acvaluedata.Length];
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                targetvaluedata[i] = new Targetamountdata();
                targetvaluedata[i].accountvalue = acvaluedata[i].accountvalue;
                //targetvaluedata[i].actualcommission = acvaluedata[i].actualcommission;
                targetvaluedata[i].age = acvaluedata[i].age;
                targetvaluedata[i].commissionpercentvalue = acvaluedata[i].commissionpercentvalue;
                targetvaluedata[i].costofinsurance = acvaluedata[i].costofinsurance;
                targetvaluedata[i].targetoverage = acvaluedata[i].targetoverage;
                //targetvaluedata[i].loadcharge = acvaluedata[i].loadcharge;
                targetvaluedata[i].loadchargepercent = acvaluedata[0].loadchargepercent;
                targetvaluedata[i].monthlyfeevalue = acvaluedata[i].monthlyfeevalue;
                targetvaluedata[i].mortalityrate = acvaluedata[i].mortalityrate;
                targetvaluedata[i].netgrowthrate = acvaluedata[i].netgrowthrate;
                targetvaluedata[i].sno = acvaluedata[i].sno;
                targetvaluedata[i].targetamount = 0;
                targetvaluedata[i].insuredamount = insuredamount;

            }
            double targetamount = Targetamountdata.getTargetamount(0, 100000, 0, 10, targetvaluedata, prodprofile);
            maindata.targetamount = targetamount;




            //insurancecost+commission+loadcharge



            for (int i = 0; i < acvaluedata.Length; i++)
            {
                //- insuredadmount*(1/1000.0) * (1 / )
                //double commissionamount = acvaluedata[i].premiumamount * acvaluedata[i].commissionpercentvalue;
                double commissionamount = 0.0;
                double excesscommissionamount = 0.0;
                double loadcharge = acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve)) * acvaluedata[i].loadchargepercent;

                double adjustedpremium = acvaluedata[i].premiumamount / (1 + acvaluedata[i].premiumreserve);

                if (acvaluedata[i].premiumamount > 0)
                {
                    commissionamount = targetamount * acvaluedata[i].commissionpercentvalue;
                    if ((adjustedpremium - targetamount) > 0)
                    {
                        //excesscommissionamount = (acvaluedata[i].premiumamount - targetamount) * acvaluedata[i].excesspercentvalue;
                        excesscommissionamount = (adjustedpremium - targetamount) * acvaluedata[i].excesspercentvalue;
                    }
                    commissionamount = commissionamount + excesscommissionamount;
                }
                double costofinsurance = 0.0;
                if (prodprofile.plantypecode == 'F')
                {
                    costofinsurance = (insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                }
                else
                {
                    costofinsurance = (insuredamount) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);

                }


                //double costofinsurance1 = (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);

                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                acvaluedata[i].targetamount = targetamount;

            }
            maindata.accountvalue = accountvalue;
            return maindata;
        }

    }
}
