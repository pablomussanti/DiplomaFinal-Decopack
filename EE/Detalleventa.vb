Public Class Detalleventa
    Private _venta As Venta
    Public Property venta() As Venta
        Get
            Return _venta
        End Get
        Set(ByVal value As Venta)
            _venta = value
        End Set
    End Property

    Private _producto As Producto
    Public Property producto() As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property

    Private _cantidad As String
    Public Property cantidad() As String
        Get
            Return _cantidad
        End Get
        Set(ByVal value As String)
            _cantidad = value
        End Set
    End Property

    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property
End Class
