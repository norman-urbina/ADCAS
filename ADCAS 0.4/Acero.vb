Public Class Aceros

    'SINGLETON
    Private Shared _Instancia As Aceros = Nothing


    'METODO CONSTRUCTOR UNICO PRIVADO
    Private Sub New()
        'AQUI INICIALIZA EL CODIGO
        InitializeComponent()

    End Sub

    Public Shared Function GetSingleton() As Aceros

        'inicializar el objeto si aún no se ha hecho
        If _Instancia Is Nothing OrElse _Instancia.IsDisposed Then
            _Instancia = New Aceros

        End If

        'retornar la instancia inicializada
        Return _Instancia

    End Function
    

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If TextBox9.Text <> "" Then

            ADCAS.TextBox8.Text = ComboBox1.SelectedValue.ToString
            ADCAS.TextBox7.Text = ComboBox2.SelectedValue.ToString
            ADCAS.TextBox9.Text = ComboBox3.SelectedValue.ToString
            ADCAS.TextBox103.Text = TextBox9.Text

            '____________________________
            'CALCULOS RBS
            '--------------------
            If ADCAS.LabelDiseño.Text = "Conexión de Momento con Sección de Viga Reducida" Then
                Me.Hide()
                ADCAS.labelStatusBar1.Text = "Diseño de conexión RBS" + " (" + ADCAS.LabelDiseño.Text + ")"
            End If

            '____________________________
            'CALCULOS BUEEP/BSEEP
            '--------------------
            If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida Rigidizada" Or ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida sin Rigidizar" Then
                'SI tsmin en ADCAS.BSEEP ya ha sido calculado, actualizar el calculo
                If ADCAS.LabelTsmin.Visible = True Then

                    'INSTANCIA PARA OBTENER twb
                    Dim Instwb As Secciones = Secciones.GetSingleton
                    Dim twb As Double = Val(Instwb.TextBox2.Text)

                    'CALCULO DE ESPESOR MINIMO PARA RIGIDIZADOR
                    Dim tsMin As Double
                    tsMin = Math.Round(twb * (Val(TextBox1.Text) / Val(ADCAS.TextBox103.Text)), 3)
                    ADCAS.LabelTsmin.Visible = True
                    ADCAS.LabelTsmin.Text = tsMin.ToString + " in"
                End If

                If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida sin Rigidizar" Then
                    ADCAS.labelStatusBar1.Text = "Diseño de conexión BUEEP" + " (" + ADCAS.LabelDiseño.Text + ")"
                End If
                If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa Extrema Extendida Rigidizada" Then
                    ADCAS.labelStatusBar1.Text = "Diseño de conexión BSEEP" + " (" + ADCAS.LabelDiseño.Text + ")"
                End If

                Me.Hide()
            End If

            '_____________________________
            'CALCULOS BFP
            '------------
            If ADCAS.LabelDiseño.Text = "Conexión de Momento con Placa de Patín Empernada" Then
                'Calculo del diametro MAXIMO (para prevenir la ruptura del patín de la viga)
                If ADCAS.TextBox1.Text <> "" Then
                    Dim InstPerfil As Secciones = Secciones.GetSingleton
                    Dim bfViga As Double = Val(InstPerfil.TextBox4.Text)
                    Dim Dmax, Ry, Fy, Rt, Fu As Double
                    Ry = Val(TextBox3.Text)
                    Fy = Val(TextBox1.Text)
                    Rt = Val(TextBox4.Text)
                    Fu = Val(TextBox2.Text)
                    Dim cociente, dbmax As Double
                    cociente = (Ry * Fy) / (Rt * Fu)

                    Dmax = ((bfViga / 2) * (1 - cociente)) - 1 / 8
                    dbmax = redondear(Dmax, 0.125)
                    Dim fracc As String = cFraccion(dbmax)
                    ADCAS.TextBox107.Text = Simplificar(fracc)

                    'Chekeo del diamtero escogido en el Combobox 7
                    Dim dperno As Double
                    dperno = Frac2Num(ADCAS.ComboBox7.Text)

                    If dbmax < dperno Then
                        ADCAS.ComboBox7.BackColor = Color.Red
                    Else
                        ADCAS.ComboBox7.BackColor = Color.White
                    End If
                End If

                If ADCAS.TextBox134.Text <> "" Then
                    Dim MprBFP, rn, n As Double
                    Dim InstPerf As Secciones = Secciones.GetSingleton

                    Dim Fyb As Double = Val(TextBox1.Text)
                    Dim Fub As Double = Val(TextBox2.Text)
                    Dim Zxb As Double = Val(InstPerf.TextBox5.Text)
                    Dim dbeam As Double = Val(InstPerf.TextBox1.Text)
                    Dim Ryb As Double = Val(TextBox3.Text)
                    Dim tfb As Double = Val(InstPerf.TextBox6.Text)
                    Dim Fup As Double = Val(TextBox11.Text)
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

                'CAMBIO EN EL PROGRESSBAR
                ADCAS.labelStatusBar1.Text = "Diseño de conexión BFP" + " (" + ADCAS.LabelDiseño.Text + ")"

                If ComboBox3.Text = "ASTM A36" Or ComboBox3.Text = "ASTM A572 Grado 50" Then
                    Me.Hide()
                    ADCAS.TextBox9.BackColor = Color.WhiteSmoke
                Else
                    MsgBox("Por favor seleccione un tipo de acero ASTM A36 o A572 Grado 50 para las placas.", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            End If

            '_____________________________
            'CALCULOS WUF-W
            '------------
            If ADCAS.LabelDiseño.Text = "Conexión de Momento con Patín Soldado sin refuerzo y Alma Soldada" Then
                ADCAS.labelStatusBar1.Text = "Diseño de conexión WUF-W" + " (" + ADCAS.LabelDiseño.Text + ")"
                Me.Hide()
            End If

            'CAMBIO EN EL TOOLTIP
            ADCAS.ToolTip1.SetToolTip(ADCAS.TextBox8, ComboBox1.SelectedValue.ToString)
            ADCAS.ToolTip1.SetToolTip(ADCAS.TextBox7, ComboBox2.SelectedValue.ToString)
            ADCAS.ToolTip1.SetToolTip(ADCAS.TextBox9, ComboBox3.SelectedValue.ToString)
        Else
            MsgBox("Por favor, seleccione un tipo de acero", MsgBoxStyle.Exclamation, "Advertencia")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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

    Private Sub Aceros_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub Aceros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''TODO: This line of code loads data into the 'AcerosDataSet.Acero_en_placasBFP' table. You can move, or remove it, as needed.
        'Me.Acero_en_placasBFPTableAdapter.Fill(Me.AcerosDataSet.Acero_en_placasBFP)
        'TODO: This line of code loads data into the 'AcerosDataSet.Acero_en_placas' table. You can move, or remove it, as needed.
        Me.Acero_en_placasTableAdapter.Fill(Me.AcerosDataSet.Acero_en_placas)
        'TODO: This line of code loads data into the 'AcerosDataSet.Acero_en_columnas' table. You can move, or remove it, as needed.
        Me.Acero_en_columnasTableAdapter.Fill(Me.AcerosDataSet.Acero_en_columnas)
        'TODO: This line of code loads data into the 'AcerosDataSet.Acero_en_vigas' table. You can move, or remove it, as needed.
        Me.Acero_en_vigasTableAdapter.Fill(Me.AcerosDataSet.Acero_en_vigas)

        'llenaCombo()
    End Sub

    'Public Sub llenaCombo()

    '    Me.ComboBox3.DataSource = Me.AceroEnPlacasBindingSource
    '    Me.ComboBox3.DisplayMember = "Acero"
    '    Me.ComboBox3.ValueMember = "Acero"
    '    Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AceroEnPlacasBindingSource, "Fy", True))
    '    Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AceroEnPlacasBindingSource, "Fu", True))
    '    Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AceroEnPlacasBindingSource, "Ry", True))
    '    Me.TextBox12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AceroEnPlacasBindingSource, "Rt", True))

    'End Sub

End Class