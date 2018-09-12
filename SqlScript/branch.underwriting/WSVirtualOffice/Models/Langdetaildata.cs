using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models
{
    public class Langdetaildata
    {
        public Langdetaildata(String formname, String itemname, String languagevalue)
        {
            this.formname = formname;
            this.itemname = itemname;
            this.languagevalue = languagevalue;
        }

        public String formname;
        public String itemname;
        public String languagevalue;
    }
}
