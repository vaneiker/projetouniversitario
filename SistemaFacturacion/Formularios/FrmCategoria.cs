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
    public partial class FrmCategoria : Form
        {
        LogicaDbVentas _metodos = new LogicaDbVentas();

        categoriaEntitis categoria = new categoriaEntitis();
      
        public FrmCategoria()
            {
            InitializeComponent();
            }

        private void BuscarD_Click(object sender, EventArgs e)
            {

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
            GuardarCategoria();
            }

        #region metodos
        private void GuardarCategoria()
            {
            categoria.idcategoria =int.Parse("0");
            categoria.nombre = txtNom.Text.Trim();
            categoria.descripcion = txtDes.Text.Trim();
            _metodos.Registrar_Categoria(categoria);
            MessageBox.Show("Categoria Insertada Correctamente");
            }
        #endregion
        private void Salir_Click(object sender, EventArgs e)
            {
            MenuPrincipal fp = new MenuPrincipal();


            DialogResult resul = MessageBox.Show("Esta seguro que desea salir de este Formulario?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
                {
                  this.Close();
                }
           
            }

      
        }
    }
