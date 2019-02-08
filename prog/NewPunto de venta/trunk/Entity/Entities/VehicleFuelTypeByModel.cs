using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class VehicleFuelTypeByModel
    {
        public Nullable<int> VehicleFuelTypeIdSysflex { get; set; }
        public Nullable<int> MakeId { get; set; }
        public Nullable<int> ModelId { get; set; }
        public string VehicleFuelTypeDesc { get; set; }

        public class Parameter
        {
            public Nullable<int> vehicleFuelTypeIdSysflex { get; set; }
            public Nullable<int> makeId { get; set; }
            public Nullable<int> modelId { get; set; }
        }
    }
}
