using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.ModeloVista
{
    public class CuadreViewModel
    {
        public DateTime Fecha { get; set; }
        public int IdVenta { get; set; }
        public string NombreCliente { get; set; }
        public int IdTrabajador { get; set; }
        public string TipoFactura { get; set; }
        public string TipoVenta { get; set; }
        public string Categoria { get; set; }
        public decimal ITBIS { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total  { get; set; }
        public string Estado { get; set; }
    }
}
