<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrecioCorteLocalidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrecioCorteLocalidad))
        Me.CboLocalidad = New C1.Win.C1List.C1Combo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Button15 = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.CboLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.CboLocalidad.Location = New System.Drawing.Point(119, 12)
        Me.CboLocalidad.MatchEntryTimeout = CType(2000, Long)
        Me.CboLocalidad.MaxDropDownItems = CType(6, Short)
        Me.CboLocalidad.MaxLength = 32767
        Me.CboLocalidad.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboLocalidad.Name = "CboLocalidad"
        Me.CboLocalidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboLocalidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboLocalidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboLocalidad.Size = New System.Drawing.Size(273, 39)
        Me.CboLocalidad.TabIndex = 244
        Me.CboLocalidad.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.CboLocalidad.PropBag = resources.GetString("CboLocalidad.PropBag")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(12, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 20)
        Me.Label18.TabIndex = 242
        Me.Label18.Text = "LOCALIDAD"
        '
        'Button15
        '
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.Location = New System.Drawing.Point(398, 15)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(35, 38)
        Me.Button15.TabIndex = 243
        Me.Button15.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 62)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(417, 23)
        Me.ProgressBar1.TabIndex = 245
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(251, 91)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(182, 23)
        Me.ProgressBar2.TabIndex = 246
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(311, 132)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 56)
        Me.Button1.TabIndex = 247
        Me.Button1.Text = "Procesar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmPrecioCorteLocalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(450, 202)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.CboLocalidad)
        Me.Controls.Add(Me.Label18)
        Me.Name = "FrmPrecioCorteLocalidad"
        Me.Text = "FrmPrecioCorteLocalidad"
        CType(Me.CboLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents CboLocalidad As C1.Win.C1List.C1Combo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
