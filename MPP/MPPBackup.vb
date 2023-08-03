Imports DAL
Public Class MPPBackup

    'Public Function realizarbackup(dato1 As String)
    '    Dim resultado As Boolean
    '    Dim odatos As New DAL.Datos
    '    resultado = odatos.backup(dato1)
    '    Return resultado
    'End Function

    Public Function Generar(ByVal direccion As String) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Backup_Realizar"
        hdatos.Add("@dato", direccion)
        resultado = oDatos.backup(consulta, hdatos)

        Return resultado
    End Function

    Public Function Crear(ByVal direccion As String) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Backup_Guardar"
        hdatos.Add("@nombre", direccion)
        resultado = oDatos.Escribir(consulta, hdatos)
        Return resultado
    End Function

    Public Function Listar() As List(Of Servicios.backups)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Backups)
        Dim dato3 As Servicios.Backups

        DS = oDatos.Leer("s_Backup_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Backups
                dato3.codigo = Item("Idbackup")
                dato3.nombre = Item("Nombre")
                lista.Add(dato3)
            Next

            Return lista
        Else
            Return Nothing
        End If
    End Function

End Class
