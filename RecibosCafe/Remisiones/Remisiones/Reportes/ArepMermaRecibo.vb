Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepMermaRecibo
    Private MermaRecibosSubReport As SrpMermaRecibo = Nothing
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub ArepRemisionTicket_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        If MermaRecibosSubReport Is Nothing Then
            MermaRecibosSubReport = New SrpMermaRecibo
            Me.SubReportRecibos.Report = MermaRecibosSubReport
            Me.SubReportRecibos.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If


    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        'CType(Me.SubReportRecibos.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        'CType(Me.SubReportRecibos.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString

        Me.SubReportRecibos.Report.DataSource = FrmReportes.DataSet.Tables("Recepcion")
        My.Application.DoEvents()




    End Sub
End Class
