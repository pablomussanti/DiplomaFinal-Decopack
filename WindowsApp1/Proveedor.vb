Imports EE
Imports Servicios
Imports BLL
Public Class Proveedor
    Implements Iidiomaobserver

    Dim bllproveedor As New BLLproveedor
    Dim bllproveedorproducto As New BLLproveedorproducto
    Dim listaproveedorproducto As New List(Of proveedorproducto)
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim nn As New BLLproducto
    Dim bllbitacora As New BLLbitacora
    Dim mensaje1 As String
    Dim mensaje3 As String
    Dim mensaje2 As String
    Dim valorp As Integer = 0
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim mensaje9 As String
    Dim mensaje10 As String
    Dim mensaje11 As String
    Dim mensaje12 As String
    Dim mensaje13 As String
    Dim mensaje14 As String
    Dim mensaje15 As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If txtcodigo.Text = "" Then
                If txttelefono.Text > 0 Then
                    Dim proveedor As New EE.Proveedor
                    proveedor.cantidaddeerrores = 0
                    proveedor.direccion = txtdireccion.Text
                    proveedor.nombre = txtnombre.Text
                    proveedor.estado = "Activo"
                    proveedor.telefono = txttelefono.Text
                    bllproveedor.Crearproveedor(proveedor)
                    MessageBox.Show(mensaje4)
                    bllbitacora.generarbitacora("Alta proveedor", "Tabla Proveedor", Servicios.SesionManager.obtenerinstancia)
                    limpiar()
                    actualizar()
                Else
                    MessageBox.Show(mensaje5)

                End If
            Else
                MessageBox.Show(mensaje2)

            End If



        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error alta proveedor", "Tabla Proveedor", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mensaje4 = "Proveedor generado"


        mensaje5 = "Valor telefono incompatible"


        mensaje6 = "Los datos ingresados no corresponden al formato del campo"
        Singletonidioma._instancia.Agregar(Me)

        mensaje7 = "Producto dado de baja con exito"


        mensaje8 = "Los datos ingresados no corresponden al formato del campo, revise los campos o ponga limpiar y reseleccione el proveedor"


        mensaje9 = "Producto modificado"


        mensaje10 = "Proveedor advertido con exito"


        mensaje11 = "Se Modifico el detalle"


        mensaje12 = "Se genero el detalle"


        mensaje13 = "Precio incompatible"


        mensaje14 = "Se genero la baja"


        mensaje15 = "No se pudo realizar la baja, verifique que exista el producto correspondiente asociado"



        txtcodigo.Enabled = False
        txtcantidaddeerrores.Enabled = False
        actualizar()

        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Proveedor")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = True
            valorp = 1

        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False


        End If

        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Proveedor Asignar")
        If verificador = True Then

            Button6.Enabled = True
            Button7.Enabled = True

        Else

            Button6.Enabled = False
            Button7.Enabled = False

        End If

        mensaje1 = "Seleccione un proveedor"

        mensaje2 = "Limpie los campos"

        mensaje3 = "Ingrese un monto"



        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(393, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 393)

        bllpalabra.verificacionpalabras(394, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 394)


        bllpalabra.verificacionpalabras(395, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 395)


        bllpalabra.verificacionpalabras(396, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 396)

        bllpalabra.verificacionpalabras(397, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 397)

        bllpalabra.verificacionpalabras(398, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 398)

        bllpalabra.verificacionpalabras(399, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 399)

        bllpalabra.verificacionpalabras(400, mensaje11)
        mensaje11 = blltraduccion.Traduccion(idioma, 400)

        bllpalabra.verificacionpalabras(401, mensaje12)
        mensaje12 = blltraduccion.Traduccion(idioma, 401)

        bllpalabra.verificacionpalabras(402, mensaje13)
        mensaje13 = blltraduccion.Traduccion(idioma, 402)

        bllpalabra.verificacionpalabras(403, mensaje14)
        mensaje14 = blltraduccion.Traduccion(idioma, 403)

        bllpalabra.verificacionpalabras(404, mensaje15)
        mensaje15 = blltraduccion.Traduccion(idioma, 404)


        bllpalabra.verificacionpalabras(286, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 286)

        bllpalabra.verificacionpalabras(287, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 287)

        bllpalabra.verificacionpalabras(288, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 288)


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
        bllpalabra.verificacionpalabras(Label8.Tag, Label8.Text)
        Label8.Text = blltraduccion.Traduccion(idioma, Label8.Tag)


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


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)


    End Sub

    Public Sub limpiar()
        txtcodigo.Text = ""
        txtdireccion.Text = ""
        txtcantidaddeerrores.Text = ""
        txtnombre.Text = ""
        txttelefono.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        limpiar()
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim proveedor As New EE.Proveedor
            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje1)
            Else
                proveedor.codigo = txtcodigo.Text
                proveedor.cantidaddeerrores = txtcantidaddeerrores.Text
                proveedor.direccion = txtdireccion.Text
                proveedor.nombre = txtnombre.Text
                proveedor.estado = "Baja"
                proveedor.telefono = txttelefono.Text
                bllproveedor.Modificarproveedor(proveedor)
                MessageBox.Show(mensaje7)
                bllbitacora.generarbitacora("Baja proveedor", "Tabla Proveedor", Servicios.SesionManager.obtenerinstancia)
            End If
            actualizar()
            limpiar()
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error baja proveedor", "Tabla Proveedor", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim proveedor As New EE.Proveedor
            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje1)
            Else
                proveedor.codigo = txtcodigo.Text
                proveedor.cantidaddeerrores = txtcantidaddeerrores.Text
                proveedor.direccion = txtdireccion.Text
                proveedor.nombre = txtnombre.Text
                proveedor.telefono = txttelefono.Text
                bllproveedor.Modificarproveedor(proveedor)
                MessageBox.Show(mensaje9)
                bllbitacora.generarbitacora("Modificar proveedor", "Tabla Proveedor", Servicios.SesionManager.obtenerinstancia)
            End If
            actualizar()
            limpiar()
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False

        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error modificar proveedor", "Tabla Proveedor", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim proveedor As New EE.Proveedor
            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje1)
            Else
                proveedor.codigo = txtcodigo.Text
                bllproveedor.generaradvertencia(proveedor, txtcantidaddeerrores.Text)
                ' proveedor.cantidaddeerrores = (txtcantidaddeerrores.Text + 1)
                proveedor.direccion = txtdireccion.Text
                proveedor.nombre = txtnombre.Text
                proveedor.estado = "Activo"
                proveedor.telefono = txttelefono.Text
                bllproveedor.Modificarproveedor(proveedor)
                MessageBox.Show(mensaje10)
                bllbitacora.generarbitacora("Generar advertencia", "Tabla Proveedor", Servicios.SesionManager.obtenerinstancia)
            End If
            actualizar()
            limpiar()
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False

        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error generar advertencia", "Tabla Proveedor", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub actualizar()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllproveedor.Listarproveedor
        actualizar1()
        actualizardata()

    End Sub

    Public Sub actualizar1()
        Me.ComboBox2.DataSource = Nothing
        Me.ComboBox2.DataSource = nn.Listarproducto
        Me.ComboBox2.DisplayMember = "Nombre"
        Me.ComboBox1.DataSource = Nothing
        Me.ComboBox1.DataSource = bllproveedor.Listarproveedor
        Me.ComboBox1.DisplayMember = "Nombre"
    End Sub


    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Proveedor = a.DataBoundItem
            txtcodigo.Text = p.codigo
            txtnombre.Text = p.nombre
            txtcantidaddeerrores.Text = p.cantidaddeerrores
            txtdireccion.Text = p.direccion
            txttelefono.Text = p.telefono

            If valorp = 1 Then
                Button2.Enabled = True
                Button3.Enabled = True
                Button4.Enabled = True
            End If
        End If


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje3)

            Else
                If TextBox1.Text > 0 Then

                    Dim proveedorproducto As New EE.proveedorproducto
                    Dim registro As Integer = 0
                    proveedorproducto.producto = ComboBox2.SelectedItem
                    proveedorproducto.proveedor = ComboBox1.SelectedItem
                    proveedorproducto.precio = TextBox1.Text
                    If bllproveedorproducto.Listardetalle IsNot Nothing Then
                        For Each n In bllproveedorproducto.Listardetalle

                            If proveedorproducto.producto.codigo = n.producto.codigo Then
                                If n.proveedor.codigo = proveedorproducto.proveedor.codigo Then
                                    bllproveedorproducto.Modificardetalle(proveedorproducto)
                                    MessageBox.Show(mensaje11)
                                    bllbitacora.generarbitacora("Modificar detalle proveedor-producto", "Tabla ProveedorProducto", Servicios.SesionManager.obtenerinstancia)
                                    registro = 1
                                End If

                            End If

                        Next
                    End If

                    If registro = 0 Then
                        bllproveedorproducto.Generardetalle(proveedorproducto)
                        MessageBox.Show(mensaje12)
                        bllbitacora.generarbitacora("Generar detalle proveedor-producto", "Tabla ProveedorProducto", Servicios.SesionManager.obtenerinstancia)
                    End If
                    registro = 0
                    actualizar()
                Else
                    MessageBox.Show(mensaje13)

                End If


            End If


        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error Generar/Modificar detalle proveedor-producto", "Tabla ProveedorProducto", Servicios.SesionManager.obtenerinstancia)
        End Try


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Try
            Dim valorint As Integer = 0
            Dim valorcorrecto As Integer = 0
            Dim proveedorproducto As New EE.proveedorproducto
            proveedorproducto.producto = ComboBox2.SelectedItem
            proveedorproducto.proveedor = ComboBox1.SelectedItem
            If bllproveedorproducto.Listardetalle IsNot Nothing Then
                For Each n In bllproveedorproducto.Listardetalle

                    If proveedorproducto.producto.codigo = n.producto.codigo Then
                        If n.proveedor.codigo = proveedorproducto.proveedor.codigo Then
                            bllproveedorproducto.Eliminardetalle(proveedorproducto)
                            MessageBox.Show(mensaje14)
                            valorcorrecto = 1
                            bllbitacora.generarbitacora("Baja detalle proveedor-producto", "Tabla ProveedorProducto", Servicios.SesionManager.obtenerinstancia)
                        Else
                            valorint = 1
                        End If

                    End If

                Next
            End If
            If valorint = 1 And valorcorrecto = 0 Then
                MessageBox.Show(mensaje15)
            End If
            actualizar()
        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error baja detalle proveedor-producto", "Tabla ProveedorProducto", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub


    Public Sub actualizardata()
        Me.DataGridView2.DataSource = Nothing
        If bllproveedorproducto.Listardetalle Is Nothing Then
            Exit Sub

        Else
            Me.DataGridView2.DataSource = bllproveedorproducto.Listardetalle
        End If


    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(393, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 393)

        bllpalabra.verificacionpalabras(394, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 394)


        bllpalabra.verificacionpalabras(395, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 395)


        bllpalabra.verificacionpalabras(396, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 396)

        bllpalabra.verificacionpalabras(397, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 397)

        bllpalabra.verificacionpalabras(398, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 398)

        bllpalabra.verificacionpalabras(399, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 399)

        bllpalabra.verificacionpalabras(400, mensaje11)
        mensaje11 = blltraduccion.Traduccion(idioma, 400)

        bllpalabra.verificacionpalabras(401, mensaje12)
        mensaje12 = blltraduccion.Traduccion(idioma, 401)

        bllpalabra.verificacionpalabras(402, mensaje13)
        mensaje13 = blltraduccion.Traduccion(idioma, 402)

        bllpalabra.verificacionpalabras(403, mensaje14)
        mensaje14 = blltraduccion.Traduccion(idioma, 403)

        bllpalabra.verificacionpalabras(404, mensaje15)
        mensaje15 = blltraduccion.Traduccion(idioma, 404)


        bllpalabra.verificacionpalabras(286, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 286)

        bllpalabra.verificacionpalabras(287, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 287)

        bllpalabra.verificacionpalabras(288, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 288)


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
        bllpalabra.verificacionpalabras(Label8.Tag, Label8.Text)
        Label8.Text = blltraduccion.Traduccion(idioma, Label8.Tag)


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


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)
    End Sub
End Class