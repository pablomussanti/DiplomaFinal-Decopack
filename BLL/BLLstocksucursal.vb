Imports EE
Imports MPP
Public Class BLLstocksucursal
    Public Function aumentarstock(ByVal stocksucursal As EE.Stocksucursal, valor As Integer) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPstocksucursal
        stocksucursal.cantidad = valor + stocksucursal.cantidad
        resultado = oMPP.aumentarstock(stocksucursal)
        Return resultado
    End Function
    Public Function generarstock(ByVal stocksucursal As EE.Stocksucursal) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPstocksucursal
        resultado = oMPP.generarstock(stocksucursal)
        Return resultado
    End Function

    Public Function reducirstock(ByVal stocksucursal As EE.Stocksucursal, valor As Integer) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPstocksucursal
        stocksucursal.cantidad = stocksucursal.cantidad - valor
        resultado = oMPP.Reducirstock(stocksucursal)
        Return resultado
    End Function

    Public Function Listarstock() As List(Of EE.Stocksucursal)
        Dim lista As New List(Of EE.Stocksucursal)
        Dim oMPP As New MPPstocksucursal
        lista = oMPP.Listarstock()
        Return lista
    End Function

    Public Function Verificarfaltantestock(sc As List(Of EE.Stocksucursal), cantidad As Integer) As List(Of EE.Stocksucursal)
        Dim lista As New List(Of EE.Stocksucursal)
        For Each n In sc
            If n.cantidad >= cantidad Then
                n.requerirstock = False
            Else
                n.requerirstock = True
            End If

            If n.requerirstock = False Then
                lista.Add(n)
            End If
        Next

        For Each n In lista
            sc.Remove(n)
        Next


        Return sc
    End Function
End Class
