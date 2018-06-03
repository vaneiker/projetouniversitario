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
using SistemaFacturacion.AppTools;

namespace SistemaFacturacion
    {
    public partial class Login : Form
        {
        public Login()
            {
            InitializeComponent();
            }

<<<<<<< HEAD
=======
        private void btnIngresar_Click(object sender, EventArgs e)
            {
         

            }

        private void button1_Click(object sender, EventArgs e)
            {

            }

        private void button1_Click_1(object sender, EventArgs e)
            {

            if (LogicaLogin.ValidateLogin(txtUsuario.Text, Encripatar.Encrypt(txtContrasena.Text), out Program.UsuarioRole))
                {
                //implementar validacion de role para visualizar el menu pendiente
                Formularios.MenuPrincipal f = new Formularios.MenuPrincipal();
                f.Show();
                }
            }

>>>>>>> 9cc78b48729cf9c3fccb5c6e4dff1b344f58b45e
        private void button2_Click(object sender, EventArgs e)
            {
              txtContrasena.Text = string.Empty;
              txtUsuario.Text = string.Empty;
            }

        private void button1_Click_2(object sender, EventArgs e)
            {
          
            }

        private void button3_Click(object sender, EventArgs e)
            {
            DialogResult resul = MessageBox.Show("Esta seguro que desea apagar el Sistema?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
                {
                this.Close();
                }
            }

        private void BtnIngerso_Click(object sender, EventArgs e)
        {
            if (LogicaLogin.ValidateLogin(txtUsuario.Text, txtContrasena.Text, out Program.UsuarioRole))
            {
                //implementar validacion de role para visualizar el menu pendiente
                Formularios.MenuPrincipal f = new Formularios.MenuPrincipal();
                //Dar Visualizacion segun Role
                AppTools.Visibilidad.MenuPrincipal(Program.UsuarioRole, f);
                f.Show();
            }
        }
    }
    }
