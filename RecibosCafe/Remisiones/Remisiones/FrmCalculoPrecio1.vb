Imports System.Data.SqlClient

Public Class FrmCalculoPrecio
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdCalidad As Double, IdCategoria As Double, IdEstadoFisico As Double, IdDaño As Double, IdRegion As Double
    Public PrecioComplemento As Double, NumCorte As Integer, PrecioAutoriza As Double

    Private Sub FrmCalculoPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim Ruta As String, LeeArchivo As String
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, i As Integer, count As Double, TipoImp As String
        Dim Registros As Double, Cadena As String

        sql = "SELECT  Calidad.*  FROM Calidad"
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

        sql = "SELECT        Nombre   FROM      RangoImperfeccion"
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
        Dim Adapter As New SqlDataAdapter, DataSet As New DataSet, Registros As Double, i As Double
        '//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
        SqlString = "SELECT  DiferencialPrecioPergamino.IdDiferencialPrecioPergamino, DiferencialPrecioPergamino.Fecha, DiferencialPrecioPergamino.Monto, DiferencialPrecioPergamino.IdRangoImperfeccion, DiferencialPrecioPergamino.IdCalidad, DiferencialPrecioPergamino.IdRegion, DiferencialPrecioPergamino.IdCosecha, DiferencialPrecioPergamino.FechaActualizacion, DiferencialPrecioPergamino.IdUsuarioEcs, DiferencialPrecioPergamino.IdDiferencialECS FROM  DiferencialPrecioPergamino INNER JOIN  Moneda ON DiferencialPrecioPergamino.IdMoneda = Moneda.IdMoneda INNER JOIN  RangoImperfeccion ON DiferencialPrecioPergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion  " & _
                    "WHERE   (Moneda.Nombre = 'Córdoba') AND (RangoImperfeccion.Nombre = '" & Categoria & "') AND (DiferencialPrecioPergamino.IdRegion = " & IdRegion & ") AND  (DiferencialPrecioPergamino.IdCalidad = " & IdCalidad & ") AND (DiferencialPrecioPergamino.IdCosecha = " & IdCosecha & ") ORDER BY DiferencialPrecioPergamino.FechaActualizacion DESC"
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
        '//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
        SqlString = "SELECT PrecioCafe.IdPrecioCafe, PrecioCafe.IdLocalidad, PrecioCafe.IdCalidad, PrecioCafe.IdRangoImperfeccion, PrecioCafe.Precio, PrecioCafe.FechaActualizacion,  RangoImperfeccion.Nombre FROM PrecioCafe INNER JOIN RangoImperfeccion ON PrecioCafe.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE  (PrecioCafe.IdLocalidad = " & IdLugarAcopio & ") AND (PrecioCafe.IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = '" & Categoria & "') ORDER BY RangoImperfeccion.Nombre, PrecioCafe.FechaActualizacion DESC"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "ConsultaA")
        Precio = 0
        If DataSet.Tables("ConsultaA").Rows.Count <> 0 Then
            Precio = DataSet.Tables("ConsultaA").Rows(0)("Precio")
        Else
            Precio = 0.0
            'NumCorte = DataSet.Tables("ConsultaA").Rows(0)("Corte")
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
        Dim oDataRow As DataRow

        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////CREO UNA CONSULTA QUE NO TENDRA INFORMACION //////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT EmpresaTransporte.NombreEmpresa As CodLugarAcopio, EmpresaTransporte.NombreEmpresa As CentroAcopio, EmpresaTransporte.NombreRepresentante AS PrecioA, EmpresaTransporte.NombreRepresentante AS ComplementoA, EmpresaTransporte.NombreRepresentante AS PrecioComplementoA,  EmpresaTransporte.NombreRepresentante AS PrecioB, EmpresaTransporte.NombreRepresentante AS ComplementoB, EmpresaTransporte.NombreRepresentante AS PrecioComplementoB, EmpresaTransporte.NombreRepresentante AS PrecioC, EmpresaTransporte.NombreRepresentante AS ComplementoC, EmpresaTransporte.NombreRepresentante AS PrecioComplementoC,  EmpresaTransporte.NombreRepresentante AS PrecioD, EmpresaTransporte.NombreRepresentante AS ComplementoD, EmpresaTransporte.NombreRepresentante AS PrecioComplementoD,EmpresaTransporte.NombreRepresentante AS IdLugarAcopio  FROM IndiceCarga LEFT OUTER JOIN  EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo ON IndiceCarga.Placa = Vehiculo.Placa  WHERE (IndiceCarga.CodCarga = N'-100000')"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Reporte")

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

        SqlString = "SELECT  IdLugarAcopio, CodLugarAcopio, NomLugarAcopio, IdRegion  FROM LugarAcopio WHERE (IdRegion = " & IdRegionUsuario & ") ORDER BY CodLugarAcopio"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Localidad")
        Registros = DataSet.Tables("Localidad").Rows.Count
        i = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Registros
        Me.ProgressBar1.Value = 0

        IdCosecha = Me.CboCosecha.Columns(0).Text

        Dim PrecioA As Double, PrecioB As Double, PrecioC As Double, PrecioD As Double, ComplementoA As Double, ComplementoB As Double, ComplementoC As Double, ComplementoD As Double

        Do While Registros > i

            IdLugarAcopio = DataSet.Tables("Localidad").Rows(i)("IdLugarAcopio")

            ''//////////////////////////////////CONSULTO LA CALIDAD A ////////////////////////////////////////////////////////////
            'SqlString = "SELECT PrecioCafe.IdPrecioCafe, PrecioCafe.IdLocalidad, PrecioCafe.IdCalidad, PrecioCafe.IdRangoImperfeccion, PrecioCafe.Precio, PrecioCafe.FechaActualizacion,  RangoImperfeccion.Nombre FROM PrecioCafe INNER JOIN RangoImperfeccion ON PrecioCafe.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion WHERE  (PrecioCafe.IdLocalidad = " & IdLugarAcopio & ") AND (PrecioCafe.IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = 'A') ORDER BY RangoImperfeccion.Nombre, PrecioCafe.FechaActualizacion"
            'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'Adapter.Fill(DataSet, "ConsultaA")
            'If DataSet.Tables("ConsultaA").Rows.Count <> 0 Then
            '    PrecioA = DataSet.Tables("ConsultaA").Rows(0)("Precio")
            'End If


            PrecioA = Precio(IdLugarAcopio, IdCalidad, "A")
            PrecioB = Precio(IdLugarAcopio, IdCalidad, "B")
            PrecioC = Precio(IdLugarAcopio, IdCalidad, "C")
            PrecioD = Precio(IdLugarAcopio, IdCalidad, "D")

            ComplementoA = ComplementoPrecio(IdLugarAcopio, IdCalidad, "A", IdRegionUsuario, IdCosecha)
            ComplementoB = ComplementoPrecio(IdLugarAcopio, IdCalidad, "B", IdRegionUsuario, IdCosecha)
            ComplementoC = ComplementoPrecio(IdLugarAcopio, IdCalidad, "C", IdRegionUsuario, IdCosecha)
            ComplementoD = ComplementoPrecio(IdLugarAcopio, IdCalidad, "D", IdRegionUsuario, IdCosecha)

            'PrecioConComplemnetoA = PrecioConComplemneto(IdLugarAcopio, IdCalidad, "A")
            'PrecioConComplemneto(IdLugarAcopio, IdCalidad, "B")
            'PrecioConComplemneto(IdLugarAcopio, IdCalidad, "C")
            'PrecioConComplemneto(IdLugarAcopio, IdCalidad, "D")



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
        Me.TrueDBGridComponentes.Columns(4).Caption = "Autoriza"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(3).Visible = False

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Locked = True
        Me.TrueDBGridComponentes.Columns(5).Caption = "Atlantic B"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(5).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Locked = True
        Me.TrueDBGridComponentes.Columns(6).Caption = "Complemento"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(7).Locked = False
        Me.TrueDBGridComponentes.Columns(7).Caption = "Autoriza"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(6).Visible = False

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Locked = True
        Me.TrueDBGridComponentes.Columns(8).Caption = "Atlantic C"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(8).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Locked = True
        Me.TrueDBGridComponentes.Columns(9).Caption = "Complemento"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(10).Locked = False
        Me.TrueDBGridComponentes.Columns(10).Caption = "Autoriza"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(9).Visible = False

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 60
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Locked = True
        Me.TrueDBGridComponentes.Columns(11).Caption = "Atlantic D"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(11).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(12).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(12).Locked = True
        Me.TrueDBGridComponentes.Columns(12).Caption = "Complemento"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(13).Width = 90
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(13).Locked = False
        Me.TrueDBGridComponentes.Columns(13).Caption = "Autoriza"
        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(12).Visible = False

        Me.TrueDBGridComponentes.Splits.Item(0).DisplayColumns(14).Visible = False

        'Me.LblPrecioDiscre.txt = ComplementoPrecio()
        'Me.LblDisA.Text = Me.TrueDBGridComponentes.Columns(3).Text
        'Me.LblDisB.Text = Me.TrueDBGridComponentes.Columns(6).Text
        'Me.LblDisC.Text = Me.TrueDBGridComponentes.Columns(9).Text
        'Me.LblDisD.Text = Me.TrueDBGridComponentes.Columns(12).Text

        Me.GroupBox1.Enabled = True
        Me.Button1.Enabled = True
    End Sub

    Private Sub CmdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdActualizar.Click
        Dim Registros As Double, i As Double, Precio As Double, Complemento As Double, Autoriza As Double

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
            Complemento = Me.TrueDBGridComponentes.Columns(3).Text

            If Me.TxtComplemento.Text <> "" Then
                Autoriza = Me.TxtComplemento.Text
                If Autoriza < 0 Then
                    Autoriza = 0
                End If
            End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If
            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(4).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                Me.TrueDBGridComponentes.Columns(4).Text = "0.00"
            End If

            '///////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////ATLANTIC B////////////////////////////////////////////////
            '________________________________________________________________________________________________________________________

            'Case "Atlantic B"
            Precio = Me.TrueDBGridComponentes.Columns(5).Text
            Complemento = Me.TrueDBGridComponentes.Columns(6).Text

            If Me.TxtComplemento.Text <> "" Then
                Autoriza = Me.TxtComplemento.Text
                If Autoriza < 0 Then
                    Autoriza = 0
                End If
            End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If

            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(7).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                Me.TrueDBGridComponentes.Columns(7).Text = "0.00"
            End If


            'Case "Atlantic C"
            '///////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////ATLANTIC C////////////////////////////////////////////////
            '________________________________________________________________________________________________________________________
            Precio = Me.TrueDBGridComponentes.Columns(8).Text
            Complemento = Me.TrueDBGridComponentes.Columns(9).Text

            If Me.TxtComplemento.Text <> "" Then
                Autoriza = Me.TxtComplemento.Text
                If Autoriza < 0 Then
                    Autoriza = 0
                End If
            End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If

            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(10).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                Me.TrueDBGridComponentes.Columns(10).Text = "0.00"
            End If


            '///////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////ATLANTIC D///////////////////////////////////////////////
            '________________________________________________________________________________________________________________________
            'Case "Atlantic D"
            Precio = Me.TrueDBGridComponentes.Columns(11).Text
            Complemento = Me.TrueDBGridComponentes.Columns(12).Text

            If Me.TxtComplemento.Text <> "" Then
                Autoriza = Me.TxtComplemento.Text
                If Autoriza < 0 Then
                    Autoriza = 0
                End If
            End If

            If Autoriza > Complemento Then
                Autoriza = Complemento
            End If

            If Precio <> 0 Then
                Me.TrueDBGridComponentes.Columns(13).Text = Format(Precio + Autoriza, "##,##0.00")
            Else
                Me.TrueDBGridComponentes.Columns(13).Text = "0.00"
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
            PrecioMax = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioA")) + CDbl(Me.TrueDBGridComponentes.Item(posicion)("ComplementoA"))
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
            PrecioMax = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioB")) + CDbl(Me.TrueDBGridComponentes.Item(posicion)("ComplementoB"))
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
            PrecioMax = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioC")) + CDbl(Me.TrueDBGridComponentes.Item(posicion)("ComplementoC"))
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
            PrecioMax = CDbl(Me.TrueDBGridComponentes.Item(posicion)("PrecioD")) + CDbl(Me.TrueDBGridComponentes.Item(posicion)("ComplementoD"))
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
        Dim posicion As Integer = 0
        If Me.TrueDBGridComponentes.Col = 4 Then
            posicion = Me.TrueDBGridComponentes.Row
            Me.LblPrecioDiscre.Text = Me.TrueDBGridComponentes.Item(posicion)("ComplementoA")
        End If
        If Me.TrueDBGridComponentes.Col = 7 Then
            posicion = Me.TrueDBGridComponentes.Row
            Me.LblPrecioDiscre.Text = Me.TrueDBGridComponentes.Item(posicion)("ComplementoB")
        End If

        If Me.TrueDBGridComponentes.Col = 10 Then
            posicion = Me.TrueDBGridComponentes.Row
            Me.LblPrecioDiscre.Text = Me.TrueDBGridComponentes.Item(posicion)("ComplementoC")
        End If

        If Me.TrueDBGridComponentes.Col = 13 Then
            posicion = Me.TrueDBGridComponentes.Row
            Me.LblPrecioDiscre.Text = Me.TrueDBGridComponentes.Item(posicion)("ComplementoD")
        End If
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
        Count = Me.TrueDBGridComponentes.RowCount
        Dim sql As String, DataAdapter As SqlClient.SqlDataAdapter, DataSet As New DataSet, SqlString As String
        Dim Ruta As String, LeeArchivo As String
        Dim Registros As Double, Cadena As String

        If Count = 0 Then
            Exit Sub
        End If
        i = 0

        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Count
        Me.ProgressBar1.Value = 0

        Do While Count > i
            'Me.TrueDBGridComponentes.Row = i
            If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoA")) = True Then
                sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion    FROM    RangoImperfeccion    WHERE        (Nombre = 'A')"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "RangoA")
                IdCategoria = DataSet.Tables("RangoA").Rows(0)("IdRangoImperfeccion")
                GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "A", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoA"))

                DataSet.Tables("RangoA").Reset()
            End If
            If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoB")) = True Then

                sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion    FROM    RangoImperfeccion    WHERE        (Nombre = 'B')"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "RangoB")
                IdCategoria = DataSet.Tables("RangoB").Rows(0)("IdRangoImperfeccion")
                GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "B", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoB"))

                DataSet.Tables("RangoB").Reset()

            End If
            If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoC")) = True Then

                sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion    FROM    RangoImperfeccion    WHERE        (Nombre = 'C')"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "RangoC")
                IdCategoria = DataSet.Tables("RangoC").Rows(0)("IdRangoImperfeccion")
                GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "C", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoC"))

                DataSet.Tables("RangoC").Reset()

            End If
            If IsNumeric(Me.TrueDBGridComponentes.Item(i)("PrecioComplementoD")) = True Then
                sql = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion    FROM    RangoImperfeccion    WHERE        (Nombre = 'D')"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "RangoD")
                IdCategoria = DataSet.Tables("RangoD").Rows(0)("IdRangoImperfeccion")
                GuardarPrecioComplemento(Me.TrueDBGridComponentes.Item(i)("IdLugarAcopio"), IdCalidad, IdCategoria, "D", Me.TrueDBGridComponentes.Item(i)("PrecioComplementoD"))

                DataSet.Tables("RangoD").Reset()

            End If

            i = i + 1
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Loop
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

  
End Class