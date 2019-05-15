using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.WSEntities
{
    public class PolicyCanceladasProspectoVehicleWS
    {
        public Nullable<int> ramo { get; set; }
        public decimal Cotizacion { get; set; }
        public string Poliza { get; set; }
        public string EstatusPoliza { get; set; }
        public Nullable<int> Item { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> SubRamo { get; set; }
        public string DescripcionSubramo { get; set; }
        public string EstatusItem { get; set; }
        public string TipoVehiculo { get; set; }
        public string Idtipovehiculo { get; set; }
        public string Marca { get; set; }
        public string IdMarca { get; set; }
        public string Modelo { get; set; }
        public string Idmodelo { get; set; }
        public string Ano { get; set; }
        public string Idano { get; set; }
        public string Uso { get; set; }
        public string Iduso { get; set; }
        public string Estacionamiento { get; set; }
        public string IdEstacionamiento { get; set; }
        public Nullable<decimal> ValorVehiculo { get; set; }
        public string Deducible { get; set; }
        public string Iddeducible { get; set; }
        public string placa { get; set; }
        public string chasis { get; set; }
        public string color { get; set; }
        public Nullable<decimal> primaproratadiasinimpuestos { get; set; }
        public string DescripcionTarifa { get; set; }
        public bool Financed { get; set; }
        public string TipoPolizaDescripcion { get; set; }
        public Nullable<bool> TieneEndoso { get; set; }
        public Nullable<decimal> ValorEndosoCesion { get; set; }
        public string RNC { get; set; }
        public Nullable<decimal> Prima { get; set; }
        public int ColorId { get; set; }
        public int ChasisId { get; set; }
        public int PlacaId { get; set; }
        public Nullable<int> SubramoNew { get; set; }
        public string DescripcionSubramoNew { get; set; }
        public Nullable<decimal> PrimaBrutaNew { get; set; }
        public Nullable<decimal> primaproratadiasinimpuestosNew { get; set; }
        public string TipoPolizaDescripcionNew { get; set; }
        public int Secuenciamov { get; set; }
        public string conceptomovimiento { get; set; }

        public string FechaFinString { get; set; }

        public int? TipoPolizaNew { get; set; }

        public int? vehicleId { get; set; }


        public string TipoCombustible { get; set; }
        public string IdTipoCombustible { get; set; }
        public string Capacidad { get; set; }
        public string IdCapacidad { get; set; }
        public decimal? PorcientoRecargoVenta { get; set; }
        
    }
}
