using System.ComponentModel.DataAnnotations.Schema;

namespace STL.POS.Data
{
    [Table("BENEFITS_BROCHURE")]
    public class BenefitBrochure
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Basic { get; set; }

        public bool Ultra { get; set; }

    }
}