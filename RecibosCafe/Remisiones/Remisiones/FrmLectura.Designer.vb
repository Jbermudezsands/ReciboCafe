<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLectura
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
        Me.LblHora = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CmdGrabar = New C1.Win.C1Input.C1Button
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.TxtTipo = New System.Windows.Forms.TextBox
        Me.LblRegistros = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblPlaca = New System.Windows.Forms.Label
        Me.Placa = New System.Windows.Forms.Label
        Me.LblTicket = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LblConductor = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblBoleta = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblLocalidad = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtBarraBoleta = New C1.Win.C1BarCode.C1BarCode
        Me.TxtCodigoBarra = New System.Windows.Forms.TextBox
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.ImgLogo = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.LblEncabezado = New System.Windows.Forms.Label
        Me.LblCosecha = New System.Windows.Forms.Label
        Me.LblFecha = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.White
        Me.LblHora.Location = New System.Drawing.Point(655, 293)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(242, 39)
        Me.LblHora.TabIndex = 27
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'CmdGrabar
        '
        Me.CmdGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.Location = New System.Drawing.Point(113, 558)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(157, 82)
        Me.CmdGrabar.TabIndex = 2
        Me.CmdGrabar.Text = "ACEPTAR"
        Me.CmdGrabar.UseVisualStyleBackColor = False
        '
        'C1Button1
        '
        Me.C1Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.C1Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button1.Location = New System.Drawing.Point(743, 557)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(157, 82)
        Me.C1Button1.TabIndex = 30
        Me.C1Button1.Text = "SALIR"
        Me.C1Button1.UseVisualStyleBackColor = False
        '
        'TxtTipo
        '
        Me.TxtTipo.Location = New System.Drawing.Point(-12, 163)
        Me.TxtTipo.Name = "TxtTipo"
        Me.TxtTipo.Size = New System.Drawing.Size(100, 20)
        Me.TxtTipo.TabIndex = 31
        Me.TxtTipo.Visible = False
        '
        'LblRegistros
        '
        Me.LblRegistros.AutoSize = True
        Me.LblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistros.ForeColor = System.Drawing.Color.White
        Me.LblRegistros.Location = New System.Drawing.Point(361, 85)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(416, 37)
        Me.LblRegistros.TabIndex = 32
        Me.LblRegistros.Text = "REGISTRO DE ENTRADA"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblPlaca)
        Me.GroupBox1.Controls.Add(Me.Placa)
        Me.GroupBox1.Controls.Add(Me.LblTicket)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LblConductor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblBoleta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LblLocalidad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(114, 335)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 216)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'LblPlaca
        '
        Me.LblPlaca.AutoSize = True
        Me.LblPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPlaca.ForeColor = System.Drawing.Color.White
        Me.LblPlaca.Location = New System.Drawing.Point(223, 132)
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Size = New System.Drawing.Size(0, 29)
        Me.LblPlaca.TabIndex = 9
        '
        'Placa
        '
        Me.Placa.AutoSize = True
        Me.Placa.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Placa.Location = New System.Drawing.Point(29, 132)
        Me.Placa.Name = "Placa"
        Me.Placa.Size = New System.Drawing.Size(78, 29)
        Me.Placa.TabIndex = 8
        Me.Placa.Text = "Placa"
        '
        'LblTicket
        '
        Me.LblTicket.AutoSize = True
        Me.LblTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTicket.ForeColor = System.Drawing.Color.White
        Me.LblTicket.Location = New System.Drawing.Point(223, 170)
        Me.LblTicket.Name = "LblTicket"
        Me.LblTicket.Size = New System.Drawing.Size(0, 29)
        Me.LblTicket.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(29, 169)
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
        'TxtBarraBoleta
        '
        Me.TxtBarraBoleta.Location = New System.Drawing.Point(114, 285)
        Me.TxtBarraBoleta.Name = "TxtBarraBoleta"
        Me.TxtBarraBoleta.Size = New System.Drawing.Size(315, 44)
        Me.TxtBarraBoleta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TxtBarraBoleta.TabIndex = 28
        Me.TxtBarraBoleta.Text = "12355"
        '
        'TxtCodigoBarra
        '
        Me.TxtCodigoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoBarra.Location = New System.Drawing.Point(119, 241)
        Me.TxtCodigoBarra.Name = "TxtCodigoBarra"
        Me.TxtCodigoBarra.Size = New System.Drawing.Size(310, 38)
        Me.TxtCodigoBarra.TabIndex = 1
        '
        'DTPFecha
        '
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(668, 186)
        Me.DTPFecha.Margin = New System.Windows.Forms.Padding(5)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(224, 38)
        Me.DTPFecha.TabIndex = 26
        Me.DTPFecha.Visible = False
        '
        'ImgLogo
        '
        Me.ImgLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ImgLogo.Location = New System.Drawing.Point(29, 30)
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.Size = New System.Drawing.Size(170, 127)
        Me.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgLogo.TabIndex = 72
        Me.ImgLogo.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(446, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(213, 20)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "ECOM COFFEE SYSTEM"
        '
        'LblEncabezado
        '
        Me.LblEncabezado.AutoSize = True
        Me.LblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEncabezado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblEncabezado.Location = New System.Drawing.Point(235, 30)
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Size = New System.Drawing.Size(657, 55)
        Me.LblEncabezado.TabIndex = 69
        Me.LblEncabezado.Text = "EXPORTADORA ATLANTIC"
        '
        'LblCosecha
        '
        Me.LblCosecha.AutoSize = True
        Me.LblCosecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCosecha.ForeColor = System.Drawing.Color.White
        Me.LblCosecha.Location = New System.Drawing.Point(432, 152)
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Size = New System.Drawing.Size(243, 29)
        Me.LblCosecha.TabIndex = 73
        Me.LblCosecha.Text = "Cosecha 2014-2015"
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.ForeColor = System.Drawing.Color.White
        Me.LblFecha.Location = New System.Drawing.Point(661, 241)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(242, 39)
        Me.LblFecha.TabIndex = 74
        Me.LblFecha.Text = "10:23:55 p.m."
        '
        'FrmLectura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(964, 653)
        Me.Controls.Add(Me.LblFecha)
        Me.Controls.Add(Me.LblCosecha)
        Me.Controls.Add(Me.ImgLogo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LblEncabezado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblRegistros)
        Me.Controls.Add(Me.TxtTipo)
        Me.Controls.Add(Me.C1Button1)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.TxtBarraBoleta)
        Me.Controls.Add(Me.LblHora)
        Me.Controls.Add(Me.TxtCodigoBarra)
        Me.Controls.Add(Me.DTPFecha)
        Me.Name = "FrmLectura"
        Me.Text = "FrmLectura"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CmdGrabar As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents TxtTipo As System.Windows.Forms.TextBox
    Friend WithEvents LblRegistros As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblLocalidad As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblConductor As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblBoleta As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblTicket As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtBarraBoleta As C1.Win.C1BarCode.C1BarCode
    Friend WithEvents TxtCodigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ImgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblEncabezado As System.Windows.Forms.Label
    Friend WithEvents LblCosecha As System.Windows.Forms.Label
    Friend WithEvents Placa As System.Windows.Forms.Label
    Friend WithEvents LblPlaca As System.Windows.Forms.Label
    Friend WithEvents LblFecha As System.Windows.Forms.Label
End Class
