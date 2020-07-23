<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepReporteRemision 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepReporteRemision))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.LblCompañia = New DataDynamics.ActiveReports.Label
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.Label39 = New DataDynamics.ActiveReports.Label
        Me.Label38 = New DataDynamics.ActiveReports.Label
        Me.Label42 = New DataDynamics.ActiveReports.Label
        Me.Label43 = New DataDynamics.ActiveReports.Label
        Me.Label44 = New DataDynamics.ActiveReports.Label
        Me.Label46 = New DataDynamics.ActiveReports.Label
        Me.Label49 = New DataDynamics.ActiveReports.Label
        Me.Label47 = New DataDynamics.ActiveReports.Label
        Me.Label48 = New DataDynamics.ActiveReports.Label
        Me.Label45 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TxtCont = New DataDynamics.ActiveReports.TextBox
        Me.TxtNumeroRecibos = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoBrutoRemision = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoNetoRecibos = New DataDynamics.ActiveReports.TextBox
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantSacos1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoBruto1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoNeto1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantSacos2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoBruto2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoNeto2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtNumeroRecibo = New DataDynamics.ActiveReports.TextBox
        Me.LblNumero = New DataDynamics.ActiveReports.Label
        Me.TxtIdRemision = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtProductor = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.TxtListadoRecibos = New DataDynamics.ActiveReports.TextBox
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label19 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.TxtTaraPlanta = New DataDynamics.ActiveReports.TextBox
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.TxtMermaTransitoPI = New DataDynamics.ActiveReports.TextBox
        Me.TxtMermaBodegaPI = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtMermaTransitoPII = New DataDynamics.ActiveReports.TextBox
        Me.TxtMermaBodegaPII = New DataDynamics.ActiveReports.TextBox
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.LblFecha = New DataDynamics.ActiveReports.Label
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.LblLocalidad = New DataDynamics.ActiveReports.Label
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.Label25 = New DataDynamics.ActiveReports.Label
        Me.Label26 = New DataDynamics.ActiveReports.Label
        Me.LblModalidad = New DataDynamics.ActiveReports.Label
        Me.Label27 = New DataDynamics.ActiveReports.Label
        Me.TextBox30 = New DataDynamics.ActiveReports.TextBox
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox19 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox20 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox21 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox22 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox23 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox24 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox25 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox26 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox27 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox28 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox29 = New DataDynamics.ActiveReports.TextBox
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCompañia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumeroRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoBrutoRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoNetoRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantSacos1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoBruto1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoNeto1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantSacos2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoBruto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoNeto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumeroRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIdRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtListadoRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTaraPlanta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMermaTransitoPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMermaBodegaPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMermaTransitoPII, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMermaBodegaPII, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblModalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.LblCompañia, Me.ImgLogo, Me.Label39, Me.Label38, Me.Label42, Me.Label43, Me.Label44, Me.Label46, Me.Label49, Me.Label47, Me.Label48, Me.Label45, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label7, Me.Label18, Me.Label19, Me.Label12, Me.Label20, Me.Label21, Me.Label22, Me.Label13, Me.LblFecha, Me.Label23, Me.LblLocalidad, Me.Label24, Me.Label25, Me.Label26, Me.LblModalidad, Me.Label27, Me.TextBox30})
        Me.PageHeader1.Height = 1.75!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-style:" & _
            " normal; font-size: 9pt; "
        Me.Label1.Text = "REPORTE MERMA  BODEGA VRS RECIBO VRS REMISION"
        Me.Label1.Top = 0.3!
        Me.Label1.Width = 14.025!
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
        Me.LblCompañia.Left = 0.0!
        Me.LblCompañia.Name = "LblCompañia"
        Me.LblCompañia.Style = "color: Green; ddo-char-set: 0; text-align: center; font-style: normal; font-size:" & _
            " 14.25pt; "
        Me.LblCompañia.Text = "Exportadora Atlantic S.A"
        Me.LblCompañia.Top = 0.0!
        Me.LblCompañia.Width = 14.025!
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
        Me.ImgLogo.Height = 0.925!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.0!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.425!
        '
        'Label39
        '
        Me.Label39.Border.BottomColor = System.Drawing.Color.Black
        Me.Label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Border.LeftColor = System.Drawing.Color.Black
        Me.Label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label39.Border.RightColor = System.Drawing.Color.Black
        Me.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Border.TopColor = System.Drawing.Color.Black
        Me.Label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Height = 0.275!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 0.275!
        Me.Label39.Name = "Label39"
        Me.Label39.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label39.Text = "Nº Recibo"
        Me.Label39.Top = 1.425!
        Me.Label39.Width = 0.75!
        '
        'Label38
        '
        Me.Label38.Border.BottomColor = System.Drawing.Color.Black
        Me.Label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.Border.LeftColor = System.Drawing.Color.Black
        Me.Label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.Border.RightColor = System.Drawing.Color.Black
        Me.Label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.Border.TopColor = System.Drawing.Color.Black
        Me.Label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label38.Height = 0.2800001!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.025!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label38.Text = "Nº"
        Me.Label38.Top = 1.425!
        Me.Label38.Width = 0.24!
        '
        'Label42
        '
        Me.Label42.Border.BottomColor = System.Drawing.Color.Black
        Me.Label42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.LeftColor = System.Drawing.Color.Black
        Me.Label42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.RightColor = System.Drawing.Color.Black
        Me.Label42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Border.TopColor = System.Drawing.Color.Black
        Me.Label42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label42.Height = 0.275!
        Me.Label42.HyperLink = Nothing
        Me.Label42.Left = 2.95!
        Me.Label42.Name = "Label42"
        Me.Label42.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label42.Text = "% Imp"
        Me.Label42.Top = 1.425!
        Me.Label42.Width = 0.45!
        '
        'Label43
        '
        Me.Label43.Border.BottomColor = System.Drawing.Color.Black
        Me.Label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.LeftColor = System.Drawing.Color.Black
        Me.Label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.RightColor = System.Drawing.Color.Black
        Me.Label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label43.Border.TopColor = System.Drawing.Color.Black
        Me.Label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Height = 0.275!
        Me.Label43.HyperLink = Nothing
        Me.Label43.Left = 3.4!
        Me.Label43.Name = "Label43"
        Me.Label43.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label43.Text = "Daño"
        Me.Label43.Top = 1.425!
        Me.Label43.Width = 0.6499999!
        '
        'Label44
        '
        Me.Label44.Border.BottomColor = System.Drawing.Color.Black
        Me.Label44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.LeftColor = System.Drawing.Color.Black
        Me.Label44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.RightColor = System.Drawing.Color.Black
        Me.Label44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Border.TopColor = System.Drawing.Color.Black
        Me.Label44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label44.Height = 0.275!
        Me.Label44.HyperLink = Nothing
        Me.Label44.Left = 4.025!
        Me.Label44.Name = "Label44"
        Me.Label44.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label44.Text = "Edo.Fisico"
        Me.Label44.Top = 1.425!
        Me.Label44.Width = 0.675!
        '
        'Label46
        '
        Me.Label46.Border.BottomColor = System.Drawing.Color.Black
        Me.Label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.LeftColor = System.Drawing.Color.Black
        Me.Label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.RightColor = System.Drawing.Color.Black
        Me.Label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Border.TopColor = System.Drawing.Color.Black
        Me.Label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label46.Height = 0.275!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 5.125!
        Me.Label46.Name = "Label46"
        Me.Label46.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label46.Text = "Peso Bruto"
        Me.Label46.Top = 1.425!
        Me.Label46.Width = 0.5249999!
        '
        'Label49
        '
        Me.Label49.Border.BottomColor = System.Drawing.Color.Black
        Me.Label49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label49.Border.LeftColor = System.Drawing.Color.Black
        Me.Label49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label49.Border.RightColor = System.Drawing.Color.Black
        Me.Label49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label49.Border.TopColor = System.Drawing.Color.Black
        Me.Label49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label49.Height = 0.275!
        Me.Label49.HyperLink = Nothing
        Me.Label49.Left = 5.65!
        Me.Label49.Name = "Label49"
        Me.Label49.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label49.Text = "Tara"
        Me.Label49.Top = 1.425!
        Me.Label49.Width = 0.41!
        '
        'Label47
        '
        Me.Label47.Border.BottomColor = System.Drawing.Color.Black
        Me.Label47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Border.LeftColor = System.Drawing.Color.Black
        Me.Label47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label47.Border.RightColor = System.Drawing.Color.Black
        Me.Label47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Border.TopColor = System.Drawing.Color.Black
        Me.Label47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Height = 0.275!
        Me.Label47.HyperLink = Nothing
        Me.Label47.Left = 6.050001!
        Me.Label47.Name = "Label47"
        Me.Label47.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label47.Text = "Peso Neto"
        Me.Label47.Top = 1.425!
        Me.Label47.Width = 0.525!
        '
        'Label48
        '
        Me.Label48.Border.BottomColor = System.Drawing.Color.Black
        Me.Label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label48.Border.LeftColor = System.Drawing.Color.Black
        Me.Label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label48.Border.RightColor = System.Drawing.Color.Black
        Me.Label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label48.Border.TopColor = System.Drawing.Color.Black
        Me.Label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label48.Height = 0.15!
        Me.Label48.HyperLink = Nothing
        Me.Label48.Left = 4.7!
        Me.Label48.Name = "Label48"
        Me.Label48.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.Label48.Text = "Peso Según Remision"
        Me.Label48.Top = 1.275!
        Me.Label48.Width = 1.875!
        '
        'Label45
        '
        Me.Label45.Border.BottomColor = System.Drawing.Color.Black
        Me.Label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.LeftColor = System.Drawing.Color.Black
        Me.Label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.RightColor = System.Drawing.Color.Black
        Me.Label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label45.Border.TopColor = System.Drawing.Color.Black
        Me.Label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Height = 0.275!
        Me.Label45.HyperLink = Nothing
        Me.Label45.Left = 4.7!
        Me.Label45.Name = "Label45"
        Me.Label45.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label45.Text = "Cant. Sacos"
        Me.Label45.Top = 1.425!
        Me.Label45.Width = 0.41!
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
        Me.Label2.Height = 0.15!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 6.575!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.Label2.Text = "Peso Recibo Neto"
        Me.Label2.Top = 1.275!
        Me.Label2.Width = 1.05!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Height = 0.275!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 6.575!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label3.Text = "Sacos Origen"
        Me.Label3.Top = 1.425!
        Me.Label3.Width = 0.4000001!
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
        Me.Label4.Height = 0.275!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 7.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label4.Text = "Peso Neto Origen"
        Me.Label4.Top = 1.425!
        Me.Label4.Width = 0.64!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Height = 0.275!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 7.65!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label5.Text = "Merma Bodega"
        Me.Label5.Top = 1.425!
        Me.Label5.Width = 0.5!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.275!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 8.575!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label6.Text = "PB Recep."
        Me.Label6.Top = 1.425!
        Me.Label6.Width = 0.5249999!
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
        Me.Label8.Height = 0.275!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 9.1!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label8.Text = "PB Remision"
        Me.Label8.Top = 1.425!
        Me.Label8.Width = 0.525!
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
        Me.Label9.Height = 0.15!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 8.150001!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.Label9.Text = "Punto Intermedio 1"
        Me.Label9.Top = 1.275!
        Me.Label9.Width = 2.525!
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
        Me.Label10.Height = 0.275!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 8.150001!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label10.Text = "Cant. Sacos"
        Me.Label10.Top = 1.425!
        Me.Label10.Width = 0.41!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.275!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 11.125!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label11.Text = "PB Recep"
        Me.Label11.Top = 1.425!
        Me.Label11.Width = 0.5249999!
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
        Me.Label14.Height = 0.15!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 10.675!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.Label14.Text = "Planta Procesadora"
        Me.Label14.Top = 1.275!
        Me.Label14.Width = 3.475!
        '
        'Label15
        '
        Me.Label15.Border.BottomColor = System.Drawing.Color.Black
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.LeftColor = System.Drawing.Color.Black
        Me.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label15.Border.RightColor = System.Drawing.Color.Black
        Me.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.TopColor = System.Drawing.Color.Black
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Height = 0.275!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 10.7!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label15.Text = "Cant. Sacos"
        Me.Label15.Top = 1.425!
        Me.Label15.Width = 0.41!
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
        Me.Label16.Height = 0.275!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 2.4!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label16.Text = "No Remision"
        Me.Label16.Top = 1.425!
        Me.Label16.Width = 0.5500001!
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
        Me.Label17.Height = 0.275!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 1.025!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label17.Text = "Productor"
        Me.Label17.Top = 1.425!
        Me.Label17.Width = 1.375!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtCont, Me.TxtNumeroRecibos, Me.TextBox3, Me.TextBox4, Me.TextBox6, Me.TextBox7, Me.TxtPesoBrutoRemision, Me.TextBox9, Me.TextBox10, Me.TextBox5, Me.TxtPesoNetoRecibos, Me.TextBox12, Me.TxtCantSacos1, Me.TxtPesoBruto1, Me.TxtPesoNeto1, Me.TxtCantSacos2, Me.TxtPesoBruto2, Me.TxtPesoNeto2, Me.TxtNumeroRecibo, Me.LblNumero, Me.TxtIdRemision, Me.TextBox1, Me.TxtProductor, Me.TxtListadoRecibos, Me.TxtTaraPlanta, Me.TxtMermaTransitoPI, Me.TxtMermaBodegaPI, Me.TextBox2, Me.TxtMermaTransitoPII, Me.TxtMermaBodegaPII})
        Me.Detail1.Height = 0.2604167!
        Me.Detail1.Name = "Detail1"
        '
        'TxtCont
        '
        Me.TxtCont.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCont.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCont.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCont.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCont.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCont.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCont.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCont.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCont.DataField = "N0"
        Me.TxtCont.Height = 0.225!
        Me.TxtCont.Left = 0.0!
        Me.TxtCont.Name = "TxtCont"
        Me.TxtCont.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TxtCont.Text = Nothing
        Me.TxtCont.Top = 0.0!
        Me.TxtCont.Width = 0.25!
        '
        'TxtNumeroRecibos
        '
        Me.TxtNumeroRecibos.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtNumeroRecibos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroRecibos.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtNumeroRecibos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroRecibos.Border.RightColor = System.Drawing.Color.Black
        Me.TxtNumeroRecibos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroRecibos.Border.TopColor = System.Drawing.Color.Black
        Me.TxtNumeroRecibos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroRecibos.DataField = "Rango"
        Me.TxtNumeroRecibos.Height = 0.225!
        Me.TxtNumeroRecibos.Left = 0.2!
        Me.TxtNumeroRecibos.Name = "TxtNumeroRecibos"
        Me.TxtNumeroRecibos.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.TxtNumeroRecibos.Text = Nothing
        Me.TxtNumeroRecibos.Top = 0.425!
        Me.TxtNumeroRecibos.Visible = False
        Me.TxtNumeroRecibos.Width = 1.225!
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
        Me.TextBox3.DataField = "Imperfeccion"
        Me.TextBox3.Height = 0.225!
        Me.TextBox3.Left = 2.95!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.45!
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
        Me.TextBox4.DataField = "Daño"
        Me.TextBox4.Height = 0.225!
        Me.TextBox4.Left = 3.4!
        Me.TextBox4.MultiLine = False
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.6749999!
        '
        'TextBox6
        '
        Me.TextBox6.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox6.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox6.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox6.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox6.DataField = "EstadoFisico"
        Me.TextBox6.Height = 0.225!
        Me.TextBox6.Left = 4.075!
        Me.TextBox6.MultiLine = False
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.6000001!
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
        Me.TextBox7.DataField = "CantidadSacos"
        Me.TextBox7.Height = 0.25!
        Me.TextBox7.Left = 4.725!
        Me.TextBox7.MultiLine = False
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.4000001!
        '
        'TxtPesoBrutoRemision
        '
        Me.TxtPesoBrutoRemision.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoBrutoRemision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBrutoRemision.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoBrutoRemision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBrutoRemision.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoBrutoRemision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBrutoRemision.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoBrutoRemision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBrutoRemision.DataField = "PesoBruto"
        Me.TxtPesoBrutoRemision.Height = 0.225!
        Me.TxtPesoBrutoRemision.Left = 5.15!
        Me.TxtPesoBrutoRemision.MultiLine = False
        Me.TxtPesoBrutoRemision.Name = "TxtPesoBrutoRemision"
        Me.TxtPesoBrutoRemision.OutputFormat = resources.GetString("TxtPesoBrutoRemision.OutputFormat")
        Me.TxtPesoBrutoRemision.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Arial; "
        Me.TxtPesoBrutoRemision.Text = Nothing
        Me.TxtPesoBrutoRemision.Top = 0.0!
        Me.TxtPesoBrutoRemision.Width = 0.4999999!
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
        Me.TextBox9.DataField = "Tara"
        Me.TextBox9.Height = 0.225!
        Me.TextBox9.Left = 5.65!
        Me.TextBox9.MultiLine = False
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 0.3999999!
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
        Me.TextBox10.DataField = "PesoNeto"
        Me.TextBox10.Height = 0.225!
        Me.TextBox10.Left = 6.050001!
        Me.TextBox10.MultiLine = False
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.5000001!
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
        Me.TextBox5.DataField = "CantidadSacosRecibos"
        Me.TextBox5.Height = 0.225!
        Me.TextBox5.Left = 6.575!
        Me.TextBox5.MultiLine = False
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.4250001!
        '
        'TxtPesoNetoRecibos
        '
        Me.TxtPesoNetoRecibos.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoNetoRecibos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNetoRecibos.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoNetoRecibos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNetoRecibos.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoNetoRecibos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNetoRecibos.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoNetoRecibos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNetoRecibos.DataField = "PesoNetoRecibos"
        Me.TxtPesoNetoRecibos.Height = 0.225!
        Me.TxtPesoNetoRecibos.Left = 7.0!
        Me.TxtPesoNetoRecibos.MultiLine = False
        Me.TxtPesoNetoRecibos.Name = "TxtPesoNetoRecibos"
        Me.TxtPesoNetoRecibos.OutputFormat = resources.GetString("TxtPesoNetoRecibos.OutputFormat")
        Me.TxtPesoNetoRecibos.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtPesoNetoRecibos.Text = Nothing
        Me.TxtPesoNetoRecibos.Top = 0.0!
        Me.TxtPesoNetoRecibos.Width = 0.6250003!
        '
        'TextBox12
        '
        Me.TextBox12.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox12.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox12.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox12.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox12.DataField = "MermaBodega"
        Me.TextBox12.Height = 0.225!
        Me.TextBox12.Left = 7.65!
        Me.TextBox12.MultiLine = False
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
        Me.TextBox12.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 0.0!
        Me.TextBox12.Width = 0.5!
        '
        'TxtCantSacos1
        '
        Me.TxtCantSacos1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantSacos1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantSacos1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantSacos1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantSacos1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos1.DataField = "CantidadSacosPI"
        Me.TxtCantSacos1.Height = 0.225!
        Me.TxtCantSacos1.Left = 8.150001!
        Me.TxtCantSacos1.MultiLine = False
        Me.TxtCantSacos1.Name = "TxtCantSacos1"
        Me.TxtCantSacos1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TxtCantSacos1.Text = Nothing
        Me.TxtCantSacos1.Top = 0.0!
        Me.TxtCantSacos1.Width = 0.4250003!
        '
        'TxtPesoBruto1
        '
        Me.TxtPesoBruto1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoBruto1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoBruto1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoBruto1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoBruto1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto1.DataField = "PesoBrutoIniPI"
        Me.TxtPesoBruto1.Height = 0.225!
        Me.TxtPesoBruto1.Left = 8.575!
        Me.TxtPesoBruto1.MultiLine = False
        Me.TxtPesoBruto1.Name = "TxtPesoBruto1"
        Me.TxtPesoBruto1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtPesoBruto1.Text = Nothing
        Me.TxtPesoBruto1.Top = 0.0!
        Me.TxtPesoBruto1.Width = 0.5249998!
        '
        'TxtPesoNeto1
        '
        Me.TxtPesoNeto1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoNeto1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoNeto1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoNeto1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoNeto1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto1.DataField = "PesoBrutoFinPI"
        Me.TxtPesoNeto1.Height = 0.225!
        Me.TxtPesoNeto1.Left = 9.075!
        Me.TxtPesoNeto1.MultiLine = False
        Me.TxtPesoNeto1.Name = "TxtPesoNeto1"
        Me.TxtPesoNeto1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtPesoNeto1.Text = Nothing
        Me.TxtPesoNeto1.Top = 0.0!
        Me.TxtPesoNeto1.Width = 0.5499998!
        '
        'TxtCantSacos2
        '
        Me.TxtCantSacos2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantSacos2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantSacos2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantSacos2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantSacos2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos2.DataField = "CantidadSacosPII"
        Me.TxtCantSacos2.Height = 0.225!
        Me.TxtCantSacos2.Left = 10.725!
        Me.TxtCantSacos2.MultiLine = False
        Me.TxtCantSacos2.Name = "TxtCantSacos2"
        Me.TxtCantSacos2.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TxtCantSacos2.Text = Nothing
        Me.TxtCantSacos2.Top = 0.0!
        Me.TxtCantSacos2.Width = 0.3999998!
        '
        'TxtPesoBruto2
        '
        Me.TxtPesoBruto2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoBruto2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoBruto2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoBruto2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoBruto2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto2.DataField = "PesoBrutoIniPII"
        Me.TxtPesoBruto2.Height = 0.225!
        Me.TxtPesoBruto2.Left = 11.125!
        Me.TxtPesoBruto2.MultiLine = False
        Me.TxtPesoBruto2.Name = "TxtPesoBruto2"
        Me.TxtPesoBruto2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtPesoBruto2.Text = Nothing
        Me.TxtPesoBruto2.Top = 0.0!
        Me.TxtPesoBruto2.Width = 0.5500002!
        '
        'TxtPesoNeto2
        '
        Me.TxtPesoNeto2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoNeto2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoNeto2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoNeto2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoNeto2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto2.DataField = "PesoNetoIniPII"
        Me.TxtPesoNeto2.Height = 0.225!
        Me.TxtPesoNeto2.Left = 12.075!
        Me.TxtPesoNeto2.MultiLine = False
        Me.TxtPesoNeto2.Name = "TxtPesoNeto2"
        Me.TxtPesoNeto2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtPesoNeto2.Text = Nothing
        Me.TxtPesoNeto2.Top = 0.0!
        Me.TxtPesoNeto2.Width = 0.4999995!
        '
        'TxtNumeroRecibo
        '
        Me.TxtNumeroRecibo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtNumeroRecibo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroRecibo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtNumeroRecibo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroRecibo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtNumeroRecibo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroRecibo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtNumeroRecibo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtNumeroRecibo.DataField = "Codigo"
        Me.TxtNumeroRecibo.Height = 0.1979167!
        Me.TxtNumeroRecibo.Left = 3.75!
        Me.TxtNumeroRecibo.Name = "TxtNumeroRecibo"
        Me.TxtNumeroRecibo.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial Narrow; "
        Me.TxtNumeroRecibo.Text = Nothing
        Me.TxtNumeroRecibo.Top = 0.525!
        Me.TxtNumeroRecibo.Visible = False
        Me.TxtNumeroRecibo.Width = 1.0!
        '
        'LblNumero
        '
        Me.LblNumero.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNumero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNumero.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNumero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNumero.Border.RightColor = System.Drawing.Color.Black
        Me.LblNumero.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNumero.Border.TopColor = System.Drawing.Color.Black
        Me.LblNumero.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNumero.Height = 0.1979167!
        Me.LblNumero.HyperLink = Nothing
        Me.LblNumero.Left = 2.475!
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial Narrow; "
        Me.LblNumero.Text = ""
        Me.LblNumero.Top = 0.75!
        Me.LblNumero.Visible = False
        Me.LblNumero.Width = 1.0!
        '
        'TxtIdRemision
        '
        Me.TxtIdRemision.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtIdRemision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtIdRemision.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtIdRemision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtIdRemision.Border.RightColor = System.Drawing.Color.Black
        Me.TxtIdRemision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtIdRemision.Border.TopColor = System.Drawing.Color.Black
        Me.TxtIdRemision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtIdRemision.DataField = "IdRemisionPergamino"
        Me.TxtIdRemision.Height = 0.1979167!
        Me.TxtIdRemision.Left = 3.15!
        Me.TxtIdRemision.Name = "TxtIdRemision"
        Me.TxtIdRemision.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial Narrow; "
        Me.TxtIdRemision.Text = "TextBox1"
        Me.TxtIdRemision.Top = 0.45!
        Me.TxtIdRemision.Visible = False
        Me.TxtIdRemision.Width = 1.0!
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
        Me.TextBox1.DataField = "NumeroRemision"
        Me.TextBox1.Height = 0.225!
        Me.TextBox1.Left = 2.4!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.575!
        '
        'TxtProductor
        '
        Me.TxtProductor.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtProductor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtProductor.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtProductor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtProductor.Border.RightColor = System.Drawing.Color.Black
        Me.TxtProductor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtProductor.Border.TopColor = System.Drawing.Color.Black
        Me.TxtProductor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtProductor.DataField = "Proveedor"
        Me.TxtProductor.Height = 0.225!
        Me.TxtProductor.Left = 1.025!
        Me.TxtProductor.Name = "TxtProductor"
        Me.TxtProductor.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial; "
        Me.TxtProductor.Text = Nothing
        Me.TxtProductor.Top = 0.0!
        Me.TxtProductor.Width = 1.375!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'TxtListadoRecibos
        '
        Me.TxtListadoRecibos.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtListadoRecibos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtListadoRecibos.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtListadoRecibos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtListadoRecibos.Border.RightColor = System.Drawing.Color.Black
        Me.TxtListadoRecibos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtListadoRecibos.Border.TopColor = System.Drawing.Color.Black
        Me.TxtListadoRecibos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtListadoRecibos.DataField = "Rango"
        Me.TxtListadoRecibos.Height = 0.225!
        Me.TxtListadoRecibos.Left = 0.25!
        Me.TxtListadoRecibos.Name = "TxtListadoRecibos"
        Me.TxtListadoRecibos.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Microsoft Sans Serif; "
        Me.TxtListadoRecibos.Text = Nothing
        Me.TxtListadoRecibos.Top = 0.0!
        Me.TxtListadoRecibos.Width = 0.775!
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
        Me.Label7.Height = 0.275!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 9.625001!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label7.Text = "Merma Trans.PI"
        Me.Label7.Top = 1.425!
        Me.Label7.Width = 0.53!
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
        Me.Label18.Height = 0.275!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 13.1!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label18.Text = "Merma Trans.PI"
        Me.Label18.Top = 1.425!
        Me.Label18.Width = 0.53!
        '
        'Label19
        '
        Me.Label19.Border.BottomColor = System.Drawing.Color.Black
        Me.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.LeftColor = System.Drawing.Color.Black
        Me.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label19.Border.RightColor = System.Drawing.Color.Black
        Me.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Border.TopColor = System.Drawing.Color.Black
        Me.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label19.Height = 0.275!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 10.15!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label19.Text = "Merma Bodega PI"
        Me.Label19.Top = 1.425!
        Me.Label19.Width = 0.53!
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
        Me.Label12.Height = 0.275!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 11.65!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label12.Text = "Tara"
        Me.Label12.Top = 1.425!
        Me.Label12.Width = 0.41!
        '
        'TxtTaraPlanta
        '
        Me.TxtTaraPlanta.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTaraPlanta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTaraPlanta.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTaraPlanta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTaraPlanta.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTaraPlanta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTaraPlanta.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTaraPlanta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTaraPlanta.DataField = "TaraIniPII"
        Me.TxtTaraPlanta.Height = 0.225!
        Me.TxtTaraPlanta.Left = 11.675!
        Me.TxtTaraPlanta.MultiLine = False
        Me.TxtTaraPlanta.Name = "TxtTaraPlanta"
        Me.TxtTaraPlanta.OutputFormat = resources.GetString("TxtTaraPlanta.OutputFormat")
        Me.TxtTaraPlanta.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtTaraPlanta.Text = Nothing
        Me.TxtTaraPlanta.Top = 0.0!
        Me.TxtTaraPlanta.Width = 0.3999999!
        '
        'Label20
        '
        Me.Label20.Border.BottomColor = System.Drawing.Color.Black
        Me.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.LeftColor = System.Drawing.Color.Black
        Me.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.RightColor = System.Drawing.Color.Black
        Me.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Border.TopColor = System.Drawing.Color.Black
        Me.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label20.Height = 0.275!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 12.05!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label20.Text = "PN Recep"
        Me.Label20.Top = 1.425!
        Me.Label20.Width = 0.5249999!
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
        Me.Label21.Height = 0.275!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 12.575!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label21.Text = "PB Remision"
        Me.Label21.Top = 1.425!
        Me.Label21.Width = 0.525!
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
        Me.Label22.Height = 0.275!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 13.625!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label22.Text = "Merma Total"
        Me.Label22.Top = 1.425!
        Me.Label22.Width = 0.53!
        '
        'TxtMermaTransitoPI
        '
        Me.TxtMermaTransitoPI.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMermaTransitoPI.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaTransitoPI.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMermaTransitoPI.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaTransitoPI.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMermaTransitoPI.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaTransitoPI.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMermaTransitoPI.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaTransitoPI.DataField = "MermaTransitoPI"
        Me.TxtMermaTransitoPI.Height = 0.225!
        Me.TxtMermaTransitoPI.Left = 9.650001!
        Me.TxtMermaTransitoPI.MultiLine = False
        Me.TxtMermaTransitoPI.Name = "TxtMermaTransitoPI"
        Me.TxtMermaTransitoPI.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtMermaTransitoPI.Text = Nothing
        Me.TxtMermaTransitoPI.Top = 0.0!
        Me.TxtMermaTransitoPI.Width = 0.4999997!
        '
        'TxtMermaBodegaPI
        '
        Me.TxtMermaBodegaPI.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMermaBodegaPI.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaBodegaPI.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMermaBodegaPI.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaBodegaPI.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMermaBodegaPI.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaBodegaPI.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMermaBodegaPI.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaBodegaPI.DataField = "MermaBodegaPI"
        Me.TxtMermaBodegaPI.Height = 0.225!
        Me.TxtMermaBodegaPI.Left = 10.175!
        Me.TxtMermaBodegaPI.MultiLine = False
        Me.TxtMermaBodegaPI.Name = "TxtMermaBodegaPI"
        Me.TxtMermaBodegaPI.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtMermaBodegaPI.Text = Nothing
        Me.TxtMermaBodegaPI.Top = 0.0!
        Me.TxtMermaBodegaPI.Width = 0.4999997!
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
        Me.TextBox2.DataField = "PesoBruto"
        Me.TextBox2.Height = 0.225!
        Me.TextBox2.Left = 12.6!
        Me.TextBox2.MultiLine = False
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.4999999!
        '
        'TxtMermaTransitoPII
        '
        Me.TxtMermaTransitoPII.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMermaTransitoPII.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaTransitoPII.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMermaTransitoPII.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaTransitoPII.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMermaTransitoPII.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaTransitoPII.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMermaTransitoPII.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaTransitoPII.DataField = "MermaTransitoPII"
        Me.TxtMermaTransitoPII.Height = 0.225!
        Me.TxtMermaTransitoPII.Left = 13.125!
        Me.TxtMermaTransitoPII.MultiLine = False
        Me.TxtMermaTransitoPII.Name = "TxtMermaTransitoPII"
        Me.TxtMermaTransitoPII.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtMermaTransitoPII.Text = Nothing
        Me.TxtMermaTransitoPII.Top = 0.0!
        Me.TxtMermaTransitoPII.Width = 0.4999997!
        '
        'TxtMermaBodegaPII
        '
        Me.TxtMermaBodegaPII.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMermaBodegaPII.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaBodegaPII.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMermaBodegaPII.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaBodegaPII.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMermaBodegaPII.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaBodegaPII.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMermaBodegaPII.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMermaBodegaPII.DataField = "MermaBodegaTotal"
        Me.TxtMermaBodegaPII.Height = 0.225!
        Me.TxtMermaBodegaPII.Left = 13.65!
        Me.TxtMermaBodegaPII.MultiLine = False
        Me.TxtMermaBodegaPII.Name = "TxtMermaBodegaPII"
        Me.TxtMermaBodegaPII.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TxtMermaBodegaPII.Text = Nothing
        Me.TxtMermaBodegaPII.Top = 0.0!
        Me.TxtMermaBodegaPII.Width = 0.5000001!
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
        Me.Label13.Height = 0.2!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 1.7!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label13.Text = "Fecha:"
        Me.Label13.Top = 0.675!
        Me.Label13.Width = 0.5250001!
        '
        'LblFecha
        '
        Me.LblFecha.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFecha.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFecha.Border.RightColor = System.Drawing.Color.Black
        Me.LblFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFecha.Border.TopColor = System.Drawing.Color.Black
        Me.LblFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFecha.Height = 0.2!
        Me.LblFecha.HyperLink = Nothing
        Me.LblFecha.Left = 2.475!
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.LblFecha.Text = ""
        Me.LblFecha.Top = 0.7!
        Me.LblFecha.Width = 3.625!
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
        Me.Label23.Height = 0.2!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 1.7!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label23.Text = "Localidad:"
        Me.Label23.Top = 0.925!
        Me.Label23.Width = 0.7750001!
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
        Me.LblLocalidad.Height = 0.2!
        Me.LblLocalidad.HyperLink = Nothing
        Me.LblLocalidad.Left = 2.475!
        Me.LblLocalidad.Name = "LblLocalidad"
        Me.LblLocalidad.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.LblLocalidad.Text = ""
        Me.LblLocalidad.Top = 0.925!
        Me.LblLocalidad.Width = 3.625!
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
        Me.Label24.Height = 0.2!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 1.7!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label24.Text = "Localidad:"
        Me.Label24.Top = 0.925!
        Me.Label24.Width = 0.7750001!
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
        Me.Label25.Height = 0.2!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 2.475!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label25.Text = ""
        Me.Label25.Top = 0.925!
        Me.Label25.Width = 3.625!
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
        Me.Label26.Height = 0.2!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 6.575!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label26.Text = "Modalidad"
        Me.Label26.Top = 0.675!
        Me.Label26.Width = 0.7750001!
        '
        'LblModalidad
        '
        Me.LblModalidad.Border.BottomColor = System.Drawing.Color.Black
        Me.LblModalidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblModalidad.Border.LeftColor = System.Drawing.Color.Black
        Me.LblModalidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblModalidad.Border.RightColor = System.Drawing.Color.Black
        Me.LblModalidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblModalidad.Border.TopColor = System.Drawing.Color.Black
        Me.LblModalidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblModalidad.Height = 0.2!
        Me.LblModalidad.HyperLink = Nothing
        Me.LblModalidad.Left = 7.35!
        Me.LblModalidad.Name = "LblModalidad"
        Me.LblModalidad.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.LblModalidad.Text = ""
        Me.LblModalidad.Top = 0.675!
        Me.LblModalidad.Width = 3.625!
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
        Me.Label27.Height = 0.2!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 11.9!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label27.Text = "Pag."
        Me.Label27.Top = 0.65!
        Me.Label27.Width = 0.4000002!
        '
        'TextBox30
        '
        Me.TextBox30.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox30.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox30.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox30.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox30.DataField = "CantidadSacosPI"
        Me.TextBox30.Height = 0.2!
        Me.TextBox30.Left = 12.3!
        Me.TextBox30.MultiLine = False
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox30.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox30.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.TextBox30.Text = Nothing
        Me.TextBox30.Top = 0.65!
        Me.TextBox30.Width = 0.4249997!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Height = 0.0!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox8, Me.TextBox11, Me.TextBox13, Me.TextBox14, Me.TextBox15, Me.TextBox16, Me.TextBox17, Me.TextBox18, Me.TextBox19, Me.TextBox20, Me.TextBox21, Me.TextBox22, Me.TextBox23, Me.TextBox24, Me.TextBox25, Me.TextBox26, Me.TextBox27, Me.TextBox28, Me.TextBox29})
        Me.ReportFooter1.Height = 0.3020833!
        Me.ReportFooter1.Name = "ReportFooter1"
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
        Me.TextBox8.DataField = "MermaBodegaTotal"
        Me.TextBox8.Height = 0.225!
        Me.TextBox8.Left = 13.65!
        Me.TextBox8.MultiLine = False
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox8.SummaryGroup = "GroupHeader1"
        Me.TextBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.5000001!
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
        Me.TextBox11.DataField = "PesoBruto"
        Me.TextBox11.Height = 0.225!
        Me.TextBox11.Left = 5.15!
        Me.TextBox11.MultiLine = False
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox11.SummaryGroup = "GroupHeader1"
        Me.TextBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.4999999!
        '
        'TextBox13
        '
        Me.TextBox13.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox13.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox13.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox13.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox13.DataField = "Tara"
        Me.TextBox13.Height = 0.225!
        Me.TextBox13.Left = 5.65!
        Me.TextBox13.MultiLine = False
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat")
        Me.TextBox13.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox13.SummaryGroup = "GroupHeader1"
        Me.TextBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0.0!
        Me.TextBox13.Width = 0.3999999!
        '
        'TextBox14
        '
        Me.TextBox14.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox14.DataField = "PesoNeto"
        Me.TextBox14.Height = 0.225!
        Me.TextBox14.Left = 6.050001!
        Me.TextBox14.MultiLine = False
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat")
        Me.TextBox14.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox14.SummaryGroup = "GroupHeader1"
        Me.TextBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = 0.0!
        Me.TextBox14.Width = 0.5000001!
        '
        'TextBox15
        '
        Me.TextBox15.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox15.DataField = "CantidadSacosRecibos"
        Me.TextBox15.Height = 0.225!
        Me.TextBox15.Left = 6.575!
        Me.TextBox15.MultiLine = False
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat")
        Me.TextBox15.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox15.SummaryGroup = "GroupHeader1"
        Me.TextBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox15.Text = Nothing
        Me.TextBox15.Top = 0.0!
        Me.TextBox15.Width = 0.4250001!
        '
        'TextBox16
        '
        Me.TextBox16.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox16.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox16.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox16.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox16.DataField = "PesoNetoRecibos"
        Me.TextBox16.Height = 0.225!
        Me.TextBox16.Left = 7.0!
        Me.TextBox16.MultiLine = False
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat")
        Me.TextBox16.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox16.SummaryGroup = "GroupHeader1"
        Me.TextBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox16.Text = Nothing
        Me.TextBox16.Top = 0.0!
        Me.TextBox16.Width = 0.6250003!
        '
        'TextBox17
        '
        Me.TextBox17.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox17.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox17.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox17.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox17.DataField = "MermaBodega"
        Me.TextBox17.Height = 0.225!
        Me.TextBox17.Left = 7.65!
        Me.TextBox17.MultiLine = False
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat")
        Me.TextBox17.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox17.SummaryGroup = "GroupHeader1"
        Me.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox17.Text = Nothing
        Me.TextBox17.Top = 0.0!
        Me.TextBox17.Width = 0.5!
        '
        'TextBox18
        '
        Me.TextBox18.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox18.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox18.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox18.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox18.DataField = "CantidadSacosPI"
        Me.TextBox18.Height = 0.225!
        Me.TextBox18.Left = 8.150001!
        Me.TextBox18.MultiLine = False
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox18.SummaryGroup = "GroupHeader1"
        Me.TextBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox18.Text = Nothing
        Me.TextBox18.Top = 0.0!
        Me.TextBox18.Width = 0.4250003!
        '
        'TextBox19
        '
        Me.TextBox19.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox19.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox19.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox19.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox19.DataField = "PesoBrutoIniPI"
        Me.TextBox19.Height = 0.225!
        Me.TextBox19.Left = 8.575!
        Me.TextBox19.MultiLine = False
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox19.SummaryGroup = "GroupHeader1"
        Me.TextBox19.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox19.Text = Nothing
        Me.TextBox19.Top = 0.0!
        Me.TextBox19.Width = 0.5249998!
        '
        'TextBox20
        '
        Me.TextBox20.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox20.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox20.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox20.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox20.DataField = "PesoBrutoFinPI"
        Me.TextBox20.Height = 0.225!
        Me.TextBox20.Left = 9.075!
        Me.TextBox20.MultiLine = False
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox20.SummaryGroup = "GroupHeader1"
        Me.TextBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox20.Text = Nothing
        Me.TextBox20.Top = 0.0!
        Me.TextBox20.Width = 0.5499998!
        '
        'TextBox21
        '
        Me.TextBox21.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox21.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox21.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox21.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox21.DataField = "CantidadSacosPII"
        Me.TextBox21.Height = 0.225!
        Me.TextBox21.Left = 10.725!
        Me.TextBox21.MultiLine = False
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox21.SummaryGroup = "GroupHeader1"
        Me.TextBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox21.Text = Nothing
        Me.TextBox21.Top = 0.0!
        Me.TextBox21.Width = 0.3999998!
        '
        'TextBox22
        '
        Me.TextBox22.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox22.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox22.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox22.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox22.DataField = "PesoBrutoIniPII"
        Me.TextBox22.Height = 0.225!
        Me.TextBox22.Left = 11.125!
        Me.TextBox22.MultiLine = False
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox22.SummaryGroup = "GroupHeader1"
        Me.TextBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox22.Text = Nothing
        Me.TextBox22.Top = 0.0!
        Me.TextBox22.Width = 0.5500002!
        '
        'TextBox23
        '
        Me.TextBox23.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox23.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox23.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox23.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox23.DataField = "PesoNetoIniPII"
        Me.TextBox23.Height = 0.225!
        Me.TextBox23.Left = 12.075!
        Me.TextBox23.MultiLine = False
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox23.SummaryGroup = "GroupHeader1"
        Me.TextBox23.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox23.Text = Nothing
        Me.TextBox23.Top = 0.0!
        Me.TextBox23.Width = 0.4999995!
        '
        'TextBox24
        '
        Me.TextBox24.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox24.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox24.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox24.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox24.DataField = "TaraIniPII"
        Me.TextBox24.Height = 0.225!
        Me.TextBox24.Left = 11.675!
        Me.TextBox24.MultiLine = False
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat")
        Me.TextBox24.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox24.SummaryGroup = "GroupHeader1"
        Me.TextBox24.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox24.Text = Nothing
        Me.TextBox24.Top = 0.0!
        Me.TextBox24.Width = 0.3999999!
        '
        'TextBox25
        '
        Me.TextBox25.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox25.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox25.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox25.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox25.DataField = "MermaTransitoPI"
        Me.TextBox25.Height = 0.225!
        Me.TextBox25.Left = 9.650001!
        Me.TextBox25.MultiLine = False
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox25.SummaryGroup = "GroupHeader1"
        Me.TextBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox25.Text = Nothing
        Me.TextBox25.Top = 0.0!
        Me.TextBox25.Width = 0.4999997!
        '
        'TextBox26
        '
        Me.TextBox26.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox26.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox26.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox26.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox26.DataField = "MermaBodegaPI"
        Me.TextBox26.Height = 0.225!
        Me.TextBox26.Left = 10.175!
        Me.TextBox26.MultiLine = False
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox26.SummaryGroup = "GroupHeader1"
        Me.TextBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox26.Text = Nothing
        Me.TextBox26.Top = 0.0!
        Me.TextBox26.Width = 0.4999997!
        '
        'TextBox27
        '
        Me.TextBox27.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox27.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox27.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox27.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox27.DataField = "PesoBruto"
        Me.TextBox27.Height = 0.225!
        Me.TextBox27.Left = 12.6!
        Me.TextBox27.MultiLine = False
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.OutputFormat = resources.GetString("TextBox27.OutputFormat")
        Me.TextBox27.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox27.SummaryGroup = "GroupHeader1"
        Me.TextBox27.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox27.Text = Nothing
        Me.TextBox27.Top = 0.0!
        Me.TextBox27.Width = 0.4999999!
        '
        'TextBox28
        '
        Me.TextBox28.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox28.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox28.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox28.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox28.DataField = "MermaTransitoPII"
        Me.TextBox28.Height = 0.225!
        Me.TextBox28.Left = 13.125!
        Me.TextBox28.MultiLine = False
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox28.SummaryGroup = "GroupHeader1"
        Me.TextBox28.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox28.Text = Nothing
        Me.TextBox28.Top = 0.0!
        Me.TextBox28.Width = 0.4999997!
        '
        'TextBox29
        '
        Me.TextBox29.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox29.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox29.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox29.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox29.DataField = "CantidadSacos"
        Me.TextBox29.Height = 0.25!
        Me.TextBox29.Left = 4.725!
        Me.TextBox29.MultiLine = False
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.OutputFormat = resources.GetString("TextBox29.OutputFormat")
        Me.TextBox29.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.TextBox29.SummaryGroup = "GroupHeader1"
        Me.TextBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.PageTotal
        Me.TextBox29.Text = Nothing
        Me.TextBox29.Top = 0.0!
        Me.TextBox29.Width = 0.4000001!
        '
        'ArepReporteRemision
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=TRANSPORTE;Data Source=JUANBERMUDEZ-PC\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.05!
        Me.PageSettings.Margins.Left = 0.05!
        Me.PageSettings.Margins.Right = 0.05!
        Me.PageSettings.Margins.Top = 0.05!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 14.0!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Legal
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 14.21875!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCompañia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumeroRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoBrutoRemision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoNetoRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantSacos1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoBruto1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoNeto1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantSacos2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoBruto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoNeto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumeroRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIdRemision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtListadoRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTaraPlanta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMermaTransitoPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMermaBodegaPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMermaTransitoPII, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMermaBodegaPII, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblModalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCompañia As DataDynamics.ActiveReports.Label
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Private WithEvents Label39 As DataDynamics.ActiveReports.Label
    Private WithEvents Label38 As DataDynamics.ActiveReports.Label
    Private WithEvents Label42 As DataDynamics.ActiveReports.Label
    Private WithEvents Label43 As DataDynamics.ActiveReports.Label
    Private WithEvents Label44 As DataDynamics.ActiveReports.Label
    Private WithEvents Label46 As DataDynamics.ActiveReports.Label
    Private WithEvents Label49 As DataDynamics.ActiveReports.Label
    Private WithEvents Label47 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label48 As DataDynamics.ActiveReports.Label
    Private WithEvents Label45 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCont As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtNumeroRecibos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoBrutoRemision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Private WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoNetoRecibos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantSacos1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoBruto1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoNeto1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantSacos2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoBruto2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoNeto2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtNumeroRecibo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblNumero As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtIdRemision As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtProductor As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label17 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtListadoRecibos As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label7 As DataDynamics.ActiveReports.Label
    Private WithEvents Label18 As DataDynamics.ActiveReports.Label
    Private WithEvents Label19 As DataDynamics.ActiveReports.Label
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtTaraPlanta As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label20 As DataDynamics.ActiveReports.Label
    Private WithEvents Label21 As DataDynamics.ActiveReports.Label
    Private WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtMermaTransitoPI As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMermaBodegaPI As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMermaTransitoPII As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMermaBodegaPII As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLocalidad As DataDynamics.ActiveReports.Label
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label26 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblModalidad As DataDynamics.ActiveReports.Label
    Friend WithEvents Label27 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox30 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox16 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox18 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox19 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox20 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox21 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox22 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox23 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox24 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox25 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox26 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox27 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox28 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox29 As DataDynamics.ActiveReports.TextBox
End Class
