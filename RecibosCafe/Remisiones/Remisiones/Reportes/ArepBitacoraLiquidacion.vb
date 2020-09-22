Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepBitacoraLiquidacion
    Public NumeroLiquidacion As String, idLiquidacion As Double, Cosecha As String
    Private DetalleReciboSubReport As SrpDetalleRecibosLiquidacion = Nothing

    Private Sub ArepBitacoraLiquidacion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If DetalleReciboSubReport Is Nothing Then
            DetalleReciboSubReport = New SrpDetalleRecibosLiquidacion
            Me.SubReportDetalleRecibo.Report = DetalleReciboSubReport
            Me.SubReportDetalleRecibo.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If
    End Sub


    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim SqlString As String, Lineas As Double
        Dim p As System.Drawing.PointF



        Lineas = (Me.LblProductor.Text.Length) / 35

        If Lineas > 3 Then
            Lineas = 4
        ElseIf Lineas < 1 Then
            Lineas = 1
        Else
            Lineas = Int(Lineas)
        End If

        Select Case Lineas
            Case 1
                p.X = 0 : p.Y = 0.78
                Me.Label7.Location = p
                p.X = 1.1 : p.Y = 0.78
                Me.LblIdentificacion.Location = p
                p.X = 0 : p.Y = 0.98
                Me.Label8.Location = p
                p.X = 1.1 : p.Y = 0.98
                Me.LblNombreFinca.Location = p
                p.X = 0 : p.Y = 1.18
                Me.Label9.Location = p
                p.X = 1.1 : p.Y = 1.18
                Me.LblUbiFinca.Location = p
                p.X = 0 : p.Y = 1.38
                Me.Label10.Location = p
                p.X = 1.1 : p.Y = 1.38
                Me.LblMunicipio.Location = p
                p.X = 0 : p.Y = 1.6
                Me.TxtDatosCliente.Location = p

            Case 2

                p.X = 0 : p.Y = 0.98
                Me.Label7.Location = p
                p.X = 1.1 : p.Y = 0.98
                Me.LblIdentificacion.Location = p
                p.X = 0 : p.Y = 1.18
                Me.Label8.Location = p
                p.X = 1.1 : p.Y = 1.18
                Me.LblNombreFinca.Location = p
                p.X = 0 : p.Y = 1.38
                Me.Label9.Location = p
                p.X = 1.1 : p.Y = 1.38
                Me.LblUbiFinca.Location = p
                p.X = 0 : p.Y = 1.58
                Me.Label10.Location = p
                p.X = 1.1 : p.Y = 1.58
                Me.LblMunicipio.Location = p
                p.X = 0 : p.Y = 1.8
                Me.TxtDatosCliente.Location = p

            Case 3

                p.X = 0 : p.Y = 1.18
                Me.Label7.Location = p
                p.X = 1.1 : p.Y = 1.18
                Me.LblIdentificacion.Location = p
                p.X = 0 : p.Y = 1.38
                Me.Label8.Location = p
                p.X = 1.1 : p.Y = 1.38
                Me.LblNombreFinca.Location = p
                p.X = 0 : p.Y = 1.58
                Me.Label9.Location = p
                p.X = 1.1 : p.Y = 1.58
                Me.LblUbiFinca.Location = p
                p.X = 0 : p.Y = 1.78
                Me.Label10.Location = p
                p.X = 1.1 : p.Y = 1.78
                Me.LblMunicipio.Location = p
                p.X = 0 : p.Y = 2
                Me.TxtDatosCliente.Location = p

        End Select



        If Me.LblRecibos.Text = "" Then
            Me.Label14.Visible = False
            p.X = 0.35 : p.Y = 6.889
            Me.Label15.Location = p
            p.X = 0.35 : p.Y = 7.775
            Me.Label25.Location = p
        End If

        'SqlString = "SELECT ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.Precio,   DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio AS ValorBrutoC$, DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio / TipoCambio.TipoCambio AS ValorBruto$, ReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara,  DetalleLiquidacionPergamino.PesoNeto AS PesoNTCompara  FROM   LiquidacionPergamino INNER JOIN    DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN   ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN    TipoCambio ON LiquidacionPergamino.IdMonedaPreecio = TipoCambio.IdTipoCambio " & _
        '            "WHERE (LiquidacionPergamino.IdLiquidacionPergamino = " & idLiquidacion & ")"

        SqlString = "SELECT  ReciboCafePergamino.Seleccion AS Aplicar, ReciboCafePergamino.Codigo AS NºRecibo, DetalleLiquidacionPergamino.PesoNeto, LiquidacionPergamino.Precio, DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio AS ValorBrutoC$, DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio / TipoCambio.TipoCambio AS ValorBruto$, ReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleLiquidacionPergamino.PesoNeto AS PesoNTCompara, TipoCambio.TipoCambio FROM  LiquidacionPergamino INNER JOIN  DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio " & _
                    "WHERE  (LiquidacionPergamino.IdLiquidacionPergamino = " & idLiquidacion & ")"
        'Me.LblCosecha.Text = My.Forms.FrmLiquidacion.LblCosecha.Text
        Me.LblCosecha.Text = Me.LblCosecha.Text

        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SubReportDetalleRecibo.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReportDetalleRecibo.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString
        My.Application.DoEvents()
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format

    End Sub
End Class
