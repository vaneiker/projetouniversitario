using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ListVehicleSourceID
    {
        public int Index { get; set; }
        public string SourceID { get; set; }
        public int VehicleID { get; set; }
    }

    public class BaseEntity
    {
        public string Action { get; set; }
        public int EntityId { get; set; }
    }
}
