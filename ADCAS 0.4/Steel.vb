Public Class Steel

    Public Abierto As Boolean

    Private Sub Steel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        fyb2l.SelectedIndex = ComboBox4.SelectedIndex
        fub2l.SelectedIndex = ComboBox4.SelectedIndex
        ryb2l.SelectedIndex = ComboBox4.SelectedIndex
        rtb2l.SelectedIndex = ComboBox4.SelectedIndex

        Label17.Text = fyb2l.Text + " ksi"
        Label18.Text = fyb2l.Text + " ksi"
        Label19.Text = ryb2l.Text
        Label20.Text = rtb2l.Text
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        fycl.SelectedIndex = ComboBox5.SelectedIndex
        fucl.SelectedIndex = ComboBox5.SelectedIndex
        rycl.SelectedIndex = ComboBox5.SelectedIndex
        rtcl.SelectedIndex = ComboBox5.SelectedIndex

        Label22.Text = fycl.Text + " ksi"
        Label23.Text = fucl.Text + " ksi"
        Label24.Text = rycl.Text
        Label25.Text = rtcl.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = String.Empty Or ComboBox2.Text = String.Empty Or ComboBox3.Text = String.Empty Or ComboBox4.Text = String.Empty Or ComboBox5.Text = String.Empty Then

            MsgBox("Por favor seleccione todos los tipos de acero.", MsgBoxStyle.Exclamation, "Advertencia")

        Else

            ADCAS.TextBox298.Text = ComboBox1.Text
            ADCAS.TextBox301.Text = ComboBox2.Text
            ADCAS.TextBox300.Text = ComboBox3.Text
            ADCAS.TextBox299.Text = ComboBox4.Text
            ADCAS.TextBox302.Text = ComboBox5.Text

            Abierto = True

            Fybr = Val(fybrl.Text)
            Fubr = Val(fubrl.Text)
            Rybr = Val(rybrl.Text)
            Rtbr = Val(rtbrl.Text)

            Fyb = Val(fybl.Text)
            Fub = Val(fubl.Text)
            Ryb = Val(rybl.Text)
            Rtb = Val(rtbl.Text)

            Fyb2 = Val(fyb2l.Text)
            Fub2 = Val(fub2l.Text)
            Ryb2 = Val(ryb2l.Text)
            Rtb2 = Val(rtb2l.Text)

            Fyc = Val(fycl.Text)
            Fuc = Val(fucl.Text)
            Ryc = Val(rycl.Text)
            Rtc = Val(rtcl.Text)

            Fyp = Val(fypl.Text)
            Fup = Val(fupl.Text)
            Ryp = Val(rypl.Text)
            Rtp = Val(rtpl.Text)

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ComboBox1.Text = ADCAS.TextBox298.Text
        ComboBox2.Text = ADCAS.TextBox301.Text
        ComboBox3.Text = ADCAS.TextBox300.Text
        ComboBox4.Text = ADCAS.TextBox299.Text
        ComboBox5.Text = ADCAS.TextBox302.Text

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
End Class