Imports EE
Imports MPP
Public Class BLLdetalleventa
    Public Function Generardetalle(ByVal detalle As EE.Detalleventa) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPdetalleventa
        resultado = oMPP.Generardetalle(detalle)
        Return resultado
    End Function

    Public Function Listardetalle(venta As Venta) As List(Of Detalleventa)
        Dim lista As New List(Of Detalleventa)
        Dim oMPP As New MPPdetalleventa
        lista = oMPP.Listardetalle(venta)
        Return lista
    End Function

    Public Function Eliminardetalle(Venta As Venta) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPdetalleventa
        resultado = oMPP.Eliminardetalle(Venta)
        Return resultado
    End Function


End Class
