Imports EE
Imports BLL
Imports Servicios
Public Class Venta
    Implements Iidiomaobserver
    Dim venta As New EE.Venta
    Dim bllproducto As New BLLproducto
    Dim productos As New EE.Producto
    Dim bllsucursal As New BLLsucursal
    Dim listaproducto As New List(Of EE.Producto)
    Dim bllempleadosucursal As New BLLempleadosucursal
    Dim bllcomprador As New BLLcomprador
    Dim bllventa As New BLLventa
    Dim blldetalleventa As New BLLdetalleventa
    Dim bllstocksucursal As New BLLstocksucursal
    Dim bllstockdeposito As New BLLstockdeposito
    Dim blldeposito As New BLLdeposito
    Dim bllbitacora As New BLLbitacora
    Dim bllpalabra As New BLLpalabra
    Dim carrito As New List(Of EE.Carritomuestra)
    Dim blltraduccion As New BLLtraduccion
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Shared descuento As Double
    Dim variable1 As String
    Dim variable2 As String
    Shared descuento2 As Double
    Dim bllpermisos As New BLLpermiso
    Dim sucursalelegida As New EE.Sucursal
    Dim verificador As Boolean
    Dim mensaje9 As String
    Dim mensaje10 As String
    Dim mensaje11 As String
    Dim mensaje12 As String
    Dim mensaje13 As String
    Dim mensaje14 As String
    Dim mensaje15 As String
    Dim mensaje16 As String
    Dim mensaje17 As String
    Dim mensaje18 As String
    Dim mensaje19 As String
    Dim mensaje20 As String
    Dim mensaje21 As String
    Dim lstdetodoslosproductos As New List(Of EE.Producto)
    Dim lststocksucursal As New List(Of EE.Stocksucursal)
    Dim lststockdeposito As New List(Of EE.Stockdeposito)
    Dim lstdeposito As New List(Of EE.Deposito)
    Dim depo As New EE.Deposito
    Dim verificador2 As Integer = 0
    Dim verificador1 As Integer = 0

    Private Sub Venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        txtprod.Enabled = False
        txtprod2.Enabled = False
        txtprod3.Enabled = False
        txtprod4.Enabled = False
        txtprod5.Enabled = False
        TextBox1.Enabled = False
        ComboBox4.Enabled = False

        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = True

            Button5.Enabled = True
            Button6.Enabled = True

        Else
            Button1.Enabled = False
            Button2.Enabled = False

            Button5.Enabled = False
            Button6.Enabled = False

        End If

        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
        If verificador = True Then


            Button3.Enabled = True
            Button4.Enabled = True

        Else


            Button3.Enabled = False
            Button4.Enabled = False

        End If

        Button4.Enabled = False
        Button3.Enabled = False

        txtestado.Enabled = False
        txtfecha.Enabled = False
        txtmonto.Enabled = False
        txtpagado.Enabled = False
        txtcodigo.Enabled = False
        actualizar()
        actualizar3()


        Singletonidioma._instancia.Agregar(Me)

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        mensaje8 = "Ingrese el descuento para los clientes"
        mensaje7 = "Ingrese el descuento para los socios"

        bllpalabra.verificacionpalabras(559, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 559)

        bllpalabra.verificacionpalabras(558, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 558)

        Try
            variable1 = InputBox(mensaje8, " ")
            If variable1 = "" Then
                descuento2 = 0

            Else
                descuento2 = variable1

            End If
            variable2 = InputBox(mensaje7, " ")
            If variable2 = "" Then
                descuento = 0

            Else
                descuento = variable2

            End If
        Catch ex As Exception

        End Try

        descuento = descuento * 0.01
        descuento = 1 - descuento
        descuento2 = descuento2 * 0.01
        descuento2 = 1 - descuento2

        mensaje1 = "No se posee el stock suficiente en el deposito del producto "

        mensaje2 = "No se posee el stock suficiente en la sucursal del producto "

        mensaje3 = "Seleccione un metodo de entrega"

        mensaje4 = "Ingrese una cantidad"

        mensaje5 = "Seleccione los productos con las cantidades"

        mensaje6 = "Seleccione una venta"


        mensaje9 = "Cantidad incompatible"


        mensaje10 = "Seleccione un producto"


        mensaje11 = "Formato introducido incorrecto segun los campos"


        mensaje12 = "Venta generada"


        mensaje13 = "Pago confirmado"


        mensaje14 = "Seleccione un metodo de pago"


        mensaje15 = "No se puede volver a pagar una venta"


        mensaje16 = "Se ha establecido la forma de entrega"


        mensaje17 = "Verifique que haya cobrado el producto"


        mensaje18 = "Al recargar los productos se eliminara los productos del carrito, desea continuar?"

        mensaje19 = "Ventana de confirmacion"

        mensaje20 = "No se cuenta con stock"

        mensaje21 = "No se puede realizar la venta, se posee stock que no se encuentran en un lugar definido, verifique que se cumpla el stock de los productos solicitados de la venta en la sucursal o en el deposito."








        bllpalabra.verificacionpalabras(500, mensaje18)
        mensaje18 = blltraduccion.Traduccion(idioma, 500)

        bllpalabra.verificacionpalabras(501, mensaje19)
        mensaje19 = blltraduccion.Traduccion(idioma, 501)

        bllpalabra.verificacionpalabras(502, mensaje20)
        mensaje20 = blltraduccion.Traduccion(idioma, 502)

        bllpalabra.verificacionpalabras(503, mensaje21)
        mensaje21 = blltraduccion.Traduccion(idioma, 503)


        bllpalabra.verificacionpalabras(307, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 307)

        bllpalabra.verificacionpalabras(308, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 308)

        bllpalabra.verificacionpalabras(309, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 309)

        bllpalabra.verificacionpalabras(310, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 310)

        bllpalabra.verificacionpalabras(311, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 311)

        bllpalabra.verificacionpalabras(312, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 312)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
        bllpalabra.verificacionpalabras(Label5.Tag, Label5.Text)
        Label5.Text = blltraduccion.Traduccion(idioma, Label5.Tag)
        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)

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

        bllpalabra.verificacionpalabras(GroupBox4.Tag, GroupBox4.Text)
        GroupBox4.Text = blltraduccion.Traduccion(idioma, GroupBox4.Tag)


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)

        bllpalabra.verificacionpalabras(GroupBox3.Tag, GroupBox3.Text)
        GroupBox3.Text = blltraduccion.Traduccion(idioma, GroupBox3.Tag)


        bllpalabra.verificacionpalabras(GroupBox5.Tag, GroupBox5.Text)
        GroupBox5.Text = blltraduccion.Traduccion(idioma, GroupBox5.Tag)

        bllpalabra.verificacionpalabras(GroupBox6.Tag, GroupBox6.Text)
        GroupBox6.Text = blltraduccion.Traduccion(idioma, GroupBox6.Tag)

        bllpalabra.verificacionpalabras(RadioButton1.Tag, RadioButton1.Text)
        RadioButton1.Text = blltraduccion.Traduccion(idioma, RadioButton1.Tag)

        bllpalabra.verificacionpalabras(RadioButton2.Tag, RadioButton2.Text)
        RadioButton2.Text = blltraduccion.Traduccion(idioma, RadioButton2.Tag)

        bllpalabra.verificacionpalabras(RadioButton3.Tag, RadioButton3.Text)
        RadioButton3.Text = blltraduccion.Traduccion(idioma, RadioButton3.Tag)

        bllpalabra.verificacionpalabras(RadioButton4.Tag, RadioButton4.Text)
        RadioButton4.Text = blltraduccion.Traduccion(idioma, RadioButton4.Tag)

        bllpalabra.verificacionpalabras(441, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 441)


        bllpalabra.verificacionpalabras(440, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 440)


        bllpalabra.verificacionpalabras(439, mensaje11)
        mensaje11 = blltraduccion.Traduccion(idioma, 439)

        bllpalabra.verificacionpalabras(433, mensaje12)
        mensaje12 = blltraduccion.Traduccion(idioma, 433)

        bllpalabra.verificacionpalabras(434, mensaje13)
        mensaje13 = blltraduccion.Traduccion(idioma, 434)


        bllpalabra.verificacionpalabras(435, mensaje14)
        mensaje14 = blltraduccion.Traduccion(idioma, 435)


        bllpalabra.verificacionpalabras(436, mensaje15)
        mensaje15 = blltraduccion.Traduccion(idioma, 436)


        bllpalabra.verificacionpalabras(437, mensaje16)
        mensaje16 = blltraduccion.Traduccion(idioma, 437)

        bllpalabra.verificacionpalabras(438, mensaje17)
        mensaje17 = blltraduccion.Traduccion(idioma, 438)

    End Sub

    Public Sub actualizar()
        Dim bllstocksucursal As New BLLstocksucursal
        Dim lstsucursal As New List(Of EE.Sucursal)
        Dim contador As Integer = 0
        Me.ComboBox2.DataSource = Nothing
        For Each n In bllstocksucursal.Listarstock
            If n.cantidad > 0 Then

                If lstsucursal.Count = 0 Then
                    If bllempleadosucursal.Listarempleadoporsucursal(n.sucursal) IsNot Nothing Then
                        lstsucursal.Add(n.sucursal)

                    End If

                Else
                    For Each nn In lstsucursal
                        If nn.codigo = n.sucursal.codigo Then

                        Else
                            contador = 1
                        End If
                    Next
                    If contador = 1 Then
                        If bllempleadosucursal.Listarempleadoporsucursal(n.sucursal) IsNot Nothing Then
                            lstsucursal.Add(n.sucursal)
                            contador = 0
                        End If

                    End If
                End If



            End If

        Next
        Me.ComboBox2.DataSource = lstsucursal
        Me.ComboBox2.DisplayMember = "Detalle"

        Me.ComboBox1.DataSource = Nothing
        Dim lstcompra As New List(Of EE.Comprador)
        For Each n In bllcomprador.Listarcompradoractivos("socio")
            lstcompra.Add(n)
        Next
        For Each n In bllcomprador.Listarcompradoractivos("cliente")
            lstcompra.Add(n)
        Next

        Me.ComboBox1.DataSource = lstcompra
        Me.ComboBox1.DisplayMember = "Dni"
    End Sub

    Public Sub actualizar2()



        Me.DataGridView2.DataSource = Nothing

        Me.DataGridView2.DataSource = carrito
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            If txtcantidad.Text = "" Then
                MessageBox.Show(mensaje4)
            Else
                If txtprod.Text IsNot "" Then
                    If txtcantidad.Text > 0 Then
                        Dim producto As New EE.Producto

                        Dim carritomuestra As New EE.Carritomuestra
                        producto.codigo = txtprod.Text
                        producto.descripcion = txtprod2.Text
                        producto.dvh = txtprod3.Text
                        producto.nombre = txtprod4.Text
                        producto.precio = txtprod5.Text
                        producto.estado = TextBox1.Text
                        carritomuestra.producto = producto
                        Dim valorreferencia As Integer = 0
                        Dim totalidad As Integer = 0


                        bllventa.asignarstockdelasucursal(lststocksucursal, carritomuestra, sucursalelegida)

                        bllventa.asignarstockdeldeposito(lststockdeposito, carritomuestra, depo)

                        carritomuestra.stockrequerido = txtcantidad.Text

                        bllventa.asignarpreciocarritomuestra(lstdetodoslosproductos, carritomuestra)


                        If carrito.Count = 0 Then


                            If carritomuestra.stockdisponibledeposito >= carritomuestra.stockrequerido Or carritomuestra.stockdisponiblesucursal >= carritomuestra.stockrequerido Then

                                carrito.Add(carritomuestra)

                            Else
                                MessageBox.Show(mensaje20)
                                Exit Sub
                            End If


                        Else
                            Dim contador As Integer
                            For Each cmuestra In carrito
                                If carritomuestra.producto.codigo = cmuestra.producto.codigo Then
                                    If cmuestra.stockdisponiblesucursal > cmuestra.stockdisponibledeposito Then

                                        valorreferencia = cmuestra.stockdisponiblesucursal
                                    Else

                                        valorreferencia = cmuestra.stockdisponibledeposito

                                    End If

                                    totalidad = cmuestra.stockrequerido + carritomuestra.stockrequerido

                                    If totalidad > valorreferencia Then

                                        MessageBox.Show(mensaje20)
                                        Exit Sub

                                    Else

                                        bllventa.agregarstockalcarrito(cmuestra, carritomuestra)
                                    End If


                                Else

                                    contador = contador + 1
                                End If

                            Next
                            If contador = carrito.Count Then

                                If carritomuestra.stockdisponibledeposito >= carritomuestra.stockrequerido Or carritomuestra.stockdisponiblesucursal >= carritomuestra.stockrequerido Then

                                    carrito.Add(carritomuestra)

                                Else
                                    MessageBox.Show(mensaje20)
                                    Exit Sub
                                End If

                            End If
                        End If
                        actualizar2()
                    Else
                        MessageBox.Show(mensaje9)
                    End If

                Else
                    MessageBox.Show(mensaje10)
                End If


            End If


        Catch ex As Exception
            MessageBox.Show(mensaje11)
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Productomuestra = a.DataBoundItem


            txtprod.Text = p.producto.codigo
            txtprod2.Text = p.producto.descripcion
            txtprod3.Text = p.producto.dvh
            txtprod4.Text = p.producto.nombre
            txtprod5.Text = p.producto.precio
            TextBox1.Text = p.producto.estado

        End If


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If carrito.Count > 0 Then
                Dim respuesta As Integer
                respuesta = MsgBox(mensaje18, vbOKCancel, mensaje19)
                If respuesta = 2 Then
                    Exit Sub
                Else
                    carrito = New List(Of EE.Carritomuestra)
                End If
            End If

            Me.DataGridView1.DataSource = Nothing
            Dim sucursal As New EE.Sucursal
            sucursal = ComboBox2.SelectedItem
            Dim proddispo As New List(Of EE.Productomuestra)
            Dim contador As Integer = 0

            lstdetodoslosproductos = bllproducto.Listarproductotodo
            lststocksucursal = bllstocksucursal.Listarstock
            lststockdeposito = bllstockdeposito.Listarstock
            lstdeposito = blldeposito.Listardeposito

            asignarlugares()

            For Each prod In lstdetodoslosproductos
                For Each stksucu In lststocksucursal
                    If stksucu.producto.codigo = prod.codigo And stksucu.sucursal.codigo = sucursalelegida.codigo Then
                        If stksucu.cantidad > 0 Then


                            bllventa.verificacionsucursalproductos(proddispo, contador, prod)


                            DataGridView2.DataSource = Nothing
                            carrito.Clear()
                            ComboBox4.DataSource = Nothing
                        End If
                    End If

                Next


            Next

            For Each prod In lstdetodoslosproductos

                For Each stkdep In lststockdeposito
                    If stkdep.producto.codigo = prod.codigo And stkdep.deposito.codigo = depo.codigo Then
                        If stkdep.cantidad > 0 Then

                            bllventa.verificarproductodeposito(proddispo, contador, prod)

                        End If
                    End If
                    contador = 0
                Next


            Next


            DataGridView1.DataSource = proddispo


            Me.Combobox3.DataSource = Nothing
            Combobox3.DataSource = bllempleadosucursal.Listarempleadoporsucursal(sucursal)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub asignarlugares()
        For Each n In lstdeposito
            depo = n
        Next
        sucursalelegida = ComboBox2.SelectedItem
    End Sub

    Private Sub DataGridView3_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView3.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView3.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Venta = a.DataBoundItem
            Dim lstsucursal As New List(Of EE.Sucursal)
            Dim lstcomprador As New List(Of EE.Comprador)
            Dim lstempleado As New List(Of EE.Empleadosucursal)

            txtcodigo.Text = p.codigo
            txtestado.Text = p.estado
            txtfecha.Text = p.fecha
            txtmonto.Text = p.monto
            txtpagado.Text = p.pagado


            ComboBox2.DataSource = Nothing
            lstsucursal.Add(p.sucursal)
            ComboBox2.DataSource = lstsucursal
            Me.Combobox3.DataSource = Nothing
            lstempleado.Add(p.empleado)
            Combobox3.DataSource = lstempleado
            Me.ComboBox1.DataSource = Nothing
            lstcomprador.Add(p.comprador)
            ComboBox1.DataSource = lstcomprador


            If txtpagado.Text = "Efectivo" Then
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False
                Button3.Enabled = False
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then


                    Button3.Enabled = False

                Else


                    Button3.Enabled = False
                End If
            End If
            If txtpagado.Text = "Tarjeta" Then
                RadioButton1.Enabled = False
                Button3.Enabled = False
                RadioButton2.Enabled = False
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then

                    Button3.Enabled = False

                Else


                    Button3.Enabled = False

                End If
            End If
            If txtpagado.Text = "No" Then
                RadioButton1.Enabled = True
                RadioButton2.Enabled = True
                Button3.Enabled = True
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then


                    Button3.Enabled = True

                Else


                    Button3.Enabled = False

                End If
            End If
            If p.estado = "Solo envio" Then
                RadioButton4.Enabled = False
                RadioButton3.Checked = True
                Button4.Enabled = True
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then

                    Button4.Enabled = True

                Else


                    Button4.Enabled = False

                End If
            Else
                RadioButton4.Enabled = True
            End If
            If p.estado = "Solo sucursal" Then
                RadioButton3.Enabled = False
                Button4.Enabled = True
                RadioButton4.Checked = True
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then


                    Button4.Enabled = True

                Else


                    Button4.Enabled = False

                End If
            Else
                RadioButton3.Enabled = True
            End If
            If p.estado = "Envio" Then
                RadioButton3.Enabled = False
                Button4.Enabled = False
                RadioButton4.Enabled = False
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then

                    Button4.Enabled = False

                Else

                    Button4.Enabled = False

                End If
            End If
            If p.estado = "Sucursal" Then
                RadioButton3.Enabled = False
                Button4.Enabled = False
                RadioButton4.Enabled = False
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then


                    Button4.Enabled = False

                Else


                    Button4.Enabled = False

                End If
            End If
            If p.estado = "Envio atendido" Then
                RadioButton1.Enabled = False
                Button3.Enabled = False
                RadioButton2.Enabled = False
                RadioButton4.Enabled = False
                RadioButton3.Enabled = False
                Button4.Enabled = False
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then


                    Button3.Enabled = False
                    Button4.Enabled = False

                Else


                    Button3.Enabled = False
                    Button4.Enabled = False

                End If
            End If
            If p.estado = "Atender" Then
                RadioButton1.Enabled = False
                Button3.Enabled = False
                RadioButton2.Enabled = False
                RadioButton4.Enabled = False
                RadioButton3.Enabled = False
                Button4.Enabled = False
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then


                    Button3.Enabled = False
                    Button4.Enabled = False

                Else


                    Button3.Enabled = False
                    Button4.Enabled = False

                End If
            End If
            If p.estado = "En proceso" Then
                RadioButton4.Enabled = True
                RadioButton3.Enabled = True
                Button4.Enabled = True
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then



                    Button4.Enabled = True

                Else



                    Button4.Enabled = False

                End If
            End If
            If p.estado = "Cancelado" Then
                RadioButton4.Enabled = True
                RadioButton3.Enabled = True
                Button4.Enabled = True
                verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Venta Pago")
                If verificador = True Then


                    Button3.Enabled = False
                    Button4.Enabled = False

                Else


                    Button3.Enabled = False
                    Button4.Enabled = False

                End If
            End If

        End If


    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged

        Try
            Dim l As DataGridViewSelectedRowCollection = Me.DataGridView2.SelectedRows

            If l.Count = 1 Then
                Dim a = l(0)
                Dim p As EE.Carritomuestra = a.DataBoundItem
                Dim prod As New List(Of EE.Producto)
                prod.Add(p.producto)
                ComboBox4.DataSource = prod
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If sucursalelegida.codigo = ComboBox2.SelectedItem.codigo Then

            Else

                ComboBox2.SelectedItem = sucursalelegida

            End If

            If DataGridView2.Rows.Count = 0 Then
                MessageBox.Show(mensaje5)

            Else

                Dim lstdetalleventa As New List(Of EE.Detalleventa)
                verificador2 = 0
                verificador1 = 0
                Dim integridad1 As Integer = 0
                Dim integridad2 As Integer = 0
                Dim venta As New EE.Venta

                Dim stockfaltadepo As New List(Of EE.Producto)
                Dim stockfaltasucu As New List(Of EE.Producto)

                venta.comprador = ComboBox1.SelectedItem
                venta.empleado = Combobox3.SelectedItem
                venta.sucursal = ComboBox2.SelectedItem
                venta.estado = "En proceso"
                venta.pagado = "No"
                venta.fecha = DateTime.Now
                Dim datos As New List(Of EE.Producto)

                For Each cmuestra In carrito

                    ' bllventa.verificardisponibilidad(cmuestra, datos)


                    'If integridad1 >= 1 And integridad2 >= 1 Then

                    '    Exit Sub
                    'End If


                    bllventa.Calcularcobro(venta, descuento, descuento2, cmuestra, bllcomprador.Listarcompradoractivos("socio"), bllcomprador.Listarcompradoractivos("cliente"))


                Next

                bllventa.Crear(venta)
                MessageBox.Show(mensaje12)
                Dim lstventa As New List(Of EE.Venta)
                lstventa = bllventa.Listargrande


                Dim detalleventa As New EE.Detalleventa
                For Each n In lstventa
                    detalleventa.venta = n
                    venta = n
                Next

                Dim carritodetalle As New List(Of Carritomuestra)
                carritodetalle = carrito

                For Each cmuestra In carrito

                    detalleventa.producto = cmuestra.producto

                    For Each nn In lstdetodoslosproductos

                        If nn.codigo = detalleventa.producto.codigo Then
                            detalleventa.precio = cmuestra.monto
                            detalleventa.cantidad = cmuestra.stockrequerido
                        End If
                    Next

                    establecerestadoventa(detalleventa, cmuestra, venta)



                Next

                For Each cmuestra In carritodetalle

                    detalleventa.producto = cmuestra.producto

                    For Each nn In lstdetodoslosproductos

                        If nn.codigo = detalleventa.producto.codigo Then
                            detalleventa.precio = cmuestra.monto
                            detalleventa.cantidad = cmuestra.stockrequerido
                        End If
                    Next

                    If verificador1 = 0 And verificador2 <> 0 Then

                        blldetalleventa.Generardetalle(detalleventa)
                        bllbitacora.generarbitacora("Generar venta", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)

                    End If
                    If verificador2 = 0 And verificador1 <> 0 Then

                        blldetalleventa.Generardetalle(detalleventa)
                        bllbitacora.generarbitacora("Generar venta", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)

                    End If
                    If verificador2 = 0 And verificador1 = 0 Then

                        blldetalleventa.Generardetalle(detalleventa)
                        bllbitacora.generarbitacora("Generar venta", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)

                    End If
                Next


                limpiar()
                actualizar3()
                carrito = New List(Of EE.Carritomuestra)

            End If


        Catch ex As Exception
            MessageBox.Show(mensaje11)

            bllbitacora.generarbitacora("Error generar venta", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub


    Public Sub establecerestadoventa(detalleventa As EE.Detalleventa, n As EE.Carritomuestra, venta As EE.Venta)


        Dim verif As Integer = 0
        For Each nn In lststockdeposito
            If n.producto.codigo = nn.producto.codigo Then
                verif = 1
                If (nn.cantidad - detalleventa.cantidad) < 0 Then

                    MessageBox.Show(mensaje1 & " " & detalleventa.producto.nombre)
                    verificador1 = 1
                    RadioButton3.Enabled = False
                    venta.estado = "Solo sucursal"
                    bllventa.Modificar(venta)

                End If
            End If

        Next

        If verif = 0 Then
            MessageBox.Show(mensaje1 & " " & detalleventa.producto.nombre)
            verificador1 = 1
            RadioButton3.Enabled = False
            venta.estado = "Solo sucursal"
            bllventa.Modificar(venta)
        End If

        Dim verif2 As Integer = 0
        For Each nn In lststocksucursal
            If nn.sucursal.codigo = venta.sucursal.codigo Then
                If n.producto.codigo = nn.producto.codigo Then
                    verif2 = 1
                    If (nn.cantidad - detalleventa.cantidad) < 0 Then
                        MessageBox.Show(mensaje2 & detalleventa.producto.nombre)
                        verificador2 = 1
                        RadioButton4.Enabled = False
                        venta.estado = "Solo envio"
                        bllventa.Modificar(venta)
                    End If
                End If
            End If
        Next

        If verif2 = 0 Then
            MessageBox.Show(mensaje2 & detalleventa.producto.nombre)
            verificador2 = 1
            RadioButton4.Enabled = False
            venta.estado = "Solo envio"
            bllventa.Modificar(venta)
        End If

        If verif = 0 And verif2 = 0 Then
            venta.estado = "Cancelado"
            bllventa.Modificar(venta)
            MessageBox.Show(mensaje21)
        End If

        If verificador2 = 1 And verificador1 = 1 Then
            venta.estado = "Cancelado"
            bllventa.Modificar(venta)
            limpiar()
            actualizar3()
            MessageBox.Show(mensaje21)
            Exit Sub

        End If
    End Sub

    Public Sub actualizar3()

        Me.DataGridView3.DataSource = Nothing
        If bllventa.Listar Is Nothing Then
            Exit Sub
        Else
            Me.DataGridView3.DataSource = bllventa.Listar
        End If


    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje6)
            Else
                Dim venta As New EE.Venta
                venta.comprador = ComboBox1.SelectedItem
                venta.empleado = Combobox3.SelectedItem
                venta.sucursal = ComboBox2.SelectedItem
                venta.estado = txtestado.Text
                venta.codigo = txtcodigo.Text
                venta.fecha = txtfecha.Text
                venta.monto = txtmonto.Text

                If txtestado.Text = "En proceso" And txtpagado.Text = "No" Then
                    Confirmarpago(venta)
                Else

                End If
                If txtestado.Text = "Solo sucursal" And txtpagado.Text = "No" Then
                    Confirmarpago(venta)
                Else

                End If

                If txtestado.Text = "Solo envio" And txtpagado.Text = "No" Then
                    Confirmarpago(venta)
                Else

                End If

                If txtestado.Text = "Cancelado" Then

                End If


                If txtpagado.Text = "Si" Then
                    MessageBox.Show(mensaje15)
                End If



            End If
            limpiar()
            actualizar3()

        Catch ex As Exception
            MessageBox.Show(mensaje11)
            bllbitacora.generarbitacora("Error cobrar venta", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub Confirmarpago(venta As EE.Venta)

        If RadioButton1.Checked = True Then
            venta.pagado = "Efectivo"
            bllventa.Modificar(venta)
            MessageBox.Show(mensaje13)
            bllbitacora.generarbitacora("Cobrar venta", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)
        End If
        If RadioButton2.Checked = True Then
            venta.pagado = "Tarjeta"
            bllventa.Modificar(venta)
            MessageBox.Show(mensaje13)
            bllbitacora.generarbitacora("Cobrar venta", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)
        End If
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MessageBox.Show(mensaje14)
        End If

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        limpiar()
    End Sub

    Public Sub limpiar()
        TextBox1.Text = ""
        listaproducto.Clear()
        txtcantidad.Text = ""
        txtcodigo.Text = ""
        txtestado.Text = ""
        txtfecha.Text = ""
        txtmonto.Text = ""
        txtpagado.Text = ""
        txtprod.Text = ""
        txtprod2.Text = ""
        txtprod3.Text = ""
        txtprod4.Text = ""
        txtprod5.Text = ""
        Me.DataGridView1.DataSource = Nothing
        carrito = New List(Of EE.Carritomuestra)
        Me.DataGridView2.DataSource = carrito
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        ComboBox4.DataSource = Nothing
        actualizar()
        actualizar2()
        actualizar3()
        Button3.Enabled = False
        Button4.Enabled = False
        Combobox3.DataSource = bllempleadosucursal.Listarempleadoporsucursal(ComboBox2.SelectedItem)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje6)
            Else
                Dim pasador As Integer = 0

                pasador = bllventa.verificarpago(txtestado.Text, txtpagado.Text, pasador)


                If pasador = 1 Then
                    Dim venta As New EE.Venta
                    venta.comprador = ComboBox1.SelectedItem
                    venta.empleado = Combobox3.SelectedItem
                    venta.sucursal = ComboBox2.SelectedItem
                    venta.codigo = txtcodigo.Text
                    venta.fecha = txtfecha.Text
                    venta.monto = txtmonto.Text
                    venta.pagado = txtpagado.Text

                    Dim lstdetalleventa As New List(Of EE.Detalleventa)
                    lstdetalleventa = blldetalleventa.Listardetalle(venta)

                    If RadioButton3.Checked = True Then
                        venta.estado = "Envio"

                        For Each detalle In lstdetalleventa


                            For Each stkdepo In lststockdeposito
                                If detalle.producto.codigo = stkdepo.producto.codigo Then
                                    bllstockdeposito.reducirstock(stkdepo, detalle.cantidad)
                                End If
                            Next

                        Next
                        bllventa.Modificar(venta)
                        MessageBox.Show(mensaje16)
                        bllbitacora.generarbitacora("Asignar entrega", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)
                    End If
                    If RadioButton4.Checked = True Then
                        venta.estado = "Sucursal"

                        For Each n In lstdetalleventa

                            For Each nn In lststocksucursal
                                If nn.sucursal.codigo = venta.sucursal.codigo Then
                                    If n.producto.codigo = nn.producto.codigo Then
                                        bllstocksucursal.reducirstock(nn, n.cantidad)
                                    End If
                                End If
                            Next

                        Next

                        bllventa.Modificar(venta)
                        MessageBox.Show(mensaje16)
                        bllbitacora.generarbitacora("Asignar entrega", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)
                    End If
                    If RadioButton3.Checked = False And RadioButton4.Checked = False Then
                        MessageBox.Show(mensaje3)
                    End If
                Else
                    MessageBox.Show(mensaje17)
                End If


            End If
            actualizar3()
            limpiar()
         
        Catch ex As Exception
            MessageBox.Show(mensaje11)
            bllbitacora.generarbitacora("Error asignar entrega", "Tabla Venta", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick

    End Sub

    Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseClick

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_Click(sender As Object, e As EventArgs) Handles DataGridView2.Click

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            If txtprod.Text = "" Then
                MessageBox.Show(mensaje10)
            Else
                For Each n In carrito
                    If n.producto Is ComboBox4.SelectedItem Then
                        carrito.Remove(n)
                        actualizar2()
                        ComboBox4.DataSource = Nothing
                    End If
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(559, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 559)

        bllpalabra.verificacionpalabras(558, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 558)


        bllpalabra.verificacionpalabras(307, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 307)

        bllpalabra.verificacionpalabras(308, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 308)

        bllpalabra.verificacionpalabras(309, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 309)

        bllpalabra.verificacionpalabras(310, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 310)

        bllpalabra.verificacionpalabras(311, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 311)

        bllpalabra.verificacionpalabras(312, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 312)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
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

        bllpalabra.verificacionpalabras(500, mensaje18)
        mensaje18 = blltraduccion.Traduccion(idioma, 500)

        bllpalabra.verificacionpalabras(501, mensaje19)
        mensaje19 = blltraduccion.Traduccion(idioma, 501)

        bllpalabra.verificacionpalabras(502, mensaje20)
        mensaje20 = blltraduccion.Traduccion(idioma, 502)

        bllpalabra.verificacionpalabras(503, mensaje21)
        mensaje21 = blltraduccion.Traduccion(idioma, 503)


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)

        bllpalabra.verificacionpalabras(GroupBox3.Tag, GroupBox3.Text)
        GroupBox3.Text = blltraduccion.Traduccion(idioma, GroupBox3.Tag)
        bllpalabra.verificacionpalabras(GroupBox4.Tag, GroupBox4.Text)
        GroupBox4.Text = blltraduccion.Traduccion(idioma, GroupBox4.Tag)



        bllpalabra.verificacionpalabras(GroupBox5.Tag, GroupBox5.Text)
        GroupBox5.Text = blltraduccion.Traduccion(idioma, GroupBox5.Tag)

        bllpalabra.verificacionpalabras(GroupBox6.Tag, GroupBox6.Text)
        GroupBox6.Text = blltraduccion.Traduccion(idioma, GroupBox6.Tag)

        bllpalabra.verificacionpalabras(RadioButton1.Tag, RadioButton1.Text)
        RadioButton1.Text = blltraduccion.Traduccion(idioma, RadioButton1.Tag)

        bllpalabra.verificacionpalabras(RadioButton2.Tag, RadioButton2.Text)
        RadioButton2.Text = blltraduccion.Traduccion(idioma, RadioButton2.Tag)

        bllpalabra.verificacionpalabras(RadioButton3.Tag, RadioButton3.Text)
        RadioButton3.Text = blltraduccion.Traduccion(idioma, RadioButton3.Tag)

        bllpalabra.verificacionpalabras(RadioButton4.Tag, RadioButton4.Text)
        RadioButton4.Text = blltraduccion.Traduccion(idioma, RadioButton4.Tag)

        bllpalabra.verificacionpalabras(441, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 441)

        bllpalabra.verificacionpalabras(Label4.Tag, Label4.Text)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)


        bllpalabra.verificacionpalabras(440, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 440)


        bllpalabra.verificacionpalabras(439, mensaje11)
        mensaje11 = blltraduccion.Traduccion(idioma, 439)

        bllpalabra.verificacionpalabras(433, mensaje12)
        mensaje12 = blltraduccion.Traduccion(idioma, 433)

        bllpalabra.verificacionpalabras(434, mensaje13)
        mensaje13 = blltraduccion.Traduccion(idioma, 434)


        bllpalabra.verificacionpalabras(435, mensaje14)
        mensaje14 = blltraduccion.Traduccion(idioma, 435)


        bllpalabra.verificacionpalabras(436, mensaje15)
        mensaje15 = blltraduccion.Traduccion(idioma, 436)


        bllpalabra.verificacionpalabras(437, mensaje16)
        mensaje16 = blltraduccion.Traduccion(idioma, 437)

        bllpalabra.verificacionpalabras(438, mensaje17)
        mensaje17 = blltraduccion.Traduccion(idioma, 438)

        bllpalabra.verificacionpalabras(313, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 313)

        bllpalabra.verificacionpalabras(314, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 314)
    End Sub


End Class