<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReimpresion
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
        Me.components = New System.ComponentModel.Container
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblTicket = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LblConductor = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblBoleta = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblLocalidad = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblRegistros = New System.Windows.Forms.Label
        Me.TxtTipo = New System.Windows.Forms.TextBox
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.CmdGrabar = New C1.Win.C1Input.C1Button
        Me.LblHora = New System.Windows.Forms.Label
        Me.TxtNumeroBoleta = New System.Windows.Forms.TextBox
        Me.TxtLocalidad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LblCosecha = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblTicket)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LblConductor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblBoleta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LblLocalidad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(77, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 209)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'LblTicket
        '
        Me.LblTicket.AutoSize = True
        Me.LblTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTicket.ForeColor = System.Drawing.Color.White
        Me.LblTicket.Location = New System.Drawing.Point(223, 138)
        Me.LblTicket.Name = "LblTicket"
        Me.LblTicket.Size = New System.Drawing.Size(0, 29)
        Me.LblTicket.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(29, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 29)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Numero Ticket"
        '
        'LblConductor
        '
        Me.LblConductor.AutoSize = True
        Me.LblConductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConductor.ForeColor = System.Drawing.Color.White
        Me.LblConductor.Location = New System.Drawing.Point(223, 101)
        Me.LblConductor.Name = "LblConductor"
        Me.LblConductor.Size = New System.Drawing.Size(0, 29)
        Me.LblConductor.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 29)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Conductor"
        '
        'LblBoleta
        '
        Me.LblBoleta.AutoSize = True
        Me.LblBoleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBoleta.ForeColor = System.Drawing.Color.White
        Me.LblBoleta.Location = New System.Drawing.Point(223, 61)
        Me.LblBoleta.Name = "LblBoleta"
        Me.LblBoleta.Size = New System.Drawing.Size(0, 29)
        Me.LblBoleta.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(188, 29)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Numero Boleta"
        '
        'LblLocalidad
        '
        Me.LblLocalidad.AutoSize = True
        Me.LblLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLocalidad.ForeColor = System.Drawing.Color.White
        Me.LblLocalidad.Location = New System.Drawing.Point(223, 20)
        Me.LblLocalidad.Name = "LblLocalidad"
        Me.LblLocalidad.Size = New System.Drawing.Size(0, 29)
        Me.LblLocalidad.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Localidad"
        '
        'LblRegistros
        '
        Me.LblRegistros.AutoSize = True
        Me.LblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblRegistros.Location = New System.Drawing.Point(200, 42)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(713, 55)
        Me.LblRegistros.TabIndex = 41
        Me.LblRegistros.Text = "RE-IMPRESION DE BOLETAS"
        '
        'TxtTipo
        '
        Me.TxtTipo.Location = New System.Drawing.Point(-141, 387)
        Me.TxtTipo.Name = "TxtTipo"
        Me.TxtTipo.Size = New System.Drawing.Size(100, 20)
        Me.TxtTipo.TabIndex = 40
        Me.TxtTipo.Visible = False
        '
        'C1Button1
        '
        Me.C1Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.C1Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button1.Location = New System.Drawing.Point(941, 350)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(157, 82)
        Me.C1Button1.TabIndex = 39
        Me.C1Button1.Text = "SALIR"
        Me.C1Button1.UseVisualStyleBackColor = False
        '
        'CmdGrabar
        '
        Me.CmdGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CmdGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.Location = New System.Drawing.Point(941, 180)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(157, 82)
        Me.CmdGrabar.TabIndex = 38
        Me.CmdGrabar.Text = "IMPRIMIR"
        Me.CmdGrabar.UseVisualStyleBackColor = False
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblHora.Location = New System.Drawing.Point(582, 121)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(331, 55)
        Me.LblHora.TabIndex = 36
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'TxtNumeroBoleta
        '
        Me.TxtNumeroBoleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroBoleta.Location = New System.Drawing.Point(276, 179)
        Me.TxtNumeroBoleta.Name = "TxtNumeroBoleta"
        Me.TxtNumeroBoleta.Size = New System.Drawing.Size(259, 38)
        Me.TxtNumeroBoleta.TabIndex = 47
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLocalidad.Location = New System.Drawing.Point(274, 136)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(261, 38)
        Me.TxtLocalidad.TabIndex = 46
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(76, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 31)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Numero Boleta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(76, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 31)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Localidad"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'LblCosecha
        '
        Me.LblCosecha.AutoSize = True
        Me.LblCosecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCosecha.ForeColor = System.Drawing.Color.Black
        Me.LblCosecha.Location = New System.Drawing.Point(602, 190)
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Size = New System.Drawing.Size(243, 29)
        Me.LblCosecha.TabIndex = 48
        Me.LblCosecha.Text = "Cosecha 2014-2015"
        '
        'FrmReimpresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(1114, 470)
        Me.Controls.Add(Me.LblCosecha)
        Me.Controls.Add(Me.TxtNumeroBoleta)
        Me.Controls.Add(Me.TxtLocalidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblRegistros)
        Me.Controls.Add(Me.TxtTipo)
        Me.Controls.Add(Me.C1Button1)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.LblHora)
        Me.Name = "FrmReimpresion"
        Me.Text = "FrmReimpresion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblTicket As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblConductor As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblBoleta As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblLocalidad As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblRegistros As System.Windows.Forms.Label
    Friend WithEvents TxtTipo As System.Windows.Forms.TextBox
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdGrabar As C1.Win.C1Input.C1Button
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroBoleta As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LblCosecha As System.Windows.Forms.Label
End Class
