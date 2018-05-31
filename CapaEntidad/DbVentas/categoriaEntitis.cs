using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class categoriaEntitis
        {
        public categoriaEntitis()
            {

            this.articulo = new HashSet<articulosEntitis>();

            }


        public int idcategoria { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }



       
        public virtual ICollection<articulosEntitis> articulo { get; set; }
        }
    }
