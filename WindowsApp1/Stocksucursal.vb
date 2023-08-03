Imports EE
Imports BLL
Imports Servicios
Public Class Stocksucursal
    Implements Iidiomaobserver

    Dim bllstocksucursal As New BLLstocksucursal
    Dim listadeproductos As New List(Of EE.Producto)
    Dim bllbitacora As New BLLbitacora
    Dim nn As New BLLproducto
    Dim nnn As New BLLsucursal
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String

    Private Sub Stocksucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mensaje3 = "Stock actualizado"


        mensaje4 = "Stock Generado"
        Singletonidioma._instancia.Agregar(Me)

        mensaje5 = "Valor ingresado invalido"


        mensaje6 = "Formato ingresado no valido"


        mensaje7 = "Ingrese el formato correcto o no deje el campo vacio"

        mensaje1 = "Ingrese una cantidad"


        mensaje2 = "No se cuenta con el suficiente stock"

        mensaje8 = "Filtro aplicado"


        Me.ComboBox1.DataSource = Nothing

        Me.ComboBox1.DataSource = nnn.Listarsucursal
        Me.ComboBox1.DisplayMember = "Detalle"
        actualizar1()
        actualizar()


        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Stocksucursal")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True

        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
        End If




        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(490, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 490)

        bllpalabra.verificacionpalabras(491, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 491)

        bllpalabra.verificacionpalabras(419, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 419)


        bllpalabra.verificacionpalabras(420, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 420)


        bllpalabra.verificacionpalabras(421, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 421)


        bllpalabra.verificacionpalabras(422, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 422)

        bllpalabra.verificacionpalabras(300, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 300)


        bllpalabra.verificacionpalabras(302, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 302)

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

        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)
        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        bllpalabra.verificacionpalabras(Button4.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)

    End Sub

    Public Sub actualizar1()
        Me.ComboBox2.DataSource = Nothing
        Me.ComboBox2.DataSource = nn.Listarproducto
        Me.ComboBox2.DisplayMember = "Nombre"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje1)


            Else
                If TextBox1.Text > 0 Then
                    Dim stocksucursal As New EE.Stocksucursal
                    Dim registro As Integer = 0
                    stocksucursal.producto = ComboBox2.SelectedItem
                    stocksucursal.sucursal = ComboBox1.SelectedItem
                    stocksucursal.cantidad = TextBox1.Text
                    If bllstocksucursal.Listarstock IsNot Nothing Then
                        For Each n In bllstocksucursal.Listarstock

                            If stocksucursal.producto.codigo = n.producto.codigo Then
                                If n.sucursal.codigo = stocksucursal.sucursal.codigo Then
                                    bllstocksucursal.aumentarstock(stocksucursal, n.cantidad)
                                    registro = 1
                                    MessageBox.Show(mensaje3)
                                End If

                            End If

                        Next
                    End If

                    If registro = 0 Then
                        bllstocksucursal.generarstock(stocksucursal)
                        MessageBox.Show(mensaje4)
                        bllbitacora.generarbitacora("Aumentar stock sucursal", "Tabla Stocksucursal", Servicios.SesionManager.obtenerinstancia)
                    End If
                    registro = 0

                    actualizar()
                Else
                    MessageBox.Show(mensaje5)
                End If


            End If

        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error aumentar stock sucursal", "Tabla Stocksucursal", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub actualizar()
        Me.DataGridView1.DataSource = Nothing
        If bllstocksucursal.Listarstock Is Nothing Then
            Exit Sub
        Else
            Me.DataGridView1.DataSource = bllstocksucursal.Listarstock
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje1)


            Else
                If TextBox1.Text > 0 Then
                    Dim stocksucursal As New EE.Stocksucursal
                    stocksucursal.producto = ComboBox2.SelectedItem
                    stocksucursal.sucursal = ComboBox1.SelectedItem
                    stocksucursal.cantidad = TextBox1.Text
                    For Each n In bllstocksucursal.Listarstock

                        If n.sucursal.codigo = stocksucursal.sucursal.codigo Then
                            If n.producto.codigo = stocksucursal.producto.codigo Then


                                If (n.cantidad - stocksucursal.cantidad) >= 0 Then
                                    bllstocksucursal.reducirstock(n, stocksucursal.cantidad)
                                    MessageBox.Show(mensaje3)
                                    bllbitacora.generarbitacora("Decrementar stock sucursal", "Tabla Stocksucursal", Servicios.SesionManager.obtenerinstancia)
                                Else
                                    MessageBox.Show(mensaje2)
                                End If


                            End If


                        End If


                    Next


                    actualizar()

                Else
                    MessageBox.Show(mensaje5)
                End If


            End If


        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Decrementar stock sucursal", "Tabla Stocksucursal", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(419, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 419)


        bllpalabra.verificacionpalabras(420, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 420)


        bllpalabra.verificacionpalabras(421, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 421)


        bllpalabra.verificacionpalabras(422, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 422)

        bllpalabra.verificacionpalabras(490, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 490)

        bllpalabra.verificacionpalabras(491, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 491)

        bllpalabra.verificacionpalabras(300, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 300)


        bllpalabra.verificacionpalabras(302, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 302)

        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        bllpalabra.verificacionpalabras(Label3.Tag, Label3.Text)
        Label3.Text = blltraduccion.Traduccion(idioma, Label3.Tag)
        bllpalabra.verificacionpalabras(Label3.Tag, Label4.Text)
        Label4.Text = blltraduccion.Traduccion(idioma, Label4.Tag)

        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)
        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button4.Text)
        Button4.Text = blltraduccion.Traduccion(idioma, Button4.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)
        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        actualizar()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim stocksuc As List(Of EE.Stocksucursal)
            stocksuc = bllstocksucursal.Listarstock()
            DataGridView1.DataSource = bllstocksucursal.Verificarfaltantestock(stocksuc, TextBox2.Text)
            MessageBox.Show(mensaje8)
        Catch ex As Exception
            MessageBox.Show(mensaje7)
        End Try

    End Sub
End Class