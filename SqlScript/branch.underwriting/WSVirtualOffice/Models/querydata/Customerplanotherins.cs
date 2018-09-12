using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class Customerplanotherins
    {
        private String product;
        private String insuredamount;
        private String annuityamount;
        private String annuityperiod;
        private long customerplanotherinsuranceno;

        public Customerplanotherins(String product, String insuredamount, String annuityamount, String annuityperiod, long customerplanotherinsuranceno)
        {
            this.product = product;
            this.insuredamount = insuredamount;
            this.annuityamount = annuityamount;
            this.annuityperiod = annuityperiod;
            this.customerplanotherinsuranceno= customerplanotherinsuranceno;
        }


        public String Product
        {
            get { return this.product; }
            set { this.product = value; }
        }

        public String Insuredamount
        {
            get { return this.insuredamount; }
            set { this.insuredamount = value; }
        }

        public String Annuityamount
        {
            get { return this.annuityamount; }
            set { this.annuityamount = value; }
        }

        public String Annuityperiod
        {
            get { return this.annuityperiod; }
            set { this.annuityperiod = value; }
        }

        public long Customerplanotherinsuranceno
        {
            get { return this.customerplanotherinsuranceno; }
            set { this.customerplanotherinsuranceno = value; }
        }


        
    }
}
