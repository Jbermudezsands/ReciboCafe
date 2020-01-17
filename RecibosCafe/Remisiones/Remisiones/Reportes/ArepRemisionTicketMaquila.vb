Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepRemisionTicketMaquila 
    Public IdRemision As Double
    Private DetalleRemisionSubReport As SrpDetalleRemision = Nothing, Contador As Double
    Private PuntosIntermediosSubReport As SrpPuntosIntermedios = Nothing
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Dim SqlString As String

        Contador = 0
        SqlString = "SELECT Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.PesoBruto - DetalleRemisionPergamino.Tara AS PesoNeto, MAX(DetalleReciboCafePergamino.Humedad) AS Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.Merma FROM DetalleRemisionPergamino INNER JOIN RemisionPergamino ON DetalleRemisionPergamino.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino INNER JOIN  ReciboCafePergamino INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN  RecibosRemisionPergamino ON DetalleReciboCafePergamino.IdDetalleReciboPergamino = RecibosRemisionPergamino.IdDetalleReciboPergamino ON  DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino GROUP BY DetalleRemisionPergamino.Merma, Dano.Nombre, EstadoFisico.Descripcion, TipoSaco.Descripcion, RangoImperfeccion.Nombre, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion, RemisionPergamino.IdRemisionPergamino, DetalleRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.Codigo, DetalleRemisionPergamino.PesoNeto2, DetalleRemisionPergamino.PesoBruto, DetalleRemisionPergamino.Tara, DetalleRemisionPergamino.CantidadSacos, DetalleRemisionPergamino.IdDetalleRemisionPergamino " & _
                    "HAVING (RemisionPergamino.IdRemisionPergamino = '" & IdRemision & "') ORDER BY DetalleRemisionPergamino.IdDetalleRemisionPergamino"

        Me.LblCosecha.Text = My.Forms.FrmRemision2.Cosecha

        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SubReportDetalleRemision.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReportDetalleRemision.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString
        My.Application.DoEvents()

        SqlString = "SELECT IdIntermedio, CantidadSacosOrigen, PesoBrutoOrigen, CantidadSacosDestino, PesoBrutoDestino, Fecha, FechaSalida, Cancelada, IdRemisionPergamino, IdEmpresaTransporte, IdOrigen, IdDestino, IdConductor, IdVehiculo, IdUsuario, FechaCarga FROM Intermedio " & _
                    "WHERE  (IdRemisionPergamino = '" & IdRemision & "') AND (Cancelada = 0)"
        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SubReportIntermedio.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReportIntermedio.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString
        My.Application.DoEvents()

    End Sub

    Private Sub ArepRemisionTicketMaquila_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If DetalleRemisionSubReport Is Nothing Then
            DetalleRemisionSubReport = New SrpDetalleRemision
            Me.SubReportDetalleRemision.Report = DetalleRemisionSubReport
            Me.SubReportDetalleRemision.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        If PuntosIntermediosSubReport Is Nothing Then
            PuntosIntermediosSubReport = New SrpPuntosIntermedios
            Me.SubReportIntermedio.Report = PuntosIntermediosSubReport
            Me.SubReportIntermedio.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Contador = Contador + 1
    End Sub
End Class
