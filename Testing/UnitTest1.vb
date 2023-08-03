Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports EE
Imports BLL

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub Test_CrearSucursal()
        Dim esperado As Boolean = True
        Dim actual As Boolean = False
        Dim sucursal As New Sucursal
        Dim bllsucursal As New BLLsucursal
        sucursal.codigopostal = "1718"
        sucursal.detalle = "Sucursal de Padua Sur"
        sucursal.direccion = "Sulivan 12345"
        sucursal.telefono = "4837458"
        actual = bllsucursal.Crear(sucursal)
        Assert.AreEqual(actual, esperado)
    End Sub

    <TestMethod()> Public Sub Test_ModificarSucursal()
        Dim esperado As Boolean = True
        Dim actual As Boolean = False
        Dim sucursal As New Sucursal
        Dim bllsucursal As New BLLsucursal
        sucursal.codigopostal = "1718"
        sucursal.codigo = "5"
        sucursal.detalle = "Sucursal de Padua Sur"
        sucursal.direccion = "Sulivan 12345"
        sucursal.telefono = "4837458"
        actual = bllsucursal.Crear(sucursal)
        Assert.AreEqual(actual, esperado)
    End Sub

    <TestMethod()> Public Sub Test_EliminarSucursal()
        Dim esperado As Boolean = True
        Dim actual As Boolean = False
        Dim sucursal As New Sucursal
        Dim bllsucursal As New BLLsucursal
        sucursal.codigo = "5"
        actual = bllsucursal.Eliminar(sucursal)
        Assert.AreEqual(actual, esperado)
    End Sub

End Class