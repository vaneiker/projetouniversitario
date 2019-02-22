using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
   public class CategoriaVehiculos
    {
        public int Codigo { get; set; }
          [Display(Name = "Descripción")]
       public string Descripcion { get; set; }
       public decimal Recargo { get; set; }
       public int DeducibleMinimo { get; set; }
    }
}
