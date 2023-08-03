Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BLL
Imports MPP
Imports EE
<TestClass()> Public Class UnitTest_Sucursal

    <TestMethod()> Public Sub Test_CrearSucursal()
        Dim sucursal As New Sucursal
        Dim mppsucursal As New MPPsucursal
        Dim esperado As Boolean = False
        Dim actual As Boolean = False

        sucursal.codigopostal = "1718"
        sucursal.detalle = "Sucursal de Padua Sur"
        sucursal.direccion = "Sulivan 12345"
        sucursal.telefono = "4837458"

        actual = mppsucursal.Crear(sucursal)
        Assert.AreEqual(actual, esperado)

    End Sub

End Class