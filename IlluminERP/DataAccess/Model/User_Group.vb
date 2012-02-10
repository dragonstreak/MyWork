
Namespace Model
    Public Class User_Group
        Private _id As Integer
        Private _groupname As String
        Private _status As Integer
        Private _remark As String

        Public Sub New()
            _status = 0
            _groupname = String.Empty
            _remark = String.Empty
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

        '×éÃû³Æ
        Public Property GroupName() As String
            Get
                Return _groupname
            End Get
            Set(ByVal Value As String)
                _groupname = Value
            End Set
        End Property

        'Status
        Public Property Status() As Integer
            Get
                Return _status
            End Get
            Set(ByVal Value As Integer)
                _status = Value
            End Set
        End Property

        '±¸×¢
        Public Property Remark() As String
            Get
                Return _remark
            End Get
            Set(ByVal Value As String)
                _remark = Value
            End Set
        End Property

    End Class
End Namespace
