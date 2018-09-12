using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.querydata
{
    class Illusdataclientinfo
    {
        private String illusnum;
        private String plantype;
        private String premiumamt;
        private String benfamt;
        private long customerplanno;


        public Illusdataclientinfo(String illusnum, String plantype, double premiumamt, double benfamt, long customerplanno)
        {
            this.illusnum = illusnum;
            this.plantype = plantype;
            this.premiumamt = Program.getCurrencyString(Classdata.getClasscode("A"),premiumamt);
            this.benfamt = Program.getCurrencyString(Classdata.getClasscode("A"),benfamt);
            this.customerplanno = customerplanno;
        }

        public String Illusnum
        {
            get { return this.illusnum; }
            set { this.illusnum = value; }
        }

        public String Plantype
        {
            get { return this.plantype; }
            set { this.plantype = value; }
        }

        public String Premiumamt
        {
            get { return this.premiumamt; }
            set { this.premiumamt = value; }
        }

        public String Benfamt
        {
            get { return this.benfamt; }
            set { this.benfamt = value; }
        }

        public long Customerplanno
        {
            get { return this.customerplanno; }
            set { this.customerplanno = value; }
        }
    }
}
