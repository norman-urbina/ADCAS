Public Class Perfiles

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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        db2l.SelectedIndex = ComboBox2.SelectedIndex
        tbf2l.SelectedIndex = ComboBox2.SelectedIndex
        tbw2l.SelectedIndex = ComboBox2.SelectedIndex
        kb12l.SelectedIndex = ComboBox2.SelectedIndex
        kb2l.SelectedIndex = ComboBox2.SelectedIndex
        bbf2l.SelectedIndex = ComboBox2.SelectedIndex
        rbx2l.SelectedIndex = ComboBox2.SelectedIndex
        Tb2l.SelectedIndex = ComboBox2.SelectedIndex
        Ab2l.SelectedIndex = ComboBox2.SelectedIndex
        Zbx2l.SelectedIndex = ComboBox2.SelectedIndex

        Label13.Text = db2l.Text + " in"
        Label14.Text = tbf2l.Text + " in"
        Label15.Text = tbw2l.Text + " in"
        Label16.Text = kb12l.Text + " in"
        Label17.Text = kb2l.Text + " in"
        Label18.Text = bbf2l.Text + " in"
        Label19.Text = rbx2l.Text + " in"
        Label20.Text = Tb2l.Text + " in"
        Label21.Text = Ab2l.Text + " in²"
        Label22.Text = Zbx2l.Text + " in³"

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
            ADCAS.PictureBox242N.Image = My.Resources.LAPmín2
        Else
            PictureBox2.Image = My.Resources.SeccionPIPE2
            ADCAS.PictureBox242N.Image = My.Resources.LapMin
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Por favor, seleccione todos los perfiles.", MsgBoxStyle.Exclamation, "Advertencia")
        Else

            'Cambio en el tipo de acero

            If Abierto = False Or OpenMode Then

                Steel.ComboBox1.Items.Clear()
                Steel.fybrl.Items.Clear()
                Steel.fubrl.Items.Clear()
                Steel.rybrl.Items.Clear()
                Steel.rtbrl.Items.Clear()

                If ComboBox4.Text.Contains("Pipe") Then
                    Steel.ComboBox1.Items.AddRange(New Object() {"ASTM A53"})
                    Steel.fybrl.Items.AddRange(New Object() {"35"})
                    Steel.fubrl.Items.AddRange(New Object() {"60"})
                    Steel.rybrl.Items.AddRange(New Object() {"1.6"})
                    Steel.rtbrl.Items.AddRange(New Object() {"1.2"})
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains(".") Then
                    Steel.ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                    Steel.fybrl.Items.AddRange(New Object() {"42", "46", "36"})
                    Steel.fubrl.Items.AddRange(New Object() {"58", "62", "58"})
                    Steel.rybrl.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                    Steel.rtbrl.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains("/") Then
                    Steel.ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                    Steel.fybrl.Items.AddRange(New Object() {"46", "50", "36"})
                    Steel.fubrl.Items.AddRange(New Object() {"58", "62", "58"})
                    Steel.rybrl.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                    Steel.rtbrl.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
                End If

            End If

            If ADCAS.TextBox297.Text <> String.Empty And ADCAS.TextBox297.Text <> ComboBox4.Text And OpenMode = False Then
               
                If ComboBox4.Text.Contains("Pipe") And ADCAS.TextBox297.Text.Contains("HSS") Then
                    Steel.ComboBox1.Items.Clear()
                    Steel.fybrl.Items.Clear()
                    Steel.fubrl.Items.Clear()
                    Steel.rybrl.Items.Clear()
                    Steel.rtbrl.Items.Clear()
                    ADCAS.TextBox298.Text = "ASTM A53"
                    Steel.ComboBox1.Items.AddRange(New Object() {"ASTM A53"})
                    Steel.fybrl.Items.AddRange(New Object() {"35"})
                    Steel.fubrl.Items.AddRange(New Object() {"60"})
                    Steel.rybrl.Items.AddRange(New Object() {"1.6"})
                    Steel.rtbrl.Items.AddRange(New Object() {"1.2"})
                    Steel.ComboBox1.SelectedIndex = 0
                    Steel.fybrl.SelectedIndex = 0
                    Steel.fubrl.SelectedIndex = 0
                    Steel.rybrl.SelectedIndex = 0
                    Steel.rtbrl.SelectedIndex = 0
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains(".") And (ADCAS.TextBox297.Text.Contains("/") Or ADCAS.TextBox297.Text.Contains("Pipe")) Then
                    Steel.ComboBox1.Items.Clear()
                    Steel.fybrl.Items.Clear()
                    Steel.fubrl.Items.Clear()
                    Steel.rybrl.Items.Clear()
                    Steel.rtbrl.Items.Clear()
                    ADCAS.TextBox298.Text = "ASTM A500 Gr. B"
                    Steel.ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                    Steel.fybrl.Items.AddRange(New Object() {"42", "46", "36"})
                    Steel.fubrl.Items.AddRange(New Object() {"58", "62", "58"})
                    Steel.rybrl.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                    Steel.rtbrl.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
                    Steel.ComboBox1.SelectedIndex = 0
                    Steel.fybrl.SelectedIndex = 0
                    Steel.fubrl.SelectedIndex = 0
                    Steel.rybrl.SelectedIndex = 0
                    Steel.rtbrl.SelectedIndex = 0
                ElseIf ComboBox4.Text.Contains("HSS") And ComboBox4.Text.Contains("/") And (ADCAS.TextBox297.Text.Contains("Pipe") Or (ADCAS.TextBox297.Text.Contains("."))) Then
                    Steel.ComboBox1.Items.Clear()
                    Steel.fybrl.Items.Clear()
                    Steel.fubrl.Items.Clear()
                    Steel.rybrl.Items.Clear()
                    Steel.rtbrl.Items.Clear()
                    ADCAS.TextBox298.Text = "ASTM A500 Gr. B"
                    Steel.ComboBox1.Items.AddRange(New Object() {"ASTM A500 Gr. B", "ASTM A500 Gr. C", "ASTM A501"})
                    Steel.fybrl.Items.AddRange(New Object() {"46", "50", "36"})
                    Steel.fubrl.Items.AddRange(New Object() {"58", "62", "58"})
                    Steel.rybrl.Items.AddRange(New Object() {"1.4", "1.4", "1.4"})
                    Steel.rtbrl.Items.AddRange(New Object() {"1.3", "1.3", "1.3"})
                    Steel.ComboBox1.SelectedIndex = 0
                    Steel.fybrl.SelectedIndex = 0
                    Steel.fubrl.SelectedIndex = 0
                    Steel.rybrl.SelectedIndex = 0
                    Steel.rtbrl.SelectedIndex = 0
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

            db2 = Val(db2l.Text)
            tbf2 = Val(tbf2l.Text)
            tbw2 = Val(tbw2l.Text)
            kbdes2 = Val(kb2l.Text)
            kb12 = Frac2Num(kb12l.Text)
            bbf2 = Val(bbf2l.Text)
            rb2 = Val(rbx2l.Text)
            Tb2 = Frac2Num(Tb2l.Text)
            Ab2 = Val(Ab2l.Text)
            Z2 = Val(Zbx2l.Text)

            dc = Val(dcl.Text)
            tcf = Val(tcfl.Text)
            tcw = Val(tcwl.Text)
            kcdes = Val(kcl.Text)
            bcf = Val(bcfl.Text)
            Tc = Frac2Num(Tcl.Text)

            Agbr = Val(Agbrl.Text)
            tbrnom = Val(tbrnoml.Text)
            tbrdes = Val(tbrdesl.Text)
            Bbr = Val(Bbrl.Text)
            Darr = Math.Max(Val(ODbrl.Text), Val(Htbrl.Text))
            rbr = Val(rxbrl.Text)

            If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
            End If

                ADCAS.TextBox295.Text = ComboBox1.Text
                ADCAS.TextBox294.Text = ComboBox2.Text
                ADCAS.TextBox296.Text = ComboBox3.Text
                ADCAS.TextBox297.Text = ComboBox4.Text
                Abierto = True
                Me.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = ADCAS.TextBox295.Text
        ComboBox2.Text = ADCAS.TextBox294.Text
        ComboBox3.Text = ADCAS.TextBox296.Text
        ComboBox4.Text = ADCAS.TextBox297.Text

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

    Private Sub Perfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            GroupBox2.Text = "Viga superior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            GroupBox2.Text = "Viga superior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            GroupBox2.Text = "Viga inferior"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            GroupBox2.Text = "Viga inferior"
        End If

        If OpenMode Or Abierto Then
            ComboBox1.Text = ADCAS.TextBox295.Text
            ComboBox2.Text = ADCAS.TextBox294.Text
            ComboBox3.Text = ADCAS.TextBox296.Text
            ComboBox4.Text = ADCAS.TextBox297.Text
        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub
End Class