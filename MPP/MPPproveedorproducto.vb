Imports DAL
Imports EE
Public Class MPPproveedorproducto
    Public Function Creardetalle(ByVal proveedorproducto As EE.proveedorproducto) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Proveedorproducto_Crear"

        hdatos.Add("@codproveedor", proveedorproducto.proveedor.codigo)
        hdatos.Add("@codproducto", proveedorproducto.producto.codigo)
        hdatos.Add("@precio", proveedorproducto.precio)



        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificardetalle(ByVal proveedorproducto As EE.proveedorproducto) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Proveedorproducto_Modificar"

        hdatos.Add("@codproveedor", proveedorproducto.proveedor.codigo)
        hdatos.Add("@codproducto", proveedorproducto.producto.codigo)
        hdatos.Add("@precio", proveedorproducto.precio)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminardetalle(ByVal proveedorproducto As EE.proveedorproducto) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codproducto", proveedorproducto.producto.codigo)
        hdatos.Add("@codproveedor", proveedorproducto.proveedor.codigo)

        resultado = oDatos.Escribir("s_Proveedorproducto_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listardetalle() As List(Of proveedorproducto)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of proveedorproducto)
        Dim dato3 As proveedorproducto

        DS = oDatos.Leer("s_Proveedorproducto_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then



            Dim ll = New List(Of Producto)

            For Each Item As DataRow In DS.Tables(2).Rows

                ll.Add(New Producto With {
                 .nombre = Item("Nombre"),
                .precio = Item("Precio"),
                .descripcion = Item("Descripcion"),
                .dvh = Item("DVH"),
                .codigo = Item("Codproducto")})
            Next

            Dim llllll = New List(Of Proveedor)

            For Each r In DS.Tables(1).Rows
                llllll.Add(New Proveedor With {
                    .cantidaddeerrores = r("Cantidaddeerrores"),
                    .codigo = r("Codproveedor"),
                    .direccion = r("Direccion"),
                    .nombre = r("Nombre"),
                    .telefono = r("Telefono")})
            Next



            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New proveedorproducto

                dato3.producto = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproducto")))

                dato3.proveedor = llllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproveedor")))

                dato3.precio = Item("Precio")

                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Traerdetalleporproducto(producto As Producto) As List(Of proveedorproducto)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of proveedorproducto)
        Dim dato3 As proveedorproducto
        Dim hdatos As New Hashtable

        hdatos.Add("@codproducto", producto.codigo)

        DS = oDatos.Leer("s_Proveedorproducto_Traerporproducto", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then



            Dim ll = New List(Of Producto)

            For Each Item As DataRow In DS.Tables(2).Rows

                ll.Add(New Producto With {
                 .nombre = Item("Nombre"),
                .precio = Item("Precio"),
                .descripcion = Item("Descripcion"),
                 .estado = Item("Estado"),
                .dvh = Item("DVH"),
                .codigo = Item("Codproducto")})
            Next

            Dim llllll = New List(Of Proveedor)

            For Each r In DS.Tables(1).Rows
                llllll.Add(New Proveedor With {
                    .cantidaddeerrores = r("Cantidaddeerrores"),
                    .codigo = r("Codproveedor"),
                    .direccion = r("Direccion"),
                     .estado = r("Estado"),
                    .nombre = r("Nombre"),
                    .telefono = r("Telefono")})
            Next



            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New proveedorproducto

                dato3.producto = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproducto")))

                dato3.proveedor = llllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproveedor")))

                dato3.precio = Item("Precio")

                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
