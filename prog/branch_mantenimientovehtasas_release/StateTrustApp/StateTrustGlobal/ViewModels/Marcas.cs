using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StateTrustGlobal.ViewModels
{
    public class Marcas
    {
        [Display(Name="Cód. Marca")]
        public int Make_Id { get; set; }
        
        [Display(Name="Nombre Marca")]
        //[Required(ErrorMessage = "Campo Requerido {0}")]
        public string Make_Desc { get; set; }

        [Display(Name="Estatus")]
        public string Make_Status { get; set; }

        [Display(Name="Estatus")]
        public string Pos_Flag { get; set; }

       
    }
    public class MarcasSysFlex
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }

    }
}