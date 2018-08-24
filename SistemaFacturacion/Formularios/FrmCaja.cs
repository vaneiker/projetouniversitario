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
    public partial class FrmCaja : Form
    {

        Seccion seccion = Seccion.Instance;
        string cargo = "";

        
       
        public FrmCaja()
        {
            seccion = Seccion.Instance;
            InitializeComponent();
        }
           Seccion s = Seccion.Instance;
        private void btnCuadre_Click(object sender, EventArgs e)
        {
            CuadreForm c = new Formularios.CuadreForm();
            c.ShowDialog();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Esta seguro que desea apagar el Sistema?, " + s.Usuario + " " + cargo, "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resul == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void ChangerUser_Click(object sender, EventArgs e)
        {
            Login l = new SistemaFacturacion.Login();
            l.Show();
            this.Close();
        }

        private void btnCxc_Click(object sender, EventArgs e)
        {
            FrmCuentasPorCobrarl cxc = new Formularios.FrmCuentasPorCobrarl();
            cxc.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCotizador cc = new Formularios.FrmCotizador();
            cc.ShowDialog();
        }

        private void BtnFacturacion_Click(object sender, EventArgs e)
        {
            FrmVentas cc = new Formularios.FrmVentas();
            cc.ShowDialog();
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            FrmClientes cl = new Formularios.FrmClientes();
            cl.ShowDialog();
        }
    }
}
