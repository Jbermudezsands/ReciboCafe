Public Class FrmReimpresion
    Public MiConexion As New SqlClient.SqlConnection
    Private Sub TxtLocalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLocalidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TxtNumeroBoleta.Focus()
        End If
    End Sub

    Private Sub TxtLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLocalidad.TextChanged

    End Sub

    Private Sub TxtNumeroBoleta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNumeroBoleta.KeyDown
        Dim CodLocalidad As String, NumeroBoleta As String
        Dim SqlString As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        If e.KeyCode = Keys.Enter Then

            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & Me.TxtLocalidad.Text & "') AND (Activo = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(Dataset, "Localidad")
            If Dataset.Tables("Localidad").Rows.Count = 0 Then
                MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Else
                Me.LblLocalidad.Text = Dataset.Tables("Localidad").Rows(0)("NomLugarAcopio")
            End If

            Me.LblBoleta.Text = Me.TxtNumeroBoleta.Text

            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            'SqlString = "SELECT * FROM  PuntoRevision INNER JOIN Conductor ON PuntoRevision.IdEmpresaTransporte = Conductor.IdEmpresaTransporte WHERE  (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (PuntoRevision. IdLugarAcopioChequeo = " & CodLocalidad & ")"
            SqlString = "SELECT PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision.IdLugarAcopioChequeo, Conductor.IdEmpresaTransporte AS Expr1, Conductor.Codigo, Conductor.Nombre, Conductor.Cedula, Conductor.Licencia, Conductor.Estado, Conductor.ListaNegra, Conductor.RazonListaNegra, Conductor.IdUsuario, Conductor.IdCompany, LugarAcopio.CodLugarAcopio FROM  PuntoRevision INNER JOIN  Conductor ON PuntoRevision.IdEmpresaTransporte = Conductor.IdEmpresaTransporte INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio WHERE  (PuntoRevision.NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (LugarAcopio.CodLugarAcopio = '" & Me.TxtLocalidad.Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(Dataset, "Consulta")
            If Dataset.Tables("Consulta").Rows.Count = 0 Then
                MsgBox("No Existe la PuntoRevision", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Else
                Me.LblConductor.Text = Dataset.Tables("Consulta").Rows(0)("Nombre")
                Me.LblTicket.Text = Dataset.Tables("Consulta").Rows(0)("CodigoRemision")

            End If


        End If
    End Sub

    Private Sub TxtNumeroBoleta_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroBoleta.RightToLeftChanged

    End Sub

    Private Sub TxtNumeroBoleta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroBoleta.TextChanged

    End Sub

    Private Sub FrmReimpresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, SqlDatos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Moneda As String, SQlString As String, Fecha As String = ""
        MiConexion = New SqlClient.SqlConnection(Conexion)

        Fecha = Format(Now, "yyyy-MM-dd")
        '//////////////////////////////////////////////////////////COSECHA ///////////////////////////////////////////////////
        'SQlString = "SELECT  *, YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (FechaInicial <= CONVERT(DATETIME, '" & Fecha & "', 102)) AND (FechaFinal >= CONVERT(DATETIME, '" & Fecha & "', 102))"
        SQlString = "SELECT IdCosecha, Codigo, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CodigoCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SQlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count = 0 Then
            Me.LblCosecha.Text = "Cosecha NO DEFINIDA"
        Else
            Me.LblCosecha.Text = "Cosecha " & DataSet.Tables("Cosecha").Rows(0)("AñoIni") & "-" & DataSet.Tables("Cosecha").Rows(0)("AñoFin")
        End If
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim ViewerForm As New FrmViewer()
        Dim ArepRemision As New ArepRemision, RutaLogo As String
        Dim DataSet As New DataSet, SqlDatos As String
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Moneda As String, SQlString As String
        Dim SQL As New DataDynamics.ActiveReports.DataSources.SqlDBDataSource, IdEmpresaTransporte As String = ""
        Dim cadena As String


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

        'SqlDatos = "SELECT  * FROM Conductor INNER JOIN EmpresaTransporte ON Conductor.IdCompany = EmpresaTransporte.IdEmpresaTransporte WHERE (Conductor.Codigo = '" & Me.TxtCodigo.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        'DataAdapter.Fill(DataSet, "EmpresaTransporte")
        'If Not DataSet.Tables("EmpresaTransporte").Rows.Count = 0 Then
        '    IdEmpresaTransporte = DataSet.Tables("EmpresaTransporte").Rows(0)("Codigo")
        'End If

        'cadena = Me.TxtLocalidad.Text & Me.TxtNumeroBoleta.Text & IdEmpresaTransporte & Me.TxtPlaca.Text
        'ArepRemision.TxtCodigoBarra.Text = cadena

        'SQlString = "SELECT  * FROM PuntoRevision INNER JOIN Conductor ON PuntoRevision.IdEmpresaTransporte = Conductor.IdEmpresaTransporte INNER JOIN  LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio  WHERE(PuntoRevision.NumeroBoleta = '" & Me.TxtNumeroBoleta.Text & "') AND (LugarAcopio.CodLugarAcopio = '" & Me.TxtLocalidad.Text & "')"

        'SQL.ConnectionString = Conexion
        'SQL.SQL = SQlString

        ArepRemision.LblCosecha.Text = Me.LblCosecha.Text

        ViewerForm.arvMain.Document = ArepRemision.Document
        My.Application.DoEvents()
        ArepRemision.DataSource = SQL
        'ArepRemision.Run(False)
        'ViewerForm.Show()
        ViewerForm.arvMain.Document.Print(False, False, False)

    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Me.Close()
    End Sub
End Class