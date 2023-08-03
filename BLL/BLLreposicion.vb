Imports EE
Imports MPP
Public Class BLLreposicion
    Public Function Crearreposicion(ByVal reposicion As EE.Reposicion) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPreposicion
        resultado = oMPP.Crearreposicion(reposicion)
        Return resultado
    End Function

    Public Function Modificarreposicion(ByVal reposicion As Reposicion) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPreposicion
        resultado = oMPP.Modificarreposicion(reposicion)
        Return resultado
    End Function

    Public Function Eliminarreposicion(ByVal reposicion As Reposicion) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPreposicion
        resultado = oMPP.Eliminarreposicion(reposicion)
        Return resultado
    End Function

    Public Function Listarreposicion() As List(Of Reposicion)
        Dim lista As New List(Of Reposicion)
        Dim oMPP As New MPPreposicion
        lista = oMPP.Listarreposicion()
        Return lista
    End Function
End Class
