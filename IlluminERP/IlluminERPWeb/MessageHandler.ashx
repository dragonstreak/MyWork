<%@ WebHandler Language="VB" Class="MessageHandler" %>

Imports System
Imports System.Web
Imports Newtonsoft.Json
Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports System.Web.SessionState

Public Class MessageHandler : Implements IHttpHandler, IRequiresSessionState  
    
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        Dim operation As String = context.Request.QueryString("operation")
        Select Case operation
            Case "GetUnremindMessage"
                'Dim userId As Integer  = context.Request.QueryString("userid")
                GetUnremindMessage(context)
            Case "GetUserList"
                GetUserList(context)
            Case "SendMessage"
                SendMessage(context)
            Case "GetMessageById"
                GetMessageById(context)
            Case "SetReceiverMessageReaded"
                SetReceiverMessageReaded(context)
        End Select
        
            
        'GetMessageById(context, 1)
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
#Region "Function match the operation"
    Private Sub GetMessageById(ByVal context As HttpContext)
        Dim id As Integer = CInt(context.Request.QueryString("id"))
        Dim json As String = ""
        Dim messageBLL As New Base_MessageBLL
        Dim message As New Base_Message
        Dim ds As DataSet = messageBLL.GetEntityById(id)
       
        If (ds.Tables.Count > 0 And ds.Tables(0).Rows.Count > 0) Then
            message.message_content = ds.Tables(0).Rows(0)("message_content").ToString()
            message.message_sender = ds.Tables(0).Rows(0)("message_sender").ToString()
            message.message_sender_id = ds.Tables(0).Rows(0)("message_sender_id")
            message.message_status = ds.Tables(0).Rows(0)("message_status")
            message.message_subject = ds.Tables(0).Rows(0)("message_subject").ToString()
            message.message_time = Convert.ToDateTime(ds.Tables(0).Rows(0)("message_time"))
            message.MessageShowTime = message.message_time.ToLongTimeString()
            message.message_type = ds.Tables(0).Rows(0)("message_type")
            message.message_receivers = ds.Tables(0).Rows(0)("message_receivers").ToString()
            
            message.id = ds.Tables(0).Rows(0)("id").ToString()
            If (ds.Tables.Count > 1 And ds.Tables(1).Rows.Count > 0) Then
                Dim receiver As New Base_MessageReceiver
                receiver.message_receiver_id = ds.Tables(1).Rows(0)("message_receiver_id")
                message.ReceiversList.Add(receiver)
                
            End If
        End If
            
        
        json = "{totalPorperty:0,root:" + JsonConvert.SerializeObject(message) + "}"
        context.Response.Write(json)
        context.Response.End()
    End Sub
    Private Sub GetUnremindMessage(ByVal context As HttpContext)
        Dim json As String = ""
        If context.Session("LoginUserInfo") Is Nothing Then
            json = "{total:0}"
        Else
            
       
            Dim userId As Integer = CType(context.Session("LoginUserInfo"), User_UserInfo).ID
        
            'If Session("LoginUserInfo") Is Nothing Then
        
            Dim messageBLL As New Base_MessageBLL
            Dim messageList As DataSet
            messageList = messageBLL.GetUnremindMessage(userId)
        
        
            If messageList.Tables.Count > 0 And messageList.Tables(0).Rows.Count > 0 Then
                Dim unRemindMessageList As New List(Of Base_Message)
                For Each row As DataRow In messageList.Tables(0).Rows
                    Dim message As New Base_Message
                    message.message_content = row("message_content").ToString()
                    message.message_sender = row("message_sender").ToString()
                    message.message_sender_id = row("message_sender_id")
                    message.message_status = row("message_status")
                    message.message_subject = row("message_subject").ToString()
                    message.message_time = Convert.ToDateTime(row("message_time"))
                    message.MessageShowTime = message.message_time.ToLongTimeString()
                    message.message_type = row("message_type")
                    message.message_receivers = row("message_receivers").ToString()
                    message.id = row("id")
                    unRemindMessageList.Add(message)
                Next
           
                json = "{total:" + messageList.Tables(0).Rows.Count.ToString + ",root:" + JsonConvert.SerializeObject(unRemindMessageList) + "}"
            Else
                json = "{total:0}"
            End If
        End If
        
            context.Response.Write(json)
            context.Response.End()
    End Sub
#End Region
    
    Private Sub GetUserList(ByVal context As HttpContext)
        Dim UserBLL As New UserInfoBLL
        Dim userTable As DataTable = UserBLL.GetAllUser()
        Dim json = ""
        If userTable Is Nothing Or userTable.Rows.Count = 0 Then
            json = "{totalPorperty:0}"
        Else
            
            Dim userList As New List(Of User_UserInfo)
            
            For Each userRow As DataRow In userTable.Rows
                Dim user As New User_UserInfo
                user.ID = userRow("ID")
                user.E_Name = userRow("E_NAME")
                user.C_Name = userRow("C_NAME")
                user.Code = userRow("CODE")
                userList.Add(user)
            Next
            
            json = "{totalPorperty:" + userList.Count.ToString + ",root:" + JsonConvert.SerializeObject(userList) + "}"
            
        End If
        context.Response.Write(json)
        context.Response.End()
    End Sub

    Private Sub SendMessage(ByVal context As HttpContext)
        Dim json As String = ""
        If context.Session("LoginUserInfo") Is Nothing Then
            json = "{totalProperty:0}"
        Else
            Dim messageBLL As New Base_MessageBLL
            Dim message As New Base_Message
            message.id = 0
            message.message_content = HttpUtility.UrlDecode(context.Request.Form("content"))
            message.message_receivers = context.Request.Form("receivers")
            message.message_sender = context.Request.Form("sender")
            'message.message_sender_id = context.Request.Form("senderId")
            message.message_sender = CType(context.Session("LoginUserInfo"), User_UserInfo).E_Name
            message.message_sender_id=CType(context.Session("LoginUserInfo"),User_UserInfo).ID 
            message.message_status = 1
            message.message_subject = context.Request.Form("subject")
            message.message_type = context.Request.Form("type")
            message.message_time = Date.Now
            Dim receiverIds = context.Request.Form("receiverIds")
            Dim receiverIdArr As String() = receiverIds.Split(CChar(";"))
            For Each receiverId As String In receiverIdArr
                Dim receiver As New Base_MessageReceiver
                receiver.id = 0
                receiver.message_id = 0
                receiver.message_receiver_id = receiverId
                receiver.message_receiver_name = ""
                message.ReceiversList.Add(receiver)
            Next
            Dim count As Integer = messageBLL.SaveMessage(message)
            json = "{totalProperty:" + count.ToString + "}"
        End If
        context.Response.Write(json)
        context.Response.End()
        'messageBLL.SaveMessage
    End Sub

    Private Sub SetReceiverMessageReaded(ByVal context As HttpContext)
        Dim json = "{totalPorperty:0}"
        If context.Session("LoginUserInfo") Is Nothing Then
            context.Response.Write(json)
            context.Response.End()
            Return
        End If
      
        Dim messageBLL As New Base_MessageBLL
        Dim messageId As Integer  = context.Request.Form("messageId")
        Dim receiverId As Integer = CType(context.Session("LoginUserInfo"), User_UserInfo).ID
        messageBLL.SetReceiverMessageReaded(receiverId,messageId)
        context.Response.Write(json)
        context.Response.End()
    End Sub
    
    

End Class