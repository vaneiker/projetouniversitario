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
                //else
                //{
                //    DataRow filaDeArticuloAVender = dt.Rows[0];
                //    string cantidad = "";
                //    string subtotal = "";
                //    string total = "";
                //    string itbis = "";
                //    detallesArticulos = AgregarArticulo(detallesArticulos, filaDeArticuloAVender, txtDescuento.Text, out cantidad, out subtotal, out itbis, out total);
                //    if (detallesArticulos != null)
                //    {
                //        txtCan.Text = cantidad;
                //        txtSubtotal.Text = subtotal;
                //        txtTotal.Text = total;
                //        txtItbis.Text = itbis;
                //        gridArticulosAVender.DataSource = null;
                //        gridArticulosAVender.DataSource = detallesArticulos;
                //        gridArticulosAVender.Columns["id_producto"].Visible = false;
                //        GrivArticulo.DataSource = null;
                //        txtBuscarArticulo.Focus();
                //    }
                //    else
                //    {
                //        Alertas.Alerwarning aler = new Alertas.Alerwarning("No se Agrego el Articulo");
                //        aler.ShowDialog();
                //    }


                //}
            }
        }
    }
}
