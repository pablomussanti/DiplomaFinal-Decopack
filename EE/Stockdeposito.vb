Public Class Stockdeposito
    Private _cantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _deposito As Deposito
    Public Property deposito() As Deposito
        Get
            Return _deposito
        End Get
        Set(ByVal value As Deposito)
            _deposito = value
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

    Private _requerirstock As Boolean
    Public Property requerirstock() As Boolean
        Get
            Return _requerirstock
        End Get
        Set(ByVal value As Boolean)
            _requerirstock = value
        End Set
    End Property
End Class
