Imports BLL
Imports System.Configuration
Imports Servicios
Public Class Login
    Implements Iidiomaobserver
    Dim intento As Integer = 1
    Dim bllpermiso As New BLLpermiso
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim mensaje5 As String
    Dim mensaje6 As String

    Dim bllpalabra As New BLLpalabra
    Dim blltraduccion As New BLLtraduccion
    '  Public Shared rolusuario As New Rol
    Dim strhelppath As String = System.IO.Path.Combine(Application.StartupPath, "Sistema Gestion De Ventas.chm")
    Dim strhelppath2 As String = System.IO.Path.Combine(Application.StartupPath, "Sistema Gestion De Ventas Final.chm")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            Dim usuariodatos As New Servicios.Usuario

            Dim entrar As Boolean = False
            Dim BLLusuario As New BLLusuario
            Dim usuariolog As New Servicios.Usuario
            Dim usuariologuiado As New List(Of Servicios.Usuario)

            usuariodatos.user = txtnombre.Text
            usuariodatos.contraseña = Seguridad.Encripta(txtcontraseña.Text, txtnombre.Text)

            usuariologuiado = BLLusuario.Confirmarusuario(usuariodatos)

            If usuariologuiado IsNot Nothing Then
                For Each n In usuariologuiado
                    entrar = True
                    usuariolog = n
                    If n.estadobloqueado = "si" Then
                        MessageBox.Show(mensaje1, " ")
                        Exit Sub
                    Else
                        MessageBox.Show(mensaje2)
                    End If

                Next
            End If


            If entrar = False Then
                MessageBox.Show(mensaje5 & intento & "", " ")
                intento = intento + 1
            Else
                SesionManager._instancia = usuariolog




                MessageBox.Show(String.Format(mensaje4 & usuariolog.user & ""))

                'Dim lstrol As New List(Of Servicios.Rolpermiso)
                'lstrol = bllpermiso.listarrolusuario(Servicios.SesionManager.obtenerinstancia)
                'For Each n In lstrol
                '    If n.Tipo = "Rol" Then
                '        usuariolog.rolpermiso.Add(n)
                '        For Each nnn In bllpermiso.traerpermisosrol(n)
                '            rolusuario.Agregar(nnn)
                '        Next
                '    Else
                '        usuariolog.rolpermiso.Add(n)
                '        rolusuario.Agregar(n)
                '    End If

                'Next
                'SesionManager._instancia = usuariolog


                usuariolog.rolpermiso = bllpermiso.Verificacionrol()
                SesionManager._instancia = usuariolog

                usuariolog.rolpermiso = bllpermiso.obtenertodospermisos(SesionManager._instancia.rolpermiso)
                SesionManager._instancia = usuariolog

                'rolusuario.Agregar(SesionManager._instancia.rolpermiso)

                Dim nn As New Menu
                nn.Show()
                Me.Close()
            End If

            If intento = 4 Then
                For Each usr In BLLusuario.Listar
                    If usr.user = txtnombre.Text Then
                        usuariolog = usr
                        usuariolog.estadobloqueado = "si"
                        BLLusuario.Crear(usuariolog)

                    End If
                Next


                MessageBox.Show(mensaje3, " ")

            End If

        Catch ex As Exception
            MessageBox.Show(mensaje6)
        End Try



    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtcontraseña.UseSystemPasswordChar = False
        Else
            txtcontraseña.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load





        Try

            Dim dic As String
            Dim bllconectado As New BLLconectado
            dic = System.IO.Path.Combine(Application.StartupPath & "Ingreso.txt")


            Dim sr As New System.IO.StreamReader(dic)
            bllconectado.asignarstring(sr.ReadToEnd)

            'Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            'config.ConnectionStrings.ConnectionStrings.Clear()
            'Dim n As New ConnectionStringSettings("dbContext", sr.ReadToEnd, "System.Data.SqlClient")

            'config.ConnectionStrings.ConnectionStrings.Add(n)
            'config.Save() '(ConfigurationSaveMode.Full, True)
            sr.Close()
            '  ConfigurationManager.ConnectionStrings.Add(ConnectionStringSettings)

            'config.Save()

            Dim idiomas As New Servicios.Idioma
            Dim bllidioma As New BLLidioma
            For Each idiomas In bllidioma.idiomalistar
                If Singletonidioma._instancia Is Nothing Then
                    If idiomas.nombre = "Español" Then

                        Singletonidioma._instancia = idiomas



                    End If
                End If

            Next

            mensaje1 = "Usuario bloqueado, consulte al administrador"
            mensaje2 = "Usuario comprobado, Estado: no bloqueado"
            mensaje3 = "Ya se ha superado el numero de intentos"
            mensaje4 = "Bienvenido "
            mensaje5 = "El usuario es incorrecto, intento "
            mensaje6 = "Este usuario no posee ningun permiso"
            txtcontraseña.UseSystemPasswordChar = True



            Dim idiomaselec As New Servicios.Idioma
            idiomaselec = Singletonidioma.obtenerinstancia()
            Dim idioma As String = idiomaselec.nombre

            bllpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
            Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
            bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
            Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
            bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
            Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
            bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
            Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)
            bllpalabra.verificacionpalabras(CheckBox1.Tag, CheckBox1.Text)
            CheckBox1.Text = blltraduccion.Traduccion(idioma, CheckBox1.Tag)
            bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
            Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

            bllpalabra.verificacionpalabras(320, mensaje1)
            mensaje1 = blltraduccion.Traduccion(idioma, 320)

            bllpalabra.verificacionpalabras(321, mensaje2)
            mensaje2 = blltraduccion.Traduccion(idioma, 321)


            bllpalabra.verificacionpalabras(322, mensaje3)
            mensaje3 = blltraduccion.Traduccion(idioma, 322)

            bllpalabra.verificacionpalabras(323, mensaje4)
            mensaje4 = blltraduccion.Traduccion(idioma, 323)

            bllpalabra.verificacionpalabras(324, mensaje5)
            mensaje5 = blltraduccion.Traduccion(idioma, 324)

            bllpalabra.verificacionpalabras(510, mensaje6)
            mensaje6 = blltraduccion.Traduccion(idioma, 510)


        Catch ex As Exception

            Dim n As New Conectado
            n.Show()
            Me.Close()

        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If txtnombre.Text = "admin" And txtcontraseña.Text = "1234" Then
                Dim n As New Usuario
                Dim usuarioadmin As New Servicios.Usuario
                usuarioadmin.user = "Adminsistema"

                SesionManager._instancia = usuarioadmin
                n.Show()

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Login_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.F11
                Dim helpProvider1 As New HelpProvider
                helpProvider1.HelpNamespace = strhelppath
                Help.ShowHelp(Me, helpProvider1.HelpNamespace, HelpNavigator.TableOfContents)
            Case Keys.F12
                Dim helpProvider1 As New HelpProvider
                helpProvider1.HelpNamespace = strhelppath2
                Help.ShowHelp(Me, helpProvider1.HelpNamespace, HelpNavigator.TableOfContents)
        End Select
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim n As New Conectado
        n.Show()
        Me.Close()
    End Sub

    Public Sub update(h As Object) Implements Iidiomaobserver.update
        Dim idiomaselec As New Servicios.Idioma
        idiomaselec = Singletonidioma.obtenerinstancia
        Dim idioma As String = idiomaselec.nombre

        BLLpalabra.verificacionpalabras(Label1.Tag, Label1.Text)
        Label1.Text = blltraduccion.Traduccion(idioma, Label1.Tag)
        bllpalabra.verificacionpalabras(Label2.Tag, Label2.Text)
        Label2.Text = blltraduccion.Traduccion(idioma, Label2.Tag)
        bllpalabra.verificacionpalabras(Button1.Tag, Button1.Text)
        Button1.Text = blltraduccion.Traduccion(idioma, Button1.Tag)
        bllpalabra.verificacionpalabras(Button2.Tag, Button2.Text)
        Button2.Text = blltraduccion.Traduccion(idioma, Button2.Tag)
        bllpalabra.verificacionpalabras(CheckBox1.Tag, CheckBox1.Text)
        CheckBox1.Text = blltraduccion.Traduccion(idioma, CheckBox1.Tag)
        bllpalabra.verificacionpalabras(Me.Tag, Me.Text)
        Me.Text = blltraduccion.Traduccion(idioma, Me.Tag)

        bllpalabra.verificacionpalabras(320, mensaje1)
        mensaje1 = blltraduccion.Traduccion(idioma, 320)

        bllpalabra.verificacionpalabras(321, mensaje2)
        mensaje2 = blltraduccion.Traduccion(idioma, 321)


        bllpalabra.verificacionpalabras(322, mensaje3)
        mensaje3 = blltraduccion.Traduccion(idioma, 322)

        bllpalabra.verificacionpalabras(323, mensaje4)
        mensaje4 = blltraduccion.Traduccion(idioma, 323)

        bllpalabra.verificacionpalabras(324, mensaje5)
        mensaje5 = blltraduccion.Traduccion(idioma, 324)
    End Sub
End Class