Imports EE
Imports DAL
Public Class MPPproducto

    Public Function Crearproducto(ByVal producto As Producto) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Producto_Crear"

        If (producto.codigo <> 0) Then
            hdatos.Add("@codproducto", producto.codigo)
            consulta = "s_Producto_Modificar"
        End If

        hdatos.Add("@nombre", producto.nombre)
        hdatos.Add("@precio", producto.precio)
        hdatos.Add("@descripcion", producto.descripcion)
        hdatos.Add("@dvh", producto.dvh)
        hdatos.Add("@estado", producto.estado)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Eliminarproducto(ByVal producto As Producto) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codproducto", producto.codigo)

        resultado = oDatos.Escribir("s_Producto_Eliminar", hdatos)

        Return resultado

    End Function

    Public Function Listarproductotodo() As List(Of Producto)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Producto)
        Dim dato3 As Producto

        DS = oDatos.Leer("s_Producto_Listartodo", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Producto
                dato3.nombre = Item("Nombre")
                dato3.precio = Item("Precio")
                dato3.descripcion = Item("Descripcion")
                dato3.dvh = Item("DVH")
                dato3.estado = Item("Estado")
                dato3.codigo = Item("Codproducto")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function

    Public Function Listarproducto() As List(Of Producto)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Producto)
        Dim dato3 As Producto

        DS = oDatos.Leer("s_Producto_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Producto
                dato3.nombre = Item("Nombre")
                dato3.precio = Item("Precio")
                dato3.descripcion = Item("Descripcion")
                dato3.dvh = Item("DVH")
                dato3.estado = Item("Estado")
                dato3.codigo = Item("Codproducto")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function

    Public Function Listarproductoporsucursal(sucursal As EE.Sucursal) As List(Of Producto)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Producto)
        Dim dato3 As Producto
        Dim hdatos As New Hashtable


        hdatos.Add("@codsucursal", sucursal.codigo)

        DS = oDatos.Leer("s_Producto_Sucursal", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Producto
                dato3.nombre = Item("Nombre")
                dato3.descripcion = Item("Descripcion")
                dato3.precio = Item("Precio")
                dato3.estado = Item("Estado")
                dato3.dvh = Item("DVH")
                dato3.codigo = Item("Codproducto")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function

    Public Function Creardvv(ByVal dato1 As String) As Boolean
        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Productodvv_Generar"
        hdatos.Add("@nombre", "Producto")
        hdatos.Add("@dvv", dato1)
        resultado = oDatos.Escribir(consulta, hdatos)
        Return resultado
    End Function

    Public Function Listardvv() As List(Of Servicios.DVV)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.DVV)
        Dim dato3 As Servicios.DVV

        DS = oDatos.Leer("s_Productodvv_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.DVV
                dato3.entidad = Item("Entidad")
                dato3.dvv = Item("DVV")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function

    Public Function Actualizardvv(ByVal dato1 As String) As Boolean
        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Productodvv_Actualizar"
        hdatos.Add("@nombre", "Producto")
        hdatos.Add("@dvv", dato1)
        resultado = oDatos.Escribir(consulta, hdatos)
        Return resultado
    End Function

    Public Function Resguardarentidad(ByVal dato1 As Servicios.CCproducto) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_CCProducto_Crear"

        hdatos.Add("@nombre", dato1.Nombre)
        hdatos.Add("@descripcion", dato1.Descripcion)
        hdatos.Add("@usuario", dato1.Usuario)
        hdatos.Add("@tipo", dato1.Tipo)
        hdatos.Add("@fecha", dato1.Fecha)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function


    Public Function Listarentidad() As List(Of Servicios.CCproducto)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.CCproducto)
        Dim dato3 As Servicios.CCproducto


        DS = oDatos.Leer("s_CCproducto_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.CCproducto
                dato3.nombre = Item("Nombre")
                dato3.descripcion = Item("Descripcion")
                dato3.Fecha = Item("Fecha")
                dato3.codigo = Item("Codccproducto")
                dato3.Tipo = Item("Tipo")
                dato3.Usuario = Item("Usuario")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function
End Class
