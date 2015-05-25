Public Class AceroBr

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

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        ListBox13.SelectedIndex = ComboBox4.SelectedIndex
        ListBox14.SelectedIndex = ComboBox4.SelectedIndex
        ListBox15.SelectedIndex = ComboBox4.SelectedIndex
        ListBox16.SelectedIndex = ComboBox4.SelectedIndex

        TextBox13.Text = ListBox13.Text
        TextBox14.Text = ListBox14.Text
        TextBox15.Text = ListBox15.Text
        TextBox16.Text = ListBox16.Text
    End Sub
    Public abierto As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Por favor seleccione todos los tipos de acero.", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            Fybr2 = Val(TextBox1.Text)
            Fubr2 = Val(TextBox2.Text)
            Rybr2 = Val(TextBox3.Text)
            Rtbr2 = Val(TextBox4.Text)
            Fyp = Val(TextBox5.Text)
            Fup = Val(TextBox6.Text)
            Ryp = Val(TextBox7.Text)
            Rtp = Val(TextBox8.Text)
            Fyb = Val(TextBox9.Text)
            Fub = Val(TextBox10.Text)
            Ryb = Val(TextBox11.Text)
            Rtb = Val(TextBox12.Text)
            Fyc = Val(TextBox13.Text)
            Fuc = Val(TextBox14.Text)
            Ryc = Val(TextBox15.Text)
            Ryc = Val(TextBox16.Text)

            ADCAS.TextBox212.Text = ComboBox1.Text
            ADCAS.TextBox210.Text = ComboBox2.Text
            ADCAS.TextBox215.Text = ComboBox3.Text
            ADCAS.TextBox214.Text = ComboBox4.Text

            If ADCAS.LabelDiseño.Text = "Conexión Viga/Columna Empernada" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada"
            Else
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada"
            End If

            abierto = True
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ADCAS.LabelDiseño.Text = "Conexión Viga/Columna Empernada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada"
        End If
        Me.Close()
    End Sub

    Private Sub AceroBr_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ADCAS.LabelDiseño.Text = "Conexión Viga/Columna Empernada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada"
        End If
    End Sub

    Private Sub AceroBr_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox1.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        If ADCAS.TextBox209.Text.Contains("HSS") Then
            ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
            If ADCAS.TextBox209.Text.Contains(".") Then
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

        ElseIf ADCAS.TextBox209.Text.Contains("Pipe") Then
            ComboBox1.Items.AddRange(New Object() {"ASTM A53"})
            ListBox1.Items.AddRange(New Object() {"35"})
            ListBox2.Items.AddRange(New Object() {"60"})
            ListBox3.Items.AddRange(New Object() {"1.6"})
            ListBox4.Items.AddRange(New Object() {"1.2"})
        End If

        If abierto = True Or OpenMode Then
            ComboBox1.Text = ADCAS.TextBox212.Text
            ComboBox2.Text = ADCAS.TextBox210.Text
            ComboBox3.Text = ADCAS.TextBox215.Text
            ComboBox4.Text = ADCAS.TextBox214.Text
        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub
End Class