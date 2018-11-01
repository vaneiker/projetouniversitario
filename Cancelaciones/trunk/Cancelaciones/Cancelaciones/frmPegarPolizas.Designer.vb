<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPegarPolizas
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
        Me.txtListaPolizas = New System.Windows.Forms.TextBox()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtListaPolizas
        '
        Me.txtListaPolizas.Location = New System.Drawing.Point(12, 12)
        Me.txtListaPolizas.Multiline = True
        Me.txtListaPolizas.Name = "txtListaPolizas"
        Me.txtListaPolizas.Size = New System.Drawing.Size(369, 203)
        Me.txtListaPolizas.TabIndex = 0
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Enabled = False
        Me.btnSeleccionar.Location = New System.Drawing.Point(12, 221)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionar.TabIndex = 1
        Me.btnSeleccionar.Text = "&Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(306, 221)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmPegarPolizas
        '
        Me.AcceptButton = Me.btnSeleccionar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(393, 250)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.txtListaPolizas)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPegarPolizas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pegar Lista Pólizas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtListaPolizas As System.Windows.Forms.TextBox
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
