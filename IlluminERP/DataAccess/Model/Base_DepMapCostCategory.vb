
Namespace Model
    Public Class Base_DepMapCostCategory
        Private _id As Integer
        Private _depId As Integer
        Private _costId As Integer

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

        Public Property DepId() As Integer
            Get
                Return _depId
            End Get
            Set(ByVal Value As Integer)
                _depId = Value
            End Set
        End Property

        Public Property CostId() As Integer
            Get
                Return _costId
            End Get
            Set(ByVal Value As Integer)
                _costId = Value
            End Set
        End Property


    End Class
End Namespace
