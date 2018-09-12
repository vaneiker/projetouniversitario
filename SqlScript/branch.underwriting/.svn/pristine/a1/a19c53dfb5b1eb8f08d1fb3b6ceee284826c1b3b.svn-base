using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class SpecialClientIllustrations
    {
        private String firstname;
        private String dispillustrationno;
        private decimal amount;
        private DateTime dateupdated;
        private String isspecial;
        private long customerno;
        private long customerplanno;
        

        public SpecialClientIllustrations(String firstname, String dispillustrationno, decimal amount, DateTime dateupdated, Char isspecial, long customerno, long customerplanno)
        {
            this.firstname = firstname;
            this.dispillustrationno = dispillustrationno;
            this.amount = amount;
            this.dateupdated = dateupdated;
            if (isspecial == 'N')
            {
                this.isspecial = "Standard";
            }
            else if (isspecial == 'Y')
            {
                this.isspecial = "Special";
            }

            this.customerno = customerno;
            this.customerplanno = customerplanno;
        }


        public String Firstname
        {
            get { return this.firstname; }
            set { this.firstname = value; }
        }

        public String Dispillustrationno
        {
            get { return this.dispillustrationno; }
            set { this.dispillustrationno = value; }
        }

        public DateTime Dateupdated
        {
            get { return this.dateupdated; }
            set { this.dateupdated = value; }
        }

        public Decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        public String Isspecial
        {
            get { return this.isspecial; }
            set { this.isspecial = value; }
        }

        public long Customerno
        {
            get { return customerno; }
            set { customerno = value; }
        }


        public long Customerplanno
        {
            get { return customerplanno; }
            set { customerplanno = value; }
        }



    }
}