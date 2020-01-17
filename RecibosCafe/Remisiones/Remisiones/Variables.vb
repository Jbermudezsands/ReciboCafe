Module Variables
    Public Conexion As String, Enfoque As String, CodigoCosecha As String, Quien3 As String, QuienRemision As String
    Public NombreUsuario As String = "Desconocido", TipoUsuario As String = "Administrador", CodLocalidadActual As String, Quien As String
    Public CodigoRepesaje As String, QuienTec As String, Sugerencia As String, IdUsuario As Double, UsuarioType As String, IdRegionUsuario As Integer, Quien2 As String, CambioPrecio As Boolean = False
    Public ValidaBoleta As Boolean = True
    Public Function BuscaLocalidad(ByVal CodigoLocalidad As String) As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, Ruta As String, fileReader As String
        Dim MiConexion As New SqlClient.SqlConnection

        Ruta = My.Application.Info.DirectoryPath & "\SysInfo.txt"
        fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
        Conexion = fileReader
        MiConexion = New SqlClient.SqlConnection(Conexion)
        BuscaLocalidad = ""

        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT CodLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (CodLugarAcopio = " & CodigoLocalidad & ") AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Consulta")
        If Dataset.Tables("Consulta").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No esta Activa", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        Else
            BuscaLocalidad = Dataset.Tables("Consulta").Rows(0)("NomLugarAcopio")
            CodLocalidadActual = Dataset.Tables("Consulta").Rows(0)("CodLugarAcopio")
        End If
    End Function

    Public Function BuscaIdLocalidad(ByVal CodigoLocalidad As String) As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, Ruta As String, fileReader As String
        Dim MiConexion As New SqlClient.SqlConnection

        MiConexion = New SqlClient.SqlConnection(Conexion)
        BuscaIdLocalidad = ""

        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT * FROM LugarAcopio WHERE (CodLugarAcopio = " & CodigoLocalidad & ") AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Consulta")
        If Dataset.Tables("Consulta").Rows.Count = 0 Then
            ''MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        Else
            BuscaIdLocalidad = Dataset.Tables("Consulta").Rows(0)("IdLugarAcopio")

        End If
    End Function

    Public Function BuscaIdVehiculo(ByVal Placa As String) As String
        Dim Dataset As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String
        Dim MiConexion As New SqlClient.SqlConnection

        MiConexion = New SqlClient.SqlConnection(Conexion)

        BuscaIdVehiculo = ""

        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT * FROM Vehiculo WHERE (Placa = '" & Placa & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(Dataset, "Consulta")
        If Dataset.Tables("Consulta").Rows.Count = 0 Then
            ''MsgBox("No Existe esta Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        Else
            BuscaIdVehiculo = Dataset.Tables("Consulta").Rows(0)("IdVehiculo")

        End If
    End Function
End Module
