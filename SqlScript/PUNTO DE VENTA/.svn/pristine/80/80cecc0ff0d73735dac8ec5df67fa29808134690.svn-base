namespace STL.POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Integration.Core_Integration")]
    public partial class Core_Integration
    {
        [Key]
        [Column(Order = 0)]
        public Guid Row_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Table_Name { get; set; }

        public string Table_Name_Core { get; set; }

        public int? Ramo { get; set; }

        public int? SubRamo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Secuencia { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Status { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string HostName { get; set; }
    }
}
