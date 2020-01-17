<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRemision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRemision))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.C1Button10 = New C1.Win.C1Input.C1Button
        Me.CmdBoton0 = New C1.Win.C1Input.C1Button
        Me.C1Button12 = New C1.Win.C1Input.C1Button
        Me.CmdBoton9 = New C1.Win.C1Input.C1Button
        Me.CmdBoton8 = New C1.Win.C1Input.C1Button
        Me.CmdBoton7 = New C1.Win.C1Input.C1Button
        Me.CmdBoton6 = New C1.Win.C1Input.C1Button
        Me.CmdBoton5 = New C1.Win.C1Input.C1Button
        Me.CmdBoton4 = New C1.Win.C1Input.C1Button
        Me.CmdBoton3 = New C1.Win.C1Input.C1Button
        Me.CmdBoton2 = New C1.Win.C1Input.C1Button
        Me.CmdBoton1 = New C1.Win.C1Input.C1Button
        Me.TxtMinutos = New System.Windows.Forms.TextBox
        Me.TxtHora = New System.Windows.Forms.TextBox
        Me.TxtBarra = New C1.Win.C1BarCode.C1BarCode
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmdImprimir = New C1.Win.C1Input.C1Button
        Me.LblEstado = New System.Windows.Forms.Label
        Me.TxtCodigoBarra = New System.Windows.Forms.TextBox
        Me.TxtBarraBoleta = New C1.Win.C1BarCode.C1BarCode
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtLocalidad = New System.Windows.Forms.TextBox
        Me.TxtNumeroBoleta = New System.Windows.Forms.TextBox
        Me.LblHora = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtPlaca = New C1.Win.C1List.C1Combo
        Me.CmdGrabar = New C1.Win.C1Input.C1Button
        Me.IdLugarAcopio = New System.Windows.Forms.TextBox
        Me.LblCosecha = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblSucursal = New System.Windows.Forms.Label
        Me.LblLocalidad = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.C1Button2 = New C1.Win.C1Input.C1Button
        Me.LblEncabezado = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ImgLogo = New System.Windows.Forms.PictureBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.OptBarra = New System.Windows.Forms.RadioButton
        Me.OptManual = New System.Windows.Forms.RadioButton
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.LblFecha = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.TxtPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.C1Button1)
        Me.GroupBox1.Controls.Add(Me.C1Button10)
        Me.GroupBox1.Controls.Add(Me.CmdBoton0)
        Me.GroupBox1.Controls.Add(Me.C1Button12)
        Me.GroupBox1.Controls.Add(Me.CmdBoton9)
        Me.GroupBox1.Controls.Add(Me.CmdBoton8)
        Me.GroupBox1.Controls.Add(Me.CmdBoton7)
        Me.GroupBox1.Controls.Add(Me.CmdBoton6)
        Me.GroupBox1.Controls.Add(Me.CmdBoton5)
        Me.GroupBox1.Controls.Add(Me.CmdBoton4)
        Me.GroupBox1.Controls.Add(Me.CmdBoton3)
        Me.GroupBox1.Controls.Add(Me.CmdBoton2)
        Me.GroupBox1.Controls.Add(Me.CmdBoton1)
        Me.GroupBox1.Controls.Add(Me.TxtMinutos)
        Me.GroupBox1.Controls.Add(Me.TxtHora)
        Me.GroupBox1.Controls.Add(Me.TxtBarra)
        Me.GroupBox1.Location = New System.Drawing.Point(469, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(521, 400)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'C1Button1
        '
        Me.C1Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.C1Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button1.ForeColor = System.Drawing.Color.White
        Me.C1Button1.Location = New System.Drawing.Point(389, 22)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(122, 366)
        Me.C1Button1.TabIndex = 16
        Me.C1Button1.Text = "ENTER"
        Me.C1Button1.UseVisualStyleBackColor = False
        '
        'C1Button10
        '
        Me.C1Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.C1Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button10.ForeColor = System.Drawing.Color.White
        Me.C1Button10.Location = New System.Drawing.Point(262, 297)
        Me.C1Button10.Name = "C1Button10"
        Me.C1Button10.Size = New System.Drawing.Size(119, 91)
        Me.C1Button10.TabIndex = 15
        Me.C1Button10.Text = "Borrar"
        Me.C1Button10.UseVisualStyleBackColor = False
        '
        'CmdBoton0
        '
        Me.CmdBoton0.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton0.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton0.ForeColor = System.Drawing.Color.White
        Me.CmdBoton0.Location = New System.Drawing.Point(141, 296)
        Me.CmdBoton0.Name = "CmdBoton0"
        Me.CmdBoton0.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton0.TabIndex = 14
        Me.CmdBoton0.Text = "0"
        Me.CmdBoton0.UseVisualStyleBackColor = False
        '
        'C1Button12
        '
        Me.C1Button12.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.C1Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button12.ForeColor = System.Drawing.Color.White
        Me.C1Button12.Location = New System.Drawing.Point(20, 296)
        Me.C1Button12.Name = "C1Button12"
        Me.C1Button12.Size = New System.Drawing.Size(119, 91)
        Me.C1Button12.TabIndex = 10
        Me.C1Button12.Text = "+"
        Me.C1Button12.UseVisualStyleBackColor = False
        '
        'CmdBoton9
        '
        Me.CmdBoton9.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton9.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton9.ForeColor = System.Drawing.Color.White
        Me.CmdBoton9.Location = New System.Drawing.Point(261, 205)
        Me.CmdBoton9.Name = "CmdBoton9"
        Me.CmdBoton9.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton9.TabIndex = 13
        Me.CmdBoton9.Text = "9"
        Me.CmdBoton9.UseVisualStyleBackColor = False
        '
        'CmdBoton8
        '
        Me.CmdBoton8.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton8.ForeColor = System.Drawing.Color.White
        Me.CmdBoton8.Location = New System.Drawing.Point(140, 204)
        Me.CmdBoton8.Name = "CmdBoton8"
        Me.CmdBoton8.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton8.TabIndex = 12
        Me.CmdBoton8.Text = "8"
        Me.CmdBoton8.UseVisualStyleBackColor = False
        '
        'CmdBoton7
        '
        Me.CmdBoton7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton7.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton7.ForeColor = System.Drawing.Color.White
        Me.CmdBoton7.Location = New System.Drawing.Point(20, 204)
        Me.CmdBoton7.Name = "CmdBoton7"
        Me.CmdBoton7.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton7.TabIndex = 11
        Me.CmdBoton7.Text = "7"
        Me.CmdBoton7.UseVisualStyleBackColor = False
        '
        'CmdBoton6
        '
        Me.CmdBoton6.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton6.ForeColor = System.Drawing.Color.White
        Me.CmdBoton6.Location = New System.Drawing.Point(261, 113)
        Me.CmdBoton6.Name = "CmdBoton6"
        Me.CmdBoton6.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton6.TabIndex = 10
        Me.CmdBoton6.Text = "6"
        Me.CmdBoton6.UseVisualStyleBackColor = False
        '
        'CmdBoton5
        '
        Me.CmdBoton5.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton5.ForeColor = System.Drawing.Color.White
        Me.CmdBoton5.Location = New System.Drawing.Point(140, 112)
        Me.CmdBoton5.Name = "CmdBoton5"
        Me.CmdBoton5.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton5.TabIndex = 9
        Me.CmdBoton5.Text = "5"
        Me.CmdBoton5.UseVisualStyleBackColor = False
        '
        'CmdBoton4
        '
        Me.CmdBoton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton4.ForeColor = System.Drawing.Color.White
        Me.CmdBoton4.Location = New System.Drawing.Point(20, 112)
        Me.CmdBoton4.Name = "CmdBoton4"
        Me.CmdBoton4.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton4.TabIndex = 8
        Me.CmdBoton4.Text = "4"
        Me.CmdBoton4.UseVisualStyleBackColor = False
        '
        'CmdBoton3
        '
        Me.CmdBoton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton3.ForeColor = System.Drawing.Color.White
        Me.CmdBoton3.Location = New System.Drawing.Point(261, 20)
        Me.CmdBoton3.Name = "CmdBoton3"
        Me.CmdBoton3.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton3.TabIndex = 7
        Me.CmdBoton3.Text = "3"
        Me.CmdBoton3.UseVisualStyleBackColor = False
        '
        'CmdBoton2
        '
        Me.CmdBoton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton2.ForeColor = System.Drawing.Color.White
        Me.CmdBoton2.Location = New System.Drawing.Point(141, 19)
        Me.CmdBoton2.Name = "CmdBoton2"
        Me.CmdBoton2.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton2.TabIndex = 6
        Me.CmdBoton2.Text = "2"
        Me.CmdBoton2.UseVisualStyleBackColor = False
        '
        'CmdBoton1
        '
        Me.CmdBoton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdBoton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBoton1.ForeColor = System.Drawing.Color.White
        Me.CmdBoton1.Location = New System.Drawing.Point(20, 19)
        Me.CmdBoton1.Name = "CmdBoton1"
        Me.CmdBoton1.Size = New System.Drawing.Size(119, 91)
        Me.CmdBoton1.TabIndex = 5
        Me.CmdBoton1.Text = "1"
        Me.CmdBoton1.UseVisualStyleBackColor = False
        '
        'TxtMinutos
        '
        Me.TxtMinutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMinutos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtMinutos.Location = New System.Drawing.Point(631, 61)
        Me.TxtMinutos.MaxLength = 2
        Me.TxtMinutos.Name = "TxtMinutos"
        Me.TxtMinutos.Size = New System.Drawing.Size(62, 49)
        Me.TxtMinutos.TabIndex = 4
        Me.TxtMinutos.Visible = False
        '
        'TxtHora
        '
        Me.TxtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtHora.Location = New System.Drawing.Point(563, 61)
        Me.TxtHora.MaxLength = 2
        Me.TxtHora.Name = "TxtHora"
        Me.TxtHora.Size = New System.Drawing.Size(62, 49)
        Me.TxtHora.TabIndex = 3
        Me.TxtHora.Visible = False
        '
        'TxtBarra
        '
        Me.TxtBarra.Location = New System.Drawing.Point(755, 12)
        Me.TxtBarra.Name = "TxtBarra"
        Me.TxtBarra.Size = New System.Drawing.Size(113, 34)
        Me.TxtBarra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TxtBarra.TabIndex = 7
        Me.TxtBarra.Text = "12355"
        Me.TxtBarra.Visible = False
        '
        'DTPFecha
        '
        Me.DTPFecha.Enabled = False
        Me.DTPFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFecha.Location = New System.Drawing.Point(16, 160)
        Me.DTPFecha.Margin = New System.Windows.Forms.Padding(5)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(229, 47)
        Me.DTPFecha.TabIndex = 4
        Me.DTPFecha.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(339, 714)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 42)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = ":"
        Me.Label1.Visible = False
        '
        'CmdImprimir
        '
        Me.CmdImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdImprimir.ForeColor = System.Drawing.Color.White
        Me.CmdImprimir.Location = New System.Drawing.Point(162, 565)
        Me.CmdImprimir.Name = "CmdImprimir"
        Me.CmdImprimir.Size = New System.Drawing.Size(144, 91)
        Me.CmdImprimir.TabIndex = 17
        Me.CmdImprimir.Text = "RE - IMPRIMIR"
        Me.CmdImprimir.UseVisualStyleBackColor = False
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstado.ForeColor = System.Drawing.Color.White
        Me.LblEstado.Location = New System.Drawing.Point(340, 723)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(258, 31)
        Me.LblEstado.TabIndex = 10
        Me.LblEstado.Text = "Codigo Contratista"
        Me.LblEstado.Visible = False
        '
        'TxtCodigoBarra
        '
        Me.TxtCodigoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoBarra.Location = New System.Drawing.Point(235, 325)
        Me.TxtCodigoBarra.Name = "TxtCodigoBarra"
        Me.TxtCodigoBarra.Size = New System.Drawing.Size(220, 38)
        Me.TxtCodigoBarra.TabIndex = 1
        '
        'TxtBarraBoleta
        '
        Me.TxtBarraBoleta.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBarraBoleta.Location = New System.Drawing.Point(769, 51)
        Me.TxtBarraBoleta.Name = "TxtBarraBoleta"
        Me.TxtBarraBoleta.Size = New System.Drawing.Size(249, 33)
        Me.TxtBarraBoleta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TxtBarraBoleta.TabIndex = 19
        Me.TxtBarraBoleta.Text = "12355"
        Me.TxtBarraBoleta.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 377)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 29)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Localidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 422)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 29)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Numero Boleta"
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLocalidad.Location = New System.Drawing.Point(235, 370)
        Me.TxtLocalidad.MaxLength = 3
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(220, 38)
        Me.TxtLocalidad.TabIndex = 22
        '
        'TxtNumeroBoleta
        '
        Me.TxtNumeroBoleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroBoleta.Location = New System.Drawing.Point(236, 414)
        Me.TxtNumeroBoleta.MaxLength = 6
        Me.TxtNumeroBoleta.Name = "TxtNumeroBoleta"
        Me.TxtNumeroBoleta.Size = New System.Drawing.Size(220, 38)
        Me.TxtNumeroBoleta.TabIndex = 23
        '
        'LblHora
        '
        Me.LblHora.AutoSize = True
        Me.LblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHora.ForeColor = System.Drawing.Color.White
        Me.LblHora.Location = New System.Drawing.Point(499, 147)
        Me.LblHora.Name = "LblHora"
        Me.LblHora.Size = New System.Drawing.Size(242, 39)
        Me.LblHora.TabIndex = 24
        Me.LblHora.Text = "10:23:55 p.m."
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 511)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 29)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = " Placa"
        '
        'TxtPlaca
        '
        Me.TxtPlaca.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.TxtPlaca.AlternatingRows = True
        Me.TxtPlaca.Caption = ""
        Me.TxtPlaca.CaptionHeight = 17
        Me.TxtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TxtPlaca.ColumnCaptionHeight = 17
        Me.TxtPlaca.ColumnFooterHeight = 17
        Me.TxtPlaca.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.TxtPlaca.ContentHeight = 33
        Me.TxtPlaca.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.TxtPlaca.DisplayMember = "Placa"
        Me.TxtPlaca.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.TxtPlaca.DropDownWidth = 200
        Me.TxtPlaca.EditorBackColor = System.Drawing.SystemColors.Window
        Me.TxtPlaca.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlaca.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtPlaca.EditorHeight = 33
        Me.TxtPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlaca.Images.Add(CType(resources.GetObject("TxtPlaca.Images"), System.Drawing.Image))
        Me.TxtPlaca.ItemHeight = 35
        Me.TxtPlaca.Location = New System.Drawing.Point(235, 504)
        Me.TxtPlaca.MatchEntryTimeout = CType(2000, Long)
        Me.TxtPlaca.MaxDropDownItems = CType(6, Short)
        Me.TxtPlaca.MaxLength = 32767
        Me.TxtPlaca.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.TxtPlaca.Name = "TxtPlaca"
        Me.TxtPlaca.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.TxtPlaca.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.TxtPlaca.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.TxtPlaca.Size = New System.Drawing.Size(220, 39)
        Me.TxtPlaca.TabIndex = 28
        Me.TxtPlaca.VisualStyle = C1.Win.C1List.VisualStyle.System
        Me.TxtPlaca.PropBag = resources.GetString("TxtPlaca.PropBag")
        '
        'CmdGrabar
        '
        Me.CmdGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.CmdGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGrabar.ForeColor = System.Drawing.Color.White
        Me.CmdGrabar.Location = New System.Drawing.Point(13, 565)
        Me.CmdGrabar.Name = "CmdGrabar"
        Me.CmdGrabar.Size = New System.Drawing.Size(144, 91)
        Me.CmdGrabar.TabIndex = 16
        Me.CmdGrabar.Text = "GRABAR"
        Me.CmdGrabar.UseVisualStyleBackColor = False
        '
        'IdLugarAcopio
        '
        Me.IdLugarAcopio.Location = New System.Drawing.Point(1094, 126)
        Me.IdLugarAcopio.Name = "IdLugarAcopio"
        Me.IdLugarAcopio.Size = New System.Drawing.Size(45, 20)
        Me.IdLugarAcopio.TabIndex = 30
        Me.IdLugarAcopio.Visible = False
        '
        'LblCosecha
        '
        Me.LblCosecha.AutoSize = True
        Me.LblCosecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCosecha.ForeColor = System.Drawing.Color.White
        Me.LblCosecha.Location = New System.Drawing.Point(396, 104)
        Me.LblCosecha.Name = "LblCosecha"
        Me.LblCosecha.Size = New System.Drawing.Size(243, 29)
        Me.LblCosecha.TabIndex = 31
        Me.LblCosecha.Text = "Cosecha 2014-2015"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 466)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 29)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Cod transportista"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblSucursal)
        Me.GroupBox2.Location = New System.Drawing.Point(62, 701)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(445, 127)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'LblSucursal
        '
        Me.LblSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblSucursal.AutoSize = True
        Me.LblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSucursal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblSucursal.Location = New System.Drawing.Point(46, 11)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(324, 31)
        Me.LblSucursal.TabIndex = 32
        Me.LblSucursal.Text = "SUCURSAL JINOTEGA"
        Me.LblSucursal.Visible = False
        '
        'LblLocalidad
        '
        Me.LblLocalidad.AutoSize = True
        Me.LblLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLocalidad.ForeColor = System.Drawing.Color.White
        Me.LblLocalidad.Location = New System.Drawing.Point(12, 225)
        Me.LblLocalidad.Name = "LblLocalidad"
        Me.LblLocalidad.Size = New System.Drawing.Size(153, 24)
        Me.LblLocalidad.TabIndex = 33
        Me.LblLocalidad.Text = "Localidad Actual:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(13, 328)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 29)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Código Barra"
        '
        'C1Button2
        '
        Me.C1Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.C1Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button2.ForeColor = System.Drawing.Color.White
        Me.C1Button2.Location = New System.Drawing.Point(312, 565)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(144, 91)
        Me.C1Button2.TabIndex = 35
        Me.C1Button2.Text = "SALIR"
        Me.C1Button2.UseVisualStyleBackColor = False
        '
        'LblEncabezado
        '
        Me.LblEncabezado.AutoSize = True
        Me.LblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEncabezado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblEncabezado.Location = New System.Drawing.Point(257, 9)
        Me.LblEncabezado.Name = "LblEncabezado"
        Me.LblEncabezado.Size = New System.Drawing.Size(515, 42)
        Me.LblEncabezado.TabIndex = 36
        Me.LblEncabezado.Text = "EXPORTADORA ATLANTIC"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(289, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(439, 29)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "REGISTRO DE RUTAS - LOGISTICA"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(404, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(213, 20)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "ECOM COFFEE SYSTEM"
        '
        'ImgLogo
        '
        Me.ImgLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ImgLogo.Location = New System.Drawing.Point(17, 9)
        Me.ImgLogo.Name = "ImgLogo"
        Me.ImgLogo.Size = New System.Drawing.Size(170, 127)
        Me.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgLogo.TabIndex = 68
        Me.ImgLogo.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.OptBarra)
        Me.GroupBox3.Controls.Add(Me.OptManual)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 256)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(448, 52)
        Me.GroupBox3.TabIndex = 69
        Me.GroupBox3.TabStop = False
        '
        'OptBarra
        '
        Me.OptBarra.AutoSize = True
        Me.OptBarra.Checked = True
        Me.OptBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptBarra.ForeColor = System.Drawing.Color.White
        Me.OptBarra.Location = New System.Drawing.Point(208, 15)
        Me.OptBarra.Name = "OptBarra"
        Me.OptBarra.Size = New System.Drawing.Size(234, 29)
        Me.OptBarra.TabIndex = 1
        Me.OptBarra.TabStop = True
        Me.OptBarra.Text = "Lectura Codigo Barra"
        Me.OptBarra.UseVisualStyleBackColor = True
        '
        'OptManual
        '
        Me.OptManual.AutoSize = True
        Me.OptManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptManual.ForeColor = System.Drawing.Color.White
        Me.OptManual.Location = New System.Drawing.Point(16, 17)
        Me.OptManual.Name = "OptManual"
        Me.OptManual.Size = New System.Drawing.Size(179, 29)
        Me.OptManual.TabIndex = 0
        Me.OptManual.Text = "Lectura Manual"
        Me.OptManual.UseVisualStyleBackColor = True
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(236, 461)
        Me.TxtCodigo.MaxLength = 3
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(220, 38)
        Me.TxtCodigo.TabIndex = 70
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFecha.ForeColor = System.Drawing.Color.White
        Me.LblFecha.Location = New System.Drawing.Point(748, 147)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(242, 39)
        Me.LblFecha.TabIndex = 75
        Me.LblFecha.Text = "10:23:55 p.m."
        '
        'FrmRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1020, 733)
        Me.Controls.Add(Me.LblFecha)
        Me.Controls.Add(Me.LblLocalidad)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.LblCosecha)
        Me.Controls.Add(Me.ImgLogo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblEncabezado)
        Me.Controls.Add(Me.C1Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.IdLugarAcopio)
        Me.Controls.Add(Me.TxtPlaca)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblHora)
        Me.Controls.Add(Me.TxtNumeroBoleta)
        Me.Controls.Add(Me.TxtLocalidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtBarraBoleta)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.TxtCodigoBarra)
        Me.Controls.Add(Me.CmdImprimir)
        Me.Controls.Add(Me.CmdGrabar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTPFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRemision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PUNTO CONTROL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TxtPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ImgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdBoton1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button10 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton0 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button12 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton9 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton8 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton7 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton6 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton5 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton4 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton3 As C1.Win.C1Input.C1Button
    Friend WithEvents CmdBoton2 As C1.Win.C1Input.C1Button
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMinutos As System.Windows.Forms.TextBox
    Friend WithEvents TxtBarra As C1.Win.C1BarCode.C1BarCode
    Friend WithEvents CmdImprimir As C1.Win.C1Input.C1Button
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents TxtBarraBoleta As C1.Win.C1BarCode.C1BarCode
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumeroBoleta As System.Windows.Forms.TextBox
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents LblHora As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPlaca As C1.Win.C1List.C1Combo
    Friend WithEvents CmdGrabar As C1.Win.C1Input.C1Button
    Friend WithEvents IdLugarAcopio As System.Windows.Forms.TextBox
    Friend WithEvents LblCosecha As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents LblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ImgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents LblSucursal As System.Windows.Forms.Label
    Friend WithEvents LblLocalidad As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptManual As System.Windows.Forms.RadioButton
    Friend WithEvents OptBarra As System.Windows.Forms.RadioButton
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LblFecha As System.Windows.Forms.Label

End Class
