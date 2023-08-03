Imports DAL
Imports EE
Public Class MPPbitacora
    Public Function Generarbitacora(ByVal bitacora As Servicios.Bitacora) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Bitacora_Crear"


        hdatos.Add("@user", bitacora.user)
        hdatos.Add("@fecha", bitacora.fecha)
        hdatos.Add("@tipo", bitacora.tipo)
        hdatos.Add("@descripcion", bitacora.descripcion)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Listarbitacora() As List(Of Servicios.Bitacora)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Bitacora)
        Dim dato3 As Servicios.Bitacora

        DS = oDatos.Leer("s_Bitacora_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Bitacora
                dato3.user = Item("Username")
                dato3.descripcion = Item("Descripcion")
                dato3.tipo = Item("Tipo")
                dato3.fecha = Item("Fecha")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Listarporusuario(user As String) As List(Of Servicios.Bitacora)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Bitacora)
        Dim dato3 As Servicios.Bitacora
        Dim hdatos As New Hashtable
        hdatos.Add("@user", user)
        DS = oDatos.Leer("s_Bitacora_Listarporusuario", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Bitacora
                dato3.user = Item("Username")
                dato3.descripcion = Item("Descripcion")
                dato3.tipo = Item("Tipo")
                dato3.fecha = Item("Fecha")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function


    Public Function Listarerror() As List(Of Servicios.Bitacoraerror)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Bitacoraerror)
        Dim dato3 As Servicios.Bitacoraerror

        DS = oDatos.Leer("s_Bitacora_Listarerror", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Bitacoraerror
                dato3.user = Item("Username")
                dato3.descripcion = Item("Descripcion")
                dato3.tipo = Item("Tipo")
                dato3.fecha = Item("Fecha")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
