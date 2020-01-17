<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SrpPuntosIntermedios 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SrpPuntosIntermedios))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TxtReferencia = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TxtTitulo = New DataDynamics.ActiveReports.TextBox
        Me.SubReportIntermedioOrigen = New DataDynamics.ActiveReports.SubReport
        Me.TextBox27 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox28 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox30 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox31 = New DataDynamics.ActiveReports.TextBox
        Me.SubReportIntermedioEntrada = New DataDynamics.ActiveReports.SubReport
        Me.TextBox29 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox32 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox33 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox34 = New DataDynamics.ActiveReports.TextBox
        Me.SubReportIntermedioSalida = New DataDynamics.ActiveReports.SubReport
        Me.TextBox35 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox36 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox37 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.TxtOrigen = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.TxtDestino = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.TxtEmpresa = New DataDynamics.ActiveReports.TextBox
        Me.TxtPlaca = New DataDynamics.ActiveReports.TextBox
        Me.TxtConductor = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.TxtFechaEntrada = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaCarga = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaSalida = New DataDynamics.ActiveReports.TextBox
        CType(Me.TxtReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtReferencia, Me.TxtTitulo, Me.SubReportIntermedioOrigen, Me.TextBox27, Me.TextBox28, Me.TextBox30, Me.TextBox31, Me.SubReportIntermedioEntrada, Me.TextBox29, Me.TextBox32, Me.TextBox33, Me.TextBox34, Me.SubReportIntermedioSalida, Me.TextBox35, Me.TextBox36, Me.TextBox37, Me.TextBox5, Me.Label1, Me.TxtOrigen, Me.Label2, Me.TxtDestino, Me.TextBox1, Me.Label3, Me.Label4, Me.Label5, Me.TxtEmpresa, Me.TxtPlaca, Me.TxtConductor, Me.Label6, Me.Label7, Me.Label8, Me.TxtFechaEntrada, Me.TxtFechaCarga, Me.TxtFechaSalida})
        Me.Detail1.Height = 4.041667!
        Me.Detail1.Name = "Detail1"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtReferencia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtReferencia.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtReferencia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtReferencia.Border.RightColor = System.Drawing.Color.Black
        Me.TxtReferencia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtReferencia.Border.TopColor = System.Drawing.Color.Black
        Me.TxtReferencia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtReferencia.DataField = "CantidadSacosOrigen"
        Me.TxtReferencia.Height = 0.1979167!
        Me.TxtReferencia.Left = 0.0!
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.TxtReferencia.Text = Nothing
        Me.TxtReferencia.Top = 0.0!
        Me.TxtReferencia.Visible = False
        Me.TxtReferencia.Width = 0.25!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.DataField = "IdRemisionPergamino"
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TxtTitulo
        '
        Me.TxtTitulo.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTitulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTitulo.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTitulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTitulo.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTitulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTitulo.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTitulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTitulo.Height = 0.1875!
        Me.TxtTitulo.Left = 0.0!
        Me.TxtTitulo.Name = "TxtTitulo"
        Me.TxtTitulo.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TxtTitulo.Text = "Puntos Intermedios"
        Me.TxtTitulo.Top = 0.0!
        Me.TxtTitulo.Width = 2.625!
        '
        'SubReportIntermedioOrigen
        '
        Me.SubReportIntermedioOrigen.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportIntermedioOrigen.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioOrigen.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportIntermedioOrigen.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioOrigen.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportIntermedioOrigen.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioOrigen.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportIntermedioOrigen.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioOrigen.CloseBorder = False
        Me.SubReportIntermedioOrigen.Height = 0.25!
        Me.SubReportIntermedioOrigen.Left = 0.5!
        Me.SubReportIntermedioOrigen.Name = "SubReportIntermedioOrigen"
        Me.SubReportIntermedioOrigen.Report = Nothing
        Me.SubReportIntermedioOrigen.ReportName = "SubReport1"
        Me.SubReportIntermedioOrigen.Top = 2.75!
        Me.SubReportIntermedioOrigen.Width = 1.5625!
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
        Me.TextBox27.Height = 0.1875!
        Me.TextBox27.Left = 0.5!
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox27.Text = "Detalle de Pesadas Origen"
        Me.TextBox27.Top = 2.375!
        Me.TextBox27.Width = 1.5625!
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
        Me.TextBox28.Height = 0.1875!
        Me.TextBox28.Left = 1.0!
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox28.Text = "Sacos"
        Me.TextBox28.Top = 2.5625!
        Me.TextBox28.Width = 0.4375!
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
        Me.TextBox30.Height = 0.1875!
        Me.TextBox30.Left = 1.4375!
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox30.Text = "P.Bruto"
        Me.TextBox30.Top = 2.5625!
        Me.TextBox30.Width = 0.625!
        '
        'TextBox31
        '
        Me.TextBox31.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox31.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox31.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox31.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox31.Height = 0.1875!
        Me.TextBox31.Left = 0.5!
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox31.Text = "Ref"
        Me.TextBox31.Top = 2.5625!
        Me.TextBox31.Width = 0.5!
        '
        'SubReportIntermedioEntrada
        '
        Me.SubReportIntermedioEntrada.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportIntermedioEntrada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioEntrada.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportIntermedioEntrada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioEntrada.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportIntermedioEntrada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioEntrada.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportIntermedioEntrada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioEntrada.CloseBorder = False
        Me.SubReportIntermedioEntrada.Height = 0.25!
        Me.SubReportIntermedioEntrada.Left = 0.0625!
        Me.SubReportIntermedioEntrada.Name = "SubReportIntermedioEntrada"
        Me.SubReportIntermedioEntrada.Report = Nothing
        Me.SubReportIntermedioEntrada.ReportName = "SubReport1"
        Me.SubReportIntermedioEntrada.Top = 3.6875!
        Me.SubReportIntermedioEntrada.Width = 1.5625!
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
        Me.TextBox29.Height = 0.1875!
        Me.TextBox29.Left = 0.0625!
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox29.Text = "Entradas"
        Me.TextBox29.Top = 3.3125!
        Me.TextBox29.Width = 1.5625!
        '
        'TextBox32
        '
        Me.TextBox32.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox32.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox32.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox32.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox32.Height = 0.1875!
        Me.TextBox32.Left = 0.5625!
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox32.Text = "Sacos"
        Me.TextBox32.Top = 3.5!
        Me.TextBox32.Width = 0.4375!
        '
        'TextBox33
        '
        Me.TextBox33.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox33.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox33.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox33.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox33.Height = 0.1875!
        Me.TextBox33.Left = 1.0!
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox33.Text = "P.Bruto"
        Me.TextBox33.Top = 3.5!
        Me.TextBox33.Width = 0.625!
        '
        'TextBox34
        '
        Me.TextBox34.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox34.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox34.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox34.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox34.Height = 0.1875!
        Me.TextBox34.Left = 0.0625!
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox34.Text = "Ref"
        Me.TextBox34.Top = 3.5!
        Me.TextBox34.Width = 0.5!
        '
        'SubReportIntermedioSalida
        '
        Me.SubReportIntermedioSalida.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportIntermedioSalida.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioSalida.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportIntermedioSalida.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioSalida.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportIntermedioSalida.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioSalida.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportIntermedioSalida.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedioSalida.CloseBorder = False
        Me.SubReportIntermedioSalida.Height = 0.25!
        Me.SubReportIntermedioSalida.Left = 1.625!
        Me.SubReportIntermedioSalida.Name = "SubReportIntermedioSalida"
        Me.SubReportIntermedioSalida.Report = Nothing
        Me.SubReportIntermedioSalida.ReportName = "SubReport1"
        Me.SubReportIntermedioSalida.Top = 3.6875!
        Me.SubReportIntermedioSalida.Width = 1.0625!
        '
        'TextBox35
        '
        Me.TextBox35.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox35.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox35.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox35.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox35.Height = 0.1875!
        Me.TextBox35.Left = 1.625!
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox35.Text = "Salidas"
        Me.TextBox35.Top = 3.3125!
        Me.TextBox35.Width = 1.0625!
        '
        'TextBox36
        '
        Me.TextBox36.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox36.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox36.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox36.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox36.Height = 0.1875!
        Me.TextBox36.Left = 1.625!
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox36.Text = "Sacos"
        Me.TextBox36.Top = 3.5!
        Me.TextBox36.Width = 0.4375!
        '
        'TextBox37
        '
        Me.TextBox37.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox37.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox37.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox37.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox37.Height = 0.1875!
        Me.TextBox37.Left = 2.0625!
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox37.Text = "P.Bruto"
        Me.TextBox37.Top = 3.5!
        Me.TextBox37.Width = 0.625!
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
        Me.TextBox5.Height = 0.1875!
        Me.TextBox5.Left = 0.0625!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox5.Text = "Detalle de Pesadas"
        Me.TextBox5.Top = 3.125!
        Me.TextBox5.Width = 2.625!
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
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label1.Text = "Origen:"
        Me.Label1.Top = 0.9375!
        Me.Label1.Width = 0.5!
        '
        'TxtOrigen
        '
        Me.TxtOrigen.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtOrigen.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtOrigen.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen.Border.RightColor = System.Drawing.Color.Black
        Me.TxtOrigen.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen.Border.TopColor = System.Drawing.Color.Black
        Me.TxtOrigen.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen.Height = 0.1875!
        Me.TxtOrigen.Left = 0.5625!
        Me.TxtOrigen.Name = "TxtOrigen"
        Me.TxtOrigen.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtOrigen.Top = 0.9375!
        Me.TxtOrigen.Width = 1.9375!
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
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label2.Text = "Destino:"
        Me.Label2.Top = 1.125!
        Me.Label2.Width = 0.5!
        '
        'TxtDestino
        '
        Me.TxtDestino.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtDestino.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtDestino.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino.Border.RightColor = System.Drawing.Color.Black
        Me.TxtDestino.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino.Border.TopColor = System.Drawing.Color.Black
        Me.TxtDestino.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino.Height = 0.1875!
        Me.TxtDestino.Left = 0.5625!
        Me.TxtDestino.Name = "TxtDestino"
        Me.TxtDestino.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtDestino.Top = 1.125!
        Me.TxtDestino.Width = 1.9375!
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
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.25!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 8.25pt; "
        Me.TextBox1.Text = "Empresa Transporte"
        Me.TextBox1.Top = 1.4375!
        Me.TextBox1.Width = 2.1875!
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
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.Label3.Text = "Empresa:"
        Me.Label3.Top = 1.6875!
        Me.Label3.Width = 0.625!
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
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.Label4.Text = "Placa:"
        Me.Label4.Top = 1.875!
        Me.Label4.Width = 0.625!
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
        Me.Label5.Left = 0.0!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.Label5.Text = "Conductor:"
        Me.Label5.Top = 2.0625!
        Me.Label5.Width = 0.625!
        '
        'TxtEmpresa
        '
        Me.TxtEmpresa.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtEmpresa.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpresa.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtEmpresa.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpresa.Border.RightColor = System.Drawing.Color.Black
        Me.TxtEmpresa.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpresa.Border.TopColor = System.Drawing.Color.Black
        Me.TxtEmpresa.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpresa.Height = 0.1875!
        Me.TxtEmpresa.Left = 0.625!
        Me.TxtEmpresa.Name = "TxtEmpresa"
        Me.TxtEmpresa.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtEmpresa.Top = 1.6875!
        Me.TxtEmpresa.Width = 1.9375!
        '
        'TxtPlaca
        '
        Me.TxtPlaca.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPlaca.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPlaca.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPlaca.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPlaca.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca.Height = 0.1875!
        Me.TxtPlaca.Left = 0.625!
        Me.TxtPlaca.Name = "TxtPlaca"
        Me.TxtPlaca.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtPlaca.Top = 1.875!
        Me.TxtPlaca.Width = 1.9375!
        '
        'TxtConductor
        '
        Me.TxtConductor.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtConductor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtConductor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor.Border.RightColor = System.Drawing.Color.Black
        Me.TxtConductor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor.Border.TopColor = System.Drawing.Color.Black
        Me.TxtConductor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor.Height = 0.1875!
        Me.TxtConductor.Left = 0.625!
        Me.TxtConductor.Name = "TxtConductor"
        Me.TxtConductor.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtConductor.Top = 2.0625!
        Me.TxtConductor.Width = 1.9375!
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
        Me.Label6.Height = 0.1979167!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label6.Text = "Fecha Entrada:"
        Me.Label6.Top = 0.25!
        Me.Label6.Visible = False
        Me.Label6.Width = 1.0!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Height = 0.1979167!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.0!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label7.Text = "Fecha Carga:"
        Me.Label7.Top = 0.4375!
        Me.Label7.Width = 1.0!
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
        Me.Label8.Height = 0.1979167!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.0!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.Label8.Text = "Fecha Salida"
        Me.Label8.Top = 0.625!
        Me.Label8.Width = 1.0!
        '
        'TxtFechaEntrada
        '
        Me.TxtFechaEntrada.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaEntrada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaEntrada.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaEntrada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaEntrada.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaEntrada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaEntrada.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaEntrada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaEntrada.Height = 0.1875!
        Me.TxtFechaEntrada.Left = 1.0!
        Me.TxtFechaEntrada.Name = "TxtFechaEntrada"
        Me.TxtFechaEntrada.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtFechaEntrada.Top = 0.25!
        Me.TxtFechaEntrada.Visible = False
        Me.TxtFechaEntrada.Width = 1.5!
        '
        'TxtFechaCarga
        '
        Me.TxtFechaCarga.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaCarga.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaCarga.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaCarga.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaCarga.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga.Height = 0.1875!
        Me.TxtFechaCarga.Left = 1.0!
        Me.TxtFechaCarga.Name = "TxtFechaCarga"
        Me.TxtFechaCarga.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtFechaCarga.Top = 0.4375!
        Me.TxtFechaCarga.Width = 1.5!
        '
        'TxtFechaSalida
        '
        Me.TxtFechaSalida.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaSalida.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaSalida.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaSalida.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaSalida.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida.Height = 0.1875!
        Me.TxtFechaSalida.Left = 1.0!
        Me.TxtFechaSalida.Name = "TxtFechaSalida"
        Me.TxtFechaSalida.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtFechaSalida.Top = 0.625!
        Me.TxtFechaSalida.Width = 1.5!
        '
        'SrpPuntosIntermedios
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB;Integrated Security=SSPI;Persist Security Info=False;Initial Ca" & _
            "talog=TRANSPORTE1;Data Source=WIN-M13RQ730J8P\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.729167!
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
        CType(Me.TxtReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaCarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents TxtReferencia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtTitulo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReportIntermedioOrigen As DataDynamics.ActiveReports.SubReport
    Friend WithEvents TextBox27 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox28 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox30 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox31 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReportIntermedioEntrada As DataDynamics.ActiveReports.SubReport
    Friend WithEvents TextBox29 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox32 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox33 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox34 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReportIntermedioSalida As DataDynamics.ActiveReports.SubReport
    Friend WithEvents TextBox35 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox36 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox37 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtOrigen As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtDestino As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtEmpresa As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPlaca As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtConductor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtFechaEntrada As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaCarga As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaSalida As DataDynamics.ActiveReports.TextBox
End Class 
