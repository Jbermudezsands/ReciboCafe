<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportes))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTPFechaFinal = New System.Windows.Forms.DateTimePicker
        Me.DTPFechaInicial = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Button15 = New System.Windows.Forms.Button
        Me.CboLocalidad = New C1.Win.C1List.C1Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.CboUnidadRL = New C1.Win.C1List.C1Combo
        Me.CboCalidadRL = New C1.Win.C1List.C1Combo
        Me.lblproveedor = New System.Windows.Forms.Label
        Me.CboEstado = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.BtnImprimir = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.CboLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.CboUnidadRL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCalidadRL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(388, 34)
        Me.GroupBox2.TabIndex = 237
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(140, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "Filtro de Fecha"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.DTPFechaFinal)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.DTPFechaInicial)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(406, 91)
        Me.GroupBox3.TabIndex = 250
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(202, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 240
        Me.Label3.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Desde"
        '
        'DTPFechaFinal
        '
        Me.DTPFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFinal.Location = New System.Drawing.Point(252, 48)
        Me.DTPFechaFinal.Name = "DTPFechaFinal"
        Me.DTPFechaFinal.Size = New System.Drawing.Size(142, 31)
        Me.DTPFechaFinal.TabIndex = 238
        '
        'DTPFechaInicial
        '
        Me.DTPFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicial.Location = New System.Drawing.Point(54, 46)
        Me.DTPFechaInicial.Name = "DTPFechaInicial"
        Me.DTPFechaInicial.Size = New System.Drawing.Size(142, 31)
        Me.DTPFechaInicial.TabIndex = 178
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(436, 34)
        Me.GroupBox1.TabIndex = 234
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(172, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 235
        Me.Label4.Text = "Filtro"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.Button15)
        Me.GroupBox6.Controls.Add(Me.CboLocalidad)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.GroupBox7)
        Me.GroupBox6.Controls.Add(Me.GroupBox1)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.CboUnidadRL)
        Me.GroupBox6.Controls.Add(Me.CboCalidadRL)
        Me.GroupBox6.Controls.Add(Me.lblproveedor)
        Me.GroupBox6.Location = New System.Drawing.Point(424, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(445, 194)
        Me.GroupBox6.TabIndex = 251
        Me.GroupBox6.TabStop = False
        '
        'Button15
        '
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.Location = New System.Drawing.Point(393, 147)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(35, 38)
        Me.Button15.TabIndex = 244
        Me.Button15.UseVisualStyleBackColor = True
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
        Me.CboLocalidad.Location = New System.Drawing.Point(114, 147)
        Me.CboLocalidad.MatchEntryTimeout = CType(2000, Long)
        Me.CboLocalidad.MaxDropDownItems = CType(6, Short)
        Me.CboLocalidad.MaxLength = 32767
        Me.CboLocalidad.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboLocalidad.Name = "CboLocalidad"
        Me.CboLocalidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboLocalidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboLocalidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboLocalidad.Size = New System.Drawing.Size(273, 39)
        Me.CboLocalidad.TabIndex = 243
        Me.CboLocalidad.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.CboLocalidad.PropBag = resources.GetString("CboLocalidad.PropBag")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(10, 157)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 20)
        Me.Label18.TabIndex = 241
        Me.Label18.Text = "Localidad"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Location = New System.Drawing.Point(5, 109)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(434, 34)
        Me.GroupBox7.TabIndex = 235
        Me.GroupBox7.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(170, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 235
        Me.Label5.Text = "Localidad"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(16, 87)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 15)
        Me.Label21.TabIndex = 233
        Me.Label21.Text = "U.Medida"
        '
        'CboUnidadRL
        '
        Me.CboUnidadRL.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboUnidadRL.AlternatingRows = True
        Me.CboUnidadRL.Caption = ""
        Me.CboUnidadRL.CaptionHeight = 17
        Me.CboUnidadRL.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboUnidadRL.ColumnCaptionHeight = 17
        Me.CboUnidadRL.ColumnFooterHeight = 17
        Me.CboUnidadRL.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboUnidadRL.ContentHeight = 26
        Me.CboUnidadRL.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboUnidadRL.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboUnidadRL.DropDownWidth = 300
        Me.CboUnidadRL.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboUnidadRL.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboUnidadRL.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboUnidadRL.EditorHeight = 26
        Me.CboUnidadRL.Images.Add(CType(resources.GetObject("CboUnidadRL.Images"), System.Drawing.Image))
        Me.CboUnidadRL.ItemHeight = 35
        Me.CboUnidadRL.Location = New System.Drawing.Point(114, 81)
        Me.CboUnidadRL.MatchEntryTimeout = CType(2000, Long)
        Me.CboUnidadRL.MaxDropDownItems = CType(5, Short)
        Me.CboUnidadRL.MaxLength = 32767
        Me.CboUnidadRL.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboUnidadRL.Name = "CboUnidadRL"
        Me.CboUnidadRL.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboUnidadRL.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboUnidadRL.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboUnidadRL.Size = New System.Drawing.Size(150, 32)
        Me.CboUnidadRL.TabIndex = 232
        Me.CboUnidadRL.PropBag = resources.GetString("CboUnidadRL.PropBag")
        '
        'CboCalidadRL
        '
        Me.CboCalidadRL.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCalidadRL.AlternatingRows = True
        Me.CboCalidadRL.Caption = ""
        Me.CboCalidadRL.CaptionHeight = 17
        Me.CboCalidadRL.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCalidadRL.ColumnCaptionHeight = 17
        Me.CboCalidadRL.ColumnFooterHeight = 17
        Me.CboCalidadRL.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCalidadRL.ContentHeight = 26
        Me.CboCalidadRL.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCalidadRL.DisplayMember = "Nombre"
        Me.CboCalidadRL.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCalidadRL.DropDownWidth = 300
        Me.CboCalidadRL.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCalidadRL.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCalidadRL.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCalidadRL.EditorHeight = 26
        Me.CboCalidadRL.Images.Add(CType(resources.GetObject("CboCalidadRL.Images"), System.Drawing.Image))
        Me.CboCalidadRL.ItemHeight = 35
        Me.CboCalidadRL.Location = New System.Drawing.Point(114, 46)
        Me.CboCalidadRL.MatchEntryTimeout = CType(2000, Long)
        Me.CboCalidadRL.MaxDropDownItems = CType(5, Short)
        Me.CboCalidadRL.MaxLength = 32767
        Me.CboCalidadRL.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCalidadRL.Name = "CboCalidadRL"
        Me.CboCalidadRL.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCalidadRL.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCalidadRL.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCalidadRL.Size = New System.Drawing.Size(150, 32)
        Me.CboCalidadRL.TabIndex = 183
        Me.CboCalidadRL.PropBag = resources.GetString("CboCalidadRL.PropBag")
        '
        'lblproveedor
        '
        Me.lblproveedor.AutoSize = True
        Me.lblproveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblproveedor.Location = New System.Drawing.Point(15, 51)
        Me.lblproveedor.Name = "lblproveedor"
        Me.lblproveedor.Size = New System.Drawing.Size(56, 15)
        Me.lblproveedor.TabIndex = 2
        Me.lblproveedor.Text = "Calidad"
        '
        'CboEstado
        '
        Me.CboEstado.DisplayMember = "Descripcion"
        Me.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEstado.FormattingEnabled = True
        Me.CboEstado.Location = New System.Drawing.Point(198, 52)
        Me.CboEstado.Name = "CboEstado"
        Me.CboEstado.Size = New System.Drawing.Size(196, 33)
        Me.CboEstado.TabIndex = 253
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(31, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 20)
        Me.Label11.TabIndex = 252
        Me.Label11.Text = "Estado Fisico"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.CboEstado)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 102)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(406, 104)
        Me.GroupBox4.TabIndex = 254
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(388, 34)
        Me.GroupBox5.TabIndex = 237
        Me.GroupBox5.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(119, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 15)
        Me.Label7.TabIndex = 235
        Me.Label7.Text = "Filtro Estado Fisico"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Image = Global.Remisiones.My.Resources.Resources.icons8_print_48
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(875, 19)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(131, 48)
        Me.BtnImprimir.TabIndex = 255
        Me.BtnImprimir.Text = "IMPRIMIR"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Remisiones.My.Resources.Resources.Exit_64
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(875, 231)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 49)
        Me.Button1.TabIndex = 256
        Me.Button1.Text = "SALIR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(18, 221)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(851, 30)
        Me.ProgressBar1.TabIndex = 257
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(538, 257)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(331, 23)
        Me.ProgressBar2.TabIndex = 258
        '
        'FrmReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1018, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "FrmReportes"
        Me.Text = "FrmReportes"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.CboLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.CboUnidadRL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCalidadRL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CboUnidadRL As C1.Win.C1List.C1Combo
    Friend WithEvents CboCalidadRL As C1.Win.C1List.C1Combo
    Friend WithEvents lblproveedor As System.Windows.Forms.Label
    Friend WithEvents CboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboLocalidad As C1.Win.C1List.C1Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
End Class
