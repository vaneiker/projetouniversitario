namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Global.ST_VEHICLE_TYPE")]
    public partial class ST_VEHICLE_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ST_VEHICLE_TYPE()
        {
            ST_VEHICLE_MODEL = new HashSet<ST_VEHICLE_MODEL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Vehicle_Type_Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Vehicle_Type_Desc { get; set; }

        public bool Vehicle_Type_Status { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        [Required]
        [StringLength(100)]
        public string Hostname { get; set; }

        [StringLength(50)]
        public string namekey { get; set; }

        public Guid? ROW_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ST_VEHICLE_MODEL> ST_VEHICLE_MODEL { get; set; }

    }
}
