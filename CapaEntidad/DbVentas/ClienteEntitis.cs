using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
  public  class ClienteEntitis
        {
        public int idcliente { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string sexo { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public bool? statu { get; set; }
        public string CodigoCliente { get; set; }
        public DateTime? FechaAdiciona { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string UsuarioAdiciona { get; set; }
        public string UsuarioModifica { get; set; }
        public string HostName { get; set; }
        public string NombreCompleto { get; set; }

        }
    }
 