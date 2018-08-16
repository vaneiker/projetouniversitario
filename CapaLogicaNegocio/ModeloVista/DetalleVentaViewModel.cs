namespace CapaLogicaNegocio.ModeloVista
{
    public class DetalleVentaViewModel
    {
        public int iddetalle_venta { get; set; }
        public int idventa { get; set; }
        public string producto { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_venta { get; set; }
        public decimal descuento { get; set; } = 0.0M;
        public decimal itbis { get; set; }
    }
}