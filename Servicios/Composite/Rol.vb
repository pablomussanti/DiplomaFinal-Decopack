Imports Servicios
'composite
Public Class Rol
    Inherits Rolpermiso

    Private _rolPermiso As New List(Of Rolpermiso) '= New List(Of Rolpermiso)



    Public Overrides Sub Agregar(rolPermiso As Rolpermiso)
        _rolPermiso.Add(rolPermiso)
    End Sub

    Public Overrides Sub Remover(rolPermiso As Rolpermiso)
        _rolPermiso.Remove(rolPermiso)
    End Sub

    Public Overrides Function Mostrar()
        Return _rolPermiso
    End Function

    Public Overrides Function ToString() As String
        Return nombre
    End Function
End Class
