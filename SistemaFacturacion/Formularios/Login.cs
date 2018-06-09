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
          
        int rolid;
        public Login()
            {
            InitializeComponent();
            }

        private void BtnIngerso_Click(object sender, EventArgs e)
            {
            if (txtContrasena.Text == "" || txtContrasena.Text == null || txtUsuario.Text == "" || txtUsuario.Text == null)
                {
                panelErrorClave.Visible = true;
                label5.Text = "Digite usuario y contraseña";
                }
            else
                {
                if (LogicaLogin.ValidateLogin(txtUsuario.Text, Encripatar.Encrypt(txtContrasena.Text), out rolid))
                    {
                    //implementar validacion de role para visualizar el menu pendiente
                    Formularios.MenuPrincipal f = new Formularios.MenuPrincipal();
                    Program.UsuarioActual = ApplicationUser.Instance;
                    Program.UsuarioActual.RolId = rolid;
                    Program.UsuarioActual.UserLoggedIn = txtUsuario.Text;
                    f.Show();
                    }
                else
                    {
                    panelErrorClave.Visible = true;
                    label5.Text = "Usuario y/o contraseña incorrectos";
                    }
                }
            }
        private void btnCancelar_Click(object sender, EventArgs e)
            {
            CleanPantalla();
            }

        private void CleanPantalla()
            {
            txtContrasena.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            panelErrorClave.Visible = false;
            
            }

        private void btnCerrarSeccion_Click(object sender, EventArgs e)
            {
            DialogResult resul = MessageBox.Show("Esta seguro que desea apagar el Sistema?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resul == System.Windows.Forms.DialogResult.OK)
                {
                this.Close();
                }
            }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
            {
            panelErrorClave.Visible = false;
            }
        }
    }