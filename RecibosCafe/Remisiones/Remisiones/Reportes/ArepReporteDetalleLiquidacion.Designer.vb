<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepReporteDetalleLiquidacion 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepReporteDetalleLiquidacion))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.LblNumero = New DataDynamics.ActiveReports.Label
        Me.LblFecha = New DataDynamics.ActiveReports.Label
        Me.LblCosecha = New DataDynamics.ActiveReports.Label
        Me.LblLocalidad = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.TxtPesoNeto = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.TxtPrecioNeto = New DataDynamics.ActiveReports.TextBox
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.TxtPagado = New DataDynamics.ActiveReports.TextBox
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtIdLiquidacion = New DataDynamics.ActiveReports.TextBox
        Me.TxtAbono = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.TextBox19 = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label17 = New DataDynamics.ActiveReports.Label
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrecioNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPagado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIdLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.LblEncabezado.Height = 0.175!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 0.175!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: normal; font-si" & _
            "ze: 9.75pt; "
        Me.LblEncabezado.Text = "EXPORTADORA ATLANTIC, S.A"
        Me.LblEncabezado.Top = 0.0!
        Me.LblEncabezado.Width = 2.55!
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
        Me.Label1.Height = 0.175!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.175!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: normal; font-si" & _
            "ze: 9.75pt; "
        Me.Label1.Text = "Managua, Nicaragua"
        Me.Label1.Top = 0.25!
        Me.Label1.Width = 2.55!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.175!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.175!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: normal; font-si" & _
            "ze: 9.75pt; "
        Me.Label2.Text = "Sucursal Matagalpa Telf: 2277-5311 "
        Me.Label2.Top = 0.425!
        Me.Label2.Width = 2.55!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.175!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.175!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: normal; font-si" & _
            "ze: 9.75pt; "
        Me.Label3.Text = "Sucursal Jinotega Telf: 2782-4251 "
        Me.Label3.Top = 0.6!
        Me.Label3.Width = 2.55!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.175!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.175!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: normal; font-si" & _
            "ze: 9.75pt; "
        Me.Label4.Text = "Sucursal Ocotal Telf: 2732-2181 "
        Me.Label4.Top = 0.775!
        Me.Label4.Width = 2.55!
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
        Me.Label5.Height = 0.175!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.175!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: normal; font-si" & _
            "ze: 8.25pt; "
        Me.Label5.Text = "REEMBOLSO COMPRA DIRECTA DE CAFE"
        Me.Label5.Top = 1.1!
        Me.Label5.Width = 2.55!
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
        Me.LblNumero.Height = 0.2!
        Me.LblNumero.HyperLink = Nothing
        Me.LblNumero.Left = 0.2!
        Me.LblNumero.Name = "LblNumero"
        Me.LblNumero.Style = "text-align: center; "
        Me.LblNumero.Text = ""
        Me.LblNumero.Top = 1.3!
        Me.LblNumero.Width = 2.55!
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
        Me.LblFecha.Left = 0.175!
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; "
        Me.LblFecha.Text = "Fecha Reembolso:"
        Me.LblFecha.Top = 1.625!
        Me.LblFecha.Width = 2.55!
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
        Me.LblCosecha.Height = 0.2!
        Me.LblCosecha.HyperLink = Nothing
        Me.LblCosecha.Left = 0.175!
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; "
        Me.LblCosecha.Text = "COSECHA:"
        Me.LblCosecha.Top = 1.85!
        Me.LblCosecha.Width = 2.55!
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
        Me.LblLocalidad.Left = 0.175!
        Me.LblLocalidad.Name = "LblLocalidad"
        Me.LblLocalidad.Style = "ddo-char-set: 0; text-align: left; font-size: 9pt; "
        Me.LblLocalidad.Text = "LOCALIDAD"
        Me.LblLocalidad.Top = 2.05!
        Me.LblLocalidad.Width = 2.55!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label6, Me.Label7, Me.Label8, Me.TextBox1, Me.Label9, Me.TxtPesoNeto, Me.Label10, Me.TxtPrecioNeto, Me.Label11, Me.Label12, Me.TxtPagado, Me.Label13, Me.TextBox3, Me.TxtIdLiquidacion, Me.TxtAbono})
        Me.Detail1.Height = 1.46875!
        Me.Detail1.Name = "Detail1"
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
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label6.Height = 0.05!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.05!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; "
        Me.Label6.Text = ""
        Me.Label6.Top = 0.0!
        Me.Label6.Width = 2.55!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Height = 0.05!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.05!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; "
        Me.Label7.Text = ""
        Me.Label7.Top = 1.375!
        Me.Label7.Width = 2.55!
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
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.05!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Times New Roma" & _
            "n; "
        Me.Label8.Text = "LIQUIDACION:"
        Me.Label8.Top = 0.075!
        Me.Label8.Width = 0.8500001!
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
        Me.TextBox1.DataField = "Codigo"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.9!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.075!
        Me.TextBox1.Width = 1.7!
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
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.05!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Times New Roma" & _
            "n; "
        Me.Label9.Text = "KILOGRAMOS:"
        Me.Label9.Top = 0.3!
        Me.Label9.Width = 0.8500001!
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
        Me.TxtPesoNeto.DataField = "PesoNeto"
        Me.TxtPesoNeto.Height = 0.2!
        Me.TxtPesoNeto.Left = 0.9!
        Me.TxtPesoNeto.Name = "TxtPesoNeto"
        Me.TxtPesoNeto.OutputFormat = resources.GetString("TxtPesoNeto.OutputFormat")
        Me.TxtPesoNeto.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtPesoNeto.Text = Nothing
        Me.TxtPesoNeto.Top = 0.3!
        Me.TxtPesoNeto.Width = 1.7!
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
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.05!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Times New Roma" & _
            "n; "
        Me.Label10.Text = "PRECIO NETO:"
        Me.Label10.Top = 0.525!
        Me.Label10.Width = 0.8500001!
        '
        'TxtPrecioNeto
        '
        Me.TxtPrecioNeto.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPrecioNeto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPrecioNeto.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPrecioNeto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPrecioNeto.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPrecioNeto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPrecioNeto.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPrecioNeto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPrecioNeto.Height = 0.2!
        Me.TxtPrecioNeto.Left = 0.925!
        Me.TxtPrecioNeto.Name = "TxtPrecioNeto"
        Me.TxtPrecioNeto.OutputFormat = resources.GetString("TxtPrecioNeto.OutputFormat")
        Me.TxtPrecioNeto.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtPrecioNeto.Text = Nothing
        Me.TxtPrecioNeto.Top = 0.525!
        Me.TxtPrecioNeto.Width = 1.675!
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
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.075!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Times New Roma" & _
            "n; "
        Me.Label11.Text = "ABONO (C$):"
        Me.Label11.Top = 0.75!
        Me.Label11.Width = 0.8500001!
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
        Me.Label12.Height = 0.2!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.075!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Times New Roma" & _
            "n; "
        Me.Label12.Text = "PAGADO (C$):"
        Me.Label12.Top = 0.95!
        Me.Label12.Width = 0.8500001!
        '
        'TxtPagado
        '
        Me.TxtPagado.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPagado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPagado.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPagado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPagado.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPagado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPagado.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPagado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPagado.Height = 0.2!
        Me.TxtPagado.Left = 0.95!
        Me.TxtPagado.Name = "TxtPagado"
        Me.TxtPagado.OutputFormat = resources.GetString("TxtPagado.OutputFormat")
        Me.TxtPagado.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtPagado.Text = Nothing
        Me.TxtPagado.Top = 0.95!
        Me.TxtPagado.Width = 1.65!
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
        Me.Label13.Left = 0.075!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Times New Roma" & _
            "n; "
        Me.Label13.Text = "PRODUCTOR:"
        Me.Label13.Top = 1.15!
        Me.Label13.Width = 0.8500001!
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
        Me.TextBox3.DataField = "Nombres"
        Me.TextBox3.Height = 0.2!
        Me.TextBox3.Left = 0.95!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 1.15!
        Me.TextBox3.Width = 1.65!
        '
        'TxtIdLiquidacion
        '
        Me.TxtIdLiquidacion.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtIdLiquidacion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtIdLiquidacion.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtIdLiquidacion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtIdLiquidacion.Border.RightColor = System.Drawing.Color.Black
        Me.TxtIdLiquidacion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtIdLiquidacion.Border.TopColor = System.Drawing.Color.Black
        Me.TxtIdLiquidacion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtIdLiquidacion.DataField = "IdLiquidacionPergamino"
        Me.TxtIdLiquidacion.Height = 0.1979167!
        Me.TxtIdLiquidacion.Left = 1.05!
        Me.TxtIdLiquidacion.Name = "TxtIdLiquidacion"
        Me.TxtIdLiquidacion.Style = ""
        Me.TxtIdLiquidacion.Text = Nothing
        Me.TxtIdLiquidacion.Top = 1.525!
        Me.TxtIdLiquidacion.Visible = False
        Me.TxtIdLiquidacion.Width = 1.0!
        '
        'TxtAbono
        '
        Me.TxtAbono.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtAbono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtAbono.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtAbono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtAbono.Border.RightColor = System.Drawing.Color.Black
        Me.TxtAbono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtAbono.Border.TopColor = System.Drawing.Color.Black
        Me.TxtAbono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtAbono.Height = 0.2!
        Me.TxtAbono.Left = 0.925!
        Me.TxtAbono.Name = "TxtAbono"
        Me.TxtAbono.OutputFormat = resources.GetString("TxtAbono.OutputFormat")
        Me.TxtAbono.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtAbono.Text = Nothing
        Me.TxtAbono.Top = 0.7250001!
        Me.TxtAbono.Width = 1.675!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox19})
        Me.GroupHeader1.DataField = "TipoCompra"
        Me.GroupHeader1.Height = 0.21875!
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.TextBox19.DataField = "TipoCompra"
        Me.TextBox19.Height = 0.1875!
        Me.TextBox19.Left = 0.025!
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox19.Text = Nothing
        Me.TextBox19.Top = 0.0!
        Me.TextBox19.Width = 2.625!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label14, Me.TextBox8})
        Me.GroupFooter1.Height = 0.3125!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.Label14.Height = 0.1979167!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 0.4!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.Label14.Text = "Total a Pagar"
        Me.Label14.Top = 0.0!
        Me.Label14.Width = 1.0!
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
        Me.TextBox8.DataField = "Monto"
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 1.425!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox8.SummaryGroup = "GroupHeader1"
        Me.TextBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 1.125!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblEncabezado, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.LblNumero, Me.LblFecha, Me.LblCosecha, Me.LblLocalidad})
        Me.ReportHeader1.Height = 2.302083!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label15, Me.Label16, Me.Label17})
        Me.ReportFooter1.Height = 2.697917!
        Me.ReportFooter1.Name = "ReportFooter1"
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
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Height = 0.2!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0.15!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "text-align: center; "
        Me.Label15.Text = "RESPONSABLE AGENCIA"
        Me.Label15.Top = 0.6!
        Me.Label15.Width = 2.3!
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
        Me.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label16.Height = 0.2!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.2!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; "
        Me.Label16.Text = "REVISION TESORERIA"
        Me.Label16.Top = 1.475!
        Me.Label16.Width = 2.3!
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
        Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.225!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "text-align: center; "
        Me.Label17.Text = "AUTORIZADO POR GERENCIA"
        Me.Label17.Top = 2.3!
        Me.Label17.Width = 2.3!
        '
        'ArepReporteDetalleLiquidacion
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=TRANSPORTE;Data Source=JUANBERMUDEZ-PC\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.05!
        Me.PageSettings.Margins.Left = 0.05!
        Me.PageSettings.Margins.Right = 0.05!
        Me.PageSettings.Margins.Top = 0.05!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.78125!
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
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoNeto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrecioNeto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPagado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIdLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNumero As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCosecha As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLocalidad As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TextBox19 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtPesoNeto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtPrecioNeto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtPagado As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtIdLiquidacion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtAbono As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label17 As DataDynamics.ActiveReports.Label
End Class
