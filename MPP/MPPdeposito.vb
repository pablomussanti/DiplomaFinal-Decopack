Imports EE
Imports DAL
Public Class MPPdeposito
    Public Function Creardeposito(ByVal deposito As EE.Deposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Deposito_Crear"

        If (deposito.codigo <> 0) Then
            hdatos.Add("@coddeposito", deposito.codigo)
            consulta = "s_Deposito_Modificar"
        End If

        hdatos.Add("@codigopostal", deposito.codigopostal)
        hdatos.Add("@detalle", deposito.detalle)
        hdatos.Add("@direccion", deposito.direccion)
        hdatos.Add("@telefono", deposito.telefono)
        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Eliminardeposito(ByVal deposito As EE.Deposito) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@coddeposito", deposito.codigo)

        resultado = oDatos.Escribir("s_Deposito_Eliminar", hdatos)

        Return resultado

    End Function

    Public Function Listardeposito() As List(Of EE.Deposito)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of EE.Deposito)
        Dim dato3 As EE.Deposito
        DS = oDatos.Leer("s_Deposito_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New EE.Deposito
                dato3.codigo = Item("Coddeposito")
                dato3.codigopostal = Item("Codigopostal")
                dato3.detalle = Item("Detalle")
                dato3.direccion = Item("Direccion")
                dato3.telefono = Item("Telefono")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function
End Class
