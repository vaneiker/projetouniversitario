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
    public partial class FrmRhh : Form
    {
        

        Seccion seccion = Seccion.Instance;
        string cargo = "";

        public FrmRhh()
        {
            seccion = Seccion.Instance;
            InitializeComponent();
        }
        Seccion s = Seccion.Instance;

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            FrmTrabajador t = new Formularios.FrmTrabajador();
            t.ShowDialog();
        }

        private void ChangerUser_Click(object sender, EventArgs e)
        {
            Login l = new SistemaFacturacion.Login();
            l.Show();
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmMantenimientoUsuarios u = new FrmMantenimientoUsuarios();
            u.ShowDialog();
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
