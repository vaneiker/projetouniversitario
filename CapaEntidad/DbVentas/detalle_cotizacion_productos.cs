using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
{
    /// <summary>
    /// Clase publica Detalle de cotizacion de productos para Ingresar y extraer datos de detalles
    /// </summary>
    public class detalle_cotizacion_productos
    {
        public int id_cotizacion_producto { get; set; }
        public int idcotizacion { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public decimal precioVenta { get; set; }
        public decimal itbis { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }
    }
}
