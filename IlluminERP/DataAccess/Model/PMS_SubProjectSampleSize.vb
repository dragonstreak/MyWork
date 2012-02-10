Namespace Model
    Public Class PMS_SubProjectSampleSize
        Private _id As Integer
        Private _SubProId As Integer
        Private _CityId As Integer
        Private _Samplesize As Decimal
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

        'City
        Public Property CityId() As Integer
            Get
                Return _CityId
            End Get
            Set(ByVal Value As Integer)
                _CityId = Value
            End Set
        End Property

        'Samplesize
        Public Property Samplesize() As Decimal
            Get
                Return _Samplesize
            End Get
            Set(ByVal Value As Decimal)
                _Samplesize = Value
            End Set
        End Property


        'Description
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
