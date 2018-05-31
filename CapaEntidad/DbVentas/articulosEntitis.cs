using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class articulosEntitis
        {

        public articulosEntitis()
            {

            this.detalle_ingreso = new HashSet<detalle_ingresoEntitis>();

            }


        public int idarticulo { get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public byte[] imagen { get; set; }

        public int idcategoria { get; set; }

        public int idpresentacion { get; set; }

        public string Imag_Url { get; set; }

        public Nullable<decimal> precioVenta { get; set; }

        public Nullable<decimal> precioCompra { get; set; }

        public Nullable<decimal> cantidad { get; set; }

        public Nullable<bool> estado { get; set; }

        public int idProveedor { get; set; }



        public virtual categoriaEntitis categoria { get; set; }

      

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<detalle_ingresoEntitis> detalle_ingreso { get; set; }

        }
    }
    
