Public Class Devolucion
    Inherits EntidadEstado

    Private _envio As Envio
    Public Property envio() As Envio
        Get
            Return _envio
        End Get
        Set(ByVal value As Envio)
            _envio = value
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

    Private _cantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
End Class
