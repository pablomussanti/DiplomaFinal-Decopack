Imports EE
Imports MPP
Public Class BLLproveedorproducto
    Public Function Generardetalle(ByVal proveedorproducto As EE.proveedorproducto) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproveedorproducto
        resultado = oMPP.Creardetalle(proveedorproducto)
        Return resultado
    End Function

    Public Function Modificardetalle(ByVal proveedorproducto As proveedorproducto) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproveedorproducto
        resultado = oMPP.Modificardetalle(proveedorproducto)
        Return resultado
    End Function

    Public Function Eliminardetalle(ByVal proveedorproducto As proveedorproducto) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproveedorproducto
        resultado = oMPP.Eliminardetalle(proveedorproducto)
        Return resultado
    End Function

    Public Function Listardetalle() As List(Of proveedorproducto)
        Dim lista As New List(Of proveedorproducto)
        Dim oMPP As New MPPproveedorproducto
        lista = oMPP.Listardetalle()
        Return lista
    End Function

    Public Function Traerdetalleporproducto(producto As Producto) As List(Of proveedorproducto)
        Dim lista As New List(Of proveedorproducto)
        Dim oMPP As New MPPproveedorproducto
        lista = oMPP.Traerdetalleporproducto(producto)
        Return lista
    End Function
End Class
