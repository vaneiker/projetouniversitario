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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtUsuario.Text) && !string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                int rol;
                string name;
                int id;
                LogicaLogin.ValidateLogin(txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), out rol, out name, out id);
                if( rol == 1 || rol == 5)
                {
                    PuedeCancelar = true;
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
