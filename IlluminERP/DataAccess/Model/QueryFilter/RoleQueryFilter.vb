
Namespace Model
    Public Class RoleQueryFilter
        Private _name As String
        Private _status As Integer

        Public Sub New()
            _name = ""
            _status = -1
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Status() As Integer
            Get
                Return _status
            End Get
            Set(ByVal value As Integer)
                _status = value
            End Set
        End Property
    End Class
End Namespace

