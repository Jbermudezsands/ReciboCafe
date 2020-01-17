Imports Excel = Microsoft.Office.Interop
Imports System.Drawing.Printing
Imports System.IO
Imports System.Collections

Module Funciones

    Public Function Establecer_Impresora(ByVal NamePrinter As String) As Boolean
        On Error GoTo errSub

        'Variable de referencia  
        Dim obj_Impresora As Object

        'Creamos la referencia  
        obj_Impresora = CreateObject("WScript.Network")
        obj_Impresora.setdefaultprinter(NamePrinter)

        obj_Impresora = Nothing

        'La función devuelve true y se cambió con éxito  
        Establecer_Impresora = True
        'MsgBox("La impresora se cambió correctamente", vbInformation)
        Exit Function


        'Error al cambiar la impresora  
errSub:
        If Err.Number = 0 Then Exit Function
        Establecer_Impresora = False
        MsgBox("error: " & Err.Number & Chr(13) & "Description: " & Err.Description)
        On Error GoTo 0
    End Function

    Public Function BuscaImpresora(ByVal Modulo As String) As String
        Dim sLine As String = "", Ruta As String
        Dim arrText As New ArrayList(), CadenaDiv() As String, Max As Double
        Dim ModuloArchivo As String, RutaTemp As String
        Dim RutaBD As String = My.Application.Info.DirectoryPath & "\Impresoras.dll", ConexionImpresora As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & RutaBD & " "
        Dim DataSet As New DataSet

        Dim SqlString As String = "SELECT  Impresoras.*  FROM Impresoras WHERE (((Impresoras.TipoImpresora)='" & Modulo & "'))"
        Dim MiConexionImpresora As New OleDb.OleDbConnection(ConexionImpresora)
        Dim DataAdapterImpresora As New OleDb.OleDbDataAdapter(SqlString, MiConexionImpresora)


        MiConexionImpresora.Open()
        DataAdapterImpresora.Fill(DataSet, "Impresoras")
        MiConexionImpresora.Close()


        If DataSet.Tables("Impresoras").Rows.Count <> 0 Then
            BuscaImpresora = DataSet.Tables("Impresoras").Rows(0)("Impresora")
        Else
            BuscaImpresora = "Ninguno"
        End If






        'Ruta = My.Application.Info.DirectoryPath & "\Impresoras.txt"
        'If Dir(Ruta) <> "" Then
        '    Dim objReader As New StreamReader(Ruta)

        '    Do
        '        sLine = objReader.ReadLine()
        '        If Not sLine Is Nothing Then
        '            arrText.Add(sLine)

        '            CadenaDiv = sLine.Split(">")
        '            Max = UBound(CadenaDiv)

        '            If Max >= 1 Then
        '                ModuloArchivo = CadenaDiv(0)
        '                If ModuloArchivo = Modulo Then
        '                    BuscaImpresora = CadenaDiv(1)
        '                    Exit Function
        '                End If
        '            End If

        '        End If
        '    Loop Until sLine Is Nothing
        '    objReader.Close()
        'Else

        '    '//////////////////////////SI NO EXISTE CREO EL ARCHIVO ///////////////////////
        '    'RutaTemp = My.Application.Info.DirectoryPath & "\ImpresorasTmp.txt"
        '    Dim sw As New System.IO.StreamWriter(Ruta)
        '    sw.WriteLine("Remision>HpTemp")
        '    sw.WriteLine("Tickets>HpTemp")
        '    sw.Close()

        '    'MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Impresoras")
        'End If



    End Function
    Public Function GuardaImpresora(ByVal Modulo As String, ByVal Impresora As String) As String
        Dim sLine As String = "", Ruta As String, RutaTemp As String, RutaOld As String
        Dim arrText As New ArrayList(), CadenaDiv() As String, Max As Double
        Dim ModuloArchivo As String, StrSqlUpdate As String



        Dim SqlString As String = "SELECT  Impresoras.*  FROM Impresoras WHERE (((Impresoras.TipoImpresora)='" & Modulo & "'))"
        Dim MiConexionImpresora As New OleDb.OleDbConnection(My.Forms.FrmImpresoras.ConexionImpresora)
        Dim DataAdapterImpresora As New OleDb.OleDbDataAdapter(SqlString, MiConexionImpresora), DataSet As New DataSet
        Dim ComandoUpdate As New OleDb.OleDbCommand, iResultado As Integer

        MiConexionImpresora.Open()
        DataAdapterImpresora.Fill(DataSet, "Impresoras")
        MiConexionImpresora.Close()


        If DataSet.Tables("Impresoras").Rows.Count <> 0 Then
            MiConexionImpresora.Open()
            StrSqlUpdate = "UPDATE [Impresoras] SET [Impresora] = '" & Impresora & "' WHERE (((Impresoras.TipoImpresora)='" & Modulo & "'))"
            ComandoUpdate = New OleDb.OleDbCommand(StrSqlUpdate, MiConexionImpresora)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexionImpresora.Close()
        End If






        'Ruta = My.Application.Info.DirectoryPath & "\Impresoras.txt"
        'RutaTemp = My.Application.Info.DirectoryPath & "\ImpresorasTmp.txt"
        'RutaOld = My.Application.Info.DirectoryPath & "\ImpresorasOld.txt"



        'If Dir(Ruta) <> "" Then
        '    File.Copy(Ruta, RutaOld, True)

        '    Dim objReader As New StreamReader(RutaOld)
        '    Dim sw As New System.IO.StreamWriter(RutaTemp)


        '    Do


        '        sLine = objReader.ReadLine()


        '        If Not sLine Is Nothing Then
        '            arrText.Add(sLine)

        '            CadenaDiv = sLine.Split(">")
        '            Max = UBound(CadenaDiv)

        '            If Max >= 1 Then
        '                ModuloArchivo = CadenaDiv(0)
        '                If ModuloArchivo = Modulo Then
        '                    CadenaDiv(1) = Impresora
        '                End If
        '            End If


        '            sw.WriteLine(String.Join(">", CadenaDiv))

        '        End If
        '    Loop Until sLine Is Nothing

        '    objReader.Close()
        '    sw.Close()


        '    'File.Delete(Ruta)
        '    'File.Move(RutaTemp, Ruta)
        '    File.Copy(RutaTemp, Ruta, True)


        'Else
        '    MsgBox("No Existe el Archivo Impresoras", MsgBoxStyle.Critical, "Impresoras")
        'End If

    End Function




    Public Sub ActualizaDetalleRemision(ByVal ConsecutivoRemision As String, ByVal TipoRemision As String, ByVal Calidad As String, ByVal EstadoFisico As String, ByVal TipoPesada As String)

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sql As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Fecha As String

        Fecha = Format(CDate(FrmBascula.DTPFecha.Text), "yyyy-MM-dd")

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Pesadas  " & _
              "WHERE  (NumeroRemision = '" & ConsecutivoRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & TipoRemision & "') AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "') AND (TipoPesada = '" & TipoPesada & "')"

        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        My.Forms.FrmBascula.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
        My.Forms.FrmBascula.TrueDBGridComponentes.DataSource = My.Forms.FrmBascula.BindingDetalle
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        My.Forms.FrmBascula.TrueDBGridComponentes.Columns(0).Caption = "Psda"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        My.Forms.FrmBascula.TrueDBGridComponentes.Columns(1).Caption = "Código"
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        My.Forms.FrmBascula.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        My.Forms.FrmBascula.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        My.Forms.FrmBascula.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        My.Forms.FrmBascula.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        My.Forms.FrmBascula.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75
    End Sub

    Public Function BuscaLineaRemision(ByVal NumeroRemision As String, ByVal FechaRemision As Date, ByVal TipoRemision As String, ByVal Calidad As String, ByVal EstadoFisico As String, ByVal TipoPesada As String) As Double
        Dim Sql As String, Fecha As Date
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim MiConexion As New SqlClient.SqlConnection(Conexion), Registros As Double, i As Double, j As Double
        Dim iResultado As Integer, SqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, Linea As Double = 0

        Fecha = Format(FechaRemision, "yyyy-MM-dd")

        Sql = "SELECT  Detalle_Pesadas.* FROM Detalle_Pesadas WHERE (NumeroRemision = '" & NumeroRemision & "')  AND (TipoRemision = '" & TipoRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FechaRemision, "yyyy-MM-dd") & "', 102)) AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "') AND (TipoPesada = '" & TipoPesada & "')"
        'Sql = "SELECT id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, Liquidado,  Codigo_BeamsOrigen, RecepcionBin, Transferido, Calidad, Estado, Precio, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ, Calidad_Cafe FROM Detalle_Recepcion " & _
        '      "WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = '" & TipoRecepcion & "') AND (Fecha = CONVERT(DATETIME,  '" & Format(Fecha, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRemision")
        Registros = DataSet.Tables("DetalleRemision").Rows.Count
        i = 0
        j = 1
        Do While Registros > i
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL DETALLE DE COMPRAS///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            Linea = DataSet.Tables("DetalleRemision").Rows(i)("id_Eventos")
            SqlUpdate = "UPDATE [Detalle_Pesadas]  SET [id_Eventos] = " & j & " " & _
                        "WHERE (NumeroRemision = '" & NumeroRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FechaRemision, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & TipoRemision & "') AND (id_Eventos = " & Linea & ") AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "') AND (TipoPesada = '" & TipoPesada & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            i = i + 1
            j = j + 1
        Loop
        BuscaLineaRemision = j

    End Function
    Public Function BuscaConsecutivoRemisionManual(ByVal Serie As String, ByVal IdTipoCafe As Double, ByVal IdCosecha As Double, ByVal IdLocalidad As Double, ByVal NumeroRecibo As String) As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Sqlstring As String
        Dim DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim Consecutivo As Double

        If Serie = "" Then
            'Sqlstring = "SELECT   IdLiquidacionPergamino, Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso, IdTipoIngreso, IdCosecha,    IdLocalidad, Cod_Proveedor, IdTipoCompra, PrecioAutoriza, TotalDeducciones, ChkRentDef, ChkRent2, ChkRent3, ChkMuncipal, IdTipoCambio, Serie  FROM        LiquidacionPergamino " & _
            '             "WHERE (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ")  AND (LEN(Codigo) <= 6) AND (Serie = '?')  AND (Codigo = '" & NumeroRecibo & "') ORDER BY Codigo DESC"
            Sqlstring = "SELECT        RemisionPergamino.* FROM RemisionPergamino " & _
                        "WHERE (LEN(Codigo) <= 6) AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLocalidad & ") AND (IdTipoIngreso = 2) AND (IdCosecha = " & IdCosecha & ") AND (Codigo =  '" & NumeroRecibo & "')"
        Else
            'Sqlstring = "SELECT  IdLiquidacionPergamino, Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso, IdTipoIngreso, IdCosecha,    IdLocalidad, Cod_Proveedor, IdTipoCompra, PrecioAutoriza, TotalDeducciones, ChkRentDef, ChkRent2, ChkRent3, ChkMuncipal, IdTipoCambio, Serie  FROM        LiquidacionPergamino " & _
            '                        "WHERE (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ")   AND (LEN(Codigo) <= 6)AND (Serie = '" & Serie & "') AND (Codigo = '" & NumeroRecibo & "') ORDER BY Codigo DESC"

            Sqlstring = "SELECT        RemisionPergamino.* FROM RemisionPergamino " & _
                        "WHERE (LEN(Codigo) <= 6) AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLocalidad & ") AND (IdTipoIngreso = 2) AND (IdCosecha = " & IdCosecha & ") AND (Codigo =  '" & NumeroRecibo & "')"

        End If
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "Serie")
        If DataSet.Tables("Serie").Rows.Count <> 0 Then
            Consecutivo = DataSet.Tables("Serie").Rows(0)("Codigo")
            BuscaConsecutivoRemisionManual = Format(Consecutivo + 1, "00000#")
        Else
            BuscaConsecutivoRemisionManual = "000000"
        End If

    End Function

    Public Sub GrabaLecturaPesoRemision(ByVal Peso As Double)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)

        Dim ConsecutivoCompra As Double, NumeroRemision As String, Registros As Double, Iposicion As Double
        Dim Linea As Double, CodigoProducto As String, Cantidad As Double, Descripcion As String, CodigoBeams As String, UnidadMedida As String = ""
        Dim CodigoBeamsOrigen As String = "", CodigoRecepcionBin As String = "", Calidad As String, Estado As String, SqlString As String
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, PesoKg As Double, Precio As Double, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Tara As Double = 0, PesoNetoLb As Double = 0, PesoNetoKg As Double = 0, QQ As Double = 0, LugarAcopio As Integer, SubTotal As Double = 0
        Dim HumedadxDefecto As Double = 0, HumedadReal As Double = 0, Consecutivo As Double, NumeroRecibo As String, Cadena As String, CadenaDiv() As String
        Dim CodLugarAcopio As Double, IdCategoria As Double, IdRemision As Double


        'SqlString = "SELECT  LugarAcopio.* FROM LugarAcopio WHERE  (IdLugarAcopio = " & FrmBasculan.IdLugarAcopio & " ) AND (Activo = 1)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "ConsultaLugarAcopio")
        'If DataSet.Tables("ConsultaLugarAcopio").Rows.Count <> 0 Then
        '    CodLugarAcopio = DataSet.Tables("ConsultaLugarAcopio").Rows(0)("CodLugarAcopio")
        'Else
        '    CodLugarAcopio = FrmBasculan.TxtIdLocalidad.Text
        'End If



        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'If FrmBasculan.TxtNumeroEnsamble.Text = "-----0-----" Then
        '    Select Case FrmBasculan.CboTipoRecepcion.Text
        '        Case "Recepcion"
        '            ConsecutivoCompra = BuscaConsecutivo("Recepcion", CodLugarAcopio)

        '        Case "RePesaje"
        '            ConsecutivoCompra = BuscaConsecutivo("ReImprime", CodLugarAcopio)
        '        Case "Lote"
        '            ConsecutivoCompra = BuscaConsecutivo("Lote", CodLugarAcopio)
        '    End Select

        '    NumeroRecepcion = CodLugarAcopio & "-" & Format(ConsecutivoCompra, "00000#")
        'Else
        '    NumeroRecepcion = FrmBasculan.TxtNumeroEnsamble.Text
        'End If




        ''////////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////////BUSCO EL CONSECUTIVO DEL RECIBO ///////////////////////////////////////
        ''/////////////////////////////////////////////////////////////////////////////////////////////////////////
        'If FrmBasculan.TxtNumeroRecibo.Text = "-----0-----" Then
        '    SqlString = "SELECT Codigo FROM ReciboCafePergamino WHERE (IdCosecha = " & FrmBasculan.IdCosecha & ") AND (IdLocalidad = " & FrmBasculan.IdLugarAcopio & ") AND (IdTipoCompra = " & FrmBasculan.IdTipoCompra & ") AND (IdTipoCafe = " & FrmBasculan.IdTipoCafe & ")  AND (LEN(Codigo) > 6) AND (Codigo LIKE '%" & CodLugarAcopio & "%') ORDER BY Codigo DESC"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "NumeroRecibo")
        '    If DataSet.Tables("NumeroRecibo").Rows.Count <> 0 Then
        '        Cadena = DataSet.Tables("NumeroRecibo").Rows(0)("Codigo")
        '        If Len(Cadena) >= 6 Then
        '            CadenaDiv = Cadena.Split("-")
        '            Consecutivo = CadenaDiv(1)
        '            Consecutivo = Consecutivo + 1
        '        End If
        '    Else
        '        Consecutivo = 1
        '    End If

        '    NumeroRecibo = Format(Consecutivo, "00000#")
        '    FrmBasculan.TxtNumeroRecibo.Text = NumeroRecibo

        'Else
        '    NumeroRecibo = FrmBasculan.TxtNumeroRecibo.Text
        'End If


        ''////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////GRABO ENCABEZADO DE RECEPCION /////////////////////////////////////////////
        ''//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        'GrabaRecepcion(NumeroRecepcion)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA RECEPCION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////


        NumeroRemision = FrmBascula.TxtNumeroRemision.Text
        Registros = FrmBascula.BindingDetalle.Count
        Iposicion = FrmBascula.BindingDetalle.Position
        If My.Forms.FrmBascula.TrueDBGridComponentes.Columns(0).Text = "" Then
            Linea = BuscaLineaRemision(NumeroRemision, CDate(My.Forms.FrmBascula.DTPFecha.Text), My.Forms.FrmBascula.TxtTipoRemision.Text, FrmBascula.Calidad, FrmBascula.EstadoFisico, FrmBascula.TipoPesada)
        Else
            Linea = FrmBascula.TrueDBGridComponentes.Columns(0).Text
        End If

        CodigoProducto = FrmBascula.CboIngresoBascula.Columns(0).Text
        Cantidad = Peso
        Descripcion = FrmBascula.CboIngresoBascula.Columns(1).Text

        'If FrmBasculan.CboCategoria.Text <> "" Then
        '    Calidad = FrmBasculan.CboCategoria.Text
        'End If

        'If FrmBasculan.OptMojado.Checked = True Then
        '    Estado = "Mojado"
        'ElseIf FrmBasculan.OptHumedo.Checked = True Then
        '    Estado = "Humedo"
        'ElseIf FrmBasculan.OptOreado.Checked = True Then
        '    Estado = "Oreado"
        'End If

        'Estado = FrmBasculan.CboEstado.Text


        '/////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////CONSULTO EL PRECIO DE VENTA //////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT  Productos.* FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        'DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapterProductos.Fill(DataSet, "Precios")
        'If Not DataSet.Tables("Precios").Rows.Count = 0 Then
        '    Select Case FrmBasculan.CboTipoProducto.Text
        '        Case "A" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Venta")
        '        Case "B" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Lista")
        '        Case "C" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Compra")
        '    End Select

        'End If

        'Precio = PrecioVenta(CodigoProducto, FrmBasculan.IdLugarAcopio, FrmBasculan.CboCategoria.Text, CDate(FrmRecepcion.DTPFecha.Text))
        'Precio = PrecioVenta(FrmRecepcion.IdLugarAcopio, FrmRecepcion.IdCalidad, FrmRecepcion.CboCategoria.Text)
        Precio = 0

        '-------------------------------PREGUNTO LOS QUINTALES -----------------------------
        '--------------------------------------------------------------------------------------
        My.Forms.FrmQQ.ShowDialog()
        QQ = My.Forms.FrmQQ.QQ

        '///////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////CONVERTIR DE LIBRAS A KG //////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////
        PesoKg = Cantidad
        Cantidad = Format((Cantidad / 46) * 100, "##,##0.00")

        Dim Factor As Double = 0, IdEsdoFisico As Double = 0, IdCalidad As Double = 0, IdTipoLugarAcopio As Double = 0

        '////////////////////////////////////BUSCO EL ESTADO FISICO ///////////////////////////////////////////////////


        IdEsdoFisico = My.Forms.FrmBascula.IdEstadoFisico
        IdCalidad = My.Forms.FrmBascula.IdCalidad
        IdTipoLugarAcopio = My.Forms.FrmBascula.IdTipoLugarAcopio
        Calidad = My.Forms.FrmBascula.Calidad
        Estado = My.Forms.FrmBascula.EstadoFisico
        IdRemision = My.Forms.FrmBascula.IdRemisionPergamino


        '//////////////////////////////ESTA OPCION SOLO CALCULA TARA PARA EL DETALLE DE REMISION ////////////////////////////
        '//////////////////////////////LAS ENTRADAS Y SALIDAS NO LLEVAN TARA ///////////////////////////////////////////////

        If FrmBascula.TipoPesada = "DetalleRemision" & FrmBascula.Posicion Then
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////CONSULTO LAS TARAS /////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT FactorTara FROM FactorSaco WHERE  (IdEdoFisico = " & IdEsdoFisico & " )  AND (IdTipoLugarAcopio = " & IdTipoLugarAcopio & ") AND (IdUMedida = 1) AND (IdCalidad = " & IdCalidad & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Tara")
            If DataSet.Tables("Tara").Rows.Count <> 0 Then
                Factor = DataSet.Tables("Tara").Rows(0)("FactorTara")
            Else
                Factor = 0
            End If

            Tara = Factor * QQ
        Else
            Tara = 0
        End If





        'If FrmRecepcion.CboTipoCalidad.Text = "AP1ra" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "AP2da" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "BROZA" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "FRUTO" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "PULPON" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "MP1ra" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'End If

        PesoNetoKg = Format((PesoKg - Tara), "##,##0.0000")
        PesoNetoLb = Format((PesoNetoKg / 46) * 100, "##,##0.0000")

        GrabaDetalleRemision(NumeroRemision, CodigoProducto, Cantidad, Linea, Descripcion, Calidad, Estado, Precio, PesoKg, FrmBascula.TxtTipoRemision.Text, Tara, PesoNetoKg, QQ, FrmBascula.Calidad, FrmBascula.TipoPesada, FrmBascula.DTPRemFechCarga.Value, IdRemision)
        ActualizaDetalleRemision(NumeroRemision, FrmBascula.TxtTipoRemision.Text, FrmBascula.Calidad, FrmBascula.EstadoFisico, FrmBascula.TipoPesada)


        FrmBascula.TrueDBGridComponentes.Columns(1).Text = CodigoProducto
        FrmBascula.TrueDBGridComponentes.Columns(2).Text = Descripcion
        FrmBascula.TrueDBGridComponentes.Columns(3).Text = Calidad
        FrmBascula.TrueDBGridComponentes.Columns(4).Text = Estado
        FrmBascula.TrueDBGridComponentes.Columns(5).Text = Cantidad
        FrmBascula.TrueDBGridComponentes.Columns(6).Text = PesoKg
        FrmBascula.TrueDBGridComponentes.Columns(7).Text = Tara
        FrmBascula.TrueDBGridComponentes.Columns(8).Text = PesoNetoLb
        FrmBascula.TrueDBGridComponentes.Columns(9).Text = PesoNetoKg
        FrmBascula.TrueDBGridComponentes.Columns(10).Text = QQ
        FrmBascula.TrueDBGridComponentes.Columns(11).Text = Format(Precio / 46, "##,##0.00")
        FrmBascula.TrueDBGridComponentes.Columns(0).Text = Linea
        FrmBascula.TxtNumeroRemision.Text = NumeroRemision

        Iposicion = FrmBascula.TrueDBGridComponentes.Row
        FrmBascula.TrueDBGridComponentes.Row = FrmBascula.TrueDBGridComponentes.Row + 1
        FrmBascula.TrueDBGridComponentes.Columns(1).Text = CodigoProducto
        FrmBascula.TrueDBGridComponentes.Columns(2).Text = Descripcion
        FrmBascula.TrueDBGridComponentes.Col = 5


        FrmBascula.txtsubtotal.Text = TotalRecepcion(FrmBascula.TxtNumeroRemision.Text, FrmBascula.DTPFecha.Text, FrmBascula.TxtTipoRemision.Text)


        ''////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        'SqlString = "SELECT  EstadoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto  FROM EstadoFisico WHERE (Descripcion = '" & FrmBascula.CboEstado.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        '    HumedadxDefecto = DataSet.Tables("Consulta").Rows(0)("HumedadXDefecto")
        'End If

        SubTotal = FrmBascula.txtsubtotal.Text

        'FrmBascula.TxtEqOreado.Text = Format(SubTotal * (1 - (HumedadxDefecto - 42) / 100), "##,##0.00")
        'FrmBascula.TxtOreadoReal.Text = Format(SubTotal * (1 - (HumedadReal - 42) / 100), "##,##0.00")




    End Sub

    Public Sub GrabaDetalleRemision(ByVal ConsecutivoRemision As String, ByVal CodigoProducto As String, ByVal Cantidad As Double, ByVal Linea As Double, ByVal Descripcion As String, ByVal Calidad As String, ByVal Estado As String, ByVal Precio As Double, ByVal PesoKg As Double, ByVal TipoRemision As String, ByVal Tara As Double, ByVal PesoNetoKg As Double, ByVal QQ As Double, ByVal CalidadCafe As String, ByVal TipoPesada As String, ByVal FechaCarga As Date, ByVal IdRemision As Double)
        Dim Sqldetalle As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, MiConexion As New SqlClient.SqlConnection(Conexion), SqlUpdate As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, PesoNetoLb As Double


        PesoNetoLb = Format((PesoNetoKg / 46) * 100, "##,##0.0000")

        ''If FrmRecepcion.CboTipoDocumento.Text = "Recibo Bascula Manual" Then
        ''    Fecha = Format(CDate(FrmRecepcion.DtpFechaManual.Text), "yyyy-MM-dd")
        ''Else
        Fecha = Format(CDate(FrmBascula.DTPFecha.Text), "yyyy-MM-dd")
        'End If


        Sqldetalle = "SELECT Detalle_Pesadas.* FROM Detalle_Pesadas " & _
                     "WHERE (IdRemisionPergamino = " & IdRemision & ") AND (id_Eventos = " & Linea & ") AND (NumeroRemision = '" & ConsecutivoRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & TipoRemision & "')  AND (TipoPesada = '" & TipoPesada & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldetalle, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        If Not DataSet.Tables("DetalleRecepcion").Rows.Count = 0 Then
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL DETALLE DE COMPRAS///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlUpdate = "UPDATE [Detalle_Pesadas] SET [Cod_Productos] = '" & CodigoProducto & "',[Descripcion_Producto] = '" & Descripcion & "',[Cantidad] = " & Cantidad & ",[PesoKg] = " & PesoKg & ", [Calidad] = '" & Calidad & "', [Estado] = '" & Estado & "', [Precio] = " & Precio & ", [Tara] = " & Tara & ", [PesoNetoLb] = " & PesoNetoLb & ", [PesoNetoKg] = " & PesoNetoKg & " , [QQ] = " & QQ & ", [Calidad_Cafe] = '" & CalidadCafe & "', [FechaCarga] = CONVERT(DATETIME, '" & Format(CDate(FechaCarga), "yyyy-MM-dd HH:mm:ss") & "', 102) " & _
                        "WHERE (id_Eventos = " & Linea & ") AND (NumeroRemision = '" & ConsecutivoRemision & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & TipoRemision & "') AND (TipoPesada = '" & TipoPesada & "') "  'AND (Cod_Productos = '" & CodigoProducto & "')
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else

            SqlUpdate = "INSERT INTO [Detalle_Pesadas] ([id_Eventos],[NumeroRemision],[Fecha],[TipoRemision],[Cod_Productos],[Descripcion_Producto],[Cantidad],[PesoKg],[Calidad],[Estado],[Precio],[Tara],[PesoNetoLb],[PesoNetoKg],[QQ],[Calidad_Cafe],[TipoPesada],[FechaCarga],[IdRemisionPergamino]) " & _
                        "VALUES (" & Linea & " ,'" & ConsecutivoRemision & "',CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102) ,'" & My.Forms.FrmBascula.TxtTipoRemision.Text & "','" & CodigoProducto & "','" & Descripcion & "'," & Cantidad & "," & PesoKg & ", '" & Calidad & "','" & Estado & "', " & Precio & ", " & Tara & ", " & PesoNetoLb & ", " & PesoNetoKg & ", " & QQ & ", '" & CalidadCafe & "', '" & TipoPesada & "', CONVERT(DATETIME, '" & Format(CDate(FechaCarga), "yyyy-MM-dd HH:mm:ss") & "', 102), " & IdRemision & ") "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        '  '" & Format(CDate(Fecha), "dd/MM/yyyy") & "'
    End Sub


    Public Sub CreaCortePrecios(ByVal IdLocalidad As Double, ByVal FechaCorte As Date)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Sqlstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaAnterior As Date, i As Double, RegCat As Double, idCategoria As Double, RegCalidad As Double, j As Double, idCalidad As Double
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Precio As Double, FechaActualizacion As Date


        FechaAnterior = FechaCorte.AddDays(-1)

        'WHERE    (IdLocalidad = '" & IdLocalidad & "') AND (IdCalidad = " & idCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY FechaActualizacion DESC"

        '///////////////////////////////////RECORRO TODAAS LAS CATEGORIAS ////////////////////////////////////////////////////////////
        Sqlstring = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion FROM RangoImperfeccion   WHERE(IdCosecha = " & CodigoCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "Categoria")
        RegCat = DataSet.Tables("Categoria").Rows.Count
        i = 0

        Do While RegCat > i

            idCategoria = DataSet.Tables("Categoria").Rows(i)("IdRangoImperfeccion")

            '/////////////////////////////////////////RECORRO TODAS LAS CALIDADES ////////////////////////////////////////////////////
            Sqlstring = "SELECT RelacionTipoDocumentoxCalidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN TipoCafe ON RelacionTipoDocumentoxCalidad.IdtipoDocumento = TipoCafe.IdTipoCafe INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad WHERE( RelacionTipoDocumentoxCalidad.IdtipoDocumento = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
            DataAdapter.Fill(DataSet, "Calidad")
            RegCalidad = DataSet.Tables("Calidad").Rows.Count

            j = 0

            Do While RegCalidad > j

                idCalidad = DataSet.Tables("Calidad").Rows(j)("IdCalidad")

                '//////////////////////////////////////////////////////////////////////////////
                '/////////////VERIFICO SI EXISTE UN CORTE EN LA TABLA DE PRECIOS DE COMPLEMENTOS //////////
                '///////////////////////////////////////////////////////////////////////////////////////
                Sqlstring = "SELECT   IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, FechaActualizacion  FROM  PrecioComplemento   WHERE    (IdLocalidad = '" & IdLocalidad & "') AND (IdCalidad = " & idCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY FechaActualizacion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                DataAdapter.Fill(DataSet, "PrecioComplemento")
                If DataSet.Tables("PrecioComplemento").Rows.Count = 0 Then
                    '////////////////////////////////SI NO EXISTE PRECIO COMPLEMENTO AGREGO UN NUEVO PRECIO SEGUN EL ULTIMO PRECIO BASE /////////////////
                    Sqlstring = "SELECT   IdPrecioCafe, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, FechaActualizacion  FROM  PrecioCafe   WHERE    (IdLocalidad = '" & IdLocalidad & "')  AND (IdCalidad = " & idCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaAnterior, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaAnterior, "yyyy-MM-dd") & " 23:59:59', 102)) ORDER BY FechaActualizacion DESC"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "PrecioCafe")
                    If DataSet.Tables("PrecioCafe").Rows.Count <> 0 Then

                        Precio = DataSet.Tables("PrecioCafe").Rows(0)("Precio")
                        Sqlstring = "INSERT INTO [dbo].[PrecioComplemento]  ([IdCosecha],[IdLocalidad],[IdCalidad],[IdRangoImperfeccion],[Precio],[Corte] ,[FechaActualizacion])  VALUES ( '" & CDbl(CodigoCosecha) & "','" & IdLocalidad & "','" & idCalidad & "','" & idCategoria & "','" & Precio & "','1','" & Format(CDate(FechaCorte), "dd/MM/yyyy 05:00:00") & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(Sqlstring, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                        'Sqlstring = "INSERT INTO [dbo].[PrecioCafe] ([IdLocalidad],[IdCalidad],[IdRangoImperfeccion],[Precio],[Corte],[FechaActualizacion])  VALUES ('" & IdLocalidad & "','" & idCalidad & "','" & idCategoria & "','" & Precio & "','1','" & Format(CDate(FechaCorte), "dd/MM/yyyy 05:00:00") & "')"
                        'MiConexion.Open()
                        'ComandoUpdate = New SqlClient.SqlCommand(Sqlstring, MiConexion)
                        'iResultado = ComandoUpdate.ExecuteNonQuery
                        'MiConexion.Close()

                    End If
                    DataSet.Tables("PrecioCafe").Reset()

                End If

                DataSet.Tables("PrecioComplemento").Reset()


                j = j + 1
            Loop

            i = i + 1
        Loop


    End Sub

    Public Function BuscaConsecutivoLiquidacionManual(ByVal Serie As String, ByVal IdTipoCafe As Double, ByVal IdCosecha As Double, ByVal IdLocalidad As Double, ByVal IdTipoCompra As String, ByVal NumeroRecibo As String) As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Sqlstring As String
        Dim DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim Consecutivo As Double

        If Serie = "" Then
            Sqlstring = "SELECT   IdLiquidacionPergamino, Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso, IdTipoIngreso, IdCosecha,    IdLocalidad, Cod_Proveedor, IdTipoCompra, PrecioAutoriza, TotalDeducciones, ChkRentDef, ChkRent2, ChkRent3, ChkMuncipal, IdTipoCambio, Serie  FROM        LiquidacionPergamino " & _
                         "WHERE (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (LEN(Codigo) <= 6) AND (Serie = '?')  AND (Codigo = '" & NumeroRecibo & "') ORDER BY Codigo DESC"
        Else
            Sqlstring = "SELECT  IdLiquidacionPergamino, Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso, IdTipoIngreso, IdCosecha,    IdLocalidad, Cod_Proveedor, IdTipoCompra, PrecioAutoriza, TotalDeducciones, ChkRentDef, ChkRent2, ChkRent3, ChkMuncipal, IdTipoCambio, Serie  FROM        LiquidacionPergamino " & _
                                    "WHERE (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ") AND (IdTipoCompra = " & IdTipoCompra & ")  AND (LEN(Codigo) <= 6)AND (Serie = '" & Serie & "') AND (Codigo = '" & NumeroRecibo & "') ORDER BY Codigo DESC"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "Serie")
        If DataSet.Tables("Serie").Rows.Count <> 0 Then
            Consecutivo = DataSet.Tables("Serie").Rows(0)("Codigo")
            BuscaConsecutivoLiquidacionManual = Format(Consecutivo + 1, "00000#")
        Else
            BuscaConsecutivoLiquidacionManual = "000000"
        End If

    End Function

    Public Function BuscaConsecutivoReciboManual(ByVal Serie As String, ByVal IdTipoCafe As Double, ByVal IdCosecha As Double, ByVal IdLocalidad As Double, ByVal IdTipoCompra As String, ByVal NumeroRecibo As String) As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Sqlstring As String
        Dim DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim Consecutivo As Double

        If Serie = "" Then
            Sqlstring = "SELECT Codigo, IdTipoCafe, IdCosecha, IdLocalidad, IdDano, IdFinca, IdTipoCompra, IdEstadoDocumento, IdProductor, IdUnidadMedida, IdUsuario, IdLocalidadLiquidacion, SincronizadoECS, FechaSincronizacion, FechaIngresoSistemas, IdPignorado, EsProductorManual, CedulaManual, ProductorManual, FincaManual,  IdCalidad  FROM ReciboCafePergamino " & _
                         "WHERE (IdTipoCafe = " & IdTipoCafe & ") AND (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (LEN(Codigo) <= 6) AND (Serie = '?')  AND (Codigo = '" & NumeroRecibo & "') ORDER BY Codigo DESC"
        Else
            Sqlstring = "SELECT Codigo, IdTipoCafe, IdCosecha, IdLocalidad, IdDano, IdFinca, IdTipoCompra, IdEstadoDocumento, IdProductor, IdUnidadMedida, IdUsuario, IdLocalidadLiquidacion, SincronizadoECS, FechaIngresoSistemas, IdPignorado, EsProductorManual, CedulaManual, ProductorManual, FincaManual,  IdCalidad  FROM ReciboCafePergamino " & _
                                    "WHERE (IdTipoCafe = " & IdTipoCafe & ") AND (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ") AND (IdTipoCompra = " & IdTipoCompra & ")  AND (LEN(Codigo) <= 6)AND (Serie = '" & Serie & "') AND (Codigo = '" & NumeroRecibo & "') ORDER BY Codigo DESC"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "Serie")
        If DataSet.Tables("Serie").Rows.Count <> 0 Then
            Consecutivo = DataSet.Tables("Serie").Rows(0)("Codigo")
            BuscaConsecutivoReciboManual = Format(Consecutivo + 1, "00000#")
        Else
            BuscaConsecutivoReciboManual = "000000"
        End If


    End Function

    Public Function DescripcionTipoIngreso(ByVal Codigo As String) As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlString As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, IdTipoDocumento As Double = 0, Numero As Double

        DescripcionTipoIngreso = ""

        SqlString = "SELECT IdTipoIngreso, Descripcion, Code, IdECS FROM TipoIngreso WHERE (Code = '" & Codigo & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            DescripcionTipoIngreso = DataSet.Tables("Consulta").Rows(0)("Descripcion")
        End If

    End Function


    Public Sub NumeroTecla(ByVal Numeros As Boolean)
        If Numeros = True Then
            FrmTecladoLetras.CmdQ.Text = "1"
            FrmTecladoLetras.CmdW.Text = "2"
            FrmTecladoLetras.CmdE.Text = "3"
            FrmTecladoLetras.CmdR.Text = "4"
            FrmTecladoLetras.CmdT.Text = "5"
            FrmTecladoLetras.CmdY.Text = "6"
            FrmTecladoLetras.CmdU.Text = "7"
            FrmTecladoLetras.CmdI.Text = "8"
            FrmTecladoLetras.CmdO.Text = "9"
            FrmTecladoLetras.CmdP.Text = "0"
            FrmTecladoLetras.CmdA.Text = "!"
            FrmTecladoLetras.CmdS.Text = "@"
            FrmTecladoLetras.CmdD.Text = "#"
            FrmTecladoLetras.CmdF.Text = "$"
            FrmTecladoLetras.CmdG.Text = "/"
            FrmTecladoLetras.CmdH.Text = "+"
            FrmTecladoLetras.CmdJ.Text = "&"
            FrmTecladoLetras.CmdK.Text = "*"
            FrmTecladoLetras.CmdL.Text = "("
            FrmTecladoLetras.CmdÑ.Text = ")"
            FrmTecladoLetras.CmdZ.Text = "-"
            FrmTecladoLetras.CmdX.Text = "%"
            FrmTecladoLetras.CmdC.Text = "="
            FrmTecladoLetras.CmdV.Text = "?"
            FrmTecladoLetras.CmdB.Text = "¿"
            FrmTecladoLetras.CmdN.Text = ":"
            FrmTecladoLetras.CmdM.Text = ";"
            FrmTecladoLetras.CmdEspacio.Text = "Espacio"
        ElseIf FrmTecladoLetras.CmdMinusculas.Visible = True Then
            FrmTecladoLetras.CmdQ.Text = "q"
            FrmTecladoLetras.CmdW.Text = "w"
            FrmTecladoLetras.CmdE.Text = "e"
            FrmTecladoLetras.CmdR.Text = "r"
            FrmTecladoLetras.CmdT.Text = "t"
            FrmTecladoLetras.CmdY.Text = "y"
            FrmTecladoLetras.CmdU.Text = "u"
            FrmTecladoLetras.CmdI.Text = "i"
            FrmTecladoLetras.CmdO.Text = "o"
            FrmTecladoLetras.CmdP.Text = "p"
            FrmTecladoLetras.CmdA.Text = "a"
            FrmTecladoLetras.CmdS.Text = "s"
            FrmTecladoLetras.CmdD.Text = "d"
            FrmTecladoLetras.CmdF.Text = "f"
            FrmTecladoLetras.CmdG.Text = "g"
            FrmTecladoLetras.CmdH.Text = "h"
            FrmTecladoLetras.CmdJ.Text = "j"
            FrmTecladoLetras.CmdK.Text = "k"
            FrmTecladoLetras.CmdL.Text = "l"
            FrmTecladoLetras.CmdÑ.Text = "ñ"
            FrmTecladoLetras.CmdZ.Text = "z"
            FrmTecladoLetras.CmdX.Text = "x"
            FrmTecladoLetras.CmdC.Text = "c"
            FrmTecladoLetras.CmdV.Text = "v"
            FrmTecladoLetras.CmdB.Text = "b"
            FrmTecladoLetras.CmdN.Text = "n"
            FrmTecladoLetras.CmdM.Text = "m"
            FrmTecladoLetras.CmdEspacio.Text = "Espacio"
        ElseIf FrmTecladoLetras.CmdMayusculas.Visible = True Then
            FrmTecladoLetras.CmdQ.Text = "Q"
            FrmTecladoLetras.CmdW.Text = "W"
            FrmTecladoLetras.CmdE.Text = "E"
            FrmTecladoLetras.CmdR.Text = "R"
            FrmTecladoLetras.CmdT.Text = "T"
            FrmTecladoLetras.CmdY.Text = "Y"
            FrmTecladoLetras.CmdU.Text = "U"
            FrmTecladoLetras.CmdI.Text = "I"
            FrmTecladoLetras.CmdO.Text = "O"
            FrmTecladoLetras.CmdP.Text = "P"
            FrmTecladoLetras.CmdA.Text = "A"
            FrmTecladoLetras.CmdS.Text = "S"
            FrmTecladoLetras.CmdD.Text = "D"
            FrmTecladoLetras.CmdF.Text = "F"
            FrmTecladoLetras.CmdG.Text = "G"
            FrmTecladoLetras.CmdH.Text = "H"
            FrmTecladoLetras.CmdJ.Text = "J"
            FrmTecladoLetras.CmdK.Text = "K"
            FrmTecladoLetras.CmdL.Text = "L"
            FrmTecladoLetras.CmdÑ.Text = "Ñ"
            FrmTecladoLetras.CmdZ.Text = "Z"
            FrmTecladoLetras.CmdX.Text = "X"
            FrmTecladoLetras.CmdC.Text = "C"
            FrmTecladoLetras.CmdV.Text = "V"
            FrmTecladoLetras.CmdB.Text = "B"
            FrmTecladoLetras.CmdN.Text = "N"
            FrmTecladoLetras.CmdM.Text = "M"
            FrmTecladoLetras.CmdEspacio.Text = "ESPACIO"

        End If

    End Sub



    Public Sub LetraTecla(ByVal Minusculas As Boolean)
        If Minusculas = True Then
            FrmTecladoLetras.CmdQ.Text = "q"
            FrmTecladoLetras.CmdW.Text = "w"
            FrmTecladoLetras.CmdE.Text = "e"
            FrmTecladoLetras.CmdR.Text = "r"
            FrmTecladoLetras.CmdT.Text = "t"
            FrmTecladoLetras.CmdY.Text = "y"
            FrmTecladoLetras.CmdU.Text = "u"
            FrmTecladoLetras.CmdI.Text = "i"
            FrmTecladoLetras.CmdO.Text = "o"
            FrmTecladoLetras.CmdP.Text = "p"
            FrmTecladoLetras.CmdA.Text = "a"
            FrmTecladoLetras.CmdS.Text = "s"
            FrmTecladoLetras.CmdD.Text = "d"
            FrmTecladoLetras.CmdF.Text = "f"
            FrmTecladoLetras.CmdG.Text = "g"
            FrmTecladoLetras.CmdH.Text = "h"
            FrmTecladoLetras.CmdJ.Text = "j"
            FrmTecladoLetras.CmdK.Text = "k"
            FrmTecladoLetras.CmdL.Text = "l"
            FrmTecladoLetras.CmdÑ.Text = "ñ"
            FrmTecladoLetras.CmdZ.Text = "z"
            FrmTecladoLetras.CmdX.Text = "x"
            FrmTecladoLetras.CmdC.Text = "c"
            FrmTecladoLetras.CmdV.Text = "v"
            FrmTecladoLetras.CmdB.Text = "b"
            FrmTecladoLetras.CmdN.Text = "n"
            FrmTecladoLetras.CmdM.Text = "m"
            FrmTecladoLetras.CmdEspacio.Text = "Espacio"
        Else
            FrmTecladoLetras.CmdQ.Text = "Q"
            FrmTecladoLetras.CmdW.Text = "W"
            FrmTecladoLetras.CmdE.Text = "E"
            FrmTecladoLetras.CmdR.Text = "R"
            FrmTecladoLetras.CmdT.Text = "T"
            FrmTecladoLetras.CmdY.Text = "Y"
            FrmTecladoLetras.CmdU.Text = "U"
            FrmTecladoLetras.CmdI.Text = "I"
            FrmTecladoLetras.CmdO.Text = "O"
            FrmTecladoLetras.CmdP.Text = "P"
            FrmTecladoLetras.CmdA.Text = "A"
            FrmTecladoLetras.CmdS.Text = "S"
            FrmTecladoLetras.CmdD.Text = "D"
            FrmTecladoLetras.CmdF.Text = "F"
            FrmTecladoLetras.CmdG.Text = "G"
            FrmTecladoLetras.CmdH.Text = "H"
            FrmTecladoLetras.CmdJ.Text = "J"
            FrmTecladoLetras.CmdK.Text = "K"
            FrmTecladoLetras.CmdL.Text = "L"
            FrmTecladoLetras.CmdÑ.Text = "Ñ"
            FrmTecladoLetras.CmdZ.Text = "Z"
            FrmTecladoLetras.CmdX.Text = "X"
            FrmTecladoLetras.CmdC.Text = "C"
            FrmTecladoLetras.CmdV.Text = "V"
            FrmTecladoLetras.CmdB.Text = "B"
            FrmTecladoLetras.CmdN.Text = "N"
            FrmTecladoLetras.CmdM.Text = "M"
            FrmTecladoLetras.CmdEspacio.Text = "ESPACIO"

        End If

    End Sub


    Public Function SoloNumeros(ByVal strCadena As String) As Object
        Dim SoloNumero As String = ""
        Dim index As Integer
        For index = 1 To Len(strCadena)
            If (Mid$(strCadena, index, 1) Like "#") _
                Or Mid$(strCadena, index, 1) = "-" Then
                SoloNumero = SoloNumero & Mid$(strCadena, index, 1)
            End If
        Next
        Return SoloNumero
    End Function
    Public Sub GrabaRecibo(ByVal NumeroRecibo As String, ByVal FechaRecibo As Date)
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion), ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Serie As String, Sql As String, IdEstadoDocumento As Double

        If FrmRecepcion.TxtSerie.Text = "" Then
            Serie = "?"
        Else
            Serie = FrmRecepcion.TxtSerie.Text
        End If




        'Sql = "SELECT IdEstadoDocumento, Codigo, Descripcion  FROM EstadoDocumento WHERE (Descripcion = '" & FrmRecepcion.CboEstadoDocumeto.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        'DataAdapter.Fill(DataSet, "EstadoDocumento")
        'If DataSet.Tables("EstadoDocumento").Rows.Count <> 0 Then
        '    IdEstadoDocumento = DataSet.Tables("EstadoDocumento").Rows(0)("IdEstadoDocumento")
        'Else
        '    IdEstadoDocumento = 293
        'End If

        If FrmRecepcion.TxtProveedor.Text = "00001" Then
            '//////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////SI EL PRODUCTOR ES MANUAL /////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////
            '///////////////BUSCO EL ID DEL TIPO DE CAFE ///////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////  (Codigo = '" & NumeroRecibo & "') AND (IdTipoCafe = " & FrmRecepcion.IdTipoCafe & ") AND (IdLocalidad = " & FrmRecepcion.IdLugarAcopio & ") AND (IdTipoCompra = " & FrmRecepcion.IdTipoCompra & ")
            SqlString = "SELECT  ReciboCafePergamino.*  FROM ReciboCafePergamino WHERE  (ReciboCafePergamino.IdReciboPergamino = " & FrmRecepcion.IdReciboCafe & ") AND (IdCosecha = " & FrmRecepcion.IdCosecha & ") "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                MiConexion.Open()
                StrSqlUpdate = "UPDATE [ReciboCafePergamino] SET [Codigo] = '" & NumeroRecibo & "',[Fecha] = CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm") & "', 102),[Observacion] =  '" & FrmRecepcion.Observaciones & "' ,[IdTipoCafe] = " & FrmRecepcion.IdTipoCafe & " ,[IdCosecha] = " & FrmRecepcion.IdCosecha & " ,[IdLocalidad] = " & FrmRecepcion.IdLugarAcopio & " ,[IdDano] = " & FrmRecepcion.IdDaño & " ,[IdTipoCompra] = " & FrmRecepcion.IdTipoCompra & " ,[IdLocalidadLiquidacion] = " & FrmRecepcion.CboLiquidarLocalidad.Columns(0).Text & " ,[FechaIngresoSistemas] = CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm") & "', 102), [IdCalidad] = " & FrmRecepcion.IdCalidad & ", [IdTipoIngreso] = " & FrmRecepcion.IdTipoIngreso & " ,[IdRangoImperfeccion]= " & FrmRecepcion.IdRangoImperfeccion & " ,[CedulaManual]= '" & FrmRecepcion.TxtNumeroCedula.Text & "',[EsProductorManual]= 1, [ProductorManual]= '" & FrmRecepcion.txtnombre.Text & "',[FincaManual]= '" & FrmRecepcion.TxtFinca.Text & "',[Serie2]= '" & Serie & "',[IdUsuario]= " & IdUsuario & " ,[IdUnidadMedida]= 1 ,[IdPignorado]= " & FrmRecepcion.IdPignorado & ", [IdEstadoDocumento]= " & FrmRecepcion.IdEstadoDocumento & ",  [IdLocalidadRegistro]= " & FrmRecepcion.IdLugarAcopioDefecto & "  WHERE (ReciboCafePergamino.IdReciboPergamino = " & FrmRecepcion.IdReciboCafe & ") AND (IdCosecha = " & FrmRecepcion.IdCosecha & ") "
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else

                '[FechaIngresoSistemas]
                StrSqlUpdate = "INSERT INTO [ReciboCafePergamino] ([Codigo],[Fecha],[Observacion],[IdTipoCafe],[IdCosecha],[IdLocalidad],[IdDano],[IdTipoCompra],[IdEstadoDocumento],[IdLocalidadLiquidacion],[IdCalidad],[IdTipoIngreso],[IdRangoImperfeccion],[CedulaManual],[ProductorManual],[FincaManual],[Serie2],[IdUsuario] ,[IdUnidadMedida],[IdPignorado],[IdLocalidadRegistro],[EsProductorManual],[FechaIngresoSistemas])  " & _
                               "VALUES ('" & NumeroRecibo & "' ,CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm") & "', 102) , '" & FrmRecepcion.Observaciones & "' ," & FrmRecepcion.IdTipoCafe & " ," & FrmRecepcion.IdCosecha & "," & FrmRecepcion.IdLugarAcopio & " ," & FrmRecepcion.IdDaño & " , " & FrmRecepcion.IdTipoCompra & " ," & FrmRecepcion.IdEstadoDocumento & "," & FrmRecepcion.CboLiquidarLocalidad.Columns(0).Text & " , " & FrmRecepcion.IdCalidad & "," & FrmRecepcion.IdTipoIngreso & "," & FrmRecepcion.IdRangoImperfeccion & ",'" & FrmRecepcion.TxtNumeroCedula.Text & "', '" & FrmRecepcion.txtnombre.Text & "', '" & FrmRecepcion.TxtFinca.Text & "', '" & Serie & "', " & IdUsuario & ",1, " & FrmRecepcion.IdPignorado & ", " & FrmRecepcion.IdLugarAcopioDefecto & ",1, CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm") & "', 102))"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If




        Else
            '/////////////////////////////////////////////////////////////////////////////
            '///////////////BUSCO EL ID DEL TIPO DE CAFE ///////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT  ReciboCafePergamino.*  FROM ReciboCafePergamino WHERE (ReciboCafePergamino.IdReciboPergamino = " & FrmRecepcion.IdReciboCafe & ") AND (IdCosecha = " & FrmRecepcion.IdCosecha & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                MiConexion.Open()
                StrSqlUpdate = "UPDATE [ReciboCafePergamino] SET [Codigo] = '" & NumeroRecibo & "',[Fecha] = CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm") & "', 102),[Observacion] =  '" & FrmRecepcion.Observaciones & "' ,[IdTipoCafe] = " & FrmRecepcion.IdTipoCafe & " ,[IdCosecha] = " & FrmRecepcion.IdCosecha & " ,[IdLocalidad] = " & FrmRecepcion.IdLugarAcopio & " ,[IdDano] = " & FrmRecepcion.IdDaño & " ,[IdFinca] = " & FrmRecepcion.IdFinca & " ,[IdTipoCompra] = " & FrmRecepcion.IdTipoCompra & " ,[IdProductor] = " & FrmRecepcion.IdProductor & " ,[IdLocalidadLiquidacion] = " & FrmRecepcion.CboLiquidarLocalidad.Columns(0).Text & " ,[FechaIngresoSistemas] = CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm") & "', 102), [IdCalidad] = " & FrmRecepcion.IdCalidad & ", [IdTipoIngreso] = " & FrmRecepcion.IdTipoIngreso & " ,[IdRangoImperfeccion]= " & FrmRecepcion.IdRangoImperfeccion & ", [Serie2]= '" & Serie & "', [IdUsuario]= " & IdUsuario & " ,[IdUnidadMedida]= 1, [IdPignorado]= " & FrmRecepcion.IdPignorado & ", [IdEstadoDocumento]= " & FrmRecepcion.IdEstadoDocumento & ", [IdLocalidadRegistro]= " & FrmRecepcion.IdLugarAcopioDefecto & ", [EsProductorManual]= 0,  [CedulaManual]= '', [ProductorManual]= '', [FincaManual]= ''  WHERE (ReciboCafePergamino.IdReciboPergamino = " & FrmRecepcion.IdReciboCafe & ") AND (IdCosecha = " & FrmRecepcion.IdCosecha & ") "
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else
                StrSqlUpdate = "INSERT INTO [ReciboCafePergamino] ([Codigo],[Fecha],[Observacion],[IdTipoCafe],[IdCosecha],[IdLocalidad],[IdDano],[IdFinca],[IdTipoCompra],[IdEstadoDocumento],[IdProductor],[IdLocalidadLiquidacion],[IdCalidad],[IdTipoIngreso],[IdRangoImperfeccion],[Serie2],[IdUsuario] ,[IdUnidadMedida],[IdPignorado], [IdLocalidadRegistro],[EsProductorManual],[FechaIngresoSistemas])  " & _
                               "VALUES ('" & NumeroRecibo & "' ,CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm") & "', 102) , '" & FrmRecepcion.Observaciones & "' ," & FrmRecepcion.IdTipoCafe & " ," & FrmRecepcion.IdCosecha & "," & FrmRecepcion.IdLugarAcopio & " ," & FrmRecepcion.IdDaño & " , " & FrmRecepcion.IdFinca & " , " & FrmRecepcion.IdTipoCompra & " ," & FrmRecepcion.IdEstadoDocumento & "," & FrmRecepcion.IdProductor & " ," & FrmRecepcion.CboLiquidarLocalidad.Columns(0).Text & " , " & FrmRecepcion.IdCalidad & "," & FrmRecepcion.IdTipoIngreso & "," & FrmRecepcion.IdRangoImperfeccion & ",'" & Serie & "', " & IdUsuario & ",1, " & FrmRecepcion.IdPignorado & "," & FrmRecepcion.IdLugarAcopioDefecto & ",0,CONVERT(DATETIME, '" & Format(FechaRecibo, "yyyy-MM-dd HH:mm") & "', 102))"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
        End If
    End Sub

    Public Sub GrabaDetalleRecibo(ByVal IdReciboCafe As Double, ByVal CantidadSacos As Double, ByVal Humedad As Double, ByVal Tara As Double, ByVal Imperfeccion As Double, ByVal IdReciboPergamino As Double, ByVal IdTipoSaco As Double, ByVal IdEstadoFisico As Double, ByVal PesoBruto As Double)
        Dim SqlString As String
        Dim DataSet As New DataSet, DataAdapter As SqlClient.SqlDataAdapter, StrSqlUpdate As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion), ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        '/////////////////////////////////////////////////////////////////////////////
        '///////////////BUSCO EL ID DEL TIPO DE CAFE ///////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  DetalleReciboCafePergamino.* FROM DetalleReciboCafePergamino WHERE(IdReciboPergamino = " & IdReciboCafe & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            MiConexion.Open()
            StrSqlUpdate = "UPDATE DetalleReciboCafePergamino  SET  [CantidadSacos] = " & CantidadSacos & " ,[Humedad] = " & Humedad & " ,[Tara] = " & Tara & " ,[Imperfeccion] = " & Imperfeccion & " ,[IdReciboPergamino] = " & IdReciboPergamino & ",[IdTipoSaco] = " & IdTipoSaco & ",[IdEdoFisico] = " & IdEstadoFisico & ",[PesoBruto] = " & PesoBruto & "   WHERE(IdReciboPergamino = " & IdReciboCafe & ")"
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Else
            StrSqlUpdate = "INSERT INTO [DetalleReciboCafePergamino] ([CantidadSacos],[Humedad],[Tara],[Imperfeccion],[IdReciboPergamino],[IdTipoSaco],[IdEdoFisico],[PesoBruto]) " & _
                           "VALUES (" & CantidadSacos & "," & Humedad & " ," & Tara & " ," & Imperfeccion & " ," & IdReciboPergamino & " ," & IdTipoSaco & "," & IdEstadoFisico & "," & PesoBruto & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If






    End Sub

    Public Function ExisteConductor(ByVal CodProveedor As String) As Boolean
        Dim SqlString As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter

        'SqlString = "SELECT  *  FROM Conductor WHERE (Codigo = '" & CodProveedor & "')"
        SqlString = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, Vehiculo.Placa FROM  EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo  " & _
                     "WHERE   (EmpresaTransporte.Codigo = '" & CodProveedor & "')"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapterProductos.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            ExisteConductor = True
        Else
            ExisteConductor = False
        End If

    End Function

    Public Sub ActualizaComboProducto()
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, SqlProductos As String


        SqlProductos = "SELECT Cod_Productos, Descripcion_Producto FROM Productos"
        DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlProductos, MiConexion)
        DataAdapterProductos.Fill(DataSet, "ListaProductos")
        If Not DataSet.Tables("ListaProductos").Rows.Count = 0 Then
            FrmProductos.CboCodigoProducto.DataSource = DataSet.Tables("ListaProductos")
        End If
    End Sub
    Public Function BuscaConsecutivoCarga(ByVal NombreCampo As String) As Double

        Dim SqlConsecutivo As String, SQlUpdate As String, CodConsecutivo As Double
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        '/////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////BUSCO EL CONSECUTIVO COMPONENTES/////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////

        SqlConsecutivo = "SELECT  * FROM  Consecutivos"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        DataAdapter.Fill(DataSet, "Consecutivo")
        If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Consecutivo").Rows(0)(NombreCampo)) Then
                CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)(NombreCampo) + 1
            Else
                CodConsecutivo = 1
            End If
            BuscaConsecutivoCarga = CodConsecutivo

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////ACTUALIZO EL CONSECUTIVO///////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'MiConexion.Close()
            'SQlUpdate = "UPDATE [Consecutivos]  SET [" & NombreCampo & "] = " & CodConsecutivo & ""
            'MiConexion.Open()
            'ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
            'iResultado = ComandoUpdate.ExecuteNonQuery
            'MiConexion.Close()

        Else
            BuscaConsecutivoCarga = 0
        End If

    End Function


    Public Function BuscaConsecutivo(ByVal NombreCampo As String, ByVal CodLugarAcopio As Double) As Double

        Dim SqlConsecutivo As String, SQlUpdate As String, CodConsecutivo As Double
        Dim MiConexion As New SqlClient.SqlConnection(Conexion), SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Numero As Double, Cadena As String, CadenaSplit() As String, IdLugarAcopio As Double = 0
        '/////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////BUSCO EL CONSECUTIVO COMPONENTES/////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////

        '//////////////////7BUSCO LA LOCALIDAD ////////////////////////////////////////
        SqlString = "SELECT LugarAcopio.* FROM LugarAcopio WHERE (CodLugarAcopio = " & CodLugarAcopio & ") AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "LugarAcopio")
        If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
            IdLugarAcopio = DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
        End If



        BuscaConsecutivo = 0

        Select Case NombreCampo
            Case "Lote"
                SqlConsecutivo = "SELECT TipoRecepcion, IdLugarAcopio, NumeroRecepcion FROM Recepcion WHERE  (TipoRecepcion = '" & NombreCampo & "') AND (IdLugarAcopio = " & IdLugarAcopio & ") AND (NumeroRecepcion LIKE '%" & CodLugarAcopio & "%') ORDER BY NumeroRecepcion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                DataAdapter.Fill(DataSet, "Consecutivo")
                If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
                    Numero = Len(DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion"))
                    If Numero <= 6 Then
                        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion")
                        CodConsecutivo = CodConsecutivo + 1
                    Else
                        Cadena = DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion")
                        CadenaSplit = Cadena.Split("-")
                        CodConsecutivo = CadenaSplit(1)
                        CodConsecutivo = CodConsecutivo + 1
                    End If
                Else
                    CodConsecutivo = 1
                End If
            Case "RePesaje"
                SqlConsecutivo = "SELECT TipoRecepcion, IdLugarAcopio, NumeroRecepcion FROM Recepcion WHERE  (TipoRecepcion = '" & NombreCampo & "') AND (IdLugarAcopio = " & IdLugarAcopio & ") AND (NumeroRecepcion LIKE '%" & CodLugarAcopio & "%') ORDER BY NumeroRecepcion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                DataAdapter.Fill(DataSet, "Consecutivo")
                If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
                    Numero = Len(DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion"))
                    If Numero <= 6 Then
                        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion")
                        CodConsecutivo = CodConsecutivo + 1
                    Else
                        Cadena = DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion")
                        CadenaSplit = Cadena.Split("-")
                        CodConsecutivo = CadenaSplit(1)
                        CodConsecutivo = CodConsecutivo + 1
                    End If
                Else
                    CodConsecutivo = 1
                End If

            Case "ReImprime"
                SqlConsecutivo = "SELECT TipoRecepcion, IdLugarAcopio, NumeroRecepcion FROM Recepcion WHERE  (TipoRecepcion = 'RePesaje') AND (IdLugarAcopio = " & IdLugarAcopio & ") AND (NumeroRecepcion LIKE '%" & CodLugarAcopio & "%') ORDER BY NumeroRecepcion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                DataAdapter.Fill(DataSet, "Consecutivo")
                If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
                    Numero = Len(DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion"))
                    If Numero <= 6 Then
                        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion")
                        CodConsecutivo = CodConsecutivo + 1
                    Else
                        Cadena = DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion")
                        CadenaSplit = Cadena.Split("-")
                        CodConsecutivo = CadenaSplit(1)
                        CodConsecutivo = CodConsecutivo + 1
                    End If
                Else
                    CodConsecutivo = 1
                End If

            Case "Recepcion"
                SqlConsecutivo = "SELECT TipoRecepcion, IdLugarAcopio, NumeroRecepcion FROM Recepcion WHERE  (TipoRecepcion = '" & NombreCampo & "') AND (IdLugarAcopio = " & IdLugarAcopio & ") AND (NumeroRecepcion LIKE '%" & CodLugarAcopio & "%') ORDER BY NumeroRecepcion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                DataAdapter.Fill(DataSet, "Consecutivo")
                If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
                    Numero = Len(DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion"))
                    If Numero <= 6 Then
                        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion")
                        CodConsecutivo = CodConsecutivo + 1
                    Else
                        Cadena = DataSet.Tables("Consecutivo").Rows(0)("NumeroRecepcion")
                        CadenaSplit = Cadena.Split("-")
                        CodConsecutivo = CadenaSplit(1)
                        CodConsecutivo = CodConsecutivo + 1
                    End If
                Else
                    CodConsecutivo = 1
                End If

            Case "Entrada"
                'SqlConsecutivo = "SELECT CodCarga, IdLugarAcopio, Fecha, NumeroManual, LEN(CodCarga) AS Numero FROM IndiceCarga WHERE (LEN(CodCarga) > 6) AND (IdLugarAcopio = " & IdLugarAcopio & ") ORDER BY CodCarga DESC"
                SqlConsecutivo = "SELECT IdRegistro, IdLugarAcopio, TipoRegistro FROM Registros WHERE (IdLugarAcopio = " & IdLugarAcopio & ") AND (TipoRegistro = 'Llegada') AND (LEN(IdRegistro) > 6) ORDER BY IdRegistro DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                DataAdapter.Fill(DataSet, "Consecutivo")
                If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
                    Numero = Len(DataSet.Tables("Consecutivo").Rows(0)("IdRegistro"))
                    If Numero <= 6 Then
                        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)("IdRegistro")
                        CodConsecutivo = CodConsecutivo + 1
                    Else
                        Cadena = DataSet.Tables("Consecutivo").Rows(0)("IdRegistro")
                        CadenaSplit = Cadena.Split("-")
                        CodConsecutivo = CadenaSplit(1)
                        CodConsecutivo = CodConsecutivo + 1
                    End If
                Else
                    CodConsecutivo = 1
                End If

            Case "Carga"
                SqlConsecutivo = "SELECT CodCarga, IdLugarAcopio, Fecha, LEN(CodCarga) AS Numero FROM IndiceCarga WHERE (IdLugarAcopio = " & IdLugarAcopio & ") AND (LEN(IdRegistro) > 6) ORDER BY CodCarga DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                DataAdapter.Fill(DataSet, "Consecutivo")
                If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
                    Numero = Len(DataSet.Tables("Consecutivo").Rows(0)("CodCarga"))
                    If Numero <= 6 Then
                        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)("CodCarga")
                        CodConsecutivo = CodConsecutivo + 1
                    Else
                        Cadena = DataSet.Tables("Consecutivo").Rows(0)("CodCarga")
                        CadenaSplit = Cadena.Split("-")
                        CodConsecutivo = CadenaSplit(1)
                        CodConsecutivo = CodConsecutivo + 1
                    End If
                Else
                    CodConsecutivo = 1
                End If

            Case "Salida"
                SqlConsecutivo = "SELECT IdRegistro, IdLugarAcopio, TipoRegistro FROM Registros WHERE (IdLugarAcopio = " & IdLugarAcopio & ") AND (TipoRegistro = '" & NombreCampo & "') AND (LEN(IdRegistro) > 6) ORDER BY IdRegistro DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                DataAdapter.Fill(DataSet, "Consecutivo")
                If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
                    Numero = Len(DataSet.Tables("Consecutivo").Rows(0)("IdRegistro"))
                    If Numero <= 6 Then
                        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)("IdRegistro")
                        CodConsecutivo = CodConsecutivo + 1
                    Else
                        Cadena = DataSet.Tables("Consecutivo").Rows(0)("IdRegistro")
                        CadenaSplit = Cadena.Split("-")
                        CodConsecutivo = CadenaSplit(1)
                        CodConsecutivo = CodConsecutivo + 1
                    End If
                Else
                    CodConsecutivo = 1
                End If

            Case "Reserva"
                SqlConsecutivo = "SELECT IdRegistro, IdLugarAcopio, TipoRegistro FROM Registros WHERE (IdLugarAcopio = " & IdLugarAcopio & ") AND (TipoRegistro = '" & NombreCampo & "') AND (LEN(IdRegistro) > 6) ORDER BY IdRegistro DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
                DataAdapter.Fill(DataSet, "Consecutivo")
                If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
                    Numero = Len(DataSet.Tables("Consecutivo").Rows(0)("IdRegistro"))
                    If Numero <= 6 Then
                        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)("IdRegistro")
                        CodConsecutivo = CodConsecutivo + 1
                    Else
                        Cadena = DataSet.Tables("Consecutivo").Rows(0)("IdRegistro")
                        CadenaSplit = Cadena.Split("-")
                        CodConsecutivo = CadenaSplit(1)
                        CodConsecutivo = CodConsecutivo + 1
                    End If
                Else
                    CodConsecutivo = 1
                End If


        End Select

        BuscaConsecutivo = CodConsecutivo

        'SqlConsecutivo = "SELECT  * FROM  Consecutivos"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlConsecutivo, MiConexion)
        'DataAdapter.Fill(DataSet, "Consecutivo")
        'If Not DataSet.Tables("Consecutivo").Rows.Count = 0 Then
        '    If Not IsDBNull(DataSet.Tables("Consecutivo").Rows(0)(NombreCampo)) Then
        '        CodConsecutivo = DataSet.Tables("Consecutivo").Rows(0)(NombreCampo) + 1
        '    Else
        '        CodConsecutivo = 1
        '    End If
        '    BuscaConsecutivo = CodConsecutivo

        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '////////////////////////////ACTUALIZO EL CONSECUTIVO///////////////////////////////////////////////////
        '    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    MiConexion.Close()
        '    SQlUpdate = "UPDATE [Consecutivos]  SET [" & NombreCampo & "] = " & CodConsecutivo & ""
        '    MiConexion.Open()
        '    ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
        '    iResultado = ComandoUpdate.ExecuteNonQuery
        '    MiConexion.Close()

        'Else
        '    BuscaConsecutivo = 0
        'End If

    End Function

    Public Sub ActualizaEstadoRecepcion(ByVal NumeroRecepcion As String, ByVal FechaRecepcion As Date, ByVal Activo As Boolean, ByVal NumeroBoleta As String)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Sql As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        MiConexion.Close()

        Sql = "SELECT  Recepcion.* FROM Recepcion WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = 'Recepcion')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        If Not DataSet.Tables("DetalleRecepcion").Rows.Count = 0 Then
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCompras = "UPDATE [Recepcion] SET [Activo] = '" & Activo & "', [NumeroBoleta] = '" & NumeroBoleta & "' WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = 'Recepcion')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

    End Sub
    Public Sub GrabaRegistros(ByVal ConsecutivoRegistro As String, ByVal TipoRegistro As String, ByVal IdConductor As Double, ByVal IdLugarAcopio As Double, ByVal FechaCarga As DateTime, ByVal Placa As String, ByVal NumeroBoleta As String, ByVal IdCosecha As Double)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Sql As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        'Fecha = Format(FrmCarga.DTPFecha.Value, "yyyy-MM-dd")

        '-----------------------BUSCO EL ULTIMO CODIGO DE LLEGADA DE LA PLACA ---------------
        Dim IdTransporte As String = ""
        If TipoRegistro = "Llegada" Then
            IdTransporte = ConsecutivoRegistro
        Else
            Dim Adaptar As New SqlClient.SqlDataAdapter("Select top (1) IdRegistro From Registros Where Placa = '" & Placa & "' and TipoRegistro = 'Llegada' order by IdRegistro DESC ", MiConexion)
            Dim TablaQuery As New DataTable
            Adaptar.Fill(TablaQuery)
            If TablaQuery.Rows.Count > 0 Then
                IdTransporte = TablaQuery.Rows(0)("IdRegistro")
            End If

        End If

        '---------------------------ACTULIZO EL ESTADO DEL VEHICULO -----------------------------------------
        Dim Command As SqlClient.SqlCommand
        If TipoRegistro = "Salida" Then
            Command = New SqlClient.SqlCommand("Update Vehiculo set Posicion ='Disponible' Where Placa ='" & Placa & "' ", MiConexion)
        Else
            Command = New SqlClient.SqlCommand("Update Vehiculo set Posicion ='" & TipoRegistro & "' Where Placa ='" & Placa & "' ", MiConexion)
        End If


        '/////////////////////////////


        MiConexion.Close()

        Sql = "SELECT  *  FROM Registros WHERE (IdRegistro = '" & ConsecutivoRegistro & "') AND (TipoRegistro = '" & TipoRegistro & "') AND (IdLugarAcopio = '" & IdLugarAcopio & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Registros")
        If DataSet.Tables("Registros").Rows.Count = 0 Then
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCompras = "INSERT INTO [Registros] ([IdRegistro],[TipoRegistro],[IdConductor],[IdLugarAcopio],[Fecha],[Placa],[IdTransporte],[NumeroBoleta],[IdCosecha]) " & _
                         "VALUES ('" & ConsecutivoRegistro & "','" & TipoRegistro & "'," & IdConductor & "," & IdLugarAcopio & ",CONVERT(DATETIME, '" & Format(FechaCarga, "yyyy-MM-dd HH:mm:ss") & "', 102),'" & Placa & "','" & IdTransporte & "','" & NumeroBoleta & "'," & IdCosecha & " )"

            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlCompras = "UPDATE [Registros] SET [IdConductor] = " & IdConductor & ",[IdLugarAcopio] = " & IdLugarAcopio & ",[Fecha] =  CONVERT(DATETIME, '" & Format(FechaCarga, "yyyy-MM-dd HH:mm:ss") & "', 102) ,[Placa] = '" & Placa & "', [IdTransporte] = '" & IdTransporte & "', [NumeroBoleta] = '" & NumeroBoleta & "', [IdCosecha] = " & IdCosecha & " " & _
                         "WHERE (IdRegistro = '" & ConsecutivoRegistro & "') AND (TipoRegistro = '" & TipoRegistro & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

    End Sub


    Public Sub GrabaCarga(ByVal ConsecutivoCarga As String, ByVal IdConductor As Double, ByVal IdLugarAcopio As Double, ByVal FechaCarga As DateTime, ByVal Placa As String)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Sql As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        'Fecha = Format(FrmCarga.DTPFecha.Value, "yyyy-MM-dd")
        '-----------------------BUSCO EL ULTIMO CODIGO DE LLEGADA DE LA PLACA ---------------
        Dim IdTransporte As String = ""
        Dim Adaptar As New SqlClient.SqlDataAdapter("Select top (1) IdRegistro From Registros Where Placa = '" & Placa & "' and TipoRegistro = 'Llegada' order by IdRegistro DESC ", MiConexion)
        Dim TablaQuery As New DataTable
        Adaptar.Fill(TablaQuery)
        If TablaQuery.Rows.Count > 0 Then
            IdTransporte = TablaQuery.Rows(0)("IdRegistro")
        End If

        '///////////////////////////////////7///////////////////
        '/////////////////////ACTUALIZO EL ESTADO DEL VEHICULO ///////////////
        Dim Command As New SqlClient.SqlCommand("Update Vehiculo set Posicion ='Carga' Where Placa ='" & Placa & "' ", MiConexion)
        MiConexion.Open()
        Command.ExecuteNonQuery()
        MiConexion.Close()

        MiConexion.Close()

        Sql = "SELECT  *  FROM IndiceCarga WHERE (CodCarga = '" & ConsecutivoCarga & "') AND (IdLugarAcopio = " & IdLugarAcopio & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        If DataSet.Tables("DetalleRecepcion").Rows.Count = 0 Then
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCompras = "INSERT INTO [IndiceCarga] ([CodCarga],[IdConductor],[IdLugarAcopio],[Fecha],[Placa],[IdTransporte]) " & _
                         "VALUES ('" & ConsecutivoCarga & "'," & IdConductor & "," & IdLugarAcopio & ",'" & Format(FechaCarga, "dd/MM/yyyy HH:mm:ss") & "','" & Placa & "','" & IdTransporte & "')"

            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Else
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlCompras = "UPDATE [IndiceCarga] SET [IdConductor] = " & IdConductor & ",[IdLugarAcopio] = " & IdLugarAcopio & ",[Placa] = '" & Placa & "',[IdTransporte] = '" & IdTransporte & "'  " & _
                         "WHERE (CodCarga = '" & ConsecutivoCarga & "') AND (IdLugarAcopio = " & IdLugarAcopio & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

    End Sub
    Public Sub GrabaDetalleCarga(ByVal ConsecutivoCarga As String, ByVal NumeroRecepcion As String, ByVal FechaRecepcion As Date, ByVal IdLugarAcopio As Double)
        Dim Sqldetalle As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, MiConexion As New SqlClient.SqlConnection(Conexion), SqlUpdate As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Fecha = Format(CDate(FrmRecepcion.DTPFecha.Text), "yyyy-MM-dd")

        Sqldetalle = "SELECT  *  FROM DetalleCarga WHERE (CodCarga = '" & ConsecutivoCarga & "') AND (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = 'Recepcion')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldetalle, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        If Not DataSet.Tables("DetalleRecepcion").Rows.Count = 0 Then
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL DETALLE DE COMPRAS///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////

        Else

            SqlUpdate = "INSERT INTO [DetalleCarga] ([CodCarga],[NumeroRecepcion],[IdLugarAcopio],[FechaRecepcion],[TipoRecepcion]) " & _
                        "VALUES ('" & ConsecutivoCarga & "' ,'" & NumeroRecepcion & "'," & IdLugarAcopio & ",'" & Format(FechaRecepcion, "dd/MM/yyyy HH:mm:ss") & "','Recepcion')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

    End Sub

    Public Sub GrabaRecepcion(ByVal ConsecutivoRecepcion As String)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Subtotal As Double, Lote As String, TipoProceso As String = "", IdLugarAcopio As Double, NumeroTemporal As Double

        NumeroTemporal = FrmRecepcion.NumeroTemporal

        IdLugarAcopio = FrmRecepcion.IdLugarAcopio
        If My.Forms.FrmRecepcion.OptMaquila.Checked = True Then
            TipoProceso = "MAQUILA"
        Else
            TipoProceso = "EXPASA"
        End If

        Dim DateFecha As DateTime = FrmRecepcion.DTPFecha.Text

        If FrmRecepcion.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
            Fecha = Format(DateFecha, "yyyy-MM-dd") & " " & FrmRecepcion.LblHora.Text
        Else
            Fecha = Format(FrmRecepcion.DtpFechaManual.Value, "yyyy-MM-dd") & " " & Format(FrmRecepcion.DtpHoraManual.Value, "hh:mm:ss tt")
        End If

        'Fecha = Format(CDate(FrmRecepcion.DTPFecha.Text), "yyyy-MM-dd")
        Lote = FrmRecepcion.TxtAno.Text & "-" & FrmRecepcion.TxtMes.Text & "-" & FrmRecepcion.TxtDia.Text & "-" & FrmRecepcion.TxtProveedor.Text & "-" & FrmRecepcion.TxtOrigen.Text & "-" & FrmRecepcion.TxtPila.Text

        If FrmRecepcion.txtsubtotal.Text <> "" Then
            Subtotal = FrmRecepcion.txtsubtotal.Text
        Else
            Subtotal = 0
        End If

        MiConexion.Close()
        SqlCompras = "SELECT Recepcion.* FROM Recepcion WHERE (NumeroRecepcion = '" & ConsecutivoRecepcion & "') AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")
        If DataSet.Tables("Recepcion").Rows.Count = 0 Then

            'If FrmRecepcion.TxtNumeroEnsamble.Text = "-----0-----" Then
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlCompras = "INSERT INTO Recepcion ([NumeroRecepcion],[Fecha],[TipoRecepcion],[Cod_Proveedor],[Conductor] ,[Id_identificacion] ,[Id_Placa],[Cod_Bodega],[Observaciones],[SubTotal],[Lote],[TipoProceso],[IdLugarAcopio],[FechaHora],[IdReciboPergamino]) " & _
                         "VALUES ('" & ConsecutivoRecepcion & "','" & Format(CDate(Fecha), "dd/MM/yyyy") & "', '" & My.Forms.FrmRecepcion.CboTipoRecepcion.Text & "' ,'" & My.Forms.FrmRecepcion.CboCodigoProveedor.Columns(0).Text & "' ,'" & My.Forms.FrmRecepcion.CboConductor.Text & "' ,'" & My.Forms.FrmRecepcion.txtid.Text & "' ,'" & My.Forms.FrmRecepcion.txtplaca.Text & "' ,'" & FrmRecepcion.CboCodigoBodega.Text & "' ,'" & FrmRecepcion.txtobservaciones.Text & "' ,'" & Subtotal & "' ,'" & Lote & "','" & TipoProceso & "', " & IdLugarAcopio & ", '" & Format(CDate(Fecha), "dd/MM/yyyy HH:mm:ss") & "', " & NumeroTemporal & " ) "

            'SqlCompras = "INSERT INTO [Recepcion] ([NumeroRecepcion],[Fecha],[TipoRecepcion],[Cod_Proveedor],[Conductor],[Id_identificacion],[Id_Placa],[Cod_Bodega],[Observaciones],[SubTotal],[Lote]) " & _
            '             "VALUES ('" & ConsecutivoRecepcion & "','" & Format(FrmRecepcion.DTPFecha.Value, "dd/MM/yyyy") & "','" & FrmRecepcion.CboTipoRecepcion.Text & "','" & FrmRecepcion.CboCodigoProveedor.Columns(0).Text & "','" & FrmRecepcion.CboConductor.Text & "', '" & FrmRecepcion.txtid.Text & "','" & FrmRecepcion.txtplaca.Text & "','" & FrmRecepcion.CboCodigoBodega.Columns(0).Text & "','" & FrmRecepcion.txtobservaciones.Text & "','" & Subtotal & "','" & Lote & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            ', [IdReciboPergamino] = " & NumeroTemporal & "
            SqlCompras = "UPDATE [Recepcion] SET [Cod_Proveedor] = '" & FrmRecepcion.CboCodigoProveedor.Columns(0).Text & "',[Conductor] = '" & FrmRecepcion.CboConductor.Text & "',[Id_identificacion] ='" & FrmRecepcion.txtid.Text & "',[Id_Placa] = '" & FrmRecepcion.txtplaca.Text & "',[Observaciones] = '" & FrmRecepcion.txtobservaciones.Text & "',[SubTotal] = '" & Subtotal & "',[Lote] = '" & Lote & "',[TipoProceso] = '" & TipoProceso & "',[IdLugarAcopio] = " & IdLugarAcopio & " " & _
                         "WHERE (NumeroRecepcion = '" & ConsecutivoRecepcion & "') AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

    End Sub
    Public Sub ActualizaDetalleRecepcion(ByVal ConsecutivoRecepcion As String, ByVal TipoRecepcion As String)

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sql As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Fecha As String

        Fecha = Format(CDate(FrmRecepcion.DTPFecha.Text), "yyyy-MM-dd")

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion  " & _
              "WHERE  (NumeroRecepcion = '" & ConsecutivoRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "') "

        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        My.Forms.FrmRecepcion.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
        My.Forms.FrmRecepcion.TrueDBGridComponentes.DataSource = My.Forms.FrmRecepcion.BindingDetalle
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(0).Caption = "Psda"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(1).Caption = "Código"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Button = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Button = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75
    End Sub


    Public Sub GrabaDetalleRecepcion(ByVal ConsecutivoRecepcion As String, ByVal CodigoProducto As String, ByVal Cantidad As Double, ByVal Linea As Double, ByVal Descripcion As String, ByVal Calidad As String, ByVal Estado As String, ByVal Precio As Double, ByVal PesoKg As Double, ByVal TipoRecepcion As String, ByVal Tara As Double, ByVal PesoNetoKg As Double, ByVal QQ As Double, ByVal CalidadCafe As String)
        Dim Sqldetalle As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, MiConexion As New SqlClient.SqlConnection(Conexion), SqlUpdate As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, PesoNetoLb As Double


        PesoNetoLb = Format((PesoNetoKg / 46) * 100, "##,##0.0000")

        If FrmRecepcion.CboTipoDocumento.Text = "Recibo Bascula Manual" Then
            Fecha = Format(CDate(FrmRecepcion.DtpFechaManual.Text), "yyyy-MM-dd")
        Else
            Fecha = Format(CDate(FrmRecepcion.DTPFecha.Text), "yyyy-MM-dd")
        End If


        Sqldetalle = "SELECT Detalle_Recepcion.* FROM Detalle_Recepcion " & _
                     "WHERE (id_Eventos = " & Linea & ") AND (NumeroRecepcion = '" & ConsecutivoRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "') "   'AND (Cod_Productos = '" & CodigoProducto & "')
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldetalle, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        If Not DataSet.Tables("DetalleRecepcion").Rows.Count = 0 Then
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL DETALLE DE COMPRAS///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlUpdate = "UPDATE [Detalle_Recepcion] SET [Cod_Productos] = '" & CodigoProducto & "',[Descripcion_Producto] = '" & Descripcion & "',[Cantidad] = " & Cantidad & ",[PesoKg] = " & PesoKg & ", [Calidad] = '" & Calidad & "', [Estado] = '" & Estado & "', [Precio] = " & Precio & ", [Tara] = " & Tara & ", [PesoNetoLb] = " & PesoNetoLb & ", [PesoNetoKg] = " & PesoNetoKg & " , [QQ] = " & QQ & ", [Calidad_Cafe] = '" & CalidadCafe & "' " & _
                        "WHERE (id_Eventos = " & Linea & ") AND (NumeroRecepcion = '" & ConsecutivoRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Fecha), "yyyy-MM-dd") & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "') "  'AND (Cod_Productos = '" & CodigoProducto & "')
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else

            SqlUpdate = "INSERT INTO [Detalle_Recepcion] ([id_Eventos],[NumeroRecepcion],[Fecha],[TipoRecepcion],[Cod_Productos],[Descripcion_Producto],[Cantidad],[PesoKg],[Calidad],[Estado],[Precio],[Tara],[PesoNetoLb],[PesoNetoKg],[QQ],[Calidad_Cafe]) " & _
                        "VALUES (" & Linea & " ,'" & ConsecutivoRecepcion & "','" & Format(CDate(Fecha), "dd/MM/yyyy") & "','" & My.Forms.FrmRecepcion.CboTipoRecepcion.Text & "','" & CodigoProducto & "','" & Descripcion & "'," & Cantidad & "," & PesoKg & ", '" & Calidad & "','" & Estado & "', " & Precio & ", " & Tara & ", " & PesoNetoLb & ", " & PesoNetoKg & ", " & QQ & ", '" & CalidadCafe & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

    End Sub

    Public Sub LimpiaRecepcion()
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Sql As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)

        FrmRecepcion.NumeroTemporal = FrmRecepcion.Random.Next()

        FrmRecepcion.LimpiarRecibo = True
        FrmRecepcion.ListBoxCertificados.Items.Clear()
        FrmRecepcion.CboPignorado.Items.Clear()
        FrmRecepcion.DTPFecha.Text = Format(Now, "dd/MM/yyyy")
        FrmRecepcion.Timer1.Enabled = True
        FrmRecepcion.CboCodigoProveedor.Text = ""
        FrmRecepcion.TxtNumeroEnsamble.Text = "-----0-----"
        FrmRecepcion.TxtNumeroRecibo.Text = "-----0-----"
        FrmRecepcion.txtobservaciones.Text = ""
        FrmRecepcion.txtsubtotal.Text = ""
        FrmRecepcion.txtnombre.Text = ""
        FrmRecepcion.LblPeso.Text = "0.00"
        FrmRecepcion.TxtEqOreado.Text = "0.00"
        FrmRecepcion.TxtOreadoReal.Text = "0.00"
        FrmRecepcion.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA")
        FrmRecepcion.CboEstadoDocumeto.Text = "Editable"
        FrmRecepcion.CmdConfirma.Enabled = False
        FrmRecepcion.IdReciboCafe = 0
        FrmRecepcion.IdRecibo = 0
        FrmRecepcion.TxtFinca.Text = ""
        FrmRecepcion.TxtNumeroRecepcion.Visible = False
        FrmRecepcion.TxtNumeroEnsamble.Visible = False

        If FrmRecepcion.CboTipoCompra.Text = "Compra Directa" Then
            FrmRecepcion.TxtSerie.Text = "C" & FrmRecepcion.Cod_Cosecha
        End If



        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        Sql = "SELECT  IdFinca, CodFinca, IdProductor, NomFinca, UbicaFinca, FechaMovimiento FROM Finca  WHERE (IdProductor = '-1000000' )"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        FrmRecepcion.CboFinca.DataSource = DataSet.Tables("Consulta")
        FrmRecepcion.CboFinca.DisplayMember = "NomFinca"


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CARGO EL DETALLE DE COMPRAS/////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Sql = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion  WHERE (NumeroRecepcion = N'-100000')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        My.Forms.FrmRecepcion.BindingDetalle.DataSource = DataSet.Tables("DetalleRecepcion")
        My.Forms.FrmRecepcion.TrueDBGridComponentes.DataSource = My.Forms.FrmRecepcion.BindingDetalle
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 40
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(0).Caption = "Psda"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Precio").Visible = False
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(1).Caption = "Código"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Button = False
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 63
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(2).Caption = "Descripción"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 200
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(3).Caption = "Categ"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 50
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(4).Caption = "Estado"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 50
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(5).Caption = "PesoLb"
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("Cantidad").Locked = True
        'Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 85
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Button = False
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 50
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Locked = True
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 75
        My.Forms.FrmRecepcion.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Locked = True


        FrmRecepcion.CboEstadoDocumeto.Text = "Editable"
        FrmRecepcion.CboEstadoDocumeto.Enabled = True
        FrmRecepcion.TrueDBGridComponentes.Enabled = True
        FrmRecepcion.CboTipoCafe.Enabled = True
        FrmRecepcion.CboTipoCalidad.Enabled = True
        FrmRecepcion.CboCodigoProveedor.Enabled = True
        FrmRecepcion.CboTipoCompra.Enabled = True
        FrmRecepcion.CboTipoDocumento.Enabled = True
        FrmRecepcion.CboTipoIngresoBascula.Enabled = True
        FrmRecepcion.CboTipoRecepcion.Enabled = True
        FrmRecepcion.CboCategoria.Enabled = False
        FrmRecepcion.CboDaño.Enabled = True
        FrmRecepcion.CboEstado.Enabled = True
        FrmRecepcion.CboFinca.Enabled = True
        FrmRecepcion.TxtNumeroCedula.Enabled = True
        FrmRecepcion.TxtFinca.Enabled = True
        FrmRecepcion.txtnombre.Enabled = True
        FrmRecepcion.CmdProductorManual.Enabled = True
        FrmRecepcion.Button2.Enabled = True
        FrmRecepcion.Button14.Enabled = True
        FrmRecepcion.Button15.Enabled = True
        FrmRecepcion.CboLocalidad.Enabled = True
        FrmRecepcion.CboLiquidarLocalidad.Enabled = True
        FrmRecepcion.Button16.Enabled = True
        FrmRecepcion.CmdPesada.Enabled = True
        FrmRecepcion.TxtHumedad.Enabled = True
        FrmRecepcion.TxtImperfecion.Enabled = True
        'FrmRecepcion.CmdObservaciones.Enabled = True
        FrmRecepcion.Button11.Enabled = True
        FrmRecepcion.Button10.Enabled = True
        FrmRecepcion.Button7.Enabled = True


    End Sub

    Public Function TotalRecepcion(ByVal NumeroRecepcion As String, ByVal FechaRecepcion As Date, ByVal TipoRecepcion As String) As Double
        Dim Fecha As String, SqlCompras As String, Registros As Double
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, i As Double, Total As Double

        Fecha = Format(FechaRecepcion, "yyyy-MM-dd")
        'SqlCompras = "SELECT  Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida,id_Eventos As Linea  FROM Detalle_Recepcion   WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "') "
        SqlCompras = "SELECT  id_Eventos As Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ As Saco, Precio  FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")
        Registros = DataSet.Tables("Recepcion").Rows.Count
        i = 0
        Total = 0
        Do While Registros > i
            Total = Total + DataSet.Tables("Recepcion").Rows(i)("PesoNetoKg")
            i = i + 1
        Loop

        TotalRecepcion = Format(Total, "##,##0.00")

    End Function



    Public Sub AnulaRecepcion(ByVal ConsecutivoRecepcion As String)
        Dim SqlCompras As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As String, TipoCompra As String, SqlUpdate As String
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Subtotal As Double



        TipoCompra = FrmRecepcion.CboTipoRecepcion.Text
        Fecha = Format(CDate(FrmRecepcion.DTPFecha.Text), "yyyy-MM-dd")

        If FrmRecepcion.txtsubtotal.Text <> "" Then
            Subtotal = FrmRecepcion.txtsubtotal.Text
        Else
            Subtotal = 0
        End If


        MiConexion.Close()

        SqlCompras = "SELECT Recepcion.*, Proveedor.Nombre_Proveedor, SubProveedor.Nombre_Proveedor AS SubProveedor, Bodegas.Nombre_Bodega FROM  Recepcion INNER JOIN Proveedor ON Recepcion.Cod_Proveedor = Proveedor.Cod_Proveedor INNER JOIN SubProveedor ON Recepcion.Cod_SubProveedor = SubProveedor.Cod_Proveedor INNER JOIN Bodegas ON Recepcion.Cod_Bodega = Bodegas.Cod_Bodega  " & _
                      "WHERE (Recepcion.Activo = 1) AND (Recepcion.NumeroRecepcion = '" & FrmRecepcion.TxtNumeroEnsamble.Text & "') AND (Recepcion.Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (Recepcion.TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")
        If Not DataSet.Tables("Recepcion").Rows.Count = 0 Then

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlCompras = "UPDATE [Recepcion] SET [Cancelar] = 'True',[Activo] = 'False' " & _
                         "WHERE (NumeroRecepcion = '" & ConsecutivoRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlCompras, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------
        '----------------------------------------EDITO EL DETALLE DE RECEPCION -----------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------------------------------------------
        MiConexion.Close()

        SqlCompras = "SELECT Detalle_Recepcion.* FROM Detalle_Recepcion " & _
                     "WHERE (NumeroRecepcion = '" & ConsecutivoRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlCompras, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        If Not DataSet.Tables("DetalleRecepcion").Rows.Count = 0 Then

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL DETALLE DE COMPRAS///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            SqlUpdate = "UPDATE [Detalle_Recepcion] SET [Cantidad] = 0 " & _
                        "WHERE (NumeroRecepcion = '" & ConsecutivoRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Fecha & "', 102)) AND (TipoRecepcion = '" & FrmRecepcion.CboTipoRecepcion.Text & "') "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

    End Sub
    Public Function CalcularEqOreado(ByVal idCosecha As Double, ByVal idEstadoFisico As Double) As Boolean
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Factor As Double

        SqlString = "SELECT  IdDeduccionEstadoFisico, PorcentajeDeduccion, EstadoFisico, IdCosecha FROM PorcentajeDeduccionEstadoFisico " & _
                    "WHERE  (EstadoFisico = " & idEstadoFisico & ") AND (IdCosecha = " & idCosecha & ") "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Factor")
        If DataSet.Tables("Factor").Rows.Count <> 0 Then
            Factor = DataSet.Tables("Factor").Rows(0)("PorcentajeDeduccion")
            If Factor >= 1 Then
                CalcularEqOreado = False
            Else
                CalcularEqOreado = True
            End If
        Else
            CalcularEqOreado = False

        End If


    End Function


    Public Sub CalculaTaraRecepcion()
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim IdEsdoFisico As Double, IdCalidad As Double, IdTipoLugarAcopio As Double, Factor As Double, QQ As Double, Tara As Double, PesoNetoKg As Double, PesoNetoLb As Double
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, Cantidad As Double, PesoKg As Double
        Dim Registro As Double, i As Double, SubTotal As Double = 0, HumedadxDefecto As Double, HumedadReal As Double
        Dim Categoria As String, Estado As String, idCosecha As Double



        IdEsdoFisico = My.Forms.FrmRecepcion.IdEstadoFisico
        IdCalidad = My.Forms.FrmRecepcion.IdCalidad
        IdTipoLugarAcopio = My.Forms.FrmRecepcion.IdTipoLugarAcopio
        idCosecha = My.Forms.FrmRecepcion.IdCosecha

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////CONSULTO LAS TARAS /////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT FactorTara FROM FactorSaco WHERE  (IdEdoFisico = " & IdEsdoFisico & " )  AND (IdTipoLugarAcopio = " & IdTipoLugarAcopio & ") AND (IdUMedida = 1) AND (IdCalidad = " & IdCalidad & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Tara")
        If DataSet.Tables("Tara").Rows.Count <> 0 Then
            Factor = DataSet.Tables("Tara").Rows(0)("FactorTara")
        Else
            Factor = 0
        End If


        Categoria = FrmRecepcion.CboCategoria.Text
        Estado = FrmRecepcion.CboEstado.Text
        Registro = FrmRecepcion.TrueDBGridComponentes.RowCount
        i = 0
        FrmRecepcion.TrueDBGridComponentes.Row = i
        SubTotal = 0
        Do While Registro > i
            If FrmRecepcion.TrueDBGridComponentes.Columns(10).Text = "" Then
                Exit Do
            End If


            QQ = FrmRecepcion.TrueDBGridComponentes.Columns(10).Text
            Tara = Factor * QQ
            PesoKg = FrmRecepcion.TrueDBGridComponentes.Columns(6).Text
            PesoNetoKg = Format((PesoKg - Tara), "##,##0.0000")
            PesoNetoLb = Format((PesoNetoKg / 46) * 100, "##,##0.0000")

            FrmRecepcion.TrueDBGridComponentes.Columns(3).Text = Categoria
            FrmRecepcion.TrueDBGridComponentes.Columns(4).Text = Estado
            FrmRecepcion.TrueDBGridComponentes.Columns(7).Text = Format(Tara, "##,##0.00")
            FrmRecepcion.TrueDBGridComponentes.Columns(8).Text = Format(PesoNetoLb, "##,##0.0000")
            FrmRecepcion.TrueDBGridComponentes.Columns(9).Text = Format(PesoNetoKg, "##,##0.0000")

            SubTotal = PesoNetoKg + SubTotal



            i = i + 1
            FrmRecepcion.TrueDBGridComponentes.Row = i
        Loop


        HumedadxDefecto = FrmRecepcion.HumedadxDefecto

        If FrmRecepcion.TxtHumedad.Text <> "" Then
            HumedadReal = FrmRecepcion.TxtHumedad.Text
        Else
            HumedadReal = 0
        End If


        FrmRecepcion.txtsubtotal.Text = Format(SubTotal, "##,##0.00")

        If CalcularEqOreado(idCosecha, IdEsdoFisico) = True Then
            FrmRecepcion.TxtEqOreado.Text = Format(SubTotal * (1 - (HumedadxDefecto - 42) / 100), "##,##0.00")
            FrmRecepcion.TxtOreadoReal.Text = Format(SubTotal * (1 - (HumedadReal - 42) / 100), "##,##0.00")
        Else
            FrmRecepcion.TxtEqOreado.Text = Format(SubTotal, "##,##0.00")
            FrmRecepcion.TxtOreadoReal.Text = Format(SubTotal, "##,##0.00")
        End If



    End Sub

    Public Sub GrabaLecturaPeso(ByVal Peso As Double)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)

        Dim ConsecutivoCompra As Double, NumeroRecepcion As String, Registros As Double, Iposicion As Double
        Dim Linea As Double, CodigoProducto As String, Cantidad As Double, Descripcion As String, CodigoBeams As String, UnidadMedida As String = ""
        Dim CodigoBeamsOrigen As String = "", CodigoRecepcionBin As String = "", Calidad As String, Estado As String, SqlString As String
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, PesoKg As Double, Precio As Double, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Tara As Double = 0, PesoNetoLb As Double = 0, PesoNetoKg As Double = 0, QQ As Double = 0, LugarAcopio As Integer, SubTotal As Double = 0
        Dim HumedadxDefecto As Double = 0, HumedadReal As Double = 0, Consecutivo As Double, NumeroRecibo As String, Cadena As String, CadenaDiv() As String
        Dim CodLugarAcopio As Double, Fecha As Date, NumeroTemporal As Double


        SqlString = "SELECT  LugarAcopio.* FROM LugarAcopio WHERE  (IdLugarAcopio = " & FrmRecepcion.IdLugarAcopio & " ) AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultaLugarAcopio")
        If DataSet.Tables("ConsultaLugarAcopio").Rows.Count <> 0 Then
            CodLugarAcopio = DataSet.Tables("ConsultaLugarAcopio").Rows(0)("CodLugarAcopio")
        Else
            CodLugarAcopio = FrmRecepcion.TxtIdLocalidad.Text
        End If


        NumeroTemporal = FrmRecepcion.NumeroTemporal

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO EL CONSECUTIVO DE LA COMPRA /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        If FrmRecepcion.TxtNumeroEnsamble.Text = "-----0-----" Then
            Select Case FrmRecepcion.CboTipoRecepcion.Text
                Case "Recepcion"
                    ConsecutivoCompra = BuscaConsecutivo("Recepcion", CodLugarAcopio)

                Case "RePesaje"
                    ConsecutivoCompra = BuscaConsecutivo("ReImprime", CodLugarAcopio)
                Case "Lote"
                    ConsecutivoCompra = BuscaConsecutivo("Lote", CodLugarAcopio)
            End Select

            NumeroRecepcion = CodLugarAcopio & "-" & Format(ConsecutivoCompra, "00000#")
        Else
            NumeroRecepcion = FrmRecepcion.TxtNumeroEnsamble.Text
        End If




        ''////////////////////////////////////////////////////////////////////////////////////////////////////////
        ''/////////////////////////////////BUSCO EL CONSECUTIVO DEL RECIBO ///////////////////////////////////////
        ''/////////////////////////////////////////////////////////////////////////////////////////////////////////
        'If FrmRecepcion.TxtNumeroRecibo.Text = "-----0-----" Then
        '    SqlString = "SELECT Codigo FROM ReciboCafePergamino WHERE (IdCosecha = " & FrmRecepcion.IdCosecha & ") AND (IdLocalidad = " & FrmRecepcion.IdLugarAcopio & ") AND (IdTipoCompra = " & FrmRecepcion.IdTipoCompra & ") AND (IdTipoCafe = " & FrmRecepcion.IdTipoCafe & ")  AND (LEN(Codigo) > 9) AND (Codigo LIKE '%" & CodLugarAcopio & "%') ORDER BY Codigo DESC"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "NumeroRecibo")
        '    If DataSet.Tables("NumeroRecibo").Rows.Count <> 0 Then
        '        Cadena = DataSet.Tables("NumeroRecibo").Rows(0)("Codigo")
        '        If Len(Cadena) >= 6 Then
        '            CadenaDiv = Cadena.Split("-")
        '            Consecutivo = CadenaDiv(1)
        '            Consecutivo = Consecutivo + 1
        '        End If
        '    Else
        '        Consecutivo = 1
        '    End If

        '    NumeroRecibo = Format(Consecutivo, "00000#")
        '    FrmRecepcion.TxtNumeroRecibo.Text = NumeroRecibo

        'Else
        '    NumeroRecibo = FrmRecepcion.TxtNumeroRecibo.Text
        'End If


        If FrmRecepcion.CboTipoIngresoBascula.Text = "Manual" Then
            NumeroRecibo = FrmRecepcion.TxtNumeroRecibo.Text
        End If





        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO ENCABEZADO DE RECEPCION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        GrabaRecepcion(NumeroRecepcion)

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////GRABO EL DETALLE DE LA RECEPCION /////////////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////7
        Registros = FrmRecepcion.BindingDetalle.Count
        Iposicion = FrmRecepcion.BindingDetalle.Position
        If My.Forms.FrmRecepcion.TrueDBGridComponentes.Columns(0).Text = "" Then
            Linea = BuscaLinea(NumeroRecepcion, CDate(My.Forms.FrmRecepcion.DTPFecha.Text), My.Forms.FrmRecepcion.CboTipoRecepcion.Text)
        Else
            Linea = FrmRecepcion.TrueDBGridComponentes.Columns(0).Text
        End If

        CodigoProducto = FrmRecepcion.CboIngresoBascula.Columns(0).Text
        Cantidad = Peso
        Descripcion = FrmRecepcion.CboIngresoBascula.Columns(1).Text

        If FrmRecepcion.CboCategoria.Text <> "" Then
            Calidad = FrmRecepcion.CboCategoria.Text
        End If

        'If FrmRecepcion.OptMojado.Checked = True Then
        '    Estado = "Mojado"
        'ElseIf FrmRecepcion.OptHumedo.Checked = True Then
        '    Estado = "Humedo"
        'ElseIf FrmRecepcion.OptOreado.Checked = True Then
        '    Estado = "Oreado"
        'End If

        Estado = FrmRecepcion.CboEstado.Text


        '/////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////CONSULTO EL PRECIO DE VENTA //////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT  Productos.* FROM Productos WHERE (Tipo_Producto <> 'Servicio') AND (Tipo_Producto <> 'Descuento')"
        'DataAdapterProductos = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapterProductos.Fill(DataSet, "Precios")
        'If Not DataSet.Tables("Precios").Rows.Count = 0 Then
        '    Select Case FrmRecepcion.CboTipoProducto.Text
        '        Case "A" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Venta")
        '        Case "B" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Lista")
        '        Case "C" : Precio = DataSet.Tables("Precios").Rows(0)("Precio_Compra")
        '    End Select

        'End If

        'Precio = PrecioVenta(CodigoProducto, FrmRecepcion.IdLugarAcopio, FrmRecepcion.CboCategoria.Text, CDate(FrmRecepcion.DTPFecha.Text))
        If FrmRecepcion.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
            Fecha = Format(CDate(FrmRecepcion.DTPFecha.Text), "yyyy-MM-dd") & " " & FrmRecepcion.LblHora.Text
        Else
            Fecha = Format(CDate(FrmRecepcion.DtpFechaManual.Value), "yyyy-MM-dd") & " " & Format(FrmRecepcion.DtpHoraManual.Value, "hh:mm:ss tt")
        End If

        Precio = PrecioVenta(FrmRecepcion.IdLugarAcopio, FrmRecepcion.IdCalidad, FrmRecepcion.CboCategoria.Text, Fecha)
        Precio = Format(Precio / 46, "##,##0.00")

        '-------------------------------PREGUNTO LOS QUINTALES -----------------------------
        '--------------------------------------------------------------------------------------
        My.Forms.FrmQQ.ShowDialog()
        QQ = My.Forms.FrmQQ.QQ

        '///////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////CONVERTIR DE LIBRAS A KG //////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////
        PesoKg = Cantidad
        Cantidad = Format((Cantidad / 46) * 100, "##,##0.00")

        Dim Factor As Double = 0, IdEsdoFisico As Double = 0, IdCalidad As Double = 0, IdTipoLugarAcopio As Double = 0

        '////////////////////////////////////BUSCO EL ESTADO FISICO ///////////////////////////////////////////////////


        IdEsdoFisico = My.Forms.FrmRecepcion.IdEstadoFisico
        IdCalidad = My.Forms.FrmRecepcion.IdCalidad
        IdTipoLugarAcopio = My.Forms.FrmRecepcion.IdTipoLugarAcopio

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////CONSULTO LAS TARAS /////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT FactorTara FROM FactorSaco WHERE  (IdEdoFisico = " & IdEsdoFisico & " )  AND (IdTipoLugarAcopio = " & IdTipoLugarAcopio & ") AND (IdUMedida = 1) AND (IdCalidad = " & IdCalidad & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Tara")
        If DataSet.Tables("Tara").Rows.Count <> 0 Then
            Factor = DataSet.Tables("Tara").Rows(0)("FactorTara")
        Else
            Factor = 0
        End If


        Tara = Factor * QQ


        'If FrmRecepcion.CboTipoCalidad.Text = "AP1ra" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "AP2da" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "BROZA" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "FRUTO" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "PULPON" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'ElseIf FrmRecepcion.CboTipoCalidad.Text = "MP1ra" Then
        '    Select Case Estado
        '        Case "Mojado" : Tara = 0.46 * QQ
        '        Case "Humedo" : Tara = 0.23 * QQ
        '        Case "Oreado" : Tara = 0.23 * QQ
        '    End Select
        'End If

        PesoNetoKg = Format((PesoKg - Tara), "##,##0.0000")
        PesoNetoLb = Format((PesoNetoKg / 46) * 100, "##,##0.0000")

        GrabaDetalleRecepcion(NumeroRecepcion, CodigoProducto, Cantidad, Linea, Descripcion, Calidad, Estado, Precio, PesoKg, FrmRecepcion.CboTipoRecepcion.Text, Tara, PesoNetoKg, QQ, FrmRecepcion.CboTipoCalidad.Text)
        ActualizaDetalleRecepcion(NumeroRecepcion, FrmRecepcion.CboTipoRecepcion.Text)


        FrmRecepcion.TrueDBGridComponentes.Columns(1).Text = CodigoProducto
        FrmRecepcion.TrueDBGridComponentes.Columns(2).Text = Descripcion
        FrmRecepcion.TrueDBGridComponentes.Columns(3).Text = Calidad
        FrmRecepcion.TrueDBGridComponentes.Columns(4).Text = Estado
        FrmRecepcion.TrueDBGridComponentes.Columns(5).Text = Cantidad
        FrmRecepcion.TrueDBGridComponentes.Columns(6).Text = PesoKg
        FrmRecepcion.TrueDBGridComponentes.Columns(7).Text = Tara
        FrmRecepcion.TrueDBGridComponentes.Columns(8).Text = PesoNetoLb
        FrmRecepcion.TrueDBGridComponentes.Columns(9).Text = PesoNetoKg
        FrmRecepcion.TrueDBGridComponentes.Columns(10).Text = QQ
        FrmRecepcion.TrueDBGridComponentes.Columns(11).Text = Precio
        FrmRecepcion.TrueDBGridComponentes.Columns(0).Text = Linea
        FrmRecepcion.TxtNumeroEnsamble.Text = NumeroRecepcion
        'FrmRecepcion.TxtNumeroRecibo.Text = NumeroRecibo


        Iposicion = FrmRecepcion.TrueDBGridComponentes.Row
        FrmRecepcion.TrueDBGridComponentes.Row = FrmRecepcion.TrueDBGridComponentes.Row + 1
        FrmRecepcion.TrueDBGridComponentes.Columns(1).Text = CodigoProducto
        FrmRecepcion.TrueDBGridComponentes.Columns(2).Text = Descripcion
        FrmRecepcion.TrueDBGridComponentes.Col = 5


        FrmRecepcion.txtsubtotal.Text = TotalRecepcion(FrmRecepcion.TxtNumeroEnsamble.Text, FrmRecepcion.DTPFecha.Text, FrmRecepcion.CboTipoRecepcion.Text)


        ''////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD /////////////////////////////////////
        'SqlString = "SELECT  EstadoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto  FROM EstadoFisico WHERE (Descripcion = '" & FrmRecepcion.CboEstado.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        '    HumedadxDefecto = DataSet.Tables("Consulta").Rows(0)("HumedadXDefecto")
        'End If

        SubTotal = FrmRecepcion.txtsubtotal.Text
        HumedadxDefecto = FrmRecepcion.HumedadxDefecto
        HumedadReal = FrmRecepcion.TxtHumedad.Text

        If CalcularEqOreado(My.Forms.FrmRecepcion.IdCosecha, IdEsdoFisico) = True Then
            FrmRecepcion.TxtEqOreado.Text = Format(SubTotal * (1 - (HumedadxDefecto - 42) / 100), "##,##0.00")
            FrmRecepcion.TxtOreadoReal.Text = Format(SubTotal * (1 - (HumedadReal - 42) / 100), "##,##0.00")
        Else
            FrmRecepcion.TxtEqOreado.Text = Format(SubTotal, "##,##0.00")
            FrmRecepcion.TxtOreadoReal.Text = Format(SubTotal, "##,##0.00")
        End If




    End Sub
    Public Sub ConsecutivoRecibo(ByVal TipoIngreso As String)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)

        Dim ConsecutivoCompra As Double, NumeroRecepcion As String, Registros As Double, Iposicion As Double
        Dim DataSet As New DataSet, DataAdapterProductos As New SqlClient.SqlDataAdapter, PesoKg As Double, Precio As Double, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroRecibo As String, Cadena As String, CadenaDiv() As String, Consecutivo As Double
        Dim SqlString As String, CodLugarAcopio As String

        If TipoIngreso = "Manual" Then
            Exit Sub
        End If


        SqlString = "SELECT  LugarAcopio.* FROM LugarAcopio WHERE  (IdLugarAcopio = " & FrmRecepcion.IdLugarAcopio & " ) AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultaLugarAcopio")
        If DataSet.Tables("ConsultaLugarAcopio").Rows.Count <> 0 Then
            CodLugarAcopio = DataSet.Tables("ConsultaLugarAcopio").Rows(0)("CodLugarAcopio")
        Else
            CodLugarAcopio = FrmRecepcion.TxtIdLocalidad.Text
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////BUSCO EL CONSECUTIVO DEL RECIBO ///////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////
        If FrmRecepcion.TxtNumeroRecibo.Text = "-----0-----" Or FrmRecepcion.TxtNumeroRecibo.Text = "" Then
            SqlString = "SELECT Codigo FROM ReciboCafePergamino WHERE (IdCosecha = " & FrmRecepcion.IdCosecha & ") AND (IdLocalidad = " & FrmRecepcion.IdLugarAcopio & ") AND (IdTipoCompra = " & FrmRecepcion.IdTipoCompra & ") AND (IdTipoCafe = " & FrmRecepcion.IdTipoCafe & ")  AND (LEN(Codigo) > 9) AND (Codigo LIKE '%" & CodLugarAcopio & "%') ORDER BY Codigo DESC"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "NumeroRecibo")
            If DataSet.Tables("NumeroRecibo").Rows.Count <> 0 Then
                Cadena = DataSet.Tables("NumeroRecibo").Rows(0)("Codigo")
                If Len(Cadena) <= 10 Then
                    CadenaDiv = Cadena.Split("-")
                    Consecutivo = CadenaDiv(1)
                    Consecutivo = Consecutivo + 1
                ElseIf Len(Cadena) > 10 Then
                    CadenaDiv = Cadena.Split("-")
                    Consecutivo = CadenaDiv(2)
                    Consecutivo = Consecutivo + 1
                End If
            Else
                Consecutivo = 1
            End If

            NumeroRecibo = Format(Consecutivo, "00000#")
            FrmRecepcion.TxtNumeroRecibo.Text = NumeroRecibo

        Else
            NumeroRecibo = FrmRecepcion.TxtNumeroRecibo.Text
        End If
    End Sub




    Public Function PrecioVenta(ByVal IdLugarAcopio As Double, ByVal IdCalidad As Double, ByVal Categoria As String, ByVal FechaCorte As Date) As Double
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim SqlString As String
        Dim Adapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, Registros As Double, i As Double
        'Dim FechaCorte As Date

        'FechaCorte = Now
        '//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
        SqlString = "SELECT PrecioCafe.IdPrecioCafe, PrecioCafe.IdLocalidad, PrecioCafe.IdCalidad, PrecioCafe.IdRangoImperfeccion, PrecioCafe.Precio, PrecioCafe.FechaActualizacion,  RangoImperfeccion.Nombre FROM PrecioCafe INNER JOIN RangoImperfeccion ON PrecioCafe.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE  (PrecioCafe.IdLocalidad = " & IdLugarAcopio & ") AND (PrecioCafe.IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = '" & Categoria & "') AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY RangoImperfeccion.Nombre, PrecioCafe.FechaActualizacion DESC"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "ConsultaA")
        PrecioVenta = 0
        If DataSet.Tables("ConsultaA").Rows.Count <> 0 Then
            PrecioVenta = DataSet.Tables("ConsultaA").Rows(0)("Precio")
        Else
            PrecioVenta = 0.0
            'NumCorte = DataSet.Tables("ConsultaA").Rows(0)("Corte")
        End If



    End Function



    Public Function BuscaLinea(ByVal NumeroRecepcion As String, ByVal FechaRecepcion As Date, ByVal TipoRecepcion As String) As Double
        Dim Sql As String, Fecha As Date
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim MiConexion As New SqlClient.SqlConnection(Conexion), Registros As Double, i As Double, j As Double
        Dim iResultado As Integer, SqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, Linea As Double = 0

        Fecha = Format(FechaRecepcion, "yyyy-MM-dd")

        Sql = "SELECT  Detalle_Recepcion.* FROM Detalle_Recepcion WHERE (NumeroRecepcion = '" & NumeroRecepcion & "')  AND (TipoRecepcion = '" & TipoRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FechaRecepcion, "yyyy-MM-dd") & "', 102))"
        'Sql = "SELECT id_Eventos, NumeroRecepcion, Fecha, TipoRecepcion, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, Liquidado,  Codigo_BeamsOrigen, RecepcionBin, Transferido, Calidad, Estado, Precio, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ, Calidad_Cafe FROM Detalle_Recepcion " & _
        '      "WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (TipoRecepcion = '" & TipoRecepcion & "') AND (Fecha = CONVERT(DATETIME,  '" & Format(Fecha, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecepcion")
        Registros = DataSet.Tables("DetalleRecepcion").Rows.Count
        i = 0
        j = 1
        Do While Registros > i
            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////EDITO EL DETALLE DE COMPRAS///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            Linea = DataSet.Tables("DetalleRecepcion").Rows(i)("id_Eventos")
            SqlUpdate = "UPDATE [Detalle_Recepcion]  SET [id_Eventos] = " & j & " " & _
                        "WHERE (NumeroRecepcion = '" & NumeroRecepcion & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FechaRecepcion, "yyyy-MM-dd") & "', 102)) AND (TipoRecepcion = '" & TipoRecepcion & "') AND (id_Eventos = " & Linea & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            i = i + 1
            j = j + 1
        Loop
        BuscaLinea = j

    End Function

    Public Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim strFileName As String = filepath, Registros As Double
        If System.IO.File.Exists(strFileName) Then
            If (MessageBox.Show("Querés exportar en el archivo existente?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
                System.IO.File.Delete(strFileName)
            Else
                Return
            End If

        End If
        Dim _excel As New Excel.Excel.Application
        Dim wBook As Excel.Excel.Workbook
        Dim wSheet As Excel.Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0, ColGrid As Integer
        Dim rowIndex As Integer = 3
        Dim rnd As New Random


        wSheet.Cells(1, 1) = "EXPORTADORA ATLANTIC"
        wSheet.Cells(2, 1) = "REPORTE DE TRAZABILIDAD"
        wSheet.Cells(3, 1) = "IMPRESO DESDE " & Format(My.Forms.FrmConsultaReporte.dtpFechaInicio.Value, "dd/MM/yyyy") & " HASTA " & Format(My.Forms.FrmConsultaReporte.dtpFechaFin.Value, "dd/MM/yyyy")
        wSheet.Range("A1:AN1").Merge()
        wSheet.Range("A1:AN1").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A1:AN1").VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A1:AN1").VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A1:AN1").Font.Size = 26
        wSheet.Range("A1:AN1").Font.Bold = True

        wSheet.Range("A2:AN2").Merge()
        wSheet.Range("A2:AN2").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A2:AN2").VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A2:AN2").Font.Size = 20
        wSheet.Range("A2:AN2").Font.Bold = True

        wSheet.Range("A3:AN3").Merge()
        wSheet.Range("A3:AN3").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A3:AN3").VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A3:AN3").Font.Size = 20
        wSheet.Range("A3:AN3").Font.Bold = True


        wSheet.Range("A4:AM4").WrapText = True

        wSheet.Range("A4:AM4").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A4:AM4").VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter
        wSheet.Range("A4:AM4").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

        wSheet.Columns("A").ColumnWidth = 30.86
        wSheet.Columns("B").ColumnWidth = 27.57
        wSheet.Columns("C").ColumnWidth = 10.71
        wSheet.Columns("D").ColumnWidth = 27
        wSheet.Columns("E").ColumnWidth = 10.71
        wSheet.Columns("F").ColumnWidth = 15.43
        wSheet.Columns("G").ColumnWidth = 15.43
        wSheet.Columns("H").ColumnWidth = 15.43
        wSheet.Columns("I").ColumnWidth = 19.86
        wSheet.Columns("J").ColumnWidth = 10.71
        wSheet.Columns("J").NumberFormat = "@"
        wSheet.Columns("K").ColumnWidth = 10.71
        wSheet.Columns("K").NumberFormat = "@"

        wSheet.Columns("L").ColumnWidth = 19.71
        wSheet.Columns("M").ColumnWidth = 20.57
        wSheet.Columns("N").ColumnWidth = 19.86
        wSheet.Columns("O").ColumnWidth = 30.86
        wSheet.Columns("P").ColumnWidth = 27.57
        wSheet.Columns("Q").ColumnWidth = 10.71
        wSheet.Columns("R").ColumnWidth = 10.71
        wSheet.Columns("S").ColumnWidth = 15.43
        wSheet.Columns("T").ColumnWidth = 15.43
        wSheet.Columns("U").ColumnWidth = 15.43
        wSheet.Columns("V").ColumnWidth = 15.43
        wSheet.Columns("W").ColumnWidth = 10.71
        wSheet.Columns("W").NumberFormat = "@"
        wSheet.Columns("X").ColumnWidth = 10.71
        wSheet.Columns("X").NumberFormat = "@"

        wSheet.Columns("Y").ColumnWidth = 15.43
        wSheet.Columns("Z").ColumnWidth = 15.43
        wSheet.Columns("AA").ColumnWidth = 15.43
        wSheet.Columns("AB").ColumnWidth = 15.43

        wSheet.Columns("AC").ColumnWidth = 10.71
        wSheet.Columns("AD").ColumnWidth = 10.71
        wSheet.Columns("AE").ColumnWidth = 10.71
        wSheet.Columns("AF").ColumnWidth = 10.71
        wSheet.Columns("AG").ColumnWidth = 10.71
        wSheet.Columns("AH").ColumnWidth = 10.71
        wSheet.Columns("AI").ColumnWidth = 10.71
        wSheet.Columns("AJ").ColumnWidth = 10.71
        wSheet.Columns("AL").ColumnWidth = 10.71

        wSheet.Columns("AM").ColumnWidth = 13


        ColGrid = 0
        For Each dc In dt.Columns
            colIndex = colIndex + 1
            wSheet.Cells(4, colIndex) = My.Forms.FrmConsultaReporte.TrueDBGridConsultas.Columns(ColGrid).Caption    'dc.ColumnName

            With (wSheet)
                '.Range(.Cells(rowIndex + 1, colIndex), .Cells(rowIndex + 1, colIndex)).Interior.Color = RGB(rnd.Next(255), rnd.Next(255), rnd.Next(255))
                .Range(.Cells(rowIndex + 1, colIndex), .Cells(rowIndex + 1, colIndex)).Interior.Color = RGB(255, 118, 0)
                .Cells(rowIndex + 1, colIndex).WrapText = True
            End With

            ColGrid = ColGrid + 1
        Next

        My.Application.DoEvents()
        Registros = dt.Rows.Count
        FrmConsultaReporte.ProgressBar1.Minimum = 0
        FrmConsultaReporte.ProgressBar1.Maximum = Registros
        FrmConsultaReporte.ProgressBar1.Value = 0


        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0

            My.Application.DoEvents()
            Registros = dt.Columns.Count
            FrmConsultaReporte.ProgressBar2.Minimum = 0
            FrmConsultaReporte.ProgressBar2.Maximum = Registros
            FrmConsultaReporte.ProgressBar2.Value = 0


            '

            For Each dc In dt.Columns
                colIndex = colIndex + 1
                wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                With (wSheet)
                    '.Range(.Cells(1, 1), .Cells(1, 2)).Font.ColorIndex = 3
                    '.Range(.Cells(1, 1), .Cells(rowIndex + 1, colIndex)).Interior.Color = 3
                    .Range(.Cells(4, 1), .Cells(4, colIndex)).Font.Size = 12
                    .Range(.Cells(4, 1), .Cells(4, colIndex)).Font.Bold = True
                    .Cells.RowHeight = 45
                    If colIndex = 4 Then
                        .Range(.Cells(rowIndex + 1, colIndex), .Cells(rowIndex + 1, colIndex)).Interior.Color = RGB(204, 255, 204)
                    ElseIf colIndex > 4 And colIndex <= 11 Then
                        .Range(.Cells(rowIndex + 1, colIndex), .Cells(rowIndex + 1, colIndex)).Interior.Color = RGB(184, 204, 228)
                    ElseIf colIndex > 11 And colIndex <= 24 Then
                        .Range(.Cells(rowIndex + 1, colIndex), .Cells(rowIndex + 1, colIndex)).Interior.Color = RGB(248, 203, 173)
                    ElseIf colIndex > 24 And colIndex <= 28 Then
                        .Range(.Cells(rowIndex + 1, colIndex), .Cells(rowIndex + 1, colIndex)).Interior.Color = RGB(174, 170, 170)
                    ElseIf colIndex > 28 And colIndex <= 38 Then
                        .Range(.Cells(rowIndex + 1, colIndex), .Cells(rowIndex + 1, colIndex)).Interior.Color = RGB(255, 230, 153)
                    ElseIf colIndex = 39 Then
                        .Range(.Cells(rowIndex + 1, colIndex), .Cells(rowIndex + 1, colIndex)).Interior.Color = RGB(112, 173, 71)
                    End If


                End With

                FrmConsultaReporte.ProgressBar2.Value = FrmConsultaReporte.ProgressBar2.Value + 1

            Next

            FrmConsultaReporte.ProgressBar1.Value = FrmConsultaReporte.ProgressBar1.Value + 1
        Next
        'wSheet.Columns.AutoFit()   AJUTA EL ACHO DE LA COLUMNA
        wBook.SaveAs(strFileName)


        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)

        GC.Collect()

        MessageBox.Show("Archivo exportado correctamente")
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

End Module
