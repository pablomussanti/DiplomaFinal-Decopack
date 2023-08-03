Public Class Localizacion
    Inherits Entidad

    Private _detalle As String
    Public Property detalle() As String
        Get
            Return _detalle
        End Get
        Set(ByVal value As String)
            _detalle = value
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

    Private _telefono As Integer
    Public Property telefono() As Integer
        Get
            Return _telefono
        End Get
        Set(ByVal value As Integer)
            _telefono = value
        End Set
    End Property

    Private _codigopostal As Integer
    Public Property codigopostal() As Integer
        Get
            Return _codigopostal
        End Get
        Set(ByVal value As Integer)
            _codigopostal = value
        End Set
    End Property



    Public Overrides Function ToString() As String
        Return detalle
    End Function
End Class
