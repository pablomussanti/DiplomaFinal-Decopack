Imports BLL
Imports EE
Imports System.IO
Imports Servicios
Public Class Bitacora
    Implements Iidiomaobserver
    Dim bllpalabra As New BLLpalabra
    Dim bllbitacoras As New BLLbitacora
    Dim blltraduccion As New BLLtraduccion
    Dim lstbitacora As New List(Of Servicios.Bitacora)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim busqueda As New Servicios.Usuario
            busqueda = ComboBox1.SelectedValue
            Me.DataGridView1.DataSource = Nothing
            If lstbitacora IsNot Nothing Then
                lstbitacora.Clear()
            End If
            lstbitacora = bllbitacoras.Listarporusuario(busqueda.user)
            Me.DataGridView1.DataSource = lstbitacora
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Bitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizar()
        Singletonidioma._instancia.Agregar(Me)
        cargarComboPaquete1()

        Dim idiomaactual As New Servicios.Idioma
        idiomaactual = Singletonidioma.obtenerinstancia
        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Label1.Text = blltraduccion.Traduccion(idiomaactual.nombre, Label1.Tag)
        Button1.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button1.Tag)
        Button2.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button2.Tag)
        Button3.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button3.Tag)
        Button4.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button4.Tag)
        GroupBox1.Text = blltraduccion.Traduccion(idiomaactual.nombre, GroupBox1.Tag)
        Me.Text = blltraduccion.Traduccion(idiomaactual.nombre, Me.Tag)
    End Sub

    Public Sub actualizar()
        If lstbitacora IsNot Nothing Then
            lstbitacora.Clear()
        End If

        Me.DataGridView1.DataSource = Nothing
        lstbitacora = bllbitacoras.Listarbitacora
        Me.DataGridView1.DataSource = lstbitacora
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        actualizar()
    End Sub

    Public Sub cargarComboPaquete1()
        Me.ComboBox1.DataSource = Nothing
        Dim nn As New BLLusuario
        Me.ComboBox1.DataSource = nn.Listar
        Me.ComboBox1.DisplayMember = "User"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If lstbitacora Is Nothing Then Exit Sub
            If lstbitacora.Count > 0 Then
                Dim filename As String

                Using fbd = New FolderBrowserDialog()
                    Dim result As DialogResult = fbd.ShowDialog()
                    If result = DialogResult.OK AndAlso Not String.IsNullOrWhiteSpace(fbd.SelectedPath) Then
                        filename = fbd.SelectedPath & "\" & DateTime.Now.ToString("dd-MM-yy-hh-mm-ss") & "Bitacora.json"
                        Dim json As New SerializadorJSN()
                        json.Serialize(filename, lstbitacora)


                    End If

                End Using
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllbitacoras.Listarerror
    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaactual As New Servicios.Idioma
        idiomaactual = Singletonidioma.obtenerinstancia
        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Label1.Text = blltraduccion.Traduccion(idiomaactual.nombre, Label1.Tag)
        Button1.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button1.Tag)
        Button2.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button2.Tag)
        Button3.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button3.Tag)
        Button4.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button4.Tag)
        GroupBox1.Text = blltraduccion.Traduccion(idiomaactual.nombre, GroupBox1.Tag)
        Me.Text = blltraduccion.Traduccion(idiomaactual.nombre, Me.Tag)


    End Sub
End Class