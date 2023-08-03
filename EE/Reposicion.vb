Public Class Reposicion
    Inherits EntidadEstado

    Private _cantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property


    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
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

    Private _sucursal As Sucursal
    Public Property sucursal() As Sucursal
        Get
            Return _sucursal
        End Get
        Set(ByVal value As Sucursal)
            _sucursal = value
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

End Class
