Public Class Carritomuestra
    Private _producto As EE.Producto
    Public Property producto() As EE.Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As EE.Producto)
            _producto = value
        End Set
    End Property

    Private _stockrequerido As Integer
    Public Property stockrequerido() As Integer
        Get
            Return _stockrequerido
        End Get
        Set(ByVal value As Integer)
            _stockrequerido = value
        End Set
    End Property

    Private _stockdisponiblesucursal As Integer
    Public Property stockdisponiblesucursal() As Integer
        Get
            Return _stockdisponiblesucursal
        End Get
        Set(ByVal value As Integer)
            _stockdisponiblesucursal = value
        End Set
    End Property

    Private _stockdisponibledeposito As Integer
    Public Property stockdisponibledeposito() As Integer
        Get
            Return _stockdisponibledeposito
        End Get
        Set(ByVal value As Integer)
            _stockdisponibledeposito = value
        End Set
    End Property

    Private _monto As Double
    Public Property monto() As Double
        Get
            Return _monto
        End Get
        Set(ByVal value As Double)
            _monto = value
        End Set
    End Property

End Class
