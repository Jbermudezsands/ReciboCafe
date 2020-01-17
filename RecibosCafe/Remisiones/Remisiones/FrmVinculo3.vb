Public Class FrmVinculo3
    Public MiConexion As New SqlClient.SqlConnection(Conexion), DataSet As New DataSet, oDatarowCalidad As DataRow
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim Reg As Double, i As Double, r As String, DataAdapter As SqlClient.SqlDataAdapter
        Dim IdCalidad As Double = 0, SqlString As String, StrSqlUpdate As String, IdTipoCafe As Double = 0
        Dim row As String, col As Integer, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Cont As Double, j As Double
        Dim row2 As String, IdEdoFisico As Double


        '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////

        SqlString = "SELECT IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE  (Nombre = '" & Me.ListTipoCafe.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdTipoCafe = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
        End If


        DataSet.Tables("Consulta").Reset()


        '/////////////////////////RECORRO EL LISTADO DE CALIDAD /////////////////////////////////
        'Reg = Me.ListCalidad.ListCount - 1

                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////

        'For i = 0 To Reg

        '    If Me.ListCalidad.SelectedIndices.Contains(i) = True Then

        '        Me.ListCalidad.Row = i
        '        row = Me.ListCalidad.Columns(1).Text
        '        IdCalidad = Me.ListCalidad.Columns("IdCalidad").Text

        '////////////////////////////////RECORRO EL LISTADO DE ESTADO FISICO ////////////////////////////////////////////

        '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
        SqlString = "SELECT  IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion   FROM Calidad " & _
                    "WHERE   (NomCalidad = '" & Me.CboTipoCalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta2")
        If DataSet.Tables("Consulta2").Rows.Count <> 0 Then
            IdCalidad = DataSet.Tables("Consulta2").Rows(0)("IdCalidad")
        End If
        DataSet.Tables("Consulta2").Reset()

        Cont = Me.ListEstadoFisico.ListCount - 1
        For j = 0 To Cont
            If Me.ListEstadoFisico.SelectedIndices.Contains(j) = True Then
                Me.ListEstadoFisico.Row = j
                row2 = Me.ListEstadoFisico.Columns("IdEdoFisico").Text
                IdEdoFisico = Me.ListEstadoFisico.Columns("IdEdoFisico").Text

                '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                SqlString = "SELECT        RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe, RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad, RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico, Calidad.NomCalidad, EstadoFisico.Descripcion FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN  Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoFisico ON RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = EstadoFisico.EstadoFisico  " & _
                            "WHERE  (RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = " & IdCalidad & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdTipoCafe & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = " & IdEdoFisico & ")"

                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "BuscaCalidad")

                If DataSet.Tables("BuscaCalidad").Rows.Count = 0 Then

                    MiConexion.Close()
                    '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                    StrSqlUpdate = "INSERT INTO [RelacionTipoCafeXCalidadXEstadoFisico] ([IdTipoCafe],[IdCalidad],[IdEdoFisico]) VALUES (" & IdTipoCafe & "," & IdCalidad & ", " & IdEdoFisico & ")"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

                DataSet.Tables("BuscaCalidad").Reset()

            Else

                Me.ListEstadoFisico.Row = j
                row2 = Me.ListEstadoFisico.Columns("IdEdoFisico").Text
                IdEdoFisico = Me.ListEstadoFisico.Columns("IdEdoFisico").Text

                SqlString = "SELECT        RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe, RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad, RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico, Calidad.NomCalidad, EstadoFisico.Descripcion FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN  Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoFisico ON RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = EstadoFisico.EstadoFisico  " & _
                           "WHERE  (RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = " & IdCalidad & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdTipoCafe & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = " & IdEdoFisico & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "BuscaCalidad")

                If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                    '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                    MiConexion.Close()
                    StrSqlUpdate = "DELETE FROM RelacionTipoCafeXCalidadXEstadoFisico  WHERE  (RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = " & IdCalidad & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdTipoCafe & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = " & IdEdoFisico & ")"
                    MiConexion.Open()
                    ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                    iResultado = ComandoUpdate.ExecuteNonQuery
                    MiConexion.Close()
                End If

                'Me.ListEstadoFisico.SetSelected(i, False)
                DataSet.Tables("BuscaCalidad").Reset()
            End If '/////////////////FIN DEL IF DE ESTADO FISICO ///////////////////////////////
        Next


        '    End If   '/////////////FIN DEL IF DE CALIDAD /////////////////////////////////////////////////

        'Next

        MsgBox("Se ha Grabado con Exito!!!!", MsgBoxStyle.Exclamation, "Sistema Bascula")
        Me.ListEstadoFisico.ClearSelected()
        Me.ListTipoCafe.ClearSelected()
        Me.ListCalidad.ClearSelected()

        'SqlString = "SELECT IdCalidad AS Seleccion, NomCalidad, IdCalidad FROM Calidad "
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Calidad2")
        'Me.CboTipoCalidad.DataSource = DataSet.Tables("Calidad2")
        'Me.CboTipoCalidad.Text = DataSet.Tables("Calidad2").Rows(1)("NomCalidad")

    End Sub

    Private Sub FrmVinculo3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataAdapter As New SqlClient.SqlDataAdapter, Cont As Double, i As Double
        Dim SqlString As String, Registros As Double
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()

        Me.ListCalidad.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.ListEstadoFisico.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.Text = Quien




        SqlString = "SELECT IdCalidad AS Seleccion, NomCalidad, IdCalidad FROM Calidad "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Calidad2")
        Me.CboTipoCalidad.DataSource = DataSet.Tables("Calidad2")
        Me.CboTipoCalidad.Text = DataSet.Tables("Calidad2").Rows(1)("NomCalidad")


        SqlString = "SELECT IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (IdTipoCafe = 1) OR (IdTipoCafe = 2)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "TipoCafe")
        Me.ListTipoCafe.DataSource = DataSet.Tables("TipoCafe")
        Me.ListTipoCafe.DisplayMember = "Descripcion"

        SqlString = "SELECT  Calidad.*  FROM Calidad"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Calidad")
        Me.ListCalidad.DataSource = DataSet.Tables("Calidad")
        Me.ListCalidad.Splits.Item(0).DisplayColumns(0).Visible = False

        SqlString = "SELECT  Codigo, Descripcion, IdEdoFisico FROM EstadoFisico "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "EstadoFisico")
        Me.ListEstadoFisico.DataSource = DataSet.Tables("EstadoFisico")
        Me.ListEstadoFisico.Splits.Item(0).DisplayColumns("IdEdoFisico").Visible = False
        Me.Text = "Tipo Cafe - Calidad - Estado Fisico"


    End Sub

    Private Sub ListTipoCafe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListTipoCafe.SelectedIndexChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, IdtipoCafe As Double = 0, i As Double = 0, Reg As Double = 0
        Dim Descripcion As String, Contador As Double, j As Double = 0, IdTipoCompra As Double = 0
        Dim IdCalidad As Double = 0

        Contador = Me.ListCalidad.ListCount
        If Contador = 0 Then
            Exit Sub
        End If


        Me.ListCalidad.ClearSelected()

        '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
        'SqlString = "SELECT   IdtipoDocumento, Descripcion FROM TipoDocumento WHERE (Descripcion = '" & Me.ListCalidad.Text & "')"
        SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.ListTipoCafe.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdtipoCafe = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
        End If


        '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
        For j = 0 To Contador

            Me.ListCalidad.Row = j

            '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
            'SqlString = "SELECT RelacionTipoDocumentoxCalidad.IdtipoDocumento, RelacionTipoDocumentoxCalidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad  " & _
            '            "WHERE (RelacionTipoDocumentoxCalidad.IdtipoDocumento = " & IdtipoCafe & ") AND (Calidad.NomCalidad = '" & Me.ListCategoria.Columns(2).Text & "')"
            SqlString = "SELECT  RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe, RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad, RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico, Calidad.NomCalidad FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad  " & _
                        "WHERE (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdtipoCafe & ") AND (Calidad.NomCalidad = '" & Me.ListCalidad.Columns("NomCalidad").Text & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "BuscaCalidad")
            Reg = DataSet.Tables("BuscaCalidad").Rows.Count

            If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                Me.ListCalidad.SetSelected(j, True)
            Else
                Me.ListCalidad.SetSelected(j, False)
            End If

            DataSet.Tables("BuscaCalidad").Reset()


        Next

        SqlString = "SELECT IdCalidad AS Seleccion, NomCalidad, IdCalidad FROM Calidad "
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Calidad2")
        Me.CboTipoCalidad.Text = DataSet.Tables("Calidad2").Rows(0)("NomCalidad")

        CboTipoCalidad_SelectedValueChanged(sender, e)

    End Sub

    Private Sub ListCalidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListCalidad.Click
        'Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        'Dim SqlString As String, IdtipoCafe As Double = 0, i As Double = 0, Reg As Double = 0
        'Dim Descripcion As String, Contador As Double, j As Double = 0, IdTipoCompra As Double = 0
        'Dim IdCalidad As Double = 0, row As Double

        'row = Me.ListCalidad.Row
        'Contador = Me.ListEstadoFisico.ListCount
        'If Contador = 0 Then
        '    Exit Sub
        'End If


        'Me.ListEstadoFisico.ClearSelected()

        'SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.ListTipoCafe.Text & "')"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        '    IdtipoCafe = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
        'End If

        ''///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
        ' ''SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.ListCalidad.Text & "')"
        ''SqlString = "SELECT  IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion   FROM Calidad " & _
        ''            "WHERE   (NomCalidad = '" & Me.ListCalidad.Columns("NomCalidad").Text & "')"
        ''DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        ''DataAdapter.Fill(DataSet, "Consulta")
        ''If DataSet.Tables("Consulta").Rows.Count <> 0 Then
        ''    IdCalidad = DataSet.Tables("Consulta").Rows(0)("IdCalidad")
        ''End If

        'IdCalidad = Me.ListCalidad.Columns("IdCalidad").Text


        ''//////////////////////////////RECORRO EL LISTADO ESTOD FISICO ///////////////////////////////////////////
        'For j = 0 To Contador

        '    Me.ListEstadoFisico.Row = j

        '    '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
        '    'SqlString = "SELECT  RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe, RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad, RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico, Calidad.NomCalidad FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad  " & _
        '    '            "WHERE (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdtipoCafe & ") AND (Calidad.NomCalidad = '" & Me.ListCalidad.Columns("NomCalidad").Text & "')"
        '    SqlString = "SELECT  RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe, RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad, RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico, Calidad.NomCalidad, EstadoFisico.Descripcion FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN  Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoFisico ON RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = EstadoFisico.EstadoFisico  " & _
        '                "WHERE  (RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = " & IdCalidad & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdtipoCafe & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = '" & Me.ListEstadoFisico.Columns("IdEdoFisico").Text & "')"
        '    '"WHERE  (EstadoFisico.Descripcion = '" & Me.ListEstadoFisico.Columns("Descripcion").Text & "') AND (RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = " & IdCalidad & ")"
        '    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        '    DataAdapter.Fill(DataSet, "BuscaEstadoFisico")
        '    Reg = DataSet.Tables("BuscaEstadoFisico").Rows.Count

        '    If DataSet.Tables("BuscaEstadoFisico").Rows.Count <> 0 Then
        '        Me.ListEstadoFisico.SetSelected(j, True)
        '    Else
        '        Me.ListEstadoFisico.SetSelected(j, False)
        '    End If

        '    DataSet.Tables("BuscaEstadoFisico").Reset()


        'Next
    End Sub

    Private Sub CboCalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboTipoCalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoCalidad.SelectedIndexChanged

    End Sub

    Private Sub CboTipoCalidad_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTipoCalidad.SelectedValueChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, IdtipoCafe As Double = 0, i As Double = 0, Reg As Double = 0
        Dim Descripcion As String, Contador As Double, j As Double = 0, IdTipoCompra As Double = 0
        Dim IdCalidad As Double = 0, row As Double

        row = Me.ListCalidad.Row
        Contador = Me.ListEstadoFisico.ListCount
        If Contador = 0 Then
            Exit Sub
        End If


        Me.ListEstadoFisico.ClearSelected()

        SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.ListTipoCafe.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If DataSet.Tables("Consulta").Rows.Count <> 0 Then
            IdtipoCafe = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
        End If

        '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
        SqlString = "SELECT  IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion, VDImperfeccion   FROM Calidad " & _
                    "WHERE   (NomCalidad = '" & Me.CboTipoCalidad.Text & "')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta2")
        If DataSet.Tables("Consulta2").Rows.Count <> 0 Then
            IdCalidad = DataSet.Tables("Consulta2").Rows(0)("IdCalidad")
        End If




        '//////////////////////////////RECORRO EL LISTADO ESTOD FISICO ///////////////////////////////////////////
        For j = 0 To Contador

            Me.ListEstadoFisico.Row = j

            '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
            'SqlString = "SELECT  RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe, RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad, RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico, Calidad.NomCalidad FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad  " & _
            '            "WHERE (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdtipoCafe & ") AND (Calidad.NomCalidad = '" & Me.ListCalidad.Columns("NomCalidad").Text & "')"
            SqlString = "SELECT  RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe, RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad, RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico, Calidad.NomCalidad, EstadoFisico.Descripcion FROM RelacionTipoCafeXCalidadXEstadoFisico INNER JOIN  Calidad ON RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = Calidad.IdCalidad INNER JOIN EstadoFisico ON RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = EstadoFisico.EstadoFisico  " & _
                        "WHERE  (RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = " & IdCalidad & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdTipoCafe = " & IdtipoCafe & ") AND (RelacionTipoCafeXCalidadXEstadoFisico.IdEdoFisico = '" & Me.ListEstadoFisico.Columns("IdEdoFisico").Text & "')"
            '"WHERE  (EstadoFisico.Descripcion = '" & Me.ListEstadoFisico.Columns("Descripcion").Text & "') AND (RelacionTipoCafeXCalidadXEstadoFisico.IdCalidad = " & IdCalidad & ")"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "BuscaEstadoFisico")
            Reg = DataSet.Tables("BuscaEstadoFisico").Rows.Count

            If DataSet.Tables("BuscaEstadoFisico").Rows.Count <> 0 Then
                Me.ListEstadoFisico.SetSelected(j, True)
            Else
                Me.ListEstadoFisico.SetSelected(j, False)
            End If

            DataSet.Tables("BuscaEstadoFisico").Reset()


        Next

    End Sub
End Class