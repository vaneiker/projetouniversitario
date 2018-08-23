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
            this.SuspendLayout();
            // 
            // facturaReportViewer
            // 
            this.facturaReportViewer.ActiveViewIndex = -1;
            this.facturaReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.facturaReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.facturaReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.facturaReportViewer.Location = new System.Drawing.Point(0, 0);
            this.facturaReportViewer.Name = "facturaReportViewer";
            this.facturaReportViewer.Size = new System.Drawing.Size(789, 429);
            this.facturaReportViewer.TabIndex = 0;
            this.facturaReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // VisualFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 429);
            this.Controls.Add(this.facturaReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VisualFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisualFactura";
            this.Load += new System.EventHandler(this.VisualFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer facturaReportViewer;
        private Reports.FacturaReport FacturaReport;
 
    }
}