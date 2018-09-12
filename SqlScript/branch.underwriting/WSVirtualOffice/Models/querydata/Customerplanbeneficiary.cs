using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class Customerplanbeneficiary
    {
        private String name;
        private String dob;
        private String percentvalue;
        private String relationshiptype;
        private long customerplanbeneficiaryno;



        public Customerplanbeneficiary(String name, String dob, String relationshiptype, String percentvalue, long customerplanbeneficiaryno)
        {
            this.customerplanbeneficiaryno = customerplanbeneficiaryno;
            this.dob = Convert.ToDateTime(dob).ToShortDateString();
            this.percentvalue= percentvalue;
            this.name = name;
            this.relationshiptype = relationshiptype;
        }


        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public String Dob
        {
            get { return this.dob; }
            set { this.dob = value; }
        }

        public String Percentvalue
        {
            get { return this.percentvalue; }
            set { this.percentvalue = value; }
        }

        public String Relationshiptype
        {
            get { return this.relationshiptype; }
            set { this.relationshiptype = value; }
        }

        public long Customerplanbeneficiaryno
        {
            get { return this.customerplanbeneficiaryno; }
            set { this.customerplanbeneficiaryno = value; }
        }


        
    }
}
