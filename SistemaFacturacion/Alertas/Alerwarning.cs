using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion.Alertas
{
    public partial class Alerwarning : Form
    {
        public Alerwarning()
        {
            InitializeComponent();
        }

        public Alerwarning(string msg)
        {
            InitializeComponent();
            label1.Text = msg;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
