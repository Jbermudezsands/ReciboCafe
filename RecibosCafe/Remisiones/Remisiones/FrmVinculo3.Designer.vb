<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVinculo3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVinculo3))
        Me.ListCalidad = New C1.Win.C1List.C1List
        Me.ListTipoCafe = New System.Windows.Forms.ListBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.ListEstadoFisico = New C1.Win.C1List.C1List
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.CboTipoCalidad = New System.Windows.Forms.ComboBox
        CType(Me.ListCalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListEstadoFisico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListCalidad
        '
        Me.ListCalidad.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.ListCalidad.AllowColMove = False
        Me.ListCalidad.AllowSort = False
        Me.ListCalidad.Caption = ""
        Me.ListCalidad.CaptionHeight = 17
        Me.ListCalidad.ColumnCaptionHeight = 17
        Me.ListCalidad.ColumnFooterHeight = 17
        Me.ListCalidad.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.ListCalidad.Images.Add(CType(resources.GetObject("ListCalidad.Images"), System.Drawing.Image))
        Me.ListCalidad.ItemHeight = 15
        Me.ListCalidad.Location = New System.Drawing.Point(232, 4)
        Me.ListCalidad.MatchEntryTimeout = CType(2000, Long)
        Me.ListCalidad.Name = "ListCalidad"
        Me.ListCalidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.ListCalidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.ListCalidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.ListCalidad.Size = New System.Drawing.Size(214, 203)
        Me.ListCalidad.TabIndex = 191
        Me.ListCalidad.Text = "C1List1"
        Me.ListCalidad.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.ListCalidad.PropBag = resources.GetString("ListCalidad.PropBag")
        '
        'ListTipoCafe
        '
        Me.ListTipoCafe.DisplayMember = "Nombre"
        Me.ListTipoCafe.FormattingEnabled = True
        Me.ListTipoCafe.Location = New System.Drawing.Point(8, 4)
        Me.ListTipoCafe.Name = "ListTipoCafe"
        Me.ListTipoCafe.Size = New System.Drawing.Size(208, 238)
        Me.ListTipoCafe.TabIndex = 188
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = CType(resources.GetObject("Button9.Image"), System.Drawing.Image)
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(564, 247)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(114, 86)
        Me.Button9.TabIndex = 190
        Me.Button9.Text = "Salir"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(8, 248)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(114, 87)
        Me.Button7.TabIndex = 189
        Me.Button7.Text = "Grabar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'ListEstadoFisico
        '
        Me.ListEstadoFisico.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.ListEstadoFisico.Caption = ""
        Me.ListEstadoFisico.CaptionHeight = 17
        Me.ListEstadoFisico.ColumnCaptionHeight = 17
        Me.ListEstadoFisico.ColumnFooterHeight = 17
        Me.ListEstadoFisico.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.ListEstadoFisico.Images.Add(CType(resources.GetObject("ListEstadoFisico.Images"), System.Drawing.Image))
        Me.ListEstadoFisico.ItemHeight = 15
        Me.ListEstadoFisico.Location = New System.Drawing.Point(464, 4)
        Me.ListEstadoFisico.MatchEntryTimeout = CType(2000, Long)
        Me.ListEstadoFisico.Name = "ListEstadoFisico"
        Me.ListEstadoFisico.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.ListEstadoFisico.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.ListEstadoFisico.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.ListEstadoFisico.Size = New System.Drawing.Size(214, 238)
        Me.ListEstadoFisico.TabIndex = 192
        Me.ListEstadoFisico.Text = "C1List1"
        Me.ListEstadoFisico.PropBag = resources.GetString("ListEstadoFisico.PropBag")
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Check3.png")
        Me.ImageList.Images.SetKeyName(1, "Uncheked3.png")
        '
        'CboTipoCalidad
        '
        Me.CboTipoCalidad.DisplayMember = "NomCalidad"
        Me.CboTipoCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoCalidad.FormattingEnabled = True
        Me.CboTipoCalidad.Location = New System.Drawing.Point(232, 213)
        Me.CboTipoCalidad.Name = "CboTipoCalidad"
        Me.CboTipoCalidad.Size = New System.Drawing.Size(214, 33)
        Me.CboTipoCalidad.TabIndex = 193
        '
        'FrmVinculo3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 347)
        Me.Controls.Add(Me.CboTipoCalidad)
        Me.Controls.Add(Me.ListEstadoFisico)
        Me.Controls.Add(Me.ListCalidad)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ListTipoCafe)
        Me.Name = "FrmVinculo3"
        Me.Text = "FrmVinculo3"
        CType(Me.ListCalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListEstadoFisico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListCalidad As C1.Win.C1List.C1List
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents ListTipoCafe As System.Windows.Forms.ListBox
    Friend WithEvents ListEstadoFisico As C1.Win.C1List.C1List
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents CboTipoCalidad As System.Windows.Forms.ComboBox
End Class
