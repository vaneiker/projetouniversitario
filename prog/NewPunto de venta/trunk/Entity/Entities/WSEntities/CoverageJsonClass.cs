using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.WSEntities
{
    public class CoverageJsonClass
    {
        public string Name { get; set; }
        public int CoverageDetailCoreId { get; set; }
        public decimal Limit { get; set; }
        public bool isSelected { get; set; }
        public bool delete { get; set; }
    }

    public class CoverageDeductibleJsonClass
    {
        public string Name { get; set; }
        public int CoverageDetailCoreId { get; set; }
        public decimal Limit { get; set; }
        public bool isSelected { get; set; }
        public bool delete { get; set; }

        public decimal minimumDeductible { get; set; }
        public bool hasMinimumDeductible { get; set; }
    }
}

