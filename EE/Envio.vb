Public Class Envio
    Inherits EntidadEstado

    Private _direccion As String
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _empleado As Empleadodeposito
    Public Property empleado() As Empleadodeposito
        Get
            Return _empleado
        End Get
        Set(ByVal value As Empleadodeposito)
            _empleado = value
        End Set
    End Property


    Private _fechadesalida As Date
    Public Property fechadesalida() As Date
        Get
            Return _fechadesalida
        End Get
        Set(ByVal value As Date)
            _fechadesalida = value
        End Set
    End Property

    Private _fechadellegada As Date
    Public Property fechadellegada() As Date
        Get
            Return _fechadellegada
        End Get
        Set(ByVal value As Date)
            _fechadellegada = value
        End Set
    End Property

    Private _venta As Venta
    Public Property venta() As Venta
        Get
            Return _venta
        End Get
        Set(ByVal value As Venta)
            _venta = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return codigo
    End Function
End Class
