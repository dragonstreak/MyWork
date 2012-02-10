Imports DataAccess
Imports System.Data
Imports Utils.PageUtils

Partial Class User_TeamQuery
    Inherits System.Web.UI.Page

    Private UserInfoBLL As New DataAccess.BLL.UserInfoBLL
    Private CityInfoBLL As New DataAccess.BLL.Base_CityInfoBLL
    Private TeamInfoBLL As New DataAccess.BLL.User_TeamInfoBLL
    Private SectorBLL As New BLL.Base_SectorBLL
    Private teamQueryFilter As New Model.TeamQueryFilter


    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim objError As Exception
        objError = Server.GetLastError.GetBaseException
        If clsWarningHandle.GetPageError(objError) = True Then
            Server.ClearError()
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitForm()
        End If
    End Sub


    Private Sub InitForm()
        Dim ds As DataSet
        Dim dt As New DataTable

        ds = CityInfoBLL.GetCityInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.ddlCity, ds, "ID", "City", 2)
        End If

        ds = TeamInfoBLL.GetTeamInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.ddlParent, ds, "ID", "TeamName", 2)
        End If

        ds = SectorBLL.GetSectorInfo()
        If Not ds Is Nothing Then
            Utils.PageUtils.BindDropDownList(Me.ddlSector, ds, "ID", "Sector", 2)
        End If



    End Sub


    Protected Sub gridResult_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles gridResult.NeedDataSource

        teamQueryFilter.TeamName = txtTeamName.Text.Trim()
        'teamQueryFilter.CityID = ddlCity.SelectedValue
        teamQueryFilter.ParentID = ddlParent.SelectedValue
        teamQueryFilter.SectorID = ddlSector.SelectedValue
        Dim dsTeamList As DataSet = TeamInfoBLL.GetTeamListByFilter(teamQueryFilter)
        gridResult.DataSource = dsTeamList
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Me.gridResult.Rebind()
    End Sub

    Protected Sub gridResult_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles gridResult.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim id As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("IDColumn").Text
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("editColumn").Text = "<a href='#' onclick=javascript:OpenModifyPage('" + id + "') >Edit</a>"
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("roleColumn").Text = "<a href='#' onclick=javascript:OpenAssignRolePage('" + id + "') >Assign Role</a>"
        End If
    End Sub

End Class
