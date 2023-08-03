Imports EE
Imports DAL
Public Class MPPempleadodeposito

    Public Function Crearempleadodeposito(ByVal empleadodeposito As EE.Empleadodeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Empleadodeposito_Crear"

        hdatos.Add("@apellido", empleadodeposito.apellido)
        hdatos.Add("@email", empleadodeposito.email)
        hdatos.Add("@fechadeingreso", empleadodeposito.fechadeingreso)
        hdatos.Add("@coddeposito", empleadodeposito.localizacion.codigo)
        hdatos.Add("@nombre", empleadodeposito.nombre)
        hdatos.Add("@telefono", empleadodeposito.telefono)
        hdatos.Add("@estado", empleadodeposito.estado)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Modificarempleadodeposito(ByVal empleadodeposito As EE.Empleadodeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Empleadodeposito_Modificar"

        hdatos.Add("@codempleadodeposito", empleadodeposito.codigo)
        hdatos.Add("@apellido", empleadodeposito.apellido)
        hdatos.Add("@email", empleadodeposito.email)
        hdatos.Add("@fechadeingreso", empleadodeposito.fechadeingreso)
        hdatos.Add("@coddeposito", empleadodeposito.localizacion.codigo)
        hdatos.Add("@nombre", empleadodeposito.nombre)
        hdatos.Add("@telefono", empleadodeposito.telefono)
        hdatos.Add("@estado", empleadodeposito.estado)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminarempleadodeposito(ByVal empleadodeposito As EE.Empleadodeposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codempleadodeposito", empleadodeposito.codigo)

        resultado = oDatos.Escribir("s_Empleadodeposito_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listarempleadodeposito() As List(Of Empleadodeposito)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Empleadodeposito)
        Dim dato3 As Empleadodeposito

        DS = oDatos.Leer("s_Empleadodeposito_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 And DS.Tables(1).Rows.Count > 0 Then
            Dim l = New List(Of Deposito)

            For Each r In DS.Tables(1).Rows
                l.Add(New Deposito With {
                    .codigo = r("Coddeposito"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                    .detalle = r("Detalle")})
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Empleadodeposito
                dato3.codigo = Item("Codempleadodeposito")
                dato3.apellido = Item("Apellido")
                dato3.email = Item("Email")
                dato3.nombre = Item("Nombre")
                dato3.telefono = Item("Telefono")
                dato3.fechadeingreso = Item("Fechadeingreso")
                dato3.estado = Item("Estado")
                dato3.localizacion = l.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Coddeposito")))
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
