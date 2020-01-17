Public Class FrmConsultas
    Public DataSet As New DataSet, TipoEnsamble As String, CodIva As String, TipoCompra As String, CodCajero As String, Nombres As String, Apellidos As String, IdCosecha As Double, Cedula As String
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Codigo As String, Descripcion As String, TipoProducto As String, CodComponente As Double, Precio As Double
    Public Cantidad As Double, CodProducto As String, Fecha As Date, CodigoCliente As String, SqlRemision As String, NumeroRecibo As String, IdReciboCafe As Double = 0, Vigencia As Date
    Public DescripcionImpuestos As String, TasaImpuestos As Double, TipoImpuesto As String, Conductor As String, CodProveedor As String, CodigoProceso As String, DescripcionProceso As String, Filtro As String, NumeroRecepcion As String


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
        Next dc

        If sb.ToString <> "" Then
            DataSet.Tables("Consultas").DefaultView.RowFilter = sb.ToString
        End If
    End Sub

    Private Sub FrmConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.TxtFiltro.Focus()
            DataSet.Reset()

            Me.CmdPesada.Visible = False

            MiConexion.Close()
            Me.TrueDBGridConsultas.AllowUpdate = False
            Me.LblInicio.Visible = False
            Me.LblFin.Visible = False
            Me.DtpFechaIni.Visible = False
            Me.DtpFechaFin.Visible = False
            Me.CmdFiltrar.Visible = False
            Me.CmdActualizar.Visible = False

            Dim DataAdapter As New SqlClient.SqlDataAdapter, SQlProductos As String
            Select Case Quien
                Case "EmpresaTransporte"
                    SQlProductos = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN ContratoTransporte ON EmpresaTransporte.IdEmpresaTransporte = ContratoTransporte.IdEmpresaTransporte " & _
                                   "WHERE(ContratoTransporte.IdCosecha = " & IdCosecha & ")"
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

                Case "CertificadoFinca"
                    SQlProductos = "SELECT  CertificadoXFinca.IdCertificado, Finca.NomFinca, CertificadoXFinca.Vigencia FROM  CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca  " & _
                    "WHERE (Finca.IdFinca = " & FrmRecepcion.IdFinca & ") AND (CertificadoXFinca.IdCosecha = " & FrmRecepcion.IdCosecha & ") AND (Finca.IdProductor = " & FrmRecepcion.IdProductor & ") ORDER BY CertificadoXFinca.Vigencia DESC"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Finca"
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Vigencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 300
                    MiConexion.Close()

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

                    Me.LblInicio.Visible = True
                    Me.LblFin.Visible = True
                    Me.DtpFechaIni.Visible = True
                    Me.DtpFechaFin.Visible = True
                    Me.CmdFiltrar.Visible = True
                    Me.CmdActualizar.Visible = True

                    SQlProductos = "SELECT Recepcion.NumeroReciboCafe, ReciboCafePergamino.Fecha As FechaRecibo, Proveedor.Cod_Proveedor, CASE WHEN Proveedor.Cod_Proveedor = '00001' THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Nombres, Recepcion.Conductor, Recepcion.TipoRecepcion, Recepcion.NumeroRecepcion, Recepcion.IdReciboPergamino, TipoCafe.Nombre AS TipoCafe, TipoCompra.Nombre AS TipoCompra, TipoIngreso.Descripcion AS TipoIngreso, ReciboCafePergamino.Serie, EstadoDocumento.Descripcion AS Estado, Recepcion.Fecha FROM  Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN ReciboCafePergamino ON Recepcion.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN TipoCompra ON ReciboCafePergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN " & _
                                   "LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN TipoIngreso ON ReciboCafePergamino.IdTipoIngreso = TipoIngreso.IdECS WHERE  (Recepcion.Cancelar = 0) AND (Recepcion.TipoRecepcion = 'Recepcion') AND (ReciboCafePergamino.IdLocalidadRegistro = '" & FrmRecepcion.IdLugarAcopioDefecto & "') ORDER BY Recepcion.Fecha DESC, Recepcion.NumeroReciboCafe DESC"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    'Me.TrueDBGridConsultas.Columns(13).FilterText = Filtro
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Recibos"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Proveedor"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 70
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 150
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(13).Visible = False

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
                Case "SalidaBodegaCordobas"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Costo_Promedio, Existencia_Unidades,Cod_Iva FROM Productos "
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
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Precio C$"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    MiConexion.Close()
                Case "CodigoTipoPrecio"
                    SQlProductos = "SELECT  * FROM TipoPrecio"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "Liquidacion"
                    SQlProductos = "SELECT  Numero_Compra, Fecha_Compra, Tipo_Compra, MonedaCompra, Cod_Proveedor, Cod_Bodega, Nombre_Proveedor, Apellido_Proveedor, Direccion_Proveedor, Telefono_Proveedor, Fecha_Vencimiento, Observacion, Descuento, Fecha_Descuento, SubTotal, IVA, Pagado, NetoPagar, MontoCredito, Contabilizado, Activo, Cancelado, Exonerado, RecepcionNo, Retencion_Municipal, Retencion_IR1, Retencion_IR2, Adelantos, Reintegro, Su_Referencia, Nuestra_Referencia, TransferenciaProcesada, Marca FROM Compras WHERE  (Tipo_Compra = 'Liquidacion Productos') AND (Activo = 1)"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Numero"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Nombres"
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Apellidos"


                Case "CodigoProductosCordobas"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta, Existencia_Unidades,Cod_Iva FROM Productos "
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
                    Me.TrueDBGridConsultas.Columns(3).Caption = "Precio C$"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 65
                    Me.TrueDBGridConsultas.Columns(3).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Columns(4).Caption = "Existencia"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 65
                    Me.TrueDBGridConsultas.Columns(4).NumberFormat = "##,##0.00"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False

                    MiConexion.Close()
                Case "CodigoProductosFactura"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Lista, Existencia_Unidades,Cod_Iva FROM Productos"
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
                Case "Arqueo"
                    SQlProductos = "SELECT CodArqueo, FechaArqueo, Cod_Cajero FROM Arqueo ORDER BY CodArqueo"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195
                Case "CodigoCajero"
                    SQlProductos = "SELECT Cod_Cajero, Nombre_Cajero + ' ' + Apellido_Cajero AS Nombres FROM  Cajeros ORDER BY Cod_Cajero"
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 65
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 195



                Case "CodigoCliente"
                    SQlProductos = "SELECT  Cod_Cliente, Nombre_Cliente, Apellido_Cliente  FROM Clientes "
                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 100





                Case "Ensamble"
                    SQlProductos = "SELECT  *  FROM Ensamble WHERE (Tipo_Ensamble = 'Ensamble Recibido')"

                    MiConexion.Open()
                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
                    Me.TrueDBGridConsultas.Columns(2).Caption = "Tipo Ensamble"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 100
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Visible = False
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(8).Visible = False


                Case "CodigoProductosEnsamble"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, CodComponente FROM Productos WHERE (Tipo_Producto = 'Ensambles')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"


                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 220
                    If Filtro <> "" Then
                        Me.TrueDBGridConsultas.Columns(1).FilterText = Filtro
                    End If
                Case "CodigoProductosComponente"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto FROM Productos WHERE (Cod_Productos <> '" & FrmProductos.CboCodigoProducto.Text & "')"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()


                Case "Bodegas"
                    SQlProductos = "SELECT  * FROM   Bodegas"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 250
                    MiConexion.Close()

                Case "CodigoProducto"
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto FROM Productos "
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"

                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    MiConexion.Close()

                Case "CodigoProveedorLiquidacion"

                    SQlProductos = "SELECT DISTINCT CASE WHEN Proveedor.IdProductor IS NULL THEN '00001' ELSE Proveedor.Cod_Proveedor END AS Cod_Proveedor, CASE WHEN Proveedor.IdProductor IS NULL  THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Nombres, CASE WHEN Proveedor.Cedula IS NULL THEN ReciboCafePergamino.CedulaManual ELSE Proveedor.Cedula END AS Cedula  FROM   ReciboCafePergamino LEFT OUTER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor " & _
                                   "WHERE(ReciboCafePergamino.IdCosecha = " & IdCosecha & ")"

                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 300

                    Me.CmdPesada.Visible = False

                    MiConexion.Close()



                Case "CodigoProveedor"
                    SQlProductos = "SELECT Cod_Proveedor As Codigo, Nombre_Proveedor + ' ' + Apellido_Proveedor As Nombres FROM Proveedor"
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 300

                    Me.CmdPesada.Visible = False

                    MiConexion.Close()


                Case "CodigoProductos"
                    'SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta FROM Productos "
                    SQlProductos = "SELECT Cod_Productos, Descripcion_Producto, Tipo_Producto,Precio_Venta FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"

                    MiConexion.Open()

                    DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
                    DataSet.Reset()
                    DataAdapter.Fill(DataSet, "Consultas")
                    Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                    Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
                    Me.TrueDBGridConsultas.Columns(0).Caption = "Còdigo"
                    Me.TrueDBGridConsultas.Columns(1).Caption = "Descripcion"
                    Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Visible = False
                    MiConexion.Close()

                Case "Remision"

                    If My.Forms.FrmRemision2.CboTipoRemision.Text = "Pergamino" Then
                        SqlRemision = "SELECT  RemisionPergamino.Codigo, RemisionPergamino.Fecha, RemisionPergamino.FechaCarga, RemisionPergamino.HoraSalida, RemisionPergamino.Observacion,    RemisionPergamino.IdCosecha, RemisionPergamino.IdLugarAcopio, RemisionPergamino.IdCalidad, RemisionPergamino.IdEstadoDocumento,  RemisionPergamino.IdConductor, RemisionPergamino.IdEmpresaTransporte, RemisionPergamino.IdVehiculo, RemisionPergamino.IdDestino,RemisionPergamino.IdTipoCafe, RemisionPergamino.IdTipoIngreso, EstadoDocumento.Descripcion, RemisionPergamino.IdRemisionPergamino,    TipoDocumento.Descripcion AS TipoDoc FROM   RemisionPergamino INNER JOIN        EstadoDocumento ON RemisionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                         TipoDocumento ON RemisionPergamino.IdtipoDocumento = TipoDocumento.IdtipoDocumento  WHERE        (EstadoDocumento.Descripcion <> 'Anulado') AND (TipoDocumento.Descripcion = 'Pergamino')"
                        MiConexion.Open()
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlRemision, MiConexion)
                        DataSet.Reset()
                        DataAdapter.Fill(DataSet, "Consultas")
                        Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                        Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    ElseIf My.Forms.FrmRemision2.CboTipoRemision.Text = "Maquila" Then
                        SqlRemision = "SELECT  RemisionPergamino.Codigo, RemisionPergamino.Fecha, RemisionPergamino.FechaCarga, RemisionPergamino.HoraSalida, RemisionPergamino.Observacion, RemisionPergamino.IdCosecha, RemisionPergamino.IdLugarAcopio, RemisionPergamino.IdCalidad, RemisionPergamino.IdEstadoDocumento,                          RemisionPergamino.IdConductor, RemisionPergamino.IdEmpresaTransporte, RemisionPergamino.IdVehiculo, RemisionPergamino.IdDestino,                          RemisionPergamino.IdTipoCafe, RemisionPergamino.IdTipoIngreso, EstadoDocumento.Descripcion, RemisionPergamino.IdRemisionPergamino,                          TipoDocumento.Descripcion AS TipoDoc FROM            RemisionPergamino INNER JOIN                         EstadoDocumento ON RemisionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                         TipoDocumento ON RemisionPergamino.IdtipoDocumento = TipoDocumento.IdtipoDocumento  WHERE        (EstadoDocumento.Descripcion <> 'Anulado') AND (TipoDocumento.Descripcion = 'Maquila')"
                        MiConexion.Open()
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlRemision, MiConexion)
                        DataSet.Reset()
                        DataAdapter.Fill(DataSet, "Consultas")
                        Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
                        Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas

                    End If

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

        Me.TxtFiltro.Text = ""
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Posicion As Integer, Registros As Double, Iposicion As Double



        Select Case Quien
            Case "EmpresaTransporte"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
                Descripcion = Me.BindingConsultas.Item(Posicion)("NombreEmpresa")
            Case "CertificadoFinca"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("IdCertificado")
                Vigencia = Me.BindingConsultas.Item(Posicion)("Vigencia")
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
            Case "CodigoTipoPrecio"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_TipoPrecio")
            Case "Liquidacion"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero_Liquidacion")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Liquidacion")
                Nombres = Me.BindingConsultas.Item(Posicion)("Nombre_Proveedor")
                Apellidos = Me.BindingConsultas.Item(Posicion)("Apellido_Proveedor")

            Case "CodigoProductosCordobas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Precio_Venta")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
            Case "CodigoProductosFactura"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Precio_Lista")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
            Case "Arqueo"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodArqueo")
                Fecha = Me.BindingConsultas.Item(Posicion)("FechaArqueo")
                CodCajero = Me.BindingConsultas.Item(Posicion)("Cod_Cajero")

            Case "CodigoCajero"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Cajero")
            Case "FacturasHistoricos"
                Posicion = Me.BindingConsultas.Position
                Nombres = Me.BindingConsultas.Item(Posicion)("Cliente")
                If Me.BindingConsultas.Item(Posicion)("Cliente") = "******CANCELADO ******" Then
                    MsgBox(Me.BindingConsultas.Item(Posicion)("Tipo") & " CANCELADA", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Nombres = Me.BindingConsultas.Item(Posicion)("Cliente")
                Else
                    Posicion = Me.BindingConsultas.Position
                    Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                    Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                    TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
                End If
            Case "Facturas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
            Case "Plantillas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NumeroPlantilla")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Plantilla")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo_Plantilla")
            Case "CodigoCliente"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Cliente")

            Case "Compras"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")

            Case "Liquidacion_Productos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
            Case "ComprasHistorico"
                Posicion = Me.BindingConsultas.Position
                Nombres = Me.BindingConsultas.Item(Posicion)("Proveedor")
                If Me.BindingConsultas.Item(Posicion)("Proveedor") = "******CANCELADO ******" Then
                    MsgBox(Me.BindingConsultas.Item(Posicion)("Tipo") & " CANCELADA", MsgBoxStyle.Critical, "Zeus Facturacion")
                    Nombres = Me.BindingConsultas.Item(Posicion)("Proveedor")
                Else
                    Posicion = Me.BindingConsultas.Position
                    Codigo = Me.BindingConsultas.Item(Posicion)("Numero")
                    Fecha = Me.BindingConsultas.Item(Posicion)("Fecha")
                    TipoCompra = Me.BindingConsultas.Item(Posicion)("Tipo")
                End If

            Case "Bodegas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Bodega")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombre_Bodega")
            Case "CodigoProductosDetalle"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                Precio = Me.BindingConsultas.Item(Posicion)("Costo_Promedio")
                CodIva = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "MetodoPago"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("NombrePago")

            Case "Ensamble"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_ReciboEnsamble")
                Cantidad = Me.BindingConsultas.Item(Posicion)("Cantidad_Principal")
                CodProducto = Me.BindingConsultas.Item(Posicion)("Cod_ProductoEnsamble")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Ensamble")
                CodComponente = Me.BindingConsultas.Item(Posicion)("Cod_Componente")
                TipoEnsamble = Me.BindingConsultas.Item(Posicion)("Tipo_Ensamble")
            Case "Ensambles"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_ReciboEnsamble")
                Cantidad = Me.BindingConsultas.Item(Posicion)("Cantidad_Principal")
                CodProducto = Me.BindingConsultas.Item(Posicion)("Cod_ProductoEnsamble")
                Fecha = Me.BindingConsultas.Item(Posicion)("Fecha_Ensamble")
                CodComponente = Me.BindingConsultas.Item(Posicion)("Cod_Componente")
            Case "CodigoProductosEnsamble"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                CodComponente = Me.BindingConsultas.Item(Posicion)("CodComponente")
            Case "CodigoProductosComponente"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
            Case "CuentaPagarInteres"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaCobrarInteres"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")

            Case "Bodegas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Bodega")
            Case "CodigoProducto"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "CuentaBancos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion")
            Case "CuentaCaja"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaGastoAjuste"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaIngresoAjuste"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CodigoImpuestos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Iva")
                DescripcionImpuestos = Me.BindingConsultas.Item(Posicion)("Descripcion_Iva")
                TasaImpuestos = Me.BindingConsultas.Item(Posicion)("Impuesto")
                TipoImpuesto = Me.BindingConsultas.Item(Posicion)("TipoImpuesto")
            Case "CodigoRubro"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo_Rubro")
            Case "CodigoTarea"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodigoTarea")
            Case "CodigoLinea"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Linea")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Linea")
            Case "CuentaPagar"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaCobrar"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CodigoProveedorLiquidacion"
                Posicion = Me.BindingConsultas.Position
                Cedula = Me.BindingConsultas.Item(Posicion)("Cedula")
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Proveedor")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombres")

            Case "CodigoProveedor"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombres")
                'TipoProducto = Me.BindingConsultas.Item(Posicion)("Apellidos")
            Case "SubProveedor"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Nombres")
            Case "CodigoProductos"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
                'Codigo = Me.BindingConsultas.Item(Posicion)("Cod_Productos")
                'Descripcion = Me.BindingConsultas.Item(Posicion)("Descripcion_Producto")
                'TipoProducto = Me.BindingConsultas.Item(Posicion)("Tipo_Producto")
            Case "CuentaInventario"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaCosto"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")
            Case "CuentaVentas"
                Posicion = Me.BindingConsultas.Position
                Codigo = Me.BindingConsultas.Item(Posicion)("CodCuentas")

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
                    Codigo = Me.BindingConsultas.Item(Posicion)("Codigo")
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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFiltro.TextChanged
        'If Filtro <> "" Then
        '    Me.TrueDBGridConsultas.Columns(1).FilterText = Filtro
        'End If

        If Quien = "Recepcion" Then
            Me.TrueDBGridConsultas.Columns(2).FilterText = Me.TxtFiltro.Text
        Else
            Me.TrueDBGridConsultas.Columns(1).FilterText = Me.TxtFiltro.Text
        End If

    End Sub

    Private Sub CmdFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFiltrar.Click
        Dim SqlProductos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSetFiltro As New DataSet

        MiConexion.Close()
        SqlProductos = "SELECT Recepcion.NumeroReciboCafe, Recepcion.Fecha, Proveedor.Cod_Proveedor, CASE WHEN Proveedor.Cod_Proveedor = '00001' THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Nombres, Recepcion.Conductor, Recepcion.TipoRecepcion, Recepcion.NumeroRecepcion, Recepcion.IdReciboPergamino, TipoCafe.Nombre AS TipoCafe, TipoCompra.Nombre AS TipoCompra, TipoIngreso.Descripcion AS TipoIngreso, ReciboCafePergamino.Serie, EstadoDocumento.Descripcion AS Estado FROM  Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN ReciboCafePergamino ON Recepcion.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN TipoCompra ON ReciboCafePergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN " & _
                       "LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN TipoIngreso ON ReciboCafePergamino.IdTipoIngreso = TipoIngreso.IdECS WHERE  (Recepcion.Cancelar = 0) AND (Recepcion.TipoRecepcion = 'Recepcion') AND (ReciboCafePergamino.IdLocalidadRegistro = '" & FrmRecepcion.IdLugarAcopioDefecto & "') AND (Recepcion.Fecha BETWEEN  CONVERT(DATETIME, '" & Format(Me.DtpFechaIni.Value, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(Me.DtpFechaFin.Value, "yyyy-MM-dd") & " 23:59:59', 102)) ORDER BY Recepcion.Fecha DESC, Recepcion.NumeroReciboCafe DESC"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
        DataAdapter.Fill(DataSetFiltro, "Filtro")
        Me.BindingConsultas.DataSource = DataSetFiltro.Tables("Filtro")
        Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
        'Me.TrueDBGridConsultas.Columns(13).FilterText = Filtro
        Me.TrueDBGridConsultas.Columns(0).Caption = "Recibos"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
        Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridConsultas.Columns(2).Caption = "Proveedor"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 150
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Visible = False
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Visible = False


    End Sub

    Private Sub CmdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdActualizar.Click
        Dim SqlProductos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSetFiltro As New DataSet

        MiConexion.Close()
        SQlProductos = "SELECT Recepcion.NumeroReciboCafe, Recepcion.Fecha, Proveedor.Cod_Proveedor, CASE WHEN Proveedor.Cod_Proveedor = '00001' THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Nombres, Recepcion.Conductor, Recepcion.TipoRecepcion, Recepcion.NumeroRecepcion, Recepcion.IdReciboPergamino, TipoCafe.Nombre AS TipoCafe, TipoCompra.Nombre AS TipoCompra, TipoIngreso.Descripcion AS TipoIngreso, ReciboCafePergamino.Serie, EstadoDocumento.Descripcion AS Estado FROM  Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN ReciboCafePergamino ON Recepcion.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN TipoCompra ON ReciboCafePergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN " & _
               "LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN TipoIngreso ON ReciboCafePergamino.IdTipoIngreso = TipoIngreso.IdECS WHERE  (Recepcion.Cancelar = 0) AND (Recepcion.TipoRecepcion = 'Recepcion') AND (ReciboCafePergamino.IdLocalidadRegistro = '" & FrmRecepcion.IdLugarAcopioDefecto & "') ORDER BY Recepcion.Fecha DESC, Recepcion.NumeroReciboCafe DESC"
        MiConexion.Open()

        DataAdapter = New SqlClient.SqlDataAdapter(SQlProductos, MiConexion)
        DataSet.Reset()
        DataAdapter.Fill(DataSet, "Consultas")
        Me.BindingConsultas.DataSource = DataSet.Tables("Consultas")
        Me.TrueDBGridConsultas.DataSource = Me.BindingConsultas
        'Me.TrueDBGridConsultas.Columns(13).FilterText = Filtro
        Me.TrueDBGridConsultas.Columns(0).Caption = "Recibos"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 70
        Me.TrueDBGridConsultas.Columns(1).Caption = "Fecha"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridConsultas.Columns(2).Caption = "Proveedor"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 150
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Visible = False
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Visible = False
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Visible = False
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Visible = False
    End Sub
End Class