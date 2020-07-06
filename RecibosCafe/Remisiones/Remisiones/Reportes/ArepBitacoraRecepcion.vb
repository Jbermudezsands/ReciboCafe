Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 


Public Class ArepBitacoraRecepcion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdFinca As Double, IdCosecha As Double, IdProductor As Double, ListaCertificados As String
    'Private CertificadoSubReport As SrpCertificado = Nothing


    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Cont As Double, i As Double


        SqlString = "SELECT Certificado.Code,Certificado.Descripcion, CertificadoXFinca.Vigencia FROM  CertificadoXFinca INNER JOIN Finca ON CertificadoXFinca.IdFinca = Finca.IdFinca INNER JOIN Certificado ON CertificadoXFinca.IdCertificado = Certificado.IdCertificado  " & _
                    "WHERE (Finca.IdFinca = " & IdFinca & ") AND (CertificadoXFinca.IdCosecha = " & IdCosecha & ") AND (Finca.IdProductor = " & IdProductor & " ) ORDER BY CertificadoXFinca.Vigencia DESC"

        Me.LblCosecha.Text = My.Forms.FrmRecepcion.LblCosecha.Text

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        Cont = DataSet.Tables("Consulta").Rows.Count
        i = 0
        ListaCertificados = ""
        Do While Cont > i
            If i = 0 Then
                ListaCertificados = "Certificados: " & DataSet.Tables("Consulta").Rows(i)("Descripcion")
            Else
                ListaCertificados = ListaCertificados & "," & DataSet.Tables("Consulta").Rows(i)("Descripcion")
            End If

            i = i + 1
        Loop


        ''//////////////////////////////ACTUALIZO EL REPORTE CON LA CONSULTA //////////////////////////////////////////////////////////////////////
        'CType(Me.SubReportCertificado.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).ConnectionString = Conexion
        'CType(Me.SubReportCertificado.Report.DataSource, DataDynamics.ActiveReports.DataSources.SqlDBDataSource).SQL = SqlString
        My.Application.DoEvents()
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        If Me.TxtObservaciones.Text = "" Then
            Me.Label62.Visible = False
            Me.Label50.Location = New Point(0, 1.35)
            Me.Label52.Visible = False
            Me.Label54.Visible = True
            Me.Label46.Location = New Point(0.3, 1.75)
            Me.TxtReal.Location = New Point(1.175, 1.75)
            Me.Label47.Location = New Point(1.95, 1.75)


        End If
    End Sub

    Private Sub ArepBitacoraRecepcion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        'If CertificadoSubReport Is Nothing Then
        '    CertificadoSubReport = New SrpCertificado
        '    Me.SubReportCertificado.Report = CertificadoSubReport
        '    Me.SubReportCertificado.Report.DataSource = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        'End If

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
            Me.ReportHeader1.Height = 6.448
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


    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Me.TxtCertificados.Text = ListaCertificados

        If ListaCertificados = "" Then
            Me.LblHora.Location = New Point(0.025, 0.4)
            Me.Label2.Location = New Point(0.1, 0.65)
            Me.Label58.Location = New Point(0.35, 0.65)
            Me.Label1.Location = New Point(0.8, 0.65)
            Me.Label59.Location = New Point(1.45, 0.65)
            Me.Label37.Location = New Point(1.925, 0.65)
            Me.GroupHeader1.Height = 0.99
        End If

    End Sub
End Class
