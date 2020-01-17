Public Class FrmLectura
    Public MiConexion As New SqlClient.SqlConnection, NoTiket As Double, CodigoBarra As String
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub TxtCodigoBarra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoBarra.KeyDown
        Dim CodLocalidad As String, NumeroBoleta As String
        Dim SqlString As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        NoTiket = 0
        CodigoBarra = ""

        If e.KeyCode = Keys.Enter Then
            'Me.TxtCodigoBarra.Text = Mid(Me.TxtCodigoBarra.Text, 1, Len(Me.TxtCodigoBarra.Text) - 1)

            CodigoBarra = Me.TxtCodigoBarra.Text
            CodLocalidad = Mid(Me.TxtCodigoBarra.Text, 1, 3)
            NumeroBoleta = Mid(Me.TxtCodigoBarra.Text, 4, 6)

            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & CodLocalidad & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(Dataset, "Localidad")
            If Dataset.Tables("Localidad").Rows.Count = 0 Then
                MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Else
                Me.LblLocalidad.Text = Dataset.Tables("Localidad").Rows(0)("NomLugarAcopio")
            End If

            Me.LblBoleta.Text = NumeroBoleta

            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            'SqlString = "SELECT PuntoRevision.NumeroBoleta, LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio FROM PuntoRevision INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (LugarAcopio.CodLugarAcopio = '" & CodLocalidad & "')"
            SqlString = "SELECT PuntoRevision.CodigoRemision, EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, PuntoRevision.Placa, LugarAcopio.NomLugarAcopio, PuntoRevision.Fecha, LugarAcopio.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.IdLugarAcopioChequeo, LugarAcopio.CodLugarAcopio FROM PuntoRevision INNER JOIN EmpresaTransporte ON PuntoRevision.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio " & _
                        "WHERE (LugarAcopio.CodLugarAcopio = '" & CodLocalidad & "') AND (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(Dataset, "Consulta")
            If Dataset.Tables("Consulta").Rows.Count = 0 Then
                MsgBox("No Existe el PuntoRevision", MsgBoxStyle.Critical, "Sistema PuntoRevision")
                NoTiket = 0
            Else
                Me.LblConductor.Text = Dataset.Tables("Consulta").Rows(0)("NombreEmpresa")
                Me.LblTicket.Text = Dataset.Tables("Consulta").Rows(0)("CodigoRemision")
                Me.LblPlaca.Text = Dataset.Tables("Consulta").Rows(0)("Placa")
                NoTiket = Dataset.Tables("Consulta").Rows(0)("CodigoRemision")
            End If

            Me.TxtCodigoBarra.Text = ""


        End If
    End Sub

    Private Sub TxtCodigoBarra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoBarra.TextChanged
        Me.TxtBarraBoleta.Text = Me.TxtCodigoBarra.Text
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Me.Close()
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim SQLString As String, FechaIni As String, FechaFin As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String = "", ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Fecha As Date, SqlDatos As String = "", Ruta As String, LeeArchivo As String = "", IdLugarAcopio As String = ""
        Dim CodigoLocalidad As String, NumeroBoletas As String

        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        If Dir(Ruta) <> "" Then
            LeeArchivo = My.Computer.FileSystem.ReadAllText(Ruta)
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If

        If CodigoBarra = "" Then
            MsgBox("No se puede grabar sin Lectura", MsgBoxStyle.Critical, "Sistema Remision")
            Me.TxtCodigoBarra.Focus()
            Exit Sub
        End If

        CodigoLocalidad = Mid(CodigoBarra, 1, 3)
        NumeroBoletas = Mid(CodigoBarra, 4, 6)

        '/////////////////////////////////////////////BUSCO EL CONDUCTOR ///////////////////////////////////////////////////
        SqlDatos = "SELECT PuntoRevision.NumeroBoleta, LugarAcopio.CodLugarAcopio, LugarAcopio.NomLugarAcopio FROM PuntoRevision INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoletas & "') AND (LugarAcopio.CodLugarAcopio = '" & CodigoLocalidad & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count = 0 Then
            MsgBox("BOLETA NO EXISTEN EN LOS PUNTOS DE REVISION!!!", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Me.TxtCodigoBarra.Focus()
            Exit Sub
        End If
        DataSet.Tables("Consulta").Reset()



        SQLString = "SELECT  ChequeoPlanta.* FROM ChequeoPlanta WHERE (CodigoLectura = '" & CodigoBarra & "') AND (TipoLectura = '" & Me.TxtTipo.Text & "') AND (CodigoRemision = " & NoTiket & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            MsgBox("Ya Existe esta Lectura en el sistema", MsgBoxStyle.Critical, "Sistema Remision")
            Exit Sub
        End If

        If Me.TxtTipo.Text = "Salida" Then
            SQLString = "SELECT  ChequeoPlanta.* FROM ChequeoPlanta WHERE (CodigoLectura = '" & CodigoBarra & "') AND (TipoLectura = 'Entrada') AND (CodigoRemision = " & NoTiket & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If DataSet.Tables("Consulta").Rows.Count = 0 Then
                MsgBox("No Existe Entrada para esta Lectura", MsgBoxStyle.Critical, "Sistema Remision")
                Exit Sub
            End If
        End If

        IdLugarAcopio = BuscaIdLocalidad(LeeArchivo)

        '//////////////////////////////////////////////////////////////////////////////////////////////
        '////////////////////////////AGREGO EL ENCABEZADO DE LA COMPRA///////////////////////////////////
        '/////////////////////////////////////////////////////////////////////////////////////////////////
        MiConexion.Close()
        SQLString = "INSERT INTO [ChequeoPlanta] ([CodigoLectura],[Fecha],[TipoLectura],[IdLugarAcopio],[CodigoRemision]) " & _
                    "VALUES ('" & CodigoBarra & "','" & Format(Now, "dd/MM/yyyy H:mm:ss") & "','" & Me.TxtTipo.Text & "'," & IdLugarAcopio & "," & NoTiket & ")"
        MiConexion.Open()
        ComandoUpdate = New SqlClient.SqlCommand(SQLString, MiConexion)
        iResultado = ComandoUpdate.ExecuteNonQuery
        MiConexion.Close()

        MsgBox("Grabado con Exito!!!", MsgBoxStyle.Exclamation, "Sistema PuntoRevision")
        Me.TxtCodigoBarra.Text = ""
        Me.TxtBarraBoleta.Text = "1234567890"
        Me.LblLocalidad.Text = ""
        Me.LblConductor.Text = ""
        Me.LblTicket.Text = ""
        Me.LblTicket.Text = ""
        Me.LblBoleta.Text = ""
        Me.LblPlaca.Text = ""
        NoTiket = 0
        CodigoBarra = ""
        Me.TxtCodigoBarra.Focus()


        Me.Close()
    End Sub

    Private Sub FrmLectura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String, RutaLogo As String
        Dim Fecha As String = "", SQlstring As String
        MiConexion = New SqlClient.SqlConnection(Conexion)


        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then

            Me.LblEncabezado.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
            'ArepRemision.TxtDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")

            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                'ArepRemision.TxtRuc.Text = "Numero RUC:  " & DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")

            End If
            If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                RutaLogo = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")
                If Dir(RutaLogo) <> "" Then
                    Me.ImgLogo.Image = New System.Drawing.Bitmap(RutaLogo)
                End If

            End If
        End If

        '//////////////////////////////////////////////////////////COSECHA ///////////////////////////////////////////////////
        Fecha = Format(Now, "yyyy-MM-dd")
        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        'SqlString = "SELECT *, YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (FechaInicial <= CONVERT(DATETIME, '" & Fecha & "', 102)) AND (FechaFinal >= CONVERT(DATETIME, '" & Fecha & "', 102))"
        SQlstring = "SELECT IdCosecha, Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CodigoCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlstring, MiConexion)
        DataAdapter.Fill(Dataset, "Cosecha")
        If Dataset.Tables("Cosecha").Rows.Count = 0 Then
            Me.LblCosecha.Text = "Cosecha NO DEFINIDA"
        Else
            Me.LblCosecha.Text = "Cosecha " & Dataset.Tables("Cosecha").Rows(0)("AñoIni") & "-" & Dataset.Tables("Cosecha").Rows(0)("AñoFin")
        End If
    End Sub

    Private Sub TxtBarraBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBarraBoleta.Click

    End Sub
End Class