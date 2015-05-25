Public Class CargasEBF

    Private Sub CargasEBF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub CargasEBF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            TabPage4.Text = "Viga superior"
            GroupBox5.Visible = True
            GroupBox4.Location = New System.Drawing.Point(270, 161)
            If TabControl1.TabPages.Contains(TabPage3) = False Then
                TabControl1.TabPages.Insert(0, TabPage3)
            End If
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            TabPage4.Text = "Viga inferior"
            GroupBox5.Visible = False
            GroupBox4.Location = New System.Drawing.Point(270, 84)
            If TabControl1.TabPages.Contains(TabPage3) = False Then
                TabControl1.TabPages.Insert(0, TabPage3)
            End If
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
            If TabControl1.TabPages.Contains(TabPage3) = True Then
                TabControl1.TabPages.Remove(TabPage3)
            End If
        End If
    End Sub

    Private Sub TextBox27_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox27.KeyPress
        soloNumeros(TextBox27, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox29.Focus()
        End If
    End Sub

    Private Sub TextBox29_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox29.KeyPress
        soloNumeros(TextBox29, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox30.Focus()
        End If
    End Sub

    Private Sub TextBox30_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox30.KeyPress
        soloNumeros(TextBox30, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox25.Focus()
        End If
    End Sub

    Private Sub TextBox25_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox25.KeyPress
        soloNumeros(TextBox25, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox28.Focus()
        End If
    End Sub

    Private Sub TextBox28_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox28.KeyPress
        soloNumeros(TextBox28, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox26.Focus()
        End If
    End Sub

    Private Sub TextBox26_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox26.KeyPress
        soloNumeros(TextBox26, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox31.Focus()
        End If
    End Sub

    Private Sub TextBox31_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox31.KeyPress
        soloNumeros(TextBox31, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox33.Focus()
        End If
    End Sub

    Private Sub TextBox33_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox33.KeyPress
        soloNumeros(TextBox33, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox32.Focus()
        End If
    End Sub

    Private Sub TextBox32_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox32.KeyPress
        soloNumeros(TextBox32, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox19.Focus()
        End If
    End Sub

    Private Sub TextBox19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox19.KeyPress
        soloNumeros(TextBox19, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox20.Focus()
        End If
    End Sub

    Private Sub TextBox20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox20.KeyPress
        soloNumeros(TextBox20, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox21.Focus()
        End If
    End Sub

    Private Sub TextBox21_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox21.KeyPress
        soloNumeros(TextBox21, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox22.Focus()
        End If
    End Sub

    Private Sub TextBox22_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox22.KeyPress
        soloNumeros(TextBox22, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox23.Focus()
        End If
    End Sub

    Private Sub TextBox23_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox23.KeyPress
        soloNumeros(TextBox23, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox24.Focus()
        End If
    End Sub

    Private Sub TextBox24_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox24.KeyPress
        soloNumeros(TextBox24, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox39_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox39.KeyPress
        soloNumeros(TextBox39, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox41.Focus()
        End If
    End Sub

    Private Sub TextBox41_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox41.KeyPress
        soloNumeros(TextBox41, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox42.Focus()
        End If
    End Sub

    Private Sub TextBox37_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox37.KeyPress
        soloNumeros(TextBox37, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox40.Focus()
        End If
    End Sub

    Private Sub TextBox40_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox40.KeyPress
        soloNumeros(TextBox40, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox38.Focus()
        End If
    End Sub

    Private Sub TextBox38_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox38.KeyPress
        soloNumeros(TextBox38, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox34.Focus()
        End If
    End Sub

    Private Sub TextBox34_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox34.KeyPress
        soloNumeros(TextBox34, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox36.Focus()
        End If
    End Sub

    Private Sub TextBox36_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox36.KeyPress
        soloNumeros(TextBox36, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox35.Focus()
        End If
    End Sub

    Private Sub TextBox35_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox35.KeyPress

        soloNumeros(TextBox35, e)
       
        If Asc(e.KeyChar) = 13 Then
            If ADCAS.LabelDiseño.Text <> "Conexión Arriostre-Enlace" Then
                TabControl1.SelectTab(2)
                TextBox54.Focus()
            Else
                TabControl1.SelectTab(1)
                TextBox54.Focus()
            End If
            
        End If
    End Sub

    Private Sub TextBox54_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox54.KeyPress
        soloNumeros(TextBox54, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox56.Focus()
        End If
    End Sub

    Private Sub TextBox56_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox56.KeyPress
        soloNumeros(TextBox56, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox57.Focus()
        End If
    End Sub

    Private Sub TextBox57_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox57.KeyPress
        soloNumeros(TextBox57, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox52.Focus()
        End If
    End Sub

    Private Sub TextBox52_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox52.KeyPress
        soloNumeros(TextBox52, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox55.Focus()
        End If
    End Sub

    Private Sub TextBox55_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox55.KeyPress
        soloNumeros(TextBox55, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox53.Focus()
        End If
    End Sub

    Private Sub TextBox53_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox53.KeyPress
        soloNumeros(TextBox53, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox49.Focus()
        End If
    End Sub

    Private Sub TextBox49_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox49.KeyPress
        soloNumeros(TextBox49, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox51.Focus()
        End If
    End Sub

    Private Sub TextBox51_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox51.KeyPress
        soloNumeros(TextBox51, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox50.Focus()
        End If
    End Sub

    Private Sub TextBox50_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox50.KeyPress
        soloNumeros(TextBox50, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox43.Focus()
        End If
    End Sub

    Private Sub TextBox43_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox43.KeyPress
        soloNumeros(TextBox43, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox44.Focus()
        End If
    End Sub

    Private Sub TextBox44_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox44.KeyPress
        soloNumeros(TextBox44, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox45.Focus()
        End If
    End Sub

    Private Sub TextBox45_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox45.KeyPress
        soloNumeros(TextBox45, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox46.Focus()
        End If
    End Sub

    Private Sub TextBox46_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox46.KeyPress
        soloNumeros(TextBox46, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox47.Focus()
        End If
    End Sub

    Private Sub TextBox47_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox47.KeyPress
        soloNumeros(TextBox47, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox48.Focus()
        End If
    End Sub

    Private Sub TextBox48_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox48.KeyPress
        soloNumeros(TextBox48, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox48.Focus()
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
    Public Shared todos As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            If TextBox27.Text <> String.Empty Or TextBox29.Text <> String.Empty Or TextBox30.Text <> String.Empty Or TextBox25.Text <> String.Empty Or TextBox28.Text <> String.Empty Or TextBox26.Text <> String.Empty Or TextBox31.Text <> String.Empty Or TextBox33.Text <> String.Empty Or TextBox32.Text <> String.Empty Or TextBox1.Text <> String.Empty Then
                todos = True
            Else
                todos = False
                MsgBox("Por favor, introduzca todas las cargas de la viga", MsgBoxStyle.Exclamation, "Advertencia")
                GoTo Line0
            End If
        End If

        If ADCAS.LabelDiseño.Text <> "Conexión Arriostre-Enlace" Then
            If TextBox19.Text <> String.Empty Or TextBox20.Text <> String.Empty Or TextBox21.Text <> String.Empty Or TextBox22.Text <> String.Empty Or TextBox23.Text <> String.Empty Or TextBox24.Text <> String.Empty Then
                todos = True
            Else
                todos = False
                MsgBox("Por favor, introduzca todas las cargas que la viga transmite al nodo de la conexión.", MsgBoxStyle.Exclamation, "Advertencia")
                GoTo Line0
            End If
        End If

        If TextBox39.Text <> String.Empty Or TextBox41.Text <> String.Empty Or TextBox42.Text <> String.Empty Or TextBox37.Text <> String.Empty Or TextBox40.Text <> String.Empty Or TextBox38.Text <> String.Empty Or TextBox34.Text <> String.Empty Or TextBox36.Text <> String.Empty Or TextBox35.Text <> String.Empty Then
            todos = True
        Else
            todos = False
            MsgBox("Por favor, introduzca todas las cargas de la viga", MsgBoxStyle.Exclamation, "Advertencia")
            GoTo Line0
        End If

        If TextBox54.Text <> String.Empty Or TextBox56.Text <> String.Empty Or TextBox57.Text <> String.Empty Or TextBox52.Text <> String.Empty Or TextBox55.Text <> String.Empty Or TextBox53.Text <> String.Empty Or TextBox49.Text <> String.Empty Or TextBox51.Text <> String.Empty Or TextBox50.Text <> String.Empty Then
            todos = True
        Else
            todos = False
            MsgBox("Por favor, introduzca todas las cargas del arriostre", MsgBoxStyle.Exclamation, "Advertencia")
            GoTo Line0
        End If

        If TextBox43.Text <> String.Empty Or TextBox44.Text <> String.Empty Or TextBox45.Text <> String.Empty Or TextBox46.Text <> String.Empty Or TextBox47.Text <> String.Empty Or TextBox48.Text <> String.Empty Then
            todos = True
        Else
            todos = False
            MsgBox("Por favor, introduzca todas las cargas que el arriostre transmite al nodo de la conexión.", MsgBoxStyle.Exclamation, "Advertencia")
            GoTo Line0
        End If

        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            todos = False
            MsgBox("Por favor, especifique la condición de carga del arriostre.", MsgBoxStyle.Exclamation, "Advertencia")
            GoTo Line0
        End If

        'Viga a conectar, cargas controlantes en el miembro

        Dim Srr As Double

        Srr = 1.3

        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then

            Dim VLbm, VDbm, VQbm, PDbm, PLbm, PQbm, MDbm, MLbm, MQbm As Double

            VDbm = Val(TextBox27.Text)
            VLbm = Val(TextBox29.Text)
            VQbm = Val(TextBox30.Text)
            PDbm = Val(TextBox25.Text)
            PLbm = Val(TextBox28.Text)
            PQbm = Val(TextBox26.Text)
            MDbm = Val(TextBox31.Text)
            MLbm = Val(TextBox33.Text)
            MQbm = Val(TextBox32.Text)

            'Resistencias requeridas en la viga a conectar (controlantes)

            Dim VubmM, PubmM As Double

            VubmM = Math.Round(1.4 * Math.Abs(VDbm) + 0.5 * Math.Abs(VLbm) + 1.3 * Math.Abs(VQbm), 2)
            PubmM = Math.Round(1.4 * Math.Abs(PDbm) + 0.5 * Math.Abs(PLbm) + 1.3 * Math.Abs(PQbm), 2)

            Dim Py, Pc, Pr As Double
            Dim Vp, Mp As Double

            Py = Ab * Fyb
            Pc = Py
            Pr = PubmM

            '   Resistencias disponibles en la viga a conectar

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

            Srr = Math.Round(AdjStrgnth / VQbm, 2)

            ADCAS.Label971.Text = "in <= " + mínLnkLngth.ToString + " in"

        End If

        If ADCAS.LabelDiseño.Text <> "Conexión Arriostre-Enlace" Then
            'Viga a conectar, cargas transmitidas al nodo

            Dim VLbmN, VDbmN, VQbmN, PDbmN, PLbmN, PQbmN As Double

            VLbmN = Val(TextBox19.Text)
            VDbmN = Val(TextBox20.Text)
            VQbmN = Val(TextBox21.Text)
            PDbmN = Val(TextBox22.Text)
            PLbmN = Val(TextBox23.Text)
            PQbmN = Val(TextBox24.Text)

            '   cargas factoradas

            Vubm = Math.Round(1.4 * Math.Abs(VDbmN) + 0.5 * Math.Abs(VLbmN) + Srr * Math.Abs(VQbmN), 2)
            Pubm = Math.Round(1.4 * Math.Abs(PDbmN) + 0.5 * Math.Abs(PLbmN) + Srr * Math.Abs(PQbmN), 2)
        End If

        'Viga superior o inferior, cargas controlantes en el miembro

        Dim VLbm2, VDbm2, VQbm2, PDbm2, PLbm2, PQbm2, MDbm2, MLbm2, MQbm2 As Double

        VLbm2 = Val(TextBox39.Text)
        VDbm2 = Val(TextBox41.Text)
        VQbm2 = Val(TextBox42.Text)
        PDbm2 = Val(TextBox37.Text)
        PLbm2 = Val(TextBox40.Text)
        PQbm2 = Val(TextBox38.Text)
        MDbm2 = Val(TextBox34.Text)
        MLbm2 = Val(TextBox36.Text)
        MQbm2 = Val(TextBox35.Text)

        'Arriostre, cargas controlantes en el miembro

        Dim VLbr, VDbr, VQbr, PDbr, PLbr, PQbr, MDbr, MLbr, MQbr As Double

        VLbr = Val(TextBox54.Text)
        VDbr = Val(TextBox56.Text)
        VQbr = Val(TextBox57.Text)
        PDbr = Val(TextBox52.Text)
        PLbr = Val(TextBox55.Text)
        PQbr = Val(TextBox53.Text)
        MDbr = Val(TextBox49.Text)
        MLbr = Val(TextBox51.Text)
        MQbr = Val(TextBox50.Text)

        'Arriostre, cargas transmitidas al nodo

        Dim VLbrN, VDbrN, VQbrN, PDbrN, PLbrN, PQbrN As Double

        VLbrN = Val(TextBox43.Text)
        VDbrN = Val(TextBox44.Text)
        VQbrN = Val(TextBox45.Text)
        PDbrN = Val(TextBox46.Text)
        PLbrN = Val(TextBox47.Text)
        PQbrN = Val(TextBox48.Text)

        'Cálculo de las resistencias requeridas en la viga superior o inferior

        Dim VubmM2, PubmM2 As Double

        VubmM2 = 1.4 * Math.Abs(VDbm2) + 0.5 * Math.Abs(VLbm2) + 1.3 * Math.Abs(VQbm2)
        PubmM2 = 1.4 * Math.Abs(PDbm2) + 0.5 * Math.Abs(PLbm2) + 1.3 * Math.Abs(PQbm2)

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

        Dim Srr2 As Double

        Srr2 = Math.Round(AdjStrgnth2 / VQbm2, 2)

        'Resistencias requeridas en el nodo

        '   arriostre

        Vubr = Math.Round(1.4 * Math.Abs(VDbrN) + 0.5 * Math.Abs(VLbrN) + Srr2 * Math.Abs(VQbrN), 2)
        Pubr = Math.Round(1.4 * Math.Abs(PDbrN) + 0.5 * Math.Abs(PLbrN) + Srr2 * Math.Abs(PQbrN), 2)

        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Or ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Or ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
            ADCAS.Label971.Text = "in <= " + mínLnkLngth2.ToString + " in"
        Else
            ADCAS.Label970.Text = "in <= " + mínLnkLngth2.ToString + " in"
        End If

        If ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna Soldada EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Arriostre-Enlace" Then
            Mubr = Math.Round(1.4 * Math.Abs(MDbr) + 0.5 * Math.Abs(MLbr) + Srr2 * Math.Abs(MQbr), 2)
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Enlace"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna empernada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Empernada (EBF, Tope)"
        ElseIf ADCAS.LabelDiseño.Text = "Conexión Viga-Columna soldada Tope EBF" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión Arriostre-Viga/Columna Soldada (EBF, Tope)"
        End If

Line0:

        If todos = True Then
            Me.Close()
        End If

    End Sub

    Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox42.KeyPress
        soloNumeros(TextBox42, e)
        If Asc(e.KeyChar) = 13 Then
            TextBox37.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        soloNumeros(TextBox1, e)
        If Asc(e.KeyChar) = 13 Then
            TabControl1.SelectTab(1)
            TextBox39.Focus()
        End If
    End Sub
End Class