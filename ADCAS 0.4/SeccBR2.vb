Public Class SeccBR2

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
        ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'advertencia
        If ComboBox1.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Por favor, seleccione todos los perfiles.", MsgBoxStyle.Exclamation, "Advertencia")
        Else

            'datos

            db2 = Val(TextBox1.Text)
            tbf2 = Val(TextBox2.Text)
            bbf2 = Val(TextBox3.Text)
            kbdes2 = Val(TextBox4.Text)
            tbw2 = Val(TextBox5.Text)
            rb2 = Val(ListBox20.Text)
            Ab2 = Val(ListBox21.Text)
            Tb2 = Frac2Num(ListBox28.Text) - 2 * Frac2Num(ListBox27.Text)

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

            Z2 = Val(ListBox35.Text)

            'Cambio en el tipo de acero
            If ADCAS.TextBox308.Text <> String.Empty Then
                If ComboBox4.Text.Contains("Pipe") And ADCAS.TextBox305.Text.Contains("HSS") Then
                    ADCAS.TextBox308.Text = "ASTM A53"
                    Fybr = 35
                    Fubr = 60
                    Rybr = 1.6
                    Rtbr = 1.2
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains(".") And (ADCAS.TextBox305.Text.Contains("/") Or ADCAS.TextBox305.Text.Contains("Pipe")) Then
                    ADCAS.TextBox308.Text = "ASTM A500 Gr. B"
                    Fybr = 42
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains("/") And (ADCAS.TextBox305.Text.Contains("Pipe") Or (ADCAS.TextBox305.Text.Contains("."))) Then
                    ADCAS.TextBox308.Text = "ASTM A500 Gr. B"
                    Fybr = 46
                    Fubr = 58
                    Rybr = 1.4
                    Rtbr = 1.3
                End If
            End If

            ADCAS.TextBox306.Text = ComboBox1.Text
            ADCAS.TextBox305.Text = ComboBox4.Text

            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"

            Abierto = True
            Me.Close()

        End If

    End Sub

    Public Shared Abierto As Boolean

    Private Sub SeccBR2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
    End Sub

    Private Sub SeccBR2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Abierto Or OpenMode Then
            ComboBox1.Text = ADCAS.TextBox306.Text
            ComboBox4.Text = ADCAS.TextBox305.Text
        End If

        If OpenMode Then
            Button2_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub
End Class