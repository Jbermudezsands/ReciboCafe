Public Class FrmProductos
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    'Public MiConexionContabilidad As New SqlClient.SqlConnection(ConexionContabilidad)
    Public CodComponente As Double


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProducto.Text = My.Forms.FrmConsultas.Codigo
        'Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoProducto
        'Me.TxtNombreProducto.Text = My.Forms.FrmConsultas.Descripcion

    End Sub

    Private Sub Button6_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboCodigoProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CodigoProducto As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
        Dim CodLinea As String, SqlLinea As String, CodImpuesto As String, SqlImpuesto As String


        If Me.CboCodigoProducto.Text = "" Then
            Me.TxtUbicacion.Text = ""

            Me.TxtNombreProducto.Text = ""
            Me.CboTipoProducto.Text = ""
            Me.CboUnidad.Text = ""
            Me.TxtDescuento.Text = ""
            Me.CboExistencia.Text = ""
            Me.CboActivo.Text = ""

            CodComponente = 0
            Exit Sub
        End If

        CodigoProducto = Me.CboCodigoProducto.Text
        SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "') "
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If Not DataSet.Tables("Producto").Rows.Count = 0 Then
            Me.TxtUbicacion.Text = DataSet.Tables("Producto").Rows(0)("Ubicacion")
            Me.TxtNombreProducto.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
            Me.CboTipoProducto.Text = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")


            Me.CboUnidad.Text = DataSet.Tables("Producto").Rows(0)("Unidad_Medida")
            Me.TxtDescuento.Text = DataSet.Tables("Producto").Rows(0)("Descuento")
            If DataSet.Tables("Producto").Rows(0)("Existencia_Negativa") = True Then
                Me.CboExistencia.Text = "SI"
            Else
                Me.CboExistencia.Text = "NO"
            End If




            If DataSet.Tables("Producto").Rows(0)("Activo") = True Then
                Me.CboActivo.Text = "Activo"
            Else
                Me.CboActivo.Text = "Inactivo"
            End If




            MiConexion.Close()
        End If

        MiConexion.Close()


    End Sub

    Private Sub FrmProductos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String
        Dim SqlLinea As String = "SELECT * FROM Lineas ", SqlImpuestos As String = "SELECT * FROM Impuestos"
        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
        End If
        'Me.CboCodigoProducto.Splits.Item(0).DisplayColumns(1).Width = 300


    End Sub

    Private Sub FrmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String
        Dim SqlLinea As String = "SELECT * FROM Lineas ", SqlImpuestos As String = "SELECT * FROM Impuestos"

        DataSet.Reset()
        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
        End If







    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CboCodigoProducto.Text = ""
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtCuentaVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoProducto.Text = ""
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        Dim SQLProductos As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim CodBodega As String = "", CodRubro As String = "", Iposicion = 0, Reintegro As Integer
        'Try


        If Me.CboCodigoProducto.Text = "" Then
            MsgBox("Se necesita el Codigo del Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.CboTipoProducto.Text = "" Then
            MsgBox("Se necesita el Tipo de Producto", MsgBoxStyle.Exclamation, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.CboActivo.Text = "" Then
            MsgBox("Se necesita un Estado para el Producto", MsgBoxStyle.Exclamation, "Sistema de Facturacion")
            Exit Sub
        End If

        If Me.CboExistencia.Text = "" Then
            MsgBox("Se necesita conocer si se permiten negativos", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TxtNombreProducto.Text = "" Then
            MsgBox(" Se necesita un nombre para el Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If





        SQLProductos = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProductos, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedores")
        If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Productos] SET [Descripcion_Producto] = '" & Me.TxtNombreProducto.Text & "',[Ubicacion] = '" & Me.TxtUbicacion.Text & "',[Tipo_Producto] = '" & Me.CboTipoProducto.Text & "',[Unidad_Medida] = '" & Me.CboUnidad.Text & "',[Precio_Venta] = '" & Me.TxtPrecioVentaA.Text & "',[Precio_Lista] = '" & Me.TxtPrecioVentaB.Text & "',[Descuento] = '" & Me.TxtDescuento.Text & "',[Existencia_Negativa] = '" & Me.CboExistencia.Text & "',[Activo] = '" & Me.CboActivo.Text & "' ,[Nota] = '" & Me.TxtNota.Text & "',[Cod_Cuenta_GastoAjuste]= '" & Me.TxtGastoAjuste.Text & "',[Cod_Cuenta_IngresoAjuste]= '" & Me.TxtIngresoAjuste.Text & "',[CodComponente]= " & CodComponente & ",[Cod_Rubro]= '" & CodRubro & "',[Reintegro]= " & Reintegro & "  WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Productos] ([Cod_Productos],[Descripcion_Producto],[Ubicacion],[Tipo_Producto],[Unidad_Medida],[Precio_Venta],[Precio_Lista],[Descuento],[Existencia_Negativa],[Activo],[Nota],[Cod_Cuenta_GastoAjuste],[Cod_Cuenta_IngresoAjuste],[CodComponente],[Cod_Rubro],[Reintegro]) " & _
                           "VALUES('" & Me.CboCodigoProducto.Text & "','" & Me.TxtNombreProducto.Text & "','" & Me.TxtUbicacion.Text & "','" & Me.CboTipoProducto.Text & "' ,'" & Me.CboUnidad.Text & "','" & Me.TxtPrecioVentaA.Text & "','" & Me.TxtPrecioVentaB.Text & "','" & Me.TxtDescuento.Text & "','" & Me.CboExistencia.Text & "','" & Me.CboActivo.Text & "','" & Me.TxtNota.Text & "','" & Me.TxtGastoAjuste.Text & "','" & Me.TxtIngresoAjuste.Text & "'," & CodComponente & ",'" & CodRubro & "'," & Reintegro & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery

        End If
        ActualizaComboProducto()
        Me.CboCodigoProducto.Text = ""

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

    End Sub

    Private Sub CboCodigoProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProducto.Click
        FrmTeclado.ShowDialog()
        CboCodigoProducto.Text = FrmTeclado.Numero
    End Sub



    Private Sub CboCodigoProducto_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProducto.TextChanged
        Dim CodigoProducto As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SQl As String
        Dim CodLinea As String, SqlLinea As String, CodImpuesto As String, SqlImpuesto As String, RutaOrigen As String
        Dim SqlString As String, Existencia As Double, iPosicionFila As Double, CodigoBodega As String
        Dim ExistenciaValores As Double, ExistenciaValoresDolar As Double, CodRubro As String, ExistenciaBodega As Double
        Dim StrSQLUpdate As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim iResultado As Integer

        If Me.CboCodigoProducto.Text = "" Then
            Me.TxtUbicacion.Text = ""
            'Me.TxtCtaInventario.Text = ""
            Me.TxtNombreProducto.Text = ""
            'Me.CboTipoProducto.Text = ""

            Me.CboUnidad.Text = ""
            Me.TxtDescuento.Text = ""
            Me.CboExistencia.Text = ""
            Me.TxtPrecioVentaA.Text = ""
            Me.CboActivo.Text = ""
            'Me.TxtCuentaVenta.Text = ""
            CodComponente = 0





            Exit Sub
        End If

        CodigoProducto = Me.CboCodigoProducto.Text

        SQl = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "') "
        MiConexion.Close()
        MiConexion.Open()
        DataAdapter = New SqlClient.SqlDataAdapter(SQl, MiConexion)
        DataAdapter.Fill(DataSet, "Producto")
        If Not DataSet.Tables("Producto").Rows.Count = 0 Then
            CodComponente = DataSet.Tables("Producto").Rows(0)("CodComponente")










            Me.TxtNombreProducto.Text = DataSet.Tables("Producto").Rows(0)("Descripcion_Producto")
            Me.CboTipoProducto.Text = DataSet.Tables("Producto").Rows(0)("Tipo_Producto")
            'Existencia = BuscaExistencia(CodigoProducto)
            'Me.TxtExistenciaUnidades.Text = Format(DataSet.Tables("Producto").Rows(0)("Existencia_Unidades"), "##,##0.00")
            'Me.TxtExistenciaValores.Text = Format(DataSet.Tables("Producto").Rows(0)("Existencia_Dinero"), "##,##0.00")
            ExistenciaValores = Math.Abs(Existencia * DataSet.Tables("Producto").Rows(0)("Costo_Promedio"))
            ExistenciaValoresDolar = Math.Abs(Existencia * DataSet.Tables("Producto").Rows(0)("Costo_Promedio_Dolar"))








            Me.CboUnidad.Text = DataSet.Tables("Producto").Rows(0)("Unidad_Medida")
            Me.TxtPrecioVentaB.Text = PrecioVenta(My.Forms.MDIParent1.IdLugarAcopio, 1, "B", Now)
            Me.TxtDescuento.Text = DataSet.Tables("Producto").Rows(0)("Descuento")
            'If DataSet.Tables("Producto").Rows(0)("Existencia_Negativa") = True Then

            'Else
            Me.CboExistencia.Text = DataSet.Tables("Producto").Rows(0)("Existencia_Negativa")
            'End If

            Me.TxtPrecioVentaA.Text = PrecioVenta(My.Forms.MDIParent1.IdLugarAcopio, 1, "A", Now)
            Me.TxtPrecioVentaC.Text = PrecioVenta(My.Forms.MDIParent1.IdLugarAcopio, 1, "C", Now)



            'If DataSet.Tables("Producto").Rows(0)("Activo") = True Then
            Me.CboActivo.Text = DataSet.Tables("Producto").Rows(0)("Activo")
            'Else
            '    Me.CboActivo.Text = "Inactivo"
            'End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Nota")) Then
                Me.TxtNota.Text = DataSet.Tables("Producto").Rows(0)("Nota")
            End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_GastoAjuste")) Then
                Me.TxtGastoAjuste.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_GastoAjuste")
            End If

            If Not IsDBNull(DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_IngresoAjuste")) Then
                Me.TxtIngresoAjuste.Text = DataSet.Tables("Producto").Rows(0)("Cod_Cuenta_IngresoAjuste")
            End If

            RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & Me.CboCodigoProducto.Text & ".bmp"
            If System.IO.File.Exists(RutaOrigen) = True Then
                Me.ImgFoto.ImageLocation = RutaOrigen
            End If
            MiConexion.Close()
        Else
            Me.TxtUbicacion.Text = ""

            Me.TxtNombreProducto.Text = ""
            Me.CboTipoProducto.Text = ""
            Me.CboUnidad.Text = ""
            Me.TxtDescuento.Text = ""
            Me.CboExistencia.Text = ""
            Me.TxtPrecioVentaA.Text = ""

            CodComponente = 0
        End If

        MiConexion.Close()
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Quien = "CodigoProductos"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProducto.Text = My.Forms.FrmConsultas.Codigo
        Me.CboTipoProducto.Text = My.Forms.FrmConsultas.TipoProducto
        Me.TxtNombreProducto.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Try


            Resultado = MsgBox("¿Esta Seguro de Eliminar el Producto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

            If Not Resultado = "6" Then
                Exit Sub
            End If




            SQLProveedor = "SELECT Productos.*  FROM Productos WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Columns(0).Text & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "Proveedores")
            If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


                StrSqlUpdate = "DELETE FROM [Productos] WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Columns(0).Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()


            End If

            SQLProveedor = "SELECT Productos.*  FROM Productos"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
            DataAdapter.Fill(DataSet, "ListaProductos")
            If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
                Me.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
            End If

            ActualizaComboProducto()
            Me.CboCodigoProducto.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CboLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdAddDocente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub cmdBorrarDocente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RutaOrigen As String, Resultado As Double
        Resultado = MsgBox("¿Esta Seguro de Eliminar la Foto?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        RutaOrigen = My.Application.Info.DirectoryPath & "\Fotos\" & Me.CboCodigoProducto.Text & ".bmp"
        If System.IO.File.Exists(RutaOrigen) = True Then
            System.IO.File.Delete(RutaOrigen)
            ImgFoto.ImageLocation = ""
            ImgFoto.Refresh()
        Else
            MsgBox("El archivo no Existe", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If
    End Sub

    Private Sub CmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RutaOrigen As String = "", RutaDestino As String
        Me.OpenFileDialog1.ShowDialog()
        RutaOrigen = Me.OpenFileDialog1.FileName.ToString()
        If RutaOrigen = "OpenFileDialog1" Then
            Exit Sub
        End If
        Me.ImgFoto.ImageLocation = RutaOrigen
        RutaDestino = My.Application.Info.DirectoryPath & "\Fotos\" & Me.CboCodigoProducto.Text & ".bmp"
        If System.IO.File.Exists(RutaDestino) = True Then
            System.IO.File.Delete(RutaDestino)
            System.IO.File.Copy(RutaOrigen, RutaDestino)
        Else
            System.IO.File.Copy(RutaOrigen, RutaDestino)
        End If
    End Sub

    Private Sub Button4_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdINgresoAjuste.Click
        Quien = "CuentaIngresoAjuste"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtIngresoAjuste.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub CmdGastosAjuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGastosAjuste.Click
        Quien = "CuentaGastoAjuste"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtGastoAjuste.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button4_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CodigoBodega As String, CodigoProducto As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, DatasetBodegas As New DataSet

        If Me.CboCodigoProducto.Text = "" Then
            MsgBox("Debe Seleccionar una Bodega", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        CodigoProducto = Me.CboCodigoProducto.Text



        SQL = "SELECT *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "MultiBodega")


        If DatasetBodegas.Tables("MultiBodega").Rows.Count = 0 Then
            MsgBox("Para Agregar una Bodega, es necesario que exista el Producto", MsgBoxStyle.Critical, "Sistema de Factuacion")
            DatasetBodegas.Tables("MultiBodega").Reset()
            Exit Sub
        Else
            DatasetBodegas.Tables("MultiBodega").Reset()
        End If

        Quien = "Bodegas"
        My.Forms.FrmConsultas.ShowDialog()
        CodigoBodega = My.Forms.FrmConsultas.Codigo

        SQL = "SELECT  *  FROM DetalleBodegas WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "Detalles")
        If Not DatasetBodegas.Tables("Detalles").Rows.Count = 0 Then
            '///////////SI EXISTE EL  LO ACTUALIZO////////////////
            MsgBox("Ya Existe esta Bodega relacionada al producto", MsgBoxStyle.Critical, "Sistema Facturacion")

        Else
            MiConexion.Close()
            If CodigoBodega = "-----0-----" Then
                Exit Sub
            End If

            If CodigoProducto <> "" Then
                '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                StrSqlUpdate = "INSERT INTO [DetalleBodegas] ([Cod_Bodegas],[Cod_Productos]) " & _
                               "VALUES('" & CodigoBodega & "','" & CodigoProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If

        End If

    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CodigoBodega As String, CodigoProducto As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, DatasetBodegas As New DataSet, ExistenciaBodega As Double

        Resultado = MsgBox("¿Esta Seguro de Eliminar el producto de la bodega?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        If Me.CboCodigoProducto.Text = "" Then
            MsgBox("Debe Seleccionar un Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        CodigoProducto = Me.CboCodigoProducto.Text


        SQL = "SELECT *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "MultiBodega")


        If DatasetBodegas.Tables("MultiBodega").Rows.Count = 0 Then
            MsgBox("Para Agregar un Producto, es necesario que exista la Bodega", MsgBoxStyle.Critical, "Sistema de Factuacion")
            DatasetBodegas.Tables("MultiBodega").Reset()
            Exit Sub
        Else
            DatasetBodegas.Tables("MultiBodega").Reset()
        End If






        SQL = "SELECT  *  FROM DetalleBodegas WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "Detalles")
        If Not DatasetBodegas.Tables("Detalles").Rows.Count = 0 Then
            '///////////SI EXISTE EL  LO ACTUALIZO////////////////

            ExistenciaBodega = DatasetBodegas.Tables("Detalles").Rows(0)("Existencia")

            If ExistenciaBodega <> 0 Then
                MsgBox("No se puede Eliminar una Bodega con Existencia", MsgBoxStyle.Critical, "Zeus Facturacion")
                Exit Sub
            End If

            MiConexion.Close()
            If CodigoProducto <> "" Then
                '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                StrSqlUpdate = "DELETE FROM [DetalleBodegas] WHERE(Cod_Bodegas = '" & CodigoBodega & "') AND (Cod_Productos = '" & CodigoProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If


        Else

            MsgBox("Ya Existe este Producto en la Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")
        End If

    End Sub


    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CodigoProducto As String, NombreProducto As String = "", SQLComponentes As String, SQLProductos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Dataset As New DataSet, Recuperable As Boolean = False


        Quien = "CodigoProductosComponente"
        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Codigo <> "-----0-----" Then
            CodigoProducto = My.Forms.FrmConsultas.Codigo
            NombreProducto = My.Forms.FrmConsultas.Descripcion
        Else
            CodigoProducto = ""
        End If


        If CodComponente = 0 Then
            '/////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////BUSCO EL CONSECUTIVO COMPONENTES/////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////

            SQLComponentes = "SELECT  * FROM  Consecutivos"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLComponentes, MiConexion)
            DataAdapter.Fill(Dataset, "ConsecutivoComponente")
            If Not Dataset.Tables("ConsecutivoComponente").Rows.Count = 0 Then
                CodComponente = Dataset.Tables("ConsecutivoComponente").Rows(0)("Componente") + 1

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////ACTUALIZO EL CONSECUTIVO///////////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SQLProductos = "UPDATE [Consecutivos]  SET [Componente] = " & CodComponente & ""
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SQLProductos, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If
        End If

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////Agrego el Componente al Producto///////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        SQLComponentes = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "') AND (Cod_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLComponentes, MiConexion)
        DataAdapter.Fill(Dataset, "Componentes")
        If Dataset.Tables("Componentes").Rows.Count = 0 Then
            MiConexion.Close()
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Componentes] ([Cod_Componente],[Cod_Producto],[Descripcion_Producto],[Requerido],[Recuperable] ,[Desecho]) " & _
                           "VALUES('" & CodComponente & "', '" & CodigoProducto & "', '" & NombreProducto & "',1,0,0.001)"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////ACTUALIZO EL PRODUCTO CON EL COMPONENTE///////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SQLProductos = "UPDATE [Productos] SET [CodComponente] = '" & CodComponente & "' WHERE (Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQLProductos, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()



        Else
            MsgBox("EL PRODUCTO YA EXISTE EN LA LISTA DE COMPONENTES", MsgBoxStyle.Critical, "Sistema de Facturacion")
        End If



    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CodigoProducto As String, SQL As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, DatasetBodegas As New DataSet

        Resultado = MsgBox("¿Esta Seguro de Eliminar el producto de la Lista de Componentes?", MsgBoxStyle.YesNo, "Sistema de Facturacion")

        If Not Resultado = "6" Then
            Exit Sub
        End If

        If Me.CboCodigoProducto.Text = "" Then
            MsgBox("Debe Seleccionar un Producto", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If




        SQL = "SELECT *  FROM Productos WHERE (Cod_Productos = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "Componentes")


        If DatasetBodegas.Tables("Componentes").Rows.Count = 0 Then
            MsgBox("Para Eliminar el Componente debe existir el producto", MsgBoxStyle.Critical, "Sistema de Factuacion")
            DatasetBodegas.Tables("Componentes").Reset()
            Exit Sub
        Else
            DatasetBodegas.Tables("Componentes").Reset()
        End If


        'CodComponente = Me.TrueDBGridConsultas.Columns(0).Text

        SQL = "SELECT *  FROM Componentes WHERE (Cod_Componente = '" & CodComponente & "') AND (Cod_Producto = '" & CodigoProducto & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DatasetBodegas, "Detalles")
        If Not DatasetBodegas.Tables("Detalles").Rows.Count = 0 Then
            '///////////SI EXISTE EL  LO ACTUALIZO////////////////
            MiConexion.Close()
            If CodigoProducto <> "" Then
                '/////////SI NO EXISTE LO AGREGO COiMO NUEVO/////////////////
                StrSqlUpdate = "DELETE FROM [Componentes]    WHERE (Cod_Componente = '" & CodComponente & "') AND (Cod_Producto = '" & CodigoProducto & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If


        Else

            MsgBox("Ya Existe este Producto en la Bodega", MsgBoxStyle.Critical, "Sistema Facturacion")
        End If



    End Sub

    Private Sub Componentes_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub TxtPrecioVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdAddDocente_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CodigoImpuestos As String, DescripcionImpuesto As String, TasaImpuesto As Double, TipoImpuesto As String
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        Quien = "CodigoImpuestos"
        My.Forms.FrmConsultas.ShowDialog()
        CodigoImpuestos = My.Forms.FrmConsultas.Codigo
        DescripcionImpuesto = My.Forms.FrmConsultas.DescripcionImpuestos
        TasaImpuesto = My.Forms.FrmConsultas.TasaImpuestos
        TipoImpuesto = My.Forms.FrmConsultas.TipoImpuesto

        SqlString = "SELECT  Cod_Iva, Cod_Productos FROM ImpuestosProductos WHERE  (Cod_Iva = '" & CodigoImpuestos & "') AND (Cod_Productos = '" & Me.CboCodigoProducto.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Impuestos")
        If DataSet.Tables("Impuestos").Rows.Count <> 0 Then
            MsgBox("Este impuesto ya fue asignado para este producto", MsgBoxStyle.Critical, "Zeus Facturacion")
            Exit Sub
        Else
            StrSqlUpdate = "INSERT INTO [ImpuestosProductos] ([Cod_Iva],[Cod_Productos]) " & _
                        "VALUES ('" & CodigoImpuestos & "' ,'" & Me.CboCodigoProducto.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If







    End Sub

    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SqlString As String, CodigoImpuestos As String, Respuesta As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        Respuesta = MsgBox("Desea quitar el impuesto del producto?", MsgBoxStyle.YesNo, "Zeus Facturacion")
        If Respuesta <> 6 Then
            Exit Sub
        End If

        StrSqlUpdate = "DELETE FROM [ImpuestosProductos] WHERE (Cod_Iva='" & CodigoImpuestos & "') and (Cod_Productos='" & Me.CboCodigoProducto.Text & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()


    End Sub

    Private Sub TxtNombreProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombreProducto.TextChanged
        Me.TxtNombreProducto.Text = Replace(Me.TxtNombreProducto.Text, "'", "")
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FrmTeclado.ShowDialog()
        CboCodigoProducto.Text = FrmTeclado.Numero
    End Sub
End Class
