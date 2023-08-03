Imports Newtonsoft.Json
Imports System.IO
Public Class SerializadorJSN
    Public Sub Serialize(path As String, obj As Object)
        Dim fs As New FileStream(path, FileMode.Create)
        Dim writer As New StreamWriter(fs)
        Dim serializer As New JsonSerializer()
        Using writer
            serializer.Serialize(writer, obj)
        End Using
        writer.Close()
        fs.Close()
    End Sub
End Class
