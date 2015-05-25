Public Class Secciones

    'SINGLETON
    Private Shared _EstaInstancia As Secciones = Nothing


    'METODO CONSTRUCTOR UNICO PRIVADO
    Private Sub New()
        'AQUI INICIALIZA EL CODIGO
        InitializeComponent()

    End Sub

    Public Shared Function GetSingleton() As Secciones

        'inicializar el objeto si aún no se ha hecho
        If _EstaInstancia Is Nothing OrElse _EstaInstancia.IsDisposed Then
            _EstaInstancia = New Secciones

        End If

        'retornar la instancia inicializada
        Return _EstaInstancia

    End Function


    Private Sub PictureBox8_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If Val(TextBox4.Text) <= Val(TextBox12.Text) Then 'Se asegura que el ancho del patin de la columna sea mayor o igual al de la viga conectada
            Me.Hide()

            ADCAS.TextBox2.Text = ComboBox1.SelectedValue.ToString
            ADCAS.TextBox1.Text = ComboBox2.SelectedValue.ToString

            Dim tbf As Double = Double.Parse(TextBox6.Text)
            Dim bf As Double = Val(TextBox4.Text)


            '--------------------------
            'CALCULO EN RBS
            '--------------------------
            If ADCAS.LabelDiseño.Text = "Conexión de Momento con Sección de Viga Reducida" Then
                'CALCULO DE LAS DIMENSIONES DE CORTE DE LA SECCION REDUCIDA
                Dim a1, a2 As Double
                a1 = Math.Round(0.5 * Double.Parse(TextBox4.Text), 2)
                a2 = Math.Round(0.75 * Double.Parse(TextBox4.Text), 2)

                ADCAS.TextBox26.Text = a1.ToString
                ADCAS.TextBox24.Text = a2.ToString

                Dim b1, b2 As Double
                b1 = Math.Round(0.65 * Double.Parse(TextBox1.Text), 2)
                b2 = Math.Round(0.85 * Double.Parse(TextBox1.Text), 2)

                ADCAS.TextBox23.Text = b1.ToString
                ADCAS.TextBox22.Text = b2.ToString

                Dim c1, c2 As Double
                c1 = Math.Round(0.1 * Double.Parse(TextBox4.Text), 2)
                c2 = Math.Round(0.25 * Double.Parse(TextBox4.Text), 2)

                ADCAS.TextBox20.Text = c1.ToString
                ADCAS.TextBox19.Text = c2.ToString

                'si ya se han introducido valores para a,b y c
                'VERIFICAR que esten bien
                If ADCAS.TextBox27.Text <> "" Then  'comprobacion de "a"
                    If Val(ADCAS.TextBox27.Text) < a1 Or Val(ADCAS.TextBox27.Text) > a2 Then
                        ADCAS.TextBox27.BackColor = Color.Red
                    Else
                        ADCAS.TextBox27.BackColor = Color.White
                    End If
                End If
                If ADCAS.TextBox25.Text <> "" Then  'comprobacion de "b"
                    If Val(ADCAS.TextBox25.Text) < b1 Or Val(ADCAS.TextBox25.Text) > b2 Then
                        ADCAS.TextBox25.BackColor = Color.Red
                    Else
                        ADCAS.TextBox25.BackColor = Color.White
                    End If
                End If
                If ADCAS.TextBox21.Text <> "" Then  'comprobacion de "a"
                    If Val(ADCAS.TextBox21.Text) < c1 Or Val(ADCAS.TextBox21.Text) > c2 Then
                        ADCAS.TextBox21.BackColor = Color.Red
                    Else
                        ADCAS.TextBox21.BackColor = Color.White
                    End If
                End If

                'CAMBIO EN EL PROGRESSBAR
                ADCAS.labelStatusBar1.Text = "Diseño de conexión RBS" + " (" + ADCAS.LabelDiseño.Text + ")"
            End If

            '--------------------------
            'CALCULO EN WUF-W
            '--------------------------
            If ADCAS.LabelDiseño.Text = "Conexión de Momento con Patín Soldado sin refuerzo y Alma Soldada" Then
                'CALCULO DE LA GEOMETRIA EN AGUJERO DE ACCESO WUF-W
                Dim aWUF, bWUF, dWUF, amenos, amas As Double

                aWUF = Math.Max(tbf, 0.5)
                ADCAS.TextBox81.Text = aWUF

                amenos = 0.25 * tbf
                amas = 0.5 * tbf
                ADCAS.Lblmas_a.Text = "(Menos " & amenos & " in, Más " & amas & " in)"

                Dim bmin As Double
                bmin = 0.75 * tbf
                bWUF = Math.Max(bmin, 0.75)
                ADCAS.TextBox79.Text = bWUF
                If tbf >= 0.75 Then
                    ADCAS.Lblmas_b.Text = "Valor máximo es tbf= " & tbf & " in. (Menos 1/4 in, Más 1/4 in)"
                Else
                    ADCAS.Lblmas_b.Text = "(Menos 1/4 in, Más 1/4 in)"
                End If

                ADCAS.TextBox75.Text = 3 / 8

                dWUF = 3 * tbf
                ADCAS.TextBox82.Text = dWUF

                'Espesor mínimi de placa simple (Igual al grosor del alma de la viga)
                ADCAS.Label329.Text = TextBox2.Text + " in"

                'CAMBIO EN EL PROGRESSBAR
                ADCAS.labelStatusBar1.Text = "Diseño de conexión WUF-W" + " (" + ADCAS.LabelDiseño.Text + ")"
            End If

            '--------------------------
            'CALCULOS EN BUEEP Y BSEPP
            '--------------------------
            If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida sin Rigidizar" Or ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida Rigidizada" Then

                'SI tsmin en ADCAS.BSEEP ya ha sido calculado, actualizar el calculo
                If ADCAS.LabelTsmin.Visible = True Then

                    'INSTANCIA PARA OBTENER Fyb
                    Dim InstFyb As Aceros = Aceros.GetSingleton
                    Dim Fyb As Double = Val(InstFyb.TextBox1.Text)

                    'CALCULO DE ESPESOR MINIMO PARA RIGIDIZADOR
                    Dim tsMin As Double
                    tsMin = Math.Round(Double.Parse(TextBox2.Text) * (Fyb / Val(ADCAS.TextBox103.Text)), 3)
                    ADCAS.LabelTsmin.Visible = True
                    ADCAS.LabelTsmin.Text = tsMin.ToString + " in"
                End If

                'Si 'bp, g y de' ya han sido introducidos, verificar los limites que dependen de la seccion elegida
                'g
                If ADCAS.TextBox90.Text <> "" Then  'chekeo del gramil g

                    'LIM DE PRECALIFICACION PARA EL GRAMIL EN DEPENDENCIA DE SI ES 4E, 4ES y/o 8ES
                    Dim gmin As String
                    Dim gmax As String
                    If ADCAS.ComboBox3.Visible = True Then
                        If ADCAS.ComboBox3.SelectedItem = "4ES" Then
                            gmin = Strings.Mid(ADCAS.Label150.Text, 17, 4)    'para 4ES
                            gmax = Strings.Mid(ADCAS.Label150.Text, 24, 1)
                        Else
                            gmin = Strings.Mid(ADCAS.Label150.Text, 17, 1)    'para 8ES
                            gmax = Strings.Mid(ADCAS.Label150.Text, 21, 1)
                        End If
                    Else
                        gmin = "4"    'para 4E
                        gmax = "6"
                    End If

                    'VER QUE LIMITE ES MAS CRITICO PARA EVALUAR DATO
                    Dim limmax As Double

                    limmax = Math.Min(bf, Val(gmax))

                    If Val(ADCAS.TextBox90.Text) < gmin Or Val(ADCAS.TextBox90.Text) > limmax Then
                        ADCAS.TextBox90.BackColor = Color.Red
                    Else
                        ADCAS.TextBox90.BackColor = Color.White
                    End If
                End If

                'bp
                If ADCAS.TextBox88.Text <> "" Then

                    'LIM DE PRECALIFICACION PARA EL bp (ancho de la placa de extremo) EN DEPENDENCIA DE SI ES 4E, 4ES y/o 8ES
                    Dim bpinf, bpsup As String
                    bpinf = Strings.Mid(ADCAS.Label149.Text, 17, 1)
                    bpsup = Strings.Mid(ADCAS.Label149.Text, 21)
                    Dim bpmax = 1 + bf

                    'VER QUE LIMITE ES MAS CRITICO PARA EVALUAR DATO
                    Dim limmax2 As Double
                    limmax2 = Math.Min(bpmax, Val(bpsup))   'valor máximo

                    'chekeo del ancho de la placa extrema bp
                    If Val(ADCAS.TextBox88.Text) < bpinf Or Val(ADCAS.TextBox88.Text) > limmax2 Then
                        ADCAS.TextBox88.BackColor = Color.Red
                    Else
                        ADCAS.TextBox88.BackColor = Color.White
                    End If
                End If

                'de 
                If ADCAS.TextBox98.Text <> "" Then
                    'verificacion de de, ya que el limite superior depende del espesor del alma de la columna
                    Dim tfc As Double = Val(TextBox13.Text)
                    consultaPernos1(ADCAS.ComboBox5.Text)
                    Dim d1 As Double = Math.Min(Val(ADCAS.TextBox96.Text), tfc)
                    Dim demax As Double = Math.Min(12 * d1, 6)

                    If Val(ADCAS.TextBox98.Text) < demin Or Val(ADCAS.TextBox98.Text) > demax Then
                        ADCAS.TextBox98.BackColor = Color.Red
                    Else
                        ADCAS.TextBox98.BackColor = Color.White
                    End If

                End If


                If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida sin Rigidizar" Then
                    'CAMBIO EN EL PROGRESSBAR
                    ADCAS.labelStatusBar1.Text = "Diseño de conexión BUEEP" + " (" + ADCAS.LabelDiseño.Text + ")"
                End If
                If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida Rigidizada" Then
                    'CAMBIO EN EL PROGRESSBAR
                    ADCAS.labelStatusBar1.Text = "Diseño de conexión BSEEP" + " (" + ADCAS.LabelDiseño.Text + ")"
                End If
            End If

            '--------------------------
            'CALCULOS EN BFP-----------
            '--------------------------
            If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa de Patín Empernada" Then

                'Calculo del diametro MAXIMO (para prevenir la ruptura del patín de la viga)
                If ADCAS.TextBox8.Text <> "" Then
                    Dim InstMaterial As Aceros = Aceros.GetSingleton
                    Dim Dmax, Ry, Fy, Rt, Fu As Double
                    Ry = Val(InstMaterial.TextBox3.Text)
                    Fy = Val(InstMaterial.TextBox1.Text)
                    Rt = Val(InstMaterial.TextBox4.Text)
                    Fu = Val(InstMaterial.TextBox2.Text)
                    Dim cociente, dbmax As Double
                    cociente = (Ry * Fy) / (Rt * Fu)

                    Dmax = ((bf / 2) * (1 - cociente)) - 1 / 8
                    dbmax = redondear(Dmax, 0.125)
                    'Dim fracc As String = cFraccion(dbmax)
                    ADCAS.TextBox107.Text = dbmax.ToString

                    'Chekeo del diamtero escogido en el Combobox 7
                    Dim dperno As Double
                    dperno = Frac2Num(ADCAS.ComboBox7.Text)

                    If dbmax < dperno Then
                        ADCAS.ComboBox7.BackColor = Color.Red
                    Else
                        ADCAS.ComboBox7.BackColor = Color.White
                    End If
                End If

                'Actualización del gramil al cambiar la sección de la viga
                If ADCAS.TextBox113.Text <> "" Then
                    Dim G As Double
                    G = bf - (2 * Val(ADCAS.TextBox111.Text))
                    ADCAS.TextBox113.Text = G.ToString

                    'Ya que el gramil se actualiza, es necesario verificar nuevamente si cumple con el esp. min
                    If G < Val(ADCAS.TextBox114.Text) Then  'gramil debe ser mayor al espaciamiento mínimo de 2 2/3*db
                        ADCAS.TextBox114.BackColor = Color.Red
                    Else
                        ADCAS.TextBox114.BackColor = Color.WhiteSmoke
                    End If

                End If

                'Actualizacion del valor de Lemax al elegir una nueva sección
                Dim Lemax As Double
                Lemax = Math.Min((12 * tbf), 6)   'Lemax en el patín de la viga
                ADCAS.TextBox109.Text = Lemax.ToString

                If ADCAS.TextBox111.Text <> "" Or ADCAS.TextBox110.Text <> "" Then
                    'Si la dist.max al borde cambia, chekear Leh y Lev 
                    If Val(ADCAS.TextBox111.Text) < Val(ADCAS.TextBox108.Text) Or Val(ADCAS.TextBox111.Text) > Lemax Then  'Leh
                        ADCAS.TextBox111.BackColor = Color.Red
                    Else
                        ADCAS.TextBox111.BackColor = Color.White
                    End If

                    If Val(ADCAS.TextBox110.Text) < Val(ADCAS.TextBox108.Text) Or Val(ADCAS.TextBox110.Text) > Lemax Then  'Lev
                        ADCAS.TextBox110.BackColor = Color.Red
                    Else
                        ADCAS.TextBox110.BackColor = Color.White
                    End If

                End If

                'Actualizacion de 'CALCULO DE Mpr, la fuerza cortante nominal d/c perno
                'para determinar el número de pernos a seleccionar
                If ADCAS.TextBox134.Text <> "" Then
                    'Esto asegura que ya se haya seleccionado las seeciones y el material
                    Dim MprBFP, rn, n As Double
                    Dim InsMat As Aceros = Aceros.GetSingleton

                    Dim Fyb As Double = Val(InsMat.TextBox1.Text)
                    Dim Fub As Double = Val(InsMat.TextBox2.Text)
                    Dim Zxb As Double = Val(TextBox5.Text)
                    Dim dbeam As Double = Val(TextBox1.Text)
                    Dim Ryb As Double = Val(InsMat.TextBox3.Text)
                    Dim tfb As Double = Val(TextBox6.Text)
                    Dim Fup As Double = Val(InsMat.TextBox11.Text)
                    Dim tp As Double = Val(ADCAS.TextBox118.Text)

                    Dim Cpr As Double
                    Cpr = (Fyb + Fub) / (2 * Fyb)
                    Dim Momento As Double
                    Momento = Cpr * Zxb * Ryb * Fyb
                    MprBFP = redondear(Momento, 10)

                    Dim Ab, db As Double
                    db = Frac2Num(ADCAS.ComboBox7.Text)
                    Ab = Math.PI * (db ^ 2) / 4

                    Dim rn1, rn2, rn3 As Double
                    rn1 = 84 * Ab
                    rn2 = 2.4 * Fub * db * tfb
                    rn3 = 2.4 * Fup * db * tp

                    rn = Math.Min(Math.Min(rn1, rn2), rn3)
                    rnPernos = rn

                    n = Math.Floor(1.25 * MprBFP / (0.9 * rn * (dbeam + tp))) + 1
                    'Es necesario redondear 'n' al siguiente número par superior
                    If n Mod 2 = 0 Then
                        n = n
                    Else
                        n = n + 1
                    End If

                    ADCAS.TextBox134.Text = n.ToString
                End If

                'Actualizacion del valor de smax (que depende del espesor del patin de la viga 'tfbeam')
                If ADCAS.TextBox129.Text <> "" Then
                    Dim min1 As Double = Math.Min(Val(ADCAS.TextBox118.Text), tbf)
                    Dim smax As Double = Math.Min(24 * min1, 12)
                    ADCAS.TextBox129.Text = smax.ToString

                    'chekeo de s, ya que se ha modificado smax
                    If ADCAS.TextBox130.Text <> "" Then
                        If Val(ADCAS.TextBox130.Text) < Val(ADCAS.TextBox131.Text) Or Val(ADCAS.TextBox130.Text) > smax Then
                            ADCAS.TextBox130.BackColor = Color.Red
                        Else
                            ADCAS.TextBox130.BackColor = Color.WhiteSmoke
                        End If
                    End If
                End If

                'CAMBIO EN EL PROGRESSBAR
                ADCAS.labelStatusBar1.Text = "Diseño de conexión BFP" + " (" + ADCAS.LabelDiseño.Text + ")"
            End If
        Else
            MsgBox("El patin de la viga conectada es mayor que el patín de la columna. Por favor elija otras secciones.", MsgBoxStyle.Exclamation, "Advertencia")

        End If

    End Sub

     

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Hide()

        'CAMBIO EN EL PROGRESSBAR
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Sección de Viga Reducida" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión RBS" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Patín Soldado sin refuerzo y Alma Soldada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión WUF-W" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida sin Rigidizar" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión BUEEP" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida Rigidizada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión BSEEP" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa de Patín Empernada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión BFP" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If


    End Sub

    Private Sub Secciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Secciones_WDataSet.SeccW1' table. You can move, or remove it, as needed.
        Me.SeccW1TableAdapter.Fill(Me.Secciones_WDataSet.SeccW1)
        'TODO: This line of code loads data into the 'Secciones_WDataSet.SeccW' table. You can move, or remove it, as needed.
        Me.SeccWTableAdapter.Fill(Me.Secciones_WDataSet.SeccW)

    End Sub

    Private Sub Secciones_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()

        'CAMBIO EN EL PROGRESSBAR
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Sección de Viga Reducida" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión RBS" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Patín Soldado sin refuerzo y Alma Soldada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión WUF-W" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida sin Rigidizar" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión BUEEP" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida Rigidizada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión BSEEP" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
        If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa de Patín Empernada" Then
            ADCAS.labelStatusBar1.Text = "Diseño de conexión BFP" + " (" + ADCAS.LabelDiseño.Text + ")"
        End If
    End Sub

End Class

