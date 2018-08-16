using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
{
   public class ArticulosCompuestoEntity
    {
        public string nombre               {get; set;}    
        public int idcategoria             {get;set;}      
        public string Codigo                  {get;set;}      
        public string Imag_Url             {get;set;}   
        public string descripcion          {get;set;}   
        public decimal? precioVenta        {get;set;} 
        public decimal? precioCompra       {get;set;} 
        public decimal? cantidad           {get;set;} 
        public bool estado                 {get;set;}     
        public int idProveedor             {get;set;}      
        public int idingreso               {get;set;}      
        public DateTime? fecha             {get;set;}
        public string tipo_comprobante     {get;set;}   
        public decimal? igv                 {get;set;}  
        public string UsuarioAdiciona      {get;set;}   
        public decimal? stock_inicial           {get;set;}      
        public int stock_actual            {get;set;}       
        public DateTime? fecha_produccion  {get;set;} 
        public DateTime? fecha_vencimiento {get;set;} 

    }
}
