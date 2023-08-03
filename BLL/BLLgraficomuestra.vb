Public Class BLLgraficomuestra


    Public Sub obtenermuestrafinal(listacompleta As List(Of EE.Detalleventa), lista As List(Of EE.GraficoMuestra))
        Dim cont As Integer = 0

        For Each n In listacompleta
            For Each nn In lista
                If n.producto.codigo = nn.producto.codigo Then
                    cont = cont + 1
                    nn.cantidad = nn.cantidad + n.cantidad
                    nn.precio = nn.precio + n.precio
                End If
            Next
        Next

    End Sub

End Class
