Imports EE
Imports MPP
Imports Servicios
Public Class BLLbitacora
    Public Function Crearbitacora(bitacora As Servicios.Bitacora) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPbitacora
        resultado = oMPP.Generarbitacora(bitacora)
        Return resultado
    End Function

    Public Function Listarbitacora() As List(Of Servicios.Bitacora)
        Dim lista As New List(Of Servicios.Bitacora)
        Dim oMPP As New MPPbitacora
        lista = oMPP.Listarbitacora()
        Return lista
    End Function

    Public Function Listarporusuario(user As String) As List(Of Servicios.Bitacora)
        Dim lista As New List(Of Servicios.Bitacora)
        Dim oMPP As New MPPbitacora
        lista = oMPP.Listarporusuario(user)
        Return lista
    End Function

    Public Sub generarbitacora(tipo As String, tabla As String, usuario As Servicios.Usuario)
        Dim bitacora As New Servicios.Bitacora(tipo, tabla, usuario.user, DateTime.Now.ToString("dd/MM/yy"))
        Me.Crearbitacora(bitacora)
    End Sub

    Public Function Listarerror() As List(Of Servicios.Bitacoraerror)
        Dim lista As New List(Of Servicios.Bitacoraerror)
        Dim oMPP As New MPPbitacora
        lista = oMPP.Listarerror()
        Return lista
    End Function
End Class
