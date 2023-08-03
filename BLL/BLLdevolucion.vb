Imports EE
Imports MPP
Public Class BLLdevolucion
    Public Function Generardevolucion(ByVal devolucion As EE.Devolucion) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPdevolucion
        resultado = oMPP.generardevolucion(devolucion)
        Return resultado
    End Function

    Public Function Modificardevolucion(ByVal devolucion As Devolucion) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPdevolucion
        resultado = oMPP.Modificardevolucion(devolucion)
        Return resultado
    End Function

    Public Function Eliminardevolucion(ByVal devolucion As Devolucion) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPdevolucion
        resultado = oMPP.Eliminardevolucion(devolucion)
        Return resultado
    End Function

    Public Function Listardevolucion() As List(Of Devolucion)
        Dim lista As New List(Of Devolucion)
        Dim oMPP As New MPPdevolucion
        lista = oMPP.Listardevolucion()
        Return lista
    End Function
End Class
