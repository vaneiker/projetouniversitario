namespace WindowsFormsApp1
{
    partial class ProcesarCancelaciones
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
            this.TabControCancelar = new System.Windows.Forms.TabControl();
            this.TabControCancelarPorPagos = new System.Windows.Forms.TabPage();
            this.TabControCancelarPorDocument = new System.Windows.Forms.TabPage();
            this.TabControCancelar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControCancelar
            // 
            this.TabControCancelar.Controls.Add(this.TabControCancelarPorPagos);
            this.TabControCancelar.Controls.Add(this.TabControCancelarPorDocument);
            this.TabControCancelar.Location = new System.Drawing.Point(1, 2);
            this.TabControCancelar.Name = "TabControCancelar";
            this.TabControCancelar.SelectedIndex = 0;
            this.TabControCancelar.Size = new System.Drawing.Size(1261, 656);
            this.TabControCancelar.TabIndex = 0;
            // 
            // TabControCancelarPorPagos
            // 
            this.TabControCancelarPorPagos.Location = new System.Drawing.Point(4, 22);
            this.TabControCancelarPorPagos.Name = "TabControCancelarPorPagos";
            this.TabControCancelarPorPagos.Padding = new System.Windows.Forms.Padding(3);
            this.TabControCancelarPorPagos.Size = new System.Drawing.Size(1253, 630);
            this.TabControCancelarPorPagos.TabIndex = 0;
            this.TabControCancelarPorPagos.Text = "Procesar Cancelacion por falta de Pagos";
            this.TabControCancelarPorPagos.UseVisualStyleBackColor = true;
            // 
            // TabControCancelarPorDocument
            // 
            this.TabControCancelarPorDocument.Location = new System.Drawing.Point(4, 22);
            this.TabControCancelarPorDocument.Name = "TabControCancelarPorDocument";
            this.TabControCancelarPorDocument.Padding = new System.Windows.Forms.Padding(3);
            this.TabControCancelarPorDocument.Size = new System.Drawing.Size(1253, 630);
            this.TabControCancelarPorDocument.TabIndex = 1;
            this.TabControCancelarPorDocument.Text = "Procesar Cancelacion por falta de Documentación";
            this.TabControCancelarPorDocument.UseVisualStyleBackColor = true;
            // 
            // ProcesarCancelaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 660);
            this.Controls.Add(this.TabControCancelar);
            this.Name = "ProcesarCancelaciones";
            this.Text = "Form1";
            this.TabControCancelar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControCancelar;
        private System.Windows.Forms.TabPage TabControCancelarPorPagos;
        private System.Windows.Forms.TabPage TabControCancelarPorDocument;
    }
}

