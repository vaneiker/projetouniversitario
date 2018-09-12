using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.businesslogic
{
    class GrowthCompareClass
    {
        private String productcode;
        private String product;
        private String investmentprofilecode;
        private String growthrate1;
        private String growthrate2;
        private String classcode;
        private long investmentprofilecompareratesno;


        public GrowthCompareClass(String product, String investmentprofilecode, String productcode, String growthrate1, String growthrate2, String classcode, long investmentprofilecompareratesno)
        {
            this.productcode = productcode;
            this.product = product;
            this.investmentprofilecode = investmentprofilecode;
            this.growthrate1 = growthrate1;
            this.growthrate2 = growthrate2;
            this.classcode = classcode;
            this.investmentprofilecompareratesno = investmentprofilecompareratesno;
        }


        public String Product
        {
            get { return this.product; }
            set { this.product = value; }
        }

       

        public String InvestmentProfileCode
        {
            get { return this.investmentprofilecode; }
            set { this.investmentprofilecode = value; }
        }
        public String ProductCode
        {
            get { return this.productcode; }
            set { this.productcode = value; }
        }
        public String GrowthRate1
        {
            get { return this.growthrate1; }
            set { this.growthrate1 = value; }
        }

        public String GrowthRate2
        {
            get { return this.growthrate2; }
            set { this.growthrate2 = value; }
        }
        public String ClassCode
        {
            get { return this.classcode; }
            set { this.classcode = value; }
        }

        public long InvestmentProfileCompareRatesNo
        {
            get { return this.investmentprofilecompareratesno; }
            set { this.investmentprofilecompareratesno = value; }
        }
    }
}