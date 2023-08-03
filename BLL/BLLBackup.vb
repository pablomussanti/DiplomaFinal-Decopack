Imports Servicios
Imports MPP
Public Class BLLBackup
    Public Function realizarbackup(direccion As String) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPBackup
        resultado = oMPP.Generar(direccion)
        Return resultado
    End Function

    Public Function crearbackup(direccion As String) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPBackup
        resultado = oMPP.Crear(direccion)
        Return resultado
    End Function

    Public Function Listarbackup() As List(Of Servicios.Backups)
        Dim lista As New List(Of Servicios.Backups)
        Dim oMPP As New MPPBackup
        lista = oMPP.Listar()
        Return lista
    End Function
End Class
