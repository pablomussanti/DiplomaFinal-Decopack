'componente
Public MustInherit Class Rolpermiso
    Inherits Entidad
    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return nombre
    End Function


    Public MustOverride Sub Agregar(rolPermiso As Rolpermiso)
    Public MustOverride Sub Remover(rolPermiso As Rolpermiso)
    Public MustOverride Function Mostrar()
End Class
