<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductos))
        Me.CmdINgresoAjuste = New System.Windows.Forms.Button
        Me.CmdGastosAjuste = New System.Windows.Forms.Button
        Me.TxtGastoAjuste = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtIngresoAjuste = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtDescuento = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.ButtonBorrar = New System.Windows.Forms.Button
        Me.ButtonAgregar = New System.Windows.Forms.Button
        Me.CboCodigoProducto = New C1.Win.C1List.C1Combo
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNombreProducto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.BindingBodegas = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.C1TrueDBGrid3 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BindingComponentes = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingHistoricoCompras = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingHistoricosVentas = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingImpuestos = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CboExistencia = New System.Windows.Forms.ComboBox
        Me.CboActivo = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.CboUnidad = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtPrecioVentaC = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtPrecioVentaB = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtPrecioVentaA = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CboTipoProducto = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.TxtUbicacion = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.CmdAgregar = New System.Windows.Forms.Button
        Me.CmdBorrarFoto = New System.Windows.Forms.Button
        Me.ImgFoto = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCodigoProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TrueDBGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingHistoricoCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingHistoricosVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdINgresoAjuste
        '
        Me.CmdINgresoAjuste.Image = CType(resources.GetObject("CmdINgresoAjuste.Image"), System.Drawing.Image)
        Me.CmdINgresoAjuste.Location = New System.Drawing.Point(1017, 225)
        Me.CmdINgresoAjuste.Name = "CmdINgresoAjuste"
        Me.CmdINgresoAjuste.Size = New System.Drawing.Size(37, 38)
        Me.CmdINgresoAjuste.TabIndex = 29
        Me.CmdINgresoAjuste.UseVisualStyleBackColor = True
        Me.CmdINgresoAjuste.Visible = False
        '
        'CmdGastosAjuste
        '
        Me.CmdGastosAjuste.Image = CType(resources.GetObject("CmdGastosAjuste.Image"), System.Drawing.Image)
        Me.CmdGastosAjuste.Location = New System.Drawing.Point(1017, 267)
        Me.CmdGastosAjuste.Name = "CmdGastosAjuste"
        Me.CmdGastosAjuste.Size = New System.Drawing.Size(37, 38)
        Me.CmdGastosAjuste.TabIndex = 27
        Me.CmdGastosAjuste.UseVisualStyleBackColor = True
        Me.CmdGastosAjuste.Visible = False
        '
        'TxtGastoAjuste
        '
        Me.TxtGastoAjuste.Location = New System.Drawing.Point(893, 267)
        Me.TxtGastoAjuste.Name = "TxtGastoAjuste"
        Me.TxtGastoAjuste.Size = New System.Drawing.Size(118, 20)
        Me.TxtGastoAjuste.TabIndex = 8
        Me.TxtGastoAjuste.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(788, 267)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 13)
        Me.Label25.TabIndex = 28
        Me.Label25.Text = "Cta Gastos x Ajustes"
        Me.Label25.Visible = False
        '
        'TxtIngresoAjuste
        '
        Me.TxtIngresoAjuste.Location = New System.Drawing.Point(893, 225)
        Me.TxtIngresoAjuste.Name = "TxtIngresoAjuste"
        Me.TxtIngresoAjuste.Size = New System.Drawing.Size(118, 20)
        Me.TxtIngresoAjuste.TabIndex = 7
        Me.TxtIngresoAjuste.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(786, 224)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Cta Ingreso x Ajustes"
        Me.Label16.Visible = False
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Location = New System.Drawing.Point(363, 355)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(145, 20)
        Me.TxtDescuento.TabIndex = 10
        Me.TxtDescuento.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(278, 355)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Descuento"
        Me.Label7.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(714, 71)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(186, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(295, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "MANTENIMIENTO DE PRODUCTOS Y SERVICIOS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(70, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(605, 331)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 66)
        Me.Button8.TabIndex = 21
        Me.Button8.Text = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = CType(resources.GetObject("CmdNuevo.Image"), System.Drawing.Image)
        Me.CmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdNuevo.Location = New System.Drawing.Point(11, 327)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(75, 67)
        Me.CmdNuevo.TabIndex = 18
        Me.CmdNuevo.Text = "Nuevo"
        Me.CmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Image = CType(resources.GetObject("ButtonBorrar.Image"), System.Drawing.Image)
        Me.ButtonBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonBorrar.Location = New System.Drawing.Point(173, 327)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonBorrar.TabIndex = 20
        Me.ButtonBorrar.Text = "Eliminar"
        Me.ButtonBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Image = CType(resources.GetObject("ButtonAgregar.Image"), System.Drawing.Image)
        Me.ButtonAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonAgregar.Location = New System.Drawing.Point(92, 327)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 67)
        Me.ButtonAgregar.TabIndex = 19
        Me.ButtonAgregar.Text = "Guardar"
        Me.ButtonAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'CboCodigoProducto
        '
        Me.CboCodigoProducto.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCodigoProducto.Caption = ""
        Me.CboCodigoProducto.CaptionHeight = 17
        Me.CboCodigoProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCodigoProducto.ColumnCaptionHeight = 17
        Me.CboCodigoProducto.ColumnFooterHeight = 17
        Me.CboCodigoProducto.ContentHeight = 15
        Me.CboCodigoProducto.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCodigoProducto.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCodigoProducto.DropDownWidth = 400
        Me.CboCodigoProducto.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCodigoProducto.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCodigoProducto.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCodigoProducto.EditorHeight = 15
        Me.CboCodigoProducto.Images.Add(CType(resources.GetObject("CboCodigoProducto.Images"), System.Drawing.Image))
        Me.CboCodigoProducto.ItemHeight = 15
        Me.CboCodigoProducto.Location = New System.Drawing.Point(111, 92)
        Me.CboCodigoProducto.MatchEntryTimeout = CType(2000, Long)
        Me.CboCodigoProducto.MaxDropDownItems = CType(5, Short)
        Me.CboCodigoProducto.MaxLength = 32767
        Me.CboCodigoProducto.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCodigoProducto.Name = "CboCodigoProducto"
        Me.CboCodigoProducto.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCodigoProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCodigoProducto.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCodigoProducto.Size = New System.Drawing.Size(158, 21)
        Me.CboCodigoProducto.TabIndex = 0
        Me.CboCodigoProducto.PropBag = resources.GetString("CboCodigoProducto.PropBag")
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(276, 79)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(37, 38)
        Me.Button6.TabIndex = 1
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Codigo Producto"
        '
        'TxtNombreProducto
        '
        Me.TxtNombreProducto.Location = New System.Drawing.Point(407, 89)
        Me.TxtNombreProducto.Multiline = True
        Me.TxtNombreProducto.Name = "TxtNombreProducto"
        Me.TxtNombreProducto.Size = New System.Drawing.Size(270, 45)
        Me.TxtNombreProducto.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(319, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Nombre Producto"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button7.Location = New System.Drawing.Point(73, 216)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(55, 49)
        Me.Button7.TabIndex = 131
        Me.Button7.Text = "Quitar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(12, 216)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(55, 49)
        Me.Button9.TabIndex = 130
        Me.Button9.Text = "Agregar"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button9.UseVisualStyleBackColor = True
        '
        'C1TrueDBGrid3
        '
        Me.C1TrueDBGrid3.AlternatingRows = True
        Me.C1TrueDBGrid3.Caption = "Listado de Almacen"
        Me.C1TrueDBGrid3.FilterBar = True
        Me.C1TrueDBGrid3.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid3.Images.Add(CType(resources.GetObject("C1TrueDBGrid3.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid3.Location = New System.Drawing.Point(6, 19)
        Me.C1TrueDBGrid3.Name = "C1TrueDBGrid3"
        Me.C1TrueDBGrid3.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid3.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid3.PreviewInfo.ZoomFactor = 75
        Me.C1TrueDBGrid3.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid3.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid3.Size = New System.Drawing.Size(308, 185)
        Me.C1TrueDBGrid3.TabIndex = 129
        Me.C1TrueDBGrid3.Text = "C1TrueDBGrid1"
        Me.C1TrueDBGrid3.PropBag = resources.GetString("C1TrueDBGrid3.PropBag")
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(217, 114)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 25)
        Me.Button1.TabIndex = 117
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Location = New System.Drawing.Point(12, 140)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(668, 185)
        Me.TabControl.TabIndex = 118
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(660, 159)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CboExistencia)
        Me.GroupBox2.Controls.Add(Me.CboActivo)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.CboUnidad)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(306, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(284, 132)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informacion de Compras"
        '
        'CboExistencia
        '
        Me.CboExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboExistencia.FormattingEnabled = True
        Me.CboExistencia.Items.AddRange(New Object() {"SI", "NO"})
        Me.CboExistencia.Location = New System.Drawing.Point(117, 105)
        Me.CboExistencia.Name = "CboExistencia"
        Me.CboExistencia.Size = New System.Drawing.Size(123, 21)
        Me.CboExistencia.TabIndex = 12
        Me.CboExistencia.Visible = False
        '
        'CboActivo
        '
        Me.CboActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboActivo.FormattingEnabled = True
        Me.CboActivo.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.CboActivo.Location = New System.Drawing.Point(117, 43)
        Me.CboActivo.Name = "CboActivo"
        Me.CboActivo.Size = New System.Drawing.Size(123, 21)
        Me.CboActivo.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Activo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Existencia Negativa"
        Me.Label10.Visible = False
        '
        'CboUnidad
        '
        Me.CboUnidad.FormattingEnabled = True
        Me.CboUnidad.Location = New System.Drawing.Point(95, 19)
        Me.CboUnidad.Name = "CboUnidad"
        Me.CboUnidad.Size = New System.Drawing.Size(145, 21)
        Me.CboUnidad.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Unidad Medida"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPrecioVentaC)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TxtPrecioVentaB)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtPrecioVentaA)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CboTipoProducto)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.TxtUbicacion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 152)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales"
        '
        'TxtPrecioVentaC
        '
        Me.TxtPrecioVentaC.Location = New System.Drawing.Point(63, 115)
        Me.TxtPrecioVentaC.Name = "TxtPrecioVentaC"
        Me.TxtPrecioVentaC.Size = New System.Drawing.Size(210, 20)
        Me.TxtPrecioVentaC.TabIndex = 27
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Precio C"
        '
        'TxtPrecioVentaB
        '
        Me.TxtPrecioVentaB.Location = New System.Drawing.Point(63, 89)
        Me.TxtPrecioVentaB.Name = "TxtPrecioVentaB"
        Me.TxtPrecioVentaB.Size = New System.Drawing.Size(210, 20)
        Me.TxtPrecioVentaB.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Precio B"
        '
        'TxtPrecioVentaA
        '
        Me.TxtPrecioVentaA.Location = New System.Drawing.Point(63, 63)
        Me.TxtPrecioVentaA.Name = "TxtPrecioVentaA"
        Me.TxtPrecioVentaA.Size = New System.Drawing.Size(210, 20)
        Me.TxtPrecioVentaA.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Precio A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Tipo Producto"
        '
        'CboTipoProducto
        '
        Me.CboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoProducto.FormattingEnabled = True
        Me.CboTipoProducto.Items.AddRange(New Object() {"Insumos", "Productos", "Ensambles"})
        Me.CboTipoProducto.Location = New System.Drawing.Point(121, 13)
        Me.CboTipoProducto.Name = "CboTipoProducto"
        Me.CboTipoProducto.Size = New System.Drawing.Size(157, 21)
        Me.CboTipoProducto.TabIndex = 3
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(640, 83)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Location = New System.Drawing.Point(67, 37)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(210, 20)
        Me.TxtUbicacion.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Descripcion 2"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TxtNota)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.ImgFoto)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(660, 159)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Foto"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TxtNota
        '
        Me.TxtNota.AcceptsReturn = True
        Me.TxtNota.Location = New System.Drawing.Point(412, 134)
        Me.TxtNota.MaxLength = 250
        Me.TxtNota.Multiline = True
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNota.Size = New System.Drawing.Size(212, 42)
        Me.TxtNota.TabIndex = 4
        Me.TxtNota.Text = "Nota:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.CmdAgregar)
        Me.GroupBox6.Controls.Add(Me.CmdBorrarFoto)
        Me.GroupBox6.Location = New System.Drawing.Point(411, 19)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(219, 112)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Foto"
        '
        'CmdAgregar
        '
        Me.CmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAgregar.Image = CType(resources.GetObject("CmdAgregar.Image"), System.Drawing.Image)
        Me.CmdAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdAgregar.Location = New System.Drawing.Point(23, 19)
        Me.CmdAgregar.Name = "CmdAgregar"
        Me.CmdAgregar.Size = New System.Drawing.Size(75, 67)
        Me.CmdAgregar.TabIndex = 47
        Me.CmdAgregar.Text = "Agregar"
        Me.CmdAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdAgregar.UseVisualStyleBackColor = True
        '
        'CmdBorrarFoto
        '
        Me.CmdBorrarFoto.Image = CType(resources.GetObject("CmdBorrarFoto.Image"), System.Drawing.Image)
        Me.CmdBorrarFoto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdBorrarFoto.Location = New System.Drawing.Point(124, 19)
        Me.CmdBorrarFoto.Name = "CmdBorrarFoto"
        Me.CmdBorrarFoto.Size = New System.Drawing.Size(75, 67)
        Me.CmdBorrarFoto.TabIndex = 22
        Me.CmdBorrarFoto.Text = "Borrar"
        Me.CmdBorrarFoto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdBorrarFoto.UseVisualStyleBackColor = True
        '
        'ImgFoto
        '
        Me.ImgFoto.Image = CType(resources.GetObject("ImgFoto.Image"), System.Drawing.Image)
        Me.ImgFoto.Location = New System.Drawing.Point(16, 19)
        Me.ImgFoto.Name = "ImgFoto"
        Me.ImgFoto.Size = New System.Drawing.Size(389, 153)
        Me.ImgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgFoto.TabIndex = 1
        Me.ImgFoto.TabStop = False
        '
        'FrmProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 407)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CmdINgresoAjuste)
        Me.Controls.Add(Me.CmdGastosAjuste)
        Me.Controls.Add(Me.TxtNombreProducto)
        Me.Controls.Add(Me.TxtGastoAjuste)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.CboCodigoProducto)
        Me.Controls.Add(Me.TxtIngresoAjuste)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.TxtDescuento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmdNuevo)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Productos"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCodigoProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TrueDBGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingHistoricoCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingHistoricosVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.ImgFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents CboCodigoProducto As C1.Win.C1List.C1Combo
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TxtIngresoAjuste As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CmdGastosAjuste As System.Windows.Forms.Button
    Friend WithEvents TxtGastoAjuste As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CmdINgresoAjuste As System.Windows.Forms.Button
    Friend WithEvents BindingBodegas As System.Windows.Forms.BindingSource
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents C1TrueDBGrid3 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BindingComponentes As System.Windows.Forms.BindingSource
    Friend WithEvents BindingHistoricoCompras As System.Windows.Forms.BindingSource
    Friend WithEvents BindingHistoricosVentas As System.Windows.Forms.BindingSource
    Friend WithEvents BindingImpuestos As System.Windows.Forms.BindingSource
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CboExistencia As System.Windows.Forms.ComboBox
    Friend WithEvents CboActivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrecioVentaC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioVentaB As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioVentaA As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboTipoProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdAgregar As System.Windows.Forms.Button
    Friend WithEvents CmdBorrarFoto As System.Windows.Forms.Button
    Friend WithEvents ImgFoto As System.Windows.Forms.PictureBox

End Class
