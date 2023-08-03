Imports EE
Imports BLL
Imports Servicios
Public Class Empleadosucursal
    Implements Iidiomaobserver

    Dim bllsucursal As New BLLsucursal
    Dim bllempleadosucursal As New BLLempleadosucursal
    '  Dim listaempleadosucursal As New List(Of EE.Empleadosucursal)
    Dim mensaje1 As String
    Dim mensaje2 As String

    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim bllpalabra As New BLLpalabra
    Dim bllbitacora As New BLLbitacora
    Dim blltraduccion As New BLLtraduccion
    Dim valorp As Integer = 0
    Private Sub Empleadosucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mensaje3 = "Empleado de sucursal generado"
        Singletonidioma._instancia.Agregar(Me)

        mensaje4 = "Telefono incompatible"


        mensaje5 = "Formato ingresado en los campos es incompatible"


        mensaje6 = "Modificacion generada"


        mensaje7 = "Eliminacion generada"



        txtcodigo.Enabled = False
        Me.ComboBox1.DataSource = Nothing
        Me.ComboBox1.DataSource = bllsucursal.Listarsucursal
        Me.ComboBox1.DisplayMember = "Detalle"
        actualizar()


        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Empleadosucursal")
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



        mensaje2 = "Seleccione un empleado"
        mensaje1 = "Limpie los campos"

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(357, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 357)
        bllpalabra.verificacionpalabras(358, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 358)
        bllpalabra.verificacionpalabras(359, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 359)
        bllpalabra.verificacionpalabras(360, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 360)
        bllpalabra.verificacionpalabras(361, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 361)

        bllpalabra.verificacionpalabras(126, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 126)
        bllpalabra.verificacionpalabras(127, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 127)


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
        Me.DataGridView1.DataSource = bllempleadosucursal.Listarempleadosucursal
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If txtcodigo.Text = "" Then
                If txttelefono.Text > 0 Then
                    Dim empleadosucursal As New EE.Empleadosucursal
                    empleadosucursal.apellido = txtapellido.Text
                    empleadosucursal.email = txtemail.Text
                    empleadosucursal.fechadeingreso = datafecha.Value
                    empleadosucursal.localizacion = ComboBox1.SelectedItem
                    empleadosucursal.nombre = txtnombre.Text
                    empleadosucursal.estado = "Activo"
                    empleadosucursal.telefono = txttelefono.Text
                    bllempleadosucursal.Crearempleadosucursal(empleadosucursal)
                    MessageBox.Show(mensaje3)
                    bllbitacora.generarbitacora("Alta empleado sucursal", "Tabla Empleadosucursal", Servicios.SesionManager.obtenerinstancia)
                    actualizar()
                    txtapellido.Text = ""
                    txtnombre.Text = ""
                    txtemail.Text = ""
                    txttelefono.Text = ""
                    txtcodigo.Text = ""
                Else
                    MessageBox.Show(mensaje4)
                End If

            Else
                MessageBox.Show(mensaje1)
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error alta empleado sucursal", "Tabla Empleadosucursal", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Empleadosucursal = a.DataBoundItem
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

                Dim empleadosucursal As New EE.Empleadosucursal
                empleadosucursal.codigo = txtcodigo.Text
                empleadosucursal.apellido = txtapellido.Text
                empleadosucursal.email = txtemail.Text
                empleadosucursal.estado = "Activo"
                empleadosucursal.fechadeingreso = datafecha.Value
                empleadosucursal.localizacion = ComboBox1.SelectedItem
                empleadosucursal.nombre = txtnombre.Text
                empleadosucursal.telefono = txttelefono.Text
                bllempleadosucursal.Modificarempleadosucursal(empleadosucursal)
                MessageBox.Show(mensaje6)
                bllbitacora.generarbitacora("Modificacion empleado sucursal", "Tabla Empleadosucursal", Servicios.SesionManager.obtenerinstancia)
                actualizar()
                Button2.Enabled = False
                Button3.Enabled = False
                txtapellido.Text = ""
                txtnombre.Text = ""
                txtemail.Text = ""
                txttelefono.Text = ""
                txtcodigo.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error Modificacion empleado sucursal", "Tabla Empleadosucursal", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje2)
            Else

                Dim empleadosucursal As New EE.Empleadosucursal
                empleadosucursal.codigo = txtcodigo.Text
                empleadosucursal.apellido = txtapellido.Text
                empleadosucursal.email = txtemail.Text
                empleadosucursal.fechadeingreso = datafecha.Value
                empleadosucursal.localizacion = ComboBox1.SelectedItem
                empleadosucursal.nombre = txtnombre.Text
                empleadosucursal.estado = "Baja"
                empleadosucursal.telefono = txttelefono.Text
                bllempleadosucursal.Modificarempleadosucursal(empleadosucursal)
                MessageBox.Show(mensaje7)
                bllbitacora.generarbitacora("Baja empleado sucursal", "Tabla Empleadosucursal", Servicios.SesionManager.obtenerinstancia)
                actualizar()
                Button2.Enabled = False
                Button3.Enabled = False
                txtapellido.Text = ""
                txtnombre.Text = ""
                txtemail.Text = ""
                txttelefono.Text = ""
                txtcodigo.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error baja empleado sucursal", "Tabla Empleadosucursal", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(357, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 357)
        bllpalabra.verificacionpalabras(358, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 358)
        bllpalabra.verificacionpalabras(359, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 359)
        bllpalabra.verificacionpalabras(360, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 360)
        bllpalabra.verificacionpalabras(361, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 361)

        bllpalabra.verificacionpalabras(126, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 126)
        bllpalabra.verificacionpalabras(127, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 127)


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
End Class