<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcesarCancelaciones
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcesarCancelaciones))
        Me.TabControCancelar = New System.Windows.Forms.TabControl()
        Me.TabControCancelarPorPagos = New System.Windows.Forms.TabPage()
        Me.chkMostrarSeleccionadas = New System.Windows.Forms.CheckBox()
        Me.txtTotalPolizasSeleccionadas = New System.Windows.Forms.TextBox()
        Me.lblTotalPolizasSeleccionadas = New System.Windows.Forms.Label()
        Me.lblPasoProceso = New System.Windows.Forms.Label()
        Me.txtPolizasFiltradas = New System.Windows.Forms.TextBox()
        Me.lblPolizasFiltradas = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.txtTotalPolizas = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GrdCancelaciones = New System.Windows.Forms.DataGridView()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Poliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReglaSiniestros = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.btnExportCSV = New System.Windows.Forms.Button()
        Me.btnPegarPolizas = New System.Windows.Forms.Button()
        Me.lblFiltrandoPor = New System.Windows.Forms.Label()
        Me.btnEliminarFiltro = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.cbFiltros = New System.Windows.Forms.ComboBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.BtnCargarDatos = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControCancelarPorDocument = New System.Windows.Forms.TabPage()
        Me.lblTiempoDeProcesamiento = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.SysFlexSegurosDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SysFlexSegurosDataSet = New Cancelaciones.SysFlexSegurosDataSet()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.timerTiempoTranscurrido = New System.Windows.Forms.Timer(Me.components)
        Me.TabControCancelar.SuspendLayout()
        Me.TabControCancelarPorPagos.SuspendLayout()
        CType(Me.GrdCancelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.TabControCancelarPorDocument.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SysFlexSegurosDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SysFlexSegurosDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControCancelar
        '
        Me.TabControCancelar.Controls.Add(Me.TabControCancelarPorPagos)
        Me.TabControCancelar.Controls.Add(Me.TabControCancelarPorDocument)
        Me.TabControCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControCancelar.Location = New System.Drawing.Point(0, 2)
        Me.TabControCancelar.Name = "TabControCancelar"
        Me.TabControCancelar.SelectedIndex = 0
        Me.TabControCancelar.Size = New System.Drawing.Size(1259, 652)
        Me.TabControCancelar.TabIndex = 0
        '
        'TabControCancelarPorPagos
        '
        Me.TabControCancelarPorPagos.Controls.Add(Me.btnProcesar)
        Me.TabControCancelarPorPagos.Controls.Add(Me.chkMostrarSeleccionadas)
        Me.TabControCancelarPorPagos.Controls.Add(Me.txtTotalPolizasSeleccionadas)
        Me.TabControCancelarPorPagos.Controls.Add(Me.lblTotalPolizasSeleccionadas)
        Me.TabControCancelarPorPagos.Controls.Add(Me.lblPasoProceso)
        Me.TabControCancelarPorPagos.Controls.Add(Me.txtPolizasFiltradas)
        Me.TabControCancelarPorPagos.Controls.Add(Me.lblPolizasFiltradas)
        Me.TabControCancelarPorPagos.Controls.Add(Me.ProgressBar1)
        Me.TabControCancelarPorPagos.Controls.Add(Me.txtTotalPolizas)
        Me.TabControCancelarPorPagos.Controls.Add(Me.Label5)
        Me.TabControCancelarPorPagos.Controls.Add(Me.GrdCancelaciones)
        Me.TabControCancelarPorPagos.Controls.Add(Me.btnExportCSV)
        Me.TabControCancelarPorPagos.Controls.Add(Me.btnPegarPolizas)
        Me.TabControCancelarPorPagos.Controls.Add(Me.lblFiltrandoPor)
        Me.TabControCancelarPorPagos.Controls.Add(Me.btnEliminarFiltro)
        Me.TabControCancelarPorPagos.Controls.Add(Me.Label4)
        Me.TabControCancelarPorPagos.Controls.Add(Me.Label3)
        Me.TabControCancelarPorPagos.Controls.Add(Me.btnFiltrar)
        Me.TabControCancelarPorPagos.Controls.Add(Me.cbFiltros)
        Me.TabControCancelarPorPagos.Controls.Add(Me.txtFiltro)
        Me.TabControCancelarPorPagos.Controls.Add(Me.BtnCargarDatos)
        Me.TabControCancelarPorPagos.Controls.Add(Me.Label2)
        Me.TabControCancelarPorPagos.Controls.Add(Me.Label1)
        Me.TabControCancelarPorPagos.Controls.Add(Me.MenuStrip2)
        Me.TabControCancelarPorPagos.Location = New System.Drawing.Point(4, 29)
        Me.TabControCancelarPorPagos.Name = "TabControCancelarPorPagos"
        Me.TabControCancelarPorPagos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabControCancelarPorPagos.Size = New System.Drawing.Size(1251, 619)
        Me.TabControCancelarPorPagos.TabIndex = 0
        Me.TabControCancelarPorPagos.Text = "Procesar Cancelacion por falta de Pagos"
        Me.TabControCancelarPorPagos.UseVisualStyleBackColor = True
        '
        'chkMostrarSeleccionadas
        '
        Me.chkMostrarSeleccionadas.AutoSize = True
        Me.chkMostrarSeleccionadas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMostrarSeleccionadas.Location = New System.Drawing.Point(924, 580)
        Me.chkMostrarSeleccionadas.Name = "chkMostrarSeleccionadas"
        Me.chkMostrarSeleccionadas.Size = New System.Drawing.Size(321, 24)
        Me.chkMostrarSeleccionadas.TabIndex = 47
        Me.chkMostrarSeleccionadas.Text = "Mostrar solo la(s) Póliza(s) Seleccionadas"
        Me.chkMostrarSeleccionadas.UseVisualStyleBackColor = True
        '
        'txtTotalPolizasSeleccionadas
        '
        Me.txtTotalPolizasSeleccionadas.Enabled = False
        Me.txtTotalPolizasSeleccionadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPolizasSeleccionadas.Location = New System.Drawing.Point(1138, 559)
        Me.txtTotalPolizasSeleccionadas.Name = "txtTotalPolizasSeleccionadas"
        Me.txtTotalPolizasSeleccionadas.Size = New System.Drawing.Size(106, 20)
        Me.txtTotalPolizasSeleccionadas.TabIndex = 46
        Me.txtTotalPolizasSeleccionadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotalPolizasSeleccionadas
        '
        Me.lblTotalPolizasSeleccionadas.AutoSize = True
        Me.lblTotalPolizasSeleccionadas.Location = New System.Drawing.Point(929, 559)
        Me.lblTotalPolizasSeleccionadas.Name = "lblTotalPolizasSeleccionadas"
        Me.lblTotalPolizasSeleccionadas.Size = New System.Drawing.Size(210, 20)
        Me.lblTotalPolizasSeleccionadas.TabIndex = 45
        Me.lblTotalPolizasSeleccionadas.Text = "Total Polizas Seleccionadas:"
        '
        'lblPasoProceso
        '
        Me.lblPasoProceso.Location = New System.Drawing.Point(361, 532)
        Me.lblPasoProceso.Name = "lblPasoProceso"
        Me.lblPasoProceso.Size = New System.Drawing.Size(316, 14)
        Me.lblPasoProceso.TabIndex = 44
        Me.lblPasoProceso.Text = "..."
        Me.lblPasoProceso.Visible = False
        '
        'txtPolizasFiltradas
        '
        Me.txtPolizasFiltradas.Enabled = False
        Me.txtPolizasFiltradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPolizasFiltradas.Location = New System.Drawing.Point(186, 562)
        Me.txtPolizasFiltradas.Name = "txtPolizasFiltradas"
        Me.txtPolizasFiltradas.Size = New System.Drawing.Size(65, 20)
        Me.txtPolizasFiltradas.TabIndex = 43
        Me.txtPolizasFiltradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPolizasFiltradas.Visible = False
        '
        'lblPolizasFiltradas
        '
        Me.lblPolizasFiltradas.AutoSize = True
        Me.lblPolizasFiltradas.Location = New System.Drawing.Point(13, 560)
        Me.lblPolizasFiltradas.Name = "lblPolizasFiltradas"
        Me.lblPolizasFiltradas.Size = New System.Drawing.Size(167, 20)
        Me.lblPolizasFiltradas.TabIndex = 42
        Me.lblPolizasFiltradas.Text = "Total Polizas Filtradas:"
        Me.lblPolizasFiltradas.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 527)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(342, 30)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 41
        '
        'txtTotalPolizas
        '
        Me.txtTotalPolizas.Enabled = False
        Me.txtTotalPolizas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPolizas.Location = New System.Drawing.Point(128, 530)
        Me.txtTotalPolizas.Name = "txtTotalPolizas"
        Me.txtTotalPolizas.Size = New System.Drawing.Size(65, 20)
        Me.txtTotalPolizas.TabIndex = 40
        Me.txtTotalPolizas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 537)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Total Polizas:"
        '
        'GrdCancelaciones
        '
        Me.GrdCancelaciones.AllowUserToOrderColumns = True
        Me.GrdCancelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdCancelaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionar, Me.Poliza, Me.ReglaSiniestros, Me.NombreCliente, Me.Beneficiario, Me.NombreIntermediario, Me.TipoIntermediario, Me.InicioVigencia, Me.FinVigencia, Me.FechaVenceReal, Me.Endosada, Me.BalanceGP, Me.BalanceSF, Me.Diferencia, Me.NombreSupervisor})
        Me.GrdCancelaciones.Location = New System.Drawing.Point(8, 108)
        Me.GrdCancelaciones.Name = "GrdCancelaciones"
        Me.GrdCancelaciones.Size = New System.Drawing.Size(1226, 413)
        Me.GrdCancelaciones.TabIndex = 38
        '
        'Seleccionar
        '
        Me.Seleccionar.DataPropertyName = "None"
        Me.Seleccionar.HeaderText = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Poliza
        '
        Me.Poliza.DataPropertyName = "Poliza"
        Me.Poliza.HeaderText = "Poliza"
        Me.Poliza.Name = "Poliza"
        '
        'ReglaSiniestros
        '
        Me.ReglaSiniestros.DataPropertyName = "ReglaSiniestros"
        Me.ReglaSiniestros.HeaderText = "+3 Siniestros"
        Me.ReglaSiniestros.Name = "ReglaSiniestros"
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
        DataGridViewCellStyle16.Format = "C2"
        DataGridViewCellStyle16.NullValue = "0"
        Me.BalanceGP.DefaultCellStyle = DataGridViewCellStyle16
        Me.BalanceGP.HeaderText = "BalanceGP"
        Me.BalanceGP.Name = "BalanceGP"
        Me.BalanceGP.ReadOnly = True
        '
        'BalanceSF
        '
        Me.BalanceSF.DataPropertyName = "BalanceSF"
        DataGridViewCellStyle17.Format = "C2"
        DataGridViewCellStyle17.NullValue = "0"
        Me.BalanceSF.DefaultCellStyle = DataGridViewCellStyle17
        Me.BalanceSF.HeaderText = "BalanceSF"
        Me.BalanceSF.Name = "BalanceSF"
        Me.BalanceSF.ReadOnly = True
        '
        'Diferencia
        '
        Me.Diferencia.DataPropertyName = "Diferencia"
        DataGridViewCellStyle18.Format = "C2"
        DataGridViewCellStyle18.NullValue = "0"
        Me.Diferencia.DefaultCellStyle = DataGridViewCellStyle18
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
        'btnExportCSV
        '
        Me.btnExportCSV.FlatAppearance.BorderSize = 0
        Me.btnExportCSV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportCSV.Image = Global.Cancelaciones.My.Resources.Resources.text_csv
        Me.btnExportCSV.Location = New System.Drawing.Point(1088, 63)
        Me.btnExportCSV.Name = "btnExportCSV"
        Me.btnExportCSV.Size = New System.Drawing.Size(35, 35)
        Me.btnExportCSV.TabIndex = 37
        Me.btnExportCSV.UseVisualStyleBackColor = True
        '
        'btnPegarPolizas
        '
        Me.btnPegarPolizas.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPegarPolizas.Enabled = False
        Me.btnPegarPolizas.Location = New System.Drawing.Point(104, 68)
        Me.btnPegarPolizas.Name = "btnPegarPolizas"
        Me.btnPegarPolizas.Size = New System.Drawing.Size(90, 28)
        Me.btnPegarPolizas.TabIndex = 36
        Me.btnPegarPolizas.Text = "Cargar Lista"
        Me.btnPegarPolizas.UseVisualStyleBackColor = True
        '
        'lblFiltrandoPor
        '
        Me.lblFiltrandoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltrandoPor.ForeColor = System.Drawing.Color.Red
        Me.lblFiltrandoPor.Location = New System.Drawing.Point(725, 73)
        Me.lblFiltrandoPor.Name = "lblFiltrandoPor"
        Me.lblFiltrandoPor.Size = New System.Drawing.Size(353, 19)
        Me.lblFiltrandoPor.TabIndex = 35
        Me.lblFiltrandoPor.Text = "..."
        Me.lblFiltrandoPor.Visible = False
        '
        'btnEliminarFiltro
        '
        Me.btnEliminarFiltro.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEliminarFiltro.Image = CType(resources.GetObject("btnEliminarFiltro.Image"), System.Drawing.Image)
        Me.btnEliminarFiltro.Location = New System.Drawing.Point(858, 68)
        Me.btnEliminarFiltro.Name = "btnEliminarFiltro"
        Me.btnEliminarFiltro.Size = New System.Drawing.Size(87, 28)
        Me.btnEliminarFiltro.TabIndex = 34
        Me.btnEliminarFiltro.Text = "Borrar Filtrar"
        Me.btnEliminarFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminarFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarFiltro.UseVisualStyleBackColor = True
        Me.btnEliminarFiltro.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(444, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 20)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Filtro :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(194, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Filtrar por :"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Enabled = False
        Me.btnFiltrar.Image = CType(resources.GetObject("btnFiltrar.Image"), System.Drawing.Image)
        Me.btnFiltrar.Location = New System.Drawing.Point(765, 68)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(87, 28)
        Me.btnFiltrar.TabIndex = 31
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFiltrar.UseVisualStyleBackColor = True
        Me.btnFiltrar.Visible = False
        '
        'cbFiltros
        '
        Me.cbFiltros.FormattingEnabled = True
        Me.cbFiltros.Items.AddRange(New Object() {"Beneficiario", "Cliente", "Nombre de Intermediario", "Tipo de Intermediario", "Nombre de Supervisor"})
        Me.cbFiltros.Location = New System.Drawing.Point(281, 70)
        Me.cbFiltros.Name = "cbFiltros"
        Me.cbFiltros.Size = New System.Drawing.Size(159, 28)
        Me.cbFiltros.TabIndex = 30
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(499, 71)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(221, 26)
        Me.txtFiltro.TabIndex = 29
        '
        'BtnCargarDatos
        '
        Me.BtnCargarDatos.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCargarDatos.Location = New System.Drawing.Point(8, 68)
        Me.BtnCargarDatos.Name = "BtnCargarDatos"
        Me.BtnCargarDatos.Size = New System.Drawing.Size(90, 28)
        Me.BtnCargarDatos.TabIndex = 28
        Me.BtnCargarDatos.Text = "Cargar Datos"
        Me.BtnCargarDatos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 24)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Cancelaciones a Procesar"
        '
        'Label1
        '
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(827, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(402, 30)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Hora Inicio : {0} | Tiempo Transcurrido {1}"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Visible = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip2.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1245, 24)
        Me.MenuStrip2.TabIndex = 16
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(41, 20)
        Me.ToolStripMenuItem1.Text = "Salir"
        '
        'TabControCancelarPorDocument
        '
        Me.TabControCancelarPorDocument.Controls.Add(Me.lblTiempoDeProcesamiento)
        Me.TabControCancelarPorDocument.Controls.Add(Me.MenuStrip1)
        Me.TabControCancelarPorDocument.Location = New System.Drawing.Point(4, 29)
        Me.TabControCancelarPorDocument.Name = "TabControCancelarPorDocument"
        Me.TabControCancelarPorDocument.Padding = New System.Windows.Forms.Padding(3)
        Me.TabControCancelarPorDocument.Size = New System.Drawing.Size(1251, 610)
        Me.TabControCancelarPorDocument.TabIndex = 1
        Me.TabControCancelarPorDocument.Text = "Procesar Cancelacion por falta de Documentación"
        Me.TabControCancelarPorDocument.UseVisualStyleBackColor = True
        '
        'lblTiempoDeProcesamiento
        '
        Me.lblTiempoDeProcesamiento.Enabled = False
        Me.lblTiempoDeProcesamiento.Location = New System.Drawing.Point(831, 0)
        Me.lblTiempoDeProcesamiento.Name = "lblTiempoDeProcesamiento"
        Me.lblTiempoDeProcesamiento.Size = New System.Drawing.Size(402, 30)
        Me.lblTiempoDeProcesamiento.TabIndex = 16
        Me.lblTiempoDeProcesamiento.Text = "Hora Inicio : {0} | Tiempo Transcurrido {1}"
        Me.lblTiempoDeProcesamiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTiempoDeProcesamiento.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1245, 24)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(1130, 66)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(99, 32)
        Me.btnProcesar.TabIndex = 48
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'SysFlexSegurosDataSetBindingSource
        '
        '
        'SysFlexSegurosDataSet
        '
        Me.SysFlexSegurosDataSet.DataSetName = "SysFlexSegurosDataSet"
        Me.SysFlexSegurosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FrmProcesarCancelaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1261, 660)
        Me.Controls.Add(Me.TabControCancelar)
        Me.Name = "FrmProcesarCancelaciones"
        Me.Text = "FrmProcesarCancelaciones"
        Me.TabControCancelar.ResumeLayout(False)
        Me.TabControCancelarPorPagos.ResumeLayout(False)
        Me.TabControCancelarPorPagos.PerformLayout()
        CType(Me.GrdCancelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.TabControCancelarPorDocument.ResumeLayout(False)
        Me.TabControCancelarPorDocument.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.SysFlexSegurosDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SysFlexSegurosDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControCancelar As TabControl
    Friend WithEvents TabControCancelarPorPagos As TabPage
    Friend WithEvents TabControCancelarPorDocument As TabPage
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblTiempoDeProcesamiento As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents btnExportCSV As Button
    Friend WithEvents btnPegarPolizas As Button
    Friend WithEvents lblFiltrandoPor As Label
    Friend WithEvents btnEliminarFiltro As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents cbFiltros As ComboBox
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents BtnCargarDatos As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GrdCancelaciones As DataGridView
    Friend WithEvents Seleccionar As DataGridViewCheckBoxColumn
    Friend WithEvents Poliza As DataGridViewTextBoxColumn
    Friend WithEvents ReglaSiniestros As DataGridViewTextBoxColumn
    Friend WithEvents NombreCliente As DataGridViewTextBoxColumn
    Friend WithEvents Beneficiario As DataGridViewTextBoxColumn
    Friend WithEvents NombreIntermediario As DataGridViewTextBoxColumn
    Friend WithEvents TipoIntermediario As DataGridViewTextBoxColumn
    Friend WithEvents InicioVigencia As DataGridViewTextBoxColumn
    Friend WithEvents FinVigencia As DataGridViewTextBoxColumn
    Friend WithEvents FechaVenceReal As DataGridViewTextBoxColumn
    Friend WithEvents Endosada As DataGridViewTextBoxColumn
    Friend WithEvents BalanceGP As DataGridViewTextBoxColumn
    Friend WithEvents BalanceSF As DataGridViewTextBoxColumn
    Friend WithEvents Diferencia As DataGridViewTextBoxColumn
    Friend WithEvents NombreSupervisor As DataGridViewTextBoxColumn
    Friend WithEvents lblPasoProceso As Label
    Friend WithEvents txtPolizasFiltradas As TextBox
    Friend WithEvents lblPolizasFiltradas As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents txtTotalPolizas As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chkMostrarSeleccionadas As CheckBox
    Friend WithEvents txtTotalPolizasSeleccionadas As TextBox
    Friend WithEvents lblTotalPolizasSeleccionadas As Label
    Friend WithEvents btnProcesar As Button
    Friend WithEvents SysFlexSegurosDataSetBindingSource As BindingSource
    Friend WithEvents SysFlexSegurosDataSet As SysFlexSegurosDataSet
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents timerTiempoTranscurrido As Timer
End Class
