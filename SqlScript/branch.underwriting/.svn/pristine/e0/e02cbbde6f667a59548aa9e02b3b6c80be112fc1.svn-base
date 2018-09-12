using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WSVirtualOffice.Models.querydata
{
    public class ContactClient
    {


        public enum Illussortorder
        {
            actiondate = 1,
            inputdate = 2,
            type = 3,
            notes = 4,
            none = 5,
            followuptype = 6,
            followupdate = 7

        }
        private String agentlogno;
        private String datecreated;


        private String eventdate;
        private String notes;
        //private String type;
        private String customerno;
        private String logitemcode;
        private String followupdate;
        private char type;
        private String followupnotetypecode;
        private string contactNoteType;

        public string ContactNoteType
        {
            get { return contactNoteType; }
            set { contactNoteType = value; }
        }

        public char Type
        {
            get { return type; }
            set { type = value; }
        }
        public String Followupdate
        {
            get { return followupdate; }
            set { followupdate = value; }
        }
        private String followupnotetype;

        public String Followupnotetype
        {
            get { return followupnotetypecode; }
            set { followupnotetypecode = value; }
        }
        //private String customerphoneno;

        public ContactClient(String agentlogno, String datecreated, String eventdate, String notetype, String notes, String customerno, String followuptype, String followupdatee)
        {
            this.contactNoteType = notetype;
            this.agentlogno = agentlogno;
            this.datecreated = DateTime.Parse(datecreated).ToShortDateString();
            if (eventdate != null)
            {
                this.eventdate = DateTime.Parse(eventdate).ToShortDateString();
            }
            if (notes.Length <= 145)
            {
                this.notes = notes;
            }
            else
            {
                this.notes = notes.Substring(0, 142) + "...";
            }

            this.customerno = customerno;
            this.followupdate = DateTime.Parse(followupdatee).ToShortDateString();
            this.followupnotetypecode = followuptype;
            //if (type == 'C')
            //{
            //    this.followupdate = "";
            //    this.followupnotetype = "";
            //}
            //else if (type == 'F')
            //{
            //    this.followupdate = DateTime.Parse(eventdate).ToShortDateString();
            //    this.followupnotetype = notetype;
            //}
        }

        public String Agentlogno
        {
            get { return agentlogno; }
            set { agentlogno = value; }
        }
        public String Datecreated
        {
            get { return datecreated; }
            set { datecreated = value; }
        }

        public String Logitemcode
        {
            get { return logitemcode; }
            set { logitemcode = value; }
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

        public String Customerno
        {
            get { return customerno; }
            set { customerno = value; }
        }


    }
}
