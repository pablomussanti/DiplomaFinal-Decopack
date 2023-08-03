Imports EE
Imports BLL
Imports Servicios
Public Class Devolucion
    Implements Iidiomaobserver

    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim listaenvio As New List(Of EE.Envio)
    Dim bllenvio As New BLLenvio
    Dim bllempleadodeposito As New BLLempleadodeposito
    Dim bllventa As New BLLventa
    Dim listaproducto As New List(Of EE.Producto)
    Dim blldetalleventa As New BLLdetalleventa
    Dim bllproducto As New BLLproducto
    Dim lstdetalle As New List(Of EE.Detalleventa)
    Dim devolucion As New EE.Devolucion
    Dim bllstockdeposito As New BLLstockdeposito
    Dim blldevolucion As New BLLdevolucion
    'Dim listadevolucion As New List(Of EE.Devolucion)
    Dim bllbitacora As New BLLbitacora
    Dim mensaje1 As String
    Dim mensaje2 As String

    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Private Sub Devolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        Singletonidioma._instancia.Agregar(Me)
        mensaje3 = "Devolucion generada"


        mensaje4 = "Cantidad incompatible"


        mensaje5 = "Dato ingresado no corresponde al formato del campo"


        actualizardata()
        txtcodigo.Enabled = False
        txtdireccion.Enabled = False
        txtestado.Enabled = False
        txtfechallegada.Enabled = False
        txtfechasalida.Enabled = False
        cmbventa.Enabled = False
        cmbempleado.Enabled = False
        actualizardata2()
        mensaje1 = "Hay mas reclamo de lo comprado"
        mensaje2 = "Seleccione un envio"
        RadioButton1.Checked = True
        RadioButton1.Enabled = False

        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Devolucion")
        If verificador = True Then
            Button1.Enabled = True

        Else
            Button1.Enabled = False

        End If

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(349, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 349)
        bllpalabra.verificacionpalabras(350, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 350)
        bllpalabra.verificacionpalabras(351, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 351)
        bllpalabra.verificacionpalabras(95, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 95)
        bllpalabra.verificacionpalabras(284, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 284)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)

        bllpalabra.verificacionpalabras(RadioButton1.Tag, RadioButton1.Text)
        RadioButton1.Text = blltraduccion.Traduccion(idioma, RadioButton1.Tag)
        bllpalabra.verificacionpalabras(RadioButton1.Tag, RadioButton1.Text)
        RadioButton1.Text = blltraduccion.Traduccion(idioma, RadioButton1.Tag)


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)

    End Sub

    Public Sub actualizardata2()
        Me.DataGridView2.DataSource = Nothing
        Me.DataGridView2.DataSource = blldevolucion.Listardevolucion
    End Sub

    Public Sub actualizardata()
        listaenvio.Clear()
        Me.DataGridView1.DataSource = Nothing
        If bllenvio.Listarenvio Is Nothing Then
            Exit Sub
        End If
        For Each n In bllenvio.Listarenvio

            If n.empleado Is Nothing Then
                Dim emp As New EE.Empleadodeposito
                n.empleado = emp
                n.empleado.nombre = "Asignar"
            End If
            If n.estado = "Atender" Then
                listaenvio.Add(n)
            End If
        Next
        Me.DataGridView1.DataSource = listaenvio
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows
        listaproducto.Clear()


        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Envio = a.DataBoundItem
            txtcodigo.Text = p.codigo
            txtdireccion.Text = p.direccion
            txtestado.Text = p.estado
            txtfechallegada.Text = p.fechadellegada
            txtfechasalida.Text = p.fechadesalida
            Dim lstventa As New List(Of EE.Venta)
            lstventa.Add(p.venta)
            cmbventa.DataSource = lstventa


            Dim lstempleado As New List(Of EE.Empleado)
            lstempleado.Add(p.empleado)
            cmbempleado.DataSource = lstempleado

            devolucion.envio = p
            For Each detalleventa In blldetalleventa.Listardetalle(p.venta)

                listaproducto.Add(detalleventa.producto)
                lstdetalle.Add(detalleventa)
            Next

            If p.estado = "Atender" And p.empleado.nombre <> "Asignar" Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
            Me.ComboBox1.DataSource = Nothing
            Me.ComboBox1.DataSource = listaproducto
            Me.ComboBox1.DisplayMember = "Nombre"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim verifi As Integer = 0
            If ComboBox1.Items.Count = 0 Then
                MessageBox.Show(mensaje2)

            Else
                If TextBox1.Text > 0 Then
                    Dim envio As New EE.Envio
                    Dim devolucions As New EE.Devolucion
                    Dim verificador As Integer = 0
                    devolucions.envio = devolucion.envio
                    devolucions.envio.estado = "Advertencia devolucion"
                    bllenvio.Modificarenvio(devolucions.envio)
                    devolucion.producto = ComboBox1.SelectedItem
                    devolucion.cantidad = TextBox1.Text
                    devolucion.estado = "Generado"
                    For Each n In lstdetalle
                        If n.producto.codigo = devolucion.producto.codigo Then
                            If devolucion.envio.venta.codigo = n.venta.codigo Then
                                If (n.cantidad - devolucion.cantidad) >= 0 Then
                                    ' Dim envio As New Envio
                                    envio.direccion = devolucion.envio.direccion
                                    Dim emp As New EE.Empleadodeposito
                                    emp.codigo = 0
                                    emp.nombre = "Asignar"
                                    envio.empleado = emp
                                    envio.venta = devolucion.envio.venta
                                    envio.fechadesalida = DateTime.Now
                                    envio.estado = "Devolucion"
                                    envio.fechadellegada = DateTime.Now
                                    If blldevolucion.Listardevolucion Is Nothing Then
                                    Else
                                        For Each devo In blldevolucion.Listardevolucion
                                            If devo.envio.codigo = envio.codigo Then
                                                verificador = 1
                                            Else
                                                verificador = 0
                                            End If
                                        Next
                                    End If
                                    If RadioButton1.Checked = True Then
                                        For Each nn In bllstockdeposito.Listarstock
                                            If devolucion.producto.codigo = nn.producto.codigo Then
                                                bllstockdeposito.reducirstock(nn, devolucion.cantidad)
                                            End If
                                        Next
                                    End If
                                    verifi = 1
                                Else
                                    MessageBox.Show(mensaje1)
                                    Exit Sub
                                End If
                            End If
                        End If

                    Next
                    If verificador = 0 Then
                        bllenvio.generarenvio(Envio)
                    End If
                    If verifi = 1 Then
                        blldevolucion.Generardevolucion(devolucion)
                        MessageBox.Show(mensaje3)
                        bllbitacora.generarbitacora("Generar devolucion", "Tabla Devolucion", Servicios.SesionManager.obtenerinstancia)
                    End If
                    limpiar()
                    actualizardata2()
                    actualizardata()
                    ComboBox1.DataSource = Nothing
                    TextBox1.Text = ""
                Else
                    MessageBox.Show(mensaje4)
                End If



            End If


        Catch ex As Exception
            MessageBox.Show(mensaje5)
            bllbitacora.generarbitacora("Error generar devolucion", "Tabla Devolucion", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub limpiar()
        txtcodigo.Text = ""
        txtdireccion.Text = ""
        txtestado.Text = ""
        txtfechallegada.Text = ""
        txtfechasalida.Text = ""
        cmbempleado.DataSource = Nothing
        cmbventa.DataSource = Nothing
    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(349, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 349)
        bllpalabra.verificacionpalabras(350, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 350)
        bllpalabra.verificacionpalabras(351, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 351)
        bllpalabra.verificacionpalabras(95, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 95)
        bllpalabra.verificacionpalabras(284, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 284)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)

        bllpalabra.verificacionpalabras(RadioButton1.Tag, RadioButton1.Text)
        RadioButton1.Text = blltraduccion.Traduccion(idioma, RadioButton1.Tag)
        bllpalabra.verificacionpalabras(RadioButton1.Tag, RadioButton1.Text)
        RadioButton1.Text = blltraduccion.Traduccion(idioma, RadioButton1.Tag)


        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)

    End Sub
End Class