namespace SistemaFacturacion.Formularios
{
    partial class CodigoBarraGenerador
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
            this.btnBuscarCodigo = new System.Windows.Forms.Button();
            this.btnBuscarTodos = new System.Windows.Forms.Button();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.txtCopias = new System.Windows.Forms.TextBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.btnBuscarCodigo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscarCodigo.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(632, 19);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(117, 49);
            this.btnBuscarCodigo.TabIndex = 1;
            this.btnBuscarCodigo.Text = "Buscar";
            this.btnBuscarCodigo.UseVisualStyleBackColor = false;
            this.btnBuscarCodigo.Click += new System.EventHandler(this.btnBuscarCodigo_Click);
            // 
            // btnBuscarTodos
            // 
            this.btnBuscarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.btnBuscarTodos.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscarTodos.ForeColor = System.Drawing.Color.White;
            this.btnBuscarTodos.Location = new System.Drawing.Point(755, 19);
            this.btnBuscarTodos.Name = "btnBuscarTodos";
            this.btnBuscarTodos.Size = new System.Drawing.Size(170, 49);
            this.btnBuscarTodos.TabIndex = 2;
            this.btnBuscarTodos.Text = "Buscar Todos";
            this.btnBuscarTodos.UseVisualStyleBackColor = false;
            this.btnBuscarTodos.Click += new System.EventHandler(this.btnBuscarTodos_Click);
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtCodigoBarra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtCodigoBarra.Location = new System.Drawing.Point(180, 19);
            this.txtCodigoBarra.Multiline = true;
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(250, 49);
            this.txtCodigoBarra.TabIndex = 3;
            this.txtCodigoBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCopias
            // 
            this.txtCopias.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtCopias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(243)))));
            this.txtCopias.Location = new System.Drawing.Point(574, 19);
            this.txtCopias.Multiline = true;
            this.txtCopias.Name = "txtCopias";
            this.txtCopias.Size = new System.Drawing.Size(52, 49);
            this.txtCopias.TabIndex = 5;
            this.txtCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.ForeColor = System.Drawing.Color.White;
            this.crystalReportViewer1.Location = new System.Drawing.Point(19, 76);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(909, 298);
            this.crystalReportViewer1.TabIndex = 6;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnBuscarTodos);
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Controls.Add(this.btnBuscarCodigo);
            this.panel1.Controls.Add(this.txtCopias);
            this.panel1.Controls.Add(this.txtCodigoBarra);
            this.panel1.Location = new System.Drawing.Point(116, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 417);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label1.Location = new System.Drawing.Point(436, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 120;
            this.label1.Text = "No. Copias:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(139)))), ((int)(((byte)(144)))));
            this.label4.Location = new System.Drawing.Point(18, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 25);
            this.label4.TabIndex = 119;
            this.label4.Text = "Codigo Barra:";
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.panel7.ForeColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(0, 68);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1161, 38);
            this.panel7.TabIndex = 94;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 518);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 43);
            this.panel2.TabIndex = 95;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(355, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(436, 58);
            this.label7.TabIndex = 163;
            this.label7.Text = "Codigo de Barras";
            // 
            // CodigoBarraGenerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(1161, 561);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CodigoBarraGenerador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Codigos De Barras";
            this.Load += new System.EventHandler(this.CodigoBarraGenerador_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscarCodigo;
        private System.Windows.Forms.Button btnBuscarTodos;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.TextBox txtCopias;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
    }
}