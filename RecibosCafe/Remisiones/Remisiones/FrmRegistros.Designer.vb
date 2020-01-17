<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistros))
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.LblFecha = New System.Windows.Forms.Label
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.lblbdega = New System.Windows.Forms.Label
        Me.LblHora = New System.Windows.Forms.Label
        Me.lbldatosre = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.TxtBoleta = New System.Windows.Forms.TextBox
        Me.LblBoleta = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPlaca = New C1.Win.C1List.C1Combo
        Me.CboCodigoProveedor = New C1.Win.C1List.C1Combo
        Me.datosprov = New System.Windows.Forms.Label
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.lblnombre = New System.Windows.Forms.Label
        Me.lblproveedor = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.OptSalida = New System.Windows.Forms.RadioButton
        Me.OptLlegada = New System.Windows.Forms.RadioButton
        Me.Button7 = New System.Windows.Forms.Button
        Me.LblCosecha = New System.Windows.Forms.Label
        Me.LblSucursal = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.C1Button10 = New C1.Win.C1Input.C1Button
        Me.CmdBoton0 = New C1.Win.C1Input.C1Button
        Me.C1Button12 = New C1.Win.C1Input.C1Button
        Me.CmdBoton9 = New C1.Win.C1Input.C1Button
        Me.CmdBoton8 = New C1.Win.C1Input.C1Button
        Me.CmdBoton7 = New C1.Win.C1Input.C1Button
        Me.CmdBoton6 = New C1.Win.C1Input.C1Button
        Me.CmdBoton5 = New C1.Win.C1Input.C1Button
        Me.CmdBoton4 = New C1.Win.C1Input.C1Button
        Me.CmdBoton3 = New C1.Win.C1Input.C1Button
        Me.CmdBoton2 = New C1.Win.C1Input.C1Button
        Me.CmdBoton1 = New C1.Win.C1Input.C1Button
        Me.TxtMinutos = New System.Windows.Forms.TextBox
        Me.TxtHora = New System.Windows.Forms.TextBox
        Me.TxtBarra = New C1.Win.C1BarCode.C1BarCode
        Me.LblEncabezado = New System.Windows.Forms.Label
        Me.OptReserva = New System.Windows.Forms.RadioButton
        Me.LblRegistro = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.TxtPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox9.Controls.Add(Me.LblFecha)
        Me.GroupBox9.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox9.Controls.Add(Me.lblbdega)
        Me.GroupBox9.Controls.Add(Me.LblHora)
        Me.GroupBox9.Controls.Add(Me.lbldatosre)
        Me.GroupBox9.Location = New System.Drawing.Point(7, 188)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(616, 91)
        Me.GroupBox9.TabIndex = 181
        Me.GroupBox9.TabStop = False
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.ForeColor = System.Drawing.Color.White
        Me.LblFecha.Location = New System.Drawing.Point(5, 31)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(242, 39)
        Me.LblFecha.TabIndex = 183
        Me.LblFecha.Text = "10:23:55 p.m."
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Enabled = False
        Me.TxtNumeroEnsamble.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(468, 39)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(103, 29)
        Me.TxtNumeroEnsamble.TabIndex = 182
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'lblbdega
        '
        Me.lblbdega.AutoSize = True
        Me.lblbdega.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbdega.ForeColor = System.Drawing.Color.Red
        Me.lblbdega.Location = New System.Drawing.Point(444, 11)
        Me.lblbdega.Name = "lblbdega"
        Me.lblbdega.Size = New System.Drawing.Size(160, 25)
        Me.lblbdega.TabIndex = 181
        Me.lblbdega.Text = "Nº REGISTRO"
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.White
        Me.LblHora.Location = New System.Drawing.Point(223, 31)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(242, 39)
        Me.LblHora.TabIndex = 180
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'lbldatosre
        '
        Me.lbldatosre.AutoSize = True
        Me.lbldatosre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatosre.ForeColor = System.Drawing.Color.Black
        Me.lbldatosre.Location = New System.Drawing.Point(41, 0)
        Me.lbldatosre.Name = "lbldatosre"
        Me.lbldatosre.Size = New System.Drawing.Size(180, 20)
        Me.lbldatosre.TabIndex = 176
        Me.lbldatosre.Text = "DATOS DE REGISTRO"
        '
        'DTPFecha
        '
        Me.DTPFecha.Enabled = False
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(667, 107)
        Me.DTPFecha.Margin = New System.Windows.Forms.Padding(5)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(229, 47)
        Me.DTPFecha.TabIndex = 179
        Me.DTPFecha.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.TxtBoleta)
        Me.GroupBox6.Controls.Add(Me.LblBoleta)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.TxtPlaca)
        Me.GroupBox6.Controls.Add(Me.CboCodigoProveedor)
        Me.GroupBox6.Controls.Add(Me.datosprov)
        Me.GroupBox6.Controls.Add(Me.txtnombre)
        Me.GroupBox6.Controls.Add(Me.lblnombre)
        Me.GroupBox6.Controls.Add(Me.lblproveedor)
        Me.GroupBox6.Controls.Add(Me.Button2)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 285)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(616, 194)
        Me.GroupBox6.TabIndex = 180
        Me.GroupBox6.TabStop = False
        '
        'TxtBoleta
        '
        Me.TxtBoleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoleta.Location = New System.Drawing.Point(71, 140)
        Me.TxtBoleta.MaxLength = 6
        Me.TxtBoleta.Name = "TxtBoleta"
        Me.TxtBoleta.Size = New System.Drawing.Size(394, 24)
        Me.TxtBoleta.TabIndex = 239
        '
        'LblBoleta
        '
        Me.LblBoleta.AutoSize = True
        Me.LblBoleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBoleta.ForeColor = System.Drawing.Color.White
        Me.LblBoleta.Location = New System.Drawing.Point(9, 143)
        Me.LblBoleta.Name = "LblBoleta"
        Me.LblBoleta.Size = New System.Drawing.Size(48, 15)
        Me.LblBoleta.TabIndex = 238
        Me.LblBoleta.Text = "Boleta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Placa"
        '
        'TxtPlaca
        '
        Me.TxtPlaca.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.TxtPlaca.AlternatingRows = True
        Me.TxtPlaca.Caption = ""
        Me.TxtPlaca.CaptionHeight = 17
        Me.TxtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtPlaca.ColumnCaptionHeight = 17
        Me.TxtPlaca.ColumnFooterHeight = 17
        Me.TxtPlaca.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.TxtPlaca.ContentHeight = 33
        Me.TxtPlaca.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.TxtPlaca.DisplayMember = "Placa"
        Me.TxtPlaca.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.TxtPlaca.DropDownWidth = 200
        Me.TxtPlaca.EditorBackColor = System.Drawing.SystemColors.Window
        Me.TxtPlaca.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlaca.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtPlaca.EditorHeight = 33
        Me.TxtPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlaca.Images.Add(CType(resources.GetObject("TxtPlaca.Images"), System.Drawing.Image))
        Me.TxtPlaca.ItemHeight = 35
        Me.TxtPlaca.Location = New System.Drawing.Point(71, 91)
        Me.TxtPlaca.MatchEntryTimeout = CType(2000, Long)
        Me.TxtPlaca.MaxDropDownItems = CType(6, Short)
        Me.TxtPlaca.MaxLength = 32767
        Me.TxtPlaca.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.TxtPlaca.Name = "TxtPlaca"
        Me.TxtPlaca.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.TxtPlaca.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.TxtPlaca.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.TxtPlaca.Size = New System.Drawing.Size(220, 39)
        Me.TxtPlaca.TabIndex = 180
        Me.TxtPlaca.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.TxtPlaca.PropBag = resources.GetString("TxtPlaca.PropBag")
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
        Me.CboCodigoProveedor.Location = New System.Drawing.Point(71, 23)
        Me.CboCodigoProveedor.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoProveedor.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoProveedor.MaxLength = 32767
        Me.CboCodigoProveedor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoProveedor.Name = "CboCodigoProveedor"
        Me.CboCodigoProveedor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoProveedor.Size = New System.Drawing.Size(172, 32)
        Me.CboCodigoProveedor.TabIndex = 0
        Me.CboCodigoProveedor.PropBag = resources.GetString("CboCodigoProveedor.PropBag")
        '
        'datosprov
        '
        Me.datosprov.AutoSize = True
        Me.datosprov.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datosprov.ForeColor = System.Drawing.Color.White
        Me.datosprov.Location = New System.Drawing.Point(52, 0)
        Me.datosprov.Name = "datosprov"
        Me.datosprov.Size = New System.Drawing.Size(237, 20)
        Me.datosprov.TabIndex = 25
        Me.datosprov.Text = "DATOS DEL TRANSPORTISTA"
        '
        'txtnombre
        '
        Me.txtnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(71, 60)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(394, 24)
        Me.txtnombre.TabIndex = 178
        '
        'lblnombre
        '
        Me.lblnombre.AutoSize = True
        Me.lblnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnombre.ForeColor = System.Drawing.Color.White
        Me.lblnombre.Location = New System.Drawing.Point(9, 63)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(58, 15)
        Me.lblnombre.TabIndex = 174
        Me.lblnombre.Text = "Nombre"
        '
        'lblproveedor
        '
        Me.lblproveedor.AutoSize = True
        Me.lblproveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproveedor.ForeColor = System.Drawing.Color.White
        Me.lblproveedor.Location = New System.Drawing.Point(13, 29)
        Me.lblproveedor.Name = "lblproveedor"
        Me.lblproveedor.Size = New System.Drawing.Size(52, 15)
        Me.lblproveedor.TabIndex = 2
        Me.lblproveedor.Text = "Código"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(516, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 64)
        Me.Button2.TabIndex = 171
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OptSalida
        '
        Me.OptSalida.AutoSize = True
        Me.OptSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptSalida.ForeColor = System.Drawing.Color.White
        Me.OptSalida.Location = New System.Drawing.Point(10, 19)
        Me.OptSalida.Name = "OptSalida"
        Me.OptSalida.Size = New System.Drawing.Size(283, 33)
        Me.OptSalida.TabIndex = 185
        Me.OptSalida.TabStop = True
        Me.OptSalida.Text = "REGISTRO DE SALIDA"
        Me.OptSalida.UseVisualStyleBackColor = True
        '
        'OptLlegada
        '
        Me.OptLlegada.AutoSize = True
        Me.OptLlegada.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptLlegada.ForeColor = System.Drawing.Color.White
        Me.OptLlegada.Location = New System.Drawing.Point(10, 53)
        Me.OptLlegada.Name = "OptLlegada"
        Me.OptLlegada.Size = New System.Drawing.Size(308, 33)
        Me.OptLlegada.TabIndex = 184
        Me.OptLlegada.TabStop = True
        Me.OptLlegada.Text = "REGISTRO DE LLEGADA"
        Me.OptLlegada.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(12, 577)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(144, 85)
        Me.Button7.TabIndex = 228
        Me.Button7.Text = "Grabar"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'LblCosecha
        '
        Me.LblCosecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCosecha.ForeColor = System.Drawing.Color.White
        Me.LblCosecha.Location = New System.Drawing.Point(85, 129)
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Size = New System.Drawing.Size(508, 25)
        Me.LblCosecha.TabIndex = 184
        Me.LblCosecha.Text = "Cosecha 2011-2015"
        Me.LblCosecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSucursal
        '
        Me.LblSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblSucursal.AutoSize = True
        Me.LblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSucursal.ForeColor = System.Drawing.Color.White
        Me.LblSucursal.Location = New System.Drawing.Point(21, 190)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(249, 31)
        Me.LblSucursal.TabIndex = 32
        Me.LblSucursal.Text = "SUCURSAL xxxxx"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.C1Button1)
        Me.GroupBox2.Controls.Add(Me.C1Button10)
        Me.GroupBox2.Controls.Add(Me.CmdBoton0)
        Me.GroupBox2.Controls.Add(Me.C1Button12)
        Me.GroupBox2.Controls.Add(Me.CmdBoton9)
        Me.GroupBox2.Controls.Add(Me.CmdBoton8)
        Me.GroupBox2.Controls.Add(Me.CmdBoton7)
        Me.GroupBox2.Controls.Add(Me.CmdBoton6)
        Me.GroupBox2.Controls.Add(Me.CmdBoton5)
        Me.GroupBox2.Controls.Add(Me.CmdBoton4)
        Me.GroupBox2.Controls.Add(Me.CmdBoton3)
        Me.GroupBox2.Controls.Add(Me.CmdBoton2)
        Me.GroupBox2.Controls.Add(Me.CmdBoton1)
        Me.GroupBox2.Controls.Add(Me.TxtMinutos)
        Me.GroupBox2.Controls.Add(Me.TxtHora)
        Me.GroupBox2.Controls.Add(Me.TxtBarra)
        Me.GroupBox2.Location = New System.Drawing.Point(628, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(380, 486)
        Me.GroupBox2.TabIndex = 232
        Me.GroupBox2.TabStop = False
        '
        'C1Button1
        '
        Me.C1Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.C1Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button1.ForeColor = System.Drawing.Color.White
        Me.C1Button1.Location = New System.Drawing.Point(14, 390)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(356, 84)
        Me.C1Button1.TabIndex = 16
        Me.C1Button1.Text = "ENTER"
        Me.C1Button1.UseVisualStyleBackColor = False
        '
        'C1Button10
        '
        Me.C1Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.C1Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button10.ForeColor = System.Drawing.Color.White
        Me.C1Button10.Location = New System.Drawing.Point(251, 293)
        Me.C1Button10.Name = "C1Button10"
        Me.C1Button10.Size = New System.Drawing.Size(119, 91)
        Me.C1Button10.TabIndex = 15
        Me.C1Button10.Text = "Borrar"
        Me.C1Button10.UseVisualStyleBackColor = False
        '
        'CmdBoton0
        '
        Me.CmdBoton0.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton0.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton0.ForeColor = System.Drawing.Color.White
        Me.CmdBoton0.Location = New System.Drawing.Point(130, 292)
        Me.CmdBoton0.Name = "CmdBoton0"
        Me.CmdBoton0.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton0.TabIndex = 14
        Me.CmdBoton0.Text = "0"
        Me.CmdBoton0.UseVisualStyleBackColor = False
        '
        'C1Button12
        '
        Me.C1Button12.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.C1Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button12.ForeColor = System.Drawing.Color.White
        Me.C1Button12.Location = New System.Drawing.Point(9, 292)
        Me.C1Button12.Name = "C1Button12"
        Me.C1Button12.Size = New System.Drawing.Size(119, 91)
        Me.C1Button12.TabIndex = 10
        Me.C1Button12.Text = "+"
        Me.C1Button12.UseVisualStyleBackColor = False
        '
        'CmdBoton9
        '
        Me.CmdBoton9.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton9.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton9.ForeColor = System.Drawing.Color.White
        Me.CmdBoton9.Location = New System.Drawing.Point(250, 201)
        Me.CmdBoton9.Name = "CmdBoton9"
        Me.CmdBoton9.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton9.TabIndex = 13
        Me.CmdBoton9.Text = "9"
        Me.CmdBoton9.UseVisualStyleBackColor = False
        '
        'CmdBoton8
        '
        Me.CmdBoton8.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton8.ForeColor = System.Drawing.Color.White
        Me.CmdBoton8.Location = New System.Drawing.Point(129, 200)
        Me.CmdBoton8.Name = "CmdBoton8"
        Me.CmdBoton8.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton8.TabIndex = 12
        Me.CmdBoton8.Text = "8"
        Me.CmdBoton8.UseVisualStyleBackColor = False
        '
        'CmdBoton7
        '
        Me.CmdBoton7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton7.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton7.ForeColor = System.Drawing.Color.White
        Me.CmdBoton7.Location = New System.Drawing.Point(9, 200)
        Me.CmdBoton7.Name = "CmdBoton7"
        Me.CmdBoton7.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton7.TabIndex = 11
        Me.CmdBoton7.Text = "7"
        Me.CmdBoton7.UseVisualStyleBackColor = False
        '
        'CmdBoton6
        '
        Me.CmdBoton6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton6.ForeColor = System.Drawing.Color.White
        Me.CmdBoton6.Location = New System.Drawing.Point(250, 109)
        Me.CmdBoton6.Name = "CmdBoton6"
        Me.CmdBoton6.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton6.TabIndex = 10
        Me.CmdBoton6.Text = "6"
        Me.CmdBoton6.UseVisualStyleBackColor = False
        '
        'CmdBoton5
        '
        Me.CmdBoton5.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton5.ForeColor = System.Drawing.Color.White
        Me.CmdBoton5.Location = New System.Drawing.Point(129, 108)
        Me.CmdBoton5.Name = "CmdBoton5"
        Me.CmdBoton5.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton5.TabIndex = 9
        Me.CmdBoton5.Text = "5"
        Me.CmdBoton5.UseVisualStyleBackColor = False
        '
        'CmdBoton4
        '
        Me.CmdBoton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton4.ForeColor = System.Drawing.Color.White
        Me.CmdBoton4.Location = New System.Drawing.Point(9, 108)
        Me.CmdBoton4.Name = "CmdBoton4"
        Me.CmdBoton4.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton4.TabIndex = 8
        Me.CmdBoton4.Text = "4"
        Me.CmdBoton4.UseVisualStyleBackColor = False
        '
        'CmdBoton3
        '
        Me.CmdBoton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton3.ForeColor = System.Drawing.Color.White
        Me.CmdBoton3.Location = New System.Drawing.Point(250, 16)
        Me.CmdBoton3.Name = "CmdBoton3"
        Me.CmdBoton3.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton3.TabIndex = 7
        Me.CmdBoton3.Text = "3"
        Me.CmdBoton3.UseVisualStyleBackColor = False
        '
        'CmdBoton2
        '
        Me.CmdBoton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton2.ForeColor = System.Drawing.Color.White
        Me.CmdBoton2.Location = New System.Drawing.Point(130, 15)
        Me.CmdBoton2.Name = "CmdBoton2"
        Me.CmdBoton2.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton2.TabIndex = 6
        Me.CmdBoton2.Text = "2"
        Me.CmdBoton2.UseVisualStyleBackColor = False
        '
        'CmdBoton1
        '
        Me.CmdBoton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton1.ForeColor = System.Drawing.Color.White
        Me.CmdBoton1.Location = New System.Drawing.Point(9, 15)
        Me.CmdBoton1.Name = "CmdBoton1"
        Me.CmdBoton1.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton1.TabIndex = 5
        Me.CmdBoton1.Text = "1"
        Me.CmdBoton1.UseVisualStyleBackColor = False
        '
        'TxtMinutos
        '
        Me.TxtMinutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMinutos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtMinutos.Location = New System.Drawing.Point(631, 61)
        Me.TxtMinutos.MaxLength = 2
        Me.TxtMinutos.Name = "TxtMinutos"
        Me.TxtMinutos.Size = New System.Drawing.Size(62, 49)
        Me.TxtMinutos.TabIndex = 4
        Me.TxtMinutos.Visible = False
        '
        'TxtHora
        '
        Me.TxtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtHora.Location = New System.Drawing.Point(563, 61)
        Me.TxtHora.MaxLength = 2
        Me.TxtHora.Name = "TxtHora"
        Me.TxtHora.Size = New System.Drawing.Size(62, 49)
        Me.TxtHora.TabIndex = 3
        Me.TxtHora.Visible = False
        '
        'TxtBarra
        '
        Me.TxtBarra.Location = New System.Drawing.Point(755, 12)
        Me.TxtBarra.Name = "TxtBarra"
        Me.TxtBarra.Size = New System.Drawing.Size(113, 34)
        Me.TxtBarra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TxtBarra.TabIndex = 7
        Me.TxtBarra.Text = "12355"
        Me.TxtBarra.Visible = False
        '
        'LblEncabezado
        '
        Me.LblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEncabezado.ForeColor = System.Drawing.Color.White
        Me.LblEncabezado.Location = New System.Drawing.Point(7, 29)
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Size = New System.Drawing.Size(991, 42)
        Me.LblEncabezado.TabIndex = 233
        Me.LblEncabezado.Text = "EXPORTADORA ATLANTIC"
        Me.LblEncabezado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OptReserva
        '
        Me.OptReserva.AutoSize = True
        Me.OptReserva.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptReserva.ForeColor = System.Drawing.Color.White
        Me.OptReserva.Location = New System.Drawing.Point(6, 92)
        Me.OptReserva.Name = "OptReserva"
        Me.OptReserva.Size = New System.Drawing.Size(274, 33)
        Me.OptReserva.TabIndex = 234
        Me.OptReserva.TabStop = True
        Me.OptReserva.Text = "REGISTRO RESERVA"
        Me.OptReserva.UseVisualStyleBackColor = True
        '
        'LblRegistro
        '
        Me.LblRegistro.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistro.ForeColor = System.Drawing.Color.White
        Me.LblRegistro.Location = New System.Drawing.Point(13, 83)
        Me.LblRegistro.Name = "LblRegistro"
        Me.LblRegistro.Size = New System.Drawing.Size(646, 31)
        Me.LblRegistro.TabIndex = 235
        Me.LblRegistro.Text = "SUCURSAL xxxxx"
        Me.LblRegistro.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptSalida)
        Me.GroupBox1.Controls.Add(Me.OptLlegada)
        Me.GroupBox1.Controls.Add(Me.OptReserva)
        Me.GroupBox1.Location = New System.Drawing.Point(162, 514)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 131)
        Me.GroupBox1.TabIndex = 236
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(475, 579)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 85)
        Me.Button1.TabIndex = 237
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmRegistros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1023, 733)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblRegistro)
        Me.Controls.Add(Me.LblEncabezado)
        Me.Controls.Add(Me.LblCosecha)
        Me.Controls.Add(Me.LblSucursal)
        Me.Controls.Add(Me.DTPFecha)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox6)
        Me.Name = "FrmRegistros"
        Me.Text = "Registros"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.TxtPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents lblbdega As System.Windows.Forms.Label
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbldatosre As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CboCodigoProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents datosprov As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents lblnombre As System.Windows.Forms.Label
    Friend WithEvents lblproveedor As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OptSalida As System.Windows.Forms.RadioButton
    Friend WithEvents OptLlegada As System.Windows.Forms.RadioButton
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents LblCosecha As System.Windows.Forms.Label
    Friend WithEvents LblSucursal As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button10 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton0 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button12 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton9 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton8 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton7 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton6 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton5 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton4 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton3 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton2 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton1 As C1.Win.C1Input.C1Button
    Friend WithEvents TxtMinutos As System.Windows.Forms.TextBox
    Friend WithEvents TxtHora As System.Windows.Forms.TextBox
    Friend WithEvents TxtBarra As C1.Win.C1BarCode.C1BarCode
    Friend WithEvents LblEncabezado As System.Windows.Forms.Label
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents OptReserva As System.Windows.Forms.RadioButton
    Friend WithEvents LblRegistro As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPlaca As C1.Win.C1List.C1Combo
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtBoleta As System.Windows.Forms.TextBox
    Friend WithEvents LblBoleta As System.Windows.Forms.Label
End Class
