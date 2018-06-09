namespace SistemaFacturacion.Formularios
    {
    partial class FrmCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCategoria));
            this.TabEmpleado = new System.Windows.Forms.TabControl();
            this.TabBuscar = new System.Windows.Forms.TabPage();
            this.txtSearchCategoria = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GridViewCategoria = new System.Windows.Forms.DataGridView();
            this.selecc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelErrorCategoria = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnArticulos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Nuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BuscarD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Eliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Limpia = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Salir = new System.Windows.Forms.ToolStripButton();
            this.TabEmpleado.SuspendLayout();
            this.TabBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCategoria)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelErrorCategoria.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabEmpleado
            // 
            this.TabEmpleado.Controls.Add(this.TabBuscar);
            this.TabEmpleado.Controls.Add(this.tabPage2);
            this.TabEmpleado.Location = new System.Drawing.Point(8, 74);
            this.TabEmpleado.Name = "TabEmpleado";
            this.TabEmpleado.SelectedIndex = 0;
            this.TabEmpleado.Size = new System.Drawing.Size(964, 403);
            this.TabEmpleado.TabIndex = 11;
            // 
            // TabBuscar
            // 
            this.TabBuscar.Controls.Add(this.txtSearchCategoria);
            this.TabBuscar.Controls.Add(this.label4);
            this.TabBuscar.Controls.Add(this.GridViewCategoria);
            this.TabBuscar.Location = new System.Drawing.Point(4, 22);
            this.TabBuscar.Name = "TabBuscar";
            this.TabBuscar.Padding = new System.Windows.Forms.Padding(3);
            this.TabBuscar.Size = new System.Drawing.Size(956, 377);
            this.TabBuscar.TabIndex = 0;
            this.TabBuscar.Text = "Busqueda Empleado:";
            this.TabBuscar.UseVisualStyleBackColor = true;
            // 
            // txtSearchCategoria
            // 
            this.txtSearchCategoria.BackColor = System.Drawing.Color.White;
            this.txtSearchCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCategoria.Location = new System.Drawing.Point(120, 12);
            this.txtSearchCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchCategoria.Multiline = true;
            this.txtSearchCategoria.Name = "txtSearchCategoria";
            this.txtSearchCategoria.Size = new System.Drawing.Size(828, 31);
            this.txtSearchCategoria.TabIndex = 112;
            this.txtSearchCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 73;
            this.label4.Text = "Buscar Categoria";
            // 
            // GridViewCategoria
            // 
            this.GridViewCategoria.AllowUserToAddRows = false;
            this.GridViewCategoria.AllowUserToDeleteRows = false;
            this.GridViewCategoria.AllowUserToOrderColumns = true;
            this.GridViewCategoria.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridViewCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selecc,
            this.Codigo,
            this.nombreG,
            this.Desc});
            this.GridViewCategoria.Location = new System.Drawing.Point(6, 64);
            this.GridViewCategoria.Name = "GridViewCategoria";
            this.GridViewCategoria.ReadOnly = true;
            this.GridViewCategoria.Size = new System.Drawing.Size(942, 290);
            this.GridViewCategoria.TabIndex = 0;
            this.GridViewCategoria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewCategoria_CellContentClick);
            // 
            // selecc
            // 
            this.selecc.HeaderText = "Seleccionar";
            this.selecc.Name = "selecc";
            this.selecc.ReadOnly = true;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            // 
            // nombreG
            // 
            this.nombreG.HeaderText = "Nombre";
            this.nombreG.Name = "nombreG";
            this.nombreG.ReadOnly = true;
            this.nombreG.Visible = false;
            // 
            // Desc
            // 
            this.Desc.HeaderText = "Descripción";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            this.Desc.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(956, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimineto Empleado:";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelErrorCategoria);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDes);
            this.groupBox1.Controls.Add(this.txtNom);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 352);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            // 
            // panelErrorCategoria
            // 
            this.panelErrorCategoria.AutoSize = true;
            this.panelErrorCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(216)))));
            this.panelErrorCategoria.Controls.Add(this.label6);
            this.panelErrorCategoria.Controls.Add(this.label1);
            this.panelErrorCategoria.ForeColor = System.Drawing.Color.White;
            this.panelErrorCategoria.Location = new System.Drawing.Point(150, 75);
            this.panelErrorCategoria.Name = "panelErrorCategoria";
            this.panelErrorCategoria.Size = new System.Drawing.Size(788, 54);
            this.panelErrorCategoria.TabIndex = 91;
            this.panelErrorCategoria.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(118)))), ((int)(((byte)(61)))));
            this.label6.Location = new System.Drawing.Point(277, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 26);
            this.label1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(150, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(788, 62);
            this.panel3.TabIndex = 90;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(6, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 62);
            this.panel2.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(17, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "M";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.BtnArticulos);
            this.panel1.Location = new System.Drawing.Point(7, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 273);
            this.panel1.TabIndex = 87;
            // 
            // BtnArticulos
            // 
            this.BtnArticulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.BtnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnArticulos.ForeColor = System.Drawing.Color.White;
            this.BtnArticulos.Location = new System.Drawing.Point(21, 37);
            this.BtnArticulos.Name = "BtnArticulos";
            this.BtnArticulos.Size = new System.Drawing.Size(102, 37);
            this.BtnArticulos.TabIndex = 1;
            this.BtnArticulos.Text = "&Articulos";
            this.BtnArticulos.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(634, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 170);
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 74;
            this.label2.Text = "Nombre Categoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(197, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 75;
            this.label5.Text = "Descripción";
            // 
            // txtDes
            // 
            this.txtDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDes.Location = new System.Drawing.Point(279, 195);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(349, 122);
            this.txtDes.TabIndex = 84;
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.White;
            this.txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(279, 147);
            this.txtNom.Multiline = true;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(349, 42);
            this.txtNom.TabIndex = 83;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nuevo,
            this.toolStripSeparator6,
            this.toolStripButton1,
            this.toolStripSeparator5,
            this.BuscarD,
            this.toolStripSeparator1,
            this.Aceptar,
            this.toolStripSeparator4,
            this.Eliminar,
            this.toolStripSeparator3,
            this.Limpia,
            this.toolStripSeparator2,
            this.Salir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(984, 71);
            this.ToolStrip1.TabIndex = 10;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // Nuevo
            // 
            this.Nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("Nuevo.Image")));
            this.Nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(68, 68);
            this.Nuevo.Text = "Nuevo";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 71);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 68);
            this.toolStripButton1.Text = "Limpiar";
            this.toolStripButton1.ToolTipText = "Eliminar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 71);
            // 
            // BuscarD
            // 
            this.BuscarD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BuscarD.Image = ((System.Drawing.Image)(resources.GetObject("BuscarD.Image")));
            this.BuscarD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BuscarD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BuscarD.Name = "BuscarD";
            this.BuscarD.Size = new System.Drawing.Size(52, 68);
            this.BuscarD.Text = "Buscar";
            this.BuscarD.ToolTipText = "Buscar";
            this.BuscarD.Click += new System.EventHandler(this.BuscarD_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
            // 
            // Aceptar
            // 
            this.Aceptar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("Aceptar.Image")));
            this.Aceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Aceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(52, 68);
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.ToolTipText = "Guardar, Modificar";
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 71);
            // 
            // Eliminar
            // 
            this.Eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(52, 68);
            this.Eliminar.Text = "Limpiar";
            this.Eliminar.ToolTipText = "Eliminar";
            this.Eliminar.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 71);
            // 
            // Limpia
            // 
            this.Limpia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Limpia.Enabled = false;
            this.Limpia.Image = ((System.Drawing.Image)(resources.GetObject("Limpia.Image")));
            this.Limpia.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Limpia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Limpia.Name = "Limpia";
            this.Limpia.Size = new System.Drawing.Size(68, 68);
            this.Limpia.Text = "Limpia";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 71);
            // 
            // Salir
            // 
            this.Salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Salir.Image = ((System.Drawing.Image)(resources.GetObject("Salir.Image")));
            this.Salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(52, 68);
            this.Salir.Text = "Salir";
            this.Salir.ToolTipText = "Salir";
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // FrmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 483);
            this.Controls.Add(this.TabEmpleado);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "FrmCategoria";
            this.Text = "FrmCategoria";
            this.Load += new System.EventHandler(this.FrmCategoria_Load);
            this.TabEmpleado.ResumeLayout(false);
            this.TabBuscar.ResumeLayout(false);
            this.TabBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCategoria)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelErrorCategoria.ResumeLayout(false);
            this.panelErrorCategoria.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TabControl TabEmpleado;
        private System.Windows.Forms.TabPage TabBuscar;
        private System.Windows.Forms.TextBox txtSearchCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView GridViewCategoria;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.TextBox txtNom;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton Nuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripButton BuscarD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripButton Eliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton Limpia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton Salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelErrorCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnArticulos;
        private System.Windows.Forms.DataGridViewButtonColumn selecc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        }
    }