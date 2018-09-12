using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DLL.TH.Serialization.Entity
{
    public class Policy
    {
        public string Plan { get; set; }
        public string PolicyType { get; set; }
        public string InsuranceDurantion { get; set; }
        public string PrincipalInsuredReq { get; set; }
        public string AdditionalInsuredReq { get; set; }
        public string Age { get; set; }
        public string YearsOfThePlan { get; set; }
        public string BasicPrimeCoverage { get; set; }
        public string SupplementsPrime { get; set; }
        public string TotalPrime { get; set; }
        public string AccumulatedPremiums { get; set; }
        public string DeathBenefit { get; set; }
        public string TipoPrima { get; set; }
    }
}
