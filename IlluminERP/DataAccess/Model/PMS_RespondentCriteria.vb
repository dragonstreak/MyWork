'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.225
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports Utils

Namespace Model
    
    <System.SerializableAttribute()> _
    Public Class PMS_RespondentCriteria
        Inherits AbstractEntity

        Private _id As Integer

        Private _ComponentId As Integer

        Private _Criteria As String

        Public Sub New()
            MyBase.New()
            _id = -1
            abstractEntityStatus = EntityStatus.Added
        End Sub

        'This is the property of id
        <ColumnMapping("id")> _
        Public Property id() As Integer
            Get
                Return Me._id
            End Get
            Set(ByVal value As Integer)
                Me._id = Value
            End Set
        End Property

        'This is the property of ComponentId
        <ColumnMapping("ComponentId")> _
        Public Property ComponentId() As Integer
            Get
                Return Me._ComponentId
            End Get
            Set(ByVal value As Integer)
                Me._ComponentId = Value
            End Set
        End Property

        'This is the property of Criteria
        <ColumnMapping("Criteria")> _
        Public Property Criteria() As String
            Get
                Return Me._Criteria
            End Get
            Set(ByVal value As String)
                Me._Criteria = Value
            End Set
        End Property
    End Class
End Namespace
