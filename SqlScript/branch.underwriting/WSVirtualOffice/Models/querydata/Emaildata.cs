using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class emaildata
    {
        private String emailtype;
        private String email;                
        private long customeremailno;

        public emaildata(String emailtype, String email,long customeremailno)
        {
            this.email = email;
            this.emailtype = emailtype;            
            this.customeremailno = customeremailno;
        }


        public String Emailtype
        {
            get { return this.emailtype; }
            set { this.emailtype = value; }
        }

        

        public String Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        

        public String edit
        {
            get { return "edit"; }            
        }

        public String delete
        {
            get { return "delete"; }
        }


        public long Customeremailno
        {
            get { return this.customeremailno; }
            set { this.customeremailno = value; }
        }


        	
    }
}
