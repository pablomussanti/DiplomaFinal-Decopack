Public Class Singletonidioma
    Public Shared _instancia As Idioma

    Public Shared Function obtenerinstancia()
        If _instancia.ToString = Nothing Then
            _instancia = New Idioma()
        End If
        Return _instancia
    End Function
    Sub New(Idioma)
        _instancia = Idioma
    End Sub
End Class
