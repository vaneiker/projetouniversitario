using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
  public  class ventasEntitis
        {
        public ventasEntitis()
            {

            this.detalle_venta = new HashSet<detalle_ventaEntitis>();

            }


        public int idventa { get; set; }

        public int idcliente { get; set; }

        public int idtrabajador { get; set; }

        public System.DateTime fecha { get; set; }

        public string tipo_comprobante { get; set; }

        public string serie { get; set; }

        public string correlativo { get; set; }

        public decimal igv { get; set; }



        public virtual ClienteEntitis cliente { get; set; }

     
        public virtual ICollection<detalle_ventaEntitis> detalle_venta { get; set; }

        public virtual trabajadorEntitis trabajador { get; set; }
        }
    }
