Imports EE
Imports MPP
Public Class BLLpalabra
    Public Function Crearpalabra(palabra As Servicios.Palabra)
        Dim resultado As String
        Dim oMPP As New MPPpalabra
        resultado = oMPP.Confirmar(palabra.tag)
        If resultado = False Then
            oMPP.Crearpalabra(palabra)
            Return True
        Else
            ''oMPP.Modificar(palabra, resultado)
            Return False
        End If
    End Function

    Public Function palabralistar()
        Dim oMPP As New MPPpalabra
        Return oMPP.Listar()
    End Function

    Public Sub verificacionpalabras(tag As String, descripcion As String)
        Dim palabra As New BLLpalabra
        Dim palabraobjeto As New Servicios.Palabra
        palabraobjeto.nombre = descripcion
        palabraobjeto.tag = tag
        palabra.Crearpalabra(palabraobjeto)
    End Sub

    Public Function listarpalabrafaltante(idioma As Integer)
        Dim oMPP As New MPPpalabra
        Return oMPP.Listarpalabratraer(idioma)
    End Function
End Class
