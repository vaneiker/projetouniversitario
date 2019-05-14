using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{

    [Table("SERVICES_TYPES")]
    public class ServiceType
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int? UserId { get; set; }
        public DateTime? Modi_Date { get; set; }

        public ICollection<CoverageDetail> Coverages { get; set; }

    }
}
