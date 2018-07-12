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
            this.btnPagar = new System.Windows.Forms.Button();
            this.TabCXC = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.tabCuentaP = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblEst = new System.Windows.Forms.Label();
            this.dateTimePago = new System.Windows.Forms.DateTimePicker();
            this.txtMontoApagar = new System.Windows.Forms.TextBox();
            this.txtTotalAdeu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomC = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCXC)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TabCXC.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabCuentaP.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridViewCXC
            // 
            this.GridViewCXC.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.GridViewCXC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewCXC.GridColor = System.Drawing.Color.White;
            this.GridViewCXC.Location = new System.Drawing.Point(74, 80);
            this.GridViewCXC.Name = "GridViewCXC";
            this.GridViewCXC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewCXC.Size = new System.Drawing.Size(955, 164);
            this.GridViewCXC.TabIndex = 1;
            this.GridViewCXC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewCXC_CellClick);
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
            this.panel1.Controls.Add(this.btnPagar);
            this.panel1.Location = new System.Drawing.Point(1, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1167, 55);
            this.panel1.TabIndex = 127;
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(924, 7);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(157, 35);
            this.btnPagar.TabIndex = 194;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // TabCXC
            // 
            this.TabCXC.Controls.Add(this.tabPage2);
            this.TabCXC.Controls.Add(this.tabCuentaP);
            this.TabCXC.Location = new System.Drawing.Point(1, 105);
            this.TabCXC.Name = "TabCXC";
            this.TabCXC.SelectedIndex = 0;
            this.TabCXC.Size = new System.Drawing.Size(1165, 293);
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
            this.tabPage2.Size = new System.Drawing.Size(1157, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimineto Clientes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label3.Location = new System.Drawing.Point(241, 32);
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
            this.cboTipoDoc.Location = new System.Drawing.Point(477, 29);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(331, 33);
            this.cboTipoDoc.TabIndex = 173;
            this.cboTipoDoc.Text = "Seleccionar Tipo Documento";
            // 
            // tabCuentaP
            // 
            this.tabCuentaP.Controls.Add(this.groupBox3);
            this.tabCuentaP.Location = new System.Drawing.Point(4, 22);
            this.tabCuentaP.Name = "tabCuentaP";
            this.tabCuentaP.Padding = new System.Windows.Forms.Padding(3);
            this.tabCuentaP.Size = new System.Drawing.Size(1157, 267);
            this.tabCuentaP.TabIndex = 2;
            this.tabCuentaP.Text = "Pagos Cuenta Por Cobrar";
            this.tabCuentaP.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.lblEst);
            this.groupBox3.Controls.Add(this.dateTimePago);
            this.groupBox3.Controls.Add(this.txtMontoApagar);
            this.groupBox3.Controls.Add(this.txtTotalAdeu);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtNomC);
            this.groupBox3.Controls.Add(this.txtClient);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtCed);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(156, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(795, 249);
            this.groupBox3.TabIndex = 183;
            this.groupBox3.TabStop = false;
            // 
            // lblEst
            // 
            this.lblEst.AutoSize = true;
            this.lblEst.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblEst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.lblEst.Location = new System.Drawing.Point(277, 19);
            this.lblEst.Name = "lblEst";
            this.lblEst.Size = new System.Drawing.Size(24, 25);
            this.lblEst.TabIndex = 170;
            this.lblEst.Text = "?";
            // 
            // dateTimePago
            // 
            this.dateTimePago.CalendarForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePago.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.dateTimePago.Enabled = false;
            this.dateTimePago.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePago.Location = new System.Drawing.Point(585, 19);
            this.dateTimePago.Name = "dateTimePago";
            this.dateTimePago.Size = new System.Drawing.Size(200, 27);
            this.dateTimePago.TabIndex = 169;
            // 
            // txtMontoApagar
            // 
            this.txtMontoApagar.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtMontoApagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtMontoApagar.Location = new System.Drawing.Point(585, 142);
            this.txtMontoApagar.Multiline = true;
            this.txtMontoApagar.Name = "txtMontoApagar";
            this.txtMontoApagar.Size = new System.Drawing.Size(200, 35);
            this.txtMontoApagar.TabIndex = 168;
            this.txtMontoApagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalAdeu
            // 
            this.txtTotalAdeu.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtTotalAdeu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtTotalAdeu.Location = new System.Drawing.Point(585, 98);
            this.txtTotalAdeu.Multiline = true;
            this.txtTotalAdeu.Name = "txtTotalAdeu";
            this.txtTotalAdeu.ReadOnly = true;
            this.txtTotalAdeu.Size = new System.Drawing.Size(200, 36);
            this.txtTotalAdeu.TabIndex = 167;
            this.txtTotalAdeu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label8.Location = new System.Drawing.Point(417, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 25);
            this.label8.TabIndex = 166;
            this.label8.Text = "Pagar Deuda";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label9.Location = new System.Drawing.Point(393, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 25);
            this.label9.TabIndex = 165;
            this.label9.Text = "Monto Adeudado";
            // 
            // txtNomC
            // 
            this.txtNomC.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtNomC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtNomC.Location = new System.Drawing.Point(211, 200);
            this.txtNomC.Multiline = true;
            this.txtNomC.Name = "txtNomC";
            this.txtNomC.ReadOnly = true;
            this.txtNomC.Size = new System.Drawing.Size(574, 36);
            this.txtNomC.TabIndex = 161;
            this.txtNomC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClient
            // 
            this.txtClient.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtClient.Location = new System.Drawing.Point(211, 148);
            this.txtClient.Multiline = true;
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(179, 35);
            this.txtClient.TabIndex = 162;
            this.txtClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 25);
            this.label1.TabIndex = 160;
            this.label1.Text = "Estado de la Cuenta $:";
            // 
            // txtCed
            // 
            this.txtCed.Enabled = false;
            this.txtCed.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtCed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtCed.Location = new System.Drawing.Point(211, 95);
            this.txtCed.Multiline = true;
            this.txtCed.Name = "txtCed";
            this.txtCed.ReadOnly = true;
            this.txtCed.Size = new System.Drawing.Size(179, 36);
            this.txtCed.TabIndex = 161;
            this.txtCed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label4.Location = new System.Drawing.Point(4, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 25);
            this.label4.TabIndex = 159;
            this.label4.Text = "Nombre Completo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label5.Location = new System.Drawing.Point(43, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 25);
            this.label5.TabIndex = 160;
            this.label5.Text = "Codigo Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label2.Location = new System.Drawing.Point(54, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 159;
            this.label2.Text = "Cedula o RNC";
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
            this.panel1.ResumeLayout(false);
            this.TabCXC.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabCuentaP.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNomC;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePago;
        private System.Windows.Forms.TextBox txtMontoApagar;
        private System.Windows.Forms.TextBox txtTotalAdeu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEst;
        private System.Windows.Forms.Button btnPagar;
    }
    }