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
        public FrmMantenimientoUsuarios()
        {
            InitializeComponent();
        }
        ComboxBosxTools cbo = new ComboxBosxTools();
        private void FrmMantenimientoUsuarios_Load(object sender, EventArgs e)
        {
            Roll();
        }

        private void Roll()
        {
            var c = cbo.GetRollD();
            cboRoll.DataSource = c;
            cboRoll.DisplayMember = "Nombre";
            cboRoll.ValueMember = "id";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnBusc_Click(object sender, EventArgs e)
        {
            UsersEntitis usuario = new UsersEntitis();
            usuario =  usuario.GetUserByName(txtBuscarUsuario.Text);
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
    }
}
