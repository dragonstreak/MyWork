
Namespace Model

    Public Class Client_ClientUploadFile
        Private _Id As Integer
        Private _ClientId As Integer
        Private _FileTypeId As Integer
        Private _FileName As String
        Private _FilePath As String

        Public Sub New()
            _Id = 0
            _ClientId = 0
            _FileName = String.Empty
            _FileTypeId = 0
            _FilePath = String.Empty

        End Sub

        'Id
        Public Property Id() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal Value As Integer)
                _Id = Value
            End Set
        End Property


        'ClientId
        Public Property ClientId() As Integer
            Get
                Return _ClientId
            End Get
            Set(ByVal Value As Integer)
                _ClientId = Value
            End Set
        End Property

        'FileTypeId
        Public Property FileTypeId() As Integer
            Get
                Return _FileTypeId
            End Get
            Set(ByVal Value As Integer)
                _FileTypeId = Value
            End Set
        End Property

        'FileName
        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal Value As String)
                _FileName = Value
            End Set
        End Property

        'FileName
        Public Property FilePath() As String
            Get
                Return _FilePath
            End Get
            Set(ByVal Value As String)
                _FilePath = Value
            End Set
        End Property
    End Class
End Namespace

