namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.VW_ST_VEHICLE_MAKE")]
    public partial class VW_ST_VEHICLE_MAKE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Make_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string Make_Desc { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Make_Status { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string Hostname { get; set; }

        public Guid? Row_Id { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Core_Make_Id { get; set; }
    }
}
