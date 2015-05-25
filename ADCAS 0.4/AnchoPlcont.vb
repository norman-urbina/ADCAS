Public Class AnchoPlcont
    Public Shared OpcSelecc As Integer
    Public Shared TextoAnchoPl As String
    Public Shared varError As Boolean

    Dim anchos As Secciones = Secciones.GetSingleton
    Dim Twcol, Bfcol, Bfbeam As Double

    Private Sub AnchoPlcont_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If varError = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub AnchoPlcont_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
            Select Case OpcSelecc
                Case 0
                    RadioButton1.Checked = True
                Case 1
                    RadioButton2.Checked = True
                Case 2
                    RadioButton3.Checked = True
                    TextBox1.Text = TextoAnchoPl
            End Select

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        PictureBox1.Image = My.Resources.PlcontCOMPLETA
        Label1.Visible = False
        TextBox1.ReadOnly = True
        Twcol = Val(anchos.TextBox14.Text)
        Bfcol = Val(anchos.TextBox12.Text)
        Dim anchoCOMPLETO As Double
        anchoCOMPLETO = (Bfcol / 2) - (Twcol / 2)
        TextBox1.Text = anchoCOMPLETO.ToString
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        PictureBox1.Image = My.Resources.PlcontALINEADAVIGA
        Label1.Visible = False
        TextBox1.ReadOnly = True
        Twcol = Val(anchos.TextBox14.Text)
        Bfbeam = Val(anchos.TextBox4.Text)
        Dim anchoVIGA As Double
        anchoVIGA = (Bfbeam / 2) - (Twcol / 2)
        TextBox1.Text = anchoVIGA.ToString
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        PictureBox1.Image = My.Resources.PlcontANCHOCUALQUIERA
        Label1.Visible = True
        Label1.Text = "Especifique un ancho mayor a la proyección del patín de la viga"
        TextBox1.ReadOnly = False
        TextBox1.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenAnchPl = True
        If RadioButton1.Checked = True Then
            OpcSelecc = 0
            varError = False
            If ADCAS.RadioButton9.Checked = True Then
                ADCAS.PictureBox7.Image = My.Resources.PlRecto
                ADCAS.Label232.Text = "Bisel Recto"
            Else
                ADCAS.PictureBox7.Image = My.Resources.PlCurvo
                ADCAS.Label232.Text = "0.5"" radio mín."
            End If
            GoTo Line7
        End If

        If RadioButton2.Checked = True Then
            OpcSelecc = 1
            varError = False
            If ADCAS.RadioButton9.Checked = True Then
                ADCAS.PictureBox7.Image = My.Resources.PrectaRED
                ADCAS.Label232.Text = "Bisel Recto"
            Else
                ADCAS.PictureBox7.Image = My.Resources.PcurvaRED
                ADCAS.Label232.Text = "0.5"" radio mín."
            End If
            GoTo Line7
        End If

        If RadioButton3.Checked = True Then
            Twcol = Val(anchos.TextBox14.Text)
            Bfcol = Val(anchos.TextBox12.Text)
            Bfbeam = Val(anchos.TextBox4.Text)
            Dim anchoVIGA As Double
            anchoVIGA = (Bfbeam / 2) - (Twcol / 2)
            Dim anchoCOL As Double
            anchoCOL = (Bfcol / 2) - (Twcol / 2)
            If Val(TextBox1.Text) < anchoVIGA Then
                MsgBox("El ancho propuesto es menor a la proyección del patín de la viga", MsgBoxStyle.Critical, "Error")
                varError = True
            End If
            If Val(TextBox1.Text) > anchoCOL Then
                MsgBox("El ancho propuesto supera el patín de la columna", MsgBoxStyle.Critical, "Error")
                varError = True
            End If
            If Val(TextBox1.Text) >= anchoVIGA And Val(TextBox1.Text) <= anchoCOL Then
                varError = False
                'Establecer la imagen
                If ADCAS.RadioButton9.Checked = True Then
                    ADCAS.PictureBox7.Image = My.Resources.PrectaRED
                    ADCAS.Label232.Text = "Bisel Recto"
                Else
                    ADCAS.PictureBox7.Image = My.Resources.PcurvaRED
                    ADCAS.Label232.Text = "0.5"" radio mín."
                End If
                OpcSelecc = 2
                TextoAnchoPl = TextBox1.Text

                '/////////////////////////////////////////
                'CALCULOS QUE DEPENDEN DEL ANCHO DE LA PL
Line7:
                If ADCAS.TextBox40.Text <> "" Then

                    Dim bplcont, wpatin As Double
                    bplcont = Val(TextBox1.Text)

                    wpatin = bplcont - Val(ADCAS.TextBox40.Text)
                    ADCAS.TextBox41.Text = wpatin.ToString

                    'Actualización del calculo de la soldadura en el alma
                    If ADCAS.TextBox47.Text <> "" Then
                        Dim dcol, tfc, twc As Double 'Todos son Datos de la Columna
                        Dim DeNuevoOtraInst As Secciones = Secciones.GetSingleton
                        dcol = Val(DeNuevoOtraInst.TextBox16.Text)
                        tfc = Val(DeNuevoOtraInst.TextBox13.Text)
                        twc = Val(DeNuevoOtraInst.TextBox14.Text)
                        Dim acerInst As Aceros = Aceros.GetSingleton
                        Dim dbViga As Double = Val(DeNuevoOtraInst.TextBox1.Text)
                        Dim tfbViga As Double = Val(DeNuevoOtraInst.TextBox6.Text)

                        'Calculo de la resistencia de la soldadura
                        'La menor entre a), b), c) y d)
                        Dim FyPLcont, Apf As Double
                        FyPLcont = Val(acerInst.TextBox9.Text) 'Fy de la placa de continuidad
                        'Apf=tp*Wplaca-patin
                        Apf = Val(ADCAS.TextBox43.Text) * Val(ADCAS.TextBox41.Text)

                        Dim Ra, Rb, Rc, Rd As Double 'cada caso de resistencia requerida considerado
                        Dim Apw, Mpe As Double

                        'Apw=tp*Wplaca-alma
                        Apw = Val(ADCAS.TextBox43.Text) * Val(ADCAS.TextBox44.Text)

                        'a) Calculo de Ra
                        If ADCAS.ComboBox1.SelectedItem = "2" Then
                            Ra = 2 * 0.9 * FyPLcont * Apf
                        Else
                            Ra = 0.9 * FyPLcont * Apf
                        End If

                        'b) Calculo de Rb
                        Rb = 0.6 * FyPLcont * Apw

                        'c) Calculo de Rc
                        'Hay que calcular la resistencia de la zona de panel nodal
                        Dim Rzpanel As Double
                        Dim EMf As Double
                        EMf = Mf + ADCAS.MfPrima
                        Dim Ru As Double            'Calculo de la resistencia requerida de la ZONA DE PANEL NODAL
                        If OpcionesDiseño.VcRUconsid = 1 Then
                            Dim Vcol, htop, hbot As Double
                            htop = AlturasEntrepiso.Hsup
                            hbot = AlturasEntrepiso.Hinf
                            Vcol = EMf / ((htop + hbot) * 12 / 2)
                            Ru = Math.Round(EMf / (dbViga - tfbViga) - Vcol)
                        Else
                            Ru = Math.Round(EMf / (dbViga - tfbViga))
                        End If


                        Dim Pu, Py As Double
                        Dim Fycolumna, Agcolumna As Double
                        Fycolumna = Val(acerInst.TextBox5.Text)
                        Agcolumna = Val(DeNuevoOtraInst.TextBox10.Text)

                        Pu = Val(ADCAS.TextBox4.Text)
                        Py = 0.75 * Fycolumna * Agcolumna   'IMPORTANTE: Py ya incluye el 0.75

                        'CALCULO DE LA RESISTENCIA DE DISEÑO DE LA ZONA DE PANEL

                        Dim Rn, coc As Double
                        'coc= cociente
                        coc = (3 * bcf * (tfc ^ 2)) / (dbViga * dcol * twc)
                        If Pu <= Py Then
                            Rn = Math.Round(0.6 * Fycolumna * dcol * twc * (1 + coc))
                        Else
                            Dim pivot As Double
                            pivot = (1.2 * Pu) / (Py / 0.75)
                            Rn = Math.Round(0.6 * Fycolumna * dcol * twc * (1 + coc) * (1.9 - pivot))
                        End If


                        If Ru > Rn Then 'Quiere decir que las placas nodales son necesarias
                            'Y es necesario determinar la Resistencia con el aporte de las
                            'Placas Nodales
                            Dim RpN As Double 'RpN= Resistencia nominal con placa(s) Nodal(es)
                            Dim Otrococ As Double
                            Dim tz As Double = twc + Val(ADCAS.TextBox52.Text) 'espesor total de la zona de panel incluyendo el refuerzo
                            Otrococ = (3 * bcf * (tfc ^ 2)) / (dbViga * dcol * tz)

                            If Pu <= Py Then
                                RpN = Math.Round(0.6 * Fycolumna * dcol * tz * (1 + Otrococ))
                            Else
                                Dim pivot As Double
                                pivot = (1.2 * Pu) / (Py / 0.75)
                                RpN = Math.Round(0.6 * Fycolumna * dcol * tz * (1 + Otrococ) * (1.9 - pivot))
                            End If

                            Rzpanel = RpN
                        Else
                            Rzpanel = Rn
                        End If

                        Rc = Rzpanel

                        'd) Calculo de Rd
                        Dim Fyb As Double = Val(acerInst.TextBox1.Text)
                        Dim Ryb As Double = Val(acerInst.TextBox3.Text)
                        Dim Zx As Double = Val(DeNuevoOtraInst.TextBox5.Text)
                        If ADCAS.ComboBox1.SelectedItem = "2" Then
                            Mpe = 2 * Fyb * Ryb * Zx
                        Else
                            Mpe = Fyb * Ryb * Zx
                        End If
                        Rd = Mpe / (dbViga - tfbViga)

                        Dim Rplcont As Double
                        Rplcont = Math.Round(Math.Min(Math.Min(Ra, Rb), Math.Min(Rc, Rd)))
                        ADCAS.TextBox49.Text = Rplcont.ToString

                        'Calculo del tamaño mínimo de soldadura de placa de continuidad
                        Dim Dmin As Double
                        Dmin = Math.Round(Rplcont / (2 * 1.392 * Val(ADCAS.TextBox44.Text)), 2)
                        ADCAS.TextBox47.Text = Dmin.ToString

                        'si la conexion es una conex. de tope
                        Dim DpTapa As Double
                        DpTapa = 2 * Dmin
                        ADCAS.TextBox72.Text = DpTapa.ToString

                        'Mandar dato a las Placas Nodales
                        'Tamaño de soldadura de la unión placa nodal-placa de continuidad (En caso de que las placa
                        '                                                                   nodal no sobrasale)
                        Dim soldPL_pl As Double
                        soldPL_pl = Math.Round(Val(ADCAS.TextBox47.Text) / 16, 3)

                        ADCAS.Label111.Text = "La placa nodal es soldada a las placas de continuidad con " & soldPL_pl & " in de soldadura de filete."

                        'Si ya se ha establecido en la Pestaña 'Zona de Panel nodal' que las placas nodales sobresalgan
                        If ADCAS.TextBox67.Text <> "" Then
                            'Entonces calcular el espesor adecuado
                            Dim tadec, wplac_alma As Double
                            wplac_alma = Val(ADCAS.TextBox44.Text)
                            tadec = Math.Round(Rplcont / (0.6 * FyPLcont * wplac_alma * 2), 3)
                            ADCAS.TextBox67.Text = tadec.ToString
                            If Val(ADCAS.TextBox68.Text) < tadec Then
                                ADCAS.TextBox68.BackColor = Color.Red
                            Else
                                ADCAS.TextBox68.BackColor = Color.WhiteSmoke
                            End If
                        End If
                    End If

                    'En el caso de una conexion BUEEP/BSEEP actualizar el cálculo del Asmin
                    If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida sin Rigidizar" Or ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida Rigidizada" Then

                        If ADCAS.TextBox164.Text <> "" Then
                            'Area del rigidizador
                            Dim Aspl, As_min, Apfred As Double
                            Dim FFu As Double = Val(ADCAS.TextBox149.Text)

                            Dim AlgunaInstMas As Aceros = Aceros.GetSingleton
                            Dim FyPLcont As Double = Val(AlgunaInstMas.TextBox9.Text)
                            Dim Apf As Double
                            Apf = Val(ADCAS.TextBox43.Text) * Val(ADCAS.TextBox41.Text)
                            As_min = Math.Round((FFu - ADCAS.RnPLcont) / (0.9 * FyPLcont), 3)
                            Apfred = Math.Round(Apf, 3)
                            Aspl = 2 * Apfred
                            ADCAS.TextBox164.Text = Aspl.ToString
                            ADCAS.Label289.Text = As_min.ToString + " in2"

                            If Aspl < As_min Then
                                ADCAS.TextBox164.BackColor = Color.Red
                            Else
                                ADCAS.TextBox164.BackColor = Color.WhiteSmoke
                            End If

                            'Soldadura minima de filete en el patin
                            Dim Soldmin As Double
                            Soldmin = Math.Round((FyPLcont * Apf) / (2 * 1.392 * Val(ADCAS.TextBox41.Text)), 2)
                            ADCAS.TextBox165.Text = Soldmin.ToString
                        End If
                    End If

                End If

            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        soloNumeros(Me.TextBox1, e)
        If Asc(e.KeyChar) = 13 Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Twcol = Val(anchos.TextBox14.Text)
        Bfcol = Val(anchos.TextBox12.Text)
        Bfbeam = Val(anchos.TextBox4.Text)
        Dim anchoVIGA As Double
        anchoVIGA = (Bfbeam / 2) - (Twcol / 2)
        Dim anchoCOL As Double
        anchoCOL = (Bfcol / 2) - (Twcol / 2)
        If TextBox1.Text <> "" Then
            If Val(TextBox1.Text) >= anchoVIGA And Val(TextBox1.Text) <= anchoCOL Then
                TextBox1.BackColor = Color.White
            Else
                TextBox1.BackColor = Color.Red
            End If
        End If

       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        varError = False
    End Sub
End Class