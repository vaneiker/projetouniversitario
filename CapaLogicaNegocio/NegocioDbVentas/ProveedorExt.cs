using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.RepocitoryDbVentas;
using CapaEntidad.DbVentas;
namespace CapaLogicaNegocio.NegocioDbVentas
{
   public static class ProveedorExt
    {
        public static ProveedorEntity GetProveedor(this ProveedorEntity p,int id_proveedor)
        {
            CapaDatos.RepocitoryDbVentas.DventasData db = new DventasData();
            p = db.ListaProveedores(id_proveedor);
            return p;
        }

    }
}
