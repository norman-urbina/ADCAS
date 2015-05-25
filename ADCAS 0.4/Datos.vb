Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.SoapFault
Imports System.Runtime.Remoting.Messaging

' Marcamos la clase como serializable.
<Serializable()>
Public Class Datos

#Region "Campos privados de la clase."

    Private S_viga As String        'S:sección de la viga
    Private M_columna As String     'M:material de la columna
    Private C_axial As String       'C:carga axial en la columna


#End Region

#Region "Constructores de la clase."

    ''' <summary>
    ''' Crea una nueva instancia de la clase Persona.
    ''' </summary>
    Public Sub New()
        ' Este es el constructor predeterminado de la clase.
    End Sub

    ''' <summary>
    ''' Crea una nueva instancia de la clase Persona.
    ''' </summary>
    Public Sub New(idPersona As String)
        ' Constructor sobrecargado de la clase. ???? NO ENTIENDO!!
        Me.SeccViga = idPersona
    End Sub

#End Region

#Region "Propiedades públicas de la clase."
    Public Property Calc As Integer
    'sirve para saber si el usuario ejecutó el diseño desde el 
    'menú 'Calcular' (F5)
    '=0 si no lo ejecutó, 1 si lo ejecutó al menos una vez
    Public Property Sistema As String
    'Sistema de Marco al que 
    'pertenece al conexión
    Public Property Tipo_de_Conexion As Integer
    'Tipo de conexion:
    '1->RBS,  2->BUEEP,  3->BSEEP,  4->BFP,  5->WUF-W
    Public Property Vigas_conectadas As Integer

    Public Property Losa As Integer

    Public Property Conex_Extremo As Integer

    Public Property SeccViga As String
        Get
            Return S_viga
        End Get
        Set(value As String)
            ' El valor es requerido por lo que debe ser una
            ' cadena alfanumérica de longitud superior a cero.
            '
            If (String.IsNullOrEmpty(value)) Then
                Throw New ArgumentNullException("value", "No es una sección válida.")
            End If

            S_viga = value
        End Set
    End Property

    Public Property perfilViga

    Public Property Carga_Axial As String
        Get
            Return C_axial
        End Get
        Set(value As String)
            ' El valor es requerido por lo que debe ser una
            ' cadena alfanumérica de longitud superior a cero.
            '
            If (String.IsNullOrEmpty(value)) Then
                Throw New ArgumentNullException("value", "No es una carga válida.")
            End If

            C_axial = value
        End Set
    End Property

    Public Property Claro As String

    Public Property SeccCol As String

    Public Property perfilCol

    Public Property CV As String    'Carga Viva

    Public Property CM As String    'Carga Muerta

    Public Property MatViga As String

    Public Property AceroViga

    Public Property MatCol As String
        Get
            Return M_columna
        End Get
        Set(value As String)
            ' El valor es requerido por lo que no puede
            ' ser Nothing ni una cadena de longitud cero.
            '
            If (String.IsNullOrEmpty(value)) Then
                Throw New ArgumentException("No es un acero válido.")
            End If

            M_columna = value
        End Set
    End Property

    Public Property AceroCol

    Public Property MatPlaca As String

    Public Property AceroPlaca

    Public Property espesor_plCont As String
    Public Property plcontBckColor

    Public Property recorte1_plCont As String
    Public Property BckColor1
    Public Property contacto1_plCont As String

    Public Property recorte2_plCont As String
    Public Property BckColor2
    Public Property contacto2_plCont As String

    Public Property biselRecto As Integer

    Public Property soldplCont As String

    Public Property Rsold_plCont As String

    Public Property Dsold_plCont As String

    Public Property As_plCont As String
    Public Property BckColor3

    Public Property AsminplCont As String

    Public Property sold2plCont As String

    Public Property sold_capPlate As String

    Public Property tRefNodal As String
    Public Property BckColor4

    Public Property confPlNodal As Integer

    Public Property dispPlNodal As Integer

    Public Property soldPlNodal As Integer

    Public Property bordPlNodal As Integer

    Public Property plNodal_dist As String
    Public Property BckColor5

    Public Property bisel_plNodal As String
    Public Property BckColor6

    Public Property soldFilete_plNodal As String

    Public Property tmin_plNodalSobresale As String

    'Datos Específicos de RBS
    '
    Public Property dim_a As String
    Public Property bckcolorRBS1
    Public Property ainf As String
    Public Property asup As String

    Public Property dim_b As String
    Public Property bckcolorRBS2
    Public Property binf As String
    Public Property bsup As String

    Public Property dim_c As String
    Public Property bckcolorRBS3
    Public Property cinf As String
    Public Property csup As String

    Public Property tplRBS As String
    Public Property BckColor7

    'Datos Específicos de BUEEP/BSEEP
    '
    Public Property pernoBEEP As Integer
    Public Property holeBEEP As Integer
    Public Property diamReq As String
    Public Property diamBEEP As Integer
    Public Property gramilBEEP As String
    Public Property BckColorBEEP1
    Public Property bpBEEP As String
    Public Property BckColorBEEP2
    Public Property pfoBEEP As String
    Public Property pfiBEEP As String
    Public Property deBEEP As String
    Public Property BckColorBEEP3
    Public Property pbBEEP As String
    Public Property BckColorBEEP4
    Public Property tipoBSEEP As Integer '4ES o 8ES
    Public Property treqBEEP As String
    Public Property tpBEEP As String
    Public Property Lst As String
    Public Property hst As String
    Public Property Lst_grafica As String
    Public Property hst_grafica As String
    Public Property FysBEEP As String
    Public Property tsBSEEP As String
    Public Property tsmin As String
    Public Property plcontBEEP As String 'Espesor de pl.cont en la pestaña Diseño de la conexion
    Public Property tcfMinBEEP As String 'Espesor mínimo por flexión del patín BEEP
    Public Property BckColor

    'Datos Específicos de BFP
    '
    Public Property holgBFP As String
    Public Property dbMaxBFP As String
    Public Property dbBFP As Integer
    Public Property Lemax1 As String
    Public Property Leh1 As String
    Public Property bckcolorBFP1
    Public Property Lev1 As String
    Public Property bckcolorBFP2
    Public Property Lc1 As String
    Public Property bckcolorBFP3
    Public Property gramilBFP As String
    Public Property gmin As String
    Public Property bckcolorBFP4
    Public Property g_workgage As String
    Public Property holeBFP As Integer
    Public Property tpBFP As String
    Public Property bfp As String
    Public Property Lemax2 As String
    Public Property Leh2 As String
    Public Property bckcolorBFP5
    Public Property Lev2 As String
    Public Property bckcolorBFP6
    Public Property Lc2 As String
    Public Property bckcolorBFP7
    Public Property Npernos As String
    Public Property N_prop As String
    Public Property s_prop As String
    Public Property bckcolorBFP8
    Public Property smin As String
    Public Property smax As String
    Public Property S1_BFP As String
    Public Property Sh_BFP As String
    Public Property Lc3 As String
    Public Property bckcolorBFP9
    Public Property AcerPlSimple_BFP As Integer
    Public Property PernPlSimple_BFP As Integer
    Public Property DiamPernPlSimple_BFP As Integer
    Public Property NumPernPlSimple_BFP As Integer
    Public Property SoldPlSimple_BFP As Integer
    Public Property NotaLeh As String
    Public Property VisibleBFP1 As Integer
    Public Property NotaSoldadura As String
    Public Property VisibleBFP2 As Integer
    Public Property aIntroducido As String
    Public Property LehIntroducido As String
    Public Property esp_sIntrod As String
    Public Property LevIntroducido As String
    Public Property tplSimpleBFP As String
    Public Property SoldFilete_PlSimpleBFP As String
    Public Property bckcolorBFP10
    Public Property Soldmin_PlSimpleBFP As String
    Public Property bckcolorBFP11

    'Datos Específicos de WUF-W
    '
    Public Property holeacces_a As String
    Public Property holeacces_b As String
    Public Property holeacces_c As String
    Public Property holeacces_d As String
    Public Property holgMontaje As String
    Public Property aPrimaVal As String
    Public Property bPrimaVal As String
    Public Property cPrimaVal As String
    Public Property dPrimaVal As String
    Public Property ePrimaVal As String
    Public Property anchoEstimadoPL As String
    Public Property longCalcPL As String
    Public Property longPropPL As String
    Public Property aPrimaNew As String
    Public Property bckcolorWUFW1
    Public Property tpPropPL As String
    Public Property twbWUF As String
    Public Property FyPLSimpleBFP As String
    Public Property RyPLSimpleBFP As String
    Public Property bckcolorWUFW2

    '_______<<<<<<>>>>>>________
    'Opciones de Diseño
    '---------------------------
    Public Property Mom_gravedad As Integer
    Public Property VC_consid As Integer
    Public Property VCMpc_consid As Integer
    Public Property VCRu_consid As Integer
    Public Property BfRBS_consid As Integer
    Public Property Hsup_coL As Double
    Public Property Hinf_coL As Double
    Public Property Opcbp_PLcont As Integer
    Public Property anchoProp_plcont As String
    Public Property LthetaCalc As Integer
    Public Property momindCalc As Integer
    Public Property CompFrm As Integer


    'Conexión SCBF
    '   Datos Iniciales

    '       Secciones
    Public Property BR1VC As String
    Public Property BR2VC As String
    Public Property BMVC As String
    Public Property CLVC As String
    '       Aceros
    Public Property StBR1VC As String
    Public Property StBr2VC As String
    Public Property StBMVC As String
    Public Property StCLVC As String
    Public Property StPLVC As String
    '       Viga
    Public Property CMBMVC As String
    Public Property CLBMVC As String
    Public Property LBMVC As String
    '       Pisos
    Public Property SHVC As String
    Public Property SH2VC As String

    'Opciones de diseño EBF

    Public Property Lbrcn As Double
    Public Property Lbrcn2 As Double
    Public Property thetacn As Double
    Public Property thetacn2 As Double

    '   Datos de diseño
    '       Conexión Arriostre-Placa Gusset superior
    Public Property SweldVC As String
    Public Property LwbrVC As String
    Public Property gAwtmrVC As String
    Public Property tVC As String
    Public Property PhiGussetVC As String
    Public Property LAGussetVC As String
    Public Property LBGussetVC As String
    Public Property LflGusset As String
    Public Property LGussetVC As String
    Public Property dostGussetVC As String
    Public Property aGusset As String
    '       Pernos
    Public Property bPSVC As String
    Public Property tPSVC As String
    Public Property BTipoVC As String
    Public Property BDiamVC As String
    Public Property GPSqnt As String
    Public Property GPSspc As String
    Public Property BPSqnt As String
    Public Property BPSspc As String

    '       Conexión Arriostre-Placa Gusset inferior
    Public Property Dbr2VC As String
    Public Property Lwbr2VC As String
    Public Property gAwtmr2VC As String
    Public Property t2VC As String
    Public Property phigusset2VC As String
    Public Property LBGusset2VC As String
    Public Property Lgusset2VC As String
    Public Property LflGusset2 As String
    Public Property LAgusset2VC As String
    Public Property dostGusset2VC As String
    Public Property aGusset2 As String
    '       Tamaños de soldadura
    Public Property DBCVC As String
    Public Property DGBSVC As String
    Public Property DGBIVC As String
    Public Property DGCSVC As String
    Public Property DGCIVC As String
    '   checkbox

    Public Property CheckedBox1 As Boolean

#End Region

#Region "Métodos públicos de la clase."

    Public Overrides Function Equals(obj As Object) As Boolean

        ' Dos objetos Persona serán iguales si son iguales
        ' sus identificadores.
        '
        If (Not (TypeOf obj Is Datos)) Then Return False

        Dim dat As Datos = DirectCast(obj, Datos)

        Return (S_viga.Equals(dat.SeccViga, StringComparison.OrdinalIgnoreCase))

    End Function

    Public Overrides Function GetHashCode() As Integer

        If (String.IsNullOrEmpty(S_viga)) Then
            Return 0
        End If

        ' Simplemente nos limitamos a devolver el
        ' valor GetHashCode del campo S_viga.
        '
        Return S_viga.ToUpperInvariant().GetHashCode()

    End Function

    ''' <summary>
    ''' Devuelve una cadena alfanumérica resultante de la
    ''' concatenación del identificador y el nombre del
    ''' objeto Persona.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return String.Format("{0} - {1}", S_viga, M_columna)
    End Function

#End Region

#Region "Métodos privados y compartidos de la clase."

    ''' <summary>
    ''' Devuelve un objeto Persona con los datos existentes
    ''' en el archivo especificado.
    ''' </summary>
    ''' <param name="fileName">Ruta completa del archivo que contiene los datos.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Open(fileName As String) As Datos

        ' Verificamos el valor del parámetro.
        '
        If (fileName Is Nothing) Then
            Throw New ArgumentNullException("fileName")
        End If

        If (fileName = String.Empty) Then
            Throw New ArgumentException("No es un nombre de archivo válido.", "fileName")
        End If

        ' Creamos una nueva instancia de la clase Persona como
        ' resultado de deserializar el archivo especificado.
        '
        Using fs As New IO.FileStream(fileName, IO.FileMode.Open)

            Dim formatter As New BinaryFormatter()

            ' Deserializamos los objetos en el mismo orden
            ' en el que fueron serializados.
            '
            ' Primero la instancia de la clase concreta.
            Dim dat As Datos = TryCast(formatter.Deserialize(fs), Datos)

            Return dat

        End Using

    End Function

    ''' <summary>
    ''' Guarda el objeto Persona en el archivo especificado.
    ''' </summary>
    ''' <param name="dat">Objeto Persona que se desea guardar.</param>
    ''' <param name="fileName">Ruta completa del archivo donde se desean guardar los datos.</param>
    ''' <remarks></remarks>
    Public Shared Sub Save(dat As Datos, fileName As String)

        ' Verificamos el valor de los parámetros.
        '
        If (dat Is Nothing) Then
            Throw New ArgumentNullException("p")
        End If

        If (fileName Is Nothing) Then
            Throw New ArgumentNullException("fileName")
        End If

        If (fileName = String.Empty) Then
            Throw New ArgumentException("No es un nombre de archivo válido.", "fileName")
        End If

        ' Serialización en tiempo de ejecución
        ' http://msdn.Microsoft.com/msdnmag/issues/02/04/NET/default.aspx
        '
        ' Serialización binaria
        ' http://msdn.microsoft.com/es-es/library/aa719633.aspx



        Using fs As New IO.FileStream(fileName, IO.FileMode.Create)

            Dim formatter As New BinaryFormatter()

            ' Serializamos el objeto.
            formatter.Serialize(fs, dat)

        End Using

    End Sub

#End Region


End Class
