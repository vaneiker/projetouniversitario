using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice
{
    class HealthRiskIns
    {
       
        private String product;    
        private String healthrisktype;
        private long healthrisktypeno;
        private String healthriskvalue;
        private String productcode;


        public HealthRiskIns(String product, String healthrisktype, long healthrisktypeno, String healthriskvalue, String productcode)
        {
            
            this.product = product;
            
            this.healthrisktype = healthrisktype;
            this.healthrisktypeno = healthrisktypeno;
            this.healthriskvalue = healthriskvalue;
            this.productcode = productcode;
        }


        public String Product
        {
            get { return this.product; }
            set { this.product = value; }
        }

        

       
        public String HealthRiskType
        {
            get { return this.healthrisktype; }
            set { this.healthrisktype = value; }
        }

        public long healthRisktypeNo
        {
            get { return this.healthrisktypeno; }
            set { this.healthrisktypeno = value; }
        }
        public String HealthRiskValue
        {
            get { return this.healthriskvalue; }
            set { this.healthriskvalue = value; }
        }

        public String ProductCode
        {
            get { return this.productcode; }
            set { this.productcode = value; }
        }
    }
}