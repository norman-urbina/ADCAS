Public Class SteelBRBF2

    Public Abierto As Boolean

    Private Sub SteelBRBF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada BRBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (BRBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Doble Soldada BRBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Doble Soldada (BRBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en V o Chevron (BRBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en X (BRBF)"
        End If
    End Sub

    Private Sub Steelbrbf_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
        End If

        If Abierto Or OpenMode Then
            ComboBox2.Text = ADCAS.TextBox291.Text
            ComboBox3.Text = ADCAS.TextBox312.Text
        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

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

        If ComboBox2.Text = String.Empty Or ComboBox3.Text = String.Empty Then
            MsgBox("Por favor seleccione todos los tipos de acero.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" And (TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Por favor indique el acero del arriostre BRB's.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" And (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Por favor indique el acero de los arriostres BRB's.", MsgBoxStyle.Exclamation, "Advertencia")
        Else

            ADCAS.TextBox291.Text = ComboBox2.Text
            ADCAS.TextBox312.Text = ComboBox3.Text
            ADCAS.TextBox311.Text = "Según fabricante"

            Fyb = Val(fybl.Text)
            Fub = Val(fubl.Text)
            Ryb = Val(rybl.Text)
            Rtb = Val(rtbl.Text)

            Fyp = Val(fypl.Text)
            Fup = Val(fupl.Text)
            Ryp = Val(rypl.Text)
            Rtp = Val(rtpl.Text)

            Abierto = True

            If ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en V o Chevron (BRBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en X (BRBF)"
            End If

            Me.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ComboBox2.Text = ADCAS.TextBox291.Text
        ComboBox3.Text = ADCAS.TextBox312.Text

        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada BRBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (BRBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Doble Soldada BRBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Doble Soldada (BRBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en V o Chevron (BRBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en X (BRBF)"
        End If

        Me.Close()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        soloEntero(e)

        If Asc(e.KeyChar) = 13 Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        soloNumeros(TextBox2, e)

        If Asc(e.KeyChar) = 13 Then
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        soloEntero(e)

        If Asc(e.KeyChar) = 13 Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        soloNumeros(TextBox3, e)

        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub

End Class