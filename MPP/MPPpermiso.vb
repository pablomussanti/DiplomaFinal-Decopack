Imports DAL
Imports Servicios
Public Class MPPpermiso

    Public Function componenteListar() As List(Of Servicios.Rolpermiso)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim dato3 As Servicios.Rolpermiso
        Dim lista As New List(Of Servicios.Rolpermiso)

        DS = oDatos.Leer("s_Componente_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                If Item("Tipo") = "Rol" Then
                    dato3 = New Servicios.Rol()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                Else
                    dato3 = New Servicios.Permiso()
                    dato3.Nombre = Item("Nombre")
                    dato3.Tipo = Item("Tipo")
                    dato3.codigo = Item("Codcomponente")
                End If


                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Asignarpermisousuario(ByVal usuario As Servicios.Usuario, rol As Rolpermiso) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Permisousuario_Asignar"

        hdatos.Add("@codusuario", usuario.codigo)
        hdatos.Add("@codcomponente", rol.codigo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function desAsignarrolusuario(ByVal usuario As Servicios.Usuario, rol As Rolpermiso) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Permisousuario_Eliminar"

        hdatos.Add("@codusuario", usuario.codigo)
        hdatos.Add("@codcomponente", rol.codigo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function


    Public Function Eliminarrol(ByVal rol As Rol) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Componente_Eliminar"

        hdatos.Add("@codpermiso", rol.codigo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function generarrol(ByVal rol As Rolpermiso) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Componente_Crear"

        hdatos.Add("@nombre", rol.nombre)
        hdatos.Add("@tipo", rol.Tipo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function


    Public Function asociarpermiso(ByVal rol As Rol, Permiso As Rolpermiso) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_ComponenteComponente_Crear"

        hdatos.Add("@codpermiso1", rol.codigo)
        hdatos.Add("@codpermiso2", Permiso.codigo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function desasociarpermiso(ByVal rol As Rol, permiso As Rolpermiso) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_ComponenteComponente_Eliminar"

        hdatos.Add("@codpermiso1", rol.codigo)
        hdatos.Add("@codpermiso2", permiso.codigo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function



    Public Function traerpermisosusuario(usuario As Usuario) As List(Of Servicios.Rolpermiso)

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim dato3 As Servicios.Rolpermiso
        Dim lista As New List(Of Servicios.Rolpermiso)
        Dim consulta As String = "s_ComponenteComponente_Traerusuario"

        hdatos.Add("@codusuario", usuario.codigo)

        DS = oDatos.Leer(consulta, hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                If Item("Tipo") = "Rol" Then
                    dato3 = New Servicios.Rol()
                    dato3.Nombre = Item("Nombre")
                    dato3.Tipo = Item("Tipo")
                    dato3.codigo = Item("Codcomponente")
                Else
                    dato3 = New Servicios.Permiso()
                    dato3.Nombre = Item("Nombre")
                    dato3.Tipo = Item("Tipo")
                    dato3.codigo = Item("Codcomponente")
                End If


                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Listarpermisousuario() As List(Of Servicios.Permisousuario)

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim dato3 As Servicios.Permisousuario
        Dim lista As New List(Of Servicios.Permisousuario)
        Dim consulta As String = "s_Permisousuario_Listar"

        DS = oDatos.Leer(consulta, Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            Dim lllllll = New List(Of Rolpermiso)

            For Each r In DS.Tables(1).Rows
                If r("Tipo") = "Rol" Then
                    lllllll.Add(New Rol With {
                 .codigo = r("Codcomponente"),
                 .nombre = r("Nombre"),
                 .Tipo = r("Tipo")})
                Else
                    lllllll.Add(New Permiso With {
                 .codigo = r("Codcomponente"),
                 .nombre = r("Nombre"),
                 .Tipo = r("Tipo")})
                End If

            Next

            Dim ll = New List(Of Usuario)

            For Each r In DS.Tables(2).Rows
                ll.Add(New Usuario With {
                    .codigo = r("Codusuario"),
                    .contraseña = r("Contraseña"),
                    .estadobloqueado = r("Estadobloqueado"),
                    .user = r("Username")})
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Permisousuario
                dato3.permiso = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codcomponente")))
                dato3.usuario = ll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codusuario")))
                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Listarrol() As List(Of Servicios.Rolpermiso)



        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Rolpermiso)
        Dim dato3 As New Rol

        DS = oDatos.Leer("s_Componente_Listarrol", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                Dim dato2 As New Rol
                dato2.codigo = Item("Codcomponente")
                dato2.Nombre = Item("Nombre")
                dato2.Tipo = Item("Tipo")
                dato3 = dato2
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If

    End Function

    Public Function Listarpermisos() As List(Of Servicios.Rolpermiso)



        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Rolpermiso)
        Dim dato3 As New Rol

        DS = oDatos.Leer("s_Componente_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                Dim dato2 As New Rol
                dato2.codigo = Item("Codcomponente")
                dato2.nombre = Item("Nombre")
                dato2.Tipo = Item("Tipo")
                dato3 = dato2
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If

    End Function

    Public Function traerpermisosrol(rol As Rol) As List(Of Servicios.Rolpermiso)

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim dato3 As Servicios.Rolpermiso
        Dim lista As New List(Of Servicios.Rolpermiso)
        Dim consulta As String = "s_ComponenteComponente_Traerpermiso"

        hdatos.Add("@codcomponente", rol.codigo)

        DS = oDatos.Leer(consulta, hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                If Item("Tipo") = "Rol" Then
                    dato3 = New Servicios.Rol()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                Else
                    dato3 = New Servicios.Permiso()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                End If
                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function traerpermisofaltante(rol As Rol) As List(Of Servicios.Rolpermiso)

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim dato3 As Servicios.Rolpermiso
        Dim lista As New List(Of Servicios.Rolpermiso)
        Dim consulta As String = "s_ComponenteComponente_Traerpermisofaltante"

        hdatos.Add("@codcomponente", rol.codigo)

        DS = oDatos.Leer(consulta, hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                If Item("Tipo") = "Rol" Then
                    dato3 = New Servicios.Rol()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                Else
                    dato3 = New Servicios.Permiso()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                End If
                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function traerrolusuario(usuario As Usuario) As List(Of Servicios.Rolpermiso)

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim dato3 As Servicios.Rolpermiso
        Dim lista As New List(Of Servicios.Rolpermiso)
        Dim consulta As String = "s_Permisousuario_Traer"

        hdatos.Add("@codusuario", usuario.codigo)

        DS = oDatos.Leer(consulta, hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                If Item("Tipo") = "Rol" Then
                    dato3 = New Servicios.Rol()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                Else
                    dato3 = New Servicios.Permiso()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                End If
                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function verificarpermisoexistente(permiso As Permiso) As List(Of Servicios.Rolpermiso)

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim dato3 As Servicios.Rolpermiso
        Dim lista As New List(Of Servicios.Rolpermiso)
        Dim consulta As String = "s_Componente_Verificar"

        hdatos.Add("@nombre", permiso.nombre)

        DS = oDatos.Leer(consulta, hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                If Item("Tipo") = "Rol" Then
                    dato3 = New Servicios.Rol()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                Else
                    dato3 = New Servicios.Permiso()
                    dato3.nombre = Item("Nombre")
                    dato3.codigo = Item("Codcomponente")
                    dato3.Tipo = Item("Tipo")
                End If
                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function


End Class
