<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCarga))
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtNBoleta = New System.Windows.Forms.TextBox
        Me.LblFecha = New System.Windows.Forms.Label
        Me.TxtNumeroEnsamble = New System.Windows.Forms.TextBox
        Me.LblHora = New System.Windows.Forms.Label
        Me.lblbdega = New System.Windows.Forms.Label
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.lbldatosre = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPlaca = New C1.Win.C1List.C1Combo
        Me.CboCodigoProveedor = New C1.Win.C1List.C1Combo
        Me.datosprov = New System.Windows.Forms.Label
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.lblnombre = New System.Windows.Forms.Label
        Me.lblproveedor = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.LblSucursal = New System.Windows.Forms.Label
        Me.TrueDBGridComponentes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LblCosecha = New System.Windows.Forms.Label
        Me.BindingDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.TxtPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.GroupBox9.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox9.Controls.Add(Me.Label2)
        Me.GroupBox9.Controls.Add(Me.TxtNBoleta)
        Me.GroupBox9.Controls.Add(Me.LblFecha)
        Me.GroupBox9.Controls.Add(Me.TxtNumeroEnsamble)
        Me.GroupBox9.Controls.Add(Me.LblHora)
        Me.GroupBox9.Controls.Add(Me.lblbdega)
        Me.GroupBox9.Controls.Add(Me.DTPFecha)
        Me.GroupBox9.Controls.Add(Me.lbldatosre)
        Me.GroupBox9.Location = New System.Drawing.Point(511, 86)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(466, 135)
        Me.GroupBox9.TabIndex = 179
        Me.GroupBox9.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 24)
        Me.Label2.TabIndex = 187
        Me.Label2.Text = "No Boleta"
        '
        'TxtNBoleta
        '
        Me.TxtNBoleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNBoleta.Location = New System.Drawing.Point(117, 92)
        Me.TxtNBoleta.MaxLength = 6
        Me.TxtNBoleta.Name = "TxtNBoleta"
        Me.TxtNBoleta.Size = New System.Drawing.Size(108, 29)
        Me.TxtNBoleta.TabIndex = 186
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.ForeColor = System.Drawing.Color.White
        Me.LblFecha.Location = New System.Drawing.Point(4, 33)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(242, 39)
        Me.LblFecha.TabIndex = 184
        Me.LblFecha.Text = "10:23:55 p.m."
        '
        'TxtNumeroEnsamble
        '
        Me.TxtNumeroEnsamble.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroEnsamble.Location = New System.Drawing.Point(360, 92)
        Me.TxtNumeroEnsamble.Name = "TxtNumeroEnsamble"
        Me.TxtNumeroEnsamble.Size = New System.Drawing.Size(92, 29)
        Me.TxtNumeroEnsamble.TabIndex = 182
        Me.TxtNumeroEnsamble.Text = "-----0-----"
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.White
        Me.LblHora.Location = New System.Drawing.Point(222, 33)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(242, 39)
        Me.LblHora.TabIndex = 180
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'lblbdega
        '
        Me.lblbdega.AutoSize = True
        Me.lblbdega.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbdega.ForeColor = System.Drawing.Color.White
        Me.lblbdega.Location = New System.Drawing.Point(231, 94)
        Me.lblbdega.Name = "lblbdega"
        Me.lblbdega.Size = New System.Drawing.Size(123, 25)
        Me.lblbdega.TabIndex = 181
        Me.lblbdega.Text = "Nº CARGA"
        '
        'DTPFecha
        '
        Me.DTPFecha.Enabled = False
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(-139, -42)
        Me.DTPFecha.Margin = New System.Windows.Forms.Padding(5)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(229, 47)
        Me.DTPFecha.TabIndex = 179
        Me.DTPFecha.Visible = False
        '
        'lbldatosre
        '
        Me.lbldatosre.AutoSize = True
        Me.lbldatosre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatosre.ForeColor = System.Drawing.Color.White
        Me.lbldatosre.Location = New System.Drawing.Point(52, -1)
        Me.lbldatosre.Name = "lbldatosre"
        Me.lbldatosre.Size = New System.Drawing.Size(153, 20)
        Me.lbldatosre.TabIndex = 176
        Me.lbldatosre.Text = "DATOS DE CARGA"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.Button2)
        Me.GroupBox6.Controls.Add(Me.Button14)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.TxtPlaca)
        Me.GroupBox6.Controls.Add(Me.CboCodigoProveedor)
        Me.GroupBox6.Controls.Add(Me.datosprov)
        Me.GroupBox6.Controls.Add(Me.txtnombre)
        Me.GroupBox6.Controls.Add(Me.lblnombre)
        Me.GroupBox6.Controls.Add(Me.lblproveedor)
        Me.GroupBox6.Location = New System.Drawing.Point(0, 86)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(505, 135)
        Me.GroupBox6.TabIndex = 178
        Me.GroupBox6.TabStop = False
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(411, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 64)
        Me.Button2.TabIndex = 187
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Image = CType(resources.GetObject("Button14.Image"), System.Drawing.Image)
        Me.Button14.Location = New System.Drawing.Point(249, 24)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(64, 32)
        Me.Button14.TabIndex = 186
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 185
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
        Me.TxtPlaca.Location = New System.Drawing.Point(71, 90)
        Me.TxtPlaca.MatchEntryTimeout = CType(2000, Long)
        Me.TxtPlaca.MaxDropDownItems = CType(6, Short)
        Me.TxtPlaca.MaxLength = 32767
        Me.TxtPlaca.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.TxtPlaca.Name = "TxtPlaca"
        Me.TxtPlaca.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.TxtPlaca.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.TxtPlaca.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.TxtPlaca.Size = New System.Drawing.Size(334, 39)
        Me.TxtPlaca.TabIndex = 184
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
        Me.CboCodigoProveedor.Location = New System.Drawing.Point(71, 24)
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
        Me.datosprov.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.datosprov.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datosprov.ForeColor = System.Drawing.Color.White
        Me.datosprov.Location = New System.Drawing.Point(44, -1)
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
        Me.txtnombre.Size = New System.Drawing.Size(334, 24)
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
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.LblSucursal)
        Me.GroupBox5.Location = New System.Drawing.Point(82, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(412, 59)
        Me.GroupBox5.TabIndex = 224
        Me.GroupBox5.TabStop = False
        '
        'LblSucursal
        '
        Me.LblSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblSucursal.AutoSize = True
        Me.LblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSucursal.ForeColor = System.Drawing.Color.White
        Me.LblSucursal.Location = New System.Drawing.Point(33, 19)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(249, 31)
        Me.LblSucursal.TabIndex = 32
        Me.LblSucursal.Text = "SUCURSAL xxxxx"
        '
        'TrueDBGridComponentes
        '
        Me.TrueDBGridComponentes.AlternatingRows = True
        Me.TrueDBGridComponentes.Caption = "Listado de Recepciones"
        Me.TrueDBGridComponentes.CaptionHeight = 17
        Me.TrueDBGridComponentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrueDBGridComponentes.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridComponentes.Images.Add(CType(resources.GetObject("TrueDBGridComponentes.Images"), System.Drawing.Image))
        Me.TrueDBGridComponentes.Location = New System.Drawing.Point(0, 236)
        Me.TrueDBGridComponentes.Name = "TrueDBGridComponentes"
        Me.TrueDBGridComponentes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridComponentes.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridComponentes.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridComponentes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridComponentes.RowHeight = 15
        Me.TrueDBGridComponentes.Size = New System.Drawing.Size(977, 255)
        Me.TrueDBGridComponentes.TabIndex = 225
        Me.TrueDBGridComponentes.Text = "C1TrueDBGrid1"
        Me.TrueDBGridComponentes.PropBag = resources.GetString("TrueDBGridComponentes.PropBag")
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(833, 538)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(144, 85)
        Me.Button9.TabIndex = 227
        Me.Button9.Text = "Salir"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(683, 539)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(144, 85)
        Me.Button7.TabIndex = 226
        Me.Button7.Text = "Grabar"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(533, 540)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 84)
        Me.Button1.TabIndex = 228
        Me.Button1.Text = "Consultar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.LblCosecha)
        Me.GroupBox3.Location = New System.Drawing.Point(511, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 59)
        Me.GroupBox3.TabIndex = 229
        Me.GroupBox3.TabStop = False
        '
        'LblCosecha
        '
        Me.LblCosecha.AutoSize = True
        Me.LblCosecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCosecha.ForeColor = System.Drawing.Color.White
        Me.LblCosecha.Location = New System.Drawing.Point(11, 21)
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Size = New System.Drawing.Size(223, 25)
        Me.LblCosecha.TabIndex = 184
        Me.LblCosecha.Text = "Cosecha 2011-2015"
        '
        'FrmCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 635)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.TrueDBGridComponentes)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox6)
        Me.Name = "FrmCarga"
        Me.Text = "FrmCarga"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.TxtPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.TrueDBGridComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.BindingDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbldatosre As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CboCodigoProveedor As C1.Win.C1List.C1Combo
    Friend WithEvents datosprov As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents lblnombre As System.Windows.Forms.Label
    Friend WithEvents lblproveedor As System.Windows.Forms.Label
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents LblSucursal As System.Windows.Forms.Label
    Friend WithEvents TrueDBGridComponentes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BindingDetalle As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LblCosecha As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroEnsamble As System.Windows.Forms.TextBox
    Friend WithEvents lblbdega As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPlaca As C1.Win.C1List.C1Combo
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtNBoleta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
