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
        int rollid;
        public Login()
            {
            InitializeComponent();
            }
       
        private void BtnIngerso_Click(object sender, EventArgs e)
            {
            string NomC;
            int idTrabajador;

            if (txtContrasena.Text == "" || txtContrasena.Text == null || txtUsuario.Text == "" || txtUsuario.Text == null)
                {
                  panelErrorClave.Visible = true;
                  label5.Text = "Digite usuario y contraseña";
                txtUsuario.Focus();
                }
            else
                {
                if (LogicaLogin.ValidateLogin(txtUsuario.Text, Encripatar.Encrypt(txtContrasena.Text), out rollid,out NomC, out idTrabajador))
                    {

                    if (rollid <= 0)
                    {
                        panelErrorClave.Visible = true;
                        label5.Text = "Usuario y/o contraseña incorrectos";
                    }
                    else
                    {
                        //implementar validacion de role para visualizar el menu pendiente
                        Seccion seccion = Seccion.Instance;
                        seccion.Usuario = txtUsuario.Text;
                        seccion.Rolid = (LogicRoll.LevelRol)rollid;
                        seccion.nombreCompleto = NomC;
                        seccion.IdTrabajador = idTrabajador;


                        if (rollid == 1 || rollid == 7)
                        {
                            Formularios.MenuPrincipal men = new Formularios.MenuPrincipal();
                            this.Hide();
                            men.Show();
                        }
                        else if (rollid == 2 || rollid == 4)
                        {
                            Formularios.FrmAlmacenista al = new Formularios.FrmAlmacenista();
                            this.Hide();
                            al.Show();

                        }
                        else if (rollid == 3 || rollid == 5)
                        {
                            Formularios.FrmCaja c = new Formularios.FrmCaja();
                            this.Hide();
                            c.Show();
                        }
                        else if (rollid == 6)
                        {
                            Formularios.FrmRhh r1 = new Formularios.FrmRhh();
                            this.Hide();
                            r1.Show();
                        }

                    }
                }                 
                else
                    {
                      panelErrorClave.Visible = true;
                      label5.Text = "Usuario y/o contraseña incorrectos";
                    txtUsuario.Focus();
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
            if(panelErrorClave.Visible==true) { panelErrorClave.Visible = false;}
            }
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (panelErrorClave.Visible == true) { panelErrorClave.Visible = false; }
            }
        }
    }