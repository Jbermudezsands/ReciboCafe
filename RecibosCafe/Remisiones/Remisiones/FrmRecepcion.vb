Public Class FrmRecepcion
    Public NumeroTemporal As String, Random As New Random()
    Public MiConexion As New SqlClient.SqlConnection(Conexion), IdLugarAcopio As Integer, IdEstadoFisico As Integer, IdCalidad As Integer, IdTipoLugarAcopio As Integer, IdCosecha As Integer, HumedadxDefecto As Double = 0, Observaciones As String = "", IdTipoCafe As Double = 0, IdDaño As Double = 0, IdFinca As Double = 0, IdTipoCompra As Double = 0, IdTipoDocumento As Double = 0, IdProductor As Double = 0, IdEstadoDocumento As Double = 0, IdRecibo As Double = 0, CantSacos As Double = 0, IdTipoIngreso As Double = 0, IdRangoImperfeccion As Double = 0, CodLugarAcopio As String, LimpiarRecibo As Boolean, EsProductorManual As Boolean = True, Cosecha As String, Cod_Cosecha As String
    Public EqOreado As Double, EqReal As Double, QQOreado As Double, Finca As String, Cedula As String, TipoIngreso As String, NRecibo As String, IdReciboCafe As Double, IdPignorado As Double, NumeroCertificado As Double = 0, FechaVence As Date = "01/01/1900", Hora As Date, EstadoDoc As String, NomLugarAcopioDefecto As String, IdLugarAcopioDefecto As Double, CodLugarAcopioDefecto As String, Pignorado As String, Localidad As String, LocalidadLiquidar As String, TipoCafe As String, FechaRecibo As String, TipoCompra As String, TipoCalidad As String, Categoria As String, Estado As String, Daño As String, Humedad As String, Imperfeccion As String, AñoCosecha As String
    Delegate Sub delegado(ByVal data As String)
    Private Sub Siguiente()
        If Me.TrueDBGridComponentes.RowCount <> 0 Then
            Dim Iposicion As Double
            Iposicion = Me.TrueDBGridComponentes.RowCount
            Me.TrueDBGridComponentes.Row = Iposicion
            Me.TrueDBGridComponentes.Columns(1).Text = Me.CboIngresoBascula.Columns(0).Text
            Me.TrueDBGridComponentes.Columns(2).Text = Me.CboIngresoBascula.Columns(1).Text
            Me.TrueDBGridComponentes.Col = 5
        End If
    End Sub
    Public Function CalculaPrecioBruto(ByVal FechaRecibo As Date, ByVal IdLocalidadLiqui As Double, ByVal idCategoria As Double, ByVal IdDano As Double, ByVal IdMoneda As Double, ByVal IdEdoFisico As Double) As Double
        Dim IdRecibo As Integer, i As Integer, IdlocalidadRec, Precio1 As Double, Fecha As Date, PesoNeto As Double, Precio As Double
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, EsPorcentaje As Boolean, IdLocalidad As Integer, DeduccionDano As Double, DD As Double
        Dim DeducEstado As Double, PrecioBruto As String, PrecioAutoriza As Double, PrecioAutoriza1 As Double, PrecioBrutoAutoriza As Double, TotalMonto As Double, Count As Double
        Dim DataSet As New DataSet, SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, Porcentaje As Double

        SqlString = "SELECT  IdImpuesto, Descripcion, Valor, VigenciaInicial, VigenciaFinal  FROM Impuesto WHERE (VigenciaInicial <= CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd") & "', 102)) AND (VigenciaFinal >= CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd") & "', 102)) AND (IdImpuesto = 8)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Retencion")
        If DataSet.Tables("Retencion").Rows.Count <> 0 Then
            Porcentaje = DataSet.Tables("Retencion").Rows(0)("Valor")
        Else
            Porcentaje = 0
        End If

        '______________________________________________________________________________________________________()
        'PRECIO(CAFE)
        '______________________________________________________________________________________________________()
        SqlString = "SELECT   IdPrecioCafe, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, FechaActualizacion  FROM   PrecioCafe   WHERE    (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm:ss") & "', 102))  ORDER BY FechaActualizacion DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Precio")

        SqlString = "SELECT        IdPrecioComplemento, IdCosecha, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion  FROM   PrecioComplemento   WHERE    (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm:ss") & "', 102))  ORDER BY Corte DESC, FechaActualizacion DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "PrecioAutoriza")


        If DataSet.Tables("PrecioAutoriza").Rows.Count <> 0 Then
            PrecioAutoriza = Format(DataSet.Tables("PrecioAutoriza").Rows(0)("Precio"), "##,##0.0000")
            PrecioAutoriza1 = Format(DataSet.Tables("PrecioAutoriza").Rows(0)("Precio"), "##,##0.0000") / 46
        Else
            PrecioAutoriza = 0.0
            PrecioAutoriza1 = 0.0
        End If



        If DataSet.Tables("Precio").Rows.Count <> 0 Then
            'Quien2 = "NoJustifica"
            Precio = Format(DataSet.Tables("Precio").Rows(0)("Precio"), "##,##0.0000")

            'Me.TxtPrecio.Text = Format(Precio, "##,##0.00")
            Precio1 = Format(DataSet.Tables("Precio").Rows(0)("Precio") / 46, "####0.0000")

            'Me.TxtPrecioBrutoSinDeduc.Text = Precio1
            'Me.TxtPrecioSG.Text = Me.TxtPrecio.Text
        Else
            'Quien2 = "NoJustifica"
            Precio = 0.0
            'MsgBox("NO SE ENCONTRO PRECIOS", MsgBoxStyle.Critical, "Liquidacion")
            'Me.TxtPrecio.Text = Format(Precio, "##,##0.00")
            'Me.TxtPrecioBrutoAutoriza.Text = Format(Precio, "##,##0.00")
            Precio1 = Format(0.0, "##,##0.00")

            'Me.TxtPrecioBrutoSinDeduc.Text = Precio1
            'Me.TxtPrecioSG.Text = Me.TxtPrecio.Text
        End If


        DataSet.Tables("PrecioAutoriza").Reset()
        DataSet.Tables("Precio").Reset()
        '______________________________________________________________________________________________________
        'DEDUCCION DAÑO 
        '______________________________________________________________________________________________________


        IdCosecha = CodigoCosecha
        SqlString = "SELECT  IdDeduccionDano, Deduccion, EsPorcentaje, FechaInicio, FechaFin, IdDano, IdMoneda, IdUMedida, IdCosecha  FROM  DeduccionDano WHERE (IdDano = '" & IdDano & "') AND (IdMoneda ='" & IdMoneda & "') AND (IdCosecha ='" & IdCosecha & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DeduccionDano")
        If DataSet.Tables("DeduccionDano").Rows.Count = 0 Then
            DeduccionDano = 0
        Else
            Fechainicial = DataSet.Tables("DeduccionDano").Rows(0)("FechaInicio")
            FechaFinal = DataSet.Tables("DeduccionDano").Rows(0)("FechaFin")
            Fechanow = FechaRecibo
            EsPorcentaje = DataSet.Tables("DeduccionDano").Rows(0)("EsPorcentaje")
            DD = DataSet.Tables("DeduccionDano").Rows(0)("Deduccion")
            If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                If EsPorcentaje = True Then
                    DeduccionDano = Precio1 * (1 - DD)
                Else
                    DeduccionDano = DD / 46
                End If
            Else
                DeduccionDano = 0
            End If
        End If




        '______________________________________________________________________________________________________
        'DEDUCCION ESTADO FISICO 
        '______________________________________________________________________________________________________
        SqlString = "SELECT IdDeduccionEstadoFisico, PorcentajeDeduccion, EstadoFisico, IdCosecha FROM   PorcentajeDeduccionEstadoFisico   WHERE  (EstadoFisico = '" & IdEdoFisico & "') AND (IdCosecha = '" & IdCosecha & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DeduccionEdo")
        DeducEstado = DataSet.Tables("DeduccionEdo").Rows(0)("PorcentajeDeduccion")

        '/////////////////////////////////////SI PRECIO BASE DEL DIA ES CERO BUSCO EL PRECIO DEL PRIMER CORTE /////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Precio1 = 0 Then
            SqlString = "SELECT  IdPrecioComplemento, IdCosecha, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion  FROM PrecioComplemento WHERE  (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm:ss") & "', 102)) AND (Corte = 1) ORDER BY Corte DESC, FechaActualizacion DESC"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "PrecioBase")

            If DataSet.Tables("PrecioBase").Rows.Count <> 0 Then
                Precio = Format(DataSet.Tables("PrecioBase").Rows(0)("Precio"), "##,##0.0000")
                Precio1 = Format(DataSet.Tables("PrecioBase").Rows(0)("Precio") / 46, "####0.0000")
            End If
        End If


        DeduccionDano = Format(DeduccionDano, "####0.0000")
        DeducEstado = Format(DeducEstado, "####0.0000")
        Porcentaje = Format(Porcentaje, "####0.0000")


        'PrecioBruto = Format(((((Precio1 * DeducEstado) - DeduccionDano) / (1 - Porcentaje))), "####0.00")
        'PrecioBrutoAutoriza = Format(((((PrecioAutoriza1 * DeducEstado) - DeduccionDano) / (1 - Porcentaje))), "####0.00")

        '-------------------------------EL SISTEMA MOSTRARA EL PRECIO BASE --------------------------------------------------
        PrecioBruto = Format(((((Precio1 - DeduccionDano) * DeducEstado) / (Format(1 - Porcentaje, "####0.0000")))), "####0.00")
        PrecioBrutoAutoriza = Format(((((PrecioAutoriza1 - DeduccionDano) * DeducEstado) / (Format(1 - Porcentaje, "####0.0000")))), "####0.00")

        ''///////////////////////////////////CAMBIO EL PRECIO BRUTO SIEMPRE POR EL PRECIO AUTORIZA ///////////////////////////////////
        'If PrecioBrutoAutoriza <> 0 Then
        '    PrecioBruto = PrecioBrutoAutoriza
        'End If

        If Precio1 = 0 Then
            If PrecioAutoriza1 = 0 Then
                PrecioBruto = 0
            Else
                PrecioBruto = PrecioBrutoAutoriza
            End If
        End If

        CalculaPrecioBruto = PrecioBruto


    End Function




    Public Function BuscaNumeroRecibo() As String
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Cadena As String, CadenaDiv() As String, Consecutivo As Double, NumeroRecibo As String
        '////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////BUSCO EL CONSECUTIVO DEL RECIBO ///////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////
        'If Me.TxtNumeroRecibo.Text = "-----0-----" Then
        SqlString = "SELECT Codigo FROM ReciboCafePergamino WHERE (IdCosecha = " & Me.IdCosecha & ") AND (IdLocalidad = " & Me.IdLugarAcopio & ") AND (IdTipoCompra = " & Me.IdTipoCompra & ") AND (IdTipoCafe = " & Me.IdTipoCafe & ")  AND (LEN(Codigo) > 6) AND (Codigo LIKE '%" & CodLugarAcopio & "%') ORDER BY Codigo DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "NumeroRecibo")
        If DataSet.Tables("NumeroRecibo").Rows.Count <> 0 Then
            Cadena = DataSet.Tables("NumeroRecibo").Rows(0)("Codigo")
            If Len(Cadena) >= 6 Then
                CadenaDiv = Cadena.Split("-")
                Consecutivo = CadenaDiv(1)
                Consecutivo = Consecutivo + 1
            End If
        Else
            Consecutivo = 1
        End If

        NumeroRecibo = Format(Consecutivo, "00000#")
        BuscaNumeroRecibo = NumeroRecibo
        'Me.TxtNumeroRecibo.Text = NumeroRecibo

        'Else
        'NumeroRecibo = Me.TxtNumeroRecibo.Text
        'End If
    End Function
    Private Function BuscaConsecutivoRecibo(ByVal IdLocalidad As Double, ByVal IdCosecha As Double) As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, Consecutivo As Double

        SqlString = "SELECT  Codigo, IdCosecha, IdLocalidad FROM ReciboCafePergamino WHERE (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ") ORDER BY Codigo DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consecutivo")
        If DataSet.Tables("Consecutivo").Rows.Count = 0 Then
            BuscaConsecutivoRecibo = Format(1, "000000#")
        Else
            Consecutivo = DataSet.Tables("Consecutivo").Rows(0)("Codigo")
            BuscaConsecutivoRecibo = Format(Consecutivo, "000000#")
        End If

    End Function

    Private Sub FrmRecepcion_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DockChanged

    End Sub

    Private Sub FrmRecepcion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Cont As Double, i As Double, Eleccion As Boolean, idReciboPergamino As Double, IdRemisionPergamino As Double, Sql As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet


        '//////////////////////////////////////////SI LE DA SALIR Y NO SE GRABO ELIMINO LAS PESADAS //////////////////////////////////////////////

        If Not Me.TxtNumeroEnsamble.Text = "-----0-----" Then

            Sql = "SELECT  * FROM Recepcion WHERE(idReciboPergamino = '" & Me.NumeroTemporal & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "ConsultaSalida")
            If DataSet.Tables("ConsultaSalida").Rows.Count <> 0 Then

                '---------------------SI NO SE GUARDO LA REMISION BORRO TODO --------------------------------------------
                StrSqlUpdate = "DELETE FROM Recepcion WHERE (idReciboPergamino = '" & Me.NumeroTemporal & "') "
                MiConexion.Close()
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If


        End If


        Me.sp.Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Ruta As String, LeeArchivo As String, i As Double = 0


        Me.NumeroTemporal = Me.Random.Next()



        MiConexion.Close()
        EstadoDoc = "Editable"
        LimpiarRecibo = True

        If Quien = "RePesaje" Then
            Me.CboTipoRecepcion.Text = "RePesaje"
            Me.TxtNumeroRecibo.Visible = False
            Me.TxtLocalidad.Visible = False
            Me.TxtSerie.Visible = False
            Me.CboCodigoProveedor.Enabled = False
            Me.txtnombre.Enabled = False
            Me.CboFinca.Enabled = False
            Me.CboLocalidad.Enabled = False
            Me.CboTipoCompra.Enabled = False
            Me.CboTipoIngresoBascula.Enabled = False
            Me.CmdProductorManual.Enabled = False
            Me.Button2.Enabled = False
            Me.TxtNumeroEnsamble.Visible = True

            Quien = "Recepcion"
        Else
            Me.CboTipoRecepcion.Text = "Recepcion"
            Me.TxtNumeroEnsamble.Visible = True
            Me.TxtNumeroRecibo.Visible = True
            Me.TxtLocalidad.Visible = True
            Me.TxtSerie.Visible = True
            Me.CboCodigoProveedor.Enabled = True
            Me.txtnombre.Enabled = True
            Me.CboFinca.Enabled = True
            Me.CboLocalidad.Enabled = True
            Me.CboTipoCompra.Enabled = True
            Me.CboTipoIngresoBascula.Enabled = True
            Me.CmdProductorManual.Enabled = True
            Me.Button2.Enabled = True
            CodigoRepesaje = 0

        End If

        Quien = "Load"
        Me.CboTipoCalidad.Text = "AP1ra"
        Me.CboCategoria.Text = "A"

        'Me.CboIngreso.Text = "Automatico"
        'CboTipoDocumento.Text = DescripcionTipoIngreso("BA")
        Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA")

        'sql = "SELECT  Calidad.*  FROM Calidad"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "Calidad")
        'Me.CboTipoCalidad.DataSource = DataSet.Tables("Calidad")


        sql = "SELECT  Descripcion FROM EstadoDocumento"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "EstadoDocumento")
        Me.CboEstadoDocumeto.DisplayMember = "Descripcion"
        Me.CboEstadoDocumeto.DataSource = DataSet.Tables("EstadoDocumento")
        Me.CboEstadoDocumeto.Text = "Editable"
        Me.Button12.Enabled = False
        Me.Button4.Enabled = False

        sql = "SELECT IdTipoIngreso, Descripcion FROM TipoIngreso "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoIngreso")
        Me.CboTipoIngresoBascula.DisplayMember = "Descripcion"
        Me.CboTipoIngresoBascula.DataSource = DataSet.Tables("TipoIngreso")

        'sql = "SELECT IdEstadoDocumento, Codigo, Descripcion  FROM EstadoDocumento "
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "EstadoDocumento")
        'Me.CboEstadoDocumeto.DisplayMember = "Descripcion"
        'Me.CboEstadoDocumeto.DataSource = DataSet.Tables("EstadoDocumento")

        sql = "SELECT IdtipoDocumento, Descripcion FROM TipoDocumento WHERE (IdtipoDocumento = 1647) OR (IdtipoDocumento = 1646)"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoDocumento")
        Me.CboTipoDocumento.DisplayMember = "Descripcion"
        Me.CboTipoDocumento.DataSource = DataSet.Tables("TipoDocumento")
        Me.CboTipoDocumento.Text = "Recibo Bascula Manual"



        'sql = "SELECT  IdTipoCompra, Codigo, Nombre FROM TipoCompra"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "TipoCompra")
        'Me.CboTipoCompra.DataSource = DataSet.Tables("TipoCompra")


        'sql = "SELECT Nombre FROM RangoImperfeccion"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "Categoria")
        'Me.CboCategoria.DataSource = DataSet.Tables("Categoria")

        'i = 0
        'Do While DataSet.Tables("Categoria").Rows.Count > i
        '    Me.CboCategoria.Items.Add(DataSet.Tables("Categoria").Rows(i)("Categoria"))
        '    Me.CboCategoria.Text = DataSet.Tables("Categoria").Rows(0)("Categoria")
        '    i = i + 1
        'Loop


        'sql = "SELECT  Calidad.*  FROM Calidad"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "Calidad")
        'Me.CboTipoCalidad.DataSource = DataSet.Tables("Calidad")
        'i = 0
        'Do While DataSet.Tables("Calidad").Rows.Count > i
        '    Me.CboTipoCalidad.Items.Add(DataSet.Tables("Calidad").Rows(i)("NomCalidad"))
        '    Me.CboTipoCalidad.Text = DataSet.Tables("Calidad").Rows(0)("NomCalidad")
        '    i = i + 1
        'Loop



        'sql = "SELECT Nombre, Codigo FROM Daño WHERE (Activo = 1)"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "Daño")
        'i = 0
        'Do While DataSet.Tables("Daño").Rows.Count > i
        '    Me.CboDaño.Items.Add(DataSet.Tables("Daño").Rows(i)("Nombre"))
        '    Me.CboDaño.Text = DataSet.Tables("Daño").Rows(0)("Nombre")
        '    i = i + 1
        'Loop

        'sql = "SELECT  Codigo, Nombre FROM TipoCompra"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "TipoCompra")
        'i = 0
        'Do While DataSet.Tables("TipoCompra").Rows.Count > i
        '    Me.CboTipoCompra.Items.Add(DataSet.Tables("TipoCompra").Rows(i)("Nombre"))
        '    Me.CboTipoCompra.Text = DataSet.Tables("TipoCompra").Rows(0)("Nombre")
        '    i = i + 1
        'Loop

        'sql = "SELECT  Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto FROM EstadoFisico"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "Estado")
        'i = 0
        'Do While DataSet.Tables("Estado").Rows.Count > i
        '    Me.CboEstado.Items.Add(DataSet.Tables("Estado").Rows(i)("Descripcion"))
        '    Me.CboEstado.Text = DataSet.Tables("Estado").Rows(0)("Descripcion")
        '    i = i + 1
        'Loop



        sql = "SELECT * FROM Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")
        End If

        Me.CboCodigoProveedor.Columns(0).Caption = "Codigo"
        Me.CboCodigoProveedor.Columns(1).Caption = "Proveedor"
        Me.CboCodigoProveedor.Columns(2).Caption = "Origen"

        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboIngresoBascula.DataSource = DataSet.Tables("ListaProductos")
            Me.CboIngresoBascula.Text = DataSet.Tables("ListaProductos").Rows(0)("Descripcion_Producto")
        End If


        Me.CboIngresoBascula.Splits(0).DisplayColumns(1).Width = 400


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion  WHERE (NumeroRecepcion = N'-100000')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"

        Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False

        sql = "SELECT IdTipoCafe,Nombre FROM TipoCafe WHERE (IdTipoCafe = 1) OR (IdTipoCafe = 2)"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCafe")
        Me.CboTipoCafe.DisplayMember = "Nombre"
        Me.CboTipoCafe.DataSource = DataSet.Tables("TipoCafe")







        Me.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.TxtAno.Text = Microsoft.VisualBasic.DateAndTime.Year(Now)
        Me.TxtMes.Text = Microsoft.VisualBasic.DateAndTime.Month(Now)
        Me.TxtDia.Text = Microsoft.VisualBasic.DateAndTime.Day(Now)


        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If


        SqlString = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidades")
        If DataSet.Tables("Localidades").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        End If

        Me.CboLocalidad.DataSource = DataSet.Tables("Localidades")
        Me.CboLocalidad.Text = Me.LblSucursal.Text
        Me.CboLocalidad.Splits(0).DisplayColumns(1).Width = 400

        LeeArchivo = Mid(LeeArchivo, 1, 3)

        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & LeeArchivo & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad")
        If DataSet.Tables("Localidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Quien = "Load"
            Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
            IdLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
            IdTipoLugarAcopio = DataSet.Tables("Localidad").Rows(0)("TipoLugarAcopio")
            Me.TxtIdLocalidad.Text = DataSet.Tables("Localidad").Rows(0)("CodLugarAcopio")
            Me.CboLocalidad.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
            CodLugarAcopio = DataSet.Tables("Localidad").Rows(0)("CodLugarAcopio")

            NomLugarAcopioDefecto = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
            IdLugarAcopioDefecto = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
            CodLugarAcopioDefecto = DataSet.Tables("Localidad").Rows(0)("CodLugarAcopio")

        End If


        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT  * FROM LugarAcopio WHERE  (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad2")
        If DataSet.Tables("Localidad2").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Me.CboLiquidarLocalidad.Text = DataSet.Tables("Localidad2").Rows(0)("NomLugarAcopio")
            Me.CboLiquidarLocalidad.DataSource = DataSet.Tables("Localidad2")
        End If


        '///////////////////////////////////SI ES CENTRO DE ACOPIO QUITO LA OPCION DE LIQUIDAR /////////////////////////
        SqlString = "SELECT  TipoLocalidad.Descripcion, LugarAcopio.NomLugarAcopio, LugarAcopio.IdLugarAcopio, TipoLocalidad.IdTipoLocalidad FROM LugarAcopio INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad  WHERE (TipoLocalidad.IdTipoLocalidad = 12) AND (LugarAcopio.IdLugarAcopio = " & IdLugarAcopio & ") "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscoLocalidad")
        If DataSet.Tables("BuscoLocalidad").Rows.Count <> 0 Then
            Me.CboLiquidarLocalidad.Text = Me.CboLocalidad.Text
            Me.CboLiquidarLocalidad.Enabled = False
            Me.LblLiquidar.Enabled = False
            Me.Button16.Enabled = False
        Else
            Me.CboLiquidarLocalidad.Enabled = False
            Me.LblLiquidar.Enabled = False
            Me.Button16.Enabled = False
        End If

        Me.CboLiquidarLocalidad.Text = Me.CboLocalidad.Text

        '//////////////////////////////////////////////////////////COSECHA ///////////////////////////////////////////////////

        'Fecha = Format(Now, "yyyy-MM-dd")
        'Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        'SqlString = "SELECT *, YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (FechaInicial <= CONVERT(DATETIME, '" & Fecha & "', 102)) AND (FechaFinal >= CONVERT(DATETIME, '" & Fecha & "', 102))"
        SqlString = "SELECT IdCosecha,Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CDbl(CodigoCosecha) & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count = 0 Then
            Me.LblCosecha.Text = "Cosecha NO DEFINIDA"

        Else
            IdCosecha = DataSet.Tables("Cosecha").Rows(0)("IdCosecha")
            Cod_Cosecha = DataSet.Tables("Cosecha").Rows(0)("Codigo")
            Me.LblCosecha.Text = "Cosecha " & DataSet.Tables("Cosecha").Rows(0)("AñoIni") & "-" & DataSet.Tables("Cosecha").Rows(0)("AñoFin")
        End If


        '/////////////////////////////////////SERIE PARA RECEPCION EN LAENTRADA //////////////////////////////////////////////
        If Me.CboTipoCompra.Text = "Compra Directa" Then
            Me.TxtSerie.Text = "C" & Cod_Cosecha
        Else
            Me.TxtSerie.Text = "?"
        End If

        Dim Fecha As Date, Precio As Double

        Fecha = Format(CDate(Me.DtpFechaManual.Text), "dd/MM/yyyy") & " " & Format(CDate(Me.DtpHoraManual.Text), "HH:mm:ss")
        Precio = PrecioVenta(IdLugarAcopio, IdCalidad, CboCategoria.Text, Fecha)
        Precio = Format(Precio / 46, "##,##0.00")
        Me.TxtPrecio.Text = Precio

    End Sub

    Private Sub TrueDBGridComponentes_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColUpdate
        Dim CodProducto As String, SqlProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.txtsubtotal.Text = TotalRecepcion(Me.TxtNumeroEnsamble.Text, Me.DTPFecha.Text, Me.CboTipoRecepcion.Text)

        Select Case e.ColIndex
            Case 0
                CodProducto = Me.TrueDBGridComponentes.Columns(0).Text
                SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Productos")
                If DataSet.Tables("Productos").Rows.Count = 0 Then
                    MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                    Exit Sub
                Else
                    Me.TrueDBGridComponentes.Columns(1).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                    Me.TrueDBGridComponentes.Columns(5).Text = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")
                    If Me.TxtCodigo.Text <> "" Then
                        Me.TrueDBGridComponentes.Columns(3).Text = Me.TxtCodigo.Text
                    End If
                    Me.TrueDBGridComponentes.Col = 3
                End If
        End Select
    End Sub



    Private Sub TrueDBGridComponentes_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.AfterUpdate
        'Dim CodigoProducto As String = 0, Cantidad As Double = 0, Descripcion As String = "", CodigoBeams As String = "", UnidadMedida As String = ""
        'Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQlProveedor As String
        'Dim iposicion As Double, Fecha As String

        'Fecha = Format(Me.DTPFecha.Value, "yyyy-MM-dd")

        ''---------------------------------------------------------------------------------------------------------------------------------------
        ''------------------------------------------BUSCO LA ULTIMA LINEA -----------------------------------------------------------------------
        ''---------------------------------------------------------------------------------------------------------------------------------------
        'SQlProveedor = "SELECT  Detalle_Recepcion.* FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        'DataAdapter.Fill(DataSet, "Productos")
        'If DataSet.Tables("Productos").Rows.Count <> 0 Then

        '    If Me.TrueDBGridComponentes.Columns(3).Text <> "" Then
        '        Cantidad = Me.TrueDBGridComponentes.Columns(3).Text
        '    Else
        '        Cantidad = 0
        '    End If




        '    'iposicion = Me.BindingDetalle.Position
        '    'If Cantidad <> 0 Then

        '    '    iposicion = Me.BindingDetalle.Position
        '    '    If Not IsDBNull(DataSet.Tables("Productos").Rows(iposicion)("Descripcion_Producto")) Then
        '    '        Descripcion = DataSet.Tables("Productos").Rows(iposicion)("Descripcion_Producto")
        '    '    End If
        '    '    If Not IsDBNull(DataSet.Tables("Productos").Rows(iposicion)("Codigo_Beams")) Then
        '    '        CodigoBeams = DataSet.Tables("Productos").Rows(iposicion)("Codigo_Beams")
        '    '    End If
        '    '    If Not IsDBNull(DataSet.Tables("Productos").Rows(iposicion)("Unidad_Medida")) Then
        '    '        UnidadMedida = DataSet.Tables("Productos").Rows(iposicion)("Unidad_Medida")
        '    '    End If

        '    '    If Not IsDBNull(DataSet.Tables("Productos").Rows(iposicion)("Cod_Productos")) Then
        '    '        CodigoProducto = DataSet.Tables("Productos").Rows(iposicion)("Cod_Productos")
        '    '    End If


        '    '    Me.TrueDBGridComponentes.Row = iposicion + 1
        '    '    Me.TrueDBGridComponentes.Columns(0).Text = CodigoProducto
        '    '    Me.TrueDBGridComponentes.Columns(1).Text = Descripcion
        '    '    Me.TrueDBGridComponentes.Columns(2).Text = CodigoBeams
        '    '    Me.TrueDBGridComponentes.Columns(4).Text = UnidadMedida
        '    '    Me.TrueDBGridComponentes.Col = 3
        '    'End If




        'End If


        'Me.TrueDBGridComponentes.Row = Me.TrueDBGridComponentes.Row + 1

        If Me.TrueDBGridComponentes.RowCount <> 0 Then
            Me.DtpFechaManual.Enabled = True
            Me.DtpHoraManual.Enabled = True
        End If

    End Sub


    Private Sub TrueDBGridComponentes_BeforeUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TrueDBGridComponentes.BeforeUpdate
        'Dim ConsecutivoCompra As Double, NumeroRecepcion As String, Registros As Double, Iposicion As Double
        'Dim Linea As Double, CodigoProducto As String, Cantidad As Double = 0, Descripcion As String = "", CodigoBeams As String = "", UnidadMedida As String = ""
        'Dim CodigoBeamsOrigen As String = "", CodigoRecepcionBin As String = "", Calidad As String = "", Precio As Double
        'Dim Estado As String = "", SqlString As String
        'Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, PesoKg As Double

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
        '    Select Case Me.CboTipoRecepcion.Text
        '        Case "Recepcion"
        '            ConsecutivoCompra = BuscaConsecutivo("Recepcion")
        '        Case "Maquila"
        '            ConsecutivoCompra = BuscaConsecutivo("Maquila")
        '        Case "Lote"
        '            ConsecutivoCompra = BuscaConsecutivo("Lote")
        '    End Select
        'Else
        '    ConsecutivoCompra = Me.TxtNumeroEnsamble.Text
        'End If


        'NumeroRecepcion = Format(ConsecutivoCompra, "0000#")

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO ENCABEZADO DE RECEPCION /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'GrabaRecepcion(NumeroRecepcion)

        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO EL DETALLE DE LA RECEPCION /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'Registros = Me.BindingDetalle.Count
        'Iposicion = Me.BindingDetalle.Position
        'If Me.TrueDBGridComponentes.Columns(7).Text = "" Then
        '    Linea = BuscaLinea(NumeroRecepcion, Me.DTPFecha.Value, Me.CboTipoRecepcion.Text)
        'Else
        '    Linea = Me.TrueDBGridComponentes.Columns(7).Text
        'End If


        'If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Cantidad")) Then
        '    Cantidad = Me.BindingDetalle.Item(Iposicion)("Cantidad")
        'End If
        'If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Descripcion_Producto")) Then
        '    Descripcion = Me.BindingDetalle.Item(Iposicion)("Descripcion_Producto")
        'End If

        'If Me.CboTipoProducto.Text <> "" Then
        '    Calidad = Me.CboTipoProducto.Text
        'End If


        'If Me.OptMojado.Checked = True Then
        '    Estado = "Mojado"
        'Else
        '    Estado = "Humedo"
        'End If


        ''/////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////CONSULTO EL PRECIO DE VENTA //////////////////////////////////////
        ''////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT Productos.* FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        'DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapterProductos.Fill(DataSet, "Precios")
        'If Not DataSet.Tables("Precios").Rows.Count = 0 Then
        '    Select Case Me.CboTipoProducto.Text
        '        Case "A" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Venta")
        '        Case "B" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Lista")
        '        Case "C" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Compra")
        '    End Select

        'End If


        ''///////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////CONVERTIR DE LIBRAS A KG //////////////////////////////////////////
        ''////////////////////////////////////////////////////////////////////////////////////////////////
        'PesoKg = Cantidad
        'Cantidad = Cantidad / 2.20462



        'If Not IsDBNull(Me.BindingDetalle.Item(Iposicion)("Cod_Productos")) Then
        '    CodigoProducto = Me.BindingDetalle.Item(Iposicion)("Cod_Productos")
        '    GrabaDetalleRecepcion(NumeroRecepcion, CodigoProducto, Cantidad, Linea, Descripcion, Calidad, Estado, Precio, PesoKg, Me.CboTipoRecepcion.Text)
        'End If

        'Me.TrueDBGridComponentes.Columns(7).Text = Linea
        'TxtNumeroEnsamble.Text = NumeroRecepcion
        'Me.TrueDBGridComponentes.Col = 4


    End Sub

    Private Sub TrueDBGridComponentes_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.ButtonClick
        Dim CodProducto As String, SqlProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Quien = "CodigoProductosDetalle"

        Select Case Me.TrueDBGridComponentes.Col
            Case 1
                Quien = "CodigoProductosDetalle"
                My.Forms.FrmConsultas.ShowDialog()
                If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                    Me.TrueDBGridComponentes.Columns(1).Text = My.Forms.FrmConsultas.Codigo
                    Me.TrueDBGridComponentes.Columns(2).Text = My.Forms.FrmConsultas.Descripcion
                    Me.TrueDBGridComponentes.Col = 3

                    CodProducto = My.Forms.FrmConsultas.Codigo
                    Me.TxtCodigo.Text = My.Forms.FrmConsultas.Codigo
                    SqlProveedor = "SELECT  * FROM Productos WHERE (Cod_Productos = '" & CodProducto & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                    DataAdapter.Fill(DataSet, "Productos")
                    If DataSet.Tables("Productos").Rows.Count = 0 Then
                        MsgBox("El Producto Seleccionado no Existe", MsgBoxStyle.Critical, "Sistema Facturacion")
                        Exit Sub
                    Else
                        Me.TrueDBGridComponentes.Columns(2).Text = DataSet.Tables("Productos").Rows(0)("Descripcion_Producto")
                        Me.TrueDBGridComponentes.Columns(3).Text = Me.CboCategoria.Text

                        'If Me.OptHumedo.Checked = True Then
                        '    Me.TrueDBGridComponentes.Columns(4).Text = "Humedo"
                        'ElseIf Me.OptMojado.Checked = True Then
                        '    Me.TrueDBGridComponentes.Columns(4).Text = "Mojado"
                        'End If

                        Me.TrueDBGridComponentes.Columns(4).Text = Me.CboEstado.Text

                        If Me.TxtCodigo.Text <> "" Then
                            Me.TrueDBGridComponentes.Columns(1).Text = Me.TxtCodigo.Text
                        End If
                        If Me.TxtNumeroRecepcion.Text <> "" Then
                            Me.TrueDBGridComponentes.Columns(0).Text = Me.TxtNumeroRecepcion.Text
                        End If
                        'Me.TrueDBGridComponentes.Columns(6).Text = DataSet.Tables("Productos").Rows(0)("Unidad_Medida")
                    End If
                End If
                'Case 3
                '    Quien = "CodigoBeamsRecepcion"
                '    My.Forms.FrmConsultas.ShowDialog()
                '    If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                '        Me.TrueDBGridComponentes.Columns(2).Text = My.Forms.FrmConsultas.Codigo
                '        Me.TrueDBGridComponentes.Col = 3
                '        Me.TxtCodigo.Text = My.Forms.FrmConsultas.Codigo
                '        Me.TxtNumeroRecepcion.Text = My.Forms.FrmConsultas.NumeroRecepcion
                '        Me.TrueDBGridComponentes.Columns(7).Text = My.Forms.FrmConsultas.NumeroRecepcion
                '    End If
                'Case 4
                '    Quien = "CodigoBeams"
                '    My.Forms.FrmConsultas.ShowDialog()
                '    If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
                '        Me.TrueDBGridComponentes.Columns(3).Text = My.Forms.FrmConsultas.Codigo
                '        Me.TrueDBGridComponentes.Col = 4

                '    End If
        End Select
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim respuesta As Double
        respuesta = MsgBox("¿Esta Seguro de Salir?", MsgBoxStyle.YesNo, "Sistema Bascula")
        If respuesta = 7 Then
            Exit Sub
        End If
        Button10_Click(sender, e)
        Me.sp.Close()
        Me.Close()
    End Sub

    Private Sub CboConductor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboConductor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = ""
        SqlProveedor = "SELECT  Conductor, Id_identificacion, Id_Placa FROM Recepcion WHERE  (Conductor = '" & Me.CboConductor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Id_identificacion")) Then
                Me.txtid.Text = DataSet.Tables("Conductor").Rows(0)("Id_identificacion")
            End If

            If Not IsDBNull(DataSet.Tables("Conductor").Rows(0)("Id_Placa")) Then
                Me.txtplaca.Text = DataSet.Tables("Conductor").Rows(0)("Id_Placa")
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim SQLProveedor As String, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, Posicion As Double, CodigoLinea As String = ""
        Dim CodigoIngreso As String = "", SqlString As String = "", Fecha As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Ingreso?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Resultado <> 6 Then
            Exit Sub
        End If

        Posicion = Me.BindingDetalle.Position
        If Not IsDBNull(Me.BindingDetalle.Item(Posicion)("Linea")) Then
            CodigoLinea = Me.BindingDetalle.Item(Posicion)("Linea")
        End If

        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")

        SQLProveedor = "SELECT * FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') AND (id_Eventos = " & CodigoLinea & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Deducciones")
        If Not DataSet.Tables("Deducciones").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Close()
            StrSqlUpdate = "DELETE FROM [Detalle_Recepcion] WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') AND (id_Eventos = " & CodigoLinea & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If



        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion   WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        Me.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
        Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 7


        CalcularEquivalente()

    End Sub

    Private Sub CalcularEquivalente()
        Dim Registro As Double, SubTotal As Double, QQ As Double, Tara As Double, PesoKg As Double, PesoNetoKg As Double, PesoNetoLb As Double
        Dim i As Double, HumedadReal As Double

        '///////////////////////////////////////////////////SUMO EL TOTAL DEL GRID ///////////////////////////////////////////
        Categoria = Me.CboCategoria.Text
        Estado = Me.CboEstado.Text
        Registro = Me.TrueDBGridComponentes.RowCount
        i = 0
        Me.TrueDBGridComponentes.Row = i
        SubTotal = 0
        Do While Registro > i
            If Me.TrueDBGridComponentes.Columns(10).Text = "" Then
                Exit Do
            End If


            QQ = Me.TrueDBGridComponentes.Columns(10).Text
            Tara = Me.TrueDBGridComponentes.Columns("Tara").Text
            PesoKg = Me.TrueDBGridComponentes.Columns("PesoKg").Text
            PesoNetoKg = Me.TrueDBGridComponentes.Columns("PesoNetoKg").Text
            PesoNetoLb = Me.TrueDBGridComponentes.Columns("PesoNetoLb").Text

            SubTotal = PesoNetoKg + SubTotal



            i = i + 1
            Me.TrueDBGridComponentes.Row = i
        Loop


        HumedadxDefecto = Me.HumedadxDefecto

        If Me.TxtHumedad.Text <> "" Then
            HumedadReal = Me.TxtHumedad.Text
        Else
            HumedadReal = 0
        End If


        Me.txtsubtotal.Text = Format(SubTotal, "##,##0.00")

        If CalcularEqOreado(IdCosecha, Me.IdEstadoFisico) = True Then
            Me.TxtEqOreado.Text = Format(SubTotal * (1 - (HumedadxDefecto - 42) / 100), "##,##0.00")
            Me.TxtOreadoReal.Text = Format(SubTotal * (1 - (HumedadReal - 42) / 100), "##,##0.00")
        Else
            Me.TxtEqOreado.Text = Format(SubTotal, "##,##0.00")
            Me.TxtOreadoReal.Text = Format(SubTotal, "##,##0.00")
        End If

    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'LimpiaRecepcion()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim NumeroRecibo As String, SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim FechaRecibo As Date, Cadena As String, CadenaDiv() As String, SubTotal As Double, HumedadReal As Double, IdEstadoDocumento As Double
        Dim IdDetalleReciboCafe As Double, Imperfeccion As Double, IdFinca As Double

        Button10_Click(sender, e)
        Quien = "Recepcion"
        My.Forms.FrmConsultas.Text = "Consulta Recibo"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA RECIBOS"
        My.Forms.FrmConsultas.Filtro = CodLugarAcopioDefecto
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then

            Quien = "CCC"
            Me.CboTipoRecepcion.Text = My.Forms.FrmConsultas.TipoCompra
            Me.DTPFecha.Text = FrmConsultas.Fecha
            Me.DtpFechaManual.Value = FrmConsultas.Fecha
            Me.CboConductor.Text = FrmConsultas.Conductor
            Quien = "Pegar"
            Me.CboCodigoProveedor.Text = FrmConsultas.CodProveedor
            Quien = "CCC"

            '--------
            '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
            SqlString = "SELECT  IdFinca, CodFinca, IdProductor, NomFinca, UbicaFinca, FechaMovimiento FROM Finca  WHERE (IdProductor = '" & IdProductor & "' )"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "ConsultaFinca")
            Me.CboFinca.DataSource = DataSet.Tables("ConsultaFinca")
            Me.CboFinca.DisplayMember = "NomFinca"

            Me.TxtNumeroEnsamble.Text = FrmConsultas.Codigo


            Cadena = FrmConsultas.NumeroRecibo
            FechaRecibo = FrmConsultas.Fecha
            IdReciboCafe = FrmConsultas.IdReciboCafe

            If Len(Trim(Cadena)) = 10 Then
                CadenaDiv = Cadena.Split("-")
                NumeroRecibo = CadenaDiv(1)
                Me.TxtNumeroRecibo.Text = NumeroRecibo
            ElseIf Len(Trim(Cadena)) > 10 Then
                CadenaDiv = Cadena.Split("-")
                NumeroRecibo = CadenaDiv(2)
                Me.TxtNumeroRecibo.Text = NumeroRecibo
            Else
                Me.TxtNumeroRecibo.Text = Cadena
            End If


            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////BUSCO LOS DATOS DEL RECIBO /////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  ReciboCafePergamino.*,LugarAcopio.CodLugarAcopio As LocalidadRecibo, LugarAcopio.NomLugarAcopio, Dano.Nombre AS NombreDano, TipoCafe.Nombre AS NombreTipoCafe, Calidad.NomCalidad, LugarAcopio_1.NomLugarAcopio AS LocalidadLiquidar, TipoCompra.Nombre AS NombreTipoCompra, TipoIngreso.Descripcion AS TipoIngreso FROM ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN LugarAcopio AS LugarAcopio_1 ON ReciboCafePergamino.IdLocalidadLiquidacion = LugarAcopio_1.IdLugarAcopio INNER JOIN TipoCompra ON ReciboCafePergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN TipoIngreso ON ReciboCafePergamino.IdTipoIngreso = TipoIngreso.IdECS  " & _
                         "WHERE (ReciboCafePergamino.Codigo = '" & Cadena & "') AND (ReciboCafePergamino.IdReciboPergamino = " & IdReciboCafe & ")"
            '"WHERE (ReciboCafePergamino.Codigo = '" & Cadena & "') AND (ReciboCafePergamino.IdCosecha = " & IdCosecha & ") AND (ReciboCafePergamino.IdTipoCafe = " & IdTipoCafe & ") AND (ReciboCafePergamino.IdLocalidad = " & IdLugarAcopio & ") AND (ReciboCafePergamino.IdTipoCompra = " & IdTipoCompra & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                Quien = "Load"
                Me.CboTipoCafe.Text = DataSet.Tables("Consulta").Rows(0)("NombreTipoCafe")
                Me.CboTipoCompra.Text = DataSet.Tables("Consulta").Rows(0)("NombreTipoCompra")
                TipoCompra = DataSet.Tables("Consulta").Rows(0)("NombreTipoCompra")

                Me.NumeroTemporal = Me.Random.Next()

                Quien = "CCC"
                Me.CmdConfirma.Enabled = True
                '/////////////////BUSCO EL LUGAR DE ACOPIO ////////////////////////////////////////////
                IdEstadoDocumento = DataSet.Tables("Consulta").Rows(0)("IdEstadoDocumento")
                Hora = DataSet.Tables("Consulta").Rows(0)("Fecha")
                Me.LblHora.Text = Format(Hora, "hh:mm:ss tt")
                'Me.DtpHoraManual.Value = Format(Hora, "hh:mm:ss tt")
                Me.Timer1.Enabled = False

                '////////////////////////////////////BUSCO LOS DATOS DE LA FINCA ///////////////////////////
                IdFinca = DataSet.Tables("Consulta").Rows(0)("IdFinca")
                SqlString = "SELECT   *  FROM Finca  WHERE(IdFinca = " & IdFinca & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Finca")
                If DataSet.Tables("Finca").Rows.Count <> 0 Then
                    Me.CboFinca.Text = DataSet.Tables("Finca").Rows(0)("NomFinca")
                End If


                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Observacion")) Then
                    Me.Observaciones = DataSet.Tables("Consulta").Rows(0)("Observacion")
                End If

                Me.CboLocalidad.Text = DataSet.Tables("Consulta").Rows(0)("NomLugarAcopio")


                Me.CboTipoCalidad.Text = DataSet.Tables("Consulta").Rows(0)("NomCalidad")
                Me.CboLiquidarLocalidad.Text = DataSet.Tables("Consulta").Rows(0)("LocalidadLiquidar")

                Quien = "CCC"
                Me.CboTipoIngresoBascula.Text = DataSet.Tables("Consulta").Rows(0)("TipoIngreso")
                Me.CboDaño.Text = DataSet.Tables("Consulta").Rows(0)("NombreDano")

                If Me.CboCodigoProveedor.Text = "00001" Then
                    If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("ProductorManual")) Then
                        Me.txtnombre.Text = DataSet.Tables("Consulta").Rows(0)("ProductorManual")
                    End If
                    If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("FincaManual")) Then
                        Me.TxtFinca.Text = DataSet.Tables("Consulta").Rows(0)("FincaManual")
                    End If
                    If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("CedulaManual")) Then
                        Me.TxtNumeroCedula.Text = DataSet.Tables("Consulta").Rows(0)("CedulaManual")
                    End If
                End If

                If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
                    Me.TxtNumeroRecibo.Enabled = True
                    Me.TxtNumeroRecibo.ReadOnly = True

                    Me.DtpFechaManual.Visible = True
                    Me.DtpFechaManual.Text = Format(DataSet.Tables("Consulta").Rows(0)("Fecha"), "dd/MM/yyyy")
                    Me.DtpHoraManual.Visible = True
                    Me.DtpHoraManual.Text = Format(Hora, "hh:mm:ss tt")


                End If

                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("Serie2")) Then
                    Me.TxtSerie.Text = DataSet.Tables("Consulta").Rows(0)("Serie2")
                Else
                    Me.TxtSerie.Text = ""
                End If

                If Me.TxtSerie.Text = "?" Then
                    Me.TxtSerie.Text = ""
                End If

                Me.TxtIdLocalidad.Text = DataSet.Tables("Consulta").Rows(0)("LocalidadRecibo")

                SqlString = "SELECT  DetalleReciboCafePergamino.IdDetalleReciboPergamino, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.IdTipoSaco, DetalleReciboCafePergamino.IdEdoFisico, DetalleReciboCafePergamino.PesoBruto, EstadoFisico.IdEdoFisico AS Expr1, EstadoFisico.Descripcion, EstadoFisico.HumedadXDefecto FROM DetalleReciboCafePergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico " & _
                            "WHERE(DetalleReciboCafePergamino.IdReciboPergamino = " & IdReciboCafe & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Detalle")
                If DataSet.Tables("Detalle").Rows.Count <> 0 Then
                    Imperfeccion = DataSet.Tables("Detalle").Rows(0)("Imperfeccion")
                    Me.CboEstado.Text = DataSet.Tables("Detalle").Rows(0)("Descripcion")
                    Me.TxtImperfecion.Text = Imperfeccion
                    HumedadxDefecto = DataSet.Tables("Detalle").Rows(0)("HumedadXDefecto")
                    HumedadReal = DataSet.Tables("Detalle").Rows(0)("Humedad")
                    Me.TxtHumedad.Text = HumedadReal
                    HumedadxDefecto = DataSet.Tables("Detalle").Rows(0)("HumedadXDefecto")
                    HumedadReal = DataSet.Tables("Detalle").Rows(0)("Humedad")
                End If




                SubTotal = Me.txtsubtotal.Text
                'HumedadxDefecto = Me.HumedadxDefecto
                'HumedadReal = Me.TxtHumedad.Text

                If CalcularEqOreado(IdCosecha, Me.IdEstadoFisico) = True Then
                    Me.TxtEqOreado.Text = Format(SubTotal * (1 - (HumedadxDefecto - 42) / 100), "##,##0.00")
                    Me.TxtOreadoReal.Text = Format(SubTotal * (1 - (HumedadReal - 42) / 100), "##,##0.00")
                Else
                    Me.TxtEqOreado.Text = Format(SubTotal, "##,##0.00")
                    Me.TxtOreadoReal.Text = Format(SubTotal, "##,##0.00")
                End If


                Me.TxtNumeroEnsamble.Text = FrmConsultas.Codigo

                If IdEstadoDocumento = "294" Then

                    EstadoDoc = "Confirmado"
                    Me.CboEstadoDocumeto.Text = "Confirmado"
                    Me.CboEstadoDocumeto.Enabled = False
                    Me.TrueDBGridComponentes.Enabled = False
                    Me.CboTipoCafe.Enabled = False
                    Me.CboTipoCalidad.Enabled = False
                    Me.CboCodigoProveedor.Enabled = False
                    Me.CboTipoCompra.Enabled = False
                    Me.CboTipoDocumento.Enabled = False
                    Me.CboTipoIngresoBascula.Enabled = False
                    Me.CboTipoRecepcion.Enabled = False
                    Me.CboCategoria.Enabled = False
                    Me.CboDaño.Enabled = False
                    Me.CboEstado.Enabled = False
                    Me.CboFinca.Enabled = False
                    Me.TxtNumeroCedula.Enabled = False
                    Me.TxtFinca.Enabled = False
                    Me.txtnombre.Enabled = False
                    Me.CmdProductorManual.Enabled = False
                    Me.Button2.Enabled = False
                    Me.Button14.Enabled = False
                    Me.Button15.Enabled = False
                    Me.CboLocalidad.Enabled = False
                    Me.CboLiquidarLocalidad.Enabled = False
                    Me.Button16.Enabled = False
                    Me.CmdPesada.Enabled = False
                    Me.TxtHumedad.Enabled = False
                    Me.TxtImperfecion.Enabled = False
                    Me.CmdObservaciones.Enabled = False
                    Me.Button11.Enabled = False
                    Me.Button10.Enabled = False
                    Me.Button7.Enabled = False
                    Me.Button6.Enabled = False
                    Me.CmdConfirma.Enabled = False
                    Me.Button12.Enabled = True
                    Me.Button4.Enabled = True
                    Me.CboPignorado.Enabled = False
                    Me.ListBoxCertificados.Enabled = False
                    Me.DtpFechaManual.Enabled = False
                    Me.DtpHoraManual.Enabled = False

                ElseIf IdEstadoDocumento = "292" Then

                    EstadoDoc = "Anulado"
                    Me.CboEstadoDocumeto.Text = "Anulado"
                    Me.CboEstadoDocumeto.Enabled = False
                    Me.TrueDBGridComponentes.Enabled = False
                    Me.CboTipoCafe.Enabled = False
                    Me.CboTipoCalidad.Enabled = False
                    Me.CboCodigoProveedor.Enabled = False
                    Me.CboTipoCompra.Enabled = False
                    Me.CboTipoDocumento.Enabled = False
                    Me.CboTipoIngresoBascula.Enabled = False
                    Me.CboTipoRecepcion.Enabled = False
                    Me.CboCategoria.Enabled = False
                    Me.CboDaño.Enabled = False
                    Me.CboEstado.Enabled = False
                    Me.CboFinca.Enabled = False
                    Me.TxtNumeroCedula.Enabled = False
                    Me.TxtFinca.Enabled = False
                    Me.txtnombre.Enabled = False
                    Me.CmdProductorManual.Enabled = False
                    Me.Button2.Enabled = False
                    Me.Button14.Enabled = False
                    Me.Button15.Enabled = False
                    Me.CboLocalidad.Enabled = False
                    Me.CboLiquidarLocalidad.Enabled = False
                    Me.Button16.Enabled = False
                    Me.CmdPesada.Enabled = False
                    Me.TxtHumedad.Enabled = False
                    Me.TxtImperfecion.Enabled = False
                    Me.CmdObservaciones.Enabled = False
                    Me.Button11.Enabled = False
                    Me.Button10.Enabled = False
                    Me.Button7.Enabled = False
                    Me.Button6.Enabled = False
                    Me.CmdConfirma.Enabled = False

                    Me.Button12.Enabled = False
                    Me.Button4.Enabled = False
                    Me.CboPignorado.Enabled = False
                    Me.ListBoxCertificados.Enabled = False
                    Me.DtpFechaManual.Enabled = False
                    Me.DtpHoraManual.Enabled = False

                ElseIf IdEstadoDocumento = "293" Then


                    EstadoDoc = "Editable"
                    Me.CboEstadoDocumeto.Text = "Editable"
                    Me.CboTipoCompra.Enabled = True

                    'ESTO LO EN COMENTARIOS POR QUE MARIELOS DICE QUE NO  08-02-2019
                    'If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
                    '    Me.CboTipoCompra.Enabled = True
                    'Else
                    '    Me.CboTipoCompra.Enabled = False
                    'End If

                    If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
                        Me.CboLocalidad.Enabled = True
                        Me.Button15.Enabled = True
                    Else
                        Me.CboLocalidad.Enabled = False
                        Me.Button15.Enabled = False
                    End If


                    '////////////////////////////////MODIFICADO 12-09-2019 ...SE PERMITE CAMBIAR LAS PESADAS EN EDITABLE -----------------------
                    Me.TrueDBGridComponentes.Enabled = True
                    Me.CboTipoCafe.Enabled = False
                    Me.CboTipoIngresoBascula.Enabled = False
                    Me.Button12.Enabled = False
                    Me.Button4.Enabled = False
                    Me.CboEstadoDocumeto.Enabled = True
                    Me.TrueDBGridComponentes.Enabled = False
                    Me.Button6.Enabled = False
                    Me.CboTipoCafe.Enabled = True
                    Me.CboTipoCalidad.Enabled = True
                    Me.CboCodigoProveedor.Enabled = True
                    Me.CboTipoDocumento.Enabled = True
                    Me.CboTipoRecepcion.Enabled = True
                    Me.CboCategoria.Enabled = False
                    Me.CboDaño.Enabled = True
                    Me.CboEstado.Enabled = True
                    Me.CboFinca.Enabled = True
                    Me.TxtNumeroCedula.Enabled = True
                    Me.TxtFinca.Enabled = True
                    Me.txtnombre.Enabled = True
                    Me.CmdProductorManual.Enabled = True
                    Me.Button2.Enabled = True
                    Me.Button14.Enabled = True
                    Me.CboLiquidarLocalidad.Enabled = False
                    Me.Button16.Enabled = False
                    Me.Button11.Enabled = True   '-------------DICE LA MARIELOS QUEDA LIBRE EL BOTON DE PESADAS   04/09/2019 -----
                    Me.Button10.Enabled = True
                    Me.CmdPesada.Enabled = False
                    Me.TxtHumedad.Enabled = True
                    Me.TxtImperfecion.Enabled = True
                    Me.CboPignorado.Enabled = True
                    Me.ListBoxCertificados.Enabled = True

                    Me.DtpFechaManual.Enabled = True
                    Me.DtpHoraManual.Enabled = True



                End If

            End If




        End If

        '////////////////////////////////////////VALIDACION SEGUN NUEVO REQUERIMIENTO ///////////////////////////////////
        If Me.CboTipoCompra.Text = "Compra Directa" Then
            Me.Button12.Enabled = False
            'Else
            '    Me.Button12.Enabled = True
        End If

        My.Application.DoEvents()
        'Siguiente()
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        Dim SqlCompras As String, Fecha As String, TipoCompra As String, SubTotal As Double = 0
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sql As String


        If Quien = "NumeroCompras" Then
            Exit Sub
        ElseIf Quien = "MetodoPago" Then
            Exit Sub
        End If

        Try



            If Me.TxtNumeroEnsamble.Text <> "-----0-----" Then
                TipoCompra = Me.CboTipoRecepcion.Text
                Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")
                'SqlCompras = "SELECT Proveedor.Nombre_Proveedor, Recepcion.* FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor  " & _
                '             "WHERE (Recepcion.Activo = 1) AND (Recepcion.NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Recepcion.Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Recepcion.TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"
                SqlCompras = "SELECT Proveedor.Nombre_Proveedor, Recepcion.* FROM Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor  " & _
                             "WHERE (Recepcion.NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Recepcion.Fecha BETWEEN CONVERT(DATETIME, '" & Fecha & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Fecha & " 23:59:00', 102)) AND (Recepcion.TipoRecepcion = 'Recepcion')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
                DataAdapter.Fill(DataSet, "Recepcion")
                If Not DataSet.Tables("Recepcion").Rows.Count = 0 Then
                    '///////////////////////////////////CARGO LOS DATOS DEL PROVEEDOR/////////////////////////////////////////////////////////////////////////
                    Me.CboCodigoProveedor.Text = DataSet.Tables("Recepcion").Rows(0)("Cod_Proveedor")
                    Me.CboConductor.Text = DataSet.Tables("Recepcion").Rows(0)("Conductor")
                    Me.txtid.Text = DataSet.Tables("Recepcion").Rows(0)("Id_identificacion")
                    Me.txtplaca.Text = DataSet.Tables("Recepcion").Rows(0)("Id_Placa")
                    Me.txtobservaciones.Text = DataSet.Tables("Recepcion").Rows(0)("Observaciones")
                    Me.txtsubtotal.Text = TotalRecepcion(Me.TxtNumeroEnsamble.Text, Me.DTPFecha.Text, Me.CboTipoRecepcion.Text)


                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
                    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion  WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                    DataAdapter.Fill(DataSet, "DetalleRecepcion")
                    Me.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
                    Me.TrueDBGridComponentes.DataSource = Me.BindingDetalle
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
                    Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
                    Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
                    Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
                    Me.TrueDBGridComponentes.Columns(3).Caption = "Categ"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
                    Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
                    Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
                    Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim DateFecha As DateTime = Me.DTPFecha.Text, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Fecha As String, SqlString As String, DataSet As New DataSet, Registro As Double, i = 0, CantSacos As Double = 0
        Dim PesoBruto As Double, Tara As Double, idCalidad As Double, NumeroRecibo As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Registros As Double, IdCertificado As Double
        Dim StrSqlUpdate As String



        Fecha = Format(DateFecha, "yyyy-MM-dd") & " " & Me.LblHora.Text
        Fecha = Format(CDate(Fecha), "dd/MM/yyyy")

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO ENCABEZADO DE RECEPCION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Me.TxtProveedor.Text = "00001" Then
            IdProductor = 1
            If Len(Trim(Me.TxtNumeroCedula.Text)) <> 14 Then
                MsgBox("Se necesitan 14 digitos para la cedula", MsgBoxStyle.Critical, "Bascula")
                Exit Sub
            End If
        End If

        If Me.txtnombre.Text = "" Then
            MsgBox("Se Necesita Nombre Productor", MsgBoxStyle.Critical, "Bascula")
            Exit Sub
        End If


        Me.Button7.Enabled = False

        CalcularEquivalente()

        If Me.CboEstadoDocumeto.Text = "Confirmado" Then
            IdEstadoDocumento = "294"
        ElseIf Me.CboEstadoDocumeto.Text = "Anulado" Then
            IdEstadoDocumento = "292"
        ElseIf Me.CboEstadoDocumeto.Text = "Editable" Then
            IdEstadoDocumento = "293"
        End If



        If IdTipoCompra = 108 Then
            If IdEstadoDocumento = "294" Then
                'Quien = "Recibo"
                '////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////VERIFICO PRECIO ////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
                    Fecha = Format(DateFecha, "yyyy-MM-dd") & " " & Me.LblHora.Text
                Else
                    Fecha = Format(Me.DtpFechaManual.Value, "yyyy-MM-dd") & " " & Format(Me.DtpHoraManual.Value, "hh:mm:ss tt")
                End If

                If CalculaPrecioBruto(Fecha, IdLugarAcopio, IdRangoImperfeccion, IdDaño, 609, IdEstadoFisico) <= 1 Then
                    MsgBox("No Existen Precios para la Liquidacion¡¡¡", MsgBoxStyle.Critical, "Sistema Bascula")
                    Me.Button7.Enabled = True
                    Exit Sub
                End If

            End If
        End If

        If Me.CboTipoIngresoBascula.Text <> DescripcionTipoIngreso("BA") Then
            NumeroRecibo = Me.TxtNumeroRecibo.Text

            SqlString = "SELECT  Codigo, IdTipoCafe, IdCosecha, IdLocalidad FROM ReciboCafePergamino WHERE (Codigo = '" & NumeroRecibo & "') AND (IdLocalidad = " & IdLugarAcopio & ") AND (IdCosecha =" & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdTipoIngreso = 295)"
            'SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (IdTipoDocumento = 972) AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Num")
            If DataSet.Tables("Num").Rows.Count <> 0 Then
                MsgBox("Existen Recibos con este numero", MsgBoxStyle.Exclamation, "Recibos")
                CboTipoIngresoBascula_SelectedIndexChanged(sender, e)
                Me.Button7.Enabled = True
                Exit Sub
            End If

            DataSet.Tables("Num").Reset()

        End If


        If Me.BindingDetalle.Count <> 0 Then

            ConsecutivoRecibo(Me.CboTipoIngresoBascula.Text)

            GrabaRecepcion(Me.TxtNumeroEnsamble.Text)

            If Me.CboTipoRecepcion.Text <> "RePesaje" Then



                If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
                    'GrabaRecibo(Me.TxtNumeroEnsamble.Text, Me.DTPFecha.Text)
                    Fecha = Format(DateFecha, "yyyy-MM-dd") & " " & Me.LblHora.Text

                    '/////////////////////////////////////SERIE PARA RECEPCION EN LAENTRADA //////////////////////////////////////////////
                    If Me.CboTipoCompra.Text = "Compra Directa" Then
                        NumeroRecibo = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text & "-" & Me.TxtNumeroRecibo.Text
                    Else
                        NumeroRecibo = Me.TxtIdLocalidad.Text & "-" & Me.TxtNumeroRecibo.Text
                    End If


                    GrabaRecibo(NumeroRecibo, Fecha)

                Else


                    Fecha = Format(Me.DtpFechaManual.Value, "yyyy-MM-dd") & " " & Format(Me.DtpHoraManual.Value, "hh:mm:ss tt")
                    NumeroRecibo = Me.TxtNumeroRecibo.Text
                    GrabaRecibo(NumeroRecibo, Fecha)


                End If




                SqlString = "SELECT  ReciboCafePergamino.*  FROM ReciboCafePergamino WHERE (Codigo = '" & NumeroRecibo & "') AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLocalidad = " & IdLugarAcopio & ") AND (IdTipoCompra = " & IdTipoCompra & ") ORDER BY IdReciboPergamino DESC"   'AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd") & "', 102))
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdRecibo = DataSet.Tables("Consulta").Rows(0)("IdReciboPergamino")
                    'NumeroRecibo = DataSet.Tables("Consulta").Rows(0)("NumeroReciboCafe")
                    '////////////////////////////////////EDITO LA RECEPCION Y AGREGO EL ID DEL RECIBO /////////////////////////////////
                    SqlString = "SELECT Recepcion.* FROM Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Recepcion")
                    If DataSet.Tables("Recepcion").Rows.Count <> 0 Then

                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlString = "UPDATE [Recepcion] SET [IdReciboPergamino] = '" & IdRecibo & "', [NumeroReciboCafe] = '" & NumeroRecibo & "' " & _
                                    "WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    Else
                        '/////////////////////////////////////SI NO LO ENCUENTRA BUSCO POR EL NUMERO TEMPORAL PARA CONFIRMAR ////////////////////////////////
                        SqlString = "SELECT Recepcion.* FROM Recepcion WHERE (IdReciboPergamino = '" & NumeroTemporal & "') "
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "Temporal")
                        If DataSet.Tables("Temporal").Rows.Count <> 0 Then

                            '//////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////
                            SqlString = "UPDATE [Recepcion] SET [IdReciboPergamino] = '" & IdRecibo & "', [NumeroReciboCafe] = '" & NumeroRecibo & "' " & _
                                        "WHERE (IdReciboPergamino = '" & NumeroTemporal & "') "
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()


                        End If




                    End If


                End If


                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////GRABO EL DETALLE DE LA FINCA //////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If IdEstadoDocumento = "294" Then

                    SqlString = "SELECT CertificadoXFinca.IdCertificadoXFinca, CertificadoXFinca.IdCertificado, CertificadoXFinca.IdFinca, CertificadoXFinca.IdCosecha, CertificadoXFinca.Vigencia, Finca.NomFinca, Finca.CodFinca, Finca.IdProductor FROM  CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca  " & _
                                "WHERE (Finca.IdFinca = " & IdFinca & ") AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & ") ORDER BY CertificadoXFinca.Vigencia DESC"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Certificado")
                    Registros = DataSet.Tables("Certificado").Rows.Count
                    i = 0
                    Do While Registros > i

                        IdCertificado = DataSet.Tables("Certificado").Rows(i)("IdCertificado")
                        '//////////////////////////////////////////////////////////////////////////////////////////////
                        '////////////////////////////GRABO LOS CERTIFICADOS///////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////////////////////////////////
                        SqlString = "INSERT INTO CertificadoXRecibo ([IdRecibo],[IdCosecha],[IdCertificado],[IdLocalidad]) " & _
                                    "VALUES(" & IdRecibo & "," & IdCosecha & "," & IdCertificado & "," & IdLugarAcopio & ")"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                        i = i + 1
                    Loop

                End If





                Dim CodigoProducto As String, Cantidad As Double, Linea As Double, Descripcion As String, Calidad As String, Estado As String, Precio As Double, PesoKg As Double, QQ As Double, PesoNetoKg As Double, Tara1 As Double
                '///////////////////////////////////////////TOTALES /////////////////////////////////////////////
                Registro = Me.BindingDetalle.Count
                'Registro = Me.TrueDBGridComponentes.RowCount
                i = 0
                'Me.TrueDBGridComponentes.Row = i
                Tara = 0
                CantSacos = 0
                PesoBruto = 0
                Do While Registro > i

                    'If Me.TrueDBGridComponentes.Columns(10).Text = "" Then
                    '    Exit Do
                    'End If

                    'If Me.TrueDBGridComponentes.Columns(10).Text <> "" Then
                    '    CantSacos = CDbl(Me.TrueDBGridComponentes.Columns(10).Text) + CantSacos
                    '    QQ = CDbl(Me.TrueDBGridComponentes.Columns(10).Text) + QQ
                    'End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("Saco")) Then
                        CantSacos = Me.BindingDetalle.Item(i)("Saco") + CantSacos
                        QQ = Me.BindingDetalle.Item(i)("Saco")
                    End If


                    'If Me.TrueDBGridComponentes.Columns(6).Text <> "" Then
                    '    PesoBruto = CDbl(Me.TrueDBGridComponentes.Columns(6).Text) + PesoBruto
                    'End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("PesoKg")) Then
                        PesoBruto = Me.BindingDetalle.Item(i)("PesoKg") + PesoBruto
                    End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("Tara")) Then
                        Tara = Me.BindingDetalle.Item(i)("Tara") + Tara
                        Tara1 = Me.BindingDetalle.Item(i)("Tara")
                    End If

                    'If Me.TrueDBGridComponentes.Columns(7).Text <> "" Then
                    '    Tara = CDbl(Me.TrueDBGridComponentes.Columns(7).Text) + Tara
                    'End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("Cod_Productos")) Then
                        CodigoProducto = Me.BindingDetalle.Item(i)("Cod_Productos")
                    End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("Cantidad")) Then
                        Cantidad = Me.BindingDetalle.Item(i)("Cantidad")
                    End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("Linea")) Then
                        Linea = Me.BindingDetalle.Item(i)("Linea")
                    Else
                        Linea = -1
                    End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("Descripcion_Producto")) Then
                        Descripcion = Me.BindingDetalle.Item(i)("Descripcion_Producto")
                    End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("Precio")) Then
                        Precio = Me.BindingDetalle.Item(i)("Precio")
                    End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("PesoKg")) Then
                        PesoKg = Me.BindingDetalle.Item(i)("PesoKg")
                    End If

                    If Not IsDBNull(Me.BindingDetalle.Item(i)("PesoNetoKg")) Then
                        PesoNetoKg = Me.BindingDetalle.Item(i)("PesoNetoKg")
                    End If



                    Calidad = Me.CboCategoria.Text
                    Estado = Me.CboEstado.Text

                    If Linea <> -1 Then
                        GrabaDetalleRecepcion(Me.TxtNumeroEnsamble.Text, CodigoProducto, Cantidad, Linea, Descripcion, Calidad, Estado, Precio, PesoKg, Me.CboTipoRecepcion.Text, Tara1, PesoNetoKg, QQ, Me.CboTipoCalidad.Text)
                    End If

                    i = i + 1
                Loop

                GrabaDetalleRecibo(IdRecibo, CantSacos, Me.TxtHumedad.Text, Tara, Me.TxtImperfecion.Text, IdRecibo, 1, IdEstadoFisico, PesoBruto)

            End If



            If IdTipoCompra = 108 Then
                If IdEstadoDocumento = "294" Then
                    Quien = "Recibo"
                    '////////////////////////////////////////////////////////////////////////////////////////////
                    '////////////////////////////VERIFICO PRECIO ////////////////////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////

                    FrmLiquidacion.NumeroRecibo = Me.TxtNumeroRecibo.Text
                    If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
                        Fecha = Format(DateFecha, "yyyy-MM-dd") & " " & Me.LblHora.Text
                    Else
                        Fecha = Format(Me.DtpFechaManual.Value, "yyyy-MM-dd") & " " & Format(Me.DtpHoraManual.Value, "hh:mm:ss tt")
                    End If

                    If CalculaPrecioBruto(Fecha, IdLugarAcopio, IdRangoImperfeccion, IdDaño, 609, IdEstadoFisico) <= 0 Then
                        MsgBox("No Existen Precios para la Liquidacion¡¡¡", MsgBoxStyle.Critical, "Sistema Bascula")
                        Exit Sub
                    End If

                    SqlString = "SELECT  IdTipoCambio, FechaTipoCambio, TipoCambio, Simbolo FROM TipoCambio WHERE  (FechaTipoCambio = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102))"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "TasaCambio")
                    If DataSet.Tables("TasaCambio").Rows.Count = 0 Then
                        MsgBox("No Existen Tasas de Cambio para la liquidacion¡¡¡", MsgBoxStyle.Critical, "Sistema Bascula")
                        Me.Button7.Enabled = True
                        Exit Sub
                    End If

                    If Me.TxtProveedor.Text = "00001" Then
                        EsProductorManual = True
                        Cedula = Me.TxtNumeroCedula.Text
                    Else
                        EsProductorManual = False
                    End If

                    '------------------------ACTUALIZO LOS ID DE LA LIQUIDACION -----------------------------------------
                    FrmLiquidacion.IdLocalidadLiqui = IdLugarAcopio
                    FrmLiquidacion.IdTipoIngreso = IdTipoIngreso
                    FrmLiquidacion.IdTipoCompra = IdTipoCompra
                    FrmLiquidacion.IdCalidad = Me.IdCalidad
                    FrmLiquidacion.IdEdoFisico = IdEstadoFisico
                    FrmLiquidacion.IdDano = IdDaño
                    FrmLiquidacion.IdCategoria = Me.IdRangoImperfeccion
                    FrmLiquidacion.Cedula = Me.Cedula
                    FrmLiquidacion.EsProductorManual = Me.EsProductorManual

                    FechaRecibo = Fecha
                    FrmLiquidacion.DTPFecha.Value = Fecha
                    FrmLiquidacion.DTPFecha.Enabled = False
                    FrmLiquidacion.LocalidadCbo = Me.CboLiquidarLocalidad.Text
                    FrmLiquidacion.CboLocalidadLiq.Enabled = False
                    FrmLiquidacion.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text
                    FrmLiquidacion.CboCodigoProveedor.Enabled = False
                    FrmLiquidacion.codigoProveedor = Me.CboCodigoProveedor.Text
                    FrmLiquidacion.txtnombre.Text = Me.txtnombre.Text
                    FrmLiquidacion.TipoIngresoCbo = Me.CboTipoIngresoBascula.Text
                    FrmLiquidacion.CboTipIngreso.Enabled = False
                    FrmLiquidacion.CboTipoCompra.Text = Me.CboTipoCompra.Text
                    FrmLiquidacion.TipoCompraCbo = Me.CboTipoCompra.Text
                    FrmLiquidacion.CboTipoCompra.Enabled = False
                    FrmLiquidacion.CboCalidad.Text = Me.CboTipoCalidad.Text
                    FrmLiquidacion.CboCalidad.Enabled = False
                    FrmLiquidacion.CboTipDano.Text = Me.CboDaño.Text
                    FrmLiquidacion.CboTipDano.Enabled = False
                    FrmLiquidacion.CboEdofisico.Text = Me.CboEstado.Text
                    FrmLiquidacion.CboEdofisico.Enabled = False
                    FrmLiquidacion.CboImperfeccion.Text = Me.CboCategoria.Text
                    FrmLiquidacion.CboImperfeccion.Enabled = False
                    FrmLiquidacion.Button10.Enabled = False
                    FrmLiquidacion.txtnombre.Enabled = False
                    FrmLiquidacion.TxtCedula.Enabled = False
                    FrmLiquidacion.CboMunicipio.Enabled = False
                    FrmLiquidacion.CboMoneda.Enabled = True
                    FrmLiquidacion.CboMonedas.Enabled = True
                    FrmLiquidacion.TabControl1.Enabled = True
                    FrmLiquidacion.Button8.Enabled = False
                    FrmLiquidacion.Button14.Enabled = False
                    FrmLiquidacion.Button2.Enabled = False
                    FrmLiquidacion.TxtTasaCambio.Enabled = False
                    FrmLiquidacion.Button3.Enabled = False
                    FrmLiquidacion.Button9.Enabled = False
                    FrmLiquidacion.Button6.Enabled = False
                    FrmLiquidacion.TxtIdLocalidad.Text = Me.TxtIdLocalidad.Text
                    FrmLiquidacion.NumeroRecibo = Me.TxtNumeroRecibo.Text
                    FrmLiquidacion.TxtSerie.Text = Me.TxtSerie.Text
                    FrmLiquidacion.TDGridDetalleRecibos.Enabled = False



                    TipoIngreso = Me.CboTipoIngresoBascula.Text
                    Pignorado = Me.CboPignorado.Text
                    Localidad = Me.CboLocalidad.Text
                    LocalidadLiquidar = Me.CboLiquidarLocalidad.Text
                    TipoCompra = Me.CboTipoCompra.Text
                    TipoCalidad = Me.CboTipoCalidad.Text
                    Categoria = Me.CboCategoria.Text
                    Estado = Me.CboEstado.Text
                    Daño = Me.CboDaño.Text
                    Humedad = Me.TxtHumedad.Text
                    Imperfeccion = Me.TxtImperfecion.Text
                    TipoCafe = Me.CboTipoCafe.Text





                    SqlString = "SELECT  ReciboCafePergamino.*  FROM ReciboCafePergamino WHERE  (ReciboCafePergamino.IdReciboPergamino = " & IdRecibo & ") AND (IdCosecha = " & IdCosecha & ") "
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                        '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                        MiConexion.Open()
                        StrSqlUpdate = "UPDATE [ReciboCafePergamino] SET [Seleccion] = 'True'  WHERE (ReciboCafePergamino.IdReciboPergamino = " & IdRecibo & ") AND (IdCosecha = " & IdCosecha & ") "
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                    End If
                    'FrmLiquidacion.Button10_Click(sender, e)
                    FrmLiquidacion.ShowDialog()
                    SalirLiquidacion(True)

                    'FrmLiquidacion.Button10_Click(sender, e)
                    'FrmLiquidacion.TDGridDetalleRecibos_BeforeColUpdate(Nothing, Nothing)
                    'FrmLiquidacion.TDGridDetalleRecibos_AfterColUpdate(Nothing, Nothing)




                End If

            End If



            Me.Button7.Enabled = True

            If LimpiarRecibo = True Then
                LimpiaRecepcion()
            End If
        Else
            MsgBox("Seleccione Productos para poder Grabar", MsgBoxStyle.Critical, "Recibo")
        End If

        If Me.CboTipoRecepcion.Text = "RePesaje" Then
            Me.Close()
        End If


    End Sub
    Public Sub SalirLiquidacion(ByVal Salir As Boolean)
        If Salir = True Then
            My.Forms.FrmLiquidacion.Close()
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim ArepRecepcion As New ArepRecepcion, CodigoProducto As String, Sqldatos As String, RutaLogo As String
        Dim oDataRow As DataRow, Fecha As String, Registros As Double, i As Double, Buscar_Fila() As DataRow, Criterios As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Posicion As Double = 0, DescripcionAnterior As String = ""


        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")


        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '-100000') AND (Fecha = CONVERT(DATETIME, '2013-10-12 00:00:00', 102)) AND (TipoRecepcion = N'Recepcion') ORDER BY Cantidad"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Reporte")

        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') ORDER BY Cod_Productos DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")
        Registros = DataSet.Tables("Recepcion").Rows.Count
        i = 0

        Do While Registros > i

            CodigoProducto = DataSet.Tables("Recepcion").Rows(i)("Cod_Productos")

            '//////////////////////////////////////////BUSCO SI NO EXISTE PARA AGREGAR UNO NUEVO ///////////////////////////
            Criterios = "Cod_Productos= '" & CodigoProducto & "'"
            Buscar_Fila = DataSet.Tables("Reporte").Select(Criterios)
            If Buscar_Fila.Length = 0 Then
                oDataRow = DataSet.Tables("Reporte").NewRow
                oDataRow("id_Eventos") = DataSet.Tables("Recepcion").Rows(i)("id_Eventos")
                oDataRow("NumeroRecepcion") = DataSet.Tables("Recepcion").Rows(i)("NumeroRecepcion")
                oDataRow("Fecha") = DataSet.Tables("Recepcion").Rows(i)("Fecha")
                oDataRow("TipoRecepcion") = DataSet.Tables("Recepcion").Rows(i)("TipoRecepcion")
                oDataRow("Cod_Productos") = DataSet.Tables("Recepcion").Rows(i)("Cod_Productos")
                oDataRow("Descripcion_Producto") = DataSet.Tables("Recepcion").Rows(i)("Descripcion_Producto")
                oDataRow("Codigo_Beams") = DataSet.Tables("Recepcion").Rows(i)("Codigo_Beams")
                oDataRow("Cantidad") = DataSet.Tables("Recepcion").Rows(i)("Cantidad")
                oDataRow("Unidad_Medida") = DataSet.Tables("Recepcion").Rows(i)("id_Eventos") & "-" & DataSet.Tables("Recepcion").Rows(i)("Cantidad") & "Lb"
                DataSet.Tables("Reporte").Rows.Add(oDataRow)
            Else
                Posicion = DataSet.Tables("Reporte").Rows.IndexOf(Buscar_Fila(0))
                DescripcionAnterior = DataSet.Tables("Reporte").Rows(Posicion)("Unidad_Medida")
                DataSet.Tables("Reporte").Rows(Posicion)("Unidad_Medida") = DescripcionAnterior & " , " & DataSet.Tables("Recepcion").Rows(i)("id_Eventos") & "-" & DataSet.Tables("Recepcion").Rows(i)("Cantidad") & "Lb"
                DataSet.Tables("Reporte").Rows(Posicion)("Cantidad") = DataSet.Tables("Reporte").Rows(Posicion)("Cantidad") + DataSet.Tables("Recepcion").Rows(i)("Cantidad")
            End If

            i = i + 1
        Loop


        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepRecepcion.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepRecepcion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepRecepcion.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepRecepcion.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        ArepRecepcion.LblLote.Text = Me.TxtAno.Text & "-" & Me.TxtMes.Text & "-" & Me.TxtDia.Text & "-" & Me.TxtProveedor.Text & "-" & Me.TxtOrigen.Text & "-" & Me.TxtPila.Text
        ArepRecepcion.LblNotas.Text = Me.txtobservaciones.Text
        ArepRecepcion.LblOrden.Text = Me.TxtNumeroEnsamble.Text
        ArepRecepcion.LblFechaOrden.Text = Format(CDate(Me.DTPFecha.Text), "dd/MM/yyyy")
        ArepRecepcion.LblTipoCompra.Text = Me.CboTipoRecepcion.Text
        'ArepRecepcion.LblCodProveedor.Text = Me.CboCodigoProveedor.Text
        ArepRecepcion.LblNombres.Text = Me.txtnombre.Text
        ArepRecepcion.LblApellidos.Text = Me.txtapellido.Text
        'ArepRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepRecepcion.LblNombres.Text = Me.txtnombre.Text
        'ArepRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepRecepcion.LblPila.Text = Me.txtapellido.Text
        'ArepRecepcion.LblConductor.Text = Me.CboConductor.Text
        'ArepRecepcion.LblCedula.Text = Me.txtid.Text
        'ArepRecepcion.LblPlaca.Text = Me.txtplaca.Text

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepRecepcion.Document
        My.Application.DoEvents()

        ArepRecepcion.DataSource = DataSet.Tables("Reporte")
        ArepRecepcion.Run(False)
        ViewerForm.Show()

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim ArepBitacoraRecepcion As New ArepBitacoraRecepcion, Sqldatos As String, RutaLogo As String
        Dim Fecha As String, Criterios As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Posicion As Double = 0, DescripcionAnterior As String = ""
        Dim DateFecha As DateTime = Me.DTPFecha.Text


        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO ENCABEZADO DE RECEPCION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Me.TxtProveedor.Text = "00001" Then
            If Len(Trim(Me.TxtNumeroCedula.Text)) <> 14 Then
                MsgBox("Se necesitan 14 digitos para la cedula", MsgBoxStyle.Critical, "Bascula")
                Exit Sub
            End If
        End If

        If Me.txtnombre.Text = "" Then
            MsgBox("Se Necesita Nombre Productor", MsgBoxStyle.Critical, "Bascula")
            Exit Sub
        End If



        Me.Button12.Enabled = False

        'CalcularEquivalente()



        If Me.Button7.Enabled = True Then
            LimpiarRecibo = False
            Button7_Click(sender, e)
            LimpiarRecibo = True
        Else
            'LimpiaRecepcion()
        End If

        EqOreado = Me.TxtEqOreado.Text
        EqReal = Me.TxtOreadoReal.Text
        QQOreado = EqOreado / 46



        If IdTipoCompra = 108 Then
            If IdEstadoDocumento = "294" Then
                Quien = "Recibo"
                '////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////VERIFICO PRECIO ////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////

                If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
                    Fecha = Format(DateFecha, "yyyy-MM-dd") & " " & Me.LblHora.Text
                Else
                    Fecha = Format(Me.DtpFechaManual.Value, "yyyy-MM-dd") & " " & Format(Me.DtpHoraManual.Value, "hh:mm:ss tt")
                End If

                If CalculaPrecioBruto(Fecha, IdLugarAcopio, IdRangoImperfeccion, IdDaño, 609, IdEstadoFisico) = 0 Then
                    MsgBox("No Existen Precios para la Liquidacion¡¡¡", MsgBoxStyle.Critical, "Sistema Bascula")
                    Exit Sub
                End If


            End If

        End If






        Finca = ""
        If Me.CboCodigoProveedor.Text = "00001" Then
            If Me.TxtFinca.Text <> "" Then
                Finca = Me.TxtFinca.Text
            End If
        Else
            If Me.CboFinca.Text <> "" Then
                Finca = Me.CboFinca.Text
            End If
        End If

        Cedula = ""
        If Me.TxtNumeroCedula.Text <> "" Then
            Cedula = Me.TxtNumeroCedula.Text
        End If

        If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
            NRecibo = Me.TxtIdLocalidad.Text & "-" & Me.TxtNumeroRecibo.Text
            FechaRecibo = Me.DTPFecha.Text
        Else
            NRecibo = Me.TxtNumeroRecibo.Text
            FechaRecibo = Format(Me.DtpFechaManual.Value, "dd/MM/yyyy")
        End If


        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")


        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, Calidad, Estado, Precio, PesoKg, PesoNetoKg,Calidad_Cafe, Tara, QQ  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"

        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            ArepBitacoraRecepcion.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepBitacoraRecepcion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepBitacoraRecepcion.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepBitacoraRecepcion.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If
        End If


        ArepBitacoraRecepcion.LblLote.Text = Me.TxtAno.Text & "-" & Me.TxtMes.Text & "-" & Me.TxtDia.Text & "-" & Me.TxtProveedor.Text & "-" & Me.TxtOrigen.Text & "-" & Me.TxtPila.Text
        ArepBitacoraRecepcion.TxtObservaciones.Text = Me.Observaciones

        ArepBitacoraRecepcion.LblFechaOrden.Text = Format(CDate(Me.DTPFecha.Text), "dd/MM/yyyy")

        'ArepBitacoraRecepcion.LblCodProveedor.Text = Me.CboCodigoProveedor.Text
        ArepBitacoraRecepcion.LblNombres.Text = Me.txtnombre.Text
        'ArepBitacoraRecepcion.LblApellidos.Text = Me.txtapellido.Text
        'ArepBitacoraRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepBitacoraRecepcion.LblPila.Text = Me.txtapellido.Text
        'ArepBitacoraRecepcion.LblConductor.Text = Me.CboConductor.Text
        'ArepBitacoraRecepcion.LblCedula.Text = Me.txtid.Text
        'ArepBitacoraRecepcion.LblPlaca.Text = Me.txtplaca.Text


        '////////////////////////////CONSULTO EL AÑO DE LA COSECHA ////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  Cosecha.* FROM Cosecha WHERE(activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("Cosecha").Rows(0)("FechaFinal")) Then
                AñoCosecha = Year(CDate(DataSet.Tables("Cosecha").Rows(0)("FechaFinal")))
            End If
        End If


        SqlString = "SELECT ParametroGeneral.*  FROM ParametroGeneral WHERE (Codigo = '01')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Parametro")
        If DataSet.Tables("Parametro").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("Parametro").Rows(0)("Valor")) Then
                AñoCosecha = AñoCosecha & "-" & DataSet.Tables("Parametro").Rows(0)("Valor")
            End If
        End If

        AñoCosecha = Format(CDate(AñoCosecha), "dd 'de' MMMM 'de' yyyy")


        Hora = Me.LblHora.Text
        TipoIngreso = Me.CboTipoIngresoBascula.Text
        Pignorado = Me.CboPignorado.Text
        Localidad = Me.CboLocalidad.Text
        LocalidadLiquidar = Me.CboLiquidarLocalidad.Text
        TipoCompra = Me.CboTipoCompra.Text
        TipoCalidad = Me.CboTipoCalidad.Text
        Categoria = Me.CboCategoria.Text
        Estado = Me.CboEstado.Text
        Daño = Me.CboDaño.Text
        Humedad = Me.TxtHumedad.Text
        Imperfeccion = Me.TxtImperfecion.Text
        TipoCafe = Me.CboTipoCafe.Text
        Cosecha = Me.LblCosecha.Text



        ArepBitacoraRecepcion.IdCosecha = IdCosecha
        ArepBitacoraRecepcion.IdFinca = IdFinca
        ArepBitacoraRecepcion.IdProductor = IdProductor


        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, Calidad, Estado, Precio, PesoKg, PesoNetoKg,Calidad_Cafe, Tara, QQ  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "')"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlString

        Dim ViewerForm As New FrmViewer(), i As Integer
        ViewerForm.arvMain.Document = ArepBitacoraRecepcion.Document
        My.Application.DoEvents()
        ArepBitacoraRecepcion.DataSource = SQL
        'ArepBitacoraRecepcion.Run(False)

        For i = 1 To 3
            If i = 1 Then
                ArepBitacoraRecepcion.LblOriginal.Visible = True
                ArepBitacoraRecepcion.LblOriginal.Text = "O R I G I N A L"
                ArepBitacoraRecepcion.Run(False)
                ViewerForm.arvMain.Document.Print(False, False, False)
                'ViewerForm.Show()
                My.Application.DoEvents()
            Else
                ArepBitacoraRecepcion.LblOriginal.Visible = True
                ArepBitacoraRecepcion.LblOriginal.Text = "C O P I A"
                ArepBitacoraRecepcion.Run(False)
                ViewerForm.arvMain.Document.Print(False, False, False)
                'ViewerForm.Show()
                My.Application.DoEvents()

            End If

            'ViewerForm.Show()

            'ViewerForm.arvMain.Document.Print(False, False, False)

            ' SI ESTA HABILITADO PARA GRABAR LO PERMITO GRABAR
        Next


        LimpiaRecepcion()
        Me.Button12.Enabled = True

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Resultado As Double
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO ENCABEZADO DE RECEPCION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        Resultado = MsgBox("¿Esta Seguro de Cancelar la Recepcion?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If


        If Me.BindingDetalle.Count <> 0 Then
            AnulaRecepcion(Me.TxtNumeroEnsamble.Text)
            LimpiaRecepcion()
        Else
            MsgBox("Seleccione Productos para poder Grabar", MsgBoxStyle.Critical, "Zeus Inventario")
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        My.Forms.FrmPuertos.Pregunta = "Recepcion"
        My.Forms.FrmPuertos.ShowDialog()
    End Sub

    Private Sub sp_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sp.DataReceived
        Dim s As String '= sp.ReadExisting, Pesada As Double

        Dim escribeport3 As New delegado(AddressOf Me.mostar)



        s = sp.ReadLine

        Select Case Mid(s, 1, 4)
            Case "TARA" : Exit Sub
            Case "NETO" : Exit Sub
            Case "" : Exit Sub
        End Select

        If Len(s) > 5 Then
            s = SoloNumeros(s)
            Me.Invoke(escribeport3, s)

        End If




    End Sub

    Sub mostar(ByVal d As String)
        Dim Posicion As Double
        Dim Cadena As String, Pesada As Double, PesoEntero As Double, PesoDecimal As Double

        'Cadena = Mid(d, 7, Len(d))
        'Pesada = CDbl(Cadena)
        Cadena = d
        Pesada = SoloNumeros(Cadena)
        '-------------------------------SI SE ACTIVA EL REDONDEO CAMBIO LA PESADA
        If Me.ChkRedondeo.Checked = True Then
            PesoEntero = Int(Pesada)
            PesoDecimal = Format(Pesada - PesoEntero, "##0.00")
            'If PesoDecimal >= 0.01 And PesoDecimal <= 0.4 Then
            '    PesoDecimal = 0
            'ElseIf PesoDecimal >= 0.41 And PesoDecimal <= 0.5 Then
            '    'PesoDecimal = 0.5
            'ElseIf PesoDecimal >= 0.51 And PesoDecimal <= 0.9 Then
            '    PesoDecimal = 0.5
            'ElseIf PesoDecimal >= 0.91 And PesoDecimal <= 0.99 Then
            '    'PesoDecimal = 1
            'End If

            Pesada = PesoEntero + PesoDecimal
        End If

        'Posicion = Me.BindingDetalle.Position
        Posicion = Me.TrueDBGridComponentes.Row
        Me.TrueDBGridComponentes.Columns(5).Text = Pesada
        'Me.LblPeso.Text = Pesada & " Kg"
        My.Application.DoEvents()
        GrabaLecturaPeso(Pesada)
        'Me.BindingDetalle.Position = Posicion + 1
        Me.TrueDBGridComponentes.Row = Posicion + 1
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.sp.Close()
        Me.LblEstado.Text = "DESCONECT"
        Me.LblEstado.ForeColor = Color.Black
    End Sub

    Private Sub TxtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TrueDBGridComponentes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TrueDBGridComponentes.KeyDown


        'If e.KeyCode = 13 Then
        '    Dim Posicion As Double
        '    Dim Pesada As Double
        '    Posicion = Me.BindingDetalle.Position
        '    If Me.TrueDBGridComponentes.Columns(5).Text <> "" Then
        '        If IsNumeric(Me.TrueDBGridComponentes.Columns(5).Text) Then
        '            Pesada = Me.TrueDBGridComponentes.Columns(5).Text

        '        Else
        '            Me.TrueDBGridComponentes.Columns(5).Text = 0
        '            Pesada = 0
        '        End If
        '    Else
        '        Pesada = 0
        '    End If
        '    Me.LblPeso.Text = Pesada & " Kg"
        '    My.Application.DoEvents()
        '    GrabaLecturaPeso(Pesada)
        '    Me.BindingDetalle.Position = Posicion + 1

        '    Pesada = 0
        '    Me.TrueDBGridComponentes.Columns(5).Text = Pesada

        'End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.Text = "Consulta Proveedor"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA PROVEEDOR"
        My.Forms.FrmConsultas.ShowDialog()
        If FrmConsultas.Codigo <> "" Then
            Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Quien = "CodigoBeamsRecepcion"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            Me.TxtCodigo.Text = My.Forms.FrmConsultas.Codigo
            Me.TxtNumeroRecepcion.Text = My.Forms.FrmConsultas.NumeroRecepcion
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim ArepRecepcion As New ArepRecepcionTalla, CodigoProducto As String, Sqldatos As String, RutaLogo As String
        Dim oDataRow As DataRow, Fecha As String, Registros As Double, i As Double, Buscar_Fila() As DataRow, Criterios As String = ""
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Posicion As Double = 0, DescripcionAnterior As String = ""


        Fecha = Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd")


        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '-100000') AND (Fecha = CONVERT(DATETIME, '2013-10-12 00:00:00', 102)) AND (TipoRecepcion = N'Recepcion') ORDER BY Cantidad"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Reporte")

        'SqlString = "SELECT  id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') ORDER BY Cod_Productos DESC"
        SqlString = "SELECT MAX(id_Eventos) AS id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, MAX(Codigo_Beams) AS Codigo_Beams, SUM(Cantidad) AS Cantidad, MAX(Unidad_Medida) AS Unidad_Medida FROM Detalle_Recepcion GROUP BY Cod_Productos, Descripcion_Producto, NumeroRecepcion, Fecha, TipoRecepcion HAVING (NumeroRecepcion = '" & Me.TxtNumeroEnsamble.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & Me.CboTipoRecepcion.Text & "') ORDER BY id_Eventos"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")
        Registros = DataSet.Tables("Recepcion").Rows.Count
        i = 0

        Do While Registros > i

            CodigoProducto = DataSet.Tables("Recepcion").Rows(i)("Cod_Productos")

            '//////////////////////////////////////////BUSCO SI NO EXISTE PARA AGREGAR UNO NUEVO ///////////////////////////
            Criterios = "Cod_Productos= '" & CodigoProducto & "'"
            Buscar_Fila = DataSet.Tables("Reporte").Select(Criterios)
            If Buscar_Fila.Length = 0 Then
                oDataRow = DataSet.Tables("Reporte").NewRow
                oDataRow("id_Eventos") = DataSet.Tables("Recepcion").Rows(i)("id_Eventos")
                oDataRow("NumeroRecepcion") = DataSet.Tables("Recepcion").Rows(i)("NumeroRecepcion")
                oDataRow("Fecha") = DataSet.Tables("Recepcion").Rows(i)("Fecha")
                oDataRow("TipoRecepcion") = DataSet.Tables("Recepcion").Rows(i)("TipoRecepcion")
                oDataRow("Cod_Productos") = DataSet.Tables("Recepcion").Rows(i)("Cod_Productos")
                oDataRow("Descripcion_Producto") = DataSet.Tables("Recepcion").Rows(i)("Descripcion_Producto")
                oDataRow("Codigo_Beams") = DataSet.Tables("Recepcion").Rows(i)("Codigo_Beams")
                oDataRow("Cantidad") = DataSet.Tables("Recepcion").Rows(i)("Cantidad")
                oDataRow("Unidad_Medida") = DataSet.Tables("Recepcion").Rows(i)("id_Eventos") & "-" & DataSet.Tables("Recepcion").Rows(i)("Cantidad") & "Lb"
                DataSet.Tables("Reporte").Rows.Add(oDataRow)
            Else
                Posicion = DataSet.Tables("Reporte").Rows.IndexOf(Buscar_Fila(0))
                DescripcionAnterior = DataSet.Tables("Reporte").Rows(Posicion)("Unidad_Medida")
                DataSet.Tables("Reporte").Rows(Posicion)("Unidad_Medida") = DescripcionAnterior & " , " & DataSet.Tables("Recepcion").Rows(i)("id_Eventos") & "-" & DataSet.Tables("Recepcion").Rows(i)("Cantidad") & "Lb"
                DataSet.Tables("Reporte").Rows(Posicion)("Cantidad") = DataSet.Tables("Reporte").Rows(Posicion)("Cantidad") + DataSet.Tables("Recepcion").Rows(i)("Cantidad")
            End If

            i = i + 1
        Loop


        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then


            ArepRecepcion.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepRecepcion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                ArepRecepcion.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepRecepcion.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        ArepRecepcion.LblLote.Text = Me.TxtAno.Text & "-" & Me.TxtMes.Text & "-" & Me.TxtDia.Text & "-" & Me.TxtProveedor.Text & "-" & Me.TxtOrigen.Text & "-" & Me.TxtPila.Text
        ArepRecepcion.LblNotas.Text = Me.txtobservaciones.Text
        ArepRecepcion.LblOrden.Text = Me.TxtNumeroEnsamble.Text
        ArepRecepcion.LblFechaOrden.Text = Format(CDate(Me.DTPFecha.Text), "dd/MM/yyyy")
        ArepRecepcion.LblTipoCompra.Text = Me.CboTipoRecepcion.Text
        'ArepRecepcion.LblCodProveedor.Text = Me.CboCodigoProveedor.Text
        ArepRecepcion.LblNombres.Text = Me.txtnombre.Text
        ArepRecepcion.LblApellidos.Text = Me.txtapellido.Text
        'ArepRecepcion.LblBodegas.Text = Me.CboCodigoBodega.Columns(0).Text + " " + Me.CboCodigoBodega.Columns(1).Text
        'ArepRecepcion.LblPila.Text = Me.txtapellido.Text
        'ArepRecepcion.LblConductor.Text = Me.CboConductor.Text
        'ArepRecepcion.LblCedula.Text = Me.txtid.Text
        'ArepRecepcion.LblPlaca.Text = Me.txtplaca.Text

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepRecepcion.Document
        My.Application.DoEvents()

        ArepRecepcion.DataSource = DataSet.Tables("Reporte")
        ArepRecepcion.Run(False)
        ViewerForm.Show()
    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged

    End Sub

    Private Sub txtapellido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtapellido.TextChanged
        Me.TxtPila.Text = Mid(Me.txtapellido.Text, 1, 3)
    End Sub

    Private Sub TrueDBGridComponentes_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Move

    End Sub

    Private Sub TxtNumeroRecepcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroRecepcion.TextChanged

    End Sub

    Private Sub cbosubpro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbosubpro_ItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboCodigoProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.Click

    End Sub

    Private Sub CboCodigoProveedor_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.ClientSizeChanged

    End Sub

    Private Sub CboCodigoProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.DoubleClick
        FrmTeclado.ShowDialog()
        Me.CboCodigoProveedor.Text = FrmTeclado.Numero
    End Sub

    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = "", SqlString As String, Registros As Double, i As Double, Pignorado As Boolean

        Me.TxtProveedor.Text = Me.CboCodigoProveedor.Text
        IdFinca = 0

        Me.ListBoxCertificados.Items.Clear()

        If Me.TxtProveedor.Text = "00001" Then
            Me.TxtFinca.Visible = True
            Me.TxtNumeroCedula.Visible = True
        Else
            Me.TxtFinca.Visible = False
            Me.TxtNumeroCedula.Visible = False
        End If


        SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")

            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Cedula")) Then
                Me.TxtNumeroCedula.Text = DataSet.Tables("Proveedor").Rows(0)("Cedula")
            End If

            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                Me.txtapellido.Text = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor") & " " & DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
            End If



            '////////////////////////////////////////////////BUSCO DATOS DEL CONDUCTOR ///////////////////////////////////
            SqlProveedor = "SELECT DISTINCT Conductor, Id_identificacion, Id_Placa, Cod_Bodega, SubTotal, Telefono,Cod_SubProveedor  FROM Recepcion WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') ORDER BY Conductor"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Datos")
            If Not DataSet.Tables("Datos").Rows.Count = 0 Then
                If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Conductor")) Then
                    Me.CboConductor.Text = DataSet.Tables("Datos").Rows(0)("Conductor")
                End If
                If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Id_identificacion")) Then
                    Me.txtid.Text = DataSet.Tables("Datos").Rows(0)("Id_identificacion")
                End If

                If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Id_Placa")) Then
                    Me.txtplaca.Text = DataSet.Tables("Datos").Rows(0)("Id_Placa")
                End If
                If Not IsDBNull(DataSet.Tables("Datos").Rows(0)("Cod_SubProveedor")) Then
                    CodigoSubProveedor = DataSet.Tables("Datos").Rows(0)("Cod_SubProveedor")
                End If


            End If

            'SqlString = "SELECT IdProductor, Cedula, Apellido1, Apellido2, Nombre, CodProductor, FechaMovimiento FROM Productor WHERE (CodProductor = '" & Me.CboCodigoProveedor.Text & "')"
            'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'DataAdapter.Fill(DataSet, "ConsultaIdProductor")
            'If DataSet.Tables("ConsultaIdProductor").Rows.Count <> 0 Then
            '    IdProductor = DataSet.Tables("ConsultaIdProductor").Rows(0)("IdProductor")
            'End If


            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("IdProductor")) Then
                IdProductor = DataSet.Tables("Proveedor").Rows(0)("IdProductor")
                IdPignorado = 0

                If Me.CboCodigoProveedor.Text = "00001" Then
                    IdProductor = Nothing
                End If

                SqlProveedor = "SELECT  IdProductorPignorado, IdCosecha, IdPignorado, IdProductor, Activo  FROM ProductorPignorado WHERE(IdProductor = " & IdProductor & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "Pignorado")


                If Not DataSet.Tables("Pignorado").Rows.Count = 0 Then
                    IdPignorado = DataSet.Tables("Pignorado").Rows(0)("IdPignorado")
                End If

                SqlProveedor = "SELECT IdPignorado, codigo, Descripccion, Activo FROM Pignorado WHERE  (IdPignorado = " & IdPignorado & ") AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
                DataAdapter.Fill(DataSet, "ConsultaP")
                Registros = DataSet.Tables("ConsultaP").Rows.Count
                i = 0
                Pignorado = False
                Me.CboPignorado.Items.Clear()
                Me.CboPignorado.Items.Add("NO PIGNORADO")


                Do While Registros > i
                    If DataSet.Tables("ConsultaP").Rows(0)("codigo") <> "00" Then
                        Pignorado = True
                        Me.LblPignorado.Text = "PIGNORADO: " & DataSet.Tables("ConsultaP").Rows(0)("Descripccion")
                        Me.CboPignorado.Items.Add(DataSet.Tables("ConsultaP").Rows(i)("Descripccion"))
                        Me.CboPignorado.Text = DataSet.Tables("ConsultaP").Rows(i)("Descripccion")
                    End If
                    i = i + 1
                Loop



                If Quien <> "Pegar" Then
                    If Pignorado = True Then
                        MsgBox("Productor Pignorado!!!", MsgBoxStyle.Exclamation, "Recepcion")
                        Me.CboPignorado.Text = "NO PIGNORADO"
                        IdPignorado = 0
                    End If
                End If




            End If

            '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
            SqlString = "SELECT  IdFinca, CodFinca, IdProductor, NomFinca, UbicaFinca, FechaMovimiento FROM Finca  WHERE (IdProductor = '" & IdProductor & "' )"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            Me.CboFinca.DataSource = DataSet.Tables("Consulta")
            Me.CboFinca.DisplayMember = "NomFinca"


            'Me.C1Combo1.Splits.Item(0).DisplayColumns(0).Visible = False
            'Me.C1Combo1.Splits.Item(0).DisplayColumns(1).Visible = False
            'Me.C1Combo1.Splits.Item(0).DisplayColumns(2).Visible = False
            'Me.C1Combo1.Splits.Item(0).DisplayColumns(4).Visible = False
            'Me.C1Combo1.Splits.Item(0).DisplayColumns(5).Visible = False


        End If
    End Sub


    Private Sub DTPFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TxtAno.Text = Microsoft.VisualBasic.DateAndTime.Year(CDate(Me.DTPFecha.Text))
        Me.TxtMes.Text = Microsoft.VisualBasic.DateAndTime.Month(CDate(Me.DTPFecha.Text))
        Me.TxtDia.Text = Microsoft.VisualBasic.DateAndTime.Day(CDate(Me.DTPFecha.Text))
    End Sub

    Private Sub lblnombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblnombre.Click

    End Sub

    Private Sub CboCodigoProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboIngresoBascula.KeyDown

    End Sub

    Private Sub CboCodigoProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboIngresoBascula.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, i = 0

        ''////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        'SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.CboIngresoBascula.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        '    IdTipoCafe = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
        'End If

    End Sub

    Private Sub CboTipoProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCategoria.SelectedIndexChanged
        'Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        'Dim SqlString As String, i = 0


        ''////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        'SqlString = "SELECT IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion FROM RangoImperfeccion WHERE  (Nombre = '" & Me.CboCategoria.Text & "') AND (IdCosecha = " & IdCosecha & ")"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        '    IdRangoImperfeccion = DataSet.Tables("Consulta").Rows(0)("IdRangoImperfeccion")
        'End If

        CalculaTaraRecepcion()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub lbldatosre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbldatosre.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
        My.Application.DoEvents()
    End Sub

    Private Sub OptExpasa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptExpasa.CheckedChanged

        If Me.OptExpasa.Checked = True Then

            Me.OptOreado.Visible = False
        Else
            Me.OptOreado.Visible = True
        End If
    End Sub

    Private Sub OptMaquila_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptMaquila.CheckedChanged
        If Me.OptMaquila.Checked = True Then

            Select Case Me.CboTipoCalidad.Text
                Case "AP1ra" : Me.OptOreado.Visible = True
                Case "MP1ra" : Me.OptOreado.Visible = True
                Case "AP2da" : Me.OptOreado.Visible = True
                Case Else : Me.OptOreado.Visible = False
            End Select
        Else
            Me.OptOreado.Visible = False
        End If
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        FrmTeclado.ShowDialog()
        If FrmTeclado.Numero <> 0 Then
            Me.CboCodigoProveedor.Text = FrmTeclado.Numero
        End If
    End Sub

    Private Sub CboTipoCalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoCalidad.SelectedIndexChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, i = 0


        '//////////////////////////////////////CONSULTO LA COSECHA ACTIVA //////////////////////////////////////////
        SqlString = "SELECT  IdCosecha, CodCosecha, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra, activo, periodo, Codigo  FROM Cosecha   WHERE(activo = 1) ORDER BY CodCosecha DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count Then
            IdCosecha = DataSet.Tables("Cosecha").Rows(0)("IdCosecha")
        End If

        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        'SqlString = "SELECT RelacionCalidadxCategoria.IdCalidad, RelacionCalidadxCategoria.IdCategoriaCAfe, Categoria.Categoria, Calidad.NomCalidad FROM RelacionCalidadxCategoria INNER JOIN  Categoria ON RelacionCalidadxCategoria.IdCategoriaCAfe = Categoria.IdCategoriaCAfe INNER JOIN Calidad ON RelacionCalidadxCategoria.IdCalidad = Calidad.IdCalidad  " & _
        '            "WHERE (Calidad.NomCalidad = '" & Me.CboTipoCalidad.Text & "')"
        SqlString = "SELECT  RelacionCalidadxCategoria.IdCalidad, RelacionCalidadxCategoria.IdCategoriaCAfe, Calidad.NomCalidad, RangoImperfeccion.Nombre FROM  RelacionCalidadxCategoria INNER JOIN Calidad ON RelacionCalidadxCategoria.IdCalidad = Calidad.IdCalidad INNER JOIN RangoImperfeccion ON RelacionCalidadxCategoria.IdCategoriaCAfe = RangoImperfeccion.IdRangoImperfeccion  " & _
                    "WHERE (Calidad.NomCalidad = '" & Me.CboTipoCalidad.Text & "') AND (RangoImperfeccion.IdCosecha = " & IdCosecha & ") ORDER BY Calidad.NomCalidad"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultaCalidad")
        Me.CboCategoria.DataSource = DataSet.Tables("ConsultaCalidad")


        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        SqlString = "SELECT  Calidad.NomCalidad, Dano.IdDano, Dano.Nombre FROM Calidad INNER JOIN RelacionCalidadxDaño ON Calidad.IdCalidad = RelacionCalidadxDaño.IdCalidad INNER JOIN Dano ON RelacionCalidadxDaño.IdDaño = Dano.IdDano WHERE  (Calidad.NomCalidad = '" & Me.CboTipoCalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Daño")
        Me.CboDaño.DataSource = DataSet.Tables("Daño")
        If DataSet.Tables("Daño").Rows.Count Then
            IdDaño = DataSet.Tables("Daño").Rows(0)("IdDano")
        End If


        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        'SqlString = "SELECT  Calidad.NomCalidad, EstadoFisico.Descripcion FROM  Calidad INNER JOIN  RelacionCalidadxEstadoFisico ON Calidad.IdCalidad = RelacionCalidadxEstadoFisico.IdCalidad INNER JOIN  EstadoFisico ON RelacionCalidadxEstadoFisico.EstadoFisico = EstadoFisico.IdEdoFisico WHERE  (Calidad.NomCalidad ='" & Me.CboTipoCalidad.Text & "')"
        SqlString = "SELECT DISTINCT Calidad.NomCalidad, EstadoFisico.Descripcion, EstadoFisico.EstadoFisico FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN  Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoFisico ON RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = EstadoFisico.EstadoFisico  " & _
                    "WHERE  (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdTipoCafe & ") AND (Calidad.NomCalidad = '" & Me.CboTipoCalidad.Text & "') ORDER BY EstadoFisico.EstadoFisico"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Fisico")
        Me.CboEstado.DataSource = DataSet.Tables("Fisico")


        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        SqlString = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion FROM Calidad  WHERE  (NomCalidad = '" & Me.CboTipoCalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("VDImperfeccion")) Then
                Me.TxtImperfecion.Text = Format(DataSet.Tables("Consulta").Rows(0)("VDImperfeccion"), "##,##0.00")
                TxtImperfecion_TextChanged(sender, e)
            End If
            Me.ToolTip.SetToolTip(Me.TxtImperfecion, "Imperfeccion Desde " & DataSet.Tables("Consulta").Rows(0)("MinImperfeccion") & " Hasta " & DataSet.Tables("Consulta").Rows(0)("MaxImperfeccion"))
            IdCalidad = DataSet.Tables("Consulta").Rows(0)("IdCalidad")
        End If

        CalculaTaraRecepcion()

        'Me.CboCategoria.Items.Clear()

        'Select Case Me.CboTipoCalidad.Text

        '    Case "AP1ra"
        '        Me.OptNinguno.Visible = False
        '        Me.OptHumedo.Checked = True
        '        Me.OptHumedo.Visible = True
        '        Me.OptMojado.Visible = True
        '        If Me.OptMaquila.Checked = True Then
        '            Me.OptOreado.Visible = True
        '        Else
        '            Me.OptOreado.Visible = False
        '        End If
        '        Me.OptMedioSeco.Visible = True
        '        Me.OptPreSeco.Visible = True

        '        Me.CboCategoria.Items.Add("A")
        '        Me.CboCategoria.Items.Add("B")
        '        Me.CboCategoria.Items.Add("C")

        '    Case "MP1ra"
        '        Me.OptNinguno.Visible = False
        '        Me.OptHumedo.Checked = True
        '        Me.OptHumedo.Visible = True
        '        Me.OptMojado.Visible = True
        '        If Me.OptMaquila.Checked = True Then
        '            Me.OptOreado.Visible = True
        '        Else
        '            Me.OptOreado.Visible = False
        '        End If
        '        Me.OptMedioSeco.Visible = True
        '        Me.OptPreSeco.Visible = True

        '        Me.CboCategoria.Items.Add("D")
        '    Case "AP2da"
        '        Me.OptNinguno.Visible = False
        '        Me.OptHumedo.Checked = True
        '        Me.OptHumedo.Visible = True
        '        Me.OptMojado.Visible = True
        '        If Me.OptMaquila.Checked = True Then
        '            Me.OptOreado.Visible = True
        '        Else
        '            Me.OptOreado.Visible = False
        '        End If
        '        Me.OptMedioSeco.Visible = True
        '        Me.OptPreSeco.Visible = True
        '        Me.CboCategoria.Items.Add("D")
        '    Case Else
        '        Me.OptNinguno.Checked = True
        '        Me.OptHumedo.Visible = False
        '        Me.OptMojado.Visible = False
        '        Me.OptOreado.Visible = False
        '        Me.OptMedioSeco.Visible = False
        '        Me.OptPreSeco.Visible = False
        '        Me.OptNinguno.Visible = True

        '        Me.CboCategoria.Items.Add("D")

        'End Select


    End Sub

    Private Sub lblbdega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblbdega.Click

    End Sub

    Private Sub lblrecepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        If Quien = "Load" Then
            Quien = "Consulta"
            Exit Sub
        ElseIf Quien = "Consulta" Then

            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            SqlString = "SELECT  * FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Localidad")
            If DataSet.Tables("Localidad").Rows.Count = 0 Then
                MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
                Exit Sub
            Else
                Quien = "Consulta"
                Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
                IdLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
                CodLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
                IdTipoLugarAcopio = DataSet.Tables("Localidad").Rows(0)("TipoLugarAcopio")
                Me.TxtIdLocalidad.Text = DataSet.Tables("Localidad").Rows(0)("CodLugarAcopio")
                Me.CboLocalidad.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")

            End If
        Else
            IdLugarAcopio = Me.CboLocalidad.Columns(0).Text

        End If






        SqlString = "SELECT  * FROM LugarAcopio WHERE (IdLugarAcopio = '" & IdLugarAcopio & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscoLocalidad")
        If DataSet.Tables("BuscoLocalidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Me.LblSucursal.Text = DataSet.Tables("BuscoLocalidad").Rows(0)("NomLugarAcopio")
            IdLugarAcopio = DataSet.Tables("BuscoLocalidad").Rows(0)("IdLugarAcopio")
            IdTipoLugarAcopio = DataSet.Tables("BuscoLocalidad").Rows(0)("TipoLugarAcopio")
        End If

        DataSet.Tables("BuscoLocalidad").Reset()


        '///////////////////////////////////SI ES CENTRO DE ACOPIO QUITO LA OPCION DE LIQUIDAR /////////////////////////
        'SqlString = "SELECT TipoLocalidad.Descripcion, LugarAcopio.NomLugarAcopio, LugarAcopio.IdLugarAcopio FROM  LugarAcopio INNER JOIN  TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad  " & _
        '            "WHERE  (TipoLocalidad.Descripcion LIKE '%Centro de Acopio%') AND (LugarAcopio.IdLugarAcopio = " & IdLugarAcopio & ")"
        SqlString = "SELECT  TipoLocalidad.Descripcion, LugarAcopio.NomLugarAcopio, LugarAcopio.IdLugarAcopio, TipoLocalidad.IdTipoLocalidad FROM LugarAcopio INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad  WHERE (TipoLocalidad.IdTipoLocalidad = 12) AND (LugarAcopio.IdLugarAcopio = " & IdLugarAcopio & ") "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscoLocalidad")
        If DataSet.Tables("BuscoLocalidad").Rows.Count <> 0 Then
            Me.CboLiquidarLocalidad.Text = Me.CboLocalidad.Text
            Me.CboLiquidarLocalidad.Enabled = False
            Me.LblLiquidar.Enabled = False
            Me.Button16.Enabled = False
        Else
            Me.CboLiquidarLocalidad.Enabled = True
            Me.LblLiquidar.Enabled = True
            Me.Button16.Enabled = True
        End If


    End Sub

    Private Sub OptOreado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptOreado.CheckedChanged

    End Sub

    Private Sub DateTimePicker1_CausesValidationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.CausesValidationChanged

    End Sub

    Private Sub DateTimePicker1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker1.Validating

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub CboTipoCompra_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles CboTipoCompra.ChangeUICues

    End Sub

    Private Sub CboTipoCompra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTipoCompra.Click
        TipoCompra = Me.CboTipoCompra.Text
    End Sub

    Private Sub CboTipoCompra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoCompra.SelectedIndexChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Numero As Double
        Dim SqlString As String, i = 0

        If Quien = "Retorno" Then
            Exit Sub
        End If

        ''////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        'SqlString = "SELECT TipoCompra.IdTipoCompra, TipoCompra.Codigo, TipoCompra.Nombre, Calidad.NomCalidad FROM  TipoCompra INNER JOIN  RelacionTipoCompraxCalidad ON TipoCompra.IdTipoCompra = RelacionTipoCompraxCalidad.IdTipoCompra INNER JOIN  Calidad ON RelacionTipoCompraxCalidad.IdCalidad = Calidad.IdCalidad " & _
        '            "WHERE (TipoCompra.Nombre = '" & Me.CboTipoCompra.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "ConsultaCalidad")
        'Me.CboTipoCalidad.DataSource = DataSet.Tables("ConsultaCalidad")

        SqlString = "SELECT  idTipoCompra, Codigo, Nombre, IdECS FROM TipoCompra WHERE  (Nombre = '" & Me.CboTipoCompra.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCompra")
        If DataSet.Tables("TipoCompra").Rows.Count <> 0 Then
            IdTipoCompra = DataSet.Tables("TipoCompra").Rows(0)("IdECS")
        End If

        If Me.CboTipoCompra.Text = "Compra Directa" Then
            '////////////////////SI ES COMPRA DIRECTA BLOQUEAMOS LA OPCION DE IMPRIMIR ///////////////////////
            Me.Button12.Enabled = False
        Else
            Me.Button12.Enabled = True
        End If


        If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
            If Quien <> "Load" Then
                'My.Forms.FrmLocalidad.IdLugarAcopioDefecto = IdLugarAcopio
                'My.Forms.FrmLocalidad.CodLugarAcopioDefecto = CodLugarAcopioDefecto
                'My.Forms.FrmLocalidad.NomLugarAcopioDefecto = NomLugarAcopioDefecto
                'My.Forms.FrmLocalidad.ShowDialog()


                My.Forms.FrmTecladoSerie.IdCosecha = IdCosecha
                My.Forms.FrmTecladoSerie.IdLocalidad = IdLugarAcopio
                My.Forms.FrmTecladoSerie.IdTipoCafe = IdTipoCafe
                My.Forms.FrmTecladoSerie.IdTipoCompra = IdTipoCompra
                My.Forms.FrmTecladoSerie.ShowDialog()
                Numero = My.Forms.FrmTecladoSerie.Numero

                If Numero = 0 Then
                    Quien = "Retorno"
                    Me.CboTipoCompra.Text = TipoCompra
                    Quien = ""
                    Exit Sub
                End If
                'Me.TxtNumeroEnsamble.Text = Format(Numero, "0000#")
                Me.TxtNumeroRecibo.Text = Format(Numero, "00000#")
                Me.TxtSerie.Text = My.Forms.FrmTecladoSerie.Serie
            End If

        Else
            If Quien <> "Load" Then
                If Me.CboTipoCompra.Text = "Compra Directa" Then
                    Me.TxtSerie.Text = "C" & Cod_Cosecha
                Else
                    Me.TxtSerie.Text = "?"
                End If
            End If
        End If


    End Sub

    Private Sub CboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEstado.SelectedIndexChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, i = 0


        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        SqlString = "SELECT  IdEdoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto  FROM EstadoFisico WHERE (Descripcion = '" & Me.CboEstado.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdEstadoFisico = DataSet.Tables("Consulta").Rows(0)("IdEdoFisico")
            Me.TxtHumedad.Text = DataSet.Tables("Consulta").Rows(0)("HumedadXDefecto")
            Me.ToolTip.SetToolTip(Me.TxtHumedad, "Humedad desde " & DataSet.Tables("Consulta").Rows(0)("HumedadInicial") & " Hasta " & DataSet.Tables("Consulta").Rows(0)("HumedadFinal"))
            HumedadxDefecto = DataSet.Tables("Consulta").Rows(0)("HumedadXDefecto")
        End If

        CalculaTaraRecepcion()

    End Sub

    Private Sub TxtHumedad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHumedad.Click
        My.Forms.FrmTeclado.ShowDialog()
        Me.TxtHumedad.Text = My.Forms.FrmTeclado.Numero
    End Sub

    Private Sub TxtHumedad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHumedad.TextChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, i = 0, Numero As Double, Minimo As Double, Maximo As Double

        If Me.TxtHumedad.Text <> "" Then
            Numero = Me.TxtHumedad.Text
        End If

        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        SqlString = "SELECT IdEdoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto  FROM EstadoFisico WHERE (Descripcion = '" & Me.CboEstado.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            Minimo = DataSet.Tables("Consulta").Rows(0)("HumedadInicial")
            Maximo = DataSet.Tables("Consulta").Rows(0)("HumedadFinal")

            If Numero < Minimo Then
                MsgBox("%Humedad esta Fuera del Rango", MsgBoxStyle.Critical, "Recepcion")
                Me.TxtHumedad.Text = DataSet.Tables("Consulta").Rows(0)("HumedadXDefecto")
                Exit Sub
            ElseIf Numero > Maximo Then
                MsgBox("%Humedad esta Fuera del Rango", MsgBoxStyle.Critical, "Recepcion")
                Me.TxtHumedad.Text = DataSet.Tables("Consulta").Rows(0)("HumedadXDefecto")
                Exit Sub
            End If

        End If

        CalculaTaraRecepcion()

    End Sub

    Private Sub TxtImperfecion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtImperfecion.Click
        My.Forms.FrmTeclado.ShowDialog()
        Me.TxtImperfecion.Text = My.Forms.FrmTeclado.Numero
    End Sub

    Private Sub TxtImperfecion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtImperfecion.TextChanged

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, i = 0, Numero As Double, Minimo As Double, Maximo As Double, Categoria

        If Me.TxtImperfecion.Text = "" Then
            Exit Sub
        End If

        If Not IsNumeric(Me.TxtImperfecion.Text) Then
            Me.TxtImperfecion.Text = ""
            Exit Sub
        End If

        Numero = Me.TxtImperfecion.Text

        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        'SqlString = "SELECT  IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion  FROM Calidad WHERE  (NomCalidad = '" & Me.CboTipoCalidad.Text & "')"
        SqlString = "SELECT  RelacionCalidadxCategoria.IdCalidad, RelacionCalidadxCategoria.IdCategoriaCAfe, Calidad.NomCalidad, RangoImperfeccion.Nombre, Calidad.IdCalidad, Calidad.CodCalidad, Calidad.NomCompleto, Calidad.MinImperfeccion, Calidad.MaxImperfeccion FROM  RelacionCalidadxCategoria INNER JOIN Calidad ON RelacionCalidadxCategoria.IdCalidad = Calidad.IdCalidad INNER JOIN RangoImperfeccion ON RelacionCalidadxCategoria.IdCategoriaCAfe = RangoImperfeccion.IdRangoImperfeccion  " & _
                           "WHERE (Calidad.NomCalidad = '" & Me.CboTipoCalidad.Text & "') AND (RangoImperfeccion.IdCosecha = " & IdCosecha & ") ORDER BY Calidad.NomCalidad"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            Minimo = DataSet.Tables("Consulta").Rows(0)("MinImperfeccion")
            Maximo = DataSet.Tables("Consulta").Rows(0)("MaxImperfeccion")
            Categoria = Me.CboCategoria.Text

            SqlString = "SELECT IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion FROM RangoImperfeccion WHERE (Maximo >= " & Numero & ") AND (Minimo <= " & Numero & ") AND (IdCosecha = " & IdCosecha & ") ORDER BY IdRangoImperfeccion DESC"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Rango")
            If DataSet.Tables("Rango").Rows.Count <> 0 Then
                Categoria = DataSet.Tables("Rango").Rows(0)("Nombre")
                Me.CboCategoria.Text = Categoria
                IdRangoImperfeccion = DataSet.Tables("Rango").Rows(0)("IdRangoImperfeccion")
            End If

            If Numero < Minimo Then
                MsgBox("%Imperfeccion esta Fuera del Rango Calidad", MsgBoxStyle.Critical, "Recepcion")
                Me.TxtImperfecion.Text = DataSet.Tables("Consulta").Rows(0)("MaxImperfeccion")
                Me.CboCategoria.Text = Categoria
                Exit Sub
            ElseIf Numero > Maximo Then
                MsgBox("%Imperfeccion esta Fuera del Rango Calidad", MsgBoxStyle.Critical, "Recepcion")
                Me.TxtImperfecion.Text = DataSet.Tables("Consulta").Rows(0)("MaxImperfeccion")
                Me.CboCategoria.Text = Categoria
                Exit Sub
            End If

            DataSet.Reset()

        End If
    End Sub

    Private Sub CboTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoDocumento.SelectedIndexChanged
        Dim SqlString As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, IdTipoDocumento As Double = 0, Numero As Double

        ''///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
        'SqlString = "SELECT   IdtipoDocumento, Descripcion FROM TipoDocumento WHERE (Descripcion = '" & Me.CboTipoDocumento.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        '    IdTipoDocumento = DataSet.Tables("Consulta").Rows(0)("IdtipoDocumento")
        'End If


        'SqlString = "SELECT Calidad.IdCalidad, Calidad.CodCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad " & _
        '            " WHERE(RelacionTipoDocumentoxCalidad.IdtipoDocumento = " & IdTipoDocumento & ")"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "BuscaCalidad")
        'Me.CboTipoCalidad.DataSource = DataSet.Tables("BuscaCalidad")


        ''If Me.CboTipoDocumento.Text = "Recibo Bascula Manual" Then
        ''    Me.TxtNumeroEnsamble.Enabled = True
        ''    Me.DtpFechaManual.Visible = True
        ''    Me.DtpHoraManual.Visible = True
        ''    Me.DtpFechaManual.Value = Now
        ''    Me.DtpHoraManual.Value = Now
        ''    My.Forms.FrmTecladoSerie.IdCosecha = IdCosecha
        ''    My.Forms.FrmTecladoSerie.IdLocalidad = IdLugarAcopio
        ''    My.Forms.FrmTecladoSerie.IdTipoCafe = IdTipoCafe
        ''    My.Forms.FrmTecladoSerie.IdTipoCompra = IdTipoCompra
        ''    My.Forms.FrmTecladoSerie.ShowDialog()
        ''    Numero = My.Forms.FrmTecladoSerie.Numero
        ''    Me.TxtNumeroEnsamble.Text = Format(Numero, "0000#")
        ''    Me.TxtNumeroRecibo.Text = Format(Numero, "0000#")
        ''    Me.TxtSerie.Text = My.Forms.FrmTecladoSerie.Serie
        ''    Me.CmdPesada.Visible = True
        ''    Me.CboLocalidad.Enabled = True
        ''    Me.Button15.Enabled = True

        ''    If Numero = 0 Then
        ''        Me.TxtNumeroEnsamble.Enabled = False
        ''        Me.TxtNumeroEnsamble.Text = "-----0-----"
        ''        Me.TxtNumeroRecibo.Text = "-----0-----"
        ''        Me.DtpFechaManual.Visible = False
        ''        Me.DtpHoraManual.Visible = False
        ''        Me.CmdPesada.Visible = False
        ''        Me.CboLocalidad.Enabled = True
        ''        Me.Button15.Enabled = True
        ''    End If

        ''ElseIf Me.CboTipoDocumento.Text = DescripcionTipoIngreso("BA") Then
        ''    Me.TxtNumeroEnsamble.Enabled = False
        ''    Me.TxtNumeroEnsamble.Text = "-----0-----"
        ''    Me.TxtNumeroRecibo.Text = "-----0-----"
        ''    Me.DtpFechaManual.Visible = False
        ''    Me.DtpHoraManual.Visible = False
        ''    Me.CmdPesada.Visible = False
        ''    Me.CboLocalidad.Enabled = True
        ''    Me.Button15.Enabled = True
        ''End If


    End Sub

    Private Sub CboIngreso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.CboIngreso.Text = "Manual" Then
        '    Me.TxtNumeroEnsamble.Enabled = True
        '    Me.DtpFechaManual.Visible = True
        '    Me.DtpHoraManual.Visible = True
        '    Me.DtpFechaManual.Value = Now
        '    Me.DtpHoraManual.Value = Now
        '    My.Forms.FrmTeclado.ShowDialog()
        '    Me.TxtNumeroEnsamble.Text = My.Forms.FrmTeclado.Numero


        'ElseIf Me.CboIngreso.Text = "Automatico" Then
        '    Me.TxtNumeroEnsamble.Enabled = False
        '    Me.TxtNumeroEnsamble.Text = "-----0-----"
        '    Me.DtpFechaManual.Visible = False
        '    Me.DtpHoraManual.Visible = False
        'End If
    End Sub

    Private Sub TxtEqOreado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEqOreado.TextChanged

    End Sub

    Private Sub CmdObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboDaño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDaño.SelectedIndexChanged
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        SqlString = "SELECT IdDano, Codigo, Nombre, Activo FROM Dano WHERE (Nombre = '" & Me.CboDaño.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Daño")
        If DataSet.Tables("Daño").Rows.Count <> 0 Then
            IdDaño = DataSet.Tables("Daño").Rows(0)("IdDano")
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFinca.SelectedIndexChanged
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Registros As Double, i As Double, Cadena As String, FechaCertificado As Date

        Me.ListBoxCertificados.Items.Clear()

        If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
            FechaCertificado = Me.DtpFechaManual.Value
        Else
            FechaCertificado = Me.LblHora.Text
        End If

        'SqlString = "SELECT CertificadoXFinca.IdCertificadoXFinca, CertificadoXFinca.IdCertificado, CertificadoXFinca.IdFinca, CertificadoXFinca.IdCosecha, CertificadoXFinca.Vigencia, Finca.NomFinca, Finca.CodFinca, Finca.IdProductor FROM  CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca  " & _
        '            "WHERE (Finca.NomFinca = '" & Me.CboFinca.Text & "') AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & ") ORDER BY CertificadoXFinca.Vigencia DESC"
        SqlString = "SELECT CertificadoXFinca.IdCertificadoXFinca, CertificadoXFinca.IdCertificado, CertificadoXFinca.IdFinca, CertificadoXFinca.IdCosecha, CertificadoXFinca.Vigencia, Finca.NomFinca, Finca.CodFinca, Finca.IdProductor, Certificado.Code, Certificado.Descripcion FROM CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca INNER JOIN Certificado ON CertificadoXFinca.IdCertificado = Certificado.IdCertificado  WHERE (Finca.NomFinca = '" & Me.CboFinca.Text & "') AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & ") AND (CertificadoXFinca.Vigencia >= CONVERT(DATETIME, '2019-01-31 00:00:00', 102)) ORDER BY CertificadoXFinca.Vigencia DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Certificado")
        Registros = DataSet.Tables("Certificado").Rows.Count
        i = 0
        Do While Registros > i
            Cadena = "Certificado: " & DataSet.Tables("Certificado").Rows(i)("Code")
            Me.ListBoxCertificados.Items.Add(Cadena)
            i = i + 1
        Loop


        SqlString = "SELECT  Finca.* FROM Finca WHERE  (NomFinca = '" & Me.CboFinca.Text & "') AND (IdProductor = " & IdProductor & ") "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Finca")
        If Not DataSet.Tables("Finca").Rows.Count = 0 Then
            IdFinca = DataSet.Tables("Finca").Rows(0)("IdFinca")
            Exit Sub
        Else
            IdFinca = 0
        End If





    End Sub

    Private Sub BindingDetalle_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingDetalle.CurrentChanged

    End Sub

    Private Sub CboEstadoDocumeto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)





    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPesada.Click
        Dim Pesada As Double, Posicion As Double



        Posicion = Me.TrueDBGridComponentes.Row

        FrmTeclado.ShowDialog()
        Pesada = FrmTeclado.Numero
        Me.LblPeso.Text = Pesada & " Kg"
        'Pesada = 100

        Me.TrueDBGridComponentes.Columns(5).Text = Pesada
        My.Application.DoEvents()
        GrabaLecturaPeso(Pesada)
        Me.TrueDBGridComponentes.Row = Posicion + 1



        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Psda"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        Me.TrueDBGridComponentes.Columns(1).Caption = "Código"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        Me.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        Me.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = False
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Locked = True
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Locked = True
    End Sub

    Private Sub CboIngreso_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SqlString As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, IdTipoDocumento As Double = 0, Numero As Double

        If Me.CboTipoDocumento.Text = "Manual" Then
            Me.TxtNumeroEnsamble.Enabled = True
            Me.DtpFechaManual.Visible = True
            Me.DtpHoraManual.Visible = True
            Me.DtpFechaManual.Value = Now
            Me.DtpHoraManual.Value = Now
            My.Forms.FrmTecladoSerie.IdCosecha = IdCosecha
            My.Forms.FrmTecladoSerie.IdLocalidad = IdLugarAcopio
            My.Forms.FrmTecladoSerie.IdTipoCafe = IdTipoCafe
            My.Forms.FrmTecladoSerie.IdTipoCompra = IdTipoCompra
            My.Forms.FrmTecladoSerie.ShowDialog()
            Numero = My.Forms.FrmTecladoSerie.Numero
            Me.TxtNumeroEnsamble.Text = Format(Numero, "0000#")
            Me.TxtNumeroRecibo.Text = Format(Numero, "0000#")
            Me.TxtSerie.Text = My.Forms.FrmTecladoSerie.Serie
            Me.CmdPesada.Visible = True
            Me.CboLocalidad.Enabled = True
            Me.Button15.Enabled = True

            If Numero = 0 Then
                Me.TxtNumeroEnsamble.Enabled = False
                Me.TxtNumeroEnsamble.Text = "-----0-----"
                Me.TxtNumeroRecibo.Text = "-----0-----"
                Me.DtpFechaManual.Visible = False
                Me.DtpHoraManual.Visible = False
                Me.CmdPesada.Visible = False
                Me.CboLocalidad.Enabled = True
                Me.Button15.Enabled = True
            End If

        ElseIf Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
            Me.TxtNumeroEnsamble.Enabled = False
            Me.TxtNumeroEnsamble.Text = "-----0-----"
            Me.TxtNumeroRecibo.Text = "-----0-----"
            Me.DtpFechaManual.Visible = False
            Me.DtpHoraManual.Visible = False
            Me.CmdPesada.Visible = False
            Me.CboLocalidad.Enabled = True
            Me.Button15.Enabled = True
        End If
    End Sub

    Private Sub CboTipoCafe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoCafe.SelectedIndexChanged
        Dim Sql As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim Fecha As Date, Precio As Double





        If Me.CboTipoCafe.Text = "MAQUILA" Then
            Me.OptMaquila.Checked = True
            Me.OptMaquila.Visible = False
            Me.CboLiquidarLocalidad.Visible = False
            Me.Button16.Visible = False
            Me.LblLiquidar.Visible = False
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Visible = False
            Me.LblPrecio.Visible = False
            Me.TxtPrecio.Visible = False
        Else
            Me.OptExpasa.Checked = True
            Me.LblLiquidar.Visible = True
            Me.CboLiquidarLocalidad.Visible = True
            Me.Button16.Visible = True
            'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Visible = True
            Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
            Me.LblPrecio.Visible = True
            Me.TxtPrecio.Visible = True
        End If

        '////////////////////////////BUSCO EL IdTipoCafe ////////////////////////////
        'IdTipoCafe = Me.CboTipoCafe.Text
        Sql = "SELECT IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.CboTipoCafe.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCafe")
        If DataSet.Tables("TipoCafe").Rows.Count <> 0 Then
            IdTipoCafe = DataSet.Tables("TipoCafe").Rows(0)("IdTipoCafe")
        End If


        Sql = "SELECT TipoCompra.IdTipoCompra, TipoCompra.Nombre FROM RelacionTipoCompraxCalidad INNER JOIN TipoCompra ON RelacionTipoCompraxCalidad.IdCalidad = TipoCompra.IdTipoCompra INNER JOIN TipoCafe ON RelacionTipoCompraxCalidad.IdTipoCompra = TipoCafe.IdTipoCafe " & _
              "WHERE(TipoCafe.IdTipoCafe = " & IdTipoCafe & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCompra")
        Me.CboTipoCompra.DataSource = DataSet.Tables("TipoCompra")

        'Sql = "SELECT RelacionTipoDocumentoxCalidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN TipoCafe ON RelacionTipoDocumentoxCalidad.IdtipoDocumento = TipoCafe.IdTipoCafe INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad " & _
        '      "WHERE( RelacionTipoDocumentoxCalidad.IdtipoDocumento = " & IdTipoCafe & ")"

        Sql = "SELECT DISTINCT Calidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad " & _
              "WHERE(RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdTipoCafe & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCalidad")
        Me.CboTipoCalidad.DataSource = DataSet.Tables("TipoCalidad")


        '-------------------------------------------------------------------------------------------------------
        '----------------------------ESTA OPCION SOLICITADO POR MARIELOS 09-09-2019 ----------------------------
        '-------------------------------------------------------------------------------------------------------
        If CboEstadoDocumeto.Text = "Editable" Then
            Me.Button12.Enabled = False
        ElseIf CboEstadoDocumeto.Text = "Anulado" Then
            Me.Button12.Enabled = False
        Else
            Me.Button12.Enabled = True
        End If
    End Sub

    Private Sub Button15_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Quien = "Localidad"
        My.Forms.FrmConsultas.Text = "Consulta Localidad"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA LOCALIDAD"

        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Quien = "Consulta"
            Me.CboLocalidad.Text = My.Forms.FrmConsultas.Descripcion
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Quien = "Localidad"
        My.Forms.FrmConsultas.Text = "Consulta Localidad"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA LOCALIDAD"

        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Me.CboLiquidarLocalidad.Text = My.Forms.FrmConsultas.Descripcion
        End If
    End Sub

    Private Sub Button17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        FrmTecladoHora.Show()
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub CmdProductorManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdProductorManual.Click
        FrmProveedorManual.ShowDialog()
    End Sub

    Private Sub CboTipoIngresoBascula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoIngresoBascula.SelectedIndexChanged
        Dim SqlString As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, IdTipoDocumento As Double = 0, Numero As Double
        Dim Code As String, ConsecutivoCompra As Double, NumeroRecepcion As String

        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        SqlString = "SELECT IdTipoIngreso, Descripcion, Code, IdECS FROM TipoIngreso WHERE  (Descripcion = '" & Me.CboTipoIngresoBascula.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdTipoIngreso = DataSet.Tables("Consulta").Rows(0)("IdECS")
            Code = DataSet.Tables("Consulta").Rows(0)("Code")
        End If

        If Quien = "CCC" Then
            Quien = ""
            Exit Sub
        End If


        If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
            Quien = ""

            Me.Button7.Enabled = False
            Me.Button12.Enabled = False
            Me.CmdConfirma.Enabled = False
            Me.TxtNumeroEnsamble.Enabled = True
            Me.TxtNumeroRecibo.Enabled = True
            Me.TxtNumeroRecibo.ReadOnly = True
            Me.DtpFechaManual.Visible = True
            Me.DtpHoraManual.Visible = True
            Me.DtpFechaManual.Enabled = False
            Me.DtpHoraManual.Enabled = False
            Me.DtpFechaManual.Value = Now
            Me.DtpHoraManual.Value = Now

            My.Forms.FrmLocalidad.IdLugarAcopioDefecto = IdLugarAcopio
            My.Forms.FrmLocalidad.CodLugarAcopioDefecto = CodLugarAcopioDefecto
            My.Forms.FrmLocalidad.NomLugarAcopioDefecto = NomLugarAcopioDefecto
            My.Forms.FrmLocalidad.ShowDialog()


            My.Forms.FrmTecladoSerie.IdCosecha = IdCosecha
            My.Forms.FrmTecladoSerie.IdLocalidad = IdLugarAcopio
            My.Forms.FrmTecladoSerie.IdTipoCafe = IdTipoCafe
            My.Forms.FrmTecladoSerie.IdTipoCompra = IdTipoCompra
            My.Forms.FrmTecladoSerie.ShowDialog()
            Numero = My.Forms.FrmTecladoSerie.Numero

            If Numero = 0 Then
                Me.LblSucursal.Text = NomLugarAcopioDefecto
                IdLugarAcopio = IdLugarAcopioDefecto
                CodLugarAcopio = CodLugarAcopioDefecto
                Me.TxtIdLocalidad.Text = CodLugarAcopio
                Me.CboLocalidad.Text = NomLugarAcopioDefecto
                Me.CboLiquidarLocalidad.Text = NomLugarAcopioDefecto
            Else

                Me.TxtNumeroRecibo.Text = Format(Numero, "00000#")
                Me.TxtSerie.Text = My.Forms.FrmTecladoSerie.Serie
                Me.CmdPesada.Visible = True
                Me.CboLocalidad.Enabled = True
                Me.Button15.Enabled = True
            End If


            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                Select Case Me.CboTipoRecepcion.Text
                    Case "Recepcion"
                        ConsecutivoCompra = BuscaConsecutivo("Recepcion", CodLugarAcopio)

                    Case "RePesaje"
                        ConsecutivoCompra = BuscaConsecutivo("ReImprime", CodLugarAcopio)
                    Case "Lote"
                        ConsecutivoCompra = BuscaConsecutivo("Lote", CodLugarAcopio)
                End Select

                NumeroRecepcion = CodLugarAcopio & "-" & Format(ConsecutivoCompra, "00000#")
            Else
                NumeroRecepcion = Me.TxtNumeroEnsamble.Text
            End If

            If Numero = 0 Then
                Me.TxtNumeroEnsamble.Enabled = False
                Me.TxtNumeroEnsamble.Text = "-----0-----"
                Me.TxtNumeroRecibo.Text = "-----0-----"
                Me.DtpFechaManual.Visible = False
                Me.DtpHoraManual.Visible = False
                Me.CmdPesada.Visible = False
                Me.CboLocalidad.Enabled = True
                Me.Button15.Enabled = True
                Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA")
            End If

        ElseIf Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then

            Me.LblSucursal.Text = NomLugarAcopioDefecto
            IdLugarAcopio = IdLugarAcopioDefecto
            CodLugarAcopio = CodLugarAcopioDefecto
            Me.TxtIdLocalidad.Text = CodLugarAcopio
            Me.CboLocalidad.Text = NomLugarAcopioDefecto
            Me.CboLiquidarLocalidad.Text = NomLugarAcopioDefecto
            Me.TxtSerie.Text = ""

            If Me.CboTipoCompra.Text = "Compra Directa" Then
                Me.TxtSerie.Text = "C" & Cod_Cosecha
            Else
                Me.TxtSerie.Text = "?"
            End If

            Me.TxtNumeroRecibo.Enabled = False
            Me.TxtNumeroEnsamble.Enabled = False
            Me.TxtNumeroEnsamble.Text = "-----0-----"
            Me.TxtNumeroRecibo.Text = "-----0-----"
            Me.DtpFechaManual.Visible = False
            Me.DtpHoraManual.Visible = False
            Me.CmdPesada.Visible = False
            Me.CboLocalidad.Enabled = True
            Me.Button15.Enabled = True

            Me.Button7.Enabled = True
            'Me.Button12.Enabled = True
            Me.CmdConfirma.Enabled = True
            Me.LblSucursal.Text = NomLugarAcopioDefecto
            My.Application.DoEvents()


        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConfirma.Click
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion), ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim IdRecibo As Double



        If MsgBox("Esta Seguro de Confirmar?", MsgBoxStyle.YesNo, "BA") = MsgBoxResult.No Then
            Exit Sub
        End If

        If Len(Me.TxtNumeroCedula.Text) < 14 Then
            MsgBox("El Numero de Cedula no puede ser menor de 14 digitos", MsgBoxStyle.Critical, "Recibos")
            Exit Sub
        End If



        SqlString = "SELECT  ReciboCafePergamino.*  FROM ReciboCafePergamino WHERE (IdReciboPergamino = '" & IdReciboCafe & "') ORDER BY IdReciboPergamino DESC"   'AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd") & "', 102))
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then

            IdRecibo = DataSet.Tables("Consulta").Rows(0)("IdReciboPergamino")
            '/////////////////////////////////////////////////////////////////////////////
            '///////////////BUSCO EL ID DEL TIPO DE CAFE ///////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Open()
            StrSqlUpdate = "UPDATE [ReciboCafePergamino] SET [IdEstadoDocumento] = '294' WHERE (IdReciboPergamino = " & IdReciboCafe & ")"
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If
    End Sub



    Private Sub CboLocalidad_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLocalidad.TextChanged
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        If Quien = "Load" Then
            Quien = "Consulta"
            Exit Sub
        ElseIf Quien = "Consulta" Then

            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            SqlString = "SELECT  * FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Localidad")
            If DataSet.Tables("Localidad").Rows.Count = 0 Then
                MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
                Exit Sub
            Else

                Quien = "Consulta"

                If Me.CboTipoIngresoBascula.Text <> DescripcionTipoIngreso("M") Then
                    Me.LblSucursal.Text = NomLugarAcopioDefecto
                    IdLugarAcopio = IdLugarAcopioDefecto
                    CodLugarAcopio = CodLugarAcopio

                    Me.TxtIdLocalidad.Text = CodLugarAcopio
                    Me.CboLocalidad.Text = NomLugarAcopioDefecto
                    Me.CboLiquidarLocalidad.Text = NomLugarAcopioDefecto

                Else
                    Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
                    IdLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
                    CodLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
                    IdTipoLugarAcopio = DataSet.Tables("Localidad").Rows(0)("TipoLugarAcopio")
                    Me.TxtIdLocalidad.Text = DataSet.Tables("Localidad").Rows(0)("CodLugarAcopio")
                    Me.CboLocalidad.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
                    Me.CboLiquidarLocalidad.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")

                End If



            End If
        Else
            IdLugarAcopio = Me.CboLocalidad.Columns(0).Text

        End If

        CalculaTaraRecepcion()




        SqlString = "SELECT  * FROM LugarAcopio WHERE (IdLugarAcopio = '" & IdLugarAcopio & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscoLocalidad")
        If DataSet.Tables("BuscoLocalidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Me.LblSucursal.Text = DataSet.Tables("BuscoLocalidad").Rows(0)("NomLugarAcopio")
            IdLugarAcopio = DataSet.Tables("BuscoLocalidad").Rows(0)("IdLugarAcopio")
            IdTipoLugarAcopio = DataSet.Tables("BuscoLocalidad").Rows(0)("TipoLugarAcopio")
        End If

        DataSet.Tables("BuscoLocalidad").Reset()


        '///////////////////////////////////SI ES CENTRO DE ACOPIO QUITO LA OPCION DE LIQUIDAR /////////////////////////
        'SqlString = "SELECT TipoLocalidad.Descripcion, LugarAcopio.NomLugarAcopio, LugarAcopio.IdLugarAcopio FROM  LugarAcopio INNER JOIN  TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad  " & _
        '            "WHERE  (TipoLocalidad.Descripcion LIKE '%Centro de Acopio%') AND (LugarAcopio.IdLugarAcopio = " & IdLugarAcopio & ")"
        SqlString = "SELECT  TipoLocalidad.Descripcion, LugarAcopio.NomLugarAcopio, LugarAcopio.IdLugarAcopio, TipoLocalidad.IdTipoLocalidad FROM LugarAcopio INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad  WHERE (TipoLocalidad.IdTipoLocalidad = 12) AND (LugarAcopio.IdLugarAcopio = " & IdLugarAcopio & ") "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscoLocalidad")
        If DataSet.Tables("BuscoLocalidad").Rows.Count <> 0 Then
            Me.CboLiquidarLocalidad.Text = Me.CboLocalidad.Text
            Me.CboLiquidarLocalidad.Enabled = False
            Me.LblLiquidar.Enabled = False
            Me.Button16.Enabled = False
        Else
            Me.CboLiquidarLocalidad.Enabled = False
            Me.LblLiquidar.Enabled = False
            Me.Button16.Enabled = False
        End If

    End Sub

    Private Sub DtpFechaManual_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpFechaManual.GotFocus
        Dim sql As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        sql = "SELECT IdEstadoDocumento, Codigo, Descripcion  FROM EstadoDocumento WHERE (Descripcion = '" & Me.CboEstadoDocumeto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "EstadoDocumento")
        If DataSet.Tables("EstadoDocumento").Rows.Count <> 0 Then
            IdEstadoDocumento = DataSet.Tables("EstadoDocumento").Rows(0)("IdEstadoDocumento")
        End If

        'If IdEstadoDocumento = "294" Then
        '    '/////////////////////////////////CONFIRMADO 777777777777777777777
        '    Me.Button7.Enabled = False
        '    Me.Button12.Enabled = False
        '    Me.CmdConfirma.Enabled = True
        'ElseIf IdEstadoDocumento = "293" Then
        '    '/////////////////////////////EDITABLE /////////////////////////////
        '    Me.Button7.Enabled = True
        '    Me.Button12.Enabled = False
        '    Me.CmdConfirma.Enabled = False
        'End If

        If Me.CboEstadoDocumeto.Text = "Confirmado" Then
            IdEstadoDocumento = "294"

            If Me.CboTipoCompra.Text = "Compra Directa" Then
                '////////////////////SI ES COMPRA DIRECTA BLOQUEAMOS LA OPCION DE IMPRIMIR ///////////////////////
                Me.Button12.Enabled = False
            Else
                Me.Button12.Enabled = True
            End If

            Me.Button7.Enabled = True
            Me.DtpFechaManual.Enabled = False
            Me.DtpHoraManual.Enabled = False

        ElseIf Me.CboEstadoDocumeto.Text = "Anulado" Then
            IdEstadoDocumento = "292"
            Me.Button12.Enabled = False
        ElseIf Me.CboEstadoDocumeto.Text = "Editable" Then
            IdEstadoDocumento = "293"
            Me.Button12.Enabled = False
            Me.Button7.Enabled = True
            Me.DtpFechaManual.Enabled = True
            Me.DtpHoraManual.Enabled = True
        End If

    End Sub

    Private Sub SumaGrid()
        '/////////////////////////////AL CAMBIAR LA FECHA RECORRO EL GRID Y CAMBIO LOS PRECIOS ////////////////////////////
        Dim Cant As Double, i As Double, Pos As Double, Precio As Double, Fecha As Date

        Pos = Me.TrueDBGridComponentes.Row
        Cant = Me.TrueDBGridComponentes.RowCount
        Fecha = Format(CDate(Me.DtpFechaManual.Text), "dd/MM/yyyy") & " " & Format(CDate(Me.DtpHoraManual.Text), "HH:mm:ss")
        i = 0
        Do While Cant > i
            Me.TrueDBGridComponentes.Row = i
            Precio = PrecioVenta(IdLugarAcopio, IdCalidad, CboCategoria.Text, Fecha)
            Precio = Format(Precio / 46, "##,##0.00")
            If Me.TrueDBGridComponentes.Columns("Precio").Text <> "" Then
                Me.TrueDBGridComponentes.Columns("Precio").Text = Precio
            End If
            i = i + 1
        Loop

        'Me.TrueDBGridComponentes.Row = Pos
    End Sub

    Private Sub DtpFechaManual_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpFechaManual.TextChanged
        'SumaGrid()
    End Sub

    Private Sub DtpFechaManual_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFechaManual.ValueChanged
        Dim Fecha As Date, Precio As Double

        Fecha = Format(CDate(Me.DtpFechaManual.Text), "dd/MM/yyyy") & " " & Format(CDate(Me.DtpHoraManual.Text), "HH:mm:ss")
        Precio = PrecioVenta(IdLugarAcopio, IdCalidad, CboCategoria.Text, Fecha)
        Precio = Format(Precio / 46, "##,##0.00")
        Me.TxtPrecio.Text = Precio

    End Sub

    Private Sub TxtFinca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFinca.TextChanged
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Registros As Double, i As Double, Cadena As String, FechaCertificado As Date

        Me.ListBoxCertificados.Items.Clear()

        If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
            FechaCertificado = Me.DtpFechaManual.Value
        Else
            FechaCertificado = Me.LblHora.Text
        End If

        'SqlString = "SELECT CertificadoXFinca.IdCertificadoXFinca, CertificadoXFinca.IdCertificado, CertificadoXFinca.IdFinca, CertificadoXFinca.IdCosecha, CertificadoXFinca.Vigencia, Finca.NomFinca, Finca.CodFinca, Finca.IdProductor FROM  CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca  " & _
        '            "WHERE (Finca.NomFinca = '" & Me.CboFinca.Text & "') AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & ") ORDER BY CertificadoXFinca.Vigencia DESC"
        SqlString = "SELECT CertificadoXFinca.IdCertificadoXFinca, CertificadoXFinca.IdCertificado, CertificadoXFinca.IdFinca, CertificadoXFinca.IdCosecha, CertificadoXFinca.Vigencia, Finca.NomFinca, Finca.CodFinca, Finca.IdProductor, Certificado.Code, Certificado.Descripcion FROM CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca INNER JOIN Certificado ON CertificadoXFinca.IdCertificado = Certificado.IdCertificado  WHERE (Finca.NomFinca = '" & Me.CboFinca.Text & "') AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & ") AND (CertificadoXFinca.Vigencia >= CONVERT(DATETIME, '2019-01-31 00:00:00', 102)) ORDER BY CertificadoXFinca.Vigencia DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Certificado")
        Registros = DataSet.Tables("Certificado").Rows.Count
        i = 0
        Do While Registros > i
            Cadena = "Certificado: " & DataSet.Tables("Certificado").Rows(i)("IdCertificado") & "   Codigo: " & DataSet.Tables("Certificado").Rows(i)("Code")
            Me.ListBoxCertificados.Items.Add(Cadena)
            i = i + 1
        Loop

        'If Not DataSet.Tables("Certificado").Rows.Count = 0 Then
        '    NumeroCertificado = DataSet.Tables("Certificado").Rows(0)("IdCertificado")
        '    FechaVence = DataSet.Tables("Certificado").Rows(0)("Vigencia")
        '    Me.LblCertificado.Text = "No.Certificado: " & NumeroCertificado & " Vence: " & Format(FechaVence, "dd/MM/yyyy")
        '    Exit Sub
        'Else
        '    Me.LblCertificado.Text = "NO TIENE CERTIFICADO VIGENTE"
        'End If
    End Sub

    Private Sub Button18_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Quien = "CertificadoFinca"
        My.Forms.FrmConsultas.ShowDialog()
        If FrmConsultas.Codigo <> "-----0-----" Then
            NumeroCertificado = My.Forms.FrmConsultas.Codigo
            FechaVence = My.Forms.FrmConsultas.Vigencia

            Me.LblCertificado.Text = "No.Certificado: " & NumeroCertificado & " Vence: " & Format(FechaVence, "dd/MM/yyyy")
        End If
    End Sub

    Private Sub TxtNumeroRecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroRecibo.Click
        Dim SqlString As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, IdTipoDocumento As Double = 0, Numero As Double
        Dim Code As String, ConsecutivoCompra As Double, NumeroRecepcion As String

        If IdEstadoDocumento = "294" Then
            Exit Sub
        ElseIf IdEstadoDocumento = "292" Then
            Exit Sub
        End If

        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        SqlString = "SELECT IdTipoIngreso, Descripcion, Code, IdECS FROM TipoIngreso WHERE  (Descripcion = '" & Me.CboTipoIngresoBascula.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdTipoIngreso = DataSet.Tables("Consulta").Rows(0)("IdECS")
            Code = DataSet.Tables("Consulta").Rows(0)("Code")
        End If

        If Quien = "CCC" Then
            Quien = ""
            Exit Sub
        End If


        If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
            Quien = ""

            Me.Button7.Enabled = False
            Me.Button12.Enabled = False
            Me.CmdConfirma.Enabled = False
            Me.TxtNumeroEnsamble.Enabled = True
            Me.TxtNumeroRecibo.Enabled = True
            Me.DtpFechaManual.Visible = True
            Me.DtpHoraManual.Visible = True
            Me.DtpFechaManual.Value = Now
            Me.DtpHoraManual.Value = Now
            My.Forms.FrmTecladoSerie.IdCosecha = IdCosecha
            My.Forms.FrmTecladoSerie.IdLocalidad = IdLugarAcopio
            My.Forms.FrmTecladoSerie.IdTipoCafe = IdTipoCafe
            My.Forms.FrmTecladoSerie.IdTipoCompra = IdTipoCompra
            My.Forms.FrmTecladoSerie.ShowDialog()
            Numero = My.Forms.FrmTecladoSerie.Numero
            'Me.TxtNumeroEnsamble.Text = Format(Numero, "0000#")
            Me.TxtNumeroRecibo.Text = Format(Numero, "00000#")
            Me.TxtSerie.Text = My.Forms.FrmTecladoSerie.Serie
            Me.CmdPesada.Visible = True
            Me.CboLocalidad.Enabled = True
            Me.Button15.Enabled = True

            If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
                Select Case Me.CboTipoRecepcion.Text
                    Case "Recepcion"
                        ConsecutivoCompra = BuscaConsecutivo("Recepcion", CodLugarAcopio)

                    Case "RePesaje"
                        ConsecutivoCompra = BuscaConsecutivo("ReImprime", CodLugarAcopio)
                    Case "Lote"
                        ConsecutivoCompra = BuscaConsecutivo("Lote", CodLugarAcopio)
                End Select

                NumeroRecepcion = CodLugarAcopio & "-" & Format(ConsecutivoCompra, "00000#")
            Else
                NumeroRecepcion = Me.TxtNumeroEnsamble.Text
            End If

            If Numero = 0 Then
                Me.TxtNumeroEnsamble.Enabled = False
                Me.TxtNumeroEnsamble.Text = "-----0-----"
                Me.TxtNumeroRecibo.Text = "-----0-----"
                Me.DtpFechaManual.Visible = False
                Me.DtpHoraManual.Visible = False
                Me.CmdPesada.Visible = False
                Me.CboLocalidad.Enabled = True
                Me.Button15.Enabled = True
                Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA")
            End If

        ElseIf Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then

            Me.TxtNumeroRecibo.Enabled = False
            Me.TxtNumeroEnsamble.Enabled = False
            Me.TxtNumeroEnsamble.Text = "-----0-----"
            Me.TxtNumeroRecibo.Text = "-----0-----"
            Me.DtpFechaManual.Visible = False
            Me.DtpHoraManual.Visible = False
            Me.CmdPesada.Visible = False
            Me.CboLocalidad.Enabled = False
            Me.Button15.Enabled = False

            Me.Button7.Enabled = True
            Me.Button12.Enabled = True
            Me.CmdConfirma.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEstadoDocumeto.SelectedIndexChanged
        Dim sql As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        sql = "SELECT IdEstadoDocumento, Codigo, Descripcion  FROM EstadoDocumento WHERE (Descripcion = '" & Me.CboEstadoDocumeto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "EstadoDocumento")
        If DataSet.Tables("EstadoDocumento").Rows.Count <> 0 Then
            IdEstadoDocumento = DataSet.Tables("EstadoDocumento").Rows(0)("IdEstadoDocumento")
        End If

        If EstadoDoc = "Editable" Then
            IdEstadoDocumento = 293
        End If

        If Quien = "Load" Then
            Exit Sub
        End If

        If My.Forms.FrmConsultas.Codigo = "-----0-----" Then
            Exit Sub
        End If

        If Me.CboEstadoDocumeto.Text = "Confirmado" Then
            IdEstadoDocumento = "294"

            If Me.CboTipoCompra.Text = "Compra Directa" Then
                '////////////////////SI ES COMPRA DIRECTA BLOQUEAMOS LA OPCION DE IMPRIMIR ///////////////////////
                Me.Button12.Enabled = False
            Else
                Me.Button12.Enabled = True
            End If

            Me.Button7.Enabled = True
            Me.DtpFechaManual.Enabled = False
            Me.DtpHoraManual.Enabled = False

        ElseIf Me.CboEstadoDocumeto.Text = "Anulado" Then
            IdEstadoDocumento = "292"
            Me.Button12.Enabled = False
        ElseIf Me.CboEstadoDocumeto.Text = "Editable" Then
            IdEstadoDocumento = "293"
            Me.Button12.Enabled = False
            Me.Button7.Enabled = True
            Me.DtpFechaManual.Enabled = True
            Me.DtpHoraManual.Enabled = True



        End If





    End Sub
    Public Sub BloqueoEstadoRecibo(ByVal IdEstadoDocumento)

        If IdEstadoDocumento = "294" Then
            Me.CboEstadoDocumeto.Text = "Confirmado"
            Me.CboEstadoDocumeto.Enabled = False
            Me.TrueDBGridComponentes.Enabled = False
            Me.CboTipoCafe.Enabled = False
            Me.CboTipoCalidad.Enabled = False
            Me.CboCodigoProveedor.Enabled = False
            Me.CboTipoCompra.Enabled = False
            Me.CboTipoDocumento.Enabled = False
            Me.CboTipoIngresoBascula.Enabled = False
            Me.CboTipoRecepcion.Enabled = False
            Me.CboCategoria.Enabled = False
            Me.CboDaño.Enabled = False
            Me.CboEstado.Enabled = False
            Me.CboFinca.Enabled = False
            Me.TxtNumeroCedula.Enabled = False
            Me.TxtFinca.Enabled = False
            Me.txtnombre.Enabled = False
            Me.CmdProductorManual.Enabled = False
            Me.Button2.Enabled = False
            Me.Button14.Enabled = False
            Me.Button15.Enabled = False
            Me.CboLocalidad.Enabled = False
            Me.CboLiquidarLocalidad.Enabled = False
            Me.Button16.Enabled = False
            Me.CmdPesada.Enabled = False
            Me.TxtHumedad.Enabled = False
            Me.TxtImperfecion.Enabled = False
            Me.CmdObservaciones.Enabled = False
            Me.Button11.Enabled = False
            Me.Button10.Enabled = False
            Me.Button7.Enabled = True
            Me.Button6.Enabled = False
            Me.CmdConfirma.Enabled = False
            Me.Button12.Enabled = True
            Me.Button4.Enabled = True
            Me.Button12.Enabled = True
            Me.Button4.Enabled = True

        ElseIf IdEstadoDocumento = "292" Then
            Me.CboEstadoDocumeto.Text = "Anulado"
            Me.CboEstadoDocumeto.Enabled = False
            Me.TrueDBGridComponentes.Enabled = False
            Me.CboTipoCafe.Enabled = False
            Me.CboTipoCalidad.Enabled = False
            Me.CboCodigoProveedor.Enabled = False
            Me.CboTipoCompra.Enabled = False
            Me.CboTipoDocumento.Enabled = False
            Me.CboTipoIngresoBascula.Enabled = False
            Me.CboTipoRecepcion.Enabled = False
            Me.CboCategoria.Enabled = False
            Me.CboDaño.Enabled = False
            Me.CboEstado.Enabled = False
            Me.CboFinca.Enabled = False
            Me.TxtNumeroCedula.Enabled = False
            Me.TxtFinca.Enabled = False
            Me.txtnombre.Enabled = False
            Me.CmdProductorManual.Enabled = False
            Me.Button2.Enabled = False
            Me.Button14.Enabled = False
            Me.Button15.Enabled = False
            Me.CboLocalidad.Enabled = False
            Me.CboLiquidarLocalidad.Enabled = False
            Me.Button16.Enabled = False
            Me.CmdPesada.Enabled = False
            Me.TxtHumedad.Enabled = False
            Me.TxtImperfecion.Enabled = False
            Me.CmdObservaciones.Enabled = False
            Me.Button11.Enabled = False
            Me.Button10.Enabled = False
            Me.Button7.Enabled = True
            Me.Button6.Enabled = False
            Me.CmdConfirma.Enabled = True
            Me.Button12.Enabled = False
            Me.Button4.Enabled = False

        ElseIf IdEstadoDocumento = "293" Then

            Me.Button7.Enabled = True
            Me.CmdConfirma.Enabled = True
            Me.Button12.Enabled = False
            Me.Button4.Enabled = False


        End If
    End Sub


    Private Sub DTPFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFecha.Click

    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DtpHoraManual_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpHoraManual.ValueChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPignorado.SelectedIndexChanged
        Dim SQLString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter



        SQLString = "SELECT  IdPignorado, codigo, Descripccion, Activo FROM Pignorado WHERE (Descripccion = '" & Me.CboPignorado.Text & " ')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Pignorado")
        If Not DataSet.Tables("Pignorado").Rows.Count = 0 Then
            IdPignorado = DataSet.Tables("Pignorado").Rows(0)("IdPignorado")
        Else
            IdPignorado = 0
        End If


    End Sub

    Private Sub CboLiquidarLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLiquidarLocalidad.TextChanged

    End Sub

    Private Sub C1Combo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub CboFinca2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Registros As Double, i As Double, Cadena As String, FechaCertificado As Date

        Me.ListBoxCertificados.Items.Clear()

        If Me.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("M") Then
            FechaCertificado = Me.DtpFechaManual.Value
        Else
            FechaCertificado = Me.LblHora.Text
        End If

        'SqlString = "SELECT CertificadoXFinca.IdCertificadoXFinca, CertificadoXFinca.IdCertificado, CertificadoXFinca.IdFinca, CertificadoXFinca.IdCosecha, CertificadoXFinca.Vigencia, Finca.NomFinca, Finca.CodFinca, Finca.IdProductor FROM  CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca  " & _
        '            "WHERE (Finca.NomFinca = '" & Me.CboFinca.Text & "') AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & ") ORDER BY CertificadoXFinca.Vigencia DESC"
        SqlString = "SELECT CertificadoXFinca.IdCertificadoXFinca, CertificadoXFinca.IdCertificado, CertificadoXFinca.IdFinca, CertificadoXFinca.IdCosecha, CertificadoXFinca.Vigencia, Finca.NomFinca, Finca.CodFinca, Finca.IdProductor, Certificado.Code, Certificado.Descripcion FROM CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca INNER JOIN Certificado ON CertificadoXFinca.IdCertificado = Certificado.IdCertificado  WHERE (Finca.NomFinca = '" & Me.CboFinca.Text & "') AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & ") AND (CertificadoXFinca.Vigencia >= CONVERT(DATETIME, '2019-01-31 00:00:00', 102)) ORDER BY CertificadoXFinca.Vigencia DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Certificado")
        Registros = DataSet.Tables("Certificado").Rows.Count
        i = 0
        Do While Registros > i
            Cadena = "Certificado: " & DataSet.Tables("Certificado").Rows(i)("Code")
            Me.ListBoxCertificados.Items.Add(Cadena)
            i = i + 1
        Loop

        'SE CAMBIO POR QUE EL PROVEEDOR PUEDE TENER DOS FINCAS CON EL MISMO NOMBRE
        'SqlString = "SELECT  Finca.* FROM Finca WHERE  (NomFinca = '" & Me.CboFinca.Text & "') AND (IdProductor = " & IdProductor & ") "
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Finca")
        'If Not DataSet.Tables("Finca").Rows.Count = 0 Then
        '    IdFinca = DataSet.Tables("Finca").Rows(0)("IdFinca")
        '    Exit Sub
        'Else
        '    IdFinca = 0
        'End If

        'IdFinca = 0


    End Sub

    Private Sub TxtNumeroRecibo_SystemColorsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroRecibo.SystemColorsChanged

    End Sub

    Private Sub TxtNumeroRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroRecibo.TextChanged

    End Sub

    Private Sub TxtIdLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIdLocalidad.TextChanged

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiaRecepcion()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdObservaciones.Click
        FrmObservaciones.TxtObservaciones.Text = Observaciones
        FrmObservaciones.ShowDialog()
        If FrmObservaciones.TxtObservaciones.Text <> "" Then
            Observaciones = FrmObservaciones.TxtObservaciones.Text
        End If
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Pesada As Double, Posicion As Double, Clave As String

        My.Forms.FrmClave.ShowDialog()
        Clave = My.Forms.FrmClave.Clave

        If Clave <> "SYS2019" Then
            Exit Sub
        Else
            Me.TxtNumeroEnsamble.Visible = True
            Me.TxtNumeroEnsamble.Visible = True
            Button15_Click(sender, e)
        End If



    End Sub

    Private Sub TrueDBGridComponentes_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles TrueDBGridComponentes.Invalidated

    End Sub
End Class