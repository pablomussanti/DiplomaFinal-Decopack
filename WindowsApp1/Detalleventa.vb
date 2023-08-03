Imports EE
Imports BLL
Imports Servicios
Public Class Detalleventa
    Implements Iidiomaobserver

    Dim blldetalleventa As New BLLdetalleventa
    Dim listadetalle As New List(Of EE.Detalleventa)
    Dim bllproducto As New BLLproducto
    Dim bllventa As New BLLventa
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Private Sub Detalleventa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizar()
        Singletonidioma._instancia.Agregar(Me)

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

    End Sub


    Public Sub actualizar()
        listadetalle.Clear()

        If bllventa.Listar Is Nothing Then Exit Sub
        For Each venta In bllventa.Listar
            Dim contador As Integer = 0
            Me.DataGridView1.DataSource = Nothing
            If blldetalleventa.Listardetalle(venta) Is Nothing Then
                contador = 1
            End If
            If contador = 0 Then
                For Each n In blldetalleventa.Listardetalle(venta)
                    listadetalle.Add(n)
                Next

            End If

        Next
        Me.DataGridView1.DataSource = listadetalle

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)
    End Sub
End Class