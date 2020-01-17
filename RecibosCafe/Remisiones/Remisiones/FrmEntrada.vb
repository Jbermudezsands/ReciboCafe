Public Class FrmEntrada
    Public MiConexion As New SqlClient.SqlConnection
    Private Sub FrmEntrada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fileReader As String, Ruta As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Ruta = My.Application.Info.DirectoryPath & "\SysInfo.txt"
        fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
        Conexion = fileReader


        MiConexion = New SqlClient.SqlConnection(Conexion)


        '////////////////////Declaro las Consultas a Utilizar/////////////////////////////////////////////////
        Dim strSQL As String = "SELECT Usuario FROM Usuarios"

        '/////////////////////////Declaro las variables de Conexion//////////////////////////////////////// 

        Dim DRUsuarios As SqlClient.SqlDataReader
        Dim DTUsuarios As New DataTable
        Dim CmUsuarios As SqlClient.SqlCommand

        '///////////////////Establecemos Conexion con la Base de Datos///////////////////////////////////////
        CmUsuarios = New SqlClient.SqlCommand(strSQL, MiConexion)

        '////////////////Abrimos Conexion con la Base de Datos////////////////////////////
        MiConexion.Open()

        '///////Ejecutamos la Sentencias SQL////////////////////////////////////////////
        DRUsuarios = CmUsuarios.ExecuteReader()

        '///////Cargamos los Resultados en el Objeto Table////////////////////////////////////////
        DTUsuarios.Load(DRUsuarios, LoadOption.OverwriteChanges)
        Me.CboUsuario.DataSource = DTUsuarios
        CmUsuarios = Nothing

        If DTUsuarios.Rows.Count = 0 Then
            Me.Hide()
            My.Forms.MDIParent1.ShowDialog()
            Me.Close()
        End If

        MiConexion.Close()
    End Sub

    Private Sub cmdEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEntrar.Click
        Dim DataSetUsuario As New DataSet
        Dim DataAdapterUsuario As New SqlClient.SqlDataAdapter
        Dim SqlUsuario As String
        Dim Contraseña As String, Usuario As String, BDContraseña As String

        If Me.CboUsuario.Text = "" Then
            MsgBox("Seleccione un Usuario", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If

        If Not Me.txtPassword.Text = "" Then
            Contraseña = Me.txtPassword.Text
            Usuario = Me.CboUsuario.Text
            NombreUsuario = Me.CboUsuario.Text

            MiConexion.Open()
            SqlUsuario = "SELECT Usuario, Contraseña, Tipo, IdUsuarioEcs,IdRegion FROM Usuarios WHERE (Usuario = '" & Usuario & "')"

            DataAdapterUsuario = New SqlClient.SqlDataAdapter(SqlUsuario, MiConexion)
            DataAdapterUsuario.Fill(DataSetUsuario, "Usuarios")
            If Not DataSetUsuario.Tables("Usuarios").Rows.Count = 0 Then
                BDContraseña = DataSetUsuario.Tables("Usuarios").Rows(0)("Contraseña")
                TipoUsuario = DataSetUsuario.Tables("Usuarios").Rows(0)("Tipo")
                IdUsuario = DataSetUsuario.Tables("Usuarios").Rows(0)("IdUsuarioEcs")
                UsuarioType = DataSetUsuario.Tables("Usuarios").Rows(0)("Tipo")
                If Not IsDBNull(DataSetUsuario.Tables("Usuarios").Rows(0)("IdRegion")) Then
                    IdRegionUsuario = DataSetUsuario.Tables("Usuarios").Rows(0)("IdRegion")
                Else
                    IdRegionUsuario = "0"
                End If

                If BDContraseña = Contraseña Then
                    MiConexion.Close()
                    Me.Hide()
                    My.Forms.MDIParent1.ShowDialog()
                    Me.Close()
                Else
                    MsgBox("Contraseña Incorrecta", MsgBoxStyle.Exclamation, "Sistema Facturacion")
                    MiConexion.Close()
                    Exit Sub
                End If
            End If
            MiConexion.Close()
        Else
            MsgBox("Digite la Contraseña", MsgBoxStyle.Critical, "Sistema Facturacion")
            Exit Sub
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class