Imports DAL
Imports EE
Public Class MPPidioma
    Public Function Listaridioma() As List(Of Servicios.Idioma)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Idioma)
        Dim dato3 As Servicios.Idioma

        DS = oDatos.Leer("s_Idioma_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Idioma
                dato3.codigo = Item("Codidioma")
                dato3.nombre = Item("Descripcion")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function
    Public Function Crearidioma(ByVal idioma As Servicios.Idioma) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Idioma_Crear"

        hdatos.Add("@descripcion", idioma.nombre)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function
End Class
