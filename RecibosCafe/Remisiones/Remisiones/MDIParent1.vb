Public Class MDIParent1

    Private Sub RibbonButton32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton32.Click
        'My.Forms.FrmRemision.MdiParent = Me
        My.Forms.FrmRemision.Show()
    End Sub

    Private Sub RibbonButton30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton30.Click
        My.Forms.FrmUsuarios.MdiParent = Me

        Me.Button1.Visible = False
        Me.Button2.Visible = False
        Me.Button3.Visible = False
        My.Forms.FrmUsuarios.Show()


    End Sub

    Private Sub RibbonButton31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton31.Click
        My.Forms.FrmConfigurar.MdiParent = Me
        Me.Button1.Visible = False
        Me.Button2.Visible = False
        Me.Button3.Visible = False
        My.Forms.FrmConfigurar.Show()
    End Sub

    Private Sub RibbonButton321_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton321.Click
        My.Forms.FrmLectura.TxtTipo.Text = "Entrada"
        My.Forms.FrmLectura.LblRegistros.Text = "REGISTRO DE ENTRADA"
        'My.Forms.FrmLectura.MdiParent = Me
        My.Forms.FrmLectura.Show()
    End Sub

    Private Sub RibbonButton3211_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton3211.Click
        My.Forms.FrmLectura.TxtTipo.Text = "Salida"
        My.Forms.FrmLectura.LblRegistros.Text = "REGISTRO DE SALIDA"
        'My.Forms.FrmLectura.MdiParent = Me
        My.Forms.FrmLectura.Show()
    End Sub

    Private Sub RibbonButton322_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton322.Click

        My.Forms.FrmReimpresion.MdiParent = Me
        My.Forms.FrmReimpresion.Show()
    End Sub

    Private Sub MDIParent1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Dim MyRuta As String, SqlString As String, Ruta As String
        Dim fileReader As String = ""

        Ruta = My.Application.Info.DirectoryPath & "\Cosecha.txt"
        If Dir(Ruta) <> "" Then
            fileReader = My.Computer.FileSystem.ReadAllText(Ruta)
            CodigoCosecha = fileReader
        Else
            MsgBox("No Existe el Archivo Cosecha", MsgBoxStyle.Critical, "Sistema PuntoRevision")
        End If
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RibbonApplicationMenu1.DropDownWidth = 115

        Select Case TipoUsuario
            Case "Planta"
                Me.RibbonButton31.Enabled = False
                Me.RibbonButton30.Enabled = False
                Me.RibbonButton311.Enabled = False

            Case "Entrada/Salida"
                Me.RibbonButton32.Enabled = False
                Me.RibbonButton31.Enabled = False
                Me.RibbonButton30.Enabled = False
                Me.RibbonButton311.Enabled = False
                Me.Button3.Enabled = False

            Case "Punto Control"
                Me.RibbonButton31.Enabled = False
                Me.RibbonButton30.Enabled = False
                Me.RibbonButton321.Enabled = False
                Me.RibbonButton3211.Enabled = False
                Me.RibbonButton311.Enabled = False
                Me.Button1.Enabled = False
                Me.Button2.Enabled = False

            Case "Administrador"
                Me.RibbonButton31.Enabled = True
                Me.RibbonButton30.Enabled = True

        End Select




    End Sub

    Private Sub RibbonButton311_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton311.Click
        My.Forms.FrmBitacora.MdiParent = Me

        Me.Button1.Visible = False
        Me.Button2.Visible = False
        Me.Button3.Visible = False
        My.Forms.FrmBitacora.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Forms.FrmLectura.TxtTipo.Text = "Entrada"
        My.Forms.FrmLectura.LblRegistros.Text = "REGISTRO DE ENTRADA"
        My.Forms.FrmLectura.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Forms.FrmLectura.TxtTipo.Text = "Salida"
        My.Forms.FrmLectura.LblRegistros.Text = "REGISTRO DE SALIDA"
        My.Forms.FrmLectura.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Forms.FrmRemision.Show()
    End Sub

    Private Sub RibbonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibbonButton1.Click
        My.Forms.FrmEditarRemision.MdiParent = Me
        Me.Button1.Visible = False
        Me.Button2.Visible = False
        Me.Button3.Visible = False
        My.Forms.FrmEditarRemision.Show()
    End Sub

    Private Sub C1Ribbon1_RibbonEvent(ByVal sender As System.Object, ByVal e As C1.Win.C1Ribbon.RibbonEventArgs) Handles C1Ribbon1.RibbonEvent

    End Sub
End Class