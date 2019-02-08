using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ProductLimits
    {
        public Nullable<int> Id { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public Nullable<decimal> SdPrime { get; set; }
        public Nullable<decimal> TpPrime { get; set; }
        public Nullable<decimal> ServicesPrime { get; set; }
        public Nullable<decimal> ISC { get; set; }
        public Nullable<decimal> ISCPercentage { get; set; }
        public Nullable<decimal> TotalPrime { get; set; }
        public Nullable<decimal> TotalIsc { get; set; }
        public Nullable<decimal> TotalDiscount { get; set; }
        public Nullable<int> SelectedDeductibleCoreId { get; set; }
        public string SelectedDeductibleName { get; set; }
        public Nullable<int> VehicleProduct_Id { get; set; }
        public Nullable<int> UserId { get; set; }

        public class Parameter
        {
             public Nullable<int> id {get; set;}             public Nullable<bool> isSelected{get; set;}             public Nullable<decimal> sdPrime{get; set;}             public Nullable<decimal> tpPrime{get; set;}             public Nullable<decimal> servicesPrime{get; set;}             public Nullable<decimal> iSC{get; set;}             public Nullable<decimal> iSCPercentage{get; set;}             public Nullable<decimal> totalPrime{get; set;}             public Nullable<decimal> totalIsc{get; set;}             public Nullable<decimal> totalDiscount{get; set;}             public Nullable<int> selectedDeductibleCoreId{get; set;}             public string selectedDeductibleName{get; set;}             public Nullable<int> vehicleProduct_Id{get; set;}
             public Nullable<int> userId { get; set; }
        }
    }
}
