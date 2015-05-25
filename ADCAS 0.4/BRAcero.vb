Public Class BRAcero

    Private Sub BRAcero_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
        End If
    End Sub

    Private Sub BRAcero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        If ADCAS.TextBox297.Text.Contains("HSS") Then
            ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
            If ADCAS.TextBox297.Text.Contains(".") Then
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
        ElseIf ADCAS.TextBox297.Text.Contains("Pipe") Then
            ComboBox1.Items.AddRange(New Object() {"ASTM A53"})
            ListBox1.Items.AddRange(New Object() {"35"})
            ListBox2.Items.AddRange(New Object() {"60"})
            ListBox3.Items.AddRange(New Object() {"1.6"})
            ListBox4.Items.AddRange(New Object() {"1.2"})
        End If

        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            GroupBox4.Text = "Viga superior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            GroupBox4.Text = "Viga superior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            GroupBox4.Text = "Viga inferior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            GroupBox4.Text = "Viga inferior"
        End If

        If Abierto Or OpenMode Then
            ComboBox1.Text = ADCAS.TextBox298.Text
            ComboBox2.Text = ADCAS.TextBox301.Text
            ComboBox3.Text = ADCAS.TextBox300.Text
            ComboBox4.Text = ADCAS.TextBox299.Text
            ComboBox5.Text = ADCAS.TextBox302.Text
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

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

        ListBox13.SelectedIndex = ComboBox4.SelectedIndex
        ListBox14.SelectedIndex = ComboBox4.SelectedIndex
        ListBox15.SelectedIndex = ComboBox4.SelectedIndex
        ListBox16.SelectedIndex = ComboBox4.SelectedIndex

        TextBox13.Text = ListBox16.Text
        TextBox14.Text = ListBox15.Text
        TextBox15.Text = ListBox14.Text
        TextBox16.Text = ListBox13.Text

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

        ListBox17.SelectedIndex = ComboBox5.SelectedIndex
        ListBox18.SelectedIndex = ComboBox5.SelectedIndex
        ListBox19.SelectedIndex = ComboBox5.SelectedIndex
        ListBox20.SelectedIndex = ComboBox5.SelectedIndex

        TextBox17.Text = ListBox20.Text
        TextBox18.Text = ListBox19.Text
        TextBox19.Text = ListBox18.Text
        TextBox20.Text = ListBox17.Text

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = String.Empty Or ComboBox2.Text = String.Empty Or ComboBox3.Text = String.Empty Or ComboBox4.Text = String.Empty Or ComboBox5.Text = String.Empty Then

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

            Fyb = Val(TextBox9.Text)
            Fub = Val(TextBox10.Text)
            Ryb = Val(TextBox11.Text)
            Rtb = Val(TextBox12.Text)

            Fyb2 = Val(TextBox13.Text)
            Fub2 = Val(TextBox14.Text)
            Ryb2 = Val(TextBox15.Text)
            Rtb2 = Val(TextBox16.Text)

            Fyc = Val(TextBox17.Text)
            Fuc = Val(TextBox18.Text)
            Ryc = Val(TextBox19.Text)
            Rtc = Val(TextBox20.Text)

            ADCAS.TextBox298.Text = ComboBox1.Text
            ADCAS.TextBox301.Text = ComboBox2.Text
            ADCAS.TextBox300.Text = ComboBox3.Text
            ADCAS.TextBox299.Text = ComboBox4.Text
            ADCAS.TextBox302.Text = ComboBox5.Text

            Abierto = True

            If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
            End If

            Me.Close()

        End If

    End Sub
    Public Abierto As Boolean
End Class