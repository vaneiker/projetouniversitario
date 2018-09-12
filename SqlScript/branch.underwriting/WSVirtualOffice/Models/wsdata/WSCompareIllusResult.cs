using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSCompareIllusResult
    {
        public WSValidationError error { get; set; }
        public List<List<WSValidationError>> list { get; set; }
       public byte[] result { get; set; }

    }
}