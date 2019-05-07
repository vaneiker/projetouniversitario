using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
   public partial class ShipmentFileEntity
    {
        public int ShipUniqueID { get; set; }
        public string CarrierName { get; set; }
        public string AccountNumber { get; set; }
        public string LoginID { get; set; }
        public string ShipmentNumber { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string ReceiverCompany { get; set; }
        public string ReceiverDepartment { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverState { get; set; }
        public string ReceiverZipCode { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string ReceiverAttentionTo { get; set; }
        public string BillToAccountNumber { get; set; }
        public string PackageWeight { get; set; }
        public string PackageDescription { get; set; }
        public string CustomsValue { get; set; }
        public string PieceCount { get; set; }
        public string ServiceDescription { get; set; }
        public string EstFreightChgs { get; set; }
        public string EstOtherChgs { get; set; }
        public string EstTotalChgs { get; set; }
        public string SentBy { get; set; }
    }
}
