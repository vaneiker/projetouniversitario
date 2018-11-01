Imports System
Imports System.Configuration
Imports System.Data.SqlClient


Public Class ProcesarCancelaciones

    Dim dt As New DataTable()
    Dim bindingSource1 As New BindingSource()
    Private Sub ProcesarCancelaciones_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ProgressBar1.Visible = False
       
        'Try
        '    MsgBox("UserName: " + Environment.UserDomainName + "\" + Environment.UserName)
        '    MsgBox("MachineName: " + Environment.MachineName)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Public Sub CargarDatos(Optional ByVal username As String = "AUTOMATICO")
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 40
        Me.Cursor = Cursors.WaitCursor


        Dim connectionString As String = GetConnectionString()
        Using connection As SqlConnection = _
          New SqlConnection(connectionString)
            connection.Open()
            Dim cmd As New SqlCommand("EXEC [dbo].[SPCCancelarPolizasAutomaticasNew_Listado]  30,'" & username & "',10,0", connection)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 600
            Dim da As New SqlDataAdapter(cmd)
            Try
                If dt.Rows.Count() > 0 Then
                    dt.Clear()
                End If
                da.Fill(dt)
                Me.ProgressBar1.Value = 80
                'Formato GRID
                GrdCancelaciones.AutoGenerateColumns = False

                'DATA BIND
                bindingSource1.DataSource = dt
                GrdCancelaciones.DataSource = bindingSource1

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Me.txtTotal.Text = dt.Rows.Count
        End Using
        Me.Cursor = Cursors.Default
        Me.ProgressBar1.Visible = False
    End Sub

    Private Function GetConnectionString() As String
        Return ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
    End Function

    Private Sub cmdProcesar_Click(sender As Object, e As EventArgs) Handles cmdProcesar.Click

        If MsgBox("Esta seguro de cancelar la(s) póliza(s) seleccionada(s)? ", MsgBoxStyle.OkCancel, "Cancelación en Lote") = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = 40
        Me.Cursor = Cursors.WaitCursor
        'Borrar tmpListaPoliza
        BorrarListaPoliza()

        'Insertar Poliza e Historico
        For Each Row As DataGridViewRow In GrdCancelaciones.Rows
            If Row.Cells(0).Value = True Then
                Row.Selected = True
            End If
        Next


        Dim UserLoggued As String = String.Empty
        UserLoggued = IIf(Environment.GetEnvironmentVariable("USERNAME") Is Nothing, "Administrador..", Environment.GetEnvironmentVariable("USERNAME"))

        For Each row As DataGridViewRow In GrdCancelaciones.SelectedRows
            Try
                ProcesarCancelaciones(row.Cells(1).Value.ToString(), UserLoggued)
                Me.GrdCancelaciones.Rows.Remove(row)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
        Me.ProgressBar1.Value = 80
        Try
            ProcesarCancelacionesFinal(UserLoggued)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        dt.AcceptChanges()
        GrdCancelaciones.Refresh()
        Me.txtTotal.Text = dt.Rows.Count()
        Me.Cursor = Cursors.Default
        Me.ProgressBar1.Visible = False
        MsgBox("Registros Procesados Satisfactoriamente")

    End Sub
    Public Sub ProcesarCancelacionesFinal(ByVal UserLoggued As String)
        Dim connectionString As String = GetConnectionString()

        Using connection As SqlConnection = _
           New SqlConnection(connectionString)
            connection.Open()
            Dim cmd As SqlCommand = New SqlCommand("EXEC SPCCancelarPolizasAutomaticasNew  30,'" & UserLoggued & "',10,1", connection)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 900

            Try
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Using

    End Sub

    Public Sub ProcesarCancelaciones(ByVal Poliza As String, ByVal UserLoggued As String)
        Dim connectionString As String = GetConnectionString()

        Using connection As SqlConnection = _
           New SqlConnection(connectionString)
            connection.Open()

            Dim cmd As SqlCommand = New SqlCommand("SP_ProcesarCancelaciones", connection)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Poliza", Poliza)
            cmd.Parameters.AddWithValue("@UserLoggued", UserLoggued)
            cmd.CommandTimeout = 600

            Try
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Using
    End Sub
    Public Sub BorrarListaPoliza()
        Dim connectionString As String = GetConnectionString()

        Using connection As SqlConnection = _
           New SqlConnection(connectionString)
            connection.Open()

            Dim cmd As SqlCommand = New SqlCommand("truncate table tmpListaPoliza", connection)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 600
            Try
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim UserLoggued As String = Environment.GetEnvironmentVariable("USERNAME")

        CargarDatos(UserLoggued)
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filt
        If Me.ComboBox1.SelectedIndex = 0 Then
            filt = String.Format("Beneficiario Like '{0}%'", txtFiltro.Text)
        ElseIf Me.ComboBox1.SelectedIndex = 1 Then
            filt = String.Format("NombreCliente Like '{0}%'", txtFiltro.Text)
        ElseIf Me.ComboBox1.SelectedIndex = 2 Then
            filt = String.Format("NombreIntermediario Like '{0}%'", txtFiltro.Text)
        ElseIf Me.ComboBox1.SelectedIndex = 3 Then
            filt = String.Format("TipoIntermediario Like '{0}%'", txtFiltro.Text)
        ElseIf Me.ComboBox1.SelectedIndex = 4 Then
            filt = String.Format("NombreSupervisor Like '{0}%'", txtFiltro.Text)
        End If
        bindingSource1.Filter = filt
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
