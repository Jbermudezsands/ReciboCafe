Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepMermaRecibo
    Private MermaRecibosSubReport As SrpMermaRecibo = Nothing
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub ArepRemisionTicket_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        If MermaRecibosSubReport Is Nothing Then
            'MermaRecibosSubReport = New SrpMermaRecibo
            'Me.SubReportRecibos.Report = MermaRecibosSubReport
            'Me.SubReportRecibos.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If


    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        'CType(Me.SubReportRecibos.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        'CType(Me.SubReportRecibos.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString

        'Me.SubReportRecibos.Report.DataSource = FrmReportes.DataSet.Tables("Recepcion")
        'My.Application.DoEvents()




    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Select Case Me.TxtTipo.Text
            Case "Recepcion1"
                Me.LblTipoInformacion.Text = "INFORMACION MODULO DE RECIBO"
                Me.LblTipoInformacion2.Text = "CONSOLIDADO DE ENTRADA - FECHA DE RECEPCIO:"
                Me.LblMontoPagado.Text = "MONTO PAGADO"
                Me.TxtMontoPagado.Visible = True
                Me.TxtMerma.Visible = False
                Me.TxtTotalMontoPagado.Visible = True
                Me.TxtTotalMerma.Visible = False
                Me.TextBox21.Visible = False
                Me.TextBox22.Visible = False
                Me.TextBox23.Visible = False
                Me.TextBox20.Visible = True
                Me.TextBox14.Visible = True
                Me.TextBox13.Visible = True


            Case "Recepcion2"
                Me.LblTipoInformacion.Text = " "
                Me.LblTipoInformacion2.Text = "LIQUIDADO DE DEPOSITO PERGAMINO"
                Me.LblMontoPagado.Text = "MONTO PAGADO"
                Me.LblMontoPagado.Visible = True
                Me.TxtMontoPagado.Visible = True
                Me.TxtMerma.Visible = False
                Me.TxtTotalMontoPagado.Visible = True
                Me.TxtTotalMerma.Visible = False
                Me.TextBox21.Visible = False
                Me.TextBox22.Visible = False
                Me.TextBox23.Visible = False
                Me.TextBox20.Visible = True
                Me.TextBox14.Visible = True
                Me.TextBox13.Visible = True

            Case "Recepcion3"
                Me.LblTipoInformacion.Text = "INFORMACION MODULO DE REMISION"
                Me.LblTipoInformacion2.Text = "CONSOLIDADO DE ENTRADA - FECHA DE REMISION:"
                Me.LblMontoPagado.Text = "MERMA"
                Me.TxtMontoPagado.Visible = False
                Me.TxtMerma.Visible = True
                Me.TxtTotalMontoPagado.Visible = False
                Me.TxtTotalMerma.Visible = True
                Me.TextBox21.Visible = True
                Me.TextBox22.Visible = True
                Me.TextBox23.Visible = True
                Me.TextBox20.Visible = False
                Me.TextBox14.Visible = False
                Me.TextBox13.Visible = False

            Case "Recepcion4"
                Me.LblTipoInformacion.Text = "INFORMACION MODULO DE BODEGA"
                Me.LblTipoInformacion2.Text = "CONSOLIDADO DE ENTRADA - FECHA DE BODEGA:"
                Me.LblMontoPagado.Visible = False
                Me.TxtMontoPagado.Visible = False
                Me.TxtMerma.Visible = False
                Me.TxtTotalMontoPagado.Visible = False
                Me.TxtTotalMerma.Visible = False
                Me.TextBox21.Visible = False
                Me.TextBox22.Visible = False
                Me.TextBox23.Visible = False
                Me.TextBox20.Visible = False
                Me.TextBox14.Visible = False
                Me.TextBox13.Visible = False

        End Select
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format

    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format
        Me.LblTotalTipoCafe.Text = "TOTAL " & Me.TxtTipoCafe.Text
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Me.LblLocalidad.Text = "Total " & Me.TxtLocalidad.Text
    End Sub

    Private Sub GroupFooter4_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter4.Format
        Me.LblTotalTipoCompra.Text = "Total " & Me.TxtTipoCompra.Text
    End Sub
End Class
