Imports EE
Imports DAL
Public Class MPPstockdeposito

    Public Function generarstock(ByVal stockdeposito As EE.Stockdeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Stockdeposito_Crear"

        hdatos.Add("@coddeposito", stockdeposito.deposito.codigo)
        hdatos.Add("@codproducto", stockdeposito.producto.codigo)
        hdatos.Add("@cantidad", stockdeposito.cantidad)
        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function aumentarstock(ByVal stockdeposito As EE.Stockdeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Stockdeposito_Modificar"

        hdatos.Add("@coddeposito", stockdeposito.deposito.codigo)
        hdatos.Add("@codproducto", stockdeposito.producto.codigo)
        hdatos.Add("@cantidad", stockdeposito.cantidad)
        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Reducirstock(ByVal stockdeposito As EE.Stockdeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Stockdeposito_Modificar"

        hdatos.Add("@coddeposito", stockdeposito.deposito.codigo)
        hdatos.Add("@codproducto", stockdeposito.producto.codigo)
        hdatos.Add("@cantidad", stockdeposito.cantidad)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Listarstock() As List(Of EE.Stockdeposito)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of EE.Stockdeposito)
        Dim dato3 As EE.Stockdeposito
        DS = oDatos.Leer("s_Stockdeposito_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

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
                .precio = Item("Precio"),
                 .estado = Item("Estado"),
                .descripcion = Item("Descripcion"),
                .dvh = Item("DVH"),
                .codigo = Item("Codproducto")})
            Next



            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New EE.Stockdeposito
                dato3.cantidad = Item("Cantidad")


                dato3.deposito = llllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Coddeposito")))


                dato3.producto = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codproducto")))


                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function

End Class
