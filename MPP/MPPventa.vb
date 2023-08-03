Imports DAL
Imports EE
Public Class MPPventa
    Public Function Crear(ByVal venta As EE.Venta) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Venta_Crear"

        hdatos.Add("@codempleado", venta.empleado.codigo)
        hdatos.Add("@estado", venta.estado)
        hdatos.Add("@fecha", venta.fecha)
        hdatos.Add("@monto", venta.monto)
        hdatos.Add("@codcomprador", venta.comprador.codigo)
        hdatos.Add("@codsucursal", venta.sucursal.codigo)
        hdatos.Add("@pagado", venta.pagado)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificar(ByVal venta As EE.Venta) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Venta_Modificar"

        hdatos.Add("@codventa", venta.codigo)
        hdatos.Add("@codempleado", venta.empleado.codigo)
        hdatos.Add("@estado", venta.estado)
        hdatos.Add("@fecha", venta.fecha)
        hdatos.Add("@monto", venta.monto)
        hdatos.Add("@codcomprador", venta.comprador.codigo)
        hdatos.Add("@codsucursal", venta.sucursal.codigo)
        hdatos.Add("@pagado", venta.pagado)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminar(ByVal venta As EE.Venta) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codventa", venta.codigo)

        resultado = oDatos.Escribir("s_Venta_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listar() As List(Of Venta)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Venta)
        Dim dato3 As Venta

        DS = oDatos.Leer("s_Venta_Listar", Nothing)








        If DS.Tables(0).Rows.Count > 0 Then

            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(3).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .estado = r("Estado"),
                    .detalle = r("Detalle")})

            Next




            Dim llll = New List(Of Comprador)

            For Each r In DS.Tables(2).Rows
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

            For Each r In DS.Tables(1).Rows
                lllll.Add(New Empleadosucursal With {
                    .codigo = r("Codempleadosucursal"),
                    .nombre = r("Nombre"),
                    .apellido = r("Apellido"),
                     .estado = r("Estado"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codsucursal")))})
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Venta
                dato3.codigo = Item("Codventa")

                dato3.empleado = lllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codempleado")))

                dato3.comprador = llll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codcomprador")))

                dato3.sucursal = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codsucursal")))

                dato3.pagado = Item("Pagado")
                dato3.estado = Item("Estado")
                dato3.fecha = Item("Fecha")
                dato3.monto = Item("Monto")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If

    End Function

    Public Function Listargrande() As List(Of Venta)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Venta)
        Dim dato3 As Venta

        DS = oDatos.Leer("s_Venta_Listargrande", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(3).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next




            Dim llll = New List(Of Comprador)

            For Each r In DS.Tables(2).Rows
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

            For Each r In DS.Tables(1).Rows
                lllll.Add(New Empleadosucursal With {
                    .codigo = r("Codempleadosucursal"),
                    .nombre = r("Nombre"),
                    .apellido = r("Apellido"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codsucursal")))})
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Venta
                dato3.codigo = Item("Codventa")

                dato3.empleado = lllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codempleado")))

                dato3.comprador = llll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codcomprador")))

                dato3.sucursal = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codsucursal")))

                dato3.pagado = Item("Pagado")
                dato3.estado = Item("Estado")
                dato3.fecha = Item("Fecha")
                dato3.monto = Item("Monto")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function


    Public Function Listarenvio() As List(Of Venta)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Venta)
        Dim dato3 As Venta

        DS = oDatos.Leer("s_Venta_Traerenvio", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(3).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next




            Dim llll = New List(Of Comprador)

            For Each r In DS.Tables(2).Rows
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

            For Each r In DS.Tables(1).Rows
                lllll.Add(New Empleadosucursal With {
                    .codigo = r("Codempleadosucursal"),
                    .nombre = r("Nombre"),
                    .apellido = r("Apellido"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codsucursal")))})
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Venta
                dato3.codigo = Item("Codventa")

                dato3.empleado = lllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codempleado")))

                dato3.comprador = llll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codcomprador")))

                dato3.sucursal = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codsucursal")))

                dato3.pagado = Item("Pagado")
                dato3.estado = Item("Estado")
                dato3.fecha = Item("Fecha")
                dato3.monto = Item("Monto")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If

    End Function
End Class
