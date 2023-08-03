Public Class DVV
    Private _entidad As String

    Public Property entidad As String
        Get
            Return _entidad
        End Get
        Set(ByVal value As String)
            _entidad = value
        End Set
    End Property

    Private _dvv As String

    Public Property dvv As String
        Get
            Return _dvv
        End Get
        Set(ByVal value As String)
            _dvv = value
        End Set
    End Property
End Class
