Public Class BrSecc3
    Public abierto As Boolean

    Private Sub BrSecc3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en X"
    End Sub
    Private Sub BrSecc3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If abierto = True Or OpenMode Then
            ComboBox1.Text = ADCAS.TextBox203N.Text
            ComboBox2.Text = ADCAS.TextBox201N.Text
            ComboBox3.Text = ADCAS.TextBox202N.Text
        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If
    End Sub

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

        ListBox6.SelectedIndex = ComboBox2.SelectedIndex
        ListBox7.SelectedIndex = ComboBox2.SelectedIndex
        ListBox8.SelectedIndex = ComboBox2.SelectedIndex
        ListBox9.SelectedIndex = ComboBox2.SelectedIndex
        ListBox10.SelectedIndex = ComboBox2.SelectedIndex
        ListBox11.SelectedIndex = ComboBox2.SelectedIndex
        ListBox12.SelectedIndex = ComboBox2.SelectedIndex

        TextBox6.Text = ListBox6.Text
        TextBox7.Text = ListBox7.Text
        TextBox8.Text = ListBox8.Text
        TextBox9.Text = ListBox9.Text
        TextBox10.Text = ListBox10.Text
        TextBox11.Text = ListBox11.Text
        TextBox12.Text = ListBox12.Text
        TextBox13.Text = ListBox13.Text

        If ComboBox2.Text.Contains("/") And ComboBox2.Text.Contains("HSS") Then
            PictureBox2.Image = My.Resources.SeccionHSS1
            ADCAS.PictureBox280.Image = My.Resources.LAPmín2
        Else
            PictureBox2.Image = My.Resources.SeccionPIPE2
            ADCAS.PictureBox280.Image = My.Resources.LapMin
        End If

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        ListBox13.SelectedIndex = ComboBox3.SelectedIndex
        ListBox14.SelectedIndex = ComboBox3.SelectedIndex
        ListBox15.SelectedIndex = ComboBox3.SelectedIndex
        ListBox16.SelectedIndex = ComboBox3.SelectedIndex
        ListBox17.SelectedIndex = ComboBox3.SelectedIndex
        ListBox18.SelectedIndex = ComboBox3.SelectedIndex
        ListBox19.SelectedIndex = ComboBox3.SelectedIndex

        TextBox13.Text = ListBox13.Text
        TextBox14.Text = ListBox14.Text
        TextBox15.Text = ListBox15.Text
        TextBox16.Text = ListBox16.Text
        TextBox17.Text = ListBox17.Text
        TextBox18.Text = ListBox18.Text
        TextBox19.Text = ListBox19.Text

        'cambio de imagen

        If ComboBox3.Text.Contains("HSS") Then
            If ComboBox3.Text.Contains(".") Then
                PictureBox2.Image = My.Resources.SeccionPIPE2
                ADCAS.PictureBox280.Image = My.Resources.LapMin
            Else
                PictureBox2.Image = My.Resources.SeccionHSS1
                ADCAS.PictureBox280.Image = My.Resources.LAPmín2
            End If
        ElseIf ComboBox3.Text.Contains("Pipe") Then
            PictureBox2.Image = My.Resources.SeccionPIPE2
            ADCAS.PictureBox280.Image = My.Resources.LapMin
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Por favor, seleccione todos los perfiles.", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            'datos

            db = Val(ListBox1.Text)
            tbf = Val(ListBox2.Text)
            bbf = Val(ListBox3.Text)
            kbdes = Val(ListBox4.Text)
            tbw = Val(ListBox5.Text)
            rb = Val(ListBox20.Text)
            Ab = Val(ListBox21.Text)

            Agbr = Val(ListBox6.Text)
            tbrnom = Val(ListBox7.Text)
            tbrdes = Val(ListBox8.Text)
            Bbr = Val(ListBox9.Text)
            rbr = Val(ListBox10.Text)
            If ListBox12.Text = "–" Then
                Darr = Val(ListBox11.Text)
            Else
                Darr = Val(ListBox12.Text)
            End If

            Agbr2 = Val(ListBox13.Text)
            tbrnom2 = Val(ListBox14.Text)
            tbrdes2 = Val(ListBox15.Text)
            Bbr2 = Val(ListBox16.Text)
            rbr2 = Val(ListBox17.Text)
            If ListBox19.Text = "–" Then
                Darr2 = Val(ListBox18.Text)
            Else
                Darr2 = Val(ListBox19.Text)
            End If

            Tb = Frac2Num(ListBox28.Text) - 2 * Frac2Num(ListBox27.Text)

            If ADCAS.TextBox205N.Text <> String.Empty Then

                If ComboBox2.Text.Contains("Pipe") And ADCAS.TextBox201N.Text.Contains("HSS") Then
                    ADCAS.TextBox205N.Text = "ASTM A53"
                    Fybr = 35
                    Fubr = 60
                    Rybr = 1.6
                    Rtbr = 1.2
                ElseIf ComboBox2.Text.Contains("HSS") And ComboBox2.Text.Contains(".") And (ADCAS.TextBox201N.Text.Contains("/") Or ADCAS.TextBox201N.Text.Contains("Pipe")) Then
                    ADCAS.TextBox205N.Text = "ASTM A500 Gr. B"
                    Fybr = 42
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                ElseIf ComboBox2.Text.Contains("HSS") And ComboBox2.Text.Contains("/") And (ADCAS.TextBox201N.Text.Contains("Pipe") Or (ADCAS.TextBox201N.Text.Contains("."))) Then
                    ADCAS.TextBox205N.Text = "ASTM A500 Gr. B"
                    Fybr = 46
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                End If

            End If

            If ADCAS.TextBox206N.Text <> String.Empty Then

                If ComboBox3.Text.Contains("Pipe") And ADCAS.TextBox202N.Text.Contains("HSS") Then
                    ADCAS.TextBox206N.Text = "ASTM A53"
                    Fybr = 35
                    Fubr = 60
                    Rybr = 1.6
                    Rtbr = 1.2
                ElseIf ComboBox3.Text.Contains("HSS") And ComboBox3.Text.Contains(".") And (ADCAS.TextBox202N.Text.Contains("/") Or ADCAS.TextBox202N.Text.Contains("Pipe")) Then
                    ADCAS.TextBox206N.Text = "ASTM A500 Gr. B"
                    Fybr = 42
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                ElseIf ComboBox3.Text.Contains("HSS") And ComboBox3.Text.Contains("/") And (ADCAS.TextBox202N.Text.Contains("Pipe") Or (ADCAS.TextBox202N.Text.Contains("."))) Then
                    ADCAS.TextBox206N.Text = "ASTM A500 Gr. B"
                    Fybr = 46
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                End If

            End If

            ADCAS.TextBox203N.Text = ComboBox1.Text
            ADCAS.TextBox201N.Text = ComboBox2.Text
            ADCAS.TextBox202N.Text = ComboBox3.Text

            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en X"

            abierto = True

            Me.Close()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en X"
        Me.Close()
    End Sub

    
    Private Sub ListBox28_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox28.SelectedIndexChanged

    End Sub
End Class