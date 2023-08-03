Imports Servicios
Imports DAL
Public Class MPPUsuario
    Public Function Crear(ByVal dato1 As Servicios.Usuario) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Usuario_Crear"

        If (dato1.codusuario <> 0) Then
            hdatos.Add("@codusuario", dato1.codusuario)
            consulta = "s_Usuario_Modificar"
        End If

        hdatos.Add("@user", dato1.User)
        hdatos.Add("@contraseña", dato1.Contraseña)
        hdatos.Add("@estadobloqueado", dato1.estadobloqueado)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminar(ByVal dato2 As Servicios.Usuario) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codusuario", dato2.codusuario)

        resultado = oDatos.Escribir("s_Usuario_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Listar() As List(Of Servicios.Usuario)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Usuario)
        Dim dato3 As Servicios.Usuario

        DS = oDatos.Leer("s_Usuario_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Usuario
                dato3.User = Item("User")
                dato3.Contraseña = Item("Contraseña")
                dato3.estadobloqueado = Item("Estadobloqueado")
                dato3.codusuario = Item("Codusuario")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function


    Public Function Listarbloqueados() As List(Of Servicios.Usuario)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Usuario)
        Dim dato3 As Servicios.Usuario
        Dim hdatos As New Hashtable
        Dim dato1 As New Servicios.Usuario
        dato1.estadobloqueado = True

        hdatos.Add("@estadobloqueado", dato1.estadobloqueado)

        DS = oDatos.Leer("s_Usuario_Listar", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Usuario
                dato3.User = Item("User")
                dato3.Contraseña = Item("Contraseña")
                dato3.estadobloqueado = Item("Estadobloqueado")
                dato3.codusuario = Item("Codusuario")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
