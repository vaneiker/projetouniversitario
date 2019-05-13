using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
  
    public partial class AssigneToPersonalEntity
    {
        public int id { get; set; }
        public string NameAssigne { get; set; }
        public bool? IsActive { get; set; }
    }
}
