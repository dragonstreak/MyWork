Imports System
Imports System.Data
Imports System.Linq
Imports System.Collections
Imports System.Collections.Generic

Imports Telerik.Web.UI

Imports DataAccess.BLL
Imports DataAccess.Model

Imports Utils

Partial Class NewsQuery
    Inherits PageBase

    Private NewsBLL As New System_NewsBLL
    Private ListItemBLL As New Base_ListItemBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitPageSetting()
        End If
    End Sub

    Private Sub InitPageSetting()

        Dim listItemFilter As New ListItemQueryFilter
        listItemFilter.Content = String.Empty
        listItemFilter.Type = Convert.ToInt32(ConstantsUtils.ListItemTypeEnum.NewsType)
        Dim dtNewsType As DataTable = ListItemBLL.GetEntityList(listItemFilter)
        PageUtils.BindDropDownList(ddlTypeQry, dtNewsType, "ListItemID", "ContentText", 1)
        PageUtils.BindDropDownList(ddlSeverityQry, EnumTextHelper.GetEnumTextList(GetType(ConstantsUtils.NewsSeverityEnum)), "ID", "TEXT", 1)
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        GetNewsList()
        gridResult.Rebind()
    End Sub

    Private Function GetNewsList() As DataTable
        Dim newsFilter As New NewsQueryFilter
        newsFilter.Title = txtTitleQry.Text.Trim()
        If ddlTypeQry.Items.Count > 0 Then
            newsFilter.NewsType = Convert.ToInt32(ddlTypeQry.SelectedValue)
        End If
        newsFilter.SeverityLevel = Convert.ToInt32(ddlSeverityQry.SelectedValue)
        Dim NewsList As DataTable = NewsBLL.GetEntityList(newsFilter)
        Return NewsList
    End Function

    Protected Sub gridResult_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles gridResult.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim gridRow As Telerik.Web.UI.GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)
            Dim drv As DataRowView = DirectCast(gridRow.DataItem, DataRowView)
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("editColumn").Text = "<a href='#' onclick=javascript:OpenModifyPage('" + Convert.ToInt32(drv("NewsID")).ToString() + "') >Edit</a>"
            If Not Convert.IsDBNull(drv("SeverityLevel")) Then
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("severityColumn").Text = EnumTextHelper.GetEnumText(CType(Integer.Parse(drv("SeverityLevel")), ConstantsUtils.NewsSeverityEnum))
            Else
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("severityColumn").Text = "UnKnow"
            End If

            If Not Convert.IsDBNull(drv("Published")) Then
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("publishedColum").Text = EnumTextHelper.GetEnumText(CType(Integer.Parse(drv("Published")), ConstantsUtils.YesNoEnum))
            Else
                DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("publishedColum").Text = "UnKnow"
            End If
        End If
    End Sub


    Protected Sub gridResult_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles gridResult.NeedDataSource
        Dim NewsList As DataTable = GetNewsList()
 
        gridResult.DataSource = NewsList
    End Sub

End Class
