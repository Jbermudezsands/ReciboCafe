<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmResumenLiquidacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmResumenLiquidacion))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TDGridResumenLiquidacion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.CboUnidadRL = New C1.Win.C1List.C1Combo
        Me.CboCalidadRL = New C1.Win.C1List.C1Combo
        Me.lblproveedor = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.BtnFiltrar = New System.Windows.Forms.Button
        Me.BtnImprimir = New System.Windows.Forms.Button
        Me.BtnRefrescar = New System.Windows.Forms.Button
        Me.BtnVer = New System.Windows.Forms.Button
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.DTPFechaInicial = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CboMeses = New System.Windows.Forms.ComboBox
        Me.CboAnoRL = New C1.Win.C1List.C1Combo
        Me.DTPFechaFinal = New System.Windows.Forms.DateTimePicker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RbPorRango = New System.Windows.Forms.RadioButton
        Me.RbPorMeses = New System.Windows.Forms.RadioButton
        Me.Eventos = New System.Windows.Forms.GroupBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.BindingResumenLiqui = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.TDGridResumenLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CboUnidadRL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCalidadRL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CboAnoRL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Eventos.SuspendLayout()
        CType(Me.BindingResumenLiqui, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(123, 23)
        Me.TabControl1.Location = New System.Drawing.Point(9, 216)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(984, 305)
        Me.TabControl1.TabIndex = 238
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TDGridResumenLiquidacion)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(976, 274)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle Recibos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TDGridResumenLiquidacion
        '
        Me.TDGridResumenLiquidacion.AlternatingRows = True
        Me.TDGridResumenLiquidacion.Caption = "Listado de Productos"
        Me.TDGridResumenLiquidacion.CaptionHeight = 17
        Me.TDGridResumenLiquidacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TDGridResumenLiquidacion.FilterBar = True
        Me.TDGridResumenLiquidacion.GroupByCaption = "Drag a column header here to group by that column"
        Me.TDGridResumenLiquidacion.Images.Add(CType(resources.GetObject("TDGridResumenLiquidacion.Images"), System.Drawing.Image))
        Me.TDGridResumenLiquidacion.Location = New System.Drawing.Point(3, 3)
        Me.TDGridResumenLiquidacion.Name = "TDGridResumenLiquidacion"
        Me.TDGridResumenLiquidacion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TDGridResumenLiquidacion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TDGridResumenLiquidacion.PreviewInfo.ZoomFactor = 75
        Me.TDGridResumenLiquidacion.PrintInfo.PageSettings = CType(resources.GetObject("TDGridResumenLiquidacion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TDGridResumenLiquidacion.RowHeight = 15
        Me.TDGridResumenLiquidacion.Size = New System.Drawing.Size(970, 268)
        Me.TDGridResumenLiquidacion.TabIndex = 212
        Me.TDGridResumenLiquidacion.Text = "C1TrueDBGrid1"
        Me.TDGridResumenLiquidacion.PropBag = resources.GetString("TDGridResumenLiquidacion.PropBag")
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.GroupBox1)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.CboUnidadRL)
        Me.GroupBox6.Controls.Add(Me.CboCalidadRL)
        Me.GroupBox6.Controls.Add(Me.lblproveedor)
        Me.GroupBox6.Location = New System.Drawing.Point(10, 62)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(296, 135)
        Me.GroupBox6.TabIndex = 236
        Me.GroupBox6.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 34)
        Me.GroupBox1.TabIndex = 234
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(128, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 15)
        Me.Label1.TabIndex = 235
        Me.Label1.Text = "Filtro"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(16, 96)
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
        Me.CboUnidadRL.Location = New System.Drawing.Point(114, 90)
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
        Me.CboCalidadRL.Location = New System.Drawing.Point(114, 50)
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
        Me.lblproveedor.Location = New System.Drawing.Point(15, 55)
        Me.lblproveedor.Name = "lblproveedor"
        Me.lblproveedor.Size = New System.Drawing.Size(56, 15)
        Me.lblproveedor.TabIndex = 2
        Me.lblproveedor.Text = "Calidad"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox7.Controls.Add(Me.BtnFiltrar)
        Me.GroupBox7.Controls.Add(Me.BtnImprimir)
        Me.GroupBox7.Controls.Add(Me.BtnRefrescar)
        Me.GroupBox7.Controls.Add(Me.BtnVer)
        Me.GroupBox7.Controls.Add(Me.BtnNuevo)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(984, 60)
        Me.GroupBox7.TabIndex = 240
        Me.GroupBox7.TabStop = False
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltrar.Image = Global.Remisiones.My.Resources.Resources.Filter_48
        Me.BtnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFiltrar.Location = New System.Drawing.Point(655, 9)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(131, 48)
        Me.BtnFiltrar.TabIndex = 254
        Me.BtnFiltrar.Text = "FILTRAR"
        Me.BtnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Enabled = False
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Image = Global.Remisiones.My.Resources.Resources.icons8_print_48
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(850, 9)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(131, 48)
        Me.BtnImprimir.TabIndex = 253
        Me.BtnImprimir.Text = "IMPRIMIR"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefrescar.Image = Global.Remisiones.My.Resources.Resources.Refresh48
        Me.BtnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRefrescar.Location = New System.Drawing.Point(424, 9)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(131, 48)
        Me.BtnRefrescar.TabIndex = 252
        Me.BtnRefrescar.Text = "REFRESCAR"
        Me.BtnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRefrescar.UseVisualStyleBackColor = True
        '
        'BtnVer
        '
        Me.BtnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVer.Image = Global.Remisiones.My.Resources.Resources.Seen48
        Me.BtnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVer.Location = New System.Drawing.Point(215, 9)
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(131, 48)
        Me.BtnVer.TabIndex = 251
        Me.BtnVer.Text = "VER     "
        Me.BtnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVer.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = Global.Remisiones.My.Resources.Resources.New48__2_
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(1, 9)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(131, 48)
        Me.BtnNuevo.TabIndex = 250
        Me.BtnNuevo.Text = "NUEVO "
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'DTPFechaInicial
        '
        Me.DTPFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaInicial.Location = New System.Drawing.Point(205, 90)
        Me.DTPFechaInicial.Name = "DTPFechaInicial"
        Me.DTPFechaInicial.Size = New System.Drawing.Size(182, 31)
        Me.DTPFechaInicial.TabIndex = 178
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(644, 34)
        Me.GroupBox2.TabIndex = 236
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(284, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "Filtro de Fecha"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CboMeses)
        Me.GroupBox3.Controls.Add(Me.CboAnoRL)
        Me.GroupBox3.Controls.Add(Me.DTPFechaFinal)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.DTPFechaInicial)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Location = New System.Drawing.Point(349, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(644, 135)
        Me.GroupBox3.TabIndex = 249
        Me.GroupBox3.TabStop = False
        '
        'CboMeses
        '
        Me.CboMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMeses.FormattingEnabled = True
        Me.CboMeses.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.CboMeses.Location = New System.Drawing.Point(205, 42)
        Me.CboMeses.Name = "CboMeses"
        Me.CboMeses.Size = New System.Drawing.Size(182, 33)
        Me.CboMeses.TabIndex = 241
        '
        'CboAnoRL
        '
        Me.CboAnoRL.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboAnoRL.AlternatingRows = True
        Me.CboAnoRL.Caption = ""
        Me.CboAnoRL.CaptionHeight = 17
        Me.CboAnoRL.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboAnoRL.ColumnCaptionHeight = 17
        Me.CboAnoRL.ColumnFooterHeight = 17
        Me.CboAnoRL.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboAnoRL.ContentHeight = 26
        Me.CboAnoRL.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboAnoRL.DisplayMember = "Nombre"
        Me.CboAnoRL.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboAnoRL.DropDownWidth = 300
        Me.CboAnoRL.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboAnoRL.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAnoRL.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboAnoRL.EditorHeight = 26
        Me.CboAnoRL.Images.Add(CType(resources.GetObject("CboAnoRL.Images"), System.Drawing.Image))
        Me.CboAnoRL.ItemHeight = 35
        Me.CboAnoRL.Location = New System.Drawing.Point(450, 42)
        Me.CboAnoRL.MatchEntryTimeout = CType(2000, Long)
        Me.CboAnoRL.MaxDropDownItems = CType(5, Short)
        Me.CboAnoRL.MaxLength = 32767
        Me.CboAnoRL.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboAnoRL.Name = "CboAnoRL"
        Me.CboAnoRL.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboAnoRL.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboAnoRL.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboAnoRL.Size = New System.Drawing.Size(182, 32)
        Me.CboAnoRL.TabIndex = 240
        Me.CboAnoRL.PropBag = resources.GetString("CboAnoRL.PropBag")
        '
        'DTPFechaFinal
        '
        Me.DTPFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaFinal.Location = New System.Drawing.Point(450, 90)
        Me.DTPFechaFinal.Name = "DTPFechaFinal"
        Me.DTPFechaFinal.Size = New System.Drawing.Size(182, 31)
        Me.DTPFechaFinal.TabIndex = 238
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RbPorRango)
        Me.GroupBox4.Controls.Add(Me.RbPorMeses)
        Me.GroupBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GroupBox4.Location = New System.Drawing.Point(6, 33)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(188, 97)
        Me.GroupBox4.TabIndex = 237
        Me.GroupBox4.TabStop = False
        '
        'RbPorRango
        '
        Me.RbPorRango.AutoSize = True
        Me.RbPorRango.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbPorRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPorRango.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RbPorRango.Location = New System.Drawing.Point(22, 52)
        Me.RbPorRango.Name = "RbPorRango"
        Me.RbPorRango.Size = New System.Drawing.Size(117, 24)
        Me.RbPorRango.TabIndex = 2
        Me.RbPorRango.Text = "Por Rango "
        Me.RbPorRango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbPorRango.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RbPorRango.UseVisualStyleBackColor = True
        '
        'RbPorMeses
        '
        Me.RbPorMeses.AutoSize = True
        Me.RbPorMeses.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbPorMeses.Checked = True
        Me.RbPorMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbPorMeses.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RbPorMeses.Location = New System.Drawing.Point(24, 17)
        Me.RbPorMeses.Name = "RbPorMeses"
        Me.RbPorMeses.Size = New System.Drawing.Size(117, 24)
        Me.RbPorMeses.TabIndex = 1
        Me.RbPorMeses.TabStop = True
        Me.RbPorMeses.Text = "Por Mes     "
        Me.RbPorMeses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbPorMeses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RbPorMeses.UseVisualStyleBackColor = True
        '
        'Eventos
        '
        Me.Eventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Eventos.Controls.Add(Me.Button9)
        Me.Eventos.Controls.Add(Me.Button4)
        Me.Eventos.Location = New System.Drawing.Point(9, 524)
        Me.Eventos.Name = "Eventos"
        Me.Eventos.Size = New System.Drawing.Size(984, 87)
        Me.Eventos.TabIndex = 237
        Me.Eventos.TabStop = False
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = Global.Remisiones.My.Resources.Resources.Exit_64
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(853, 10)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(127, 75)
        Me.Button9.TabIndex = 226
        Me.Button9.Text = "Salir"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(4, 9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(122, 75)
        Me.Button4.TabIndex = 183
        Me.Button4.Text = "Consultar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'FrmResumenLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1019, 616)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Eventos)
        Me.Controls.Add(Me.GroupBox6)
        Me.MaximumSize = New System.Drawing.Size(1035, 654)
        Me.MinimumSize = New System.Drawing.Size(1035, 654)
        Me.Name = "FrmResumenLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPendientesLiquid"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.TDGridResumenLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CboUnidadRL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCalidadRL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CboAnoRL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Eventos.ResumeLayout(False)
        CType(Me.BindingResumenLiqui, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CboUnidadRL As C1.Win.C1List.C1Combo
    Friend WithEvents CboCalidadRL As C1.Win.C1List.C1Combo
    Friend WithEvents lblproveedor As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RbPorMeses As System.Windows.Forms.RadioButton
    Friend WithEvents RbPorRango As System.Windows.Forms.RadioButton
    Friend WithEvents DTPFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboAnoRL As C1.Win.C1List.C1Combo
    Friend WithEvents CboMeses As System.Windows.Forms.ComboBox
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents BtnVer As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Eventos As System.Windows.Forms.GroupBox
    Friend WithEvents BindingResumenLiqui As System.Windows.Forms.BindingSource
    Friend WithEvents TDGridResumenLiquidacion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
