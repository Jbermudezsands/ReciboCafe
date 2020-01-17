Public Class FrmTecladoLetra
    Public EscrituraTeclado As String = ""

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TxtCadena.Text = ""
    End Sub

    Private Sub C1Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdI.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "i"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "I"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "8"

        End If
    End Sub

    Private Sub C1Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdO.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "o"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "O"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "9"

        End If
    End Sub

    Private Sub C1Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub CmdMinusculas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdMayusculas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CmdMinusculas.Visible = True Then
            Me.CmdMayusculas.Visible = True
            Me.CmdMinusculas.Visible = False
            LetraTecla(False)
        Else
            Me.CmdMayusculas.Visible = False
            Me.CmdMinusculas.Visible = True
            LetraTecla(True)
        End If
    End Sub

    Private Sub SimpleButton30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdLetras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdP.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "p"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "P"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "0"

        End If
    End Sub

    Private Sub CmdQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdQ.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "q"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "Q"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "1"

        End If

    End Sub

    Private Sub CmdW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdW.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "w"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "W"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "2"

        End If

    End Sub

    Private Sub CmdE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdE.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "e"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "E"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "3"

        End If
    End Sub

    Private Sub CmdR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdR.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "r"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "R"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "4"

        End If
    End Sub

    Private Sub CmdT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdT.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "t"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "T"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "5"

        End If
    End Sub

    Private Sub CmdY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdY.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "y"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "Y"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "6"

        End If
    End Sub

    Private Sub CmdU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdU.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "u"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "U"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "7"

        End If
    End Sub

    Private Sub CmdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdA.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "a"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "A"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "!"

        End If
    End Sub

    Private Sub CmdS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdS.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "s"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "S"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "@"

        End If
    End Sub

    Private Sub CmdD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdD.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "d"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "D"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "#"

        End If
    End Sub

    Private Sub CmdF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdF.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "f"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "F"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "$"

        End If
    End Sub

    Private Sub CmdG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdG.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "g"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "G"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "/"

        End If
    End Sub

    Private Sub CmdH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdH.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "h"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "H"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "+"

        End If
    End Sub

    Private Sub CmdJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdJ.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "j"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "J"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & " "

        End If
    End Sub

    Private Sub CmdK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdK.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "k"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "K"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "*"

        End If
    End Sub

    Private Sub CmdL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdL.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "l"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "L"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "("

        End If
    End Sub

    Private Sub Cmd—_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd—.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "Ò"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "—"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & ")"

        End If
    End Sub

    Private Sub CmdZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdZ.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "z"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "Z"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "-"

        End If
    End Sub

    Private Sub CmdX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdX.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "x"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "X"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "%"

        End If
    End Sub

    Private Sub CmdC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdC.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "c"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "C"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "="

        End If

    End Sub

    Private Sub CmdV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdV.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "v"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "V"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "?"

        End If
    End Sub

    Private Sub CmdB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdB.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "b"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "B"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & "ø"

        End If
    End Sub

    Private Sub CmdN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdN.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "n"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "N"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & ":"

        End If
    End Sub

    Private Sub CmdM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdM.Click
        If Me.CmdNumeros.Visible = True Then
            '----------------------QUIERE DECIR QUE SON LETRAS
            If Me.CmdMinusculas.Visible = True Then
                Me.TxtCadena.Text = Me.TxtCadena.Text & "m"
            Else
                Me.TxtCadena.Text = Me.TxtCadena.Text & "M"
            End If

        Else
            '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
            Me.TxtCadena.Text = Me.TxtCadena.Text & ";"

        End If
    End Sub

    Private Sub C1Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button28.Click

        '---------------------QUIERE DECIR QUE SON NUMEROS ------------------------
        Me.TxtCadena.Text = Me.TxtCadena.Text & "."

    End Sub

    Private Sub CmdEspacio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEspacio.Click
        Me.TxtCadena.Text = Me.TxtCadena.Text & " "
    End Sub

    Private Sub TxtCadena_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCadena.TextChanged

    End Sub

    Private Sub SimpleButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub SimpleButton33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CmdMayusculas_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMayusculas.Click
        If CmdMinusculas.Visible = True Then
            Me.CmdMayusculas.Visible = True
            Me.CmdMinusculas.Visible = False
            LetraTecla(False)
        Else
            Me.CmdMayusculas.Visible = False
            Me.CmdMinusculas.Visible = True
            LetraTecla(True)
        End If
    End Sub

    Private Sub CmdMinusculass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMinusculas.Click
        If CmdMinusculas.Visible = True Then
            Me.CmdMayusculas.Visible = True
            Me.CmdMinusculas.Visible = False
            LetraTecla(False)
        Else
            Me.CmdMayusculas.Visible = False
            Me.CmdMinusculas.Visible = True
            LetraTecla(True)
        End If
    End Sub

    Private Sub CmdNumeros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNumeros.Click
        If Me.CmdNumeros.Visible = True Then
            Me.CmdLetras.Visible = True
            Me.CmdNumeros.Visible = False
            NumeroTecla(True)
            Me.CmdMayusculas.Enabled = False
            Me.CmdMinusculas.Enabled = False
        End If
    End Sub

    Private Sub CmdLetras_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdLetras.Click
        If Me.CmdNumeros.Visible = False Then
            Me.CmdLetras.Visible = False
            Me.CmdNumeros.Visible = True
            NumeroTecla(False)
            Me.CmdMayusculas.Visible = False
            Me.CmdMinusculas.Visible = True
            Me.CmdMayusculas.Enabled = True
            Me.CmdMinusculas.Enabled = True
            LetraTecla(True)
        End If
    End Sub

    Private Sub CmdBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBorrar.Click
        Dim Posicion As Double, i As Double = 0, Longitud As Double = 0, CadenaNueva As String = "", Cadena As String
        Dim PosicionFinal As Double = 0
        Dim cadenass As TextBox

        Me.TxtCadena.Select(Me.TxtCadena.Text.Length, 0)
        Cadena = Me.TxtCadena.Text
        Longitud = Len(Me.TxtCadena.Text)
        'me.TxtCadena.
        Posicion = Me.TxtCadena.SelectionStart
        PosicionFinal = Posicion + Me.TxtCadena.SelectionLength





        If Posicion = PosicionFinal Then
            For i = 0 To Longitud - 1
                If i <> Posicion - 1 Then
                    CadenaNueva = CadenaNueva & Cadena.Chars(i)
                End If
            Next
        Else
            For i = 0 To Longitud - 1
                If i < Posicion Then
                    CadenaNueva = CadenaNueva & Cadena.Chars(i)
                ElseIf i > PosicionFinal - 1 Then
                    CadenaNueva = CadenaNueva & Cadena.Chars(i)
                End If
            Next

        End If

        Me.TxtCadena.Text = CadenaNueva
        If Posicion = 0 Then
            Me.TxtCadena.SelectionStart = 0
        Else
            Me.TxtCadena.SelectionStart = Posicion - 1
        End If
        Me.TxtCadena.Focus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        EscrituraTeclado = Me.TxtCadena.Text
        Me.Close()
    End Sub
End Class
