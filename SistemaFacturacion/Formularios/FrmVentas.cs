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
        int id_facturaGenerado = 0;

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
                GrivArticulo.Columns["precioCompra"].Visible = false;
                GrivArticulo.Columns["estado"].Visible = false;
                GrivArticulo.Columns["idProveedor"].Visible = false;
                GrivArticulo.Columns["precioVenta"].Visible = true;
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
            textArticuloCantidad.Focus();
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
            if(textArticuloCantidad.Text.Length > 0)
            {
                int cantidadArticulo;
                if(!int.TryParse(textArticuloCantidad.Text, out cantidadArticulo))
                {
                    Alertas.AlertError cantidadInvalidad = new Alertas.AlertError("La Cantidad Digitada es Invalidad. Asegurese de entrar un numero");
                    cantidadInvalidad.ShowDialog();
                    return;
                }
            }
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
                    gridArticulosAVender.Columns["id_producto"].Visible = false;
                    GrivArticulo.DataSource = null;
                    txtBuscarArticulo.Focus();
                    btnCancelarFactura.Visible = true;
                    btnCancelarFactura.Enabled = true;
                    btnRemoveItem.Visible = true;
                    btnRemoveItem.Enabled = true;
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
            return  reducido > 0;
        }

        private bool DescuentoEsValido(decimal descuento, decimal precioVenta, decimal precioCompra)
        {
            decimal descuentoAGenerar = (descuento / 100) * precioVenta;
            decimal descontado = (precioVenta - descuentoAGenerar);
            return  descontado >  precioCompra;
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

            if(clienteAFacturar.idcliente == 1 && cboCliente.SelectedIndex > 0)
            {
                Alertas.Alerwarning ventasDirectas = new Alertas.Alerwarning("Para Ventas Ambulatorias Seleccione Ventas Directas");
                ventasDirectas.ShowDialog();
                return;
            }

            if(clienteAFacturar.idcliente == 1 && (radioACredito.Checked || cboProv.SelectedIndex != 1 || comboMedioPago.SelectedIndex != 0))
            {
                Alertas.Alerwarning noCredito = new Alertas.Alerwarning("No se Permites Ventas Directas a Credito, solo Efectivo y factura Normal");
                noCredito.ShowDialog();
                return;

            }

            //Generar Pago
            LogicaDbVentas db = new LogicaDbVentas();
            ventaActual.Detalles = detallesArticulos;
            ventaActual.fecha = DateTime.Now;
            ventaActual.subtotal = detallesArticulos.Sum(s => s.precio_venta * s.cantidad);
            ventaActual.itbis = detallesArticulos.Sum(i => i.itbis * i.cantidad);
            ventaActual.cantidad = detallesArticulos.Count;
            ventaActual.total = ventaActual.subtotal + ventaActual.itbis;
            ventaActual.tipo_cliente = cboCliente.Text;
            ventaActual.tipo_venta = radioAlContado.Checked ? "Al Contado" : "A Credito";
            ventaActual.idcliente = clienteAFacturar.idcliente;
            ventaActual.tipo_comprobante = cboProv.Text;

            int idventa = db.IngresarVentaModelo(ventaActual, detallesArticulos);
            if(idventa > 0)
            {
                foreach(DetalleVentaViewModel articulo in detallesArticulos)
                {
                    db.ReducirArticulo(articulo.id_producto, articulo.cantidad);
                }
                if (radioACredito.Checked)
                {
                    db.AgregarCuentaACobrar(ventaActual.idcliente, idventa, ventaActual.total, Seccion.Instance.nombreCompleto);
                }
                FacturaEntity facturaGenerada = new FacturaEntity();
                facturaGenerada.cantidad_articulos = ventaActual.cantidad;
                facturaGenerada.fecha = ventaActual.fecha;
                facturaGenerada.id_cliente = ventaActual.idcliente;
                facturaGenerada.id_factura = 0;
                facturaGenerada.id_trabajador = ventaActual.idtrabajador;
                facturaGenerada.id_venta = idventa;
                facturaGenerada.itbis = ventaActual.itbis;
                facturaGenerada.medio_pago = comboMedioPago.Text;
                facturaGenerada.nombre_trabajador = Seccion.Instance.nombreCompleto;
                facturaGenerada.subtotal = ventaActual.subtotal;
                facturaGenerada.tipo_pago = radioAlContado.Checked ? "Al Contado" : "A Credito";
                facturaGenerada.total = ventaActual.total;

               id_facturaGenerado =  db.IngresarFactura(facturaGenerada);
                if(id_facturaGenerado > 0)
                {
                    Alertas.AlertSuccess facturaG = new Alertas.AlertSuccess("Se ha Generado La Factura No. " + id_facturaGenerado.ToString());
                    facturaG.ShowDialog();
                    GrivArticulo.DataSource = null;
                    DataGrivCliente.DataSource = null;
                    txtCan.Text = string.Empty;
                    txtItbis.Text = string.Empty;
                    txtSubtotal.Text = string.Empty;
                    txtTotal.Text = string.Empty;
                    cargarTipoF();
                    txtBuscarArticulo.Text = string.Empty;
                    txtCliente.Text = string.Empty;
                    cboCliente.Text = string.Empty;
                    cboProv.Text = string.Empty;
                    comboMedioPago.SelectedIndex = 0;
                    checkDescuento.Checked = false;
                    radioAlContado.Checked = true;
                    gridArticulosAVender.DataSource = null;
                    btnCancelarFactura.Visible = false;
                    btnRemoveItem.Visible = false;
                    cboCliente.Focus();
                    btnCuadre.Visible = true;
                    if (MessageBox.Show("Desea Imprimir la Factura?", "Impresion", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                    {
                       Formularios.VisualFactura facturaAImprimir = new VisualFactura(id_facturaGenerado);
                        facturaAImprimir.ShowDialog();
                        btnImprimir.Visible = false;
                        btnPagar.Visible = true;
                        btnPagar.Enabled = false;
                        id_facturaGenerado = 0;
                        ventaActual = null;
                        detallesArticulos = null;
                        clienteAFacturar = null;
                        dt = null;
                        GrivArticulo.DataSource = null;
                        textArticuloCantidad.Text = string.Empty;
                        gridArticulosAVender.DataSource = null;
                        txtB.Text = string.Empty;
                        
                        btnRemoveItem.Visible = false;
                        btnCancelarFactura.Visible = false;

                    }
                    else
                    {
                        btnImprimir.Visible = true;
                        btnImprimir.Enabled = true;
                        btnPagar.Visible = false;
                        btnImprimir.Focus();
                        
                    }
                    

                }
            }
            

        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Desea Cancelar la vental Actual", "Cancelar Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
            {
                //mostrar formulario modal para digitar el usuario del supervisor y su contraseña.
                using(CancelForm cancelar = new CancelForm())
                {
                    cancelar.ShowDialog();

                    if (cancelar.PuedeCancelar)
                    {
                        Limpia_Click(sender, new EventArgs());
                    }
                }
                
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(id_facturaGenerado <= 0)
            {
                Alertas.AlertError noId = new Alertas.AlertError("No Hay Factura a Imprimir");
                noId.ShowDialog();
                btnImprimir.Visible = false;
                btnPagar.Visible = true;
                btnPagar.Enabled = false;
            }
            else
            {
                Formularios.VisualFactura facturaAImprimir = new VisualFactura(id_facturaGenerado);
                facturaAImprimir.ShowDialog();
                btnImprimir.Visible = false;
                btnPagar.Visible = true;
                btnPagar.Enabled = false;
                id_facturaGenerado = 0;
                ventaActual = null;
                detallesArticulos = null;
                clienteAFacturar = null;
                gridArticulosAVender.DataSource = null;
                dt = null;
                
            }
        }

        private void Limpia_Click(object sender, EventArgs e)
        {
            
            btnImprimir.Visible = false;
            btnPagar.Visible = true;
            btnPagar.Enabled = false;
            id_facturaGenerado = 0;
            ventaActual = null;
            detallesArticulos = null;
            clienteAFacturar = null;
            dt = null;
            textArticuloCantidad.Text = string.Empty;
            txtB.Text = string.Empty;
            cboCliente.Focus();
          
            gridArticulosAVender.DataSource = null;
            txtB.Text = string.Empty;
            cboCliente.Text = string.Empty;
            txtCan.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            txtItbis.Text = string.Empty;
            cboProv.Text = string.Empty;
            comboMedioPago.Text = string.Empty;

        }

        private void Cuadrar_Click(object sender, EventArgs e)
        {
            CuadreForm cuadrar = new Formularios.CuadreForm();

            cuadrar.ShowDialog();
            
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if(detallesArticulos == null || gridArticulosAVender.Rows.Count <= 0 || gridArticulosAVender.DataSource == null)
            {
                Alertas.Alerwarning noArticulos = new Alertas.Alerwarning("No Hay Articulos en la Lista.");
                noArticulos.ShowDialog();
                return;
            }
            string idProducto = gridArticulosAVender.CurrentRow.Cells[2].Value.ToString();
            int index = detallesArticulos.FindIndex(c => c.producto == idProducto);
            if (detallesArticulos[index].cantidad == 1)
            {
                detallesArticulos.RemoveAt(index);

                if (detallesArticulos.Count <= 0)
                {
                    detallesArticulos = null;
                    gridArticulosAVender.DataSource = null;
                    btnRemoveItem.Visible = false;
                    btnCancelarFactura.Visible = false;
                    txtTotal.Text = string.Empty;
                    txtItbis.Text = string.Empty;
                    txtSubtotal.Text = string.Empty;
                    txtCan.Text = string.Empty;

                }else
                {
                    gridArticulosAVender.Refresh();
                }
            }
            else
            {
                detallesArticulos[index].cantidad -= 1;
                gridArticulosAVender.Refresh();
            }
            

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Si ha hecho algun cambio y no lo guardo, al cerrar los cambio se perderan, Seguro que desea cerrar?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnCuadre_Click(object sender, EventArgs e)
        {
            Formularios.CuadreForm cf = new Formularios.CuadreForm();
            cf.ShowDialog();
        }
    }
}   


