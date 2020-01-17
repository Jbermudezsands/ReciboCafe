Public Class FrmLocalidad
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public NomLugarAcopioDefecto As String, IdLugarAcopioDefecto As Double, CodLugarAcopioDefecto As String
    Private Sub FrmLocalidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT CodLugarAcopio, NomLugarAcopio, IdLugarAcopio FROM LugarAcopio WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidades")
        If DataSet.Tables("Localidades").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        End If

        Me.CboLocalidad.DataSource = DataSet.Tables("Localidades")
        Me.CboLocalidad.Text = NomLugarAcopioDefecto
        Me.CboLocalidad.Splits(0).DisplayColumns(1).Width = 400
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Quien = "Localidad"
        My.Forms.FrmConsultas.Text = "Consulta Localidad"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA LOCALIDAD"

        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Quien = "Consulta"
            Me.CboLocalidad.Text = My.Forms.FrmConsultas.Descripcion
        End If
    End Sub

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        My.Forms.FrmRecepcion.CboLocalidad.Text = Me.CboLocalidad.Text
        My.Forms.FrmRecepcion.IdLugarAcopio = Me.CboLocalidad.Columns(2).Text
        My.Forms.FrmRecepcion.CboLiquidarLocalidad.Text = Me.CboLocalidad.Text
        My.Forms.FrmRecepcion.TxtIdLocalidad.Text = Me.CboLocalidad.Columns(0).Text
        My.Forms.FrmRecepcion.LblSucursal.Text = Me.CboLocalidad.Text

        Me.Close()
    End Sub
End Class