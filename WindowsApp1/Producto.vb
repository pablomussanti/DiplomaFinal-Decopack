Imports EE
Imports BLL
Imports Servicios
Public Class Producto
    Implements Iidiomaobserver

    Dim BLLproducto As New BLLproducto
    Dim blltraduccion As New BLLtraduccion
    Dim bllbitacora As New BLLbitacora
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim valorp As Integer = 0
    Dim bllpalabra As New BLLpalabra
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim mensaje9 As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If TextBox1.Text = "" Then
                If txtprecio.Text > 0 Then
                    Dim producto As New EE.Producto
                    Dim variabledeestado As String
                    producto.nombre = txtnombre.Text
                    producto.descripcion = txtdescripcion.Text
                    producto.precio = txtprecio.Text
                    producto.estado = "Activo"
                    If TextBox1.Text = Nothing Then
                        variabledeestado = "Alta"
                    Else
                        producto.codigo = TextBox1.Text
                        variabledeestado = "Modificacion"
                    End If
                    producto.dvh = Servicios.Seguridad.GenerarSHA(producto.nombre & producto.descripcion & producto.precio)
                    BLLproducto.Crearproducto(producto)
                    actualizar()
                    integridadDVV()

                    Dim usuario As New Servicios.Usuario
                    usuario = Servicios.SesionManager.obtenerinstancia
                    Dim ccproducto As New Servicios.CCproducto
                    ccproducto.Descripcion = txtdescripcion.Text
                    ccproducto.Nombre = txtnombre.Text
                    If TextBox1.Text = Nothing Then
                        ccproducto.Tipo = "Alta"
                    Else
                        ccproducto.Tipo = "Modificacion"
                    End If
                    ccproducto.Usuario = usuario.user
                    ccproducto.Fecha = DateTime.Now
                    BLLproducto.Resguardarentidad(ccproducto)
                    MessageBox.Show(mensaje4)
                    bllbitacora.generarbitacora(variabledeestado & " producto", "Tabla Producto", Servicios.SesionManager.obtenerinstancia)
                    limpiar()
                Else
                    MessageBox.Show(mensaje5)
                End If



            Else
                MessageBox.Show(mensaje2)


            End If

        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error A/M producto", "Tabla Producto", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub actualizar()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = BLLproducto.Listarproducto()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim producto As New EE.Producto
            If TextBox1.Text = Nothing Then
                MessageBox.Show(mensaje3)
            Else
                producto.codigo = TextBox1.Text
                producto.nombre = txtnombre.Text
                producto.descripcion = txtdescripcion.Text
                producto.precio = txtprecio.Text
                producto.estado = "Baja"
                producto.dvh = TextBox2.Text
                BLLproducto.Crearproducto(producto)
                bllbitacora.generarbitacora("Eliminar producto", "Tabla Producto", Servicios.SesionManager.obtenerinstancia)
                actualizar()
                integridadDVV()
                Dim usuario As New Servicios.Usuario
                usuario = Servicios.SesionManager.obtenerinstancia
                Dim ccproducto As New Servicios.CCproducto
                ccproducto.Descripcion = txtdescripcion.Text
                ccproducto.Nombre = txtnombre.Text
                ccproducto.Tipo = "Baja"
                ccproducto.Usuario = usuario.user
                ccproducto.Fecha = DateTime.Now
                BLLproducto.Resguardarentidad(ccproducto)
                MessageBox.Show(mensaje7)
            End If


            Button2.Enabled = False
            limpiar()

        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error Eliminar producto", "Tabla Producto", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mensaje4 = "Producto generado"

        mensaje1 = "Se recomienda hacer restore de un backup anterior, se presenta un error en el codigo"


        mensaje2 = "Limpie los campos"

        mensaje3 = "Seleccione un producto"

        mensaje5 = "Precio incompatible"

        Singletonidioma._instancia.Agregar(Me)
        mensaje6 = "Datos incompatibles segun los campos"


        mensaje7 = "Baja producto exitosa"


        mensaje8 = "Mantega el formato de la fila, reintentar o limpie los campos y intente nuevamente"


        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Producto")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = True
            Button4.Enabled = True
            valorp = 1

        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False

        End If

        actualizar()
        TextBox1.Enabled = False
        actualizardvv()
        verificarintegridad()
        TextBox2.Enabled = False





        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(388, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 388)
        bllpalabra.verificacionpalabras(389, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 389)
        bllpalabra.verificacionpalabras(390, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 390)
        bllpalabra.verificacionpalabras(391, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 391)
        bllpalabra.verificacionpalabras(392, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 392)
        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        bllpalabra.verificacionpalabras(Label5.Tag, Label5.Text)
        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)
        Label5.Text = blltraduccion.Traduccion(idioma, Label5.Tag)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)

        bllpalabra.verificacionpalabras(186, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 186)

        bllpalabra.verificacionpalabras(186, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 186)


        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)
    End Sub

    Public Sub verificarintegridad()
        If BLLproducto.Listarproducto Is Nothing Then Exit Sub

        For Each productos In BLLproducto.Listarproductotodo
            If productos.dvh = Servicios.Seguridad.GenerarSHA(productos.nombre & productos.descripcion & productos.precio) Then

            Else
                MessageBox.Show(String.Format("{0} {1}", mensaje1, productos.codigo))

            End If
        Next
    End Sub

    Public Sub integridadDVV()
        Dim cadena As String = ""
        Dim cadenaconvertida As String
        Dim dvvlistamiento As New List(Of Servicios.DVV)
        Dim lstproductos As List(Of EE.Producto)
        lstproductos = BLLproducto.Listarproducto()
        For Each n In lstproductos
            cadena = cadena & n.dvh
        Next
        cadenaconvertida = Servicios.Seguridad.GenerarSHA(cadena)

        dvvlistamiento = BLLproducto.DVVlistar()

        If dvvlistamiento IsNot Nothing Then
            BLLproducto.DVVactualizar(cadenaconvertida)
        Else
            BLLproducto.DVVcrear(cadenaconvertida)
        End If
        actualizardvv()
    End Sub
    Public Sub actualizardvv()
        Me.DataGridView2.DataSource = Nothing
        Me.DataGridView2.DataSource = BLLproducto.DVVlistar()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Producto = a.DataBoundItem
            TextBox1.Text = p.codigo
            txtnombre.Text = p.nombre
            txtdescripcion.Text = p.descripcion
            txtprecio.Text = p.precio
            TextBox2.Text = p.dvh
            If valorp = 1 Then
                Button2.Enabled = True
            End If
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim n As New CCproducto
        n.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        limpiar()
    End Sub

    Public Sub limpiar()
        txtdescripcion.Text = ""
        txtnombre.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        txtprecio.Text = ""
        Button2.Enabled = False
    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(388, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 388)
        bllpalabra.verificacionpalabras(389, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 389)
        bllpalabra.verificacionpalabras(390, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 390)
        bllpalabra.verificacionpalabras(391, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 391)
        bllpalabra.verificacionpalabras(392, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 392)
        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        bllpalabra.verificacionpalabras(Label5.Tag, Label5.Text)
        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)
        Label5.Text = blltraduccion.Traduccion(idioma, Label5.Tag)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)

        bllpalabra.verificacionpalabras(186, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 186)

        bllpalabra.verificacionpalabras(186, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 186)


        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)
    End Sub
End Class