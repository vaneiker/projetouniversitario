using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class Calenderdata
    {
        private String notes;
        private String eventdate;

        public Calenderdata(String notes, String eventdate)
        {
            this.notes = notes;
            this.eventdate = eventdate;
        }

        public String Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public String Eventdate
        {
            get { return eventdate; }
            set { eventdate = value; }
        }
    }
}
