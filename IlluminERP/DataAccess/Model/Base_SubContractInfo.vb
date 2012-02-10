Namespace Model
    Public Class Base_SubContractInfo
        Private _id As Integer
        Private _S_City As String
        Private _S_Name As String

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


        'S_City
        Public Property S_City() As String
            Get
                Return _S_City
            End Get
            Set(ByVal Value As String)
                _S_City = Value
            End Set
        End Property

        'S_Name
        Public Property S_Name() As String
            Get
                Return _S_Name
            End Get
            Set(ByVal Value As String)
                _S_Name = Value
            End Set
        End Property


    End Class

End Namespace