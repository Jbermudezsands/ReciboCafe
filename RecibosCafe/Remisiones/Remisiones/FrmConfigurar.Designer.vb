<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigurar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfigurar))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtRutaLogo = New System.Windows.Forms.TextBox
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.TxtRuc = New System.Windows.Forms.TextBox
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.TxtNombreEmpresa = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ImgLogo = New System.Windows.Forms.PictureBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.CmdGrabar = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbLocalidad = New C1.Win.C1List.C1Combo
        Me.CmbCosecha = New C1.Win.C1List.C1Combo
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbCosecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(9, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(70, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 81
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(118, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(311, 13)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "CONFIGURACION DEL SISTEMA  DE FACTURACION"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(533, 71)
        Me.PictureBox1.TabIndex = 79
        Me.PictureBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(478, 238)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(37, 38)
        Me.Button4.TabIndex = 78
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 259)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Ruta Logo"
        '
        'TxtRutaLogo
        '
        Me.TxtRutaLogo.Location = New System.Drawing.Point(71, 256)
        Me.TxtRutaLogo.Name = "TxtRutaLogo"
        Me.TxtRutaLogo.Size = New System.Drawing.Size(401, 20)
        Me.TxtRutaLogo.TabIndex = 76
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(278, 212)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(240, 20)
        Me.TxtTelefono.TabIndex = 75
        '
        'TxtRuc
        '
        Me.TxtRuc.Location = New System.Drawing.Point(278, 185)
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.Size = New System.Drawing.Size(240, 20)
        Me.TxtRuc.TabIndex = 74
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(278, 113)
        Me.TxtDireccion.Multiline = True
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(240, 66)
        Me.TxtDireccion.TabIndex = 73
        '
        'TxtNombreEmpresa
        '
        Me.TxtNombreEmpresa.Location = New System.Drawing.Point(278, 87)
        Me.TxtNombreEmpresa.Name = "TxtNombreEmpresa"
        Me.TxtNombreEmpresa.Size = New System.Drawing.Size(240, 20)
        Me.TxtNombreEmpresa.TabIndex = 72
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(183, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Telefono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(182, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Numero Ruc"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Direccion Empresa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(183, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Nombre Empresa"
        '
        'ImgLogo
        '
        Me.ImgLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ImgLogo.Location = New System.Drawing.Point(6, 77)
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.Size = New System.Drawing.Size(170, 155)
        Me.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgLogo.TabIndex = 67
        Me.ImgLogo.TabStop = False
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(437, 292)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 68)
        Me.Button2.TabIndex = 83
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.Image = CType(resources.GetObject("CmdGrabar.Image"), System.Drawing.Image)
        Me.CmdGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdGrabar.Location = New System.Drawing.Point(355, 293)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(78, 68)
        Me.CmdGrabar.TabIndex = 82
        Me.CmdGrabar.Text = "Grabar"
        Me.CmdGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdGrabar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 285)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Localidad"
        '
        'CmbLocalidad
        '
        Me.CmbLocalidad.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbLocalidad.Caption = ""
        Me.CmbLocalidad.CaptionHeight = 17
        Me.CmbLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbLocalidad.ColumnCaptionHeight = 17
        Me.CmbLocalidad.ColumnFooterHeight = 17
        Me.CmbLocalidad.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CmbLocalidad.ContentHeight = 15
        Me.CmbLocalidad.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbLocalidad.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbLocalidad.DropDownWidth = 250
        Me.CmbLocalidad.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbLocalidad.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbLocalidad.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbLocalidad.EditorHeight = 15
        Me.CmbLocalidad.Images.Add(CType(resources.GetObject("CmbLocalidad.Images"), System.Drawing.Image))
        Me.CmbLocalidad.ItemHeight = 15
        Me.CmbLocalidad.Location = New System.Drawing.Point(71, 280)
        Me.CmbLocalidad.MatchEntryTimeout = CType(2000, Long)
        Me.CmbLocalidad.MaxDropDownItems = CType(5, Short)
        Me.CmbLocalidad.MaxLength = 32767
        Me.CmbLocalidad.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbLocalidad.Name = "CmbLocalidad"
        Me.CmbLocalidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbLocalidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbLocalidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbLocalidad.Size = New System.Drawing.Size(144, 21)
        Me.CmbLocalidad.TabIndex = 85
        Me.CmbLocalidad.PropBag = resources.GetString("CmbLocalidad.PropBag")
        '
        'CmbCosecha
        '
        Me.CmbCosecha.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CmbCosecha.Caption = ""
        Me.CmbCosecha.CaptionHeight = 17
        Me.CmbCosecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CmbCosecha.ColumnCaptionHeight = 17
        Me.CmbCosecha.ColumnFooterHeight = 17
        Me.CmbCosecha.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CmbCosecha.ContentHeight = 15
        Me.CmbCosecha.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CmbCosecha.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CmbCosecha.DropDownWidth = 350
        Me.CmbCosecha.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CmbCosecha.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCosecha.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbCosecha.EditorHeight = 15
        Me.CmbCosecha.Images.Add(CType(resources.GetObject("CmbCosecha.Images"), System.Drawing.Image))
        Me.CmbCosecha.ItemHeight = 15
        Me.CmbCosecha.Location = New System.Drawing.Point(71, 308)
        Me.CmbCosecha.MatchEntryTimeout = CType(2000, Long)
        Me.CmbCosecha.MaxDropDownItems = CType(5, Short)
        Me.CmbCosecha.MaxLength = 32767
        Me.CmbCosecha.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CmbCosecha.Name = "CmbCosecha"
        Me.CmbCosecha.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CmbCosecha.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CmbCosecha.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CmbCosecha.Size = New System.Drawing.Size(144, 21)
        Me.CmbCosecha.TabIndex = 87
        Me.CmbCosecha.PropBag = resources.GetString("CmbCosecha.PropBag")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 313)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Cosecha"
        '
        'Button15
        '
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.Location = New System.Drawing.Point(234, 280)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(34, 32)
        Me.Button15.TabIndex = 238
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(271, 293)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 68)
        Me.Button1.TabIndex = 239
        Me.Button1.Text = "Impresoras"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmConfigurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 370)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.CmbCosecha)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmbLocalidad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtRutaLogo)
        Me.Controls.Add(Me.TxtTelefono)
        Me.Controls.Add(Me.TxtRuc)
        Me.Controls.Add(Me.TxtDireccion)
        Me.Controls.Add(Me.TxtNombreEmpresa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ImgLogo)
        Me.Name = "FrmConfigurar"
        Me.Text = "FrmConfigurar"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbCosecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtRutaLogo As System.Windows.Forms.TextBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TxtRuc As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombreEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CmdGrabar As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbLocalidad As C1.Win.C1List.C1Combo
    Friend WithEvents CmbCosecha As C1.Win.C1List.C1Combo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
