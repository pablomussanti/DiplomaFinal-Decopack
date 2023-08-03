Imports EE
Imports DAL
Public Class MPPreclamo

    Public Function Generarreclamo(ByVal reclamo As EE.Reclamo) As Boolean

        Dim oDatos As New Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean
        Dim consulta As String = "s_Reclamo_Crear"

        hdatos.Add("@codcomprador", reclamo.comprador.codigo)
        hdatos.Add("@codsucursal", reclamo.sucursal.codigo)
        hdatos.Add("@fecha", reclamo.fecha)
        hdatos.Add("@medidasatomar", reclamo.medidasatomar)
        hdatos.Add("@motivo", reclamo.motivo)

        resultado = oDatos.Escribir(consulta, hdatos)

        Return resultado

    End Function


    Public Function Listarreclamo() As List(Of EE.Reclamo)

        Dim oDatos As New Datos
        Dim DS As New DataSet
        Dim lista As New List(Of EE.Reclamo)
        Dim dato3 As EE.Reclamo

        DS = oDatos.Leer("s_Reclamo_Listar", Nothing)

        If DS.Tables(0).Rows.Count > 0 Then


            Dim lllllll = New List(Of Sucursal)

            For Each r In DS.Tables(1).Rows
                lllllll.Add(New Sucursal With {
                    .codigo = r("Codsucursal"),
                    .codigopostal = r("Codigopostal"),
                    .direccion = r("Direccion"),
                    .telefono = r("Telefono"),
                     .estado = r("Estado"),
                    .detalle = r("Detalle")})
            Next



            Dim llll = New List(Of Comprador)

            For Each r In DS.Tables(2).Rows
                If r("Socioestado") = "Si" Then
                    llll.Add(New Socio With {
                    .codigo = r("Codcomprador"),
                    .apellido = r("Apellido"),
                    .dni = r("Dni"),
                    .domicilio = r("Domicilio"),
                    .estado = r("Estado"),
                    .mail = r("Mail"),
                    .nombre = r("Nombre"),
                    .telefono = r("Telefono")
                         })
                Else
                    llll.Add(New Cliente With {
                    .codigo = r("Codcomprador"),
                    .apellido = r("Apellido"),
                    .dni = r("Dni"),
                    .domicilio = r("Domicilio"),
                    .estado = r("Estado"),
                    .mail = r("Mail"),
                    .nombre = r("Nombre"),
                    .telefono = r("Telefono")
                         })
                End If
            Next

            For Each Item As DataRow In DS.Tables(0).Rows
                dato3 = New EE.Reclamo
                dato3.codigo = Item("Codreclamo")


                dato3.comprador = llll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codcomprador")))


                dato3.sucursal = lllllll.FirstOrDefault(Function(x) x.codigo = Integer.Parse(Item("Codsucursal")))


                dato3.fecha = Item("Fecha")
                dato3.motivo = Item("Motivo")
                dato3.medidasatomar = Item("Medidasatomar")
                lista.Add(dato3)
            Next

            Return lista

        Else
            Return Nothing
        End If
    End Function
End Class
