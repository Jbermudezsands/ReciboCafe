<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ArepRemisionPergamino 
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArepRemisionPergamino))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtNumeroRecibos = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantSacos1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoBruto1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoNeto1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantSacos2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoBruto2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoNeto2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantSacos3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoBruto3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtPesoNeto3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantSacos33 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantSacos22 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCantSacos11 = New DataDynamics.ActiveReports.TextBox
        Me.TxtListadoRecibos = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Label65 = New DataDynamics.ActiveReports.Label
        Me.TxtObservaciones = New DataDynamics.ActiveReports.TextBox
        Me.Label66 = New DataDynamics.ActiveReports.Label
        Me.Label67 = New DataDynamics.ActiveReports.Label
        Me.Label68 = New DataDynamics.ActiveReports.Label
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ImgLogo = New DataDynamics.ActiveReports.Picture
        Me.LblCompañia = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.LblTipoRemision = New DataDynamics.ActiveReports.Label
        Me.LblCosecha = New DataDynamics.ActiveReports.Label
        Me.LblNumeroRemision = New DataDynamics.ActiveReports.Label
        Me.lblOrderDate = New DataDynamics.ActiveReports.Label
        Me.lblOrderNum = New DataDynamics.ActiveReports.Label
        Me.Label36 = New DataDynamics.ActiveReports.Label
        Me.LblDescripcion = New DataDynamics.ActiveReports.Label
        Me.Label38 = New DataDynamics.ActiveReports.Label
        Me.Label39 = New DataDynamics.ActiveReports.Label
        Me.Label42 = New DataDynamics.ActiveReports.Label
        Me.Label43 = New DataDynamics.ActiveReports.Label
        Me.Label44 = New DataDynamics.ActiveReports.Label
        Me.Label46 = New DataDynamics.ActiveReports.Label
        Me.Label47 = New DataDynamics.ActiveReports.Label
        Me.Label49 = New DataDynamics.ActiveReports.Label
        Me.Label48 = New DataDynamics.ActiveReports.Label
        Me.Label45 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.LblEmpresaTransporte = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.LblConductor = New DataDynamics.ActiveReports.TextBox
        Me.LblCedula = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.LblFechaOrden = New DataDynamics.ActiveReports.TextBox
        Me.LblFechaSalida = New DataDynamics.ActiveReports.TextBox
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.LblOrigen = New DataDynamics.ActiveReports.TextBox
        Me.LblDestino = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.LblCantSaco1 = New DataDynamics.ActiveReports.Label
        Me.LblPBRecepcion1 = New DataDynamics.ActiveReports.Label
        Me.LblP1 = New DataDynamics.ActiveReports.Label
        Me.LblPBRemision1 = New DataDynamics.ActiveReports.Label
        Me.LblCantSaco11 = New DataDynamics.ActiveReports.Label
        Me.LblCantSaco2 = New DataDynamics.ActiveReports.Label
        Me.LblPBRecepcion2 = New DataDynamics.ActiveReports.Label
        Me.LblP2 = New DataDynamics.ActiveReports.Label
        Me.LblPBRemision2 = New DataDynamics.ActiveReports.Label
        Me.LblCantSaco22 = New DataDynamics.ActiveReports.Label
        Me.LblCantSaco3 = New DataDynamics.ActiveReports.Label
        Me.LblPBRecepcion3 = New DataDynamics.ActiveReports.Label
        Me.LblP3 = New DataDynamics.ActiveReports.Label
        Me.LblPBRemision3 = New DataDynamics.ActiveReports.Label
        Me.LblCantSaco33 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.TxtEmpTransp1 = New DataDynamics.ActiveReports.TextBox
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.TxtPlaca1 = New DataDynamics.ActiveReports.TextBox
        Me.Label17 = New DataDynamics.ActiveReports.Label
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.Label19 = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.TxtConductor1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtMarca1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCedConductor1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaRecp1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaCarga1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaSalida1 = New DataDynamics.ActiveReports.TextBox
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.TxtOrigen1 = New DataDynamics.ActiveReports.TextBox
        Me.TxtDestino1 = New DataDynamics.ActiveReports.TextBox
        Me.Label25 = New DataDynamics.ActiveReports.Label
        Me.Label26 = New DataDynamics.ActiveReports.Label
        Me.TxtEmpTransp2 = New DataDynamics.ActiveReports.TextBox
        Me.Label27 = New DataDynamics.ActiveReports.Label
        Me.TxtPlaca2 = New DataDynamics.ActiveReports.TextBox
        Me.Label28 = New DataDynamics.ActiveReports.Label
        Me.Label29 = New DataDynamics.ActiveReports.Label
        Me.Label30 = New DataDynamics.ActiveReports.Label
        Me.Label31 = New DataDynamics.ActiveReports.Label
        Me.Label32 = New DataDynamics.ActiveReports.Label
        Me.Label33 = New DataDynamics.ActiveReports.Label
        Me.TxtConductor2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtMarca2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCedConductor2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaCarga2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaSalida2 = New DataDynamics.ActiveReports.TextBox
        Me.Label34 = New DataDynamics.ActiveReports.Label
        Me.Label35 = New DataDynamics.ActiveReports.Label
        Me.TxtOrigen2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtDestino2 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaRecp2 = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label37 = New DataDynamics.ActiveReports.Label
        Me.TxtEmpTransp3 = New DataDynamics.ActiveReports.TextBox
        Me.Label63 = New DataDynamics.ActiveReports.Label
        Me.TxtPlaca3 = New DataDynamics.ActiveReports.TextBox
        Me.Label64 = New DataDynamics.ActiveReports.Label
        Me.Label69 = New DataDynamics.ActiveReports.Label
        Me.Label70 = New DataDynamics.ActiveReports.Label
        Me.Label71 = New DataDynamics.ActiveReports.Label
        Me.Label72 = New DataDynamics.ActiveReports.Label
        Me.Label73 = New DataDynamics.ActiveReports.Label
        Me.TxtConductor3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtMarca3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtCedConductor3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaRecp3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaCarga3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtFechaSalida3 = New DataDynamics.ActiveReports.TextBox
        Me.Label74 = New DataDynamics.ActiveReports.Label
        Me.Label75 = New DataDynamics.ActiveReports.Label
        Me.TxtOrigen3 = New DataDynamics.ActiveReports.TextBox
        Me.TxtDestino3 = New DataDynamics.ActiveReports.TextBox
        Me.Label40 = New DataDynamics.ActiveReports.Label
        Me.TxtOrigenRemision = New DataDynamics.ActiveReports.TextBox
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumeroRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantSacos1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoBruto1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoNeto1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantSacos2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoBruto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoNeto2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantSacos3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoBruto3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesoNeto3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantSacos33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantSacos22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCantSacos11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtListadoRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label65, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label67, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label68, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCompañia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTipoRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblNumeroRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEmpresaTransporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCantSaco1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPBRecepcion1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPBRemision1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCantSaco11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCantSaco2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPBRecepcion2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPBRemision2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCantSaco22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCantSaco3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPBRecepcion3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblP3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblPBRemision3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCantSaco33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmpTransp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPlaca1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtConductor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMarca1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCedConductor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaRecp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaCarga1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaSalida1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrigen1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDestino1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmpTransp2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPlaca2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtConductor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMarca2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCedConductor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaCarga2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaSalida2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrigen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDestino2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaRecp2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmpTransp3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPlaca3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label64, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label69, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label71, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label72, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label73, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtConductor3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMarca3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCedConductor3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaRecp3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaCarga3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFechaSalida3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label74, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label75, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrigen3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDestino3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrigenRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.01041667!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TxtNumeroRecibos, Me.TextBox3, Me.TextBox4, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.TextBox10, Me.TxtCantSacos1, Me.TxtPesoBruto1, Me.TxtPesoNeto1, Me.TxtCantSacos2, Me.TxtPesoBruto2, Me.TxtPesoNeto2, Me.TxtCantSacos3, Me.TxtPesoBruto3, Me.TxtPesoNeto3, Me.TxtCantSacos33, Me.TxtCantSacos22, Me.TxtCantSacos11, Me.TxtListadoRecibos})
        Me.Detail1.Height = 0.25!
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
        Me.TextBox1.DataField = "Cont"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 0.2222222!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Microsoft Sans Serif; "
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.26!
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
        Me.TxtNumeroRecibos.DataField = "Codigo"
        Me.TxtNumeroRecibos.Height = 0.2!
        Me.TxtNumeroRecibos.Left = 0.28!
        Me.TxtNumeroRecibos.Name = "TxtNumeroRecibos"
        Me.TxtNumeroRecibos.Style = "ddo-char-set: 0; font-size: 6.75pt; font-family: Microsoft Sans Serif; "
        Me.TxtNumeroRecibos.Text = Nothing
        Me.TxtNumeroRecibos.Top = 0.52!
        Me.TxtNumeroRecibos.Visible = False
        Me.TxtNumeroRecibos.Width = 1.44!
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
        Me.TextBox3.Height = 0.2222222!
        Me.TextBox3.Left = 1.888889!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Microsoft Sans " & _
            "Serif; "
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.5555556!
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
        Me.TextBox4.DataField = "Dano"
        Me.TextBox4.Height = 0.2222222!
        Me.TextBox4.Left = 2.47!
        Me.TextBox4.MultiLine = False
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Microsoft Sans Serif; "
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.9444444!
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
        Me.TextBox6.Height = 0.2222222!
        Me.TextBox6.Left = 3.44!
        Me.TextBox6.MultiLine = False
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Microsoft Sans Serif; "
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 1.055556!
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
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 4.444445!
        Me.TextBox7.MultiLine = False
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
        Me.TextBox7.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Microsoft Sans " & _
            "Serif; "
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.41!
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
        Me.TextBox8.DataField = "PesoBruto"
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 4.85!
        Me.TextBox8.MultiLine = False
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Microsoft Sans S" & _
            "erif; "
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.64!
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
        Me.TextBox9.Height = 0.2!
        Me.TextBox9.Left = 5.5!
        Me.TextBox9.MultiLine = False
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Microsoft Sans S" & _
            "erif; "
        Me.TextBox9.Text = Nothing
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 0.41!
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
        Me.TextBox10.Left = 5.92!
        Me.TextBox10.MultiLine = False
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Microsoft Sans S" & _
            "erif; "
        Me.TextBox10.Text = Nothing
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.64!
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
        Me.TxtCantSacos1.DataField = "CantidadSacos"
        Me.TxtCantSacos1.Height = 0.2!
        Me.TxtCantSacos1.Left = 6.56!
        Me.TxtCantSacos1.MultiLine = False
        Me.TxtCantSacos1.Name = "TxtCantSacos1"
        Me.TxtCantSacos1.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Microsoft Sans " & _
            "Serif; "
        Me.TxtCantSacos1.Text = Nothing
        Me.TxtCantSacos1.Top = 0.0!
        Me.TxtCantSacos1.Width = 0.41!
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
        Me.TxtPesoBruto1.DataField = "PesoBruto"
        Me.TxtPesoBruto1.Height = 0.2!
        Me.TxtPesoBruto1.Left = 6.98!
        Me.TxtPesoBruto1.MultiLine = False
        Me.TxtPesoBruto1.Name = "TxtPesoBruto1"
        Me.TxtPesoBruto1.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Microsoft Sans S" & _
            "erif; "
        Me.TxtPesoBruto1.Text = Nothing
        Me.TxtPesoBruto1.Top = 0.0!
        Me.TxtPesoBruto1.Width = 0.64!
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
        Me.TxtPesoNeto1.DataField = "PesoNeto"
        Me.TxtPesoNeto1.Height = 0.2!
        Me.TxtPesoNeto1.Left = 8.02!
        Me.TxtPesoNeto1.MultiLine = False
        Me.TxtPesoNeto1.Name = "TxtPesoNeto1"
        Me.TxtPesoNeto1.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Microsoft Sans S" & _
            "erif; "
        Me.TxtPesoNeto1.Text = Nothing
        Me.TxtPesoNeto1.Top = 0.0!
        Me.TxtPesoNeto1.Width = 0.64!
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
        Me.TxtCantSacos2.DataField = "CantidadSacos"
        Me.TxtCantSacos2.Height = 0.2!
        Me.TxtCantSacos2.Left = 8.67!
        Me.TxtCantSacos2.MultiLine = False
        Me.TxtCantSacos2.Name = "TxtCantSacos2"
        Me.TxtCantSacos2.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Microsoft Sans " & _
            "Serif; "
        Me.TxtCantSacos2.Text = Nothing
        Me.TxtCantSacos2.Top = 0.0!
        Me.TxtCantSacos2.Width = 0.39!
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
        Me.TxtPesoBruto2.Height = 0.2!
        Me.TxtPesoBruto2.Left = 9.06!
        Me.TxtPesoBruto2.MultiLine = False
        Me.TxtPesoBruto2.Name = "TxtPesoBruto2"
        Me.TxtPesoBruto2.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Microsoft Sans S" & _
            "erif; "
        Me.TxtPesoBruto2.Text = Nothing
        Me.TxtPesoBruto2.Top = 0.0!
        Me.TxtPesoBruto2.Width = 0.64!
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
        Me.TxtPesoNeto2.DataField = "PesoNeto"
        Me.TxtPesoNeto2.Height = 0.2!
        Me.TxtPesoNeto2.Left = 10.13!
        Me.TxtPesoNeto2.MultiLine = False
        Me.TxtPesoNeto2.Name = "TxtPesoNeto2"
        Me.TxtPesoNeto2.Style = "ddo-char-set: 0; text-align: right; font-size: 9pt; font-family: Microsoft Sans S" & _
            "erif; "
        Me.TxtPesoNeto2.Text = Nothing
        Me.TxtPesoNeto2.Top = 0.0!
        Me.TxtPesoNeto2.Width = 0.64!
        '
        'TxtCantSacos3
        '
        Me.TxtCantSacos3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantSacos3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantSacos3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantSacos3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantSacos3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos3.Height = 0.2!
        Me.TxtCantSacos3.Left = 11.77778!
        Me.TxtCantSacos3.MultiLine = False
        Me.TxtCantSacos3.Name = "TxtCantSacos3"
        Me.TxtCantSacos3.Style = "ddo-char-set: 0; text-align: center; font-size: 6.75pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.TxtCantSacos3.Text = Nothing
        Me.TxtCantSacos3.Top = 0.0!
        Me.TxtCantSacos3.Width = 0.3199998!
        '
        'TxtPesoBruto3
        '
        Me.TxtPesoBruto3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoBruto3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoBruto3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoBruto3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoBruto3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoBruto3.Height = 0.2!
        Me.TxtPesoBruto3.Left = 12.11111!
        Me.TxtPesoBruto3.MultiLine = False
        Me.TxtPesoBruto3.Name = "TxtPesoBruto3"
        Me.TxtPesoBruto3.Style = "ddo-char-set: 0; text-align: right; font-size: 6.75pt; font-family: Microsoft San" & _
            "s Serif; "
        Me.TxtPesoBruto3.Text = Nothing
        Me.TxtPesoBruto3.Top = 0.0!
        Me.TxtPesoBruto3.Width = 0.6000001!
        '
        'TxtPesoNeto3
        '
        Me.TxtPesoNeto3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPesoNeto3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPesoNeto3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPesoNeto3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPesoNeto3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPesoNeto3.Height = 0.2!
        Me.TxtPesoNeto3.Left = 13.0!
        Me.TxtPesoNeto3.MultiLine = False
        Me.TxtPesoNeto3.Name = "TxtPesoNeto3"
        Me.TxtPesoNeto3.Style = "ddo-char-set: 0; text-align: right; font-size: 6.75pt; font-family: Microsoft San" & _
            "s Serif; "
        Me.TxtPesoNeto3.Text = Nothing
        Me.TxtPesoNeto3.Top = 0.0!
        Me.TxtPesoNeto3.Width = 0.56!
        '
        'TxtCantSacos33
        '
        Me.TxtCantSacos33.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantSacos33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos33.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantSacos33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos33.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantSacos33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos33.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantSacos33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos33.Height = 0.2!
        Me.TxtCantSacos33.Left = 12.72222!
        Me.TxtCantSacos33.MultiLine = False
        Me.TxtCantSacos33.Name = "TxtCantSacos33"
        Me.TxtCantSacos33.Style = "ddo-char-set: 0; text-align: center; font-size: 6.75pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.TxtCantSacos33.Text = Nothing
        Me.TxtCantSacos33.Top = 0.0!
        Me.TxtCantSacos33.Width = 0.28!
        '
        'TxtCantSacos22
        '
        Me.TxtCantSacos22.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantSacos22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos22.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantSacos22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos22.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantSacos22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos22.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantSacos22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos22.Height = 0.2!
        Me.TxtCantSacos22.Left = 9.7!
        Me.TxtCantSacos22.MultiLine = False
        Me.TxtCantSacos22.Name = "TxtCantSacos22"
        Me.TxtCantSacos22.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Microsoft Sans " & _
            "Serif; "
        Me.TxtCantSacos22.Text = Nothing
        Me.TxtCantSacos22.Top = 0.0!
        Me.TxtCantSacos22.Width = 0.41!
        '
        'TxtCantSacos11
        '
        Me.TxtCantSacos11.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCantSacos11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos11.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCantSacos11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos11.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCantSacos11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos11.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCantSacos11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCantSacos11.Height = 0.2!
        Me.TxtCantSacos11.Left = 7.61!
        Me.TxtCantSacos11.MultiLine = False
        Me.TxtCantSacos11.Name = "TxtCantSacos11"
        Me.TxtCantSacos11.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; font-family: Microsoft Sans " & _
            "Serif; "
        Me.TxtCantSacos11.Text = Nothing
        Me.TxtCantSacos11.Top = 0.0!
        Me.TxtCantSacos11.Width = 0.41!
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
        Me.TxtListadoRecibos.DataField = "Codigo"
        Me.TxtListadoRecibos.Height = 0.2222222!
        Me.TxtListadoRecibos.Left = 0.5!
        Me.TxtListadoRecibos.Name = "TxtListadoRecibos"
        Me.TxtListadoRecibos.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Microsoft Sans Serif; "
        Me.TxtListadoRecibos.Text = Nothing
        Me.TxtListadoRecibos.Top = 0.0!
        Me.TxtListadoRecibos.Width = 1.388889!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label65, Me.TxtObservaciones, Me.Label66, Me.Label67, Me.Label68})
        Me.PageFooter1.Height = 1.395833!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Label65
        '
        Me.Label65.Border.BottomColor = System.Drawing.Color.Black
        Me.Label65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label65.Border.LeftColor = System.Drawing.Color.Black
        Me.Label65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label65.Border.RightColor = System.Drawing.Color.Black
        Me.Label65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label65.Border.TopColor = System.Drawing.Color.Black
        Me.Label65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label65.Height = 0.16!
        Me.Label65.HyperLink = Nothing
        Me.Label65.Left = 0.0!
        Me.Label65.Name = "Label65"
        Me.Label65.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.Label65.Text = "OBSERVACIONES"
        Me.Label65.Top = 0.0!
        Me.Label65.Width = 10.88!
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
        Me.TxtObservaciones.Height = 0.36!
        Me.TxtObservaciones.Left = 0.04!
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtObservaciones.Text = Nothing
        Me.TxtObservaciones.Top = 0.2!
        Me.TxtObservaciones.Width = 10.76!
        '
        'Label66
        '
        Me.Label66.Border.BottomColor = System.Drawing.Color.Black
        Me.Label66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label66.Border.LeftColor = System.Drawing.Color.Black
        Me.Label66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label66.Border.RightColor = System.Drawing.Color.Black
        Me.Label66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label66.Border.TopColor = System.Drawing.Color.Black
        Me.Label66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label66.Height = 0.16!
        Me.Label66.HyperLink = Nothing
        Me.Label66.Left = 0.12!
        Me.Label66.Name = "Label66"
        Me.Label66.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label66.Text = "RESPONSABLE DE AGENCIA  O C.ACOPIO"
        Me.Label66.Top = 1.0!
        Me.Label66.Width = 2.56!
        '
        'Label67
        '
        Me.Label67.Border.BottomColor = System.Drawing.Color.Black
        Me.Label67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label67.Border.LeftColor = System.Drawing.Color.Black
        Me.Label67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label67.Border.RightColor = System.Drawing.Color.Black
        Me.Label67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label67.Border.TopColor = System.Drawing.Color.Black
        Me.Label67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label67.Height = 0.16!
        Me.Label67.HyperLink = Nothing
        Me.Label67.Left = 4.32!
        Me.Label67.Name = "Label67"
        Me.Label67.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label67.Text = "NOMBRE Y FIRMA (TRANSPORTISTA)"
        Me.Label67.Top = 1.04!
        Me.Label67.Width = 2.56!
        '
        'Label68
        '
        Me.Label68.Border.BottomColor = System.Drawing.Color.Black
        Me.Label68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label68.Border.LeftColor = System.Drawing.Color.Black
        Me.Label68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label68.Border.RightColor = System.Drawing.Color.Black
        Me.Label68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label68.Border.TopColor = System.Drawing.Color.Black
        Me.Label68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label68.Height = 0.16!
        Me.Label68.HyperLink = Nothing
        Me.Label68.Left = 8.28!
        Me.Label68.Name = "Label68"
        Me.Label68.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label68.Text = "NOMBRE Y FIRMA (BENEFICIO)"
        Me.Label68.Top = 1.04!
        Me.Label68.Width = 2.56!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ImgLogo, Me.LblCompañia, Me.Label1, Me.LblTipoRemision, Me.LblCosecha, Me.LblNumeroRemision, Me.lblOrderDate, Me.lblOrderNum, Me.Label36, Me.LblDescripcion, Me.Label38, Me.Label39, Me.Label42, Me.Label43, Me.Label44, Me.Label46, Me.Label47, Me.Label49, Me.Label48, Me.Label45, Me.Label4, Me.LblEmpresaTransporte, Me.Label6, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.LblConductor, Me.LblCedula, Me.TextBox5, Me.LblFechaOrden, Me.LblFechaSalida, Me.Label12, Me.Label13, Me.LblOrigen, Me.LblDestino, Me.Label3, Me.LblCantSaco1, Me.LblPBRecepcion1, Me.LblP1, Me.LblPBRemision1, Me.LblCantSaco11, Me.LblCantSaco2, Me.LblPBRecepcion2, Me.LblP2, Me.LblPBRemision2, Me.LblCantSaco22, Me.LblCantSaco3, Me.LblPBRecepcion3, Me.LblP3, Me.LblPBRemision3, Me.LblCantSaco33, Me.Label5, Me.TextBox12, Me.Label7, Me.TextBox13, Me.Label40, Me.TxtOrigenRemision})
        Me.ReportHeader1.Height = 2.1875!
        Me.ReportHeader1.Name = "ReportHeader1"
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
        Me.ImgLogo.Left = 0.2222222!
        Me.ImgLogo.LineWeight = 0.0!
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.ImgLogo.Top = 0.05555556!
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
        Me.LblCompañia.Left = 1.444445!
        Me.LblCompañia.Name = "LblCompañia"
        Me.LblCompañia.Style = "color: Green; ddo-char-set: 0; font-style: italic; font-size: 11.25pt; "
        Me.LblCompañia.Text = "Exportadora Atlantic S.A"
        Me.LblCompañia.Top = 0.1111111!
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
        Me.Label1.Left = 1.444445!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; ddo-char-set: 0; font-weight: bold; font-style: normal; font-size: " & _
            "9pt; "
        Me.Label1.Text = "REMISION DE CAFÉ PERGAMINO"
        Me.Label1.Top = 0.3333333!
        Me.Label1.Width = 2.92!
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
        Me.LblTipoRemision.Height = 0.2!
        Me.LblTipoRemision.HyperLink = Nothing
        Me.LblTipoRemision.Left = 1.444445!
        Me.LblTipoRemision.Name = "LblTipoRemision"
        Me.LblTipoRemision.Style = "color: Black; ddo-char-set: 0; font-style: normal; font-size: 9pt; "
        Me.LblTipoRemision.Text = "COMPRA DIRECTA - EXPASA"
        Me.LblTipoRemision.Top = 0.5555556!
        Me.LblTipoRemision.Width = 2.92!
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
        Me.LblCosecha.Left = 9.64!
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Style = ""
        Me.LblCosecha.Text = ""
        Me.LblCosecha.Top = 0.52!
        Me.LblCosecha.Width = 1.16!
        '
        'LblNumeroRemision
        '
        Me.LblNumeroRemision.Border.BottomColor = System.Drawing.Color.Black
        Me.LblNumeroRemision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNumeroRemision.Border.LeftColor = System.Drawing.Color.Black
        Me.LblNumeroRemision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNumeroRemision.Border.RightColor = System.Drawing.Color.Black
        Me.LblNumeroRemision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNumeroRemision.Border.TopColor = System.Drawing.Color.Black
        Me.LblNumeroRemision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblNumeroRemision.Height = 0.2!
        Me.LblNumeroRemision.HyperLink = Nothing
        Me.LblNumeroRemision.Left = 9.64!
        Me.LblNumeroRemision.Name = "LblNumeroRemision"
        Me.LblNumeroRemision.Style = ""
        Me.LblNumeroRemision.Text = ""
        Me.LblNumeroRemision.Top = 0.28!
        Me.LblNumeroRemision.Width = 1.16!
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
        Me.lblOrderDate.Height = 0.1875!
        Me.lblOrderDate.HyperLink = Nothing
        Me.lblOrderDate.Left = 8.599999!
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Style = "text-align: left; font-weight: bold; "
        Me.lblOrderDate.Text = "COSECHA:"
        Me.lblOrderDate.Top = 0.52!
        Me.lblOrderDate.Width = 1.0!
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
        Me.lblOrderNum.Height = 0.1875!
        Me.lblOrderNum.HyperLink = Nothing
        Me.lblOrderNum.Left = 8.599999!
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Style = "text-align: left; font-weight: bold; "
        Me.lblOrderNum.Text = "Nº REMISION:"
        Me.lblOrderNum.Top = 0.28!
        Me.lblOrderNum.Width = 1.0!
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
        Me.Label36.Height = 0.16!
        Me.Label36.HyperLink = Nothing
        Me.Label36.Left = 0.0!
        Me.Label36.Name = "Label36"
        Me.Label36.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-style:" & _
            " normal; font-size: 8.25pt; "
        Me.Label36.Text = "DETALLE DEL CAFÉ REMISIONADO"
        Me.Label36.Top = 1.4!
        Me.Label36.Width = 10.8!
        '
        'LblDescripcion
        '
        Me.LblDescripcion.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDescripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblDescripcion.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDescripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblDescripcion.Border.RightColor = System.Drawing.Color.Black
        Me.LblDescripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblDescripcion.Border.TopColor = System.Drawing.Color.Black
        Me.LblDescripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblDescripcion.Height = 0.1666666!
        Me.LblDescripcion.HyperLink = Nothing
        Me.LblDescripcion.Left = 0.2222222!
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.LblDescripcion.Text = "CALIDAD: FRUTO UNDAD DE MEDIDA: KG"
        Me.LblDescripcion.Top = 1.555556!
        Me.LblDescripcion.Width = 10.55556!
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
        Me.Label38.Left = 0.2222222!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label38.Text = "Nº"
        Me.Label38.Top = 1.88!
        Me.Label38.Width = 0.24!
        '
        'Label39
        '
        Me.Label39.Border.BottomColor = System.Drawing.Color.Black
        Me.Label39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Border.LeftColor = System.Drawing.Color.Black
        Me.Label39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Border.RightColor = System.Drawing.Color.Black
        Me.Label39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Border.TopColor = System.Drawing.Color.Black
        Me.Label39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label39.Height = 0.2777777!
        Me.Label39.HyperLink = Nothing
        Me.Label39.Left = 0.4444444!
        Me.Label39.Name = "Label39"
        Me.Label39.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label39.Text = "Nº Recibo"
        Me.Label39.Top = 1.888889!
        Me.Label39.Width = 1.444445!
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
        Me.Label42.Height = 0.2777777!
        Me.Label42.HyperLink = Nothing
        Me.Label42.Left = 1.888889!
        Me.Label42.Name = "Label42"
        Me.Label42.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label42.Text = "% Imp"
        Me.Label42.Top = 1.888889!
        Me.Label42.Width = 0.5555555!
        '
        'Label43
        '
        Me.Label43.Border.BottomColor = System.Drawing.Color.Black
        Me.Label43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.LeftColor = System.Drawing.Color.Black
        Me.Label43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.RightColor = System.Drawing.Color.Black
        Me.Label43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Border.TopColor = System.Drawing.Color.Black
        Me.Label43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label43.Height = 0.2777777!
        Me.Label43.HyperLink = Nothing
        Me.Label43.Left = 2.444444!
        Me.Label43.Name = "Label43"
        Me.Label43.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label43.Text = "Daño"
        Me.Label43.Top = 1.888889!
        Me.Label43.Width = 0.9444444!
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
        Me.Label44.Height = 0.2777777!
        Me.Label44.HyperLink = Nothing
        Me.Label44.Left = 3.388889!
        Me.Label44.Name = "Label44"
        Me.Label44.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label44.Text = "Edo.Fisico"
        Me.Label44.Top = 1.888889!
        Me.Label44.Width = 1.055556!
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
        Me.Label46.Height = 0.2799999!
        Me.Label46.HyperLink = Nothing
        Me.Label46.Left = 4.85!
        Me.Label46.Name = "Label46"
        Me.Label46.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label46.Text = "Peso Bruto"
        Me.Label46.Top = 1.888889!
        Me.Label46.Width = 0.64!
        '
        'Label47
        '
        Me.Label47.Border.BottomColor = System.Drawing.Color.Black
        Me.Label47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Border.LeftColor = System.Drawing.Color.Black
        Me.Label47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Border.RightColor = System.Drawing.Color.Black
        Me.Label47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Border.TopColor = System.Drawing.Color.Black
        Me.Label47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label47.Height = 0.2800001!
        Me.Label47.HyperLink = Nothing
        Me.Label47.Left = 5.9!
        Me.Label47.Name = "Label47"
        Me.Label47.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label47.Text = "Peso Neto"
        Me.Label47.Top = 1.888889!
        Me.Label47.Width = 0.64!
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
        Me.Label49.Height = 0.2799997!
        Me.Label49.HyperLink = Nothing
        Me.Label49.Left = 5.5!
        Me.Label49.Name = "Label49"
        Me.Label49.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label49.Text = "Tara"
        Me.Label49.Top = 1.888889!
        Me.Label49.Width = 0.41!
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
        Me.Label48.Height = 0.16!
        Me.Label48.HyperLink = Nothing
        Me.Label48.Left = 4.444445!
        Me.Label48.Name = "Label48"
        Me.Label48.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.Label48.Text = "Peso Según Remision"
        Me.Label48.Top = 1.722222!
        Me.Label48.Width = 2.1!
        '
        'Label45
        '
        Me.Label45.Border.BottomColor = System.Drawing.Color.Black
        Me.Label45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.LeftColor = System.Drawing.Color.Black
        Me.Label45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.RightColor = System.Drawing.Color.Black
        Me.Label45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Border.TopColor = System.Drawing.Color.Black
        Me.Label45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label45.Height = 0.2800001!
        Me.Label45.HyperLink = Nothing
        Me.Label45.Left = 4.444445!
        Me.Label45.Name = "Label45"
        Me.Label45.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.Label45.Text = "Cant. Sacos"
        Me.Label45.Top = 1.888889!
        Me.Label45.Width = 0.41!
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
        Me.Label4.Height = 0.1666666!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.1666667!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label4.Text = "Emp. Transporte:"
        Me.Label4.Top = 1.0!
        Me.Label4.Width = 1.0!
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
        Me.LblEmpresaTransporte.Height = 0.1666666!
        Me.LblEmpresaTransporte.Left = 1.166667!
        Me.LblEmpresaTransporte.Name = "LblEmpresaTransporte"
        Me.LblEmpresaTransporte.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblEmpresaTransporte.Text = Nothing
        Me.LblEmpresaTransporte.Top = 1.0!
        Me.LblEmpresaTransporte.Width = 1.72!
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
        Me.Label6.Height = 0.1666666!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.1666667!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label6.Text = "Conductor"
        Me.Label6.Top = 1.166667!
        Me.Label6.Width = 1.0!
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
        Me.Label8.Height = 0.16!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 4.388889!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label8.Text = "Ced.Conductor"
        Me.Label8.Top = 1.0!
        Me.Label8.Width = 0.84!
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
        Me.Label9.Left = 4.388889!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label9.Text = "Fecha Recepcion"
        Me.Label9.Top = 1.166667!
        Me.Label9.Visible = False
        Me.Label9.Width = 0.8400001!
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
        Me.Label10.Height = 0.1666667!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 6.333333!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label10.Text = "Fecha Carga"
        Me.Label10.Top = 1.0!
        Me.Label10.Width = 0.7222224!
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
        Me.Label11.Height = 0.1666667!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 6.333333!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label11.Text = "Fecha Salida"
        Me.Label11.Top = 1.166667!
        Me.Label11.Width = 0.7222224!
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
        Me.LblConductor.Height = 0.16!
        Me.LblConductor.Left = 1.166667!
        Me.LblConductor.Name = "LblConductor"
        Me.LblConductor.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblConductor.Text = Nothing
        Me.LblConductor.Top = 1.166667!
        Me.LblConductor.Width = 1.72!
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
        Me.LblCedula.Height = 0.16!
        Me.LblCedula.Left = 5.222222!
        Me.LblCedula.Name = "LblCedula"
        Me.LblCedula.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblCedula.Text = Nothing
        Me.LblCedula.Top = 1.0!
        Me.LblCedula.Width = 1.08!
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
        Me.TextBox5.Height = 0.16!
        Me.TextBox5.Left = 5.222222!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 1.166667!
        Me.TextBox5.Visible = False
        Me.TextBox5.Width = 1.08!
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
        Me.LblFechaOrden.Height = 0.1666667!
        Me.LblFechaOrden.Left = 7.055556!
        Me.LblFechaOrden.Name = "LblFechaOrden"
        Me.LblFechaOrden.OutputFormat = resources.GetString("LblFechaOrden.OutputFormat")
        Me.LblFechaOrden.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblFechaOrden.Text = Nothing
        Me.LblFechaOrden.Top = 1.0!
        Me.LblFechaOrden.Width = 1.33!
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
        Me.LblFechaSalida.Height = 0.1666667!
        Me.LblFechaSalida.Left = 7.055556!
        Me.LblFechaSalida.Name = "LblFechaSalida"
        Me.LblFechaSalida.OutputFormat = resources.GetString("LblFechaSalida.OutputFormat")
        Me.LblFechaSalida.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; "
        Me.LblFechaSalida.Text = Nothing
        Me.LblFechaSalida.Top = 1.166667!
        Me.LblFechaSalida.Width = 1.33!
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
        Me.Label12.Height = 0.175!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 8.375001!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label12.Text = "Ultimo PI"
        Me.Label12.Top = 1.2!
        Me.Label12.Width = 0.5249997!
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
        Me.Label13.Height = 0.1666667!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 8.375001!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label13.Text = "Destino"
        Me.Label13.Top = 1.375!
        Me.Label13.Width = 0.4444447!
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
        Me.LblOrigen.Height = 0.175!
        Me.LblOrigen.Left = 8.925!
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblOrigen.Text = Nothing
        Me.LblOrigen.Top = 1.2!
        Me.LblOrigen.Width = 1.85!
        '
        'LblDestino
        '
        Me.LblDestino.Border.BottomColor = System.Drawing.Color.Black
        Me.LblDestino.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDestino.Border.LeftColor = System.Drawing.Color.Black
        Me.LblDestino.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDestino.Border.RightColor = System.Drawing.Color.Black
        Me.LblDestino.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDestino.Border.TopColor = System.Drawing.Color.Black
        Me.LblDestino.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblDestino.Height = 0.1666667!
        Me.LblDestino.Left = 8.825!
        Me.LblDestino.Name = "LblDestino"
        Me.LblDestino.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.LblDestino.Text = Nothing
        Me.LblDestino.Top = 1.375!
        Me.LblDestino.Width = 1.944445!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.16!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.05555556!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: Black; ddo-char-set: 0; text-align: center; font-style: normal; font-size:" & _
            " 8.25pt; "
        Me.Label3.Text = "DATOS DE LA EMPRESA DE TRANSPORTE"
        Me.Label3.Top = 0.8333333!
        Me.Label3.Width = 10.76!
        '
        'LblCantSaco1
        '
        Me.LblCantSaco1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCantSaco1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCantSaco1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco1.Border.RightColor = System.Drawing.Color.Black
        Me.LblCantSaco1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco1.Border.TopColor = System.Drawing.Color.Black
        Me.LblCantSaco1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco1.Height = 0.2799997!
        Me.LblCantSaco1.HyperLink = Nothing
        Me.LblCantSaco1.Left = 6.555556!
        Me.LblCantSaco1.Name = "LblCantSaco1"
        Me.LblCantSaco1.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblCantSaco1.Text = "Cant. Sacos"
        Me.LblCantSaco1.Top = 1.888889!
        Me.LblCantSaco1.Visible = False
        Me.LblCantSaco1.Width = 0.41!
        '
        'LblPBRecepcion1
        '
        Me.LblPBRecepcion1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPBRecepcion1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPBRecepcion1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion1.Border.RightColor = System.Drawing.Color.Black
        Me.LblPBRecepcion1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion1.Border.TopColor = System.Drawing.Color.Black
        Me.LblPBRecepcion1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion1.Height = 0.2799997!
        Me.LblPBRecepcion1.HyperLink = Nothing
        Me.LblPBRecepcion1.Left = 6.98!
        Me.LblPBRecepcion1.Name = "LblPBRecepcion1"
        Me.LblPBRecepcion1.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblPBRecepcion1.Text = "PB    Recep."
        Me.LblPBRecepcion1.Top = 1.888889!
        Me.LblPBRecepcion1.Visible = False
        Me.LblPBRecepcion1.Width = 0.64!
        '
        'LblP1
        '
        Me.LblP1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblP1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblP1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP1.Border.RightColor = System.Drawing.Color.Black
        Me.LblP1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP1.Border.TopColor = System.Drawing.Color.Black
        Me.LblP1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP1.Height = 0.1666666!
        Me.LblP1.HyperLink = Nothing
        Me.LblP1.Left = 6.555556!
        Me.LblP1.Name = "LblP1"
        Me.LblP1.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.LblP1.Text = "Punto Intermedio 1"
        Me.LblP1.Top = 1.722222!
        Me.LblP1.Visible = False
        Me.LblP1.Width = 2.1!
        '
        'LblPBRemision1
        '
        Me.LblPBRemision1.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPBRemision1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision1.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPBRemision1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision1.Border.RightColor = System.Drawing.Color.Black
        Me.LblPBRemision1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision1.Border.TopColor = System.Drawing.Color.Black
        Me.LblPBRemision1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision1.Height = 0.2800001!
        Me.LblPBRemision1.HyperLink = Nothing
        Me.LblPBRemision1.Left = 8.02!
        Me.LblPBRemision1.Name = "LblPBRemision1"
        Me.LblPBRemision1.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblPBRemision1.Text = "PB Remision"
        Me.LblPBRemision1.Top = 1.888889!
        Me.LblPBRemision1.Visible = False
        Me.LblPBRemision1.Width = 0.64!
        '
        'LblCantSaco11
        '
        Me.LblCantSaco11.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCantSaco11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco11.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCantSaco11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco11.Border.RightColor = System.Drawing.Color.Black
        Me.LblCantSaco11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco11.Border.TopColor = System.Drawing.Color.Black
        Me.LblCantSaco11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco11.Height = 0.2799997!
        Me.LblCantSaco11.HyperLink = Nothing
        Me.LblCantSaco11.Left = 7.611111!
        Me.LblCantSaco11.Name = "LblCantSaco11"
        Me.LblCantSaco11.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblCantSaco11.Text = "Cant. Sacos"
        Me.LblCantSaco11.Top = 1.888889!
        Me.LblCantSaco11.Visible = False
        Me.LblCantSaco11.Width = 0.41!
        '
        'LblCantSaco2
        '
        Me.LblCantSaco2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCantSaco2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCantSaco2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco2.Border.RightColor = System.Drawing.Color.Black
        Me.LblCantSaco2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco2.Border.TopColor = System.Drawing.Color.Black
        Me.LblCantSaco2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco2.Height = 0.2799997!
        Me.LblCantSaco2.HyperLink = Nothing
        Me.LblCantSaco2.Left = 8.666667!
        Me.LblCantSaco2.Name = "LblCantSaco2"
        Me.LblCantSaco2.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblCantSaco2.Text = "Cant. Sacos"
        Me.LblCantSaco2.Top = 1.888889!
        Me.LblCantSaco2.Visible = False
        Me.LblCantSaco2.Width = 0.39!
        '
        'LblPBRecepcion2
        '
        Me.LblPBRecepcion2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPBRecepcion2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPBRecepcion2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion2.Border.RightColor = System.Drawing.Color.Black
        Me.LblPBRecepcion2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion2.Border.TopColor = System.Drawing.Color.Black
        Me.LblPBRecepcion2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion2.Height = 0.28!
        Me.LblPBRecepcion2.HyperLink = Nothing
        Me.LblPBRecepcion2.Left = 9.055556!
        Me.LblPBRecepcion2.Name = "LblPBRecepcion2"
        Me.LblPBRecepcion2.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblPBRecepcion2.Text = "PB    Recep."
        Me.LblPBRecepcion2.Top = 1.888889!
        Me.LblPBRecepcion2.Visible = False
        Me.LblPBRecepcion2.Width = 0.64!
        '
        'LblP2
        '
        Me.LblP2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblP2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblP2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP2.Border.RightColor = System.Drawing.Color.Black
        Me.LblP2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP2.Border.TopColor = System.Drawing.Color.Black
        Me.LblP2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP2.Height = 0.16!
        Me.LblP2.HyperLink = Nothing
        Me.LblP2.Left = 8.666667!
        Me.LblP2.Name = "LblP2"
        Me.LblP2.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.LblP2.Text = "Punto Intermedio 2"
        Me.LblP2.Top = 1.722222!
        Me.LblP2.Visible = False
        Me.LblP2.Width = 2.1!
        '
        'LblPBRemision2
        '
        Me.LblPBRemision2.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPBRemision2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision2.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPBRemision2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision2.Border.RightColor = System.Drawing.Color.Black
        Me.LblPBRemision2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision2.Border.TopColor = System.Drawing.Color.Black
        Me.LblPBRemision2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision2.Height = 0.2800001!
        Me.LblPBRemision2.HyperLink = Nothing
        Me.LblPBRemision2.Left = 10.13!
        Me.LblPBRemision2.Name = "LblPBRemision2"
        Me.LblPBRemision2.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblPBRemision2.Text = "PB Remision"
        Me.LblPBRemision2.Top = 1.888889!
        Me.LblPBRemision2.Visible = False
        Me.LblPBRemision2.Width = 0.64!
        '
        'LblCantSaco22
        '
        Me.LblCantSaco22.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCantSaco22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco22.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCantSaco22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco22.Border.RightColor = System.Drawing.Color.Black
        Me.LblCantSaco22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco22.Border.TopColor = System.Drawing.Color.Black
        Me.LblCantSaco22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco22.Height = 0.2799997!
        Me.LblCantSaco22.HyperLink = Nothing
        Me.LblCantSaco22.Left = 9.7!
        Me.LblCantSaco22.Name = "LblCantSaco22"
        Me.LblCantSaco22.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblCantSaco22.Text = "Cant. Sacos"
        Me.LblCantSaco22.Top = 1.888889!
        Me.LblCantSaco22.Visible = False
        Me.LblCantSaco22.Width = 0.41!
        '
        'LblCantSaco3
        '
        Me.LblCantSaco3.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCantSaco3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco3.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCantSaco3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco3.Border.RightColor = System.Drawing.Color.Black
        Me.LblCantSaco3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco3.Border.TopColor = System.Drawing.Color.Black
        Me.LblCantSaco3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco3.Height = 0.2799997!
        Me.LblCantSaco3.HyperLink = Nothing
        Me.LblCantSaco3.Left = 11.77778!
        Me.LblCantSaco3.Name = "LblCantSaco3"
        Me.LblCantSaco3.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblCantSaco3.Text = "Cant. Sacos"
        Me.LblCantSaco3.Top = 1.888889!
        Me.LblCantSaco3.Visible = False
        Me.LblCantSaco3.Width = 0.3199998!
        '
        'LblPBRecepcion3
        '
        Me.LblPBRecepcion3.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPBRecepcion3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion3.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPBRecepcion3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion3.Border.RightColor = System.Drawing.Color.Black
        Me.LblPBRecepcion3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion3.Border.TopColor = System.Drawing.Color.Black
        Me.LblPBRecepcion3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRecepcion3.Height = 0.2799997!
        Me.LblPBRecepcion3.HyperLink = Nothing
        Me.LblPBRecepcion3.Left = 12.11111!
        Me.LblPBRecepcion3.Name = "LblPBRecepcion3"
        Me.LblPBRecepcion3.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblPBRecepcion3.Text = "PB    Recep."
        Me.LblPBRecepcion3.Top = 1.888889!
        Me.LblPBRecepcion3.Visible = False
        Me.LblPBRecepcion3.Width = 0.5599999!
        '
        'LblP3
        '
        Me.LblP3.Border.BottomColor = System.Drawing.Color.Black
        Me.LblP3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP3.Border.LeftColor = System.Drawing.Color.Black
        Me.LblP3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP3.Border.RightColor = System.Drawing.Color.Black
        Me.LblP3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP3.Border.TopColor = System.Drawing.Color.Black
        Me.LblP3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblP3.Height = 0.16!
        Me.LblP3.HyperLink = Nothing
        Me.LblP3.Left = 11.77778!
        Me.LblP3.Name = "LblP3"
        Me.LblP3.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-styl" & _
            "e: normal; font-size: 8.25pt; "
        Me.LblP3.Text = "Punto Intermedio 3"
        Me.LblP3.Top = 1.722222!
        Me.LblP3.Visible = False
        Me.LblP3.Width = 1.76!
        '
        'LblPBRemision3
        '
        Me.LblPBRemision3.Border.BottomColor = System.Drawing.Color.Black
        Me.LblPBRemision3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision3.Border.LeftColor = System.Drawing.Color.Black
        Me.LblPBRemision3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision3.Border.RightColor = System.Drawing.Color.Black
        Me.LblPBRemision3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision3.Border.TopColor = System.Drawing.Color.Black
        Me.LblPBRemision3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblPBRemision3.Height = 0.2800001!
        Me.LblPBRemision3.HyperLink = Nothing
        Me.LblPBRemision3.Left = 13.0!
        Me.LblPBRemision3.Name = "LblPBRemision3"
        Me.LblPBRemision3.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblPBRemision3.Text = "PB Remision"
        Me.LblPBRemision3.Top = 1.888889!
        Me.LblPBRemision3.Visible = False
        Me.LblPBRemision3.Width = 0.56!
        '
        'LblCantSaco33
        '
        Me.LblCantSaco33.Border.BottomColor = System.Drawing.Color.Black
        Me.LblCantSaco33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco33.Border.LeftColor = System.Drawing.Color.Black
        Me.LblCantSaco33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco33.Border.RightColor = System.Drawing.Color.Black
        Me.LblCantSaco33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco33.Border.TopColor = System.Drawing.Color.Black
        Me.LblCantSaco33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblCantSaco33.Height = 0.2799997!
        Me.LblCantSaco33.HyperLink = Nothing
        Me.LblCantSaco33.Left = 12.66667!
        Me.LblCantSaco33.Name = "LblCantSaco33"
        Me.LblCantSaco33.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; "
        Me.LblCantSaco33.Text = "Cant. Sacos"
        Me.LblCantSaco33.Top = 1.888889!
        Me.LblCantSaco33.Visible = False
        Me.LblCantSaco33.Width = 0.3199998!
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
        Me.Label5.Height = 0.16!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 2.888889!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label5.Text = "Marca"
        Me.Label5.Top = 1.166667!
        Me.Label5.Width = 0.56!
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
        Me.TextBox12.Height = 0.1666667!
        Me.TextBox12.Left = 3.444445!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox12.Text = Nothing
        Me.TextBox12.Top = 1.0!
        Me.TextBox12.Width = 0.94!
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
        Me.Label7.Height = 0.16!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 2.888889!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label7.Text = "Placa"
        Me.Label7.Top = 1.0!
        Me.Label7.Width = 0.5600001!
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
        Me.TextBox13.Height = 0.1666667!
        Me.TextBox13.Left = 3.444445!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 1.166667!
        Me.TextBox13.Width = 0.94!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label14, Me.Label15, Me.TxtEmpTransp1, Me.Label16, Me.TxtPlaca1, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.TxtConductor1, Me.TxtMarca1, Me.TxtCedConductor1, Me.TxtFechaRecp1, Me.TxtFechaCarga1, Me.TxtFechaSalida1, Me.Label23, Me.Label24, Me.TxtOrigen1, Me.TxtDestino1, Me.Label25, Me.Label26, Me.TxtEmpTransp2, Me.Label27, Me.TxtPlaca2, Me.Label28, Me.Label29, Me.Label30, Me.Label31, Me.Label32, Me.Label33, Me.TxtConductor2, Me.TxtMarca2, Me.TxtCedConductor2, Me.TxtFechaCarga2, Me.TxtFechaSalida2, Me.Label34, Me.Label35, Me.TxtOrigen2, Me.TxtDestino2, Me.TxtFechaRecp2, Me.Label2, Me.Label37, Me.TxtEmpTransp3, Me.Label63, Me.TxtPlaca3, Me.Label64, Me.Label69, Me.Label70, Me.Label71, Me.Label72, Me.Label73, Me.TxtConductor3, Me.TxtMarca3, Me.TxtCedConductor3, Me.TxtFechaRecp3, Me.TxtFechaCarga3, Me.TxtFechaSalida3, Me.Label74, Me.Label75, Me.TxtOrigen3, Me.TxtDestino3})
        Me.ReportFooter1.Height = 0.8229167!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Height = 0.16!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 0.0!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-style:" & _
            " normal; font-size: 8.25pt; "
        Me.Label14.Text = "PUNTO INTERMEDIO 1"
        Me.Label14.Top = 0.0!
        Me.Label14.Visible = False
        Me.Label14.Width = 10.76!
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
        Me.Label15.Height = 0.16!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0.0!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label15.Text = "Emp. Transporte:"
        Me.Label15.Top = 0.2!
        Me.Label15.Visible = False
        Me.Label15.Width = 0.8!
        '
        'TxtEmpTransp1
        '
        Me.TxtEmpTransp1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtEmpTransp1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtEmpTransp1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtEmpTransp1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtEmpTransp1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp1.Height = 0.16!
        Me.TxtEmpTransp1.Left = 0.84!
        Me.TxtEmpTransp1.Name = "TxtEmpTransp1"
        Me.TxtEmpTransp1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtEmpTransp1.Text = Nothing
        Me.TxtEmpTransp1.Top = 0.2!
        Me.TxtEmpTransp1.Visible = False
        Me.TxtEmpTransp1.Width = 1.88!
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
        Me.Label16.Height = 0.16!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 2.76!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label16.Text = "Placa"
        Me.Label16.Top = 0.2!
        Me.Label16.Visible = False
        Me.Label16.Width = 0.56!
        '
        'TxtPlaca1
        '
        Me.TxtPlaca1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPlaca1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPlaca1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPlaca1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPlaca1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca1.Height = 0.16!
        Me.TxtPlaca1.Left = 3.36!
        Me.TxtPlaca1.Name = "TxtPlaca1"
        Me.TxtPlaca1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtPlaca1.Text = Nothing
        Me.TxtPlaca1.Top = 0.2!
        Me.TxtPlaca1.Visible = False
        Me.TxtPlaca1.Width = 1.16!
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
        Me.Label17.Height = 0.16!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.0!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label17.Text = "Conductor"
        Me.Label17.Top = 0.36!
        Me.Label17.Visible = False
        Me.Label17.Width = 0.8!
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
        Me.Label18.Height = 0.16!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 2.76!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label18.Text = "Marca"
        Me.Label18.Top = 0.36!
        Me.Label18.Visible = False
        Me.Label18.Width = 0.56!
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
        Me.Label19.Height = 0.16!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 4.56!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label19.Text = "Ced.Conductor"
        Me.Label19.Top = 0.2!
        Me.Label19.Visible = False
        Me.Label19.Width = 0.84!
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
        Me.Label20.Height = 0.16!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 4.56!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label20.Text = "Fecha Recepcion"
        Me.Label20.Top = 0.36!
        Me.Label20.Visible = False
        Me.Label20.Width = 0.84!
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
        Me.Label21.Height = 0.16!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 6.6!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label21.Text = "Fecha Carga"
        Me.Label21.Top = 0.2!
        Me.Label21.Visible = False
        Me.Label21.Width = 0.6!
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
        Me.Label22.Height = 0.16!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 6.6!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label22.Text = "Fecha Salida"
        Me.Label22.Top = 0.36!
        Me.Label22.Visible = False
        Me.Label22.Width = 0.6!
        '
        'TxtConductor1
        '
        Me.TxtConductor1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtConductor1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtConductor1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtConductor1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtConductor1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor1.Height = 0.16!
        Me.TxtConductor1.Left = 0.84!
        Me.TxtConductor1.Name = "TxtConductor1"
        Me.TxtConductor1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtConductor1.Text = Nothing
        Me.TxtConductor1.Top = 0.36!
        Me.TxtConductor1.Visible = False
        Me.TxtConductor1.Width = 1.88!
        '
        'TxtMarca1
        '
        Me.TxtMarca1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMarca1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMarca1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMarca1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMarca1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca1.Height = 0.16!
        Me.TxtMarca1.Left = 3.36!
        Me.TxtMarca1.Name = "TxtMarca1"
        Me.TxtMarca1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtMarca1.Text = Nothing
        Me.TxtMarca1.Top = 0.36!
        Me.TxtMarca1.Visible = False
        Me.TxtMarca1.Width = 1.16!
        '
        'TxtCedConductor1
        '
        Me.TxtCedConductor1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCedConductor1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCedConductor1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCedConductor1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCedConductor1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor1.Height = 0.16!
        Me.TxtCedConductor1.Left = 5.44!
        Me.TxtCedConductor1.Name = "TxtCedConductor1"
        Me.TxtCedConductor1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtCedConductor1.Text = Nothing
        Me.TxtCedConductor1.Top = 0.2!
        Me.TxtCedConductor1.Visible = False
        Me.TxtCedConductor1.Width = 1.08!
        '
        'TxtFechaRecp1
        '
        Me.TxtFechaRecp1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaRecp1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaRecp1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaRecp1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaRecp1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp1.Height = 0.16!
        Me.TxtFechaRecp1.Left = 5.44!
        Me.TxtFechaRecp1.Name = "TxtFechaRecp1"
        Me.TxtFechaRecp1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaRecp1.Text = Nothing
        Me.TxtFechaRecp1.Top = 0.36!
        Me.TxtFechaRecp1.Visible = False
        Me.TxtFechaRecp1.Width = 1.08!
        '
        'TxtFechaCarga1
        '
        Me.TxtFechaCarga1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaCarga1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaCarga1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaCarga1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaCarga1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga1.Height = 0.16!
        Me.TxtFechaCarga1.Left = 7.28!
        Me.TxtFechaCarga1.Name = "TxtFechaCarga1"
        Me.TxtFechaCarga1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaCarga1.Text = Nothing
        Me.TxtFechaCarga1.Top = 0.2!
        Me.TxtFechaCarga1.Visible = False
        Me.TxtFechaCarga1.Width = 0.8800001!
        '
        'TxtFechaSalida1
        '
        Me.TxtFechaSalida1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaSalida1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaSalida1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaSalida1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaSalida1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida1.Height = 0.16!
        Me.TxtFechaSalida1.Left = 7.28!
        Me.TxtFechaSalida1.Name = "TxtFechaSalida1"
        Me.TxtFechaSalida1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaSalida1.Text = Nothing
        Me.TxtFechaSalida1.Top = 0.36!
        Me.TxtFechaSalida1.Visible = False
        Me.TxtFechaSalida1.Width = 0.8800001!
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
        Me.Label23.Height = 0.16!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 8.24!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label23.Text = "Origen"
        Me.Label23.Top = 0.2!
        Me.Label23.Visible = False
        Me.Label23.Width = 0.48!
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
        Me.Label24.Height = 0.16!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 8.24!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label24.Text = "Destino"
        Me.Label24.Top = 0.36!
        Me.Label24.Visible = False
        Me.Label24.Width = 0.48!
        '
        'TxtOrigen1
        '
        Me.TxtOrigen1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtOrigen1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtOrigen1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtOrigen1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtOrigen1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen1.Height = 0.16!
        Me.TxtOrigen1.Left = 8.759999!
        Me.TxtOrigen1.Name = "TxtOrigen1"
        Me.TxtOrigen1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtOrigen1.Text = Nothing
        Me.TxtOrigen1.Top = 0.2!
        Me.TxtOrigen1.Visible = False
        Me.TxtOrigen1.Width = 2.0!
        '
        'TxtDestino1
        '
        Me.TxtDestino1.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtDestino1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino1.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtDestino1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino1.Border.RightColor = System.Drawing.Color.Black
        Me.TxtDestino1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino1.Border.TopColor = System.Drawing.Color.Black
        Me.TxtDestino1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino1.Height = 0.16!
        Me.TxtDestino1.Left = 8.759999!
        Me.TxtDestino1.Name = "TxtDestino1"
        Me.TxtDestino1.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtDestino1.Text = Nothing
        Me.TxtDestino1.Top = 0.36!
        Me.TxtDestino1.Visible = False
        Me.TxtDestino1.Width = 2.0!
        '
        'Label25
        '
        Me.Label25.Border.BottomColor = System.Drawing.Color.Black
        Me.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label25.Border.LeftColor = System.Drawing.Color.Black
        Me.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Border.RightColor = System.Drawing.Color.Black
        Me.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Border.TopColor = System.Drawing.Color.Black
        Me.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label25.Height = 0.16!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 0.0!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-style:" & _
            " normal; font-size: 8.25pt; "
        Me.Label25.Text = "PUNTO INTERMEDIO 2"
        Me.Label25.Top = 0.5600001!
        Me.Label25.Visible = False
        Me.Label25.Width = 10.76!
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
        Me.Label26.Height = 0.16!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 0.04!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label26.Text = "Emp. Transporte:"
        Me.Label26.Top = 0.76!
        Me.Label26.Visible = False
        Me.Label26.Width = 0.8!
        '
        'TxtEmpTransp2
        '
        Me.TxtEmpTransp2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtEmpTransp2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtEmpTransp2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtEmpTransp2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtEmpTransp2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp2.Height = 0.16!
        Me.TxtEmpTransp2.Left = 0.8799999!
        Me.TxtEmpTransp2.Name = "TxtEmpTransp2"
        Me.TxtEmpTransp2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtEmpTransp2.Text = Nothing
        Me.TxtEmpTransp2.Top = 0.76!
        Me.TxtEmpTransp2.Visible = False
        Me.TxtEmpTransp2.Width = 1.88!
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
        Me.Label27.Height = 0.16!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 2.8!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label27.Text = "Placa"
        Me.Label27.Top = 0.76!
        Me.Label27.Visible = False
        Me.Label27.Width = 0.56!
        '
        'TxtPlaca2
        '
        Me.TxtPlaca2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPlaca2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPlaca2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPlaca2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPlaca2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca2.Height = 0.16!
        Me.TxtPlaca2.Left = 3.4!
        Me.TxtPlaca2.Name = "TxtPlaca2"
        Me.TxtPlaca2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtPlaca2.Text = Nothing
        Me.TxtPlaca2.Top = 0.76!
        Me.TxtPlaca2.Visible = False
        Me.TxtPlaca2.Width = 1.12!
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
        Me.Label28.Height = 0.16!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 0.04!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label28.Text = "Conductor"
        Me.Label28.Top = 0.9200001!
        Me.Label28.Visible = False
        Me.Label28.Width = 0.8!
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
        Me.Label29.Height = 0.16!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 2.8!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label29.Text = "Marca"
        Me.Label29.Top = 0.9200001!
        Me.Label29.Visible = False
        Me.Label29.Width = 0.56!
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
        Me.Label30.Height = 0.16!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 4.6!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label30.Text = "Ced.Conductor"
        Me.Label30.Top = 0.76!
        Me.Label30.Visible = False
        Me.Label30.Width = 0.84!
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
        Me.Label31.Height = 0.16!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 4.6!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label31.Text = "Fecha Recepcion"
        Me.Label31.Top = 0.9200001!
        Me.Label31.Visible = False
        Me.Label31.Width = 0.84!
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
        Me.Label32.Height = 0.16!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 6.6!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label32.Text = "Fecha Carga"
        Me.Label32.Top = 0.76!
        Me.Label32.Visible = False
        Me.Label32.Width = 0.6!
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
        Me.Label33.Height = 0.16!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 6.6!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label33.Text = "Fecha Salida"
        Me.Label33.Top = 0.9200001!
        Me.Label33.Visible = False
        Me.Label33.Width = 0.6!
        '
        'TxtConductor2
        '
        Me.TxtConductor2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtConductor2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtConductor2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtConductor2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtConductor2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor2.Height = 0.16!
        Me.TxtConductor2.Left = 0.8799999!
        Me.TxtConductor2.Name = "TxtConductor2"
        Me.TxtConductor2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtConductor2.Text = Nothing
        Me.TxtConductor2.Top = 0.9200001!
        Me.TxtConductor2.Visible = False
        Me.TxtConductor2.Width = 1.88!
        '
        'TxtMarca2
        '
        Me.TxtMarca2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMarca2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMarca2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMarca2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMarca2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca2.Height = 0.16!
        Me.TxtMarca2.Left = 3.4!
        Me.TxtMarca2.Name = "TxtMarca2"
        Me.TxtMarca2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtMarca2.Text = Nothing
        Me.TxtMarca2.Top = 0.9200001!
        Me.TxtMarca2.Visible = False
        Me.TxtMarca2.Width = 1.12!
        '
        'TxtCedConductor2
        '
        Me.TxtCedConductor2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCedConductor2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCedConductor2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCedConductor2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCedConductor2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor2.Height = 0.16!
        Me.TxtCedConductor2.Left = 5.48!
        Me.TxtCedConductor2.Name = "TxtCedConductor2"
        Me.TxtCedConductor2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtCedConductor2.Text = Nothing
        Me.TxtCedConductor2.Top = 0.76!
        Me.TxtCedConductor2.Visible = False
        Me.TxtCedConductor2.Width = 1.08!
        '
        'TxtFechaCarga2
        '
        Me.TxtFechaCarga2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaCarga2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaCarga2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaCarga2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaCarga2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga2.Height = 0.16!
        Me.TxtFechaCarga2.Left = 7.24!
        Me.TxtFechaCarga2.Name = "TxtFechaCarga2"
        Me.TxtFechaCarga2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaCarga2.Text = Nothing
        Me.TxtFechaCarga2.Top = 0.76!
        Me.TxtFechaCarga2.Visible = False
        Me.TxtFechaCarga2.Width = 0.8800001!
        '
        'TxtFechaSalida2
        '
        Me.TxtFechaSalida2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaSalida2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaSalida2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaSalida2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaSalida2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida2.Height = 0.16!
        Me.TxtFechaSalida2.Left = 7.24!
        Me.TxtFechaSalida2.Name = "TxtFechaSalida2"
        Me.TxtFechaSalida2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaSalida2.Text = Nothing
        Me.TxtFechaSalida2.Top = 0.9200001!
        Me.TxtFechaSalida2.Visible = False
        Me.TxtFechaSalida2.Width = 0.8800001!
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
        Me.Label34.Height = 0.16!
        Me.Label34.HyperLink = Nothing
        Me.Label34.Left = 8.24!
        Me.Label34.Name = "Label34"
        Me.Label34.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label34.Text = "Origen"
        Me.Label34.Top = 0.76!
        Me.Label34.Visible = False
        Me.Label34.Width = 0.48!
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
        Me.Label35.Height = 0.16!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 8.24!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label35.Text = "Destino"
        Me.Label35.Top = 0.9200001!
        Me.Label35.Visible = False
        Me.Label35.Width = 0.48!
        '
        'TxtOrigen2
        '
        Me.TxtOrigen2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtOrigen2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtOrigen2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtOrigen2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtOrigen2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen2.Height = 0.16!
        Me.TxtOrigen2.Left = 8.759999!
        Me.TxtOrigen2.Name = "TxtOrigen2"
        Me.TxtOrigen2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtOrigen2.Text = Nothing
        Me.TxtOrigen2.Top = 0.76!
        Me.TxtOrigen2.Visible = False
        Me.TxtOrigen2.Width = 2.0!
        '
        'TxtDestino2
        '
        Me.TxtDestino2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtDestino2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtDestino2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtDestino2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtDestino2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino2.Height = 0.16!
        Me.TxtDestino2.Left = 8.759999!
        Me.TxtDestino2.Name = "TxtDestino2"
        Me.TxtDestino2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtDestino2.Text = Nothing
        Me.TxtDestino2.Top = 0.9200001!
        Me.TxtDestino2.Visible = False
        Me.TxtDestino2.Width = 2.0!
        '
        'TxtFechaRecp2
        '
        Me.TxtFechaRecp2.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaRecp2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp2.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaRecp2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp2.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaRecp2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp2.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaRecp2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp2.Height = 0.16!
        Me.TxtFechaRecp2.Left = 5.48!
        Me.TxtFechaRecp2.Name = "TxtFechaRecp2"
        Me.TxtFechaRecp2.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaRecp2.Text = Nothing
        Me.TxtFechaRecp2.Top = 0.9200001!
        Me.TxtFechaRecp2.Visible = False
        Me.TxtFechaRecp2.Width = 1.08!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.16!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.04!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-style:" & _
            " normal; font-size: 8.25pt; "
        Me.Label2.Text = "PUNTO INTERMEDIO 3"
        Me.Label2.Top = 1.08!
        Me.Label2.Visible = False
        Me.Label2.Width = 10.76!
        '
        'Label37
        '
        Me.Label37.Border.BottomColor = System.Drawing.Color.Black
        Me.Label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label37.Border.LeftColor = System.Drawing.Color.Black
        Me.Label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label37.Border.RightColor = System.Drawing.Color.Black
        Me.Label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label37.Border.TopColor = System.Drawing.Color.Black
        Me.Label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label37.Height = 0.16!
        Me.Label37.HyperLink = Nothing
        Me.Label37.Left = 0.04!
        Me.Label37.Name = "Label37"
        Me.Label37.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label37.Text = "Emp. Transporte:"
        Me.Label37.Top = 1.28!
        Me.Label37.Visible = False
        Me.Label37.Width = 0.8!
        '
        'TxtEmpTransp3
        '
        Me.TxtEmpTransp3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtEmpTransp3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtEmpTransp3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtEmpTransp3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtEmpTransp3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtEmpTransp3.Height = 0.2!
        Me.TxtEmpTransp3.Left = 0.8799999!
        Me.TxtEmpTransp3.Name = "TxtEmpTransp3"
        Me.TxtEmpTransp3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtEmpTransp3.Text = Nothing
        Me.TxtEmpTransp3.Top = 1.28!
        Me.TxtEmpTransp3.Visible = False
        Me.TxtEmpTransp3.Width = 1.88!
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
        Me.Label63.Height = 0.16!
        Me.Label63.HyperLink = Nothing
        Me.Label63.Left = 2.8!
        Me.Label63.Name = "Label63"
        Me.Label63.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label63.Text = "Placa"
        Me.Label63.Top = 1.28!
        Me.Label63.Visible = False
        Me.Label63.Width = 0.56!
        '
        'TxtPlaca3
        '
        Me.TxtPlaca3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtPlaca3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtPlaca3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtPlaca3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtPlaca3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtPlaca3.Height = 0.16!
        Me.TxtPlaca3.Left = 3.4!
        Me.TxtPlaca3.Name = "TxtPlaca3"
        Me.TxtPlaca3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtPlaca3.Text = Nothing
        Me.TxtPlaca3.Top = 1.28!
        Me.TxtPlaca3.Visible = False
        Me.TxtPlaca3.Width = 1.12!
        '
        'Label64
        '
        Me.Label64.Border.BottomColor = System.Drawing.Color.Black
        Me.Label64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label64.Border.LeftColor = System.Drawing.Color.Black
        Me.Label64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label64.Border.RightColor = System.Drawing.Color.Black
        Me.Label64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label64.Border.TopColor = System.Drawing.Color.Black
        Me.Label64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label64.Height = 0.16!
        Me.Label64.HyperLink = Nothing
        Me.Label64.Left = 0.04!
        Me.Label64.Name = "Label64"
        Me.Label64.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label64.Text = "Conductor"
        Me.Label64.Top = 1.44!
        Me.Label64.Visible = False
        Me.Label64.Width = 0.8!
        '
        'Label69
        '
        Me.Label69.Border.BottomColor = System.Drawing.Color.Black
        Me.Label69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label69.Border.LeftColor = System.Drawing.Color.Black
        Me.Label69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label69.Border.RightColor = System.Drawing.Color.Black
        Me.Label69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label69.Border.TopColor = System.Drawing.Color.Black
        Me.Label69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label69.Height = 0.16!
        Me.Label69.HyperLink = Nothing
        Me.Label69.Left = 2.8!
        Me.Label69.Name = "Label69"
        Me.Label69.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label69.Text = "Marca"
        Me.Label69.Top = 1.44!
        Me.Label69.Visible = False
        Me.Label69.Width = 0.5600001!
        '
        'Label70
        '
        Me.Label70.Border.BottomColor = System.Drawing.Color.Black
        Me.Label70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label70.Border.LeftColor = System.Drawing.Color.Black
        Me.Label70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label70.Border.RightColor = System.Drawing.Color.Black
        Me.Label70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label70.Border.TopColor = System.Drawing.Color.Black
        Me.Label70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label70.Height = 0.16!
        Me.Label70.HyperLink = Nothing
        Me.Label70.Left = 4.56!
        Me.Label70.Name = "Label70"
        Me.Label70.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label70.Text = "Ced.Conductor"
        Me.Label70.Top = 1.28!
        Me.Label70.Visible = False
        Me.Label70.Width = 0.84!
        '
        'Label71
        '
        Me.Label71.Border.BottomColor = System.Drawing.Color.Black
        Me.Label71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label71.Border.LeftColor = System.Drawing.Color.Black
        Me.Label71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label71.Border.RightColor = System.Drawing.Color.Black
        Me.Label71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label71.Border.TopColor = System.Drawing.Color.Black
        Me.Label71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label71.Height = 0.16!
        Me.Label71.HyperLink = Nothing
        Me.Label71.Left = 4.56!
        Me.Label71.Name = "Label71"
        Me.Label71.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label71.Text = "Fecha Recepcion"
        Me.Label71.Top = 1.44!
        Me.Label71.Visible = False
        Me.Label71.Width = 0.84!
        '
        'Label72
        '
        Me.Label72.Border.BottomColor = System.Drawing.Color.Black
        Me.Label72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label72.Border.LeftColor = System.Drawing.Color.Black
        Me.Label72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label72.Border.RightColor = System.Drawing.Color.Black
        Me.Label72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label72.Border.TopColor = System.Drawing.Color.Black
        Me.Label72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label72.Height = 0.16!
        Me.Label72.HyperLink = Nothing
        Me.Label72.Left = 6.6!
        Me.Label72.Name = "Label72"
        Me.Label72.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label72.Text = "Fecha Carga"
        Me.Label72.Top = 1.28!
        Me.Label72.Visible = False
        Me.Label72.Width = 0.6!
        '
        'Label73
        '
        Me.Label73.Border.BottomColor = System.Drawing.Color.Black
        Me.Label73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label73.Border.LeftColor = System.Drawing.Color.Black
        Me.Label73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label73.Border.RightColor = System.Drawing.Color.Black
        Me.Label73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label73.Border.TopColor = System.Drawing.Color.Black
        Me.Label73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label73.Height = 0.16!
        Me.Label73.HyperLink = Nothing
        Me.Label73.Left = 6.6!
        Me.Label73.Name = "Label73"
        Me.Label73.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label73.Text = "Fecha Salida"
        Me.Label73.Top = 1.44!
        Me.Label73.Visible = False
        Me.Label73.Width = 0.6!
        '
        'TxtConductor3
        '
        Me.TxtConductor3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtConductor3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtConductor3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtConductor3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtConductor3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtConductor3.Height = 0.16!
        Me.TxtConductor3.Left = 0.8799999!
        Me.TxtConductor3.Name = "TxtConductor3"
        Me.TxtConductor3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtConductor3.Text = Nothing
        Me.TxtConductor3.Top = 1.44!
        Me.TxtConductor3.Visible = False
        Me.TxtConductor3.Width = 1.88!
        '
        'TxtMarca3
        '
        Me.TxtMarca3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtMarca3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtMarca3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtMarca3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtMarca3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtMarca3.Height = 0.16!
        Me.TxtMarca3.Left = 3.4!
        Me.TxtMarca3.Name = "TxtMarca3"
        Me.TxtMarca3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtMarca3.Text = Nothing
        Me.TxtMarca3.Top = 1.44!
        Me.TxtMarca3.Visible = False
        Me.TxtMarca3.Width = 1.12!
        '
        'TxtCedConductor3
        '
        Me.TxtCedConductor3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtCedConductor3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtCedConductor3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtCedConductor3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtCedConductor3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtCedConductor3.Height = 0.16!
        Me.TxtCedConductor3.Left = 5.44!
        Me.TxtCedConductor3.Name = "TxtCedConductor3"
        Me.TxtCedConductor3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtCedConductor3.Text = Nothing
        Me.TxtCedConductor3.Top = 1.28!
        Me.TxtCedConductor3.Visible = False
        Me.TxtCedConductor3.Width = 1.08!
        '
        'TxtFechaRecp3
        '
        Me.TxtFechaRecp3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaRecp3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaRecp3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaRecp3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaRecp3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaRecp3.Height = 0.16!
        Me.TxtFechaRecp3.Left = 5.44!
        Me.TxtFechaRecp3.Name = "TxtFechaRecp3"
        Me.TxtFechaRecp3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaRecp3.Text = Nothing
        Me.TxtFechaRecp3.Top = 1.44!
        Me.TxtFechaRecp3.Visible = False
        Me.TxtFechaRecp3.Width = 1.08!
        '
        'TxtFechaCarga3
        '
        Me.TxtFechaCarga3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaCarga3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaCarga3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaCarga3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaCarga3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaCarga3.Height = 0.16!
        Me.TxtFechaCarga3.Left = 7.24!
        Me.TxtFechaCarga3.Name = "TxtFechaCarga3"
        Me.TxtFechaCarga3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaCarga3.Text = Nothing
        Me.TxtFechaCarga3.Top = 1.28!
        Me.TxtFechaCarga3.Visible = False
        Me.TxtFechaCarga3.Width = 0.8800001!
        '
        'TxtFechaSalida3
        '
        Me.TxtFechaSalida3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtFechaSalida3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtFechaSalida3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtFechaSalida3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtFechaSalida3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtFechaSalida3.Height = 0.16!
        Me.TxtFechaSalida3.Left = 7.24!
        Me.TxtFechaSalida3.Name = "TxtFechaSalida3"
        Me.TxtFechaSalida3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtFechaSalida3.Text = Nothing
        Me.TxtFechaSalida3.Top = 1.44!
        Me.TxtFechaSalida3.Visible = False
        Me.TxtFechaSalida3.Width = 0.8800001!
        '
        'Label74
        '
        Me.Label74.Border.BottomColor = System.Drawing.Color.Black
        Me.Label74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label74.Border.LeftColor = System.Drawing.Color.Black
        Me.Label74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label74.Border.RightColor = System.Drawing.Color.Black
        Me.Label74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label74.Border.TopColor = System.Drawing.Color.Black
        Me.Label74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label74.Height = 0.16!
        Me.Label74.HyperLink = Nothing
        Me.Label74.Left = 8.24!
        Me.Label74.Name = "Label74"
        Me.Label74.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label74.Text = "Origen"
        Me.Label74.Top = 1.28!
        Me.Label74.Visible = False
        Me.Label74.Width = 0.48!
        '
        'Label75
        '
        Me.Label75.Border.BottomColor = System.Drawing.Color.Black
        Me.Label75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label75.Border.LeftColor = System.Drawing.Color.Black
        Me.Label75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label75.Border.RightColor = System.Drawing.Color.Black
        Me.Label75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label75.Border.TopColor = System.Drawing.Color.Black
        Me.Label75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label75.Height = 0.16!
        Me.Label75.HyperLink = Nothing
        Me.Label75.Left = 8.24!
        Me.Label75.Name = "Label75"
        Me.Label75.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; "
        Me.Label75.Text = "Destino"
        Me.Label75.Top = 1.44!
        Me.Label75.Visible = False
        Me.Label75.Width = 0.48!
        '
        'TxtOrigen3
        '
        Me.TxtOrigen3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtOrigen3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtOrigen3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtOrigen3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtOrigen3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigen3.Height = 0.16!
        Me.TxtOrigen3.Left = 8.8!
        Me.TxtOrigen3.Name = "TxtOrigen3"
        Me.TxtOrigen3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtOrigen3.Text = Nothing
        Me.TxtOrigen3.Top = 1.28!
        Me.TxtOrigen3.Visible = False
        Me.TxtOrigen3.Width = 2.0!
        '
        'TxtDestino3
        '
        Me.TxtDestino3.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtDestino3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino3.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtDestino3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino3.Border.RightColor = System.Drawing.Color.Black
        Me.TxtDestino3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino3.Border.TopColor = System.Drawing.Color.Black
        Me.TxtDestino3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtDestino3.Height = 0.16!
        Me.TxtDestino3.Left = 8.8!
        Me.TxtDestino3.Name = "TxtDestino3"
        Me.TxtDestino3.Style = "ddo-char-set: 0; font-size: 6.75pt; "
        Me.TxtDestino3.Text = Nothing
        Me.TxtDestino3.Top = 1.44!
        Me.TxtDestino3.Visible = False
        Me.TxtDestino3.Width = 2.0!
        '
        'Label40
        '
        Me.Label40.Border.BottomColor = System.Drawing.Color.Black
        Me.Label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.LeftColor = System.Drawing.Color.Black
        Me.Label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.RightColor = System.Drawing.Color.Black
        Me.Label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Border.TopColor = System.Drawing.Color.Black
        Me.Label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label40.Height = 0.175!
        Me.Label40.HyperLink = Nothing
        Me.Label40.Left = 8.375001!
        Me.Label40.Name = "Label40"
        Me.Label40.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; "
        Me.Label40.Text = "Origen"
        Me.Label40.Top = 1.025!
        Me.Label40.Width = 0.5249997!
        '
        'TxtOrigenRemision
        '
        Me.TxtOrigenRemision.Border.BottomColor = System.Drawing.Color.Black
        Me.TxtOrigenRemision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigenRemision.Border.LeftColor = System.Drawing.Color.Black
        Me.TxtOrigenRemision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigenRemision.Border.RightColor = System.Drawing.Color.Black
        Me.TxtOrigenRemision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigenRemision.Border.TopColor = System.Drawing.Color.Black
        Me.TxtOrigenRemision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TxtOrigenRemision.Height = 0.1750001!
        Me.TxtOrigenRemision.Left = 8.925!
        Me.TxtOrigenRemision.Name = "TxtOrigenRemision"
        Me.TxtOrigenRemision.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.TxtOrigenRemision.Text = Nothing
        Me.TxtOrigenRemision.Top = 1.0!
        Me.TxtOrigenRemision.Width = 1.85!
        '
        'ArepRemisionPergamino
        '
        Me.MasterReport = False
        OleDBDataSource1.ConnectionString = "Provider=SQLOLEDB.1;Password=P@ssword;Persist Security Info=True;User ID=sa;Initi" & _
            "al Catalog=TRANSPORTE;Data Source=JUANBERMUDEZ\SQL2014"
        OleDBDataSource1.SQL = resources.GetString("OleDBDataSource1.SQL")
        Me.DataSource = OleDBDataSource1
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.02!
        Me.PageSettings.Margins.Left = 0.02!
        Me.PageSettings.Margins.Right = 0.02!
        Me.PageSettings.Margins.Top = 0.2!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.93!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumeroRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantSacos1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoBruto1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoNeto1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantSacos2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoBruto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoNeto2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantSacos3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoBruto3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesoNeto3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantSacos33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantSacos22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCantSacos11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtListadoRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label65, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label67, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label68, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCompañia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTipoRemision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCosecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblNumeroRemision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrderNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEmpresaTransporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCantSaco1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPBRecepcion1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPBRemision1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCantSaco11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCantSaco2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPBRecepcion2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPBRemision2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCantSaco22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCantSaco3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPBRecepcion3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblP3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblPBRemision3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCantSaco33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmpTransp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPlaca1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtConductor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMarca1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCedConductor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaRecp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaCarga1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaSalida1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrigen1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDestino1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmpTransp2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPlaca2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtConductor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMarca2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCedConductor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaCarga2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaSalida2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrigen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDestino2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaRecp2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmpTransp3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPlaca3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label64, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label69, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label71, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label72, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label73, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtConductor3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMarca3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCedConductor3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaRecp3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaCarga3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFechaSalida3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label74, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label75, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrigen3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDestino3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrigenRemision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Label65 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtObservaciones As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label66 As DataDynamics.ActiveReports.Label
    Private WithEvents Label67 As DataDynamics.ActiveReports.Label
    Private WithEvents Label68 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtNumeroRecibos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantSacos1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoBruto1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoNeto1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantSacos2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoBruto2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoNeto2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantSacos3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoBruto3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtPesoNeto3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ImgLogo As DataDynamics.ActiveReports.Picture
    Friend WithEvents LblCompañia As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTipoRemision As DataDynamics.ActiveReports.Label
    Friend WithEvents LblCosecha As DataDynamics.ActiveReports.Label
    Friend WithEvents LblNumeroRemision As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderDate As DataDynamics.ActiveReports.Label
    Private WithEvents lblOrderNum As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label36 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblDescripcion As DataDynamics.ActiveReports.Label
    Private WithEvents Label38 As DataDynamics.ActiveReports.Label
    Private WithEvents Label42 As DataDynamics.ActiveReports.Label
    Private WithEvents Label43 As DataDynamics.ActiveReports.Label
    Private WithEvents Label44 As DataDynamics.ActiveReports.Label
    Private WithEvents Label39 As DataDynamics.ActiveReports.Label
    Private WithEvents Label46 As DataDynamics.ActiveReports.Label
    Private WithEvents Label47 As DataDynamics.ActiveReports.Label
    Private WithEvents Label49 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label48 As DataDynamics.ActiveReports.Label
    Private WithEvents Label45 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtCantSacos33 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantSacos22 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCantSacos11 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblEmpresaTransporte As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label6 As DataDynamics.ActiveReports.Label
    Private WithEvents Label8 As DataDynamics.ActiveReports.Label
    Private WithEvents Label9 As DataDynamics.ActiveReports.Label
    Private WithEvents Label10 As DataDynamics.ActiveReports.Label
    Private WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblConductor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblFechaOrden As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblFechaSalida As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label12 As DataDynamics.ActiveReports.Label
    Private WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblOrigen As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblDestino As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Private WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtEmpTransp1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtPlaca1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label17 As DataDynamics.ActiveReports.Label
    Private WithEvents Label18 As DataDynamics.ActiveReports.Label
    Private WithEvents Label19 As DataDynamics.ActiveReports.Label
    Private WithEvents Label20 As DataDynamics.ActiveReports.Label
    Private WithEvents Label21 As DataDynamics.ActiveReports.Label
    Private WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtConductor1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMarca1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCedConductor1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaRecp1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaCarga1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaSalida1 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label23 As DataDynamics.ActiveReports.Label
    Private WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtOrigen1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtDestino1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label25 As DataDynamics.ActiveReports.Label
    Private WithEvents Label26 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtEmpTransp2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label27 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtPlaca2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label28 As DataDynamics.ActiveReports.Label
    Private WithEvents Label29 As DataDynamics.ActiveReports.Label
    Private WithEvents Label30 As DataDynamics.ActiveReports.Label
    Private WithEvents Label31 As DataDynamics.ActiveReports.Label
    Private WithEvents Label32 As DataDynamics.ActiveReports.Label
    Private WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtConductor2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMarca2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCedConductor2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaCarga2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaSalida2 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label34 As DataDynamics.ActiveReports.Label
    Private WithEvents Label35 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtOrigen2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtDestino2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaRecp2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Private WithEvents Label37 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtEmpTransp3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label63 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtPlaca3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label64 As DataDynamics.ActiveReports.Label
    Private WithEvents Label69 As DataDynamics.ActiveReports.Label
    Private WithEvents Label70 As DataDynamics.ActiveReports.Label
    Private WithEvents Label71 As DataDynamics.ActiveReports.Label
    Private WithEvents Label72 As DataDynamics.ActiveReports.Label
    Private WithEvents Label73 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtConductor3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtMarca3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtCedConductor3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaRecp3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaCarga3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtFechaSalida3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label74 As DataDynamics.ActiveReports.Label
    Private WithEvents Label75 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtOrigen3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtDestino3 As DataDynamics.ActiveReports.TextBox
    Private WithEvents LblCantSaco1 As DataDynamics.ActiveReports.Label
    Private WithEvents LblPBRecepcion1 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblP1 As DataDynamics.ActiveReports.Label
    Private WithEvents LblPBRemision1 As DataDynamics.ActiveReports.Label
    Private WithEvents LblCantSaco11 As DataDynamics.ActiveReports.Label
    Private WithEvents LblCantSaco3 As DataDynamics.ActiveReports.Label
    Private WithEvents LblPBRecepcion3 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblP3 As DataDynamics.ActiveReports.Label
    Private WithEvents LblPBRemision3 As DataDynamics.ActiveReports.Label
    Private WithEvents LblCantSaco33 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtListadoRecibos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox12 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Private WithEvents LblCantSaco2 As DataDynamics.ActiveReports.Label
    Private WithEvents LblPBRecepcion2 As DataDynamics.ActiveReports.Label
    Friend WithEvents LblP2 As DataDynamics.ActiveReports.Label
    Private WithEvents LblPBRemision2 As DataDynamics.ActiveReports.Label
    Private WithEvents LblCantSaco22 As DataDynamics.ActiveReports.Label
    Private WithEvents Label40 As DataDynamics.ActiveReports.Label
    Friend WithEvents TxtOrigenRemision As DataDynamics.ActiveReports.TextBox
End Class
