Imports System
Imports System.Data
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic

Imports Telerik.Web.UI

Imports DataAccess.BLL
Imports DataAccess.Model
Partial Class Message_UserMessageList
    Inherits PageBase
    'Private DepartBLL As New Base_DepartmentBLL

    Private MessageBLL As New Base_MessageBLL
    Public LoginUserId As Integer = 2



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        GetMessageList()
        gridResult.Rebind()
        Throw New IndexOutOfRangeException("IndexOutOfRangeException")
    End Sub

    ''' <summary>
    ''' This is the command when user click delete.
    ''' </summary>
    ''' <param name="source">Pass the event source:datagrid.</param>
    ''' <param name="e">Pass the event args.</param>
    ''' <remarks></remarks>
    Protected Sub gridResult_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles gridResult.DeleteCommand
        Dim id As Integer = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("IDColumn").Text
        'MessageBLL.DeleteMessage(id)
        MessageBLL.DeleteEntity(id)
        GetMessageList()
    End Sub
    ''' <summary>
    ''' Item Data Bound event
    ''' </summary>
    ''' <param name="sender">Pass the event sender:grid.</param>
    ''' <param name="e">Pass the event args.</param>
    ''' <remarks></remarks>
    Protected Sub gridResult_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles gridResult.ItemDataBound

        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim id As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("IDColumn").Text
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("OpenColumn").Text = "<a href='#' onclick=javascript:ShowMessage('" + id + "') >Open</a>"
            Dim content = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("contentColumn").Text
            If content.Length > 30 Then
                content = content.Substring(0, 30) + "..."
            End If
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("contentColumn").Text = content

        End If
    End Sub
    ''' <summary>
    ''' This method is uese to get user message list and save the user list to viewstate.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetMessageList()
        If Session("LoginUserInfo") Is Nothing Then
            Return
        End If
        'Dim messageList As DataSet = MessageBLL.GetUserMessageList(LoginUserId)
        Dim filter As New MessageQueryFilter
        ' should change to login user id
        filter.UserId = CType(Session("LoginUserInfo"), User_UserInfo).ID
        filter.MessageContent = txtMessageContent.Text.Trim()
        filter.MessageFrom = txtMessageFrom.Text.Trim()
        'filter.MessageStatus = Me.ddlMessageStatus.SelectedItem.Value
        filter.MessageSubject = Me.txtMessageSubject.Text.Trim()
        filter.ReceiverMessageStatus = Me.ddlMessageStatus.SelectedItem.Value
        Dim messageList As DataSet = MessageBLL.GetMessageListByFilter(filter)
        ViewState("MessageList") = messageList
    End Sub

    ''' <summary>
    ''' This is event whey need datasource event firs.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub gridResult_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles gridResult.NeedDataSource
        'we will save userlist in viewstate
        If ViewState("MessageList") Is Nothing Then
            GetMessageList()
        End If
        'get datasource from viewstate instead of getting data from database.
        gridResult.DataSource = ViewState("MessageList")
    End Sub
End Class
