namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Global.ST_GLOBAL_COUNTRY")]
    public partial class ST_GLOBAL_COUNTRY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Global_Country_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Global_Country_Desc { get; set; }

        [StringLength(100)]
        public string Global_Country_Desc_EN { get; set; }

        [StringLength(50)]
        public string Global_Time_Zone_Desc { get; set; }

        [StringLength(2)]
        public string Global_Letter_Code_2 { get; set; }

        [StringLength(3)]
        public string Global_Letter_Code_3 { get; set; }

        [StringLength(60)]
        public string Citizenship { get; set; }

        public bool Global_Country_Status { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        [Required]
        [StringLength(100)]
        public string hostname { get; set; }

        public ICollection<BusinessLine> BusinessLines { get; set; }
    }
}
