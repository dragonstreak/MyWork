Imports System.Collections.Generic

Namespace Model
    Public Class User_Role
        Private _id As Integer
        Private _rolename As String
        Private _status As Integer
        Private _remark As String
        Private _isDeleted As Boolean
        Private _permissionIDs As List(Of Integer)

        Public Sub New()
            _rolename = String.Empty
            _status = 0
            _remark = String.Empty
            _isDeleted = False
            _permissionIDs = New List(Of Integer)
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

        '½ÇÉ«Ãû³Æ
        Public Property RoleName() As String
            Get
                Return _rolename
            End Get
            Set(ByVal Value As String)
                _rolename = Value
            End Set
        End Property

        'Status
        Public Property Status() As Integer
            Get
                Return _status
            End Get
            Set(ByVal Value As Integer)
                _status = Value
            End Set
        End Property

        '±¸×¢
        Public Property Remark() As String
            Get
                Return _remark
            End Get
            Set(ByVal Value As String)
                _remark = Value
            End Set
        End Property

        Public Property IsDeleted() As Boolean
            Get
                Return _isDeleted
            End Get
            Set(ByVal value As Boolean)
                _isDeleted = value
            End Set
        End Property

        Public Property PermissionIDs As List(Of Integer)
            Get
                Return _permissionIDs
            End Get
            Set(ByVal value As List(Of Integer))
                _permissionIDs = value
            End Set
        End Property

    End Class
End Namespace
