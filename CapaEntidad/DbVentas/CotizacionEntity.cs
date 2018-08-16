using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
{
    /// <summary>
    /// Clase Cotizacion Para Guardar y Recuperar informacion de Las Cotizaciones.
    /// </summary>
   public class CotizacionEntity
    {
        public int idcotizacion { get; set; }
        public int idcliente { get; set; }
        public int idtrabajador { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
        public decimal itbis { get; set; }
        public decimal total { get; set; }
        public DateTime fecha { get; set; }
        public bool estatus { get; set; }
    }
}
