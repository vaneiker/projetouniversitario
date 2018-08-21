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
        private string codigo { get; set; }


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
            //if (TabArticulo.SelectedIndex == 1)
            //{
            //    MessageBox.Show("Por Favor de ir a la pestaña de busqueda.");
            //    return;
            //}
            //string codigo = GridViewArticulos.CurrentRow.Cells[1].Value.ToString();
            //string nombre = GridViewArticulos.CurrentRow.Cells[2].Value.ToString();
            //DialogResult result = MessageBox.Show($"Desea Eliminar El Producto {codigo}?", "Eliminar Articulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //if (result == DialogResult.OK)
            //{
            //    LogicaDbVentas db = new LogicaDbVentas();
            //    articulosEntitis entity = new articulosEntitis();
            //    if (db.Eliminar_Articulo(entity))
            //    {

            //    }
            //}
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
        public void InsertarArticulos(string cod ,string codigo,string nombre,int idcategoria,string Imag_Url,string descripcion,decimal precioVenta,decimal precioCompra,decimal cantidad, bool estado, int idProveedor)
                            
        {
         
           
            var repuesta = _metodos.Registrar_Articulos(cod,codigo,nombre,idcategoria,Imag_Url,descripcion,precioVenta,precioCompra,cantidad,estado,idProveedor);

            if (repuesta == true)
            {
                Alertas.AlertSuccess trueR = new Alertas.AlertSuccess("Registro Guardado Satifactoriamente");
                trueR.ShowDialog();
                clearT();
                carga();
                Inactivar("Guardar");

            }
            else
            {
                Alertas.AlertError falseR = new Alertas.AlertError("Registro no fue Guardado");
                falseR.ShowDialog();
            }

        }
        private void clearT()
        {
            this.codigo = string.Empty;
            cboCat.Text="---Seleccione---";
            cboProv.Text= "---Seleccione---";
            txtNom.Text = string.Empty;
            txtDes.Text = string.Empty;
            txtruta.Text = string.Empty;
            pictureBox1.Image = null;
            txtComp.Text = "0";
            txtCan.Text = "0";
            txtVent.Text = "0";
             

        }
        private void Aceptar_Click(object sender, EventArgs e)
            {
            if (string.IsNullOrWhiteSpace(cboCat.Text) || string.IsNullOrWhiteSpace(cboProv.Text) || cboProv.Text == "---Seleccione---")
            {
                Alertas.AlertError error = new Alertas.AlertError("Seleccione el Proveedor y la categoria del producto");
                error.ShowDialog();
                return;
            }
            else
                 if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtDes.Text))
            {
                Alertas.AlertError error = new Alertas.AlertError("Digite el Articulo y su Descripción");
                error.ShowDialog();
                return;
            }
            else
                 if (string.IsNullOrWhiteSpace(txtCan.Text) || string.IsNullOrWhiteSpace(txtComp.Text) || string.IsNullOrWhiteSpace(txtVent.Text))
            {
                Alertas.AlertError error = new Alertas.AlertError("Digite el Precio de Compra, la cantidad y el Precio de Venta");
                error.ShowDialog();
                return;
            }
          InsertarArticulos(this.codigo, "0", txtNom.Text, int.Parse(cboCat.SelectedValue.ToString()), txtruta.Text.Trim(), txtDes.Text
             , int.Parse(txtVent.Text), decimal.Parse(txtComp.Text), decimal.Parse(txtCan.Text), true, int.Parse(cboProv.SelectedValue.ToString()));
            TabArticulo.SelectedTab = TabArticulo.TabPages[0];

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
           
           



            if (string.IsNullOrWhiteSpace(txtSearchCategoria.Text))
            {
                Alertas.AlertError err = new Alertas.AlertError("Por Favor Digite la Informacion del Articulo");
                err.ShowDialog();
                txtSearchCategoria.Focus();
                return;
            }
            else
            {
                string a, b;
                a = txtSearchCategoria.Text.Trim();
                b = txtSearchCategoria.Text.Trim();


                var buscar = _metodos.CriterioBusquedaArticulo(a, b);
              
                if (buscar.Rows.Count > 0)
                {
                    GridViewArticulos.DataSource = buscar;
                  

                }
                else
                {
                    Alertas.AlertError err = new Alertas.AlertError("No Existe Data");
                    err.ShowDialog();
                    txtSearchCategoria.Focus();
                }
            }




        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CodigoBarraGenerador c = new CodigoBarraGenerador();
            c.ShowDialog();
        }
        private void Nuevo_Click(object sender, EventArgs e)
        {
            TabArticulo.SelectedTab = TabArticulo.TabPages["tabMantenimiento"];
            Inactivar("Nuevo");
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
            DialogResult resul = MessageBox.Show("Esta seguro que desea eliminar este Articulo?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
            {
                var repuesta = _metodos.BorrarArticulo(int.Parse(this.codigo),false);

                if (repuesta == true)
                {
                    Alertas.AlertSuccess trueR = new Alertas.AlertSuccess("Articulo Eliminado Satifactoriamente");
                    trueR.ShowDialog();
                    clearT();
                    carga();
                    Inactivar("Borrar");

                }
                else
                {
                    Alertas.AlertError falseR = new Alertas.AlertError("Articulo no fue Eliminado ");
                    falseR.ShowDialog();
                }

            }

        }
        private void GridViewArticulos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewArticulos.CurrentRow != null)
            {
                DialogResult resul = MessageBox.Show("Que acción desea Realizar?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resul == System.Windows.Forms.DialogResult.OK)
                {
                    TabArticulo.SelectedTab = TabArticulo.TabPages["tabMantenimiento"];
                    Inactivar("Editar");
                    this.codigo = Convert.ToString(GridViewArticulos.CurrentRow.Cells[0].Value.ToString());
                    txtNom.Text = GridViewArticulos.CurrentRow.Cells[2].Value.ToString();
                    txtDes.Text = GridViewArticulos.CurrentRow.Cells[5].Value.ToString();

                    txtCan.Text= GridViewArticulos.CurrentRow.Cells[8].Value.ToString();
                    txtComp.Text= GridViewArticulos.CurrentRow.Cells[7].Value.ToString();
                }
                else
                {
                    TabArticulo.SelectedTab = TabArticulo.TabPages["tabMantenimiento"];

                    Inactivar("Borrar");
                    txtNom.Text = GridViewArticulos.CurrentRow.Cells[2].Value.ToString();
                    txtDes.Text = GridViewArticulos.CurrentRow.Cells[3].Value.ToString();

                    this.codigo = Convert.ToString(GridViewArticulos.CurrentRow.Cells[0].Value.ToString());

                }
                this.codigo = Convert.ToString(GridViewArticulos.CurrentRow.Cells[0].Value.ToString());
                
            }
        }
        private void calcularPrecioVenta()
        {
            if(txtCan.Text=="" || txtComp.Text=="")
            {
                return;
            }
            else if (txtCan.Text == "0" || txtComp.Text == "0")
            {
                return;
            }
            else
            {   int a,c;              
                a = int.Parse(txtComp.Text.Replace(",00",""));
                c = a * 35/100;
                var precioV = a + c;
                txtVent.Text = Convert.ToString(precioV);
            }

          

        }
        private void txtCan_TextChanged(object sender, EventArgs e)
        {
            if(this.codigo!=null || this.codigo != "")
            {
              calcularPrecioVenta();
            }
           
        }
        private void txtComp_TextChanged(object sender, EventArgs e)
        {
            calcularPrecioVenta();
        }
        private void Inactivar(string actividad)
        {
            if (actividad == "Guardar")
            {
                Aceptar.Enabled = false;
                Eliminar.Enabled = false;
                Nuevo.Enabled = true;
                clearT();
                ActiveT();
            }
            else if (actividad == "Editar")
            {
                Aceptar.Enabled = true;
                Nuevo.Enabled = false;
                Eliminar.Enabled = false;
                clearT();
                ActiveT();

            }
            else if (actividad == "Nuevo")
            {
                Nuevo.Enabled = false;
                Aceptar.Enabled = true;
                Eliminar.Enabled = false;
                ActiveT();
            }

            else if (actividad == "Borrar")
            {
                Nuevo.Enabled = true;
                Aceptar.Enabled = false;
                Eliminar.Enabled = false;
                DctiveT();
            }

        }
        private void DctiveT()
        {
            cboCat.Enabled = false;
            cboProv.Enabled = false;
             
            txtNom.Enabled = false;
            txtDes.Enabled = false;
            txtCan.Enabled = false;
            txtComp.Enabled = false;

        }
        private void ActiveT()
        {
            cboCat.Enabled = true;
            cboProv.Enabled = true;            
            txtNom.Enabled = true;
            txtDes.Enabled = true;
            txtCan.Enabled = true;
            txtComp.Enabled = true;

        }

        private void Limpia_Click(object sender, EventArgs e)
        {
            ActiveT();
            clearT();
        }

        private void txtCan_KeyPress(object sender, KeyPressEventArgs e)
        {
            AppTools.Util.SoloNumeros(e);
        }
    }
    }
