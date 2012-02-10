Imports Utils

Namespace Model
    Public Class ListItemQueryFilter
        Private _content As String
        Private _type As Integer

        Public Sub New()
            _content = String.Empty
            _type = -1
        End Sub

        <Filter("ListItem.ContentText", "@ContentText", "", MatchType.Likes)>
        Public Property Content As String
            Get
                Return _content
            End Get
            Set(ByVal value As String)
                _content = value
            End Set
        End Property

        <Filter("ListItem.Type", "@Type", "", "-1", ColumnType.IntColumn, MatchType.Equals)>
        Public Property Type As Integer
            Get
                Return _type
            End Get
            Set(ByVal value As Integer)
                _type = value
            End Set
        End Property

    End Class
End Namespace

