Namespace Model
    Public Class Base_ProDesignRecruitmentSelection
        Private _id As Integer
        Private _RecruitmentId As Integer
        Private _RecruitmentSelection As String
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

        'RecruitmentId ID
        Public Property RecruitmentId() As Integer
            Get
                Return _RecruitmentId
            End Get
            Set(ByVal Value As Integer)
                _RecruitmentId = Value
            End Set
        End Property


        'RecruitmentSelection
        Public Property RecruitmentSelection() As String
            Get
                Return _RecruitmentSelection
            End Get
            Set(ByVal Value As String)
                _RecruitmentSelection = Value
            End Set
        End Property

    End Class
End Namespace
