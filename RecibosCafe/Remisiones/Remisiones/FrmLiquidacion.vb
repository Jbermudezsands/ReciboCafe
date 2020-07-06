Public Class FrmLiquidacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    'Base de datos 
    Public sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String, NumeroRecibo As String, Cod_Cosecha As String
    Public LocalidadCbo As String, TipoIngresoCbo As String, TipoCompraCbo As String, ImprimirConfirmado As Boolean = True, EsProductorManual As Boolean = False, Cedula As String, EsReciboManual As Boolean = False
    'ids de los datos 
    Public IdLugarAcopio As Double = 0, IdProductor As Double, IdCalidad As Double, IdCosecha As Double, IdDano As Double
    Public IdLocalidadLiqui As Double, IdEdoFisico As Double, IdTipoIngreso As Double, IdTipoCompra As Double, Idliquidacion As Double
    Public IdCategoria As Double, IdMunicipio As Double, IdRegion As Double, IdMoneda As Double, IdEstaDocumento As Double, IdTipoCambio As Double
    'otras variables 
    Public Porcentaje As Double, totalCor As Double, totalDol As Double, ImpMuniC As Double, ImpMuniD As Double, RetDefC As Double, RetDefD As Double, Salir As Boolean
    Public Ret3C As Double, Ret3D As Double, valorCor As Double, ValorDol As Double, TotalDecC As Double, TotalDecD As Double, NetoPagarC As Double
    Public NetoPagarD As Double, Reten2C As Double, Reten2D As Double, Precio As Double, Fecha As Date, IdFinca As Double, TasaCambio As Double, SumaAbono As Double
    Public count1 As Integer, count2 As Integer, PrecioAnterior As Double, NumEnsambleJust As String, CambioPrecio As Boolean = False, codigoProveedor As String
    Private Sub ValidaDistribuicion()
        Dim ContarGrid As Double, i As Double, Monto As Double

        ContarGrid = 0
        i = 0
        ContarGrid = Me.TDBGRidDistribucion.RowCount
        Do While ContarGrid > i
            'Me.TDBGRidDistribucion.Row = i
            If IsDBNull(Me.TDBGRidDistribucion.Item(i)("Monto")) Then
                'i = i + 1
            Else
                Monto = CDbl(Me.TDBGRidDistribucion.Item(i)("Monto")) + Monto
                Monto = Format(Monto, "####0.00")

            End If

            If IsDBNull(Me.TDBGRidDistribucion.Item(i)("TipoPago")) Then
                Me.TDBGRidDistribucion.Item(i)("TipoPago") = "Efectivo"
                Me.TDBGRidDistribucion.Item(i)("Concepto") = "Efectivo"
                Me.TDBGRidDistribucion.Item(i)("Monto") = 0.0
            End If

            If IsDBNull(Me.TDBGRidDistribucion.Item(i)("Concepto")) Then
                Me.TDBGRidDistribucion.Item(i)("TipoPago") = "Efectivo"
                Me.TDBGRidDistribucion.Item(i)("Concepto") = "Efectivo"
                Me.TDBGRidDistribucion.Item(i)("Monto") = 0.0
            End If

            i = i + 1
        Loop
        If Monto > CDbl(Me.TxtTotalDol.Text) Then
            MsgBox("El total de distribucion es mayor a lo digitado", MsgBoxStyle.Critical, "Liquidacion")
            Me.TDBGRidDistribucion.Columns("Monto").Text = 0.0
        End If

        sumagriddistribucion()

    End Sub



    Private Sub CalcularImpuesto()

        Dim PesoBruto As Double
        Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double, ResultadoC As Double, ResultadoD As Double, TipoImpuesto As String
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, ContaTrue As Double


        ImpMuniC = 0
        RetDefC = 0
        Ret3C = 0
        Reten2C = 0

        ImpMuniD = 0
        RetDefD = 0
        Ret3D = 0
        Reten2D = 0


        i = 0
        PesoBruto = 0
        valorCor = 0
        ValorDol = 0
        Registros = Me.TDGridDetalleRecibos.RowCount
        Do While Registros > i
            If Me.TDGridDetalleRecibos.Item(i)("Aplicar") = True Then
                '____________________________________________
                'CONTADOR PARA VER CUANTOS VERDADEROS SON 
                '____________________________________________
                ContaTrue = ContaTrue + 1

                PesoBruto = Me.TDGridDetalleRecibos.Item(i)("PesoNeto") + PesoBruto
                valorCor = Me.TDGridDetalleRecibos.Item(i)("ValorBrutoC$") + valorCor
                ValorDol = Me.TDGridDetalleRecibos.Item(i)("ValorBruto$") + ValorDol
                i = i + 1
            Else
                i = i + 1
            End If
        Loop

        Me.LblTotalPesoKG.Text = "= " + Format(PesoBruto, "##,##0.00")
        Me.LblValorC.Text = "= " + Format(valorCor, "##,##0.00")
        Me.TxtValorBrutoCor.Text = "= " + Format(ValorDol, "##,##0.00")

        totalCor = Mid(Me.LblValorC.Text, 3, Len(Me.LblValorC.Text))
        totalDol = Mid(Me.TxtValorBrutoCor.Text, 3, Len(Me.TxtValorBrutoCor.Text))


        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((CALCULO LOS IMPUESTOS MUNICIPALES (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkpor1.Checked = True Then
            TipoImpuesto = "Imp. Municipal"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto1")

            Porcentaje = DataSet.Tables("Impuesto1").Rows(0)("Valor")

            ImpMuniC = Porcentaje * totalCor
            ImpMuniD = Porcentaje * totalDol
        Else
            ImpMuniC = 0
            ImpMuniD = 0
        End If


        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION DEFINITIVA (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkpor2.Checked = True Then
            TipoImpuesto = "Retención Definitiva"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto2")
            Porcentaje = DataSet.Tables("Impuesto2").Rows(0)("Valor")
            RetDefC = Porcentaje * totalCor
            RetDefD = Porcentaje * totalDol

            Me.TxtRentDefC.Text = Format(RetDefC, "##,##0.00")
            Me.TxtRentDefD.Text = Format(RetDefD, "##,##0.00")
        Else
            RetDefC = 0
            RetDefD = 0
            Me.TxtRentDefC.Text = "0.00"
            Me.TxtRentDefD.Text = "0.00"
        End If


        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION 3% (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkpor3.Checked = True Then
            TipoImpuesto = "Retención 3%"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto3")
            Porcentaje = DataSet.Tables("Impuesto3").Rows(0)("Valor")
            Ret3C = Porcentaje * totalCor
            Ret3D = Porcentaje * totalDol
        Else
            Ret3C = 0
            Ret3D = 0
        End If

        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION 2% (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkbox4.Checked = True Then
            TipoImpuesto = "Retención 2%"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto4")

            Porcentaje = DataSet.Tables("Impuesto4").Rows(0)("Valor")
            Reten2C = Porcentaje * totalCor
            Reten2D = Porcentaje * totalDol
        Else
            Reten2C = 0
            Reten2D = 0
        End If

        TotalDecC = ImpMuniC + RetDefC + Ret3C + Reten2C
        TotalDecD = ImpMuniD + RetDefD + Ret3D + Reten2D

        Me.TxtTotalDecC.Text = Format(TotalDecC, "##,##0.00")
        Me.TxtTotalDecD.Text = Format(TotalDecD, "##,##0.00")

        NetoPagarC = totalCor - TotalDecC
        NetoPagarD = totalDol - TotalDecD

        Me.TxtTotalCor.Text = Format(NetoPagarC, "##,##0.00")
        Me.TxtTotalDol.Text = Format(NetoPagarD, "##,##0.00")


    End Sub

    Private Sub GrabaLiquidacion(ByVal IdLiquida As Double, ByVal NumEnsamble As String, ByVal FechaLiqui As Date, ByVal Precio As Double)
        MiConexion.Close()
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, TipoImpuesto As String, IdImpuestos As Double
        Dim StrSqlInsert As String, SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlString = "Select * FROM LiquidacionPergamino WHERE (IdLiquidacionPergamino = '" & IdLiquida & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ValidaLiquida")

        If DataSet.Tables("ValidaLiquida").Rows.Count <> 0 Then
            StrSqlInsert = "UPDATE [dbo].[LiquidacionPergamino]   SET [Fecha] = '" & Format(CDate(FechaLiqui), "dd/MM/yyyy HH:mm:ss") & "'  ,[Precio] = '" & Precio & "'  ,[IdEstadoDocumento] = '" & IdEstaDocumento & "' ,  [TotalDeducciones] ='" & CDbl(Me.TxtTotalDecC.Text) & "'   ,[IdTipoCambio]=  '" & IdTipoCambio & "'WHERE (IdLiquidacionPergamino = '" & IdLiquida & "') "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Else
            'GUARDO LIQUIDACION 
            '__________________________________________________________________________________________________________________________________________________________
            If Me.TxtSerie.Text = "" Or Me.TxtSerie.Text = " " Then
                Me.TxtSerie.Text = "?"
            End If
            MiConexion.Close()
            StrSqlInsert = "INSERT INTO [dbo].[LiquidacionPergamino]([Codigo],[Fecha],[Precio],[IdEstadoFisico],[IdCategoriaImperfeccion],[IdEstadoDocumento],[IdMoneda],[IdMonedaPreecio],[IdMunicipio],[SincronizadoESC],[NumeroReembolso],[IdTipoIngreso],[IdCosecha],[IdLocalidad],[IdTipoCompra],[Cod_Proveedor] ,[TotalDeducciones]  ,[IdTipoCambio],[Serie2] )" & _
                                  " VALUES('" & NumEnsamble & "','" & Format(CDate(FechaLiqui), "dd/MM/yyyy HH:mm:ss") & "','" & Precio & "','" & IdEdoFisico & "','" & IdCategoria & "','" & IdEstaDocumento & "','" & IdMoneda & "','" & IdTipoCambio & "','" & IdMunicipio & "','0','" & Me.TxtReembolso.Text & "','" & IdTipoIngreso & "','" & IdCosecha & "','" & IdLocalidadLiqui & "','" & IdTipoCompra & "','" & IdProductor & "','" & CDbl(Me.TxtTotalDecC.Text) & "','" & IdTipoCambio & "', '" & Me.TxtSerie.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If


        '/////////////////////////////BUSCO EL ID DE LA LIQUIDACION GRABADA ///////////////////////////////////////////
        sql = "SELECT  LiquidacionPergamino.*  FROM LiquidacionPergamino   " & _
              "WHERE (Codigo = '" & NumEnsamble & "') AND (Cod_Proveedor = '" & IdProductor & "') AND (IdLocalidad = '" & IdLocalidadLiqui & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(FechaLiqui), "yyyy-MM-dd HH:mm:ss") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdLiquida = DataSet.Tables("Consulta").Rows(0)("IdLiquidacionPergamino")
            Idliquidacion = DataSet.Tables("Consulta").Rows(0)("IdLiquidacionPergamino")
        End If

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////GRABO LA TABLA DE IMPUESTOS //////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Me.Checkpor1.Checked = True Then
            TipoImpuesto = "Municipal"
            SqlString = "SELECT IdImpuesto,Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion LIKE '%" & TipoImpuesto & "%')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto1")
            If DataSet.Tables("Impuesto1").Rows.Count <> 0 Then
                IdImpuestos = DataSet.Tables("Impuesto1").Rows(0)("IdImpuesto")
            Else
                IdImpuestos = 0
            End If

            GrabaImpuestos(IdLiquida, IdImpuestos, IdUsuario)



        End If


        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION DEFINITIVA (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkpor2.Checked = True Then
            TipoImpuesto = "Retención Definitiva"
            SqlString = "SELECT  IdImpuesto, Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto2")
            If DataSet.Tables("Impuesto2").Rows.Count <> 0 Then
                IdImpuestos = DataSet.Tables("Impuesto2").Rows(0)("IdImpuesto")
            Else
                IdImpuestos = 0
            End If

            GrabaImpuestos(IdLiquida, IdImpuestos, IdUsuario)
        End If


        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION 3% (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkpor3.Checked = True Then
            TipoImpuesto = "Retención 3%"
            SqlString = "SELECT  IdImpuesto, Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto3")
            If DataSet.Tables("Impuesto3").Rows.Count <> 0 Then
                IdImpuestos = DataSet.Tables("Impuesto3").Rows(0)("IdImpuesto")
            Else
                IdImpuestos = 0
            End If

            GrabaImpuestos(IdLiquida, IdImpuestos, IdUsuario)
        End If

        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION 2% (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkbox4.Checked = True Then
            TipoImpuesto = "Retención 2%"
            SqlString = "SELECT  IdImpuesto, Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto4")
            If DataSet.Tables("Impuesto4").Rows.Count <> 0 Then
                IdImpuestos = DataSet.Tables("Impuesto4").Rows(0)("IdImpuesto")
            Else
                IdImpuestos = 0
            End If

            GrabaImpuestos(IdLiquida, IdImpuestos, IdUsuario)
        End If



    End Sub
    Private Sub GrabaImpuestos(ByVal idLiquidacion As Double, ByVal idImpuestos As Double, ByVal IdUsuario As Double)
        Dim Sql As String, StrSqlInsert As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        Sql = "SELECT  LiquidacionPergaminoImpuesto.* FROM LiquidacionPergaminoImpuesto WHERE  (IdLiquidacionPergamino = " & idLiquidacion & ") AND (IdImpuesto = " & idImpuestos & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Impuesto")
        MiConexion.Close()
        If DataSet.Tables("Impuesto").Rows.Count = 0 Then
            MiConexion.Open()
            StrSqlInsert = "INSERT INTO LiquidacionPergaminoImpuesto ([IdLiquidacionPergamino] ,[IdImpuesto],[IdUsuarioEcs]) " & _
                           "VALUES (" & idLiquidacion & " , " & idImpuestos & " ," & IdUsuario & ")"
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Else

            MiConexion.Open()
            StrSqlInsert = "UPDATE [LiquidacionPergaminoImpuesto]  SET [IdLiquidacionPergamino] = " & idLiquidacion & " ,[IdImpuesto] = " & idImpuestos & " ,[IdUsuarioEcs] = " & IdUsuario & "  " & _
                           "WHERE  (IdLiquidacionPergamino = " & idLiquidacion & ") AND (IdImpuesto = " & idImpuestos & ")"
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If


    End Sub

    Private Sub FrmLiquidacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub



    Private Sub FrmLiquidacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Respuesta As Double = 0
        Respuesta = MsgBox("Esta Seguro de Salir?", MsgBoxStyle.YesNo, "Sistema Bascula")
        If Respuesta <> 6 Then
            e.Cancel = True
        End If

        Quien2 = ""
        Quien3 = ""


    End Sub
    Private Sub FrmLiquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim Ruta As String, LeeArchivo As String
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, i As Integer, count As Double, TipoImp As String



        'Quien = "Load"
        'If UsuarioType = "AutorizaPrecioDiscrecionalidad" Or UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then
        '    Me.Button7.Visible = True
        'Else
        '    Me.Button7.Visible = False
        'End If
        'Me.DTPFecha.Enabled = True
        Me.EsReciboManual = False

        Me.BtnBorrarLinea.Visible = False
        Me.GrpValorDolar.Visible = False
        Me.TxtPrecioSG.Text = "0"
        Me.Button6.Enabled = False
        Me.Lbltxmonto.Visible = False
        Me.LbltxSaldo.Visible = False

        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If
        Me.DTPFecha.Value = Now
        LeeArchivo = Mid(LeeArchivo, 1, 3)
        '/////////////////////MONEDA///////////////////////////////////
        sql = "SELECT  IdMoneda, Nombre, Simbolo  FROM Moneda "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Moneda")
        Me.CboMonedas.DisplayMember = "Nombre"
        If DataSet.Tables("Moneda").Rows.Count = 0 Then
            Me.CboMonedas.Text = ""
            IdMoneda = 0
        Else
            'Me.CboMoneda.DisplayMember = "Simbolo"
            'Me.CboMoneda.DataSource = DataSet.Tables("Moneda")
            Me.CboMonedas.DataSource = DataSet.Tables("Moneda")
            Me.CboMonedas.Text = DataSet.Tables("Moneda").Rows(0)("Nombre")
            Me.CboMonedas.Splits.Item(0).DisplayColumns(2).Visible = False
            Me.CboMonedas.Splits.Item(0).DisplayColumns(0).Visible = False
            IdMoneda = DataSet.Tables("Moneda").Rows(0)("IdMoneda")
        End If

        sql = "SELECT  IdMoneda, Nombre, Simbolo  FROM Moneda "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "MonedaSim")
        If DataSet.Tables("MonedaSim").Rows.Count = 0 Then
            Me.CboMoneda.Text = ""
        Else
            Me.CboMoneda.DisplayMember = "Simbolo"
            Me.CboMoneda.DataSource = DataSet.Tables("MonedaSim")
        End If

        '/////////////////////ESTADO DEL DOCUMENTO/////////////////////////////////
        sql = "SELECT IdEstadoDocumento, Codigo, Descripcion  FROM EstadoDocumento "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "EstadoDocumento")
        Me.CboEstadoDocumeto.DisplayMember = "Descripcion"
        If DataSet.Tables("EstadoDocumento").Rows.Count = 0 Then
            Me.CboEstadoDocumeto.Text = ""
        Else
            Me.CboEstadoDocumeto.DataSource = DataSet.Tables("EstadoDocumento")
            Me.CboEstadoDocumeto.Text = "Editable"
        End If

        '/////////////////////TIPO COMPRA ///////////////////////////////////
        sql = "SELECT  IdTipoCompra, Codigo, Nombre FROM TipoCompra"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCompra")
        If DataSet.Tables("TipoCompra").Rows.Count = 0 Then
            Me.CboTipoCompra.Text = ""
        Else
            Me.CboTipoCompra.DisplayMember = "Nombre"
            Me.CboTipoCompra.DataSource = DataSet.Tables("TipoCompra")
            If Quien2 = "Nuevo" Then
                Me.CboTipoCompra.Text = "Depósito"
            Else
                Me.CboTipoCompra.Text = "Compra Directa"
            End If
        End If

        'Me.CboCodigoProveedor.Columns(0).Caption = "Codigo"
        'Me.CboCodigoProveedor.Columns(1).Caption = "Proveedor"

        '/////////////////////////// LOCALIDAD PARA EL LABEL ///////////////////////////////////////////////////
        SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & LeeArchivo & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad")
        If DataSet.Tables("Localidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
        End If
        '////////////////////////////////CARGO LOCALIDAD LIQUIDACION PARA EL COMBO  ///////////////////////////////////////////////
        sql = "SELECT  IdLugarAcopio, NomLugarAcopio   FROM   LugarAcopio WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "LocalidadLiq")
        Me.CboLocalidadLiq.DisplayMember = "NomLugarAcopio"
        If DataSet.Tables("LocalidadLiq").Rows.Count = 0 Then
            Me.CboLocalidadLiq.Text = ""
        Else
            Me.CboLocalidadLiq.DataSource = DataSet.Tables("LocalidadLiq")
            Me.CboLocalidadLiq.Text = Me.LblSucursal.Text
        End If

        '////////////////////////////////CARGO COSECHA ///////////////////////////////////////////////

        SqlString = "SELECT IdCosecha, Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CDbl(CodigoCosecha) & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count = 0 Then
            Me.LblCosecha.Text = "Cosecha NO DEFINIDA"
        Else
            Me.LblCosecha.Text = "Cosecha " & DataSet.Tables("Cosecha").Rows(0)("AñoIni") & "-" & DataSet.Tables("Cosecha").Rows(0)("AñoFin")
            IdCosecha = DataSet.Tables("Cosecha").Rows(0)("IdCosecha")
            Cod_Cosecha = DataSet.Tables("Cosecha").Rows(0)("Codigo")
        End If




        '/////////////////////////////////7CON ESTA CONSULTA SOLO LOS PRODUCTORES QUE TIEN RECIBOS APARECEN EN LA LIQUIDACION //////////////////
        'sql = "SELECT DISTINCT Proveedor.Cod_Proveedor AS Codigo, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombre,Exonerado, Cedula FROM ReciboCafePergamino INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor "
        sql = "SELECT DISTINCT CASE WHEN Proveedor.IdProductor IS NULL THEN '00001' ELSE Proveedor.Cod_Proveedor END AS Cod_Proveedor, CASE WHEN Proveedor.IdProductor IS NULL  THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Nombres, CASE WHEN Proveedor.Cedula IS NULL THEN ReciboCafePergamino.CedulaManual ELSE Proveedor.Cedula END AS Cedula  FROM   ReciboCafePergamino LEFT OUTER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor " & _
              "WHERE(ReciboCafePergamino.IdCosecha = " & IdCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")
        Else
            Me.CboCodigoProveedor.Text = ""
        End If

        '////////////////////////////////CARGO COMBO TIPO INGRESO ///////////////////////////////////////////////
        sql = "SELECT  IdTipoIngreso, Descripcion, Code  FROM  TipoIngreso"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Tipoingreso")
        Me.CboTipIngreso.DisplayMember = "Descripcion"
        If DataSet.Tables("Tipoingreso").Rows.Count = 0 Then
            Me.CboTipIngreso.Text = "--------"
        Else
            Me.CboTipIngreso.DataSource = DataSet.Tables("Tipoingreso")
            Me.CboTipIngreso.Text = DataSet.Tables("Tipoingreso").Rows(0)("Descripcion")
        End If

        Me.TxtTotalDecC.Text = "0.00"
        Me.TxtTotalDecD.Text = "0.00"
        Me.TxtRentDefC.Text = "0.00"
        Me.TxtRentDefD.Text = "0.00"
        Me.TxtTotalCor.Text = "0.00"
        Me.TxtTotalDol.Text = "0.00"

        '////////////////////////////////VALIDO LAS FECHAS DE LOS IMPUESTOS  ///////////////////////////////////////////////
        'Validacion de Fechas de los impuestos

        SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Impuesto")
        count = DataSet.Tables("Impuesto").Rows.Count
        i = 0
        Do While count > i
            Fechainicial = DataSet.Tables("Impuesto").Rows(i)("VigenciaInicial")
            FechaFinal = DataSet.Tables("Impuesto").Rows(i)("VigenciaFinal")
            Fechanow = Me.DTPFecha.Text
            TipoImp = DataSet.Tables("Impuesto").Rows(i)("Descripcion")
            Select Case TipoImp
                Case "Imp. Municipal"
                    If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                        Me.Checkpor1.Enabled = True
                    Else
                        Me.Checkpor1.Enabled = False
                    End If
                Case "Retención 2%"
                    If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                        Me.Checkbox4.Enabled = True
                    Else
                        Me.Checkbox4.Enabled = False
                    End If
                Case "Retención Definitiva"
                    If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                        Me.Checkpor2.Enabled = True
                        Me.Checkpor2.Checked = True
                    Else
                        Me.Checkpor2.Enabled = False
                    End If
                Case "Retención 3%"
                    If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                        Me.Checkpor3.Enabled = True
                    Else
                        Me.Checkpor3.Enabled = False
                    End If
            End Select
            i = i + 1
        Loop

        '////////////////////////////////CARGO LA TASA DE CAMBIO PARA EL DIA  ///////////////////////////////////////////////
        SqlString = "SELECT  IdTipoCambio, FechaTipoCambio, TipoCambio, Simbolo FROM TipoCambio WHERE  (FechaTipoCambio = CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TasaCambio")
        If DataSet.Tables("TasaCambio").Rows.Count <> 0 Then
            Me.TxtTasaCambio.Text = DataSet.Tables("TasaCambio").Rows(0)("TipoCambio")
            IdTipoCambio = DataSet.Tables("TasaCambio").Rows(0)("IdTipoCambio")
        Else
            Me.TxtTasaCambio.Text = "0.00"
            IdTipoCambio = 0
        End If

        SqlString = "SELECT  ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ISNULL(PrecioCafe.Precio, 0) AS Precio, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) * ISNULL(PrecioCafe.Precio, 0) AS ValorBrutoC$, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) * ISNULL(PrecioCafe.Precio, 0) / ISNULL(TipoCambio.TipoCambio, 1) AS ValorBruto$, ReciboCafePergamino.IdTipoCompra  FROM  ReciboCafePergamino INNER JOIN   DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  TipoCompra ON ReciboCafePergamino.IdTipoCompra = TipoCompra.IdTipoCompra LEFT OUTER JOIN   TipoCambio ON ReciboCafePergamino.Fecha = TipoCambio.FechaTipoCambio LEFT OUTER JOIN   PrecioCafe ON ReciboCafePergamino.IdLocalidad = PrecioCafe.IdLocalidad AND ReciboCafePergamino.IdCalidad = PrecioCafe.IdCalidad WHERE  (ReciboCafePergamino.IdProductor = '-100') AND (ReciboCafePergamino.IdDano = " & IdDano & ") AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (DetalleReciboCafePergamino.IdEdoFisico = " & IdEdoFisico & ") AND (ReciboCafePergamino.IdTipoCompra = " & IdTipoCompra & ")AND (ReciboCafePergamino.IdTipoIngreso = '" & IdTipoIngreso & "')"
        'SqlString = "SELECT  ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ISNULL(PrecioCafe.Precio, 0) AS Precio, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) * ISNULL(PrecioCafe.Precio, 0) AS ValorBrutoC$, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) * ISNULL(PrecioCafe.Precio, 0) / ISNULL(TipoCambio.TipoCambio, 1) AS ValorBruto$, ReciboCafePergamino.Fecha  FROM  ReciboCafePergamino INNER JOIN   DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino LEFT OUTER JOIN    TipoCambio ON ReciboCafePergamino.Fecha = TipoCambio.FechaTipoCambio LEFT OUTER JOIN  PrecioCafe ON ReciboCafePergamino.IdLocalidad = PrecioCafe.IdLocalidad AND ReciboCafePergamino.IdCalidad = PrecioCafe.IdCalidad " & _
        '                "WHERE(ReciboCafePergamino.IdProductor = '-100')AND (ReciboCafePergamino.IdDano = " & IdDano & ") AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (ReciboCafePergamino.IdLocalidadLiquidacion = " & IdLocalidad & ") AND  (DetalleReciboCafePergamino.IdEdoFisico = " & IdEdoFisico & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecibo12")
        Me.TDGridDetalleRecibos.DataSource = DataSet.Tables("DetalleRecibo12")
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("NºRecibo").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("PesoNeto").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBrutoC$").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBruto$").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBruto$").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("Precio").Locked = True
        '////////////////////////////////BUSCO EL ID DE LA SIGUENTE LIQUIDACION  ///////////////////////////////////////////////
        'If Quien2 = "Nuevo" Then
        '    SqlString = "SELECT    IdLiquidacionPergamino  FROM    LiquidacionPergamino   ORDER BY IdLiquidacionPergamino DESC"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "IdLiquidacionPost")

        '    If Not DataSet.Tables("IdLiquidacionPost").Rows.Count = 0 Then
        '        IdliquidacionPost = DataSet.Tables("IdLiquidacionPost").Rows(0)("IdLiquidacionPergamino") + 1
        '        Me.TxtIdLiquidacion.Text = IdliquidacionPost
        '        Quien2 = ""
        '    Else
        '        Me.TxtIdLiquidacion.Text = 1
        '    End If
        'End If

        If Quien3 = "Ver" Then
            Me.Button10.Enabled = False
            Me.DTPFecha.Enabled = False
        End If


        If Quien = "Recibo" Then
            Quien3 = "Recibo"

            Me.EsReciboManual = True
            Me.IdProductor = My.Forms.FrmRecepcion.IdProductor
            Me.EsProductorManual = My.Forms.FrmRecepcion.EsProductorManual
            If EsProductorManual = True Then
                Me.Cedula = My.Forms.FrmRecepcion.Cedula
                Me.TxtCedula.Text = Me.Cedula

            End If

            Me.DTPFecha.Value = FrmRecepcion.FechaRecibo
            'Me.CboCodigoProveedor.Text = codigoProveedor
            Me.CboTipIngreso.Text = TipoIngresoCbo
            Me.CboLocalidadLiq.Text = LocalidadCbo
            Me.TxtNumeroEnsamble.Text = NumeroRecibo
            Me.CboTipoCompra.Text = TipoCompraCbo


            Me.LocalidadCbo = FrmRecepcion.CboLiquidarLocalidad.Text
            Me.CboLocalidadLiq.Enabled = False
            Me.CboCodigoProveedor.Text = FrmRecepcion.CboCodigoProveedor.Text
            Me.CboCodigoProveedor.Enabled = False
            'Me.codigoProveedor = FrmRecepcion.CboCodigoProveedor.Text
            Me.txtnombre.Text = FrmRecepcion.txtnombre.Text
            Me.TipoIngresoCbo = FrmRecepcion.CboTipoIngresoBascula.Text
            Me.CboTipIngreso.Enabled = False
            Me.CboTipoCompra.Text = FrmRecepcion.CboTipoCompra.Text
            Me.TipoCompraCbo = FrmRecepcion.CboTipoCompra.Text
            Me.CboTipoCompra.Enabled = False
            Me.CboCalidad.Text = My.Forms.FrmRecepcion.TipoCalidad
            Me.CboCalidad.Enabled = False
            Me.CboTipDano.Text = FrmRecepcion.Daño
            Me.CboTipDano.Enabled = False
            Me.CboEdofisico.Text = FrmRecepcion.Estado
            Me.CboEdofisico.Enabled = False
            Me.CboImperfeccion.Text = FrmRecepcion.Categoria
            Me.CboImperfeccion.Enabled = False
            Me.Button10.Enabled = False
            Me.txtnombre.Enabled = False
            Me.TxtCedula.Enabled = False
            Me.CboMunicipio.Enabled = True
            Me.CboMoneda.Enabled = True
            Me.CboMonedas.Enabled = True
            Me.TabControl1.Enabled = True
            Me.Button8.Enabled = False
            Me.Button14.Enabled = False
            Me.Button2.Enabled = False
            Me.TxtTasaCambio.Enabled = False
            Me.Button3.Enabled = False
            Me.Button9.Enabled = False
            Me.Button6.Enabled = False
            Me.TxtIdLocalidad.Text = Me.TxtIdLocalidad.Text
            Me.NumeroRecibo = FrmRecepcion.TxtNumeroRecibo.Text
            Me.TxtSerie.Text = Me.TxtSerie.Text
            Me.TDGridDetalleRecibos.Enabled = False

            '------------------------ACTUALIZO LOS ID DE LA LIQUIDACION -----------------------------------------
            Me.IdProductor = My.Forms.FrmRecepcion.IdProductor
            Me.IdLocalidadLiqui = FrmRecepcion.IdLugarAcopio
            Me.IdTipoIngreso = FrmRecepcion.IdTipoIngreso
            Me.IdTipoCompra = FrmRecepcion.IdTipoCompra
            Me.IdCalidad = FrmRecepcion.IdCalidad
            Me.IdEdoFisico = FrmRecepcion.IdEstadoFisico
            Me.IdDano = FrmRecepcion.IdDaño
            Me.IdCategoria = FrmRecepcion.IdRangoImperfeccion

            CalculaPrecioBruto()
            Me.Button10_Click(sender, e)

            SumaGrid1()
            sumagriddistribucion()
            Me.DTPFecha.Enabled = False

            Salir = False
            BtnGuardar_Click(sender, e)
            Salir = True
            Quien = "Recibo"
            Me.TxtIdLiquidacion.Text = Idliquidacion

            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("NºRecibo").Locked = True
            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("PesoNeto").Locked = True
            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBrutoC$").Locked = True
            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBruto$").Locked = True
            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBruto$").Locked = True
            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("Precio").Locked = True
        Else
            Me.TxtSerie.Text = "D" & Cod_Cosecha
        End If
        Quien2 = ""
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If Quien = "Recibo" Then
            Quien = ""
            Me.Close()
        Else
            Me.Close()
            My.Forms.FrmResumenLiquidacion.Show()
            My.Forms.FrmResumenLiquidacion.Refresh()
        End If

    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        'QuienTec = "Proveedor"
        'Sugerencia = "LiqProveedor"
        FrmTeclado.ShowDialog()
        Me.CboCodigoProveedor.Text = FrmTeclado.Numero
    End Sub
    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = "", SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, i As Integer, count As Double, TipoImp As String
        Dim Fecha As Date, TasaCambio As Double, IdlocalidadRec As Double, PesoNeto As Double, Precio1 As Double
        Dim EsPorcentaje As Boolean, IdLocalidad As Integer, DeduccionDano As Double, DD As Double
        Dim DeducEstado As Double, Descripcion As String
        limpiaGrid()
        If Me.CboCodigoProveedor.Text = "" Then
            Exit Sub
        End If

        If Me.CboCodigoProveedor.Text = "00001" Then
            EsProductorManual = True
        Else
            EsProductorManual = False
        End If

        '////////////////////////BUSCO EL LOS DATOS DEL PROVEEDOR SELECCIONADO //////////////////////////////
        If EsProductorManual = False Then
            SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
            Me.CboMunicipio.Text = ""
        Else
            SqlProveedor = "SELECT CedulaManual, ProductorManual FROM ReciboCafePergamino WHERE (CedulaManual = '" & Cedula & "') AND (IdCosecha = " & Me.IdCosecha & ")"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            If EsProductorManual = True Then
                Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("ProductorManual")
                IdProductor = 1
                Me.TxtCedula.Text = DataSet.Tables("Proveedor").Rows(0)("CedulaManual")
            Else
                Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
                IdProductor = DataSet.Tables("Proveedor").Rows(0)("IdProductor")
                Me.TxtCedula.Text = DataSet.Tables("Proveedor").Rows(0)("Cedula")
                If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                    Me.txtnombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor") & " " & DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
                End If
            End If

        Else
            MsgBox("Verifique este proveedor", MsgBoxStyle.Critical, "Proveedor")
            Me.txtnombre.Text = ""
            Me.TxtCedula.Text = ""
            Exit Sub
        End If
        'If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
        '    IdProductor = DataSet.Tables("Proveedor").Rows(0)("IdProductor")
        '    Me.TxtCedula.Text = DataSet.Tables("Proveedor").Rows(0)("Cedula")
        'End If

        If Me.EsProductorManual = False Then
            If DataSet.Tables("Proveedor").Rows(0)("Exonerado") = True Then
                Me.Checkpor3.Enabled = False
                Me.Checkbox4.Enabled = False
                Me.Checkpor2.Enabled = False
                Me.Checkpor2.Checked = False
            Else
                '///////////////////////////// VALIDO LA FECHA DE LOS IMPUESTOS NUEVAMENTE //////////////////////
                SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Impuesto")
                count = DataSet.Tables("Impuesto").Rows.Count
                i = 0
                Do While count > i
                    Fechainicial = DataSet.Tables("Impuesto").Rows(i)("VigenciaInicial")
                    FechaFinal = DataSet.Tables("Impuesto").Rows(i)("VigenciaFinal")
                    Fechanow = Me.DTPFecha.Value
                    TipoImp = DataSet.Tables("Impuesto").Rows(i)("Descripcion")
                    Select Case TipoImp
                        Case "Imp. Municipal"
                            If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                                Me.Checkpor1.Enabled = True
                            Else
                                Me.Checkpor1.Enabled = False
                            End If
                        Case "Retención 2%"
                            If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                                Me.Checkbox4.Enabled = True
                            Else
                                Me.Checkbox4.Enabled = False
                            End If
                        Case "Retención Definitiva"
                            If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                                Me.Checkpor2.Enabled = True
                                Me.Checkpor2.Checked = True
                            Else
                                Me.Checkpor2.Enabled = False
                            End If
                        Case "Retención 3%"
                            If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                                Me.Checkpor3.Enabled = True
                            Else
                                Me.Checkpor3.Enabled = False
                            End If
                    End Select
                    i = i + 1
                Loop


            End If
        Else
            '///////////////////////////// VALIDO LA FECHA DE LOS IMPUESTOS NUEVAMENTE //////////////////////
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto")
            count = DataSet.Tables("Impuesto").Rows.Count
            i = 0
            Do While count > i
                Fechainicial = DataSet.Tables("Impuesto").Rows(i)("VigenciaInicial")
                FechaFinal = DataSet.Tables("Impuesto").Rows(i)("VigenciaFinal")
                Fechanow = Me.DTPFecha.Value
                TipoImp = DataSet.Tables("Impuesto").Rows(i)("Descripcion")
                Select Case TipoImp
                    Case "Imp. Municipal"
                        If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                            Me.Checkpor1.Enabled = True
                        Else
                            Me.Checkpor1.Enabled = False
                        End If
                    Case "Retención 2%"
                        If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                            Me.Checkbox4.Enabled = True
                        Else
                            Me.Checkbox4.Enabled = False
                        End If
                    Case "Retención Definitiva"
                        If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                            Me.Checkpor2.Enabled = True
                            Me.Checkpor2.Checked = True
                        Else
                            Me.Checkpor2.Enabled = False
                        End If
                    Case "Retención 3%"
                        If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                            Me.Checkpor3.Enabled = True
                        Else
                            Me.Checkpor3.Enabled = False
                        End If
                End Select
                i = i + 1
            Loop
        End If
        '///////////////////////////CARGO LAS CALIDADES SEGUN LAS CALIDADES QUE HA DADO EL PROVEEDOR//////////////////////////////////

        If Me.CboCodigoProveedor.Text = "00001" Then
            sql = "SELECT  DISTINCT Calidad.NomCalidad, Calidad.IdCalidad  FROM  ReciboCafePergamino INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad WHERE (ReciboCafePergamino.CedulaManual = '" & Me.Cedula & "') AND (ReciboCafePergamino.IdCosecha = " & IdCosecha & ")"
            EsProductorManual = True
        Else
            sql = "SELECT DISTINCT Calidad.NomCalidad , Calidad.IdCalidad  FROM     ReciboCafePergamino INNER JOIN      Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad  WHERE  (ReciboCafePergamino.IdProductor = " & IdProductor & ")"
            EsProductorManual = False
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Calidad")
        If Me.txtnombre.Text = "" Then
            MsgBox("SELECCIONE UN PROVEEDOR PARA TENER CALIDADES", MsgBoxStyle.Information, "liquidacion")
        End If
        Me.CboCalidad.DisplayMember = "NomCalidad"

        If DataSet.Tables("Calidad").Rows.Count <> 0 Then
            Me.CboCalidad.DataSource = DataSet.Tables("Calidad")
            Me.CboCalidad.Text = DataSet.Tables("Calidad").Rows(0)("NomCalidad")
            IdCalidad = DataSet.Tables("Calidad").Rows(0)("IdCalidad")
        Else
            MsgBox("ESTE PROVEEDOR NO TIENE  CALIDADES", MsgBoxStyle.Information, "liquidacion")
        End If

        '/////////////////reemplazo... Requerimiento 8
        'SELECT  LugarAcopio.NomLugarAcopio, LugarAcopio.IdLugarAcopio, LugarAcopio.IdPadre, Municipio.Nombre, LugarAcopio.Activo  FROM LugarAcopio INNER JOIN   Municipio ON LugarAcopio.IdPadre = Municipio.IdLugarAcopio   WHERE(LugarAcopio.Activo = 1)

        IdMunicipio = 0
        If EsProductorManual = False Then
            '///////////////////////// CARGO EL COMBO MUNICIPIO SEGUN LOS DATOS DEL PROVEEDOR ////////////////////////////
            sql = " SELECT DISTINCT Finca.IdFinca, Finca.NomFinca, Finca.UbicaFinca, Municipio.IdMunicipio, Municipio.Nombre  FROM   Proveedor INNER JOIN  Finca ON Proveedor.IdProductor = Finca.IdProductor INNER JOIN        Comarca ON Finca.IdComarca = Comarca.IdComarca INNER JOIN   Municipio ON Comarca.IdMunicipio = Municipio.IdMunicipio WHERE (Proveedor.IdProductor = '" & IdProductor & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "municio")
            'Me.CboMunicipio.DisplayMember = "Nombre"    
            Me.CboFinca.DisplayMember = "NomFinca"
            If DataSet.Tables("municio").Rows.Count <> 0 Then
                'Me.CboMunicipio.DataSource = DataSet.Tables("municio")
                'Me.CboMunicipio.Text = DataSet.Tables("municio").Rows(0)("Nombre")

                Me.CboFinca.DataSource = DataSet.Tables("municio")
                Me.CboFinca.Text = DataSet.Tables("municio").Rows(0)("NomFinca")
            Else
                sql = " SELECT DISTINCT IdMunicipio, Nombre, IdLugarAcopio FROM     Municipio WHERE        (IdLugarAcopio = '" & IdLocalidadLiqui & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "municipo")
                'Me.CboMunicipio.DisplayMember = "Nombre"
                If DataSet.Tables("municipo").Rows.Count <> 0 Then
                    'Me.CboMunicipio.DataSource = DataSet.Tables("municipo")
                    'Me.CboMunicipio.Text = DataSet.Tables("municipo").Rows(0)("Nombre")
                Else
                    Me.CboMunicipio.Text = ""
                    Me.CboFinca.Text = ""
                End If
            End If

        Else
            sql = " SELECT DISTINCT Finca.IdFinca, Finca.NomFinca, Finca.UbicaFinca, Municipio.IdMunicipio, Municipio.Nombre  FROM   Proveedor INNER JOIN  Finca ON Proveedor.IdProductor = Finca.IdProductor INNER JOIN  Comarca ON Finca.IdComarca = Comarca.IdComarca INNER JOIN   Municipio ON Comarca.IdMunicipio = Municipio.IdMunicipio WHERE (Proveedor.IdProductor = '-10000')"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "municio")
            'Me.CboMunicipio.DisplayMember = "Nombre"
            Me.CboFinca.DisplayMember = "NomFinca"
            'Me.CboMunicipio.DataSource = DataSet.Tables("municipo")
            Me.CboMunicipio.Text = ""
        End If

        'DataSet.Tables("municio").Reset()
        ''PRECIO 
        ''PRECIO DE LA LIQUIDACION 
        'Fecha = Me.DTPFecha.Text
        ''DataSet.Tables("Precio3").Reset()
        'SqlString = "SELECT  PrecioCafe.IdCalidad, PrecioCafe.Precio  / 46 AS Precio, PrecioCafe.FechaActualizacion, PrecioCafe.IdRangoImperfeccion, PrecioCafe.IdLocalidad, RangoImperfeccion.Nombre, LugarAcopio.NomLugarAcopio, Calidad.NomCalidad FROM  PrecioCafe INNER JOIN  LugarAcopio ON PrecioCafe.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN   RangoImperfeccion ON PrecioCafe.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN   Calidad ON PrecioCafe.IdCalidad = Calidad.IdCalidad WHERE  (LugarAcopio.NomLugarAcopio = '" & Me.CboLocalidadLiq.Text & "') AND (RangoImperfeccion.Nombre = '" & Me.CboImperfeccion.Text & "') AND (Calidad.NomCalidad = '" & Me.CboCalidad.Text & "') AND (PrecioCafe.FechaActualizacion <= ' " & Fecha & "')  ORDER BY PrecioCafe.FechaActualizacion DESC"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Precio3")
        'count = 0
        'i = 0
        'count = DataSet.Tables("Precio3").Rows.Count

        '' BUSCO LAS DEDUCCIONES PARA APLICARSELAS AL PRECIO 
        ''______________________________________________________________________________________________________
        ''DEDUCCION DAÑO 
        ''______________________________________________________________________________________________________

        'SqlString = "SELECT  IdDeduccionDano, Deduccion, EsPorcentaje, FechaInicio, FechaFin, IdDano, IdMoneda, IdUMedida, IdCosecha  FROM  DeduccionDano WHERE (IdDano = '" & IdDano & "') AND (IdMoneda ='" & IdMoneda & "') AND (IdCosecha ='" & IdCosecha & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DeduccionDano")
        'Fechainicial = DataSet.Tables("DeduccionDano").Rows(0)("FechaInicio")
        'FechaFinal = DataSet.Tables("DeduccionDano").Rows(0)("FechaFin")
        'Fechanow = Me.DTPFecha.Text
        'EsPorcentaje = DataSet.Tables("DeduccionDano").Rows(0)("EsPorcentaje")
        'DD = DataSet.Tables("DeduccionDano").Rows(0)("Deduccion")

        'If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
        '    If EsPorcentaje = True Then
        '        DeduccionDano = Precio * (1 - DD)
        '    Else
        '        DeduccionDano = DD / 46
        '    End If
        'Else
        '    DeduccionDano = 0
        'End If
        ''______________________________________________________________________________________________________
        ''DEDUCCION ESTADO FISICO 
        ''______________________________________________________________________________________________________

        'SqlString = "SELECT IdDeduccionEstadoFisico, PorcentajeDeduccion, EstadoFisico, IdCosecha FROM   PorcentajeDeduccionEstadoFisico   WHERE  (EstadoFisico = '" & IdEdoFisico & "') AND (IdCosecha = '" & IdCosecha & "') "
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "DeduccionEdo")
        'DeducEstado = DataSet.Tables("DeduccionEdo").Rows(0)("PorcentajeDeduccion")
        'Porcentaje = 0.015

        'If count <> 0 Then
        '    Do While count > i
        '        Precio = ((Format(DataSet.Tables("Precio3").Rows(i)("Precio"), "##,##0.00") * DeducEstado) - DeduccionDano) / (1 - Porcentaje)
        '        Me.CboPrecios.DataSource = DataSet.Tables("Precio3")
        '    Loop
        '    Me.CboPrecios.DisplayMember = "Precio"
        '    Me.CboPrecios.DataSource = DataSet.Tables("Precio3")
        '    Me.CboPrecios.Text = ((Format(DataSet.Tables("Precio3").Rows(0)("Precio"), "##,##0.00") * DeducEstado) - DeduccionDano) / (1 - Porcentaje)
        '    Precio = Me.CboPrecios.Text
        'Else
        '    Precio = 0.0
        'End If

        totalCor = 0
        totalDol = 0
        ImpMuniC = 0
        ImpMuniD = 0
        RetDefC = 0
        RetDefD = 0
        Ret3C = 0
        Ret3D = 0
        valorCor = 0
        ValorDol = 0
        TotalDecC = 0
        TotalDecD = 0
        NetoPagarC = 0
        NetoPagarD = 0
        TotalDecC = 0
        TotalDecD = 0

        Me.TxtTotalDecC.Text = "0.00"
        Me.TxtTotalDecD.Text = "0.00"
        Me.TxtRentDefC.Text = "0.00"
        Me.TxtRentDefD.Text = "0.00"
        Me.TxtTotalCor.Text = "0.00"
        Me.TxtTotalDol.Text = "0.00"

        'If Quien = "NumeroChange" Then
        '    Exit Sub
        'Else
        '    'FiltarLimpiar()
        'End If   

        CalculaPrecioBruto()
    End Sub
    Private Sub DTPFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFecha.ValueChanged
        Dim SQlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, mes As Integer, ano As Integer
        DataSet.Reset()
        '////////////////////////// SELECIONA LA TASA CAMBIO CUANDO CAMBIAN LA FECHA ////////////////////////////////
        '///////////////SEPARO LOS MESES Y EL ANO, PARA VALIDAR QUE LA TASA ESTA EN EL MES CONTABLE////////////
        mes = Me.DTPFecha.Value.Month
        ano = Me.DTPFecha.Value.Year
        If mes <> Me.DTPFecha.Value.Now.Month Or ano <> Me.DTPFecha.Value.Now.Year Then
            If Quien3 = "Ver" Then
                'Quien3 = ""
                Exit Sub
            End If
            MsgBox("LA FECHA ESTA FUERA DE RANGO", MsgBoxStyle.Critical, "Liquidaciones")
            Me.DTPFecha.Value = Now
            Exit Sub


        Else
            SQlString = "SELECT  IdTipoCambio, FechaTipoCambio, TipoCambio, Simbolo FROM TipoCambio WHERE  (FechaTipoCambio = CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd") & "', 102))"
            DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
            DataAdapter.Fill(DataSet, "TasaCambio")
            If DataSet.Tables("TasaCambio").Rows.Count <> 0 Then
                Me.TxtTasaCambio.Text = DataSet.Tables("TasaCambio").Rows(0)("TipoCambio")
                IdTipoCambio = DataSet.Tables("TasaCambio").Rows(0)("IdTipoCambio")
                TasaCambio = CDbl(Me.TxtTasaCambio.Text)
            Else
                Me.TxtTasaCambio.Text = "0.00"
                IdTipoCambio = 0
            End If
        End If
        'Precio = 0
        'SQlString = "SELECT  PrecioCafe.IdCalidad, PrecioCafe.Precio  / 46 AS Precio, PrecioCafe.FechaActualizacion, PrecioCafe.IdRangoImperfeccion, PrecioCafe.IdLocalidad, RangoImperfeccion.Nombre, LugarAcopio.NomLugarAcopio, Calidad.NomCalidad FROM  PrecioCafe INNER JOIN  LugarAcopio ON PrecioCafe.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN   RangoImperfeccion ON PrecioCafe.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN   Calidad ON PrecioCafe.IdCalidad = Calidad.IdCalidad WHERE  (LugarAcopio.NomLugarAcopio = '" & Me.CboLocalidadLiq.Text & "') AND (RangoImperfeccion.Nombre = '" & Me.CboImperfeccion.Text & "') AND (Calidad.NomCalidad = '" & Me.CboCalidad.Text & "') AND (PrecioCafe.FechaActualizacion = ' " & Fecha & "')  ORDER BY PrecioCafe.FechaActualizacion DESC"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Precio4")
        'If DataSet.Tables("Precio4").Rows.Count <> 0 Then
        '    Me.CboPrecios.DisplayMember = "Precio"
        '    Me.CboPrecios.DataSource = DataSet.Tables("Precio4")
        '    Me.CboPrecios.Text = Format(DataSet.Tables("Precio4").Rows(0)("Precio") / 46, "##,##0.00")
        '    Precio = Me.CboPrecios.Text
        '    Precio = Format(DataSet.Tables("Precio1").Rows(0)("Precio") / 46, "##,##0.00")
        'Else
        '    Precio = 0.0
        'End If
        CalculaPrecioBruto()
        CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
    End Sub

    Private Sub CboIngreso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'sql = "SELECT Descripcion  FROM  TipoDocumento  WHERE   (Descripcion = 'Recibo Bascula Manual') OR  (Descripcion = 'Recibo Bascula Automático') ORDER BY Descripcion"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "Tipoingreso")
        'Me.CboTipIngreso.DataSource = DataSet.Tables("Tipoingreso")

        'If Not DataSet.Tables("Tipoingreso").Rows.Count = 0 Then

        '    If Not IsDBNull(DataSet.Tables("Tipoingreso").Rows(0)("Descripcion")) Then
        '        Me.CboIngreso.Text = DataSet.Tables("Tipoingreso").Rows(0)("Descripcion")
        '    End If
        'End If

        'If Me.CboIngreso.Text = "Manual" Then
        '    Me.TxtNumeroEnsamble.Enabled = True
        '    My.Forms.FrmTeclado.ShowDialog()
        '    Me.TxtNumeroEnsamble.Text = My.Forms.FrmTeclado.Numero
        'ElseIf Me.CboIngreso.Text = "Automatico" Then
        '    Me.TxtNumeroEnsamble.Enabled = False
        '    Me.TxtNumeroEnsamble.Text = "-----0-----"
        'End If
    End Sub
    Private Sub TxtNumeroEnsamble_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.Click
        'If CboTipIngreso.Text = "Manual" Then
        '    Me.TxtNumeroEnsamble.Enabled = True
        '    My.Forms.FrmTecladoLiqui.ShowDialog()
        '    Me.TxtNumeroEnsamble.Text = My.Forms.FrmTecladoLiqui.Numero
        'End If
    End Sub
    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged
        '    If Quien = "Grid" Then
        '        Quien = ""
        '        Exit Sub
        '    End If

        '    Dim Sql As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, DataSet1 As New DataSet, DataAdapter1 As New SqlClient.SqlDataAdapter, SumaRec As String
        '    Dim count As Integer, i As Integer, Descripcion As String, item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        '    Dim item1 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        '    Dim item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        '    Dim sql1 As String, SumPaseo As String, sqldet As String
        '    Dim IdEstadoLlama As String

        '    If Me.TxtNumeroEnsamble.Text = "-----0-----" Or Me.TxtNumeroEnsamble.Text = "" Or Me.TxtNumeroEnsamble.Text = "---0---" Then
        '        Exit Sub
        '    End If

        '    Try
        '        Sql = "SELECT LiquidacionPergamino.Fecha, Proveedor.Cod_Proveedor, YEAR(Cosecha.FechaInicial) AS Fechainicial, YEAR(Cosecha.FechaFinal) AS FechaFinal, LugarAcopio.NomLugarAcopio, Municipio.Nombre, TipoIngreso.Descripcion AS TipoIngreso, EstadoDocumento.Descripcion AS EstadoDocumento, TipoCompra.Nombre AS TipoCompra, EstadoFisico.Descripcion AS EdoFisico, RangoImperfeccion.Nombre AS RangoImperfeccion,  Calidad.NomCalidad, Dano.Nombre AS Dano,  Moneda.Simbolo, EstadoDocumento.IdEstadoDocumento   FROM   LiquidacionPergamino INNER JOIN   Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN   Cosecha ON LiquidacionPergamino.IdCosecha = Cosecha.IdCosecha INNER JOIN   LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN    Municipio ON LiquidacionPergamino.IdMunicipio = Municipio.IdMunicipio INNER JOIN     TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN    EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN  EstadoFisico ON LiquidacionPergamino.IdEstadoFisico = EstadoFisico.IdEdoFisico INNER JOIN   RangoImperfeccion ON LiquidacionPergamino.IdCategoriaImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN Moneda ON LiquidacionPergamino.IdMoneda = Moneda.IdMoneda WHERE  (LiquidacionPergamino.Codigo = '" & Me.TxtNumeroEnsamble.Text & "')"
        '        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '        DataAdapter.Fill(DataSet, "LlamaLiquida")

        '        IdEstadoLlama = DataSet.Tables("LlamaLiquida").Rows(0)("IdEstadoDocumento")
        '        If IdEstadoLlama = 294 Then
        '            Me.GroupBox6.Enabled = False
        '        ElseIf IdEstadoLlama = 293 Then
        '            Me.GroupBox6.Enabled = True
        '        End If

        '        'MsgBox("Desea Activar este usuario ", MsgBoxStyle.YesNo, "Clientes")

        '        If Not DataSet.Tables("LlamaLiquida").Rows.Count = 0 Then
        '            '  IdDestino, IdTipoCafe, IdTipoIngreso, IdUMedida, IdElaboradorPor, IdUsuario, IdCompany, FechaModificacion, Serie, IdtipoDocumento

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Fecha")) Then
        '                Me.DTPFecha.Value = DataSet.Tables("LlamaLiquida").Rows(0)("Fecha")
        '            Else
        '                Me.DTPFecha.Value = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Cod_Proveedor")) Then
        '                Me.CboCodigoProveedor.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Cod_Proveedor")
        '            Else
        '                Me.CboCodigoProveedor.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Fechainicial")) And IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("FechaFinal")) Then
        '                Me.LblCosecha.Text = "Cosecha " + DataSet.Tables("LlamaLiquida").Rows(0)("Fechainicial") + "-" + IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("FechaFinal"))
        '            Else
        '                Me.LblCosecha.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("NomLugarAcopio")) Then
        '                Me.CboLocalidadLiq.Text = DataSet.Tables("LlamaLiquida").Rows(0)("NomLugarAcopio")
        '                Me.LblSucursal.Text = Me.CboLocalidadLiq.Text

        '            Else
        '                Me.CboCodigoProveedor.Text = ""
        '                Me.LblSucursal.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Nombre")) Then
        '                Me.CboMunicipio.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Nombre")
        '            Else
        '                Me.CboMunicipio.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("TipoIngreso")) Then
        '                Me.CboTipIngreso.Text = DataSet.Tables("LlamaLiquida").Rows(0)("TipoIngreso")
        '            Else
        '                Me.CboTipIngreso.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("EstadoDocumento")) Then
        '                Me.CboEstadoDocumeto.Text = DataSet.Tables("LlamaLiquida").Rows(0)("EstadoDocumento")
        '            Else
        '                Me.CboEstadoDocumeto.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("TipoCompra")) Then
        '                Me.CboTipoCompra.Text = DataSet.Tables("LlamaLiquida").Rows(0)("TipoCompra")
        '            Else
        '                Me.CboTipoCompra.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("RangoImperfeccion")) Then
        '                Me.CboImperfeccion.Text = DataSet.Tables("LlamaLiquida").Rows(0)("RangoImperfeccion")
        '            Else
        '                Me.CboImperfeccion.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("EdoFisico")) Then
        '                Me.CboEdofisico.Text = DataSet.Tables("LlamaLiquida").Rows(0)("EdoFisico")
        '            Else
        '                Me.CboEdofisico.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("NomCalidad")) Then
        '                Me.CboCalidad.Text = DataSet.Tables("LlamaLiquida").Rows(0)("NomCalidad")
        '            Else
        '                Me.CboCalidad.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Dano")) Then
        '                Me.CboTipDano.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Dano")
        '            Else
        '                Me.CboTipDano.Text = ""
        '            End If

        '            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Simbolo")) Then
        '                Me.CboMoneda.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Simbolo")
        '            Else
        '                Me.CboMoneda.Text = ""
        '            End If

        '            Sql = "SELECT  ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.Precio, DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio AS ValorBrutoC$,   DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio / TipoCambio.TipoCambio AS ValorBruto$ FROM   LiquidacionPergamino INNER JOIN    DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN   ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN    TipoCambio ON LiquidacionPergamino.IdMonedaPreecio = TipoCambio.IdTipoCambio   WHERE  (LiquidacionPergamino.Codigo = '" & Me.TxtNumeroEnsamble.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "RecibosLiquida")
        '            Me.BinDetalleRecLiq.DataSource = DataSet.Tables("RecibosLiquida")
        '            Me.TDGridDetalleRecibos.DataSource = Me.BinDetalleRecLiq.DataSource


        '            Me.TDGridDetalleRecibos.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
        '            Me.TDGridDetalleRecibos.Columns(0).ValueItems.CycleOnClick = True
        '            With Me.TDGridDetalleRecibos.Columns(0).ValueItems.Values

        '                item.Value = "False"
        '                item.DisplayValue = Me.ImageList.Images(1)
        '                .Add(item)

        '                item = New C1.Win.C1TrueDBGrid.ValueItem()
        '                item.Value = "True"
        '                item.DisplayValue = Me.ImageList.Images(0)
        '                .Add(item)

        '                Me.TDGridDetalleRecibos.Columns(0).ValueItems.Translate = True
        '            End With

        '            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).Width = 147
        '            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).Width = 147
        '            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).Width = 147
        '            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).Width = 147
        '            Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).Width = 147

        '            Me.TDGridDetalleRecibos.Columns("ValorBruto$").NumberFormat = "##,##0.00"
        '            Me.TDGridDetalleRecibos.Columns("Precio").NumberFormat = "##,##0.00"
        '            Me.TDGridDetalleRecibos.Columns("PesoNeto").NumberFormat = "##,##0.00"
        '            Me.TDGridDetalleRecibos.Columns("ValorBrutoC$").NumberFormat = "##,##0.00"
        '            Me.TDGridDetalleRecibos.Columns("ValorBruto$").NumberFormat = "##,##0.00"

        '            Sql = "SELECT  AplicacionLiquidacionPergamino.Descripcion AS Concepto, TipoPago.Descripcion AS TipoPago, DetalleDistribucion.Monto,DetalleDistribucion.Monto - DetalleDistribucion.Monto AS Saldo,  DetalleDistribucion.FechaPago AS Fecha   FROM    DetalleDistribucion INNER JOIN   AplicacionLiquidacionPergamino ON DetalleDistribucion.IdAplicacionLiquidacionPergamino = AplicacionLiquidacionPergamino.IdAplicacionLiquidacionPergamino INNER JOIN  TipoPago ON DetalleDistribucion.IdTipoPago = TipoPago.IdTipoPago INNER JOIN LiquidacionPergamino ON DetalleDistribucion.IdLiquidacionPergamino = LiquidacionPergamino.IdLiquidacionPergamino  WHERE  (LiquidacionPergamino.Codigo = '" & Me.TxtNumeroEnsamble.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "DistrbLiquida")
        '            Me.TDBGRidDistribucion.DataSource = DataSet.Tables("DistrbLiquida")


        '            Me.TDBGRidDistribucion.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
        '            With Me.TDBGRidDistribucion.Columns(0).ValueItems.Values
        '                Do While count > i
        '                    If i = 0 Then
        '                        Descripcion = DataSet.Tables("DistrbLiquida").Rows(i)("Concepto")
        '                        item1.Value = Descripcion
        '                        .Add(item1)
        '                    Else
        '                        Descripcion = DataSet.Tables("DistrbLiquida").Rows(i)("Concepto")
        '                        item1 = New C1.Win.C1TrueDBGrid.ValueItem()
        '                        item1.Value = Descripcion
        '                        .Add(item1)
        '                    End If
        '                    i = i + 1
        '                Loop
        '            End With
        '            count = 0
        '            i = 0
        '            '____________________________________________________
        '            'LLENE LOS COMBOBOX(0) DEL GRID DE DISTRBUCION 
        '            '____________________________________________________
        '            Me.TDBGRidDistribucion.Columns(1).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
        '            With Me.TDBGRidDistribucion.Columns(1).ValueItems.Values
        '                Do While count > i
        '                    If i = 0 Then
        '                        Descripcion = DataSet.Tables("DistrbLiquida").Rows(i)("TipoPago")
        '                        item2.Value = Descripcion
        '                        .Add(item2)
        '                    Else
        '                        Descripcion = DataSet.Tables("DistrbLiquida").Rows(i)("TipoPago")
        '                        item2 = New C1.Win.C1TrueDBGrid.ValueItem()
        '                        item2.Value = Descripcion
        '                        .Add(item2)
        '                    End If
        '                    i = i + 1
        '                Loop
        '            End With

        '            'ACTUALIZO EL GRID
        '            SumaGrid()
        '        Else
        '            Button3_Click(sender, e)
        '            Exit Sub
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '    End Try
        'End Sub
        'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '    Quien = "CodigoProveedor"
        '    My.Forms.FrmConsultas.ShowDialog()
        '    Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub
    Private Sub TDGridDetalleRecibos_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridDetalleRecibos.AfterColUpdate
        Dim PesoBruto As Double
        Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double, ResultadoC As Double, ResultadoD As Double, TipoImpuesto As String
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, ContarSelec As Double, estado As Boolean, codigo As String, ContaTrue As Double
        Dim IdTipCompra As Integer, Ingreso As Integer, eleccion As Boolean, CodLocalidad As String, codigoRecibo As String, CadenaDiv() As String, Cadena As String
        Dim PorImperfeccion As Double, Sacos As Double, PesoBruto2 As Double, Tara As Double, NewValorBrtCor As Double, NewValorBrtDol As Double, Posicion As Integer
        Dim PesoNeto As Double, PrecioNetoCor As Double, PrecioNetoDol As Double, PesoCompara As Double

        i = 0
        PesoBruto = 0
        valorCor = 0
        ValorDol = 0
        Registros = Me.TDGridDetalleRecibos.RowCount

        eleccion = Me.BinDetalleRecLiq.Item(Me.TDGridDetalleRecibos.Row)("Aplicar")


        If eleccion = False Then
            Me.TDGridDetalleRecibos.Columns("PesoNeto").Text = Me.BinDetalleRecLiq.Item(Me.TDGridDetalleRecibos.Row)("PesoNTCompara")
        End If

        PesoNeto = Me.TDGridDetalleRecibos.Columns("PesoNeto").Text
        PrecioNetoCor = Me.TDGridDetalleRecibos.Columns("Precio").Text
        PesoCompara = Me.TDGridDetalleRecibos.Columns("PesoNTCompara").Text

        If PesoNeto > PesoCompara Or PesoNeto <= 0 Then
            Me.TDGridDetalleRecibos.Columns("PesoNeto").Text = PesoCompara
            PesoNeto = Me.TDGridDetalleRecibos.Columns("PesoNeto").Text
            Me.TDGridDetalleRecibos.Columns("ValorBrutoC$").Text = PesoNeto * PrecioNetoCor
            Me.TDGridDetalleRecibos.Columns("ValorBruto$").Text = (PesoNeto * PrecioNetoCor) / TasaCambio
        Else
            Me.TDGridDetalleRecibos.Columns("ValorBrutoC$").Text = PesoNeto * PrecioNetoCor
            Me.TDGridDetalleRecibos.Columns("ValorBruto$").Text = (PesoNeto * PrecioNetoCor) / TasaCambio
        End If

        SumaGrid1()

        'Do While Registros > i
        '    eleccion = Me.BinDetalleRecLiq.Item(i)("Aplicar")
        '    If Not eleccion = False Then
        '        '____________________________________________
        '        'CONTADOR PARA VER CUANTOS VERDADEROS SON 
        '        '____________________________________________
        '        ContaTrue = ContaTrue + 1
        '        '________________________________________________________________________________________
        '        'VALIDAMOS EL NUMERO DE LIQUIDACION DE RECIBOS DIRECTOS AUTOMATICOS  
        '        '________________________________________________________________________________________
        '        PesoBruto = Me.BinDetalleRecLiq.Item(i)("PesoNeto") + PesoBruto
        '        valorCor = Me.BinDetalleRecLiq.Item(i)("ValorBrutoC$") + valorCor
        '        ValorDol = Me.BinDetalleRecLiq.Item(i)("ValorBruto$") + ValorDol

        '        PorImperfeccion = Me.BinDetalleRecLiq.Item(i)("Imperfeccion") + PorImperfeccion
        '        Sacos = Me.BinDetalleRecLiq.Item(i)("CantidadSacos") + Sacos
        '        PesoBruto2 = Me.BinDetalleRecLiq.Item(i)("PesoBruto") + PesoBruto2
        '        Tara = Me.BinDetalleRecLiq.Item(i)("Tara") + Tara

        '        codigo = Me.BinDetalleRecLiq.Item(i)("NºRecibo")

        '        If Len(Trim(codigo)) > 6 Then
        '            CadenaDiv = codigo.Split("-")
        '            CodLocalidad = CadenaDiv(0)
        '            codigoRecibo = CadenaDiv(1)
        '        Else
        '            codigoRecibo = codigo
        '        End If

        '        If IdTipoCompra = 108 And (IdTipoIngreso = 1646 Or IdTipoIngreso = 295) And eleccion = True Then
        '            Me.TxtNumeroEnsamble.Text = codigoRecibo
        '            Me.TxtIdLocalidad.Text = CodLocalidad
        '        End If

        '        i = i + 1

        '    Else
        '        i = i + 1
        '    End If
        'Loop




        ''////////////////////////////////Calulos de los Impuestos///////////////////////

        'Me.LblTotalPesoKG.Text = "= " + Format(PesoBruto, "##,##0.00")
        'Me.LblValorC.Text = "= " + Format(valorCor, "##,##0.00")
        'Me.LblValorU.Text = "= " + Format(ValorDol, "##,##0.00")


        'Me.TxtPorcentajeImperfec.Text = Format(PorImperfeccion, "####0.00")
        'Me.TxtSacos.Text = Format(Sacos, "####0.00")
        'Me.TextPesoBruto.Text = Format(PesoBruto2, "####0.00")
        'Me.TxtTAra.Text = Format(Tara, "####0.00")

        'totalCor = Mid(Me.LblValorC.Text, 3, Len(Me.LblValorC.Text))
        'totalDol = Mid(Me.LblValorU.Text, 3, Len(Me.LblValorU.Text))

        'If Me.Checkpor1.Checked = True Then
        '    TipoImpuesto = "Imp. Municipal"
        '    SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto1")

        '    Porcentaje = DataSet.Tables("Impuesto1").Rows(0)("Valor")
        '    ImpMuniC = Porcentaje * totalCor
        '    ImpMuniD = Porcentaje * totalDol
        'Else
        '    ImpMuniC = 0
        '    ImpMuniD = 0
        'End If

        'Porcentaje = 0

        'If Me.Checkpor2.Checked = True Then

        '    TipoImpuesto = "Retención Definitiva"
        '    SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto2")

        '    Porcentaje = DataSet.Tables("Impuesto2").Rows(0)("Valor")
        '    RetDefC = Porcentaje * totalCor
        '    RetDefD = Porcentaje * totalDol

        '    Me.TxtRentDefC.Text = RetDefC
        '    Me.TxtRentDefD.Text = RetDefD
        'Else
        '    RetDefC = 0
        '    RetDefD = 0
        '    Me.TxtRentDefC.Text = "0.00"
        '    Me.TxtRentDefD.Text = "0.00"
        'End If

        'Porcentaje = 0

        'If Me.Checkbox4.Checked = True Then
        '    TipoImpuesto = "Retención 2%"
        '    SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto4")

        '    Porcentaje = DataSet.Tables("Impuesto4").Rows(0)("Valor")
        '    Reten2C = Porcentaje * totalCor
        '    Reten2D = Porcentaje * totalDol
        'Else
        '    Reten2C = 0
        '    Reten2D = 0
        'End If

        'If Me.Checkpor3.Checked = True Then
        '    TipoImpuesto = "Retención 3%"
        '    SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto3")

        '    Porcentaje = DataSet.Tables("Impuesto3").Rows(0)("Valor")
        '    Ret3C = Porcentaje * totalCor
        '    Ret3D = Porcentaje * totalDol
        'Else
        '    Ret3C = 0
        '    Ret3D = 0
        'End If

        ''aqui va el otro

        'TotalDecC = ImpMuniC + RetDefC + Ret3C + Reten2C
        'TotalDecD = ImpMuniD + RetDefD + Ret3D + Reten2D

        'Me.TxtTotalDecC.Text = Format(TotalDecC, "##,##0.00")
        'Me.TxtTotalDecD.Text = Format(TotalDecD, "##,##0.00")

        'NetoPagarC = totalCor - TotalDecC
        'NetoPagarD = totalDol - TotalDecD

        'Me.TxtTotalCor.Text = Format(NetoPagarC, "##,##0.00")
        'Me.TxtTotalDol.Text = Format(NetoPagarD, "##,##0.00")



    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkpor1.CheckedChanged
        'Dim PesoBruto As Double
        'Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double, ResultadoC As Double, ResultadoD As Double, TipoImpuesto As String
        'Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date

        'If Me.Checkpor1.Checked = True Then
        '    TipoImpuesto = "Imp. Municipal"
        '    SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto1")
        '    'Fechainicial = DataSet.Tables("Impuesto1").Rows(0)("VigenciaInicial")
        '    'FechaFinal = DataSet.Tables("Impuesto1").Rows(0)("VigenciaFinal")
        '    'Fechanow = DateTime.Now

        '    'If Fechainicial > Fechanow Or FechaFinal < Fechanow Then
        '    '    Me.Checkpor1.Enabled = False
        '    'Else
        '    '    Porcentaje = DataSet.Tables("Impuesto1").Rows(0)("Valor")
        '    'End If
        '    Porcentaje = DataSet.Tables("Impuesto1").Rows(0)("Valor")
        '    'Porcentaje = 0.01
        '    ImpMuniC = Porcentaje * totalCor
        '    ImpMuniD = Porcentaje * totalDol
        'Else
        '    ImpMuniC = 0
        '    ImpMuniD = 0
        'End If
        'TotalDecC = ImpMuniC + RetDefC + Ret3C + Reten2C
        'TotalDecD = ImpMuniD + RetDefD + Ret3D + Reten2D

        'Me.TxtTotalDecC.Text = Format(TotalDecC, "##,##0.00")
        'Me.TxtTotalDecD.Text = Format(TotalDecD, "##,##0.00")

        'NetoPagarC = totalCor - TotalDecC
        'NetoPagarD = totalDol - TotalDecD

        'Me.TxtTotalCor.Text = Format(NetoPagarC, "##,##0.00")
        'Me.TxtTotalDol.Text = Format(NetoPagarD, "##,##0.00")
        CalculaPrecioBruto()
        CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
        CalcularImpuesto()

        ValidaDistribuicion()

    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkpor2.CheckedChanged
        'Dim PesoBruto As Double
        'Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double, ResultadoC As Double, ResultadoD As Double, TipoImpuesto As String
        'Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date

        'If Me.Checkpor2.Checked = True Then
        '    TipoImpuesto = "Retención Definitiva"
        '    SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto2")
        '    'Fechainicial = DataSet.Tables("Impuesto2").Rows(0)("VigenciaInicial")
        '    'FechaFinal = DataSet.Tables("Impuesto2").Rows(0)("VigenciaFinal")
        '    'Fechanow = DateTime.Now

        '    'If Fechainicial > Fechanow Or FechaFinal < Fechanow Then
        '    '    Me.Checkpor2.Enabled = False
        '    'Else
        '    '    Porcentaje = DataSet.Tables("Impuesto2").Rows(0)("Valor")
        '    'End If
        '    Porcentaje = DataSet.Tables("Impuesto2").Rows(0)("Valor")
        '    'Porcentaje = 0.015
        '    RetDefC = Porcentaje * totalCor
        '    RetDefD = Porcentaje * totalDol

        '    Me.TxtRentDefC.Text = RetDefC
        '    Me.TxtRentDefD.Text = RetDefD
        'Else
        '    RetDefC = 0
        '    RetDefD = 0
        '    Me.TxtRentDefC.Text = "0.00"
        '    Me.TxtRentDefD.Text = "0.00"
        'End If
        'TotalDecC = ImpMuniC + RetDefC + Ret3C + Reten2C
        'TotalDecD = ImpMuniD + RetDefD + Ret3D + Reten2D

        'Me.TxtTotalDecC.Text = Format(TotalDecC, "##,##0.00")
        'Me.TxtTotalDecD.Text = Format(TotalDecD, "##,##0.00")

        'NetoPagarC = totalCor - TotalDecC
        'NetoPagarD = totalDol - TotalDecD

        'Me.TxtTotalCor.Text = Format(NetoPagarC, "##,##0.00")
        'Me.TxtTotalDol.Text = Format(NetoPagarD, "##,##0.00")
        CalculaPrecioBruto()
        CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
        CalcularImpuesto()

        ValidaDistribuicion()
    End Sub
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkpor3.CheckedChanged
        'Dim PesoBruto As Double
        'Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double, ResultadoC As Double, ResultadoD As Double, TipoImpuesto As String
        'Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date

        'If Me.Checkpor3.Checked = True Then
        '    TipoImpuesto = "Retención 3%"
        '    SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto3")
        '    'Fechainicial = DataSet.Tables("Impuesto3").Rows(0)("VigenciaInicial")
        '    'FechaFinal = DataSet.Tables("Impuesto3").Rows(0)("VigenciaFinal")
        '    'Fechanow = DateTime.Now

        '    'If Fechainicial > Fechanow Or FechaFinal < Fechanow Then
        '    '    Me.Checkpor3.Enabled = False
        '    'Else
        '    '    Porcentaje = DataSet.Tables("Impuesto3").Rows(0)("Valor")
        '    'End If
        '    'Porcentaje = 0.03
        '    Porcentaje = DataSet.Tables("Impuesto3").Rows(0)("Valor")
        '    Ret3C = Porcentaje * totalCor
        '    Ret3D = Porcentaje * totalDol
        'Else
        '    Ret3C = 0
        '    Ret3D = 0
        'End If
        'TotalDecC = ImpMuniC + RetDefC + Ret3C + Reten2C
        'TotalDecD = ImpMuniD + RetDefD + Ret3D + Reten2D

        'Me.TxtTotalDecC.Text = Format(TotalDecC, "##,##0.00")
        'Me.TxtTotalDecD.Text = Format(TotalDecD, "##,##0.00")

        'NetoPagarC = totalCor - TotalDecC
        'NetoPagarD = totalDol - TotalDecD

        'Me.TxtTotalCor.Text = Format(NetoPagarC, "##,##0.00")
        'Me.TxtTotalDol.Text = Format(NetoPagarD, "##,##0.00")
        CalculaPrecioBruto()
        CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
        CalcularImpuesto()

        ValidaDistribuicion()
    End Sub
    Private Sub Checkbox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkbox4.CheckedChanged
        'Dim PesoBruto As Double
        'Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double, ResultadoC As Double, ResultadoD As Double, TipoImpuesto As String
        'Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date

        'If Me.Checkbox4.Checked = True Then
        '    TipoImpuesto = "Retención 2%"
        '    SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Impuesto4")
        '    'Fechainicial = DataSet.Tables("Impuesto4").Rows(0)("VigenciaInicial")
        '    'FechaFinal = DataSet.Tables("Impuesto4").Rows(0)("VigenciaFinal")
        '    'Fechanow = DateTime.Now

        '    'If Fechainicial > Fechanow Or FechaFinal < Fechanow Then
        '    '    Me.Checkbox4.Enabled = False
        '    'Else
        '    '    Porcentaje = DataSet.Tables("Impuesto4").Rows(0)("Valor")
        '    'End If
        '    'Porcentaje = 0.01
        '    Porcentaje = DataSet.Tables("Impuesto4").Rows(0)("Valor")
        '    Reten2C = Porcentaje * totalCor
        '    Reten2D = Porcentaje * totalDol
        'Else
        '    Reten2C = 0
        '    Reten2D = 0
        'End If
        'TotalDecC = ImpMuniC + RetDefC + Ret3C + Reten2C
        'TotalDecD = ImpMuniD + RetDefD + Ret3D + Reten2D

        'Me.TxtTotalDecC.Text = Format(TotalDecC, "##,##0.00")
        'Me.TxtTotalDecD.Text = Format(TotalDecD, "##,##0.00")

        'NetoPagarC = totalCor - TotalDecC
        'NetoPagarD = totalDol - TotalDecD

        'Me.TxtTotalCor.Text = Format(NetoPagarC, "##,##0.00")
        'Me.TxtTotalDol.Text = Format(NetoPagarD, "##,##0.00")
        CalculaPrecioBruto()
        CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
        CalcularImpuesto()

        ValidaDistribuicion()
    End Sub


    Private Sub CboCalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCalidad.SelectedIndexChanged
        limpiaGrid()

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, i = 0


        '//////////////////////IdCalidad//////////////////////////////////
        SqlString = "SELECT       IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion  FROM   Calidad  WHERE (NomCalidad = '" & Me.CboCalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Calida1")
        IdCalidad = DataSet.Tables("Calida1").Rows(0)("IdCalidad")


        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD Y CATEGORIA  /////////////////////////////////////
        SqlString = "SELECT  RelacionCalidadxCategoria.IdCalidad, RelacionCalidadxCategoria.IdCategoriaCAfe, Calidad.NomCalidad, RangoImperfeccion.Nombre FROM  RelacionCalidadxCategoria INNER JOIN Calidad ON RelacionCalidadxCategoria.IdCalidad = Calidad.IdCalidad INNER JOIN RangoImperfeccion ON RelacionCalidadxCategoria.IdCategoriaCAfe = RangoImperfeccion.IdRangoImperfeccion  " & _
                            "WHERE (Calidad.NomCalidad = '" & Me.CboCalidad.Text & "') AND (RangoImperfeccion.IdCosecha = " & IdCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultaCalidad")
        Me.CboImperfeccion.DataSource = DataSet.Tables("ConsultaCalidad")


        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD Y DAÑO /////////////////////////////////////
        SqlString = "SELECT  Calidad.NomCalidad, Dano.IdDano, Dano.Nombre FROM Calidad INNER JOIN RelacionCalidadxDaño ON Calidad.IdCalidad = RelacionCalidadxDaño.IdCalidad INNER JOIN Dano ON RelacionCalidadxDaño.IdDaño = Dano.IdDano WHERE  (Calidad.NomCalidad = '" & Me.CboCalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Daño")
        Me.CboTipDano.DataSource = DataSet.Tables("Daño")

        '////////////////////////////////////////////BUSCO LA RELACION ENTRE CALIDAD  Y ESTADO FISICO /////////////////////////////////////
        SqlString = "SELECT  Calidad.NomCalidad, EstadoFisico.Descripcion FROM  Calidad INNER JOIN  RelacionCalidadxEstadoFisico ON Calidad.IdCalidad = RelacionCalidadxEstadoFisico.IdCalidad INNER JOIN  EstadoFisico ON RelacionCalidadxEstadoFisico.EstadoFisico = EstadoFisico.IdEdoFisico WHERE  (Calidad.NomCalidad ='" & Me.CboCalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Fisico")
        Me.CboEdofisico.DataSource = DataSet.Tables("Fisico")

        'DataSet.Tables("ConsultaCalidad").Reset()
        'DataSet.Tables("Daño").Reset()
        'DataSet.Tables("Fisico").Reset()
        'DataSet.Tables("Calida1").Reset()
        CalculaPrecioBruto()
    End Sub

    Private Sub C1Combo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLocalidadLiq.TextChanged
        DataSet.Reset()
        Me.BinDistribucion.ResetBindings(True)
        Me.LblSucursal.Text = Me.CboLocalidadLiq.Text
        SqlString = "SELECT  * FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.LblSucursal.Text & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "locali")
        If DataSet.Tables("locali").Rows.Count = 0 Then
            'MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            'Exit Sub
        Else
            IdLocalidadLiqui = DataSet.Tables("locali").Rows(0)("IdLugarAcopio")
            Me.TxtIdLocalidad.Text = DataSet.Tables("locali").Rows(0)("CodLugarAcopio")

            'If Quien = "NumeroChange" Then
            '    Quien = ""
            '    Exit Sub
            'Else
            '    FiltarLimpiar()
            'End If

            'sql = "SELECT  IdLiquidacionPergamino, RIGHT(Codigo, 6) AS Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso,     IdTipoIngreso, IdCosecha, IdLocalidad, IdTipoCompra    FROM   LiquidacionPergamino    WHERE  (IdTipoCompra = 109) AND (IdCosecha = '" & IdCosecha & "') AND (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdTipoIngreso = 1646)  ORDER BY Codigo DESC"
            'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            'DataAdapter.Fill(DataSet, "LiquidaCodigo")
            'If DataSet.Tables("LiquidaCodigo").Rows.Count = 0 Then
            '    Me.TxtNumeroEnsamble.Text = "000001"
            'Else
            '    Me.TxtNumeroEnsamble.Text = Format(DataSet.Tables("LiquidaCodigo").Rows(0)("Codigo") + 1, "00000#")
            'End If

        End If
        CalculaPrecioBruto()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Quien = "Localidad"
        My.Forms.FrmConsultas.ShowDialog()

        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Quien = "consulta"
            Me.CboLocalidadLiq.Text = My.Forms.FrmConsultas.Descripcion
        End If
    End Sub

    Public Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.BinDistribucion.ResetBindings(True)
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = "", SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item1 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim oDatarow As DataRow, Count As Double, i As Integer
        Dim Fecha As Date, IdlocalidadRec As Double, PesoNeto As Double, Precio1 As Double, Precio As Double
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, EsPorcentaje As Boolean, IdLocalidad As Integer, DeduccionDano As Double, DD As Double
        Dim DeducEstado As Double, Descripcion As String, PesoRestante As Double, EstadoLiquidado As Boolean, Parcial As Boolean
        Dim Saldo As Double, Monto As Double, TotalSaldo As Double, TotalMonto As Double, IdRecibo As Integer

        If CDbl(Me.TxtPrecio.Text) = 0.0 Then
            MsgBox("No se encontro precio", MsgBoxStyle.Exclamation, "Liquidacion")
            Exit Sub
        End If
        If Me.CboCodigoProveedor.Text = "" Then
            MsgBox("SE NECESITAN MAS DATOS PARA PODER FILTAR", MsgBoxStyle.Exclamation, "Liquidacion")
            Exit Sub
        End If
        '___________________________________________________________________________________________________________
        'SACAMOS EL IREGION 
        '___________________________________________________________________________________________________________
        sql = "SELECT  IdLugarAcopio, NomLugarAcopio,IdRegion   FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidadLiq.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "LocalidadLiqui")
        If DataSet.Tables("LocalidadLiqui").Rows.Count <> 0 Then
            IdLocalidad = DataSet.Tables("LocalidadLiqui").Rows(0)("IdLugarAcopio")
            IdRegion = DataSet.Tables("LocalidadLiqui").Rows(0)("IdRegion")
        End If
        '___________________________________________________________________________________________________________
        'VOY HACER UNA CONSULTA QUE NO RETORNA NADA,PARA RELLENAR EL GRID
        '___________________________________________________________________________________________________________

        SqlString = "SELECT   ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ISNULL(PrecioCafe.Precio, 0) AS Precio, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) * ISNULL(PrecioCafe.Precio, 0) AS ValorBrutoC$, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara)  * ISNULL(PrecioCafe.Precio, 0) / ISNULL(TipoCambio.TipoCambio, 1) AS ValorBruto$, ReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto,DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.Imperfeccion AS PesoNTCompara FROM  ReciboCafePergamino INNER JOIN   DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  TipoCompra ON ReciboCafePergamino.IdTipoCompra = TipoCompra.IdTipoCompra LEFT OUTER JOIN   TipoCambio ON ReciboCafePergamino.Fecha = TipoCambio.FechaTipoCambio LEFT OUTER JOIN   PrecioCafe ON ReciboCafePergamino.IdLocalidad = PrecioCafe.IdLocalidad AND ReciboCafePergamino.IdCalidad = PrecioCafe.IdCalidad WHERE  (ReciboCafePergamino.IdProductor = '-100') AND (ReciboCafePergamino.IdDano = " & IdDano & ") AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (ReciboCafePergamino.IdLocalidadLiquidacion = " & IdLocalidad & ") AND (DetalleReciboCafePergamino.IdEdoFisico = " & IdEdoFisico & ") AND (ReciboCafePergamino.IdTipoCompra = " & IdTipoCompra & ")AND (ReciboCafePergamino.IdTipoIngreso = '" & IdTipoIngreso & "')"
        'SqlString = "SELECT  ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ISNULL(PrecioCafe.Precio, 0) AS Precio, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) * ISNULL(PrecioCafe.Precio, 0) AS ValorBrutoC$, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) * ISNULL(PrecioCafe.Precio, 0) / ISNULL(TipoCambio.TipoCambio, 1) AS ValorBruto$, ReciboCafePergamino.Fecha  FROM  ReciboCafePergamino INNER JOIN   DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino LEFT OUTER JOIN    TipoCambio ON ReciboCafePergamino.Fecha = TipoCambio.FechaTipoCambio LEFT OUTER JOIN  PrecioCafe ON ReciboCafePergamino.IdLocalidad = PrecioCafe.IdLocalidad AND ReciboCafePergamino.IdCalidad = PrecioCafe.IdCalidad " & _
        '                "WHERE(ReciboCafePergamino.IdProductor = '-100')AND (ReciboCafePergamino.IdDano = " & IdDano & ") AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (ReciboCafePergamino.IdLocalidadLiquidacion = " & IdLocalidad & ") AND  (DetalleReciboCafePergamino.IdEdoFisico = " & IdEdoFisico & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecibo")
        '___________________________________________________________________________________________________________
        'UNA CONSULTA CON ALGUNOS DATOS 
        'PARA SACAR ALGUNOS DATOS 
        '___________________________________________________________________________________________________________
        'AND (ReciboCafePergamino.Liquidado = 0)
        If Me.EsProductorManual = True Then
            SqlString = "SELECT ReciboCafePergamino.*, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.CantidadSacos,DetalleReciboCafePergamino.Imperfeccion FROM  ReciboCafePergamino INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino WHERE    (DetalleReciboCafePergamino.IdEdoFisico = " & IdEdoFisico & ") AND (ReciboCafePergamino.IdLocalidadLiquidacion = " & IdLocalidadLiqui & ") AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (ReciboCafePergamino.IdDano = " & IdDano & ") AND  (ReciboCafePergamino.CedulaManual = '" & Me.Cedula & "') AND (ReciboCafePergamino.IdRangoImperfeccion = " & IdCategoria & ")AND (ReciboCafePergamino.IdTipoCompra = " & IdTipoCompra & ") AND (ReciboCafePergamino.IdTipoCafe = 1) AND (ReciboCafePergamino.IdEstadoDocumento = 294) " 'AND (ReciboCafePergamino.IdTipoIngreso = '" & IdTipoIngreso & "')
        Else
            SqlString = "SELECT ReciboCafePergamino.*, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.CantidadSacos,DetalleReciboCafePergamino.Imperfeccion FROM  ReciboCafePergamino INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino WHERE    (DetalleReciboCafePergamino.IdEdoFisico = " & IdEdoFisico & ") AND (ReciboCafePergamino.IdLocalidadLiquidacion = " & IdLocalidadLiqui & ") AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (ReciboCafePergamino.IdDano = " & IdDano & ") AND  (ReciboCafePergamino.IdProductor = " & IdProductor & ") AND (ReciboCafePergamino.IdRangoImperfeccion = " & IdCategoria & ")AND (ReciboCafePergamino.IdTipoCompra = " & IdTipoCompra & ") AND (ReciboCafePergamino.IdTipoCafe = 1) AND (ReciboCafePergamino.IdEstadoDocumento = 294) " 'AND (ReciboCafePergamino.IdTipoIngreso = '" & IdTipoIngreso & "')
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recib")
        Count = DataSet.Tables("Recib").Rows.Count
        i = 0

        'DataSet.Tables("Precio3").Reset()

        Do While Count > i
            IdRecibo = DataSet.Tables("Recib").Rows(i)("IdReciboPergamino")
            PesoNeto = DataSet.Tables("Recib").Rows(i)("PesoBruto") - DataSet.Tables("Recib").Rows(i)("Tara")
            EstadoLiquidado = DataSet.Tables("Recib").Rows(i)("Liquidado")
            If IdTipoCompra = 109 Then
                SqlString = "SELECT  IdReciboPergamino, SUM(PesoNeto) AS PesoNeto    FROM            DetalleLiquidacionPergamino    WHERE       (IdReciboPergamino ='" & IdRecibo & "')   GROUP BY IdReciboPergamino   ORDER BY IdReciboPergamino "
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "DetalleLiquidacion")
                If DataSet.Tables("DetalleLiquidacion").Rows.Count = 0 Then
                    PesoRestante = PesoNeto
                    Parcial = False
                Else
                    Parcial = True
                    PesoRestante = Format(PesoNeto - DataSet.Tables("DetalleLiquidacion").Rows(0)("PesoNeto"), "####0.00")
                    DataSet.Tables("DetalleLiquidacion").Reset()
                End If
            ElseIf IdTipoCompra = 108 Then
                PesoRestante = PesoNeto
                Parcial = False
            End If

            '______________________________________________________________________________________________________
            'LLENO EL GRIND 
            '______________________________________________________________________________________________________
            TasaCambio = Me.TxtTasaCambio.Text

            If PesoRestante > 0 And EstadoLiquidado = False Then
                oDatarow = DataSet.Tables("DetalleRecibo").NewRow
                oDatarow("Aplicar") = DataSet.Tables("Recib").Rows(i)("Seleccion")
                If Parcial = True Then
                    oDatarow("NºRecibo") = "Ø " & DataSet.Tables("Recib").Rows(i)("Codigo")
                    Parcial = False
                Else
                    Parcial = False
                    oDatarow("NºRecibo") = DataSet.Tables("Recib").Rows(i)("Codigo")
                End If
                oDatarow("PesoNeto") = PesoRestante
                oDatarow("Precio") = CDbl(Me.TxtPrecio.Text)
                oDatarow("ValorBrutoC$") = CDbl(Me.TxtPrecio.Text) * PesoNeto
                'TasaCambio = Me.TxtTasaCambio.Text
                If TasaCambio <> 0 Then
                    oDatarow("ValorBruto$") = (CDbl(Me.TxtPrecio.Text) * PesoNeto) / TasaCambio
                Else
                    MsgBox("No Existe Tasa de Cambio", MsgBoxStyle.Critical, "Registro de Bascula")
                    oDatarow("ValorBruto$") = (CDbl(Me.TxtPrecio.Text) * PesoNeto)
                End If
                oDatarow("IdReciboPergamino") = IdRecibo
                oDatarow("Imperfeccion") = DataSet.Tables("Recib").Rows(i)("Imperfeccion")
                oDatarow("CantidadSacos") = DataSet.Tables("Recib").Rows(i)("CantidadSacos")
                oDatarow("PesoBruto") = DataSet.Tables("Recib").Rows(i)("PesoBruto")
                oDatarow("Tara") = DataSet.Tables("Recib").Rows(i)("Tara")
                oDatarow("PesoNTCompara") = PesoRestante
                'oDatarow("Fecha") = Fecha
                DataSet.Tables("DetalleRecibo").Rows.Add(oDatarow)
            End If
            i = i + 1
        Loop

        Me.BinDetalleRecLiq.DataSource = DataSet.Tables("DetalleRecibo")
        Me.TDGridDetalleRecibos.DataSource = Me.BinDetalleRecLiq.DataSource
        If Me.BinDetalleRecLiq.Count = 0 Then
            MsgBox("NO HAY RECIBOS PARA EL FLITRO ESPECIFICADO", MsgBoxStyle.Exclamation, "Liquidacion")
            Exit Sub
        End If

        Me.TDGridDetalleRecibos.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
        Me.TDGridDetalleRecibos.Columns(0).ValueItems.CycleOnClick = True
        With Me.TDGridDetalleRecibos.Columns(0).ValueItems.Values

            item.Value = "False"
            item.DisplayValue = Me.ImageList.Images(1)
            .Add(item)

            item = New C1.Win.C1TrueDBGrid.ValueItem()
            item.Value = "True"
            item.DisplayValue = Me.ImageList.Images(0)
            .Add(item)

            Me.TDGridDetalleRecibos.Columns(0).ValueItems.Translate = True
        End With

        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).Width = 149
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).Width = 150
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).Width = 150
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).Width = 150
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).Width = 149
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(6).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(7).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(8).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(9).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(11).Visible = False


        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).Locked = True
        'Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(10).Locked = True
        'Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns().Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("NºRecibo").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("PesoNeto").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBrutoC$").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBruto$").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBruto$").Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("Precio").Locked = True
        'Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("TipoCambio").Locked = True


        Me.TDGridDetalleRecibos.Columns(2).Caption = "KG"
        Me.TDGridDetalleRecibos.Columns(3).Caption = "PrecioBruto C$/KG"
        Me.TDGridDetalleRecibos.Columns(5).Caption = "ValorBruto U$"


        Me.TDGridDetalleRecibos.Columns("ValorBruto$").NumberFormat = "##,##0.00"
        Me.TDGridDetalleRecibos.Columns("Precio").NumberFormat = "##,##0.00"
        Me.TDGridDetalleRecibos.Columns("PesoNeto").NumberFormat = "##,##0.00"
        Me.TDGridDetalleRecibos.Columns("ValorBrutoC$").NumberFormat = "##,##0.00"
        Me.TDGridDetalleRecibos.Columns("ValorBruto$").NumberFormat = "##,##0.00"
        Dim conta
        conta = Me.TDGridDetalleRecibos.RowCount
        i = 0


        'Do While conta > i
        '    If Me.TDGridDetalleRecibos.Item(i)("PesoNeto") = 0.0 Then
        '        Me.TDGridDetalleRecibos.Delete(i)
        '        If i <> 0 Then
        '            i = i - 1
        '        Else
        '            i = 0
        '        End If
        '    Else
        '        i = i + 1
        '    End If
        '    conta = Me.TDGridDetalleRecibos.RowCount
        'Loop


        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        SumaGrid1()

        '____________________________________________________
        'CARGO EL GRID CON UNA CONSULTA NULLA DISTRIBUCION
        '____________________________________________________

        SqlString = "SELECT  AplicacionLiquidacionPergamino.Descripcion AS Concepto, TipoPago.Descripcion AS TipoPago, TipoPago.Descripcion AS NumeroSolicitud, DetalleDistribucion.Monto, DetalleDistribucion.FechaPago,DetalleDistribucion.IdDetalleDistribucion  FROM DetalleDistribucion INNER JOIN  AplicacionLiquidacionPergamino ON DetalleDistribucion.IdAplicacionLiquidacionPergamino = AplicacionLiquidacionPergamino.IdAplicacionLiquidacionPergamino INNER JOIN                          TipoPago ON DetalleDistribucion.IdTipoPago = TipoPago.IdTipoPago WHERE        (DetalleDistribucion.IdDetalleDistribucion = - 100)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Distribucion15")
        'Me.BinDistribucion.DataSource = DataSet.Tables("Distribucion")
        'Me.TDBGRidDistribucion.DataSource = Me.BinDistribucion.DataSource
        Dim Concepto As String, TipoPago As String

        sql = " SELECT     IdAplicacionLiquidacionPergamino, Code, Descripcion, Activo   FROM   AplicacionLiquidacionPergamino   WHERE (Activo = 1) AND   (Code = '0')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "AplicaLiquida")
        Concepto = DataSet.Tables("AplicaLiquida").Rows(0)("Descripcion")

        SqlString = "SELECT  IdTipoPago, Code, Descripcion, Activo FROM   TipoPago   WHERE (Activo = 1) AND (Code = '3')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "PagoLiquida")
        TipoPago = DataSet.Tables("PagoLiquida").Rows(0)("Descripcion")

        Dim DataRowDistribucion As DataRow
        DataRowDistribucion = DataSet.Tables("Distribucion15").NewRow
        DataRowDistribucion("Concepto") = Concepto
        DataRowDistribucion("TipoPago") = TipoPago
        DataRowDistribucion("NumeroSolicitud") = ""
        DataRowDistribucion("Monto") = Me.TxtTotalDol.Text
        DataRowDistribucion("FechaPago") = Format(CDate(Me.DTPFecha.Value), "dd/MM/yyyy")
        DataSet.Tables("Distribucion15").Rows.Add(DataRowDistribucion)

        Me.BinDistribucion.DataSource = DataSet.Tables("Distribucion15")
        Me.TDBGRidDistribucion.DataSource = Me.BinDistribucion.DataSource

        '____________________________________________________
        'LLENE LOS COMBOBOX(0) DEL GRID DE DISTRBUCION 
        '____________________________________________________
        Count = 0
        i = 0
        SqlString = "SELECT Descripcion   FROM    AplicacionLiquidacionPergamino"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "AplicacionLiquid")
        Count = DataSet.Tables("AplicacionLiquid").Rows.Count

        Me.TDBGRidDistribucion.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
        With Me.TDBGRidDistribucion.Columns(0).ValueItems.Values
            Do While Count > i
                If i = 0 Then
                    Descripcion = DataSet.Tables("AplicacionLiquid").Rows(i)("Descripcion")
                    item1.Value = Descripcion
                    .Add(item1)
                Else
                    Descripcion = DataSet.Tables("AplicacionLiquid").Rows(i)("Descripcion")
                    item1 = New C1.Win.C1TrueDBGrid.ValueItem()
                    item1.Value = Descripcion
                    .Add(item1)
                End If
                i = i + 1
            Loop
        End With
        Count = 0
        i = 0
        SqlString = "SELECT   Descripcion   FROM TipoPago WHERE  (Activo = 1) "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPago")
        Count = DataSet.Tables("TipoPago").Rows.Count
        '____________________________________________________
        'LLENE LOS COMBOBOX(0) DEL GRID DE DISTRBUCION 
        '____________________________________________________
        Me.TDBGRidDistribucion.Columns(1).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
        With Me.TDBGRidDistribucion.Columns(1).ValueItems.Values
            Do While Count > i
                If i = 0 Then
                    Descripcion = DataSet.Tables("TipoPago").Rows(i)("Descripcion")
                    item2.Value = Descripcion
                    .Add(item2)
                Else
                    Descripcion = DataSet.Tables("TipoPago").Rows(i)("Descripcion")
                    item2 = New C1.Win.C1TrueDBGrid.ValueItem()
                    item2.Value = Descripcion
                    .Add(item2)
                End If
                i = i + 1
            Loop
        End With

        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).Width = 160
        Me.TDBGRidDistribucion.Columns(2).EditMask = "#-##-#####"
        Me.TDBGRidDistribucion.Columns(2).EditMaskUpdate = True

        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(5).Visible = False

        '///////////////////////////////// LLENARE EL GRID DISTRIBUION /////////////////////////
        'If IdTipoCompra = 108 Then
        'Dim Concepto As String, TipoPago As String
        'sql = " SELECT     IdAplicacionLiquidacionPergamino, Code, Descripcion, Activo   FROM   AplicacionLiquidacionPergamino   WHERE (Activo = 1) AND   (Code = '0')"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "AplicaLiquida")
        'Concepto = DataSet.Tables("AplicaLiquida").Rows(0)("Descripcion")

        'SqlString = "SELECT  IdTipoPago, Code, Descripcion, Activo FROM   TipoPago   WHERE (Activo = 1) AND (Code = '3')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "PagoLiquida")
        'TipoPago = DataSet.Tables("PagoLiquida").Rows(0)("Descripcion")

        ' ''lleno los combos en el grid
        'Me.TDBGRidDistribucion.Columns(0).Text = Concepto
        'Me.TDBGRidDistribucion.Columns(1).Text = TipoPago
        'Me.TDBGRidDistribucion.Columns(2).Text = ""
        'Me.TDBGRidDistribucion.Columns(3).Text = Me.TxtTotalDol.Text
        'Me.TDBGRidDistribucion.Columns(4).Text = Format(CDate(Me.DTPFecha.Value), "dd/MM/yyyy")
        'Me.TDBGRidDistribucion.AllowAddNew = False
        ''ElseIf IdTipoCompra = 109 Then
        'Dim Concepto As String, TipoPago As String

        'sql = " SELECT     IdAplicacionLiquidacionPergamino, Code, Descripcion, Activo   FROM   AplicacionLiquidacionPergamino   WHERE (Activo = 1) AND   (Code = '0')"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "AplicaLiquida")
        'Concepto = DataSet.Tables("AplicaLiquida").Rows(0)("Descripcion")

        'SqlString = "SELECT  IdTipoPago, Code, Descripcion, Activo FROM   TipoPago   WHERE (Activo = 1) AND (Code = '3')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "PagoLiquida")
        'TipoPago = DataSet.Tables("PagoLiquida").Rows(0)("Descripcion")

        ' ''lleno los combos en el grid
        'Me.TDBGRidDistribucion.Columns(0).Text = Concepto
        'Me.TDBGRidDistribucion.Columns(1).Text = TipoPago
        'Me.TDBGRidDistribucion.Columns(2).Text = ""
        'Me.TDBGRidDistribucion.Columns(3).Text = Me.TxtTotalDol.Text
        'Me.TDBGRidDistribucion.Columns(4).Text = Format(CDate(Me.DTPFecha.Value), "dd/MM/yyyy")
        ''Me.TDBGRidDistribucion.AllowAddNew = False
        'End If
    End Sub
    '///////////////////////////////// FUNCION DE CALCULO PRECIO /////////////////////////
    Public Sub CalculaPrecioBruto()
        Dim IdRecibo As Integer, i As Integer, IdlocalidadRec, Precio1 As Double, Fecha As Date, PesoNeto As Double, Precio As Double, TipoImpuesto As String
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, EsPorcentaje As Boolean, IdLocalidad As Integer, DeduccionDano As Double, DD As Double, PorcentajeImpApli As Double
        Dim DeducEstado As Double, PrecioBruto As String, PrecioAutoriza As Double, PrecioAutoriza1 As Double, PrecioBrutoAutoriza As Double, TotalMonto As Double, Count As Double
        Dim ImpMunic As Double, RetDef As Double, Ret3 As Double, Ret2 As Double, TasaCambioPrecio As Double
        '////////////////////////////////////////Busco los recibos Para encontrar la fecha de los recibos ///////////////////////////

        'SqlString = "SELECT  IdImpuesto, Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE        (IdImpuesto = 8)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "PorceImpusAplica")
        'If DataSet.Tables("PorceImpusAplica").Rows.Count = 0 Then
        '    PorcentajeImpApli = 0
        'Else
        '    PorcentajeImpApli = DataSet.Tables("PorceImpusAplica").Rows(0)("Valor")
        'End If

        If Me.Checkpor1.Checked = True Then
            TipoImpuesto = "Imp. Municipal"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto1")
            ImpMunic = DataSet.Tables("Impuesto1").Rows(0)("Valor")
        Else
            ImpMunic = 0
        End If


        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION DEFINITIVA (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkpor2.Checked = True Then
            TipoImpuesto = "Retención Definitiva"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto2")
            RetDef = DataSet.Tables("Impuesto2").Rows(0)("Valor")

        Else
            RetDef = 0
        End If


        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION 3% (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkpor3.Checked = True Then
            TipoImpuesto = "Retención 3%"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto3")
            Ret3 = DataSet.Tables("Impuesto3").Rows(0)("Valor")

        Else
            Ret3 = 0
        End If

        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((
        '(((((((((((((((((((((((((((((((((((((((((((((RETENCION 2% (((((((((((((((((((((
        '((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((

        If Me.Checkbox4.Checked = True Then
            TipoImpuesto = "Retención 2%"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto4")
            Ret2 = DataSet.Tables("Impuesto4").Rows(0)("Valor")
        Else
            Ret2 = 0
        End If
        PorcentajeImpApli = ImpMunic + RetDef + Ret3 + Ret2

        'AND (ReciboCafePergamino.Liquidado = 0)

        If EsProductorManual = True Then
            SqlString = "SELECT ReciboCafePergamino.*, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.CantidadSacos,DetalleReciboCafePergamino.Imperfeccion FROM  ReciboCafePergamino INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino WHERE    (DetalleReciboCafePergamino.IdEdoFisico = " & IdEdoFisico & ") AND (ReciboCafePergamino.IdLocalidadLiquidacion = " & IdLocalidadLiqui & ") AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (ReciboCafePergamino.IdDano = " & IdDano & ") AND (ReciboCafePergamino.IdRangoImperfeccion = " & IdCategoria & ")AND (ReciboCafePergamino.IdTipoCompra = " & IdTipoCompra & ")AND (ReciboCafePergamino.IdTipoCafe = 1) AND (ReciboCafePergamino.IdEstadoDocumento = 294) AND (ReciboCafePergamino.CedulaManual = '" & Me.Cedula & "') "  '(ReciboCafePergamino.IdTipoIngreso = '" & IdTipoIngreso & "')
        Else
            SqlString = "SELECT ReciboCafePergamino.*, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.CantidadSacos,DetalleReciboCafePergamino.Imperfeccion FROM  ReciboCafePergamino INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino WHERE    (DetalleReciboCafePergamino.IdEdoFisico = " & IdEdoFisico & ") AND (ReciboCafePergamino.IdLocalidadLiquidacion = " & IdLocalidadLiqui & ") AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (ReciboCafePergamino.IdDano = " & IdDano & ") AND  (ReciboCafePergamino.IdProductor = " & IdProductor & ") AND (ReciboCafePergamino.IdRangoImperfeccion = " & IdCategoria & ")AND (ReciboCafePergamino.IdTipoCompra = " & IdTipoCompra & ")AND (ReciboCafePergamino.IdTipoCafe = 1) AND (ReciboCafePergamino.IdEstadoDocumento = 294)"  '(ReciboCafePergamino.IdTipoIngreso = '" & IdTipoIngreso & "')
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recib")
        Count = DataSet.Tables("Recib").Rows.Count
        If Count = 0 Then
            Me.TxtPrecio.Text = 0.0
            Exit Sub
        End If

        Do While Count > i
            IdRecibo = DataSet.Tables("Recib").Rows(i)("IdReciboPergamino")

            If DataSet.Tables("Recib").Rows(i)("IdTipoCompra") = 108 Then
                'Compra directa
                Fecha = DataSet.Tables("Recib").Rows(i)("Fecha")

                'SqlString = "SELECT    TipoCambio   FROM  TipoCambio  WHERE        (FechaTipoCambio = CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & "', 102))"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'DataAdapter.Fill(DataSet, "TasaCamb")
                'TasaCambioPrecio = DataSet.Tables("TasaCamb").Rows(0)("TipoCambio")

            ElseIf DataSet.Tables("Recib").Rows(i)("IdTipoCompra") = 109 Then
                'Compra deposito
                Fecha = Me.DTPFecha.Value

                'TasaCambio = Me.TxtTasaCfambio.Text
            End If
            '______________________________________________________________________________________________________()
            'PRECIO(CAFE)
            '______________________________________________________________________________________________________()
            If DataSet.Tables("Recib").Rows(i)("IdTipoCompra") = 108 Or DataSet.Tables("Recib").Rows(i)("IdTipoCompra") = 109 Then
                SqlString = "SELECT   IdPrecioCafe, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, FechaActualizacion  FROM     PrecioCafe   WHERE    (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & IdCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY FechaActualizacion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Precio")

                'SqlString = "SELECT        IdPrecioComplemento, IdCosecha, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion  FROM   PrecioComplemento   WHERE   (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & IdCategoria & ") AND (FechaActualizacion =  CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd HH:mm:ss") & "', 102))ORDER BY Corte DESC, FechaActualizacion DESC"
                SqlString = "SELECT  IdPrecioComplemento, IdCosecha, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion  FROM PrecioComplemento WHERE  (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & IdCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY Corte DESC, FechaActualizacion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "PrecioAutoriza")

                PrecioAutoriza = 0.0
                PrecioAutoriza1 = 0.0

                If DataSet.Tables("PrecioAutoriza").Rows.Count <> 0 Then
                    PrecioAutoriza = Format(DataSet.Tables("PrecioAutoriza").Rows(0)("Precio"), "##,##0.00")
                    PrecioAutoriza1 = Format(DataSet.Tables("PrecioAutoriza").Rows(0)("Precio"), "##,##0.00") / 46
                Else
                    '////////////////////////19-09-2019 SEGUN CONVERSADO CON MARIELOS SI NO HAY COMPLEMENTO DE PRECIOS PARA LA FECHA DEL RANGO ACTUAL

                    PrecioAutoriza = 0.0
                    PrecioAutoriza1 = 0.0


                    ''////////////////////////////BUSCO SI EXISTE PRECIO AUTORIZA PARA EL ULTIMA DIA UTILIZADO ///////////////
                    'SqlString = "SELECT  IdPrecioComplemento, IdCosecha, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion  FROM PrecioComplemento WHERE  (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & IdCategoria & ") AND (FechaActualizacion <= CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY Corte DESC, FechaActualizacion DESC"
                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    'DataAdapter.Fill(DataSet, "PrecioAutorizaAnt")
                    'If DataSet.Tables("PrecioAutorizaAnt").Rows.Count <> 0 Then
                    '    PrecioAutoriza = Format(DataSet.Tables("PrecioAutorizaAnt").Rows(0)("Precio"), "##,##0.00")
                    '    PrecioAutoriza1 = Format(DataSet.Tables("PrecioAutorizaAnt").Rows(0)("Precio"), "##,##0.00") / 46

                    'End If
                    'DataSet.Tables("PrecioAutorizaAnt").Reset()
                End If


                If DataSet.Tables("Precio").Rows.Count <> 0 Then
                    'Quien2 = "NoJustifica"
                    Precio = Format(DataSet.Tables("Precio").Rows(0)("Precio"), "##,##0.0000")
                    'Me.TxtPrecio.Text = Format(Precio, "##,##0.00")
                    Precio1 = Format(DataSet.Tables("Precio").Rows(0)("Precio") / 46, "####0.0000")
                    Me.TxtPrecioBrutoSinDeduc.Text = Precio1
                    'Me.TxtPrecioSG.Text = Me.TxtPrecio.Text
                Else
                    'Quien2 = "NoJustifica"
                    Precio = 0.0
                    'MsgBox("NO SE ENCONTRO PRECIOS", MsgBoxStyle.Critical, "Liquidacion")
                    'Me.TxtPrecio.Text = Format(Precio, "##,##0.00")
                    'Me.TxtPrecioBrutoAutoriza.Text = Format(Precio, "##,##0.00")
                    Precio1 = Format(0.0, "##,##0.0000")

                    'Me.TxtPrecioBrutoSinDeduc.Text = Precio1
                    'Me.TxtPrecioSG.Text = Me.TxtPrecio.Text
                End If
            End If

            DataSet.Tables("PrecioAutoriza").Reset()

            DataSet.Tables("Precio").Reset()
            '______________________________________________________________________________________________________
            'DEDUCCION DAÑO 
            '______________________________________________________________________________________________________


            IdCosecha = CodigoCosecha
            SqlString = "SELECT  IdDeduccionDano, ABS(Deduccion) AS Deduccion, EsPorcentaje, FechaInicio, FechaFin, IdDano, IdMoneda, IdUMedida, IdCosecha  FROM  DeduccionDano WHERE (IdDano = '" & IdDano & "') AND (IdMoneda ='609') AND (IdCosecha ='" & IdCosecha & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DeduccionDano")
            If DataSet.Tables("DeduccionDano").Rows.Count = 0 Then
                DeduccionDano = 0
            Else
                Fechainicial = DataSet.Tables("DeduccionDano").Rows(0)("FechaInicio")
                FechaFinal = DataSet.Tables("DeduccionDano").Rows(0)("FechaFin")
                Fechanow = Me.DTPFecha.Value.Now
                EsPorcentaje = DataSet.Tables("DeduccionDano").Rows(0)("EsPorcentaje")
                DD = DataSet.Tables("DeduccionDano").Rows(0)("Deduccion")
                If Fechanow >= Fechainicial And Fechanow <= FechaFinal Then
                    If EsPorcentaje = True Then
                        DeduccionDano = Precio1 * (1 - DD)
                        DataSet.Tables("DeduccionDano").Reset()
                    Else
                        DeduccionDano = DD / 46
                        DataSet.Tables("DeduccionDano").Reset()
                    End If
                Else
                    DeduccionDano = 0
                    DataSet.Tables("DeduccionDano").Reset()
                End If
            End If


            DeducEstado = 0
            '______________________________________________________________________________________________________
            'DEDUCCION ESTADO FISICO 
            '______________________________________________________________________________________________________
            SqlString = "SELECT IdDeduccionEstadoFisico, PorcentajeDeduccion, EstadoFisico, IdCosecha FROM   PorcentajeDeduccionEstadoFisico   WHERE  (EstadoFisico = '" & IdEdoFisico & "') AND (IdCosecha = '" & IdCosecha & "') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "DeduccionEdo")
            If DataSet.Tables("DeduccionEdo").Rows.Count <> 0 Then
                DeducEstado = DataSet.Tables("DeduccionEdo").Rows(0)("PorcentajeDeduccion")
            End If
            DataSet.Tables("DeduccionEdo").Reset()

            '/////////////////////////////////////SI PRECIO BASE DEL DIA ES CERO BUSCO EL PRECIO DEL PRIMER CORTE /////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If Precio1 = 0 Then
                SqlString = "SELECT  IdPrecioComplemento, IdCosecha, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion  FROM PrecioComplemento WHERE  (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & IdCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(Fecha, "yyyy-MM-dd HH:mm:ss") & "', 102)) AND (Corte = 1) ORDER BY Corte DESC, FechaActualizacion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "PrecioBase")

                If DataSet.Tables("PrecioBase").Rows.Count <> 0 Then
                    Precio = Format(DataSet.Tables("PrecioBase").Rows(0)("Precio"), "##,##0.0000")
                    Precio1 = Format(DataSet.Tables("PrecioBase").Rows(0)("Precio") / 46, "####0.0000")
                    Me.TxtPrecioBrutoSinDeduc.Text = Precio1
                End If
            End If



            DeduccionDano = Format(DeduccionDano, "####0.00")
            DeducEstado = Format(DeducEstado, "####0.00")
            PorcentajeImpApli = Format(PorcentajeImpApli, "####0.000")
            Precio1 = Format(Precio1, "####0.00")
            PrecioAutoriza1 = Format(PrecioAutoriza1, "####0.00")

            PrecioBruto = Format(((((Precio1 - DeduccionDano) * DeducEstado) / (1 - PorcentajeImpApli))), "####0.00")
            PrecioBrutoAutoriza = Format(((((PrecioAutoriza1 - DeduccionDano) * DeducEstado) / (1 - PorcentajeImpApli))), "####0.00")

            '///////////////////////////////////CAMBIO EL PRECIO BRUTO SIEMPRE POR EL PRECIO AUTORIZA ///////////////////////////////////
            'If PrecioBrutoAutoriza <> 0 Then
            '    PrecioBruto = PrecioBrutoAutoriza
            'End If

            If Precio1 <= 0 Then
                If PrecioAutoriza = 0 Then
                    PrecioBruto = 0
                Else
                    PrecioBruto = PrecioBrutoAutoriza
                End If
            End If



            '////////////////////////////////// LAS MARIELOS DICE 16/07/2019 QUE MUESTRE SIEMPRE EL PRECIO AUTORIZA EN LUGAR DEL PRECIO BRUTO /////
            '/////////////////QUE ES COMO ELLOS LO UTILIZAN Y NO QUIEREN CAMBIAR ESTO, EN REUNION ANTERIOR SE COMENTO QUE EL PRECIO AUTORIZA SOLO ERA MARCO DE REFERENCIA DEL LIMITE MAXIMO 
            '/////////////////PERO QUE SE QUEDA EL PRECIO BRUTO. ESTO SE VA CAMBIAR POR EL PRECIO AUTORIZA.

            i = i + 1
        Loop
        Quien2 = "NoJustifica"
        Me.TxtPrecioBrutoAutoriza.Text = PrecioBrutoAutoriza
        Me.TxtPrecio.Text = PrecioBruto
        Me.TxtPrecioSG.Text = Me.TxtPrecio.Text

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Quien = "Liquidacion"
        My.Forms.FrmConsultasLiqui.ShowDialog()
        Me.TxtNumeroEnsamble.Text = My.Forms.FrmConsultasLiqui.Codigo
        Me.TxtIdLiquidacion.Text = My.Forms.FrmConsultasLiqui.Codigo1
    End Sub
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        MiConexion.Close()
        Dim Count As Double, countfalso As Double, i As Integer, SqlLiqui As String, codigoingre As String, NumEnsamble As String
        Dim FechaLiqui As Date, StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, IdLiquida As String
        Dim sql2 As String, IdAplicacion As String, IdtipoPago As String, SqlIdRecib As String, Idrecibo As String, StrSqlInsert As String, PrecioAtc As Double
        Dim Monto As Double


        ValidaDistribuicion()


        Count = Me.TDBGRidDistribucion.RowCount
        i = 0
        Monto = 0
        Do While Count > i
            Monto = Monto + Me.TDBGRidDistribucion.Item(i)("Monto")
            i = i + 1
        Loop

        Me.LblMontoComp.Text = Monto



        If CDbl(Me.LblMontoComp.Text) <> CDbl(Me.TxtTotalDol.Text) Then
            MsgBox("Los Datos de la Distribucion No coinciden con el neto a pagar", MsgBoxStyle.Exclamation, "Liquidacion")
            Exit Sub
        End If
        If Me.CboCodigoProveedor.Text = "" Or Me.CboTipDano.Text = "" Or Me.CboLocalidadLiq.Text = "" Or Me.CboImperfeccion.Text = "" Then
            MsgBox("ALGUNOS CAMPOS ESTAN VACIOS POR FAVOR REVISE LA INFORMACION", MsgBoxStyle.Critical, "Liquidacion")
            Exit Sub
        End If

        If Me.IdTipoCambio = 0 Then
            MsgBox("SELECIONE UNA FECHA CON TASA DE CAMBIO", MsgBoxStyle.Critical, "Liquidacion")
            Exit Sub
        End If





        '/////////////////////////////NUMERO DE ENSAMBLE ////////////////////////
        FechaLiqui = Me.DTPFecha.Value
        If Me.TxtPrecio.Text = "" Then
            PrecioAtc = 0.0
        Else
            PrecioAtc = Me.TxtPrecio.Text
        End If

        NumEnsamble = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text

        If Me.TxtNumeroEnsamble.Text = "---0---" Then
            '
            '    
            Select Case IdTipoIngreso
                'Manual
                Case 295

                    If Me.EsReciboManual = False Then
                        '/////////////////////////SOLICITO EL NUMERO MANUAL //////////////////////////////////
                        FrmTecladoLiqui.ShowDialog()
                        Me.TxtNumeroEnsamble.Text = FrmTecladoLiqui.Numero
                        Me.TxtSerie.Text = FrmTecladoLiqui.Serie
                    End If

                    If IdTipoCompra = 108 Then
                        ' manual y directa 
                        NumEnsamble = Me.TxtNumeroEnsamble.Text
                    ElseIf IdTipoCompra = 109 Then
                        ' manual y deposito 
                        NumEnsamble = Me.TxtNumeroEnsamble.Text
                    End If
                    ' automatico 
                Case 1646
                    If IdTipoCompra = 108 Then
                        ' automatica y directa 
                        NumEnsamble = Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                    ElseIf IdTipoCompra = 109 Then
                        ' automatica y  deposito
                        ConsecutivoLiquidacion()
                        NumEnsamble = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                    End If
            End Select


        ElseIf Me.TxtNumeroEnsamble.Text = " " Then
            Select Case IdTipoIngreso
                'Manual
                Case 295

                    If Me.EsReciboManual = False Then
                        '/////////////////////////SOLICITO EL NUMERO MANUAL //////////////////////////////////
                        FrmTecladoLiqui.ShowDialog()
                        Me.TxtNumeroEnsamble.Text = FrmTecladoLiqui.Numero
                        Me.TxtSerie.Text = FrmTecladoLiqui.Serie
                    End If

                    If IdTipoCompra = 108 Then
                        ' manual y directa 
                        NumEnsamble = Me.TxtNumeroEnsamble.Text
                    ElseIf IdTipoCompra = 109 Then
                        ' manual y deposito 
                        NumEnsamble = Me.TxtNumeroEnsamble.Text
                    End If
                    ' automatico 
                Case 1646
                    If IdTipoCompra = 108 Then
                        ' automatica y directa 
                        NumEnsamble = Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                    ElseIf IdTipoCompra = 109 Then
                        ' automatica y  deposito
                        ConsecutivoLiquidacion()
                        NumEnsamble = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                    End If
            End Select


        ElseIf Me.TxtNumeroEnsamble.Text = "" Then
            Select Case IdTipoIngreso
                'Manual
                Case 295

                    If Me.EsReciboManual = False Then
                        '/////////////////////////SOLICITO EL NUMERO MANUAL //////////////////////////////////
                        FrmTecladoLiqui.ShowDialog()
                        Me.TxtNumeroEnsamble.Text = FrmTecladoLiqui.Numero
                        Me.TxtSerie.Text = FrmTecladoLiqui.Serie
                    End If

                    If IdTipoCompra = 108 Then
                        ' manual y directa 
                        NumEnsamble = Me.TxtNumeroEnsamble.Text
                    ElseIf IdTipoCompra = 109 Then
                        ' manual y deposito 
                        NumEnsamble = Me.TxtNumeroEnsamble.Text
                    End If
                    ' automatico 
                Case 1646
                    If IdTipoCompra = 108 Then
                        ' automatica y directa 
                        NumEnsamble = Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                    ElseIf IdTipoCompra = 109 Then
                        ' automatica y  deposito
                        ConsecutivoLiquidacion()
                        NumEnsamble = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                    End If
            End Select




        ElseIf Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            Select Case IdTipoIngreso
                'Manual
                Case 295

                    If Me.EsReciboManual = False Then
                        '/////////////////////////SOLICITO EL NUMERO MANUAL //////////////////////////////////
                        FrmTecladoLiqui.ShowDialog()
                        Me.TxtNumeroEnsamble.Text = FrmTecladoLiqui.Numero
                        Me.TxtSerie.Text = FrmTecladoLiqui.Serie
                    End If

                    If IdTipoCompra = 108 Then
                        ' manual y directa 
                        NumEnsamble = Me.TxtNumeroEnsamble.Text
                    ElseIf IdTipoCompra = 109 Then
                        ' manual y deposito 
                        NumEnsamble = Me.TxtNumeroEnsamble.Text
                    End If
                    ' automatico 
                Case 1646
                    If IdTipoCompra = 108 Then
                        ' automatica y directa 
                        NumEnsamble = Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                    ElseIf IdTipoCompra = 109 Then
                        ' automatica y  deposito
                        ConsecutivoLiquidacion()
                        NumEnsamble = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                    End If
            End Select

            'NumEnsamble = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text

        Else



        End If
        ' GUARDO EL ENCABEZADO DE LA LIQUIDACION .
        '__________________________________________________________________________________________________________________________________________________________
        GrabaLiquidacion(Idliquidacion, NumEnsamble, FechaLiqui, Me.TxtPrecio.Text)



        '/////////////////////////////BUSCO EL ID DE LA LIQUIDACION GRABADA ///////////////////////////////////////////
        sql = "SELECT  LiquidacionPergamino.*  FROM LiquidacionPergamino   " & _
              "WHERE (Codigo = '" & NumEnsamble & "') AND (Cod_Proveedor = '" & IdProductor & "') AND (IdLocalidad = '" & IdLocalidadLiqui & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(FechaLiqui), "yyyy-MM-dd HH:mm:ss") & "', 102))"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdLiquida = DataSet.Tables("Consulta").Rows(0)("IdLiquidacionPergamino")
            Idliquidacion = DataSet.Tables("Consulta").Rows(0)("IdLiquidacionPergamino")
        End If
        DataSet.Tables("Consulta").Reset()

        Count = Me.TDGridDetalleRecibos.RowCount
        countfalso = 0
        i = 0

        Do While Count > i
            If Me.TDGridDetalleRecibos.Item(i)("Aplicar") = True Then
                countfalso = countfalso + 1
                Idrecibo = Me.TDGridDetalleRecibos.Item(i)("IdReciboPergamino")

                'SqlLiqui = "SELECT  *, DetalleLiquidacionPergamino.IdReciboPergamino AS IdRecibo   FROM  LiquidacionPergamino INNER JOIN   DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino WHERE  (DetalleLiquidacionPergamino.IdReciboPergamino =  '" & Me.TDGridDetalleRecibos.Item(i)("IdReciboPergamino") & "') And (DetalleLiquidacionPergamino.IdLiquidacionPergamino =  '" & Idliquidacion & "') "
                SqlLiqui = "SELECT  IdDetalleLiquidacionPergamino, PesoNeto, IdLiquidacionPergamino, IdReciboPergamino FROM DetalleLiquidacionPergamino  WHERE  (IdLiquidacionPergamino = '" & Idliquidacion & "') AND (IdReciboPergamino = " & Idrecibo & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlLiqui, MiConexion)
                DataAdapter.Fill(DataSet, "Liquidaciones")

                If DataSet.Tables("Liquidaciones").Rows.Count <> 0 Then
                    '///////////SI EXISTE UNA LIQUIDACION LA ACTUALIZO////////////////
                    'IdLiquida = DataSet.Tables("Liquidaciones").Rows(i)("IdLiquidacionPergamino")


                    StrSqlInsert = "UPDATE [dbo].[DetalleLiquidacionPergamino] SET [PesoNeto] =  '" & Me.TDGridDetalleRecibos.Item(i)("PesoNeto") & "' WHERE (IdLiquidacionPergamino = '" & Idliquidacion & "')AND (IdReciboPergamino= '" & Idrecibo & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery

                    'StrSqlInsert = "INSERT INTO [dbo].[DetalleLiquidacionPergamino]([PesoNeto],[IdLiquidacionPergamino],[IdReciboPergamino]) VALUES('" & Me.TDGridDetalleRecibos.Item(i)("PesoNeto") & "','" & IdLiquida & "','" & Idrecibo & "' )"
                    'ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                    'iResultado = ComandoUpdate.ExecuteNonQuery
                    ' Aualizo el nuevo o los nuevos recibos 
                    '__________________________________________________________________________________________________________________________________________________________

                    'If Me.TDGridDetalleRecibos.Item(i)("PesoNeto") = Me.TDGridDetalleRecibos.Item(i)("PesoNTCompara") Then
                    '    StrSqlInsert = "UPDATE [dbo].[ReciboCafePergamino]  SET [Liquidado] = '1',[Seleccion] = '" & Me.TDGridDetalleRecibos.Item(i)("Aplicar") & "'  WHERE ( IdReciboPergamino = '" & Idrecibo & "')"
                    '    ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                    '    iResultado = ComandoUpdate.ExecuteNonQuery
                    '    MiConexion.Close()
                    'Else
                    '    MiConexion.Close()
                    'End If
                    MiConexion.Close()
                    ' AQUI MANDARE A BUSCAR LOS ID DE APLICACION Y TIPO PAGO 
                    '__________________________________________________________________________________________________________________________________________________________

                Else
                    '///////////////////// VALIDO SI NO EXISTE ENTONCES LO GUARDO COMO NUEVO /////////////////////
                    'IdLiquida = Me.TDGridDetalleRecibos.Item(i)("IdLiquidacionPergamino")
                    'Idrecibo = Me.TDGridDetalleRecibos.Item(i)("IdReciboPergamino")

                    'SqlLiqui = "SELECT  IdLiquidacionPergamino, Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso, IdTipoIngreso,  IdCosecha, IdLocalidad, Cod_Proveedor, IdTipoCompra FROM    LiquidacionPergamino ORDER BY IdLiquidacionPergamino DESC "
                    'DataAdapter = New SqlClient.SqlDataAdapter(SqlLiqui, MiConexion)
                    'DataAdapter.Fill(DataSet, "IdLiqui")
                    'IdLiquida = DataSet.Tables("IdLiqui").Rows(0)("IdLiquidacionPergamino")
                    'DataSet.Tables("IdLiqui").Reset()
                    'Guardo en detalle de la liquidacion
                    '__________________________________________________________________________________________________________________________________________________________

                    StrSqlInsert = "INSERT INTO [dbo].[DetalleLiquidacionPergamino]([PesoNeto],[IdLiquidacionPergamino],[IdReciboPergamino]) VALUES('" & Me.TDGridDetalleRecibos.Item(i)("PesoNeto") & "','" & IdLiquida & "','" & Idrecibo & "' )"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery

                    'actualizo los recibos como ya liquidados.
                    '__________________________________________________________________________________________________________________________________________________________
                    ', [Seleccion] = '" & Me.TDGridDetalleRecibos.Item(i)("Aplicar") & "'
                    If Me.IdTipoCompra = 108 Then
                        StrSqlInsert = "UPDATE [dbo].[ReciboCafePergamino]  SET [Liquidado] = '1'   WHERE ( IdReciboPergamino = '" & Idrecibo & "')"
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    Else
                        MiConexion.Close()
                    End If
                    'MiConexion.Close()
                End If

                DataSet.Tables("Liquidaciones").Reset()
            Else
            End If
            i = i + 1
        Loop

        ' AQUI MANDARE A GUARDAR LOS REGISTROS DE LA DISTRIBUCION 
        '______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        Count = Me.TDBGRidDistribucion.RowCount
        i = 0
        Do While Count > i
            ' AQUI MANDARE A CONSULTAR SI EXISTEN REGISTROS PREVIOS
            '____________________________________________________________________
            sql = " SELECT  IdDetalleDistribucion, IdLiquidacionPergamino, IdAplicacionLiquidacionPergamino, IdTipoPago, FechaPago, Monto, NumeroAvio   FROM   DetalleDistribucion  WHERE  (IdLiquidacionPergamino = '" & Idliquidacion & "')AND (IdDetalleDistribucion = '" & Me.TDBGRidDistribucion.Item(i)("IdDetalleDistribucion") & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "Distribucion")
            If DataSet.Tables("Distribucion").Rows.Count <> 0 Then

                sql = " SELECT     IdAplicacionLiquidacionPergamino  FROM   AplicacionLiquidacionPergamino   WHERE (Descripcion = '" & Me.TDBGRidDistribucion.Item(i)("Concepto") & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "AplicaLiquida")
                If Not IsDBNull(DataSet.Tables("AplicaLiquida").Rows(0)("IdAplicacionLiquidacionPergamino")) Then
                    IdAplicacion = DataSet.Tables("AplicaLiquida").Rows(0)("IdAplicacionLiquidacionPergamino")
                End If
                DataSet.Tables("AplicaLiquida").Reset()

                SqlString = "SELECT  IdTipoPago FROM   TipoPago   WHERE (Descripcion = '" & Me.TDBGRidDistribucion.Item(i)("TipoPago") & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "PagoLiquida")
                If Not IsDBNull(DataSet.Tables("PagoLiquida").Rows(0)("IdTipoPago")) Then
                    IdtipoPago = DataSet.Tables("PagoLiquida").Rows(0)("IdTipoPago")
                End If
                DataSet.Tables("PagoLiquida").Reset()

                ' Actualizar el detalledistribucion 
                '__________________________________________________________________________________________________________________________________________________________

                sql2 = "UPDATE [dbo].[DetalleDistribucion]  SET [IdAplicacionLiquidacionPergamino] ='" & IdAplicacion & "'   ,[IdTipoPago] =   '" & IdtipoPago & "'    ,[FechaPago] =  CONVERT(DATETIME, '" & Format(CDate(Me.TDBGRidDistribucion.Item(i)("FechaPago")), "yyyy-MM-dd hh:mm.ss") & "', 102)   ,[Monto] =   '" & Me.TDBGRidDistribucion.Item(i)("Monto") & "', [NumeroAvio] =   '" & Me.TDBGRidDistribucion.Item(i)("NumeroSolicitud") & "'  WHERE  (IdLiquidacionPergamino =  '" & Idliquidacion & "' )AND (IdDetalleDistribucion = '" & Me.TDBGRidDistribucion.Item(i)("IdDetalleDistribucion") & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(sql2, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
                DataSet.Tables("Distribucion").Reset()
            Else
                If Not Me.TxtIdLiquidacion.Text = "" Then
                    IdLiquida = Me.TxtIdLiquidacion.Text
                End If

                sql = " SELECT     IdAplicacionLiquidacionPergamino  FROM   AplicacionLiquidacionPergamino   WHERE (Descripcion = '" & Me.TDBGRidDistribucion.Item(i)("Concepto") & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "AplicaLiquida")
                If Not IsDBNull(DataSet.Tables("AplicaLiquida").Rows(0)("IdAplicacionLiquidacionPergamino")) Then
                    IdAplicacion = DataSet.Tables("AplicaLiquida").Rows(0)("IdAplicacionLiquidacionPergamino")
                End If
                DataSet.Tables("AplicaLiquida").Reset()

                SqlString = "SELECT  IdTipoPago FROM   TipoPago   WHERE (Descripcion = '" & Me.TDBGRidDistribucion.Item(i)("TipoPago") & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "PagoLiquida")
                If Not IsDBNull(DataSet.Tables("PagoLiquida").Rows(0)("IdTipoPago")) Then
                    IdtipoPago = DataSet.Tables("PagoLiquida").Rows(0)("IdTipoPago")
                End If
                DataSet.Tables("PagoLiquida").Reset()
                ' Guardo en la tabla detalle de distribucion 
                '__________________________________________________________________________________________________________________________________________________________

                StrSqlInsert = "INSERT INTO [dbo].[DetalleDistribucion]([IdLiquidacionPergamino],[IdAplicacionLiquidacionPergamino],[IdTipoPago],[FechaPago],[Monto],[NumeroAvio])" & _
                                      " VALUES('" & IdLiquida & "','" & IdAplicacion & "','" & IdtipoPago & "', CONVERT(DATETIME, '" & Format(Me.DTPFecha.Value, "yyyy-MM-dd HH:mm:ss") & "', 102) , '" & Me.TDBGRidDistribucion.Item(i)("Monto") & "', '" & Me.TDBGRidDistribucion.Item(i)("NumeroSolicitud") & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
            i = i + 1
        Loop
        '_________________________________________________________________________________________________________________________________________________

        If countfalso = 0 Then
            MsgBox("Seleccione al menos un Recibo", MsgBoxStyle.Critical, "Liquidacion")
            Exit Sub
        Else
            If CDbl(Me.TxtPrecio.Text) <> CDbl(Me.TxtPrecioSG.Text) Then
                StrSqlInsert = "INSERT INTO [dbo].[JustificacionLiquidacionPergamino]([Justificacion],[FechaAutorizacion],[PrecioAnterior],[IdAutorizador],[IdLiquidacionPergamino]) VALUES   ('" & Me.TxtjustSave.Text & "',  '" & Format(Me.DtpFechaJustif.Value.Now, "dd/MM/yyyy") & "','" & Format(CDbl(Me.TxtPrecioSG.Text), "####0.00") & "','" & IdUsuario & "','" & IdLiquida & "' )"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
                'MsgBox("OPERACION CON EXITO SE ACTUALIZARON: '" & countfalso & "' ", MsgBoxStyle.Exclamation, "Liquidacion")
            End If
        End If
        If Quien = "Recibo" Then

            If Salir = True Then
                Quien = ""
            End If

            My.Forms.FrmRecepcion.SalirLiquidacion(Salir)
            Exit Sub
        Else
            Button3_Click(sender, e)
        End If

    End Sub

    Private Sub TxtIdLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIdLocalidad.TextChanged
        'SqlString = "SELECT  RIGHT(Codigo, 6) AS  Codigo  FROM   LiquidacionPergamino   WHERE (IdCosecha = '" & IdCosecha & "')AND  (IdLocalidad = '" & IdLocalidadLiqui & "')  ORDER BY Codigo DESC"
        ''DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        ''DataAdapter.Fill(DataSet, "ConseAutomatico")
        ''If DataSet.Tables("ConseAutomatico").Rows.Count = 0 Then
        ''    Me.TxtNumeroEnsamble.Enabled = False
        ''    Me.TxtNumeroEnsamble.Text = "000001"
        ''Else
        ''    Me.TxtNumeroEnsamble.Enabled = False
        ''    Me.TxtNumeroEnsamble.Text = Format(DataSet.Tables("ConseAutomatico").Rows(0)("Codigo") + 1, "00000#")
        ''End If
    End Sub
    Private Sub CboPrecios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim filas As Integer, i As Integer
        sql = "SELECT  IdTipoCompra, Codigo, Nombre FROM TipoCompra WHERE (Nombre= '" & Me.CboTipoCompra.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCompra2")

        If DataSet.Tables("TipoCompra2").Rows.Count = 0 Then
            MsgBox("NO EXISTE NINGUN TIPO COMPRA", MsgBoxStyle.Exclamation, "Liquidacion")
        Else
            If DataSet.Tables("TipoCompra2").Rows(0)("IdTipoCompra") = 4 Then
                filas = Me.TDGridDetalleRecibos.RowCount
                i = 0
                Do While filas > i
                    Me.TDGridDetalleRecibos.Item(i)("Precio") = Me.TxtPrecio.Text
                    i = i + 1
                Loop
            End If
            DataSet.Tables("TipoCompra2").Reset()
        End If
    End Sub

    Private Sub CboMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMoneda.SelectedIndexChanged
        sql = "SELECT  IdMoneda, Nombre, Simbolo  FROM Moneda WHERE (Simbolo = '" & Me.CboMoneda.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Moneda1")
        If DataSet.Tables("Moneda1").Rows.Count = 0 Then
            IdMoneda = 0
        Else
            IdMoneda = DataSet.Tables("Moneda1").Rows(0)("IdMoneda")
        End If
    End Sub
    Private Sub CboEstadoDocumeto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEstadoDocumeto.SelectedIndexChanged
        sql = "SELECT IdEstadoDocumento, Codigo, Descripcion  FROM EstadoDocumento WHERE (Descripcion = '" & Me.CboEstadoDocumeto.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "EstadoDocumento1")


        If DataSet.Tables("EstadoDocumento1").Rows.Count = 0 Then
            IdEstaDocumento = 0
        Else
            IdEstaDocumento = DataSet.Tables("EstadoDocumento1").Rows(0)("IdEstadoDocumento")
        End If

        If IdEstaDocumento = 292 Then
            DataSet.Tables("EstadoDocumento1").Reset()
            Exit Sub
        End If

        If IdEstaDocumento = 294 And CDbl(Me.LblMontoComp.Text) <> 0 And CDbl(Me.TxtTotalDol.Text) <> 0.0 Then

            Me.Button6.Enabled = True

            If CDbl(Me.LblMontoComp.Text) <> CDbl(Me.TxtTotalDol.Text) Then

                DataSet.Tables("EstadoDocumento1").Reset()
                sql = "SELECT  Descripcion  FROM EstadoDocumento WHERE (IdEstadoDocumento = '293') "
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "EstadoDocument")
                Me.CboEstadoDocumeto.Text = DataSet.Tables("EstadoDocument").Rows(0)("Descripcion")
                DataSet.Tables("EstadoDocumento1").Reset()
            Else
                If ImprimirConfirmado = True Then
                    DataSet.Tables("EstadoDocumento1").Reset()
                    Me.Button6.Enabled = True
                    BtnGuardar_Click(sender, e)
                    Me.TxtIdLiquidacion.Text = Idliquidacion
                    Button6_Click(sender, e)
                End If
            End If

        Else
            Me.Button6.Enabled = False
            DataSet.Tables("EstadoDocumento1").Reset()
            sql = "SELECT  Descripcion  FROM EstadoDocumento WHERE (IdEstadoDocumento = '293') "
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "EstadoDocument")
            Me.CboEstadoDocumeto.Text = DataSet.Tables("EstadoDocument").Rows(0)("Descripcion")
            DataSet.Tables("EstadoDocumento1").Reset()
        End If

        DataSet.Tables("EstadoDocumento1").Reset()

    End Sub
    Private Sub CboTipoCompra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoCompra.SelectedIndexChanged
        sql = "SELECT  IdTipoCompra, Codigo, Nombre, IdECS   FROM  TipoCompra WHERE (Nombre = '" & Me.CboTipoCompra.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCompra1")
        If DataSet.Tables("TipoCompra1").Rows.Count = 0 Then
            IdTipoCompra = 0
        Else
            IdTipoCompra = DataSet.Tables("TipoCompra1").Rows(0)("IdECS")
        End If
        DataSet.Tables("TipoCompra1").Reset()

        limpiaGrid()

        '///////////////////////////////////////////////////////////////////////////////
        Select Case IdTipoCompra
            'Directa 
            'Case 108
            '    If IdTipoIngreso = 1646 Then
            '        ' Automatica y  Directa
            '    ElseIf IdTipoIngreso = 295 Then
            '        ' Manual y  Directa
            '    End If
            '    'Automatico 
            Case 109
                If IdTipoIngreso = 1646 Then
                    ' Automatica y  Deposito
                    QuienTec = "Liquida Automatico Deposito"
                    sql = "SELECT  IdLiquidacionPergamino, RIGHT(Codigo, 6) AS Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso,     IdTipoIngreso, IdCosecha, IdLocalidad, IdTipoCompra    FROM   LiquidacionPergamino    WHERE  (IdTipoCompra = 109) AND (IdCosecha = '" & IdCosecha & "') AND (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdTipoIngreso = 1646)  ORDER BY Codigo DESC"
                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(DataSet, "LiquidaCodigo")
                    If DataSet.Tables("LiquidaCodigo").Rows.Count = 0 Then
                        Me.TxtNumeroEnsamble.Text = "000001"
                    Else
                        Me.TxtNumeroEnsamble.Text = Format(DataSet.Tables("LiquidaCodigo").Rows(0)("Codigo") + 1, "00000#")
                    End If
                ElseIf IdTipoIngreso = 295 Then
                    ' Manual y  Deposito
                    QuienTec = "Liquida Manual Deposito"
                    If Quien3 = "Ver" Then
                        Quien3 = ""
                        Exit Sub
                    End If
                    FrmTecladoLiqui.ShowDialog()
                    Me.TxtNumeroEnsamble.Text = FrmTecladoLiqui.Numero
                End If
        End Select
        CalculaPrecioBruto()
    End Sub
    Private Sub CboTipDano_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipDano.SelectedIndexChanged
        limpiaGrid()

        sql = "SELECT  IdDano, Codigo, Nombre, Activo  FROM   Dano   WHERE  (Nombre = '" & Me.CboTipDano.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "TipoDano")
        If DataSet.Tables("TipoDano").Rows.Count = 0 Then
            IdDano = 0
        Else
            IdDano = DataSet.Tables("TipoDano").Rows(0)("IdDano")
        End If
        CalculaPrecioBruto()
        DataSet.Tables("TipoDano").Reset()
    End Sub
    Private Sub CboImperfeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboImperfeccion.SelectedIndexChanged
        limpiaGrid()

        sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion   FROM   RangoImperfeccion   WHERE (Nombre = '" & Me.CboImperfeccion.Text & "') AND (IdCosecha = " & IdCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "IdImperfeccion")
        If DataSet.Tables("IdImperfeccion").Rows.Count = 0 Then
            IdCategoria = 0
        Else
            IdCategoria = Nothing
            IdCategoria = DataSet.Tables("IdImperfeccion").Rows(0)("IdRangoImperfeccion")
        End If
        CalculaPrecioBruto()

        DataSet.Tables("IdImperfeccion").Reset()
    End Sub
    Private Sub CboDocIngreso_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipIngreso.SelectedIndexChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String
        Dim i As Integer, count1 As Integer, count2 As Integer
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()


        'Me.TxtNumeroEnsamble.Text = "---0---"
        SqlString = "SELECT  IdTipoIngreso, Descripcion, Code, IdECS  FROM   TipoIngreso    WHERE  (Descripcion = '" & Me.CboTipIngreso.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "IdIngreso")
        IdTipoIngreso = DataSet.Tables("IdIngreso").Rows(0)("IdECS")

        DataSet.Tables("IdIngreso").Reset()

        limpiaGrid()

        If Quien = "Recibo" Then
            Exit Sub
        End If

        If IdTipoIngreso = 295 Then
            'Manual
            Me.DTPFecha.Enabled = True
            Me.TxtSerie.Text = "?"
        ElseIf IdTipoIngreso = 1646 Then
            'Automatico
            Me.DTPFecha.Enabled = False
            Me.TxtSerie.Text = "D" & Cod_Cosecha
        End If

        Select Case IdTipoIngreso
            'Manual
            Case 295
                If IdTipoCompra = 108 Then
                    ' manual y directa 
                ElseIf IdTipoCompra = 109 Then
                    ' manual y deposito 
                    If Quien3 = "Ver" Then
                        Quien3 = ""
                        Exit Sub
                    End If
                    QuienTec = "Liquida Manual Deposito"
                    Me.TxtSerie.Text = "?"
                    'FrmTecladoLiqui.ShowDialog()
                    'Me.TxtNumeroEnsamble.Text = FrmTecladoLiqui.Numero
                    'Me.TxtSerie.Text = FrmTecladoLiqui.Serie
                End If
                ' automatico 
            Case 1646
                If IdTipoCompra = 108 Then
                    ' automatica y directa 
                ElseIf IdTipoCompra = 109 Then
                    ' automatica y  deposito

                    Me.TxtSerie.Text = "D" & Cod_Cosecha
                    'QuienTec = "Liquida Automatico Deposito"
                    'sql = "SELECT  IdLiquidacionPergamino, RIGHT(Codigo, 6) AS Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso,     IdTipoIngreso, IdCosecha, IdLocalidad, IdTipoCompra    FROM   LiquidacionPergamino    WHERE  (IdTipoCompra = 109) AND (IdCosecha = '" & IdCosecha & "') AND (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdTipoIngreso = 1646)  ORDER BY Codigo DESC"
                    'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    'DataAdapter.Fill(DataSet, "LiquidaCodigo")
                    'If DataSet.Tables("LiquidaCodigo").Rows.Count = 0 Then
                    '    Me.TxtNumeroEnsamble.Text = "000001"
                    'Else
                    '    Me.TxtNumeroEnsamble.Text = Format(DataSet.Tables("LiquidaCodigo").Rows(0)("Codigo") + 1, "00000#")
                    'End If
                End If
        End Select

        CalculaPrecioBruto()
    End Sub
    Public Sub ConsecutivoLiquidacion()
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        QuienTec = "Liquida Automatico Deposito"
        sql = "SELECT  IdLiquidacionPergamino, RIGHT(Codigo, 6) AS Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso,     IdTipoIngreso, IdCosecha, IdLocalidad, IdTipoCompra    FROM   LiquidacionPergamino    WHERE  (IdTipoCompra = 109) AND (IdCosecha = '" & IdCosecha & "') AND (IdLocalidad = '" & IdLocalidadLiqui & "') AND (IdTipoIngreso = 1646)  ORDER BY Codigo DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "LiquidaCodigo")
        If DataSet.Tables("LiquidaCodigo").Rows.Count = 0 Then
            Me.TxtNumeroEnsamble.Text = "000001"
        Else
            Me.TxtNumeroEnsamble.Text = Format(DataSet.Tables("LiquidaCodigo").Rows(0)("Codigo") + 1, "00000#")
        End If
    End Sub



    Private Sub TDGridDetalleRecibos_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TDGridDetalleRecibos.BeforeColEdit
        Dim elecion As Boolean, posi As Integer
        posi = Me.TDGridDetalleRecibos.Row

        If Me.TDGridDetalleRecibos.RowCount <> 0 Then
            elecion = Me.TDGridDetalleRecibos.Item(posi)("Aplicar")
        End If


        If e.ColIndex = 2 Then
            If elecion = False Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub TDGridDetalleRecibos_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TDGridDetalleRecibos.BeforeColUpdate
        Dim PesoBruto As Double
        Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double, ResultadoC As Double, ResultadoD As Double, TipoImpuesto As String
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, ContarSelec As Double, estado As Boolean, codigo As String, ContaTrue As Double
        Dim PorImperfeccion As Double, Sacos As Double, PesoBruto2 As Double, Tara As Double
        i = 0
        PesoBruto = 0
        valorCor = 0
        ValorDol = 0
        Registros = Me.BinDetalleRecLiq.Count

        Do While Registros > i
            If Me.BinDetalleRecLiq.Item(i)("Aplicar") = True Then
                '____________________________________________
                'CONTADOR PARA VER CUANTOS VERDADEROS SON 
                '____________________________________________
                ContaTrue = ContaTrue + 1


                PesoBruto = Me.BinDetalleRecLiq.Item(i)("PesoNeto") + PesoBruto
                valorCor = Me.BinDetalleRecLiq.Item(i)("ValorBrutoC$") + valorCor
                ValorDol = Me.BinDetalleRecLiq.Item(i)("ValorBruto$") + ValorDol

                'PorImperfeccion = Me.BinDetalleRecLiq.Item(i)("Imperfeccion") + PorImperfeccion
                'Sacos = Me.BinDetalleRecLiq.Item(i)("CantidadSacos") + Sacos
                'PesoBruto2 = Me.BinDetalleRecLiq.Item(i)("PesoBruto") + PesoBruto2
                'Tara = Me.BinDetalleRecLiq.Item(i)("Tara") + Tara

                'codigo = Me.BinDetalleRecLiq.Item(i)("NºRecibo")
                'sql = "SELECT  Discrecional    FROM ReciboCafePergamino   WHERE   (Codigo = '" & codigo & "')"
                'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                'DataAdapter.Fill(DataSet, "Reciboselec")
                'estado = DataSet.Tables("Reciboselec").Rows(0)("Discrecional")
                'If estado = True And UsuarioType = "AutorizaPrecioDiscrecionalidad" Or UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then
                '    Me.Button7.Enabled = True
                'Else
                '    Me.Button7.Enabled = False
                'End If
                i = i + 1
                'DataSet.Tables("Reciboselec").Reset()
            Else
                i = i + 1
            End If
        Loop


        'End If
        Me.LblTotalPesoKG.Text = "= " + Format(PesoBruto, "##,##0.00")
        Me.LblValorC.Text = "= " + Format(valorCor, "##,##0.00")
        Me.TxtValorBrutoCor.Text = "= " + Format(ValorDol, "##,##0.00")

        'Me.TxtPorcentajeImperfec.Text = Format(PorImperfeccion, "####0.00")
        'Me.TxtSacos.Text = Format(Sacos, "####0.00")
        'Me.TextPesoBruto.Text = Format(PesoBruto2, "####0.00")
        'Me.TxtTAra.Text = Format(tara, "####0.00")


        totalCor = Mid(Me.LblValorC.Text, 3, Len(Me.LblValorC.Text))
        totalDol = Mid(Me.TxtValorBrutoCor.Text, 3, Len(Me.TxtValorBrutoCor.Text))

        If Me.Checkpor1.Checked = True Then
            TipoImpuesto = "Imp. Municipal"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto1")

            Porcentaje = DataSet.Tables("Impuesto1").Rows(0)("Valor")
            ImpMuniC = Porcentaje * totalCor
            ImpMuniD = Porcentaje * totalDol
        Else
            ImpMuniC = 0
            ImpMuniD = 0
        End If

        Porcentaje = 0

        If Me.Checkpor2.Checked = True Then

            TipoImpuesto = "Retención Definitiva"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto2")

            Porcentaje = DataSet.Tables("Impuesto2").Rows(0)("Valor")
            RetDefC = Porcentaje * totalCor
            RetDefD = Porcentaje * totalDol

            Me.TxtRentDefC.Text = Format(RetDefC, "##,##0.00")
            Me.TxtRentDefD.Text = Format(RetDefD, "##,##0.00")
        Else
            RetDefC = 0
            RetDefD = 0
            Me.TxtRentDefC.Text = "0.00"
            Me.TxtRentDefD.Text = "0.00"
        End If

        Porcentaje = 0

        If Me.Checkbox4.Checked = True Then
            TipoImpuesto = "Retención 2%"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto4")

            Porcentaje = DataSet.Tables("Impuesto4").Rows(0)("Valor")
            Reten2C = Porcentaje * totalCor
            Reten2D = Porcentaje * totalDol
        Else
            Reten2C = 0
            Reten2D = 0
        End If

        If Me.Checkpor3.Checked = True Then
            TipoImpuesto = "Retención 3%"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto3")

            Porcentaje = DataSet.Tables("Impuesto3").Rows(0)("Valor")
            Ret3C = Porcentaje * totalCor
            Ret3D = Porcentaje * totalDol
        Else
            Ret3C = 0
            Ret3D = 0
        End If

        'aqui va el otro

        TotalDecC = ImpMuniC + RetDefC + Ret3C + Reten2C
        TotalDecD = ImpMuniD + RetDefD + Ret3D + Reten2D

        Me.TxtTotalDecC.Text = Format(TotalDecC, "##,##0.00")
        Me.TxtTotalDecD.Text = Format(TotalDecD, "##,##0.00")

        NetoPagarC = totalCor - TotalDecC
        NetoPagarD = totalDol - TotalDecD

        Me.TxtTotalCor.Text = Format(NetoPagarC, "##,##0.00")
        Me.TxtTotalDol.Text = Format(NetoPagarD, "##,##0.00")


        If Me.TDGridDetalleRecibos.Col = 3 Then
            Dim filas As Integer
            sql = "SELECT  IdTipoCompra, Codigo, Nombre FROM TipoCompra WHERE (Nombre= '" & Me.CboTipoCompra.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "TipoCompra2")

            If DataSet.Tables("TipoCompra2").Rows.Count = 0 Then
                MsgBox("NO EXISTE NINGUN TIPO COMPRA", MsgBoxStyle.Exclamation, "Liquidacion")
            Else
                If DataSet.Tables("TipoCompra2").Rows(0)("IdTipoCompra") = 4 Then
                    filas = Me.TDGridDetalleRecibos.RowCount
                    i = 0
                    Do While filas > i
                        Me.TDGridDetalleRecibos.Item(i)("Precio") = Me.TxtPrecio.Text
                        i = i + 1
                    Loop
                End If
            End If
        End If
    End Sub

    Private Sub TDBGRidDistribucion_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDBGRidDistribucion.AfterColEdit
        Dim DataSet5 As New DataSet, SqlString As String, NumeroRecibo As String
        Dim PesoBruto As Double
        Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, ContarGrid As Double, TotalMonto As Double, ResultadoD As Double, TipoImpuesto As String
        Dim ContarSelec As Double, estado As Boolean, codigo As String, ContaTrue As Double
        Dim IdTipCompra As Integer, Ingreso As Integer, eleccion As Boolean, CodLocalidad As String, codigoRecibo As String, CadenaDiv() As String, Cadena As String
        Dim PorImperfeccion As Double, Sacos As Double, PesoBruto2 As Double, Tara As Double, NewValorBrtCor As Double, Monto As Double, Posicion As Integer
        Dim PesoNeto As Double, PrecioNetoCor As Double, PrecioNetoDol As Double, PesoCompara As Double, addrow As String

        'If addrow <> "NoRow" Then
        '    addrow = ""
        '    If Me.TDBGRidDistribucion.Col = 0 Then
        '        'Posicion = Me.BinDistribucion.Position
        '        sql = " SELECT     IdAplicacionLiquidacionPergamino, Code, Descripcion, Activo   FROM   AplicacionLiquidacionPergamino   WHERE (Activo = 1) AND   (Descripcion = '" & Me.TDBGRidDistribucion.Columns(0).Text & "')"
        '        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        '        DataAdapter.Fill(DataSet5, "AplicaLiquidacion")
        '        If DataSet5.Tables("AplicaLiquidacion").Rows.Count <> 0 Then
        '            IdConcepto = DataSet5.Tables("AplicaLiquidacion").Rows(0)("IdAplicacionLiquidacionPergamino")
        '        End If

        '        If IdConcepto = 724 Then
        '            Posicion = Me.TDBGRidDistribucion.Row
        '            Me.TDBGRidDistribucion.Item(Posicion, "Monto") = CDbl(Me.TxtTotalDol.Text) - CDbl(Me.LblMontoComp.Text)

        '            Me.TDBGRidDistribucion.AllowAddNew = False
        '            'Me.TDBGRidDistribucion.Item(Posicion, "FechaPago") = Me.DTPFecha.Text
        '        ElseIf IdConcepto = 725 Then
        '            Posicion = Me.TDBGRidDistribucion.Row
        '            Me.TDBGRidDistribucion.Item(Posicion, "Monto") = 0.0
        '            addrow = "NoRow"
        '            'Me.TDBGRidDistribucion.Item(Posicion, "FechaPago") = Me.DTPFecha.Text
        '            Me.TDBGRidDistribucion.AllowAddNew = True
        '        End If
        '    End If
        'End If

        'Posicion = Me.BinDistribucion.Position
        'If Posicion >= 0 Then
        '    Monto = Me.BinDistribucion.Item(Posicion)("Monto")
        '    PrecioNetoDol = Me.TxtTotalDol.Text
        'End If
        'If Monto > PrecioNetoDol Then
        '    Me.BinDistribucion.Item(Posicion)("Monto") = 0.0
        'End If
        ContarGrid = 0
        i = 0
        ContarGrid = Me.TDBGRidDistribucion.RowCount
        Do While ContarGrid > i
            'Me.TDBGRidDistribucion.Row = i
            If IsDBNull(Me.TDBGRidDistribucion.Item(i)("Monto")) Then
                i = i + 1
            Else
                Monto = CDbl(Me.TDBGRidDistribucion.Item(i)("Monto")) + Monto
                Monto = Format(Monto, "####0.00")
                i = i + 1
            End If
        Loop
        If Monto > CDbl(Me.TxtTotalDol.Text) Then
            MsgBox("El total de distribucion es mayor a lo digitado", MsgBoxStyle.Critical, "Liquidacion")
            Me.TDBGRidDistribucion.Columns("Monto").Text = 0.0
        End If

        sumagriddistribucion()


    End Sub
    Public Sub sumagriddistribucion()
        Dim Registros As Double, TotalMonto As Double, i As Integer
        Registros = Me.TDBGRidDistribucion.RowCount
        i = 0
        Do While Registros > i
            'VALIDAMOS EL NUMERO DE LIQUIDACION DE RECIBOS DIRECTOS AUTOMATICOS  
            '__________________________________________________________________
            If IsDBNull(Me.TDBGRidDistribucion.Item(i)("Monto")) = True Then
                Me.TDBGRidDistribucion.Item(i)("Monto") = 0.0
            End If
            TotalMonto = Me.TDBGRidDistribucion.Item(i)("Monto") + TotalMonto
            i = i + 1
        Loop
        Me.LblTotalMonto.Text = "= " & TotalMonto
        Me.LblMontoComp.Text = TotalMonto
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim count1 As String, Ruta As String, LeeArchivo As String
        Quien2 = "NoJustifica"
        Me.Button10.Enabled = True
        Me.DTPFecha.Enabled = True
        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If
        LeeArchivo = Mid(LeeArchivo, 1, 3)
        SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & LeeArchivo & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad")
        If DataSet.Tables("Localidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
            Me.CboLocalidadLiq.Text = Me.LblSucursal.Text
        End If

        Me.CboCodigoProveedor.Text = ""
        'Me.TxtNumeroEnsamble.Text = "---0---"
        Me.txtnombre.Text = ""
        Me.TxtCedula.Text = ""
        Me.DTPFecha.Value = Now
        Me.CboEstadoDocumeto.Text = "Editable"
        Me.CboMunicipio.Text = ""
        Me.CboCalidad.Text = ""
        Me.CboImperfeccion.Text = ""
        Me.CboEdofisico.Text = ""
        Me.CboImperfeccion.Text = ""
        Me.TxtPrecio.Text = "0.0"
        Me.LblTotalMonto.Text = "=0.00"
        Me.LblTotalPesoKG.Text = "=0.00"
        Me.LblTotalSaldo.Text = "=0.00"
        Me.LblValorC.Text = "=0.00"
        Me.TxtValorBrutoCor.Text = "=0.00"
        Me.TxtRentDefC.Text = "0.00"
        Me.TxtRentDefD.Text = "0.00"
        Me.TxtTotalDecC.Text = "0.00"
        Me.TxtTotalDecD.Text = "0.00"
        Me.TxtTotalDol.Text = "0.00"
        Me.TxtTotalCor.Text = "0.00"
        Me.TxtPorcentajeImperfec.Text = "0.00"
        Me.TxtSacos.Text = "0.00"
        Me.TextPesoBruto.Text = "0.00"
        Me.TxtTAra.Text = "0.00"
        Me.TxtPrecioSG.Text = "0.00"
        Me.TxtjustSave.Text = ""
        Me.TxtUbicaFinca.Text = ""
        Me.CboCalidad.Text = ""
        Me.CboEdofisico.Text = ""
        Me.CboTipDano.Text = ""
        Me.CboImperfeccion.Text = ""
        Me.TxtReembolso.Text = ""
        Me.TxtPrecioBrutoAutoriza.Text = "0.0"
        Me.TxtIdLiquidacion.Text = ""
        Me.TxtNumeroEnsamble.Text = ""


        Me.GroupBox6.Enabled = True
        Me.BtnGuardar.Enabled = True
        Me.DTPFecha.Enabled = True
        Me.CboLocalidadLiq.Enabled = True
        Me.CboCodigoProveedor.Enabled = True
        Me.CboTipIngreso.Enabled = True
        Me.CboTipoCompra.Enabled = True
        Me.IdTipoCompra = IdTipoCompra
        Me.CboCalidad.Enabled = True
        Me.CboTipDano.Enabled = True
        Me.CboEdofisico.Enabled = True
        Me.CboImperfeccion.Enabled = True
        Me.Button10.Enabled = True
        Me.txtnombre.Enabled = True
        Me.TxtCedula.Enabled = True
        Me.CboMunicipio.Enabled = True
        Me.CboMoneda.Enabled = True
        Me.CboMonedas.Enabled = True
        Me.TabControl1.Enabled = True
        Me.Button8.Enabled = True
        Me.Button14.Enabled = True
        Me.Button2.Enabled = True
        Me.TxtTasaCambio.Enabled = True
        Me.Button3.Enabled = True
        Me.Button9.Enabled = True
        Me.Button6.Enabled = False
        Me.TDBGRidDistribucion.Enabled = True
        Me.TDGridDetalleRecibos.Enabled = True
        Me.CboTipIngreso.Text = "Automatico"
        Me.EsReciboManual = False

        limpiaGrid()
        'CboDocIngreso_SelectedIndexChanged_1(sender, e)
    End Sub

    Public Sub limpiaGrid()
        SqlString = "SELECT  AplicacionLiquidacionPergamino.Descripcion AS Concepto, TipoPago.Descripcion AS TipoPago, TipoPago.Descripcion AS NumeroSolicitud, DetalleDistribucion.Monto, DetalleDistribucion.FechaPago FROM DetalleDistribucion INNER JOIN  AplicacionLiquidacionPergamino ON DetalleDistribucion.IdAplicacionLiquidacionPergamino = AplicacionLiquidacionPergamino.IdAplicacionLiquidacionPergamino INNER JOIN                          TipoPago ON DetalleDistribucion.IdTipoPago = TipoPago.IdTipoPago WHERE        (DetalleDistribucion.IdDetalleDistribucion = - 100)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Distribucion12")
        Me.TDBGRidDistribucion.DataSource = DataSet.Tables("Distribucion12")

        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).Width = 160

        Me.TDBGRidDistribucion.AllowAddNew = True


        SqlString = "SELECT   ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ISNULL(PrecioCafe.Precio, 0) AS Precio, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) * ISNULL(PrecioCafe.Precio, 0) AS ValorBrutoC$, (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara)  * ISNULL(PrecioCafe.Precio, 0) / ISNULL(TipoCambio.TipoCambio, 1) AS ValorBruto$, ReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto,DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.Imperfeccion AS PesoNTCompara FROM  ReciboCafePergamino INNER JOIN   DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  TipoCompra ON ReciboCafePergamino.IdTipoCompra = TipoCompra.IdTipoCompra LEFT OUTER JOIN   TipoCambio ON ReciboCafePergamino.Fecha = TipoCambio.FechaTipoCambio LEFT OUTER JOIN   PrecioCafe ON ReciboCafePergamino.IdLocalidad = PrecioCafe.IdLocalidad AND ReciboCafePergamino.IdCalidad = PrecioCafe.IdCalidad WHERE  (ReciboCafePergamino.IdProductor = '-100') AND (ReciboCafePergamino.IdDano = 55555) AND (ReciboCafePergamino.IdCalidad = " & IdCalidad & ") AND (ReciboCafePergamino.IdLocalidadLiquidacion = -9878) AND (DetalleReciboCafePergamino.IdEdoFisico = -84654) AND (ReciboCafePergamino.IdTipoCompra = " & IdTipoCompra & ")AND (ReciboCafePergamino.IdTipoIngreso = '" & IdTipoIngreso & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DetalleRecibos")
        Me.TDGridDetalleRecibos.DataSource = DataSet.Tables("DetalleRecibos")

        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).Width = 149
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).Width = 150
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).Width = 150
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).Width = 150
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).Width = 149
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(6).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(7).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(8).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(9).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(11).Visible = False
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center



        Me.LblTotalPesoKG.Text = "= 0.00"
        Me.LblValorC.Text = "= 0.00"
        Me.TxtValorBrutoCor.Text = "= 0.00"



    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim count As Integer, i As Integer, Saldo As Double, Monto As Double, TotalSaldo As Double, TotalMonto As Double
        Select Case TabControl1.SelectedIndex
            Case 0
                Me.LblTotalPesoKG.Visible = True
                Me.LblValorC.Visible = True
                Me.TxtValorBrutoCor.Visible = True

                Me.LblTotalSaldo.Visible = False
                Me.LblTotalMonto.Visible = False

                Me.Lbltxmonto.Visible = False
                Me.LbltxSaldo.Visible = False

                Me.LblTotalPesoKG.Location = New Point(337, 536)
                Me.LblValorC.Location = New Point(610, 536)
                Me.TxtValorBrutoCor.Location = New Point(775, 536)

                Me.BtnBorrarLinea.Visible = False

            Case 1
                Me.LblTotalPesoKG.Visible = False
                Me.LblValorC.Visible = False
                Me.TxtValorBrutoCor.Visible = False

                Me.LblTotalSaldo.Visible = False
                Me.LblTotalMonto.Visible = True

                Me.Lbltxmonto.Visible = False
                Me.LbltxSaldo.Visible = False

                Me.LblTotalSaldo.Location = New Point(370, 536)
                Me.LbltxSaldo.Location = New Point(370, 555)

                Me.LblTotalMonto.Location = New Point(600, 536)
                Me.Lbltxmonto.Location = New Point(245, 555)
                Me.BtnBorrarLinea.Visible = True
                sumagriddistribucion()

        End Select
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        My.Forms.FrmResumenLiquidacion.Show()
    End Sub
    Private Sub CboMonedas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMonedas.TextChanged
        sql = "SELECT  IdMoneda, Nombre, Simbolo  FROM Moneda  WHERE (Nombre = '" & Me.CboMonedas.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Moneda1")
        If DataSet.Tables("Moneda1").Rows.Count = 0 Then
            IdMoneda = 0
        Else
            IdMoneda = DataSet.Tables("Moneda1").Rows(0)("IdMoneda")
        End If

        If Not IdMoneda = 610 Then
            Me.GrpValorDolar.Visible = False
        Else
            Me.GrpValorDolar.Visible = True
        End If
        DataSet.Tables("Moneda1").Reset()
    End Sub

    Private Sub TxtIdLiquidacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIdLiquidacion.TextChanged
        If Quien2 = "Nuevo" Then
            Exit Sub
        End If

        ImprimirConfirmado = False

        If Me.TxtIdLiquidacion.Text = "" Then
            Idliquidacion = 0
        Else
            Idliquidacion = Me.TxtIdLiquidacion.Text
        End If

        Dim Sql As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, DataSet1 As New DataSet, DataAdapter1 As New SqlClient.SqlDataAdapter, SumaRec As String
        Dim count As Integer, i As Integer = 0, Descripcion As String, item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item1 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim sql1 As String, SumPaseo As String, sqldet As String, CodLocalidad As String, codigo
        Dim IdEstadoLlama As String, filas As Integer = 0, Cont As Double, TipoImp As String

        Try
            'Municipio.Nombre,   INNER JOIN    Municipio ON LiquidacionPergamino.IdMunicipio = Municipio.IdMunicipio
            'RECORDAR HACER EL CMBIO DE BUSCAR EL CODIGO POR QUE LO DEJO PARA 6 PERO QUE PASARIA SI FUESE MAS DE 6 DIGITOS. 
            'LiquidacionPergamino.PrecioAutoriza,
            Sql = "SELECT        LiquidacionPergamino.Fecha, LiquidacionPergamino.Precio, Proveedor.Cod_Proveedor, YEAR(Cosecha.FechaInicial) AS Fechainicial, YEAR(Cosecha.FechaFinal) AS FechaFinal, LugarAcopio.NomLugarAcopio, TipoIngreso.Descripcion AS TipoIngreso, EstadoDocumento.Descripcion AS EstadoDocumento, TipoCompra.Nombre AS TipoCompra, EstadoFisico.Descripcion AS EdoFisico, RangoImperfeccion.Nombre AS RangoImperfeccion,  Calidad.NomCalidad, Dano.Nombre AS Dano, Moneda.Simbolo, EstadoDocumento.IdEstadoDocumento, LiquidacionPergamino.IdLiquidacionPergamino, LugarAcopio.CodLugarAcopio AS Localidad,                           RIGHT(LiquidacionPergamino.Codigo, 6) AS Numero, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.TotalDeducciones, LiquidacionPergamino.ChkRentDef, LiquidacionPergamino.ChkRent2, LiquidacionPergamino.ChkRent3, LiquidacionPergamino.Serie2, LiquidacionPergamino.ChkMuncipal, TipoCambio.TipoCambio, ReciboCafePergamino.CedulaManual,  ReciboCafePergamino.ProductorManual, ReciboCafePergamino.EsProductorManual  FROM  LiquidacionPergamino INNER JOIN  Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  Cosecha ON LiquidacionPergamino.IdCosecha = Cosecha.IdCosecha INNER JOIN  LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN  EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN  EstadoFisico ON LiquidacionPergamino.IdEstadoFisico = EstadoFisico.IdEdoFisico INNER JOIN  RangoImperfeccion ON LiquidacionPergamino.IdCategoriaImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN   Moneda ON LiquidacionPergamino.IdMoneda = Moneda.IdMoneda INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio " & _
                  "WHERE (LiquidacionPergamino.IdLiquidacionPergamino = '" & Idliquidacion & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "LlamaLiquida")

            If DataSet.Tables("LlamaLiquida").Rows.Count = 0 Then
                Exit Sub
            End If

            IdEstadoLlama = DataSet.Tables("LlamaLiquida").Rows(0)("IdEstadoDocumento")
            EsProductorManual = DataSet.Tables("LlamaLiquida").Rows(0)("EsProductorManual")
            If IdEstadoLlama = 294 Then
                Me.GroupBox6.Enabled = False
                Me.TDBGRidDistribucion.Enabled = False
                Me.TDGridDetalleRecibos.Enabled = False
                Me.BtnGuardar.Enabled = False
                Me.GrpValorDolar.Visible = True
                Me.DTPFecha.Enabled = False
                Me.CboEstadoDocumeto.Text = "Confirmado"

                Me.Checkbox4.Enabled = False
                Me.Checkpor1.Enabled = False
                Me.Checkpor3.Enabled = False
                Me.Checkpor2.Enabled = False

            ElseIf IdEstadoLlama = 293 Then
                Me.CboEstadoDocumeto.Text = "Editable"

                Me.Checkbox4.Enabled = True
                Me.Checkpor1.Enabled = True
                Me.Checkpor3.Enabled = True
                Me.Checkpor2.Enabled = True

                Me.DTPFecha.Enabled = False
                Me.CboLocalidadLiq.Enabled = False
                Me.CboCodigoProveedor.Enabled = False
                Me.CboTipIngreso.Enabled = False
                Me.CboTipoCompra.Enabled = False
                Me.IdTipoCompra = IdTipoCompra
                Me.CboCalidad.Enabled = False
                Me.CboTipDano.Enabled = False
                Me.CboEdofisico.Enabled = False
                Me.CboImperfeccion.Enabled = False
                Me.Button10.Enabled = False
                Me.txtnombre.Enabled = False
                Me.TxtCedula.Enabled = False
                Me.CboMunicipio.Enabled = False
                Me.CboMoneda.Enabled = False
                Me.CboMonedas.Enabled = True
                Me.TabControl1.Enabled = True
                Me.Button8.Enabled = False
                Me.Button14.Enabled = False
                Me.Button2.Enabled = False
                Me.TxtTasaCambio.Enabled = False
                Me.Button3.Enabled = True
                Me.Button9.Enabled = True
                Me.Button6.Enabled = False
                Me.TDBGRidDistribucion.Enabled = True
                Me.TDGridDetalleRecibos.Enabled = True



            End If

            'MsgBox("Desea Activar este usuario ", MsgBoxStyle.YesNo, "Clientes")

            If Not DataSet.Tables("LlamaLiquida").Rows.Count = 0 Then
                '  IdDestino, IdTipoCafe, IdTipoIngreso, IdUMedida, IdElaboradorPor, IdUsuario, IdCompany, FechaModificacion, Serie, IdtipoDocumento

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Localidad")) Then
                    Me.TxtIdLocalidad.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Localidad")
                Else
                    Me.TxtIdLocalidad.Text = ""
                End If

                'If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Serie")) Then
                '    Me.TxtNumeroEnsamble.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Serie")
                'Else
                '    Me.TxtNumeroEnsamble.Text = ""
                'End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Fecha")) Then
                    Me.DTPFecha.Value = DataSet.Tables("LlamaLiquida").Rows(0)("Fecha")
                Else
                    Me.DTPFecha.Value = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Cod_Proveedor")) Then
                    If EsProductorManual = True Then
                        Me.TxtCedula.Text = DataSet.Tables("LlamaLiquida").Rows(0)("CedulaManual")
                        Me.Cedula = DataSet.Tables("LlamaLiquida").Rows(0)("CedulaManual")
                        Me.CboCodigoProveedor.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Cod_Proveedor")
                        Me.txtnombre.Text = DataSet.Tables("LlamaLiquida").Rows(0)("ProductorManual")
                    Else
                        Me.CboCodigoProveedor.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Cod_Proveedor")
                    End If
                Else
                    Me.CboCodigoProveedor.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("TipoCambio")) Then
                    Me.TxtTasaCambio.Text = DataSet.Tables("LlamaLiquida").Rows(0)("TipoCambio")
                Else
                    Me.TxtTasaCambio.Text = ""
                End If

                If IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Fechainicial")) Or IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("FechaFinal")) Then
                    Me.LblCosecha.Text = ""
                Else
                    Me.LblCosecha.Text = "Cosecha: " & DataSet.Tables("LlamaLiquida").Rows(0)("Fechainicial") & "-" & (DataSet.Tables("LlamaLiquida").Rows(0)("FechaFinal"))
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("NomLugarAcopio")) Then
                    Me.CboLocalidadLiq.Text = DataSet.Tables("LlamaLiquida").Rows(0)("NomLugarAcopio")
                    Me.LblSucursal.Text = Me.CboLocalidadLiq.Text

                Else
                    Me.CboCodigoProveedor.Text = ""
                    Me.LblSucursal.Text = ""
                End If

                Sql = "SELECT  Municipio.Nombre, LiquidacionPergamino.IdLiquidacionPergamino    FROM    LiquidacionPergamino INNER JOIN  Municipio ON LiquidacionPergamino.IdMunicipio = Municipio.IdMunicipio WHERE (LiquidacionPergamino.IdLiquidacionPergamino = '" & Me.TxtIdLiquidacion.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Municipio")

                If DataSet.Tables("Municipio").Rows.Count <> 0 Then
                    If Not IsDBNull(DataSet.Tables("Municipio").Rows(0)("Nombre")) Then
                        Me.CboMunicipio.DataSource = DataSet.Tables("Municipio")
                        Me.CboMunicipio.Text = DataSet.Tables("Municipio").Rows(0)("Nombre")
                    Else
                        Me.CboMunicipio.Text = ""
                    End If
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("TipoIngreso")) Then
                    Me.CboTipIngreso.Text = DataSet.Tables("LlamaLiquida").Rows(0)("TipoIngreso")
                Else
                    Me.CboTipIngreso.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Serie2")) Then
                    Me.TxtSerie.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Serie2")
                Else
                    Me.TxtSerie.Text = ""
                End If

                'If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("ChkRentDef")) Then
                '    Me.Checkpor2.Checked = DataSet.Tables("LlamaLiquida").Rows(0)("ChkRentDef")
                'Else
                '    Me.Checkpor2.Checked = False
                'End If

                'If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("ChkRent2")) Then
                '    Me.Checkbox4.Checked = DataSet.Tables("LlamaLiquida").Rows(0)("ChkRent2")
                'Else
                '    Me.Checkbox4.Checked = False
                'End If

                'If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("ChkRent3")) Then
                '    Me.Checkpor3.Checked = DataSet.Tables("LlamaLiquida").Rows(0)("ChkRent3")
                'Else
                '    Me.Checkpor3.Checked = False
                'End If

                'If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("ChkMuncipal")) Then
                '    Me.Checkpor1.Checked = DataSet.Tables("LlamaLiquida").Rows(0)("ChkMuncipal")
                'Else
                '    Me.Checkpor1.Checked = False
                'End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("TipoCompra")) Then
                    Me.CboTipoCompra.Text = DataSet.Tables("LlamaLiquida").Rows(0)("TipoCompra")
                Else
                    Me.CboTipoCompra.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("RangoImperfeccion")) Then
                    Me.CboImperfeccion.Text = DataSet.Tables("LlamaLiquida").Rows(0)("RangoImperfeccion")
                Else
                    Me.CboImperfeccion.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("EdoFisico")) Then
                    Me.CboEdofisico.Text = DataSet.Tables("LlamaLiquida").Rows(0)("EdoFisico")
                Else
                    Me.CboEdofisico.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("NomCalidad")) Then
                    Me.CboCalidad.Text = DataSet.Tables("LlamaLiquida").Rows(0)("NomCalidad")
                Else
                    Me.CboCalidad.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Dano")) Then
                    Me.CboTipDano.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Dano")
                Else
                    Me.CboTipDano.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Simbolo")) Then
                    Me.CboMoneda.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Simbolo")
                Else
                    Me.CboMoneda.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("NumeroReembolso")) Then
                    Me.TxtReembolso.Text = DataSet.Tables("LlamaLiquida").Rows(0)("NumeroReembolso")
                Else
                    Me.TxtReembolso.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Precio")) Then
                    Me.TxtPrecio.Text = Format(DataSet.Tables("LlamaLiquida").Rows(0)("Precio"), "##,##0.00")
                    Me.TxtPrecioSG.Text = Me.TxtPrecio.Text
                Else
                    Me.TxtPrecio.Text = 0.0
                    Me.TxtPrecioSG.Text = Me.TxtPrecio.Text
                End If

                If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("Numero")) Then
                    Me.TxtNumeroEnsamble.Text = DataSet.Tables("LlamaLiquida").Rows(0)("Numero")
                Else
                    Me.TxtNumeroEnsamble.Text = ""
                End If

                If Me.TxtNumeroEnsamble.Text = "-----0-----" Or Me.TxtNumeroEnsamble.Text = "" Or Me.TxtNumeroEnsamble.Text = "---0---" Then
                    Exit Sub
                End If

                Sql = "SELECT  LiquidacionPergaminoImpuesto.*, Impuesto.* FROM LiquidacionPergaminoImpuesto INNER JOIN  Impuesto ON LiquidacionPergaminoImpuesto.IdImpuesto = Impuesto.IdImpuesto  " & _
                      "WHERE (LiquidacionPergaminoImpuesto.IdLiquidacionPergamino = " & Idliquidacion & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Impuestos")
                Cont = DataSet.Tables("Impuestos").Rows.Count
                i = 0
                Do While Cont > i
                    TipoImp = DataSet.Tables("Impuestos").Rows(i)("Descripcion")
                    If TipoImp = "Imp. Municipal" Then
                        Me.Checkpor1.Checked = True
                    Else
                        Me.Checkpor1.Checked = False
                    End If


                    If TipoImp = "Retención 2%" Then
                        Me.Checkbox4.Checked = True
                    Else
                        Me.Checkbox4.Checked = False
                    End If

                    If TipoImp = "Retención Definitiva" Then
                        Me.Checkpor2.Checked = True
                    Else
                        Me.Checkpor2.Checked = False
                    End If

                    If TipoImp = "Retención 3%" Then
                        Me.Checkpor3.Checked = True
                    Else
                        Me.Checkpor3.Checked = False
                    End If

                    i = i + 1
                Loop

                'If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("PrecioAutoriza")) Then
                '    Me.TxtPrecioBrutoAutoriza.Text = DataSet.Tables("LlamaLiquida").Rows(0)("PrecioAutoriza")
                'Else
                '    Me.TxtPrecioBrutoAutoriza.Text = 0.0
                'End If

                'Sql = "SELECT ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.Precio,   DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio AS ValorBrutoC$, DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio / TipoCambio.TipoCambio AS ValorBruto$, ReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara,  DetalleLiquidacionPergamino.PesoNeto AS PesoNTCompara  FROM   LiquidacionPergamino INNER JOIN    DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN   ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN    TipoCambio ON LiquidacionPergamino.IdMonedaPreecio = TipoCambio.IdTipoCambio   WHERE  (LiquidacionPergamino.IdLiquidacionPergamino = '" & Me.TxtIdLiquidacion.Text & "')"
                Sql = "SELECT ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.Precio, DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio AS ValorBrutoC$, DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio / TipoCambio.TipoCambio AS ValorBruto$, ReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleLiquidacionPergamino.PesoNeto AS PesoNTCompara, TipoCambio.TipoCambio FROM  LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio  " & _
                      "WHERE  (LiquidacionPergamino.IdLiquidacionPergamino = '" & Me.TxtIdLiquidacion.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "RecibosLiquida")
                'Me.TDGridDetalleRecibos.DataSource = DataSet.Tables("RecibosLiquida")

                Me.BinDetalleRecLiq.DataSource = DataSet.Tables("RecibosLiquida")
                Me.TDGridDetalleRecibos.DataSource = Me.BinDetalleRecLiq.DataSource
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("NºRecibo").Locked = True
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("PesoNeto").Locked = True
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBrutoC$").Locked = True
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBruto$").Locked = True
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("ValorBruto$").Locked = True
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("Precio").Locked = True
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns("TipoCambio").Locked = True
                'Me.BinDetalleRecLiq.DataSource = DataSet.Tables("RecibosLiquida")
                'Me.TDGridDetalleRecibos.DataSource = Me.BinDetalleRecLiq

                Me.TDGridDetalleRecibos.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
                Me.TDGridDetalleRecibos.Columns(0).ValueItems.CycleOnClick = True
                With Me.TDGridDetalleRecibos.Columns(0).ValueItems.Values

                    item.Value = "False"
                    item.DisplayValue = Me.ImageList.Images(1)
                    .Add(item)

                    item = New C1.Win.C1TrueDBGrid.ValueItem()
                    item.Value = "True"
                    item.DisplayValue = Me.ImageList.Images(0)
                    .Add(item)

                    Me.TDGridDetalleRecibos.Columns(0).ValueItems.Translate = True
                End With

                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).Width = 149
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).Width = 150
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).Width = 150
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).Width = 150
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).Width = 149
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(6).Visible = False
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(7).Visible = False
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(8).Visible = False
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(9).Visible = False
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(10).Visible = False
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(11).Visible = False
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                Me.CheckTodosRecibos.Checked = True
                'Me.TDGridDetalleRecibos.Columns("Aplicar").Value = False
                'Me.TDGridDetalleRecibos.Columns("Aplicar").Value = True
                Me.TDGridDetalleRecibos.Columns("ValorBruto$").NumberFormat = "##,##0.00"
                Me.TDGridDetalleRecibos.Columns("Precio").NumberFormat = "##,##0.00"
                Me.TDGridDetalleRecibos.Columns("PesoNeto").NumberFormat = "##,##0.00"
                Me.TDGridDetalleRecibos.Columns("ValorBrutoC$").NumberFormat = "##,##0.00"
                Me.TDGridDetalleRecibos.Columns("ValorBruto$").NumberFormat = "##,##0.00"


                Sql = "SELECT  AplicacionLiquidacionPergamino.Descripcion AS Concepto, TipoPago.Descripcion AS TipoPago, DetalleDistribucion.NumeroAvio AS NumeroSolicitud, DetalleDistribucion.Monto AS Monto,  DetalleDistribucion.FechaPago AS FechaPago, DetalleDistribucion.IdDetalleDistribucion   FROM    DetalleDistribucion INNER JOIN   AplicacionLiquidacionPergamino ON DetalleDistribucion.IdAplicacionLiquidacionPergamino = AplicacionLiquidacionPergamino.IdAplicacionLiquidacionPergamino INNER JOIN  TipoPago ON DetalleDistribucion.IdTipoPago = TipoPago.IdTipoPago INNER JOIN LiquidacionPergamino ON DetalleDistribucion.IdLiquidacionPergamino = LiquidacionPergamino.IdLiquidacionPergamino  WHERE  (LiquidacionPergamino.IdLiquidacionPergamino = '" & Me.TxtIdLiquidacion.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "DistrbLiquida")
                Me.TDBGRidDistribucion.DataSource = DataSet.Tables("DistrbLiquida")
                'count = DataSet.Tables("DistrbLiquida").Rows.Count

                count = 0
                i = 0
                SqlString = "SELECT Descripcion   FROM    AplicacionLiquidacionPergamino"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "AplicacionLiquid")
                count = DataSet.Tables("AplicacionLiquid").Rows.Count

                Me.TDBGRidDistribucion.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
                With Me.TDBGRidDistribucion.Columns(0).ValueItems.Values
                    Do While count > i
                        If i = 0 Then
                            Descripcion = DataSet.Tables("AplicacionLiquid").Rows(i)("Descripcion")
                            item1.Value = Descripcion
                            .Add(item1)
                        Else
                            Descripcion = DataSet.Tables("AplicacionLiquid").Rows(i)("Descripcion")
                            item1 = New C1.Win.C1TrueDBGrid.ValueItem()
                            item1.Value = Descripcion
                            .Add(item1)
                        End If
                        i = i + 1
                    Loop
                End With
                count = 0
                i = 0
                SqlString = "SELECT   Descripcion   FROM TipoPago WHERE  (Activo = 1) "
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TipoPago")
                count = DataSet.Tables("TipoPago").Rows.Count
                '____________________________________________________
                'LLENE LOS COMBOBOX(0) DEL GRID DE DISTRBUCION 
                '____________________________________________________
                Me.TDBGRidDistribucion.Columns(1).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
                With Me.TDBGRidDistribucion.Columns(1).ValueItems.Values
                    Do While count > i
                        If i = 0 Then
                            Descripcion = DataSet.Tables("TipoPago").Rows(i)("Descripcion")
                            item2.Value = Descripcion
                            .Add(item2)
                        Else
                            Descripcion = DataSet.Tables("TipoPago").Rows(i)("Descripcion")
                            item2 = New C1.Win.C1TrueDBGrid.ValueItem()
                            item2.Value = Descripcion
                            .Add(item2)
                        End If
                        i = i + 1
                    Loop
                End With
            End If


            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).Width = 160
            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).Width = 160
            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).Width = 200
            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).Width = 160
            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).Width = 160
            Me.TDBGRidDistribucion.Columns(3).NumberFormat = "##,##0.00"


            Me.TDBGRidDistribucion.Columns(2).EditMask = "#-##-#####"
            Me.TDBGRidDistribucion.Columns(2).EditMaskUpdate = True

            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).Locked = False

            Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(5).Visible = False

            'ACTUALIZO EL GRID
            SumaGrid1()
            sumagriddistribucion()
            'Else
            'Button3_Click(sender, e)
            'Exit Sub
            'End If
            If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("EstadoDocumento")) Then
                Me.CboEstadoDocumeto.Text = DataSet.Tables("LlamaLiquida").Rows(0)("EstadoDocumento")
            Else
                Me.CboEstadoDocumeto.Text = ""
            End If

            'CalculaPrecioBruto()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub SumaGrid1()
        Dim PesoBruto As Double
        Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double, ResultadoC As Double, ResultadoD As Double, TipoImpuesto As String
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, ContarSelec As Double, estado As Boolean, codigo As String, ContaTrue As Double
        Dim IdTipCompra As Integer, Ingreso As Integer, eleccion As Boolean, CodLocalidad As String, codigoRecibo As String, CadenaDiv() As String, Cadena As String
        Dim PorImperfeccion As Double, Sacos As Double, PesoBruto2 As Double, Tara As Double

        i = 0
        PesoBruto = 0
        valorCor = 0
        ValorDol = 0
        Registros = Me.TDGridDetalleRecibos.RowCount

        If Me.TDGridDetalleRecibos.Col = 0 Or Me.TDGridDetalleRecibos.Col = 2 Then
            Do While Registros > i
                eleccion = Me.BinDetalleRecLiq.Item(i)("Aplicar")
                If Not eleccion = False Then
                    '____________________________________________
                    'CONTADOR PARA VER CUANTOS VERDADEROS SON 
                    '____________________________________________
                    ContaTrue = ContaTrue + 1
                    '________________________________________________________________________________________
                    'VALIDAMOS EL NUMERO DE LIQUIDACION DE RECIBOS DIRECTOS AUTOMATICOS  
                    '________________________________________________________________________________________
                    PesoBruto = Me.BinDetalleRecLiq.Item(i)("PesoNeto") + PesoBruto
                    valorCor = Me.BinDetalleRecLiq.Item(i)("ValorBrutoC$") + valorCor
                    ValorDol = Me.BinDetalleRecLiq.Item(i)("ValorBruto$") + ValorDol

                    PorImperfeccion = Me.BinDetalleRecLiq.Item(i)("Imperfeccion") + PorImperfeccion
                    Sacos = Me.BinDetalleRecLiq.Item(i)("CantidadSacos") + Sacos
                    PesoBruto2 = Me.BinDetalleRecLiq.Item(i)("PesoBruto") + PesoBruto2
                    Tara = Me.BinDetalleRecLiq.Item(i)("Tara") + Tara

                    codigo = Me.BinDetalleRecLiq.Item(i)("NºRecibo")

                    If Mid(codigo, 1, 1) = "Ø" Then
                        codigo = Mid(codigo, 3, Len(codigo))
                    End If

                    If Len(Trim(codigo)) = 10 Then
                        CadenaDiv = codigo.Split("-")
                        CodLocalidad = CadenaDiv(0)
                        codigoRecibo = CadenaDiv(1)
                    ElseIf Len(Trim(codigo)) > 10 Then
                        CadenaDiv = codigo.Split("-")
                        CodLocalidad = CadenaDiv(1)
                        codigoRecibo = CadenaDiv(2)
                    Else
                        codigoRecibo = codigo
                    End If

                    If IdTipoCompra = 108 And (IdTipoIngreso = 1646 Or IdTipoIngreso = 295) And eleccion = True Then
                        Me.TxtNumeroEnsamble.Text = codigoRecibo
                        Me.TxtIdLocalidad.Text = CodLocalidad
                    End If
                    i = i + 1
                Else
                    i = i + 1
                End If
            Loop
        End If

        Me.LblTotalPesoKG.Text = "= " + Format(PesoBruto, "##,##0.00")
        Me.LblValorC.Text = "= " + Format(valorCor, "##,##0.00")
        Me.TxtValorBrutoCor.Text = Format(valorCor, "##,##0.00")
        Me.TxtValorBrutoCor.Text = "= " + Format(ValorDol, "##,##0.00")


        Me.TxtPorcentajeImperfec.Text = Format(PorImperfeccion, "####0.00")
        Me.TxtSacos.Text = Format(Sacos, "####0.00")
        Me.TextPesoBruto.Text = Format(PesoBruto2, "####0.00")
        Me.TxtTAra.Text = Format(Tara, "####0.00")

        totalCor = Mid(Me.LblValorC.Text, 3, Len(Me.LblValorC.Text))
        totalDol = Mid(Me.TxtValorBrutoCor.Text, 3, Len(Me.TxtValorBrutoCor.Text))

        If Me.Checkpor1.Checked = True Then
            TipoImpuesto = "Imp. Municipal"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto1")

            Porcentaje = DataSet.Tables("Impuesto1").Rows(0)("Valor")
            ImpMuniC = Porcentaje * totalCor
            ImpMuniD = Porcentaje * totalDol
        Else
            ImpMuniC = 0
            ImpMuniD = 0
        End If

        Porcentaje = 0

        If Me.Checkpor2.Checked = True Then

            TipoImpuesto = "Retención Definitiva"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto2")

            Porcentaje = DataSet.Tables("Impuesto2").Rows(0)("Valor")
            RetDefC = Porcentaje * totalCor
            RetDefD = Porcentaje * totalDol

            Me.TxtRentDefC.Text = Format(RetDefC, "##,##0.00")
            Me.TxtRentDefD.Text = Format(RetDefD, "##,##0.00")
        Else
            RetDefC = 0
            RetDefD = 0
            Me.TxtRentDefC.Text = "0.00"
            Me.TxtRentDefD.Text = "0.00"
        End If

        Porcentaje = 0

        If Me.Checkbox4.Checked = True Then
            TipoImpuesto = "Retención 2%"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto4")

            Porcentaje = DataSet.Tables("Impuesto4").Rows(0)("Valor")
            Reten2C = Porcentaje * totalCor
            Reten2D = Porcentaje * totalDol
        Else
            Reten2C = 0
            Reten2D = 0
        End If

        If Me.Checkpor3.Checked = True Then
            TipoImpuesto = "Retención 3%"
            SqlString = "SELECT  Descripcion, Valor, VigenciaInicial, VigenciaFinal   FROM   Impuesto   WHERE    (Descripcion = '" & TipoImpuesto & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Impuesto3")

            Porcentaje = DataSet.Tables("Impuesto3").Rows(0)("Valor")
            Ret3C = Porcentaje * totalCor
            Ret3D = Porcentaje * totalDol
        Else
            Ret3C = 0
            Ret3D = 0
        End If

        'aqui va el otro

        TotalDecC = ImpMuniC + RetDefC + Ret3C + Reten2C
        TotalDecD = ImpMuniD + RetDefD + Ret3D + Reten2D

        Me.TxtTotalDecC.Text = Format(TotalDecC, "##,##0.00")
        Me.TxtTotalDecD.Text = Format(TotalDecD, "##,##0.00")

        NetoPagarC = totalCor - TotalDecC
        NetoPagarD = totalDol - TotalDecD

        Me.TxtTotalCor.Text = Format(NetoPagarC, "##,##0.00")
        Me.TxtTotalDol.Text = Format(NetoPagarD, "##,##0.00")
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub
    Private Sub CboEdofisico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEdofisico.SelectedIndexChanged
        limpiaGrid()

        If Me.CboEdofisico.Text = "" Then
            Exit Sub
        End If

        SqlString = "SELECT  EstadoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto, IdEdoFisico  FROM     EstadoFisico  WHERE (Descripcion = '" & Me.CboEdofisico.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Fisico1")
        IdEdoFisico = DataSet.Tables("Fisico1").Rows(0)("IdEdoFisico")

        CalculaPrecioBruto()
        DataSet.Tables("Fisico1").Reset()
    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim ArepBitacoraLiquidacion As New ArepBitacoraLiquidacion, Sqldatos As String, RutaLogo As String
        Dim NumEnsambleRep As String, PrecioNeto As Double, PesoNeto As Double, TotalLiquida As Double
        Dim Cont As Double, Cadena As String, i As Double, Cosecha As String = Me.LblCosecha.Text

        ValidaDistribuicion()

        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            ArepBitacoraLiquidacion.LblNombreEmpresa.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            'ArepBitacoraLiquidacion.LblDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            'If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
            '    'ArepBitacoraLiquidacion.LblRuc.Text = "Numero RUC " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
            'End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepBitacoraLiquidacion.ImgLogoLiquid.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If
        End If

        Select Case IdTipoIngreso
            'Manual
            Case 295
                If IdTipoCompra = 108 Then
                    ' manual y directa 
                    NumEnsambleRep = Me.TxtNumeroEnsamble.Text
                ElseIf IdTipoCompra = 109 Then
                    ' manual y deposito 
                    NumEnsambleRep = Me.TxtNumeroEnsamble.Text
                End If
                ' automatico 
            Case 1646
                If IdTipoCompra = 108 Then
                    ' automatica y directa 
                    NumEnsambleRep = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                ElseIf IdTipoCompra = 109 Then
                    ' automatica y  deposito
                    NumEnsambleRep = Me.TxtSerie.Text & "-" & Me.TxtIdLocalidad.Text + "-" + Me.TxtNumeroEnsamble.Text
                End If
        End Select



        '////////////////////////////////////////RECORRO LOS RECIOBOS PARA MOSTRARLOS ///////////////////////
        cont = Me.TDGridDetalleRecibos.RowCount
        i = 0
        Cadena = ""
        Do While Cont > i
            Cadena = Cadena & " " & Me.TDGridDetalleRecibos.Item(i)("NºRecibo")
            i = i + 1
        Loop

        ArepBitacoraLiquidacion.LblRecibos.Text = Cadena


        ArepBitacoraLiquidacion.LblNumeroLiquida.Text = NumEnsambleRep
        ArepBitacoraLiquidacion.NumeroLiquidacion = NumEnsambleRep

        If Me.TxtIdLiquidacion.Text <> "" Then
            ArepBitacoraLiquidacion.idLiquidacion = Me.TxtIdLiquidacion.Text
        End If
        ArepBitacoraLiquidacion.LblFecha.Text = Format(CDate(Me.DTPFecha.Value), "dd/MM/yyyy HH:mm")
        ArepBitacoraLiquidacion.LblCosecha.Text = Mid(Cosecha, 10)
        ArepBitacoraLiquidacion.LblLocalidad.Text = Me.CboLocalidadLiq.Text
        ArepBitacoraLiquidacion.LblProductor.Text = Me.CboCodigoProveedor.Text & "-" & Me.txtnombre.Text
        ArepBitacoraLiquidacion.LblIdentificacion.Text = Me.TxtCedula.Text
        ArepBitacoraLiquidacion.LblNombreFinca.Text = Me.CboFinca.Text
        ArepBitacoraLiquidacion.LblUbiFinca.Text = Me.TxtUbicaFinca.Text

        If Me.EsProductorManual = True Then
            ArepBitacoraLiquidacion.LblMunicipio.Text = ""
        Else
            ArepBitacoraLiquidacion.LblMunicipio.Text = Me.CboMunicipio.Text
        End If




        'Datos del cafe
        ArepBitacoraLiquidacion.LblCalidad.Text = Me.CboCalidad.Text
        ArepBitacoraLiquidacion.LblEdoFisico.Text = Me.CboEdofisico.Text
        ArepBitacoraLiquidacion.LblDano.Text = Me.CboTipDano.Text

        If IdTipoCompra = 108 Then
            ArepBitacoraLiquidacion.Label1.Text = "RECIBO LIQUIDACION.CAFE PERGAMINO "  'COMPRA DIRECTA
            ArepBitacoraLiquidacion.LblPorcImper.Text = Me.TxtPorcentajeImperfec.Text & " %"
        ElseIf IdTipoCompra = 109 Then
            ArepBitacoraLiquidacion.LblPorcImper.Text = Me.CboImperfeccion.Text
            ArepBitacoraLiquidacion.Label20.Text = "IMPERFECCION:"
            ArepBitacoraLiquidacion.Label1.Text = "LIQUIDACION CAFE PERGAMINO" '"RECIBO LIQUIDACION.CAFE PERGAMINO COMPRA DEPOSITO"
        End If



        ArepBitacoraLiquidacion.LblCantSacos.Text = Format(CDbl(Me.TxtSacos.Text), "##,##")
        ArepBitacoraLiquidacion.LblPesoBruto.Text = CDbl(Mid(Me.LblTotalPesoKG.Text, 3)) + CDbl(Me.TxtTAra.Text)
        ArepBitacoraLiquidacion.LblTara.Text = Me.TxtTAra.Text
        ArepBitacoraLiquidacion.LblPesoNeto.Text = Mid(Me.LblTotalPesoKG.Text, 3)

        If Me.TxtPrecioBrutoSinDeduc.Text = "" Then
            Me.TxtPrecioBrutoSinDeduc.Text = 0
        End If

        PesoNeto = Mid(Me.LblTotalPesoKG.Text, 3)
        TotalLiquida = Me.TxtTotalCor.Text

        ArepBitacoraLiquidacion.LblPrecioBruto.Text = Format(CDbl(Me.TxtPrecio.Text), "##,##0.00")

        ArepBitacoraLiquidacion.LblPrecioNeto.Text = Format(TotalLiquida / PesoNeto, "##,##0.00")    ' Format(CDbl(Me.TxtPrecioBrutoSinDeduc.Text), "##,##0.00")
        ArepBitacoraLiquidacion.LblTipoCambio.Text = Me.TxtTasaCambio.Text
        ArepBitacoraLiquidacion.LblSubTotal.Text = Mid(Me.LblValorC.Text, 3)
        ArepBitacoraLiquidacion.LblPorcRetDeter.Text = "1.5%"
        ArepBitacoraLiquidacion.LblRetenDefini.Text = Mid(Me.TxtRentDefC.Text, 1)
        ArepBitacoraLiquidacion.LblTotalPagarCor.Text = Me.TxtTotalCor.Text
        ArepBitacoraLiquidacion.LblTotalPagarDol.Text = Me.TxtTotalDol.Text


        SQL.ConnectionString = Conexion
        'SQL.SQL = SqlString

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepBitacoraLiquidacion.Document
        'My.Application.DoEvents()
        'ArepBitacoraLiquidacion.DataSource = SQL

        'ArepBitacoraLiquidacion.Run(False)
        'ViewerForm.arvMain.Document.Print(False, False, False)
        'ViewerForm.Show()

        Quien2 = "ImprimeLiquida"
        Salir = False
        BtnGuardar_Click(sender, e)
        Salir = True

        For i = 1 To 3
            If i = 1 Then
                ArepBitacoraLiquidacion.LblOriginal.Visible = True
                ArepBitacoraLiquidacion.LblOriginal.Text = "O R I G I N A L"
                ArepBitacoraLiquidacion.Run(False)
                ViewerForm.arvMain.Document.Print(False, False, False)
                'ViewerForm.Show()
                My.Application.DoEvents()
            Else
                ArepBitacoraLiquidacion.LblOriginal.Visible = True
                ArepBitacoraLiquidacion.LblOriginal.Text = "C O P I A"
                ArepBitacoraLiquidacion.Run(False)
                ViewerForm.arvMain.Document.Print(False, False, False)
                'ViewerForm.Show()
                My.Application.DoEvents()

            End If

            'ViewerForm.Show()

            'ViewerForm.arvMain.Document.Print(False, False, False)

            ' SI ESTA HABILITADO PARA GRABAR LO PERMITO GRABAR
        Next

        'Quien2 = "ImprimeLiquida"
        'BtnGuardar_Click(sender, e)

        If Quien = "Recibo" Then
            If Salir = True Then
                Quien = ""
            End If

            My.Forms.FrmRecepcion.SalirLiquidacion(Salir)
            Exit Sub
        Else
            Button3_Click(sender, e)
        End If


        If Quien = "Recibo" Then
            Quien = ""
            Me.Close()
        End If
    End Sub

    Private Sub CboMunicipio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMunicipio.SelectedIndexChanged
        sql = "SELECT   IdMunicipio, Nombre, IdLugarAcopio  FROM    Municipio   WHERE (Nombre = '" & Me.CboMunicipio.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "IdMunicipo")
        If Not DataSet.Tables("IdMunicipo").Rows.Count = 0 Then
            IdMunicipio = DataSet.Tables("IdMunicipo").Rows(0)("IdMunicipio")
        Else
            IdMunicipio = 0
        End If
        DataSet.Tables("IdMunicipo").Reset()
    End Sub

    Private Sub CboFinca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFinca.SelectedIndexChanged
        sql = "SELECT   NomFinca, UbicaFinca, IdFinca, IdProductor   FROM            Finca   WHERE        (NomFinca = '" & Me.CboFinca.Text & "') AND (IdProductor = '" & IdProductor & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Idfinc")
        If Not DataSet.Tables("Idfinc").Rows.Count = 0 Then
            IdFinca = DataSet.Tables("Idfinc").Rows(0)("IdFinca")
            TxtUbicaFinca.Text = DataSet.Tables("Idfinc").Rows(0)("UbicaFinca")
        Else
            IdFinca = 0
        End If
        DataSet.Tables("Idfinc").Reset()
    End Sub

    Private Sub TxtPrecio_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles TxtPrecio.ChangeUICues

    End Sub

    Private Sub TxtPrecio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrecio.Click

        Dim PrecioAutoriza As Double, PrecioSugerido As Double
        'If Me.TxtNumeroEnsamble.Text = "-----0-----" Or Me.TxtNumeroEnsamble.Text = "" Or Me.TxtNumeroEnsamble.Text = "---0---" And Me.TxtIdLocalidad.Text = "" Then
        '    MsgBox("DEBE TENER UN NUMERO DE LIQUIDACION PARA CAMBIAR EL PRECIO", MsgBoxStyle.Critical, "Liquidacion")
        '    Exit Sub
        'Else

        'End If
        If Me.TxtPrecio.Text = "" Then
            PrecioAnterior = 0
        Else
            PrecioAnterior = Me.TxtPrecio.Text
        End If
        QuienTec = "LiquidacionNumero"

        If Me.TxtPrecioBrutoAutoriza.Text <> "" Then
            PrecioAutoriza = Me.TxtPrecioBrutoAutoriza.Text
        Else
            PrecioAutoriza = 0
        End If

        If Me.TxtPrecioSG.Text <> "" Then
            PrecioSugerido = Me.TxtPrecioSG.Text
        Else
            PrecioSugerido = 0
        End If

        FrmTecladoLiqui.ShowDialog()
        If UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then
            Me.TxtPrecio.Text = FrmTecladoLiqui.Numero
        Else
            '////////////////////////AUTORIZA CUALQUIER USUARIO A CAMBIAR PRECIO POR DEBAJO MARIELOS 16/07/2019                
            If CDbl(My.Forms.FrmTecladoLiqui.Numero) > CDbl(PrecioAutoriza) And CDbl(My.Forms.FrmTecladoLiqui.Numero) > CDbl(PrecioSugerido) Then  ' ///////CAMBIO SOLICITADO POR MARIELOS 16/07/2019   QUE PERMITA TODOS LOS PRECIOS MENORES 
                Me.TxtPrecio.Text = Me.TxtPrecioSG.Text                                                                      '/////////////////SE VOLVIO A CAMBIAR AHARA SE AUTORIZA LOS PRECIOS QUE NO SUPEREN LOS AUTORIZADOS  13/09/2019
            Else
                Me.TxtPrecio.Text = FrmTecladoLiqui.Numero
            End If
        End If



    End Sub

    Private Sub TxtPrecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecio.TextChanged
        Dim diferencia As Double
        If Me.TxtPrecio.Text = Me.TxtPrecioSG.Text Then
            CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
            CalcularImpuesto()
            Exit Sub
        Else
            CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
            CalcularImpuesto()
        End If

        If Quien2 = "NoJustifica" Then
            Quien2 = ""
            Exit Sub
        ElseIf Quien3 = "Ver" Then
            Quien3 = ""
            Exit Sub
        End If

        If Me.TxtPrecio.Text = "0" Or Me.TxtPrecio.Text = "" Or Me.TxtPrecio.Text = "0.0" Or Me.TxtPrecio.Text = " " Then
            Exit Sub
        Else
            '/////////////////MARIELOS DICE QUE SE PERMITEN TODOS LOS PRECIOS POR DEBAJO DE PRECIO AUTORIZA /
            '////////17/06/2019  
            If CDbl(Me.TxtPrecio.Text) > CDbl(Me.TxtPrecioBrutoAutoriza.Text) Or CDbl(Me.TxtPrecio.Text) < CDbl(Me.TxtPrecioSG.Text) Then
                If UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then
                    Quien2 = ""
                    CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
                    CalcularImpuesto()
                    'diferencia = CDbl(Me.TxtPrecio.Text) - CDbl(Me.TxtPrecioSG.Text)
                    'Me.TxtjustSave.Text = "+" & Format(diferencia, "####0.00")
                    FrmJustificacionLiquidacion.ShowDialog()
                Else
                    Quien2 = ""
                    '///////////////////////CUALQUIER USUARIO PUEDE CAMBIAR EL PRECIO POR DEBAJO MARIELOS AUTORIZO EL CAMBIO
                    '//////////16/07/2019 ----> Me.TxtPrecio.Text = Me.TxtPrecioSG.Text

                    CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
                    CalcularImpuesto()
                End If
            Else
                CambioPrecioGrid(CDbl(Me.TxtPrecio.Text))
                CalcularImpuesto()
                diferencia = CDbl(Me.TxtPrecio.Text) - CDbl(Me.TxtPrecioSG.Text)
                Me.TxtjustSave.Text = "+" & Format(diferencia, "####0.00")
                'FrmJustificacionLiquidacion.ShowDialog()
            End If
        End If

        'If UsuarioType = "AutorizaPrecioDiscrecionalidad" Then

        'ElseIf UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then

        'End If







        'CalculaPrecioNeto()
    End Sub


    Public Sub CambioPrecioGrid(ByVal Precio As Double)
        Dim PrecioXPesoCor As Double, PrecioXPesoDol As Double, count As Integer = 0, i As Integer = 0, Fila As Integer
        count = Me.TDGridDetalleRecibos.RowCount
        Do While count > i
            Me.TDGridDetalleRecibos.Row = i

            Me.TDGridDetalleRecibos.Columns(3).Text = Precio
            Me.TDGridDetalleRecibos.Columns(4).Text = Me.TDGridDetalleRecibos.Item(i)("PesoNeto") * Me.TDGridDetalleRecibos.Item(i)("Precio")
            Me.TDGridDetalleRecibos.Columns(5).Text = Me.TDGridDetalleRecibos.Item(i)("PesoNeto") * Me.TDGridDetalleRecibos.Item(i)("Precio") / TasaCambio
            i = i + 1
        Loop
        If IdTipoCompra = 108 Then
            count = Me.TDBGRidDistribucion.RowCount
            Do While count > i
                Me.TDBGRidDistribucion.Row = i
                If Me.TDBGRidDistribucion.Columns("Concepto").Text <> "" Then
                    If Me.TDBGRidDistribucion.Columns("TipoPago").Text <> "" Then
                        Me.TDBGRidDistribucion.Columns(3).Text = Format(CDbl(Me.TxtTotalDol.Text), "####0.00")
                    End If
                End If
                i = i + 1
            Loop
        End If

        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).Locked = True
    End Sub
    Private Sub TxtReembolso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReembolso.Click
        FrmTecladoLetras.ShowDialog()
        Me.TxtReembolso.Text = FrmTecladoLetras.EscrituraTeclado
    End Sub

    Private Sub TDGridDetalleRecibos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TDGridDetalleRecibos.KeyDown
        Dim colimna As String, KeyCode As Integer
        If e.KeyCode = Keys.Escape Then
            colimna = Me.TDGridDetalleRecibos.Columns(2).Text
            Me.TDGridDetalleRecibos.DataChanged = False
            KeyCode = 0
            SumaGrid1()
        End If
    End Sub

    Private Sub TDBGRidDistribucion_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TDBGRidDistribucion.BeforeColUpdate
        Dim DataSet5 As New DataSet, SqlString As String, NumeroRecibo As String
        Dim PesoBruto As Double, count As Integer, i As Integer, SumaAbono As Double, ConceptoReco As String
        Dim APlicado As Double, PorAplicar As Double, Registros As Integer, IdConcepto As Double, TotalMonto As Double, ResultadoD As Double, TipoImpuesto As String
        Dim ContarGrid As Double, estado As Boolean, codigo As String, ContaTrue As Double
        Dim IdTipCompra As Integer, Ingreso As Integer, eleccion As Boolean, CodLocalidad As String, codigoRecibo As String, CadenaDiv() As String, Cadena As String
        Dim PorImperfeccion As Double, Sacos As Double, PesoBruto2 As Double, Tara As Double, NewValorBrtCor As Double, Monto As Double, Posicion As Integer
        Dim PesoNeto As Double, PrecioNetoCor As Double, PrecioNetoDol As Double, PesoCompara As Double, addrow As String

        If Me.TDBGRidDistribucion.Columns("Monto").Text = "" Or Me.TDBGRidDistribucion.Columns("Monto").Text = " " Then
            Me.TDBGRidDistribucion.Columns("Monto").Text = 0.0
        End If
        If addrow <> "NoRow" Then
            addrow = ""
            If Me.TDBGRidDistribucion.Col = 0 Then
                'Posicion = Me.BinDistribucion.Position
                sql = " SELECT     IdAplicacionLiquidacionPergamino, Code, Descripcion, Activo   FROM   AplicacionLiquidacionPergamino   WHERE (Activo = 1) AND   (Descripcion = '" & Me.TDBGRidDistribucion.Columns("Concepto").Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet5, "AplicaLiquidacion")
                If DataSet5.Tables("AplicaLiquidacion").Rows.Count <> 0 Then
                    IdConcepto = DataSet5.Tables("AplicaLiquidacion").Rows(0)("IdAplicacionLiquidacionPergamino")
                End If
                If IdConcepto = 724 Then
                    'Posicion = Me.TDBGRidDistribucion.Row
                    'SumaAbono = 0
                    'count = Me.TDBGRidDistribucion.RowCount
                    'i = 0
                    'Do While count > i
                    '    If Not IsDBNull(Me.TDBGRidDistribucion.Item(i)("Concepto")) Then
                    '        ConceptoReco = Me.TDBGRidDistribucion.Item(i)("Concepto")
                    '        If ConceptoReco = "Abono" Then
                    '            SumaAbono = Me.TDBGRidDistribucion.Item(i)("Monto") + SumaAbono
                    '        End If
                    '    End If
                    '    i = i + 1
                    'Loop
                    'Me.TDBGRidDistribucion.Columns("Monto").Text = CDbl(Me.TxtTotalDol.Text) - SumaAbono
                    CalculoMontoDistribucion()
                    Me.TDBGRidDistribucion.AllowAddNew = False
                    Me.TDBGRidDistribucion.Splits(0).DisplayColumns("Monto").Locked = True
                    Me.TDBGRidDistribucion.Splits(0).DisplayColumns("FechaPago").Locked = True
                ElseIf IdConcepto = 725 Then
                    Me.TDBGRidDistribucion.Columns("Monto").Text = 0.0
                    addrow = "NoRow"
                    Me.TDBGRidDistribucion.AllowAddNew = True
                    Me.TDBGRidDistribucion.Splits(0).DisplayColumns("Monto").Locked = False
                    Me.TDBGRidDistribucion.Splits(0).DisplayColumns("FechaPago").Locked = True
                End If
            End If
        End If
        Me.TDBGRidDistribucion.Columns("FechaPago").Text = Me.DTPFecha.Text
        Me.TDBGRidDistribucion.Columns("TipoPago").Text = "Efectivo"
        If Me.TDBGRidDistribucion.Col = 3 Then
            If Me.TDBGRidDistribucion.Columns("NumeroSolicitud").Text = "" Then
                If Me.TDBGRidDistribucion.Columns("Concepto").Text = "Abono" Then
                    MsgBox("Se Necesita Numero Solicitud", MsgBoxStyle.Exclamation, "Liquidacion")
                    Me.TDBGRidDistribucion.Columns("Monto").Text = 0.0
                End If
            End If
        End If


    End Sub
    Public Sub CalculoMontoDistribucion()
        Dim Posicion As Integer, count As Integer, ConceptoReco As String, i As Integer

        Posicion = Me.TDBGRidDistribucion.Row
        SumaAbono = 0
        count = Me.TDBGRidDistribucion.RowCount
        i = 0
        Do While count > i
            If Not IsDBNull(Me.TDBGRidDistribucion.Item(i)("Concepto")) Then
                ConceptoReco = Me.TDBGRidDistribucion.Item(i)("Concepto")
                If ConceptoReco = "Abono" Then
                    SumaAbono = Me.TDBGRidDistribucion.Item(i)("Monto") + SumaAbono
                End If
            End If
            i = i + 1
        Loop
        Me.TDBGRidDistribucion.Columns("Monto").Text = CDbl(Me.TxtTotalDol.Text) - SumaAbono
    End Sub
    Private Sub TxtTotalDol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTotalDol.TextChanged
        If Quien3 = "Recibo" Then
            Quien3 = ""
            Exit Sub
        End If
        If IdTipoCompra = 108 Or IdTipoCompra = 109 Then
            If Me.TDBGRidDistribucion.Columns("Concepto").Text <> "" Then
                If Me.TDBGRidDistribucion.Columns("TipoPago").Text <> "" Then
                    Me.TDBGRidDistribucion.Columns("Monto").Text = CDbl(Me.TxtTotalDol.Text)
                End If
            End If
        End If
        sumagriddistribucion()
    End Sub
    Private Sub CheckTodosRecibos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTodosRecibos.CheckedChanged
        Dim contador As Integer = 0, i As Integer = 0
        contador = Me.TDGridDetalleRecibos.RowCount
        Do While contador > i
            Me.TDGridDetalleRecibos.Row = i
            If CheckTodosRecibos.Checked = True Then
                Me.TDGridDetalleRecibos.Item(i)("Aplicar") = True
            Else
                Me.TDGridDetalleRecibos.Item(i)("Aplicar") = False
            End If
            i = i + 1
        Loop
        SumaGrid1()
    End Sub

    Private Sub TDGridDetalleRecibos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridDetalleRecibos.Click

    End Sub

    Private Sub TDBGRidDistribucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDBGRidDistribucion.Click

    End Sub

    Private Sub LblMontoComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblMontoComp.Click

    End Sub

    Private Sub LblMontoComp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblMontoComp.TextChanged



    End Sub

    Private Sub BtnBorrarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrarLinea.Click
        Dim Resultado As String, Posicion As Integer, tipo As String
        Dim IdDistribucion As String, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlDelete As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        Resultado = MsgBox("¿Esta Seguro de Eliminar la fila?", MsgBoxStyle.YesNo, "Sistema de Facturacion")
        If Resultado <> 6 Then
            Exit Sub
        End If
        Posicion = Me.TDBGRidDistribucion.Row
        IdDistribucion = Me.TDBGRidDistribucion.Columns("IdDetalleDistribucion").Text

        Sql = "SELECT    IdDetalleDistribucion, IdLiquidacionPergamino, IdAplicacionLiquidacionPergamino, IdTipoPago, FechaPago, Monto FROM            DetalleDistribucion WHERE        (IdDetalleDistribucion = '" & IdDistribucion & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "BorraDistribuciones")



        If Me.TDBGRidDistribucion.RowCount > 0 Then
            '///////////SI NO  EXISTE REGISTROS LOS ELIMINO EL GRID////////////////

            '///////////SI EXISTE REGISTROS LOS ELIMINO DE LA BASE DATOS////////////////
            MiConexion.Close()
            StrSqlDelete = "DELETE FROM [dbo].[DetalleDistribucion]  WHERE (IdDetalleDistribucion = '" & IdDistribucion & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlDelete, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            If Me.TDBGRidDistribucion.RowCount > 1 Then
                tipo = Me.TDBGRidDistribucion.Item(Posicion)("Concepto")
                Me.TDBGRidDistribucion.Delete(Posicion)
                Me.TDBGRidDistribucion.AllowAddNew = True
            Else
                MsgBox("No puede borrar esta linea", MsgBoxStyle.Critical, "Liquidacion")
                Exit Sub
            End If
        Else
            MsgBox("no hay filas que borrar", MsgBoxStyle.Critical, "Liquidacion")
            Exit Sub
            'ActualizaGriDistribucion()
        End If

        If tipo <> "Efectivo" Then
            CalculoMontoDistribucion()
            Me.TDBGRidDistribucion.AllowAddNew = False
        End If
        sumagriddistribucion()
    End Sub
    Public Sub ActualizaGriDistribucion()
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = "", SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item1 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim oDatarow As DataRow, Count As Double, i As Integer
        Dim Fecha As Date, IdlocalidadRec As Double, PesoNeto As Double, Precio1 As Double, Precio As Double
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, EsPorcentaje As Boolean, IdLocalidad As Integer, DeduccionDano As Double, DD As Double
        Dim DeducEstado As Double, Descripcion As String, PesoRestante As Double, EstadoLiquidado As Boolean, Parcial As Boolean
        Dim Saldo As Double, Monto As Double, TotalSaldo As Double, TotalMonto As Double, IdRecibo As Integer


        sql = "SELECT  AplicacionLiquidacionPergamino.Descripcion AS Concepto, TipoPago.Descripcion AS TipoPago, DetalleDistribucion.NumeroAvio AS NumeroSolicitud, DetalleDistribucion.Monto AS Monto,  DetalleDistribucion.FechaPago AS FechaPago, DetalleDistribucion.IdDetalleDistribucion   FROM    DetalleDistribucion INNER JOIN   AplicacionLiquidacionPergamino ON DetalleDistribucion.IdAplicacionLiquidacionPergamino = AplicacionLiquidacionPergamino.IdAplicacionLiquidacionPergamino INNER JOIN  TipoPago ON DetalleDistribucion.IdTipoPago = TipoPago.IdTipoPago INNER JOIN LiquidacionPergamino ON DetalleDistribucion.IdLiquidacionPergamino = LiquidacionPergamino.IdLiquidacionPergamino  WHERE  (LiquidacionPergamino.IdLiquidacionPergamino = '" & Me.TxtIdLiquidacion.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "DistrbLiquida")
        Me.TDBGRidDistribucion.DataSource = DataSet.Tables("DistrbLiquida")
        'count = DataSet.Tables("DistrbLiquida").Rows.Count

        Count = 0
        i = 0
        SqlString = "SELECT Descripcion   FROM    AplicacionLiquidacionPergamino"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "AplicacionLiquid")
        Count = DataSet.Tables("AplicacionLiquid").Rows.Count

        Me.TDBGRidDistribucion.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
        With Me.TDBGRidDistribucion.Columns(0).ValueItems.Values
            Do While Count > i
                If i = 0 Then
                    Descripcion = DataSet.Tables("AplicacionLiquid").Rows(i)("Descripcion")
                    item1.Value = Descripcion
                    .Add(item1)
                Else
                    Descripcion = DataSet.Tables("AplicacionLiquid").Rows(i)("Descripcion")
                    item1 = New C1.Win.C1TrueDBGrid.ValueItem()
                    item1.Value = Descripcion
                    .Add(item1)
                End If
                i = i + 1
            Loop
        End With
        Count = 0
        i = 0
        SqlString = "SELECT   Descripcion   FROM TipoPago WHERE  (Activo = 1) "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoPago")
        Count = DataSet.Tables("TipoPago").Rows.Count
        '____________________________________________________
        'LLENE LOS COMBOBOX(0) DEL GRID DE DISTRBUCION 
        '____________________________________________________
        Me.TDBGRidDistribucion.Columns(1).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
        With Me.TDBGRidDistribucion.Columns(1).ValueItems.Values
            Do While Count > i
                If i = 0 Then
                    Descripcion = DataSet.Tables("TipoPago").Rows(i)("Descripcion")
                    item2.Value = Descripcion
                    .Add(item2)
                Else
                    Descripcion = DataSet.Tables("TipoPago").Rows(i)("Descripcion")
                    item2 = New C1.Win.C1TrueDBGrid.ValueItem()
                    item2.Value = Descripcion
                    .Add(item2)
                End If
                i = i + 1
            Loop
        End With


        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).Width = 160
        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).Width = 160
        Me.TDBGRidDistribucion.Columns(2).EditMask = "#-##-#####"
        Me.TDBGRidDistribucion.Columns(2).EditMaskUpdate = True

        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).Locked = False

        Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(5).Visible = False
        sumagriddistribucion()


    End Sub

    Private Sub TxtValorBrutoCor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtValorBrutoCor.Click

    End Sub

    Private Sub TxtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub TxtCodigoCompleto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoCompleto.TextChanged

    End Sub

    Private Sub Eventos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eventos.Enter

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Quien = "Proveedor"
        'My.Forms.FrmConsultasLiqui.ShowDialog()
        'Me.CboCodigoProveedor.Text = My.Forms.FrmConsultasLiqui.Codigo
        ''Me.TxtIdLiquidacion.Text = My.Forms.FrmConsultasLiqui.Codigo1
        Quien = "CodigoProveedorLiquidacion"
        My.Forms.FrmConsultas.Text = "Consulta Proveedor"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA PROVEEDOR"
        My.Forms.FrmConsultas.IdCosecha = IdCosecha
        My.Forms.FrmConsultas.ShowDialog()
        If FrmConsultas.Codigo <> "" Then
            Me.Cedula = My.Forms.FrmConsultas.Cedula
            Me.TxtCedula.Text = My.Forms.FrmConsultas.Cedula
            Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
            Me.txtnombre.Text = My.Forms.FrmConsultas.Descripcion
        End If
    End Sub
End Class

