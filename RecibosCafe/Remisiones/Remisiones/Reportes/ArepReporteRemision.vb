Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepReporteRemision 
    Public IdRemision As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public i As Double

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Sqlstring As String, CantidadBascula As Double, PesoBascula As Double, TipoPesada As String, Sql As String, Tara As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Numero As String

        Numero = Me.TxtNumeroRecibo.Text
        IdRemision = Me.TxtIdRemision.Text

        If IdRemision <> 0 Then
            Me.LblNumero.Text = CDbl(Mid(Numero, 5, Len(Numero) - 1))

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////BUSCO LA PESADA PARA EL PRIMER PUNTO INTERMEDIO ///////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Me.TxtCont.Text = i + 1
            CantidadBascula = 0
            PesoBascula = 0
            'Rec208-000004-N0-D0-P1
            TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 0 & "-P1"
            '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
            Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = " & Me.IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
            End If

            Me.TxtCantSacos1.Text = Format(CantidadBascula, "##,##0")
            Me.TxtPesoBruto1.Text = Format(PesoBascula, "##,##0.00")
            DataSet.Tables("Consulta").Reset()

            CantidadBascula = 0
            PesoBascula = 0
            TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 0 & "-P2"
            '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
            'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
            Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "')  AND  (IdRemisionPergamino = " & Me.IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
            End If

            'Me.TxtCantSacos11.Text = Format(CantidadBascula, "##,##0")
            Me.TxtPesoNeto1.Text = Format(PesoBascula, "##,##0.00")
            DataSet.Tables("Consulta").Reset()


            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////BUSCO LA PESADA PARA EL SEGUNDO PUNTO INTERMEDIO ///////////////////////
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            CantidadBascula = 0
            PesoBascula = 0
            TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 1 & "-P1"
            '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
            Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
            End If

            Me.TxtCantSacos2.Text = Format(CantidadBascula, "##,##0")
            Me.TxtPesoBruto2.Text = Format(PesoBascula, "##,##0.00")
            DataSet.Tables("Consulta").Reset()

            CantidadBascula = 0
            PesoBascula = 0
            TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 1 & "-P2"
            '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
            Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND  (IdRemisionPergamino = '" & IdRemision & "') GROUP BY Cod_Productos, Descripcion_Producto"
            DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
            DataAdapter.Fill(DataSet, "Consulta")
            If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
                PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
                CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
                Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
            End If

            'Me.TxtCantSacos22.Text = Format(CantidadBascula, "##,##0")
            Me.TxtPesoNeto2.Text = Format(PesoBascula, "##,##0.00")
            DataSet.Tables("Consulta").Reset()

        End If

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub
End Class
