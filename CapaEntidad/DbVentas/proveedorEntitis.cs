using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class proveedorEntitis
        {

        public proveedorEntitis()
            {

            this.ingreso = new HashSet<ingresosEntitis>();

            this.cuentas_x_pagar = new HashSet<cuentas_x_pagarEntitis>();

            }


        public int idproveedor { get; set; }

        public string razon_social { get; set; }

        public string NombreProveedor { get; set; }

        public string tipo_documento { get; set; }

        public string num_documento { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public string url { get; set; }

        public Nullable<bool> statu { get; set; }

        public Nullable<System.DateTime> FechaAdiciona { get; set; }

        public Nullable<System.DateTime> FechaModifica { get; set; }

        public string UsuarioAdiciona { get; set; }

        public string UsuarioModifica { get; set; }

        public string HostName { get; set; }



        public virtual ICollection<ingresosEntitis> ingreso { get; set; }

      
        public virtual ICollection<cuentas_x_pagarEntitis> cuentas_x_pagar { get; set; }
        }
    }
