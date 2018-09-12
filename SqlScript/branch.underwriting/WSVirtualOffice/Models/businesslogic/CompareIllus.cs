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

namespace WSVirtualOffice.Models.businesslogic
{
    public class CompareIllus
    {
        private string column1;
        private string column2;
        private string column3;
        private string column4;


        public CompareIllus(string column1, string column2, string column3, string column4)
        {
            this.column1 = column1;
            this.column2 = column2;
            this.column3 = column3;
            this.column4 = column4;
         
        }

        public string maincolumn1
        {
            get { return this.column1; }
            set { this.column1 = value; }
        }
        public string maincolumn2
        {
            get { return this.column2; }
            set { this.column2 = value; }
        }
        public string maincolumn3
        {
            get { return this.column3; }
            set { this.column3 = value; }
        }
        public string maincolumn4
        {
            get { return this.column4; }
            set { this.column4 = value; }
        }
       
       
       
    }
}
