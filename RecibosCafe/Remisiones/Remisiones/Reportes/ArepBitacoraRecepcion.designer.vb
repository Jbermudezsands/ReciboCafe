<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepBitacoraRecepcion 
    Inherits DataDynamics.ActiveReports.ActiveReport3 

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepBitacoraRecepcion))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.LblDireccion = New DataDynamics.ActiveReports.Label
        Me.LblRuc = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.LblLote = New DataDynamics.ActiveReports.Label
        Me.LblHora = New DataDynamics.ActiveReports.Label
        Me.SubReportCertificado = New DataDynamics.ActiveReports.SubReport
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.TxtFinal = New DataDynamics.ActiveReports.TextBox
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.lblOrderNum = New DataDynamics.ActiveReports.Label
        Me.lblOrderDate = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.LblOrden = New DataDynamics.ActiveReports.Label
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.LblTipoCompra = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.LblNombres = New DataDynamics.ActiveReports.Label
        Me.LblCosecha = New DataDynamics.ActiveReports.Label
        Me.LblLocalidad = New DataDynamics.ActiveReports.Label
        Me.LblHoraRecibo = New DataDynamics.ActiveReports.Label
        Me.Label38 = New DataDynamics.ActiveReports.Label
        Me.Label35 = New DataDynamics.ActiveReports.Label
        Me.LblCedulas = New DataDynamics.ActiveReports.Label
        Me.Label39 = New DataDynamics.ActiveReports.Label
        Me.LblFinca = New DataDynamics.ActiveReports.Label
        Me.LblOriginal = New DataDynamics.ActiveReports.Label
        Me.Label61 = New DataDynamics.ActiveReports.Label
        Me.LblPignorado = New DataDynamics.ActiveReports.Label
        Me.Label40 = New DataDynamics.ActiveReports.Label
        Me.Label41 = New DataDynamics.ActiveReports.Label
        Me.Label42 = New DataDynamics.ActiveReports.Label
        Me.LblEstado = New DataDynamics.ActiveReports.Label
        Me.LblCalidad = New DataDynamics.ActiveReports.Label
        Me.Label45 = New DataDynamics.ActiveReports.Label
        Me.LblDaño = New DataDynamics.ActiveReports.Label
        Me.LblCategoria = New DataDynamics.ActiveReports.Label
        Me.Label48 = New DataDynamics.ActiveReports.Label
        Me.Label49 = New DataDynamics.ActiveReports.Label
        Me.LblHum = New DataDynamics.ActiveReports.Label
        Me.Label51 = New DataDynamics.ActiveReports.Label
        Me.LblImp = New DataDynamics.ActiveReports.Label
        Me.Label53 = New DataDynamics.ActiveReports.Label
        Me.LblIngreso = New DataDynamics.ActiveReports.Label
        Me.Label55 = New DataDynamics.ActiveReports.Label
        Me.Label56 = New DataDynamics.ActiveReports.Label
        Me.LblCompra = New DataDynamics.ActiveReports.Label
        Me.LblLiquidar = New DataDynamics.ActiveReports.Label
        Me.Label59 = New DataDynamics.ActiveReports.Label
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblProductID = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.LblApellidos = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.LblBodegas = New DataDynamics.ActiveReports.Label
        Me.LblBarco = New DataDynamics.ActiveReports.Label
        Me.LblConductor = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.LblOrigen = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.LblPila = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.LblPlaca = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label19 = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.Label25 = New DataDynamics.ActiveReports.Label
        Me.Label26 = New DataDynamics.ActiveReports.Label
        Me.Label27 = New DataDynamics.ActiveReports.Label
        Me.Label28 = New DataDynamics.ActiveReports.Label
        Me.Label29 = New DataDynamics.ActiveReports.Label
        Me.Label30 = New DataDynamics.ActiveReports.Label
        Me.Label31 = New DataDynamics.ActiveReports.Label
        Me.Label32 = New DataDynamics.ActiveReports.Label
        Me.Label33 = New DataDynamics.ActiveReports.Label
        Me.Label34 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label37 = New DataDynamics.ActiveReports.Label
        Me.Label57 = New DataDynamics.ActiveReports.Label
        Me.Label58 = New DataDynamics.ActiveReports.Label
        Me.Label60 = New DataDynamics.ActiveReports.Label
        Me.TxtCertificados = New DataDynamics.ActiveReports.TextBox
        Me.lblQty = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.lblSubTotals = New DataDynamics.ActiveReports.Label
        Me.TxtPesoNeto = New DataDynamics.ActiveReports.TextBox
        Me.Label36 = New DataDynamics.ActiveReports.Label
        Me.Label43 = New DataDynamics.ActiveReports.Label
        Me.Label44 = New DataDynamics.ActiveReports.Label
        Me.Label46 = New DataDynamics.ActiveReports.Label
        Me.Label47 = New DataDynamics.ActiveReports.Label
        Me.Label50 = New DataDynamics.ActiveReports.Label
        Me.Label52 = New DataDynamics.ActiveReports.Label
        Me.TxtOreado = New DataDynamics.ActiveReports.Label
        Me.TxtReal = New DataDynamics.ActiveReports.Label
        Me.Label62 = New DataDynamics.ActiveReports.Label
        Me.TxtObservaciones = New DataDynamics.ActiveReports.TextBox
        Me.Label63 = New DataDynamics.ActiveReports.Label
        Me.TxtQQOreado = New DataDynamics.ActiveReports.Label
        Me.Label65 = New DataDynamics.ActiveReports.Label
        Me.Label54 = New DataDynamics.ActiveReports.Label
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblHoraRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCedulas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFinca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPignorado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDaño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblHum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblImp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblIngreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLiquidar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblBarco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPila, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCertificados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOreado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtReal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtQQOreado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblDireccion, Me.LblRuc, Me.Label13, Me.LblLote})
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'LblDireccion
        '
        Me.LblDireccion.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDireccion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDireccion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion.Border.RightColor = System.Drawing.Color.Black
        Me.LblDireccion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion.Border.TopColor = System.Drawing.Color.Black
        Me.LblDireccion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDireccion.Height = 0.1875!
        Me.LblDireccion.HyperLink = Nothing
        Me.LblDireccion.Left = 8.6875!
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblDireccion.Text = ""
        Me.LblDireccion.Top = 1.625!
        Me.LblDireccion.Visible = False
        Me.LblDireccion.Width = 3.6875!
        '
        'LblRuc
        '
        Me.LblRuc.Border.BottomColor = System.Drawing.Color.Black
        Me.LblRuc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRuc.Border.LeftColor = System.Drawing.Color.Black
        Me.LblRuc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRuc.Border.RightColor = System.Drawing.Color.Black
        Me.LblRuc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRuc.Border.TopColor = System.Drawing.Color.Black
        Me.LblRuc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblRuc.Height = 0.1875!
        Me.LblRuc.HyperLink = Nothing
        Me.LblRuc.Left = 8.6875!
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Style = "ddo-char-set: 0; font-style: italic; font-size: 8.25pt; "
        Me.LblRuc.Text = ""
        Me.LblRuc.Top = 1.8125!
        Me.LblRuc.Visible = False
        Me.LblRuc.Width = 2.0!
        '
        'Label13
        '
        Me.Label13.Border.BottomColor = System.Drawing.Color.Black
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.LeftColor = System.Drawing.Color.Black
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.RightColor = System.Drawing.Color.Black
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.TopColor = System.Drawing.Color.Black
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Height = 0.1875!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 8.5625!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: left; font-weight: bold; "
        Me.Label13.Text = "Lote No."
        Me.Label13.Top = 1.125!
        Me.Label13.Visible = False
        Me.Label13.Width = 1.0!
        '
        'LblLote
        '
        Me.LblLote.Border.BottomColor = System.Drawing.Color.Black
        Me.LblLote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLote.Border.LeftColor = System.Drawing.Color.Black
        Me.LblLote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLote.Border.RightColor = System.Drawing.Color.Black
        Me.LblLote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLote.Border.TopColor = System.Drawing.Color.Black
        Me.LblLote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLote.Height = 0.1875!
        Me.LblLote.HyperLink = Nothing
        Me.LblLote.Left = 9.625!
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Style = "ddo-char-set: 0; font-size: 9.75pt; "
        Me.LblLote.Text = ""
        Me.LblLote.Top = 1.125!
        Me.LblLote.Visible = False
        Me.LblLote.Width = 1.5625!
        '
        'LblHora
        '
        Me.LblHora.Border.BottomColor = System.Drawing.Color.Black
        Me.LblHora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHora.Border.LeftColor = System.Drawing.Color.Black
        Me.LblHora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHora.Border.RightColor = System.Drawing.Color.Black
        Me.LblHora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHora.Border.TopColor = System.Drawing.Color.Black
        Me.LblHora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHora.Height = 0.1875!
        Me.LblHora.HyperLink = Nothing
        Me.LblHora.Left = 0.075!
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Style = "text-align: center; "
        Me.LblHora.Text = ""
        Me.LblHora.Top = 0.6250001!
        Me.LblHora.Width = 2.625!
        '
        'SubReportCertificado
        '
        Me.SubReportCertificado.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportCertificado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportCertificado.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportCertificado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportCertificado.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportCertificado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportCertificado.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportCertificado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportCertificado.CloseBorder = False
        Me.SubReportCertificado.Height = 0.1875!
        Me.SubReportCertificado.Left = 0.05!
        Me.SubReportCertificado.Name = "SubReportCertificado"
        Me.SubReportCertificado.Report = Nothing
        Me.SubReportCertificado.ReportName = "SubReport1"
        Me.SubReportCertificado.Top = 0.0!
        Me.SubReportCertificado.Width = 2.625!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox5, Me.TextBox1, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.TextBox10, Me.TextBox3, Me.TextBox11})
        Me.Detail1.Height = 0.21875!
        Me.Detail1.Name = "Detail1"
        '
        'TextBox2
        '
        Me.TextBox2.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox2.DataField = "Cantidad"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 0.32!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.52!
        Me.TextBox2.Visible = False
        Me.TextBox2.Width = 0.5!
        '
        'TextBox5
        '
        Me.TextBox5.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.DataField = "id_Eventos"
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 0.12!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.25!
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.DataField = "PesoKg"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.8!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.68!
        '
        'TextBox7
        '
        Me.TextBox7.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.DataField = "PesoNetoKg"
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 1.92!
        Me.TextBox7.MultiLine = False
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.6!
        '
        'TextBox8
        '
        Me.TextBox8.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.DataField = "Calidad_Cafe"
        Me.TextBox8.Height = 0.1875!
        Me.TextBox8.Left = 4.15!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Visible = False
        Me.TextBox8.Width = 0.375!
        '
        'TextBox9
        '
        Me.TextBox9.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.DataField = "Precio"
        Me.TextBox9.Height = 0.1875!
        Me.TextBox9.Left = 2.875!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Visible = False
        Me.TextBox9.Width = 0.5625!
        '
        'TextBox10
        '
        Me.TextBox10.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.DataField = "Estado"
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 3.65!
        Me.TextBox10.MultiLine = False
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Visible = False
        Me.TextBox10.Width = 0.5!
        '
        'TextBox3
        '
        Me.TextBox3.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox3.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox3.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox3.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox3.DataField = "Tara"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 1.48!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.4375!
        '
        'TextBox11
        '
        Me.TextBox11.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox11.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox11.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox11.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox11.DataField = "QQ"
        Me.TextBox11.Height = 0.1875!
        Me.TextBox11.Left = 0.36!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.4375!
        '
        'TextBox4
        '
        Me.TextBox4.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox4.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox4.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox4.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox4.DataField = "Cod_Productos"
        Me.TextBox4.Height = 0.2105263!
        Me.TextBox4.Left = 7.0!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.5!
        Me.TextBox4.Visible = False
        Me.TextBox4.Width = 0.6842105!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'TxtFinal
        '
        Me.TxtFinal.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFinal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFinal.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFinal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFinal.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFinal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFinal.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFinal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFinal.Height = 1.92!
        Me.TxtFinal.Left = 0.125!
        Me.TxtFinal.Name = "TxtFinal"
        Me.TxtFinal.Style = "ddo-char-set: 0; text-align: justify; font-size: 8.25pt; "
        Me.TxtFinal.Text = Nothing
        Me.TxtFinal.Top = 2.85!
        Me.TxtFinal.Width = 2.48!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblOrderNum, Me.lblOrderDate, Me.ImgLogo, Me.LblEncabezado, Me.LblOrden, Me.LblFechaOrden, Me.LblTipoCompra, Me.Label6, Me.LblNombres, Me.LblCosecha, Me.LblLocalidad, Me.LblHoraRecibo, Me.Label38, Me.Label35, Me.LblCedulas, Me.Label39, Me.LblFinca, Me.LblOriginal, Me.Label61, Me.LblPignorado, Me.Label40, Me.Label41, Me.Label42, Me.LblEstado, Me.LblCalidad, Me.Label45, Me.LblDaño, Me.LblCategoria, Me.Label48, Me.Label49, Me.LblHum, Me.Label51, Me.LblImp, Me.Label53, Me.LblIngreso, Me.Label55, Me.Label56, Me.LblCompra, Me.LblLiquidar, Me.Label59})
        Me.ReportHeader1.Height = 6.96875!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'lblOrderNum
        '
        Me.lblOrderNum.Border.BottomColor = System.Drawing.Color.Black
        Me.lblOrderNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderNum.Border.LeftColor = System.Drawing.Color.Black
        Me.lblOrderNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderNum.Border.RightColor = System.Drawing.Color.Black
        Me.lblOrderNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderNum.Border.TopColor = System.Drawing.Color.Black
        Me.lblOrderNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderNum.Height = 0.2399999!
        Me.lblOrderNum.HyperLink = Nothing
        Me.lblOrderNum.Left = 0.08!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.lblOrderNum.Text = "Recibo No:"
        Me.lblOrderNum.Top = 2.96!
        Me.lblOrderNum.Width = 0.64!
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Border.BottomColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.LeftColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.RightColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Border.TopColor = System.Drawing.Color.Black
        Me.lblOrderDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblOrderDate.Height = 0.2399999!
        Me.lblOrderDate.HyperLink = Nothing
        Me.lblOrderDate.Left = 0.225!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.lblOrderDate.Text = "Fecha :"
        Me.lblOrderDate.Top = 2.6!
        Me.lblOrderDate.Width = 0.48!
        '
        'ImgLogo
        '
        Me.ImgLogo.Border.BottomColor = System.Drawing.Color.Black
        Me.ImgLogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgLogo.Border.LeftColor = System.Drawing.Color.Black
        Me.ImgLogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgLogo.Border.RightColor = System.Drawing.Color.Black
        Me.ImgLogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgLogo.Border.TopColor = System.Drawing.Color.Black
        Me.ImgLogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ImgLogo.Height = 0.8!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.64!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.28!
        '
        'LblEncabezado
        '
        Me.LblEncabezado.Border.BottomColor = System.Drawing.Color.Black
        Me.LblEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado.Border.LeftColor = System.Drawing.Color.Black
        Me.LblEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado.Border.RightColor = System.Drawing.Color.Black
        Me.LblEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado.Border.TopColor = System.Drawing.Color.Black
        Me.LblEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEncabezado.Height = 0.48!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 0.0!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 12pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 1.0!
        Me.LblEncabezado.Width = 2.56!
        '
        'LblOrden
        '
        Me.LblOrden.Border.BottomColor = System.Drawing.Color.Black
        Me.LblOrden.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrden.Border.LeftColor = System.Drawing.Color.Black
        Me.LblOrden.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrden.Border.RightColor = System.Drawing.Color.Black
        Me.LblOrden.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrden.Border.TopColor = System.Drawing.Color.Black
        Me.LblOrden.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrden.DataField = "NumeroReciboCafe"
        Me.LblOrden.Height = 0.2!
        Me.LblOrden.HyperLink = Nothing
        Me.LblOrden.Left = 0.76!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = ""
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 3.04!
        Me.LblOrden.Width = 1.04!
        '
        'LblFechaOrden
        '
        Me.LblFechaOrden.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.RightColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Border.TopColor = System.Drawing.Color.Black
        Me.LblFechaOrden.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaOrden.Height = 0.1999999!
        Me.LblFechaOrden.HyperLink = Nothing
        Me.LblFechaOrden.Left = 0.76!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = ""
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 2.6!
        Me.LblFechaOrden.Width = 1.08!
        '
        'LblTipoCompra
        '
        Me.LblTipoCompra.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTipoCompra.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoCompra.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTipoCompra.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoCompra.Border.RightColor = System.Drawing.Color.Black
        Me.LblTipoCompra.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoCompra.Border.TopColor = System.Drawing.Color.Black
        Me.LblTipoCompra.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoCompra.Height = 0.28!
        Me.LblTipoCompra.HyperLink = Nothing
        Me.LblTipoCompra.Left = 0.0!
        Me.LblTipoCompra.Name = "LblTipoCompra"
        Me.LblTipoCompra.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 12pt; "
        Me.LblTipoCompra.Text = "Recepción"
        Me.LblTipoCompra.Top = 1.56!
        Me.LblTipoCompra.Width = 2.56!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Height = 0.2399998!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.08!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label6.Text = "Proveedor:"
        Me.Label6.Top = 3.2!
        Me.Label6.Width = 0.64!
        '
        'LblNombres
        '
        Me.LblNombres.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNombres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNombres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.RightColor = System.Drawing.Color.Black
        Me.LblNombres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Border.TopColor = System.Drawing.Color.Black
        Me.LblNombres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNombres.Height = 0.3199999!
        Me.LblNombres.HyperLink = Nothing
        Me.LblNombres.Left = 0.76!
        Me.LblNombres.Name = "LblNombres"
        Me.LblNombres.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblNombres.Text = ""
        Me.LblNombres.Top = 3.28!
        Me.LblNombres.Width = 1.72!
        '
        'LblCosecha
        '
        Me.LblCosecha.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCosecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCosecha.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCosecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCosecha.Border.RightColor = System.Drawing.Color.Black
        Me.LblCosecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCosecha.Border.TopColor = System.Drawing.Color.Black
        Me.LblCosecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCosecha.Height = 0.1999999!
        Me.LblCosecha.HyperLink = Nothing
        Me.LblCosecha.Left = 0.0!
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Style = "text-align: center; "
        Me.LblCosecha.Text = ""
        Me.LblCosecha.Top = 1.84!
        Me.LblCosecha.Width = 2.56!
        '
        'LblLocalidad
        '
        Me.LblLocalidad.Border.BottomColor = System.Drawing.Color.Black
        Me.LblLocalidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLocalidad.Border.LeftColor = System.Drawing.Color.Black
        Me.LblLocalidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLocalidad.Border.RightColor = System.Drawing.Color.Black
        Me.LblLocalidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLocalidad.Border.TopColor = System.Drawing.Color.Black
        Me.LblLocalidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLocalidad.Height = 0.2399999!
        Me.LblLocalidad.HyperLink = Nothing
        Me.LblLocalidad.Left = 0.0!
        Me.LblLocalidad.Name = "LblLocalidad"
        Me.LblLocalidad.Style = "text-align: center; "
        Me.LblLocalidad.Text = ""
        Me.LblLocalidad.Top = 2.0!
        Me.LblLocalidad.Width = 2.56!
        '
        'LblHoraRecibo
        '
        Me.LblHoraRecibo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblHoraRecibo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHoraRecibo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblHoraRecibo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHoraRecibo.Border.RightColor = System.Drawing.Color.Black
        Me.LblHoraRecibo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHoraRecibo.Border.TopColor = System.Drawing.Color.Black
        Me.LblHoraRecibo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHoraRecibo.Height = 0.2!
        Me.LblHoraRecibo.HyperLink = Nothing
        Me.LblHoraRecibo.Left = 0.76!
        Me.LblHoraRecibo.Name = "LblHoraRecibo"
        Me.LblHoraRecibo.Style = ""
        Me.LblHoraRecibo.Text = ""
        Me.LblHoraRecibo.Top = 2.8!
        Me.LblHoraRecibo.Width = 1.04!
        '
        'Label38
        '
        Me.Label38.Border.BottomColor = System.Drawing.Color.Black
        Me.Label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.LeftColor = System.Drawing.Color.Black
        Me.Label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.RightColor = System.Drawing.Color.Black
        Me.Label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.TopColor = System.Drawing.Color.Black
        Me.Label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Height = 0.2!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.2!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label38.Text = "Hora :"
        Me.Label38.Top = 2.8!
        Me.Label38.Width = 0.52!
        '
        'Label35
        '
        Me.Label35.Border.BottomColor = System.Drawing.Color.Black
        Me.Label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.LeftColor = System.Drawing.Color.Black
        Me.Label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.RightColor = System.Drawing.Color.Black
        Me.Label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.TopColor = System.Drawing.Color.Black
        Me.Label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Height = 0.2399999!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 0.08!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label35.Text = "Cedula:"
        Me.Label35.Top = 3.6!
        Me.Label35.Width = 0.64!
        '
        'LblCedulas
        '
        Me.LblCedulas.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCedulas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedulas.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCedulas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedulas.Border.RightColor = System.Drawing.Color.Black
        Me.LblCedulas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedulas.Border.TopColor = System.Drawing.Color.Black
        Me.LblCedulas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedulas.Height = 0.1999999!
        Me.LblCedulas.HyperLink = Nothing
        Me.LblCedulas.Left = 0.76!
        Me.LblCedulas.Name = "LblCedulas"
        Me.LblCedulas.Style = ""
        Me.LblCedulas.Text = ""
        Me.LblCedulas.Top = 3.6!
        Me.LblCedulas.Width = 1.72!
        '
        'Label39
        '
        Me.Label39.Border.BottomColor = System.Drawing.Color.Black
        Me.Label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Border.LeftColor = System.Drawing.Color.Black
        Me.Label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Border.RightColor = System.Drawing.Color.Black
        Me.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Border.TopColor = System.Drawing.Color.Black
        Me.Label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Height = 0.2400001!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 0.08!
        Me.Label39.Name = "Label39"
        Me.Label39.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label39.Text = "Finca:"
        Me.Label39.Top = 3.84!
        Me.Label39.Width = 0.64!
        '
        'LblFinca
        '
        Me.LblFinca.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFinca.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFinca.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFinca.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFinca.Border.RightColor = System.Drawing.Color.Black
        Me.LblFinca.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFinca.Border.TopColor = System.Drawing.Color.Black
        Me.LblFinca.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFinca.Height = 0.2250001!
        Me.LblFinca.HyperLink = Nothing
        Me.LblFinca.Left = 0.75!
        Me.LblFinca.Name = "LblFinca"
        Me.LblFinca.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblFinca.Text = ""
        Me.LblFinca.Top = 3.825!
        Me.LblFinca.Width = 1.725!
        '
        'LblOriginal
        '
        Me.LblOriginal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblOriginal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOriginal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblOriginal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOriginal.Border.RightColor = System.Drawing.Color.Black
        Me.LblOriginal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOriginal.Border.TopColor = System.Drawing.Color.Black
        Me.LblOriginal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOriginal.Height = 0.2799999!
        Me.LblOriginal.HyperLink = Nothing
        Me.LblOriginal.Left = 0.0!
        Me.LblOriginal.Name = "LblOriginal"
        Me.LblOriginal.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.LblOriginal.Text = ""
        Me.LblOriginal.Top = 2.2!
        Me.LblOriginal.Width = 2.56!
        '
        'Label61
        '
        Me.Label61.Border.BottomColor = System.Drawing.Color.Black
        Me.Label61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label61.Border.LeftColor = System.Drawing.Color.Black
        Me.Label61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label61.Border.RightColor = System.Drawing.Color.Black
        Me.Label61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label61.Border.TopColor = System.Drawing.Color.Black
        Me.Label61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label61.Height = 0.1999999!
        Me.Label61.HyperLink = Nothing
        Me.Label61.Left = 0.075!
        Me.Label61.Name = "Label61"
        Me.Label61.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label61.Text = "Pignorado"
        Me.Label61.Top = 4.1!
        Me.Label61.Width = 0.64!
        '
        'LblPignorado
        '
        Me.LblPignorado.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPignorado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPignorado.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPignorado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPignorado.Border.RightColor = System.Drawing.Color.Black
        Me.LblPignorado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPignorado.Border.TopColor = System.Drawing.Color.Black
        Me.LblPignorado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPignorado.Height = 0.2000001!
        Me.LblPignorado.HyperLink = Nothing
        Me.LblPignorado.Left = 0.75!
        Me.LblPignorado.Name = "LblPignorado"
        Me.LblPignorado.Style = ""
        Me.LblPignorado.Text = ""
        Me.LblPignorado.Top = 4.075!
        Me.LblPignorado.Width = 1.725!
        '
        'Label40
        '
        Me.Label40.Border.BottomColor = System.Drawing.Color.Black
        Me.Label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label40.Border.LeftColor = System.Drawing.Color.Black
        Me.Label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.RightColor = System.Drawing.Color.Black
        Me.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.TopColor = System.Drawing.Color.Black
        Me.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Height = 0.1599999!
        Me.Label40.HyperLink = Nothing
        Me.Label40.Left = 0.075!
        Me.Label40.Name = "Label40"
        Me.Label40.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.Label40.Text = "DATOS CAFE"
        Me.Label40.Top = 4.375!
        Me.Label40.Width = 2.52!
        '
        'Label41
        '
        Me.Label41.Border.BottomColor = System.Drawing.Color.Black
        Me.Label41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label41.Border.LeftColor = System.Drawing.Color.Black
        Me.Label41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label41.Border.RightColor = System.Drawing.Color.Black
        Me.Label41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label41.Border.TopColor = System.Drawing.Color.Black
        Me.Label41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label41.Height = 0.2400001!
        Me.Label41.HyperLink = Nothing
        Me.Label41.Left = 0.075!
        Me.Label41.Name = "Label41"
        Me.Label41.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label41.Text = "Estado:"
        Me.Label41.Top = 5.0!
        Me.Label41.Width = 0.65!
        '
        'Label42
        '
        Me.Label42.Border.BottomColor = System.Drawing.Color.Black
        Me.Label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label42.Border.LeftColor = System.Drawing.Color.Black
        Me.Label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label42.Border.RightColor = System.Drawing.Color.Black
        Me.Label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label42.Border.TopColor = System.Drawing.Color.Black
        Me.Label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label42.Height = 0.25!
        Me.Label42.HyperLink = Nothing
        Me.Label42.Left = 0.075!
        Me.Label42.Name = "Label42"
        Me.Label42.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label42.Text = "Calidad:"
        Me.Label42.Top = 4.55!
        Me.Label42.Width = 0.65!
        '
        'LblEstado
        '
        Me.LblEstado.Border.BottomColor = System.Drawing.Color.Black
        Me.LblEstado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEstado.Border.LeftColor = System.Drawing.Color.Black
        Me.LblEstado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEstado.Border.RightColor = System.Drawing.Color.Black
        Me.LblEstado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEstado.Border.TopColor = System.Drawing.Color.Black
        Me.LblEstado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEstado.Height = 0.2000001!
        Me.LblEstado.HyperLink = Nothing
        Me.LblEstado.Left = 0.75!
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.LblEstado.Text = ""
        Me.LblEstado.Top = 5.025!
        Me.LblEstado.Width = 1.08!
        '
        'LblCalidad
        '
        Me.LblCalidad.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCalidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCalidad.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCalidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCalidad.Border.RightColor = System.Drawing.Color.Black
        Me.LblCalidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCalidad.Border.TopColor = System.Drawing.Color.Black
        Me.LblCalidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCalidad.Height = 0.2!
        Me.LblCalidad.HyperLink = Nothing
        Me.LblCalidad.Left = 0.75!
        Me.LblCalidad.Name = "LblCalidad"
        Me.LblCalidad.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.LblCalidad.Text = ""
        Me.LblCalidad.Top = 4.55!
        Me.LblCalidad.Width = 1.08!
        '
        'Label45
        '
        Me.Label45.Border.BottomColor = System.Drawing.Color.Black
        Me.Label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Border.LeftColor = System.Drawing.Color.Black
        Me.Label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Border.RightColor = System.Drawing.Color.Black
        Me.Label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Border.TopColor = System.Drawing.Color.Black
        Me.Label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Height = 0.24!
        Me.Label45.HyperLink = Nothing
        Me.Label45.Left = 0.075!
        Me.Label45.Name = "Label45"
        Me.Label45.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label45.Text = "Daño:"
        Me.Label45.Top = 5.275!
        Me.Label45.Width = 0.64!
        '
        'LblDaño
        '
        Me.LblDaño.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDaño.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDaño.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDaño.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDaño.Border.RightColor = System.Drawing.Color.Black
        Me.LblDaño.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDaño.Border.TopColor = System.Drawing.Color.Black
        Me.LblDaño.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDaño.Height = 0.24!
        Me.LblDaño.HyperLink = Nothing
        Me.LblDaño.Left = 0.75!
        Me.LblDaño.Name = "LblDaño"
        Me.LblDaño.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.LblDaño.Text = ""
        Me.LblDaño.Top = 5.275!
        Me.LblDaño.Width = 1.08!
        '
        'LblCategoria
        '
        Me.LblCategoria.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCategoria.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCategoria.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCategoria.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCategoria.Border.RightColor = System.Drawing.Color.Black
        Me.LblCategoria.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCategoria.Border.TopColor = System.Drawing.Color.Black
        Me.LblCategoria.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCategoria.Height = 0.2399999!
        Me.LblCategoria.HyperLink = Nothing
        Me.LblCategoria.Left = 0.75!
        Me.LblCategoria.Name = "LblCategoria"
        Me.LblCategoria.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.LblCategoria.Text = ""
        Me.LblCategoria.Top = 4.8!
        Me.LblCategoria.Width = 1.08!
        '
        'Label48
        '
        Me.Label48.Border.BottomColor = System.Drawing.Color.Black
        Me.Label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label48.Border.LeftColor = System.Drawing.Color.Black
        Me.Label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label48.Border.RightColor = System.Drawing.Color.Black
        Me.Label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label48.Border.TopColor = System.Drawing.Color.Black
        Me.Label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label48.Height = 0.1999999!
        Me.Label48.HyperLink = Nothing
        Me.Label48.Left = 0.075!
        Me.Label48.Name = "Label48"
        Me.Label48.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label48.Text = "Categoria:"
        Me.Label48.Top = 4.8!
        Me.Label48.Width = 0.65!
        '
        'Label49
        '
        Me.Label49.Border.BottomColor = System.Drawing.Color.Black
        Me.Label49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label49.Border.LeftColor = System.Drawing.Color.Black
        Me.Label49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label49.Border.RightColor = System.Drawing.Color.Black
        Me.Label49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label49.Border.TopColor = System.Drawing.Color.Black
        Me.Label49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label49.Height = 0.2000002!
        Me.Label49.HyperLink = Nothing
        Me.Label49.Left = 0.075!
        Me.Label49.Name = "Label49"
        Me.Label49.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label49.Text = "%Hum:"
        Me.Label49.Top = 5.525!
        Me.Label49.Width = 0.65!
        '
        'LblHum
        '
        Me.LblHum.Border.BottomColor = System.Drawing.Color.Black
        Me.LblHum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHum.Border.LeftColor = System.Drawing.Color.Black
        Me.LblHum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHum.Border.RightColor = System.Drawing.Color.Black
        Me.LblHum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHum.Border.TopColor = System.Drawing.Color.Black
        Me.LblHum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblHum.Height = 0.1875!
        Me.LblHum.HyperLink = Nothing
        Me.LblHum.Left = 0.8!
        Me.LblHum.Name = "LblHum"
        Me.LblHum.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.LblHum.Text = ""
        Me.LblHum.Top = 5.525!
        Me.LblHum.Width = 1.0625!
        '
        'Label51
        '
        Me.Label51.Border.BottomColor = System.Drawing.Color.Black
        Me.Label51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label51.Border.LeftColor = System.Drawing.Color.Black
        Me.Label51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label51.Border.RightColor = System.Drawing.Color.Black
        Me.Label51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label51.Border.TopColor = System.Drawing.Color.Black
        Me.Label51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label51.Height = 0.2000002!
        Me.Label51.HyperLink = Nothing
        Me.Label51.Left = 0.05!
        Me.Label51.Name = "Label51"
        Me.Label51.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label51.Text = "%Imp:"
        Me.Label51.Top = 5.75!
        Me.Label51.Width = 0.65!
        '
        'LblImp
        '
        Me.LblImp.Border.BottomColor = System.Drawing.Color.Black
        Me.LblImp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImp.Border.LeftColor = System.Drawing.Color.Black
        Me.LblImp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImp.Border.RightColor = System.Drawing.Color.Black
        Me.LblImp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImp.Border.TopColor = System.Drawing.Color.Black
        Me.LblImp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblImp.Height = 0.1875!
        Me.LblImp.HyperLink = Nothing
        Me.LblImp.Left = 0.8!
        Me.LblImp.Name = "LblImp"
        Me.LblImp.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.LblImp.Text = ""
        Me.LblImp.Top = 5.75!
        Me.LblImp.Width = 1.0625!
        '
        'Label53
        '
        Me.Label53.Border.BottomColor = System.Drawing.Color.Black
        Me.Label53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label53.Border.LeftColor = System.Drawing.Color.Black
        Me.Label53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label53.Border.RightColor = System.Drawing.Color.Black
        Me.Label53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label53.Border.TopColor = System.Drawing.Color.Black
        Me.Label53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label53.Height = 0.2!
        Me.Label53.HyperLink = Nothing
        Me.Label53.Left = 0.05!
        Me.Label53.Name = "Label53"
        Me.Label53.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.Label53.Text = "GENERALES RECIBO"
        Me.Label53.Top = 5.975!
        Me.Label53.Width = 2.525!
        '
        'LblIngreso
        '
        Me.LblIngreso.Border.BottomColor = System.Drawing.Color.Black
        Me.LblIngreso.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIngreso.Border.LeftColor = System.Drawing.Color.Black
        Me.LblIngreso.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIngreso.Border.RightColor = System.Drawing.Color.Black
        Me.LblIngreso.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIngreso.Border.TopColor = System.Drawing.Color.Black
        Me.LblIngreso.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblIngreso.Height = 0.1749999!
        Me.LblIngreso.HyperLink = Nothing
        Me.LblIngreso.Left = 0.8!
        Me.LblIngreso.Name = "LblIngreso"
        Me.LblIngreso.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblIngreso.Text = ""
        Me.LblIngreso.Top = 6.225!
        Me.LblIngreso.Width = 1.075!
        '
        'Label55
        '
        Me.Label55.Border.BottomColor = System.Drawing.Color.Black
        Me.Label55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label55.Border.LeftColor = System.Drawing.Color.Black
        Me.Label55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label55.Border.RightColor = System.Drawing.Color.Black
        Me.Label55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label55.Border.TopColor = System.Drawing.Color.Black
        Me.Label55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label55.Height = 0.1999999!
        Me.Label55.HyperLink = Nothing
        Me.Label55.Left = 0.05!
        Me.Label55.Name = "Label55"
        Me.Label55.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label55.Text = "Ingreso:"
        Me.Label55.Top = 6.225!
        Me.Label55.Width = 0.7!
        '
        'Label56
        '
        Me.Label56.Border.BottomColor = System.Drawing.Color.Black
        Me.Label56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label56.Border.LeftColor = System.Drawing.Color.Black
        Me.Label56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label56.Border.RightColor = System.Drawing.Color.Black
        Me.Label56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label56.Border.TopColor = System.Drawing.Color.Black
        Me.Label56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label56.Height = 0.175!
        Me.Label56.HyperLink = Nothing
        Me.Label56.Left = 0.05!
        Me.Label56.Name = "Label56"
        Me.Label56.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label56.Text = "Compra:"
        Me.Label56.Top = 6.425001!
        Me.Label56.Width = 0.7!
        '
        'LblCompra
        '
        Me.LblCompra.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCompra.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCompra.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCompra.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCompra.Border.RightColor = System.Drawing.Color.Black
        Me.LblCompra.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCompra.Border.TopColor = System.Drawing.Color.Black
        Me.LblCompra.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCompra.Height = 0.1875!
        Me.LblCompra.HyperLink = Nothing
        Me.LblCompra.Left = 0.8!
        Me.LblCompra.Name = "LblCompra"
        Me.LblCompra.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblCompra.Text = ""
        Me.LblCompra.Top = 6.425001!
        Me.LblCompra.Width = 1.0625!
        '
        'LblLiquidar
        '
        Me.LblLiquidar.Border.BottomColor = System.Drawing.Color.Black
        Me.LblLiquidar.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLiquidar.Border.LeftColor = System.Drawing.Color.Black
        Me.LblLiquidar.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLiquidar.Border.RightColor = System.Drawing.Color.Black
        Me.LblLiquidar.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLiquidar.Border.TopColor = System.Drawing.Color.Black
        Me.LblLiquidar.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblLiquidar.Height = 0.1875!
        Me.LblLiquidar.HyperLink = Nothing
        Me.LblLiquidar.Left = 0.8!
        Me.LblLiquidar.Name = "LblLiquidar"
        Me.LblLiquidar.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblLiquidar.Text = ""
        Me.LblLiquidar.Top = 6.675001!
        Me.LblLiquidar.Width = 1.0625!
        '
        'Label59
        '
        Me.Label59.Border.BottomColor = System.Drawing.Color.Black
        Me.Label59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label59.Border.LeftColor = System.Drawing.Color.Black
        Me.Label59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label59.Border.RightColor = System.Drawing.Color.Black
        Me.Label59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label59.Border.TopColor = System.Drawing.Color.Black
        Me.Label59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label59.Height = 0.1999998!
        Me.Label59.HyperLink = Nothing
        Me.Label59.Left = 0.05!
        Me.Label59.Name = "Label59"
        Me.Label59.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label59.Text = "Liquidar:"
        Me.Label59.Top = 6.675001!
        Me.Label59.Width = 0.7250001!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblProductID, Me.Label2, Me.LblApellidos, Me.Label5, Me.Line2, Me.LblBodegas, Me.LblBarco, Me.LblConductor, Me.Label8, Me.Label9, Me.LblOrigen, Me.Label10, Me.Label11, Me.LblPila, Me.Label12, Me.LblPlaca, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.Label23, Me.Label24, Me.Label25, Me.Label26, Me.Label27, Me.Label28, Me.Label29, Me.Label30, Me.Label31, Me.Label32, Me.Label33, Me.Label34, Me.TextBox4, Me.Label1, Me.Label3, Me.Label4, Me.Label7, Me.Label37, Me.Label57, Me.Label58, Me.SubReportCertificado, Me.LblHora, Me.Label60, Me.TxtCertificados, Me.lblQty})
        Me.GroupHeader1.DataField = "NumeroRecepcion"
        Me.GroupHeader1.Height = 1.229167!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblProductID
        '
        Me.lblProductID.Border.BottomColor = System.Drawing.Color.Black
        Me.lblProductID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.LeftColor = System.Drawing.Color.Black
        Me.lblProductID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.RightColor = System.Drawing.Color.Black
        Me.lblProductID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Border.TopColor = System.Drawing.Color.Black
        Me.lblProductID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblProductID.Height = 0.2105263!
        Me.lblProductID.HyperLink = Nothing
        Me.lblProductID.Left = 6.9375!
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Style = "color: #000040; text-align: center; font-weight: bold; background-color: White; f" & _
            "ont-size: 8.5pt; "
        Me.lblProductID.Text = "Product ID"
        Me.lblProductID.Top = 0.1875!
        Me.lblProductID.Visible = False
        Me.lblProductID.Width = 0.6842105!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Height = 0.32!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.1!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: White; text-align: center; font-weight: bold; background-color: Black; fon" & _
            "t-size: 8.5pt; "
        Me.Label2.Text = "Pd"
        Me.Label2.Top = 0.875!
        Me.Label2.Width = 0.25!
        '
        'LblApellidos
        '
        Me.LblApellidos.Border.BottomColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.LeftColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.RightColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Border.TopColor = System.Drawing.Color.Black
        Me.LblApellidos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblApellidos.Height = 0.2105263!
        Me.LblApellidos.HyperLink = Nothing
        Me.LblApellidos.Left = 9.125!
        Me.LblApellidos.Name = "LblApellidos"
        Me.LblApellidos.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblApellidos.Text = ""
        Me.LblApellidos.Top = 0.25!
        Me.LblApellidos.Visible = False
        Me.LblApellidos.Width = 1.526316!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 8.0!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: #000040; text-align: left; font-weight: bold; background-color: White; fon" & _
            "t-size: 8.5pt; "
        Me.Label5.Text = "Bodega"
        Me.Label5.Top = 0.8125!
        Me.Label5.Visible = False
        Me.Label5.Width = 0.6875!
        '
        'Line2
        '
        Me.Line2.Border.BottomColor = System.Drawing.Color.Black
        Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.LeftColor = System.Drawing.Color.Black
        Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.RightColor = System.Drawing.Color.Black
        Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.TopColor = System.Drawing.Color.Black
        Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 7.875!
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.0!
        Me.Line2.Visible = False
        Me.Line2.Width = 1.5625!
        Me.Line2.X1 = 7.875!
        Me.Line2.X2 = 9.4375!
        Me.Line2.Y1 = 1.0!
        Me.Line2.Y2 = 1.0!
        '
        'LblBodegas
        '
        Me.LblBodegas.Border.BottomColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.LeftColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.RightColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Border.TopColor = System.Drawing.Color.Black
        Me.LblBodegas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBodegas.Height = 0.1875!
        Me.LblBodegas.HyperLink = Nothing
        Me.LblBodegas.Left = 8.6875!
        Me.LblBodegas.Name = "LblBodegas"
        Me.LblBodegas.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblBodegas.Text = ""
        Me.LblBodegas.Top = 0.8125!
        Me.LblBodegas.Visible = False
        Me.LblBodegas.Width = 1.25!
        '
        'LblBarco
        '
        Me.LblBarco.Border.BottomColor = System.Drawing.Color.Black
        Me.LblBarco.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBarco.Border.LeftColor = System.Drawing.Color.Black
        Me.LblBarco.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBarco.Border.RightColor = System.Drawing.Color.Black
        Me.LblBarco.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBarco.Border.TopColor = System.Drawing.Color.Black
        Me.LblBarco.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblBarco.Height = 0.2105263!
        Me.LblBarco.HyperLink = Nothing
        Me.LblBarco.Left = 9.125!
        Me.LblBarco.Name = "LblBarco"
        Me.LblBarco.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.LblBarco.Text = ""
        Me.LblBarco.Top = 0.0625!
        Me.LblBarco.Visible = False
        Me.LblBarco.Width = 1.526316!
        '
        'LblConductor
        '
        Me.LblConductor.Border.BottomColor = System.Drawing.Color.Black
        Me.LblConductor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblConductor.Border.LeftColor = System.Drawing.Color.Black
        Me.LblConductor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblConductor.Border.RightColor = System.Drawing.Color.Black
        Me.LblConductor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblConductor.Border.TopColor = System.Drawing.Color.Black
        Me.LblConductor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblConductor.Height = 0.1875!
        Me.LblConductor.HyperLink = Nothing
        Me.LblConductor.Left = 8.6875!
        Me.LblConductor.Name = "LblConductor"
        Me.LblConductor.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblConductor.Text = ""
        Me.LblConductor.Top = 1.0625!
        Me.LblConductor.Visible = False
        Me.LblConductor.Width = 1.4375!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Height = 0.2105263!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 7.25!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label8.Text = "Origen"
        Me.Label8.Top = 1.5!
        Me.Label8.Visible = False
        Me.Label8.Width = 0.7368421!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 7.9375!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label9.Text = "Conductor"
        Me.Label9.Top = 1.0625!
        Me.Label9.Visible = False
        Me.Label9.Width = 0.6875!
        '
        'LblOrigen
        '
        Me.LblOrigen.Border.BottomColor = System.Drawing.Color.Black
        Me.LblOrigen.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrigen.Border.LeftColor = System.Drawing.Color.Black
        Me.LblOrigen.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrigen.Border.RightColor = System.Drawing.Color.Black
        Me.LblOrigen.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrigen.Border.TopColor = System.Drawing.Color.Black
        Me.LblOrigen.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblOrigen.Height = 0.2105264!
        Me.LblOrigen.HyperLink = Nothing
        Me.LblOrigen.Left = 9.625!
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblOrigen.Text = ""
        Me.LblOrigen.Top = 0.625!
        Me.LblOrigen.Visible = False
        Me.LblOrigen.Width = 2.736842!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 7.9375!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label10.Text = "Cedula"
        Me.Label10.Top = 1.3125!
        Me.Label10.Visible = False
        Me.Label10.Width = 0.6875!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Height = 0.2105263!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 7.25!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label11.Text = "Pila"
        Me.Label11.Top = 1.75!
        Me.Label11.Visible = False
        Me.Label11.Width = 0.7368421!
        '
        'LblPila
        '
        Me.LblPila.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPila.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPila.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPila.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPila.Border.RightColor = System.Drawing.Color.Black
        Me.LblPila.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPila.Border.TopColor = System.Drawing.Color.Black
        Me.LblPila.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPila.Height = 0.2105262!
        Me.LblPila.HyperLink = Nothing
        Me.LblPila.Left = 9.75!
        Me.LblPila.Name = "LblPila"
        Me.LblPila.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblPila.Text = ""
        Me.LblPila.Top = 1.1875!
        Me.LblPila.Visible = False
        Me.LblPila.Width = 2.736842!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 7.9375!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label12.Text = "Placa"
        Me.Label12.Top = 1.5625!
        Me.Label12.Visible = False
        Me.Label12.Width = 0.6875!
        '
        'LblPlaca
        '
        Me.LblPlaca.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPlaca.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPlaca.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPlaca.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPlaca.Border.RightColor = System.Drawing.Color.Black
        Me.LblPlaca.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPlaca.Border.TopColor = System.Drawing.Color.Black
        Me.LblPlaca.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblPlaca.Height = 0.1875!
        Me.LblPlaca.HyperLink = Nothing
        Me.LblPlaca.Left = 8.6875!
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblPlaca.Text = ""
        Me.LblPlaca.Top = 1.5625!
        Me.LblPlaca.Visible = False
        Me.LblPlaca.Width = 1.4375!
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Height = 0.2105263!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 7.25!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label14.Text = "Origen"
        Me.Label14.Top = 1.5!
        Me.Label14.Visible = False
        Me.Label14.Width = 0.7368421!
        '
        'Label15
        '
        Me.Label15.Border.BottomColor = System.Drawing.Color.Black
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.LeftColor = System.Drawing.Color.Black
        Me.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.RightColor = System.Drawing.Color.Black
        Me.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.TopColor = System.Drawing.Color.Black
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Height = 0.2105263!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 7.9375!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label15.Text = "Pila"
        Me.Label15.Top = 0.5625!
        Me.Label15.Visible = False
        Me.Label15.Width = 0.7368421!
        '
        'Label16
        '
        Me.Label16.Border.BottomColor = System.Drawing.Color.Black
        Me.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.LeftColor = System.Drawing.Color.Black
        Me.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.RightColor = System.Drawing.Color.Black
        Me.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.TopColor = System.Drawing.Color.Black
        Me.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Height = 0.2105264!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 8.6875!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label16.Text = ""
        Me.Label16.Top = 0.5!
        Me.Label16.Visible = False
        Me.Label16.Width = 2.736842!
        '
        'Label17
        '
        Me.Label17.Border.BottomColor = System.Drawing.Color.Black
        Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Border.LeftColor = System.Drawing.Color.Black
        Me.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Border.RightColor = System.Drawing.Color.Black
        Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Border.TopColor = System.Drawing.Color.Black
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label17.Height = 0.2105262!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 9.0!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label17.Text = ""
        Me.Label17.Top = 0.875!
        Me.Label17.Visible = False
        Me.Label17.Width = 2.736842!
        '
        'Label18
        '
        Me.Label18.Border.BottomColor = System.Drawing.Color.Black
        Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.LeftColor = System.Drawing.Color.Black
        Me.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.RightColor = System.Drawing.Color.Black
        Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.TopColor = System.Drawing.Color.Black
        Me.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Height = 0.1875!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 7.9375!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label18.Text = "Conductor"
        Me.Label18.Top = 1.0625!
        Me.Label18.Visible = False
        Me.Label18.Width = 0.6875!
        '
        'Label19
        '
        Me.Label19.Border.BottomColor = System.Drawing.Color.Black
        Me.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Border.LeftColor = System.Drawing.Color.Black
        Me.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Border.RightColor = System.Drawing.Color.Black
        Me.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Border.TopColor = System.Drawing.Color.Black
        Me.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Height = 0.1875!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 8.6875!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label19.Text = ""
        Me.Label19.Top = 1.0625!
        Me.Label19.Visible = False
        Me.Label19.Width = 1.4375!
        '
        'Label20
        '
        Me.Label20.Border.BottomColor = System.Drawing.Color.Black
        Me.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.LeftColor = System.Drawing.Color.Black
        Me.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.RightColor = System.Drawing.Color.Black
        Me.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.TopColor = System.Drawing.Color.Black
        Me.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Height = 0.1875!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 8.6875!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label20.Text = ""
        Me.Label20.Top = 1.3125!
        Me.Label20.Visible = False
        Me.Label20.Width = 1.4375!
        '
        'Label21
        '
        Me.Label21.Border.BottomColor = System.Drawing.Color.Black
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.LeftColor = System.Drawing.Color.Black
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.RightColor = System.Drawing.Color.Black
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.TopColor = System.Drawing.Color.Black
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Height = 0.1875!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 7.9375!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label21.Text = "Cedula"
        Me.Label21.Top = 1.3125!
        Me.Label21.Visible = False
        Me.Label21.Width = 0.6875!
        '
        'Label22
        '
        Me.Label22.Border.BottomColor = System.Drawing.Color.Black
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Border.LeftColor = System.Drawing.Color.Black
        Me.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Border.RightColor = System.Drawing.Color.Black
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Border.TopColor = System.Drawing.Color.Black
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Height = 0.1875!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 7.9375!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label22.Text = "Placa"
        Me.Label22.Top = 1.5625!
        Me.Label22.Visible = False
        Me.Label22.Width = 0.6875!
        '
        'Label23
        '
        Me.Label23.Border.BottomColor = System.Drawing.Color.Black
        Me.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Border.LeftColor = System.Drawing.Color.Black
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Border.RightColor = System.Drawing.Color.Black
        Me.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Border.TopColor = System.Drawing.Color.Black
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label23.Height = 0.2105263!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 8.5!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label23.Text = "Origen"
        Me.Label23.Top = 1.625!
        Me.Label23.Visible = False
        Me.Label23.Width = 0.7368421!
        '
        'Label24
        '
        Me.Label24.Border.BottomColor = System.Drawing.Color.Black
        Me.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.LeftColor = System.Drawing.Color.Black
        Me.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.RightColor = System.Drawing.Color.Black
        Me.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.TopColor = System.Drawing.Color.Black
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Height = 0.2105263!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 8.5!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label24.Text = "Pila"
        Me.Label24.Top = 1.875!
        Me.Label24.Visible = False
        Me.Label24.Width = 0.7368421!
        '
        'Label25
        '
        Me.Label25.Border.BottomColor = System.Drawing.Color.Black
        Me.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Border.LeftColor = System.Drawing.Color.Black
        Me.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Border.RightColor = System.Drawing.Color.Black
        Me.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Border.TopColor = System.Drawing.Color.Black
        Me.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Height = 0.2105264!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 9.3125!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label25.Text = ""
        Me.Label25.Top = 1.625!
        Me.Label25.Visible = False
        Me.Label25.Width = 2.736842!
        '
        'Label26
        '
        Me.Label26.Border.BottomColor = System.Drawing.Color.Black
        Me.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label26.Border.LeftColor = System.Drawing.Color.Black
        Me.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label26.Border.RightColor = System.Drawing.Color.Black
        Me.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label26.Border.TopColor = System.Drawing.Color.Black
        Me.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label26.Height = 0.2105262!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 9.3125!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label26.Text = ""
        Me.Label26.Top = 1.875!
        Me.Label26.Visible = False
        Me.Label26.Width = 2.736842!
        '
        'Label27
        '
        Me.Label27.Border.BottomColor = System.Drawing.Color.Black
        Me.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label27.Border.LeftColor = System.Drawing.Color.Black
        Me.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label27.Border.RightColor = System.Drawing.Color.Black
        Me.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label27.Border.TopColor = System.Drawing.Color.Black
        Me.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label27.Height = 0.1875!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 7.9375!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label27.Text = "Conductor"
        Me.Label27.Top = 1.0625!
        Me.Label27.Visible = False
        Me.Label27.Width = 0.6875!
        '
        'Label28
        '
        Me.Label28.Border.BottomColor = System.Drawing.Color.Black
        Me.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label28.Border.LeftColor = System.Drawing.Color.Black
        Me.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label28.Border.RightColor = System.Drawing.Color.Black
        Me.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label28.Border.TopColor = System.Drawing.Color.Black
        Me.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label28.Height = 0.1875!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 8.6875!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label28.Text = ""
        Me.Label28.Top = 1.0625!
        Me.Label28.Visible = False
        Me.Label28.Width = 1.4375!
        '
        'Label29
        '
        Me.Label29.Border.BottomColor = System.Drawing.Color.Black
        Me.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label29.Border.LeftColor = System.Drawing.Color.Black
        Me.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label29.Border.RightColor = System.Drawing.Color.Black
        Me.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label29.Border.TopColor = System.Drawing.Color.Black
        Me.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label29.Height = 0.1875!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 8.6875!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label29.Text = ""
        Me.Label29.Top = 1.3125!
        Me.Label29.Visible = False
        Me.Label29.Width = 1.4375!
        '
        'Label30
        '
        Me.Label30.Border.BottomColor = System.Drawing.Color.Black
        Me.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label30.Border.LeftColor = System.Drawing.Color.Black
        Me.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label30.Border.RightColor = System.Drawing.Color.Black
        Me.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label30.Border.TopColor = System.Drawing.Color.Black
        Me.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label30.Height = 0.1875!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 7.9375!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label30.Text = "Cedula"
        Me.Label30.Top = 1.3125!
        Me.Label30.Visible = False
        Me.Label30.Width = 0.6875!
        '
        'Label31
        '
        Me.Label31.Border.BottomColor = System.Drawing.Color.Black
        Me.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.LeftColor = System.Drawing.Color.Black
        Me.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.RightColor = System.Drawing.Color.Black
        Me.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.TopColor = System.Drawing.Color.Black
        Me.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Height = 0.1875!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 7.9375!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label31.Text = "Placa"
        Me.Label31.Top = 1.5625!
        Me.Label31.Visible = False
        Me.Label31.Width = 0.6875!
        '
        'Label32
        '
        Me.Label32.Border.BottomColor = System.Drawing.Color.Black
        Me.Label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label32.Border.LeftColor = System.Drawing.Color.Black
        Me.Label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label32.Border.RightColor = System.Drawing.Color.Black
        Me.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label32.Border.TopColor = System.Drawing.Color.Black
        Me.Label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label32.Height = 0.1875!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 8.6875!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.Label32.Text = ""
        Me.Label32.Top = 1.5625!
        Me.Label32.Visible = False
        Me.Label32.Width = 1.4375!
        '
        'Label33
        '
        Me.Label33.Border.BottomColor = System.Drawing.Color.Black
        Me.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label33.Border.LeftColor = System.Drawing.Color.Black
        Me.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label33.Border.RightColor = System.Drawing.Color.Black
        Me.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label33.Border.TopColor = System.Drawing.Color.Black
        Me.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label33.Height = 0.2105263!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 8.0625!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; "
        Me.Label33.Text = "Origen"
        Me.Label33.Top = 0.125!
        Me.Label33.Visible = False
        Me.Label33.Width = 0.7368421!
        '
        'Label34
        '
        Me.Label34.Border.BottomColor = System.Drawing.Color.Black
        Me.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label34.Border.LeftColor = System.Drawing.Color.Black
        Me.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label34.Border.RightColor = System.Drawing.Color.Black
        Me.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label34.Border.TopColor = System.Drawing.Color.Black
        Me.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label34.Height = 0.2105264!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 7.9375!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label34.Text = ""
        Me.Label34.Top = 0.875!
        Me.Label34.Visible = False
        Me.Label34.Width = 2.736842!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.Black
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.LeftColor = System.Drawing.Color.Black
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.RightColor = System.Drawing.Color.Black
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopColor = System.Drawing.Color.Black
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Height = 0.32!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.8!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.Label1.Text = "Peso Bruto KG"
        Me.Label1.Top = 0.875!
        Me.Label1.Width = 0.64!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 2.875!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label3.Text = "Precio"
        Me.Label3.Top = 0.0!
        Me.Label3.Visible = False
        Me.Label3.Width = 0.5625!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Height = 0.3125!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 3.6!
        Me.Label4.MultiLine = False
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.Label4.Text = "Estado"
        Me.Label4.Top = 0.0!
        Me.Label4.Visible = False
        Me.Label4.Width = 0.4375!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.3125!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 4.025!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: #000040; ddo-char-set: 0; text-align: left; font-weight: bold; background-" & _
            "color: White; font-size: 8.25pt; "
        Me.Label7.Text = "Cdad"
        Me.Label7.Top = 0.0!
        Me.Label7.Visible = False
        Me.Label7.Width = 0.375!
        '
        'Label37
        '
        Me.Label37.Border.BottomColor = System.Drawing.Color.Black
        Me.Label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.LeftColor = System.Drawing.Color.Black
        Me.Label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.RightColor = System.Drawing.Color.Black
        Me.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Border.TopColor = System.Drawing.Color.Black
        Me.Label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label37.Height = 0.32!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 1.925!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.Label37.Text = "Peso Neto KG"
        Me.Label37.Top = 0.875!
        Me.Label37.Width = 0.6!
        '
        'Label57
        '
        Me.Label57.Border.BottomColor = System.Drawing.Color.Black
        Me.Label57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label57.Border.LeftColor = System.Drawing.Color.Black
        Me.Label57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label57.Border.RightColor = System.Drawing.Color.Black
        Me.Label57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label57.Border.TopColor = System.Drawing.Color.Black
        Me.Label57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label57.Height = 0.32!
        Me.Label57.HyperLink = Nothing
        Me.Label57.Left = 1.45!
        Me.Label57.Name = "Label57"
        Me.Label57.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.Label57.Text = "Tara"
        Me.Label57.Top = 0.875!
        Me.Label57.Width = 0.48!
        '
        'Label58
        '
        Me.Label58.Border.BottomColor = System.Drawing.Color.Black
        Me.Label58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label58.Border.LeftColor = System.Drawing.Color.Black
        Me.Label58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label58.Border.RightColor = System.Drawing.Color.Black
        Me.Label58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label58.Border.TopColor = System.Drawing.Color.Black
        Me.Label58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label58.Height = 0.32!
        Me.Label58.HyperLink = Nothing
        Me.Label58.Left = 0.35!
        Me.Label58.Name = "Label58"
        Me.Label58.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.Label58.Text = "Saco"
        Me.Label58.Top = 0.875!
        Me.Label58.Width = 0.4375!
        '
        'Label60
        '
        Me.Label60.Border.BottomColor = System.Drawing.Color.Black
        Me.Label60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label60.Border.LeftColor = System.Drawing.Color.Black
        Me.Label60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label60.Border.RightColor = System.Drawing.Color.Black
        Me.Label60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label60.Border.TopColor = System.Drawing.Color.Black
        Me.Label60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label60.Height = 0.1875!
        Me.Label60.HyperLink = Nothing
        Me.Label60.Left = 0.0!
        Me.Label60.Name = "Label60"
        Me.Label60.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label60.Text = "Certificados"
        Me.Label60.Top = 0.0!
        Me.Label60.Width = 2.625!
        '
        'TxtCertificados
        '
        Me.TxtCertificados.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCertificados.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCertificados.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCertificados.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCertificados.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCertificados.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCertificados.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCertificados.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCertificados.Height = 0.375!
        Me.TxtCertificados.Left = 0.05!
        Me.TxtCertificados.Name = "TxtCertificados"
        Me.TxtCertificados.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtCertificados.Text = Nothing
        Me.TxtCertificados.Top = 0.2!
        Me.TxtCertificados.Width = 2.525!
        '
        'lblQty
        '
        Me.lblQty.Border.BottomColor = System.Drawing.Color.Black
        Me.lblQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.LeftColor = System.Drawing.Color.Black
        Me.lblQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.RightColor = System.Drawing.Color.Black
        Me.lblQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Border.TopColor = System.Drawing.Color.Black
        Me.lblQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblQty.Height = 0.3125!
        Me.lblQty.HyperLink = Nothing
        Me.lblQty.Left = 1.1!
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Style = "color: #000040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 8.25pt; "
        Me.lblQty.Text = "Peso LB"
        Me.lblQty.Top = 1.85!
        Me.lblQty.Visible = False
        Me.lblQty.Width = 0.5!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblSubTotals, Me.TxtPesoNeto, Me.Label36, Me.Label43, Me.Label44, Me.Label46, Me.Label47, Me.Label50, Me.Label52, Me.TxtOreado, Me.TxtReal, Me.Label62, Me.TxtObservaciones, Me.Label63, Me.TxtQQOreado, Me.Label65, Me.Label54, Me.TxtFinal})
        Me.GroupFooter1.Height = 4.9375!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'lblSubTotals
        '
        Me.lblSubTotals.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.RightColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Border.TopColor = System.Drawing.Color.Black
        Me.lblSubTotals.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubTotals.Height = 0.1875!
        Me.lblSubTotals.HyperLink = Nothing
        Me.lblSubTotals.Left = 0.5!
        Me.lblSubTotals.Name = "lblSubTotals"
        Me.lblSubTotals.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.lblSubTotals.Text = "Peso  Neto"
        Me.lblSubTotals.Top = 0.0!
        Me.lblSubTotals.Width = 0.8125!
        '
        'TxtPesoNeto
        '
        Me.TxtPesoNeto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoNeto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoNeto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoNeto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoNeto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto.DataField = "PesoNetoKg"
        Me.TxtPesoNeto.Height = 0.1875!
        Me.TxtPesoNeto.Left = 1.3125!
        Me.TxtPesoNeto.Name = "TxtPesoNeto"
        Me.TxtPesoNeto.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9pt; font-famil" & _
            "y: Arial; "
        Me.TxtPesoNeto.SummaryGroup = "GroupHeader1"
        Me.TxtPesoNeto.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtPesoNeto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtPesoNeto.Text = Nothing
        Me.TxtPesoNeto.Top = 0.0!
        Me.TxtPesoNeto.Width = 0.75!
        '
        'Label36
        '
        Me.Label36.Border.BottomColor = System.Drawing.Color.Black
        Me.Label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label36.Border.LeftColor = System.Drawing.Color.Black
        Me.Label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label36.Border.RightColor = System.Drawing.Color.Black
        Me.Label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label36.Border.TopColor = System.Drawing.Color.Black
        Me.Label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label36.Height = 0.1875!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 2.125!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label36.Text = "Kg"
        Me.Label36.Top = 0.0!
        Me.Label36.Width = 0.3125!
        '
        'Label43
        '
        Me.Label43.Border.BottomColor = System.Drawing.Color.Black
        Me.Label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Border.LeftColor = System.Drawing.Color.Black
        Me.Label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Border.RightColor = System.Drawing.Color.Black
        Me.Label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Border.TopColor = System.Drawing.Color.Black
        Me.Label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Height = 0.1875!
        Me.Label43.HyperLink = Nothing
        Me.Label43.Left = 0.5!
        Me.Label43.Name = "Label43"
        Me.Label43.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label43.Text = "Eq.Oreado"
        Me.Label43.Top = 0.225!
        Me.Label43.Width = 0.8125!
        '
        'Label44
        '
        Me.Label44.Border.BottomColor = System.Drawing.Color.Black
        Me.Label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label44.Border.LeftColor = System.Drawing.Color.Black
        Me.Label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label44.Border.RightColor = System.Drawing.Color.Black
        Me.Label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label44.Border.TopColor = System.Drawing.Color.Black
        Me.Label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label44.Height = 0.1875!
        Me.Label44.HyperLink = Nothing
        Me.Label44.Left = 2.125!
        Me.Label44.Name = "Label44"
        Me.Label44.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label44.Text = "Kg"
        Me.Label44.Top = 0.2!
        Me.Label44.Width = 0.3125!
        '
        'Label46
        '
        Me.Label46.Border.BottomColor = System.Drawing.Color.Black
        Me.Label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label46.Border.LeftColor = System.Drawing.Color.Black
        Me.Label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label46.Border.RightColor = System.Drawing.Color.Black
        Me.Label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label46.Border.TopColor = System.Drawing.Color.Black
        Me.Label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label46.Height = 0.1875!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 0.3!
        Me.Label46.Name = "Label46"
        Me.Label46.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label46.Text = "Eq.Real"
        Me.Label46.Top = 2.6!
        Me.Label46.Visible = False
        Me.Label46.Width = 0.8125!
        '
        'Label47
        '
        Me.Label47.Border.BottomColor = System.Drawing.Color.Black
        Me.Label47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label47.Border.LeftColor = System.Drawing.Color.Black
        Me.Label47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label47.Border.RightColor = System.Drawing.Color.Black
        Me.Label47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label47.Border.TopColor = System.Drawing.Color.Black
        Me.Label47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label47.Height = 0.1875!
        Me.Label47.HyperLink = Nothing
        Me.Label47.Left = 1.925!
        Me.Label47.Name = "Label47"
        Me.Label47.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label47.Text = "Kg"
        Me.Label47.Top = 2.625!
        Me.Label47.Visible = False
        Me.Label47.Width = 0.3125!
        '
        'Label50
        '
        Me.Label50.Border.BottomColor = System.Drawing.Color.Black
        Me.Label50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label50.Border.LeftColor = System.Drawing.Color.Black
        Me.Label50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label50.Border.RightColor = System.Drawing.Color.Black
        Me.Label50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label50.Border.TopColor = System.Drawing.Color.Black
        Me.Label50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label50.Height = 0.2!
        Me.Label50.HyperLink = Nothing
        Me.Label50.Left = 0.075!
        Me.Label50.Name = "Label50"
        Me.Label50.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label50.Text = "Realizado Por"
        Me.Label50.Top = 2.425!
        Me.Label50.Width = 0.95!
        '
        'Label52
        '
        Me.Label52.Border.BottomColor = System.Drawing.Color.Black
        Me.Label52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label52.Border.LeftColor = System.Drawing.Color.Black
        Me.Label52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label52.Border.RightColor = System.Drawing.Color.Black
        Me.Label52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label52.Border.TopColor = System.Drawing.Color.Black
        Me.Label52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label52.Height = 0.3000001!
        Me.Label52.HyperLink = Nothing
        Me.Label52.Left = 1.5!
        Me.Label52.Name = "Label52"
        Me.Label52.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label52.Text = "Entregue Conforme"
        Me.Label52.Top = 2.425!
        Me.Label52.Width = 1.075!
        '
        'TxtOreado
        '
        Me.TxtOreado.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtOreado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOreado.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtOreado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOreado.Border.RightColor = System.Drawing.Color.Black
        Me.TxtOreado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOreado.Border.TopColor = System.Drawing.Color.Black
        Me.TxtOreado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOreado.Height = 0.2!
        Me.TxtOreado.HyperLink = Nothing
        Me.TxtOreado.Left = 1.325!
        Me.TxtOreado.Name = "TxtOreado"
        Me.TxtOreado.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtOreado.Text = ""
        Me.TxtOreado.Top = 0.2!
        Me.TxtOreado.Width = 0.75!
        '
        'TxtReal
        '
        Me.TxtReal.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtReal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtReal.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtReal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtReal.Border.RightColor = System.Drawing.Color.Black
        Me.TxtReal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtReal.Border.TopColor = System.Drawing.Color.Black
        Me.TxtReal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtReal.Height = 0.225!
        Me.TxtReal.HyperLink = Nothing
        Me.TxtReal.Left = 1.175!
        Me.TxtReal.Name = "TxtReal"
        Me.TxtReal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtReal.Text = ""
        Me.TxtReal.Top = 2.575!
        Me.TxtReal.Visible = False
        Me.TxtReal.Width = 0.725!
        '
        'Label62
        '
        Me.Label62.Border.BottomColor = System.Drawing.Color.Black
        Me.Label62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label62.Border.LeftColor = System.Drawing.Color.Black
        Me.Label62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label62.Border.RightColor = System.Drawing.Color.Black
        Me.Label62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label62.Border.TopColor = System.Drawing.Color.Black
        Me.Label62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label62.Height = 0.2!
        Me.Label62.HyperLink = Nothing
        Me.Label62.Left = 0.04!
        Me.Label62.Name = "Label62"
        Me.Label62.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label62.Text = "Observaciones"
        Me.Label62.Top = 0.72!
        Me.Label62.Width = 1.2!
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtObservaciones.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtObservaciones.Border.RightColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtObservaciones.Border.TopColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtObservaciones.Height = 0.52!
        Me.TxtObservaciones.Left = 0.075!
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtObservaciones.Text = Nothing
        Me.TxtObservaciones.Top = 0.95!
        Me.TxtObservaciones.Width = 2.6!
        '
        'Label63
        '
        Me.Label63.Border.BottomColor = System.Drawing.Color.Black
        Me.Label63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label63.Border.LeftColor = System.Drawing.Color.Black
        Me.Label63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label63.Border.RightColor = System.Drawing.Color.Black
        Me.Label63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label63.Border.TopColor = System.Drawing.Color.Black
        Me.Label63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label63.Height = 0.2!
        Me.Label63.HyperLink = Nothing
        Me.Label63.Left = 0.12!
        Me.Label63.Name = "Label63"
        Me.Label63.Style = "color: #000040; text-align: right; font-weight: bold; background-color: White; fo" & _
            "nt-size: 8.5pt; "
        Me.Label63.Text = "Eq.QQs Oreado"
        Me.Label63.Top = 0.44!
        Me.Label63.Width = 1.16!
        '
        'TxtQQOreado
        '
        Me.TxtQQOreado.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtQQOreado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtQQOreado.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtQQOreado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtQQOreado.Border.RightColor = System.Drawing.Color.Black
        Me.TxtQQOreado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtQQOreado.Border.TopColor = System.Drawing.Color.Black
        Me.TxtQQOreado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtQQOreado.Height = 0.2!
        Me.TxtQQOreado.HyperLink = Nothing
        Me.TxtQQOreado.Left = 1.32!
        Me.TxtQQOreado.Name = "TxtQQOreado"
        Me.TxtQQOreado.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtQQOreado.Text = ""
        Me.TxtQQOreado.Top = 0.44!
        Me.TxtQQOreado.Width = 0.75!
        '
        'Label65
        '
        Me.Label65.Border.BottomColor = System.Drawing.Color.Black
        Me.Label65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label65.Border.LeftColor = System.Drawing.Color.Black
        Me.Label65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label65.Border.RightColor = System.Drawing.Color.Black
        Me.Label65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label65.Border.TopColor = System.Drawing.Color.Black
        Me.Label65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label65.Height = 0.1875!
        Me.Label65.HyperLink = Nothing
        Me.Label65.Left = 2.12!
        Me.Label65.Name = "Label65"
        Me.Label65.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; "
        Me.Label65.Text = "QQs"
        Me.Label65.Top = 0.44!
        Me.Label65.Width = 0.3125!
        '
        'Label54
        '
        Me.Label54.Border.BottomColor = System.Drawing.Color.Black
        Me.Label54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label54.Border.LeftColor = System.Drawing.Color.Black
        Me.Label54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label54.Border.RightColor = System.Drawing.Color.Black
        Me.Label54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label54.Border.TopColor = System.Drawing.Color.Black
        Me.Label54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label54.Height = 0.3000001!
        Me.Label54.HyperLink = Nothing
        Me.Label54.Left = 1.55!
        Me.Label54.Name = "Label54"
        Me.Label54.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.Label54.Text = "Entregue Conforme"
        Me.Label54.Top = 1.0!
        Me.Label54.Visible = False
        Me.Label54.Width = 1.075!
        '
        'ArepBitacoraRecepcion
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=TRANSPORTE;Data Source=JUANBERMUDEZ\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.1!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.67625!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.LblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblHoraRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCedulas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFinca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPignorado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDaño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblHum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblImp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblIngreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLiquidar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblBarco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPila, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCertificados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoNeto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOreado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtReal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtQQOreado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents lblProductID As DataDynamics.ActiveReports.Label
    Private WithEvents lblQty As DataDynamics.ActiveReports.Label
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Private WithEvents lblSubTotals As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtPesoNeto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents LblRuc As DataDynamics.ActiveReports.Label
    Private WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLote As DataDynamics.ActiveReports.Label
    Friend WithEvents LblApellidos As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents LblBodegas As DataDynamics.ActiveReports.Label
    Friend WithEvents LblBarco As DataDynamics.ActiveReports.Label
    Friend WithEvents LblConductor As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrigen As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPila As DataDynamics.ActiveReports.Label
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPlaca As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label19 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label26 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label27 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label28 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label29 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label30 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label31 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label32 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label34 As DataDynamics.ActiveReports.Label
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label36 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblHora As DataDynamics.ActiveReports.Label
    Private WithEvents Label37 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label43 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label44 As DataDynamics.ActiveReports.Label
    Private WithEvents Label46 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label47 As DataDynamics.ActiveReports.Label
    Private WithEvents Label50 As DataDynamics.ActiveReports.Label
    Private WithEvents Label52 As DataDynamics.ActiveReports.Label
    Private WithEvents Label57 As DataDynamics.ActiveReports.Label
    Private WithEvents Label58 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtOreado As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtReal As DataDynamics.ActiveReports.Label
    Friend WithEvents SubReportCertificado As DataDynamics.ActiveReports.SubReport
    Private WithEvents Label60 As DataDynamics.ActiveReports.Label
    Private WithEvents Label62 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtObservaciones As DataDynamics.ActiveReports.TextBox
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoCompra As DataDynamics.ActiveReports.Label
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCosecha As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLocalidad As DataDynamics.ActiveReports.Label
    Friend WithEvents LblHoraRecibo As DataDynamics.ActiveReports.Label
    Private WithEvents Label38 As DataDynamics.ActiveReports.Label
    Private WithEvents Label35 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCedulas As DataDynamics.ActiveReports.Label
    Private WithEvents Label39 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFinca As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOriginal As DataDynamics.ActiveReports.Label
    Private WithEvents Label61 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPignorado As DataDynamics.ActiveReports.Label
    Private WithEvents Label40 As DataDynamics.ActiveReports.Label
    Private WithEvents Label41 As DataDynamics.ActiveReports.Label
    Private WithEvents Label42 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblEstado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCalidad As DataDynamics.ActiveReports.Label
    Private WithEvents Label45 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDaño As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCategoria As DataDynamics.ActiveReports.Label
    Private WithEvents Label48 As DataDynamics.ActiveReports.Label
    Private WithEvents Label49 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblHum As DataDynamics.ActiveReports.Label
    Private WithEvents Label51 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblImp As DataDynamics.ActiveReports.Label
    Private WithEvents Label53 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblIngreso As DataDynamics.ActiveReports.Label
    Private WithEvents Label55 As DataDynamics.ActiveReports.Label
    Private WithEvents Label56 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCompra As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLiquidar As DataDynamics.ActiveReports.Label
    Private WithEvents Label59 As DataDynamics.ActiveReports.Label
    Private WithEvents Label63 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtQQOreado As DataDynamics.ActiveReports.Label
    Friend WithEvents Label65 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCertificados As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFinal As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label54 As DataDynamics.ActiveReports.Label
End Class
