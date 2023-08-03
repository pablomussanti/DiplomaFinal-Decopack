Public Class Bitacora
    Inherits Bitacorageneral
    Sub New(dato1 As String, dato2 As String, dato3 As String, dato4 As Date)
        tipo = dato1
        descripcion = dato2
        user = dato3
        fecha = dato4
    End Sub
    Sub New()

    End Sub
End Class
