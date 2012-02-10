Namespace Model
    Public Class Base_ClientUploadFileType
        Private _id As Integer
        Private _ClientFileType As String

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


        '_ClientFileType 文件上传类型
        Public Property ClientFileType() As String
            Get
                Return _ClientFileType
            End Get
            Set(ByVal Value As String)
                _ClientFileType = Value
            End Set
        End Property
    End Class
End Namespace
