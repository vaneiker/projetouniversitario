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
    public partial class FrmIngresos : Form
        {
        LogicaDbVentas _metodos = new LogicaDbVentas();
        public FrmIngresos()
            {
            InitializeComponent();
            }

        private void FrmIngresos_Load(object sender, EventArgs e)
            {

            }

        private void BuscarArticulos(string codigo,string nom)
            {
            var art = _metodos.CriterioBusquedaArticulo(codigo,nom);
            dataGridArticulos.DataSource = art;
            }
         private void BuscarProveedors(string doc,string tel,string nom)
            {
            var art = _metodos.CriterioBusquedaProveedor(doc,tel, nom);
            dataGridProveedor.DataSource = art;
            }
        private void btnArticulos_Click(object sender, EventArgs e)
            {
          
            }

        private void dataGridArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            if (dataGridArticulos.CurrentRow != null)
                {
               
                var codigo = dataGridArticulos.CurrentRow.Cells[0].Value.ToString();
                txtarticulo.Text = dataGridArticulos.CurrentRow.Cells[2].Value.ToString();
                //txtNombre.Text = GridViewEmpleado.CurrentRow.Cells[2].Value.ToString();
       
                }
            }

        private void btnArticulos_Click_1(object sender, EventArgs e)
            {
            BuscarArticulos(txtCbuscAr.Text,txtCbuscAr.Text);
            }

        private void btnProveedor_Click(object sender, EventArgs e)
            {
            BuscarProveedors(txtBucarProveedor.Text, txtBucarProveedor.Text, txtBucarProveedor.Text);
            }

        private void dataGridProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            var codigo = dataGridProveedor.CurrentRow.Cells[0].Value.ToString();
            txtproceedor.Text = dataGridProveedor.CurrentRow.Cells[2].Value.ToString();
            //txtNombre.Text = GridViewEmpleado.CurrentRow.Cells[2].Value.ToString();
            }
        }
    }
