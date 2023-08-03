Public Class Proveedor
    Inherits EntidadEstado

    Private _cantidaddeerrores As Integer
    Public Property cantidaddeerrores() As Integer
        Get
            Return _cantidaddeerrores
        End Get
        Set(ByVal value As Integer)
            _cantidaddeerrores = value
        End Set
    End Property

    Private _direccion As String
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _telefono As Integer
    Public Property telefono() As Integer
        Get
            Return _telefono
        End Get
        Set(ByVal value As Integer)
            _telefono = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return nombre
    End Function
End Class
