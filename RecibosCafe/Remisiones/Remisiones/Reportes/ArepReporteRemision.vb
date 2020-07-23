Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepReporteRemision 
    Public IdRemision As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public i As Double

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        'Dim Sqlstring As String, CantidadBascula As Double, PesoBascula As Double, TipoPesada As String, Sql As String, Tara As Double
        'Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Numero As String
        'Dim NumeroRecibo As String, CadenaDiv() As String, Max As Double, j As Double, MermaTransitoPI As Double = 0, PesoBrutoRemision As Double = 0, PesoBrutoIni1 As Double, PesoBrutoFin1 As Double
        'Dim PesoBrutoIni2 As Double = 0, PesoBrutoFin2 As Double = 0, PesoNetoRecibo As Double = 0, PesoNetoPII As Double

        'Numero = Me.TxtNumeroRecibo.Text
        'IdRemision = Me.TxtIdRemision.Text

        'PesoBrutoRemision = 0
        'If Me.TxtPesoBrutoRemision.Text <> "" Then
        '    PesoBrutoRemision = Me.TxtPesoBrutoRemision.Text
        'End If

        'PesoNetoRecibo = 0
        'If Me.TxtPesoNetoRecibos.Text <> "" Then
        '    PesoNetoRecibo = Me.TxtPesoNetoRecibos.Text
        'End If

        'Me.TxtCont.Text = i + 1

        'If Me.TxtProductor.Text = "EXPASA" Then
        '    '/////////////////////////////QUITO EL NUMERO DE LA LOCALIDAD AL NUMERO DE RECIBO ///////////////////////////
        '    NumeroRecibo = Trim(Replace(Me.TxtNumeroRecibos.Text, ",", "-"))
        '    NumeroRecibo = Trim(Replace(NumeroRecibo, "Ø", ""))
        '    CadenaDiv = NumeroRecibo.Split("-")
        '    Max = UBound(CadenaDiv)
        '    NumeroRecibo = ""
        '    For j = 0 To Max
        '        If Len(CadenaDiv(j)) > 4 Then              '/////////////////////////MODIFICADO EL 25-11-2019 A SOLICITUD DE MARIELO ///////////////////

        '            If NumeroRecibo = "" Then '//////////////////////ESTE ES EL RANGO PARA EL PRIMER RECIBO /////////////
        '                NumeroRecibo = CDbl(CadenaDiv(j))
        '            Else                              'If j = Max Then  '//////////////ESTE ES EL RANGO PARA EL ULTIMO RECIBO ///////////////////
        '                NumeroRecibo = NumeroRecibo & "," & CDbl(CadenaDiv(j))
        '            End If

        '        End If
        '    Next
        '    Me.TxtListadoRecibos.Text = NumeroRecibo
        'Else
        '    Me.TxtListadoRecibos.Text = Me.TxtNumeroRecibo.Text
        'End If




        'If IdRemision <> 0 Then
        '    Me.LblNumero.Text = CDbl(Mid(Numero, 5, Len(Numero) - 1))

        '    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '/////////////////////////////////////////////////////////////////////BUSCO LA PESADA PARA EL PRIMER PUNTO INTERMEDIO ///////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '    Me.TxtCont.Text = i + 1
        '    CantidadBascula = 0
        '    PesoBascula = 0
        '    'Rec208-000004-N0-D0-P1
        '    TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 0 & "-P1"
        '    '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
        '    Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = " & Me.IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
        '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '    DataAdapter.Fill(DataSet, "Consulta")
        '    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
        '        PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
        '        CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
        '        Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
        '    End If

        '    Me.TxtCantSacos1.Text = Format(CantidadBascula, "##,##0")
        '    Me.TxtPesoBruto1.Text = Format(PesoBascula, "##,##0.00")
        '    PesoBrutoIni1 = Format(PesoBascula, "##,##0.00")
        '    Me.TxtMermaTransitoPI.Text = Format(PesoBrutoIni1 - PesoBrutoRemision, "##,##0.00")
        '    DataSet.Tables("Consulta").Reset()




        '    CantidadBascula = 0
        '    PesoBascula = 0
        '    Tara = 0
        '    TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 0 & "-P2"
        '    '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
        '    'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
        '    Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "')  AND  (IdRemisionPergamino = " & Me.IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
        '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '    DataAdapter.Fill(DataSet, "Consulta")
        '    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
        '        PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
        '        CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
        '        Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
        '    End If

        '    'Me.TxtCantSacos11.Text = Format(CantidadBascula, "##,##0")
        '    PesoBrutoFin1 = Format(PesoBascula, "##,##0.00")
        '    Me.TxtPesoNeto1.Text = Format(PesoBrutoFin1, "##,##0.00")
        '    Me.TxtMermaBodegaPI.Text = Format(PesoBrutoFin1 - PesoBrutoIni1, "##,##0.00")
        '    DataSet.Tables("Consulta").Reset()


        '    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '/////////////////////////////////////////////////////////////////////BUSCO LA PESADA PARA EL SEGUNDO PUNTO INTERMEDIO ///////////////////////
        '    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        '    CantidadBascula = 0
        '    PesoBascula = 0
        '    Tara = 0
        '    TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 1 & "-P1"
        '    '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
        '    Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
        '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '    DataAdapter.Fill(DataSet, "Consulta")
        '    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
        '        PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
        '        CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
        '        Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
        '    End If

        '    PesoBrutoIni2 = Format(PesoBascula, "##,##00")
        '    Me.TxtTaraPlanta.Text = Format(Tara, "##,##0")
        '    Me.TxtCantSacos2.Text = Format(CantidadBascula, "##,##0")
        '    Me.TxtPesoBruto2.Text = Format(PesoBrutoIni2, "##,##0.00")
        '    Me.TxtPesoNeto2.Text = Format(PesoBrutoIni2 - Tara, "##,##0.00")
        '    PesoNetoPII = Format(PesoBrutoIni2 - Tara, "##,##0.00")

        '    DataSet.Tables("Consulta").Reset()

        '    CantidadBascula = 0
        '    PesoBascula = 0
        '    TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 1 & "-P2"
        '    '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
        '    Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = '" & IdRemision & "') GROUP BY Cod_Productos, Descripcion_Producto"
        '    DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        '    DataAdapter.Fill(DataSet, "Consulta")
        '    If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
        '        PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
        '        CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
        '        Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
        '    End If

        '    PesoBrutoFin2 = Format(PesoBascula, "##,##00")
        '    Me.TxtMermaTransitoPII.Text = Format(PesoBrutoIni2 - PesoBrutoRemision, "##,##0.00")
        '    Me.TxtMermaBodegaPII.Text = Format(PesoNetoRecibo - PesoNetoPII, "##,##0.00")
        '    DataSet.Tables("Consulta").Reset()

        'End If

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub ArepReporteRemision_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        i = 0

        Me.LblFecha.Text = "Desde: " & Format(FrmReportes.DTPFechaInicial.Value, "dd/MM/yyyy") & " Hasta: " & Format(FrmReportes.DTPFechaFinal.Value, "dd/MM/yyyy")
        Me.LblModalidad.Text = FrmReportes.CboModalidad.Text
        Me.LblLocalidad.Text = FrmReportes.CboLocalidad.Text
    End Sub
End Class
