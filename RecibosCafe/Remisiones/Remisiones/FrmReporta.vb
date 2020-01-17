Public Class FrmReporta

    Public MiConexion As New SqlClient.SqlConnection(Conexion), Hora As Date
    Dim IdSucursal As Integer = 0, dt As New DataTable, IdLugarAcopio As Integer

    Private Sub FrmReporta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Ruta As String, LeeArchivo As String
        Dim SqlProveedor As String
        Dim CodigoSubProveedor As String = "", CodConductor As String

        Me.DTPFecha.Value = Now
        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")


        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If


        'LeeArchivo = LeeArchivo.Replace(" "c, String.Empty)
        LeeArchivo = Mid(LeeArchivo, 1, 3)

        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & LeeArchivo & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad")
        If DataSet.Tables("Localidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
            IdLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
        End If


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'sql = "SELECT Recepcion.NumeroReciboCafe , Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.SeleccionReportada, Proveedor.Cod_Proveedor, Recepcion.NumeroRecepcion FROM  Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor  WHERE(Recepcion.Activo = 1) AND (Recepcion.TipoRecepcion = 'Recepcion') AND (Recepcion.Reportada = 'False') ORDER BY Recepcion.Fecha, Recepcion.NumeroReciboCafe"
        sql = "SELECT Recepcion.NumeroReciboCafe, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.SeleccionReportada, Proveedor.Cod_Proveedor, Recepcion.NumeroRecepcion FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN ReciboCafePergamino ON Recepcion.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Recepcion.Activo = 1) AND (Recepcion.TipoRecepcion = 'Recepcion') AND (Recepcion.Reportada = 'False') AND (ReciboCafePergamino.IdEstadoDocumento = 294) ORDER BY Recepcion.Fecha, Recepcion.NumeroReciboCafe"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        Me.BindingDetalle.DataSource = DataSet.Tables("Detalle")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 600
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TrueDBGridComponentes.RowHeight = 40
        'Me.TrueDBGridComponentes.Font = New Font("Arial", 20)
        'Me.TrueDBGridComponentes.Columns(3).

        dt = DataSet.Tables("Detalle")


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "Recepcion"
        My.Forms.FrmConsultas.ShowDialog()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim SQLProductos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim CodBodega As String = "", CodRubro As String = "", Iposicion = 0, Reintegro As Integer
        Dim Fecha As Date, Sqlstring As String, Consecutivo As Double, Numero
        Dim Filtro As String = "(SeleccionReportada = 1)", foundRows() As DataRow, NumeroRecepcion As String, FechaRecepcion As Date, IdReporta As Double
        Dim Registros As Double = 0, Sql As String

        Fecha = Me.LblFecha.Text & " " & Format(Hora, "HH:mm:ss")

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////BUSCO EL CONSECUTIVO ////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sqlstring = "SELECT Consecutivos.*  FROM Consecutivos"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consecutivos")
        If DataSet.Tables("Consecutivos").Rows.Count <> 0 Then
            Consecutivo = DataSet.Tables("Consecutivos").Rows(0)("Reporta") + 1
        Else
            Consecutivo = 1
        End If




        '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
        StrSqlUpdate = "INSERT INTO [Reporta] ([ReportaExistencia],[FechaReporta],[IdLugarAcopio])  VALUES ('" & Consecutivo & "' , '" & Format(Fecha, "dd/MM/yyyy HH:mm:ss") & "', " & IdLugarAcopio & ")"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////BUSCO EL CONSECUTIVO ////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sqlstring = "SELECT IdReportaExistencia FROM Reporta ORDER BY IdReportaExistencia DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "ConsecutivosId")
        Registros = DataSet.Tables("ConsecutivosId").Rows.Count
        If DataSet.Tables("ConsecutivosId").Rows.Count <> 0 Then
            IdReporta = DataSet.Tables("ConsecutivosId").Rows(0)("IdReportaExistencia")
        Else
            IdReporta = 1
        End If


        MiConexion.Close()
        foundRows = dt.Select(Filtro)
        For Each dr As DataRow In foundRows

            NumeroRecepcion = CStr(dr("NumeroRecepcion"))
            FechaRecepcion = dr("Fecha")


            MiConexion.Close()
            StrSqlUpdate = "INSERT INTO [DetalleReporta]  ([IdReporta],[NumeroRecepcion])  VALUES (" & IdReporta & ", '" & NumeroRecepcion & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////ACTUALIZO LAS RECEPCIONES ////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            StrSqlUpdate = "UPDATE [Recepcion]  SET [Reportada] = 1 WHERE  (NumeroRecepcion ='" & NumeroRecepcion & "') AND (TipoRecepcion = 'Recepcion')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()



        Next


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT Recepcion.NumeroReciboCafe, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.SeleccionReportada, Proveedor.Cod_Proveedor, Recepcion.NumeroRecepcion FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN ReciboCafePergamino ON Recepcion.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Recepcion.Activo = 1) AND (Recepcion.TipoRecepcion = 'Recepcion') AND (Recepcion.Reportada = 'False') AND (ReciboCafePergamino.IdEstadoDocumento = 294) ORDER BY Recepcion.Fecha, Recepcion.NumeroReciboCafe"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        Me.BindingDetalle.DataSource = DataSet.Tables("Detalle")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 600
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TrueDBGridComponentes.RowHeight = 40

        dt = DataSet.Tables("Detalle")


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Hora = Date.Now.ToLongTimeString
        Me.LblHora.Text = Hora
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub
End Class