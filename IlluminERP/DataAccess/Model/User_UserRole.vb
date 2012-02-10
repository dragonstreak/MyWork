Namespace Model
    Public Class User_UserRole
        Private _id As Integer
        Private _roleid As Integer
        Private _userid As Integer

        Public Sub New()
            _id = 0
            _roleid = 0
            _userid = 0
        End Sub

        'ID
        Public Property ID() As Integer
            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property

        'UserId
        Public Property Userid() As Integer
            Get
                Return _userid
            End Get
            Set(ByVal Value As Integer)
                _userid = Value
            End Set
        End Property

        'RoleID
        Public Property RoleId() As Integer
            Get
                Return _roleid
            End Get
            Set(ByVal Value As Integer)
                _roleid = Value
            End Set
        End Property

    End Class
End Namespace
