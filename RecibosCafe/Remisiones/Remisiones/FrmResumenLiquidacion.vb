Public Class FrmResumenLiquidacion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    'Base de datos 
    Public sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String, Pendiente As Boolean = False
    Public mes As String, anualidad As String, unidadmedida As String, calidad As String, Ruta As String, LeeArchivo As String, Localidad As Integer

 
    Private Sub FrmPendientesLiquid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If

        sql = "SELECT IdLugarAcopio FROM     LugarAcopio  WHERE   (CodLugarAcopio = " & LeeArchivo & ") AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "localidad")
        Localidad = DataSet.Tables("localidad").Rows(0)("IdLugarAcopio")

        Me.CboMeses.Text = Me.CboMeses.Items(0)

        sql = "SELECT DISTINCT YEAR(Fecha) AS Anualidad   FROM LiquidacionPergamino"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ResumenLiquidaAnual")
        Me.CboAnoRL.DisplayMember = "Anualidad"
        If DataSet.Tables("ResumenLiquidaAnual").Rows.Count = 0 Then
            'MsgBox("NO SE ENCONTRARON AÑOS", MsgBoxStyle.Critical, "LiquidacionResumen")
        Else
            Me.CboAnoRL.Text = DataSet.Tables("ResumenLiquidaAnual").Rows(0)("Anualidad")
            Me.CboAnoRL.DataSource = DataSet.Tables("ResumenLiquidaAnual")
        End If

        sql = "SELECT DISTINCT UnidadMedida.Descripcion   FROM  ReciboCafePergamino INNER JOIN  DetalleLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino INNER JOIN LiquidacionPergamino ON DetalleLiquidacionPergamino.IdLiquidacionPergamino = LiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida   "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ResumenLiquidaUnidad")
        Me.CboUnidadRL.DisplayMember = "Descripcion"
        If DataSet.Tables("ResumenLiquidaUnidad").Rows.Count = 0 Then
            'MsgBox("NO SE ENCONTRARON UNIDADES DE MEDIDA", MsgBoxStyle.Critical, "LiquidacionResumen")
        Else
            Me.CboUnidadRL.DataSource = DataSet.Tables("ResumenLiquidaUnidad")
            Me.CboUnidadRL.Text = DataSet.Tables("ResumenLiquidaUnidad").Rows(0)("Descripcion")
            Me.CboUnidadRL.Splits.Item(0).DisplayColumns(0).Width = 100
            'Me.CboUnidadRL.Splits.Item(0).DisplayColumns().Visible = False
        End If

        sql = "SELECT DISTINCT Calidad.NomCalidad  FROM Calidad INNER JOIN  ReciboCafePergamino ON Calidad.IdCalidad = ReciboCafePergamino.IdCalidad INNER JOIN  DetalleLiquidacionPergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleLiquidacionPergamino.IdReciboPergamino INNER JOIN LiquidacionPergamino ON DetalleLiquidacionPergamino.IdLiquidacionPergamino = LiquidacionPergamino.IdLiquidacionPergamino "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ResumenLiquidaCalidad")
        Me.CboCalidadRL.DisplayMember = "NomCalidad"
        If DataSet.Tables("ResumenLiquidaCalidad").Rows.Count = 0 Then
            'MsgBox("NO SE ENCONTRARON CALIDADES", MsgBoxStyle.Critical, "LiquidacionResumen")
        Else
            Me.CboCalidadRL.DataSource = DataSet.Tables("ResumenLiquidaCalidad")
            Me.CboCalidadRL.Text = DataSet.Tables("ResumenLiquidaCalidad").Rows(0)("NomCalidad")
        End If

        If UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then  ' UsuarioType = "AutorizaPrecioDiscrecionalidad" Or
            sql = "SELECT DISTINCT  TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie2, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad,  SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor,   LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto,     SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol,    SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol FROM   LiquidacionPergamino INNER JOIN     TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN                          DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN                          ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN                          EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN                          TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie ORDER BY LiquidacionPergamino.Fecha DESC  "
        Else
            sql = "SELECT DISTINCT TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie2, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones,  SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol, SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol,  LiquidacionPergamino.IdLocalidad, LugarAcopio.IdLugarAcopio, LugarAcopio.IdRegion FROM LiquidacionPergamino INNER JOIN  TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN  EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones, TipoCambio.TipoCambio, LiquidacionPergamino.Serie2, LiquidacionPergamino.IdLocalidad, LugarAcopio.IdLugarAcopio, LugarAcopio.IdRegion HAVING(LugarAcopio.IdRegion = " & IdRegionUsuario & ") ORDER BY LiquidacionPergamino.Fecha DESC"
            'sql = "SELECT DISTINCT  TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad,  SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor,   LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto,     SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol,    SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, LiquidacionPergamino.IdLocalidad FROM    LiquidacionPergamino INNER JOIN      TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN                          DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN                          ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN                          EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN                          TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie, LiquidacionPergamino.IdLocalidad HAVING        (LiquidacionPergamino.IdLocalidad = '" & Localidad & "') ORDER BY LiquidacionPergamino.Fecha DESC  "
        End If

        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ResumenLiquida")
        If DataSet.Tables("ResumenLiquida").Rows.Count <> 0 Then
            'MsgBox("NO SE ENCONTRARON LIQUIDACIONES", MsgBoxStyle.Critical, "LiquidacionResumen")
            Me.BindingResumenLiqui.DataSource = DataSet.Tables("ResumenLiquida")
            Me.TDGridResumenLiquidacion.DataSource = Me.BindingResumenLiqui
        Else
            Me.BindingResumenLiqui.DataSource = DataSet.Tables("ResumenLiquida")
            Me.TDGridResumenLiquidacion.DataSource = Me.BindingResumenLiqui
        End If

        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(11).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(12).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(13).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(14).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(15).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(16).Locked = True

        Me.TDGridResumenLiquidacion.Columns(11).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(12).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(13).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(14).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(15).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(16).NumberFormat = "##,##0.00"

        Me.TDGridResumenLiquidacion.Columns(1).Caption = "Nº"
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Width = 150
        Me.TDGridResumenLiquidacion.Columns(0).Caption = "Tipo Ingreso"
        Me.TDGridResumenLiquidacion.Columns(3).Caption = "Numero Reembolso"
        Me.TDGridResumenLiquidacion.Columns(5).Caption = "Calidad"
        Me.TDGridResumenLiquidacion.Columns(8).Caption = "Id"
        Me.TDGridResumenLiquidacion.Columns(9).Caption = "Nombre"
        Me.TDGridResumenLiquidacion.Columns("ValorBruto").Caption = "V.Bruto"
        Me.TDGridResumenLiquidacion.Columns(12).Caption = "Deducciones"
        Me.TDGridResumenLiquidacion.Columns(13).Caption = "Neto"
        Me.TDGridResumenLiquidacion.Columns(14).Caption = "V.Bruto$"
        Me.TDGridResumenLiquidacion.Columns(15).Caption = "Deducciones$"
        Me.TDGridResumenLiquidacion.Columns(16).Caption = "Neto$"



        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(5).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(6).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(7).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(8).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(9).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(11).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(12).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(13).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(14).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(15).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(16).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Style.ForeColor = Color.Blue
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Style.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Underline)
        Me.TDGridResumenLiquidacion.RowHeight = 20

    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        My.Forms.FrmLiquidacion.Show()
    End Sub


    Public Sub Refresh()

        Dim DataSet1 As New DataSet

        'If UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then  'UsuarioType = "AutorizaPrecioDiscrecionalidad" Or
        '    'sql = "SELECT DISTINCT    TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad,  SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, CASE WHEN Proveedor.Cod_Proveedor = '00001' THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS NombreProveedor,   LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones,                           SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto,     SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol,    SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol FROM   LiquidacionPergamino INNER JOIN     TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN                          DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN                          ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN                          EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN                          TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie ORDER BY LiquidacionPergamino.Fecha DESC  "
        '    sql = "SELECT DISTINCT TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, CASE WHEN Proveedor.Cod_Proveedor = '00001' THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto)  AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol, SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.EsProductorManual FROM  LiquidacionPergamino INNER JOIN TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones, TipoCambio.TipoCambio, LiquidacionPergamino.Serie, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.EsProductorManual  ORDER BY LiquidacionPergamino.Fecha DESC"
        'Else
        '    'sql = "SELECT DISTINCT TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, CASE WHEN Proveedor.Cod_Proveedor = '00001' THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol, SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.EsProductorManual FROM LiquidacionPergamino INNER JOIN TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio ROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones, TipoCambio.TipoCambio, LiquidacionPergamino.Serie, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.EsProductorManual, LiquidacionPergamino.IdLocalidad HAVING (LiquidacionPergamino.IdLocalidad = '" & Localidad & "') ORDER BY LiquidacionPergamino.Fecha DESC"
        '    sql = "SELECT DISTINCT TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha,  Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, CASE WHEN Proveedor.Cod_Proveedor = '00001' THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol, SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.EsProductorManual FROM LiquidacionPergamino INNER JOIN TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones, TipoCambio.TipoCambio, LiquidacionPergamino.Serie, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.EsProductorManual, LiquidacionPergamino.IdLocalidad HAVING(LiquidacionPergamino.IdLocalidad = '" & Localidad & "') ORDER BY LiquidacionPergamino.Fecha DESC"
        'End If

        If UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then  ' UsuarioType = "AutorizaPrecioDiscrecionalidad" Or
            sql = "SELECT DISTINCT  TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie2, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad,  SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor,   LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto,     SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol,    SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol FROM   LiquidacionPergamino INNER JOIN     TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN                          DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN                          ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN                          EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN                          TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie2 ORDER BY LiquidacionPergamino.Fecha DESC  "
        Else
            sql = "SELECT DISTINCT TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie2, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones,  SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol, SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol,  LiquidacionPergamino.IdLocalidad, LugarAcopio.IdLugarAcopio, LugarAcopio.IdRegion FROM LiquidacionPergamino INNER JOIN  TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN  EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones, TipoCambio.TipoCambio, LiquidacionPergamino.Serie2, LiquidacionPergamino.IdLocalidad, LugarAcopio.IdLugarAcopio, LugarAcopio.IdRegion HAVING(LugarAcopio.IdRegion = " & IdRegionUsuario & ") ORDER BY LiquidacionPergamino.Fecha DESC"
            'sql = "SELECT DISTINCT  TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad,  SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor,   LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto,     SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol,    SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, LiquidacionPergamino.IdLocalidad FROM    LiquidacionPergamino INNER JOIN      TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN                          DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN                          ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN                          EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN                          TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie, LiquidacionPergamino.IdLocalidad HAVING        (LiquidacionPergamino.IdLocalidad = '" & Localidad & "') ORDER BY LiquidacionPergamino.Fecha DESC  "
        End If


        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet1, "ResumenLiquidaRefres")
        If DataSet1.Tables("ResumenLiquidaRefres").Rows.Count = 0 Then
            MsgBox("NO SE ENCONTRARON LIQUIDACIONES", MsgBoxStyle.Critical, "ResumenLiquidaRefres")
            Me.BindingResumenLiqui.DataSource = DataSet1.Tables("ResumenLiquidaRefres")
            Me.TDGridResumenLiquidacion.DataSource = Me.BindingResumenLiqui
        Else
            Me.BindingResumenLiqui.DataSource = DataSet1.Tables("ResumenLiquidaRefres")
            Me.TDGridResumenLiquidacion.DataSource = Me.BindingResumenLiqui
        End If

        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(11).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(12).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(13).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(14).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(15).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(16).Locked = True

        Me.TDGridResumenLiquidacion.Columns(11).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(12).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(13).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(14).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(15).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(16).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(1).Caption = "Nº"
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Width = 150
        Me.TDGridResumenLiquidacion.Columns(0).Caption = "Tipo Ingreso"
        Me.TDGridResumenLiquidacion.Columns(3).Caption = "Numero Reembolso"
        Me.TDGridResumenLiquidacion.Columns(5).Caption = "Calidad"
        Me.TDGridResumenLiquidacion.Columns(8).Caption = "Id"
        Me.TDGridResumenLiquidacion.Columns(9).Caption = "Nombre"
        Me.TDGridResumenLiquidacion.Columns("ValorBruto").Caption = "V.Bruto"
        Me.TDGridResumenLiquidacion.Columns(12).Caption = "Deducciones"
        Me.TDGridResumenLiquidacion.Columns(13).Caption = "Neto"
        Me.TDGridResumenLiquidacion.Columns(14).Caption = "V.Bruto$"
        Me.TDGridResumenLiquidacion.Columns(15).Caption = "Deducciones$"
        Me.TDGridResumenLiquidacion.Columns(16).Caption = "Neto$"



        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(5).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(6).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(7).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(8).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(9).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(11).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(12).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(13).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(14).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(15).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(16).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Style.ForeColor = Color.Blue
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Style.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Underline)
        Me.TDGridResumenLiquidacion.RowHeight = 20
    End Sub
    Private Sub RbPorMeses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbPorMeses.CheckedChanged
        Me.DTPFechaInicial.Enabled = False
        Me.DTPFechaFinal.Enabled = False
        Me.CboMeses.Enabled = True
        Me.CboAnoRL.Enabled = True
    End Sub
    Private Sub RbPorRango_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbPorRango.CheckedChanged
        Me.CboMeses.Enabled = False
        Me.CboAnoRL.Enabled = False
        Me.DTPFechaInicial.Enabled = True
        Me.DTPFechaFinal.Enabled = True
    End Sub
    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Dim DataSetFiltro As New DataSet
        'UnidadMedida.Descripcion AS UnidMedida,

        If UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then  'UsuarioType = "AutorizaPrecioDiscrecionalidad" Or
            If Me.RbPorMeses.Checked = True Then
                sql = "SELECT DISTINCT TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones,SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol, SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, LiquidacionPergamino.IdLocalidad FROM  LiquidacionPergamino INNER JOIN  TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN  EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN   TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie, LiquidacionPergamino.IdLocalidad, UnidadMedida.Descripcion , LugarAcopio.IdLugarAcopio, LugarAcopio.IdRegion  HAVING  (LugarAcopio.IdRegion = " & IdRegionUsuario & ") AND (YEAR(LiquidacionPergamino.Fecha) = " & Me.CboAnoRL.Text & ") AND (DATENAME(mm, LiquidacionPergamino.Fecha) = '" & Me.CboMeses.Text & "') AND (Calidad.NomCalidad = '" & Me.CboCalidadRL.Text & "') AND (UnidadMedida.Descripcion = '" & Me.CboUnidadRL.Text & "')ORDER BY LiquidacionPergamino.Fecha DESC"
            ElseIf Me.RbPorRango.Checked = True Then
                sql = "SELECT DISTINCT TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol, SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, LiquidacionPergamino.IdLocalidad FROM LiquidacionPergamino INNER JOIN  TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN  EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie, LiquidacionPergamino.IdLocalidad, UnidadMedida.Descripcion , LugarAcopio.IdLugarAcopio, LugarAcopio.IdRegion  HAVING  (LugarAcopio.IdRegion = " & IdRegionUsuario & ") AND (LiquidacionPergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(CDate(Me.DTPFechaInicial.Text), "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(CDate(Me.DTPFechaFinal.Text), "yyyy-MM-dd") & " 23:59:59', 102))  AND (Calidad.NomCalidad = '" & Me.CboCalidadRL.Text & "') AND (UnidadMedida.Descripcion = '" & Me.CboUnidadRL.Text & "')ORDER BY LiquidacionPergamino.Fecha DESC"
            End If
        Else
            If Me.RbPorMeses.Checked = True Then
                sql = "SELECT DISTINCT TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto,  SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol,  SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, LiquidacionPergamino.IdLocalidad FROM LiquidacionPergamino INNER JOIN   TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN  ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN  EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio INNER JOIN  UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie, LiquidacionPergamino.IdLocalidad, UnidadMedida.Descripcion , LugarAcopio.IdLugarAcopio, LugarAcopio.IdRegion HAVING  (LugarAcopio.IdRegion = " & IdRegionUsuario & ") AND (LiquidacionPergamino.IdLocalidad = '" & Localidad & "') AND (YEAR(LiquidacionPergamino.Fecha) = " & Me.CboAnoRL.Text & ") AND (DATENAME(mm, LiquidacionPergamino.Fecha) = '" & Me.CboMeses.Text & "') AND (Calidad.NomCalidad = '" & Me.CboCalidadRL.Text & "') AND (UnidadMedida.Descripcion = '" & Me.CboUnidadRL.Text & "')ORDER BY LiquidacionPergamino.Fecha DESC"
            ElseIf Me.RbPorRango.Checked = True Then
                sql = "SELECT DISTINCT  TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, LiquidacionPergamino.IdLiquidacionPergamino, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto) AS ValorBruto, LiquidacionPergamino.TotalDeducciones, SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) AS PesoNeto,  SUM(LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio) AS ValorDolares, SUM(LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio) AS DeduccionesDol, SUM((LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio) AS PesoNetoDol, LiquidacionPergamino.IdLocalidad FROM LiquidacionPergamino INNER JOIN   TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN   Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, LiquidacionPergamino.TotalDeducciones,                           TipoCambio.TipoCambio, LiquidacionPergamino.Serie, LiquidacionPergamino.IdLocalidad, UnidadMedida.Descripcion , LugarAcopio.IdLugarAcopio, LugarAcopio.IdRegion HAVING (LugarAcopio.IdRegion = " & IdRegionUsuario & ") AND (LiquidacionPergamino.IdLocalidad = '" & Localidad & "') AND  (LiquidacionPergamino.Fecha BETWEEN CONVERT(DATETIME, '" & Format(CDate(Me.DTPFechaInicial.Text), "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(CDate(Me.DTPFechaFinal.Text), "yyyy-MM-dd") & " 23:59:59', 102))  AND (Calidad.NomCalidad = '" & Me.CboCalidadRL.Text & "') AND (UnidadMedida.Descripcion = '" & Me.CboUnidadRL.Text & "')ORDER BY LiquidacionPergamino.Fecha DESC"
            End If
        End If


        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSetFiltro, "FiltroLiquida")
        If DataSetFiltro.Tables("FiltroLiquida").Rows.Count = 0 Then
            MsgBox("NO SE ENCONTRARON LIQUIDACIONES", MsgBoxStyle.Critical, "LiquidacionResumen")
        Else
            Me.BindingResumenLiqui.DataSource = DataSetFiltro.Tables("FiltroLiquida")
            Me.TDGridResumenLiquidacion.DataSource = Me.BindingResumenLiqui
        End If


        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(7).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(11).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(12).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(13).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(14).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(15).Locked = True
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(16).Locked = True

        Me.TDGridResumenLiquidacion.Columns(11).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(12).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(13).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(14).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(15).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(16).NumberFormat = "##,##0.00"
        Me.TDGridResumenLiquidacion.Columns(1).Caption = "Nº"
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Width = 150
        Me.TDGridResumenLiquidacion.Columns(0).Caption = "Tipo Ingreso"
        Me.TDGridResumenLiquidacion.Columns(3).Caption = "Numero Reembolso"
        Me.TDGridResumenLiquidacion.Columns(5).Caption = "Calidad"
        Me.TDGridResumenLiquidacion.Columns(8).Caption = "Id"
        Me.TDGridResumenLiquidacion.Columns(9).Caption = "Nombre"
        Me.TDGridResumenLiquidacion.Columns("ValorBruto").Caption = "V.Bruto"
        Me.TDGridResumenLiquidacion.Columns(12).Caption = "Deducciones"
        Me.TDGridResumenLiquidacion.Columns(13).Caption = "Neto"
        Me.TDGridResumenLiquidacion.Columns(14).Caption = "V.Bruto$"
        Me.TDGridResumenLiquidacion.Columns(15).Caption = "Deducciones$"
        Me.TDGridResumenLiquidacion.Columns(16).Caption = "Neto$"



        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(5).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(6).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(7).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(8).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(9).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(10).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(11).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(12).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(13).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(14).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(15).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(16).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Style.ForeColor = Color.Blue
        Me.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns(1).Style.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Underline)
        Me.TDGridResumenLiquidacion.RowHeight = 20
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Quien2 = "Nuevo"
        My.Forms.FrmLiquidacion.ShowDialog()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Hide()
        My.Forms.FrmLiquidacion.Close()
    End Sub
    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim Posicion As Integer, IdLi As String, CodigoLi As String

        Quien3 = "Ver"
        Quien2 = "NoJustifica"
        Posicion = Me.BindingResumenLiqui.Position()
        If Posicion < 0 Then
            MsgBox("NO HAY LIQUIDACIONES SELECCIONADO", MsgBoxStyle.Information, "Resumen Liquidacion")
            Exit Sub
        Else
            CodigoLi = Me.BindingResumenLiqui.Item(Posicion)("Codigo")
            IdLi = Me.BindingResumenLiqui.Item(Posicion)("IdLiquidacionPergamino")
        End If

        My.Forms.FrmLiquidacion.Show()
        My.Forms.FrmLiquidacion.TxtIdLiquidacion.Text = IdLi
        My.Forms.FrmLiquidacion.TxtCodigoCompleto.Text = CodigoLi





    End Sub
    Private Sub TDGridResumenLiquidacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridResumenLiquidacion.DoubleClick
        If Pendiente = False Then
            Pendiente = True
            BtnVer_Click(sender, e)
            Pendiente = False
        End If
    End Sub

    Private Sub TDGridResumenLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridResumenLiquidacion.Click

    End Sub

    Private Sub BtnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefrescar.Click
        'Dim DataSet1 As New DataSet
        'sql = "SELECT DISTINCT    TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.Serie, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad,                          SUM(DetalleLiquidacionPergamino.PesoNeto) AS Cantidad, EstadoDocumento.Descripcion AS Estado, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor,                          LiquidacionPergamino.IdLiquidacionPergamino, LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto AS ValorBruto, LiquidacionPergamino.TotalDeducciones,                            LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones AS PesoNeto,                           LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto / TipoCambio.TipoCambio AS ValorDolares, LiquidacionPergamino.TotalDeducciones / TipoCambio.TipoCambio AS DeduccionesDol,                           (LiquidacionPergamino.Precio * DetalleLiquidacionPergamino.PesoNeto - LiquidacionPergamino.TotalDeducciones) / TipoCambio.TipoCambio AS PesoNetoDol FROM            LiquidacionPergamino INNER JOIN                          TipoIngreso ON LiquidacionPergamino.IdTipoIngreso = TipoIngreso.IdECS INNER JOIN                          DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN                          ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN                          EstadoDocumento ON LiquidacionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          Proveedor ON LiquidacionPergamino.Cod_Proveedor = Proveedor.IdProductor INNER JOIN                          TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio GROUP BY TipoIngreso.Descripcion, LiquidacionPergamino.Codigo, LiquidacionPergamino.NumeroReembolso, LiquidacionPergamino.Fecha, Calidad.NomCalidad, EstadoDocumento.Descripcion, LiquidacionPergamino.Cod_Proveedor,                           Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor, LiquidacionPergamino.IdLiquidacionPergamino, Proveedor.Cod_Proveedor, LiquidacionPergamino.Precio, DetalleLiquidacionPergamino.PesoNeto,                           LiquidacionPergamino.TotalDeducciones, TipoCambio.TipoCambio, LiquidacionPergamino.Serie ORDER BY TipoIngreso.Descripcion  "
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet1, "ResumenLiquidaRefres")
        'If DataSet1.Tables("ResumenLiquidaRefres").Rows.Count = 0 Then
        '    MsgBox("NO SE ENCONTRARON LIQUIDACIONES", MsgBoxStyle.Critical, "ResumenLiquidaRefres")
        '    Me.BindingResumenLiqui.DataSource = DataSet1.Tables("ResumenLiquidaRefres")
        '    Me.TDGridResumenLiquidacion.DataSource = Me.BindingResumenLiqui
        'Else
        '    Me.BindingResumenLiqui.DataSource = DataSet1.Tables("ResumenLiquidaRefres")
        '    Me.TDGridResumenLiquidacion.DataSource = Me.BindingResumenLiqui
        'End If
        Refresh()
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub CboAnoRL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAnoRL.TextChanged

    End Sub
End Class