namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Global.ST_VEHICLE_MAKE")]
    public partial class ST_VEHICLE_MAKE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ST_VEHICLE_MAKE()
        {
            ST_VEHICLE_MODEL = new HashSet<ST_VEHICLE_MODEL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Make_Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Make_Desc { get; set; }

        public bool Make_Status { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        public bool? Pos_Flag { get; set; }

        [Required]
        [StringLength(100)]
        public string Hostname { get; set; }

        public Guid? Row_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ST_VEHICLE_MODEL> ST_VEHICLE_MODEL { get; set; }
    }
}
