using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.querydata
{
    class Phonedata
    {
        private String phonetype;
        private String intcode;
        private String areacode;
        private String phoneno;
        private String ext;
        private long customerphoneno;
        private String specialphonetype;


        public Phonedata(HttpSessionState session, String phonetype,  String intcode, String areacode, String phoneno, String ext,long customerphoneno,String specialphonetype)
        {
            if (phonetype == null)
            {
                this.phonetype = specialphonetype;

            }
            else
            {
                this.phonetype =Lookuplangdata.getLanguagevalue(Lookuptables.phonetypedet,businesslogic.Phonetypes.getPhonetype(phonetype.ToCharArray()[0]),Sessionclass.getSessiondata(session).language);

            }
            this.intcode = intcode;
            this.areacode = areacode;
            this.phoneno = phoneno;
            this.ext = ext;
            this.customerphoneno = customerphoneno;
        }


        public String Phonetype
        {
            get { return this.phonetype; }
            set { this.phonetype = value; }
        }

        public String Intcode
        {
            get { return this.intcode; }
            set { this.intcode = value; }
        }

        public String Areacode
        {
            get { return this.areacode; }
            set { this.areacode = value; }
        }

        public String Phoneno
        {
            get { return this.phoneno; }
            set { this.phoneno = value; }
        }

        public String Ext
        {
            get { return this.ext; }
            set { this.ext = value; }
        }

        public String edit
        {
            get { return "edit"; }            
        }

        public String delete
        {
            get { return "delete"; }
        }


        public long Customerphoneno
        {
            get { return this.customerphoneno; }
            set { this.customerphoneno = value; }
        }


        	
    }
}
