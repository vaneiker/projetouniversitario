namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Global.ST_SURCHARGE_PERCENTAGE")]
    public partial class ST_SURCHARGE_PERCENTAGE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SurCharge_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Percentage_Desc { get; set; }

        public decimal Percentage { get; set; }

        public bool SurCharge_Status { get; set; }

        public bool Pos_Flag { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        [StringLength(100)]
        public string Hostname { get; set; }

        public Guid? Row_Id { get; set; }
    }
}
