Imports EE
Imports BLL
Imports Servicios

Public Class Empleadodeposito
    Implements Iidiomaobserver

    Dim blldeposito As New BLLdeposito
    Dim bllempleadodeposito As New BLLempleadodeposito
    '   Dim listaempleadodeposito As New List(Of EE.Empleadodeposito)
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim mensaje1 As String
    Dim mensaje2 As String

    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim bllbitacora As New BLLbitacora
    Dim valorp As Integer = 0
    Private Sub Empleadodeposito_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mensaje3 = "Empleado de deposito generado"

        Singletonidioma._instancia.Agregar(Me)
        mensaje4 = "Telefono incompatible"


        mensaje5 = "Mal formato de los datos ingresados en los campos"


        mensaje6 = "Modificacion exitosa"


        mensaje7 = "Baja de empleado de deposito exitosa"




        txtcodigo.Enabled = False
        Me.ComboBox1.DataSource = Nothing
        Me.ComboBox1.DataSource = blldeposito.Listardeposito
        Me.ComboBox1.DisplayMember = "Detalle"
        actualizar()
        mensaje2 = "Seleccione un empleado"
        mensaje1 = "Limpie los campos"

        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Empleadodeposito")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = True
            valorp = 1

        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False

        End If


        Singletonidioma._instancia.Agregar(Me)


        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(352, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 352)
        bllpalabra.verificacionpalabras(353, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 353)
        bllpalabra.verificacionpalabras(354, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 354)
        bllpalabra.verificacionpalabras(355, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 355)
        bllpalabra.verificacionpalabras(356, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 356)

        bllpalabra.verificacionpalabras(111, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 111)
        bllpalabra.verificacionpalabras(112, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 112)


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
        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)

        bllpalabra.verificacionpalabras(Label7.Tag, Label7.Text)
        Label7.Text = blltraduccion.Traduccion(idioma, Label7.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)


        bllpalabra.verificacionpalabras(ABM.Tag, ABM.Text)
        ABM.Text = blltraduccion.Traduccion(idioma, ABM.Tag)
    End Sub

    Public Sub actualizar()

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllempleadodeposito.Listarempleadodeposito

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If txtcodigo.Text = "" Then
                If txttelefono.Text > 0 Then
                    Dim empleadodeposito As New EE.Empleadodeposito
                    empleadodeposito.apellido = txtapellido.Text
                    empleadodeposito.email = txtemail.Text
                    empleadodeposito.fechadeingreso = datafecha.Value
                    empleadodeposito.localizacion = ComboBox1.SelectedItem
                    empleadodeposito.estado = "Activo"
                    empleadodeposito.nombre = txtnombre.Text
                    empleadodeposito.telefono = txttelefono.Text
                    bllempleadodeposito.Crearempleadodeposito(empleadodeposito)
                    MessageBox.Show(mensaje3)
                    bllbitacora.generarbitacora("Alta Empleado deposito", "Tabla Empleadodeposito", Servicios.SesionManager.obtenerinstancia)

                Else
                    MessageBox.Show(mensaje4)
                End If

            Else
                MessageBox.Show(mensaje1)
            End If
            actualizar()

        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error Alta empleado deposito", "Tabla Empleadodeposito", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Empleadodeposito = a.DataBoundItem
            txtapellido.Text = p.apellido
            txtnombre.Text = p.nombre
            txtemail.Text = p.email
            txttelefono.Text = p.telefono
            datafecha.Text = p.fechadeingreso
            ComboBox1.SelectedItem = p.localizacion
            txtcodigo.Text = p.codigo

            If valorp = 1 Then
                Button2.Enabled = True
                Button3.Enabled = True
            End If
        End If


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtapellido.Text = ""
        txtnombre.Text = ""
        txtemail.Text = ""
        txttelefono.Text = ""
        txtcodigo.Text = ""
        Button2.Enabled = False
        Button3.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje2)
            Else

                Dim empleadodeposito As New EE.Empleadodeposito
                empleadodeposito.codigo = txtcodigo.Text
                empleadodeposito.apellido = txtapellido.Text
                empleadodeposito.email = txtemail.Text
                empleadodeposito.estado = "Activo"
                empleadodeposito.fechadeingreso = datafecha.Value
                empleadodeposito.localizacion = ComboBox1.SelectedItem
                empleadodeposito.nombre = txtnombre.Text
                empleadodeposito.telefono = txttelefono.Text
                bllempleadodeposito.Modificarempleadodeposito(empleadodeposito)
                MessageBox.Show(mensaje6)
                bllbitacora.generarbitacora("Modificacion empleado deposito", "Tabla Empleadodeposito", Servicios.SesionManager.obtenerinstancia)
            End If
            actualizar()
            Button2.Enabled = False

            Button3.Enabled = False
        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error Modificacion empleado deposito", "Tabla Empleadodeposito", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje2)
            Else

                Dim empleadodeposito As New EE.Empleadodeposito
                empleadodeposito.codigo = txtcodigo.Text
                empleadodeposito.apellido = txtapellido.Text
                empleadodeposito.estado = "Baja"
                empleadodeposito.email = txtemail.Text
                empleadodeposito.fechadeingreso = datafecha.Value
                empleadodeposito.localizacion = ComboBox1.SelectedItem
                empleadodeposito.nombre = txtnombre.Text
                empleadodeposito.telefono = txttelefono.Text
                bllempleadodeposito.Modificarempleadodeposito(empleadodeposito)
                MessageBox.Show(mensaje7)
                bllbitacora.generarbitacora("Baja Empleado deposito", "Tabla Empleadodeposito", Servicios.SesionManager.obtenerinstancia)
            End If
            Button2.Enabled = False
            Button3.Enabled = False
            actualizar()
        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error baja empleado deposito", "Tabla Empleadodeposito", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(352, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 352)
        bllpalabra.verificacionpalabras(353, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 353)
        bllpalabra.verificacionpalabras(354, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 354)
        bllpalabra.verificacionpalabras(355, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 355)
        bllpalabra.verificacionpalabras(356, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 356)

        bllpalabra.verificacionpalabras(111, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 111)
        bllpalabra.verificacionpalabras(112, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 112)


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
        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)

        bllpalabra.verificacionpalabras(Label7.Tag, Label7.Text)
        Label7.Text = blltraduccion.Traduccion(idioma, Label7.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)


        bllpalabra.verificacionpalabras(ABM.Tag, ABM.Text)
        ABM.Text = blltraduccion.Traduccion(idioma, ABM.Tag)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class