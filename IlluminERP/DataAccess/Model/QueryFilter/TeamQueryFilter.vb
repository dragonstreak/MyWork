Namespace Model
    Public Class TeamQueryFilter
        Private _parentid As Integer
        Private _teamname As String
        Private _cityid As Integer
        Private _sectorid As Integer

        'TeamName
        Public Property TeamName() As String
            Get
                Return _teamname
            End Get
            Set(ByVal Value As String)
                _teamname = Value
            End Set
        End Property


        '父节点
        Public Property ParentID() As Integer
            Get
                Return _parentid
            End Get
            Set(ByVal Value As Integer)
                _parentid = Value
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


        Public Sub New()
            _teamname = String.Empty
            _parentid = 0
            _cityid = 0
            _sectorid = 0
        End Sub
        Public Sub New(ByVal sTeamName As String, ByVal iParentId As Integer, ByVal iCityId As Integer, ByVal iSectorid As Integer)
            _teamname = sTeamName
            _parentid = iParentId
            _cityid = iCityId
            _sectorid = iSectorid
        End Sub

    End Class
End Namespace

