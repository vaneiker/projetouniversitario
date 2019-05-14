using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.POSEntities
{
    public class CoverageJsonClass
    {
        public string Name { get; set; }
        public int CoverageDetailCoreId { get; set; }
        public decimal Limit { get; set; }
        public bool isSelected { get; set; }
        public bool delete { get; set; }
    }
}

