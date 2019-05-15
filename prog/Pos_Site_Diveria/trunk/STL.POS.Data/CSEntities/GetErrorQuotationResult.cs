using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.CSEntities
{
    public class GetErrorQuotationResult
    {
        public int Log_Id { get; set; }
        public int Log_Type_Id { get; set; }
        public int Corp_Id { get; set; }
        public int Company_Id { get; set; }
        public int Project_Id { get; set; }
        public string Identifier { get; set; }
        public string Log_Value { get; set; }
        public DateTime? Create_Date { get; set; }
        public string HostName { get; set; }
    }
}
