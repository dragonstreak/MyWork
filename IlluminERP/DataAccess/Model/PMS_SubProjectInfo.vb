

Imports System
Namespace Model
    Public Class PMS_SubProjectInfo
        Private _id As Integer
        Private _ProId As Integer
        Private _SubJobNumber As String
        Private _MethodologyType As Integer
        Private _MethodologyId As Integer
        Private _Description As String
        Private _Status As Integer

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

        'ProId
        Public Property ProId() As Integer
            Get
                Return _ProId
            End Get
            Set(ByVal Value As Integer)
                _ProId = Value
            End Set
        End Property

        '_SubJobNumber
        Public Property SubJobNumber() As String
            Get
                Return _SubJobNumber
            End Get
            Set(ByVal Value As String)
                _SubJobNumber = Value
            End Set
        End Property

        'MethdologyId
        Public Property MethodologyId() As Integer
            Get
                Return _MethodologyId
            End Get
            Set(ByVal Value As Integer)
                _MethodologyId = Value
            End Set
        End Property

        'MethodologyType
        Public Property MethodologyType() As Integer
            Get
                Return _MethodologyType
            End Get
            Set(ByVal Value As Integer)
                _MethodologyType = Value
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

        'Status
        Public Property Status() As Integer
            Get
                Return _Status
            End Get
            Set(ByVal Value As Integer)
                _Status = Value
            End Set
        End Property

    End Class
End Namespace
