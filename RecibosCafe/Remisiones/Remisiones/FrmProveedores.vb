Public Class FrmProveedores
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT * FROM Proveedor"
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")


    End Sub

    Private Sub CboCodigoProveedor_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Me.CboCodigoProveedor.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Reintegro As Double, Exonerado As Double, Exclusivo As Double

        If Me.ChkReintegro.Checked = True Then
            Reintegro = 1
        Else
            Reintegro = 0
        End If

        If Me.ChkExonerado.Checked = True Then
            Exonerado = 1
        Else
            Exonerado = 0
        End If

        If Me.ChkExclusivo.Checked = True Then
            Exclusivo = 1
        Else
            Exclusivo = 0
        End If


        SQLProveedor = "SELECT TOP (1) PERCENT dbo.Proveedor.* FROM Proveedor WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') ORDER BY Cod_Proveedor"
         DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedores")
        If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
            StrSqlUpdate = "UPDATE [Proveedor] SET [Nombre_Proveedor] = '" & Me.TxtNombre.Text & "',[Apellido_Proveedor] = '" & Me.TxtApellido.Text & "',[Direccion_Proveedor] = '" & Me.TxtDireccion.Text & "',[Telefono] = '" & Me.TxtTelefono.Text & "',[Cod_Cuenta_Pagar] = '" & Me.TxtCtaxPagar.Text & "',[Cod_Cuenta_Cobrar] = '" & Me.TxtCtaxPagar.Text & "',[Merma] = '" & Me.TxtMerma.Text & "',[Reintegro] = " & Reintegro & ",[Exonerado] = " & Exonerado & ",[Exclusivo] = " & Exclusivo & "  WHERE Cod_Proveedor= '" & Me.CboCodigoProveedor.Text & "'"

            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        Else
            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
            StrSqlUpdate = "INSERT INTO [Proveedor] ([Cod_Proveedor],[Nombre_Proveedor],[Apellido_Proveedor],[Direccion_Proveedor],[Telefono],[Cod_Cuenta_Pagar],[Cod_Cuenta_Cobrar],[Merma],[Reintegro],[Exonerado],[Exclusivo]) " & _
                               "VALUES ('" & Me.CboCodigoProveedor.Text & "','" & Me.TxtNombre.Text & "','" & Me.TxtApellido.Text & "','" & Me.TxtDireccion.Text & "','" & Me.TxtTelefono.Text & "','" & Me.TxtCtaxPagar.Text & "','" & Me.TxtCtaxCobrar.Text & "','" & Me.TxtMerma.Text & "'," & Reintegro & "," & Exonerado & ", " & Exclusivo & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

        End If
        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Proveedor.* FROM Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")
        End If

        Me.CboCodigoProveedor.Text = ""

    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        Dim SQLProveedor As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim Resultado As String

        Resultado = MsgBox("¿Esta Seguro de Eliminar el Usuario?", MsgBoxStyle.OkCancel , "Sistema de Facturacion")

        If Not Resultado = "1" Then
            Exit Sub
        End If


        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Proveedor.* FROM Proveedor WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "') ORDER BY Cod_Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedores")
        If Not DataSet.Tables("Proveedores").Rows.Count = 0 Then
            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////


            StrSqlUpdate = "DELETE FROM [Proveedor] WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


        End If

        SQLProveedor = "SELECT TOP (100) PERCENT dbo.Proveedor.* FROM Proveedor"
        DataAdapter = New SqlClient.SqlDataAdapter(SQLProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "ListaProveedores")
        If Not DataSet.Tables("ListaProveedores").Rows.Count = 0 Then
            Me.CboCodigoProveedor.DataSource = DataSet.Tables("ListaProveedores")
        End If

        Me.CboCodigoProveedor.Text = ""
    End Sub

    Private Sub CboCodigoProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.Click
        FrmTeclado.ShowDialog()
        Me.CboCodigoProveedor.Text = FrmTeclado.Numero
    End Sub

    Private Sub CboCodigoProveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.GotFocus

    End Sub


    Private Sub CboCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCodigoProveedor.TextChanged
        Dim SqlProveedor As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String

        SqlProveedor = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.CboCodigoProveedor.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        DataAdapter.Fill(DataSet, "Proveedor")
        If Not DataSet.Tables("Proveedor").Rows.Count = 0 Then
            Me.TxtNombre.Text = DataSet.Tables("Proveedor").Rows(0)("Nombre_Proveedor")
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")) Then
                Me.TxtApellido.Text = DataSet.Tables("Proveedor").Rows(0)("Apellido_Proveedor")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")) Then
                Me.TxtDireccion.Text = DataSet.Tables("Proveedor").Rows(0)("Direccion_Proveedor")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Telefono")) Then
                Me.TxtTelefono.Text = DataSet.Tables("Proveedor").Rows(0)("Telefono")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Merma")) Then
                Me.TxtMerma.Text = DataSet.Tables("Proveedor").Rows(0)("Merma")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Cod_Cuenta_Cobrar")) Then
                Me.TxtCtaxCobrar.Text = DataSet.Tables("Proveedor").Rows(0)("Cod_Cuenta_Cobrar")
            End If
            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Cod_Cuenta_Pagar")) Then
                Me.TxtCtaxPagar.Text = DataSet.Tables("Proveedor").Rows(0)("Cod_Cuenta_Pagar")
            End If

            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Reintegro")) Then
                If DataSet.Tables("Proveedor").Rows(0)("Reintegro") = True Then
                    Me.ChkReintegro.Checked = True
                Else
                    Me.ChkReintegro.Checked = False
                End If
            Else
                Me.ChkReintegro.Checked = False
            End If

            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Exonerado")) Then
                If DataSet.Tables("Proveedor").Rows(0)("Exonerado") = True Then
                    Me.ChkExonerado.Checked = True
                Else
                    Me.ChkExonerado.Checked = False
                End If
            Else
                Me.ChkExonerado.Checked = False
            End If

            If Not IsDBNull(DataSet.Tables("Proveedor").Rows(0)("Exclusivo")) Then
                If DataSet.Tables("Proveedor").Rows(0)("Exclusivo") = True Then
                    Me.ChkExclusivo.Checked = True
                Else
                    Me.ChkExclusivo.Checked = False
                End If
            Else
                Me.ChkExclusivo.Checked = False
            End If




        Else

            Me.TxtNombre.Text = ""
            Me.TxtApellido.Text = ""
            Me.TxtDireccion.Text = ""
            Me.TxtTelefono.Text = ""
            Me.TxtMerma.Text = ""
            Me.TxtCtaxCobrar.Text = ""
            Me.TxtCtaxPagar.Text = ""

        End If
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConsulta.Click
        Quien = "CodigoProveedor"
        My.Forms.FrmConsultas.ShowDialog()
        Me.CboCodigoProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Quien = "CuentaPagar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxPagar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quien = "CuentaCobrar"
        My.Forms.FrmConsultas.ShowDialog()
        Me.TxtCtaxCobrar.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FrmTeclado.ShowDialog()
        Me.CboCodigoProveedor.Text = FrmTeclado.Numero
    End Sub
End Class