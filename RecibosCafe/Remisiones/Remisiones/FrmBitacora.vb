Imports C1.Win.C1TrueDBGrid

Public Class FrmBitacora
    Public MiConexion As New SqlClient.SqlConnection(Conexion)



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oDataRow As DataRow
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter
        Dim SqlString As String, SqlDatos As String, Registro As Double = 0, Iposicion As Double = 0, Posicion As Double = 0
        Dim Fecha1 As String, Fecha2 As String, Criterios As String, CodigoRemision As Double = 0
        Dim Buscar_Fila() As DataRow, NumeroBoleta As String, CodIntermedio As String = "", CodLugarOrigen As String = ""
        Dim StrSqlUpdate As String = "", ComandoUpdate As New SqlClient.SqlCommand, iResultado As Integer
        Dim FechaIntermedio As Date, HoraReal As Date, FechaEntrada As Date, FechaSalida As Date

        Fecha1 = Format(Me.DTPFechaIni.Value, "yyyy-MM-dd") & " " & "00:00:00"
        Fecha2 = Format(Me.DTPFechaFin.Value, "yyyy-MM-dd") & " " & "23:59:00"

        '*******************************************************************************************************************************
        '/////////////////////////AGREGO UNA CONSULTA QUE NUNCA TENDRA REGISTROS PARA PODER AGREGARLOS /////////////////////////////////
        '*******************************************************************************************************************************
        SqlString = "SELECT Cosecha.Codigo, EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, PuntoRevision.Placa, EmpresaTransporte.NombreEmpresa As NumeroBoleta, LugarAcopio.CodLugarAcopio AS Localidad_Origen, ChequeoPlanta.TipoLectura As NombreLocalidadOrigen, PuntoRevision.IdLugarAcopioChequeo AS Localidad_Intermedio, ChequeoPlanta.TipoLectura As NombreLocalidadIntermedio,PuntoRevision.Fecha, CASE WHEN ChequeoPlanta.TipoLectura = 'Entrada' THEN ChequeoPlanta.TipoLectura END AS ENTRADA, PuntoRevision.IdLugarAcopioChequeo AS Localidad_Beneficio, ChequeoPlanta.TipoLectura AS NombreLocalidadBeneficio,PuntoRevision.Fecha AS FechaBeneficio, CASE WHEN ChequeoPlanta.TipoLectura = 'Salida' THEN ChequeoPlanta.TipoLectura END AS SALIDA, PuntoRevision.IdLugarAcopioChequeo AS Localidad_BeneficioS, ChequeoPlanta.TipoLectura As NombreLocalidadBeneficioS,PuntoRevision.Fecha AS FechaBeneficioS,ChequeoPlanta.TipoLectura AS CodigoRemision FROM  PuntoRevision INNER JOIN EmpresaTransporte ON PuntoRevision.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN Cosecha ON PuntoRevision.IdCosecha = Cosecha.IdCosecha INNER JOIN ChequeoPlanta ON PuntoRevision.CodigoRemision = ChequeoPlanta.CodigoRemision INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio WHERE (Cosecha.Codigo = '-1000')"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Consulta")

        If Me.RadioButton1.Checked = True Then
            SqlDatos = "SELECT PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision.IdLugarAcopioChequeo, PuntoRevision.IdCosecha, PuntoRevision.IdLocalidadChequeo, PuntoRevision.IdVehiculo, Cosecha.Codigo, EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, LugarAcopio.CodLugarAcopio FROM PuntoRevision INNER JOIN Cosecha ON PuntoRevision.IdCosecha = Cosecha.IdCosecha INNER JOIN EmpresaTransporte ON PuntoRevision.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                        "WHERE (PuntoRevision.Fecha BETWEEN CONVERT(DATETIME, '" & Fecha1 & "', 102) AND CONVERT(DATETIME, '" & Fecha2 & "', 102))"
        Else
            SqlDatos = "SELECT PuntoRevision.CodigoRemision, PuntoRevision.Fecha, PuntoRevision.IdLugarAcopio, PuntoRevision.NumeroBoleta, PuntoRevision.IdEmpresaTransporte, PuntoRevision.Placa, PuntoRevision.IdLugarAcopioChequeo, PuntoRevision.IdCosecha, PuntoRevision.IdLocalidadChequeo, PuntoRevision.IdVehiculo, Cosecha.Codigo, EmpresaTransporte.Codigo, EmpresaTransporte.NombreEmpresa, LugarAcopio.CodLugarAcopio FROM PuntoRevision INNER JOIN Cosecha ON PuntoRevision.IdCosecha = Cosecha.IdCosecha INNER JOIN EmpresaTransporte ON PuntoRevision.IdEmpresaTransporte = EmpresaTransporte.IdEmpresaTransporte INNER JOIN LugarAcopio ON PuntoRevision.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                        "WHERE (PuntoRevision.NumeroBoleta BETWEEN  '" & Me.TxtBoleta1.Text & "' AND  '" & Me.TxtBoleta2.Text & "' )"
        End If
        '*****************************************************************************************************************************************
        '////////////////////////////////////////////CON ESTE CICLO RECORRO LA CONSULTA //////////////////////////////////////////
        '*****************************************************************************************************************************************
        DataAdapter = New SqlClient.SqlDataAdapter(SqlDatos, MiConexion)
        DataAdapter.Fill(DataSet, "Productos")
        Me.ProgressBar.Maximum = DataSet.Tables("Productos").Rows.Count
        Me.ProgressBar.Minimum = 0
        Me.ProgressBar.Value = 0
        Me.ProgressBar.Visible = True
        Registro = DataSet.Tables("Productos").Rows.Count
        Iposicion = 0
        Do While Iposicion < Registro

            NumeroBoleta = DataSet.Tables("Productos").Rows(Iposicion)("NumeroBoleta")
            CodLugarOrigen = DataSet.Tables("Productos").Rows(Iposicion)("CodLugarAcopio")

            If NumeroBoleta = "060227" Then
                NumeroBoleta = DataSet.Tables("Productos").Rows(Iposicion)("NumeroBoleta")
            End If

            Criterios = "NumeroBoleta= '" & DataSet.Tables("Productos").Rows(Iposicion)("NumeroBoleta") & "' AND Localidad_Origen= '" & CodLugarOrigen & "'"
            Buscar_Fila = DataSet.Tables("Consulta").Select(Criterios)
            If Buscar_Fila.Length > 0 Then
                Posicion = DataSet.Tables("Consulta").Rows.IndexOf(Buscar_Fila(0))
                CodigoRemision = DataSet.Tables("Productos").Rows(Iposicion)("CodigoRemision")
                CodIntermedio = DataSet.Tables("Productos").Rows(Iposicion)("IdLugarAcopioChequeo")

                '--------------------------------------------------CONSULTA ENTRADA -----------------------------------------------------------
                SqlString = "SELECT ChequeoPlanta.TipoLectura, LugarAcopio.CodLugarAcopio, ChequeoPlanta.Fecha FROM ChequeoPlanta INNER JOIN PuntoRevision ON ChequeoPlanta.CodigoRemision = PuntoRevision.CodigoRemision INNER JOIN LugarAcopio ON ChequeoPlanta.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                            "WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (ChequeoPlanta.TipoLectura = 'Entrada') AND (ChequeoPlanta.CodigoRemision = '" & CodigoRemision & "')"
                'SqlString = "SELECT * FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Entrada')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Entrada")
                If DataSet.Tables("Entrada").Rows.Count <> 0 Then
                    FechaEntrada = DataSet.Tables("Entrada").Rows(0)("Fecha")
                    FechaIntermedio = DataSet.Tables("Productos").Rows(Iposicion)("Fecha")
                    If CDate(Format(FechaEntrada, "dd/MM/yyyy")) <= CDate(("31/12/2014")) Then
                        If CDate(Format(FechaEntrada, "H:mm")) < CDate(Format(FechaIntermedio, "H:mm")) Then
                            If Hour(Format(FechaIntermedio, "H:mm")) >= 12 Then
                                HoraReal = CDate(Mid(Format(FechaEntrada, "H:mm"), 1, 5) & " PM")
                            Else
                                HoraReal = CDate(Mid(Format(FechaEntrada, "H:mm"), 1, 5) & " AM")
                                If CDate(Format(HoraReal, "H:mm")) < CDate(Format(FechaIntermedio, "H:mm")) Then
                                    HoraReal = CDate(Mid(Format(FechaEntrada, "H:mm"), 1, 5) & " PM")
                                End If
                            End If

                            FechaEntrada = CDate(Format(FechaEntrada, "dd/MM/yyyy")) & " " & HoraReal

                            '-----------------------------------------------CODIGO PARA REPARAR LA HORA ------------------------------------------------
                            SqlString = "UPDATE [ChequeoPlanta]  SET [Fecha] = '" & Format(FechaEntrada, "dd/MM/yyyy H:mm:ss") & "'  " & _
                                        "WHERE (ChequeoPlanta.TipoLectura = 'Entrada') AND (ChequeoPlanta.CodigoRemision = '" & CodigoRemision & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If
                    End If
                    DataSet.Tables("Consulta").Rows(Posicion)("Localidad_Beneficio") = DataSet.Tables("Entrada").Rows(0)("CodLugarAcopio")
                    DataSet.Tables("Consulta").Rows(Posicion)("NombreLocalidadBeneficio") = BuscaLocalidad(DataSet.Tables("Entrada").Rows(0)("CodLugarAcopio"))
                    DataSet.Tables("Consulta").Rows(Posicion)("FechaBeneficio") = Format(DataSet.Tables("Entrada").Rows(0)("Fecha"), "dd/MM/yyyy")
                    'DataSet.Tables("Consulta").Rows(Posicion)("SALIDA") = Format(DataSet.Tables("Entrada").Rows(0)("Fecha"), "hh:mm tt")
                    DataSet.Tables("Consulta").Rows(Posicion)("SALIDA") = Format(FechaEntrada, "hh:mm tt")
                End If
                DataSet.Tables("Entrada").Reset()


                SqlString = "SELECT ChequeoPlanta.TipoLectura, LugarAcopio.CodLugarAcopio, ChequeoPlanta.Fecha FROM ChequeoPlanta INNER JOIN PuntoRevision ON ChequeoPlanta.CodigoRemision = PuntoRevision.CodigoRemision INNER JOIN LugarAcopio ON ChequeoPlanta.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                            "WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (ChequeoPlanta.TipoLectura = 'Salida') AND (ChequeoPlanta.CodigoRemision = '" & CodigoRemision & "')"
                'SqlString = "SELECT * FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Salida')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Salida")
                If DataSet.Tables("Salida").Rows.Count <> 0 Then
                    FechaSalida = DataSet.Tables("Salida").Rows(0)("Fecha")
                    FechaIntermedio = DataSet.Tables("Productos").Rows(Iposicion)("Fecha")
                    If CDate(Format(FechaSalida, "dd/MM/yyyy")) <= CDate(("31/12/2014")) Then
                        If CDate(Format(FechaSalida, "H:mm")) < CDate(Format(FechaEntrada, "H:mm")) Then
                            If Hour(Format(FechaIntermedio, "H:mm")) >= 12 Then
                                HoraReal = CDate(Mid(Format(FechaSalida, "H:mm"), 1, 5) & " PM")
                            Else
                                HoraReal = CDate(Mid(Format(FechaSalida, "H:mm"), 1, 5) & " AM")
                                If CDate(Format(HoraReal, "H:mm")) < CDate(Format(FechaEntrada, "H:mm")) Then
                                    HoraReal = CDate(Mid(Format(FechaSalida, "H:mm"), 1, 5) & " PM")
                                End If
                            End If

                            FechaSalida = CDate(Format(FechaSalida, "dd/MM/yyyy")) & " " & HoraReal

                            '-----------------------------------------------CODIGO PARA REPARAR LA HORA ------------------------------------------------
                            SqlString = "UPDATE [ChequeoPlanta]  SET [Fecha] = '" & Format(FechaSalida, "dd/MM/yyyy H:mm:ss") & "'  " & _
                                        "WHERE (ChequeoPlanta.TipoLectura = 'Salida') AND (ChequeoPlanta.CodigoRemision = '" & CodigoRemision & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If
                    End If
                    DataSet.Tables("Consulta").Rows(Posicion)("Localidad_BeneficioS") = DataSet.Tables("Salida").Rows(0)("CodLugarAcopio")
                    DataSet.Tables("Consulta").Rows(Posicion)("NombreLocalidadBeneficioS") = BuscaLocalidad(DataSet.Tables("Salida").Rows(0)("CodLugarAcopio"))
                    DataSet.Tables("Consulta").Rows(Posicion)("FechaBeneficioS") = Format(DataSet.Tables("Salida").Rows(0)("Fecha"), "dd/MM/yyyy")
                    'DataSet.Tables("Consulta").Rows(Posicion)("CodigoRemision") = Format(DataSet.Tables("Salida").Rows(0)("Fecha"), "hh:mm tt")
                    DataSet.Tables("Consulta").Rows(Posicion)("CodigoRemision") = Format(FechaSalida, "hh:mm tt")
                End If
                DataSet.Tables("Salida").Reset()


            Else

                oDataRow = DataSet.Tables("Consulta").NewRow
                oDataRow("Codigo") = DataSet.Tables("Productos").Rows(Iposicion)("CodCosecha")
                oDataRow("Codigo") = DataSet.Tables("Productos").Rows(Iposicion)("Codigo")
                oDataRow("NombreEmpresa") = DataSet.Tables("Productos").Rows(Iposicion)("NombreEmpresa")
                oDataRow("Placa") = DataSet.Tables("Productos").Rows(Iposicion)("Placa")
                oDataRow("NumeroBoleta") = DataSet.Tables("Productos").Rows(Iposicion)("NumeroBoleta")
                oDataRow("Localidad_Origen") = DataSet.Tables("Productos").Rows(Iposicion)("CodLugarAcopio")
                oDataRow("NombreLocalidadOrigen") = BuscaLocalidad(DataSet.Tables("Productos").Rows(Iposicion)("CodLugarAcopio"))
                oDataRow("Localidad_Intermedio") = DataSet.Tables("Productos").Rows(Iposicion)("IdLugarAcopioChequeo")
                oDataRow("NombreLocalidadIntermedio") = BuscaLocalidad(DataSet.Tables("Productos").Rows(Iposicion)("IdLugarAcopioChequeo"))
                oDataRow("Fecha") = Format(DataSet.Tables("Productos").Rows(Iposicion)("Fecha"), "dd/MM/yyyy")
                oDataRow("ENTRADA") = Format(DataSet.Tables("Productos").Rows(Iposicion)("Fecha"), "hh:mm tt")
                CodigoRemision = DataSet.Tables("Productos").Rows(Iposicion)("CodigoRemision")

                CodIntermedio = DataSet.Tables("Productos").Rows(Iposicion)("IdLugarAcopioChequeo")

                '------------------------------------------------------CONSULTA ENTRADA -----------------------------------------------------------
                SqlString = "SELECT ChequeoPlanta.TipoLectura, LugarAcopio.CodLugarAcopio, ChequeoPlanta.Fecha FROM ChequeoPlanta INNER JOIN PuntoRevision ON ChequeoPlanta.CodigoRemision = PuntoRevision.CodigoRemision INNER JOIN LugarAcopio ON ChequeoPlanta.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                            "WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (ChequeoPlanta.TipoLectura = 'Entrada') AND (ChequeoPlanta.CodigoRemision = '" & CodigoRemision & "')"

                'SqlString = "SELECT * FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Entrada')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Entrada")
                If DataSet.Tables("Entrada").Rows.Count <> 0 Then
                    FechaEntrada = DataSet.Tables("Entrada").Rows(0)("Fecha")
                    FechaIntermedio = DataSet.Tables("Productos").Rows(Iposicion)("Fecha")
                    If CDate(Format(FechaEntrada, "dd/MM/yyyy")) <= CDate(("31/12/2014")) Then
                        If CDate(Format(FechaEntrada, "H:mm")) < CDate(Format(FechaIntermedio, "H:mm")) Then
                            If Hour(Format(FechaIntermedio, "H:mm")) >= 12 Then
                                HoraReal = CDate(Mid(Format(FechaEntrada, "H:mm"), 1, 5) & " PM")
                            Else
                                HoraReal = CDate(Mid(Format(FechaEntrada, "H:mm"), 1, 5) & " AM")
                                If CDate(Format(HoraReal, "H:mm")) < CDate(Format(FechaIntermedio, "H:mm")) Then
                                    HoraReal = CDate(Mid(Format(FechaEntrada, "H:mm"), 1, 5) & " PM")
                                End If
                            End If

                            FechaEntrada = CDate(Format(FechaEntrada, "dd/MM/yyyy")) & " " & HoraReal

                            '-----------------------------------------------CODIGO PARA REPARAR LA HORA ------------------------------------------------
                            SqlString = "UPDATE [ChequeoPlanta]  SET [Fecha] = '" & Format(FechaEntrada, "dd/MM/yyyy H:mm:ss") & "'  " & _
                                        "WHERE (ChequeoPlanta.TipoLectura = 'Entrada') AND (ChequeoPlanta.CodigoRemision = '" & CodigoRemision & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If
                    End If
                    oDataRow("Localidad_Beneficio") = DataSet.Tables("Entrada").Rows(0)("CodLugarAcopio")
                    oDataRow("NombreLocalidadBeneficio") = BuscaLocalidad(DataSet.Tables("Entrada").Rows(0)("CodLugarAcopio"))
                    oDataRow("FechaBeneficio") = Format(DataSet.Tables("Entrada").Rows(0)("Fecha"), "dd/MM/yyyy")
                    'oDataRow("SALIDA") = Format(DataSet.Tables("Entrada").Rows(0)("Fecha"), "hh:mm tt")
                    oDataRow("SALIDA") = Format(FechaEntrada, "hh:mm tt")
                End If
                DataSet.Tables("Entrada").Reset()


                SqlString = "SELECT ChequeoPlanta.TipoLectura, LugarAcopio.CodLugarAcopio, ChequeoPlanta.Fecha FROM ChequeoPlanta INNER JOIN PuntoRevision ON ChequeoPlanta.CodigoRemision = PuntoRevision.CodigoRemision INNER JOIN LugarAcopio ON ChequeoPlanta.IdLugarAcopio = LugarAcopio.IdLugarAcopio  " & _
                            "WHERE (PuntoRevision.NumeroBoleta = '" & NumeroBoleta & "') AND (ChequeoPlanta.TipoLectura = 'Salida') AND (ChequeoPlanta.CodigoRemision = '" & CodigoRemision & "')"
                'SqlString = "SELECT * FROM ChequeoPlanta WHERE (CodigoRemision = " & CodigoRemision & ") AND (TipoLectura = 'Salida')"
                DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
                DataAdapter.Fill(DataSet, "Salida")
                If DataSet.Tables("Salida").Rows.Count <> 0 Then
                    FechaSalida = DataSet.Tables("Salida").Rows(0)("Fecha")
                    FechaIntermedio = DataSet.Tables("Productos").Rows(Iposicion)("Fecha")
                    If CDate(Format(FechaSalida, "dd/MM/yyyy")) <= CDate(("31/12/2014")) Then
                        If CDate(Format(FechaSalida, "H:mm")) < CDate(Format(FechaEntrada, "H:mm")) Then
                            If Hour(Format(FechaIntermedio, "H:mm")) >= 12 Then
                                HoraReal = CDate(Mid(Format(FechaSalida, "H:mm"), 1, 5) & " PM")
                            Else
                                HoraReal = CDate(Mid(Format(FechaSalida, "H:mm"), 1, 5) & " AM")
                                If CDate(Format(HoraReal, "H:mm")) < CDate(Format(FechaEntrada, "H:mm")) Then
                                    HoraReal = CDate(Mid(Format(FechaSalida, "H:mm"), 1, 5) & " PM")
                                End If
                            End If

                            FechaSalida = CDate(Format(FechaSalida, "dd/MM/yyyy")) & " " & HoraReal

                            '-----------------------------------------------CODIGO PARA REPARAR LA HORA ------------------------------------------------
                            SqlString = "UPDATE [ChequeoPlanta]  SET [Fecha] = '" & Format(FechaSalida, "dd/MM/yyyy H:mm:ss") & "'  " & _
                                        "WHERE (ChequeoPlanta.TipoLectura = 'Salida') AND (ChequeoPlanta.CodigoRemision = '" & CodigoRemision & "')"
                            MiConexion.Open()
                            ComandoUpdate = New SqlClient.SqlCommand(SqlString, MiConexion)
                            iResultado = ComandoUpdate.ExecuteNonQuery
                            MiConexion.Close()
                        End If
                    End If

                    oDataRow("Localidad_BeneficioS") = DataSet.Tables("Salida").Rows(0)("CodLugarAcopio")
                    oDataRow("NombreLocalidadBeneficioS") = BuscaLocalidad(DataSet.Tables("Salida").Rows(0)("CodLugarAcopio"))
                    oDataRow("FechaBeneficioS") = Format(DataSet.Tables("Salida").Rows(0)("Fecha"), "dd/MM/yyyy")
                    'oDataRow("CodigoRemision") = Format(DataSet.Tables("Salida").Rows(0)("Fecha"), "hh:mm tt")
                    oDataRow("CodigoRemision") = Format(FechaSalida, "hh:mm tt")
                End If
                DataSet.Tables("Salida").Reset()



                DataSet.Tables("Consulta").Rows.Add(oDataRow)
            End If






            Me.Text = "Procesando: " & Iposicion
            If Me.ProgressBar.Maximum <> 0 Then
                Me.ProgressBar.Value = Me.ProgressBar.Value + 1
            End If
            My.Application.DoEvents()
            Iposicion = Iposicion + 1
        Loop


        Me.TrueDBGridConsultas.DataSource = DataSet.Tables("Consulta")

        Me.TrueDBGridConsultas.Columns(0).Caption = "Cosecha"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 55
        Me.TrueDBGridConsultas.Columns(1).Caption = "Codigo Empresa"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(2).Width = 200
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 80
        Me.TrueDBGridConsultas.Columns(5).Caption = "Localidad Origen"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 60
        Me.TrueDBGridConsultas.Columns(6).Caption = "Nombre Localidad Origen"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 90
        Me.TrueDBGridConsultas.Columns(7).Caption = "Localidad Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 60
        Me.TrueDBGridConsultas.Columns(8).Caption = "Nombre Localidad Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(8).Width = 90
        Me.TrueDBGridConsultas.Columns(9).Caption = "Fecha Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(9).Width = 65
        Me.TrueDBGridConsultas.Columns(10).Caption = "Hora Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(10).Width = 65
        Me.TrueDBGridConsultas.Columns(11).Caption = "Localidad Entrada Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(11).Width = 65
        Me.TrueDBGridConsultas.Columns(12).Caption = "Nombre Localidad Entrada"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(12).Width = 90
        Me.TrueDBGridConsultas.Columns(13).Caption = "Fecha Entrada Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(13).Width = 80
        Me.TrueDBGridConsultas.Columns(14).Caption = "Hora Entrada Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(14).Width = 70
        Me.TrueDBGridConsultas.Columns(15).Caption = "Localidad Salida Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(15).Width = 70
        Me.TrueDBGridConsultas.Columns(16).Caption = "Nombre Localidad Salida"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(16).Width = 90
        Me.TrueDBGridConsultas.Columns(17).Caption = "Fecha Salida Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(17).Width = 70
        Me.TrueDBGridConsultas.Columns(18).Caption = "Hora Salida Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(18).Width = 70

    End Sub

    Private Sub ButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmBitacora_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'MDIParent1.Button1.Visible = True
        'MDIParent1.Button2.Visible = True
        'MDIParent1.Button3.Visible = True
    End Sub
    Public Sub Exportar_Excel(ByVal dgv As C1TrueDBGrid, ByVal pth As String)

        Dim xlApp As Object = CreateObject("Excel.Application")
        'nueva
        Dim xlWB As Object = xlApp.WorkBooks.add
        Dim xlWS As Object = xlWB.WorkSheets(1)

        'exportamos
        For c As Integer = 0 To TrueDBGridConsultas.Columns.Count - 1
            xlWS.cells(1, c + 1) = TrueDBGridConsultas.Columns(c).Caption
        Next
        'exportamos las cabeceras de columnas
        For r As Integer = 0 To TrueDBGridConsultas.RowCount - 1
            For c As Integer = 0 To TrueDBGridConsultas.Columns.Count - 1
                xlWS.cells(r + 2, c + 1) = TrueDBGridConsultas.Item(r, c)
            Next
        Next
        'guardamos la hoja de calculo en la ruta especifica
        xlWB.saveas(pth)
        xlWS = Nothing
        xlWB = Nothing
        xlApp.quit()
        xlApp = Nothing
    End Sub


    Private Sub FrmBitacora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TrueDBGridConsultas.Columns(0).Caption = "Cosecha"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(0).Width = 55
        Me.TrueDBGridConsultas.Columns(1).Caption = "Codigo Empresa"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(1).Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(3).Width = 70
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(4).Width = 80
        Me.TrueDBGridConsultas.Columns(5).Caption = "Localidad Origen"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(5).Width = 60
        Me.TrueDBGridConsultas.Columns(6).Caption = "Localidad Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(6).Width = 60
        Me.TrueDBGridConsultas.Columns(7).Caption = "Fecha Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(7).Width = 65
        Me.TrueDBGridConsultas.Columns(8).Caption = "Hora Intermedio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(8).Width = 65
        Me.TrueDBGridConsultas.Columns(9).Caption = "Entrada Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(9).Width = 65
        Me.TrueDBGridConsultas.Columns(10).Caption = "Fecha Entrada Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(10).Width = 80
        Me.TrueDBGridConsultas.Columns(11).Caption = "Hora Entrada Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(11).Width = 70
        Me.TrueDBGridConsultas.Columns(12).Caption = "Salida Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(12).Width = 70
        Me.TrueDBGridConsultas.Columns(13).Caption = "Fecha Salida Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(13).Width = 70
        Me.TrueDBGridConsultas.Columns(14).Caption = "Hora Salida Beneficio"
        Me.TrueDBGridConsultas.Splits.Item(0).DisplayColumns(14).Width = 70

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            Me.GroupBox1.Visible = True
            Me.GroupBox3.Visible = False
        Else
            Me.GroupBox3.Visible = True
            Me.GroupBox1.Visible = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            Me.GroupBox1.Visible = True
            Me.GroupBox3.Visible = False
        Else
            Me.GroupBox3.Visible = True
            Me.GroupBox1.Visible = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Save As New SaveFileDialog
        Save.Filter = "Archivo Excel | *.xlsx"
        If Save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Exportar_Excel(Me.TrueDBGridConsultas, Save.FileName)
        End If
    End Sub
End Class