using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    [Table("PRODUCT_LIMITS")]
    public class ProductLimit
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsSelected { get; set; }

        /// <summary>
        /// Self-Damages Prime
        /// </summary>
        public decimal? SdPrime { get; set; }

        /// <summary>
        /// Third Party Prime value
        /// </summary>
        public decimal? TpPrime { get; set; }

        public decimal? ServicesPrime { get; set; }

        public decimal? ISC { get; set; }

        public decimal? ISCPercentage { get; set; }

        public decimal? TotalPrime { get; set; }

        public decimal? TotalIsc { get; set; }

        public decimal? TotalDiscount { get; set; }

        public int? SelectedDeductibleCoreId { get; set; }

        public string SelectedDeductibleName { get; set; }

        public int? UserId { get; set; }
        public DateTime? Modi_Date { get; set; }

        public ICollection<CoverageDetail> ThirdPartyCoverages { get; set; }
        public ICollection<CoverageDetail> SelfDamagesCoverages { get; set; }
        public ICollection<ServiceType> ServicesCoverages { get; set; }

    }
}
