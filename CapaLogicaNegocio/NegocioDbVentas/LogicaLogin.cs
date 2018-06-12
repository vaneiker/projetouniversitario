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
    }
}
