Imports Utils
Namespace Model
    Public Class MessageQueryFilter
        Public Sub New()
        End Sub
        Private _content As String
        <Filter("t_Base_Message.message_content", "@message_content", "", MatchType.Likes)>
        Public Property MessageContent() As String
            Get
                Return _content
            End Get
            Set(ByVal Value As String)
                _content = Value
            End Set
        End Property
        Private _from As String
        <Filter("t_Base_Message.Message_sender", "@message_sender", "", MatchType.Likes)>
        Public Property MessageFrom() As String
            Get
                Return _from
            End Get
            Set(ByVal Value As String)
                _from = Value
            End Set
        End Property
        Private _subject As String
        <Filter("t_Base_Message.Message_subject", "@message_subject", "", MatchType.Likes)>
        Public Property MessageSubject() As String
            Get
                Return _subject
            End Get
            Set(ByVal value As String)
                _subject = value
            End Set
        End Property
        Private _to As String

        Public Property MessageTo() As String
            Get
                Return _to
            End Get
            Set(ByVal value As String)
                _to = value
            End Set
        End Property
        Private _UserId As Integer?

        Public Property UserId As Integer?
            Get
                Return _UserId
            End Get
            Set(ByVal value As Integer?)
                _UserId = value
            End Set
        End Property
        Private _status As String
        '<Filter("t_Base_Message.message_status", "@message_stasut", "", "-1", ColumnType.IntColumn, MatchType.Equals)>
        Public Property MessageStatus As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                _status = value
            End Set
        End Property
        Private _receiverMessageStatus As String
        ''' <summary>
        ''' This is the filter for getting message by status.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ReceiverMessageStatus As String
            Get
                Return _receiverMessageStatus
            End Get
            Set(ByVal value As String)
                _receiverMessageStatus = value
            End Set
        End Property
    End Class
End Namespace

