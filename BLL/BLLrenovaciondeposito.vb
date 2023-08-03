Imports EE
Imports MPP
Public Class BLLrenovaciondeposito
    Public Function Crearrenovaciondeposito(ByVal renovaciondeposito As EE.Renovaciondeposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPrenovaciondeposito
        resultado = oMPP.Crearrenovaciondeposito(renovaciondeposito)
        Return resultado
    End Function

    Public Function Modificarrenovaciondeposito(ByVal renovaciondeposito As Renovaciondeposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPrenovaciondeposito
        resultado = oMPP.Modificarrenovaciondeposito(renovaciondeposito)
        Return resultado
    End Function

    Public Function Eliminarrenovaciondeposito(ByVal renovaciondeposito As Renovaciondeposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPrenovaciondeposito
        resultado = oMPP.Eliminarrenovaciondeposito(renovaciondeposito)
        Return resultado
    End Function

    Public Function Listarrenovaciondeposito() As List(Of Renovaciondeposito)
        Dim lista As New List(Of Renovaciondeposito)
        Dim oMPP As New MPPrenovaciondeposito
        lista = oMPP.Listarrenovaciondeposito()
        Return lista
    End Function
End Class
