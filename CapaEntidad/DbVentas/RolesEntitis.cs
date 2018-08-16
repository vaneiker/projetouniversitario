using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class RolesEntitis
        {
          public RolesEntitis()
            {

            this.USERS = new HashSet<UsersEntitis>();

            }


        public int id { get; set; }

        public string Nombre { get; set; }

        public string Grupo { get; set; }



        public virtual ICollection<UsersEntitis> USERS { get; set; }

        }
    }
