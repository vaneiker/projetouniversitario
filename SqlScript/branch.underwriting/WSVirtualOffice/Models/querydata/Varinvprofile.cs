using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class Varinvprofile
    {

        private String fromyear;
        private String toyear;
        private String investmentprofile;
        private int sno;
        private long customerplanvarprofileno;


        public Varinvprofile(String fromyear,String toyear,String investmentprofile,long customerplanvarprofileno,int sno)
        {
            this.fromyear = fromyear;
            this.toyear = toyear;
            this.investmentprofile = investmentprofile;
            this.customerplanvarprofileno = customerplanvarprofileno;
            this.sno = sno;

        }


        public String Fromyear
        {
            get { return this.fromyear; }
            set { this.fromyear = value; }
        }

        public String Toyear
        {
            get { return this.toyear; }
            set { this.toyear = value; }
        }

        public String Investmentprofile
        {
            get { return this.investmentprofile; }
            set { this.investmentprofile = value; }
        }

        public String Edit
        {
            get { return "edit"; }            
        }

        public String Delete
        {
            get { return "delete"; }            
        }

        public int Sno
        {
            get { return this.sno; }
            set { this.sno = value; }
        }

        public long Customerplanvarprofileno
        {
            get { return this.customerplanvarprofileno; }
            set { this.customerplanvarprofileno = value; }
        }


    }
}
