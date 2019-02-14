using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class Invoice
    {
        public String Company {get; set;}
        public String Rnc {get; set;}
        public String Address {get; set;}
        public String Fax {get; set;}
        public String Telephone { get; set; }
        public String PayDate { get; set; }
        public String Time { get; set; }
        public String PaymentNumber { get; set; }
        public String FullName { get; set; }
        public String Amount_desc { get; set; }
        public decimal Amount { get; set; }
        public String Policy_No { get; set; }
        public String WayToPay { get; set; }
        public string Cashier { get; set; }
        public decimal CustomerBalance { get; set; }
    }
}
