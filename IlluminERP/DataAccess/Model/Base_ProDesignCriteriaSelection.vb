Namespace Model
    Public Class Base_ProDesignCriteriaSelection
        Private _id As Integer
        Private _CriteriaId As Integer
        Private _CriteriaSelection As String
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

        'CriteriaId ID
        Public Property CriteriaId() As Integer
            Get
                Return _CriteriaId
            End Get
            Set(ByVal Value As Integer)
                _CriteriaId = Value
            End Set
        End Property


        'CriteriaSelection
        Public Property CriteriaSelection() As String
            Get
                Return _CriteriaSelection
            End Get
            Set(ByVal Value As String)
                _CriteriaSelection = Value
            End Set
        End Property

    End Class

End Namespace
