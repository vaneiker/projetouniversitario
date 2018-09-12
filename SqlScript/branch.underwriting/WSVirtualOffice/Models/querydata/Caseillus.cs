using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class Caseillus
    {

        public static int COLUMNOPEN = 7;
        public static int COLUMNCOMPARE = 8;

        private String illustrationno;
        private String planname;
        private String plantype;
        private String plandate;
        private String premiumamount;
        private String insuredamount;
        private long customerplanno;
        



        public Caseillus(String illuscode1, 
 String planname,
 String plantype,
 String effectivedate1,
 String premium,
 String insuredamount, 
            long customerplanno
 )
        {



            this.illustrationno = illuscode1;//.ToString();
            this.planname = planname;//.ToString();            
            this.plantype = plantype;
            this.plandate = effectivedate1;
            this.premiumamount = premium;
            this.insuredamount = insuredamount;                        
            this.customerplanno = customerplanno;

        }



        public String Illustrationno
        {
            get { return this.illustrationno; }
            set { this.illustrationno = value; }
        }

        public String Planname
        {
            get { return this.planname; }
            set { this.planname = value; }
        }

        public String Plantype
        {
            get { return this.plantype; }
            set { this.plantype = value; }
        }

        public String Plandate
        {
            get { return this.plandate; }
            set { this.plandate = value; }
        }

        public String Premiumamount
        {
            get { return this.premiumamount; }
            set { this.premiumamount = value; }
        }

        public String Insuredamount
        {
            get { return this.insuredamount; }
            set { this.insuredamount = value; }
        }
        public String Open
        {
            get { return "Open"; }

        }
        public String Compare
        {
            get { return "Compare"; }
        }

        public long Customerplanno
        {
            get { return this.customerplanno; }
            set { this.customerplanno = value; }
        }

    }
}
