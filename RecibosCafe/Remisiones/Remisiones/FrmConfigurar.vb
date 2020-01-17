Public Class FrmConfigurar
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmConfigurar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'MDIParent1.Button1.Visible = True
        'MDIParent1.Button2.Visible = True
        'MDIParent1.Button3.Visible = True
    End Sub
    Private Sub FrmConfigurar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim MyRuta As String, SqlString As String, Ruta As String
        Dim fileReader As String = ""
        Try

            Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
            If Dir(Ruta) <> "" Then
                fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
                Me.CmbLocalidad.Text = fileReader
            Else
                MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            End If
            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            SqlString = "SELECT  CodLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1) ORDER BY CodLugarAcopio"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Localidad")
            Me.CmbLocalidad.DataSource = DataSet.Tables("Localidad")

            Ruta = My.Application.Info.DirectoryPath & "\Cosecha.txt"
            If Dir(Ruta) <> "" Then
                fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
                Me.CmbCosecha.Text = fileReader
            Else
                MsgBox("No Existe el Archivo Cosecha", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            End If

            '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
            SqlString = "SELECT IdCosecha,CONVERT(char, FechaInicial, 103) AS FechaInicial, CONVERT(char, FechaFinal, 103) AS FechaFinal FROM Cosecha"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "Cosecha")
            Me.CmbCosecha.DataSource = DataSet.Tables("Cosecha")

            SqlDatos = "SELECT * FROM DatosEmpresa"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
            DataAdapter.Fill(DataSet, "DatosEmpresa")
            If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
                Me.TxtNombreEmpresa.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Nombre_Empresa")
                Me.TxtDireccion.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Direccion_Empresa")
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")) Then
                    Me.TxtTelefono.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Telefono")
                End If
                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")) Then
                    Me.TxtRuc.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Numero_Ruc")
                End If

                If Not IsDBNull(DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")) Then
                    Me.TxtRutaLogo.Text = DataSet.Tables("DatosEmpresa").Rows(0)("Ruta_Logo")

                    ImgLogo.ImageLocation = Me.TxtRutaLogo.Text
                    MyRuta = Dir(Me.TxtRutaLogo.Text)
                    If MyRuta <> "" Then
                        ImgLogo.Load()
                    Else
                        MsgBox("No Existe imagen para esta ruta", MsgBoxStyle.Critical, "Zeus Facturacion")
                        Exit Sub
                    End If
                End If


            End If





        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlDatos As String
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Sincroniza As Boolean
        Dim Ruta As String = My.Application.Info.DirectoryPath & "\Localidad.txt"
        Dim RutaCosecha As String = My.Application.Info.DirectoryPath & "\Cosecha.txt"

        If Dir(Ruta) <> "" Then
            Dim sw As New System.IO.StreamWriter(Ruta)
            sw.WriteLine(Trim(Me.CmbLocalidad.Text))
            sw.Close()
        End If

        If Dir(Ruta) <> "" Then
            Dim sw As New System.IO.StreamWriter(RutaCosecha)
            sw.WriteLine(Trim(Me.CmbCosecha.Text))
            sw.Close()
        End If


        If Me.TxtNombreEmpresa.Text = "" Then
            MsgBox("Se Necesita el Nombre de la Empresa", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TxtDireccion.Text = "" Then
            MsgBox("Se necesita la Direccion", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Me.TxtRutaLogo.Text = "" Then
            MsgBox("Se necesita una Ubicacin", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub
        End If

        SqlDatos = "SELECT * FROM DatosEmpresa"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "DatosEmpresa")
        If Not DataSet.Tables("DatosEmpresa").Rows.Count = 0 Then
            MiConexion.Open()
            StrSqlUpdate = "UPDATE [DatosEmpresa] SET [Nombre_Empresa] = '" & Me.TxtNombreEmpresa.Text & "',[Direccion_Empresa] = '" & Me.TxtDireccion.Text & "',[Numero_Ruc] = '" & Me.TxtRuc.Text & "',[Telefono] = '" & Me.TxtTelefono.Text & "',[Ruta_Logo] = '" & Me.TxtRutaLogo.Text & "' "
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()
            MsgBox("Registros Actualizados", MsgBoxStyle.Exclamation, "Sistema Facturacion")

            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim RutaBD As String
        Me.OpenFileDialog.ShowDialog()
        RutaBD = OpenFileDialog.FileName
        Me.TxtRutaLogo.Text = RutaBD
        If Not Me.TxtRutaLogo.Text = "OpenFileDialog1" Then
            ImgLogo.ImageLocation = Me.TxtRutaLogo.Text
            ImgLogo.Load()
        Else

            Me.TxtRutaLogo.Text = ""
        End If
    End Sub

    Private Sub CmbLocalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLocalidad.TextChanged

    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Quien = "Localidad"
        My.Forms.FrmConsultas.Text = "Consulta Localidad"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA LOCALIDAD"

        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Quien = "Consulta"
            Me.CmbLocalidad.Text = My.Forms.FrmConsultas.Codigo
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Forms.FrmImpresoras.ShowDialog()
    End Sub
End Class