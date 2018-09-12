using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class illustrationsBO
    {
        private String firstname;
        private String dispillustrationno;                
        private DateTime dateupdated;
        private String productcode;
        private decimal premiumamount;
        private String frequencytypecode;
        private String changetype;
        private String createdby;
        private String isspecial;
        private Int64 customerno;
        private Int64 customerplanno;

        public illustrationsBO(String firstname, String dispillustrationno, DateTime dateupdated, String productcode, decimal premiumamount, String frequencytypecode, String changetype, String createdby, Char isspecial, Int64 customerno, Int64 customerplanno)
        {
            this.firstname=firstname;
            this.dispillustrationno=dispillustrationno;
            this.dateupdated=dateupdated;
            this.productcode=productcode;
            this.premiumamount=premiumamount;
            this.frequencytypecode=frequencytypecode;
            this.changetype = changetype;
            this.createdby=createdby;
            this.customerno = customerno;
            this.customerplanno = customerplanno;
       

            if (isspecial == 'N')
            {
                this.isspecial = "Standard";
            }
            else if (isspecial == 'Y')
            {
                this.isspecial = "Special";
            }
    
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

         public String Productcode
        {
            get { return this.productcode; }
            set { this.productcode = value; }
        }
           public decimal Premiumamount
        {
            get { return this.premiumamount; }
            set { this.premiumamount = value; }
        }
           public String Frequencytypecode
        {
            get { return this.frequencytypecode; }
            set { this.frequencytypecode = value; }
        }

        public String Changetype
        {
            get { return this.changetype; }
            set { this.changetype = value; }
        }


        public String Createdby
        {
            get { return this.createdby; }
            set { this.createdby = value; }
        }
       public String Isspecial
        {
            get { return this.isspecial; }
            set { this.isspecial = value; }
        }
       public Int64 Customerno
       {
           get { return this.customerno; }
           set { this.customerno = value; }
       }
       public Int64 Customerplanno
       {
           get { return this.customerplanno; }
           set { this.customerplanno = value; }
       }
    }
}