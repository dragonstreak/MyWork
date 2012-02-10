Namespace Model

    Public Class Base_ProjectType
        Private _id As Integer
        Private _projecttype As String

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



        'ProjectType
        Public Property ProjectType() As String
            Get
                Return _projecttype
            End Get
            Set(ByVal Value As String)
                _projecttype = Value
            End Set
        End Property
    End Class
End Namespace
