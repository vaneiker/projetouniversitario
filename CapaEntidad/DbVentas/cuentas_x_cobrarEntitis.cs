using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
    public class cuentas_x_cobrarEntitis
    {
        public int id { get; set; }

        public int id_cliente { get; set; }

        public DateTime? fecha { get; set; }

        public decimal valor { get; set; }

        public bool pagado { get; set; }

        public string usuario { get; set; }

        public string num_documento { get; set; }

        public string codigoCliente { get; set; }

        public string NombComp { get; set; }

        public int id_venta { get; set; }
          public int idFactura { get; set; }
        public decimal CantidadPagada { get; set; }
        public bool statud { get; set; }
        public virtual ClienteEntitis cliente { get; set; }
        }
    }
