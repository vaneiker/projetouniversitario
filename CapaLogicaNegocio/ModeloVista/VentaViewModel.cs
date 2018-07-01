using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.ModeloVista
{
    public class VentaViewModel
    {
      

        public int idventa { get; set;  }
        public int idcliente { get; set; }
        public int idtrabajador { get; set;  }
        public DateTime fecha { get; set;  }
        public int cantidad { get; set; }
        public string tipo_comprobante { get; set; }
        public string tipo_venta { get; set; }
        public string tipo_cliente { get; set; }
        public decimal itbis { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }

        public ICollection<DetalleVentaViewModel> Detalles { get; set; }

    }
}
