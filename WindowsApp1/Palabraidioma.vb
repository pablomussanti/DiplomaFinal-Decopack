Imports Servicios
Imports BLL
Public Class Palabraidioma
    Implements Iidiomaobserver

    Dim bllpalabra As New BLLpalabra
    Dim bllidioma As New BLLidioma
    Dim blltraduccion As New BLLtraduccion
    Dim bllbitacora As New BLLbitacora
    Dim mensaje1 As String

    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje2)
            Else
                Dim idioma As New Servicios.Idioma
                idioma.nombre = TextBox1.Text
                bllidioma.Crearidioma(idioma)
                MessageBox.Show(mensaje3)
                bllbitacora.generarbitacora("Crear idioma", "Tabla Idioma", Servicios.SesionManager.obtenerinstancia)
                actualizaridioma()
                cargaridioma()

            End If
        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error crear idioma", "Tabla Idioma", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Palabraidioma_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mensaje2 = "Introdusca un nombre"
        Singletonidioma._instancia.Agregar(Me)

        mensaje3 = "Idioma cargado"


        mensaje4 = "No hay palabras para traducir"


        mensaje5 = "Traduccion realizada"

        mensaje6 = "Seleccione una traduccion"


        mensaje7 = "Se elimino la traduccion con exito"


        mensaje8 = "Se establecio mal el formato del campo"



        Me.TextBox3.Enabled = False

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllpalabra.palabralistar
        actualizaridioma()
        cargaridioma()
        actualizartraduccion()

        mensaje1 = "Ingrese una traduccion"

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(Label7.Tag, Label7.Text)
        Label7.Text = blltraduccion.Traduccion(idioma, Label7.Tag)

        bllpalabra.verificacionpalabras(371, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 371)
        bllpalabra.verificacionpalabras(372, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 372)
        bllpalabra.verificacionpalabras(373, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 373)
        bllpalabra.verificacionpalabras(374, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 374)
        bllpalabra.verificacionpalabras(375, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 375)
        bllpalabra.verificacionpalabras(376, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 376)
        bllpalabra.verificacionpalabras(377, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 377)
        bllpalabra.verificacionpalabras(285, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 285)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        bllpalabra.verificacionpalabras(Label5.Tag, Label5.Text)
        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        bllpalabra.verificacionpalabras(Label8.Tag, Label8.Text)
        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)

        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)
        Label5.Text = blltraduccion.Traduccion(idioma, Label5.Tag)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)
        Label8.Text = blltraduccion.Traduccion(idioma, Label8.Tag)

        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

    End Sub

    Public Sub actualizaridioma()
        Me.DataGridView2.DataSource = Nothing
        Me.DataGridView2.DataSource = bllidioma.idiomalistar
    End Sub

    Public Sub cargarpalabras()
        Me.ComboBox2.DataSource = Nothing
        Dim nn As New BLLpalabra
        Me.ComboBox2.DataSource = cargarpalabras2()
        Me.ComboBox2.DisplayMember = "Nombre"
    End Sub

    Public Sub cargaridioma()
        Me.ComboBox1.DataSource = Nothing
        Dim nn As New BLLidioma
        Me.ComboBox1.DataSource = nn.idiomalistar
        Me.ComboBox1.DisplayMember = "Nombre"
    End Sub

    Public Sub actualizartraduccion()
        Me.DataGridView3.DataSource = Nothing
        Me.DataGridView3.DataSource = blltraduccion.listar
    End Sub

    Public Function cargarpalabras2()
        Dim idioma As New Servicios.Idioma
        idioma = ComboBox1.SelectedItem
        Dim n As New List(Of Servicios.Palabra)
        n = bllpalabra.listarpalabrafaltante(idioma.codigo)
        Return n
    End Function

    Private Sub DataGridView3_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView3.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView3.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As Servicios.Traduccion = a.DataBoundItem
            TextBox3.Text = p.codigo
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If TextBox2.Text = "" Then
                MessageBox.Show(mensaje1)
            Else
                If ComboBox2.Items.Count = 0 Then
                    MessageBox.Show(mensaje4)
                Else

                    Dim Traduccion As New Traduccion
                    Dim palabra As New Palabra
                    Dim idiomas As New Servicios.Idioma
                    idiomas = ComboBox1.SelectedItem
                    palabra = ComboBox2.SelectedItem
                    Traduccion.palabra = palabra
                    Traduccion.idioma = idiomas
                    Traduccion.traduccion = TextBox2.Text
                    MessageBox.Show(mensaje5)
                    blltraduccion.agregartraduccion(Traduccion)
                    actualizartraduccion()
                    cargarpalabras()
                    TextBox2.Text = ""
                    bllbitacora.generarbitacora("Generar traduccion", "Tabla Traduccion", Servicios.SesionManager.obtenerinstancia)


                End If

            End If

        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error generar traduccion", "Tabla Traduccion", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            cargarpalabras()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If TextBox3.Text = "" Then
                MessageBox.Show(mensaje6)
            Else
                blltraduccion.Eliminar(TextBox3.Text)
                actualizartraduccion()
                MessageBox.Show(mensaje7)
                bllbitacora.generarbitacora("Eliminar traduccion", "Tabla Traduccion", Servicios.SesionManager.obtenerinstancia)
                TextBox3.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error eliminar traduccion", "Tabla Traduccion", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre



        bllpalabra.verificacionpalabras(371, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 371)
        bllpalabra.verificacionpalabras(372, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 372)
        bllpalabra.verificacionpalabras(373, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 373)
        bllpalabra.verificacionpalabras(374, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 374)
        bllpalabra.verificacionpalabras(375, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 375)
        bllpalabra.verificacionpalabras(376, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 376)
        bllpalabra.verificacionpalabras(377, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 377)
        bllpalabra.verificacionpalabras(285, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 285)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        bllpalabra.verificacionpalabras(Label5.Tag, Label5.Text)
        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        bllpalabra.verificacionpalabras(Label8.Tag, Label8.Text)
        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)

        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)
        Label5.Text = blltraduccion.Traduccion(idioma, Label5.Tag)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)
        Label8.Text = blltraduccion.Traduccion(idioma, Label8.Tag)
        bllpalabra.verificacionpalabras(Label7.Tag, Label7.Text)
        Label7.Text = blltraduccion.Traduccion(idioma, Label7.Tag)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)
    End Sub
End Class