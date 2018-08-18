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
            this.tabCuentaP = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.BtnIngerso = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtPagoDeuda = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePago = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeudaActul = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.blbStado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCXC)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TabCXC.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabCuentaP.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridViewCXC
            // 
            this.GridViewCXC.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.GridViewCXC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewCXC.GridColor = System.Drawing.Color.White;
            this.GridViewCXC.Location = new System.Drawing.Point(99, 110);
            this.GridViewCXC.Name = "GridViewCXC";
            this.GridViewCXC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            this.panel2.Controls.Add(this.blbStado);
            this.panel2.Location = new System.Drawing.Point(1, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1167, 38);
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
            this.tabPage2.Controls.Add(this.btnBuscar);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtBuscar);
            this.tabPage2.Controls.Add(this.GridViewCXC);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1157, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimineto Clientes:";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabCuentaP
            // 
            this.tabCuentaP.Controls.Add(this.groupBox2);
            this.tabCuentaP.Controls.Add(this.groupBox1);
            this.tabCuentaP.Location = new System.Drawing.Point(4, 22);
            this.tabCuentaP.Name = "tabCuentaP";
            this.tabCuentaP.Padding = new System.Windows.Forms.Padding(3);
            this.tabCuentaP.Size = new System.Drawing.Size(1157, 301);
            this.tabCuentaP.TabIndex = 2;
            this.tabCuentaP.Text = "Pagos Cuenta Por Cobrar";
            this.tabCuentaP.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.BtnIngerso);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(72, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(986, 68);
            this.groupBox2.TabIndex = 204;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Lucida Sans", 15F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(359, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(135, 47);
            this.btnCancelar.TabIndex = 47;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnIngerso
            // 
            this.BtnIngerso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.BtnIngerso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIngerso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.BtnIngerso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnIngerso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIngerso.Font = new System.Drawing.Font("Lucida Sans", 15F);
            this.BtnIngerso.ForeColor = System.Drawing.Color.White;
            this.BtnIngerso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIngerso.Location = new System.Drawing.Point(493, 11);
            this.BtnIngerso.Name = "BtnIngerso";
            this.BtnIngerso.Size = new System.Drawing.Size(154, 47);
            this.BtnIngerso.TabIndex = 46;
            this.BtnIngerso.Text = "Pagar";
            this.BtnIngerso.UseVisualStyleBackColor = false;
            this.BtnIngerso.Click += new System.EventHandler(this.BtnIngerso_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCedula);
            this.groupBox1.Controls.Add(this.txtPagoDeuda);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCodigoCliente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFactura);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePago);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDeudaActul);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNom);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(72, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 217);
            this.groupBox1.TabIndex = 203;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label9.Location = new System.Drawing.Point(48, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 25);
            this.label9.TabIndex = 211;
            this.label9.Text = "Cedula Cliente:";
            // 
            // txtCedula
            // 
            this.txtCedula.Enabled = false;
            this.txtCedula.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtCedula.Location = new System.Drawing.Point(235, 98);
            this.txtCedula.Multiline = true;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(331, 36);
            this.txtCedula.TabIndex = 212;
            this.txtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPagoDeuda
            // 
            this.txtPagoDeuda.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtPagoDeuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtPagoDeuda.Location = new System.Drawing.Point(741, 147);
            this.txtPagoDeuda.Multiline = true;
            this.txtPagoDeuda.Name = "txtPagoDeuda";
            this.txtPagoDeuda.Size = new System.Drawing.Size(228, 36);
            this.txtPagoDeuda.TabIndex = 210;
            this.txtPagoDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label6.Location = new System.Drawing.Point(568, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 209;
            this.label6.Text = "Pagar Deuda:";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtCodigoCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtCodigoCliente.Location = new System.Drawing.Point(741, 95);
            this.txtCodigoCliente.Multiline = true;
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(228, 36);
            this.txtCodigoCliente.TabIndex = 208;
            this.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label5.Location = new System.Drawing.Point(568, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 207;
            this.label5.Text = "Codigo Cliente:";
            // 
            // txtFactura
            // 
            this.txtFactura.Enabled = false;
            this.txtFactura.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtFactura.Location = new System.Drawing.Point(741, 48);
            this.txtFactura.Multiline = true;
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(228, 36);
            this.txtFactura.TabIndex = 206;
            this.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label4.Location = new System.Drawing.Point(570, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 205;
            this.label4.Text = "Fecha de Pago:";
            // 
            // dateTimePago
            // 
            this.dateTimePago.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.dateTimePago.Enabled = false;
            this.dateTimePago.Location = new System.Drawing.Point(741, 22);
            this.dateTimePago.Name = "dateTimePago";
            this.dateTimePago.Size = new System.Drawing.Size(228, 20);
            this.dateTimePago.TabIndex = 204;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label1.Location = new System.Drawing.Point(576, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 203;
            this.label1.Text = "Factura #";
            // 
            // txtDeudaActul
            // 
            this.txtDeudaActul.Enabled = false;
            this.txtDeudaActul.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtDeudaActul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtDeudaActul.Location = new System.Drawing.Point(235, 150);
            this.txtDeudaActul.Multiline = true;
            this.txtDeudaActul.Name = "txtDeudaActul";
            this.txtDeudaActul.Size = new System.Drawing.Size(331, 36);
            this.txtDeudaActul.TabIndex = 200;
            this.txtDeudaActul.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label2.Location = new System.Drawing.Point(48, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 162;
            this.label2.Text = "Nombre Cliente:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtNom
            // 
            this.txtNom.Enabled = false;
            this.txtNom.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtNom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtNom.Location = new System.Drawing.Point(235, 48);
            this.txtNom.Multiline = true;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(331, 36);
            this.txtNom.TabIndex = 163;
            this.txtNom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label8.Location = new System.Drawing.Point(48, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 25);
            this.label8.TabIndex = 199;
            this.label8.Text = "Deuda Actual:";
            // 
            // blbStado
            // 
            this.blbStado.AutoSize = true;
            this.blbStado.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.blbStado.ForeColor = System.Drawing.Color.White;
            this.blbStado.Location = new System.Drawing.Point(491, 3);
            this.blbStado.Name = "blbStado";
            this.blbStado.Size = new System.Drawing.Size(84, 25);
            this.blbStado.TabIndex = 163;
            this.blbStado.Text = "Estado";
            this.blbStado.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label3.Location = new System.Drawing.Point(267, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(688, 25);
            this.label3.TabIndex = 164;
            this.label3.Text = "Criterios de Busqueda: Por el #Factura, Cedula , Codigo, Nombre";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtBuscar.Location = new System.Drawing.Point(272, 52);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(782, 47);
            this.txtBuscar.TabIndex = 165;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Lucida Sans", 15F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::SistemaFacturacion.Properties.Resources.buscador;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(99, 52);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(167, 47);
            this.btnBuscar.TabIndex = 166;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TabCXC.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabCuentaP.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TabPage tabCuentaP;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeudaActul;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPagoDeuda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button BtnIngerso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label blbStado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscar;
    }
    }