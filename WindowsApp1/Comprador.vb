Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports BLL
Imports EE
Imports Servicios
Imports System.IO

Public Class Comprador
    Implements Iidiomaobserver

    Dim bllcomprador As New BLLcomprador
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim compradorelegido As New EE.Comprador
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim mensaje9 As String
    Dim mensaje10 As String
    Dim mensaje11 As String
    Dim mensaje12 As String
    Dim bllbitacora As New BLLbitacora
    Dim valorp As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                If txtdni.Text > 0 Then
                    If txttelefono.Text > 0 Then

                        If bllcomprador.Buscarcomprador(txtdni.Text) = 1 Then
                            Dim comprador As New EE.Cliente
                            comprador.apellido = txtapellido.Text
                            comprador.dni = txtdni.Text
                            comprador.domicilio = txtdomicilio.Text
                            comprador.estado = "Activo"
                            comprador.mail = txtmail.Text
                            comprador.nombre = txtnombre.Text
                            comprador.telefono = txttelefono.Text
                            bllcomprador.Generarcliente(comprador)
                            MessageBox.Show(mensaje5)
                            bllbitacora.generarbitacora("Alta cliente", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
                            actualizarclientes()
                            limpiar()
                        Else
                            MessageBox.Show(mensaje1)
                        End If

                    Else

                        MessageBox.Show(mensaje6)
                    End If



                Else

                    MessageBox.Show(mensaje6)

                End If



            Else
                MessageBox.Show(mensaje4)
            End If

        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error Alta cliente", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
        End Try


    End Sub

    Public Sub actualizarclientes()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllcomprador.Listarcompradoractivos("cliente")
    End Sub

    Public Sub actualizarsocios()
        Me.DataGridView2.DataSource = Nothing
        Me.DataGridView2.DataSource = bllcomprador.Listarcompradoractivos("socio")
    End Sub


    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Cliente = a.DataBoundItem
            txtapellido.Text = p.apellido
            txtnombre.Text = p.nombre
            txtdni.Text = p.dni
            txtdomicilio.Text = p.domicilio
            txtmail.Text = p.mail
            txttelefono.Text = p.telefono
            TextBox1.Text = p.codigo
            TextBox2.Text = p.estado
            compradorelegido = p
            TextBox3.Text = "No"
            If valorp = 1 Then
                If p.estado = "Activo" Then
                    Button2.Enabled = True
                    Button7.Enabled = False
                Else
                    Button2.Enabled = False
                    Button7.Enabled = True
                End If

                Button3.Enabled = True
                Button4.Enabled = False
                Button5.Enabled = True


            End If
        End If


    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView2.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As EE.Socio = a.DataBoundItem
            txtapellido.Text = p.apellido
            txtnombre.Text = p.nombre
            txtdni.Text = p.dni
            txtdomicilio.Text = p.domicilio
            txtmail.Text = p.mail
            txttelefono.Text = p.telefono
            TextBox1.Text = p.codigo
            TextBox2.Text = p.estado
            TextBox3.Text = "Si"
            compradorelegido = p
            If valorp = 1 Then
                If p.estado = "Activo" Then
                    Button2.Enabled = True
                    Button7.Enabled = False
                Else
                    Button2.Enabled = False
                    Button7.Enabled = True
                End If
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = False


            End If
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje2)
            Else
                Dim comprador As Object
                If TypeOf compradorelegido Is EE.Socio Then
                    comprador = New EE.Socio
                Else
                    comprador = New EE.Cliente
                End If


                comprador.codigo = TextBox1.Text
                    comprador.apellido = txtapellido.Text
                    comprador.dni = txtdni.Text
                    comprador.domicilio = txtdomicilio.Text
                    comprador.estado = "Inactivo"
                    comprador.mail = txtmail.Text
                comprador.nombre = txtnombre.Text
                comprador.telefono = txttelefono.Text
                    bllcomprador.Generarcliente(comprador)
                    MessageBox.Show(mensaje7)
                    bllbitacora.generarbitacora("Baja comprador", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
                    Button1.Enabled = True
                    Button2.Enabled = False
                    Button3.Enabled = False
                    Button4.Enabled = False
                    Button5.Enabled = False
                    Button6.Enabled = True
                    Button7.Enabled = False
                    Button8.Enabled = True
                    Button9.Enabled = True
                End If
                actualizarclientes()
            actualizarsocios()
            limpiar()
        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error Baja comprador", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje2)
            Else
                Dim comprador As Object
                If TypeOf compradorelegido Is EE.Socio Then
                    comprador = New EE.Socio
                Else
                    comprador = New EE.Cliente
                End If
                comprador.codigo = TextBox1.Text
                comprador.apellido = txtapellido.Text
                comprador.dni = txtdni.Text
                comprador.domicilio = txtdomicilio.Text
                comprador.estado = TextBox2.Text
                comprador.mail = txtmail.Text
                comprador.nombre = txtnombre.Text
                comprador.telefono = txttelefono.Text
                bllcomprador.Generarcliente(comprador)
                MessageBox.Show(mensaje8)
                bllbitacora.generarbitacora("Modificacion Comprador", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button5.Enabled = False
                Button6.Enabled = True
                Button7.Enabled = False
                Button8.Enabled = True
                Button9.Enabled = True
            End If
            actualizarclientes()
            actualizarsocios()
            limpiar()
        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error Modificacion cliente", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim comprador As New EE.Socio
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje2)
            Else
                comprador.codigo = TextBox1.Text
                comprador.apellido = txtapellido.Text
                comprador.dni = txtdni.Text
                comprador.domicilio = txtdomicilio.Text
                comprador.estado = TextBox2.Text
                comprador.mail = txtmail.Text
                comprador.nombre = txtnombre.Text
                comprador.telefono = txttelefono.Text
                bllcomprador.Generarcliente(comprador)
                MessageBox.Show(mensaje9)
                bllbitacora.generarbitacora("Alta Socio", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button5.Enabled = False
                Button6.Enabled = True
                Button7.Enabled = False
                Button8.Enabled = True
                Button9.Enabled = True
            End If
            actualizarclientes()
            actualizarsocios()
            limpiar()
        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error Alta Socio", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.DataSource = bllcomprador.Listarcompradorinactivos("cliente")
            Me.DataGridView2.DataSource = Nothing
            Me.DataGridView2.DataSource = bllcomprador.Listarcompradorinactivos("socio")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim comprador As New Cliente
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje3)
            Else
                comprador.codigo = TextBox1.Text
                comprador.apellido = txtapellido.Text
                comprador.dni = txtdni.Text
                comprador.domicilio = txtdomicilio.Text
                comprador.estado = TextBox2.Text
                comprador.mail = txtmail.Text
                comprador.nombre = txtnombre.Text
                comprador.telefono = txttelefono.Text
                bllcomprador.Generarcliente(comprador)
                MessageBox.Show(mensaje10)
                bllbitacora.generarbitacora("Baja socio", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button5.Enabled = False
                Button6.Enabled = True
                Button7.Enabled = False
                Button8.Enabled = True
                Button9.Enabled = True
            End If
            actualizarclientes()
            actualizarsocios()
            limpiar()

        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error Baja socio", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
        End Try


    End Sub

    Private Sub Comprador_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        mensaje5 = "Cliente generado"

        Singletonidioma._instancia.Agregar(Me)
        mensaje6 = "Se intrudujo datos incorrectos en los campos"


        mensaje7 = "Se realizo la baja con exito"


        mensaje8 = "Se genero la modificacion con exito"


        mensaje9 = "Se genero la modificacion con exito"


        mensaje10 = "Socio dado de baja con exito"


        mensaje11 = "Comprador reactivado"


        mensaje12 = "No hay ningun dato que reportar"


        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Comprador")
        If verificador = True Then
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = True
            Button7.Enabled = False
            Button8.Enabled = True
            Button9.Enabled = True
            valorp = 1
        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = False
            Button8.Enabled = False
            Button9.Enabled = False
        End If


        actualizarsocios()
        actualizarclientes()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        mensaje1 = "Existe un comprador con este dni"
        mensaje2 = "Seleccione un cliente"
        mensaje3 = "Seleccione un socio"
        mensaje4 = "Limpie los campos"


        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(338, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 338)
        bllpalabra.verificacionpalabras(339, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 339)
        bllpalabra.verificacionpalabras(340, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 340)
        bllpalabra.verificacionpalabras(341, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 341)
        bllpalabra.verificacionpalabras(342, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 342)
        bllpalabra.verificacionpalabras(343, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 343)
        bllpalabra.verificacionpalabras(344, mensaje11)
        mensaje11 = blltraduccion.Traduccion(idioma, 344)
        bllpalabra.verificacionpalabras(345, mensaje12)
        mensaje12 = blltraduccion.Traduccion(idioma, 345)

        bllpalabra.verificacionpalabras(73, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 73)
        bllpalabra.verificacionpalabras(74, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 74)
        bllpalabra.verificacionpalabras(75, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 75)
        bllpalabra.verificacionpalabras(110, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 110)


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
        bllpalabra.verificacionpalabras(Label9.Tag, Label9.Text)
        Label9.Text = blltraduccion.Traduccion(idioma, Label9.Tag)
        bllpalabra.verificacionpalabras(Label10.Tag, Label10.Text)
        Label10.Text = blltraduccion.Traduccion(idioma, Label10.Tag)

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
        bllpalabra.verificacionpalabras(Button8.Tag, Button8.Text)
        Button8.Text = blltraduccion.Traduccion(idioma, Button8.Tag)

        bllpalabra.verificacionpalabras(Button9.Tag, Button9.Text)
        Button9.Text = blltraduccion.Traduccion(idioma, Button9.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try

            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje2)
            Else
                Dim comprador As Object
                If TypeOf compradorelegido Is EE.Socio Then
                    comprador = New EE.Socio
                Else
                    comprador = New EE.Cliente
                End If
                comprador.codigo = TextBox1.Text
                comprador.apellido = txtapellido.Text
                comprador.dni = txtdni.Text
                comprador.domicilio = txtdomicilio.Text
                comprador.estado = "Activo"
                comprador.mail = txtmail.Text
                comprador.nombre = txtnombre.Text
                comprador.telefono = txttelefono.Text
                bllcomprador.Generarcliente(comprador)
                MessageBox.Show(mensaje11)
                bllbitacora.generarbitacora("Reactivar Comprador", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button5.Enabled = False
                Button6.Enabled = True
                Button7.Enabled = False
                Button8.Enabled = True
                Button9.Enabled = True
            End If
            actualizarclientes()
            actualizarsocios()
            limpiar()
        Catch ex As Exception
            MessageBox.Show(mensaje6)
            bllbitacora.generarbitacora("Error Reactivar Comprador", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        limpiar()
    End Sub

    Public Sub limpiar()
        txtapellido.Text = ""
        txtdni.Text = ""
        txtdomicilio.Text = ""
        txtmail.Text = ""
        txtnombre.Text = ""
        txttelefono.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = True
        Button7.Enabled = False
        Button8.Enabled = True
        Button9.Enabled = True
    End Sub

    Public Sub ExportarDatosPDF(ByVal DataGRidView As DataGridView)
        Try

            Dim DataGrid As New DataGridView
            Dim filename As String
            DataGrid = DataGRidView

            Dim doc As New Document(PageSize.A4.Rotate(), 11, 11, 11, 11)

            Using fbd = New FolderBrowserDialog()
                Dim result As DialogResult = fbd.ShowDialog()
                If result = DialogResult.OK AndAlso Not String.IsNullOrWhiteSpace(fbd.SelectedPath) Then
                    filename = fbd.SelectedPath & "\" & DateTime.Now.ToString("dd-MM-yy-hh-mm-ss") & "-SocioReporte.pdf"

                End If

            End Using

            If File.Exists(filename) Then
                Return
            End If

            Dim files As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            PdfWriter.GetInstance(doc, files)
            doc.Open()

            Dim datatable As New PdfPTable(DataGRidView.ColumnCount)

            datatable.DefaultCell.Padding = 3
            Dim headerwidths As Single() = getColumnasSize(DataGrid)
            datatable.SetWidths(headerwidths)
            datatable.WidthPercentage = 100
            datatable.DefaultCell.BorderWidth = 2
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

            Dim encabezado As New Paragraph("Sistema Gestion de Ventas", New Font(Font.Name = "Tahoma", 14, Font.Bold))

            Dim texto As New Phrase("Socios del sistema:" & Now.Date() & " Cantidad: " & DataGRidView.Rows.Count, New Font(Font.Name = "Tahoma", 10, Font.Bold))

            For i As Integer = 0 To DataGrid.ColumnCount - 1
                datatable.AddCell(DataGrid.Columns(i).HeaderText)
            Next
            datatable.HeaderRows = 1
            datatable.DefaultCell.BorderWidth = 1

            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
            For i As Integer = 0 To DataGrid.RowCount - 1
                For j As Integer = 0 To DataGrid.ColumnCount - 1
                    datatable.AddCell(DataGrid(j, i).Value.ToString)
                Next
                datatable.CompleteRow()
            Next

            doc.Add(encabezado)
            doc.Add(texto)
            doc.Add(datatable)
            doc.Close()
            Process.Start(filename)
        Catch ex As Exception
            bllbitacora.generarbitacora("Error generar reporte socio", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
        End Try
    End Sub

    Public Function getColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.Columns.Count - 1) {}
        For i As Integer = 0 To dg.Columns.Count - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            If DataGridView2.Rows.Count = 0 Then
                MessageBox.Show(mensaje12)
            Else
                ExportarDatosPDF(DataGridView2)
                bllbitacora.generarbitacora("Generar reporte socios", "Tabla comprador", Servicios.SesionManager.obtenerinstancia)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        bllpalabra.verificacionpalabras(338, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 338)
        bllpalabra.verificacionpalabras(339, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 339)
        bllpalabra.verificacionpalabras(340, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 340)
        bllpalabra.verificacionpalabras(341, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 341)
        bllpalabra.verificacionpalabras(342, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 342)
        bllpalabra.verificacionpalabras(343, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 343)
        bllpalabra.verificacionpalabras(344, mensaje11)
        mensaje11 = blltraduccion.Traduccion(idioma, 344)
        bllpalabra.verificacionpalabras(345, mensaje12)
        mensaje12 = blltraduccion.Traduccion(idioma, 345)

        bllpalabra.verificacionpalabras(73, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 73)
        bllpalabra.verificacionpalabras(74, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 74)
        bllpalabra.verificacionpalabras(75, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 75)
        bllpalabra.verificacionpalabras(110, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 110)


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
        bllpalabra.verificacionpalabras(Label9.Tag, Label9.Text)
        Label9.Text = blltraduccion.Traduccion(idioma, Label9.Tag)
        bllpalabra.verificacionpalabras(Label10.Tag, Label10.Text)
        Label10.Text = blltraduccion.Traduccion(idioma, Label10.Tag)

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
        bllpalabra.verificacionpalabras(Button8.Tag, Button8.Text)
        Button8.Text = blltraduccion.Traduccion(idioma, Button8.Tag)

        bllpalabra.verificacionpalabras(Button9.Tag, Button9.Text)
        Button9.Text = blltraduccion.Traduccion(idioma, Button9.Tag)

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

    End Sub
End Class