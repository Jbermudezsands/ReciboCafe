Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 


Public Class ArepBitacoraRecepcion
    Public IdFinca As Double, IdCosecha As Double, IdProductor As Double
    Private CertificadoSubReport As SrpCertificado = Nothing


    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Dim SqlString As String
        SqlString = "SELECT Certificado.Code,Certificado.Descripcion, CertificadoXFinca.Vigencia FROM  CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca INNER JOIN Certificado ON CertificadoXFinca.IdCertificado = Certificado.IdCertificado  " & _
                    "WHERE (Finca.IdFinca = " & IdFinca & ") AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & " ) ORDER BY CertificadoXFinca.Vigencia DESC"

        Me.LblCosecha.Text = My.Forms.FrmRecepcion.LblCosecha.Text

        '//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        CType(Me.SubReportCertificado.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        CType(Me.SubReportCertificado.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString
        My.Application.DoEvents()
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub

    Private Sub ArepBitacoraRecepcion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        If CertificadoSubReport Is Nothing Then
            CertificadoSubReport = New SrpCertificado
            Me.SubReportCertificado.Report = CertificadoSubReport
            Me.SubReportCertificado.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        End If

        Me.LblTipoCompra.Text = "Recibo Cafe " & FrmRecepcion.CboTipoCafe.Text
        Me.LblFechaOrden.Text = FrmRecepcion.FechaRecibo
        Me.LblHoraRecibo.Text = Format(FrmRecepcion.Hora, "hh:mm:ss tt")
        Me.LblLocalidad.Text = FrmRecepcion.Localidad
        Me.LblHora.Text = "Impreso: " & Now
        Me.LblCedulas.Text = FrmRecepcion.Cedula
        Me.LblFinca.Text = FrmRecepcion.Finca
        Me.LblCalidad.Text = FrmRecepcion.TipoCalidad
        Me.LblCategoria.Text = FrmRecepcion.Categoria
        Me.LblEstado.Text = FrmRecepcion.Estado
        Me.LblDaño.Text = FrmRecepcion.Daño
        Me.LblHum.Text = FrmRecepcion.Humedad
        Me.LblImp.Text = FrmRecepcion.Imperfeccion
        Me.LblIngreso.Text = FrmRecepcion.TipoIngreso
        Me.LblCompra.Text = FrmRecepcion.TipoCompra
        Me.LblLiquidar.Text = FrmRecepcion.LocalidadLiquidar
        If My.Forms.FrmRecepcion.Pignorado = "" Then
            Label61.Visible = False
        Else
            Me.LblPignorado.Text = FrmRecepcion.Pignorado
        End If
        Me.LblCosecha.Text = My.Forms.FrmRecepcion.Cosecha

        'Me.LblCertificado.Text = "No.Certificado: " & FrmRecepcion.NumeroCertificado & " Vence: " & Format(FrmRecepcion.FechaVence, "dd/MM/yyyy")


        Me.LblOrden.Text = FrmRecepcion.NRecibo
        Me.TxtOreado.Text = FrmRecepcion.EqOreado
        Me.TxtReal.Text = FrmRecepcion.EqReal
        Me.TxtQQOreado.Text = Format(FrmRecepcion.QQOreado, "##,##0.00")

        If FrmRecepcion.TipoCafe = "PERGAMINO" Then
            Me.LblCompra.Visible = True
            Me.LblLiquidar.Visible = True
            Me.Label56.Visible = True
            Me.Label59.Visible = True

        Else
            Me.LblCompra.Visible = False
            Me.LblLiquidar.Visible = False
            Me.Label56.Visible = False
            Me.Label59.Visible = False
        End If



        Me.TxtFinal.Text = ""

        If FrmRecepcion.TipoCafe = "PERGAMINO" Then
            If FrmRecepcion.TipoCompra = "Depósito" Then
                Me.TxtFinal.Text = "AP1ra (Arabe Pergamino Primera)/ AP2da(Arabe Pergamino Segunda)/ MP1ra(Mara Pergamino Primera) Este café queda a la orden irrevocable de Exportadora Atlantic S.A. A fin de formalizar la venta, el vendedor tiene la opción de vender el café entregado en cualquier momento a más tardar el " & FrmRecepcion.AñoCosecha & ", al precio que Exportadora Atlantic S.A. indique, Si a esta fecha no se ha fijado el precio, el café entregado se considera vendido al precio que ese día determine Exportadora Atlantic S.A. siendo esta opción válida solo para Exportadora Atlantic S.A."

            End If
        Else
            If FrmRecepcion.TipoCompra = "Depósito" Then
                Me.TxtFinal.Text = "AP1ra (Arabe Pergamino Primera)/ AP2da (Arabe Pergamino Segunda)/ MP1ra (Mara Pergamino Primera)/ FRUTO(Arabe Pergamino Fruto)/BROZA(Arabe Pergamino Broza)/ APS(Arabe Pergamino Seco)/ MPS(Mara Pergamino Seco)/ MP2da(Mara Pergamino Segunda)/ PULPON(Arabe Pergamino Pulpon) Este café es precalificado en agencia y centro de acopio. Para efectos de liquidación la clasificación oficial del café respecto a: Calidades, Humedad y Estado físico se emitirá por parte de Exportadora Atlantic S.A. en el beneficio seco como resultado del proceso de beneficiado. "
                'Me.TxtFinal.Text = "AP1ra (Arabe Pergamino Primera)/AP2da(Arabe Pergamino Segunda)/MP1ra(Mara Pergamino Primera) Este café queda a la orden irrevocable de Exportadora Atlantic S.A. A fin de formalizar la venta, el vendedor tiene la opción de vender el café entregado en cualquier momento a más tardar el " & FrmRecepcion.AñoCosecha & ", al precio que Exportadora Atlantic S.A. indique, Si a esta fecha no se ha fijado el precio, el café entregado se considera vendido al precio que ese día determine Exportadora Atlantic S.A. siendo esta opción válida solo para Exportadora Atlantic S.A."
            ElseIf FrmRecepcion.TipoCompra = "Maquila" Then
                'Me.TxtFinal.Text = "AP1ra (Arabe Pergamino Primera)/AP2da (Arabe Pergamino Segunda)/MP1ra (Mara Pergamino Primera)/FRUTO(Arabe Pergamino Fruto)/BROZA(Arabe Pergamino Broza)/APS(Arabe Pergamino Seco)/MPS(Mara Pergamino Seco)/MP2da(Mara Pergamino Segunda)/PULPON(Arabe Pergamino Pulpon) Este café es precalificado en agencia y centro de acopio. Para efectos de liquidación la clasificación oficial del café respecto a: Calidades, Humedad y Estado físico se emitirá por parte de Exportadora Atlantic S.A. en el beneficio seco como resultado del proceso de beneficiado. "
            End If
        End If
        'Me.TxtPesoNeto.Text = FrmRecepcion.txtsubtotal.Text

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format

    End Sub
End Class
