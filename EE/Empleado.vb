Public Class Empleado
    Inherits EntidadEstado

    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Private _apellido As String
    Public Property apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property
    Private _telefono As Integer
    Public Property telefono() As Integer
        Get
            Return _telefono
        End Get
        Set(ByVal value As Integer)
            _telefono = value
        End Set
    End Property
    Private _fechadeingreso As Date
    Public Property fechadeingreso() As Date
        Get
            Return _fechadeingreso
        End Get
        Set(ByVal value As Date)
            _fechadeingreso = value
        End Set
    End Property

    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _localizacion As Localizacion
    Public Property localizacion() As Localizacion
        Get
            Return _localizacion
        End Get
        Set(ByVal value As Localizacion)
            _localizacion = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return nombre & "" & apellido
    End Function
End Class
