using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSTermillusdata
    {
        public int sno{ get; set; }
        public int age{ get; set; }
        public double regularpremium{ get; set; }
        public double riderpremium{ get; set; }
        public double totalpremium{ get; set; }
        public double accumulatedpremium{ get; set; }
        public double totalbenefitamount{ get; set; }


        public double commission{ get; set; }
        public double costofinsurance{ get; set; }
        public double insuredamount{ get; set; }
    }
}