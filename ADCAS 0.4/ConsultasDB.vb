Imports System.Data
Imports System.Data.OleDb

Module ConsultasDB
    Public coneXSecc As New OleDb.OleDbConnection
    Public conPerns As New OleDb.OleDbConnection
    Public conexEncroach As New OleDb.OleDbConnection
    Public cmd As New OleDb.OleDbCommand
    Public dread As OleDb.OleDbDataReader
    Public LeminSTD As String
    Public LeminOVS As String
    Public wgageCol As String
    Public demin As String
    Public dhOVS As String
    Public minLe As String
    Public Encr As String
    Public ranura As String
    Public kdes As String

    Public Sub conectarseSecciones()

        Try
            coneXSecc.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Secciones W.accdb;Persist Security Info=False"
            coneXSecc.Open()
            'MsgBox("conexion exitosa")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Public Sub conecPernos()

        Try
            conPerns.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Pernos.accdb;Persist Security Info=False"
            conPerns.Open()
            'MsgBox("conexion exitosa")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub conecEncroach()

        Try
            conexEncroach.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EncroachmentDB.accdb;Persist Security Info=False"
            conexEncroach.Open()
            'MsgBox("conexion exitosa")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try


    End Sub

    Public Sub consultarSecc(ByRef seccion As String)
        cmd.Connection = coneXSecc
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT SECCION, WORKABLEGAGE FROM Hoja1 WHERE Seccion = '" & seccion & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    ADCAS.TextBox115.Text = dread(1).ToString
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub getPeso(ByRef perfil As String)
        cmd.Connection = coneXSecc
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT SECCION, W FROM Hoja1 WHERE Seccion = '" & perfil & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    ADCAS.TextBox16.Text = dread(1).ToString
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Public Sub consultColumna(ByRef columna As String)
        cmd.Connection = coneXSecc
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT SECCION, WORKABLEGAGE FROM Hoja1 WHERE Seccion = '" & columna & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    wgageCol = dread(1).ToString
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub consKdes(ByRef seccCol As String)
        cmd.Connection = coneXSecc
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT SECCION, kdes FROM Hoja1 WHERE Seccion = '" & seccCol & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    kdes = dread(1).ToString
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub consultaPernos(ByRef diametro As String)

        cmd.Connection = conPerns
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT * FROM LeminBFP WHERE DB = '" & diametro & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    LeminSTD = dread(1).ToString()
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub consultaPernos1(ByRef perno As String)

        cmd.Connection = conPerns
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT DB, STD FROM LeminBUEEP WHERE DB = '" & perno & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    demin = dread(1).ToString()
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub consultRanuraSSL(ByRef diam As String)
        cmd.Connection = conPerns
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT DB, RanuraSSL FROM LeminBUEEP WHERE DB = '" & diam & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    ranura = dread(1).ToString()
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub consultaPernos2(ByRef Diamdb As String)

        cmd.Connection = conPerns
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT DB, STD, OVS FROM LeminBFP WHERE DB = '" & Diamdb & "' "

        Try
            dread = cmd.ExecuteReader()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '***********
        'IMPORTANTE: Asegurarse de CERRAR el datareader despues de la consulta
        '***********
    End Sub
    Public Sub consultaPernos3(ByRef diam As String)

        cmd.Connection = conPerns
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT DB, OVS FROM DhAgujeroBFP WHERE DB = '" & diam & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    dhOVS = dread(1).ToString()
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Function saberLemin(ByRef agujero, ByRef diametro) As String
        cmd.Connection = conPerns
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT * FROM LeminBFP WHERE DB = '" & diametro & "' "

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    If agujero = "STD" Then
                        minLe = dread(1).ToString()
                    Else
                        minLe = dread(2).ToString()
                    End If
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        saberLemin = minLe

    End Function

    Public Sub consultaEncroach(ByRef dif As String)

        cmd.Connection = conexEncroach
        cmd.CommandType = CommandType.Text

        cmd.CommandText = "SELECT diferencia, Encroachment FROM FilletEncroachment WHERE diferencia =" + dif

        Try
            dread = cmd.ExecuteReader()

            If dread.HasRows = True Then
                While dread.Read()
                    Encr = dread(1).ToString
                End While
            Else
                MsgBox("No se puede consultar")
            End If

            dread.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Module
