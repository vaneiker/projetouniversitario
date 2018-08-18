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


namespace SistemaFacturacion.Formularios
{
    public partial class CancelForm : Form
    {
        
        public CancelForm()
        {
            InitializeComponent();
        }

        public bool PuedeCancelar { get; set; }

        /// <summary>
        /// Esto es lo que hace la verdadera majia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtUsuario.Text) && !string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                int rol;
                string name;
                int id;
                txtContraseña.Text = AppTools.Encripatar.Encrypt(txtContraseña.Text.Trim());
                LogicaLogin.ValidateLogin(txtUsuario.Text.Trim(), txtContraseña.Text, out rol, out name, out id);
                if( rol == 1 || rol == 5)
                {
                    PuedeCancelar = true;
                    this.Close();
                }else if(rol <= 0)
                {
                    Alertas.AlertError noValido = new Alertas.AlertError("Usuario o Contraseña no Valido..");
                    noValido.ShowDialog();
                    noValido.ShowDialog();
                    PuedeCancelar = false;
                    return;
                }else
                {
                    Alertas.Alerwarning sinPrivilegio = new Alertas.Alerwarning("El Usuario Digitado No Tiene Privilegios Para Eliminar");
                    sinPrivilegio.ShowDialog();
                    PuedeCancelar = false;
                    return; 
                }
            }
            else
            {
                Alertas.AlertError noVacio = new Alertas.AlertError("Asegurese de Entrar Usuario y Contraseña");
                noVacio.ShowDialog();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
