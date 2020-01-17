<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPuntosInter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPuntosInter))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DTPPISalida = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTPPICarga = New System.Windows.Forms.DateTimePicker
        Me.DTPPIEntrada = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button15 = New System.Windows.Forms.Button
        Me.CboLocOrigen = New C1.Win.C1List.C1Combo
        Me.TxtCantSacos = New System.Windows.Forms.TextBox
        Me.TxtPIPesoBruto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.CboEmprsPlc = New C1.Win.C1List.C1Combo
        Me.CboEmpresaTrans = New C1.Win.C1List.C1Combo
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.CboLocDest = New C1.Win.C1List.C1Combo
        Me.TxtCantDest = New System.Windows.Forms.TextBox
        Me.TxtPesoBrutDestino = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Origen = New System.Windows.Forms.TextBox
        Me.Empresa = New System.Windows.Forms.TextBox
        Me.conductor = New System.Windows.Forms.TextBox
        Me.vehiculo = New System.Windows.Forms.TextBox
        Me.destino = New System.Windows.Forms.TextBox
        Me.CboConductor = New C1.Win.C1List.C1Combo
        Me.TxtIdPI = New System.Windows.Forms.TextBox
        Me.TxtCantidadEntrada = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPBEntrada = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPBSalida = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtCantidadSalida = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TDBGridMerma = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.CmdConfirma = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TDGridOrigen = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button_Pesada_Maquila_Salida = New System.Windows.Forms.Button
        Me.TDGribListRecibosSalida = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Button_Pesada_Maquila = New System.Windows.Forms.Button
        Me.TDGribListRecibos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BtnGuardarPInter = New System.Windows.Forms.Button
        Me.CmdPesada = New System.Windows.Forms.Button
        Me.Label37 = New System.Windows.Forms.Label
        Me.TxtNumeroBoleta = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CboLocOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEmprsPlc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEmpresaTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CboLocDest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboConductor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDBGridMerma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDGridOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDGribListRecibosSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDGribListRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Ivory
        Me.GroupBox1.Controls.Add(Me.DTPPISalida)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DTPPICarga)
        Me.GroupBox1.Controls.Add(Me.DTPPIEntrada)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 163)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'DTPPISalida
        '
        Me.DTPPISalida.CustomFormat = "dd/MM/yyyy HH:mm:s"
        Me.DTPPISalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPPISalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPPISalida.Location = New System.Drawing.Point(11, 131)
        Me.DTPPISalida.Name = "DTPPISalida"
        Me.DTPPISalida.Size = New System.Drawing.Size(230, 29)
        Me.DTPPISalida.TabIndex = 203
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 20)
        Me.Label2.TabIndex = 202
        Me.Label2.Text = "Fecha Salida"
        '
        'DTPPICarga
        '
        Me.DTPPICarga.CustomFormat = "dd/MM/yyyy HH:mm:s"
        Me.DTPPICarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPPICarga.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPPICarga.Location = New System.Drawing.Point(15, 81)
        Me.DTPPICarga.Name = "DTPPICarga"
        Me.DTPPICarga.Size = New System.Drawing.Size(226, 29)
        Me.DTPPICarga.TabIndex = 201
        '
        'DTPPIEntrada
        '
        Me.DTPPIEntrada.CustomFormat = "dd/MM/yyyy HH:mm:s"
        Me.DTPPIEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPPIEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPPIEntrada.Location = New System.Drawing.Point(14, 30)
        Me.DTPPIEntrada.Name = "DTPPIEntrada"
        Me.DTPPIEntrada.Size = New System.Drawing.Size(227, 29)
        Me.DTPPIEntrada.TabIndex = 200
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(10, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 20)
        Me.Label9.TabIndex = 199
        Me.Label9.Text = "Fecha Entrada "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(12, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 198
        Me.Label10.Text = "Fecha Carga"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Ivory
        Me.GroupBox2.Controls.Add(Me.Button15)
        Me.GroupBox2.Controls.Add(Me.CboLocOrigen)
        Me.GroupBox2.Controls.Add(Me.TxtCantSacos)
        Me.GroupBox2.Controls.Add(Me.TxtPIPesoBruto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 179)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(533, 107)
        Me.GroupBox2.TabIndex = 205
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Origen "
        '
        'Button15
        '
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.Location = New System.Drawing.Point(260, 57)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(35, 33)
        Me.Button15.TabIndex = 238
        Me.Button15.UseVisualStyleBackColor = True
        '
        'CboLocOrigen
        '
        Me.CboLocOrigen.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboLocOrigen.AlternatingRows = True
        Me.CboLocOrigen.Caption = ""
        Me.CboLocOrigen.CaptionHeight = 17
        Me.CboLocOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboLocOrigen.ColumnCaptionHeight = 17
        Me.CboLocOrigen.ColumnFooterHeight = 17
        Me.CboLocOrigen.ContentHeight = 26
        Me.CboLocOrigen.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboLocOrigen.DisplayMember = "NomLugarAcopio"
        Me.CboLocOrigen.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboLocOrigen.DropDownWidth = 300
        Me.CboLocOrigen.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboLocOrigen.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboLocOrigen.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboLocOrigen.EditorHeight = 26
        Me.CboLocOrigen.Images.Add(CType(resources.GetObject("CboLocOrigen.Images"), System.Drawing.Image))
        Me.CboLocOrigen.ItemHeight = 35
        Me.CboLocOrigen.Location = New System.Drawing.Point(6, 57)
        Me.CboLocOrigen.MatchEntryTimeout = CType(2000, Long)
        Me.CboLocOrigen.MaxDropDownItems = CType(5, Short)
        Me.CboLocOrigen.MaxLength = 32767
        Me.CboLocOrigen.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboLocOrigen.Name = "CboLocOrigen"
        Me.CboLocOrigen.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboLocOrigen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboLocOrigen.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboLocOrigen.Size = New System.Drawing.Size(252, 32)
        Me.CboLocOrigen.TabIndex = 223
        Me.CboLocOrigen.PropBag = resources.GetString("CboLocOrigen.PropBag")
        '
        'TxtCantSacos
        '
        Me.TxtCantSacos.BackColor = System.Drawing.Color.LightGreen
        Me.TxtCantSacos.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantSacos.Location = New System.Drawing.Point(300, 57)
        Me.TxtCantSacos.Name = "TxtCantSacos"
        Me.TxtCantSacos.Size = New System.Drawing.Size(77, 31)
        Me.TxtCantSacos.TabIndex = 206
        '
        'TxtPIPesoBruto
        '
        Me.TxtPIPesoBruto.BackColor = System.Drawing.Color.LightGreen
        Me.TxtPIPesoBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPIPesoBruto.Location = New System.Drawing.Point(402, 57)
        Me.TxtPIPesoBruto.Name = "TxtPIPesoBruto"
        Me.TxtPIPesoBruto.Size = New System.Drawing.Size(119, 31)
        Me.TxtPIPesoBruto.TabIndex = 205
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(293, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 24)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Cant Orig"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(276, 24)
        Me.Label5.TabIndex = 199
        Me.Label5.Text = "Recepcion Punto Intermedio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(400, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 24)
        Me.Label6.TabIndex = 198
        Me.Label6.Text = "Peso Bruto "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(14, 296)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 16)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "Datos de Empresa"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(78, 435)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 20)
        Me.Label8.TabIndex = 211
        Me.Label8.Text = "Conductor "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(90, 359)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 20)
        Me.Label11.TabIndex = 208
        Me.Label11.Text = "Empresa "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(115, 401)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 20)
        Me.Label12.TabIndex = 207
        Me.Label12.Text = "Placa "
        '
        'CboEmprsPlc
        '
        Me.CboEmprsPlc.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEmprsPlc.AlternatingRows = True
        Me.CboEmprsPlc.Caption = ""
        Me.CboEmprsPlc.CaptionHeight = 17
        Me.CboEmprsPlc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEmprsPlc.ColumnCaptionHeight = 17
        Me.CboEmprsPlc.ColumnFooterHeight = 17
        Me.CboEmprsPlc.ContentHeight = 26
        Me.CboEmprsPlc.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEmprsPlc.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboEmprsPlc.DropDownWidth = 300
        Me.CboEmprsPlc.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEmprsPlc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEmprsPlc.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEmprsPlc.EditorHeight = 26
        Me.CboEmprsPlc.Images.Add(CType(resources.GetObject("CboEmprsPlc.Images"), System.Drawing.Image))
        Me.CboEmprsPlc.ItemHeight = 35
        Me.CboEmprsPlc.Location = New System.Drawing.Point(194, 392)
        Me.CboEmprsPlc.MatchEntryTimeout = CType(2000, Long)
        Me.CboEmprsPlc.MaxDropDownItems = CType(5, Short)
        Me.CboEmprsPlc.MaxLength = 32767
        Me.CboEmprsPlc.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEmprsPlc.Name = "CboEmprsPlc"
        Me.CboEmprsPlc.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEmprsPlc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEmprsPlc.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEmprsPlc.Size = New System.Drawing.Size(267, 32)
        Me.CboEmprsPlc.TabIndex = 220
        Me.CboEmprsPlc.PropBag = resources.GetString("CboEmprsPlc.PropBag")
        '
        'CboEmpresaTrans
        '
        Me.CboEmpresaTrans.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEmpresaTrans.AlternatingRows = True
        Me.CboEmpresaTrans.Caption = ""
        Me.CboEmpresaTrans.CaptionHeight = 17
        Me.CboEmpresaTrans.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEmpresaTrans.ColumnCaptionHeight = 17
        Me.CboEmpresaTrans.ColumnFooterHeight = 17
        Me.CboEmpresaTrans.ContentHeight = 26
        Me.CboEmpresaTrans.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEmpresaTrans.DisplayMember = "NombreEmpresa"
        Me.CboEmpresaTrans.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboEmpresaTrans.DropDownWidth = 300
        Me.CboEmpresaTrans.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEmpresaTrans.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEmpresaTrans.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEmpresaTrans.EditorHeight = 26
        Me.CboEmpresaTrans.Images.Add(CType(resources.GetObject("CboEmpresaTrans.Images"), System.Drawing.Image))
        Me.CboEmpresaTrans.ItemHeight = 35
        Me.CboEmpresaTrans.Location = New System.Drawing.Point(193, 355)
        Me.CboEmpresaTrans.MatchEntryTimeout = CType(2000, Long)
        Me.CboEmpresaTrans.MaxDropDownItems = CType(5, Short)
        Me.CboEmpresaTrans.MaxLength = 32767
        Me.CboEmpresaTrans.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEmpresaTrans.Name = "CboEmpresaTrans"
        Me.CboEmpresaTrans.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEmpresaTrans.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEmpresaTrans.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEmpresaTrans.Size = New System.Drawing.Size(267, 32)
        Me.CboEmpresaTrans.TabIndex = 218
        Me.CboEmpresaTrans.PropBag = resources.GetString("CboEmpresaTrans.PropBag")
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Ivory
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.CboLocDest)
        Me.GroupBox3.Controls.Add(Me.TxtCantDest)
        Me.GroupBox3.Controls.Add(Me.TxtPesoBrutDestino)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(9, 470)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(533, 95)
        Me.GroupBox3.TabIndex = 221
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de Salida"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(265, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 33)
        Me.Button2.TabIndex = 239
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CboLocDest
        '
        Me.CboLocDest.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboLocDest.AlternatingRows = True
        Me.CboLocDest.Caption = ""
        Me.CboLocDest.CaptionHeight = 17
        Me.CboLocDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboLocDest.ColumnCaptionHeight = 17
        Me.CboLocDest.ColumnFooterHeight = 17
        Me.CboLocDest.ContentHeight = 26
        Me.CboLocDest.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboLocDest.DisplayMember = "NomLugarAcopio"
        Me.CboLocDest.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboLocDest.DropDownWidth = 300
        Me.CboLocDest.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboLocDest.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboLocDest.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboLocDest.EditorHeight = 26
        Me.CboLocDest.Images.Add(CType(resources.GetObject("CboLocDest.Images"), System.Drawing.Image))
        Me.CboLocDest.ItemHeight = 35
        Me.CboLocDest.Location = New System.Drawing.Point(8, 46)
        Me.CboLocDest.MatchEntryTimeout = CType(2000, Long)
        Me.CboLocDest.MaxDropDownItems = CType(5, Short)
        Me.CboLocDest.MaxLength = 32767
        Me.CboLocDest.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboLocDest.Name = "CboLocDest"
        Me.CboLocDest.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboLocDest.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboLocDest.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboLocDest.Size = New System.Drawing.Size(255, 32)
        Me.CboLocDest.TabIndex = 222
        Me.CboLocDest.PropBag = resources.GetString("CboLocDest.PropBag")
        '
        'TxtCantDest
        '
        Me.TxtCantDest.BackColor = System.Drawing.Color.LightGreen
        Me.TxtCantDest.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantDest.Location = New System.Drawing.Point(309, 45)
        Me.TxtCantDest.Name = "TxtCantDest"
        Me.TxtCantDest.Size = New System.Drawing.Size(80, 31)
        Me.TxtCantDest.TabIndex = 206
        '
        'TxtPesoBrutDestino
        '
        Me.TxtPesoBrutDestino.BackColor = System.Drawing.Color.LightGreen
        Me.TxtPesoBrutDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPesoBrutDestino.Location = New System.Drawing.Point(402, 46)
        Me.TxtPesoBrutDestino.Name = "TxtPesoBrutDestino"
        Me.TxtPesoBrutDestino.Size = New System.Drawing.Size(116, 31)
        Me.TxtPesoBrutDestino.TabIndex = 205
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(297, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 24)
        Me.Label14.TabIndex = 202
        Me.Label14.Text = "Cant Desti"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(7, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(262, 24)
        Me.Label15.TabIndex = 199
        Me.Label15.Text = "Remision Punto Intermedio"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(404, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 24)
        Me.Label16.TabIndex = 198
        Me.Label16.Text = "Peso Bruto "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 445)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 16)
        Me.Label13.TabIndex = 214
        '
        'Origen
        '
        Me.Origen.Location = New System.Drawing.Point(577, 283)
        Me.Origen.Name = "Origen"
        Me.Origen.Size = New System.Drawing.Size(23, 20)
        Me.Origen.TabIndex = 225
        '
        'Empresa
        '
        Me.Empresa.Location = New System.Drawing.Point(577, 223)
        Me.Empresa.Name = "Empresa"
        Me.Empresa.Size = New System.Drawing.Size(23, 20)
        Me.Empresa.TabIndex = 226
        '
        'conductor
        '
        Me.conductor.Location = New System.Drawing.Point(577, 205)
        Me.conductor.Name = "conductor"
        Me.conductor.Size = New System.Drawing.Size(23, 20)
        Me.conductor.TabIndex = 227
        '
        'vehiculo
        '
        Me.vehiculo.Location = New System.Drawing.Point(577, 179)
        Me.vehiculo.Name = "vehiculo"
        Me.vehiculo.Size = New System.Drawing.Size(23, 20)
        Me.vehiculo.TabIndex = 228
        '
        'destino
        '
        Me.destino.Location = New System.Drawing.Point(577, 231)
        Me.destino.Name = "destino"
        Me.destino.Size = New System.Drawing.Size(23, 20)
        Me.destino.TabIndex = 229
        '
        'CboConductor
        '
        Me.CboConductor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboConductor.AlternatingRows = True
        Me.CboConductor.Caption = ""
        Me.CboConductor.CaptionHeight = 17
        Me.CboConductor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboConductor.ColumnCaptionHeight = 17
        Me.CboConductor.ColumnFooterHeight = 17
        Me.CboConductor.ContentHeight = 26
        Me.CboConductor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboConductor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboConductor.DropDownWidth = 300
        Me.CboConductor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboConductor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboConductor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboConductor.EditorHeight = 26
        Me.CboConductor.Images.Add(CType(resources.GetObject("CboConductor.Images"), System.Drawing.Image))
        Me.CboConductor.ItemHeight = 35
        Me.CboConductor.Location = New System.Drawing.Point(193, 430)
        Me.CboConductor.MatchEntryTimeout = CType(2000, Long)
        Me.CboConductor.MaxDropDownItems = CType(5, Short)
        Me.CboConductor.MaxLength = 32767
        Me.CboConductor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboConductor.Name = "CboConductor"
        Me.CboConductor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboConductor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboConductor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboConductor.Size = New System.Drawing.Size(267, 32)
        Me.CboConductor.TabIndex = 230
        Me.CboConductor.PropBag = resources.GetString("CboConductor.PropBag")
        '
        'TxtIdPI
        '
        Me.TxtIdPI.Location = New System.Drawing.Point(577, 257)
        Me.TxtIdPI.Name = "TxtIdPI"
        Me.TxtIdPI.Size = New System.Drawing.Size(23, 20)
        Me.TxtIdPI.TabIndex = 231
        '
        'TxtCantidadEntrada
        '
        Me.TxtCantidadEntrada.BackColor = System.Drawing.Color.LightGreen
        Me.TxtCantidadEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadEntrada.Location = New System.Drawing.Point(651, 225)
        Me.TxtCantidadEntrada.Name = "TxtCantidadEntrada"
        Me.TxtCantidadEntrada.Size = New System.Drawing.Size(80, 31)
        Me.TxtCantidadEntrada.TabIndex = 246
        Me.TxtCantidadEntrada.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(663, 198)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 24)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Cant Entrada"
        Me.Label1.Visible = False
        '
        'TxtPBEntrada
        '
        Me.TxtPBEntrada.BackColor = System.Drawing.Color.LightGreen
        Me.TxtPBEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPBEntrada.Location = New System.Drawing.Point(641, 262)
        Me.TxtPBEntrada.Name = "TxtPBEntrada"
        Me.TxtPBEntrada.Size = New System.Drawing.Size(116, 31)
        Me.TxtPBEntrada.TabIndex = 248
        Me.TxtPBEntrada.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(663, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 24)
        Me.Label3.TabIndex = 247
        Me.Label3.Text = "PB Entrada "
        Me.Label3.Visible = False
        '
        'TxtPBSalida
        '
        Me.TxtPBSalida.AcceptsReturn = True
        Me.TxtPBSalida.BackColor = System.Drawing.Color.LightGreen
        Me.TxtPBSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPBSalida.Location = New System.Drawing.Point(641, 494)
        Me.TxtPBSalida.Name = "TxtPBSalida"
        Me.TxtPBSalida.Size = New System.Drawing.Size(116, 31)
        Me.TxtPBSalida.TabIndex = 252
        Me.TxtPBSalida.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(647, 468)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 24)
        Me.Label17.TabIndex = 251
        Me.Label17.Text = "PB Salida"
        Me.Label17.Visible = False
        '
        'TxtCantidadSalida
        '
        Me.TxtCantidadSalida.BackColor = System.Drawing.Color.LightGreen
        Me.TxtCantidadSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadSalida.Location = New System.Drawing.Point(649, 586)
        Me.TxtCantidadSalida.Name = "TxtCantidadSalida"
        Me.TxtCantidadSalida.Size = New System.Drawing.Size(80, 31)
        Me.TxtCantidadSalida.TabIndex = 250
        Me.TxtCantidadSalida.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(631, 557)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(115, 24)
        Me.Label18.TabIndex = 249
        Me.Label18.Text = "Cant Salida"
        Me.Label18.Visible = False
        '
        'TDBGridMerma
        '
        Me.TDBGridMerma.AllowUpdate = False
        Me.TDBGridMerma.AlternatingRows = True
        Me.TDBGridMerma.Caption = "Mermas por Categorias"
        Me.TDBGridMerma.CaptionHeight = 17
        Me.TDBGridMerma.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDBGridMerma.Images.Add(CType(resources.GetObject("TDBGridMerma.Images"), System.Drawing.Image))
        Me.TDBGridMerma.Location = New System.Drawing.Point(308, 5)
        Me.TDBGridMerma.Name = "TDBGridMerma"
        Me.TDBGridMerma.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDBGridMerma.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDBGridMerma.PreviewInfo.ZoomFactor = 75
        Me.TDBGridMerma.PrintInfo.PageSettings = CType(resources.GetObject("TDBGridMerma.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDBGridMerma.RowHeight = 22
        Me.TDBGridMerma.Size = New System.Drawing.Size(234, 168)
        Me.TDBGridMerma.TabIndex = 257
        Me.TDBGridMerma.Text = "C1TrueDBGrid6"
        Me.TDBGridMerma.PropBag = resources.GetString("TDBGridMerma.PropBag")
        '
        'CmdConfirma
        '
        Me.CmdConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdConfirma.ForeColor = System.Drawing.Color.Black
        Me.CmdConfirma.Image = CType(resources.GetObject("CmdConfirma.Image"), System.Drawing.Image)
        Me.CmdConfirma.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdConfirma.Location = New System.Drawing.Point(871, 538)
        Me.CmdConfirma.Name = "CmdConfirma"
        Me.CmdConfirma.Size = New System.Drawing.Size(101, 80)
        Me.CmdConfirma.TabIndex = 256
        Me.CmdConfirma.Text = "Confirmar"
        Me.CmdConfirma.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdConfirma.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(468, 356)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 33)
        Me.Button1.TabIndex = 255
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TDGridOrigen
        '
        Me.TDGridOrigen.AlternatingRows = True
        Me.TDGridOrigen.Caption = "PESADA DE ORIGEN"
        Me.TDGridOrigen.CaptionHeight = 17
        Me.TDGridOrigen.FilterBar = True
        Me.TDGridOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDGridOrigen.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridOrigen.Images.Add(CType(resources.GetObject("TDGridOrigen.Images"), System.Drawing.Image))
        Me.TDGridOrigen.Location = New System.Drawing.Point(545, 5)
        Me.TDGridOrigen.Name = "TDGridOrigen"
        Me.TDGridOrigen.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridOrigen.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridOrigen.PreviewInfo.ZoomFactor = 75
        Me.TDGridOrigen.PrintInfo.PageSettings = CType(resources.GetObject("TDGridOrigen.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridOrigen.RowHeight = 25
        Me.TDGridOrigen.Size = New System.Drawing.Size(427, 168)
        Me.TDGridOrigen.TabIndex = 254
        Me.TDGridOrigen.Text = "TDGridOrigen"
        Me.TDGridOrigen.PropBag = resources.GetString("TDGridOrigen.PropBag")
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(441, 573)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(101, 51)
        Me.Button9.TabIndex = 253
        Me.Button9.Text = "Salir"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button_Pesada_Maquila_Salida
        '
        Me.Button_Pesada_Maquila_Salida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Pesada_Maquila_Salida.Image = CType(resources.GetObject("Button_Pesada_Maquila_Salida.Image"), System.Drawing.Image)
        Me.Button_Pesada_Maquila_Salida.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Pesada_Maquila_Salida.Location = New System.Drawing.Point(871, 445)
        Me.Button_Pesada_Maquila_Salida.Name = "Button_Pesada_Maquila_Salida"
        Me.Button_Pesada_Maquila_Salida.Size = New System.Drawing.Size(101, 80)
        Me.Button_Pesada_Maquila_Salida.TabIndex = 244
        Me.Button_Pesada_Maquila_Salida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Pesada_Maquila_Salida.UseVisualStyleBackColor = True
        '
        'TDGribListRecibosSalida
        '
        Me.TDGribListRecibosSalida.AlternatingRows = True
        Me.TDGribListRecibosSalida.Caption = "PESADA DE SALIDA"
        Me.TDGribListRecibosSalida.CaptionHeight = 17
        Me.TDGribListRecibosSalida.FilterBar = True
        Me.TDGribListRecibosSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDGribListRecibosSalida.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGribListRecibosSalida.Images.Add(CType(resources.GetObject("TDGribListRecibosSalida.Images"), System.Drawing.Image))
        Me.TDGribListRecibosSalida.Location = New System.Drawing.Point(548, 445)
        Me.TDGribListRecibosSalida.Name = "TDGribListRecibosSalida"
        Me.TDGribListRecibosSalida.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGribListRecibosSalida.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGribListRecibosSalida.PreviewInfo.ZoomFactor = 75
        Me.TDGribListRecibosSalida.PrintInfo.PageSettings = CType(resources.GetObject("TDGribListRecibosSalida.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGribListRecibosSalida.RowHeight = 25
        Me.TDGribListRecibosSalida.Size = New System.Drawing.Size(295, 183)
        Me.TDGribListRecibosSalida.TabIndex = 243
        Me.TDGribListRecibosSalida.Text = "C1TrueDBGrid1"
        Me.TDGribListRecibosSalida.PropBag = resources.GetString("TDGribListRecibosSalida.PropBag")
        '
        'Button_Pesada_Maquila
        '
        Me.Button_Pesada_Maquila.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Pesada_Maquila.Image = CType(resources.GetObject("Button_Pesada_Maquila.Image"), System.Drawing.Image)
        Me.Button_Pesada_Maquila.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_Pesada_Maquila.Location = New System.Drawing.Point(871, 179)
        Me.Button_Pesada_Maquila.Name = "Button_Pesada_Maquila"
        Me.Button_Pesada_Maquila.Size = New System.Drawing.Size(101, 80)
        Me.Button_Pesada_Maquila.TabIndex = 242
        Me.Button_Pesada_Maquila.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Pesada_Maquila.UseVisualStyleBackColor = True
        '
        'TDGribListRecibos
        '
        Me.TDGribListRecibos.AlternatingRows = True
        Me.TDGribListRecibos.Caption = "PESADA DE ENTRADA"
        Me.TDGribListRecibos.CaptionHeight = 17
        Me.TDGribListRecibos.FilterBar = True
        Me.TDGribListRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDGribListRecibos.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGribListRecibos.Images.Add(CType(resources.GetObject("TDGribListRecibos.Images"), System.Drawing.Image))
        Me.TDGribListRecibos.Location = New System.Drawing.Point(548, 179)
        Me.TDGribListRecibos.Name = "TDGribListRecibos"
        Me.TDGribListRecibos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGribListRecibos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGribListRecibos.PreviewInfo.ZoomFactor = 75
        Me.TDGribListRecibos.PrintInfo.PageSettings = CType(resources.GetObject("TDGribListRecibos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGribListRecibos.RowHeight = 25
        Me.TDGribListRecibos.Size = New System.Drawing.Size(295, 225)
        Me.TDGribListRecibos.TabIndex = 241
        Me.TDGribListRecibos.Text = "C1TrueDBGrid1"
        Me.TDGribListRecibos.PropBag = resources.GetString("TDGribListRecibos.PropBag")
        '
        'BtnGuardarPInter
        '
        Me.BtnGuardarPInter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardarPInter.Image = Global.Remisiones.My.Resources.Resources.icons8_data_grid_36
        Me.BtnGuardarPInter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardarPInter.Location = New System.Drawing.Point(12, 572)
        Me.BtnGuardarPInter.Name = "BtnGuardarPInter"
        Me.BtnGuardarPInter.Size = New System.Drawing.Size(101, 51)
        Me.BtnGuardarPInter.TabIndex = 222
        Me.BtnGuardarPInter.Text = "Pegar"
        Me.BtnGuardarPInter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardarPInter.UseVisualStyleBackColor = True
        '
        'CmdPesada
        '
        Me.CmdPesada.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPesada.Image = CType(resources.GetObject("CmdPesada.Image"), System.Drawing.Image)
        Me.CmdPesada.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdPesada.Location = New System.Drawing.Point(635, 504)
        Me.CmdPesada.Name = "CmdPesada"
        Me.CmdPesada.Size = New System.Drawing.Size(101, 80)
        Me.CmdPesada.TabIndex = 239
        Me.CmdPesada.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdPesada.UseVisualStyleBackColor = True
        Me.CmdPesada.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(64, 329)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(111, 16)
        Me.Label37.TabIndex = 259
        Me.Label37.Text = "Numero Boleta"
        '
        'TxtNumeroBoleta
        '
        Me.TxtNumeroBoleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroBoleta.Location = New System.Drawing.Point(193, 320)
        Me.TxtNumeroBoleta.MaxLength = 6
        Me.TxtNumeroBoleta.Name = "TxtNumeroBoleta"
        Me.TxtNumeroBoleta.Size = New System.Drawing.Size(267, 29)
        Me.TxtNumeroBoleta.TabIndex = 258
        '
        'FrmPuntosInter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(984, 688)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.TxtNumeroBoleta)
        Me.Controls.Add(Me.TDBGridMerma)
        Me.Controls.Add(Me.CmdConfirma)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TDGridOrigen)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button_Pesada_Maquila_Salida)
        Me.Controls.Add(Me.TDGribListRecibosSalida)
        Me.Controls.Add(Me.Button_Pesada_Maquila)
        Me.Controls.Add(Me.TDGribListRecibos)
        Me.Controls.Add(Me.TxtIdPI)
        Me.Controls.Add(Me.CboConductor)
        Me.Controls.Add(Me.destino)
        Me.Controls.Add(Me.vehiculo)
        Me.Controls.Add(Me.conductor)
        Me.Controls.Add(Me.Empresa)
        Me.Controls.Add(Me.Origen)
        Me.Controls.Add(Me.BtnGuardarPInter)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.CboEmprsPlc)
        Me.Controls.Add(Me.CboEmpresaTrans)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtPBEntrada)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCantidadEntrada)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPBSalida)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtCantidadSalida)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CmdPesada)
        Me.MaximumSize = New System.Drawing.Size(1000, 726)
        Me.MinimumSize = New System.Drawing.Size(559, 726)
        Me.Name = "FrmPuntosInter"
        Me.Text = "FrmPuntosInter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CboLocOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEmprsPlc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEmpresaTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CboLocDest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboConductor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDBGridMerma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDGridOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDGribListRecibosSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDGribListRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPPICarga As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPPIEntrada As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DTPPISalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCantSacos As System.Windows.Forms.TextBox
    Friend WithEvents TxtPIPesoBruto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CboEmprsPlc As C1.Win.C1List.C1Combo
    Friend WithEvents CboEmpresaTrans As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CboLocDest As C1.Win.C1List.C1Combo
    Friend WithEvents TxtCantDest As System.Windows.Forms.TextBox
    Friend WithEvents TxtPesoBrutDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardarPInter As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CboLocOrigen As C1.Win.C1List.C1Combo
    Friend WithEvents Origen As System.Windows.Forms.TextBox
    Friend WithEvents Empresa As System.Windows.Forms.TextBox
    Friend WithEvents conductor As System.Windows.Forms.TextBox
    Friend WithEvents vehiculo As System.Windows.Forms.TextBox
    Friend WithEvents destino As System.Windows.Forms.TextBox
    Friend WithEvents CboConductor As C1.Win.C1List.C1Combo
    Friend WithEvents TxtIdPI As System.Windows.Forms.TextBox
    Friend WithEvents CmdPesada As System.Windows.Forms.Button
    Friend WithEvents TDGribListRecibos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button_Pesada_Maquila As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button_Pesada_Maquila_Salida As System.Windows.Forms.Button
    Friend WithEvents TDGribListRecibosSalida As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TxtCantidadEntrada As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPBEntrada As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPBSalida As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidadSalida As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents TDGridOrigen As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmdConfirma As System.Windows.Forms.Button
    Friend WithEvents TDBGridMerma As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroBoleta As System.Windows.Forms.TextBox
End Class
