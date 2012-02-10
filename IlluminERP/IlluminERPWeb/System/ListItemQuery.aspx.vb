Imports System
Imports System.Data
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic

Imports Telerik.Web.UI

Imports DataAccess.BLL
Imports DataAccess.Model

Imports Utils

Partial Class ListItemQuery
    Inherits PageBase

    Private ListItemBLL As New Base_ListItemBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitPageSetting()
        End If
    End Sub

    Private Sub InitPageSetting()
        PageUtils.BindDropDownList(ddlTypeQry, EnumTextHelper.GetEnumTextList(GetType(ConstantsUtils.ListItemTypeEnum)), "ID", "TEXT", 1)

    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        gridResult.Rebind()
    End Sub

    Private Function GetListItemList() As DataTable
        Dim listItemFilter As New ListItemQueryFilter
        listItemFilter.Content = txtNameQry.Text
        listItemFilter.Type = Convert.ToInt32(ddlTypeQry.SelectedValue)
        Dim listItemList As DataTable = ListItemBLL.GetEntityList(listItemFilter)
        Return listItemList
    End Function

    Protected Sub gridResult_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles gridResult.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim gridRow As Telerik.Web.UI.GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)
            Dim drv As DataRowView = DirectCast(gridRow.DataItem, DataRowView)
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("editColumn").Text = "<a href='#' onclick=javascript:OpenModifyPage('" + Convert.ToInt32(drv("ListItemID")).ToString() + "') >Edit</a>"
            If Not Convert.IsDBNull(drv("Type")) Then
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("typeColumn").Text = EnumTextHelper.GetEnumText(CType(Integer.Parse(drv("Type")), ConstantsUtils.ListItemTypeEnum))
            Else
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("typeColumn").Text = "UnKnow"
            End If

            If Not Convert.IsDBNull(drv("ParentID")) Then
                Dim parentListItem As Base_ListItem
                parentListItem = ListItemBLL.GetEntityByID(Convert.ToInt32(drv("ParentID")))
                If parentListItem IsNot Nothing Then
                    DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("parentColumn").Text = parentListItem.ContentText
                Else
                    DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("parentColumn").Text = String.Empty
                End If
            Else
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("parentColumn").Text = String.Empty
            End If

        End If
    End Sub


    Protected Sub gridResult_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles gridResult.NeedDataSource
        Dim dtListItem As DataTable = GetListItemList()
        gridResult.DataSource = dtListItem
    End Sub

End Class
