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

        private void BtnIngerso_Click(object sender, EventArgs e)
            {
            if (txtContrasena.Text == "" || txtContrasena.Text == null || txtUsuario.Text == "" || txtUsuario.Text == null)
                {
<<<<<<< HEAD
                //implementar validacion de role para visualizar el menu pendiente
                Formularios.MenuPrincipal f = new Formularios.MenuPrincipal();
                this.Hide();
                 f.Show();
            }else
            {
                MessageBox.Show("Usuario o Contraseña Estan Incorrectos", "Error Al Logearse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
=======
                panelErrorClave.Visible = true;
                label5.Text = "Digite usuario y contraseña";
                }
            else
                {
                if (LogicaLogin.ValidateLogin(txtUsuario.Text, Encripatar.Encrypt(txtContrasena.Text), out Program.UsuarioRole))
                    {
                    //implementar validacion de role para visualizar el menu pendiente
                    Formularios.MenuPrincipal f = new Formularios.MenuPrincipal();
                    f.Show();
                    }
                else
                    {
                    panelErrorClave.Visible = true;
                    label5.Text = "Usuario y/o contraseña incorrectos";
                    }
                }
>>>>>>> fb20852c4b73f648feebc8a4c3017adc87f90259
            }
        private void btnCancelar_Click(object sender, EventArgs e)
            {
<<<<<<< HEAD
              txtContrasena.Text = string.Empty;
              txtUsuario.Text = string.Empty;
=======
            CleanPantalla();
>>>>>>> fb20852c4b73f648feebc8a4c3017adc87f90259
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

<<<<<<< HEAD
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
=======
        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
            {
            panelErrorClave.Visible = false;
            }
        }
    }
>>>>>>> fb20852c4b73f648feebc8a4c3017adc87f90259
