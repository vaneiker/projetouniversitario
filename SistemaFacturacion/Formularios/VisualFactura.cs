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
    public partial class VisualFactura : Form
    {
        private ReportDocument reportDocument = new ReportDocument();
        private int idfactura = 0;

        public VisualFactura(int idfactura)
        {
            InitializeComponent();
            this.idfactura = idfactura;
        }

        private void facturaReportViewer_Load(object sender, EventArgs e)
        {
            if(idfactura <= 0)
            {
                Alertas.AlertError noId = new Alertas.AlertError("No se ha Facilitado ID. Se cerrara el Formulario");
                noId.ShowDialog();
                this.Close();
            }
            reportDocument.Load(FacturaReport1.FileName);
            reportDocument.SetParameterValue("@id_factura", this.idfactura);
            facturaReportViewer.ReportSource = reportDocument;
            
        }
    }
}
