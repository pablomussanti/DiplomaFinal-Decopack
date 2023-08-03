Imports EE
Imports MPP
Public Class BLLstockdeposito
    Public Function aumentarstock(ByVal stockdeposito As EE.Stockdeposito, valor As Integer) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPstockdeposito
        stockdeposito.cantidad = valor + stockdeposito.cantidad
        resultado = oMPP.aumentarstock(stockdeposito)
        Return resultado
    End Function

    Public Function generarstock(ByVal stockdeposito As EE.Stockdeposito) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPstockdeposito
        resultado = oMPP.generarstock(stockdeposito)
        Return resultado
    End Function

    Public Function reducirstock(ByVal stockdeposito As EE.Stockdeposito, valor As Integer) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPstockdeposito
        stockdeposito.cantidad = stockdeposito.cantidad - valor
        resultado = oMPP.Reducirstock(stockdeposito)
        Return resultado
    End Function

    Public Function Listarstock() As List(Of EE.Stockdeposito)
        Dim lista As New List(Of EE.Stockdeposito)
        Dim oMPP As New MPPstockdeposito
        lista = oMPP.Listarstock()
        Return lista
    End Function

    Public Function Verificarfaltantestock(sc As List(Of EE.Stockdeposito), cantidad As Integer) As List(Of EE.Stockdeposito)
        Dim lista As New List(Of EE.Stockdeposito)
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
