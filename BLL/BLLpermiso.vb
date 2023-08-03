Imports Servicios
Imports EE
Imports MPP

Public Class BLLpermiso

    Public Function asignarpermisousuario(usuario As Servicios.Usuario, Permiso As Rolpermiso)
        Dim resultado As String
        Dim oMPP As New MPPpermiso
        resultado = oMPP.Asignarpermisousuario(usuario, Permiso)
        Return resultado
    End Function

    Public Function desasignarrolusuario(usuario As Servicios.Usuario, Permiso As Rolpermiso)
        Dim resultado As String
        Dim oMPP As New MPPpermiso
        resultado = oMPP.desAsignarrolusuario(usuario, Permiso)
        Return resultado
    End Function

    Public Function eliminarrol(rol As Rol)
        Dim resultado As String
        Dim oMPP As New MPPpermiso
        resultado = oMPP.Eliminarrol(rol)
        Return resultado
    End Function

    Public Function generarrolpermiso(rolpermiso As Rolpermiso)
        Dim resultado As String
        Dim oMPP As New MPPpermiso
        resultado = oMPP.generarrol(rolpermiso)
        Return resultado
    End Function

    Public Function asociarpermiso(rol As Rol, permisorol As Rolpermiso)
        Dim resultado As String
        Dim oMPP As New MPPpermiso
        resultado = oMPP.asociarpermiso(rol, permisorol)
        Return resultado
    End Function

    Public Function desasociarpermiso(rol As Rol, permisorol As Rolpermiso)
        Dim resultado As String
        Dim oMPP As New MPPpermiso
        resultado = oMPP.desasociarpermiso(rol, permisorol)
        Return resultado
    End Function

    'Public Function traerpermisos(usuario As Usuario)
    '    Dim lstpermisos As List(Of Rolpermiso)
    '    Dim oMPP As New MPPpermiso
    '    lstpermisos = Verificacionrol(oMPP.traerpermisosusuario(usuario))
    '    Return lstpermisos
    'End Function

    Public Function Verificacionrol()
        Dim lstpermisosrol As New List(Of Servicios.Rolpermiso)
        Dim lstrol As New List(Of Rol)
        Dim oMPP As New MPPpermiso


        lstpermisosrol = listarrolusuario(SesionManager._instancia)

        For Each n In lstpermisosrol
            If n.Tipo = "Rol" Then
                'lstpermisosrol.Add(n)
                lstrol.Add(n)
            Else
                'lstpermisosrol.Add(n)
            End If
        Next
        If lstrol IsNot Nothing Then
            For Each n In lstrol
                llenarpermisos(n)
            Next
        End If

        Return lstpermisosrol
    End Function

    Public Sub llenarpermisos(rol As Rol)
        Dim lstrol2 As New List(Of Rol)
        Dim permisosroles As New List(Of Rolpermiso)

        permisosroles = traerpermisosrol(rol)
        If permisosroles Is Nothing Then Exit Sub
        For Each n In permisosroles
            If n.Tipo = "Rol" Then
                lstrol2.Add(n)
                rol.Agregar(n)
            Else
                rol.Agregar(n)
            End If
        Next

        If lstrol2 IsNot Nothing Or lstrol2.Count = 0 Then
            For Each n In lstrol2
                llenarpermisos(n)
            Next
        End If

    End Sub

    Public Function obtenertodospermisos(lst As List(Of Rolpermiso))
        Dim lstpermisosrol As New List(Of Servicios.Rolpermiso)
        Dim lstrol As New List(Of Rol)
        Dim oMPP As New MPPpermiso


        lstpermisosrol = lst

        For Each n In lstpermisosrol
            If n.Tipo = "Rol" Then
                'lstpermisosrol.Add(n)
                lstrol.Add(n)
            Else
                'lstpermisosrol.Add(n)
            End If
        Next
        If lstrol IsNot Nothing Then
            For Each n In lstrol
                obtenertodospermisos2(lst, n)
            Next
        End If

        Return lstpermisosrol
    End Function

    Private Sub obtenertodospermisos2(lst As List(Of Rolpermiso), rol As Rol)
        Dim lstrol2 As New List(Of Rol)

        For Each n In rol.Mostrar
            If n.Tipo = "Rol" Then
                lst.Add(n)
                lstrol2.Add(n)
            Else
                lst.Add(n)

            End If

        Next

        If lstrol2 IsNot Nothing Or lstrol2.Count = 0 Then
            For Each n In lstrol2
                obtenertodospermisos2(lst, n)
            Next
        End If
    End Sub



    Public Function traerpermisosrol(rol As Rol)
        Dim oMPP As New MPPpermiso
        Dim listpermisos2 As New List(Of Rolpermiso)
        Return oMPP.traerpermisosrol(rol)
    End Function


    Public Function listarrol()
        Dim lst As List(Of Rolpermiso)
        Dim oMPP As New MPPpermiso
        lst = oMPP.Listarrol()
        Return lst
    End Function

    Public Function listarpermisos()
        Dim lst As List(Of Rolpermiso)
        Dim oMPP As New MPPpermiso
        lst = oMPP.Listarpermisos()
        Return lst
    End Function

    Public Function listarrolusuario(usuario As Usuario)
        Dim lst As List(Of Rolpermiso)
        Dim oMPP As New MPPpermiso
        lst = oMPP.traerrolusuario(usuario)
        Return lst
    End Function


    Public Function listarpermisousuario()
        Dim oMPP As New MPPpermiso
        Return oMPP.Listarpermisousuario()
    End Function

    Public Function listarpermisofaltante(rol As Rol)
        Dim oMPP As New MPPpermiso
        Return oMPP.traerpermisofaltante(rol)
    End Function

    Public Function verificarpermiso(lst As List(Of Rolpermiso), permiso As String)
        Dim verificador As Boolean = False
        For Each n In lst
            If n.nombre = permiso Then
                verificador = True
            End If
        Next
        Dim permisos As New Permiso
        permisos.nombre = permiso
        permisos.Tipo = "Permiso"
        verificarpermisoexistente(permisos)
        Return verificador
    End Function

    Public Sub verificarpermisoexistente(permiso As Permiso)
        Dim lstexistente As New List(Of Rolpermiso)
        Dim oMPP As New MPPpermiso
        lstexistente = oMPP.verificarpermisoexistente(permiso)
        If lstexistente Is Nothing Then
            generarrolpermiso(permiso)
        End If
    End Sub


    'Public Function componentelistar()
    '    Dim oMPP As New MPPpalabra
    '    Return oMPP.Listar()
    'End Function









End Class
