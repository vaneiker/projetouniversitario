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

namespace SistemaFacturacion.Formularios
    {
    public partial class FrmArticulos : Form
        {
        public FrmArticulos()
            {
            InitializeComponent();
            }
        ComboxBosxTools cbo = new ComboxBosxTools();
        LogicaDbVentas _metodos = new LogicaDbVentas();


        private void FrmArticulos_Load(object sender, EventArgs e)
            {
            carga();

            }
        private void GetProveedorCbox()
            {
            var c = cbo.ListaProve();
            cboProv.DataSource = c;
            cboProv.DisplayMember = "NombreProveedor";
            cboProv.ValueMember = "idproveedor";

            }
        private void GetCategotia()
            {
            var c = cbo.GetCategotia();
            cboCat.DataSource = c;
            cboCat.DisplayMember = "nombre";
            cboCat.ValueMember = "idcategoria";

            }
        public void ListaArticulos()
            {
            var articulo = _metodos.ListaArticulos();
            GridViewArticulos.DataSource = articulo;

            }
        private void BtnCategoria_Click(object sender, EventArgs e)
            {
            FrmCategoria f = new Formularios.FrmCategoria();
            //BtnCategoria.Enabled = false;
            f.ShowDialog();
            }
        private void toolStripEliminar_Click(object sender, EventArgs e)
            {
            if (TabArticulo.SelectedIndex == 1)
            {
                MessageBox.Show("Por Favor de ir a la pestaña de busqueda.");
                return;
            }
            string codigo = GridViewArticulos.CurrentRow.Cells[1].Value.ToString();
            string nombre = GridViewArticulos.CurrentRow.Cells[2].Value.ToString();
            DialogResult result = MessageBox.Show($"Desea Eliminar El Producto {codigo}?", "Eliminar Articulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(result == DialogResult.OK)
            {
                LogicaDbVentas db = new LogicaDbVentas();
                articulosEntitis entity = new articulosEntitis();
                if(db.Eliminar_Articulo(entity))
                {

                }
            }
                carga();
            }      
        private void GridViewArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }
        public void carga()
            {
            GetProveedorCbox();
            GetCategotia();
            ListaArticulos();
            }

        public void InsertarArticulos()
            {

            articulosEntitis entitis = new articulosEntitis();
            decimal a, b, c;
            a = decimal.Parse(txtCan.Text);
            b = decimal.Parse(txtVent.Text);
            c = decimal.Parse(txtComp.Text);

            entitis.idarticulo=0;
            entitis.codigo=MascKcodigoBarra.Text;
            entitis.nombre=txtNom.Text;
            entitis.idcategoria =int.Parse(cboCat.SelectedValue.ToString());
            entitis.Imag_Url    =txtruta.Text.Trim();
            entitis.descripcion =txtDes.Text;
            entitis.precioVenta = b;
            entitis.precioCompra = c;
            entitis.cantidad = a;
            entitis.estado =true;
            entitis.idProveedor = int.Parse(cboProv.SelectedValue.ToString());
            _metodos.Registrar_Articulos(entitis);

            }

        private void Aceptar_Click(object sender, EventArgs e)
            {
            InsertarArticulos();
            }

        private void btnRuta_Click(object sender, EventArgs e)
            {
          

            }

        private void OpenFileImagen_FileOk(object sender, CancelEventArgs e)
            {

            }

        private void BuscarD_Click(object sender, EventArgs e)
            {
            TabArticulo.SelectedTab = TabArticulo.TabPages[0];
            }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CodigoBarraGenerador c = new CodigoBarraGenerador();
            c.ShowDialog();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            TabArticulo.SelectedTab = TabArticulo.TabPages["tabMantenimiento"];
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
                pictureBox1.Image = (Image)pin;
                txtruta.Text = dir;
            }

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Esta seguro que desea salir de este Formulario?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

         private void Eliminar_Click(object sender, EventArgs e)
        {
            if (TabArticulo.SelectedIndex == 1)
            {
                MessageBox.Show("Por Favor de ir a la pestaña de busqueda.");
                return;
            }
            string codigo = GridViewArticulos.CurrentRow.Cells[1].Value.ToString();
            string nombre = GridViewArticulos.CurrentRow.Cells[2].Value.ToString();
            DialogResult result = MessageBox.Show($"Desea Eliminar El Producto {codigo}?", "Eliminar Articulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                LogicaDbVentas db = new LogicaDbVentas();
                articulosEntitis entity = db.BuscarArticulosPorCodigo(codigo);
                if(entity != null)
                {
                    if(db.Eliminar_Articulo(entity))
                    {
                        MessageBox.Show("Articulo Eliminado..");
                    }
                    else
                    {
                        MessageBox.Show("Error al Eliminar el Articulo.", "Error en Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            carga();
        }

    }
    }
