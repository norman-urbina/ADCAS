Public Class Carriostre
    Public Sub soloNumeros(ByVal CajaTexto As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Carriostre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If abierto = True Then
            'TextBox3.Text = P_Darr.ToString
            'TextBox2.Text = P_Larr.ToString
            'TextBox1.Text = P_QEarr.ToString
            'TextBox6.Text = V_Darr.ToString
            'TextBox5.Text = V_Larr.ToString
            'TextBox4.Text = V_QEarr.ToString
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        soloNumeros(Me.TextBox3, e)
        If Asc(e.KeyChar) = 13 Then
            If TextBox3.Text = "" Then
            Else
                TextBox2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        soloNumeros(Me.TextBox2, e)
        If Asc(e.KeyChar) = 13 Then
            If TextBox2.Text = "" Then
            Else
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        soloNumeros(Me.TextBox1, e)
        If Asc(e.KeyChar) = 13 Then
            If TextBox1.Text = "" Then
            Else
                TextBox6.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        soloNumeros(Me.TextBox6, e)
        If Asc(e.KeyChar) = 13 Then
            If TextBox6.Text = "" Then
            Else
                TextBox5.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        soloNumeros(Me.TextBox5, e)
        If Asc(e.KeyChar) = 13 Then
            If TextBox5.Text = "" Then
            Else
                TextBox4.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        soloNumeros(Me.TextBox4, e)
        If Asc(e.KeyChar) = 13 Then
            If TextBox4.Text = "" Then
            Else
                Button1.Focus()
            End If
        End If
    End Sub
    Public Shared abierto As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Por favor introduzca todas las cargas.", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            abierto = True
            'P_Darr = Double.Parse(TextBox3.Text)
            'P_Larr = Double.Parse(TextBox2.Text)
            'P_QEarr = Double.Parse(TextBox1.Text)
            'V_Darr = Double.Parse(TextBox6.Text)
            'V_Larr = Double.Parse(TextBox5.Text)
            'V_QEarr = Double.Parse(TextBox4.Text)

            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class