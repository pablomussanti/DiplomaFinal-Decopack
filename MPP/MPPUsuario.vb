Imports Servicios
Imports DAL
Public Class MPPUsuario
    Public Function Crear(ByVal usuario As Servicios.Usuario) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Usuario_Crear"

        If (usuario.codigo <> 0) Then
            hdatos.Add("@codusuario", usuario.codigo)
            consulta = "s_Usuario_Modificar"
        End If

        hdatos.Add("@user", usuario.user)
        hdatos.Add("@contraseña", usuario.contraseña)
        hdatos.Add("@estadobloqueado", usuario.estadobloqueado)


        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado
    End Function

    Public Function Eliminar(ByVal usuario As Servicios.Usuario) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codusuario", usuario.codigo)

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
                dato3.User = Item("Username")
                dato3.Contraseña = Item("Contraseña")
                dato3.estadobloqueado = Item("Estadobloqueado")
                dato3.codigo = Item("Codusuario")
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

        Dim dato1 As New Servicios.Usuario
        dato1.estadobloqueado = True

        DS = oDatos.Leer("s_Usuario_Listarbloqueado", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Usuario
                dato3.user = Item("Username")
                dato3.Contraseña = Item("Contraseña")
                dato3.estadobloqueado = Item("Estadobloqueado")
                dato3.codigo = Item("Codusuario")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Confimarusuario(usuario As Servicios.Usuario) As List(Of Servicios.Usuario)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Usuario)
        Dim dato3 As Servicios.Usuario
        Dim hdatos As New Hashtable

        hdatos.Add("@user", usuario.user)
        hdatos.Add("@contraseña", usuario.contraseña)

        DS = oDatos.Leer("s_Usuario_Confirmar", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Usuario
                dato3.user = Item("Username")
                dato3.contraseña = Item("Contraseña")
                dato3.estadobloqueado = Item("Estadobloqueado")
                dato3.codigo = Item("Codusuario")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
