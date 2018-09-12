using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.querydata
{
    public class Caseclient_new
    {
        public enum Illussortorder
        {
            name = 1,
            plantype = 2,
            dispplancode=3,
            status=4,
            lastupdated=5,
            none=6,
            
        }
        public static int COLUMNPRODUCTILLUSTRATIONS = 4;
        public static int COLUMNOPEN = 7;



        private String clientname;
        private String plantype;
        private String productillustrations;
        private String status;
        private String dispplancode;
        private DateTime lastupdated;
        private long customerno;
        private long customerplanno;







        public Caseclient_new(String clientname, String plantype, String dispplancode, String productillustrations, String status, DateTime lastupdated, long customerno, long customerplanno) 
        {
            this.clientname=clientname;
            this.dispplancode = dispplancode;
            this.plantype=plantype;
            this.productillustrations=productillustrations;
            this.status=status;
            this.lastupdated=lastupdated;
            this.customerno=customerno;
            this.customerplanno = customerplanno;
            //this.customerplanno = customerplanno;                    
        }



        public String Clientname
        {
            get { return this.clientname; }
            set { this.clientname = value; }
        }

        public String Dispplancode
        {
            get { return this.dispplancode; }
            set { this.dispplancode = value; }
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

        public DateTime Lastupdated
        {
            get { return this.lastupdated; }
            set { this.lastupdated = value; }
        }

        //public String Open
        //{
        //    get
        //    {
        //        return "Open";
        //    }

        //}

        

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
