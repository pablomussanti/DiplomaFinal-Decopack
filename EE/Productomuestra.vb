Public Class Productomuestra
    Private _producto As Producto
    Public Property producto() As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property

    Private _sucursal As Boolean
    Public Property sucursal() As Boolean
        Get
            Return _sucursal
        End Get
        Set(ByVal value As Boolean)
            _sucursal = value
        End Set
    End Property

    Private _deposito As Boolean
    Public Property deposito() As Boolean
        Get
            Return _deposito
        End Get
        Set(ByVal value As Boolean)
            _deposito = value
        End Set
    End Property



End Class
