using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DLL.TH.Serialization.Entity
{
    public class Quote
    {
        public List<Member> Member { get; set; }
        public PolicyInfo PolicyInfo { get; set; }
        public List<Coverage> Coverages { get; set; }
        public List<PolicyData> PolicyData { get; set; }
        public Quotation Quotation { get; set; }
        public PaymentDetail PaymentDetail { get; set; }
        public PrimeResume PrimeResume { get; set; }
    }
}
