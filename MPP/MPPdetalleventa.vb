Imports DAL
Imports EE
Public Class MPPdetalleventa
    Public Function Generardetalle(ByVal detalle As EE.Detalleventa) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Detalleventa_Crear"

        hdatos.Add("@cantidad", detalle.cantidad)
        hdatos.Add("@precio", detalle.precio)
        hdatos.Add("@codproducto", detalle.producto.codigo)
        hdatos.Add("@codventa", detalle.venta.codigo)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminardetalle(ByVal venta As Venta) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Detalleventa_Eliminar"


        hdatos.Add("@codventa", venta.codigo)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Listardetalle(venta As Venta) As List(Of Detalleventa)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Detalleventa)
        Dim dato3 As Detalleventa
        Dim hdatos As New Hashtable

        hdatos.Add("@codventa", venta.codigo)

        DS = oDatos.Leer("s_Detalleventa_Listar", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then


            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(2).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                     .estado = r("Estado"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next



            Dim ll = New List(Of Producto)

            For Each Item As DataRow In DS.Tables(1).Rows

                ll.Add(New Producto With {
                 .nombre = Item("Nombre"),
                .precio = Item("Precio"),
                 .estado = Item("Estado"),
                .descripcion = Item("Descripcion"),
                .dvh = Item("DVH"),
                .codigo = Item("Codproducto")})
            Next

            Dim llll = New List(Of Comprador)

            For Each r In DS.Tables(3).Rows
                If r("Socioestado") = "Si" Then
                    llll.Add(New Socio With {
                    .codigo = r("Codcomprador"),
                    .apellido = r("Apellido"),
                    .dni = r("Dni"),
                    .domicilio = r("Domicilio"),
                    .estado = r("Estado"),
                    .mail = r("Mail"),
                    .nombre = r("Nombre"),
                    .telefono = r("Telefono")
                         })
                Else
                    llll.Add(New Cliente With {
                    .codigo = r("Codcomprador"),
                    .apellido = r("Apellido"),
                    .dni = r("Dni"),
                    .domicilio = r("Domicilio"),
                    .estado = r("Estado"),
                    .mail = r("Mail"),
                    .nombre = r("Nombre"),
                    .telefono = r("Telefono")
                         })
                End If
            Next

            Dim lllll = New List(Of Empleadosucursal)

            For Each r In DS.Tables(4).Rows
                lllll.Add(New Empleadosucursal With {
                    .codigo = r("Codempleadosucursal"),
                    .nombre = r("Nombre"),
                     .estado = r("Estado"),
                    .apellido = r("Apellido"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codsucursal")))})
            Next



            Dim lll = New List(Of Venta)

            For Each r In DS.Tables(5).Rows
                lll.Add(New Venta With {
                    .codigo = r("Codventa"),
                    .comprador = llll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codcomprador"))),
                    .empleado = lllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codempleado"))),
                    .estado = r("Estado"),
                    .fecha = r("Fecha"),
                    .monto = r("Monto"),
                    .sucursal = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codsucursal"))),
                    .pagado = r("Pagado")})
            Next



            For Each Item As DataRow In DS.Tables(0).Rows

                dato3 = New Detalleventa

                dato3.venta = lll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codventa")))

                dato3.producto = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproducto")))

                dato3.cantidad = Item("Cantidad")
                dato3.precio = Item("Precio")

                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
