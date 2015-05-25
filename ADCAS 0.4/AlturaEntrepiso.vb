Public Class AlturasEntrepiso
    Public Shared Hsup As Double
    Public Shared Hinf As Double

    Private Sub AlturasEntrepiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        If Hinf <> 0 Then
            TextBox2.Text = Hinf.ToString
        Else
            TextBox2.Clear()
        End If
        If ADCAS.ComboBox2.SelectedIndex = 0 Then
            TextBox1.Enabled = False
            TextBox1.Clear()
        Else
            TextBox1.Enabled = True
            If Hsup <> 0 Then
                TextBox1.Text = Hsup.ToString
            Else
                TextBox1.Clear()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        soloNumeros(Me.TextBox1, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2__KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        soloNumeros(Me.TextBox2, e)
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("Es necesario indicar la altura del entrepiso", MsgBoxStyle.Exclamation, "Dato faltante")
        ElseIf TextBox1.Enabled = True And TextBox1.Text = "" Then
            MsgBox("Es necesario indicar la altura del entrepiso", MsgBoxStyle.Exclamation, "Dato faltante")
        Else
            Hsup = Val(TextBox1.Text)
            Hinf = Val(TextBox2.Text)
            Me.Close()
            'MsgBox(Hsup.ToString + "  " + Hinf.ToString)
        End If

    End Sub

End Class