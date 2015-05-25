Module CalculosDiseno
    Public cpr As Double
    Public Mpr As Double
    Public Vh, VhPrima As Double
    Public Mf, Mg As Double
    Public SumMpc As Double
    Public SumMpb As Double
    Public rnPernos As Double 'resistencia usada para calcular el No. de pernos en conex. BFP
    Public OpenAnchPl As Boolean 'variable para controlar el ancho de la Pl de continuidad

    'SoloNUMEROS
    Public Sub soloNumeros(ByVal CajaTexto As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'SoloEnteros
    Public Sub soloEntero(ByVal a As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(a.KeyChar) Then
            a.Handled = False
        ElseIf Char.IsControl(a.KeyChar) Then
            a.Handled = False
        Else
            a.Handled = True
        End If
    End Sub

    'Numeros con signo menos
    Public Sub NumMenos(ByVal TextoBox As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "-" And Not TextoBox.Text.IndexOf("-") Then
            e.Handled = True
        ElseIf e.KeyChar = "-" Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not TextoBox.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'Procedimiento para forzar el signo menos únicamente al inicio
    Public Sub SignoMenos(ByVal cadenaTexto As String, ByVal FocoActual As Windows.Forms.TextBox, ByVal FocoSig As Windows.Forms.TextBox)
        Dim Pos As Integer
        Pos = Strings.InStr(cadenaTexto, "-")
        If Pos = 1 Or Pos = 0 Then
            'MsgBox(Pos.ToString + Valor.ToString)
            FocoSig.Focus()
        Else
            MsgBox("Valor no reconocido. Coloque el signo menos al inicio", MsgBoxStyle.Critical, "Valor no válido")
            FocoActual.Text = ""
            FocoActual.Focus()
        End If

    End Sub

    'Funcion para redondear a un multiplo especifico
    Public Function redondear(ByVal numero As Double, ByVal multiplo As Double) As Double

        'Dividir el numero entre el multiplo
        Dim divid As Double
        divid = numero / multiplo

        'redondear el resultado
        Dim res As Double
        res = Math.Round(divid)

        'multiplicar el resultado redondeado por el multiplo
        Dim Redondeo As Double
        Redondeo = res * multiplo

        Return Redondeo

    End Function

    'Funcion para convertir fracciones (string) a decimales
    Function Frac2Num(ByVal X As String) As Double

        Dim P As Integer, N As Double, Num As Double, Den As Double
        X = Strings.Trim(X)
        P = Strings.InStr(X, "/")
        If P = 0 Then
            N = Val(X)
        Else
            Try
                Den = Val(Strings.Mid(X, P + 1))
                If Den = 0 Then Error 11 ' Divide by zero
                X = Strings.Trim(Strings.Left(X, P - 1))
                P = Strings.InStr(X, " ")
                If P = 0 Then
                    Num = Val(X)
                Else
                    Num = Val(Strings.Mid(X, P + 1))
                    N = Val(Strings.Left(X, P - 1))
                End If
            Catch ex As Exception
                MsgBox("Error al digitar fracción", MsgBoxStyle.Critical, "Valor no válido")
            End Try
        End If
        If Den <> 0 Then
            N = N + Num / Den
        End If
        Frac2Num = N

    End Function

    'Funcion para convertir decimales a Fraccion
    Function cFraccion(Rac As Double) 'Rac: Racional
        Dim sRac As String 'la cadena que contiene a Rac
        Dim Numero As Double 'Numero decimal a simplificar
        Dim entero As String = "" 'Parte entera de una fraccion mixta
        Dim dec As String 'Resto de decimales después del punto
        Dim Num As Long 'Numerador
        Dim Den As Long 'Denominador
        Dim nDec As Integer
        sRac = Rac.ToString 'Convierte en cadena
        nDec = 0 'cifras decinamales a cero por defecto

        If Strings.InStr(1, sRac, ".") <> 0 Then 'Observa si tiene el punto decimal
            nDec = Strings.Len(Strings.Mid(sRac, Strings.InStr(1, sRac, ".") + 1)) 'Cuenta el Numero de Decimales
            'si rac es mayor a 1 (1.125 por ejem) expresar en fraccion mixta
            If Rac > 1 Then
                entero = Strings.Left(sRac, Strings.InStr(1, sRac, ".") - 1)
                dec = "0." + Strings.Mid(sRac, Strings.InStr(1, sRac, ".") + 1)
                Numero = Val(dec)
            Else
                Numero = Rac
            End If
        Else
            'Quiere decir que el numero es un entero (1 por ejemplo)
            Numero = Rac
        End If

        Num = Numero * (10 ^ nDec)
        Den = 10 ^ nDec

        If entero = "" Then
            If nDec = 0 Then
                cFraccion = Num / Den
            Else
                cFraccion = Num & "/" & Den
            End If
        Else
            cFraccion = entero & " " & Num & "/" & Den
        End If


    End Function
    'simplificar la fraccion
    Function Simplificar(ByVal Fraccion As String)
        Dim Aux, A, B As Long
        Dim Den, Num As Long
        Dim MCD, P As Integer
        Dim examinador As Integer 'verifica si el dato recibido es una fraccion o un entero
        Dim recorte As String
        Dim N As String = " "

        examinador = Strings.InStr(Fraccion, "/")
        If examinador <> 0 Then 'ejecutará el resto de la Función

            P = Strings.InStr(Fraccion, " ")
            'Recorta y obtiene el Numerador y Denominador
            If P <> 0 Then
                recorte = Strings.Left(Fraccion, Strings.InStr(1, Fraccion, "/") - 1)
                Num = Val(Strings.Mid(recorte, P + 1))
                N = Strings.Left(recorte, P - 1)
            Else
                Num = Val(Strings.Mid(Fraccion, 1, Strings.InStr(1, Fraccion, "/") - 1))
            End If
            Den = Val(Strings.Mid(Fraccion, Strings.InStr(1, Fraccion, "/") + 1))
            A = Num
            B = Den
            If Num = 0 Or Den = 0 Then Simplificar = "0" : Exit Function

            '#############   Busca el Maximo Comun Divisor - Algoritmo de euclides para hacerlo...
            While (B <> 0)
                Aux = A Mod B
                A = B
                B = Aux
            End While
            '############

            MCD = A 'Asigna el Valor del Maximo C. D
            Simplificar = N & " " & Num / MCD & "/" & Den / MCD  'Divide el Num y Den por el MCD, y lo convierte en cadena

        Else 'esto quiere decir que se trata de un entero el cual no hay que simplificar
            Simplificar = Fraccion
        End If

    End Function

    'Calculo de Mpr
    'Cpr
    Public Sub CalcularCpr(ByRef Fy As Double, ByRef Fu As Double)

        cpr = (Fy + Fu) / (2 * Fy)

    End Sub

    'Mpr
    Public Sub CalcMpr(ByRef c_pr As Double, ByRef Zx As Double, ByRef Ry As Double, ByRef Fybeam As Double)
        Dim Momento As Double
        Momento = c_pr * Zx * Ry * Fybeam
        Mpr = redondear(Momento, 10)
    End Sub

    'Calculo de Vh (Vrbs en conex. RBS) 
    Public Sub CortanteVh(ByRef Mplastico As Double, ByRef Lh As Double, ByRef CargaGravitWu As Double)
        'Lh en pulgadas

        Vh = Math.Round((2 * Mplastico / Lh) + (CargaGravitWu * Lh / 24), 2)
        VhPrima = Math.Round((2 * Mplastico / Lh) - (CargaGravitWu * Lh / 24), 2)
    End Sub

    'Calculo de Mg
    'Mg
    Public Sub Mgravedad(ByRef CargaWu As Double, ByRef DistSh As Double)
        Mg = 0.5 * CargaWu / 12 * (DistSh ^ 2)
    End Sub

    'Calculo de Mf
    'Mf 
    Public Sub MomentoMf(ByRef Mp As Double, ByRef Vpr As Double, ByRef Sh As Double)
        'Sh en pulgadas
        Dim Mcaracol As Double
        If OpcionesDiseño.Mgconsid = 1 Then
            Mcaracol = Mp + (Vpr * Sh) + Mg
        Else
            Mcaracol = Mp + (Vpr * Sh)
        End If

        Mf = redondear(Mcaracol, 10)
    End Sub
    'M'f
    Public Function Mfdos(ByRef Mom As Double, ByRef VhPrima As Double, ByRef sh As Double)
        'sh en pulgadas
        Dim Mcol2 As Double
        If OpcionesDiseño.Mgconsid = 1 Then
            Mcol2 = redondear(Mom + (VhPrima * sh) - Mg, 10)
        Else
            Mcol2 = redondear(Mom + (VhPrima * sh), 10)
        End If

        Return Mcol2

    End Function

    'Calculo de RELACION VIGA-COLUMNA
    'Sumatoria de Momentos en la Columna "EMpc"
    Public Sub EMpc(ByRef Zc As Double, ByRef Fyc As Double, ByRef Puc As Double, ByRef Ag As Double, ByRef d_beam As Double)
        'Si la conexion es la conexion es de un piso intermedio
        '(dos columnas)entonces combobox2=No
        Dim Mpc As Double
        Dim Mplasnom As Double = Zc * (Fyc - Puc / Ag)
        Dim Vcsup, Vcinf As Double
        Dim htop, hbot As Double
        htop = AlturasEntrepiso.Hsup * 12
        hbot = AlturasEntrepiso.Hinf * 12

        If ADCAS.ComboBox2.SelectedItem = "No" Then
            Select Case OpcionesDiseño.VcMpcconsid
                Case 0
                    Mpc = 2 * Mplasnom
                Case 1
                    Vcsup = htop / (htop - d_beam)
                    Vcinf = (hbot) / (hbot - d_beam)
                    Mpc = Mplasnom * (Vcsup + Vcinf)
            End Select
        Else
            'la conexion es una conexion de extremo
            '(una columna)
            Select Case OpcionesDiseño.VcMpcconsid
                Case 0
                    Mpc = Mplasnom
                Case 1
                    Vcinf = (hbot / 2 + d_beam / 2) / (hbot / 2)
                    Mpc = Mplasnom * Vcsup
            End Select
        End If

        SumMpc = redondear(Mpc, 100)
    End Sub
    'Sumatoria de Momentos en la Viga "EMpb"
    Public Sub EMpb(ByRef Momentopr As Double, ByRef Vp As Double, ByRef Vp_prima As Double, ByRef Shpr As Double, ByRef peralte_col As Double)
        'Calculo Mv
        Dim Mv, EMv, Mpb As Double
        If ADCAS.ComboBox1.SelectedItem = "2" Then  'Dos vigas IDENTICAS conectadas
            Mv = (Vp + Vp_prima) * (Shpr + peralte_col / 2)
            EMv = redondear(Mv, 10)
            Mpb = (2 * Momentopr) + EMv
        Else    'Solo una viga conectada
            Mv = (Vp) * (Shpr + peralte_col / 2)
            EMv = redondear(Mv, 100)
            Mpb = (Momentopr) + EMv
        End If

        SumMpb = redondear(Mpb, 100)
    End Sub
End Module
