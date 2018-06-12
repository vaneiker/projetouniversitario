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
    public partial class MenuPrincipal : Form
        {
<<<<<<< HEAD
        private static Seccion seccion;
        string cargo = "";
||||||| merged common ancestors
=======
        Seccion seccion = Seccion.Instance;
        string cargo = "";
>>>>>>> 44bde7d306b36df2c5891f132919aa71a9555ce9
        public MenuPrincipal()
            {
            seccion = Seccion.Instance;
            InitializeComponent();
            }
<<<<<<< HEAD
        private void MenuPrincipal_Load(object sender, EventArgs e)
            {
                
              cargo = AppTools.LogicRoll.Cargos(seccion.Rolid);
            }
||||||| merged common ancestors

=======
        Seccion s = Seccion.Instance;
        private void MenuPrincipal_Load(object sender, EventArgs e)
            {
                 cargo = AppTools.LogicRoll.Cargos(seccion.Rolid);
            }
>>>>>>> 44bde7d306b36df2c5891f132919aa71a9555ce9
        private void panel3_Paint(object sender, PaintEventArgs e)
            {

            }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Salir_Click(object sender, EventArgs e)
            {
<<<<<<< HEAD
            
            DialogResult resul = MessageBox.Show("Esta seguro que desea apagar el Sistema?, " + seccion.Usuario + " " + cargo, "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
||||||| merged common ancestors
            DialogResult resul = MessageBox.Show("Esta seguro que desea apagar el Sistema?", "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
=======
            
            DialogResult resul = MessageBox.Show("Esta seguro que desea apagar el Sistema?, " + s.Usuario + " " + cargo, "Mensage de Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
>>>>>>> 44bde7d306b36df2c5891f132919aa71a9555ce9
            if (resul == System.Windows.Forms.DialogResult.OK)
                {
                this.Close();
                }
            }

        private void timer1_Tick(object sender, EventArgs e)
            {

            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");
<<<<<<< HEAD
            toolStripStatusLabel2.Text="***Usuario: "+ seccion.Usuario.ToString()+" Cargo : " + cargo;
||||||| merged common ancestors
=======
            toolStripStatusLabel2.Text="***Usuario: "+s.Usuario.ToString()+" Cargo : " + cargo;
>>>>>>> 44bde7d306b36df2c5891f132919aa71a9555ce9
            }

        private void BtnCategoria_Click(object sender, EventArgs e)
            {
            FrmCategoria f = new Formularios.FrmCategoria();
            f.ShowDialog();
            }

        private void BtnCliente_Click(object sender, EventArgs e)
            {
            FrmClientes cliente = new Formularios.FrmClientes();

            cliente.ShowDialog();
            }

        private void BtnIngreso_Click(object sender, EventArgs e)
            {
            Formularios.FrmIngresos f = new FrmIngresos();
            f.ShowDialog();
            }

        private void BtnArticulos_Click(object sender, EventArgs e)
            {
            FrmArticulos f = new FrmArticulos();
            f.ShowDialog();
            }
<<<<<<< HEAD


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

||||||| merged common ancestors
=======

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
            {

            }
>>>>>>> 44bde7d306b36df2c5891f132919aa71a9555ce9
        }
    }
    }
