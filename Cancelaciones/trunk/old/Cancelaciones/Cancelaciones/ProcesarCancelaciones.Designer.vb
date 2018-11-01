<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcesarCancelaciones
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GrdCancelaciones = New System.Windows.Forms.DataGridView()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Poliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Beneficiario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreIntermediario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoIntermediario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InicioVigencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinVigencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVenceReal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Endosada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceGP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalanceSF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSupervisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SysFlexSegurosDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SysFlexSegurosDataSet = New Cancelaciones.SysFlexSegurosDataSet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdProcesar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GrdCancelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SysFlexSegurosDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SysFlexSegurosDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrdCancelaciones
        '
        Me.GrdCancelaciones.AllowUserToOrderColumns = True
        Me.GrdCancelaciones.AutoGenerateColumns = False
        Me.GrdCancelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdCancelaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionar, Me.Poliza, Me.NombreCliente, Me.Beneficiario, Me.NombreIntermediario, Me.TipoIntermediario, Me.InicioVigencia, Me.FinVigencia, Me.FechaVenceReal, Me.Endosada, Me.BalanceGP, Me.BalanceSF, Me.Diferencia, Me.NombreSupervisor})
        Me.GrdCancelaciones.DataSource = Me.SysFlexSegurosDataSetBindingSource
        Me.GrdCancelaciones.Location = New System.Drawing.Point(12, 100)
        Me.GrdCancelaciones.Name = "GrdCancelaciones"
        Me.GrdCancelaciones.Size = New System.Drawing.Size(1226, 413)
        Me.GrdCancelaciones.TabIndex = 0
        '
        'Seleccionar
        '
        Me.Seleccionar.DataPropertyName = "None"
        Me.Seleccionar.HeaderText = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        '
        'Poliza
        '
        Me.Poliza.DataPropertyName = "Poliza"
        Me.Poliza.HeaderText = "Poliza"
        Me.Poliza.Name = "Poliza"
        '
        'NombreCliente
        '
        Me.NombreCliente.DataPropertyName = "NombreCliente"
        Me.NombreCliente.HeaderText = "Nombre del Cliente"
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.ReadOnly = True
        Me.NombreCliente.Width = 250
        '
        'Beneficiario
        '
        Me.Beneficiario.DataPropertyName = "Beneficiario"
        Me.Beneficiario.HeaderText = "Beneficiario"
        Me.Beneficiario.Name = "Beneficiario"
        Me.Beneficiario.ReadOnly = True
        Me.Beneficiario.Width = 150
        '
        'NombreIntermediario
        '
        Me.NombreIntermediario.DataPropertyName = "NombreIntermediario"
        Me.NombreIntermediario.HeaderText = "Nombre de Intermediario"
        Me.NombreIntermediario.Name = "NombreIntermediario"
        Me.NombreIntermediario.ReadOnly = True
        Me.NombreIntermediario.Width = 250
        '
        'TipoIntermediario
        '
        Me.TipoIntermediario.DataPropertyName = "TipoIntermediario"
        Me.TipoIntermediario.HeaderText = "Tipo de Intermediario"
        Me.TipoIntermediario.Name = "TipoIntermediario"
        Me.TipoIntermediario.ReadOnly = True
        '
        'InicioVigencia
        '
        Me.InicioVigencia.DataPropertyName = "InicioVigencia"
        Me.InicioVigencia.HeaderText = "Inicio de Vigencia"
        Me.InicioVigencia.Name = "InicioVigencia"
        Me.InicioVigencia.ReadOnly = True
        '
        'FinVigencia
        '
        Me.FinVigencia.DataPropertyName = "FinVigencia"
        Me.FinVigencia.HeaderText = "Fin de Vigencia"
        Me.FinVigencia.Name = "FinVigencia"
        Me.FinVigencia.ReadOnly = True
        '
        'FechaVenceReal
        '
        Me.FechaVenceReal.DataPropertyName = "FechaVenceReal"
        Me.FechaVenceReal.HeaderText = "Fecha Vencimiento Real"
        Me.FechaVenceReal.Name = "FechaVenceReal"
        Me.FechaVenceReal.ReadOnly = True
        '
        'Endosada
        '
        Me.Endosada.DataPropertyName = "Endosada"
        Me.Endosada.HeaderText = "Endosada"
        Me.Endosada.Name = "Endosada"
        Me.Endosada.ReadOnly = True
        '
        'BalanceGP
        '
        Me.BalanceGP.DataPropertyName = "BalanceGP"
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = "0"
        Me.BalanceGP.DefaultCellStyle = DataGridViewCellStyle13
        Me.BalanceGP.HeaderText = "BalanceGP"
        Me.BalanceGP.Name = "BalanceGP"
        Me.BalanceGP.ReadOnly = True
        '
        'BalanceSF
        '
        Me.BalanceSF.DataPropertyName = "BalanceSF"
        DataGridViewCellStyle14.Format = "C2"
        DataGridViewCellStyle14.NullValue = "0"
        Me.BalanceSF.DefaultCellStyle = DataGridViewCellStyle14
        Me.BalanceSF.HeaderText = "BalanceSF"
        Me.BalanceSF.Name = "BalanceSF"
        Me.BalanceSF.ReadOnly = True
        '
        'Diferencia
        '
        Me.Diferencia.DataPropertyName = "Diferencia"
        DataGridViewCellStyle15.Format = "C2"
        DataGridViewCellStyle15.NullValue = "0"
        Me.Diferencia.DefaultCellStyle = DataGridViewCellStyle15
        Me.Diferencia.HeaderText = "Diferencia"
        Me.Diferencia.Name = "Diferencia"
        Me.Diferencia.ReadOnly = True
        '
        'NombreSupervisor
        '
        Me.NombreSupervisor.DataPropertyName = "NombreSupervisor"
        Me.NombreSupervisor.HeaderText = "Nombre de Supervisor"
        Me.NombreSupervisor.Name = "NombreSupervisor"
        Me.NombreSupervisor.ReadOnly = True
        Me.NombreSupervisor.Width = 250
        '
        'SysFlexSegurosDataSetBindingSource
        '
        Me.SysFlexSegurosDataSetBindingSource.DataSource = Me.SysFlexSegurosDataSet
        Me.SysFlexSegurosDataSetBindingSource.Position = 0
        '
        'SysFlexSegurosDataSet
        '
        Me.SysFlexSegurosDataSet.DataSetName = "SysFlexSegurosDataSet"
        Me.SysFlexSegurosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cancelaciones a Procesar"
        '
        'cmdProcesar
        '
        Me.cmdProcesar.Location = New System.Drawing.Point(1148, 61)
        Me.cmdProcesar.Name = "cmdProcesar"
        Me.cmdProcesar.Size = New System.Drawing.Size(90, 28)
        Me.cmdProcesar.TabIndex = 2
        Me.cmdProcesar.Text = "Procesar"
        Me.cmdProcesar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Cargar Datos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(785, 539)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Total Polizas:"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(888, 532)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(65, 20)
        Me.txtTotal.TabIndex = 5
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(439, 69)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(221, 20)
        Me.txtFiltro.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Beneficiario", "Cliente", "Nombre de Intermediario", "Tipo de Intermediario", "Nombre de Supervisor"})
        Me.ComboBox1.Location = New System.Drawing.Point(246, 65)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(685, 69)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Filtrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(184, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Filtrar por :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(398, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Filtro :"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 529)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(342, 23)
        Me.ProgressBar1.TabIndex = 13
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1300, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ProcesarCancelaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 570)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdProcesar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GrdCancelaciones)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ProcesarCancelaciones"
        Me.Text = "Procesar Cancelaciones"
        CType(Me.GrdCancelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SysFlexSegurosDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SysFlexSegurosDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents GrdCancelaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdProcesar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SysFlexSegurosDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SysFlexSegurosDataSet As Cancelaciones.SysFlexSegurosDataSet
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Poliza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Beneficiario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreIntermediario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoIntermediario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InicioVigencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinVigencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVenceReal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Endosada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceGP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceSF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Diferencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreSupervisor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
