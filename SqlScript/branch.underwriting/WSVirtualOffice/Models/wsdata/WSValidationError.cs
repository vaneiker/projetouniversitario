using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSValidationError
    {
        public string errormessage { get; set; }
        public string errormessageespanol { get; set; }
        public WSErrorType errortype { get; set; }
        public string errorfield { get; set; }
        public string value { get; set; }
        public double rangefromvalue { get; set; }
        public double rangetovalue { get; set; }
        //public string possiblevalues { get; set; }

    }
}