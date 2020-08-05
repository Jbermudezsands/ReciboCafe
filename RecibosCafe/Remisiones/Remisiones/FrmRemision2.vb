
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports System.Collections


Public Class FrmRemision2
    Public MiConexion As New SqlClient.SqlConnection(Conexion), IdEmpresaTransporte As Double, IdRemision As String = "", idCosecha As Double, ConfirmadoDetalle As Boolean = False, Limpiar As Boolean = True, Cosecha As String
    Public CodLugarAcopio As String, DataSetRecibos As New DataSet, AgregarRegistos As Boolean = False, IdLugarAcopio As Double, IdRutaLogica As Double
    Public NumeroTemporal As String, Random As New Random(), Impresora_Defecto As String, PegarRemision As Boolean = False



    Dim IdSucursal As Double = 0
    Dim sql As String
    Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Dataset1 As New DataSet
    Dim _rowcol As Point = Point.Empty


    'VARIABLES PARA GUARDAR"
    '-----------------------------------------------------------------------------------------------------------------------
    Public IdTipoCafe As Integer, Observaciones As String

    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Public Sub ComboRecibos()
        Dim SQL As String = "SELECT        IdTipoCafe, Codigo, Nombre FROM   TipoCafe  WHERE        (Nombre = '" & Me.CboTipoRemision.Text & "')"
        Dim DataSet As New DataSet, DataSet1 As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion), SqlString As String
        Dim MyRuta As String, Ruta As String
        Dim fileReader As String = ""

        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "DsTipoCafe")
        If Not DataSet.Tables("DsTipoCafe").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")) Then
                IdTipoCafe = DataSet.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")
            End If
        End If


        Me.TextIdCosecha.Text = Trim(CodigoCosecha)

        If IdTipoCafe = 2 Then
            Me.LblProductor.Visible = True
            Me.TxtProductores.Visible = True
            Me.PanelPergaminio.Visible = False
            Me.PanelMaquila.Visible = True
            SqlString = "SELECT DISTINCT ReciboCafePergamino.Codigo   FROM  ReciboCafePergamino INNER JOIN  EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe " & _
                        "WHERE (ReciboCafePergamino.IdReciboPergamino NOT IN (SELECT DISTINCT ReciboCafePergamino_1.IdReciboPergamino FROM  RecibosRemisionPergamino INNER JOIN DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN  ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (EstadoDocumento.Descripcion = 'Confirmado') AND  (TipoCafe.Nombre = 'MAQUILA') AND (ReciboCafePergamino.IdLocalidadRegistro = '" & Me.TxtIdLugarAcopio.Text & "') AND (ReciboCafePergamino.IdCosecha = " & Trim(CodigoCosecha) & ") "
        Else
            Me.LblProductor.Visible = False
            Me.TxtProductores.Visible = False
            Me.PanelPergaminio.Visible = True
            Me.PanelMaquila.Visible = False
            Me.PanelGRidProveeedores.Visible = False
            SqlString = "SELECT   DISTINCT ReciboCafePergamino.Codigo   FROM   ReciboCafePergamino INNER JOIN   EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe " & _
                        "WHERE (ReciboCafePergamino.IdReciboPergamino NOT IN   (SELECT DISTINCT ReciboCafePergamino_1.IdReciboPergamino FROM RecibosRemisionPergamino INNER JOIN  DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN  ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (EstadoDocumento.Descripcion = 'Confirmado') AND  (TipoCafe.Nombre = 'PERGAMINO')   AND (ReciboCafePergamino.IdLocalidadRegistro = '" & Me.TxtIdLugarAcopio.Text & "') AND (ReciboCafePergamino.IdCosecha = " & Trim(CodigoCosecha) & ") "
        End If

        'LLeno los cbo de recibos
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recibos")
        DataAdapter.Fill(DataSet1, "Recibos1")
        Me.CboRecInicial.DataSource = DataSet.Tables("Recibos")
        If Not DataSet.Tables("Recibos").Rows.Count = 0 Then
            Me.CboRecInicial.Text = DataSet.Tables("Recibos").Rows(0)("Codigo")
        End If
        Me.CboRecFinal.DataSource = DataSet1.Tables("Recibos1")
        If Not DataSet1.Tables("Recibos1").Rows.Count = 0 Then
            Me.CboRecFinal.Text = DataSet1.Tables("Recibos1").Rows(0)("Codigo")
        End If


    End Sub


    Public Sub LimpiarRegistros(ByVal IdRemision As Double)

        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, StrSqlInsert As String
        Dim SqlString As String, Registros As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, i As Double, IdReciboRemision As Double

        SqlString = "SELECT RecibosRemisionPergamino.IdReciboRemisionPergamino, RecibosRemisionPergamino.PesoNeto, RecibosRemisionPergamino.IdDetalleReciboPergamino, RecibosRemisionPergamino.IdDetalleRemsionPergamino, RecibosRemisionPergamino.IdUsuario, RecibosRemisionPergamino.Orden, DetalleRemisionPergamino.IdRemisionPergamino FROM RecibosRemisionPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino " & _
                    "WHERE(DetalleRemisionPergamino.IdRemisionPergamino = " & IdRemision & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        Registros = DataSet.Tables("Consulta").Rows.Count
        i = 0
        Do While Registros > i
            IdReciboRemision = DataSet.Tables("Consulta").Rows(i)("IdReciboRemisionPergamino")
            ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ''/////////////////////////BORROR EL RECIBO REMISION PERGAMINO/////////////////////////////////////////////////////////////////////
            ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            StrSqlInsert = "DELETE FROM RecibosRemisionPergamino WHERE (IdReciboRemisionPergamino = " & IdReciboRemision & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
            i = i + 1
        Loop



        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////BORROR TODO EL DETALLE PARA GRABARLO /////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        StrSqlInsert = "DELETE FROM DetalleRemisionPergamino WHERE (IdRemisionPergamino = " & IdRemision & ")"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()




    End Sub



    Public Sub ConsecutivoRemision()
        Dim SqlString As String, Contador1 As Double
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim NumeroRemision As Double

        SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM   TipoCafe  WHERE  (Nombre = '" & Me.CboTipoRemision.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "DsTipoCafe")
        If Not Dataset.Tables("DsTipoCafe").Rows.Count = 0 Then
            If Not IsDBNull(Dataset.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")) Then
                IdTipoCafe = Dataset.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")
            End If
        End If

        If Not Me.TxtNumeroRemision.Text = "" Then
            If Not Me.TxtNumeroRemision.Text = "-----0-----" Then
                Exit Sub
            End If
        End If

        Select Case Me.CboRemTipIngr.Text
            Case "Manual"
                Me.TxtNumeroRemision.Enabled = True
                Me.TxtNumeroRemision.Text = ""
            Case "Automatico"




                sql = "SELECT * FROM  RemisionPergamino WHERE  (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLugarAcopio & ") AND (IdTipoIngreso = 1) ORDER BY Codigo DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(Dataset, "RemisionPergamino")
                If Not Dataset.Tables("RemisionPergamino").Rows.Count = 0 Then
                    Contador1 = Dataset.Tables("RemisionPergamino").Rows.Count
                    If Not IsDBNull(Dataset.Tables("RemisionPergamino").Rows(0)("Codigo")) Then
                        NumeroRemision = Dataset.Tables("RemisionPergamino").Rows(0)("Codigo")
                        Me.TxtNumeroRemision.Text = Format(NumeroRemision + 1, "00000#")
                        Me.TxtNumeroRemision.Enabled = False
                    End If
                Else
                    Me.TxtNumeroRemision.Text = "000001"
                    Me.TxtNumeroRemision.Enabled = False
                End If
        End Select
    End Sub
    Public Sub CierreFormulario()
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Cont As Double, i As Double, Eleccion As Boolean, idReciboPergamino As Double, IdRemisionPergamino As Double


        '++++++++++++++++++++++++++++++++++++VERIFICO SI ESTA REMISION NO ESTA GRABADA PARA CAMBIAR EL ESTADO DE VARIAS TABLAS +++++++++++++++++++++++

        If Me.TxtIdRemision.Text = "" Then
            sql = "SELECT   Codigo FROM RemisionPergamino WHERE (Codigo = '" & Me.NumeroTemporal & "') AND (IdTipoCafe = " & IdTipoCafe & ") "
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(Dataset, "ConsultaSalida")
            If Dataset.Tables("ConsultaSalida").Rows.Count = 0 Then

                '---------------------SI NO SE GUARDO LA REMISION BORRO TODO --------------------------------------------
                StrSqlUpdate = "DELETE FROM Detalle_Pesadas WHERE (NumeroRemision = '" & Me.NumeroTemporal & "') AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') "
                MiConexion.Close()
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                Cont = Me.TDGribListRecibos.RowCount
                i = 0
                Do While Cont > i
                    Me.TDGribListRecibos.Row = i
                    'Eleccion = Me.TDGribListRecibos.Item(i)("Seleccion")
                    'If Eleccion = True Then
                    idReciboPergamino = Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino")
                    '//////////////////////////////////////////////////////////////////////////////////////////////
                    '////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
                    '/////////////////////////////////////////////////////////////////////////////////////////////////
                    MiConexion.Close()
                    sql = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = 0  WHERE(IdReciboPergamino = " & idReciboPergamino & ")"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(sql, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    'End If

                    i = i + 1
                Loop


            End If
        Else



            Cont = Me.TDGribListRecibos.RowCount
            i = 0
            Do While Cont > i
                Me.TDGribListRecibos.Row = i
                idReciboPergamino = Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino")
                IdRemisionPergamino = Me.IdRemision
                '//////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////
                sql = "SELECT CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.IdTipoSaco, DetalleReciboCafePergamino.IdEdoFisico, Dano.IdDano, Dano.Nombre AS Dano, DetalleReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino, RangoImperfeccion.Nombre AS Categoria, RangoImperfeccion.IdRangoImperfeccion, DetalleRemisionPergamino.IdDetalleRemisionPergamino, DetalleRemisionPergamino.IdRemisionPergamino, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual FROM RecibosRemisionPergamino INNER JOIN DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca LEFT OUTER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor " & _
                      "WHERE(DetalleRemisionPergamino.IdRemisionPergamino = " & IdRemisionPergamino & ") AND (DetalleReciboCafePergamino.IdReciboPergamino = " & idReciboPergamino & ") ORDER BY RecibosRemisionPergamino.Orden"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(Dataset, "ConsultaSalida")
                If Dataset.Tables("ConsultaSalida").Rows.Count = 0 Then

                    MiConexion.Close()
                    sql = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = 0  WHERE(IdReciboPergamino = " & idReciboPergamino & ")"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(sql, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    'End If
                End If
                Dataset.Tables("ConsultaSalida").Reset()


                i = i + 1
            Loop


            If NumeroTemporal <> Me.TxtNumeroRemision.Text Then

                '/////////////////////////////////////////////////////////SI LE DA SALIR ELIMINO LAS PESADAS CON NUMEROS TEMPORALES AUNQUE TENGO REMISION ////////

                '---------------------SI NO SE GUARDO LA REMISION BORRO TODO --------------------------------------------
                StrSqlUpdate = "DELETE FROM Detalle_Pesadas WHERE (NumeroRemision = '" & Me.NumeroTemporal & "') AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') "
                MiConexion.Close()
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
        End If
    End Sub



    Private Sub FrmRemision2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CierreFormulario()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------
    Private Sub FrmRemision3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fileReader As String, Ruta As String, SqlString As String, ValidarBoleta As Boolean = True
        Dim LeeArchivo As String = "", Fecha As String = ""
        Dim Contador As Integer, SqlString1 As String

        PegarRemision = False
        Me.NumeroTemporal = Me.Random.Next()

        Quien = "Load"

        ValidaBoleta = True
        'Mando una consulta que no retorna nada
        '------------------------------------------------------------------------------------------------------------------------------
        sql = " SELECT  Proveedor.Cod_Proveedor,Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS CantidadSacos, DetalleReciboCafePergamino.Tara AS Humedad, DetalleReciboCafePergamino.Tara AS IdSaco, DetalleReciboCafePergamino.Tara AS IdEdoFisico, DetalleReciboCafePergamino.Tara AS IdDano ,DetalleReciboCafePergamino.Tara AS PesoBruto , DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.AplicarRemision As Aplicar, ReciboCafePergamino.Fecha, ReciboCafePergamino.IdReciboPergamino FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE   (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Me.DataSetRecibos, "ListaRecibos2")


        '/////////////////////////ACTIVO EL TOOLTIPO TEXT DEL GRID //////////////////////////////
        Me.c1SuperTooltip1.IsBalloon = True
        Me.TDBGridPuntosInterMaquila.CellTips = C1.Win.C1TrueDBGrid.CellTipEnum.Anchored
        Me.c1SuperTooltip1.AutomaticDelay = 0
        Me.c1SuperTooltip1.AutoPopDelay = 20000


        Ruta = My.Application.Info.DirectoryPath & "\SysInfo.txt"
        fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
        Conexion = fileReader
        MiConexion = New SqlClient.SqlConnection(Conexion)
        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If

        sql = "SELECT  NomCalidad, IdCalidad  FROM Calidad"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "calidades")
        If Not Dataset.Tables("calidades").Rows.Count = 0 Then
            Me.CboCalidad.DataSource = Dataset.Tables("calidades")
            If Not IsDBNull(Dataset.Tables("calidades").Rows(0)("NomCalidad")) Then
                Me.CboCalidad.Text = Dataset.Tables("calidades").Rows(0)("NomCalidad")
            End If
        End If

        LeeArchivo = Mid(LeeArchivo, 1, 3)
        SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & LeeArchivo & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Localidad")
        If Dataset.Tables("Localidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            CodLugarAcopio = LeeArchivo
            Me.LblSucursal.Text = Dataset.Tables("Localidad").Rows(0)("NomLugarAcopio")
            IdSucursal = LeeArchivo
            Me.TxtIdLugarAcopio.Text = Dataset.Tables("Localidad").Rows(0)("IdLugarAcopio")
            IdLugarAcopio = Dataset.Tables("Localidad").Rows(0)("IdLugarAcopio")
        End If

        sql = "SELECT  Nombre FROM   TipoCafe  WHERE   (Nombre = 'PERGAMINO') OR  (Nombre = 'MAQUILA')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "TipoDoc")
        Me.CboTipoRemision.DisplayMember = "Nombre"
        Me.CboTipoRemision.DataSource = Dataset.Tables("TipoDoc")

        sql = "SELECT Descripcion FROM  TipoIngreso"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "TipoIngre")
        Me.CboRemTipIngr.DataSource = Dataset.Tables("TipoIngre")
        Me.CboRemTipIngr.Text = "Automatico"



        'CboTipoRemision.Items.Add("Remision Pergamino")
        'CboTipoRemision.Items.Add("Remision Maquila")
        'CboTipoRemision.Text = "Remision Pergamino"

        'CboRemTipIngr.Items.Add("Manual")
        'CboRemTipIngr.Items.Add("Automatico")
        'CboRemTipIngr.Items.Add("Movil")
        'CboRemTipIngr.Text = "Automatico"

        sql = "SELECT IdEstadoDocumento, Descripcion  FROM  EstadoDocumento"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "Estado")
        If Not Dataset.Tables("Estado").Rows.Count = 0 Then

            Me.CboEstadoDoc.DataSource = Dataset.Tables("Estado")
            Me.CboEstadoDoc.DisplayMember = "Descripcion"
            Me.CboEstadoDoc.Splits.Item(0).DisplayColumns(0).Visible = False
            Me.CboEstadoDoc.Columns(1).Caption = "Estado Documento"
            Me.CboEstadoDoc.Text = Dataset.Tables("Estado").Rows(0)("Descripcion")
            Me.CboEstadoDoc.Text = "Editable"

            'Me.TxtIdEstadoDoc.Text = Dataset.Tables("Estado").Rows(0)("IdEstadoDocumento")
        End If

        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.DTPRemFechCarga.Value = Now
        Me.DTPRemFechSalid.Value = Now
        Me.TxtHoraSalida.Text = Format(Me.DTPRemFechSalid.Value, "HH:mm:ss")



        SqlString = "SELECT IdCosecha, Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CDbl(CodigoCosecha) & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Cosecha")
        If Dataset.Tables("Cosecha").Rows.Count = 0 Then
            Me.LblCosecha.Text = "Cosecha NO DEFINIDA"
            Cosecha = "Cosecha NO DEFINIDA"
        Else
            Me.LblCosecha.Text = "Cosecha " & Dataset.Tables("Cosecha").Rows(0)("AñoIni") & "-" & Dataset.Tables("Cosecha").Rows(0)("AñoFin")
            Cosecha = Dataset.Tables("Cosecha").Rows(0)("AñoIni") & "-" & Dataset.Tables("Cosecha").Rows(0)("AñoFin")
            Me.TextIdCosecha.Text = Dataset.Tables("Cosecha").Rows(0)("IdCosecha")
        End If

        'sql = "SELECT DISTINCT EmpresaTransporte.Codigo ,EmpresaTransporte.NombreEmpresa,EmpresaTransporte.IdEmpresaTransporte FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte "
        sql = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, EmpresaTransporte.IdEmpresaTransporte FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN  ContratoTransporte ON EmpresaTransporte.IdEmpresaTransporte = ContratoTransporte.IdEmpresaTransporte " & _
              "WHERE(ContratoTransporte.IdCosecha = " & Me.TextIdCosecha.Text & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "Conductor")
        If Not Dataset.Tables("Conductor").Rows.Count = 0 Then
            Me.CboEmpresaTrans.DataSource = Dataset.Tables("Conductor")
            Me.CboEmpresaTrans.Columns(0).Caption = "Cod"
            Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns(0).Width = 50
            Me.CboEmpresaTrans.Columns(1).Caption = "Empresa"
            Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns(1).Width = 200
            Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns(2).Visible = False
        End If

        sql = "SELECT  Nombre FROM  Conductor "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "Conduc")
        If Not Dataset.Tables("Conduc").Rows.Count = 0 Then
            Me.CboEmpresaCond.DataSource = Dataset.Tables("Conduc")
            Me.CboEmpresaCond.Splits.Item(0).DisplayColumns(0).Width = 270
        End If

        SqlString = "SELECT   LugarAcopio.NomLugarAcopio, TipoLocalidad.IdTipoLocalidad  FROM    TipoLocalidad INNER JOIN  LugarAcopio ON TipoLocalidad.IdTipoLocalidad = LugarAcopio.TipoLugarAcopio  WHERE  (TipoLocalidad.IdTipoLocalidad = 11)  AND  (LugarAcopio.Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Localidades")
        If Dataset.Tables("Localidades").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If

        Me.CboRemLocDest.DataSource = Dataset.Tables("Localidades")
        Me.CboRemLocDest.Text = Dataset.Tables("Localidades").Rows(0)("NomLugarAcopio")
        Me.CboRemLocDest.Splits(0).DisplayColumns("NomLugarAcopio").Width = 300
        Me.CboRemLocDest.Splits(0).DisplayColumns(1).Visible = False

        LeeArchivo = Mid(LeeArchivo, 1, 3)

        'SqlString = "SELECT Codigo FROM ReciboCafePergamino"
        'SqlString = "SELECT    ReciboCafePergamino.Codigo   FROM     ReciboCafePergamino INNER JOIN      EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento   WHERE     (ReciboCafePergamino.Codigo NOT IN       (SELECT DISTINCT ReciboCafePergamino_1.Codigo          FROM            RecibosRemisionPergamino INNER JOIN          DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN     ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (EstadoDocumento.Descripcion = 'Confirmado' OR     EstadoDocumento.Descripcion = 'Editable')"

        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(Dataset, "Recibos")
        'DataAdapter.Fill(Dataset1, "Recibos1")
        'Me.CboRecInicial.DataSource = Dataset.Tables("Recibos")
        'If Not Dataset.Tables("Recibos").Rows.Count = 0 Then
        '    Me.CboRecInicial.Text = Dataset.Tables("Recibos").Rows(0)("Codigo")
        'End If
        'Me.CboRecFinal.DataSource = Dataset1.Tables("Recibos1")
        'If Not Dataset1.Tables("Recibos1").Rows.Count = 0 Then
        '    Me.CboRecFinal.Text = Dataset1.Tables("Recibos1").Rows(0)("Codigo")
        'End If

        '////////////////////////////////////////////////////////LLENO EL COMBO DE DESTINO RUTAS LOGICAS //////////////////////////////////////////////////77
        'SqlString = "SELECT DISTINCT  LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio FROM  EmpresaTransporte INNER JOIN  VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN  ContratoTransporte ON EmpresaTransporte.IdEmpresaTransporte = ContratoTransporte.IdEmpresaTransporte INNER JOIN  RutasLogicasTransporte ON ContratoTransporte.IdContratoTransporte = RutasLogicasTransporte.IdContratoTransporte INNER JOIN LugarAcopio ON RutasLogicasTransporte.IdLugarAcopioDestino = LugarAcopio.IdLugarAcopio  " & _
        '            "WHERE (ContratoTransporte.IdCosecha = " & Me.TextIdCosecha.Text & ") AND (RutasLogicasTransporte.IdLugarAcopioOrigen = " & Me.TxtIdLugarAcopio.Text & ") "
        SqlString = "SELECT DISTINCT LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio  FROM  LugarAcopio INNER JOIN  RutasLogicasTransporte ON LugarAcopio.IdLugarAcopio = RutasLogicasTransporte.IdLugarAcopioDestino " & _
                     "WHERE (RutasLogicasTransporte.IdLugarAcopioOrigen = " & Me.TxtIdLugarAcopio.Text & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "LocalidadesDes")
        Me.CboLocDest.DataSource = Dataset.Tables("LocalidadesDes")
        If Dataset.Tables("LocalidadesDes").Rows.Count > 0 Then
            Me.CboLocDest.Text = Dataset.Tables("LocalidadesDes").Rows(0)("NomLugarAcopio")
            'Me.CboRemLocDest.Text = Dataset.Tables("LocalidadesDes").Rows(0)("NomLugarAcopio")
        End If
        Me.CboLocDest.Splits(0).DisplayColumns("NomLugarAcopio").Width = 300
        Me.CboLocDest.Splits(0).DisplayColumns("CodLugarAcopio").Visible = False

        Me.BtnTeclado.Enabled = False

        sql = "SELECT  Intermedio.Fecha, Intermedio.FechaCarga, Intermedio.FechaSalida, Intermedio.IdOrigen, LugarAcopio.NomLugarAcopio as NomLugarAcopioOrigen, Intermedio.CantidadSacosOrigen,  Intermedio.PesoBrutoOrigen, Intermedio.PesoBrutoOrigen As PesoEntrada, Intermedio.IdEmpresaTransporte, EmpresaTransporte.NombreEmpresa, Intermedio.IdVehiculo, Vehiculo.Placa, Intermedio.IdConductor, Conductor.Nombre, Intermedio.IdDestino, LugarAcopio_1.NomLugarAcopio AS destino, Intermedio.CantidadSacosDestino, Intermedio.PesoBrutoDestino, Intermedio.ConfirmadoIntermedio, Intermedio.NumeroBoleta, Intermedio.IdIntermedio, Intermedio.PesoBrutoEntrada FROM   Intermedio INNER JOIN  EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  RemisionPergamino ON Intermedio.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN   LugarAcopio ON Intermedio.IdDestino = LugarAcopio.IdLugarAcopio INNER JOIN  Vehiculo ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN   Conductor ON Intermedio.IdConductor = Conductor.IdConductor WHERE  (RemisionPergamino.Codigo ='-8995655')AND (Cancelada = '0') AND (RemisionPergamino.IdTipoCafe = " & IdTipoCafe & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "PuntosIntermedios")
        Me.BinPuntosInterMe.DataSource = Dataset.Tables("PuntosIntermedios")
        Me.TDBGridPuntosInter.DataSource = Me.BinPuntosInterMe.DataSource

        'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TDBGridPuntosInter.Columns("Fecha").Caption = "Fecha Entrada"
        Me.TDBGridPuntosInter.Columns("FechaCarga").Caption = "Fecha Carga"
        Me.TDBGridPuntosInter.Columns("FechaSalida").Caption = "Fecha Salida"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdOrigen").Visible = False
        Me.TDBGridPuntosInter.Columns("NomLugarAcopioOrigen").Caption = "Origen"
        Me.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Caption = "Cantidad"
        Me.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Caption = "Peso Bruto"
        Me.TDBGridPuntosInter.Columns("PesoEntrada").Caption = "Peso Entrada"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdEmpresaTransporte").Visible = False
        Me.TDBGridPuntosInter.Columns("NombreEmpresa").Caption = "Nombre Empresa"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdVehiculo").Visible = False
        Me.TDBGridPuntosInter.Columns("Placa").Caption = "Placa"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdConductor").Visible = False
        Me.TDBGridPuntosInter.Columns("Nombre").Caption = "Conductor"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdDestino").Visible = False
        Me.TDBGridPuntosInter.Columns("destino").Caption = "Destino"
        Me.TDBGridPuntosInter.Columns("CantidadSacosDestino").Caption = "Cantidad"
        Me.TDBGridPuntosInter.Columns("PesoBrutoDestino").Caption = "Peso Bruto"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdIntermedio").Visible = False
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("PesoBrutoEntrada").Visible = False

        Me.TDBGridPuntosInter.RowHeight = 30

        'sql = "SELECT Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion,  DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO  FROM DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor WHERE (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = 'xxx') "
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(Dataset, "Recibos")
        'Me.TDGribListRecibos.DataSource = Dataset.Tables("Recibos")

        'SqlString1 = "SELECT     Distinc   Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Productor FROM    ReciboCafePergamino INNER JOIN                          EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo NOT IN                              (SELECT DISTINCT ReciboCafePergamino_1.Codigo                                FROM            RecibosRemisionPergamino INNER JOIN                                                          DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN                                                         ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (EstadoDocumento.Descripcion = 'Confirmado' OR                          EstadoDocumento.Descripcion = 'Editable') AND (ReciboCafePergamino.IdTipoCafe = 2)  "
        'SqlString1 = "SELECT  DISTINCT      Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Productor , ReciboCafePergamino.IdProductor   FROM            ReciboCafePergamino INNER JOIN                           EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN                          Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad WHERE        (ReciboCafePergamino.Codigo NOT IN                              (SELECT DISTINCT ReciboCafePergamino_1.Codigo                                FROM            RecibosRemisionPergamino INNER JOIN                                                          DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN                                                          ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (EstadoDocumento.Descripcion = 'Editable') AND  (ReciboCafePergamino.IdTipoCafe = 2)     "   'AND (Calidad.NomCalidad = '" & Me.CboCalidad.Text & "')

        SqlString1 = "SELECT DISTINCT Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Productor, ReciboCafePergamino.IdProductor FROM ReciboCafePergamino INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE (ReciboCafePergamino.Codigo NOT IN (SELECT DISTINCT ReciboCafePergamino_1.Codigo FROM RecibosRemisionPergamino INNER JOIN DetalleReciboCafePergamino ON  RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN ReciboCafePergamino AS ReciboCafePergamino_1 ON  DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (ReciboCafePergamino.IdTipoCafe = 2) "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString1, MiConexion)
        DataAdapter.Fill(Dataset, "ProductoresMaquila")
        Me.ListPorveedores.DisplayMember = "Productor"
        If Not Dataset.Tables("ProductoresMaquila").Rows.Count = 0 Then
            Me.ListPorveedores.DataSource = Dataset.Tables("ProductoresMaquila")
            Me.ListPorveedores.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
            'Me.ListProveedores.Splits.Item(0).DisplayColumns(0).Width = 290
            'Me.ListProveedores.RowHeight = 30

        End If

        Quien = "Noload"

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Iposicion As Integer, IposicionDetalle As Double
        Dim ConfirmaIntermedio As Boolean


        If Me.CboEstadoDoc.Text = "Editable" Then
            Me.Button2.Enabled = False
            Exit Sub
        Else
            Me.Button2.Enabled = True
        End If


        Quien = "NuevoPunto"
        Iposicion = Me.TDBGridPuntosInter.RowCount
        IposicionDetalle = Iposicion

        ConfirmaIntermedio = True
        If Iposicion > 0 Then
            ConfirmaIntermedio = Me.TDBGridPuntosInter.Item(Iposicion - 1)("ConfirmadoIntermedio")

            '///////////////////////////
            If ConfirmaIntermedio = False Then
                MsgBox("Es necesario Confirmar Intermedio Anteriores", MsgBoxStyle.Critical, "Puntos Intermedio")
                Exit Sub
            End If
        End If

        'IposicionDetalle = Me.TDBGridPuntosInter.Row
        FrmPuntosInter.ConfirmaIntermedio = False

        Me.TDBGridPuntosInter.Row = Me.TDBGridPuntosInter.RowCount
        FrmPuntosInter.Posicion = Iposicion
        FrmPuntosInter.iPosicionDetalle = IposicionDetalle
        FrmPuntosInter.ShowDialog()

        Iposicion = Me.TDBGridPuntosInter.RowCount
        Me.TDBGridPuntosInter.Row = Iposicion
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub CboEmpresaTrans_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmpresaTrans.TextChanged
        Dim SqlString As String, texto As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Me.TxtIdEmprTrans.Text = Me.CboEmpresaTrans.Columns(2).Text

        IdEmpresaTransporte = Me.TxtIdEmprTrans.Text


        '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT Vehiculo.IdVehiculo,Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo  " & _
                    "WHERE (EmpresaTransporte.NombreEmpresa = '" & Me.CboEmpresaTrans.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Placa")
        Me.CboEmprsPlaca.DataSource = Dataset.Tables("Placa")
        Me.CboEmprsPlaca.Splits.Item(0).DisplayColumns(0).Width = 30
        Me.CboEmprsPlaca.Splits.Item(0).DisplayColumns(1).Width = 150
        texto = Me.CboEmprsPlaca.Text


        '////////////////////////////////////////////////////////LLENO EL COMBO DE DESTINO //////////////////////////////////////////////////77
        SqlString = "SELECT DISTINCT LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio, LugarAcopio.IdLugarAcopio  FROM  LugarAcopio INNER JOIN  RutasLogicasTransporte ON LugarAcopio.IdLugarAcopio = RutasLogicasTransporte.IdLugarAcopioDestino " & _
                   "WHERE (RutasLogicasTransporte.IdLugarAcopioOrigen = " & Me.TxtIdLugarAcopio.Text & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "LocalidadesDes")
        Me.CboLocDest.DataSource = Dataset.Tables("LocalidadesDes")
        If Dataset.Tables("LocalidadesDes").Rows.Count > 0 Then
            Me.CboLocDest.Text = Dataset.Tables("LocalidadesDes").Rows(0)("NomLugarAcopio")
            IdRutaLogica = Dataset.Tables("LocalidadesDes").Rows(0)("IdLugarAcopio")
        End If


        sql = "SELECT   Conductor.Nombre FROM Conductor INNER JOIN ConductorEmpresaTransporte ON Conductor.IdConductor = ConductorEmpresaTransporte.IdConductor  " & _
              "WHERE  (ConductorEmpresaTransporte.Activo = 1) AND (ConductorEmpresaTransporte.IdEmpresaTransporte = " & IdEmpresaTransporte & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "Conduc")
        Me.CboEmpresaCond.DataSource = Dataset.Tables("Conduc")

        If Not Dataset.Tables("Conduc").Rows.Count = 0 Then
            Me.CboEmpresaCond.Splits.Item(0).DisplayColumns(0).Width = 270
        End If

    End Sub
    Private Sub DTPRemFechCarga_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPRemFechCarga.ValueChanged
        If QuienRemision = "FechaRemisiones" Then
            Exit Sub
        End If
        Dim Result As DialogResult
        Dim FechaC As Date = Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy HH:mm")
        Dim FechaS As Date = Format(Me.DTPRemFechSalid.Value, "dd/MM/yyyy HH:mm")
        If FechaC > FechaS Then
            'Result = MsgBox("FECHA CARGA ES MAYOR A FECHA SALIDA", MsgBoxStyle.OkOnly, "Remision")
            'If Result = "1" Then
            'DTPRemFechCarga.Value = DTPRemFechSalid.Value
            'End If
        Else
        End If
    End Sub
    Private Sub DTPRemFechSalid_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPRemFechSalid.ValueChanged
        If QuienRemision = "FechaRemisiones" Then
            Exit Sub
        End If
        Dim Result As DialogResult
        Dim FechaC As Date = Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy HH:mm")
        Dim FechaS As Date = Format(Me.DTPRemFechSalid.Value, "dd/MM/yyyy HH:mm")
        Me.TxtHoraSalida.Text = Format(Me.DTPRemFechSalid.Value, "HH:mm:ss")

        If FechaS < FechaC Then
            Result = MsgBox("FECHA SALIDA ES MENOR A FECHA CARGA ", MsgBoxStyle.OkOnly, "Remision")
            If Result = "1" Then
                DTPRemFechSalid.Value = DTPRemFechCarga.Value
            End If
        End If
    End Sub
    Private Sub BtnRemAgreRecib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemAgreRecib.Click
        'FrmListRecibo.ShowDialog()
    End Sub
    Private Sub TxtNumeroRemision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroRemision.Click
        'My.Forms.FrmTeclado.ShowDialog()
        QuienTec = "RemisionNumero"
        My.Forms.FrmTecladoLiqui.ShowDialog()
        If Not My.Forms.FrmTecladoLiqui.Numero = 0 And Not My.Forms.FrmTecladoLiqui.Numero = "" Then
            Me.TxtNumeroRemision.Text = My.Forms.FrmTecladoLiqui.Numero
        End If
    End Sub
    Public Sub TDGridUseParc_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGridUseParc.AfterColUpdate
        Dim row As Double, Eleccion As Boolean, idReciboCafe As Double, Cadena As String, CadenaDiv() As String, CountDet As Double, j As Double, h As Double, max As Double
        Dim PesoNetoPesadas As Double, PesoNetoRecibos As Double, MontoAplicar As Double, PesoReal As Double, IdRecibo As String
        Dim iPos As Double, i As Double, ResultaBusqueda As Integer, SqlString As String
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        row = Me.TDGridUseParc.Row


        Eleccion = Me.TDGridUseParc.Item(row)("Aplicar")
        If Eleccion = True Then
            idReciboCafe = Me.TDGridUseParc.Item(row)("IdDetalleReciboPergamino")

            '//////////////////////////////AHORA RECORRO EL GRID DETALLE PARA VERIFICAR A CUAL GRUPO PERTENECE SI ES PERGAMINO /////
            'If Me.CboTipoRemision.Text = "PERGAMINO" Then
            CountDet = Me.TDBGridDetalle.RowCount
            j = 0
            Do While CountDet > j
                Cadena = Me.TDBGridDetalle.Item(j)("IdDetalleReciboPergamino")
                CadenaDiv = Cadena.Split("-")
                max = UBound(CadenaDiv)
                IdRecibo = idReciboCafe
                ResultaBusqueda = Cadena.IndexOf(IdRecibo)
                h = 0

                If ResultaBusqueda <> -1 Then    '/////////////////SI EL RESULTADO ES CERO SIGNIFICA QUE LO ENCONTRO ///////////////////////
                    For h = 0 To max
                        If IdRecibo = CadenaDiv(h) Then
                            PesoNetoPesadas = Me.TDBGridDetalle.Item(j)("PesoNeto")
                            PesoNetoRecibos = Me.TDBGridDetalle.Item(j)("PesoNeto2")

                            If PesoNetoPesadas = 0 Then
                                MsgBox("Tiene que Pesar la Remision antes de Aplicar Recibo Parcial", MsgBoxStyle.Critical, "Sistema Bascula")
                                Eleccion = False
                                Me.TDGridUseParc.Item(row)("Aplicar") = Eleccion
                                Exit Sub
                            End If


                            '//////////////////////////////////////////////////////////////////////////////////////////////
                            '////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
                            '/////////////////////////////////////////////////////////////////////////////////////////////////
                            MiConexion.Close()
                            SqlString = "UPDATE [ReciboCafePergamino] SET [AplicarRemision] = '" & Eleccion & "'  WHERE(IdReciboPergamino = " & IdRecibo & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()

                            Me.TDBGridMerma.Row = j
                            Me.TDBGridMerma.Columns("Merma").Text = 0


                        Else
                            '///////////////////////////VERIFICO QUE NO EXISTE OTRO SELECCIONADO PARA ELSTE GRUPO /////////////////////////
                            i = Me.BinReciboParcial.Find("IdDetalleReciboPergamino", CadenaDiv(h))
                            Me.BinReciboParcial.Position = i
                            Eleccion = Me.BinReciboParcial.Item(i)("Aplicar")
                            If Eleccion = True Then
                                MsgBox("Existe Otro Recibo Seleccionado ", MsgBoxStyle.Critical, "Recibos")
                                Eleccion = False
                                Me.TDGridUseParc.Item(row)("Aplicar") = Eleccion
                                Exit Sub
                            End If
                        End If
                    Next
                End If

                j = j + 1
            Loop

            MontoAplicar = PesoNetoRecibos - PesoNetoPesadas
            MontoAplicar = Format(MontoAplicar, "##,##0.00")

            If MontoAplicar < 0 Then
                MsgBox("la Pesada no puede ser mayor que los recibos", MsgBoxStyle.Critical, "Sistema de Recibos")
                Eleccion = False
                Me.TDGridUseParc.Item(row)("Aplicar") = Eleccion
                Exit Sub
            End If
            '///////////////////APLICO LA DIFERENCIA A ESTE RECIBO ////////////////////////////
            Me.TDGridUseParc.Row = row
            PesoReal = Me.TDGridUseParc.Columns("PesoReal").Text
            If PesoReal < MontoAplicar Then
                MsgBox("El monto por Aplicar no puede se Mayor que el Recibo", MsgBoxStyle.Critical, "Sistema de Recibos")
                Eleccion = False
                Me.TDGridUseParc.Item(row)("Aplicar") = Eleccion
                Exit Sub
            Else
                Me.TDGridUseParc.Columns("PesoAplicado").Text = PesoReal - MontoAplicar
                Me.TDGridUseParc.Columns("PesoPorAplicar").Text = MontoAplicar





                '//////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////ACTUALIZO LA TABLA DETALLE RECIBO///////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////
                MiConexion.Close()
                SqlString = "UPDATE [DetalleReciboCafePergamino] SET [PesoBrutoRemisionado] = " & PesoReal - MontoAplicar & "  WHERE(IdReciboPergamino = " & IdRecibo & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If


            'ElseIf Me.CboTipoRemision.Text = "MAQUILA" Then

            'End If

        Else
            'Me.TDGridUseParc.Row = e.ColIndex
            IdRecibo = Me.TDGridUseParc.Item(row)("IdDetalleReciboPergamino")
            PesoReal = Me.TDGridUseParc.Columns("PesoReal").Text
            Me.TDGridUseParc.Columns("PesoAplicado").Text = PesoReal
            Me.TDGridUseParc.Columns("PesoPorAplicar").Text = 0.0

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            SqlString = "UPDATE [ReciboCafePergamino] SET [AplicarRemision] = '" & Eleccion & "'  WHERE(IdReciboPergamino = " & IdRecibo & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////ACTUALIZO LA TABLA DETALLE RECIBO///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            SqlString = "UPDATE [DetalleReciboCafePergamino] SET [PesoBrutoRemisionado] = " & PesoReal & "  WHERE(IdReciboPergamino = " & IdRecibo & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            idReciboCafe = Me.TDGridUseParc.Item(row)("IdDetalleReciboPergamino")
            CountDet = Me.TDBGridDetalle.RowCount
            j = 0
            Do While CountDet > j
                Cadena = Me.TDBGridDetalle.Item(j)("IdDetalleReciboPergamino")
                CadenaDiv = Cadena.Split("-")
                max = UBound(CadenaDiv)
                IdRecibo = idReciboCafe
                ResultaBusqueda = Cadena.IndexOf(IdRecibo)
                h = 0

                If ResultaBusqueda <> -1 Then    '/////////////////SI EL RESULTADO ES CERO SIGNIFICA QUE LO ENCONTRO ///////////////////////
                    For h = 0 To max
                        If IdRecibo = CadenaDiv(h) Then
                            PesoNetoPesadas = Me.TDBGridDetalle.Item(j)("PesoNeto")
                            PesoNetoRecibos = Me.TDBGridDetalle.Item(j)("PesoNeto2")

                            Me.TDBGridMerma.Row = j
                            Me.TDBGridMerma.Columns("Merma").Text = Format(PesoNetoRecibos - PesoNetoPesadas, "##,##0.00")
                            Exit Sub
                        Else

                        End If
                    Next
                End If

                j = j + 1
            Loop

            'MontoAplicar = PesoNetoRecibos - PesoNetoPesadas
            'MontoAplicar = Format(MontoAplicar, "##,##0.00")

        End If

        'Dim PesoReal As Double, PesoAplicado As Double, PesoPorAplicar As Double

        'PesoReal = CDbl(Me.TDGridUseParc.Columns("PesoReal").Text)
        'PesoAplicado = CDbl(Me.TDGridUseParc.Columns("PesoAplicado").Text)
        'PesoPorAplicar = PesoReal - PesoAplicado
        'Me.TDGridUseParc.Columns("PesoPorAplicar").Text = Format(PesoPorAplicar, "##,##0.00")

        CalculoGridParcial()
        SumaGridParcial()
    End Sub
    Public Sub SumaGridParcial()
        Dim Count As Integer, i As Integer, SumaPesoReal As Double, SumaPesoAplicado As Double, SumaPesoPorAplicar As Double, SumaPesoRealLista As Double

        SumaPesoReal = 0
        SumaPesoAplicado = 0
        SumaPesoPorAplicar = 0
        SumaPesoRealLista = 0
        Count = Me.TDGridUseParc.RowCount
        i = 0
        Do While Count > i
            Me.TDGridUseParc.Row = i
            Me.TDGribListRecibos.Row = i
            SumaPesoReal = CDbl(Me.TDGridUseParc.Columns("PesoReal").Text) + SumaPesoReal
            SumaPesoAplicado = CDbl(Me.TDGridUseParc.Columns("PesoAplicado").Text) + SumaPesoAplicado
            SumaPesoPorAplicar = CDbl(Me.TDGridUseParc.Columns("PesoPorAplicar").Text) + SumaPesoPorAplicar
            'SumaPesoRealLista = CDbl(Me.TDGribListRecibos.Columns("PESONETO").Text) + SumaPesoRealLista
            i = i + 1
        Loop
        Me.LblTotalPesoReal.Text = Format(SumaPesoReal, "##,##0.00")
        Me.LblSumaPesoAplicado.Text = Format(SumaPesoAplicado, "##,##0.00")
        Me.LblSumaPesoXaplicar.Text = Format(SumaPesoPorAplicar, "##,##0.00")
        Me.LblTotalPeso.Text = Format(SumaPesoRealLista, "##,##0.00")
    End Sub

    Private Sub TDGridUseParc_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridUseParc.AfterDelete

    End Sub
    'RECIBOS)))))))))))))))))))))))))))))))))))))))))))))))))))
    Private Sub TDGridUseParc_AfterUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDGridUseParc.AfterUpdate
        Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double
        Registros = Me.BinLstRecibos.Count
        i = 0
        APlicado = 0
        PorAplicar = 0
        Do While Registros > i
            APlicado = Me.BinLstRecibos.Item(i)("Peso_Aplicado") + APlicado
            Peso = Me.BinLstRecibos.Item(i)("PesoReal") + Peso
            i = i + 1
        Loop
        Me.LblSumaPesoXaplicar.Text = "= " + Format(APlicado, "##,##0.00")
        Me.LblSumaPesoAplicado.Text = Format(Peso - APlicado, "##,##0.00")
    End Sub
    'RECIBOS)))))))))))))))))))))))))))))))))))))))))))))))))))
    Private Sub TDGridUseParc_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TDGridUseParc.BeforeColUpdate
        Dim PesoReal As Double, PesoAplicado As Double, PesoPorAplicar As Double, Eleccion As Boolean, row As Double, idReciboCafe As Double
        PesoReal = CDbl(Me.TDGridUseParc.Columns("PesoReal").Text)
        PesoAplicado = CDbl(Me.TDGridUseParc.Columns("PesoAplicado").Text)
        If PesoAplicado > PesoReal Or PesoAplicado < 0 Then
            MsgBox("El resultado de la operacion no puede ser negativo", MsgBoxStyle.OkOnly, "Remision")
            e.Cancel = True
        End If

    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTeclado.Click
        Dim SaldoInicial As Double, SaldoFinal As Double, Movimiento As Double
        Dim i As Integer, APlicado As Double, PorAplicar As Double, Registros As Integer, Peso As Double

        My.Forms.FrmTeclado.ShowDialog()
        Me.TDGridUseParc.Columns(4).Text = My.Forms.FrmTeclado.Numero
        SaldoInicial = Me.TDGridUseParc.Columns(3).Text
        Movimiento = My.Forms.FrmTeclado.Numero
        If Movimiento > SaldoInicial Then
            Movimiento = 0.0
            Me.TDGridUseParc.Columns(4).Text = Movimiento
            MsgBox("El resultado de la operacion no puede ser negativo", MsgBoxStyle.OkOnly, "Remision")
        Else
            SaldoFinal = SaldoInicial - Movimiento
            Me.TDGridUseParc.Columns(5).Text = Format(SaldoFinal, "##,##0.00")
        End If
        Registros = Me.BinLstRecibos.Count
        i = 0
        APlicado = 0
        PorAplicar = 0
        Do While Registros > i
            APlicado = Me.BinLstRecibos.Item(i)("Peso_Aplicado") + APlicado
            Peso = Me.BinLstRecibos.Item(i)("PesoReal") + Peso
            i = i + 1
        Loop
        Me.LblSumaPesoXaplicar.Text = "= " + Format(APlicado, "##,##0.00")
        Me.LblSumaPesoAplicado.Text = Format(Peso - APlicado, "##,##0.00")
    End Sub
    Private Sub BtnGuardarRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SQLRem As String, Contador As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim i As Integer, Registros As Integer, ID As Double
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, StrSqlInsert As String
        Dim FechaCrg As String, sql2 As String, FechaSal As String, ContadorDetalle As Double, IdsDetallRecibos As String
        Dim IdRemision As Double, IdDetalleRecibo As Double, IdDetalleRemision As Double, Sacos As Integer, Encontrado As Double
        Dim CadenaDiv() As String, Cadena As String, j As Integer, CountDet As Integer, max As Double, h As Double





        'If Registros >= 2 Or Registros = 0 Then
        '    Me.TDBGridPuntosInter.Row = Registros - 1
        'If Me.TDBGridPuntosInter.Columns(13).Text = "" Then
        '    ID = 0
        'Else
        '    ID = Me.TDBGridPuntosInter.Columns(13).Text
        '    SQLRem = "SELECT  IdLugarAcopio, CodLugarAcopio, NomLugarAcopio, IdPadre, IdRegion, TipoLugarAcopio, FDA, Direccion, Telefono, PPCDefecto, CapacidadRecep,    IdUMedidaRecep, CapacidadSecado, IdUMedidaSecado, BultosMaxSecado, IdUsuario, IdCompany, NombreCorto, Fax, Activo, CapacidadAlmacenamiento,  IdUMedidaAlmacenamiento  FROM  LugarAcopio WHERE (NomLugarAcopio LIKE '%Planta Procesadora%') AND (IdLugarAcopio = " & ID & ")"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
        '    DataAdapter.Fill(DataSet, "Intermedio")
        '    If DataSet.Tables("Intermedio").Rows.Count = 0 Then
        '        MsgBox("EL ULTIMO PUNTO INTERMEDIO DEBE SER UNA PLANTA PROCESADORA", MsgBoxStyle.Critical, "PUNTO INTERMEDIO")
        '        Exit Sub
        '    End If
        'End If

        'If Me.TxtNumeroRemision.Text = "" Then
        '    MsgBox("DIGITE UN CODIGO DE REMISION", MsgBoxStyle.Critical, "Detalle Remision")
        '    Exit Sub
        'Else
        '---------------------------------------------------------------------------------------------------
        'GUARDO TABLA REMISION PERMIGAMINO 
        '---------------------------------------------------------------------------------------------------

        'SQLRem = "SELECT   *   FROM   RemisionPergamino  WHERE  (Codigo = '" & Me.TxtIdRemision.Text & "')"
        SQLRem = "SELECT  RemisionPergamino.* FROM RemisionPergamino  WHERE(IdRemisionPergamino = " & Me.TxtIdRemision.Text & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
        DataAdapter.Fill(DataSet, "Remisiones")

        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        FechaCrg = Me.DTPRemFechCarga.Value
        FechaSal = Me.DTPRemFechSalid.Value

        If Me.TxtNumeroRemision.Text = "" Or Me.CboEmpresaTrans.Text = "" Or Me.CboEmpresaCond.Text = "" Or Me.CboEmprsPlaca.Text = "" Then
            MsgBox("ALGUNOS CAMPOS ESTAN VACIOS POR FAVOR REVISE LA INFORMACION", MsgBoxStyle.Critical, "Remision")
            Exit Sub
        Else
            If Not DataSet.Tables("Remisiones").Rows.Count = 0 Then
                '///////////SI EXISTE UNA REMISION LA ACTUALIZO////////////////
                If MsgBox("ESTE CODIGO YA EXISTE DESEA ACTUALIZARLO?", MsgBoxStyle.YesNo, "Remision Cafe") = MsgBoxResult.Yes Then
                    StrSqlUpdate = "UPDATE [RemisionPergamino] SET [FechaCarga] = CONVERT(DATETIME, '" & Format(CDate(FechaCrg), "yyyy-MM-dd") & "', 102)  ,[Fecha] =  CONVERT(DATETIME, '" & Format(CDate(Me.LblFecha.Text), "yyyy-MM-dd") & "', 102) ,[HoraSalida] = CONVERT(DATETIME, '" & Format(CDate(FechaSal), "yyyy-MM-dd HH:mm:ss") & "', 102) ,[Observacion] ='" & Observaciones & "'  ,[IdCosecha] ='" & Me.TextIdCosecha.Text & "' ,[IdLugarAcopio] =  '" & Me.TxtIdLugarAcopio.Text & "' ,[IdCalidad] ='" & Me.TxtIdcalidad.Text & "',[IdEstadoDocumento] ='" & Me.TxtIdEstadoDoc.Text & "'    ,[IdConductor] ='" & Me.TxtIdConductor.Text & "'   ,[IdEmpresaTransporte] ='" & Me.TxtIdEmprTrans.Text & "'   ,[IdVehiculo] ='" & Me.TxtIdVehiculo.Text & "' ,[IdDestino] ='" & Me.TxtDestino.Text & "'   ,[IdTipoIngreso] = '" & Me.TxtIdIngreso.Text & "'  WHERE  (IdRemisionPergamino = '" & Me.TxtIdRemision.Text & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    MsgBox("REMISION ACTUALIZADA CON EXITO", MsgBoxStyle.Exclamation, "Remision")
                Else
                    Exit Sub
                End If
            Else
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlInsert = " INSERT INTO  [dbo].[RemisionPergamino] ([Codigo]  ,[FechaCarga]  ,[Fecha],[HoraSalida] ,[Observacion] ,[IdCosecha]  ,[IdLugarAcopio]  ,[IdCalidad] ,[IdEstadoDocumento]     ,[IdConductor]        ,[IdEmpresaTransporte]   ,[IdVehiculo]   ,[IdDestino] ,[IdTipoCafe]  ,[IdTipoIngreso]  ,[IdUMedida] ,[IdElaboradorPor]  ,[IdUsuario],[IdCompany],[FechaModificacion]  ,[Serie])   " & _
                               " VALUES ('" & Me.TxtNumeroRemision.Text & "', CONVERT(DATETIME, '" & Format(CDate(FechaCrg), "yyyy-MM-dd") & "', 102) , CONVERT(DATETIME, '" & Format(CDate(Me.LblFecha.Text & " " & Me.LblHora.Text), "yyyy-MM-dd HH:mm:ss") & "', 102) , CONVERT(DATETIME, '" & Format(CDate(FechaSal), "yyyy-MM-dd HH:mm:ss") & "', 102) ,'" & Observaciones & "','" & Me.TextIdCosecha.Text & "','" & Me.TxtIdLugarAcopio.Text & "','" & Me.TxtIdcalidad.Text & "','" & Me.TxtIdEstadoDoc.Text & "','" & Me.TxtIdConductor.Text & "','" & Me.TxtIdEmprTrans.Text & "','" & Me.TxtIdVehiculo.Text & "','" & Me.TxtDestino.Text & "','" & IdTipoCafe & "','" & Me.TxtIdIngreso.Text & "','1','0','" & IdUsuario & "','0', CONVERT(DATETIME, '" & Format(CDate(Me.LblFecha.Text), "yyyy-MM-dd") & "', 102) ,'" & Me.TxtSerie.Text & "')"
                MiConexion.Close()
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
                'MsgBox("REMISION GUARDADA CON EXITO", MsgBoxStyle.Exclamation, "Remision")
            End If



        End If

        '-------------------------------------------------------------------------------------------------------------------------------()
        'GUARDO TABLA DETALLE REMISION PERMIGAMINO 
        '--------------------------------------------------------------------------------------------------------------------------------
        'SQLRem = "SELECT   DetalleReciboCafePergamino.CantidadSacos AS Cantidad, DetalleReciboCafePergamino.Humedad, DetalleReciboCafePergamino.PesoBruto, TipoSaco.IdTipoSaco,   EstadoFisico.IdEdoFisico, Dano.IdDano, ReciboCafePergamino.Codigo, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto,  DetalleReciboCafePergamino.IdDetalleReciboPergamino  FROM      ReciboCafePergamino INNER JOIN    Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN    DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN   EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        'SQLRem = "SELECT        IdDetalleRemisionPergamino, CantidadSacos, Humedad, PesoBruto, IdRemisionPergamino, IdSaco, IdEdoFisico, IdDano, IdUsuario FROM            DetalleRemisionPergamino  WHERE        (IdRemisionPergamino =  '" & Me.TxtIdRemision.Text & "')"

        SQLRem = " SELECT * FROM DetalleRemisionPergamino WHERE (IdRemisionPergamino = '" & Me.TxtIdRemision.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
        DataAdapter.Fill(DataSet, "DetallesdeRemisiones")

        i = 0
        Contador = 0
        Contador = Me.TDBGridDetalle.RowCount

        '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
        Do While Contador > i
            If DataSet.Tables("DetallesdeRemisiones").Rows.Count <> 0 Then
                'ACTUALIZO LOS DATOS DE  Detalles de Remisiones
                StrSqlUpdate = "UPDATE [DetalleRemisionPergamino] SET  [CantidadSacos] = '" & Me.TDBGridDetalle.Item(i)("CantidadSacos") & "',[Humedad] = '" & Me.TDBGridDetalle.Item(i)("Humedad") & "' ,[PesoBruto] ='" & Me.TDBGridDetalle.Item(i)("PesoBruto") & "' ,[IdSaco] ='" & Me.TDBGridDetalle.Item(i)("IdTipoSaco") & "'  ,[IdEdoFisico] ='" & Me.TDBGridDetalle.Item(i)("IdEdoFisico") & "'  ,[IdDano] = '" & Me.TDBGridDetalle.Item(i)("IdDano") & "' ,[IdDetalleReciboPergamino] = '" & Me.TDBGridDetalle.Item(i)("IdDetalleReciboPergamino") & "',[PesoNeto2] = '" & Me.TDBGridDetalle.Item(i)("PesoNeto2") & "' ,[Tara] = '" & Me.TDBGridDetalle.Item(i)("Tara") & "'  WHERE  (IdRemisionPergamino = " & IdRemision & ")AND (IdDetalleRemisionPergamino= '" & DataSet.Tables("DetallesdeRemisiones").Rows(i)("IdRemisionPergamino") & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            Else
                '-------------------------------------------------------------------------------------------------------------------------------()
                'BUSCO EL ID DE REMISION 
                '--------------------------------------------------------------------------------------------------------------------------------

                SQLRem = " SELECT  IdRemisionPergamino FROM  RemisionPergamino ORDER BY IdRemisionPergamino DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
                DataAdapter.Fill(DataSet, "IdRemisiones")
                IdRemision = DataSet.Tables("IdRemisiones").Rows(0)("IdRemisionPergamino")

                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                StrSqlInsert = "INSERT INTO [dbo].[DetalleRemisionPergamino]  ([CantidadSacos]    ,[Humedad]    ,[PesoBruto]  ,[IdRemisionPergamino] ,[IdSaco], [IdEdoFisico] ,[IdDano] ,[IdUsuario],[IdDetalleReciboPergamino],[PesoNeto2],[Codigo],[Tara])" & _
                "VALUES ('" & Me.TDBGridDetalle.Item(i)("CantidadSacos") & "','" & Me.TDBGridDetalle.Item(i)("Humedad") & "','" & Me.TDBGridDetalle.Item(i)("PesoBruto") & "','" & IdRemision & "','" & Me.TDBGridDetalle.Item(i)("IdTipoSaco") & "','" & Me.TDBGridDetalle.Item(i)("IdEdoFisico") & "','" & Me.TDBGridDetalle.Item(i)("IdDano") & "','" & IdUsuario & "', '" & Me.TDBGridDetalle.Item(i)("IdDetalleReciboPergamino") & "','" & Me.TDBGridDetalle.Item(i)("PesoNeto2") & "','" & Me.TDBGridDetalle.Item(i)("Codigo") & "','" & Me.TDBGridDetalle.Item(i)("Tara") & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
            i = i + 1
        Loop

        '-------------------------------------------------------------------------------------------------------------------------------()
        'GUARDO TABLA RECIBOREMISON PERGAMINO
        '--------------------------------------------------------------------------------------------------------------------------------

        SQLRem = "SELECT        RecibosRemisionPergamino.IdReciboRemisionPergamino, RecibosRemisionPergamino.PesoNeto, RecibosRemisionPergamino.IdDetalleReciboPergamino, RecibosRemisionPergamino.IdDetalleRemsionPergamino,                           RecibosRemisionPergamino.IdUsuario, RecibosRemisionPergamino.Orden, RemisionPergamino.IdRemisionPergamino FROM            RemisionPergamino INNER JOIN                          DetalleRemisionPergamino ON RemisionPergamino.IdRemisionPergamino = DetalleRemisionPergamino.IdRemisionPergamino INNER JOIN                          RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino WHERE        (RemisionPergamino.IdRemisionPergamino = '" & Me.TxtIdRemision.Text & " ' )     "
        DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
        DataAdapter.Fill(DataSet, "RecibosRemision")

        i = 0
        Contador = 0
        Contador = Me.TDGridUseParc.RowCount
        Do While Contador > i
            If DataSet.Tables("RecibosRemision").Rows.Count <> 0 Then

                'StrSqlUpdate = " UPDATE [RecibosRemisionPergamino] SET [PesoNeto] = '" & Me.TDGridUseParc.Item(i)("PesoAplicado") & "' ,[IdDetalleReciboPergamino] = '" & Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino") & "',[IdDetalleRemsionPergamino] = " & IdDetalleRemision & "  WHERE  (IdDetalleRemsionPergamino = " & IdDetalleRemision & ")AND (IdDetalleReciboPergamino =" & Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino") & ") "
                StrSqlUpdate = "UPDATE [RecibosRemisionPergamino]  SET [PesoNeto] = '" & Me.TDGridUseParc.Item(i)("PesoAplicado") & "' ,[IdDetalleReciboPergamino] = '" & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & "',[IdDetalleRemsionPergamino] = " & Me.TxtIdRemision.Text & "  WHERE  (IdDetalleRemsionPergamino = " & Me.TxtIdRemision.Text & ") AND (IdDetalleReciboPergamino = " & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & ") "
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            Else

                SQLRem = "SELECT        IdDetalleRemisionPergamino, CantidadSacos, Humedad, PesoBruto, IdRemisionPergamino, IdSaco, IdEdoFisico, IdDano, IdUsuario  FROM            DetalleRemisionPergamino WHERE   (IdRemisionPergamino = '" & IdRemision & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
                DataAdapter.Fill(DataSet, "IdDetalleRemision")

                IdDetalleRecibo = Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino")
                CountDet = Me.TDBGridDetalle.RowCount
                j = 0
                Do While CountDet > j
                    Cadena = Me.TDBGridDetalle.Item(j)("IdDetalleReciboPergamino")
                    CadenaDiv = Cadena.Split("-")
                    max = UBound(CadenaDiv)

                    h = 0
                    For h = 0 To max
                        If IdDetalleRecibo = CadenaDiv(h) Then
                            IdDetalleRemision = DataSet.Tables("IdDetalleRemision").Rows(j)("IdDetalleRemisionPergamino")



                            '---------------------------------------------------------------------------------------------------------------------------------
                            'GUARDO RECIBOS REMISION PERGAMINO 
                            '---------------------------------------------------------------------------------------------------------------------------------
                            StrSqlInsert = " INSERT INTO  [RecibosRemisionPergamino] ([PesoNeto] ,[IdDetalleReciboPergamino] ,[IdDetalleRemsionPergamino],[IdUsuario],[Orden])" & _
                                           "VALUES ('" & Me.TDGridUseParc.Item(i)("PesoAplicado") & "','" & Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino") & "'," & IdDetalleRemision & ",'" & IdUsuario & "','" & i & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()

                            Exit Do
                        End If
                    Next

                    j = j + 1
                Loop

            End If

            'DataSet.Tables("RecibosRemisionInsert").Reset()
            i = i + 1
        Loop



        'End If
        '_______________________________________________________________________________________________________________________________()
        'GUARDO PUNTOS INTERMEDIOS
        '_______________________________________________________________________________________________________________________________()
        sql = "SELECT * FROM  Intermedio WHERE(IdRemisionPergamino ='" & IdRemision & "')AND (Cancelada =1)"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "PI")
        Registros = Me.TDBGridPuntosInter.RowCount
        i = 0
        If Me.TxtNumeroRemision.Text = "" Then
            MsgBox("Debe Poner un codigo de Remision", MsgBoxStyle.Critical, "Remision Puntos")
        Else
            If Not DataSet.Tables("PI").Rows.Count = 0 Then
                '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                Do While Registros > i
                    'StrSqlUpdate = "UPDATE [Intermedio]  SET  [Cancelada] = '0' WHERE (IdRemisionPergamino = '" & IdRemision & "')"
                    StrSqlUpdate = "UPDATE [Intermedio]  SET [CantidadSacosOrigen] = '" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosOrigen") & "' ,[PesoBrutoOrigen] = '" & Me.TDBGridPuntosInter.Item(i)("PesoBrutoOrigen") & "',[CantidadSacosDestino] ='" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino") & "',[PesoBrutoDestino] = '" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino") & "' ,[Fecha] =  '" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("Fecha")), "dd/MM/yyyy") & "' ,[FechaSalida] ='" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaSalida")), "dd/MM/yyyy") & "' ,[Cancelada] =  '0' ,[IdRemisionPergamino] = '" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosOrigen") & "' ,[IdEmpresaTransporte] = '" & Me.TDBGridPuntosInter.Item(i)("IdEmpresaTransporte") & "' ,[IdOrigen] =  '" & Me.TDBGridPuntosInter.Item(i)("IdOrigen") & "' ,[IdDestino] = '" & Me.TDBGridPuntosInter.Item(i)("IdDestino") & "',[IdConductor] ='" & Me.TDBGridPuntosInter.Item(i)("IdConductor") & "' ,[IdVehiculo] = '" & Me.TDBGridPuntosInter.Item(i)("IdVehiculo") & "',[FechaCarga]  = '" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaCarga")), "dd/MM/yyyy") & "' WHERE (IdRemisionPergamino = '" & IdRemision & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    i = i + 1
                Loop
            Else
                '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                Do While Registros > i
                    StrSqlUpdate = "INSERT [Intermedio] ([CantidadSacosOrigen] ,[PesoBrutoOrigen] ,[CantidadSacosDestino],[PesoBrutoDestino],[Fecha],[FechaSalida],[Cancelada],[IdRemisionPergamino],[IdEmpresaTransporte],[IdOrigen] ,[IdDestino] ,[IdConductor],[IdVehiculo],[FechaCarga])" & _
                    "VALUES('" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosOrigen") & "','" & Me.TDBGridPuntosInter.Item(i)("PesoBrutoOrigen") & "','" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino") & "','" & Me.TDBGridPuntosInter.Item(i)("PesoBrutoDestino") & "','" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("Fecha")), "dd/MM/yyyy") & "','" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaSalida")), "dd/MM/yyyy") & "','0','" & IdRemision & "','" & Me.TDBGridPuntosInter.Item(i)("IdEmpresaTransporte") & "','" & Me.TDBGridPuntosInter.Item(i)("IdOrigen") & "','" & Me.TDBGridPuntosInter.Item(i)("IdDestino") & "','" & Me.TDBGridPuntosInter.Item(i)("IdConductor") & "','" & Me.TDBGridPuntosInter.Item(i)("IdVehiculo") & "','" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaCarga")), "dd/MM/yyyy") & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    i = i + 1
                Loop
            End If
        End If
        'Else
        'MsgBox("DEBE TENER AL MENOS 2 PUNTOS INTEMEDIOS Y EL DESTINO DEL ULTIMO TIENE QUE SER ")
        'Exit Sub
        'End If
        MsgBox("SE HA GUARDADO CON EXITO", MsgBoxStyle.Information, "Remision")
        LimpiarRem()

    End Sub
    Public Sub LimpiarRem()
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Contador1 As Integer
        Dim fileReader As String, Ruta As String, SqlString As String, SumPaseo As String
        Dim LeeArchivo As String = "", Fecha As String = ""
        Dim Contador As Integer
        Dim sql As String, sql1 As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim DataAdapter1 As New SqlClient.SqlDataAdapter
        Dim SumParPeso As String
        Dim DataSet1 As New DataSet, DataSet As New DataSet
        Dim Num As Integer

        Me.Timer1.Start()

        sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, ReciboCafePergamino.Codigo As Merma FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosRem")
        TDBGridMerma.DataSource = DataSet.Tables("ListaRecibosRem")

        PegarRemision = False
        Me.CboRemTipIngr.Text = "Automatico"
        Me.CboEstadoDoc.Text = "Editable"
        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.DTPRemFechCarga.Value = Now
        Me.DTPRemFechSalid.Value = Now
        Me.TxtHoraSalida.Text = Format(Me.DTPRemFechSalid.Value, "HH:mm:ss")

        SqlString = "SELECT        IdTipoCafe, Codigo, Nombre FROM   TipoCafe  WHERE  (Nombre = '" & Me.CboTipoRemision.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "DsTipoCafe")
        If Not DataSet.Tables("DsTipoCafe").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")) Then
                IdTipoCafe = DataSet.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")
            End If
        End If

        'Select Case Me.CboRemTipIngr.Text
        '    Case "Manual"
        '        Me.TxtNumeroRemision.Enabled = True
        '        Me.TxtNumeroRemision.Text = ""
        '    Case "Automatico"

        '        sql = "SELECT * FROM  RemisionPergamino WHERE  (IdTipoCafe = " & IdTipoCafe & ")"
        '        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        '        DataAdapter.Fill(DataSet, "RemisionPergamino")
        '        If Not DataSet.Tables("RemisionPergamino").Rows.Count = 0 Then
        '            Contador1 = DataSet.Tables("RemisionPergamino").Rows.Count
        '            If Not IsDBNull(DataSet.Tables("RemisionPergamino").Rows(0)("Codigo")) Then
        '                Me.TxtNumeroRemision.Text = Format(DataSet.Tables("RemisionPergamino").Rows(Contador1 - 1)("Codigo") + 1, "00000#")
        '                Me.TxtNumeroRemision.Enabled = False
        '            End If
        '        Else
        '            Me.TxtNumeroRemision.Text = "000001"
        '            Me.TxtNumeroRemision.Enabled = False
        '        End If
        'End Select

        'ConsecutivoRemision()

        Me.NumeroTemporal = Me.Random.Next()


        Me.TxtNumeroRemision.Text = "-----0-----"
        Me.CboEmprsPlaca.Text = ""
        Me.CboEmpresaCond.Text = ""
        Me.CboEmpresaTrans.Text = ""
        ValidaBoleta = False
        Me.TxtNumeroBoleta.Text = ""
        ValidaBoleta = True
        Me.TxtMarca.Text = ""
        Me.TxtCedula.Text = ""
        'SqlString = "SELECT    ReciboCafePergamino.Codigo   FROM     ReciboCafePergamino INNER JOIN      EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento   WHERE     (ReciboCafePergamino.Codigo NOT IN       (SELECT DISTINCT ReciboCafePergamino_1.Codigo          FROM            RecibosRemisionPergamino INNER JOIN          DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN     ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (EstadoDocumento.Descripcion = 'Confirmado' OR     EstadoDocumento.Descripcion = 'Editable')"

        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(Dataset, "Recibos")
        'DataAdapter.Fill(Dataset1, "Recibos1")
        'Me.CboRecInicial.DataSource = Dataset.Tables("Recibos")
        'If Not Dataset.Tables("Recibos").Rows.Count = 0 Then
        '    Me.CboRecInicial.Text = Dataset.Tables("Recibos").Rows(0)("Codigo")
        'End If
        'Me.CboRecFinal.DataSource = Dataset1.Tables("Recibos1")
        'If Not Dataset1.Tables("Recibos1").Rows.Count = 0 Then
        '    Me.CboRecFinal.Text = Dataset1.Tables("Recibos1").Rows(0)("Codigo")
        'End If

        Num = Me.TDGribListRecibos.RowCount
        If Num > 0 Then
            Me.TDGribListRecibos.Delete(0, Num)
        End If


        Num = Me.TDBGridDetalle.RowCount
        If Num > 0 Then
            Me.TDBGridDetalle.Delete(0, Num)
        End If

        Num = Me.TDGridUseParc.RowCount
        If Num > 0 Then
            Me.TDGridUseParc.Delete(0, Num)
        End If

        Num = Me.TDBGridPesoAyCA.RowCount
        If Num > 0 Then
            Me.TDBGridPesoAyCA.Delete(0, Num)
        End If

        Me.LblTotalPeso.Text = "="
        Me.LblTotalPesoReal.Text = "="
        Me.LblSumaPesoAplicado.Text = "="
        Me.LblSumaPesoXaplicar.Text = "="
        Me.LblTotalCSaco.Text = "="
        Me.LblPesoBruto.Text = "="
        Me.LblTaraTotal.Text = "="
        Me.LblPesoNeto.Text = "="
        Observaciones = ""
        Me.TxtIdRemision.Text = ""
        Me.CboTipoRemision.Enabled = True

        Me.BtnGuardarRem.Enabled = True
        Me.Button13.Enabled = True
        Me.Button14.Enabled = True
        Me.BtnBorrarRem.Enabled = True
        Me.Button7.Enabled = True
        Me.Button8.Enabled = True
        Me.CmdPesada.Enabled = True
        Me.BtnFiltrar.Enabled = True
        Me.TDGridUseParc.Enabled = True

        Me.GroupBox2.Enabled = True
        Me.GroupBox3.Enabled = True
        Me.GroupBox4.Enabled = True
        Me.CboCalidad.Enabled = True
        Me.CboRecInicial.Enabled = True
        Me.CboRecFinal.Enabled = True
        Me.Button2.Enabled = True
        Me.Button3.Enabled = True
        Me.Button4.Enabled = True
        Me.CmdConfirma.Enabled = True
        Me.BtnImprimir.Enabled = False

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
            CodLugarAcopio = LeeArchivo
            Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
            IdSucursal = LeeArchivo
            Me.TxtIdLugarAcopio.Text = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
            IdLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
        End If

        sql = "SELECT  Intermedio.Fecha, Intermedio.FechaCarga, Intermedio.FechaSalida, Intermedio.IdOrigen, LugarAcopio.NomLugarAcopio as NomLugarAcopioOrigen, Intermedio.CantidadSacosOrigen,  Intermedio.PesoBrutoOrigen, Intermedio.PesoBrutoOrigen As PesoEntrada, Intermedio.IdEmpresaTransporte, EmpresaTransporte.NombreEmpresa, Intermedio.IdVehiculo, Vehiculo.Placa, Intermedio.IdConductor, Conductor.Nombre, Intermedio.IdDestino, LugarAcopio_1.NomLugarAcopio AS destino, Intermedio.CantidadSacosDestino, Intermedio.PesoBrutoDestino, Intermedio.ConfirmadoIntermedio, Intermedio.NumeroBoleta, Intermedio.IdIntermedio, Intermedio.PesoBrutoEntrada FROM   Intermedio INNER JOIN  EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  RemisionPergamino ON Intermedio.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN   LugarAcopio ON Intermedio.IdDestino = LugarAcopio.IdLugarAcopio INNER JOIN  Vehiculo ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN   Conductor ON Intermedio.IdConductor = Conductor.IdConductor WHERE  (RemisionPergamino.Codigo ='-8995655')AND (Cancelada = '0') AND (RemisionPergamino.IdTipoCafe = " & IdTipoCafe & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "PuntosIntermedios")
        Me.BinPuntosInterMe.DataSource = DataSet.Tables("PuntosIntermedios")
        Me.TDBGridPuntosInter.DataSource = Me.BinPuntosInterMe.DataSource

        'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(0).Visible = False
        Me.TDBGridPuntosInter.Columns("Fecha").Caption = "Fecha Entrada"
        Me.TDBGridPuntosInter.Columns("FechaCarga").Caption = "Fecha Carga"
        Me.TDBGridPuntosInter.Columns("FechaSalida").Caption = "Fecha Salida"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdOrigen").Visible = False
        Me.TDBGridPuntosInter.Columns("NomLugarAcopioOrigen").Caption = "Origen"
        Me.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Caption = "Cantidad"
        Me.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Caption = "Peso Bruto"
        Me.TDBGridPuntosInter.Columns("PesoEntrada").Caption = "Peso Entrada"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdEmpresaTransporte").Visible = False
        Me.TDBGridPuntosInter.Columns("NombreEmpresa").Caption = "Nombre Empresa"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdVehiculo").Visible = False
        Me.TDBGridPuntosInter.Columns("Placa").Caption = "Placa"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdConductor").Visible = False
        Me.TDBGridPuntosInter.Columns("Nombre").Caption = "Conductor"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdDestino").Visible = False
        Me.TDBGridPuntosInter.Columns("destino").Caption = "Destino"
        Me.TDBGridPuntosInter.Columns("CantidadSacosDestino").Caption = "Cantidad"
        Me.TDBGridPuntosInter.Columns("PesoBrutoDestino").Caption = "Peso Bruto"
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdIntermedio").Visible = False
        Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("PesoBrutoEntrada").Visible = False




        'Num = Me.TDBGridPuntosInter.RowCount
        'If Num > 0 Then
        '    Me.TDBGridPuntosInter.Delete(0, Num)
        'End If

    End Sub
    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BtnGuardarRem_Click(sender, e)
    End Sub
    Private Sub TDBGridDetalle_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDBGridDetalle.AfterColUpdate
        Dim i As Integer, CantidadSacos As Double, PesoBruto As Double, Registros As Integer, Tara As Double, PesoNeto As Double, Resultado As Double
        Registros = Me.BinDetalles.Count
        i = 0
        CantidadSacos = 0
        Tara = 0
        PesoBruto = 0
        PesoNeto = 0
        Do While Registros > i
            CantidadSacos = Me.BinDetalles.Item(i)("Cantidad") + CantidadSacos
            PesoBruto = Me.BinDetalles.Item(i)("PesoBruto") + PesoBruto
            Tara = Me.BinDetalles.Item(i)("Tara") + Tara
            PesoNeto = Me.BinDetalles.Item(i)("PesoNeto") + PesoNeto
            i = i + 1
        Loop
        Me.LblTotalCSaco.Text = "= " + Format(CantidadSacos, "##,##0.00")
        Me.LblPesoBruto.Text = "= " + Format(PesoBruto, "##,##0.00")
        Me.LblTaraTotal.Text = "= " + Format(Tara, "##,##0.0000")
        Me.LblPesoNeto.Text = "= " + Format(PesoNeto, "##,##0.00")
    End Sub
    Private Sub TDBGridDetalle_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles TDBGridDetalle.BeforeColUpdate
        Dim PesoBruto As Double, Tara As Double, PesoNeto As Double, SacosComp As Integer, Factor As Double, SacosCant As Integer, Registros As Integer, i As Integer
        Dim CantidadSacos As Integer
        If e.ColIndex = 4 Then
            PesoBruto = Me.TDBGridDetalle.Columns(4).Text
            Tara = Me.TDBGridDetalle.Columns(5).Text
            PesoNeto = PesoBruto - Tara
            Me.TDBGridDetalle.Columns(6).Text = Format(PesoNeto, "##,##0.00")
        ElseIf e.ColIndex = 3 Then
            Tara = Me.TDBGridDetalle.Columns(5).Text
            SacosCant = Me.TDBGridDetalle.Columns(3).Text
            Factor = Me.TDBGridDetalle.Columns(9).Text
            SacosComp = Me.TDBGridDetalle.Columns(8).Text

            If SacosComp <> SacosCant Then
                Tara = SacosCant * Factor
                Me.TDBGridDetalle.Columns(5).Text = Format(Tara, "##,##0.0000")
                SacosComp = SacosCant
                Me.TDBGridDetalle.Columns(8).Text = SacosComp
            End If
        End If

        Registros = Me.BinDetalles.Count
        i = 0
        CantidadSacos = 0
        PesoBruto = 0
        Tara = 0
        PesoNeto = 0
        Do While Registros > i
            CantidadSacos = Me.BinDetalles.Item(i)("Cantidad") + CantidadSacos
            PesoBruto = Me.BinDetalles.Item(i)("PesoBruto") + PesoBruto
            Tara = Me.BinDetalles.Item(i)("Tara") + Tara
            PesoNeto = Me.BinDetalles.Item(i)("PesoNeto") + PesoNeto
            i = i + 1
        Loop
        Me.LblTotalCSaco.Text = "= " + Format(CantidadSacos, "##,##0.00")
        Me.LblPesoBruto.Text = "= " + Format(PesoBruto, "##,##0.00")
        Me.LblTaraTotal.Text = "= " + Format(Tara, "##,##0.0000")
        Me.LblPesoNeto.Text = "= " + Format(PesoNeto, "##,##0.00")
    End Sub
    Private Sub BtnTecladoDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTecladoDetalle.Click
        Dim PesoBruto As Double, Tara As Double, PesoNeto As Double, CantSaco As Integer
        Dim i As Integer, count As Integer, Pesoneto3 As Double, Registros As Integer, Registros1 As Integer, Diferencia As Double, PesoNeto1 As Double, Resultado As Double, SacosCant As Integer
        Dim CantidadSacos As Double, Factor As Double, SacosComp As Double, Estado1 As String, Estado2 As String
        My.Forms.FrmTeclado.ShowDialog()

        If Me.TDBGridDetalle.Col = 3 Then
            Me.TDBGridDetalle.Columns(3).Text = My.Forms.FrmTeclado.Numero

            CantSaco = My.Forms.FrmTeclado.Numero
            Tara = Me.TDBGridDetalle.Columns(5).Text
            SacosCant = Me.TDBGridDetalle.Columns(3).Text
            Factor = Me.TDBGridDetalle.Columns(9).Text
            SacosComp = Me.TDBGridDetalle.Columns(8).Text

            If SacosComp <> SacosCant Then
                Tara = SacosCant * Factor
                Me.TDBGridDetalle.Columns(5).Text = Format(Tara, "##,##0.0000")
                SacosComp = SacosCant
                Me.TDBGridDetalle.Columns(8).Text = SacosComp
                PesoBruto = Me.TDBGridDetalle.Columns(4).Text
                If Tara > PesoBruto Then
                    MsgBox("El resultado de la operacion no puede ser negativo", MsgBoxStyle.OkOnly, "Remision")
                    Exit Sub
                Else
                    PesoNeto = PesoBruto - Tara
                    Me.TDBGridDetalle.Columns(6).Text = Format(PesoNeto, "##,##0.00")
                End If
            End If

        ElseIf Me.TDBGridDetalle.Col = 4 Then
            PesoBruto = My.Forms.FrmTeclado.Numero
            Me.TDBGridDetalle.Columns(4).Text = PesoBruto
            Tara = Me.TDBGridDetalle.Columns(5).Text

            If Tara > PesoBruto Then
                MsgBox("El resultado de la operacion no puede ser negativo", MsgBoxStyle.OkOnly, "Remision")
                Exit Sub
            Else
                i = 0
                PesoNeto = PesoBruto - Tara
                Me.TDBGridDetalle.Columns(6).Text = Format(PesoNeto, "##,##0.00")
            End If
        End If

        i = 0
        CantidadSacos = 0
        PesoBruto = 0
        Tara = 0
        PesoNeto = 0
        Registros = Me.BinDetalles.Count
        Do While Registros > i
            CantidadSacos = Me.BinDetalles.Item(i)("Cantidad") + CantidadSacos
            PesoBruto = Me.BinDetalles.Item(i)("PesoBruto") + PesoBruto
            Tara = Me.BinDetalles.Item(i)("Tara") + Tara
            PesoNeto = Me.BinDetalles.Item(i)("PesoNeto") + PesoNeto
            i = i + 1
        Loop
        Me.LblTotalCSaco.Text = "= " + Format(CantidadSacos, "##,##0.00")
        Me.LblPesoBruto.Text = "= " + Format(PesoBruto, "##,##0.00")
        Me.LblTaraTotal.Text = "= " + Format(Tara, "##,##0.0000")
        Me.LblPesoNeto.Text = "= " + Format(PesoNeto, "##,##0.00")

        Registros1 = Me.BinRecibosAgen.Count
        Estado1 = Me.TDBGridDetalle.Columns(1).Text
        i = 0
        PesoNeto1 = Me.TDBGridDetalle.Columns(6).Text
        Do While Registros1 > i
            Estado2 = Me.BinRecibosAgen.Item(i)("EstadoFisico")
            Pesoneto3 = Me.BinRecibosAgen.Item(i)("PesoNeto")
            If Estado2 = Estado1 Then
                Diferencia = PesoNeto1 - Pesoneto3
                Me.BinRecibosAgen.Item(i)("DDD") = Format(Diferencia, "##,##0.00")
            End If
            i = i + 1
        Loop
    End Sub
    Private Sub BtnRemBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemBusca.Click
        Quien = "Remision"

        My.Forms.FrmConsultasLiqui.IdLugarAcopio = Me.TxtIdLugarAcopio.Text
        My.Forms.FrmConsultasLiqui.ShowDialog()
        If My.Forms.FrmConsultasLiqui.Codigo = "-----0-----" Then
            Exit Sub
        End If
        Me.TxtIdRemision.Text = My.Forms.FrmConsultasLiqui.Codigo
    End Sub
    Private Sub BtnNuevoRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LimpiarRem()
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ''Dim sql As String, sql1 As String, SumPaseo As String
        ''Dim sqlag As String
        'Dim sql As String
        'Dim DataAdapter As New SqlClient.SqlDataAdapter
        'Dim DataAdapter1 As New SqlClient.SqlDataAdapter
        ''Dim SumParPeso As String
        'Dim DataSet1 As New DataSet, DataSet As New DataSet

        'Select Case Me.TabControl1.SelectedIndex
        '    Case 1

        '    Case 2
        'sql = "SELECT  Intermedio.Fecha, Intermedio.FechaCarga, Intermedio.FechaSalida, Intermedio.IdOrigen, LugarAcopio.NomLugarAcopio, Intermedio.CantidadSacosOrigen,  Intermedio.PesoBrutoOrigen, Intermedio.IdEmpresaTransporte, EmpresaTransporte.NombreEmpresa, Intermedio.IdVehiculo, Vehiculo.Placa, Intermedio.IdConductor, Conductor.Nombre, Intermedio.IdDestino, LugarAcopio_1.NomLugarAcopio AS destino, Intermedio.CantidadSacosDestino, Intermedio.PesoBrutoDestino  FROM   Intermedio INNER JOIN  EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  RemisionPergamino ON Intermedio.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN   LugarAcopio ON Intermedio.IdDestino = LugarAcopio.IdLugarAcopio INNER JOIN  Vehiculo ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN   Conductor ON Intermedio.IdConductor = Conductor.IdConductor WHERE  (RemisionPergamino.Codigo ='" & Me.TxtNumeroRemision.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(DataSet, "PuntosIntermedios")
        'Me.BinPuntosInterMe.DataSource = DataSet.Tables("PuntosIntermedios")
        'Me.TDBGridPuntosInter.DataSource = Me.BinPuntosInterMe.DataSource
        'If DataSet.Tables("PuntosIntermedios").Rows.Count = 0 Then
        '    MsgBox("No Existen Puntos Intermedios ", MsgBoxStyle.Exclamation, "Remision")
        'End If
        ''Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(0).Visible = False
        'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(3).Visible = False
        'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(7).Visible = False
        'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(9).Visible = False
        'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(11).Visible = False
        'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(13).Visible = False

        'End Select
    End Sub
    Private Sub CboEmpresaCond_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmpresaCond.TextChanged
        Dim SQL As String = "SELECT Nombre, IdConductor,Cedula  FROM Conductor WHERE (Nombre = '" & Me.CboEmpresaCond.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Cond")
        If Not DataSet.Tables("Cond").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Cond").Rows(0)("IdConductor")) Then
                Me.TxtIdConductor.Text = DataSet.Tables("Cond").Rows(0)("IdConductor")
                Me.TxtCedula.Text = DataSet.Tables("Cond").Rows(0)("Cedula")
                If Me.TxtCedula.Text = "" Then
                    Me.TxtCedula.Text = "---------"
                End If
            End If
        End If
    End Sub
    Private Sub CboEmprsPlaca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmprsPlaca.TextChanged
        'Dim SQL As String = "SELECT IdVehiculo, Placa  FROM Vehiculo WHERE (Placa = '" & Me.CboEmprsPlaca.Text & "')"
        Dim SQL As String = "SELECT Vehiculo.IdVehiculo, Vehiculo.Placa, Vehiculo.IdMarca, Vehiculo.IdTipoVehiculo, Vehiculo.IdUsuario, Vehiculo.IdCompany, Vehiculo.Posicion, Vehiculo.FechaActualizacion, Marca.NombreMarca FROM  Vehiculo LEFT OUTER JOIN  Marca ON Vehiculo.IdMarca = Marca.IdMarca  " & _
                            "WHERE (Vehiculo.Placa = '" & Me.CboEmprsPlaca.Text & "')  "

        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "vehi")
        If Not DataSet.Tables("vehi").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("vehi").Rows(0)("IdVehiculo")) Then
                Me.TxtIdVehiculo.Text = DataSet.Tables("vehi").Rows(0)("IdVehiculo")
            End If
            If Not IsDBNull(DataSet.Tables("vehi").Rows(0)("NombreMarca")) Then
                Me.TxtMarca.Text = DataSet.Tables("vehi").Rows(0)("NombreMarca")
            End If
        End If

        'SQL = "SELECT IdVehiculo, Placa  FROM Vehiculo WHERE (Placa = '" & Me.CboEmprsPlaca.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
        '    Me.TxtIdVehiculo.Text = DataSet.Tables("Consulta").Rows(0)("IdVehiculo")
        'End If





    End Sub
    Private Sub CboRemLocDest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRemLocDest.TextChanged
        Dim SQL As String = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (NomLugarAcopio=  '" & Me.CboRemLocDest.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Destino")
        If Not DataSet.Tables("Destino").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Destino").Rows(0)("IdLugarAcopio")) Then
                Me.TxtDestino.Text = DataSet.Tables("Destino").Rows(0)("IdLugarAcopio")
            End If
        End If
    End Sub
    Private Sub CboCalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCalidad.TextChanged
        Dim SQL As String = "SELECT    IdCalidad  FROM  Calidad WHERE (NomCalidad = '" & Me.CboCalidad.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "calidad")
        If Not DataSet.Tables("calidad").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("calidad").Rows(0)("IdCalidad")) Then
                Me.TxtIdcalidad.Text = DataSet.Tables("calidad").Rows(0)("IdCalidad")
            End If
        End If
    End Sub
    Private Sub CboRemEstad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEstadoDoc.TextChanged
        Dim SQL As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter


        SQL = "SELECT IdEstadoDocumento FROM EstadoDocumento WHERE (Descripcion= '" & Me.CboEstadoDoc.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "estadodoc")
        If Not DataSet.Tables("estadodoc").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("estadodoc").Rows(0)("IdEstadoDocumento")) Then
                Me.TxtIdEstadoDoc.Text = DataSet.Tables("estadodoc").Rows(0)("IdEstadoDocumento")

                If Me.TxtIdRemision.Text <> "" Then
                    SQL = "SELECT  IdRemisionPergamino, ConfirmadoDetalle FROM RemisionPergamino  WHERE (IdRemisionPergamino = " & Me.TxtIdRemision.Text & ")  "
                    DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    ConfirmadoDetalle = False
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        ConfirmadoDetalle = DataSet.Tables("Consulta").Rows(0)("ConfirmadoDetalle")
                    End If


                    If ConfirmadoDetalle = False Then
                        If Me.CboEstadoDoc.Text <> "Editable" Then
                            MsgBox("No se puede cambiar el estado sin confirmar detalle", MsgBoxStyle.Exclamation, "Sistema Bascula")
                            Me.CboEstadoDoc.Text = "Editable"
                            Exit Sub
                        End If
                    End If

                End If
            End If
        End If
    End Sub
    Private Sub CboTipoRemision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoRemision.SelectedIndexChanged
        Dim SQL As String = "SELECT        IdTipoCafe, Codigo, Nombre FROM   TipoCafe  WHERE        (Nombre = '" & Me.CboTipoRemision.Text & "')"
        Dim DataSet As New DataSet, DataSet1 As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion), SqlString As String
        Dim MyRuta As String, Ruta As String
        Dim fileReader As String = ""

        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "DsTipoCafe")
        If Not DataSet.Tables("DsTipoCafe").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")) Then
                IdTipoCafe = DataSet.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")
            End If
        End If



        'Ruta = My.Application.Info.DirectoryPath & "\Cosecha.txt"
        'If Dir(Ruta) <> "" Then
        '    fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
        '    CodigoCosecha = fileReader
        'Else
        '    'MsgBox("No Existe el Archivo Cosecha", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        'End If

        Me.TextIdCosecha.Text = Trim(CodigoCosecha)

        If IdTipoCafe = 2 Then

            Me.LblTotalCSaco.Location = New Point(555, 6)
            Me.LblPesoBruto.Location = New Point(620, 6)
            Me.LblTaraTotal.Location = New Point(705, 6)
            Me.LblPesoNeto.Location = New Point(770, 6)

            Me.LblTotalCSaco.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point)
            Me.LblPesoBruto.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point)
            Me.LblTaraTotal.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point)
            Me.LblPesoNeto.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point)


            Me.LblProductor.Visible = True
            Me.TxtProductores.Visible = True
            Me.PanelPergaminio.Visible = False
            Me.PanelMaquila.Visible = True
            SqlString = "SELECT DISTINCT ReciboCafePergamino.Codigo   FROM  ReciboCafePergamino INNER JOIN  EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe " & _
                        "WHERE (ReciboCafePergamino.IdReciboPergamino NOT IN (SELECT DISTINCT ReciboCafePergamino_1.IdReciboPergamino FROM  RecibosRemisionPergamino INNER JOIN DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN  ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (EstadoDocumento.Descripcion = 'Confirmado') AND  (TipoCafe.Nombre = 'MAQUILA') AND (ReciboCafePergamino.IdLocalidadRegistro = '" & Me.TxtIdLugarAcopio.Text & "') AND (ReciboCafePergamino.IdCosecha = " & Trim(CodigoCosecha) & ") AND (ReciboCafePergamino.IdEstadoDocumento = 294) "

            '///////////////////////////////////////CARGO EL GRID DE PUNTOS INTERMEDIOS DE PERGAMINO ///////////////////////////////////////////////////
            SQL = "SELECT  Intermedio.Fecha, Intermedio.FechaCarga, Intermedio.FechaSalida, EmpresaTransporte.NombreEmpresa, Intermedio.IdOrigen, LugarAcopio.NomLugarAcopio as NomLugarAcopioOrigen, Intermedio.CantidadSacosOrigen,  Intermedio.PesoBrutoOrigen, Intermedio.PesoBrutoOrigen As PesoEntrada, Intermedio.IdEmpresaTransporte, Intermedio.IdVehiculo, Vehiculo.Placa, Intermedio.IdConductor, Conductor.Nombre, Intermedio.IdDestino, LugarAcopio_1.NomLugarAcopio AS destino, Intermedio.CantidadSacosDestino, Intermedio.PesoBrutoDestino FROM   Intermedio INNER JOIN  EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  RemisionPergamino ON Intermedio.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN   LugarAcopio ON Intermedio.IdDestino = LugarAcopio.IdLugarAcopio INNER JOIN  Vehiculo ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN   Conductor ON Intermedio.IdConductor = Conductor.IdConductor WHERE  (RemisionPergamino.Codigo ='" & Me.TxtNumeroRemision.Text & "')AND (Cancelada = '0') AND (RemisionPergamino.IdTipoCafe = " & IdTipoCafe & ") "
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "PuntosIntermedios")
            Me.BinPuntosInterMe.DataSource = DataSet.Tables("PuntosIntermedios")
            Me.TDBGridPuntosInter.DataSource = Me.BinPuntosInterMe.DataSource

            'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(0).Visible = False
            Me.TDBGridPuntosInter.Columns("Fecha").Caption = "Fecha Entrada"
            Me.TDBGridPuntosInter.Columns("FechaCarga").Caption = "Fecha Carga"
            Me.TDBGridPuntosInter.Columns("FechaSalida").Caption = "Fecha Salida"
            Me.TDBGridPuntosInter.Columns("NombreEmpresa").Caption = "Nombre Empresa"
            Me.TDBGridPuntosInter.Columns("NomLugarAcopioOrigen").Caption = "Origen"
            Me.TDBGridPuntosInter.Columns("Placa").Caption = "Placa"
            Me.TDBGridPuntosInter.Columns("Nombre").Caption = "Conductor"
            Me.TDBGridPuntosInter.Columns("destino").Caption = "Destino"


            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdOrigen").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("CantidadSacosOrigen").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("PesoBrutoOrigen").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("PesoEntrada").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("CantidadSacosDestino").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdEmpresaTransporte").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdVehiculo").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdConductor").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdDestino").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("CantidadSacosDestino").Visible = False
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("PesoBrutoDestino").Visible = False

            Me.TDBGridPuntosInter.ChildGrid = Me.TDBGridPuntosInterMaquila
            Me.TDBGridPuntosInterMaquila.Visible = False

            'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(12).Visible = False
            'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(13).Visible = False
            'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(14).Visible = False
            'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(15).Visible = False
            'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(16).Visible = False

            Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 145
            Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 72
            Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 68
            Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Width = 68
            Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Width = 95
            Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Width = 60
            Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Width = 60
            Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Width = 75
            'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Width = 65
            'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(9).Width = 105
            'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(10).Width = 85

            'Me.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Caption = "Cantidad"
            'Me.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Caption = "Peso Bruto"
            'Me.TDBGridPuntosInter.Columns("PesoEntrada").Caption = "Peso Entrada"
            'Me.TDBGridPuntosInter.Columns("CantidadSacosDestino").Caption = "Cantidad"
            'Me.TDBGridPuntosInter.Columns("PesoBrutoDestino").Caption = "Peso Bruto"
        Else

            Me.LblTotalCSaco.Location = New Point(357, 6)
            Me.LblPesoBruto.Location = New Point(460, 6)
            Me.LblTaraTotal.Location = New Point(579, 6)
            Me.LblPesoNeto.Location = New Point(696, 6)

            Me.LblTotalCSaco.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point)
            Me.LblPesoBruto.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point)
            Me.LblTaraTotal.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point)
            Me.LblPesoNeto.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point)


            Me.LblProductor.Visible = False
            Me.TxtProductores.Visible = False
            Me.PanelPergaminio.Visible = True
            Me.PanelMaquila.Visible = False
            Me.PanelGRidProveeedores.Visible = False
            SqlString = "SELECT   DISTINCT ReciboCafePergamino.Codigo   FROM   ReciboCafePergamino INNER JOIN   EstadoDocumento ON ReciboCafePergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe " & _
                        "WHERE (ReciboCafePergamino.IdReciboPergamino NOT IN   (SELECT DISTINCT ReciboCafePergamino_1.IdReciboPergamino FROM RecibosRemisionPergamino INNER JOIN  DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN  ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino)) AND (EstadoDocumento.Descripcion = 'Confirmado') AND  (TipoCafe.Nombre = 'PERGAMINO')   AND (ReciboCafePergamino.IdLocalidadRegistro = '" & Me.TxtIdLugarAcopio.Text & "') AND (ReciboCafePergamino.IdCosecha = " & Trim(CodigoCosecha) & ") AND (ReciboCafePergamino.IdEstadoDocumento = 294) "

            '///////////////////////////////////////CARGO EL GRID DE PUNTOS INTERMEDIOS DE PERGAMINO ///////////////////////////////////////////////////
            SQL = "SELECT  Intermedio.Fecha, Intermedio.FechaCarga, Intermedio.FechaSalida, Intermedio.IdOrigen, LugarAcopio.NomLugarAcopio as NomLugarAcopioOrigen, Intermedio.CantidadSacosOrigen,  Intermedio.PesoBrutoOrigen, Intermedio.PesoBrutoOrigen As PesoEntrada, Intermedio.IdEmpresaTransporte, EmpresaTransporte.NombreEmpresa, Intermedio.IdVehiculo, Vehiculo.Placa, Intermedio.IdConductor, Conductor.Nombre, Intermedio.IdDestino, LugarAcopio_1.NomLugarAcopio AS destino, Intermedio.CantidadSacosDestino, Intermedio.PesoBrutoDestino FROM   Intermedio INNER JOIN  EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  RemisionPergamino ON Intermedio.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN   LugarAcopio ON Intermedio.IdDestino = LugarAcopio.IdLugarAcopio INNER JOIN  Vehiculo ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN   Conductor ON Intermedio.IdConductor = Conductor.IdConductor WHERE  (RemisionPergamino.Codigo ='" & Me.TxtNumeroRemision.Text & "')AND (Cancelada = '0') AND (RemisionPergamino.IdTipoCafe = " & IdTipoCafe & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "PuntosIntermedios")
            Me.BinPuntosInterMe.DataSource = DataSet.Tables("PuntosIntermedios")
            Me.TDBGridPuntosInter.DataSource = Me.BinPuntosInterMe.DataSource

            'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(0).Visible = False
            Me.TDBGridPuntosInter.Columns("Fecha").Caption = "Fecha Entrada"
            Me.TDBGridPuntosInter.Columns("FechaCarga").Caption = "Fecha Carga"
            Me.TDBGridPuntosInter.Columns("FechaSalida").Caption = "Fecha Salida"
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdOrigen").Visible = False
            Me.TDBGridPuntosInter.Columns("NomLugarAcopioOrigen").Caption = "Origen"
            Me.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Caption = "Cantidad"
            Me.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Caption = "Peso Bruto"
            Me.TDBGridPuntosInter.Columns("PesoEntrada").Caption = "Peso Entrada"
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdEmpresaTransporte").Visible = False
            Me.TDBGridPuntosInter.Columns("NombreEmpresa").Caption = "Nombre Empresa"
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdVehiculo").Visible = False
            Me.TDBGridPuntosInter.Columns("Placa").Caption = "Placa"
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdConductor").Visible = False
            Me.TDBGridPuntosInter.Columns("Nombre").Caption = "Conductor"
            Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdDestino").Visible = False
            Me.TDBGridPuntosInter.Columns("destino").Caption = "Destino"
            Me.TDBGridPuntosInter.Columns("CantidadSacosDestino").Caption = "Cantidad"
            Me.TDBGridPuntosInter.Columns("PesoBrutoDestino").Caption = "Peso Bruto"

            'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(9).Visible = False
            'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(11).Visible = False
            'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(13).Visible = True

            Me.TDBGridPuntosInter.ChildGrid = Me.TDBGridPuntosInterMaquila
            Me.TDBGridPuntosInterMaquila.Visible = False

        End If

        'LLeno los cbo de recibos
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Recibos")
        DataAdapter.Fill(DataSet1, "Recibos1")
        Me.CboRecInicial.DataSource = DataSet.Tables("Recibos")
        If Not DataSet.Tables("Recibos").Rows.Count = 0 Then
            Me.CboRecInicial.Text = DataSet.Tables("Recibos").Rows(0)("Codigo")
        End If
        Me.CboRecFinal.DataSource = DataSet1.Tables("Recibos1")
        If Not DataSet1.Tables("Recibos1").Rows.Count = 0 Then
            Me.CboRecFinal.Text = DataSet1.Tables("Recibos1").Rows(0)("Codigo")
        End If





        'ConsecutivoRemision()
    End Sub
    Public Sub CboRemTipIngr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRemTipIngr.TextChanged
        Dim Sql As String
        Dim Contador As Double, Contador1 As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)

        Sql = "SELECT IdTipoIngreso FROM  TipoIngreso WHERE (Descripcion= '" & Me.CboRemTipIngr.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Ingreso")
        If Not DataSet.Tables("Ingreso").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Ingreso").Rows(0)("IdTipoIngreso")) Then

                If Me.TxtIdIngreso.Text <> "" Then
                    If Me.TxtIdIngreso.Text <> DataSet.Tables("Ingreso").Rows(0)("IdTipoIngreso") Then
                        '//////////////////SI TIPO DE INGRESO SON DISTINTOS LO VERFICIO //////////////////////
                        If Not Me.TxtNumeroRemision.Text = "-----0-----" Then
                            If PegarRemision = False Then
                                Me.TxtNumeroRemision.Text = "-----0-----"
                            End If
                        End If
                    End If
                End If

                Me.TxtIdIngreso.Text = DataSet.Tables("Ingreso").Rows(0)("IdTipoIngreso")
            End If
        End If
        ' _________________________________________________________________________________________________________________()
        'EN CASO QUE NO EXISTA REMISIONES LLENO EL TXTiDREMISION
        ' _________________________________________________________________________________________________________________()
        Sql = "SELECT * FROM  RemisionPergamino"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "RemisionPergamino")
        Contador1 = DataSet.Tables("RemisionPergamino").Rows.Count

        'ConsecutivoRemision()

        'Sql = "SELECT        IdTipoCafe, Codigo, Nombre FROM   TipoCafe  WHERE  (Nombre = '" & Me.CboTipoRemision.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        'DataAdapter.Fill(DataSet, "DsTipoCafe")
        'If Not DataSet.Tables("DsTipoCafe").Rows.Count = 0 Then
        '    If Not IsDBNull(DataSet.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")) Then
        '        IdTipoCafe = DataSet.Tables("DsTipoCafe").Rows(0)("IdTipoCafe")
        '    End If
        'End If
        'If Not Me.TxtNumeroRemision.Text = "" Then
        '    If Not Me.TxtNumeroRemision.Text = "-----0-----" Then
        '        Exit Sub
        '    End If
        'End If

        If PegarRemision = True Then
            Exit Sub
        End If

        Select Case Me.CboRemTipIngr.Text
            Case "Manual"
                TxtNumeroRemision_Click(sender, e)
                'Case "Automatico"

        End Select
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        BtnGuardarRem_Click(sender, e)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        BtnGuardarRem_Click(sender, e)
    End Sub
    Private Sub TxtNumeroRemision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroRemision.TextChanged
        Dim CadenaDiv() As String, Cadena As String, Max As Double, i As Double

        Cadena = Me.TxtNumeroRemision.Text
        CadenaDiv = Cadena.Split("-")
        Max = UBound(CadenaDiv)

        If Max >= 2 Then
            Me.TxtSerie.Text = CadenaDiv(0)
            Me.TxtNumeroRemision2.Text = CadenaDiv(1)
        End If



        'i = 0



        'For i = 0 To Max


        'Next


        'Dim Sql As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, DataSet1 As New DataSet, DataAdapter1 As New SqlClient.SqlDataAdapter, SumaRec As String
        'Dim count As Integer
        'Dim sql1 As String, SumPaseo As String, sqldet As String
        'Dim SumParPeso As String


        'Try


        '    Sql = "SELECT *    FROM    RemisionPergamino  WHERE (Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (IdTipoCafe = " & IdTipoCafe & ") "
        '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '    DataAdapter.Fill(DataSet, "Remisiones")

        '    'MsgBox("Desea Activar este usuario ", MsgBoxStyle.YesNo, "Clientes")
        '    If Not DataSet.Tables("Remisiones").Rows.Count = 0 Then

        '        '  IdDestino, IdTipoCafe, IdTipoIngreso, IdUMedida, IdElaboradorPor, IdUsuario, IdCompany, FechaModificacion, Serie, IdtipoDocumento
        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("FechaCarga")) Then
        '            Me.DTPRemFechCarga.Value = DataSet.Tables("Remisiones").Rows(0)("FechaCarga")
        '        Else
        '            Me.DTPRemFechCarga.Value = ""
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("Fecha")) Then
        '            Me.LblFecha.Text = DataSet.Tables("Remisiones").Rows(0)("Fecha")
        '        Else
        '            Me.LblFecha.Text = ""
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("HoraSalida")) Then
        '            Me.DTPRemFechSalid.Text = DataSet.Tables("Remisiones").Rows(0)("HoraSalida")
        '        Else
        '            Me.DTPRemFechSalid.Text = ""
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("Observacion")) Then
        '            Observaciones = DataSet.Tables("Remisiones").Rows(0)("Observacion")
        '        Else
        '            Observaciones = ""
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("IdCosecha")) Then
        '            Me.TextIdCosecha.Text = DataSet.Tables("Remisiones").Rows(0)("IdCosecha")
        '            Sql = "SELECT IdCosecha, Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & Me.TextIdCosecha.Text & ")"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "Cosecha")
        '            If DataSet.Tables("Cosecha").Rows.Count = 0 Then
        '                Me.LblCosecha.Text = "Cosecha NO DEFINIDA"
        '            Else
        '                Me.LblCosecha.Text = "Cosecha " & DataSet.Tables("Cosecha").Rows(0)("AñoIni") & "-" & DataSet.Tables("Cosecha").Rows(0)("AñoFin")
        '                Me.TextIdCosecha.Text = DataSet.Tables("Cosecha").Rows(0)("IdCosecha")
        '            End If
        '        Else
        '            Me.TextIdCosecha.Text = ""
        '        End If



        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("IdLugarAcopio")) Then
        '            'Me.TxtIdLugarAcopio.Text = DataSet.Tables("Remisiones").Rows(0)("IdLugarAcopio")

        '            Sql = "SELECT  * FROM LugarAcopio WHERE (IdLugarAcopio = '" & Me.TxtIdLugarAcopio.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "Localidad")
        '            Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
        '        Else
        '            Me.TxtIdLugarAcopio.Text = ""
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("IdCalidad")) Then
        '            Me.TxtIdcalidad.Text = DataSet.Tables("Remisiones").Rows(0)("IdCalidad")
        '            Sql = "SELECT  NomCalidad, IdCalidad  FROM Calidad WHERE (IdCalidad='" & Me.TxtIdcalidad.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "calidades")
        '            If Not IsDBNull(DataSet.Tables("calidades").Rows(0)("NomCalidad")) Then
        '                Me.CboCalidad.Text = DataSet.Tables("calidades").Rows(0)("NomCalidad")
        '            End If
        '        Else
        '            Me.TxtIdcalidad.Text = ""
        '        End If


        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("IdEstadoDocumento")) Then
        '            Me.TxtIdEstadoDoc.Text = DataSet.Tables("Remisiones").Rows(0)("IdEstadoDocumento")

        '            Sql = "SELECT IdEstadoDocumento, Descripcion  FROM  EstadoDocumento WHERE (IdEstadoDocumento='" & Me.TxtIdEstadoDoc.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "Estadodoc")
        '            If Not DataSet.Tables("Estadodoc").Rows.Count = 0 Then
        '                Me.CboEstadoDoc.Text = DataSet.Tables("Estadodoc").Rows(0)("Descripcion")
        '            End If
        '        Else
        '            Me.TxtIdEstadoDoc.Text = ""
        '        End If


        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("IdConductor")) Then
        '            Me.TxtIdConductor.Text = DataSet.Tables("Remisiones").Rows(0)("IdConductor")

        '            Sql = "SELECT  Nombre FROM  Conductor WHERE (IdConductor = '" & Me.TxtIdConductor.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "Conductor")
        '            If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
        '                Me.CboEmpresaCond.Text = DataSet.Tables("Conductor").Rows(0)("Nombre")
        '            End If
        '        Else
        '            Me.TxtIdConductor.Text = ""
        '        End If


        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("IdEmpresaTransporte")) Then
        '            Me.TxtIdEmprTrans.Text = DataSet.Tables("Remisiones").Rows(0)("IdEmpresaTransporte")

        '            Sql = "SELECT   NombreEmpresa  FROM EmpresaTransporte  WHERE  (IdEmpresaTransporte = '" & Me.TxtIdEmprTrans.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "empresa")
        '            If Not DataSet.Tables("empresa").Rows.Count = 0 Then
        '                Me.CboEmpresaTrans.Text = DataSet.Tables("empresa").Rows(0)("NombreEmpresa")
        '            Else
        '                Me.TxtIdEmprTrans.Text = ""
        '            End If
        '        End If


        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("IdVehiculo")) Then
        '            Me.TxtIdVehiculo.Text = DataSet.Tables("Remisiones").Rows(0)("IdVehiculo")

        '            Sql = "SELECT Placa FROM Vehiculo WHERE (IdVehiculo = '" & Me.TxtIdVehiculo.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "vehiculo")
        '            Me.CboEmprsPlaca.Text = DataSet.Tables("vehiculo").Rows(0)("Placa")

        '        Else
        '            Me.TxtIdVehiculo.Text = ""
        '        End If

        '        If Not IsDBNull(DataSet.Tables("Remisiones").Rows(0)("IdDestino")) Then
        '            Me.TxtDestino.Text = DataSet.Tables("Remisiones").Rows(0)("IdDestino")

        '            Sql = "SELECT  * FROM LugarAcopio WHERE (IdLugarAcopio = '" & Me.TxtDestino.Text & "')"
        '            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '            DataAdapter.Fill(DataSet, "Localidad")
        '            Me.CboRemLocDest.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")

        '        Else
        '            Me.TxtDestino.Text = ""
        '        End If


        '        ''-------------------------------------------------
        '        'CUANDO EL CODIGO NO COINCIDE SE VACIAN LOS CAMPOS
        '        '--------------------------------------------------

        '        'SELECT  RemisionPergamino.Codigo, ReciboCafePergamino.Codigo AS ReciboCodigo  FROM  DetalleReciboCafePergamino INNER JOIN    ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN            DetalleRemisionPergamino INNER JOIN     RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.CantidadSacos = DetalleRemisionPergamino.CantidadSacos AND   DetalleReciboCafePergamino.PesoBruto = DetalleRemisionPergamino.PesoBruto AND DetalleReciboCafePergamino.Humedad = DetalleRemisionPergamino.Humedad AND      DetalleReciboCafePergamino.IdTipoSaco = DetalleRemisionPergamino.IdTipoSaco AND ReciboCafePergamino.IdCalidad = RemisionPergamino.IdCalidad  WHERE        (RemisionPergamino.Codigo = '000002')

        '        'Sql = "SELECT  RemisionPergamino.Codigo, ReciboCafePergamino.Codigo AS ReciboCodigo  FROM  DetalleReciboCafePergamino INNER JOIN    ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN            DetalleRemisionPergamino INNER JOIN     RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.CantidadSacos = DetalleRemisionPergamino.CantidadSacos AND   DetalleReciboCafePergamino.PesoBruto = DetalleRemisionPergamino.PesoBruto AND DetalleReciboCafePergamino.Humedad = DetalleRemisionPergamino.Humedad AND      DetalleReciboCafePergamino.IdTipoSaco = DetalleRemisionPergamino.IdTipoSaco AND ReciboCafePergamino.IdCalidad = RemisionPergamino.IdCalidad  WHERE (RemisionPergamino.Codigo = '" & Me.TxtNumeroRemision.Text & "')"
        '        Sql = "SELECT RemisionPergamino.Codigo, ReciboCafePergamino.Codigo AS ReciboCodigo, ReciboCafePergamino.IdTipoCafe FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN DetalleRemisionPergamino INNER JOIN  RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.CantidadSacos = DetalleRemisionPergamino.CantidadSacos AND DetalleReciboCafePergamino.PesoBruto = DetalleRemisionPergamino.PesoBruto AND DetalleReciboCafePergamino.Humedad = DetalleRemisionPergamino.Humedad And ReciboCafePergamino.IdCalidad = RemisionPergamino.IdCalidad  WHERE  (RemisionPergamino.Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (ReciboCafePergamino.IdTipoCafe = " & Me.TxtIdRemision.Text & ")"
        '        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '        DataAdapter.Fill(DataSet, "codigos")

        '        If DataSet.Tables("codigos").Rows.Count <> 0 Then
        '            Me.CboRecInicial.Text = DataSet.Tables("codigos").Rows(0)("ReciboCodigo")
        '            count = DataSet.Tables("codigos").Rows.Count
        '            Me.CboRecFinal.Text = DataSet.Tables("codigos").Rows(count - 1)("ReciboCodigo")
        '        End If

        '        'Sql = "SELECT  Productor.Nombre+' '+Productor.Apellido1 AS Nombre, Finca.NomFinca, ReciboCafePergamino.Codigo,EstadoFisico.Descripcion,DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Productor ON ReciboCafePergamino.IdProductor = Productor.IdProductor INNER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "' )AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '        Sql = "SELECT        Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, Proveedor.IdProductor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombre FROM   DetalleReciboCafePergamino INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor  " & _
        '              "WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '        SumaRec = "SELECT  SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PESONETO FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '        DataAdapter.Fill(DataSet, "RecibosGrib")
        '        DataAdapter1 = New SqlClient.SqlDataAdapter(SumaRec, MiConexion)
        '        DataAdapter1.Fill(DataSet1, "Suma")
        '        If DataSet.Tables("RecibosGrib").Rows.Count = 0 Then
        '            'MsgBox("No Existe Recibos", MsgBoxStyle.Critical, "Remision")
        '        Else
        '            Me.TDGribListRecibos.DataSource = DataSet.Tables("RecibosGrib")
        '            Me.LblTotalPeso.Text = "= " + Format(DataSet1.Tables("Suma").Rows(0)("PESONETO"), "##,##0.00")
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(0).Width = 190
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(0).Locked = False
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(1).Width = 150
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(1).Locked = False
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(2).Width = 90
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(2).Locked = False
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(3).Width = 140
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(3).Locked = False
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(4).Width = 90
        '            Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(4).Locked = False
        '            Me.TDGribListRecibos.Columns(4).NumberFormat = "##,##0.00"

        '            '_____________________________________________________________________________________________________
        '            'LLENO GRID DE RECIBOS PARCIALES 
        '            '_____________________________________________________________________________________________________
        '            'sql1 = "SELECT   Productor.Nombre + ' ' + Productor.Apellido1 AS Nombre, Finca.NomFinca, ReciboCafePergamino.Codigo, ISNULL(DetalleReciboCafePergamino.PesoBruto, 0) - ISNULL(DetalleReciboCafePergamino.Tara, 0) - ISNULL(RecibosRemisionPergamino.PesoNeto, 0) AS PesoReal,    DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS Peso_Aplicado,   DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.PesoBruto AS PorAplicar  FROM   DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN    Productor ON ReciboCafePergamino.IdProductor = Productor.IdProductor INNER JOIN     Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN     EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico LEFT OUTER JOIN     RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') AND (DetalleReciboCafePergamino.IdDetalleReciboPergamino NOT IN (SELECT DISTINCT RecibosRemisionPergamino.IdDetalleReciboPergamino  FROM  RecibosRemisionPergamino INNER JOIN   DetalleReciboCafePergamino AS DetalleReciboCafePergamino_1 ON  RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino_1.IdDetalleReciboPergamino INNER JOIN  ReciboCafePergamino AS ReciboCafePergamino_1 ON  DetalleReciboCafePergamino_1.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino  WHERE (ReciboCafePergamino_1.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')))"
        '            ''sql1 = "SELECT  Select ReciboCafePergamino.AplicarRemision as Aplicar, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombre, Finca.NomFinca, ReciboCafePergamino.Codigo, ISNULL(DetalleReciboCafePergamino.PesoBruto, 0) - ISNULL(DetalleReciboCafePergamino.Tara, 0) - ISNULL(RecibosRemisionPergamino.PesoNeto, 0) AS PesoReal,    DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS Peso_Aplicado,   DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.PesoBruto AS PorAplicar  FROM   DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN    Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN     Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN     EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico LEFT OUTER JOIN     RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '            'DataAdapter = New SqlClient.SqlDataAdapter(sql1, MiConexion)
        '            'DataAdapter.Fill(DataSet, "RecibosPar")
        '            'If DataSet.Tables("RecibosPar").Rows.Count = 0 Then
        '            '    MsgBox("No Existe Recibos parciales", MsgBoxStyle.Exclamation, "Remision")
        '            '    Exit Sub
        '            'End If

        '            'Me.BinLstRecibos.DataSource = DataSet.Tables("RecibosPar")
        '            'Me.TDGridUseParc.DataSource = Me.BinLstRecibos.DataSource
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns(0).Locked = True
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns(1).Locked = True
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns(2).Locked = True
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns(3).Locked = True
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns(5).Locked = True
        '            Me.TDGridUseParc.Columns(3).NumberFormat = "##,##0.00"
        '            Me.TDGridUseParc.Columns(4).NumberFormat = "##,##0.00"
        '            Me.TDGridUseParc.Columns(5).NumberFormat = "##,##0.00"

        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Aplicar").Width = 30
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Proveedor").Width = 180
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns("NomFinca").Width = 140
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Codigo").Width = 90
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Descripcion").Width = 65
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Dano").Width = 65
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Categoria").Width = 50
        '            Me.TDGridUseParc.Splits.Item(0).DisplayColumns("PesoReal").Width = 100

        '            Me.TDGridUseParc.Columns("Aplicar").Caption = " "
        '            Me.TDGridUseParc.Columns("Proveedor").Caption = "Nombre Productor"
        '            Me.TDGridUseParc.Columns("NomFinca").Caption = "Nombre Finca"
        '            Me.TDGridUseParc.Columns("Codigo").Caption = "Recibo No"
        '            Me.TDGridUseParc.Columns("Descripcion").Caption = "Edo Fisico"
        '            Me.TDGridUseParc.Columns("Dano").Caption = "Daño"
        '            Me.TDGridUseParc.Columns("Categoria").Caption = "Categoria"
        '            Me.TDGridUseParc.Columns("PesoReal").Caption = "Peso Real"
        '            Me.TDGridUseParc.Columns("PesoAplicado").Caption = "Peso Aplicado"
        '            Me.TDGridUseParc.Columns("PesoPorAplicar").Caption = "Peso Por Aplicar"

        '            'SumParPeso = "SELECT  SUM (ISNULL(DetalleReciboCafePergamino.PesoBruto, 0) - ISNULL(DetalleReciboCafePergamino.Tara, 0) - ISNULL(RecibosRemisionPergamino.PesoNeto, 0))  AS PESOReal FROM   DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Productor ON ReciboCafePergamino.IdProductor = Productor.IdProductor INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN   EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico LEFT OUTER JOIN  RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '            'DataAdapter1 = New SqlClient.SqlDataAdapter(SumParPeso, MiConexion)
        '            'DataAdapter1.Fill(DataSet1, "SumaPar")
        '            'If Not IsDBNull(DataSet1.Tables("SumaPar").Rows(0)("PesoReal")) Then
        '            '    Me.LblTotalPesoReal.Text = "= " + Format(DataSet1.Tables("SumaPar").Rows(0)("PesoReal"), "##,##0.00")
        '            'End If

        '            'SumParPeso = "SELECT  DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.PesoBruto AS Peso_Aplicado  FROM   DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Productor ON ReciboCafePergamino.IdProductor = Productor.IdProductor INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN   EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico LEFT OUTER JOIN    RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '            'DataAdapter1 = New SqlClient.SqlDataAdapter(SumParPeso, MiConexion)
        '            'DataAdapter1.Fill(DataSet1, "SumaPaplido")
        '            'If Not IsDBNull(DataSet1.Tables("SumaPaplido").Rows(0)("Peso_Aplicado")) Then
        '            '    Me.LblSumaPesoXaplicar.Text = "= " + Format(DataSet1.Tables("SumaPaplido").Rows(0)("Peso_Aplicado"), "##,##0.00")
        '            'End If

        '            'SumParPeso = "SELECT   SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PorAplicar  FROM   DetalleReciboCafePergamino INNER JOIN    ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN     Productor ON ReciboCafePergamino.IdProductor = Productor.IdProductor INNER JOIN                         Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN    EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico LEFT OUTER JOIN  RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino  WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '            'DataAdapter1 = New SqlClient.SqlDataAdapter(SumParPeso, MiConexion)
        '            'DataAdapter1.Fill(DataSet1, "SumaXapli")
        '            'If Not IsDBNull(DataSet1.Tables("SumaXapli").Rows(0)("PorAplicar")) Then
        '            '    Me.LblSumaPesoAplicado.Text = "= " + Format(DataSet1.Tables("SumaXapli").Rows(0)("PorAplicar"), "##,##0.00")
        '            'End If
        '        End If
        '    End If
        '    '____________________________________________________________________________________________________
        '    'DETALLES REMISION
        '    '____________________________________________________________________________________________________
        '    '
        '    'sqldet = "SELECT Dano.Nombre AS Daño, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, SUM(DetalleReciboCafePergamino.CantidadSacos)  AS Cantidad, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, SUM(DetalleReciboCafePergamino.Tara) AS Tara,  SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, MAX(DetalleReciboCafePergamino.Humedad) AS Humedad,  SUM(DetalleReciboCafePergamino.CantidadSacos) AS SacosComp, SUM(DetalleReciboCafePergamino.Tara) / SUM(DetalleReciboCafePergamino.CantidadSacos)  AS Factor, Dano.IdDano, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico FROM   ReciboCafePergamino  INNER JOIN    Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN    DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN     TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco   WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') GROUP BY Dano.Nombre, EstadoFisico.Descripcion, TipoSaco.Descripcion, Dano.IdDano, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        '    'DataAdapter.Fill(DataSet, "ReDetalle")
        '    'Uso el Binding
        '    'Me.BinDetalles.DataSource = DataSet.Tables("ReDetalle")
        '    'Me.TDBGridDetalle.DataSource = Me.BinDetalles.DataSource

        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 70
        '    Me.TDBGridDetalle.Columns(4).NumberFormat = "##,##0.00"
        '    Me.TDBGridDetalle.Columns(5).NumberFormat = "##,##0.00"
        '    Me.TDBGridDetalle.Columns(6).NumberFormat = "##,##0.00"
        '    Me.TDBGridDetalle.Columns(7).NumberFormat = "##,##0.00"
        '    Me.TDBGridDetalle.Columns(8).NumberFormat = "##,##0.00"

        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Locked = True
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Locked = True
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Locked = True
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Locked = True
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Locked = True
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Locked = True
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Visible = False
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(9).Visible = False
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(10).Visible = False
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(11).Visible = False
        '    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(12).Visible = False


        '    'SumParPeso = "SELECT  SUM(DetalleReciboCafePergamino.CantidadSacos) AS Cantidad FROM   ReciboCafePergamino INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco    WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '    'DataAdapter1 = New SqlClient.SqlDataAdapter(SumParPeso, MiConexion)
        '    'DataAdapter1.Fill(DataSet1, "CantSacos")
        '    'If Not IsDBNull(DataSet1.Tables("CantSacos").Rows(0)("Cantidad")) Then
        '    '    Me.LblTotalCSaco.Text = "= " + Format(DataSet1.Tables("CantSacos").Rows(0)("Cantidad"), "##,##0.00")
        '    'End If

        '    'sqldet = "SELECT SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto FROM   ReciboCafePergamino INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco    WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        '    'DataAdapter.Fill(DataSet, "PesoBrut")
        '    'If Not IsDBNull(DataSet.Tables("PesoBrut").Rows(0)("PesoBruto")) Then
        '    '    Me.LblPesoBruto.Text = "= " + Format(DataSet.Tables("PesoBrut").Rows(0)("PesoBruto"), "##,##0.00")
        '    'End If

        '    'sqldet = "SELECT SUM(DetalleReciboCafePergamino.Tara) AS Tara FROM ReciboCafePergamino INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco    WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        '    'DataAdapter.Fill(DataSet, "Taratotal")
        '    'If Not IsDBNull(DataSet.Tables("Taratotal").Rows(0)("Tara")) Then
        '    '    Me.LblTaraTotal.Text = "= " + Format(DataSet.Tables("Taratotal").Rows(0)("Tara"), "##,##0.00")
        '    'End If

        '    'sqldet = "SELECT SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto FROM ReciboCafePergamino INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco    WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        '    'DataAdapter.Fill(DataSet, "PesoNetoTo")
        '    'If Not IsDBNull(DataSet.Tables("PesoNetoTo").Rows(0)("PesoNeto")) Then
        '    '    Me.LblPesoNeto.Text = "= " + Format(DataSet.Tables("PesoNetoTo").Rows(0)("PesoNeto"), "##,##0.00")
        '    'End If

        '    'sqldet = "SELECT EstadoFisico.Descripcion AS EstadoFisico, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto,   SUM(DetalleReciboCafePergamino.Tara - DetalleReciboCafePergamino.Tara) AS DDD   FROM    ReciboCafePergamino INNER JOIN    Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN    DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN    EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') GROUP BY EstadoFisico.Descripcion"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        '    'DataAdapter.Fill(DataSet, "RecibosDeAgencias")
        '    'Me.BinRecibosAgen.DataSource = DataSet.Tables("RecibosDeAgencias")
        '    'Me.TDBGridPesoAyCA.DataSource = Me.BinRecibosAgen.DataSource
        '    ''____________________________________________________________________________________________________
        '    ''LLENO PUNTOS INTERMEDIOS 
        '    ''____________________________________________________________________________________________________
        '    'Sql = "SELECT  Intermedio.Fecha, Intermedio.FechaCarga, Intermedio.FechaSalida, Intermedio.IdOrigen, LugarAcopio.NomLugarAcopio, Intermedio.CantidadSacosOrigen,  Intermedio.PesoBrutoOrigen, Intermedio.IdEmpresaTransporte, EmpresaTransporte.NombreEmpresa, Intermedio.IdVehiculo, Vehiculo.Placa, Intermedio.IdConductor, Conductor.Nombre, Intermedio.IdDestino, LugarAcopio_1.NomLugarAcopio AS destino, Intermedio.CantidadSacosDestino, Intermedio.PesoBrutoDestino FROM   Intermedio INNER JOIN  EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  RemisionPergamino ON Intermedio.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN   LugarAcopio ON Intermedio.IdDestino = LugarAcopio.IdLugarAcopio INNER JOIN  Vehiculo ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN   Conductor ON Intermedio.IdConductor = Conductor.IdConductor WHERE  (RemisionPergamino.Codigo ='" & Me.TxtNumeroRemision.Text & "')AND (Cancelada = '0') AND (RemisionPergamino.IdTipoCafe =" & IdTipoCafe & ")"
        '    'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '    'DataAdapter.Fill(DataSet, "Pinter")
        '    'Me.BinPuntosInterMe.DataSource = DataSet.Tables("Pinter")
        '    'Me.TDBGridPuntosInter.DataSource = Me.BinPuntosInterMe.DataSource

        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub BtnBorrarRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrarRem.Click

        Dim sql As String, dataadapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim StrSqlDelete As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer

        sql = "SELECT   *   FROM   RemisionPergamino  WHERE  (Codigo = '" & Me.TxtNumeroRemision.Text & "')"
        dataadapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        dataadapter.Fill(DataSet, "Remisiones")
        If Not DataSet.Tables("Remisiones").Rows.Count = 0 Then
            If MsgBox("ESTA SEGURO QUE DESEA ANULAR LA REMISION? " + Me.TxtNumeroRemision.Text, MsgBoxStyle.YesNo, "Zeus Agenda") = MsgBoxResult.Yes Then
                Me.CboEstadoDoc.Text = "Anulado"
                StrSqlDelete = "UPDATE [dbo].[RemisionPergamino]  SET  [IdEstadoDocumento]= '" & Me.TxtIdEstadoDoc.Text & "'   WHERE ( Codigo ='" & Me.TxtNumeroRemision.Text & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlDelete, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                'CANCELO LOS PUNTOS INTERMEDIOS DE LA REMISION
                StrSqlDelete = "UPDATE [Intermedio] SET [Cancelada] = '1'  WHERE ( IdRemisionPergamino =  '" & DataSet.Tables("Remisiones").Rows(0)("IdRemisionPergamino") & "')"
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlDelete, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
            MsgBox("REMISION ANULADA CON EXITO", MsgBoxStyle.Critical, "Remisiones")
            LimpiarRem()
        Else
            MsgBox("LA REMISION NO ESTA ALMACENADA POR LO TANTO NO SE PUEDE BORRAR", MsgBoxStyle.Critical, "Remisiones")
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sqlintermedio As String, Sql As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String, Posicion As Double, CodigoLinea As String = ""
        Dim CodigoIngreso As String = "", SqlString As String = "", Fecha As String
        Dim Iposicion As Double, Confirmado As Boolean

        If Me.CboEstadoDoc.Text = "Editable" Then
            Me.Button3.Enabled = False
            Exit Sub
        Else
            Me.Button3.Enabled = True
        End If

        Iposicion = Me.TDBGridPuntosInter.Row
        Confirmado = Me.TDBGridPuntosInter.Item(Iposicion)("ConfirmadoIntermedio")

        If Confirmado = True Then
            Me.Button3.Enabled = False
            Exit Sub
        ElseIf Confirmado = False Then
            Me.Button3.Enabled = True
        End If

        Resultado = MsgBox("¿ESTA SEGURO QUE QUIERE ELIMINAR ESTE PUNTO INTERMEDIO?", MsgBoxStyle.YesNo, "Remisiones")

        If Resultado <> 6 Then
            Exit Sub
        End If

        Posicion = Me.TDBGridPuntosInter.RowCount
        If Posicion = 0 Then
            MsgBox("NO EXISTEN REGISTROS DE PUNTOS INTERMEDIOS", MsgBoxStyle.Critical, "Puntos intermedios")
            Exit Sub
        End If
        Me.TDBGridPuntosInter.Delete()

        BtnGuardar_Click(sender, e)



    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Conductor As String
        Dim Iposicion As Integer, iPosicionDetalle As Double

        If Me.CboEstadoDoc.Text = "Editable" Then
            Me.Button4.Enabled = False
            Exit Sub
        Else
            Me.Button4.Enabled = True
        End If


        If Me.TDBGridPuntosInter.RowCount = 0 Then
            MsgBox("No se puede editar, No existen registros", MsgBoxStyle.Critical, "Sistema Bascula")
            Exit Sub
        End If




        Quien = "EditarPunto"
        Iposicion = Me.TDBGridPuntosInter.Row
        iPosicionDetalle = Me.TDBGridPuntosInter.Row
        Me.TDBGridPuntosInter.Row = Me.TDBGridPuntosInter.Row + 1

        If Iposicion >= Me.TDBGridPuntosInter.RowCount Then
            MsgBox("No se puede editar, No existen registros", MsgBoxStyle.Critical, "Sistema Bascula")
            Exit Sub
        End If

        FrmPuntosInter.ConfirmaIntermedio = Me.TDBGridPuntosInter.Item(Iposicion)("ConfirmadoIntermedio")
        FrmPuntosInter.IdOrigen = Me.TDBGridPuntosInter.Item(Iposicion)("IdOrigen")
        FrmPuntosInter.IdDestino = Me.TDBGridPuntosInter.Item(Iposicion)("IdDestino")
        FrmPuntosInter.Posicion = Iposicion
        FrmPuntosInter.iPosicionDetalle = iPosicionDetalle
        FrmPuntosInter.ShowDialog()

        Iposicion = Me.TDBGridPuntosInter.RowCount
        Me.TDBGridPuntosInter.Row = Iposicion
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LimpiarRem()
    End Sub
    Private Sub Button6_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LimpiarRem()
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Dim Count As Double, i As Double, idRecibo As Double, Criterios As String, Buscar_Fila() As DataRow
        Dim ResultaBusqueda As Integer, Sqlstring As String, SqlRem As String

        IdRemision = 0
        If Me.TxtIdRemision.Text = "" Then
            SQLRem = "SELECT   *   FROM   RemisionPergamino  WHERE  (Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLugarAcopio & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
            DataAdapter.Fill(Dataset, "Consulta")
            If Dataset.Tables("Consulta").Rows.Count <> 0 Then
                IdRemision = Dataset.Tables("Consulta").Rows(0)("IdRemisionPergamino")
            End If
        Else
            IdRemision = Me.TxtIdRemision.Text
        End If



        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////BUSCO SI EXISTEN REGISTROS EN ESTA REMISION PARA AGREGAR SOLO LOS NUEVOS RECIOS
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        AgregarRegistos = False
        If Me.IdRemision = Nothing Then
            sql = "SELECT   ReciboCafePergamino.AplicarRemision as Aplicar, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal, RecibosRemisionPergamino.PesoNeto AS PesoAplicado, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara - RecibosRemisionPergamino.PesoNeto AS PesoPorAplicar, RemisionPergamino.IdRemisionPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca ORDER BY RecibosRemisionPergamino.Orden"
        Else
            sql = "SELECT   ReciboCafePergamino.AplicarRemision as Aplicar, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal, RecibosRemisionPergamino.PesoNeto AS PesoAplicado, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara - RecibosRemisionPergamino.PesoNeto AS PesoPorAplicar, RemisionPergamino.IdRemisionPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca " & _
                   " WHERE  (RemisionPergamino.IdRemisionPergamino = '" & IdRemision & "') ORDER BY RecibosRemisionPergamino.Orden"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "DetallesDeRemisiones")
        If Dataset.Tables("DetallesDeRemisiones").Rows.Count = 0 Then
            AgregarRegistos = False
        Else
            AgregarRegistos = True
        End If






        '///////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////CREO EL LISTADO DE RECIBOS//////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////
        'If Me.IdTipoCafe = 2 Then
        '    'sql = "SELECT  ReciboCafePergamino.SeleccionRemision as Seleccion, ReciboCafePergamino.AplicarRemision as Aplicar, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino, Calidad.NomCalidad,TipoSaco.Descripcion AS Tiposaco, Dano.Nombre as Dano, RangoImperfeccion.Nombre AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano , DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara as Tara, DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.Fecha  FROM  DetalleReciboCafePergamino INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN                          TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN  UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN                          Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')AND (ReciboCafePergamino.IdTipoCafe='2') "
        '    sql = "SELECT        Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, Calidad.NomCalidad, TipoSaco.Descripcion AS Tiposaco, Dano.Nombre AS Dano, RangoImperfeccion.Nombre AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.IdDetalleReciboPergamino, Proveedor.IdProductor, ReciboCafePergamino.Fecha, ReciboCafePergamino.Codigo, ReciboCafePergamino.SeleccionRemision, ReciboCafePergamino.AplicarRemision, ReciboCafePergamino.IdLocalidadRegistro, ReciboCafePergamino.IdReciboPergamino FROM RangoImperfeccion INNER JOIN  DetalleReciboCafePergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad ON RangoImperfeccion.IdRangoImperfeccion = ReciboCafePergamino.IdRangoImperfeccion INNER JOIN  TipoLocalidad INNER JOIN  LugarAcopio ON TipoLocalidad.IdTipoLocalidad = LugarAcopio.TipoLugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN  Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha LEFT OUTER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca  " & _
        '          "WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') AND (ReciboCafePergamino.IdTipoCafe = '2')"
        'ElseIf Me.IdTipoCafe = 1 Then
        '    'sql = "SELECT  ReciboCafePergamino.SeleccionRemision as Seleccion, ReciboCafePergamino.AplicarRemision as Aplicar, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino, Calidad.NomCalidad, TipoSaco.Descripcion AS Tiposaco, Dano.Nombre as Dano, RangoImperfeccion.Nombre AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano , DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara as Tara, DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.Fecha FROM DetalleReciboCafePergamino INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN                          TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN  UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN                          Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')AND (ReciboCafePergamino.IdTipoCafe='1') 
        '    sql = "SELECT        Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, Calidad.NomCalidad, TipoSaco.Descripcion AS Tiposaco, Dano.Nombre AS Dano, RangoImperfeccion.Nombre AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.IdDetalleReciboPergamino, Proveedor.IdProductor, ReciboCafePergamino.Fecha, ReciboCafePergamino.Codigo, ReciboCafePergamino.SeleccionRemision, ReciboCafePergamino.AplicarRemision, ReciboCafePergamino.IdLocalidadRegistro, ReciboCafePergamino.IdReciboPergamino FROM RangoImperfeccion INNER JOIN  DetalleReciboCafePergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad ON RangoImperfeccion.IdRangoImperfeccion = ReciboCafePergamino.IdRangoImperfeccion INNER JOIN  TipoLocalidad INNER JOIN  LugarAcopio ON TipoLocalidad.IdTipoLocalidad = LugarAcopio.TipoLugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN  Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha LEFT OUTER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca  " & _
        '          "WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') AND (ReciboCafePergamino.IdTipoCafe = '1')"
        'End If
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(Dataset, "DatosRecibos")


        ''/////////////////////////////////////RECORRO EL LISTAD DE RECIBOS CARGADOS EN EL GRID /////////////////////////////////////
        'Count = Me.DataSetRecibos.Tables("ListaRecibos2").Rows.Count
        'i = 0
        'Do While Count > i
        '    idRecibo = Me.DataSetRecibos.Tables("ListaRecibos2").Rows(i)("IdReciboPergamino")

        '    '///////////////////////////////////BUSCO EL RECIBO EN EL DATASET DEL FILTRO//////////////////////////////////

        '    Criterios = "IdReciboPergamino= '" & idRecibo & "' "
        '    Buscar_Fila = Me.Dataset.Tables("DatosRecibos").Select(Criterios)
        '    If Buscar_Fila.Length <> 1 Then  '///////////////SI NO LO ENCUENTRA VERIFICO SI SE GRABO PESADA ///////////////////

        '        Dim CountDet As Double, j As Double, h As Double, max As Double, Cadena As String, CadenaDiv() As String

        '        CountDet = Me.TDBGridDetalle.RowCount
        '        j = 0
        '        Do While CountDet > j
        '            Cadena = Me.TDBGridDetalle.Item(j)("IdDetalleReciboPergamino")
        '            CadenaDiv = Cadena.Split("-")
        '            max = UBound(CadenaDiv)
        '            ResultaBusqueda = Cadena.IndexOf(idRecibo)
        '            h = 0

        '            If ResultaBusqueda = 0 Then    '/////////////////SI EL RESULTADO ES CERO SIGNIFICA QUE LO ENCONTRO ///////////////////////
        '                For h = 0 To max            '/////////////////SI ES MENOS UNO SIGNIFICA QUE NO LO ENCONTRO ////////////////
        '                    'If idRecibo = CadenaDiv(h) Then

        '                    '////////////////////////////////////BUSCO SI ESTE ID EXISTE EN EL DETALLE DE PESADAS ////////////////////////////
        '                    sql = "SELECT Codigo_Beams FROM Detalle_Pesadas WHERE (Codigo_Beams LIKE N'%" & CadenaDiv(h) & "%')"
        '                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        '                    DataAdapter.Fill(Dataset, "DetalleRemision")
        '                    If Dataset.Tables("DetalleRemision").Rows.Count <> 0 Then
        '                        MsgBox("¡¡¡En este Filtro no se estan tomando en cuenta recibos con Pesadas!!!", MsgBoxStyle.Critical, "Sistema Bascula")
        '                        Exit Sub
        '                    End If

        '                    Dataset.Tables("DetalleRemision").Reset()

        '                    'End If

        '                Next

        '            End If

        '            j = j + 1
        '        Loop



        '        '/////////////////////////////////////////////SI NO EXISTE BUSCO SI EXISTEN PESADAS /////////////////////////////////////////
        '        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas  " & _
        '        '      "WHERE  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "')"


        '    End If


        '            i = i + 1
        'Loop

        '        Dataset.Tables("DatosRecibos").Reset()


        'sql = "SELECT Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion,                           DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO  FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') AND (DetalleReciboCafePergamino.IdDetalleReciboPergamino NOT IN                              (SELECT DISTINCT RecibosRemisionPergamino.IdDetalleReciboPergamino                                FROM            RecibosRemisionPergamino INNER JOIN                                                          DetalleReciboCafePergamino AS DetalleReciboCafePergamino_1 ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino_1.IdDetalleReciboPergamino INNER JOIN                                                          ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino_1.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino                                WHERE        (ReciboCafePergamino_1.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')))   "
        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(Dataset, "Recibos")
        'Me.TDGribListRecibos.DataSource = Dataset.Tables("Recibos")

        FrmListRecibo.IdCosecha = CodigoCosecha
        FrmListRecibo.idRemisionPergamino = Me.IdRemision
        FrmListRecibo.ShowDialog()


        'Dim sql As String, sql1 As String, SumPaseo As String
        'Dim DataAdapter As New SqlClient.SqlDataAdapter
        'Dim DataAdapter1 As New SqlClient.SqlDataAdapter
        'Dim SumParPeso As String
        'Dim DataSet1 As New DataSet, DataSet As New DataSet
        ''_______________________________________________________________________________________________________________________________
        ''VALIDO LOS COMBOS DE FILTRO
        ''_______________________________________________________________________________________________________________________________
        'If CboRecInicial.Text = "" Then
        '    MsgBox("necesita Un Valor inical Para Filtrar ", MsgBoxStyle.Critical, "Remision")
        'ElseIf CboRecFinal.Text = "" Then
        '    MsgBox("necesita Un Valor final Para Filtrar ", MsgBoxStyle.Critical, "Remision")
        'ElseIf Me.CboCalidad.Text = "" Then
        '    MsgBox("Necesita una Calidad Para Filtrar ", MsgBoxStyle.Critical, "Remision")
        'Else
        '    '_______________________________________________________________________________________________________________________________
        '    'LENO EL GRIB DE LOS RECIBOS
        '    '_______________________________________________________________________________________________________________________________
        'sql = "SELECT  Productor.Nombre+' '+Productor.Apellido1 AS Nombre, Finca.NomFinca, ReciboCafePergamino.Codigo,EstadoFisico.Descripcion,DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Productor ON ReciboCafePergamino.IdProductor = Productor.IdProductor INNER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "' )AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"

        'sql = "SELECT        Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS NombreProveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion,                           DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO  FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') AND (DetalleReciboCafePergamino.IdDetalleReciboPergamino NOT IN                              (SELECT DISTINCT RecibosRemisionPergamino.IdDetalleReciboPergamino                                FROM            RecibosRemisionPergamino INNER JOIN                                                          DetalleReciboCafePergamino AS DetalleReciboCafePergamino_1 ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino_1.IdDetalleReciboPergamino INNER JOIN                                                          ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino_1.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino                                WHERE        (ReciboCafePergamino_1.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')))   "
        ''SumPaseo = "SELECT        SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PESONETO   FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"

        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        'DataAdapter.Fill(Dataset, "Recibos")


        'DataAdapter1 = New SqlClient.SqlDataAdapter(SumPaseo, MiConexion)
        'DataAdapter1.Fill(Dataset1, "Suma")

        '    If DataSet.Tables("Recibos").Rows.Count = 0 Then
        '        MsgBox("No Existe Recibos", MsgBoxStyle.Critical, "Remision")
        '    Else
        '        Me.TDGribListRecibos.DataSource = DataSet.Tables("Recibos")
        '        Me.LblTotalPeso.Text = "= " + Format(DataSet1.Tables("Suma").Rows(0)("PESONETO"), "##,##0.00")
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(0).Width = 190
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(0).Locked = False
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(1).Width = 150
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(1).Locked = False
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(2).Width = 90
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(2).Locked = False
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(3).Width = 140
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(3).Locked = False
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(4).Width = 90
        '        Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(4).Locked = False
        '        Me.TDGribListRecibos.Columns(4).NumberFormat = "##,##0.00"
        '        'Me.TDGribListRecibos.Splits.Item(0).DisplayColumns(6).Locked = False
        '        Me.BtnTeclado.Enabled = True
        '        '_______________________________________________________________________________________________________________________________
        '        'LLENO EL GRIB DE LOS RECIBOS LISTA USADOS PARCIALEMENTE
        '        '_______________________________________________________________________________________________________________________________

        '        sql1 = "SELECT        Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Nombre, Finca.NomFinca, ReciboCafePergamino.Codigo, ISNULL(DetalleReciboCafePergamino.PesoBruto, 0) - ISNULL(DetalleReciboCafePergamino.Tara,                          0) - ISNULL(RecibosRemisionPergamino.PesoNeto, 0) AS PesoReal, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS Peso_Aplicado,                           DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.PesoBruto AS PorAplicar FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor LEFT OUTER JOIN                          RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') AND (DetalleReciboCafePergamino.IdDetalleReciboPergamino NOT IN                              (SELECT DISTINCT RecibosRemisionPergamino_1.IdDetalleReciboPergamino                                FROM            RecibosRemisionPergamino AS RecibosRemisionPergamino_1 INNER JOIN                                                          DetalleReciboCafePergamino AS DetalleReciboCafePergamino_1 ON RecibosRemisionPergamino_1.IdDetalleReciboPergamino = DetalleReciboCafePergamino_1.IdDetalleReciboPergamino INNER JOIN                                                          ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino_1.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino                                WHERE        (ReciboCafePergamino_1.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')))  "
        '        DataAdapter = New SqlClient.SqlDataAdapter(sql1, MiConexion)
        '        DataAdapter.Fill(DataSet, "RecibosPar")
        '        If DataSet.Tables("RecibosPar").Rows.Count = 0 Then
        '            MsgBox("No Existe Recibos parciales", MsgBoxStyle.Exclamation, "Remision")
        '            Exit Sub
        '        End If

        '        Me.BinLstRecibos.DataSource = DataSet.Tables("RecibosPar")
        '        Me.TDGridUseParc.DataSource = Me.BinLstRecibos.DataSource
        '        Me.TDGridUseParc.Splits.Item(0).DisplayColumns(0).Locked = True
        '        Me.TDGridUseParc.Splits.Item(0).DisplayColumns(1).Locked = True
        '        Me.TDGridUseParc.Splits.Item(0).DisplayColumns(2).Locked = True
        '        Me.TDGridUseParc.Splits.Item(0).DisplayColumns(3).Locked = True
        '        Me.TDGridUseParc.Splits.Item(0).DisplayColumns(5).Locked = True
        '        Me.TDGridUseParc.Columns(3).NumberFormat = "##,##0.00"
        '        Me.TDGridUseParc.Columns(4).NumberFormat = "##,##0.00"
        '        Me.TDGridUseParc.Columns(5).NumberFormat = "##,##0.00"

        '        SumParPeso = "SELECT        SUM(ISNULL(DetalleReciboCafePergamino.PesoBruto, 0) - ISNULL(DetalleReciboCafePergamino.Tara, 0) - ISNULL(RecibosRemisionPergamino.PesoNeto, 0)) AS PESOReal FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor LEFT OUTER JOIN                          RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '        DataAdapter1 = New SqlClient.SqlDataAdapter(SumParPeso, MiConexion)
        '        DataAdapter1.Fill(DataSet1, "SumaPar")
        '        If Not IsDBNull(DataSet1.Tables("SumaPar").Rows(0)("PesoReal")) Then
        '            Me.LblSumaPRParc.Text = "= " + Format(DataSet1.Tables("SumaPar").Rows(0)("PesoReal"), "##,##0.00")
        '        End If

        '        SumParPeso = "SELECT        DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.PesoBruto AS Peso_Aplicado FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor LEFT OUTER JOIN                          RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '        DataAdapter1 = New SqlClient.SqlDataAdapter(SumParPeso, MiConexion)
        '        DataAdapter1.Fill(DataSet1, "SumaPaplido")
        '        If Not IsDBNull(DataSet1.Tables("SumaPaplido").Rows(0)("Peso_Aplicado")) Then
        '            Me.LblSumPAplido.Text = "= " + Format(DataSet1.Tables("SumaPaplido").Rows(0)("Peso_Aplicado"), "##,##0.00")
        '        End If

        '        SumParPeso = "SELECT        SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PorAplicar FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                           Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor LEFT OUTER JOIN                          RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        '        DataAdapter1 = New SqlClient.SqlDataAdapter(SumParPeso, MiConexion)
        '        DataAdapter1.Fill(DataSet1, "SumaXapli")
        '        If Not IsDBNull(DataSet1.Tables("SumaXapli").Rows(0)("PorAplicar")) Then
        '            Me.LblSumPxApli.Text = "= " + Format(DataSet1.Tables("SumaXapli").Rows(0)("PorAplicar"), "##,##0.00")
        '        End If
        '    End If
        'End If
        ''_______________________________________________________________________________________________________________________________()
        ''LLENO EL GRID DE DETALLE REMISION PERGAMINO 
        ''_______________________________________________________________________________________________________________________________()
        'Dim sqdet As String
        'sqldet = "SELECT Dano.Nombre AS Daño, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, SUM(DetalleReciboCafePergamino.CantidadSacos)  AS Cantidad, SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto, SUM(DetalleReciboCafePergamino.Tara) AS Tara,  SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto, MAX(DetalleReciboCafePergamino.Humedad) AS Humedad,  SUM(DetalleReciboCafePergamino.CantidadSacos) AS SacosComp, SUM(DetalleReciboCafePergamino.Tara) / SUM(DetalleReciboCafePergamino.CantidadSacos)  AS Factor, Dano.IdDano, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico FROM   ReciboCafePergamino  INNER JOIN    Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN    DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN     TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco   WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') GROUP BY Dano.Nombre, EstadoFisico.Descripcion, TipoSaco.Descripcion, Dano.IdDano, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico"
        'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        'DataAdapter.Fill(DataSet, "Detalle")
        ''Uso el Binding
        'Me.BinDetalles.DataSource = DataSet.Tables("Detalle")
        'Me.TDBGridDetalle.DataSource = Me.BinDetalles.DataSource

        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 70
        'Me.TDBGridDetalle.Columns(4).NumberFormat = "##,##0.00"
        'Me.TDBGridDetalle.Columns(5).NumberFormat = "##,##0.00"
        'Me.TDBGridDetalle.Columns(6).NumberFormat = "##,##0.00"
        'Me.TDBGridDetalle.Columns(7).NumberFormat = "##,##0.00"
        'Me.TDBGridDetalle.Columns(8).NumberFormat = "##,##0.00"

        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Locked = True
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Locked = True
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Locked = True
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Locked = True
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Locked = True
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Locked = True
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Visible = False
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(9).Visible = False
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(10).Visible = False
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(11).Visible = False
        'Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(12).Visible = False

        'SumParPeso = "SELECT  SUM(DetalleReciboCafePergamino.CantidadSacos) AS Cantidad FROM   ReciboCafePergamino INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco    WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        'DataAdapter1 = New SqlClient.SqlDataAdapter(SumParPeso, MiConexion)
        'DataAdapter1.Fill(DataSet1, "CantSacos")
        'If Not IsDBNull(DataSet1.Tables("CantSacos").Rows(0)("Cantidad")) Then
        '    Me.LblTotalCSaco.Text = "= " + Format(DataSet1.Tables("CantSacos").Rows(0)("Cantidad"), "##,##0.00")
        'End If

        'sqldet = "SELECT SUM(DetalleReciboCafePergamino.PesoBruto) AS PesoBruto FROM   ReciboCafePergamino INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco    WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        'DataAdapter.Fill(DataSet, "PesoBrut")
        'If Not IsDBNull(DataSet.Tables("PesoBrut").Rows(0)("PesoBruto")) Then
        '    Me.LblPesoBruto.Text = "= " + Format(DataSet.Tables("PesoBrut").Rows(0)("PesoBruto"), "##,##0.00")
        'End If

        'sqldet = "SELECT SUM(DetalleReciboCafePergamino.Tara) AS Tara FROM ReciboCafePergamino INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco    WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        'DataAdapter.Fill(DataSet, "Taratotal")
        'If Not IsDBNull(DataSet.Tables("Taratotal").Rows(0)("Tara")) Then
        '    Me.LblTaraTotal.Text = "= " + Format(DataSet.Tables("Taratotal").Rows(0)("Tara"), "##,##0.00")
        'End If

        'sqldet = "SELECT SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto FROM ReciboCafePergamino INNER JOIN   Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco    WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        'DataAdapter.Fill(DataSet, "PesoNetoTo")
        'If Not IsDBNull(DataSet.Tables("PesoNetoTo").Rows(0)("PesoNeto")) Then
        '    Me.LblPesoNeto.Text = "= " + Format(DataSet.Tables("PesoNetoTo").Rows(0)("PesoNeto"), "##,##0.00")
        'End If
        ''_______________________________________________________________________________________________________________________________()
        ''LLENO EL GRID DE LOS PESOS RECIBIDOS EN DE AGENCIA Y CENTROS DE ACOPIO
        ''_______________________________________________________________________________________________________________________________()
        'sqldet = "SELECT EstadoFisico.Descripcion AS EstadoFisico, SUM(DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara) AS PesoNeto,   SUM(DetalleReciboCafePergamino.Tara - DetalleReciboCafePergamino.Tara) AS DDD   FROM    ReciboCafePergamino INNER JOIN    Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN    DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN    EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "') GROUP BY EstadoFisico.Descripcion"
        'DataAdapter = New SqlClient.SqlDataAdapter(sqldet, MiConexion)
        'DataAdapter.Fill(DataSet, "RecibosDeAgencias")
        'Me.BinRecibosAgen.DataSource = DataSet.Tables("RecibosDeAgencias")
        'Me.TDBGridPesoAyCA.DataSource = Me.BinRecibosAgen.DataSource
        'If DataSet.Tables("RecibosDeAgencias").Rows.Count = 0 Then
        '    MsgBox("No Existe Recibos de agencias ", MsgBoxStyle.Exclamation, "Remision")
        '    Exit Sub
        'End If
    End Sub
    Public Sub SumaGridAgrupados()
        Dim CantidadSacos As Double, PesoBruto As Double, Tara As Double, PesoNeto As Double, Count As Double, i As Double
        CantidadSacos = 0
        PesoBruto = 0
        Tara = 0
        PesoNeto = 0
        Count = Me.TDBGridDetalle.RowCount
        i = 0

        If IdTipoCafe = 2 Then
            Do While Count > i
                Me.TDGridUseParc.Row = i
                Me.TDGribListRecibos.Row = i
                CantidadSacos = CDbl(Me.TDBGridDetalle.Item(i)(6)) + CantidadSacos
                PesoBruto = CDbl(Me.TDBGridDetalle.Item(i)(7)) + PesoBruto
                Tara = CDbl(Me.TDBGridDetalle.Item(i)(8)) + Tara
                PesoNeto = CDbl(Me.TDBGridDetalle.Item(i)(9)) + PesoNeto
                i = i + 1
            Loop
        ElseIf IdTipoCafe = 1 Then
            Do While Count > i
                Me.TDGridUseParc.Row = i
                Me.TDGribListRecibos.Row = i
                CantidadSacos = CDbl(Me.TDBGridDetalle.Item(i)(3)) + CantidadSacos
                PesoBruto = CDbl(Me.TDBGridDetalle.Item(i)(4)) + PesoBruto
                Tara = CDbl(Me.TDBGridDetalle.Item(i)(5)) + Tara
                PesoNeto = CDbl(Me.TDBGridDetalle.Item(i)(6)) + PesoNeto
                i = i + 1
            Loop
        End If

        Me.LblTotalCSaco.Text = "= " & Format(CantidadSacos, "##,##0.00")
        Me.LblPesoBruto.Text = "= " & Format(PesoBruto, "##,##0.00")
        Me.LblTaraTotal.Text = "= " & Format(Tara, "##,##0.00")
        Me.LblPesoNeto.Text = "= " & Format(PesoNeto, "##,##0.00")
    End Sub
    Private Sub TDGridUseParc_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TDGridUseParc.BeforeDelete

    End Sub

    Private Sub TDGridUseParc_BeforeOpen(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TDGridUseParc.BeforeOpen

    End Sub

    Private Sub TDGridUseParc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGridUseParc.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TDGribListRecibos_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles TDGribListRecibos.AfterColUpdate
        Dim PesoReal As Double, PesoAplicado As Double, PesoPorAplicar As Double, posicion As Double

        posicion = Me.TDGribListRecibos.Row
        Me.TDGridUseParc.Row = posicion

        PesoAplicado = CDbl(Me.TDGribListRecibos.Columns("PESONETO").Text)
        Me.TDGridUseParc.Columns("PesoAplicado").Text = PesoAplicado
        CalculoGridParcial()
        'TDGridUseParc_AfterColUpdate(e, sender)
    End Sub
    Public Sub CalculoGridParcial()
        Dim PesoReal As Double, PesoAplicado As Double, PesoPorAplicar As Double

        If TDGridUseParc.RowCount <> 0 Then
            PesoReal = CDbl(Me.TDGridUseParc.Columns("PesoReal").Text)
            PesoAplicado = CDbl(Me.TDGridUseParc.Columns("PesoAplicado").Text)
            PesoPorAplicar = PesoReal - PesoAplicado
            Me.TDGridUseParc.Columns("PesoPorAplicar").Text = Format(PesoPorAplicar, "##,##0.00")
        End If

        SumaGridParcial()
    End Sub
    Private Sub TDGribListRecibos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDGribListRecibos.Click

    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        FrmObservaciones.TxtObservaciones.Text = Observaciones
        FrmObservaciones.ShowDialog()
        If FrmObservaciones.TxtObservaciones.Text <> "" Then
            Observaciones = FrmObservaciones.TxtObservaciones.Text
        End If


    End Sub
    Private Sub CmdPesada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPesada.Click
        Dim iPosicion As Double, Cont As Double, i As Double, NumeroFactura As String, PesoReal As Double, PesoAplicado As Double, PesoPorAplicar As Double
        Dim Peso1 As Double, Peso2 As Double, TipoPesada As String, TipoRemision As String, NumeroRemision As String, Cadena As String, CadenaDiv() As String, Max As Double
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, IdDetalleRecibo As Double, IdDetalleRemision As Double, h As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, StrSqlInsert As String, Sqlstring As String, ExisteRecibo2HMas As Boolean = False
        Dim Factor As Double, QQ As Double, Tara As Double, IdEstadoFisico As Double, IdCategoria As Double, IdCalidad As Double, IdTipoLugarAcopio As Double, IdLugarAcopio As Double




        iPosicion = Me.TDBGridDetalle.Row

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////VERIFICO EL TIEMPO DE RECIBIO EL CAFE /////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////
        Cadena = Me.TDBGridDetalle.Item(iPosicion)("IdDetalleReciboPergamino")
        CadenaDiv = Cadena.Split("-")
        max = UBound(CadenaDiv)

        h = 0
        ExisteRecibo2HMas = False


        For h = 0 To Max
            IdDetalleRecibo = CadenaDiv(h)
            'If IdDetalleRecibo = CadenaDiv(h) Then
            'IdDetalleRemision = Dataset.Tables("IdDetalleRemision").Rows(iPosicion)("IdDetalleRemisionPergamino")
            Sqlstring = "SELECT  Codigo, DATEDIFF(hh, Fecha, CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS HorasReal, IdReciboPergamino FROM ReciboCafePergamino WHERE (IdReciboPergamino = " & IdDetalleRecibo & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
            DataAdapter.Fill(Dataset, "Horas")

            If Dataset.Tables("Horas").Rows.Count <> 0 Then
                If Dataset.Tables("Horas").Rows(0)("HorasReal") > 2 Then
                    ExisteRecibo2HMas = True
                End If

            End If

            Dataset.Tables("Horas").Reset()



            'End If
        Next


        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////////SI YA TIENE PESADAS QUE NO ME ENVIE MENSAJE ////////////////////////////////////////////////////////
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (IdRemisionPergamino = " & IdRemision & ") AND (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy")), "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"



        If ExisteRecibo2HMas = False Then
            If MsgBox("No es necesario realizar la Pesada por tiempo Menor a 2 Horas, ¿Desea persarlos?", MsgBoxStyle.YesNo, "Sistema Bascula") = MsgBoxResult.No Then
                Me.TDBGridDetalle.Columns("PesoBruto").Text = Me.TDBGridDetalle.Columns("PesoBruto2").Text
                Me.TDBGridDetalle.Columns("Tara").Text = Me.TDBGridDetalle.Columns("Tara2").Text
                Me.TDBGridDetalle.Columns("PesoNeto").Text = Me.TDBGridDetalle.Columns("PesoNeto2").Text
                Me.TDBGridDetalle.Columns("CantidadSacos").Text = Me.TDBGridDetalle.Columns("CantidadSacos2").Text

                QQ = Me.TDBGridDetalle.Columns("CantidadSacos2").Text

                IdEstadoFisico = 0
                If Me.TDBGridDetalle.Columns("EstadoFisico").Text <> "" Then
                    '////////////////////////////////////////////BUSCO ID ESTADO FISICO /////////////////////////////////////
                    Sqlstring = "SELECT  IdEdoFisico, Codigo, Descripcion, HumedadInicial, HumedadFinal, HumedadXDefecto  FROM EstadoFisico WHERE (Descripcion = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                    DataAdapter.Fill(Dataset, "EstadoFisico")
                    If Dataset.Tables("EstadoFisico").Rows.Count <> 0 Then
                        IdEstadoFisico = Dataset.Tables("EstadoFisico").Rows(0)("IdEdoFisico")
                    End If
                End If


                IdCategoria = 0
                If Me.TDBGridDetalle.Columns("RangoImperfec").Text <> "" Then
                    Sqlstring = "SELECT IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion FROM RangoImperfeccion WHERE (Nombre = '" & Me.TDBGridDetalle.Columns("RangoImperfec").Text & "') ORDER BY IdRangoImperfeccion DESC"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                    DataAdapter.Fill(Dataset, "Rango")
                    If Dataset.Tables("Rango").Rows.Count <> 0 Then
                        IdCategoria = Dataset.Tables("Rango").Rows(0)("IdRangoImperfeccion")
                    End If
                End If

                IdCalidad = 0
                Sqlstring = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion FROM Calidad  WHERE  (NomCalidad = '" & Me.CboCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                DataAdapter.Fill(Dataset, "Consulta")
                If Dataset.Tables("Consulta").Rows.Count <> 0 Then
                    IdCalidad = Dataset.Tables("Consulta").Rows(0)("IdCalidad")
                End If

                IdLugarAcopio = Me.TxtIdLugarAcopio.Text
                IdTipoLugarAcopio = 0
                Sqlstring = "SELECT  * FROM LugarAcopio WHERE (IdLugarAcopio = " & IdLugarAcopio & ") AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                DataAdapter.Fill(Dataset, "Localidad")
                If Not Dataset.Tables("Localidad").Rows.Count = 0 Then
                    IdTipoLugarAcopio = Dataset.Tables("Localidad").Rows(0)("TipoLugarAcopio")
                End If


                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////CONSULTO LAS TARAS /////////////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////
                Sqlstring = "SELECT FactorTara FROM FactorSaco WHERE  (IdEdoFisico = " & IdEstadoFisico & " )  AND (IdTipoLugarAcopio = " & IdTipoLugarAcopio & ") AND (IdUMedida = 1) AND (IdCalidad = " & IdCalidad & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                DataAdapter.Fill(Dataset, "Tara")
                If Dataset.Tables("Tara").Rows.Count <> 0 Then
                    Factor = Dataset.Tables("Tara").Rows(0)("FactorTara")
                Else
                    Factor = 0
                End If

                Tara = Factor * QQ


                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////ACTUALIZO EL NIVEL DE DETALLE ////////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If Me.TxtNumeroRemision.Text = "" Or Me.TxtNumeroRemision.Text = "-----0-----" Then
                    sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & NumeroTemporal & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"

                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(Dataset, "Consulta")
                    If Dataset.Tables("Consulta").Rows.Count <> 0 Then

                        sql = "UPDATE Detalle_Pesadas  SET  [Codigo_Beams] = '" & Me.TDBGridDetalle.Columns("IdDetalleReciboPergamino").Text & "'  WHERE  (NumeroRemision = '" & NumeroTemporal & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(sql, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    End If
                Else
                    sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"

                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(Dataset, "Consulta")
                    If Dataset.Tables("Consulta").Rows.Count <> 0 Then

                        sql = "UPDATE Detalle_Pesadas  SET  [Codigo_Beams] = '" & Me.TDBGridDetalle.Columns("IdDetalleReciboPergamino").Text & "'  WHERE  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(sql, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    End If
                End If

                SumaGridAgrupados()

                'GrabaDetalleRemision(NumeroRemision, CodigoProducto, QQ, Linea, Descripcion, Me.CboCalidad.Text, Me.TDBGridDetalle.Columns("EstadoFisico").Text, Precio, Me.TDBGridDetalle.Columns("PesoNeto2").Text, CboTipoRemision.Text, Tara, PesoNetoKg, QQ, Me.CboCalidad.Text, FrmBascula.TipoPesada, Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy"))
                Exit Sub


            End If

        End If


        My.Forms.FrmBascula.TipoPesada = "DetalleRemision" & iPosicion
        My.Forms.FrmBascula.Calidad = Me.CboCalidad.Text
        My.Forms.FrmBascula.EstadoFisico = Me.TDBGridDetalle.Columns("EstadoFisico").Text
        My.Forms.FrmBascula.Categoria = Me.TDBGridDetalle.Columns("RangoImperfec").Text
        My.Forms.FrmBascula.DTPFecha.Text = Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy")
        My.Forms.FrmBascula.DTPRemFechCarga.Value = Me.DTPRemFechCarga.Value
        NumeroFactura = Me.TDBGridDetalle.Columns("Codigo").Text
        My.Forms.FrmBascula.Posicion = iPosicion

        TipoPesada = "DetalleRemision" & iPosicion

        My.Forms.FrmBascula.ShowDialog()
        SumaGridAgrupados()

        '////////////////////////////////RECORRO EL GRID DE RECIBOS PARA UBICAR LAS PESADAS ///////////////////////////
        Cont = Me.TDGridUseParc.RowCount
        i = 0
        Do While Cont > i
            Me.TDGridUseParc.Row = i
            If Me.TDGridUseParc.Columns("Codigo").Text = NumeroFactura Then
                'Me.TDGridUseParc.Columns("CantidadSacos").Text = FrmBascula.QQRemision
                'Me.TDGridUseParc.Columns("PesoBruto").Text = FrmBascula.SubTotalRemision
                'Me.TDGridUseParc.Columns("Tara").Text = FrmBascula.TaraRemision
                'Me.TDGridUseParc.Columns("PesoAplicado").Text = FrmBascula.TotalRemision

                PesoReal = CDbl(Me.TDGridUseParc.Columns("PesoReal").Text)
                PesoAplicado = CDbl(Me.TDGridUseParc.Columns("PesoAplicado").Text)
                PesoPorAplicar = PesoReal - PesoAplicado
                Me.TDGridUseParc.Columns("PesoPorAplicar").Text = Format(PesoPorAplicar, "##,##0.00")
                Exit Do
            End If

            i = i + 1
        Loop

        CalculoGridParcial()
        SumaGridParcial()

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////ACTUALIZO EL NIVEL DE DETALLE ////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Me.TxtNumeroRemision.Text = "" Or Me.TxtNumeroRemision.Text = "-----0-----" Then
            sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & NumeroTemporal & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(Dataset, "Consulta")
            If Dataset.Tables("Consulta").Rows.Count <> 0 Then

                sql = "UPDATE Detalle_Pesadas  SET  [Codigo_Beams] = '" & Me.TDBGridDetalle.Columns("IdDetalleReciboPergamino").Text & "'  WHERE  (NumeroRemision = '" & NumeroTemporal & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(sql, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
        Else
            sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"

            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(Dataset, "Consulta")
            If Dataset.Tables("Consulta").Rows.Count <> 0 Then

                sql = "UPDATE Detalle_Pesadas  SET  [Codigo_Beams] = '" & Me.TDBGridDetalle.Columns("IdDetalleReciboPergamino").Text & "'  WHERE  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (Calidad = '" & Me.CboCalidad.Text & "') AND (Estado = '" & Me.TDBGridDetalle.Columns("EstadoFisico").Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(sql, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
        End If



        '////////////////////CALCULO LA MERMA ////////////////////////////////////////////////
        Me.TDBGridMerma.Row = iPosicion
        Peso1 = Me.TDBGridDetalle.Columns("PesoNeto").Text
        Peso2 = Me.TDBGridDetalle.Columns("PesoNeto2").Text
        If Peso1 <> 0 Then
            If Peso2 <> 0 Then
                Me.TDBGridMerma.Columns("Merma").Text = Format(Peso1 - Peso2, "##,##0.00")
            End If
        End If

        Me.TDBGridDetalle.Row = iPosicion + 1
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.PanelGRidProveeedores.Visible = False
        Me.PanelGRidProveeedores.Width = 300
        Me.PanelGRidProveeedores.Height = 10
    End Sub

    Private Sub TxtProductores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProductores.Click
        Me.PanelGRidProveeedores.Visible = True
        Me.PanelGRidProveeedores.Width = 300
        Me.PanelGRidProveeedores.Height = 260
    End Sub


    Private Sub TDBGridProductoresMaquila_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TDBGridProductoresMaquila.MouseDown
        Dim row As Integer = Me.TDBGridProductoresMaquila.RowContaining(e.Y)
        If row <> -1 Then
            ' if the row is in the SelectedRows collection then remove it (deselect)
            ' if it isn't then add it (select)
            Dim index As Integer = Me.TDBGridProductoresMaquila.SelectedRows.IndexOf(row)
            If index <> -1 Then
                Me.TDBGridProductoresMaquila.SelectedRows.RemoveAt(index)
            Else
                Me.TDBGridProductoresMaquila.SelectedRows.Add(row)
            End If
        End If
    End Sub

    Private Sub ListCalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtProductores_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProductores.TextChanged

    End Sub

    Private Sub lbltipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltipo.Click

    End Sub

    Private Sub TxtIdRemision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIdRemision.TextChanged
        Dim SqlMerma As String

        QuienRemision = "FechaRemisiones"
        If Me.TxtIdRemision.Text = "" Then
            IdRemision = 0
        Else
            IdRemision = Me.TxtIdRemision.Text
        End If



        Me.CboTipoRemision.Enabled = False

        Dim Sql As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, DataSet1 As New DataSet, DataAdapter1 As New SqlClient.SqlDataAdapter, SumaRec As String
        Dim count As Integer, i As Integer = 0, Descripcion As String, item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item1 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim sql1 As String, SumPaseo As String, sqldet As String, CodLocalidad As String, codigo
        Dim IdEstadoRemision As String, filas As Integer = 0

        Try
            'Municipio.Nombre,   INNER JOIN    Municipio ON LiquidacionPergamino.IdMunicipio = Municipio.IdMunicipio
            'RECORDAR HACER EL CMBIO DE BUSCAR EL CODIGO POR QUE LO DEJO PARA 6 PERO QUE PASARIA SI FUESE MAS DE 6 DIGITOS. 

            '/////////////////////////////CREO UNA CONSULTA QUE NUNCA TENDRA REGISTROS //////////////////////////////////////////////////
            Sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, ReciboCafePergamino.Codigo As Merma FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.IdCalidad = '-55555')      "
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "ListaRecibosRem")



            'Sql = "SELECT  RemisionPergamino.Numero_Boleta, RemisionPergamino.ConfirmadoDetalle, RemisionPergamino.IdRemisionPergamino, RemisionPergamino.Serie, RemisionPergamino.Codigo AS Numero, RemisionPergamino.Fecha, EstadoDocumento.Descripcion AS Estado, TipoCafe.Nombre AS TipoRemision, Calidad.NomCalidad AS Calidad, LugarAcopio.NomLugarAcopio, EmpresaTransporte.NombreEmpresa, Vehiculo.Placa, Conductor.Nombre AS Conductor, RemisionPergamino.FechaCarga, RemisionPergamino.HoraSalida,RemisionPergamino.IdTipoCafe, TipoIngreso.Descripcion AS TipoIngreso, Conductor.Cedula, RemisionPergamino.IdEstadoDocumento, Cosecha.FechaInicial, Cosecha.FechaFinal,LugarAcopio_1.NomLugarAcopio AS Destino FROM RemisionPergamino INNER JOIN EstadoDocumento ON RemisionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN     TipoCafe ON RemisionPergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN    Calidad ON RemisionPergamino.IdCalidad = Calidad.IdCalidad INNER JOIN  LugarAcopio ON RemisionPergamino.IdLugarAcopio = LugarAcopio.IdLugarAcopio INNER JOIN   EmpresaTransporte ON RemisionPergamino.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  Vehiculo ON RemisionPergamino.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  Conductor ON RemisionPergamino.IdConductor = Conductor.IdConductor INNER JOIN  TipoIngreso ON RemisionPergamino.IdTipoIngreso = TipoIngreso.IdTipoIngreso INNER JOIN Cosecha ON RemisionPergamino.IdCosecha = Cosecha.IdCosecha INNER JOIN  LugarAcopio AS LugarAcopio_1 ON RemisionPergamino.IdDestino = LugarAcopio_1.IdLugarAcopio  WHERE  (RemisionPergamino.IdRemisionPergamino = '" & Me.TxtIdRemision.Text & "')  AND (RemisionPergamino.IdTipoCafe = " & IdTipoCafe & ")"
            Sql = "SELECT  RemisionPergamino.Numero_Boleta, RemisionPergamino.ConfirmadoDetalle, RemisionPergamino.IdRemisionPergamino, RemisionPergamino.Serie, RemisionPergamino.Codigo AS Numero, RemisionPergamino.Fecha, EstadoDocumento.Descripcion AS Estado, TipoCafe.Nombre AS TipoRemision, Calidad.NomCalidad AS Calidad, LugarAcopio.NomLugarAcopio, EmpresaTransporte.NombreEmpresa, Vehiculo.Placa, Conductor.Nombre AS Conductor, RemisionPergamino.FechaCarga, RemisionPergamino.HoraSalida, RemisionPergamino.IdTipoCafe, TipoIngreso.Descripcion AS TipoIngreso, Conductor.Cedula, RemisionPergamino.IdEstadoDocumento, Cosecha.FechaInicial, Cosecha.FechaFinal, LugarAcopio_1.NomLugarAcopio AS Destino, RemisionPergamino.IdRutaLogica, LugarAcopio_2.NomLugarAcopio AS NomLugarRuta, RemisionPergamino.FechaModificacion, RemisionPergamino.Observacion FROM  RemisionPergamino INNER JOIN EstadoDocumento ON RemisionPergamino.IdEstadoDocumento = EstadoDocumento.IdEstadoDocumento INNER JOIN  TipoCafe ON RemisionPergamino.IdTipoCafe = TipoCafe.IdTipoCafe INNER JOIN Calidad ON RemisionPergamino.IdCalidad = Calidad.IdCalidad INNER JOIN LugarAcopio ON RemisionPergamino.IdLugarAcopio = LugarAcopio.IdLugarAcopio INNER JOIN EmpresaTransporte ON RemisionPergamino.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  Vehiculo ON RemisionPergamino.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN Conductor ON RemisionPergamino.IdConductor = Conductor.IdConductor INNER JOIN TipoIngreso ON RemisionPergamino.IdTipoIngreso = TipoIngreso.IdTipoIngreso INNER JOIN Cosecha ON RemisionPergamino.IdCosecha = Cosecha.IdCosecha INNER JOIN LugarAcopio AS LugarAcopio_1 ON RemisionPergamino.IdDestino = LugarAcopio_1.IdLugarAcopio LEFT OUTER JOIN LugarAcopio AS LugarAcopio_2 ON RemisionPergamino.IdRutaLogica = LugarAcopio_2.IdLugarAcopio  " & _
                  "WHERE (RemisionPergamino.IdRemisionPergamino = '" & Me.TxtIdRemision.Text & "') AND (RemisionPergamino.IdTipoCafe = " & IdTipoCafe & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "LlamaRemision")

            If DataSet.Tables("LlamaRemision").Rows.Count = 0 Then
                Exit Sub
            End If

            IdEstadoRemision = DataSet.Tables("LlamaRemision").Rows(0)("IdEstadoDocumento")

            'If IdEstadoLlama = 294 Then
            '    Me.GroupBox6.Enabled = False
            '    Me.TDBGRidDistribucion.Enabled = False
            '    Me.TDGridDetalleRecibos.Enabled = False
            '    Me.BtnGuardar.Enabled = False

            'ElseIf IdEstadoLlama = 293 Then

            '    Me.DTPFecha.Enabled = False
            '    Me.CboLocalidadLiq.Enabled = False
            '    Me.CboCodigoProveedor.Enabled = False
            '    Me.CboTipIngreso.Enabled = False
            '    Me.CboTipoCompra.Enabled = False
            '    Me.IdTipoCompra = IdTipoCompra
            '    Me.CboCalidad.Enabled = False
            '    Me.CboTipDano.Enabled = False
            '    Me.CboEdofisico.Enabled = False
            '    Me.CboImperfeccion.Enabled = False
            '    Me.Button10.Enabled = False
            '    Me.txtnombre.Enabled = False
            '    Me.TxtCedula.Enabled = False
            '    Me.CboMunicipio.Enabled = False
            '    Me.CboMoneda.Enabled = False
            '    Me.CboMonedas.Enabled = True
            '    Me.TabControl1.Enabled = True
            '    Me.Button8.Enabled = False
            '    Me.Button14.Enabled = False
            '    Me.Button2.Enabled = False
            '    Me.TxtTasaCambio.Enabled = False
            '    Me.Button3.Enabled = True
            '    Me.Button9.Enabled = True
            '    Me.Button6.Enabled = False
            '    Me.TDBGRidDistribucion.Enabled = True
            '    Me.TDGridDetalleRecibos.Enabled = True

            'End If


            If Not DataSet.Tables("LlamaRemision").Rows.Count = 0 Then

                PegarRemision = True

                'IdRemision = DataSet.Tables("LlamaRemision").Rows(0)("IdRemisionPergamino")

                '--------------------------------------------------------------------------------------------------------
                'LLENO EL PRIMER GRUPO
                '-------------------------------------------------------------------------------------------------------

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Observacion")) Then
                    Me.Observaciones = DataSet.Tables("LlamaRemision").Rows(0)("Observacion")
                End If



                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("ConfirmadoDetalle")) Then
                    ConfirmadoDetalle = DataSet.Tables("LlamaRemision").Rows(0)("ConfirmadoDetalle")
                Else
                    ConfirmadoDetalle = False
                End If



                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Numero_Boleta")) Then
                    ValidaBoleta = False
                    Me.TxtNumeroBoleta.Text = DataSet.Tables("LlamaRemision").Rows(0)("Numero_Boleta")
                    ValidaBoleta = True
                Else
                    ValidaBoleta = False
                    Me.TxtNumeroBoleta.Text = ""
                    ValidaBoleta = True
                End If


                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("NomLugarRuta")) Then
                    Me.CboLocDest.Text = DataSet.Tables("LlamaRemision").Rows(0)("NomLugarRuta")
                    IdRutaLogica = DataSet.Tables("LlamaRemision").Rows(0)("IdRutaLogica")
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Calidad")) Then
                    Me.CboCalidad.Text = DataSet.Tables("LlamaRemision").Rows(0)("Calidad")
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("TipoRemision")) Then
                    Me.CboTipoRemision.Text = DataSet.Tables("LlamaRemision").Rows(0)("TipoRemision")
                Else
                    Me.CboTipoRemision.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("NomLugarAcopio")) Then
                    Me.LblSucursal.Text = DataSet.Tables("LlamaRemision").Rows(0)("NomLugarAcopio")
                Else
                    Me.LblSucursal.Text = ""
                End If

                If IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Fechainicial")) Or IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("FechaFinal")) Then
                    Me.LblCosecha.Text = ""
                Else
                    Me.LblCosecha.Text = "Cosecha: " & DataSet.Tables("LlamaRemision").Rows(0)("Fechainicial") & "-" & (DataSet.Tables("LlamaRemision").Rows(0)("FechaFinal"))
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Serie")) Then
                    Me.TxtSerie.Text = DataSet.Tables("LlamaRemision").Rows(0)("Serie")
                Else
                    Me.TxtSerie.Text = "?"
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Numero")) Then
                    Me.TxtNumeroRemision.Text = DataSet.Tables("LlamaRemision").Rows(0)("Numero")
                    Me.NumeroTemporal = Me.TxtNumeroRemision.Text

                Else
                    Me.TxtNumeroRemision.Text = "---0---"
                End If
                '--------------------------------------------------------------------------------------------------------
                'LLENO EL GRUPO DATOS DE DOCUMENTO
                '-------------------------------------------------------------------------------------------------------

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Fecha")) Then
                    Me.LblFecha.Text = Format(DataSet.Tables("LlamaRemision").Rows(0)("Fecha"), "dd/MM/yyyy")
                Else
                    Me.LblFecha.Text = "? " & Format(Now, "dd/MM/yyyy")
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Fecha")) Then
                    Me.Timer1.Stop()
                    'Me.LblHora.Text = Format(DataSet.Tables("LlamaRemision").Rows(0)("Fecha"), "HH:mm:ss")
                    Me.LblHora.Text = Format(DataSet.Tables("LlamaRemision").Rows(0)("FechaModificacion"), "HH:mm:ss")

                Else
                    Me.LblHora.Text = "? " & Format(Now, "HH:mm:ss")
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("TipoIngreso")) Then
                    Me.CboRemTipIngr.Text = DataSet.Tables("LlamaRemision").Rows(0)("TipoIngreso")
                Else
                    Me.CboRemTipIngr.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Estado")) Then
                    Me.CboEstadoDoc.Text = DataSet.Tables("LlamaRemision").Rows(0)("Estado")
                Else
                    Me.CboEstadoDoc.Text = ""
                End If

                '--------------------------------------------------------------------------------------------------------
                'LLENO EL GRUPO DATOS DE CONDUCTOR
                '-------------------------------------------------------------------------------------------------------
                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("NombreEmpresa")) Then
                    Me.CboEmpresaTrans.Text = DataSet.Tables("LlamaRemision").Rows(0)("NombreEmpresa")
                Else
                    Me.CboEmpresaTrans.Text = ""
                End If


                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Placa")) Then
                    Me.CboEmprsPlaca.Text = DataSet.Tables("LlamaRemision").Rows(0)("Placa")
                Else
                    Me.CboEmprsPlaca.Text = ""
                End If

                'If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Marca")) Then
                '    Me.TxtMarca.Text = DataSet.Tables("LlamaRemision").Rows(0)("Marca")
                'Else
                '    Me.TxtMarca.Text = ""
                'End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Conductor")) Then
                    Me.CboEmpresaCond.Text = DataSet.Tables("LlamaRemision").Rows(0)("Conductor")
                Else
                    Me.CboEmpresaCond.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Cedula")) Then
                    Me.TxtCedula.Text = DataSet.Tables("LlamaRemision").Rows(0)("Cedula")
                Else
                    Me.TxtCedula.Text = ""
                End If
                '--------------------------------------------------------------------------------------------------------
                'LLENO EL GRUPO DATOS DE CONDUCTOR
                '-------------------------------------------------------------------------------------------------------

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("FechaCarga")) Then
                    Me.DTPRemFechCarga.Text = DataSet.Tables("LlamaRemision").Rows(0)("FechaCarga")
                Else
                    Me.DTPRemFechCarga.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("HoraSalida")) Then
                    Me.DTPRemFechSalid.Text = DataSet.Tables("LlamaRemision").Rows(0)("HoraSalida")
                Else
                    Me.DTPRemFechSalid.Text = ""
                End If

                If Not IsDBNull(DataSet.Tables("LlamaRemision").Rows(0)("Destino")) Then
                    Me.CboRemLocDest.Text = DataSet.Tables("LlamaRemision").Rows(0)("Destino")
                Else
                    Me.CboRemLocDest.Text = ""
                End If

                '----------------------------------------------------------------------------------------------------------------------------
                '---------------------------BLOQUEO LOS BOTONES DE OPCIONES QUE NO PUEDEN MODIFICAR ------------------------------------------
                '-----------------------------------------------------------------------------------------------------------------------------
                If Me.CboEstadoDoc.Text = "Editable" Then
                    Me.BtnGuardarRem.Enabled = True
                    Me.Button13.Enabled = True
                    Me.Button14.Enabled = True
                    Me.BtnBorrarRem.Enabled = False
                    Me.Button7.Enabled = False
                    Me.Button8.Enabled = False
                    Me.CmdPesada.Enabled = True
                    Me.BtnFiltrar.Enabled = True
                    Me.TDGridUseParc.Enabled = False
                    Me.BtnImprimir.Enabled = False

                    Me.GroupBox2.Enabled = True    'Modificado 21-11-2019  caso 17 doc test 
                    Me.GroupBox3.Enabled = True     'Modificado 21-11-2019  caso 17  doc test 
                    Me.GroupBox4.Enabled = True     'Modificado 21-11-2019 caso 17 doc test
                    Me.CboCalidad.Enabled = True
                    Me.CboRecInicial.Enabled = True
                    Me.CboRecFinal.Enabled = True
                    Me.CboLocDest.Enabled = True
                    Me.BtnFiltrar.Enabled = True

                    Me.Button2.Enabled = False    'Modificado 21-11-2019  Caso18 doc test
                    Me.Button3.Enabled = False    'Modificado 21-11-2019  Caso18 doc test
                    Me.Button4.Enabled = False

                ElseIf Me.CboEstadoDoc.Text = "Confirmado" Then
                    Me.BtnImprimir.Enabled = True
                    Me.BtnGuardarRem.Enabled = False
                    Me.Button13.Enabled = False
                    Me.Button14.Enabled = False
                    Me.BtnBorrarRem.Enabled = False
                    Me.Button7.Enabled = False
                    Me.Button8.Enabled = False
                    Me.CmdPesada.Enabled = False
                    Me.BtnFiltrar.Enabled = False
                    Me.TDGridUseParc.Enabled = False

                    Me.GroupBox2.Enabled = False
                    Me.GroupBox3.Enabled = False
                    Me.GroupBox4.Enabled = False
                    Me.CboCalidad.Enabled = False
                    Me.CboRecInicial.Enabled = False
                    Me.CboRecFinal.Enabled = False
                    Me.CboLocDest.Enabled = False
                    Me.BtnFiltrar.Enabled = False

                    Me.Button2.Enabled = True   'Modificado 21-11-2019  Caso18 doc test
                    Me.Button3.Enabled = True   'Modificado 21-11-2019  Caso18 doc test
                    Me.Button4.Enabled = True   'Modificado 21-11-2019  caso18 doc test

                ElseIf Me.CboEstadoDoc.Text = "Anulado" Then

                    Me.CmdPesada.Enabled = False
                    Me.CmdConfirma.Enabled = False
                    Me.BtnImprimir.Enabled = False
                    Me.BtnGuardarRem.Enabled = False
                    Me.Button13.Enabled = False
                    Me.Button14.Enabled = False
                    Me.BtnBorrarRem.Enabled = False
                    Me.Button7.Enabled = False
                    Me.Button8.Enabled = False
                    Me.CmdPesada.Enabled = False
                    Me.BtnFiltrar.Enabled = False
                    Me.TDGridUseParc.Enabled = False

                    Me.GroupBox2.Enabled = False
                    Me.GroupBox3.Enabled = False
                    Me.GroupBox4.Enabled = False
                    Me.CboCalidad.Enabled = False
                    Me.CboRecInicial.Enabled = False
                    Me.CboRecFinal.Enabled = False
                    Me.CboLocDest.Enabled = False
                    Me.BtnFiltrar.Enabled = False

                    Me.Button2.Enabled = False    'Modificado 21-11-2019  Caso18 doc test
                    Me.Button3.Enabled = False   'Modificado 21-11-2019  Caso18 doc test
                    Me.Button4.Enabled = False
                    Me.Button5.Enabled = False
                    Me.CmdConfirma.Enabled = False
                    Me.CmdPesada.Enabled = False


                    'Modificado 21-11-2019  caso18 doc test

                End If

                If Me.CboEstadoDoc.Text <> "Anulado" Then
                    If ConfirmadoDetalle = True Then
                        '////////////////////////SI ESTA CONFIRMADO ES PERMITIDO IMPRIMIR ////////////////////////////
                        If Me.CboEstadoDoc.Text = "Confirmado" Then
                            Me.CmdConfirma.Enabled = False
                            Me.CmdPesada.Enabled = False
                            Me.BtnFiltrar.Enabled = False
                            Me.BtnImprimir.Enabled = True
                        Else
                            Me.CmdConfirma.Enabled = False
                            Me.CmdPesada.Enabled = False
                            Me.BtnFiltrar.Enabled = False
                            Me.BtnImprimir.Enabled = False
                        End If
                    Else
                        Me.CmdConfirma.Enabled = True
                        Me.CmdPesada.Enabled = True
                        Me.BtnFiltrar.Enabled = True
                        Me.BtnImprimir.Enabled = False
                    End If
                End If
                '----------------------------------------------------------------------------------------------------------
                '---------LLENO EL GRID DEL LISTADO DE RECIBOS QUE ESTA OCULTO 
                '--------------------------------------------------------------------------------------------------------------
                'Sql = "SELECT  CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.IdTipoSaco, DetalleReciboCafePergamino.IdEdoFisico, Dano.IdDano, Dano.Nombre AS Dano, DetalleReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino, RangoImperfeccion.Nombre AS Categoria, RangoImperfeccion.IdRangoImperfeccion, DetalleRemisionPergamino.IdDetalleRemisionPergamino, DetalleRemisionPergamino.IdRemisionPergamino, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual FROM DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN  ReciboCafePergamino INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion ON RecibosRemisionPergamino.IdDetalleReciboPergamino = ReciboCafePergamino.IdReciboPergamino LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca LEFT OUTER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor  " & _
                '      "WHERE(DetalleRemisionPergamino.IdRemisionPergamino = " & IdRemision & ") ORDER BY RecibosRemisionPergamino.Orden"

                Sql = "SELECT  CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.IdTipoSaco, DetalleReciboCafePergamino.IdEdoFisico, Dano.IdDano, Dano.Nombre AS Dano, DetalleReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino, RangoImperfeccion.Nombre AS Categoria, RangoImperfeccion.IdRangoImperfeccion, DetalleRemisionPergamino.IdDetalleRemisionPergamino, DetalleRemisionPergamino.IdRemisionPergamino, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual FROM DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN ReciboCafePergamino INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca LEFT OUTER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor " & _
                      "WHERE(DetalleRemisionPergamino.IdRemisionPergamino = " & IdRemision & ") ORDER BY RecibosRemisionPergamino.Orden"

                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "ListaRecibos2")
                ''----------------------LLENO EL GRID DE LISTA RECIBOS--------------------------------------------------------------------------------------------------
                Me.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos2")
                Me.DataSetRecibos.Reset()
                Me.DataSetRecibos.Tables.Add(DataSet.Tables("ListaRecibos2").Copy)


                '--------------------------------------------------------------------------------------------------------
                'LLENO EL GRIND DE USO PARCIALES.
                '--------------------------------------------------------------------------------------------------------

                'Sql = "SELECT ReciboCafePergamino.AplicarRemision AS Aplicar, CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, Dano.Nombre AS Dano, RangoImperfeccion.Nombre AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal, RecibosRemisionPergamino.PesoNeto AS PesoAplicado, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara - RecibosRemisionPergamino.PesoNeto AS PesoPorAplicar, RemisionPergamino.IdRemisionPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino As IdDetalleReciboPergamino2, ReciboCafePergamino.IdReciboPergamino as IdDetalleReciboPergamino, ReciboCafePergamino.IdReciboPergamino Dano INNER JOIN DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico ON Dano.IdDano = ReciboCafePergamino.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino LEFT OUTER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca " & _
                '      "WHERE (RemisionPergamino.IdRemisionPergamino = '" & IdRemision & "') ORDER BY RecibosRemisionPergamino.Orden"

                Sql = "SELECT   ReciboCafePergamino.AplicarRemision AS Aplicar, CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, Dano.Nombre AS Dano, RangoImperfeccion.Nombre AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal, RecibosRemisionPergamino.PesoNeto AS PesoAplicado, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara - RecibosRemisionPergamino.PesoNeto AS PesoPorAplicar, RemisionPergamino.IdRemisionPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino AS IdDetalleReciboPergamino2, ReciboCafePergamino.IdReciboPergamino AS IdDetalleReciboPergamino, ReciboCafePergamino.IdReciboPergamino FROM Dano INNER JOIN DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico ON Dano.IdDano = ReciboCafePergamino.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN DetalleRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON  DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino LEFT OUTER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca  " & _
                       "WHERE (RemisionPergamino.IdRemisionPergamino = '" & IdRemision & "') ORDER BY RecibosRemisionPergamino.Orden"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "DetallesDeRemisiones")
                'Me.TDGridUseParc.DataSource = DataSet.Tables("DetallesDeRemisiones")


                ''--------------LLENO EL GRID DE DETALLES DE REMISION PERGAMINO-----------------------------------------------------
                Me.BinReciboParcial.DataSource = DataSet.Tables("DetallesDeRemisiones")
                Me.TDGridUseParc.DataSource = Me.BinReciboParcial.DataSource
                SumaGridAgrupados()

                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Aplicar").Width = 30
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Proveedor").Width = 180
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("NomFinca").Width = 140
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Codigo").Width = 100
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Descripcion").Width = 65
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Dano").Width = 65
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("Categoria").Width = 50
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("PesoReal").Width = 100

                Me.TDGridUseParc.Columns("Aplicar").Caption = " "
                Me.TDGridUseParc.Columns("Proveedor").Caption = "Nombre Productor"
                Me.TDGridUseParc.Columns("NomFinca").Caption = "Nombre Finca"
                Me.TDGridUseParc.Columns("Codigo").Caption = "Recibo No"
                Me.TDGridUseParc.Columns("Descripcion").Caption = "Edo Fisico"
                Me.TDGridUseParc.Columns("Dano").Caption = "Daño"
                Me.TDGridUseParc.Columns("Categoria").Caption = "Categoria"
                Me.TDGridUseParc.Columns("PesoReal").Caption = "Peso Real"
                Me.TDGridUseParc.Columns("PesoAplicado").Caption = "Peso Aplicado"
                Me.TDGridUseParc.Columns("PesoPorAplicar").Caption = "Peso Por Aplicar"
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("IdRemisionPergamino").Visible = False
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino2").Visible = False
                Me.TDGridUseParc.Splits.Item(0).DisplayColumns("IdReciboPergamino").Visible = False
                Me.TDGridUseParc.Columns("PesoReal").NumberFormat = "##,##0.00"
                Me.TDGridUseParc.Columns("PesoAplicado").NumberFormat = "##,##0.00"
                Me.TDGridUseParc.Columns("PesoPorAplicar").NumberFormat = "##,##0.00"

                Me.TDGridUseParc.Columns("Aplicar").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
                Me.TDGridUseParc.Columns("Aplicar").ValueItems.CycleOnClick = True
                With Me.TDGridUseParc.Columns("Aplicar").ValueItems.Values

                    item.Value = "False"
                    item.DisplayValue = Me.ImageList.Images(1)
                    .Add(item)

                    item = New C1.Win.C1TrueDBGrid.ValueItem()
                    item.Value = "True"
                    item.DisplayValue = Me.ImageList.Images(0)
                    .Add(item)

                    Me.TDGridUseParc.Columns("Aplicar").ValueItems.Translate = True
                End With

                CalculoGridParcial()
                SumaGridParcial()

                '--------------------------------------------------------------------------------------------------------
                'LLENO EL GRIND LIST RECIBOS
                '--------------------------------------------------------------------------------------------------------


                '--------------------------------------------------------------------------------------------------------
                'LLENO EL GRIND AGRUPACION.
                '--------------------------------------------------------------------------------------------------------

                '------------------------SI ES REMISION MAQUILA--------------------------------------------
                'If My.Forms.FrmRemision2.IdTipoCafe = 2 Then
                '    oDatarow = DataSet.Tables("ListaRecibosAgrupados").NewRow
                '    oDatarow("Productor") = Me.GribListRecibos.Item(i)("Proveedor")
                '    oDatarow("NomFinca") = Me.GribListRecibos.Item(i)("NomFinca")
                '    oDatarow("Codigo") = Me.GribListRecibos.Item(i)("Codigo")
                '    oDatarow("Dano") = Me.GribListRecibos.Item(i)("Dano")
                '    oDatarow("EstadoFisico") = Me.GribListRecibos.Item(i)("Descripcion")
                '    oDatarow("TipoSaco") = Me.GribListRecibos.Item(i)("Tiposaco")
                '    oDatarow("CantidadSacos") = 0 'Me.GribListRecibos.Item(i)("CantidadSacos")
                '    oDatarow("PesoBruto") = 0 'Me.GribListRecibos.Item(i)("PesoBruto")
                '    oDatarow("Tara") = 0 'Me.GribListRecibos.Item(i)("Tara")
                '    oDatarow("PesoNeto") = 0 'Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                '    oDatarow("Humedad") = Me.GribListRecibos.Item(i)("Humedad")
                '    oDatarow("RangoImperfec") = Me.GribListRecibos.Item(i)("RangoImperfec")
                '    oDatarow("IdCosecha") = Me.GribListRecibos.Item(i)("IdCosecha")
                '    oDatarow("IdTipoSaco") = Me.GribListRecibos.Item(i)("IdTipoSaco")
                '    oDatarow("IdEdoFisico") = Me.GribListRecibos.Item(i)("IdEdoFisico")
                '    oDatarow("IdDano") = Me.GribListRecibos.Item(i)("IdDano")
                '    oDatarow("TipoLocalidad") = Me.GribListRecibos.Item(i)("TipoLocalidad")
                '    oDatarow("IdDetalleReciboPergamino") = Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino")
                '    oDatarow("PesoNeto2") = Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")

                '    DataSet.Tables("ListaRecibosAgrupados").Rows.Add(oDatarow)

                '    '------------------------SI ES REMISION PERGAMINO--------------------------------------------
                'ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then
                '    Criterios = "Dano= '" & Dano & "' And EstadoFisico= '" & EdoFisico & "' And Tiposaco= '" & TipoSaco & "' And RangoImperfec= '" & RangoImperf & "' And TipoLocalidad= '" & TipoLugarAco & "' And IdCosecha= '" & Cosecha & "'"
                '    Buscar_Fila = DataSet.Tables("ListaRecibosAgrupados").Select(Criterios)
                '    If Buscar_Fila.Length > 0 Then
                '        Posicion = DataSet.Tables("ListaRecibosAgrupados").Rows.IndexOf(Buscar_Fila(0))
                '        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos") = 0 'Me.GribListRecibos.Item(i)("CantidadSacos") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos")
                '        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoBruto") = 0 'Me.GribListRecibos.Item(i)("PesoBruto") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoBruto")
                '        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Tara") = 0 'Me.GribListRecibos.Item(i)("Tara") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Tara")
                '        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto") = 0 '(Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")) + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto")
                '        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("IdDetalleReciboPergamino") = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("IdDetalleReciboPergamino") & "-" & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino")
                '        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Codigo") = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Codigo") & "," & Me.GribListRecibos.Item(i)("Codigo")
                '        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto2") = (Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")) + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto2")
                '    Else
                '        oDatarow = DataSet.Tables("ListaRecibosAgrupados").NewRow
                '        oDatarow("Dano") = Me.GribListRecibos.Item(i)("Dano")
                '        oDatarow("EstadoFisico") = Me.GribListRecibos.Item(i)("Descripcion")
                '        oDatarow("TipoSaco") = Me.GribListRecibos.Item(i)("Tiposaco")
                '        oDatarow("CantidadSacos") = 0 'Me.GribListRecibos.Item(i)("CantidadSacos")
                '        oDatarow("PesoBruto") = 0 'Me.GribListRecibos.Item(i)("PesoBruto")
                '        oDatarow("Tara") = 0 'Me.GribListRecibos.Item(i)("Tara")
                '        oDatarow("PesoNeto") = 0 'Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                '        oDatarow("Humedad") = Me.GribListRecibos.Item(i)("Humedad")
                '        oDatarow("RangoImperfec") = Me.GribListRecibos.Item(i)("RangoImperfec")
                '        oDatarow("IdCosecha") = Me.GribListRecibos.Item(i)("IdCosecha")
                '        oDatarow("IdTipoSaco") = Me.GribListRecibos.Item(i)("IdTipoSaco")
                '        oDatarow("IdEdoFisico") = Me.GribListRecibos.Item(i)("IdEdoFisico")
                '        oDatarow("IdDano") = Me.GribListRecibos.Item(i)("IdDano")
                '        oDatarow("TipoLocalidad") = Me.GribListRecibos.Item(i)("TipoLocalidad")
                '        oDatarow("Codigo") = Me.GribListRecibos.Item(i)("Codigo")
                '        oDatarow("IdDetalleReciboPergamino") = Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino")
                '        oDatarow("PesoNeto2") = Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                '        DataSet.Tables("ListaRecibosAgrupados").Rows.Add(oDatarow)
                '    End If
                'End If





                If IdTipoCafe = 2 Then
                    Me.LblProductor.Visible = True
                    Me.TxtProductores.Visible = True
                    Me.PanelPergaminio.Visible = False
                    Me.PanelMaquila.Visible = True
                    'Sql = "SELECT  CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Productor, Finca.NomFinca, ReciboCafePergamino.Codigo, Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, DetalleReciboCafePergamino.Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.CantidadSacos2, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2 FROM Finca RIGHT OUTER JOIN DetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN ReciboCafePergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad ON RecibosRemisionPergamino.IdDetalleReciboPergamino = ReciboCafePergamino.IdReciboPergamino LEFT OUTER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor ON Finca.IdFinca = ReciboCafePergamino.IdFinca  " & _
                    '      "WHERE  (RemisionPergamino.IdRemisionPergamino = '" & IdRemision & "') ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino"

                    Sql = "SELECT  CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Productor, Finca.NomFinca, ReciboCafePergamino.Codigo, Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, DetalleReciboCafePergamino.Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.CantidadSacos2,  CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2 FROM Finca RIGHT OUTER JOIN DetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN ReciboCafePergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad ON  RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino LEFT OUTER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor ON Finca.IdFinca = ReciboCafePergamino.IdFinca " & _
                          "WHERE (RemisionPergamino.IdRemisionPergamino = '" & IdRemision & "') ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                    DataAdapter.Fill(DataSet, "AgrupacionesRemisiones")
                    Me.TDBGridDetalle.DataSource = DataSet.Tables("AgrupacionesRemisiones")

                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(12).Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(13).Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(14).Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(15).Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(16).Visible = False

                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 145
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 72
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Width = 91
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Dano").Width = 71
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Width = 95
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Width = 60
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos").Width = 62
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto").Width = 77
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Width = 65
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto").Width = 76
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Humedad").Width = 82
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("RangoImperfec").Width = 50



                    Me.TDBGridDetalle.Columns(0).Caption = ""
                    Me.TDBGridDetalle.Columns(1).Caption = ""
                    Me.TDBGridDetalle.Columns(2).Caption = ""
                    Me.TDBGridDetalle.Columns(3).Caption = ""
                    Me.TDBGridDetalle.Columns(4).Caption = ""
                    Me.TDBGridDetalle.Columns(5).Caption = ""
                    Me.TDBGridDetalle.Columns(6).Caption = ""
                    Me.TDBGridDetalle.Columns(7).Caption = ""
                    Me.TDBGridDetalle.Columns(8).Caption = ""
                    Me.TDBGridDetalle.Columns(9).Caption = ""
                    Me.TDBGridDetalle.Columns(10).Caption = ""
                    Me.TDBGridDetalle.Columns(11).Caption = ""



                    Me.TDBGridDetalle.Columns(7).NumberFormat = "##,##0.00"
                    Me.TDBGridDetalle.Columns(8).NumberFormat = "##,##0.00"
                    Me.TDBGridDetalle.Columns(9).NumberFormat = "##,##0.00"
                    Me.TDBGridDetalle.Columns(10).NumberFormat = "##,##0.00"

                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Locked = True
                    'My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Visible = False
                    'My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
                    'My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto2").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Visible = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdRemisionPergamino").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto2").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos2").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Merma").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto2").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Tara2").Visible = False
                    ''--------------ACOMODO EL GRID DE DETALLES DE REMISION PREGAMINO --------------------------------------------------------------

                ElseIf IdTipoCafe = 1 Then
                    Me.LblProductor.Visible = False
                    Me.TxtProductores.Visible = False
                    Me.PanelPergaminio.Visible = True
                    Me.PanelMaquila.Visible = False
                    Me.PanelGRidProveeedores.Visible = False

                    'Sql = "SELECT  Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, MAX(DetalleReciboCafePergamino.Humedad) AS Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.CantidadSacos2, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2 FROM ReciboCafePergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN DetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino ON  ReciboCafePergamino.IdReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino GROUP BY Dano.Nombre, EstadoFisico.Descripcion, TipoSaco.Descripcion, RangoImperfeccion.Nombre, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.IdDetalleRemisionPergamino, DetalleRemisionPergamino.CantidadSacos2, DetalleRemisionPergamino.Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2 " & _
                    '"HAVING (RemisionPergamino.IdRemisionPergamino = '" & IdRemision & "') ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino"

                    Sql = "SELECT Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, MAX(DetalleReciboCafePergamino.Humedad) AS Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.CantidadSacos2, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2 FROM ReciboCafePergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN DetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino ON  DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino  GROUP BY Dano.Nombre, EstadoFisico.Descripcion, TipoSaco.Descripcion, RangoImperfeccion.Nombre, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.IdDetalleRemisionPergamino, DetalleRemisionPergamino.CantidadSacos2, DetalleRemisionPergamino.Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2  " & _
                          "HAVING (RemisionPergamino.IdRemisionPergamino = '" & IdRemision & "') ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                    DataAdapter.Fill(DataSet, "AgrupacionesRemisiones")
                    Me.TDBGridDetalle.DataSource = DataSet.Tables("AgrupacionesRemisiones")

                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdTipoSaco").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDano").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdEdoFisico").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdCosecha").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("TipoLocalidad").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdRemisionPergamino").Visible = False


                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 85
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 127
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 101
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Width = 99
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Width = 120
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Width = 86
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Width = 127
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Width = 109
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Width = 93

                    Me.TDBGridDetalle.Columns(0).Caption = ""
                    Me.TDBGridDetalle.Columns(1).Caption = ""
                    Me.TDBGridDetalle.Columns(2).Caption = ""
                    Me.TDBGridDetalle.Columns(3).Caption = ""
                    Me.TDBGridDetalle.Columns(4).Caption = ""
                    Me.TDBGridDetalle.Columns(5).Caption = ""
                    Me.TDBGridDetalle.Columns(6).Caption = ""
                    Me.TDBGridDetalle.Columns(7).Caption = ""
                    Me.TDBGridDetalle.Columns(8).Caption = ""

                    Me.TDBGridDetalle.Columns(4).NumberFormat = "##,##0.00"
                    Me.TDBGridDetalle.Columns(5).NumberFormat = "##,##0.00"
                    Me.TDBGridDetalle.Columns(6).NumberFormat = "##,##0.00"
                    Me.TDBGridDetalle.Columns(7).NumberFormat = "##,##0.00"

                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Locked = True
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Locked = True

                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto2").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos2").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Merma").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto2").Visible = False
                    Me.TDBGridDetalle.Splits.Item(0).DisplayColumns("Tara2").Visible = False

                End If


                Dim Cont As Double, ODataRowDetalle As DataRow


                If Me.IdTipoCafe = 2 Then
                    '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA MERMA /////////////////////////////
                    Cont = Me.TDBGridDetalle.RowCount
                    i = 0
                    Do While Cont > i
                        'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                        ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                        ODataRowDetalle("NumeroRecibo") = Me.TDBGridDetalle.Item(i)("Codigo") ' Me.TDBGridDetalle.Columns("Codigo").Text
                        ODataRowDetalle("Merma") = Format(Me.TDBGridDetalle.Item(i)("Merma"), "##,##0.00")
                        DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)
                        i = i + 1
                    Loop

                Else
                    '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA MERMA /////////////////////////////
                    Cont = Me.TDBGridDetalle.RowCount
                    i = 0
                    Do While Cont > i
                        'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                        ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                        ODataRowDetalle("NumeroRecibo") = "Grupo " & i
                        ODataRowDetalle("Merma") = Format(Me.TDBGridDetalle.Item(i)("Merma"), "##,##0.00")
                        DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)
                        i = i + 1
                    Loop
                End If


                Me.TDBGridMerma.DataSource = DataSet.Tables("ListaRecibosRem")

                '_________________________________________________________________________________________
                '____________________________CALCULA TOTAL GRID DETALLE __________________________________
                '_________________________________________________________________________________________
                SumaGridAgrupados()
                ComboRecibos()




                Sql = "SELECT  Intermedio.Fecha, Intermedio.FechaCarga, Intermedio.FechaSalida, Intermedio.IdOrigen, LugarAcopio.NomLugarAcopio as NomLugarAcopioOrigen, Intermedio.CantidadSacosOrigen,  Intermedio.PesoBrutoOrigen, Intermedio.PesoBrutoOrigen As PesoEntrada, Intermedio.IdEmpresaTransporte, EmpresaTransporte.NombreEmpresa, Intermedio.IdVehiculo, Vehiculo.Placa, Intermedio.IdConductor, Conductor.Nombre, Intermedio.IdDestino, LugarAcopio_1.NomLugarAcopio AS destino, Intermedio.CantidadSacosDestino, Intermedio.PesoBrutoDestino, Intermedio.ConfirmadoIntermedio, Intermedio.NumeroBoleta, Intermedio.IdIntermedio, Intermedio.PesoBrutoEntrada  FROM   Intermedio INNER JOIN  EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  RemisionPergamino ON Intermedio.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN   LugarAcopio ON Intermedio.IdDestino = LugarAcopio.IdLugarAcopio INNER JOIN  Vehiculo ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN  LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN   Conductor ON Intermedio.IdConductor = Conductor.IdConductor WHERE  (RemisionPergamino.IdRemisionPergamino ='" & IdRemision & "')AND (Cancelada = '0') ORDER BY Intermedio.Orden"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "PuntosIntermedios")
                Me.BinPuntosInterMe.DataSource = DataSet.Tables("PuntosIntermedios")
                Me.TDBGridPuntosInter.DataSource = Me.BinPuntosInterMe.DataSource

                'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns(0).Visible = False
                Me.TDBGridPuntosInter.Columns("Fecha").Caption = "Fecha Entrada"
                Me.TDBGridPuntosInter.Columns("Fecha").NumberFormat = "dd/MM/yyyy HH:mm:ss"
                Me.TDBGridPuntosInter.Columns("FechaCarga").Caption = "Fecha Carga"
                Me.TDBGridPuntosInter.Columns("FechaCarga").NumberFormat = "dd/MM/yyyy HH:mm:ss"
                Me.TDBGridPuntosInter.Columns("FechaSalida").Caption = "Fecha Salida"
                Me.TDBGridPuntosInter.Columns("FechaSalida").NumberFormat = "dd/MM/yyyy HH:mm:ss"
                Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdOrigen").Visible = False
                Me.TDBGridPuntosInter.Columns("NomLugarAcopioOrigen").Caption = "Origen"
                Me.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Caption = "Cantidad"
                Me.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Caption = "Peso Bruto"
                Me.TDBGridPuntosInter.Columns("PesoEntrada").Caption = "Peso Entrada"
                Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdEmpresaTransporte").Visible = False
                Me.TDBGridPuntosInter.Columns("NombreEmpresa").Caption = "Nombre Empresa"
                Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdVehiculo").Visible = False
                Me.TDBGridPuntosInter.Columns("Placa").Caption = "Placa"
                Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdConductor").Visible = False
                Me.TDBGridPuntosInter.Columns("Nombre").Caption = "Conductor"
                Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdDestino").Visible = False
                Me.TDBGridPuntosInter.Columns("destino").Caption = "Destino"
                Me.TDBGridPuntosInter.Columns("CantidadSacosDestino").Caption = "Cantidad"
                Me.TDBGridPuntosInter.Columns("PesoBrutoDestino").NumberFormat = "##,##0.0000"
                Me.TDBGridPuntosInter.Columns("PesoBrutoDestino").Caption = "Peso Bruto"
                Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("ConfirmadoIntermedio").Visible = False
                'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdIntermedio").Visible = False
                'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("PesoBrutoEntrada").Visible = False

                Me.TDBGridPuntosInter.RowHeight = 25
                Me.Button3.Enabled = True



                'Me.TDBGridPuntosInter.Splits.Item(0).DisplayColumns("IdIntermedio").Visible = False


                'Me.TDGridDetalleRecibos.DataSource = DataSet.Tables("RecibosLiquida")

                '    Me.BinDetalleRecLiq.DataSource = DataSet.Tables("RecibosLiquida")
                '    Me.TDGridDetalleRecibos.DataSource = Me.BinDetalleRecLiq.DataSource

                '    'Me.BinDetalleRecLiq.DataSource = DataSet.Tables("RecibosLiquida")
                '    'Me.TDGridDetalleRecibos.DataSource = Me.BinDetalleRecLiq

                '    Me.TDGridDetalleRecibos.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
                '    Me.TDGridDetalleRecibos.Columns(0).ValueItems.CycleOnClick = True
                '    With Me.TDGridDetalleRecibos.Columns(0).ValueItems.Values

                '        item.Value = "False"
                '        item.DisplayValue = Me.ImageList.Images(1)
                '        .Add(item)

                '        item = New C1.Win.C1TrueDBGrid.ValueItem()
                '        item.Value = "True"
                '        item.DisplayValue = Me.ImageList.Images(0)
                '        .Add(item)

                '        Me.TDGridDetalleRecibos.Columns(0).ValueItems.Translate = True
                '    End With

                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).Width = 149
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).Width = 150
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).Width = 150
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).Width = 150
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).Width = 149
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(6).Visible = False
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(7).Visible = False
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(8).Visible = False
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(9).Visible = False
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(10).Visible = False
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(11).Visible = False
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '    Me.TDGridDetalleRecibos.Splits.Item(0).DisplayColumns(5).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                '    Me.CheckTodosRecibos.Checked = True
                '    'Me.TDGridDetalleRecibos.Columns("Aplicar").Value = False
                '    'Me.TDGridDetalleRecibos.Columns("Aplicar").Value = True
                '    Me.TDGridDetalleRecibos.Columns("ValorBruto$").NumberFormat = "##,##0.00"
                '    Me.TDGridDetalleRecibos.Columns("Precio").NumberFormat = "##,##0.00"
                '    Me.TDGridDetalleRecibos.Columns("PesoNeto").NumberFormat = "##,##0.00"
                '    Me.TDGridDetalleRecibos.Columns("ValorBrutoC$").NumberFormat = "##,##0.00"
                '    Me.TDGridDetalleRecibos.Columns("ValorBruto$").NumberFormat = "##,##0.00"


                '    Sql = "SELECT  AplicacionLiquidacionPergamino.Descripcion AS Concepto, TipoPago.Descripcion AS TipoPago, DetalleDistribucion.NumeroAvio AS NumeroSolicitud, DetalleDistribucion.Monto AS Monto,  DetalleDistribucion.FechaPago AS FechaPago, DetalleDistribucion.IdDetalleDistribucion   FROM    DetalleDistribucion INNER JOIN   AplicacionLiquidacionPergamino ON DetalleDistribucion.IdAplicacionLiquidacionPergamino = AplicacionLiquidacionPergamino.IdAplicacionLiquidacionPergamino INNER JOIN  TipoPago ON DetalleDistribucion.IdTipoPago = TipoPago.IdTipoPago INNER JOIN LiquidacionPergamino ON DetalleDistribucion.IdLiquidacionPergamino = LiquidacionPergamino.IdLiquidacionPergamino  WHERE  (LiquidacionPergamino.IdLiquidacionPergamino = '" & Me.TxtIdLiquidacion.Text & "')"
                '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                '    DataAdapter.Fill(DataSet, "DistrbLiquida")
                '    Me.TDBGRidDistribucion.DataSource = DataSet.Tables("DistrbLiquida")
                '    'count = DataSet.Tables("DistrbLiquida").Rows.Count

                '    count = 0
                '    i = 0
                '    SqlString = "SELECT Descripcion   FROM    AplicacionLiquidacionPergamino"
                '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                '    DataAdapter.Fill(DataSet, "AplicacionLiquid")
                '    count = DataSet.Tables("AplicacionLiquid").Rows.Count

                '    Me.TDBGRidDistribucion.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
                '    With Me.TDBGRidDistribucion.Columns(0).ValueItems.Values
                '        Do While count > i
                '            If i = 0 Then
                '                Descripcion = DataSet.Tables("AplicacionLiquid").Rows(i)("Descripcion")
                '                item1.Value = Descripcion
                '                .Add(item1)
                '            Else
                '                Descripcion = DataSet.Tables("AplicacionLiquid").Rows(i)("Descripcion")
                '                item1 = New C1.Win.C1TrueDBGrid.ValueItem()
                '                item1.Value = Descripcion
                '                .Add(item1)
                '            End If
                '            i = i + 1
                '        Loop
                '    End With
                '    count = 0
                '    i = 0
                '    SqlString = "SELECT   Descripcion   FROM TipoPago WHERE  (Activo = 1) "
                '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                '    DataAdapter.Fill(DataSet, "TipoPago")
                '    count = DataSet.Tables("TipoPago").Rows.Count
                '    '____________________________________________________
                '    'LLENE LOS COMBOBOX(0) DEL GRID DE DISTRBUCION 
                '    '____________________________________________________
                '    Me.TDBGRidDistribucion.Columns(1).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
                '    With Me.TDBGRidDistribucion.Columns(1).ValueItems.Values
                '        Do While count > i
                '            If i = 0 Then
                '                Descripcion = DataSet.Tables("TipoPago").Rows(i)("Descripcion")
                '                item2.Value = Descripcion
                '                .Add(item2)
                '            Else
                '                Descripcion = DataSet.Tables("TipoPago").Rows(i)("Descripcion")
                '                item2 = New C1.Win.C1TrueDBGrid.ValueItem()
                '                item2.Value = Descripcion
                '                .Add(item2)
                '            End If
                '            i = i + 1
                '        Loop
                '    End With
            End If


            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).Width = 160
            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(1).Width = 160
            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(2).Width = 200
            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(3).Width = 160
            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(4).Width = 160
            'Me.TDBGRidDistribucion.Columns(3).NumberFormat = "##,##0.00"


            'Me.TDBGRidDistribucion.Columns(2).EditMask = "#-##-#####"
            'Me.TDBGRidDistribucion.Columns(2).EditMaskUpdate = True

            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(0).Locked = False

            'Me.TDBGRidDistribucion.Splits.Item(0).DisplayColumns(5).Visible = False

            ''ACTUALIZO EL GRID
            'SumaGrid1()
            'sumagriddistribucion()
            ''Else
            ''Button3_Click(sender, e)
            ''Exit Sub
            ''End If
            'If Not IsDBNull(DataSet.Tables("LlamaLiquida").Rows(0)("EstadoDocumento")) Then
            '    Me.CboEstadoDocumeto.Text = DataSet.Tables("LlamaLiquida").Rows(0)("EstadoDocumento")
            'Else
            '    Me.CboEstadoDocumeto.Text = ""
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        PegarRemision = False


        QuienRemision = ""
    End Sub

    Private Sub TDBGridPuntosInter_BeforeOpen(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TDBGridPuntosInter.BeforeOpen

        Dim Cont As Double, i As Double, CantidadBascula As Double, PesoBascula As Double, TipoPesada As String, oDataRow As DataRow, CadenaDiv() As String, Max As Double
        Dim DataSetGrid As New DataSet, j As Double, Reg As Double, Categoria As String
        Dim NumeroRecibo As String, Cantidad As Double, PesoBruto As Double, PesoBrutoEntrada As Double, MermaEntrada As Double, CantidadDestino As Double, PesoBrutoDestino As Double, MermaBodega As Double, MermaTotal As Double, CantDiv() As String, h As Double = 0
        Dim MermaTransito As Double, CantidadEntrada As Double, PesoBrutoSalida As Double, CantidadSalida As Double, iPosicionDetalle As Double
        Dim PesoBasculaSalida As Double, CantidadBasculaSalida As Double
        '------------------------------------------------------------------------------------------------------------------------------
        'Mando una consulta que no retorna nada
        '------------------------------------------------------------------------------------------------------------------------------
        sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, ReciboCafePergamino.Codigo As Categoria, DetalleReciboCafePergamino.Tara As PesoBruto,DetalleReciboCafePergamino.Tara As Cantidad, DetalleReciboCafePergamino.Tara As PesoBrutoEntrada ,DetalleReciboCafePergamino.Tara As CantidadEntrada, DetalleReciboCafePergamino.Tara AS CantidadDestino ,DetalleReciboCafePergamino.Tara AS PesoBrutoDestino, DetalleReciboCafePergamino.Tara As MermaBodega, DetalleReciboCafePergamino.Tara As MermaTransito, DetalleReciboCafePergamino.Tara As MermaTotal  FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSetGrid, "ListaRecibos")


        If CboTipoRemision.Text = "MAQUILA" Then

            '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
            Reg = Me.TDBGridDetalle.RowCount
            i = 0
            Do While Reg > i
                Me.TDBGridDetalle.Row = i
                CantidadBascula = 0
                PesoBascula = 0
                iPosicionDetalle = Me.TDBGridPuntosInter.Row
                TipoPesada = "Rec" & Me.TDBGridDetalle.Item(i)("Codigo") & "-N" & i & "-D" & iPosicionDetalle & "-P1"
                'TipoPesada = "Rec" & Me.TDGribListRecibos.Columns("Codigo").Text & "-N" & i & "-D" & Me.TDBGridPuntosInter.Row
                '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "')  AND (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSetGrid, "Consulta")
                If Not DataSetGrid.Tables("Consulta").Rows.Count = 0 Then
                    PesoBascula = DataSetGrid.Tables("Consulta").Rows(0)("PesoNetoKg")
                    CantidadBascula = DataSetGrid.Tables("Consulta").Rows(0)("QQ")
                End If
                DataSetGrid.Tables("Consulta").Reset()


                TipoPesada = "Rec" & Me.TDBGridDetalle.Item(i)("Codigo") & "-N" & i & "-D" & iPosicionDetalle & "-P2"
                '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "')   AND (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSetGrid, "Consulta")
                If Not DataSetGrid.Tables("Consulta").Rows.Count = 0 Then
                    PesoBasculaSalida = DataSetGrid.Tables("Consulta").Rows(0)("PesoNetoKg")
                    CantidadBasculaSalida = DataSetGrid.Tables("Consulta").Rows(0)("QQ")
                End If
                DataSetGrid.Tables("Consulta").Reset()



                NumeroRecibo = Me.TDBGridDetalle.Item(i)("Codigo")
                Cantidad = CDbl(Me.TDBGridDetalle.Item(i)("CantidadSacos"))
                'PesoBruto = CDbl(Me.TDGribListRecibos.Item(i)("PESONETO"))
                Categoria = Me.TDGribListRecibos.Item(i)("Categoria")
                '/////////////////////////////////////BUSCO LOS DETALLES DE LOS RECIBOS ////////////////////////////////////
                PesoBruto = CDbl(Me.TDBGridDetalle.Item(i)("PesoBruto"))

                MermaEntrada = Format(0 - PesoBascula, "##,##0.00")
                MermaBodega = Format(PesoBasculaSalida - PesoBascula, "##,##0.00")
                MermaTotal = MermaBodega - MermaEntrada
                MermaTransito = Format(PesoBascula - PesoBruto, "##,##0.00")


                oDataRow = DataSetGrid.Tables("ListaRecibos").NewRow
                oDataRow("NumeroRecibo") = NumeroRecibo
                oDataRow("Categoria") = Categoria
                oDataRow("Cantidad") = Cantidad
                oDataRow("PesoBruto") = PesoBruto
                oDataRow("PesoBrutoEntrada") = PesoBascula
                oDataRow("CantidadEntrada") = CantidadBascula
                oDataRow("CantidadDestino") = CantidadBasculaSalida
                oDataRow("PesoBrutoDestino") = PesoBasculaSalida
                oDataRow("MermaBodega") = MermaBodega
                oDataRow("MermaTransito") = MermaTransito
                'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                DataSetGrid.Tables("ListaRecibos").Rows.Add(oDataRow)

                'oDataRow = DataSetGrid.Tables("ListaRecibos").NewRow
                'oDataRow("NumeroRecibo") = NumeroRecibo
                'oDataRow("Cantidad") = Cantidad
                'oDataRow("PesoBruto") = PesoBruto
                'oDataRow("PesoBrutoEntrada") = 0
                'oDataRow("MermaTransito") = MermaEntrada
                'oDataRow("CantidadDestino") = CantidadBascula
                'oDataRow("PesoBrutoDestino") = PesoBascula
                'oDataRow("MermaBodega") = MermaBodega
                'oDataRow("MermaTotal") = MermaTotal
                ''oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                'DataSetGrid.Tables("ListaRecibos").Rows.Add(oDataRow)

                i = i + 1
            Loop


            'Me.TDBGridPuntosInterMaquila.DataSource = DataSetGrid.Tables("ListaRecibos")
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("NumeroRecibo").Width = 80
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("NumeroRecibo").Style.Font = New Font("Arial", 10)
            'Me.TDBGridPuntosInterMaquila.Columns("NumeroRecibo").Caption = "Recibo No"
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBruto").Width = 80
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("Categoria").Width = 60
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBrutoEntrada").Width = 80
            'Me.TDBGridPuntosInterMaquila.Columns("PesoBrutoEntrada").Caption = "Peso Entrada"
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("MermaEntrada").Width = 85
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("CantidadDestino").Width = 60
            'Me.TDBGridPuntosInterMaquila.Columns("CantidadDestino").Caption = "Cantidad"
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBrutoDestino").Width = 80
            'Me.TDBGridPuntosInterMaquila.Columns("PesoBrutoDestino").Caption = "Peso Salida"
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("MermaBodega").Width = 85
            'Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("MermaTotal").Width = 85

            Me.TDBGridPuntosInterMaquila.DataSource = DataSetGrid.Tables("ListaRecibos")
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("NumeroRecibo").Width = 80
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("NumeroRecibo").Style.Font = New Font("Arial", 10)
            Me.TDBGridPuntosInterMaquila.Columns("NumeroRecibo").Caption = "Recibo No"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("Cantidad").Visible = False
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("Categoria").Width = 60
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("NumeroRecibo").Width = 80
            Me.TDBGridPuntosInterMaquila.Columns("Cantidad").Caption = "Cant QQ"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBruto").Width = 80
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBrutoEntrada").Width = 80
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBrutoEntrada").Visible = True
            Me.TDBGridPuntosInterMaquila.Columns("PesoBrutoEntrada").Caption = "Peso Entrada"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("CantidadEntrada").Width = 90
            Me.TDBGridPuntosInterMaquila.Columns("CantidadEntrada").Caption = "Cant.Entrada"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("CantidadEntrada").Visible = True
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("CantidadDestino").Width = 60
            Me.TDBGridPuntosInterMaquila.Columns("CantidadDestino").Caption = "Cantidad"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBrutoDestino").Width = 80
            Me.TDBGridPuntosInterMaquila.Columns("PesoBrutoDestino").Caption = "Peso Salida"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("MermaBodega").Width = 85
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("MermaTransito").Width = 90

        Else

            '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
            Reg = Me.TDBGridDetalle.RowCount
            i = 0
            Do While Reg > i
                Me.TDBGridDetalle.Row = i
                CantidadBascula = 0
                PesoBascula = 0
                'TipoPesada = "Rec" & Me.TDGribListRecibos.Columns("Codigo").Text & "-N" & i & "-D" & Me.TDBGridPuntosInter.Row
                TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & Me.TDBGridPuntosInter.Row
                '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "')  AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"  'AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102))
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSetGrid, "Consulta")
                If Not DataSetGrid.Tables("Consulta").Rows.Count = 0 Then
                    PesoBascula = DataSetGrid.Tables("Consulta").Rows(0)("PesoNetoKg")
                    CantidadBascula = DataSetGrid.Tables("Consulta").Rows(0)("QQ")
                End If
                DataSetGrid.Tables("Consulta").Reset()


                NumeroRecibo = TDBGridDetalle.Columns("IdDetalleReciboPergamino").Text
                '/////////////////////////////////////BUSCO LOS DETALLES DE LOS RECIBOS ////////////////////////////////////
                CadenaDiv = NumeroRecibo.Split("-")
                Max = UBound(CadenaDiv)

                Cantidad = 0
                PesoBruto = 0
                For j = 0 To Max
                    '//////////////////////RECORRO EL GRID DE RECIBOS //////////////////////////////////////////////////
                    Cont = Me.TDGribListRecibos.RowCount
                    h = 0
                    For h = 0 To Cont
                        Me.TDGribListRecibos.Row = h
                        If CadenaDiv(j) = Me.TDGribListRecibos.Columns("IdDetalleReciboPergamino").Text Then
                            Cantidad = CDbl(Me.TDGribListRecibos.Columns("CantidadSacos").Text) + Cantidad
                            PesoBruto = CDbl(Me.TDGribListRecibos.Columns("PESONETO").Text) + PesoBruto
                            Categoria = Me.TDGribListRecibos.Columns("Categoria").Text
                            Exit For
                        End If
                    Next
                Next

                PesoBrutoEntrada = 0
                CantidadEntrada = 0
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////////////////////////////////BUSCO EL PESO BRUTO DE ENTRADA AL PUNTO INTERMIDIO ///////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & Me.TDBGridPuntosInter.Row & "-P1"
                '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS ////////////////////////// 'AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102))
                sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "')  AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSetGrid, "Consulta")
                If Not DataSetGrid.Tables("Consulta").Rows.Count = 0 Then
                    PesoBrutoEntrada = DataSetGrid.Tables("Consulta").Rows(0)("PesoNetoKg")
                    CantidadEntrada = DataSetGrid.Tables("Consulta").Rows(0)("QQ")
                End If
                DataSetGrid.Tables("Consulta").Reset()



                PesoBrutoSalida = 0
                CantidadSalida = 0
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '///////////////////////////////////////////////////BUSCO EL PESO BRUTO DE ENTRADA AL PUNTO INTERMIDIO ///////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & Me.TDBGridPuntosInter.Row & "-P2"
                '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"  'AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102))
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSetGrid, "Consulta")
                If Not DataSetGrid.Tables("Consulta").Rows.Count = 0 Then
                    PesoBrutoSalida = DataSetGrid.Tables("Consulta").Rows(0)("PesoNetoKg")
                    CantidadSalida = DataSetGrid.Tables("Consulta").Rows(0)("QQ")
                End If
                DataSetGrid.Tables("Consulta").Reset()

                If Me.TDBGridPuntosInter.Row = 0 Then
                    PesoBruto = Me.TDBGridDetalle.Columns("PesoNeto").Text
                    Cantidad = Me.TDBGridDetalle.Columns("CantidadSacos").Text
                Else
                    '///////////////////////BUSCO LAS PESADAS ANTERIORES ///////////////////////////////////////
                    TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & Me.TDBGridPuntosInter.Row - 1 & "-P2"
                    '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                    sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(DataSetGrid, "Consulta")
                    If Not DataSetGrid.Tables("Consulta").Rows.Count = 0 Then
                        PesoBruto = DataSetGrid.Tables("Consulta").Rows(0)("PesoNetoKg")
                        Cantidad = DataSetGrid.Tables("Consulta").Rows(0)("QQ")
                    End If
                    DataSetGrid.Tables("Consulta").Reset()

                    'Cantidad = Me.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Text
                    'PesoBruto = Me.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Text
                    'PesoBrutoDetalleRem = Me.TDBGridDetalle.Columns("PesoNeto").Text
                    'CantidadDetalleRem = Me.TDBGridDetalle.Columns("CantidadSacos").Text
                    'MermaBodega = Format(PesoBruto - PesoBrutoDetalleRem, "##,##0.00")
                    'MermaTransito = Format(PesoBruto - PesoBascula, "##,##0.00")
                End If


                'MermaEntrada = Format(0 - PesoBruto, "##,##0.00")

                'MermaTotal = MermaBodega - MermaEntradape

                MermaTransito = Format(PesoBruto - PesoBrutoEntrada, "##,##0.00")
                MermaBodega = Format(PesoBrutoSalida - PesoBrutoEntrada, "##,##0.00")


                oDataRow = DataSetGrid.Tables("ListaRecibos").NewRow
                oDataRow("NumeroRecibo") = TDBGridDetalle.Columns("Codigo").Text
                oDataRow("Categoria") = Categoria
                oDataRow("Cantidad") = Cantidad
                oDataRow("PesoBruto") = PesoBruto
                oDataRow("PesoBrutoEntrada") = PesoBrutoEntrada
                oDataRow("CantidadEntrada") = CantidadEntrada
                oDataRow("CantidadDestino") = CantidadSalida
                oDataRow("PesoBrutoDestino") = PesoBrutoSalida
                oDataRow("MermaBodega") = MermaBodega
                oDataRow("MermaTransito") = MermaTransito
                'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                DataSetGrid.Tables("ListaRecibos").Rows.Add(oDataRow)

                i = i + 1
            Loop


            Me.TDBGridPuntosInterMaquila.DataSource = DataSetGrid.Tables("ListaRecibos")
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("NumeroRecibo").Width = 80
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("NumeroRecibo").Style.Font = New Font("Arial", 10)
            Me.TDBGridPuntosInterMaquila.Columns("NumeroRecibo").Caption = "Recibo No"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("Cantidad").Width = 60
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("Cantidad").Visible = False
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("Categoria").Width = 60
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("NumeroRecibo").Width = 80
            Me.TDBGridPuntosInterMaquila.Columns("Cantidad").Caption = "Cant QQ"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBruto").Width = 80
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBrutoEntrada").Width = 80
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBrutoEntrada").Visible = True
            Me.TDBGridPuntosInterMaquila.Columns("PesoBrutoEntrada").Caption = "Peso Entrada"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("CantidadEntrada").Width = 90
            Me.TDBGridPuntosInterMaquila.Columns("CantidadEntrada").Caption = "Cant.Entrada"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("CantidadEntrada").Visible = True
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("CantidadDestino").Width = 60
            Me.TDBGridPuntosInterMaquila.Columns("CantidadDestino").Caption = "Cantidad"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("PesoBrutoDestino").Width = 80
            Me.TDBGridPuntosInterMaquila.Columns("PesoBrutoDestino").Caption = "Peso Salida"
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("MermaBodega").Width = 85
            Me.TDBGridPuntosInterMaquila.Splits.Item(0).DisplayColumns("MermaTransito").Width = 90


        End If
        Me.TDBGridPuntosInterMaquila.RowHeight = 30



    End Sub

    Private Sub TDBGridPuntosInterMaquila_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles TDBGridPuntosInterMaquila.FetchCellTips
        '// setting e.CellTip to an empty string disables the built-in celltip
        Dim tdbgrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid = sender, Msg As String
        e.CellTip = String.Empty

        '// now use supertooltip


        '// save the current row and column index, we'll use this in MouseMove
        Me._rowcol = New Point(e.ColIndex, e.Row)
        'Dim tip As String = _tip.Replace("(row,col)", String.Format("<b>({0},{1})</b>", e.Row, e.ColIndex))
        Msg = "Recibos " & Me.TDBGridPuntosInterMaquila.Columns(0).Text
        Me.c1SuperTooltip1.IsBalloon = True
        Me.c1SuperTooltip1.SetToolTip(tdbgrid, Msg)



    End Sub

    Private Sub TDBGridPuntosInterMaquila_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TDBGridPuntosInterMaquila.MouseMove
        Dim tdbgrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid = sender
        Dim p As Point, curRowCol As Point

        p = tdbgrid.PointToClient(Control.MousePosition)
        curRowCol = New Point(tdbgrid.ColContaining(p.X), tdbgrid.RowContaining(p.Y))

        'If (Me._rowcol.Equals(curRowCol)) Then Me.c1SuperTooltip1.Hide(tdbgrid)


    End Sub

    Private Sub TDBGridPuntosInterMaquila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDBGridPuntosInterMaquila.Click

    End Sub

    Private Sub TDBGridPuntosInter_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles TDBGridPuntosInter.BeforeRowColChange

    End Sub

    Private Sub TDBGridPuntosInter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDBGridPuntosInter.Click
        Try
            Dim Iposicion As Double, Confirmado As Boolean
            Iposicion = Me.TDBGridPuntosInter.Row
            Confirmado = Me.TDBGridPuntosInter.Item(Iposicion)("ConfirmadoIntermedio")

            If Confirmado = True Then
                Me.Button3.Enabled = False
            ElseIf Confirmado = False Then
                Me.Button3.Enabled = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        LimpiarRem()
    End Sub

    Private Sub Button6_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevoRem.Click
        CierreFormulario()
        LimpiarRem()
    End Sub

    Public Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarRem.Click
        Dim SQLRem As String, Contador As Integer, suma As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, IdVehiculo As Double, Placa As String
        Dim i As Integer, Registros As Integer, ID As Double, EmpresaTransporte As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, StrSqlInsert As String
        Dim FechaCrg As String, sql2 As String, FechaSal As String, ContadorDetalle As Double, IdsDetallRecibos As String
        Dim IdRemision As Double, IdDetalleRecibo As Double, idReciboCafe As Double, IdDetalleRemision As Double, Sacos As Integer, Encontrado As Double
        Dim CadenaDiv() As String, Cadena As String, j As Integer, CountDet As Integer, max As Double, h As Double
        Dim Merma As Double = 0, IdLocalidad As Double, ConfirmaIntermedio As Boolean = False, sqlstring As String, NumeroCarga As String
        Dim ConsecutivoCompra As Double, Recibos(,) As Double, TotalGrupo As Double, IdIntermedio As Double, Porciento As Double, MontoRecibo As Double
        Dim IdRecibCafe As Double, PesoNeto As Double, SQlUpdatePesadas As String, IdReciboRemisionPergamino As Double = 0
        Dim CantidadBascula As Double, PesoBascula As Double, iPosicionDetalle As Double, TipoPesada As String, PesoBasculaSalida As Double, CantidadBasculaSalida As Double, PesoRemisionado As Double
        Dim Serie As String
        Dim NumeroRecepcion As String, FechaRecepcion As Date



        '//////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////BUSCAR SI EL CONDUCTOR YA REGISTRO SU LLEGADA ////////////
        '/////////////////////////////////////////////////////////////////////////////////////

        sqlstring = "SELECT  IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta, DATEDIFF(hh, Fecha, CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS Horas FROM Registros WHERE (TipoRegistro = 'Llegada') AND (Placa = '" & CboEmprsPlaca.Text & "') AND (NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta2")
        If DataSet.Tables("Consulta2").Rows.Count = 0 Then
            MsgBox("No Existe Registro de llegada para este camion", MsgBoxStyle.Critical, " Remision ")
            Exit Sub
        End If

        If Me.TDGridUseParc.RowCount = 0 Then
            MsgBox("Necesita Filtrar Recibos para Grabar", MsgBoxStyle.Critical, " Remision ")
            Exit Sub
        End If

        Me.BtnGuardarRem.Enabled = False



        sql = "SELECT IdEstadoDocumento FROM EstadoDocumento WHERE (Descripcion= '" & Me.CboEstadoDoc.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "estadodoc")
        If Not DataSet.Tables("estadodoc").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("estadodoc").Rows(0)("IdEstadoDocumento")) Then
                Me.TxtIdEstadoDoc.Text = DataSet.Tables("estadodoc").Rows(0)("IdEstadoDocumento")
            End If
        End If


        If Me.TxtIdRemision.Text = "" Then
            SQLRem = "SELECT   *   FROM   RemisionPergamino  WHERE  (Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLugarAcopio & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                IdRemision = DataSet.Tables("Consulta").Rows(0)("IdRemisionPergamino")
            End If
        Else
            IdRemision = Me.TxtIdRemision.Text
        End If



        If Val(IdRemision) <> 0 Then
            sql = "SELECT  IdRemisionPergamino, ConfirmadoDetalle FROM RemisionPergamino  WHERE (IdRemisionPergamino = " & IdRemision & ")  "
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            'ConfirmadoDetalle = False
            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                ConfirmadoDetalle = DataSet.Tables("Consulta").Rows(0)("ConfirmadoDetalle")
            End If
        Else


            If Me.TxtIdEstadoDoc.Text <> "293" Then
                MsgBox("Se cambiara el Estado a Editable, No se puede Grabar sin Confirmar Detalle", MsgBoxStyle.Critical, "Sistema Bascula")
                Me.TxtIdEstadoDoc.Text = 293
                Me.CboEstadoDoc.Text = "Editable"
                ConfirmadoDetalle = False
            End If

        End If


            Contador = Me.TDBGridDetalle.RowCount
            i = 0
            suma = 0
            Do While Contador > i
                suma = suma + CDbl(Me.TDBGridDetalle.Item(i)("PesoBruto")) + CDbl(Me.TDBGridDetalle.Item(i)("Tara")) + CDbl(Me.TDBGridDetalle.Item(i)("PesoNeto")) + CDbl(Me.TDBGridDetalle.Item(i)("CantidadSacos"))
                i = i + 1
            Loop

            If suma = 0 Then
                MsgBox("Necesitan Pesadas para Grabar", MsgBoxStyle.Critical, " Remision ")
                Me.BtnGuardarRem.Enabled = True
                Exit Sub
            End If

            ''////////////////////////////////////////////////////////////////////
            ''/////////////////////////////BUSCO SI EXISTE ESTE REGISTRO /////////
            ''///////////////////////////////////////////////////////////////////////
            'sql = "SELECT Registros.*  FROM Registros WHERE (NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (TipoRegistro = 'Reserva')"
            'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            'DataAdapter.Fill(DataSet, "LugarAcopio")
            'If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
            '    MsgBox("Ya existe esta boleta para su Reserva !!!!", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If


            'If Registros >= 2 Or Registros = 0 Then
            '    Me.TDBGridPuntosInter.Row = Registros - 1
            'If Me.TDBGridPuntosInter.Columns(13).Text = "" Then
            '    ID = 0
            'Else
            '    ID = Me.TDBGridPuntosInter.Columns(13).Text
            '    SQLRem = "SELECT  IdLugarAcopio, CodLugarAcopio, NomLugarAcopio, IdPadre, IdRegion, TipoLugarAcopio, FDA, Direccion, Telefono, PPCDefecto, CapacidadRecep,    IdUMedidaRecep, CapacidadSecado, IdUMedidaSecado, BultosMaxSecado, IdUsuario, IdCompany, NombreCorto, Fax, Activo, CapacidadAlmacenamiento,  IdUMedidaAlmacenamiento  FROM  LugarAcopio WHERE (NomLugarAcopio LIKE '%Planta Procesadora%') AND (IdLugarAcopio = " & ID & ")"
            '    DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
            '    DataAdapter.Fill(DataSet, "Intermedio")
            '    If DataSet.Tables("Intermedio").Rows.Count = 0 Then
            '        MsgBox("EL ULTIMO PUNTO INTERMEDIO DEBE SER UNA PLANTA PROCESADORA", MsgBoxStyle.Critical, "PUNTO INTERMEDIO")
            '        Exit Sub
            '    End If
            'End If

            'If Me.TxtNumeroRemision.Text = "" Then
            '    MsgBox("DIGITE UN CODIGO DE REMISION", MsgBoxStyle.Critical, "Detalle Remision")
            '    Exit Sub
            'Else
            '---------------------------------------------------------------------------------------------------
            'GUARDO TABLA REMISION PERMIGAMINO 
            '---------------------------------------------------------------------------------------------------

            If Me.TxtIdRemision.Text = "" Then
                SQLRem = "SELECT   *   FROM   RemisionPergamino  WHERE  (Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLugarAcopio & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdRemision = DataSet.Tables("Consulta").Rows(0)("IdRemisionPergamino")
                End If
            Else
                IdRemision = Me.TxtIdRemision.Text
            End If


            ConsecutivoRemision()
            idCosecha = Me.TextIdCosecha.Text

            'SQLRem = "SELECT   *   FROM   RemisionPergamino  WHERE  (Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLugarAcopio & ")"
            SQLRem = "SELECT  RemisionPergamino.* FROM RemisionPergamino  WHERE(IdRemisionPergamino = " & IdRemision & ") AND (IdTipoCafe = " & IdTipoCafe & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
            DataAdapter.Fill(DataSet, "Remisiones")

            Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
            FechaCrg = Me.DTPRemFechCarga.Value
            FechaSal = Me.DTPRemFechSalid.Value

            If Me.TxtNumeroRemision.Text = "" Or Me.CboEmpresaTrans.Text = "" Or Me.CboEmpresaCond.Text = "" Or Me.CboEmprsPlaca.Text = "" Then
                MsgBox("ALGUNOS CAMPOS ESTAN VACIOS POR FAVOR REVISE LA INFORMACION", MsgBoxStyle.Critical, "Remision")
                Me.BtnGuardarRem.Enabled = True
                Exit Sub
            Else
                If Not DataSet.Tables("Remisiones").Rows.Count = 0 Then
                    '///////////SI EXISTE UNA REMISION LA ACTUALIZO////////////////
                    'If MsgBox("ESTE CODIGO YA EXISTE DESEA ACTUALIZARLO?", MsgBoxStyle.YesNo, "Remision Cafe") = MsgBoxResult.Yes Then
                    StrSqlUpdate = "UPDATE [RemisionPergamino] SET [Codigo] = '" & Me.TxtNumeroRemision.Text & "', [FechaCarga] = CONVERT(DATETIME, '" & Format(CDate(FechaCrg), "yyyy-MM-dd HH:mm:ss") & "', 102) ,[HoraSalida] = CONVERT(DATETIME, '" & Format(CDate(FechaSal), "yyyy-MM-dd HH:mm:ss") & "', 102) ,[Observacion] ='" & Observaciones & "'  ,[IdCosecha] =" & Trim(Me.TextIdCosecha.Text) & " ,[IdCalidad] ='" & Me.TxtIdcalidad.Text & "',[IdEstadoDocumento] ='" & Me.TxtIdEstadoDoc.Text & "'    ,[IdConductor] ='" & Me.TxtIdConductor.Text & "'   ,[IdEmpresaTransporte] ='" & Me.TxtIdEmprTrans.Text & "'   ,[IdVehiculo] ='" & Me.TxtIdVehiculo.Text & "' ,[IdDestino] ='" & Me.TxtDestino.Text & "'   ,[IdTipoIngreso] = '" & Me.TxtIdIngreso.Text & "',[ConfirmadoDetalle] = '" & ConfirmadoDetalle & "',[Numero_Boleta] = '" & Me.TxtNumeroBoleta.Text & "',[IdRutaLogica] = " & IdRutaLogica & "  WHERE  (IdRemisionPergamino = '" & IdRemision & "') AND (IdTipoCafe = " & IdTipoCafe & ") " 'AND (IdLugarAcopio = " & IdLugarAcopio & ")"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()

                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////CUANDO YA ESTA GRABADA LA REMISION CREO UN REGISTRO DE RESERVA ////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    'sql = "SELECT LugarAcopio.* FROM LugarAcopio WHERE (CodLugarAcopio = " & IdSucursal & ") AND (Activo = 1)"
                    'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    'DataAdapter.Fill(DataSet, "LugarAcopio")
                    'If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
                    '    IdLocalidad = DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
                    '    CodLugarAcopio = IdSucursal
                    'End If


                    ''/////////////////////////////SI LA SALIDA ES PARA EL DIA SIGUIENTE GRABO EL REGISTRO DE SALIDA ////////////////////////

                    'If CDbl(Mid(Format(DTPRemFechSalid.Value, "dd-MM-yyyy"), 1, 2)) > CDbl(Mid(Format(Me.DTPRemFechCarga.Value, "dd-MM-yyyy"), 1, 2)) Then
                    '    GrabaRegistros(Me.TxtNumeroBoleta.Text, "Reserva", Me.TxtIdConductor.Text, IdLocalidad, Me.DTPRemFechCarga.Value, Me.CboEmprsPlaca.Text, Me.TxtNumeroBoleta.Text)
                    '    GrabaRegistros(Me.TxtNumeroBoleta.Text, "Salida", Me.TxtIdConductor.Text, IdLocalidad, Me.DTPRemFechCarga.Value, Me.CboEmprsPlaca.Text, Me.TxtNumeroBoleta.Text)
                    'End If
                Else
                    '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                    StrSqlInsert = "INSERT INTO  [dbo].[RemisionPergamino] ([Codigo],[FechaCarga],[Fecha],[HoraSalida],[Observacion],[IdCosecha],[IdLugarAcopio],[IdCalidad],[IdEstadoDocumento],[IdConductor],[IdEmpresaTransporte],[IdVehiculo],[IdDestino],[IdTipoCafe],[IdTipoIngreso],[IdUMedida],[IdElaboradorPor],[IdUsuario],[IdCompany],[FechaModificacion],[Serie], [ConfirmadoDetalle],[Numero_Boleta],[IdRutaLogica])   " & _
                                   "VALUES ('" & Me.TxtNumeroRemision.Text & "',CONVERT(DATETIME, '" & Format(CDate(FechaCrg), "yyyy-MM-dd HH:mm:ss") & "', 102),CONVERT(DATETIME, '" & Format(CDate(Me.LblFecha.Text & " " & Me.LblHora.Text), "yyyy-MM-dd HH:mm:ss") & "', 102),CONVERT(DATETIME, '" & Format(CDate(FechaSal), "yyyy-MM-dd HH:mm:ss") & "', 102) ,'" & Observaciones & "'," & idCosecha & ",'" & Me.TxtIdLugarAcopio.Text & "','" & Me.TxtIdcalidad.Text & "','" & Me.TxtIdEstadoDoc.Text & "','" & Me.TxtIdConductor.Text & "','" & Me.TxtIdEmprTrans.Text & "','" & Me.TxtIdVehiculo.Text & "','" & Me.TxtDestino.Text & "','" & IdTipoCafe & "','" & Me.TxtIdIngreso.Text & "','1','" & IdUsuario & "','" & IdUsuario & "','1',  CONVERT(DATETIME, '" & Format(CDate(Me.LblFecha.Text & " " & Me.LblHora.Text), "yyyy-MM-dd HH:mm:ss") & "', 102) ,'" & Me.TxtSerie.Text & "', '" & ConfirmadoDetalle & "', '" & Me.TxtNumeroBoleta.Text & "', " & IdRutaLogica & ")"
                    MiConexion.Close()
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                    'MsgBox("REMISION GUARDADA CON EXITO", MsgBoxStyle.Exclamation, "Remision")

                    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '///////////////////////////CUANDO YA ESTA GRABADA LA REMISION CREO UN REGISTRO DE RESERVA ////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    sql = "SELECT LugarAcopio.* FROM LugarAcopio WHERE (CodLugarAcopio = " & IdSucursal & ") AND (Activo = 1)"
                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(DataSet, "LugarAcopio")
                    If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
                        IdLocalidad = DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
                        CodLugarAcopio = IdSucursal
                    End If



                    '/////////////////////////////SI LA SALIDA ES PARA EL DIA SIGUIENTE GRABO EL REGISTRO DE SALIDA ////////////////////////

                    If CDbl(Mid(Format(DTPRemFechSalid.Value, "dd-MM-yyyy"), 1, 2)) > CDbl(Mid(Format(Me.DTPRemFechCarga.Value, "dd-MM-yyyy"), 1, 2)) Then
                        ConsecutivoCompra = BuscaConsecutivo("Reserva", CodLugarAcopio)
                        GrabaRegistros(Me.TxtNumeroBoleta.Text, "Reserva", Me.TxtIdConductor.Text, IdLocalidad, Me.DTPRemFechCarga.Value, Me.CboEmprsPlaca.Text, Me.TxtNumeroBoleta.Text, Me.idCosecha)
                        ConsecutivoCompra = BuscaConsecutivo("Salida", CodLugarAcopio)
                        GrabaRegistros(Me.TxtNumeroBoleta.Text, "Salida", Me.TxtIdConductor.Text, IdLocalidad, Me.DTPRemFechCarga.Value, Me.CboEmprsPlaca.Text, Me.TxtNumeroBoleta.Text, Me.idCosecha)
                    End If


                End If



            End If

            If Me.TxtIdRemision.Text = "" Then
                SQLRem = "SELECT   *   FROM   RemisionPergamino  WHERE  (Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLugarAcopio & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdRemision = DataSet.Tables("Consulta").Rows(0)("IdRemisionPergamino")
                End If
            Else
                IdRemision = Me.TxtIdRemision.Text
            End If

            '////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////////////////////////////////
            LimpiarRegistros(IdRemision)
            '////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////

            '-------------------------------------------------------------------------------------------------------------------------------()
            'GUARDO TABLA DETALLE REMISION PERMIGAMINO 
            '--------------------------------------------------------------------------------------------------------------------------------
            'SQLRem = "SELECT   DetalleReciboCafePergamino.CantidadSacos AS Cantidad, DetalleReciboCafePergamino.Humedad, DetalleReciboCafePergamino.PesoBruto, TipoSaco.IdTipoSaco,   EstadoFisico.IdEdoFisico, Dano.IdDano, ReciboCafePergamino.Codigo, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoNeto,  DetalleReciboCafePergamino.IdDetalleReciboPergamino  FROM      ReciboCafePergamino INNER JOIN    Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN    DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN   EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & Me.CboRecInicial.Text & "' AND '" & Me.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & Me.TxtIdcalidad.Text & "')"
            'SQLRem = "SELECT        IdDetalleRemisionPergamino, CantidadSacos, Humedad, PesoBruto, IdRemisionPergamino, IdSaco, IdEdoFisico, IdDano, IdUsuario FROM            DetalleRemisionPergamino  WHERE        (IdRemisionPergamino =  '" & Me.TxtIdRemision.Text & "')"

            SQLRem = " SELECT * FROM DetalleRemisionPergamino WHERE (IdRemisionPergamino = " & IdRemision & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
            DataAdapter.Fill(DataSet, "DetallesdeRemisiones")




            i = 0
            Contador = 0
            Contador = Me.TDBGridDetalle.RowCount

            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            Do While Contador > i


                ''
                ''    Exit Sub
                ''End If

                Merma = Me.TDBGridMerma.Item(i)("Merma")
                sql = "SELECT  IdDetalleRemisionPergamino, CantidadSacos, Humedad, PesoBruto, IdRemisionPergamino, IdSaco, IdEdoFisico, IdDano, IdUsuario, IdDetalleReciboPergamino, Codigo, PesoNeto2, Tara, CantidadSacos2, Merma, PesoBruto2, Tara2, PesoBrutoEntrada FROM DetalleRemisionPergamino  " & _
                      "WHERE   (IdRemisionPergamino = " & IdRemision & ") AND (IdDetalleReciboPergamino LIKE '%" & Me.TDBGridDetalle.Item(i)("IdDetalleReciboPergamino") & "%')"
                If DataSet.Tables("DetallesdeRemisiones").Rows.Count <> 0 Then
                    'ACTUALIZO LOS DATOS DE  Detalles de Remisiones
                    'If Contador > DataSet.Tables("DetallesdeRemisiones").Rows.Count Then
                    StrSqlUpdate = "UPDATE [DetalleRemisionPergamino] SET  [Merma] = " & Merma & ", [CantidadSacos] = '" & Me.TDBGridDetalle.Item(i)("CantidadSacos") & "',[Humedad] = '" & Me.TDBGridDetalle.Item(i)("Humedad") & "' ,[PesoBruto] ='" & Me.TDBGridDetalle.Item(i)("PesoBruto") & "' ,[IdSaco] ='" & Me.TDBGridDetalle.Item(i)("IdTipoSaco") & "'  ,[IdEdoFisico] ='" & Me.TDBGridDetalle.Item(i)("IdEdoFisico") & "'  ,[IdDano] = '" & Me.TDBGridDetalle.Item(i)("IdDano") & "' ,[IdDetalleReciboPergamino] = '" & Me.TDBGridDetalle.Item(i)("IdDetalleReciboPergamino") & "',[PesoNeto2] = '" & Me.TDBGridDetalle.Item(i)("PesoNeto2") & "' ,[Tara] = '" & Me.TDBGridDetalle.Item(i)("Tara") & "'  WHERE   (IdDetalleRemisionPergamino= '" & DataSet.Tables("DetallesdeRemisiones").Rows(i)("IdRemisionPergamino") & "')"
                    'End If
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                Else
                    '-------------------------------------------------------------------------------------------------------------------------------()
                    'BUSCO EL ID DE REMISION 
                    '--------------------------------------------------------------------------------------------------------------------------------

                    'SQLRem = " SELECT  IdRemisionPergamino FROM  RemisionPergamino ORDER BY IdRemisionPergamino DESC"
                    'DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
                    'DataAdapter.Fill(DataSet, "IdRemisiones")
                    'IdRemision = DataSet.Tables("IdRemisiones").Rows(0)("IdRemisionPergamino")

                    '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                    StrSqlInsert = "INSERT INTO [dbo].[DetalleRemisionPergamino]  ([CantidadSacos]    ,[Humedad]    ,[PesoBruto]  ,[IdRemisionPergamino] ,[IdSaco], [IdEdoFisico] ,[IdDano] ,[IdUsuario],[IdDetalleReciboPergamino],[PesoNeto2],[Codigo],[Tara],[Merma],[PesoBruto2],[Tara2],[CantidadSacos2])" & _
                    "VALUES ('" & Me.TDBGridDetalle.Item(i)("CantidadSacos") & "','" & Me.TDBGridDetalle.Item(i)("Humedad") & "','" & Me.TDBGridDetalle.Item(i)("PesoBruto") & "','" & IdRemision & "','" & Me.TDBGridDetalle.Item(i)("IdTipoSaco") & "','" & Me.TDBGridDetalle.Item(i)("IdEdoFisico") & "','" & Me.TDBGridDetalle.Item(i)("IdDano") & "','" & IdUsuario & "', '" & Me.TDBGridDetalle.Item(i)("IdDetalleReciboPergamino") & "','" & Me.TDBGridDetalle.Item(i)("PesoNeto2") & "','" & Me.TDBGridDetalle.Item(i)("Codigo") & "','" & Me.TDBGridDetalle.Item(i)("Tara") & "'," & Merma & ",'" & Me.TDBGridDetalle.Item(i)("PesoBruto2") & "','" & Me.TDBGridDetalle.Item(i)("Tara2") & "', '" & Me.TDBGridDetalle.Item(i)("CantidadSacos2") & "')"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If
                i = i + 1
            Loop


            '//////////////////////////////'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'CUANDO SE GRABA LA REMION BUSCO LAS PESADAS Y CAMBIO EL NUMERO TEMPORAL DEL SISTEMA ///////
            '???????????????????????????????????????????????????????????????????????????????????????????? '
            If Me.TxtNumeroRemision.Text <> Me.NumeroTemporal Then
                SQlUpdatePesadas = "UPDATE [Detalle_Pesadas]  SET  [NumeroRemision] = '" & Me.TxtNumeroRemision.Text & "', [IdRemisionPergamino] = " & IdRemision & " WHERE  (NumeroRemision = '" & Me.NumeroTemporal & "')"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SQlUpdatePesadas, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            Else
                'StrSqlInsert = "UPDATE [Detalle_Pesadas]  SET  [NumeroRemision] = '" & Me.TxtNumeroRemision.Text & "', [IdRemisionPergamino] = " & IdRemision & " WHERE  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(CDate(Me.DTPFecha.Text), "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & Me.TxtTipoRemision.Text & "') AND (Calidad = '" & Calidad & "') AND (Estado = '" & EstadoFisico & "') AND (TipoPesada = '" & TipoPesada & "')"
            End If



            '-------------------------------------------------------------------------------------------------------------------------------()
            'GUARDO TABLA RECIBOREMISON PERGAMINO
            '--------------------------------------------------------------------------------------------------------------------------------

            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////BORROR TODO EL LISTADO PARA GRABARLO /////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'StrSqlInsert = "DELETE FROM RemisionPergamino WHERE (IdRemisionPergamino = " & IdRemision & " ) "
            'MiConexion.Open()
            'ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
            'iResultado = ComandoUpdate.ExecuteNonQuery
            'MiConexion.Close()


            'SQLRem = "SELECT  RecibosRemisionPergamino.IdReciboRemisionPergamino, RecibosRemisionPergamino.PesoNeto, RecibosRemisionPergamino.IdDetalleReciboPergamino, RecibosRemisionPergamino.IdDetalleRemsionPergamino,                           RecibosRemisionPergamino.IdUsuario, RecibosRemisionPergamino.Orden, RemisionPergamino.IdRemisionPergamino FROM            RemisionPergamino INNER JOIN                          DetalleRemisionPergamino ON RemisionPergamino.IdRemisionPergamino = DetalleRemisionPergamino.IdRemisionPergamino INNER JOIN                          RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino WHERE   (RemisionPergamino.IdRemisionPergamino = " & IdRemision & " )     "
            'DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
            'DataAdapter.Fill(DataSet, "RecibosRemision")

            i = 0
            Contador = 0
            Contador = Me.TDGridUseParc.RowCount
            ReDim Recibos(Contador, 2)
            Do While Contador > i

                '"WHERE  (IdDetalleRemsionPergamino = " & IdRemision & ") AND (IdDetalleReciboPergamino = " & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & ") "


                SQLRem = "SELECT  RecibosRemisionPergamino.IdReciboRemisionPergamino, RecibosRemisionPergamino.PesoNeto, RecibosRemisionPergamino.IdDetalleReciboPergamino, RecibosRemisionPergamino.IdDetalleRemsionPergamino, RecibosRemisionPergamino.IdUsuario, RecibosRemisionPergamino.Orden, RemisionPergamino.IdRemisionPergamino FROM  RemisionPergamino INNER JOIN  DetalleRemisionPergamino ON RemisionPergamino.IdRemisionPergamino = DetalleRemisionPergamino.IdRemisionPergamino INNER JOIN  RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino " & _
                         "WHERE   (RemisionPergamino.IdRemisionPergamino = " & IdRemision & ") AND (RecibosRemisionPergamino.IdDetalleReciboPergamino = " & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
                DataAdapter.Fill(DataSet, "RecibosRemision")
                If DataSet.Tables("RecibosRemision").Rows.Count <> 0 Then

                    IdReciboRemisionPergamino = DataSet.Tables("RecibosRemision").Rows(0)("IdReciboRemisionPergamino")

                    If Me.TxtIdEstadoDoc.Text = "292" Then
                        'StrSqlUpdate = " UPDATE [RecibosRemisionPergamino] SET [PesoNeto] = '" & Me.TDGridUseParc.Item(i)("PesoAplicado") & "' ,[IdDetalleReciboPergamino] = '" & Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino") & "',[IdDetalleRemsionPergamino] = " & IdDetalleRemision & "  WHERE  (IdDetalleRemsionPergamino = " & IdDetalleRemision & ")AND (IdDetalleReciboPergamino =" & Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino") & ") "
                        StrSqlUpdate = "UPDATE [RecibosRemisionPergamino]  SET [PesoNeto] = 0 ,[IdDetalleReciboPergamino] = '" & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & "',[IdDetalleRemsionPergamino] = " & Me.TxtIdRemision.Text & "  WHERE  (IdDetalleRemsionPergamino = " & IdRemision & ") AND (IdDetalleReciboPergamino = " & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & ") "
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    Else
                        'StrSqlUpdate = " UPDATE [RecibosRemisionPergamino] SET [PesoNeto] = '" & Me.TDGridUseParc.Item(i)("PesoAplicado") & "' ,[IdDetalleReciboPergamino] = '" & Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino") & "',[IdDetalleRemsionPergamino] = " & IdDetalleRemision & "  WHERE  (IdDetalleRemsionPergamino = " & IdDetalleRemision & ")AND (IdDetalleReciboPergamino =" & Me.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino") & ") "
                        StrSqlUpdate = "UPDATE [RecibosRemisionPergamino]  SET [PesoNeto] = '" & Me.TDGridUseParc.Item(i)("PesoAplicado") & "' ,[IdDetalleReciboPergamino] = '" & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & "',[IdDetalleRemsionPergamino] = " & Me.TxtIdRemision.Text & "  WHERE  (IdDetalleRemsionPergamino = " & IdRemision & ") AND (IdDetalleReciboPergamino = " & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & ") "
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()
                    End If

                Else

                    SQLRem = "SELECT   IdDetalleRemisionPergamino, CantidadSacos, Humedad, PesoBruto, IdRemisionPergamino, IdSaco, IdEdoFisico, IdDano, IdUsuario  FROM  DetalleRemisionPergamino WHERE   (IdRemisionPergamino = '" & IdRemision & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
                    DataAdapter.Fill(DataSet, "IdDetalleRemision")

                    idReciboCafe = Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino")
                    CountDet = Me.TDBGridDetalle.RowCount
                    j = 0
                    Do While CountDet > j
                        Cadena = Me.TDBGridDetalle.Item(j)("IdDetalleReciboPergamino")
                        CadenaDiv = Cadena.Split("-")
                        max = UBound(CadenaDiv)

                        h = 0
                        TotalGrupo = 0
                        For h = 0 To max
                            If idReciboCafe = CadenaDiv(h) Then
                                IdDetalleRemision = DataSet.Tables("IdDetalleRemision").Rows(j)("IdDetalleRemisionPergamino")
                                TotalGrupo = Me.TDBGridDetalle.Item(j)("PesoNeto")  'YA ESTA SUMANDO EL TOTAL EN EL GRID DETALLE 


                                '//////////////////////////////////////BUSCO EL DETALLE DEL RECIBO A GRABAR EN LA TABLA RECIBOREMISION ///////////////
                                sql = "SELECT DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.IdReciboPergamino FROM ReciboCafePergamino INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino " & _
                                      "WHERE(ReciboCafePergamino.IdReciboPergamino = " & idReciboCafe & ")"
                                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                                DataAdapter.Fill(DataSet, "ConsultaDetalleRecibo")
                                IdDetalleRecibo = 0
                                If DataSet.Tables("ConsultaDetalleRecibo").Rows.Count <> 0 Then
                                    IdDetalleRecibo = DataSet.Tables("ConsultaDetalleRecibo").Rows(0)("IdDetalleReciboPergamino")
                                End If

                                DataSet.Tables("ConsultaDetalleRecibo").Reset()

                                '////////////////////////////////VALIDO QUE NO ESTE REPETIDO 
                                SQLRem = "SELECT  RecibosRemisionPergamino.IdReciboRemisionPergamino, RecibosRemisionPergamino.PesoNeto, RecibosRemisionPergamino.IdDetalleReciboPergamino, RecibosRemisionPergamino.IdDetalleRemsionPergamino, RecibosRemisionPergamino.IdUsuario, RecibosRemisionPergamino.Orden, RemisionPergamino.IdRemisionPergamino FROM  RemisionPergamino INNER JOIN  DetalleRemisionPergamino ON RemisionPergamino.IdRemisionPergamino = DetalleRemisionPergamino.IdRemisionPergamino INNER JOIN  RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino " & _
                                         "WHERE        (RecibosRemisionPergamino.IdDetalleRemsionPergamino = " & IdRemision & ") AND (RecibosRemisionPergamino.IdDetalleReciboPergamino = " & Me.TDGridUseParc.Item(i)("IdDetalleReciboPergamino") & ")"
                                DataAdapter = New SqlClient.SqlDataAdapter(SQLRem, MiConexion)
                                DataAdapter.Fill(DataSet, "RecibosRemision2")
                                If DataSet.Tables("RecibosRemision2").Rows.Count = 0 Then

                                    If Me.TxtIdEstadoDoc.Text = "292" Then
                                        '---------------------------------------------------------------------------------------------------------------------------------
                                        '---------------------------GUARDO RECIBOS REMISION PERGAMINO 
                                        '---------------------------------------------------------------------------------------------------------------------------------
                                        StrSqlInsert = " INSERT INTO  [RecibosRemisionPergamino] ([PesoNeto] ,[IdDetalleReciboPergamino] ,[IdDetalleRemsionPergamino],[IdUsuario],[Orden])" & _
                                                       "VALUES (0,'" & IdDetalleRecibo & "'," & IdDetalleRemision & ",'" & IdUsuario & "','" & i + 1 & "')"
                                        MiConexion.Open()
                                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                                        iResultado = ComandoUpdate.ExecuteNonQuery
                                        MiConexion.Close()

                                        '------------------------------------------------------------------------------------------------------------------
                                        '------------ACTUALIZO EL VALOR BANDERA PARA EL RECIBO Y LO MARCO COMO REMISIONADO --------------------------------
                                        '------------------------------------------------------------------------------------------------------------------
                                        sql = "UPDATE [ReciboCafePergamino] SET [Remisionado] = 'False' WHERE(IdReciboPergamino = " & idReciboCafe & ")"
                                        MiConexion.Open()
                                        ComandoUpdate = New SqlClient.SqlCommand(sql, MiConexion)
                                        iResultado = ComandoUpdate.ExecuteNonQuery
                                        MiConexion.Close()

                                    Else
                                        '---------------------------------------------------------------------------------------------------------------------------------
                                        '---------------------------GUARDO RECIBOS REMISION PERGAMINO 
                                        '---------------------------------------------------------------------------------------------------------------------------------
                                        StrSqlInsert = " INSERT INTO  [RecibosRemisionPergamino] ([PesoNeto] ,[IdDetalleReciboPergamino] ,[IdDetalleRemsionPergamino],[IdUsuario],[Orden])" & _
                                                       "VALUES ('" & Me.TDGridUseParc.Item(i)("PesoAplicado") & "','" & IdDetalleRecibo & "'," & IdDetalleRemision & ",'" & IdUsuario & "','" & i + 1 & "')"
                                        MiConexion.Open()
                                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                                        iResultado = ComandoUpdate.ExecuteNonQuery
                                        MiConexion.Close()

                                        '------------------------------------------------------------------------------------------------------------------
                                        '------------ACTUALIZO EL VALOR BANDERA PARA EL RECIBO Y LO MARCO COMO REMISIONADO --------------------------------
                                        '------------------------------------------------------------------------------------------------------------------
                                        sql = "UPDATE [ReciboCafePergamino] SET [Remisionado] = 'True' WHERE(IdReciboPergamino = " & idReciboCafe & ")"
                                        MiConexion.Open()
                                        ComandoUpdate = New SqlClient.SqlCommand(sql, MiConexion)
                                        iResultado = ComandoUpdate.ExecuteNonQuery
                                        MiConexion.Close()
                                    End If
                                End If


                                DataSet.Tables("RecibosRemision2").Reset()



                                Exit Do
                            End If
                        Next

                        j = j + 1
                    Loop

                End If

                DataSet.Tables("RecibosRemision").Reset()
                i = i + 1
            Loop



            '//////////////////////////////RECORRO LOS RECIBOS PARA GRABAR LOS REISGROS DE CARGA //////////////////////////////////////////

            Registros = TDGribListRecibos.RowCount
            i = 0
            Do While Registros > i

                NumeroCarga = IdTipoCafe & "-" & CodLugarAcopio & "-" & Me.TxtNumeroRemision.Text
                '///////////////////////////////////7BUSCO LOS DATOS DE LA RECEPCION SEGUN EL RECIBO ////////////////////////

                idReciboCafe = Me.TDGribListRecibos.Item(i)("IdReciboPergamino")
                sqlstring = "SELECT  Recepcion.*  FROM Recepcion WHERE (IdReciboPergamino = " & idReciboCafe & ") "
                DataAdapter = New SqlClient.SqlDataAdapter(sqlstring, MiConexion)
                DataAdapter.Fill(DataSet, "ConsultaRec")

                If DataSet.Tables("ConsultaRec").Rows.Count <> 0 Then
                    NumeroRecepcion = DataSet.Tables("ConsultaRec").Rows(0)("NumeroRecepcion")
                    FechaRecepcion = DataSet.Tables("ConsultaRec").Rows(0)("Fecha")
                End If

                DataSet.Tables("ConsultaRec").Reset()

                '///////////////////////////////////////////////////////HAGO EL REGISTRO DE LA CARGA /////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If i = 0 Then
                    GrabaCarga(NumeroCarga, Me.TxtIdConductor.Text, Me.TxtIdLugarAcopio.Text, Format(CDate(FechaCrg), "yyyy-MM-dd"), Me.CboEmprsPlaca.Text)
                End If


                GrabaDetalleCarga(NumeroCarga, NumeroRecepcion, Format(CDate(FechaCrg), "yyyy-MM-dd"), IdLocalidad)
                ActualizaEstadoRecepcion(NumeroRecepcion, FechaRecepcion, False, Me.TxtNumeroBoleta.Text)

                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////////////////ACTUALIZO LA TABLA REPORTA ///////////////////////////////////////////////
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                MiConexion.Close()
                StrSqlInsert = "UPDATE [Reporta] SET [NumeroBoleta] = '" & Me.TxtNumeroBoleta.Text & "' WHERE (IdReportaExistencia IN (SELECT IdReporta FROM DetalleReporta  WHERE  (NumeroRecepcion = '" & NumeroRecepcion & "')))"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
                i = i + 1
            Loop

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////////////BUSCO EL ULTIMO REGISTRO DE LLEGADA QUE NO TENGA BOLETA //////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            sqlstring = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros " & _
                        "WHERE (TipoRegistro = 'Llegada') AND (IdLugarAcopio = " & IdLocalidad & ") AND (Placa = '" & Me.CboEmpPlaca.Text & "') AND (NumeroBoleta IS NULL)"
            DataAdapter = New SqlClient.SqlDataAdapter(sqlstring, MiConexion)
            DataAdapter.Fill(DataSet, "Llegada")
            If DataSet.Tables("Llegada").Rows.Count <> 0 Then
                MiConexion.Close()
                StrSqlInsert = "UPDATE [Registros] SET [NumeroBoleta] = '" & Me.TxtNumeroBoleta.Text & "' " & _
                            "WHERE (TipoRegistro = 'Llegada') AND (IdLugarAcopio = " & Me.TxtIdLugarAcopio.Text & ") AND (Placa = '" & Me.CboEmpPlaca.Text & "') AND (NumeroBoleta IS NULL)"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

            End If



            MiConexion.Close()
            StrSqlInsert = "DELETE FROM  Intermedio WHERE(IdRemisionPergamino =" & IdRemision & ")AND (Cancelada =0)"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()




            'End If
            '_______________________________________________________________________________________________________________________________()
            'GUARDO PUNTOS INTERMEDIOS
            '_______________________________________________________________________________________________________________________________()
            sql = "SELECT * FROM  Intermedio WHERE(IdRemisionPergamino =" & IdRemision & ")AND (Cancelada =0)"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "PI")
            Registros = Me.TDBGridPuntosInter.RowCount
            i = 0
            If Me.TxtNumeroRemision.Text = "" Then
                MsgBox("Debe Poner un codigo de Remision", MsgBoxStyle.Critical, "Remision Puntos")
            Else
                If Not DataSet.Tables("PI").Rows.Count = 0 Then
                    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                    Do While Registros > i

                        '[CantidadSacosOrigen] = '" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino") & "' ,[PesoBrutoOrigen] = '" & Me.TDBGridPuntosInter.Item(i)("PesoBrutoOrigen") & "'
                        ConfirmaIntermedio = Me.TDBGridPuntosInter.Item(i)("ConfirmadoIntermedio")  '[IdRemisionPergamino] = '" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosOrigen") & "'
                        'StrSqlUpdate = "UPDATE [Intermedio]  SET  [Cancelada] = '0' WHERE (IdRemisionPergamino = '" & IdRemision & "')"  'Me.TDBGridPuntosInter.Item(i)("CantidadSacosOrigen")  Me.TDBGridPuntosInter.Item(i)("PesoBrutoOrigen")
                        StrSqlUpdate = "UPDATE [Intermedio]  SET [PesoBrutoEntrada] ='" & Me.TDBGridPuntosInter.Item(i)("PesoBrutoOrigen") & "', [CantidadSacosDestino] ='" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino") & "',[PesoBrutoDestino] = '" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino") & "' ,[Fecha] =  '" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("Fecha")), "dd/MM/yyyy  HH:mm:ss") & "' ,[FechaSalida] ='" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaSalida")), "dd/MM/yyyy HH:mm:ss") & "' ,[Cancelada] =  '0' ,[IdEmpresaTransporte] = '" & Me.TDBGridPuntosInter.Item(i)("IdEmpresaTransporte") & "' ,[IdOrigen] =  '" & Me.TDBGridPuntosInter.Item(i)("IdOrigen") & "' ,[IdDestino] = '" & Me.TDBGridPuntosInter.Item(i)("IdDestino") & "',[IdConductor] ='" & Me.TDBGridPuntosInter.Item(i)("IdConductor") & "' ,[IdVehiculo] = '" & Me.TDBGridPuntosInter.Item(i)("IdVehiculo") & "',[FechaCarga]  = '" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaCarga")), "dd/MM/yyyy HH:mm:ss") & "', [ConfirmadoIntermedio] = '" & ConfirmaIntermedio & "', [IdUsuario] = '" & IdUsuario & "', [NumeroBoleta] = '" & Me.TDBGridPuntosInter.Item(i)("NumeroBoleta") & "' WHERE (IdRemisionPergamino = " & IdRemision & ")"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                        '///////////////////////////////////////////////////////AHORA GUARDO EL DETALLE DE INTERMEDIO /////////////////////////////////////////////////
                        'StrSqlUpdate = "UPDATE [DetalleIntermadio]  SET [CantidadSacosDestino] ='" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino") & "',[PesoBrutoDestino] = '" & Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino") & "'   WHERE (IdRemisionPergamino = " & IdRemision & ")"
                        'MiConexion.Open()
                        'ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        'iResultado = ComandoUpdate.ExecuteNonQuery
                        'MiConexion.Close()
                        i = i + 1
                    Loop
                Else

                    Dim SacosOrigen As Double, PesobrutoOrigen As Double, SacosDestino As Double, PesoBrutoDestino As Double, PesoBrutoEntrada As Double



                    '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////

                Do While Registros > i

                    SacosOrigen = 0
                    PesobrutoOrigen = 0
                    SacosDestino = 0
                    PesoBrutoDestino = 0
                    PesoBrutoEntrada = 0
                    If Me.TDBGridPuntosInter.RowCount <> 0 Then
                        If Not IsDBNull(Me.TDBGridPuntosInter.Item(i)("CantidadSacosOrigen")) Then
                            SacosOrigen = Me.TDBGridPuntosInter.Item(i)("CantidadSacosOrigen")
                        End If

                        If Not IsDBNull(Me.TDBGridPuntosInter.Item(i)("PesoBrutoOrigen")) Then
                            PesobrutoOrigen = Me.TDBGridPuntosInter.Item(i)("PesoBrutoOrigen")
                        End If

                        If Not IsDBNull(Me.TDBGridPuntosInter.Item(i)("PesoBrutoDestino")) Then
                            PesoBrutoDestino = Me.TDBGridPuntosInter.Item(i)("PesoBrutoDestino")
                        End If

                        If Not IsDBNull(Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino")) Then
                            SacosDestino = Me.TDBGridPuntosInter.Item(i)("CantidadSacosDestino")
                        End If

                        If Not IsDBNull(Me.TDBGridPuntosInter.Item(i)("PesoBrutoEntrada")) Then
                            PesoBrutoEntrada = Me.TDBGridPuntosInter.Item(i)("PesoBrutoEntrada")
                        End If

                    End If

                    ConfirmaIntermedio = Me.TDBGridPuntosInter.Item(i)("ConfirmadoIntermedio")
                    StrSqlUpdate = "INSERT [Intermedio] ([CantidadSacosOrigen] ,[PesoBrutoOrigen] ,[CantidadSacosDestino],[PesoBrutoDestino],[Fecha],[FechaSalida],[Cancelada],[IdRemisionPergamino],[IdEmpresaTransporte],[IdOrigen] ,[IdDestino] ,[IdConductor],[IdVehiculo],[FechaCarga],[ConfirmadoIntermedio],[PesoBrutoEntrada],[IdUsuario],[NumeroBoleta],[Orden])" & _
                    "VALUES('" & SacosOrigen & "','" & PesobrutoOrigen & "','" & SacosDestino & "','" & PesoBrutoDestino & "','" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("Fecha")), "dd/MM/yyyy HH:mm:ss") & "','" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaSalida")), "dd/MM/yyyy HH:mm:ss") & "','0','" & IdRemision & "','" & Me.TDBGridPuntosInter.Item(i)("IdEmpresaTransporte") & "','" & Me.TDBGridPuntosInter.Item(i)("IdOrigen") & "','" & Me.TDBGridPuntosInter.Item(i)("IdDestino") & "','" & Me.TDBGridPuntosInter.Item(i)("IdConductor") & "','" & Me.TDBGridPuntosInter.Item(i)("IdVehiculo") & "','" & Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaCarga")), "dd/MM/yyyy HH:mm:ss") & "', '" & ConfirmaIntermedio & "'," & PesoBrutoEntrada & ", '" & IdUsuario & "', '" & Me.TDBGridPuntosInter.Item(i)("NumeroBoleta") & "' , " & i & ")"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()


                    '///////////////////////////////////////////////////////////////////////////////BUSCO EL ID INTERMEDIO ///////////////////////////
                    sql = "SELECT * FROM  Intermedio WHERE(IdRemisionPergamino =" & IdRemision & ")AND (Cancelada =0) AND (Orden =" & i & " ) "
                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(DataSet, "ConsultaPI")
                    If DataSet.Tables("ConsultaPI").Rows.Count <> 0 Then
                        IdIntermedio = DataSet.Tables("ConsultaPI").Rows(0)("IdIntermedio")
                    End If
                    DataSet.Tables("ConsultaPI").Reset()

                    'MiConexion.Close()
                    'StrSqlInsert = "DELETE FROM  DetalleIntermadio WHERE(IdIntermedio =" & IdIntermedio & ")"
                    'MiConexion.Open()
                    'ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                    'iResultado = ComandoUpdate.ExecuteNonQuery
                    'MiConexion.Close()

                    'If IdTipoCafe = 2 Then


                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    '////////////////////////////CON ESTA CONSULTA PRORRATEO LOS MONTOS /////////////////////////////////////////////////////////////////
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'sql = "SELECT  DetalleReciboCafePergamino.IdReciboPergamino,RecibosRemisionPergamino_1.IdReciboRemisionPergamino, RecibosRemisionPergamino_1.PesoNeto, RecibosRemisionPergamino_1.IdDetalleReciboPergamino,  RecibosRemisionPergamino_1.IdDetalleRemsionPergamino, RecibosRemisionPergamino_1.IdUsuario, RecibosRemisionPergamino_1.Orden, DetalleRemisionPergamino_1.IdRemisionPergamino, RecibosRemisionPergamino_1.PesoNeto/(SELECT SUM(RecibosRemisionPergamino.PesoNeto) AS PesoNeto  FROM RecibosRemisionPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino WHERE  (DetalleRemisionPergamino.IdRemisionPergamino = " & IdRemision & ")) AS Porciento FROM RecibosRemisionPergamino AS RecibosRemisionPergamino_1 INNER JOIN DetalleRemisionPergamino AS DetalleRemisionPergamino_1 ON RecibosRemisionPergamino_1.IdDetalleRemsionPergamino = DetalleRemisionPergamino_1.IdDetalleRemisionPergamino INNER JOIN DetalleReciboCafePergamino ON RecibosRemisionPergamino_1.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino  " & _
                    '      "WHERE(DetalleRemisionPergamino_1.IdRemisionPergamino = " & IdRemision & ") " 'AND (DetalleReciboCafePergamino.IdReciboPergamino = 98186)
                    sql = "SELECT DetalleReciboCafePergamino.IdReciboPergamino, RecibosRemisionPergamino_1.IdReciboRemisionPergamino, RecibosRemisionPergamino_1.PesoNeto, RecibosRemisionPergamino_1.IdDetalleReciboPergamino, RecibosRemisionPergamino_1.IdDetalleRemsionPergamino, RecibosRemisionPergamino_1.IdUsuario, RecibosRemisionPergamino_1.Orden, DetalleRemisionPergamino_1.IdRemisionPergamino, RecibosRemisionPergamino_1.PesoNeto /(SELECT  SUM(RecibosRemisionPergamino.PesoNeto) AS PesoNeto FROM RecibosRemisionPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino  WHERE (DetalleRemisionPergamino.IdRemisionPergamino = " & IdRemision & ")) AS Porciento, ReciboCafePergamino.Codigo FROM RecibosRemisionPergamino AS RecibosRemisionPergamino_1 INNER JOIN DetalleRemisionPergamino AS DetalleRemisionPergamino_1 ON  RecibosRemisionPergamino_1.IdDetalleRemsionPergamino = DetalleRemisionPergamino_1.IdDetalleRemisionPergamino INNER JOIN DetalleReciboCafePergamino ON RecibosRemisionPergamino_1.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino " & _
                          "WHERE(DetalleRemisionPergamino_1.IdRemisionPergamino = " & IdRemision & ")"
                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(DataSet, "ConsultaDI")
                    Contador = DataSet.Tables("ConsultaDI").Rows.Count
                    j = 0

                    Do While Contador > j
                        idReciboCafe = DataSet.Tables("ConsultaDI").Rows(j)("IdReciboPergamino")
                        IdReciboRemisionPergamino = DataSet.Tables("ConsultaDI").Rows(j)("IdReciboRemisionPergamino")
                        Porciento = DataSet.Tables("ConsultaDI").Rows(j)("Porciento")

                        '///////////////////////////////////BUSCO EL DETALLE DE LA PESADA /////////////////////////////////////////////

                        'sql = "SELECT SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoKg) AS PesoNetoKg  FROM(Detalle_Pesadas)  WHERE  (IdRemisionPergamino = " & IdRemision & ") AND (Codigo_Beams LIKE '%" & idReciboCafe & "%')"
                        'DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        'DataAdapter.Fill(DataSet, "Consulta")
                        'If DataSet.Tables("Consulta").Rows.Count <> 0 Then

                        If IdTipoCafe = 2 Then


                            CantidadBascula = 0
                            PesoBascula = 0
                            CantidadBascula = 0
                            PesoBascula = 0
                            PesoBasculaSalida = 0
                            CantidadBasculaSalida = 0
                            PesoRemisionado = 0

                            'PesoRemisionado = DataSet.Tables("ConsultaDI").Rows(j)("PesoNeto")

                            sql = "SELECT IdDetalleRemisionPergamino, CantidadSacos, Humedad, PesoBruto, IdRemisionPergamino, IdSaco, IdEdoFisico, IdDano, IdUsuario, IdDetalleReciboPergamino, Codigo, PesoNeto2, Tara, CantidadSacos2, Merma, PesoBruto2, Tara2, PesoBrutoEntrada FROM DetalleRemisionPergamino WHERE  (IdRemisionPergamino = " & IdRemision & ") AND (IdDetalleReciboPergamino = '" & idReciboCafe & "')"
                            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                            DataAdapter.Fill(DataSet, "Consulta")
                            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PesoBruto")) Then
                                    PesoRemisionado = DataSet.Tables("Consulta").Rows(0)("PesoBruto")
                                End If
                            End If
                            DataSet.Tables("Consulta").Reset()


                            iPosicionDetalle = i
                            TipoPesada = "Rec" & DataSet.Tables("ConsultaDI").Rows(j)("Codigo") & "-N" & j & "-D" & iPosicionDetalle & "-P1"
                            'TipoPesada = "Rec" & Me.TDGribListRecibos.Columns("Codigo").Text & "-N" & i & "-D" & Me.TDBGridPuntosInter.Row
                            '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                            sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') GROUP BY Cod_Productos, Descripcion_Producto"  'AND (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102))
                            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                            DataAdapter.Fill(DataSet, "Consulta")
                            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                                CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                            End If
                            DataSet.Tables("Consulta").Reset()

                            TipoPesada = "Rec" & DataSet.Tables("ConsultaDI").Rows(j)("Codigo") & "-N" & j & "-D" & iPosicionDetalle & "-P2"
                            '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                            sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & Me.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & Me.TxtNumeroRemision.Text & "') GROUP BY Cod_Productos, Descripcion_Producto"  '///////////////////////////////////modificado 22/01/2020  (Fecha = CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102))
                            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                            DataAdapter.Fill(DataSet, "Consulta")
                            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                PesoBasculaSalida = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                                CantidadBasculaSalida = DataSet.Tables("Consulta").Rows(0)("QQ")
                            End If
                            DataSet.Tables("Consulta").Reset()

                            StrSqlUpdate = "INSERT INTO DetalleIntermadio ([PesoBrutoOrigen],[CantidadSacosOrigen],[PesoBrutoDestino],[CantidadSacosDestino] ,[IdIntermedio],[IdReciboRemisionPergamino],[PesoBrutoEntrada]) " & _
                                           "VALUES (" & CDbl(PesoBascula) & ", " & CDbl(CantidadBascula) & " ," & CDbl(PesoBasculaSalida) & ", " & CDbl(CantidadBasculaSalida) & ",'" & IdIntermedio & "' , '" & IdReciboRemisionPergamino & "' ," & CDbl(PesoBrutoEntrada) & ")"

                        Else




                            sql = "SELECT IdDetalleRemisionPergamino, CantidadSacos, Humedad, PesoBruto, IdRemisionPergamino, IdSaco, IdEdoFisico, IdDano, IdUsuario, IdDetalleReciboPergamino, Codigo, PesoNeto2, Tara, CantidadSacos2, Merma, PesoBruto2, Tara2, PesoBrutoEntrada FROM DetalleRemisionPergamino WHERE  (IdRemisionPergamino = " & IdRemision & ") AND (IdDetalleReciboPergamino = '" & idReciboCafe & "')"

                            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)

                            DataAdapter.Fill(DataSet, "Consulta")
                            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                                If Not IsDBNull(DataSet.Tables("Consulta").Rows(0)("PesoBruto")) Then
                                    PesoRemisionado = DataSet.Tables("Consulta").Rows(0)("PesoBruto")
                                End If
                            End If
                            DataSet.Tables("Consulta").Reset()


                            StrSqlUpdate = "INSERT INTO DetalleIntermadio ([PesoBrutoOrigen],[CantidadSacosOrigen],[PesoBrutoDestino],[CantidadSacosDestino] ,[IdIntermedio],[IdReciboRemisionPergamino],[PesoBrutoEntrada]) " & _
                                           "VALUES (" & CDbl(PesobrutoOrigen) * Porciento & ", " & CDbl(SacosOrigen) * Porciento & " ," & CDbl(PesoBrutoDestino) * Porciento & ", " & CDbl(SacosDestino) * Porciento & ",'" & IdIntermedio & "' , '" & IdReciboRemisionPergamino & "' ," & CDbl(PesoBrutoEntrada) * Porciento & ")"
                        End If


                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                        NumeroCarga = IdTipoCafe & "-" & CodLugarAcopio & "-" & IdIntermedio
                        IdVehiculo = Me.TDBGridPuntosInter.Item(i)("IdVehiculo")
                        '///////////////////////////////////////////////////////HAGO EL REGISTRO DE LA CARGA /////////////////////////////////////////
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        sqlstring = "SELECT IdVehiculo, Placa, IdMarca, IdTipoVehiculo, IdUsuario, IdCompany, Posicion, FechaActualizacion FROM Vehiculo  WHERE (IdVehiculo = " & IdVehiculo & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(sqlstring, MiConexion)
                        DataAdapter.Fill(DataSet, "Vehiculo")
                        If DataSet.Tables("Vehiculo").Rows.Count <> 0 Then
                            Placa = DataSet.Tables("Vehiculo").Rows(0)("Placa")
                        End If
                        DataSet.Tables("Vehiculo").Reset()

                        If i = 0 Then
                            GrabaCarga(NumeroCarga, Me.TDBGridPuntosInter.Item(i)("IdConductor"), Me.TDBGridPuntosInter.Item(i)("IdOrigen"), Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaCarga")), "yyyy-MM-dd"), Placa)
                        End If


                        GrabaDetalleCarga(NumeroCarga, NumeroRecepcion, Format(CDate(Me.TDBGridPuntosInter.Item(i)("FechaCarga")), "yyyy-MM-dd"), Me.TDBGridPuntosInter.Item(i)("IdOrigen"))
                        ActualizaEstadoRecepcion(NumeroRecepcion, FechaRecepcion, False, Me.TDBGridPuntosInter.Item(i)("NumeroBoleta"))

                        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        '////////////////////////////////////////////ACTUALIZO LA TABLA REPORTA ///////////////////////////////////////////////
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        MiConexion.Close()
                        StrSqlInsert = "UPDATE [Reporta] SET [NumeroBoleta] = '" & Me.TDBGridPuntosInter.Item(i)("NumeroBoleta") & "' WHERE (IdReportaExistencia IN (SELECT IdReporta FROM DetalleReporta  WHERE  (NumeroRecepcion = '" & NumeroRecepcion & "')))"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(StrSqlInsert, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                        j = j + 1
                    Loop
                    DataSet.Tables("ConsultaDI").Reset()





                    'End If
                    i = i + 1

                Loop

                End If
            End If


            '______________________________________________________________________________________________________________________________
            'GUARDO PUNTOS INTERMEDIOS
            '_______________________________________________________________________________________________________________________________
            sql = "SELECT * FROM  Intermedio WHERE(IdRemisionPergamino =" & IdRemision & ")AND (Cancelada =0)"
            DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapter.Fill(DataSet, "DetalleIntermedio")




            Me.BtnGuardarRem.Enabled = True



            'Else
            'MsgBox("DEBE TENER AL MENOS 2 PUNTOS INTEMEDIOS Y EL DESTINO DEL ULTIMO TIENE QUE SER ")
            'Exit Sub
            'End If
            MsgBox("SE HA GUARDADO CON EXITO", MsgBoxStyle.Information, "Remision")
            If Limpiar = True Then
                LimpiarRem()
            End If
    End Sub

    Private Sub Button6_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        BtnGuardarRem_Click(sender, e)
    End Sub

    Public Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, SqlString As String
        Dim Arepremisionticket As New ArepRemisionTicket, Sqldatos As String, RutaLogo As String, IdLocalidad As Double
        Dim NumEnsambleRep As String, PrecioNeto As Double, PesoNeto As Double, TotalLiquida As Double
        Dim ArepRemisionTicketMaquila As New ArepRemisionTicketMaquila, ArepRemisionPergamino As New ArepRemisionPergamino, ArepRemisionMaquila As New ArepRemisionMaquila

        'If Me.TxtNumeroBoleta.Text = "" Then
        '    'MsgBox("El numero de Boleta no puede quedar en Blanco", MsgBoxStyle.Exclamation, "Sistema Bascula")
        '    Exit Sub
        'End If

        ''////////////////////////////////////////////////////////////////////
        ''/////////////////////////////BUSCO SI EXISTE ESTE REGISTRO /////////
        ''///////////////////////////////////////////////////////////////////////
        'SqlString = "SELECT Registros.*  FROM Registros WHERE (NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (TipoRegistro = 'Reserva')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(Dataset, "LugarAcopio")
        'If Dataset.Tables("LugarAcopio").Rows.Count <> 0 Then
        '    MsgBox("Ya existe esta boleta para su Reserva !!!!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        Me.BtnImprimir.Enabled = False

        Sqldatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqldatos, MiConexion)
        DataAdapter.Fill(Dataset, "DatosEmpresa")

        If Not Dataset.Tables("DatosEmpresa").Rows.Count = 0 Then

            Arepremisionticket.LblEncabezado.Text = Dataset.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            ArepRemisionTicketMaquila.LblEncabezado.Text = Dataset.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            If Not IsDBNull(Dataset.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = Dataset.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    Arepremisionticket.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                    ArepRemisionTicketMaquila.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If
            End If
        End If

        If Me.TxtIdRemision.Text = "" Then
            SqlString = "SELECT LugarAcopio.* FROM LugarAcopio WHERE (CodLugarAcopio = " & IdSucursal & ") AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(Dataset, "LugarAcopio")
            If Dataset.Tables("LugarAcopio").Rows.Count <> 0 Then
                IdLocalidad = Dataset.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
                CodLugarAcopio = IdSucursal
            End If

            IdLocalidad = Me.TxtIdLugarAcopio.Text

            '////////////////////////////////////BUSCO EL NUMERO DE REMISION //////////////////////////////////////////////////
            IdRemision = 0
            SqlString = "SELECT  RemisionPergamino.* FROM RemisionPergamino WHERE (Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLocalidad & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(Dataset, "BuscaRemisiones")
            If Dataset.Tables("BuscaRemisiones").Rows.Count <> 0 Then
                IdRemision = Dataset.Tables("BuscaRemisiones").Rows(0)("IdRemisionPergamino")
            End If
            Dataset.Tables("BuscaRemisiones").Reset()
        Else
            IdRemision = Me.TxtIdRemision.Text
        End If







        Arepremisionticket.IdRemision = IdRemision
        ArepRemisionTicketMaquila.IdRemision = IdRemision
        ArepRemisionPergamino.IdRemision = IdRemision
        ArepRemisionMaquila.IdRemision = IdRemision


        'Arepremisionticket.DataSet.Reset()
        'Arepremisionticket.DataSet.Tables.Add(Dataset.Tables("ListaRecibos2").Copy)
        If Me.CboTipoRemision.Text = "MAQUILA" Then
            '------------------------------------------------------------------------------------------------------------
            '------------------------------REPORTE DE MAQUILA -----------------------------------------------------------
            '------------------------------------------------------------------------------------------------------------

            ArepRemisionMaquila.LblNumeroRemision.Text = Me.TxtNumeroRemision.Text
            ArepRemisionMaquila.LblFechaOrden.Text = Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy HH:mm:ss")
            ArepRemisionMaquila.LblFechaSalida.Text = Format(Me.DTPRemFechSalid.Value, "dd/MM/yyyy HH:mm:ss")
            ArepRemisionMaquila.LblCosecha.Text = Mid(Me.LblCosecha.Text, 10)
            ArepRemisionMaquila.LblOrigen.Text = ""


            ArepRemisionMaquila.LblEmpresaTransporte.Text = Me.CboEmpresaTrans.Text
            ArepRemisionMaquila.LblPlaca.Text = Me.CboEmprsPlaca.Text
            ArepRemisionMaquila.LblMarca.Text = Me.TxtMarca.Text
            ArepRemisionMaquila.LblConductor.Text = Me.CboEmpresaCond.Text
            ArepRemisionMaquila.LblCedula.Text = Me.TxtCedula.Text
            'ArepRemisionPergamino.LblRutaLogica.Text = Me.CboLocDest.Text
            ArepRemisionMaquila.LblDestino.Text = Me.CboRemLocDest.Text
            ArepRemisionMaquila.LblDescripcion.Text = "CALIDAD:" & Me.CboCalidad.Text & "  UNIDAD DE MEDIDA KG"
            ArepRemisionMaquila.LblTipoRemision.Text = "SERVICIO DE MAQUILA"
            ArepRemisionMaquila.TxtObservaciones.Text = Me.Observaciones
            ArepRemisionMaquila.TxtOrigenRemision.Text = Me.LblSucursal.Text

            'ArepRemisionTicketMaquila.LblOrden.Text = Me.TxtNumeroRemision.Text
            'ArepRemisionTicketMaquila.LblFechaOrden.Text = Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy HH:mm")
            'ArepRemisionTicketMaquila.LblFechaSalida.Text = Format(Me.DTPRemFechSalid.Value, "dd/MM/yyyy HH:mm")
            'ArepRemisionTicketMaquila.LblCosecha.Text = Mid(Me.LblCosecha.Text, 10)
            'ArepRemisionTicketMaquila.LblLocalidad.Text = Me.LblSucursal.Text

            'ArepRemisionTicketMaquila.LblEmpresaTransporte.Text = Me.CboEmpresaTrans.Text
            'ArepRemisionTicketMaquila.LblPlaca.Text = Me.CboEmprsPlaca.Text
            'ArepRemisionTicketMaquila.LblMarca.Text = Me.TxtMarca.Text
            'ArepRemisionTicketMaquila.LblConductor.Text = Me.CboEmpresaCond.Text
            'ArepRemisionTicketMaquila.LblCedula.Text = Me.TxtCedula.Text
            'ArepRemisionTicketMaquila.LblRutaLogica.Text = Me.CboLocDest.Text
            'ArepRemisionTicketMaquila.LblDestino.Text = Me.CboRemLocDest.Text
            'ArepRemisionTicketMaquila.LblCalidad.Text = Me.CboCalidad.Text
            'ArepRemisionTicketMaquila.LblTipoRemision.Text = "Remision Cafe " & Me.CboTipoRemision.Text

        Else
            ArepRemisionPergamino.LblNumeroRemision.Text = Me.TxtNumeroRemision.Text
            ArepRemisionPergamino.LblFechaOrden.Text = Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy HH:mm:ss")
            ArepRemisionPergamino.LblFechaSalida.Text = Format(Me.DTPRemFechSalid.Value, "dd/MM/yyyy HH:mm:ss")
            ArepRemisionPergamino.LblCosecha.Text = Cosecha
            ArepRemisionPergamino.LblOrigen.Text = ""

            ArepRemisionPergamino.LblEmpresaTransporte.Text = Me.CboEmpresaTrans.Text
            ArepRemisionPergamino.TextBox12.Text = Me.CboEmprsPlaca.Text
            ArepRemisionPergamino.TextBox13.Text = Me.TxtMarca.Text
            ArepRemisionPergamino.LblConductor.Text = Me.CboEmpresaCond.Text
            ArepRemisionPergamino.LblCedula.Text = Me.TxtCedula.Text
            'ArepRemisionPergamino.LblRutaLogica.Text = Me.CboLocDest.Text
            ArepRemisionPergamino.LblDestino.Text = Me.CboRemLocDest.Text
            ArepRemisionPergamino.LblDescripcion.Text = "CALIDAD:" & Me.CboCalidad.Text & "  UNIDAD DE MEDIDA KG"
            ArepRemisionPergamino.LblTipoRemision.Text = "COMPRA DIRECTA - EXPASA"
            ArepRemisionPergamino.TxtObservaciones.Text = Me.Observaciones
            ArepRemisionPergamino.TxtOrigenRemision.Text = Me.LblSucursal.Text
            'Arepremisionticket.LblFechaOrden.Text = Format(Me.DTPRemFechCarga.Value, "dd/MM/yyyy HH:mm")
            'Arepremisionticket.LblFechaSalida.Text = Format(Me.DTPRemFechSalid.Value, "dd/MM/yyyy HH:mm")
            'Arepremisionticket.LblCosecha.Text = Mid(Me.LblCosecha.Text, 10)
            'Arepremisionticket.LblLocalidad.Text = Me.LblSucursal.Text

            'Arepremisionticket.LblEmpresaTransporte.Text = Me.CboEmpresaTrans.Text
            'Arepremisionticket.LblPlaca.Text = Me.CboEmprsPlaca.Text
            'Arepremisionticket.LblMarca.Text = Me.TxtMarca.Text
            'Arepremisionticket.LblConductor.Text = Me.CboEmpresaCond.Text
            'Arepremisionticket.LblCedula.Text = Me.TxtCedula.Text
            'Arepremisionticket.LblRutaLogica.Text = Me.CboLocDest.Text
            'Arepremisionticket.LblDestino.Text = Me.CboRemLocDest.Text
            'Arepremisionticket.LblCalidad.Text = Me.CboCalidad.Text
            'Arepremisionticket.LblTipoRemision.Text = "Remision Cafe " & Me.CboTipoRemision.Text


        End If

        Dim pd As New PrintDocument
        Dim ImpresoraRemision As String
        Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

        Impresora_Defecto = s_Default_Printer

        ImpresoraRemision = BuscaImpresora("Remision")

        Establecer_Impresora(ImpresoraRemision)



        Dim ViewerForm As New FrmViewer(), i As Integer
        If Me.CboTipoRemision.Text = "MAQUILA" Then
            
            SqlString = "SELECT  ReciboCafePergamino.AplicarRemision AS Aplicar, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal, RecibosRemisionPergamino.PesoNeto AS PesoAplicado, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara - RecibosRemisionPergamino.PesoNeto AS PesoPorAplicar, RemisionPergamino.IdRemisionPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino, DetalleReciboCafePergamino.Imperfeccion, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, Dano.IdDano, Dano.Nombre, Finca.CodFinca FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano LEFT OUTER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca  " & _
                        "WHERE(RemisionPergamino.IdRemisionPergamino = " & IdRemision & ") ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino "

            'SqlString = "SELECT ReciboCafePergamino.AplicarRemision AS Aplicar, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal, RecibosRemisionPergamino.PesoNeto AS PesoAplicado, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara - RecibosRemisionPergamino.PesoNeto AS PesoPorAplicar, RemisionPergamino.IdRemisionPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino, DetalleReciboCafePergamino.Imperfeccion, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, Dano.IdDano, Dano.Nombre, Finca.CodFinca FROM Dano INNER JOIN DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor ON Dano.IdDano = ReciboCafePergamino.IdDano INNER JOIN DetalleRemisionPergamino INNER JOIN  RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino ON ReciboCafePergamino.IdReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca " & _
            '                        "WHERE(RemisionPergamino.IdRemisionPergamino = " & IdRemision & ") ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino"
            SQL.ConnectionString = Conexion
            SQL.SQL = SqlString

            ViewerForm.s_Default_Printer = s_Default_Printer
            ViewerForm.arvMain.Document = ArepRemisionMaquila.Document
            My.Application.DoEvents()
            ArepRemisionMaquila.DataSource = SQL
            ArepRemisionMaquila.Run(False)
            'ViewerForm.arvMain.Document.Print(False, False, False)
            ViewerForm.Show()

        Else


            SqlString = "SELECT  AVG(DetalleReciboCafePergamino.Imperfeccion) AS Imperfeccion, Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleRemisionPergamino.CantidadSacos,  DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, MAX(DetalleReciboCafePergamino.Humedad) AS Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.CantidadSacos2, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2, COUNT(DetalleRemisionPergamino.IdDetalleRemisionPergamino) AS Cont, AVG(RangoImperfeccion.Minimo) AS Minimo, AVG(RangoImperfeccion.Maximo) AS Maximo FROM DetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN ReciboCafePergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN  TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino GROUP BY DetalleRemisionPergamino.IdDetalleRemisionPergamino, Dano.Nombre, EstadoFisico.Descripcion, TipoSaco.Descripcion, RangoImperfeccion.Nombre, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.CantidadSacos2, DetalleRemisionPergamino.Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2 HAVING (RemisionPergamino.IdRemisionPergamino = " & IdRemision & ") ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino"
            'SqlString = "SELECT AVG(DetalleReciboCafePergamino.Imperfeccion) AS Imperfeccion, Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, MAX(DetalleReciboCafePergamino.Humedad) AS Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.CantidadSacos2, CASE WHEN DetalleRemisionPergamino.Merma IS NULL THEN 0 ELSE DetalleRemisionPergamino.Merma END AS Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2, COUNT(DetalleRemisionPergamino.IdDetalleRemisionPergamino) AS Cont, AVG(RangoImperfeccion.Minimo) AS Minimo, AVG(RangoImperfeccion.Maximo) AS Maximo FROM ReciboCafePergamino INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN DetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino ON ReciboCafePergamino.IdReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino GROUP BY DetalleRemisionPergamino.IdDetalleRemisionPergamino, Dano.Nombre, EstadoFisico.Descripcion, TipoSaco.Descripcion, RangoImperfeccion.Nombre, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.CantidadSacos2, DetalleRemisionPergamino.Merma, DetalleRemisionPergamino.PesoBruto2, DetalleRemisionPergamino.Tara2  " & _
            '"HAVING(RemisionPergamino.IdRemisionPergamino = " & IdRemision & ") ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino"
            SQL.ConnectionString = Conexion
            SQL.SQL = SqlString

            ViewerForm.s_Default_Printer = s_Default_Printer
            ViewerForm.arvMain.Document = ArepRemisionPergamino.Document
            My.Application.DoEvents()
            'Arepremisionticket.DataSource = SQL
            'Arepremisionticket.Run(False)
            'ViewerForm.arvMain.Document.Print(False, False, False)

            ArepRemisionPergamino.DataSource = SQL
            ArepRemisionPergamino.Run(False)
            ViewerForm.Show()
            'ViewerForm.arvMain.Document.Print(False, False, False)
        End If


        Me.BtnImprimir.Enabled = True

        'Establecer_Impresora(s_Default_Printer)

        'ViewerForm.Show()

        'Quien2 = "ImprimeLiquida"
        'BtnGuardar_Click(sender, e)


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub TDBGridDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDBGridDetalle.Click

    End Sub

    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Quien = "EmpresaTransporte"
        My.Forms.FrmConsultas.IdCosecha = Me.TextIdCosecha.Text
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboEmpresaTrans.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub LblFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblFecha.Click

    End Sub

    Private Sub LblHora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblHora.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub TxtNumeroBoleta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroBoleta.TextChanged
        Dim SqlString As String, NumeroPlaca As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim idRemision As Double

        If Me.TxtNumeroBoleta.Text = "" Then
            Exit Sub
        End If


        'If Me.TxtIdRemision.Text = "" Then
        '    SqlString = "SELECT   *   FROM   RemisionPergamino  WHERE  (Codigo = '" & Me.TxtNumeroRemision.Text & "') AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdLugarAcopio = " & IdLugarAcopio & ")"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "Consulta")
        '    If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        '        idRemision = DataSet.Tables("Consulta").Rows(0)("IdRemisionPergamino")
        '    End If
        'Else
        '    idRemision = Me.TxtIdRemision.Text
        'End If

        '-----------------------------------VALIDACION SE QUITO 06-09-2019 SEGUN MARIELOS ESTO NO SE VALIDA POR QUE UNA BOLETA TIENE VARIAS REMISIONES -
        'SqlString = "SELECT  Numero_Boleta, IdRemisionPergamino  FROM RemisionPergamino WHERE (Numero_Boleta = '" & Me.TxtNumeroBoleta.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "ConsultaBoleta")
        'If Not DataSet.Tables("ConsultaBoleta").Rows.Count = 0 Then
        '    If ValidaBoleta = True Then
        '        MsgBox("Esta Boleta ya se utilizo en otra Remision", MsgBoxStyle.Critical, " Bascula ")
        '        Me.BtnGuardarRem.Enabled = False
        '        Me.BtnImprimir.Enabled = False
        '        Me.TxtNumeroBoleta.Text = ""
        '    End If
        'End If

        '//////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////BUSCAR SI EL CONDUCTOR YA REGISTRO SU LLEGADA ////////////
        '/////////////////////////////////////////////////////////////////////////////////////

        If Len(Me.TxtNumeroBoleta.Text) = 6 Then
            '***REGITRO VALIDACION 03-01-2020 LUGAR ACOPIO***
            'SqlString = "SELECT  IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta, DATEDIFF(hh, Fecha, CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS Horas FROM Registros WHERE (TipoRegistro = 'Llegada') AND (Placa = '" & NumeroPlaca & "') AND (NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "')"
            SqlString = "SELECT  Registros.IdRegistro, Registros.TipoRegistro, Registros.IdConductor, Registros.IdLugarAcopio, Registros.Fecha, Registros.Placa, Registros.IdTransporte, Registros.NumeroBoleta, DATEDIFF(hh, Registros.Fecha, CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS Horas, EmpresaTransporte.NombreEmpresa FROM  Registros INNER JOIN EmpresaTransporte ON Registros.IdConductor = EmpresaTransporte.Codigo  " & _
                        "WHERE  (Registros.TipoRegistro = 'Llegada') AND (Registros.NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (Registros.IdLugarAcopio = '" & IdLugarAcopio & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta2")
            If DataSet.Tables("Consulta2").Rows.Count = 0 Then
                MsgBox("No Existe Registro de llegada para este camion", MsgBoxStyle.Critical, " Bascula ")
                Me.BtnGuardarRem.Enabled = False
                Me.BtnImprimir.Enabled = False
            Else

                '/////////////////////////////////////////////////////////////////////////////
                '//////////////////////////SI EXISTE LA BOLETA LA LLENO DE INFORMACION //////////
                '////////////////////////////////////////////////////////////////////////////////////
                Me.CboEmprsPlaca.Text = DataSet.Tables("Consulta2").Rows(0)("Placa")
                CboEmpresaTrans.Text = DataSet.Tables("Consulta2").Rows(0)("NombreEmpresa")

                Me.TxtIdEmprTrans.Text = Me.CboEmpresaTrans.Columns(2).Text
                IdEmpresaTransporte = Me.TxtIdEmprTrans.Text

                IdEmpresaTransporte = Me.TxtIdEmprTrans.Text

                sql = "SELECT   Conductor.Nombre FROM Conductor INNER JOIN ConductorEmpresaTransporte ON Conductor.IdConductor = ConductorEmpresaTransporte.IdConductor  " & _
                      "WHERE  (ConductorEmpresaTransporte.Activo = 1) AND (ConductorEmpresaTransporte.IdEmpresaTransporte = " & IdEmpresaTransporte & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "Conduc")
                Me.CboEmpresaCond.DataSource = DataSet.Tables("Conduc")

                Me.TxtCedula.Text = ""

                If Not DataSet.Tables("Conduc").Rows.Count = 0 Then
                    Me.CboEmpresaCond.Splits.Item(0).DisplayColumns(0).Width = 270
                End If


                Me.BtnGuardarRem.Enabled = True
                Me.BtnImprimir.Enabled = False
            End If
        End If
    End Sub

    Public Sub CmdConfirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConfirma.Click
        Dim respuesta As Double, sqlupdate As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, StrSqlInsert As String

        If Me.TDGridUseParc.RowCount = 0 Then
            MsgBox("Necesita Filtrar Recibos para Grabar", MsgBoxStyle.Critical, " Remision ")
            Exit Sub
        End If

        Limpiar = True
        respuesta = MsgBox("¿Esta Seguro de Confirmar?", MsgBoxStyle.YesNo, "Sistema Bascula")
        If respuesta = 6 Then
            ConfirmadoDetalle = True
            Limpiar = False

            If Me.TxtIdRemision.Text = "" Then
                BtnGuardar_Click(sender, e)
            Else
                StrSqlUpdate = "UPDATE [RemisionPergamino] SET [ConfirmadoDetalle] = 1 WHERE(IdRemisionPergamino = " & Me.TxtIdRemision.Text & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If


            Me.CmdConfirma.Enabled = False
            Me.CmdPesada.Enabled = False
            Me.BtnFiltrar.Enabled = False

            If Me.CboEstadoDoc.Text = "Confirmado" Then
                Me.BtnImprimir.Enabled = True
            Else
                Me.BtnImprimir.Enabled = False
            End If

            MsgBox("Confirmado con Existo", MsgBoxStyle.Exclamation, "Sistema Bascula")
            'Button11_Click(sender, e)
            Limpiar = True
        End If

    End Sub

    Private Sub TxtIdLugarAcopio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIdLugarAcopio.TextChanged

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

    End Sub

    Private Sub Label58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label58.Click

    End Sub

    Private Sub Panel9_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel9.Paint

    End Sub

    Private Sub Label37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label37.Click

    End Sub

    Private Sub CboLocDest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLocDest.TextChanged
        Dim SQL As String = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (NomLugarAcopio=  '" & Me.CboLocDest.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "Destino")
        If Not DataSet.Tables("Destino").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("Destino").Rows(0)("IdLugarAcopio")) Then
                IdRutaLogica = DataSet.Tables("Destino").Rows(0)("IdLugarAcopio")
            End If
        End If
    End Sub
End Class