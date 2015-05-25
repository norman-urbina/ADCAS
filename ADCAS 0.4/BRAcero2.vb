Public Class BRAcero2

    Private Sub BRAcero_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
    End Sub

    Private Sub BRAcero2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        If ADCAS.TextBox305.Text.Contains("HSS") Then
            ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
            If ADCAS.TextBox305.Text.Contains(".") Then
                ListBox1.Items.AddRange(New Object() {"42", "46", "36"})
                ListBox2.Items.AddRange(New Object() {"58", "62", "58"})
                ListBox3.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                ListBox4.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
            Else
                ListBox1.Items.AddRange(New Object() {"46", "50", "36"})
                ListBox2.Items.AddRange(New Object() {"58", "62", "58"})
                ListBox3.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                ListBox4.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
            End If
        ElseIf ADCAS.TextBox305.Text.Contains("Pipe") Then
            ComboBox1.Items.AddRange(New Object() {"ASTM A53"})
            ListBox1.Items.AddRange(New Object() {"35"})
            ListBox2.Items.AddRange(New Object() {"60"})
            ListBox3.Items.AddRange(New Object() {"1.6"})
            ListBox4.Items.AddRange(New Object() {"1.2"})
        End If

        If Abierto Or OpenMode Then
            ComboBox1.Text = ADCAS.TextBox308.Text
            ComboBox2.Text = ADCAS.TextBox307.Text
            ComboBox3.Text = ADCAS.TextBox309.Text
        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        ListBox1.SelectedIndex = ComboBox1.SelectedIndex
        ListBox2.SelectedIndex = ComboBox1.SelectedIndex
        ListBox3.SelectedIndex = ComboBox1.SelectedIndex
        ListBox4.SelectedIndex = ComboBox1.SelectedIndex

        TextBox1.Text = ListBox1.Text
        TextBox2.Text = ListBox2.Text
        TextBox3.Text = ListBox3.Text
        TextBox4.Text = ListBox4.Text

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        ListBox5.SelectedIndex = ComboBox2.SelectedIndex
        ListBox6.SelectedIndex = ComboBox2.SelectedIndex
        ListBox7.SelectedIndex = ComboBox2.SelectedIndex
        ListBox8.SelectedIndex = ComboBox2.SelectedIndex

        TextBox5.Text = ListBox5.Text
        TextBox6.Text = ListBox6.Text
        TextBox7.Text = ListBox7.Text
        TextBox8.Text = ListBox8.Text

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        ListBox9.SelectedIndex = ComboBox3.SelectedIndex
        ListBox10.SelectedIndex = ComboBox3.SelectedIndex
        ListBox11.SelectedIndex = ComboBox3.SelectedIndex
        ListBox12.SelectedIndex = ComboBox3.SelectedIndex

        TextBox9.Text = ListBox9.Text
        TextBox10.Text = ListBox10.Text
        TextBox11.Text = ListBox11.Text
        TextBox12.Text = ListBox12.Text

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
       ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = String.Empty Or ComboBox2.Text = String.Empty Or ComboBox3.Text = String.Empty Then

            MsgBox("Por favor seleccione todos los tipos de acero.", MsgBoxStyle.Exclamation, "Advertencia")

        Else

            'datos

            Fybr = Val(TextBox1.Text)
            Fybr = Val(TextBox2.Text)
            Rybr = Val(TextBox3.Text)
            Rtbr = Val(TextBox4.Text)

            Fyp = Val(TextBox5.Text)
            Fup = Val(TextBox6.Text)
            Ryp = Val(TextBox7.Text)
            Rtp = Val(TextBox8.Text)

            Fyb2 = Val(TextBox9.Text)
            Fub2 = Val(TextBox10.Text)
            Ryb2 = Val(TextBox11.Text)
            Rtb2 = Val(TextBox12.Text)

            ADCAS.TextBox308.Text = ComboBox1.Text
            ADCAS.TextBox307.Text = ComboBox2.Text
            ADCAS.TextBox309.Text = ComboBox3.Text
            
            Abierto = True

            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"

            Me.Close()

        End If

    End Sub
    Public Abierto As Boolean
End Class