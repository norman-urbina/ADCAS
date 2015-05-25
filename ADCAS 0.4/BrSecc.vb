Public Class BrSecc

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'cambio en los listboxes
        ListBox1.SelectedIndex = ComboBox1.SelectedIndex
        ListBox2.SelectedIndex = ComboBox1.SelectedIndex
        ListBox3.SelectedIndex = ComboBox1.SelectedIndex
        ListBox4.SelectedIndex = ComboBox1.SelectedIndex
        ListBox5.SelectedIndex = ComboBox1.SelectedIndex
        ListBox20.SelectedIndex = ComboBox1.SelectedIndex
        ListBox21.SelectedIndex = ComboBox1.SelectedIndex
        ListBox28.SelectedIndex = ComboBox1.SelectedIndex
        ListBox27.SelectedIndex = ComboBox1.SelectedIndex
        'cambio en los textboxes
        TextBox1.Text = ListBox1.Text
        TextBox2.Text = ListBox2.Text
        TextBox3.Text = ListBox3.Text
        TextBox4.Text = ListBox4.Text
        TextBox5.Text = ListBox5.Text
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'cambio en los listboxes
        ListBox6.SelectedIndex = ComboBox2.SelectedIndex
        ListBox7.SelectedIndex = ComboBox2.SelectedIndex
        ListBox8.SelectedIndex = ComboBox2.SelectedIndex
        ListBox9.SelectedIndex = ComboBox2.SelectedIndex
        ListBox10.SelectedIndex = ComboBox2.SelectedIndex
        ListBox19.SelectedIndex = ComboBox2.SelectedIndex
        ListBox18.SelectedIndex = ComboBox2.SelectedIndex
        'cambio en los textboxes
        TextBox6.Text = ListBox6.Text
        TextBox7.Text = ListBox7.Text
        TextBox8.Text = ListBox8.Text
        TextBox9.Text = ListBox9.Text
        TextBox10.Text = ListBox10.Text
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        'cambio en los listboxes
        ListBox11.SelectedIndex = ComboBox3.SelectedIndex
        ListBox12.SelectedIndex = ComboBox3.SelectedIndex
        ListBox13.SelectedIndex = ComboBox3.SelectedIndex
        ListBox14.SelectedIndex = ComboBox3.SelectedIndex
        ListBox15.SelectedIndex = ComboBox3.SelectedIndex
        ListBox16.SelectedIndex = ComboBox3.SelectedIndex
        ListBox17.SelectedIndex = ComboBox3.SelectedIndex
        'cambio en los textboxes
        TextBox11.Text = ListBox11.Text
        TextBox12.Text = ListBox12.Text
        TextBox13.Text = ListBox13.Text
        TextBox14.Text = ListBox14.Text
        TextBox15.Text = ListBox15.Text
        TextBox16.Text = ListBox16.Text
        TextBox17.Text = ListBox17.Text

        'cambio de imagen

        If ComboBox3.Text.Contains("HSS") Then
            If ComboBox3.Text.Contains(".") Then
                PictureBox2.Image = My.Resources.SeccionPIPE2
                ADCAS.PictureBox242N.Image = My.Resources.LapMin
            Else
                PictureBox2.Image = My.Resources.SeccionHSS1
                ADCAS.PictureBox242N.Image = My.Resources.LAPmín2
            End If
        ElseIf ComboBox3.Text.Contains("Pipe") Then
            PictureBox2.Image = My.Resources.SeccionPIPE2
            ADCAS.PictureBox242N.Image = My.Resources.LapMin
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Empernada (Tope)" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada (Tope)"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada (Tope)"
        End If
        Me.Close()
    End Sub
    Public abierto As Boolean
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'advertencia
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
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
            dc = Val(TextBox6.Text)
            tcf = Val(TextBox7.Text)
            bcf = Val(TextBox8.Text)
            kcdes = Val(TextBox9.Text)
            tcw = Val(TextBox10.Text)
            Agbr2 = Val(TextBox11.Text)
            tbrnom2 = Val(TextBox12.Text)
            tbrdes2 = Val(TextBox13.Text)
            Bbr2 = Val(TextBox14.Text)
            rbr2 = Val(TextBox15.Text)
            If Val(TextBox16.Text) > Val(TextBox17.Text) Then
                Darr2 = Val(TextBox16.Text)
            Else
                Darr2 = Val(TextBox17.Text)
            End If

            Tb = Frac2Num(ListBox28.Text) - 2 * Frac2Num(ListBox27.Text)
            Tc = Frac2Num(ListBox19.Text) - 2 * Frac2Num(ListBox18.Text)

            If ADCAS.TextBox212.Text <> String.Empty Then
                If ComboBox3.Text.Contains("Pipe") And ADCAS.TextBox209.Text.Contains("HSS") Then
                    ADCAS.TextBox212.Text = "ASTM A53"
                    Fybr = 35
                    Fubr = 60
                    Rybr = 1.6
                    Rtbr = 1.2
                ElseIf ComboBox3.Text.Contains("HSS") And ComboBox3.Text.Contains(".") And (ADCAS.TextBox209.Text.Contains("/") Or ADCAS.TextBox209.Text.Contains("Pipe")) Then
                    ADCAS.TextBox212.Text = "ASTM A500 Gr. B"
                    Fybr = 42
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                ElseIf ComboBox3.Text.Contains("HSS") And ComboBox3.Text.Contains("/") And (ADCAS.TextBox209.Text.Contains(".") Or ADCAS.TextBox209.Text.Contains("Pipe")) Then
                    ADCAS.TextBox212.Text = "ASTM A500 Gr. B"
                    Fybr = 46
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                End If
            End If

            ADCAS.TextBox208.Text = ComboBox1.Text
            ADCAS.TextBox211.Text = ComboBox2.Text
            ADCAS.TextBox209.Text = ComboBox3.Text

            abierto = True

            If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Empernada (Tope)" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada (Tope)"
            Else
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada (Tope)"
            End If

            Me.Close()

        End If
    End Sub

    Private Sub BrSecc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Empernada (Tope)" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna empernada (Tope)"
        Else
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna soldada (Tope)"
        End If

    End Sub

    Private Sub BrSecc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If abierto = True Or OpenMode Then
            ComboBox1.Text = ADCAS.TextBox208.Text
            ComboBox2.Text = ADCAS.TextBox211.Text
            ComboBox3.Text = ADCAS.TextBox209.Text
        End If

        If OpenMode Then
            Button2_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub
End Class