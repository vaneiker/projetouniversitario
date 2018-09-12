using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class REDIllusdata
    {
        public char isdynamicgrowthrate;

        private int sno;
        private int age;
        private double premium;
        private double accumulatedpremium;
        private double deathbenefit;
        private double discbenefit;
        private double accountvalue;
        private double rescatevalue;
        private double penaltyvalue;
        private double partialretirementamount;


        private double commission;
        private double costofinsurance;
        private double annuityamount;



        public String[] getDataarray()
        {
            String[] str1 = null;
            str1 = new String[9];
            str1[0] = sno.ToString();
            str1[1] = age.ToString();
            if (premium > 0)
                str1[2] = String.Format("{0:N0}", premium);

            if (accumulatedpremium > 0)
                str1[3] = String.Format("{0:N0}", accumulatedpremium);

            if (deathbenefit > 0)
                str1[4] = String.Format("{0:N0}", deathbenefit);

            if (discbenefit > 0)
                str1[5] = String.Format("{0:N0}", discbenefit);

            if (accountvalue > 0)
                str1[6] = String.Format("{0:N0}", accountvalue);

            if (rescatevalue > 0)
                str1[7] = String.Format("{0:N0}", rescatevalue);

            if (partialretirementamount > 0)
                str1[8] = String.Format("{0:N0}", partialretirementamount);


            return str1;
        }


        public String[] getDatacolumns()
        {
            String[] str1 = null;// new String[numscenarios * 3 + 3];            
            str1 = new String[9];
            str1[0] = "Sno";
            str1[1] = "Age";
            str1[2] = "Premium";
            str1[3] = "accumulatedpremium";
            str1[4] = "deathbenefit";
            str1[5] = "discbenefit";
            str1[6] = "accountvalue";
            str1[7] = "rescatevalue";
            str1[8] = "partialretirementamount";
            return str1;
        }



        public int Sno
        {
            get { return this.sno; }
            set { this.sno = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public double Premium
        {
            get { return this.premium; }
            set { this.premium = value; }
        }

        public double Accumulatedpremium
        {
            get { return this.accumulatedpremium; }
            set { this.accumulatedpremium = value; }
        }

        public double Deathbenefit
        {
            get { return this.deathbenefit; }
            set { this.deathbenefit = value; }
        }

        public double Discbenefit
        {
            get { return this.discbenefit; }
            set { this.discbenefit = value; }
        }

        public double Accountvalue
        {
            get { return this.accountvalue; }
            set { this.accountvalue = value; }
        }

        public double Penaltyvalue
        {
            get { return this.penaltyvalue; }
            set { this.penaltyvalue = value; }
        }

        public double Rescatevalue
        {
            get { return this.rescatevalue; }
            set { this.rescatevalue = value; }
        }

        public double Partialretirementamount
        {
            get { return this.partialretirementamount; }
            set { this.partialretirementamount = value; }
        }

        public double Commission
        {
            get { return this.commission; }
            set { this.commission = value; }
        }

        public double Costofinsurance
        {
            get { return this.costofinsurance; }
            set { this.costofinsurance = value; }
        }

        public double Annuityamount
        {
            get { return this.annuityamount; }
            set { this.annuityamount = value; }
        }
    }
}