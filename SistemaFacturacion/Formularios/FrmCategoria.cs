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
using Microsoft.VisualBasic;

namespace SistemaFacturacion.Formularios
    {
    public partial class FrmCategoria : Form
        {

        LogicaDbVentas _metodos = new LogicaDbVentas();
        private int codigo { get; set; }
        categoriaEntitis categoria = new categoriaEntitis();

        public FrmCategoria()
            {
            InitializeComponent();
            }

        private void BuscarD_Click(object sender, EventArgs e)
            {
             string nombreCategoria = Interaction.InputBox("Digite El Nombre de La Categoria", "Buscar Categoria Por Nombre", "Nombre Categoria");
              //buscar la categoria en la base de datos y asignar el nuevo dataset al grid
            }

        private void FrmCategoria_Load(object sender, EventArgs e)
            {
            ListarCategoria();
            }

        private void ListarCategoria()
            {
            var dato = _metodos.ListCategoria();
            GridViewCategoria.DataSource = dato;
            }

        private void toolStripButton1_Click(object sender, EventArgs e)
            {
            ListarCategoria();
            }

        private void Aceptar_Click(object sender, EventArgs e)
            {
            if (String.IsNullOrWhiteSpace(txtDes.Text) || String.IsNullOrWhiteSpace(txtDes.Text))
                {
                MessageBox.Show("Favor de Digitar la categoria y su descripción");
                return;
                }
            else
                {
               
                GuardarCategoria(txtNom.Text,txtDes.Text,this.codigo);
                }
            }

        #region metodos
        private void GuardarCategoria(string nombre, string descripcion, int id )
            {
            LogicaCategoria l = new LogicaCategoria();
            bool m;
            categoria.idcategoria = id;
            categoria.nombre = txtNom.Text.Trim();
            categoria.descripcion = txtDes.Text.Trim();


            m = l.Insertar(nombre,descripcion,id);
            if (m == true)
                {
                ErrorPersonalizado(1);

              }
            else
                {
                ErrorPersonalizado(0);
                }
            }
        #endregion
        private void Salir_Click(object sender, EventArgs e)
            {
          
            DialogResult resul = MessageBox.Show("Esta seguro que desea salir de este Formulario?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
                {
                this.Close();
                }
            }

        private void ErrorPersonalizado(int valor)
            {


            if(valor==0)
                {
                panelErrorCategoria.Visible = true;
                panelErrorCategoria.BackColor = Color.FromArgb(242, 222, 222);
                label6.BackColor = Color.FromArgb(162,18,16);
                label6.Text = "Error al Insertar Los Datos";

                }
            else if(valor==1)
                {
                panelErrorCategoria.Visible = true;         
                panelErrorCategoria.BackColor = Color.FromArgb(223, 240, 216);
                label6.BackColor = Color.FromArgb(223, 240, 216);
                label6.Text = "Datos Insertar Correctamente";
                ListarCategoria();
                txtDes.Text = string.Empty;
                txtNom.Text = string.Empty;
                txtNom.Focus();
                }

            
            }

        private void GridViewCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            if (GridViewCategoria.CurrentRow != null)
                {

                this.codigo= int.Parse(GridViewCategoria.CurrentRow.Cells[0].Value.ToString());
                txtNom.Text = GridViewCategoria.CurrentRow.Cells[1].Value.ToString();
                txtDes.Text = GridViewCategoria.CurrentRow.Cells[2].Value.ToString();
                //txtTelefono.Text = GridViewEmpleado.CurrentRow.Cells[4].Value.ToString();
                //txtDni.Text = GridViewEmpleado.CurrentRow.Cells[5].Value.ToString();
                //txtDireccion.Text = GridViewEmpleado.CurrentRow.Cells[6].Value.ToString();
                }
            }

        private void TabEmpleado_KeyPress(object sender, KeyPressEventArgs e)
            {
           
            }

        private void TabEmpleado_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (panelErrorCategoria.Visible == true) { panelErrorCategoria.Visible = false; }
            }
        }
    }