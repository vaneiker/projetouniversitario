using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    [Table("TERM_TYPES")]
    public class TermType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Timespan to calculate the ensurance end time. If null, the insurance end time is editable.
        /// </summary>
        public int? TimeSpanInMonths { get; set; }

        public string TimeSpanInLetters { get; set; }
    }
}
