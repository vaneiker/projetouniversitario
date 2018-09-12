using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    struct Riderspouseaccountdata
    {

        public int sno;
        public int age;
        public double mortalityrate;
        public double activityrisk;
        public double illnessrisk;
        public double premiumamount;

        public double insuredamount;

        //public double loadcharge;
        public double loadchargepercent;
        public double monthlyfeevalue;
        public double commission;
        public double netgrowthrate;
        public double premiumreserve;
        public double targetoverage;
        public double accountvalue;
        public double costofinsurance;

        public double commissionpercentvalue;
        public double excesspercentvalue;
        public double actualcommission;
        public double targetamount;
        //public double netpremiumamount;
        //public double accountvalue;
        //public double totalaccountvalue;

        public static double calculatepremiumamount(double minrideramount, double maxrideramount, double targetaccountvalue, double precision, Riderspouseaccountdata[] acvaluedata, int contributionperiod, int ridermaxage)
        {
            return goalseek(minrideramount, maxrideramount, targetaccountvalue, precision, acvaluedata, contributionperiod,ridermaxage);
        }


        private static double goalseek(double minrideramount, double maxrideramount, double targetaccountvalue, double precision, Riderspouseaccountdata[] acvaluedata, int contributionperiod, int ridermaxage)
        {
            //double minaccountvalue = calculateaccountvalue(mininsuredamount);
            //double maxaccountvalue = calculateaccountvalue(maxinsuredamount);                
            double midrideramount = (maxrideramount + minrideramount) / 2.0;
            double midaccountvalue = calculateaccountvalue(midrideramount, acvaluedata, contributionperiod,ridermaxage);
            if (midaccountvalue > (targetaccountvalue - precision) && midaccountvalue < (targetaccountvalue + precision))
            {
                return midrideramount;
            }
            else
            {
                if (midaccountvalue < precision)
                {
                    return goalseek(midrideramount, maxrideramount, targetaccountvalue, precision, acvaluedata, contributionperiod,ridermaxage);
                }
                else
                {
                    return goalseek(minrideramount, midrideramount, targetaccountvalue, precision, acvaluedata, contributionperiod,ridermaxage);
                }
            }
            //return 0.0;
        }



        private static double calculateaccountvalue(double rideramount, Riderspouseaccountdata[] acvaluedata, int contributionperiod, int ridermaxage)
        {
            double accountvalue = 0.0;
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                //- insuredadmount*(1/1000.0) * (1 / )
                //double commissionamount = acvaluedata[i].premiumamount * acvaluedata[i].commissionpercentvalue;
                double commissionamount = 0.0;
                double excesscommissionamount = 0.0;
                double loadcharge = rideramount * (1 / (1 + acvaluedata[i].premiumreserve)) * acvaluedata[i].loadchargepercent;
                double costofinsurance = 0;
                if (ridermaxage >= acvaluedata[i].age)
                {
                    costofinsurance = (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                }                                
                if ((rideramount >= 400) && (rideramount <= 600))
                {
                    int k11 = 1;
                }
                if (i <= contributionperiod)
                {
                    accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (rideramount * (1 / (1 + acvaluedata[i].premiumreserve))) - commissionamount - costofinsurance);
                }
                else
                {
                    accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue - costofinsurance);
                }
                //acvaluedata[i].targetamount = targetamount;
            }
            return accountvalue;
        }


        /*
        public static Riderspouseaccountdata[] calculateaccountvaluedata(double rideramount, Riderspouseaccountdata[] acvaluedata, int contributionperiod)
        {
            double accountvalue = 0.0;            
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                //double costofinsurance = 0.0;
                //double commissionamount = acvaluedata[i].premiumamount * acvaluedata[i].commissionpercentvalue;
                double commissionamount = 0.0;
                double excesscommissionamount = 0.0;
                double loadcharge = rideramount * (1 / (1 + acvaluedata[i].premiumreserve)) * acvaluedata[i].loadchargepercent;
                

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

                double costofinsurance = (insuredadmount - accountvalue) * (1 / 1000.0) * (acvaluedata[i].mortalityrate * (1 + acvaluedata[i].targetoverage));
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                acvaluedata[i].targetamount = targetamount;
                //double costofinsurance = (insuredadmount - accountvalue) * (1 / 1000.0) * (acvaluedata[i].mortalityrate * (1 + acvaluedata[i].targetoverage));
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission - costofinsurance);
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                acvaluedata[i].costofinsurance = costofinsurance;
                acvaluedata[i].accountvalue = accountvalue;
                acvaluedata[i].actualcommission = commissionamount;
            }
            return acvaluedata;
        }
        */



    }
}
