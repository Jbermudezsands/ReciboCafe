Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FrmConsultaReporte
    Public MiConexion As New SqlClient.SqlConnection(Conexion), DataSet As New DataSet
    Private Sub FrmConsultaReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String = "SELECT Cod_proveedor, Nombre_Proveedor FROM Proveedor"
        Dim DataAdapter As New SqlClient.SqlDataAdapter(Sql, MiConexion)
        Dim TablaConsulta As New DataTable
        DataAdapter.Fill(TablaConsulta)
        If Not TablaConsulta.Rows.Count = 0 Then
            Me.cboProveedor.DataSource = TablaConsulta
        End If

        Me.cboProveedor.Columns(0).Caption = "Codigo"
        Me.cboProveedor.Columns(1).Caption = "Proveedor"
        Me.cboProveedor.DropDownWidth = 230
        Me.cboProveedor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
    End Sub

    Private Sub cboProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.TextChanged
        Dim SqlProveedor As String = "SELECT  * FROM Proveedor  WHERE (Cod_Proveedor = '" & Me.cboProveedor.Text & "')"
        Dim DataAdapter As New SqlClient.SqlDataAdapter(SqlProveedor, MiConexion)
        Dim TablaConsulta As New DataTable
        DataAdapter.Fill(TablaConsulta)
        If Not TablaConsulta.Rows.Count = 0 Then
            Me.txtProveedor.Value = TablaConsulta.Rows(0)("Nombre_Proveedor")
        Else
            Me.txtProveedor.Value = ""
        End If
    End Sub

    Private Sub cboProveedor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.DoubleClick
        Quien = "CodigoProveedorConsultaTrazabilidad"
        My.Forms.FrmConsultas.ShowDialog()
        Me.cboProveedor.Text = My.Forms.FrmConsultas.Codigo
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim SqlString As String
        Dim Adapter As New SqlDataAdapter
        Dim FechaInicio As Date, FechaFin As Date, Iposicion As Double, Registros As Double
        Dim LugarAcopio As String, NumeroBoleta As String, CantidadTraslado As Double
        Dim oDataRow As DataRow, Placa As String, FechaCompra As Date, HoraCargaCamion As Date, HoraSalidaCamion As Date
        Dim FechaIntermedio As Date, FechaEntradaBeneficio As Date, FechaBascula As Date, FechaDescarga As Date, FechaSalida As Date
        Dim TipoTrasnporte As String = "", IdTransporte As String, CodCarga As String, NumeroRecepcion As String, FechaExistencia As Date
        Dim IdLugarAcopio As Double, CodigoRemision As Double = -1, IdCosecha As Double, NumeroRemision As String, FechaEntradaBeneficioRemision As Date
        Dim FechaEsperaDespacho As Date, FechaSalidaAgencia As Date, LocalidadIntermedio As String, TiempoTotal As Double
        Dim IdRemisionPergamino As Double, j As Double, count As Double, FechaSalidaBeneficio As Date, FechaEntradaCheckPoint As Date, FechaSalidaCheckPoint As Date
        DataSet.Reset()

        'EmpresaTransporte.NombreRepresentante AS NumeroRecibos
        SqlString = "SELECT DISTINCT EmpresaTransporte.NombreEmpresa, EmpresaTransporte.NombreRepresentante AS Conductor, EmpresaTransporte.NombreRepresentante AS Placa, EmpresaTransporte.NombreRepresentante AS AgenciaAcopio, EmpresaTransporte.Telefono AS CantidadTraslado, IndiceCarga.Fecha AS FechaEntradaBeneficio, IndiceCarga.Fecha AS FechaCargaACA, IndiceCarga.Fecha AS FechaEsperaDespacho, IndiceCarga.Fecha AS FechaSalidaAgencia,EmpresaTransporte.NombreEmpresa As NumeroRemision, EmpresaTransporte.NombreEmpresa As NumeroBoleta,  EmpresaTransporte.NombreEmpresa As LocalidadIntermedio, IndiceCarga.Fecha AS FechaIntermedio, EmpresaTransporte.NombreEmpresa As LocalidadPI, EmpresaTransporte.NombreEmpresa As NombreEmpresaPI ,EmpresaTransporte.NombreEmpresa As ConductorPI, EmpresaTransporte.NombreEmpresa As PlacaPI, EmpresaTransporte.NombreEmpresa As CantidadTrasladoPI, IndiceCarga.Fecha AS FechaEntradaBeneficioPI, IndiceCarga.Fecha AS FechaCargaACAPI, IndiceCarga.Fecha AS FechaEsperaDespachoPI, IndiceCarga.Fecha AS FechaSalidaPI, EmpresaTransporte.NombreEmpresa As NumeroRemisionPI, EmpresaTransporte.NombreEmpresa As NumeroBoletaPI, IndiceCarga.Fecha AS FechaEntradaBeneficio, IndiceCarga.Fecha AS FechaBascula, IndiceCarga.Fecha AS FechaDescargaBeneficio, IndiceCarga.Fecha AS FechaSalidaBeneficio, EmpresaTransporte.Telefono AS TiempoPosicionamiento1, EmpresaTransporte.Telefono AS TiempoCarga1, EmpresaTransporte.Telefono AS TiempoBodega1, EmpresaTransporte.Telefono AS TiempoTransito1, EmpresaTransporte.Telefono AS TiempoPosicionamiento2, EmpresaTransporte.Telefono AS TiempoCarga2, EmpresaTransporte.Telefono AS TiempoBodega2, EmpresaTransporte.Telefono AS TiempoTransito2, EmpresaTransporte.Telefono AS HoraEspera, EmpresaTransporte.Telefono AS TiempoDescarga, EmpresaTransporte.Telefono AS TiempoTotal FROM IndiceCarga LEFT OUTER JOIN  EmpresaTransporte INNER JOIN VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo ON IndiceCarga.Placa = Vehiculo.Placa  WHERE  (IndiceCarga.Fecha BETWEEN CONVERT(DATETIME, '2018-03-20 00:00:00', 102) AND CONVERT(DATETIME, '2018-03-26 23:59:00', 102)) AND (IndiceCarga.CodCarga = N'-100000')"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Reporte")

        SqlString = "SELECT Cosecha.* FROM Cosecha WHERE (activo = 1)"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Cosecha")
        If DataSet.Tables("Cosecha").Rows.Count <> 0 Then
            IdCosecha = DataSet.Tables("Cosecha").Rows(0)("IdCosecha")
        Else
            IdCosecha = 0
        End If

        FechaInicio = Format(Me.dtpFechaInicio.Value, "yyyy-MM-dd") & " 00:00:00"
        FechaFin = Format(Me.dtpFechaFin.Value, "yyyy-MM-dd") & " 23:59:00"

        'SqlString = "SELECT DISTINCT EmpresaTransporte.NombreEmpresa, IndiceCarga.IdTransporte, IndiceCarga.IdLugarAcopio, LugarAcopio.NomLugarAcopio, IndiceCarga.CodCarga, DetalleCarga.NumeroRecepcion, IndiceCarga.Fecha as FechaCarga,  IndiceCarga.Placa FROM IndiceCarga INNER JOIN  DetalleCarga ON IndiceCarga.CodCarga = DetalleCarga.CodCarga AND IndiceCarga.IdLugarAcopio = DetalleCarga.IdLugarAcopio LEFT OUTER JOIN  LugarAcopio ON IndiceCarga.IdLugarAcopio = LugarAcopio.IdLugarAcopio LEFT OUTER JOIN  EmpresaTransporte INNER JOIN  VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo ON IndiceCarga.Placa = Vehiculo.Placa  " & _
        '     "WHERE (IndiceCarga.Fecha BETWEEN CONVERT(DATETIME, '" & Format(FechaInicio, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & " 23:59:00', 102))"

        SqlString = "SELECT DISTINCT EmpresaTransporte.NombreEmpresa, RemisionPergamino.Codigo AS NumeroRemsion, MAX(RemisionPergamino.Numero_Boleta) AS Numero_Boleta, MAX(Conductor.Nombre) AS Conductor, MAX(Vehiculo.Placa) AS Placa, MAX(DetalleRemisionPergamino.Codigo) AS NumeroRecibos, SUM(DetalleRemisionPergamino.CantidadSacos) AS CantidadSacos, MAX(RemisionPergamino.FechaCarga) AS FechaCarga, MAX(LugarAcopio.NomLugarAcopio) AS NomLugarAcopio, RemisionPergamino.IdRemisionPergamino,EmpresaTransporte.IdEmpresaTransporte FROM  RemisionPergamino INNER JOIN Conductor ON RemisionPergamino.IdConductor = Conductor.IdConductor INNER JOIN EmpresaTransporte ON RemisionPergamino.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON RemisionPergamino.IdVehiculo = Vehiculo.IdVehiculo INNER JOIN DetalleRemisionPergamino ON RemisionPergamino.IdRemisionPergamino = DetalleRemisionPergamino.IdRemisionPergamino INNER JOIN LugarAcopio ON RemisionPergamino.IdLugarAcopio = LugarAcopio.IdLugarAcopio GROUP BY EmpresaTransporte.NombreEmpresa, RemisionPergamino.Codigo, RemisionPergamino.IdRemisionPergamino,  EmpresaTransporte.IdEmpresaTransporte HAVING (MAX(RemisionPergamino.FechaCarga) BETWEEN CONVERT(DATETIME, '" & Format(FechaInicio, "yyyy-MM-dd") & " 00:00:00', 102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & " 23:59:59', 102)) ORDER BY MAX(Conductor.Nombre)"
        Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        Adapter.Fill(DataSet, "Consulta")

        If DataSet.Tables("Consulta").Rows.Count <= 0 Then
            MessageBox.Show("No Existen Registros, para exportar", "Sistema de Recepción", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Registros = DataSet.Tables("Consulta").Rows.Count
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Maximum = Registros
        Me.ProgressBar1.Value = 0
        Iposicion = 0


        Do While Registros > Iposicion

            'NumeroRecepcion = DataSet.Tables("Consulta").Rows(Iposicion)("NumeroRecepcion")
            '
            'CodCarga = DataSet.Tables("Consulta").Rows(Iposicion)("CodCarga")
            'IdLugarAcopio = DataSet.Tables("Consulta").Rows(Iposicion)("IdLugarAcopio")

            NumeroRemision = DataSet.Tables("Consulta").Rows(Iposicion)("NumeroRemsion")
            HoraCargaCamion = DataSet.Tables("Consulta").Rows(Iposicion)("FechaCarga")
            NumeroBoleta = DataSet.Tables("Consulta").Rows(Iposicion)("Numero_Boleta")
            Placa = DataSet.Tables("Consulta").Rows(Iposicion)("Placa")
            IdTransporte = DataSet.Tables("Consulta").Rows(Iposicion)("IdEmpresaTransporte")
            IdRemisionPergamino = DataSet.Tables("Consulta").Rows(Iposicion)("IdRemisionPergamino")
            TiempoTotal = 0

            '//////////////////////////////////////////////////////////////////////////////////////////////////////////
            '//////////////////////////////////////////CARGO LOS DATOS DE LA RECEPCION /////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////
            SqlString = "SELECT PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision.IdLugarAcopioChequeo, PuntoRevision.IdCosecha, PuntoRevision.IdLocalidadChequeo, PuntoRevision.IdVehiculo, Cosecha.Codigo, EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, LugarAcopio.CodLugarAcopio FROM PuntoRevision INNER JOIN Cosecha ON PuntoRevision.IdCosecha = Cosecha.IdCosecha INNER JOIN EmpresaTransporte ON PuntoRevision.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                       "WHERE (PuntoRevision.NumeroBoleta BETWEEN  '" & NumeroBoleta & "' AND  '" & NumeroBoleta & "' ) AND (PuntoRevision.IdCosecha = " & IdCosecha & ")ORDER BY PuntoRevision.CodigoRemision DESC"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "ChequePlanta")
            If DataSet.Tables("ChequePlanta").Rows.Count <> 0 Then
                CodigoRemision = DataSet.Tables("ChequePlanta").Rows(0)("CodigoRemision")
            Else
                CodigoRemision = 0
            End If
            DataSet.Tables("ChequePlanta").Reset()

            'SqlString = "SELECT  Recepcion.* FROM Recepcion WHERE (NumeroRecepcion = '" & NumeroRecepcion & "')"
            'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'Adapter.Fill(DataSet, "Recepcion")
            'If DataSet.Tables("Recepcion").Rows.Count <> 0 Then
            '    FechaCompra = DataSet.Tables("Recepcion").Rows(0)("FechaHora")
            'Else
            '    FechaCompra = "01/01/1900 00:00"
            'End If
            'DataSet.Tables("Recepcion").Reset()

            HoraSalidaCamion = Nothing
            SqlString = "SELECT   IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta  FROM Registros WHERE  (TipoRegistro = 'Salida') AND (Placa = '" & Placa & "')  AND (IdTransporte = '" & IdTransporte & "') AND (NumeroBoleta = '" & NumeroBoleta & "')"   'AND (IdLugarAcopio = " & IdLugarAcopio & ")
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "Salida")
            If DataSet.Tables("Salida").Rows.Count <> 0 Then
                HoraSalidaCamion = DataSet.Tables("Salida").Rows(0)("Fecha")
                'NumeroBoleta = DataSet.Tables("Salida").Rows(0)("NumeroBoleta")
            End If
            DataSet.Tables("Salida").Reset()


            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////BUSCO INTERMEDIO CHECKPOINT//////////////////////////////////////////
            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            LocalidadIntermedio = ""
            FechaIntermedio = Nothing
            'SqlString = "SELECT  CodigoRemision, Fecha, IdLugarAcopio, NumeroBoleta, IdEmpresaTransporte, Placa, IdLugarAcopioChequeo, IdCosecha, IdLocalidadChequeo, IdVehiculo  FROM PuntoRevision    " & _
            '            "WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (CodigoRemision = " & CodigoRemision & ") ORDER BY Fecha DESC"
            SqlString = "SELECT  PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision.IdLugarAcopioChequeo, PuntoRevision.IdCosecha, PuntoRevision.IdLocalidadChequeo, PuntoRevision.IdVehiculo, LugarAcopio.NomLugarAcopio AS LocalidaChequeo FROM PuntoRevision INNER JOIN  LugarAcopio ON PuntoRevision.IdLocalidadChequeo = LugarAcopio.IdLugarAcopio  " & _
                        "WHERE   (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (PuntoRevision.CodigoRemision = '" & CodigoRemision & "') ORDER BY PuntoRevision.Fecha DESC"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "Intermedio")
            If DataSet.Tables("Intermedio").Rows.Count <> 0 Then
                FechaIntermedio = DataSet.Tables("Intermedio").Rows(0)("Fecha")
                LocalidadIntermedio = DataSet.Tables("Intermedio").Rows(0)("LocalidaChequeo")
                'CodigoRemision = DataSet.Tables("Intermedio").Rows(0)("CodigoRemision")
            End If
            DataSet.Tables("Intermedio").Reset()



            '----------------------------------------------------------------------------------------------------------------------
            '------------------------------------BUSCO LA ENTRADA AL BENEFICIO DE LA REMISION ------------------------------------
            '----------------------------------------------------------------------------------------------------------------------

            FechaEntradaBeneficioRemision = Nothing
            SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Llegada')"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "CheckPoint")
            If DataSet.Tables("CheckPoint").Rows.Count <> 0 Then
                FechaEntradaBeneficioRemision = DataSet.Tables("CheckPoint").Rows(0)("Fecha")
            End If
            DataSet.Tables("CheckPoint").Reset()

            '----------------------------------------------------------------------------------------------------------------------
            '------------------------------------BUSCO TIEMPO DE ESPERA EN DESAPCHO ------------------------------------
            '----------------------------------------------------------------------------------------------------------------------
            FechaEsperaDespacho = Nothing
            SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Reserva')"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "CheckPoint")
            If DataSet.Tables("CheckPoint").Rows.Count <> 0 Then
                FechaEsperaDespacho = DataSet.Tables("CheckPoint").Rows(0)("Fecha")
            End If
            DataSet.Tables("CheckPoint").Reset()

            '----------------------------------------------------------------------------------------------------------------------
            '------------------------------------BUSCO TIEMPO SALIDA AGENCIA ------------------------------------
            '----------------------------------------------------------------------------------------------------------------------
            FechaSalida = Nothing
            SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Salida')"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "CheckPoint")
            If DataSet.Tables("CheckPoint").Rows.Count <> 0 Then
                FechaSalida = DataSet.Tables("CheckPoint").Rows(0)("Fecha")
            End If
            DataSet.Tables("CheckPoint").Reset()


            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////BUSCO REGISTRO DE BASCULA CHECKPOINT//////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            FechaBascula = Nothing
            SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Bascula')"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "Bascula")
            If DataSet.Tables("Bascula").Rows.Count <> 0 Then
                FechaBascula = DataSet.Tables("Bascula").Rows(0)("Fecha")
            End If
            DataSet.Tables("Bascula").Reset()


            ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ''/////////////////////////////////////////////BUSCO REGISTRO DE SALIDA CHECKPOINT //////////////////////////////////////////
            ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Salida')"
            'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'Adapter.Fill(DataSet, "Salida")
            'If DataSet.Tables("Salida").Rows.Count <> 0 Then
            '    FechaSalida = DataSet.Tables("Salida").Rows(0)("Fecha")
            'Else
            '    FechaSalida = "01/01/1900 00:00"
            'End If
            'DataSet.Tables("Salida").Reset()

            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////BUSCO REGISTRO DE DESCARGA CHECKPOING //////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            FechaDescarga = Nothing
            SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'RegExistencia')"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "Descarga")
            If DataSet.Tables("Descarga").Rows.Count <> 0 Then
                FechaDescarga = DataSet.Tables("Descarga").Rows(0)("Fecha")
            End If
            DataSet.Tables("Descarga").Reset()



            'SqlString = "SELECT  SUM(QQ) AS QQ, NumeroRecepcion FROM Detalle_Recepcion GROUP BY NumeroRecepcion HAVING  (NumeroRecepcion = '" & NumeroRecepcion & "')"
            'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'Adapter.Fill(DataSet, "QQ")
            'If DataSet.Tables("QQ").Rows.Count <> 0 Then
            '    CantidadTraslado = DataSet.Tables("QQ").Rows(0)("QQ")
            'End If
            'DataSet.Tables("QQ").Reset()


            'If Not IsDBNull(DataSet.Tables("Consulta").Rows(Iposicion)("NomLugarAcopio")) Then
            '    LugarAcopio = DataSet.Tables("Consulta").Rows(Iposicion)("NomLugarAcopio")
            'Else
            '    LugarAcopio = "Lacalidad no Existe"
            'End If




            '///////////////////////////////////////////////////////////////////////////////////////////
            '///////////////////////////////BUSCO SI ES INTERMEDIO O DIRECTO //////////////////////////
            '//////////////////////////////////////////////////////////////////////////////////////////////
            'SqlString = "SELECT DISTINCT EmpresaTransporte.NombreEmpresa, IndiceCarga.IdTransporte, IndiceCarga.IdLugarAcopio, LugarAcopio.NomLugarAcopio, IndiceCarga.CodCarga FROM  IndiceCarga LEFT OUTER JOIN LugarAcopio ON IndiceCarga.IdLugarAcopio = LugarAcopio.IdLugarAcopio LEFT OUTER JOIN  EmpresaTransporte INNER JOIN  VehiculoEmpresaTransporte ON EmpresaTransporte.IdEmpresaTransporte = VehiculoEmpresaTransporte.IdEmpresaTransporte INNER JOIN Vehiculo ON VehiculoEmpresaTransporte.IdVehiculo = Vehiculo.IdVehiculo ON IndiceCarga.Placa = Vehiculo.Placa  " & _
            '            "WHERE (IndiceCarga.Fecha BETWEEN CONVERT(DATETIME, '" & Format(FechaInicio, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(FechaFin, "yyyy-MM-dd") & "', 102)) AND  (IndiceCarga.IdTransporte = '" & IdTransporte & "') OR  (IndiceCarga.CodCarga = '" & CodCarga & "')"
            'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            'Adapter.Fill(DataSet, "Contador")
            'If DataSet.Tables("Contador").Rows.Count > 1 Then
            '    TipoTrasnporte = "Intermedio"
            'Else
            '    TipoTrasnporte = "Directo"

            'End If
            'DataSet.Tables("Contador").Reset()



            '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            '/////////////////////////////////////////////REGISTRO DE EXISTENCIA //////////////////////////////////////////
            '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'SqlString = "SELECT Registros.*  FROM Registros  WHERE   (TipoRegistro = 'Reporta') AND (IdTransporte = '" & NumeroRecepcion & "')"
            SqlString = "SELECT  IdReportaExistencia, ReportaExistencia, FechaReporta, IdLugarAcopio, NumeroBoleta FROM Reporta  WHERE  (NumeroBoleta = '" & CodCarga & "')"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "Existencia")
            If DataSet.Tables("Existencia").Rows.Count <> 0 Then
                FechaExistencia = DataSet.Tables("Existencia").Rows(0)("FechaReporta")
            Else
                FechaExistencia = Nothing
            End If
            DataSet.Tables("Existencia").Reset()



            oDataRow = DataSet.Tables("Reporte").NewRow
            oDataRow("NombreEmpresa") = DataSet.Tables("Consulta").Rows(Iposicion)("NombreEmpresa")
            oDataRow("Conductor") = DataSet.Tables("Consulta").Rows(Iposicion)("Conductor")
            oDataRow("Placa") = DataSet.Tables("Consulta").Rows(Iposicion)("Placa")
            oDataRow("AgenciaAcopio") = DataSet.Tables("Consulta").Rows(Iposicion)("NomLugarAcopio")
            'oDataRow("NumeroRecibos") = DataSet.Tables("Consulta").Rows(Iposicion)("NumeroRecibos")
            oDataRow("CantidadTraslado") = DataSet.Tables("Consulta").Rows(Iposicion)("CantidadSacos")
            If Format(FechaEntradaBeneficioRemision, "HH:mm") <> "00:00" Then
                oDataRow("FechaEntradaBeneficio") = Format(FechaEntradaBeneficioRemision, "dd/MM/yyyy HH:mm:ss")
            End If
            If Format(HoraCargaCamion, "HH:mm") <> "00:00" Then
                oDataRow("FechaCargaACA") = Format(HoraCargaCamion, "dd/MM/yyyy HH:mm:ss")
            End If
            If Format(FechaEsperaDespacho, "HH:mm") <> "00:00" Then
                oDataRow("FechaEsperaDespacho") = Format(FechaEsperaDespacho, "dd/MM/yyyy HH:mm:ss")
            End If
            If Format(FechaSalida, "HH:mm") <> "00:00" Then
                oDataRow("FechaSalidaAgencia") = Format(FechaSalida, "dd/MM/yyyy HH:mm")
            End If
            oDataRow("NumeroRemision") = NumeroRemision
            oDataRow("NumeroBoleta") = NumeroBoleta
            oDataRow("LocalidadIntermedio") = LocalidadIntermedio
            If Format(FechaIntermedio, "HH:mm") <> "00:00" Then
                oDataRow("FechaIntermedio") = Format(FechaIntermedio, "dd/MM/yyyy HH:mm:ss")
            End If
            'If Format(FechaExistencia, "HH:mm") <> "00:00" Then
            '    oDataRow("FechaReportaExistencia") = Format(FechaExistencia, "dd/MM/yyyy HH:mm")
            'End If


            'If Format(FechaIntermedio, "HH:mm") <> "00:00" Then
            '    oDataRow("FechaIntermedio") = Format(FechaIntermedio, "dd/MM/yyyy HH:mm")
            'End If

            'If Format(FechaBascula, "HH:mm") <> "00:00" Then
            '    oDataRow("FechaBascula") = Format(FechaBascula, "dd/MM/yyyy HH:mm")
            'End If
            'If Format(FechaDescarga, "HH:mm") <> "00:00" Then
            '    oDataRow("FechaDescargaBeneficio") = Format(FechaDescarga, "dd/MM/yyyy HH:mm")
            'End If
            'If Format(FechaSalida, "HH:mm") <> "00:00" Then
            '    oDataRow("FechaSalidaBeneficio") = Format(FechaSalida, "dd/MM/yyyy HH:mm")
            'End If

            'oDataRow("TiempoBodega") = DateDiff(DateInterval.Minute, FechaCompra, HoraSalidaCamion)
            'oDataRow("Posicionamiento") = DateDiff(DateInterval.Minute, FechaCompra, HoraCargaCamion)
            'oDataRow("TiempoCarga") = DateDiff(DateInterval.Minute, HoraCargaCamion, HoraSalidaCamion)
            'oDataRow("TiempoTransito") = DateDiff(DateInterval.Minute, HoraSalidaCamion, FechaEntradaBeneficio)
            'oDataRow("HoraEspera") = DateDiff(DateInterval.Minute, FechaEntradaBeneficio, FechaBascula)
            'oDataRow("TiempoDescarga") = DateDiff(DateInterval.Minute, FechaBascula, FechaDescarga)
            'oDataRow("TiempoTotal") = DateDiff(DateInterval.Minute, FechaCompra, HoraSalidaCamion) + DateDiff(DateInterval.Minute, HoraSalidaCamion, FechaEntradaBeneficio) + DateDiff(DateInterval.Minute, FechaEntradaBeneficio, FechaBascula) + DateDiff(DateInterval.Minute, FechaBascula, FechaDescarga)
            'oDataRow("TiempoTotal2") = DateDiff(DateInterval.Minute, FechaCompra, HoraCargaCamion) + DateDiff(DateInterval.Minute, HoraCargaCamion, HoraSalidaCamion) + DateDiff(DateInterval.Minute, HoraSalidaCamion, FechaEntradaBeneficio) + DateDiff(DateInterval.Minute, FechaEntradaBeneficio, FechaBascula) + DateDiff(DateInterval.Minute, FechaBascula, FechaDescarga)



            If FechaEntradaBeneficioRemision <> Nothing Then
                If HoraCargaCamion <> Nothing Then
                    If DateDiff(DateInterval.Minute, FechaEntradaBeneficioRemision, HoraCargaCamion) > 0 Then
                        oDataRow("TiempoPosicionamiento1") = DateDiff(DateInterval.Minute, FechaEntradaBeneficioRemision, HoraCargaCamion)
                        TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaEntradaBeneficioRemision, HoraCargaCamion)
                    End If
                End If
            End If

            If HoraCargaCamion <> Nothing Then
                If FechaEsperaDespacho <> Nothing Then
                    If DateDiff(DateInterval.Minute, HoraCargaCamion, FechaEsperaDespacho) > 0 Then
                        oDataRow("TiempoCarga1") = DateDiff(DateInterval.Minute, HoraCargaCamion, FechaEsperaDespacho)
                        TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, HoraCargaCamion, FechaEsperaDespacho)
                    End If
                End If
            End If

            If FechaEsperaDespacho <> Nothing Then
                If FechaSalida <> Nothing Then
                    If DateDiff(DateInterval.Minute, FechaEsperaDespacho, FechaSalida) > 0 Then
                        oDataRow("TiempoBodega1") = DateDiff(DateInterval.Minute, FechaEsperaDespacho, FechaSalida)
                        TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaEsperaDespacho, FechaSalida)
                    End If
                End If
            End If

            If FechaIntermedio <> Nothing Then
                If FechaSalida <> Nothing Then
                    If DateDiff(DateInterval.Minute, FechaSalida, FechaIntermedio) > 0 Then
                        oDataRow("TiempoTransito1") = DateDiff(DateInterval.Minute, FechaSalida, FechaIntermedio)
                        TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaSalida, FechaIntermedio)
                    End If
                End If
            End If

            oDataRow("NumeroBoleta") = NumeroBoleta
            DataSet.Tables("Reporte").Rows.Add(oDataRow)



            '---------------------------------------------------------------------------------------------------------------
            '--------------------------RECORRO LOS PUNTOS INTERMEDIOS DE LA REMIONES -------------------------------------------
            '----------------------------------------------------------------------------------------------------------------
            SqlString = "SELECT Intermedio.IdIntermedio, Intermedio.CantidadSacosOrigen, Intermedio.PesoBrutoOrigen, Intermedio.CantidadSacosDestino, Intermedio.PesoBrutoDestino, Intermedio.Fecha, Intermedio.FechaSalida, Intermedio.Cancelada, Intermedio.IdRemisionPergamino, Intermedio.IdEmpresaTransporte, Intermedio.IdOrigen, Intermedio.IdDestino, Intermedio.IdConductor, Intermedio.IdVehiculo, Intermedio.IdUsuario, Intermedio.FechaCarga, Intermedio.ConfirmadoIntermedio, Intermedio.PesoBrutoEntrada, Intermedio.NumeroBoleta, Intermedio.Orden, LugarAcopio.NomLugarAcopio AS LugarAcopioOrigen, LugarAcopio_1.NomLugarAcopio AS LugarAcopioDestino, EmpresaTransporte.NombreEmpresa, Conductor.Nombre AS NombreConductor, Vehiculo.Placa, RemisionPergamino.Codigo AS NumeroRemsion FROM Intermedio INNER JOIN LugarAcopio ON Intermedio.IdOrigen = LugarAcopio.IdLugarAcopio INNER JOIN LugarAcopio AS LugarAcopio_1 ON Intermedio.IdDestino = LugarAcopio_1.IdLugarAcopio INNER JOIN EmpresaTransporte ON Intermedio.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN  Conductor ON Intermedio.IdConductor = Conductor.IdConductor INNER JOIN  Vehiculo ON Intermedio.IdVehiculo = Vehiculo.IdVehiculo  INNER JOIN RemisionPergamino ON Intermedio.IdRemisionPergamino = RemisionPergamino.IdRemisionPergamino " & _
                        "WHERE(Intermedio.IdRemisionPergamino = " & IdRemisionPergamino & ") ORDER BY Intermedio.Orden"
            Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
            Adapter.Fill(DataSet, "IntermedioRemision")
            count = DataSet.Tables("IntermedioRemision").Rows.Count
            j = 0


            '///////////////////////SI CONTADOR ES CERO ES VIAJE DIRECTO ////////////////////////////////////////////////////////////////////////
            If count = 0 Then

                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO ENTRADA CHECKPOINT //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                FechaEntradaCheckPoint = Nothing
                SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Entrada')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "EntradaCheckPoint")
                If DataSet.Tables("EntradaCheckPoint").Rows.Count <> 0 Then
                    FechaEntradaCheckPoint = DataSet.Tables("EntradaCheckPoint").Rows(0)("Fecha")
                End If
                DataSet.Tables("EntradaCheckPoint").Reset()

                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO DESCARGA CHECKPOINT //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                FechaDescarga = Nothing
                SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'RegExistencia')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "DescargaBascula")
                If DataSet.Tables("DescargaBascula").Rows.Count <> 0 Then
                    FechaDescarga = DataSet.Tables("DescargaBascula").Rows(0)("Fecha")
                End If
                DataSet.Tables("DescargaBascula").Reset()

                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO SALIDA CHECKPOINT //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                FechaBascula = Nothing
                SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Bascula')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "BasculaCheckPoint")
                If DataSet.Tables("BasculaCheckPoint").Rows.Count <> 0 Then
                    FechaBascula = DataSet.Tables("BasculaCheckPoint").Rows(0)("Fecha")
                End If
                DataSet.Tables("BasculaCheckPoint").Reset()


                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO SALIDA CHECKPOINT //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                FechaSalidaCheckPoint = Nothing
                SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Salida')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "SalidaCheckPoint")
                If DataSet.Tables("SalidaCheckPoint").Rows.Count <> 0 Then
                    FechaSalidaCheckPoint = DataSet.Tables("SalidaCheckPoint").Rows(0)("Fecha")
                End If
                DataSet.Tables("SalidaCheckPoint").Reset()

                '----------------------------------------------------------------------------------------------------------------------
                '------------------------------------BUSCO TIEMPO DE ESPERA EN DESAPCHO ------------------------------------
                '----------------------------------------------------------------------------------------------------------------------
                SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Reserva')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "EsperaDespachoRegistro")
                If DataSet.Tables("EsperaDespachoRegistro").Rows.Count <> 0 Then
                    FechaEsperaDespacho = DataSet.Tables("EsperaDespachoRegistro").Rows(0)("Fecha")
                End If
                DataSet.Tables("EsperaDespachoRegistro").Reset()

                '----------------------------------------------------------------------------------------------------------------------
                '------------------------------------BUSCO TIEMPO SALIDA AGENCIA ------------------------------------
                '----------------------------------------------------------------------------------------------------------------------
                FechaSalida = Nothing
                SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Salida')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "SalidaRegistro")
                If DataSet.Tables("SalidaRegistro").Rows.Count <> 0 Then
                    FechaSalida = DataSet.Tables("SalidaRegistro").Rows(0)("Fecha")
                End If
                DataSet.Tables("SalidaRegistro").Reset()

                FechaEntradaBeneficio = Nothing
                SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Llegada')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "EntradaRegistro")
                If DataSet.Tables("EntradaRegistro").Rows.Count <> 0 Then
                    FechaEntradaBeneficio = DataSet.Tables("EntradaRegistro").Rows(0)("Fecha")
                End If
                DataSet.Tables("EntradaRegistro").Reset()



                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////BUSCO INTERMEDIO CHECKPOINT//////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                LocalidadIntermedio = ""
                SqlString = "SELECT  PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision.IdLugarAcopioChequeo, PuntoRevision.IdCosecha, PuntoRevision.IdLocalidadChequeo, PuntoRevision.IdVehiculo, LugarAcopio.NomLugarAcopio AS LocalidaChequeo FROM PuntoRevision INNER JOIN  LugarAcopio ON PuntoRevision.IdLocalidadChequeo = LugarAcopio.IdLugarAcopio  " & _
                            "WHERE   (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (PuntoRevision.CodigoRemision = '" & CodigoRemision & "') ORDER BY PuntoRevision.Fecha DESC"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "Intermedio")
                If DataSet.Tables("Intermedio").Rows.Count <> 0 Then
                    FechaIntermedio = DataSet.Tables("Intermedio").Rows(0)("Fecha")
                    LocalidadIntermedio = DataSet.Tables("Intermedio").Rows(0)("LocalidaChequeo")
                End If
                DataSet.Tables("Intermedio").Reset()


                If Format(FechaBascula, "HH:mm") <> "00:00" Then
                    oDataRow("FechaBascula") = Format(FechaBascula, "dd/MM/yyyy HH:mm:ss")
                End If
                If Format(FechaDescarga, "HH:mm") <> "00:00" Then
                    oDataRow("FechaDescargaBeneficio") = Format(FechaDescarga, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaEntradaCheckPoint, "HH:mm") <> "00:00" Then
                    oDataRow("FechaEntradaBeneficio1") = Format(FechaEntradaCheckPoint, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaBascula, "HH:mm") <> "00:00" Then
                    oDataRow("FechaBascula") = Format(FechaBascula, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaEsperaDespacho, "HH:mm") <> "00:00" Then
                    oDataRow("FechaDescargaBeneficio") = Format(FechaDescarga, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaSalidaCheckPoint, "HH:mm") <> "00:00" Then
                    oDataRow("FechaSalidaBeneficio") = Format(FechaSalidaCheckPoint, "dd/MM/yyyy HH:mm:ss")
                End If

                If FechaSalida <> Nothing Then
                    If FechaEntradaCheckPoint <> Nothing Then
                        If DateDiff(DateInterval.Minute, FechaSalida, FechaEntradaCheckPoint) > 0 Then
                            oDataRow("TiempoTransito2") = DateDiff(DateInterval.Minute, FechaSalida, FechaEntradaCheckPoint)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaSalida, FechaEntradaCheckPoint)
                        End If
                    End If
                End If



                If FechaEntradaCheckPoint <> Nothing Then
                    If FechaDescarga <> Nothing Then
                        If DateDiff(DateInterval.Minute, FechaEntradaCheckPoint, FechaDescarga) > 0 Then
                            oDataRow("HoraEspera") = DateDiff(DateInterval.Minute, FechaEntradaCheckPoint, FechaDescarga)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaEntradaCheckPoint, FechaDescarga)
                        End If
                    End If
                End If

                If FechaDescarga <> Nothing Then
                    If FechaSalidaCheckPoint <> Nothing Then
                        If DateDiff(DateInterval.Minute, FechaDescarga, FechaSalidaCheckPoint) > 0 Then
                            oDataRow("TiempoDescarga") = DateDiff(DateInterval.Minute, FechaDescarga, FechaSalidaCheckPoint)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaDescarga, FechaSalidaCheckPoint)
                        End If
                    End If
                End If

                'DataSet.Tables("Reporte").Rows.Add(oDataRow)

                oDataRow("TiempoTotal") = TiempoTotal


            End If

            '//////////////////////////////////////////SI EXISTE MAS DE UN PUNTO INTERMEDIO AGREGO OTRA LINEA --------------------------------------

            '-------------------------------------------------------------------------------------------------------------------------
            '------------------------------------RECORRO LOS PUNTOS INTERMEDIOS ------------------------------------------------------
            '--------------------------------------------------------------------------------------------------------------------------
            Do While count > j

                Placa = DataSet.Tables("IntermedioRemision").Rows(j)("Placa")
                NumeroBoleta = DataSet.Tables("IntermedioRemision").Rows(j)("NumeroBoleta")
                FechaEsperaDespacho = Nothing

                '//////////////////////////////////////////////////////////////////////////////////////////////////////////
                '//////////////////////////////////////////CARGO LOS DATOS DE LA RECEPCION /////////////////////////////////
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlString = "SELECT PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision.IdLugarAcopioChequeo, PuntoRevision.IdCosecha, PuntoRevision.IdLocalidadChequeo, PuntoRevision.IdVehiculo, Cosecha.Codigo, EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, LugarAcopio.CodLugarAcopio FROM PuntoRevision INNER JOIN Cosecha ON PuntoRevision.IdCosecha = Cosecha.IdCosecha INNER JOIN EmpresaTransporte ON PuntoRevision.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                           "WHERE (PuntoRevision.NumeroBoleta BETWEEN  '" & NumeroBoleta & "' AND  '" & NumeroBoleta & "' ) AND (PuntoRevision.IdCosecha = " & IdCosecha & ")ORDER BY PuntoRevision.CodigoRemision DESC"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "ChequePlantaPI")
                If DataSet.Tables("ChequePlantaPI").Rows.Count <> 0 Then
                    CodigoRemision = DataSet.Tables("ChequePlantaPI").Rows(0)("CodigoRemision")
                Else
                    CodigoRemision = 0
                End If
                DataSet.Tables("ChequePlantaPI").Reset()


                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO ENTRADA CHECKPOINT //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                FechaEntradaCheckPoint = Nothing
                SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Entrada')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "EntradaCheckPoint")
                If DataSet.Tables("EntradaCheckPoint").Rows.Count <> 0 Then
                    FechaEntradaCheckPoint = DataSet.Tables("EntradaCheckPoint").Rows(0)("Fecha")
                End If
                DataSet.Tables("EntradaCheckPoint").Reset()

                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO DESCARGA CHECKPOINT //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                FechaDescarga = Nothing
                SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'RegExistencia')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "DescargaBascula")
                If DataSet.Tables("DescargaBascula").Rows.Count <> 0 Then
                    FechaDescarga = DataSet.Tables("DescargaBascula").Rows(0)("Fecha")
                End If
                DataSet.Tables("DescargaBascula").Reset()

                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO SALIDA CHECKPOINT //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                FechaBascula = Nothing
                SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Bascula')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "BasculaCheckPoint")
                If DataSet.Tables("BasculaCheckPoint").Rows.Count <> 0 Then
                    FechaBascula = DataSet.Tables("BasculaCheckPoint").Rows(0)("Fecha")
                End If
                DataSet.Tables("BasculaCheckPoint").Reset()


                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO SALIDA CHECKPOINT //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                FechaSalidaCheckPoint = Nothing
                SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Salida')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "SalidaCheckPoint")
                If DataSet.Tables("SalidaCheckPoint").Rows.Count <> 0 Then
                    FechaSalidaCheckPoint = DataSet.Tables("SalidaCheckPoint").Rows(0)("Fecha")
                End If
                DataSet.Tables("SalidaCheckPoint").Reset()

                '----------------------------------------------------------------------------------------------------------------------
                '------------------------------------BUSCO TIEMPO DE ESPERA EN DESAPCHO ------------------------------------
                '----------------------------------------------------------------------------------------------------------------------
                SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Reserva')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "EsperaDespachoRegistro")
                If DataSet.Tables("EsperaDespachoRegistro").Rows.Count <> 0 Then
                    FechaEsperaDespacho = DataSet.Tables("EsperaDespachoRegistro").Rows(0)("Fecha")
                End If
                DataSet.Tables("EsperaDespachoRegistro").Reset()

                '----------------------------------------------------------------------------------------------------------------------
                '------------------------------------BUSCO TIEMPO SALIDA AGENCIA ------------------------------------
                '----------------------------------------------------------------------------------------------------------------------
                FechaSalida = Nothing
                SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Salida')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "SalidaRegistro")
                If DataSet.Tables("SalidaRegistro").Rows.Count <> 0 Then
                    FechaSalida = DataSet.Tables("SalidaRegistro").Rows(0)("Fecha")
                End If
                DataSet.Tables("SalidaRegistro").Reset()



                ''////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO LA ENTRADA CHECKPOINT//////////////////////////////////////////
                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                'FechaEntradaBeneficio = Nothing
                'SqlString = "SELECT ChequeoPlanta.TipoLectura, LugarAcopio.CodLugarAcopio, PuntoRevision.Placa, PuntoRevision.Fecha AS FechaIntermedio, ChequeoPlanta.Fecha AS FechaEntrada FROM  ChequeoPlanta INNER JOIN PuntoRevision ON ChequeoPlanta.CodigoRemision = PuntoRevision.CodigoRemision INNER JOIN  LugarAcopio ON ChequeoPlanta.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                '                        "WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (PuntoRevision.Placa = '" & Placa & "') AND (ChequeoPlanta.TipoLectura = 'Entrada')"
                ''SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Entrada')"
                'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'Adapter.Fill(DataSet, "CheckPoint")
                'If DataSet.Tables("CheckPoint").Rows.Count <> 0 Then
                '    FechaEntradaBeneficio = DataSet.Tables("CheckPoint").Rows(0)("Fecha")
                'End If
                'DataSet.Tables("CheckPoint").Reset()

                FechaEntradaBeneficio = Nothing
                SqlString = "SELECT IdRegistro, TipoRegistro, IdConductor, IdLugarAcopio, Fecha, Placa, IdTransporte, NumeroBoleta FROM Registros WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (Placa = '" & Placa & "') AND (TipoRegistro = 'Llegada')"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "EntradaRegistro")
                If DataSet.Tables("EntradaRegistro").Rows.Count <> 0 Then
                    FechaEntradaBeneficio = DataSet.Tables("EntradaRegistro").Rows(0)("Fecha")
                End If
                DataSet.Tables("EntradaRegistro").Reset()

                ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ''/////////////////////////////////////////////BUSCO REGISTRO DE DESCARGA CHECKPOING //////////////////////////////////////////
                ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                'FechaDescarga = Nothing
                'SqlString = "SELECT ChequeoPlanta.TipoLectura, LugarAcopio.CodLugarAcopio, PuntoRevision.Placa, PuntoRevision.Fecha AS FechaIntermedio, ChequeoPlanta.Fecha AS FechaEntrada FROM  ChequeoPlanta INNER JOIN PuntoRevision ON ChequeoPlanta.CodigoRemision = PuntoRevision.CodigoRemision INNER JOIN  LugarAcopio ON ChequeoPlanta.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                '                        "WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (PuntoRevision.Placa = '" & Placa & "') AND (ChequeoPlanta.TipoLectura = 'RegExistencia')"
                ''SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'RegExistencia')"
                'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'Adapter.Fill(DataSet, "Descarga")
                'If DataSet.Tables("Descarga").Rows.Count <> 0 Then
                '    FechaDescarga = DataSet.Tables("Descarga").Rows(0)("FechaIntermedio")
                'End If
                'DataSet.Tables("Descarga").Reset()

                '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '/////////////////////////////////////////////BUSCO INTERMEDIO CHECKPOINT//////////////////////////////////////////
                '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                LocalidadIntermedio = ""
                FechaIntermedio = Nothing
                'SqlString = "SELECT  CodigoRemision, Fecha, IdLugarAcopio, NumeroBoleta, IdEmpresaTransporte, Placa, IdLugarAcopioChequeo, IdCosecha, IdLocalidadChequeo, IdVehiculo  FROM PuntoRevision    " & _
                '            "WHERE (NumeroBoleta = '" & NumeroBoleta & "') AND (CodigoRemision = " & CodigoRemision & ") ORDER BY Fecha DESC"
                SqlString = "SELECT  PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision.IdLugarAcopioChequeo, PuntoRevision.IdCosecha, PuntoRevision.IdLocalidadChequeo, PuntoRevision.IdVehiculo, LugarAcopio.NomLugarAcopio AS LocalidaChequeo FROM PuntoRevision INNER JOIN  LugarAcopio ON PuntoRevision.IdLocalidadChequeo = LugarAcopio.IdLugarAcopio  " & _
                            "WHERE   (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (PuntoRevision.CodigoRemision = '" & CodigoRemision & "') ORDER BY PuntoRevision.Fecha DESC"
                Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                Adapter.Fill(DataSet, "Intermedio")
                If DataSet.Tables("Intermedio").Rows.Count <> 0 Then
                    FechaIntermedio = DataSet.Tables("Intermedio").Rows(0)("Fecha")
                    LocalidadIntermedio = DataSet.Tables("Intermedio").Rows(0)("LocalidaChequeo")
                    'CodigoRemision = DataSet.Tables("Intermedio").Rows(0)("CodigoRemision")
                End If
                DataSet.Tables("Intermedio").Reset()

                ' ''/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ' ''/////////////////////////////////////////////BUSCO REGISTRO DE SALIDA CHECKPOINT //////////////////////////////////////////
                ' ''///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                'FechaSalidaBeneficio = Nothing
                ''SqlString = "SELECT CodigoLectura, Fecha, TipoLectura, IdLugarAcopio, CodigoRemision FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Salida')"
                'SqlString = "SELECT ChequeoPlanta.TipoLectura, LugarAcopio.CodLugarAcopio, PuntoRevision.Placa, PuntoRevision.Fecha AS FechaIntermedio, ChequeoPlanta.Fecha AS FechaEntrada FROM  ChequeoPlanta INNER JOIN PuntoRevision ON ChequeoPlanta.CodigoRemision = PuntoRevision.CodigoRemision INNER JOIN  LugarAcopio ON ChequeoPlanta.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                '                                       "WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (PuntoRevision.Placa = '" & Placa & "') AND (ChequeoPlanta.TipoLectura = 'Salida')"
                'Adapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                'Adapter.Fill(DataSet, "Salida")
                'If DataSet.Tables("Salida").Rows.Count <> 0 Then
                '    FechaSalidaBeneficio = DataSet.Tables("Salida").Rows(0)("FechaIntermedio")
                'End If
                'DataSet.Tables("Salida").Reset()


                If j > 0 Then
                    oDataRow = DataSet.Tables("Reporte").NewRow
                End If
                oDataRow("LocalidadPI") = DataSet.Tables("IntermedioRemision").Rows(j)("LugarAcopioOrigen")
                oDataRow("NombreEmpresaPI") = DataSet.Tables("IntermedioRemision").Rows(j)("NombreEmpresa")
                oDataRow("ConductorPI") = DataSet.Tables("IntermedioRemision").Rows(j)("NombreConductor")
                oDataRow("PlacaPI") = DataSet.Tables("IntermedioRemision").Rows(j)("Placa")
                oDataRow("CantidadTrasladoPI") = DataSet.Tables("IntermedioRemision").Rows(j)("CantidadSacosOrigen")
                oDataRow("FechaEntradaBeneficioPI") = FechaEntradaBeneficio  'DataSet.Tables("IntermedioRemision").Rows(j)("Fecha")
                oDataRow("FechaCargaACAPI") = DataSet.Tables("IntermedioRemision").Rows(j)("FechaCarga")

                HoraCargaCamion = DataSet.Tables("IntermedioRemision").Rows(j)("FechaCarga")
                FechaIntermedio = DataSet.Tables("IntermedioRemision").Rows(j)("Fecha")



                If Format(FechaEsperaDespacho, "HH:mm") <> "00:00" Then
                    oDataRow("FechaEsperaDespachoPI") = Format(FechaEsperaDespacho, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaSalida, "HH:mm") <> "00:00" Then
                    oDataRow("FechaSalidaPI") = Format(FechaSalida, "dd/MM/yyyy HH:mm:ss")
                End If
                oDataRow("NumeroRemisionPI") = DataSet.Tables("IntermedioRemision").Rows(j)("NumeroRemsion")
                oDataRow("NumeroBoletaPI") = DataSet.Tables("IntermedioRemision").Rows(j)("NumeroBoleta")


                If Format(FechaBascula, "HH:mm") <> "00:00" Then
                    oDataRow("FechaBascula") = Format(FechaBascula, "dd/MM/yyyy HH:mm:ss")
                End If
                If Format(FechaDescarga, "HH:mm") <> "00:00" Then
                    oDataRow("FechaDescargaBeneficio") = Format(FechaDescarga, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaEntradaCheckPoint, "HH:mm") <> "00:00" Then
                    oDataRow("FechaEntradaBeneficio1") = Format(FechaEntradaCheckPoint, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaBascula, "HH:mm") <> "00:00" Then
                    oDataRow("FechaBascula") = Format(FechaBascula, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaEsperaDespacho, "HH:mm") <> "00:00" Then
                    oDataRow("FechaDescargaBeneficio") = Format(FechaDescarga, "dd/MM/yyyy HH:mm:ss")
                End If

                If Format(FechaSalidaCheckPoint, "HH:mm") <> "00:00" Then
                    oDataRow("FechaSalidaBeneficio") = Format(FechaSalidaCheckPoint, "dd/MM/yyyy HH:mm:ss")
                End If

                If FechaEntradaBeneficio <> Nothing Then
                    If HoraCargaCamion <> Nothing Then
                        If DateDiff(DateInterval.Minute, FechaEntradaBeneficio, HoraCargaCamion) > 0 Then
                            oDataRow("TiempoPosicionamiento2") = DateDiff(DateInterval.Minute, FechaEntradaBeneficio, HoraCargaCamion)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaEntradaBeneficio, HoraCargaCamion)
                        End If
                    End If
                End If

                If HoraCargaCamion <> Nothing Then
                    If FechaEsperaDespacho <> Nothing Then
                        If DateDiff(DateInterval.Minute, HoraCargaCamion, FechaEsperaDespacho) > 0 Then
                            oDataRow("TiempoCarga2") = DateDiff(DateInterval.Minute, HoraCargaCamion, FechaEsperaDespacho)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, HoraCargaCamion, FechaEsperaDespacho)
                        End If
                    End If
                End If

                If FechaEsperaDespacho <> Nothing Then
                    If FechaSalida <> Nothing Then
                        If DateDiff(DateInterval.Minute, FechaEsperaDespacho, FechaSalida) > 0 Then
                            oDataRow("TiempoBodega2") = DateDiff(DateInterval.Minute, FechaEsperaDespacho, FechaSalida)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaEsperaDespacho, FechaSalida)
                        End If
                    End If
                End If

                If FechaSalida <> Nothing Then
                    If FechaEntradaCheckPoint <> Nothing Then
                        If DateDiff(DateInterval.Minute, FechaSalida, FechaEntradaCheckPoint) > 0 Then
                            oDataRow("TiempoTransito2") = DateDiff(DateInterval.Minute, FechaSalida, FechaEntradaCheckPoint)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaSalida, FechaEntradaCheckPoint)
                        End If
                    End If
                End If



                If FechaEntradaCheckPoint <> Nothing Then
                    If FechaDescarga <> Nothing Then
                        If DateDiff(DateInterval.Minute, FechaEntradaCheckPoint, FechaDescarga) > 0 Then
                            oDataRow("HoraEspera") = DateDiff(DateInterval.Minute, FechaEntradaCheckPoint, FechaDescarga)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaEntradaCheckPoint, FechaDescarga)
                        End If
                    End If
                End If

                If FechaDescarga <> Nothing Then
                    If FechaSalidaCheckPoint <> Nothing Then
                        If DateDiff(DateInterval.Minute, FechaDescarga, FechaSalidaCheckPoint) > 0 Then
                            oDataRow("TiempoDescarga") = DateDiff(DateInterval.Minute, FechaDescarga, FechaSalidaCheckPoint)
                            TiempoTotal = TiempoTotal + DateDiff(DateInterval.Minute, FechaDescarga, FechaSalidaCheckPoint)
                        End If
                    End If
                End If

                oDataRow("TiempoTotal") = TiempoTotal

                If j > 0 Then
                    DataSet.Tables("Reporte").Rows.Add(oDataRow)
                End If

                j = j + 1
            Loop

            DataSet.Tables("IntermedioRemision").Reset()


            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
            Iposicion = Iposicion + 1
        Loop

        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Reporte")
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NombreEmpresa").Width = 250
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Conductor").Width = 200
        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NumeroRecibos").Visible = False
        Me.TrueDBGridConsultas.Columns("CantidadTraslado").Caption = "Cantidad Traslado"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("CantidadTraslado").Width = 55
        Me.TrueDBGridConsultas.Columns("AgenciaAcopio").Caption = "Agencia Acopio"
        Me.TrueDBGridConsultas.Columns("FechaEntradaBeneficio").Caption = "Posicionamiento de Transporte (Hra de llegada)"
        Me.TrueDBGridConsultas.Columns("FechaEntradaBeneficio").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaEntradaBeneficio").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaCargaACA").Caption = "Fecha y Hora de Carga"
        Me.TrueDBGridConsultas.Columns("FechaCargaACA").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaCargaACA").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaEsperaDespacho").Caption = "Fecha de Espera en Despacho Agencia o CA"
        Me.TrueDBGridConsultas.Columns("FechaEsperaDespacho").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaEsperaDespacho").Width = 130
        Me.TrueDBGridConsultas.Columns("NumeroRemision").Caption = "Numero Remision"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NumeroRemision").Width = 55
        Me.TrueDBGridConsultas.Columns("NumeroBoleta").Caption = "Numero Boleta"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NumeroBoleta").Width = 55
        Me.TrueDBGridConsultas.Columns("FechaSalidaAgencia").Caption = "Feha y Hora de Salida de Agencia o CA (salida del camion)"
        Me.TrueDBGridConsultas.Columns("FechaSalidaAgencia").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaSalidaAgencia").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaIntermedio").Caption = "Punto Intermedio (Fecha y Horadonde marca pto intermedio check point)"
        Me.TrueDBGridConsultas.Columns("FechaIntermedio").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaIntermedio").Width = 130
        Me.TrueDBGridConsultas.Columns("LocalidadIntermedio").Caption = "Punto Intermedio (localidad donde marca pto intermedio check point)"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("LocalidadIntermedio").Width = 140
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaEntradaBeneficio").Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

        Me.TrueDBGridConsultas.Columns("LocalidadPI").Caption = "Punto Intermedio (localidad donde marca pto intermedio Remisiones)"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("LocalidadPI").Width = 140
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("LocalidadPI").Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NombreEmpresaPI").Width = 250
        Me.TrueDBGridConsultas.Columns("NombreEmpresaPI").Caption = "Proveedor de Transporte Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("ConductorPI").Width = 200
        Me.TrueDBGridConsultas.Columns("ConductorPI").Caption = "Conductor Punto Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("CantidadTrasladoPI").Width = 55
        Me.TrueDBGridConsultas.Columns("CantidadTrasladoPI").Caption = "QQ a trasladar PI"
        Me.TrueDBGridConsultas.Columns("FechaEntradaBeneficioPI").Caption = "Posicionamiento de Transporte (Hra de llegada)"
        Me.TrueDBGridConsultas.Columns("FechaEntradaBeneficioPI").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaEntradaBeneficioPI").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaCargaACAPI").Caption = "Fecha y Hora de Carga"
        Me.TrueDBGridConsultas.Columns("FechaCargaACAPI").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaCargaACAPI").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaEsperaDespachoPI").Caption = "Fecha de Espera en Agencia o CA"
        Me.TrueDBGridConsultas.Columns("FechaEsperaDespachoPI").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaEsperaDespachoPI").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaSalidaPI").Caption = "Salida de Agencia o CA (salida del camion)"
        Me.TrueDBGridConsultas.Columns("FechaSalidaPI").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaSalidaPI").Width = 130
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NumeroRemisionPI").Width = 55
        Me.TrueDBGridConsultas.Columns("NumeroRemisionPI").Caption = "Numero de Remision"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NumeroRemisionPI").Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NumeroBoletaPI").Width = 70
        Me.TrueDBGridConsultas.Columns("NumeroBoletaPI").Caption = "Boleta de Transporte"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NumeroBoletaPI").Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
        Me.TrueDBGridConsultas.Columns("FechaEntradaBeneficio1").Caption = "Entrada a Beneficio"
        Me.TrueDBGridConsultas.Columns("FechaEntradaBeneficio1").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaEntradaBeneficio1").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaBascula").Caption = "Pesaje en Bascula"
        Me.TrueDBGridConsultas.Columns("FechaBascula").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaBascula").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaDescargaBeneficio").Caption = "Descargue en Beneficio"
        Me.TrueDBGridConsultas.Columns("FechaDescargaBeneficio").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaDescargaBeneficio").Width = 130
        Me.TrueDBGridConsultas.Columns("FechaSalidaBeneficio").Caption = "Salida de Beneficio"
        Me.TrueDBGridConsultas.Columns("FechaSalidaBeneficio").NumberFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaSalidaBeneficio").Width = 130

        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("TiempoPosicionamiento1").Width = 65
        Me.TrueDBGridConsultas.Columns("TiempoPosicionamiento1").Caption = "Tiempo Posicionamiento 1"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("TiempoCarga1").Width = 65
        Me.TrueDBGridConsultas.Columns("TiempoCarga1").Caption = "Tiempo de Carga 1"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("TiempoBodega1").Width = 65
        Me.TrueDBGridConsultas.Columns("TiempoBodega1").Caption = "Tiempo en Bodega 1"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("TiempoTransito1").Width = 65
        Me.TrueDBGridConsultas.Columns("TiempoTransito1").Caption = "Tiempo en Transito 1"

        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("TiempoPosicionamiento2").Width = 65
        Me.TrueDBGridConsultas.Columns("TiempoPosicionamiento2").Caption = "Tiempo Posicionamiento 2"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("TiempoCarga2").Width = 65
        Me.TrueDBGridConsultas.Columns("TiempoCarga2").Caption = "Tiempo de Carga 2"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("TiempoBodega2").Width = 65
        Me.TrueDBGridConsultas.Columns("TiempoBodega2").Caption = "Tiempo en Bodega 2"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("TiempoTransito2").Width = 65
        Me.TrueDBGridConsultas.Columns("TiempoTransito2").Caption = "Tiempo en Transito 2"

        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaCargaACA").Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NombreEmpresa").Style.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Conductor").Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("Placa").Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("AgenciaAcopio").Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("NumeroRecibos").Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        'Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns("FechaEntradaBeneficio").Style.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)

    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dim objDlg As New SaveFileDialog
        objDlg.Filter = "Archivo Excel|*.xls"
        objDlg.OverwritePrompt = False
        If objDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim filepath As String = objDlg.FileName
            ExportToExcel(DataSet.Tables("Reporte"), filepath)
        End If
    End Sub

    Private Sub C1Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        Me.Close()
    End Sub
End Class