Imports EE
Imports MPP
Public Class BLLreclamo
    Public Function generarreclamo(ByVal reclamo As EE.Reclamo) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPreclamo
        resultado = oMPP.Generarreclamo(reclamo)
        Return resultado
    End Function

    Public Function Listarreclamo() As List(Of EE.Reclamo)
        Dim lista As New List(Of EE.Reclamo)
        Dim oMPP As New MPPreclamo
        lista = oMPP.Listarreclamo
        Return lista
    End Function
End Class
