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
    Public Class Base_Message
        
        Private _id As Integer
        
        Private _message_content As String
        
        Private _message_subject As String
        
        Private _message_sender_id As Integer
        
        Private _message_sender As String
        
        Private _message_status As Integer
        
        Private _message_time As DateTime
        
        Private _message_type As String

        Private _message_receivers As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        'This is the property of id
        <ColumnMapping("ID", True)>
        Public Property id() As Integer
            Get
                Return Me._id
            End Get
            Set(ByVal value As Integer)
                Me._id = value
            End Set
        End Property
        
        'This is the property of message_content
        <ColumnMapping("message_content")>
        Public Property message_content() As String
            Get
                Return Me._message_content
            End Get
            Set(ByVal value As String)
                Me._message_content = value
            End Set
        End Property
        
        'This is the property of message_subject
        <ColumnMapping("message_subject")>
        Public Property message_subject() As String
            Get
                Return Me._message_subject
            End Get
            Set(ByVal value As String)
                Me._message_subject = Value
            End Set
        End Property
        
        'This is the property of message_sender_id
        <ColumnMapping("message_sender_id")>
        Public Property message_sender_id() As Integer
            Get
                Return Me._message_sender_id
            End Get
            Set(ByVal value As Integer)
                Me._message_sender_id = Value
            End Set
        End Property
        
        'This is the property of message_sender
        <ColumnMapping("message_sender")>
        Public Property message_sender() As String
            Get
                Return Me._message_sender
            End Get
            Set(ByVal value As String)
                Me._message_sender = value
            End Set
        End Property
        
        'This is the property of message_status
        '0 means read
        '1 means unread-unremind
        '2 means unread-remined
        <ColumnMapping("message_status")>
        Public Property message_status() As Integer
            Get
                Return Me._message_status
            End Get
            Set(ByVal value As Integer)
                Me._message_status = Value
            End Set
        End Property
        
        'This is the property of message_time
        <ColumnMapping("message_time")>
        Public Property message_time() As DateTime
            Get
                Return Me._message_time
            End Get
            Set(ByVal value As DateTime)
                Me._message_time = value
            End Set
        End Property

        
        'This is the property of message_type
        <ColumnMapping("message_type")>
        Public Property message_type() As String
            Get
                Return Me._message_type
            End Get
            Set(ByVal value As String)
                Me._message_type = Value
            End Set
        End Property
        'This is the property of message_receivers
        <ColumnMapping("message_receivers")>
        Public Property message_receivers() As String
            Get
                Return Me._message_receivers
            End Get
            Set(ByVal value As String)
                Me._message_receivers = value
            End Set
        End Property
        Private receiverList As New List(Of Base_MessageReceiver)
        Public Property ReceiversList() As List(Of Base_MessageReceiver)
            Get
                Return Me.receiverList
            End Get
            Set(ByVal value As List(Of Base_MessageReceiver))
                receiverList = value
            End Set
        End Property
        Private _messageShowTime As String
        Public Property MessageShowTime() As String
            Get
               
                Return message_time.ToString
            End Get
            Set(ByVal value As String)
                _messageShowTime = value
            End Set
        End Property
    End Class
End Namespace
