Imports EE
Imports BLL
Imports Servicios
Public Class Reposicion
    Implements Iidiomaobserver

    Dim bllproducto As New BLLproducto
    Dim bllreposicion As New BLLreposicion
    Dim blldeposito As New BLLdeposito
    Dim bllsucursal As New BLLsucursal
    Dim bllstockdeposito As New BLLstockdeposito
    Dim bllstocksucursal As New BLLstocksucursal
    Dim bllbitacora As New BLLbitacora
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim valorp2 As Integer = 0
    Dim valorp As Integer = 0
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim mensaje9 As String
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.cmbproducto.DataSource = Nothing
        Dim sucursal As New EE.Sucursal
        sucursal = cmbsucursal.SelectedItem
        cmbproducto.DataSource = bllproducto.Listarproductoporsucursal(sucursal)
    End Sub

    Private Sub Reposicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcodigo.Enabled = False
        TextBox1.Enabled = False
        txtestado.Enabled = False
        actualizar()
        actualizar1()

        mensaje1 = "No se llega a cubrir el stock pedido"
        Button5.Enabled = False
        Button2.Enabled = False

        Singletonidioma._instancia.Agregar(Me)
        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Reposicion")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = True
            valorp2 = 1
            Button5.Enabled = True
            Button6.Enabled = True

        Else
            Button1.Enabled = False
            Button2.Enabled = False

            Button5.Enabled = False
            Button6.Enabled = False

        End If

        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Reposicion Confirmar")
        If verificador = True Then

            Button4.Enabled = True
            valorp = 1

        Else

            Button4.Enabled = False

        End If


        mensaje2 = "Limpie los campos"

        mensaje3 = "Seleccione una reposicion"



        mensaje4 = "Alta reposicion exitosa"


        mensaje5 = "Formato de cantidad invalido"


        mensaje6 = "Formato ingresado no valido"


        mensaje7 = "Eliminacion de reposicion exitosa"

        mensaje8 = "No se puede eliminar un pedido ya entregado"


        mensaje9 = "Reposicion confirmada"

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(293, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 293)

        bllpalabra.verificacionpalabras(294, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 294)

        bllpalabra.verificacionpalabras(295, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 295)

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


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)


        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)
        bllpalabra.verificacionpalabras(Button5.Tag, Button5.Text)
        Button5.Text = blltraduccion.Traduccion(idioma, Button5.Tag)



        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)


        bllpalabra.verificacionpalabras(413, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 413)

        bllpalabra.verificacionpalabras(414, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 414)


        bllpalabra.verificacionpalabras(415, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 415)


        bllpalabra.verificacionpalabras(416, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 416)

        bllpalabra.verificacionpalabras(417, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 417)

        bllpalabra.verificacionpalabras(418, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 418)

    End Sub

    Public Sub actualizar1()
        Me.cmbdeposito.DataSource = Nothing
        Me.cmbdeposito.DataSource = blldeposito.Listardeposito
        Me.cmbdeposito.DisplayMember = "Detalle"
        Me.cmbsucursal.DataSource = Nothing
        Me.cmbsucursal.DataSource = bllsucursal.Listarsucursal
        Me.cmbsucursal.DisplayMember = "Detalle"
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Reposicion = a.DataBoundItem
            Dim listadepo As New List(Of EE.Deposito)
            Dim listasucu As New List(Of EE.Sucursal)
            Dim listprodu As New List(Of EE.Producto)

            txtcantidad.Text = p.cantidad
            txtcodigo.Text = p.codigo
            txtestado.Text = p.estado
            TextBox1.Text = p.fecha
            cmbdeposito.DataSource = Nothing
            listadepo.Add(p.deposito)
            cmbdeposito.DataSource = listadepo
            Me.cmbsucursal.DataSource = Nothing
            listasucu.Add(p.sucursal)
            cmbsucursal.DataSource = listasucu
            Me.cmbproducto.DataSource = Nothing
            listprodu.Add(p.producto)
            cmbproducto.DataSource = listprodu

            If p.estado = "Confirmado" Then
                Button5.Enabled = False

            End If
            If p.estado = "En proceso" And valorp = 1 Then
                Button5.Enabled = True

            End If
            If p.estado = "En proceso" And valorp2 = 1 Then
                Button2.Enabled = True
            Else
                Button2.Enabled = False
            End If




        End If


    End Sub

    Public Sub actualizar()

        Me.DataGridView1.DataSource = Nothing
        If bllreposicion.Listarreposicion Is Nothing Then
            Exit Sub
        Else
            Me.DataGridView1.DataSource = bllreposicion.Listarreposicion

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If txtcodigo.Text = "" Then
                If txtcantidad.Text > 0 Then
                    Dim reposicion As New EE.Reposicion
                    reposicion.estado = "En proceso"
                    reposicion.fecha = DateTime.Now
                    reposicion.deposito = cmbdeposito.SelectedItem
                    reposicion.cantidad = txtcantidad.Text
                    reposicion.producto = cmbproducto.SelectedItem
                    reposicion.sucursal = cmbsucursal.SelectedItem
                    For Each n In bllstockdeposito.Listarstock

                        If n.deposito.codigo = reposicion.deposito.codigo Then
                            If n.producto.codigo = reposicion.producto.codigo Then
                                If (n.cantidad - reposicion.cantidad) >= 0 Then
                                    bllreposicion.Crearreposicion(reposicion)
                                    bllbitacora.generarbitacora("Generar reposicion", "Tabla Reposicion", Servicios.SesionManager.obtenerinstancia)
                                    bllstockdeposito.reducirstock(n, reposicion.cantidad)
                                    MessageBox.Show(mensaje4)
                                Else
                                    MessageBox.Show(mensaje1)
                                End If
                            End If
                        End If
                    Next
                    actualizar()
                Else
                    MessageBox.Show(mensaje5)
                End If


            Else
                MessageBox.Show(mensaje2)
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error generar reposicion", "Tabla Reposicion", Servicios.SesionManager.obtenerinstancia)
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje3)
            Else
                Dim reposicion As New EE.Reposicion
                reposicion.fecha = DateTime.Now
                reposicion.deposito = cmbdeposito.SelectedItem
                reposicion.cantidad = txtcantidad.Text
                reposicion.producto = cmbproducto.SelectedItem
                reposicion.sucursal = cmbsucursal.SelectedItem
                reposicion.codigo = txtcodigo.Text
                If txtestado.Text = "En proceso" Then
                    bllreposicion.Eliminarreposicion(reposicion)
                    MessageBox.Show(mensaje7)
                    bllbitacora.generarbitacora("Baja reposicion", "Tabla Reposicion", Servicios.SesionManager.obtenerinstancia)
                    For Each n In bllstockdeposito.Listarstock

                        If n.deposito.codigo = reposicion.deposito.codigo Then
                            If n.producto.codigo = reposicion.producto.codigo Then
                                If (n.cantidad - reposicion.cantidad) >= 0 Then
                                    bllstockdeposito.aumentarstock(n, reposicion.cantidad)

                                End If
                            End If
                        End If
                    Next

                Else
                    MessageBox.Show(mensaje8)
                End If

                actualizar()

            End If

        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error baja reposicion", "Tabla Reposicion", Servicios.SesionManager.obtenerinstancia)
        End Try


    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtcantidad.Text = ""
        txtcodigo.Text = ""
        txtestado.Text = ""
        TextBox1.Text = ""
        actualizar1()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje3)
            Else

                Dim reposicion As New EE.Reposicion
                reposicion.estado = "Confirmado"
                reposicion.fecha = TextBox1.Text
                reposicion.codigo = txtcodigo.Text
                reposicion.deposito = cmbdeposito.SelectedItem
                reposicion.cantidad = txtcantidad.Text
                reposicion.producto = cmbproducto.SelectedItem
                reposicion.sucursal = cmbsucursal.SelectedItem

                For Each n In bllstocksucursal.Listarstock
                    If n.sucursal.codigo = reposicion.sucursal.codigo Then
                        If n.producto.codigo = reposicion.producto.codigo Then
                            bllstocksucursal.aumentarstock(n, reposicion.cantidad)
                        End If
                    End If
                Next

                bllreposicion.Modificarreposicion(reposicion)
                MessageBox.Show(mensaje9)
                bllbitacora.generarbitacora("Confirmar reposicion", "Tabla Reposicion", Servicios.SesionManager.obtenerinstancia)
                actualizar()
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error confirmacion reposicion", "Tabla Reposicion", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(293, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 293)

        bllpalabra.verificacionpalabras(294, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 294)

        bllpalabra.verificacionpalabras(295, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 295)

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


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)


        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)
        bllpalabra.verificacionpalabras(Button5.Tag, Button5.Text)
        Button5.Text = blltraduccion.Traduccion(idioma, Button5.Tag)



        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)


        bllpalabra.verificacionpalabras(413, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 413)

        bllpalabra.verificacionpalabras(414, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 414)


        bllpalabra.verificacionpalabras(415, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 415)


        bllpalabra.verificacionpalabras(416, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 416)

        bllpalabra.verificacionpalabras(417, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 417)

        bllpalabra.verificacionpalabras(418, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 418)
    End Sub
End Class