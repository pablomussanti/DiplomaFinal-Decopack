Imports BLL
Imports WindowsApp1
Imports Servicios

Public Class Backup
    Implements Iidiomaobserver

    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim bllbitacora As New BLLbitacora
    Dim blltraduccion As New BLLtraduccion


    Public Sub update(h As Object) Implements Iidiomaobserver.update

        Dim idiomaactual As New Servicios.Idioma
        idiomaactual = Singletonidioma.obtenerinstancia
        Dim bllpalabra As New BLLpalabra
        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button1.Tag)
        bllpalabra.verificacionpalabras(48, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idiomaactual.nombre, 48)
        bllpalabra.verificacionpalabras(49, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idiomaactual.nombre, 49)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idiomaactual.nombre, Label2.Tag)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim estado As Boolean
            Dim total As String
            Dim lugar As String
            Dim direccion As String
            direccion = TextBox1.Text
            lugar = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss")
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje3)
                Exit Sub
            End If
            total = direccion & "\" & lugar & "bdfinal.bak"
            Dim backup As New BLLBackup
            estado = backup.realizarbackup(total)
            If estado = True Then
                MessageBox.Show(mensaje1)
                backup.crearbackup(total)
                bllbitacora.generarbitacora("Generar backup", "Tabla backup", Servicios.SesionManager.obtenerinstancia)
            Else
                MessageBox.Show(mensaje2)
                bllbitacora.generarbitacora("Error generar backup", "Tabla backup", Servicios.SesionManager.obtenerinstancia)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        mensaje1 = "El backup se realizo con exito."
        mensaje2 = "El backup no se realizo, intentelo nuevamente."
        mensaje3 = "Ingrese una ruta"
        Singletonidioma._instancia.Agregar(Me)

        Dim idiomaactual As New Servicios.Idioma
        idiomaactual = Singletonidioma.obtenerinstancia
        Dim bllpalabra As New BLLpalabra
        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idiomaactual.nombre, Button1.Tag)
        bllpalabra.verificacionpalabras(48, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idiomaactual.nombre, 48)
        bllpalabra.verificacionpalabras(49, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idiomaactual.nombre, 49)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idiomaactual.nombre, Label2.Tag)
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class