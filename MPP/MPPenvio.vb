Imports EE
Imports DAL
Public Class MPPenvio
    Public Function generarenvio(ByVal envio As EE.Envio) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Envio_Crear"

        hdatos.Add("@direccion", envio.direccion)
        hdatos.Add("@codempleado", envio.empleado.codigo)
        hdatos.Add("@fechadellegada", envio.fechadellegada)
        hdatos.Add("@fechadesalida", envio.fechadesalida)
        hdatos.Add("@estado", envio.estado)
        hdatos.Add("@codventa", envio.venta.codigo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificarenvio(ByVal envio As EE.Envio) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Envio_Modificar"

        hdatos.Add("@codenvio", envio.codigo)
        hdatos.Add("@estado", envio.estado)
        hdatos.Add("@direccion", envio.direccion)
        hdatos.Add("@codempleado", envio.empleado.codigo)
        hdatos.Add("@fechadellegada", envio.fechadellegada)
        hdatos.Add("@fechadesalida", envio.fechadesalida)
        hdatos.Add("@codventa", envio.venta.codigo)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminarenvio(ByVal envio As EE.Envio) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codenvio", envio.codigo)

        resultado = oDatos.Escribir("s_Envio_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listarenvio() As List(Of Envio)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Envio)
        Dim dato3 As Envio

        DS = oDatos.Leer("s_Envio_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then



            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(6).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next

            Dim llllllll = New List(Of Deposito)

            For Each r In DS.Tables(5).Rows
                llllllll.Add(New Deposito With {
                    .codigo = r("Coddeposito"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
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

            For Each r In DS.Tables(3).Rows
                lllll.Add(New Empleadosucursal With {
                    .codigo = r("Codempleadosucursal"),
                    .nombre = r("Nombre"),
                    .apellido = r("Apellido"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codsucursal")))})
            Next

            Dim llllll = New List(Of Empleadodeposito)

            For Each r In DS.Tables(2).Rows
                llllll.Add(New Empleadodeposito With {
                    .codigo = r("Codempleadodeposito"),
                    .apellido = r("Apellido"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = llllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Coddeposito")))})
            Next



            Dim lll = New List(Of Venta)

            For Each r In DS.Tables(1).Rows
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
                dato3 = New Envio
                dato3.codigo = Item("Codenvio")
                dato3.direccion = Item("Direccion")


                dato3.empleado = llllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codempleadodeposito")))
                dato3.estado = Item("Estado")

                dato3.fechadellegada = Item("Fechadellegada")
                dato3.fechadesalida = Item("Fechadesalida")


                dato3.venta = lll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codventa")))
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Listarenvioporempleado(empleadodeposito As Empleadodeposito) As List(Of Envio)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Envio)
        Dim dato3 As Envio

        Dim hdatos As New Hashtable

        hdatos.Add("@codempleado", empleadodeposito.codigo)

        DS = oDatos.Leer("s_Envio_Porempleado", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then



            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(6).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next

            Dim llllllll = New List(Of Deposito)

            For Each r In DS.Tables(5).Rows
                llllllll.Add(New Deposito With {
                    .codigo = r("Coddeposito"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
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

            For Each r In DS.Tables(3).Rows
                lllll.Add(New Empleadosucursal With {
                    .codigo = r("Codempleadosucursal"),
                    .nombre = r("Nombre"),
                    .apellido = r("Apellido"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Codsucursal")))})
            Next

            Dim llllll = New List(Of Empleadodeposito)

            For Each r In DS.Tables(2).Rows
                llllll.Add(New Empleadodeposito With {
                    .codigo = r("Codempleadodeposito"),
                    .apellido = r("Apellido"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = llllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Coddeposito")))})
            Next



            Dim lll = New List(Of Venta)

            For Each r In DS.Tables(1).Rows
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
                dato3 = New Envio
                dato3.codigo = Item("Codenvio")
                dato3.direccion = Item("Direccion")


                dato3.empleado = llllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codempleadodeposito")))
                dato3.estado = Item("Estado")

                dato3.fechadellegada = Item("Fechadellegada")
                dato3.fechadesalida = Item("Fechadesalida")


                dato3.venta = lll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codventa")))
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Listarenviopordevolucion(empleadodeposito As Empleadodeposito) As List(Of Envio)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Envio)
        Dim dato3 As Envio
        Dim hdatos As New Hashtable

        hdatos.Add("@codempleado", empleadodeposito.codigo)

        DS = oDatos.Leer("s_Envio_Devolucion", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then



            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(6).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                     .estado = r("Estado"),
                    .detalle = r("Detalle")})
            Next

            Dim llllllll = New List(Of Deposito)

            For Each r In DS.Tables(5).Rows
                llllllll.Add(New Deposito With {
                    .codigo = r("Coddeposito"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
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

            For Each r In DS.Tables(3).Rows
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

            For Each r In DS.Tables(2).Rows
                llllll.Add(New Empleadodeposito With {
                    .codigo = r("Codempleadodeposito"),
                    .apellido = r("Apellido"),
                     .estado = r("Estado"),
                    .email = r("Email"),
                    .fechadeingreso = r("Fechadeingreso"),
                    .localizacion = llllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(r("Coddeposito")))})
            Next



            Dim lll = New List(Of Venta)

            For Each r In DS.Tables(1).Rows
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
                dato3 = New Envio
                dato3.codigo = Item("Codenvio")
                dato3.direccion = Item("Direccion")


                dato3.empleado = llllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codempleadodeposito")))
                dato3.estado = Item("Estado")

                dato3.fechadellegada = Item("Fechadellegada")
                dato3.fechadesalida = Item("Fechadesalida")


                dato3.venta = lll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codventa")))
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
