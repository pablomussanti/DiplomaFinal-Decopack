Imports EE
Imports DAL
Public Class MPPsucursal
    Public Function Crearsucursal(ByVal sucursal As EE.Sucursal) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Sucursal_Crear"

        If (sucursal.codigo <> 0) Then
            hdatos.Add("@codsucursal", sucursal.codigo)
            consulta = "s_Sucursal_Modificar"
        End If

        hdatos.Add("@codigopostal", sucursal.codigopostal)
        hdatos.Add("@detalle", sucursal.detalle)
        hdatos.Add("@direccion", sucursal.direccion)
        hdatos.Add("@telefono", sucursal.telefono)
        hdatos.Add("@estado", sucursal.estado)
        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Eliminarsucursal(ByVal sucursal As EE.Sucursal) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codsucursal", sucursal.codigo)

        resultado = oDatos.Escribir("s_Sucursal_Eliminar", hdatos)

        Return resultado

    End Function

    Public Function Listarsucursal() As List(Of EE.Sucursal)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of EE.Sucursal)
        Dim dato3 As EE.Sucursal
        DS = oDatos.Leer("s_Sucursal_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New EE.Sucursal
                dato3.codigo = Item("Codsucursal")
                dato3.codigopostal = Item("Codigopostal")
                dato3.detalle = Item("Detalle")
                dato3.direccion = Item("Direccion")
                dato3.telefono = Item("Telefono")
                dato3.estado = Item("Estado")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function

    Public Function Traersucursal(sucursal As Sucursal) As Sucursal

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim objeto As New Sucursal
        Dim dato3 As EE.Sucursal
        Dim hdatos As New Hashtable

        hdatos.Add("@codsucursal", sucursal.codigo)


        DS = oDatos.Leer("s_Sucursal_Traersucursal", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New EE.Sucursal
                dato3.codigo = Item("Codsucursal")
                dato3.codigopostal = Item("Codigopostal")
                dato3.detalle = Item("Detalle")
                dato3.direccion = Item("Direccion")
                dato3.telefono = Item("Telefono")
                dato3.estado = Item("Estado")
                objeto = dato3
            Next

            Return objeto

        Else
            Return Nothing
        End If
    End Function
End Class
