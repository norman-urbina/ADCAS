Public Class CargasEBF2

    Private Sub CargasEBF2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
        End If
    End Sub

    Private Sub CargasEBF2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then

            GroupBox4.Text = "Cargas internas en el enlace de la viga superior"
            GroupBox9.Text = "Cargas internas en el enlace de la viga superior"
            GroupBox2.Enabled = True
            GroupBox3.Enabled = True
            GroupBox4.Enabled = True
            GroupBox8.Enabled = True
            GroupBox7.Enabled = True
            GroupBox9.Enabled = True

            TextBox7.Enabled = False
            TextBox8.Enabled = False
            TextBox9.Enabled = False

            TextBox35.Enabled = False
            TextBox36.Enabled = False
            TextBox37.Enabled = False

        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then

            GroupBox4.Text = "Cargas internas en el enlace de la viga inferior"
            GroupBox9.Text = "Cargas internas en el enlace de la viga inferior"

            GroupBox2.Enabled = True
            GroupBox3.Enabled = False
            GroupBox4.Enabled = True
            GroupBox8.Enabled = False
            GroupBox7.Enabled = True
            GroupBox9.Enabled = True

            TextBox7.Enabled = False
            TextBox8.Enabled = False
            TextBox9.Enabled = False

            TextBox35.Enabled = False
            TextBox36.Enabled = False
            TextBox37.Enabled = False

        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then

            GroupBox2.Enabled = False
            GroupBox3.Enabled = True
            GroupBox4.Enabled = False
            GroupBox7.Enabled = False
            GroupBox8.Enabled = True
            GroupBox9.Enabled = False

            TextBox7.Enabled = True
            TextBox8.Enabled = True
            TextBox9.Enabled = True

            TextBox35.Enabled = True
            TextBox36.Enabled = True
            TextBox37.Enabled = True

        End If

        If OpenMode Then
            Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
        End If

    End Sub

    Public vacío As Boolean

    Private Sub TextVacío(ByRef Grupo As Windows.Forms.GroupBox)
        vacío = False
        Try
            Dim listatextboxes = (From TB As TextBox In Grupo.Controls.OfType(Of TextBox)() _
                                     Select TB).ToList()
            For Each Tb As TextBox In listatextboxes
                If Tb.Text = String.Empty And Tb.Enabled = True Then
                    vacío = True
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim vacío1, vacío2, vacío3, vacío4, vacío5, vacío6, vacío7, vacío8, vacío9, vacío10 As Boolean

        TextVacío(GroupBox1)
        vacío1 = vacío
        TextVacío(GroupBox2)
        vacío2 = vacío
        TextVacío(GroupBox3)
        vacío3 = vacío
        TextVacío(GroupBox4)
        vacío4 = vacío
        TextVacío(GroupBox5)
        vacío5 = vacío
        TextVacío(GroupBox6)
        vacío6 = vacío
        TextVacío(GroupBox7)
        vacío7 = vacío
        TextVacío(GroupBox8)
        vacío8 = vacío
        TextVacío(GroupBox9)
        vacío9 = vacío
        TextVacío(GroupBox10)
        vacío10 = vacío

        If vacío1 Then
            MsgBox("Por favor, introduzca todas las cargas que el arriostre a tensión transmite al nodo.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío2 Then
            MsgBox("Por favor, introduzca todas las cargas que la viga transmite al nodo cuando el arriostre esta a tensión.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío3 Then
            MsgBox("Por favor, introduzca todas las cargas internas del enlace de la viga a conectar cuando el arriostre está a tensión.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío4 Then
            MsgBox("Por favor, introduzca todas las cargas internas del enlace de la viga superior o inferior cuando el arriostre está a tensión.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío5 Then
            MsgBox("Por favor, introduzca la carga sísmica para un movimiento en la dirección positiva del eje X.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío6 Then
            MsgBox("Por favor, introduzca todas las cargas que el arriostre a compresión transmite al nodo.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío7 Then
            MsgBox("Por favor, introduzca todas las cargas que la viga transmite al nodo cuando el arriostre esta a compresión.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío8 Then
            MsgBox("Por favor, introduzca todas las cargas internas del enlace de la viga a conectar cuando el arriostre está a compresión.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío9 Then
            MsgBox("Por favor, introduzca todas las cargas internas del enlace de la viga superior o inferior cuando el arriostre está a compresión.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf vacío10 Then
            MsgBox("Por favor, introduzca la carga sísmica para un movimiento en la dirección negativa del eje X.", MsgBoxStyle.Exclamation, "Advertencia")
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then

            'Viga a conectar

            Dim Pubm1, Pubm2, PubmM As Double
            Dim Vubm1, Vubm2, VubmM As Double

            Vubm1 = Math.Round(1.4 * Val(TextBox16.Text) + 0.5 * Val(TextBox17.Text) + 1.3 * Val(TextBox18.Text), 2)
            Vubm2 = Math.Round(1.4 * Val(TextBox44.Text) + 0.5 * Val(TextBox45.Text) + 1.3 * Val(TextBox46.Text), 2)
            VubmM = Math.Max(Vubm1, Vubm2)

            Pubm1 = Math.Round(1.4 * Val(TextBox19.Text) + 0.5 * Val(TextBox20.Text) + 1.3 * Val(TextBox21.Text), 2)
            Pubm2 = Math.Round(1.4 * Val(TextBox47.Text) + 0.5 * Val(TextBox48.Text) + 1.3 * Val(TextBox49.Text), 2)
            PubmM = Math.Max(Pubm1, Pubm2)

            Dim Py, Pc, Pr As Double
            Dim Vp, Mp As Double

            Py = Ab * Fyb
            Pc = Py
            Pr = PubmM

            If Pr / Pc <= 0.15 Then
                Vp = 0.6 * Fyb * (db - 2 * tbf) * tbw
                Mp = Fyb * Z
                mínLnkLngth = Math.Round(1.6 * Mp / Vp, 2)
            Else
                Vp = 0.6 * Fyb * (db - 2 * tbf) * tbw * Math.Sqrt(1 - (Pr / Pc) ^ 2)
                Mp = Fyb * Z * ((1 - Pr / Pc) / 0.85)
                Dim rhop As Double
                rhop = (Pr / Pc) / (VubmM / (0.6 * Fyb * (db - 2 * tbf)))
                mínLnkLngth = Math.Round(0.6 * Mp / Vp * (1.15 - 0.3 * rhop), 2)
            End If

            Dim AdjStrgnth As Double

            AdjStrgnth = 1.25 * Ryb * Vp

            If Pubm1 > Pubm2 Then
                Srr = Math.Round(AdjStrgnth / Val(TextBox18.Text), 2)
            Else
                Srr = Math.Round(AdjStrgnth / Val(TextBox52.Text), 2)
            End If

            'Viga superior o inferior

            Dim Pubm12, Pubm22, PubmM2 As Double
            Dim Vubm12, Vubm22, VubmM2 As Double

            Vubm12 = Math.Round(1.4 * Val(TextBox22.Text) + 0.5 * Val(TextBox23.Text) + 1.3 * Val(TextBox24.Text), 2)
            Vubm22 = Math.Round(1.4 * Val(TextBox50.Text) + 0.5 * Val(TextBox51.Text) + 1.3 * Val(TextBox52.Text), 2)
            VubmM2 = Math.Max(Vubm12, Vubm22)

            Pubm12 = Math.Round(1.4 * Val(TextBox25.Text) + 0.5 * Val(TextBox26.Text) + 1.3 * Val(TextBox27.Text), 2)
            Pubm22 = Math.Round(1.4 * Val(TextBox53.Text) + 0.5 * Val(TextBox54.Text) + 1.3 * Val(TextBox55.Text), 2)
            PubmM2 = Math.Max(Pubm12, Pubm22)

            Dim Py2, Pc2, Pr2 As Double
            Dim Vp2, Mp2 As Double

            Py2 = Ab2 * Fyb2
            Pc2 = Py2
            Pr2 = PubmM2

            '   Resistencias disponibles en la viga superior o inferior

            If Pr2 / Pc2 <= 0.15 Then
                Vp2 = Math.Round(0.6 * Fyb2 * (db2 - 2 * tbf2) * tbw2, 2)
                Mp2 = Math.Round(Fyb2 * Z2, 2)
                mínLnkLngth2 = Math.Round(1.6 * Mp2 / Vp2, 2)
            Else
                Vp2 = Math.Round(0.6 * Fyb2 * (db2 - 2 * tbf2) * tbw2 * Math.Sqrt(1 - (Pr2 / Pc2) ^ 2), 2)
                Mp2 = Math.Round(Fyb2 * Z2 * ((1 - Pr2 / Pc2) / 0.85), 2)
                Dim rhop As Double
                rhop = (Pr2 / Pc2) / (VubmM2 / (0.6 * Fyb2 * (db2 - 2 * tbf2)))
                mínLnkLngth2 = Math.Round(1.6 * Mp2 / Vp2 * (1.15 - 0.3 * rhop), 2)
            End If

            'Resistencia ajustada del enlace al cortante

            Dim AdjStrgnth2 As Double

            AdjStrgnth2 = 1.25 * Ryb2 * Vp2

            'Sobrerresistencia del enlace

            If Pubm12 > Pubm22 Then
                Srr2 = Math.Round(AdjStrgnth2 / Val(TextBox24.Text), 2)
            Else
                Srr2 = Math.Round(AdjStrgnth2 / Val(TextBox52.Text), 2)
            End If

            ADCAS.Label971.Text = "in <= " + mínLnkLngth.ToString + " in"
            ADCAS.Label970.Text = "in <= " + mínLnkLngth2.ToString + " in"

            If Val(ADCAS.TextBox290.Text) > mínLnkLngth And ADCAS.TextBox290.Text <> String.Empty Then
                ADCAS.TextBox290.BackColor = Color.Red
            ElseIf Val(ADCAS.TextBox290.Text) <= mínLnkLngth And ADCAS.TextBox290.Text <> String.Empty Then
                ADCAS.TextBox290.BackColor = Color.White
            End If

            If Val(ADCAS.TextBox292.Text) > mínLnkLngth2 And ADCAS.TextBox292.Text <> String.Empty Then
                ADCAS.TextBox292.BackColor = Color.Red
            ElseIf Val(ADCAS.TextBox292.Text) <= mínLnkLngth2 And ADCAS.TextBox292.Text <> String.Empty Then
                ADCAS.TextBox292.BackColor = Color.White
            End If

            If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
            End If

            Me.Close()

        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then

            'Viga superior o inferior

            Dim Pubm12, Pubm22, PubmM2 As Double
            Dim Vubm12, Vubm22, VubmM2 As Double

            Vubm12 = Math.Round(1.4 * Val(TextBox22.Text) + 0.5 * Val(TextBox23.Text) + 1.3 * Val(TextBox24.Text), 2)
            Vubm22 = Math.Round(1.4 * Val(TextBox50.Text) + 0.5 * Val(TextBox51.Text) + 1.3 * Val(TextBox52.Text), 2)
            VubmM2 = Math.Max(Vubm12, Vubm22)

            Pubm12 = Math.Round(1.4 * Val(TextBox25.Text) + 0.5 * Val(TextBox26.Text) + 1.3 * Val(TextBox27.Text), 2)
            Pubm22 = Math.Round(1.4 * Val(TextBox53.Text) + 0.5 * Val(TextBox54.Text) + 1.3 * Val(TextBox55.Text), 2)
            PubmM2 = Math.Max(Pubm12, Pubm22)

            Dim Py2, Pc2, Pr2 As Double
            Dim Vp2, Mp2 As Double

            Py2 = Ab2 * Fyb2
            Pc2 = Py2
            Pr2 = PubmM2

            '   Resistencias disponibles en la viga superior o inferior

            If Pr2 / Pc2 <= 0.15 Then
                Vp2 = Math.Round(0.6 * Fyb2 * (db2 - 2 * tbf2) * tbw2, 2)
                Mp2 = Math.Round(Fyb2 * Z2, 2)
                mínLnkLngth2 = Math.Round(1.6 * Mp2 / Vp2, 2)
            Else
                Vp2 = Math.Round(0.6 * Fyb2 * (db2 - 2 * tbf2) * tbw2 * Math.Sqrt(1 - (Pr2 / Pc2) ^ 2), 2)
                Mp2 = Math.Round(Fyb2 * Z2 * ((1 - Pr2 / Pc2) / 0.85), 2)
                Dim rhop As Double
                rhop = (Pr2 / Pc2) / (VubmM2 / (0.6 * Fyb2 * (db2 - 2 * tbf2)))
                mínLnkLngth2 = Math.Round(1.6 * Mp2 / Vp2 * (1.15 - 0.3 * rhop), 2)
            End If

            'Resistencia ajustada del enlace al cortante

            Dim AdjStrgnth2 As Double

            AdjStrgnth2 = 1.25 * Ryb2 * Vp2

            'Sobrerresistencia del enlace

            If Pubm12 > Pubm22 Then
                Srr2 = Math.Round(AdjStrgnth2 / Val(TextBox24.Text), 2)
            Else
                Srr2 = Math.Round(AdjStrgnth2 / Val(TextBox52.Text), 2)
            End If

            'Cargas en la conexión

            Tu = Math.Round(1.4 * Val(TextBox4.Text) + 0.5 * Val(TextBox5.Text) + Srr2 * Val(TextBox6.Text), 2)
            Pu = Math.Round(1.4 * Val(TextBox32.Text) + 0.5 * Val(TextBox33.Text) + Srr2 * Val(TextBox34.Text), 2)

            ADCAS.Label971.Text = "in <= " + mínLnkLngth2.ToString + " in"

            If Val(ADCAS.TextBox290.Text) > mínLnkLngth2 And ADCAS.TextBox290.Text <> String.Empty Then
                ADCAS.TextBox290.BackColor = Color.Red
            ElseIf Val(ADCAS.TextBox290.Text) <= mínLnkLngth2 And ADCAS.TextBox290.Text <> String.Empty Then
                ADCAS.TextBox290.BackColor = Color.White
            End If

            If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
            ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
            End If

            Me.Close()

        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then

            'Viga a conectar

            Dim Pubm1, Pubm2, PubmM As Double
            Dim Vubm1, Vubm2, VubmM As Double

            Vubm1 = Math.Round(1.4 * Val(TextBox16.Text) + 0.5 * Val(TextBox17.Text) + 1.3 * Val(TextBox18.Text), 2)
            Vubm2 = Math.Round(1.4 * Val(TextBox44.Text) + 0.5 * Val(TextBox45.Text) + 1.3 * Val(TextBox46.Text), 2)
            VubmM = Math.Max(Vubm1, Vubm2)

            Pubm1 = Math.Round(1.4 * Val(TextBox19.Text) + 0.5 * Val(TextBox20.Text) + 1.3 * Val(TextBox21.Text), 2)
            Pubm2 = Math.Round(1.4 * Val(TextBox47.Text) + 0.5 * Val(TextBox48.Text) + 1.3 * Val(TextBox49.Text), 2)
            PubmM = Math.Max(Pubm1, Pubm2)

            Dim Py, Pc, Pr As Double
            Dim Vp, Mp As Double

            Py = Ab * Fyb
            Pc = Py
            Pr = PubmM

            If Pr / Pc <= 0.15 Then
                Vp = 0.6 * Fyb * (db - 2 * tbf) * tbw
                Mp = Fyb * Z
                mínLnkLngth = Math.Round(1.6 * Mp / Vp, 2)
            Else
                Vp = 0.6 * Fyb * (db - 2 * tbf) * tbw * Math.Sqrt(1 - (Pr / Pc) ^ 2)
                Mp = Fyb * Z * ((1 - Pr / Pc) / 0.85)
                Dim rhop As Double
                rhop = (Pr / Pc) / (VubmM / (0.6 * Fyb * (db - 2 * tbf)))
                mínLnkLngth = Math.Round(0.6 * Mp / Vp * (1.15 - 0.3 * rhop), 2)
            End If

            Dim AdjStrgnth As Double

            AdjStrgnth = 1.25 * Ryb * Vp

            If Pubm1 > Pubm2 Then
                Srr = Math.Round(AdjStrgnth / Val(TextBox18.Text), 2)
            Else
                Srr = Math.Round(AdjStrgnth / Val(TextBox46.Text), 2)
            End If

            'Cargas en la conexión

            Tu = Math.Round(1.4 * Val(TextBox4.Text) + 0.5 * Val(TextBox5.Text) + Srr * Val(TextBox6.Text), 2)
            Pu = Math.Round(1.4 * Val(TextBox32.Text) + 0.5 * Val(TextBox33.Text) + Srr * Val(TextBox34.Text), 2)

            ADCAS.Label971.Text = "in <= " + mínLnkLngth.ToString + " in"

            If Val(ADCAS.TextBox290.Text) > mínLnkLngth And ADCAS.TextBox290.Text <> String.Empty Then
                ADCAS.TextBox290.BackColor = Color.Red
            ElseIf Val(ADCAS.TextBox290.Text) <= mínLnkLngth And ADCAS.TextBox290.Text <> String.Empty Then
                ADCAS.TextBox290.BackColor = Color.White
            End If

            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"

            Me.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
        End If
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        NumMenos(TextBox1, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox1.Text, TextBox1, TextBox2)
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        NumMenos(TextBox2, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox2.Text, TextBox2, TextBox3)
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        NumMenos(TextBox3, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox3.Text, TextBox3, TextBox4)
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        NumMenos(TextBox4, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox4.Text, TextBox4, TextBox5)
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        NumMenos(TextBox5, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox5.Text, TextBox5, TextBox6)
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        NumMenos(TextBox6, e)
        If Asc(e.KeyChar) = 13 Then
            Dim Pos As Integer
            Pos = Strings.InStr(TextBox6.Text, "-")
            If Pos = 1 Or Pos = 0 Then
                If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                    TextBox10.Focus()
                ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
                    TextBox10.Focus()
                ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
                    TextBox7.Focus()
                End If
            Else
                MsgBox("Valor no reconocido. Coloque el signo menos al inicio", MsgBoxStyle.Critical, "Valor no válido")
                TextBox6.Text = ""
                TextBox6.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        NumMenos(TextBox7, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox7.Text, TextBox7, TextBox8)
        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        NumMenos(TextBox8, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox8.Text, TextBox8, TextBox9)
        End If
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        NumMenos(TextBox9, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox9.Text, TextBox9, TextBox16)
        End If
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        NumMenos(TextBox10, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox10.Text, TextBox10, TextBox11)
        End If
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        NumMenos(TextBox11, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox11.Text, TextBox11, TextBox12)
        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        NumMenos(TextBox12, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox12.Text, TextBox12, TextBox13)
        End If
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox13.KeyPress
        NumMenos(TextBox13, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox13.Text, TextBox13, TextBox14)
        End If
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        NumMenos(TextBox14, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox14.Text, TextBox14, TextBox15)
        End If
    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
        NumMenos(TextBox15, e)
        If Asc(e.KeyChar) = 13 Then
            Dim Pos As Integer
            Pos = Strings.InStr(TextBox15.Text, "-")
            If Pos = 1 Or Pos = 0 Then
                If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                    TextBox16.Focus()
                ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
                    TextBox22.Focus()
                End If
            Else
                MsgBox("Valor no reconocido. Coloque el signo menos al inicio", MsgBoxStyle.Critical, "Valor no válido")
                TextBox15.Text = ""
                TextBox15.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox16.KeyPress
        NumMenos(TextBox16, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox16.Text, TextBox16, TextBox17)
        End If
    End Sub

    Private Sub TextBox17_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox17.KeyPress
        NumMenos(TextBox17, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox17.Text, TextBox17, TextBox18)
        End If
    End Sub

    Private Sub TextBox18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox18.KeyPress
        NumMenos(TextBox18, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox18.Text, TextBox18, TextBox19)
        End If
    End Sub

    Private Sub TextBox19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox19.KeyPress
        NumMenos(TextBox19, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox19.Text, TextBox19, TextBox20)
        End If
    End Sub

    Private Sub TextBox20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox20.KeyPress
        NumMenos(TextBox20, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox20.Text, TextBox20, TextBox21)
        End If
    End Sub

    Private Sub TextBox21_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox21.KeyPress
        NumMenos(TextBox21, e)
        If Asc(e.KeyChar) = 13 Then
            Dim Pos As Integer
            Pos = Strings.InStr(TextBox21.Text, "-")
            If Pos = 1 Or Pos = 0 Then
                If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                    TextBox22.Focus()
                ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
                    TextBox28.Focus()
                End If
            Else
                MsgBox("Valor no reconocido. Coloque el signo menos al inicio", MsgBoxStyle.Critical, "Valor no válido")
                TextBox21.Text = ""
                TextBox21.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox22_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox22.KeyPress
        NumMenos(TextBox22, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox22.Text, TextBox22, TextBox23)
        End If
    End Sub

    Private Sub TextBox23_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox23.KeyPress
        NumMenos(TextBox23, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox23.Text, TextBox23, TextBox24)
        End If
    End Sub

    Private Sub TextBox24_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox24.KeyPress
        NumMenos(TextBox24, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox24.Text, TextBox24, TextBox25)
        End If
    End Sub

    Private Sub TextBox25_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox25.KeyPress
        NumMenos(TextBox25, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox25.Text, TextBox25, TextBox26)
        End If
    End Sub

    Private Sub TextBox26_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox26.KeyPress
        NumMenos(TextBox26, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox26.Text, TextBox26, TextBox27)
        End If
    End Sub

    Private Sub TextBox27_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox27.KeyPress
        NumMenos(TextBox27, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox27.Text, TextBox27, TextBox28)
        End If
    End Sub

    Private Sub TextBox28_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox28.KeyPress
        soloNumeros(TextBox28, e)
        If Asc(e.KeyChar) = 13 Then
            TabControl1.SelectTab(1)
            TextBox29.Focus()
        End If
    End Sub

    Private Sub TextBox29_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox29.KeyPress
        NumMenos(TextBox29, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox29.Text, TextBox29, TextBox30)
        End If
    End Sub

    Private Sub TextBox30_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox30.KeyPress
        NumMenos(TextBox30, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox30.Text, TextBox30, TextBox31)
        End If
    End Sub

    Private Sub TextBox31_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox31.KeyPress
        NumMenos(TextBox31, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox31.Text, TextBox31, TextBox32)
            TextBox32.Focus()
        End If
    End Sub

    Private Sub TextBox32_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox32.KeyPress
        NumMenos(TextBox32, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox32.Text, TextBox32, TextBox33)
        End If
    End Sub

    Private Sub TextBox33_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox33.KeyPress
        NumMenos(TextBox33, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox33.Text, TextBox33, TextBox34)
        End If
    End Sub

    Private Sub TextBox34_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox34.KeyPress
        NumMenos(TextBox34, e)
        If Asc(e.KeyChar) = 13 Then
            Dim Pos As Integer
            Pos = Strings.InStr(TextBox34.Text, "-")
            If Pos = 1 Or Pos = 0 Then
                If ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
                    TextBox35.Focus()
                Else
                    TextBox38.Focus()
                End If
            Else
                MsgBox("Valor no reconocido. Coloque el signo menos al inicio", MsgBoxStyle.Critical, "Valor no válido")
                TextBox34.Text = ""
                TextBox34.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox35_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox35.KeyPress
        NumMenos(TextBox35, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox35.Text, TextBox35, TextBox36)
        End If
    End Sub

    Private Sub TextBox36_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox36.KeyPress
        NumMenos(TextBox36, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox36.Text, TextBox36, TextBox37)
        End If
    End Sub

    Private Sub TextBox37_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox37.KeyPress
        NumMenos(TextBox37, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox37.Text, TextBox37, TextBox44)
        End If
    End Sub

    Private Sub TextBox38_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox38.KeyPress
        NumMenos(TextBox38, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox38.Text, TextBox38, TextBox39)
        End If
    End Sub

    Private Sub TextBox39_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox39.KeyPress
        NumMenos(TextBox39, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox39.Text, TextBox39, TextBox40)
        End If
    End Sub

    Private Sub TextBox40_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox40.KeyPress
        NumMenos(TextBox40, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox40.Text, TextBox40, TextBox41)
        End If
    End Sub

    Private Sub TextBox41_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox41.KeyPress
        NumMenos(TextBox41, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox41.Text, TextBox41, TextBox42)
        End If
    End Sub

    Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox42.KeyPress
        NumMenos(TextBox42, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox42.Text, TextBox42, TextBox43)
        End If
    End Sub

    Private Sub TextBox43_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox43.KeyPress
        NumMenos(TextBox43, e)
        If Asc(e.KeyChar) = 13 Then
            Dim Pos As Integer
            Pos = Strings.InStr(TextBox43.Text, "-")
            If Pos = 1 Or Pos = 0 Then
                If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                    TextBox44.Focus()
                ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
                    TextBox50.Focus()
                End If
            Else
                MsgBox("Valor no reconocido. Coloque el signo menos al inicio", MsgBoxStyle.Critical, "Valor no válido")
                TextBox43.Text = ""
                TextBox43.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox44_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox44.KeyPress
        NumMenos(TextBox44, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox44.Text, TextBox44, TextBox45)
        End If
    End Sub

    Private Sub TextBox45_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox45.KeyPress
        NumMenos(TextBox45, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox45.Text, TextBox45, TextBox46)
        End If
    End Sub

    Private Sub TextBox46_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox46.KeyPress
        NumMenos(TextBox46, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox46.Text, TextBox46, TextBox47)
        End If
    End Sub

    Private Sub TextBox47_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox47.KeyPress
        NumMenos(TextBox47, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox47.Text, TextBox47, TextBox48)
        End If
    End Sub

    Private Sub TextBox48_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox48.KeyPress
        NumMenos(TextBox48, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox48.Text, TextBox48, TextBox49)
        End If
    End Sub

    Private Sub TextBox49_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox49.KeyPress
        NumMenos(TextBox49, e)
        If Asc(e.KeyChar) = 13 Then
            Dim Pos As Integer
            Pos = Strings.InStr(TextBox49.Text, "-")
            If Pos = 1 Or Pos = 0 Then
                If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
                    TextBox50.Focus()
                ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
                    TextBox56.Focus()
                End If
            Else
                MsgBox("Valor no reconocido. Coloque el signo menos al inicio", MsgBoxStyle.Critical, "Valor no válido")
                TextBox49.Text = ""
                TextBox49.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox50_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox50.KeyPress
        NumMenos(TextBox50, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox50.Text, TextBox50, TextBox51)
        End If
    End Sub

    Private Sub TextBox51_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox51.KeyPress
        NumMenos(TextBox51, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox51.Text, TextBox51, TextBox52)
        End If
    End Sub

    Private Sub TextBox52_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox52.KeyPress
        NumMenos(TextBox52, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox52.Text, TextBox52, TextBox53)
        End If
    End Sub

    Private Sub TextBox53_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox53.KeyPress
        NumMenos(TextBox53, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox53.Text, TextBox53, TextBox54)
        End If
    End Sub

    Private Sub TextBox54_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox54.KeyPress
        NumMenos(TextBox54, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox54.Text, TextBox54, TextBox55)
        End If
    End Sub

    Private Sub TextBox55_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox55.KeyPress
        NumMenos(TextBox55, e)
        If Asc(e.KeyChar) = 13 Then
            SignoMenos(TextBox55.Text, TextBox55, TextBox56)
        End If
    End Sub

    Private Sub TextBox56_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox56.KeyPress
        soloNumeros(TextBox56, e)
        If Asc(e.KeyChar) = 13 Then
            Button4.Focus()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_Click(ADCAS.AbrirToolStripMenuItem1, Nothing)
    End Sub
End Class