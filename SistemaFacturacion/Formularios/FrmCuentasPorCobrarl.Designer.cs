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
            this.GridViewCXC = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TabCXC = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.tabCuentaP = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCXC)).BeginInit();
            this.panel6.SuspendLayout();
            this.TabCXC.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridViewCXC
            // 
            this.GridViewCXC.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.GridViewCXC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewCXC.GridColor = System.Drawing.Color.White;
            this.GridViewCXC.Location = new System.Drawing.Point(99, 104);
            this.GridViewCXC.Name = "GridViewCXC";
            this.GridViewCXC.Size = new System.Drawing.Size(955, 164);
            this.GridViewCXC.TabIndex = 1;
            this.GridViewCXC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewCXC_CellContentClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(1, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1167, 72);
            this.panel6.TabIndex = 124;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(301, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(471, 58);
            this.label7.TabIndex = 162;
            this.label7.Text = "Cuenta Por Cobrar";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.panel2.Location = new System.Drawing.Point(1, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1167, 26);
            this.panel2.TabIndex = 126;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.panel1.Location = new System.Drawing.Point(1, 453);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1167, 32);
            this.panel1.TabIndex = 127;
            // 
            // TabCXC
            // 
            this.TabCXC.Controls.Add(this.tabPage2);
            this.TabCXC.Controls.Add(this.tabCuentaP);
            this.TabCXC.Location = new System.Drawing.Point(1, 105);
            this.TabCXC.Name = "TabCXC";
            this.TabCXC.SelectedIndex = 0;
            this.TabCXC.Size = new System.Drawing.Size(1165, 327);
            this.TabCXC.TabIndex = 128;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cboTipoDoc);
            this.tabPage2.Controls.Add(this.GridViewCXC);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1157, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimineto Clientes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label3.Location = new System.Drawing.Point(266, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 25);
            this.label3.TabIndex = 174;
            this.label3.Text = "Clientes con Deudas:";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.cboTipoDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(502, 53);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(331, 33);
            this.cboTipoDoc.TabIndex = 173;
            this.cboTipoDoc.Text = "Seleccionar Tipo Documento";
            // 
            // tabCuentaP
            // 
            this.tabCuentaP.Location = new System.Drawing.Point(4, 22);
            this.tabCuentaP.Name = "tabCuentaP";
            this.tabCuentaP.Padding = new System.Windows.Forms.Padding(3);
            this.tabCuentaP.Size = new System.Drawing.Size(1157, 301);
            this.tabCuentaP.TabIndex = 2;
            this.tabCuentaP.Text = "Pagos Cuenta Por Cobrar";
            this.tabCuentaP.UseVisualStyleBackColor = true;
            // 
            // FrmCuentasPorCobrarl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(1168, 484);
            this.Controls.Add(this.TabCXC);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCuentasPorCobrarl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas Por Cobrar";
            this.Load += new System.EventHandler(this.FrmCuentasPorCobrarl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCXC)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.TabCXC.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.DataGridView GridViewCXC;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl TabCXC;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.TabPage tabCuentaP;
    }
    }