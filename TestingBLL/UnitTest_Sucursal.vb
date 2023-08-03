Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports EE
Imports BLL
Imports MPP

<TestClass()> Public Class UnitTest_Sucursal

    <TestMethod()> Public Sub Test_CrearSucursal(sucursal As Sucursal)
        sucursal.codigopostal = "1718"
        sucursal.detalle = "Sucursal de Padua Sur"
        sucursal.direccion = "Sulivan 12345"
        sucursal.telefono = "4837458"
        Dim mppsucursal As New MPPsucursal
        Dim esperado As Boolean = True
        Dim actual As Boolean = False
        actual = mppsucursal.Crear(sucursal)
        Assert.AreEqual(actual, esperado)
    End Sub
End Class