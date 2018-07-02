using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
{
    public class FacturaEntity
    {
        public int id_factura { get; set; }
        public int id_cliente { get; set; }
        public string nombre_trabajador { get; set; }
        public string tipo_pago { get; set; }
        public DateTime fecha { get; set; }
        public string medio_pago { get; set; }
        public int id_venta { get; set; }
        public int id_trabajador { get; set; }
        public int cantidad_articulos { get; set; }
        public decimal subtotal { get; set; }
        public decimal itbis { get; set; }
        public decimal total { get; set; }
        public string numero_factura { get; set; }
    }
}
