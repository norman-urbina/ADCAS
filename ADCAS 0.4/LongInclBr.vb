Public Class LongInclBr

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.Text = String.Empty And TextBox2.Text = String.Empty) And (TextBox3.Text = String.Empty And TextBox4.Text = String.Empty) Then
            OpcionesDiseño.CheckBox9.Checked = False
        Else

            Dim ángulo1, ángulo2 As Double

            Lbr = Val(TextBox1.Text)
            Lbr2 = Val(TextBox3.Text)

            ángulo1 = Math.Round(Val(TextBox2.Text) * Math.PI / 180, 4)
            ángulo2 = Math.Round(Val(TextBox4.Text) * Math.PI / 180, 4)

            If ángulo1 <> Math.Round(theta, 4) Then
                theta = Val(TextBox2.Text) * Math.PI / 180
            End If

            If ángulo2 <> Math.Round(theta2, 4) Then
                theta2 = Val(TextBox4.Text) * Math.PI / 180
            End If

        End If

        Me.Close()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "/" And Not TextBox1.Text.IndexOf("/") Then
            e.Handled = True
        ElseIf e.KeyChar = "/" Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not TextBox1.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Dim exTexto As Integer
        If Asc(e.KeyChar) = 13 Then
            exTexto = Strings.InStr(TextBox1.Text, "/")
            If exTexto <> 0 Then
                TextBox1.Text = Frac2Num(TextBox1.Text)
            End If
            If TextBox1.Text <> String.Empty Then
                TextBox2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "/" And Not TextBox2.Text.IndexOf("/") Then
            e.Handled = True
        ElseIf e.KeyChar = "/" Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not TextBox2.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Dim exTexto As Integer

        If Asc(e.KeyChar) = 13 Then
            exTexto = Strings.InStr(TextBox2.Text, "/")

            If exTexto <> 0 Then
                TextBox2.Text = Frac2Num(TextBox2.Text)
            End If

            If TextBox2.Text <> String.Empty Then

                If Val(TextBox2.Text) < 30 Then
                    TextBox2.Text = 30
                ElseIf Val(TextBox2.Text) > 60 Then
                    TextBox2.Text = 60
                End If

                TextBox3.Focus()

            End If

        End If

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "/" And Not TextBox3.Text.IndexOf("/") Then
            e.Handled = True
        ElseIf e.KeyChar = "/" Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not TextBox3.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Dim exTexto As Integer
        If Asc(e.KeyChar) = 13 Then
            exTexto = Strings.InStr(TextBox3.Text, "/")
            If exTexto <> 0 Then
                TextBox3.Text = Frac2Num(TextBox3.Text)
            End If
            If TextBox3.Text <> String.Empty Then

                TextBox4.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "/" And Not TextBox4.Text.IndexOf("/") Then
            e.Handled = True
        ElseIf e.KeyChar = "/" Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not TextBox4.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Dim exTexto As Integer
        If Asc(e.KeyChar) = 13 Then
            exTexto = Strings.InStr(TextBox4.Text, "/")
            If exTexto <> 0 Then
                TextBox4.Text = Frac2Num(TextBox4.Text)
            End If
            If TextBox4.Text <> String.Empty Then
                If Val(TextBox4.Text) < 30 Then
                    TextBox4.Text = 30
                ElseIf Val(TextBox4.Text) > 60 Then
                    TextBox4.Text = 60
                End If
                Button1.Focus()
            End If
        End If
    End Sub

    Private Sub LongInclBr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (OpcionesDiseño.LthetaBr = 1 Or OpcionesDiseño.CheckBox9.Checked = True) And (Lbr <> 0 Or Lbr2 <> 0) Then
            TextBox1.Text = Lbr.ToString
            TextBox2.Text = Math.Round(theta * 180 / Math.PI, 2)
            TextBox3.Text = Lbr2.ToString
            TextBox4.Text = Math.Round(theta2 * 180 / Math.PI, 2)
        End If
        If Lbr = 0 Then
            TextBox1.Text = String.Empty
        End If
        If theta = 0 Then
            TextBox2.Text = String.Empty
        End If
        If Lbr2 = 0 Then
            TextBox3.Text = String.Empty
        End If
        If theta2 = 0 Then
            TextBox4.Text = String.Empty
        End If
    End Sub

End Class