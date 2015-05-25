Public Class Steel2

    Public Abierto As Boolean

    Private Sub Steel2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        fybrl.SelectedIndex = ComboBox1.SelectedIndex
        fubrl.SelectedIndex = ComboBox1.SelectedIndex
        rybrl.SelectedIndex = ComboBox1.SelectedIndex
        rtbrl.SelectedIndex = ComboBox1.SelectedIndex

        Label2.Text = fybrl.Text + " ksi"
        Label3.Text = fubrl.Text + " ksi"
        Label4.Text = rybrl.Text
        Label5.Text = rtbrl.Text
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        fypl.SelectedIndex = ComboBox2.SelectedIndex
        fupl.SelectedIndex = ComboBox2.SelectedIndex
        rypl.SelectedIndex = ComboBox2.SelectedIndex
        rtpl.SelectedIndex = ComboBox2.SelectedIndex

        Label7.Text = fypl.Text + " ksi"
        Label8.Text = fupl.Text + " ksi"
        Label9.Text = rypl.Text
        Label10.Text = rtpl.Text
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        fybl.SelectedIndex = ComboBox3.SelectedIndex
        fubl.SelectedIndex = ComboBox3.SelectedIndex
        rybl.SelectedIndex = ComboBox3.SelectedIndex
        rtbl.SelectedIndex = ComboBox3.SelectedIndex

        Label12.Text = fybl.Text + " ksi"
        Label13.Text = fubl.Text + " ksi"
        Label14.Text = rybl.Text
        Label15.Text = rtbl.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = String.Empty Or ComboBox2.Text = String.Empty Or ComboBox3.Text = String.Empty Then

            MsgBox("Por favor seleccione todos los tipos de acero.", MsgBoxStyle.Exclamation, "Advertencia")

        Else

            ADCAS.TextBox308.Text = ComboBox1.Text
            ADCAS.TextBox307.Text = ComboBox2.Text
            ADCAS.TextBox309.Text = ComboBox3.Text

            Fybr = Val(fybrl.Text)
            Fubr = Val(fubrl.Text)
            Rybr = Val(rybrl.Text)
            Rtbr = Val(rtbrl.Text)

            Fyb = Val(fybl.Text)
            Fub = Val(fubl.Text)
            Ryb = Val(rybl.Text)
            Rtb = Val(rtbl.Text)

            Fyp = Val(fypl.Text)
            Fup = Val(fupl.Text)
            Ryp = Val(rypl.Text)
            Rtp = Val(rtpl.Text)

            Abierto = True

            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"

            Me.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ComboBox1.Text = ADCAS.TextBox308.Text
        ComboBox2.Text = ADCAS.TextBox307.Text
        ComboBox3.Text = ADCAS.TextBox309.Text

        ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"

        Me.Close()

    End Sub
End Class