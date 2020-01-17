Public Class FrmTecladoSerie
    Public Numero As String, IdCosecha As Double, IdTipoCafe As Double, IdLocalidad As Double, Serie As String, IdTipoCompra As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmTeclado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim SqlString As String, Registros As Double, RangoMin As Double, RangoMax As Double, i As Double = 0
        Dim Consecutivo As Double, Registro As Double, RangoInicial As String, RangoFinal As String, j As Double = 0
        Dim ConsecutivoRecibo As String, RangoMinimo As Double, RangoMaximo As Double, SerieBlanco As Boolean = False

        Quien = "Load"

        Me.CboSerie.ResetText()
        Me.TxtNumero.Text = ""
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '//////////////////////////////BUSCO SI EXISTE EL CONSECUTIVO PARA RECIBOS ///////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"
        SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (IdTipoDocumento = 972) AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Serie")
        'Me.CboSerie.DataSource = DataSet.Tables("Serie")
        Registro = DataSet.Tables("Serie").Rows.Count
        i = 0
        Me.CboSerie.Enabled = False
        Me.CboSerie.ResetText()
        SerieBlanco = False
        Do While Registro > i
            Serie = DataSet.Tables("Serie").Rows(i)("Serie")
            RangoMinimo = DataSet.Tables("Serie").Rows(i)("RangoInicial")
            RangoMaximo = DataSet.Tables("Serie").Rows(i)("RangoFinal")

            For j = RangoMinimo To RangoMaximo
                ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra, Format(j, "00000#"))

                If ConsecutivoRecibo = "000000" Then
                    Exit For
                End If
            Next

            If ConsecutivoRecibo = "000000" Then

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

                Me.TxtNumero.Text = ConsecutivoRecibo
                CboSerie.Text = Serie

                Exit Do

            End If

            i = i + 1
        Loop


        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '///////////////////////////////////////////////AGREGO LOS DATOS DEL COMBO ////////////////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (IdTipoDocumento = 972) AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Combo")
        'Me.CboSerie.DataSource = DataSet.Tables("Serie")
        Registro = DataSet.Tables("Combo").Rows.Count
        i = 0
        Me.CboSerie.Enabled = False
        Me.CboSerie.Items.Clear()
        SerieBlanco = False
        Do While Registro > i
            Serie = DataSet.Tables("Combo").Rows(i)("Serie")

            If Serie <> "" Then
                Me.CboSerie.Items.Add(Serie)
                Me.CboSerie.Enabled = True
                'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
            Else

                'ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra)
                If SerieBlanco = False Then
                    Me.CboSerie.Items.Add(Serie)
                    SerieBlanco = True
                End If

            End If


            i = i + 1
        Loop


        'Me.TxtNumero.Text = ""

        ''///////////////////////////////////RECOMIENDO EL ULTIMO NUMERO DE RECIBO ///////////////////////////////
        'SqlString = "SELECT Codigo, IdTipoCafe, IdCosecha, IdLocalidad, IdDano, IdFinca, IdTipoCompra, IdEstadoDocumento, IdProductor, IdUnidadMedida, IdUsuario, IdLocalidadLiquidacion, SincronizadoECS, FechaSincronizacion, FechaIngresoSistemas, Imei, IdPignorado, EsProductorManual, CedulaManual, ProductorManual, FincaManual,  IdCalidad  FROM ReciboCafePergamino " & _
        '            "WHERE  (IdTipoCafe = " & IdTipoCafe & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (IdTipoIngreso = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ") ORDER BY Codigo DESC"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Consecutivo")
        'If DataSet.Tables("Consecutivo").Rows.Count <> 0 Then
        '    Consecutivo = DataSet.Tables("Consecutivo").Rows(0)("Codigo") + 1
        '    Me.TxtNumero.Text = Format(Consecutivo, "0000#")
        'Else
        '    Consecutivo = 1
        '    Me.TxtNumero.Text = Format(Consecutivo, "0000#")
        'End If


        Quien = ""


    End Sub

    Private Sub C1Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdBoton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton1.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "1"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "1"
        End If
    End Sub

    Private Sub CmdBoton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton2.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "2"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "2"
        End If
    End Sub

    Private Sub CmdBoton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton3.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "3"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "3"
        End If
    End Sub

    Private Sub CmdBoton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton4.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "4"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "4"
        End If
    End Sub

    Private Sub CmdBoton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton5.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "5"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "5"
        End If
    End Sub

    Private Sub CmdBoton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton6.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "6"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "6"
        End If
    End Sub

    Private Sub CmdBoton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton7.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "7"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "7"
        End If
    End Sub

    Private Sub CmdBoton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton8.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "8"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "8"
        End If
    End Sub

    Private Sub CmdBoton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton9.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "9"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "9"
        End If
    End Sub

    Private Sub C1Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button12.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "+"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "+"
        End If
    End Sub

    Private Sub CmdBoton0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton0.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "0"
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "0"
        End If
    End Sub

    Private Sub C1Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button10.Click
        If Me.TxtNumero.Text <> "" Then
            Me.TxtNumero.Text = Mid(Me.TxtNumero.Text, 1, Len(Me.TxtNumero.Text) - 1)
        End If
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Numero = 0
        FrmRecepcion.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA")
        FrmRecepcion.TxtSerie.Text = ""
        FrmRecepcion.TxtLocalidad.Text = FrmRecepcion.CodLugarAcopioDefecto
        Serie = ""
        If FrmRecepcion.CboTipoCompra.Text = "Compra Directa" Then
            FrmRecepcion.TxtSerie.Text = "C" & FrmRecepcion.Cod_Cosecha
        End If

        Me.Close()

    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Dim DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim SqlString As String, Registros As Double, RangoMin As Double, RangoMax As Double, i As Double = 0, NumeroTecla As Double, RangoCorrecto As Boolean = False
        Dim Fecha As String
        Dim Consecutivo As Double, RangoInicial As String, RangoFinal As String, Minimo As Double, Maximo As Double, FueraRango As Boolean, ConsecutivoRecibo As String

        If Len(Trim(Me.TxtNumero.Text)) <> 6 Then
            MsgBox("Debe Digitar Numeros de 6 Digitos")
            Exit Sub
        End If


        If Me.CboSerie.Text <> "" Then
            Serie = Me.CboSerie.Text
        End If

        If Me.TxtNumero.Text = "" Then
            Numero = 0
            NumeroTecla = 0
            Exit Sub
        Else
            NumeroTecla = Me.TxtNumero.Text
            NumeroTecla = Format(NumeroTecla, "00000#")
            Numero = NumeroTecla
        End If

        'SqlString = "SELECT Codigo, IdTipoCafe, IdCosecha, IdLocalidad, IdDano, IdFinca, IdTipoCompra, IdEstadoDocumento, IdProductor, IdUnidadMedida, IdUsuario, IdLocalidadLiquidacion, SincronizadoECS, FechaSincronizacion, FechaIngresoSistemas, IdPignorado, EsProductorManual, CedulaManual, ProductorManual, FincaManual,  IdCalidad  FROM ReciboCafePergamino " & _
        '            "WHERE (IdTipoCafe = " & IdTipoCafe & ") AND (IdCosecha = " & IdCosecha & ") AND (IdLocalidad = " & IdLocalidad & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (Codigo = '" & Format(NumeroTecla, "00000#") & "') ORDER BY Codigo DESC"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Numero")

        Serie = Me.CboSerie.Text
        ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra, Format(NumeroTecla, "00000#"))
        If ConsecutivoRecibo = Me.TxtNumero.Text Then
            MsgBox("Ya existe un Recibo con este Numero Recibo", MsgBoxStyle.Critical, "Bascula")
            Me.TxtNumero.Text = ""
            Exit Sub
        End If

        If Serie = "" Then
            Serie = "?"
        End If

        If FrmRecepcion.CboTipoIngresoBascula.Text = DescripcionTipoIngreso("BA") Then
            'GrabaRecibo(Me.TxtNumeroEnsamble.Text, Me.DTPFecha.Text)
            Fecha = Format(FrmRecepcion.DTPFecha.Text, "yyyy-MM-dd")
        Else
            Fecha = Format(FrmRecepcion.DtpFechaManual.Value, "yyyy-MM-dd")
        End If

        If Me.CboSerie.Text = "" Then
            SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (IdTipoDocumento = 972) AND (Activo = 1) AND  (Serie = ' ') OR  (Serie IS NULL)"
        Else
            SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (IdTipoDocumento = 972) AND (Activo = 1) AND (Serie = '" & Me.CboSerie.Text & "')"
        End If

        'SqlString = "SELECT DISTINCT Serie FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ")"

        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Serie")
        'Me.CboSerie.DataSource = DataSet.Tables("Serie")

        i = 0
        Registros = DataSet.Tables("Serie").Rows.Count
        FueraRango = True

        Do While Registros > i

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

        Me.Close()
    End Sub

    Private Sub BtnPunto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPunto.Click
        If Me.TxtNumero.Text = "" Then
            Me.TxtNumero.Text = "0."
        Else
            Me.TxtNumero.Text = Me.TxtNumero.Text & "."
        End If
    End Sub

    Private Sub TxtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumero.TextChanged

        If Me.TxtNumero.Text = "" Then
            Numero = 0
            Exit Sub
        Else
            Numero = Me.TxtNumero.Text
        End If



    End Sub

    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie.SelectedIndexChanged
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
        SqlString = "SELECT DISTINCT Serie, RangoInicial, RangoFinal, IdTipoCompra, IdTipoDocumento FROM Preingreso WHERE  (IdLocalidad = " & IdLocalidad & ") AND (Activo = 1) AND (IdCosecha = " & IdCosecha & ") AND (IdTipoCafe = " & IdTipoCafe & ") AND (IdTipoCompra = " & IdTipoCompra & ") AND (IdTipoDocumento = 972) AND (Serie = '" & Me.CboSerie.Text & "')"
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
                ConsecutivoRecibo = BuscaConsecutivoReciboManual(Serie, IdTipoCafe, IdCosecha, IdLocalidad, IdTipoCompra, Format(j, "00000#"))

                If ConsecutivoRecibo = "000000" Then
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





            If ConsecutivoRecibo = "000000" Then

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

                Me.TxtNumero.Text = ConsecutivoRecibo
                Exit Do

            End If





            i = i + 1
        Loop

    End Sub
End Class