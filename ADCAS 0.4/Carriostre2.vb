Public Class Carriostre2
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
    Public Shared abierto As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Then
            MsgBox("Por favor introduzca todas las cargas.", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            abierto = True
            'V_D = Double.Parse(TextBox1.Text)
            'V_L = Double.Parse(TextBox2.Text)
            'V_QE = Double.Parse(TextBox3.Text)
            'P_D = Double.Parse(TextBox4.Text)
            'P_L = Double.Parse(TextBox5.Text)
            'P_QE = Double.Parse(TextBox6.Text)
            'M_D = Double.Parse(TextBox7.Text)
            'M_L = Double.Parse(TextBox8.Text)
            'M_QE = Double.Parse(TextBox9.Text)

            If ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
            Else
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga"
            End If

            Me.Close()
        End If

    End Sub

    Private Sub Carriostre2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga"
        End If
    End Sub

    Private Sub Carriostre2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If abierto = True Then
            'TextBox1.Text = V_D.ToString
            'TextBox2.Text = V_L.ToString
            'TextBox3.Text = V_QE.ToString
            'TextBox4.Text = P_D.ToString
            'TextBox5.Text = P_L.ToString
            'TextBox6.Text = P_QE.ToString
            'TextBox7.Text = M_D.ToString
            'TextBox8.Text = M_L.ToString
            'TextBox9.Text = M_QE.ToString
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga"
        End If
        Me.Close()
    End Sub

   
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        soloNumeros(TextBox1, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        soloNumeros(TextBox2, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox3.Focus()
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        soloNumeros(TextBox3, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox4.Focus()
        End If
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        soloNumeros(TextBox4, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox5.Focus()
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        soloNumeros(TextBox5, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox6.Focus()
        End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        soloNumeros(TextBox6, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox7.Focus()
        End If
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        soloNumeros(TextBox7, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox8.Focus()
        End If
    End Sub
    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        soloNumeros(TextBox8, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox9.Focus()
        End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        soloNumeros(TextBox9, e)
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub
End Class