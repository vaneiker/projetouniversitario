using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
   public class Vendor
    {
       [Display(Name = "Agregar Agent Id")]
       [Required]
       public int    Agent_Id   {get;set;}
       [Display(Name = "Codigo Agente Sysflex")]
       public string Agent_Code {get;set;}
       [Required]
       [Display(Name = "Agregar Codigo GP")]
       public string Vendor_Id { get; set;}
       [Display(Name = "Nombre Completo")]
       public string Full_Name  {get;set;}
       public int Create_UserId { get; set; }
       [Display(Name = "Codigo Unico")]
       public int Unique_Agent_Id { get; set; }
       [DataType(DataType.Date)]
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
       [Display(Name = "Fecha Nacimeinto")]
       public Nullable<System.DateTime> Dob { get; set; }
        [Display(Name = "Fecha de Nacimeinto")]
       public string dateNacimiento { get; set; }
    }
  
}
