<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecepcion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecepcion))
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.TxtNumeroRecibo = New System.Windows.Forms.TextBox
        Me.TxtSerie = New System.Windows.Forms.TextBox
        Me.CboTipoCafe = New System.Windows.Forms.ComboBox
        Me.TxtIdLocalidad = New System.Windows.Forms.TextBox
        Me.LblCosecha = New System.Windows.Forms.Label
        Me.LblSucursal = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.lblbdega = New System.Windows.Forms.Label
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.CboTipoDocumento = New System.Windows.Forms.ComboBox
        Me.CboTipoRecepcion = New System.Windows.Forms.ComboBox
        Me.lbltipo = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.CboPignorado = New System.Windows.Forms.ComboBox
        Me.ListBoxCertificados = New System.Windows.Forms.ListBox
        Me.LblPignorado = New System.Windows.Forms.Label
        Me.LblCertificado = New System.Windows.Forms.Label
        Me.TxtNumeroCedula = New System.Windows.Forms.MaskedTextBox
        Me.TxtFinca = New System.Windows.Forms.TextBox
        Me.CmdProductorManual = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.CboFinca = New System.Windows.Forms.ComboBox
        Me.Button14 = New System.Windows.Forms.Button
        Me.CboCodigoProveedor = New C1.Win.C1List.C1Combo
        Me.datosprov = New System.Windows.Forms.Label
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.lblnombre = New System.Windows.Forms.Label
        Me.lblproveedor = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.ChkRedondeo = New System.Windows.Forms.CheckBox
        Me.lblcedula = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CboConductor = New C1.Win.C1List.C1Combo
        Me.txtplaca = New System.Windows.Forms.TextBox
        Me.txtapellido = New System.Windows.Forms.TextBox
        Me.txtid = New System.Windows.Forms.TextBox
        Me.lblapellido = New System.Windows.Forms.Label
        Me.lblconductor = New System.Windows.Forms.Label
        Me.Grupo = New System.Windows.Forms.GroupBox
        Me.DtpHoraManual = New System.Windows.Forms.DateTimePicker
        Me.DtpFechaManual = New System.Windows.Forms.DateTimePicker
        Me.DTPFecha = New System.Windows.Forms.Label
        Me.LblHora = New System.Windows.Forms.Label
        Me.lbldatosre = New System.Windows.Forms.Label
        Me.OptExpasa = New System.Windows.Forms.RadioButton
        Me.OptMaquila = New System.Windows.Forms.RadioButton
        Me.TxtProveedor = New System.Windows.Forms.TextBox
        Me.TxtPila = New System.Windows.Forms.TextBox
        Me.TxtOrigen = New System.Windows.Forms.TextBox
        Me.TxtDia = New System.Windows.Forms.TextBox
        Me.TxtMes = New System.Windows.Forms.TextBox
        Me.TxtAno = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtobservaciones = New System.Windows.Forms.TextBox
        Me.TxtNumeroRecepcion = New System.Windows.Forms.TextBox
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CboCodigoBodega = New C1.Win.C1List.C1Combo
        Me.lblnumR = New System.Windows.Forms.Label
        Me.Eventos = New System.Windows.Forms.GroupBox
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.CmdConfirma = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtsubtotal = New System.Windows.Forms.TextBox
        Me.sp = New System.IO.Ports.SerialPort(Me.components)
        Me.LblEstado = New System.Windows.Forms.Label
        Me.LblPeso = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.CboLocalidad = New C1.Win.C1List.C1Combo
        Me.CboTipoIngresoBascula = New System.Windows.Forms.ComboBox
        Me.Button16 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.TxtImperfecion = New System.Windows.Forms.TextBox
        Me.TxtHumedad = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.CmdPesada = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.CboDaño = New System.Windows.Forms.ComboBox
        Me.CboEstado = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblLiquidar = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.CboLiquidarLocalidad = New C1.Win.C1List.C1Combo
        Me.CboTipoCompra = New System.Windows.Forms.ComboBox
        Me.CboTipoCalidad = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CboCategoria = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.CboIngresoBascula = New C1.Win.C1List.C1Combo
        Me.OptNinguno = New System.Windows.Forms.RadioButton
        Me.OptPreSeco = New System.Windows.Forms.RadioButton
        Me.OptMedioSeco = New System.Windows.Forms.RadioButton
        Me.OptOreado = New System.Windows.Forms.RadioButton
        Me.OptMojado = New System.Windows.Forms.RadioButton
        Me.OptHumedo = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxtLocalidad = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtEqOreado = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtOreadoReal = New System.Windows.Forms.TextBox
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label20 = New System.Windows.Forms.Label
        Me.CboEstadoDocumeto = New System.Windows.Forms.ComboBox
        Me.Button17 = New System.Windows.Forms.Button
        Me.Button18 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtPrecio = New System.Windows.Forms.TextBox
        Me.LblPrecio = New System.Windows.Forms.Label
        Me.CmdObservaciones = New System.Windows.Forms.Button
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Eventos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboLiquidarLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboIngresoBascula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox7.Controls.Add(Me.TxtNumeroRecibo)
        Me.GroupBox7.Controls.Add(Me.TxtSerie)
        Me.GroupBox7.Controls.Add(Me.CboTipoCafe)
        Me.GroupBox7.Controls.Add(Me.TxtIdLocalidad)
        Me.GroupBox7.Controls.Add(Me.LblCosecha)
        Me.GroupBox7.Controls.Add(Me.LblSucursal)
        Me.GroupBox7.Controls.Add(Me.Button5)
        Me.GroupBox7.Controls.Add(Me.lblbdega)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(988, 42)
        Me.GroupBox7.TabIndex = 6
        Me.GroupBox7.TabStop = False
        '
        'TxtNumeroRecibo
        '
        Me.TxtNumeroRecibo.Enabled = False
        Me.TxtNumeroRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroRecibo.Location = New System.Drawing.Point(869, 11)
        Me.TxtNumeroRecibo.Name = "TxtNumeroRecibo"
        Me.TxtNumeroRecibo.Size = New System.Drawing.Size(82, 26)
        Me.TxtNumeroRecibo.TabIndex = 236
        Me.TxtNumeroRecibo.Text = "-----0-----"
        '
        'TxtSerie
        '
        Me.TxtSerie.Enabled = False
        Me.TxtSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtSerie.Location = New System.Drawing.Point(786, 11)
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.Size = New System.Drawing.Size(37, 26)
        Me.TxtSerie.TabIndex = 235
        Me.TxtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboTipoCafe
        '
        Me.CboTipoCafe.DisplayMember = "Nombre"
        Me.CboTipoCafe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCafe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoCafe.FormattingEnabled = True
        Me.CboTipoCafe.Location = New System.Drawing.Point(8, 9)
        Me.CboTipoCafe.Name = "CboTipoCafe"
        Me.CboTipoCafe.Size = New System.Drawing.Size(147, 28)
        Me.CboTipoCafe.TabIndex = 234
        '
        'TxtIdLocalidad
        '
        Me.TxtIdLocalidad.Enabled = False
        Me.TxtIdLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIdLocalidad.Location = New System.Drawing.Point(826, 11)
        Me.TxtIdLocalidad.Name = "TxtIdLocalidad"
        Me.TxtIdLocalidad.Size = New System.Drawing.Size(37, 26)
        Me.TxtIdLocalidad.TabIndex = 187
        '
        'LblCosecha
        '
        Me.LblCosecha.AutoSize = True
        Me.LblCosecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCosecha.ForeColor = System.Drawing.Color.White
        Me.LblCosecha.Location = New System.Drawing.Point(474, 9)
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Size = New System.Drawing.Size(223, 25)
        Me.LblCosecha.TabIndex = 186
        Me.LblCosecha.Text = "Cosecha 2014-2015"
        '
        'LblSucursal
        '
        Me.LblSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblSucursal.AutoSize = True
        Me.LblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSucursal.ForeColor = System.Drawing.Color.White
        Me.LblSucursal.Location = New System.Drawing.Point(194, 10)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(253, 25)
        Me.LblSucursal.TabIndex = 185
        Me.LblSucursal.Text = "SUCURSAL JINOTEGA"
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(955, 9)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(29, 30)
        Me.Button5.TabIndex = 180
        Me.Button5.UseVisualStyleBackColor = True
        '
        'lblbdega
        '
        Me.lblbdega.AutoSize = True
        Me.lblbdega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbdega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblbdega.Location = New System.Drawing.Point(698, 16)
        Me.lblbdega.Name = "lblbdega"
        Me.lblbdega.Size = New System.Drawing.Size(79, 16)
        Me.lblbdega.TabIndex = 12
        Me.lblbdega.Text = "Nº Recibo"
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(1085, 376)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(125, 26)
        Me.TxtNumeroEnsamble.TabIndex = 177
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'CboTipoDocumento
        '
        Me.CboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoDocumento.FormattingEnabled = True
        Me.CboTipoDocumento.Items.AddRange(New Object() {"Manual", "Automatico", "Movil"})
        Me.CboTipoDocumento.Location = New System.Drawing.Point(1059, 288)
        Me.CboTipoDocumento.Name = "CboTipoDocumento"
        Me.CboTipoDocumento.Size = New System.Drawing.Size(157, 33)
        Me.CboTipoDocumento.TabIndex = 233
        Me.CboTipoDocumento.Visible = False
        '
        'CboTipoRecepcion
        '
        Me.CboTipoRecepcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoRecepcion.Enabled = False
        Me.CboTipoRecepcion.FormattingEnabled = True
        Me.CboTipoRecepcion.Items.AddRange(New Object() {"Recepcion", "RePesaje"})
        Me.CboTipoRecepcion.Location = New System.Drawing.Point(1064, 254)
        Me.CboTipoRecepcion.Name = "CboTipoRecepcion"
        Me.CboTipoRecepcion.Size = New System.Drawing.Size(135, 21)
        Me.CboTipoRecepcion.TabIndex = 179
        Me.CboTipoRecepcion.Visible = False
        '
        'lbltipo
        '
        Me.lbltipo.AutoSize = True
        Me.lbltipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lbltipo.Location = New System.Drawing.Point(1070, 295)
        Me.lbltipo.Name = "lbltipo"
        Me.lbltipo.Size = New System.Drawing.Size(35, 15)
        Me.lbltipo.TabIndex = 25
        Me.lbltipo.Text = "Tipo"
        Me.lbltipo.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.CboPignorado)
        Me.GroupBox6.Controls.Add(Me.ListBoxCertificados)
        Me.GroupBox6.Controls.Add(Me.LblPignorado)
        Me.GroupBox6.Controls.Add(Me.LblCertificado)
        Me.GroupBox6.Controls.Add(Me.TxtNumeroCedula)
        Me.GroupBox6.Controls.Add(Me.TxtFinca)
        Me.GroupBox6.Controls.Add(Me.CmdProductorManual)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.CboFinca)
        Me.GroupBox6.Controls.Add(Me.Button14)
        Me.GroupBox6.Controls.Add(Me.CboCodigoProveedor)
        Me.GroupBox6.Controls.Add(Me.datosprov)
        Me.GroupBox6.Controls.Add(Me.txtnombre)
        Me.GroupBox6.Controls.Add(Me.lblnombre)
        Me.GroupBox6.Controls.Add(Me.lblproveedor)
        Me.GroupBox6.Controls.Add(Me.Button2)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 43)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(735, 123)
        Me.GroupBox6.TabIndex = 176
        Me.GroupBox6.TabStop = False
        '
        'CboPignorado
        '
        Me.CboPignorado.DisplayMember = "Descripccion"
        Me.CboPignorado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPignorado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPignorado.FormattingEnabled = True
        Me.CboPignorado.Location = New System.Drawing.Point(524, 78)
        Me.CboPignorado.Name = "CboPignorado"
        Me.CboPignorado.Size = New System.Drawing.Size(205, 33)
        Me.CboPignorado.TabIndex = 244
        '
        'ListBoxCertificados
        '
        Me.ListBoxCertificados.FormattingEnabled = True
        Me.ListBoxCertificados.Location = New System.Drawing.Point(524, 16)
        Me.ListBoxCertificados.Name = "ListBoxCertificados"
        Me.ListBoxCertificados.Size = New System.Drawing.Size(205, 56)
        Me.ListBoxCertificados.TabIndex = 242
        '
        'LblPignorado
        '
        Me.LblPignorado.AutoSize = True
        Me.LblPignorado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPignorado.ForeColor = System.Drawing.Color.Yellow
        Me.LblPignorado.Location = New System.Drawing.Point(314, 29)
        Me.LblPignorado.Name = "LblPignorado"
        Me.LblPignorado.Size = New System.Drawing.Size(0, 18)
        Me.LblPignorado.TabIndex = 240
        Me.LblPignorado.Visible = False
        '
        'LblCertificado
        '
        Me.LblCertificado.AutoSize = True
        Me.LblCertificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCertificado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblCertificado.Location = New System.Drawing.Point(412, 91)
        Me.LblCertificado.Name = "LblCertificado"
        Me.LblCertificado.Size = New System.Drawing.Size(0, 20)
        Me.LblCertificado.TabIndex = 239
        Me.LblCertificado.Visible = False
        '
        'TxtNumeroCedula
        '
        Me.TxtNumeroCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroCedula.Location = New System.Drawing.Point(371, 90)
        Me.TxtNumeroCedula.Mask = "0000000000000>A"
        Me.TxtNumeroCedula.Name = "TxtNumeroCedula"
        Me.TxtNumeroCedula.Size = New System.Drawing.Size(147, 26)
        Me.TxtNumeroCedula.TabIndex = 238
        Me.TxtNumeroCedula.Visible = False
        '
        'TxtFinca
        '
        Me.TxtFinca.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFinca.Location = New System.Drawing.Point(64, 86)
        Me.TxtFinca.Name = "TxtFinca"
        Me.TxtFinca.Size = New System.Drawing.Size(282, 31)
        Me.TxtFinca.TabIndex = 237
        Me.TxtFinca.Visible = False
        '
        'CmdProductorManual
        '
        Me.CmdProductorManual.Image = CType(resources.GetObject("CmdProductorManual.Image"), System.Drawing.Image)
        Me.CmdProductorManual.Location = New System.Drawing.Point(388, 16)
        Me.CmdProductorManual.Name = "CmdProductorManual"
        Me.CmdProductorManual.Size = New System.Drawing.Size(69, 40)
        Me.CmdProductorManual.TabIndex = 236
        Me.CmdProductorManual.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(6, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 15)
        Me.Label19.TabIndex = 235
        Me.Label19.Text = "Finca"
        '
        'CboFinca
        '
        Me.CboFinca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFinca.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboFinca.FormattingEnabled = True
        Me.CboFinca.Location = New System.Drawing.Point(66, 86)
        Me.CboFinca.Name = "CboFinca"
        Me.CboFinca.Size = New System.Drawing.Size(280, 33)
        Me.CboFinca.TabIndex = 234
        '
        'Button14
        '
        Me.Button14.Image = CType(resources.GetObject("Button14.Image"), System.Drawing.Image)
        Me.Button14.Location = New System.Drawing.Point(248, 16)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(64, 40)
        Me.Button14.TabIndex = 184
        Me.Button14.UseVisualStyleBackColor = True
        '
        'CboCodigoProveedor
        '
        Me.CboCodigoProveedor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoProveedor.AlternatingRows = True
        Me.CboCodigoProveedor.Caption = ""
        Me.CboCodigoProveedor.CaptionHeight = 17
        Me.CboCodigoProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoProveedor.ColumnCaptionHeight = 17
        Me.CboCodigoProveedor.ColumnFooterHeight = 17
        Me.CboCodigoProveedor.ContentHeight = 26
        Me.CboCodigoProveedor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoProveedor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoProveedor.DropDownWidth = 300
        Me.CboCodigoProveedor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoProveedor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoProveedor.EditorHeight = 26
        Me.CboCodigoProveedor.Images.Add(CType(resources.GetObject("CboCodigoProveedor.Images"), System.Drawing.Image))
        Me.CboCodigoProveedor.ItemHeight = 35
        Me.CboCodigoProveedor.Location = New System.Drawing.Point(66, 24)
        Me.CboCodigoProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoProveedor.MaxLength = 32767
        Me.CboCodigoProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoProveedor.Name = "CboCodigoProveedor"
        Me.CboCodigoProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.Size = New System.Drawing.Size(172, 32)
        Me.CboCodigoProveedor.TabIndex = 183
        Me.CboCodigoProveedor.PropBag = resources.GetString("CboCodigoProveedor.PropBag")
        '
        'datosprov
        '
        Me.datosprov.AutoSize = True
        Me.datosprov.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datosprov.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.datosprov.Location = New System.Drawing.Point(44, -3)
        Me.datosprov.Name = "datosprov"
        Me.datosprov.Size = New System.Drawing.Size(206, 20)
        Me.datosprov.TabIndex = 25
        Me.datosprov.Text = "DATOS DEL PRODUCTOR"
        '
        'txtnombre
        '
        Me.txtnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(64, 59)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(338, 24)
        Me.txtnombre.TabIndex = 178
        '
        'lblnombre
        '
        Me.lblnombre.AutoSize = True
        Me.lblnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblnombre.Location = New System.Drawing.Point(4, 63)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(58, 15)
        Me.lblnombre.TabIndex = 174
        Me.lblnombre.Text = "Nombre"
        '
        'lblproveedor
        '
        Me.lblproveedor.AutoSize = True
        Me.lblproveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblproveedor.Location = New System.Drawing.Point(8, 29)
        Me.lblproveedor.Name = "lblproveedor"
        Me.lblproveedor.Size = New System.Drawing.Size(52, 15)
        Me.lblproveedor.TabIndex = 2
        Me.lblproveedor.Text = "Código"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(316, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 40)
        Me.Button2.TabIndex = 171
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ChkRedondeo
        '
        Me.ChkRedondeo.AutoSize = True
        Me.ChkRedondeo.Enabled = False
        Me.ChkRedondeo.Location = New System.Drawing.Point(1092, 523)
        Me.ChkRedondeo.Name = "ChkRedondeo"
        Me.ChkRedondeo.Size = New System.Drawing.Size(76, 17)
        Me.ChkRedondeo.TabIndex = 182
        Me.ChkRedondeo.Text = "Redondeo"
        Me.ChkRedondeo.UseVisualStyleBackColor = True
        Me.ChkRedondeo.Visible = False
        '
        'lblcedula
        '
        Me.lblcedula.AutoSize = True
        Me.lblcedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcedula.Location = New System.Drawing.Point(704, 933)
        Me.lblcedula.Name = "lblcedula"
        Me.lblcedula.Size = New System.Drawing.Size(52, 15)
        Me.lblcedula.TabIndex = 183
        Me.lblcedula.Text = "Cédula"
        Me.lblcedula.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(661, 956)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 15)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "Placa Camión"
        Me.Label2.Visible = False
        '
        'CboConductor
        '
        Me.CboConductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboConductor.Caption = ""
        Me.CboConductor.CaptionHeight = 17
        Me.CboConductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboConductor.ColumnCaptionHeight = 17
        Me.CboConductor.ColumnFooterHeight = 17
        Me.CboConductor.ContentHeight = 15
        Me.CboConductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboConductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboConductor.DropDownWidth = 300
        Me.CboConductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboConductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboConductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboConductor.EditorHeight = 15
        Me.CboConductor.Images.Add(CType(resources.GetObject("CboConductor.Images"), System.Drawing.Image))
        Me.CboConductor.ItemHeight = 15
        Me.CboConductor.Location = New System.Drawing.Point(759, 909)
        Me.CboConductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboConductor.MaxDropDownItems = CType(5, Short)
        Me.CboConductor.MaxLength = 32767
        Me.CboConductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboConductor.Name = "CboConductor"
        Me.CboConductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboConductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboConductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboConductor.Size = New System.Drawing.Size(174, 21)
        Me.CboConductor.TabIndex = 181
        Me.CboConductor.Text = "001"
        Me.CboConductor.Visible = False
        Me.CboConductor.PropBag = resources.GetString("CboConductor.PropBag")
        '
        'txtplaca
        '
        Me.txtplaca.Location = New System.Drawing.Point(759, 951)
        Me.txtplaca.Name = "txtplaca"
        Me.txtplaca.Size = New System.Drawing.Size(174, 20)
        Me.txtplaca.TabIndex = 13
        Me.txtplaca.Text = "001"
        Me.txtplaca.Visible = False
        '
        'txtapellido
        '
        Me.txtapellido.Location = New System.Drawing.Point(759, 888)
        Me.txtapellido.Name = "txtapellido"
        Me.txtapellido.Size = New System.Drawing.Size(172, 20)
        Me.txtapellido.TabIndex = 179
        Me.txtapellido.Text = "001"
        Me.txtapellido.Visible = False
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(759, 930)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(172, 20)
        Me.txtid.TabIndex = 11
        Me.txtid.Text = "001"
        Me.txtid.Visible = False
        '
        'lblapellido
        '
        Me.lblapellido.AutoSize = True
        Me.lblapellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblapellido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblapellido.Location = New System.Drawing.Point(721, 889)
        Me.lblapellido.Name = "lblapellido"
        Me.lblapellido.Size = New System.Drawing.Size(32, 15)
        Me.lblapellido.TabIndex = 175
        Me.lblapellido.Text = "Pila"
        Me.lblapellido.Visible = False
        '
        'lblconductor
        '
        Me.lblconductor.AutoSize = True
        Me.lblconductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconductor.Location = New System.Drawing.Point(687, 911)
        Me.lblconductor.Name = "lblconductor"
        Me.lblconductor.Size = New System.Drawing.Size(72, 15)
        Me.lblconductor.TabIndex = 6
        Me.lblconductor.Text = "Conductor"
        Me.lblconductor.Visible = False
        '
        'Grupo
        '
        Me.Grupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Grupo.Controls.Add(Me.DtpHoraManual)
        Me.Grupo.Controls.Add(Me.DtpFechaManual)
        Me.Grupo.Controls.Add(Me.DTPFecha)
        Me.Grupo.Controls.Add(Me.LblHora)
        Me.Grupo.Controls.Add(Me.lbldatosre)
        Me.Grupo.Location = New System.Drawing.Point(745, 43)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(249, 123)
        Me.Grupo.TabIndex = 177
        Me.Grupo.TabStop = False
        '
        'DtpHoraManual
        '
        Me.DtpHoraManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpHoraManual.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpHoraManual.Location = New System.Drawing.Point(20, 74)
        Me.DtpHoraManual.Name = "DtpHoraManual"
        Me.DtpHoraManual.Size = New System.Drawing.Size(188, 35)
        Me.DtpHoraManual.TabIndex = 184
        '
        'DtpFechaManual
        '
        Me.DtpFechaManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaManual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaManual.Location = New System.Drawing.Point(21, 31)
        Me.DtpFechaManual.Name = "DtpFechaManual"
        Me.DtpFechaManual.Size = New System.Drawing.Size(188, 35)
        Me.DtpFechaManual.TabIndex = 183
        '
        'DTPFecha
        '
        Me.DTPFecha.AutoSize = True
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.DTPFecha.Location = New System.Drawing.Point(14, 31)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(169, 33)
        Me.DTPFecha.TabIndex = 182
        Me.DTPFecha.Text = "20/10/2017"
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblHora.Location = New System.Drawing.Point(14, 76)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(205, 33)
        Me.LblHora.TabIndex = 181
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'lbldatosre
        '
        Me.lbldatosre.AutoSize = True
        Me.lbldatosre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatosre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lbldatosre.Location = New System.Drawing.Point(35, -2)
        Me.lbldatosre.Name = "lbldatosre"
        Me.lbldatosre.Size = New System.Drawing.Size(189, 20)
        Me.lbldatosre.TabIndex = 176
        Me.lbldatosre.Text = "DATOS DE RECEPCION"
        '
        'OptExpasa
        '
        Me.OptExpasa.AutoSize = True
        Me.OptExpasa.Checked = True
        Me.OptExpasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptExpasa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.OptExpasa.Location = New System.Drawing.Point(6, 36)
        Me.OptExpasa.Name = "OptExpasa"
        Me.OptExpasa.Size = New System.Drawing.Size(176, 33)
        Me.OptExpasa.TabIndex = 178
        Me.OptExpasa.TabStop = True
        Me.OptExpasa.Text = "PERGAMINO"
        Me.OptExpasa.UseVisualStyleBackColor = True
        '
        'OptMaquila
        '
        Me.OptMaquila.AutoSize = True
        Me.OptMaquila.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptMaquila.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.OptMaquila.Location = New System.Drawing.Point(7, 10)
        Me.OptMaquila.Name = "OptMaquila"
        Me.OptMaquila.Size = New System.Drawing.Size(136, 33)
        Me.OptMaquila.TabIndex = 177
        Me.OptMaquila.Text = "MAQUILA"
        Me.OptMaquila.UseVisualStyleBackColor = True
        '
        'TxtProveedor
        '
        Me.TxtProveedor.Enabled = False
        Me.TxtProveedor.Location = New System.Drawing.Point(718, 732)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(30, 20)
        Me.TxtProveedor.TabIndex = 195
        Me.TxtProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtProveedor.Visible = False
        '
        'TxtPila
        '
        Me.TxtPila.Enabled = False
        Me.TxtPila.Location = New System.Drawing.Point(1428, 117)
        Me.TxtPila.Name = "TxtPila"
        Me.TxtPila.Size = New System.Drawing.Size(30, 20)
        Me.TxtPila.TabIndex = 194
        Me.TxtPila.Text = "001"
        Me.TxtPila.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtPila.Visible = False
        '
        'TxtOrigen
        '
        Me.TxtOrigen.Enabled = False
        Me.TxtOrigen.Location = New System.Drawing.Point(749, 732)
        Me.TxtOrigen.Name = "TxtOrigen"
        Me.TxtOrigen.Size = New System.Drawing.Size(30, 20)
        Me.TxtOrigen.TabIndex = 193
        Me.TxtOrigen.Text = "001"
        Me.TxtOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtOrigen.Visible = False
        '
        'TxtDia
        '
        Me.TxtDia.Enabled = False
        Me.TxtDia.Location = New System.Drawing.Point(686, 732)
        Me.TxtDia.Name = "TxtDia"
        Me.TxtDia.Size = New System.Drawing.Size(30, 20)
        Me.TxtDia.TabIndex = 192
        Me.TxtDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtDia.Visible = False
        '
        'TxtMes
        '
        Me.TxtMes.Enabled = False
        Me.TxtMes.Location = New System.Drawing.Point(654, 732)
        Me.TxtMes.Name = "TxtMes"
        Me.TxtMes.Size = New System.Drawing.Size(30, 20)
        Me.TxtMes.TabIndex = 191
        Me.TxtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtMes.Visible = False
        '
        'TxtAno
        '
        Me.TxtAno.Enabled = False
        Me.TxtAno.Location = New System.Drawing.Point(622, 732)
        Me.TxtAno.Name = "TxtAno"
        Me.TxtAno.Size = New System.Drawing.Size(30, 20)
        Me.TxtAno.TabIndex = 190
        Me.TxtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtAno.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(573, 736)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 15)
        Me.Label5.TabIndex = 189
        Me.Label5.Text = "Lote"
        Me.Label5.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtobservaciones)
        Me.GroupBox4.Location = New System.Drawing.Point(749, 727)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(268, 56)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Observaciones"
        Me.GroupBox4.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 189
        Me.Label4.Text = "Rec Bin"
        Me.Label4.Visible = False
        '
        'txtobservaciones
        '
        Me.txtobservaciones.Location = New System.Drawing.Point(31, 12)
        Me.txtobservaciones.Multiline = True
        Me.txtobservaciones.Name = "txtobservaciones"
        Me.txtobservaciones.Size = New System.Drawing.Size(255, 35)
        Me.txtobservaciones.TabIndex = 12
        '
        'TxtNumeroRecepcion
        '
        Me.TxtNumeroRecepcion.Enabled = False
        Me.TxtNumeroRecepcion.Location = New System.Drawing.Point(1080, 408)
        Me.TxtNumeroRecepcion.Name = "TxtNumeroRecepcion"
        Me.TxtNumeroRecepcion.Size = New System.Drawing.Size(130, 20)
        Me.TxtNumeroRecepcion.TabIndex = 190
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(1000, 672)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(130, 20)
        Me.TxtCodigo.TabIndex = 187
        Me.TxtCodigo.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(663, 825)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 186
        Me.Label3.Text = "Jalar BIN"
        Me.Label3.Visible = False
        '
        'CboCodigoBodega
        '
        Me.CboCodigoBodega.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoBodega.Caption = ""
        Me.CboCodigoBodega.CaptionHeight = 17
        Me.CboCodigoBodega.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoBodega.ColumnCaptionHeight = 17
        Me.CboCodigoBodega.ColumnFooterHeight = 17
        Me.CboCodigoBodega.ContentHeight = 15
        Me.CboCodigoBodega.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoBodega.DisplayMember = "Nombre_Bodega"
        Me.CboCodigoBodega.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoBodega.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoBodega.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoBodega.EditorHeight = 15
        Me.CboCodigoBodega.Images.Add(CType(resources.GetObject("CboCodigoBodega.Images"), System.Drawing.Image))
        Me.CboCodigoBodega.ItemHeight = 15
        Me.CboCodigoBodega.Location = New System.Drawing.Point(738, 795)
        Me.CboCodigoBodega.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoBodega.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoBodega.MaxLength = 32767
        Me.CboCodigoBodega.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoBodega.Name = "CboCodigoBodega"
        Me.CboCodigoBodega.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoBodega.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoBodega.Size = New System.Drawing.Size(195, 21)
        Me.CboCodigoBodega.TabIndex = 172
        Me.CboCodigoBodega.Text = "001"
        Me.CboCodigoBodega.Visible = False
        Me.CboCodigoBodega.PropBag = resources.GetString("CboCodigoBodega.PropBag")
        '
        'lblnumR
        '
        Me.lblnumR.AutoSize = True
        Me.lblnumR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnumR.Location = New System.Drawing.Point(628, 794)
        Me.lblnumR.Name = "lblnumR"
        Me.lblnumR.Size = New System.Drawing.Size(105, 15)
        Me.lblnumR.TabIndex = 32
        Me.lblnumR.Text = "Código Bodega"
        Me.lblnumR.Visible = False
        '
        'Eventos
        '
        Me.Eventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Eventos.Controls.Add(Me.CmdNuevo)
        Me.Eventos.Controls.Add(Me.CmdConfirma)
        Me.Eventos.Controls.Add(Me.Button10)
        Me.Eventos.Controls.Add(Me.Button7)
        Me.Eventos.Controls.Add(Me.Button11)
        Me.Eventos.Location = New System.Drawing.Point(7, 592)
        Me.Eventos.Name = "Eventos"
        Me.Eventos.Size = New System.Drawing.Size(620, 80)
        Me.Eventos.TabIndex = 178
        Me.Eventos.TabStop = False
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.CmdNuevo.Image = Global.Remisiones.My.Resources.Resources.New48__2_1
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdNuevo.Location = New System.Drawing.Point(13, 13)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(114, 56)
        Me.CmdNuevo.TabIndex = 228
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'CmdConfirma
        '
        Me.CmdConfirma.Enabled = False
        Me.CmdConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdConfirma.Image = CType(resources.GetObject("CmdConfirma.Image"), System.Drawing.Image)
        Me.CmdConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdConfirma.Location = New System.Drawing.Point(253, 12)
        Me.CmdConfirma.Name = "CmdConfirma"
        Me.CmdConfirma.Size = New System.Drawing.Size(114, 56)
        Me.CmdConfirma.TabIndex = 216
        Me.CmdConfirma.Text = "Confirma"
        Me.CmdConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdConfirma.UseVisualStyleBackColor = True
        Me.CmdConfirma.Visible = False
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(490, 14)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(114, 56)
        Me.Button10.TabIndex = 215
        Me.Button10.Text = "Des-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Conectar"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(133, 12)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(114, 56)
        Me.Button7.TabIndex = 179
        Me.Button7.Text = "Grabar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Image = CType(resources.GetObject("Button11.Image"), System.Drawing.Image)
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.Location = New System.Drawing.Point(371, 13)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(114, 56)
        Me.Button11.TabIndex = 214
        Me.Button11.Text = "Conectar"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(796, 569)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 20)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "SubTotal"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.Enabled = False
        Me.txtsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.Location = New System.Drawing.Point(888, 565)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(105, 26)
        Me.txtsubtotal.TabIndex = 210
        '
        'sp
        '
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstado.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.LblEstado.Location = New System.Drawing.Point(854, 674)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(137, 24)
        Me.LblEstado.TabIndex = 217
        Me.LblEstado.Text = "DESCONECT"
        '
        'LblPeso
        '
        Me.LblPeso.AutoSize = True
        Me.LblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeso.ForeColor = System.Drawing.Color.Maroon
        Me.LblPeso.Location = New System.Drawing.Point(944, 538)
        Me.LblPeso.Name = "LblPeso"
        Me.LblPeso.Size = New System.Drawing.Size(49, 24)
        Me.LblPeso.TabIndex = 218
        Me.LblPeso.Text = "0.00"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.CboLocalidad)
        Me.GroupBox1.Controls.Add(Me.CboTipoIngresoBascula)
        Me.GroupBox1.Controls.Add(Me.Button16)
        Me.GroupBox1.Controls.Add(Me.Button15)
        Me.GroupBox1.Controls.Add(Me.TxtImperfecion)
        Me.GroupBox1.Controls.Add(Me.TxtHumedad)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.CmdPesada)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.CboDaño)
        Me.GroupBox1.Controls.Add(Me.CboEstado)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.LblLiquidar)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.CboLiquidarLocalidad)
        Me.GroupBox1.Controls.Add(Me.CboTipoCompra)
        Me.GroupBox1.Controls.Add(Me.CboTipoCalidad)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.CboCategoria)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 165)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(827, 183)
        Me.GroupBox1.TabIndex = 220
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(665, 138)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 23)
        Me.Button1.TabIndex = 255
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CboLocalidad
        '
        Me.CboLocalidad.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboLocalidad.AlternatingRows = True
        Me.CboLocalidad.Caption = ""
        Me.CboLocalidad.CaptionHeight = 17
        Me.CboLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboLocalidad.ColumnCaptionHeight = 17
        Me.CboLocalidad.ColumnFooterHeight = 17
        Me.CboLocalidad.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboLocalidad.ContentHeight = 33
        Me.CboLocalidad.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboLocalidad.DisplayMember = "NomLugarAcopio"
        Me.CboLocalidad.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboLocalidad.DropDownWidth = 600
        Me.CboLocalidad.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboLocalidad.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboLocalidad.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboLocalidad.EditorHeight = 33
        Me.CboLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboLocalidad.Images.Add(CType(resources.GetObject("CboLocalidad.Images"), System.Drawing.Image))
        Me.CboLocalidad.ItemHeight = 35
        Me.CboLocalidad.Location = New System.Drawing.Point(110, 11)
        Me.CboLocalidad.MatchEntryTimeout = CType(2000, Long)
        Me.CboLocalidad.MaxDropDownItems = CType(6, Short)
        Me.CboLocalidad.MaxLength = 32767
        Me.CboLocalidad.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboLocalidad.Name = "CboLocalidad"
        Me.CboLocalidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboLocalidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboLocalidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboLocalidad.Size = New System.Drawing.Size(273, 39)
        Me.CboLocalidad.TabIndex = 240
        Me.CboLocalidad.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.CboLocalidad.PropBag = resources.GetString("CboLocalidad.PropBag")
        '
        'CboTipoIngresoBascula
        '
        Me.CboTipoIngresoBascula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoIngresoBascula.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoIngresoBascula.FormattingEnabled = True
        Me.CboTipoIngresoBascula.Items.AddRange(New Object() {"Manual", "Automatico", "Movil"})
        Me.CboTipoIngresoBascula.Location = New System.Drawing.Point(110, 91)
        Me.CboTipoIngresoBascula.Name = "CboTipoIngresoBascula"
        Me.CboTipoIngresoBascula.Size = New System.Drawing.Size(276, 33)
        Me.CboTipoIngresoBascula.TabIndex = 239
        '
        'Button16
        '
        Me.Button16.Enabled = False
        Me.Button16.Image = CType(resources.GetObject("Button16.Image"), System.Drawing.Image)
        Me.Button16.Location = New System.Drawing.Point(388, 129)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(35, 40)
        Me.Button16.TabIndex = 238
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.Location = New System.Drawing.Point(388, 14)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(35, 38)
        Me.Button15.TabIndex = 237
        Me.Button15.UseVisualStyleBackColor = True
        '
        'TxtImperfecion
        '
        Me.TxtImperfecion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImperfecion.Location = New System.Drawing.Point(725, 56)
        Me.TxtImperfecion.Name = "TxtImperfecion"
        Me.TxtImperfecion.Size = New System.Drawing.Size(97, 31)
        Me.TxtImperfecion.TabIndex = 236
        Me.ToolTip.SetToolTip(Me.TxtImperfecion, "JUAN2")
        '
        'TxtHumedad
        '
        Me.TxtHumedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHumedad.Location = New System.Drawing.Point(725, 19)
        Me.TxtHumedad.Name = "TxtHumedad"
        Me.TxtHumedad.Size = New System.Drawing.Size(98, 31)
        Me.TxtHumedad.TabIndex = 235
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(669, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 20)
        Me.Label15.TabIndex = 234
        Me.Label15.Text = "%IMP"
        '
        'CmdPesada
        '
        Me.CmdPesada.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPesada.Image = CType(resources.GetObject("CmdPesada.Image"), System.Drawing.Image)
        Me.CmdPesada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPesada.Location = New System.Drawing.Point(708, 97)
        Me.CmdPesada.Name = "CmdPesada"
        Me.CmdPesada.Size = New System.Drawing.Size(114, 52)
        Me.CmdPesada.TabIndex = 236
        Me.CmdPesada.Text = "Pesada"
        Me.CmdPesada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPesada.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(659, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 20)
        Me.Label14.TabIndex = 232
        Me.Label14.Text = "%HUM"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(6, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 20)
        Me.Label18.TabIndex = 234
        Me.Label18.Text = "LOCALIDAD"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(456, 139)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 20)
        Me.Label13.TabIndex = 230
        Me.Label13.Text = "DAÑO"
        '
        'CboDaño
        '
        Me.CboDaño.DisplayMember = "Nombre"
        Me.CboDaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDaño.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDaño.FormattingEnabled = True
        Me.CboDaño.Location = New System.Drawing.Point(512, 131)
        Me.CboDaño.Name = "CboDaño"
        Me.CboDaño.Size = New System.Drawing.Size(147, 33)
        Me.CboDaño.TabIndex = 229
        '
        'CboEstado
        '
        Me.CboEstado.DisplayMember = "Descripcion"
        Me.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEstado.FormattingEnabled = True
        Me.CboEstado.Location = New System.Drawing.Point(512, 94)
        Me.CboEstado.Name = "CboEstado"
        Me.CboEstado.Size = New System.Drawing.Size(147, 33)
        Me.CboEstado.TabIndex = 194
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(452, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 20)
        Me.Label11.TabIndex = 193
        Me.Label11.Text = "ESTDO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(8, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 20)
        Me.Label10.TabIndex = 192
        Me.Label10.Text = "COMPRA"
        '
        'LblLiquidar
        '
        Me.LblLiquidar.AutoSize = True
        Me.LblLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLiquidar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblLiquidar.Location = New System.Drawing.Point(11, 136)
        Me.LblLiquidar.Name = "LblLiquidar"
        Me.LblLiquidar.Size = New System.Drawing.Size(87, 20)
        Me.LblLiquidar.TabIndex = 195
        Me.LblLiquidar.Text = "LIQUIDAR"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(9, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 191
        Me.Label9.Text = "INGRESO"
        '
        'CboLiquidarLocalidad
        '
        Me.CboLiquidarLocalidad.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboLiquidarLocalidad.AlternatingRows = True
        Me.CboLiquidarLocalidad.Caption = ""
        Me.CboLiquidarLocalidad.CaptionHeight = 17
        Me.CboLiquidarLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboLiquidarLocalidad.ColumnCaptionHeight = 17
        Me.CboLiquidarLocalidad.ColumnFooterHeight = 17
        Me.CboLiquidarLocalidad.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboLiquidarLocalidad.ContentHeight = 33
        Me.CboLiquidarLocalidad.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboLiquidarLocalidad.DisplayMember = "NomLugarAcopio"
        Me.CboLiquidarLocalidad.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboLiquidarLocalidad.DropDownWidth = 600
        Me.CboLiquidarLocalidad.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboLiquidarLocalidad.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboLiquidarLocalidad.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboLiquidarLocalidad.EditorHeight = 33
        Me.CboLiquidarLocalidad.Enabled = False
        Me.CboLiquidarLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboLiquidarLocalidad.Images.Add(CType(resources.GetObject("CboLiquidarLocalidad.Images"), System.Drawing.Image))
        Me.CboLiquidarLocalidad.ItemHeight = 35
        Me.CboLiquidarLocalidad.Location = New System.Drawing.Point(109, 130)
        Me.CboLiquidarLocalidad.MatchEntryTimeout = CType(2000, Long)
        Me.CboLiquidarLocalidad.MaxDropDownItems = CType(6, Short)
        Me.CboLiquidarLocalidad.MaxLength = 32767
        Me.CboLiquidarLocalidad.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboLiquidarLocalidad.Name = "CboLiquidarLocalidad"
        Me.CboLiquidarLocalidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboLiquidarLocalidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboLiquidarLocalidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboLiquidarLocalidad.Size = New System.Drawing.Size(277, 39)
        Me.CboLiquidarLocalidad.TabIndex = 228
        Me.CboLiquidarLocalidad.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.CboLiquidarLocalidad.PropBag = resources.GetString("CboLiquidarLocalidad.PropBag")
        '
        'CboTipoCompra
        '
        Me.CboTipoCompra.DisplayMember = "Nombre"
        Me.CboTipoCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoCompra.FormattingEnabled = True
        Me.CboTipoCompra.Location = New System.Drawing.Point(109, 53)
        Me.CboTipoCompra.Name = "CboTipoCompra"
        Me.CboTipoCompra.Size = New System.Drawing.Size(276, 33)
        Me.CboTipoCompra.TabIndex = 189
        '
        'CboTipoCalidad
        '
        Me.CboTipoCalidad.DisplayMember = "NomCalidad"
        Me.CboTipoCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoCalidad.FormattingEnabled = True
        Me.CboTipoCalidad.Location = New System.Drawing.Point(511, 21)
        Me.CboTipoCalidad.Name = "CboTipoCalidad"
        Me.CboTipoCalidad.Size = New System.Drawing.Size(147, 33)
        Me.CboTipoCalidad.TabIndex = 188
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(429, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 187
        Me.Label8.Text = "CALIDAD"
        '
        'CboCategoria
        '
        Me.CboCategoria.DisplayMember = "Nombre"
        Me.CboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCategoria.Enabled = False
        Me.CboCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCategoria.FormattingEnabled = True
        Me.CboCategoria.Location = New System.Drawing.Point(512, 57)
        Me.CboCategoria.Name = "CboCategoria"
        Me.CboCategoria.Size = New System.Drawing.Size(147, 33)
        Me.CboCategoria.TabIndex = 185
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(405, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 20)
        Me.Label7.TabIndex = 184
        Me.Label7.Text = "CATEGORIA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(1049, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 20)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "TIPO DE CAFE"
        Me.Label6.Visible = False
        '
        'CboIngresoBascula
        '
        Me.CboIngresoBascula.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboIngresoBascula.AlternatingRows = True
        Me.CboIngresoBascula.Caption = ""
        Me.CboIngresoBascula.CaptionHeight = 17
        Me.CboIngresoBascula.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboIngresoBascula.ColumnCaptionHeight = 17
        Me.CboIngresoBascula.ColumnFooterHeight = 17
        Me.CboIngresoBascula.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboIngresoBascula.ContentHeight = 33
        Me.CboIngresoBascula.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboIngresoBascula.DisplayMember = "Descripcion_Producto"
        Me.CboIngresoBascula.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboIngresoBascula.DropDownWidth = 600
        Me.CboIngresoBascula.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboIngresoBascula.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboIngresoBascula.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboIngresoBascula.EditorHeight = 33
        Me.CboIngresoBascula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboIngresoBascula.Images.Add(CType(resources.GetObject("CboIngresoBascula.Images"), System.Drawing.Image))
        Me.CboIngresoBascula.ItemHeight = 35
        Me.CboIngresoBascula.Location = New System.Drawing.Point(1037, 24)
        Me.CboIngresoBascula.MatchEntryTimeout = CType(2000, Long)
        Me.CboIngresoBascula.MaxDropDownItems = CType(6, Short)
        Me.CboIngresoBascula.MaxLength = 32767
        Me.CboIngresoBascula.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboIngresoBascula.Name = "CboIngresoBascula"
        Me.CboIngresoBascula.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboIngresoBascula.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboIngresoBascula.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboIngresoBascula.Size = New System.Drawing.Size(328, 39)
        Me.CboIngresoBascula.TabIndex = 181
        Me.CboIngresoBascula.Visible = False
        Me.CboIngresoBascula.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.CboIngresoBascula.PropBag = resources.GetString("CboIngresoBascula.PropBag")
        '
        'OptNinguno
        '
        Me.OptNinguno.AutoSize = True
        Me.OptNinguno.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptNinguno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.OptNinguno.Location = New System.Drawing.Point(1052, 197)
        Me.OptNinguno.Name = "OptNinguno"
        Me.OptNinguno.Size = New System.Drawing.Size(116, 28)
        Me.OptNinguno.TabIndex = 191
        Me.OptNinguno.Text = "NINGUNO"
        Me.OptNinguno.UseVisualStyleBackColor = True
        Me.OptNinguno.Visible = False
        '
        'OptPreSeco
        '
        Me.OptPreSeco.AutoSize = True
        Me.OptPreSeco.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptPreSeco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.OptPreSeco.Location = New System.Drawing.Point(1052, 169)
        Me.OptPreSeco.Name = "OptPreSeco"
        Me.OptPreSeco.Size = New System.Drawing.Size(124, 28)
        Me.OptPreSeco.TabIndex = 190
        Me.OptPreSeco.Text = "PRE SECO"
        Me.OptPreSeco.UseVisualStyleBackColor = True
        Me.OptPreSeco.Visible = False
        '
        'OptMedioSeco
        '
        Me.OptMedioSeco.AutoSize = True
        Me.OptMedioSeco.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptMedioSeco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.OptMedioSeco.Location = New System.Drawing.Point(1052, 142)
        Me.OptMedioSeco.Name = "OptMedioSeco"
        Me.OptMedioSeco.Size = New System.Drawing.Size(147, 28)
        Me.OptMedioSeco.TabIndex = 189
        Me.OptMedioSeco.Text = "MEDIO SECO"
        Me.OptMedioSeco.UseVisualStyleBackColor = True
        Me.OptMedioSeco.Visible = False
        '
        'OptOreado
        '
        Me.OptOreado.AutoSize = True
        Me.OptOreado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptOreado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.OptOreado.Location = New System.Drawing.Point(1206, 202)
        Me.OptOreado.Name = "OptOreado"
        Me.OptOreado.Size = New System.Drawing.Size(110, 28)
        Me.OptOreado.TabIndex = 186
        Me.OptOreado.Text = "OREADO"
        Me.OptOreado.UseVisualStyleBackColor = True
        Me.OptOreado.Visible = False
        '
        'OptMojado
        '
        Me.OptMojado.AutoSize = True
        Me.OptMojado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptMojado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.OptMojado.Location = New System.Drawing.Point(1205, 170)
        Me.OptMojado.Name = "OptMojado"
        Me.OptMojado.Size = New System.Drawing.Size(109, 28)
        Me.OptMojado.TabIndex = 180
        Me.OptMojado.Text = "MOJADO"
        Me.OptMojado.UseVisualStyleBackColor = True
        Me.OptMojado.Visible = False
        '
        'OptHumedo
        '
        Me.OptHumedo.AutoSize = True
        Me.OptHumedo.Checked = True
        Me.OptHumedo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptHumedo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.OptHumedo.Location = New System.Drawing.Point(52, 66)
        Me.OptHumedo.Name = "OptHumedo"
        Me.OptHumedo.Size = New System.Drawing.Size(112, 28)
        Me.OptHumedo.TabIndex = 179
        Me.OptHumedo.TabStop = True
        Me.OptHumedo.Text = "HUMEDO"
        Me.OptHumedo.UseVisualStyleBackColor = True
        Me.OptHumedo.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.OptExpasa)
        Me.GroupBox3.Controls.Add(Me.OptMaquila)
        Me.GroupBox3.Controls.Add(Me.OptHumedo)
        Me.GroupBox3.Location = New System.Drawing.Point(1052, 59)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(185, 72)
        Me.GroupBox3.TabIndex = 222
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Location = New System.Drawing.Point(420, 749)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(100, 20)
        Me.TxtLocalidad.TabIndex = 224
        Me.TxtLocalidad.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Button12)
        Me.GroupBox8.Controls.Add(Me.Button9)
        Me.GroupBox8.Controls.Add(Me.Button4)
        Me.GroupBox8.Location = New System.Drawing.Point(633, 592)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(375, 79)
        Me.GroupBox8.TabIndex = 226
        Me.GroupBox8.TabStop = False
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button12.Location = New System.Drawing.Point(10, 14)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(114, 57)
        Me.Button12.TabIndex = 216
        Me.Button12.Text = "Ticket"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(249, 14)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(114, 55)
        Me.Button9.TabIndex = 184
        Me.Button9.Text = "Salir"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(129, 14)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(114, 55)
        Me.Button4.TabIndex = 183
        Me.Button4.Text = "Reporte"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(1037, 350)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 228
        Me.DateTimePicker1.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(306, 568)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 20)
        Me.Label16.TabIndex = 230
        Me.Label16.Text = "Eq.Oreado"
        '
        'TxtEqOreado
        '
        Me.TxtEqOreado.Enabled = False
        Me.TxtEqOreado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEqOreado.Location = New System.Drawing.Point(407, 565)
        Me.TxtEqOreado.Name = "TxtEqOreado"
        Me.TxtEqOreado.Size = New System.Drawing.Size(105, 26)
        Me.TxtEqOreado.TabIndex = 229
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(523, 569)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(110, 20)
        Me.Label17.TabIndex = 232
        Me.Label17.Text = "Oreado Real"
        '
        'TxtOreadoReal
        '
        Me.TxtOreadoReal.Enabled = False
        Me.TxtOreadoReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOreadoReal.Location = New System.Drawing.Point(633, 564)
        Me.TxtOreadoReal.Name = "TxtOreadoReal"
        Me.TxtOreadoReal.Size = New System.Drawing.Size(105, 26)
        Me.TxtOreadoReal.TabIndex = 231
        '
        'ToolTip
        '
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(846, 220)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(123, 20)
        Me.Label20.TabIndex = 238
        Me.Label20.Text = "ESTADO DCTO"
        '
        'CboEstadoDocumeto
        '
        Me.CboEstadoDocumeto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstadoDocumeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEstadoDocumeto.FormattingEnabled = True
        Me.CboEstadoDocumeto.Location = New System.Drawing.Point(840, 245)
        Me.CboEstadoDocumeto.Name = "CboEstadoDocumeto"
        Me.CboEstadoDocumeto.Size = New System.Drawing.Size(147, 33)
        Me.CboEstadoDocumeto.TabIndex = 239
        '
        'Button17
        '
        Me.Button17.Image = CType(resources.GetObject("Button17.Image"), System.Drawing.Image)
        Me.Button17.Location = New System.Drawing.Point(850, 176)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(51, 38)
        Me.Button17.TabIndex = 185
        Me.Button17.UseVisualStyleBackColor = True
        Me.Button17.Visible = False
        '
        'Button18
        '
        Me.Button18.Image = CType(resources.GetObject("Button18.Image"), System.Drawing.Image)
        Me.Button18.Location = New System.Drawing.Point(1000, 187)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(69, 45)
        Me.Button18.TabIndex = 241
        Me.Button18.UseVisualStyleBackColor = True
        Me.Button18.Visible = False
        '
        'Button13
        '
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button13.Location = New System.Drawing.Point(1085, 443)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(114, 55)
        Me.Button13.TabIndex = 219
        Me.Button13.Text = "Calidad"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button13.UseVisualStyleBackColor = True
        Me.Button13.Visible = False
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(555, 765)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 34)
        Me.Button3.TabIndex = 180
        Me.Button3.Text = "Eliminar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AllowAddNew = True
        Me.TrueDBGridComponentes.AllowDelete = True
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Productos"
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(7, 358)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(988, 175)
        Me.TrueDBGridComponentes.TabIndex = 211
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.Location = New System.Drawing.Point(870, 818)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(29, 30)
        Me.Button8.TabIndex = 188
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(12, 538)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(161, 51)
        Me.Button6.TabIndex = 213
        Me.Button6.Text = "Borrar Linea"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'BindingDetalle
        '
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Enabled = False
        Me.TxtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecio.Location = New System.Drawing.Point(792, 443)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(98, 31)
        Me.TxtPrecio.TabIndex = 243
        Me.TxtPrecio.Visible = False
        '
        'LblPrecio
        '
        Me.LblPrecio.AutoSize = True
        Me.LblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblPrecio.Location = New System.Drawing.Point(796, 423)
        Me.LblPrecio.Name = "LblPrecio"
        Me.LblPrecio.Size = New System.Drawing.Size(70, 20)
        Me.LblPrecio.TabIndex = 242
        Me.LblPrecio.Text = "PRECIO"
        Me.LblPrecio.Visible = False
        '
        'CmdObservaciones
        '
        Me.CmdObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdObservaciones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdObservaciones.Image = Global.Remisiones.My.Resources.Resources.icons8_comentarios_40
        Me.CmdObservaciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdObservaciones.Location = New System.Drawing.Point(179, 538)
        Me.CmdObservaciones.Name = "CmdObservaciones"
        Me.CmdObservaciones.Size = New System.Drawing.Size(111, 56)
        Me.CmdObservaciones.TabIndex = 244
        Me.CmdObservaciones.Text = "Observaciones"
        Me.CmdObservaciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdObservaciones.UseVisualStyleBackColor = True
        '
        'FrmRecepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1279, 716)
        Me.Controls.Add(Me.CmdObservaciones)
        Me.Controls.Add(Me.CboEstadoDocumeto)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtOreadoReal)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtEqOreado)
        Me.Controls.Add(Me.CboTipoDocumento)
        Me.Controls.Add(Me.OptNinguno)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.OptPreSeco)
        Me.Controls.Add(Me.lbltipo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CboIngresoBascula)
        Me.Controls.Add(Me.CboTipoRecepcion)
        Me.Controls.Add(Me.OptMedioSeco)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.TxtNumeroRecepcion)
        Me.Controls.Add(Me.TxtLocalidad)
        Me.Controls.Add(Me.OptOreado)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.OptMojado)
        Me.Controls.Add(Me.TxtProveedor)
        Me.Controls.Add(Me.ChkRedondeo)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lblcedula)
        Me.Controls.Add(Me.TxtPila)
        Me.Controls.Add(Me.TxtOrigen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtDia)
        Me.Controls.Add(Me.TxtMes)
        Me.Controls.Add(Me.LblPeso)
        Me.Controls.Add(Me.TxtAno)
        Me.Controls.Add(Me.CboConductor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtplaca)
        Me.Controls.Add(Me.txtapellido)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblapellido)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Controls.Add(Me.Eventos)
        Me.Controls.Add(Me.CboCodigoBodega)
        Me.Controls.Add(Me.lblconductor)
        Me.Controls.Add(Me.Grupo)
        Me.Controls.Add(Me.lblnumR)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.TxtNumeroEnsamble)
        Me.Controls.Add(Me.TxtPrecio)
        Me.Controls.Add(Me.LblPrecio)
        Me.Name = "FrmRecepcion"
        Me.Text = "Recepcion de Cafe"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboConductor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo.ResumeLayout(False)
        Me.Grupo.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.CboCodigoBodega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Eventos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboLiquidarLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboIngresoBascula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents CboTipoRecepcion As System.Windows.Forms.ComboBox
    Friend WithEvents lbltipo As System.Windows.Forms.Label
    Friend WithEvents lblbdega As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents datosprov As System.Windows.Forms.Label
    Friend WithEvents txtplaca As System.Windows.Forms.TextBox
    Friend WithEvents txtapellido As System.Windows.Forms.TextBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents lblapellido As System.Windows.Forms.Label
    Friend WithEvents lblnombre As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblconductor As System.Windows.Forms.Label
    Friend WithEvents Grupo As System.Windows.Forms.GroupBox
    Friend WithEvents lbldatosre As System.Windows.Forms.Label
    Friend WithEvents CboCodigoBodega As C1.Win.C1List.C1Combo
    Friend WithEvents lblnumR As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtobservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Eventos As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents CboConductor As C1.Win.C1List.C1Combo
    Friend WithEvents sp As System.IO.Ports.SerialPort
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblPeso As System.Windows.Forms.Label
    Friend WithEvents ChkRedondeo As System.Windows.Forms.CheckBox
    Friend WithEvents lblproveedor As System.Windows.Forms.Label
    Friend WithEvents lblcedula As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroRecepcion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtAno As System.Windows.Forms.TextBox
    Friend WithEvents TxtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents TxtDia As System.Windows.Forms.TextBox
    Friend WithEvents TxtMes As System.Windows.Forms.TextBox
    Friend WithEvents TxtPila As System.Windows.Forms.TextBox
    Friend WithEvents TxtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents CboCodigoProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OptMaquila As System.Windows.Forms.RadioButton
    Friend WithEvents OptExpasa As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboIngresoBascula As C1.Win.C1List.C1Combo
    Friend WithEvents OptMojado As System.Windows.Forms.RadioButton
    Friend WithEvents OptHumedo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents OptOreado As System.Windows.Forms.RadioButton
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DTPFecha As System.Windows.Forms.Label
    Friend WithEvents LblCosecha As System.Windows.Forms.Label
    Friend WithEvents LblSucursal As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents CboTipoCalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OptPreSeco As System.Windows.Forms.RadioButton
    Friend WithEvents OptMedioSeco As System.Windows.Forms.RadioButton
    Friend WithEvents OptNinguno As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboTipoCompra As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents CboLiquidarLocalidad As C1.Win.C1List.C1Combo
    Friend WithEvents LblLiquidar As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CboDaño As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtEqOreado As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtOreadoReal As System.Windows.Forms.TextBox
    Friend WithEvents TxtImperfecion As System.Windows.Forms.TextBox
    Friend WithEvents TxtHumedad As System.Windows.Forms.TextBox
    Friend WithEvents CboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtIdLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CboFinca As System.Windows.Forms.ComboBox
    Friend WithEvents CmdPesada As System.Windows.Forms.Button
    Friend WithEvents DtpHoraManual As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaManual As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboTipoCafe As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents TxtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroRecibo As System.Windows.Forms.TextBox
    Friend WithEvents CmdProductorManual As System.Windows.Forms.Button
    Friend WithEvents TxtFinca As System.Windows.Forms.TextBox
    Friend WithEvents CboTipoIngresoBascula As System.Windows.Forms.ComboBox
    Friend WithEvents CmdConfirma As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CboLocalidad As C1.Win.C1List.C1Combo
    Friend WithEvents LblCertificado As System.Windows.Forms.Label
    Friend WithEvents LblPignorado As System.Windows.Forms.Label
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents CboEstadoDocumeto As System.Windows.Forms.ComboBox
    Friend WithEvents ListBoxCertificados As System.Windows.Forms.ListBox
    Friend WithEvents CboPignorado As System.Windows.Forms.ComboBox
    Friend WithEvents TxtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents LblPrecio As System.Windows.Forms.Label
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdObservaciones As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
