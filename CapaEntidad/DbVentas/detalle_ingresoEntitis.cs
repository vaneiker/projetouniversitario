using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
 public  class detalle_ingresoEntitis
        {
        public detalle_ingresoEntitis()
            {

            this.detalle_venta = new HashSet<detalle_ventaEntitis>();

            }


        public int iddetalle_ingreso { get; set; }

        public int idingreso { get; set; }

        public int idarticulo { get; set; }

        public decimal precio_compra { get; set; }

        public decimal precio_venta { get; set; }

        public int stock_inicial { get; set; }

        public int stock_actual { get; set; }

        public System.DateTime fecha_produccion { get; set; }

        public System.DateTime fecha_vencimiento { get; set; }



        public virtual articulosEntitis articulo { get; set; }

        public virtual ingresosEntitis ingreso { get; set; }

       
        public virtual ICollection<detalle_ventaEntitis> detalle_venta { get; set; }

        }
    }
