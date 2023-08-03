Imports MPP
Public Class BLLrestore
    Public Function realizarrestore(direccion As String) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPrestore
        resultado = oMPP.realizarrestore(direccion)
        Return resultado
    End Function

    Public Function realizarnuevorestore(direccion As String) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPrestore
        resultado = oMPP.realizarnuevorestore(direccion)
        Return resultado
    End Function
End Class
