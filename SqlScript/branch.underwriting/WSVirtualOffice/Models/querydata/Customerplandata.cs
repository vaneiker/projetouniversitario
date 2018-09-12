using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class Customerplandata
    {


        public static int COLUMNOPEN = 7;

        private String clientname;
        private String plantype;
        private double insuredamount;
        private String frequencytype;
        private double periodicpremium;
        private String planstatus;
        private long customerno;
        private long customerplanno;

        public Customerplandata(String clientname, String plantype, double insuredamount, String frequencytype, double periodicpremium, String plancode, long customerno, long customerplanno)
        {
            this.clientname = clientname;
            this.plantype = plantype;
            this.insuredamount = insuredamount;
            this.frequencytype = frequencytype;
            this.periodicpremium = periodicpremium;
            if (plancode == null)
            {
                this.planstatus = "Illustration";
            }
            else
            {                
                planstatus = long.Parse(plancode).ToString("00000000");
            }
            this.customerplanno = customerplanno;
            this.customerno = customerno;
            
        }

        public String Clientname
        {
            get { return this.clientname; }
            set { this.clientname = value; }
        }

        public String Plantype
        {
            get { return this.plantype; }
            set { this.plantype = value; }
        }

        public double Insuredamount
        {
            get { return this.insuredamount; }
            set { this.insuredamount = value; }
        }

        public String Frequencytype
        {
            get { return this.frequencytype; }
            set { this.frequencytype = value; }
        }

        public double Periodicpremium
        {
            get { return this.periodicpremium; }
            set { this.periodicpremium = value; }
        }

        public String Planstatus
        {
            get { return this.planstatus; }
            set { this.planstatus = value; }
        }

        public String Open
        {
            get { return "Open"; }            
        }

        public long Customerplanno
        {
            get { return this.customerplanno; }
            set { this.customerplanno = value; }
        }

        public long Customerno
        {
            get { return this.customerno; }
            set { this.customerno = value; }
        }


    }
}
