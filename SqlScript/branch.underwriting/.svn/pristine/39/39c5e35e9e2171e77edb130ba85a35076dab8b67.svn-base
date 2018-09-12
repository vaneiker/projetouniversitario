using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    struct WSVirtualOffice
    {

        public int sno;
        public int age;
        public double mortalityrate;
        public double loadchargepercent;
        public double netgrowthrate;
        public double adbaccountvalue;
        public double accountvalue;
        public double costofinsurancepercent;
        public double commissionpercentvalue;
        public double excesspercentvalue;
        public int contributionperiod;
        public double targetoverage;
        //public String ridertype;

        public double activityrisk;
        public double illnessrisk;

        public static readonly String ADB = "ADB";
        public static readonly String TERM = "TERM";
        public static readonly String OTHER = "ACDB";

        //public double accountvalue;
        //public double accountvalue;
        //public double totalaccountvalue;

        public static double getRiderfee(double mintargetamount, double maxtargetamount, double targetaccountvalue, double precision, WSVirtualOffice[] ridervaluedata, double riderinsuredamount, int contributionperiod,int ridertermage, String ridertype)
        {
            return goalseek(mintargetamount, maxtargetamount, targetaccountvalue, precision, ridervaluedata, riderinsuredamount, contributionperiod,ridertermage ,ridertype);
        }


        private static double goalseek(double mintargetamount, double maxtargetamount, double accountvalue, double precision, WSVirtualOffice[] ridervaluedata, double riderinsuredamount, int contributionperiod,int ridertermage, String ridertype)
        {
            //double minaccountvalue = calculateaccountvalue(mininsuredamount);
            //double maxaccountvalue = calculateaccountvalue(maxinsuredamount);                
            double midtargetamount = (maxtargetamount + mintargetamount) / 2.0;
            double midaccountvalue = calculateaccountvalue(midtargetamount, ridervaluedata, riderinsuredamount, contributionperiod,ridertermage ,ridertype);
            if (midaccountvalue > (accountvalue - precision) && midaccountvalue < (accountvalue + precision))
            {
                return midtargetamount;
            }
            else
            {
                if (midaccountvalue < precision)
                {
                    return goalseek(midtargetamount, maxtargetamount, accountvalue, precision, ridervaluedata, riderinsuredamount, contributionperiod,ridertermage ,ridertype);
                }

                {
                    return goalseek(mintargetamount, midtargetamount, accountvalue, precision, ridervaluedata, riderinsuredamount, contributionperiod,ridertermage ,ridertype);
                }
            }
            //return 0.0;
        }

        private static double calculateaccountvalue(double rideramount, WSVirtualOffice[] ridervaluedata, double riderinsuredamount, int contributionperiod,int ridertermage ,String ridertype)
        {

            if (rideramount <= 150)
            {
                int ik = 1;

            }
            double accountvalue = 0.0;
            for (int i = 0; i < ridervaluedata.Length; i++)
            {
                //- insuredadmount*(1/1000.0) * (1 / )
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                if (ridertype.Equals(ADB))
                {
                    double commissionamount = rideramount * ridervaluedata[i].excesspercentvalue;
                    double costofinsurance =0;
                    if (ridertermage >= ridervaluedata[i].age)
                    {
                        costofinsurance = riderinsuredamount * ridervaluedata[i].costofinsurancepercent;
                    }                    
                    if (i < contributionperiod)
                    {
                        accountvalue = (1 + ridervaluedata[i].netgrowthrate) * (accountvalue + (rideramount) - rideramount * (ridervaluedata[i].loadchargepercent) - commissionamount - costofinsurance);
                    }
                    else
                    {
                        accountvalue = (1 + ridervaluedata[i].netgrowthrate) * (accountvalue - costofinsurance);
                    }

                    ridervaluedata[i].accountvalue = accountvalue;
                    ridervaluedata[i].adbaccountvalue = accountvalue;
                }
                else if (ridertype.Equals(TERM))
                {
                    double commissionamount = rideramount * ridervaluedata[i].excesspercentvalue;
                    //double costofinsurance = (riderinsuredamount - ridervaluedata[i].adbaccountvalue - accountvalue)  *(1 / 1000.0) * ((ridervaluedata[i].mortalityrate*(1+ridervaluedata[i].activityrisk) * (1 + ridervaluedata[i].targetoverage))+ridervaluedata[i].illnessrisk); 
                    double costofinsurance = 0;
                    if (ridertermage >= ridervaluedata[i].age)
                    {
                        costofinsurance = (riderinsuredamount - accountvalue) * (1 / 1000.0) * ((ridervaluedata[i].mortalityrate * (1 + ridervaluedata[i].activityrisk) * (1 + ridervaluedata[i].targetoverage)) + ridervaluedata[i].illnessrisk);
                    }
                    
                    if ((rideramount >= 180) && (rideramount <= 195))
                    {
                        int k1 = 0;
                    }

                    if (i < contributionperiod)
                    {
                        accountvalue = (1 + ridervaluedata[i].netgrowthrate) * (accountvalue + (rideramount) - rideramount * (ridervaluedata[i].loadchargepercent) - commissionamount - costofinsurance);
                        //accountvalue = (1 + ridervaluedata[i].netgrowthrate) * (accountvalue - rideramount * (ridervaluedata[i].loadchargepercent) - commissionamount - costofinsurance);
                    }
                    else
                    {
                        accountvalue = (1 + ridervaluedata[i].netgrowthrate) * (accountvalue - costofinsurance);
                    }
                    ridervaluedata[i].accountvalue = accountvalue;
                }



            }
            return accountvalue;
        }

    }
}
