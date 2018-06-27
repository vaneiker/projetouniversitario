using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.DbVentas;


namespace CapaLogicaNegocio.NegocioDbVentas
{
 public static class ExtencionTrabajador
    {
        public static trabajadorEntitis ListaTrabajador(this trabajadorEntitis trabajador,string NombCompleto,string cedula,string telefono)
        {
            CapaDatos.RepocitoryDbVentas.DventasData db = new CapaDatos.RepocitoryDbVentas.DventasData();
            trabajador = db.ListaTrabajador(NombCompleto,cedula,telefono);

            return trabajador;
        }

        public static trabajadorEntitis GetEmployeeById(this trabajadorEntitis trabajador, int id)
        {
            if (id <= 0) return null;

            CapaDatos.RepocitoryDbVentas.DventasData db = new CapaDatos.RepocitoryDbVentas.DventasData();
            return db.GetEmployeeById(id);
        }
    }
}
