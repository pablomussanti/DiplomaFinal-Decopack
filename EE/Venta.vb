Public Class Venta
    Inherits EntidadEstado


    Private _sucursal As Sucursal
    Public Property sucursal() As Sucursal
        Get
            Return _sucursal
        End Get
        Set(ByVal value As Sucursal)
            _sucursal = value
        End Set
    End Property

    Private _empleado As Empleadosucursal
    Public Property empleado() As Empleadosucursal
        Get
            Return _empleado
        End Get
        Set(ByVal value As Empleadosucursal)
            _empleado = value
        End Set
    End Property

    Private _comprador As Comprador
    Public Property comprador() As Comprador
        Get
            Return _comprador
        End Get
        Set(ByVal value As Comprador)
            _comprador = value
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

    Private _monto As Double
    Public Property monto() As Double
        Get
            Return _monto
        End Get
        Set(ByVal value As Double)
            _monto = value
        End Set
    End Property

    Private _pagado As String
    Public Property pagado() As String
        Get
            Return _pagado
        End Get
        Set(ByVal value As String)
            _pagado = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return codigo
    End Function
End Class
