Public Class OpcionesDiseño
    Public Shared Mgconsid As Integer 'Momento de gravedad se calculará en el tramo de viga entre la cara de la columna y la articulación plástica
    Public Shared Vcconsid As Integer 'El cortante en la columna se considerará
    Public Shared BfredRBS As Integer 'Considera la reducción del patín para el cálculo de la relación ancho-espesor en conexiones RBS
    Public Shared VcMpcconsid As Integer 'El cortante se considerará para calcular el Momento Mpc en la relación de momentos, asumiendo puntos de inflexion a la mitad del entrepiso
    Public Shared VcRUconsid As Integer  'El cortante se considerará para calcular la Resistencia requerida a cortante de la zona de panel nodal, reduciendo la demanda.
    Public Shared CompConsid As Integer 'Considera si se usa en conjunto con otros marcos
    Public Shared MomInd As Integer 'Induce momento en las conexiones de la placa gusset
    Public Shared LthetaBr As Integer 'Calcula altura de piso y claro de viga
    Public Loaded As Boolean
    Private Sub OpcionesDiseño_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Mgconsid = 1 Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If

        If Vcconsid = 1 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

        If VcMpcconsid = 1 Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If

        If VcRUconsid = 1 Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If

        If BfredRBS = 1 Then
            CheckBox5.Checked = True
        Else
            CheckBox5.Checked = False
        End If

        If CompConsid = 1 Then
            CheckBox6.Checked = True
        Else
            CheckBox6.Checked = False
        End If

        If MomInd = 1 Then
            CheckBox7.Checked = True
        Else
            CheckBox7.Checked = False
        End If

        If LthetaBr = 1 Then
            CheckBox9.Checked = True
        Else
            CheckBox9.Checked = False
        End If

        Loaded = True

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            AlturasEntrepiso.ShowDialog()
            CheckBox3.Enabled = True
            CheckBox4.Enabled = True
        Else
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If CheckBox1.Checked = True Then
            Mgconsid = 1
        Else
            Mgconsid = 0
        End If

        If CheckBox2.Checked = True Then
            Vcconsid = 1
        Else
            Vcconsid = 0
        End If

        If CheckBox3.Checked = True Then
            VcMpcconsid = 1
        Else
            VcMpcconsid = 0
        End If

        If CheckBox4.Checked = True Then
            VcRUconsid = 1
        Else
            VcRUconsid = 0
        End If

        If CheckBox5.Checked = True Then
            BfredRBS = 1
        Else
            BfredRBS = 0
        End If

        If CheckBox6.Checked = True Then
            CompConsid = 1
        Else
            CompConsid = 0
        End If

        If CheckBox7.Checked = True Then
            MomInd = 1
        Else
            MomInd = 0
        End If

        If CheckBox9.Checked = True Then
            LthetaBr = 1
        Else
            LthetaBr = 0
        End If

        Me.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MgDialog.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PanelZone.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MomentoMpc.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PatinReducido.ShowDialog()
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MmntGusset.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        ConjMarcos.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        LongIncl.ShowDialog()
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked And Loaded Then
            LongInclBr.ShowDialog()
        End If
    End Sub
End Class