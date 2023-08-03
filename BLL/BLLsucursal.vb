Imports EE
Imports MPP
Public Class BLLsucursal
    Public Function Crearsucursal(ByVal sucursal As EE.Sucursal) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPsucursal
        resultado = oMPP.Crearsucursal(sucursal)
        Return resultado
    End Function

    Public Function Eliminarsucursal(ByVal sucursal As EE.Sucursal) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPsucursal
        resultado = oMPP.Eliminarsucursal(sucursal)
        Return resultado
    End Function

    Public Function Listarsucursal() As List(Of EE.Sucursal)
        Dim lista As New List(Of EE.Sucursal)
        Dim oMPP As New MPPsucursal
        lista = oMPP.Listarsucursal()
        Return lista
    End Function

    Public Function Traersucursal(sucursal As Sucursal)
        Dim objecto As New Sucursal
        Dim oMPP As New MPPsucursal
        objecto = oMPP.Traersucursal(sucursal)
        Return objecto
    End Function
End Class
