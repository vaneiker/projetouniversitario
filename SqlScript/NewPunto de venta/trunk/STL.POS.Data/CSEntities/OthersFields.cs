using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.CSEntities
{
    public class OthersFields
    {
        public int idOficina { get; set; }
        public int AgentIDOnSysflex { get; set; }

        public int codMoneda { get; set; }
        public int tasaMoneda { get; set; }
        public int codramo { get; set; }

        public QuotationAuto objQuotation { get; set; }
    }
}
