Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class Datos
    'Private Str As String = ConfigurationManager.ConnectionStrings("dbContext").ConnectionString
    ' Dim x = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.ConnectionStrings(0)
    Shared Str As String
    '= x.ToString() '.ConnectionStrings.ConnectionString(0)
    Private Cnn As New SqlConnection(Str)
    Private Tranx As SqlTransaction
    Private Cmd As SqlCommand

    Public Function Leer(ByVal consulta As String, ByVal hdatos As Hashtable) As DataSet

        Dim Ds As New DataSet
        Cmd = New SqlCommand

        Cmd.Connection = Cnn
        Cmd.CommandText = consulta
        Cmd.CommandType = CommandType.StoredProcedure

        If Not hdatos Is Nothing Then
            For Each dato As String In hdatos.Keys
                Cmd.Parameters.AddWithValue(dato, hdatos(dato))
            Next
        End If

        Dim Adaptador As New SqlDataAdapter(Cmd)
        Adaptador.Fill(Ds)
        Return Ds

    End Function

    Public Function Escribir(ByVal consulta As String, ByVal hdatos As Hashtable) As Boolean

        If Cnn.State = ConnectionState.Closed Then
            Cnn.ConnectionString = Str
            Cnn.Open()
        End If

        Try
            Tranx = Cnn.BeginTransaction
            Cmd = New SqlCommand
            Cmd.Connection = Cnn
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Transaction = Tranx

            If Not hdatos Is Nothing Then

                For Each dato As String In hdatos.Keys
                    Cmd.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If

            Dim respuesta As Integer = Cmd.ExecuteNonQuery
            Tranx.Commit()
            Return True

        Catch ex As Exception
            Tranx.Rollback()
            Return False
        Finally
            Cnn.Close()
        End Try

    End Function

    Public Function backup(ByVal consulta As String, ByVal hdatos As Hashtable) As Boolean
        If Cnn.State = ConnectionState.Closed Then
            Cnn.ConnectionString = Str
            Cnn.Open()
        End If

        Try
            Cmd = New SqlCommand
            Cmd.Connection = Cnn
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.StoredProcedure

            If Not hdatos Is Nothing Then

                For Each dato As String In hdatos.Keys
                    Cmd.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If

            Dim respuesta As Integer = Cmd.ExecuteNonQuery
            Return True

        Catch ex As Exception
            Return False
        Finally
            Cnn.Close()
        End Try

    End Function


    Public Function restore(SQL As String) As Integer
        Dim filasAfectadas As Integer = 0
        Cnn.Open()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.Connection = Cnn
        cmd.CommandText = SQL
        Try
            filasAfectadas = cmd.ExecuteNonQuery()
        Catch
            filasAfectadas = -1
        End Try
        Cnn.Close()
        Return filasAfectadas
    End Function

    Public Sub asignarstring(valor As String)
        Str = valor
    End Sub


End Class
