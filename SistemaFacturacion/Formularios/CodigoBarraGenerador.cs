using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio.NegocioDbVentas;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace SistemaFacturacion.Formularios
{
    public partial class CodigoBarraGenerador : Form
    {
        private ReportDocument rpt = new ReportDocument();
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
            LogicaDbVentas db = new LogicaDbVentas();
            DataTable data = db.ListaArticulos();
            rpt.SetDataSource(data);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void CodigoBarraGenerador_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (path.IndexOf(@"\bin\Debug") != -1)
            {
                string rPath = path.Replace(@"bin\Debug", "Reports");
                string reportPath = Path.Combine(rPath, "BarcodeReport.rpt");
                rpt.Load(reportPath);
            }
            else
            {
                rpt.Load(Path.Combine(path, "Reports", "BarcodeReport.rpt"));
            }
        }
    }
}
