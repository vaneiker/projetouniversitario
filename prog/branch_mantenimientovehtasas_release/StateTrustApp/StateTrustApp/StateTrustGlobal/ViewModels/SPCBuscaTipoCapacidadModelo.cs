using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class SPCBuscaTipoCapacidadModelo
    {
      //  public int Idioma { get; set; }
        [Display(Name="Descripción")]
        public string DescIdioma { get; set; }
        public int IdListaHeader { get; set; }
        public string DescListaGeneral { get; set; }
        public int Estatus { get; set; }
        public int MarcaCapacidad { get; set; }
        public int MarcaVersion { get; set; }
        public int MarcaCategoria { get; set; }
        public int MarcaTipo { get; set; }
        public string Descripcion { get; set; }
        public bool IsChecked { get; set; }

    }
}
   
