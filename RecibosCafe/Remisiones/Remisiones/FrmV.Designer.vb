<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVinculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVinculo))
        Me.ListCalidad = New System.Windows.Forms.ListBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.ListCategoria = New C1.Win.C1List.C1List
        CType(Me.ListCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListCalidad
        '
        Me.ListCalidad.DisplayMember = "Nombre"
        Me.ListCalidad.FormattingEnabled = True
        Me.ListCalidad.Location = New System.Drawing.Point(12, 12)
        Me.ListCalidad.Name = "ListCalidad"
        Me.ListCalidad.Size = New System.Drawing.Size(208, 238)
        Me.ListCalidad.TabIndex = 1
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(352, 260)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(114, 86)
        Me.Button9.TabIndex = 186
        Me.Button9.Text = "Salir"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(12, 256)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(114, 87)
        Me.Button7.TabIndex = 185
        Me.Button7.Text = "Grabar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'ListCategoria
        '
        Me.ListCategoria.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.ListCategoria.Caption = ""
        Me.ListCategoria.CaptionHeight = 17
        Me.ListCategoria.ColumnCaptionHeight = 17
        Me.ListCategoria.ColumnFooterHeight = 17
        Me.ListCategoria.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.ListCategoria.Images.Add(CType(resources.GetObject("ListCategoria.Images"), System.Drawing.Image))
        Me.ListCategoria.ItemHeight = 15
        Me.ListCategoria.Location = New System.Drawing.Point(252, 12)
        Me.ListCategoria.MatchEntryTimeout = CType(2000, Long)
        Me.ListCategoria.Name = "ListCategoria"
        Me.ListCategoria.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.ListCategoria.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.ListCategoria.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.ListCategoria.Size = New System.Drawing.Size(214, 238)
        Me.ListCategoria.TabIndex = 187
        Me.ListCategoria.Text = "C1List1"
        Me.ListCategoria.PropBag = resources.GetString("ListCategoria.PropBag")
        '
        'FrmVinculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(478, 358)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListCategoria)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ListCalidad)
        Me.Name = "FrmVinculo"
        Me.Text = "Calidad vs Categoria"
        CType(Me.ListCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListCalidad As System.Windows.Forms.ListBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents ListCategoria As C1.Win.C1List.C1List
End Class
