Imports EE
Imports MPP
Public Class BLLcomprador
    Public Function Generarcliente(ByVal cliente As Comprador) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPComprador
        resultado = oMPP.generarcliente(cliente)
        Return resultado
    End Function

    Public Function Eliminarcomprador(ByVal comprador As Comprador) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPComprador
        resultado = oMPP.Eliminarcomprador(comprador)
        Return resultado
    End Function

    Public Function Listarcompradoractivos(tipo As String) As List(Of Comprador)
        Dim lista As New List(Of Comprador)
        Dim oMPP As New MPPComprador
        lista = oMPP.Listarcompradoractivos(tipo)
        Return lista
    End Function

    Public Function Listarcompradortodos() As List(Of Comprador)
        Dim lista As New List(Of Comprador)
        Dim oMPP As New MPPComprador
        lista = oMPP.Listarcompradortodos()
        Return lista
    End Function

    Public Function Listarcompradorinactivos(tipo As String) As List(Of Comprador)
        Dim lista As New List(Of Comprador)
        Dim oMPP As New MPPComprador
        lista = oMPP.Listartodosinactivos(tipo)
        Return lista
    End Function

    Public Function Buscarcomprador(dni As Integer)
        Dim oMPP As New MPPComprador
        Return oMPP.BuscarComprador(dni)
    End Function




End Class
