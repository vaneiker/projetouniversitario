namespace SistemaFacturacion.Formularios
    {
    partial class FrmCuentasPorCobrarl
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
            this.CboClientes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CboClientes
            // 
            this.CboClientes.FormattingEnabled = true;
            this.CboClientes.Location = new System.Drawing.Point(66, 82);
            this.CboClientes.Name = "CboClientes";
            this.CboClientes.Size = new System.Drawing.Size(475, 21);
            this.CboClientes.TabIndex = 0;
            // 
            // FrmCuentasPorCobrarl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 261);
            this.Controls.Add(this.CboClientes);
            this.Name = "FrmCuentasPorCobrarl";
            this.Text = "FrmCuentasPorCobrarl";
            this.Load += new System.EventHandler(this.FrmCuentasPorCobrarl_Load);
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.ComboBox CboClientes;
        }
    }