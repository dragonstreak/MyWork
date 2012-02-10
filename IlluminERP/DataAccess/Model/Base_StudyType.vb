
Namespace Model
    Public Class Base_StudyType
        Private _id As Integer
        Private _StudyType As String


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



        '_studytype
        Public Property StudyType() As String
            Get
                Return _StudyType
            End Get
            Set(ByVal Value As String)
                _StudyType = Value
            End Set
        End Property

    End Class


End Namespace

