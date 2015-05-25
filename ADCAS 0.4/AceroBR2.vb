Public Class AceroBR2

    Private Sub AceroBR2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ADCAS.LabelDiseño.Text = "Conexión Viga/Columna Empernada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada"
        End If
    End Sub
    Private Sub AceroBR2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'SELECCIÓN DE LAS PROPIEDADES A MOSTRAR SEGÚN LA SECCIÓN DEL ARRIOSTRE

        ComboBox1.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        If ADCAS.TextBox201N.Text.Contains("HSS") Then
            ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
            If ADCAS.TextBox201N.Text.Contains(".") Then
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
        ElseIf ADCAS.TextBox201N.Text.Contains("Pipe") Then
            ComboBox1.Items.AddRange(New Object() {"ASTM A53"})
            ListBox1.Items.AddRange(New Object() {"35"})
            ListBox2.Items.AddRange(New Object() {"60"})
            ListBox3.Items.AddRange(New Object() {"1.6"})
            ListBox4.Items.AddRange(New Object() {"1.2"})
        End If

        ComboBox5.Items.Clear()
        ListBox17.Items.Clear()
        ListBox18.Items.Clear()
        ListBox19.Items.Clear()
        ListBox20.Items.Clear()

        If ADCAS.TextBox202N.Text.Contains("HSS") Then
            ComboBox5.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
            If ADCAS.TextBox202N.Text.Contains(".") Then
                'ComboBox5.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                ListBox20.Items.AddRange(New Object() {"42", "46", "36"})
                ListBox19.Items.AddRange(New Object() {"58", "62", "58"})
                ListBox18.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                ListBox17.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
            Else
                ListBox20.Items.AddRange(New Object() {"46", "50", "36"})
                ListBox19.Items.AddRange(New Object() {"58", "62", "58"})
                ListBox18.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                ListBox17.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
            End If
        ElseIf ADCAS.TextBox202N.Text.Contains("Pipe") Then
            ComboBox5.Items.AddRange(New Object() {"ASTM A53"})
            ListBox20.Items.AddRange(New Object() {"35"})
            ListBox19.Items.AddRange(New Object() {"60"})
            ListBox18.Items.AddRange(New Object() {"1.6"})
            ListBox17.Items.AddRange(New Object() {"1.2"})
        End If

        If abierto Or OpenMode Then
            ComboBox1.Text = ADCAS.TextBox205N.Text
            ComboBox5.Text = ADCAS.TextBox206N.Text
            ComboBox3.Text = ADCAS.TextBox207N.Text
            ComboBox4.Text = ADCAS.TextBox208N.Text
            ComboBox2.Text = ADCAS.TextBox214N.Text
        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or ComboBox5.Text = "" Then
            MsgBox("Por favor seleccione todos los tipos de acero.", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            'DATOS EN EL FORMULARIO PRINCIPAL
            If ADCAS.Button2.Enabled = False Then
            Else
                ADCAS.TextBox205N.Text = ComboBox1.Text
                ADCAS.TextBox206N.Text = ComboBox5.Text
                ADCAS.TextBox207N.Text = ComboBox3.Text
                ADCAS.TextBox208N.Text = ComboBox4.Text
                ADCAS.TextBox214N.Text = ComboBox2.Text
            End If

            abierto = True

            If ADCAS.LabelDiseño.Text = "Conexión Viga/Columna Empernada" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada"
            Else
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada"
            End If

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

    Public Shared abierto As Boolean

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        ListBox1.SelectedIndex = ComboBox1.SelectedIndex
        ListBox2.SelectedIndex = ComboBox1.SelectedIndex
        ListBox3.SelectedIndex = ComboBox1.SelectedIndex
        ListBox4.SelectedIndex = ComboBox1.SelectedIndex
        TextBox1.Text = ListBox1.Text
        TextBox2.Text = ListBox2.Text
        TextBox3.Text = ListBox3.Text
        TextBox4.Text = ListBox4.Text

        Fybr = Val(ListBox1.Text)
        Fubr = Val(ListBox2.Text)
        Rybr = Val(ListBox3.Text)
        Rtbr = Val(ListBox4.Text)

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

    Private Sub TextBox5_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Fyp = Double.Parse(TextBox5.Text)
    End Sub

    Private Sub TextBox6_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Fup = Double.Parse(TextBox6.Text)
    End Sub

    Private Sub TextBox7_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        Ryp = Double.Parse(TextBox7.Text)
    End Sub

    Private Sub TextBox8_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Rtp = Double.Parse(TextBox8.Text)
    End Sub

    Private Sub TextBox9_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        Fyb = Double.Parse(TextBox9.Text)
    End Sub

    Private Sub TextBox10_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        Fub = Double.Parse(TextBox10.Text)
    End Sub

    Private Sub TextBox11_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        Ryb = Double.Parse(TextBox11.Text)
    End Sub

    Private Sub TextBox12_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        Rtb = Double.Parse(TextBox12.Text)
    End Sub

    Private Sub TextBox13_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        Fyc = Double.Parse(TextBox13.Text)
    End Sub

    Private Sub TextBox14_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        Fuc = Double.Parse(TextBox14.Text)
    End Sub

    Private Sub TextBox15_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        Ryc = Double.Parse(TextBox15.Text)
    End Sub

    Private Sub TextBox16_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        Rtc = Double.Parse(TextBox16.Text)
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

        ListBox17.SelectedIndex = ComboBox5.SelectedIndex
        ListBox18.SelectedIndex = ComboBox5.SelectedIndex
        ListBox19.SelectedIndex = ComboBox5.SelectedIndex
        ListBox20.SelectedIndex = ComboBox5.SelectedIndex

        Rtbr2 = Val(ListBox17.Text)
        Rybr2 = Val(ListBox18.Text)
        Fubr2 = Val(ListBox19.Text)
        Fybr2 = Val(ListBox20.Text)

        TextBox20.Text = ListBox20.Text
        TextBox19.Text = ListBox19.Text
        TextBox18.Text = ListBox18.Text
        TextBox17.Text = ListBox17.Text

    End Sub
End Class