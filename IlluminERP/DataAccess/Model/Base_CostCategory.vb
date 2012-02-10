Namespace Model
    Public Class Base_CostCategory
        Private _id As Integer
        Private _Code As String
        Private _CostCategoryEn As String
        Private _CostCategoryCN As String
        Private _Description As String


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


        'Code
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal Value As String)
                _Code = Value
            End Set
        End Property

        'CostCategoryEn
        Public Property CostCategoryEn() As String
            Get
                Return _CostCategoryEn
            End Get
            Set(ByVal Value As String)
                _CostCategoryEn = Value
            End Set
        End Property

        'CostCategoryCN
        Public Property CostCategoryCN() As String
            Get
                Return _CostCategoryCN
            End Get
            Set(ByVal Value As String)
                _CostCategoryCN = Value
            End Set
        End Property

        'Code
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
