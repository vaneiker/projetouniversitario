namespace SistemaFacturacion.Formularios
{
    partial class CotizacionReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewerCotizacion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CotizacionReport1 = new SistemaFacturacion.Reports.CotizacionReport();
            this.SuspendLayout();
            // 
            // crystalReportViewerCotizacion
            // 
            this.crystalReportViewerCotizacion.ActiveViewIndex = -1;
            this.crystalReportViewerCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerCotizacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerCotizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerCotizacion.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerCotizacion.Name = "crystalReportViewerCotizacion";
            this.crystalReportViewerCotizacion.ReportSource = this.CotizacionReport1;
            this.crystalReportViewerCotizacion.Size = new System.Drawing.Size(783, 440);
            this.crystalReportViewerCotizacion.TabIndex = 0;
            this.crystalReportViewerCotizacion.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // CotizacionReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 440);
            this.Controls.Add(this.crystalReportViewerCotizacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CotizacionReporte";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista de Cotizacion";
            this.Load += new System.EventHandler(this.CotizacionReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerCotizacion;
        private Reports.CotizacionReport CotizacionReport1;
    }
}