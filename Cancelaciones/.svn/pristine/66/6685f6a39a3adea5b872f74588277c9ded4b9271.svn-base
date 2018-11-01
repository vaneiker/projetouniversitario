Public Class frmPegarPolizas


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
   
        CierraFormulario()

    End Sub

    Private Sub txtListaPolizas_TextChanged(sender As Object, e As EventArgs) Handles txtListaPolizas.TextChanged

        If txtListaPolizas.Text.Length >= 5 Then btnSeleccionar.Enabled = True Else btnSeleccionar.Enabled = False


    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        For linea As Integer = 0 To txtListaPolizas.Lines.Count - 1
            ProcesarCancelaciones.SeleccionarPoliza(txtListaPolizas.Lines(linea))

        Next

        CierraFormulario()

    End Sub

    Public Sub CierraFormulario()
        'Me.Hide()
        Me.Close()
        'Me.Dispose()
    End Sub
End Class