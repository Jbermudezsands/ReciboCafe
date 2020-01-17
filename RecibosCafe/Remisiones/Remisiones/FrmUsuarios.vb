Public Class FrmUsuarios
    Public MiConexion As New SqlClient.SqlConnection(Conexion)

    Private Sub FrmUsuarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'MDIParent1.Button1.Visible = True
        'MDIParent1.Button2.Visible = True
        'MDIParent1.Button3.Visible = True
    End Sub
    Private Sub FrmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlUsuarios As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        SqlUsuarios = "SELECT Usuario,Tipo FROM Usuarios WHERE (Usuario = '" & NombreUsuario & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlUsuarios, MiConexion)
        DataAdapter.Fill(DataSet, "ListaUsuarios")
        If Not DataSet.Tables("ListaUsuarios").Rows.Count = 0 Then
            Me.CboUsuario.DataSource = DataSet.Tables("ListaUsuarios")
        End If

        Me.TxtNivel.Text = "Administrador"
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click
        Dim strusuario As String, SqlUsuarios As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Tipo As String

        If Me.CboUsuario.Text = "" Then
            MsgBox("Digite el Nombre del Usuario", MsgBoxStyle.Critical, "Sistema Remision")
            Exit Sub
        End If


        'If Me.ChkAdministrador.Checked = True Then
        '    Tipo = "Administrador"
        'Else
        '    Tipo = "Normal"
        'End If

        Tipo = Me.TxtNivel.Text


        If Not Me.TxtContraseña.Text = Me.TxtConfirmar.Text Then
            MsgBox("LAS CONTRASEÑAS NO COINCIDEN!", MsgBoxStyle.Critical, "Sistema de Factuacion")
            Exit Sub
        End If

        If Me.TxtContraseña.Text = "" Then
            MsgBox("La Contraseña no puede quedar Vacia", MsgBoxStyle.Critical, "Sistema de Facturacion")
            Exit Sub

        End If

        strusuario = "Select * FROM Usuarios Where Usuario= '" & Me.CboUsuario.Text & "'"
        DataAdapter = New SqlClient.SqlDataAdapter(strusuario, MiConexion)
        DataAdapter.Fill(DataSet, "Usuario")
        If Not DataSet.Tables("Usuario").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Usuarios] SET [Contraseña] = '" & Me.TxtContraseña.Text & "',[Tipo] = '" & Tipo & "' " & _
                           "WHERE [Usuario] = '" & Me.CboUsuario.Text & "' "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            'Nivel = Me.TxtNivel.Text
            StrSqlUpdate = "INSERT INTO [Usuarios] ([Usuario],[Contraseña],[Tipo]) " & _
                           "VALUES('" & Me.CboUsuario.Text & "','" & Me.TxtContraseña.Text & "','" & Tipo & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If

        SqlUsuarios = "SELECT Usuario  FROM Usuarios"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlUsuarios, MiConexion)

        DataAdapter.Fill(DataSet, "ListaUsuarios")
        DataSet.Tables("ListaUsuarios").Reset()
        DataAdapter.Fill(DataSet, "ListaUsuarios")
        If Not DataSet.Tables("ListaUsuarios").Rows.Count = 0 Then
            Me.CboUsuario.DataSource = DataSet.Tables("ListaUsuarios")

        End If

        MsgBox("El usuario se Grabo Correctamente!!", MsgBoxStyle.Information, "Sistema de Facturacion")
        Me.CboUsuario.Text = ""
        Me.TxtConfirmar.Visible = False
        Me.LblConfirmar.Visible = False
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim strusuario As String, SqlUsuarios As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel, "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If




        strusuario = "Select * FROM Usuarios Where Usuario= '" & Me.CboUsuario.Text & "'"
        DataAdapter = New SqlClient.SqlDataAdapter(strusuario, MiConexion)
        DataAdapter.Fill(DataSet, "Usuario")
        If Not DataSet.Tables("Usuario").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Usuarios] " & _
                           "WHERE [Usuario] = '" & Me.CboUsuario.Text & "' "
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        SqlUsuarios = "SELECT Usuario  FROM Usuarios"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlUsuarios, MiConexion)

        DataAdapter.Fill(DataSet, "ListaUsuarios")
        DataSet.Tables("ListaUsuarios").Reset()
        DataAdapter.Fill(DataSet, "ListaUsuarios")
        If Not DataSet.Tables("ListaUsuarios").Rows.Count = 0 Then
            Me.CboUsuario.DataSource = DataSet.Tables("ListaUsuarios")

        End If

        MsgBox("El Usuario se Elimino Correctamente", MsgBoxStyle.Information, "Sistema de Facturacion")

        Me.CboUsuario.Text = ""
        Me.TxtConfirmar.Visible = False
        Me.LblConfirmar.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CboUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboUsuario.TextChanged
        Dim StrUsuario As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter

        StrUsuario = "Select * FROM Usuarios Where Usuario = '" & Me.CboUsuario.Text & "'"
        DataAdapter = New SqlClient.SqlDataAdapter(StrUsuario, MiConexion)
        DataAdapter.Fill(DataSet, "Usuario")
        If Not DataSet.Tables("Usuario").Rows.Count = 0 Then
            Me.TxtContraseña.Text = DataSet.Tables("Usuario").Rows(0)("Contraseña")

            If DataSet.Tables("Usuario").Rows(0)("Tipo") = "Administrador" Then
                Me.ChkAdministrador.Checked = True
            Else
                Me.ChkAdministrador.Checked = False
            End If
        Else
            Me.TxtContraseña.Text = ""
            Me.TxtConfirmar.Text = ""
        End If
    End Sub

    Private Sub TxtNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNivel.SelectedIndexChanged

    End Sub

    Private Sub TxtContraseña_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtContraseña.TextChanged
        If Not Me.TxtContraseña.Text = "" Then
            Me.TxtConfirmar.Visible = True
            Me.LblConfirmar.Visible = True
        End If
    End Sub
End Class