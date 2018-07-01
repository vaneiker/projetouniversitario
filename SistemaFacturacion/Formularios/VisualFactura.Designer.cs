namespace SistemaFacturacion.Formularios
{
    partial class VisualFactura
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
            this.facturaReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.FacturaReport1 = new SistemaFacturacion.Reports.FacturaReport();
            this.SuspendLayout();
            // 
            // facturaReportViewer
            // 
            this.facturaReportViewer.ActiveViewIndex = -1;
            this.facturaReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.facturaReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.facturaReportViewer.DisplayToolbar = true;
            this.facturaReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.facturaReportViewer.Location = new System.Drawing.Point(0, 0);
            this.facturaReportViewer.Name = "facturaReportViewer";
            this.facturaReportViewer.ReportSource = this.FacturaReport1;
            this.facturaReportViewer.Size = new System.Drawing.Size(881, 503);
            this.facturaReportViewer.TabIndex = 0;
            this.facturaReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.facturaReportViewer.Load += new System.EventHandler(this.facturaReportViewer_Load);
            // 
            // VisualFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 503);
            this.Controls.Add(this.facturaReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisualFactura";
            this.Text = "Visualizacion de Facturas";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer facturaReportViewer;
        private Reports.FacturaReport FacturaReport1;
    }
}