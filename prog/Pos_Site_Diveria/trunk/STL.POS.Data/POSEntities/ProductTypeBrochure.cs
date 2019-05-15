using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace STL.POS.Data
{

    [Table("PRODUCT_TYPE_BROCHURE")]
    public class ProductTypeBrochure
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CoverageTypeBrochure> CoverageTypes { get; set; }

        public ICollection<BenefitBrochure> Benefits { get; set; }

        public string Elegibilidad { set; get; }

        public string Deducible { get; set; }

        public string Coberturas { get; set; }

    }
}