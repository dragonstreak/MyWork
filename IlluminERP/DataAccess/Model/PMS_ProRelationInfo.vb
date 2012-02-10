Namespace Model
    Public Class PMS_ProRelationInfo
        Private _id As Integer
        Private _ProId As Integer
        Private _RelationType As String
        Private _RelationProId As Integer

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

        Public Property RelationType() As String
            Get
                Return _RelationType
            End Get
            Set(ByVal Value As String)
                _RelationType = Value
            End Set
        End Property

        Public Property RelationProId() As Integer
            Get
                Return _RelationProId
            End Get
            Set(ByVal Value As Integer)
                _RelationProId = Value
            End Set
        End Property


    End Class
End Namespace

