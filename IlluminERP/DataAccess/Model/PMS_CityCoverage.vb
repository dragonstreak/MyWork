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
    Public Class PMS_CityCoverage
        Inherits AbstractEntity

        Private _id As Integer

        Private _ComponentId As Integer

        Private _District As Integer

        Private _Province As Integer

        Private _City As Integer

        Private _CitySize As Decimal

        Private _AddedSize As Decimal

        Private _IncidenceRate As Integer

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

        'This is the property of District
        <ColumnMapping("District")> _
        Public Property District() As Integer
            Get
                Return Me._District
            End Get
            Set(ByVal value As Integer)
                Me._District = Value
            End Set
        End Property

        'This is the property of Province
        <ColumnMapping("Province")> _
        Public Property Province() As Integer
            Get
                Return Me._Province
            End Get
            Set(ByVal value As Integer)
                Me._Province = Value
            End Set
        End Property

        'This is the property of City
        <ColumnMapping("City")> _
        Public Property City() As Integer
            Get
                Return Me._City
            End Get
            Set(ByVal value As Integer)
                Me._City = Value
            End Set
        End Property

        'This is the property of CitySize
        <ColumnMapping("CitySize")> _
        Public Property CitySize() As Decimal
            Get
                Return Me._CitySize
            End Get
            Set(ByVal value As Decimal)
                Me._CitySize = Value
            End Set
        End Property

        'This is the property of AddedSize
        <ColumnMapping("AddedSize")> _
        Public Property AddedSize() As Decimal
            Get
                Return Me._AddedSize
            End Get
            Set(ByVal value As Decimal)
                Me._AddedSize = Value
            End Set
        End Property

        'This is the property of IncidenceRate
        <ColumnMapping("IncidenceRate")> _
        Public Property IncidenceRate() As Integer
            Get
                Return Me._IncidenceRate
            End Get
            Set(ByVal value As Integer)
                Me._IncidenceRate = Value
            End Set
        End Property
    End Class
End Namespace
