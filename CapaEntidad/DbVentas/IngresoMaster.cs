using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
   public class IngresoMasterEntity
        {
        public int idingreso               { get; set;}
        public int idproveedor             { get; set;}
        public DateTime? fecha             { get; set;}
        public string tipo_comprobante     { get; set;}
        public string serie                { get; set;}
        public int correlativo             { get; set;}
        public decimal? Itbis              { get; set;}
        public DateTime? FechaAdiciona     { get; set;}
        public DateTime? FechaModifica     { get; set;}
        public string UsuarioAdiciona      { get; set;}
        public string UsuarioModifica      { get; set;}
        public int idarticulo              { get; set;}
        public int precio_compra           { get; set;}
        public int precio_venta            { get; set;}
        public int stock_inicial           { get; set;}
        public int stock_actual            { get; set;}
        public DateTime? fecha_produccion  { get; set;}
        public DateTime? fecha_vencimiento { get; set; }
        }
    }
