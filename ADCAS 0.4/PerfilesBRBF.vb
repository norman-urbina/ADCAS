Public Class PerfilesBRBF

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

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        dcl.SelectedIndex = ComboBox3.SelectedIndex
        tcfl.SelectedIndex = ComboBox3.SelectedIndex
        tcwl.SelectedIndex = ComboBox3.SelectedIndex
        kc1l.SelectedIndex = ComboBox3.SelectedIndex
        kcl.SelectedIndex = ComboBox3.SelectedIndex
        bcfl.SelectedIndex = ComboBox3.SelectedIndex
        rcxl.SelectedIndex = ComboBox3.SelectedIndex
        Tcl.SelectedIndex = ComboBox3.SelectedIndex
        Acl.SelectedIndex = ComboBox3.SelectedIndex
        Zcxl.SelectedIndex = ComboBox3.SelectedIndex

        Label24.Text = dcl.Text + " in"
        Label25.Text = tcfl.Text + " in"
        Label26.Text = tcwl.Text + " in"
        Label27.Text = kc1l.Text + " in"
        Label28.Text = kcl.Text + " in"
        Label29.Text = bcfl.Text + " in"
        Label30.Text = rcxl.Text + " in"
        Label31.Text = Tcl.Text + " in"
        Label32.Text = Acl.Text + " in²"
        Label33.Text = Zcxl.Text + " in³"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Por favor, seleccione todos los perfiles.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox10.Text = "" Or TextBox9.Text = "" Or TextBox8.Text = "" Then
            MsgBox("Por favor, indique los datos de los arriostres BRB's.", MsgBoxStyle.Exclamation, "Advertencia")
        Else

            'Cambio en el tipo de acero

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

            dc = Val(dcl.Text)
            tcf = Val(tcfl.Text)
            tcw = Val(tcwl.Text)
            kcdes = Val(kcl.Text)
            bcf = Val(bcfl.Text)
            Tc = Frac2Num(Tcl.Text)

           If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada BRBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (BRBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Doble Soldada BRBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Doble Soldada (BRBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga Chevron BRBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en V o Chevron (BRBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Viga en X BRBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga en X (BRBF)"
            End If

            If Val(bbfl.Text) > Val(bcfl.Text) Then
                MsgBox("El patín de la viga es más ancho que el patín de la columna. Por favor, cambie los perfiles.", MsgBoxStyle.Exclamation, "Advertencia")
            Else
                ADCAS.TextBox317.Text = ComboBox1.Text
                ADCAS.TextBox319.Text = ComboBox3.Text
                ADCAS.TextBox293.Text = "Pandeo Restringido"
                Abierto = True
                Me.Close()
            End If

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = ADCAS.TextBox295.Text
        ComboBox3.Text = ADCAS.TextBox296.Text

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

        If OpenMode Or Abierto Then
            ComboBox1.Text = ADCAS.TextBox317.Text
            ComboBox3.Text = ADCAS.TextBox319.Text
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