Imports EE
Imports DAL
Public Class MPPdevolucion
    Public Function generardevolucion(ByVal devolucion As EE.Devolucion) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Devolucion_Crear"

        hdatos.Add("@codenvio", devolucion.envio.codigo)
        hdatos.Add("@estado", devolucion.estado)
        hdatos.Add("@codproducto", devolucion.producto.codigo)
        hdatos.Add("@cantidad", devolucion.cantidad)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificardevolucion(ByVal devolucion As EE.Devolucion) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Devolucion_Modificar"

        hdatos.Add("@coddevolucion", devolucion.codigo)
        hdatos.Add("@codenvio", devolucion.envio.codigo)
        hdatos.Add("@estado", devolucion.estado)
        hdatos.Add("@codproducto", devolucion.producto.codigo)
        hdatos.Add("@cantidad", devolucion.cantidad)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminardevolucion(ByVal devolucion As EE.Devolucion) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@coddevolucion", devolucion.codigo)

        resultado = oDatos.Escribir("s_Devolucion_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listardevolucion() As List(Of Devolucion)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Devolucion)
        Dim dato3 As Devolucion

        DS = oDatos.Leer("s_Devolucion_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            Dim l = New List(Of Envio)

            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(7).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                     .estado = r("Estado"),
                    .detalle = r("Detalle")})
            Next

            Dim llllllll = New List(Of Deposito)

            For Each r In DS.Tables(8).Rows
                llllllll.Add(New Deposito With {
                    .codigo = r("Coddeposito"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next

            Dim ll = New List(Of Producto)

            For Each Item As DataRow In DS.Tables(2).Rows

                ll.Add(New Producto With {
                 .nombre = Item("Nombre"),
                .precio = Item("Precio"),
                 .estado = Item("Estado"),
                .descripcion = Item("Descripcion"),
                .dvh = Item("DVH"),
                .codigo = Item("Codproducto")})
            Next

            Dim llll = New List(Of Comprador)

            For Each r In DS.Tables(4).Rows
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

            For Each r In DS.Tables(5).Rows
                lllll.Add(New Empleadosucursal With {
                    .codigo = r("Codempleadosucursal"),
                    .nombre = r("Nombre"),
                    .apellido = r("Apellido"),
                     .estado = r("Estado"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codsucursal")))})
            Next

            Dim llllll = New List(Of Empleadodeposito)

            For Each r In DS.Tables(6).Rows
                llllll.Add(New Empleadodeposito With {
                    .codigo = r("Codempleadodeposito"),
                    .apellido = r("Apellido"),
                     .estado = r("Estado"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = llllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Coddeposito")))})
            Next



            Dim lll = New List(Of Venta)

            For Each r In DS.Tables(3).Rows
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

            For Each r In DS.Tables(1).Rows
                l.Add(New Envio With {
                    .codigo = r("Codenvio"),
                    .empleado = llllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codempleadodeposito"))),
                    .direccion = r("Direccion"),
                    .estado = r("Estado"),
                    .fechadesalida = r("Fechadesalida"),
                    .venta = lll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codventa"))),
                    .fechadellegada = r("Fechadellegada")})
            Next





            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Devolucion
                dato3.codigo = Item("Coddevolucion")

                dato3.envio = l.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codenvio")))
                dato3.estado = Item("Estado")

                dato3.producto = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproducto")))

                dato3.cantidad = Item("Cantidad")

                lista.Add(dato3)
            Next



            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
