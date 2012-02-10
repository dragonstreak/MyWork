
Namespace Model
    Public Class PMS_UploadFileType
        Private _id As Integer
        Private _FileType As String
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



        'FileType
        Public Property FileType() As String
            Get
                Return _FileType
            End Get
            Set(ByVal Value As String)
                _FileType = Value
            End Set
        End Property
    End Class
End Namespace

