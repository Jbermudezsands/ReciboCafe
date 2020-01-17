Public Class FrmVinculo
    Public MiConexion As New SqlClient.SqlConnection(Conexion), DataSet As New DataSet, idCosecha As Double



    Private Sub FrmVinculo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, Registros As Double

        Me.ListCategoria.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.Text = Quien

        Select Case Quien
            Case "TipoDocumento-Calidad"
                SqlString = "SELECT IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (IdTipoCafe = 1) OR (IdTipoCafe = 2)"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TipoDocumento")
                Me.ListCalidad.DataSource = DataSet.Tables("TipoDocumento")
                Me.ListCalidad.DisplayMember = "Descripcion"

                SqlString = "SELECT  Calidad.*  FROM Calidad"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Calidad")
                Me.ListCategoria.DataSource = DataSet.Tables("Calidad")
                Me.ListCategoria.Splits.Item(0).DisplayColumns(0).Visible = False

                Me.Text = "Tipo Cafe - Calidad"

            Case "Calidad-Categoria"
                idCosecha = CodigoCosecha
                SqlString = "SELECT IdRangoImperfeccion, Nombre FROM RangoImperfeccion WHERE (IdCosecha = " & idCosecha & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Categoria")
                Me.ListCategoria.DataSource = DataSet.Tables("Categoria")
                Me.ListCategoria.Splits.Item(0).DisplayColumns(0).Visible = False


                SqlString = "SELECT  Calidad.*  FROM Calidad"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Calidad")
                Me.ListCalidad.DataSource = DataSet.Tables("Calidad")
                Me.ListCalidad.DisplayMember = "NomCalidad"

            Case "Calidad-Daño"
                SqlString = "SELECT Dano.* FROM  Dano"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Daño")
                Me.ListCategoria.DataSource = DataSet.Tables("Daño")
                Me.ListCategoria.Splits.Item(0).DisplayColumns(0).Visible = False

                SqlString = "SELECT  Calidad.*  FROM Calidad"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Calidad")
                Me.ListCalidad.DataSource = DataSet.Tables("Calidad")
                Me.ListCalidad.DisplayMember = "NomCalidad"

            Case "Calidad-Fisico"
                SqlString = "SELECT EstadoFisico.* FROM  EstadoFisico"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Fisico")
                Me.ListCategoria.DataSource = DataSet.Tables("Fisico")
                Me.ListCategoria.Splits.Item(0).DisplayColumns(0).Visible = False

                SqlString = "SELECT  Calidad.*  FROM Calidad"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Calidad")
                Me.ListCalidad.DataSource = DataSet.Tables("Calidad")
                Me.ListCalidad.DisplayMember = "NomCalidad"

                Me.Text = "Calidad - Estado Fisico"

            Case "TipoCompra-Calidad"
                'SqlString = "SELECT Codigo, Nombre FROM TipoCompra"
                SqlString = "SELECT IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (IdTipoCafe = 1) OR (IdTipoCafe = 2)"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "TipoCompra")
                Me.ListCalidad.DataSource = DataSet.Tables("TipoCompra")
                Me.ListCalidad.DisplayMember = "Nombre"

                'SqlString = "SELECT  IdCalidad, NomCalidad  FROM Calidad"
                SqlString = "SELECT IdTipoCompra, Nombre FROM TipoCompra"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Calidad")
                Me.ListCategoria.DataSource = DataSet.Tables("Calidad")

        End Select





        'CheckBox selection


        'Me.ListCategoria.SelectedIndices.Add(0)
        'Me.ListCategoria.SelectedIndices.Add(1)

        'Me.C1List1.ClearSelected()

        'For i = 0 To Me.DsComposer1.Composer.Rows.Count - 1
        '    If Me.DsComposer1.Composer.Rows(i).Item("Country") = "Germany" Then
        '        Me.C1List1.SelectedIndices.Add(i)

        '    End If
        'Next


    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim Reg As Double, i As Double, r As String, IdCategoria As Double, DataAdapter As SqlClient.SqlDataAdapter
        Dim IdCalidad As Double = 0, SqlString As String, StrSqlUpdate As String, IdTipoDocumento As Double = 0
        Dim row As String, col As Integer, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer


        Select Case Quien

            Case "TipoCompra-Calidad"

                '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
                'SqlString = "SELECT   IdTipoCompra, Nombre FROM TipoCompra WHERE (Nombre = '" & Me.ListCalidad.Text & "')"
                SqlString = "SELECT IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE  (Nombre = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdTipoDocumento = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
                End If

                DataSet.Tables("Consulta").Reset()

                'Me.ListCategoria.CellContaining(e.X, e.Y, row, col)
                'If col <> -1 Then
                '    If Me.ListCategoria.SelectedIndices.Contains(row) Then
                '        Me.ListCategoria.SetSelected(row, False)
                '    Else
                '        Me.ListCategoria.SetSelected(row, True)
                '    End If
                'End If

                Reg = Me.ListCategoria.ListCount - 1
                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For i = 0 To Reg

                    If Me.ListCategoria.SelectedIndices.Contains(i) = True Then

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text


                        '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                        'SqlString = "SELECT RelacionTipoDocumentoxCalidad.IdtipoDocumento, RelacionTipoDocumentoxCalidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad  " & _
                        '             "WHERE (RelacionTipoDocumentoxCalidad.IdtipoDocumento = " & IdTipoDocumento & ") AND (Calidad.NomCalidad = '" & Me.ListCategoria.Columns(1).Text & "')"

                        SqlString = "SELECT  IdCalidad, IdTipoCompra FROM RelacionTipoCompraxCalidad WHERE (IdCalidad = '" & Me.ListCategoria.Columns(0).Text & "') AND (IdTipoCompra = " & IdTipoDocumento & ")"

                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count = 0 Then

                            MiConexion.Close()
                            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                            StrSqlUpdate = "INSERT INTO RelacionTipoCompraxCalidad ([IdCalidad],[IdTipoCompra]) VALUES (" & Me.ListCategoria.Columns(0).Text & " ," & IdTipoDocumento & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        DataSet.Tables("BuscaCalidad").Reset()

                    Else

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text

                        SqlString = "SELECT  IdCalidad, IdTipoCompra FROM RelacionTipoCompraxCalidad WHERE (IdCalidad = " & Me.ListCategoria.Columns(0).Text & ") AND (IdTipoCompra = " & IdTipoDocumento & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                            MiConexion.Close()
                            StrSqlUpdate = "DELETE FROM RelacionTipoCompraxCalidad  WHERE(IdCalidad = " & Me.ListCategoria.Columns(0).Text & ") AND (IdTipoCompra = " & IdTipoDocumento & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        Me.ListCategoria.SetSelected(i, False)
                        DataSet.Tables("BuscaCalidad").Reset()

                    End If

                Next


            Case "TipoDocumento-Calidad"

                '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
                'SqlString = "SELECT   IdtipoDocumento, Descripcion FROM TipoDocumento WHERE (Descripcion = '" & Me.ListCalidad.Text & "')"
                SqlString = "SELECT IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE  (Nombre = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdTipoDocumento = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
                End If

                DataSet.Tables("Consulta").Reset()

                'Me.ListCategoria.CellContaining(e.X, e.Y, row, col)
                'If col <> -1 Then
                '    If Me.ListCategoria.SelectedIndices.Contains(row) Then
                '        Me.ListCategoria.SetSelected(row, False)
                '    Else
                '        Me.ListCategoria.SetSelected(row, True)
                '    End If
                'End If

                Reg = Me.ListCategoria.ListCount - 1
                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For i = 0 To Reg






                    If Me.ListCategoria.SelectedIndices.Contains(i) = True Then

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text


                        '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                        'SqlString = "SELECT  IdCalidad, IdCategoriaCAfe FROM RelacionCalidadxCategoria WHERE (IdCalidad = " & IdCalidad & ") AND (IdCategoriaCAfe = " & IdCategoria & ")"

                        SqlString = "SELECT RelacionTipoDocumentoxCalidad.IdtipoDocumento, RelacionTipoDocumentoxCalidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad  " & _
                                     "WHERE (RelacionTipoDocumentoxCalidad.IdtipoDocumento = " & IdTipoDocumento & ") AND (RelacionTipoDocumentoxCalidad.IdCalidad = '" & Me.ListCategoria.Columns(0).Text & "')"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count = 0 Then

                            MiConexion.Close()
                            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                            StrSqlUpdate = "INSERT INTO RelacionTipoDocumentoxCalidad ([IdCalidad],[IdtipoDocumento]) VALUES (" & Me.ListCategoria.Columns(0).Text & " ," & IdTipoDocumento & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        DataSet.Tables("BuscaCalidad").Reset()

                    Else

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text

                        SqlString = "SELECT  IdCalidad, IdtipoDocumento FROM RelacionTipoDocumentoxCalidad WHERE (IdCalidad = " & Me.ListCategoria.Columns(0).Text & ") AND (IdtipoDocumento = " & IdTipoDocumento & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                            MiConexion.Close()
                            StrSqlUpdate = "DELETE FROM RelacionTipoDocumentoxCalidad  WHERE(IdCalidad = " & Me.ListCategoria.Columns(0).Text & ") AND (IdtipoDocumento = " & IdTipoDocumento & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        Me.ListCategoria.SetSelected(i, False)
                        DataSet.Tables("BuscaCalidad").Reset()

                    End If

                Next


            Case "Calidad-Categoria"

                SqlString = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion FROM Calidad WHERE (NomCalidad = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdCalidad = DataSet.Tables("Consulta").Rows(0)("IdCalidad")
                End If

                DataSet.Tables("Consulta").Reset()

                'Me.ListCategoria.CellContaining(e.X, e.Y, row, col)
                'If col <> -1 Then
                '    If Me.ListCategoria.SelectedIndices.Contains(row) Then
                '        Me.ListCategoria.SetSelected(row, False)
                '    Else
                '        Me.ListCategoria.SetSelected(row, True)
                '    End If
                'End If

                Reg = Me.ListCategoria.ListCount - 1
                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For i = 0 To Reg






                    If Me.ListCategoria.SelectedIndices.Contains(i) = True Then

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text


                        '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                        SqlString = "SELECT  IdCalidad, IdCategoriaCAfe FROM RelacionCalidadxCategoria WHERE (IdCalidad = " & IdCalidad & ") AND (IdCategoriaCAfe = " & IdCategoria & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count = 0 Then

                            MiConexion.Close()
                            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                            StrSqlUpdate = "INSERT INTO RelacionCalidadxCategoria ([IdCalidad],[IdCategoriaCAfe]) VALUES (" & IdCalidad & " ," & IdCategoria & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        DataSet.Tables("BuscaCalidad").Reset()

                    Else

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text

                        SqlString = "SELECT  IdCalidad, IdCategoriaCAfe FROM RelacionCalidadxCategoria WHERE (IdCalidad = '" & IdCalidad & "') AND (IdCategoriaCAfe = " & IdCategoria & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                            MiConexion.Close()
                            StrSqlUpdate = "DELETE FROM RelacionCalidadxCategoria  WHERE(IdCalidad = " & IdCalidad & ") AND (IdCategoriaCAfe = " & IdCategoria & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        Me.ListCategoria.SetSelected(i, False)
                        DataSet.Tables("BuscaCalidad").Reset()

                    End If

                Next


            Case "Calidad-Daño"

                SqlString = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion FROM Calidad WHERE (NomCalidad = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdCalidad = DataSet.Tables("Consulta").Rows(0)("IdCalidad")
                End If

                DataSet.Tables("Consulta").Reset()

                'Me.ListCategoria.CellContaining(e.X, e.Y, row, col)
                'If col <> -1 Then
                '    If Me.ListCategoria.SelectedIndices.Contains(row) Then
                '        Me.ListCategoria.SetSelected(row, False)
                '    Else
                '        Me.ListCategoria.SetSelected(row, True)
                '    End If
                'End If

                Reg = Me.ListCategoria.ListCount - 1
                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For i = 0 To Reg






                    If Me.ListCategoria.SelectedIndices.Contains(i) = True Then

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text


                        '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                        SqlString = "SELECT IdCalidad, IdDaño FROM RelacionCalidadxDaño WHERE (IdCalidad = " & IdCalidad & ") AND (IdDaño = " & Me.ListCategoria.Columns(0).Text & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count = 0 Then

                            MiConexion.Close()
                            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                            StrSqlUpdate = "INSERT INTO RelacionCalidadxDaño ([IdCalidad],[IdDaño]) VALUES (" & IdCalidad & " ," & Me.ListCategoria.Columns(0).Text & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()

                        End If

                        DataSet.Tables("BuscaCalidad").Reset()

                    Else

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text

                        SqlString = "SELECT IdCalidad, IdDaño FROM RelacionCalidadxDaño WHERE (IdCalidad = " & IdCalidad & ") AND (IdDaño = " & Me.ListCategoria.Columns(0).Text & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                            MiConexion.Close()
                            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                            StrSqlUpdate = "DELETE FROM RelacionCalidadxDaño  WHERE(IdCalidad = " & IdCalidad & ") AND (IdDaño = " & Me.ListCategoria.Columns(0).Text & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        Me.ListCategoria.SetSelected(i, False)
                        DataSet.Tables("BuscaCalidad").Reset()

                    End If

                Next

            Case "Calidad-Fisico"

                SqlString = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion FROM Calidad WHERE (NomCalidad = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdCalidad = DataSet.Tables("Consulta").Rows(0)("IdCalidad")
                End If

                DataSet.Tables("Consulta").Reset()

                'Me.ListCategoria.CellContaining(e.X, e.Y, row, col)
                'If col <> -1 Then
                '    If Me.ListCategoria.SelectedIndices.Contains(row) Then
                '        Me.ListCategoria.SetSelected(row, False)
                '    Else
                '        Me.ListCategoria.SetSelected(row, True)
                '    End If
                'End If

                Reg = Me.ListCategoria.ListCount - 1

                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For i = 0 To Reg



                    If Me.ListCategoria.SelectedIndices.Contains(i) = True Then

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text


                        '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                        SqlString = "SELECT IdCalidad, EstadoFisico FROM RelacionCalidadxEstadoFisico WHERE (IdCalidad = " & IdCalidad & ") AND (EstadoFisico = " & Me.ListCategoria.Columns(0).Text & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count = 0 Then

                            MiConexion.Close()
                            '/////////SI NO EXISTE LO AGREGO COMO NUEVO/////////////////
                            StrSqlUpdate = "INSERT INTO RelacionCalidadxEstadoFisico ([IdCalidad],[EstadoFisico]) VALUES (" & IdCalidad & " ," & Me.ListCategoria.Columns(0).Text & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery

                        End If

                        DataSet.Tables("BuscaCalidad").Reset()

                    Else

                        Me.ListCategoria.Row = i
                        row = Me.ListCategoria.Columns(1).Text
                        IdCategoria = Me.ListCategoria.Columns(0).Text

                        SqlString = "SELECT IdCalidad, EstadoFisico FROM RelacionCalidadxEstadoFisico WHERE (IdCalidad = " & IdCalidad & ") AND (EstadoFisico = " & Me.ListCategoria.Columns(0).Text & ")"
                        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                        DataAdapter.Fill(DataSet, "BuscaCalidad")

                        If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                            MiConexion.Close()
                            '///////////SI EXISTE EL USUARIO LO ACTUALIZO////////////////
                            StrSqlUpdate = "DELETE FROM RelacionCalidadxEstadoFisico  WHERE(IdCalidad = " & IdCalidad & ") AND (EstadoFisico = " & Me.ListCategoria.Columns(0).Text & ")"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(StrSqlUpdate, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If

                        DataSet.Tables("BuscaCalidad").Reset()
                        Me.ListCategoria.SetSelected(i, False)

                    End If

                Next

        End Select


    End Sub


    Private Sub ListCalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListCalidad.SelectedIndexChanged
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, IdtipoDocumento As Double = 0, i As Double = 0, Reg As Double = 0
        Dim Descripcion As String, Contador As Double, j As Double = 0, IdTipoCompra As Double = 0
        Dim IdCalidad As Double = 0

        Contador = Me.ListCategoria.ListCount
        If Contador = 0 Then
            Exit Sub
        End If

        'For j = 0 To Contador
        '    Me.ListCategoria.SetSelected(j, False)
        'Next

        Me.ListCategoria.ClearSelected()

        Select Case Quien
            Case "TipoDocumento-Calidad"
                '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
                'SqlString = "SELECT   IdtipoDocumento, Descripcion FROM TipoDocumento WHERE (Descripcion = '" & Me.ListCalidad.Text & "')"
                SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdtipoDocumento = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
                End If


                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For j = 0 To Contador

                    Me.ListCategoria.Row = j

                    '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                    SqlString = "SELECT RelacionTipoDocumentoxCalidad.IdtipoDocumento, RelacionTipoDocumentoxCalidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad  " & _
                                "WHERE (RelacionTipoDocumentoxCalidad.IdtipoDocumento = " & IdtipoDocumento & ") AND (Calidad.NomCalidad = '" & Me.ListCategoria.Columns(2).Text & "')"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "BuscaCalidad")
                    Reg = DataSet.Tables("BuscaCalidad").Rows.Count

                    If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                        Me.ListCategoria.SetSelected(j, True)
                    Else
                        Me.ListCategoria.SetSelected(j, False)
                    End If

                    DataSet.Tables("BuscaCalidad").Reset()


                Next

            Case "Calidad-Categoria"

                '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
                SqlString = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion FROM Calidad WHERE (NomCalidad = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdCalidad = DataSet.Tables("Consulta").Rows(0)("IdCalidad")
                End If


                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For j = 0 To Contador

                    Me.ListCategoria.Row = j

                    '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                    'SqlString = "SELECT  RelacionCalidadxCategoria.IdCalidad, RelacionCalidadxCategoria.IdCategoriaCAfe, Categoria.Categoria FROM  RelacionCalidadxCategoria INNER JOIN Categoria ON RelacionCalidadxCategoria.IdCategoriaCAfe = Categoria.IdCategoriaCAfe " & _
                    '             "WHERE(IdCalidad = " & IdCalidad & ") AND (Categoria.Categoria = '" & Me.ListCategoria.Columns(1).Text & "')"

                    SqlString = "SELECT RelacionCalidadxCategoria.IdCalidad, RelacionCalidadxCategoria.IdCategoriaCAfe, RangoImperfeccion.IdRangoImperfeccion, RangoImperfeccion.Nombre FROM  RelacionCalidadxCategoria INNER JOIN RangoImperfeccion ON RelacionCalidadxCategoria.IdCategoriaCAfe = RangoImperfeccion.IdRangoImperfeccion " & _
                                "WHERE (RelacionCalidadxCategoria.IdCalidad = " & IdCalidad & ") AND (RangoImperfeccion.Nombre = '" & Me.ListCategoria.Columns(1).Text & "')"

                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "BuscaCalidad")
                    Reg = DataSet.Tables("BuscaCalidad").Rows.Count

                    If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                        Me.ListCategoria.SetSelected(j, True)
                    Else
                        Me.ListCategoria.SetSelected(j, False)
                    End If

                    DataSet.Tables("BuscaCalidad").Reset()


                Next


            Case "Calidad-Daño"

                Me.Text = "Calidad-Daño"

                '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
                SqlString = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion FROM Calidad WHERE (NomCalidad = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdCalidad = DataSet.Tables("Consulta").Rows(0)("IdCalidad")
                End If




                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For j = 0 To Contador

                    Me.ListCategoria.Row = j

                    '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                    SqlString = "SELECT IdCalidad, IdDaño FROM RelacionCalidadxDaño WHERE (IdCalidad = " & IdCalidad & ") AND (IdDaño = " & Me.ListCategoria.Columns(0).Text & ")"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "BuscaCalidad")
                    Reg = DataSet.Tables("BuscaCalidad").Rows.Count

                    If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                        Me.ListCategoria.SetSelected(j, True)
                    Else
                        Me.ListCategoria.SetSelected(j, False)
                    End If

                    DataSet.Tables("BuscaCalidad").Reset()


                Next


            Case "Calidad-Fisico"

                Me.Text = "Calidad-Daño"

                '///////////////////////////////BUSCO EL ID DE LA CALIDAD ////////////////////////////////////
                SqlString = "SELECT IdCalidad, CodCalidad, NomCalidad, NomCompleto, MinImperfeccion, MaxImperfeccion FROM Calidad WHERE (NomCalidad = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdCalidad = DataSet.Tables("Consulta").Rows(0)("IdCalidad")
                End If




                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For j = 0 To Contador

                    Me.ListCategoria.Row = j

                    '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                    SqlString = "SELECT IdCalidad, EstadoFisico FROM RelacionCalidadxEstadoFisico WHERE (IdCalidad = " & IdCalidad & ") AND (EstadoFisico = " & Me.ListCategoria.Columns(0).Text & ")"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "BuscaCalidad")
                    Reg = DataSet.Tables("BuscaCalidad").Rows.Count

                    If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                        Me.ListCategoria.SetSelected(j, True)
                    Else
                        Me.ListCategoria.SetSelected(j, False)
                    End If

                    DataSet.Tables("BuscaCalidad").Reset()


                Next


            Case "TipoCompra-Calidad"



                Me.Text = "Tipo Cafe x Tipo Compra"

                '///////////////////////////////BUSCO EL ID DEl TIPO ////////////////////////////////////
                'SqlString = "SELECT IdTipoCompra, Codigo, Nombre FROM TipoCompra WHERE (Nombre = '" & Me.ListCalidad.Text & "')"
                SqlString = "SELECT  IdTipoCafe, Codigo, Nombre FROM TipoCafe WHERE (Nombre = '" & Me.ListCalidad.Text & "')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Consulta")
                If DataSet.Tables("Consulta").Rows.Count <> 0 Then
                    IdTipoCompra = DataSet.Tables("Consulta").Rows(0)("IdTipoCafe")
                End If




                '//////////////////////////////RECORRO EL LIST ///////////////////////////////////////////
                For j = 0 To Contador

                    Me.ListCategoria.Row = j

                    '/////////////////////////////////////CONSULTO SI ESTA OPCION ESTA BLOQUEADA ////////////////////////
                    SqlString = "SELECT IdCalidad, IdTipoCompra FROM RelacionTipoCompraxCalidad WHERE (IdTipoCompra = " & IdTipoCompra & ") AND (IdCalidad  = " & Me.ListCategoria.Columns(0).Text & ")"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "BuscaCalidad")
                    Reg = DataSet.Tables("BuscaCalidad").Rows.Count

                    If DataSet.Tables("BuscaCalidad").Rows.Count <> 0 Then
                        Me.ListCategoria.SetSelected(j, True)
                    Else
                        Me.ListCategoria.SetSelected(j, False)
                    End If

                    DataSet.Tables("BuscaCalidad").Reset()


                Next


        End Select



    End Sub

    Private Sub ListCategoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListCategoria.Click

    End Sub
End Class