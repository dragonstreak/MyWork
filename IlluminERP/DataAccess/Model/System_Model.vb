
Namespace Model
    Public Class System_Model
        Private _id As Integer
        Private _parentid As Integer
        Private _code As String
        Private _level As Integer
        Private _modelname As String
        Private _status As Integer
        Private _linkpage As String

        Public Sub New()

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


        'parentID
        Public Property ParentID() As Integer
            Get
                Return _parentid
            End Get
            Set(ByVal Value As Integer)
                _parentid = Value
            End Set
        End Property

        '编号
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal Value As String)
                _code = Value
            End Set
        End Property

        'level
        Public Property Level() As Integer
            Get
                Return _level
            End Get
            Set(ByVal Value As Integer)
                _level = Value
            End Set
        End Property

        '模块名称
        Public Property ModelName() As String
            Get
                Return _modelname
            End Get
            Set(ByVal Value As String)
                _modelname = Value
            End Set
        End Property

        'status
        Public Property Status() As Integer
            Get
                Return _status
            End Get
            Set(ByVal Value As Integer)
                _status = Value
            End Set
        End Property

        '链接页面
        Public Property Linkpage() As String
            Get
                Return _linkpage
            End Get
            Set(ByVal Value As String)
                _linkpage = Value
            End Set
        End Property

    End Class
End Namespace
