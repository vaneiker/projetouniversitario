using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.WSEntities
{
    public class UsageByProductWS
    {
        public int? idUso { get; set; }
        public string descUso { get; set; }
        public int allowed { get; set; }
        public string message { get; set; }
    }
}
