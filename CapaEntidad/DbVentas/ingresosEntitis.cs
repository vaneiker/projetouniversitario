using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
  public  class ingresosEntitis
        {
        public ingresosEntitis()
            {

            this.detalle_ingreso = new HashSet<detalle_ingresoEntitis>();

            }


        public int idingreso { get; set; }

        public int idtrabajador { get; set; }

        public int idproveedor { get; set; }

        public System.DateTime fecha { get; set; }

        public string tipo_comprobante { get; set; }

        public string serie { get; set; }

        public string correlativo { get; set; }

        public decimal igv { get; set; }

        public Nullable<System.DateTime> FechaAdiciona { get; set; }

        public Nullable<System.DateTime> FechaModifica { get; set; }

        public string UsuarioAdiciona { get; set; }

        public string UsuarioModifica { get; set; }



       
        public virtual ICollection<detalle_ingresoEntitis> detalle_ingreso { get; set; }

        public virtual ProveedorEntity proveedor { get; set; }

        public virtual trabajadorEntitis trabajador { get; set; }
        }
    }
