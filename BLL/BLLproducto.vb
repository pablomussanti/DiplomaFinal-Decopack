Imports EE
Imports MPP
Public Class BLLproducto
    Public Function Crearproducto(ByVal producto As Producto) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproducto
        resultado = oMPP.Crearproducto(producto)
        Return resultado
    End Function

    Public Function Eliminarproducto(ByVal producto As Producto) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproducto
        resultado = oMPP.Eliminarproducto(producto)
        Return resultado
    End Function

    Public Function Listarproducto() As List(Of Producto)
        Dim lista As New List(Of Producto)
        Dim oMPP As New MPPproducto
        lista = oMPP.Listarproducto
        Return lista
    End Function
    Public Function Listarproductotodo() As List(Of Producto)
        Dim lista As New List(Of Producto)
        Dim oMPP As New MPPproducto
        lista = oMPP.Listarproductotodo
        Return lista
    End Function

    Public Function Listarproductoporsucursal(sucursal As EE.Sucursal) As List(Of Producto)
        Dim lista As New List(Of Producto)
        Dim oMPP As New MPPproducto
        lista = oMPP.Listarproductoporsucursal(sucursal)
        Return lista
    End Function

    Public Function DVVcrear(dato1 As String) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproducto
        resultado = oMPP.creardvv(dato1)
        Return resultado
    End Function

    Public Function DVVactualizar(dato1 As String) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproducto
        resultado = oMPP.actualizardvv(dato1)
        Return resultado
    End Function

    Public Function DVVlistar()
        Dim resultado As New List(Of Servicios.DVV)
        Dim oMPP As New MPPproducto
        resultado = oMPP.Listardvv()
        Return resultado
    End Function

    Public Function Resguardarentidad(ByVal dato1 As Servicios.CCproducto) As Boolean
        Dim resultado As Boolean
        Dim oMPP As New MPPproducto
        resultado = oMPP.Resguardarentidad(dato1)
        Return resultado
    End Function

    Public Function Listarentidad() As List(Of Servicios.CCproducto)
        Dim lista As New List(Of Servicios.CCproducto)
        Dim oMPP As New MPPproducto
        lista = oMPP.Listarentidad
        Return lista
    End Function
End Class
