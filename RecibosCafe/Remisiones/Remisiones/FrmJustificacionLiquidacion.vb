Public Class FrmJustificacionLiquidacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    'Base de datos 
    Public sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
    'ids de los datos 
    Public IdLugarAcopio As Double = 0, IdProductor As Double, IdCalidad As Integer, IdCosecha As Integer, IdDano As Integer
    Public IdLocalidadLiqui As Integer, IdEdoFisico As Integer, IdTipoIngreso As Integer, IdTipoCompra As Integer
    Public IdCategoria As Integer, IdMunicipio As Integer, IdRegion As Integer, IdMoneda As Integer, IdEstaDocumento As Integer, IdTipoCambio As Integer
    'otras variables 
    Public SqlJustifica As Double, totalCor As Double, totalDol As Double, ImpMuniC As Double, ImpMuniD As Double, RetDefC As Double, RetDefD As Double
    Public Ret3C As Double, Ret3D As Double, valorCor As Double, ValorDol As Double, TotalDecC As Double, TotalDecD As Double, NetoPagarC As Double
    Public NetoPagarD As Double, Reten2C As Double, Reten2D As Double, Precio As Double, Fecha As Date
    Public count1 As Integer, count2 As Integer, PrecioAnterior As Double

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtJustifica.Click
        FrmTecladoLetras.ShowDialog()
        Me.TxtJustifica.Text = FrmTecladoLetras.EscrituraTeclado
    End Sub
    Private Sub FrmJustificacionLiquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Quien2 = "NoJustifica" Then
            Quien2 = ""
            Exit Sub
        End If

        Me.Location = New Point(250, 60)
        Me.DTPFechaJust.Value = Now
        Me.DTPFechaJust.Visible = False
        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.LblHoraJsut.Text = Format(Me.DTPFechaJust.Value, "HH:mm:ss")
        Me.TxtJustifica.Text = My.Forms.FrmLiquidacion.TxtjustSave.Text
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim Count As Double, countfalso As Double, i As Integer, SqlLiqui As String, codigoingre As String, NumEnsamble As String
        'Dim FechaLiqui As Date, StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, IdLiquida As String
        'Dim sql2 As String, IdAplicacion As String, IdtipoPago As String, SqlIdRecib As String, Idrecibo As String, StrSqlInsert As String
        'Dim IdJustificacion As Integer
        Dim TxtJustificacion As String

        If Me.TxtJustifica.Text = "" Then
            MsgBox("DESCRIBA EL MOTIVO DEL CAMBIO DE PRECIO", MsgBoxStyle.Critical, "Justifoca")
            Exit Sub
        Else
            My.Forms.FrmLiquidacion.TxtjustSave.Text = Me.TxtJustifica.Text
        End If

        'My.Forms.FrmLiquidacion.DtpFechaJustif.Value = Me.DTPFechaJust.Value


        'If Me.TxtJustifica.Text = "" Then
        '    MsgBox("ALGUNOS CAMPOS ESTAN VACIOS POR FAVOR REVISE LA INFORMACION", MsgBoxStyle.Critical, "JustificacionLiquidacion")
        '    Exit Sub
        'Else
        '    StrSqlInsert = "INSERT INTO [dbo].[JustificacionLiquidacionPergamino]([Justificacion],[FechaAutorizacion],[PrecioAnterior],[IdAutorizador],[IdLiquidacionPergamino]) VALUES   ('" & Me.TxtJustifica.Text & "',  '" & Me.DTPFechaJust.Value.Now & "','" & My.Forms.FrmLiquidacion.PrecioAnterior & "','" & IdUsuario & "','" & My.Forms.FrmLiquidacion.TxtIdLiquidacion.Text & "' )"
        '    MiConexion.Open()
        '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
        '    iResultado = ComandoUpdate.ExecuteNonQuery
        '    MiConexion.Close()
        '    MsgBox("GUARDAR JUSTICACION EXITOSA ", MsgBoxStyle.Exclamation, "Justifica Liquidacion")
        'End If
        Me.Close()
    End Sub

End Class
