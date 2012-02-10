

Namespace Model
    Public Class User_UserTeam
        Private _id As Integer
        Private _userid As Integer
        Private _teamid As Integer
        Private _teamlevel As Integer
        Private _isteamleader As Integer

        Public Sub New()
            _id = 0
            _userid = 0
            _teamid = 0
            _teamlevel = 0
            _isteamleader = 0
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

        'UserID
        Public Property UserID() As Integer
            Get
                Return _userid
            End Get
            Set(ByVal Value As Integer)
                _userid = Value
            End Set
        End Property

        'TeamID
        Public Property TeamID() As Integer
            Get
                Return _teamid
            End Get
            Set(ByVal Value As Integer)
                _teamid = Value
            End Set
        End Property

        'TeamLevel
        Public Property TeamLevel() As Integer
            Get
                Return _teamlevel
            End Get
            Set(ByVal Value As Integer)
                _teamlevel = Value
            End Set
        End Property

        'IsTeamLeader
        Public Property IsTeamLeader() As Integer
            Get
                Return _isteamleader
            End Get
            Set(ByVal Value As Integer)
                _isteamleader = Value
            End Set
        End Property

    End Class
End Namespace
