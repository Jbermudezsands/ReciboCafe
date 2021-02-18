Public Class FrmReportes
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    'Base de datos 
    Public DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String, Pendiente As Boolean = False, IdLugarAcopio As Double, IdCalidad As Double, IdEstadoFisico As Double, IdUnidadMedida As Double, IdRegion As Double
    Public mes As String, anualidad As String, unidadmedida As String, calidad As String, Ruta As String, LeeArchivo As String, Localidad As Integer, Sql As String
    Public Sub LlenadoGrid(ByVal TipoFiltro As String)
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet, CodLugarAcopio As String

        '///////////////////////////////////////////////LUGAR ACOPIO ///////////////////////////////////////////////////////
        SqlString = "SELECT IdLugarAcopio, CodLugarAcopio, NomLugarAcopio  FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaLocalidad")
        If DataSet.Tables("BuscaLocalidad").Rows.Count <> 0 Then
            Me.IdLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("IdLugarAcopio")
            CodLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("CodLugarAcopio")
        Else
            Me.IdLugarAcopio = 0
        End If
        DataSet.Tables("BuscaLocalidad").Reset()

        If TipoFiltro = "Todo" Then
            SqlString = "SELECT DISTINCT LiquidacionPergamino.NumeroReportado, LiquidacionPergamino.FechaReportado, LugarAcopio.NomLugarAcopio FROM LiquidacionPergamino INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio WHERE(Not (LiquidacionPergamino.NumeroReportado Is NULL))"
        ElseIf TipoFiltro = "Fecha" Then
            SqlString = "SELECT DISTINCT LiquidacionPergamino.NumeroReportado, LiquidacionPergamino.FechaReportado, LugarAcopio.NomLugarAcopio FROM LiquidacionPergamino INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio WHERE (NOT (LiquidacionPergamino.NumeroReportado IS NULL)) AND (LiquidacionPergamino.FechaReportado BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
        ElseIf TipoFiltro = "Lugar" Then
            SqlString = "SELECT DISTINCT LiquidacionPergamino.NumeroReportado, LiquidacionPergamino.FechaReportado, LugarAcopio.NomLugarAcopio FROM LiquidacionPergamino INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio WHERE (NOT (LiquidacionPergamino.NumeroReportado IS NULL)) AND (LugarAcopio.IdLugarAcopio BETWEEN '" & IdLugarAcopio & "' AND '" & IdLugarAcopio & "') AND (LiquidacionPergamino.FechaReportado BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "

        End If

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        Me.TDGridResumenLiquidacion.DataSource = DataSet.Tables("Consulta")
        Me.TDGridResumenLiquidacion.Location = New Point(446, 8)
        Me.TDGridResumenLiquidacion.Visible = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("NumeroReportado").Width = 100
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("NumeroReportado").Locked = True
        Me.TDGridResumenLiquidacion.Columns("NumeroReportado").Caption = "Proceso"

        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("FechaReportado").Width = 80
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("FechaReportado").Locked = True
        Me.TDGridResumenLiquidacion.Columns("FechaReportado").Caption = "Fecha"

        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("NomLugarAcopio").Width = 150
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("NomLugarAcopio").Locked = True
        Me.TDGridResumenLiquidacion.Columns("NomLugarAcopio").Caption = "Lugar Acopio"

        Me.BtnReimprimir.Visible = True
        Me.BtnReimprimir.Location = New Point(875, 16)

        Me.TDGridResumenLiquidacion.RowHeight = 20


    End Sub



    Public Sub ListadoLiquidacion()
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataSet As New DataSet, Cont As Double, CodLugarAcopio As String
        Dim i As Double = 0

        Me.BtnProcesar.Enabled = False
        Me.BtnPrevio.Enabled = False

        '///////////////////////////////////////////////LUGAR ACOPIO ///////////////////////////////////////////////////////
        SqlString = "SELECT IdLugarAcopio, CodLugarAcopio, NomLugarAcopio  FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaLocalidad")
        If DataSet.Tables("BuscaLocalidad").Rows.Count <> 0 Then
            Me.IdLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("IdLugarAcopio")
            CodLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("CodLugarAcopio")
        Else
            Me.IdLugarAcopio = 0
        End If
        DataSet.Tables("BuscaLocalidad").Reset()


        'SqlString = "SELECT  LiquidacionPergamino.IdLiquidacionPergamino, LiquidacionPergamino.Codigo, LiquidacionPergamino.Fecha, LiquidacionPergamino.Precio, DetalleDistribucion.Monto, DetalleLiquidacionPergamino.PesoNeto, CASE WHEN LiquidacionPergamino.ReportadoDistribucion IS NULL THEN 0 ELSE LiquidacionPergamino.ReportadoDistribucion END AS ReportadoDistribucion, LiquidacionPergamino.IdLocalidad FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino  " & _
        '    "WHERE (CASE WHEN LiquidacionPergamino.ReportadoDistribucion IS NULL THEN 0 ELSE LiquidacionPergamino.ReportadoDistribucion END = 0) AND (LiquidacionPergamino.IdLocalidad = " & Me.IdLugarAcopio & ")"
        SqlString = "SELECT LiquidacionPergamino.IdLiquidacionPergamino, LiquidacionPergamino.Codigo, LiquidacionPergamino.Fecha, LiquidacionPergamino.Precio, (DetalleDistribucion.Monto * TipoCambio.TipoCambio) / DetalleLiquidacionPergamino.PesoNeto AS PrecioNeto, DetalleDistribucion.Monto * TipoCambio.TipoCambio AS Monto, DetalleLiquidacionPergamino.PesoNeto, CASE WHEN LiquidacionPergamino.ReportadoDistribucion IS NULL THEN 0 ELSE LiquidacionPergamino.ReportadoDistribucion END AS ReportadoDistribucion, LiquidacionPergamino.IdLocalidad, Proveedor.IdProductor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino INNER JOIN Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor  INNER JOIN TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio " & _
                    "WHERE (CASE WHEN LiquidacionPergamino.ReportadoDistribucion IS NULL THEN 0 ELSE LiquidacionPergamino.ReportadoDistribucion END = 0) AND (LiquidacionPergamino.IdLocalidad = " & Me.IdLugarAcopio & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Liquidacion")
        Cont = DataSet.Tables("Liquidacion").Rows.Count

        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Cont
        Me.ProgressBar1.Value = 0


        Me.ListBox.Items.Clear()

        Do While Cont > i

            My.Application.DoEvents()
            Me.ListBox.Items.Add("Fecha: " & DataSet.Tables("Liquidacion").Rows(i)("Fecha"))
            Me.ListBox.Items.Add("No Liquidacion:" & DataSet.Tables("Liquidacion").Rows(i)("Codigo"))
            Me.ListBox.Items.Add("Productor:" & DataSet.Tables("Liquidacion").Rows(i)("Nombres"))
            Me.ListBox.Items.Add("Precio:" & DataSet.Tables("Liquidacion").Rows(i)("PrecioNeto"))
            Me.ListBox.Items.Add("Total Pagar:" & DataSet.Tables("Liquidacion").Rows(i)("Monto"))
            Me.ListBox.Items.Add("_____________________________________________")
            Me.ListBox.Items.Add("                           ")

            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            i = i + 1
        Loop


        Me.BtnProcesar.Enabled = True
        Me.BtnPrevio.Enabled = True

    End Sub

    Private Sub FrmReportes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.ListBox.Visible = False
        Me.BtnPrevio.Visible = False
        Me.BtnFiltrar.Visible = False
        Me.ChkTodosLosProcesos.Visible = False
    End Sub


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


        SqlString = "SELECT LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio, Region.Nombre, LugarAcopio.IdLugarAcopio FROM LugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion  WHERE(LugarAcopio.IdLugarAcopio = " & Localidad & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsLocalidades")
        If DataSet.Tables("ConsLocalidades").Rows.Count <> 0 Then
            Me.CboRegion.Text = DataSet.Tables("ConsLocalidades").Rows(0)("Nombre")
            Me.CboLocalidad.Text = DataSet.Tables("ConsLocalidades").Rows(0)("NomLugarAcopio")

        End If



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
        Dim ArepMermaRecepcion As New ArepMermaRecibo, RutaLogo As String, PesoBruto As Double, PesoNeto As Double, MontoPagado As Double, j As Double, Reg As Double
        Dim DvRecepcion As DataView, PesoBrutoRemision As Double, PesoNetoRemision As Double, Filtro1 As String, Filtro2 As String, Filtro3 As String, Filtro4 As String, Filtro5 As String, Filtro6 As String
        Dim IdLiquidacion As Double, DeduccionLiquidacion As Double = 0, IdRemision As Double, Filtro7 As String, Filtro8 As String, FechaInicial As Date
        Dim TaraRemision As Double

        SqlString = "SELECT  IdRegion, Nombre, NombreCorto FROM Region WHERE (Nombre = '" & Me.CboRegion.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaRegion")
        If DataSet.Tables("BuscaRegion").Rows.Count <> 0 Then
            Me.IdRegion = DataSet.Tables("BuscaRegion").Rows(0)("IdRegion")
        Else
            Me.IdRegion = 0
        End If
        DataSet.Tables("BuscaRegion").Reset()



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


        FechaInicial = Format(Me.DTPFechaInicial.Value, "dd/MM/yyyy") & " 00:00:00"
        FechaInicial = FechaInicial.AddDays(-3)
        If Me.ChkTodasLocalidades.Checked = True Then
            Filtro = "WHERE  (Region.IdRegion = " & Me.IdRegion & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
            Filtro1 = "WHERE  (Region.IdRegion = " & Me.IdRegion & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
            Filtro3 = "WHERE  (Region.IdRegion = " & Me.IdRegion & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha NOT BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
            Filtro5 = "WHERE  (Region.IdRegion = " & Me.IdRegion & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (RemisionPergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
            Filtro7 = "WHERE  (ReciboCafePergamino.Remisionado = 0) AND (Region.IdRegion = " & Me.IdRegion & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(FechaInicial, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
        Else
            Filtro = "WHERE  (LugarAcopio.IdLugarAcopio = " & Me.IdLugarAcopio & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
            Filtro1 = "WHERE  (LugarAcopio.IdLugarAcopio = " & Me.IdLugarAcopio & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
            Filtro3 = "WHERE  (LugarAcopio.IdLugarAcopio = " & Me.IdLugarAcopio & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha NOT BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
            Filtro5 = "WHERE  (LugarAcopio.IdLugarAcopio = " & Me.IdLugarAcopio & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (RemisionPergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "
            Filtro7 = "WHERE  (ReciboCafePergamino.Remisionado = 0) AND (LugarAcopio.IdLugarAcopio = " & Me.IdLugarAcopio & ") AND (UnidadMedida.IdUnidadMedida = " & Me.IdUnidadMedida & ") AND (ReciboCafePergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(FechaInicial, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) "

        End If

        If Me.ChkEstadoTodos.Checked = False Then
            Filtro = Filtro & " AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ")"
            Filtro1 = Filtro1 & " AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ")"
            Filtro3 = Filtro3 & " AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ")"
            Filtro5 = Filtro5 & " AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ")"
            Filtro7 = Filtro7 & " AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ")"
        End If

        If Me.ChkTodasCalidades.Checked = False Then
            Filtro = Filtro & " AND (Calidad.IdCalidad = " & Me.IdCalidad & ") "
            Filtro1 = Filtro1 & " AND (Calidad.IdCalidad = " & Me.IdCalidad & ") "
            Filtro3 = Filtro3 & " AND (Calidad.IdCalidad = " & Me.IdCalidad & ") "
            Filtro5 = Filtro5 & " AND (Calidad.IdCalidad = " & Me.IdCalidad & ") "
            Filtro7 = Filtro7 & " AND (Calidad.IdCalidad = " & Me.IdCalidad & ") "
        End If



        Filtro8 = Filtro & " GROUP BY TipoCompra.Nombre, EstadoFisico.Descripcion, Region.Nombre, LugarAcopio.NomLugarAcopio, TipoCafe.Nombre, Calidad.NomCalidad "   ' HAVING (TipoCompra.Nombre <> 'MAQUILA')
        Filtro8 = Filtro8 & "ORDER BY Localidad, TipoCafe DESC, TipoCompra"


        'SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, SUM(CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END) AS MontoPagado, MAX(UnidadMedida.Descripcion) AS Descripcion, SUM(CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END) AS MermaRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoBruto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto2 END) AS PesoBrutoRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END) AS PesoNetoRemision, SUM(CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END) AS TaraRemision, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, TipoCompra.Nombre AS TipoCompra  FROM  TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON  TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino LEFT OUTER JOIN  LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino " & Filtro

        SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, SUM(CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio - LiquidacionPergamino.TotalDeducciones END) AS MontoPagado, MAX(UnidadMedida.Descripcion) AS Descripcion, SUM(CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END) AS MermaRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoBruto IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto END) AS PesoBrutoRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END) AS PesoNetoRemision, SUM(CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END) AS TaraRemision, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, TipoCompra.Nombre AS TipoCompra  FROM  TipoCambio INNER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON TipoCambio.IdTipoCambio = LiquidacionPergamino.IdTipoCambio RIGHT OUTER JOIN TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino " & Filtro8

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


            j = 0
            Reg = 0

            If DataSet.Tables("Registros").Rows(i)("TipoCafe") <> "MAQUILA" Then
                If DataSet.Tables("Registros").Rows(i)("TipoCompra") <> "Depósito" Then
                    Filtro2 = Filtro1 & " AND (Calidad.NomCalidad = '" & DataSet.Tables("Registros").Rows(i)("Calidad") & "') AND (EstadoFisico.Descripcion = '" & DataSet.Tables("Registros").Rows(i)("EstadoFisico") & "') AND  (TipoCafe.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCafe") & "') AND (TipoCompra.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCompra") & "') AND (LiquidacionPergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102))"
                Else
                    Filtro2 = Filtro1 & " AND (Calidad.NomCalidad = '" & DataSet.Tables("Registros").Rows(i)("Calidad") & "') AND (EstadoFisico.Descripcion = '" & DataSet.Tables("Registros").Rows(i)("EstadoFisico") & "') AND  (TipoCafe.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCafe") & "') AND (TipoCompra.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCompra") & "') "
                End If

            Else
                Filtro2 = Filtro1 & " AND (Calidad.NomCalidad = '" & DataSet.Tables("Registros").Rows(i)("Calidad") & "') AND (EstadoFisico.Descripcion = '" & DataSet.Tables("Registros").Rows(i)("EstadoFisico") & "') AND  (TipoCafe.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCafe") & "') AND (TipoCompra.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCompra") & "') "
            End If
            '

            '/////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////BUSCO LOS TOTALES DEL GRUPO //////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT DISTINCT RemisionPergamino.IdRemisionPergamino, Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE (DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio) END AS MontoPagado, UnidadMedida.Descripcion, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS MermaRemision, CASE WHEN DetalleRemisionPergamino.PesoBruto IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto END AS PesoBrutoRemision, CASE WHEN RecibosRemisionPergamino.PesoNeto IS NULL THEN 0 ELSE RecibosRemisionPergamino.PesoNeto END AS PesoNetoRemision, CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END AS TaraRemision, DetalleReciboCafePergamino.PesoBruto, TipoCompra.Nombre AS TipoCompra,  ReciboCafePergamino.Codigo,  LiquidacionPergamino.Codigo as CodigoLiquidacion, LiquidacionPergamino.IdLiquidacionPergamino, LiquidacionPergamino.TotalDeducciones, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE (DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio) - LiquidacionPergamino.TotalDeducciones END AS MontoTotal, LiquidacionPergamino.Fecha FROM TipoCambio INNER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON  TipoCambio.IdTipoCambio = LiquidacionPergamino.IdTipoCambio RIGHT OUTER JOIN TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN  DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino  " & Filtro2 & " ORDER BY Localidad, TipoCafe DESC, TipoCompra"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Liquidaciones")

            Reg = DataSet.Tables("Liquidaciones").Rows.Count
            j = 0
            Me.ProgressBar2.Minimum = 0
            Me.ProgressBar2.Maximum = Reg
            Me.ProgressBar2.Value = 0
            IdLiquidacion = 0
            IdRemision = 0
            DeduccionLiquidacion = 0

            PesoBruto = 0
            PesoNeto = 0
            MontoPagado = 0
            PesoBrutoRemision = 0
            PesoNetoRemision = 0
            Do While Reg > j

                DeduccionLiquidacion = 0
                If Not IsDBNull(DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino")) Then
                    If IdLiquidacion <> DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino") Then
                        DeduccionLiquidacion = DataSet.Tables("Liquidaciones").Rows(j)("TotalDeducciones")
                        IdLiquidacion = DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino")
                    End If
                End If

                PesoBruto = PesoBruto + DataSet.Tables("Liquidaciones").Rows(j)("PesoBruto")
                PesoNeto = PesoNeto + DataSet.Tables("Liquidaciones").Rows(j)("PesoNeto")

                If DataSet.Tables("Registros").Rows(i)("TipoCafe") <> "MAQUILA" Then
                    If Not IsDBNull(DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino")) Then
                        'If IdRemision <> DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino") Then
                        PesoBrutoRemision = PesoBrutoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoBrutoRemision")
                        PesoNetoRemision = PesoNetoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoNetoRemision")
                        MontoPagado = MontoPagado + DataSet.Tables("Liquidaciones").Rows(j)("MontoTotal")
                        'End If
                    End If
                Else
                    PesoBrutoRemision = PesoBrutoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoBrutoRemision")
                    PesoNetoRemision = PesoNetoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoNetoRemision")
                End If

                If Not IsDBNull(DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino")) Then
                    IdRemision = DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino")
                End If

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////////VALIDO QUE EL MONTO LIQUIDADO ESTE EN EL RANGO DE FECHA DE LA CONSULTA /////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Dim FechaLiquidacion As Date

                If Not IsDBNull(DataSet.Tables("Liquidaciones").Rows(j)("Fecha")) Then
                    FechaLiquidacion = Format(DataSet.Tables("Liquidaciones").Rows(j)("Fecha"), "dd/MM/yyyy")

                    If FechaLiquidacion < Format(Me.DTPFechaInicial.Value, "dd/MM/yyyy") Then
                        MontoPagado = 0
                    ElseIf FechaLiquidacion > Format(Me.DTPFechaFinal.Value, "dd/MM/yyyy") Then
                        MontoPagado = 0
                    End If
                Else
                    MontoPagado = 0
                End If




                Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
                j = j + 1

            Loop
            DataSet.Tables("Liquidaciones").Reset()


            oDataRow = DataSet.Tables("Recepcion").NewRow
            oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
            oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
            oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
            oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
            oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
            oDataRow("PesoBruto") = PesoBruto
            oDataRow("PesoNeto") = PesoNeto
            oDataRow("MontoPagado") = MontoPagado
            oDataRow("Merma") = 0
            oDataRow("TipoCafe") = DataSet.Tables("Registros").Rows(i)("TipoCafe")
            oDataRow("Tipo") = "Recepcion1"
            DataSet.Tables("Recepcion").Rows.Add(oDataRow)

            'oDataRow = DataSet.Tables("Recepcion").NewRow
            'oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
            'oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
            'oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
            'oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
            'oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
            'oDataRow("PesoBruto") = PesoBrutoRemision
            'oDataRow("PesoNeto") = PesoNetoRemision
            'oDataRow("Merma") = DataSet.Tables("Registros").Rows(i)("MermaRemision")
            'oDataRow("TipoCafe") = DataSet.Tables("Registros").Rows(i)("TipoCafe")
            'oDataRow("Tipo") = "Recepcion2"
            'DataSet.Tables("Recepcion").Rows.Add(oDataRow)

            If PesoBruto - PesoBrutoRemision > 0 Then

                oDataRow = DataSet.Tables("Recepcion").NewRow
                oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
                oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
                oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
                oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
                oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
                oDataRow("PesoBruto") = PesoBruto - PesoBrutoRemision
                oDataRow("PesoNeto") = PesoNeto - PesoNetoRemision
                oDataRow("Tipo") = "Recepcion4"
                oDataRow("TipoCafe") = DataSet.Tables("Registros").Rows(i)("TipoCafe")
                oDataRow("Merma") = 0
                DataSet.Tables("Recepcion").Rows.Add(oDataRow)

            End If

            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            Me.Text = "Procesando " & i & " de " & Cont
            My.Application.DoEvents()
        Loop


        ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ''///////////////////////////////////////AGREO LOS RECIBOS DE MAQUILA CON LAS CONDICIONES ///////////////////////////////////////////////////////
        ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'Filtro8 = Filtro & " GROUP BY TipoCompra.Nombre, EstadoFisico.Descripcion, Region.Nombre,  LugarAcopio.NomLugarAcopio, TipoCafe.Nombre, Calidad.NomCalidad  HAVING (TipoCafe.Nombre = 'MAQUILA')"
        'Filtro8 = Filtro8 & "ORDER BY Localidad, TipoCafe DESC, TipoCompra"


        ''SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, SUM(CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleDistribucion.Monto END) AS MontoPagado, MAX(UnidadMedida.Descripcion) AS Descripcion, SUM(CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END) AS MermaRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoBruto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto2 END) AS PesoBrutoRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END) AS PesoNetoRemision, SUM(CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END) AS TaraRemision, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, TipoCompra.Nombre AS TipoCompra  FROM  TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON  TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino LEFT OUTER JOIN  LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino " & Filtro

        'SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, SUM(CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio - LiquidacionPergamino.TotalDeducciones END) AS MontoPagado, MAX(UnidadMedida.Descripcion) AS Descripcion, SUM(CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END) AS MermaRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoBruto IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto END) AS PesoBrutoRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END) AS PesoNetoRemision, SUM(CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END) AS TaraRemision, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, TipoCompra.Nombre AS TipoCompra  FROM  TipoCambio INNER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON TipoCambio.IdTipoCambio = LiquidacionPergamino.IdTipoCambio RIGHT OUTER JOIN TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino " & Filtro8

        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Registros")

        'Cont = DataSet.Tables("Registros").Rows.Count
        'i = 0
        'Me.ProgressBar1.Minimum = 0
        'Me.ProgressBar1.Maximum = Cont
        'Me.ProgressBar1.Value = 0

        'If Cont = 0 Then
        '    MsgBox("No Existen Registros para este Filtro", MsgBoxStyle.Information, "Sistema Bascula")
        '    Exit Sub
        'End If


        'Do While Cont > i


        '    j = 0
        '    Reg = 0

        '    'Filtro2 = Filtro1 & " AND (Calidad.NomCalidad = '" & DataSet.Tables("Registros").Rows(i)("Calidad") & "') AND (EstadoFisico.Descripcion = '" & DataSet.Tables("Registros").Rows(i)("EstadoFisico") & "') AND  (TipoCafe.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCafe") & "') AND (TipoCompra.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCompra") & "') AND (LiquidacionPergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102))"
        '    Filtro2 = Filtro1 & " AND (Calidad.NomCalidad = '" & DataSet.Tables("Registros").Rows(i)("Calidad") & "') AND (EstadoFisico.Descripcion = '" & DataSet.Tables("Registros").Rows(i)("EstadoFisico") & "') AND  (TipoCafe.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCafe") & "') AND (TipoCompra.Nombre = '" & DataSet.Tables("Registros").Rows(i)("TipoCompra") & "') "

        '    '/////////////////////////////////////////////////////////////////////////////////////////
        '    '////////////////////////BUSCO LOS TOTALES DEL GRUPO //////////////////////////////////
        '    '///////////////////////////////////////////////////////////////////////////////////////////
        '    SqlString = "SELECT DISTINCT RemisionPergamino.IdRemisionPergamino, Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE (DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio) END AS MontoPagado, UnidadMedida.Descripcion, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS MermaRemision, CASE WHEN DetalleRemisionPergamino.PesoBruto IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto END AS PesoBrutoRemision, CASE WHEN RecibosRemisionPergamino.PesoNeto IS NULL THEN 0 ELSE RecibosRemisionPergamino.PesoNeto END AS PesoNetoRemision, CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END AS TaraRemision, DetalleReciboCafePergamino.PesoBruto, TipoCompra.Nombre AS TipoCompra,  ReciboCafePergamino.Codigo,  LiquidacionPergamino.Codigo as CodigoLiquidacion, LiquidacionPergamino.IdLiquidacionPergamino, LiquidacionPergamino.TotalDeducciones, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE (DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio) - LiquidacionPergamino.TotalDeducciones END AS MontoTotal FROM TipoCambio INNER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON  TipoCambio.IdTipoCambio = LiquidacionPergamino.IdTipoCambio RIGHT OUTER JOIN TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN  DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino  " & Filtro2 & " ORDER BY Localidad, TipoCafe DESC, TipoCompra"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Liquidaciones")

        '    Reg = DataSet.Tables("Liquidaciones").Rows.Count
        '    j = 0
        '    Me.ProgressBar2.Minimum = 0
        '    Me.ProgressBar2.Maximum = Reg
        '    Me.ProgressBar2.Value = 0
        '    IdLiquidacion = 0
        '    IdRemision = 0
        '    DeduccionLiquidacion = 0

        '    PesoBruto = 0
        '    PesoNeto = 0
        '    MontoPagado = 0
        '    PesoBrutoRemision = 0
        '    PesoNetoRemision = 0
        '    Do While Reg > j

        '        DeduccionLiquidacion = 0
        '        If Not IsDBNull(DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino")) Then
        '            If IdLiquidacion <> DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino") Then
        '                DeduccionLiquidacion = DataSet.Tables("Liquidaciones").Rows(j)("TotalDeducciones")
        '                IdLiquidacion = DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino")
        '            End If
        '        End If

        '        PesoBruto = PesoBruto + DataSet.Tables("Liquidaciones").Rows(j)("PesoBruto")
        '        PesoNeto = PesoNeto + DataSet.Tables("Liquidaciones").Rows(j)("PesoNeto")

        '        If DataSet.Tables("Registros").Rows(i)("TipoCafe") <> "MAQUILA" Then
        '            If Not IsDBNull(DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino")) Then
        '                'If IdRemision <> DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino") Then
        '                PesoBrutoRemision = PesoBrutoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoBrutoRemision")
        '                PesoNetoRemision = PesoNetoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoNetoRemision")
        '                MontoPagado = MontoPagado + DataSet.Tables("Liquidaciones").Rows(j)("MontoTotal")
        '                'End If
        '            End If
        '        Else
        '            PesoBrutoRemision = PesoBrutoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoBrutoRemision")
        '            PesoNetoRemision = PesoNetoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoNetoRemision")
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino")) Then
        '            IdRemision = DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino")
        '        End If

        '        Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
        '        j = j + 1

        '    Loop
        '    DataSet.Tables("Liquidaciones").Reset()


        '    oDataRow = DataSet.Tables("Recepcion").NewRow
        '    oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
        '    oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
        '    oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
        '    oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
        '    oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
        '    oDataRow("PesoBruto") = PesoBruto
        '    oDataRow("PesoNeto") = PesoNeto
        '    oDataRow("MontoPagado") = MontoPagado
        '    oDataRow("Merma") = 0
        '    oDataRow("TipoCafe") = DataSet.Tables("Registros").Rows(i)("TipoCafe")
        '    oDataRow("Tipo") = "Recepcion1"
        '    DataSet.Tables("Recepcion").Rows.Add(oDataRow)


        '    If PesoBruto - PesoBrutoRemision > 0 Then

        '        oDataRow = DataSet.Tables("Recepcion").NewRow
        '        oDataRow("Region") = DataSet.Tables("Registros").Rows(i)("Region")
        '        oDataRow("Localidad") = DataSet.Tables("Registros").Rows(i)("Localidad")
        '        oDataRow("Calidad") = DataSet.Tables("Registros").Rows(i)("Calidad")
        '        oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
        '        oDataRow("TipoCompra") = DataSet.Tables("Registros").Rows(i)("TipoCompra")
        '        oDataRow("PesoBruto") = PesoBruto - PesoBrutoRemision
        '        oDataRow("PesoNeto") = PesoNeto - PesoNetoRemision
        '        oDataRow("Tipo") = "Recepcion4"
        '        oDataRow("TipoCafe") = DataSet.Tables("Registros").Rows(i)("TipoCafe")
        '        oDataRow("Merma") = 0
        '        DataSet.Tables("Recepcion").Rows.Add(oDataRow)

        '    End If

        '    i = i + 1
        '    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        '    Me.Text = "Procesando " & i & " de " & Cont
        '    My.Application.DoEvents()
        'Loop


        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////AGREGO LAS REMISIONES DEL PERIODO //////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Filtro6 = Filtro5
        Filtro5 = Filtro5 & " GROUP BY TipoCompra.Nombre, EstadoFisico.Descripcion, Region.Nombre,  LugarAcopio.NomLugarAcopio, TipoCafe.Nombre, Calidad.NomCalidad  "
        Filtro5 = Filtro5 & "ORDER BY Localidad, TipoCafe DESC, TipoCompra"

        SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, SUM(CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio - LiquidacionPergamino.TotalDeducciones END) AS MontoPagado, MAX(UnidadMedida.Descripcion) AS Descripcion, SUM(CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END) AS MermaRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoBruto IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto END) AS PesoBrutoRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END) AS PesoNetoRemision, SUM(CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END) AS TaraRemision, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, TipoCompra.Nombre AS TipoCompra  FROM  TipoCambio INNER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON TipoCambio.IdTipoCambio = LiquidacionPergamino.IdTipoCambio RIGHT OUTER JOIN TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino " & Filtro5
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "RegistrosRemision")

        Cont = DataSet.Tables("RegistrosRemision").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Cont
        Me.ProgressBar1.Value = 0

        If Cont = 0 Then
            MsgBox("No Existen Registros para este Filtro", MsgBoxStyle.Information, "Sistema Bascula")
            Exit Sub
        End If


        Do While Cont > i
            PesoBruto = 0
            PesoNeto = 0
            MontoPagado = 0
            PesoBrutoRemision = 0
            PesoNetoRemision = 0
            TaraRemision = 0

            j = 0
            Reg = 0

            Filtro2 = Filtro6 & " AND (Calidad.NomCalidad = '" & DataSet.Tables("RegistrosRemision").Rows(i)("Calidad") & "') AND (EstadoFisico.Descripcion = '" & DataSet.Tables("RegistrosRemision").Rows(i)("EstadoFisico") & "') AND  (TipoCafe.Nombre = '" & DataSet.Tables("RegistrosRemision").Rows(i)("TipoCafe") & "') AND (TipoCompra.Nombre = '" & DataSet.Tables("RegistrosRemision").Rows(i)("TipoCompra") & "')"
            '/////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////BUSCO LOS TOTALES DEL GRUPO //////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT DISTINCT RemisionPergamino.IdRemisionPergamino, Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE (DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio) END AS MontoPagado, UnidadMedida.Descripcion, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS MermaRemision, CASE WHEN DetalleRemisionPergamino.PesoBruto IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto END AS PesoBrutoRemision, CASE WHEN RecibosRemisionPergamino.PesoNeto IS NULL THEN 0 ELSE RecibosRemisionPergamino.PesoNeto END AS PesoNetoRemision, CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END AS TaraRemision, DetalleReciboCafePergamino.PesoBruto, TipoCompra.Nombre AS TipoCompra,  ReciboCafePergamino.Codigo,  LiquidacionPergamino.Codigo as CodigoLiquidacion, LiquidacionPergamino.IdLiquidacionPergamino, LiquidacionPergamino.TotalDeducciones FROM TipoCambio INNER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON  TipoCambio.IdTipoCambio = LiquidacionPergamino.IdTipoCambio RIGHT OUTER JOIN TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN  DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino  " & Filtro2 & " ORDER BY Localidad, TipoCafe DESC, TipoCompra"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Liquidaciones")

            Reg = DataSet.Tables("Liquidaciones").Rows.Count
            j = 0
            Me.ProgressBar2.Minimum = 0
            Me.ProgressBar2.Maximum = Reg
            Me.ProgressBar2.Value = 0
            IdLiquidacion = 0
            DeduccionLiquidacion = 0
            IdRemision = 0
            Do While Reg > j



                DeduccionLiquidacion = 0
                If Not IsDBNull(DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino")) Then
                    If IdLiquidacion <> DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino") Then
                        DeduccionLiquidacion = DataSet.Tables("Liquidaciones").Rows(j)("TotalDeducciones")
                        IdLiquidacion = DataSet.Tables("Liquidaciones").Rows(j)("IdLiquidacionPergamino")
                    End If
                End If

                ''////////////////////////////////////BASADOS EN LA REMISION CONSULTO EL PESO DEL GRUPO REMISIONADO /////////
                'Sql = "SELECT DISTINCT SUM(DetalleRemisionPergamino.PesoBruto) AS PesoBruto, SUM(DetalleRemisionPergamino.Tara) AS Tara, SUM(DetalleRemisionPergamino.PesoNeto2) AS PesoNeto2, SUM(DetalleRemisionPergamino.Merma) AS Merma, SUM(DetalleRemisionPergamino.PesoBruto2) AS PesoBruto2, SUM(DetalleRemisionPergamino.Tara2) AS Tara2 FROM  DetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN EstadoFisico ON DetalleRemisionPergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN Calidad ON RemisionPergamino.IdCalidad = Calidad.IdCalidad INNER JOIN TipoCafe ON RemisionPergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN  RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN TipoCompra ON ReciboCafePergamino.IdTipoCompra = TipoCompra.IdECS  " & _
                '      "WHERE (Calidad.NomCalidad = 'AP1ra') AND (EstadoFisico.Descripcion = 'Pergamino') AND (RemisionPergamino.IdRemisionPergamino = 426463) AND  (TipoCafe.Nombre = 'PERGAMINO') AND (TipoCompra.Nombre = 'Compra Directa')"

                '///////////////////////////CON ESTA CONDICIONAL EVITO SUMAR REMISIONES REPETIDAS PARA EL GRUPO ////////

                If DataSet.Tables("RegistrosRemision").Rows(i)("TipoCafe") <> "MAQUILA" Then
                    If IdRemision <> DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino") Then
                        PesoBruto = PesoBruto + DataSet.Tables("Liquidaciones").Rows(j)("PesoBruto")
                        PesoNeto = PesoNeto + DataSet.Tables("Liquidaciones").Rows(j)("PesoNeto")
                        PesoBrutoRemision = PesoBrutoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoBrutoRemision")
                        TaraRemision = DataSet.Tables("Liquidaciones").Rows(j)("TaraRemision")
                        PesoNetoRemision = PesoNetoRemision + (DataSet.Tables("Liquidaciones").Rows(j)("PesoBrutoRemision") - TaraRemision)    'DataSet.Tables("Liquidaciones").Rows(j)("PesoNetoRemision")

                        MontoPagado = MontoPagado + DataSet.Tables("Liquidaciones").Rows(j)("MontoPagado") - DeduccionLiquidacion
                    End If

                Else
                    PesoBruto = PesoBruto + DataSet.Tables("Liquidaciones").Rows(j)("PesoBruto")
                    PesoNeto = PesoNeto + DataSet.Tables("Liquidaciones").Rows(j)("PesoNeto")
                    PesoBrutoRemision = PesoBrutoRemision + DataSet.Tables("Liquidaciones").Rows(j)("PesoBrutoRemision")
                    TaraRemision = DataSet.Tables("Liquidaciones").Rows(j)("TaraRemision")
                    PesoNetoRemision = PesoNetoRemision + (DataSet.Tables("Liquidaciones").Rows(j)("PesoBrutoRemision") - TaraRemision)
                    MontoPagado = MontoPagado + DataSet.Tables("Liquidaciones").Rows(j)("MontoPagado") - DeduccionLiquidacion
                End If

                IdRemision = DataSet.Tables("Liquidaciones").Rows(j)("IdRemisionPergamino")


                Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
                j = j + 1
            Loop
            DataSet.Tables("Liquidaciones").Reset()


            oDataRow = DataSet.Tables("Recepcion").NewRow
            oDataRow("Region") = DataSet.Tables("RegistrosRemision").Rows(i)("Region")
            oDataRow("Localidad") = DataSet.Tables("RegistrosRemision").Rows(i)("Localidad")
            oDataRow("Calidad") = DataSet.Tables("RegistrosRemision").Rows(i)("Calidad")
            oDataRow("EstadoFisico") = DataSet.Tables("RegistrosRemision").Rows(i)("EstadoFisico")
            oDataRow("TipoCompra") = DataSet.Tables("RegistrosRemision").Rows(i)("TipoCompra")
            oDataRow("PesoBruto") = PesoBrutoRemision
            oDataRow("PesoNeto") = PesoNetoRemision
            oDataRow("Merma") = DataSet.Tables("RegistrosRemision").Rows(i)("MermaRemision")
            oDataRow("TipoCafe") = DataSet.Tables("RegistrosRemision").Rows(i)("TipoCafe")
            oDataRow("Tipo") = "Recepcion3"
            DataSet.Tables("Recepcion").Rows.Add(oDataRow)


            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            Me.Text = "Procesando " & i & " de " & Cont
            My.Application.DoEvents()
        Loop






        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////////////AGREGO LAS LIQUIDACION PAGADAS EN EL RANGO DE FECHA SELECCIONADO /////////////////////////////////
        '/////////////////////////////////////////PERO LOS RECIBOS SON EN OTRAS FECHAS ///////////////////////////////////////////////////////////
        'Filtro4 = Filtro3 & " AND  (LiquidacionPergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & "', 102)) "
        'SqlString = "SELECT DISTINCT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE (DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio) END AS MontoPagado, UnidadMedida.Descripcion, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS MermaRemision, CASE WHEN DetalleRemisionPergamino.PesoBruto IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto END AS PesoBrutoRemision, CASE WHEN RecibosRemisionPergamino.PesoNeto IS NULL THEN 0 ELSE RecibosRemisionPergamino.PesoNeto END AS PesoNetoRemision, CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END AS TaraRemision, DetalleReciboCafePergamino.PesoBruto, TipoCompra.Nombre AS TipoCompra, ReciboCafePergamino.Codigo, LiquidacionPergamino.Codigo AS CodigoLiquidacion, LiquidacionPergamino.IdLiquidacionPergamino, LiquidacionPergamino.TotalDeducciones FROM TipoCambio INNER JOIN  LiquidacionPergamino INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON  TipoCambio.IdTipoCambio = LiquidacionPergamino.IdTipoCambio RIGHT OUTER JOIN TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN  TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino " & Filtro4 & " ORDER BY Localidad, TipoCafe DESC, TipoCompra"
        SqlString = "SELECT  DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.TotalDeducciones, LiquidacionPergamino.Fecha, TipoCompra.Nombre AS TipoCompra, LugarAcopio.NomLugarAcopio AS Localidad, Region.Nombre AS Region, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, LiquidacionPergamino.IdLiquidacionPergamino, CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE (DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio) END AS MontoPagado, TipoCafe.Nombre FROM  LiquidacionPergamino INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN  LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoFisico ON LiquidacionPergamino.IdEstadoFisico = EstadoFisico.EstadoFisico INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe " & _
                    "WHERE (LiquidacionPergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd") & " 23:59:59', 102)) AND (LugarAcopio.IdLugarAcopio =  " & Me.IdLugarAcopio & ") AND (TipoCompra.Nombre = 'Depósito')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "LiquidacionesMes")

        Reg = DataSet.Tables("LiquidacionesMes").Rows.Count
        j = 0
        Me.ProgressBar2.Minimum = 0
        Me.ProgressBar2.Maximum = Reg
        Me.ProgressBar2.Value = 0
        IdLiquidacion = 0
        DeduccionLiquidacion = 0
        PesoBruto = 0
        PesoNeto = 0
        MontoPagado = 0
        Do While Reg > j

            DeduccionLiquidacion = 0
            DeduccionLiquidacion = DataSet.Tables("LiquidacionesMes").Rows(j)("TotalDeducciones")


            PesoBruto = PesoBruto + DataSet.Tables("LiquidacionesMes").Rows(j)("PesoBruto")
            PesoNeto = PesoNeto + DataSet.Tables("LiquidacionesMes").Rows(j)("PesoNeto")
            MontoPagado = MontoPagado + DataSet.Tables("LiquidacionesMes").Rows(j)("MontoPagado") - DeduccionLiquidacion

            If IdLiquidacion <> DataSet.Tables("LiquidacionesMes").Rows(j)("IdLiquidacionPergamino") Then
                oDataRow = DataSet.Tables("Recepcion").NewRow
                oDataRow("Region") = DataSet.Tables("LiquidacionesMes").Rows(j)("Region")
                oDataRow("Localidad") = DataSet.Tables("LiquidacionesMes").Rows(j)("Localidad")
                oDataRow("Calidad") = DataSet.Tables("LiquidacionesMes").Rows(j)("Calidad")
                oDataRow("EstadoFisico") = DataSet.Tables("LiquidacionesMes").Rows(j)("EstadoFisico")
                oDataRow("TipoCompra") = DataSet.Tables("LiquidacionesMes").Rows(j)("TipoCompra")
                oDataRow("PesoBruto") = PesoBruto
                oDataRow("PesoNeto") = PesoNeto
                oDataRow("MontoPagado") = MontoPagado
                oDataRow("Merma") = 0
                oDataRow("TipoCafe") = DataSet.Tables("LiquidacionesMes").Rows(j)("Nombre")
                oDataRow("Tipo") = "Recepcion2"
                DataSet.Tables("Recepcion").Rows.Add(oDataRow)

            End If

            IdLiquidacion = DataSet.Tables("LiquidacionesMes").Rows(j)("IdLiquidacionPergamino")


            Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
            j = j + 1
        Loop
        DataSet.Tables("LiquidacionesMes").Reset()


        '/////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////BUSCO EL SALDO EN BODEGA //////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////
        Filtro7 = Filtro7 & " GROUP BY TipoCompra.Nombre, EstadoFisico.Descripcion, Region.Nombre,  LugarAcopio.NomLugarAcopio, TipoCafe.Nombre, Calidad.NomCalidad  "
        Filtro7 = Filtro7 & "ORDER BY Localidad, TipoCafe DESC, TipoCompra"
        SqlString = "SELECT  Region.Nombre AS Region, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, EstadoFisico.Descripcion AS EstadoFisico, TipoCafe.Nombre AS TipoCafe, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, SUM(CASE WHEN DetalleDistribucion.Monto IS NULL THEN 0 ELSE DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio - LiquidacionPergamino.TotalDeducciones END) AS MontoPagado, MAX(UnidadMedida.Descripcion) AS Descripcion, SUM(CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END) AS MermaRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoBruto IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoBruto END) AS PesoBrutoRemision, SUM(CASE WHEN DetalleRemisionPergamino.PesoNeto2 IS NULL THEN 0 ELSE DetalleRemisionPergamino.PesoNeto2 END) AS PesoNetoRemision, SUM(CASE WHEN DetalleRemisionPergamino.Tara IS NULL THEN 0 ELSE DetalleRemisionPergamino.Tara END) AS TaraRemision, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, TipoCompra.Nombre AS TipoCompra  FROM  TipoCambio INNER JOIN LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino ON TipoCambio.IdTipoCambio = LiquidacionPergamino.IdTipoCambio RIGHT OUTER JOIN TipoCompra INNER JOIN UnidadMedida INNER JOIN ReciboCafePergamino INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN Region ON LugarAcopio.IdRegion = Region.IdRegion INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe ON UnidadMedida.IdUnidadMedida = ReciboCafePergamino.IdUnidadMedida ON TipoCompra.IdECS = ReciboCafePergamino.IdTipoCompra LEFT OUTER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino " & Filtro7

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Bodega")

        Cont = DataSet.Tables("Bodega").Rows.Count
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
            oDataRow("Region") = DataSet.Tables("Bodega").Rows(i)("Region")
            oDataRow("Localidad") = DataSet.Tables("Bodega").Rows(i)("Localidad")
            oDataRow("Calidad") = DataSet.Tables("Bodega").Rows(i)("Calidad")
            oDataRow("EstadoFisico") = DataSet.Tables("Bodega").Rows(i)("EstadoFisico")
            oDataRow("TipoCompra") = DataSet.Tables("Bodega").Rows(i)("TipoCompra")
            oDataRow("PesoBruto") = PesoBruto
            oDataRow("PesoNeto") = PesoNeto
            oDataRow("Tipo") = "Recepcion4"
            oDataRow("TipoCafe") = DataSet.Tables("Bodega").Rows(i)("TipoCafe")
            oDataRow("Merma") = 0
            DataSet.Tables("Recepcion").Rows.Add(oDataRow)


            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
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

        ArepMermaRecepcion.LblImpreso.Text = "Desde: " & Format(Me.DTPFechaInicial.Value, "yyyy-MM-dd") & " Hasta: " & Format(Me.DTPFechaFinal.Value, "yyyy-MM-dd")
        DvRecepcion = New DataView(DataSet.Tables("Recepcion"))
        DvRecepcion.Sort = "Tipo, Calidad"

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
        ListadoLiquidacion()
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
        Dim DvRecepcion As DataView, oDataRow As DataRow
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, ListaRecibos As String
        Dim CantidadBascula As Double, PesoBascula As Double, TipoPesada As String, Tara As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Numero As String, IdRemision As Double
        Dim NumeroRecibo As String, CadenaDiv() As String, Max As Double, j As Double, MermaTransitoPI As Double = 0, PesoBrutoRemision As Double = 0, PesoBrutoIni1 As Double, PesoBrutoFin1 As Double
        Dim PesoBrutoIni2 As Double = 0, PesoBrutoFin2 As Double = 0, PesoNetoRecibo As Double = 0, PesoNetoPII As Double, i As Double
        Dim CantSacoPI As Double = 0, PesoBrutoPI As Double = 0, MermaBodegaPI As Double = 0
        Dim TaraPII As Double, CantSacosPII As Double, MermaTransitoPII As Double, MermaBodegaTotal As Double
        Dim Criterios As String, Buscar_Fila() As DataRow, Posicion As Double, h As Double = 0, TipoRemision As String


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

        If Me.ChkTodasLocalidades.Checked = False Then
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

        If Me.ChkTodasModalidades.Checked = False Then
            Filtro = Filtro & " AND (RemisionPergamino.IdTipoCafe  = " & IdTipoCafe & ")"
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

        If Me.ChkTodasCalidades.Checked = False Then
            Filtro = Filtro & " AND (Calidad.IdCalidad = " & IdCalidad & ")"
        End If

        SqlString = "SELECT EstadoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto, IdEdoFisico FROM EstadoFisico WHERE (Descripcion = '" & Me.CboEstado.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaFisico")
        If DataSet.Tables("BuscaFisico").Rows.Count <> 0 Then
            Me.IdEstadoFisico = DataSet.Tables("BuscaFisico").Rows(0)("EstadoFisico")
        Else
            Me.IdEstadoFisico = 0
        End If
        DataSet.Tables("BuscaFisico").Reset()

        If Me.ChkEstadoTodos.Checked = False Then
            Filtro = Filtro & " AND (EstadoFisico.EstadoFisico = " & Me.IdEstadoFisico & ")"
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

        Filtro = Filtro & " ORDER BY RemisionPergamino.IdRemisionPergamino, ReciboCafePergamino.Codigo"




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


        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CREO UNA CONSULTA QUE NUNCA TENDRA REGISTROS //////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT  DetalleRemisionPergamino.Codigo AS N0, DetalleRemisionPergamino.Codigo AS Rango, RemisionPergamino.Codigo AS NumeroRemision, CASE WHEN TipoCafe.Nombre = 'PERGAMINO' THEN 'EXPASA' ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, DetalleReciboCafePergamino.Imperfeccion, Dano.Nombre AS Daño, EstadoFisico.Descripcion AS EstadoFisico, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, DetalleReciboCafePergamino.CantidadSacos AS CantidadSacosRecibos, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNetoRecibos, DetalleReciboCafePergamino.PesoBruto AS MermaBodega, DetalleReciboCafePergamino.CantidadSacos AS CantidadSacosPI, DetalleReciboCafePergamino.PesoBruto AS PesoBrutoIniPI, DetalleReciboCafePergamino.PesoBruto AS PesoBrutoFinPI, DetalleReciboCafePergamino.PesoBruto AS MermaTransitoPI, DetalleReciboCafePergamino.PesoBruto AS MermaBodegaPI, DetalleReciboCafePergamino.CantidadSacos AS CantidadSacosPII, DetalleReciboCafePergamino.PesoBruto AS PesoBrutoIniPII, DetalleReciboCafePergamino.PesoBruto AS TaraIniPII, DetalleReciboCafePergamino.PesoBruto AS PesoNetoIniPII, DetalleReciboCafePergamino.PesoBruto AS PesoBrutoFinPII, DetalleReciboCafePergamino.PesoBruto AS MermaTransitoPII, DetalleReciboCafePergamino.PesoBruto AS MermaBodegaTotal, RemisionPergamino.IdRemisionPergamino FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN Vehiculo ON RemisionPergamino.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad LEFT OUTER JOIN Intermedio ON RemisionPergamino.IdRemisionPergamino = Intermedio.IdRemisionPergamino LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca " & _
                    "WHERE(TipoCafe.IdTipoCafe = -1000000) And (calidad.IdCalidad = 1) ORDER BY ReciboCafePergamino.Codigo "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Reporte")

        SqlString = "SELECT DISTINCT DetalleRemisionPergamino.Codigo AS Rango, DetalleReciboCafePergamino.Imperfeccion, Dano.Nombre AS Daño, EstadoFisico.Descripcion AS EstadoFisico,  CASE WHEN TipoCafe.Nombre = 'PERGAMINO' THEN 'EXPASA' ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, ReciboCafePergamino.Codigo, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, DetalleReciboCafePergamino.CantidadSacos AS CantidadSacosRecibos, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNetoRecibos, RecibosRemisionPergamino.PesoNeto AS PesoAplicado, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara - RecibosRemisionPergamino.PesoNeto AS PesoPorAplicar, RemisionPergamino.IdRemisionPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino, Dano.IdDano, Finca.CodFinca, RemisionPergamino.FechaCarga, RemisionPergamino.IdLugarAcopio, RemisionPergamino.IdEmpresaTransporte, Vehiculo.Placa, (DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara) - (DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS Merma, TipoCafe.Nombre, calidad.NomCalidad, calidad.IdCalidad, TipoCafe.IdTipoCafe, RemisionPergamino.Codigo AS NumeroRemision, RemisionPergamino.Numero_Boleta  FROM  DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN Vehiculo ON RemisionPergamino.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad LEFT OUTER JOIN  Intermedio ON RemisionPergamino.IdRemisionPergamino = Intermedio.IdRemisionPergamino LEFT OUTER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca  " & Filtro
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Registros")

        i = 0
        Me.ProgressBar1.Maximum = DataSet.Tables("Registros").Rows.Count
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Value = 0
        Do While DataSet.Tables("Registros").Rows.Count > i


            Numero = DataSet.Tables("Registros").Rows(i)("Rango")
            IdRemision = DataSet.Tables("Registros").Rows(i)("IdRemisionPergamino")

            If IdRemision = "134443" Then
                IdRemision = "134443"
            End If

            PesoBrutoRemision = 0
            If Not IsDBNull(DataSet.Tables("Registros").Rows(i)("PesoBruto")) Then
                PesoBrutoRemision = DataSet.Tables("Registros").Rows(i)("PesoBruto")
            End If

            PesoNetoRecibo = 0
            If Not IsDBNull(DataSet.Tables("Registros").Rows(i)("PesoNetoRecibos")) Then
                PesoNetoRecibo = DataSet.Tables("Registros").Rows(i)("PesoNetoRecibos")
            End If

            ListaRecibos = ""
            If DataSet.Tables("Registros").Rows(i)("Proveedor") = "EXPASA" Then
                '/////////////////////////////QUITO EL NUMERO DE LA LOCALIDAD AL NUMERO DE RECIBO ///////////////////////////
                NumeroRecibo = Trim(Replace(DataSet.Tables("Registros").Rows(i)("Rango"), ",", "-"))
                NumeroRecibo = Trim(Replace(NumeroRecibo, "Ø", ""))
                CadenaDiv = NumeroRecibo.Split("-")
                Max = UBound(CadenaDiv)
                NumeroRecibo = ""
                For j = 0 To Max
                    If Len(CadenaDiv(j)) > 4 Then              '/////////////////////////MODIFICADO EL 25-11-2019 A SOLICITUD DE MARIELO ///////////////////

                        If NumeroRecibo = "" Then '//////////////////////ESTE ES EL RANGO PARA EL PRIMER RECIBO /////////////
                            NumeroRecibo = CDbl(CadenaDiv(j))
                        Else                              'If j = Max Then  '//////////////ESTE ES EL RANGO PARA EL ULTIMO RECIBO ///////////////////
                            NumeroRecibo = NumeroRecibo & "," & CDbl(CadenaDiv(j))
                        End If

                    End If
                Next
                ListaRecibos = NumeroRecibo
            Else
                ListaRecibos = DataSet.Tables("Registros").Rows(i)("Codigo")
            End If

            If IdRemision = "134443" Then
                IdRemision = "134443"
            End If

            Criterios = "IdRemisionPergamino= '" & IdRemision & "' "
            Buscar_Fila = DataSet.Tables("Reporte").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                Posicion = DataSet.Tables("Reporte").Rows.IndexOf(Buscar_Fila(0))
                'DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos") = 0 'Me.GribListRecibos.Item(i)("CantidadSacos") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos")
                DataSet.Tables("Reporte").Rows(Posicion)("CantidadSacosRecibos") = DataSet.Tables("Reporte").Rows(Posicion)("CantidadSacosRecibos") + DataSet.Tables("Registros").Rows(i)("CantidadSacosRecibos")
                DataSet.Tables("Reporte").Rows(Posicion)("PesoNetoRecibos") = DataSet.Tables("Reporte").Rows(Posicion)("PesoNetoRecibos") + DataSet.Tables("Registros").Rows(i)("PesoNetoRecibos")
                DataSet.Tables("Reporte").Rows(Posicion)("MermaBodega") = DataSet.Tables("Registros").Rows(i)("PesoNeto") - DataSet.Tables("Reporte").Rows(Posicion)("PesoNetoRecibos")

            Else

                If IdRemision <> 0 Then
                    'Me.LblNumero.Text = CDbl(Mid(Numero, 5, Len(Numero) - 1))


                    CantSacoPI = 0
                    PesoBrutoPI = 0
                    PesoBrutoIni1 = 0
                    PesoBrutoFin1 = 0
                    MermaTransitoPI = 0
                    MermaBodegaPI = 0
                    CantSacosPII = 0
                    PesoBrutoIni2 = 0
                    TaraPII = 0
                    PesoNetoPII = 0
                    PesoBrutoFin2 = 0
                    MermaTransitoPII = 0
                    MermaBodegaTotal = 0

                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////////CARGO LA CONSULTA CON LOS REGISTROS DEL DETALLE/////////////////////////////
                    '///////////////////////////////////////////////////////////////////////////////////////////////////////////77
                    SqlString = "SELECT  IdDetalleRemisionPergamino, CantidadSacos, IdRemisionPergamino FROM DetalleRemisionPergamino WHERE(IdRemisionPergamino = " & IdRemision & ")"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "DetalleRemision")
                    h = 0
                    Do While DataSet.Tables("DetalleRemision").Rows.Count > h



                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////BUSCO LA PESADA PARA EL PRIMER PUNTO INTERMEDIO ///////////////////////
                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        CantidadBascula = 0
                        PesoBascula = 0
                        If DataSet.Tables("Registros").Rows(i)("Nombre") = "MAQUILA" Then
                            TipoPesada = "Rec" & Numero & "-N" & h & "-D" & 0 & "-P1"
                            TipoRemision = "MAQUILA"
                        Else
                            TipoPesada = "RecGrupo " & h & "-N" & h & "-D" & 0 & "-P1"
                            TipoRemision = "PERGAMINO"
                        End If


                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        SqlString = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = " & IdRemision & ") AND (TipoRemision = '" & TipoRemision & "') GROUP BY Cod_Productos, Descripcion_Producto "
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "ConsultaPI")
                        If Not DataSet.Tables("ConsultaPI").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("ConsultaPI").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("ConsultaPI").Rows(0)("QQ")
                            Tara = DataSet.Tables("ConsultaPI").Rows(0)("Tara")
                        End If


                        CantSacoPI = CantSacoPI + Format(CantidadBascula, "##,##0")
                        PesoBrutoPI = PesoBrutoPI + Format(PesoBascula, "##,##0.00")
                        PesoBrutoIni1 = PesoBrutoIni1 + Format(PesoBascula, "##,##0.00")
                        MermaTransitoPI = Format(PesoBrutoIni1 - PesoBrutoRemision, "##,##0.00")
                        DataSet.Tables("ConsultaPI").Reset()


                        CantidadBascula = 0
                        PesoBascula = 0
                        Tara = 0
                        'TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 0 & "-P2"

                        If DataSet.Tables("Registros").Rows(i)("Nombre") = "MAQUILA" Then
                            TipoPesada = "Rec" & Numero & "-N" & h & "-D" & 0 & "-P2"
                            TipoRemision = "MAQUILA"
                        Else
                            TipoPesada = "RecGrupo " & h & "-N" & h & "-D" & 0 & "-P2"
                            TipoRemision = "PERGAMINO"
                        End If

                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        SqlString = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "')  AND  (IdRemisionPergamino = " & IdRemision & ") AND (TipoRemision = '" & TipoRemision & "') GROUP BY Cod_Productos, Descripcion_Producto"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "ConsultaPI")
                        If Not DataSet.Tables("ConsultaPI").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("ConsultaPI").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("ConsultaPI").Rows(0)("QQ")
                            Tara = DataSet.Tables("ConsultaPI").Rows(0)("Tara")
                        End If

                        'Me.TxtCantSacos11.Text = Format(CantidadBascula, "##,##0")
                        PesoBrutoFin1 = PesoBrutoFin1 + Format(PesoBascula, "##,##0.00")
                        MermaBodegaPI = Format(PesoBrutoFin1 - PesoBrutoIni1, "##,##0.00")
                        DataSet.Tables("ConsultaPI").Reset()


                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '/////////////////////////////////////////////////////////////////////BUSCO LA PESADA PARA EL SEGUNDO PUNTO INTERMEDIO ///////////////////////
                        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                        CantidadBascula = 0
                        PesoBascula = 0
                        Tara = 0
                        'TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 1 & "-P1"

                        If DataSet.Tables("Registros").Rows(i)("Nombre") = "MAQUILA" Then
                            TipoPesada = "Rec" & Numero & "-N" & h & "-D" & 1 & "-P1"
                            TipoRemision = "MAQUILA"
                        Else
                            TipoPesada = "RecGrupo " & h & "-N" & h & "-D" & 1 & "-P1"
                            TipoRemision = "PERGAMINO"
                        End If

                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        SqlString = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = " & IdRemision & ") AND (TipoRemision = '" & TipoRemision & "') GROUP BY Cod_Productos, Descripcion_Producto"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "ConsultaPII")
                        If Not DataSet.Tables("ConsultaPII").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("ConsultaPII").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("ConsultaPII").Rows(0)("QQ")
                            Tara = DataSet.Tables("ConsultaPII").Rows(0)("Tara")
                        End If

                        PesoBrutoIni2 = PesoBrutoIni2 + Format(PesoBascula, "##,##00")
                        TaraPII = TaraPII + Format(Tara, "##,##0")
                        CantSacosPII = CantSacosPII + Format(CantidadBascula, "##,##0")
                        PesoNetoPII = PesoNetoPII + Format(PesoBrutoIni2 - TaraPII, "##,##0.00")

                        DataSet.Tables("ConsultaPII").Reset()

                        CantidadBascula = 0
                        PesoBascula = 0
                        'TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 1 & "-P2"

                        If DataSet.Tables("Registros").Rows(i)("Nombre") = "MAQUILA" Then
                            TipoPesada = "Rec" & Numero & "-N" & h & "-D" & 1 & "-P2"
                            TipoRemision = "MAQUILA"
                        Else
                            TipoPesada = "RecGrupo " & h & "-N" & h & "-D" & 1 & "-P2"
                            TipoRemision = "PERGAMINO"
                        End If

                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        SqlString = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = '" & IdRemision & "') AND (TipoRemision = '" & TipoRemision & "') GROUP BY Cod_Productos, Descripcion_Producto"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "ConsultaPII")
                        If Not DataSet.Tables("ConsultaPII").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("ConsultaPII").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("ConsultaPII").Rows(0)("QQ")
                            Tara = DataSet.Tables("ConsultaPII").Rows(0)("Tara")
                        End If

                        PesoBrutoFin2 = PesoBrutoFin2 + Format(PesoBascula, "##,##00")
                        MermaTransitoPII = Format(PesoBrutoIni2 - PesoBrutoRemision, "##,##0.00")
                        MermaBodegaTotal = Format(PesoNetoRecibo - PesoNetoPII, "##,##0.00")
                        DataSet.Tables("ConsultaPII").Reset()

                        h = h + 1
                    Loop

                    DataSet.Tables("DetalleRemision").Reset()


                    oDataRow = DataSet.Tables("Reporte").NewRow
                    oDataRow("N0") = i + 1
                    oDataRow("Rango") = ListaRecibos
                    oDataRow("NumeroRemision") = DataSet.Tables("Registros").Rows(i)("NumeroRemision")
                    oDataRow("Proveedor") = DataSet.Tables("Registros").Rows(i)("Proveedor")
                    oDataRow("Imperfeccion") = DataSet.Tables("Registros").Rows(i)("Imperfeccion")
                    oDataRow("Daño") = DataSet.Tables("Registros").Rows(i)("Daño")
                    oDataRow("EstadoFisico") = DataSet.Tables("Registros").Rows(i)("EstadoFisico")
                    oDataRow("CantidadSacos") = DataSet.Tables("Registros").Rows(i)("CantidadSacos")
                    oDataRow("PesoBruto") = DataSet.Tables("Registros").Rows(i)("PesoBruto")
                    oDataRow("Tara") = DataSet.Tables("Registros").Rows(i)("Tara")
                    oDataRow("PesoNeto") = DataSet.Tables("Registros").Rows(i)("PesoNeto")
                    oDataRow("CantidadSacosRecibos") = DataSet.Tables("Registros").Rows(i)("CantidadSacosRecibos")
                    oDataRow("PesoNetoRecibos") = DataSet.Tables("Registros").Rows(i)("PesoNetoRecibos")
                    oDataRow("MermaBodega") = DataSet.Tables("Registros").Rows(i)("PesoNeto") - DataSet.Tables("Registros").Rows(i)("PesoNetoRecibos")
                    oDataRow("CantidadSacosPI") = CantSacoPI
                    oDataRow("PesoBrutoIniPI") = PesoBrutoPI
                    oDataRow("PesoBrutoFinPI") = PesoBrutoFin1
                    oDataRow("MermaTransitoPI") = MermaTransitoPI
                    oDataRow("MermaBodegaPI") = MermaBodegaPI
                    oDataRow("CantidadSacosPII") = CantSacosPII
                    oDataRow("PesoBrutoIniPII") = PesoBrutoIni2
                    oDataRow("TaraIniPII") = TaraPII
                    oDataRow("PesoNetoIniPII") = PesoNetoPII
                    oDataRow("PesoBrutoFinPII") = PesoBrutoFin2
                    oDataRow("MermaTransitoPII") = MermaTransitoPII
                    oDataRow("MermaBodegaTotal") = MermaBodegaTotal
                    oDataRow("IdRemisionPergamino") = IdRemision
                    DataSet.Tables("Reporte").Rows.Add(oDataRow)

                End If


            End If



            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            Me.Text = "Procesando " & i & " de " & DataSet.Tables("Registros").Rows.Count
        Loop






        'SQL.ConnectionString = Conexion
        'SQL.SQL = SqlString

        Dim ViewerForm As New FrmViewer()

        'DvRecepcion = New DataView(DataSet.Tables("Recepcion"))
        'DvRecepcion.Sort = "Tipo"

        ViewerForm.arvMain.Document = ArepReporteRemision.Document
        ArepReporteRemision.DataSource = DataSet.Tables("Reporte")
        ArepReporteRemision.Run(False)
        ViewerForm.Show()
        My.Application.DoEvents()



    End Sub

    Private Sub CboRegion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRegion.TextChanged
        Dim IdRegion As Double

        IdRegion = Me.CboRegion.Columns(0).Text

        DataSet.Tables("Localidades").Clear()
        SqlString = "SELECT LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio FROM   LugarAcopio INNER JOIN Region ON  LugarAcopio.IdRegion = Region.IdRegion  WHERE(Region.IdRegion = " & IdRegion & ")"
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

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click
        Dim SqlString As String, Cont As Double = 0, i As Double, Ruta As String, LeeArchivo As String = "", IdCosecha As Double
        Dim Consecutivo As Double, Numero As String, CodLugarAcopio As String, IdLiquidacion As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SQlUpdate As String
        Dim ArepReporteDetalleLiquidacion As New ArepReporteDetalleLiquidacion
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
       

        SqlString = "SELECT IdCosecha,Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CDbl(CodigoCosecha) & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count <> 0 Then
            IdCosecha = DataSet.Tables("Cosecha").Rows(0)("IdCosecha")
        End If


        '///////////////////////////////////////////////LUGAR ACOPIO ///////////////////////////////////////////////////////
        SqlString = "SELECT IdLugarAcopio, CodLugarAcopio, NomLugarAcopio  FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaLocalidad")
        If DataSet.Tables("BuscaLocalidad").Rows.Count <> 0 Then
            Me.IdLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("IdLugarAcopio")
            CodLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("CodLugarAcopio")
        Else
            Me.IdLugarAcopio = 0
        End If
        DataSet.Tables("BuscaLocalidad").Reset()




        SqlString = "SELECT  LiquidacionPergamino.IdLiquidacionPergamino, LiquidacionPergamino.Codigo, LiquidacionPergamino.Fecha, LiquidacionPergamino.Precio, DetalleDistribucion.Monto, DetalleLiquidacionPergamino.PesoNeto, CASE WHEN LiquidacionPergamino.ReportadoDistribucion IS NULL THEN 0 ELSE LiquidacionPergamino.ReportadoDistribucion END AS ReportadoDistribucion, LiquidacionPergamino.IdLocalidad FROM LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino  " & _
                    "WHERE (CASE WHEN LiquidacionPergamino.ReportadoDistribucion IS NULL THEN 0 ELSE LiquidacionPergamino.ReportadoDistribucion END = 0) AND (LiquidacionPergamino.IdLocalidad = " & Me.IdLugarAcopio & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Liquidacion")
        Cont = DataSet.Tables("Liquidacion").Rows.Count
        i = 0

        If Cont = 0 Then
            MsgBox("No Existen Registros para este reporte", MsgBoxStyle.Critical, "Sistema Bascula")
            Exit Sub
        End If



        '///////////////////////////////////////////BUSCO EL CONSECUTIVO ///////////////////////////////////////////////////////
        SqlString = "SELECT IdCosecha, IdLocalidad, Consecutivo FROM CorteConsecutivoLiquidacion WHERE  (IdCosecha = " & IdCosecha & " ) AND (IdLocalidad = " & IdLugarAcopio & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "ConsultaLiquida")
        If DataSet.Tables("ConsultaLiquida").Rows.Count = 0 Then
            Consecutivo = 1

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////INSERTO LA TABLA REPORTA ///////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            SQlUpdate = "INSERT INTO [CorteConsecutivoLiquidacion] ([IdCosecha],[IdLocalidad],[Consecutivo]) VALUES (" & IdCosecha & " ," & IdLugarAcopio & " ," & Consecutivo & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        Else
            Consecutivo = DataSet.Tables("ConsultaLiquida").Rows(0)("Consecutivo") + 1

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////ACTUALIZO LA TABLA REPORTA ///////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            SQlUpdate = "UPDATE [CorteConsecutivoLiquidacion] SET [Consecutivo] = " & Consecutivo & " WHERE  (IdCosecha = " & IdCosecha & " ) AND (IdLocalidad = " & IdLugarAcopio & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
        End If

        Numero = "B-" & CodLugarAcopio & "-" & Format(Consecutivo, "000#")


        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Cont


        Do While Cont > i

            ''" & Format(CDate(now), "dd/MM/yyyy") & "'
            IdLiquidacion = DataSet.Tables("Liquidacion").Rows(i)("IdLiquidacionPergamino")
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////ACTUALIZO LA TABLA LIQUIDACION ///////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            SQlUpdate = "UPDATE [LiquidacionPergamino] SET [ReportadoDistribucion] = 1, [NumeroReportado] = '" & Numero & "', [FechaReportado] = CONVERT(DATETIME, '" & Format(Now, "dd/MM/yyyy") & "')  WHERE  (IdLiquidacionPergamino = " & IdLiquidacion & " ) "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SQlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            Me.Text = "Procesando: " & Cont & " de " & i
            My.Application.DoEvents()
        Loop

        ArepReporteDetalleLiquidacion.Registros = Cont

        SqlString = "SELECT LiquidacionPergamino.Codigo, LiquidacionPergamino.Precio,  Round((DetalleDistribucion.Monto * TipoCambio.TipoCambio) / DetalleLiquidacionPergamino.PesoNeto,2) AS PrecioNeto, Round(DetalleDistribucion.Monto  * TipoCambio.TipoCambio,2) AS Monto, DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.IdLocalidad, LiquidacionPergamino.ReportadoDistribucion, LiquidacionPergamino.NumeroReportado, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, TipoCompra.Nombre AS TipoCompra, LiquidacionPergamino.IdLiquidacionPergamino FROM LiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS  INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio WHERE (LiquidacionPergamino.ReportadoDistribucion = 1) AND (LiquidacionPergamino.NumeroReportado = '" & Numero & "') ORDER BY TipoCompra, LiquidacionPergamino.Codigo"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlString

        ArepReporteDetalleLiquidacion.LblNumero.Text = "NUMERO: " & Numero
        ArepReporteDetalleLiquidacion.LblFecha.Text = "Fecha: " & Format(Now, "dd/MM/yyyy")
        ArepReporteDetalleLiquidacion.LblCosecha.Text = "Cosecha: " & CodigoCosecha
        ArepReporteDetalleLiquidacion.LblLocalidad.Text = "Localidad: " & Me.CboLocalidad.Text

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepReporteDetalleLiquidacion.Document
        ArepReporteDetalleLiquidacion.DataSource = SQL
        ArepReporteDetalleLiquidacion.Run(False)
        ViewerForm.Show()
        My.Application.DoEvents()

    End Sub

    Private Sub TDGridResumenLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridResumenLiquidacion.Click

    End Sub

    Private Sub BtnReimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimprimir.Click
        Dim SqlString As String, Cont As Double = 0, i As Double, Ruta As String, LeeArchivo As String = "", IdCosecha As Double
        Dim ArepReportedetalleLiquidacion As New ArepReporteDetalleLiquidacion, Fecha As Date, DtaSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, Numero As String

        Numero = Me.TDGridResumenLiquidacion.Columns("NumeroReportado").Text
        'If Not IsDBNull(Me.TDGridResumenLiquidacion.Columns("Fecha").Text) Then
        Fecha = Me.TDGridResumenLiquidacion.Columns("Fecha").Text
        'End If

        'SqlString = "SELECT LiquidacionPergamino.Codigo, LiquidacionPergamino.Precio, DetalleDistribucion.Monto  * TipoCambio.TipoCambio AS Monto, DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.IdLocalidad, LiquidacionPergamino.ReportadoDistribucion, LiquidacionPergamino.NumeroReportado, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, TipoCompra.Nombre AS TipoCompra, LiquidacionPergamino.IdLiquidacionPergamino FROM LiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS  INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio WHERE (LiquidacionPergamino.ReportadoDistribucion = 1) AND (LiquidacionPergamino.NumeroReportado = '" & Numero & "') ORDER BY TipoCompra, LiquidacionPergamino.Codigo"
        SqlString = "SELECT MAX(LiquidacionPergamino.Codigo) AS Codigo, MAX(LiquidacionPergamino.Precio) AS Precio, MAX(Round(DetalleDistribucion.Monto * TipoCambio.TipoCambio,2)) AS Monto, SUM(DetalleLiquidacionPergamino.PesoNeto) AS PesoNeto, MAX(LiquidacionPergamino.IdLocalidad) AS IdLocalidad, MAX(LiquidacionPergamino.NumeroReportado) AS NumeroReportado, MAX(Proveedor.Nombre_Proveedor + N' ' + Proveedor.Apellido_Proveedor) AS Nombres, TipoCompra.Nombre AS TipoCompra, LiquidacionPergamino.IdLiquidacionPergamino FROM LiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio   WHERE(LiquidacionPergamino.ReportadoDistribucion = 1) GROUP BY TipoCompra.Nombre, LiquidacionPergamino.IdLiquidacionPergamino HAVING  (MAX(LiquidacionPergamino.NumeroReportado) = '" & Numero & "') ORDER BY TipoCompra.Nombre, MAX(LiquidacionPergamino.Codigo)"
        SQL.ConnectionString = Conexion
        SQL.SQL = SqlString


        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")

        ArepReportedetalleLiquidacion.Registros = DataSet.Tables("Consulta").Rows.Count

        ArepReportedetalleLiquidacion.LblNumero.Text = "NUMERO: " & Numero
        ArepReportedetalleLiquidacion.LblFecha.Text = "Fecha: " & Format(Fecha, "dd/MM/yyyy")
        ArepReportedetalleLiquidacion.LblCosecha.Text = "Cosecha: " & CodigoCosecha
        ArepReportedetalleLiquidacion.LblLocalidad.Text = "Localidad " & Me.TDGridResumenLiquidacion.Columns("NomLugarAcopio").Text




        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepReportedetalleLiquidacion.Document
        ArepReportedetalleLiquidacion.DataSource = SQL
        ArepReportedetalleLiquidacion.Run(False)
        ViewerForm.Show()
        My.Application.DoEvents()


    End Sub

    Private Sub BtnPrevio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevio.Click
        Dim SqlString As String, Cont As Double = 0, i As Double, Ruta As String, LeeArchivo As String = "", IdCosecha As Double
        Dim Consecutivo As Double, Numero As String, CodLugarAcopio As String, IdLiquidacion As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SQlUpdate As String
        Dim ArepReporteResumenLiquidacion As New ArepReporteResumenLiquidacion
        Dim ArepReporteDetalleLiquidacion As New ArepReporteDetalleLiquidacion
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, PeriodoCosecha As String

        '///////////////////////////////////////////////LUGAR ACOPIO ///////////////////////////////////////////////////////
        SqlString = "SELECT IdLugarAcopio, CodLugarAcopio, NomLugarAcopio  FROM LugarAcopio WHERE (NomLugarAcopio = '" & Me.CboLocalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "BuscaLocalidad")
        If DataSet.Tables("BuscaLocalidad").Rows.Count <> 0 Then
            Me.IdLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("IdLugarAcopio")
            CodLugarAcopio = DataSet.Tables("BuscaLocalidad").Rows(0)("CodLugarAcopio")
        Else
            Me.IdLugarAcopio = 0
        End If
        DataSet.Tables("BuscaLocalidad").Reset()


        '///////////////////////////////////////////////LUGAR ACOPIO ///////////////////////////////////////////////////////
        SqlString = "SELECT  Cosecha.* FROM Cosecha WHERE(IdCosecha = " & CodigoCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count <> 0 Then
            PeriodoCosecha = Year(CDate(DataSet.Tables("Cosecha").Rows(0)("FechaInicial"))) & "-" & Year(CDate(DataSet.Tables("Cosecha").Rows(0)("FechaFinal")))
        Else
            Me.IdLugarAcopio = 0
        End If
        DataSet.Tables("Cosecha").Reset()


        SqlString = "SELECT LiquidacionPergamino.Codigo, LiquidacionPergamino.Precio, Round((DetalleDistribucion.Monto * TipoCambio.TipoCambio) / DetalleLiquidacionPergamino.PesoNeto, 2) AS PrecioNeto, Round(DetalleDistribucion.Monto *  TipoCambio.TipoCambio, 2) As Monto, DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.IdLocalidad, LiquidacionPergamino.ReportadoDistribucion, LiquidacionPergamino.NumeroReportado, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombres, TipoCompra.Nombre AS TipoCompra, LiquidacionPergamino.IdLiquidacionPergamino FROM LiquidacionPergamino INNER JOIN DetalleDistribucion ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleDistribucion.IdLiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor  INNER JOIN  TipoCompra ON LiquidacionPergamino.IdTipoCompra = TipoCompra.IdECS  INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio WHERE (CASE WHEN LiquidacionPergamino.ReportadoDistribucion IS NULL THEN 0 ELSE LiquidacionPergamino.ReportadoDistribucion END = 0) AND (LiquidacionPergamino.IdLocalidad = " & Me.IdLugarAcopio & ") ORDER BY TipoCompra, LiquidacionPergamino.Codigo"
        Sql.ConnectionString = Conexion
        SQL.SQL = SqlString


        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")

        ArepReporteDetalleLiquidacion.Registros = DataSet.Tables("Consulta").Rows.Count

        ArepReporteDetalleLiquidacion.LblNumero.Text = "NUMERO: " & Numero
        ArepReporteDetalleLiquidacion.LblFecha.Text = "Fecha: " & Format(Now, "dd/MM/yyyy")
        ArepReporteDetalleLiquidacion.LblCosecha.Text = "Cosecha: " & PeriodoCosecha
        ArepReporteDetalleLiquidacion.LblLocalidad.Text = "Localidad: " & Me.CboLocalidad.Text

        Dim ViewerForm As New FrmViewer()
        ViewerForm.arvMain.Document = ArepReporteDetalleLiquidacion.Document
        ArepReporteDetalleLiquidacion.DataSource = SQL
        ArepReporteDetalleLiquidacion.Run(False)
        ViewerForm.Show()
        My.Application.DoEvents()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click

        If Me.ChkTodosLosProcesos.Checked = True Then
            LlenadoGrid("Todo")
        ElseIf Me.ChkTodasLocalidades.Checked = False Then
            If Me.CboLocalidad.Text = "" Then
                LlenadoGrid("Fecha")
            Else
                LlenadoGrid("Lugar")
            End If

        Else
            LlenadoGrid("Lugar")

        End If




    End Sub

    Private Sub ChkTodosLosProcesos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodosLosProcesos.CheckedChanged
        If Me.ChkTodosLosProcesos.Checked = True Then
            Me.ChkTodasLocalidades.Checked = False
        End If
    End Sub

    Private Sub ChkTodasLocalidades_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodasLocalidades.CheckedChanged
        If Me.ChkTodasLocalidades.Checked = True Then
            Me.ChkTodosLosProcesos.Checked = False
        End If
    End Sub
End Class