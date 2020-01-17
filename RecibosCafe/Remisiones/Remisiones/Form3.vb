Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Centrar el Panel
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize       'Captura el Tamaño del Monitor
        Dim alto As Int32 = (desktopSize.Height - 280) \ 2
        Dim ancho As Int32 = (desktopSize.Width - 500) \ 2
        panel1.Location = New Point(ancho, alto)
        'Fin centrar el Panel

        'Mostrar Fecha y Hora
        lblFecha.Text = DateTime.Now.ToLongDateString()
        lblHora.Text = DateTime.Now.ToLongTimeString()
    End Sub
    Private Sub pictureBox1_Click(sender As Object, e As EventArgs) Handles pictureBox1.Click

        If txtuser.Text.Trim() = "" Then
            MessageBox.Show("Asegúrese de ingresar el Usuario")
            txtuser.Focus()
        ElseIf txtpass.Text.Trim() = "" Then
            MessageBox.Show("Asegúrese de ingresar la Contraseña")
            txtpass.Focus()
        Else
            MessageBox.Show("Bienvenido Sr(a): " & txtuser.Text)
            Me.Hide()
            Dim fr As New Principal()
            fr.Show()
        End If

    End Sub

    Private Sub btnmin_Click(sender As Object, e As EventArgs) Handles btnmin.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        If MessageBox.Show("Estas seguro que desea Salir", "◄ AVISO | The Soft Team ►", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub pictureBox1_MouseHover(sender As Object, e As EventArgs) Handles pictureBox1.MouseHover
        'pictureBox1.Size = New Size(100, 92)
        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Sub pictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles pictureBox1.MouseLeave
        'pictureBox1.Size = New Size(90, 85)
        pictureBox1.BackgroundImageLayout = ImageLayout.Zoom
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Actualizar cada segundo la Hora
        lblHora.Text = DateTime.Now.ToLongTimeString()
    End Sub

    Private Sub panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panel1.Paint

    End Sub
End Class

