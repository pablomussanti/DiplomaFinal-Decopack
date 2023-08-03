Imports EE
Imports BLL
Imports Servicios
Public Class Deposito
    Implements Iidiomaobserver

    Dim blldeposito As New BLLdeposito
    Dim blltraduccion As New BLLtraduccion
    Dim bllpalabra As New BLLpalabra
    Dim mensaje1 As String
    Dim bllbitacora As New BLLbitacora
    Dim mensaje2 As String

    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String

    Private Sub Sucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        txtcodigo.Enabled = False
        actualizar()
        Singletonidioma._instancia.Agregar(Me)
        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Deposito")
        If verificador = True Then
            Button1.Enabled = True

            Button3.Enabled = True

        Else
            Button1.Enabled = False

            Button3.Enabled = False

        End If

        mensaje3 = "Datos incompatibles en los campos"


        mensaje4 = "Deposito actualizado"


        mensaje5 = "Deposito generado"



        mensaje1 = "Seleccione el deposito a Modificar"
        mensaje2 = "Limpie los campos"


        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(346, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 346)
        bllpalabra.verificacionpalabras(347, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 347)
        bllpalabra.verificacionpalabras(348, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 348)
        bllpalabra.verificacionpalabras(85, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 85)
        bllpalabra.verificacionpalabras(109, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 109)
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

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If txtcodigopostal.Text > 0 Then
                If txttelefono.Text > 0 Then


                    Dim i As Integer = 0
                    Dim z As Integer = 0

                    Dim deposito As New EE.Deposito
                    If blldeposito.Listardeposito IsNot Nothing Then
                        If txtcodigo.Text = "" Then
                            MessageBox.Show(mensaje1)
                            Exit Sub
                        Else
                            deposito.codigo = txtcodigo.Text
                            i = 1

                        End If
                    Else
                        z = 1

                    End If
                    deposito.codigopostal = txtcodigopostal.Text
                    deposito.detalle = txtdetalle.Text
                    deposito.direccion = txtdireccion.Text
                    deposito.telefono = txttelefono.Text
                    blldeposito.Creardeposito(deposito)
                    If i = 1 Then
                        MessageBox.Show(mensaje4)
                        bllbitacora.generarbitacora("Modificacion deposito", "Tabla Deposito", Servicios.SesionManager.obtenerinstancia)
                    End If
                    If z = 1 Then
                        MessageBox.Show(mensaje5)
                        bllbitacora.generarbitacora("Alta Deposito", "Tabla Deposito", Servicios.SesionManager.obtenerinstancia)
                    End If
                    actualizar()
                    limpiar()

                Else
                    MessageBox.Show(mensaje3)


                End If




            Else
                MessageBox.Show(mensaje3)


            End If



        Catch ex As Exception
            MessageBox.Show(mensaje3)
            bllbitacora.generarbitacora("Error A/M deposito", "Tabla Deposito", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub limpiar()
        txtcodigo.Text = ""
        txtcodigopostal.Text = ""
        txtdetalle.Text = ""
        txtdireccion.Text = ""
        txttelefono.Text = ""



    End Sub

    Public Sub actualizar()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = blldeposito.Listardeposito
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Deposito = a.DataBoundItem
            txtcodigo.Text = p.codigo
            txtcodigopostal.Text = p.codigopostal
            txtdetalle.Text = p.detalle
            txtdireccion.Text = p.direccion
            txttelefono.Text = p.telefono
        End If


    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(346, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 346)
        bllpalabra.verificacionpalabras(347, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 347)
        bllpalabra.verificacionpalabras(348, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 348)
        bllpalabra.verificacionpalabras(85, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 85)
        bllpalabra.verificacionpalabras(109, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 109)
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

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
    End Sub
End Class