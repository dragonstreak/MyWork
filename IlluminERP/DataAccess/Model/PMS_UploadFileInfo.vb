
Namespace Model
    Public Class PMS_UploadFileInfo
        Private _id As Integer
        Private _ProId As Integer
        Private _FileName As String
        Private _FileFolder As String
        Private _FileType As Integer

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


        '_ProId
        Public Property ProId() As Integer
            Get
                Return _ProId
            End Get
            Set(ByVal Value As Integer)
                _ProId = Value
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

        'FileFolder
        Public Property FileFolder() As String
            Get
                Return _FileFolder
            End Get
            Set(ByVal Value As String)
                _FileFolder = Value
            End Set
        End Property

        '_Filetype
        Public Property FileType() As Integer
            Get
                Return _FileType
            End Get
            Set(ByVal Value As Integer)
                _FileType = Value
            End Set
        End Property

    End Class
End Namespace
