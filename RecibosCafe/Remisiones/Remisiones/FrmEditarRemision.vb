Public Class FrmEditarRemision
    Public DataSet As New DataSet, Codigo As String
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmEditarRemision_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'MDIParent1.Button1.Visible = True
        'MDIParent1.Button2.Visible = True
        'MDIParent1.Button3.Visible = True
    End Sub

    Private Sub FrmEditarRemision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DtFecha.Value = Now
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FrmConsultas.ShowDialog()
        Me.TxtCodigoTiket.Text = FrmConsultas.Codigo
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TxtCodigoTiket_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoTiket.TextChanged
        Dim SQL As String = "SELECT CodigoRemision, Fecha, IdLugarAcopio, NumeroBoleta, IdEmpresaTransporte, Placa, IdLugarAcopioChequeo, IdCosecha, IdLocalidadChequeo, IdVehiculo FROM PuntoRevision  WHERE (CodigoRemision = " & Me.TxtCodigoTiket.Text & ")"
        Dim DataAdapter As New SqlClient.SqlDataAdapter, CodigoTransportista As String

        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")



        If Not DataSet.Tables("Consultas").Rows.Count = 0 Then
            Dim SqlString As String


            CodigoTransportista = Dataset.Tables("Consultas").Rows(0)("IdEmpresaTransporte")

            '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
            'SqlString = "SELECT DISTINCT Vehiculo.Placa FROM Conductor INNER JOIN EmpresaTransporte ON Conductor.IdCompany = EmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON EmpresaTransporte.IdEmpresaTransporte = Vehiculo.IdCompany WHERE (EmpresaTransporte.Codigo = '" & Me.TxtCodigo.Text & "')"
            'SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo  " & _
            '            "WHERE (EmpresaTransporte.Codigo = '" & CodigoTransportista & "')"
            SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo WHERE (EmpresaTransporte.IdEmpresaTransporte = " & CodigoTransportista & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(Dataset, "Placa")
            Me.TxtPlaca.DataSource = Dataset.Tables("Placa")
            Me.TxtPlaca.Splits.Item(0).DisplayColumns(0).Width = 90



            Me.DtFecha.Value = DataSet.Tables("Consultas").Rows(0)("Fecha")
            Me.TxtPlaca.Text = DataSet.Tables("Consultas").Rows(0)("Placa")

        End If
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        MiConexion.Open()
        StrSqlUpdate = "UPDATE [PuntoRevision] SET [Fecha] = '" & Format(Me.DtFecha.Value, "dd/MM/yyyy H:mm:ss") & "' ,[Placa] = '" & Me.TxtPlaca.Text & "'  WHERE (CodigoRemision = " & Me.TxtCodigoTiket.Text & ")"
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()
        MsgBox("Registros Actualizados", MsgBoxStyle.Exclamation, "Sistema Facturacion")

        Me.Close()
    End Sub
End Class