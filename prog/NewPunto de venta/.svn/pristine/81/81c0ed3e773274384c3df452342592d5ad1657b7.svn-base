namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Global.ST_VEHICLE_MODEL")]
    public partial class ST_VEHICLE_MODEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ST_VEHICLE_MODEL()
        {
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Make_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Model_Id { get; set; }

        public int Vehicle_Type_Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Model_Desc { get; set; }

        public bool Vehicle_Model_status { get; set; }

        public int? Core_Id { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }  

        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        public bool? Pos_Flag { get; set; }

        [Required]
        [StringLength(100)]
        public string Hostname { get; set; }

        public Guid? ROW_ID { get; set; }

        public ST_VEHICLE_MAKE Make { get; set; }
    }
}
