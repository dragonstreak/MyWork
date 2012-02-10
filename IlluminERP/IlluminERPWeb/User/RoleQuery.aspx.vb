Imports System
Imports System.Data
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic

Imports Telerik.Web.UI

Imports DataAccess.BLL
Imports DataAccess.Model

Imports Utils

Partial Class RoleQuery
    Inherits PageBase

    Private RoleBLL As New User_RoleBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitPageSetting()
        End If
    End Sub

    Private Sub InitPageSetting()
        PageUtils.BindDropDownList(ddlStatus, EnumTextHelper.GetEnumTextList(GetType(ConstantsUtils.IsEnableEnum)), "ID", "TEXT", 1)

    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        GetRoleList()
        gridResult.Rebind()
    End Sub

    Private Sub GetRoleList()
        Dim roleFilter As New RoleQueryFilter
        roleFilter.Name = txtName.Text
        roleFilter.Status = Convert.ToInt32(ddlStatus.SelectedValue)
        Dim roleList As DataSet = RoleBLL.GetRoleListByFilter(roleFilter)
        ViewState("RoleList") = roleList
    End Sub

    Protected Sub gridResult_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles gridResult.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim id As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("IDColumn").Text
            'e.Item.Cells(2).Text = "<a href='#' onclick=javascript:OpenModifyPage('" + id + "') >aaa</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("editColumn").Text = "<a href='#' onclick=javascript:OpenModifyPage('" + id + "') >Edit</a>"
            Dim gridRow As Telerik.Web.UI.GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)
            Dim drv As DataRowView = DirectCast(gridRow.DataItem, DataRowView)
            If Not Convert.IsDBNull(drv("Status")) Then
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("statusColumn").Text = EnumTextHelper.GetEnumText(CType(Integer.Parse(drv("Status")), ConstantsUtils.IsEnableEnum))
            Else
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("statusColumn").Text = "UnKnow"
            End If

        End If
    End Sub


    Protected Sub gridResult_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles gridResult.NeedDataSource
        'we will save userlist in viewstate
        If ViewState("RoleList") Is Nothing Then
            GetRoleList()
        End If
        'get datasource from viewstate instead of getting data from database.
        gridResult.DataSource = ViewState("RoleList")
    End Sub

End Class
