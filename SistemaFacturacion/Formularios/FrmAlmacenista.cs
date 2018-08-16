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
    public partial class FrmAlmacenista : Form
    {
        Seccion seccion = Seccion.Instance;
        string cargo = "";
        public FrmAlmacenista()
        {
            seccion = Seccion.Instance;
            InitializeComponent();
        }
        Seccion s = Seccion.Instance;
        private void FrmAlmacenista_Load(object sender, EventArgs e)
        {
            cargo = AppTools.LogicRoll.Cargos(seccion.Rolid);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");

            toolStripStatusLabel2.Text = "***Usuario: " + s.Usuario.ToString() + " Cargo : " + cargo;
            lblmp.Text = "Bienvenido Sr(a): " + s.nombreCompleto;
        }
    }
}
