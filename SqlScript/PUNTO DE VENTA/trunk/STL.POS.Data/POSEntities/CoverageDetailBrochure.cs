using System.ComponentModel.DataAnnotations.Schema;

namespace STL.POS.Data
{

    [Table("COVERAGE_DETAILS_BROCHURE")]
    public class CoverageDetailBrochure
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

    }
}