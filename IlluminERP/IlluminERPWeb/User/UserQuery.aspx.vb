Imports System
Imports System.Data
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic

Imports Telerik.Web.UI

Imports DataAccess.BLL
Imports DataAccess.Model



Partial Class UserQuery
    Inherits PageBase
    'Inherits System.Web.UI.Page

    Private DepartBLL As New Base_DepartmentBLL
    Private UserBLL As New UserInfoBLL
    Private CityBLL As New Base_CityInfoBLL
    Private PosBLL As New Base_PositionInfoBLL
    Private userQueryFilter As New UserQueryFilter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitPageSetting()
        End If
    End Sub
    ''' <summary>
    ''' This is the method to init the page, set the dropdownlist.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub InitPageSetting()
        Dim ds As DataSet
        

        ds = PosBLL.GetPositionInfo
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.ddlPosition, ds, "ID", "Position", 1)
        End If

     


    End Sub
    ''' <summary>
    ''' This is the query click event,
    ''' when user click the query button
    ''' the user list will be fetch by user query filter.
    ''' </summary>
    ''' <param name="sender">Pass the event sender:button.</param>
    ''' <param name="e">Pass the event args.</param>
    ''' <remarks></remarks>
    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
       
        GetUserList()
        gridResult.Rebind()
    End Sub
    ''' <summary>
    ''' This is the command when user click delete.
    ''' </summary>
    ''' <param name="source">Pass the event source:datagrid.</param>
    ''' <param name="e">Pass the event args.</param>
    ''' <remarks></remarks>
    Protected Sub gridResult_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles gridResult.DeleteCommand
        Dim id As Integer = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("IDColumn").Text
        UserBLL.DeleteUser(id)
        GetUserList()
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
            'e.Item.Cells(2).Text = "<a href='#' onclick=javascript:OpenModifyPage('" + id + "') >aaa</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("editColumn").Text = "<a href='#' onclick=javascript:OpenModifyPage('" + id + "') >Edit</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("roleColumn").Text = "<a href='#' onclick=javascript:OpenAssignRolePage('" + id + "') >Assign Role</a>"
        End If
    End Sub
    ''' <summary>
    ''' This method is uese to get user list and save the user list to viewstate.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetUserList()
      
        userQueryFilter.Name = Me.txtName.Text.Trim()
        userQueryFilter.PositionID = ddlPosition.SelectedValue
        Dim userList As DataSet = UserBLL.GetUserListByFilter(userQueryFilter)
        ViewState("UserList") = userList
    End Sub
    
    ''' <summary>
    ''' This is event whey need datasource event firs.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub gridResult_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles gridResult.NeedDataSource
        'we will save userlist in viewstate
        If ViewState("UserList") Is Nothing Then
            GetUserList()
        End If
        'get datasource from viewstate instead of getting data from database.
        gridResult.DataSource = ViewState("UserList")
    End Sub
End Class
