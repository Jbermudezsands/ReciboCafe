<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmResumenCalculoPrecio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmResumenCalculoPrecio))
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.BtnImprimir = New System.Windows.Forms.Button
        Me.BtnRefrescar = New System.Windows.Forms.Button
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.TrueDBHistoricoCPrecio = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Button9 = New System.Windows.Forms.Button
        Me.GroupBox7.SuspendLayout()
        CType(Me.TrueDBHistoricoCPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.GroupBox7.Controls.Add(Me.Button1)
        Me.GroupBox7.Controls.Add(Me.BtnImprimir)
        Me.GroupBox7.Controls.Add(Me.BtnRefrescar)
        Me.GroupBox7.Controls.Add(Me.BtnNuevo)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(1024, 60)
        Me.GroupBox7.TabIndex = 241
        Me.GroupBox7.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Remisiones.My.Resources.Resources.Refresh48
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(546, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(177, 48)
        Me.Button1.TabIndex = 254
        Me.Button1.Text = "CALCULAR PRECIO"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Enabled = False
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Image = Global.Remisiones.My.Resources.Resources.icons8_print_48
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(887, 10)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(131, 48)
        Me.BtnImprimir.TabIndex = 253
        Me.BtnImprimir.Text = "EXPORTAR"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnRefrescar
        '
        Me.BtnRefrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefrescar.Image = Global.Remisiones.My.Resources.Resources.Refresh48
        Me.BtnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRefrescar.Location = New System.Drawing.Point(264, 9)
        Me.BtnRefrescar.Name = "BtnRefrescar"
        Me.BtnRefrescar.Size = New System.Drawing.Size(131, 48)
        Me.BtnRefrescar.TabIndex = 252
        Me.BtnRefrescar.Text = "REFRESCAR"
        Me.BtnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRefrescar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = Global.Remisiones.My.Resources.Resources.New48__2_
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(3, 9)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(131, 48)
        Me.BtnNuevo.TabIndex = 250
        Me.BtnNuevo.Text = "NUEVO "
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'TrueDBHistoricoCPrecio
        '
        Me.TrueDBHistoricoCPrecio.AllowUpdate = False
        Me.TrueDBHistoricoCPrecio.AlternatingRows = True
        Me.TrueDBHistoricoCPrecio.Caption = "Historicos De Precios Calculados"
        Me.TrueDBHistoricoCPrecio.FilterBar = True
        Me.TrueDBHistoricoCPrecio.GroupByCaption = "Drag a column header here to group by that column"
        Me.TrueDBHistoricoCPrecio.Images.Add(CType(resources.GetObject("TrueDBHistoricoCPrecio.Images"), System.Drawing.Image))
        Me.TrueDBHistoricoCPrecio.Location = New System.Drawing.Point(11, 95)
        Me.TrueDBHistoricoCPrecio.Name = "TrueDBHistoricoCPrecio"
        Me.TrueDBHistoricoCPrecio.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.TrueDBHistoricoCPrecio.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.TrueDBHistoricoCPrecio.PreviewInfo.ZoomFactor = 75
        Me.TrueDBHistoricoCPrecio.PrintInfo.PageSettings = CType(resources.GetObject("TrueDBHistoricoCPrecio.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.TrueDBHistoricoCPrecio.Size = New System.Drawing.Size(1022, 305)
        Me.TrueDBHistoricoCPrecio.TabIndex = 242
        Me.TrueDBHistoricoCPrecio.Text = "C1TrueDBGrid1"
        Me.TrueDBHistoricoCPrecio.PropBag = resources.GetString("TrueDBHistoricoCPrecio.PropBag")
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Image = Global.Remisiones.My.Resources.Resources.Exit_64
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(906, 416)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(127, 75)
        Me.Button9.TabIndex = 243
        Me.Button9.Text = "Salir"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = True
        '
        'FrmResumenCalculoPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1045, 503)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.TrueDBHistoricoCPrecio)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "FrmResumenCalculoPrecio"
        Me.Text = "FrmResumenCalculoPrecio"
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.TrueDBHistoricoCPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnRefrescar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents TrueDBHistoricoCPrecio As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
