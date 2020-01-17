Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class ArepRemisionMaquila 
    Public IdRemision As Double
    Public MiConexion As New SqlClient.SqlConnection(Conexion)
    Public i As Double

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, SqlString As String

        '//////////////////////////////////SELECCIONO EL PUNTO INTERMEDIO 3/////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT  Vehiculo.Placa, Marca.NombreMarca, Conductor.Nombre, Conductor.Cedula, LugarAcopio.NomLugarAcopio AS LugarOrigen, LugarAcopio_1.NomLugarAcopio AS LugarDestino, Intermedio.Fecha, Intermedio.FechaSalida,Intermedio.FechaCarga, Intermedio.Orden, Intermedio.IdRemisionPergamino, EmpresaTransporte.NombreEmpresa FROM Conductor INNER JOIN Intermedio ON Conductor.IdConductor = Intermedio.IdConductor INNER JOIN LugarAcopio ON Intermedio.IdOrigen = LugarAcopio.IdLugarAcopio INNER JOIN LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN Vehiculo INNER JOIN Marca ON Vehiculo.IdMarca = Marca.IdMarca ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte  " & _
                    "WHERE (Intermedio.IdRemisionPergamino = " & IdRemision & ") AND (Intermedio.Orden = 2) ORDER BY Intermedio.Orden"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "PIII")
        If Not DataSet.Tables("PIII").Rows.Count = 0 Then
            'Me.TxtEmpTransp3.Text = DataSet.Tables("PIII").Rows(0)("NombreEmpresa")
            'Me.TxtPlaca3.Text = DataSet.Tables("PIII").Rows(0)("Placa")
            'Me.TxtConductor3.Text = DataSet.Tables("PIII").Rows(0)("Nombre")
            'Me.TxtMarca3.Text = DataSet.Tables("PIII").Rows(0)("NombreMarca")
            'Me.TxtCedConductor3.Text = DataSet.Tables("PIII").Rows(0)("Cedula")
            'Me.TxtFechaCarga3.Text = DataSet.Tables("PIII").Rows(0)("Fecha")
            'Me.TxtFechaSalida3.Text = DataSet.Tables("PIII").Rows(0)("FechaSalida")
            'Me.TxtOrigen3.Text = DataSet.Tables("PIII").Rows(0)("LugarOrigen")
            'Me.TxtDestino3.Text = DataSet.Tables("PIII").Rows(0)("LugarDestino")

            Me.LblEmpresaTransporte.Text = DataSet.Tables("PIII").Rows(0)("NombreEmpresa")
            Me.LblPlaca.Text = DataSet.Tables("PIII").Rows(0)("Placa")
            Me.LblConductor.Text = DataSet.Tables("PIII").Rows(0)("Nombre")
            Me.LblMarca.Text = DataSet.Tables("PIII").Rows(0)("NombreMarca")
            Me.LblCedula.Text = DataSet.Tables("PIII").Rows(0)("Cedula")
            Me.LblFechaOrden.Text = DataSet.Tables("PIII").Rows(0)("FechaCarga")
            Me.LblFechaSalida.Text = DataSet.Tables("PIII").Rows(0)("FechaSalida")
            Me.LblOrigen.Text = DataSet.Tables("PIII").Rows(0)("LugarOrigen")
            Me.LblDestino.Text = DataSet.Tables("PIII").Rows(0)("LugarDestino")

            'Me.LblP3.Visible = True
            'Me.LblCantSaco3.Visible = True
            'Me.LblCantSaco33.Visible = True
            'Me.LblPBRecepcion3.Visible = True
            'Me.LblPBRemision3.Visible = True

            Me.LblP2.Visible = True
            Me.LblCantSaco2.Visible = True
            Me.LblCantSaco22.Visible = True
            Me.LblPBRecepcion2.Visible = True
            Me.LblPBRemision2.Visible = True

            Me.LblP1.Visible = True
            Me.LblCantSaco1.Visible = True
            Me.LblCantSaco11.Visible = True
            Me.LblPBRecepcion1.Visible = True
            Me.LblPBRemision1.Visible = True

            Exit Sub
        End If


        '//////////////////////////////////SELECCIONO EL PRIMER PUNTO INTERMEDIO 2/////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT  Vehiculo.Placa, Marca.NombreMarca, Conductor.Nombre, Conductor.Cedula, LugarAcopio.NomLugarAcopio AS LugarOrigen, LugarAcopio_1.NomLugarAcopio AS LugarDestino, Intermedio.Fecha, Intermedio.FechaSalida, Intermedio.FechaCarga, Intermedio.Orden, Intermedio.IdRemisionPergamino, EmpresaTransporte.NombreEmpresa FROM Conductor INNER JOIN Intermedio ON Conductor.IdConductor = Intermedio.IdConductor INNER JOIN LugarAcopio ON Intermedio.IdOrigen = LugarAcopio.IdLugarAcopio INNER JOIN LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN Vehiculo INNER JOIN Marca ON Vehiculo.IdMarca = Marca.IdMarca ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte  " & _
                    "WHERE (Intermedio.IdRemisionPergamino = " & IdRemision & ") AND (Intermedio.Orden = 1) ORDER BY Intermedio.Orden"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "PII")
        If Not DataSet.Tables("PII").Rows.Count = 0 Then
            'Me.TxtEmpTransp2.Text = DataSet.Tables("PII").Rows(0)("NombreEmpresa")
            'Me.TxtPlaca2.Text = DataSet.Tables("PII").Rows(0)("Placa")
            'Me.TxtConductor2.Text = DataSet.Tables("PII").Rows(0)("Nombre")
            'Me.TxtMarca2.Text = DataSet.Tables("PII").Rows(0)("NombreMarca")
            'Me.TxtCedConductor2.Text = DataSet.Tables("PII").Rows(0)("Cedula")
            'Me.TxtFechaCarga2.Text = DataSet.Tables("PII").Rows(0)("Fecha")
            'Me.TxtFechaSalida2.Text = DataSet.Tables("PII").Rows(0)("FechaSalida")
            'Me.TxtOrigen2.Text = DataSet.Tables("PII").Rows(0)("LugarOrigen")
            'Me.TxtDestino2.Text = DataSet.Tables("PII").Rows(0)("LugarDestino")

            Me.LblEmpresaTransporte.Text = DataSet.Tables("PII").Rows(0)("NombreEmpresa")
            Me.LblPlaca.Text = DataSet.Tables("PII").Rows(0)("Placa")
            Me.LblConductor.Text = DataSet.Tables("PII").Rows(0)("Nombre")
            Me.LblMarca.Text = DataSet.Tables("PII").Rows(0)("NombreMarca")
            Me.LblCedula.Text = DataSet.Tables("PII").Rows(0)("Cedula")
            Me.LblFechaOrden.Text = DataSet.Tables("PII").Rows(0)("FechaCarga")
            Me.LblFechaSalida.Text = DataSet.Tables("PII").Rows(0)("FechaSalida")
            Me.LblOrigen.Text = DataSet.Tables("PII").Rows(0)("LugarOrigen")
            Me.LblDestino.Text = DataSet.Tables("PII").Rows(0)("LugarDestino")

            Me.LblP2.Visible = True
            Me.LblCantSaco2.Visible = True
            Me.LblCantSaco22.Visible = True
            Me.LblPBRecepcion2.Visible = True
            Me.LblPBRemision2.Visible = True

            Me.LblP1.Visible = True
            Me.LblCantSaco1.Visible = True
            Me.LblCantSaco11.Visible = True
            Me.LblPBRecepcion1.Visible = True
            Me.LblPBRemision1.Visible = True

            Exit Sub
        End If

        '//////////////////////////////////SELECCIONO EL PRIMER PUNTO INTERMEDIO 1/////////////////////////////////////////////////////////////////////////
        SqlString = "SELECT DISTINCT  Vehiculo.Placa, Marca.NombreMarca, Conductor.Nombre, Conductor.Cedula, LugarAcopio.NomLugarAcopio AS LugarOrigen, LugarAcopio_1.NomLugarAcopio AS LugarDestino, Intermedio.Fecha, Intermedio.FechaCarga, Intermedio.FechaSalida, Intermedio.Orden, Intermedio.IdRemisionPergamino, EmpresaTransporte.NombreEmpresa FROM Conductor INNER JOIN Intermedio ON Conductor.IdConductor = Intermedio.IdConductor INNER JOIN LugarAcopio ON Intermedio.IdOrigen = LugarAcopio.IdLugarAcopio INNER JOIN LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN Vehiculo INNER JOIN Marca ON Vehiculo.IdMarca = Marca.IdMarca ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte  " & _
                    "WHERE (Intermedio.IdRemisionPergamino = " & IdRemision & ") AND (Intermedio.Orden = 0) ORDER BY Intermedio.Orden"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "PI")
        If Not DataSet.Tables("PI").Rows.Count = 0 Then
            'Me.TxtEmpTransp1.Text = DataSet.Tables("PI").Rows(0)("NombreEmpresa")
            'Me.TxtPlaca1.Text = DataSet.Tables("PI").Rows(0)("Placa")
            'Me.TxtConductor1.Text = DataSet.Tables("PI").Rows(0)("Nombre")
            'Me.TxtMarca1.Text = DataSet.Tables("PI").Rows(0)("NombreMarca")
            'Me.TxtCedConductor1.Text = DataSet.Tables("PI").Rows(0)("Cedula")
            'Me.TxtFechaCarga1.Text = DataSet.Tables("PI").Rows(0)("Fecha")
            'Me.TxtFechaSalida1.Text = DataSet.Tables("PI").Rows(0)("FechaSalida")
            'Me.TxtOrigen1.Text = DataSet.Tables("PI").Rows(0)("LugarOrigen")
            'Me.TxtDestino1.Text = DataSet.Tables("PI").Rows(0)("LugarDestino")

            Me.LblEmpresaTransporte.Text = DataSet.Tables("PI").Rows(0)("NombreEmpresa")
            Me.LblPlaca.Text = DataSet.Tables("PI").Rows(0)("Placa")
            Me.LblConductor.Text = DataSet.Tables("PI").Rows(0)("Nombre")
            Me.LblMarca.Text = DataSet.Tables("PI").Rows(0)("NombreMarca")
            Me.LblCedula.Text = DataSet.Tables("PI").Rows(0)("Cedula")
            Me.LblFechaOrden.Text = DataSet.Tables("PI").Rows(0)("FechaCarga")
            Me.LblFechaSalida.Text = DataSet.Tables("PI").Rows(0)("FechaSalida")
            Me.LblOrigen.Text = DataSet.Tables("PI").Rows(0)("LugarOrigen")
            Me.LblDestino.Text = DataSet.Tables("PI").Rows(0)("LugarDestino")

            Me.LblP1.Visible = True
            Me.LblCantSaco1.Visible = True
            Me.LblCantSaco11.Visible = True
            Me.LblPBRecepcion1.Visible = True
            Me.LblPBRemision1.Visible = True
            Exit Sub
        End If

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim Sqlstring As String, CantidadBascula As Double, PesoBascula As Double, TipoPesada As String, Sql As String, Tara As Double
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter, Numero As String

        Numero = Me.TxtNumeroRecibo.Text

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
        Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = " & Me.IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
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
        Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = " & Me.IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
            Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
        End If

        Me.TxtCantSacos11.Text = Format(CantidadBascula, "##,##0")
        Me.TxtPesoNeto1.Text = Format(PesoBascula, "##,##0.00")
        DataSet.Tables("Consulta").Reset()

        '//////////////////////////////////SELECCIONO EL PRIMER PUNTO INTERMEDIO 1/////////////////////////////////////////////////////////////////////////
        Sqlstring = "SELECT DISTINCT  Vehiculo.Placa, Marca.NombreMarca, Conductor.Nombre, Conductor.Cedula, LugarAcopio.NomLugarAcopio AS LugarOrigen, LugarAcopio_1.NomLugarAcopio AS LugarDestino, Intermedio.Fecha, Intermedio.FechaSalida, Intermedio.Orden, Intermedio.IdRemisionPergamino, EmpresaTransporte.NombreEmpresa FROM Conductor INNER JOIN Intermedio ON Conductor.IdConductor = Intermedio.IdConductor INNER JOIN LugarAcopio ON Intermedio.IdOrigen = LugarAcopio.IdLugarAcopio INNER JOIN LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN Vehiculo INNER JOIN Marca ON Vehiculo.IdMarca = Marca.IdMarca ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte  " & _
                    "WHERE (Intermedio.IdRemisionPergamino = " & IdRemision & ") AND (Intermedio.Orden = 0) ORDER BY Intermedio.Orden"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "PI")
        If DataSet.Tables("PI").Rows.Count = 0 Then
            Me.TxtCantSacos1.Visible = False
            Me.TxtPesoBruto1.Visible = False
            Me.TxtCantSacos11.Visible = False
            Me.TxtPesoNeto1.Visible = False

            Me.LblP1.Visible = False
            Me.LblCantSaco1.Visible = False
            Me.LblCantSaco11.Visible = False
            Me.LblPBRecepcion1.Visible = False
            Me.LblPBRemision1.Visible = False
        End If


        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////BUSCO LA PESADA PARA EL SEGUNDO PUNTO INTERMEDIO ///////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        CantidadBascula = 0
        PesoBascula = 0
        TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 1 & "-P1"
        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
        Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
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
        Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = '" & IdRemision & "') GROUP BY Cod_Productos, Descripcion_Producto"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
            Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
        End If

        Me.TxtCantSacos22.Text = Format(CantidadBascula, "##,##0")
        Me.TxtPesoNeto2.Text = Format(PesoBascula, "##,##0.00")
        DataSet.Tables("Consulta").Reset()

        '//////////////////////////////////SELECCIONO EL PRIMER PUNTO INTERMEDIO 2/////////////////////////////////////////////////////////////////////////
        Sqlstring = "SELECT DISTINCT  Vehiculo.Placa, Marca.NombreMarca, Conductor.Nombre, Conductor.Cedula, LugarAcopio.NomLugarAcopio AS LugarOrigen, LugarAcopio_1.NomLugarAcopio AS LugarDestino, Intermedio.Fecha, Intermedio.FechaSalida, Intermedio.Orden, Intermedio.IdRemisionPergamino, EmpresaTransporte.NombreEmpresa FROM Conductor INNER JOIN Intermedio ON Conductor.IdConductor = Intermedio.IdConductor INNER JOIN LugarAcopio ON Intermedio.IdOrigen = LugarAcopio.IdLugarAcopio INNER JOIN LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN Vehiculo INNER JOIN Marca ON Vehiculo.IdMarca = Marca.IdMarca ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte  " & _
                    "WHERE (Intermedio.IdRemisionPergamino = " & IdRemision & ") AND (Intermedio.Orden = 1) ORDER BY Intermedio.Orden"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "PII")
        If DataSet.Tables("PII").Rows.Count = 0 Then
            Me.TxtCantSacos2.Visible = False
            Me.TxtPesoBruto2.Visible = False
            Me.TxtCantSacos22.Visible = False
            Me.TxtPesoNeto2.Visible = False

            Me.LblP2.Visible = False
            Me.LblCantSaco2.Visible = False
            Me.LblCantSaco22.Visible = False
            Me.LblPBRecepcion2.Visible = False
            Me.LblPBRemision2.Visible = False
        End If



        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '/////////////////////////////////////////////////////////////////////BUSCO LA PESADA PARA EL TERCER PUNTO INTERMEDIO ///////////////////////
        '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        CantidadBascula = 0
        PesoBascula = 0
        TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 2 & "-P1"
        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
        Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
            Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
        End If

        Me.TxtCantSacos3.Text = Format(CantidadBascula, "##,##0")
        Me.TxtPesoBruto3.Text = Format(PesoBascula, "##,##0.00")
        DataSet.Tables("Consulta").Reset()

        CantidadBascula = 0
        PesoBascula = 0
        TipoPesada = "Rec" & Numero & "-N" & i & "-D" & 2 & "-P2"
        '/////////////////////////////////////BUSCO SI EXISTEN PESADAS PARA LOS RECIBOS //////////////////////////
        'sql = "SELECT id_Eventos AS Linea, Cod_Productos, Descripcion_Producto, Calidad, Estado, Cantidad, PesoKg, Tara, PesoNetoLb, PesoNetoKg, QQ AS Saco, NumeroRemision, Fecha, TipoRemision FROM Detalle_Pesadas WHERE  (NumeroRemision = '" & FrmRemision2.TxtNumeroRemision.Text & "') AND (Fecha = CONVERT(DATETIME, '" & Format(FrmRemision2.DTPRemFechCarga.Value, "yyyy-MM-dd") & "', 102)) AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND (TipoPesada = '" & TipoPesada & "')"
        Sql = "SELECT  Cod_Productos, Descripcion_Producto, SUM(Cantidad) AS Cantidad, SUM(PesoKg) AS PesoKg, SUM(Tara) AS Tara, SUM(PesoNetoLb) AS PesoNetoLb, SUM(PesoNetoKg) AS PesoNetoKg, SUM(QQ) AS QQ FROM Detalle_Pesadas WHERE  (TipoPesada = '" & TipoPesada & "') AND (TipoRemision = '" & FrmRemision2.CboTipoRemision.Text & "') AND  (IdRemisionPergamino = " & IdRemision & ") GROUP BY Cod_Productos, Descripcion_Producto"
        DataAdapter = New SqlClient.SqlDataAdapter(Sql, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")
        If Not DataSet.Tables("Consulta").Rows.Count = 0 Then
            PesoBascula = DataSet.Tables("Consulta").Rows(0)("PesoNetoKg")
            CantidadBascula = DataSet.Tables("Consulta").Rows(0)("QQ")
            Tara = DataSet.Tables("Consulta").Rows(0)("Tara")
        End If

        Me.TxtCantSacos33.Text = Format(CantidadBascula, "##,##0")
        Me.TxtPesoNeto3.Text = Format(PesoBascula, "##,##0.00")
        DataSet.Tables("Consulta").Reset()


        '//////////////////////////////////SELECCIONO EL PRIMER PUNTO INTERMEDIO 3/////////////////////////////////////////////////////////////////////////
        Sqlstring = "SELECT DISTINCT  Vehiculo.Placa, Marca.NombreMarca, Conductor.Nombre, Conductor.Cedula, LugarAcopio.NomLugarAcopio AS LugarOrigen, LugarAcopio_1.NomLugarAcopio AS LugarDestino, Intermedio.Fecha, Intermedio.FechaSalida, Intermedio.Orden, Intermedio.IdRemisionPergamino, EmpresaTransporte.NombreEmpresa FROM Conductor INNER JOIN Intermedio ON Conductor.IdConductor = Intermedio.IdConductor INNER JOIN LugarAcopio ON Intermedio.IdOrigen = LugarAcopio.IdLugarAcopio INNER JOIN LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN Vehiculo INNER JOIN Marca ON Vehiculo.IdMarca = Marca.IdMarca ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte  " & _
                    "WHERE (Intermedio.IdRemisionPergamino = " & IdRemision & ") AND (Intermedio.Orden = 2) ORDER BY Intermedio.Orden"
        DataAdapter = New SqlClient.SqlDataAdapter(Sqlstring, MiConexion)
        DataAdapter.Fill(DataSet, "PIII")
        If DataSet.Tables("PIII").Rows.Count = 0 Then
            Me.TxtCantSacos3.Visible = False
            Me.TxtPesoBruto3.Visible = False
            Me.TxtCantSacos33.Visible = False
            Me.TxtPesoNeto3.Visible = False

            Me.LblP3.Visible = False
            Me.LblCantSaco3.Visible = False
            Me.LblCantSaco33.Visible = False
            Me.LblPBRecepcion3.Visible = False
            Me.LblPBRemision3.Visible = False
        End If


        i = i + 1
    End Sub

    Private Sub ArepRemisionMaquila_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        i = 0
        Me.LblCosecha.Text = FrmRemision2.Cosecha
    End Sub
End Class
