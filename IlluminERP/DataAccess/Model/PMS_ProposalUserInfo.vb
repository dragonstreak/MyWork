
Imports System

Namespace Model
    Public Class PMS_ProposalUserInfo
        Private _id As Integer
        Private _ProId As Integer
        Private _UserId As Integer
        Private _ProposalUserTypeId As Integer

        Public Sub New()
            _id = 0
            _ProId = 0
            _UserId = 0
            _ProposalUserTypeId = 0

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

        'ProId
        Public Property ProId() As Integer
            Get
                Return _ProId
            End Get
            Set(ByVal Value As Integer)
                _ProId = Value
            End Set
        End Property


        'UserId
        Public Property UserId() As Integer
            Get
                Return _UserId
            End Get
            Set(ByVal Value As Integer)
                _UserId = Value
            End Set
        End Property

        'ProposalUserTypeId
        Public Property ProposalUserTypeId() As Integer
            Get
                Return _ProposalUserTypeId
            End Get
            Set(ByVal Value As Integer)
                _ProposalUserTypeId = Value
            End Set
        End Property

    End Class
End Namespace