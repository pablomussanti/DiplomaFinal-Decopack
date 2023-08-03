Public Class Palabra
    Inherits Entidad


    Private _nombre As String

    Public Property nombre As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property


    Private _tag As Integer
    Public Property tag() As Integer
        Get
            Return _tag
        End Get
        Set(ByVal value As Integer)
            _tag = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return nombre
    End Function
End Class
