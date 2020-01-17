Public Class FrmResumenCalculoPrecio
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    'Base de datos 
    Public sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
    Public mes As String, anualidad As String, unidadmedida As String, calidad As String
    Private Sub FrmResumenCalculoPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT CONVERT(Nvarchar, YEAR(Cosecha.FechaInicial)) + '-' + CONVERT(Nvarchar, YEAR(Cosecha.FechaFinal)) AS Cosecha, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, RangoImperfeccion.Nombre AS Categoria, PrecioComplemento.Precio, PrecioComplemento.Corte, PrecioComplemento.FechaActualizacion  FROM   PrecioComplemento INNER JOIN     Cosecha ON PrecioComplemento.IdCosecha = Cosecha.IdCosecha INNER JOIN  LugarAcopio ON PrecioComplemento.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN   Calidad ON PrecioComplemento.IdCalidad = Calidad.IdCalidad INNER JOIN  RangoImperfeccion ON PrecioComplemento.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion  WHERE (LugarAcopio.IdRegion = " & IdRegionUsuario & ") ORDER BY PrecioComplemento.FechaActualizacion DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ResumenCalPrecio")
        Me.TrueDBHistoricoCPrecio.DataSource = DataSet.Tables("ResumenCalPrecio")
        Me.TrueDBHistoricoCPrecio.Styles("Normal").Font = New Font(Me.TrueDBHistoricoCPrecio.Styles("Normal").Font.FontFamily, 11)
        Me.TrueDBHistoricoCPrecio.RowHeight = 20
        Me.TrueDBHistoricoCPrecio.Splits.Item(0).DisplayColumns("Localidad").Width = 300
        Me.TrueDBHistoricoCPrecio.Columns("FechaActualizacion").NumberFormat = "yyyy-MM-dd HH:mm:ss"
        Me.TrueDBHistoricoCPrecio.Splits.Item(0).DisplayColumns("FechaActualizacion").Width = 200
    End Sub

    Private Sub BtnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefrescar.Click
        RefreshNew()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.Hide()
        My.Forms.FrmCalculoPrecio.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Public Sub RefreshNew()
        Dim DataSet1 As New DataSet
        sql = "SELECT CONVERT(Nvarchar, YEAR(Cosecha.FechaInicial)) + '-' + CONVERT(Nvarchar, YEAR(Cosecha.FechaFinal)) AS Cosecha, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, RangoImperfeccion.Nombre AS Categoria, PrecioComplemento.Precio, PrecioComplemento.Corte, PrecioComplemento.FechaActualizacion  FROM   PrecioComplemento INNER JOIN     Cosecha ON PrecioComplemento.IdCosecha = Cosecha.IdCosecha INNER JOIN  LugarAcopio ON PrecioComplemento.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN   Calidad ON PrecioComplemento.IdCalidad = Calidad.IdCalidad INNER JOIN  RangoImperfeccion ON PrecioComplemento.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion  WHERE (LugarAcopio.IdRegion = " & IdRegionUsuario & ") ORDER BY PrecioComplemento.FechaActualizacion DESC"
        'sql = "SELECT CONVERT(Nvarchar, YEAR(Cosecha.FechaInicial)) + '-' + CONVERT(Nvarchar, YEAR(Cosecha.FechaFinal)) AS Cosecha, LugarAcopio.NomLugarAcopio AS Localidad, Calidad.NomCalidad AS Calidad, RangoImperfeccion.Nombre AS Categoria, PrecioComplemento.Precio, PrecioComplemento.Corte, PrecioComplemento.FechaActualizacion  FROM   PrecioComplemento INNER JOIN     Cosecha ON PrecioComplemento.IdCosecha = Cosecha.IdCosecha INNER JOIN  LugarAcopio ON PrecioComplemento.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN   Calidad ON PrecioComplemento.IdCalidad = Calidad.IdCalidad INNER JOIN  RangoImperfeccion ON PrecioComplemento.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion  ORDER BY PrecioComplemento.FechaActualizacion DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet1, "ResumenCalPrecio")
        Me.TrueDBHistoricoCPrecio.DataSource = DataSet1.Tables("ResumenCalPrecio")
        Me.TrueDBHistoricoCPrecio.Styles("Normal").Font = New Font(Me.TrueDBHistoricoCPrecio.Styles("Normal").Font.FontFamily, 11)
        Me.TrueDBHistoricoCPrecio.RowHeight = 20
        Me.TrueDBHistoricoCPrecio.Splits.Item(0).DisplayColumns("Localidad").Width = 300
        Me.TrueDBHistoricoCPrecio.Columns("FechaActualizacion").NumberFormat = "yyyy-MM-dd HH:mm:ss"
        Me.TrueDBHistoricoCPrecio.Splits.Item(0).DisplayColumns("FechaActualizacion").Width = 200


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Forms.FrmPrecioCorteLocalidad.ShowDialog()
        Me.BtnRefrescar_Click(sender, e)
    End Sub
End Class