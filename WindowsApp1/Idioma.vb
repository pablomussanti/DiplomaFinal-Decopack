Imports BLL
Imports Servicios
Public Class Idioma
    Implements Iidiomaobserver

    Dim blltraduccion As New BLLtraduccion
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim bllpalabra As New BLLpalabra

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(370, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 370)
        bllpalabra.verificacionpalabras(182, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 182)
        bllpalabra.verificacionpalabras(520, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 520)

        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)

        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)

        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim idiomaselec As New Servicios.Idioma


            idiomaselec = cmbidioma.SelectedItem
            Singletonidioma._instancia.nombre = idiomaselec.nombre
            Singletonidioma._instancia.codigo = idiomaselec.codigo
            Singletonidioma._instancia.Notificar()

            'Login.idioma = idiomaselec.nombre
            MessageBox.Show(mensaje3)
        Catch ex As Exception
            MessageBox.Show(mensaje2)
        End Try

    End Sub

    Private Sub Idioma_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mensaje2 = "Seleccione el item correspondiente"

        mensaje3 = "Se cambio de idioma con exito"

        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Idioma")
        If verificador = True Then

            Button2.Enabled = True

        Else

            Button2.Enabled = False

        End If

        Singletonidioma._instancia.Agregar(Me)
        Me.cmbidioma.DataSource = Nothing
        Dim nn As New BLLidioma
        Me.cmbidioma.DataSource = nn.idiomalistar
        Me.cmbidioma.DisplayMember = "Nombre"


        mensaje1 = "Idioma cambiado con exito, cierre sesion para ver los cambios"

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(370, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 370)
        bllpalabra.verificacionpalabras(182, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 182)

        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)

        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)

        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
        bllpalabra.verificacionpalabras(520, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 520)

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim n As New Palabraidioma
        n.Show()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class