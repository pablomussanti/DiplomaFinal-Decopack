Public Class MPPrestore
    Public Function realizarrestore(direccion As String)
        Dim resultado As Boolean
        Dim odatos As New DAL.Datos
        resultado = odatos.restore("USE master ALTER DATABASE [Basededatosfinal] SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [Basededatosfinal] FROM  DISK = '" & direccion & "' with replace ALTER DATABASE [Basededatosfinal] SET MULTI_USER")
        Return resultado
    End Function

    Public Function realizarnuevorestore(direccion As String)
        Dim resultado As Boolean
        Dim odatos As New DAL.Datos
        resultado = odatos.restore(String.Format("CREATE DATABASE Basededatosfinal"))
        resultado = odatos.restore("USE master ALTER DATABASE [Basededatosfinal] SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [Basededatosfinal] FROM  DISK = '" & direccion & "' with replace ALTER DATABASE [Basededatosfinal] SET MULTI_USER")
        Return resultado
    End Function

End Class
