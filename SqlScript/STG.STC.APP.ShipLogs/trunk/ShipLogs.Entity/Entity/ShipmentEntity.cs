using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
    public partial class ShipmentEntity
    {
        public int? ShipUniqueID { get; set; }

        [Display(Name = "Carrier")]
        [Required]
        public string CarrierName { get; set; }
        public string AccountNumber { get; set; }
        [Display(Name = "Shipment")]
        [Required]
        public string ShipmentNumber { get; set; }

        [Required]
        public DateTime? ShipmentDate { get; set; }
        [Required]
        public decimal? ShipmentWeight { get; set; }
        public int? ShipmentQTY { get; set; }
        public string ShipPackageType { get; set; }
        [Required]
        public string Operator { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string ReceiverAttn { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverState { get; set; }
        public string ReceiverZipCode { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string ShipmentComments { get; set; }
        public bool? Transit { get; set; } 
        public bool Incoming { get; set; }
        public bool CommissionChecks { get; set; }
        public bool Materials { get; set; }
        public bool OtherContents { get; set; }
        public List<ShipmentDetailEntity> ListShipmentDetail { get; set; }
        public class ShipmentDetailEntity
        {
            public int? DetailUniqueID { get; set; }
            public int? ShipUniqueID { get; set; }
            public string AssignedTo { get; set; }
            public string ItemDetail { get; set; }
 
        }




    }
}
