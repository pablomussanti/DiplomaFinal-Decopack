Public Class Renovaciondeposito
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

    Private _deposito As Deposito
    Public Property deposito() As Deposito
        Get
            Return _deposito
        End Get
        Set(ByVal value As Deposito)
            _deposito = value
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

    Private _proveedor As Proveedor
    Public Property proveedor() As Proveedor
        Get
            Return _proveedor
        End Get
        Set(ByVal value As Proveedor)
            _proveedor = value
        End Set
    End Property

    Private _monto As String
    Public Property monto() As String
        Get
            Return _monto
        End Get
        Set(ByVal value As String)
            _monto = value
        End Set
    End Property
End Class
