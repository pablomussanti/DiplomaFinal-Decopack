Public Class Traduccion
    Inherits Entidad

    Private _idioma As Idioma
    Public Property idioma As Idioma
        Get
            Return _idioma
        End Get
        Set(ByVal value As Idioma)
            _idioma = value
        End Set
    End Property

    Private _palabra As Palabra
    Public Property palabra As Palabra
        Get
            Return _palabra
        End Get
        Set(ByVal value As Palabra)
            _palabra = value
        End Set
    End Property

    Private _traduccion As String
    Public Property traduccion As String
        Get
            Return _traduccion
        End Get
        Set(ByVal value As String)
            _traduccion = value
        End Set
    End Property

End Class
