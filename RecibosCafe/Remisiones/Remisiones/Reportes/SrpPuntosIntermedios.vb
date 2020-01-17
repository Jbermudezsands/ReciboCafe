Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class SrpPuntosIntermedios
    Dim Contador As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private PuntosIntermediosOrigenSubReport As SrpPuntosIntermedio2, PuntosIntermediosEntradaSubReport As SrpPuntosIntermedioEntrada, PuntosIntermediosSalidaSubReport As SrpPuntosIntermedioSalida


    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Contador = 0
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

        Dim DataSet As New DataSet, ODataRowDetalle As DataRow, oDataRowSalida As DataRow, oDataRowEntrada As DataRow, PesoBascula As Double
        Dim Contador As Double, Cont2 As Double, j As Double, Cont As Double
        Dim TipoPesada As String, iPosicionDetalle As Double
        Dim i As Double, Sql As String, CantidadBascula As Double
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Count As Double


        Me.TxtReferencia.Text = Contador
        Me.TxtTitulo.Text = "Punto Intermedio " & Contador + 1

        Sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, DetalleReciboCafePergamino.Tara As PesoBruto ,DetalleReciboCafePergamino.Tara AS PesoBascula ,DetalleReciboCafePergamino.Tara AS CantidadBascula  FROM    DetalleReciboCafePergamino INNER JOIN    ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN   EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibos")
        Sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, DetalleReciboCafePergamino.Tara As PesoBruto ,DetalleReciboCafePergamino.Tara AS PesoBascula ,DetalleReciboCafePergamino.Tara AS CantidadBascula  FROM    DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosSalida")
        Sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, ReciboCafePergamino.Codigo As Daño , ReciboCafePergamino.Codigo As EstadoFisico, DetalleReciboCafePergamino.Tara As PesoNeto ,DetalleReciboCafePergamino.Tara AS Sacos FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosRem")

        Me.TxtOrigen.Text = My.Forms.FrmRemision2.LblSucursal.Text
        Me.TxtFechaCarga.Text = My.Forms.FrmRemision2.DTPRemFechCarga.Value
        Me.TxtFechaSalida.Text = My.Forms.FrmRemision2.DTPRemFechSalid.Value
        Me.TxtEmpresa.Text = My.Forms.FrmRemision2.CboEmpresaTrans.Text
        Me.TxtPlaca.Text = My.Forms.FrmRemision2.CboEmprsPlaca.Text
        Me.TxtConductor.Text = My.Forms.FrmRemision2.CboEmpresaCond.Text
        Me.TxtDestino.Text = My.Forms.FrmRemision2.CboRemLocDest.Text
        'count = 0
        'count = My.Forms.FrmRemision2.TDBGridPuntosInter.RowCount
        'If count > 0 Then
        '    Me.TxtDestino.Text = My.Forms.FrmRemision2.TDBGridPuntosInter.Columns(14).Text
        'Else
        '    Me.TxtDestino.Text = My.Forms.FrmRemision2.CboRemLocDest.Text
        'End If


        If FrmRemision2.CboTipoRemision.Text = "MAQUILA" Then



            '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
            Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
            i = 0
            Do While Cont > i
                'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                ODataRowDetalle("NumeroRecibo") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Codigo")
                ODataRowDetalle("Daño") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                ODataRowDetalle("EstadoFisico") = 1 'My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                ODataRowDetalle("Sacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos2")
                ODataRowDetalle("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto2")
                DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)

                CantidadBascula = 0
                PesoBascula = 0
                iPosicionDetalle = i
                TipoPesada = "Rec" & My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text & "-N" & i & "-D" & iPosicionDetalle & "-P1"
                '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (FechaCarga = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') GROUP BY Cod_Productos, Descripcion_Producto"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                    PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                    CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                End If
                DataSet.Tables("Consulta").Reset()


                oDataRowEntrada = DataSet.Tables("ListaRecibos").NewRow
                oDataRowEntrada("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                oDataRowEntrada("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                oDataRowEntrada("PesoBascula") = PesoBascula
                oDataRowEntrada("CantidadBascula") = CantidadBascula
                'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                DataSet.Tables("ListaRecibos").Rows.Add(oDataRowEntrada)

                oDataRowSalida = DataSet.Tables("ListaRecibosSalida").NewRow
                oDataRowSalida("NumeroRecibo") = My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Text
                oDataRowSalida("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                oDataRowSalida("PesoBascula") = PesoBascula
                oDataRowSalida("CantidadBascula") = CantidadBascula
                'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                DataSet.Tables("ListaRecibosSalida").Rows.Add(oDataRowSalida)

                ''////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                'Cont2 = My.Forms.FrmRemision2.TDGridUseParc.RowCount
                'j = 0
                'Do While Cont2 > j
                '    My.Forms.FrmRemision2.TDGridUseParc.Row = j



                '    j = j + 1
                'Loop

                i = i + 1
            Loop

            If PuntosIntermediosOrigenSubReport Is Nothing Then
                PuntosIntermediosOrigenSubReport = New SrpPuntosIntermedio2
                Me.SubReportIntermedioOrigen.Report = PuntosIntermediosOrigenSubReport
                Me.SubReportIntermedioOrigen.Report.DataSource = DataSet.Tables("ListaRecibosRem")
            End If

            If PuntosIntermediosEntradaSubReport Is Nothing Then
                PuntosIntermediosEntradaSubReport = New SrpPuntosIntermedioEntrada
                Me.SubReportIntermedioEntrada.Report = PuntosIntermediosEntradaSubReport
                Me.SubReportIntermedioEntrada.Report.DataSource = DataSet.Tables("ListaRecibos")
            End If

            If PuntosIntermediosSalidaSubReport Is Nothing Then
                PuntosIntermediosSalidaSubReport = New SrpPuntosIntermedioSalida
                Me.SubReportIntermedioSalida.Report = PuntosIntermediosSalidaSubReport
                Me.SubReportIntermedioSalida.Report.DataSource = DataSet.Tables("ListaRecibosSalida")
            End If



        Else
            '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
            Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
            i = 0
            Do While Cont > i
                'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                ODataRowDetalle("NumeroRecibo") = i
                ODataRowDetalle("Daño") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                ODataRowDetalle("EstadoFisico") = 1 'My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                ODataRowDetalle("Sacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos2")
                ODataRowDetalle("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto2")
                DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)


                CantidadBascula = 0
                PesoBascula = 0
                iPosicionDetalle = Contador
                TipoPesada = "RecGrupo " & i & "-N" & i & "-D" & iPosicionDetalle & "-P1"
                '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
                'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
                Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (FechaCarga = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') GROUP BY Cod_Productos, Descripcion_Producto"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                    PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                    CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                End If
                DataSet.Tables("Consulta").Reset()


                oDataRowEntrada = DataSet.Tables("ListaRecibos").NewRow
                oDataRowEntrada("NumeroRecibo") = i
                oDataRowEntrada("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                oDataRowEntrada("PesoBascula") = PesoBascula
                oDataRowEntrada("CantidadBascula") = CantidadBascula
                'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                DataSet.Tables("ListaRecibos").Rows.Add(oDataRowEntrada)

                oDataRowSalida = DataSet.Tables("ListaRecibosSalida").NewRow
                oDataRowSalida("NumeroRecibo") = i
                oDataRowSalida("PesoBruto") = My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Text
                oDataRowSalida("PesoBascula") = PesoBascula
                oDataRowSalida("CantidadBascula") = CantidadBascula
                'oDataRow("CantidadSaco") = Me.GribListRecibos.Item(i)("CantidadSacos")
                DataSet.Tables("ListaRecibosSalida").Rows.Add(oDataRowSalida)

                ''////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA PESARLOS /////////////////////////////
                'Cont2 = My.Forms.FrmRemision2.TDGridUseParc.RowCount
                'j = 0
                'Do While Cont2 > j
                '    My.Forms.FrmRemision2.TDGridUseParc.Row = j



                '    j = j + 1
                'Loop


                i = i + 1
            Loop

            If PuntosIntermediosOrigenSubReport Is Nothing Then
                PuntosIntermediosOrigenSubReport = New SrpPuntosIntermedio2
                Me.SubReportIntermedioOrigen.Report = PuntosIntermediosOrigenSubReport
                Me.SubReportIntermedioOrigen.Report.DataSource = DataSet.Tables("ListaRecibosRem")
            End If

            If PuntosIntermediosEntradaSubReport Is Nothing Then
                PuntosIntermediosEntradaSubReport = New SrpPuntosIntermedioEntrada
                Me.SubReportIntermedioEntrada.Report = PuntosIntermediosEntradaSubReport
                Me.SubReportIntermedioEntrada.Report.DataSource = DataSet.Tables("ListaRecibos")
            End If

            If PuntosIntermediosSalidaSubReport Is Nothing Then
                PuntosIntermediosSalidaSubReport = New SrpPuntosIntermedioSalida
                Me.SubReportIntermedioSalida.Report = PuntosIntermediosSalidaSubReport
                Me.SubReportIntermedioSalida.Report.DataSource = DataSet.Tables("ListaRecibosSalida")
            End If



        End If



        Contador = Contador + 1
    End Sub

    Private Sub SrpPuntosIntermedios_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
