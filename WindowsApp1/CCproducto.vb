Imports BLL
Imports Servicios
Imports EE
Public Class CCproducto
    Implements Iidiomaobserver

    Dim bllproducto As New BLL.BLLproducto
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion

    Public Sub update(h As Object) Implements Iidiomaobserver.update

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(Idioma, Me.Tag)
    End Sub

    Private Sub CCproducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllproducto.Listarentidad
        Singletonidioma._instancia.Agregar(Me)

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)
    End Sub


End Class