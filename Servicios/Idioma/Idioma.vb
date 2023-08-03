Public Class Idioma
    Inherits Entidad

    Private _nombre As String

    Public Property nombre As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return nombre
    End Function

    Private list As New List(Of Iidiomaobserver)

    Public Sub Agregar(o As Iidiomaobserver)
        list.Add(o)
    End Sub

    Public Sub Quitar(o As Iidiomaobserver)
        list.Remove(o)
    End Sub

    Public Sub Notificar()
        For Each o In list
            o.update(Me)
        Next
    End Sub
End Class
