Public Class Reclamo
    Inherits Entidad

    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Private _medidasatomar As String
    Public Property medidasatomar() As String
        Get
            Return _medidasatomar
        End Get
        Set(ByVal value As String)
            _medidasatomar = value
        End Set
    End Property

    Private _motivo As String
    Public Property motivo() As String
        Get
            Return _motivo
        End Get
        Set(ByVal value As String)
            _motivo = value
        End Set
    End Property

    Private _comprador As EE.Comprador
    Public Property comprador() As EE.Comprador
        Get
            Return _comprador
        End Get
        Set(ByVal value As EE.Comprador)
            _comprador = value
        End Set
    End Property

    Private _sucursal As EE.Sucursal
    Public Property sucursal() As EE.Sucursal
        Get
            Return _sucursal
        End Get
        Set(ByVal value As EE.Sucursal)
            _sucursal = value
        End Set
    End Property
End Class
