Public Class Perfiles2

    Public Abierto As Boolean

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        dbl.SelectedIndex = ComboBox1.SelectedIndex
        tbfl.SelectedIndex = ComboBox1.SelectedIndex
        tbwl.SelectedIndex = ComboBox1.SelectedIndex
        kb1l.SelectedIndex = ComboBox1.SelectedIndex
        kbl.SelectedIndex = ComboBox1.SelectedIndex
        bbfl.SelectedIndex = ComboBox1.SelectedIndex
        rbxl.SelectedIndex = ComboBox1.SelectedIndex
        Tbl.SelectedIndex = ComboBox1.SelectedIndex
        Abl.SelectedIndex = ComboBox1.SelectedIndex
        Zbxl.SelectedIndex = ComboBox1.SelectedIndex

        Label2.Text = dbl.Text + " in"
        Label3.Text = tbfl.Text + " in"
        Label4.Text = tbwl.Text + " in"
        Label5.Text = kb1l.Text + " in"
        Label6.Text = kbl.Text + " in"
        Label7.Text = bbfl.Text + " in"
        Label8.Text = rbxl.Text + " in"
        Label9.Text = Tbl.Text + " in"
        Label10.Text = Abl.Text + " in²"
        Label11.Text = Zbxl.Text + " in³"

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

        Agbrl.SelectedIndex = ComboBox4.SelectedIndex
        tbrnoml.SelectedIndex = ComboBox4.SelectedIndex
        tbrdesl.SelectedIndex = ComboBox4.SelectedIndex
        Bbrl.SelectedIndex = ComboBox4.SelectedIndex
        ODbrl.SelectedIndex = ComboBox4.SelectedIndex
        Htbrl.SelectedIndex = ComboBox4.SelectedIndex
        rxbrl.SelectedIndex = ComboBox4.SelectedIndex
        Ixbrl.SelectedIndex = ComboBox4.SelectedIndex
        Zxbrl.SelectedIndex = ComboBox4.SelectedIndex

        Label35.Text = Agbrl.Text + " in²"
        Label36.Text = tbrnoml.Text + " in"
        Label37.Text = tbrdesl.Text + " in"
        Label38.Text = Bbrl.Text + " in"
        Label39.Text = ODbrl.Text + " in"
        Label40.Text = Htbrl.Text + " in"
        Label41.Text = rxbrl.Text + " in"
        Label42.Text = Ixbrl.Text + " in4"
        Label43.Text = Zxbrl.Text + " in³"

        If ComboBox4.Text.Contains("/") And ComboBox4.Text.Contains("HSS") Then
            PictureBox2.Image = My.Resources.SeccionHSS1
            ADCAS.PictureBox344.Image = My.Resources.LAPmín2
        Else
            PictureBox2.Image = My.Resources.SeccionPIPE2
            ADCAS.PictureBox344.Image = My.Resources.LapMin
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Por favor, seleccione todos los perfiles.", MsgBoxStyle.Exclamation, "Advertencia")
        Else

            'Cambio en el tipo de acero

            If Abierto = False Or OpenMode Then

                Steel2.ComboBox1.Items.Clear()
                Steel2.fybrl.Items.Clear()
                Steel2.fubrl.Items.Clear()
                Steel2.rybrl.Items.Clear()
                Steel2.rtbrl.Items.Clear()

                If ComboBox4.Text.Contains("Pipe") Then
                    Steel2.ComboBox1.Items.AddRange(New Object() {"ASTM A53"})
                    Steel2.fybrl.Items.AddRange(New Object() {"35"})
                    Steel2.fubrl.Items.AddRange(New Object() {"60"})
                    Steel2.rybrl.Items.AddRange(New Object() {"1.6"})
                    Steel2.rtbrl.Items.AddRange(New Object() {"1.2"})
                ElseIf ComboBox4.Text.Contains("/") And ComboBox4.Text.Contains("HSS") Then
                    Steel2.ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                    Steel2.fybrl.Items.AddRange(New Object() {"46", "50", "36"})
                    Steel2.fubrl.Items.AddRange(New Object() {"58", "62", "58"})
                    Steel2.rybrl.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                    Steel2.rtbrl.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
                ElseIf ComboBox4.Text.Contains(".") Then
                    Steel2.ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                    Steel2.fybrl.Items.AddRange(New Object() {"42", "46", "36"})
                    Steel2.fubrl.Items.AddRange(New Object() {"58", "62", "58"})
                    Steel2.rybrl.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                    Steel2.rtbrl.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
                End If
            End If

            If ADCAS.TextBox308.Text <> String.Empty And ADCAS.TextBox308.Text <> ComboBox4.Text And OpenMode = False Then

                If ComboBox4.Text.Contains("Pipe") And ADCAS.TextBox305.Text.Contains("HSS") Then
                    Steel2.ComboBox1.Items.Clear()
                    Steel2.fybrl.Items.Clear()
                    Steel2.fubrl.Items.Clear()
                    Steel2.rybrl.Items.Clear()
                    Steel2.rtbrl.Items.Clear()
                    ADCAS.TextBox308.Text = "ASTM A53"
                    Steel2.ComboBox1.Items.AddRange(New Object() {"ASTM A53"})
                    Steel2.fybrl.Items.AddRange(New Object() {"35"})
                    Steel2.fubrl.Items.AddRange(New Object() {"60"})
                    Steel2.rybrl.Items.AddRange(New Object() {"1.6"})
                    Steel2.rtbrl.Items.AddRange(New Object() {"1.2"})
                    Steel2.ComboBox1.SelectedIndex = 0
                    Steel2.fybrl.SelectedIndex = 0
                    Steel2.fubrl.SelectedIndex = 0
                    Steel2.rybrl.SelectedIndex = 0
                    Steel2.rtbrl.SelectedIndex = 0
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains(".") And (ADCAS.TextBox305.Text.Contains("/") Or ADCAS.TextBox305.Text.Contains("Pipe")) Then
                    Steel2.ComboBox1.Items.Clear()
                    Steel2.fybrl.Items.Clear()
                    Steel2.fubrl.Items.Clear()
                    Steel2.rybrl.Items.Clear()
                    Steel2.rtbrl.Items.Clear()
                    ADCAS.TextBox308.Text = "ASTM A500 Gr. B"
                    Steel2.ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                    Steel2.fybrl.Items.AddRange(New Object() {"42", "46", "36"})
                    Steel2.fubrl.Items.AddRange(New Object() {"58", "62", "58"})
                    Steel2.rybrl.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                    Steel2.rtbrl.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
                    Steel2.ComboBox1.SelectedIndex = 0
                    Steel2.fybrl.SelectedIndex = 0
                    Steel2.fubrl.SelectedIndex = 0
                    Steel2.rybrl.SelectedIndex = 0
                    Steel2.rtbrl.SelectedIndex = 0
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains("/") And (ADCAS.TextBox305.Text.Contains("Pipe") Or (ADCAS.TextBox305.Text.Contains("."))) Then
                    Steel2.ComboBox1.Items.Clear()
                    Steel2.fybrl.Items.Clear()
                    Steel2.fubrl.Items.Clear()
                    Steel2.rybrl.Items.Clear()
                    Steel2.rtbrl.Items.Clear()
                    ADCAS.TextBox308.Text = "ASTM A500 Gr. B"
                    Steel2.ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                    Steel2.fybrl.Items.AddRange(New Object() {"46", "50", "36"})
                    Steel2.fubrl.Items.AddRange(New Object() {"58", "62", "58"})
                    Steel2.rybrl.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                    Steel2.rtbrl.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
                    Steel2.ComboBox1.SelectedIndex = 0
                    Steel2.fybrl.SelectedIndex = 0
                    Steel2.fubrl.SelectedIndex = 0
                    Steel2.rybrl.SelectedIndex = 0
                    Steel2.rtbrl.SelectedIndex = 0
                End If
            End If

            db = Val(dbl.Text)
            tbf = Val(tbfl.Text)
            tbw = Val(tbwl.Text)
            kbdes = Val(kbl.Text)
            kb1 = Frac2Num(kb1l.Text)
            bbf = Val(bbfl.Text)
            rb = Val(rbxl.Text)
            Tb = Frac2Num(Tbl.Text)
            Ab = Val(Abl.Text)
            Z = Val(Zbxl.Text)

            Agbr = Val(Agbrl.Text)
            tbrnom = Val(tbrnoml.Text)
            tbrdes = Val(tbrdesl.Text)
            Bbr = Val(Bbrl.Text)
            Darr = Math.Max(Val(ODbrl.Text), Val(Htbrl.Text))
            rbr = Val(rxbrl.Text)

            ADCAS.TextBox306.Text = ComboBox1.Text
            ADCAS.TextBox305.Text = ComboBox4.Text

            Abierto = True

            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"

            Me.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = ADCAS.TextBox306.Text
        ComboBox4.Text = ADCAS.TextBox305.Text
        ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        Me.Close()
    End Sub

    Private Sub Perfiles2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If OpenMode Or Abierto Then
            ComboBox1.Text = ADCAS.TextBox306.Text
            ComboBox4.Text = ADCAS.TextBox305.Text
        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub
End Class