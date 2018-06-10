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
    public partial class MenuPrincipal : Form
        {
        public MenuPrincipal()
            {
            InitializeComponent();
            }

        private void panel3_Paint(object sender, PaintEventArgs e)
            {

            }

        private void Salir_Click(object sender, EventArgs e)
            {
            DialogResult resul = MessageBox.Show("Esta seguro que desea apagar el Sistema?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
                {
                this.Close();
                }
            }

        private void timer1_Tick(object sender, EventArgs e)
            {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");
            }

        private void BtnCategoria_Click(object sender, EventArgs e)
            {
            FrmCategoria f = new Formularios.FrmCategoria();
            //BtnCategoria.Enabled = false;
            f.ShowDialog();
            }

        private void BtnCliente_Click(object sender, EventArgs e)
            {
            FrmClientes cliente = new Formularios.FrmClientes();

            BtnCliente.Enabled = false;
            cliente.Show();
            }

        private void BtnIngreso_Click(object sender, EventArgs e)
            {
            Formularios.FrmIngresos f = new FrmIngresos();
            f.ShowDialog();
            }

        private void BtnArticulos_Click(object sender, EventArgs e)
            {
            FrmArticulos f = new FrmArticulos();
            f.ShowDialog();
            }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            Program.UsuarioActual = ApplicationUser.Instance;
            toolStripStatusLabel2.Text = Program.UsuarioActual.RolId.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
