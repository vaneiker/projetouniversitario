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
        public FrmCuentasPorCobrarl()
        {
            InitializeComponent();
        }

        private int codigoC { get; set; }
        private string idis { get; set; }
        private int idFactura { get; set; }
        private bool estatus { get; set; }
        private void ClienteCbox()
        {
            // ClienteEntitis p = new ClienteEntitis();
            //var cbo= _metodos.GetClienteCombo();

            // this.CboClientes.DataSource = cbo;
            // this.CboClientes.ValueMember ="NombreCompleto";
            // //this.CboClientes.SelectedIndex = //int.Parse("idcliente");
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

        private void GridViewCXC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridViewCXC.CurrentRow != null)
            {
                

                this.codigoC = Convert.ToInt32(GridViewCXC.CurrentRow.Cells["id_cliente"].Value.ToString());
                txtCedula.Text = GridViewCXC.CurrentRow.Cells["num_documento"].Value.ToString();                
                txtCodigoUnico.Text = GridViewCXC.CurrentRow.Cells["CodigoCliente"].Value.ToString();
                var nom = GridViewCXC.CurrentRow.Cells["NombreCompleto"].Value.ToString();
                txtNomCompleto.Text = "***" + nom + "***";
                txtMontoAdeudado.Text=Convert.ToString(GridViewCXC.CurrentRow.Cells["Deuda_Actual"].Value.ToString());
                this.estatus= GridViewCXC.CurrentRow.Cells[6].Value.ToString() == "TIENE DEUDA" ? true:false;
                lblEst.Text = GridViewCXC.CurrentRow.Cells["Estado"].Value.ToString();        
                this.idFactura =Convert.ToInt32(GridViewCXC.CurrentRow.Cells["id_factura"].Value.ToString());
             

                TabCXC.SelectedTab = TabCXC.TabPages[1];
            }
        }

        private void GridViewCXC_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
          
                decimal montoD ;
            decimal MontoApagar = decimal.Parse(txtMontoApagar.Text);
          

            montoD = decimal.Parse(txtMontoAdeudado.Text);
            MontoApagar = decimal.Parse(txtMontoApagar.Text);

            bool repuesta = _metodos.PagarCuentaCXC(this.codigoC,
                                                    MontoApagar,
                                                    this.estatus,
                                                    seccion.Usuario,
                                                    idFactura);        
        }
    }
}     
          
          
          
       
          
          
          
          
          
          
          

          
          
          
          
          
                                                                                                                                                                                                                               
     
