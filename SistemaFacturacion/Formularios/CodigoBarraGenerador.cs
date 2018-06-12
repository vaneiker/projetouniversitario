using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CapaLogicaNegocio.NegocioDbVentas;

namespace SistemaFacturacion.Formularios
{
    public partial class CodigoBarraGenerador : Form
    {
        ReportDocument rpt = new ReportDocument();

        public CodigoBarraGenerador()
        {
            InitializeComponent();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs args)
        {
            //Seleccionar Los articulos y traerlos en un datase por el codigo de barra.
        }

        private void btnBuscarTodos_Click(object sender, EventArgs args)
        {
            //buscarlo todos
            LogicaDbVentas db = new LogicaDbVentas();
            DataTable articulos = db.ListaArticulos();
            rpt.SetDataSource(articulos);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void CodigoBarraGenerador_Load(object sender, EventArgs e)
        {
            rpt.Load(System.IO.Path.Combine(Application.StartupPath, "Reports", "BarcodeArticulo.rpt"));
        }
    }
}
