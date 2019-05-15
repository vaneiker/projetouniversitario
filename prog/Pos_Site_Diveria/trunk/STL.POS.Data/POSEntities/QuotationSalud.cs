using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    public class QuotationSalud : Quotation
    {
        public string PlanType { get; set; }
        public string Plan { get; set; }
        public decimal? Deductible { get; set; }

        public ICollection<PersonHealth> Persons { get; set; }

        public override string GetPrincipalName()
        {
            if (Persons != null && Persons.Count > 0)
            {
                var principal = Persons.Where(d => d.IsPrincipal).FirstOrDefault();
                if (principal != null)
                    return principal.GetFullName();
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        public override string GetPrincipalEmail()
        {
            if (Persons != null && Persons.Count > 0)
            {
                var principal = Persons.Where(d => d.IsPrincipal).FirstOrDefault();
                if (principal != null)
                    return principal.Email;
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        public override string GetQuotationProduct()
        {
            return Plan;
        }

        public override Person GetPrincipal()
        {
            throw new NotImplementedException();
        }
    }
}
