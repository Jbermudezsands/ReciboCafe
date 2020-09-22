Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 


Public Class ArepBitacoraRecepcion
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public IdFinca As Double, IdCosecha As Double, IdProductor As Double, ListaCertificados As String, Lineas As Double
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
            Me.TxtFinal.Location = New Point(0.1, 2.05)


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
        Dim p As System.Drawing.PointF

        Lineas = (Me.LblNombres.Text.Length) / 35

        If Lineas > 3 Then
            Lineas = 4
        ElseIf Lineas <= 1 Then
            Lineas = 1
        Else
            Lineas = Int(Lineas)
        End If

        Select Case Lineas
            Case 1
                p.X = 0.075 : p.Y = 3.45
                Me.Label35.Location = p
                p.X = 0.75 : p.Y = 3.45
                Me.LblCedulas.Location = p

                p.X = 0.075 : p.Y = 3.65
                Me.Label39.Location = p
                p.X = 0.75 : p.Y = 3.65
                Me.LblFinca.Location = p

                p.X = 0.075 : p.Y = 3.85
                Me.Label61.Location = p
                p.X = 0.75 : p.Y = 3.85
                Me.LblPignorado.Location = p


                If Me.LblPignorado.Text <> "" Then
                    p.X = 0.075 : p.Y = 4.05
                    Me.Label40.Location = p
                    p.X = 0.075 : p.Y = 4.25
                    Me.Label42.Location = p
                    p.X = 0.75 : p.Y = 4.25
                    Me.LblCalidad.Location = p

                    p.X = 0.075 : p.Y = 4.45
                    Me.Label48.Location = p
                    p.X = 0.75 : p.Y = 4.45
                    Me.LblCategoria.Location = p

                    p.X = 0.075 : p.Y = 4.65
                    Me.Label41.Location = p
                    p.X = 0.75 : p.Y = 4.65
                    Me.LblEstado.Location = p

                    p.X = 0.075 : p.Y = 4.85
                    Me.Label45.Location = p
                    p.X = 0.75 : p.Y = 4.85
                    Me.LblDaño.Location = p

                    p.X = 0.075 : p.Y = 5.05
                    Me.Label49.Location = p
                    p.X = 0.75 : p.Y = 5.05
                    Me.LblHum.Location = p

                    p.X = 0.075 : p.Y = 5.3
                    Me.Label51.Location = p
                    p.X = 0.75 : p.Y = 5.3
                    Me.LblImp.Location = p

                    p.X = 0.05 : p.Y = 5.45
                    Me.Label53.Location = p
                    p.X = 0.05 : p.Y = 5.65
                    Me.Label55.Location = p
                    p.X = 0.8 : p.Y = 5.65
                    Me.LblIngreso.Location = p

                    p.X = 0.05 : p.Y = 5.85
                    Me.Label56.Location = p
                    p.X = 0.8 : p.Y = 5.85
                    Me.LblCompra.Location = p

                    p.X = 0.05 : p.Y = 6.05
                    Me.Label59.Location = p
                    p.X = 0.8 : p.Y = 6.05
                    Me.LblLiquidar.Location = p

                    If Me.LblCompra.Text = "" Then
                        Me.ReportHeader1.Height = 6.0
                    Else
                        Me.ReportHeader1.Height = 6.1
                    End If

                Else
                    p.X = 0.075 : p.Y = 3.85
                    Me.Label40.Location = p
                    p.X = 0.075 : p.Y = 4.05
                    Me.Label42.Location = p
                    p.X = 0.75 : p.Y = 4.05
                    Me.LblCalidad.Location = p

                    p.X = 0.075 : p.Y = 4.25
                    Me.Label48.Location = p
                    p.X = 0.75 : p.Y = 4.25
                    Me.LblCategoria.Location = p

                    p.X = 0.075 : p.Y = 4.45
                    Me.Label41.Location = p
                    p.X = 0.75 : p.Y = 4.45
                    Me.LblEstado.Location = p

                    p.X = 0.075 : p.Y = 4.65
                    Me.Label45.Location = p
                    p.X = 0.75 : p.Y = 4.65
                    Me.LblDaño.Location = p

                    p.X = 0.075 : p.Y = 4.85
                    Me.Label49.Location = p
                    p.X = 0.75 : p.Y = 4.85
                    Me.LblHum.Location = p

                    p.X = 0.075 : p.Y = 5.0
                    Me.Label51.Location = p
                    p.X = 0.75 : p.Y = 5.0
                    Me.LblImp.Location = p

                    p.X = 0.05 : p.Y = 5.15
                    Me.Label53.Location = p
                    p.X = 0.05 : p.Y = 5.35
                    Me.Label55.Location = p
                    p.X = 0.8 : p.Y = 5.35
                    Me.LblIngreso.Location = p

                    p.X = 0.05 : p.Y = 5.55
                    Me.Label56.Location = p
                    p.X = 0.8 : p.Y = 5.55
                    Me.LblCompra.Location = p

                    p.X = 0.05 : p.Y = 5.75
                    Me.Label59.Location = p
                    p.X = 0.8 : p.Y = 5.75
                    Me.LblLiquidar.Location = p

                    If Me.LblCompra.Text = "" Then
                        Me.ReportHeader1.Height = 6.0
                    Else
                        Me.ReportHeader1.Height = 6.1
                    End If

                End If

            Case 2

                p.X = 0.075 : p.Y = 3.65
                Me.Label35.Location = p
                p.X = 0.75 : p.Y = 3.65
                Me.LblCedulas.Location = p

                p.X = 0.075 : p.Y = 3.85
                Me.Label39.Location = p
                p.X = 0.75 : p.Y = 3.85
                Me.LblFinca.Location = p

                p.X = 0.075 : p.Y = 4.05
                Me.Label61.Location = p
                p.X = 0.75 : p.Y = 4.05
                Me.LblPignorado.Location = p

                If Me.LblPignorado.Text <> "" Then
                    p.X = 0.075 : p.Y = 4.25
                    Me.Label40.Location = p
                    p.X = 0.075 : p.Y = 4.82
                    Me.Label42.Location = p
                    p.X = 0.75 : p.Y = 4.82
                    Me.LblCalidad.Location = p
                    p.X = 0.075 : p.Y = 5.02
                    Me.Label48.Location = p
                    p.X = 0.75 : p.Y = 5.22
                    Me.LblCategoria.Location = p
                    p.X = 0.075 : p.Y = 5.22
                    Me.Label41.Location = p
                    p.X = 0.75 : p.Y = 5.42
                    Me.LblEstado.Location = p
                    p.X = 0.075 : p.Y = 5.62
                    Me.Label45.Location = p
                    p.X = 0.75 : p.Y = 5.62
                    Me.LblDaño.Location = p
                    p.X = 0.075 : p.Y = 5.82
                    Me.Label49.Location = p
                    p.X = 0.75 : p.Y = 5.82
                    Me.LblHum.Location = p
                    p.X = 0.075 : p.Y = 6.02
                    Me.Label51.Location = p
                    p.X = 0.75 : p.Y = 6.02
                    Me.LblImp.Location = p

                    p.X = 0.05 : p.Y = 6.22
                    Me.Label53.Location = p
                    p.X = 0.05 : p.Y = 6.42
                    Me.Label55.Location = p
                    p.X = 0.8 : p.Y = 6.42
                    Me.LblIngreso.Location = p

                    p.X = 0.05 : p.Y = 6.62
                    Me.Label56.Location = p
                    p.X = 0.8 : p.Y = 6.62
                    Me.LblCompra.Location = p
                    p.X = 0.05 : p.Y = 6.82
                    Me.Label59.Location = p
                    p.X = 0.8 : p.Y = 6.82
                    Me.LblLiquidar.Location = p

                    If Me.LblCompra.Text = "" Then
                        Me.ReportHeader1.Height = 6.427
                    Else
                        Me.ReportHeader1.Height = 6.677
                    End If

                Else
                    p.X = 0.075 : p.Y = 4.05
                    Me.Label40.Location = p
                    p.X = 0.075 : p.Y = 4.25
                    Me.Label42.Location = p
                    p.X = 0.75 : p.Y = 4.25
                    Me.LblCalidad.Location = p

                    p.X = 0.075 : p.Y = 4.45
                    Me.Label48.Location = p
                    p.X = 0.75 : p.Y = 4.45
                    Me.LblCategoria.Location = p

                    p.X = 0.075 : p.Y = 4.65
                    Me.Label41.Location = p
                    p.X = 0.75 : p.Y = 4.65
                    Me.LblEstado.Location = p

                    p.X = 0.075 : p.Y = 4.85
                    Me.Label45.Location = p
                    p.X = 0.75 : p.Y = 4.85
                    Me.LblDaño.Location = p

                    p.X = 0.075 : p.Y = 5.05
                    Me.Label49.Location = p
                    p.X = 0.75 : p.Y = 5.05
                    Me.LblHum.Location = p

                    p.X = 0.075 : p.Y = 5.25
                    Me.Label51.Location = p
                    p.X = 0.75 : p.Y = 5.25
                    Me.LblImp.Location = p

                    p.X = 0.05 : p.Y = 5.45
                    Me.Label53.Location = p
                    p.X = 0.05 : p.Y = 5.65
                    Me.Label55.Location = p
                    p.X = 0.8 : p.Y = 5.65
                    Me.LblIngreso.Location = p

                    p.X = 0.05 : p.Y = 5.85
                    Me.Label56.Location = p
                    p.X = 0.8 : p.Y = 5.85
                    Me.LblCompra.Location = p

                    p.X = 0.05 : p.Y = 6.05
                    Me.Label59.Location = p
                    p.X = 0.8 : p.Y = 6.05
                    Me.LblLiquidar.Location = p

                    If Me.LblCompra.Text = "" Then
                        Me.ReportHeader1.Height = 6.427
                    Else
                        Me.ReportHeader1.Height = 6.677
                    End If


                End If

            Case 3

                p.X = 0.075 : p.Y = 3.85
                Me.Label35.Location = p
                p.X = 0.75 : p.Y = 3.85
                Me.LblCedulas.Location = p

                p.X = 0.075 : p.Y = 4.05
                Me.Label39.Location = p
                p.X = 0.75 : p.Y = 4.05
                Me.LblFinca.Location = p

                p.X = 0.075 : p.Y = 4.25
                Me.Label61.Location = p
                p.X = 0.75 : p.Y = 4.25
                Me.LblPignorado.Location = p

                If Me.LblPignorado.Text <> "" Then
                    p.X = 0.075 : p.Y = 4.45
                    Me.Label40.Location = p
                    p.X = 0.075 : p.Y = 4.65
                    Me.Label42.Location = p
                    p.X = 0.75 : p.Y = 4.65
                    Me.LblCalidad.Location = p

                    p.X = 0.075 : p.Y = 4.85
                    Me.Label48.Location = p
                    p.X = 0.75 : p.Y = 4.85
                    Me.LblCategoria.Location = p

                    p.X = 0.075 : p.Y = 5.05
                    Me.Label41.Location = p
                    p.X = 0.75 : p.Y = 5.05
                    Me.LblEstado.Location = p

                    p.X = 0.075 : p.Y = 5.25
                    Me.Label45.Location = p
                    p.X = 0.75 : p.Y = 5.25
                    Me.LblDaño.Location = p

                    p.X = 0.075 : p.Y = 5.45
                    Me.Label49.Location = p
                    p.X = 0.75 : p.Y = 5.45
                    Me.LblHum.Location = p

                    p.X = 0.075 : p.Y = 5.65
                    Me.Label51.Location = p
                    p.X = 0.75 : p.Y = 5.65
                    Me.LblImp.Location = p

                    p.X = 0.05 : p.Y = 5.85
                    Me.Label53.Location = p
                    p.X = 0.05 : p.Y = 6.05
                    Me.Label55.Location = p
                    p.X = 0.8 : p.Y = 6.05
                    Me.LblIngreso.Location = p

                    p.X = 0.05 : p.Y = 6.25
                    Me.Label56.Location = p
                    p.X = 0.8 : p.Y = 6.25
                    Me.LblCompra.Location = p

                    p.X = 0.05 : p.Y = 6.45
                    Me.Label59.Location = p
                    p.X = 0.8 : p.Y = 6.45
                    Me.LblLiquidar.Location = p

                    If Me.LblCompra.Text = "" Then
                        Me.ReportHeader1.Height = 6.427
                    Else
                        Me.ReportHeader1.Height = 6.677
                    End If

                Else
                    p.X = 0.075 : p.Y = 4.25
                    Me.Label40.Location = p
                    p.X = 0.075 : p.Y = 4.82
                    Me.Label42.Location = p
                    p.X = 0.75 : p.Y = 4.82
                    Me.LblCalidad.Location = p
                    p.X = 0.075 : p.Y = 5.02
                    Me.Label48.Location = p
                    p.X = 0.75 : p.Y = 5.22
                    Me.LblCategoria.Location = p
                    p.X = 0.075 : p.Y = 5.22
                    Me.Label41.Location = p
                    p.X = 0.75 : p.Y = 5.42
                    Me.LblEstado.Location = p
                    p.X = 0.075 : p.Y = 5.62
                    Me.Label45.Location = p
                    p.X = 0.75 : p.Y = 5.62
                    Me.LblDaño.Location = p
                    p.X = 0.075 : p.Y = 5.82
                    Me.Label49.Location = p
                    p.X = 0.75 : p.Y = 5.82
                    Me.LblHum.Location = p
                    p.X = 0.075 : p.Y = 6.02
                    Me.Label51.Location = p
                    p.X = 0.75 : p.Y = 6.02
                    Me.LblImp.Location = p

                    p.X = 0.05 : p.Y = 6.22
                    Me.Label53.Location = p
                    p.X = 0.05 : p.Y = 6.42
                    Me.Label55.Location = p
                    p.X = 0.8 : p.Y = 6.42
                    Me.LblIngreso.Location = p

                    p.X = 0.05 : p.Y = 6.62
                    Me.Label56.Location = p
                    p.X = 0.8 : p.Y = 6.62
                    Me.LblCompra.Location = p
                    p.X = 0.05 : p.Y = 6.82
                    Me.Label59.Location = p
                    p.X = 0.8 : p.Y = 6.82
                    Me.LblLiquidar.Location = p

                    If Me.LblCompra.Text = "" Then
                        Me.ReportHeader1.Height = 6.427
                    Else
                        Me.ReportHeader1.Height = 6.677
                    End If


                End If
            Case Else

                If Me.LblPignorado.Text = "" Then
                    p.X = 0.075 : p.Y = 4.25
                    Me.Label40.Location = p
                    p.X = 0.075 : p.Y = 4.52
                    Me.Label42.Location = p
                    p.X = 0.75 : p.Y = 4.52
                    Me.LblCalidad.Location = p
                    p.X = 0.075 : p.Y = 4.72
                    Me.Label48.Location = p
                    p.X = 0.75 : p.Y = 4.92
                    Me.LblCategoria.Location = p
                    p.X = 0.075 : p.Y = 4.92
                    Me.Label41.Location = p
                    p.X = 0.75 : p.Y = 5.12
                    Me.LblEstado.Location = p
                    p.X = 0.075 : p.Y = 5.32
                    Me.Label45.Location = p
                    p.X = 0.75 : p.Y = 5.32
                    Me.LblDaño.Location = p
                    p.X = 0.075 : p.Y = 5.52
                    Me.Label49.Location = p
                    p.X = 0.75 : p.Y = 5.52
                    Me.LblHum.Location = p
                    p.X = 0.075 : p.Y = 5.72
                    Me.Label51.Location = p
                    p.X = 0.75 : p.Y = 5.72
                    Me.LblImp.Location = p

                    p.X = 0.05 : p.Y = 5.92
                    Me.Label53.Location = p
                    p.X = 0.05 : p.Y = 6.12
                    Me.Label55.Location = p
                    p.X = 0.8 : p.Y = 6.12
                    Me.LblIngreso.Location = p

                    p.X = 0.05 : p.Y = 6.32
                    Me.Label56.Location = p
                    p.X = 0.8 : p.Y = 6.32
                    Me.LblCompra.Location = p
                    p.X = 0.05 : p.Y = 6.52
                    Me.Label59.Location = p
                    p.X = 0.8 : p.Y = 6.52
                    Me.LblLiquidar.Location = p


                    If Me.LblCompra.Text = "" Then
                        Me.ReportHeader1.Height = 6.427
                    Else
                        Me.ReportHeader1.Height = 6.677
                    End If

                End If

        End Select



    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim p As System.Drawing.PointF

        Me.TxtCertificados.Text = ListaCertificados

        If ListaCertificados = "" Then

            Me.Label60.Visible = False
            p.X = 0 : p.Y = 0
            Me.LblHora.Location = p
            p.X = 0.1 : p.Y = 0.3
            Me.Label2.Location = p
            p.X = 0.35 : p.Y = 0.3
            Me.Label58.Location = p
            p.X = 0.8 : p.Y = 0.3
            Me.Label1.Location = p
            p.X = 1.45 : p.Y = 0.3
            Me.Label57.Location = p
            p.X = 1.93 : p.Y = 0.3
            Me.Label37.Location = p
            Me.GroupHeader1.Height = 0.59
        End If

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub
End Class
