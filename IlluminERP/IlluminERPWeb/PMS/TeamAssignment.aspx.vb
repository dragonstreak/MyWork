
Imports DataAccess.BLL
Imports DataAccess.Model
Imports System.Data
Imports Utils.PageUtils
Imports Utils
Imports DataAccess
Imports System.Collections
Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Class PMS_TeamAssignment
    Inherits System.Web.UI.Page
    Private ProjectTypeBLL As New BLL.Base_ProjectTypeBLL
    Private ClientInfoBLL As New BLL.Client_ClientInfoBLL
    Private SectorBLL As New BLL.Base_SectorBLL
    Private ProductCategory As New BLL.Base_ProductCategoryBLL
    Private StudyType As New BLL.Base_StudyTypeBLL

    Private BusinessUnitBLL As New BLL.Base_busiessUnitBLL
    Private MyUserInfoBLL As New BLL.UserInfoBLL
    Private StudyTypeBLL As New BLL.Base_StudyTypeBLL
    Private MyUserinfo As New Model.User_UserInfo
    Private UserInfoBLL As New BLL.UserInfoBLL
    Private ProposalUserInfo As New Model.PMS_ProposalUserInfo

    Private ProposalInfoBLL As New BLL.PMS_ProposalInfoBLL
    Private ProjectStatusBLL As New BLL.Base_ProjectStatusBLL
    Private ProposalUserinfoBll As New BLL.PMS_ProposalUserInfoBLL
    Private colUser As New Collection
    Private userPostionBLL As New BLL.Base_PositionInfoBLL
    Private ProposalUsertypeBLL As New BLL.PMS_ProposalUserTypeBLL


    Dim info As New Model.PMS_ProposalInfo
    Dim ClientInfo As New Model.Client_ClientInfo
    Dim userinfo As New Model.User_UserInfo



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not Page.IsPostBack Then
            Dim strProId As String
            If Not Session("LoginUserInfo") Is Nothing Then
                MyUserinfo = Session("LoginUserInfo")
            End If

            If Not Request.QueryString("proid") Is Nothing Then
                strProId = Request.QueryString("proid")

                If ProposalUserinfoBll.IsExistUserInfo(MyUserinfo.ID, strProId) = False Then
                    Call Me.DisableForm()
                End If

                InitComboBox()
                Call GetproposalInfobyId(strProId)
            End If
            
        End If

    End Sub

    Private Sub DisableForm()
        Me.cbRole.Enabled = False
        Me.cbUserSelect.Enabled = False
        Me.btnAddon.Enabled = False
    End Sub
    
    Private Sub InitComboBox()
        Dim ds As DataSet
        Dim sFilter As String
        Dim strCompanyType As String
        sFilter = "Onduty=1"
        strCompanyType = Me.cbCompanyType.SelectedValue

        Dim strId As String = Request.QueryString("Proid")

        sFilter = sFilter & " And  CompanyType='" & strCompanyType & "'"
        Dim dv As DataView = Me.UserInfoBLL.GetUserList(sFilter)


        If Not dv Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbUserSelect, dv, "Id", "E_name", 2)
        End If

        ds = ProposalUsertypeBLL.GetProposalUserTypeInfo

        If Not ds Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbRole, ds, "Id", "ProposalUserType", 2)
        End If

        dv = UserInfoBLL.GetTemUserList(strId)

        Me.radGridTeamUser.DataSource = dv
        Me.radGridTeamUser.DataBind()




    End Sub

    Private Sub GetproposalInfobyId(ByVal StrId As String)

        Dim dv As New DataView
        Try
            info = ProposalInfoBLL.GetProposalInfoByID(CInt(StrId))
            ViewState("info") = info
            If info Is Nothing Then
                Exit Sub
            End If

        Catch ex As Exception

        End Try



    End Sub

    Protected Sub btnAddon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddon.Click
        Dim strid As String
        Dim ds As DataSet
        strid = Request.QueryString("proid")
        If Me.cbUserSelect.SelectedValue <> 0 Then

            ProposalUserInfo.ProId = strid
            ProposalUserInfo.UserId = Me.cbUserSelect.SelectedValue
            ProposalUserInfo.ProposalUserTypeId = Me.cbRole.SelectedValue
            ProposalUserinfoBll.AddProposalUserinfo(ProposalUserInfo)
        End If

        Dim dv As DataView
        dv = UserInfoBLL.GetTemUserList(strid)
        If Not dv Is Nothing Then
            Me.radGridTeamUser.DataSource = dv
            Me.radGridTeamUser.DataBind()
        End If

        Me.cbUserSelect.SelectedValue = 0
    End Sub

    Protected Sub radGridTeamUser_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radGridTeamUser.DeleteCommand

        Dim Proid As String


        Proid = Request.QueryString("proid")
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim id As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnId").Text
            Dim strRole As String = DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnRole").Text.Trim
            Dim info As New Model.PMS_ProposalUserInfo

            If strRole = "Creator" Or strRole = "Project Owner" Then
                Exit Sub
            End If

            info.Id = id

            If ProposalUserinfoBll.DeleteProposalUserInfo(info) Then
                Dim dv As DataView
                dv = UserInfoBLL.GetTemUserList(Proid)
                If Not dv Is Nothing Then
                    Me.radGridTeamUser.DataSource = dv
                    Me.radGridTeamUser.DataBind()
                End If
            End If
        End If


    End Sub

    Protected Sub radGridTeamUser_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radGridTeamUser.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnPositionId").Text = userPostionBLL.GetPositionInfoByID(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnPositionId").Text).Position
            DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnRole").Text = ProposalUsertypeBLL.GetProposalUserTypeInfoByID(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Item("columnRole").Text).ProposalUserType

        End If
    End Sub

    Protected Sub radGridTeamUser_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridTeamUser.NeedDataSource
        Dim dv As DataView
        Dim strId As String = Request.QueryString("Proid")
        dv = UserInfoBLL.GetTemUserList(strId)

        Me.radGridTeamUser.DataSource = dv
        ' Me.radGridTeamUser.DataBind()
    End Sub

    Protected Sub cbUserSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbUserSelect.SelectedIndexChanged

    End Sub

    Protected Sub cbCompanyType_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cbCompanyType.SelectedIndexChanged

        Dim sFilter As String
        Dim strCompanyType As String
        sFilter = "Onduty=1"
        strCompanyType = Me.cbCompanyType.SelectedValue

        Dim strId As String = Request.QueryString("Proid")

        sFilter = sFilter & " And  CompanyType='" & strCompanyType & "'"
        Dim dv As DataView = Me.UserInfoBLL.GetUserList(sFilter)


        If Not dv Is Nothing Then
            Utils.PageUtils.BindComboBoxList(Me.cbUserSelect, dv, "Id", "E_name", 2)
        End If
    End Sub
End Class
