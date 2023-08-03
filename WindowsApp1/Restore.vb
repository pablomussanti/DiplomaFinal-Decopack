Imports BLL
Imports Servicios
Public Class Restore
    Implements Iidiomaobserver

    Dim bllrestore As New BLLrestore
    Dim direccion As String
    Dim bllbackup As New BLLBackup
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim bllbitacora As New BLLbitacora
    Dim mensaje1 As String
    Dim mensaje3 As String
    Dim mensaje2 As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim estado As Boolean
            If direccion = Nothing Then
                MessageBox.Show(mensaje3)
            Else
                estado = bllrestore.realizarrestore(direccion)
                If estado = True Then
                    MsgBox(mensaje1)
                    bllbitacora.generarbitacora("Generar restore", "Tabla Restore", Servicios.SesionManager.obtenerinstancia)
                Else
                    MsgBox(mensaje2)
                    bllbitacora.generarbitacora("Error generar restore", "Tabla Restore", Servicios.SesionManager.obtenerinstancia)
                End If
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bllpalabra As New BLLpalabra
        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        actualizar()
        Button1.Enabled = False

        mensaje1 = "El restore se realizo con exito."

        mensaje2 = "El restore no se realizo, intentelo nuevamente."

        mensaje3 = "Seleccione un backup"
        Singletonidioma._instancia.Agregar(Me)

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(296, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 296)

        bllpalabra.verificacionpalabras(297, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 297)

        bllpalabra.verificacionpalabras(298, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 298)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)



        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
    End Sub

    Public Sub actualizar()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllbackup.Listarbackup
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As Servicios.Backups = a.DataBoundItem

            direccion = p.nombre
            Button1.Enabled = True
        End If


    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(296, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 296)

        bllpalabra.verificacionpalabras(297, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 297)

        bllpalabra.verificacionpalabras(298, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 298)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)



        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
    End Sub
End Class