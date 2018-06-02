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
        }
    }
