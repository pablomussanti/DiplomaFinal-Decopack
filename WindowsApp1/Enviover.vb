Imports EE
Imports BLL
Imports Servicios

Public Class Enviover
    Implements Iidiomaobserver

    Dim listaenvio As New List(Of EE.Envio)
    Dim bllenvio As New BLLenvio
    Dim bllempleadodeposito As New BLLempleadodeposito
    Dim bllventa As New BLLventa
    Dim listaproducto As New List(Of EE.Producto)
    Dim blldetalleventa As New BLLdetalleventa
    Dim bllproducto As New BLLproducto
    Dim blldevolucion As New BLLdevolucion
    Dim mensaje2 As String
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim bllbitacora As New BLLbitacora
    Dim mensaje3 As String
    Dim mensaje4 As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            actualizardata()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Enviover_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mensaje3 = "Envio confirmado"


        mensaje4 = "Ingrese los campos con el formato correspondiente"

        Singletonidioma._instancia.Agregar(Me)


        actualizar1()
        txtcodigo.Enabled = False
        txtdirecion.Enabled = False
        txtestado.Enabled = False
        txtfechallegada.Enabled = False
        txtfechasalida.Enabled = False
        cmbventa.Enabled = False

        mensaje2 = "Seleccione un envio"





        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Confirmar Envio")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True

        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False

        End If

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(368, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 368)
        bllpalabra.verificacionpalabras(149, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 149)

        bllpalabra.verificacionpalabras(369, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 369)
        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)


    End Sub

    Public Sub actualizar1()
        Me.cmbempleado.DataSource = Nothing
        Me.cmbempleado.DataSource = bllempleadodeposito.Listarempleadodeposito
        Me.cmbempleado.DisplayMember = "Codigo"
    End Sub

    Public Sub actualizardata()
        listaenvio.Clear()
        Me.DataGridView1.DataSource = Nothing
        If bllenvio.Listarenvioporempleado(cmbempleado.SelectedItem) Is Nothing Then


        Else
            For Each n In bllenvio.Listarenvioporempleado(cmbempleado.SelectedItem)
                listaenvio.Add(n)
            Next

        End If

        If bllenvio.Listarenviopordevolucion(cmbempleado.SelectedItem) Is Nothing Then

        Else
            For Each n In bllenvio.Listarenviopordevolucion(cmbempleado.SelectedItem)
                listaenvio.Add(n)
            Next
        End If

        Me.DataGridView1.DataSource = listaenvio
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows
        listaproducto.Clear()
        Dim lstdev As New List(Of EE.Devolucion)
        Dim lstdetalle As New List(Of EE.Detalleventa)
        Me.DataGridView2.DataSource = Nothing
        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Envio = a.DataBoundItem
            txtcodigo.Text = p.codigo
            txtdirecion.Text = p.direccion
            txtestado.Text = p.estado
            txtfechallegada.Text = p.fechadellegada
            txtfechasalida.Text = p.fechadesalida
            Dim lstventa As New List(Of EE.Venta)
            lstventa.Add(p.venta)
            cmbventa.DataSource = lstventa


            If p.estado = "Atender" Then
                For Each detalleventa In blldetalleventa.Listardetalle(p.venta)
                    lstdetalle.Add(detalleventa)
                Next
            End If
            Me.DataGridView2.DataSource = lstdetalle
            '    Me.DataGridView3.DataSource = listaproducto
            If p.estado = "Devolucion" Then
                For Each n In blldevolucion.Listardevolucion

                    If n.envio.venta.codigo = p.venta.codigo Then


                        lstdev.Add(n)



                    End If

                    listaproducto.Add(n.producto)


                Next
                If lstdev.Count = 0 Then

                Else
                    Me.DataGridView2.DataSource = Nothing
                    Me.DataGridView2.DataSource = lstdev
                End If

                '  Me.DataGridView3.DataSource = listaproducto
            End If




        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            If txtcodigo.Text = "" Then
                MessageBox.Show(mensaje2)
            Else
                Dim envio As New Envio
                envio.codigo = txtcodigo.Text
                envio.direccion = txtdirecion.Text
                envio.empleado = cmbempleado.SelectedItem
                envio.estado = "Confirmado"
                envio.fechadellegada = txtfechallegada.Text
                envio.fechadesalida = txtfechasalida.Text
                envio.venta = cmbventa.SelectedItem
                bllenvio.Modificarenvio(envio)
                MessageBox.Show(mensaje3)
                bllbitacora.generarbitacora("Confirmar envio", "Tabla Envio", Servicios.SesionManager.obtenerinstancia)
                actualizardata()
                DataGridView2.DataSource = Nothing
                ' DataGridView3.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje4)
            bllbitacora.generarbitacora("Error confirmar envio", "Tabla Envio", Servicios.SesionManager.obtenerinstancia)
        End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
    End Sub

    Public Sub limpiar()
        txtcodigo.Text = ""
        txtdirecion.Text = ""
        txtestado.Text = ""
        txtfechallegada.Text = ""
        txtfechasalida.Text = ""
        DataGridView2.DataSource = Nothing
        'DataGridView3.DataSource = Nothing
        cmbventa.DataSource = Nothing
    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(368, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 368)
        bllpalabra.verificacionpalabras(149, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 149)

        bllpalabra.verificacionpalabras(369, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 369)
        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)


        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
    End Sub
End Class