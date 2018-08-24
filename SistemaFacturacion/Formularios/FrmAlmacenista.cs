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
    public partial class FrmAlmacenista : Form
    {
        Seccion seccion = Seccion.Instance;
        string cargo = "";
        public FrmAlmacenista()
        {
            seccion = Seccion.Instance;
            InitializeComponent();
        }
        Seccion s = Seccion.Instance;
        private void FrmAlmacenista_Load(object sender, EventArgs e)
        {
            cargo = AppTools.LogicRoll.Cargos(seccion.Rolid);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");

            toolStripStatusLabel2.Text = "***Usuario: " + s.Usuario.ToString() + " Cargo : " + cargo;
            lblmp.Text = "Bienvenido Sr(a): " + s.nombreCompleto;
        }

        private void BtnArticulos_Click(object sender, EventArgs e)
        {
            FrmArticulos ar = new FrmArticulos();
            ar.ShowDialog();
        }

        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria C = new FrmCategoria();
            C.ShowDialog();
        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            FrmProveedor p = new FrmProveedor();
            p.ShowDialog();
        }

        private void ChangerUser_Click(object sender, EventArgs e)
        {
            Login l = new SistemaFacturacion.Login();
            l.Show();
            this.Close();
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
    }
}
