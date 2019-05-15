namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Global.ST_GLOBAL_MUNICIPIO")]
    public partial class ST_GLOBAL_MUNICIPIO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Domesticreg_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int State_Prov_Id { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Municipio_Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Municipio_Desc { get; set; }

        public bool Municipio_Status { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        [Required]
        [StringLength(100)]
        public string hostname { get; set; }

    }
}
