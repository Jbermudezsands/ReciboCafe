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


        SqlString = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (IdLugarAcopio = -1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidades")
        Me.CboLocalidad.DataSource = DataSet.Tables("Localidades")
        Me.CboLocalidad.Splits(0).DisplayColumns(1).Width = 400

        SqlString = "SELECT IdRegion, Nombre, NombreCorto FROM Region "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Region")
        If DataSet.Tables("Region").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        End If

        Me.CboRegion.DataSource = DataSet.Tables("Region")
        Me.CboRegion.Splits(0).DisplayColumns(1).Width = 400


        Sql = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, EmpresaTransporte.IdEmpresaTransporte FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN  ContratoTransporte ON EmpresaTransporte.IdEmpresaTransporte = ContratoTransporte.IdEmpresaTransporte ORDER BY Codigo"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            Me.CboEmpresaTrans.DataSource = DataSet.Tables("Conductor")
            Me.CboEmpresaTrans.Columns(0).Caption = "Cod"
            Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns(0).Width = 50
            Me.CboEmpresaTrans.Columns(1).Caption = "Empresa"
            Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns(1).Width = 200
            Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns(2).Visible = False
        End If

        Me.CboModalidad.Text = "PERGAMINO"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim oDataRow As DataRow, SqlString As String, Filtro As String, i As Double, Cont As Double
        Dim ArepMermaRecepcion As New ArepMermaRecibo, RutaLogo As String
        Dim DvRecepcion As DataView


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
        SqlString = "SELECT Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre As TipoCompra,  TipoCafe.Nombre As TipoCafe, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS MontoPagado, DetalleReciboCafePergamino.PesoBruto, Region.Nombre AS Tipo, DetalleDistribucion.Monto  AS Merma FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino RIGHT OUTER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Region.Nombre = '000000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recepcion")

        'SqlString = "SELECT Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre As TipoCompra, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS Merma, DetalleReciboCafePergamino.PesoBruto FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino RIGHT OUTER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Region.Nombre = '000000')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Remision")

        'SqlString = "SELECT Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre As TipoCompra, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS MontoPagado, DetalleReciboCafePergamino.PesoBruto FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino RIGHT OUTER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino WHERE (Region.Nombre = '000000')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Bodega")


        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '++++++++++++++++++++++++++++++++CREO UNA CONSULTA CON LOS FILTROS ++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        If Me.IdLugarAcopio = 0 Then

            'SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, ReciboCafePergamino.Codigo, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END AS MontoPagado, UnidadMedida.Descripcion, ReciboCafePergamino.Fecha FROM UnidadMedida INNER JOIN  ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida LEFT OUTER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino " & _
            '            "WHERE  (Calidad.IdCalidad = " & Me.IdCalidad & ") AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102))"

            SqlString = "SELECT  MAX(Region.Nombre) AS Region, MAX(LugarAcopio.NomLugarAcopio) AS Localidad, MAX(Calidad.NomCalidad) AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, MAX(TipoCafe.Nombre) AS TipoCafe, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, SUM(CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END) AS MontoPagado, MAX(UnidadMedida.Descripcion) AS Descripcion, SUM(CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END) AS MermaRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoBruto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto2 END) AS PesoBrutoRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END) AS PesoNetoRemision, SUM(CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END) AS TaraRemision, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, TipoCompra.Nombre AS TipoCompra  FROM  TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON  TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino LEFT OUTER JOIN  LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino " & _
                        "WHERE  (Calidad.IdCalidad = " & Me.IdCalidad & ") AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) GROUP BY TipoCompra.Nombre, EstadoFisico.Descripcion"
        Else
            SqlString = "SELECT  MAX(Region.Nombre) AS Region, MAX(LugarAcopio.NomLugarAcopio) AS Localidad, MAX(Calidad.NomCalidad) AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, MAX(TipoCafe.Nombre) AS TipoCafe, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, SUM(CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END) AS MontoPagado, MAX(UnidadMedida.Descripcion) AS Descripcion, SUM(CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END) AS MermaRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoBruto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto2 END) AS PesoBrutoRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END) AS PesoNetoRemision, SUM(CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END) AS TaraRemision, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, TipoCompra.Nombre AS TipoCompra  FROM  TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON  TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino LEFT OUTER JOIN  LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino " & _
                        "WHERE  (LugarAcopio.IdLugarAcopio = " & Me.IdLugarAcopio & ") AND (Calidad.IdCalidad = " & Me.IdCalidad & ") AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) GROUP BY TipoCompra.Nombre, EstadoFisico.Descripcion"
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
            oDataRow("Merma") = 0
            oDataRow("TipoCafe") = DataSet.Tables("Registros").Rows(i)("TipoCafe")
            oDataRow("Tipo") = "Recepcion1"
            DataSet.Tables("Recepcion").Rows.Add(oDataRow)

            oDataRow = DataSet.Tables("Recepcion").NewRow
            oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
            oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
            oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
            oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
            oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
            oDataRow("PesoBruto") = DataSet.Tables("Registros").Rows(i)("PesoBrutoRemision")
            oDataRow("PesoNeto") = DataSet.Tables("Registros").Rows(i)("PesoNetoRemision")
            oDataRow("Merma") = DataSet.Tables("Registros").Rows(i)("MermaRemision")
            oDataRow("TipoCafe") = DataSet.Tables("Registros").Rows(i)("TipoCafe")
            oDataRow("Tipo") = "Recepcion2"
            DataSet.Tables("Recepcion").Rows.Add(oDataRow)

            If DataSet.Tables("Registros").Rows(i)("PesoBruto") - DataSet.Tables("Registros").Rows(i)("PesoBrutoRemision") > 0 Then

                oDataRow = DataSet.Tables("Recepcion").NewRow
                oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
                oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
                oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
                oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
                oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
                oDataRow("PesoBruto") = DataSet.Tables("Registros").Rows(i)("PesoBruto") - DataSet.Tables("Registros").Rows(i)("PesoBrutoRemision")
                oDataRow("PesoNeto") = DataSet.Tables("Registros").Rows(i)("PesoNeto") - DataSet.Tables("Registros").Rows(i)("PesoNetoRemision")
                oDataRow("Tipo") = "Recepcion3"
                oDataRow("TipoCafe") = DataSet.Tables("Registros").Rows(i)("TipoCafe")
                oDataRow("Merma") = 0
                DataSet.Tables("Recepcion").Rows.Add(oDataRow)

            End If




            i = i + 1
            Me.ProgressBar1.Value = i
            Me.Text = "Procesando " & i & " de " & Cont
            My.Application.DoEvents()
        Loop

        SqlString = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            ArepMermaRecepcion.LblCompañia.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepMermaRecepcion.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If
        End If

        DataSet.Tables("DatosEmpresa").Reset()

        Dim ViewerForm As New FrmViewer()

        DvRecepcion = New DataView(DataSet.Tables("Recepcion"))
        DvRecepcion.Sort = "Tipo"

        ViewerForm.arvMain.Document = ArepMermaRecepcion.Document
        ArepMermaRecepcion.DataSource = DvRecepcion
        ArepMermaRecepcion.Run(False)
        ViewerForm.Show()
        My.Application.DoEvents()

        Me.DataSet.Tables("Registros").Reset()
        DataSet.Tables("Recepcion").Reset()



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

    Private Sub CboEmpresaTrans_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmpresaTrans.TextChanged
        Dim SqlString As String, texto As String, IdEmpresaTransporte As Double
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        IdEmpresaTransporte = Me.CboEmpresaTrans.Columns(2).Text


        '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT Vehiculo.IdVehiculo,Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo  " & _
                    "WHERE (EmpresaTransporte.NombreEmpresa = '" & Me.CboEmpresaTrans.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Placa")
        Me.CboEmprsPlaca.DataSource = Dataset.Tables("Placa")
        Me.CboEmprsPlaca.Splits.Item(0).DisplayColumns(0).Width = 30
        Me.CboEmprsPlaca.Splits.Item(0).DisplayColumns(1).Width = 150
        texto = Me.CboEmprsPlaca.Text
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Quien = "EmpresaTransporteReporte"
        'My.Forms.FrmConsultas.IdCosecha = Me.TextIdCosecha.Text
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboEmpresaTrans.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub BtnImprimirMermaPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirMermaPI.Click
        Dim ArepReporteRemision As New ArepReporteRemision
        Dim Filtro As String, SqlString As String, RutaLogo As String
        Dim IdTransporte As Double, IdVehiculo As Double, IdTipoCafe As Double, IdCalidad As Double
        Dim DvRecepcion As DataView
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource

        Filtro = "WHERE  (RemisionPergamino.FechaCarga BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102))"

        '///////////////////////////////////////////////LUGAR ACOPIO ///////////////////////////////////////////////////////
        SqlString = "SELECT IdLugarAcopio, CodLugarAcopio, NomLugarAcopio  FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaLocalidad")
        If DataSet.Tables("BuscaLocalidad").Rows.Count <> 0 Then
            Me.IdLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("IdLugarAcopio")
        Else
            Me.IdLugarAcopio = 0
        End If
        DataSet.Tables("BuscaLocalidad").Reset()
        If IdLugarAcopio <> 0 Then
            Filtro = Filtro & " AND (RemisionPergamino.IdLugarAcopio = " & Me.IdLugarAcopio & ")"
        End If

        '//////////////////////////////////////MODALIDAD DEL CAFE O TIPO DE CAFE //////////////////////////////////////////
        SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.CboModalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaTipoCafe")
        If DataSet.Tables("BuscaTipoCafe").Rows.Count <> 0 Then
            IdTipoCafe = DataSet.Tables("BuscaTipoCafe").Rows(0)("IdTipoCafe")
        Else
            IdTipoCafe = 0
        End If
        DataSet.Tables("BuscaTipoCafe").Reset()
        If IdTipoCafe <> 0 Then
            Filtro = Filtro & " AND (TipoCafe.IdTipoCafe = " & IdTipoCafe & ")"
        End If


        '//////////////////////////////////////CALIDAD DEL CAFE //////////////////////////////////////////
        SqlString = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion  FROM calidad  WHERE (NomCalidad = '" & Me.CboCalidadRL.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaCalidad")
        If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
            IdCalidad = DataSet.Tables("BuscaCalidad").Rows(0)("IdCalidad")
        Else
            IdCalidad = 0
        End If
        DataSet.Tables("BuscaCalidad").Reset()
        If IdTipoCafe <> 0 Then
            Filtro = Filtro & " AND (Calidad.IdCalidad = " & IdCalidad & ")"
        End If

        'SqlString = "SELECT IdEmpresaTransporte, Codigo, NombreEmpresa, CedulaEmpresa, NombreRepresentante, CedulaRepresentante, Direccion, Telefono, IdTipoPersoneria, Activo, IdTipoEmpresaTransporte, IdUsuario, IdCompany, FechaActualizacion FROM EmpresaTransporte WHERE   (NombreEmpresa = '" & Me.CboEmpresaTrans.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "BuscaEmpresaTransporte")
        'If DataSet.Tables("BuscaEmpresaTransporte").Rows.Count <> 0 Then
        '    IdTransporte = DataSet.Tables("BuscaEmpresaTransporte").Rows(0)("IdEmpresaTransporte")
        'Else
        '    IdTransporte = 0
        'End If
        'DataSet.Tables("BuscaEmpresaTransporte").Reset()
        'If IdTransporte <> 0 Then
        '    Filtro = Filtro & " AND (RemisionPergamino.IdEmpresaTransporte = " & IdTransporte & ")"
        'End If

        'SqlString = "SELECT IdVehiculo, Placa, IdMarca, IdTipoVehiculo, IdUsuario, IdCompany, Posicion, FechaActualizacion FROM Vehiculo WHERE   (Placa = '065 - 207')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "BuscaVehiculo")
        'If DataSet.Tables("BuscaVehiculo").Rows.Count <> 0 Then
        '    IdVehiculo = DataSet.Tables("BuscaVehiculo").Rows(0)("IdVehiculo")
        'Else
        '    IdVehiculo = 0
        'End If
        'DataSet.Tables("BuscaVehiculo").Reset()
        'If IdVehiculo <> 0 Then
        '    Filtro = Filtro & " AND (Vehiculo.IdVehiculo = " & IdVehiculo & ")"
        'End If

        Filtro = Filtro & " ORDER BY ReciboCafePergamino.Codigo"




        SqlString = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")

        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            ArepReporteRemision.LblCompañia.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepReporteRemision.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If
        End If

        DataSet.Tables("DatosEmpresa").Reset()

        SqlString = "SELECT  DetalleRemisionPergamino.Codigo AS Rango, DetalleReciboCafePergamino.Imperfeccion, Dano.Nombre AS Daño, EstadoFisico.Descripcion AS EstadoFisico, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, ReciboCafePergamino.Codigo, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, DetalleReciboCafePergamino.CantidadSacos AS CantidadSacosRecibos, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNetoRecibos, RecibosRemisionPergamino.PesoNeto AS PesoAplicado, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara - RecibosRemisionPergamino.PesoNeto AS PesoPorAplicar, RemisionPergamino.IdRemisionPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino, Dano.IdDano, Finca.CodFinca, RemisionPergamino.FechaCarga, RemisionPergamino.IdLugarAcopio, RemisionPergamino.IdEmpresaTransporte, Vehiculo.Placa, (DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara) - (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS Merma, TipoCafe.Nombre, calidad.NomCalidad, calidad.IdCalidad, TipoCafe.IdTipoCafe, RemisionPergamino.Codigo AS NumeroRemision, RemisionPergamino.Numero_Boleta  FROM  DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN Vehiculo ON RemisionPergamino.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad LEFT OUTER JOIN  Intermedio ON RemisionPergamino.IdRemisionPergamino = Intermedio.IdRemisionPergamino LEFT OUTER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca  " & Filtro
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlString

        Dim ViewerForm As New FrmViewer()

        'DvRecepcion = New DataView(DataSet.Tables("Recepcion"))
        'DvRecepcion.Sort = "Tipo"

        ViewerForm.arvMain.Document = ArepReporteRemision.Document
        ArepReporteRemision.DataSource = SQL
        ArepReporteRemision.Run(False)
        ViewerForm.Show()
        My.Application.DoEvents()



    End Sub

    Private Sub CboRegion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRegion.TextChanged
        Dim IdRegion As Double

        IdRegion = Me.CboRegion.Columns(0).Text

        DataSet.Tables("Localidades").Clear()
        SqlString = "SELECT LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio FROM   LugarAcopio INNER JOIN Region ON LugarAcopio.IdPadre = Region.IdRegion  WHERE(Region.IdRegion = " & IdRegion & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidades")
        If DataSet.Tables("Localidades").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        End If

        Me.CboLocalidad.DataSource = DataSet.Tables("Localidades")
        Me.CboLocalidad.Text = DataSet.Tables("Localidades").Rows(0)("NomLugarAcopio")
        Me.CboLocalidad.Splits(0).DisplayColumns("NomLugarAcopio").Width = 400



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboModalidad.SelectedIndexChanged

    End Sub
End Class