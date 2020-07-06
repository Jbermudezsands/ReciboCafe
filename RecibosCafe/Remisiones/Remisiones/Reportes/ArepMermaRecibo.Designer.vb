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
        Dim OleDBDataSource1 As DataDynamics.ActiveReports.DataSources.OleDBDataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepMermaRecibo))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblCompañia = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TxtMontoPagado = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.LblMontoPagado = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.LblTipoInformacion2 = New DataDynamics.ActiveReports.Label
        Me.LblTipoInformacion = New DataDynamics.ActiveReports.Label
        Me.TxtTipo = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TxtTotalMontoPagado = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.TxtMerma = New DataDynamics.ActiveReports.TextBox
        Me.TxtTotalMerma = New DataDynamics.ActiveReports.TextBox
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCompañia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMontoPagado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMontoPagado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoInformacion2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalMontoPagado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMerma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalMerma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblCompañia, Me.Label1})
        Me.PageHeader1.Height = 1.020833!
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
        Me.LblCompañia.Left = 1.975!
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
        Me.Label1.Left = 1.975!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; ddo-char-set: 0; font-weight: bold; font-style: normal; font-size: " & _
            "9pt; "
        Me.Label1.Text = "REPORTE MERMA  BODEGA VRS RECIBO VRS REMISION"
        Me.Label1.Top = 0.225!
        Me.Label1.Width = 4.5!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TxtMontoPagado, Me.TxtMerma})
        Me.Detail1.Height = 0.2395833!
        Me.Detail1.Name = "Detail1"
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
        Me.TextBox1.DataField = "Region"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.125!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.825!
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
        Me.TextBox2.DataField = "Localidad"
        Me.TextBox2.Height = 0.2!
        Me.TextBox2.Left = 0.95!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.9750001!
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
        Me.TextBox3.DataField = "Calidad"
        Me.TextBox3.Height = 0.2!
        Me.TextBox3.Left = 1.925!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.675!
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
        Me.TextBox4.DataField = "EstadoFisico"
        Me.TextBox4.Height = 0.2!
        Me.TextBox4.Left = 2.6!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.75!
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
        Me.TextBox5.DataField = "TipoCafe"
        Me.TextBox5.Height = 0.2!
        Me.TextBox5.Left = 3.35!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.75!
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
        Me.TextBox6.DataField = "TipoCompra"
        Me.TextBox6.Height = 0.2!
        Me.TextBox6.Left = 4.125!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.8499999!
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
        Me.TextBox7.DataField = "PesoBruto"
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 4.975!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.8750002!
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
        Me.TextBox8.DataField = "PesoNeto"
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 5.85!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.825!
        '
        'TxtMontoPagado
        '
        Me.TxtMontoPagado.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMontoPagado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMontoPagado.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMontoPagado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMontoPagado.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMontoPagado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMontoPagado.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMontoPagado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMontoPagado.DataField = "MontoPagado"
        Me.TxtMontoPagado.Height = 0.2!
        Me.TxtMontoPagado.Left = 6.675001!
        Me.TxtMontoPagado.Name = "TxtMontoPagado"
        Me.TxtMontoPagado.OutputFormat = resources.GetString("TxtMontoPagado.OutputFormat")
        Me.TxtMontoPagado.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtMontoPagado.Text = Nothing
        Me.TxtMontoPagado.Top = 0.0!
        Me.TxtMontoPagado.Width = 0.7999998!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.LblMontoPagado, Me.Label10, Me.LblTipoInformacion2, Me.LblTipoInformacion, Me.TxtTipo})
        Me.GroupHeader1.DataField = "Tipo"
        Me.GroupHeader1.Height = 0.8541667!
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.Label2.Left = 0.125!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: center; "
        Me.Label2.Text = "REGIONAL"
        Me.Label2.Top = 0.4!
        Me.Label2.Width = 0.8500001!
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
        Me.Label3.Left = 0.9750001!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; "
        Me.Label3.Text = "LOCALIDAD"
        Me.Label3.Top = 0.4!
        Me.Label3.Width = 0.95!
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
        Me.Label4.Left = 1.925!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "text-align: center; "
        Me.Label4.Text = "CALIDAD"
        Me.Label4.Top = 0.4!
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
        Me.Label5.Left = 2.6!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "text-align: center; "
        Me.Label5.Text = "ESTADO FISICO"
        Me.Label5.Top = 0.4!
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
        Me.Label6.Left = 3.35!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; "
        Me.Label6.Text = "TIPO CAFE"
        Me.Label6.Top = 0.4!
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
        Me.Label7.Left = 4.1!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; "
        Me.Label7.Text = "TIPO DE COMPRA"
        Me.Label7.Top = 0.4!
        Me.Label7.Width = 0.8750002!
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
        Me.Label8.Left = 4.975!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; "
        Me.Label8.Text = "PESO BRUTO KG "
        Me.Label8.Top = 0.4!
        Me.Label8.Width = 0.8500001!
        '
        'LblMontoPagado
        '
        Me.LblMontoPagado.Border.BottomColor = System.Drawing.Color.Black
        Me.LblMontoPagado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblMontoPagado.Border.LeftColor = System.Drawing.Color.Black
        Me.LblMontoPagado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblMontoPagado.Border.RightColor = System.Drawing.Color.Black
        Me.LblMontoPagado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblMontoPagado.Border.TopColor = System.Drawing.Color.Black
        Me.LblMontoPagado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblMontoPagado.Height = 0.4!
        Me.LblMontoPagado.HyperLink = Nothing
        Me.LblMontoPagado.Left = 6.7!
        Me.LblMontoPagado.Name = "LblMontoPagado"
        Me.LblMontoPagado.Style = "text-align: center; "
        Me.LblMontoPagado.Text = "MONTO PAGADO"
        Me.LblMontoPagado.Top = 0.4!
        Me.LblMontoPagado.Width = 0.8000002!
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
        Me.Label10.Left = 5.825!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; "
        Me.Label10.Text = "PESO NETO KG RECIBO"
        Me.Label10.Top = 0.4!
        Me.Label10.Width = 0.8750002!
        '
        'LblTipoInformacion2
        '
        Me.LblTipoInformacion2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTipoInformacion2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTipoInformacion2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTipoInformacion2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTipoInformacion2.Border.RightColor = System.Drawing.Color.Black
        Me.LblTipoInformacion2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTipoInformacion2.Border.TopColor = System.Drawing.Color.Black
        Me.LblTipoInformacion2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTipoInformacion2.Height = 0.2!
        Me.LblTipoInformacion2.HyperLink = Nothing
        Me.LblTipoInformacion2.Left = 0.125!
        Me.LblTipoInformacion2.Name = "LblTipoInformacion2"
        Me.LblTipoInformacion2.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 9pt; "
        Me.LblTipoInformacion2.Text = "CONSOLIDADO DE ENTRADA - FECHA DE RECEPCIO:"
        Me.LblTipoInformacion2.Top = 0.2!
        Me.LblTipoInformacion2.Width = 7.375!
        '
        'LblTipoInformacion
        '
        Me.LblTipoInformacion.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTipoInformacion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTipoInformacion.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTipoInformacion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTipoInformacion.Border.RightColor = System.Drawing.Color.Black
        Me.LblTipoInformacion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTipoInformacion.Border.TopColor = System.Drawing.Color.Black
        Me.LblTipoInformacion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTipoInformacion.Height = 0.2!
        Me.LblTipoInformacion.HyperLink = Nothing
        Me.LblTipoInformacion.Left = 0.125!
        Me.LblTipoInformacion.Name = "LblTipoInformacion"
        Me.LblTipoInformacion.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 9pt; "
        Me.LblTipoInformacion.Text = "INFORMACION MODULO DE RECIBO"
        Me.LblTipoInformacion.Top = 0.0!
        Me.LblTipoInformacion.Width = 7.375!
        '
        'TxtTipo
        '
        Me.TxtTipo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTipo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTipo.DataField = "Tipo"
        Me.TxtTipo.Height = 0.1979167!
        Me.TxtTipo.Left = 4.322917!
        Me.TxtTipo.Name = "TxtTipo"
        Me.TxtTipo.Style = ""
        Me.TxtTipo.Text = "TextBox10"
        Me.TxtTipo.Top = 0.9479167!
        Me.TxtTipo.Visible = False
        Me.TxtTipo.Width = 1.0!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtTotalMontoPagado, Me.TextBox10, Me.TextBox11, Me.TxtTotalMerma})
        Me.GroupFooter1.Height = 0.2708333!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TxtTotalMontoPagado
        '
        Me.TxtTotalMontoPagado.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotalMontoPagado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMontoPagado.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotalMontoPagado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMontoPagado.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotalMontoPagado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMontoPagado.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotalMontoPagado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMontoPagado.DataField = "MontoPagado"
        Me.TxtTotalMontoPagado.Height = 0.2!
        Me.TxtTotalMontoPagado.Left = 6.7!
        Me.TxtTotalMontoPagado.Name = "TxtTotalMontoPagado"
        Me.TxtTotalMontoPagado.OutputFormat = resources.GetString("TxtTotalMontoPagado.OutputFormat")
        Me.TxtTotalMontoPagado.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtTotalMontoPagado.SummaryGroup = "GroupHeader1"
        Me.TxtTotalMontoPagado.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotalMontoPagado.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtTotalMontoPagado.Text = Nothing
        Me.TxtTotalMontoPagado.Top = 0.0!
        Me.TxtTotalMontoPagado.Width = 0.7750002!
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
        Me.TextBox10.Height = 0.2!
        Me.TextBox10.Left = 5.875!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox10.SummaryGroup = "GroupHeader1"
        Me.TextBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.8250003!
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
        Me.TextBox11.Height = 0.2!
        Me.TextBox11.Left = 5.05!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat")
        Me.TextBox11.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TextBox11.SummaryGroup = "GroupHeader1"
        Me.TextBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox11.Text = Nothing
        Me.TextBox11.Top = 0.0!
        Me.TextBox11.Width = 0.825!
        '
        'TxtMerma
        '
        Me.TxtMerma.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMerma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMerma.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMerma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMerma.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMerma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMerma.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMerma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMerma.DataField = "Merma"
        Me.TxtMerma.Height = 0.2!
        Me.TxtMerma.Left = 6.675001!
        Me.TxtMerma.Name = "TxtMerma"
        Me.TxtMerma.OutputFormat = resources.GetString("TxtMerma.OutputFormat")
        Me.TxtMerma.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtMerma.Text = Nothing
        Me.TxtMerma.Top = 0.0!
        Me.TxtMerma.Visible = False
        Me.TxtMerma.Width = 0.7999998!
        '
        'TxtTotalMerma
        '
        Me.TxtTotalMerma.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotalMerma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMerma.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotalMerma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMerma.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotalMerma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMerma.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotalMerma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalMerma.DataField = "Merma"
        Me.TxtTotalMerma.Height = 0.2!
        Me.TxtTotalMerma.Left = 6.7!
        Me.TxtTotalMerma.Name = "TxtTotalMerma"
        Me.TxtTotalMerma.OutputFormat = resources.GetString("TxtTotalMerma.OutputFormat")
        Me.TxtTotalMerma.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.TxtTotalMerma.SummaryGroup = "GroupHeader1"
        Me.TxtTotalMerma.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotalMerma.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TxtTotalMerma.Text = Nothing
        Me.TxtTotalMerma.Top = 0.0!
        Me.TxtTotalMerma.Visible = False
        Me.TxtTotalMerma.Width = 0.7499999!
        '
        'ArepMermaRecibo
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
            "Catalog=TRANSPORTE;Data Source=JUANBERMUDEZ-PC\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.2!
        Me.PageSettings.Margins.Left = 0.2!
        Me.PageSettings.Margins.Right = 0.2!
        Me.PageSettings.Margins.Top = 0.2!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.6875!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
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
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMontoPagado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMontoPagado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoInformacion2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalMontoPagado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMerma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalMerma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblCompañia As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMontoPagado As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMontoPagado As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoInformacion2 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoInformacion As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TxtTipo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTotalMontoPagado As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMerma As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTotalMerma As DataDynamics.ActiveReports.TextBox
End Class
