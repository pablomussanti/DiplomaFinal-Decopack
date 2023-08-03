Public Class SesionManager
    Public Shared _instancia As Usuario

    Public Shared Function obtenerinstancia()
        If _instancia.ToString = Nothing Then
            _instancia = New Usuario()
        End If
        Return _instancia
    End Function
    Sub New(usuario)
        _instancia = usuario
    End Sub
End Class
