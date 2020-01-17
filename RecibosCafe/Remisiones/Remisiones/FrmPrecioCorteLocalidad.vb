Public Class FrmPrecioCorteLocalidad
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Private Sub FrmPrecioCorteLocalidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQlstring As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        SqlString = "SELECT IdLugarAcopio, NomLugarAcopio FROM LugarAcopio WHERE (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidades")
        If DataSet.Tables("Localidades").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        End If

        Me.CboLocalidad.DataSource = DataSet.Tables("Localidades")
        Me.CboLocalidad.Splits(0).DisplayColumns(1).Width = 400


    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Quien = "Localidad"
        My.Forms.FrmConsultas.Text = "Consulta Localidad"
        My.Forms.FrmConsultas.LblEncabezado.Text = "CONSULTA LOCALIDAD"

        My.Forms.FrmConsultas.ShowDialog()
        If My.Forms.FrmConsultas.Descripcion <> "" Then
            Quien = "Consulta"
            Me.CboLocalidad.Text = My.Forms.FrmConsultas.Descripcion
        End If


    End Sub


    Public Sub CreaCortePreciosGral(ByVal IdLocalidad As Double, ByVal FechaCorte As Date)
        Dim MiConexion As New SqlClient.SqlConnection(Conexion)
        Dim Sqlstring As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim FechaAnterior As Date, i As Double, RegCat As Double, idCategoria As Double, RegCalidad As Double, j As Double, idCalidad As Double
        Dim StrSqlUpdate As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, Precio As Double


        FechaAnterior = FechaCorte.AddDays(-1)

        'WHERE    (IdLocalidad = '" & IdLocalidad & "') AND (IdCalidad = " & idCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY FechaActualizacion DESC"

        '///////////////////////////////////RECORRO TODAAS LAS CATEGORIAS ////////////////////////////////////////////////////////////
        Sqlstring = "SELECT  IdRangoImperfeccion, IdCosecha, Minimo, Maximo, Nombre, Deduccion FROM RangoImperfeccion   WHERE(IdCosecha = " & CodigoCosecha & ")"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "Categoria")
        RegCat = DataSet.Tables("Categoria").Rows.Count
        i = 0
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = RegCat

        Do While RegCat > i

            idCategoria = DataSet.Tables("Categoria").Rows(i)("IdRangoImperfeccion")

            '/////////////////////////////////////////RECORRO TODAS LAS CALIDADES ////////////////////////////////////////////////////
            Sqlstring = "SELECT RelacionTipoDocumentoxCalidad.IdCalidad, Calidad.NomCalidad FROM RelacionTipoDocumentoxCalidad INNER JOIN TipoCafe ON RelacionTipoDocumentoxCalidad.IdtipoDocumento = TipoCafe.IdTipoCafe INNER JOIN Calidad ON RelacionTipoDocumentoxCalidad.IdCalidad = Calidad.IdCalidad WHERE( RelacionTipoDocumentoxCalidad.IdtipoDocumento = 1)"
            DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
            DataAdapter.Fill(DataSet, "Calidad")
            RegCalidad = DataSet.Tables("Calidad").Rows.Count

            j = 0
            Me.ProgressBar2.Value = 0
            Me.ProgressBar2.Minimum = 0
            Me.ProgressBar2.Maximum = RegCalidad

            Do While RegCalidad > j

                idCalidad = DataSet.Tables("Calidad").Rows(j)("IdCalidad")

                '//////////////////////////////////////////////////////////////////////////////
                '/////////////VERIFICO SI EXISTE UN CORTE EN LA TABLA DE PRECIOS DE COMPLEMENTOS //////////
                '///////////////////////////////////////////////////////////////////////////////////////
                Sqlstring = "SELECT   IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, FechaActualizacion  FROM  PrecioComplemento   WHERE    (IdLocalidad = '" & IdLocalidad & "') AND (IdCalidad = " & idCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd HH:mm:ss") & "', 102)) ORDER BY FechaActualizacion DESC"
                DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                DataAdapter.Fill(DataSet, "PrecioComplemento")
                If DataSet.Tables("PrecioComplemento").Rows.Count = 0 Then
                    '////////////////////////////////SI NO EXISTE PRECIO COMPLEMENTO AGREGO UN NUEVO PRECIO SEGUN EL ULTIMO PRECIO BASE /////////////////
                    Sqlstring = "SELECT   IdPrecioCafe, IdLocalidad, IdCalidad, IdRangoImperfeccion, Precio, FechaActualizacion  FROM  PrecioCafe   WHERE    (IdLocalidad = '" & IdLocalidad & "')  AND (IdCalidad = " & idCalidad & ") AND (IdRangoImperfeccion = " & idCategoria & ") AND (FechaActualizacion BETWEEN CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaCorte, "yyyy-MM-dd") & " 23:59:59', 102)) ORDER BY FechaActualizacion DESC"
                    DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
                    DataAdapter.Fill(DataSet, "PrecioCafe")
                    If DataSet.Tables("PrecioCafe").Rows.Count <> 0 Then


                        Precio = DataSet.Tables("PrecioCafe").Rows(0)("Precio")
                        Sqlstring = "INSERT INTO [dbo].[PrecioComplemento]  ([IdCosecha],[IdLocalidad],[IdCalidad],[IdRangoImperfeccion],[Precio],[Corte] ,[FechaActualizacion])  VALUES ( '" & CDbl(CodigoCosecha) & "','" & IdLocalidad & "','" & idCalidad & "','" & idCategoria & "','" & Precio & "','1','" & Format(CDate(FechaCorte), "dd/MM/yyyy 05:00:00") & "')"
                        MiConexion.Open()
                        ComandoUpdate = New SqlClient.SqlCommand(Sqlstring, MiConexion)
                        iResultado = ComandoUpdate.ExecuteNonQuery
                        MiConexion.Close()

                        'Sqlstring = "INSERT INTO [dbo].[PrecioCafe] ([IdLocalidad],[IdCalidad],[IdRangoImperfeccion],[Precio],[Corte] ,[FechaActualizacion])  VALUES ('" & IdLocalidad & "','" & idCalidad & "','" & idCategoria & "','" & Precio & "','1','" & Format(CDate(FechaCorte), "dd/MM/yyyy 05:00:00") & "')"
                        'MiConexion.Open()
                        'ComandoUpdate = New SqlClient.SqlCommand(Sqlstring, MiConexion)
                        'iResultado = ComandoUpdate.ExecuteNonQuery
                        'MiConexion.Close()

                    End If
                    DataSet.Tables("PrecioCafe").Reset()

                End If

                DataSet.Tables("PrecioComplemento").Reset()

                Me.ProgressBar2.Value = Me.ProgressBar2.Value + 1
                j = j + 1
            Loop

            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            i = i + 1
        Loop




    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim idLugarAcopio As Double

        idLugarAcopio = Me.CboLocalidad.Columns("IdLugarAcopio").Text

        CreaCortePreciosGral(idLugarAcopio, Now)
    End Sub
End Class