Public Class Permisousuario
    Private _usuario As Usuario
    Public Property usuario() As Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As Usuario)
            _usuario = value
        End Set
    End Property

    Private _permiso As Rolpermiso
    Public Property permiso() As Rolpermiso
        Get
            Return _permiso
        End Get
        Set(ByVal value As Rolpermiso)
            _permiso = value
        End Set
    End Property
End Class
