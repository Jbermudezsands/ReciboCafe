Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class SrpDetalleRemision 
    Public Tara As Double, PesoNeto As Double, QQ As Double, Contador As Double

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.LblRef.Text = Contador
        Contador = Contador + 1
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Contador = 0
    End Sub
End Class
