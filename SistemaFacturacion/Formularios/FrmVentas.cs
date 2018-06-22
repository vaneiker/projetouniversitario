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
    public partial class FrmVentas : Form
        {
        public FrmVentas()
            {
            InitializeComponent();
            }
        ComboxBosxTools cbo = new ComboxBosxTools();
        LogicaDbVentas clien = new LogicaDbVentas();
    


         private void FrmVentas_Load(object sender, EventArgs e)
        {
            cargarTipoF();
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
            if (comboBox2.SelectedItem.ToString() == "Cliente Exisentes")
            {
                radioBuscApellido.Visible = true;
                radioBusNombre.Visible = true;
                radioBuscCodigo.Visible = true;
                radioBuscTelefono.Visible = true;
                lblBus.Visible = true;
                btnBusc.Visible = true;
                txtB.Visible = true;
                groupBox2.Visible = false;
            }
            else
            {
                MessageBox.Show("Desea cambiar A venta Directa?");
                radioBuscApellido.Visible = false;
                radioBusNombre.Visible = false;
                radioBuscCodigo.Visible = false;
                radioBuscTelefono.Visible = false;
                lblBus.Visible = false;
                btnBusc.Visible = false;
                txtB.Visible = false;
            }
        }

        private void groupBox1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_EnabledChanged(object sender, EventArgs e)
        {
            radioBuscApellido.Visible = true;
            radioBusNombre.Visible = true;
            radioBuscCodigo.Visible = true;
            radioBuscTelefono.Visible = true;
            lblBus.Visible = true;
            btnBusc.Visible = true;
            txtB.Visible = true;
            groupBox2.Visible = true;
        }

        private void btnBusc_Click(object sender, EventArgs e)
        {
            if(txtB.Text=="" || txtB.Text==null)
            {
                Alertas.AlertError err = new Alertas.AlertError();
                err.ShowDialog();
                return;
            }
            else
            {
                string a, b, c, d;
                a = txtB.Text.Trim();
                b = txtB.Text.Trim();
                c = txtB.Text.Trim();
                d = txtB.Text.Trim();

                var cliente = clien.BuscarCliente(a, b, c, d);
                if (cliente.Rows.Count > 0)
                {
                    DataGrivCliente.DataSource = cliente;
                    groupBox2.Visible = true;

                }
                else
                {
                    MessageBox.Show("No existe Data");
                    groupBox2.Visible = false;
                }
            }
          

           
        }
    }
 }   


