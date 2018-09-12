using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.querydata
{
    class Caseclient
    {

        public static int COLUMNPRODUCTILLUSTRATIONS = 4;
        public static int COLUMNOPEN = 7;



        private String clientname;
        private String appointment;
        private String plantype;
        private String productillustrations;
        private String status;
        private String lastupdated;
        private long customerno;







        public Caseclient(String clientname, String appointment, String plantype, String productillustrations, String status, String lastupdated, long customerno)
        {
            this.clientname = clientname;
            this.appointment = appointment;
            this.plantype = plantype;
            this.productillustrations = productillustrations;
            this.status = status;
            this.lastupdated = lastupdated;
            this.customerno = customerno;
            //this.customerplanno = customerplanno;                    
        }



        public String Clientname
        {
            get { return this.clientname; }
            set { this.clientname = value; }
        }

        public String Appointment
        {
            get { return this.appointment; }
            set { this.appointment = value; }
        }

        public String Plantype
        {
            get { return this.plantype; }
            set { this.plantype = value; }
        }

        public String Productillustrations
        {
            get { return this.productillustrations; }
            set { this.productillustrations = value; }
        }

        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public String Lastupdated
        {
            get { return this.lastupdated; }
            set { this.lastupdated = value; }
        }

        public String Open
        {
            get
            {
                return "Open";
            }

        }



        public long Customerno
        {
            get { return this.customerno; }
            set { this.customerno = value; }
        }


    }
}
