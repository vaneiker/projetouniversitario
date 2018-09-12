using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class boadmin
    {
        private String firstname;
        private String dispillustrationno;
        private DateTime dateupdated;
        private String productcode;
        private String customerstatuscode;
        private long customerno;
        private long customerplanno;






        public boadmin(String firstname, String dispillustrationno, DateTime dateupdated, String productcode, String customerstatuscode, long customerno, long customerplanno)
        {
            this.firstname = firstname;
            this.dispillustrationno = dispillustrationno;
            this.dateupdated = dateupdated;
            this.productcode = productcode;
            this.customerstatuscode= customerstatuscode;
            this.customerno = customerno;
            this.customerplanno = customerplanno;
            
        }

        public String Firstname
        {
            get { return this.firstname; }
            set { this.firstname = value; }
        }



        public String Illustrationno
        {
            get { return this.dispillustrationno; }
            set { this.dispillustrationno = value; }
        }
        public DateTime Dateupdated
        {
            get { return this.dateupdated; }
            set { this.dateupdated = value; }
        }

        public String Productcode
        {
            get { return this.productcode; }
            set { this.productcode = value; }
        }
        public String Customerstatuscode
        {
            get { return this.customerstatuscode; }
            set { this.customerstatuscode = value; }
            

        }
        public long Customerno
        {
            get { return this.customerno; }
            set { this.customerno = value; }
        }

        public long Customerplanno
        {
            get { return this.customerplanno; }
            set { this.customerplanno = value; }
        }
    }
}