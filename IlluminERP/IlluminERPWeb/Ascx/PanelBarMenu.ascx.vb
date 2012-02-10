Imports DataAccess.BLL
Imports DataAccess.Model
Imports System
Imports System.Data

Imports Utils


Partial Class Ascx_PanelBarMenu
    Inherits System.Web.UI.UserControl
    Private SystemModelBLL As New System_ModelBLL
    Private SystemPermissionBLL As New System_PermissionBLL

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim objError As Exception
        objError = Server.GetLastError.GetBaseException
        If clsWarningHandle.GetPageError(objError) = True Then
            Server.ClearError()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitPanelBarMenu()
        End If
    End Sub

    Protected Sub InitPanelBarMenu()
        Dim loginUser As DataAccess.Model.User_UserInfo = CType(Session("LoginUserInfo"), DataAccess.Model.User_UserInfo)
        Dim dsUserPer As DataSet = SystemPermissionBLL.GetUserHierarchicalPermissions(loginUser)
        Dim moduleName As String = IIf(String.IsNullOrEmpty(Context.Request.QueryString("Module")), "UnKnow", Context.Request.QueryString("Module"))
        If moduleName = "UnKnow" Then
            Dim getPageModuleParam As New GetPageModuleParam
            getPageModuleParam.PageUrl = Context.Request.RawUrl
            Dim Id As String = Me.Request.QueryString("sysid")
            Dim getPageModuleResult As GetPageModuleResult = SystemMgrService.Instance.GetPageModule(getPageModuleParam)

            Dim systemPermissionInfo As New DataAccess.Model.System_PermissionInfo

            ' systemPermissionInfo = SystemPermissionBLL.GetPerMissionInfoById(Id)
            If systemPermissionInfo IsNot Nothing Then
                moduleName = systemPermissionInfo.SystemModule
            End If

            If getPageModuleResult IsNot Nothing And getPageModuleResult.IsSuccess Then
                moduleName = getPageModuleResult.ModuleName
            End If
        End If

        Dim dvUserPer As DataView
        If dsUserPer IsNot Nothing Then
            Dim userPer = From per In dsUserPer.Tables(0).AsEnumerable() _
                          Where Not Convert.IsDBNull(per("SystemModule")) AndAlso per("SystemModule").ToString().Equals(moduleName, StringComparison.OrdinalIgnoreCase)

            dvUserPer = userPer.AsDataView()
            If dvUserPer.Count > 0 Then
                Utils.PageUtils.InitPanelBar(dvUserPer, Me.LeftMenuPanel, "ID", "ParentId", "Name", "ID", "LinkUrl")
                Me.LeftMenuPanel.Items(0).Expanded = True
            End If

        End If

    End Sub

    Protected Sub LeftMenuPanel_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadPanelBarEventArgs) Handles LeftMenuPanel.ItemDataBound
        If String.Compare(e.Item.Text.Trim(), "dividingline") = 0 Then
            e.Item.Text = ""
            e.Item.ImageUrl = "../Images/line3.jpg"

        End If

        If e.Item.NavigateUrl.Contains(PageUtils.GetPageName(Context.Request.RawUrl)) Then
            If PageUtils.GetPageQueryString(e.Item.NavigateUrl).Length > 0 Then
                If PageUtils.GetPageQueryString(Request.RawUrl).Contains(PageUtils.GetPageQueryString(e.Item.NavigateUrl)) Then
                    e.Item.Selected = True
                End If
            Else
                e.Item.Selected = True
            End If
        End If

        'Dim drItem As DataRowView = e.Item.DataItem
        'If drItem("PerLevel").ToString().Trim() = "1" Then
        '    e.Item.CssClass = "HideTopLevelLeftMenu"
        'End If
    End Sub
End Class
