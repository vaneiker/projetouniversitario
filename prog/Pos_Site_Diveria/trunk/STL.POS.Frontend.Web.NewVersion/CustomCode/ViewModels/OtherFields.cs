using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Frontend.Web.NewVersion.CustomCode
{
    public class OthersFields
    {
        public int idOficina { get; set; }
        public int AgentIDOnSysflex { get; set; }

        public int codMoneda { get; set; }
        public int tasaMoneda { get; set; }
        public int codramo { get; set; }

        public Quotation objQuotation { get; set; }
    }
}
