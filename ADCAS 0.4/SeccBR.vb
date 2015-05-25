Public Class SeccBR

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListBox1.SelectedIndex = ComboBox1.SelectedIndex
        ListBox2.SelectedIndex = ComboBox1.SelectedIndex
        ListBox3.SelectedIndex = ComboBox1.SelectedIndex
        ListBox4.SelectedIndex = ComboBox1.SelectedIndex
        ListBox5.SelectedIndex = ComboBox1.SelectedIndex
        ListBox20.SelectedIndex = ComboBox1.SelectedIndex
        ListBox21.SelectedIndex = ComboBox1.SelectedIndex
        ListBox28.SelectedIndex = ComboBox1.SelectedIndex
        ListBox27.SelectedIndex = ComboBox1.SelectedIndex
        ListBox35.SelectedIndex = ComboBox1.SelectedIndex

        TextBox1.Text = ListBox1.Text
        TextBox2.Text = ListBox2.Text
        TextBox3.Text = ListBox3.Text
        TextBox4.Text = ListBox4.Text
        TextBox5.Text = ListBox5.Text

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ListBox14.SelectedIndex = ComboBox2.SelectedIndex
        ListBox12.SelectedIndex = ComboBox2.SelectedIndex
        ListBox10.SelectedIndex = ComboBox2.SelectedIndex
        ListBox13.SelectedIndex = ComboBox2.SelectedIndex
        ListBox11.SelectedIndex = ComboBox2.SelectedIndex
        ListBox9.SelectedIndex = ComboBox2.SelectedIndex
        ListBox8.SelectedIndex = ComboBox2.SelectedIndex
        ListBox7.SelectedIndex = ComboBox2.SelectedIndex
        ListBox6.SelectedIndex = ComboBox2.SelectedIndex
        ListBox36.SelectedIndex = ComboBox2.SelectedIndex

        TextBox10.Text = ListBox14.Text
        TextBox9.Text = ListBox12.Text
        TextBox6.Text = ListBox10.Text
        TextBox7.Text = ListBox13.Text
        TextBox8.Text = ListBox11.Text

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ListBox25.SelectedIndex = ComboBox3.SelectedIndex
        ListBox23.SelectedIndex = ComboBox3.SelectedIndex
        ListBox19.SelectedIndex = ComboBox3.SelectedIndex
        ListBox24.SelectedIndex = ComboBox3.SelectedIndex
        ListBox22.SelectedIndex = ComboBox3.SelectedIndex
        ListBox18.SelectedIndex = ComboBox3.SelectedIndex
        ListBox17.SelectedIndex = ComboBox3.SelectedIndex
        ListBox16.SelectedIndex = ComboBox3.SelectedIndex
        ListBox15.SelectedIndex = ComboBox3.SelectedIndex

        TextBox15.Text = ListBox25.Text
        TextBox14.Text = ListBox23.Text
        TextBox11.Text = ListBox19.Text
        TextBox12.Text = ListBox24.Text
        TextBox13.Text = ListBox22.Text

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        ListBox33.SelectedIndex = ComboBox4.SelectedIndex
        ListBox34.SelectedIndex = ComboBox4.SelectedIndex
        ListBox30.SelectedIndex = ComboBox4.SelectedIndex
        ListBox26.SelectedIndex = ComboBox4.SelectedIndex
        ListBox32.SelectedIndex = ComboBox4.SelectedIndex
        ListBox31.SelectedIndex = ComboBox4.SelectedIndex
        ListBox29.SelectedIndex = ComboBox4.SelectedIndex

        TextBox22.Text = ListBox34.Text
        TextBox21.Text = ListBox33.Text
        TextBox20.Text = ListBox30.Text
        TextBox16.Text = ListBox26.Text
        TextBox19.Text = ListBox32.Text
        TextBox18.Text = ListBox31.Text
        TextBox17.Text = ListBox29.Text

        'cambio de la imagen

        If ComboBox4.Text.Contains("/") Then
            PictureBox2.Image = My.Resources.SeccionHSS1
        Else
            PictureBox2.Image = My.Resources.SeccionPIPE2
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ComboBox1.Text = ADCAS.TextBox295.Text
        ComboBox2.Text = ADCAS.TextBox294.Text
        ComboBox3.Text = ADCAS.TextBox296.Text
        ComboBox4.Text = ADCAS.TextBox297.Text

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'advertencia
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Por favor, seleccione todos los perfiles.", MsgBoxStyle.Exclamation, "Advertencia")
        Else

            'datos
            db = Val(TextBox1.Text)
            tbf = Val(TextBox2.Text)
            bbf = Val(TextBox3.Text)
            kbdes = Val(TextBox4.Text)
            tbw = Val(TextBox5.Text)
            rb = Val(ListBox20.Text)
            Ab = Val(ListBox21.Text)
            Tb = Frac2Num(ListBox28.Text) - 2 * Frac2Num(ListBox27.Text)

            db2 = Val(TextBox10.Text)
            tbf2 = Val(TextBox9.Text)
            bbf2 = Val(TextBox6.Text)
            kbdes2 = Val(TextBox7.Text)
            tbw2 = Val(TextBox8.Text)
            rb2 = Val(ListBox9.Text)
            Ab2 = Val(ListBox8.Text)
            Tb2 = Frac2Num(ListBox7.Text) - 2 * Frac2Num(ListBox6.Text)

            dc = Val(TextBox15.Text)
            tcf = Val(TextBox14.Text)
            bcf = Val(TextBox11.Text)
            kcdes = Val(TextBox12.Text)
            tcw = Val(TextBox13.Text)

            Agbr = Val(TextBox22.Text)
            tbrnom = Val(TextBox21.Text)
            tbrdes = Val(TextBox20.Text)
            Bbr = Val(TextBox16.Text)
            rbr = Val(TextBox19.Text)
            If Val(TextBox18.Text) < Val(TextBox17.Text) Then
                Darr = Val(TextBox17.Text)
            Else
                Darr = Val(TextBox18.Text)
            End If
            Z = Val(ListBox35.Text)
            Z2 = Val(ListBox36.Text)

            'Cambio en el tipo de acero
            If ADCAS.TextBox297.Text <> String.Empty Then
                If ComboBox4.Text.Contains("Pipe") And ADCAS.TextBox297.Text.Contains("HSS") Then
                    ADCAS.TextBox298.Text = "ASTM A53"
                    Fybr = 35
                    Fubr = 60
                    Rybr = 1.6
                    Rtbr = 1.2
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains(".") And (ADCAS.TextBox297.Text.Contains("/") Or ADCAS.TextBox297.Text.Contains("Pipe")) Then
                    ADCAS.TextBox298.Text = "ASTM A500 Gr. B"
                    Fybr = 42
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains("/") And (ADCAS.TextBox297.Text.Contains("Pipe") Or (ADCAS.TextBox297.Text.Contains("."))) Then
                    ADCAS.TextBox298.Text = "ASTM A500 Gr. B"
                    Fybr = 46
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                End If
            End If

            ADCAS.TextBox295.Text = ComboBox1.Text
            ADCAS.TextBox294.Text = ComboBox2.Text
            ADCAS.TextBox296.Text = ComboBox3.Text
            ADCAS.TextBox297.Text = ComboBox4.Text

            If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
            End If

            Abierto = True
            Me.Close()

        End If

    End Sub
    Public Shared Abierto As Boolean

    Private Sub SeccBR_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub SeccBR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            GroupBox2.Text = "Viga superior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            GroupBox2.Text = "Viga superior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            GroupBox2.Text = "Viga inferior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            GroupBox2.Text = "Viga inferior"
        End If

        If OpenMode Or Abierto Then
            ComboBox1.Text = ADCAS.TextBox295.Text
            ComboBox2.Text = ADCAS.TextBox294.Text
            ComboBox3.Text = ADCAS.TextBox296.Text
            ComboBox4.Text = ADCAS.TextBox297.Text
        End If

        If OpenMode Then
            Button2_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub
End Class