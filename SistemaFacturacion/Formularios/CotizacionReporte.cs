using CrystalDecisions.CrystalReports.Engine;
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
    public partial class CotizacionReporte : Form
    {
        private ReportDocument reportDocument = new ReportDocument();
        private int _cotizacionId = 0;

        public CotizacionReporte(int cotizacionId)
        {
            InitializeComponent();
            _cotizacionId = cotizacionId;
        }

        private void CotizacionReporte_Load(object sender, EventArgs e)
        {
            if(_cotizacionId <= 0)
            {
                Alertas.AlertError noId = new Alertas.AlertError("No Se Encontro ningun Id de la Cotizacion a Imprimir");
                noId.ShowDialog();
                this.Close();
            }
            //Load report document and set the parameter id to load the report.
            String serverName = AppTools.AppConfiguration.GetServerNameFromConfiguration();
            String databaseName = AppTools.AppConfiguration.GetDatabaseNameFromConfiguration();

            reportDocument.Load(CotizacionReport1.FileName);
            
            reportDocument.DataSourceConnections[0].SetConnection(serverName, databaseName, true);
            reportDocument.SetParameterValue("@id_factura", _cotizacionId);
            reportDocument.SetParameterValue("@id_cotizacion", _cotizacionId);
            crystalReportViewerCotizacion.ReportSource = reportDocument;
        }
    }
}
