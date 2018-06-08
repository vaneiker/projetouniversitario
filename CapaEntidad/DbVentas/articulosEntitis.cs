using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class articulosEntitis
        {

      public int idarticulo {get;set;}
      public string codigo {get;set;}
      public string nombre {get;set;}
      public int idcategoria {get;set;}
      public string Imag_Url {get;set;}
      public string descripcion {get;set;}
      public decimal? precioVenta {get;set;}
      public decimal? precioCompra {get;set;}
      public decimal? cantidad {get;set;}
      public bool? estado {get;set;}
      public int idProveedor {get;set;}

        }
    }
    
