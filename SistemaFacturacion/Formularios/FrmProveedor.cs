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
    public partial class FrmProveedor : Form
        {
        public FrmProveedor()
            {
            InitializeComponent();
            }
        ProveedorEntity p = new ProveedorEntity();
        LogicaDbVentas _log = new LogicaDbVentas();
        private void GridViewEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

        private void Aceptar_Click(object sender, EventArgs e)
            {

            }

        private void Registrar_Proveedor()
            {
            
           

            }

        }
    }
