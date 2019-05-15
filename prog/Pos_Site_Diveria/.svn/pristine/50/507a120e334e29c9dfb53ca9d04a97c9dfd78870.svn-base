using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    [Table("[POS].[IDENTIFICATION_FINAL_BENEFICIARY_OPTIONS]")]
    public class IDENTIFICATION_FINAL_BENEFICIARY_OPTIONS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Allowed { get; set; }
        public bool Status { get; set; }
        public bool? IncludeForCompanyOrNot { get; set; }       
        
    }

}
