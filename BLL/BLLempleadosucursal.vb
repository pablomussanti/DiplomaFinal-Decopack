Imports EE
Imports MPP
Public Class BLLempleadosucursal
    Public Function Crearempleadosucursal(ByVal empleadosucursal As EE.Empleadosucursal) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPempleadosucursal
        resultado = oMPP.Crearempleadosucursal(empleadosucursal)
        Return resultado
    End Function

    Public Function Modificarempleadosucursal(ByVal empleadosucursal As Empleadosucursal) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPempleadosucursal
        resultado = oMPP.Modificarempleadosucursal(empleadosucursal)
        Return resultado
    End Function

    Public Function Eliminarempleadosucursal(ByVal empleadosucursal As Empleadosucursal) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPempleadosucursal
        resultado = oMPP.Eliminarempleadosucursal(empleadosucursal)
        Return resultado
    End Function

    Public Function Listarempleadosucursal() As List(Of Empleadosucursal)
        Dim lista As New List(Of Empleadosucursal)
        Dim oMPP As New MPPempleadosucursal
        lista = oMPP.Listarempleadosucursal()
        Return lista
    End Function

    Public Function Listarempleadoporsucursal(sucursal As Sucursal) As List(Of Empleadosucursal)
        Dim lista As New List(Of Empleadosucursal)
        Dim oMPP As New MPPempleadosucursal
        lista = oMPP.Listarempleadoporsucursal(sucursal)
        Return lista
    End Function
End Class
