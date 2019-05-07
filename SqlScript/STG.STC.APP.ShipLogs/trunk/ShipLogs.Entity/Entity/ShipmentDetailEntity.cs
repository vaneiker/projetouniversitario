using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
   public partial class ShipmentDetailEntity
    {
        public int? DetailUniqueID { get; set; }
        public int? ShipUniqueID { get; set; }
        public string AssignedTo { get; set; }
        public string ItemDetail { get; set; }
          public string operat { get; set; }
    }
}
