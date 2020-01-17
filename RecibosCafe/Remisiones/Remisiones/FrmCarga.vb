

Public Class FrmCarga
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Dim IdSucursal As Double = 0, dt As New DataTable
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub FrmCarga_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.DTPFecha.Value = Now
        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub FrmCarga_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.TxtNBoleta.Text = ""
    End Sub

    Private Sub FrmCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Ruta As String, LeeArchivo As String
        Dim ConsecutivoCompra As Double, NumeroCarga As String, CodLugarAcopio As Double = 0
        Dim SqlProveedor As String
        Dim CodigoSubProveedor As String = "", CodConductor As String



        sql = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("Conductor")
        End If

        Me.CboCodigoProveedor.Splits(0).DisplayColumns(1).Width = 200


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
            CodLugarAcopio = DataSet.Tables("Localidad").Rows(0)("CodLugarAcopio")
            IdSucursal = LeeArchivo
            'Me.IdLugarAcopio.Text = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
        End If


        '//////////////////////////////////////////////////////////COSECHA ///////////////////////////////////////////////////

        'Fecha = Format(Now, "yyyy-MM-dd")
        'Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        'SqlString = "SELECT *, YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (FechaInicial <= CONVERT(DATETIME, '" & Fecha & "', 102)) AND (FechaFinal >= CONVERT(DATETIME, '" & Fecha & "', 102))"
        SqlString = "SELECT IdCosecha, CodCosecha, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CDbl(CodigoCosecha) & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count = 0 Then
            Me.LblCosecha.Text = "Cosecha NO DEFINIDA"
        Else
            Me.LblCosecha.Text = "Cosecha " & DataSet.Tables("Cosecha").Rows(0)("AñoIni") & "-" & DataSet.Tables("Cosecha").Rows(0)("AñoFin")
        End If

        '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
        SqlString = "SELECT Placa FROM Vehiculo"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.TxtPlaca.DataSource = DataSet.Tables("Placa")
        Me.TxtPlaca.Splits.Item(0).DisplayColumns(0).Width = 90


        '/////////////////////////////////////////////////////CREO EL CONSECUTIVO DE CARGAR //////////////////////////////////////////////
        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then

            ConsecutivoCompra = BuscaConsecutivo("Entrada", CodLugarAcopio)
            NumeroCarga = CodLugarAcopio & "-" & Format(ConsecutivoCompra, "00000#")
        Else
            NumeroCarga = Me.TxtNumeroEnsamble.Text
        End If



        Me.TxtNumeroEnsamble.Text = NumeroCarga


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'Sql = "SELECT Recepcion.NumeroRecepcion, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.Seleccion, Proveedor.Cod_Proveedor FROM  Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor  WHERE(Recepcion.Activo = 1) AND (Recepcion.TipoRecepcion = 'Recepcion')"
        sql = "SELECT Recepcion.NumeroRecepcion, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.Seleccion,  Proveedor.Cod_Proveedor, LugarAcopio.NomLugarAcopio FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN LugarAcopio ON Recepcion.IdLugarAcopio = LugarAcopio.IdLugarAcopio " & _
              "WHERE  (Recepcion.Activo = 1) AND (Recepcion.TipoRecepcion = 'Recepcionvv') ORDER BY Recepcion.IdLugarAcopio"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        Me.BindingDetalle.DataSource = DataSet.Tables("Detalle")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 600
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 250
        Me.TrueDBGridComponentes.RowHeight = 40

        dt = DataSet.Tables("Detalle")


    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        Me.TxtNBoleta.Text = ""
        Me.Close()
    End Sub

    Private Sub CboCodigoProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.Click

    End Sub

    Private Sub CboCodigoProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.DoubleClick
        FrmTeclado.ShowDialog()
        Me.CboCodigoProveedor.Text = FrmTeclado.Numero
    End Sub

    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlString As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.txtnombre.Text = Me.CboCodigoProveedor.Columns(1).Text


        '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////

        SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo  " & _
        "WHERE (EmpresaTransporte.Codigo = '" & Me.CboCodigoProveedor.Text & "') AND (EmpresaTransporte.Activo = 1) AND (VehiculoEmpresaTransporte.Activo = 1)"

        'SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN  Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN IndiceCarga ON Vehiculo.Placa = IndiceCarga.Placa " & _
        '             "WHERE (EmpresaTransporte.Codigo = '" & Me.CboCodigoProveedor.Text & "')"

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Placa")
        Me.TxtPlaca.DataSource = Dataset.Tables("Placa")
        Me.TxtPlaca.Splits.Item(0).DisplayColumns(0).Width = 90

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = "", CodConductor As String
        Dim Sql As String
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'Sql = "SELECT Recepcion.NumeroRecepcion, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.Seleccion, Proveedor.Cod_Proveedor FROM  Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor  WHERE(Recepcion.Activo = 1) AND (Recepcion.TipoRecepcion = 'Recepcion')"
        'Sql = "SELECT Recepcion.NumeroReciboCafe, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.Seleccion,  Proveedor.Cod_Proveedor, LugarAcopio.NomLugarAcopio, Recepcion.NumeroRecepcion FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN LugarAcopio ON Recepcion.IdLugarAcopio = LugarAcopio.IdLugarAcopio " & _
        '"WHERE  (Recepcion.Activo = 1) AND (Recepcion.TipoRecepcion = 'Recepcion') ORDER BY Recepcion.Fecha, Recepcion.NumeroReciboCafe"
        Sql = "SELECT Recepcion.NumeroReciboCafe, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.Seleccion, Proveedor.Cod_Proveedor, LugarAcopio.NomLugarAcopio, Recepcion.NumeroRecepcion FROM  Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN LugarAcopio ON Recepcion.IdLugarAcopio = LugarAcopio.IdLugarAcopio INNER JOIN  ReciboCafePergamino ON Recepcion.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Recepcion.Activo = 1) AND (Recepcion.TipoRecepcion = 'Recepcion') AND (ReciboCafePergamino.IdEstadoDocumento = 294) ORDER BY Recepcion.Fecha, Recepcion.NumeroReciboCafe"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Detalle")
        Me.BindingDetalle.DataSource = DataSet.Tables("Detalle")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 600
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 250
        Me.TrueDBGridComponentes.RowHeight = 40

        dt = DataSet.Tables("Detalle")

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim ConsecutivoCompra As Double, NumeroCarga As String, Filtro As String = "(Seleccion = 1)"
        Dim NumeroRecepcion As String, FechaRecepcion As Date, TipoRecepcion As String = "Recepcion"
        Dim foundRows() As DataRow, i As Double = 0
        Dim Fecha As Date = Format(Me.DTPFecha.Value, "dd/MM/yyyy HH:mm")
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim IdLocalidad As Double, CodLugarAcopio As Double = 0
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SQlUpdate As String



        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            MsgBox("Seleccione un Numero de Carga", MsgBoxStyle.Critical, "Zeus")
            Exit Sub
        End If

        If Me.TxtNumeroEnsamble.Text = "" Then
            MsgBox("Seleccione un Numero de Carga", MsgBoxStyle.Critical, "Zeus")
            Exit Sub
        End If

        If Me.TxtPlaca.Text = "" Then
            MsgBox("Seleccione un Numero de Placa", MsgBoxStyle.Critical, "Zeus Contable")
            Exit Sub
        End If

        SqlString = "SELECT LugarAcopio.* FROM LugarAcopio WHERE (CodLugarAcopio = " & IdSucursal & ") AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "LugarAcopio")
        If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
            IdLocalidad = DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
            CodLugarAcopio = DataSet.Tables("LugarAcopio").Rows(0)("CodLugarAcopio")
        End If


        '//////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////BUSCAR SI EL CONDUCTOR YA REGISTRO SU LLEGADA ////////////
        '/////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta, DATEDIFF(hh, Fecha, CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS Horas FROM Registros WHERE (TipoRegistro = 'Llegada') AND (Placa = '" & Me.TxtPlaca.Text & "') AND (NumeroBoleta = '" & Me.TxtNBoleta.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta2")
        If DataSet.Tables("Consulta2").Rows.Count = 0 Then
            MsgBox("No Existe Registro de llegada para este camion", MsgBoxStyle.Critical, " Zeus ")
            Exit Sub
        End If


        SqlString = "SELECT  * FROM IndiceCarga WHERE (CodCarga = '" & Me.TxtNumeroEnsamble.Text & "  ') AND (Cerrado = 0)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            If Me.TxtPlaca.Text <> DataSet.Tables("Consulta").Rows(0)("Placa") Then
                MsgBox("No es el mismo camion utilizado para la carga", MsgBoxStyle.Critical, " Zeus ")
                Exit Sub
            End If
        End If



        NumeroCarga = 0
        foundRows = dt.Select(Filtro)
        For Each dr As DataRow In foundRows

            If i = 0 Then
                If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                    ConsecutivoCompra = BuscaConsecutivo("Carga", CodLugarAcopio)
                    NumeroCarga = Format(ConsecutivoCompra, "0000#")
                Else
                    NumeroCarga = Me.TxtNumeroEnsamble.Text
                End If

                GrabaCarga(NumeroCarga, Me.CboCodigoProveedor.Text, IdLocalidad, Fecha, Me.TxtPlaca.Text)

                i = 1
            End If


            NumeroRecepcion = CStr(dr("NumeroRecepcion"))
            FechaRecepcion = dr("Fecha")
            GrabaDetalleCarga(NumeroCarga, NumeroRecepcion, FechaRecepcion, IdLocalidad)
            ActualizaEstadoRecepcion(NumeroRecepcion, FechaRecepcion, False, Me.TxtNumeroEnsamble.Text)

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////ACTUALIZO LA TABLA REPORTA ///////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            SQlUpdate = "UPDATE [Reporta] SET [NumeroBoleta] = '" & Me.TxtNumeroEnsamble.Text & "' WHERE (IdReportaExistencia IN (SELECT IdReporta FROM DetalleReporta  WHERE  (NumeroRecepcion = '" & NumeroRecepcion & "')))"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Next


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////BUSCO EL ULTIMO REGISTRO DE LLEGADA QUE NO TENGA BOLETA //////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros " & _
                    "WHERE (TipoRegistro = 'Llegada') AND (IdLugarAcopio = " & IdLocalidad & ") AND (Placa = '" & Me.TxtPlaca.Text & "') AND (NumeroBoleta IS NULL)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Llegada")
        If DataSet.Tables("Llegada").Rows.Count <> 0 Then
            MiConexion.Close()
            SQlUpdate = "UPDATE [Registros] SET [NumeroBoleta] = '" & Me.TxtNumeroEnsamble.Text & "' " & _
                        "WHERE (TipoRegistro = 'Llegada') AND (IdLugarAcopio = " & IdLocalidad & ") AND (Placa = '" & Me.TxtPlaca.Text & "') AND (NumeroBoleta IS NULL)"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If






        If i = 1 Then
            MsgBox("Se Grabo la Carga No." & NumeroCarga, MsgBoxStyle.Exclamation, "Sistema")
            Button1_Click(sender, e)
        End If

        Me.TxtNumeroEnsamble.Text = "-----0-----"
        Me.TxtNBoleta.Text = ""
        NumeroCarga = ""

    End Sub

    Private Sub TxtNumeroEnsamble_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.Click
        My.Forms.FrmTeclado.ShowDialog()
        Me.TxtNumeroEnsamble.Text = My.Forms.FrmTeclado.Numero
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "Conductor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
        Me.txtnombre.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim items As C1.Win.C1TrueDBGrid.ValueItems = Me.TrueDBGridComponentes.Columns("Seleccion").ValueItems
        Dim iPosicion As Double, Valor As Boolean, NumeroRecepcion As String
        Dim SqlString As String, Fecha As Date, Fecha2 As Date, Respuesta As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If e.ColIndex = 3 Then
            iPosicion = Me.BindingDetalle.Position
            Valor = Me.BindingDetalle.Item(iPosicion)("Seleccion")

            If Valor = True Then
                Quien = "RePesaje"
                CodigoRepesaje = Me.BindingDetalle.Item(iPosicion)("NumeroRecepcion")
                NumeroRecepcion = Me.BindingDetalle.Item(iPosicion)("NumeroRecepcion")

                '///////////////////////////////////CONSULTA LA RECEPCION ///////////////////////////////////////////////////////////
                SqlString = "SELECT FechaHora FROM Recepcion WHERE (NumeroRecepcion = '" & NumeroRecepcion & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("FechaHora")) Then
                        Fecha = DataSet.Tables("Consulta").Rows(0)("FechaHora")
                        Fecha2 = Me.DTPFecha.Value

                        If DateDiff(DateInterval.Hour, Fecha, Fecha2) > 2 Then
                            My.Forms.FrmRecepcion.CboCodigoProveedor.Text = Me.BindingDetalle.Item(iPosicion)("Cod_Proveedor")
                            My.Forms.FrmRecepcion.ShowDialog()
                        Else
                            Respuesta = MsgBox("Desea Repesar?, Tiempo menor a dos horas", MsgBoxStyle.YesNo, "Sistema Recepcion")
                            If Respuesta = 6 Then
                                My.Forms.FrmRecepcion.CboCodigoProveedor.Text = Me.BindingDetalle.Item(iPosicion)("Cod_Proveedor")
                                My.Forms.FrmRecepcion.ShowDialog()
                            Else
                                Exit Sub
                            End If

                        End If

                    End If

                End If


            End If

        End If
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT  * FROM IndiceCarga WHERE (CodCarga = '" & Me.TxtNumeroEnsamble.Text & "  ') AND (Cerrado = 0)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            If Me.TxtPlaca.Text <> DataSet.Tables("Consulta").Rows(0)("Placa") Then
                MsgBox("No es el mismo camion utilizado para la carga", MsgBoxStyle.Critical, " Zeus ")
                e.Cancel = True
                Exit Sub
            End If
        End If

    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        FrmTeclado.ShowDialog()
        Me.CboCodigoProveedor.Text = FrmTeclado.Numero
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "Transportista"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
        Me.txtnombre.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub TxtPlaca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPlaca.TextChanged
        Dim SqlString As String, NumeroPlaca As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.TxtPlaca.Text = "" Then
            Exit Sub
        End If

        NumeroPlaca = Me.TxtPlaca.Text

        If Me.TxtNBoleta.Text = "" Then
            Exit Sub
        End If

        '//////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////BUSCAR SI EL CONDUCTOR YA REGISTRO SU LLEGADA ////////////
        '/////////////////////////////////////////////////////////////////////////////////////

        SqlString = "SELECT  IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta, DATEDIFF(hh, Fecha, CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS Horas FROM Registros WHERE (TipoRegistro = 'Llegada') AND (Placa = '" & NumeroPlaca & "') AND (NumeroBoleta = '" & Me.TxtNBoleta.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta2")
        If DataSet.Tables("Consulta2").Rows.Count = 0 Then
            MsgBox("No Existe Registro de llegada para este camion", MsgBoxStyle.Critical, " Zeus ")
            Me.Button1.Enabled = False
            Me.Button7.Enabled = False
        Else
            Me.Button1.Enabled = True
            Me.Button7.Enabled = True

        End If

        'SqlString = "SELECT IdRegistro, TipoRegistro, Placa, Fecha  FROM Registros WHERE (Placa = '" & NumeroPlaca & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Now, "yyyy-MM-dd") & "', 102))"
        'SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (TipoRegistro = 'Llegada') AND (Placa = '" & NumeroPlaca & "') AND (Fecha BETWEEN CONVERT(DATETIME, '" & Format(Now, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(Now, "yyyy-MM-dd") & " 23:59:59', 102))"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Placa")
        'If DataSet.Tables("Placa").Rows.Count = 0 Then
        '    MsgBox("Debe Registrar su llegada", MsgBoxStyle.Critical, "Recepcion")
        '    Me.Button1.Enabled = False
        '    Me.Button7.Enabled = False
        'Else
        '    Me.Button1.Enabled = True
        '    Me.Button7.Enabled = True

        'End If



    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNBoleta.Click
        My.Forms.FrmTeclado.ShowDialog()
        Me.TxtNBoleta.Text = My.Forms.FrmTeclado.Numero
    End Sub

    Private Sub TxtNBoleta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNBoleta.TextChanged
        Dim SqlString As String, NumeroPlaca As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If Me.TxtPlaca.Text = "" Then
            Exit Sub
        End If

        NumeroPlaca = Me.TxtPlaca.Text

        If Me.TxtNBoleta.Text = "" Then
            Exit Sub
        End If

        '//////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////BUSCAR SI EL CONDUCTOR YA REGISTRO SU LLEGADA ////////////
        '/////////////////////////////////////////////////////////////////////////////////////

        SqlString = "SELECT  IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta, DATEDIFF(hh, Fecha, CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS Horas FROM Registros WHERE (TipoRegistro = 'Llegada') AND (Placa = '" & NumeroPlaca & "') AND (NumeroBoleta = '" & Me.TxtNBoleta.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta2")
        If DataSet.Tables("Consulta2").Rows.Count = 0 Then
            MsgBox("No Existe Registro de llegada para este camion", MsgBoxStyle.Critical, " Zeus ")
            Me.Button1.Enabled = False
            Me.Button7.Enabled = False
        Else
            Me.Button1.Enabled = True
            Me.Button7.Enabled = True

        End If
    End Sub
End Class