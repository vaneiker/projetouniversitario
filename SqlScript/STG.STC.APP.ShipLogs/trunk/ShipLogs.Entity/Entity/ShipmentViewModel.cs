using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
  
    public partial class ShipmentViewModel
    {
        public int ShipUniqueID { get; set; }
        public string CarrierName { get; set; }
        public string AccountNumber { get; set; }
        public string ShipmentNumber { get; set; }
        public Nullable<System.DateTime> ShipmentDate { get; set; }
        public Nullable<decimal> ShipmentWeight { get; set; }
        public Nullable<int> ShipmentQTY { get; set; }
        public string ShipPackageType { get; set; }
        public string Operat { get; set; }
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
        public Nullable<bool> Transit { get; set; }
        public bool? Incoming { get; set; }
        public string IncomingLiteral { get; set; }
        public Nullable<bool> CommissionChecks { get; set; }
        public Nullable<bool> Materials { get; set; }
        public Nullable<bool> OtherContents { get; set; }
        public string AssignedTo { get; set; }
        public string ItemDetail { get; set; }
 
      
    
    }
}



 