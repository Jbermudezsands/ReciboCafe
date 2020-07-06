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

            Case "Recepcion2"
                Me.LblTipoInformacion.Text = "INFORMACION MODULO DE REMISION"
                Me.LblTipoInformacion2.Text = "CONSOLIDADO DE ENTRADA - FECHA DE REMISION:"
                Me.LblMontoPagado.Text = "MERMA"
                Me.TxtMontoPagado.Visible = False
                Me.TxtMerma.Visible = True
                Me.TxtTotalMontoPagado.Visible = False
                Me.TxtTotalMerma.Visible = True

            Case "Recepcion3"
                Me.LblTipoInformacion.Text = "INFORMACION MODULO DE BODEGA"
                Me.LblTipoInformacion2.Text = "CONSOLIDADO DE ENTRADA - FECHA DE BODEGA:"
                Me.LblMontoPagado.Visible = False
                Me.TxtMontoPagado.Visible = False
                Me.TxtMerma.Visible = False
                Me.TxtTotalMontoPagado.Visible = False
                Me.TxtTotalMerma.Visible = False

        End Select
    End Sub
End Class
