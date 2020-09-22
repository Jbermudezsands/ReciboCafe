Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 



Public Class ArepReporteDetalleLiquidacion 
    Public IdLiquidacion As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion), Registros As Double


    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Monto As Double, Total As Double, PesoNeto As Double

        Monto = 0
        If Me.TxtIdLiquidacion.Text <> "" Then
            Me.IdLiquidacion = Me.TxtIdLiquidacion.Text
            My.Application.DoEvents()
            SqlString = "SELECT  SUM(DetalleDistribucion.Monto * TipoCambio.TipoCambio) AS Monto FROM  DetalleDistribucion INNER JOIN LiquidacionPergamino ON DetalleDistribucion.IdLiquidacionPergamino = LiquidacionPergamino.IdLiquidacionPergamino INNER JOIN TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio WHERE  (DetalleDistribucion.IdLiquidacionPergamino = " & Me.IdLiquidacion & ") AND (NOT (DetalleDistribucion.NumeroAvio IS NULL)) GROUP BY DetalleDistribucion.NumeroAvio HAVING   (DetalleDistribucion.NumeroAvio <> ' ') "
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                Monto = DataSet.Tables("Consulta").Rows(0)("Monto")
                Me.TxtAbono.Text = Format(Monto, "##,##0.00")
            End If

            Total = 0
            If Me.TxtPesoNeto.Text <> "" Then
                PesoNeto = Me.TxtPesoNeto.Text
            Else
                PesoNeto = 0
            End If
            '///////////////////////////////BUSCO EL TOTAL ///////////////////////////
            SqlString = "SELECT SUM(DetalleLiquidacionPergamino.PesoNeto * LiquidacionPergamino.Precio - LiquidacionPergamino.TotalDeducciones) AS ValorC$ FROM  LiquidacionPergamino INNER JOIN DetalleLiquidacionPergamino ON LiquidacionPergamino.IdLiquidacionPergamino = DetalleLiquidacionPergamino.IdLiquidacionPergamino INNER JOIN ReciboCafePergamino ON DetalleLiquidacionPergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN  TipoCambio ON LiquidacionPergamino.IdTipoCambio = TipoCambio.IdTipoCambio  WHERE(LiquidacionPergamino.IdLiquidacionPergamino = " & Me.IdLiquidacion & ") GROUP BY LiquidacionPergamino.TotalDeducciones"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta2")
            If DataSet.Tables("Consulta2").Rows.Count <> 0 Then
                Total = DataSet.Tables("Consulta2").Rows(0)("ValorC$")
                Me.TxtPagado.Text = Format(Total, "##,##0.00")

                If PesoNeto = 0 Then
                    Me.TxtPrecioNeto.Text = 0
                Else
                    Me.TxtPrecioNeto.Text = Format(Total / PesoNeto, "##,##0.00")
                End If
            End If

            FrmReportes.ProgressBar1.Value = My.Forms.FrmReportes.ProgressBar1.Value + 1
        End If
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub ArepReporteDetalleLiquidacion_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageStart

    End Sub

    Private Sub ArepReporteDetalleLiquidacion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        My.Forms.FrmReportes.ProgressBar1.Minimum = 0
        My.Forms.FrmReportes.ProgressBar1.Maximum = Registros
        My.Forms.FrmReportes.ProgressBar1.Value = 0

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub
End Class
