Imports EE
Imports DAL
Public Class MPPComprador
    Public Function generarcliente(ByVal comprador As EE.Comprador) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Comprador_Crear"

        If (comprador.codigo <> 0) Then
            hdatos.Add("@codcomprador", comprador.codigo)
            consulta = "s_Comprador_Modificar"
        End If

        hdatos.Add("@nombre", comprador.nombre)
        hdatos.Add("@apellido", comprador.apellido)
        hdatos.Add("@mail", comprador.mail)
        hdatos.Add("@dni", comprador.dni)
        hdatos.Add("@domicilio", comprador.domicilio)
        hdatos.Add("@telefono", comprador.telefono)
        If TypeOf comprador Is EE.Cliente Then
            hdatos.Add("@socioestado", "No")
        Else
            hdatos.Add("@socioestado", "Si")
        End If
        hdatos.Add("@estado", comprador.estado)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Eliminarcomprador(ByVal comprador As Comprador) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codcomprador", comprador.codigo)

        resultado = oDatos.Escribir("s_Comprador_Eliminar", hdatos)

        Return resultado

    End Function

    Public Function Listarcompradoractivos(tipo As String) As List(Of Comprador)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Comprador)
        Dim dato3 As Comprador

        DS = oDatos.Leer("s_Comprador_Listaractivo", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                If tipo = "socio" Then
                    If Item("Socioestado") = "Si" Then
                        dato3 = New Socio
                        dato3.codigo = Item("Codcomprador")
                        dato3.nombre = Item("Nombre")
                        dato3.apellido = Item("Apellido")
                        dato3.mail = Item("Mail")
                        dato3.dni = Item("Dni")
                        dato3.domicilio = Item("Domicilio")
                        dato3.telefono = Item("Telefono")
                        dato3.estado = Item("Estado")
                        lista.Add(dato3)
                    End If
                Else
                    If Item("Socioestado") = "No" Then
                        dato3 = New Cliente
                        dato3.codigo = Item("Codcomprador")
                        dato3.nombre = Item("Nombre")
                        dato3.apellido = Item("Apellido")
                        dato3.mail = Item("Mail")
                        dato3.dni = Item("Dni")
                        dato3.domicilio = Item("Domicilio")
                        dato3.telefono = Item("Telefono")
                        dato3.estado = Item("Estado")
                        lista.Add(dato3)
                    End If
                End If


            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function

    Public Function Listartodosinactivos(tipo As String) As List(Of Comprador)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Comprador)
        Dim dato3 As Comprador

        DS = oDatos.Leer("s_Comprador_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                If tipo = "socio" Then
                    If Item("Socioestado") = "Si" Then
                        dato3 = New Socio
                        dato3.codigo = Item("Codcomprador")
                        dato3.nombre = Item("Nombre")
                        dato3.apellido = Item("Apellido")
                        dato3.mail = Item("Mail")
                        dato3.dni = Item("Dni")
                        dato3.domicilio = Item("Domicilio")
                        dato3.telefono = Item("Telefono")
                        dato3.estado = Item("Estado")
                        lista.Add(dato3)
                    End If
                Else
                    If Item("Socioestado") = "No" Then
                        dato3 = New Cliente
                        dato3.codigo = Item("Codcomprador")
                        dato3.nombre = Item("Nombre")
                        dato3.apellido = Item("Apellido")
                        dato3.mail = Item("Mail")
                        dato3.dni = Item("Dni")
                        dato3.domicilio = Item("Domicilio")
                        dato3.telefono = Item("Telefono")
                        dato3.estado = Item("Estado")
                        lista.Add(dato3)
                    End If
                End If
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function

    Public Function Buscarcomprador(dni As Integer)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim hdatos As New Hashtable

        hdatos.Add("@dni", dni)


        DS = oDatos.Leer("s_Comprador_Buscar", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            Return 0

        Else
            Return 1
        End If
    End Function

    Public Function Listarcompradortodos() As List(Of Comprador)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Comprador)
        Dim dato3 As Comprador

        DS = oDatos.Leer("s_Comprador_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows



                If Item("Socioestado") = "Si" Then
                    dato3 = New Socio
                    dato3.codigo = Item("Codcomprador")
                    dato3.nombre = Item("Nombre")
                    dato3.apellido = Item("Apellido")
                    dato3.mail = Item("Mail")
                    dato3.dni = Item("Dni")
                    dato3.domicilio = Item("Domicilio")
                    dato3.telefono = Item("Telefono")
                    dato3.estado = Item("Estado")
                    lista.Add(dato3)
                End If

                If Item("Socioestado") = "No" Then
                    dato3 = New Cliente
                    dato3.codigo = Item("Codcomprador")
                    dato3.nombre = Item("Nombre")
                    dato3.apellido = Item("Apellido")
                    dato3.mail = Item("Mail")
                    dato3.dni = Item("Dni")
                    dato3.domicilio = Item("Domicilio")
                    dato3.telefono = Item("Telefono")
                    dato3.estado = Item("Estado")
                    lista.Add(dato3)
                End If


            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function
End Class
