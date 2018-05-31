using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class UsersEntitis
        {

        public int id { get; set; }

        public string Usuario { get; set; }

        public string Clave { get; set; }

        public int RolID { get; set; }

        public Nullable<bool> Statud { get; set; }



        public virtual RolesEntitis ROLES { get; set; }
        }
    }
