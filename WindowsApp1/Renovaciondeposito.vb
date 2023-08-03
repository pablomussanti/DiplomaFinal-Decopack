Imports EE
Imports Servicios
Imports BLL
Public Class Renovaciondeposito
    Implements Iidiomaobserver

    Dim valorp2 As Integer = 0
    Dim bllstockdeposito As New BLLstockdeposito
    Dim bllproveedor As New BLLproveedor
    Dim bllproducto As New BLLproducto
    Dim blldeposito As New BLLdeposito
    Dim bllrenovacion As New BLLrenovaciondeposito
    Dim bllproveedorproducto As New BLLproveedorproducto
    Dim listaproveedorproducto As New List(Of proveedorproducto)
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim bllbitacora As New BLLbitacora
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim valorp As Integer = 0
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim mensaje9 As String
    Dim mensaje10 As String
    Dim mensaje11 As String
    Dim mensaje12 As String
    Private Sub Renovaciondeposito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizar()
        actualizar1()
        txtestado.Enabled = False
        txtmonto.Enabled = False
        txtcodigo.Enabled = False
        TextBox2.Enabled = False
        Button4.Enabled = False

        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Renovacion")
        If verificador = True Then
            Button1.Enabled = True
            valorp2 = 1
            Button3.Enabled = False


            Button5.Enabled = True
            Button6.Enabled = True

        Else
            Button1.Enabled = False

            Button3.Enabled = False

            Button5.Enabled = False
            Button6.Enabled = False

        End If

        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Renovacion Confirmar")
        If verificador = True Then

            Button4.Enabled = False
            valorp = 1

        Else

            Button4.Enabled = False

        End If
        Singletonidioma._instancia.Agregar(Me)

        mensaje1 = "Limpie los campos"

        mensaje2 = "No se puede eliminar un pedido que ya fue entregado"

        mensaje3 = "No se puede confirmar algo que ya fue confirmado"

        mensaje4 = "Seleccione una renovacion"


        mensaje5 = "Alta renovacion exitosa"

        mensaje6 = "Monto incompatible"

        mensaje7 = "Cantidad incompatible"


        mensaje8 = "Formato ingresado no valido"


        mensaje9 = "Baja renovacion exitosa"


        mensaje10 = "Renovacion confirmada"

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(289, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 289)

        bllpalabra.verificacionpalabras(290, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 290)

        bllpalabra.verificacionpalabras(291, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 291)

        bllpalabra.verificacionpalabras(292, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 292)

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


        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)
        bllpalabra.verificacionpalabras(Button5.Tag, Button5.Text)
        Button5.Text = blltraduccion.Traduccion(idioma, Button5.Tag)



        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)





        bllpalabra.verificacionpalabras(407, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 407)


        bllpalabra.verificacionpalabras(408, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 408)


        bllpalabra.verificacionpalabras(409, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 409)

        bllpalabra.verificacionpalabras(410, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 410)

        bllpalabra.verificacionpalabras(411, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 411)

        bllpalabra.verificacionpalabras(412, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 412)

    End Sub

    Public Sub actualizar()

        Me.DataGridView1.DataSource = Nothing
        If bllrenovacion.Listarrenovaciondeposito Is Nothing Then
            Exit Sub
        Else
            Me.DataGridView1.DataSource = bllrenovacion.Listarrenovaciondeposito
        End If


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Me.DataGridView2.DataSource = Nothing
        If bllproveedorproducto.Traerdetalleporproducto(cmbproducto.SelectedItem) Is Nothing Then
            Exit Sub
        Else
            Me.DataGridView2.DataSource = bllproveedorproducto.Traerdetalleporproducto(cmbproducto.SelectedItem)
        End If

    End Sub


    Public Sub actualizar1()
        Me.cmbdeposito.DataSource = Nothing
        Me.cmbdeposito.DataSource = blldeposito.Listardeposito
        Me.cmbdeposito.DisplayMember = "Detalle"


        Me.cmbproducto.DataSource = Nothing
        Me.cmbproducto.DataSource = bllproducto.Listarproducto
        Me.cmbproducto.DisplayMember = "Nombre"

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        actualizar1()
        TextBox2.Text = ""
        txtcantidad.Text = ""
        txtcodigo.Text = ""
        txtestado.Text = ""
        txtmonto.Text = ""
        Button3.Enabled = False
        Button4.Enabled = False
        Button6.Enabled = True
        cmbproveedor.DataSource = Nothing
        DataGridView2.DataSource = Nothing
        txtcantidad.Enabled = True
        cmbdeposito.Enabled = True
        cmbproducto.Enabled = True
        cmbproveedor.Enabled = True
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If txtcodigo.Text = "" Then
                If txtcantidad.Text IsNot "" Then
                    If txtcantidad.Text > 0 Then

                        Dim renovacion As New EE.Renovaciondeposito
                        renovacion.cantidad = txtcantidad.Text
                        renovacion.deposito = cmbdeposito.SelectedItem
                        renovacion.producto = cmbproducto.SelectedItem
                        renovacion.proveedor = cmbproveedor.SelectedItem

                        For Each n In bllproveedorproducto.Listardetalle
                            If n.producto.codigo = renovacion.producto.codigo Then
                                If n.proveedor.codigo = renovacion.proveedor.codigo Then
                                    renovacion.monto = renovacion.cantidad * n.precio
                                End If
                            End If
                        Next
                        renovacion.estado = "En proceso"
                        renovacion.fecha = DateTime.Now
                        bllrenovacion.Crearrenovaciondeposito(renovacion)
                        MessageBox.Show(mensaje5)
                        bllbitacora.generarbitacora("Generar renovacion deposito", "Tabla Renovaciondeposito", Servicios.SesionManager.obtenerinstancia)
                        actualizar()


                    Else
                        MessageBox.Show(mensaje7)
                    End If
                Else
                    MessageBox.Show(mensaje7)
                End If


            Else
                MessageBox.Show(mensaje1)

            End If
            actualizar1()
            TextBox2.Text = ""
            txtcantidad.Text = ""
            txtcodigo.Text = ""
            txtestado.Text = ""
            txtmonto.Text = ""
            Button3.Enabled = False
            Button4.Enabled = False
            cmbproveedor.DataSource = Nothing
            DataGridView2.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error generar renovacion deposito", "Tabla Renovaciondeposito", Servicios.SesionManager.obtenerinstancia)
        End Try



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje4)
            Else
                If txtestado.Text = "En proceso" Then
                    Dim renovacion As New EE.Renovaciondeposito
                    renovacion.cantidad = txtcantidad.Text
                    renovacion.codigo = txtcodigo.Text
                    renovacion.deposito = cmbdeposito.SelectedItem
                    renovacion.producto = cmbproducto.SelectedItem
                    renovacion.proveedor = cmbproveedor.SelectedItem
                    renovacion.monto = txtmonto.Text
                    renovacion.estado = txtestado.Text
                    renovacion.fecha = TextBox2.Text
                    bllrenovacion.Eliminarrenovaciondeposito(renovacion)
                    MessageBox.Show(mensaje9)
                    bllbitacora.generarbitacora("Baja renovacion deposito", "Tabla Renovaciondeposito", Servicios.SesionManager.obtenerinstancia)
                    actualizar()

                Else
                    MessageBox.Show(mensaje2)
                End If

            End If
            txtcantidad.Enabled = True
            txtcodigo.Enabled = True
            txtestado.Enabled = True
            txtmonto.Enabled = True
            TextBox2.Enabled = True
            cmbdeposito.Enabled = True
            cmbproducto.Enabled = True
            cmbproveedor.Enabled = True
            actualizar1()
            TextBox2.Text = ""
            txtcantidad.Text = ""
            txtcodigo.Text = ""
            txtestado.Text = ""
            txtmonto.Text = ""
            Button3.Enabled = False
            Button4.Enabled = False
            cmbproveedor.DataSource = Nothing
            DataGridView2.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error baja renovacion deposito", "Tabla Renovaciondeposito", Servicios.SesionManager.obtenerinstancia)
        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje4)
            Else
                If txtestado.Text = "En proceso" Then
                    Dim renovacion As New EE.Renovaciondeposito
                    renovacion.codigo = txtcodigo.Text
                    renovacion.cantidad = txtcantidad.Text
                    renovacion.deposito = cmbdeposito.SelectedItem
                    renovacion.producto = cmbproducto.SelectedItem
                    renovacion.proveedor = cmbproveedor.SelectedItem
                    renovacion.monto = txtmonto.Text
                    renovacion.estado = "Confirmado"
                    renovacion.fecha = TextBox2.Text
                    For Each n In bllstockdeposito.Listarstock
                        If n.deposito.codigo = renovacion.deposito.codigo Then
                            If n.producto.codigo = renovacion.producto.codigo Then
                                bllstockdeposito.aumentarstock(n, renovacion.cantidad)
                            End If
                        End If
                    Next
                    bllrenovacion.Modificarrenovaciondeposito(renovacion)
                    MessageBox.Show(mensaje10)
                    bllbitacora.generarbitacora("Confirmar renovacion deposito", "Tabla Renovaciondeposito", Servicios.SesionManager.obtenerinstancia)
                    actualizar()

                Else
                    MessageBox.Show(mensaje3)
                End If

            End If
            txtcantidad.Enabled = True
            txtcodigo.Enabled = True
            txtestado.Enabled = True
            txtmonto.Enabled = True
            TextBox2.Enabled = True
            cmbdeposito.Enabled = True
            cmbproducto.Enabled = True
            cmbproveedor.Enabled = True
            actualizar1()
            TextBox2.Text = ""
            txtcantidad.Text = ""
            txtcodigo.Text = ""
            txtestado.Text = ""
            txtmonto.Text = ""
            Button3.Enabled = False
            Button4.Enabled = False
            cmbproveedor.DataSource = Nothing
            DataGridView2.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show(mensaje8)
            bllbitacora.generarbitacora("Error confirmar renovacion deposito", "Tabla Renovaciondeposito", Servicios.SesionManager.obtenerinstancia)
        End Try


    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView2.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.proveedorproducto = a.DataBoundItem
            Dim listproveedor As New List(Of EE.Proveedor)
            listproveedor.Add(p.proveedor)
            cmbproveedor.DataSource = listproveedor
        End If


    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Renovaciondeposito = a.DataBoundItem
            Dim listproveedor As New List(Of EE.Proveedor)
            listproveedor.Add(p.proveedor)
            cmbproveedor.DataSource = listproveedor
            Dim listproducto As New List(Of EE.Producto)
            listproducto.Add(p.producto)
            cmbproducto.DataSource = listproducto
            Dim listdeposito As New List(Of EE.Deposito)
            listdeposito.Add(p.deposito)
            cmbdeposito.DataSource = listdeposito
            txtcantidad.Text = p.cantidad
            txtcodigo.Text = p.codigo
            txtestado.Text = p.estado
            txtmonto.Text = p.monto
            TextBox2.Text = p.fecha

            If p.estado = "En proceso" And valorp = 1 Then
                Button4.Enabled = True
            Else
                Button4.Enabled = False
            End If

            If valorp2 = 1 And p.estado = "En proceso" Then
                Button3.Enabled = True

            End If

            Button6.Enabled = False
            txtcantidad.Enabled = False
            txtcodigo.Enabled = False
            txtestado.Enabled = False
            txtmonto.Enabled = False
            TextBox2.Enabled = False
            cmbdeposito.Enabled = False
            cmbproducto.Enabled = False
            cmbproveedor.Enabled = False
        End If


    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(289, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 289)

        bllpalabra.verificacionpalabras(290, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 290)

        bllpalabra.verificacionpalabras(291, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 291)

        bllpalabra.verificacionpalabras(292, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 292)

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


        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)
        bllpalabra.verificacionpalabras(Button5.Tag, Button5.Text)
        Button5.Text = blltraduccion.Traduccion(idioma, Button5.Tag)



        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)





        bllpalabra.verificacionpalabras(407, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 407)


        bllpalabra.verificacionpalabras(408, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 408)


        bllpalabra.verificacionpalabras(409, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 409)

        bllpalabra.verificacionpalabras(410, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 410)

        bllpalabra.verificacionpalabras(411, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 411)

        bllpalabra.verificacionpalabras(412, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 412)
    End Sub

End Class