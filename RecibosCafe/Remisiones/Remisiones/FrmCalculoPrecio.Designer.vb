<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCalculoPrecio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCalculoPrecio))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CboCosecha = New C1.Win.C1List.C1Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.CboTipoCalidad = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.CmdFiltrar = New System.Windows.Forms.Button
        Me.CboEdofisico = New System.Windows.Forms.ComboBox
        Me.CboImperfeccion = New System.Windows.Forms.ComboBox
        Me.CboTipDano = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.C1Combo1 = New C1.Win.C1List.C1Combo
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CboPrecio = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TrueDBGridComplemento = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.CmdActualizar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.ChkAplicar = New System.Windows.Forms.CheckBox
        Me.TxtComplemento = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CheckDatos = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LblDisD = New System.Windows.Forms.Label
        Me.LblDisC = New System.Windows.Forms.Label
        Me.LblDisB = New System.Windows.Forms.Label
        Me.LblDisA = New System.Windows.Forms.Label
        Me.LblRegiondiscre = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.LblPrecioDiscre = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BindingComponentes = New System.Windows.Forms.BindingSource(Me.components)
        Me.DTPFechaComple = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2.SuspendLayout()
        CType(Me.CboCosecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TrueDBGridComplemento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CboCosecha)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CboTipoCalidad)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.CmdFiltrar)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(468, 144)
        Me.GroupBox2.TabIndex = 206
        Me.GroupBox2.TabStop = False
        '
        'CboCosecha
        '
        Me.CboCosecha.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCosecha.AlternatingRows = True
        Me.CboCosecha.Caption = ""
        Me.CboCosecha.CaptionHeight = 17
        Me.CboCosecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCosecha.ColumnCaptionHeight = 17
        Me.CboCosecha.ColumnFooterHeight = 17
        Me.CboCosecha.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboCosecha.ContentHeight = 33
        Me.CboCosecha.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCosecha.DisplayMember = "NomLugarAcopio"
        Me.CboCosecha.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCosecha.DropDownWidth = 600
        Me.CboCosecha.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCosecha.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCosecha.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCosecha.EditorHeight = 33
        Me.CboCosecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCosecha.Images.Add(CType(resources.GetObject("CboCosecha.Images"), System.Drawing.Image))
        Me.CboCosecha.ItemHeight = 35
        Me.CboCosecha.Location = New System.Drawing.Point(80, 30)
        Me.CboCosecha.MatchEntryTimeout = CType(2000, Long)
        Me.CboCosecha.MaxDropDownItems = CType(6, Short)
        Me.CboCosecha.MaxLength = 32767
        Me.CboCosecha.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCosecha.Name = "CboCosecha"
        Me.CboCosecha.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCosecha.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCosecha.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCosecha.Size = New System.Drawing.Size(297, 39)
        Me.CboCosecha.TabIndex = 241
        Me.CboCosecha.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.CboCosecha.PropBag = resources.GetString("CboCosecha.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Cosecha"
        '
        'CboTipoCalidad
        '
        Me.CboTipoCalidad.DisplayMember = "Nombre"
        Me.CboTipoCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoCalidad.FormattingEnabled = True
        Me.CboTipoCalidad.Location = New System.Drawing.Point(80, 75)
        Me.CboTipoCalidad.Name = "CboTipoCalidad"
        Me.CboTipoCalidad.Size = New System.Drawing.Size(152, 33)
        Me.CboTipoCalidad.TabIndex = 238
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 16)
        Me.Label4.TabIndex = 232
        Me.Label4.Text = "Calidad"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(16, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 15)
        Me.Label11.TabIndex = 206
        Me.Label11.Text = "DATOS GENERALES"
        '
        'CmdFiltrar
        '
        Me.CmdFiltrar.Image = CType(resources.GetObject("CmdFiltrar.Image"), System.Drawing.Image)
        Me.CmdFiltrar.Location = New System.Drawing.Point(399, 29)
        Me.CmdFiltrar.Name = "CmdFiltrar"
        Me.CmdFiltrar.Size = New System.Drawing.Size(49, 44)
        Me.CmdFiltrar.TabIndex = 245
        Me.CmdFiltrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdFiltrar.UseVisualStyleBackColor = True
        '
        'CboEdofisico
        '
        Me.CboEdofisico.DisplayMember = "Descripcion"
        Me.CboEdofisico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEdofisico.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEdofisico.FormattingEnabled = True
        Me.CboEdofisico.Location = New System.Drawing.Point(1142, 233)
        Me.CboEdofisico.Name = "CboEdofisico"
        Me.CboEdofisico.Size = New System.Drawing.Size(152, 33)
        Me.CboEdofisico.TabIndex = 239
        Me.CboEdofisico.Visible = False
        '
        'CboImperfeccion
        '
        Me.CboImperfeccion.DisplayMember = "Nombre"
        Me.CboImperfeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboImperfeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboImperfeccion.FormattingEnabled = True
        Me.CboImperfeccion.Location = New System.Drawing.Point(1142, 195)
        Me.CboImperfeccion.Name = "CboImperfeccion"
        Me.CboImperfeccion.Size = New System.Drawing.Size(152, 32)
        Me.CboImperfeccion.TabIndex = 237
        Me.CboImperfeccion.Visible = False
        '
        'CboTipDano
        '
        Me.CboTipDano.DisplayMember = "Nombre"
        Me.CboTipDano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipDano.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipDano.FormattingEnabled = True
        Me.CboTipDano.Location = New System.Drawing.Point(1143, 272)
        Me.CboTipDano.Name = "CboTipDano"
        Me.CboTipDano.Size = New System.Drawing.Size(151, 32)
        Me.CboTipDano.TabIndex = 236
        Me.CboTipDano.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(1060, 204)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 16)
        Me.Label20.TabIndex = 235
        Me.Label20.Text = "Categoria"
        Me.Label20.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(1076, 277)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 16)
        Me.Label19.TabIndex = 234
        Me.Label19.Text = "Daño"
        Me.Label19.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(1047, 239)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 16)
        Me.Label16.TabIndex = 233
        Me.Label16.Text = "EdoFisico"
        Me.Label16.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 398)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(988, 17)
        Me.ProgressBar1.TabIndex = 247
        '
        'C1Combo1
        '
        Me.C1Combo1.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo1.AlternatingRows = True
        Me.C1Combo1.Caption = ""
        Me.C1Combo1.CaptionHeight = 17
        Me.C1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo1.ColumnCaptionHeight = 17
        Me.C1Combo1.ColumnFooterHeight = 17
        Me.C1Combo1.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.C1Combo1.ContentHeight = 33
        Me.C1Combo1.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo1.DisplayMember = "NomLugarAcopio"
        Me.C1Combo1.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.C1Combo1.DropDownWidth = 600
        Me.C1Combo1.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo1.EditorHeight = 33
        Me.C1Combo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo1.Images.Add(CType(resources.GetObject("C1Combo1.Images"), System.Drawing.Image))
        Me.C1Combo1.ItemHeight = 35
        Me.C1Combo1.Location = New System.Drawing.Point(74, 79)
        Me.C1Combo1.MatchEntryTimeout = CType(2000, Long)
        Me.C1Combo1.MaxDropDownItems = CType(6, Short)
        Me.C1Combo1.MaxLength = 32767
        Me.C1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo1.Name = "C1Combo1"
        Me.C1Combo1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo1.Size = New System.Drawing.Size(273, 39)
        Me.C1Combo1.TabIndex = 241
        Me.C1Combo1.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.C1Combo1.PropBag = resources.GetString("C1Combo1.PropBag")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 239
        '
        'ComboBox1
        '
        Me.ComboBox1.DisplayMember = "Nombre"
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(74, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(152, 33)
        Me.ComboBox1.TabIndex = 238
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(6, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 232
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(16, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 15)
        Me.Label5.TabIndex = 206
        '
        'CboPrecio
        '
        Me.CboPrecio.DisplayMember = "Nombre"
        Me.CboPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPrecio.Enabled = False
        Me.CboPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPrecio.FormattingEnabled = True
        Me.CboPrecio.Location = New System.Drawing.Point(1109, 146)
        Me.CboPrecio.Name = "CboPrecio"
        Me.CboPrecio.Size = New System.Drawing.Size(109, 33)
        Me.CboPrecio.TabIndex = 248
        Me.CboPrecio.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TrueDBGridComplemento)
        Me.GroupBox1.Controls.Add(Me.CmdActualizar)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ChkAplicar)
        Me.GroupBox1.Controls.Add(Me.TxtComplemento)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Location = New System.Drawing.Point(481, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 144)
        Me.GroupBox1.TabIndex = 249
        Me.GroupBox1.TabStop = False
        '
        'TrueDBGridComplemento
        '
        Me.TrueDBGridComplemento.AlternatingRows = True
        Me.TrueDBGridComplemento.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComplemento.Images.Add(CType(resources.GetObject("TrueDBGridComplemento.Images"), System.Drawing.Image))
        Me.TrueDBGridComplemento.Location = New System.Drawing.Point(172, 20)
        Me.TrueDBGridComplemento.Name = "TrueDBGridComplemento"
        Me.TrueDBGridComplemento.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComplemento.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComplemento.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComplemento.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComplemento.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComplemento.Size = New System.Drawing.Size(281, 116)
        Me.TrueDBGridComplemento.TabIndex = 254
        Me.TrueDBGridComplemento.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComplemento.PropBag = resources.GetString("TrueDBGridComplemento.PropBag")
        '
        'CmdActualizar
        '
        Me.CmdActualizar.Image = CType(resources.GetObject("CmdActualizar.Image"), System.Drawing.Image)
        Me.CmdActualizar.Location = New System.Drawing.Point(459, 19)
        Me.CmdActualizar.Name = "CmdActualizar"
        Me.CmdActualizar.Size = New System.Drawing.Size(54, 50)
        Me.CmdActualizar.TabIndex = 253
        Me.CmdActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdActualizar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(4, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(160, 16)
        Me.Label7.TabIndex = 252
        Me.Label7.Text = "Precio Complemento :"
        '
        'ChkAplicar
        '
        Me.ChkAplicar.AutoSize = True
        Me.ChkAplicar.Checked = True
        Me.ChkAplicar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAplicar.ForeColor = System.Drawing.Color.White
        Me.ChkAplicar.Location = New System.Drawing.Point(7, 75)
        Me.ChkAplicar.Name = "ChkAplicar"
        Me.ChkAplicar.Size = New System.Drawing.Size(125, 20)
        Me.ChkAplicar.TabIndex = 250
        Me.ChkAplicar.Text = "Aplicar Todos"
        Me.ChkAplicar.UseVisualStyleBackColor = True
        Me.ChkAplicar.Visible = False
        '
        'TxtComplemento
        '
        Me.TxtComplemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComplemento.Location = New System.Drawing.Point(349, 115)
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(164, 29)
        Me.TxtComplemento.TabIndex = 249
        Me.TxtComplemento.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(22, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 15)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "APLICACION"
        '
        'CheckDatos
        '
        Me.CheckDatos.AutoSize = True
        Me.CheckDatos.Checked = True
        Me.CheckDatos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckDatos.ForeColor = System.Drawing.Color.White
        Me.CheckDatos.Location = New System.Drawing.Point(1070, 332)
        Me.CheckDatos.Name = "CheckDatos"
        Me.CheckDatos.Size = New System.Drawing.Size(187, 20)
        Me.CheckDatos.TabIndex = 255
        Me.CheckDatos.Text = "Ver Datos Discrecional"
        Me.CheckDatos.UseVisualStyleBackColor = True
        Me.CheckDatos.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LblDisD)
        Me.GroupBox3.Controls.Add(Me.LblDisC)
        Me.GroupBox3.Controls.Add(Me.LblDisB)
        Me.GroupBox3.Controls.Add(Me.LblDisA)
        Me.GroupBox3.Controls.Add(Me.LblRegiondiscre)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox3.Location = New System.Drawing.Point(1079, 358)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(113, 17)
        Me.GroupBox3.TabIndex = 254
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Discrecional"
        Me.GroupBox3.Visible = False
        '
        'LblDisD
        '
        Me.LblDisD.AutoSize = True
        Me.LblDisD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblDisD.Location = New System.Drawing.Point(79, 120)
        Me.LblDisD.Name = "LblDisD"
        Me.LblDisD.Size = New System.Drawing.Size(16, 13)
        Me.LblDisD.TabIndex = 261
        Me.LblDisD.Text = "D"
        '
        'LblDisC
        '
        Me.LblDisC.AutoSize = True
        Me.LblDisC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblDisC.Location = New System.Drawing.Point(79, 97)
        Me.LblDisC.Name = "LblDisC"
        Me.LblDisC.Size = New System.Drawing.Size(15, 13)
        Me.LblDisC.TabIndex = 260
        Me.LblDisC.Text = "C"
        '
        'LblDisB
        '
        Me.LblDisB.AutoSize = True
        Me.LblDisB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblDisB.Location = New System.Drawing.Point(78, 75)
        Me.LblDisB.Name = "LblDisB"
        Me.LblDisB.Size = New System.Drawing.Size(15, 13)
        Me.LblDisB.TabIndex = 259
        Me.LblDisB.Text = "B"
        '
        'LblDisA
        '
        Me.LblDisA.AutoSize = True
        Me.LblDisA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblDisA.Location = New System.Drawing.Point(78, 53)
        Me.LblDisA.Name = "LblDisA"
        Me.LblDisA.Size = New System.Drawing.Size(15, 13)
        Me.LblDisA.TabIndex = 258
        Me.LblDisA.Text = "A"
        '
        'LblRegiondiscre
        '
        Me.LblRegiondiscre.AutoSize = True
        Me.LblRegiondiscre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegiondiscre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblRegiondiscre.Location = New System.Drawing.Point(30, 21)
        Me.LblRegiondiscre.Name = "LblRegiondiscre"
        Me.LblRegiondiscre.Size = New System.Drawing.Size(47, 13)
        Me.LblRegiondiscre.TabIndex = 257
        Me.LblRegiondiscre.Text = "Region"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(3, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 256
        Me.Label14.Text = "Discre.D :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(3, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 255
        Me.Label13.Text = "Discre.C :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(3, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 254
        Me.Label12.Text = "Discre.B :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(3, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 253
        Me.Label10.Text = "Discre.A :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(1052, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 251
        Me.Label6.Text = "Precio"
        Me.Label6.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(13, 450)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 24)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Discrecional :"
        Me.Label9.Visible = False
        '
        'LblPrecioDiscre
        '
        Me.LblPrecioDiscre.AutoSize = True
        Me.LblPrecioDiscre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecioDiscre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.LblPrecioDiscre.Location = New System.Drawing.Point(152, 451)
        Me.LblPrecioDiscre.Name = "LblPrecioDiscre"
        Me.LblPrecioDiscre.Size = New System.Drawing.Size(49, 24)
        Me.LblPrecioDiscre.TabIndex = 253
        Me.LblPrecioDiscre.Text = "0.00"
        Me.LblPrecioDiscre.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Remisiones.My.Resources.Resources.save
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(717, 434)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 58)
        Me.Button1.TabIndex = 254
        Me.Button1.Text = "Guardar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(865, 434)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(135, 58)
        Me.Button9.TabIndex = 250
        Me.Button9.Text = "Salir"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Precios Calculados"
        Me.TrueDBGridComponentes.CaptionHeight = 17
        Me.TrueDBGridComponentes.FilterBar = True
        Me.TrueDBGridComponentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(12, 163)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.RowHeight = 15
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(988, 229)
        Me.TrueDBGridComponentes.TabIndex = 246
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'DTPFechaComple
        '
        Me.DTPFechaComple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFechaComple.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaComple.Location = New System.Drawing.Point(1055, 78)
        Me.DTPFechaComple.Name = "DTPFechaComple"
        Me.DTPFechaComple.Size = New System.Drawing.Size(78, 20)
        Me.DTPFechaComple.TabIndex = 255
        Me.DTPFechaComple.Visible = False
        '
        'FrmCalculoPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.CheckDatos)
        Me.Controls.Add(Me.DTPFechaComple)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LblPrecioDiscre)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CboEdofisico)
        Me.Controls.Add(Me.CboTipDano)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.CboPrecio)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.CboImperfeccion)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1044, 700)
        Me.MinimumSize = New System.Drawing.Size(1044, 493)
        Me.Name = "FrmCalculoPrecio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculo de Precio Pergamino"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CboCosecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TrueDBGridComplemento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CboEdofisico As System.Windows.Forms.ComboBox
    Friend WithEvents CboTipoCalidad As System.Windows.Forms.ComboBox
    Friend WithEvents CboImperfeccion As System.Windows.Forms.ComboBox
    Friend WithEvents CboTipDano As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmdFiltrar As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboCosecha As C1.Win.C1List.C1Combo
    Friend WithEvents C1Combo1 As C1.Win.C1List.C1Combo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChkAplicar As System.Windows.Forms.CheckBox
    Friend WithEvents TxtComplemento As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CmdActualizar As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblPrecioDiscre As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BindingComponentes As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblRegiondiscre As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckDatos As System.Windows.Forms.CheckBox
    Friend WithEvents LblDisD As System.Windows.Forms.Label
    Friend WithEvents LblDisC As System.Windows.Forms.Label
    Friend WithEvents LblDisB As System.Windows.Forms.Label
    Friend WithEvents LblDisA As System.Windows.Forms.Label
    Friend WithEvents DTPFechaComple As System.Windows.Forms.DateTimePicker
    Friend WithEvents TrueDBGridComplemento As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
