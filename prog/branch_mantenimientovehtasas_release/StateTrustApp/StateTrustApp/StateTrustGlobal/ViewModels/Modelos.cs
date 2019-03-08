using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class Modelos
    {
        [Display(Name = "Cód. Marca")]
        public int Make_Id { get; set; }
         [Display(Name = "Marca")]
        [Required]
        public string  Make_Desc { get; set; }

        [Display(Name = "Cód. Modelo")]
        public int Model_Id { get; set; }

        [Display(Name = "Modelo")]
        public string Model_desc { get; set; }

        [Display(Name = "Estatus")]
        public bool Pos_flag { get; set; }

        [Display(Name = "Cód. Vehiculo")]
        public int Vehicle_Type_Id { get; set; }

        [Display(Name = "Tipo Vehiculo")]
        public string Vehicle_Type_Desc{ get; set; }

        public bool IsChecked { get; set; }
        public int core_Id { get; set; }

        [Display(Name = "Modelo")]
        //[Required(ErrorMessage = "Campo Requerido {0}")]
        public string NombreModelo { get; set; }

        public string NombreCapacidad { get; set; }
        //Categoria Vehiculos
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Recargo")]
        public decimal Recargo { get; set; }

        [Display(Name = "Deducible Minimo")]
        public int DeducibleMinimo { get; set; }

        List<SPCBuscaTipoCapacidadModelo> ListSPCBuscaTipoCapacidadModelo { get; set; }

        
        public string capacidad1 { get; set; }
        [Display(Name = "Cód. Marca")]
        public int Marca { get; set; }

        [Display(Name = "Cód. Modelo")]
        public int Modelo { get; set; }

        [Display(Name = "Modelo")]
        public string DescModelo { get; set; }

        [Display(Name = "Estatus")]
        public int Estatus { get; set; }

        [Display(Name = "Cód. Vehiculo")]
        public int IdCapacidad { get; set; }

        [Display(Name = "Tipo Vehiculo")]
        public string DescCapacidad { get; set; }

        public int IdTipoVehiculo { get; set; }
        public string  DescTipoVehiculo { get; set; }
        public string VersionVeh { get; set; }
        public int IdListaHeader { get; set; }
        public Modelos Modeloss { get; set; }

        public bool IsCheck { get; set; }

    }

    public class Modelos_Pos_Site
    { 

        [Display(Name = "Cód. Modelo")]
        public int Model_Id { get; set; }

        [Display(Name = "Modelo")]
        public string Model_desc { get; set; }

        [Display(Name = "Estatus")]
        public bool Pos_flag { get; set; }

        [Display(Name = "Cód. Vehiculo")]
        public int Vehicle_Type_Id { get; set; }

        [Display(Name = "Tipo Vehiculo")]
        public string Vehicle_Type_Desc { get; set; }


        //public int core_Id { get; set; }

        [Display(Name = "Cód. Marca")]
        public int Make_Id { get; set; }
 
    }
    public class Modelos_SysFlex
    {
        [Display(Name = "Cód. Marca")]
        public int Make_Id { get; set; }

        [Display(Name = "Cód. Modelo")]
        public int Model_Id { get; set; }

        [Display(Name = "Modelo")]
        public string Model_desc { get; set; }

        [Display(Name = "Estatus")]
        public string  ModelPos_flag { get; set; }

        [Display(Name = "Cód. Vehiculo")]
        public string Make_Desc { get; set; }

        [Display(Name = "Tipo Vehiculo")]
        public string MakePos_flag { get; set; }

    }


     
}
