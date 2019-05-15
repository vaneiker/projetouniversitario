using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class CoverageExplication
    {
        public int Id { get; set; }
        public int CoverageID { get; set; }
        public string Description { get; set; }

        public class Parameter {
            public int coverageID { get; set; }
        }
    }
}
