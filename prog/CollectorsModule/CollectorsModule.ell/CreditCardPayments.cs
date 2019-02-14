using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class CreditCardPayments
    {
        public String Name { get; set; }
        public String Policy_No { get; set; }
        public Int32 CreditCardTypeId { get; set; }
        public String CreditCardType { get; set; }
        public String CreditCardMaskedNumber { get; set; }
        public String AuthorizationCode { get; set; }
        public Decimal AmountToPay { get; set; }
        public DateTime? DueDate { get; set; }
        public int CurrencyID { get; set; }
        public string Comments { get; set; }
    }
}
