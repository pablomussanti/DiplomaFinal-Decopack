Imports BLL
Imports Servicios
Public Class Usuario
    Implements Iidiomaobserver

    Dim bllusuario As New BLLusuario
    Dim bllpalabra As New BLLpalabra
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
    Dim mensaje9 As String
    Dim mensaje10 As String
    Dim mensaje11 As String
    Dim mensaje12 As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllusuario.Listar()
    End Sub

    Private Sub Usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.Enabled = False
        Button5.Enabled = False
        Button3.Enabled = False
        Button2.Enabled = False
        actualizar()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        mensaje1 = "El nombre ya se encuentra en uso"

        mensaje2 = "Limpie los campos"

        mensaje3 = "Seleccione un usuario"


        Singletonidioma._instancia.Agregar(Me)
        mensaje4 = "Usuario generado"


        mensaje5 = "Datos ingresados con formato no valido segun los campos"


        mensaje6 = "Usuario Eliminado"


        mensaje7 = "Usuario bloqueado"


        mensaje8 = "Usuario modificado"


        mensaje9 = "Usuario desbloqueado"


        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(304, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 304)

        bllpalabra.verificacionpalabras(305, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 305)

        bllpalabra.verificacionpalabras(306, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 306)


        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)
        bllpalabra.verificacionpalabras(Label5.Tag, Label5.Text)
        Label5.Text = blltraduccion.Traduccion(idioma, Label5.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)
        bllpalabra.verificacionpalabras(Button5.Tag, Button5.Text)
        Button5.Text = blltraduccion.Traduccion(idioma, Button5.Tag)
        bllpalabra.verificacionpalabras(Button6.Tag, Button6.Text)
        Button6.Text = blltraduccion.Traduccion(idioma, Button6.Tag)
        bllpalabra.verificacionpalabras(Button7.Tag, Button7.Text)
        Button7.Text = blltraduccion.Traduccion(idioma, Button7.Tag)
        bllpalabra.verificacionpalabras(Button8.Tag, Button8.Text)
        Button8.Text = blltraduccion.Traduccion(idioma, Button8.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)



        bllpalabra.verificacionpalabras(427, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 427)


        bllpalabra.verificacionpalabras(428, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 428)


        bllpalabra.verificacionpalabras(429, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 429)


        bllpalabra.verificacionpalabras(430, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 430)

        bllpalabra.verificacionpalabras(431, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 431)


        bllpalabra.verificacionpalabras(432, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 432)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then

                Dim nuevousuario As New Servicios.Usuario
                nuevousuario.user = txtnombre.Text
                nuevousuario.contraseña = Seguridad.Encripta(txtcontraseña.Text, txtnombre.Text)
                nuevousuario.estadobloqueado = "no"
                If bllusuario.Listar IsNot Nothing Then
                    For Each n In bllusuario.Listar
                        If n.user = txtnombre.Text Then
                            MessageBox.Show(mensaje1)
                            Exit Sub
                        End If
                    Next
                End If
                bllusuario.Crear(nuevousuario)
                MessageBox.Show(mensaje4)
                actualizar()
                bllbitacora.generarbitacora("Alta usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)
                limpiar()
            Else

                MessageBox.Show(mensaje2)
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error alta usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub actualizar()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllusuario.Listar
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje3)
            Else
                Dim nuevousuario As New Servicios.Usuario
                nuevousuario.codigo = TextBox1.Text
                bllusuario.Eliminar(nuevousuario)
                MessageBox.Show(mensaje6)
                actualizar()
                bllbitacora.generarbitacora("Eliminar usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)

            End If
            limpiar()
        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error eliminar usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje3)
            Else

                Dim nuevousuario As New Servicios.Usuario
                nuevousuario.codigo = TextBox1.Text
                nuevousuario.user = txtnombre.Text
                nuevousuario.contraseña = Seguridad.Encripta(txtcontraseña.Text, txtnombre.Text)
                nuevousuario.estadobloqueado = TextBox2.Text
                If TextBox2.Text = "no" Then
                    nuevousuario.estadobloqueado = "si"
                End If
                bllusuario.Crear(nuevousuario)
                MessageBox.Show(mensaje7)
                actualizar()
                bllbitacora.generarbitacora("Bloquear usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)
            End If
            limpiar()
        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error bloquear usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje3)
            Else

                Dim nuevousuario As New Servicios.Usuario
                nuevousuario.codigo = TextBox1.Text
                nuevousuario.user = txtnombre.Text
                nuevousuario.contraseña = Seguridad.Encripta(txtcontraseña.Text, txtnombre.Text)
                nuevousuario.estadobloqueado = TextBox2.Text
                bllusuario.Crear(nuevousuario)
                MessageBox.Show(mensaje8)
                actualizar()
                bllbitacora.generarbitacora("Modificar usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)
            End If
            limpiar()

        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error modificar usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If TextBox1.Text = "" Then

                MessageBox.Show(mensaje3)
            Else
                Dim nuevousuario As New Servicios.Usuario
                nuevousuario.codigo = TextBox1.Text
                nuevousuario.user = txtnombre.Text
                nuevousuario.contraseña = Seguridad.Encripta(txtcontraseña.Text, txtnombre.Text)
                nuevousuario.estadobloqueado = TextBox2.Text
                If TextBox2.Text = "si" Then
                    nuevousuario.estadobloqueado = "no"
                End If
                bllusuario.Crear(nuevousuario)
                MessageBox.Show(mensaje9)
                actualizar()
                bllbitacora.generarbitacora("Desbloquear usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)

            End If
            limpiar()
        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error desbloquear usuario", "Tabla usuario", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As Servicios.Usuario = a.DataBoundItem
            TextBox1.Text = p.codigo
            txtnombre.Text = p.user
            txtcontraseña.Text = Seguridad.DesEncripta(p.contraseña, p.user)
            TextBox2.Text = p.estadobloqueado
            If p.estadobloqueado = "si" Then
                Button4.Enabled = False
                Button5.Enabled = True
            Else
                Button4.Enabled = True
                Button5.Enabled = False
            End If
            Button2.Enabled = True
            Button3.Enabled = True
        End If


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try

            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.DataSource = bllusuario.Listarbloqueados
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        actualizar()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        limpiar()
    End Sub

    Public Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        txtcontraseña.Text = ""
        txtnombre.Text = ""
        Button4.Enabled = False
        Button5.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(304, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 304)

        bllpalabra.verificacionpalabras(305, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 305)

        bllpalabra.verificacionpalabras(306, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 306)


        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)
        bllpalabra.verificacionpalabras(Label5.Tag, Label5.Text)
        Label5.Text = blltraduccion.Traduccion(idioma, Label5.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)
        bllpalabra.verificacionpalabras(Button5.Tag, Button5.Text)
        Button5.Text = blltraduccion.Traduccion(idioma, Button5.Tag)
        bllpalabra.verificacionpalabras(Button6.Tag, Button6.Text)
        Button6.Text = blltraduccion.Traduccion(idioma, Button6.Tag)
        bllpalabra.verificacionpalabras(Button7.Tag, Button7.Text)
        Button7.Text = blltraduccion.Traduccion(idioma, Button7.Tag)
        bllpalabra.verificacionpalabras(Button8.Tag, Button8.Text)
        Button8.Text = blltraduccion.Traduccion(idioma, Button8.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)



        bllpalabra.verificacionpalabras(427, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 427)


        bllpalabra.verificacionpalabras(428, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 428)


        bllpalabra.verificacionpalabras(429, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 429)


        bllpalabra.verificacionpalabras(430, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 430)

        bllpalabra.verificacionpalabras(431, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 431)


        bllpalabra.verificacionpalabras(432, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 432)
    End Sub
End Class