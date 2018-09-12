using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.businesslogic
{
    class GrowthIns
    {
        private String productcode;
        private String product;
        private String investmentprofilerate;
        private String classcode;
        private long investmentprofilevalueno;


         public GrowthIns(String productcode, String product, String investmentprofilerate, String classcode, long investmentprofilevalueno)
        {
            this.productcode = productcode;
            this.product = product;
            this.investmentprofilerate = investmentprofilerate;
            this.classcode = classcode;
            this.investmentprofilevalueno = investmentprofilevalueno;
        }


        public String Product
        {
            get { return this.product; }
            set { this.product = value; }
        }

        public String ProductCode
        {
            get { return this.productcode; }
            set { this.productcode = value; }
        }

        public String InvestmentProfileRate
        {
            get { return this.investmentprofilerate; }
            set { this.investmentprofilerate = value; }
        }

        public String ClassCode
        {
            get { return this.classcode; }
            set { this.classcode = value; }
        }

        public long InvestmentProfileValueNo
        {
            get { return this.investmentprofilevalueno; }
            set { this.investmentprofilevalueno = value; }
        }
    }
}