using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
    public partial class CarrierEntity
    {
        public int CarrierUniqueID { get; set; }
        public string CarrierName { get; set; }
        public string AccountNumber { get; set; }
        public string Comments { get; set; }
    }
}
