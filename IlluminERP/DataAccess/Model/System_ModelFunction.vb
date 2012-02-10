
Namespace Model
    Public Class System_ModelFunction
        Private _id As Integer
        Private _code As String
        Private _systemModelId As Integer
        Private _modelFunction As String
        Private _description As String


        Public Sub New()
            _code = String.Empty
            _modelFunction = String.Empty
            _description = String.Empty

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

        '编号
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal Value As String)
                _code = Value
            End Set
        End Property


        'SystemModelID
        Public Property SystemModelID() As Integer
            Get
                Return _systemModelId
            End Get
            Set(ByVal Value As Integer)
                _systemModelId = Value
            End Set
        End Property

        '模块功能
        Public Property ModelFunction() As String
            Get
                Return _modelFunction
            End Get
            Set(ByVal Value As String)
                _modelFunction = Value
            End Set
        End Property

        '功能模块描述
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property


    End Class
End Namespace
