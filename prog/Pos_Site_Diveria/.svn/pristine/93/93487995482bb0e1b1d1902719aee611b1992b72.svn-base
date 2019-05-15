using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{

    [Table("COVERAGE_DETAILS")]
    public class CoverageDetail
    {

        public const string CoverageDetailTypeThirdParty = "DAÑOS A TERCEROS";
        public const string CoverageDetailTypeSelfDamages = "DAÑOS PROPIOS";
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// This property is used when the coverage is a Service one.
        /// </summary>
        public bool IsSelected { get; set; }

        public int CoverageDetailCoreId { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public decimal MinDeductible { get; set; }

        public decimal Limit { get; set; }

        public decimal? Deductible { get; set; }

        public int? UserId { get; set; }
        public DateTime? Modi_Date { get; set; }
    }
}
