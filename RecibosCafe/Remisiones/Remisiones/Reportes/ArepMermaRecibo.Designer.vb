<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepMermaRecibo
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ArepMermaRecibo))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblCompañia = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.SubReportRecibos = New DataDynamics.ActiveReports.SubReport
        Me.Label13 = New DataDynamics.ActiveReports.Label
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
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport
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
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCompañia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblCompañia, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.SubReportRecibos, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.Label23, Me.SubReport1, Me.Label24, Me.Label25, Me.Label26, Me.Label27, Me.Label28, Me.Label29, Me.Label30, Me.Label31, Me.Label32, Me.Label33, Me.Label34, Me.SubReport2})
        Me.PageHeader1.Height = 4.40625!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.ImgLogo.Height = 0.7368421!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.157895!
        '
        'LblCompañia
        '
        Me.LblCompañia.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCompañia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCompañia.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCompañia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCompañia.Border.RightColor = System.Drawing.Color.Black
        Me.LblCompañia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCompañia.Border.TopColor = System.Drawing.Color.Black
        Me.LblCompañia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCompañia.Height = 0.2!
        Me.LblCompañia.HyperLink = Nothing
        Me.LblCompañia.Left = 1.222223!
        Me.LblCompañia.Name = "LblCompañia"
        Me.LblCompañia.Style = "color: Green; ddo-char-set: 0; font-style: italic; font-size: 11.25pt; "
        Me.LblCompañia.Text = "Exportadora Atlantic S.A"
        Me.LblCompañia.Top = 0.0!
        Me.LblCompañia.Width = 2.92!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.Black
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.LeftColor = System.Drawing.Color.Black
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.RightColor = System.Drawing.Color.Black
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.TopColor = System.Drawing.Color.Black
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.225!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; ddo-char-set: 0; font-weight: bold; font-style: normal; font-size: " & _
            "9pt; "
        Me.Label1.Text = "REPORTE MERMA  BODEGA VRS RECIBO VRS REMISION"
        Me.Label1.Top = 0.225!
        Me.Label1.Width = 4.5!
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
        Me.Label2.Height = 0.4!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.15!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: center; "
        Me.Label2.Text = "REGIONAL"
        Me.Label2.Top = 1.375!
        Me.Label2.Width = 0.925!
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
        Me.Label3.Height = 0.4!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 1.075!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; "
        Me.Label3.Text = "LOCALIDAD"
        Me.Label3.Top = 1.375!
        Me.Label3.Width = 0.875!
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
        Me.Label4.Height = 0.4!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 1.95!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: center; "
        Me.Label4.Text = "CALIDAD"
        Me.Label4.Top = 1.375!
        Me.Label4.Width = 0.675!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Height = 0.4!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 2.625!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: center; "
        Me.Label5.Text = "ESTADO FISICO"
        Me.Label5.Top = 1.375!
        Me.Label5.Width = 0.75!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.4!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 3.375!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; "
        Me.Label6.Text = "TIPO CAFE"
        Me.Label6.Top = 1.375!
        Me.Label6.Width = 0.75!
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
        Me.Label7.Height = 0.4!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 4.125!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; "
        Me.Label7.Text = "TIPO DE COMPRA"
        Me.Label7.Top = 1.375!
        Me.Label7.Width = 0.75!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label8.Height = 0.4!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 4.875!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; "
        Me.Label8.Text = "PESO BRUTO KG "
        Me.Label8.Top = 1.375!
        Me.Label8.Width = 0.85!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.4!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 6.6!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; "
        Me.Label9.Text = "MONTO PAGADO"
        Me.Label9.Top = 1.375!
        Me.Label9.Width = 0.925!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label10.Height = 0.4!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 5.725!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; "
        Me.Label10.Text = "PESO NETO KG RECIBO"
        Me.Label10.Top = 1.375!
        Me.Label10.Width = 0.8749998!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.15!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 9pt; "
        Me.Label11.Text = "CONSOLIDADO DE ENTRADA - FECHA DE RECEPCIO:"
        Me.Label11.Top = 1.175!
        Me.Label11.Width = 7.375!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.2!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.15!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 9pt; "
        Me.Label12.Text = "INFORMACION MODULO DE RECIBO"
        Me.Label12.Top = 0.9750001!
        Me.Label12.Width = 7.375!
        '
        'SubReportRecibos
        '
        Me.SubReportRecibos.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportRecibos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportRecibos.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportRecibos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportRecibos.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportRecibos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportRecibos.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportRecibos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportRecibos.CloseBorder = False
        Me.SubReportRecibos.Height = 0.25!
        Me.SubReportRecibos.Left = 0.125!
        Me.SubReportRecibos.Name = "SubReportRecibos"
        Me.SubReportRecibos.Report = Nothing
        Me.SubReportRecibos.ReportName = "SubReport1"
        Me.SubReportRecibos.Top = 1.775!
        Me.SubReportRecibos.Width = 7.425001!
        '
        'Label13
        '
        Me.Label13.Border.BottomColor = System.Drawing.Color.Black
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.LeftColor = System.Drawing.Color.Black
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.RightColor = System.Drawing.Color.Black
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.TopColor = System.Drawing.Color.Black
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.4!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.125!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: center; "
        Me.Label13.Text = "REGIONAL"
        Me.Label13.Top = 2.525!
        Me.Label13.Width = 0.925!
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Height = 0.4!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 1.05!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "text-align: center; "
        Me.Label14.Text = "LOCALIDAD"
        Me.Label14.Top = 2.525!
        Me.Label14.Width = 0.875!
        '
        'Label15
        '
        Me.Label15.Border.BottomColor = System.Drawing.Color.Black
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.LeftColor = System.Drawing.Color.Black
        Me.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.RightColor = System.Drawing.Color.Black
        Me.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.TopColor = System.Drawing.Color.Black
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Height = 0.4!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 1.925!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "text-align: center; "
        Me.Label15.Text = "CALIDAD"
        Me.Label15.Top = 2.525!
        Me.Label15.Width = 0.675!
        '
        'Label16
        '
        Me.Label16.Border.BottomColor = System.Drawing.Color.Black
        Me.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.LeftColor = System.Drawing.Color.Black
        Me.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.RightColor = System.Drawing.Color.Black
        Me.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Border.TopColor = System.Drawing.Color.Black
        Me.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Height = 0.4!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 2.6!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; "
        Me.Label16.Text = "ESTADO FISICO"
        Me.Label16.Top = 2.525!
        Me.Label16.Width = 0.75!
        '
        'Label17
        '
        Me.Label17.Border.BottomColor = System.Drawing.Color.Black
        Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.LeftColor = System.Drawing.Color.Black
        Me.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.RightColor = System.Drawing.Color.Black
        Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Border.TopColor = System.Drawing.Color.Black
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Height = 0.4!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 3.35!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "text-align: center; "
        Me.Label17.Text = "TIPO CAFE"
        Me.Label17.Top = 2.525!
        Me.Label17.Width = 0.75!
        '
        'Label18
        '
        Me.Label18.Border.BottomColor = System.Drawing.Color.Black
        Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.LeftColor = System.Drawing.Color.Black
        Me.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.RightColor = System.Drawing.Color.Black
        Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Border.TopColor = System.Drawing.Color.Black
        Me.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label18.Height = 0.4!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 4.1!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "text-align: center; "
        Me.Label18.Text = "TIPO DE COMPRA"
        Me.Label18.Top = 2.525!
        Me.Label18.Width = 0.75!
        '
        'Label19
        '
        Me.Label19.Border.BottomColor = System.Drawing.Color.Black
        Me.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.LeftColor = System.Drawing.Color.Black
        Me.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.RightColor = System.Drawing.Color.Black
        Me.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.TopColor = System.Drawing.Color.Black
        Me.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Height = 0.4!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 4.85!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "text-align: center; "
        Me.Label19.Text = "PESO BRUTO KG "
        Me.Label19.Top = 2.525!
        Me.Label19.Width = 0.85!
        '
        'Label20
        '
        Me.Label20.Border.BottomColor = System.Drawing.Color.Black
        Me.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.LeftColor = System.Drawing.Color.Black
        Me.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.RightColor = System.Drawing.Color.Black
        Me.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.TopColor = System.Drawing.Color.Black
        Me.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Height = 0.4!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 6.575!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "text-align: center; "
        Me.Label20.Text = "MERMA"
        Me.Label20.Top = 2.525!
        Me.Label20.Width = 0.925!
        '
        'Label21
        '
        Me.Label21.Border.BottomColor = System.Drawing.Color.Black
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.LeftColor = System.Drawing.Color.Black
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.RightColor = System.Drawing.Color.Black
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Border.TopColor = System.Drawing.Color.Black
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label21.Height = 0.4!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 5.7!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "text-align: center; "
        Me.Label21.Text = "PESO NETO KG RECIBO"
        Me.Label21.Top = 2.525!
        Me.Label21.Width = 0.8749998!
        '
        'Label22
        '
        Me.Label22.Border.BottomColor = System.Drawing.Color.Black
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.LeftColor = System.Drawing.Color.Black
        Me.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.RightColor = System.Drawing.Color.Black
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.TopColor = System.Drawing.Color.Black
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Height = 0.2!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.125!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 9pt; "
        Me.Label22.Text = "CONSOLIDADO DE ENTRADA - FECHA DE RECEPCIO:"
        Me.Label22.Top = 2.325!
        Me.Label22.Width = 7.375!
        '
        'Label23
        '
        Me.Label23.Border.BottomColor = System.Drawing.Color.Black
        Me.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.LeftColor = System.Drawing.Color.Black
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.RightColor = System.Drawing.Color.Black
        Me.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Border.TopColor = System.Drawing.Color.Black
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label23.Height = 0.2!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.125!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 9pt; "
        Me.Label23.Text = "INFORMACION MODULO DE REMISION"
        Me.Label23.Top = 2.125!
        Me.Label23.Width = 7.375!
        '
        'SubReport1
        '
        Me.SubReport1.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.RightColor = System.Drawing.Color.Black
        Me.SubReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.TopColor = System.Drawing.Color.Black
        Me.SubReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.25!
        Me.SubReport1.Left = 0.1!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = "SubReport1"
        Me.SubReport1.Top = 2.925!
        Me.SubReport1.Width = 7.425001!
        '
        'Label24
        '
        Me.Label24.Border.BottomColor = System.Drawing.Color.Black
        Me.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.LeftColor = System.Drawing.Color.Black
        Me.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.RightColor = System.Drawing.Color.Black
        Me.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Border.TopColor = System.Drawing.Color.Black
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label24.Height = 0.4!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 0.125!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "text-align: center; "
        Me.Label24.Text = "REGIONAL"
        Me.Label24.Top = 3.7!
        Me.Label24.Width = 0.925!
        '
        'Label25
        '
        Me.Label25.Border.BottomColor = System.Drawing.Color.Black
        Me.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.LeftColor = System.Drawing.Color.Black
        Me.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.RightColor = System.Drawing.Color.Black
        Me.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.TopColor = System.Drawing.Color.Black
        Me.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Height = 0.4!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 1.05!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "text-align: center; "
        Me.Label25.Text = "LOCALIDAD"
        Me.Label25.Top = 3.7!
        Me.Label25.Width = 0.875!
        '
        'Label26
        '
        Me.Label26.Border.BottomColor = System.Drawing.Color.Black
        Me.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.LeftColor = System.Drawing.Color.Black
        Me.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.RightColor = System.Drawing.Color.Black
        Me.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Border.TopColor = System.Drawing.Color.Black
        Me.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label26.Height = 0.4!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 1.925!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "text-align: center; "
        Me.Label26.Text = "CALIDAD"
        Me.Label26.Top = 3.7!
        Me.Label26.Width = 0.675!
        '
        'Label27
        '
        Me.Label27.Border.BottomColor = System.Drawing.Color.Black
        Me.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.LeftColor = System.Drawing.Color.Black
        Me.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.RightColor = System.Drawing.Color.Black
        Me.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Border.TopColor = System.Drawing.Color.Black
        Me.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label27.Height = 0.4!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 2.6!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "text-align: center; "
        Me.Label27.Text = "ESTADO FISICO"
        Me.Label27.Top = 3.7!
        Me.Label27.Width = 0.75!
        '
        'Label28
        '
        Me.Label28.Border.BottomColor = System.Drawing.Color.Black
        Me.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.LeftColor = System.Drawing.Color.Black
        Me.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.RightColor = System.Drawing.Color.Black
        Me.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Border.TopColor = System.Drawing.Color.Black
        Me.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label28.Height = 0.4!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 3.35!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "text-align: center; "
        Me.Label28.Text = "TIPO CAFE"
        Me.Label28.Top = 3.7!
        Me.Label28.Width = 0.75!
        '
        'Label29
        '
        Me.Label29.Border.BottomColor = System.Drawing.Color.Black
        Me.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label29.Border.LeftColor = System.Drawing.Color.Black
        Me.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label29.Border.RightColor = System.Drawing.Color.Black
        Me.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label29.Border.TopColor = System.Drawing.Color.Black
        Me.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label29.Height = 0.4!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 4.1!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "text-align: center; "
        Me.Label29.Text = "TIPO DE COMPRA"
        Me.Label29.Top = 3.7!
        Me.Label29.Width = 0.75!
        '
        'Label30
        '
        Me.Label30.Border.BottomColor = System.Drawing.Color.Black
        Me.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label30.Border.LeftColor = System.Drawing.Color.Black
        Me.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label30.Border.RightColor = System.Drawing.Color.Black
        Me.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label30.Border.TopColor = System.Drawing.Color.Black
        Me.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label30.Height = 0.4!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 4.85!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "text-align: center; "
        Me.Label30.Text = "PESO BRUTO KG "
        Me.Label30.Top = 3.7!
        Me.Label30.Width = 0.85!
        '
        'Label31
        '
        Me.Label31.Border.BottomColor = System.Drawing.Color.Black
        Me.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.LeftColor = System.Drawing.Color.Black
        Me.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.RightColor = System.Drawing.Color.Black
        Me.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Border.TopColor = System.Drawing.Color.Black
        Me.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label31.Height = 0.4!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 6.575!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "text-align: center; "
        Me.Label31.Text = "MONTO PAGADO"
        Me.Label31.Top = 3.7!
        Me.Label31.Width = 0.925!
        '
        'Label32
        '
        Me.Label32.Border.BottomColor = System.Drawing.Color.Black
        Me.Label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.Border.LeftColor = System.Drawing.Color.Black
        Me.Label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.Border.RightColor = System.Drawing.Color.Black
        Me.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.Border.TopColor = System.Drawing.Color.Black
        Me.Label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label32.Height = 0.4!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 5.7!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "text-align: center; "
        Me.Label32.Text = "PESO NETO KG RECIBO"
        Me.Label32.Top = 3.7!
        Me.Label32.Width = 0.8749998!
        '
        'Label33
        '
        Me.Label33.Border.BottomColor = System.Drawing.Color.Black
        Me.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.LeftColor = System.Drawing.Color.Black
        Me.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.RightColor = System.Drawing.Color.Black
        Me.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Border.TopColor = System.Drawing.Color.Black
        Me.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label33.Height = 0.2!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 0.125!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 9pt; "
        Me.Label33.Text = "CONSOLIDADO DE ENTRADA - FECHA DE RECEPCIO:"
        Me.Label33.Top = 3.5!
        Me.Label33.Width = 7.375!
        '
        'Label34
        '
        Me.Label34.Border.BottomColor = System.Drawing.Color.Black
        Me.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.LeftColor = System.Drawing.Color.Black
        Me.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.RightColor = System.Drawing.Color.Black
        Me.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Border.TopColor = System.Drawing.Color.Black
        Me.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label34.Height = 0.2!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 0.125!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 9pt; "
        Me.Label34.Text = "INFORMACION MODULO DE BODEGA"
        Me.Label34.Top = 3.3!
        Me.Label34.Width = 7.375!
        '
        'SubReport2
        '
        Me.SubReport2.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReport2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReport2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.RightColor = System.Drawing.Color.Black
        Me.SubReport2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.TopColor = System.Drawing.Color.Black
        Me.SubReport2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.CloseBorder = False
        Me.SubReport2.Height = 0.25!
        Me.SubReport2.Left = 0.1!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.ReportName = "SubReport1"
        Me.SubReport2.Top = 4.1!
        Me.SubReport2.Width = 7.425001!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Height = 0.0!
        Me.Detail1.Name = "Detail1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ArepMermaRecibo
        '
        Me.MasterReport = False
        Me.Name = "ArepMermaRecibo"
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.6875!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCompañia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblCompañia As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents SubReportRecibos As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
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
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
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
    Friend WithEvents SubReport2 As DataDynamics.ActiveReports.SubReport
End Class
