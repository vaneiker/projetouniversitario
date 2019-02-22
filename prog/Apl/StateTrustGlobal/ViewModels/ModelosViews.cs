using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class ModelosViews
    {
        public Modelos Modelos { get; set; }
        public List<SPCBuscaTipoCapacidadModelo> VersionVehiculos { get; set; }
        public List<CapacidadTipoVehiculo> CapacidadTipoVehiculo { get; set; }
        public List<SPCBuscaTipoCapacidadModelo> TipoVehiculos { get; set; }
        public List<CategoriaVehiculos> CategoriaVehiculos { get; set; }
        public string Versiones { get; set; }
        public string Tipo_Vehiculos { get; set; }
        public string Capacidad { get; set; }
        public string Recargo { get; set; }
        
    }
}
