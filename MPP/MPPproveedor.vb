Imports EE
Imports DAL
Public Class MPPproveedor
    Public Function Crearproveedor(ByVal proveedor As EE.Proveedor) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Proveedor_Crear"

        hdatos.Add("@cantidaddeerrores", proveedor.cantidaddeerrores)
        hdatos.Add("@direccion", proveedor.direccion)
        hdatos.Add("@nombre", proveedor.nombre)
        hdatos.Add("@telefono", proveedor.telefono)
        hdatos.Add("@estado", proveedor.estado)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificarproveedor(ByVal proveedor As EE.Proveedor) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Proveedor_Modificar"

        hdatos.Add("@codproveedor", proveedor.codigo)
        hdatos.Add("@cantidaddeerrores", proveedor.cantidaddeerrores)
        hdatos.Add("@direccion", proveedor.direccion)
        hdatos.Add("@nombre", proveedor.nombre)
        hdatos.Add("@telefono", proveedor.telefono)
        hdatos.Add("@estado", proveedor.estado)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminarproveedor(ByVal proveedor As EE.Proveedor) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codproveedor", proveedor.codigo)

        resultado = oDatos.Escribir("s_Proveedor_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listarproveedor() As List(Of Proveedor)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Proveedor)
        Dim dato3 As Proveedor

        DS = oDatos.Leer("s_Proveedor_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Proveedor
                dato3.codigo = Item("Codproveedor")
                dato3.cantidaddeerrores = Item("Cantidaddeerrores")
                dato3.direccion = Item("Direccion")
                dato3.nombre = Item("Nombre")
                dato3.telefono = Item("Telefono")
                dato3.estado = Item("Estado")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
