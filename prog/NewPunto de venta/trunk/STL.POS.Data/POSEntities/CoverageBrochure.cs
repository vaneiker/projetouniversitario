using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace STL.POS.Data
{
    [Table("COVERAGES_BROCHURE")]
    public class CoverageBrochure
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CoverageDetailBrochure> CoverageDetails { get; set; }

    }
}