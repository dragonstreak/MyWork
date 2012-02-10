Namespace Model
    Public Class Base_MBPAnswer
        Private _id As Integer
        Private _MBPQuestionId As Integer
        Private _Answer As String
        Private _Value As Decimal

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


        'MBPQuestionId
        Public Property MBPQuestionId() As Integer
            Get
                Return _MBPQuestionId
            End Get
            Set(ByVal Value As Integer)
                _MBPQuestionId = Value
            End Set
        End Property

        'Answer
        Public Property Answer() As String
            Get
                Return _Answer
            End Get
            Set(ByVal Value As String)
                _Answer = Value
            End Set
        End Property

        'Value
        Public Property Value() As String
            Get
                Return _Value
            End Get
            Set(ByVal Value As String)
                _Value = Value
            End Set
        End Property

    End Class
End Namespace
