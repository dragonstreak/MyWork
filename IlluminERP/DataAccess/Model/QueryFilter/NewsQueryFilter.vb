Imports Utils

Namespace Model
    Public Class NewsQueryFilter
        Private _title As String
        Private _type As Integer
        Private _severity As Integer
        Private _resultAmountLimit As Integer
        Private _publishType As Integer

        Public Sub New()
            _title = String.Empty
            _type = -1
            _severity = -1
            _resultAmountLimit = -1
            _publishType = -1
        End Sub

        <Filter("News.Title", "@Title", "", MatchType.Likes)>
        Public Property Title As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                _title = value
            End Set
        End Property

        <Filter("News.NewsType", "@NewsType", "", "-1", ColumnType.IntColumn, MatchType.Equals)>
        Public Property NewsType As Integer
            Get
                Return _type
            End Get
            Set(ByVal value As Integer)
                _type = value
            End Set
        End Property

        <Filter("News.SeverityLevel", "@SeverityLevel", "", "-1", ColumnType.IntColumn, MatchType.Equals)>
        Public Property SeverityLevel As Integer
            Get
                Return _severity
            End Get
            Set(ByVal value As Integer)
                _severity = value
            End Set
        End Property

        <Filter("News.Published", "@Published", "", "-1", ColumnType.IntColumn, MatchType.Equals)>
        Public Property PublishedType As Integer
            Get
                Return _publishType
            End Get
            Set(ByVal value As Integer)
                _publishType = value
            End Set
        End Property

        Public Property ResultAmountLimit As Integer
            Get
                Return _resultAmountLimit
            End Get
            Set(ByVal value As Integer)
                _resultAmountLimit = value
            End Set
        End Property
    End Class
End Namespace

