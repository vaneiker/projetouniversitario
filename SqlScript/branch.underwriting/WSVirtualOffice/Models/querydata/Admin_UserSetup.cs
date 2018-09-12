using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class adminusersetup
    {
        private Int64 userid;
        private String code;
        private String name;
        private String middleintial;
        private String lastname;
        private DateTime createddate;
        private String grouptype;
        private String profilename;
        private String agency;

        public adminusersetup(Int64 userid,String code, String name, String middleintial, String lastname, DateTime createddate, String grouptype, String profilename, String agency)
        {
            this.userid = userid;
            this.code = code;
            this.name = name;
            this.middleintial = middleintial;
            this.lastname = lastname;
            this.createddate = createddate;
            this.grouptype = grouptype;
            this.profilename = profilename;
            this.agency = agency;
            
            
        }
        public Int64 UserId
        {
            get { return this.userid; }
            set { this.userid = value; }
        }
        public String Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public String Middleintial
        {
            get { return this.middleintial; }
            set { this.middleintial = value; }
        }
        public String Lastname
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }
        public DateTime Createddate
        {
            get { return this.createddate; }
            set { this.createddate = value; }
        }
        public String Grouptype
        {
            get { return this.grouptype; }
            set { this.grouptype = value; }
        }
        public String Profilename
        {
            get { return this.profilename; }
            set { this.profilename = value; }
        }
        public String Agency
        {
            get { return this.agency; }
            set { this.agency = value; }
        }
       

    }
       
}