using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.DbVentas;
using CapaLogicaNegocio.NegocioDbVentas;
using CapaLogicaNegocio.ModeloVista;

namespace SistemaFacturacion.Formularios
    {
    public partial class FrmVentas : Form
        {

        private ClienteEntitis clienteAFacturar = null;
        private DataTable dt = null;
        private VentaViewModel ventaActual = null;
        private List<DetalleVentaViewModel> detallesArticulos = null;

        public FrmVentas()
            {
            InitializeComponent();
            }
        ComboxBosxTools cbo = new ComboxBosxTools();
        LogicaDbVentas f = new LogicaDbVentas();

        Alertas.AlertError er = new Alertas.AlertError();
       

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            cargarTipoF();
            txtB.Focus();
        }

        private void cargarTipoF()
        {
            var c = cbo.TipoDeFactura();
            cboProv.DataSource = c;
            cboProv.DisplayMember = "Tipo_Comprovante_Fiscal";
            cboProv.ValueMember = "id";
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem.ToString() == "Cliente Exisentes")
            {
                lblCri.Visible = true;
                txtB.Visible = true;
                btnBusc.Visible = true;
                lblBus.Visible = true;
            }
            else
            {
                MessageBox.Show("Desea cambiar A venta Directa?");
                lblCri.Visible = false;
                txtB.Visible = false;
                btnBusc.Visible = false;
                lblBus.Visible = false;
                groupBox2.Visible = false;
            }
        }

        private void groupBox1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_EnabledChanged(object sender, EventArgs e)
        {
            lblBus.Visible = true;
            btnBusc.Visible = true;
            txtB.Visible = true;
            groupBox2.Visible = true;
        }

        private void btnBusc_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtB.Text))
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
                    groupBox2.Visible = true;
                    LogicaDbVentas db = new LogicaDbVentas();
                    clienteAFacturar = db.GetClienteFromDataTable(cliente as DataTable);

                }
                else
                {
                    MessageBox.Show("No existe Data");
                    groupBox2.Visible = false;
                }
            }
          }

       private void BtnBuscarArticulo_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(cboCliente.Text))
            {
                Alertas.AlertError noCliente = new Alertas.AlertError("Asegurese de poner el tipo de cliente a facturar");
                noCliente.ShowDialog();
                cboCliente.Focus();
                return;
            }
            else
            {
                if(cboCliente.SelectedIndex == 0 && clienteAFacturar == null)
                {
                    LogicaDbVentas db = new LogicaDbVentas();
                    DataTable cliente = db.BuscarCliente("CLIENTE AMBULATORIO", "NINGUNO", "NINGUNO", "NINGUNO");
                    clienteAFacturar = db.GetClienteFromDataTable(cliente);

                    ventaActual = new VentaViewModel();
                    ventaActual.fecha = DateTime.Now;
                    ventaActual.idcliente = clienteAFacturar.idcliente;
                    ventaActual.idtrabajador = Seccion.Instance.IdTrabajador;
                    ventaActual.idventa = 0;
                    ventaActual.tipo_cliente = "AMBULATORIO";
                    ventaActual.tipo_comprobante = "NINGUNO";
                }
            }
            if(string.IsNullOrWhiteSpace(txtBuscarArticulo.Text))
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
            if(articuloF == null)
            {
                Alertas.AlertError error = new Alertas.AlertError("No Se Encontro El Articulo Buscado..");
                error.ShowDialog();
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
                GrivArticulo.Columns["precioVenta"].Visible = false;
                GrivArticulo.Columns["estado"].Visible = false;
                GrivArticulo.Columns["idProveedor"].Visible = false;
            }

            txtBuscarArticulo.Text = string.Empty;
            txtBuscarArticulo.Focus();

        }

        private void LlenarDataTable( ref DataTable dt, articulosEntitis nuevoArticulo)
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

        private void DataGrivCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(clienteAFacturar != null)
            {
                ventaActual = new VentaViewModel();
                Seccion session = Seccion.Instance;
                txtCliente.Text = clienteAFacturar.NombreCompleto;
                ventaActual = new VentaViewModel();
                ventaActual.idcliente = clienteAFacturar.idcliente;
                ventaActual.idtrabajador = session.IdTrabajador;
                ventaActual.fecha = DateTime.Now;
                ventaActual.tipo_cliente = cboCliente.SelectedIndex == 0 ? "Ambulatorio" : "Cliente Existente";
                ventaActual.tipo_venta = cboCliente.SelectedIndex == 0 ? "Ambulatoria" : "Cliente Existente";
                txtBuscarArticulo.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cboProv.SelectedIndex <= 0)
            {
                Alertas.AlertError nfc = new Alertas.AlertError("Seleccione el tipo de Comprovante");
                nfc.ShowDialog();
                cboProv.Focus();
                return;

            }
            if(string.IsNullOrWhiteSpace(comboMedioPago.Text))
            {
                Alertas.AlertError tipoPago = new Alertas.AlertError("Debe Seleccionar el tipo de Pago");
                tipoPago.ShowDialog();
                comboMedioPago.Focus();
                return;
            }
            if(dt == null || GrivArticulo.DataSource == null)
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
                detallesArticulos = AgregarArticulo(detallesArticulos, filaDeArticuloAVender, txtDescuento.Text, out cantidad, out subtotal, out itbis, out total);
                if(detallesArticulos != null)
                {
                    txtCan.Text = cantidad;
                    txtSubtotal.Text = subtotal;
                    txtTotal.Text = total;
                    txtItbis.Text = itbis;
                    gridArticulosAVender.DataSource = null;
                    gridArticulosAVender.DataSource = detallesArticulos;
                    GrivArticulo.DataSource = null;
                    txtBuscarArticulo.Focus();
                }
                else
                {
                    Alertas.Alerwarning aler = new Alertas.Alerwarning("No se Agrego el Articulo");
                    aler.ShowDialog();
                }
                
                
            }
            if (cboProv.SelectedIndex > 0)
                btnPagar.Enabled = true;

            if(ventaActual == null)
            {
                ventaActual = new VentaViewModel();
                ventaActual.fecha = DateTime.Now;
                Seccion seccion = Seccion.Instance;
                ventaActual.idtrabajador = seccion.IdTrabajador;
                ventaActual.tipo_cliente = "Ambulatorio";
                if (cboProv.SelectedIndex > 0)
                    ventaActual.tipo_comprobante = cboProv.Text;
            }

        }

        private void radioAlContado_CheckedChanged(object sender, EventArgs e)
        {
            if (ventaActual == null)
            {
                return;
            }
            if (radioAlContado.Checked)
            {
                ventaActual.tipo_venta = "Al Contado";
            }

            if (radioACredito.Checked)
            {
                ventaActual.tipo_venta = "A Credito";
            }
        }

        private void checkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDescuento.Checked)
            {
                txtDescuento.Visible = true;
                txtDescuento.Focus();
            }else
            {
                txtDescuento.Visible = false;
                txtDescuento.Text = string.Empty;
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private List<DetalleVentaViewModel> AgregarArticulo(List<DetalleVentaViewModel> detallesArticulos, DataRow filaDeArticuloAVender, string txtDescuento, out string txtCan, out string txtSubtotal, out string txtItbis, out string txtTotal)
        {
            if (detallesArticulos == null)
            {
                decimal precioVenta = Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString());
                decimal descuento = 0.0M;
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

                detallesArticulos = new List<DetalleVentaViewModel>();
                detallesArticulos.Add(new DetalleVentaViewModel
                {
                    iddetalle_venta = 0,
                    idventa = 0,
                    producto = filaDeArticuloAVender["nombre"].ToString(),
                    cantidad = 1,
                    precio_venta = precioVenta,
                    descuento = descuento / 100M,
                    itbis = (Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString()) * 0.18M)
                });
                txtCan = detallesArticulos.Count.ToString();
                txtSubtotal = detallesArticulos[0].precio_venta.ToString();
                txtItbis = detallesArticulos[0].itbis.ToString();
                txtTotal = (detallesArticulos[0].precio_venta + detallesArticulos[0].itbis).ToString();

            }else
            {
                //logica para actualizar detalles articulos
                decimal _total = 0;
                decimal _subtotal = 0;
                decimal _itbis = 0;

                decimal precioVenta = Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString());
                decimal _itbisAgregar = (Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString()) * 0.18M);
                decimal descuento = 0.0M;
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
                if(index >= 0)
                {
                    detallesArticulos[index].cantidad++;
                }else
                {
                    detallesArticulos.Add(new DetalleVentaViewModel
                    {
                        iddetalle_venta = 0,
                        idventa = 0,
                        producto = filaDeArticuloAVender["nombre"].ToString(),
                        cantidad = 1,
                        precio_venta = precioVenta,
                        descuento = descuento / 100M,
                        itbis = (Convert.ToDecimal(filaDeArticuloAVender["precioVenta"].ToString()) * 0.18M)
                    });
                }

                //foreach(DetalleVentaViewModel detalle in detallesArticulos)
                //{
                //    _subtotal += (detalle.precio_venta * detalle.cantidad);
                //    _itbis += (detalle.itbis + _itbisAgregar);
                //    _total += (_subtotal + _itbis);
                //}
                _subtotal = detallesArticulos.Sum(venta => venta.precio_venta * venta.cantidad);
                _itbis = detallesArticulos.Sum(venta => venta.itbis * venta.cantidad);
                _total = _subtotal + _itbis;
                txtCan = detallesArticulos.Count.ToString();
                txtSubtotal = _subtotal.ToString("N2");
                txtItbis = _itbis.ToString("N2");
                txtTotal = _total.ToString("N2");
            }

            return detallesArticulos;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if(clienteAFacturar == null)
            {
                Alertas.AlertError noCliente = new Alertas.AlertError("Asegurese de que el tipo de cliente este seleccionado");
                noCliente.ShowDialog();
                cboCliente.Focus();
                return;
            }
            if(ventaActual == null)
            {
                Alertas.AlertError noCliente = new Alertas.AlertError("No se a cargado ninguna venta a facturar");
                noCliente.ShowDialog();
                return;
            }

            if(detallesArticulos == null)
            {
                Alertas.AlertError noCliente = new Alertas.AlertError("No se encontraron ningun articulos a facturar");
                noCliente.ShowDialog();
                return;
            }else if (detallesArticulos.Count <= 0)
            {
                Alertas.AlertError noCliente = new Alertas.AlertError("No se encontraron ningun articulos a facturar");
                noCliente.ShowDialog();
                return;

            }

            MessageBox.Show("Se puede pagar");

        }
    }
}   


