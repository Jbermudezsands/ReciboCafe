Public Class FrmPuntosInter
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Conductores As String, Posicion As Double, Cantidad As Double, PesoBruto As Double, iPosicionDetalle As Double, ConfirmaIntermedio As Boolean = False, NumeroTemporal As Double, IdRemisionPergamino As Double, IdOrigen As Double, IdDestino As Double
    Dim sql As String, Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, IdEmpresaTransporte As Double
    Public Sub SumaGridRecibos(ByVal Row As String)
        Dim Cont As Double, i As Double

        Cont = Me.TDGribListRecibos.RowCount
        i = 0
        Cantidad = 0
        PesoBruto = 0
        Do While Cont > i
            Me.TDGribListRecibos.Row = i
            Cantidad = Me.TDGribListRecibos.Columns("CantidadBascula").Text + Cantidad
            PesoBruto = Me.TDGribListRecibos.Columns("PesoBascula").Text + PesoBruto
            i = i + 1
        Loop

        Me.TDGribListRecibos.Row = Row + 1
    End Sub
    Public Sub SumaGridRecibosSSalida(ByVal Row As String)
        Dim Cont As Double, i As Double

        Cont = Me.TDGribListRecibosSalida.RowCount
        i = 0
        Cantidad = 0
        PesoBruto = 0
        Do While Cont > i
            Me.TDGribListRecibosSalida.Row = i
            Cantidad = Me.TDGribListRecibosSalida.Columns("CantidadBascula").Text + Cantidad
            PesoBruto = Me.TDGribListRecibosSalida.Columns("PesoBascula").Text + PesoBruto
            i = i + 1
        Loop

        Me.TDGribListRecibosSalida.Row = Row + 1
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmPuntosInter_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub FrmPuntosInter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim text As String, tamano As Integer, Dataset1 As New DataSet, DataAdapter1 As New SqlClient.SqlDataAdapter
        Dim SQLRem As String, CantidadBasculaSalida As Double, PesoBasculaSalida As Double, SacosOrigen As Double, PesoOrigen As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim i As Integer, Registros As Integer, ID As Double, IdRemision As String
        Dim idInter As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, count As Integer, iPosicion As Double = 0
        Dim oDataRow As DataRow, Cont As Double, TipoPesada As String, PesoBascula As Double, CantidadBascula As Double, CantAnterior As Double, PesoAnterior As Double
        Dim oDataRowSalida As DataRow, ODataRowDetalle As DataRow, oDataRowMerma As DataRow

        NumeroTemporal = FrmRemision2.NumeroTemporal

        '//////////////////SI NO SE HA GRABADO SE ASIGNA UN NUMERO TEMPORAL A LA PESADA /////////////
        If FrmRemision2.TxtNumeroRemision.Text = "-----0-----" Then
            Me.IdRemisionPergamino = 0
        ElseIf FrmRemision2.TxtNumeroRemision.Text = "" Then
            Me.IdRemisionPergamino = 0
        Else
            Me.IdRemisionPergamino = FrmRemision2.IdRemision
        End If
        '------------------------------------------------------------------------------------------------------------------------------
        'Mando una consulta que no retorna nada
        '------------------------------------------------------------------------------------------------------------------------------
        sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, DetalleReciboCafePergamino.Tara As PesoBruto ,DetalleReciboCafePergamino.Tara AS PesoBascula ,DetalleReciboCafePergamino.Tara AS CantidadBascula  FROM    DetalleReciboCafePergamino INNER JOIN    ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN   EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibos")
        sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, DetalleReciboCafePergamino.Tara As PesoBruto ,DetalleReciboCafePergamino.Tara AS PesoBascula ,DetalleReciboCafePergamino.Tara AS CantidadBascula  FROM    DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosSalida")
        sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, ReciboCafePergamino.Codigo As Daño , ReciboCafePergamino.Codigo As EstadoFisico, DetalleReciboCafePergamino.Tara As PesoNeto ,DetalleReciboCafePergamino.Tara AS Sacos FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosRem")
        sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, ReciboCafePergamino.Codigo As Merma FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Merma")


        'sql = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte "
        sql = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, EmpresaTransporte.IdEmpresaTransporte FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN  ContratoTransporte ON EmpresaTransporte.IdEmpresaTransporte = ContratoTransporte.IdEmpresaTransporte " & _
              "WHERE(ContratoTransporte.IdCosecha = " & My.Forms.FrmRemision2.idCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            Me.CboEmpresaTrans.DataSource = DataSet.Tables("Conductor")
        End If


        sql = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter1 = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Localidades")
        DataAdapter1.Fill(Dataset1, "LocalidadesDes")
        If DataSet.Tables("Localidades").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        Else
            Me.CboLocOrigen.DataSource = DataSet.Tables("Localidades")
        End If




        sql = "SELECT  Nombre FROM  Conductor "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Conduc")
        If Not DataSet.Tables("Conduc").Rows.Count = 0 Then
            Me.CboConductor.DataSource = DataSet.Tables("Conduc")
        End If

        If My.Forms.FrmRemision2.TDBGridPuntosInter.RowCount = 0 Then
            Me.CboLocOrigen.Text = My.Forms.FrmRemision2.LblSucursal.Text
            Me.DTPPICarga.Value = My.Forms.FrmRemision2.DTPRemFechCarga.Text
            Me.DTPPISalida.Value = My.Forms.FrmRemision2.DTPRemFechSalid.Text
            tamano = My.Forms.FrmRemision2.LblTotalCSaco.Text.Length
            Me.TxtCantSacos.Text = Mid(My.Forms.FrmRemision2.LblTotalCSaco.Text, 3, Len(My.Forms.FrmRemision2.LblTotalCSaco.Text))
            Me.TxtCantSacos.TextAlign = HorizontalAlignment.Center
            Me.TxtPIPesoBruto.Text = Mid(My.Forms.FrmRemision2.LblPesoNeto.Text, 3, Len(My.Forms.FrmRemision2.LblTotalCSaco.Text))
            Me.TxtPIPesoBruto.TextAlign = HorizontalAlignment.Center
            Me.TxtCantDest.Text = "" 'Mid(My.Forms.FrmRemision2.LblTotalCSaco.Text, 3, Len(My.Forms.FrmRemision2.LblTotalCSaco.Text))
            Me.TxtCantDest.TextAlign = HorizontalAlignment.Center
            Me.TxtPesoBrutDestino.Text = "" 'Mid(My.Forms.FrmRemision2.LblPesoBruto.Text, 3, Len(My.Forms.FrmRemision2.LblTotalCSaco.Text))
            Me.TxtPesoBrutDestino.TextAlign = HorizontalAlignment.Center
            Me.CboEmpresaTrans.Text = My.Forms.FrmRemision2.CboEmpresaTrans.Text
            text = My.Forms.FrmRemision2.CboEmprsPlaca.Text
            Me.CboEmprsPlc.Text = My.Forms.FrmRemision2.CboEmprsPlaca.Text
            Me.CboConductor.Text = My.Forms.FrmRemision2.CboEmpresaCond.Text
            Me.TxtNumeroBoleta.Text = ""

            count = 0
            count = My.Forms.FrmRemision2.TDBGridPuntosInter.RowCount
            If count > 0 Then
                Me.CboLocDest.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns(14).Text
            Else
                Me.CboLocDest.Text = My.Forms.FrmRemision2.CboRemLocDest.Text
            End If


            If FrmRemision2.CboTipoRemision.Text = "MAQUILA" Then
                Me.CmdPesada.Visible = False
                Me.Button_Pesada_Maquila.Visible = True
                Me.MaximumSize = New System.Drawing.Size(1000, 660)
                Me.MinimumSize = New System.Drawing.Size(1000, 660)
                Me.Width = 1000

                '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                Cont = My.Forms.FrmRemision2.TDGridUseParc.RowCount
                i = 0
                Do While Cont > i
                    My.Forms.FrmRemision2.TDGridUseParc.Row = i
                    CantidadBascula = 0
                    PesoBascula = 0
                    TipoPesada = "Rec" & My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text & "-N" & i & "-D" & iPosicionDetalle
                    '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                    'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                    sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto"
                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                        CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                    End If
                    DataSet.Tables("Consulta").Reset()


                    oDataRow = DataSet.Tables("ListaRecibos").NewRow
                    oDataRow("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                    oDataRow("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                    oDataRow("PesoBascula") = PesoBascula
                    oDataRow("CantidadBascula") = CantidadBascula
                    'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                    DataSet.Tables("ListaRecibos").Rows.Add(oDataRow)

                    oDataRowSalida = DataSet.Tables("ListaRecibosSalida").NewRow
                    oDataRowSalida("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                    oDataRowSalida("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                    oDataRowSalida("PesoBascula") = PesoBascula
                    oDataRowSalida("CantidadBascula") = CantidadBascula
                    'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                    DataSet.Tables("ListaRecibosSalida").Rows.Add(oDataRowSalida)



                    'ODataRowDetalle = DataSet.Tables("ListaRecibosSalida").NewRow
                    'ODataRowDetalle("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                    'ODataRowDetalle("PesoNeto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                    'ODataRowDetalle("PesoBascula") = PesoBascula
                    'ODataRowDetalle("CantidadBascula") = CantidadBascula
                    'DataSet.Tables("ListaRecibosSalida").Rows.Add(ODataRowDetalle)

                    i = i + 1
                Loop

                '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
                i = 0
                SacosOrigen = 0
                PesoOrigen = 0
                Do While Cont > i
                    'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                    ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                    ODataRowDetalle("NumeroRecibo") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Codigo")
                    ODataRowDetalle("Daño") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                    ODataRowDetalle("EstadoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                    ODataRowDetalle("Sacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos")
                    ODataRowDetalle("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                    DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)

                    oDataRowMerma = DataSet.Tables("Merma").NewRow
                    oDataRowMerma("NumeroRecibo") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Codigo")
                    oDataRowMerma("Merma") = 0
                    DataSet.Tables("Merma").Rows.Add(oDataRowMerma)

                    SacosOrigen = SacosOrigen + My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos2")
                    PesoOrigen = PesoOrigen + My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto2")

                    i = i + 1
                Loop

                Me.TDBGridMerma.DataSource = DataSet.Tables("Merma")

                Me.TxtCantSacos.Text = Format(SacosOrigen, "##,##0.00")
                Me.TxtPIPesoBruto.Text = Format(PesoOrigen, "##,##0.00")

                Me.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos")
                Me.TDGribListRecibos.Columns("PesoBascula").Caption = "Peso"
                Me.TDGribListRecibos.Columns("CantidadBascula").Caption = "Cantidad"
                Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                Me.TDGribListRecibosSalida.DataSource = DataSet.Tables("ListaRecibosSalida")
                Me.TDGribListRecibosSalida.Columns("PesoBascula").Caption = "Peso"
                Me.TDGribListRecibosSalida.Columns("CantidadBascula").Caption = "Cantidad"
                Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                Me.TDGridOrigen.DataSource = DataSet.Tables("ListaRecibosRem")
                Me.TDGridOrigen.Columns("NumeroRecibo").Caption = "Numero"
                Me.TDGridOrigen.Columns("Daño").Caption = "Categ"
                Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Daño").Width = 60
                Me.TDGridOrigen.Splits.Item(0).DisplayColumns("EstadoFisico").Width = 60
                Me.TDGridOrigen.Columns("EstadoFisico").Caption = "Estado"
                Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Sacos").Width = 60
                Me.TDGridOrigen.Columns("Sacos").NumberFormat = "##,##0.00"
                Me.TDGridOrigen.Splits.Item(0).DisplayColumns("PesoNeto").Width = 80
                Me.TDGridOrigen.Columns("PesoNeto").NumberFormat = "##,##0.00"
                Me.TDGridOrigen.Columns("PesoNeto").Caption = "PesoBruto"

                SumaGridRecibos(iPosicion)
                Me.TxtCantDest.Text = Cantidad
                Me.TxtPesoBrutDestino.Text = PesoBruto

            Else
                'Me.CmdPesada.Visible = True
                'Me.Button_Pesada_Maquila.Visible = True
                'Me.MaximumSize = New System.Drawing.Size(559, 660)
                'Me.Width = 559

                Me.CmdPesada.Visible = False
                Me.Button_Pesada_Maquila.Visible = True
                Me.MaximumSize = New System.Drawing.Size(1000, 660)
                Me.MinimumSize = New System.Drawing.Size(1000, 660)
                Me.Width = 1000

                '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
                i = 0
                Do While Cont > i
                    My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                    CantidadBascula = 0
                    PesoBascula = 0
                    'If count = 0 Then
                    '    '///////////////SIGNIFICA QUE ES EL PRIMER PUNTO INTERMEDIO //////////////////////////////////
                    '    TipoPesada = "DetalleRemision" & iPosicionDetalle
                    'Else
                    '    '/////////////////////SIGNIFICA QUE NO ES EL PRIMER REGISTRO //////////////////////////////////////
                    '    TipoPesada = "Grupo" & "-N" & i & "-D" & iPosicionDetalle
                    'End If

                    TipoPesada = "Grupo" & "-N" & i & "-D" & iPosicionDetalle
                    '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS PUNTOS INTERMEDIOS ENTRADA Y SALIDA //////////////////////////
                    'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                    sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto"
                    DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                        PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                        CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                    End If
                    DataSet.Tables("Consulta").Reset()



                    oDataRow = DataSet.Tables("ListaRecibos").NewRow
                    oDataRow("NumeroRecibo") = "Grupo " & i
                    oDataRow("PesoBruto") = 0
                    oDataRow("PesoBascula") = PesoBascula
                    oDataRow("CantidadBascula") = CantidadBascula
                    'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                    DataSet.Tables("ListaRecibos").Rows.Add(oDataRow)


                    oDataRowSalida = DataSet.Tables("ListaRecibosSalida").NewRow
                    oDataRowSalida("NumeroRecibo") = "Grupo " & i
                    oDataRowSalida("PesoBruto") = 0
                    oDataRowSalida("PesoBascula") = PesoBascula
                    oDataRowSalida("CantidadBascula") = CantidadBascula
                    'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                    DataSet.Tables("ListaRecibosSalida").Rows.Add(oDataRowSalida)

                    ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                    ODataRowDetalle("NumeroRecibo") = "Grupo " & i
                    ODataRowDetalle("Daño") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                    ODataRowDetalle("EstadoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                    ODataRowDetalle("Sacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos")
                    ODataRowDetalle("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                    DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)

                    oDataRowMerma = DataSet.Tables("Merma").NewRow
                    oDataRowMerma("NumeroRecibo") = "Grupo " & i
                    If PesoBascula > 0 Then
                        oDataRowMerma("Merma") = Format(My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto") - PesoBascula, "##,##0.00")
                    Else
                        oDataRowMerma("Merma") = 0
                    End If
                    DataSet.Tables("Merma").Rows.Add(oDataRowMerma)


                    i = i + 1
                Loop

                Me.TDBGridMerma.DataSource = DataSet.Tables("Merma")

                Me.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos")
                Me.TDGribListRecibos.Columns("NumeroRecibo").Caption = "Grupo"
                Me.TDGribListRecibos.Columns("PesoBascula").Caption = "Peso"
                Me.TDGribListRecibos.Columns("CantidadBascula").Caption = "Cantidad"
                Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                Me.TDGribListRecibosSalida.DataSource = DataSet.Tables("ListaRecibosSalida")
                Me.TDGribListRecibosSalida.Columns("NumeroRecibo").Caption = "Grupo"
                Me.TDGribListRecibosSalida.Columns("PesoBascula").Caption = "Peso"
                Me.TDGribListRecibosSalida.Columns("CantidadBascula").Caption = "Cantidad"
                Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80


                Me.TDGridOrigen.DataSource = DataSet.Tables("ListaRecibosRem")
                Me.TDGridOrigen.Columns("NumeroRecibo").Caption = "Grupo"
                Me.TDGridOrigen.Columns("Daño").Caption = "Categ"
                Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Daño").Width = 60
                Me.TDGridOrigen.Splits.Item(0).DisplayColumns("EstadoFisico").Width = 60
                Me.TDGridOrigen.Columns("EstadoFisico").Caption = "Estado"
                Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Sacos").Width = 80
                Me.TDGridOrigen.Columns("Sacos").NumberFormat = "##,##0.00"
                Me.TDGridOrigen.Splits.Item(0).DisplayColumns("PesoNeto").Width = 80
                Me.TDGridOrigen.Columns("PesoNeto").NumberFormat = "##,##0.00"
                Me.TDGridOrigen.Columns("PesoNeto").Caption = "PesoBruto"


                SumaGridRecibos(iPosicion)
                Me.TxtCantDest.Text = Cantidad
                Me.TxtPesoBrutDestino.Text = PesoBruto

            End If


        Else

            If Quien = "NuevoPunto" Then

                '///////////////////////////////////////////////////////PARA UN NUEVO PUNTO, OBTENGO LOS DATOS ANTERIORES /////////////////////////
                'My.Forms.FrmRemision2.TDBGridPuntosInter.Row = My.Forms.FrmRemision2.TDBGridPuntosInter.RowCount - 1
                iPosicion = My.Forms.FrmRemision2.TDBGridPuntosInter.RowCount - 1
                CantAnterior = My.Forms.FrmRemision2.TDBGridPuntosInter.Item(iPosicion)("CantidadSacosDestino")
                PesoAnterior = My.Forms.FrmRemision2.TDBGridPuntosInter.Item(iPosicion)("PesoBrutoDestino")



                'My.Forms.FrmRemision2.TDBGridPuntosInter.Row = iPosicion

                Me.DTPPICarga.Value = My.Forms.FrmRemision2.TDBGridPuntosInter.Item(iPosicion)("FechaCarga")
                Me.DTPPIEntrada.Value = My.Forms.FrmRemision2.TDBGridPuntosInter.Item(iPosicion)("Fecha")
                Me.DTPPISalida.Value = My.Forms.FrmRemision2.TDBGridPuntosInter.Item(iPosicion)("FechaSalida")
                Me.Origen.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Item(iPosicion)("IdDestino")
                Me.CboLocOrigen.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Item(iPosicion)("destino")
                Me.TxtCantSacos.Text = CantAnterior
                Me.TxtPIPesoBruto.Text = PesoAnterior
                Me.TxtCantDest.Text = ""
                Me.TxtPesoBrutDestino.Text = ""
                Me.TxtNumeroBoleta.Text = ""

                If FrmRemision2.CboTipoRemision.Text = "MAQUILA" Then
                    Me.CmdPesada.Visible = False
                    Me.Button_Pesada_Maquila.Visible = True
                    Me.MaximumSize = New System.Drawing.Size(1000, 660)
                    Me.MinimumSize = New System.Drawing.Size(1000, 660)
                    Me.Width = 1000

                    '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                    Cont = My.Forms.FrmRemision2.TDGridUseParc.RowCount
                    i = 0
                    Do While Cont > i
                        My.Forms.FrmRemision2.TDGridUseParc.Row = i
                        CantidadBascula = 0
                        PesoBascula = 0
                        TipoPesada = "Rec" & My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text & "-N" & i & "-D" & iPosicionDetalle
                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (FechaCarga = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                        End If
                        DataSet.Tables("Consulta").Reset()


                        oDataRow = DataSet.Tables("ListaRecibos").NewRow
                        oDataRow("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                        oDataRow("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                        oDataRow("PesoBascula") = PesoBascula
                        oDataRow("CantidadBascula") = CantidadBascula
                        'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        DataSet.Tables("ListaRecibos").Rows.Add(oDataRow)

                        oDataRowSalida = DataSet.Tables("ListaRecibosSalida").NewRow
                        oDataRowSalida("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                        oDataRowSalida("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                        oDataRowSalida("PesoBascula") = PesoBascula
                        oDataRowSalida("CantidadBascula") = CantidadBascula
                        'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        DataSet.Tables("ListaRecibosSalida").Rows.Add(oDataRowSalida)

                        ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                        ODataRowDetalle("NumeroRecibo") = "Grupo " & i
                        ODataRowDetalle("Daño") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                        ODataRowDetalle("EstadoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                        ODataRowDetalle("Sacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos")
                        ODataRowDetalle("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                        DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)


                        DataSet.Tables("Consulta").Reset()
                        i = i + 1
                    Loop

                    Me.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos")
                    Me.TDGribListRecibos.Columns("PesoBascula").Caption = "Peso"
                    Me.TDGribListRecibos.Columns("CantidadBascula").Caption = "Cantidad"
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                    Me.TDGribListRecibosSalida.DataSource = DataSet.Tables("ListaRecibosSalida")
                    Me.TDGribListRecibosSalida.Columns("PesoBascula").Caption = "Peso"
                    Me.TDGribListRecibosSalida.Columns("CantidadBascula").Caption = "Cantidad"
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                    Me.TDGridOrigen.DataSource = DataSet.Tables("ListaRecibosRem")
                    Me.TDGridOrigen.Columns("NumeroRecibo").Caption = "Grupo"
                    Me.TDGridOrigen.Columns("Daño").Caption = "Categ"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Daño").Width = 60
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("EstadoFisico").Width = 60
                    Me.TDGridOrigen.Columns("EstadoFisico").Caption = "Estado"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Sacos").Width = 80
                    Me.TDGridOrigen.Columns("Sacos").NumberFormat = "##,##0.00"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("PesoNeto").Width = 80
                    Me.TDGridOrigen.Columns("PesoNeto").NumberFormat = "##,##0.00"
                    Me.TDGridOrigen.Columns("PesoNeto").Caption = "PesoBruto"

                    SumaGridRecibos(iPosicion)
                    Me.TxtCantDest.Text = Cantidad
                    Me.TxtPesoBrutDestino.Text = PesoBruto

                Else   '''''EN CASO QUE SE PERGAMINO -----------------------------------------------------------------------------
                    'Me.CmdPesada.Visible = True
                    'Me.Button_Pesada_Maquila.Visible = True
                    'Me.MaximumSize = New System.Drawing.Size(559, 660)
                    'Me.Width = 559

                    Me.CmdPesada.Visible = False
                    Me.Button_Pesada_Maquila.Visible = True
                    Me.MaximumSize = New System.Drawing.Size(1000, 660)
                    Me.MinimumSize = New System.Drawing.Size(1000, 660)
                    Me.Width = 1000

                    '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                    Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
                    i = 0

                    SacosOrigen = 0
                    PesoOrigen = 0
                    Do While Cont > i
                        My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                        CantidadBascula = 0
                        PesoBascula = 0

                        TipoPesada = "Grupo" & "-N" & i & "-D" & iPosicionDetalle
                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (FechaCarga = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                        End If
                        DataSet.Tables("Consulta").Reset()


                        oDataRow = DataSet.Tables("ListaRecibos").NewRow
                        oDataRow("NumeroRecibo") = "Grupo " & i
                        oDataRow("PesoBruto") = 0
                        oDataRow("PesoBascula") = PesoBascula
                        oDataRow("CantidadBascula") = CantidadBascula
                        'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        DataSet.Tables("ListaRecibos").Rows.Add(oDataRow)


                        oDataRowSalida = DataSet.Tables("ListaRecibosSalida").NewRow
                        oDataRowSalida("NumeroRecibo") = "Grupo " & i
                        oDataRowSalida("PesoBruto") = 0
                        oDataRowSalida("PesoBascula") = PesoBascula
                        oDataRowSalida("CantidadBascula") = CantidadBascula
                        'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        DataSet.Tables("ListaRecibosSalida").Rows.Add(oDataRowSalida)

                        oDataRow = DataSet.Tables("Merma").NewRow
                        oDataRow("NumeroRecibo") = "Grupo " & i
                        If PesoBascula > 0 Then
                            oDataRow("Merma") = Format(CDbl(My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto")) - CDbl(PesoBascula), "##,##0.00")
                        Else
                            oDataRow("Merma") = 0
                        End If
                        DataSet.Tables("Merma").Rows.Add(oDataRow)

                        '/////////////////////////////////////////////////////////////////////////////////////////////////////
                        '///////////////////////BUSCO LAS PESADAS DEL PUNTO INTERMEDIO ANTERIOR /////////////////////////////
                        '///////////////////////////////////////////////////////////////////////////////////////////////////////
                        DataSet.Tables("Consulta").Reset()
                        CantidadBasculaSalida = 0
                        PesoBasculaSalida = 0
                        'TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & iPosicionDetalle & "-P2"
                        TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & My.Forms.FrmRemision2.TDBGridPuntosInter.RowCount - 1 & "-P2"
                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        'sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "')  AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto" 'AND (FechaCarga = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102))


                        sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                            PesoBasculaSalida = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                            CantidadBasculaSalida = DataSet.Tables("Consulta").Rows(0)("QQ")
                        End If


                        ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                        ODataRowDetalle("NumeroRecibo") = "Grupo " & i
                        ODataRowDetalle("Daño") = ""
                        ODataRowDetalle("EstadoFisico") = ""
                        ODataRowDetalle("Sacos") = CantidadBasculaSalida
                        ODataRowDetalle("PesoNeto") = PesoBasculaSalida
                        DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)

                        SacosOrigen = SacosOrigen + CantidadBasculaSalida
                        PesoOrigen = PesoOrigen + PesoBasculaSalida

                        DataSet.Tables("Consulta").Reset()
                        i = i + 1
                    Loop

                    Me.TxtCantSacos.Text = Format(SacosOrigen, "##,##0.00")
                    Me.TxtPIPesoBruto.Text = Format(PesoOrigen, "##,##0.00")

                    Me.TDBGridMerma.DataSource = DataSet.Tables("Merma")

                    Me.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos")
                    Me.TDGribListRecibos.Columns("NumeroRecibo").Caption = "Grupo"
                    Me.TDGribListRecibos.Columns("PesoBascula").Caption = "Peso"
                    Me.TDGribListRecibos.Columns("CantidadBascula").Caption = "Cantidad"
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                    Me.TDGribListRecibosSalida.DataSource = DataSet.Tables("ListaRecibosSalida")
                    Me.TDGribListRecibosSalida.Columns("NumeroRecibo").Caption = "Grupo"
                    Me.TDGribListRecibosSalida.Columns("PesoBascula").Caption = "Peso"
                    Me.TDGribListRecibosSalida.Columns("CantidadBascula").Caption = "Cantidad"
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80


                    Me.TDGridOrigen.DataSource = DataSet.Tables("ListaRecibosRem")
                    Me.TDGridOrigen.Columns("NumeroRecibo").Caption = "Grupo"
                    Me.TDGridOrigen.Columns("Daño").Caption = "Categ"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Daño").Width = 60
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Daño").Visible = False
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("EstadoFisico").Width = 60
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("EstadoFisico").Visible = False
                    Me.TDGridOrigen.Columns("EstadoFisico").Caption = "Estado"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Sacos").Width = 80
                    Me.TDGridOrigen.Columns("Sacos").NumberFormat = "##,##0.00"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("PesoNeto").Width = 80
                    Me.TDGridOrigen.Columns("PesoNeto").NumberFormat = "##,##0.00"
                    Me.TDGridOrigen.Columns("PesoNeto").Caption = "PesoBruto"


                    SumaGridRecibos(iPosicion)
                    Me.TxtCantDest.Text = Cantidad
                    Me.TxtPesoBrutDestino.Text = PesoBruto

                End If

            ElseIf Quien = "EditarPunto" Then






                iPosicion = My.Forms.FrmRemision2.TDBGridPuntosInter.RowCount - 1
                My.Forms.FrmRemision2.TDBGridPuntosInter.Row = iPosicion

                sql = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1) AND (IdLugarAcopio = " & IdOrigen & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "Origen")
                If DataSet.Tables("Origen").Rows.Count = 0 Then
                    MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
                Else
                    Me.CboLocOrigen.Text = DataSet.Tables("Origen").Rows(0)("NomLugarAcopio")
                End If

                sql = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1) AND (IdLugarAcopio = " & IdDestino & ")"
                DataAdapter1 = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter1.Fill(DataSet, "Destino")
                If DataSet.Tables("Destino").Rows.Count = 0 Then
                    MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
                Else
                    Me.CboLocDest.Text = DataSet.Tables("Destino").Rows(0)("NomLugarAcopio")
                End If


                Me.DTPPICarga.Value = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaCarga").Text
                Me.DTPPIEntrada.Value = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Fecha").Text
                Me.DTPPISalida.Value = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaSalida").Text
                Me.Origen.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdDestino").Text
                'Me.CboLocOrigen.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("destino").Text

                '///////////////////////////////////////LLENO LA INFORMACION BASICA PARA EDITAR ////////////////////////////
                Me.Origen.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdOrigen").Text
                'Me.CboLocOrigen.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NomLugarAcopioOrigen").Text
                Me.TxtCantSacos.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Text
                Me.TxtPIPesoBruto.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Text
                Me.Empresa.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdEmpresaTransporte").Text
                Me.CboEmpresaTrans.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NombreEmpresa").Text
                Me.vehiculo.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdVehiculo").Text
                Me.CboEmprsPlc.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Placa").Text
                Me.conductor.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdConductor").Text
                Me.CboConductor.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Nombre").Text
                Me.destino.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdDestino").Text
                'Me.CboLocDest.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Destino").Text
                Me.TxtCantDest.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("CantidadSacosDestino").Text
                Me.TxtPesoBrutDestino.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoDestino").Text
                Me.TxtNumeroBoleta.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NumeroBoleta").Text

                If FrmRemision2.CboTipoRemision.Text = "MAQUILA" Then
                    Me.CmdPesada.Visible = False
                    Me.Button_Pesada_Maquila.Visible = True
                    Me.MaximumSize = New System.Drawing.Size(1000, 660)
                    Me.MinimumSize = New System.Drawing.Size(1000, 660)
                    Me.Width = 1000

                    '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                    Cont = My.Forms.FrmRemision2.TDGridUseParc.RowCount
                    i = 0
                    Do While Cont > i
                        My.Forms.FrmRemision2.TDGridUseParc.Row = i
                        CantidadBascula = 0
                        PesoBascula = 0
                        TipoPesada = "Rec" & My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text & "-N" & i & "-D" & iPosicionDetalle & "-P1"
                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                        End If
                        DataSet.Tables("Consulta").Reset()


                        oDataRow = DataSet.Tables("ListaRecibos").NewRow
                        oDataRow("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                        oDataRow("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                        oDataRow("PesoBascula") = PesoBascula
                        oDataRow("CantidadBascula") = CantidadBascula
                        'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        DataSet.Tables("ListaRecibos").Rows.Add(oDataRow)


                        oDataRow = DataSet.Tables("Merma").NewRow
                        oDataRow("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                        oDataRow("Merma") = Format(CDbl(My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")) - CDbl(PesoBascula), "##,##0.00")
                        DataSet.Tables("Merma").Rows.Add(oDataRow)

                        SumaGridRecibos(iPosicion)
                        CantidadBascula = 0
                        PesoBascula = 0

                        TipoPesada = "Rec" & My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text & "-N" & i & "-D" & iPosicionDetalle & "-P2"
                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto"
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                        End If
                        DataSet.Tables("Consulta").Reset()
                        SumaGridRecibos(iPosicion)

                        oDataRowSalida = DataSet.Tables("ListaRecibosSalida").NewRow
                        oDataRowSalida("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                        oDataRowSalida("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                        oDataRowSalida("PesoBascula") = PesoBascula
                        oDataRowSalida("CantidadBascula") = CantidadBascula
                        'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        DataSet.Tables("ListaRecibosSalida").Rows.Add(oDataRowSalida)
                        SumaGridRecibosSSalida(iPosicion)


                        ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                        ODataRowDetalle("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                        ODataRowDetalle("Daño") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                        ODataRowDetalle("EstadoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                        ODataRowDetalle("Sacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos")
                        ODataRowDetalle("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                        DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)

                        i = i + 1
                    Loop

                    Me.TDBGridMerma.DataSource = DataSet.Tables("Merma")

                    Me.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos")
                    Me.TDGribListRecibos.Columns("PesoBascula").Caption = "Peso"
                    Me.TDGribListRecibos.Columns("CantidadBascula").Caption = "Cantidad"
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                    Me.TDGribListRecibosSalida.DataSource = DataSet.Tables("ListaRecibosSalida")
                    Me.TDGribListRecibosSalida.Columns("PesoBascula").Caption = "Peso"
                    Me.TDGribListRecibosSalida.Columns("CantidadBascula").Caption = "Cantidad"
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                    Me.TDGridOrigen.DataSource = DataSet.Tables("ListaRecibosRem")
                    Me.TDGridOrigen.Columns("NumeroRecibo").Caption = "Rec"
                    Me.TDGridOrigen.Columns("Daño").Caption = "Categ"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Daño").Width = 60
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("EstadoFisico").Width = 60
                    Me.TDGridOrigen.Columns("EstadoFisico").Caption = "Estado"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Sacos").Width = 80
                    Me.TDGridOrigen.Columns("Sacos").NumberFormat = "##,##0.00"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("PesoNeto").Width = 80
                    Me.TDGridOrigen.Columns("PesoNeto").NumberFormat = "##,##0.00"
                    Me.TDGridOrigen.Columns("PesoNeto").Caption = "PesoBruto"

                    SumaGridRecibos(iPosicion)
                    Me.TxtCantDest.Text = Cantidad
                    Me.TxtPesoBrutDestino.Text = PesoBruto

                Else

                    '///////////////////////////EDITAR PUNTOS INTERMEDIOS PERGAMINO ////////////////////////////////////////


                    Me.CmdPesada.Visible = False
                    Me.Button_Pesada_Maquila.Visible = True
                    Me.MaximumSize = New System.Drawing.Size(1000, 660)
                    Me.MinimumSize = New System.Drawing.Size(1000, 660)
                    Me.Width = 1000

                    '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                    Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
                    i = 0
                    Do While Cont > i
                        My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                        CantidadBascula = 0
                        PesoBascula = 0
                        TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & iPosicionDetalle & "-P1"
                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto" 'AND (FechaCarga = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102))
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                        End If
                        DataSet.Tables("Consulta").Reset()


                        oDataRow = DataSet.Tables("ListaRecibos").NewRow
                        oDataRow("NumeroRecibo") = "Grupo " & i
                        oDataRow("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                        oDataRow("PesoBascula") = PesoBascula
                        oDataRow("CantidadBascula") = CantidadBascula
                        'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        DataSet.Tables("ListaRecibos").Rows.Add(oDataRow)

                        oDataRow = DataSet.Tables("Merma").NewRow
                        oDataRow("NumeroRecibo") = "Grupo " & i
                        oDataRow("Merma") = Format(CDbl(My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto")) - CDbl(PesoBascula), "##,##0.00")
                        DataSet.Tables("Merma").Rows.Add(oDataRow)


                        SumaGridRecibos(iPosicion)

                        CantidadBascula = 0
                        PesoBascula = 0
                        TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & iPosicionDetalle & "-P2"
                        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                        sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "')  AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemisionPergamino & "') GROUP BY Cod_Productos, Descripcion_Producto" 'AND (FechaCarga = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102))
                        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                        DataAdapter.Fill(DataSet, "Consulta")
                        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                        End If
                        DataSet.Tables("Consulta").Reset()

                        oDataRowSalida = DataSet.Tables("ListaRecibosSalida").NewRow
                        oDataRowSalida("NumeroRecibo") = "Grupo " & i
                        oDataRowSalida("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                        oDataRowSalida("PesoBascula") = PesoBascula
                        oDataRowSalida("CantidadBascula") = CantidadBascula
                        'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        DataSet.Tables("ListaRecibosSalida").Rows.Add(oDataRowSalida)

                        SumaGridRecibosSSalida(iPosicion)


                        ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                        ODataRowDetalle("NumeroRecibo") = "Grupo " & i
                        ODataRowDetalle("Daño") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                        ODataRowDetalle("EstadoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                        ODataRowDetalle("Sacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos")
                        ODataRowDetalle("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                        DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)

                        i = i + 1
                    Loop

                    Me.TDBGridMerma.DataSource = DataSet.Tables("Merma")

                    Me.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos")
                    Me.TDGribListRecibos.Columns("NumeroRecibo").Caption = "Grupo"
                    Me.TDGribListRecibos.Columns("PesoBascula").Caption = "Peso"
                    Me.TDGribListRecibos.Columns("CantidadBascula").Caption = "Cantidad"
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                    Me.TDGribListRecibos.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                    Me.TDGribListRecibosSalida.DataSource = DataSet.Tables("ListaRecibosSalida")
                    Me.TDGribListRecibosSalida.Columns("NumeroRecibo").Caption = "Grupo"
                    Me.TDGribListRecibosSalida.Columns("PesoBascula").Caption = "Peso"
                    Me.TDGribListRecibosSalida.Columns("CantidadBascula").Caption = "Cantidad"
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBruto").Visible = False
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("PesoBascula").Width = 80
                    Me.TDGribListRecibosSalida.Splits.Item(0).DisplayColumns("CantidadBascula").Width = 80

                    Me.TDGridOrigen.DataSource = DataSet.Tables("ListaRecibosRem")
                    Me.TDGridOrigen.Columns("NumeroRecibo").Caption = "Grupo"
                    Me.TDGridOrigen.Columns("Daño").Caption = "Categ"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Daño").Width = 60
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("EstadoFisico").Width = 60
                    Me.TDGridOrigen.Columns("EstadoFisico").Caption = "Estado"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("Sacos").Width = 80
                    Me.TDGridOrigen.Columns("Sacos").NumberFormat = "##,##0.00"
                    Me.TDGridOrigen.Splits.Item(0).DisplayColumns("PesoNeto").Width = 80
                    Me.TDGridOrigen.Columns("PesoNeto").NumberFormat = "##,##0.00"
                    Me.TDGridOrigen.Columns("PesoNeto").Caption = "PesoBruto"

                    SumaGridRecibos(iPosicion)
                    Me.TxtCantDest.Text = Cantidad
                    Me.TxtPesoBrutDestino.Text = PesoBruto

                End If


            End If



        End If


        'If Quien = "EditarPunto" Then

        'End If

        SumaGridRecibos(0)
        Me.TxtPesoBrutDestino.Text = PesoBruto
        Me.TxtCantDest.Text = Cantidad
        Me.TxtPBEntrada.Text = PesoBruto
        Me.TxtCantidadEntrada.Text = Cantidad
        Me.TxtCantSacos.Text = Cantidad
        Me.TxtPIPesoBruto.Text = PesoBruto
        Me.TDGribListRecibos.Row = 0

        SumaGridRecibosSSalida(0)
        Me.TxtPesoBrutDestino.Text = PesoBruto
        Me.TxtCantDest.Text = Cantidad
        Me.TxtCantidadSalida.Text = Cantidad
        Me.TxtPBSalida.Text = PesoBruto

        TDGribListRecibosSalida.Row = 0


        If Me.ConfirmaIntermedio = True Then
            Me.CmdPesada.Enabled = False
            Me.CmdConfirma.Enabled = False
            Me.Button_Pesada_Maquila_Salida.Enabled = False
            Button_Pesada_Maquila.Enabled = False
            Me.BtnGuardarPInter.Enabled = False
        Else
            Me.CmdPesada.Enabled = True
            Me.CmdConfirma.Enabled = True
            Me.Button_Pesada_Maquila_Salida.Enabled = True
            Button_Pesada_Maquila.Enabled = True
            Me.BtnGuardarPInter.Enabled = True
        End If
    End Sub
    Private Sub CboEmpresaTrans_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmpresaTrans.TextChanged
        Dim SqlString As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlString = "SELECT IdEmpresaTransporte FROM EmpresaTransporte WHERE (NombreEmpresa = '" & Me.CboEmpresaTrans.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "idEmpresa")
        If Not Dataset.Tables("idEmpresa").Rows.Count = 0 Then
            If Not IsDBNull(Dataset.Tables("idEmpresa").Rows(0)("IdEmpresaTransporte")) Then
                Me.Empresa.Text = Dataset.Tables("idEmpresa").Rows(0)("IdEmpresaTransporte")
                IdEmpresaTransporte = Dataset.Tables("idEmpresa").Rows(0)("IdEmpresaTransporte")
            End If
        End If
        '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo  " & _
        "WHERE (EmpresaTransporte.NombreEmpresa = '" & Me.CboEmpresaTrans.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Placa")
        Me.CboEmprsPlc.DataSource = Dataset.Tables("Placa")
        Me.CboEmprsPlc.Splits.Item(0).DisplayColumns(0).Width = 90
        Me.CboEmprsPlc.Text = My.Forms.FrmRemision2.CboEmpPlaca.Text

        '////////////////////////////////////////////////////////LLENO EL COMBO DE DESTINO //////////////////////////////////////////////////77
        SqlString = "SELECT DISTINCT  LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio FROM  EmpresaTransporte INNER JOIN  VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN  ContratoTransporte ON EmpresaTransporte.IdEmpresaTransporte = ContratoTransporte.IdEmpresaTransporte INNER JOIN  RutasLogicasTransporte ON ContratoTransporte.IdContratoTransporte = RutasLogicasTransporte.IdContratoTransporte INNER JOIN LugarAcopio ON RutasLogicasTransporte.IdLugarAcopioDestino = LugarAcopio.IdLugarAcopio  " & _
                    "WHERE (ContratoTransporte.IdCosecha = " & My.Forms.FrmRemision2.TextIdCosecha.Text & ") AND (RutasLogicasTransporte.IdLugarAcopioOrigen = " & My.Forms.FrmRemision2.TxtIdLugarAcopio.Text & ") AND (EmpresaTransporte.IdEmpresaTransporte = " & Me.Empresa.Text & ") "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "LocalidadesDes")
        Me.CboLocDest.DataSource = Dataset.Tables("LocalidadesDes")
        If Dataset.Tables("LocalidadesDes").Rows.Count > 0 Then
            Me.CboLocDest.Text = Dataset.Tables("LocalidadesDes").Rows(0)("NomLugarAcopio")
        End If


        sql = "SELECT   Conductor.Nombre FROM Conductor INNER JOIN ConductorEmpresaTransporte ON Conductor.IdConductor = ConductorEmpresaTransporte.IdConductor  " & _
              "WHERE  (ConductorEmpresaTransporte.Activo = 1) AND (ConductorEmpresaTransporte.IdEmpresaTransporte = " & IdEmpresaTransporte & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(Dataset, "Conduc")
        Me.CboConductor.DataSource = Dataset.Tables("Conduc")


        If Not Dataset.Tables("Conduc").Rows.Count = 0 Then
            Me.CboConductor.Splits.Item(0).DisplayColumns(0).Width = 270
        End If

    End Sub
    Private Sub BtnGuardarPInter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarPInter.Click
        Dim SQLRem As String, Contador As Integer
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim i As Integer, Registros As Integer, ID As Double, IdRemision As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, count As Integer
        Dim FechaCrg As String, sql2 As String, FechaSal As String, MONTO As Double, PesoBrutoEntrada As Double


        If Len(Me.TxtNumeroBoleta.Text) <> 6 Then
            MsgBox("El Numero de Boleta debe ser de 6 Digitos", MsgBoxStyle.Critical, "Puntos Intermedios")
            Exit Sub
        End If

        '////////////////////////////////////////////////////////////////////////////////////////////////////
        count = Me.TDGridOrigen.RowCount
        i = 0
        PesoBrutoEntrada = 0
        Do While count > i
            PesoBrutoEntrada = PesoBrutoEntrada + Me.TDGridOrigen.Item(i)("PesoNeto")
            i = i + 1
        Loop

        If Me.CboLocOrigen.Text = "" Or Me.CboConductor.Text = "" Or Me.CboEmpresaTrans.Text = "" Or Me.CboEmprsPlc.Text = "" Or Me.CboLocDest.Text = "" Or Me.TxtCantSacos.Text = "" Or Me.TxtPIPesoBruto.Text = "" Or Me.TxtCantDest.Text = "" Or Me.TxtPesoBrutDestino.Text = "" Then

            'Registros = Me.TDGribListRecibosSalida.RowCount
            'If Not Registros = 0 Then
            '    'MsgBox("Uno de los campos esta vacio", MsgBoxStyle.Critical, "")
            'Else



            My.Forms.FrmRemision2.TDBGridPuntosInter.Row = Posicion
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaCarga").NumberFormat = "dd/MM/yyyy HH:mm:ss"
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaCarga").Text = Me.DTPPICarga.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Fecha").NumberFormat = "dd/MM/yyyy HH:mm:ss"
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Fecha").Text = Me.DTPPIEntrada.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaSalida").NumberFormat = "dd/MM/yyyy HH:mm:ss"
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaSalida").Text = Me.DTPPISalida.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdOrigen").Text = Me.Origen.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NomLugarAcopioOrigen").Text = Me.CboLocOrigen.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Text = Me.TxtCantidadEntrada.Text   'Me.TxtCantSacos.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Text = Me.TxtPBEntrada.Text  'Me.TxtPIPesoBruto.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdEmpresaTransporte").Text = Me.Empresa.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NombreEmpresa").Text = Me.CboEmpresaTrans.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdVehiculo").Text = Me.vehiculo.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Placa").Text = Me.CboEmprsPlc.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdConductor").Text = Me.conductor.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Nombre").Text = Me.CboConductor.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdDestino").Text = Me.destino.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Destino").Text = Me.CboLocDest.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("CantidadSacosDestino").Text = Me.TxtCantDest.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoDestino").NumberFormat = "##,##0.0000"
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoDestino").Text = Me.TxtPesoBrutDestino.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("ConfirmadoIntermedio").Text = ConfirmaIntermedio
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NumeroBoleta").Text = Me.TxtNumeroBoleta.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoEntrada").Text = PesoBrutoEntrada
            Me.Close()
            'End If
        Else

            My.Forms.FrmRemision2.TDBGridPuntosInter.Row = Posicion
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaCarga").NumberFormat = "dd/MM/yyyy HH:mm:ss"
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaCarga").Text = Me.DTPPICarga.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Fecha").NumberFormat = "dd/MM/yyyy HH:mm:ss"
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Fecha").Text = Me.DTPPIEntrada.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaSalida").NumberFormat = "dd/MM/yyyy HH:mm:ss"
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("FechaSalida").Text = Me.DTPPISalida.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdOrigen").Text = Me.Origen.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NomLugarAcopioOrigen").Text = Me.CboLocOrigen.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("CantidadSacosOrigen").Text = Me.TxtCantidadEntrada.Text   'Me.TxtCantSacos.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoOrigen").Text = Me.TxtPBEntrada.Text  'Me.TxtPIPesoBruto.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdEmpresaTransporte").Text = Me.Empresa.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NombreEmpresa").Text = Me.CboEmpresaTrans.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdVehiculo").Text = Me.vehiculo.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Placa").Text = Me.CboEmprsPlc.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdConductor").Text = Me.conductor.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Nombre").Text = Me.CboConductor.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("IdDestino").Text = Me.destino.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("Destino").Text = Me.CboLocDest.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("CantidadSacosDestino").Text = Me.TxtCantDest.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoDestino").NumberFormat = "##,##0.0000"
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoDestino").Text = Me.TxtPesoBrutDestino.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("ConfirmadoIntermedio").Text = ConfirmaIntermedio
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("NumeroBoleta").Text = Me.TxtNumeroBoleta.Text
            My.Forms.FrmRemision2.TDBGridPuntosInter.Columns("PesoBrutoEntrada").Text = PesoBrutoEntrada
            Me.Close()
        End If



        My.Forms.FrmRemision2.BtnGuardar_Click(sender, e)
        'My.Forms.FrmRemision2.Button11_Click(sender, e)
    End Sub
    Private Sub CboLocOrigen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLocOrigen.TextChanged
        Dim SQL As String = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1 and NomLugarAcopio = '" & Me.CboLocOrigen.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "LugarAcopio")
        If Not DataSet.Tables("LugarAcopio").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")) Then
                Me.Origen.Text = DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
            End If

            '------------------------------------------------------------------------------------------------
            '---------------CARGO EL REGISTRO DE LAS EMPRESAS DE TRANSPORTE ----------------------------------
            '-----------------------------------------------------------------------------------------------------
            'SQL = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte "
            SQL = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, EmpresaTransporte.IdEmpresaTransporte, ContratoTransporte.IdCosecha,  RutasLogicasTransporte.IdLugarAcopioOrigen FROM EmpresaTransporte INNER JOIN ContratoTransporte ON EmpresaTransporte.IdEmpresaTransporte = ContratoTransporte.IdEmpresaTransporte INNER JOIN RutasLogicasTransporte ON ContratoTransporte.IdContratoTransporte = RutasLogicasTransporte.IdContratoTransporte  " & _
                  "WHERE  (ContratoTransporte.IdCosecha = " & My.Forms.FrmRemision2.TextIdCosecha.Text & ") AND (RutasLogicasTransporte.IdLugarAcopioOrigen = " & Me.Origen.Text & ") ORDER BY EmpresaTransporte.Codigo"
            DataAdapter = New SqlClient.SqlDataAdapter(SQL, MiConexion)
            DataAdapter.Fill(DataSet, "Conductor")
            If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
                Me.CboEmpresaTrans.DataSource = DataSet.Tables("Conductor")
                Me.CboEmpresaTrans.Text = DataSet.Tables("Conductor").Rows(0)("NombreEmpresa")
                Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns("IdEmpresaTransporte").Visible = False
                Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns("IdCosecha").Visible = False
                Me.CboEmpresaTrans.Splits.Item(0).DisplayColumns("IdLugarAcopioOrigen").Visible = False
            End If


        End If
    End Sub

    Private Sub CboLocDest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLocDest.TextChanged
        Dim SQL As String = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1 and NomLugarAcopio = '" & Me.CboLocDest.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "LugarAcopio")
        If Not DataSet.Tables("LugarAcopio").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")) Then
                Me.destino.Text = DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
            End If
        End If
    End Sub

    Private Sub CboEmprsPlc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmprsPlc.TextChanged
        Dim SQL As String = "SELECT IdVehiculo FROM Vehiculo WHERE ( Placa = '" & Me.CboEmprsPlc.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "idvehi")
        If Not DataSet.Tables("idvehi").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("idvehi").Rows(0)("IdVehiculo")) Then
                Me.vehiculo.Text = DataSet.Tables("idvehi").Rows(0)("IdVehiculo")
            End If
        End If
    End Sub
    Private Sub CboConductor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboConductor.TextChanged
        Dim SQL As String = "SELECT  IdConductor  FROM  Conductor WHERE ( Nombre = '" & Me.CboConductor.Text & "')"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(SQL, MiConexion)
        DataAdapter.Fill(DataSet, "conduc")
        If Not DataSet.Tables("conduc").Rows.Count = 0 Then
            If Not IsDBNull(DataSet.Tables("conduc").Rows(0)("IdConductor")) Then
                Me.conductor.Text = DataSet.Tables("conduc").Rows(0)("IdConductor")
            End If
        End If
    End Sub

    Private Sub CmdPesada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPesada.Click
        My.Forms.FrmBascula.TipoPesada = "PuntoIntermedio" & Posicion
        My.Forms.FrmBascula.Posicion = Posicion
        My.Forms.FrmBascula.Calidad = FrmRemision2.CboCalidad.Text
        My.Forms.FrmBascula.EstadoFisico = "Ninguno"
        My.Forms.FrmBascula.Categoria = "Ninguno"
        My.Forms.FrmBascula.DTPFecha.Text = Format(FrmRemision2.DTPRemFechCarga.Value, "dd/MM/yyyy")
        My.Forms.FrmBascula.DTPRemFechCarga.Value = FrmRemision2.DTPRemFechCarga.Value
        My.Forms.FrmBascula.ShowDialog()
    End Sub

    Private Sub Button_Pesada_Maquila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Pesada_Maquila.Click
        Dim iPosicion As Double, TipoPesada As String
        iPosicion = TDGribListRecibos.Row

        Me.TDGridOrigen.Row = iPosicion
        Me.TDBGridMerma.Row = iPosicion
        TipoPesada = "Rec" & Me.TDGribListRecibos.Columns("NumeroRecibo").Text & "-N" & iPosicion & "-D" & iPosicionDetalle & "-P1"

        My.Forms.FrmBascula.TipoPesada = TipoPesada
        My.Forms.FrmBascula.Posicion = iPosicion
        My.Forms.FrmBascula.Calidad = FrmRemision2.CboCalidad.Text
        My.Forms.FrmBascula.EstadoFisico = "Ninguno"
        My.Forms.FrmBascula.Categoria = "Ninguno"
        My.Forms.FrmBascula.DTPFecha.Text = Format(FrmRemision2.DTPRemFechCarga.Value, "dd/MM/yyyy")
        My.Forms.FrmBascula.DTPRemFechCarga.Value = FrmRemision2.DTPRemFechCarga.Value
        My.Forms.FrmBascula.ShowDialog()

        Me.TDGribListRecibos.Columns("PesoBascula").Text = FrmBascula.SubTotalRemision
        Me.TDGribListRecibos.Columns("CantidadBascula").Text = FrmBascula.QQRemision

        Me.TDBGridMerma.Columns("Merma").Text = Format(Me.TDGridOrigen.Item(iPosicion)("PesoNeto") - FrmBascula.SubTotalRemision, "##,##0.00")


        SumaGridRecibos(iPosicion)

        Me.TxtPesoBrutDestino.Text = PesoBruto
        Me.TxtCantDest.Text = Cantidad
        Me.TxtPBEntrada.Text = PesoBruto
        Me.TxtCantidadEntrada.Text = Cantidad
        Me.TxtCantSacos.Text = Cantidad
        Me.TxtPIPesoBruto.Text = PesoBruto

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Quien = "Localidad"
        My.Forms.FrmConsultas.Text = "Consulta Localidad"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA LOCALIDAD"

        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Quien = "Consulta"
            Me.CboLocOrigen.Text = My.Forms.FrmConsultas.Descripcion
            Me.CboLocDest.Text = My.Forms.FrmConsultas.Descripcion
            'Me.Button2.Enabled = False
            'Me.CboLocDest.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "Localidad"
        My.Forms.FrmConsultas.Text = "Consulta Localidad"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA LOCALIDAD"

        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Quien = "Consulta"
            Me.CboLocDest.Text = My.Forms.FrmConsultas.Descripcion
        End If
    End Sub

    Private Sub Button_Pesada_Maquila_Salida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Pesada_Maquila_Salida.Click
        Dim iPosicion As Double, TipoPesada As String, FechaP1 As Date, TipoPesadaP1 As String, TipoRemision As String, ExisteRecibo2HMas As Boolean
        Dim PesoBascula As Double, CantidadBascula As Double, NumeroRemision As String, CodigoProducto As String, Linea As Double, Descripcion As String, Calidad As String, Estado As String, Precio As Double, PesoKg As Double
        Dim Tara As Double, PesoNetoKg As Double, QQ As Double
        Dim DataSetConsulta As New DataSet, DataAdapterConsulta As New SqlClient.SqlDataAdapter

        iPosicion = TDGribListRecibosSalida.Row
        TipoPesada = "Rec" & Me.TDGribListRecibosSalida.Columns("NumeroRecibo").Text & "-N" & iPosicion & "-D" & iPosicionDetalle & "-P2"

        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////VERIFICO EL TIEMPO DE LA PRIMER PESADA /////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        FechaP1 = Format(FrmRemision2.DTPRemFechCarga.Value, "dd/MM/yyyy")
        TipoPesadaP1 = "Rec" & Me.TDGribListRecibos.Columns("NumeroRecibo").Text & "-N" & iPosicion & "-D" & iPosicionDetalle & "-P1"
        TipoRemision = FrmRemision2.CboTipoRemision.Text
        ExisteRecibo2HMas = False
        'Me.TDGribListRecibos.Row = iPosicion

        sql = "SELECT id_Eventos AS Linea, Precio, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision, FechaCarga FROM Detalle_Pesadas  " & _
              "WHERE  (IdRemisionPergamino = " & Me.IdRemisionPergamino & ") AND (TipoRemision = '" & TipoRemision & "') AND (TipoPesada = '" & TipoPesadaP1 & "')"
        DataAdapterConsulta = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapterConsulta.Fill(DataSetConsulta, "DetallePesada")

        If DataSetConsulta.Tables("DetallePesada").Rows.Count <> 0 Then

            NumeroRemision = DataSetConsulta.Tables("DetallePesada").Rows(0)("NumeroRemision")
            CodigoProducto = DataSetConsulta.Tables("DetallePesada").Rows(0)("Cod_Productos")
            Linea = DataSetConsulta.Tables("DetallePesada").Rows(0)("Linea")
            Descripcion = DataSetConsulta.Tables("DetallePesada").Rows(0)("Descripcion_Producto")
            Calidad = DataSetConsulta.Tables("DetallePesada").Rows(0)("Calidad")
            Estado = DataSetConsulta.Tables("DetallePesada").Rows(0)("Estado")
            Precio = DataSetConsulta.Tables("DetallePesada").Rows(0)("Precio")
            Tara = DataSetConsulta.Tables("DetallePesada").Rows(0)("Tara")
            PesoNetoKg = DataSetConsulta.Tables("DetallePesada").Rows(0)("PesoNetoKg")
            QQ = DataSetConsulta.Tables("DetallePesada").Rows(0)("Saco")


            If DateDiff(DateInterval.Hour, DataSetConsulta.Tables("DetallePesada").Rows(0)("FechaCarga"), Me.DTPPISalida.Value) > 2 Then
                ExisteRecibo2HMas = True
            End If
        End If


        If ExisteRecibo2HMas = False Then

            '//////////////////////////////////////////SI YA ESTA GRABADO NO PREGUNTO /////////////////////////////////////////////
            sql = "SELECT id_Eventos AS Linea, Precio, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision, FechaCarga FROM Detalle_Pesadas  " & _
                  "WHERE  (IdRemisionPergamino = " & Me.IdRemisionPergamino & ") AND (TipoRemision = '" & TipoRemision & "') AND (TipoPesada = '" & TipoPesada & "')"
            DataAdapterConsulta = New SqlClient.SqlDataAdapter(sql, MiConexion)
            DataAdapterConsulta.Fill(DataSetConsulta, "Consulta")
            If DataSetConsulta.Tables("Consulta").Rows.Count <> 0 Then
                My.Forms.FrmBascula.TipoPesada = TipoPesada
                My.Forms.FrmBascula.Posicion = iPosicion
                My.Forms.FrmBascula.Calidad = FrmRemision2.CboCalidad.Text
                My.Forms.FrmBascula.EstadoFisico = "Ninguno"
                My.Forms.FrmBascula.Categoria = "Ninguno"
                My.Forms.FrmBascula.DTPFecha.Text = Format(FrmRemision2.DTPRemFechCarga.Value, "dd/MM/yyyy")
                My.Forms.FrmBascula.DTPRemFechCarga.Value = FrmRemision2.DTPRemFechCarga.Value
                My.Forms.FrmBascula.ShowDialog()

                Me.TDGribListRecibosSalida.Columns("PesoBascula").Text = FrmBascula.SubTotalRemision
                Me.TDGribListRecibosSalida.Columns("CantidadBascula").Text = FrmBascula.QQRemision

            Else


                If MsgBox("No es necesario realizar la Pesada por tiempo Menor a 2 Horas, ¿Desea persarlos?", MsgBoxStyle.YesNo, "Sistema Bascula") = MsgBoxResult.No Then



                    PesoBascula = DataSetConsulta.Tables("DetallePesada").Rows(0)("PesoNetoKg")
                    CantidadBascula = DataSetConsulta.Tables("DetallePesada").Rows(0)("Saco")

                    GrabaDetallePesadas(NumeroRemision, CodigoProducto, CantidadBascula, Linea, Descripcion, Calidad, Estado, Precio, PesoBascula, TipoRemision, Tara, PesoNetoKg, QQ, Calidad, TipoPesada, Me.DTPPISalida.Value, IdRemisionPergamino)

                    Me.TDGribListRecibosSalida.Columns("PesoBascula").Text = PesoBascula
                    Me.TDGribListRecibosSalida.Columns("CantidadBascula").Text = CantidadBascula
                Else

                    '//////////////////////////////////SI TIENE MENOS DE 2 HORAS PERO QUIERE PESARLO /////////////////////////////////////////////////
                    My.Forms.FrmBascula.TipoPesada = TipoPesada
                    My.Forms.FrmBascula.Posicion = iPosicion
                    My.Forms.FrmBascula.Calidad = FrmRemision2.CboCalidad.Text
                    My.Forms.FrmBascula.EstadoFisico = "Ninguno"
                    My.Forms.FrmBascula.Categoria = "Ninguno"
                    My.Forms.FrmBascula.DTPFecha.Text = Format(FrmRemision2.DTPRemFechCarga.Value, "dd/MM/yyyy")
                    My.Forms.FrmBascula.DTPRemFechCarga.Value = FrmRemision2.DTPRemFechCarga.Value
                    My.Forms.FrmBascula.ShowDialog()

                    Me.TDGribListRecibosSalida.Columns("PesoBascula").Text = FrmBascula.SubTotalRemision
                    Me.TDGribListRecibosSalida.Columns("CantidadBascula").Text = FrmBascula.QQRemision

                End If







            End If



        Else

            '//////////////////////////////////SI TIENE DE MAS DE 2 HORAS ES OBLIGATORIO PESARLO/////////////////////////////////////////////////
            My.Forms.FrmBascula.TipoPesada = TipoPesada
            My.Forms.FrmBascula.Posicion = iPosicion
            My.Forms.FrmBascula.Calidad = FrmRemision2.CboCalidad.Text
            My.Forms.FrmBascula.EstadoFisico = "Ninguno"
            My.Forms.FrmBascula.Categoria = "Ninguno"
            My.Forms.FrmBascula.DTPFecha.Text = Format(FrmRemision2.DTPRemFechCarga.Value, "dd/MM/yyyy")
            My.Forms.FrmBascula.DTPRemFechCarga.Value = FrmRemision2.DTPRemFechCarga.Value
            My.Forms.FrmBascula.ShowDialog()

            Me.TDGribListRecibosSalida.Columns("PesoBascula").Text = FrmBascula.SubTotalRemision
            Me.TDGribListRecibosSalida.Columns("CantidadBascula").Text = FrmBascula.QQRemision
        End If








        SumaGridRecibosSSalida(iPosicion)

        Me.TxtPesoBrutDestino.Text = PesoBruto
        Me.TxtCantDest.Text = Cantidad
        Me.TxtCantidadSalida.Text = Cantidad
        Me.TxtPBSalida.Text = PesoBruto

        TDGribListRecibosSalida.Row = iPosicion + 1
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, NumeroRemision As String

        ''///////////////////////////////////////////SI LE DA SALIR ELIMINO LAS PESADAS /////////////////////////////////
        'If FrmRemision2.TxtNumeroRemision.Text = "-----0-----" Then
        '    NumeroRemision = FrmRemision2.NumeroTemporal
        'ElseIf FrmRemision2.TxtNumeroRemision.Text = "" Then
        '    NumeroRemision = FrmRemision2.NumeroTemporal
        'Else
        '    NumeroRemision = FrmRemision2.TxtNumeroRemision.Text
        'End If

        ''---------------------SI NO SE GUARDO LA REMISION BORRO TODO --------------------------------------------
        'StrSqlUpdate = "DELETE FROM Detalle_Pesadas WHERE (NumeroRemision = '" & NumeroRemision & "') AND (TipoRemision = '" & My.Forms.FrmRemision2.CboTipoRemision.Text & "') "
        'MiConexion.Close()
        'MiConexion.Open()
        'ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
        'iResultado = ComandoUpdate.ExecuteNonQuery
        'MiConexion.Close()





        Me.Close()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "EmpresaTransporte"
        My.Forms.FrmConsultas.IdCosecha = My.Forms.FrmRemision2.TextIdCosecha.Text
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboEmpresaTrans.Text = My.Forms.FrmConsultas.Descripcion
    End Sub

    Private Sub CmdConfirma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConfirma.Click
        Dim Respuesta As Double = 0, Registros As Double, i As Double

        If Me.TxtPesoBrutDestino.Text = "" Then
            MsgBox("La Cantidad Destino es necesaria para confirmar", MsgBoxStyle.Critical, "SistemaBascula")
            Exit Sub
        End If

        If Len(Me.TxtNumeroBoleta.Text) <> 6 Then
            MsgBox("El Numero de Boleta debe ser de 6 Digitos", MsgBoxStyle.Critical, "Puntos Intermedios")
            Exit Sub
        End If


        Registros = 0
        i = 0
        Registros = Me.TDGribListRecibosSalida.RowCount
        Do While Registros > i
            If Me.TDGribListRecibosSalida.Item(i)("PesoBascula") = 0 Then
                MsgBox("La Cantidad Destino es necesaria para confirmar", MsgBoxStyle.Critical, "SistemaBascula")
                Exit Sub
            End If

            i = i + 1
        Loop

        If Val(Me.TxtPesoBrutDestino.Text) = 0 Then
            MsgBox("La Cantidad Destino es necesaria para confirmar", MsgBoxStyle.Critical, "SistemaBascula")
            Exit Sub
        End If


        respuesta = MsgBox("¿Esta Seguro de Confirmar?", MsgBoxStyle.YesNo, "Sistema Bascula")
        If Respuesta = 6 Then
            ConfirmaIntermedio = True
            My.Forms.FrmRemision2.Limpiar = False
            My.Forms.FrmRemision2.Button11.Enabled = True
            BtnGuardarPInter_Click(sender, e)


            My.Forms.FrmRemision2.Limpiar = True
        End If
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
            '***CAMBIO 03-01-2020 VALIDAR EL LUGAR DE ACOPIO EN LA CONSULTA ***
            'SqlString = "SELECT  IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta, DATEDIFF(hh, Fecha, CONVERT(DATETIME, '" & Format(Me.DTPRemFechCarga.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS Horas FROM Registros WHERE (TipoRegistro = 'Llegada') AND (Placa = '" & NumeroPlaca & "') AND (NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "')"
            SqlString = "SELECT  Registros.IdRegistro, Registros.TipoRegistro, Registros.IdConductor, Registros.IdLugarAcopio, Registros.Fecha, Registros.Placa, Registros.IdTransporte, Registros.NumeroBoleta, DATEDIFF(hh, Registros.Fecha, CONVERT(DATETIME, '" & Format(Me.DTPPICarga.Value, "yyyy-MM-dd HH:mm") & "', 102)) AS Horas, EmpresaTransporte.NombreEmpresa FROM  Registros INNER JOIN EmpresaTransporte ON Registros.IdConductor = EmpresaTransporte.Codigo  " & _
                        "WHERE  (Registros.TipoRegistro = 'Llegada') AND (Registros.NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (Registros.IdLugarAcopio = '" & My.Forms.FrmRemision2.IdLugarAcopio & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta2")
            If DataSet.Tables("Consulta2").Rows.Count = 0 Then
                MsgBox("No Existe Registro de llegada para este camion", MsgBoxStyle.Critical, " Bascula ")
            Else

                '/////////////////////////////////////////////////////////////////////////////
                '//////////////////////////SI EXISTE LA BOLETA LA LLENO DE INFORMACION //////////
                '////////////////////////////////////////////////////////////////////////////////////

                CboEmpresaTrans.Text = DataSet.Tables("Consulta2").Rows(0)("NombreEmpresa")
                Me.CboEmprsPlc.Text = DataSet.Tables("Consulta2").Rows(0)("Placa")


                'IdEmpresaTransporte = Me.CboEmpresaTrans.Columns(2).Text

                sql = "SELECT   Conductor.Nombre FROM Conductor INNER JOIN ConductorEmpresaTransporte ON Conductor.IdConductor = ConductorEmpresaTransporte.IdConductor  " & _
                      "WHERE  (ConductorEmpresaTransporte.Activo = 1) AND (ConductorEmpresaTransporte.IdEmpresaTransporte = " & IdEmpresaTransporte & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
                DataAdapter.Fill(DataSet, "Conduc")
                Me.CboConductor.DataSource = DataSet.Tables("Conduc")


                If Not DataSet.Tables("Conduc").Rows.Count = 0 Then
                    Me.CboConductor.Splits.Item(0).DisplayColumns(0).Width = 270
                End If


            End If
        End If
    End Sub
End Class