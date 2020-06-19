Public Class FrmReportes
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    'Base de datos 
    Public DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String, Pendiente As Boolean = False, IdLugarAcopio As Double, IdCalidad As Double, IdEstadoFisico As Double, IdUnidadMedida As Double
    Public mes As String, anualidad As String, unidadmedida As String, calidad As String, Ruta As String, LeeArchivo As String, Localidad As Integer, Sql As String

    Private Sub FrmReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If

        Me.DTPFechaInicial.Text = Now
        Me.DTPFechaFinal.Text = Now

        Sql = "SELECT IdLugarAcopio FROM     LugarAcopio  WHERE   (CodLugarAcopio = " & LeeArchivo & ") AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "localidad")
        Localidad = DataSet.Tables("localidad").Rows(0)("IdLugarAcopio")

        Sql = "SELECT DISTINCT UnidadMedida.Descripcion FROM  ReciboCafePergamino INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ResumenLiquidaUnidad")
        Me.CboUnidadRL.DisplayMember = "Descripcion"
        If DataSet.Tables("ResumenLiquidaUnidad").Rows.Count = 0 Then
            'MsgBox("NO SE ENCONTRARON UNIDADES DE MEDIDA", MsgBoxStyle.Critical, "LiquidacionResumen")
        Else
            Me.CboUnidadRL.DataSource = DataSet.Tables("ResumenLiquidaUnidad")
            Me.CboUnidadRL.Text = DataSet.Tables("ResumenLiquidaUnidad").Rows(0)("Descripcion")
            Me.CboUnidadRL.Splits.Item(0).DisplayColumns(0).Width = 100
        End If

        Sql = "SELECT DISTINCT Calidad.NomCalidad FROM    Calidad INNER JOIN  ReciboCafePergamino ON Calidad.IdCalidad = ReciboCafePergamino.IdCalidad "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ResumenLiquidaCalidad")
        Me.CboCalidadRL.DisplayMember = "NomCalidad"
        If DataSet.Tables("ResumenLiquidaCalidad").Rows.Count = 0 Then

        Else
            Me.CboCalidadRL.DataSource = DataSet.Tables("ResumenLiquidaCalidad")
            Me.CboCalidadRL.Text = DataSet.Tables("ResumenLiquidaCalidad").Rows(0)("NomCalidad")
        End If

        SqlString = "SELECT DISTINCT Descripcion  FROM EstadoFisico ORDER BY Descripcion"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Fisico")
        Me.CboEstado.DataSource = DataSet.Tables("Fisico")


        SqlString = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidades")
        If DataSet.Tables("Localidades").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        End If

        Me.CboLocalidad.DataSource = DataSet.Tables("Localidades")
        Me.CboLocalidad.Splits(0).DisplayColumns(1).Width = 400

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim oDataRow As DataRow, SqlString As String, Filtro As String, i As Double, Cont As Double
        Dim ArepMermaRecepcion As New ArepMermaRecibo


        SqlString = "SELECT EstadoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto, IdEdoFisico FROM EstadoFisico WHERE (Descripcion = '" & Me.CboEstado.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaFisico")
        If DataSet.Tables("BuscaFisico").Rows.Count <> 0 Then
            Me.IdEstadoFisico = DataSet.Tables("BuscaFisico").Rows(0)("EstadoFisico")
        Else
            Me.IdEstadoFisico = 0
        End If
        DataSet.Tables("BuscaFisico").Reset()

        SqlString = "SELECT  IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion FROM calidad WHERE  (NomCalidad = '" & Me.CboCalidadRL.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaCalidad")
        If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
            Me.IdCalidad = DataSet.Tables("BuscaCalidad").Rows(0)("IdCalidad")
        Else
            Me.IdCalidad = 0
        End If
        DataSet.Tables("BuscaCalidad").Reset()


        SqlString = "SELECT IdUnidadMedida, Codigo, Descripcion FROM unidadmedida WHERE  (Descripcion = '" & Me.CboUnidadRL.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaUnidadMedida")
        If DataSet.Tables("BuscaUnidadMedida").Rows.Count <> 0 Then
            Me.IdUnidadMedida = DataSet.Tables("BuscaUnidadMedida").Rows(0)("IdUnidadMedida")
        Else
            Me.IdUnidadMedida = 0
        End If
        DataSet.Tables("BuscaUnidadMedida").Reset()


        SqlString = "SELECT IdLugarAcopio, CodLugarAcopio, NomLugarAcopio  FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaLocalidad")
        If DataSet.Tables("BuscaLocalidad").Rows.Count <> 0 Then
            Me.IdLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("IdLugarAcopio")
        Else
            Me.IdLugarAcopio = 0
        End If
        DataSet.Tables("BuscaLocalidad").Reset()


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CREO UNA CONSULTA QUE NUNCA TENDRA REGISTROS //////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre As TipoCompra, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS MontoPagado, DetalleReciboCafePergamino.PesoBruto FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino RIGHT OUTER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Region.Nombre = '000000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")

        SqlString = "SELECT Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre As TipoCompra, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS Merma, DetalleReciboCafePergamino.PesoBruto FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino RIGHT OUTER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Region.Nombre = '000000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Remision")

        SqlString = "SELECT Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre As TipoCompra, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS MontoPagado, DetalleReciboCafePergamino.PesoBruto FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino RIGHT OUTER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Region.Nombre = '000000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodega")


        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '++++++++++++++++++++++++++++++++CREO UNA CONSULTA CON LOS FILTROS ++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        If Me.IdLugarAcopio = 0 Then


            'SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS MontoPagado, UnidadMedida.Descripcion, ReciboCafePergamino.Fecha FROM UnidadMedida INNER JOIN  ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida LEFT OUTER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino " & _
            '            "WHERE  (Calidad.IdCalidad = " & Me.IdCalidad & ") AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102))"

            SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre As TipoCompra, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS MontoPagado, UnidadMedida.Descripcion, ReciboCafePergamino.Fecha, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS MermaRemision, CASE WHEN DetalleRemisionPergamino.PesoBruto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto2 END AS PesoBrutoRemision, CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END AS PesoNetoRemision, CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END AS TaraRemision, DetalleReciboCafePergamino.PesoBruto FROM DetalleRemisionPergamino INNER JOIN  RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN  RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino RIGHT OUTER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN " & _
                        "DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON  RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino LEFT OUTER JOIN LiquidacionPergamino INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino  " & _
                        "WHERE  (Calidad.IdCalidad = " & Me.IdCalidad & ") AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102))"
        Else
            SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre As TipoCompra, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS MontoPagado, UnidadMedida.Descripcion, ReciboCafePergamino.Fecha, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS MermaRemision, CASE WHEN DetalleRemisionPergamino.PesoBruto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto2 END AS PesoBrutoRemision, CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END AS PesoNetoRemision, CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END AS TaraRemision, DetalleReciboCafePergamino.PesoBruto FROM DetalleRemisionPergamino INNER JOIN  RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN  RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino RIGHT OUTER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN " & _
                      "DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON  RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino LEFT OUTER JOIN LiquidacionPergamino INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino  " & _
                      "WHERE  (LugarAcopio.IdLugarAcopio = " & Me.IdLugarAcopio & ") AND (Calidad.IdCalidad = " & Me.IdCalidad & ") AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102))"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Registros")

        Cont = DataSet.Tables("Registros").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Cont
        Me.ProgressBar1.Value = 0

        If Cont = 0 Then
            MsgBox("No Existen Registros para este Filtro", MsgBoxStyle.Information, "Sistema Bascula")
            Exit Sub
        End If

        Do While Cont > i
            oDataRow = DataSet.Tables("Recepcion").NewRow
            oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
            oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
            oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
            oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
            oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
            oDataRow("PesoBruto") = DataSet.Tables("Registros").Rows(i)("PesoBruto")
            oDataRow("PesoNeto") = DataSet.Tables("Registros").Rows(i)("PesoNeto")
            oDataRow("MontoPagado") = DataSet.Tables("Registros").Rows(i)("MontoPagado")
            DataSet.Tables("Recepcion").Rows.Add(oDataRow)

            oDataRow = DataSet.Tables("Remision").NewRow
            oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
            oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
            oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
            oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
            oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
            oDataRow("PesoBruto") = DataSet.Tables("Registros").Rows(i)("PesoBrutoRemision")
            oDataRow("PesoNeto") = DataSet.Tables("Registros").Rows(i)("PesoNetoRemision")
            oDataRow("Merma") = DataSet.Tables("Registros").Rows(i)("MermaRemision")
            DataSet.Tables("Remision").Rows.Add(oDataRow)

            If DataSet.Tables("Registros").Rows(i)("PesoBruto") - DataSet.Tables("Registros").Rows(i)("PesoBrutoRemision") > 0 Then

                oDataRow = DataSet.Tables("Bodega").NewRow
                oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
                oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
                oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
                oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
                oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
                oDataRow("PesoBruto") = DataSet.Tables("Registros").Rows(i)("PesoBruto") - DataSet.Tables("Registros").Rows(i)("PesoBrutoRemision")
                oDataRow("PesoNeto") = DataSet.Tables("Registros").Rows(i)("PesoNeto") - DataSet.Tables("Registros").Rows(i)("PesoNetoRemision")
                DataSet.Tables("Bodega").Rows.Add(oDataRow)

            End If




            i = i + 1
            Me.ProgressBar1.Value = i
            Me.Text = "Procesando " & i & " de " & Cont
            My.Application.DoEvents()
        Loop

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepMermaRecepcion.Document
        ArepMermaRecepcion.Run(False)
        ViewerForm.Show()
        My.Application.DoEvents()



    End Sub

    Private Sub CboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEstado.SelectedIndexChanged
        'SqlString = "SELECT EstadoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto, IdEdoFisico FROM EstadoFisico WHERE (Descripcion = '" & Me.CboEstado.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "BuscaFisico")
        'If DataSet.Tables("BuscaFisico").Rows.Count <> 0 Then
        '    Me.IdEstadoFisico = DataSet.Tables("BuscaFisico").Rows(0)("EstadoFisico")
        'Else
        '    Me.IdEstadoFisico = 0
        'End If
        'DataSet.Tables("BuscaFisico").Reset()

    End Sub

    Private Sub CboCalidadRL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCalidadRL.TextChanged
        'SqlString = "SELECT  IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion FROM calidad WHERE  (NomCalidad = '" & Me.CboCalidadRL.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "BuscaCalidad")
        'If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
        '    Me.IdCalidad = DataSet.Tables("BuscaCalidad").Rows(0)("IdCalidad")
        'Else
        '    Me.IdCalidad = 0
        'End If
        'DataSet.Tables("BuscaCalidad").Reset()
    End Sub

    Private Sub CboUnidadRL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboUnidadRL.TextChanged
        'SqlString = "SELECT IdUnidadMedida, Codigo, Descripcion FROM unidadmedida WHERE  (Descripcion = '" & Me.CboUnidadRL.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "BuscaUnidadMedida")
        'If DataSet.Tables("BuscaUnidadMedida").Rows.Count <> 0 Then
        '    Me.IdUnidadMedida = DataSet.Tables("BuscaUnidadMedida").Rows(0)("IdUnidadMedida")
        'Else
        '    Me.IdUnidadMedida = 0
        'End If
        'DataSet.Tables("BuscaUnidadMedida").Reset()
    End Sub

    Private Sub CboLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLocalidad.TextChanged
        'SqlString = "SELECT IdLugarAcopio, CodLugarAcopio, NomLugarAcopio  FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "BuscaLocalidad")
        'If DataSet.Tables("BuscaLocalidad").Rows.Count <> 0 Then
        '    Me.IdLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("IdLugarAcopio")
        'Else
        '    Me.IdLugarAcopio = 0
        'End If
        'DataSet.Tables("BuscaLocalidad").Reset()
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
End Class