using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.DbVentas;

namespace CapaEntidad.DbVentas
    {
   public class trabajadorEntitis
        {

        public trabajadorEntitis()
            {

            this.ingreso = new HashSet<ingresosEntitis>();

            this.venta = new HashSet<ventasEntitis>();

            }


        public int idtrabajador { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }
        public string estatus { get; set; }
        public string sexo { get; set; }
        public string NombreCompleto { get; set; }
        public System.DateTime Fecha_nac { get; set; }

        public string num_documento { get; set; }
        public bool? StatusE { get; set; }
        public string direccion { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public DateTime? FechaAdiciona  {get;set;}
        public DateTime? FechaModifica  {get;set;}
        public string UsuarioAdiciona{get;set;}
        public string UsuarioModifica{get;set;}

     
        public virtual ICollection<ingresosEntitis> ingreso { get; set; }

     
        public virtual ICollection<ventasEntitis> venta { get; set; }
        }
    }
