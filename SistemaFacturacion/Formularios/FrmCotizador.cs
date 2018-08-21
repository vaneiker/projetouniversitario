using CapaEntidad.DbVentas;
using CapaLogicaNegocio.ModeloVista;
using CapaLogicaNegocio.NegocioDbVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion.Formularios
{
    public partial class FrmCotizador : Form
    {
        private ClienteEntitis clienteAFacturar = null;
        private DataTable dt = null;
        private VentaViewModel ventaActual = null;
        private List<DetalleVentaViewModel> detallesArticulos = null;
        int id_facturaGenerado = 0;

        public FrmCotizador()
        {
            InitializeComponent();
        }
        ComboxBosxTools cbo = new ComboxBosxTools();
        LogicaDbVentas f = new LogicaDbVentas();

        Alertas.AlertError er = new Alertas.AlertError();
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtB.Text))
            {
                Alertas.AlertError err = new Alertas.AlertError("Por Favor Digite la Informacion del Cliente");
                err.ShowDialog();
                txtB.Focus();
                return;
            }
            else
            {
                string a, b, c, d;
                a = txtB.Text.Trim();
                b = txtB.Text.Trim();
                c = txtB.Text.Trim();
                d = txtB.Text.Trim();

                var cliente = f.BuscarCliente(a, b, c, d);
                if (cliente.Rows.Count > 0)
                {
                    DataGrivCliente.DataSource = cliente;

                    LogicaDbVentas db = new LogicaDbVentas();
                    clienteAFacturar = db.GetClienteFromDataTable(cliente as DataTable);
                    id_facturaGenerado = 0;

                }
                else
                {
                    Alertas.Alerwarning war = new Alertas.Alerwarning("El cliente no fue encontrado!");
                    war.ShowDialog();
                    txtB.Focus();
                }
            }
        }

        private void FrmCotizador_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscarArticulo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarArticulo.Text))
            {
                Alertas.AlertError error = new Alertas.AlertError("El Codigo del Articulo a Buscar");
                error.ShowDialog();
                txtBuscarArticulo.Focus();
                return;
            }
            articulosEntitis articuloF = new articulosEntitis();
            var a = txtBuscarArticulo.Text.Trim();
            var b = txtBuscarArticulo.Text.Trim();


            articuloF = articuloF.ListaArticuloF(a, b);
            if (articuloF == null)
            {
                Alertas.Alerwarning war = new Alertas.Alerwarning("No Se Encontro El Articulo Buscado..");
                war.ShowDialog();
                txtBuscarArticulo.Text = string.Empty;
                txtBuscarArticulo.Focus();
                return;
            }

            else
            {
                dt = new DataTable();
                dt.Clear();
                LlenarDataTable(ref dt, articuloF);
                GrivArticulo.DataSource = dt;
                GrivArticulo.Columns["idarticulo"].Visible = false;
                GrivArticulo.Columns["idcategoria"].Visible = false;
                GrivArticulo.Columns["Imag_Url"].Visible = false;
                GrivArticulo.Columns["precioCompra"].Visible = false;
                GrivArticulo.Columns["estado"].Visible = false;
                GrivArticulo.Columns["idProveedor"].Visible = false;
                GrivArticulo.Columns["precioVenta"].Visible = true;
            }

            txtBuscarArticulo.Text = string.Empty;
            txtBuscarArticulo.Focus();
        }

        private void LlenarDataTable(ref DataTable dt, articulosEntitis nuevoArticulo)
        {
            dt.Columns.Add("idarticulo");
            dt.Columns.Add("nombre");
            dt.Columns.Add("idcategoria");
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Imag_Url");
            dt.Columns.Add("descripcion");
            dt.Columns.Add("precioVenta");
            dt.Columns.Add("precioCompra");
            dt.Columns.Add("cantidad");
            dt.Columns.Add("estado");
            dt.Columns.Add("idProveedor");
            dt.Columns.Add("CodigoBarra");

            DataRow nuevaFila = dt.NewRow();


            nuevaFila["idarticulo"] = nuevoArticulo.idarticulo;
            nuevaFila["nombre"] = nuevoArticulo.nombre;
            nuevaFila["idcategoria"] = nuevoArticulo.idcategoria;
            nuevaFila["Codigo"] = nuevoArticulo.codigo;
            nuevaFila["Imag_Url"] = nuevoArticulo.Imag_Url;
            nuevaFila["descripcion"] = nuevoArticulo.descripcion;
            nuevaFila["precioVenta"] = nuevoArticulo.precioVenta;
            nuevaFila["precioCompra"] = nuevoArticulo.precioCompra;
            nuevaFila["cantidad"] = nuevoArticulo.cantidad;
            nuevaFila["estado"] = nuevoArticulo.estado;
            nuevaFila["idProveedor"] = nuevoArticulo.idProveedor;
            nuevaFila["CodigoBarra"] = nuevoArticulo.CodigoBarra;

            dt.Rows.Add(nuevaFila);

        }

        private void GrivArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clienteAFacturar != null)
            {
                ventaActual = new VentaViewModel();
                Seccion session = Seccion.Instance;
                txtCliente.Text = clienteAFacturar.NombreCompleto;
                ventaActual = new VentaViewModel();
                ventaActual.idcliente = clienteAFacturar.idcliente;
                ventaActual.idtrabajador = session.IdTrabajador;
                ventaActual.fecha = DateTime.Now;
                txtBuscarArticulo.Focus();
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (textArticuloCantidad.Text.Length > 0)
            {
                int cantidadArticulo;
                if (!int.TryParse(textArticuloCantidad.Text, out cantidadArticulo))
                {
                    Alertas.AlertError cantidadInvalidad = new Alertas.AlertError("El Dato Digitado es Invalido. Asegurese de entrar un numero");
                    cantidadInvalidad.ShowDialog();
                    return;
                }
                if (dt == null || GrivArticulo.DataSource == null)
                {
                    Alertas.AlertError error = new Alertas.AlertError("Debe Buscar el Articulo");
                    error.ShowDialog();
                    txtBuscarArticulo.Focus();
                    return;
                }
                else
                {
                    DataRow filaDeArticuloAVender = dt.Rows[0];
                    string cantidad = "";
                    string subtotal = "";
                    string total = "";
                    string itbis = "";
                    detallesArticulos = AgregarArticulo(detallesArticulos, filaDeArticuloAVender, "0", out cantidad, out subtotal, out itbis, out total);
                    if (detallesArticulos != null)
                    {
                        txtCan.Text = cantidad;
                        txtSubtotal.Text = subtotal;
                        txtTotal.Text = total;
                        txtItbis.Text = itbis;
                        gridArticulosAVender.DataSource = null;
                        gridArticulosAVender.DataSource = detallesArticulos;
                        gridArticulosAVender.Columns["id_producto"].Visible = false;
                        GrivArticulo.DataSource = null;
                        txtBuscarArticulo.Focus();

                    }

                }
            }
        }

        private void gridArticulosAVender_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private List<DetalleVentaViewModel> AgregarArticulo(List<DetalleVentaViewModel> detallesArticulos, DataRow filaDeArticuloAVender, string txtDescuento, out string txtCan, out string txtSubtotal, out string txtItbis, out string txtTotal)
        {
            txtCan = "";
            txtTotal = "";
            txtSubtotal = "";
            txtItbis = "";
            int cantidadArticulo = 1;
            if (!string.IsNullOrWhiteSpace(textArticuloCantidad.Text))
            {
                if (!int.TryParse(textArticuloCantidad.Text, out cantidadArticulo))
                {
                    txtCan = "";
                    txtTotal = "";
                    txtSubtotal = "";
                    txtItbis = "";
                    return null;
                }
            }

            if (detallesArticulos == null)
            {

                decimal precioVenta = Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString());
                decimal precioCompra = Convert.ToDecimal(filaDeArticuloAVender["precioCompra"].ToString());
                decimal descuento = 0.0M;
                decimal descontado = 0.0M;
                if (!string.IsNullOrWhiteSpace(txtDescuento))
                {
                    if (!decimal.TryParse(txtDescuento, out descuento))
                    {
                        Alertas.AlertError parseError = new Alertas.AlertError("Asegurese de que el descuento es solo numero");
                        parseError.ShowDialog();
                        txtCan = string.Empty;
                        txtItbis = string.Empty;
                        txtSubtotal = string.Empty;
                        txtTotal = string.Empty;
                        return null;
                    }
                    else if (!DescuentoEsValido(descuento, precioVenta, precioCompra))
                    {
                        Alertas.AlertError parseError = new Alertas.AlertError("El descuento aplicado no es valido");
                        parseError.ShowDialog();
                        txtCan = string.Empty;
                        txtItbis = string.Empty;
                        txtSubtotal = string.Empty;
                        txtTotal = string.Empty;
                        return null;

                    }
                    descontado = precioVenta - (precioVenta * (descuento / 100));
                }
                else
                {
                    descontado = precioVenta;

                }

                detallesArticulos = new List<DetalleVentaViewModel>();
                DetalleVentaViewModel aGregar = new DetalleVentaViewModel
                {
                    iddetalle_venta = 0,
                    idventa = 0,
                    producto = filaDeArticuloAVender["nombre"].ToString(),
                    id_producto = Convert.ToInt32(filaDeArticuloAVender["idarticulo"].ToString()),
                    cantidad = cantidadArticulo,
                    precio_venta = descontado,
                    descuento = descuento / 100M,
                    itbis = (Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString()) * 0.18M)
                };
                if (!HayEnExistencia(Convert.ToDecimal(filaDeArticuloAVender["cantidad"].ToString()), aGregar.cantidad))
                {
                    txtCan = string.Empty;
                    txtSubtotal = string.Empty;
                    txtTotal = string.Empty;
                    txtItbis = string.Empty;
                    Alertas.Alerwarning noHay = new Alertas.Alerwarning("No Hay Articulos en Existencia Para la Cantidad Indicada. Verifique con Su Supervisor..");
                    noHay.ShowDialog();
                    return null;
                }
                detallesArticulos.Add(aGregar);
                txtCan = detallesArticulos.Count.ToString();
                decimal sub = detallesArticulos.Sum(venta => venta.precio_venta * venta.cantidad);
                txtSubtotal = sub.ToString("N2");
                decimal it = detallesArticulos.Sum(itbis => itbis.itbis * itbis.cantidad);
                txtItbis = it.ToString("N2");
                txtTotal = (sub + it).ToString("N2");
            }
            else
            {
                //logica para actualizar detalles articulos
                decimal _total = 0;
                decimal _subtotal = 0;
                decimal _itbis = 0;

                decimal precioVenta = Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString());
                decimal _itbisAgregar = (Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString()) * 0.18M);
                decimal precioCompra = Convert.ToDecimal(filaDeArticuloAVender["precioCompra"].ToString());
                decimal descuento = 0.0M;
                decimal precioDescontado;

                if (!string.IsNullOrWhiteSpace(txtDescuento))
                {
                    if (!decimal.TryParse(txtDescuento, out descuento))
                    {
                        Alertas.AlertError parseError = new Alertas.AlertError("Asegurese de que el descuento es solo numero");
                        parseError.ShowDialog();
                        txtCan = string.Empty;
                        txtItbis = string.Empty;
                        txtSubtotal = string.Empty;
                        txtTotal = string.Empty;
                        return null;
                    }
                }

                var index = detallesArticulos.FindIndex(de => de.producto.Equals(filaDeArticuloAVender["nombre"].ToString()));
                if (index >= 0)
                {
                    if (DescuentoEsValido(descuento, precioVenta, precioCompra))
                    {
                        detallesArticulos[index].cantidad++;
                        precioDescontado = precioVenta - (precioVenta * (descuento / 100));
                        if (!HayEnExistencia(Convert.ToDecimal(filaDeArticuloAVender["cantidad"].ToString()), detallesArticulos[index].cantidad))
                        {
                            txtItbis = string.Empty;
                            txtSubtotal = string.Empty;
                            txtTotal = string.Empty;
                            txtCan = string.Empty;

                            Alertas.Alerwarning noHay = new Alertas.Alerwarning("No Hay Articulos en Existencia Para la Cantidad Indicada. Verifique con Su Supervisor..");
                            noHay.ShowDialog();
                            return null;
                        }
                    }
                    else
                    {
                        Alertas.Alerwarning desc = new Alertas.Alerwarning("El Descuento no Es Valido");
                        desc.ShowDialog();
                        txtCan = string.Empty;
                        txtSubtotal = string.Empty;
                        txtTotal = string.Empty;
                        txtItbis = string.Empty;
                        return null;
                    }

                }
                else
                {
                    if (DescuentoEsValido(descuento, precioVenta, precioCompra))
                    {
                        precioDescontado = precioVenta - (precioVenta * (descuento / 100));
                    }
                    else
                    {
                        precioDescontado = precioVenta;
                    }
                    DetalleVentaViewModel aGregar = new DetalleVentaViewModel
                    {
                        iddetalle_venta = 0,
                        idventa = 0,
                        producto = filaDeArticuloAVender["nombre"].ToString(),
                        id_producto = Convert.ToInt32(filaDeArticuloAVender["idarticulo"].ToString()),
                        cantidad = cantidadArticulo,
                        precio_venta = precioDescontado,
                        descuento = descuento / 100M,
                        itbis = (Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString()) * 0.18M)
                    };

                    if (!HayEnExistencia(Convert.ToDecimal(filaDeArticuloAVender["cantidad"].ToString()), aGregar.cantidad))
                    {
                        txtItbis = string.Empty;
                        txtSubtotal = string.Empty;
                        txtTotal = string.Empty;
                        txtCan = string.Empty;

                        Alertas.Alerwarning noHay = new Alertas.Alerwarning("No Hay Articulos en Existencia Para la Cantidad Indicada. Verifique con Su Supervisor..");
                        noHay.ShowDialog();
                        return null;
                    }

                    detallesArticulos.Add(aGregar);
                }

                _subtotal = detallesArticulos.Sum(venta => venta.precio_venta * venta.cantidad);
                _itbis = detallesArticulos.Sum(venta => venta.itbis * venta.cantidad);
                _total = _subtotal + _itbis;
                txtCan = detallesArticulos.Count.ToString();
                txtSubtotal = _subtotal.ToString("N2");
                txtItbis = _itbis.ToString("N2");
                txtTotal = _total.ToString("N2");
            }
            textArticuloCantidad.Text = string.Empty;
            return detallesArticulos;
        }

        private bool HayEnExistencia(decimal enExistencia, int aReducir)
        {

            decimal reducido = (enExistencia - aReducir);
            return reducido > 0;
        }

        private bool DescuentoEsValido(decimal descuento, decimal precioVenta, decimal precioCompra)
        {
            decimal descuentoAGenerar = (descuento / 100) * precioVenta;
            decimal descontado = (precioVenta - descuentoAGenerar);
            return descontado > precioCompra;
        }

        private void btnBusc_Click(object sender, EventArgs e)
        {
            if(ventaActual == null)
            {
                Alertas.AlertError noRegistro = new Alertas.AlertError("No Se ha Registrado Ninguna Cotizacion, Busque El Cliente e Añade los Productos");
                noRegistro.ShowDialog();
                return;

            }

            if(string.IsNullOrWhiteSpace(txtTotal.Text.Trim()) || string.IsNullOrWhiteSpace(txtCan.Text.Trim()) || string.IsNullOrWhiteSpace(txtSubtotal.Text.Trim()))
            {
                Alertas.AlertError noRegistro = new Alertas.AlertError("No Se ha Registrado Ninguna Cotizacion, Busque El Cliente e Añade los Productos");
                noRegistro.ShowDialog();
                return;
            }
            LogicaDbVentas db = new LogicaDbVentas();
            ventaActual.cantidad = detallesArticulos.Count;
            ventaActual.itbis = detallesArticulos.Sum(de => de.itbis * de.cantidad);
            ventaActual.subtotal = detallesArticulos.Sum(de => de.precio_venta * de.cantidad);
            ventaActual.total = ventaActual.itbis + ventaActual.subtotal;

            int idCotizacion = db.IngresarCotizacion(ventaActual);
            if(idCotizacion <= 0)
            {
                Alertas.AlertError noIngreso = new Alertas.AlertError("No Se pudo Registrar la Cotizacion...");
                noIngreso.ShowDialog();
                id_facturaGenerado = 0;
                return;
            }else
            {
                db.IngresarDetallesCotizacion(idCotizacion, detallesArticulos);
                Alertas.AlertSuccess todoBien = new Alertas.AlertSuccess("Se Ha Ingresado La Cotizacion.");
                todoBien.ShowDialog();
                DataGrivCliente.DataSource = null;
                gridArticulosAVender.DataSource = null;
                txtB.Text = string.Empty;
                txtCliente.Text = string.Empty;
                ventaActual = null;
                clienteAFacturar = null;
                detallesArticulos = null;
                txtCan.Text = string.Empty;
                txtItbis.Text = string.Empty;
                txtSubtotal.Text = string.Empty;
                txtTotal.Text = string.Empty;
                id_facturaGenerado = idCotizacion;
                
            }
        }

        private void DataGrivCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ventaActual = new VentaViewModel();
            ventaActual.idcliente = Convert.ToInt32(DataGrivCliente.CurrentRow.Cells["idcliente"].Value.ToString());
            ventaActual.idtrabajador = Seccion.Instance.IdTrabajador;
            ventaActual.tipo_cliente = "Cliente Existente";
            ventaActual.tipo_comprobante = "Cotizacion";
            ventaActual.tipo_venta = "Cotizacion";

            txtCliente.Text = clienteAFacturar.NombreCompleto;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(id_facturaGenerado <= 0)
            {
                Alertas.Alerwarning noId = new Alertas.Alerwarning("No se Ha Generado la Cotizacion. Asegurece de Generar la Cotizacion primero");
                noId.ShowDialog();
                return;
            }
            else
            {
                CotizacionReporte reporteCotizacion = new Formularios.CotizacionReporte(id_facturaGenerado);
                reporteCotizacion.ShowDialog();
                id_facturaGenerado = 0;
            }
        }
    }
}
