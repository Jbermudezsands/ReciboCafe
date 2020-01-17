Imports System.Data.SqlClient

Public Class FrmCalculoPrecio
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdCalidad As Double, IdCategoria As Double, IdEstadoFisico As Double, IdDaño As Double, IdRegion As Double
    Public PrecioComplemento As Double, NumCorte As Integer, PrecioAutoriza As Double, DataSetComplemento As New DataSet


    Private Sub FrmCalculoPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim Ruta As String, LeeArchivo As String
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, i As Integer, count As Double, TipoImp As String
        Dim Registros As Double, Cadena As String


        'sql = "SELECT RelacionTipoDocumentoxCalidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN TipoCafe ON RelacionTipoDocumentoxCalidad.IdtipoDocumento = TipoCafe.IdTipoCafe INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad " & _
        '      "WHERE(RelacionTipoDocumentoxCalidad.IdtipoDocumento = 1)"
        sql = "SELECT IdCalidad, NomCalidad, VDImperfeccion  FROM Calidad  WHERE (Not (VDImperfeccion Is NULL))"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Calidad")
        Me.CboTipoCalidad.DisplayMember = "NomCalidad"
        Me.CboTipoCalidad.DataSource = DataSet.Tables("Calidad")
        Me.CboTipoCalidad.Text = DataSet.Tables("Calidad").Rows(0)("NomCalidad")

        sql = "SELECT  Descripcion   FROM  EstadoFisico"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "EdoFisico")
        Me.CboEdofisico.DisplayMember = "Descripcion"
        Me.CboEdofisico.DataSource = DataSet.Tables("EdoFisico")
        Me.CboEdofisico.Text = DataSet.Tables("EdoFisico").Rows(0)("Descripcion")

        sql = "SELECT  Nombre   FROM RangoImperfeccion"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Imperfeccion")
        Me.CboImperfeccion.DisplayMember = "Nombre"
        Me.CboImperfeccion.DataSource = DataSet.Tables("Imperfeccion")
        Me.CboImperfeccion.Text = DataSet.Tables("Imperfeccion").Rows(0)("Nombre")

        Registros = DataSet.Tables("Imperfeccion").Rows.Count
        i = 0
        Me.CboCosecha.ResetText()
        Do While Registros > i
            Cadena = "Atlantic " & DataSet.Tables("Imperfeccion").Rows(i)("Nombre")
            Me.CboPrecio.Items.Add(Cadena)
            i = i + 1
        Loop

        sql = "SELECT  Nombre   FROM  Dano"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Dano")
        Me.CboTipDano.DisplayMember = "Nombre"
        Me.CboTipDano.DataSource = DataSet.Tables("Dano")
        Me.CboTipDano.Text = DataSet.Tables("Dano").Rows(0)("Nombre")

        sql = "SELECT IdCosecha, CodCosecha,CONVERT(Nvarchar, YEAR(Cosecha.FechaInicial)) + '-' + CONVERT(Nvarchar, YEAR(Cosecha.FechaFinal)) AS Cosecha FROM Cosecha  WHERE (IdCosecha <= " & CodigoCosecha & ") ORDER BY CodCosecha DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        Me.CboCosecha.DataSource = DataSet.Tables("Cosecha")
        Me.CboCosecha.DisplayMember = "Cosecha"
        Me.CboCosecha.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.CboCosecha.Splits.Item(0).DisplayColumns(0).Width = 297
        Me.CboCosecha.Text = DataSet.Tables("Cosecha").Rows(0)("Cosecha")

        'sql = "SELECT        IdRegion, Nombre, NombreCorto   FROM            Region  WHERE        (IdRegion = '" & IdRegionUsuario & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "Region2")
        'If DataSet.Tables("Region2").Rows.Count = 0 Then
        '    Me.LblRegiondiscre.Text = "No region"
        'Else
        '    Me.LblRegiondiscre.Text = DataSet.Tables("Region2").Rows(0)("Nombre")
        'End If
        Me.GroupBox1.Enabled = False
        'Me.CheckDatos.Checked = False
        Me.GroupBox3.Visible = False
        Me.Button1.Enabled = False
    End Sub
    Private Function ComplementoPrecio(ByVal IdLugarAcopio As Double, ByVal IdCalidad As Double, ByVal Categoria As String, ByVal IdRegion As Double, ByVal IdCosecha As Double) As Double
        Dim SqlString As String
        Dim Adapter As New SqlDataAdapter, DataSet As New DataSet, Registros As Double, i As Double, FechaCorte As Date

        ''////////////////////////////////////////////////BUSCO LA REGIO ////////////////////////////////////////////////////////
        'SqlString = "SELECT  LugarAcopio.* FROM LugarAcopio  WHERE(IdLugarAcopio = " & IdLugarAcopio & ")"
        'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'Adapter.Fill(DataSet, "LugarAcopio")
        'If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
        '    IdRegion = DataSet.Tables("LugarAcopio").Rows(0)("IdRegion")
        'End If

        FechaCorte = Now
        '//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
        SqlString = "SELECT  DiferencialPrecioPergamino.IdDiferencialPrecioPergamino, DiferencialPrecioPergamino.Fecha, DiferencialPrecioPergamino.Monto, DiferencialPrecioPergamino.IdRangoImperfeccion, DiferencialPrecioPergamino.IdCalidad, DiferencialPrecioPergamino.IdRegion, DiferencialPrecioPergamino.IdCosecha, DiferencialPrecioPergamino.FechaActualizacion, DiferencialPrecioPergamino.IdUsuarioEcs, DiferencialPrecioPergamino.IdDiferencialECS FROM  DiferencialPrecioPergamino INNER JOIN  Moneda ON DiferencialPrecioPergamino.IdMoneda = Moneda.IdMoneda INNER JOIN  RangoImperfeccion ON DiferencialPrecioPergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion  " & _
                    "WHERE   (Moneda.Nombre = 'Córdoba') AND (RangoImperfeccion.Nombre = '" & Categoria & "') AND (DiferencialPrecioPergamino.IdRegion = " & IdRegion & ") AND  (DiferencialPrecioPergamino.IdCalidad = " & IdCalidad & ") AND (DiferencialPrecioPergamino.IdCosecha = " & IdCosecha & ") AND (FechaActualizacion  BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY DiferencialPrecioPergamino.FechaActualizacion  DESC"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "ConsultaA")
        ComplementoPrecio = 0
        If DataSet.Tables("ConsultaA").Rows.Count <> 0 Then
            ComplementoPrecio = DataSet.Tables("ConsultaA").Rows(0)("Monto")
        Else
            ComplementoPrecio = 0.0
            'Me.LblPrecioDiscre.Text = Format(ComplementoPrecio, "####0.00")
        End If
    End Function
    Private Function Precio(ByVal IdLugarAcopio As Double, ByVal IdCalidad As Double, ByVal Categoria As String) As Double
        Dim SqlString As String
        Dim Adapter As New SqlDataAdapter, DataSet As New DataSet, Registros As Double, i As Double
        Dim FechaCorte As Date

        FechaCorte = Now
        '//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
        SqlString = "SELECT PrecioCafe.IdPrecioCafe, PrecioCafe.IdLocalidad, PrecioCafe.IdCalidad, PrecioCafe.IdRangoImperfeccion, PrecioCafe.Precio, PrecioCafe.FechaActualizacion,  RangoImperfeccion.Nombre FROM PrecioCafe INNER JOIN RangoImperfeccion ON PrecioCafe.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE  (PrecioCafe.IdLocalidad = " & IdLugarAcopio & ") AND (PrecioCafe.IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = '" & Categoria & "') AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY RangoImperfeccion.Nombre, PrecioCafe.FechaActualizacion DESC"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "ConsultaA")
        Precio = 0
        If DataSet.Tables("ConsultaA").Rows.Count <> 0 Then
            Precio = DataSet.Tables("ConsultaA").Rows(0)("Precio")
        Else

            '////////////////////////////////////////////////SI NO EXISTE PRECIO SEGUN MARIELOS TENEMOS QUE PONER EL PRECIO DE CORTE DEL DIA 13/09/2019


            Precio = 0.0

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////BUSCO SI EXISTEN PRECIOS COMPLEMENTOS //////////////////////////////////////////
            'SqlString = "SELECT  IdPrecioComplemento, IdCosecha, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, Corte, FechaActualizacion  FROM PrecioComplemento WHERE  (IdLocalidad = '" & IdLugarAcopio & "') AND (IdCalidad = " & IdCalidad & ") AND (IdRangoImperfeccion = " & IdCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY Corte DESC, FechaActualizacion DESC"
            SqlString = "SELECT  PrecioComplemento.IdPrecioComplemento, PrecioComplemento.IdCosecha, PrecioComplemento.IdLocalidad, PrecioComplemento.IdCalidad, PrecioComplemento.Precio, PrecioComplemento.Corte, PrecioComplemento.FechaActualizacion, RangoImperfeccion.Nombre FROM  PrecioComplemento INNER JOIN  RangoImperfeccion ON PrecioComplemento.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE  (PrecioComplemento.IdCalidad = " & IdCalidad & ") AND (PrecioComplemento.FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) AND (RangoImperfeccion.Nombre = '" & Categoria & "') AND (PrecioComplemento.IdLocalidad = '" & IdLugarAcopio & "') ORDER BY PrecioComplemento.Corte DESC, PrecioComplemento.FechaActualizacion DESC"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "PrecioAutoriza")
            If DataSet.Tables("PrecioAutoriza").Rows.Count <> 0 Then
                Precio = Format(DataSet.Tables("PrecioAutoriza").Rows(0)("Precio"), "##,##0.00")
            End If



        End If
    End Function
    Private Function PrecioConComplemneto(ByVal IdLugarAcopio As Double, ByVal IdCalidad As Double, ByVal Categoria As String) As Double
        Dim SqlString As String
        Dim Adapter As New SqlDataAdapter, DataSet As New DataSet, Registros As Double, i As Double
        '//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
        SqlString = "SELECT   PrecioComplemento.IdPrecioComplemento, PrecioComplemento.IdLocalidad, PrecioComplemento.IdCalidad, PrecioComplemento.IdRangoImperfeccion, PrecioComplemento.Precio, PrecioComplemento.Corte, RangoImperfeccion.Nombre, PrecioComplemento.FechaActualizacion FROM  PrecioComplemento INNER JOIN       RangoImperfeccion ON PrecioComplemento.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE   (IdLocalidad = " & IdLugarAcopio & ") AND (IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = '" & Categoria & "')  ORDER BY RangoImperfeccion.Nombre, PrecioComplemento.FechaActualizacion DESC  "
        'SqlString = " SELECT   PrecioComplemento.IdPrecioComplemento, PrecioComplemento.IdLocalidad, PrecioComplemento.IdCalidad, PrecioComplemento.IdRangoImperfeccion, PrecioComplemento.Precio, PrecioComplemento.Corte,  RangoImperfeccion.Nombre, PrecioComplemento.FechaActualizacion FROM     PrecioComplemento INNER JOIN  RangoImperfeccion ON PrecioComplemento.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE   (IdLocalidad = " & IdLugarAcopio & ") AND (IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = '" & Categoria & "') ORDER BY RangoImperfeccion.Nombre, PrecioCafe.FechaActualizacion DESC"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "PrecioComplemento")
        PrecioAutoriza = 0
        If DataSet.Tables("PrecioComplemento").Rows.Count <> 0 Then
            PrecioAutoriza = DataSet.Tables("PrecioComplemento").Rows(0)("Precio")
        Else
            PrecioAutoriza = 0.0
            'NumCorte = DataSet.Tables("ConsultaA").Rows(0)("Corte")
        End If
    End Function

    Private Sub CmdFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFiltrar.Click
        Dim SqlString As String, IdLugarAcopio As Double, IdCosecha As Double
        Dim Adapter As New SqlDataAdapter, DataSet As New DataSet, Registros As Double, i As Double
        Dim oDataRow As DataRow, oDataRowComplemento As DataRow


        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CREO UNA CONSULTA QUE NO TENDRA INFORMACION //////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT EmpresaTransporte.NombreEmpresa As CodLugarAcopio, EmpresaTransporte.NombreEmpresa As CentroAcopio, EmpresaTransporte.NombreRepresentante AS PrecioA, EmpresaTransporte.NombreRepresentante AS ComplementoA, EmpresaTransporte.NombreRepresentante AS PrecioComplementoA,  EmpresaTransporte.NombreRepresentante AS PrecioB, EmpresaTransporte.NombreRepresentante AS ComplementoB, EmpresaTransporte.NombreRepresentante AS PrecioComplementoB, EmpresaTransporte.NombreRepresentante AS PrecioC, EmpresaTransporte.NombreRepresentante AS ComplementoC, EmpresaTransporte.NombreRepresentante AS PrecioComplementoC,  EmpresaTransporte.NombreRepresentante AS PrecioD, EmpresaTransporte.NombreRepresentante AS ComplementoD, EmpresaTransporte.NombreRepresentante AS PrecioComplementoD, EmpresaTransporte.NombreRepresentante AS PrecioE, EmpresaTransporte.NombreRepresentante AS ComplementoE, EmpresaTransporte.NombreRepresentante AS PrecioComplementoE ,EmpresaTransporte.NombreRepresentante AS IdLugarAcopio  FROM IndiceCarga LEFT OUTER JOIN  EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo ON IndiceCarga.Placa = Vehiculo.Placa  WHERE (IndiceCarga.CodCarga = N'-100000')"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Reporte")

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CREO UNA CONSULTA QUE NO TENDRA INFORMACION //////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT Nombre, Deduccion AS Complemento, Deduccion AS Autoriza FROM RangoImperfeccion WHERE (Nombre = '-1') ORDER BY Nombre"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSetComplemento, "Complemento")

        '///////////////////////////////////////////////////////CONSULTO LA CALIDAD ////////////////////////////////////////////////////
        SqlString = "SELECT  Calidad.*  FROM Calidad WHERE (NomCalidad='" & Me.CboTipoCalidad.Text & "') "
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Calidad")
        If DataSet.Tables("Calidad").Rows.Count <> 0 Then
            IdCalidad = DataSet.Tables("Calidad").Rows(0)("IdCalidad")
        End If

        '///////////////////////////////////////////////////////ESTADO FISICO ////////////////////////////////////////////////////
        SqlString = "SELECT  IdEdoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto  FROM EstadoFisico WHERE (Descripcion = '" & Me.CboEdofisico.Text & "')"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdEstadoFisico = DataSet.Tables("Consulta").Rows(0)("IdEdoFisico")
        End If

        SqlString = "SELECT  IdLugarAcopio, CodLugarAcopio, NomLugarAcopio, IdRegion  FROM LugarAcopio WHERE (IdRegion = " & IdRegionUsuario & ") AND (Activo = 1) ORDER BY CodLugarAcopio"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Localidad")
        Registros = DataSet.Tables("Localidad").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Registros
        Me.ProgressBar1.Value = 0

        IdCosecha = Me.CboCosecha.Columns(0).Text

        Dim PrecioA As Double, PrecioB As Double, PrecioC As Double, PrecioD As Double, PrecioE As Double, ComplementoA As Double, ComplementoB As Double, ComplementoC As Double, ComplementoD As Double, ComplementoE As Double
        Dim Cont As Double, j As Double, Cat As String

        Do While Registros > i

            IdLugarAcopio = DataSet.Tables("Localidad").Rows(i)("IdLugarAcopio")
            'IdRegion = DataSet.Tables("Localidad").Rows(i)("IdRegion")

            ''//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
            'SqlString = "SELECT PrecioCafe.IdPrecioCafe, PrecioCafe.IdLocalidad, PrecioCafe.IdCalidad, PrecioCafe.IdRangoImperfeccion, PrecioCafe.Precio, PrecioCafe.FechaActualizacion,  RangoImperfeccion.Nombre FROM PrecioCafe INNER JOIN RangoImperfeccion ON PrecioCafe.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE  (PrecioCafe.IdLocalidad = " & IdLugarAcopio & ") AND (PrecioCafe.IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = 'A') ORDER BY RangoImperfeccion.Nombre, PrecioCafe.FechaActualizacion"
            'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'Adapter.Fill(DataSet, "ConsultaA")
            'If DataSet.Tables("ConsultaA").Rows.Count <> 0 Then
            '    PrecioA = DataSet.Tables("ConsultaA").Rows(0)("Precio")
            'End If

            If IdLugarAcopio = 4 Then
                IdLugarAcopio = 4
            End If

            PrecioA = Precio(IdLugarAcopio, IdCalidad, "A")
            PrecioB = Precio(IdLugarAcopio, IdCalidad, "B")
            PrecioC = Precio(IdLugarAcopio, IdCalidad, "C")
            PrecioD = Precio(IdLugarAcopio, IdCalidad, "D")
            PrecioE = Precio(IdLugarAcopio, IdCalidad, "E")

            'ComplementoA = ComplementoPrecio(IdLugarAcopio, IdCalidad, "A", IdRegionUsuario, IdCosecha)
            'ComplementoB = ComplementoPrecio(IdLugarAcopio, IdCalidad, "B", IdRegionUsuario, IdCosecha)
            'ComplementoC = ComplementoPrecio(IdLugarAcopio, IdCalidad, "C", IdRegionUsuario, IdCosecha)
            'ComplementoD = ComplementoPrecio(IdLugarAcopio, IdCalidad, "D", IdRegionUsuario, IdCosecha)
            'ComplementoE = ComplementoPrecio(IdLugarAcopio, IdCalidad, "E", IdRegionUsuario, IdCosecha)


            ComplementoA = 0
            ComplementoB = 0
            ComplementoC = 0
            ComplementoD = 0
            ComplementoE = 0


            'PrecioConComplemnetoA = PrecioConComplemneto(IdLugarAcopio, IdCalidad, "A")
            'PrecioConComplemneto(IdLugarAcopio, IdCalidad, "B")
            'PrecioConComplemneto(IdLugarAcopio, IdCalidad, "C")
            'PrecioConComplemneto(IdLugarAcopio, IdCalidad, "D")

            If ComplementoA <> 0 Then
                Me.LblPrecioDiscre.Text = Format(ComplementoA, "##,##0.00")
            End If

            If ComplementoB <> 0 Then
                Me.LblPrecioDiscre.Text = Format(ComplementoB, "##,##0.00")
            End If

            If ComplementoC <> 0 Then
                Me.LblPrecioDiscre.Text = Format(ComplementoC, "##,##0.00")
            End If

            If ComplementoD <> 0 Then
                Me.LblPrecioDiscre.Text = Format(ComplementoD, "##,##0.00")
            End If

            If ComplementoE <> 0 Then
                Me.LblPrecioDiscre.Text = Format(ComplementoE, "##,##0.00")
            End If

            oDataRow = DataSet.Tables("Reporte").NewRow
            oDataRow("CodLugarAcopio") = DataSet.Tables("Localidad").Rows(i)("CodLugarAcopio")
            oDataRow("CentroAcopio") = DataSet.Tables("Localidad").Rows(i)("NomLugarAcopio")
            oDataRow("PrecioA") = Format(PrecioA, "##,##0.00")
            oDataRow("ComplementoA") = Format(ComplementoA, "##,##0.00")
            'oDataRow("PrecioComplementoA") = Format(ComplementoA, "##,##0.00")
            oDataRow("PrecioB") = Format(PrecioB, "##,##0.00")
            oDataRow("ComplementoB") = Format(ComplementoB, "##,##0.00")
            oDataRow("PrecioC") = Format(PrecioC, "##,##0.00")
            oDataRow("ComplementoC") = Format(ComplementoC, "##,##0.00")
            oDataRow("PrecioD") = Format(PrecioD, "##,##0.00")
            oDataRow("ComplementoD") = Format(ComplementoD, "##,##0.00")
            oDataRow("PrecioE") = Format(PrecioE, "##,##0.00")
            oDataRow("ComplementoE") = Format(ComplementoE, "##,##0.00")
            oDataRow("IdLugarAcopio") = IdLugarAcopio
            DataSet.Tables("Reporte").Rows.Add(oDataRow)

            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Loop

        Me.BindingComponentes.DataSource = DataSet.Tables("Reporte")
        Me.TrueDBGridComponentes.DataSource = Me.BindingComponentes.DataSource

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Width = 50
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(0).Locked = True
        Me.TrueDBGridComponentes.Columns(0).Caption = "Codigo"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Width = 200
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.TrueDBGridComponentes.Columns(1).Caption = "Centro Acopio"

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.TrueDBGridComponentes.Columns(2).Caption = "Atlantic A"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(2).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.TrueDBGridComponentes.Columns(3).Caption = "Complemento"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(4).Locked = False
        Me.TrueDBGridComponentes.Columns(4).Caption = "P.Total"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("ComplementoA").Visible = True

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TrueDBGridComponentes.Columns(5).Caption = "Atlantic B"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TrueDBGridComponentes.Columns(6).Caption = "Complemento"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = False
        Me.TrueDBGridComponentes.Columns(7).Caption = "P.Total"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("ComplementoB").Visible = True

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TrueDBGridComponentes.Columns(8).Caption = "Atlantic C"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TrueDBGridComponentes.Columns(9).Caption = "Complemento"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Locked = False
        Me.TrueDBGridComponentes.Columns(10).Caption = "P.Total"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("ComplementoC").Visible = True

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Locked = True
        Me.TrueDBGridComponentes.Columns(11).Caption = "Atlantic D"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(12).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(12).Locked = True
        Me.TrueDBGridComponentes.Columns(12).Caption = "Complemento"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(13).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(13).Locked = False
        Me.TrueDBGridComponentes.Columns(13).Caption = "P.Total"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("ComplementoD").Visible = True


        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("PrecioE").Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("PrecioE").Locked = True
        Me.TrueDBGridComponentes.Columns("PrecioE").Caption = "Atlantic E"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("PrecioE").Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("ComplementoE").Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("ComplementoE").Locked = True
        Me.TrueDBGridComponentes.Columns(15).Caption = "Complemento"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("PrecioComplementoE").Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("PrecioComplementoE").Locked = False
        Me.TrueDBGridComponentes.Columns(16).Caption = "P.Total"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("ComplementoE").Visible = True

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns("IdLugarAcopio").Visible = False
        Me.TrueDBGridComponentes.RowHeight = 20


        SqlString = "SELECT DISTINCT Nombre  FROM RangoImperfeccion ORDER BY Nombre"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSetComplemento, "Categorias")
        Cont = DataSetComplemento.Tables("Categorias").Rows.Count
        j = 0
        Do While Cont > j
            Cat = DataSetComplemento.Tables("Categorias").Rows(j)("Nombre")
            oDataRowComplemento = DataSetComplemento.Tables("Complemento").NewRow
            oDataRowComplemento("Nombre") = DataSetComplemento.Tables("Categorias").Rows(j)("Nombre")
            oDataRowComplemento("Complemento") = ComplementoPrecio(IdLugarAcopio, IdCalidad, Cat, IdRegionUsuario, IdCosecha)
            oDataRowComplemento("Autoriza") = "0.00"
            DataSetComplemento.Tables("Complemento").Rows.Add(oDataRowComplemento)

            j = j + 1
        Loop

        Me.TrueDBGridComplemento.DataSource = DataSetComplemento.Tables("Complemento")


        Me.TrueDBGridComplemento.Splits.Item(0).DisplayColumns("Nombre").Width = 60
        Me.TrueDBGridComplemento.Splits.Item(0).DisplayColumns("Nombre").Locked = True
        Me.TrueDBGridComplemento.Columns("Nombre").Caption = "Categoria"
        Me.TrueDBGridComplemento.Splits.Item(0).DisplayColumns("Complemento").Width = 80
        Me.TrueDBGridComplemento.Splits.Item(0).DisplayColumns("Complemento").Locked = True
        Me.TrueDBGridComplemento.Columns("Complemento").Caption = "Complemento"
        Me.TrueDBGridComplemento.Splits.Item(0).DisplayColumns("Autoriza").Width = 80
        Me.TrueDBGridComplemento.Columns("Autoriza").Caption = "Autoriza"

        'Me.LblPrecioDiscre.txt = ComplementoPrecio()
        'Me.LblDisA.Text = Me.TrueDBGridComponentes.Columns(3).Text
        'Me.LblDisB.Text = Me.TrueDBGridComponentes.Columns(6).Text
        'Me.LblDisC.Text = Me.TrueDBGridComponentes.Columns(9).Text
        'Me.LblDisD.Text = Me.TrueDBGridComponentes.Columns(12).Text

        Me.GroupBox1.Enabled = True
        Me.Button1.Enabled = True

        'CmdActualizar_Click(sender, e)
    End Sub

    Private Sub CmdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdActualizar.Click
        Dim Registros As Double, i As Double, Precio As Double, Complemento As Double, Autoriza As Double
        Dim Criterios As String, Buscar_Fila() As DataRow, Posicion As Double

        'If Me.CboPrecio.Text = "" Then
        '    Exit Sub
        'End If

        'If Me.ChkAplicar.Checked = False Then
        '    Exit Sub
        'End If

        Registros = Me.TrueDBGridComponentes.RowCount
        i = 0

        Do While Registros > i
            Me.TrueDBGridComponentes.Row = i

            'Select Case Me.CboPrecio.Text
            '    Case "Atlantic A"

            '///////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////ATLANTIC A////////////////////////////////////////////////
            '________________________________________________________________________________________________________________________
            Precio = Me.TrueDBGridComponentes.Columns(2).Text
            'Complemento = 
            Complemento = Me.TrueDBGridComponentes.Columns(3).Text

            'If Me.TxtComplemento.Text <> "" Then

            Criterios = "Nombre= 'A' "
            Buscar_Fila = DataSetComplemento.Tables("Complemento").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                Posicion = DataSetComplemento.Tables("Complemento").Rows.IndexOf(Buscar_Fila(0))
                Autoriza = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Autoriza")
                Complemento = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Complemento")
            Else
                Autoriza = 0
            End If

            'Autoriza = Me.TxtComplemento.Text
            If Autoriza < 0 Then
                Autoriza = 0
            End If
            'End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If
            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(3).Text = Format(Autoriza, "##,##0.00")
                Me.TrueDBGridComponentes.Columns(4).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                'Me.TrueDBGridComponentes.Columns(4).Text = "0.00"
            End If

            '///////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////ATLANTIC B////////////////////////////////////////////////
            '________________________________________________________________________________________________________________________

            'Case "Atlantic B"
            Precio = Me.TrueDBGridComponentes.Columns(5).Text
            Complemento = Me.TrueDBGridComponentes.Columns(6).Text

            'If Me.TxtComplemento.Text <> "" Then

            Criterios = "Nombre= 'B' "
            Buscar_Fila = DataSetComplemento.Tables("Complemento").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                Posicion = DataSetComplemento.Tables("Complemento").Rows.IndexOf(Buscar_Fila(0))
                Autoriza = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Autoriza")
                Complemento = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Complemento")
            Else
                Autoriza = 0
            End If

            'Autoriza = Me.TxtComplemento.Text
            If Autoriza < 0 Then
                Autoriza = 0
            End If
            'End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If

            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(6).Text = Format(Autoriza, "##,##0.00")
                Me.TrueDBGridComponentes.Columns(7).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                'Me.TrueDBGridComponentes.Columns(7).Text = "0.00"
            End If


            'Case "Atlantic C"
            '///////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////ATLANTIC C////////////////////////////////////////////////
            '________________________________________________________________________________________________________________________
            Precio = Me.TrueDBGridComponentes.Columns(8).Text
            Complemento = Me.TrueDBGridComponentes.Columns(9).Text

            'If Me.TxtComplemento.Text <> "" Then
            'Autoriza = Me.TxtComplemento.Text

            Criterios = "Nombre= 'C' "
            Buscar_Fila = DataSetComplemento.Tables("Complemento").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                Posicion = DataSetComplemento.Tables("Complemento").Rows.IndexOf(Buscar_Fila(0))
                Autoriza = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Autoriza")
                Complemento = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Complemento")
            Else
                Autoriza = 0
            End If


            If Autoriza < 0 Then
                Autoriza = 0
            End If
            'End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If

            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(9).Text = Format(Autoriza, "##,##0.00")
                Me.TrueDBGridComponentes.Columns(10).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                'Me.TrueDBGridComponentes.Columns(10).Text = "0.00"
            End If


            '///////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////ATLANTIC D///////////////////////////////////////////////
            '________________________________________________________________________________________________________________________
            'Case "Atlantic D"
            Precio = Me.TrueDBGridComponentes.Columns(11).Text
            Complemento = Me.TrueDBGridComponentes.Columns(12).Text

            'If Me.TxtComplemento.Text <> "" Then
            'Autoriza = Me.TxtComplemento.Text

            Criterios = "Nombre= 'D' "
            Buscar_Fila = DataSetComplemento.Tables("Complemento").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                Posicion = DataSetComplemento.Tables("Complemento").Rows.IndexOf(Buscar_Fila(0))
                Autoriza = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Autoriza")
                Complemento = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Complemento")
            Else
                Autoriza = 0
            End If

            If Autoriza < 0 Then
                Autoriza = 0
            End If
            'End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If

            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(12).Text = Format(Autoriza, "##,##0.00")
                Me.TrueDBGridComponentes.Columns(13).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                'Me.TrueDBGridComponentes.Columns(13).Text = "0.00"
            End If


            '///////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////ATLANTIC E///////////////////////////////////////////////
            '________________________________________________________________________________________________________________________
            'Case "Atlantic D"
            Precio = Me.TrueDBGridComponentes.Columns(14).Text
            Complemento = Me.TrueDBGridComponentes.Columns(15).Text

            'If Me.TxtComplemento.Text <> "" Then
            'Autoriza = Me.TxtComplemento.Text

            Criterios = "Nombre= 'E' "
            Buscar_Fila = DataSetComplemento.Tables("Complemento").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                Posicion = DataSetComplemento.Tables("Complemento").Rows.IndexOf(Buscar_Fila(0))
                Autoriza = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Autoriza")
                Complemento = DataSetComplemento.Tables("Complemento").Rows(Posicion)("Complemento")
            Else
                Autoriza = 0
            End If

            If Autoriza < 0 Then
                Autoriza = 0
            End If
            'End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If

            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(15).Text = Format(Autoriza, "##,##0.00")
                Me.TrueDBGridComponentes.Columns(16).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                'Me.TrueDBGridComponentes.Columns(13).Text = "0.00"
            End If

            'End Select
            i = i + 1
        Loop

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        My.Forms.FrmResumenCalculoPrecio.Show()
        My.Forms.FrmResumenCalculoPrecio.RefreshNew()
    End Sub

    Private Sub TrueDBGridComponentes_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TrueDBGridComponentes.AfterColEdit
        Dim posicion As Integer = 0, PrecioMax As Double, PrecioMin As Double

        If Me.TrueDBGridComponentes.Col = 4 Then
            posicion = Me.TrueDBGridComponentes.Row
            PrecioMax = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioA")) + CDbl(Me.LblPrecioDiscre.Text)
            PrecioMin = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioA"))

            If IsNumeric(Me.TrueDBGridComponentes.Columns("PrecioComplementoA").Text) = False Then
                Me.TrueDBGridComponentes.Columns("PrecioComplementoA").Text = 0.0
            End If
            If CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoA")) > PrecioMax Or CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoA")) < PrecioMin Or CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioA")) = 0.0 Then
                Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoA") = PrecioMin
            End If
        End If

        If Me.TrueDBGridComponentes.Col = 7 Then
            posicion = Me.TrueDBGridComponentes.Row
            PrecioMax = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioB")) + CDbl(Me.LblPrecioDiscre.Text)
            PrecioMin = Me.TrueDBGridComponentes.Item(posicion)("PrecioB")

            'IsDBNull(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoC")) = True Or Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoC") = "" 

            If IsNumeric(Me.TrueDBGridComponentes.Columns("PrecioComplementoB").Text) = False Then
                Me.TrueDBGridComponentes.Columns("PrecioComplementoB").Text = 0.0
            End If


            If CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoB")) > PrecioMax Or CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoB")) < PrecioMin Or CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioB")) = 0.0 Then
                Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoB") = PrecioMin
            End If
        End If

        If Me.TrueDBGridComponentes.Col = 10 Then
            posicion = Me.TrueDBGridComponentes.Row
            PrecioMax = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioC")) + CDbl(Me.LblPrecioDiscre.Text)
            PrecioMin = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioC"))

            If IsNumeric(Me.TrueDBGridComponentes.Columns("PrecioComplementoC").Text) = False Then
                Me.TrueDBGridComponentes.Columns("PrecioComplementoC").Text = 0.0
            End If
            If CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoC")) > PrecioMax Or CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoC")) < PrecioMin Or CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioC")) = 0.0 Then
                Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoC") = PrecioMin
            End If
        End If

        If Me.TrueDBGridComponentes.Col = 13 Then
            posicion = Me.TrueDBGridComponentes.Row
            PrecioMax = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioD")) + CDbl(Me.LblPrecioDiscre.Text)
            PrecioMin = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioD"))

            If IsNumeric(Me.TrueDBGridComponentes.Columns("PrecioComplementoD").Text) = False Then
                Me.TrueDBGridComponentes.Columns("PrecioComplementoD").Text = 0.0
            End If
            If CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoD")) > PrecioMax Or CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoD")) < PrecioMin Or CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioD")) = 0.0 Then
                Me.TrueDBGridComponentes.Item(posicion)("PrecioComplementoD") = PrecioMin
            End If
        End If
    End Sub

    Private Sub TrueDBGridComponentes_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComponentes.BeforeColEdit
        'Dim posicion As Integer = 0
        'If Me.TrueDBGridComponentes.Col = 4 Then
        '    posicion = Me.TrueDBGridComponentes.Row
        '    Me.LblPrecioDiscre.Text = Me.TrueDBGridComponentes.Item(posicion)("ComplementoA")
        'End If
        'If Me.TrueDBGridComponentes.Col = 7 Then
        '    posicion = Me.TrueDBGridComponentes.Row
        '    Me.LblPrecioDiscre.Text = Me.TrueDBGridComponentes.Item(posicion)("ComplementoB")
        'End If

        'If Me.TrueDBGridComponentes.Col = 10 Then
        '    posicion = Me.TrueDBGridComponentes.Row
        '    Me.LblPrecioDiscre.Text = Me.TrueDBGridComponentes.Item(posicion)("ComplementoC")
        'End If

        'If Me.TrueDBGridComponentes.Col = 13 Then
        '    posicion = Me.TrueDBGridComponentes.Row
        '    Me.LblPrecioDiscre.Text = Me.TrueDBGridComponentes.Item(posicion)("ComplementoD")
        'End If
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub CheckDatos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDatos.CheckedChanged
        'If CheckDatos.Checked = True Then
        '    Me.GroupBox3.Visible = True
        'ElseIf CheckDatos.Checked = False Then
        '    Me.GroupBox3.Visible = False
        'End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Count As Integer, i As Integer, Rango As String
        Dim sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim Ruta As String, LeeArchivo As String, PrecioComplemento As Double
        Dim Registros As Double, Cadena As String, Guardado As Boolean = False, idCosecha As Double

        idCosecha = Me.CboCosecha.Columns(0).Text

        Count = Me.TrueDBGridComponentes.RowCount
        If Count = 0 Then
            Exit Sub

        Else
            i = 0
            Me.ProgressBar1.Minimum = 0
            Me.ProgressBar1.Maximum = Count
            Me.ProgressBar1.Value = 0
            Do While Count > i

                'Me.TrueDBGridComponentes.Row = i
                If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoA")) = True Then
                    If Me.TrueDBGridComponentes.Item(i)("PrecioComplementoA") > 0 Then
                        sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion  FROM RangoImperfeccion    WHERE (Nombre = 'A') AND (IdCosecha = " & idCosecha & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "RangoA")
                        IdCategoria = DataSet.Tables("RangoA").Rows(0)("IdRangoImperfeccion")
                        PrecioComplemento = Me.TrueDBGridComponentes.Item(i)("PrecioComplementoA")
                        If PrecioComplemento > 0 Then
                            GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "A", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoA"))
                            Guardado = True
                        End If
                    End If
                    DataSet.Tables("RangoA").Reset()
                End If
                If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoB")) = True Then
                    If Me.TrueDBGridComponentes.Item(i)("PrecioComplementoB") > 0 Then
                        sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion    FROM    RangoImperfeccion WHERE   (Nombre = 'B') AND (IdCosecha = " & idCosecha & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "RangoB")
                        IdCategoria = DataSet.Tables("RangoB").Rows(0)("IdRangoImperfeccion")
                        PrecioComplemento = Me.TrueDBGridComponentes.Item(i)("PrecioComplementoB")
                        If PrecioComplemento > 0 Then
                            GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "B", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoB"))
                            Guardado = True
                        End If
                    End If
                    DataSet.Tables("RangoB").Reset()
                End If
                If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoC")) = True Then
                    If Me.TrueDBGridComponentes.Item(i)("PrecioComplementoC") > 0 Then
                        sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion    FROM    RangoImperfeccion    WHERE  (Nombre = 'C') AND (IdCosecha = " & idCosecha & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "RangoC")
                        IdCategoria = DataSet.Tables("RangoC").Rows(0)("IdRangoImperfeccion")
                        PrecioComplemento = Me.TrueDBGridComponentes.Item(i)("PrecioComplementoC")
                        If PrecioComplemento > 0 Then
                            GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "C", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoC"))
                            Guardado = True
                        End If
                    End If
                    DataSet.Tables("RangoC").Reset()

                End If
                If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoD")) = True Then
                    If Me.TrueDBGridComponentes.Item(i)("PrecioComplementoD") > 0 Then
                        sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion    FROM    RangoImperfeccion    WHERE  (Nombre = 'D') AND (IdCosecha = " & idCosecha & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "RangoD")
                        IdCategoria = DataSet.Tables("RangoD").Rows(0)("IdRangoImperfeccion")
                        PrecioComplemento = Me.TrueDBGridComponentes.Item(i)("PrecioComplementoD")
                        If PrecioComplemento > 0 Then
                            GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "D", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoD"))
                            Guardado = True
                        End If
                        DataSet.Tables("RangoD").Reset()
                    End If
                End If

                If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoE")) = True Then
                    If Me.TrueDBGridComponentes.Item(i)("PrecioComplementoE") > 0 Then
                        sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion    FROM    RangoImperfeccion    WHERE  (Nombre = 'E') AND (IdCosecha = " & idCosecha & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "RangoE")
                        IdCategoria = DataSet.Tables("RangoE").Rows(0)("IdRangoImperfeccion")
                        PrecioComplemento = Me.TrueDBGridComponentes.Item(i)("PrecioComplementoE")
                        If PrecioComplemento > 0 Then
                            GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "E", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoE"))
                            Guardado = True
                        End If
                        DataSet.Tables("RangoE").Reset()
                    End If
                End If
                i = i + 1
                Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            Loop
        End If

        If Guardado = True Then
            MsgBox("Precios Guardado Con Exito", MsgBoxStyle.Information, "Liquidacion")
        End If

    End Sub

    Public Sub GuardarPrecioComplemento(ByVal IdLugarAcopio As Integer, ByVal IdCalidad As Integer, ByVal IdRangoImperfeccion As Integer, ByVal Categoria As String, ByVal Precio As Double)
        Dim SqlString As String
        Dim Count As Double, countfalso As Double, i As Integer, SqlLiqui As String, codigoingre As String, NumEnsamble As String
        Dim FechaLiqui As Date, StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, IdLiquida As String
        Dim sql2 As String, IdAplicacion As String, Corte As Integer, SqlIdRecib As String, Idrecibo As String, StrSqlInsert As String, PrecioAtc As Double


        Dim Adapter As New SqlDataAdapter, DataSet As New DataSet

        Corte = 0
        '//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
        SqlString = "SELECT   PrecioComplemento.IdPrecioComplemento, PrecioComplemento.IdLocalidad, PrecioComplemento.IdCalidad, PrecioComplemento.IdRangoImperfeccion, PrecioComplemento.Precio, PrecioComplemento.Corte, RangoImperfeccion.Nombre, PrecioComplemento.FechaActualizacion FROM  PrecioComplemento INNER JOIN       RangoImperfeccion ON PrecioComplemento.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE   (IdLocalidad = " & IdLugarAcopio & ") AND (IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = '" & Categoria & "')  ORDER BY RangoImperfeccion.Nombre, PrecioComplemento.FechaActualizacion DESC  "
        'SqlString = " SELECT   PrecioComplemento.IdPrecioComplemento, PrecioComplemento.IdLocalidad, PrecioComplemento.IdCalidad, PrecioComplemento.IdRangoImperfeccion, PrecioComplemento.Precio, PrecioComplemento.Corte,  RangoImperfeccion.Nombre, PrecioComplemento.FechaActualizacion FROM     PrecioComplemento INNER JOIN  RangoImperfeccion ON PrecioComplemento.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE   (IdLocalidad = " & IdLugarAcopio & ") AND (IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = '" & Categoria & "') ORDER BY RangoImperfeccion.Nombre, PrecioCafe.FechaActualizacion DESC"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Complemento")

        If DataSet.Tables("Complemento").Rows.Count = 0 Then
            Corte = 1
        Else
            Corte = DataSet.Tables("Complemento").Rows(0)("Corte") + 1
        End If

        SqlString = "INSERT INTO [dbo].[PrecioComplemento]  ([IdCosecha]   ,[IdLocalidad]  ,[IdCalidad]    ,[IdRangoImperfeccion]     ,[Precio]     ,[Corte]        ,[FechaActualizacion])  VALUES ( '" & CDbl(CodigoCosecha) & "','" & IdLugarAcopio & "','" & IdCalidad & "','" & IdRangoImperfeccion & "','" & Precio & "','" & Corte & "','" & Format(CDate(Me.DTPFechaComple.Value.Now), "dd/MM/yyyy HH:mm:ss") & "')"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

    End Sub

  
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TrueDBGridComponentes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComponentes.Click

    End Sub

    Private Sub TrueDBGridComplemento_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles TrueDBGridComplemento.BeforeColEdit

    End Sub

    Private Sub TrueDBGridComplemento_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TrueDBGridComplemento.BeforeColUpdate
        Dim Complemento As Double, Autoriza As Double

        Complemento = Me.TrueDBGridComplemento.Columns("Complemento").Text
        Autoriza = Me.TrueDBGridComplemento.Columns("Autoriza").Text

        If Autoriza > Complemento Then
            MsgBox("El Precio Autorizado, no puede ser mayor que el complemento", MsgBoxStyle.Critical, "Sistema Bascula")
            e.Cancel = True
            Me.CmdActualizar.Enabled = False
            Me.Button1.Enabled = False
        Else
            Me.CmdActualizar.Enabled = True
            Me.Button1.Enabled = True
        End If

    End Sub

    Private Sub TrueDBGridComplemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGridComplemento.Click

    End Sub

    Private Sub TrueDBGridComplemento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TrueDBGridComplemento.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TrueDBGridComplemento.Row = Me.TrueDBGridComplemento.Row + 1
            Me.TrueDBGridComplemento.Col = 2
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CboCosecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCosecha.TextChanged

    End Sub
End Class