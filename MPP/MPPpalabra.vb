Imports EE
Imports DAL
Public Class MPPpalabra
    Public Function Confirmar(tag As String) As Boolean

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim estado As Boolean = False
        Dim dato3 As Servicios.Palabra
        Dim hdatos As New Hashtable


        hdatos.Add("@tag", tag)


        DS = oDatos.Leer("s_Palabra_Confirmar", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Palabra
                dato3.tag = Item("Tag")
                dato3.nombre = Item("Descripcion")
                dato3.codigo = Item("Codpalabra")
            Next

            Return dato3.codigo

        Else
            Return Nothing
        End If
    End Function

    Public Function Listar() As List(Of Servicios.Palabra)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim dato3 As Servicios.Palabra
        Dim lista As New List(Of Servicios.Palabra)

        DS = oDatos.Leer("s_Palabra_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Palabra
                dato3.codigo = Item("Codpalabra")
                dato3.nombre = Item("Descripcion")
                dato3.tag = Item("Tag")
                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function

    Public Function Crearpalabra(ByVal palabra As Servicios.Palabra) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Palabra_Crear"

        hdatos.Add("@descripcion", palabra.nombre)
        hdatos.Add("@tag", palabra.tag)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Modificar(ByVal palabra As Servicios.Palabra, codigo As String) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Palabra_Modificar"

        hdatos.Add("@codpalabra", codigo)
        hdatos.Add("@descripcion", palabra.nombre)
        hdatos.Add("@tag", palabra.tag)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Listarpalabratraer(idioma As Integer) As List(Of Servicios.Palabra)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim dato3 As Servicios.Palabra
        Dim lista As New List(Of Servicios.Palabra)
        Dim hdatos As New Hashtable


        hdatos.Add("@codidioma", idioma)

        DS = oDatos.Leer("s_Palabra_Traerpalabras", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Palabra
                dato3.codigo = Item("Codpalabra")
                dato3.nombre = Item("Descripcion")
                dato3.tag = Item("Tag")
                lista.Add(dato3)
            Next
            Return lista
        Else
            Return Nothing
        End If
    End Function
End Class
