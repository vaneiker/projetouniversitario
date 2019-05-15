using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    public class QuotationAuto: Quotation
    {
        public ICollection<VehicleProduct> VehicleProducts { get; set; }

        public ICollection<Driver> Drivers { get; set; }


        public List<IdentificationFinalBeneficiary> IdentificationFinalBeneficiarys { get; set; }

        public List<PepFormulary> PepFormularys { get; set; }

        public override Person GetPrincipal()
        {
            if (Drivers != null && Drivers.Count > 0)
            {
                var principal = Drivers.Where(d => d.IsPrincipal).FirstOrDefault();
                if (principal != null)
                    return principal;
                else
                    return null;
            }
            else
                return null;
        }

        public override string GetPrincipalName()
        {
            if (Drivers != null && Drivers.Count > 0)
            {
                var principal = Drivers.Where(d => d.IsPrincipal).FirstOrDefault();
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
            if (Drivers != null && Drivers.Count > 0)
            {
                var principal = Drivers.Where(d => d.IsPrincipal).FirstOrDefault();
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
            if (VehicleProducts != null && VehicleProducts.Count > 0)
            {
                var prods = VehicleProducts.Select(c => c.SelectedProductName).Distinct();
                
                if (prods.Count() > 1)
                    return "Flotilla";
                else
                    return prods.First();
            }
            else
                return string.Empty;
        }
    }
}
