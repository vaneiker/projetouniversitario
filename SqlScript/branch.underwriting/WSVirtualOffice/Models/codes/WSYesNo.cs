using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.codes
{
    public class WSYesNo
    {
        public string label { get; set; }
        public string value { get; set; }

        public static List<WSYesNo> getWSYesNoList()
        {
            List<WSYesNo> yesnolist = new List<WSYesNo>();           
            yesnolist.Add(new WSYesNo() { label = "No", value = "N" });
            yesnolist.Add(new WSYesNo() { label = "Yes", value = "Y" });
            return yesnolist;
        }

    }
}