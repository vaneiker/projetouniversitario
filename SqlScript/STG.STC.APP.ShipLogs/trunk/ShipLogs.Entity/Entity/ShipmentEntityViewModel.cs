using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
    public partial class ShipmentEntityViewModel: Generic
    {
        public ShipmentEntity shipmentEntity { get; set; }
        public List<detail> detalles { get; set; }

        public class ShipmentEntity
        {
            public int? ShipUniqueID { get; set; }

            [Display(Name = "Carrier")]

            public string CarrierName { get; set; }
            [Display(Name = "Account")]
            public string AccountNumber { get; set; }
            [Display(Name = "Tracking")]
            [Required(ErrorMessage = "Please enter an Tracking.")]
            public string ShipmentNumber { get; set; }

            [Display(Name = "Date")]
            [Required]
            public DateTime? ShipmentDate { get; set; }

            [Display(Name = "Weight")]
            [Required]
            public decimal? ShipmentWeight { get; set; }

            [Display(Name = "QTY")]
            public int? ShipmentQTY { get; set; }

            [Display(Name = "Package")]
            public string ShipPackageType { get; set; }
            [Required]
            public string Operator { get; set; }
            public string Sender { get; set; }
            public string Receiver { get; set; }
            [Display(Name = "Attn")]
            public string ReceiverAttn { get; set; }
            [Display(Name = "Address")]
            public string ReceiverAddress { get; set; }
            [Display(Name = "City")]
            public string ReceiverCity { get; set; }
            [Display(Name = "State")]
            public string ReceiverState { get; set; }
            [Display(Name = "ZIP")]
            public string ReceiverZipCode { get; set; }
            [Display(Name = "Country")]
            public string ReceiverCountry { get; set; }

            [Display(Name = "Phone")]
            public string ReceiverPhoneNumber { get; set; }
            [Display(Name = "Comments")]
            public string ShipmentComments { get; set; }
            public bool? Transit { get; set; }
            public bool Incoming { get; set; }
            [Display(Name = "Commission Checks")]
            public bool CommissionChecks { get; set; }
            public bool Materials { get; set; }
            [Display(Name = "Other")]
            public bool OtherContents { get; set; }
            public int? DetailUniqueID { get; set; }
            public string AssignedTo { get; set; }
            public string ItemDetail { get; set; }
        }

        public class detail
        {
            public int? DetailUniqueID { get; set; }
            public string AssignedTo { get; set; }
            public string ItemDetail { get; set; }
        }



    }
}
