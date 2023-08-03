'hoja
Public Class Permiso

    Inherits Rolpermiso


    Public Overrides Sub Agregar(rolPermiso As Rolpermiso)
        Throw New Exception("No se pueden agregar permisos a un permiso")
    End Sub

    Public Overrides Sub Remover(rolPermiso As Rolpermiso)
        Throw New Exception("Un permiso no contiene permisos")
    End Sub

    Public Overrides Function Mostrar()
        Return nombre
    End Function

    Public Overrides Function ToString() As String
        Return Nombre
    End Function



End Class
