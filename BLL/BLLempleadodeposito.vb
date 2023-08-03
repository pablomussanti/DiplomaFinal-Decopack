Imports EE
Imports MPP
Public Class BLLempleadodeposito
    Public Function Crearempleadodeposito(ByVal empleadodeposito As EE.Empleadodeposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPempleadodeposito
        resultado = oMPP.Crearempleadodeposito(empleadodeposito)
        Return resultado
    End Function

    Public Function Modificarempleadodeposito(ByVal empleadodeposito As Empleadodeposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPempleadodeposito
        resultado = oMPP.Modificarempleadodeposito(empleadodeposito)
        Return resultado
    End Function

    Public Function Eliminarempleadodeposito(ByVal empleadodeposito As Empleadodeposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPempleadodeposito
        resultado = oMPP.Eliminarempleadodeposito(empleadodeposito)
        Return resultado
    End Function

    Public Function Listarempleadodeposito() As List(Of Empleadodeposito)
        Dim lista As New List(Of Empleadodeposito)
        Dim oMPP As New MPPempleadodeposito
        lista = oMPP.Listarempleadodeposito()
        Return lista
    End Function
End Class
