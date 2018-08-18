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
    public partial class FrmCuentasPorCobrarl : Form
        {

        LogicaDbVentas _metodos = new LogicaDbVentas();
        Seccion seccion = Seccion.Instance;
        private int idCxc { get; set; }
        private int idFactura { get; set; }
        private int idCliente { get; set; }
        private bool est { get; set; }
        

        public FrmCuentasPorCobrarl()
            {
            InitializeComponent();
            }

        

        private void FrmCuentasPorCobrarl_Load(object sender, EventArgs e)
            {
            ListadoClienteCXC();
            }

        private void ListadoClienteCXC()
        {
            var cxc_ = _metodos.ListadoCxC();
            GridViewCXC.DataSource = cxc_;
            //GridViewCXC
        }
        /// <summary>
        /// Esto Carga los Campos para ser modificado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewCXC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewCXC.CurrentRow != null)
            {
                TabCXC.SelectedTab = TabCXC.TabPages[1];

                this.idCxc = int.Parse(GridViewCXC.CurrentRow.Cells[0].Value.ToString());
                this.idCliente = int.Parse(GridViewCXC.CurrentRow.Cells[1].Value.ToString());          
                this.idFactura = int.Parse(GridViewCXC.CurrentRow.Cells[7].Value.ToString());
                txtNom.Text = GridViewCXC.CurrentRow.Cells[4].Value.ToString();
                txtCedula.Text = GridViewCXC.CurrentRow.Cells[2].Value.ToString();
                txtCodigoCliente.Text = GridViewCXC.CurrentRow.Cells[3].Value.ToString();
                txtFactura.Text = GridViewCXC.CurrentRow.Cells[7].Value.ToString();
                txtDeudaActul.Text= GridViewCXC.CurrentRow.Cells[5].Value.ToString();
                blbStado.Text = GridViewCXC.CurrentRow.Cells[6].Value.ToString();
                blbStado.Visible = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;


            }
        }

        private void BtnIngerso_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(txtPagoDeuda.Text))
            {
                MessageBox.Show("Digite La Cantidad A Pagar Por Favor!");
                return;

            }

            decimal deuda = decimal.Parse(txtDeudaActul.Text);
            decimal deudaP = decimal.Parse(txtPagoDeuda.Text);
            if (deuda<deudaP)

            {
                MessageBox.Show("La Cantidad Digitada es Mayor a la Adeudada!");
                return;

            }
            MetodoPagar();
        }

        private void MetodoPagar()
        {

            if (blbStado.Text== "TIENE DEUDA")
            {
                est = false;
            }
            var repuesta = _metodos.PagarCuentaCxc(this.idCxc,this.idCliente,
                                                   this.idFactura,Convert.ToDateTime(dateTimePago.Text),
                                                   decimal.Parse(txtDeudaActul.Text),this.est,seccion.nombreCompleto,
                                                   decimal.Parse(txtPagoDeuda.Text),this.est);
            if (repuesta == true)
            {
                
                ClearCampo();
                ListadoClienteCXC();
            }
            else
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ClearCampo()
        {
            TabCXC.SelectedTab = TabCXC.TabPages[0];
            txtNom.Text = string.Empty;
            txtCodigoCliente.Text = string.Empty;
            txtDeudaActul.Text = string.Empty;
            txtPagoDeuda.Text = string.Empty;
            txtCedula.Text = string.Empty;
            blbStado.Visible = false;
            txtFactura.Text = string.Empty;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = _metodos.BuscarCxC(txtBuscar.Text, txtBuscar.Text, txtBuscar.Text);
            GridViewCXC.DataSource = c;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearCampo();
        }
    }
    }


