
Namespace Model
    Public Class Base_PricingProjectStage
        Private _id As Integer
        Private _DepId As Integer
        Private _Stage As String
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

        'DepId
        Public Property DepId() As Integer
            Get
                Return _DepId
            End Get
            Set(ByVal Value As Integer)
                _DepId = Value
            End Set
        End Property

        'Stage
        Public Property Stage() As String
            Get
                Return _Stage
            End Get
            Set(ByVal Value As String)
                _Stage = Value
            End Set
        End Property

    End Class
End Namespace
