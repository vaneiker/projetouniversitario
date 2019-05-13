using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
    public class ParameterEntityGeneric
    {
        public class Get_Parameter
        {
            public string IdAlf { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }
        }

        public class Set_Parameter
        {
            public string DropDownType { get; set; }
            public int Identificador { get; set; }

        }

        public class GetDropConcept
        {
            public string Operation { get; set; }
            public string id { get; set; }
            public string IdAlf { get; set; }

        }


    }
}
