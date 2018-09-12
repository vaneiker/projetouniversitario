using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{ 
    class adminuserprofile
    {
        private String profilename;
        private String description;
        private String groptype;
        private String profilestatus;
        private Int32 roleno; 






        public adminuserprofile(String profilename, String description, String groptype, String profilestatus,Int32 roleno)
        {
            this.profilename = profilename;
            this.description = description;
            this.groptype = groptype;
            this.profilestatus = profilestatus;
            this.roleno = roleno;
            
            
        }

        public String Profilename
        {
            get { return this.profilename; }
            set { this.profilename = value; }
        }



        public String Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public String Groptype
        {
            get { return this.groptype; }
            set { this.groptype = value; }
        }
        public String Profilestatus
        {
            get { return this.profilestatus; }
            set { this.profilestatus = value; }
        }
        public Int32 Roleno
        {
            get { return this.roleno; }
            set { this.roleno = value; }
        }
       
    }
}