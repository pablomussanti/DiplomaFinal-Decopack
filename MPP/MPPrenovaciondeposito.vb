Imports EE
Imports DAL
Public Class MPPrenovaciondeposito
    Public Function Crearrenovaciondeposito(ByVal renovaciondeposito As EE.Renovaciondeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Renovaciondeposito_Crear"

        hdatos.Add("@cantidad", renovaciondeposito.cantidad)
        hdatos.Add("@coddeposito", renovaciondeposito.deposito.codigo)
        hdatos.Add("@estado", renovaciondeposito.estado)
        hdatos.Add("@fecha", renovaciondeposito.fecha)
        hdatos.Add("@monto", renovaciondeposito.monto)
        hdatos.Add("@codproducto", renovaciondeposito.producto.codigo)
        hdatos.Add("@codproveedor", renovaciondeposito.proveedor.codigo)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificarrenovaciondeposito(ByVal renovaciondeposito As EE.Renovaciondeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Renovaciondeposito_Modificar"

        hdatos.Add("@codrenovaciondeposito", renovaciondeposito.codigo)
        hdatos.Add("@cantidad", renovaciondeposito.cantidad)
        hdatos.Add("@coddeposito", renovaciondeposito.deposito.codigo)
        hdatos.Add("@estado", renovaciondeposito.estado)
        hdatos.Add("@fecha", renovaciondeposito.fecha)
        hdatos.Add("@monto", renovaciondeposito.monto)
        hdatos.Add("@codproducto", renovaciondeposito.producto.codigo)
        hdatos.Add("@codproveedor", renovaciondeposito.proveedor.codigo)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminarrenovaciondeposito(ByVal renovaciondeposito As EE.Renovaciondeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codrenovaciondeposito", renovaciondeposito.codigo)

        resultado = oDatos.Escribir("s_Renovaciondeposito_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listarrenovaciondeposito() As List(Of Renovaciondeposito)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Renovaciondeposito)
        Dim dato3 As Renovaciondeposito

        DS = oDatos.Leer("s_Renovaciondeposito_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then



            Dim llllllll = New List(Of Deposito)

            For Each r In DS.Tables(3).Rows
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
                dato3 = New Renovaciondeposito
                dato3.codigo = Item("Codrenovaciondeposito")
                dato3.cantidad = Item("Cantidad")

                dato3.deposito = llllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Coddeposito")))

                dato3.estado = Item("Estado")
                dato3.fecha = Item("Fecha")
                dato3.monto = Item("Monto")


                dato3.producto = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproducto")))

                dato3.proveedor = llllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproveedor")))
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
