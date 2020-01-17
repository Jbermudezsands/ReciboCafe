Public Class FrmRegistros
    Public MiConexion As New SqlClient.SqlConnection(Conexion), CodLugarAcopio As Double = 0
    Dim IdSucursal As Double = 0, dt As New DataTable, EnfoqueBoleta As Boolean = False, IdLugarAcopio As Double

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.LblHora.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub FrmRegistros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand 'iResultado As Integer
        Dim SqlProductos As String, SqlString As String, Ruta As String, LeeArchivo As String

        Me.DTPFecha.Value = Format(Now, "dd/MM/yyyy HH:mm:ss")
        Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.TxtBoleta.Text = ""

        Me.CboCodigoProveedor.Focus()

        sql = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa FROM   EmpresaTransporte INNER JOIN  VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("Conductor")
        End If

        Me.CboCodigoProveedor.Splits(0).DisplayColumns(1).Width = 200

        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If


        'LeeArchivo = LeeArchivo.Replace(" "c, String.Empty)
        LeeArchivo = Mid(LeeArchivo, 1, 3)

        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & LeeArchivo & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad")
        If DataSet.Tables("Localidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            Me.LblSucursal.Text = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
            IdSucursal = LeeArchivo
            CodLugarAcopio = DataSet.Tables("Localidad").Rows(0)("CodLugarAcopio")
            IdLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
        End If


        '//////////////////////////////////////////////////////////COSECHA ///////////////////////////////////////////////////

        'Fecha = Format(Now, "yyyy-MM-dd")
        'Me.LblFecha.Text = Format(Now, "dd/MM/yyyy")
        'SqlString = "SELECT *, YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (FechaInicial <= CONVERT(DATETIME, '" & Fecha & "', 102)) AND (FechaFinal >= CONVERT(DATETIME, '" & Fecha & "', 102))"
        SqlString = "SELECT IdCosecha, CodCosecha, FechaInicial, FechaFinal, IdCompany, IdUsuario, FechaInicioFinanciamiento, FechaInicioCompra,YEAR(FechaFinal) AS AñoFin, YEAR(FechaInicial) AS AñoIni FROM Cosecha WHERE (IdCosecha = " & CDbl(CodigoCosecha) & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count = 0 Then
            Me.LblCosecha.Text = "Cosecha NO DEFINIDA"
        Else
            Me.LblCosecha.Text = "Cosecha " & DataSet.Tables("Cosecha").Rows(0)("AñoIni") & "-" & DataSet.Tables("Cosecha").Rows(0)("AñoFin")
        End If


        If Me.LblRegistro.Text = "REPORTA EXISTENCIA" Then
            GroupBox6.Visible = False
        End If

        Me.TxtNumeroEnsamble.Text = "-----0-----"

        ''//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
        'SqlString = "SELECT Placa FROM Vehiculo"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Placa")
        'Me.TxtPlaca.DataSource = DataSet.Tables("Placa")
        'Me.TxtPlaca.Splits.Item(0).DisplayColumns(0).Width = 90
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Quien = "Transportista"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
        Me.txtnombre.Text = My.Forms.FrmConsultas.Descripcion
        EnfoqueBoleta = False
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim ConsecutivoCompra As Double, NumeroCarga As String, TipoRegistro As String
        Dim Fecha As Date = Format(Me.DTPFecha.Value, "dd/MM/yyyy") & " " & Me.LblHora.Text
        Dim SqlString As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, IdLocalidad As Double, IdCosecha As Double

        If Len(Me.TxtBoleta.Text) <> 6 Then
            MsgBox("El Numero de Boleta tiene que ser 6 digitos", MsgBoxStyle.Critical, "Registros")
            Exit Sub
        End If

        If ExisteConductor(Me.CboCodigoProveedor.Text) = False Then
            MsgBox("El Codigo del Conductor no Existe", MsgBoxStyle.Critical, "Zeus Recepcion")
            Me.CboCodigoProveedor.Text = ""
            Exit Sub
        End If

        If Me.TxtPlaca.Text = "" Then
            MsgBox("Selecciona un Numero de Placa", MsgBoxStyle.Critical, "Zeus Recepcion")
            Exit Sub
        End If

        Me.CboCodigoProveedor.Focus()

        TipoRegistro = "Nada"

        If Me.TxtNumeroEnsamble.Text = "-----0-----" Then
            If Me.OptLlegada.Checked = True Then
                ConsecutivoCompra = BuscaConsecutivo("Entrada", CodLugarAcopio)
            ElseIf Me.OptSalida.Checked = True Then
                ConsecutivoCompra = BuscaConsecutivo("Salida", CodLugarAcopio)
            ElseIf Me.OptReserva.Checked = True Then
                ConsecutivoCompra = BuscaConsecutivo("Reserva", CodLugarAcopio)
            End If

            NumeroCarga = CodLugarAcopio & "-" & Format(ConsecutivoCompra, "00000#")
        Else
            NumeroCarga = Me.TxtNumeroEnsamble.Text
        End If



        Me.TxtNumeroEnsamble.Text = NumeroCarga

        If Me.OptLlegada.Checked = True Then
            TipoRegistro = "Llegada"
        ElseIf Me.OptSalida.Checked = True Then
            TipoRegistro = "Salida"
        ElseIf Me.OptReserva.Checked = True Then
            TipoRegistro = "Reserva"
        End If



        '////////////////////////////////////////////////////////////////////
        '/////////////////////////////BUSCO SI EXISTE ESTE REGISTRO /////////
        '///////////////////////////////////////////////////////////////////////
        SqlString = "SELECT Registros.*  FROM Registros WHERE (NumeroBoleta = '" & Me.TxtBoleta.Text & "') AND (TipoRegistro = '" & TipoRegistro & "') AND (IdLugarAcopio = '" & IdLugarAcopio & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "LugarAcopio")
        If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
            MsgBox("Ya existe esta boleta par su " & TipoRegistro & "!!!!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        SqlString = "SELECT  * FROM Cosecha WHERE(activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count <> 0 Then
            IdCosecha = DataSet.Tables("Cosecha").Rows(0)("IdCosecha")
        End If

        '//////////////////7BUSCO LA LOCALIDAD ////////////////////////////////////////
        SqlString = "SELECT LugarAcopio.* FROM LugarAcopio WHERE (CodLugarAcopio = " & IdSucursal & ") AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "LugarAcopio")
        If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
            IdLocalidad = DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
        End If


        SqlString = "SELECT LugarAcopio.* FROM LugarAcopio WHERE (CodLugarAcopio = " & IdSucursal & ") AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "LugarAcopio")
        If DataSet.Tables("LugarAcopio").Rows.Count <> 0 Then
            IdLocalidad = DataSet.Tables("LugarAcopio").Rows(0)("IdLugarAcopio")
        End If

        GrabaRegistros(NumeroCarga, TipoRegistro, Me.CboCodigoProveedor.Text, IdLocalidad, Format(Fecha, "dd/MM/yyyy HH:mm:ss"), Me.TxtPlaca.Text, Me.TxtBoleta.Text, IdCosecha)


        MsgBox("Se Grabo el registro de " & TipoRegistro & " No." & NumeroCarga, MsgBoxStyle.Exclamation, "Sistema")
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        Me.CboCodigoProveedor.Text = ""
        Me.txtnombre.Text = ""
        Me.TxtBoleta.Text = ""

    End Sub

    Private Sub CboCodigoProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.Click
        EnfoqueBoleta = False
    End Sub

    Private Sub CboCodigoProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.DoubleClick
        EnfoqueBoleta = False
    End Sub

    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = "", CodConductor As String

        CodConductor = Me.CboCodigoProveedor.Text
        EnfoqueBoleta = False

        'SqlProveedor = "SELECT  * FROM Conductor  WHERE (Codigo = '" & Me.CboCodigoProveedor.Text & "')"

        SqlProveedor = "SELECT DISTINCT EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte WHERE (EmpresaTransporte.Codigo = '" & Me.CboCodigoProveedor.Text & "')"


        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Conductor")
        If Not DataSet.Tables("Conductor").Rows.Count = 0 Then
            Me.txtnombre.Text = DataSet.Tables("Conductor").Rows(0)("NombreEmpresa")
        Else
            Me.txtnombre.Text = ""
        End If

        Dim SqlString As String

        '//////////////////////////////////////////////////////////LLENO EL COMBO PLACAS ///////////////////////////////////////////////////
        'SqlString = "SELECT DISTINCT Vehiculo.Placa FROM Conductor INNER JOIN EmpresaTransporte ON Conductor.IdCompany = EmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON EmpresaTransporte.IdEmpresaTransporte = Vehiculo.IdCompany WHERE (EmpresaTransporte.Codigo = '" & Me.CboCodigoProveedor.Text & "')"
        If Me.OptReserva.Checked = True Then
            SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN  Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN IndiceCarga ON Vehiculo.Placa = IndiceCarga.Placa " & _
                           "WHERE  (EmpresaTransporte.Codigo = '" & Me.CboCodigoProveedor.Text & "') AND (EmpresaTransporte.Activo = 1) AND (VehiculoEmpresaTransporte.Activo = 1)"
        ElseIf OptSalida.Checked = True Then
            SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN Registros ON Vehiculo.Placa = Registros.Placa " & _
                         "WHERE (EmpresaTransporte.Codigo = '" & Me.CboCodigoProveedor.Text & "') AND (Registros.TipoRegistro = 'Reserva') AND (EmpresaTransporte.Activo = 1) AND (VehiculoEmpresaTransporte.Activo = 1)"

        Else
            SqlString = "SELECT DISTINCT Vehiculo.Placa FROM EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo  " & _
                        "WHERE (EmpresaTransporte.Codigo = '" & Me.CboCodigoProveedor.Text & "') AND (EmpresaTransporte.Activo = 1) AND (VehiculoEmpresaTransporte.Activo = 1)"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Placa")
        Me.TxtPlaca.DataSource = DataSet.Tables("Placa")
        Me.TxtPlaca.Splits.Item(0).DisplayColumns(0).Width = 90

        EnfoqueBoleta = False
    End Sub

    Private Sub CmdBoton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton1.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "1"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "1"
            End If
            Exit Sub
        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "1"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "1"
            End If

        End If
    End Sub

    Private Sub CmdBoton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton2.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "2"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "2"
            End If
            Exit Sub
        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "2"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "2"
            End If
        End If
    End Sub

    Private Sub CmdBoton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton3.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "3"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "3"
            End If
            Exit Sub
        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "3"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "3"
            End If
        End If
    End Sub

    Private Sub CmdBoton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton4.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "4"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "4"
            End If
            Exit Sub
        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "4"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "4"
            End If
        End If
    End Sub

    Private Sub CmdBoton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton5.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "5"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "5"
            End If
            Exit Sub
        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "5"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "5"
            End If
        End If
    End Sub

    Private Sub CmdBoton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton6.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "6"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "6"
            End If

        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "6"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "6"
            End If
        End If
    End Sub

    Private Sub CmdBoton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton7.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "7"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "7"
            End If

        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "7"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "7"
            End If
        End If
    End Sub

    Private Sub CmdBoton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton8.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "8"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "8"
            End If

        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "8"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "8"
            End If
        End If
    End Sub

    Private Sub CmdBoton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton9.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "9"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "9"
            End If

        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "9"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "9"
            End If
        End If
    End Sub

    Private Sub CmdBoton0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBoton0.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "0"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "0"
            End If

        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "0"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "0"
            End If
        End If
    End Sub

    Private Sub C1Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button12.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text = "" Then
                Me.TxtBoleta.Text = "+"
            Else
                Me.TxtBoleta.Text = Me.TxtBoleta.Text & "+"
            End If

        Else
            If Me.CboCodigoProveedor.Text = "" Then
                Me.CboCodigoProveedor.Text = "+"
            Else
                Me.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text & "+"
            End If
        End If
    End Sub

    Private Sub C1Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button10.Click
        If EnfoqueBoleta = True Then
            If Me.TxtBoleta.Text <> "" Then
                Me.TxtBoleta.Text = Mid(Me.TxtBoleta.Text, 1, Len(Me.TxtBoleta.Text) - 1)
            End If

        Else
            If Me.CboCodigoProveedor.Text <> "" Then
                Me.CboCodigoProveedor.Text = Mid(Me.CboCodigoProveedor.Text, 1, Len(Me.CboCodigoProveedor.Text) - 1)
            End If
        End If
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click

        Button7_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub TxtNumeroEnsamble_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroEnsamble.TextChanged

    End Sub

    Private Sub TxtPlaca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPlaca.Click
        EnfoqueBoleta = False
    End Sub

    Private Sub TxtPlaca_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPlaca.DoubleClick
        EnfoqueBoleta = False
    End Sub

    Private Sub TxtPlaca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPlaca.TextChanged
        EnfoqueBoleta = False
    End Sub

    Private Sub TxtBoleta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBoleta.Click
        EnfoqueBoleta = True
    End Sub

    Private Sub TxtBoleta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBoleta.DoubleClick
        EnfoqueBoleta = True
    End Sub

    Private Sub TxtBoleta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBoleta.TextChanged
        EnfoqueBoleta = True
    End Sub

    Private Sub txtnombre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnombre.Click
        EnfoqueBoleta = False
    End Sub

    Private Sub txtnombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnombre.TextChanged
        EnfoqueBoleta = False
    End Sub
End Class