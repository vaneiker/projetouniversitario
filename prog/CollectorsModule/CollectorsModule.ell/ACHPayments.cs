using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class ACHPayments
    {
        public string AccountHolder { get; set; }
        public string AcountId { get; set; }
        public string AcountNumber { get; set; }
        public string RouteNumber { get; set; }
        public Decimal AmountToPay { get; set; }
        public string Policy_No { get; set; }
        public string Name { get; set; }
        public Int32 AccountType { get; set; }
        public Decimal? DueAmount { get; set; }
        public int? Currency_Id { get; set; }
        public DateTime? DueDate { get; set; }
        public string Comments { get; set; }
    }
}
