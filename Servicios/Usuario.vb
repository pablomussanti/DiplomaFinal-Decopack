Imports Servicios


Public Class Usuario
    Inherits Entidad
    'Implements Iidiomaobserver



    Private _user As String

    Public Property user As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private _contraseña As String

    Public Property contraseña As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property

    Private _estadobloqueado As String

    Public Property estadobloqueado As String
        Get
            Return _estadobloqueado
        End Get
        Set(ByVal value As String)
            _estadobloqueado = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return user
    End Function

    Private _rolpermiso As New List(Of Rolpermiso)
    Public Property rolpermiso() As List(Of Rolpermiso)
        Get
            Return _rolpermiso
        End Get
        Set(ByVal value As List(Of Rolpermiso))
            _rolpermiso = value
        End Set
    End Property

End Class
