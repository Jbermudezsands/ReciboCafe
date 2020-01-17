<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLocalidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLocalidad))
        Me.CboLocalidad = New C1.Win.C1List.C1Combo
        Me.Button15 = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.CmdAceptar = New System.Windows.Forms.Button
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
        Me.CboLocalidad.Location = New System.Drawing.Point(107, 16)
        Me.CboLocalidad.MatchEntryTimeout = CType(2000, Long)
        Me.CboLocalidad.MaxDropDownItems = CType(6, Short)
        Me.CboLocalidad.MaxLength = 32767
        Me.CboLocalidad.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboLocalidad.Name = "CboLocalidad"
        Me.CboLocalidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboLocalidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboLocalidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboLocalidad.Size = New System.Drawing.Size(273, 39)
        Me.CboLocalidad.TabIndex = 243
        Me.CboLocalidad.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.CboLocalidad.PropBag = resources.GetString("CboLocalidad.PropBag")
        '
        'Button15
        '
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.Location = New System.Drawing.Point(385, 19)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(35, 38)
        Me.Button15.TabIndex = 242
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(3, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 20)
        Me.Label18.TabIndex = 241
        Me.Label18.Text = "LOCALIDAD"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Location = New System.Drawing.Point(426, 19)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(87, 35)
        Me.CmdAceptar.TabIndex = 244
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'FrmLocalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(525, 76)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.CboLocalidad)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Label18)
        Me.Name = "FrmLocalidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Localidad"
        CType(Me.CboLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboLocalidad As C1.Win.C1List.C1Combo
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
End Class
