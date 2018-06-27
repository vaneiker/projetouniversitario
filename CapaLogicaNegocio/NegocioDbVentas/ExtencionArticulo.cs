using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.DbVentas;

namespace CapaLogicaNegocio.NegocioDbVentas
{
  public static  class ExtencionArticulo
    {

        public static  articulosEntitis ListaArticuloF(this articulosEntitis articulo, string codigo, string nom)
        {
            CapaDatos.RepocitoryDbVentas.DventasData db = new CapaDatos.RepocitoryDbVentas.DventasData();
            articulo = db.BuscarArticuloFaturar( codigo, nom);

            return articulo;
        }
    }
}
