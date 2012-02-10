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
   
    <System.SerializableAttribute()>  _
    Public Class PMS_Timing
        
        Private _Id As Integer
        
        Private _ProposalId As Integer
        
        Private _StageId As Integer
        
        Private _componentId As Integer
        
        Private _CreatedBy As Integer
        
        Private _CreatedDate As Date?
        
        Private _UpdatedBy As Integer
        
        Private _UpdatedDate As Date?
        
        Private _Task As String
        
        Private _StartDate As Date?
        
        Private _EndDate As Date?
        
        Private _TaskType As String
        
        Private _DayCount As Integer?
        
        Private _WeekCount As Decimal?
        
        Private _TaskOrder As Integer
        Private _Jobnumber As String
        Private _ComponentName As String
        Private _Status As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        'This is the property of Id
        <ColumnMapping("Id")>  _
        Public Property Id() As Integer
            Get
                Return Me._Id
            End Get
            Set
                Me._Id = value
            End Set
        End Property
        
        'This is the property of ProposalId
        <ColumnMapping("ProposalId")>  _
        Public Property ProposalId() As Integer
            Get
                Return Me._ProposalId
            End Get
            Set
                Me._ProposalId = value
            End Set
        End Property
        
        'This is the property of StageId
        <ColumnMapping("StageId")>  _
        Public Property StageId() As Integer
            Get
                Return Me._StageId
            End Get
            Set
                Me._StageId = value
            End Set
        End Property
        
        'This is the property of componentId
        <ColumnMapping("componentId")>  _
        Public Property componentId() As Integer
            Get
                Return Me._componentId
            End Get
            Set
                Me._componentId = value
            End Set
        End Property
        
        'This is the property of CreatedBy
        <ColumnMapping("CreatedBy")>  _
        Public Property CreatedBy() As Integer
            Get
                Return Me._CreatedBy
            End Get
            Set
                Me._CreatedBy = value
            End Set
        End Property
        
        'This is the property of CreatedDate
        <ColumnMapping("CreatedDate")> _
        Public Property CreatedDate() As Date?
            Get
                Return Me._CreatedDate
            End Get
            Set(ByVal value As Date?)
                Me._CreatedDate = Value
            End Set
        End Property
        
        'This is the property of UpdatedBy
        <ColumnMapping("UpdatedBy")>  _
        Public Property UpdatedBy() As Integer
            Get
                Return Me._UpdatedBy
            End Get
            Set
                Me._UpdatedBy = value
            End Set
        End Property
        
        'This is the property of UpdatedDate
        <ColumnMapping("UpdatedDate")> _
        Public Property UpdatedDate() As Date?
            Get
                Return Me._UpdatedDate
            End Get
            Set(ByVal value As Date?)
                Me._UpdatedDate = Value
            End Set
        End Property
        
        'This is the property of Task
        <ColumnMapping("Task")>  _
        Public Property Task() As String
            Get
                Return Me._Task
            End Get
            Set
                Me._Task = value
            End Set
        End Property
        
        'This is the property of StartDate
        <ColumnMapping("StartDate")> _
        Public Property StartDate() As Date?
            Get
                Return Me._StartDate
            End Get
            Set(ByVal value As Date?)
                Me._StartDate = Value
            End Set
        End Property
        
        'This is the property of EndDate
        <ColumnMapping("EndDate")> _
        Public Property EndDate() As Date?
            Get
                Return Me._EndDate
            End Get
            Set(ByVal value As Date?)
                Me._EndDate = Value
            End Set
        End Property
        
        'This is the property of QuotationType
        <ColumnMapping("TaskType")> _
        Public Property TaskType() As String
            Get
                Return Me._TaskType
            End Get
            Set(ByVal value As String)
                Me._TaskType = value
            End Set
        End Property
        
        'This is the property of DayCount
        <ColumnMapping("DayCount")> _
        Public Property DayCount() As Integer?
            Get
                Return Me._DayCount
            End Get
            Set(ByVal value As Integer?)
                Me._DayCount = Value
            End Set
        End Property
        
        'This is the property of WeekCount
        <ColumnMapping("WeekCount")> _
        Public Property WeekCount() As Decimal?
            Get
                Return Me._WeekCount
            End Get
            Set(ByVal value As Decimal?)
                Me._WeekCount = Value
            End Set
        End Property
        
        'This is the property of TaskOrder
        <ColumnMapping("TaskOrder")>  _
        Public Property TaskOrder() As Integer
            Get
                Return Me._TaskOrder
            End Get
            Set
                Me._TaskOrder = value
            End Set
        End Property
        'This property only for view
        Private _StageName As String
        <ColumnMapping("StageName")> _
        Public Property StageName() As String
            Get
                Return Me._StageName
            End Get
            Set(ByVal value As String)
                Me._StageName = value
            End Set
        End Property
        Private _StageNumber As String
        <ColumnMapping("StageNumber")> _
        Public Property StageNumber() As String
            Get
                Return Me._StageNumber
            End Get
            Set(ByVal value As String)
                Me._StageNumber = value
            End Set
        End Property
        'This is the property of Jobnumber
        <ColumnMapping("Jobnumber")> _
        Public Property Jobnumber() As String
            Get
                Return Me._Jobnumber
            End Get
            Set(ByVal value As String)
                Me._Jobnumber = value
            End Set
        End Property
        <ColumnMapping("Status")> _
        Public Property Status() As String
            Get
                Return Me._Status
            End Get
            Set(ByVal value As String)
                Me._Status = value
            End Set
        End Property
        <ColumnMapping("ComponentName")> _
        Public Property ComponentName() As String
            Get
                Return Me._ComponentName
            End Get
            Set(ByVal value As String)
                Me._ComponentName = value
            End Set
        End Property
    End Class
End Namespace