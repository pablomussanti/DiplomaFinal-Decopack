Imports MPP
Imports EE
Public Class BLLproveedor
    Public Function Crearproveedor(ByVal proveedor As EE.Proveedor) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproveedor
        resultado = oMPP.Crearproveedor(proveedor)
        Return resultado
    End Function

    Public Function Modificarproveedor(ByVal proveedor As Proveedor) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproveedor
        resultado = oMPP.Modificarproveedor(proveedor)
        Return resultado
    End Function

    Public Function Eliminarproveedor(ByVal proveedor As Proveedor) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproveedor
        resultado = oMPP.Eliminarproveedor(proveedor)
        Return resultado
    End Function

    Public Function Listarproveedor() As List(Of Proveedor)
        Dim lista As New List(Of Proveedor)
        Dim oMPP As New MPPproveedor
        lista = oMPP.Listarproveedor()
        Return lista
    End Function

    Public Sub generaradvertencia(proveedor As Proveedor, errores As Integer)
        proveedor.cantidaddeerrores = (errores + 1)
    End Sub
End Class
