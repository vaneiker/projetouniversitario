namespace WinReAssignNCF
{
    partial class frmDetalle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalle));
            this.dgvListaDocumentos = new System.Windows.Forms.DataGridView();
            this.Poliza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorItbis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAsignarNCF = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNCF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPoliza = new System.Windows.Forms.TextBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblProceso = new System.Windows.Forms.Label();
            this.chkSeleccionados = new System.Windows.Forms.CheckBox();
            this.Progreso = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDocumentos)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListaDocumentos
            // 
            this.dgvListaDocumentos.AllowUserToAddRows = false;
            this.dgvListaDocumentos.AllowUserToDeleteRows = false;
            this.dgvListaDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Poliza,
            this.TipoDocumento,
            this.Factura,
            this.Valor,
            this.ValorItbis,
            this.NCF,
            this.Check});
            this.dgvListaDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaDocumentos.Location = new System.Drawing.Point(0, 0);
            this.dgvListaDocumentos.Name = "dgvListaDocumentos";
            this.dgvListaDocumentos.Size = new System.Drawing.Size(916, 482);
            this.dgvListaDocumentos.TabIndex = 0;
            // 
            // Poliza
            // 
            this.Poliza.DataPropertyName = "Poliza";
            this.Poliza.Frozen = true;
            this.Poliza.HeaderText = "Poliza";
            this.Poliza.MaxInputLength = 50;
            this.Poliza.Name = "Poliza";
            this.Poliza.Width = 120;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.DataPropertyName = "TipoDocumento";
            this.TipoDocumento.Frozen = true;
            this.TipoDocumento.HeaderText = "Tipo Documento";
            this.TipoDocumento.MaxInputLength = 1;
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.Width = 120;
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "FacturaAnterior";
            this.Factura.Frozen = true;
            this.Factura.HeaderText = "Factura";
            this.Factura.MaxInputLength = 50;
            this.Factura.Name = "Factura";
            this.Factura.Width = 120;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.Frozen = true;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // ValorItbis
            // 
            this.ValorItbis.DataPropertyName = "ValorItbis";
            this.ValorItbis.Frozen = true;
            this.ValorItbis.HeaderText = "Valor ITBIS";
            this.ValorItbis.Name = "ValorItbis";
            // 
            // NCF
            // 
            this.NCF.DataPropertyName = "NCF";
            this.NCF.Frozen = true;
            this.NCF.HeaderText = "NCF";
            this.NCF.Name = "NCF";
            this.NCF.Width = 140;
            // 
            // Check
            // 
            this.Check.FalseValue = "false";
            this.Check.Frozen = true;
            this.Check.HeaderText = "Select";
            this.Check.Name = "Check";
            this.Check.TrueValue = "true";
            this.Check.Width = 60;
            // 
            // btnAsignarNCF
            // 
            this.btnAsignarNCF.Image = ((System.Drawing.Image)(resources.GetObject("btnAsignarNCF.Image")));
            this.btnAsignarNCF.Location = new System.Drawing.Point(790, 8);
            this.btnAsignarNCF.Name = "btnAsignarNCF";
            this.btnAsignarNCF.Size = new System.Drawing.Size(56, 57);
            this.btnAsignarNCF.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAsignarNCF, "Procesar");
            this.btnAsignarNCF.UseVisualStyleBackColor = true;
            this.btnAsignarNCF.Click += new System.EventHandler(this.btnAsignarNCF_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "NCF:";
            // 
            // txtNCF
            // 
            this.txtNCF.Location = new System.Drawing.Point(58, 43);
            this.txtNCF.Name = "txtNCF";
            this.txtNCF.Size = new System.Drawing.Size(150, 20);
            this.txtNCF.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Poliza:";
            // 
            // txtPoliza
            // 
            this.txtPoliza.Location = new System.Drawing.Point(58, 17);
            this.txtPoliza.Name = "txtPoliza";
            this.txtPoliza.Size = new System.Drawing.Size(150, 20);
            this.txtPoliza.TabIndex = 3;
            this.txtPoliza.Validated += new System.EventHandler(this.txtDocumentNo_Validated);
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(221, 52);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(89, 13);
            this.lblTipoDocumento.TabIndex = 1;
            this.lblTipoDocumento.Text = "Tipo Documento:";
            this.lblTipoDocumento.Visible = false;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Items.AddRange(new object[] {
            ""});
            this.cbTipoDocumento.Location = new System.Drawing.Point(316, 44);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(150, 21);
            this.cbTipoDocumento.TabIndex = 0;
            this.cbTipoDocumento.Visible = false;
            this.cbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cbTipoDocumento_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvListaDocumentos);
            this.panel2.Location = new System.Drawing.Point(2, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 482);
            this.panel2.TabIndex = 1;
            // 
            // btnConfig
            // 
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Location = new System.Drawing.Point(731, 8);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(56, 57);
            this.btnConfig.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnConfig, "Configuración");
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Image = ((System.Drawing.Image)(resources.GetObject("btnCSV.Image")));
            this.btnCSV.Location = new System.Drawing.Point(609, 8);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(58, 57);
            this.btnCSV.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnCSV, "Cargar CSV");
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(849, 8);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(56, 57);
            this.btnSalir.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnSalir, "Salir");
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnDescargar
            // 
            this.btnDescargar.Image = ((System.Drawing.Image)(resources.GetObject("btnDescargar.Image")));
            this.btnDescargar.Location = new System.Drawing.Point(670, 8);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(58, 57);
            this.btnDescargar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnDescargar, "Descargar CSV");
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMenu.Controls.Add(this.lblProceso);
            this.pnlMenu.Controls.Add(this.chkSeleccionados);
            this.pnlMenu.Controls.Add(this.Progreso);
            this.pnlMenu.Controls.Add(this.btnDescargar);
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.lblTipoDocumento);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.cbTipoDocumento);
            this.pnlMenu.Controls.Add(this.btnConfig);
            this.pnlMenu.Controls.Add(this.txtNCF);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Controls.Add(this.btnAsignarNCF);
            this.pnlMenu.Controls.Add(this.txtPoliza);
            this.pnlMenu.Controls.Add(this.btnCSV);
            this.pnlMenu.Location = new System.Drawing.Point(-6, -2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(933, 72);
            this.pnlMenu.TabIndex = 2;
            // 
            // lblProceso
            // 
            this.lblProceso.AutoSize = true;
            this.lblProceso.BackColor = System.Drawing.Color.Transparent;
            this.lblProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProceso.ForeColor = System.Drawing.Color.Black;
            this.lblProceso.Location = new System.Drawing.Point(213, 4);
            this.lblProceso.Name = "lblProceso";
            this.lblProceso.Size = new System.Drawing.Size(16, 13);
            this.lblProceso.TabIndex = 4;
            this.lblProceso.Text = "...";
            this.lblProceso.Visible = false;
            // 
            // chkSeleccionados
            // 
            this.chkSeleccionados.AutoSize = true;
            this.chkSeleccionados.Location = new System.Drawing.Point(224, 48);
            this.chkSeleccionados.Name = "chkSeleccionados";
            this.chkSeleccionados.Size = new System.Drawing.Size(142, 17);
            this.chkSeleccionados.TabIndex = 10;
            this.chkSeleccionados.Text = "Ver Solo Seleccionados.";
            this.chkSeleccionados.UseVisualStyleBackColor = true;
            this.chkSeleccionados.CheckedChanged += new System.EventHandler(this.chkSeleccionados_CheckedChanged);
            // 
            // Progreso
            // 
            this.Progreso.Location = new System.Drawing.Point(214, 18);
            this.Progreso.Name = "Progreso";
            this.Progreso.Size = new System.Drawing.Size(252, 20);
            this.Progreso.TabIndex = 3;
            this.Progreso.Visible = false;
            // 
            // frmDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 554);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDetalle";
            this.Text = "Asignar Nuevo Número Factura y NCF.";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDocumentos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.Button btnAsignarNCF;
        private System.Windows.Forms.DataGridView dgvListaDocumentos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNCF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPoliza;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorItbis;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox chkSeleccionados;
        private System.Windows.Forms.ProgressBar Progreso;
        private System.Windows.Forms.Label lblProceso;
    }
}