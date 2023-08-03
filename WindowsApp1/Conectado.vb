Imports BLL
Imports System.Configuration
Imports Servicios

Public Class Conectado


    Dim bllrestore As New BLLrestore
    Dim bllpalabra As New BLLpalabra
    Dim mensaje1 As String
    Dim mensaje2 As String
    Dim mensaje3 As String
    Dim mensaje4 As String
    Dim blltraduccion As New BLLtraduccion
    Dim dic As String
    Dim texto As String



    Private Sub Conectado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try



            dic = System.IO.Path.Combine(Application.StartupPath & "Ingreso.txt")


            Dim sr As New System.IO.StreamReader(dic)
            texto = sr.ReadToEnd()
            sr.Close()





        Catch ex As Exception

            Dim sw As New System.IO.StreamWriter(dic)
            sw.WriteLine("")
            sw.Close()

        End Try


        Button1.Enabled = False
        Button3.Enabled = False
        TextBox2.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            Dim bllconectado As New BLLconectado
            Dim localhost As String = TextBox1.Text
            Dim cadenanueva = "Data Source =" + localhost + "; Integrated Security = True"
            'Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            'config.ConnectionStrings.ConnectionStrings.Clear()
            'Dim n As New ConnectionStringSettings("dbContext", cadenanueva, "System.Data.SqlClient")

            'config.ConnectionStrings.ConnectionStrings.Add(n)
            'config.Save(ConfigurationSaveMode.Full, True)

            bllconectado.asignarstring(cadenanueva)
            Dim sw As New System.IO.StreamWriter(dic)
            sw.WriteLine(cadenanueva)
            sw.Close()

            'ConfigurationManager.RefreshSection("appSettings")

            'ConfigurationManager.ConnectionStrings.Clear()
            'Dim connectionString As String = "Server=myserver;Port=8080;Database=my_db;..."
            'Dim ConnectionStringSettings As ConnectionStringSettings = New ConnectionStringSettings("MyConnectionStringKey", connectionString)
            'ConfigurationManager.ConnectionStrings.Add(ConnectionStringSettings)

            'config.Save()

            Dim filename As String
            Dim nombredelarchivo As String = TextBox2.Text
            Using fbd = New FolderBrowserDialog()
                Dim result As DialogResult = fbd.ShowDialog()
                If result = DialogResult.OK AndAlso Not String.IsNullOrWhiteSpace(fbd.SelectedPath) Then
                    filename = fbd.SelectedPath & "\" & nombredelarchivo & ".bak"

                End If

            End Using

            If filename = "" Or nombredelarchivo = "" Then
                MessageBox.Show("Faltan datos")
                Exit Sub
            End If

            bllrestore.realizarnuevorestore(filename)

            Dim strfinal As String = "Data Source =" + localhost + "; Initial Catalog = Basededatosfinal; Integrated Security = True"
            bllconectado.asignarstring(strfinal)

            Dim sw2 As New System.IO.StreamWriter(dic)
            sw2.WriteLine(strfinal)
            sw2.Close()

            bllconectado.asignarstring(strfinal)


            '    config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            '   config.ConnectionStrings.ConnectionStrings.Clear()
            '  Dim nn As New ConnectionStringSettings("dbContext", cadenanueva, "System.Data.SqlClient")

            '     config.ConnectionStrings.ConnectionStrings.Add(nn)
            '    config.Save()

            '   Dim cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)


            ' Dim ConnectionStringsSection = cfg.GetSection("connectionStrings")




            '  Dim xx = ConnectionStringsSection.CurrentConfiguration.ConnectionStrings


            ' xx.ConnectionStrings(0).ConnectionString = "sdfgsdfdf!"

            '    config.Save(ConfigurationSaveMode.Modified, True)
            '  ConfigurationManager.RefreshSection(cfg.ConnectionStrings.SectionInformation.SectionName)



            MessageBox.Show("Se actualizo el nombre del servidor con exito y se realizo el restore, ponga en salir e intente entrar en el sistema")


        Catch ex As Exception
            MessageBox.Show("Verifique se instalo correctamente el sql y esten levantados los servicios e intente nuevamente.")
        End Try




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim n As New Login
        n.Show()
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If Button1.Enabled = True Then
            Button1.Enabled = False
            TextBox2.Enabled = False
        Else
            Button1.Enabled = True
            TextBox2.Enabled = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If Button3.Enabled = True Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim bllconectado As New BLLconectado
            Dim localhost As String = TextBox1.Text
            Dim cadenanueva As String = "Data Source =" + localhost + "; Initial Catalog = Basededatosfinal; Integrated Security = True"
            'Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            'config.ConnectionStrings.ConnectionStrings.Clear()
            ' Dim n As New ConnectionStringSettings("dbContext", cadenanueva, "System.Data.SqlClient")

            '    config.ConnectionStrings.ConnectionStrings.Add(n)
            '  config.Save(ConfigurationSaveMode.Modified, True)
            '  config.Save()

            bllconectado.asignarstring(cadenanueva)
            Dim sw As New System.IO.StreamWriter(dic)
            sw.WriteLine("Data Source =" + localhost + "; Initial Catalog = Basededatosfinal; Integrated Security = True")
            sw.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class