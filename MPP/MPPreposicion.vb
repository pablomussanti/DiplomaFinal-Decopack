Imports EE
Imports DAL
Public Class MPPreposicion
    Public Function Crearreposicion(ByVal reposicion As EE.Reposicion) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Reposicion_Crear"

        hdatos.Add("@cantidad", reposicion.cantidad)
        hdatos.Add("@coddeposito", reposicion.deposito.codigo)
        hdatos.Add("@estado", reposicion.estado)
        hdatos.Add("@fecha", reposicion.fecha)
        hdatos.Add("@codproducto", reposicion.producto.codigo)
        hdatos.Add("@codsucursal", reposicion.sucursal.codigo)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificarreposicion(ByVal reposicion As EE.Reposicion) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Reposicion_Modificar"

        hdatos.Add("@codreposicion", reposicion.codigo)
        hdatos.Add("@cantidad", reposicion.cantidad)
        hdatos.Add("@coddeposito", reposicion.deposito.codigo)
        hdatos.Add("@estado", reposicion.estado)
        hdatos.Add("@fecha", reposicion.fecha)
        hdatos.Add("@codproducto", reposicion.producto.codigo)
        hdatos.Add("@codsucursal", reposicion.sucursal.codigo)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminarreposicion(ByVal reposicion As EE.Reposicion) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codreposicion", reposicion.codigo)

        resultado = oDatos.Escribir("s_Reposicion_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listarreposicion() As List(Of Reposicion)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Reposicion)
        Dim dato3 As Reposicion

        DS = oDatos.Leer("s_Reposicion_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then


            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(3).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                     .estado = r("Estado"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next

            Dim llllllll = New List(Of Deposito)

            For Each r In DS.Tables(2).Rows
                llllllll.Add(New Deposito With {
                    .codigo = r("Coddeposito"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next

            Dim ll = New List(Of Producto)

            For Each Item As DataRow In DS.Tables(1).Rows

                ll.Add(New Producto With {
                 .nombre = Item("Nombre"),
                  .estado = Item("Estado"),
                .precio = Item("Precio"),
                .descripcion = Item("Descripcion"),
                .dvh = Item("DVH"),
                .codigo = Item("Codproducto")})
            Next



            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Reposicion
                dato3.codigo = Item("Codreposicion")
                dato3.cantidad = Item("Cantidad")

                dato3.deposito = llllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Coddeposito")))

                dato3.estado = Item("Estado")
                dato3.fecha = Item("Fecha")

                dato3.producto = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproducto")))


                dato3.sucursal = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codsucursal")))
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
