Public Class FrmConsultasLiqui
    Public DataSet As New DataSet, TipoEnsamble As String, CodIva As String, TipoCompra As String, CodCajero As String, Nombres As String, Apellidos As String
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Codigo As String, Codigo1 As String, Descripcion As String, TipoProducto As String, CodComponente As Double, Precio As Double
    Public Cantidad As Double, CodProducto As String, Fecha As Date, CodigoCliente As String, SqlRemision As String, NumeroRecibo As String, IdReciboCafe As Double = 0
    Public DescripcionImpuestos As String, TasaImpuestos As Double, TipoImpuesto As String, Conductor As String, CodProveedor As String, CodigoProceso As String, DescripcionProceso As String, Filtro As String, NumeroRecepcion As String
    Public IdLugarAcopio As Double
    Private Function getFilter() As String
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Dim tmp As String = ""
        Dim n As Integer

        For Each col In Me.TrueDBGridConsultas.Columns

            If Trim(col.FilterText) <> "" Then
                n = n + 1
                If n > 1 Then
                    tmp = tmp & " AND "
                End If
                tmp = tmp & col.DataField & " LIKE '" & col.FilterText & "*'"
            End If
        Next col
        getFilter = tmp

    End Function

    Private Sub TrueDBGridConsultas_FilterChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridConsultas.FilterChange
        Dim sb As New System.Text.StringBuilder()
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn


        For Each dc In Me.TrueDBGridConsultas.Columns
            If dc.FilterText.Length > 0 Then
                If sb.Length > 0 Then
                    sb.Append(" AND ")
                End If
                sb.Append((dc.DataField + " LIKE " + "'%" + dc.FilterText + "%'"))
            End If
        Next

        If sb.ToString <> "" Then
            DataSet.Tables("Consultas").DefaultView.RowFilter = sb.ToString
        End If
    End Sub

    Private Sub FrmConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DataSet.Reset()

            Me.CmdPesada.Visible = False

            MiConexion.Close()
            Me.TrueDBGridConsultas.AllowUpdate = False

            Dim DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String
            Select Case Quien
                Case "Localidad"

                    SQlProductos = "SELECT CodLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE(Activo=1)"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 400
                    MiConexion.Close()

                Case "Transportista"
                    SQlProductos = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Nombre"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Nombre Transportista"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 400

                    MiConexion.Close()


                Case "Conductor"
                    SQlProductos = "SELECT Codigo, Nombre, Cedula FROM  Conductor"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Nombre"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Nombre Conductor"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Cedula"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65


                    MiConexion.Close()
                Case "CodigoProductosDetalle"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Costo_Promedio, Existencia_Unidades,Cod_Iva FROM Productos Where (Tipo_Producto <> 'Ensambles')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Costo Prom"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False

                    MiConexion.Close()

                Case "Recepcion"
                    'SQlProductos = "SELECT Recepcion.NumeroReciboCafe , Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Conductor, Proveedor.Cod_Proveedor,Recepcion.TipoRecepcion, Recepcion.NumeroRecepcion, Recepcion.IdReciboPergamino FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor " & _
                    '               "WHERE(Recepcion.Cancelar = 0) AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "') ORDER BY Recepcion.Fecha, Recepcion.NumeroReciboCafe"

                    SQlProductos = "SELECT Recepcion.NumeroReciboCafe, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Recepcion.Conductor, Proveedor.Cod_Proveedor, Recepcion.TipoRecepcion, Recepcion.NumeroRecepcion, Recepcion.IdReciboPergamino FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN ReciboCafePergamino ON Recepcion.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino  " & _
                                   "WHERE (Recepcion.Cancelar = 0) AND (Recepcion.TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "') ORDER BY Recepcion.Fecha, Recepcion.NumeroReciboCafe"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Recibos"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Proveedor"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 150
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Visible = False

                Case "RecepcionBin"
                    SQlProductos = "SELECT Recepcion.NumeroReciboCafe, Recepcion.Fecha, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, Conductor, Proveedor.Cod_Proveedor,Recepcion.TipoRecepcion, Recepcion.NumeroRecepcion FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor " & _
                                   "WHERE(Recepcion.Cancelar = 0) AND (Recepcion.TipoRecepcion = 'BIN') ORDER BY Recepcion.NumeroRecepcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Recepcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Proveedor"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 150
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False

                Case "CodigoBeamsRecepcion"
                    SQlProductos = "SELECT NumeroRecepcion, CodigoBin, Conductor, Peso FROM Recepcion WHERE (Activo = 1) AND (CodigoBin IS NOT NULL)"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Numero Rec"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Codigo Bin"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Numero Rec"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Codigo Bin"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170

                Case "CodigoBeams"
                    SQlProductos = "SELECT Codigo_Beams, Descripcion_Beams  FROM Beams ORDER BY Codigo_Beams"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170

                Case "SalidaBodegaDolares"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Costo_Promedio_Dolar, Existencia_Unidades,Cod_Iva FROM Productos "
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 170
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Precio $"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    MiConexion.Close()

                Case "Liquidacion"
                    SQlProductos = "SELECT LiquidacionPergamino.Codigo, LiquidacionPergamino.Fecha, LiquidacionPergamino.Precio, TipoCompra.Nombre AS TipoCompra, TipoIngreso.Descripcion AS TipoIngreso, LugarAcopio.NomLugarAcopio AS Localiad, EstadoDocumento.Descripcion AS Estado,  LiquidacionPergamino.IdEstadoDocumento,LiquidacionPergamino.IdLiquidacionPergamino   FROM    LiquidacionPergamino INNER JOIN     TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN     TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS  INNER JOIN  LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento WHERE  (LiquidacionPergamino.IdEstadoDocumento = 293 OR  LiquidacionPergamino.IdEstadoDocumento = 294)"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "Proveedor"
                    SQlProductos = "SELECT Cod_Proveedor, Nombre_Proveedor + ' ' + Apellido_Proveedor AS NombreProveedor, Cedula AS Identificacion FROM  Proveedor"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    MiConexion.Close()

                    Me.TrueDBGridConsultas.Columns("Cod_Proveedor").Caption = "Codigo"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Cod_Proveedor").Width = 70
                    Me.TrueDBGridConsultas.Columns("NombreProveedor").Caption = "Nombre Proveedor"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NombreProveedor").Width = 300


                Case "Remision"

                    'SqlRemision = " SELECT  RemisionPergamino.IdRemisionPergamino, RemisionPergamino.Serie + ' ' + RemisionPergamino.Codigo AS Numero, RemisionPergamino.Fecha, EstadoDocumento.Descripcion AS Estado, TipoCafe.Nombre AS TipoRemision,                           Calidad.NomCalidad AS Calidad, LugarAcopio.NomLugarAcopio, EmpresaTransporte.NombreEmpresa, Vehiculo.Placa, Conductor.Nombre AS Conductor, RemisionPergamino.FechaCarga, RemisionPergamino.HoraSalida,                           RemisionPergamino.IdTipoCafe FROM            RemisionPergamino INNER JOIN                          EstadoDocumento ON RemisionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          TipoCafe ON RemisionPergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN                          Calidad ON RemisionPergamino.IdCalidad = Calidad.IdCalidad INNER JOIN                          LugarAcopio ON RemisionPergamino.IdLugarAcopio = LugarAcopio.IdLugarAcopio INNER JOIN                          EmpresaTransporte ON RemisionPergamino.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN                          Vehiculo ON RemisionPergamino.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN                          Conductor ON RemisionPergamino.IdConductor = Conductor.IdConductor WHERE        (RemisionPergamino.IdTipoCafe = '" & My.Forms.FrmRemision2.IdTipoCafe & "')   "
                    SqlRemision = "SELECT RemisionPergamino.IdRemisionPergamino, RemisionPergamino.Serie + ' ' + RemisionPergamino.Codigo AS Numero, RemisionPergamino.Fecha, EstadoDocumento.Descripcion AS Estado, TipoCafe.Nombre AS TipoRemision, Calidad.NomCalidad AS Calidad, LugarAcopio.NomLugarAcopio, EmpresaTransporte.NombreEmpresa, Vehiculo.Placa, Conductor.Nombre AS Conductor, RemisionPergamino.FechaCarga, RemisionPergamino.HoraSalida, RemisionPergamino.IdTipoCafe, RemisionPergamino.IdLugarAcopio FROM RemisionPergamino INNER JOIN EstadoDocumento ON RemisionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN TipoCafe ON RemisionPergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN Calidad ON RemisionPergamino.IdCalidad = Calidad.IdCalidad INNER JOIN LugarAcopio ON RemisionPergamino.IdLugarAcopio = LugarAcopio.IdLugarAcopio INNER JOIN EmpresaTransporte ON RemisionPergamino.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON RemisionPergamino.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  Conductor ON RemisionPergamino.IdConductor = Conductor.IdConductor WHERE (RemisionPergamino.IdLugarAcopio IN (SELECT RutasLogicasTransporte.IdLugarAcopioOrigen  FROM RutasLogicasTransporte INNER JOIN LugarAcopio AS LugarAcopio_2 ON RutasLogicasTransporte.IdLugarAcopioOrigen = LugarAcopio_2.IdLugarAcopio INNER JOIN LugarAcopio AS LugarAcopio_1 ON RutasLogicasTransporte.IdLugarAcopioDestino = LugarAcopio_1.IdLugarAcopio " & _
                                  "WHERE (RutasLogicasTransporte.IdLugarAcopioDestino = " & Me.IdLugarAcopio & ") OR (RutasLogicasTransporte.IdLugarAcopioOrigen = " & Me.IdLugarAcopio & "))) AND (RemisionPergamino.IdTipoCafe = '" & My.Forms.FrmRemision2.IdTipoCafe & "') ORDER BY RemisionPergamino.Fecha DESC, Numero DESC"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlRemision, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Visible = False
            End Select

            For Each col As C1.Win.C1TrueDBGrid.C1DataColumn In Me.TrueDBGridConsultas.Columns
                col.FilterText = ""
            Next

            Me.TrueDBGridConsultas.AlternatingRows = True
            Me.TrueDBGridConsultas.AllowFilter = False

            Me.TrueDBGridConsultas.Styles.Item(0).GradientMode = C1.Win.C1TrueDBGrid.GradientModeEnum.Vertical

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Fecha = Format(Now, "dd/MM/yyyy")
        Codigo = "-----0-----"

        For Each col As C1.Win.C1TrueDBGrid.C1DataColumn In Me.TrueDBGridConsultas.Columns
            col.FilterText = ""
        Next
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Posicion As Integer, Registros As Double, Iposicion As Double
        Select Case Quien
            Case "Localidad"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodLugarAcopio")
                Descripcion = Me.BindingConsultas.Item(Posicion)("NomLugarAcopio")
            Case "Transportista"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
                Descripcion = Me.BindingConsultas.Item(Posicion)("NombreEmpresa")

            Case "Conductor"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombre")

            Case "CodigoProductosDetalle"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")


            Case "Cierre"
                Posicion = Me.BindingConsultas.Position
                Fecha = Me.BindingConsultas.Item(Posicion)("FechaCierre")
                CodProveedor = Me.BindingConsultas.Item(Posicion)("Cod_Proveedor")
                TipoCompra = "Cierre"
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroCierre")

            Case "CodigoLote2"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Lote")
            Case "CodigoLote"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Lote")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("TipoRecepcion")
            Case "CodigoBeamsRecepcion"
                If Posicion > -1 Then
                    Posicion = Me.BindingConsultas.Position
                    Codigo = Me.BindingConsultas.Item(Posicion)("CodigoBin")
                    NumeroRecepcion = Me.BindingConsultas.Item(Posicion)("NumeroRecepcion")
                End If
            Case "Pedido"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NoPedido")
                Fecha = Me.BindingConsultas.Item(Posicion)("FechaPedido")
                CodigoCliente = Me.BindingConsultas.Item(Posicion)("CodigoCliente")
            Case "Procesos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroProceso")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
            Case "Transformacion"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroTransformacion")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                CodigoProceso = Me.BindingConsultas.Item(Posicion)("Codigo_Proceso")
                DescripcionProceso = Me.BindingConsultas.Item(Posicion)("Descripcion_Proceso")

            Case "RecepcionL"
                Dim DataSetLista As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQlString As String
                Dim NumeroRecepcion As String, Fecha As String, TipoRecepcion As String
                Dim StrSqlUpdate As String = "", ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroRecepcion")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                Conductor = Me.BindingConsultas.Item(Posicion)("Conductor")
                '//////////////////////////////////////////////BUSCO LA SELECCION DEL GRID ///////////////////////////////////
                Registros = Me.BindingConsultas.Count
                Iposicion = 0
                Do While Iposicion < Registros
                    If Me.BindingConsultas.Item(Iposicion)("Seleccion") = True Then

                        NumeroRecepcion = Me.BindingConsultas.Item(Iposicion)("NumeroRecepcion")
                        Fecha = Format(Me.BindingConsultas.Item(Iposicion)("Fecha"), "yyyy-MM-dd")
                        TipoRecepcion = "Recepcion"

                        SQlString = "SELECT Recepcion.* FROM Recepcion " & _
                                    "WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Recepcion")
                        If Not DataSet.Tables("Recepcion").Rows.Count = 0 Then
                            MiConexion.Close()
                            '//////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////
                            SQlString = "UPDATE [Recepcion] SET [Seleccion] = 'True' " & _
                                         "WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SQlString, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()

                        End If

                    Else

                        NumeroRecepcion = Me.BindingConsultas.Item(Iposicion)("NumeroRecepcion")
                        Fecha = Format(Me.BindingConsultas.Item(Iposicion)("Fecha"), "yyyy-MM-dd")
                        TipoRecepcion = "Recepcion"

                        SQlString = "SELECT Recepcion.* FROM Recepcion " & _
                                    "WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Recepcion")
                        If Not DataSet.Tables("Recepcion").Rows.Count = 0 Then
                            MiConexion.Close()
                            '//////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////
                            SQlString = "UPDATE [Recepcion] SET [Seleccion] = 'False' " & _
                                         "WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SQlString, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()

                        End If
                    End If
                    Iposicion = Iposicion + 1
                Loop
            Case "RecepcionBin"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroRecepcion")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                Conductor = Me.BindingConsultas.Item(Posicion)("Conductor")
                CodProveedor = Me.BindingConsultas.Item(Posicion)("Cod_Proveedor")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("TipoRecepcion")


            Case "Recepcion"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroRecepcion")
                NumeroRecibo = Me.BindingConsultas.Item(Posicion)("NumeroReciboCafe")
                IdReciboCafe = Me.BindingConsultas.Item(Posicion)("IdReciboPergamino")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                Conductor = Me.BindingConsultas.Item(Posicion)("Conductor")
                CodProveedor = Me.BindingConsultas.Item(Posicion)("Cod_Proveedor")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("TipoRecepcion")
            Case "CodigoBeams"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo_Beams")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Beams")
            Case "SalidaBodegaDolares"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Costo_Promedio_Dolar")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
            Case "SalidaBodegaCordobas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Costo_Promedio")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")

            Case "Liquidacion"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
                Codigo1 = Me.BindingConsultas.Item(Posicion)("IdLiquidacionPergamino")

            Case "Proveedor"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Proveedor")
                'Codigo1 = Me.BindingConsultas.Item(Posicion)("IdLiquidacionPergamino")

            Case "Transferencias"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
            Case "Remision"
                Posicion = Me.BindingConsultas.Position
                If Me.BindingConsultas.Position = -1 Then
                    Exit Sub
                Else
                    Codigo = Me.BindingConsultas.Item(Posicion)(0)
                End If
        End Select

        For Each col As C1.Win.C1TrueDBGrid.C1DataColumn In Me.TrueDBGridConsultas.Columns
            col.FilterText = ""
        Next

        Me.Close()
    End Sub


    Private Sub TrueDBGridConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridConsultas.Click

    End Sub

    Private Sub TrueDBGridConsultas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridConsultas.DoubleClick
        Button2_Click(sender, e)
    End Sub

    Private Sub TrueDBGridConsultas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TrueDBGridConsultas.KeyDown
        If e.KeyCode = 13 Then
            Button2_Click(sender, e)
        End If
    End Sub


    Private Sub CmdPesada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPesada.Click
        Dim SQLProductos As String, DataAdapter As New SqlClient.SqlDataAdapter

        My.Forms.FrmProveedores.ShowDialog()

        MiConexion.Close()
        SQlProductos = "SELECT Cod_Proveedor As Codigo, Nombre_Proveedor + ' ' + Apellido_Proveedor As Nomres FROM Proveedor"
        Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
        Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")
        Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
        Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 300

        Me.CmdPesada.Visible = True

        MiConexion.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class