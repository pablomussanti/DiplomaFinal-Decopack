Imports Servicios
Imports BLL
Public Class Permisos
    Implements Iidiomaobserver
    Dim treev As New TreeView
    Dim bllpermiso As New BLLpermiso
    Dim bllusuario As New BLLusuario
    Dim permisousuario As New Permisousuario
    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String
    Dim mensaje7 As String
    Dim mensaje8 As String
    Dim mensaje9 As String
    Dim mensaje10 As String
    Dim lstpermisorol As New List(Of Rolpermiso)
    Dim contador As Integer = 0
    Dim valorcambia As Integer = 1

    Private Sub Permisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarComboPaquete1()
        cmbpermiso.Enabled = False
        Button3.Enabled = False
        Button8.Enabled = False
        ComboBox4.Enabled = False
        Button2.Enabled = False

        Singletonidioma._instancia.Agregar(Me)

        mensaje1 = "Rol Asignado"


        mensaje2 = "Seleccione solo los items de los campos disponibles"


        mensaje3 = "Rol eliminado"


        mensaje4 = "Ingrese un nombre"


        mensaje5 = "Rol creado"


        mensaje6 = "Rol eliminado del usuario"


        mensaje7 = "Seleccione un permiso"


        mensaje8 = "Permiso Asignado al rol"


        mensaje9 = "Seleccione un permiso"


        mensaje10 = "Permiso desasociado al rol"

        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

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

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)

        bllpalabra.verificacionpalabras(Button5.Tag, Button5.Text)
        Button5.Text = blltraduccion.Traduccion(idioma, Button5.Tag)
        bllpalabra.verificacionpalabras(Button6.Tag, Button6.Text)
        Button6.Text = blltraduccion.Traduccion(idioma, Button6.Tag)

        bllpalabra.verificacionpalabras(Button8.Tag, Button8.Text)
        Button8.Text = blltraduccion.Traduccion(idioma, Button8.Tag)


        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)

        bllpalabra.verificacionpalabras(GroupBox3.Tag, GroupBox3.Text)
        GroupBox3.Text = blltraduccion.Traduccion(idioma, GroupBox3.Tag)

        bllpalabra.verificacionpalabras(GroupBox4.Tag, GroupBox4.Text)
        GroupBox4.Text = blltraduccion.Traduccion(idioma, GroupBox4.Tag)


        bllpalabra.verificacionpalabras(378, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 378)


        bllpalabra.verificacionpalabras(379, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 379)


        bllpalabra.verificacionpalabras(380, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 380)


        bllpalabra.verificacionpalabras(381, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 381)


        bllpalabra.verificacionpalabras(382, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 382)


        bllpalabra.verificacionpalabras(383, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 383)


        bllpalabra.verificacionpalabras(384, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 384)


        bllpalabra.verificacionpalabras(385, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 385)

        bllpalabra.verificacionpalabras(386, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 386)

        bllpalabra.verificacionpalabras(387, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 387)


        lstpermisorol = Servicios.SesionManager._instancia.rolpermiso()

        bllpermiso.Verificacionrol()

        llenartreeview()

        'For Each n In lstpermisorol

        '    If n.Tipo = "Rol" Then
        '        TreeView1.Nodes.Add(n.nombre)
        '        actualizarrol(n)

        '    Else

        '        TreeView1.Nodes.Add(n.Mostrar)

        '    End If

        'Next

    End Sub

    Public Sub llenartreeview()
        Dim lstpermisosrol As New List(Of Servicios.Rolpermiso)
        Dim lstrol As New List(Of Rol)
        Dim contador1 As Integer = -1



        lstpermisosrol = bllpermiso.listarrolusuario(SesionManager._instancia)

        For Each n In lstpermisosrol
            If n.Tipo = "Rol" Then

                'lstpermisosrol.Add(n)
                lstrol.Add(n)
            Else
                contador1 = contador1 + 1
                TreeView1.Nodes.Add(n.nombre)
                'lstpermisosrol.Add(n)
            End If
        Next
        If lstrol IsNot Nothing Then
            For Each n In lstrol
                contador1 = contador1 + 1
                contador = contador + 1
                TreeView1.Nodes.Add(n.nombre)
                llenarpermisos(n, contador1)
            Next
        End If
        contador = 0

    End Sub

    Public Sub llenarpermisos(rol As Rol, cont As Integer)
        Dim lstrol2 As New List(Of Rol)

        Dim permisosroles As New List(Of Rolpermiso)


        If TreeView1.SelectedNode Is Nothing Then
            TreeView1.SelectedNode = TreeView1.Nodes.Item(cont)
        Else
            If valorcambia = contador Then

                TreeView1.SelectedNode = TreeView1.SelectedNode.Nodes.Item(cont)
            End If
            If valorcambia <> contador Then
                valorcambia = contador
                TreeView1.SelectedNode = TreeView1.Nodes.Item(cont)
            End If


        End If

        permisosroles = bllpermiso.traerpermisosrol(rol)
        Dim conta As Integer = -1
        If permisosroles Is Nothing Then Exit Sub
        For Each n In permisosroles
            If n.Tipo = "Rol" Then
                lstrol2.Add(n)
                rol.Agregar(n)

            Else
                TreeView1.SelectedNode.Nodes.Add(n.nombre)
                conta = conta + 1
                rol.Agregar(n)

            End If
        Next

        If lstrol2.Count > 0 Then
            Dim origen As Object
            origen = TreeView1.SelectedNode
            For Each n In lstrol2
                TreeView1.SelectedNode = origen
                conta = conta + 1
                TreeView1.SelectedNode.Nodes.Add(n.nombre)
                llenarpermisos(n, conta)

            Next
        Else
            Exit Sub
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim rol As Rolpermiso
            Dim usuario As New Servicios.Usuario
            rol = ComboBox2.SelectedItem
            usuario = ComboBox1.SelectedItem

            bllpermiso.asignarpermisousuario(usuario, rol)
            MessageBox.Show(mensaje1)
            cargarComboPaquete1()
            Button2.Enabled = False
            ComboBox4.DataSource = Nothing

        Catch ex As Exception
            MessageBox.Show(mensaje2)
        End Try


    End Sub

    Public Sub cargarComboPaquete1()
        Me.ComboBox1.DataSource = Nothing

        Me.ComboBox1.DataSource = bllusuario.Listar
        Me.ComboBox1.DisplayMember = "User"

        Me.ComboBox2.DataSource = Nothing

        Me.ComboBox2.DataSource = bllpermiso.listarpermisos
        Me.ComboBox2.DisplayMember = "Nombre"

        Me.ComboBox3.DataSource = Nothing

        Me.ComboBox3.DataSource = bllpermiso.listarrol
        Me.ComboBox3.DisplayMember = "Nombre"

        Me.DataGridView2.DataSource = Nothing
        Me.DataGridView2.DataSource = bllpermiso.listarrol

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = bllpermiso.listarpermisousuario
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim rol As New Servicios.Rol
            rol = ComboBox3.SelectedItem

            bllpermiso.eliminarrol(rol)
            MessageBox.Show(mensaje3)
            cargarComboPaquete1()
        Catch ex As Exception
            MessageBox.Show(mensaje2)
        End Try

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If TextBox1.Text = "" Then
                MessageBox.Show(mensaje4)
            Else
                Dim rol As New Rol
                rol.nombre = TextBox1.Text
                rol.Tipo = "Rol"
                bllpermiso.generarrolpermiso(rol)
                MessageBox.Show(mensaje5)
                cargarComboPaquete1()
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            bllpermiso.desasignarrolusuario(ComboBox1.SelectedItem, ComboBox4.SelectedItem)
            Button2.Enabled = False
            ComboBox4.DataSource = Nothing
            MessageBox.Show(mensaje6)
            cargarComboPaquete1()

        Catch ex As Exception
            MessageBox.Show(mensaje2)
        End Try

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim lstperm As New List(Of Servicios.Rolpermiso)
            DataGridView3.DataSource = bllpermiso.listarpermisofaltante(ComboBox3.SelectedItem)
            DataGridView4.DataSource = bllpermiso.traerpermisosrol(ComboBox3.SelectedItem)
            If DataGridView3.Rows.Count = 0 Then
                Button3.Enabled = False
                Button8.Enabled = True
            End If
            If DataGridView4.Rows.Count = 0 Then
                Button3.Enabled = True
                Button8.Enabled = False
            End If
            If DataGridView4.Rows.Count > 0 And DataGridView3.Rows.Count > 0 Then
                Button3.Enabled = True
                Button8.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(mensaje2)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If cmbpermiso.Items.Count = 0 Then
                MessageBox.Show(mensaje7)
            Else

                Dim lstperm As New List(Of Servicios.Rolpermiso)
                bllpermiso.asociarpermiso(ComboBox3.SelectedItem, cmbpermiso.SelectedItem)
                MessageBox.Show(mensaje8)
                DataGridView3.DataSource = bllpermiso.listarpermisofaltante(ComboBox3.SelectedItem)
                DataGridView4.DataSource = bllpermiso.traerpermisosrol(ComboBox3.SelectedItem)


            End If
            If DataGridView3.Rows.Count = 0 Then
                Button3.Enabled = False
                Button8.Enabled = True
            End If
            If DataGridView4.Rows.Count = 0 Then
                Button3.Enabled = True
                Button8.Enabled = False
            End If
            If DataGridView4.Rows.Count > 0 And DataGridView3.Rows.Count > 0 Then
                Button3.Enabled = True
                Button8.Enabled = True
            End If
            cmbpermiso.DataSource = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As Servicios.Permisousuario = a.DataBoundItem
            Dim lstusuario As New List(Of Servicios.Usuario)
            Dim lstpermiso As New List(Of Servicios.Rolpermiso)
            lstpermiso.Add(p.permiso)
            lstusuario.Add(p.usuario)
            ComboBox1.DataSource = lstusuario
            ComboBox4.DataSource = lstpermiso
            Button2.Enabled = True
        End If


    End Sub

    Private Sub DataGridView3_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView3.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView3.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As Servicios.Rolpermiso = a.DataBoundItem
            Dim lstpermiso As New List(Of Servicios.Rolpermiso)
            lstpermiso.Add(p)
            cmbpermiso.DataSource = lstpermiso
            Button8.Enabled = False
            Button3.Enabled = True
        End If


    End Sub

    Private Sub DataGridView4_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView4.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView4.SelectedRows

        If l.Count = 1 Then

            Dim a = l(0)

            Dim p As Servicios.Rolpermiso = a.DataBoundItem
            Dim lstpermiso As New List(Of Servicios.Rolpermiso)
            lstpermiso.Add(p)
            cmbpermiso.DataSource = lstpermiso
            Button8.Enabled = True
            Button3.Enabled = False
        End If


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            cargarComboPaquete1()
            Button2.Enabled = False
            ComboBox4.DataSource = Nothing
            DataGridView3.DataSource = Nothing
            DataGridView4.DataSource = Nothing
            cmbpermiso.DataSource = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            If cmbpermiso.Items.Count = 0 Then
                MessageBox.Show(mensaje9)
            Else
                Dim lstperm As New List(Of Servicios.Rolpermiso)
                bllpermiso.desasociarpermiso(ComboBox3.SelectedItem, cmbpermiso.SelectedItem)
                MessageBox.Show(mensaje10)
                DataGridView3.DataSource = bllpermiso.listarpermisofaltante(ComboBox3.SelectedItem)
                DataGridView4.DataSource = bllpermiso.traerpermisosrol(ComboBox3.SelectedItem)
            End If
            If DataGridView3.Rows.Count = 0 Then
                Button3.Enabled = False
                Button8.Enabled = True
            End If
            If DataGridView4.Rows.Count = 0 Then
                Button3.Enabled = True
                Button8.Enabled = False
            End If
            If DataGridView4.Rows.Count > 0 And DataGridView3.Rows.Count > 0 Then
                Button3.Enabled = True
                Button8.Enabled = True
            End If
            cmbpermiso.DataSource = Nothing


        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

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

        bllpalabra.verificacionpalabras(Button3.Tag, Button3.Text)
        Button3.Text = blltraduccion.Traduccion(idioma, Button3.Tag)

        bllpalabra.verificacionpalabras(Button5.Tag, Button5.Text)
        Button5.Text = blltraduccion.Traduccion(idioma, Button5.Tag)
        bllpalabra.verificacionpalabras(Button6.Tag, Button6.Text)
        Button6.Text = blltraduccion.Traduccion(idioma, Button6.Tag)

        bllpalabra.verificacionpalabras(Button8.Tag, Button8.Text)
        Button8.Text = blltraduccion.Traduccion(idioma, Button8.Tag)


        bllpalabra.verificacionpalabras(GroupBox2.Tag, GroupBox2.Text)
        GroupBox2.Text = blltraduccion.Traduccion(idioma, GroupBox2.Tag)

        bllpalabra.verificacionpalabras(GroupBox3.Tag, GroupBox3.Text)
        GroupBox3.Text = blltraduccion.Traduccion(idioma, GroupBox3.Tag)

        bllpalabra.verificacionpalabras(GroupBox4.Tag, GroupBox4.Text)
        GroupBox4.Text = blltraduccion.Traduccion(idioma, GroupBox4.Tag)


        bllpalabra.verificacionpalabras(378, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 378)


        bllpalabra.verificacionpalabras(379, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 379)


        bllpalabra.verificacionpalabras(380, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 380)


        bllpalabra.verificacionpalabras(381, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 381)


        bllpalabra.verificacionpalabras(382, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 382)


        bllpalabra.verificacionpalabras(383, mensaje6)
        mensaje6 = blltraduccion.Traduccion(idioma, 383)


        bllpalabra.verificacionpalabras(384, mensaje7)
        mensaje7 = blltraduccion.Traduccion(idioma, 384)


        bllpalabra.verificacionpalabras(385, mensaje8)
        mensaje8 = blltraduccion.Traduccion(idioma, 385)

        bllpalabra.verificacionpalabras(386, mensaje9)
        mensaje9 = blltraduccion.Traduccion(idioma, 386)

        bllpalabra.verificacionpalabras(387, mensaje10)
        mensaje10 = blltraduccion.Traduccion(idioma, 387)

        bllpalabra.verificacionpalabras(Label5.Tag, Label5.Text)
        Label5.Text = blltraduccion.Traduccion(idioma, Label5.Tag)

        bllpalabra.verificacionpalabras(Label6.Tag, Label6.Text)
        Label6.Text = blltraduccion.Traduccion(idioma, Label6.Tag)

        bllpalabra.verificacionpalabras(Label7.Tag, Label7.Text)
        Label7.Text = blltraduccion.Traduccion(idioma, Label7.Tag)

        bllpalabra.verificacionpalabras(Label8.Tag, Label8.Text)
        Label8.Text = blltraduccion.Traduccion(idioma, Label8.Tag)

    End Sub


End Class