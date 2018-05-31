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
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.txtSearchCategoria = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GridViewCategoria = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnProducto = new System.Windows.Forms.Button();
            this.TabEmpleado.SuspendLayout();
            this.TabBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCategoria)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.TabBuscar.Controls.Add(this.txtcodigo);
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
            // txtcodigo
            // 
            this.txtcodigo.BackColor = System.Drawing.Color.White;
            this.txtcodigo.Enabled = false;
            this.txtcodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(0, 365);
            this.txtcodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtcodigo.Multiline = true;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(10, 10);
            this.txtcodigo.TabIndex = 118;
            this.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcodigo.Visible = false;
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
            this.GridViewCategoria.Location = new System.Drawing.Point(6, 64);
            this.GridViewCategoria.Name = "GridViewCategoria";
            this.GridViewCategoria.ReadOnly = true;
            this.GridViewCategoria.Size = new System.Drawing.Size(942, 290);
            this.GridViewCategoria.TabIndex = 0;
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
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.progressBar1);
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
            this.groupBox1.Text = "groupBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 74;
            this.label2.Text = "Nombre Categoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(197, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 75;
            this.label5.Text = "Descripción";
            // 
            // txtDes
            // 
            this.txtDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDes.Location = new System.Drawing.Point(279, 77);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(323, 122);
            this.txtDes.TabIndex = 84;
            // 
            // txtNom
            // 
            this.txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(279, 29);
            this.txtNom.Multiline = true;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(323, 42);
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
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(608, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 170);
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(152, 323);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(786, 23);
            this.progressBar1.TabIndex = 86;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnProducto);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 336);
            this.panel1.TabIndex = 87;
            // 
            // BtnProducto
            // 
            this.BtnProducto.Location = new System.Drawing.Point(3, 10);
            this.BtnProducto.Name = "BtnProducto";
            this.BtnProducto.Size = new System.Drawing.Size(137, 23);
            this.BtnProducto.TabIndex = 0;
            this.BtnProducto.Text = "Productos";
            this.BtnProducto.UseVisualStyleBackColor = true;
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
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TabControl TabEmpleado;
        private System.Windows.Forms.TabPage TabBuscar;
        private System.Windows.Forms.TextBox txtcodigo;
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnProducto;
        }
    }