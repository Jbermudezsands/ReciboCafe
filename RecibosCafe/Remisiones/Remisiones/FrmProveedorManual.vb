Public Class FrmProveedorManual

    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmProveedorManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtFinca.Text = ""
        Me.TxtMerma.Text = ""
        Me.TxtNombre.Text = ""
        Me.TxtNumeroCedula.Text = ""
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Forms.FrmTecladoLetras.ShowDialog()
        Me.TxtNombre.Text = My.Forms.FrmTecladoLetras.EscrituraTeclado
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Forms.FrmTecladoLetras.ShowDialog()
        Me.TxtNumeroCedula.Text = My.Forms.FrmTecladoLetras.EscrituraTeclado
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Forms.FrmTecladoLetras.ShowDialog()
        Me.TxtFinca.Text = My.Forms.FrmTecladoLetras.EscrituraTeclado
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.TxtFinca.Text = ""
        Me.TxtMerma.Text = ""
        Me.TxtNombre.Text = ""
        Me.TxtNumeroCedula.Text = ""
        Me.Close()
    End Sub

    Private Sub CmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGrabar.Click

        If Len(Me.TxtNumeroCedula.Text) < 14 Then
            MsgBox("El Numero de Cedula es Menor a 14 digitos", MsgBoxStyle.Critical, "Recibos")
            Exit Sub
        End If

        FrmRecepcion.CboCodigoProveedor.Text = Me.CboCodigoProveedor.Text
        FrmRecepcion.txtnombre.Text = Me.TxtNombre.Text
        FrmRecepcion.TxtFinca.Text = Me.TxtFinca.Text
        FrmRecepcion.TxtNumeroCedula.Text = Me.TxtNumeroCedula.Text
        Me.Close()

    End Sub
End Class