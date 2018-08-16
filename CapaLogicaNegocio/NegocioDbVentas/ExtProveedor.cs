using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.DbVentas;

namespace CapaLogicaNegocio.NegocioDbVentas
{
   public static class ExtProveedor
    {
        public static ProveedorEntity ListaProveedores(this ProveedorEntity proveedor, int id)
        {
            CapaDatos.RepocitoryDbVentas.DventasData db = new CapaDatos.RepocitoryDbVentas.DventasData();
            proveedor = db.ListaProveedores(id);

            return proveedor;
        }
    }
}
