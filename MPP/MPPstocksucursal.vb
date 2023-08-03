Imports EE
Imports DAL
Public Class MPPstocksucursal
    Public Function generarstock(ByVal stocksucursal As EE.Stocksucursal) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Stocksucursal_Crear"

        hdatos.Add("@codsucursal", stocksucursal.sucursal.codigo)
        hdatos.Add("@codproducto", stocksucursal.producto.codigo)
        hdatos.Add("@cantidad", stocksucursal.cantidad)
        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function aumentarstock(ByVal stocksucursal As EE.Stocksucursal) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Stocksucursal_Modificar"

        hdatos.Add("@codsucursal", stocksucursal.sucursal.codigo)
        hdatos.Add("@codproducto", stocksucursal.producto.codigo)
        hdatos.Add("@cantidad", stocksucursal.cantidad)
        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Reducirstock(ByVal stocksucursal As EE.Stocksucursal) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Stocksucursal_Modificar"

        hdatos.Add("@codsucursal", stocksucursal.sucursal.codigo)
        hdatos.Add("@codproducto", stocksucursal.producto.codigo)
        hdatos.Add("@cantidad", stocksucursal.cantidad)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Listarstock() As List(Of EE.Stocksucursal)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of EE.Stocksucursal)
        Dim dato3 As EE.Stocksucursal
        DS = oDatos.Leer("s_Stocksucursal_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(2).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                     .estado = r("Estado"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})

            Next


            Dim ll = New List(Of Producto)

            For Each Item As DataRow In DS.Tables(1).Rows

                ll.Add(New Producto With {
                 .nombre = Item("Nombre"),
                .precio = Item("Precio"),
                .descripcion = Item("Descripcion"),
                 .estado = Item("Estado"),
                .dvh = Item("DVH"),
                .codigo = Item("Codproducto")})
            Next


            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New EE.Stocksucursal
                dato3.cantidad = Item("Cantidad")

                dato3.sucursal = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codsucursal")))


                dato3.producto = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproducto")))


                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function
End Class
