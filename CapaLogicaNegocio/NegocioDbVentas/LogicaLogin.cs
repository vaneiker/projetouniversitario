using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.DbVentas;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaLogicaNegocio.NegocioDbVentas
{
    public static class  LogicaLogin
    {
        
        public static bool ValidateLogin(string usuario, string contrasena, out int rolId)
        {
            bool isValid = true;
               if(String.IsNullOrWhiteSpace(usuario) || String.IsNullOrWhiteSpace(contrasena))
            {

                isValid = false;
                rolId = 0;
            }
            else
            {
                CapaDatos.RepocitoryDbVentas.DventasData db = new CapaDatos.RepocitoryDbVentas.DventasData();
                rolId = db.LoginUser(usuario, contrasena);
            }

            return isValid;
        }

        public static UsersEntitis GetUserByName(this UsersEntitis user, string usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario))
                return null;

            CapaDatos.RepocitoryDbVentas.DventasData db = new CapaDatos.RepocitoryDbVentas.DventasData();
            user = db.GetUserByName(usuario);

            return user;
        }

        public static UsersEntitis RegistrarUsuario(this UsersEntitis user, string usuario, string clave, int role, bool status, int id = 0)
        {
            CapaDatos.RepocitoryDbVentas.DventasData db = new CapaDatos.RepocitoryDbVentas.DventasData();
            user.id = id;
            user.Usuario = usuario;
            user.Clave = clave;
            user.RolID = role;
            user.Statud = status;
            db.RegistrarUsuario(user);

            return user.GetUserByName(user.Usuario);

        }
    }
}
