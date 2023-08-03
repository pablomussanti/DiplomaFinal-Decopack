Imports DAL
Imports EE

Public Class MPPempleadosucursal

    Public Function Crearempleadosucursal(ByVal empleadosucursal As EE.Empleadosucursal) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Empleadosucursal_Crear"

        hdatos.Add("@apellido", empleadosucursal.apellido)
        hdatos.Add("@email", empleadosucursal.email)
        hdatos.Add("@fechadeingreso", empleadosucursal.fechadeingreso)
        hdatos.Add("@codsucursal", empleadosucursal.localizacion.codigo)
        hdatos.Add("@nombre", empleadosucursal.nombre)
        hdatos.Add("@telefono", empleadosucursal.telefono)
        hdatos.Add("@estado", empleadosucursal.estado)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificarempleadosucursal(ByVal empleadosucursal As EE.Empleadosucursal) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Empleadosucursal_Modificar"

        hdatos.Add("@codempleadosucursal", empleadosucursal.codigo)
        hdatos.Add("@apellido", empleadosucursal.apellido)
        hdatos.Add("@email", empleadosucursal.email)
        hdatos.Add("@fechadeingreso", empleadosucursal.fechadeingreso)
        hdatos.Add("@codsucursal", empleadosucursal.localizacion.codigo)
        hdatos.Add("@nombre", empleadosucursal.nombre)
        hdatos.Add("@telefono", empleadosucursal.telefono)
        hdatos.Add("@estado", empleadosucursal.estado)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminarempleadosucursal(ByVal empleadosucursal As EE.Empleadosucursal) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codempleadosucursal", empleadosucursal.codigo)

        resultado = oDatos.Escribir("s_Empleadosucursal_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listarempleadosucursal() As List(Of Empleadosucursal)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Empleadosucursal)

        DS = oDatos.Leer("s_Empleadosucursal_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 And DS.Tables(1).Rows.Count > 0 Then

            Dim l = New List(Of Sucursal)

            For Each r In DS.Tables(1).Rows
                l.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                     .estado = r("Estado"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                lista.Add(New Empleadosucursal With {
                    .codigo = Item("Codempleadosucursal"),
                    .apellido = Item("Apellido"),
                    .email = Item("Email"),
                    .nombre = Item("Nombre"),
                    .estado = Item("Estado"),
                    .telefono = Item("Telefono"),
                    .fechadeingreso = Item("Fechadeingreso"),
                    .localizacion = l.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codsucursal")))
                })
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Listarempleadoporsucursal(sucursal As Sucursal) As List(Of Empleadosucursal)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Empleadosucursal)
        Dim dato3 As Empleadosucursal
        Dim hdatos As New Hashtable

        hdatos.Add("@codsucursal", sucursal.codigo)

        DS = oDatos.Leer("s_Empleadosucursal_Listarporsucursal", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            Dim l = New List(Of Sucursal)

            For Each r In DS.Tables(1).Rows
                l.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .estado = r("Estado"),
                    .detalle = r("Detalle")})
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                lista.Add(New Empleadosucursal With {
                    .codigo = Item("Codempleadosucursal"),
                    .apellido = Item("Apellido"),
                    .email = Item("Email"),
                    .nombre = Item("Nombre"),
                    .estado = Item("Estado"),
                    .telefono = Item("Telefono"),
                    .fechadeingreso = Item("Fechadeingreso"),
                    .localizacion = l.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codsucursal")))
                })
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function

End Class