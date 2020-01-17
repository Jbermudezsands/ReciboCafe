
Public Class FrmTecladoLiqui
    Public Numero As String, RangoInicial As Double, RangoFinal As Double, CodigoLiquidacion As Integer, CodigoSugerido As Integer
    Public registros As Integer, i As Integer, NumComp As Integer, ForatoNum As Double = 0, SerieBlanco As Boolean, Serie As String, Consecutivo As Integer
    Public Sql As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, j As Integer, ConsecutivoLiquidacion As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmTeclado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case QuienTec
            Case "Liquida Manual Deposito"
                Quien = "Load"
                Me.CboSerieLiq.ResetText()
                Me.TxtNumero.Text = ""
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////BUSCO SI EXISTE EL CONSECUTIVO PARA RECIBOS ///////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"
                Sql = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdTipoCompra='" & FrmLiquidacion.IdTipoCompra & "') AND (IdTipoCafe = '1')  AND (IdTipoDocumento =  976 ) AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "SerieLiq")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")
                registros = DataSet.Tables("SerieLiq").Rows.Count
                i = 0
                Me.CboSerieLiq.Enabled = False
                Me.CboSerieLiq.ResetText()
                SerieBlanco = False
                Do While registros > i
                    Serie = DataSet.Tables("SerieLiq").Rows(i)("Serie")
                    RangoInicial = DataSet.Tables("SerieLiq").Rows(i)("RangoInicial")
                    RangoFinal = DataSet.Tables("SerieLiq").Rows(i)("RangoFinal")
                    For j = RangoInicial To RangoFinal
                        ConsecutivoLiquidacion = BuscaConsecutivoLiquidacionManual(Serie, 1, FrmLiquidacion.IdCosecha, FrmLiquidacion.IdLocalidadLiqui, FrmLiquidacion.IdTipoCompra, Format(j, "00000#"))
                        If ConsecutivoLiquidacion = "000000" Then
                            Exit For
                        End If
                    Next
                    If ConsecutivoLiquidacion = "000000" Then
                        Consecutivo = j
                        Me.TxtNumero.Text = Format(Consecutivo, "00000#")
                        Exit Do
                    Else
                        Me.TxtNumero.Text = ConsecutivoLiquidacion
                        Me.CboSerieLiq.Text = Serie
                        Exit Do
                    End If
                    i = i + 1
                Loop
                DataSet.Tables("SerieLiq").Reset()

                Sql = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdTipoCafe = '1') AND (IdTipoCompra = " & FrmLiquidacion.IdTipoCompra & ") AND (IdTipoDocumento = 976) AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Combo")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")
                registros = DataSet.Tables("Combo").Rows.Count
                i = 0
                Me.CboSerieLiq.Items.Clear()
                SerieBlanco = False
                Do While registros > i
                    Me.CboSerieLiq.Enabled = True
                    Serie = DataSet.Tables("Combo").Rows(i)("Serie")
                    If Serie <> "" Then
                        Me.CboSerieLiq.Items.Add(Serie)
                        Me.CboSerieLiq.Enabled = True
                        'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                    Else
                        'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                        If SerieBlanco = False Then
                            Me.CboSerieLiq.Items.Add(Serie)
                            SerieBlanco = True
                        End If
                    End If
                    i = i + 1
                Loop

                Quien = ""

                '///////////////////// BUSCO RANGOS DE LA TABLA PREINGRESO //////////////////////////////
      

                '//////Para cuando la liquidacion es tipo Depósitos Automáticos


            Case "Distribucion"
                TxtNumero.Text = ""
                Me.Label1.Visible = False
                C1Button3.Visible = False
                C1Button1.Height = 185
            Case "LiquidacionNumero"
                TxtNumero.Text = ""
                Me.Label1.Visible = False
                C1Button3.Visible = False
                Label2.Visible = False
                Me.CboSerieLiq.Visible = False
                C1Button1.Height = 185
            Case "RemisionNumero"
                Quien = "Load"
                Me.CboSerieLiq.ResetText()
                Me.TxtNumero.Text = ""
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////BUSCO SI EXISTE EL CONSECUTIVO PARA REMISION ///////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"
                Sql = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & FrmRemision2.TxtIdLugarAcopio.Text & ") AND (IdCosecha = " & FrmRemision2.TextIdCosecha.Text & ") AND (IdTipoCafe = '" & FrmRemision2.IdTipoCafe & "')  AND (IdTipoDocumento =  975 ) AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "SerieLiq")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")
                registros = DataSet.Tables("SerieLiq").Rows.Count
                i = 0
                Me.CboSerieLiq.Enabled = False
                Me.CboSerieLiq.ResetText()
                SerieBlanco = False
                Do While registros > i
                    Serie = DataSet.Tables("SerieLiq").Rows(i)("Serie")
                    RangoInicial = DataSet.Tables("SerieLiq").Rows(i)("RangoInicial")
                    RangoFinal = DataSet.Tables("SerieLiq").Rows(i)("RangoFinal")
                    For j = RangoInicial To RangoFinal
                        ConsecutivoLiquidacion = BuscaConsecutivoRemisionManual(Serie, FrmRemision2.IdTipoCafe, FrmRemision2.TextIdCosecha.Text, FrmRemision2.TxtIdLugarAcopio.Text, Format(j, "00000#"))
                        If ConsecutivoLiquidacion = "000000" Then
                            Exit For
                        End If
                    Next
                    If ConsecutivoLiquidacion = "000000" Then
                        Consecutivo = j
                        Me.TxtNumero.Text = Format(Consecutivo, "00000#")
                        Exit Do
                    Else
                        Me.TxtNumero.Text = ConsecutivoLiquidacion
                        Me.CboSerieLiq.Text = Serie
                        Exit Do
                    End If
                    i = i + 1
                Loop
                DataSet.Tables("SerieLiq").Reset()

                Sql = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & FrmRemision2.TxtIdLugarAcopio.Text & ") AND (IdCosecha = " & FrmRemision2.TextIdCosecha.Text & ") AND (IdTipoCafe = '" & FrmRemision2.IdTipoCafe & "') AND (IdTipoDocumento = 975) AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Combo")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")
                registros = DataSet.Tables("Combo").Rows.Count
                i = 0
                Me.CboSerieLiq.Items.Clear()
                SerieBlanco = False
                Do While registros > i
                    Me.CboSerieLiq.Enabled = True
                    Serie = DataSet.Tables("Combo").Rows(i)("Serie")
                    If Serie <> "" Then
                        Me.CboSerieLiq.Items.Add(Serie)
                        Me.CboSerieLiq.Enabled = True
                        'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                    Else
                        'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                        If SerieBlanco = False Then
                            Me.CboSerieLiq.Items.Add(Serie)
                            SerieBlanco = True
                        End If
                    End If
                    i = i + 1
                Loop

                Quien = ""
        End Select
    End Sub

    Private Sub CmdBoton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton1.Click
        If Me.TxtNumero.Text = "" Then
            Me.Label1.Visible = False
            Me.TxtNumero.Text = "1"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "1"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton2.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "2"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "2"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton3.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "3"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "3"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton4.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "4"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "4"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton5.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "5"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "5"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton6.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "6"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "6"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton7.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "7"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "7"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton8.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "8"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "8"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton9.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "9"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "9"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub C1Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button12.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "+"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "+"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub CmdBoton0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton0.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "0"
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "0"
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub C1Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button10.Click
        If Me.TxtNumero.Text <> "" Then
            Me.TxtNumero.Text = Mid(Me.TxtNumero.Text, 1, Len(Me.TxtNumero.Text) - 1)
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Select Case QuienTec
            Case "Liquida Manual Deposito"
  
            Case "LiquidacionNumero"
 
            Case "Distribucion"

            Case "RemisionNumero"
                My.Forms.FrmRemision2.CboRemTipIngr.Text = "Automatico"
                My.Forms.FrmRemision2.ConsecutivoRemision()
                'My.Forms.FrmRemision2.CboRemTipIngr_TextChanged(sender, e)

        End Select

        Numero = 0
        Serie = "?"

        Me.Close()
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Dim NumComp As Double, registros As Double, TotalReg As Double, CodigoLiqui As Double, i As Integer, NumeroTecla As Double
        Dim SqlString As String, FueraRango As Boolean, Minimo As Double, Maximo As Double
        Select Case QuienTec
            Case "Liquida Manual Deposito"
                If Len(Trim(Me.TxtNumero.Text)) <> 6 Then
                    MsgBox("Debe Digitar Numeros de 6 Digitos")
                    Exit Sub
                End If

                If Me.CboSerieLiq.Text <> "" Then
                    Serie = Me.CboSerieLiq.Text
                Else
                    Serie = "?"
                End If

                If Me.TxtNumero.Text = "" Then
                    Numero = 0
                    NumeroTecla = 0
                    Exit Sub
                Else
                    NumeroTecla = Me.TxtNumero.Text
                    NumeroTecla = Format(NumeroTecla, "00000#")
                    Numero = Format(NumeroTecla, "00000#")
                End If

                SqlString = "SELECT  IdLiquidacionPergamino, Codigo, Fecha, Precio, IdEstadoFisico, IdCategoriaImperfeccion, IdEstadoDocumento, IdMoneda, IdMonedaPreecio, IdMunicipio, SincronizadoESC, NumeroReembolso, IdTipoIngreso, IdCosecha,  IdLocalidad, Cod_Proveedor, IdTipoCompra, PrecioAutoriza, TotalDeducciones, ChkRentDef, ChkRent2, ChkRent3, ChkMuncipal, IdTipoCambio, Serie FROM   LiquidacionPergamino " & _
                            "WHERE (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (IdTipoCompra = " & FrmLiquidacion.IdTipoCompra & ") AND (Codigo = '" & Numero & "') ORDER BY Codigo DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Numero1")
                If DataSet.Tables("Numero1").Rows.Count <> 0 Then
                    MsgBox("Ya existe un Recibo con este Numero Recibo", MsgBoxStyle.Critical, "Liquidacion")
                    Me.TxtNumero.Text = ""
                    DataSet.Tables("Numero1").Reset()
                    Exit Sub
                End If

                If Me.CboSerieLiq.Text = "" Then
                    SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (Activo = 1) AND (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdTipoCafe = 1) AND (IdTipoCompra = " & FrmLiquidacion.IdTipoCompra & ") AND (IdTipoDocumento = 976) AND (Activo = 1) AND  (Serie = ' ') OR  (Serie IS NULL)"
                Else
                    SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (Activo = 1) AND (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdTipoCafe = 1) AND (IdTipoCompra = " & FrmLiquidacion.IdTipoCompra & ") AND (IdTipoDocumento = 976) AND (Activo = 1) AND (Serie = '" & Me.CboSerieLiq.Text & "')"
                End If

                'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"

                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Serie")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")

                i = 0
                registros = DataSet.Tables("Serie").Rows.Count
                FueraRango = False
                Do While registros > i

                    Minimo = DataSet.Tables("Serie").Rows(i)("RangoInicial")
                    Maximo = DataSet.Tables("Serie").Rows(i)("RangoFinal")
                    FueraRango = True

                    If NumeroTecla >= Minimo Then
                        If NumeroTecla <= Maximo Then
                            FueraRango = False
                        End If
                    End If
                    If FueraRango = False Then
                        Exit Do
                    End If

                    i = i + 1
                Loop

                If FueraRango = True Then
                    MsgBox("El Numero Digitado esta Fuera de Rango", MsgBoxStyle.Critical, "Recibo")
                    Exit Sub
                End If
                DataSet.Tables("Numero1").Reset()
                Me.Close()

                'If Me.TxtNumero.Text = "" Then
                '    Numero = 0
                '    NumeroTecla = 0
                '    Exit Sub
                'Else
                '    NumeroTecla = Me.TxtNumero.Text
                '    NumeroTecla = Format(NumeroTecla, "00000#")
                '    Numero = NumeroTecla
                'End If

                ''/////////////////////////BUSCO NUEVAMENTE TODAS LAS LIQUIDACIONES PARA COMPARAR EL CODIGO QUE DIGITARON//////////////////////////////////////////
                'Sql = "SELECT   Codigo  FROM   LiquidacionPergamino  WHERE (IdTipoCafe = 1) AND (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (IdTipoCompra = " & FrmLiquidacion.IdTipoCompra & ") AND (Codigo = '" & Format(NumeroTecla, "00000#") & "') ORDER BY Codigo DESC"
                'DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                'DataAdapter.Fill(DataSet, "CodLiquidacion")
                'registros = DataSet.Tables("CodLiquidacion").Rows.Count
                ''//////// GUARDO EL CODIGO DIGITADO EN UNA VARIABLE PARA PODER COPARARLO CON LOS DE LOS REGISTROS///////////
                'If registros <> 0 Then
                '    MsgBox("ESTE CODIGO YA ESTA REGISTRADO", MsgBoxStyle.Critical, "Liquidacion")
                '    DataSet.Tables("CodLiquidacion").Reset()
                '    My.Forms.FrmLiquidacion.CboTipIngreso.Text = "Automatico"
                '    Me.Close()
                '    Exit Sub
                'Else
                '    If Me.TxtNumero.Text = "" Then
                '        Numero = 0
                '        My.Forms.FrmLiquidacion.CboTipIngreso.Text = "Automatico"
                '    ElseIf CDbl(Me.TxtNumero.Text) >= RangoInicial And CDbl(Me.TxtNumero.Text) <= RangoFinal Then
                '        Numero = Me.TxtNumero.Text
                '        Me.Close()
                '    Else
                '        MsgBox("ESTE NUMERO NO ESTA EN EL RANGO DE PREINGRESO", MsgBoxStyle.Critical, "Liquidacion")
                '        My.Forms.FrmLiquidacion.CboTipIngreso.Text = "Automatico"
                '        Me.Close()
                '        Exit Sub
                '    End If
                'End If
                'DataSet.Tables("CodLiquidacion").Reset()
                ''NumComp = 0
                ''If Me.TxtNumero.Text = "" Then
                ''    NumComp = 0
                ''Else
                ''    NumComp = Me.TxtNumero.Text
                ''End If
            Case "LiquidacionNumero"
                If Me.TxtNumero.Text = "" Then
                    ForatoNum = 0
                Else
                    ForatoNum = CDbl(Me.TxtNumero.Text)
                End If
                Numero = Format(ForatoNum, "##,##0.00")
                Me.Close()
            Case "Distribucion"
                If Me.TxtNumero.Text = "" Then
                    ForatoNum = 0
                Else
                    ForatoNum = CDbl(Me.TxtNumero.Text)
                End If
                Me.Close()

            Case "RemisionNumero"
                If Len(Trim(Me.TxtNumero.Text)) <> 6 Then
                    MsgBox("Debe Digitar Numeros de 6 Digitos")
                    Exit Sub
                End If

                If Me.CboSerieLiq.Text <> "" Then
                    Serie = Me.CboSerieLiq.Text
                Else
                    Serie = "?"
                End If

                If Me.TxtNumero.Text = "" Then
                    Numero = 0
                    NumeroTecla = 0
                    Exit Sub
                Else
                    NumeroTecla = Me.TxtNumero.Text
                    NumeroTecla = Format(NumeroTecla, "00000#")
                    Numero = Format(NumeroTecla, "00000#")
                End If

                'SqlString = "SELECT        IdRemisionPergamino, Codigo, FechaCarga, Fecha, HoraSalida, Observacion, IdCosecha, IdLugarAcopio, IdCalidad, IdEstadoDocumento, IdConductor, IdEmpresaTransporte, IdVehiculo, IdDestino, IdTipoCafe, IdTipoIngreso,                           IdUMedida, IdElaboradorPor, IdUsuario, IdCompany, FechaModificacion, Serie FROM            RemisionPergamino WHERE        (IdCosecha = '" & FrmRemision2.TextIdCosecha.Text & "') AND (IdLugarAcopio = '" & FrmRemision2.TxtIdLugarAcopio.Text & "') AND (Codigo = '" & Numero & "') ORDER BY IdRemisionPergamino DESC   "

                SqlString = "SELECT IdRemisionPergamino, Codigo, FechaCarga, Fecha, HoraSalida, Observacion, IdCosecha, IdLugarAcopio, IdCalidad, IdEstadoDocumento, IdConductor, IdEmpresaTransporte, IdVehiculo, IdDestino, IdTipoCafe, IdTipoIngreso,IdUMedida, IdElaboradorPor, IdUsuario, IdCompany, FechaModificacion, Serie FROM RemisionPergamino " & _
                             "WHERE (IdCosecha = " & Trim(FrmRemision2.TextIdCosecha.Text) & ") AND (IdLugarAcopio = " & FrmRemision2.TxtIdLugarAcopio.Text & ") AND (Codigo = '" & Numero & "') ORDER BY IdRemisionPergamino DESC   "
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Numero1")
                If DataSet.Tables("Numero1").Rows.Count <> 0 Then
                    MsgBox("Ya existe una Remision con este Numero Recibo", MsgBoxStyle.Critical, "Liquidacion")
                    Me.TxtNumero.Text = ""
                    DataSet.Tables("Numero1").Reset()
                    Exit Sub
                End If

                If Me.CboSerieLiq.Text = "" Then
                    SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = '" & FrmRemision2.TxtIdLugarAcopio.Text & "') AND (Activo = 1) AND (IdCosecha = " & FrmRemision2.TextIdCosecha.Text & ") AND (IdTipoCafe ='" & FrmRemision2.IdTipoCafe & "' ) AND (IdTipoDocumento = 975) AND (Activo = 1) AND  (Serie = ' ') OR  (Serie IS NULL)"
                Else
                    SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & FrmRemision2.TxtIdLugarAcopio.Text & ") AND (Activo = 1) AND (IdCosecha = " & FrmRemision2.TextIdCosecha.Text & ") AND (IdTipoCafe ='" & FrmRemision2.IdTipoCafe & "' )  AND (IdTipoDocumento = 975) AND (Activo = 1) AND (Serie = '" & Me.CboSerieLiq.Text & "')"
                End If

                'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"

                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Serie")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")

                i = 0
                registros = DataSet.Tables("Serie").Rows.Count
                FueraRango = False
                Do While registros > i

                    Minimo = DataSet.Tables("Serie").Rows(i)("RangoInicial")
                    Maximo = DataSet.Tables("Serie").Rows(i)("RangoFinal")
                    FueraRango = True

                    If NumeroTecla >= Minimo Then
                        If NumeroTecla <= Maximo Then
                            FueraRango = False
                        End If
                    End If
                    If FueraRango = False Then
                        Exit Do
                    End If

                    i = i + 1
                Loop

                If FueraRango = True Then
                    MsgBox("El Numero Digitado esta Fuera de Rango", MsgBoxStyle.Critical, "Recibo")
                    Exit Sub
                End If
                DataSet.Tables("Numero1").Reset()
                Me.Close()
        End Select
    End Sub

    Private Sub BtnPunto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPunto.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "0."
            Me.Label1.Visible = False
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "."
            Me.Label1.Visible = False
        End If
    End Sub
    Private Sub C1Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button3.Click
        Select Case QuienTec
            Case "Liquida Manual Deposito"

                'If Me.TxtNumero.Text <> "" Then
                '    Me.TxtNumero.Text = ""
                '    Me.Label1.Text = ""
                'Else
                '    RangoInicial = 0
                '    RangoFinal = 0
                '    Sql = "SELECT IdPreIngreso, RangoInicial, RangoFinal, Activo, IdCosecha, IdLocalidad, IdTipoDocumento, IdTipoCafe, IdTipoCompra, Serie  FROM  Preingreso   WHERE   (Activo = 1) AND (IdCosecha = '" & My.Forms.FrmLiquidacion.IdCosecha & "') AND (IdLocalidad = '" & My.Forms.FrmLiquidacion.IdLocalidadLiqui & "') AND (IdTipoDocumento = 976) AND (IdTipoCompra = 109)"
                '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                '    DataAdapter.Fill(DataSet, "ConseManual")
                '    If DataSet.Tables("ConseManual").Rows.Count = 0 Then
                '        MsgBox("NO EXISTEN RANGOS, CONTACTESE CON SOPORTE", MsgBoxStyle.Information, "Liquidacion")
                '        My.Forms.FrmLiquidacion.CboTipIngreso.Text = "Automatico"
                '        Me.Close()
                '        Exit Sub
                '    Else
                '        RangoInicial = DataSet.Tables("ConseManual").Rows(0)("RangoInicial")
                '        RangoFinal = DataSet.Tables("ConseManual").Rows(0)("RangoFinal")
                '    End If

                '    '//////BUSCO LAS LIQUIDACIONES TIPO DEPOSITO MANUAL AGARRO EL ULTIMO CODIGO PARA SUGERIRLO //////////////////////////////
                '    Sql = "SELECT  Codigo  FROM   LiquidacionPergamino   WHERE (IdCosecha = '" & My.Forms.FrmLiquidacion.IdCosecha & "')AND (IdLocalidad = '" & My.Forms.FrmLiquidacion.IdLocalidadLiqui & "') AND (IdTipoIngreso=  295) AND (IdTipoCompra = 109) ORDER BY Codigo DESC"
                '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                '    DataAdapter.Fill(DataSet, "CodLiquida")
                '    CodigoSugerido = 0
                '    If DataSet.Tables("CodLiquida").Rows.Count = 0 Then
                '        CodigoSugerido = RangoInicial
                '        Me.TxtNumero.Text = CodigoSugerido
                '        Me.Label1.Text = "Numero Sugerido"
                '    Else
                '        CodigoSugerido = DataSet.Tables("CodLiquida").Rows(0)("Codigo") + 1
                '        '///////////VERIFICO QUE EL NUMERO ESTE DENTRO DE EL RNGO /////////////////////////////////////////////
                '        If CodigoSugerido >= RangoInicial And CodigoSugerido <= RangoFinal Then
                '            Me.TxtNumero.Text = CodigoSugerido
                '            Me.Label1.Text = "Numero Sugerido"
                '        Else
                '            MsgBox("NO HAY NUMEROS QUE SUGERIR, VERIFIQUE LOS RANGOS, CONTACTESE CON SOPORTE", MsgBoxStyle.Information, "Liquidacion")
                '            DataSet.Tables("CodLiquida").Reset()
                '            My.Forms.FrmLiquidacion.CboTipIngreso.Text = "Automatico"
                '            Me.Close()
                '            Exit Sub
                '        End If
                '    End If
                'End If
                'DataSet.Tables("CodLiquida").Reset()

            Case "Liquida Automatico Deposito"
              


        End Select
    End Sub

    Private Sub CboSerieLiq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerieLiq.SelectedIndexChanged
        Select Case QuienTec
            Case "Liquida Manual Deposito"
                Quien = "Load"
                Me.CboSerieLiq.ResetText()
                Me.TxtNumero.Text = ""
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////BUSCO SI EXISTE EL CONSECUTIVO PARA RECIBOS ///////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"
                Sql = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdTipoCompra='" & FrmLiquidacion.IdTipoCompra & "') AND (IdTipoCafe = '1')  AND (IdTipoDocumento =  976 ) AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "SerieLiq")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")
                registros = DataSet.Tables("SerieLiq").Rows.Count
                i = 0
                Me.CboSerieLiq.Enabled = False
                Me.CboSerieLiq.ResetText()
                SerieBlanco = False
                Do While registros > i
                    Serie = DataSet.Tables("SerieLiq").Rows(i)("Serie")
                    RangoInicial = DataSet.Tables("SerieLiq").Rows(i)("RangoInicial")
                    RangoFinal = DataSet.Tables("SerieLiq").Rows(i)("RangoFinal")
                    For j = RangoInicial To RangoFinal
                        ConsecutivoLiquidacion = BuscaConsecutivoLiquidacionManual(Serie, 1, FrmLiquidacion.IdCosecha, FrmLiquidacion.IdLocalidadLiqui, FrmLiquidacion.IdTipoCompra, Format(j, "00000#"))
                        If ConsecutivoLiquidacion = "000000" Then
                            Exit For
                        End If
                    Next
                    If ConsecutivoLiquidacion = "000000" Then
                        Consecutivo = j
                        Me.TxtNumero.Text = Format(Consecutivo, "00000#")
                        Exit Do
                    Else
                        Me.TxtNumero.Text = ConsecutivoLiquidacion
                        Me.CboSerieLiq.Text = Serie
                        Exit Do
                    End If
                    i = i + 1
                Loop
                DataSet.Tables("SerieLiq").Reset()

                Sql = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdTipoCafe = '1') AND (IdTipoCompra = " & FrmLiquidacion.IdTipoCompra & ") AND (IdTipoDocumento = 976) AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Combo")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")
                registros = DataSet.Tables("Combo").Rows.Count
                i = 0
                Me.CboSerieLiq.Items.Clear()
                SerieBlanco = False
                Do While registros > i
                    Me.CboSerieLiq.Enabled = True
                    Serie = DataSet.Tables("Combo").Rows(i)("Serie")
                    If Serie <> "" Then
                        Me.CboSerieLiq.Items.Add(Serie)
                        Me.CboSerieLiq.Enabled = True
                        'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                    Else
                        'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                        If SerieBlanco = False Then
                            Me.CboSerieLiq.Items.Add(Serie)
                            SerieBlanco = True
                        End If
                    End If
                    i = i + 1
                Loop

                Quien = ""

                '///////////////////// BUSCO RANGOS DE LA TABLA PREINGRESO //////////////////////////////


                '//////Para cuando la liquidacion es tipo Depósitos Automáticos


            Case "Distribucion"
                TxtNumero.Text = ""
                Me.Label1.Visible = False
                C1Button3.Visible = False
                C1Button1.Height = 185
            Case "LiquidacionNumero"
                TxtNumero.Text = ""
                Me.Label1.Visible = False
                C1Button3.Visible = False
                Label2.Visible = False
                Me.CboSerieLiq.Visible = False
                C1Button1.Height = 185
            Case "RemisionNumero"
                Quien = "Load"
                Me.CboSerieLiq.ResetText()
                Me.TxtNumero.Text = ""
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////BUSCO SI EXISTE EL CONSECUTIVO PARA RECIBOS ///////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"
                Sql = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & FrmRemision2.TxtIdLugarAcopio.Text & ") AND (IdCosecha = " & FrmRemision2.TextIdCosecha.Text & ") AND (IdTipoCafe = '" & FrmRemision2.IdTipoCafe & "')  AND (IdTipoDocumento =  975 ) AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "SerieLiq")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")
                registros = DataSet.Tables("SerieLiq").Rows.Count
                i = 0
                Me.CboSerieLiq.Enabled = False
                Me.CboSerieLiq.ResetText()
                SerieBlanco = False
                Do While registros > i
                    Serie = DataSet.Tables("SerieLiq").Rows(i)("Serie")
                    RangoInicial = DataSet.Tables("SerieLiq").Rows(i)("RangoInicial")
                    RangoFinal = DataSet.Tables("SerieLiq").Rows(i)("RangoFinal")
                    For j = RangoInicial To RangoFinal
                        ConsecutivoLiquidacion = BuscaConsecutivoRemisionManual(Serie, FrmRemision2.IdTipoCafe, FrmRemision2.TextIdCosecha.Text, FrmRemision2.TxtIdLugarAcopio.Text, Format(j, "00000#"))
                        If ConsecutivoLiquidacion = "000000" Then
                            Exit For
                        End If
                    Next
                    If ConsecutivoLiquidacion = "000000" Then
                        Consecutivo = j
                        Me.TxtNumero.Text = Format(Consecutivo, "00000#")
                        Exit Do
                    Else
                        Me.TxtNumero.Text = ConsecutivoLiquidacion
                        Me.CboSerieLiq.Text = Serie
                        Exit Do
                    End If
                    i = i + 1
                Loop
                DataSet.Tables("SerieLiq").Reset()

                Sql = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & FrmRemision2.TxtIdLugarAcopio.Text & ") AND (IdCosecha = " & FrmRemision2.TextIdCosecha.Text & ") AND (IdTipoCafe = '" & FrmRemision2.IdTipoCafe & "') AND (IdTipoDocumento = 975) AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
                DataAdapter.Fill(DataSet, "Combo")
                'Me.CboSerie.DataSource = DataSet.Tables("Serie")
                registros = DataSet.Tables("Combo").Rows.Count
                i = 0
                Me.CboSerieLiq.Items.Clear()
                SerieBlanco = False
                Do While registros > i
                    Me.CboSerieLiq.Enabled = True
                    Serie = DataSet.Tables("Combo").Rows(i)("Serie")
                    If Serie <> "" Then
                        Me.CboSerieLiq.Items.Add(Serie)
                        Me.CboSerieLiq.Enabled = True
                        'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                    Else
                        'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                        If SerieBlanco = False Then
                            Me.CboSerieLiq.Items.Add(Serie)
                            SerieBlanco = True
                        End If
                    End If
                    i = i + 1
                Loop

                Quien = ""
        End Select

    End Sub

    Private Sub CboSerieLiq_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSerieLiq.TextChanged
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim SqlString As String, Registros As Double, RangoMin As Double, RangoMax As Double, i As Double = 0
        Dim Consecutivo As Double, Registro As Double, RangoInicial As String, RangoFinal As String, j As Double = 0
        Dim ConsecutivoRecibo As String, RangoMinimo As Double, RangoMaximo As Double


        If Quien = "Load" Then
            Exit Sub
        End If

        Me.TxtNumero.Text = ""
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////BUSCO SI EXISTE EL CONSECUTIVO PARA RECIBOS ///////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"
        SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & FrmLiquidacion.IdLocalidadLiqui & ") AND (IdCosecha = " & FrmLiquidacion.IdCosecha & ") AND (IdTipoCafe = '1') AND (IdTipoDocumento = 976) AND (Serie = '" & Me.CboSerieLiq.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Serie")
        'Me.CboSerie.DataSource = DataSet.Tables("Serie")
        Registro = DataSet.Tables("Serie").Rows.Count
        i = 0
        'Me.CboSerie.Enabled = False
        'Me.CboSerie.ResetText()
        Do While Registro > i
            Serie = DataSet.Tables("Serie").Rows(i)("Serie")
            RangoMinimo = DataSet.Tables("Serie").Rows(i)("RangoInicial")
            RangoMaximo = DataSet.Tables("Serie").Rows(i)("RangoFinal")

            For j = RangoMinimo To RangoMaximo
                ConsecutivoLiquidacion = BuscaConsecutivoLiquidacionManual(Serie, 1, FrmLiquidacion.IdCosecha, FrmLiquidacion.IdLocalidadLiqui, FrmLiquidacion.IdTipoCompra, Format(j, "00000#"))

                If ConsecutivoLiquidacion = "000000" Then
                    Exit For
                End If
            Next

            'If Serie <> "" Then
            '    Me.CboSerie.Items.Add(Serie)
            '    Me.CboSerie.Enabled = True
            '    'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
            'Else
            '    'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
            '    Me.CboSerie.Items.Add(Serie)
            'End If
            'CboSerie.Text = Serie





            If ConsecutivoLiquidacion = "000000" Then

                Consecutivo = j
                Me.TxtNumero.Text = Format(Consecutivo, "00000#")
                Exit Do

                'RangoInicial = DataSet.Tables("Serie").Rows(i)("RangoInicial")
                'RangoFinal = DataSet.Tables("Serie").Rows(i)("RangoFinal")

                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////////// BUSCO SI EXISTE UN RECIBO PARA EL SIGUIENTE CONSECUTIVO /////////////////////////////////////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                'SqlString = "SELECT ReciboCafePergamino.*  FROM ReciboCafePergamino WHERE  (IdTipoCafe = " & IdTipoCafe & ") AND (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (Codigo BETWEEN '" & RangoInicial & "' AND '" & RangoFinal & "') ORDER BY Codigo DESC"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'DataAdapter.Fill(DataSet, "Consecutivo")
                'If DataSet.Tables("Consecutivo").Rows.Count <> 0 Then
                '    Consecutivo = DataSet.Tables("Consecutivo").Rows(0)("Codigo")
                '    Consecutivo = Consecutivo
                '    Me.TxtNumero.Text = Format(Consecutivo, "00000#")
                '    Exit Do
                'Else
                '    Consecutivo = DataSet.Tables("Serie").Rows(i)("RangoInicial")
                '    Consecutivo = Consecutivo
                '    Me.TxtNumero.Text = Format(Consecutivo, "00000#")
                'End If

            Else
                Me.TxtNumero.Text = ConsecutivoLiquidacion
                Exit Do
            End If
            i = i + 1
        Loop
    End Sub
End Class