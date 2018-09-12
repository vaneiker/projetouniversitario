using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    struct Targetamountdata
    {

        public int sno;
        public int age;
        public double mortalityrate;
        public double targetamount;
        //public double loadcharge;
        public double loadchargepercent;
        public double monthlyfeevalue;
        public double netgrowthrate;
        public double targetoverage;
        public double accountvalue;
        public double costofinsurance;
        public double commissionpercentvalue;
        public double actualcommission;

        public double insuredamount;
        public double premiumamount;

        public double activityrisk;
        public double illnessrisk;

        //public double netpremiumamount;
        //public double accountvalue;
        //public double totalaccountvalue;

        public static double getTargetamount(double mintargetamount, double maxtargetamount, double targetaccountvalue, double precision, Targetamountdata[] targetvaluedata, Productinvprofile prodprofile)
        {
            return goalseek(mintargetamount, maxtargetamount, targetaccountvalue, precision, targetvaluedata,prodprofile);
        }


        private static double goalseek(double mintargetamount, double maxtargetamount, double targetaccountvalue, double precision, Targetamountdata[] targetvaluedata, Productinvprofile prodprofile)
        {
            //double minaccountvalue = calculateaccountvalue(mininsuredamount);
            //double maxaccountvalue = calculateaccountvalue(maxinsuredamount);                
            double midtargetamount = (maxtargetamount + mintargetamount) / 2.0;
            double midaccountvalue = calculateaccountvalue(midtargetamount, targetvaluedata,prodprofile);
            if (midaccountvalue > (targetaccountvalue - precision) && midaccountvalue < (targetaccountvalue + precision))
            {
                return midtargetamount;
            }
            else
            {
                if (midaccountvalue < precision)
                {
                    return goalseek(midtargetamount, maxtargetamount, targetaccountvalue, precision, targetvaluedata,prodprofile);
                }
                else
                {
                    return goalseek(mintargetamount, midtargetamount, targetaccountvalue, precision, targetvaluedata,prodprofile);
                }
            }
            //return 0.0;
        }

        private static double calculateaccountvalue(double targetamount, Targetamountdata[] targetvaluedata, Productinvprofile prodprofile)
        {
            double accountvalue = 0.0;
            for (int i = 0; i < targetvaluedata.Length; i++)
            {
                //- insuredadmount*(1/1000.0) * (1 / )
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                if (i <= 24)
                {

                    double commissionamount = targetamount * targetvaluedata[i].commissionpercentvalue;
                    //double costofinsurance = (targetvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * ((targetvaluedata[i].mortalityrate * (1 + targetvaluedata[i].activityrisk) * (1 + targetvaluedata[i].targetoverage)) + targetvaluedata[i].illnessrisk);
                    double costofinsurance = 0.0;// (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                    if (prodprofile.plantypecode == 'F')
                    {
                        costofinsurance = (targetvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * ((targetvaluedata[i].mortalityrate * (1 + targetvaluedata[i].activityrisk) * (1 + targetvaluedata[i].targetoverage)) + targetvaluedata[i].illnessrisk);
                    }
                    else
                    {
                        costofinsurance = (targetvaluedata[i].insuredamount ) * (1 / 1000.0) * ((targetvaluedata[i].mortalityrate * (1 + targetvaluedata[i].activityrisk) * (1 + targetvaluedata[i].targetoverage)) + targetvaluedata[i].illnessrisk);
                    }

                    accountvalue = (1 + targetvaluedata[i].netgrowthrate) * (accountvalue + (targetamount) - targetamount * (targetvaluedata[i].loadchargepercent) - targetvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                }
                else
                {
                    double commissionamount = 0 * targetvaluedata[i].commissionpercentvalue;

                    //double costofinsurance = (targetvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * ((targetvaluedata[i].mortalityrate * (1 + targetvaluedata[i].activityrisk) * (1 + targetvaluedata[i].targetoverage)) + targetvaluedata[i].illnessrisk);

                    double costofinsurance = 0.0;// (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                    if (prodprofile.plantypecode == 'F')
                    {
                        costofinsurance = (targetvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * ((targetvaluedata[i].mortalityrate * (1 + targetvaluedata[i].activityrisk) * (1 + targetvaluedata[i].targetoverage)) + targetvaluedata[i].illnessrisk);
                    }
                    else
                    {
                        costofinsurance = (targetvaluedata[i].insuredamount ) * (1 / 1000.0) * ((targetvaluedata[i].mortalityrate * (1 + targetvaluedata[i].activityrisk) * (1 + targetvaluedata[i].targetoverage)) + targetvaluedata[i].illnessrisk);
                    }

                    accountvalue = (1 + targetvaluedata[i].netgrowthrate) * (accountvalue + (0) - targetvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                }

            }
            return accountvalue;
        }

    }
}
