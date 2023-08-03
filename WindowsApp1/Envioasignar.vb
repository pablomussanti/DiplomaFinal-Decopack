Imports EE
Imports BLL
Imports Servicios

Public Class Envioasignar
    Implements Iidiomaobserver

    Dim bllenvio As New BLLenvio
    Dim bllempleadodeposito As New BLLempleadodeposito
    Dim listaenvio As New List(Of EE.Envio)
    Dim bllventa As New BLLventa
    Dim bllempleadosucursal As New BLLempleadosucursal
    Dim bllsucursal As New BLLsucursal
    Dim bllcomprador As New BLLcomprador
    Dim mensaje1 As String
    Dim mensaje2 As String

    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String

    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim bllbitacora As New BLLbitacora
    Dim valorp As Integer = 0
    Dim valorp2 As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If cmbventa.DataSource IsNot Nothing Then

                If txtcodigo.Text = "" Then
                    If txtdireccion.Text IsNot "" Then
                        Dim envio As New EE.Envio
                        envio.direccion = txtdireccion.Text
                        Dim empleado As New EE.Empleadodeposito
                        empleado.codigo = 0
                        envio.empleado = empleado
                        envio.estado = "Atender"
                        envio.fechadellegada = DateTimePicker1.Value
                        envio.fechadesalida = DateTimePicker2.Value
                        envio.venta = cmbventa.SelectedItem
                        bllenvio.generarenvio(envio)
                        MessageBox.Show(mensaje3)
                        bllbitacora.generarbitacora("Generar envio", "Tabla Envio", Servicios.SesionManager.obtenerinstancia)
                        envio.venta.estado = "Envio atendido"
                        bllventa.Modificar(envio.venta)
                        actualizar1()
                        actualizardata()
                        txtcodigo.Text = ""
                        txtdireccion.Text = ""
                        txtestado.Text = ""
                        DateTimePicker1.Value = DateTime.Now
                        DateTimePicker2.Value = DateTime.Now
                    Else
                        MessageBox.Show(mensaje4)
                    End If
                Else
                    MessageBox.Show(mensaje1)
                End If
            Else
                MessageBox.Show(mensaje5)

            End If


        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error generar envio", "Tabla Envio", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Envioasignar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mensaje3 = "Envio generado"
        Singletonidioma._instancia.Agregar(Me)

        mensaje4 = "No se puede realizar un envio sin una direccion"


        mensaje5 = "No se puede realizar un envio sin una venta"


        mensaje6 = "Datos ingresados en los campos incompatibles"


        mensaje7 = "Empleado asignado"




        actualizar1()
        actualizardata()
        txtcodigo.Enabled = False
        txtestado.Enabled = False
        mensaje1 = "Limpie los campos"
        mensaje2 = "Seleccione un envio"




        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Envio")
        If verificador = True Then
            Button1.Enabled = True
            valorp2 = 1
        Else
            Button1.Enabled = False

        End If

        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Asignar Envio")
        If verificador = True Then

            Button2.Enabled = False
            valorp = 1
        Else

            Button2.Enabled = False

        End If

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(362, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 362)
        bllpalabra.verificacionpalabras(364, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 364)
        bllpalabra.verificacionpalabras(363, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 363)
        bllpalabra.verificacionpalabras(366, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 366)
        bllpalabra.verificacionpalabras(367, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 367)
        bllpalabra.verificacionpalabras(141, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 141)
        bllpalabra.verificacionpalabras(142, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 142)
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

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)



    End Sub

    Public Sub actualizar1()
        Me.cmbempleado.DataSource = Nothing
        Me.cmbempleado.DataSource = bllempleadodeposito.Listarempleadodeposito
        Me.cmbempleado.DisplayMember = "Codigo"

        Me.cmbventa.DataSource = Nothing
        Me.cmbventa.DataSource = bllventa.Listarenvio

    End Sub

    Public Sub actualizardata()
        listaenvio.Clear()
        Me.DataGridView1.DataSource = Nothing
        If bllenvio.Listarenvio() Is Nothing Then
            Exit Sub
        End If
        For Each n In bllenvio.Listarenvio
            If n.empleado Is Nothing Then
                Dim emp As New EE.Empleadodeposito
                n.empleado = emp
                n.empleado.nombre = "Asignar"
            End If
            listaenvio.Add(n)
        Next
        Me.DataGridView1.DataSource = listaenvio
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje2)
            Else
                Dim envio As New EE.Envio
                envio.direccion = txtdireccion.Text
                envio.codigo = txtcodigo.Text
                envio.empleado = cmbempleado.SelectedItem
                envio.estado = txtestado.Text
                envio.fechadellegada = DateTimePicker1.Value
                envio.fechadesalida = DateTimePicker2.Value
                envio.venta = cmbventa.SelectedItem

                bllenvio.Modificarenvio(envio)
                MessageBox.Show(mensaje7)
                bllbitacora.generarbitacora("Asignar empleado", "Tabla Envio", Servicios.SesionManager.obtenerinstancia)
            End If
            actualizardata()
            txtcodigo.Text = ""
            txtdireccion.Text = ""
            txtestado.Text = ""
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now
            Button2.Enabled = False
        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error asignar empleado", "Tabla Envio", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Envio = a.DataBoundItem
            txtcodigo.Text = p.codigo
            txtdireccion.Text = p.direccion
            txtestado.Text = p.estado
            DateTimePicker1.Text = p.fechadellegada
            DateTimePicker2.Text = p.fechadesalida
            Dim lstventa As New List(Of EE.Venta)
            lstventa.Add(p.venta)
            cmbventa.DataSource = lstventa
            If p.empleado.nombre = "Asignar" And valorp = 1 Then
                Button2.Enabled = True
            Else
                Button2.Enabled = False
            End If

            If p.estado = "Atender" And valorp2 = 1 Then
                Button1.Enabled = False
            End If

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtcodigo.Text = ""
        txtdireccion.Text = ""
        txtestado.Text = ""
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
        actualizar1()
        If valorp2 = 1 Then
            Button1.Enabled = True
        End If
    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(362, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 362)
        bllpalabra.verificacionpalabras(364, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 364)
        bllpalabra.verificacionpalabras(363, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 363)
        bllpalabra.verificacionpalabras(366, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 366)
        bllpalabra.verificacionpalabras(367, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 367)
        bllpalabra.verificacionpalabras(141, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 141)
        bllpalabra.verificacionpalabras(142, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 142)
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

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)

    End Sub
End Class