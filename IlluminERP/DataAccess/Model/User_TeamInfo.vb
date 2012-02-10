Imports System

Namespace Model
    <Serializable()>
    Public Class User_TeamInfo
        Private _id As Integer
        Private _code As String
        Private _teamname As String
        Private _parentid As Integer
        Private _teamleaderid As Integer
        Private _cityid As Integer
        Private _sectorid As Integer
        Private _teamMemberIdList As List(Of Integer)
        Private _teamLeader As User_UserInfo
        Private _parentTeamName As String
        Private _city As String
        Private _sector As String
        Private _roleIdList As List(Of Integer)


        Public Sub New()
            _id = 0
            _code = String.Empty
            _teamname = String.Empty
            _parentid = 0
            _teamleaderid = 0
            _cityid = 0
            _sectorid = 0
            _teamMemberIdList = Nothing
            _teamLeader = Nothing
            _roleIdList = Nothing
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

        '±àºÅ
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal Value As String)
                _code = Value
            End Set
        End Property

        'TeamName
        Public Property TeamName() As String
            Get
                Return _teamname
            End Get
            Set(ByVal Value As String)
                _teamname = Value
            End Set
        End Property


        '¸¸½Úµã
        Public Property ParentID() As Integer
            Get
                Return _parentid
            End Get
            Set(ByVal Value As Integer)
                _parentid = Value
            End Set
        End Property


        'TeamLeaderID
        Public Property TeamLeaderID() As Integer
            Get
                Return _teamleaderid
            End Get
            Set(ByVal Value As Integer)
                _teamleaderid = Value
            End Set
        End Property


        'Sectorid
        Public Property SectorID() As Integer
            Get
                Return _sectorid
            End Get
            Set(ByVal Value As Integer)
                _sectorid = Value
            End Set
        End Property

        'CityID
        Public Property CityID() As Integer
            Get
                Return _cityid
            End Get
            Set(ByVal Value As Integer)
                _cityid = Value
            End Set
        End Property

        Public Property TeamMemberIdList() As List(Of Integer)
            Get
                Return _teamMemberIdList
            End Get
            Set(ByVal value As List(Of Integer))
                _teamMemberIdList = value
            End Set
        End Property

        Public Property TeamLeader As User_UserInfo
            Get
                Return _teamLeader
            End Get
            Set(ByVal value As User_UserInfo)
                _teamLeader = value
            End Set
        End Property

        Public Property ParentTeamName As String
            Get
                Return _parentTeamName
            End Get
            Set(ByVal value As String)
                _parentTeamName = value
            End Set
        End Property

        Public Property City As String
            Get
                Return _city
            End Get
            Set(ByVal value As String)
                _city = value
            End Set
        End Property

        Public Property Sector As String
            Get
                Return _sector
            End Get
            Set(ByVal value As String)
                _sector = value
            End Set
        End Property

        Public Property RoleIdList As List(Of Integer)
            Get
                Return _roleIdList
            End Get
            Set(ByVal value As List(Of Integer))
                _roleIdList = value
            End Set
        End Property
    End Class
End Namespace
