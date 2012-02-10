
Namespace Model
    Public Class PMS_ProDesginCriteria
        Private _id As Integer
        Private _SubProId As Integer
        Private _CeriteriaSelectionId As Integer
        Private _Description As String
    

        Public Sub New()

        End Sub

        'Id
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal Value As Integer)
                _id = Value
            End Set
        End Property

        'SubProId
        Public Property SubProId() As Integer
            Get
                Return _SubProId
            End Get
            Set(ByVal Value As Integer)
                _SubProId = Value
            End Set
        End Property

        'CeriteriaId
        Public Property CeriteriaSelectionId() As Integer
            Get
                Return _CeriteriaSelectionId
            End Get
            Set(ByVal Value As Integer)
                _CeriteriaSelectionId = Value
            End Set
        End Property

        '_Description
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property

    End Class

End Namespace
