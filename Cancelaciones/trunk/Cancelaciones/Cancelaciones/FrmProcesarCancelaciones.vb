Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Linq
Imports System.IO
Imports System.Text

Public Class FrmProcesarCancelaciones

    Dim dt As New DataTable()
    Dim dtReglaSiniestro As New DataTable()
    Dim bindingSource1 As New BindingSource()

    Dim _HoraInicialProceso As DateTime

    Dim Hilo1, Hilo2 As Thread

    Public Shared lstPolizasSeleccionadas As New HashSet(Of String)
    Dim frmPegarPolizas As frmPegarPolizas

    Dim dtp As New DateTimePicker()



#Region "Events"




    Private Sub BtnCargarDatos_Click(sender As Object, e As EventArgs) Handles BtnCargarDatos.Click

    End Sub

    Private Sub btnProcesar_KeyPress_1(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        MessageBox.Show("Esto es una Prueba")
    End Sub

    Private Sub SysFlexSegurosDataSetBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles SysFlexSegurosDataSetBindingSource.CurrentChanged

    End Sub

    Private Sub TabControCancelarPorPagos_Click(sender As Object, e As EventArgs) Handles TabControCancelarPorPagos.Click

    End Sub

#End Region
End Class