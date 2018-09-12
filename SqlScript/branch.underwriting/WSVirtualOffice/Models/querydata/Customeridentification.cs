using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class Customeridentification
    {
        private String identificationtype;
        private String identificationcode;
        private String expirydate;
        private String countryname;
        private long customeridentificationno;

        public Customeridentification(String identificationtype, String identificationcode, String expirydate, String countryname, long customeridentificationno)
        {
            this.identificationtype = identificationtype;
            this.identificationcode = identificationcode;
            this.expirydate = Convert.ToDateTime(expirydate).ToShortDateString();
            this.countryname = countryname;
            this.customeridentificationno = customeridentificationno;
        }

        public String Identificationtype
        {
            get { return this.identificationtype; }
            set { this.identificationtype = value; }
        }

        public String Identificationcode
        {
            get { return this.identificationcode; }
            set { this.identificationcode = value; }
        }

        public String Expirydate
        {
            get { return this.expirydate; }
            set { this.expirydate = value; }
        }

        public String Countryname
        {
            get { return this.countryname; }
            set { this.countryname = value; }
        }

        public long Customeridentificationno
        {
            get { return this.customeridentificationno; }
            set { this.customeridentificationno = value; }
        }


    }
}
