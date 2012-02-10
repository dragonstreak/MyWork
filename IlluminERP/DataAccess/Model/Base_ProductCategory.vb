
Namespace Model
    Public Class Base_ProductCategory
        Private _id As Integer
        Private _sectorid As Integer
        Private _productcategory As String

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

        'Sector ID
        Public Property SectorId() As Integer
            Get
                Return _sectorid
            End Get
            Set(ByVal Value As Integer)
                _sectorid = Value
            End Set
        End Property


        'Product Category
        Public Property ProductCategory() As String
            Get
                Return _productcategory
            End Get
            Set(ByVal Value As String)
                _productcategory = Value
            End Set
        End Property


    End Class
End Namespace
