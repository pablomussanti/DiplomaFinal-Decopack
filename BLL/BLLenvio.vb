Imports EE
Imports MPP
Public Class BLLenvio
    Public Function generarenvio(ByVal envio As EE.Envio) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPenvio
        resultado = oMPP.generarenvio(envio)
        Return resultado
    End Function

    Public Function Modificarenvio(ByVal envio As Envio) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPenvio
        resultado = oMPP.Modificarenvio(envio)
        Return resultado
    End Function

    Public Function Eliminarenvio(ByVal envio As Envio) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPenvio
        resultado = oMPP.Eliminarenvio(envio)
        Return resultado
    End Function

    Public Function Listarenvio() As List(Of Envio)
        Dim lista As New List(Of Envio)
        Dim oMPP As New MPPenvio
        lista = oMPP.Listarenvio()
        Return lista
    End Function

    Public Function Listarenvioporempleado(empleado As Empleadodeposito) As List(Of Envio)
        Dim lista As New List(Of Envio)
        Dim oMPP As New MPPenvio
        lista = oMPP.Listarenvioporempleado(empleado)
        Return lista
    End Function

    Public Function Listarenviopordevolucion(empleado As Empleadodeposito) As List(Of Envio)
        Dim lista As New List(Of Envio)
        Dim oMPP As New MPPenvio
        lista = oMPP.Listarenviopordevolucion(empleado)
        Return lista
    End Function
End Class
