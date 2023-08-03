Imports EE
Imports DAL
Imports Servicios
Public Class MPPtraduccion
    Public Function obtenertraduccion(idioma As String, palabra As String) As String

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim dato3 As Traduccion
        Dim hdatos As New Hashtable

        hdatos.Add("@codidioma", idioma)
        hdatos.Add("@tag", palabra)


        DS = oDatos.Leer("s_Traduccion_Traer", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                Return Item("Descripcion")
            Next



        Else
            Return Nothing
        End If
    End Function

    Public Function Eliminar(ByVal codigo As String) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@codtraduccion", codigo)

        resultado = oDatos.Escribir("s_Traduccion_Eliminar", hdatos)

        Return resultado
    End Function

    Public Function Generartraduccion(ByVal traduccion As Servicios.Traduccion) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Traduccion_Crear"

        hdatos.Add("@codidioma", traduccion.idioma.codigo)
        hdatos.Add("@descripcion", traduccion.traduccion)
        hdatos.Add("@codpalabra", traduccion.palabra.codigo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function

    Public Function Confirmar(dato1 As String, dato2 As String) As String

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim dato3 As Traduccion
        Dim hdatos As New Hashtable

        hdatos.Add("@codidioma", dato1)
        hdatos.Add("@codpalabra", dato2)


        DS = oDatos.Leer("s_Traduccion_Generar", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Traduccion
                dato3.traduccion = Item("Descripcion")
            Next

            Return dato3.traduccion

        Else
            Return Nothing
        End If
    End Function

    Public Function Listar() As List(Of Servicios.Traduccion)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of Servicios.Traduccion)
        Dim dato3 As Servicios.Traduccion

        DS = oDatos.Leer("s_Traduccion_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then

            Dim lllllll = New List(Of Palabra)

            For Each r In DS.Tables(1).Rows
                lllllll.Add(New Palabra With {
                    .codigo = r("Codpalabra"),
                    .nombre = r("Descripcion"),
                    .tag = r("Tag")})
            Next


            Dim l = New List(Of Idioma)

            For Each r In DS.Tables(2).Rows
                l.Add(New Idioma With {
                    .codigo = r("Codidioma"),
                    .nombre = r("Descripcion")})
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New Servicios.Traduccion
                dato3.codigo = Item("Codtraduccion")

                dato3.palabra = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codpalabra")))
                dato3.idioma = l.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codidioma")))
                dato3.traduccion = Item("Descripcion")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function
End Class
