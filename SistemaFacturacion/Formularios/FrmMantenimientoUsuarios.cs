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
    }
}
