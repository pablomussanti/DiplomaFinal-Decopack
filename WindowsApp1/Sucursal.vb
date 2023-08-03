Imports EE
Imports BLL
Imports Servicios
Public Class Sucursal
    Implements Iidiomaobserver

    Dim bllsucursal As New BLLsucursal
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim bllbitacora As New BLLbitacora
    Dim mensaje1 As String
    Dim valorp As Integer = 0
    Dim mensaje2 As String

    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String

    Private Sub Sucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcodigo.Enabled = False
        actualizar()
        Button2.Enabled = False
        mensaje1 = "Seleccione una sucursal"


        Singletonidioma._instancia.Agregar(Me)
        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Sucursal")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = True
            valorp = 1
        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False

        End If


        mensaje2 = "Alta sucursal exitosa"


        mensaje3 = "Actualizacion de sucursal exitosa"


        mensaje4 = "Datos incompatibles en los campos"


        mensaje5 = "Baja sucursal exitosa"

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(303, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 303)

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


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(423, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 423)

        bllpalabra.verificacionpalabras(424, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 424)


        bllpalabra.verificacionpalabras(425, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 425)


        bllpalabra.verificacionpalabras(426, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 426)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If txtcodigopostal.Text > 0 Then

                If txttelefono.Text > 0 Then



                    Dim i As Integer = 0
                    Dim z As Integer = 0
                    Dim sucursal As New EE.Sucursal
                    sucursal.codigopostal = txtcodigopostal.Text
                    sucursal.detalle = txtdetalle.Text
                    sucursal.direccion = txtdireccion.Text
                    sucursal.estado = "Activo"
                    sucursal.telefono = txttelefono.Text
                    If txtcodigo.Text = "" Then
                        i = 1
                    Else
                        sucursal.codigo = txtcodigo.Text
                        z = 1
                    End If
                    bllsucursal.Crearsucursal(sucursal)
                    If i = 1 Then
                        bllbitacora.generarbitacora("Alta sucursal", "Tabla Sucursal", Servicios.SesionManager.obtenerinstancia)
                        MessageBox.Show(mensaje2)
                    End If
                    If z = 1 Then
                        bllbitacora.generarbitacora("Modificacion sucursal", "Tabla Sucursal", Servicios.SesionManager.obtenerinstancia)
                        MessageBox.Show(mensaje3)
                    End If

                    actualizar()
                    limpiar()

                Else
                    MessageBox.Show(mensaje4)


                End If
            Else

                MessageBox.Show(mensaje4)

            End If



        Catch ex As Exception
            MessageBox.Show(mensaje4)
            bllbitacora.generarbitacora("Error A/M sucursal", "Tabla Sucursal", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub limpiar()
        txtcodigo.Text = ""
        txtcodigopostal.Text = ""
        txtdetalle.Text = ""
        txtdireccion.Text = ""
        txttelefono.Text = ""
        Button2.Enabled = False
    End Sub

    Public Sub actualizar()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllsucursal.Listarsucursal
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
        Button2.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim sucursal As New EE.Sucursal
            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje1)
            Else
                sucursal.codigo = txtcodigo.Text
                sucursal.codigopostal = txtcodigopostal.Text
                sucursal.detalle = txtdetalle.Text
                sucursal.direccion = txtdireccion.Text
                sucursal.estado = "Baja"
                sucursal.telefono = txttelefono.Text
                bllsucursal.Crearsucursal(sucursal)
                MessageBox.Show(mensaje5)
                bllbitacora.generarbitacora("Baja sucursal", "Tabla Sucursal", Servicios.SesionManager.obtenerinstancia)
            End If
            Button2.Enabled = False
            actualizar()
            limpiar()

        Catch ex As Exception
            MessageBox.Show(mensaje4)
            bllbitacora.generarbitacora("Error baja sucursal", "Tabla Sucursal", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Sucursal = a.DataBoundItem
            txtcodigo.Text = p.codigo
            txtcodigopostal.Text = p.codigopostal
            txtdetalle.Text = p.detalle
            txtdireccion.Text = p.direccion
            txttelefono.Text = p.telefono
            If valorp = 1 Then
                Button2.Enabled = True
            End If

        End If


    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(303, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 303)

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


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(423, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 423)

        bllpalabra.verificacionpalabras(424, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 424)


        bllpalabra.verificacionpalabras(425, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 425)


        bllpalabra.verificacionpalabras(426, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 426)

    End Sub
End Class