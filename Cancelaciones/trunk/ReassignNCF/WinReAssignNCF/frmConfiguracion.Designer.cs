namespace WinReAssignNCF
{
    partial class Form1
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
            this.txtTipoDocumentoID = new System.Windows.Forms.TextBox();
            this.txtCompanyId = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbServerList = new System.Windows.Forms.ComboBox();
            this.cbDatabaseList = new System.Windows.Forms.ComboBox();
            this.btnActualizarListaBaseDatos = new System.Windows.Forms.Button();
            this.chkTrustedConnection = new System.Windows.Forms.CheckBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTipoDocumentoID
            // 
            this.txtTipoDocumentoID.Location = new System.Drawing.Point(128, 9);
            this.txtTipoDocumentoID.Name = "txtTipoDocumentoID";
            this.txtTipoDocumentoID.Size = new System.Drawing.Size(178, 20);
            this.txtTipoDocumentoID.TabIndex = 1;
            // 
            // txtCompanyId
            // 
            this.txtCompanyId.Location = new System.Drawing.Point(128, 35);
            this.txtCompanyId.Name = "txtCompanyId";
            this.txtCompanyId.Size = new System.Drawing.Size(178, 20);
            this.txtCompanyId.TabIndex = 2;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(48, 42);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(74, 13);
            this.lbl.TabIndex = 3;
            this.lbl.Text = "Compañia ID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo Documentos ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuario :";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(128, 86);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(178, 20);
            this.txtUser.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Servidor :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(128, 111);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Base de Datos :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Location = new System.Drawing.Point(340, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(65, 196);
            this.panel1.TabIndex = 13;
            // 
            // cbServerList
            // 
            this.cbServerList.FormattingEnabled = true;
            this.cbServerList.Location = new System.Drawing.Point(128, 59);
            this.cbServerList.Name = "cbServerList";
            this.cbServerList.Size = new System.Drawing.Size(177, 21);
            this.cbServerList.TabIndex = 3;
            // 
            // cbDatabaseList
            // 
            this.cbDatabaseList.FormattingEnabled = true;
            this.cbDatabaseList.Location = new System.Drawing.Point(129, 162);
            this.cbDatabaseList.Name = "cbDatabaseList";
            this.cbDatabaseList.Size = new System.Drawing.Size(177, 21);
            this.cbDatabaseList.TabIndex = 14;
            // 
            // btnActualizarListaBaseDatos
            // 
            this.btnActualizarListaBaseDatos.Location = new System.Drawing.Point(310, 162);
            this.btnActualizarListaBaseDatos.Name = "btnActualizarListaBaseDatos";
            this.btnActualizarListaBaseDatos.Size = new System.Drawing.Size(22, 20);
            this.btnActualizarListaBaseDatos.TabIndex = 15;
            this.btnActualizarListaBaseDatos.Text = "...";
            this.btnActualizarListaBaseDatos.UseVisualStyleBackColor = true;
            this.btnActualizarListaBaseDatos.Click += new System.EventHandler(this.btnActualizarListaBaseDatos_Click);
            // 
            // chkTrustedConnection
            // 
            this.chkTrustedConnection.AutoSize = true;
            this.chkTrustedConnection.Location = new System.Drawing.Point(129, 134);
            this.chkTrustedConnection.Name = "chkTrustedConnection";
            this.chkTrustedConnection.Size = new System.Drawing.Size(119, 17);
            this.chkTrustedConnection.TabIndex = 16;
            this.chkTrustedConnection.Text = "Trusted Connection";
            this.chkTrustedConnection.UseVisualStyleBackColor = true;
            this.chkTrustedConnection.CheckedChanged += new System.EventHandler(this.chkTrustedConnection_CheckedChanged);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Image = global::WinReAssignNCF.Properties.Resources.Salir48;
            this.BtnSalir.Location = new System.Drawing.Point(2, 64);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(60, 56);
            this.BtnSalir.TabIndex = 1;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::WinReAssignNCF.Properties.Resources.images__Custom_;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(2, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(60, 56);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 188);
            this.Controls.Add(this.chkTrustedConnection);
            this.Controls.Add(this.btnActualizarListaBaseDatos);
            this.Controls.Add(this.cbDatabaseList);
            this.Controls.Add(this.cbServerList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtCompanyId);
            this.Controls.Add(this.txtTipoDocumentoID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtTipoDocumentoID;
        private System.Windows.Forms.TextBox txtCompanyId;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.ComboBox cbServerList;
        private System.Windows.Forms.ComboBox cbDatabaseList;
        private System.Windows.Forms.Button btnActualizarListaBaseDatos;
        private System.Windows.Forms.CheckBox chkTrustedConnection;
    }
}

