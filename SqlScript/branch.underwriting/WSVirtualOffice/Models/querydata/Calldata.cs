using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.querydata
{
    public class Calldata
    {              
        private String calltype;        
        private String eventdate;        
        private String notes;
        private long logitemno;
             
        public Calldata(String calltype,String eventdate,String notes,long logitemno)
        {
            this.calltype = calltype;
            this.eventdate = eventdate;
            this.notes = notes;
            this.logitemno = logitemno;
        }
        
        public String Calltype
        {
            get { return calltype; }
            set { calltype = value; }
        }

        public String Eventdate
        {
            get { return eventdate; }
            set { eventdate = value; }
        }

        public String Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public long Logitemno
        {
            get { return logitemno; }
            set { logitemno = value; }
        }        
    }
}