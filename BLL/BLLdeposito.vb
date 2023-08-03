Imports EE
Imports MPP
Public Class BLLdeposito
    Public Function Creardeposito(ByVal deposito As EE.Deposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPdeposito
        resultado = oMPP.Creardeposito(deposito)
        Return resultado
    End Function

    Public Function Eliminardeposito(ByVal deposito As EE.Deposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPdeposito
        resultado = oMPP.Eliminardeposito(deposito)
        Return resultado
    End Function

    Public Function Listardeposito() As List(Of EE.Deposito)
        Dim lista As New List(Of EE.Deposito)
        Dim oMPP As New MPPdeposito
        lista = oMPP.Listardeposito()
        Return lista
    End Function
End Class
