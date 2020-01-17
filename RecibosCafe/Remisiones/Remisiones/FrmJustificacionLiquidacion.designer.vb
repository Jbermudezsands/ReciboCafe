<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJustificacionLiquidacion
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtJustifica = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.LblFecha = New System.Windows.Forms.Label
        Me.DTPFechaJust = New System.Windows.Forms.DateTimePicker
        Me.LblHoraJsut = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(160, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Justificacion"
        '
        'TxtJustifica
        '
        Me.TxtJustifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJustifica.Location = New System.Drawing.Point(38, 59)
        Me.TxtJustifica.Multiline = True
        Me.TxtJustifica.Name = "TxtJustifica"
        Me.TxtJustifica.Size = New System.Drawing.Size(417, 146)
        Me.TxtJustifica.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(161, 216)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 38)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "CONTINUAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.ForeColor = System.Drawing.SystemColors.Control
        Me.LblFecha.Location = New System.Drawing.Point(-1, 0)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(39, 13)
        Me.LblFecha.TabIndex = 4
        Me.LblFecha.Text = "Label2"
        '
        'DTPFechaJust
        '
        Me.DTPFechaJust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFechaJust.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaJust.Location = New System.Drawing.Point(527, 196)
        Me.DTPFechaJust.Name = "DTPFechaJust"
        Me.DTPFechaJust.Size = New System.Drawing.Size(95, 20)
        Me.DTPFechaJust.TabIndex = 239
        Me.DTPFechaJust.Visible = False
        '
        'LblHoraJsut
        '
        Me.LblHoraJsut.AutoSize = True
        Me.LblHoraJsut.ForeColor = System.Drawing.SystemColors.Control
        Me.LblHoraJsut.Location = New System.Drawing.Point(63, 0)
        Me.LblHoraJsut.Name = "LblHoraJsut"
        Me.LblHoraJsut.Size = New System.Drawing.Size(39, 13)
        Me.LblHoraJsut.TabIndex = 240
        Me.LblHoraJsut.Text = "Label2"
        '
        'FrmJustificacionLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(509, 261)
        Me.Controls.Add(Me.LblHoraJsut)
        Me.Controls.Add(Me.DTPFechaJust)
        Me.Controls.Add(Me.LblFecha)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtJustifica)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(12, 110)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(515, 290)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(515, 290)
        Me.Name = "FrmJustificacionLiquidacion"
        Me.Text = "FrmJustificacionLiquidacion"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtJustifica As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents DTPFechaJust As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblHoraJsut As System.Windows.Forms.Label
End Class
