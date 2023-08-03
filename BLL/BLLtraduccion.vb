Imports Servicios
Imports MPP
Public Class BLLtraduccion
    Public Function Traduccion(idioma As String, tag As String) As String
        Dim oMPP As New MPPtraduccion
        If oMPP.obtenertraduccion(idioma, tag) = Nothing Then
            Exit Function
        Else
            Return oMPP.obtenertraduccion(idioma, tag)
        End If
    End Function


    Public Function agregartraduccion(traduccion As Servicios.Traduccion)
        Dim oMPP As New MPPtraduccion
        Return oMPP.generartraduccion(traduccion)
    End Function

    Public Function listar()
        Dim oMPP As New MPPtraduccion
        Return oMPP.Listar()
    End Function

    Public Function Eliminar(ByVal codigo As Integer) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPtraduccion
        resultado = oMPP.Eliminar(codigo)
        Return resultado
    End Function

    Public Function confirmar(dato1 As String, dato2 As String)
        ' idioma / palabra
        Dim oMPP As New MPPtraduccion
        Return oMPP.Confirmar(dato1, dato2)
    End Function

End Class
