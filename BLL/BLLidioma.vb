Imports MPP
Imports EE
Imports Servicios
Public Class BLLidioma
    Public Function Crearidioma(idioma As Servicios.Idioma)
        Dim oMPP As New MPPidioma
        Return oMPP.Crearidioma(idioma)
    End Function

    Public Function idiomalistar()
        Dim oMPP As New MPPidioma
        Return oMPP.Listaridioma()
    End Function

End Class
