using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.blinsurance
{
    class IOpeningBalance
    {
        
        private String productcode;
        private char invprofilecode;
        private double currentvalue;        
        private char frequencytypecode;
        private double  periodicpremium;        
        private double monthlyinsurancecost;
        private int unpaidpremiums;
        private double targetamount;
        private int planyear;
        private char classcode;
        



        private double openingPeriodicRate
        {
            get
            {
                return Productinvprofile.getInvprofilerate(this.invprofilecode, productcode,classcode);
            }
        }



        private int currentyear
        {
            get
            {
                return DateTime.Now.Year;
            }

        }

        private int currentyearno
        {
            get
            {
                return   currentyear-this.planyear + 1;
            }

        }

        private double regularcommissionrate
        {
            get
            {
                return Commissions.getCommissionpercentvalue(this.productcode, currentyearno); ;

            }

        }

        private double excesscommissionrate
        {
            get
            {
                return Commissions.getExcesscommissionpercent(this.productcode, currentyearno); ;
            }
        }

        public double calculatepv(double growthrate, int frequency, double amount)
        {
            double netamount = amount;
            for (int i = 1; i < frequency; i++)
            {
                netamount = netamount + amount * (1.0 / Math.Pow((1 + growthrate), i));

            }
            return netamount;
        }


        private double annualizedpremium
        {
            get
            {
                return calculatepv(this.openingPeriodicRate, frequencytypevalue, this.periodicpremium);                
            }
        }

        private int frequencytypevalue
        {
            get
            {
                return Frequencytypes.getfrequencytypevalue(this.frequencytypecode);
            }

        }



        public IOpeningBalance(String productname,String currentvaluestr,String frequencystr,String periodicpremiumstr,String invprofilestr,String monthlyinsurancestr,String unpaidpremiumsstr,String targetamountstr,String planyearstr,char classcode)
        {
            this.currentvalue = double.Parse(currentvaluestr);
            this.productcode=Productdata.getProductcode(productname);
            this.unpaidpremiums = Int32.Parse(unpaidpremiumsstr);
            this.periodicpremium = double.Parse(periodicpremiumstr);            
            //
            this.frequencytypecode=Frequencytypes.getfrequencytypecode(frequencystr);
            this.invprofilecode = Invprofiledata.getInvestmentprofilecode(invprofilestr);
            
            this.planyear=Int32.Parse(planyearstr);
            this.targetamount=double.Parse(targetamountstr);
            this.monthlyinsurancecost=double.Parse(monthlyinsurancestr);
            this.classcode = classcode;
            
            
            //double commrate=Commissions.getCommissionpercentvalue(productcode,currentyearno);
            

        }

        private double loadchargepercent
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.LOAD_CHARGE, this.productcode,this.classcode);
            }

        }

        private double monthlyfee
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.MONTHLY_FEE, this.productcode,this.classcode);
            }

        }

        private double commissionamount
        {
            get
            {
                double regcommission = this.regularcommissionrate * targetamount * ((1.0 * this.unpaidpremiums) / (1.0 * this.frequencytypevalue));
                double excesscommission = this.excesscommissionrate *(annualizedpremium- targetamount) * ((1.0 * this.unpaidpremiums) / (1.0 * this.frequencytypevalue));
                return regcommission + (excesscommission > 0 ? excesscommission : 0.0);
            }

        }

        public double openingbalance
        {
            get
            {
                double acurrentvalue = currentvalue * (1 + remainingperiodrate);
                double apremium = this.periodicpremium * this.unpaidpremiums * (1 - this.loadchargepercent);
                double amonthlyfee = this.monthlyfee * 12 * ((this.unpaidpremiums * 1.0) / (1.0 * this.frequencytypevalue));
                double acommissionamount=commissionamount;
                double ainsurancecost=monthlyinsurancecost*12*(1.0*unpaidpremiums)/(1.0*this.frequencytypevalue);
                return acurrentvalue+ apremium- amonthlyfee-acommissionamount-ainsurancecost;
            }
        }

        private double remainingperiodrate
        {
            get
            {
                return Math.Pow((1 + openingPeriodicRate), (this.unpaidpremiums * 1.0) / (this.frequencytypevalue * 1.0))-1;

            }            
        }


    }
}
