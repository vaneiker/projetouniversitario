using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.POSEntities
{
    public class ProductsDataFromSysflex
    {
        public int Id { get; set; }
        public int? Ramo { get; set; }
        public int SubRamo { get; set; }
        public string SubRamoName { get; set; }
        public int? Year { get; set; }
        public int? TipoVehiculo { get; set; }
        public int? ProductoId { get; set; }
        public int? ProductoId2 { get; set; }
        public string Descripcion { get; set; }
        public decimal? PorcientoInicial { get; set; }
        public decimal? PorcientoFinal { get; set; }
        public decimal? MontoInicial { get; set; }
        public decimal? MontoFinal { get; set; }
        public decimal? Prima { get; set; }
        public decimal? Porciento { get; set; }
        public string Comentario { get; set; }
        public decimal? Calculo { get; set; }
        public int? Compania { get; set; }
        public int TipoPoliza { get; set; }
        public string DescTipoPoliza { get; set; }
        public bool? RequiereInspeccion { get; set; }
        public int? IdCapacidad { get; set; }
        public string DescCapacidad { get; set; }
        public int? IdUso { get; set; }
        public string DescUso { get; set; }
        public DateTime Create_Date { get; set; }
        public int Create_UsrId { get; set; }
        public DateTime? Modi_Date { get; set; }
        public int? Modi_UsrId { get; set; }
        public string hostname { get; set; }
    }
}
