Public Class FrmListRecibo
    Public MiConexion As New SqlClient.SqlConnection(Conexion), idRemisionPergamino As Double, IdCosecha As Double
    
    'Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmListRecibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim item2 As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim sql As String, ComandoUpdate As New SqlClient.SqlCommand
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim Count As Double, i As Double, Count1 As Double, j As Double, SqlString As String, PesoRestante As Double, Parcial As Boolean
        Dim IdRecibo As Double, PesoNeto As Double, oDatarow As DataRow, NombreFinca As String, idRemisionLocal As Double, iResultado As Integer, SeleccionRemi As Integer
        Dim k As Double, Cont As Double, PesoRemisionado As Double, idDetalleRecibo As Double

        Me.CheckTodosRecibos.Checked = False

        If My.Forms.FrmRemision2.AgregarRegistos = True Then
            Me.BtnPegar2.Visible = True
            Me.BtnPegar.Visible = False
        Else
            Me.BtnPegar.Visible = True
            Me.BtnPegar2.Visible = False
        End If

        '///////////////////////////////////GENERO UNA CONSULTA QUE ESTA EN BLANCO ///////////////////////////////////////////////
        'sql = "SELECT  ReciboCafePergamino.Seleccion,  Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion,      DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO FROM            DetalleReciboCafePergamino INNER JOIN                          ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN    Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & My.Forms.FrmRemision2.TxtIdcalidad.Text & "') AND (DetalleReciboCafePergamino.IdDetalleReciboPergamino NOT IN    (SELECT DISTINCT RecibosRemisionPergamino.IdDetalleReciboPergamino   FROM            RecibosRemisionPergamino INNER JOIN  DetalleReciboCafePergamino AS DetalleReciboCafePergamino_1 ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino_1.IdDetalleReciboPergamino INNER JOIN                                                          ReciboCafePergamino AS ReciboCafePergamino_1 ON DetalleReciboCafePergamino_1.IdReciboPergamino = ReciboCafePergamino_1.IdReciboPergamino   WHERE        (ReciboCafePergamino_1.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & My.Forms.FrmRemision2.TxtIdcalidad.Text & "')))  "
        sql = "SELECT  ReciboCafePergamino.Seleccion, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino, Calidad.NomCalidad, TipoSaco.Descripcion AS Tiposaco, Dano.Nombre as Dano, RangoImperfeccion.Nombre AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano , DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara as Tara,DetalleReciboCafePergamino.IdDetalleReciboPergamino, TipoLocalidad.Descripcion AS Categoria, ReciboCafePergamino.AplicarRemision As Aplicar, ReciboCafePergamino.Fecha FROM  DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN  Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha  " & _
              "WHERE (ReciboCafePergamino.Codigo BETWEEN '202-000001' AND '-202-000001') AND (ReciboCafePergamino.IdCalidad = '999999999')   "
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibos")

       
        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then

            'sql = "SELECT ReciboCafePergamino.SeleccionRemision AS Seleccion, ReciboCafePergamino.AplicarRemision AS Aplicar, CASE WHEN Proveedor.Cod_Proveedor IS NULL THEN '00001' ELSE Proveedor.Cod_Proveedor END AS Cod_Proveedor, CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino, Calidad.NomCalidad, TipoSaco.Descripcion AS Tiposaco, Dano.Nombre AS Dano, RangoImperfeccion.Nombre AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.Fecha, ReciboCafePergamino.IdTipoCafe, TipoCafe.Nombre, TipoCafe.Codigo AS Expr1, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.CedulaManual FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe LEFT OUTER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca  " & _
            '      "WHERE (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & My.Forms.FrmRemision2.TxtIdcalidad.Text & "') AND (ReciboCafePergamino.IdTipoCafe = 2) AND (ReciboCafePergamino.IdLocalidadRegistro = '" & My.Forms.FrmRemision2.TxtIdLugarAcopio.Text & "') "

            sql = "SELECT  ReciboCafePergamino.SeleccionRemision AS Seleccion, ReciboCafePergamino.AplicarRemision AS Aplicar, CASE WHEN Proveedor.Cod_Proveedor IS NULL  THEN '00001' ELSE Proveedor.Cod_Proveedor END AS Cod_Proveedor, CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino, Calidad.NomCalidad, TipoSaco.Descripcion AS Tiposaco, Dano.Nombre AS Dano, CASE WHEN RangoImperfeccion.Nombre IS NULL THEN 'D' ELSE RangoImperfeccion.Nombre END AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.Fecha, ReciboCafePergamino.IdTipoCafe, TipoCafe.Nombre, TipoCafe.Codigo AS Expr1, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.CedulaManual FROM  DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN  Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha INNER JOIN  TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe LEFT OUTER JOIN  RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion LEFT OUTER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca " & _
                  "WHERE (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & My.Forms.FrmRemision2.TxtIdcalidad.Text & "') AND (ReciboCafePergamino.IdTipoCafe = 2) AND (ReciboCafePergamino.IdLocalidadRegistro = '" & My.Forms.FrmRemision2.TxtIdLugarAcopio.Text & "') AND (Cosecha.IdCosecha = " & IdCosecha & ") AND (ReciboCafePergamino.IdEstadoDocumento = 294)"

        ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then

            'sql = "SELECT  ReciboCafePergamino.SeleccionRemision AS Seleccion, ReciboCafePergamino.AplicarRemision AS Aplicar, Proveedor.Cod_Proveedor, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino, Calidad.NomCalidad, TipoSaco.Descripcion AS Tiposaco, Dano.Nombre AS Dano, RangoImperfeccion.Nombre AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano,  DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.Fecha,  ReciboCafePergamino.IdTipoCafe, TipoCafe.Nombre, TipoCafe.Codigo AS Expr1 FROM DetalleReciboCafePergamino INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN  RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN  LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN  TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca " & _
            '      "WHERE (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & My.Forms.FrmRemision2.TxtIdcalidad.Text & "') AND (ReciboCafePergamino.IdTipoCafe = 1)"

            sql = "SELECT ReciboCafePergamino.SeleccionRemision AS Seleccion, ReciboCafePergamino.AplicarRemision AS Aplicar, CASE WHEN Proveedor.Cod_Proveedor IS NULL THEN '00001' ELSE Proveedor.Cod_Proveedor END AS Cod_Proveedor, CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino, Calidad.NomCalidad, TipoSaco.Descripcion AS Tiposaco, Dano.Nombre AS Dano, CASE WHEN RangoImperfeccion.Nombre IS NULL THEN 'D' ELSE RangoImperfeccion.Nombre END AS RangoImperfec, TipoLocalidad.Descripcion AS TipoLocalidad, UnidadMedida.Descripcion AS UnidadMedida, Cosecha.IdCosecha, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, TipoSaco.IdTipoSaco, EstadoFisico.IdEdoFisico, Dano.IdDano, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.Fecha, ReciboCafePergamino.IdTipoCafe, TipoCafe.Nombre, TipoCafe.Codigo AS Expr1, Proveedor.IdProductor, ReciboCafePergamino.ProductorManual, ReciboCafePergamino.CedulaManual FROM DetalleReciboCafePergamino INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Calidad ON ReciboCafePergamino.IdCalidad = Calidad.IdCalidad INNER JOIN TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN Cosecha ON ReciboCafePergamino.IdCosecha = Cosecha.IdCosecha INNER JOIN TipoCafe ON ReciboCafePergamino.IdTipoCafe = TipoCafe.IdTipoCafe LEFT OUTER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca  " & _
                  "WHERE (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '" & My.Forms.FrmRemision2.TxtIdcalidad.Text & "') AND (ReciboCafePergamino.IdTipoCafe = 1) AND (ReciboCafePergamino.IdLocalidadRegistro = '" & My.Forms.FrmRemision2.TxtIdLugarAcopio.Text & "') AND (Cosecha.IdCosecha = " & IdCosecha & ") AND (ReciboCafePergamino.IdEstadoDocumento = 294)"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(sql, MiConexion)
        DataAdapter.Fill(DataSet, "DatosRecibos")


        'REMISION PERGAMINO
        Count = DataSet.Tables("DatosRecibos").Rows.Count
        i = 0
        Do While Count > i
            IdRecibo = DataSet.Tables("DatosRecibos").Rows(i)("IdReciboPergamino")
            idDetalleRecibo = DataSet.Tables("DatosRecibos").Rows(i)("IdDetalleReciboPergamino")
            PesoNeto = DataSet.Tables("DatosRecibos").Rows(i)("PESONETO")


            ''//////////////////////////////////////////////////////////////////////////////////////////////
            ''////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
            ''/////////////////////////////////////////////////////////////////////////////////////////////////
            'MiConexion.Close()
            'SqlString = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = 0  WHERE(IdReciboPergamino = " & IdRecibo & ")"
            'MiConexion.Open()
            'ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
            'iResultado = ComandoUpdate.ExecuteNonQuery
            'MiConexion.Close()

            '///////////////////////////////////CON ESTA CONSULTA BUSCO SI EN RECIBOMISION YA ESTA REGISTRADO EL RECIBO /////////////////////
            j = 0
            PesoRemisionado = 0

            SqlString = "SELECT  SUM(RecibosRemisionPergamino.PesoNeto) AS PesoRemisionado, RecibosRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.IdRemisionPergamino FROM DetalleRemisionPergamino INNER JOIN  RecibosRemisionPergamino ON DetalleRemisionPergamino.IdDetalleRemisionPergamino = RecibosRemisionPergamino.IdDetalleRemsionPergamino INNER JOIN DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino GROUP BY RecibosRemisionPergamino.IdDetalleReciboPergamino, DetalleRemisionPergamino.IdRemisionPergamino  HAVING (RecibosRemisionPergamino.IdDetalleReciboPergamino = '" & idDetalleRecibo & "')"
            DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            DataAdapter.Fill(DataSet, "PesoRemisionado")
            If DataSet.Tables("PesoRemisionado").Rows.Count = 0 Then
                PesoRestante = PesoNeto
                Parcial = False
            Else

                j = 0
                PesoRemisionado = 0
                Cont = DataSet.Tables("PesoRemisionado").Rows.Count
                Do While Cont > j
                    idRemisionLocal = DataSet.Tables("PesoRemisionado").Rows(j)("IdRemisionPergamino")
                    If idRemisionLocal = Me.idRemisionPergamino Then
                        PesoRemisionado = PesoRemisionado + DataSet.Tables("PesoRemisionado").Rows(j)("PesoRemisionado")
                        'PesoRestante = Format(PesoNeto - DataSet.Tables("PesoRemisionado").Rows(j)("PesoRemisionado"), "####0.00")
                        'PesoRestante = PesoNeto
                        'If PesoRestante = 0 Then
                        '    Parcial = False
                        'Else
                        '    Parcial = True
                        'End If
                    Else
                        Parcial = True
                        PesoRemisionado = PesoRemisionado + DataSet.Tables("PesoRemisionado").Rows(j)("PesoRemisionado")
                        'PesoRestante = Format(PesoNeto - DataSet.Tables("PesoRemisionado").Rows(j)("PesoRemisionado"), "####0.00")
                        'DataSet.Tables("PesoRemisionado").Reset()
                    End If

                    j = j + 1
                Loop

                DataSet.Tables("PesoRemisionado").Reset()

            End If


            If PesoRemisionado <= 0 Then
                PesoRemisionado = 0
                PesoRestante = Format(PesoNeto, "####0.00")
                Parcial = False
            Else
                PesoRestante = Format(PesoNeto - PesoRemisionado, "####0.00")
                If PesoRestante = 0 Then
                    Parcial = False
                Else
                    Parcial = True
                End If
            End If

            DataSet.Tables("PesoRemisionado").Reset()
            '______________________________________________________________________________________________________
            'LLENO EL GRIND 
            '______________________________________________________________________________________________________

            If PesoRestante > 0 Then
                oDatarow = DataSet.Tables("ListaRecibos").NewRow
                oDatarow("Seleccion") = DataSet.Tables("DatosRecibos").Rows(i)("Seleccion")
                oDatarow("Cod_Proveedor") = DataSet.Tables("DatosRecibos").Rows(i)("Cod_Proveedor")
                oDatarow("Proveedor") = DataSet.Tables("DatosRecibos").Rows(i)("Proveedor")
                oDatarow("NomFinca") = DataSet.Tables("DatosRecibos").Rows(i)("NomFinca")
                If Parcial = True Then
                    oDatarow("Codigo") = "Ø " & DataSet.Tables("DatosRecibos").Rows(i)("Codigo")
                    oDatarow("PesoBruto") = PesoRestante
                    oDatarow("Tara") = 0
                    oDatarow("PESONETO") = PesoRestante
                    Parcial = False
                Else
                    Parcial = False
                    oDatarow("Codigo") = DataSet.Tables("DatosRecibos").Rows(i)("Codigo")
                    oDatarow("PesoBruto") = DataSet.Tables("DatosRecibos").Rows(i)("PesoBruto") 'Modificado 21-11-2019 no muestra el peso restante 
                    oDatarow("Tara") = DataSet.Tables("DatosRecibos").Rows(i)("Tara")   'Modificado 21-11-2019 no muestra el peso restante
                    oDatarow("PESONETO") = DataSet.Tables("DatosRecibos").Rows(i)("PESONETO")  'Modificado 21-11-2019 no muestra el peso restante
                End If
                oDatarow("Descripcion") = DataSet.Tables("DatosRecibos").Rows(i)("Descripcion")
                oDatarow("PesoPendiente") = PesoRestante
                oDatarow("IdReciboPergamino") = DataSet.Tables("DatosRecibos").Rows(i)("IdReciboPergamino")
                oDatarow("NomCalidad") = DataSet.Tables("DatosRecibos").Rows(i)("NomCalidad")
                oDatarow("Tiposaco") = DataSet.Tables("DatosRecibos").Rows(i)("Tiposaco")
                oDatarow("Dano") = DataSet.Tables("DatosRecibos").Rows(i)("Dano")
                oDatarow("RangoImperfec") = DataSet.Tables("DatosRecibos").Rows(i)("RangoImperfec")
                oDatarow("TipoLocalidad") = DataSet.Tables("DatosRecibos").Rows(i)("TipoLocalidad")
                oDatarow("UnidadMedida") = DataSet.Tables("DatosRecibos").Rows(i)("UnidadMedida")
                oDatarow("IdCosecha") = DataSet.Tables("DatosRecibos").Rows(i)("IdCosecha")
                oDatarow("CantidadSacos") = DataSet.Tables("DatosRecibos").Rows(i)("CantidadSacos")
                oDatarow("Humedad") = DataSet.Tables("DatosRecibos").Rows(i)("Humedad")
                oDatarow("IdTipoSaco") = DataSet.Tables("DatosRecibos").Rows(i)("IdTipoSaco")
                oDatarow("IdEdoFisico") = DataSet.Tables("DatosRecibos").Rows(i)("IdEdoFisico")
                oDatarow("IdDano") = DataSet.Tables("DatosRecibos").Rows(i)("IdDano")
                oDatarow("IdDetalleReciboPergamino") = DataSet.Tables("DatosRecibos").Rows(i)("IdDetalleReciboPergamino")   '/////Modificado 17-01-2020  quieren que se grabe iddetalle en reciboremision y idrecibo en detalleremision
                'oDatarow("IdDetalleReciboPergamino") = DataSet.Tables("DatosRecibos").Rows(i)("IdReciboPergamino")
                oDatarow("Categoria") = DataSet.Tables("DatosRecibos").Rows(i)("RangoImperfec")
                oDatarow("Aplicar") = DataSet.Tables("DatosRecibos").Rows(i)("Aplicar")
                oDatarow("Fecha") = DataSet.Tables("DatosRecibos").Rows(i)("Fecha")
                DataSet.Tables("ListaRecibos").Rows.Add(oDatarow)
            End If

            i = i + 1
        Loop
        'j = j + 1
        'Loop

        Me.BinRecibosLista.DataSource = DataSet.Tables("ListaRecibos")
        Me.GribListRecibos.DataSource = Me.BinRecibosLista.DataSource

        Me.GribListRecibos.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
        Me.GribListRecibos.Columns(0).ValueItems.CycleOnClick = True
        With Me.GribListRecibos.Columns(0).ValueItems.Values

            item.Value = "False"
            item.DisplayValue = Me.ImageList.Images(1)
            .Add(item)

            item = New C1.Win.C1TrueDBGrid.ValueItem()
            item.Value = "True"
            item.DisplayValue = Me.ImageList.Images(0)
            .Add(item)

            Me.GribListRecibos.Columns(0).ValueItems.Translate = True
        End With

        Me.GribListRecibos.Splits.Item(0).DisplayColumns(0).Width = 30
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(1).Width = 220
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(2).Width = 150
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(4).Width = 95
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(5).Width = 100


        Me.GribListRecibos.Splits.Item(0).DisplayColumns(1).Locked = True
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(2).Locked = True
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(3).Locked = True
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(4).Locked = True
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(5).Locked = True

        Me.GribListRecibos.Splits.Item(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(3).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(4).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(5).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


        Me.GribListRecibos.Columns(0).Caption = " "
        Me.GribListRecibos.Columns("Proveedor").Caption = "Nombre Proveedor"
        Me.GribListRecibos.Columns("NomFinca").Caption = "Nombre Finca"
        Me.GribListRecibos.Columns("Codigo").Caption = "Cod Recibo"
        Me.GribListRecibos.Columns("Descripcion").Caption = "Edo Fisico"
        Me.GribListRecibos.Columns("PESONETO").Caption = "P Neto Total"
        Me.GribListRecibos.Columns("PesoPendiente").Caption = "P Neto Dispo"

        Me.GribListRecibos.Columns(5).NumberFormat = "##,##0.00"
        Me.GribListRecibos.Columns(6).NumberFormat = "##,##0.00"
        Me.GribListRecibos.Splits.Item(0).DisplayColumns("Codigo").Width = 140

        Me.GribListRecibos.Splits.Item(0).DisplayColumns("Fecha").Visible = False
        'Me.GribListRecibos.Splits.Item(0).DisplayColumns("IdReciboPergamino").Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns("Cod_Proveedor").Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns("IdDano").Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns("RangoImperfec").Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(7).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(8).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(9).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(10).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(11).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(12).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(13).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(14).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(15).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(16).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(17).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(18).Visible = False
        Me.GribListRecibos.Splits.Item(0).DisplayColumns(19).Visible = False

    End Sub
    Private Sub BtnSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubir.Click
        Dim Posicion As Integer = Me.GribListRecibos.Row, eleccion As Boolean, AntPosicion As Integer
        'VARIABLES DE DATOS DE COlUMNAS
        Dim Productor As String, Finca As String, Recibo As String, EstadoFisco As String, PesoNetoTotal As Double, PesoDisponible As Double, Seleccion As Boolean
        Dim AntProductor As String, AntFinca As String, AntRecibo As String, AntEstadoFisco As String, AntPesoNetoTotal As Double, AntPesoDisponible As Double, AntSeleccion As Boolean
        Dim IdReciboPergamino As String, NomCalidad As String, AntDano As String, Tiposaco As String, Tara As String, Dano As String, RangoImperfec As String, TipoLocalidad As String, UnidadMedida As String, Categoria As String
        Dim IdCosecha As String, CantidadSacos As String, IdTipoSaco As String, IdEdoFisico As String, IdDano As String, PesoBruto As String, IdDetalleReciboPergamino As String, Cod_Proveedor As String, Humedad As String, Aplicar As Boolean

        Dim AntIdReciboPergamino As String, AntNomCalidad As String, AntTiposaco As String, AntRangoImperfec As String, AntTipoLocalidad As String, AntUnidadMedida As String, AntIdCosecha As String, AntCategoria As String
        Dim AntCantidadSacos As String, AntIdTipoSaco As String, AntIdEdoFisico As String, AntIdDano As String, AntPesoBruto As String, AntTara As String, AntIdDetalleReciboPergamino As String, AntCod_Proveedor As String, AntHumedad As String, AntAplicar As Boolean

        eleccion = Me.GribListRecibos.Item(Posicion)("Seleccion")

        If eleccion = True Then
            If Posicion = 0 Then
                Me.GribListRecibos.Row = 0
                MsgBox("ESTE ES EL LIMITE", MsgBoxStyle.Critical, "Remision")
            Else
                AntPosicion = Posicion - 1

                Seleccion = Me.GribListRecibos.Item(Posicion)(0)
                Cod_Proveedor = Me.GribListRecibos.Columns(1).Text
                Productor = Me.GribListRecibos.Columns(2).Text
                Finca = Me.GribListRecibos.Columns(3).Text
                Recibo = Me.GribListRecibos.Columns(4).Text
                EstadoFisco = Me.GribListRecibos.Columns(5).Text
                PesoNetoTotal = Me.GribListRecibos.Columns(6).Text
                PesoDisponible = Me.GribListRecibos.Columns(7).Text
                IdReciboPergamino = Me.GribListRecibos.Columns(8).Text
                NomCalidad = Me.GribListRecibos.Columns(9).Text
                Tiposaco = Me.GribListRecibos.Columns(10).Text
                Dano = Me.GribListRecibos.Columns(11).Text
                RangoImperfec = Me.GribListRecibos.Columns(12).Text
                TipoLocalidad = Me.GribListRecibos.Columns(13).Text
                UnidadMedida = Me.GribListRecibos.Columns(14).Text
                IdCosecha = Me.GribListRecibos.Columns(15).Text
                CantidadSacos = Me.GribListRecibos.Columns(16).Text
                Humedad = Me.GribListRecibos.Columns(17).Text
                IdTipoSaco = Me.GribListRecibos.Columns(18).Text
                IdEdoFisico = Me.GribListRecibos.Columns(19).Text
                IdDano = Me.GribListRecibos.Columns(20).Text
                PesoBruto = Me.GribListRecibos.Columns(21).Text
                Tara = Me.GribListRecibos.Columns(22).Text
                IdDetalleReciboPergamino = Me.GribListRecibos.Columns(23).Text
                Categoria = Me.GribListRecibos.Columns(24).Text
                Aplicar = Me.GribListRecibos.Item(Posicion)(25)



                AntSeleccion = Me.GribListRecibos.Item(AntPosicion)(0)
                AntCod_Proveedor = Me.GribListRecibos.Item(AntPosicion)(1)
                AntProductor = Me.GribListRecibos.Item(AntPosicion)(2)
                If Not IsDBNull(Me.GribListRecibos.Item(AntPosicion)(3)) Then
                    AntFinca = Me.GribListRecibos.Item(AntPosicion)(3)
                End If
                AntRecibo = Me.GribListRecibos.Item(AntPosicion)(4)
                AntEstadoFisco = Me.GribListRecibos.Item(AntPosicion)(5)
                AntPesoNetoTotal = Me.GribListRecibos.Item(AntPosicion)(6)
                AntPesoDisponible = Me.GribListRecibos.Item(AntPosicion)(7)
                AntIdReciboPergamino = Me.GribListRecibos.Item(AntPosicion)(8)
                AntNomCalidad = Me.GribListRecibos.Item(AntPosicion)(9)
                AntTiposaco = Me.GribListRecibos.Item(AntPosicion)(10)
                AntDano = Me.GribListRecibos.Item(AntPosicion)(11)
                AntRangoImperfec = Me.GribListRecibos.Item(AntPosicion)(12)
                AntTipoLocalidad = Me.GribListRecibos.Item(AntPosicion)(13)
                AntUnidadMedida = Me.GribListRecibos.Item(AntPosicion)(14)
                AntIdCosecha = Me.GribListRecibos.Item(AntPosicion)(15)
                AntCantidadSacos = Me.GribListRecibos.Item(AntPosicion)(16)
                AntHumedad = Me.GribListRecibos.Item(AntPosicion)(17)
                AntIdTipoSaco = Me.GribListRecibos.Item(AntPosicion)(18)
                AntIdEdoFisico = Me.GribListRecibos.Item(AntPosicion)(19)
                AntIdDano = Me.GribListRecibos.Item(AntPosicion)(20)
                AntPesoBruto = Me.GribListRecibos.Item(AntPosicion)(21)
                AntTara = Me.GribListRecibos.Item(AntPosicion)(22)
                AntIdDetalleReciboPergamino = Me.GribListRecibos.Item(AntPosicion)(23)
                AntCategoria = Me.GribListRecibos.Item(AntPosicion)(24)
                AntAplicar = Me.GribListRecibos.Item(AntPosicion)(25)


                Me.GribListRecibos.Row = AntPosicion
                Me.GribListRecibos.Columns(0).Text = Seleccion
                Me.GribListRecibos.Columns(1).Text = Cod_Proveedor
                Me.GribListRecibos.Columns(2).Text = Productor
                Me.GribListRecibos.Columns(3).Text = Finca
                Me.GribListRecibos.Columns(4).Text = Recibo
                Me.GribListRecibos.Columns(5).Text = EstadoFisco
                Me.GribListRecibos.Columns(6).Text = PesoNetoTotal
                Me.GribListRecibos.Columns(7).Text = PesoDisponible
                Me.GribListRecibos.Columns(8).Text = IdReciboPergamino
                Me.GribListRecibos.Columns(9).Text = NomCalidad
                Me.GribListRecibos.Columns(10).Text = Tiposaco
                Me.GribListRecibos.Columns(11).Text = Dano
                Me.GribListRecibos.Columns(12).Text = RangoImperfec
                Me.GribListRecibos.Columns(13).Text = TipoLocalidad
                Me.GribListRecibos.Columns(14).Text = UnidadMedida
                Me.GribListRecibos.Columns(15).Text = IdCosecha
                Me.GribListRecibos.Columns(16).Text = CantidadSacos
                Me.GribListRecibos.Columns(17).Text = Humedad
                Me.GribListRecibos.Columns(18).Text = IdTipoSaco
                Me.GribListRecibos.Columns(19).Text = IdEdoFisico
                Me.GribListRecibos.Columns(20).Text = IdDano
                Me.GribListRecibos.Columns(21).Text = PesoBruto
                Me.GribListRecibos.Columns(22).Text = Tara
                Me.GribListRecibos.Columns(23).Text = IdDetalleReciboPergamino
                Me.GribListRecibos.Columns(24).Text = Categoria
                Me.GribListRecibos.Columns(25).Text = Aplicar


                Me.GribListRecibos.Item(AntPosicion + 1)(0) = AntSeleccion
                Me.GribListRecibos.Item(AntPosicion + 1)(1) = AntCod_Proveedor
                Me.GribListRecibos.Item(AntPosicion + 1)(2) = AntProductor
                Me.GribListRecibos.Item(AntPosicion + 1)(3) = AntFinca
                Me.GribListRecibos.Item(AntPosicion + 1)(4) = AntRecibo
                Me.GribListRecibos.Item(AntPosicion + 1)(5) = AntEstadoFisco
                Me.GribListRecibos.Item(AntPosicion + 1)(6) = AntPesoNetoTotal
                Me.GribListRecibos.Item(AntPosicion + 1)(7) = AntPesoDisponible
                Me.GribListRecibos.Item(AntPosicion + 1)(8) = AntIdReciboPergamino
                Me.GribListRecibos.Item(AntPosicion + 1)(9) = AntNomCalidad
                Me.GribListRecibos.Item(AntPosicion + 1)(10) = AntTiposaco
                Me.GribListRecibos.Item(AntPosicion + 1)(11) = AntDano
                Me.GribListRecibos.Item(AntPosicion + 1)(12) = AntRangoImperfec
                Me.GribListRecibos.Item(AntPosicion + 1)(13) = AntTipoLocalidad
                Me.GribListRecibos.Item(AntPosicion + 1)(14) = AntUnidadMedida
                Me.GribListRecibos.Item(AntPosicion + 1)(15) = AntIdCosecha
                Me.GribListRecibos.Item(AntPosicion + 1)(16) = AntCantidadSacos
                Me.GribListRecibos.Item(AntPosicion + 1)(17) = AntHumedad
                Me.GribListRecibos.Item(AntPosicion + 1)(18) = AntIdTipoSaco
                Me.GribListRecibos.Item(AntPosicion + 1)(19) = AntIdEdoFisico
                Me.GribListRecibos.Item(AntPosicion + 1)(20) = AntIdDano
                Me.GribListRecibos.Item(AntPosicion + 1)(21) = AntPesoBruto
                Me.GribListRecibos.Item(AntPosicion + 1)(22) = AntTara
                Me.GribListRecibos.Item(AntPosicion + 1)(23) = AntIdDetalleReciboPergamino
                Me.GribListRecibos.Item(AntPosicion + 1)(24) = AntCategoria
                Me.GribListRecibos.Item(AntPosicion + 1)(25) = AntAplicar

                End If
        Else
                Exit Sub
        End If
    End Sub

    Private Sub BtnBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBajar.Click
        Dim Posicion As Integer = Me.GribListRecibos.Row, Maximo = Me.GribListRecibos.RowCount - 1, eleccion As Boolean, SigPosicion As Integer
        'VARIABLES DE DATOS DE COlUMNAS
        Dim Productor As String, Finca As String, Recibo As String, EstadoFisco As String, PesoNetoTotal As Double, PesoDisponible As Double, Seleccion As Boolean
        Dim SigProductor As String, SigFinca As String, SigRecibo As String, SigEstadoFisco As String, SigPesoNetoTotal As Double, SigPesoDisponible As Double, SigSeleccion As Boolean
        Dim IdReciboPergamino As String, NomCalidad As String, AntDano As String, Tiposaco As String, Tara As String, Dano As String, RangoImperfec As String, TipoLocalidad As String, UnidadMedida As String, Categoria As String
        Dim IdCosecha As String, CantidadSacos As String, IdTipoSaco As String, IdEdoFisico As String, IdDano As String, PesoBruto As String, IdDetalleReciboPergamino As String, Cod_Proveedor As String, Humedad As String, Aplicar As Boolean
        Dim SigIdReciboPergamino As String, SigNomCalidad As String, SigTiposaco As String, SigDano As String, SigRangoImperfec As String, SigTipoLocalidad As String, SigUnidadMedida As String, SigCod_Proveedor As String, SigCategoria As String
        Dim SigIdCosecha As String, SigCantidadSacos As String, SigIdTipoSaco As String, SigIdEdoFisico As String, SigIdDano As String, SigPesoBruto As String, SigTara As String, SigIdDetalleReciboPergamino As String, SigHumedad As String, SigAplicar As String

        eleccion = Me.GribListRecibos.Item(Posicion)("Seleccion")
        If eleccion = True Then
            If Posicion = Maximo Then
                Me.GribListRecibos.Row = Maximo
                MsgBox("ESTE ES EL LIMITE", MsgBoxStyle.Critical, "Remision")
            Else
                SigPosicion = Posicion + 1

                Seleccion = Me.GribListRecibos.Item(Posicion)(0)
                Cod_Proveedor = Me.GribListRecibos.Columns(1).Text
                Productor = Me.GribListRecibos.Columns(2).Text
                Finca = Me.GribListRecibos.Columns(3).Text
                Recibo = Me.GribListRecibos.Columns(4).Text
                EstadoFisco = Me.GribListRecibos.Columns(5).Text
                PesoNetoTotal = Me.GribListRecibos.Columns(6).Text
                PesoDisponible = Me.GribListRecibos.Columns(7).Text
                IdReciboPergamino = Me.GribListRecibos.Columns(8).Text
                NomCalidad = Me.GribListRecibos.Columns(9).Text
                Tiposaco = Me.GribListRecibos.Columns(10).Text
                Dano = Me.GribListRecibos.Columns(11).Text
                RangoImperfec = Me.GribListRecibos.Columns(12).Text
                TipoLocalidad = Me.GribListRecibos.Columns(13).Text
                UnidadMedida = Me.GribListRecibos.Columns(14).Text
                IdCosecha = Me.GribListRecibos.Columns(15).Text
                CantidadSacos = Me.GribListRecibos.Columns(16).Text
                Humedad = Me.GribListRecibos.Columns(17).Text
                IdTipoSaco = Me.GribListRecibos.Columns(18).Text
                IdEdoFisico = Me.GribListRecibos.Columns(19).Text
                IdDano = Me.GribListRecibos.Columns(20).Text
                PesoBruto = Me.GribListRecibos.Columns(21).Text
                Tara = Me.GribListRecibos.Columns(22).Text
                IdDetalleReciboPergamino = Me.GribListRecibos.Columns(23).Text
                Categoria = Me.GribListRecibos.Columns(24).Text
                Aplicar = Me.GribListRecibos.Item(Posicion)(25)



                SigSeleccion = Me.GribListRecibos.Item(SigPosicion)(0)
                SigCod_Proveedor = Me.GribListRecibos.Item(SigPosicion)(1)
                SigProductor = Me.GribListRecibos.Item(SigPosicion)(2)
                If Not IsDBNull(Me.GribListRecibos.Item(SigPosicion)(3)) Then
                    SigFinca = Me.GribListRecibos.Item(SigPosicion)(3)
                End If
                SigRecibo = Me.GribListRecibos.Item(SigPosicion)(4)
                SigEstadoFisco = Me.GribListRecibos.Item(SigPosicion)(5)
                SigPesoNetoTotal = Me.GribListRecibos.Item(SigPosicion)(6)
                SigPesoDisponible = Me.GribListRecibos.Item(SigPosicion)(7)
                SigIdReciboPergamino = Me.GribListRecibos.Item(SigPosicion)(8)
                SigNomCalidad = Me.GribListRecibos.Item(SigPosicion)(9)
                SigTiposaco = Me.GribListRecibos.Item(SigPosicion)(10)
                SigDano = Me.GribListRecibos.Item(SigPosicion)(11)
                SigRangoImperfec = Me.GribListRecibos.Item(SigPosicion)(12)
                SigTipoLocalidad = Me.GribListRecibos.Item(SigPosicion)(13)
                SigUnidadMedida = Me.GribListRecibos.Item(SigPosicion)(14)
                SigIdCosecha = Me.GribListRecibos.Item(SigPosicion)(15)
                SigCantidadSacos = Me.GribListRecibos.Item(SigPosicion)(16)
                SigHumedad = Me.GribListRecibos.Item(SigPosicion)(17)
                SigIdTipoSaco = Me.GribListRecibos.Item(SigPosicion)(18)
                SigIdEdoFisico = Me.GribListRecibos.Item(SigPosicion)(19)
                SigIdDano = Me.GribListRecibos.Item(SigPosicion)(20)
                SigPesoBruto = Me.GribListRecibos.Item(SigPosicion)(21)
                SigTara = Me.GribListRecibos.Item(SigPosicion)(22)
                SigIdDetalleReciboPergamino = Me.GribListRecibos.Item(SigPosicion)(23)
                SigCategoria = Me.GribListRecibos.Item(SigPosicion)(24)
                SigAplicar = Me.GribListRecibos.Item(SigPosicion)(25)


                Me.GribListRecibos.Row = SigPosicion


                Me.GribListRecibos.Item(SigPosicion)(0) = Seleccion
                Me.GribListRecibos.Columns(1).Text = Cod_Proveedor
                Me.GribListRecibos.Columns(2).Text = Productor
                Me.GribListRecibos.Columns(3).Text = Finca
                Me.GribListRecibos.Columns(4).Text = Recibo
                Me.GribListRecibos.Columns(5).Text = EstadoFisco
                Me.GribListRecibos.Columns(6).Text = PesoNetoTotal
                Me.GribListRecibos.Columns(7).Text = PesoDisponible
                Me.GribListRecibos.Columns(8).Text = IdReciboPergamino
                Me.GribListRecibos.Columns(9).Text = NomCalidad
                Me.GribListRecibos.Columns(10).Text = Tiposaco
                Me.GribListRecibos.Columns(11).Text = Dano
                Me.GribListRecibos.Columns(12).Text = RangoImperfec
                Me.GribListRecibos.Columns(13).Text = TipoLocalidad
                Me.GribListRecibos.Columns(14).Text = UnidadMedida
                Me.GribListRecibos.Columns(15).Text = IdCosecha
                Me.GribListRecibos.Columns(16).Text = CantidadSacos
                Me.GribListRecibos.Columns(17).Text = Humedad
                Me.GribListRecibos.Columns(18).Text = IdTipoSaco
                Me.GribListRecibos.Columns(19).Text = IdEdoFisico
                Me.GribListRecibos.Columns(20).Text = IdDano
                Me.GribListRecibos.Columns(21).Text = PesoBruto
                Me.GribListRecibos.Columns(22).Text = Tara
                Me.GribListRecibos.Columns(23).Text = IdDetalleReciboPergamino
                Me.GribListRecibos.Columns(24).Text = Categoria
                Me.GribListRecibos.Item(SigPosicion)(25) = Aplicar




                Me.GribListRecibos.Item(SigPosicion - 1)(0) = SigSeleccion
                Me.GribListRecibos.Item(SigPosicion - 1)(1) = SigCod_Proveedor
                Me.GribListRecibos.Item(SigPosicion - 1)(2) = SigProductor
                Me.GribListRecibos.Item(SigPosicion - 1)(3) = SigFinca
                Me.GribListRecibos.Item(SigPosicion - 1)(4) = SigRecibo
                Me.GribListRecibos.Item(SigPosicion - 1)(5) = SigEstadoFisco
                Me.GribListRecibos.Item(SigPosicion - 1)(6) = SigPesoNetoTotal
                Me.GribListRecibos.Item(SigPosicion - 1)(7) = SigPesoDisponible
                Me.GribListRecibos.Item(SigPosicion - 1)(8) = SigIdReciboPergamino
                Me.GribListRecibos.Item(SigPosicion - 1)(9) = SigNomCalidad
                Me.GribListRecibos.Item(SigPosicion - 1)(10) = SigTiposaco
                Me.GribListRecibos.Item(SigPosicion - 1)(11) = SigDano
                Me.GribListRecibos.Item(SigPosicion - 1)(12) = SigRangoImperfec
                Me.GribListRecibos.Item(SigPosicion - 1)(13) = SigTipoLocalidad
                Me.GribListRecibos.Item(SigPosicion - 1)(14) = SigUnidadMedida
                Me.GribListRecibos.Item(SigPosicion - 1)(15) = SigIdCosecha
                Me.GribListRecibos.Item(SigPosicion - 1)(16) = SigCantidadSacos
                Me.GribListRecibos.Item(SigPosicion - 1)(17) = SigHumedad
                Me.GribListRecibos.Item(SigPosicion - 1)(18) = SigIdTipoSaco
                Me.GribListRecibos.Item(SigPosicion - 1)(19) = SigIdEdoFisico
                Me.GribListRecibos.Item(SigPosicion - 1)(20) = SigIdDano
                Me.GribListRecibos.Item(SigPosicion - 1)(21) = SigPesoBruto
                Me.GribListRecibos.Item(SigPosicion - 1)(22) = SigTara
                Me.GribListRecibos.Item(SigPosicion - 1)(23) = SigIdDetalleReciboPergamino
                Me.GribListRecibos.Item(SigPosicion - 1)(24) = SigCategoria
                Me.GribListRecibos.Item(SigPosicion - 1)(25) = SigAplicar

                End If
        Else
                Exit Sub
        End If
        '
        'If Posicion = Maximo Then
        '    Me.GribListRecibos.Row = Maximo
        '    MsgBox("ESTE ES EL LIMITE", MsgBoxStyle.Critical, "Remision")
        'Else
        '    Me.GribListRecibos.Row = Posicion + 1
        'End If
    End Sub
    Private Sub BtnPegar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPegar.Click
        Dim Posicion As Integer = Me.GribListRecibos.Row
        Dim Sql As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = "", SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim oDatarow As DataRow, Count As Double, i As Integer, ODataRowDetalle As DataRow, Cont As Double
        Dim Eleccion As Boolean, IdlocalidadRec As Double, PesoNeto As Double, Precio1 As Double, Precio As Double
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, EsPorcentaje As Boolean, IdLocalidad As Integer, DeduccionDano As Double, DD As Double
        Dim DeducEstado As Double, Descripcion As String, PesoRestante As Double, EstadoLiquidado As Boolean, Parcial As Boolean
        Dim Saldo As Double, Monto As Double, TotalSaldo As Double, TotalMonto As Double, IdRecibo As Integer, Buscar_Fila() As DataRow, Criterios As String
        Dim Dano As String, Calidad As String, EdoFisico As String, TipoSaco As String, RangoImperf As String, TipoLugarAco As String, UniMedida As String, Cosecha As String, Humedad As Double
        Dim Cont2 As Double, j As Integer, estado As Boolean, nombre As String, PesadaBruto As Double, PesadaTara As Double, PesadaNeto As Double, Pesadaqq As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SeleccionRemi As Integer
        Dim Aplicar As Boolean

        '------------------------------------------------------------------------------------------------------------------------------
        'Mando una consulta que no retorna nada
        '------------------------------------------------------------------------------------------------------------------------------
        Sql = " SELECT  Proveedor.Cod_Proveedor,Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS CantidadSacos, DetalleReciboCafePergamino.Tara AS Humedad, DetalleReciboCafePergamino.Tara AS IdSaco, DetalleReciboCafePergamino.Tara AS IdEdoFisico, DetalleReciboCafePergamino.Tara AS IdDano ,DetalleReciboCafePergamino.Tara AS PesoBruto , DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.AplicarRemision As Aplicar, ReciboCafePergamino.Fecha, ReciboCafePergamino.IdReciboPergamino FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE   (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibos2")

        Sql = "SELECT ReciboCafePergamino.SeleccionRemision as Seleccion, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino  FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & My.Forms.FrmRemision2.TxtIdcalidad.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DatosRecibos")

        Sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, ReciboCafePergamino.Codigo As Merma FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosRem")

        'GRID DETALLES RECIBOS REMISIONES
        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then
            Sql = "SELECT        Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Productor, Finca.NomFinca, ReciboCafePergamino.Codigo, Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto AS PesoNeto, DetalleReciboCafePergamino.Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, TipoLocalidad.Descripcion AS IdDetalleReciboPergamino, DetalleReciboCafePergamino.PesoBruto AS PesoNeto2, DetalleReciboCafePergamino.CantidadSacos as CantidadSacos2, TipoLocalidad.Descripcion AS PesosRecibos, DetalleReciboCafePergamino.PesoBruto As PesoBruto2, DetalleReciboCafePergamino.Tara As Tara2    FROM  ReciboCafePergamino INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN                          DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN                          RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN                          LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN                         UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN                           TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca WHERE        (ReciboCafePergamino.Codigo BETWEEN '-100000' AND '-1221') AND (ReciboCafePergamino.IdCalidad = '-1')"
        ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then
            Sql = "SELECT        Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara,DetalleReciboCafePergamino.PesoBruto AS PesoNeto, DetalleReciboCafePergamino.Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico,ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, TipoLocalidad.Descripcion AS IdDetalleReciboPergamino, ReciboCafePergamino.Codigo, DetalleReciboCafePergamino.PesoBruto AS PesoNeto2, DetalleReciboCafePergamino.CantidadSacos as CantidadSacos2, TipoLocalidad.Descripcion AS PesosRecibos, DetalleReciboCafePergamino.PesoBruto As PesoBruto2, DetalleReciboCafePergamino.Tara As Tara2  FROM   ReciboCafePergamino INNER JOIN    Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN   EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN   TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN                          LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN   UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN  TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad  WHERE  (ReciboCafePergamino.Codigo BETWEEN '-100000' AND '-1221')AND (ReciboCafePergamino.IdCalidad = '-1')"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosAgrupados")

        Count = Me.GribListRecibos.RowCount
        i = 0
        FrmRemision2.ListPorveedores.ClearSelected()
        Do While Count > i
            Eleccion = Me.GribListRecibos.Item(i)("Seleccion")

            If Eleccion = True Then
                SeleccionRemi = 1
            Else
                SeleccionRemi = 0
            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            SqlString = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = " & SeleccionRemi & "  WHERE(IdReciboPergamino = " & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()

            If Eleccion = True Then

                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////BUSCO LOS PROVEEDORES PARA CHECK/////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Cont2 = FrmRemision2.ListPorveedores.ListCount - 1
                For j = 0 To Cont2
                    estado = FrmRemision2.ListPorveedores.SelectedIndices.Contains(j)
                    FrmRemision2.ListPorveedores.Row = j
                    nombre = FrmRemision2.ListPorveedores.Columns(0).Text
                    If nombre = Me.GribListRecibos.Item(i)("Proveedor") Then
                        'estado = FrmRemision2.ListPorveedores.SelectedIndices.Contains(j)
                        If estado = False Then
                            FrmRemision2.ListPorveedores.SetSelected(j, True)
                            Exit For
                        End If
                    Else
                        If estado = False Then
                            FrmRemision2.ListPorveedores.SetSelected(j, False)
                        End If
                    End If
                    j = j
                Next


                'If Eleccion = True Then
                '    SeleccionRemi = 1
                'Else
                '    SeleccionRemi = 0
                'End If
                ''//////////////////////////////////////////////////////////////////////////////////////////////
                ''////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
                ''/////////////////////////////////////////////////////////////////////////////////////////////////
                'MiConexion.Close()
                'SqlString = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = " & SeleccionRemi & "  WHERE(IdReciboPergamino = " & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & ")"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()


                oDatarow = DataSet.Tables("ListaRecibos2").NewRow
                oDatarow("Proveedor") = Me.GribListRecibos.Item(i)("Proveedor")
                oDatarow("NomFinca") = Me.GribListRecibos.Item(i)("NomFinca")
                oDatarow("Codigo") = Me.GribListRecibos.Item(i)("Codigo")
                oDatarow("Descripcion") = Me.GribListRecibos.Item(i)("Descripcion")
                oDatarow("PESONETO") = Me.GribListRecibos.Item(i)("PESONETO")
                oDatarow("CantidadSacos") = Me.GribListRecibos.Item(i)("CantidadSacos")
                oDatarow("Humedad") = Me.GribListRecibos.Item(i)("Humedad")
                oDatarow("IdSaco") = Me.GribListRecibos.Item(i)("IdTipoSaco")
                oDatarow("IdEdoFisico") = Me.GribListRecibos.Item(i)("IdEdoFisico")
                oDatarow("IdDano") = Me.GribListRecibos.Item(i)("IdDano")
                oDatarow("Dano") = Me.GribListRecibos.Item(i)("Dano")
                oDatarow("PesoBruto") = Me.GribListRecibos.Item(i)("PesoBruto")
                oDatarow("IdDetalleReciboPergamino") = Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino")
                oDatarow("Categoria") = Me.GribListRecibos.Item(i)("RangoImperfec")
                oDatarow("Fecha") = Me.GribListRecibos.Item(i)("Fecha")
                oDatarow("IdReciboPergamino") = Me.GribListRecibos.Item(i)("IdReciboPergamino")

                DataSet.Tables("ListaRecibos2").Rows.Add(oDatarow)
                '----------------------------------------------------------------------------------------------------------------------------------------------------
                Dano = Me.GribListRecibos.Item(i)("Dano")
                Calidad = Me.GribListRecibos.Item(i)("NomCalidad")
                EdoFisico = Me.GribListRecibos.Item(i)("Descripcion")
                TipoSaco = Me.GribListRecibos.Item(i)("Tiposaco")
                If Not IsDBNull(Me.GribListRecibos.Item(i)("RangoImperfec")) Then
                    RangoImperf = Me.GribListRecibos.Item(i)("RangoImperfec")
                End If
                TipoLugarAco = Me.GribListRecibos.Item(i)("TipoLocalidad")
                UniMedida = Me.GribListRecibos.Item(i)("UnidadMedida")
                Cosecha = Me.GribListRecibos.Item(i)("IdCosecha")
                Humedad = Me.GribListRecibos.Item(i)("Humedad")

                '----------------------------------------------------------------------------------------------------------------------------
                '---------------------------------BUSCO LAS PESADAS -------------------------------------------------------------------------
                '----------------------------------------------------------------------------------------------------------------------------
                SqlString = "SELECT  id_Eventos, NumeroRemision, Fecha, TipoRemision, TipoPesada, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, Liquidado, Codigo_BeamsOrigen, RecepcionBin, Transferido, Calidad, Estado, Precio, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ, Calidad_Cafe, FechaCarga  FROM Detalle_Pesadas  WHERE  (Codigo_Beams LIKE '%" & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & "%') AND (IdRemisionPergamino = " & idRemisionPergamino & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Pesadas")
                If DataSet.Tables("Pesadas").Rows.Count <> 0 Then
                    '-----------------------------SIGNIFICA QUE EXISTE PESADA PARA ESTE RECIBO ---------------------------------------------------------

                    'PesadaBruto = DataSet.Tables("Pesadas").Rows(0)("PesoKg")
                    'PesadaTara = DataSet.Tables("Pesadas").Rows(0)("Tara")
                    'PesadaNeto = DataSet.Tables("Pesadas").Rows(0)("PesoNetoKg")
                    'Pesadaqq = DataSet.Tables("Pesadas").Rows(0)("QQ")
                    PesadaBruto = 0
                    PesadaTara = 0
                    PesadaNeto = 0
                    Pesadaqq = 0
                Else
                    PesadaBruto = 0
                    PesadaTara = 0
                    PesadaNeto = 0
                    Pesadaqq = 0
                End If

                DataSet.Tables("Pesadas").Reset()


                '------------------------SI ES REMISION MAQUILA--------------------------------------------
                If My.Forms.FrmRemision2.IdTipoCafe = 2 Then
                    oDatarow = DataSet.Tables("ListaRecibosAgrupados").NewRow
                    oDatarow("Productor") = Me.GribListRecibos.Item(i)("Proveedor")
                    oDatarow("NomFinca") = Me.GribListRecibos.Item(i)("NomFinca")
                    oDatarow("Codigo") = Me.GribListRecibos.Item(i)("Codigo")
                    oDatarow("Dano") = Me.GribListRecibos.Item(i)("Dano")
                    oDatarow("EstadoFisico") = Me.GribListRecibos.Item(i)("Descripcion")
                    oDatarow("TipoSaco") = Me.GribListRecibos.Item(i)("Tiposaco")
                    oDatarow("CantidadSacos") = Pesadaqq 'Me.GribListRecibos.Item(i)("CantidadSacos")
                    oDatarow("PesoBruto") = PesadaBruto 'Me.GribListRecibos.Item(i)("PesoBruto")
                    oDatarow("Tara") = PesadaTara 'Me.GribListRecibos.Item(i)("Tara")
                    oDatarow("PesoNeto") = PesadaNeto  'Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                    oDatarow("Humedad") = Me.GribListRecibos.Item(i)("Humedad")
                    oDatarow("RangoImperfec") = Me.GribListRecibos.Item(i)("RangoImperfec")
                    oDatarow("IdCosecha") = Me.GribListRecibos.Item(i)("IdCosecha")
                    oDatarow("IdTipoSaco") = Me.GribListRecibos.Item(i)("IdTipoSaco")
                    oDatarow("IdEdoFisico") = Me.GribListRecibos.Item(i)("IdEdoFisico")
                    oDatarow("IdDano") = Me.GribListRecibos.Item(i)("IdDano")
                    oDatarow("TipoLocalidad") = Me.GribListRecibos.Item(i)("TipoLocalidad")
                    oDatarow("IdDetalleReciboPergamino") = Me.GribListRecibos.Item(i)("IdReciboPergamino")
                    oDatarow("PesoNeto2") = Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                    oDatarow("CantidadSacos2") = Me.GribListRecibos.Item(i)("CantidadSacos")
                    oDatarow("PesosRecibos") = Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                    oDatarow("PesoBruto2") = Me.GribListRecibos.Item(i)("PesoBruto")
                    oDatarow("Tara2") = Me.GribListRecibos.Item(i)("Tara")
                    DataSet.Tables("ListaRecibosAgrupados").Rows.Add(oDatarow)

                    '------------------------SI ES REMISION PERGAMINO--------------------------------------------
                ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then
                    Criterios = "Dano= '" & Dano & "' And EstadoFisico= '" & EdoFisico & "' And Tiposaco= '" & TipoSaco & "' And RangoImperfec= '" & RangoImperf & "' And IdCosecha= '" & Cosecha & "'"   ' And TipoLocalidad= '" & TipoLugarAco & "'
                    Buscar_Fila = DataSet.Tables("ListaRecibosAgrupados").Select(Criterios)
                    If Buscar_Fila.Length > 0 Then
                        Posicion = DataSet.Tables("ListaRecibosAgrupados").Rows.IndexOf(Buscar_Fila(0))
                        'DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos") = 0 'Me.GribListRecibos.Item(i)("CantidadSacos") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoBruto2") = Me.GribListRecibos.Item(i)("PesoBruto") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoBruto2")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Tara2") = Me.GribListRecibos.Item(i)("Tara") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Tara2")
                        'DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto") = 0 '(Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")) + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("IdDetalleReciboPergamino") = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("IdDetalleReciboPergamino") & "-" & Me.GribListRecibos.Item(i)("IdReciboPergamino")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Codigo") = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Codigo") & "," & Me.GribListRecibos.Item(i)("Codigo")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto2") = (Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")) + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto2")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos2") = Me.GribListRecibos.Item(i)("CantidadSacos") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos2")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesosRecibos") = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesosRecibos") & "-" & Format(Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara"), "####0.0000")
                    Else
                        oDatarow = DataSet.Tables("ListaRecibosAgrupados").NewRow
                        oDatarow("Dano") = Me.GribListRecibos.Item(i)("Dano")
                        oDatarow("EstadoFisico") = Me.GribListRecibos.Item(i)("Descripcion")
                        oDatarow("TipoSaco") = Me.GribListRecibos.Item(i)("Tiposaco")
                        oDatarow("CantidadSacos") = Pesadaqq 'Me.GribListRecibos.Item(i)("CantidadSacos")
                        oDatarow("PesoBruto") = PesadaBruto 'Me.GribListRecibos.Item(i)("PesoBruto")
                        oDatarow("Tara") = PesadaTara 'Me.GribListRecibos.Item(i)("Tara")
                        oDatarow("PesoNeto") = PesadaNeto 'Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                        oDatarow("Humedad") = Me.GribListRecibos.Item(i)("Humedad")
                        oDatarow("RangoImperfec") = Me.GribListRecibos.Item(i)("RangoImperfec")
                        oDatarow("IdCosecha") = Me.GribListRecibos.Item(i)("IdCosecha")
                        oDatarow("IdTipoSaco") = Me.GribListRecibos.Item(i)("IdTipoSaco")
                        oDatarow("IdEdoFisico") = Me.GribListRecibos.Item(i)("IdEdoFisico")
                        oDatarow("IdDano") = Me.GribListRecibos.Item(i)("IdDano")
                        oDatarow("TipoLocalidad") = Me.GribListRecibos.Item(i)("TipoLocalidad")
                        oDatarow("Codigo") = Me.GribListRecibos.Item(i)("Codigo")
                        oDatarow("IdDetalleReciboPergamino") = Me.GribListRecibos.Item(i)("IdReciboPergamino")  'Modificado 17-01-2020  Solicitaron que en detalle en iddetalleRecibo se guarde el idReciboPergamino
                        oDatarow("PesoNeto2") = Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                        oDatarow("CantidadSacos2") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        oDatarow("PesosRecibos") = Format(Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara"), "####0.0000")
                        oDatarow("PesoBruto2") = Me.GribListRecibos.Item(i)("PesoBruto")
                        oDatarow("Tara2") = Me.GribListRecibos.Item(i)("Tara")
                        DataSet.Tables("ListaRecibosAgrupados").Rows.Add(oDatarow)
                    End If
                End If
            Else
                '//////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////
                MiConexion.Close()
                SqlString = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = 0  WHERE(IdReciboPergamino = " & Me.GribListRecibos.Item(i)("IdReciboPergamino") & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()
            End If
            i = i + 1
        Loop
        ''----------------------LLENO EL GRID DE LISTA RECIBOS--------------------------------------------------------------------------------------------------

        My.Forms.FrmRemision2.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos2")
        '////////////////////copio el dataset local en remisiones ///////////////////////////
        'My.Forms.FrmRemision2.DataSetRecibos.Tables("ListaRecibos2").Reset()
        My.Forms.FrmRemision2.DataSetRecibos.Reset()
        My.Forms.FrmRemision2.DataSetRecibos.Tables.Add(DataSet.Tables("ListaRecibos2").Copy)



        ''----------------------ACOMODO EL GRID DE LISTA RECIBOS------------------------------------------------------------------------------------------------------------------------------
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(0).Width = 220
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(1).Width = 150
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(2).Width = 90
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(3).Width = 80
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(4).Width = 100

        My.Forms.FrmRemision2.TDGribListRecibos.Columns(1).Caption = "Nombre Productor"
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(2).Caption = "Nombre Finca"
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(3).Caption = "Recibo No"
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(4).Caption = "Edo Fisico"
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(5).Caption = "Peso Neto"

        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(1).Locked = True
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(5).NumberFormat = "##,##0.00"



        ''--------------LLENO EL GRID DE DETALLES DE REMISION PERGAMINO o MAQUILA -----------------------------------------------------
        My.Forms.FrmRemision2.TDBGridDetalle.DataSource = DataSet.Tables("ListaRecibosAgrupados")

        ''--------------ACOMODO EL GRID DE DETALLES DE REMISION MAQUILA--------------------------------------------------------------
        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(12).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(13).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(14).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(15).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(16).Visible = False

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 145
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 72
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Width = 91
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Dano").Width = 71
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Width = 95
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Width = 60
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos").Width = 62
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto").Width = 77
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Width = 65
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto").Width = 76
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Humedad").Width = 82
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("RangoImperfec").Width = 50

 

            My.Forms.FrmRemision2.TDBGridDetalle.Columns(0).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(1).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(2).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(3).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(4).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(5).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(6).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(7).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(8).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(9).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(10).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(11).Caption = ""



            My.Forms.FrmRemision2.TDBGridDetalle.Columns(7).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(8).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(9).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(10).NumberFormat = "##,##0.00"

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Visible = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesosRecibos").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Tara2").Visible = False
            ''--------------ACOMODO EL GRID DE DETALLES DE REMISION PREGAMINO --------------------------------------------------------------
        ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(9).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(10).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(11).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(12).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(13).Visible = False

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 85
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 127
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 101
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Width = 99
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Width = 120
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Width = 86
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Width = 127
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Width = 109
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Width = 93

            My.Forms.FrmRemision2.TDBGridDetalle.Columns(0).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(1).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(2).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(3).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(4).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(5).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(6).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(7).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(8).Caption = ""

            My.Forms.FrmRemision2.TDBGridDetalle.Columns(4).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(5).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(6).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(7).NumberFormat = "##,##0.00"

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Locked = True

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesosRecibos").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Tara2").Visible = False
        End If

        My.Forms.FrmRemision2.SumaGridAgrupados()

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Sql = " Select ReciboCafePergamino.AplicarRemision as Aplicar, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria,   DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal,DetalleReciboCafePergamino.Tara AS PesoAplicado,DetalleReciboCafePergamino.Tara AS PesoPorAplicar, DetalleReciboCafePergamino.IdDetalleReciboPergamino FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN     Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '-55555') "
        'Sql = " Select Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria,   DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal,DetalleReciboCafePergamino.Tara AS PesoAplicado,DetalleReciboCafePergamino.Tara AS PesoPorAplicar FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN     Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '-55555') "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosParciales")

        Count = My.Forms.FrmRemision2.TDGribListRecibos.RowCount
        i = 0

        Do While Count > i


            'My.Forms.FrmRemision2.TDGribListRecibos.Row = i
            If My.Forms.FrmRemision2.TDGribListRecibos.Columns("Aplicar").Text = "" Then
                Aplicar = False
            Else
                Aplicar = My.Forms.FrmRemision2.TDGribListRecibos.Columns("Aplicar").Text
            End If

            oDatarow = DataSet.Tables("ListaRecibosParciales").NewRow
            oDatarow("Aplicar") = Aplicar
            oDatarow("Proveedor") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Proveedor")
            oDatarow("NomFinca") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("NomFinca")
            oDatarow("Codigo") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Codigo")
            oDatarow("Descripcion") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Descripcion")
            oDatarow("Dano") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Dano")
            oDatarow("Categoria") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Categoria")
            oDatarow("PesoReal") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("PESONETO")
            oDatarow("PesoAplicado") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("PESONETO")
            oDatarow("PesoPorAplicar") = 0.0
            oDatarow("IdDetalleReciboPergamino") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("IdReciboPergamino")  '/////MODIFICADO 23-01-2020  CAMBIADO POR CAMBIO SOLICITADO RECIBOREMISION PERGAMINO 7777777777
            DataSet.Tables("ListaRecibosParciales").Rows.Add(oDatarow)


            i = i + 1
        Loop

        ''--------------LLENO EL GRID DE DETALLES DE REMISION PERGAMINO-----------------------------------------------------
        My.Forms.FrmRemision2.BinReciboParcial.DataSource = DataSet.Tables("ListaRecibosParciales")
        My.Forms.FrmRemision2.TDGridUseParc.DataSource = My.Forms.FrmRemision2.BinReciboParcial.DataSource

        ''--------------ACOMODO EL GRID DE DETALLES DE REMISION PERGAMINO-----------------------------------------------------

        FrmRemision2.TDGridUseParc.Columns("Aplicar").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
        FrmRemision2.TDGridUseParc.Columns("Aplicar").ValueItems.CycleOnClick = True
        With FrmRemision2.TDGridUseParc.Columns("Aplicar").ValueItems.Values

            item.Value = "False"
            item.DisplayValue = Me.ImageList.Images(1)
            .Add(item)

            item = New C1.Win.C1TrueDBGrid.ValueItem()
            item.Value = "True"
            item.DisplayValue = Me.ImageList.Images(0)
            .Add(item)

            FrmRemision2.TDGridUseParc.Columns("Aplicar").ValueItems.Translate = True
        End With

        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Aplicar").Width = 30
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Proveedor").Width = 180
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("NomFinca").Width = 140
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Codigo").Width = 90
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Descripcion").Width = 65
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Dano").Width = 65
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Categoria").Width = 50
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("PesoReal").Width = 100

        My.Forms.FrmRemision2.TDGridUseParc.Columns("Aplicar").Caption = " "
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Proveedor").Caption = "Nombre Productor"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("NomFinca").Caption = "Nombre Finca"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Caption = "Recibo No"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Descripcion").Caption = "Edo Fisico"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Dano").Caption = "Daño"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Categoria").Caption = "Categoria"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Caption = "Peso Real"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoAplicado").Caption = "Peso Aplicado"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoPorAplicar").Caption = "Peso Por Aplicar"

        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False


        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Proveedor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("NomFinca").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Codigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Dano").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Categoria").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("PesoReal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").NumberFormat = "##,##0.00"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoAplicado").NumberFormat = "##,##0.00"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoPorAplicar").NumberFormat = "##,##0.00"
        '---------------------------------------------------------------------------------------------------------------------------------------------------


        '------------------------SI ES REMISION MAQUILA--------------------------------------------
        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then
            '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA MERMA /////////////////////////////
            Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
            i = 0
            Do While Cont > i
                'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                ODataRowDetalle("NumeroRecibo") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Codigo")
                ODataRowDetalle("Merma") = 0
                DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)
                i = i + 1
            Loop

        Else
            '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA MERMA /////////////////////////////
            Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
            i = 0
            Do While Cont > i
                'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                ODataRowDetalle("NumeroRecibo") = "Grupo " & i
                ODataRowDetalle("Merma") = 0
                DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)
                i = i + 1
            Loop
        End If


        My.Forms.FrmRemision2.TDBGridMerma.DataSource = DataSet.Tables("ListaRecibosRem")

        My.Forms.FrmRemision2.SumaGridParcial()

        My.Forms.FrmRemision2.CboTipoRemision.Enabled = False
        Me.Close()
    End Sub

    Private Sub CheckTodosRecibos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTodosRecibos.CheckedChanged
        Dim contador As Integer = 0, i As Integer = 0
        contador = Me.GribListRecibos.RowCount
        Do While contador > i
            Me.GribListRecibos.Row = i
            If CheckTodosRecibos.Checked = True Then
                Me.GribListRecibos.Item(i)("Seleccion") = True
            Else
                Me.GribListRecibos.Item(i)("Seleccion") = False
            End If
            i = i + 1
        Loop
    End Sub

    Private Sub BtnPegar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPegar2.Click
        Dim Posicion As Integer = Me.GribListRecibos.Row
        Dim Sql As String, DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim CodigoSubProveedor As String = "", SqlString As String
        Dim item As C1.Win.C1TrueDBGrid.ValueItem = New C1.Win.C1TrueDBGrid.ValueItem()
        Dim oDatarow As DataRow, Count As Double, i As Integer, ODataRowDetalle As DataRow, Cont As Double
        Dim Eleccion As Boolean, IdlocalidadRec As Double, PesoNeto As Double, Precio1 As Double, Precio As Double
        Dim Fechainicial As Date, FechaFinal As Date, Fechanow As Date, EsPorcentaje As Boolean, IdLocalidad As Integer, DeduccionDano As Double, DD As Double
        Dim DeducEstado As Double, Descripcion As String, PesoRestante As Double, EstadoLiquidado As Boolean, Parcial As Boolean
        Dim Saldo As Double, Monto As Double, TotalSaldo As Double, TotalMonto As Double, IdRecibo As Integer, Buscar_Fila() As DataRow, Criterios As String
        Dim Dano As String, Calidad As String, EdoFisico As String, TipoSaco As String, RangoImperf As String, TipoLugarAco As String, UniMedida As String, Cosecha As String, Humedad As Double
        Dim Cont2 As Double, j As Integer, estado As Boolean, nombre As String, PesadaBruto As Double, PesadaTara As Double, PesadaNeto As Double, Pesadaqq As Double
        Dim ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer, SeleccionRemi As Integer
        Dim Aplicar As Boolean, Cadena As String, CadenaDiv() As String, Max As Double, h As Double

        '------------------------------------------------------------------------------------------------------------------------------
        'Mando una consulta que no retorna nada
        '------------------------------------------------------------------------------------------------------------------------------
        Sql = " SELECT  Proveedor.Cod_Proveedor,Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS CantidadSacos, DetalleReciboCafePergamino.Tara AS Humedad, DetalleReciboCafePergamino.Tara AS IdSaco, DetalleReciboCafePergamino.Tara AS IdEdoFisico, DetalleReciboCafePergamino.Tara AS IdDano ,DetalleReciboCafePergamino.Tara AS PesoBruto , DetalleReciboCafePergamino.IdDetalleReciboPergamino, ReciboCafePergamino.AplicarRemision As Aplicar, ReciboCafePergamino.Fecha, ReciboCafePergamino.IdReciboPergamino FROM DetalleReciboCafePergamino INNER JOIN ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE   (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibos2")

        Sql = "SELECT ReciboCafePergamino.SeleccionRemision as Seleccion, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.Tara AS PesoPendiente, ReciboCafePergamino.IdReciboPergamino  FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '" & My.Forms.FrmRemision2.TxtIdcalidad.Text & "') "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "DatosRecibos")

        Sql = " SELECT  ReciboCafePergamino.Codigo As NumeroRecibo, ReciboCafePergamino.Codigo As Merma FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN  Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN  EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE        (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "') AND (ReciboCafePergamino.IdCalidad = '-55555')      "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosRem")

        'GRID DETALLES RECIBOS REMISIONES
        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then
            Sql = "SELECT        Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Productor, Finca.NomFinca, ReciboCafePergamino.Codigo, Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto AS PesoNeto, DetalleReciboCafePergamino.Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico, ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, TipoLocalidad.Descripcion AS IdDetalleReciboPergamino, DetalleReciboCafePergamino.PesoBruto AS PesoNeto2, DetalleReciboCafePergamino.CantidadSacos as CantidadSacos2, TipoLocalidad.Descripcion AS PesosRecibos, DetalleReciboCafePergamino.PesoBruto as PesoBruto2, DetalleReciboCafePergamino.Tara As Tara2    FROM  ReciboCafePergamino INNER JOIN  Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN                          DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN                          TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN                          RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN                          LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN                         UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN                           TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad INNER JOIN                          Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor INNER JOIN                          Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca WHERE        (ReciboCafePergamino.Codigo BETWEEN '-100000' AND '-1221') AND (ReciboCafePergamino.IdCalidad = '-1')"

        ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then
            Sql = "SELECT        Dano.Nombre AS Dano, EstadoFisico.Descripcion AS EstadoFisico, TipoSaco.Descripcion AS TipoSaco, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara,DetalleReciboCafePergamino.PesoBruto AS PesoNeto, DetalleReciboCafePergamino.Humedad, RangoImperfeccion.Nombre AS RangoImperfec, DetalleReciboCafePergamino.IdTipoSaco, ReciboCafePergamino.IdDano, DetalleReciboCafePergamino.IdEdoFisico,ReciboCafePergamino.IdCosecha, TipoLocalidad.Descripcion AS TipoLocalidad, TipoLocalidad.Descripcion AS IdDetalleReciboPergamino, ReciboCafePergamino.Codigo, DetalleReciboCafePergamino.PesoBruto AS PesoNeto2, DetalleReciboCafePergamino.CantidadSacos as CantidadSacos2, TipoLocalidad.Descripcion AS PesosRecibos, DetalleReciboCafePergamino.PesoBruto As PesoBruto2, DetalleReciboCafePergamino.Tara as Tara2  FROM   ReciboCafePergamino INNER JOIN    Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN  DetalleReciboCafePergamino ON ReciboCafePergamino.IdReciboPergamino = DetalleReciboCafePergamino.IdReciboPergamino INNER JOIN   EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN   TipoSaco ON DetalleReciboCafePergamino.IdTipoSaco = TipoSaco.IdTipoSaco INNER JOIN  RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN                          LugarAcopio ON ReciboCafePergamino.IdLocalidad = LugarAcopio.IdLugarAcopio INNER JOIN   UnidadMedida ON ReciboCafePergamino.IdUnidadMedida = UnidadMedida.IdUnidadMedida INNER JOIN  TipoLocalidad ON LugarAcopio.TipoLugarAcopio = TipoLocalidad.IdTipoLocalidad  WHERE  (ReciboCafePergamino.Codigo BETWEEN '-100000' AND '-1221')AND (ReciboCafePergamino.IdCalidad = '-1')"
        End If
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosAgrupados")

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Sql = " Select ReciboCafePergamino.AplicarRemision as Aplicar, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria,   DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal,DetalleReciboCafePergamino.Tara AS PesoAplicado,DetalleReciboCafePergamino.Tara AS PesoPorAplicar, DetalleReciboCafePergamino.IdDetalleReciboPergamino FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN     Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '-55555') "
        'Sql = " Select Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria,   DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal,DetalleReciboCafePergamino.Tara AS PesoAplicado,DetalleReciboCafePergamino.Tara AS PesoPorAplicar FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN     Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '-55555') "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosParciales")


        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////BUSCO SI EXISTEN REGISTROS EN EL LISTDO DE RECIBOS SELECCION/////////////////////////////////////
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Count = My.Forms.FrmRemision2.TDGridUseParc.RowCount
        i = 0
        Do While Count > i
            'Aplicar = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("Aplicar")
            oDatarow = DataSet.Tables("ListaRecibosParciales").NewRow
            oDatarow("Aplicar") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("Aplicar")
            oDatarow("Proveedor") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("Proveedor")
            oDatarow("NomFinca") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("NomFinca")
            oDatarow("Codigo") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("Codigo")
            oDatarow("Descripcion") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("Descripcion")
            oDatarow("Dano") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("Dano")
            oDatarow("Categoria") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("Categoria")
            oDatarow("PesoReal") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("PesoReal")
            oDatarow("PesoAplicado") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("PesoAplicado")
            oDatarow("PesoPorAplicar") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("PesoPorAplicar")
            oDatarow("IdDetalleReciboPergamino") = My.Forms.FrmRemision2.TDGridUseParc.Item(i)("IdDetalleReciboPergamino")
            DataSet.Tables("ListaRecibosParciales").Rows.Add(oDatarow)
            i = i + 1
        Loop


        'Count = My.Forms.FrmRemision2.TDGribListRecibos.RowCount
        'i = 0
        'Do While Count > i
        '    oDatarow = DataSet.Tables("ListaRecibos2").NewRow
        '    oDatarow("Proveedor") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Proveedor")
        '    oDatarow("NomFinca") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("NomFinca")
        '    oDatarow("Codigo") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Codigo")
        '    oDatarow("Descripcion") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Descripcion")
        '    oDatarow("PESONETO") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("PESONETO")
        '    oDatarow("CantidadSacos") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("CantidadSacos")
        '    oDatarow("Humedad") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Humedad")
        '    oDatarow("IdSaco") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("IdTipoSaco")
        '    oDatarow("IdEdoFisico") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("IdEdoFisico")
        '    oDatarow("IdDano") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("IdDano")
        '    oDatarow("Dano") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Dano")
        '    oDatarow("PesoBruto") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("PesoBruto")
        '    oDatarow("IdDetalleReciboPergamino") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("IdDetalleReciboPergamino")
        '    oDatarow("Categoria") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Categoria")
        '    'oDatarow("Fecha") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("Fecha")
        '    oDatarow("IdReciboPergamino") = My.Forms.FrmRemision2.TDGribListRecibos.Item(i)("IdReciboPergamino")

        '    DataSet.Tables("ListaRecibos2").Rows.Add(oDatarow)
        '    i = i + 1
        'Loop

        Count = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
        i = 0
        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then
            Do While Count > i
                oDatarow = DataSet.Tables("ListaRecibosAgrupados").NewRow
                oDatarow("Productor") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Productor")
                oDatarow("NomFinca") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("NomFinca")
                oDatarow("Codigo") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Codigo")
                oDatarow("Dano") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Dano")
                oDatarow("EstadoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                oDatarow("TipoSaco") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tiposaco")
                oDatarow("CantidadSacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos")
                oDatarow("PesoBruto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                oDatarow("Tara") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tara")
                oDatarow("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto") - My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tara")
                oDatarow("Humedad") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Humedad")
                oDatarow("RangoImperfec") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                oDatarow("IdCosecha") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdCosecha")
                oDatarow("IdTipoSaco") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdTipoSaco")
                oDatarow("IdEdoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdEdoFisico")
                oDatarow("IdDano") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdDano")
                oDatarow("TipoLocalidad") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("TipoLocalidad")
                oDatarow("IdDetalleReciboPergamino") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdDetalleReciboPergamino")
                oDatarow("PesoNeto2") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto2")
                oDatarow("CantidadSacos2") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos2")
                oDatarow("PesoBruto2") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                oDatarow("Tara2") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tara")
                oDatarow("PesosRecibos") = Format(My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto") - My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tara"), "####0.0000")
                DataSet.Tables("ListaRecibosAgrupados").Rows.Add(oDatarow)
                i = i + 1
            Loop

        Else
            Do While Count > i
                oDatarow = DataSet.Tables("ListaRecibosAgrupados").NewRow
                oDatarow("Dano") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Dano")
                oDatarow("EstadoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("EstadoFisico")
                oDatarow("TipoSaco") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tiposaco")
                oDatarow("CantidadSacos") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos")
                oDatarow("PesoBruto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                oDatarow("Tara") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tara")
                oDatarow("PesoNeto") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto")
                oDatarow("Humedad") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Humedad")
                oDatarow("RangoImperfec") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("RangoImperfec")
                oDatarow("IdCosecha") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdCosecha")
                oDatarow("IdTipoSaco") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdTipoSaco")
                oDatarow("IdEdoFisico") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdEdoFisico")
                oDatarow("IdDano") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdDano")
                oDatarow("TipoLocalidad") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("TipoLocalidad")
                oDatarow("Codigo") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Codigo")
                oDatarow("IdDetalleReciboPergamino") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("IdDetalleReciboPergamino")
                oDatarow("PesoNeto2") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoNeto2")
                oDatarow("CantidadSacos2") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("CantidadSacos2")
                oDatarow("PesoBruto2") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto")
                oDatarow("Tara2") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tara")
                oDatarow("PesosRecibos") = Format(My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("PesoBruto") - My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Tara"), "####0.0000")
                DataSet.Tables("ListaRecibosAgrupados").Rows.Add(oDatarow)
                i = i + 1
            Loop
        End If



        Count = Me.GribListRecibos.RowCount
        i = 0
        FrmRemision2.ListPorveedores.ClearSelected()
        Do While Count > i
            Eleccion = Me.GribListRecibos.Item(i)("Seleccion")

            If Eleccion = True Then
                SeleccionRemi = 1
            Else
                SeleccionRemi = 0
            End If

            '//////////////////////////////////////////////////////////////////////////////////////////////
            '////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////
            MiConexion.Close()
            SqlString = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = " & SeleccionRemi & "  WHERE(IdReciboPergamino = " & Me.GribListRecibos.Item(i)("IdReciboPergamino") & ")"
            MiConexion.Open()
            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
            iResultado = ComandoUpdate.ExecuteNonQuery
            MiConexion.Close()


            If Eleccion = True Then

                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////BUSCO LOS PROVEEDORES PARA CHECK/////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Cont2 = FrmRemision2.ListPorveedores.ListCount - 1
                For j = 0 To Cont2
                    estado = FrmRemision2.ListPorveedores.SelectedIndices.Contains(j)
                    FrmRemision2.ListPorveedores.Row = j
                    nombre = FrmRemision2.ListPorveedores.Columns(0).Text
                    If nombre = Me.GribListRecibos.Item(i)("Proveedor") Then
                        'estado = FrmRemision2.ListPorveedores.SelectedIndices.Contains(j)
                        If estado = False Then
                            FrmRemision2.ListPorveedores.SetSelected(j, True)
                            Exit For
                        End If
                    Else
                        If estado = False Then
                            FrmRemision2.ListPorveedores.SetSelected(j, False)
                        End If
                    End If
                    j = j
                Next

                ''//////////////////////////////////////////////////////////////////////////////////////////////
                ''////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
                ''/////////////////////////////////////////////////////////////////////////////////////////////////
                'MiConexion.Close()
                'SqlString = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = 1  WHERE(IdReciboPergamino = " & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & ")"
                'MiConexion.Open()
                'ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                'iResultado = ComandoUpdate.ExecuteNonQuery
                'MiConexion.Close()

                Criterios = "IdDetalleReciboPergamino= " & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & " "
                Buscar_Fila = DataSet.Tables("ListaRecibosParciales").Select(Criterios)
                If Buscar_Fila.Length > 0 Then
                    '/////////////////////SI LO ENCUENTRA NO HAGO NADA//////////////////////
                Else
                    oDatarow = DataSet.Tables("ListaRecibos2").NewRow
                    oDatarow("Proveedor") = Me.GribListRecibos.Item(i)("Proveedor")
                    oDatarow("NomFinca") = Me.GribListRecibos.Item(i)("NomFinca")
                    oDatarow("Codigo") = Me.GribListRecibos.Item(i)("Codigo")
                    oDatarow("Descripcion") = Me.GribListRecibos.Item(i)("Descripcion")
                    oDatarow("PESONETO") = Me.GribListRecibos.Item(i)("PESONETO")
                    oDatarow("CantidadSacos") = Me.GribListRecibos.Item(i)("CantidadSacos")
                    oDatarow("Humedad") = Me.GribListRecibos.Item(i)("Humedad")
                    oDatarow("IdSaco") = Me.GribListRecibos.Item(i)("IdTipoSaco")
                    oDatarow("IdEdoFisico") = Me.GribListRecibos.Item(i)("IdEdoFisico")
                    oDatarow("IdDano") = Me.GribListRecibos.Item(i)("IdDano")
                    oDatarow("Dano") = Me.GribListRecibos.Item(i)("Dano")
                    oDatarow("PesoBruto") = Me.GribListRecibos.Item(i)("PesoBruto")
                    oDatarow("IdDetalleReciboPergamino") = Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino")
                    oDatarow("Categoria") = Me.GribListRecibos.Item(i)("RangoImperfec")
                    oDatarow("Fecha") = Me.GribListRecibos.Item(i)("Fecha")
                    oDatarow("IdReciboPergamino") = Me.GribListRecibos.Item(i)("IdReciboPergamino")

                    DataSet.Tables("ListaRecibos2").Rows.Add(oDatarow)
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------------------
                Dano = Me.GribListRecibos.Item(i)("Dano")
                Calidad = Me.GribListRecibos.Item(i)("NomCalidad")
                EdoFisico = Me.GribListRecibos.Item(i)("Descripcion")
                TipoSaco = Me.GribListRecibos.Item(i)("Tiposaco")
                If Not IsDBNull(Me.GribListRecibos.Item(i)("RangoImperfec")) Then
                    RangoImperf = Me.GribListRecibos.Item(i)("RangoImperfec")
                Else
                    RangoImperf = 0
                End If
                TipoLugarAco = Me.GribListRecibos.Item(i)("TipoLocalidad")
                UniMedida = Me.GribListRecibos.Item(i)("UnidadMedida")
                Cosecha = Me.GribListRecibos.Item(i)("IdCosecha")
                Humedad = Me.GribListRecibos.Item(i)("Humedad")

                '----------------------------------------------------------------------------------------------------------------------------
                '---------------------------------BUSCO LAS PESADAS -------------------------------------------------------------------------
                '----------------------------------------------------------------------------------------------------------------------------
                SqlString = "SELECT  id_Eventos, NumeroRemision, Fecha, TipoRemision, TipoPesada, Cod_Productos, Descripcion_Producto, Codigo_Beams, Cantidad, Unidad_Medida, Liquidado, Codigo_BeamsOrigen, RecepcionBin, Transferido, Calidad, Estado, Precio, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ, Calidad_Cafe, FechaCarga  FROM Detalle_Pesadas  WHERE  (Codigo_Beams LIKE '%" & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & "%') AND (IdRemisionPergamino = " & idRemisionPergamino & ")"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Pesadas")
                If DataSet.Tables("Pesadas").Rows.Count <> 0 Then
                    '-----------------------------SIGNIFICA QUE EXISTE PESADA PARA ESTE RECIBO y REMISION---------------------------------------------------------

                    'PesadaBruto = DataSet.Tables("Pesadas").Rows(0)("PesoKg")
                    'PesadaTara = DataSet.Tables("Pesadas").Rows(0)("Tara")
                    'PesadaNeto = DataSet.Tables("Pesadas").Rows(0)("PesoNetoKg")
                    'Pesadaqq = DataSet.Tables("Pesadas").Rows(0)("QQ")
                    PesadaBruto = 0
                    PesadaTara = 0
                    PesadaNeto = 0
                    Pesadaqq = 0
                Else
                    PesadaBruto = 0
                    PesadaTara = 0
                    PesadaNeto = 0
                    Pesadaqq = 0
                End If

                DataSet.Tables("Pesadas").Reset()
                '------------------------SI ES REMISION MAQUILA--------------------------------------------
                If My.Forms.FrmRemision2.IdTipoCafe = 2 Then

                    Criterios = "IdDetalleReciboPergamino= " & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & " "
                    Buscar_Fila = DataSet.Tables("ListaRecibosParciales").Select(Criterios)
                    If Buscar_Fila.Length > 0 Then
                        '/////////////////////SI LO ENCUENTRA NO HACE NADA //////////////////////
                    Else
                        oDatarow = DataSet.Tables("ListaRecibosAgrupados").NewRow
                        oDatarow("Productor") = Me.GribListRecibos.Item(i)("Proveedor")
                        oDatarow("NomFinca") = Me.GribListRecibos.Item(i)("NomFinca")
                        oDatarow("Codigo") = Me.GribListRecibos.Item(i)("Codigo")
                        oDatarow("Dano") = Me.GribListRecibos.Item(i)("Dano")
                        oDatarow("EstadoFisico") = Me.GribListRecibos.Item(i)("Descripcion")
                        oDatarow("TipoSaco") = Me.GribListRecibos.Item(i)("Tiposaco")
                        oDatarow("CantidadSacos") = Pesadaqq 'Me.GribListRecibos.Item(i)("CantidadSacos")
                        oDatarow("PesoBruto") = PesadaBruto 'Me.GribListRecibos.Item(i)("PesoBruto")
                        oDatarow("Tara") = PesadaTara 'Me.GribListRecibos.Item(i)("Tara")
                        oDatarow("PesoNeto") = PesadaNeto  'Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                        oDatarow("Humedad") = Me.GribListRecibos.Item(i)("Humedad")
                        oDatarow("RangoImperfec") = Me.GribListRecibos.Item(i)("RangoImperfec")
                        oDatarow("IdCosecha") = Me.GribListRecibos.Item(i)("IdCosecha")
                        oDatarow("IdTipoSaco") = Me.GribListRecibos.Item(i)("IdTipoSaco")
                        oDatarow("IdEdoFisico") = Me.GribListRecibos.Item(i)("IdEdoFisico")
                        oDatarow("IdDano") = Me.GribListRecibos.Item(i)("IdDano")
                        oDatarow("TipoLocalidad") = Me.GribListRecibos.Item(i)("TipoLocalidad")
                        oDatarow("IdDetalleReciboPergamino") = Me.GribListRecibos.Item(i)("IdReciboPergamino")   'Modificado 21-01-2020 solicitado por IT  en el campo iddetalle grabar Idrecibo
                        oDatarow("PesoNeto2") = Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                        oDatarow("CantidadSacos2") = Me.GribListRecibos.Item(i)("CantidadSacos")
                        oDatarow("PesosRecibos") = Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                        oDatarow("PesoBruto2") = Me.GribListRecibos.Item(i)("PesoBruto")
                        oDatarow("Tara2") = Me.GribListRecibos.Item(i)("Tara")
                        DataSet.Tables("ListaRecibosAgrupados").Rows.Add(oDatarow)
                    End If

                    '------------------------SI ES REMISION PERGAMINO--------------------------------------------
                ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then
                    Criterios = "Dano= '" & Dano & "' And EstadoFisico= '" & EdoFisico & "' And Tiposaco= '" & TipoSaco & "' And RangoImperfec= '" & RangoImperf & "' And TipoLocalidad= '" & TipoLugarAco & "' And IdCosecha= '" & Cosecha & "'"
                    Buscar_Fila = DataSet.Tables("ListaRecibosAgrupados").Select(Criterios)
                    If Buscar_Fila.Length > 0 Then
                        Posicion = DataSet.Tables("ListaRecibosAgrupados").Rows.IndexOf(Buscar_Fila(0))
                        'DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos") = 0 'Me.GribListRecibos.Item(i)("CantidadSacos") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoBruto2") = Me.GribListRecibos.Item(i)("PesoBruto") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoBruto2")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Tara2") = Me.GribListRecibos.Item(i)("Tara") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Tara2")
                        'DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto") = 0 '(Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")) + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("IdDetalleReciboPergamino") = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("IdDetalleReciboPergamino") & "-" & Me.GribListRecibos.Item(i)("IdReciboPergamino")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Codigo") = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("Codigo") & "," & Me.GribListRecibos.Item(i)("Codigo")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto2") = (Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")) + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesoNeto2")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos2") = Me.GribListRecibos.Item(i)("CantidadSacos") + DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("CantidadSacos2")
                        DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesosRecibos") = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("PesosRecibos") & "-" & Format(Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara"), "####0.0000")
                    Else

                        Criterios = "IdDetalleReciboPergamino= " & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & " "
                        Buscar_Fila = DataSet.Tables("ListaRecibosParciales").Select(Criterios)
                        If Buscar_Fila.Length > 0 Then
                            '/////////////////////SI LO ENCUENTRA NO HAGO NADA//////////////////////
                        Else
                            oDatarow = DataSet.Tables("ListaRecibosAgrupados").NewRow
                            oDatarow("Dano") = Me.GribListRecibos.Item(i)("Dano")
                            oDatarow("EstadoFisico") = Me.GribListRecibos.Item(i)("Descripcion")
                            oDatarow("TipoSaco") = Me.GribListRecibos.Item(i)("Tiposaco")
                            oDatarow("CantidadSacos") = Pesadaqq 'Me.GribListRecibos.Item(i)("CantidadSacos")
                            oDatarow("PesoBruto") = PesadaBruto 'Me.GribListRecibos.Item(i)("PesoBruto")
                            oDatarow("Tara") = PesadaTara 'Me.GribListRecibos.Item(i)("Tara")
                            oDatarow("PesoNeto") = PesadaNeto 'Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                            oDatarow("Humedad") = Me.GribListRecibos.Item(i)("Humedad")
                            oDatarow("RangoImperfec") = Me.GribListRecibos.Item(i)("RangoImperfec")
                            oDatarow("IdCosecha") = Me.GribListRecibos.Item(i)("IdCosecha")
                            oDatarow("IdTipoSaco") = Me.GribListRecibos.Item(i)("IdTipoSaco")
                            oDatarow("IdEdoFisico") = Me.GribListRecibos.Item(i)("IdEdoFisico")
                            oDatarow("IdDano") = Me.GribListRecibos.Item(i)("IdDano")
                            oDatarow("TipoLocalidad") = Me.GribListRecibos.Item(i)("TipoLocalidad")
                            oDatarow("Codigo") = Me.GribListRecibos.Item(i)("Codigo")
                            oDatarow("IdDetalleReciboPergamino") = Me.GribListRecibos.Item(i)("IdReciboPergamino")
                            oDatarow("PesoNeto2") = Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara")
                            oDatarow("CantidadSacos2") = Me.GribListRecibos.Item(i)("CantidadSacos")
                            oDatarow("PesosRecibos") = Format(Me.GribListRecibos.Item(i)("PesoBruto") - Me.GribListRecibos.Item(i)("Tara"), "####0.0000")
                            oDatarow("PesoBruto2") = Me.GribListRecibos.Item(i)("PesoBruto")
                            oDatarow("Tara2") = Me.GribListRecibos.Item(i)("Tara")
                            DataSet.Tables("ListaRecibosAgrupados").Rows.Add(oDatarow)
                        End If
                    End If

                End If

            Else
                '//////////////////////////////////////////////////////////////////////////////////////////////
                '////////////////////////////ACTUALIZO LA TABLA RECIBO CON LA SELECCION///////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////
                MiConexion.Close()
                SqlString = "UPDATE [ReciboCafePergamino] SET [SeleccionRemision] = 0  WHERE(IdReciboPergamino = " & Me.GribListRecibos.Item(i)("IdReciboPergamino") & ")"
                MiConexion.Open()
                ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                iResultado = ComandoUpdate.ExecuteNonQuery
                MiConexion.Close()

                '////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////BUSCO SI EL RECIBO ESTA EN LA LISTA DE LA REMISION ///////////////////
                '////////////////////////////////////////////////////////////////////////////////////////////////////
                Criterios = "IdDetalleReciboPergamino= " & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & " "
                Buscar_Fila = DataSet.Tables("ListaRecibosParciales").Select(Criterios)
                If Buscar_Fila.Length > 0 Then
                    '///////////////////////////////SI LO ENCUENTRO CONSULTO SI ESTA GRABADO PARA ESTA REMISION////////////////////////////////////////
                    SqlString = "SELECT CASE WHEN Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor IS NULL THEN ReciboCafePergamino.ProductorManual ELSE Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor END AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, DetalleReciboCafePergamino.PesoBruto, DetalleReciboCafePergamino.Tara, DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PESONETO, DetalleReciboCafePergamino.CantidadSacos, DetalleReciboCafePergamino.Humedad, DetalleReciboCafePergamino.Imperfeccion, DetalleReciboCafePergamino.IdTipoSaco, DetalleReciboCafePergamino.IdEdoFisico, Dano.IdDano, Dano.Nombre AS Dano, DetalleReciboCafePergamino.IdReciboPergamino, DetalleReciboCafePergamino.IdDetalleReciboPergamino, RangoImperfeccion.Nombre AS Categoria, RangoImperfeccion.IdRangoImperfeccion, DetalleRemisionPergamino.IdDetalleRemisionPergamino, DetalleRemisionPergamino.IdRemisionPergamino, ReciboCafePergamino.CedulaManual, ReciboCafePergamino.ProductorManual FROM RecibosRemisionPergamino INNER JOIN DetalleReciboCafePergamino ON RecibosRemisionPergamino.IdDetalleReciboPergamino = DetalleReciboCafePergamino.IdDetalleReciboPergamino INNER JOIN  ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.EstadoFisico INNER JOIN Dano ON ReciboCafePergamino.IdDano = Dano.IdDano INNER JOIN RangoImperfeccion ON ReciboCafePergamino.IdRangoImperfeccion = RangoImperfeccion.IdRangoImperfeccion INNER JOIN DetalleRemisionPergamino ON RecibosRemisionPergamino.IdDetalleRemsionPergamino = DetalleRemisionPergamino.IdDetalleRemisionPergamino LEFT OUTER JOIN Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca LEFT OUTER JOIN  Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.Cod_Proveedor " & _
                          "WHERE(DetalleRemisionPergamino.IdRemisionPergamino = " & Me.idRemisionPergamino & ") AND (DetalleReciboCafePergamino.IdReciboPergamino = " & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & ") ORDER BY RecibosRemisionPergamino.Orden"
                    DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                    DataAdapter.Fill(DataSet, "Consulta")
                    If DataSet.Tables("Consulta").Rows.Count = 0 Then
                        '/////////////////////////////////////SI LO ENCUENTRO COMO NO ESTA CHEQUEADO LO ELIMINO DE LA REMISION
                        Posicion = DataSet.Tables("ListaRecibosParciales").Rows.IndexOf(Buscar_Fila(0))
                        DataSet.Tables("ListaRecibosParciales").Rows(Posicion).Delete()

                        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then
                            DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion).Delete()
                        ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then
                            Criterios = "IdDetalleReciboPergamino LIKE '%" & Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") & "%' "
                            Buscar_Fila = DataSet.Tables("ListaRecibosAgrupados").Select(Criterios)
                            If Buscar_Fila.Length > 0 Then
                                Posicion = DataSet.Tables("ListaRecibosAgrupados").Rows.IndexOf(Buscar_Fila(0))
                                '///////////////////////////////////////SI LO ENCUENTRO REEMPLASO LA CADENA ///////////////////////////////////
                                Cadena = DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("IdDetalleReciboPergamino")
                                CadenaDiv = Cadena.Split("-")
                                Max = UBound(CadenaDiv)

                                Cadena = ""
                                h = 0
                                For h = 0 To Max
                                    If CadenaDiv(h) <> Me.GribListRecibos.Item(i)("IdDetalleReciboPergamino") Then
                                        If Cadena = "" Then
                                            Cadena = CadenaDiv(h)
                                        Else
                                            Cadena = Cadena & "-" & CadenaDiv(h)
                                        End If
                                    End If
                                Next

                                If Cadena = "" Then
                                    DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion).Delete()
                                Else
                                    DataSet.Tables("ListaRecibosAgrupados").Rows(Posicion)("IdDetalleReciboPergamino") = Cadena
                                End If

                            End If

                            End If
                    End If
                    DataSet.Tables("Consulta").Reset()

                End If



            End If
                i = i + 1
        Loop
        ''----------------------LLENO EL GRID DE LISTA RECIBOS--------------------------------------------------------------------------------------------------

        '//////////////////////////COPIO LOS DATASET PARA REMISION //////////////////////////////////
        My.Forms.FrmRemision2.TDGribListRecibos.DataSource = DataSet.Tables("ListaRecibos2")
        '////////////////////copio el dataset local en remisiones ///////////////////////////
        'My.Forms.FrmRemision2.DataSetRecibos.Tables("ListaRecibos2").Reset()
        My.Forms.FrmRemision2.DataSetRecibos.Reset()
        My.Forms.FrmRemision2.DataSetRecibos.Tables.Add(DataSet.Tables("ListaRecibos2").Copy)



        ''----------------------ACOMODO EL GRID DE LISTA RECIBOS------------------------------------------------------------------------------------------------------------------------------
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(0).Width = 220
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(1).Width = 150
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(2).Width = 90
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(3).Width = 80
        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(4).Width = 100

        My.Forms.FrmRemision2.TDGribListRecibos.Columns(1).Caption = "Nombre Productor"
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(2).Caption = "Nombre Finca"
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(3).Caption = "Recibo No"
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(4).Caption = "Edo Fisico"
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(5).Caption = "Peso Neto"

        My.Forms.FrmRemision2.TDGribListRecibos.Splits.Item(0).DisplayColumns(1).Locked = True
        My.Forms.FrmRemision2.TDGribListRecibos.Columns(5).NumberFormat = "##,##0.00"



        ''--------------LLENO EL GRID DE DETALLES DE REMISION PERGAMINO o MAQUILA -----------------------------------------------------
        My.Forms.FrmRemision2.TDBGridDetalle.DataSource = DataSet.Tables("ListaRecibosAgrupados")

        ''--------------ACOMODO EL GRID DE DETALLES DE REMISION MAQUILA--------------------------------------------------------------
        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(12).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(13).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(14).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(15).Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(16).Visible = False

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 145
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 72
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Width = 91
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Dano").Width = 71
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Width = 95
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Width = 60
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos").Width = 62
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto").Width = 77
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Width = 65
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto").Width = 76
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Humedad").Width = 82
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("RangoImperfec").Width = 50



            My.Forms.FrmRemision2.TDBGridDetalle.Columns(0).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(1).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(2).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(3).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(4).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(5).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(6).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(7).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(8).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(9).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(10).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(11).Caption = ""



            My.Forms.FrmRemision2.TDBGridDetalle.Columns(7).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(8).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(9).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(10).NumberFormat = "##,##0.00"

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Tara2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Visible = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesosRecibos").Visible = False
            ''--------------ACOMODO EL GRID DE DETALLES DE REMISION PREGAMINO --------------------------------------------------------------
        ElseIf My.Forms.FrmRemision2.IdTipoCafe = 1 Then

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdTipoSaco").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDano").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdEdoFisico").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdCosecha").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("TipoLocalidad").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoBruto2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Tara2").Visible = False

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Width = 85
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Width = 127
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Width = 101
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Width = 99
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Width = 120
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Width = 86
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Width = 127
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Width = 109
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Width = 93

            My.Forms.FrmRemision2.TDBGridDetalle.Columns(0).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(1).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(2).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(3).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(4).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(5).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(6).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(7).Caption = ""
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(8).Caption = ""

            My.Forms.FrmRemision2.TDBGridDetalle.Columns(4).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(5).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(6).NumberFormat = "##,##0.00"
            My.Forms.FrmRemision2.TDBGridDetalle.Columns(7).NumberFormat = "##,##0.00"

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(0).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(1).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(2).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(3).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(4).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(5).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(6).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(7).Locked = True
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns(8).Locked = True

            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("Codigo").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesoNeto2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("CantidadSacos2").Visible = False
            My.Forms.FrmRemision2.TDBGridDetalle.Splits.Item(0).DisplayColumns("PesosRecibos").Visible = False
        End If

        My.Forms.FrmRemision2.SumaGridAgrupados()

        'TRASLADO ESTE CODIGO AL INICIO
        ''---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Sql = " Select ReciboCafePergamino.AplicarRemision as Aplicar, Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria,   DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal,DetalleReciboCafePergamino.Tara AS PesoAplicado,DetalleReciboCafePergamino.Tara AS PesoPorAplicar, DetalleReciboCafePergamino.IdDetalleReciboPergamino FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN     Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '-55555') "
        'Sql = " Select Proveedor.Nombre_Proveedor + ' ' + Proveedor.Apellido_Proveedor AS Proveedor, Finca.NomFinca, ReciboCafePergamino.Codigo, EstadoFisico.Descripcion, EstadoFisico.Descripcion AS Dano, EstadoFisico.Descripcion AS Categoria,   DetalleReciboCafePergamino.PesoBruto - DetalleReciboCafePergamino.Tara AS PesoReal,DetalleReciboCafePergamino.Tara AS PesoAplicado,DetalleReciboCafePergamino.Tara AS PesoPorAplicar FROM  DetalleReciboCafePergamino INNER JOIN   ReciboCafePergamino ON DetalleReciboCafePergamino.IdReciboPergamino = ReciboCafePergamino.IdReciboPergamino INNER JOIN   Finca ON ReciboCafePergamino.IdFinca = Finca.IdFinca INNER JOIN                          EstadoFisico ON DetalleReciboCafePergamino.IdEdoFisico = EstadoFisico.IdEdoFisico INNER JOIN     Proveedor ON ReciboCafePergamino.IdProductor = Proveedor.IdProductor WHERE  (ReciboCafePergamino.Codigo BETWEEN '" & My.Forms.FrmRemision2.CboRecInicial.Text & "' AND '" & My.Forms.FrmRemision2.CboRecFinal.Text & "')AND (ReciboCafePergamino.IdCalidad = '-55555') "
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "ListaRecibosParciales")

        Count = My.Forms.FrmRemision2.TDGribListRecibos.RowCount
        i = 0

        Do While Count > i


            My.Forms.FrmRemision2.TDGribListRecibos.Row = i
            If My.Forms.FrmRemision2.TDGribListRecibos.Columns("Aplicar").Text = "" Then
                Aplicar = False
            Else
                Aplicar = My.Forms.FrmRemision2.TDGribListRecibos.Columns("Aplicar").Text
            End If

            Criterios = "IdDetalleReciboPergamino= " & My.Forms.FrmRemision2.TDGribListRecibos.Columns("IdDetalleReciboPergamino").Text & " "
            Buscar_Fila = DataSet.Tables("ListaRecibosParciales").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                '/////////////////////SI LO ENCUENTRA NO HACE NADA //////////////////////
            Else
                oDatarow = DataSet.Tables("ListaRecibosParciales").NewRow
                oDatarow("Aplicar") = Aplicar
                oDatarow("Proveedor") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("Proveedor").Text
                oDatarow("NomFinca") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("NomFinca").Text
                oDatarow("Codigo") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("Codigo").Text
                oDatarow("Descripcion") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("Descripcion").Text
                oDatarow("Dano") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("Dano").Text
                oDatarow("Categoria") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("Categoria").Text
                oDatarow("PesoReal") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("PESONETO").Text
                oDatarow("PesoAplicado") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("PESONETO").Text
                oDatarow("PesoPorAplicar") = 0.0
                oDatarow("IdDetalleReciboPergamino") = My.Forms.FrmRemision2.TDGribListRecibos.Columns("IdDetalleReciboPergamino").Text
                DataSet.Tables("ListaRecibosParciales").Rows.Add(oDatarow)
            End If





            i = i + 1
        Loop





        ''--------------LLENO EL GRID DE DETALLES DE REMISION PERGAMINO-----------------------------------------------------
        My.Forms.FrmRemision2.BinReciboParcial.DataSource = DataSet.Tables("ListaRecibosParciales")
        My.Forms.FrmRemision2.TDGridUseParc.DataSource = My.Forms.FrmRemision2.BinReciboParcial.DataSource

        ''--------------ACOMODO EL GRID DE DETALLES DE REMISION PERGAMINO-----------------------------------------------------

        FrmRemision2.TDGridUseParc.Columns("Aplicar").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal
        FrmRemision2.TDGridUseParc.Columns("Aplicar").ValueItems.CycleOnClick = True
        With FrmRemision2.TDGridUseParc.Columns("Aplicar").ValueItems.Values

            item.Value = "False"
            item.DisplayValue = Me.ImageList.Images(1)
            .Add(item)

            item = New C1.Win.C1TrueDBGrid.ValueItem()
            item.Value = "True"
            item.DisplayValue = Me.ImageList.Images(0)
            .Add(item)

            FrmRemision2.TDGridUseParc.Columns("Aplicar").ValueItems.Translate = True
        End With

        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Aplicar").Width = 30
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Proveedor").Width = 180
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("NomFinca").Width = 140
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Codigo").Width = 90
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Descripcion").Width = 65
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Dano").Width = 65
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Categoria").Width = 50
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("PesoReal").Width = 100

        My.Forms.FrmRemision2.TDGridUseParc.Columns("Aplicar").Caption = " "
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Proveedor").Caption = "Nombre Productor"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("NomFinca").Caption = "Nombre Finca"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Codigo").Caption = "Recibo No"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Descripcion").Caption = "Edo Fisico"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Dano").Caption = "Daño"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("Categoria").Caption = "Categoria"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").Caption = "Peso Real"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoAplicado").Caption = "Peso Aplicado"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoPorAplicar").Caption = "Peso Por Aplicar"

        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("IdDetalleReciboPergamino").Visible = False


        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Proveedor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("NomFinca").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Codigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Dano").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("Categoria").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        My.Forms.FrmRemision2.TDGridUseParc.Splits.Item(0).DisplayColumns("PesoReal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoReal").NumberFormat = "##,##0.00"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoAplicado").NumberFormat = "##,##0.00"
        My.Forms.FrmRemision2.TDGridUseParc.Columns("PesoPorAplicar").NumberFormat = "##,##0.00"
        '---------------------------------------------------------------------------------------------------------------------------------------------------


        '------------------------SI ES REMISION MAQUILA--------------------------------------------
        If My.Forms.FrmRemision2.IdTipoCafe = 2 Then
            '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA MERMA /////////////////////////////
            Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
            i = 0
            Do While Cont > i
                'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                ODataRowDetalle("NumeroRecibo") = My.Forms.FrmRemision2.TDBGridDetalle.Item(i)("Codigo")
                ODataRowDetalle("Merma") = 0
                DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)
                i = i + 1
            Loop

        Else
            '////////////////////////////////////////////////////////////RECORRO EL LISTADO DE RECIBOS PARA MERMA /////////////////////////////
            Cont = My.Forms.FrmRemision2.TDBGridDetalle.RowCount
            i = 0
            Do While Cont > i
                'My.Forms.FrmRemision2.TDBGridDetalle.Row = i
                ODataRowDetalle = DataSet.Tables("ListaRecibosRem").NewRow
                ODataRowDetalle("NumeroRecibo") = "Grupo " & i
                ODataRowDetalle("Merma") = 0
                DataSet.Tables("ListaRecibosRem").Rows.Add(ODataRowDetalle)
                i = i + 1
            Loop
        End If

        '////////////////////////////AHORA RECORRO EL GRID DE LA MERMA PARA VOLVE A PONER LOS MONTOS ////////////////////
        Count = My.Forms.FrmRemision2.TDBGridMerma.RowCount
        i = 0
        Do While Count > i
            Criterios = "NumeroRecibo= '" & My.Forms.FrmRemision2.TDBGridMerma.Item(i)("NumeroRecibo") & "' "
            Buscar_Fila = DataSet.Tables("ListaRecibosRem").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                Posicion = DataSet.Tables("ListaRecibosRem").Rows.IndexOf(Buscar_Fila(0))
                DataSet.Tables("ListaRecibosRem").Rows(Posicion)("Merma") = My.Forms.FrmRemision2.TDBGridMerma.Item(i)("Merma")
            End If

            i = i + 1
        Loop



        My.Forms.FrmRemision2.TDBGridMerma.DataSource = DataSet.Tables("ListaRecibosRem")

        My.Forms.FrmRemision2.SumaGridParcial()

        My.Forms.FrmRemision2.CboTipoRemision.Enabled = False
        Me.Close()
    End Sub
End Class