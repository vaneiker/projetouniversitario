namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Global.ST_VEHICLE_STORED")]
    public partial class ST_VEHICLE_STORED
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stored_Id { get; set; }

        [StringLength(100)]
        public string Stored_Desc { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        [Required]
        [StringLength(100)]
        public string Hostname { get; set; }
    }
}
