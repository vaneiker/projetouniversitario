using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion
    {
    public partial class Login : Form
        {
        public Login()
            {
            InitializeComponent();
            }

        private void btnIngresar_Click(object sender, EventArgs e)
            {
            Formularios.FrmCategoria f = new Formularios.FrmCategoria();
            f.Show();
            }
        }
    }
