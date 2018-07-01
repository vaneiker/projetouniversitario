using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad.DbVentas;
using CapaLogicaNegocio.NegocioDbVentas;

namespace SistemaFacturacion.Formularios
{
    public partial class FrmMantenimientoUsuarios : Form
    {
        UsersEntitis selectedUser;
        Alertas.AlertSuccess sucess = new Alertas.AlertSuccess();
        public FrmMantenimientoUsuarios()
        {
            InitializeComponent();
        }
        ComboxBosxTools cbo = new ComboxBosxTools();
        private void FrmMantenimientoUsuarios_Load(object sender, EventArgs e)
        {
            Roll();
            Trabajador();
        }

        private void Roll()
        {
            var c = cbo.GetRollD();
            cboRoll.DataSource = c;
            cboRoll.DisplayMember = "Nombre";
            cboRoll.ValueMember = "id";
        }

        private void Trabajador()
        {
            var c = cbo.GetRollD();
            cboRoll.DataSource = c;
            cboRoll.DisplayMember = "NombreCom";
            cboRoll.ValueMember = "idtrabajador";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnBusc_Click(object sender, EventArgs e)
        {
            UsersEntitis usuario = new UsersEntitis();
            usuario =  usuario.GetUserByName(txtBuscarUsuario.Text.Trim());
            if(usuario == null)
            {
                MessageBox.Show("Usuario no Fue Encontrado Intente de nuevo..");
                txtBuscarUsuario.Text = string.Empty;
                txtBuscarUsuario.Focus();
                return;
            }
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("id");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Status");

            DataRow fila = dt.NewRow();
            fila["id"] = usuario.id.ToString();
            fila["Usuario"] = usuario.Usuario;
            fila["Status"] = (usuario.Statud == true) ? "Activo" : "Inactivo";

            dt.Rows.Add(fila);
            GridViewUsuarios.DataSource = dt;
        }

        private void btnCerrarSeccion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsersEntitis user = new UsersEntitis();
            string usuario = GridViewUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
            selectedUser = user.GetUserByName(usuario);
            txtUsuario.Text = selectedUser.Usuario;
            cboRoll.SelectedIndex = selectedUser.RolID;
            TabArticulo.SelectedTab = TabArticulo.TabPages[1];
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnIngerso_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Asegurese de Entrar el usuario y la contraseña");
                return;
            }

            if(!txtContrasena.Text.Equals(txtRepClave.Text))
            {
                MessageBox.Show("Las Contraseñas No Coinciden");
                txtRepClave.Focus();
                return;
            }

            if(cboRoll.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el Role del Usuario");
                cboRoll.Focus();
                return;
            }

            UsersEntitis nuevoUsuario = new UsersEntitis();
            if(selectedUser != null)
            {
                txtContrasena.Text = AppTools.Encripatar.Encrypt(txtContrasena.Text);
                nuevoUsuario = selectedUser.RegistrarUsuario(txtUsuario.Text.Trim(), txtContrasena.Text, Convert.ToInt32(cboRoll.SelectedValue), selectedUser.Statud.Value, selectedUser.id);
                sucess.ShowDialog();
                txtUsuario.Text = string.Empty;
                txtContrasena.Text = string.Empty;
                txtRepClave.Text = string.Empty;
                cboRoll.SelectedIndex = 0;
                txtUsuario.Focus();
            }
            else
            {
                txtContrasena.Text = AppTools.Encripatar.Encrypt(txtContrasena.Text);
                nuevoUsuario = nuevoUsuario.RegistrarUsuario(txtUsuario.Text.Trim(), txtContrasena.Text, Convert.ToInt32(cboRoll.SelectedValue), true);
                sucess.ShowDialog();
                txtUsuario.Text = string.Empty;
                txtContrasena.Text = string.Empty;
                txtRepClave.Text = string.Empty;
                cboRoll.SelectedIndex = 0;
                txtUsuario.Focus();
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            TabArticulo.SelectedTab = TabArticulo.TabPages[1];
        }
    }
}
