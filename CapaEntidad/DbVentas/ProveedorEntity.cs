using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class ProveedorEntity
        {

        public int idproveedor { get; set; }
        public string razon_social { get; set; }
        public string NombreProveedor { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public bool? statu { get; set; }
        public DateTime? FechaAdiciona { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string UsuarioAdiciona { get; set; }
        public string UsuarioModifica { get; set; }
        public string HostName { get; set; }


        }
    }
