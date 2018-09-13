using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
  public  class EN_AGENT_GP_COMMISSION_entity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Corp_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Agent Id")]
        public int Agent_Id { get; set; }
        public bool No_Commission { get; set; }
        public bool Take_Vendor_Id { get; set; }
        [Display(Name = "Vendor Id")]
        [StringLength(50)]
        public string Vendor_Id { get; set; }
        public bool Agent_Status { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Modi_Date { get; set; }
        public int Create_UsrId { get; set; }
        public int? Modi_UsrId { get; set; }
        [Required]
        [StringLength(100)]
        public string Hostname { get; set; }
        [Display(Name = "Agent Code")]
        public string Agent_Code { get; set; }
        [Display(Name ="Nombre Completo")]
       public string  Full_Name  {get;set;}  
 

    }
}
