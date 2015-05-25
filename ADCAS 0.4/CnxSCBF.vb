Module CnxSCBF

    '=====>>CONEXIÓN ARRIOSTRE-PLACA
    'PROPIEDADES DEL ACERO
    Public Fybr, Fubr, Rybr, Rtbr, Fybr2, Fubr2, Rybr2, Rtbr2, Fyp, Fup, Ryp, Rtp, Fycn, Fucn, Rycn, Rtcn, Fyb, Fub, Ryb, Rtb, Fyc, Fuc, Ryc, Rtc As Double
    Public Fyb2, Fub2, Ryb2, Rtb2 As Double
    'GEOMETRÍA DE LOS PERFILES
    Public db, tbf, tbw, kbdes, kb1, bbf, rb, Ab, Tb, dc, tcf, kcdes, tcw, bcf, Tc, Agbr, tbrnom, tbrdes, rbr, Darr, Hbr, Bbr, Agbr2, tbrnom2, tbrdes2, rbr2, Darr2, Hbr2, Bbr2, Z, Z2 As Double
    Public db2, tbf2, tbw2, kbdes2, kb12, bbf2, rb2, Ab2, Tb2 As Double
    'REVISIÓN DE LA ALTA DUCTILIDAD DE LOS PERFILES
    Public MDBM, HDCL, HDBR, HDBR2 As Boolean
    'ÁNGULO, LONGITUD Y ESBELTEZ DEL ARRIOSTRE
    Public theta, theta2, thetac, thetac2, Lbr, Lbr2, k, klr, klr2 As Double
    Public thetai, thetai2, klr200, klr2002 As Boolean
    'TIPO DE MARCO
    'CARGAS EN EL MARCO
    Public Tu, Pu, Tu2, Pu2, Pupb, Pupb2, Ast1a, Ast1b, Ast2a, Ast2b, HBm1a, HBm1b, HBm2a, HBm2b, CortanteViga As Double
    Public OpenMode, RevMode As Boolean
    '========================================================================
    'GEOMETRÍA DE LA PLACA GUSSET                                        ====
    Public gWdth, gWdthi, gL, gLi, gDosT, gDosTi, gPhi, gPhii, gPhiprima, gPhiprimai, egW As Double
    Public Piv, Piv2 As Integer
    Public gLgusset, ga, gLpatín, gLAgusset, gLBgusset As Double        '====   
    Public giLgusset, gia, giLpatín, giLAgusset, giLBgusset As Double   '====
    Public gLw, giLw, gWtmr, giWtmr As Double                           '====
    Public bPS, tPS, LePS As Double                                     '====
    Public fnv, dbolt, lcmín As Double                                  '====
    Public Lwbr, Lwbr2 As Double                                        '====
    'ESPESOR MÍNIMO DE LA PLACA GUSSET                                  '====
    Public tmin, tmininf As Double                                      '====
    'ESPESOR DE LA PLACA GUSSET                                         '====
    Public gt, git As Double                                            '====
    Public t, tinf As Double                                            '====
    'ANCHO DE WITHMORE y ANCHO DE WITHMORE REDUCIDO POR PLACA GUSSET    '====
    Public Lwmr, gLwmr As Double                                        '====
    '2t y phi
    Public gdoste, gidoste, gsdoste, gsphi, giphi As Double
    'LONGITUD DE PANDEO PROMEDIO                                        '==== 
    Public Lpm As Double                                                '====
    '========================================================================
    'CARGAS EN LA VIGA
    Public CMBM, CLBM, LBM, RuBM, VBM, VBM2 As Double
    'RESITENCIA DISPONIBLE AL CORTANTE EN LA VIGA
    Public VnBM As Double
    Public CMb, CLb As Double
    'Pisos
    Public SHF, SHF2 As Double
    'COMBINACIÓN DE CARGAS EN LA VIGA
    Public Rub1, Rub2, Rub As Double
    
    'Cargas conexión viga-columna
    Public Hct, Hcp, Hc1, Hc2, Vbt, Vbp, Vb1, V, Vb2, Ru, DreqBC, DreqGB, DreqGC, DreqGB2, DreqGC2, alfab, betab, LwLA, LwLB, LwBW As Double
    Public alfabGS, betabGS, alfabGI, betabGI As Double
    'Cargas normal y cortante
    Public N, Sh As Double
    'Cargas requeridas PS
    Public RuGPS, RuBPS, RuPS As Double
    'Public Agv, Anv, Ang, Ant As Double
    Public Rnyl As Double
    Public Rngyl As Double
    Public Dmínreq As Double
    'Cargas en los miembros EBF
    Public Pubm, Vubm, Pubr, Vubr, Mubr As Double
    Public Pubm2, Vubm2 As Double
    'Indicador si es un arriostre inferior
    Public Inferior As Boolean
    'Longitudes mínimas de enlaces
    Public mínLnkLngth, mínLnkLngth2 As Double
    'Sobrerresistencia de los enlaces
    Public Srr, Srr2 As Double

    Public Sub ThetaRev(ByVal claro As Double, ByVal hpiso As Double, ByVal hpisoinf As Double)
        'Ángulo de los arriostres

        theta = Math.Atan(0.5 * claro / hpiso)
        theta2 = Math.Atan(0.5 * claro / hpisoinf)

        'Revisión del ángulo de los arriostres
        If theta < (Math.PI / 6) Or theta > (Math.PI / 3) Then
            thetai = True
        Else
            thetai = False
        End If

        If theta2 < (Math.PI / 6) Or theta2 > (Math.PI / 3) Then
            thetai2 = True
        Else
            thetai2 = False
        End If
    End Sub

    Public Sub KLrrev(ByVal claro As Double, ByVal hpiso As Double, ByVal hpisoinf As Double)

        If OpcionesDiseño.LthetaBr = 0 Then
            Lbr = Math.Round(Math.Sqrt(hpiso ^ 2 + (0.5 * claro) ^ 2) - db / 12 - dc / 24)
            Lbr2 = Math.Round(Math.Sqrt(hpisoinf ^ 2 + (0.5 * claro) ^ 2) - db / 12 - dc / 24)
        End If

        k = 1
        klr = Math.Round(k * Lbr * 12 / rbr, 2)
        If klr <= 200 Then
            klr200 = True
        Else
            klr200 = False
        End If

        klr2 = Math.Round(k * Lbr2 * 12 / rbr2, 2)
        If klr2 <= 200 Then
            klr2002 = True
        Else
            klr2002 = False
        End If

    End Sub
    Public Sub SoloNumFrac(ByVal Textbox As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "/" And Not Textbox.Text.IndexOf("/") Then
            e.Handled = True
        ElseIf e.KeyChar = "/" Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not Textbox.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
   
End Module
