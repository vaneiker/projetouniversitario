using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class TasaIntermediario
    {
        [Display(Name = "Código")]
        public int codigo { get; set; }
        public string NombreVendedor { get; set; }
        public string Tasa { get; set; }
    }
}
