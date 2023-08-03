Imports EE
Imports BLL
Imports Servicios

Public Class Reclamo
    Implements Iidiomaobserver

    Dim bllreclamo As New BLLreclamo

    Dim bllcomprador As New BLLcomprador
    Dim bllsucursal As New BLLsucursal
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim bllbitacora As New BLLbitacora
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje4 As String

    Private Sub Reclamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizar()
        actualizar2()


        Dim verificador As Boolean
        Dim bllpermisos As New BLLpermiso
        verificador = bllpermisos.verificarpermiso(Servicios.SesionManager._instancia.rolpermiso, "Gestion Reclamo")
        If verificador = True Then
            Button1.Enabled = True

        Else
            Button1.Enabled = False

        End If

        mensaje1 = "Reclamo generado"
        Singletonidioma._instancia.Agregar(Me)

        mensaje2 = "Datos ingresados incorrectamente"

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)


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

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(405, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 405)

        bllpalabra.verificacionpalabras(406, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 406)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If txtmedidaatomar.Text = "" Or txtmotivo.Text = "" Then
                Exit Sub
            End If
            Dim reclamo As New EE.Reclamo
            reclamo.comprador = cmbcomprador.SelectedItem
            reclamo.fecha = DateTime.Now
            reclamo.medidasatomar = txtmedidaatomar.Text
            reclamo.sucursal = cmbsucursal.SelectedItem
            reclamo.motivo = txtmotivo.Text
            bllreclamo.generarreclamo(reclamo)
            MessageBox.Show(mensaje1)
            bllbitacora.generarbitacora("Generar reclamo", "Tabla Reclamo", Servicios.SesionManager.obtenerinstancia)
            actualizar()


        Catch ex As Exception
            MessageBox.Show(mensaje2)
            bllbitacora.generarbitacora("Error generar reclamo", "Tabla Reclamo", Servicios.SesionManager.obtenerinstancia)
        End Try

    End Sub

    Public Sub actualizar()

        Me.DataGridView1.DataSource = Nothing
        If bllreclamo.Listarreclamo Is Nothing Then
            Exit Sub
        Else
            Me.DataGridView1.DataSource = bllreclamo.Listarreclamo
        End If


    End Sub

    Public Sub actualizar2()
        Me.cmbcomprador.DataSource = Nothing
        Dim nn As New BLLcomprador
        Dim listacompradores As New List(Of EE.Comprador)
        For Each n In nn.Listarcompradoractivos("socio")
            listacompradores.Add(n)
        Next
        For Each nnn In nn.Listarcompradoractivos("cliente")
            listacompradores.Add(nnn)
        Next
        Me.cmbcomprador.DataSource = listacompradores
        Me.cmbcomprador.DisplayMember = "dni"

        Me.cmbsucursal.DataSource = Nothing
        Dim bllsucursal As New BLLsucursal
        Me.cmbsucursal.DataSource = bllsucursal.Listarsucursal
        Me.cmbsucursal.DisplayMember = "Detalle"
    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre


        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)


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

        bllpalabra.verificacionpalabras(GroupBox1.Tag, GroupBox1.Text)
        GroupBox1.Text = blltraduccion.Traduccion(idioma, GroupBox1.Tag)

        bllpalabra.verificacionpalabras(405, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 405)

        bllpalabra.verificacionpalabras(406, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 406)

    End Sub
End Class