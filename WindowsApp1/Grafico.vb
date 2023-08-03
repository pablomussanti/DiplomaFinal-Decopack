Imports BLL
Imports Servicios
Imports EE
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data
Public Class Grafico
    Implements Iidiomaobserver


    Dim blltraduccion As New BLLtraduccion
    Dim bllpalabra As New BLLpalabra
    ' Dim Ds As New DataSet
    Dim listadetalle As New List(Of EE.Detalleventa)
    Dim bllproducto As New BLLproducto
    Dim bllventa As New BLLventa
    Dim blldetalleventa As New BLLdetalleventa
    Dim prod As New EE.Detalleventa
    Dim bllgraficomuestra As New BLLgraficomuestra
    Dim graficomuestra As New EE.GraficoMuestra
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            actualizar()
            Dim productos As New List(Of EE.Producto)
            productos = bllproducto.Listarproductotodo
            Dim muestrafinal As New List(Of EE.GraficoMuestra)
            If listadetalle.Count = 0 Then Exit Sub

            For Each n In productos
                Dim nuevo As New GraficoMuestra
                nuevo.producto = n
                muestrafinal.Add(nuevo)
            Next


            bllgraficomuestra.obtenermuestrafinal(listadetalle, muestrafinal)

            Me.Chart1.Series.Add("Recaudado")
            Me.Chart2.Series.Add("Vendidos")
            For Each n In muestrafinal
                Me.Chart2.Series("Vendidos").Points.AddXY(n.producto.nombre, n.cantidad)
                Me.Chart1.Series("Recaudado").Points.AddXY(n.producto.nombre, n.precio)
            Next


        Catch ex As Exception

        End Try
    End Sub



    Public Sub actualizar()
        listadetalle.Clear()

        If bllventa.Listar Is Nothing Then Exit Sub
        For Each venta In bllventa.Listar
            Dim contador As Integer = 0

            If blldetalleventa.Listardetalle(venta) Is Nothing Then
                contador = 1
            End If
            If contador = 0 Then
                For Each n In blldetalleventa.Listardetalle(venta)

                    listadetalle.Add(n)

                Next

            End If

        Next


    End Sub

    Private Sub Grafico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Chart1.Series.Clear()
        Me.Chart2.Series.Clear()
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre
        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(Idioma, Me.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(Idioma, Button1.Tag)


    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        BLLpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = BLLtraduccion.Traduccion(idioma, Me.Tag)


        BLLpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = BLLtraduccion.Traduccion(Idioma, Button1.Tag)


    End Sub
End Class