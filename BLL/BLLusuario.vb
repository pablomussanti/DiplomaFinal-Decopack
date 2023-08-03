Imports Servicios
Imports MPP
Public Class BLLusuario
    Public Function Crear(ByVal usuario As Usuario) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPUsuario
        resultado = oMPP.Crear(usuario)
        Return resultado
    End Function

    Public Function Eliminar(ByVal usuario As Usuario) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPUsuario
        resultado = oMPP.Eliminar(usuario)
        Return resultado
    End Function

    Public Function Listar() As List(Of Usuario)
        Dim lista As New List(Of Usuario)
        Dim oMPP As New MPPUsuario
        lista = oMPP.Listar
        Return lista
    End Function

    Public Function Listarbloqueados() As List(Of Usuario)
        Dim lista As New List(Of Usuario)
        Dim oMPP As New MPPUsuario
        lista = oMPP.Listarbloqueados
        Return lista
    End Function

    Public Function Confirmarusuario(ByVal dato3 As Usuario)
        Dim lista As New List(Of Usuario)
        Dim oMPP As New MPPUsuario
        lista = oMPP.Confimarusuario(dato3)
        Return lista
    End Function
End Class
