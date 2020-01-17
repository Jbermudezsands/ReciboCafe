<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListRecibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListRecibo))
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnPegar = New System.Windows.Forms.Button
        Me.BtnBajar = New System.Windows.Forms.Button
        Me.BtnSubir = New System.Windows.Forms.Button
        Me.BtnCancelar = New System.Windows.Forms.Button
        Me.GribListRecibos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.BinRecibosLista = New System.Windows.Forms.BindingSource(Me.components)
        Me.CheckTodosRecibos = New System.Windows.Forms.CheckBox
        Me.BtnPegar2 = New System.Windows.Forms.Button
        CType(Me.GribListRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinRecibosLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Check3.png")
        Me.ImageList.Images.SetKeyName(1, "Uncheked3.png")
        '
        'BtnPegar
        '
        Me.BtnPegar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPegar.Image = Global.Remisiones.My.Resources.Resources.icons8_data_grid_36
        Me.BtnPegar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPegar.Location = New System.Drawing.Point(864, 395)
        Me.BtnPegar.Name = "BtnPegar"
        Me.BtnPegar.Size = New System.Drawing.Size(99, 47)
        Me.BtnPegar.TabIndex = 8
        Me.BtnPegar.Text = "PEGAR"
        Me.BtnPegar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPegar.UseVisualStyleBackColor = True
        '
        'BtnBajar
        '
        Me.BtnBajar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnBajar.Image = Global.Remisiones.My.Resources.Resources.icons8_clasificar_abajo_48
        Me.BtnBajar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBajar.Location = New System.Drawing.Point(861, 54)
        Me.BtnBajar.Name = "BtnBajar"
        Me.BtnBajar.Size = New System.Drawing.Size(99, 38)
        Me.BtnBajar.TabIndex = 7
        Me.BtnBajar.Text = "Bajar"
        Me.BtnBajar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBajar.UseVisualStyleBackColor = True
        '
        'BtnSubir
        '
        Me.BtnSubir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubir.Image = Global.Remisiones.My.Resources.Resources.icons8_clasificar_arriba_48
        Me.BtnSubir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSubir.Location = New System.Drawing.Point(861, 12)
        Me.BtnSubir.Name = "BtnSubir"
        Me.BtnSubir.Size = New System.Drawing.Size(99, 38)
        Me.BtnSubir.TabIndex = 6
        Me.BtnSubir.Text = "Subir"
        Me.BtnSubir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSubir.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = Global.Remisiones.My.Resources.Resources.icons8_exit_36
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(864, 455)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(99, 45)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "SALIR"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'GribListRecibos
        '
        Me.GribListRecibos.AlternatingRows = True
        Me.GribListRecibos.Caption = "Lista de Recibos "
        Me.GribListRecibos.CaptionHeight = 17
        Me.GribListRecibos.FilterBar = True
        Me.GribListRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GribListRecibos.GroupByCaption = "Drag a column header here to group by that column"
        Me.GribListRecibos.Images.Add(CType(resources.GetObject("GribListRecibos.Images"), System.Drawing.Image))
        Me.GribListRecibos.Location = New System.Drawing.Point(12, 12)
        Me.GribListRecibos.Name = "GribListRecibos"
        Me.GribListRecibos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.GribListRecibos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.GribListRecibos.PreviewInfo.ZoomFactor = 75
        Me.GribListRecibos.PrintInfo.PageSettings = CType(resources.GetObject("GribListRecibos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.GribListRecibos.RowHeight = 25
        Me.GribListRecibos.Size = New System.Drawing.Size(843, 489)
        Me.GribListRecibos.TabIndex = 0
        Me.GribListRecibos.Text = "C1TrueDBGrid1"
        Me.GribListRecibos.PropBag = resources.GetString("GribListRecibos.PropBag")
        '
        'CheckTodosRecibos
        '
        Me.CheckTodosRecibos.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CheckTodosRecibos.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckTodosRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.CheckTodosRecibos.ForeColor = System.Drawing.Color.White
        Me.CheckTodosRecibos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckTodosRecibos.Location = New System.Drawing.Point(864, 115)
        Me.CheckTodosRecibos.Name = "CheckTodosRecibos"
        Me.CheckTodosRecibos.Size = New System.Drawing.Size(99, 40)
        Me.CheckTodosRecibos.TabIndex = 258
        Me.CheckTodosRecibos.Text = "Seleccion Todos"
        Me.CheckTodosRecibos.UseVisualStyleBackColor = True
        '
        'BtnPegar2
        '
        Me.BtnPegar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPegar2.Image = Global.Remisiones.My.Resources.Resources.icons8_data_grid_36
        Me.BtnPegar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPegar2.Location = New System.Drawing.Point(864, 342)
        Me.BtnPegar2.Name = "BtnPegar2"
        Me.BtnPegar2.Size = New System.Drawing.Size(99, 47)
        Me.BtnPegar2.TabIndex = 259
        Me.BtnPegar2.Text = "PEGAR"
        Me.BtnPegar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPegar2.UseVisualStyleBackColor = True
        Me.BtnPegar2.Visible = False
        '
        'FrmListRecibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(972, 508)
        Me.Controls.Add(Me.BtnPegar2)
        Me.Controls.Add(Me.CheckTodosRecibos)
        Me.Controls.Add(Me.BtnPegar)
        Me.Controls.Add(Me.BtnBajar)
        Me.Controls.Add(Me.BtnSubir)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GribListRecibos)
        Me.Name = "FrmListRecibo"
        Me.Text = "FrmListRecibo"
        CType(Me.GribListRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinRecibosLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GribListRecibos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents BtnSubir As System.Windows.Forms.Button
    Friend WithEvents BtnBajar As System.Windows.Forms.Button
    Friend WithEvents BtnPegar As System.Windows.Forms.Button
    Friend WithEvents BinRecibosLista As System.Windows.Forms.BindingSource
    Friend WithEvents CheckTodosRecibos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnPegar2 As System.Windows.Forms.Button
End Class
