Public Class BRsecc2

    Private Sub BRsecc2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ADCAS.LabelDiseño.Text = "Conexión Viga/Columna Empernada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada"
        End If
    End Sub

    Private Sub BRsecc2_Load(sender As Object, e As EventArgs) Handles Me.Load

        If abierto = True Or OpenMode Then
            ComboBox1.Text = ADCAS.TextBox203N.Text
            ComboBox2.Text = ADCAS.TextBox204N.Text
            ComboBox3.Text = ADCAS.TextBox201N.Text
            ComboBox4.Text = ADCAS.TextBox202N.Text
        End If

        If OpenMode Then
            Button2_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ADCAS.LabelDiseño.Text = "Conexión Viga/Columna Empernada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada"
        End If
        Me.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListBox1.SelectedIndex = ComboBox1.SelectedIndex
        ListBox2.SelectedIndex = ComboBox1.SelectedIndex
        ListBox3.SelectedIndex = ComboBox1.SelectedIndex
        ListBox4.SelectedIndex = ComboBox1.SelectedIndex
        ListBox23.SelectedIndex = ComboBox1.SelectedIndex
        ListBox25.SelectedIndex = ComboBox1.SelectedIndex
        ListBox26.SelectedIndex = ComboBox1.SelectedIndex

        TextBox1.Text = ListBox1.Text
        TextBox2.Text = ListBox2.Text
        TextBox3.Text = ListBox3.Text
        TextBox4.Text = ListBox4.Text
        TextBox23.Text = ListBox23.Text

        ListBox27.SelectedIndex = ComboBox1.SelectedIndex
        ListBox28.SelectedIndex = ComboBox1.SelectedIndex

    End Sub
    Public Shared abierto As Boolean

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'ALMACENAMIENTO DE LA COLUMNA SELECCIONADA
        'Columna = ComboBox2.Text
        ListBox5.SelectedIndex = ComboBox2.SelectedIndex
        ListBox6.SelectedIndex = ComboBox2.SelectedIndex
        ListBox7.SelectedIndex = ComboBox2.SelectedIndex
        ListBox8.SelectedIndex = ComboBox2.SelectedIndex
        ListBox24.SelectedIndex = ComboBox2.SelectedIndex
        ListBox30.SelectedIndex = ComboBox2.SelectedIndex
        ListBox29.SelectedIndex = ComboBox2.SelectedIndex

        TextBox5.Text = ListBox5.Text
        TextBox6.Text = ListBox6.Text
        TextBox7.Text = ListBox7.Text
        TextBox8.Text = ListBox8.Text
        TextBox24.Text = ListBox24.Text
    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        'Arriostre = ComboBox3.Text
        ListBox9.SelectedIndex = ComboBox3.SelectedIndex
        ListBox10.SelectedIndex = ComboBox3.SelectedIndex
        ListBox11.SelectedIndex = ComboBox3.SelectedIndex
        ListBox12.SelectedIndex = ComboBox3.SelectedIndex
        ListBox13.SelectedIndex = ComboBox3.SelectedIndex
        ListBox14.SelectedIndex = ComboBox3.SelectedIndex
        ListBox21.SelectedIndex = ComboBox3.SelectedIndex

        TextBox9.Text = ListBox9.Text
        TextBox10.Text = ListBox10.Text
        TextBox11.Text = ListBox11.Text
        TextBox12.Text = ListBox12.Text
        TextBox13.Text = ListBox13.Text
        TextBox14.Text = ListBox14.Text
        TextBox21.Text = ListBox21.Text

        'CAMBIO DE LA IMAGEN DE ARRIOSTRE

        If ComboBox4.Text.Contains("HSS") Then
            If ComboBox4.Text.Contains(".") Then
                PictureBox2.Image = My.Resources.SeccionPIPE2
                ADCAS.PictureBox242N.Image = My.Resources.LapMin
            Else
                PictureBox2.Image = My.Resources.SeccionHSS1
                ADCAS.PictureBox242N.Image = My.Resources.LAPmín2
            End If
        ElseIf ComboBox4.Text.Contains("Pipe") Then
            PictureBox2.Image = My.Resources.SeccionPIPE2
            ADCAS.PictureBox242N.Image = My.Resources.LapMin
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'DATOS EN EL FORMULARIO PRINCIPAL
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Por favor, seleccione todos los perfiles.", MsgBoxStyle.Exclamation, "Advertencia")
        Else

            'CAMBIO EN EL TIPO DE ACERO
            If ADCAS.TextBox205N.Text <> String.Empty Then

                If ComboBox3.Text.Contains("Pipe") And ADCAS.TextBox201N.Text.Contains("HSS") Then
                    ADCAS.TextBox205N.Text = "ASTM A53"
                    Fybr = 35
                    Fubr = 60
                    Rybr = 1.6
                    Rtbr = 1.2
                ElseIf ComboBox3.Text.Contains("HSS") And ComboBox3.Text.Contains(".") And (ADCAS.TextBox201N.Text.Contains("/") Or ADCAS.TextBox201N.Text.Contains("Pipe")) Then
                    ADCAS.TextBox205N.Text = "ASTM A500 Gr. B"
                    Fybr = 42
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                ElseIf ComboBox3.Text.Contains("HSS") And ComboBox3.Text.Contains("/") And (ADCAS.TextBox201N.Text.Contains("Pipe") Or (ADCAS.TextBox201N.Text.Contains("."))) Then
                    ADCAS.TextBox205N.Text = "ASTM A500 Gr. B"
                    Fybr = 46
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                End If

            End If

            If ADCAS.TextBox206N.Text <> String.Empty Then

                If ComboBox4.Text.Contains("Pipe") And ADCAS.TextBox202N.Text.Contains("HSS") Then
                    ADCAS.TextBox206N.Text = "ASTM A53"
                    Fybr = 35
                    Fubr = 60
                    Rybr = 1.6
                    Rtbr = 1.2
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains(".") And (ADCAS.TextBox202N.Text.Contains("/") Or ADCAS.TextBox202N.Text.Contains("Pipe")) Then
                    ADCAS.TextBox206N.Text = "ASTM A500 Gr. B"
                    Fybr = 42
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains("/") And (ADCAS.TextBox202N.Text.Contains("Pipe") Or (ADCAS.TextBox202N.Text.Contains("."))) Then
                    ADCAS.TextBox206N.Text = "ASTM A500 Gr. B"
                    Fybr = 46
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                End If

            End If

            abierto = True

            rb = Val(ListBox25.Text)
            Ab = Val(ListBox26.Text)
            bbf = Val(ListBox23.Text)

            db = Val(ListBox1.Text)
            tbf = Val(ListBox2.Text)
            bbf = Val(ListBox23.Text)
            kbdes = Val(ListBox3.Text)
            tbw = Val(ListBox4.Text)

            dc = Val(ListBox5.Text)
            tcf = Val(ListBox6.Text)
            bcf = Val(ListBox24.Text)
            kcdes = Val(ListBox7.Text)
            tcw = Val(ListBox8.Text)

            Agbr = Val(ListBox9.Text)
            tbrnom = Val(ListBox10.Text)
            tbrdes = Val(ListBox11.Text)
            Bbr = Val(ListBox21.Text)
            rbr = Val(ListBox12.Text)
            Hbr = Val(ListBox12.Text)
            If ListBox14.Text = "–" Then
                Darr = Val(ListBox13.Text)
            Else
                Darr = Val(ListBox14.Text)
            End If

            Agbr2 = Val(ListBox20.Text)
            tbrnom2 = Val(ListBox19.Text)
            tbrdes2 = Val(ListBox18.Text)
            rbr2 = Val(ListBox17.Text)
            Hbr2 = Val(ListBox16.Text)
            If ListBox16.Text = "–" Then
                Darr2 = Val(ListBox15.Text)
            Else
                Darr2 = Val(ListBox16.Text)
            End If
            Bbr2 = Val(ListBox22.Text)

            Tb = Frac2Num(ListBox28.Text) - 2 * Frac2Num(ListBox27.Text)
            Tc = Frac2Num(ListBox30.Text) - 2 * Frac2Num(ListBox29.Text)

            ADCAS.TextBox201N.Text = ComboBox3.Text
            ADCAS.TextBox202N.Text = ComboBox4.Text
            ADCAS.TextBox203N.Text = ComboBox1.Text
            ADCAS.TextBox204N.Text = ComboBox2.Text

            If ADCAS.LabelDiseño.Text = "Conexión Viga/Columna Empernada" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada"
            Else
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada"
            End If

            Me.Close()
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

        'Arriostre2 = ComboBox4.Texts

        ListBox15.SelectedIndex = ComboBox4.SelectedIndex
        ListBox16.SelectedIndex = ComboBox4.SelectedIndex
        ListBox17.SelectedIndex = ComboBox4.SelectedIndex
        ListBox18.SelectedIndex = ComboBox4.SelectedIndex
        ListBox19.SelectedIndex = ComboBox4.SelectedIndex
        ListBox20.SelectedIndex = ComboBox4.SelectedIndex
        ListBox22.SelectedIndex = ComboBox4.SelectedIndex

        TextBox15.Text = ListBox15.Text
        TextBox16.Text = ListBox16.Text
        TextBox17.Text = ListBox17.Text
        TextBox18.Text = ListBox18.Text
        TextBox19.Text = ListBox19.Text
        TextBox20.Text = ListBox20.Text
        TextBox22.Text = ListBox22.Text

        'CAMBIO DE LA IMAGEN DE ARRIOSTRE
        If ComboBox4.Text.Contains("HSS") Then
            If ComboBox4.Text.Contains(".") Then
                PictureBox2.Image = My.Resources.SeccionPIPE2
            Else
                PictureBox2.Image = My.Resources.SeccionHSS1
            End If
        ElseIf ComboBox4.Text.Contains("Pipe") Then
            PictureBox2.Image = My.Resources.SeccionPIPE2
        End If

    End Sub

End Class