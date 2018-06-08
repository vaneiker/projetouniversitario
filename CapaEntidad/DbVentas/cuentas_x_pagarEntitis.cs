using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class cuentas_x_pagarEntitis
        {
        public int id { get; set; }

        public int id_proveedor { get; set; }

        public System.DateTime fecha { get; set; }

        public decimal valor { get; set; }

        public bool pagado { get; set; }

        public string usuario { get; set; }



        public virtual ProveedorEntity proveedor { get; set; }
        }
    }
