<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultas))
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TrueDBGridConsultas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LblEncabezado = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BindingConsultas = New System.Windows.Forms.BindingSource(Me.components)
        Me.CmdPesada = New System.Windows.Forms.Button
        Me.TxtFiltro = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.DtpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.LblInicio = New System.Windows.Forms.Label
        Me.LblFin = New System.Windows.Forms.Label
        Me.CmdFiltrar = New System.Windows.Forms.Button
        Me.CmdActualizar = New System.Windows.Forms.Button
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Image = CType(resources.GetObject("ButtonSalir.Image"), System.Drawing.Image)
        Me.ButtonSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonSalir.Location = New System.Drawing.Point(529, 307)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(75, 69)
        Me.ButtonSalir.TabIndex = 27
        Me.ButtonSalir.Text = "Salir"
        Me.ButtonSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonSalir.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(12, 308)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 69)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Pegar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TrueDBGridConsultas
        '
        Me.TrueDBGridConsultas.AllowUpdate = False
        Me.TrueDBGridConsultas.AlternatingRows = True
        Me.TrueDBGridConsultas.Caption = "CONSULTAS"
        Me.TrueDBGridConsultas.FilterBar = True
        Me.TrueDBGridConsultas.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBGridConsultas.Images.Add(CType(resources.GetObject("TrueDBGridConsultas.Images"), System.Drawing.Image))
        Me.TrueDBGridConsultas.Location = New System.Drawing.Point(12, 80)
        Me.TrueDBGridConsultas.Name = "TrueDBGridConsultas"
        Me.TrueDBGridConsultas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBGridConsultas.PreviewInfo.ZoomFactor = 75
        Me.TrueDBGridConsultas.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBGridConsultas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBGridConsultas.Size = New System.Drawing.Size(592, 222)
        Me.TrueDBGridConsultas.TabIndex = 28
        Me.TrueDBGridConsultas.Text = "C1TrueDBGrid1"
        Me.TrueDBGridConsultas.PropBag = resources.GetString("TrueDBGridConsultas.PropBag")
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(-2, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(666, 73)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'LblEncabezado
        '
        Me.LblEncabezado.AutoSize = True
        Me.LblEncabezado.BackColor = System.Drawing.Color.White
        Me.LblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEncabezado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblEncabezado.Location = New System.Drawing.Point(241, 31)
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Size = New System.Drawing.Size(81, 13)
        Me.LblEncabezado.TabIndex = 30
        Me.LblEncabezado.Text = "CONSULTAS"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(10, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(83, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 31
        Me.PictureBox2.TabStop = False
        '
        'CmdPesada
        '
        Me.CmdPesada.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPesada.Image = CType(resources.GetObject("CmdPesada.Image"), System.Drawing.Image)
        Me.CmdPesada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPesada.Location = New System.Drawing.Point(99, 308)
        Me.CmdPesada.Name = "CmdPesada"
        Me.CmdPesada.Size = New System.Drawing.Size(104, 69)
        Me.CmdPesada.TabIndex = 237
        Me.CmdPesada.Text = "Agregar"
        Me.CmdPesada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPesada.UseVisualStyleBackColor = True
        Me.CmdPesada.Visible = False
        '
        'TxtFiltro
        '
        Me.TxtFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFiltro.Location = New System.Drawing.Point(280, 308)
        Me.TxtFiltro.Name = "TxtFiltro"
        Me.TxtFiltro.Size = New System.Drawing.Size(243, 31)
        Me.TxtFiltro.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(137, 318)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 16)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Buscar Proveedor"
        '
        'DtpFechaIni
        '
        Me.DtpFechaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaIni.Location = New System.Drawing.Point(280, 342)
        Me.DtpFechaIni.Name = "DtpFechaIni"
        Me.DtpFechaIni.Size = New System.Drawing.Size(188, 35)
        Me.DtpFechaIni.TabIndex = 240
        Me.DtpFechaIni.Visible = False
        '
        'DtpFechaFin
        '
        Me.DtpFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaFin.Location = New System.Drawing.Point(280, 381)
        Me.DtpFechaFin.Name = "DtpFechaFin"
        Me.DtpFechaFin.Size = New System.Drawing.Size(188, 35)
        Me.DtpFechaFin.TabIndex = 241
        Me.DtpFechaFin.Visible = False
        '
        'LblInicio
        '
        Me.LblInicio.AutoSize = True
        Me.LblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInicio.ForeColor = System.Drawing.Color.Maroon
        Me.LblInicio.Location = New System.Drawing.Point(228, 352)
        Me.LblInicio.Name = "LblInicio"
        Me.LblInicio.Size = New System.Drawing.Size(45, 16)
        Me.LblInicio.TabIndex = 242
        Me.LblInicio.Text = "Inicio"
        Me.LblInicio.Visible = False
        '
        'LblFin
        '
        Me.LblFin.AutoSize = True
        Me.LblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFin.ForeColor = System.Drawing.Color.Maroon
        Me.LblFin.Location = New System.Drawing.Point(241, 391)
        Me.LblFin.Name = "LblFin"
        Me.LblFin.Size = New System.Drawing.Size(29, 16)
        Me.LblFin.TabIndex = 243
        Me.LblFin.Text = "Fin"
        Me.LblFin.Visible = False
        '
        'CmdFiltrar
        '
        Me.CmdFiltrar.Image = CType(resources.GetObject("CmdFiltrar.Image"), System.Drawing.Image)
        Me.CmdFiltrar.Location = New System.Drawing.Point(470, 342)
        Me.CmdFiltrar.Name = "CmdFiltrar"
        Me.CmdFiltrar.Size = New System.Drawing.Size(49, 35)
        Me.CmdFiltrar.TabIndex = 244
        Me.CmdFiltrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdFiltrar.UseVisualStyleBackColor = True
        Me.CmdFiltrar.Visible = False
        '
        'CmdActualizar
        '
        Me.CmdActualizar.Image = CType(resources.GetObject("CmdActualizar.Image"), System.Drawing.Image)
        Me.CmdActualizar.Location = New System.Drawing.Point(468, 379)
        Me.CmdActualizar.Name = "CmdActualizar"
        Me.CmdActualizar.Size = New System.Drawing.Size(53, 44)
        Me.CmdActualizar.TabIndex = 245
        Me.CmdActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdActualizar.UseVisualStyleBackColor = True
        '
        'FrmConsultas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 425)
        Me.Controls.Add(Me.CmdActualizar)
        Me.Controls.Add(Me.CmdFiltrar)
        Me.Controls.Add(Me.LblFin)
        Me.Controls.Add(Me.LblInicio)
        Me.Controls.Add(Me.DtpFechaFin)
        Me.Controls.Add(Me.DtpFechaIni)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtFiltro)
        Me.Controls.Add(Me.CmdPesada)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LblEncabezado)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TrueDBGridConsultas)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.Button2)
        Me.Name = "FrmConsultas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultas"
        CType(Me.TrueDBGridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Protected WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TrueDBGridConsultas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblEncabezado As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BindingConsultas As System.Windows.Forms.BindingSource
    Friend WithEvents CmdPesada As System.Windows.Forms.Button
    Friend WithEvents TxtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblInicio As System.Windows.Forms.Label
    Friend WithEvents LblFin As System.Windows.Forms.Label
    Friend WithEvents CmdFiltrar As System.Windows.Forms.Button
    Friend WithEvents CmdActualizar As System.Windows.Forms.Button
End Class
