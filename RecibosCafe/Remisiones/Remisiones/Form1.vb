Imports C1.Win.C1Ribbon
Imports System.Threading
Public Class MDIParent1
    Public IdLugarAcopio As Integer, MiConexion As New SqlClient.SqlConnection(Conexion), LugarAcopio As String
    Private oHebra As Thread
    Private Sub MDIParent1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim MyRuta As String, SqlString As String, Ruta As String
        Dim fileReader As String = ""

        Ruta = My.Application.Info.DirectoryPath & "\Cosecha.txt"
        If Dir(Ruta) <> "" Then
            fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
            CodigoCosecha = fileReader
        Else
            MsgBox("No Existe el Archivo Cosecha", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If
    End Sub

    Private Sub MDIParent1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '/////////////////////////Cierro las herabas abiertas/////////////////
        If Not (oHebra Is Nothing) Then
            If oHebra.IsAlive Then
                oHebra.Abort()
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Ruta As String, LeeArchivo As String, SqlString As String
        Dim DataSet As New DataSet, DataAdapter As New SqlClient.SqlDataAdapter



        Ruta = My.Application.Info.DirectoryPath & "\Localidad.txt"
        LeeArchivo = ""
        If Dir(Ruta) <> "" Then
            LeeArchivo = Trim(My.Computer.FileSystem.ReadAllText(Ruta))
        Else
            MsgBox("No Existe el Archivo Localidad", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If


        'LeeArchivo = LeeArchivo.Replace(" "c, String.Empty)
        LeeArchivo = Mid(LeeArchivo, 1, 3)

        '//////////////////////////////////////////////////////////BUSCO LOCALIDAD ///////////////////////////////////////////////////
        SqlString = "SELECT  * FROM LugarAcopio WHERE (CodLugarAcopio = '" & LeeArchivo & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad")
        If DataSet.Tables("Localidad").Rows.Count = 0 Then
            MsgBox("No Existe esta Localidad o No Esta Activo", MsgBoxStyle.Critical, "Sistema PuntoRevision")
            Exit Sub
        Else
            IdLugarAcopio = DataSet.Tables("Localidad").Rows(0)("IdLugarAcopio")
            LugarAcopio = DataSet.Tables("Localidad").Rows(0)("NomLugarAcopio")
        End If

        If UsuarioType = "AutorizaPrecioDiscrecionalidad" Or UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then
            Me.RibbonButton21.Enabled = True
        Else
            Me.RibbonButton21.Enabled = False
        End If

        CreaCortePrecios(IdLugarAcopio, Now)

        oHebra = New Thread(AddressOf CrearCorteSubProceso)
        oHebra.Start()

    End Sub
    Private Sub CrearCorteSubProceso()
        Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet
        Dim ContLocalidad As Double, i As Double, idLocalidad As Double


        SqlString = "SELECT  * FROM LugarAcopio WHERE (IdRegion = '" & IdRegionUsuario & "') AND (Activo = 1)"
        DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        DataAdapter.Fill(DataSet, "Localidad")
        ContLocalidad = DataSet.Tables("Localidad").Rows.Count
        Do While ContLocalidad > i

            idLocalidad = DataSet.Tables("Localidad").Rows(i)("IdLugarAcopio")
            CreaCortePrecios(idLocalidad, Now)
            i = i + 1
        Loop

        oHebra.Abort()

    End Sub


    Private Sub RibbonConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Productos.Click
        My.Forms.FrmConfigurar.MdiParent = Me
        My.Forms.FrmConfigurar.Show()
    End Sub

    Private Sub RibbonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonExit.Click
        Me.Close()
    End Sub

    Private Sub RibbonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton1.Click
        Me.Close()
    End Sub

    Private Sub RibbonButton30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FrmUsuarios.MdiParent = Me
        My.Forms.FrmUsuarios.Show()
    End Sub

    Private Sub RibbonProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonProductor.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        My.Forms.FrmProveedores.MdiParent = Me
        My.Forms.FrmProveedores.Show()
    End Sub

    Private Sub RibbonButton31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton31.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        My.Forms.FrmConfigurar.MdiParent = Me
        My.Forms.FrmConfigurar.Show()
    End Sub

    Private Sub RibbonButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton3.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        Me.CmdReporta.Visible = False
        My.Forms.FrmProductos.MdiParent = Me
        My.Forms.FrmProductos.Show()
    End Sub

    Private Sub RibbonButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton12.Click
        Quien = "Recepcion"
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        'My.Forms.FrmRecepcion.MdiParent = Me
        My.Forms.FrmRecepcion.Show()
    End Sub

    Private Sub RibbonButton71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.FrmCarga.MdiParent = Me
        My.Forms.FrmCarga.Show()
    End Sub

    Private Sub RibbonButton711_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton711.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = True
        Me.CmdCargar.Visible = True
        Me.CmdReservar.Visible = True
        Me.CmdSalida.Visible = True
    End Sub

    Private Sub CmdHoraLlegada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdHoraLlegada.Click
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        Me.CmdReporta.Visible = False
        My.Forms.FrmRegistros.LblBoleta.Visible = True
        My.Forms.FrmRegistros.TxtBoleta.Visible = True
        'My.Forms.FrmRegistros.MdiParent = Me
        My.Forms.FrmRegistros.LblRegistro.Text = "REGISTRO DE LLEGADA"
        My.Forms.FrmRegistros.Text = "REGISTRO DE LLEGADA"
        My.Forms.FrmRegistros.OptLlegada.Checked = True
        My.Forms.FrmRegistros.ShowDialog()
    End Sub

    Private Sub CmdCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCargar.Click
        'Me.CmdHoraLlegada.Visible = False
        'Me.CmdCargar.Visible = False
        'Me.CmdReservar.Visible = False
        'Me.CmdSalida.Visible = False
        'Me.CmdReporta.Visible = False
        ''My.Forms.FrmCarga.MdiParent = Me
        ''My.Forms.FrmCarga.ShowDialog()

        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        My.Forms.FrmRemision2.Show()
    End Sub

    Private Sub CmdSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalida.Click
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        Me.CmdReporta.Visible = False
        My.Forms.FrmRegistros.LblBoleta.Visible = True
        My.Forms.FrmRegistros.TxtBoleta.Visible = True
        'My.Forms.FrmRegistros.MdiParent = Me
        My.Forms.FrmRegistros.LblRegistro.Text = "REGISTRO DE SALIDA"
        My.Forms.FrmRegistros.Text = "TIEMPO DE ESPERA EN DESPACHO"
        My.Forms.FrmRegistros.OptSalida.Checked = True
        My.Forms.FrmRegistros.ShowDialog()
    End Sub

    Private Sub CmdReservar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReservar.Click
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        Me.CmdReporta.Visible = False
        My.Forms.FrmRegistros.LblBoleta.Visible = True
        My.Forms.FrmRegistros.TxtBoleta.Visible = True
        'My.Forms.FrmRegistros.MdiParent = Me
        My.Forms.FrmRegistros.LblRegistro.Text = "TIEMPO DE ESPERA EN DESPACHO"
        My.Forms.FrmRegistros.Text = "TIEMPO DE ESPERA EN DESPACHO"
        My.Forms.FrmRegistros.OptReserva.Checked = True
        My.Forms.FrmRegistros.ShowDialog()
    End Sub

    Private Sub RibbonButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton11.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        My.Forms.FrmConsultaReporte.MdiParent = Me
        My.Forms.FrmConsultaReporte.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReporta.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        'My.Forms.FrmRegistros.MdiParent = Me

        My.Forms.FrmReporta.ShowDialog()
    End Sub

    Private Sub RibbonButton311_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub RibbonButton3111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "Calidad-Da�o"
        My.Forms.FrmVinculo.MdiParent = Me
        My.Forms.FrmVinculo.Show()
    End Sub

    Private Sub RibbonButton31111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "TipoCompra-Calidad"
        My.Forms.FrmVinculo.MdiParent = Me
        My.Forms.FrmVinculo.Show()
    End Sub

    Private Sub RibbonButton311111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Quien = "Calidad-Fisico"
        My.Forms.FrmVinculo.MdiParent = Me
        My.Forms.FrmVinculo.Show()
    End Sub

    Private Sub RibbonButton31111_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton31111.Click
        Quien = "TipoCompra-Calidad"
        My.Forms.FrmVinculo.MdiParent = Me
        My.Forms.FrmVinculo.Show()
    End Sub

    Private Sub RibbonButton311112_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton311112.Click
        'Quien = "TipoDocumento-Calidad"
        'My.Forms.FrmVinculo.MdiParent = Me
        'My.Forms.FrmVinculo.Show()

        My.Forms.FrmVinculo3.MdiParent = Me
        My.Forms.FrmVinculo3.Show()
    End Sub

    Private Sub RibbonButton3111_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton3111.Click
        Quien = "Calidad-Da�o"
        My.Forms.FrmVinculo.MdiParent = Me
        My.Forms.FrmVinculo.Show()
    End Sub

    Private Sub RibbonButton311_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton311.Click
        Quien = "Calidad-Categoria"
        My.Forms.FrmVinculo.MdiParent = Me
        My.Forms.FrmVinculo.Show()
    End Sub

    Private Sub RibbonButton311111_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton311111.Click
        Quien = "Calidad-Fisico"
        My.Forms.FrmVinculo.MdiParent = Me
        My.Forms.FrmVinculo.Show()
    End Sub

    Private Sub RibbonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton2.Click
        Quien = "Liquidacion"
        'Me.CmdReporta.Visible = False
        'Me.CmdHoraLlegada.Visible = False
        'Me.CmdCargar.Visible = False
        'Me.CmdReservar.Visible = False
        'Me.CmdSalida.Visible = False
        'My.Forms.FrmLiquidacion.MdiParent = Me
        'My.Forms.FrmLiquidacion.Show()
        My.Forms.FrmResumenLiquidacion.Show()
    End Sub

    Private Sub RibbonButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton4.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        My.Forms.FrmRemision2.Show()
    End Sub

    Private Sub RibbonButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton21.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        My.Forms.FrmResumenCalculoPrecio.MdiParent = Me
        My.Forms.FrmResumenCalculoPrecio.Show()
    End Sub

    Private Sub RibbonButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton5.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        My.Forms.FrmDiscrecionalidad.MdiParent = Me
        My.Forms.FrmDiscrecionalidad.Show()
    End Sub

    Private Sub RbnTrazabilidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbnTrazabilidad.Click
        Me.CmdReporta.Visible = False
        Me.CmdHoraLlegada.Visible = False
        Me.CmdCargar.Visible = False
        Me.CmdReservar.Visible = False
        Me.CmdSalida.Visible = False
        My.Forms.FrmConsultaReporte.MdiParent = Me
        My.Forms.FrmConsultaReporte.Show()
    End Sub

    Private Sub RbnMermaBodegaXReciboXRemision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbnMermaBodegaXReciboXRemision.Click
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.GroupBox4.Location = New Point(446, 147)
        My.Forms.FrmReportes.GroupBox4.Visible = True
        My.Forms.FrmReportes.GroupBox6.Location = New Point(446, 10)
        My.Forms.FrmReportes.GroupBox6.Visible = True
        My.Forms.FrmReportes.ChkTodasLocalidades.Visible = True
        My.Forms.FrmReportes.BtnImprimir.Visible = True
        My.Forms.FrmReportes.BtnImprimir.Location = New Point(875, 16)
        My.Forms.FrmReportes.TDGridResumenLiquidacion.Visible = False
        My.Forms.FrmReportes.Show()
    End Sub

    Private Sub RbnMermaPI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbnMermaPI.Click
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.GroupBox4.Location = New Point(446, 147)
        My.Forms.FrmReportes.GroupBox4.Visible = True
        My.Forms.FrmReportes.GroupBox6.Location = New Point(446, 10)
        My.Forms.FrmReportes.GroupBox6.Visible = True
        My.Forms.FrmReportes.GroupBox8.Location = New Point(12, 99)
        My.Forms.FrmReportes.GroupBox8.Visible = True
        My.Forms.FrmReportes.ChkTodasLocalidades.Visible = True
        My.Forms.FrmReportes.GroupBox11.Location = New Point(12, 261)
        My.Forms.FrmReportes.GroupBox11.Visible = True
        My.Forms.FrmReportes.BtnImprimirMermaPI.Visible = True
        My.Forms.FrmReportes.BtnImprimirMermaPI.Location = New Point(875, 16)
        My.Forms.FrmReportes.TDGridResumenLiquidacion.Visible = False
        My.Forms.FrmReportes.Show()
    End Sub


    Private Sub RbnResumenLiquidacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbnResumenLiquidacion.Click
        My.Forms.FrmReportes.MdiParent = Me
        My.Forms.FrmReportes.GroupBox3.Visible = False
        My.Forms.FrmReportes.GroupBox8.Location = New Point(12, 8)
        My.Forms.FrmReportes.ChkTodasLocalidades.Visible = False
        If UsuarioType = "AutorizaPrecioFueraDiscrecionalidad" Then
            My.Forms.FrmReportes.GroupBox8.Visible = True
            My.Forms.FrmReportes.BtnProcesar.Visible = True
        Else
            My.Forms.FrmReportes.GroupBox8.Visible = False
            My.Forms.FrmReportes.BtnProcesar.Visible = True
        End If

        My.Forms.FrmReportes.ListBox.Visible = True
        My.Forms.FrmReportes.BtnProcesar.Location = New Point(875, 16)
        My.Forms.FrmReportes.BtnPrevio.Location = New Point(875, 100)
        My.Forms.FrmReportes.BtnPrevio.Visible = True
        My.Forms.FrmReportes.TDGridResumenLiquidacion.Visible = False
        My.Forms.FrmReportes.Show()

    End Sub

    Private Sub RbnReimpresionResumeLiq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbnReimpresionResumeLiq.Click
        'Dim SqlString As String, DataAdapter As New SqlClient.SqlDataAdapter, DataSet As New DataSet

        'SqlString = "SELECT DISTINCT LiquidacionPergamino.NumeroReportado, LiquidacionPergamino.FechaReportado, LugarAcopio.NomLugarAcopio FROM LiquidacionPergamino INNER JOIN LugarAcopio ON LiquidacionPergamino.IdLocalidad = LugarAcopio.IdLugarAcopio WHERE(Not (LiquidacionPergamino.NumeroReportado Is NULL))"
        'DataAdapter = New SqlClient.SqlDataAdapter(SqlString, MiConexion)
        'DataAdapter.Fill(DataSet, "Consulta")
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.DataSource = DataSet.Tables("Consulta")
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Location = New Point(446, 8)
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Visible = True
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("NumeroReportado").Width = 80
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("NumeroReportado").Locked = True
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Columns("NumeroReportado").Caption = "Proceso"

        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("FechaReportado").Width = 80
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("FechaReportado").Locked = True
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Columns("FechaReportado").Caption = "Fecha"

        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("NomLugarAcopio").Width = 150
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Splits.Item(0).DisplayColumns("NomLugarAcopio").Locked = True
        'My.Forms.FrmReportes.TDGridResumenLiquidacion.Columns("NomLugarAcopio").Caption = "Lugar Acopio"

        'My.Forms.FrmReportes.BtnReimprimir.Visible = True
        'My.Forms.FrmReportes.BtnReimprimir.Location = New Point(875, 16)

        'My.Forms.FrmReportes.TDGridResumenLiquidacion.RowHeight = 20

        My.Forms.FrmReportes.ChkTodosLosProcesos.Visible = True
        My.Forms.FrmReportes.ChkTodosLosProcesos.Location = New Point(184, 261)
        My.Forms.FrmReportes.BtnFiltrar.Visible = True
        My.Forms.FrmReportes.BtnFiltrar.Location = New Point(321, 262)
        My.Forms.FrmReportes.LlenadoGrid("Todo")
        My.Forms.FrmReportes.Show()



    End Sub
End Class
