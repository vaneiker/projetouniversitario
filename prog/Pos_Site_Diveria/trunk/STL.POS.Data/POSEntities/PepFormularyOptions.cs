using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    [Table("[POS].[PEP_FORMULARY_OPTIONS]")]
    public class PEP_FORMULARY_OPTIONS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Allowed { get; set; }

        public bool Status { get; set; }

        public DateTime? Create_Date { get; set; }

        public int? Create_UserId { get; set; }

        public int? Modi_UserId { get; set; }

        public DateTime? Modi_Date { get; set; }

    }
}
