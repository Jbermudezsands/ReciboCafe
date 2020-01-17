<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepRemisionTicket 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepRemisionTicket))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblEncabezado = New DataDynamics.ActiveReports.Label
        Me.LblTipoRemision = New DataDynamics.ActiveReports.Label
        Me.LblCosecha = New DataDynamics.ActiveReports.Label
        Me.LblLocalidad = New DataDynamics.ActiveReports.Label
        Me.LblOriginal = New DataDynamics.ActiveReports.Label
        Me.lblOrderNum = New DataDynamics.ActiveReports.Label
        Me.lblOrderDate = New DataDynamics.ActiveReports.Label
        Me.LblOrden = New DataDynamics.ActiveReports.Label
        Me.LblFechaOrden = New DataDynamics.ActiveReports.Label
        Me.LblFechaSalida = New DataDynamics.ActiveReports.Label
        Me.Label38 = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.LblEmpresaTransporte = New DataDynamics.ActiveReports.Label
        Me.LblPlaca = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.LblMarca = New DataDynamics.ActiveReports.Label
        Me.LblConductor = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.LblCedula = New DataDynamics.ActiveReports.Label
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.TxtTotalRecibos = New DataDynamics.ActiveReports.TextBox
        Me.SubReportDetalleRemision = New DataDynamics.ActiveReports.SubReport
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox
        Me.SubReportIntermedio = New DataDynamics.ActiveReports.SubReport
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEmpresaTransporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblEncabezado, Me.LblTipoRemision, Me.LblCosecha, Me.LblLocalidad, Me.LblOriginal, Me.lblOrderNum, Me.lblOrderDate, Me.LblOrden, Me.LblFechaOrden, Me.LblFechaSalida, Me.Label38, Me.TextBox1, Me.TextBox2, Me.Label1, Me.LblEmpresaTransporte, Me.LblPlaca, Me.Label4, Me.Label5, Me.LblMarca, Me.LblConductor, Me.Label9, Me.Label10, Me.LblCedula, Me.TextBox3, Me.TextBox4, Me.TextBox5})
        Me.PageHeader1.Height = 4.90625!
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
        Me.ImgLogo.Height = 0.75!
        Me.ImgLogo.Image = Nothing
        Me.ImgLogo.ImageData = Nothing
        Me.ImgLogo.Left = 0.625!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.0!
        Me.ImgLogo.Width = 1.3125!
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
        Me.LblEncabezado.Height = 0.4375!
        Me.LblEncabezado.HyperLink = Nothing
        Me.LblEncabezado.Left = 0.0!
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 12pt; "
        Me.LblEncabezado.Text = ""
        Me.LblEncabezado.Top = 0.8125!
        Me.LblEncabezado.Width = 2.5625!
        '
        'LblTipoRemision
        '
        Me.LblTipoRemision.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTipoRemision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoRemision.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTipoRemision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoRemision.Border.RightColor = System.Drawing.Color.Black
        Me.LblTipoRemision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoRemision.Border.TopColor = System.Drawing.Color.Black
        Me.LblTipoRemision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTipoRemision.Height = 0.25!
        Me.LblTipoRemision.HyperLink = Nothing
        Me.LblTipoRemision.Left = 0.0!
        Me.LblTipoRemision.Name = "LblTipoRemision"
        Me.LblTipoRemision.Style = "color: #404040; ddo-char-set: 0; text-align: center; font-weight: bold; backgroun" & _
            "d-color: White; font-size: 9pt; "
        Me.LblTipoRemision.Text = "Remision Pergamino"
        Me.LblTipoRemision.Top = 1.375!
        Me.LblTipoRemision.Width = 2.5625!
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
        Me.LblCosecha.Height = 0.1875!
        Me.LblCosecha.HyperLink = Nothing
        Me.LblCosecha.Left = 0.0!
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Style = "text-align: center; "
        Me.LblCosecha.Text = ""
        Me.LblCosecha.Top = 1.625!
        Me.LblCosecha.Width = 2.5625!
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
        Me.LblLocalidad.Height = 0.1875!
        Me.LblLocalidad.HyperLink = Nothing
        Me.LblLocalidad.Left = 0.0!
        Me.LblLocalidad.Name = "LblLocalidad"
        Me.LblLocalidad.Style = "text-align: center; "
        Me.LblLocalidad.Text = ""
        Me.LblLocalidad.Top = 1.8125!
        Me.LblLocalidad.Width = 2.5625!
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
        Me.LblOriginal.Height = 0.25!
        Me.LblOriginal.HyperLink = Nothing
        Me.LblOriginal.Left = 0.0!
        Me.LblOriginal.Name = "LblOriginal"
        Me.LblOriginal.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; "
        Me.LblOriginal.Text = ""
        Me.LblOriginal.Top = 2.0!
        Me.LblOriginal.Width = 2.5625!
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
        Me.lblOrderNum.Height = 0.2!
        Me.lblOrderNum.HyperLink = Nothing
        Me.lblOrderNum.Left = 0.0!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.lblOrderNum.Text = "Remision No:"
        Me.lblOrderNum.Top = 3.04!
        Me.lblOrderNum.Width = 0.84!
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
        Me.lblOrderDate.Height = 0.2000001!
        Me.lblOrderDate.HyperLink = Nothing
        Me.lblOrderDate.Left = 0.04!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.lblOrderDate.Text = "Fecha  Carga;"
        Me.lblOrderDate.Top = 2.64!
        Me.lblOrderDate.Width = 0.8!
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
        Me.LblOrden.Left = 0.92!
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Style = ""
        Me.LblOrden.Text = ""
        Me.LblOrden.Top = 3.04!
        Me.LblOrden.Width = 1.72!
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
        Me.LblFechaOrden.Height = 0.1600001!
        Me.LblFechaOrden.HyperLink = Nothing
        Me.LblFechaOrden.Left = 0.92!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.Style = ""
        Me.LblFechaOrden.Text = ""
        Me.LblFechaOrden.Top = 2.64!
        Me.LblFechaOrden.Width = 1.72!
        '
        'LblFechaSalida
        '
        Me.LblFechaSalida.Border.BottomColor = System.Drawing.Color.Black
        Me.LblFechaSalida.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaSalida.Border.LeftColor = System.Drawing.Color.Black
        Me.LblFechaSalida.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaSalida.Border.RightColor = System.Drawing.Color.Black
        Me.LblFechaSalida.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaSalida.Border.TopColor = System.Drawing.Color.Black
        Me.LblFechaSalida.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblFechaSalida.Height = 0.2000001!
        Me.LblFechaSalida.HyperLink = Nothing
        Me.LblFechaSalida.Left = 0.92!
        Me.LblFechaSalida.Name = "LblFechaSalida"
        Me.LblFechaSalida.Style = ""
        Me.LblFechaSalida.Text = ""
        Me.LblFechaSalida.Top = 2.84!
        Me.LblFechaSalida.Width = 1.72!
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
        Me.Label38.Height = 0.2000001!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.08!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label38.Text = "Fecha Salida"
        Me.Label38.Top = 2.84!
        Me.Label38.Width = 0.76!
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
        Me.TextBox1.Left = 0.04!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox1.Text = "D a t o s   G e n e r a l e s "
        Me.TextBox1.Top = 2.4!
        Me.TextBox1.Width = 2.625!
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
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 0.04!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox2.Text = "T r a n s p o r t i s t a"
        Me.TextBox2.Top = 3.36!
        Me.TextBox2.Width = 2.625!
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
        Me.Label1.Height = 0.2000002!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.12!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label1.Text = "Empresa:"
        Me.Label1.Top = 3.6!
        Me.Label1.Width = 0.72!
        '
        'LblEmpresaTransporte
        '
        Me.LblEmpresaTransporte.Border.BottomColor = System.Drawing.Color.Black
        Me.LblEmpresaTransporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEmpresaTransporte.Border.LeftColor = System.Drawing.Color.Black
        Me.LblEmpresaTransporte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEmpresaTransporte.Border.RightColor = System.Drawing.Color.Black
        Me.LblEmpresaTransporte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEmpresaTransporte.Border.TopColor = System.Drawing.Color.Black
        Me.LblEmpresaTransporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblEmpresaTransporte.Height = 0.1599998!
        Me.LblEmpresaTransporte.HyperLink = Nothing
        Me.LblEmpresaTransporte.Left = 0.96!
        Me.LblEmpresaTransporte.Name = "LblEmpresaTransporte"
        Me.LblEmpresaTransporte.Style = ""
        Me.LblEmpresaTransporte.Text = ""
        Me.LblEmpresaTransporte.Top = 3.6!
        Me.LblEmpresaTransporte.Width = 1.56!
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
        Me.LblPlaca.Height = 0.2!
        Me.LblPlaca.HyperLink = Nothing
        Me.LblPlaca.Left = 0.96!
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Style = ""
        Me.LblPlaca.Text = ""
        Me.LblPlaca.Top = 3.76!
        Me.LblPlaca.Width = 1.56!
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
        Me.Label4.Height = 0.16!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.12!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label4.Text = "Placa:"
        Me.Label4.Top = 3.8!
        Me.Label4.Width = 0.72!
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
        Me.Label5.Height = 0.2000002!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.12!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label5.Text = "Marca:"
        Me.Label5.Top = 3.96!
        Me.Label5.Width = 0.72!
        '
        'LblMarca
        '
        Me.LblMarca.Border.BottomColor = System.Drawing.Color.Black
        Me.LblMarca.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMarca.Border.LeftColor = System.Drawing.Color.Black
        Me.LblMarca.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMarca.Border.RightColor = System.Drawing.Color.Black
        Me.LblMarca.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMarca.Border.TopColor = System.Drawing.Color.Black
        Me.LblMarca.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblMarca.Height = 0.1599999!
        Me.LblMarca.HyperLink = Nothing
        Me.LblMarca.Left = 0.96!
        Me.LblMarca.Name = "LblMarca"
        Me.LblMarca.Style = ""
        Me.LblMarca.Text = ""
        Me.LblMarca.Top = 3.96!
        Me.LblMarca.Width = 1.56!
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
        Me.LblConductor.Height = 0.2!
        Me.LblConductor.HyperLink = Nothing
        Me.LblConductor.Left = 0.96!
        Me.LblConductor.Name = "LblConductor"
        Me.LblConductor.Style = ""
        Me.LblConductor.Text = ""
        Me.LblConductor.Top = 4.12!
        Me.LblConductor.Width = 1.56!
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
        Me.Label9.Height = 0.16!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.12!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label9.Text = "Conductor"
        Me.Label9.Top = 4.16!
        Me.Label9.Width = 0.72!
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
        Me.Label10.Height = 0.1999999!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.12!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; "
        Me.Label10.Text = "Cedula:"
        Me.Label10.Top = 4.36!
        Me.Label10.Width = 0.72!
        '
        'LblCedula
        '
        Me.LblCedula.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCedula.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedula.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCedula.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedula.Border.RightColor = System.Drawing.Color.Black
        Me.LblCedula.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedula.Border.TopColor = System.Drawing.Color.Black
        Me.LblCedula.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblCedula.Height = 0.1999999!
        Me.LblCedula.HyperLink = Nothing
        Me.LblCedula.Left = 0.96!
        Me.LblCedula.Name = "LblCedula"
        Me.LblCedula.Style = ""
        Me.LblCedula.Text = ""
        Me.LblCedula.Top = 4.36!
        Me.LblCedula.Width = 1.56!
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
        Me.TextBox3.Height = 0.1999999!
        Me.TextBox3.Left = 0.0!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox3.Text = "NoRec"
        Me.TextBox3.Top = 4.68!
        Me.TextBox3.Width = 0.68!
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
        Me.TextBox4.Height = 0.1999999!
        Me.TextBox4.Left = 0.68!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox4.Text = "Proveedor"
        Me.TextBox4.Top = 4.68!
        Me.TextBox4.Width = 1.24!
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
        Me.TextBox5.Height = 0.1999999!
        Me.TextBox5.Left = 1.92!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox5.Text = "Aplicado"
        Me.TextBox5.Top = 4.68!
        Me.TextBox5.Width = 0.68!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox14, Me.TextBox16, Me.TextBox17})
        Me.Detail1.Height = 0.25!
        Me.Detail1.Name = "Detail1"
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
        Me.TextBox14.DataField = "Codigo"
        Me.TextBox14.Height = 0.2!
        Me.TextBox14.Left = 0.0!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = 0.0!
        Me.TextBox14.Width = 0.68!
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
        Me.TextBox16.DataField = "Proveedor"
        Me.TextBox16.Height = 0.2!
        Me.TextBox16.Left = 0.68!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox16.Text = Nothing
        Me.TextBox16.Top = 0.0!
        Me.TextBox16.Width = 1.24!
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
        Me.TextBox17.DataField = "PesoAplicado"
        Me.TextBox17.Height = 0.2!
        Me.TextBox17.Left = 1.92!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat")
        Me.TextBox17.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TextBox17.Text = Nothing
        Me.TextBox17.Top = 0.0!
        Me.TextBox17.Width = 0.68!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
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
        Me.TextBox6.Height = 0.2!
        Me.TextBox6.Left = 2.04!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox6.Text = "P.Neto"
        Me.TextBox6.Top = 0.6!
        Me.TextBox6.Width = 0.6800001!
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
        Me.TextBox8.Height = 0.1999999!
        Me.TextBox8.Left = 0.08!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox8.Text = "Daño"
        Me.TextBox8.Top = 0.6!
        Me.TextBox8.Width = 0.68!
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
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 0.76!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox7.Text = "QQ"
        Me.TextBox7.Top = 0.6!
        Me.TextBox7.Width = 0.68!
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
        Me.TextBox9.Height = 0.2!
        Me.TextBox9.Left = 1.44!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox9.Text = "Tara"
        Me.TextBox9.Top = 0.6!
        Me.TextBox9.Width = 0.6!
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
        Me.TextBox10.Height = 0.1875!
        Me.TextBox10.Left = 0.08!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox10.Text = "Detalle Remision"
        Me.TextBox10.Top = 0.4!
        Me.TextBox10.Width = 2.625!
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
        Me.TextBox15.Height = 0.1875!
        Me.TextBox15.Left = 0.08!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox15.Text = "Puntos Intermedios"
        Me.TextBox15.Top = 1.08!
        Me.TextBox15.Width = 2.625!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.DataField = "IdRemisionPergamino"
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.TxtTotalRecibos, Me.TextBox10, Me.TextBox8, Me.TextBox7, Me.TextBox9, Me.TextBox6, Me.TextBox15, Me.SubReportDetalleRemision, Me.TextBox11, Me.TextBox12, Me.TextBox13, Me.TextBox18, Me.SubReportIntermedio})
        Me.GroupFooter1.Height = 1.84!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.56!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.Label2.Text = "Total Recibos     "
        Me.Label2.Top = 0.04!
        Me.Label2.Width = 1.16!
        '
        'TxtTotalRecibos
        '
        Me.TxtTotalRecibos.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtTotalRecibos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalRecibos.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtTotalRecibos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalRecibos.Border.RightColor = System.Drawing.Color.Black
        Me.TxtTotalRecibos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalRecibos.Border.TopColor = System.Drawing.Color.Black
        Me.TxtTotalRecibos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtTotalRecibos.DataField = "PesoAplicado"
        Me.TxtTotalRecibos.Height = 0.2!
        Me.TxtTotalRecibos.Left = 1.92!
        Me.TxtTotalRecibos.Name = "TxtTotalRecibos"
        Me.TxtTotalRecibos.OutputFormat = resources.GetString("TxtTotalRecibos.OutputFormat")
        Me.TxtTotalRecibos.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; "
        Me.TxtTotalRecibos.SummaryGroup = "GroupHeader1"
        Me.TxtTotalRecibos.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TxtTotalRecibos.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtTotalRecibos.Text = Nothing
        Me.TxtTotalRecibos.Top = 0.04!
        Me.TxtTotalRecibos.Width = 0.68!
        '
        'SubReportDetalleRemision
        '
        Me.SubReportDetalleRemision.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportDetalleRemision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDetalleRemision.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportDetalleRemision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDetalleRemision.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportDetalleRemision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDetalleRemision.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportDetalleRemision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportDetalleRemision.CloseBorder = False
        Me.SubReportDetalleRemision.Height = 0.24!
        Me.SubReportDetalleRemision.Left = 0.08!
        Me.SubReportDetalleRemision.Name = "SubReportDetalleRemision"
        Me.SubReportDetalleRemision.Report = Nothing
        Me.SubReportDetalleRemision.ReportName = "SubReport1"
        Me.SubReportDetalleRemision.Top = 0.8!
        Me.SubReportDetalleRemision.Width = 2.6!
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
        Me.TextBox11.Height = 0.1999999!
        Me.TextBox11.Left = 0.08!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox11.Text = "Ini QQ"
        Me.TextBox11.Top = 1.28!
        Me.TextBox11.Width = 0.68!
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
        Me.TextBox12.Height = 0.2!
        Me.TextBox12.Left = 0.76!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox12.Text = "Fin PB"
        Me.TextBox12.Top = 1.28!
        Me.TextBox12.Width = 0.68!
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
        Me.TextBox13.Height = 0.2!
        Me.TextBox13.Left = 1.44!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox13.Text = "Fin QQ"
        Me.TextBox13.Top = 1.28!
        Me.TextBox13.Width = 0.6!
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
        Me.TextBox18.Height = 0.2!
        Me.TextBox18.Left = 2.04!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Style = "color: White; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: Black; font-size: 9.75pt; "
        Me.TextBox18.Text = "Fin PB"
        Me.TextBox18.Top = 1.28!
        Me.TextBox18.Width = 0.6800001!
        '
        'SubReportIntermedio
        '
        Me.SubReportIntermedio.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReportIntermedio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedio.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReportIntermedio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedio.Border.RightColor = System.Drawing.Color.Black
        Me.SubReportIntermedio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedio.Border.TopColor = System.Drawing.Color.Black
        Me.SubReportIntermedio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReportIntermedio.CloseBorder = False
        Me.SubReportIntermedio.Height = 0.24!
        Me.SubReportIntermedio.Left = 0.08!
        Me.SubReportIntermedio.Name = "SubReportIntermedio"
        Me.SubReportIntermedio.Report = Nothing
        Me.SubReportIntermedio.ReportName = "SubReport1"
        Me.SubReportIntermedio.Top = 1.52!
        Me.SubReportIntermedio.Width = 2.6!
        '
        'ArepRemisionTicket
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=TRANSPORTE_AGRANCHOGRANDE;Data Source=JUANBERMUDEZ\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.Margins.Bottom = 0.1!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.1!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.875!
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
        CType(Me.LblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoRemision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEmpresaTransporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoRemision As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCosecha As DataDynamics.ActiveReports.Label
    Friend WithEvents LblLocalidad As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOriginal As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.Label
    Friend WithEvents LblFechaSalida As DataDynamics.ActiveReports.Label
    Private WithEvents Label38 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblEmpresaTransporte As DataDynamics.ActiveReports.Label
    Friend WithEvents LblPlaca As DataDynamics.ActiveReports.Label
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Private WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblMarca As DataDynamics.ActiveReports.Label
    Friend WithEvents LblConductor As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCedula As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox15 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox16 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox17 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Private WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtTotalRecibos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReportDetalleRemision As DataDynamics.ActiveReports.SubReport
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox18 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReportIntermedio As DataDynamics.ActiveReports.SubReport
End Class
