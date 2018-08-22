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

        Seccion seccion = Seccion.Instance;
        string cargo = "";

        public MenuPrincipal()
            {
            seccion = Seccion.Instance;
            InitializeComponent();
            }
        Seccion s = Seccion.Instance;
        private void MenuPrincipal_Load(object sender, EventArgs e)
            {
                 cargo = AppTools.LogicRoll.Cargos(seccion.Rolid);
            }
        private void panel3_Paint(object sender, PaintEventArgs e)
            {

            }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

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

        private void timer1_Tick(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");

            toolStripStatusLabel2.Text="***Usuario: "+s.Usuario.ToString()+" Cargo : " + cargo;
            lblmp.Text = "Bienvenido Sr(a): "+s.nombreCompleto;

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
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmMantenimientoUsuarios m = new Formularios.FrmMantenimientoUsuarios();
            m.ShowDialog();
        }
        private void BtnFacturacion_Click(object sender, EventArgs e)
        {
            Formularios.FrmVentas v = new FrmVentas();
            v.ShowDialog();
        }
        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            FrmTrabajador t = new FrmTrabajador();
            t.ShowDialog();

        }
        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            FrmProveedor pr = new FrmProveedor();
            pr.ShowDialog();
        }
        private void ChangerUser_Click(object sender, EventArgs e)
        {
            Login l = new SistemaFacturacion.Login();
            l.Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmCotizador c = new Formularios.FrmCotizador();
            c.ShowDialog();
        }
        private void btnCxc_Click(object sender, EventArgs e)
        {
            FrmCuentasPorCobrarl cxc = new FrmCuentasPorCobrarl();
            cxc.ShowDialog();
        }

        private void btnCuadre_Click(object sender, EventArgs e)
        {

            Formularios.CuadreForm cf = new Formularios.CuadreForm();
            cf.ShowDialog();
        }
    }
    }
  
