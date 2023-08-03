Imports EE
Imports MPP
Public Class BLLventa
    Public Function Crear(ByVal venta As EE.Venta) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPventa
        resultado = oMPP.Crear(venta)
        Return resultado
    End Function

    Public Function Modificar(ByVal venta As Venta) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPventa
        resultado = oMPP.Modificar(venta)
        Return resultado
    End Function

    Public Function Eliminar(ByVal venta As Venta) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPventa
        resultado = oMPP.Eliminar(venta)
        Return resultado
    End Function

    Public Function Listar() As List(Of Venta)
        Dim lista As New List(Of Venta)
        Dim oMPP As New MPPventa
        lista = oMPP.Listar()
        Return lista
    End Function

    Public Function Listargrande() As List(Of Venta)
        Dim lista As New List(Of Venta)
        Dim oMPP As New MPPventa
        lista = oMPP.Listargrande()
        Return lista
    End Function

    Public Function Listarenvio() As List(Of Venta)
        Dim lista As New List(Of Venta)
        Dim oMPP As New MPPventa
        lista = oMPP.Listarenvio()
        Return lista
    End Function

    Public Sub Calcularcobro(venta As EE.Venta, descuento As Double, descuento2 As Double, carrito As Carritomuestra, lstsocio As List(Of Comprador), lstcliente As List(Of Comprador))
        For Each nn In lstsocio
            If venta.comprador.codigo = nn.codigo Then
                venta.monto = venta.monto + carrito.monto
                venta.monto = venta.monto * descuento
            End If
        Next
        For Each nnn In lstcliente
            If venta.comprador.codigo = nnn.codigo Then
                venta.monto = venta.monto + carrito.monto
                venta.monto = venta.monto * descuento2
            End If
        Next
    End Sub

    Public Sub verificardisponibilidad(n As Carritomuestra, integridad1 As Integer, integridad2 As Integer, datos As List(Of Producto))
        If n.stockrequerido > n.stockdisponiblesucursal Then

            integridad1 = integridad1 + 1

            If integridad1 >= 1 Or integridad2 >= 1 Then
                Dim prd As New EE.Producto
                prd.nombre = n.producto.nombre
                datos.Add(prd)
            End If
        End If
        If n.stockrequerido > n.stockdisponibledeposito Then

            integridad2 = integridad2 + 1

            If integridad2 >= 1 Or integridad1 >= 1 Then
                Dim prd As New EE.Producto
                prd.nombre = n.producto.nombre
                datos.Add(prd)
            End If
        End If
    End Sub

    Public Function verificarpago(estado As String, pagado As String, pasador As Integer)

        If pagado = "Tarjeta" Then
            If estado = "En proceso" Then
                pasador = 1
            End If
            If estado = "Solo envio" Then
                pasador = 1
            End If
            If estado = "Solo sucursal" Then
                pasador = 1
            End If
        End If
        If pagado = "Efectivo" Then
            If estado = "En proceso" Then
                pasador = 1
            End If
            If estado = "Solo envio" Then
                pasador = 1
            End If
            If estado = "Solo sucursal" Then
                pasador = 1
            End If
        End If
        Return pasador
    End Function

    Public Sub verificacionsucursalproductos(proddispo As List(Of EE.Productomuestra), contador As Integer, n As Producto)
        Dim productonuevo As New Productomuestra
        If proddispo.Count = 0 Then
            productonuevo = New Productomuestra
            productonuevo.sucursal = True
            productonuevo.producto = n
            proddispo.Add(productonuevo)

        Else

            For Each prod In proddispo
                If prod.producto.codigo = n.codigo Then

                    prod.sucursal = True

                Else

                    contador = contador + 1

                End If

            Next
            If contador = proddispo.Count Then
                productonuevo = New Productomuestra
                productonuevo.sucursal = True
                productonuevo.producto = n
                proddispo.Add(productonuevo)
                contador = 0
            End If
        End If
    End Sub

    Public Sub verificarproductodeposito(proddispo As List(Of Productomuestra), contador As Integer, n As Producto)
        Dim productonuevo As New Productomuestra

        If proddispo.Count = 0 Then
            productonuevo = New Productomuestra
            productonuevo.deposito = True
            productonuevo.producto = n
            proddispo.Add(productonuevo)

        Else

            For Each prod In proddispo
                If prod.producto.codigo = n.codigo Then

                    prod.deposito = True


                Else

                    contador = contador + 1

                End If


            Next

            If contador = proddispo.Count Then
                productonuevo = New Productomuestra
                productonuevo.deposito = True
                productonuevo.producto = n
                proddispo.Add(productonuevo)
                contador = 0
            End If

        End If
    End Sub

    Public Sub asignarstockdelasucursal(lststocksucursal As List(Of EE.Stocksucursal), carritomuestra As Carritomuestra, sucursalelegida As Sucursal)

        For Each stock In lststocksucursal
            If sucursalelegida.codigo = stock.sucursal.codigo Then

                If carritomuestra.producto.codigo = stock.producto.codigo Then

                    carritomuestra.stockdisponiblesucursal = stock.cantidad


                End If


            End If

        Next

    End Sub

    Public Sub asignarstockdeldeposito(lststockdeposito As List(Of EE.Stockdeposito), carritomuestra As Carritomuestra, depo As Deposito)

        For Each stock In lststockdeposito

            If depo.codigo = stock.deposito.codigo Then

                If carritomuestra.producto.codigo = stock.producto.codigo Then

                    carritomuestra.stockdisponibledeposito = stock.cantidad


                End If


            End If

        Next

    End Sub

    Public Sub asignarpreciocarritomuestra(lstdetodoslosproductos As List(Of EE.Producto), carritomuestra As Carritomuestra)

        For Each prod In lstdetodoslosproductos

            If prod.codigo = carritomuestra.producto.codigo Then

                carritomuestra.monto = carritomuestra.stockrequerido * prod.precio

            End If

        Next
    End Sub

    Public Sub agregarstockalcarrito(n As Carritomuestra, carritomuestra As Carritomuestra)
        n.stockrequerido = n.stockrequerido + carritomuestra.stockrequerido
        n.monto = n.monto + carritomuestra.monto
    End Sub
End Class
