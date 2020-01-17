<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.C1Ribbon1 = New C1.Win.C1Ribbon.C1Ribbon
        Me.RibbonApplicationMenu1 = New C1.Win.C1Ribbon.RibbonApplicationMenu
        Me.RibbonButton2 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonConfigToolBar1 = New C1.Win.C1Ribbon.RibbonConfigToolBar
        Me.RibbonQat1 = New C1.Win.C1Ribbon.RibbonQat
        Me.RibbonTab1 = New C1.Win.C1Ribbon.RibbonTab
        Me.RibbonGroup11 = New C1.Win.C1Ribbon.RibbonGroup
        Me.RibbonButton32 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton322 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton321 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton3211 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton30 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton311 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton1 = New C1.Win.C1Ribbon.RibbonButton
        Me.RibbonButton31 = New C1.Win.C1Ribbon.RibbonButton
        Me.C1StatusBar1 = New C1.Win.C1Ribbon.C1StatusBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
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
        Me.C1Ribbon1.Size = New System.Drawing.Size(1020, 142)
        Me.C1Ribbon1.TabIndex = 0
        Me.C1Ribbon1.Tabs.Add(Me.RibbonTab1)
        Me.C1Ribbon1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Silver
        '
        'RibbonApplicationMenu1
        '
        Me.RibbonApplicationMenu1.ID = "RibbonApplicationMenu1"
        Me.RibbonApplicationMenu1.LargeImage = CType(resources.GetObject("RibbonApplicationMenu1.LargeImage"), System.Drawing.Image)
        Me.RibbonApplicationMenu1.LeftPaneItems.Add(Me.RibbonButton2)
        '
        'RibbonButton2
        '
        Me.RibbonButton2.ID = "RibbonButton2"
        Me.RibbonButton2.LargeImage = CType(resources.GetObject("RibbonButton2.LargeImage"), System.Drawing.Image)
        Me.RibbonButton2.Text = "Button"
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
        Me.RibbonTab1.Groups.Add(Me.RibbonGroup11)
        Me.RibbonTab1.ID = "RibbonTab1"
        Me.RibbonTab1.Text = "Accesos"
        '
        'RibbonGroup11
        '
        Me.RibbonGroup11.ID = "RibbonGroup11"
        Me.RibbonGroup11.Items.Add(Me.RibbonButton32)
        Me.RibbonGroup11.Items.Add(Me.RibbonButton322)
        Me.RibbonGroup11.Items.Add(Me.RibbonButton321)
        Me.RibbonGroup11.Items.Add(Me.RibbonButton3211)
        Me.RibbonGroup11.Items.Add(Me.RibbonButton30)
        Me.RibbonGroup11.Items.Add(Me.RibbonButton311)
        Me.RibbonGroup11.Items.Add(Me.RibbonButton1)
        Me.RibbonGroup11.Items.Add(Me.RibbonButton31)
        Me.RibbonGroup11.Text = "Configuracion"
        '
        'RibbonButton32
        '
        Me.RibbonButton32.ID = "RibbonButton32"
        Me.RibbonButton32.LargeImage = CType(resources.GetObject("RibbonButton32.LargeImage"), System.Drawing.Image)
        Me.RibbonButton32.SmallImage = CType(resources.GetObject("RibbonButton32.SmallImage"), System.Drawing.Image)
        Me.RibbonButton32.Text = "Punto-Control"
        Me.RibbonButton32.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton322
        '
        Me.RibbonButton322.ID = "RibbonButton322"
        Me.RibbonButton322.LargeImage = CType(resources.GetObject("RibbonButton322.LargeImage"), System.Drawing.Image)
        Me.RibbonButton322.SmallImage = CType(resources.GetObject("RibbonButton322.SmallImage"), System.Drawing.Image)
        Me.RibbonButton322.Text = "ReImpresion"
        Me.RibbonButton322.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        Me.RibbonButton322.Visible = False
        '
        'RibbonButton321
        '
        Me.RibbonButton321.ID = "RibbonButton321"
        Me.RibbonButton321.LargeImage = CType(resources.GetObject("RibbonButton321.LargeImage"), System.Drawing.Image)
        Me.RibbonButton321.SmallImage = CType(resources.GetObject("RibbonButton321.SmallImage"), System.Drawing.Image)
        Me.RibbonButton321.Text = "Entrada"
        Me.RibbonButton321.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton3211
        '
        Me.RibbonButton3211.ID = "RibbonButton3211"
        Me.RibbonButton3211.LargeImage = CType(resources.GetObject("RibbonButton3211.LargeImage"), System.Drawing.Image)
        Me.RibbonButton3211.SmallImage = CType(resources.GetObject("RibbonButton3211.SmallImage"), System.Drawing.Image)
        Me.RibbonButton3211.Text = "Salida"
        Me.RibbonButton3211.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton30
        '
        Me.RibbonButton30.ID = "RibbonButton30"
        Me.RibbonButton30.LargeImage = CType(resources.GetObject("RibbonButton30.LargeImage"), System.Drawing.Image)
        Me.RibbonButton30.SmallImage = CType(resources.GetObject("RibbonButton30.SmallImage"), System.Drawing.Image)
        Me.RibbonButton30.Text = "Usuarios"
        Me.RibbonButton30.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton311
        '
        Me.RibbonButton311.ID = "RibbonButton311"
        Me.RibbonButton311.LargeImage = CType(resources.GetObject("RibbonButton311.LargeImage"), System.Drawing.Image)
        Me.RibbonButton311.SmallImage = CType(resources.GetObject("RibbonButton311.SmallImage"), System.Drawing.Image)
        Me.RibbonButton311.Text = "Bitacora"
        Me.RibbonButton311.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton1
        '
        Me.RibbonButton1.ID = "RibbonButton1"
        Me.RibbonButton1.LargeImage = CType(resources.GetObject("RibbonButton1.LargeImage"), System.Drawing.Image)
        Me.RibbonButton1.SmallImage = CType(resources.GetObject("RibbonButton1.SmallImage"), System.Drawing.Image)
        Me.RibbonButton1.Text = "Editar-Remisión"
        Me.RibbonButton1.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'RibbonButton31
        '
        Me.RibbonButton31.ID = "RibbonButton31"
        Me.RibbonButton31.LargeImage = CType(resources.GetObject("RibbonButton31.LargeImage"), System.Drawing.Image)
        Me.RibbonButton31.SmallImage = CType(resources.GetObject("RibbonButton31.SmallImage"), System.Drawing.Image)
        Me.RibbonButton31.Text = "Configuracion"
        Me.RibbonButton31.TextImageRelation = C1.Win.C1Ribbon.TextImageRelation.ImageAboveText
        '
        'C1StatusBar1
        '
        Me.C1StatusBar1.Location = New System.Drawing.Point(0, 634)
        Me.C1StatusBar1.Name = "C1StatusBar1"
        Me.C1StatusBar1.Size = New System.Drawing.Size(1020, 22)
        Me.C1StatusBar1.TabIndex = 1
        Me.C1StatusBar1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Silver
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(617, 285)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 184)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Salida"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(386, 285)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(173, 184)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Entrada"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(154, 285)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(173, 184)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Punto Control"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 656)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.C1StatusBar1)
        Me.Controls.Add(Me.C1Ribbon1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MDIParent1"
        Me.Text = "RECEPCION DE PRODUCTOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.C1Ribbon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1StatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1Ribbon1 As C1.Win.C1Ribbon.C1Ribbon
    Friend WithEvents RibbonConfigToolBar1 As C1.Win.C1Ribbon.RibbonConfigToolBar
    Friend WithEvents RibbonQat1 As C1.Win.C1Ribbon.RibbonQat
    Friend WithEvents RibbonTab1 As C1.Win.C1Ribbon.RibbonTab
    Friend WithEvents C1StatusBar1 As C1.Win.C1Ribbon.C1StatusBar
    Friend WithEvents RibbonGroup11 As C1.Win.C1Ribbon.RibbonGroup
    Friend WithEvents RibbonButton32 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton30 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton31 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton321 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton3211 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton322 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents RibbonButton311 As C1.Win.C1Ribbon.RibbonButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents RibbonButton1 As C1.Win.C1Ribbon.RibbonButton
    Private WithEvents RibbonApplicationMenu1 As C1.Win.C1Ribbon.RibbonApplicationMenu
    Friend WithEvents RibbonButton2 As C1.Win.C1Ribbon.RibbonButton
End Class
