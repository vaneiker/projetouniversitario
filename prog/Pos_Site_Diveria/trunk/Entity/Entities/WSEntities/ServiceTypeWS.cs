using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.WSEntities
{
    public class ServiceTypeWS
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? UserId { get; set; }
        public DateTime? Modi_Date { get; set; }

        public ICollection<CoverageDetailWS> Coverages { get; set; }
    }
}
