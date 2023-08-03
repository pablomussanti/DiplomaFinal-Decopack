Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BLL
Imports EE
Imports MPP
Imports WindowsApp1

<TestClass()> Public Class UnitTest_Sucursal

    <TestMethod()> Public Sub Test_CrearSucursal()
        Dim esperado As Boolean = True
        Dim actual As Boolean = False
        Dim sucursal As New EE.Sucursal
        Dim bllsucursal As New BLLsucursal
        sucursal.codigopostal = "1718"
        sucursal.detalle = "Sucursal de Padua Sur"
        sucursal.direccion = "Sulivan 12345"
        sucursal.telefono = "4837458"
        sucursal.estado = "Activo"
        actual = bllsucursal.Crearsucursal(sucursal)
        Assert.AreEqual(actual, esperado)
    End Sub

    <TestMethod()> Public Sub Test_ModificarSucursal()
        Dim esperado As Boolean = True
        Dim actual As Boolean = False
        Dim sucursal As New EE.Sucursal
        Dim bllsucursal As New BLLsucursal
        sucursal.codigopostal = "1718"
        sucursal.codigo = "5"
        sucursal.detalle = "Sucursal de Padua Sur"
        sucursal.direccion = "Sulivan 12345"
        sucursal.telefono = "4837458"
        sucursal.estado = "Activo"
        actual = bllsucursal.Crearsucursal(sucursal)
        Assert.AreEqual(actual, esperado)
    End Sub


    <TestMethod()> Public Sub Test_EliminarSucursal()
        Dim esperado As Boolean = True
        Dim actual As Boolean = False
        Dim sucursal As New EE.Sucursal
        Dim bllsucursal As New BLLsucursal
        sucursal.codigo = "5"
        actual = bllsucursal.Eliminarsucursal(sucursal)
        Assert.AreEqual(actual, esperado)
    End Sub

End Class