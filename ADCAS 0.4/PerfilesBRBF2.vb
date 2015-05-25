Public Class PerfilesBRBF2

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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "" Then
            MsgBox("Por favor, seleccione el perfil de la viga", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" And (TextBox10.Text = "" Or TextBox9.Text = "" Or TextBox8.Text = "") Then
            MsgBox("Por favor, indique los datos del arriostre BRB's.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" And (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox10.Text = "" Or TextBox9.Text = "" Or TextBox8.Text = "") Then
            MsgBox("Por favor, indique los datos de los arriostres BRB's.", MsgBoxStyle.Exclamation, "Advertencia")
        Else

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

            If ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en V o Chevron (BRBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en X (BRBF)"
            End If

            ADCAS.TextBox317.Text = ComboBox1.Text
            ADCAS.TextBox319.Text = "Pandeo Restringido"
            Abierto = True
            Me.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = ADCAS.TextBox295.Text

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

    Private Sub PerfilesBRBF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub Perfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
        End If

        If OpenMode Or Abierto Then
            ComboBox1.Text = ADCAS.TextBox317.Text
        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        soloNumeros(TextBox1, e)

        If Asc(e.KeyChar) = 13 Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        soloNumeros(TextBox2, e)

        If Asc(e.KeyChar) = 13 Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        soloNumeros(TextBox3, e)

        If Asc(e.KeyChar) = 13 Then
            TextBox10.Focus()
        End If
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        soloNumeros(TextBox10, e)

        If Asc(e.KeyChar) = 13 Then
            TextBox9.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        soloNumeros(TextBox9, e)

        If Asc(e.KeyChar) = 13 Then
            TextBox8.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        soloNumeros(TextBox8, e)

        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub
End Class