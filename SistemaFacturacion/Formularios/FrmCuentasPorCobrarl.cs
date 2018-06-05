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
    public partial class FrmCuentasPorCobrarl : Form
        {

        LogicaDbVentas _metodos = new LogicaDbVentas();
        public FrmCuentasPorCobrarl()
            {
            InitializeComponent();
            }

        private void ClienteCbox()
            {
           // ClienteEntitis p = new ClienteEntitis();
           //var cbo= _metodos.GetClienteCombo();

           // this.CboClientes.DataSource = cbo;
           // this.CboClientes.ValueMember ="NombreCompleto";
           // //this.CboClientes.SelectedIndex = //int.Parse("idcliente");
            }

        private void FrmCuentasPorCobrarl_Load(object sender, EventArgs e)
            {
            ClienteCbox();
            }
        }
    }
