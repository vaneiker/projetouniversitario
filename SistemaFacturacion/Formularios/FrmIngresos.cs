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
using SistemaFacturacion.Alertas;

namespace SistemaFacturacion.Formularios
    {
    public partial class FrmIngresos : Form
        {
        LogicaDbVentas _metodos = new LogicaDbVentas();
        public FrmIngresos()
            {
            InitializeComponent();
            }
        DocumentValidator d = new DocumentValidator();
        ComboxBosxTools cbo = new ComboxBosxTools();
        LogicaArticuloIngreso ing = new LogicaArticuloIngreso();
        Seccion seccion = Seccion.Instance;
        AlertError error = new AlertError();
        Alerwarning advertencia = new Alerwarning();
        AlertSuccess success = new AlertSuccess();


        private string tipo { get; set; }
        private void FrmIngresos_Load(object sender, EventArgs e)
            {
            carga();
            //this.reportViewer1.RefreshReport();
            }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.tipo = "Cedula";
            //var Cedula = d.IsValidModulo10(MackCedula.Text);
            //MackCedula.Visible = true;
            //lblTpD.Text = "Cedula";
            //lblTpD.Visible = true;
            //MaskRnc.Text = string.Empty;
            //MaskRnc.Visible = false;
           
        }

        private void RadioButtRnc_CheckedChanged(object sender, EventArgs e)
        {
            this.tipo = "RNC";
            //var Rnc = d.IsValidModulo10(MaskRnc.Text);
            //MaskRnc.Visible = true;
            //lblTpD.Text ="RNC";
            //lblTpD.Visible = true;
            //MackCedula.Text = string.Empty;
            //MackCedula.Visible = false;
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
           

        }
        public void carga()
        {
            GetProveedorCbox();
            GetCategotia();
           
        }
        private void GetCategotia()
        {
            var c = cbo.GetCategotia();
            cboCat.DataSource = c;
            cboCat.DisplayMember = "nombre";
            cboCat.ValueMember = "idcategoria";

        }

        private void GetProveedorCbox()
        {
            var c = cbo.ListaProve();
            cboProv.DataSource = c;
            cboProv.DisplayMember = "NombreProveedor";
            cboProv.ValueMember = "idproveedor";

        }

        private void btnRuta_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();

            Abrir.Filter = "Archivos JPEG(*.jpg)|*.jpg";
            Abrir.InitialDirectory = "D:/Todo_Comprimido/RECURSOS";

            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                String dir = Abrir.FileName;
                Bitmap pin = new Bitmap(dir);
                pinture.Image = (Image)pin;
                txtruta.Text = dir;
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {


        }

       private void Add_new_product(string  nombre
                                 , int      idcategoria
                                 , string   Codigo
                                 , string   mag_Url
                                 , string   descripcion
                                 , decimal  precioVenta
                                 , decimal  precioCompra
                                 , decimal  cantidad
                                 , bool     estado
                                 , int      idProveedor
                                 , int      idingreso
                                 , DateTime fecha
                                 , string   tipo_comprobante
                                 , decimal  igv
                                 , string   UsuarioAdiciona
                                 , decimal  stock_inicial
                                 , DateTime fecha_produccion
                                 , DateTime fecha_vencimiento)
        {

            bool parametro;
            parametro = ing.Add_Articulos(
                 nombre,
                 idcategoria,
                 Codigo,
                 mag_Url,
                 descripcion,
                 precioVenta,
                 precioCompra,
                 cantidad,
                 estado,
                 idProveedor,
                 idingreso,
                 fecha,
                 tipo_comprobante,
                 igv,
                 UsuarioAdiciona,
                 stock_inicial,
                 fecha_produccion,
                 fecha_vencimiento
                 );
            if (parametro == true)
            {
                success.ShowDialog();
            }
            else
            {
                error.ShowDialog();
            } 

        }

        private void RadioButtRnc_Click(object sender, EventArgs e)
        {

        }

        private void Aceptar_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNom.Text) || String.IsNullOrWhiteSpace(txtDes.Text))
            {
                advertencia.ShowDialog();
                //MessageBox.Show("Favor de Digitar el Nombre del Producto y su descripción");
                return;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(txtNom.Text) || String.IsNullOrWhiteSpace(txtDes.Text))
                {
                    advertencia.ShowDialog();
                    //MessageBox.Show("Favor de Digitar el Nombre del Producto y su descripción");

                    return;
                }
                else
                {
                    Add_new_product(
                                    txtNom.Text,
                                    int.Parse(cboCat.SelectedValue.ToString()),
                                    "0",
                                    txtruta.Text.Trim(),
                                    txtDes.Text,
                                    int.Parse(txtPrcioVenta.Text),
                                    int.Parse(txtComp.Text),
                                    int.Parse(txtCan.Text),
                                    true,
                                    int.Parse(cboProv.SelectedValue.ToString()),
                                    0,
                                    DateTime.Now,
                                    this.tipo,
                                   decimal.Parse(txtItbis.Text = "16"),
                                    seccion.Usuario,
                                    int.Parse(txtStok.Text),
                                    DateTime.Parse(dateFechaElavoracion.Text),
                                    DateTime.Parse(dateFechaVencimiento.Text));
                }
            }
            }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CodigoBarraGenerador r = new CodigoBarraGenerador();
            r.ShowDialog();
        }
    }
}























