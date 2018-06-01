using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio.NegocioDbVentas;

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
               if(LogicaLogin.ValidateLogin(txtUsuario.Text, txtContrasena.Text, out Program.UsuarioRole))
            {
                //implementar validacion de role para visualizar el menu pendiente
                Formularios.FrmCategoria f = new Formularios.FrmCategoria();
                f.Show();
            }
               
            }
        }
    }
