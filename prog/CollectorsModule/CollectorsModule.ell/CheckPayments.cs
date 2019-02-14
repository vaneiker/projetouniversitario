using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class CheckPayments
    {
        public String Name { get; set; }
        public String Policy_No { get; set; }
        public String BankName { get; set; }
        public String CheckNumber { get; set; }
        public Decimal? DueAmount { get; set; }
        public int? Currency_Id { get; set; }
        public DateTime? DueDate { get; set; }
        public string Comments { get; set; }
    }
}
