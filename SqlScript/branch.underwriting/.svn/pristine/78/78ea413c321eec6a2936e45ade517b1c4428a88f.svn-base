using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.blinsurance
{
    struct Minimumpremiumdata 
    {

        //Age of user	
        //Policy Year	
        //Flow in	
        //Annual fee	
        //Insurance cost	
        //Commission cost	
        //AV 
        
        public static double getMinimumpremium(double minpremiumamount, double maxpremiumamount, double targetaccountvalue, double precision, Accountvaluedata[] minpremvaluedata,Productinvprofile profdata)
        {
            //maxterm = Rules.getRulevalueint(Rules.MINIMUM_PREMIUM_PERIOD, profdata.productcode);
            return goalseek(minpremiumamount, maxpremiumamount, targetaccountvalue, precision, minpremvaluedata,profdata);
        }


        private static double goalseek(double minpremiumamount, double maxpremiumamount, double targetaccountvalue, double precision, Accountvaluedata[] minpremvaluedata, Productinvprofile profdata)
        {
            //double minaccountvalue = calculateaccountvalue(mininsuredamount);
            //double maxaccountvalue = calculateaccountvalue(maxinsuredamount);                
            double midpremiumamount = (maxpremiumamount + minpremiumamount) / 2.0;
            double midaccountvalue = calculateaccountvalue(midpremiumamount, minpremvaluedata,profdata);
            if (midaccountvalue > (targetaccountvalue - precision) && midaccountvalue < (targetaccountvalue + precision))
            {
                return midpremiumamount;
            }
            else
            {
                if (midaccountvalue < precision)
                {
                    return goalseek(midpremiumamount, maxpremiumamount, targetaccountvalue, precision, minpremvaluedata,profdata);
                }
                else
                {
                    return goalseek(minpremiumamount, midpremiumamount, targetaccountvalue, precision, minpremvaluedata,profdata);
                }
            }
            //return 0.0;
        }

        private static double calculateaccountvalue(double targetamount, Accountvaluedata[] minpremvaluedata, Productinvprofile profdata)
        {            
            double accountvalue = 0.0;
            int maxterm = Rules.getRulevalueint(Rules.MINIMUM_PREMIUM_PERIOD, profdata.productcode, profdata.classcode);
            for (int i = 0; i < maxterm; i++)
            {
                //- insuredadmount*(1/1000.0) * (1 / )
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);                
                double commissionamount = targetamount * minpremvaluedata[i].commissionpercentvalue;
                double costofinsurance = 0.0;// (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                if (profdata.plantypecode == 'F')
                {
                    costofinsurance = (minpremvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * ((minpremvaluedata[i].mortalityrate * (1 + minpremvaluedata[i].activityrisk) * (1 + minpremvaluedata[i].targetoverage)) + minpremvaluedata[i].illnessrisk);
                }
                else
                {
                    costofinsurance = (minpremvaluedata[i].insuredamount ) * (1 / 1000.0) * ((minpremvaluedata[i].mortalityrate * (1 + minpremvaluedata[i].activityrisk) * (1 + minpremvaluedata[i].targetoverage)) + minpremvaluedata[i].illnessrisk);
                }
                //double costofinsurance = (minpremvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * ((minpremvaluedata[i].mortalityrate * (1 + minpremvaluedata[i].activityrisk) * (1 + minpremvaluedata[i].targetoverage)) + minpremvaluedata[i].illnessrisk);
                accountvalue = (1 + minpremvaluedata[i].netgrowthrate) * (accountvalue + (targetamount) - targetamount * (minpremvaluedata[i].loadchargepercent) - minpremvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);                
            }
            return accountvalue;
        }

    }
}
