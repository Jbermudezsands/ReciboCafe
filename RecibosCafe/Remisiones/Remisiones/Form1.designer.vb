<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.C1Ribbon1 = New C1.Win.C1Ribbon.C1Ribbon
        Me.RibbonApplicationMenu1 = New C1.Win.C1Ribbon.RibbonApplicationMenu
        Me.RbnSalir = New C1.Win.C1Ribbon.RibbonButton
        Me.Productos = New C1.Win.C1Ribbon.RibbonButton
        Me.Proveedores = New C1.Win.C1Ribbon.RibbonButton
        Me.Configuracion = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonSeparator1 = New C1.Win.C1Ribbon.RibbonSeparator
        Me.RibbonExit = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonConfigToolBar1 = New C1.Win.C1Ribbon.RibbonConfigToolBar
        Me.RibbonQat1 = New C1.Win.C1Ribbon.RibbonQat
        Me.RibbonTab1 = New C1.Win.C1Ribbon.RibbonTab
        Me.RibbonGroup1 = New C1.Win.C1Ribbon.RibbonGroup
        Me.RibbonButton12 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton4 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton2 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton21 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton711 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton5 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonGroup2 = New C1.Win.C1Ribbon.RibbonGroup
        Me.RibbonButton3 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonProductor = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton31 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonGroup41 = New C1.Win.C1Ribbon.RibbonGroup
        Me.RibbonButton11 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonGroup4 = New C1.Win.C1Ribbon.RibbonGroup
        Me.RibbonButton1 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonTab2 = New C1.Win.C1Ribbon.RibbonTab
        Me.RibbonGroup6 = New C1.Win.C1Ribbon.RibbonGroup
        Me.RibbonButton311 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton3111 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton311111 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton31111 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton311112 = New C1.Win.C1Ribbon.RibbonButton
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar
        Me.RibbonLabel1 = New C1.Win.C1Ribbon.RibbonLabel
        Me.CmdHoraLlegada = New System.Windows.Forms.Button
        Me.CmdCargar = New System.Windows.Forms.Button
        Me.CmdReservar = New System.Windows.Forms.Button
        Me.CmdSalida = New System.Windows.Forms.Button
        Me.CmdReporta = New System.Windows.Forms.Button
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1Ribbon1
        '
        Me.C1Ribbon1.ApplicationMenuHolder = Me.RibbonApplicationMenu1
        Me.C1Ribbon1.ConfigToolBarHolder = Me.RibbonConfigToolBar1
        Me.C1Ribbon1.Location = New System.Drawing.Point(0, 0)
        Me.C1Ribbon1.Name = "C1Ribbon1"
        Me.C1Ribbon1.QatHolder = Me.RibbonQat1
        Me.C1Ribbon1.Size = New System.Drawing.Size(1150, 142)
        Me.C1Ribbon1.TabIndex = 0
        Me.C1Ribbon1.Tabs.Add(Me.RibbonTab1)
        Me.C1Ribbon1.Tabs.Add(Me.RibbonTab2)
        '
        'RibbonApplicationMenu1
        '
        Me.RibbonApplicationMenu1.BottomPaneItems.Add(Me.RbnSalir)
        Me.RibbonApplicationMenu1.ID = "RibbonApplicationMenu1"
        Me.RibbonApplicationMenu1.LargeImage = CType(resources.GetObject("RibbonApplicationMenu1.LargeImage"), System.Drawing.Image)
        Me.RibbonApplicationMenu1.LeftPaneItems.Add(Me.Productos)
        Me.RibbonApplicationMenu1.LeftPaneItems.Add(Me.Proveedores)
        Me.RibbonApplicationMenu1.LeftPaneItems.Add(Me.Configuracion)
        Me.RibbonApplicationMenu1.LeftPaneItems.Add(Me.RibbonSeparator1)
        Me.RibbonApplicationMenu1.LeftPaneItems.Add(Me.RibbonExit)
        '
        'RbnSalir
        '
        Me.RbnSalir.ID = "RbnSalir"
        Me.RbnSalir.Text = "Salir"
        '
        'Productos
        '
        Me.Productos.ID = "Productos"
        Me.Productos.LargeImage = CType(resources.GetObject("Productos.LargeImage"), System.Drawing.Image)
        Me.Productos.Text = "Productos"
        '
        'Proveedores
        '
        Me.Proveedores.ID = "Proveedores"
        Me.Proveedores.LargeImage = CType(resources.GetObject("Proveedores.LargeImage"), System.Drawing.Image)
        Me.Proveedores.Text = "Proveedores"
        '
        'Configuracion
        '
        Me.Configuracion.ID = "Configuracion"
        Me.Configuracion.LargeImage = CType(resources.GetObject("Configuracion.LargeImage"), System.Drawing.Image)
        Me.Configuracion.Text = "Configuracion"
        '
        'RibbonSeparator1
        '
        Me.RibbonSeparator1.ID = "RibbonSeparator1"
        '
        'RibbonExit
        '
        Me.RibbonExit.ID = "RibbonExit"
        Me.RibbonExit.LargeImage = CType(resources.GetObject("RibbonExit.LargeImage"), System.Drawing.Image)
        Me.RibbonExit.Text = "S&alir"
        '
        'RibbonConfigToolBar1
        '
        Me.RibbonConfigToolBar1.ID = "RibbonConfigToolBar1"
        '
        'RibbonQat1
        '
        Me.RibbonQat1.ID = "RibbonQat1"
        '
        'RibbonTab1
        '
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup1)
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup2)
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup41)
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup4)
        Me.RibbonTab1.ID = "RibbonTab1"
        Me.RibbonTab1.Text = "Accesos"
        '
        'RibbonGroup1
        '
        Me.RibbonGroup1.ID = "RibbonGroup1"
        Me.RibbonGroup1.Items.Add(Me.RibbonButton12)
        Me.RibbonGroup1.Items.Add(Me.RibbonButton4)
        Me.RibbonGroup1.Items.Add(Me.RibbonButton2)
        Me.RibbonGroup1.Items.Add(Me.RibbonButton21)
        Me.RibbonGroup1.Items.Add(Me.RibbonButton711)
        Me.RibbonGroup1.Items.Add(Me.RibbonButton5)
        Me.RibbonGroup1.Text = "Procesos"
        '
        'RibbonButton12
        '
        Me.RibbonButton12.ID = "RibbonButton12"
        Me.RibbonButton12.LargeImage = CType(resources.GetObject("RibbonButton12.LargeImage"), System.Drawing.Image)
        Me.RibbonButton12.SmallImage = CType(resources.GetObject("RibbonButton12.SmallImage"), System.Drawing.Image)
        Me.RibbonButton12.Text = "Recibos"
        '
        'RibbonButton4
        '
        Me.RibbonButton4.ID = "RibbonButton4"
        Me.RibbonButton4.LargeImage = Global.Remisiones.My.Resources.Resources.Sin_tilo
        Me.RibbonButton4.SmallImage = CType(resources.GetObject("RibbonButton4.SmallImage"), System.Drawing.Image)
        Me.RibbonButton4.Text = "Remision "
        '
        'RibbonButton2
        '
        Me.RibbonButton2.ID = "RibbonButton2"
        Me.RibbonButton2.LargeImage = Global.Remisiones.My.Resources.Resources.LiquidacionPerga
        Me.RibbonButton2.SmallImage = CType(resources.GetObject("RibbonButton2.SmallImage"), System.Drawing.Image)
        Me.RibbonButton2.Text = "Liquidacion"
        '
        'RibbonButton21
        '
        Me.RibbonButton21.ID = "RibbonButton21"
        Me.RibbonButton21.LargeImage = Global.Remisiones.My.Resources.Resources.icons8_transaction_48
        Me.RibbonButton21.SmallImage = CType(resources.GetObject("RibbonButton21.SmallImage"), System.Drawing.Image)
        Me.RibbonButton21.Text = "Cambiar Precio"
        '
        'RibbonButton711
        '
        Me.RibbonButton711.ID = "RibbonButton711"
        Me.RibbonButton711.LargeImage = Global.Remisiones.My.Resources.Resources.icons8_multiple_choice_48
        Me.RibbonButton711.SmallImage = CType(resources.GetObject("RibbonButton711.SmallImage"), System.Drawing.Image)
        Me.RibbonButton711.Text = "Registros"
        '
        'RibbonButton5
        '
        Me.RibbonButton5.Enabled = False
        Me.RibbonButton5.ID = "RibbonButton5"
        Me.RibbonButton5.LargeImage = Global.Remisiones.My.Resources.Resources.Compelmento
        Me.RibbonButton5.SmallImage = CType(resources.GetObject("RibbonButton5.SmallImage"), System.Drawing.Image)
        Me.RibbonButton5.Text = "Discrecionalidad"
        Me.RibbonButton5.Visible = False
        '
        'RibbonGroup2
        '
        Me.RibbonGroup2.ID = "RibbonGroup2"
        Me.RibbonGroup2.Items.Add(Me.RibbonButton3)
        Me.RibbonGroup2.Items.Add(Me.RibbonProductor)
        Me.RibbonGroup2.Items.Add(Me.RibbonButton31)
        Me.RibbonGroup2.Text = "Catalogos"
        '
        'RibbonButton3
        '
        Me.RibbonButton3.ID = "RibbonButton3"
        Me.RibbonButton3.LargeImage = CType(resources.GetObject("RibbonButton3.LargeImage"), System.Drawing.Image)
        Me.RibbonButton3.SmallImage = CType(resources.GetObject("RibbonButton3.SmallImage"), System.Drawing.Image)
        Me.RibbonButton3.Text = "Tipos-Cafe"
        Me.RibbonButton3.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonProductor
        '
        Me.RibbonProductor.ID = "RibbonProductor"
        Me.RibbonProductor.LargeImage = CType(resources.GetObject("RibbonProductor.LargeImage"), System.Drawing.Image)
        Me.RibbonProductor.SmallImage = CType(resources.GetObject("RibbonProductor.SmallImage"), System.Drawing.Image)
        Me.RibbonProductor.Text = "Productor"
        Me.RibbonProductor.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton31
        '
        Me.RibbonButton31.ID = "RibbonButton31"
        Me.RibbonButton31.LargeImage = CType(resources.GetObject("RibbonButton31.LargeImage"), System.Drawing.Image)
        Me.RibbonButton31.SmallImage = CType(resources.GetObject("RibbonButton31.SmallImage"), System.Drawing.Image)
        Me.RibbonButton31.Text = "Configuracion"
        Me.RibbonButton31.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonGroup41
        '
        Me.RibbonGroup41.ID = "RibbonGroup41"
        Me.RibbonGroup41.Items.Add(Me.RibbonButton11)
        Me.RibbonGroup41.Text = "Reportes"
        '
        'RibbonButton11
        '
        Me.RibbonButton11.ID = "RibbonButton11"
        Me.RibbonButton11.LargeImage = CType(resources.GetObject("RibbonButton11.LargeImage"), System.Drawing.Image)
        Me.RibbonButton11.SmallImage = CType(resources.GetObject("RibbonButton11.SmallImage"), System.Drawing.Image)
        Me.RibbonButton11.Text = "Trazabilidad"
        Me.RibbonButton11.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.RibbonButton11.ToolTip = "Registro de Trazabilidad"
        '
        'RibbonGroup4
        '
        Me.RibbonGroup4.ID = "RibbonGroup4"
        Me.RibbonGroup4.Items.Add(Me.RibbonButton1)
        Me.RibbonGroup4.Text = "Salir"
        '
        'RibbonButton1
        '
        Me.RibbonButton1.ID = "RibbonButton1"
        Me.RibbonButton1.LargeImage = CType(resources.GetObject("RibbonButton1.LargeImage"), System.Drawing.Image)
        Me.RibbonButton1.SmallImage = CType(resources.GetObject("RibbonButton1.SmallImage"), System.Drawing.Image)
        Me.RibbonButton1.Text = "Salir"
        Me.RibbonButton1.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonTab2
        '
        Me.RibbonTab2.Groups.Add(Me.RibbonGroup6)
        Me.RibbonTab2.ID = "RibbonTab2"
        Me.RibbonTab2.Text = "Relaciones"
        '
        'RibbonGroup6
        '
        Me.RibbonGroup6.ID = "RibbonGroup6"
        Me.RibbonGroup6.Items.Add(Me.RibbonButton311)
        Me.RibbonGroup6.Items.Add(Me.RibbonButton3111)
        Me.RibbonGroup6.Items.Add(Me.RibbonButton311111)
        Me.RibbonGroup6.Items.Add(Me.RibbonButton31111)
        Me.RibbonGroup6.Items.Add(Me.RibbonButton311112)
        Me.RibbonGroup6.Text = "Group"
        '
        'RibbonButton311
        '
        Me.RibbonButton311.ID = "RibbonButton311"
        Me.RibbonButton311.LargeImage = CType(resources.GetObject("RibbonButton311.LargeImage"), System.Drawing.Image)
        Me.RibbonButton311.SmallImage = CType(resources.GetObject("RibbonButton311.SmallImage"), System.Drawing.Image)
        Me.RibbonButton311.Text = "Calidad-Categ"
        Me.RibbonButton311.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton3111
        '
        Me.RibbonButton3111.ID = "RibbonButton3111"
        Me.RibbonButton3111.LargeImage = CType(resources.GetObject("RibbonButton3111.LargeImage"), System.Drawing.Image)
        Me.RibbonButton3111.SmallImage = CType(resources.GetObject("RibbonButton3111.SmallImage"), System.Drawing.Image)
        Me.RibbonButton3111.Text = "Calidad-Daño"
        Me.RibbonButton3111.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton311111
        '
        Me.RibbonButton311111.ID = "RibbonButton311111"
        Me.RibbonButton311111.LargeImage = CType(resources.GetObject("RibbonButton311111.LargeImage"), System.Drawing.Image)
        Me.RibbonButton311111.SmallImage = CType(resources.GetObject("RibbonButton311111.SmallImage"), System.Drawing.Image)
        Me.RibbonButton311111.Text = "Calidad-EFisico"
        Me.RibbonButton311111.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton31111
        '
        Me.RibbonButton31111.ID = "RibbonButton31111"
        Me.RibbonButton31111.LargeImage = CType(resources.GetObject("RibbonButton31111.LargeImage"), System.Drawing.Image)
        Me.RibbonButton31111.SmallImage = CType(resources.GetObject("RibbonButton31111.SmallImage"), System.Drawing.Image)
        Me.RibbonButton31111.Text = "T.Cafe-T.Compra"
        Me.RibbonButton31111.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton311112
        '
        Me.RibbonButton311112.ID = "RibbonButton311112"
        Me.RibbonButton311112.LargeImage = CType(resources.GetObject("RibbonButton311112.LargeImage"), System.Drawing.Image)
        Me.RibbonButton311112.SmallImage = CType(resources.GetObject("RibbonButton311112.SmallImage"), System.Drawing.Image)
        Me.RibbonButton311112.Text = "TipoCafe-Calidad"
        Me.RibbonButton311112.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 599)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.RightPaneItems.Add(Me.RibbonLabel1)
        Me.C1StatusBar1.Size = New System.Drawing.Size(1150, 22)
        Me.C1StatusBar1.TabIndex = 1
        '
        'RibbonLabel1
        '
        Me.RibbonLabel1.ID = "RibbonLabel1"
        Me.RibbonLabel1.Text = "Version  1.23"
        '
        'CmdHoraLlegada
        '
        Me.CmdHoraLlegada.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdHoraLlegada.Image = CType(resources.GetObject("CmdHoraLlegada.Image"), System.Drawing.Image)
        Me.CmdHoraLlegada.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdHoraLlegada.Location = New System.Drawing.Point(234, 337)
        Me.CmdHoraLlegada.Name = "CmdHoraLlegada"
        Me.CmdHoraLlegada.Size = New System.Drawing.Size(173, 184)
        Me.CmdHoraLlegada.TabIndex = 8
        Me.CmdHoraLlegada.Text = "Hora de Llegada"
        Me.CmdHoraLlegada.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdHoraLlegada.UseVisualStyleBackColor = True
        Me.CmdHoraLlegada.Visible = False
        '
        'CmdCargar
        '
        Me.CmdCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCargar.Image = CType(resources.GetObject("CmdCargar.Image"), System.Drawing.Image)
        Me.CmdCargar.Location = New System.Drawing.Point(451, 337)
        Me.CmdCargar.Name = "CmdCargar"
        Me.CmdCargar.Size = New System.Drawing.Size(173, 184)
        Me.CmdCargar.TabIndex = 7
        Me.CmdCargar.Text = "Cargar Productos"
        Me.CmdCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdCargar.UseVisualStyleBackColor = True
        Me.CmdCargar.Visible = False
        '
        'CmdReservar
        '
        Me.CmdReservar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReservar.Image = CType(resources.GetObject("CmdReservar.Image"), System.Drawing.Image)
        Me.CmdReservar.Location = New System.Drawing.Point(664, 337)
        Me.CmdReservar.Name = "CmdReservar"
        Me.CmdReservar.Size = New System.Drawing.Size(173, 184)
        Me.CmdReservar.TabIndex = 6
        Me.CmdReservar.Text = "Tiempo de Espera en Despacho"
        Me.CmdReservar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdReservar.UseVisualStyleBackColor = True
        Me.CmdReservar.Visible = False
        '
        'CmdSalida
        '
        Me.CmdSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSalida.Image = CType(resources.GetObject("CmdSalida.Image"), System.Drawing.Image)
        Me.CmdSalida.Location = New System.Drawing.Point(866, 337)
        Me.CmdSalida.Name = "CmdSalida"
        Me.CmdSalida.Size = New System.Drawing.Size(173, 184)
        Me.CmdSalida.TabIndex = 9
        Me.CmdSalida.Text = "Hora Salida"
        Me.CmdSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdSalida.UseVisualStyleBackColor = True
        Me.CmdSalida.Visible = False
        '
        'CmdReporta
        '
        Me.CmdReporta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReporta.Image = CType(resources.GetObject("CmdReporta.Image"), System.Drawing.Image)
        Me.CmdReporta.Location = New System.Drawing.Point(21, 337)
        Me.CmdReporta.Name = "CmdReporta"
        Me.CmdReporta.Size = New System.Drawing.Size(173, 184)
        Me.CmdReporta.TabIndex = 11
        Me.CmdReporta.Text = "Reporta Existencia"
        Me.CmdReporta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdReporta.UseVisualStyleBackColor = True
        Me.CmdReporta.Visible = False
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1150, 621)
        Me.Controls.Add(Me.CmdReporta)
        Me.Controls.Add(Me.CmdSalida)
        Me.Controls.Add(Me.CmdHoraLlegada)
        Me.Controls.Add(Me.CmdCargar)
        Me.Controls.Add(Me.CmdReservar)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.C1Ribbon1)
        Me.IsMdiContainer = True
        Me.Name = "MDIParent1"
        Me.Text = "Sistema de Recepcion"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Black
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1Ribbon1 As C1.Win.C1Ribbon.C1Ribbon
    Friend WithEvents RibbonApplicationMenu1 As C1.Win.C1Ribbon.RibbonApplicationMenu
    Friend WithEvents RibbonConfigToolBar1 As C1.Win.C1Ribbon.RibbonConfigToolBar
    Friend WithEvents RibbonQat1 As C1.Win.C1Ribbon.RibbonQat
    Friend WithEvents RibbonTab1 As C1.Win.C1Ribbon.RibbonTab
    Friend WithEvents RibbonGroup1 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents Productos As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents RibbonButton12 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonGroup4 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents RibbonButton1 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonSeparator1 As C1.Win.C1Ribbon.RibbonSeparator
    Friend WithEvents RibbonExit As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton711 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents CmdHoraLlegada As System.Windows.Forms.Button
    Friend WithEvents CmdCargar As System.Windows.Forms.Button
    Friend WithEvents CmdReservar As System.Windows.Forms.Button
    Friend WithEvents CmdSalida As System.Windows.Forms.Button
    Friend WithEvents Proveedores As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents Configuracion As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RbnSalir As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonGroup41 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents RibbonButton11 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents CmdReporta As System.Windows.Forms.Button
    Friend WithEvents RibbonGroup2 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents RibbonButton3 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonProductor As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton31 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonTab2 As C1.Win.C1Ribbon.RibbonTab
    Friend WithEvents RibbonGroup6 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents RibbonButton311 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton3111 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton311111 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton31111 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton311112 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton2 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton4 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonLabel1 As C1.Win.C1Ribbon.RibbonLabel
    Friend WithEvents RibbonButton21 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton5 As C1.Win.C1Ribbon.RibbonButton

End Class
