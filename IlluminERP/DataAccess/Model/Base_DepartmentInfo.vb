
Namespace Model

    Public Class Base_DepartmentInfo
        Private _id As Integer
        Private _Department As String
    
         

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


        'Depatement
        Public Property Department() As String
            Get
                Return _Department
            End Get
            Set(ByVal Value As String)
                _Department = Value
            End Set
        End Property


    End Class

End Namespace
