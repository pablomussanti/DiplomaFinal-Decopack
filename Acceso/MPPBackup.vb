Imports DAL
Public Class MPPBackup

    Public Function realizarbackup()
        Dim datos As New Datos
        Return datos.Backup()
    End Function

End Class
