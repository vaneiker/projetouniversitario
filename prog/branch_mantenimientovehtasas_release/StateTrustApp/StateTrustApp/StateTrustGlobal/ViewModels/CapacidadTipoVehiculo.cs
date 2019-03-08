using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class CapacidadTipoVehiculo
    {
        public int IdCapacidad { get; set; }
           [Display(Name = "Descripción")]
        public string DescCapacidad { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string DescTipoVehiculo { get; set; }
     
    }
}
