Public Class FrmRemision
    Public MiConexion As New SqlClient.SqlConnection
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fileReader As String, Ruta As String, SqlString As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Año As Double = Year(Me.DTPFecha.Value), SqlDatos As String, RutaLogo As String
        Dim LeeArchivo As String = "", Fecha As String = "", CodLocalidadActual As String



        Ruta = My.Application.Info.DirectoryPath & "\SysInfo.txt"
        fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
        Conexion = fileReader
        MiConexion = New SqlClient.SqlConnection(Conexion)

        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        If Dir(Ruta) <> "" Then
            LeeArchivo = My.Computer.FileSystem.ReadAllText(Ruta)
            Me.LblLocalidad.Text = "Localidad Actual:  " & BuscaLocalidad(LeeArchivo)
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(Dataset, "DatosEmpresa")
        If Not Dataset.Tables("DatosEmpresa").Rows.Count = 0 Then

            Me.LblEncabezado.Text = Dataset.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            'ArepRemision.TxtDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(Dataset.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                'ArepRemision.TxtRuc.Text = "Numero RUC:  " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")

            End If
            If Not IsDBNull(Dataset.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = Dataset.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    Me.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        Me.DTPFecha.Value = Now
        Me.TxtCodigoBarra.Focus()
        Me.LblSucursal.Text = ""



        '//////////////////////////////////////////////////////////LLENO EL COMBO DEL CONDUCTOR ///////////////////////////////////////////////////
        'SqlString = "SELECT  IdEmpresaTransporte, Codigo, Nombre, Cedula FROM Conductor  WHERE(Estado = 1)"
        'DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        'DataAdapter.Fill(Dataset, "Conductor")
        'Me.TxtCodigo.DataSource = Dataset.Tables("Conductor")
        'Me.TxtCodigo.Splits.Item(0).DisplayColumns(0).Visible = False
        'Me.TxtCodigo.Splits.Item(0).DisplayColumns(1).Width = 90
        'Me.TxtCodigo.Splits.Item(0).DisplayColumns(2).Width = 350
        'Me.TxtCodigo.Splits.Item(0).DisplayColumns(2).Visible = False
        'Me.TxtCodigo.Splits.Item(0).DisplayColumns(3).Width = 150
        'Me.TxtCodigo.Splits.Item(0).DisplayColumns(3).Visible = False

        '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
        'SqlString = "SELECT Placa FROM Vehiculo"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(Dataset, "Placa")
        'Me.TxtPlaca.DataSource = Dataset.Tables("Placa")
        'Me.TxtPlaca.Splits.Item(0).DisplayColumns(0).Width = 90

        '//////////////////////////////////////////////////////////COSECHA ///////////////////////////////////////////////////

        Fecha = Format(Now, "yyyy-MM-dd")
        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        'SqlString = "SELECT *, YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (FechaInicial <= CONVERT(DATETIME, '" & Fecha & "', 102)) AND (FechaFinal >= CONVERT(DATETIME, '" & Fecha & "', 102))"
        SqlString = "SELECT IdCosecha, Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CodigoCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Cosecha")
        If Dataset.Tables("Cosecha").Rows.Count = 0 Then
            Me.LblCosecha.Text = "Cosecha NO DEFINIDA"
        Else
            Me.LblCosecha.Text = "Cosecha " & Dataset.Tables("Cosecha").Rows(0)("AñoIni") & "-" & Dataset.Tables("Cosecha").Rows(0)("AñoFin")
        End If


    End Sub

    Private Sub C1Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLString As String, FechaIni As String, FechaFin As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String = "", ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As Date, SqlDatos As String, Ruta As String, LeeArchivo As String
        Dim IdCosecha As Double = 0, FechaCosecha As String = "", IdEmpresaTransporte As Double = 0, IdAcopioChequeo As Double = 0
        Dim IdVehiculo As Double = 0



        If Me.TxtCodigo.Text = "" Then
            MsgBox("Se necesita el Codigo de PuntoRevision", MsgBoxStyle.Critical, "Sistema de PuntoRevision")
            Exit Sub
        End If

        If Len(Me.TxtLocalidad.Text) < 3 Then
            MsgBox("la Localidad debe ser de tres digitos", MsgBoxStyle.Critical, "Sistema Remision")
            Exit Sub
        End If

        If Len(Me.TxtNumeroBoleta.Text) < 6 Then
            MsgBox("la Boleta debe ser de Seis digitos", MsgBoxStyle.Critical, "Sistema Remision")
            Exit Sub
        End If

        Me.TxtHora.Text = Date.Now.Hour
        Me.TxtMinutos.Text = Date.Now.Minute


        If Me.TxtHora.Text = "" Then
            Me.TxtHora.Text = "00:00"
        End If

        If Me.TxtMinutos.Text = "" Then
            Me.TxtMinutos.Text = "00:00"
        End If

        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = My.Computer.FileSystem.ReadAllText(Ruta)
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If



        '/////////////////////////////////////////////BUSCO EL CONDUCTOR ///////////////////////////////////////////////////
        ''SqlDatos = "SELECT PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision. IdLugarAcopioChequeo, LugarAcopio.CodLugarAcopio FROM  PuntoRevision INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio WHERE (PuntoRevision.NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') "
        'SqlDatos = "SELECT PuntoRevision.NumeroBoleta, LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio FROM PuntoRevision INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio WHERE (PuntoRevision.NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (LugarAcopio.CodLugarAcopio = '" & Me.TxtLocalidad.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        '    MsgBox("Ya Existe el Numero de Boleta!!!", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        '    Me.TxtNumeroBoleta.Text = ""
        '    Me.TxtCodigoBarra.Text = ""
        '    Me.TxtCodigoBarra.Focus()
        '    Exit Sub
        'End If
        DataSet.Tables("Consulta").Reset()


        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SQLString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & Me.TxtLocalidad.Text & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad")
        If DataSet.Tables("Localidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
            Me.IdLugarAcopio.Text = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
        End If

        If Str(LeeArchivo) = Str(Me.TxtLocalidad.Text) Then
            MsgBox("Seleccione Otra Localidad", MsgBoxStyle.Critical, "Sistema Remision")
            Me.TxtLocalidad.Text = ""
            Exit Sub
        End If


        '/////////////////////////////////////////////BUSCO EL CONDUCTOR ///////////////////////////////////////////////////
        SqlDatos = "SELECT     EmpresaTransporte.* FROM EmpresaTransporte WHERE (Codigo = '" & Me.TxtCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "EmpresaTransporte")
        If DataSet.Tables("EmpresaTransporte").Rows.Count = 0 Then
            MsgBox("La Empresa de Transporte no Existe!!!", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Me.TxtCodigo.Text = ""
            Exit Sub
        Else
            IdEmpresaTransporte = DataSet.Tables("EmpresaTransporte").Rows(0)("IdEmpresaTransporte")
        End If
        DataSet.Tables("EmpresaTransporte").Reset()


        'FechaIni = Format(Me.DTPFecha.Value, "yyyy-MM-dd") & " " & Me.TxtHora.Text & ":" & Me.TxtMinutos.Text & ":00"
        'FechaFin = Format(Me.DTPFecha.Value, "yyyy-MM-dd") & " " & Me.TxtHora.Text & ":" & Me.TxtMinutos.Text & ":00"
        'Fecha = FechaIni
        FechaIni = Format(Me.DTPFecha.Value, "yyyy-MM-dd") & " " & Me.LblHora.Text
        Fecha = FechaIni


        '//////////////////////////////////////////////////////////COSECHA ///////////////////////////////////////////////////
        FechaCosecha = Format(Now, "yyyy-MM-dd")
        'SQLString = "SELECT *, YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (FechaInicial <= CONVERT(DATETIME, '" & FechaCosecha & "', 102)) AND (FechaFinal >= CONVERT(DATETIME, '" & FechaCosecha & "', 102))"
        SQLString = "SELECT IdCosecha, Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha ORDER BY IdCosecha DESC"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count <> 0 Then
            IdCosecha = DataSet.Tables("Cosecha").Rows(0)("IdCosecha")
        End If


        IdAcopioChequeo = BuscaIdLocalidad(LeeArchivo)
        IdVehiculo = BuscaIdVehiculo(Me.TxtPlaca.Text)

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        MiConexion.Close()
        SQLString = "INSERT INTO [PuntoRevision] ([Fecha],[IdLugarAcopio],[NumeroBoleta],[IdEmpresaTransporte],[Placa],[IdLugarAcopioChequeo],[IdCosecha],[IdLocalidadChequeo],[IdVehiculo]) " & _
                    "VALUES('" & Format(Fecha, "dd/MM/yyyy H:mm:ss") & "','" & Me.IdLugarAcopio.Text & "','" & Me.TxtNumeroBoleta.Text & "','" & IdEmpresaTransporte & "','" & Me.TxtPlaca.Text & "'," & LeeArchivo & "," & IdCosecha & "," & IdAcopioChequeo & "," & IdVehiculo & ")"

        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQLString, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        CmdImprimir.Enabled = True
        C1Button14_Click(sender, e)


        Me.LblEstado.ForeColor = Color.Red
        Me.LblEstado.Text = "CODIGO TRANSPORTISTA GRABADO"

        Me.TxtCodigo.Text = ""
        Me.TxtHora.Text = ""
        Me.TxtMinutos.Text = ""
        Me.TxtCodigoBarra.Text = ""
        Me.TxtPlaca.Text = ""
        Me.TxtNumeroBoleta.Text = ""
        Me.TxtLocalidad.Text = ""
        Me.IdLugarAcopio.Text = ""
        Me.LblSucursal.Text = ""

        Me.TxtCodigoBarra.Focus()




    End Sub

    Private Sub TxtCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Enfoque = "TxtCodigo"
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LblEstado.ForeColor = Color.Green
        Me.LblEstado.Text = "PROCESO PuntoRevision"
        Me.TxtBarra.Text = Me.TxtCodigo.Text
    End Sub

    Private Sub TxtHora_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHora.GotFocus
        Enfoque = "TxtHora"
    End Sub

    Private Sub TxtMinutos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMinutos.GotFocus
        Enfoque = "TxtMinutos"
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton1.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If


                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "1"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "1"
                End If

            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "1"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "1"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "1"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "1"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "1"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "1"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "1"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "1"
                End If

            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "1"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "1"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "1"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "1"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub C1Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton5.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If
                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "5"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "5"
                End If
            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "5"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "5"
                End If
            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "5"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "5"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "5"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "5"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "5"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "5"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "5"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "5"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "5"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "5"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub CmdBoton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton2.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If

                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "2"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "2"
                End If

            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "2"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "2"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "2"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "2"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "2"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "2"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "2"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "2"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "2"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "2"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "2"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "2"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub CmdBoton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton3.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If
                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "3"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "3"
                End If
            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "3"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "3"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "3"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "3"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "3"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "3"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "3"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "3"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "3"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "3"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "3"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "3"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub CmdBoton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton4.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If
                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "4"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "4"
                End If
            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "4"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "4"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "4"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "4"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "4"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "4"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "4"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "4"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "4"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "4"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "4"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "4"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub CmdBoton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton6.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If
                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "6"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "6"
                End If
            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "6"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "6"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "6"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "6"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "6"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "6"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "6"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "6"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "6"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "6"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "6"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "6"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub CmdBoton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton7.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If
                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "7"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "7"
                End If
            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "7"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "7"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "7"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "7"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "7"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "7"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "7"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "7"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "7"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "7"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "7"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "7"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub CmdBoton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton8.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If
                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "8"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "8"
                End If
            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "8"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "8"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "8"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "8"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "8"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "8"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "8"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "8"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "8"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "8"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "8"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "8"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub CmdBoton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton9.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If
                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "9"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "9"
                End If
            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "9"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "9"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "9"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "9"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "9"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "9"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "9"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "9"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "9"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "9"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "9"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "9"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub CmdBoton0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton0.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Len(Me.TxtNumeroBoleta.Text) > 5 Then
                    Exit Sub
                End If
                If Me.TxtNumeroBoleta.Text = "" Then
                    Me.TxtNumeroBoleta.Text = "0"
                Else
                    Me.TxtNumeroBoleta.Text = Me.TxtNumeroBoleta.Text & "0"
                End If
            Case "TxtLocalidad"
                If Len(Me.TxtLocalidad.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtLocalidad.Text = "" Then
                    Me.TxtLocalidad.Text = "0"
                Else
                    Me.TxtLocalidad.Text = Me.TxtLocalidad.Text & "0"
                End If

            Case "TxtPlaca"
                If Me.TxtPlaca.Text = "" Then
                    Me.TxtPlaca.Text = "0"
                Else
                    Me.TxtPlaca.Text = Me.TxtPlaca.Text & "0"
                End If
            Case "TxtCodigo"
                If Len(Me.TxtCodigo.Text) > 2 Then
                    Exit Sub
                End If
                If Me.TxtCodigo.Text = "" Then
                    Me.TxtCodigo.Text = "0"
                Else
                    Me.TxtCodigo.Text = Me.TxtCodigo.Text & "0"
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "0"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "0"
                End If
            Case "TxtHora"
                If Me.TxtHora.Text = "" Then
                    Me.TxtHora.Text = Me.TxtHora.Text & "0"
                Else
                    Me.TxtHora.Text = Me.TxtHora.Text & "0"
                    Me.TxtMinutos.Focus()
                End If

            Case "TxtMinutos"
                If Me.TxtMinutos.Text = "" Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "0"
                ElseIf Longitud = 1 Then
                    Me.TxtMinutos.Text = Me.TxtMinutos.Text & "0"
                    Me.TxtMinutos.Focus()
                ElseIf Longitud > 1 Then
                    Me.TxtHora.Focus()
                End If


        End Select
    End Sub

    Private Sub TxtHora_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHora.TextChanged
        Dim Hora As Double

        If Not IsNumeric(Me.TxtHora.Text) Then
            Exit Sub
        End If


        Hora = Me.TxtHora.Text
        If Hora > 23 Then
            Me.TxtHora.Text = ""
            Me.TxtHora.Focus()
        End If

    End Sub

    Private Sub TxtMinutos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMinutos.TextChanged
        Dim Minutos As Double

        If Not IsNumeric(Me.TxtMinutos.Text) Then
            Exit Sub
        End If


        Minutos = Me.TxtMinutos.Text
        If Minutos > 59 Then
            Me.TxtMinutos.Text = ""
            Me.TxtMinutos.Focus()
        End If
    End Sub

    Private Sub C1Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button10.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                If Me.TxtNumeroBoleta.Text <> "" Then
                    Me.TxtNumeroBoleta.Text = Mid(Me.TxtNumeroBoleta.Text, 1, Len(Me.TxtNumeroBoleta.Text) - 1)
                End If
            Case "TxtLocalidad"
                If Me.TxtLocalidad.Text <> "" Then
                    Me.TxtLocalidad.Text = Mid(Me.TxtLocalidad.Text, 1, Len(Me.TxtLocalidad.Text) - 1)
                End If
            Case "TxtPlaca"
                If Me.TxtPlaca.Text <> "" Then
                    Me.TxtPlaca.Text = Mid(Me.TxtPlaca.Text, 1, Len(Me.TxtPlaca.Text) - 1)
                End If
            Case "TxtCodigo"
                If Me.TxtCodigo.Text <> "" Then
                    Me.TxtCodigo.Text = Mid(Me.TxtCodigo.Text, 1, Len(Me.TxtCodigo.Text) - 1)
                End If
            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text <> "" Then
                    Me.TxtCodigoBarra.Text = Mid(Me.TxtCodigoBarra.Text, 1, Len(Me.TxtCodigoBarra.Text) - 1)
                End If
            Case "TxtHora"
                Me.TxtHora.Text = ""
            Case "TxtMinutos"
                Me.TxtMinutos.Text = ""


        End Select
    End Sub

    Private Sub C1Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdImprimir.Click
        Dim ViewerForm As New FrmViewer()
        Dim ArepRemision As New ArepRemision, RutaLogo As String
        Dim DataSet As New DataSet, SqlDatos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Moneda As String, SQlString As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, IdEmpresaTransporte As String = ""
        Dim cadena As String, CodEmpresaTransporte As String = "", NumeroPlaca As String = ""



        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            ArepRemision.TxtTitutlo.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            'ArepRemision.TxtDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                'ArepRemision.TxtRuc.Text = "Numero RUC:  " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")

            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    ArepRemision.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        SqlDatos = "SELECT  * FROM Conductor INNER JOIN EmpresaTransporte ON Conductor.IdCompany = EmpresaTransporte.IdEmpresaTransporte WHERE (Conductor.Codigo = '" & Me.TxtCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "EmpresaTransporte")
        If Not DataSet.Tables("EmpresaTransporte").Rows.Count = 0 Then
            IdEmpresaTransporte = DataSet.Tables("EmpresaTransporte").Rows(0)("Codigo")
        End If




        
        'SQlString = "SELECT PuntoRevision.CodigoRemision, EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, PuntoRevision.Placa, LugarAcopio.NomLugarAcopio, PuntoRevision.Fecha, LugarAcopio.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.IdLugarAcopioChequeo, LugarAcopio.CodLugarAcopio FROM PuntoRevision INNER JOIN EmpresaTransporte ON PuntoRevision.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio " & _
        '            "WHERE (PuntoRevision.NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (LugarAcopio.CodLugarAcopio = '" & Me.TxtLocalidad.Text & "')"

        SQlString = "SELECT PuntoRevision.CodigoRemision, EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, PuntoRevision.Placa, LugarAcopio.NomLugarAcopio, PuntoRevision.Fecha, LugarAcopio.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.IdLugarAcopioChequeo, LugarAcopio.CodLugarAcopio FROM PuntoRevision INNER JOIN EmpresaTransporte ON PuntoRevision.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                    "WHERE (PuntoRevision.NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (LugarAcopio.CodLugarAcopio = '" & Me.TxtLocalidad.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            NumeroPlaca = DataSet.Tables("Consulta").Rows(0)("Placa")
            IdEmpresaTransporte = DataSet.Tables("Consulta").Rows(0)("Codigo")
        End If



        cadena = Me.TxtLocalidad.Text & Me.TxtNumeroBoleta.Text & IdEmpresaTransporte & NumeroPlaca
        ArepRemision.TxtCodigoBarra.Text = Me.TxtLocalidad.Text & Me.TxtNumeroBoleta.Text     'Replace(cadena, "-", "")
        ArepRemision.LblCodigo.Text = cadena

        SQL.ConnectionString = Conexion
        SQL.SQL = SQlString

        ArepRemision.LblCosecha.Text = Me.LblCosecha.Text

        ViewerForm.arvMain.Document = ArepRemision.Document
        My.Application.DoEvents()
        ArepRemision.DataSource = SQL
        ArepRemision.Run(False)
        'ViewerForm.Show()
        ViewerForm.arvMain.Document.Print(False, False, False)
        'CmdImprimir.Enabled = False

    End Sub

    Private Sub TxtCodigoBarra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodigoBarra.GotFocus
        Enfoque = "TxtCodigoBarra"
    End Sub

    Private Sub TxtCodigoBarra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoBarra.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Codigo As String, Cadenas As String(), SqlString As String
            Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

            Codigo = Me.TxtCodigoBarra.Text

            'Cadenas = Codigo.Split("+")
            'Me.TxtLocalidad.Text = Cadenas(0)
            'Me.TxtNumeroBoleta.Text = Cadenas(1)

            Me.TxtLocalidad.Text = Mid(Me.TxtCodigoBarra.Text, 1, 3)
            Me.TxtNumeroBoleta.Text = Mid(Me.TxtCodigoBarra.Text, 4, 6)


            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & Me.TxtLocalidad.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
            DataAdapter.Fill(Dataset, "Localidad")
            If Dataset.Tables("Localidad").Rows.Count = 0 Then
                MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Else
                Me.LblSucursal.Text = Dataset.Tables("Localidad").Rows(0)("NomLugarAcopio")
                Me.IdLugarAcopio.Text = Dataset.Tables("Localidad").Rows(0)("IdLugarAcopio")
            End If

            Me.TxtCodigo.Focus()
        End If
    End Sub


    Private Sub TxtCodigoBarra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoBarra.TextChanged
        Me.LblEstado.ForeColor = Color.Green
        Me.LblEstado.Text = "CODIGO TRANSPORTISTA"
        Me.TxtBarraBoleta.Text = Me.TxtCodigoBarra.Text
    End Sub

    Private Sub C1Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button12.Click
        Dim Longitud As Double
        If Enfoque = "" Then
            Enfoque = "TxtHora"
        End If

        Longitud = Len(Me.TxtMinutos.Text)

        Select Case Enfoque

            Case "TxtCodigoBarra"
                If Me.TxtCodigoBarra.Text = "" Then
                    Me.TxtCodigoBarra.Text = "+"
                Else
                    Me.TxtCodigoBarra.Text = Me.TxtCodigoBarra.Text & "+"
                End If

        End Select
    End Sub

    Private Sub C1Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Dim Codigo As String, Cadenas As String(), SqlString As String, Numero As Double
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        Select Case Enfoque
            Case "TxtNumeroBoleta"
                '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
                'SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & Me.TxtLocalidad.Text & "')"
                'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'DataAdapter.Fill(Dataset, "Localidad")
                'If Dataset.Tables("Localidad").Rows.Count = 0 Then
                '    MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
                'Else
                '    Me.LblSucursal.Text = Dataset.Tables("Localidad").Rows(0)("NomLugarAcopio")
                '    Me.IdLugarAcopio.Text = Dataset.Tables("Localidad").Rows(0)("IdLugarAcopio")
                'End If

                Me.TxtCodigo.Focus()
            Case "TxtLocalidad"


                If Me.TxtLocalidad.Text <> "" Then
                    If Not IsNumeric(Me.TxtLocalidad.Text) Then
                        Exit Sub
                    End If

                    Numero = Me.TxtLocalidad.Text
                    Me.TxtLocalidad.Text = Format(Numero, "00#")
                End If

                '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
                SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & Me.TxtLocalidad.Text & "') AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(Dataset, "Localidad")
                If Dataset.Tables("Localidad").Rows.Count = 0 Then
                    MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
                Else
                    Me.LblSucursal.Text = Dataset.Tables("Localidad").Rows(0)("NomLugarAcopio")
                    Me.IdLugarAcopio.Text = Dataset.Tables("Localidad").Rows(0)("IdLugarAcopio")
                End If





                Me.TxtNumeroBoleta.Focus()

            Case "TxtPlaca"
                Me.CmdGrabar.Focus()
            Case "TxtCodigo"
                Me.TxtPlaca.Focus()
            Case "TxtCodigoBarra"


                Codigo = Me.TxtCodigoBarra.Text

                'Cadenas = Codigo.Split("+")
                'Me.TxtLocalidad.Text = Cadenas(0)
                'Me.TxtNumeroBoleta.Text = Cadenas(1)
                Me.TxtLocalidad.Text = Mid(Me.TxtCodigoBarra.Text, 1, 3)
                Me.TxtNumeroBoleta.Text = Mid(Me.TxtCodigoBarra.Text, 4, 6)

                '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
                SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & Me.TxtLocalidad.Text & "') AND (Activo = 1)"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(Dataset, "Localidad")
                If Dataset.Tables("Localidad").Rows.Count = 0 Then
                    MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
                Else
                    Me.LblSucursal.Text = Dataset.Tables("Localidad").Rows(0)("NomLugarAcopio")
                    Me.IdLugarAcopio.Text = Dataset.Tables("Localidad").Rows(0)("IdLugarAcopio")
                End If

                Me.TxtCodigo.Focus()

        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub TxtCodigo_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        Enfoque = "TxtCodigo"
    End Sub

    Private Sub CboPlaca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPlaca.GotFocus
        Enfoque = "TxtPlaca"
    End Sub

    Private Sub TxtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.TxtPlaca.Focus()
        End If
    End Sub

    Private Sub TxtPlaca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPlaca.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.CmdGrabar.Focus()
        End If
    End Sub

    Private Sub TxtNumeroBoleta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroBoleta.GotFocus
        Enfoque = "TxtNumeroBoleta"
    End Sub

    Private Sub TxtNumeroBoleta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNumeroBoleta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TxtCodigo.Focus()
        End If
    End Sub


    Private Sub TxtLocalidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLocalidad.GotFocus
        Enfoque = "TxtLocalidad"

    End Sub

    Private Sub TxtLocalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLocalidad.KeyDown
        Dim Codigo As String, Cadenas As String(), SqlString As String, Numero As Double = 0
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If e.KeyCode = Keys.Enter Then

            If Me.TxtLocalidad.Text <> "" Then
                If Not IsNumeric(Me.TxtLocalidad.Text) Then
                    Exit Sub
                End If

                Numero = Me.TxtLocalidad.Text
                Me.TxtLocalidad.Text = Format(Numero, "00#")
            End If

            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & Me.TxtLocalidad.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(Dataset, "Localidad")
            If Dataset.Tables("Localidad").Rows.Count = 0 Then
                MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Else
                Me.LblSucursal.Text = Dataset.Tables("Localidad").Rows(0)("NomLugarAcopio")
                Me.IdLugarAcopio.Text = Dataset.Tables("Localidad").Rows(0)("IdLugarAcopio")
            End If
            Me.TxtNumeroBoleta.Focus()
        End If
    End Sub

    Private Sub TxtLocalidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLocalidad.LostFocus
        'Dim Numero As Double

        'If Me.TxtLocalidad.Text <> "" Then
        '    If Not IsNumeric(Me.TxtLocalidad.Text) Then
        '        'MsgBox("Se necesitan datos Numericos", MsgBoxStyle.Critical, "Sistema de Remisiones")
        '        Exit Sub
        '    End If

        '    Numero = Me.TxtLocalidad.Text
        '    Me.TxtLocalidad.Text = Format(Numero, "00#")
        'End If
    End Sub


    Private Sub TxtLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLocalidad.TextChanged

    End Sub

    Private Sub TxtNumeroBoleta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroBoleta.TextChanged

    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        Me.Close()
    End Sub

    Private Sub OptManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptManual.CheckedChanged
        If Me.OptManual.Checked = True Then
            Me.TxtNumeroBoleta.Enabled = True
            Me.TxtLocalidad.Enabled = True
            Me.TxtCodigoBarra.Enabled = False
            Me.TxtLocalidad.Focus()
        Else
            Me.TxtNumeroBoleta.Enabled = False
            Me.TxtLocalidad.Enabled = False
            Me.TxtCodigoBarra.Enabled = True
            Me.TxtCodigoBarra.Focus()
        End If
    End Sub

    Private Sub OptBarra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptBarra.CheckedChanged
        If Me.OptManual.Checked = True Then
            Me.TxtNumeroBoleta.Enabled = True
            Me.TxtLocalidad.Enabled = True
            Me.TxtCodigoBarra.Enabled = False
            Me.TxtCodigoBarra.Text = ""
            Me.TxtLocalidad.Focus()
        Else
            Me.TxtNumeroBoleta.Enabled = False
            Me.TxtLocalidad.Enabled = False
            Me.TxtCodigoBarra.Enabled = True
            Me.TxtNumeroBoleta.Text = ""
            Me.TxtLocalidad.Text = ""
            Me.TxtCodigoBarra.Focus()
        End If
    End Sub

    Private Sub TxtCodigo_GotFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodigo.GotFocus
        Enfoque = "TxtCodigo"
    End Sub

    Private Sub TxtCodigo_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.TextChanged
        Dim SqlString As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
        'SqlString = "SELECT DISTINCT Vehiculo.Placa FROM Conductor INNER JOIN EmpresaTransporte ON Conductor.IdCompany = EmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON EmpresaTransporte.IdEmpresaTransporte = Vehiculo.IdCompany WHERE (EmpresaTransporte.Codigo = '" & Me.TxtCodigo.Text & "')"
        SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo  " & _
                    "WHERE (EmpresaTransporte.Codigo = '" & Me.TxtCodigo.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.TxtPlaca.DataSource = DataSet.Tables("Placa")
        Me.TxtPlaca.Splits.Item(0).DisplayColumns(0).Width = 90
    End Sub

    Private Sub LblHora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblHora.Click

    End Sub
End Class
